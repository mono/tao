//
// gencore.cs
//
// Author(s):
//   Vladimir Vukicevic <vladimir@pobox.com>
//
// Copyright (C) 2004 Vladimir Vukicevic <vladimir@pobox.com>
//
// This file is part of Tao; licensed under the MIT/X11 License
// as specified in the top-level License.txt file.
//

using System;
using System.IO;
using System.Xml;
using System.Collections;

public class GlParam {
  public string name;
  public string valtype;
  public string gltype;
  public string inout;

  public ArrayList nativetypes;
}

public class GlTypeMap {
  Hashtable typeHash;

  internal class GlTypeMapEntry {
    public GlTypeMapEntry() {
      if_out = 0;
      if_array = 0;
      is_generic = 0;
      as_array = 0;
    }

    public int Rank {
      get {
        int r = 0;
        if (if_out != 0) r++;
        if (if_array != 0) r++;

        return r;
      }
    }

    public string type;
    public int if_out;
    public int if_array;
    public int is_generic;
    public int as_array;
  }

  public GlTypeMap(string file) {
    typeHash = new Hashtable();

    LoadFrom (file);
  }

  internal class GlTypeMapEntryComparer : IComparer {
    public int Compare (object a, object b) {
      GlTypeMapEntry tmea = a as GlTypeMapEntry;
      GlTypeMapEntry tmeb = b as GlTypeMapEntry;

      return tmeb.Rank - tmea.Rank;
    }
  }

  public void LoadFrom(string file) {
    XmlDocument tdoc = new XmlDocument();
    tdoc.Load(file);

    XmlNodeList nl = tdoc.GetElementsByTagName("typemap");
    XmlNode typemap = nl[0];


    foreach (XmlNode typenode in typemap.ChildNodes) {
      if (typenode.NodeType != XmlNodeType.Element)
        continue;

      if (typenode.Name == "type") {

        XmlAttribute nameattr = typenode.Attributes["name"];
        if (nameattr == null) {
          Console.WriteLine ("Warning: <type> in typemap with no name attribute");
          continue;
        }

        string typename = nameattr.Value;

        if (typeHash[typename] != null) {
          Console.WriteLine ("Warning: type '{0}' mapped multiple times", typename);
          continue;
        }

        foreach (XmlNode mapnode in typenode.ChildNodes) {
          if (mapnode.NodeType != XmlNodeType.Element)
            continue;
          
          if (mapnode.Name == "mapto") {
            // skip non-c# mappings
            if (mapnode.Attributes["language"].Value != "c#")
              continue;

            GlTypeMapEntry tme = new GlTypeMapEntry();
            tme.type = mapnode.Attributes["type"].Value;

            if (mapnode.Attributes["if_out"] != null)
              tme.if_out = Convert.ToInt32(mapnode.Attributes["if_out"].Value);
            if (mapnode.Attributes["if_array"] != null)
              tme.if_array = Convert.ToInt32(mapnode.Attributes["if_array"].Value);
            if (mapnode.Attributes["as_array"] != null)
              tme.as_array = Convert.ToInt32(mapnode.Attributes["as_array"].Value);
            if (mapnode.Attributes["is_generic"] != null)
              tme.is_generic = Convert.ToInt32(mapnode.Attributes["is_generic"].Value);

            ArrayList entries = typeHash[typename] as ArrayList;
            if (entries == null) {
              entries = new ArrayList();
              typeHash[typename] = entries;
            }

            entries.Add (tme);
          }
        }
      } else if (typenode.Name == "typealias") {
        string name = typenode.Attributes["name"].Value;
        string mapto = typenode.Attributes["mapto"].Value;

        ArrayList entries = typeHash[mapto] as ArrayList;
        if (entries == null) {
          Console.WriteLine ("Warning: typealias entry for '{0}' seen before mapto type '{1}'!", name, mapto);
          continue;
        }

        if (typeHash[name] != null) {
          Console.WriteLine ("Warning: type '{0}' mapped multiple times", name);
          continue;
        }

        typeHash[name] = typeHash[mapto];
      }
    }
  }

