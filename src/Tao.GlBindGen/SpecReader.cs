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
using System.CodeDom;

namespace Tao.GlBindGen
{
    static class SpecReader
    {
        #region internal static string FilePath
        internal static string FilePath
        {
            get
            {
                string filePath = Path.Combine("..", "..");
                string fileDirectory = Properties.Bind.Default.InputSpecFilesPath;
                string fileName = "gl.spec";

                if (File.Exists(fileName))
                {
                    filePath = "";
                    fileDirectory = "";
                }
                else if (File.Exists(Path.Combine(fileDirectory, fileName)))
                {
                    filePath = "";
                }
                return Path.Combine(filePath, fileDirectory);
            }
        }
        #endregion

        #region private static StreamReader OpenSpecFile(string file)
        private static StreamReader OpenSpecFile(string file)
        {
            string path = Path.Combine(FilePath, file);
            StreamReader sr;

            try
            {
                sr = new StreamReader(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error opening spec file: {0}", path);
                Console.WriteLine("Error: {0}", e.Message);
                throw e;
            }

            return sr;
        }
        #endregion

        #region private static bool IsExtension(string function_name)
        private static bool IsExtension(string function_name)
        {
            return (function_name.EndsWith("ARB") ||
                    function_name.EndsWith("EXT") ||
                    function_name.EndsWith("ATI") ||
                    function_name.EndsWith("NV") ||
                    function_name.EndsWith("SUN") ||
                    function_name.EndsWith("SUNX") ||
                    function_name.EndsWith("SGI") ||
                    function_name.EndsWith("SGIS") ||
                    function_name.EndsWith("SGIX") ||
                    function_name.EndsWith("MESA") ||
                    function_name.EndsWith("3DFX") ||
                    function_name.EndsWith("IBM") ||
                    function_name.EndsWith("GREMEDY") ||
                    function_name.EndsWith("HP") ||
                    function_name.EndsWith("INTEL") ||
                    function_name.EndsWith("PGI") ||
                    function_name.EndsWith("INGR") ||
                    function_name.EndsWith("APPLE"));
        }
        #endregion

        #region private static string NextValidLine(StreamReader sr)
        private static string NextValidLine(StreamReader sr)
        {
            string line;

            do
            {
                if (sr.EndOfStream)
                    return null;

                line = sr.ReadLine().Trim();

                if (String.IsNullOrEmpty(line) ||
                    line.StartsWith("#") ||                 // Disregard comments.
                    line.StartsWith("passthru") ||          // Disregard passthru statements.
                    line.StartsWith("required-props:") ||
                    line.StartsWith("param:") ||
                    line.StartsWith("dlflags:") ||
                    line.StartsWith("glxflags:") ||
                    line.StartsWith("vectorequiv:") ||
                    line.StartsWith("category:") ||
                    line.StartsWith("version:") ||
                    line.StartsWith("glxsingle:") ||
                    line.StartsWith("glxropcode:") ||
                    line.StartsWith("glxvendorpriv:") ||
                    line.StartsWith("glsflags:") ||
                    line.StartsWith("glsopcode:") ||
                    line.StartsWith("glsalias:") ||
                    line.StartsWith("wglflags:") ||
                    line.StartsWith("extension:") ||
                    line.StartsWith("alias:") ||
                    line.StartsWith("offset:"))
                    continue;

                return line;
            }
            while (true);
        }
        #endregion

        #region public static void ReadFunctionSpecs(string file, out List<CodeTypeDelegate> delegates, out List<CodeMemberMethod> functions)
        public static void ReadFunctionSpecs(
            string file,
            out List<CodeTypeDelegate> delegates,
            out List<CodeMemberMethod> functions)
        {
            StreamReader sr = OpenSpecFile(file);
            Console.WriteLine("Reading function specs from file: {0}", file);

            functions = new List<CodeMemberMethod>();
            delegates = new List<CodeTypeDelegate>();

            do
            {
                string line = NextValidLine(sr);
                if (String.IsNullOrEmpty(line))
                    break;

                // Get next OpenGL function
                while (line.Contains("(") && !sr.EndOfStream)
                {
                    CodeTypeDelegate d = new CodeTypeDelegate();
                    d.Attributes = MemberAttributes.Static;
                    d.CustomAttributes.Add(new CodeAttributeDeclaration("System.Security.SuppressUnmanagedCodeSecurity"));

                    // Get function name:
                    d.Name = line.Split(SpecTranslator.Separators, StringSplitOptions.RemoveEmptyEntries)[0];
                    if (IsExtension(d.Name))
                    {
                        d.UserData.Add("Extension", true);
                    }
                    else
                    {
                        d.UserData.Add("Extension", false);
                    }

                    d.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, d.Name));
                    d.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, d.Name));

