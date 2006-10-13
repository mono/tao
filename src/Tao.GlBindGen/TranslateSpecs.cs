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
using System.Collections;

namespace Tao.GlBindGen
{
    #region WrapperTypes enum

    public enum WrapperTypes
    {
        None,
        Bool,
        VoidArray,
        Array,
        UncheckedParameter,
        ReturnsString,
        ReturnsVoidPointer,
    }

    #endregion

    static class Translation
    {
        public static char[] Separators = { ' ', '\n', ',', '(', ')', ';', '#' };

        #region Dictionaries

        static Dictionary<string, string> parameter_names = new Dictionary<string, string>();

        #region GL types dictionary

        private static Dictionary<string, string> _gl_types;

        public static Dictionary<string, string> GLTypes
        {
            get { return Translation._gl_types; }
            set { Translation._gl_types = value; }
        }

        #endregion

        #region CS types dictionary

        private static Dictionary<string, string> _cs_types;

        public static Dictionary<string, string> CSTypes
        {
            get { return Translation._cs_types; }
            set { Translation._cs_types = value; }
        }

        #endregion

        #region GLX types dictionary

        private static Dictionary<string, string> _glx_types;

        public static Dictionary<string, string> GLXTypes
        {
            get { return _glx_types; }
            set { _glx_types = value; }
        }

        #endregion

        #region WGL types dictionary

        private static Dictionary<string, string> _wgl_types;

        public static Dictionary<string, string> WGLTypes
        {
            get { return _wgl_types; }
            set { _wgl_types = value; }
        }

        #endregion

        #endregion

        #region Constructor

        static Translation()
        {
            // Names
            parameter_names.Add("base", "@base");
            parameter_names.Add("object", "@object");
            parameter_names.Add("string", "@string");
            parameter_names.Add("ref", "reference");
            parameter_names.Add("params", "parameters");
            parameter_names.Add("in", "@in");
            parameter_names.Add("class", "@class");
        }

        #endregion

        #region Translate constants

        public static List<Constant> TranslateConstants(List<Constant> constants)
        {
            uint value;

            foreach (Constant c in constants)
            {
                c.Name = "GL_" + c.Name;
                if (!Char.IsDigit(c.Value[0]) && !c.Value.StartsWith("GL_"))
                    c.Value = "GL_" + c.Value;

                if (UInt32.TryParse(c.Value.Replace("0x", String.Empty), System.Globalization.NumberStyles.AllowHexSpecifier, null, out value))
                    if (value > 0x7FFFFFFF)
                        c.Value = "unchecked((int)" + c.Value + ")";
            }
            return constants;
        }

        #endregion

        #region Translate functions

        public static void TranslateFunctions(List<Function> functions, out List<Function> wrappers)
        {
            foreach (Function f in functions)
            {
                TranslateReturnValue(f);
                TranslateParameters(f);

                if (f.NeedsWrapper)
                    f.Name = f.Name + "_";

                f.Name = "gl" + f.Name;
            }

            wrappers = GenerateWrappers(functions);
        }

        #region Translate return value

        private static void TranslateReturnValue(Function f)
        {
            string s;

            if (f.ReturnValue == "void")
                return;

            if (GLTypes.TryGetValue(f.ReturnValue, out s))
                f.ReturnValue = s;

            if (f.ReturnValue == "void[]")
            {
                f.NeedsWrapper = true;
                f.WrapperType = WrapperTypes.ReturnsVoidPointer;
                f.ReturnValue = "IntPtr";
            }

            if (f.ReturnValue == "GLstring")
            {
                f.NeedsWrapper = true;
                f.WrapperType = WrapperTypes.ReturnsString;
                f.ReturnValue = "IntPtr";
            }
        }

        #endregion

        #region Translate parameters