  // this type matching code is pretty fragile; it just does the basics
  // to get the correct output for the (known) input.  you break it,
  // you get to keep both pieces.

  static string [] inArrayExpansions = new string[] {
    "ref bool", "bool []",
    "ref byte", "byte []",
    "ref short", "short []",
    "ref ushort", "ushort []",
    "ref int", "int []",
    "ref uint", "uint []",
    "ref float", "float []",
    "ref double", "double []",
    "IntPtr"
  };

  static string [] outArrayExpansions = new string[] {
    "out bool", "[Out] bool []",
    "out byte", "[Out] byte []",
    "out short", "[Out] short []",
    "out ushort", "[Out] ushort []",
    "out int", "[Out] int []",
    "out uint", "[Out] uint []",
    "out float", "[Out] float []",
    "out double", "[Out] double []",
    "IntPtr"
  };

  public void ExpandParam (GlParam param) {
    ArrayList entries = typeHash[param.gltype] as ArrayList;
    if (entries == null) {
      Console.WriteLine ("ExpandParam: type '{0}' not found in map!", param.gltype);
      throw new Exception();
    }

    int want_array, want_out;

    if (param.valtype == "array") want_array = 1;
    else want_array = -1;

    if (param.inout == "out") want_out = 1;
    else want_out = -1;

    // find the first one that matches
    foreach (GlTypeMapEntry tme in entries) {
      if ((tme.if_out == 0 || tme.if_out == want_out) &&
          (tme.if_array == 0 || tme.if_array == want_array))
      {
        // found one
        if (tme.is_generic == 1) {
          if (want_out == 1)
            param.nativetypes = new ArrayList(outArrayExpansions);
          else
            param.nativetypes = new ArrayList(inArrayExpansions);
        } else {
          string target = tme.type;
          param.nativetypes = new ArrayList();

          if (want_array == 1) {
            if (want_out == 1) {
              // an out array
              param.nativetypes.Add("out " + target);
              param.nativetypes.Add("[Out] " + target + " []");
            } else {
              // an in array
              param.nativetypes.Add("ref " + target);
              param.nativetypes.Add(target + " []");
            }
          } else {
            if (want_out == 1) {
              // an out value
              param.nativetypes.Add("out " + target);
            } else {
              // an in value
              param.nativetypes.Add(target);
            }
          }
        }

        return;
      }
    }

    Console.WriteLine ("ExpandParam: No match found for '{0}'", param.gltype);
    throw new Exception();
  }

  public string TypeForRetVal (string intype) {
    ArrayList entries = typeHash[intype] as ArrayList;
    if (entries == null) {
      Console.WriteLine ("TypeForRetVal: type '{0}' not found in map!", intype);
      throw new Exception();
    }

    // simple mapping?
    if (entries.Count == 1) {
      GlTypeMapEntry tme = entries[0] as GlTypeMapEntry;
      if (tme.Rank == 0) {
        return tme.type;
      }
    }

    // or not.
    foreach (GlTypeMapEntry tme in entries) {
      if ((tme.if_out == 0 || tme.if_out == -1) &&
          (tme.if_array == 0 || tme.if_array == -1))
        return tme.type;
    }

    Console.WriteLine ("TypeForRetVal: No match found for '{0}'", intype);
    throw new Exception();
  }
}

public class Driver {

  // this uh might be broken if this becomes false.
  public const bool funcUseGlPrefix = true;
  // currently ignored (enums aren't generated here, see sharp-genenums.py)
  public const bool enumUseGlPrefix = true;

  public static GlTypeMap TypeMap;
  public static XmlDocument Doc;

  public static StreamWriter Output;

