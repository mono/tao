#region License
/*
MIT License
Copyright ©2003-2006 Tao Framework Team
http://www.taoframework.com
All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.CodeDom;

namespace Tao.GlBindGen
{
    static class SpecWriter
    {
        internal class FieldComparer : Comparer<CodeMemberField>
        {
            public override int Compare(CodeMemberField x, CodeMemberField y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        internal class MethodComparer : Comparer<CodeMemberMethod>
        {
            public override int Compare(CodeMemberMethod x, CodeMemberMethod y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        internal class DelegateComparer : Comparer<CodeTypeDelegate>
        {
            public override int Compare(CodeTypeDelegate x, CodeTypeDelegate y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        #region Generate

        public static void Generate(
            string output_path,
            List<CodeTypeDelegate> delegates,
            List<CodeMemberMethod> functions,
            List<CodeMemberField> constants
        )
        {
            string filename = Path.Combine(output_path, Properties.Bind.Default.OutputClass + ".cs");

            if (!Directory.Exists(Properties.Bind.Default.OutputPath))
                Directory.CreateDirectory(Properties.Bind.Default.OutputPath);

            CodeNamespace ns = new CodeNamespace(Properties.Bind.Default.OutputNamespace);

            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("System.Runtime.InteropServices"));
            ns.Imports.Add(new CodeNamespaceImport("System.Text"));

            foreach (string key in SpecTranslator.CSTypes.Keys)
            {
                ns.Imports.Add(new CodeNamespaceImport(key + " = System." + SpecTranslator.CSTypes[key].BaseType));
            }

            constants.Sort(new FieldComparer());
            functions.Sort(new MethodComparer());
            delegates.Sort(new DelegateComparer());

            ns.Types.Add(GenerateGlClass(functions, constants));
            ns.Types.Add(GenerateDelegatesClass(delegates));
            ns.Types.Add(GenerateImportsClass(delegates));

            CodeCompileUnit cu = new CodeCompileUnit();
            /*
            cu.AssemblyCustomAttributes.Add(
                new CodeAttributeDeclaration(
                    "System.CLSCompliant",
                    new CodeAttributeArgument[] {
                        new CodeAttributeArgument(
                            new CodeSnippetExpression("true")
                        ) 
                    }
                )
            );
            */
            cu.StartDirectives.Add(new CodeDirective());
            cu.Namespaces.Add(ns);

            using (StreamWriter sw = new StreamWriter(filename, false))
            {
                Console.WriteLine("Writing Tao.OpenGl.Gl class to {0}", filename);

                Microsoft.CSharp.CSharpCodeProvider cs = new Microsoft.CSharp.CSharpCodeProvider();
                System.CodeDom.Compiler.CodeGeneratorOptions options = new System.CodeDom.Compiler.CodeGeneratorOptions();
                options.BracingStyle = "C";
                options.BlankLinesBetweenMembers = false;
                options.VerbatimOrder = true;

                cs.GenerateCodeFromCompileUnit(cu, sw, options);

                sw.Flush();
            }
        }

        #endregion

        #region private static CodeTypeDeclaration GenerateGlClass(List<CodeMemberMethod> functions, List<CodeMemberField> constants)
        private static CodeTypeDeclaration GenerateGlClass(List<CodeMemberMethod> functions, List<CodeMemberField> constants)
        
        {
            CodeTypeDeclaration gl_class = new CodeTypeDeclaration(Properties.Bind.Default.OutputClass);
            gl_class.IsClass = true;
            gl_class.IsPartial = true;
            gl_class.TypeAttributes = System.Reflection.TypeAttributes.Public;

            gl_class.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "GL class"));
            gl_class.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, "GL class"));

            gl_class.Members.Add(new CodeSnippetTypeMember("        #pragma warning disable 1591"));

            gl_class.Members.Add(new CodeSnippetTypeMember(
@"
        #region Private Constants

        #region string GL_NATIVE_LIBRARY
        /// <summary>
        /// Specifies OpenGl's native library archive.
        /// </summary>
        /// <remarks>
        /// Specifies opengl32.dll everywhere; will be mapped via .config for mono.
        /// </remarks>
        internal const string GL_NATIVE_LIBRARY = ""opengl32.dll"";
        #endregion string GL_NATIVE_LIBRARY

        #endregion Private Constants
"));

            gl_class.Members.AddRange(constants.ToArray());
            gl_class.Members.AddRange(functions.ToArray());

            return gl_class;
        }                 
        #endregion

        #region private static CodeTypeDeclaration GenerateDelegatesClass(List<CodeTypeDelegate> delegates)
        private static CodeTypeDeclaration GenerateDelegatesClass(List<CodeTypeDelegate> delegates)
        
        {
            CodeTypeDeclaration delegate_class = new CodeTypeDeclaration("Delegates");
            delegate_class.TypeAttributes = System.Reflection.TypeAttributes.NotPublic;

            CodeStatementCollection statements = new CodeStatementCollection();

            foreach (CodeTypeDelegate d in delegates)
            {
                delegate_class.Members.Add(d);

                CodeMemberField m = new CodeMemberField();
                m.Name = "gl" + d.Name;
                m.Type = new CodeTypeReference(d.Name);
                m.Attributes = MemberAttributes.Public | MemberAttributes.Static;
                
                //m.InitExpression =
                    //new CodeCastExpression(
                    //    "Delegates." + d.Name,
                    //    new CodeMethodInvokeExpression(
                    //        new CodeMethodReferenceExpression(
                    //            new CodeTypeReferenceExpression(Properties.Bind.Default.OutputClass),
                    //            "GetDelegateForExtensionMethod"
                    //        ),
                    //        new CodeExpression[] { 
                    //            new CodeSnippetExpression("\"gl" + d.Name + "\""),
                    //            new CodeTypeOfExpression("Delegates." + d.Name)
                    //        }
                    //    )
                    //);

                // Hack - generate inline initialisers in the form:
                // public static Accum glAccum = GetDelegate[...] ?? new Accum(Imports.Accum);
                CodeSnippetExpression expr = new CodeSnippetExpression();
                //expr.Value = "public static " + d.Name + " gl" + d.Name + " = ";
                expr.Value += "((" + d.Name + ")(Gl.GetDelegateForExtensionMethod(\"" + "gl" + d.Name + "\", typeof(" + d.Name + "))))";
                if (d.UserData.Contains("Extension") && !(bool)d.UserData["Extension"])
                {
                    expr.Value += " ?? ";
                    expr.Value += "new " + d.Name + "(Imports." + d.Name + ")";
                }

                m.InitExpression = expr;
                delegate_class.Members.Add(m);

                /*
                if (!(bool)d.UserData["Extension"])
                {
                    statements.Add(
                        new CodeSnippetExpression(
                            "Delegates.gl" + d.Name + " = Delegates.gl" + d.Name + " ?? new Delegates." + d.Name + "(Imports." + d.Name + ")"
                        )
                    );
                }
                */
            }

            // Disable BeforeFieldInit attribute and initialize OpenGL core.
            CodeTypeConstructor con = new CodeTypeConstructor();
            //con.Statements.AddRange(statements);
            delegate_class.Members.Add(con);

            delegate_class.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, delegate_class.Name));
            delegate_class.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, delegate_class.Name));

            return delegate_class;
        }
        #endregion

        #region private static CodeTypeDeclaration GenerateImportsClass(List<CodeTypeDelegate> delegates)
        private static CodeTypeDeclaration GenerateImportsClass(List<CodeTypeDelegate> delegates)
        {
            CodeTypeDeclaration import_class = new CodeTypeDeclaration("Imports");
            import_class.TypeAttributes = System.Reflection.TypeAttributes.NotPublic;
            import_class.Members.Add(new CodeTypeConstructor());

            foreach (CodeTypeDelegate d in delegates)
            {
                if (!(bool)d.UserData["Extension"])
                {
                    CodeMemberMethodImport m = new CodeMemberMethodImport();
                    
                    m.Name = d.Name;
                    m.CustomAttributes.Add(new CodeAttributeDeclaration("System.Security.SuppressUnmanagedCodeSecurity()"));
                    m.CustomAttributes.Add(new CodeAttributeDeclaration("DllImport(Gl.GL_NATIVE_LIBRARY, EntryPoint = \"" + "gl" + m.Name + "\", ExactSpelling = true)"));
                    m.Parameters.AddRange(d.Parameters);
                    m.ReturnType = d.ReturnType;

                    import_class.Members.Add(new CodeSnippetTypeMember(m.Text));
                    
                }
            }

            return import_class;
        }
        #endregion

        #region Write license

        private static void WriteLicense(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("#region License");
            streamWriter.WriteLine("/*");
            streamWriter.WriteLine("THIS FILE IS AUTOMATICALLY GENERATED");
            streamWriter.WriteLine("DO NOT EDIT BY HAND!!");
            streamWriter.WriteLine();
            streamWriter.WriteLine("MIT License");
            streamWriter.WriteLine("Copyright 2003-2006 Tao Framework Team");
            streamWriter.WriteLine("http://www.taoframework.com");
            streamWriter.WriteLine("All rights reserved.");
            streamWriter.WriteLine();
            streamWriter.WriteLine("Permission is hereby granted, free of charge, to any person obtaining a copy");
            streamWriter.WriteLine("of this software and associated documentation files (the \"Software\"), to deal");
            streamWriter.WriteLine("in the Software without restriction, including without limitation the rights");
            streamWriter.WriteLine("to use, copy, modify, merge, publish, distribute, sublicense, and/or sell");
            streamWriter.WriteLine("copies of the Software, and to permit persons to whom the Software is");
            streamWriter.WriteLine("furnished to do so, subject to the following conditions:");
            streamWriter.WriteLine();
            streamWriter.WriteLine("The above copyright notice and this permission notice shall be included in all");
            streamWriter.WriteLine("copies or substantial portions of the Software.");
            streamWriter.WriteLine();
            streamWriter.WriteLine("THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR");
            streamWriter.WriteLine("IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,");
            streamWriter.WriteLine("FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE");
            streamWriter.WriteLine("AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER");
            streamWriter.WriteLine("LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,");
            streamWriter.WriteLine("OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE");
            streamWriter.WriteLine("SOFTWARE.");
            streamWriter.WriteLine("*/");
            streamWriter.WriteLine("#endregion License");
        }

        #endregion
    }

    // Hacky, but that's the best we can do to get a DllImported function;
    // CodeDom does not directly support static extern methods.
    class CodeMemberMethodImport : CodeMemberMethod
    {
        public string Text
        {
            get
            {
                string s;
                //m.Attributes = MemberAttributes.Static | MemberAttributes.Public;
                s = "        #region " + this.Name + Environment.NewLine;
                s += "        [System.Security.SuppressUnmanagedCodeSecurity()]" + Environment.NewLine;
                s += "        [DllImport(Gl.GL_NATIVE_LIBRARY, EntryPoint = \"" + "gl" + this.Name + "\", ExactSpelling = true)]" + Environment.NewLine;
                s += "        public extern static ";
                if (this.ReturnType.BaseType == "System.Void")
                {
                    s += "void";
                }
                else
                {
                    s += this.ReturnType.BaseType;
                }

                s += " " + this.Name + "(";
                foreach (CodeParameterDeclarationExpression p in this.Parameters)
                {
                    s += p.Type.BaseType;
                    if (p.Type.ArrayRank > 0)
                        s += "[]";
                    s += " ";
                    if (p.Name == "base")
                        s += "@base";
                    else if (p.Name == "params")
                        s += "@params";
                    else if (p.Name == "string")
                        s += "@string";
                    else if (p.Name == "ref")
                        s += "@ref";
                    else
                        s += p.Name;
                    s += ", ";
                }
                s = s.TrimEnd(',', ' ') + ");" + Environment.NewLine;
                s += "        #endregion" + Environment.NewLine;

                return s;
            }
        }
    }
}
#region License
/*
MIT License
Copyright ©2003-2006 Tao Framework Team
http://www.taoframework.com
All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.CodeDom;

namespace Tao.GlBindGen
{
    static class SpecWriter
    {
        internal class FieldComparer : Comparer<CodeMemberField>
        {
            public override int Compare(CodeMemberField x, CodeMemberField y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        internal class MethodComparer : Comparer<CodeMemberMethod>
        {
            public override int Compare(CodeMemberMethod x, CodeMemberMethod y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        internal class DelegateComparer : Comparer<CodeTypeDelegate>
        {
            public override int Compare(CodeTypeDelegate x, CodeTypeDelegate y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        #region Generate

        public static void Generate(
            string output_path,
            List<CodeTypeDelegate> delegates,
            List<CodeMemberMethod> functions,
            List<CodeMemberField> constants
        )
        {
            string filename = Path.Combine(output_path, Properties.Bind.Default.OutputClass + ".cs");

            if (!Directory.Exists(Properties.Bind.Default.OutputPath))
                Directory.CreateDirectory(Properties.Bind.Default.OutputPath);

            CodeNamespace ns = new CodeNamespace(Properties.Bind.Default.OutputNamespace);

            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("System.Runtime.InteropServices"));
            ns.Imports.Add(new CodeNamespaceImport("System.Text"));

            foreach (string key in SpecTranslator.CSTypes.Keys)
            {
                ns.Imports.Add(new CodeNamespaceImport(key + " = System." + SpecTranslator.CSTypes[key].BaseType));
            }

            constants.Sort(new FieldComparer());
            functions.Sort(new MethodComparer());
            delegates.Sort(new DelegateComparer());

            ns.Types.Add(GenerateGlClass(functions, constants));
            ns.Types.Add(GenerateDelegatesClass(delegates));
            ns.Types.Add(GenerateImportsClass(delegates));

            CodeCompileUnit cu = new CodeCompileUnit();
            /*
            cu.AssemblyCustomAttributes.Add(
                new CodeAttributeDeclaration(
                    "System.CLSCompliant",
                    new CodeAttributeArgument[] {
                        new CodeAttributeArgument(
                            new CodeSnippetExpression("true")
                        ) 
                    }
                )
            );
            */
            cu.StartDirectives.Add(new CodeDirective());
            cu.Namespaces.Add(ns);

            using (StreamWriter sw = new StreamWriter(filename, false))
            {
                Console.WriteLine("Writing Tao.OpenGl.Gl class to {0}", filename);

                Microsoft.CSharp.CSharpCodeProvider cs = new Microsoft.CSharp.CSharpCodeProvider();
                System.CodeDom.Compiler.CodeGeneratorOptions options = new System.CodeDom.Compiler.CodeGeneratorOptions();
                options.BracingStyle = "C";
                options.BlankLinesBetweenMembers = false;
                options.VerbatimOrder = true;

                cs.GenerateCodeFromCompileUnit(cu, sw, options);

                sw.Flush();
            }
        }

        #endregion

        #region private static CodeTypeDeclaration GenerateGlClass(List<CodeMemberMethod> functions, List<CodeMemberField> constants)
        private static CodeTypeDeclaration GenerateGlClass(List<CodeMemberMethod> functions, List<CodeMemberField> constants)
        
        {
            CodeTypeDeclaration gl_class = new CodeTypeDeclaration(Properties.Bind.Default.OutputClass);
            gl_class.IsClass = true;
            gl_class.IsPartial = true;
            gl_class.TypeAttributes = System.Reflection.TypeAttributes.Public;

            gl_class.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "GL class"));
            gl_class.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, "GL class"));

            gl_class.Members.Add(new CodeSnippetTypeMember("        #pragma warning disable 1591"));

            gl_class.Members.Add(new CodeSnippetTypeMember(
@"
        #region Private Constants

        #region string GL_NATIVE_LIBRARY
        /// <summary>
        /// Specifies OpenGl's native library archive.
        /// </summary>
        /// <remarks>
        /// Specifies opengl32.dll everywhere; will be mapped via .config for mono.
        /// </remarks>
        internal const string GL_NATIVE_LIBRARY = ""opengl32.dll"";
        #endregion string GL_NATIVE_LIBRARY

        #endregion Private Constants
"));

            gl_class.Members.AddRange(constants.ToArray());
            gl_class.Members.AddRange(functions.ToArray());

            return gl_class;
        }                 
        #endregion

        #region private static CodeTypeDeclaration GenerateDelegatesClass(List<CodeTypeDelegate> delegates)
        private static CodeTypeDeclaration GenerateDelegatesClass(List<CodeTypeDelegate> delegates)
        
        {
            CodeTypeDeclaration delegate_class = new CodeTypeDeclaration("Delegates");
            delegate_class.TypeAttributes = System.Reflection.TypeAttributes.NotPublic;

            CodeStatementCollection statements = new CodeStatementCollection();

            foreach (CodeTypeDelegate d in delegates)
            {
                delegate_class.Members.Add(d);

                CodeMemberField m = new CodeMemberField();
                m.Name = "gl" + d.Name;
                m.Type = new CodeTypeReference(d.Name);
                m.Attributes = MemberAttributes.Public | MemberAttributes.Static;
                
                //m.InitExpression =
                    //new CodeCastExpression(
                    //    "Delegates." + d.Name,
                    //    new CodeMethodInvokeExpression(
                    //        new CodeMethodReferenceExpression(
                    //            new CodeTypeReferenceExpression(Properties.Bind.Default.OutputClass),
                    //            "GetDelegateForExtensionMethod"
                    //        ),
                    //        new CodeExpression[] { 
                    //            new CodeSnippetExpression("\"gl" + d.Name + "\""),
                    //            new CodeTypeOfExpression("Delegates." + d.Name)
                    //        }
                    //    )
                    //);

                // Hack - generate inline initialisers in the form:
                // public static Accum glAccum = GetDelegate[...] ?? new Accum(Imports.Accum);
                CodeSnippetExpression expr = new CodeSnippetExpression();
                //expr.Value = "public static " + d.Name + " gl" + d.Name + " = ";
                expr.Value += "((" + d.Name + ")(Gl.GetDelegateForExtensionMethod(\"" + "gl" + d.Name + "\", typeof(" + d.Name + "))))";
                if (d.UserData.Contains("Extension") && !(bool)d.UserData["Extension"])
                {
                    expr.Value += " ?? ";
                    expr.Value += "new " + d.Name + "(Imports." + d.Name + ")";
                }

                m.InitExpression = expr;
                delegate_class.Members.Add(m);

                /*
                if (!(bool)d.UserData["Extension"])
                {
                    statements.Add(
                        new CodeSnippetExpression(
                            "Delegates.gl" + d.Name + " = Delegates.gl" + d.Name + " ?? new Delegates." + d.Name + "(Imports." + d.Name + ")"
                        )
                    );
                }
                */
            }

            // Disable BeforeFieldInit attribute and initialize OpenGL core.
            CodeTypeConstructor con = new CodeTypeConstructor();
            //con.Statements.AddRange(statements);
            delegate_class.Members.Add(con);

            delegate_class.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, delegate_class.Name));
            delegate_class.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, delegate_class.Name));

            return delegate_class;
        }
        #endregion

        #region private static CodeTypeDeclaration GenerateImportsClass(List<CodeTypeDelegate> delegates)
        private static CodeTypeDeclaration GenerateImportsClass(List<CodeTypeDelegate> delegates)
        {
            CodeTypeDeclaration import_class = new CodeTypeDeclaration("Imports");
            import_class.TypeAttributes = System.Reflection.TypeAttributes.NotPublic;
            import_class.Members.Add(new CodeTypeConstructor());

            foreach (CodeTypeDelegate d in delegates)
            {
                if (!(bool)d.UserData["Extension"])
                {
                    CodeMemberMethodImport m = new CodeMemberMethodImport();
                    
                    m.Name = d.Name;
                    m.CustomAttributes.Add(new CodeAttributeDeclaration("System.Security.SuppressUnmanagedCodeSecurity()"));
                    m.CustomAttributes.Add(new CodeAttributeDeclaration("DllImport(Gl.GL_NATIVE_LIBRARY, EntryPoint = \"" + "gl" + m.Name + "\", ExactSpelling = true)"));
                    m.Parameters.AddRange(d.Parameters);
                    m.ReturnType = d.ReturnType;

                    import_class.Members.Add(new CodeSnippetTypeMember(m.Text));
                    
                }
            }

            return import_class;
        }
        #endregion

        #region Write license

        private static void WriteLicense(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("#region License");
            streamWriter.WriteLine("/*");
            streamWriter.WriteLine("THIS FILE IS AUTOMATICALLY GENERATED");
            streamWriter.WriteLine("DO NOT EDIT BY HAND!!");
            streamWriter.WriteLine();
            streamWriter.WriteLine("MIT License");
            streamWriter.WriteLine("Copyright 2003-2006 Tao Framework Team");
            streamWriter.WriteLine("http://www.taoframework.com");
            streamWriter.WriteLine("All rights reserved.");
            streamWriter.WriteLine();
            streamWriter.WriteLine("Permission is hereby granted, free of charge, to any person obtaining a copy");
            streamWriter.WriteLine("of this software and associated documentation files (the \"Software\"), to deal");
            streamWriter.WriteLine("in the Software without restriction, including without limitation the rights");
            streamWriter.WriteLine("to use, copy, modify, merge, publish, distribute, sublicense, and/or sell");
            streamWriter.WriteLine("copies of the Software, and to permit persons to whom the Software is");
            streamWriter.WriteLine("furnished to do so, subject to the following conditions:");
            streamWriter.WriteLine();
            streamWriter.WriteLine("The above copyright notice and this permission notice shall be included in all");
            streamWriter.WriteLine("copies or substantial portions of the Software.");
            streamWriter.WriteLine();
            streamWriter.WriteLine("THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR");
            streamWriter.WriteLine("IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,");
            streamWriter.WriteLine("FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE");
            streamWriter.WriteLine("AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER");
            streamWriter.WriteLine("LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,");
            streamWriter.WriteLine("OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE");
            streamWriter.WriteLine("SOFTWARE.");
            streamWriter.WriteLine("*/");
            streamWriter.WriteLine("#endregion License");
        }

        #endregion
    }

    // Hacky, but that's the best we can do to get a DllImported function;
    // CodeDom does not directly support static extern methods.
    class CodeMemberMethodImport : CodeMemberMethod
    {
        public string Text
        {
            get
            {
                string s;
                //m.Attributes = MemberAttributes.Static | MemberAttributes.Public;
                s = "        #region " + this.Name + Environment.NewLine;
                s += "        [System.Security.SuppressUnmanagedCodeSecurity()]" + Environment.NewLine;
                s += "        [DllImport(Gl.GL_NATIVE_LIBRARY, EntryPoint = \"" + "gl" + this.Name + "\", ExactSpelling = true)]" + Environment.NewLine;
                s += "        public extern static ";
                if (this.ReturnType.BaseType == "System.Void")
                {
                    s += "void";
                }
                else
                {
                    s += this.ReturnType.BaseType;
                }

                s += " " + this.Name + "(";
                foreach (CodeParameterDeclarationExpression p in this.Parameters)
                {
                    s += p.Type.BaseType;
                    if (p.Type.ArrayRank > 0)
                        s += "[]";
                    s += " ";
                    if (p.Name == "base")
                        s += "@base";
                    else if (p.Name == "params")
                        s += "@params";
                    else if (p.Name == "string")
                        s += "@string";
                    else if (p.Name == "ref")
                        s += "@ref";
                    else
                        s += p.Name;
                    s += ", ";
                }
                s = s.TrimEnd(',', ' ') + ");" + Environment.NewLine;
                s += "        #endregion" + Environment.NewLine;

                return s;
            }
        }
    }
}