                    // Get function parameters and return value:
                    do
                    {
                        line = sr.ReadLine();
                        List<string> words = new List<string>(
                            line.Replace('\t', ' ').Split(SpecTranslator.Separators, StringSplitOptions.RemoveEmptyEntries));

                        if (words.Count == 0)
                            break;

                        // Identify line:
                        switch (words[0])
                        {
                            case "return":  // Line denotes return value
                                CodeTypeReference tr = new CodeTypeReference(
                                    //SpecTranslator.GetEquivalentType(words[1])
                                    words[1]
                                );

                                if (tr.BaseType == "GLvoid")
                                    tr.BaseType = "System.Void";

                                d.ReturnType = tr;
                                break;

                            case "param":   // Line denotes parameter
                                CodeParameterDeclarationExpression p =
                                    new CodeParameterDeclarationExpression();
                                p.Name = words[1];
                                p.Type = new CodeTypeReference(words[2]);
                                //p.Direction = words[3] == "in" ? FieldDirection.In : FieldDirection.Ref;
                                if (words[3] != "in")
                                    p.CustomAttributes.Add(new CodeAttributeDeclaration("In, Out"));
                                p.Type.ArrayRank = words[4] == "array" ? 1 : 0;

                                /*
                                CodeParameterDeclarationExpression p =
                                    new CodeParameterDeclarationExpression(
                                        SpecTranslator.GetEquivalentType(words[2]),
                                        SpecTranslator.GetEquivalentName(words[1])
                                    );

                                if (p.Type.BaseType == "GLvoid")
                                {
                                    p.Type.BaseType = "System.Object";
                                }
                                */

                                d.Parameters.Add(p);
                                break;

                            case "version": // Line denotes function version (i.e. 1.0, 1.2, 1.5)
                                d.UserData.Add("version", words[1]);
                                break;
                        }
                    }
                    while (!sr.EndOfStream);

                    //functions.Add(f);

                    List<CodeMemberMethod> wrappers;
                    SpecTranslator.TranslateDelegate(d, out wrappers);
                    delegates.Add(d);
                    functions.AddRange(wrappers.ToArray());
                }
            }
            while (!sr.EndOfStream);
        }

        #endregion

        #region public static List<Constant> ReadConstantSpecs(string file)
        public static void ReadConstantSpecs(string file, out List<CodeMemberField> constants)
        {
            constants = new List<CodeMemberField>();

            StreamReader sr = OpenSpecFile(file);
            Console.WriteLine("Reading constant specs from file: {0}", file);

            do
            {
                string line = NextValidLine(sr);
                if (String.IsNullOrEmpty(line))
                    break;

                line = line.Replace('\t', ' ');

                string[] words = line.Split(SpecTranslator.Separators, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length == 0)
                    continue;

                CodeMemberField c = new CodeMemberField();
                c.Type = new CodeTypeReference("Int32");
                c.Attributes = MemberAttributes.Const | MemberAttributes.Public;

                if (line.Contains("="))
                {
                    uint number;
                    c.Name = "GL_" + words[0];
                    if (UInt32.TryParse(words[2].Replace("0x", String.Empty), System.Globalization.NumberStyles.AllowHexSpecifier, null, out number))
                        if (number > 0x7FFFFFFF)
                            words[2] = "unchecked((Int32)" + words[2] + ")";

                    c.InitExpression = new CodeFieldReferenceExpression(null, words[2]);
                }

                if (!String.IsNullOrEmpty(c.Name) && !constants.Contains(c))
                    constants.Add(c);
            }
            while (!sr.EndOfStream);
        }

        #endregion

        #region public static bool ListContainsConstant(List<CodeMemberField> constants, CodeMemberField c)
        public static bool ListContainsConstant(List<CodeMemberField> constants, CodeMemberField c)
        {
            foreach (CodeMemberField d in constants)
                if (d.Name == c.Name)
                    return true;
            return false;
        }
        #endregion

        #region public static Dictionary<string, CodeTypeReference> ReadTypeMap(string file)
        public static Dictionary<string, CodeTypeReference> ReadTypeMap(string file)
        {
            Dictionary<string, CodeTypeReference> map =
                new Dictionary<string, CodeTypeReference>();

            string path = Path.Combine(FilePath, file);
            StreamReader sr;

            try
            {
                sr = new StreamReader(path);
            }
            catch (Exception)
            {
                Console.WriteLine("Error opening typemap file: {0}", path);
                return null;
            }
            Console.WriteLine("Reading typemaps from file: {0}", file);

            do
            {
                string line = sr.ReadLine();

                if (String.IsNullOrEmpty(line) || line.StartsWith("#"))
                    continue;

                string[] words = line.Split(new char[] { ' ', ',', '*', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (words[0] == "void")
                {
                    // Special case for "void" -> ""
                    map.Add(words[0], new CodeTypeReference(String.Empty));
                }
                else if (words[0] == "VoidPointer")
                { // Special case for "VoidPointer" -> "GLvoid*"
                    map.Add(words[0], new CodeTypeReference("System.Object"));
                }
                else if (words[0] == "CharPointer" || words[0] == "charPointerARB")
                {
                    map.Add(words[0], new CodeTypeReference("System.String"));
                }
                else if (words[0].Contains("Pointer"))
	            {
                    map.Add(words[0], new CodeTypeReference(words[1], 1));
	            }
                else
                {
                    map.Add(words[0], new CodeTypeReference(words[1]));
                }
            }
            while (!sr.EndOfStream);

            return map;
        }
        #endregion
    }
}