  public static void Main (string [] args) {
    if (args.Length != 3) {
      Console.WriteLine ("Usage: gencore gl.xml typemap.xml Gl-funcs.cs");
      return;
    }

    Console.WriteLine ("Loading typemap...");
    TypeMap = new GlTypeMap(args[1]);
    
    Console.WriteLine ("Loading gl.xml...");
    Doc = new XmlDocument();
    Doc.Load(args[0]);

    Output = new StreamWriter(args[2]);

    XmlNode glspec = Doc.GetElementsByTagName("glspec")[0];
    foreach (XmlNode setnode in glspec.ChildNodes) {
      if (setnode.NodeType != XmlNodeType.Element)
        continue;

      if (setnode.Name == "coreset") {
        HandleSet (setnode, setnode.Attributes["category"].Value, true);
      } else if (setnode.Name == "extset") {
        HandleSet (setnode, setnode.Attributes["extension"].Value, false);
      }
    }

    Output.Close();

    Console.WriteLine ("Wrote {0}", args[2]);
  }

  public static ArrayList ReadParams (XmlNode funcnode) {
    ArrayList fparams = new ArrayList();

    foreach (XmlNode paramnode in funcnode.ChildNodes) {
      if (paramnode.NodeType != XmlNodeType.Element)
        continue;

      if (paramnode.Name != "param")
        continue;

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

  public static ArrayList GenParamList (ArrayList fparams, int i) {
    if (i >= fparams.Count)
      return null;

    ArrayList results = new ArrayList();
    GlParam param = fparams[i] as GlParam;

    ArrayList nextparams = GenParamList (fparams, i+1);

    if (nextparams == null) {
      foreach (string nativetype in param.nativetypes)
        results.Add(nativetype + " " + param.name);
      return results;
    }

    foreach (string nativetype in param.nativetypes) {
      foreach (string nextparam in nextparams) {
        results.Add(nativetype + " " + param.name + ", " + nextparam);
      }
    }

    return results;
  }

  public static void HandleSet (XmlNode parent, string name, bool iscore) {
    //Console.WriteLine ("Set: " + name);
    foreach (XmlNode funcnode in parent.ChildNodes) {
      if (funcnode.NodeType != XmlNodeType.Element)
        continue;

      if (funcnode.Name != "function")
        continue;

      string fname = funcnode.Attributes["name"].Value;
      string fentry = "gl" + fname;
      if (funcUseGlPrefix) fname = "gl" + fname;

      string in_rettype = funcnode.Attributes["rettype"].Value;
      string frettype = TypeMap.TypeForRetVal(in_rettype);

      // read in the fparams

      ArrayList fparams = ReadParams (funcnode);
      ArrayList paramstrings;

      if (fparams.Count == 0) {
        paramstrings = new ArrayList();
        paramstrings.Add("");
      } else {
        foreach (GlParam param in fparams)
          TypeMap.ExpandParam(param);
        paramstrings = GenParamList (fparams, 0);
      }

      if (iscore) {
        foreach (string paramstr in paramstrings) {
          // write the DllImport attribute
          Output.WriteLine();
          Output.WriteLine("    [DllImport(\"opengl32.dll\", EntryPoint=\"{0}\")]", fentry);
          Output.WriteLine("    public static extern {0} {1} ({2});", frettype, fname, paramstr);
        }
      } else {
        // write the extension pointer holder first (just once)
        Output.WriteLine();
        Output.WriteLine("    public static IntPtr ext__GL_{0}__{1} = IntPtr.Zero;", name, fentry);
        Output.WriteLine();

        foreach (string paramstr in paramstrings) {
          // write the OpenGLExtensionImport attribute
          Output.WriteLine("    [OpenGLExtensionImport(\"GL_{0}\", \"{1}\")]", name, fentry);
          Output.WriteLine("    public static {0} {1} ({2}) {{", frettype, fname, paramstr);
          // Output.WriteLine("      throw new InvalidOperationException(\"Binding error: {0}\");", fname);
          Output.WriteLine("      throw new InvalidOperationException();", fname);
          Output.WriteLine("    }");
        }
      }
    }
  }
}

