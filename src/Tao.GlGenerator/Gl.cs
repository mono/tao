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
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace Tao.GlGenerator
{
    public static class Gl
    {
        public class FunctionStruct
        {
            public string line;
            public string fname;
            public string[] fargs;
            public Dictionary<string, Dictionary<string, string>> fargtypes = new Dictionary<string, Dictionary<string, string>>();
            public string rettype;
            public string category;
            public string version;
            public int extension = 0;
            StreamReader streamReader;

            public FunctionStruct(StreamReader streamReader, string line)
            {
                this.line = line;
                this.streamReader = streamReader;
            }
        }
        static List<string> core_gl = new List<string>();


        internal static string FilePath
        {
            get
            {
                string filePath = Path.Combine("..", "..");
                string fileDirectory = "Data";
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

        internal static void WriteUsing(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("using System;");
            streamWriter.WriteLine("using System.Security;");
            streamWriter.WriteLine("using System.Runtime.InteropServices;");
            streamWriter.WriteLine();
        }

        internal static void WriteNamespace(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("namespace Tao.OpenGl");
        }

        internal static void WriteClassDefinition(StreamWriter streamWriter, bool isInstance)
        {
            streamWriter.WriteLine("\t#region Class Documentation");
            streamWriter.WriteLine("\t/// <summary>");
            streamWriter.WriteLine("\t/// ");
            streamWriter.WriteLine("\t/// </summary>");
            streamWriter.WriteLine("\t#endregion Class Documentation");
            if (isInstance)
            {
                streamWriter.WriteLine("\tpublic sealed class ContextGl");
            }
            else
            {
                streamWriter.WriteLine("\tpublic static class Gl");
            }
        }

        internal static void WritePrivateConstants(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("\t\t#region Private Constants");
            streamWriter.WriteLine("\t\t#region string GL_NATIVE_LIBRARY");
            streamWriter.WriteLine("\t\t/// <summary>");
            streamWriter.WriteLine("\t\t/// Specifies OpenGl's native library archive.");
            streamWriter.WriteLine("\t\t/// </summary>");
            streamWriter.WriteLine("\t\t/// <remarks>");
            streamWriter.WriteLine("\t\t/// Specifies opengl32.dll everywhere; will be mapped via .config for mono.");
            streamWriter.WriteLine("\t\t/// </remarks>");
            streamWriter.WriteLine("\t\tprivate const string GL_NATIVE_LIBRARY = \"opengl32.dll\";");
            streamWriter.WriteLine("\t\t#endregion string GL_NATIVE_LIBRARY");
            streamWriter.WriteLine();
            streamWriter.WriteLine("\t\t#region CallingConvention CALLING_CONVENTION");
            streamWriter.WriteLine("\t\t/// <summary>");
            streamWriter.WriteLine("\t\t/// Specifies the calling convention.");
            streamWriter.WriteLine("\t\t/// </summary>");
            streamWriter.WriteLine("\t\t/// <remarks>");
            streamWriter.WriteLine("\t\t/// Specifies <see cref=\"CallingConvention.Cdecl\" /> ");
            streamWriter.WriteLine("\t\t/// for Windows and Linux.");
            streamWriter.WriteLine("\t\t/// </remarks>");
            streamWriter.WriteLine("\t\tprivate const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;");
            streamWriter.WriteLine("\t\t#endregion CallingConvention CALLING_CONVENTION");
            streamWriter.WriteLine("\t\t#endregion Private Constants");
            streamWriter.WriteLine();
        }

        static string fileNameStatic = "Gl.cs";
        internal static string FileNameStatic
        {
            get
            {
                return fileNameStatic;
            }
        }
        static string fileNameInstance = "ContextGl.cs";
        internal static string FileNameInstance
        {
            get
            {
                return fileNameInstance;
            }
        }

        internal static void WriteClass(StreamWriter streamWriter, bool isInstance)
        {
            WritePrivateConstants(streamWriter);
            if (!isInstance)
            {
                streamWriter.WriteLine("\t\t#region Public Constants");
                WriteEnum(streamWriter);
                streamWriter.WriteLine("\t\t#endregion Public Constants");
            }
            streamWriter.WriteLine();

            streamWriter.WriteLine("\t\t#region Public Methods");
            WriteFunctions(streamWriter, isInstance);
            streamWriter.WriteLine("\t\t#endregion Public Methods");
        }

        static void GenerateXmlSpec()
        {
            ReadGlSpec();
            core_gl.Clear();
            core_gl.Add("1_1");
            core_gl.Add("display-list");
            core_gl.Add("drawing");
            core_gl.Add("drawing-control");
            core_gl.Add("feedback");
            core_gl.Add("framebuf");
            core_gl.Add("misc");
            core_gl.Add("modeling");
            core_gl.Add("pixel-op");
            core_gl.Add("pixel-rw");
            core_gl.Add("state-req");
            core_gl.Add("xform");

            StreamWriter streamWriter = new StreamWriter(Path.Combine(FilePath, "gl.xml"));
            streamWriter.WriteLine("<?xml version=\"1.0\"?>");
            streamWriter.WriteLine("<glspec>");
            foreach (string k in core_gl)
            {
                PrintCore(streamWriter, k, glHash);
            }
            foreach (string category in core_gl)
            {
                glHash.Remove(category);
            }


            foreach (string k in glHash.Keys)
            {
                PrintExtension(streamWriter, k, glHash);
            }
            streamWriter.WriteLine("</glspec>");
            streamWriter.Close();
        }

        static void ReadGlSpec()
        {
            StreamReader streamReader = new StreamReader(Path.Combine(FilePath, "gl.spec"));
            CreateGlHash(streamReader);
        }

        static Dictionary<string, Dictionary<string, FunctionStruct>> glHash = new Dictionary<string, Dictionary<string, FunctionStruct>>();
        static Dictionary<string, string> categories = new Dictionary<string, string>();
        static void CreateGlHash(StreamReader streamReader)
        {
            //Regex regex = new Regex("([^ ]+) ([^ ]+)");
            string specFileLine;
            //string[] line;
            while ((specFileLine = streamReader.ReadLine()) != null)
            {
                if (specFileLine.StartsWith("#") || specFileLine.StartsWith("passthru") || !specFileLine.Contains("("))
                {
                    continue;
                }
                FunctionStruct func = ParseSpecFileLine(streamReader, specFileLine);

                if (!(func.category == null))
                {
                    if (glHash.ContainsKey(func.category))
                    {
                        glHash[func.category][func.fname] = func;
                    }
                    else
                    {
                        glHash[func.category] = new Dictionary<string, FunctionStruct>();
                        glHash[func.category][func.fname] = func;
                    }
                }


            }
        }

        private static FunctionStruct ParseSpecFileLine(StreamReader streamReader, string specFileLine)
        {
            string[] line;
            Regex regex = new Regex(" +");
            FunctionStruct func = new FunctionStruct(streamReader, specFileLine);
            StringBuilder fargstr = new StringBuilder(specFileLine.Substring(specFileLine.IndexOf('(') + 1, specFileLine.IndexOf(')') - specFileLine.IndexOf('(') - 1));
            if (fargstr.Equals("") || fargstr == null)
            {
                func.fargs = null;
            }
            else
            {
                func.fargs = fargstr.Replace(" ", "").ToString().Split(',');
            }
            func.fname = specFileLine.Substring(0, specFileLine.IndexOf('('));
            while ((specFileLine = streamReader.ReadLine()) != "" && specFileLine != null)
            {
                line = regex.Split(specFileLine.Trim().Replace('\t', ' '));
                if (line[0] == "return")
                {
                    func.rettype = line[1].Trim();
                }
                else if (line[0] == "category")
                {
                    func.category = line[1].Trim();
                }
                else if (line[0] == "version")
                {
                    func.version = line[1].Trim();
                }
                else if (line[0] == "extension")
                {
                    func.extension = 1;
                }
                else if (line[0] == "param")
                {
                    string pname = line[1].Trim();
                    if (func.fargtypes.ContainsKey(pname))
                    {
                    }
                    else
                    {
                        func.fargtypes[pname] = new Dictionary<string, string>();
                    }
                    func.fargtypes[pname]["type"] = line[2].Trim();
                    func.fargtypes[pname]["inout"] = line[3].Trim();
                    func.fargtypes[pname]["valtype"] = line[4].Trim();
                    if (func.fargtypes[pname]["valtype"] == "array")
                    {
                        func.fargtypes[pname]["arraysize"] = line[5].Substring(1, line[5].Length - 1).Trim();
                    }
                }

            }
            return func;
        }

        static void PrintCore(StreamWriter streamWriter, string coreKey, Dictionary<string, Dictionary<string, FunctionStruct>> coreData)
        {
            streamWriter.WriteLine("\t<coreset category=\"{0}\">", coreKey);
            
            foreach (string fname in coreData[coreKey].Keys)
            {
                PrintFunction(streamWriter, coreData[coreKey][fname]);
            }
            streamWriter.WriteLine("\t</coreset>");
        }

        static void PrintExtension(StreamWriter streamWriter, string extKey, Dictionary<string, Dictionary<string, FunctionStruct>> extData)
        {
            streamWriter.WriteLine("\t<extset extension=\"{0}\">", extKey);
            
            foreach (string fname in extData[extKey].Keys)
            {
                PrintFunction(streamWriter, extData[extKey][fname]);
            }
            streamWriter.WriteLine("\t</extset>");
        }

        static void PrintFunction(StreamWriter streamWriter, FunctionStruct function)
        {
            streamWriter.WriteLine("\t\t<function name=\"{0}\" rettype=\"{1}\">", function.fname, function.rettype);
            if (function.fargs != null)
            {


                if (function.fargs.Length == 0 || function.fargs[0] == "")
                {
                    //pass   
                }
                else
                {
                    foreach (string arg in function.fargs)
                    {

                        Dictionary<string, string> arginfo = function.fargtypes[arg];
                        streamWriter.WriteLine("\t\t\t<param name=\"{0}\" valtype=\"{1}\" type=\"{2}\" inout=\"{3}\" />", arg, arginfo["valtype"], arginfo["type"], arginfo["inout"]);
                        //function.fargtypes[arg]["valtype"], function.fargtypes[arg]["type"], function.fargtypes[arg]["inout"]);
                    }
                }
            }
            streamWriter.WriteLine("\t\t</function>");

        }

        static void WriteEnum(StreamWriter streamWriter)
        {
            StreamReader streamReader = new StreamReader(Path.Combine(FilePath, "enum.spec"));
            Hashtable enumHash = new Hashtable();
            CreateHash(streamReader, enumHash);
            streamReader = new StreamReader(Path.Combine(FilePath, "enumext.spec"));
            CreateHash(streamReader, enumHash);
            foreach (string s in enumHash.Keys)
            {
                streamWriter.WriteLine("\t\t#region GL_" + s);
                streamWriter.WriteLine("\t\t/// <summary>");
                streamWriter.WriteLine("\t\t/// ");
                streamWriter.WriteLine("\t\t/// </summary>");
                if ((string)enumHash[s] == "0x80000000" || (string)enumHash[s] == "0xFFFFFFFF")
                {
                    streamWriter.WriteLine("\t\tpublic const int {0} = unchecked((int) {1});", "GL_" + s, enumHash[s]);
                }
                else
                {
                    streamWriter.WriteLine("\t\tpublic const int {0} = {1};", "GL_" + s, enumHash[s]);
                }
                streamWriter.WriteLine("\t\t#endregion GL_" + s);
                streamWriter.WriteLine();
            }
        }

        private static void CreateHash(StreamReader streamReader, Hashtable enumHash)
        {
            Regex regex = new Regex("([^ ]+) ([^ ]+)");
            string specFileLine;
            string[] line;
            while ((specFileLine = streamReader.ReadLine()) != null)
            {
                if (specFileLine.StartsWith("#") || !specFileLine.StartsWith("\t"))
                {
                    continue;
                }
                line = regex.Split(specFileLine.Trim().Replace('\t', ' '));
                if (line.Length >= 3 && line[0] != " " && line[1] == "=")
                {
                    if (!enumHash.Contains(line[0].Trim()))
                    {
                        if (line[2].Length >= 3 && line[2].Substring(0, 3) == "GL_")
                        {
                            enumHash.Add(line[0].Trim(), line[2]);
                        }
                        else
                        {
                            enumHash.Add(line[0].Trim(), "0x" + line[2].Substring(line[2].Length >= 3 ? 2 : line[2].Length - 1).PadLeft(8, '0'));
                        }
                    }
                }
            }
        }

        static void WriteFunctions(StreamWriter streamWriter, bool doInstance)
        {
            Driver.doInstance = doInstance;
            Driver.TypeMap = new GlTypeMap(Path.Combine(FilePath, "typemap.xml"));
            if (!doInstance)
            {
                GenerateXmlSpec();
            }
            Driver.Doc = new XmlDocument();
            Driver.Doc.Load(Path.Combine(FilePath, "gl.xml"));

            //Driver.Output = new StreamWriter("Gl-funcs.cs");
            Driver.Output = streamWriter;

            Driver.paramCountHash = new Hashtable();

            XmlNode glspec = Driver.Doc.GetElementsByTagName("glspec")[0];
            foreach (XmlNode setnode in glspec.ChildNodes)
            {
                if (setnode.NodeType != XmlNodeType.Element)
                {
                    continue;
                }

                if (setnode.Name == "coreset")
                {
                    Driver.HandleSet(setnode, setnode.Attributes["category"].Value, true);
                }
                else if (setnode.Name == "extset")
                {
                    Driver.HandleSet(setnode, setnode.Attributes["extension"].Value, false);
                }
            }

            ArrayList ar = new ArrayList();
            // the hash is name->num params, we need to find the max
            foreach (string fname in Driver.paramCountHash.Keys)
            {
                int nparams = (int)Driver.paramCountHash[fname];
                if (nparams > 20)
                {
                    ar.Add(new FuncParamStruct(fname, nparams));
                }
            }

            ar.Sort(new FuncParamStructComparer());
            //for (int i = 0; i < 20; i++)
            //{
            //    Console.WriteLine("{0}: {1}", ((FuncParamStruct)ar[i]).fname, ((FuncParamStruct)ar[i]).nparams);
            //}
        }

        public class GlParam
        {
            public string name;
            public string valtype;
            public string gltype;
            public string inout;

            public ArrayList nativetypes;
            public ArrayList nonclstypes;
        }

        public class GlTypeMap
        {
            Hashtable typeHash;

            internal class GlTypeMapEntry
            {
                public GlTypeMapEntry()
                {
                    if_return = 0;
                    if_out = 0;
                    if_array = 0;
                    is_generic = 0;
                    as_array = 0;
                }

                public int Rank
                {
                    get
                    {
                        int r = 0;
                        if (if_out != 0) r++;
                        if (if_array != 0) r++;

                        return r;
                    }
                }

                public string type;
                public string nonclstype;
                public int if_return;
                public int if_out;
                public int if_array;
                public int is_generic;
                public int as_array;
            }

            public GlTypeMap(string file)
            {
                typeHash = new Hashtable();
                LoadFrom(file);
            }

            internal class GlTypeMapEntryComparer : IComparer
            {
                public int Compare(object a, object b)
                {
                    GlTypeMapEntry tmea = a as GlTypeMapEntry;
                    GlTypeMapEntry tmeb = b as GlTypeMapEntry;

                    return tmeb.Rank - tmea.Rank;
                }
            }

            public void LoadFrom(string file)
            {
                XmlDocument tdoc = new XmlDocument();
                tdoc.Load(file);

                XmlNodeList nl = tdoc.GetElementsByTagName("typemap");
                XmlNode typemap = nl[0];


                foreach (XmlNode typenode in typemap.ChildNodes)
                {
                    if (typenode.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }

                    if (typenode.Name == "type")
                    {

                        XmlAttribute nameattr = typenode.Attributes["name"];
                        if (nameattr == null)
                        {
                            Console.WriteLine("Warning: <type> in typemap with no name attribute");
                            {
                                continue;
                            }
                        }

                        string typename = nameattr.Value;

                        if (typeHash[typename] != null)
                        {
                            Console.WriteLine("Warning: type '{0}' mapped multiple times", typename);
                            {
                                continue;
                            }
                        }

                        foreach (XmlNode mapnode in typenode.ChildNodes)
                        {
                            if (mapnode.NodeType != XmlNodeType.Element)
                            {
                                continue;
                            }

                            if (mapnode.Name == "mapto")
                            {
                                // skip non-c# mappings
                                if (mapnode.Attributes["language"].Value != "c#")
                                {
                                    continue;
                                }

                                GlTypeMapEntry tme = new GlTypeMapEntry();
                                if (mapnode.Attributes["type"] != null)
                                {
                                    tme.type = mapnode.Attributes["type"].Value;
                                }
                                if (mapnode.Attributes["if_return"] != null)
                                {
                                    tme.if_return = Convert.ToInt32(mapnode.Attributes["if_return"].Value);
                                }
                                if (mapnode.Attributes["if_out"] != null)
                                {
                                    tme.if_out = Convert.ToInt32(mapnode.Attributes["if_out"].Value);
                                }
                                if (mapnode.Attributes["if_array"] != null)
                                {
                                    tme.if_array = Convert.ToInt32(mapnode.Attributes["if_array"].Value);
                                }
                                if (mapnode.Attributes["as_array"] != null)
                                {
                                    tme.as_array = Convert.ToInt32(mapnode.Attributes["as_array"].Value);
                                }
                                if (mapnode.Attributes["is_generic"] != null)
                                {
                                    tme.is_generic = Convert.ToInt32(mapnode.Attributes["is_generic"].Value);
                                }
                                if (mapnode.Attributes["nonclstype"] != null)
                                {
                                    tme.nonclstype = mapnode.Attributes["nonclstype"].Value;
                                }

                                ArrayList entries = typeHash[typename] as ArrayList;
                                if (entries == null)
                                {
                                    entries = new ArrayList();
                                    typeHash[typename] = entries;
                                }

                                entries.Add(tme);
                            }
                        }
                    }
                    else if (typenode.Name == "typealias")
                    {
                        string name = typenode.Attributes["name"].Value;
                        string mapto = typenode.Attributes["mapto"].Value;

                        ArrayList entries = typeHash[mapto] as ArrayList;
                        if (entries == null)
                        {
                            Console.WriteLine("Warning: typealias entry for '{0}' seen before mapto type '{1}'!", name, mapto);
                            continue;
                        }

                        if (typeHash[name] != null)
                        {
                            Console.WriteLine("Warning: type '{0}' mapped multiple times", name);
                            continue;
                        }

                        typeHash[name] = typeHash[mapto];
                    }
                }
            }

            // this type matching code is pretty fragile; it just does the basics
            // to get the correct output for the (known) input. you break it,
            // you get to keep both pieces.

            static string[] inArrayExpansions = new string[] {
"bool []",
"byte []",
"short []",
"int []",
"float []",
"double []",
"string",
"IntPtr"
};
            static string[] inArrayNonCLSExpansions = new string[] {
/* Things that are unsafe based on type */
"ref sbyte", "sbyte []", "sbyte [,]", "sbyte [,,]",
"ref ushort", "ushort []", "ushort [,]", "ushort [,,]",
"ref uint", "uint []", "uint [,]", "uint [,,]",

/* Things that are unsafe due to being overloads */
"ref bool", "bool [,]", "bool [,,]",
"ref byte", "byte [,]", "byte [,,]",
"ref short", "short [,]", "short [,,]",
"ref int", "int [,]", "int [,,]",
"ref float", "float [,]", "float [,,]",
"ref double", "double [,]", "double [,,]",
};

            static string[] outArrayExpansions = new string[] {
"[Out] bool []",
"[Out] byte []",
"[Out] short []",
"[Out] int []",
"[Out] float []",
"[Out] double []",
"IntPtr"
};

            static string[] outArrayNonCLSExpansions = new string[] {
"out bool",
"out byte",
"out short",
"out int",
"out float",
"out double",
"out sbyte", "[Out] sbyte []",
"out ushort", "[Out] ushort []",
"out uint", "[Out] uint []",
};

            public void ExpandParam(GlParam param)
            {
                ArrayList entries = typeHash[param.gltype] as ArrayList;
                if (entries == null)
                {
                    Console.WriteLine("ExpandParam: type '{0}' not found in map!", param.gltype);
                    throw new Exception();
                }

                int want_array, want_out;

                if (param.valtype == "array")
                {
                    want_array = 1;
                }
                else
                {
                    want_array = -1;
                }

                if (param.inout == "out")
                {
                    want_out = 1;
                }
                else
                {
                    want_out = -1;
                }

                // find the first one that matches
                foreach (GlTypeMapEntry tme in entries)
                {
                    if (tme.if_return == 0 &&
                    (tme.if_out == 0 || tme.if_out == want_out) &&
                    (tme.if_array == 0 || tme.if_array == want_array))
                    {
                        // found one
                        if (tme.is_generic == 1)
                        {
                            if (want_out == 1)
                            {
                                param.nativetypes = new ArrayList(outArrayExpansions);
                                param.nonclstypes = new ArrayList(outArrayNonCLSExpansions);
                            }
                            else
                            {
                                param.nativetypes = new ArrayList(inArrayExpansions);
                                param.nonclstypes = new ArrayList(inArrayNonCLSExpansions);
                            }
                        }
                        else
                        {
                            string target = tme.type;
                            string nonclstarget = tme.nonclstype;
                            param.nativetypes = new ArrayList();
                            param.nonclstypes = new ArrayList();

                            if (want_array == 1)
                            {
                                if (want_out == 1)
                                {
                                    if (tme.if_out == 1)
                                    {
                                        // let the param handle whether it wants "out" or not
                                        if (target != null)
                                        {
                                            param.nativetypes.Add(target);
                                        }
                                        if (nonclstarget != null)
                                        {
                                            param.nonclstypes.Add(nonclstarget);
                                        }
                                    }
                                    else
                                    {
                                        // an out array
                                        if (target != null)
                                        {
                                            param.nativetypes.Add("out " + target);
                                            param.nativetypes.Add("[Out] " + target + " []");
                                        }
                                        if (nonclstarget != null)
                                        {
                                            param.nonclstypes.Add("out " + nonclstarget);
                                            param.nonclstypes.Add("[Out] " + nonclstarget + " []");
                                        }
                                    }
                                }
                                else
                                {
                                    // an in array
                                    if (target != null)
                                    {
                                        param.nativetypes.Add("ref " + target);
                                        param.nativetypes.Add(target + " []");
                                    }
                                    if (nonclstarget != null)
                                    {
                                        param.nonclstypes.Add("ref " + nonclstarget);
                                        param.nonclstypes.Add(nonclstarget + " []");
                                    }
                                }
                            }
                            else
                            {
                                if (want_out == 1)
                                {
                                    if (tme.if_out == 1)
                                    {
                                        // let the param handle whether it wants "out" or not
                                        if (target != null)
                                        {
                                            param.nativetypes.Add(target);
                                        }
                                        if (nonclstarget != null)
                                        {
                                            param.nonclstypes.Add(nonclstarget);
                                        }
                                    }
                                    else
                                    {
                                        // an out value
                                        if (target != null)
                                        {
                                            param.nativetypes.Add("out " + target);
                                        }
                                        if (nonclstarget != null)
                                        {
                                            param.nonclstypes.Add("out " + nonclstarget);
                                        }
                                    }
                                }
                                else
                                {
                                    // an in value
                                    if (target != null)
                                    {
                                        param.nativetypes.Add(target);
                                    }
                                    if (nonclstarget != null)
                                    {
                                        param.nonclstypes.Add(nonclstarget);
                                    }
                                }
                            }
                        }

                        return;
                    }
                }

                Console.WriteLine("ExpandParam: No match found for '{0}'", param.gltype);
                throw new Exception();
            }

            // note: this always uses the CLS type
            public string TypeForRetVal(string intype)
            {
                ArrayList entries = typeHash[intype] as ArrayList;
                if (entries == null)
                {
                    Console.WriteLine("TypeForRetVal: type '{0}' not found in map!", intype);
                    throw new Exception();
                }

                // simple mapping?
                if (entries.Count == 1)
                {
                    GlTypeMapEntry tme = entries[0] as GlTypeMapEntry;
                    if (tme.Rank == 0)
                    {
                        return tme.type;
                    }
                }

                // or not.
                foreach (GlTypeMapEntry tme in entries)
                {
                    if (tme.if_return == 1)
                    {
                        return tme.type;
                    }

                    if ((tme.if_out == 0 || tme.if_out == -1) &&
                    (tme.if_array == 0 || tme.if_array == -1))
                    {
                        return tme.type;
                    }
                }

                Console.WriteLine("TypeForRetVal: No match found for '{0}'", intype);
                throw new Exception();
            }
        }
        public class FuncParamStruct
        {
            public string fname;
            public int nparams;
            public FuncParamStruct(string f, int n)
            {
                fname = f; nparams = n;
            }
        }
        internal class FuncParamStructComparer : IComparer
        {
            public int Compare(object a, object b)
            {
                FuncParamStruct fpa = a as FuncParamStruct;
                FuncParamStruct fpb = b as FuncParamStruct;

                return fpb.nparams - fpa.nparams;
            }
        }

        public class Driver
        {

            // this uh might be broken if this becomes false.
            public const bool funcUseGlPrefix = true;
            // currently ignored (enums aren't generated here, see sharp-genenums.py)
            public const bool enumUseGlPrefix = true;

            public static GlTypeMap TypeMap;
            public static XmlDocument Doc;

            public static StreamWriter Output;

            public static bool doInstance = false;

            public static Hashtable paramCountHash;



            public static ArrayList ReadParams(XmlNode funcnode)
            {
                ArrayList fparams = new ArrayList();

                foreach (XmlNode paramnode in funcnode.ChildNodes)
                {
                    if (paramnode.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }

                    if (paramnode.Name != "param")
                    {
                        continue;
                    }

                    GlParam param = new GlParam();
                    param.name = paramnode.Attributes["name"].Value;
                    param.valtype = paramnode.Attributes["valtype"].Value;
                    param.gltype = paramnode.Attributes["type"].Value;
                    param.inout = paramnode.Attributes["inout"].Value;

                    // fix bad names
                    if (param.name == "params" ||
                    param.name == "base" ||
                    param.name == "string" ||
                    param.name == "ref" ||
                    param.name == "object" ||
                    param.name == "out" ||
                    param.name == "in")
                        param.name = "arg_" + param.name;

                    fparams.Add(param);
                }

                return fparams;
            }

            // fparams is an array of arrays.
            // start with i = 0;

            public class FuncParams
            {
                public string paramString;
                public bool isCLSCompliant;

                public FuncParams()
                {
                    paramString = "";
                    isCLSCompliant = true;
                }

                public FuncParams(string ptype, string name, bool compliant)
                {
                    paramString = ptype + " " + name;
                    isCLSCompliant = compliant;
                }

                // prepend [s,b] to the set of nextparams
                public FuncParams(string ptype, string name, bool compliant, FuncParams fp)
                {
                    paramString = ptype + " " + name + ", " + fp.paramString;
                    if (!compliant || !fp.isCLSCompliant)
                    {
                        isCLSCompliant = false;
                    }
                    else
                    {
                        isCLSCompliant = true;
                    }
                }
            }

            public static ArrayList GenParamList(ArrayList fparams, int i)
            {
                if (i >= fparams.Count)
                {
                    return null;
                }

                ArrayList results = new ArrayList();
                GlParam param = fparams[i] as GlParam;

                ArrayList nextparams = GenParamList(fparams, i + 1);

                if (nextparams == null)
                {
                    foreach (string nativetype in param.nativetypes)
                    {
                        results.Add(new FuncParams(nativetype, param.name, true));
                    }
                    foreach (string nonclstype in param.nonclstypes)
                    {
                        results.Add(new FuncParams(nonclstype, param.name, false));
                    }
                    return results;
                }

                foreach (FuncParams fp in nextparams)
                {
                    foreach (string nativetype in param.nativetypes)
                    {
                        results.Add(new FuncParams(nativetype, param.name, true, fp));
                    }
                    foreach (string nonclstype in param.nonclstypes)
                    {
                        results.Add(new FuncParams(nonclstype, param.name, false, fp));
                    }
                }

                return results;
            }

            public static void HandleSet(XmlNode parent, string name, bool iscore)
            {
                //Console.WriteLine ("Set: " + name);
                foreach (XmlNode funcnode in parent.ChildNodes)
                {
                    if (funcnode.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }

                    if (funcnode.Name != "function")
                    {
                        continue;
                    }

                    string fname = funcnode.Attributes["name"].Value;

                    // XXXX hack: these functions have multiple Void params, meaning
                    // that we end up with huge sets of overloads --
                    // glGetSeparableFilter has 3, so we end up with 33*33*33
                    // overloads, plus change: 4913. ouch.

                    if (fname == "GetSeparableFilterEXT" ||
                    fname == "GetSeparableFilter" ||
                    fname == "SeparableFilter2DEXT" ||
                    fname == "SeparableFilter2D")
                    {
                        continue;
                    }

                    string fentry = "gl" + fname;
                    if (funcUseGlPrefix)
                    {
                        fname = "gl" + fname;
                    }

                    string in_rettype = funcnode.Attributes["rettype"].Value;
                    string frettype = TypeMap.TypeForRetVal(in_rettype);

                    // read in the fparams

                    ArrayList fparamstr = ReadParams(funcnode);
                    ArrayList fparams;

                    if (fparamstr.Count == 0)
                    {
                        fparams = new ArrayList();
                        fparams.Add(new FuncParams());
                    }
                    else
                    {
                        foreach (GlParam param in fparamstr)
                        {
                            TypeMap.ExpandParam(param);
                        }
                        fparams = GenParamList(fparamstr, 0);
                    }

                    paramCountHash[fname] = fparams.Count;

                    if (iscore)
                    {
                        foreach (FuncParams fp in fparams)
                        {
                            // write the DllImport attribute
                            Output.WriteLine("\t\t#region {0} {1} ({2})", frettype, fname, fp.paramString);
                            Output.WriteLine("\t\t/// <summary>");
                            Output.WriteLine("\t\t/// ");
                            Output.WriteLine("\t\t/// </summary>");
                            Output.WriteLine("\t\t[DllImport(GL_NATIVE_LIBRARY, EntryPoint=\"{0}\"), SuppressUnmanagedCodeSecurity, CLSCompliantAttribute({1})]", fentry, fp.isCLSCompliant ? "true" : "false");
                            Output.WriteLine("\t\tpublic static extern {0} {1} ({2});", frettype, fname, fp.paramString);
                            Output.WriteLine("\t\t#endregion {0} {1} ({2})", frettype, fname, fp.paramString);
                            Output.WriteLine();
                        }
                    }
                    else
                    {
                        // write the extension pointer holder first (just once), along with
                        // the OpenGLExtensionImport attribute
                        Output.WriteLine("\t\t#region IntPtr ext__GL_{0}__{1}", name, fentry);
                        Output.WriteLine("\t\t/// <summary>");
                        Output.WriteLine("\t\t/// ");
                        Output.WriteLine("\t\t/// </summary>");
                        Output.WriteLine("\t\t[OpenGLExtensionImport(\"GL_{0}\", \"{1}\")]", name, fentry);
                        Output.WriteLine("\t\tpublic {0} IntPtr ext__GL_{1}__{2} = IntPtr.Zero;",
                        doInstance ? "" : "static", name, fentry);
                        Output.WriteLine("\t\t#endregion IntPtr ext__GL_{0}__{1}", name, fentry);
                        Output.WriteLine();

                        foreach (FuncParams fp in fparams)
                        {
                            // write the OpenGLExtensionImport attribute; note that it gets stripped
                            // out from methods by the postprocessor
                            Output.WriteLine("\t\t#region {0} {1} ({2})", frettype, fname, fp.paramString);
                            Output.WriteLine("\t\t/// <summary>");
                            Output.WriteLine("\t\t/// ");
                            Output.WriteLine("\t\t/// </summary>");
                            Output.WriteLine("\t\t[OpenGLExtensionImport(\"GL_{0}\", \"{1}\"), SuppressUnmanagedCodeSecurity, CLSCompliantAttribute({2})]", name, fentry, fp.isCLSCompliant ? "true" : "false");
                            Output.WriteLine("\t\tpublic {0} {1} {2} ({3}) {{",
                            doInstance ? "" : "static", frettype, fname, fp.paramString);
                            //Output.WriteLine(" throw new NotImplementedException(\"{0}\");", fname);
                            Output.WriteLine("\t\t\tthrow new NotImplementedException();");
                            Output.WriteLine("\t\t}");
                            Output.WriteLine("\t\t#endregion {0} {1} ({2})", frettype, fname, fp.paramString);
                            Output.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