        private static void TranslateParameters(Function f)
        {
            string s;

            foreach (Parameter p in f.Parameters)   // Translate each parameter of the function, and check for needed wrappers.
            {
                #region Translate parameter name

                if (parameter_names.TryGetValue(p.Name, out s))
                    p.Name = s;

                #endregion

                #region Translate parameter type

                //if (p.Type.Contains("bool"))
                //{
                //    p.Type = "[MarshalAs(UnmanagedType.Bool)] ";
                //}
                
                if (GLTypes.TryGetValue(p.Type, out s))
                    p.Type = s;

                #endregion

                #region Check for needed wrappers
                    
                if (p.Type.Contains("ushort") && f.Name.Contains("LineStipple"))    // glLineStipple needs wrapper to allow for unchecked mask values.
                {
                    p.NeedsWrapper = true;
                    p.WrapperType = WrapperTypes.UncheckedParameter;
                    p.Unchecked = true;
                }
                else if (p.Array && p.Type.Contains("string"))  // string parameters do not need special wrappers.
                {
                    p.NeedsWrapper = false;
                    p.WrapperType = WrapperTypes.None;
                }
                else if (p.Array && p.Type.Contains("char"))    // GLchar[] parameters should become (in) string or (out) StringBuilder
                {
                    if (p.Flow == Parameter.FlowDirection.Out)
                        p.Type = "StringBuilder";
                    else
                        p.Type = "string";
                    p.Array = false;
                }
                else if (p.Array)                               // All other array parameters need wrappers (around IntPtr).
                {
                    p.NeedsWrapper = true;

                    if (p.Type.Contains("void"))
                        p.WrapperType = WrapperTypes.VoidArray;
                    else
                        p.WrapperType = WrapperTypes.Array;

                    p.Type = "IntPtr";
                    p.Array = false;    // We do not want an array of IntPtrs (IntPtr[]) - it is the IntPtr that points to the array.
                    p.Flow = Parameter.FlowDirection.Undefined; // The same wrapper works for either in or out parameters.
                }

                if (p.NeedsWrapper)     // If there is at least 1 parameter that needs wrappers, mark the funcction for wrapping.
                {
                    f.NeedsWrapper = true;
                    f.WrapperType = p.WrapperType;
                }

                #endregion
            }
        }

        #endregion

        #region Generate wrappers

        private static List<Function> GenerateWrappers(List<Function> functions)
        {
            List<Function> wrappers = new List<Function>();
            Function w;

            foreach (Function f in functions)
            {
                if (f.NeedsWrapper)
                {
                    if (f.WrapperType == WrapperTypes.UncheckedParameter)
                    {
                        w = new Function(f);
                        w.Name = w.Name.TrimEnd('_');

                        // Search and replace ushort parameters with ints.
                        Predicate<Parameter> is_ushort_parameter = new Predicate<Parameter>(delegate(Parameter p) { return p.Type == "GLushort"; });
                        Parameter oldp = w.Parameters.Find(is_ushort_parameter);
                        Parameter newp = new Parameter(oldp);
                        newp.Type = "GLint";
                        w.Parameters = w.Parameters.ReplaceAll(oldp, newp);

                        // Call the low-level function wrapping (all parameters marked with Unchecked will automatically
                        // be decorated with the unchecked keyword).
                        w.Body.Add((f.ReturnValue.Contains("void") ? "" : "return ") + f.CallString() + ";");

                        // Add the wrapper.
                        wrappers.Add(w);

                        continue;
                    }

                    if (f.WrapperType == WrapperTypes.ReturnsString)
                    {
                        w = new Function(f);
                        w.Name = w.Name.TrimEnd('_');

                        // Replace the IntPtr return value with string.
                        w.ReturnValue = "string";

                        // Wrap the call to the low-level function (marshal the IntPtr to string).
                        w.Body.Add("return Marshal.PtrToStringAnsi(" + f.CallString() + ");");

                        // Add the wrapper.
                        wrappers.Add(w);

                        continue;
                    }

                    if (f.WrapperType == WrapperTypes.Bool)
                    {
                        w = new Function(f);
                        w.Name.TrimEnd('_');



                        // Search and replace bool parameters with ints.
                        Predicate<Parameter> is_ushort_parameter = new Predicate<Parameter>(delegate(Parameter p) { return p.Type == "GLushort"; });
                        Parameter oldp = w.Parameters.Find(is_ushort_parameter);
                        Parameter newp = new Parameter(oldp);
                        newp.Type = "GLint";
                        w.Parameters = w.Parameters.ReplaceAll(oldp, newp);
                    }

                    WrapPointers(f, wrappers);
                    count = 0;
                }
            }

            return wrappers;
        }

        #region Wrap pointers

        // This function needs some heavy refactoring.
        // What it does is this: it adds to the wrapper list all possible wrapper permutations
        // for functions that have more than one IntPtr parameter. Example:
        // "void f_(IntPtr p, IntPtr q)" where p and q are pointers to void arrays needs the following wrappers:
        // "void f(IntPtr p, IntPtr q)"
        // "void f(IntPtr p, object q)"
        // "void f(object p, IntPtr q)"
        // "void f(object p, object q)"
        static int count = 0;
        private static void WrapPointers(Function f, List<Function> wrappers)
        {
            if (count == 0)
            {
                wrappers.Add(IntPtrToIntPtr(f));
            }

            if (count >= 0 && count < f.Parameters.Count)
            {
                if (f.Parameters[count].NeedsWrapper)
                {
                    ++count;
                    WrapPointers(f, wrappers);
                    --count;

                    Function w = IntPtrToObject(f, count);
                    wrappers.Add(w);

                    ++count;
                    WrapPointers(w, wrappers);
                    --count;

                    if (f.Parameters[count].WrapperType == WrapperTypes.Array)
                    {
                        w = IntPtrToArray(f, count);
                        wrappers.Add(w);

                        ++count;
                        WrapPointers(w, wrappers);
                        --count;
                    }
                }
                else
                {
                    ++count;
                    WrapPointers(f, wrappers);
                    --count;
                }
            }
        }

        #endregion

        #region IntPtr to IntPtr wrapper

        private static Function IntPtrToIntPtr(Function f)
        {
            Function w = new Function(f);
            w.Name = w.Name.TrimEnd('_');

            w.Body.Add((f.ReturnValue.Contains("void") ? "" : "return ") + f.CallString() + ";");
            return w;
        }

        #endregion

        #region IntPtr to object wrapper

        private static Function IntPtrToObject(Function f, int index)
        {
            Function w = new Function(f);
            w.Name = w.Name.TrimEnd('_');

            Parameter newp = new Parameter(f.Parameters[index]);
            newp.Type = "object";
            if (newp.Flow == Parameter.FlowDirection.Out)
                newp.Flow = Parameter.FlowDirection.Undefined;
            w.Parameters = w.Parameters.Replace(f.Parameters[index], newp);

            // In the function body we should pin all objects in memory before calling the
            // low-level function.
            w.Body = GenerateBodyForPins(w);

            return w;
        }

        #endregion

        #region IntPtr to typed array wrapper

        // IntPtr -> GL[...] wrapper.
        private static Function IntPtrToArray(Function f, int index)
        {
            Function w = new Function(f);
            w.Name = w.Name.TrimEnd('_');

            // Search and replace IntPtr parameters with the know parameter types:
            Parameter newp = new Parameter(f.Parameters[index]);
            newp.Type = f.Parameters[index].PreviousType;
            newp.Array = true;
            w.Parameters = w.Parameters.Replace(f.Parameters[index], newp);

            // In the function body we should pin all objects in memory before calling the
            // low-level function.
            w.Body = GenerateBodyForPins(w);

            return w;
        }

        #endregion

        #region Wrapper body for function that need pinning

        private static FunctionBody GenerateBodyForPins(Function w)
        {

            FunctionBody body = new FunctionBody();

            int i = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            foreach (Parameter p in w.Parameters)
            {
                if (p.Type == "object" || p.Array && !p.Type.Contains("string")) // we should allow the default marshalling behavior for strings.
                {
                    body.Add("GCHandle h" + i + " = GCHandle.Alloc(" + p.Name + ", GCHandleType.Pinned);");
                    sb.Append("h" + i + ".AddrOfPinnedObject()" + ", ");
                    i++;
                }
                else
                {
                    sb.Append(p.Name + ", ");
                }
            }
            sb.Replace(", ", ")", sb.Length - 2, 2);

            body.Add("try");
            body.Add("{");
            body.Add(
                "    " +
                (w.ReturnValue.Contains("void") ? "" : "return ") +
                w.Name + "_" +
                sb.ToString() +
                ";");
            body.Add("}");
            body.Add("finally");
            body.Add("{");
            while (i > 0)
            {
                body.Add("    h" + --i + ".Free();");
            }
            body.Add("}");

            return body;
        }

        #endregion

        #endregion

        #endregion
    }
}
