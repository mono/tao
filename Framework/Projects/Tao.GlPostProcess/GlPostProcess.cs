//
//  Tao.GlPostProcess.cs
//
//  This file is part of Tao.
//
//  Copyright (C) 2004  Vladimir Vukicevic  <vladimir@pobox.com>
//
//  This file is licensed under the MIT/X11 License, as outlined
//  in the License.txt file at the top level of this distribution.
//


using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace Tao {

public class GlPostProcess {
  // .config files are used to map this in mono
  public const string GL_NATIVE_LIBRARY = "opengl32.dll";

  static Hashtable field_hash;

  public static void Main(string [] args) {
    if (args.Length < 3 || args.Length > 4) {
      Console.WriteLine ("Usage: GlPostProcess.exe in.dll out.dll Tao.OpenGl.Gl [Tao.OpenGl.ContextGl]");
      return;
    }

    string inName = args[0];
    string outName = args[1];
    string typeName = args[2];
    string instanceTypeName = null;

    if (args.Length == 4)
      instanceTypeName = args[3];

    string outDir = System.IO.Path.GetDirectoryName(outName);
    string outDll = System.IO.Path.GetFileName(outName);
    string outNameBase = System.IO.Path.GetFileNameWithoutExtension(outName);

    // The MS runtime doesn't support a bunch of queries on
    // dynamic modules, so we have to track this stuff ourselves
    field_hash = new Hashtable();
    
    // load the input DLL as an Assembly
    Assembly inputAssembly = Assembly.LoadFrom(inName);

    // the calli instructions are unverifiable
    PermissionSet reqPermSet = new PermissionSet(PermissionState.None);
    reqPermSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.SkipVerification));

    AssemblyName outAsName = new AssemblyName();
    outAsName.Name = outNameBase;
    // create a dynamic assembly
    AssemblyBuilder abuilder = AppDomain.CurrentDomain.DefineDynamicAssembly
      (outAsName, AssemblyBuilderAccess.Save, outDir != null && outDir.Length > 0 ? outDir : null,
       reqPermSet, null, null);
    abuilder.SetCustomAttribute (GetCLSCompliantCAB (true));

    // go through and copy over custom attributes
    //object [] assemblyAttrs = inputAssembly.GetCustomAttributes (false);
    // copy over references
    //AssemblyName [] assemblyRefs = inputAssembly.GetReferencedAssemblies ();


    // create a dynamic module
    ModuleBuilder mbuilder = abuilder.DefineDynamicModule(outAsName.Name, outDll);
    mbuilder.SetCustomAttribute (GetCLSCompliantCAB (true));
    mbuilder.SetCustomAttribute (GetUnverifiableCodeCAB ());

    ProcessType (mbuilder, inputAssembly, typeName, false);
    if (instanceTypeName != null)
      ProcessType (mbuilder, inputAssembly, instanceTypeName, false);

    mbuilder.CreateGlobalFunctions();
    abuilder.Save(outDll);
  }

  //
  // Custom attributes
  //
  static CustomAttributeBuilder clsCAB = null;
  public static CustomAttributeBuilder GetCLSCompliantCAB (bool isCLScompliant) {
    if (clsCAB == null) {
      ConstructorInfo clsCI = typeof(CLSCompliantAttribute).GetConstructor(new Type [] { typeof(bool) });
      clsCAB = new CustomAttributeBuilder (clsCI, new object [] { isCLScompliant });
    }
    return clsCAB;
  }

  static CustomAttributeBuilder sumcsCAB = null;
  public static CustomAttributeBuilder GetSuppressUnmanagedCSCAB () {
    if (sumcsCAB == null) {
      ConstructorInfo sumcsCI = typeof(SuppressUnmanagedCodeSecurityAttribute).GetConstructor(new Type [] {});
      sumcsCAB = new CustomAttributeBuilder(sumcsCI, new object [] {});
    }
    return sumcsCAB;
  }

  static CustomAttributeBuilder outCAB = null;
  public static CustomAttributeBuilder GetOutCAB () {
    if (outCAB == null) {
      ConstructorInfo outCI = typeof(OutAttribute).GetConstructor(new Type [] {});
      outCAB = new CustomAttributeBuilder(outCI, new object [] {});
    }
    return outCAB;
  }

  static CustomAttributeBuilder uvfCAB = null;
  public static CustomAttributeBuilder GetUnverifiableCodeCAB () {
    if (uvfCAB == null) {
      ConstructorInfo uvfCI = typeof(UnverifiableCodeAttribute).GetConstructor(new Type [] {});
      uvfCAB = new CustomAttributeBuilder(uvfCI, new object [] {});
    }
    return uvfCAB;
  }

  //
  // ProcessType
  //
  // takes a mbuilder for output, the input assembly, the name of the type,
  // and a flag indicating whether it's an instance type or not (i.e. whether
  // the members should be static or not.
  //
  // It then munges mercilessly.
  //
  public static void ProcessType(ModuleBuilder mbuilder, Assembly inputAssembly,
                                 string typeName, bool isInstanceClass)
  {
    TypeBuilder glbuilder = mbuilder.DefineType(typeName,
                                                TypeAttributes.Public |
                                                TypeAttributes.Class |
                                                TypeAttributes.Sealed);
    glbuilder.SetCustomAttribute (GetCLSCompliantCAB(true));

    Type gltype = inputAssembly.GetType(typeName);
    MemberInfo [] glMembers = gltype.GetMembers(BindingFlags.Instance |
                                                BindingFlags.Static |
                                                BindingFlags.Public |
                                                BindingFlags.NonPublic |
                                                BindingFlags.DeclaredOnly);

    // just something to help us print some status..
    int methodCount = 0;
    Console.Write ("Processing {0}...", typeName);

    foreach (MemberInfo qi in glMembers) {
      // Fields
      FieldInfo fi = qi as FieldInfo;
      if (fi != null) {
        // Console.WriteLine ("FIELD: " + fi.Name);
        FieldBuilder fb = glbuilder.DefineField (fi.Name, fi.FieldType, fi.Attributes);
        // only set constants in the non-instance class
        if (fi.FieldType != typeof(System.IntPtr) && !isInstanceClass) {
          fb.SetConstant (fi.GetValue (gltype));
        } else {
          object [] extattrs = fi.GetCustomAttributes (typeof(OpenGl.OpenGLExtensionImport), false);
          if (extattrs.Length > 0) {
            OpenGl.OpenGLExtensionImport ogl = extattrs[0] as OpenGl.OpenGLExtensionImport;
            if (ogl == null)
              throw new InvalidProgramException ("Thought we had an attr, guess we were wrong!");
            fb.SetCustomAttribute (CreateGLExtCAB (ogl.ExtensionName, ogl.EntryPoint));
          }

          // this is a slot to hold an extension addr,
          // so we save it.  We have to do this because on
          // windows we can't call GetField on a dynamic type.
          // This is probably faster anyway.
          field_hash[fi.Name] = fb;
        }
        continue;
      }

      // Methods
      MethodInfo mi = qi as MethodInfo;
      if (mi != null) {
        bool is_ext;
        bool is_dll;
        bool is_cls_compliant;
        object [] extattrs = mi.GetCustomAttributes (typeof(OpenGl.OpenGLExtensionImport), false);
        object [] clsattrs = mi.GetCustomAttributes (typeof(CLSCompliantAttribute), false);

        is_ext = (extattrs.Length > 0);
        is_dll = (mi.Attributes & MethodAttributes.PinvokeImpl) != 0;

        if (clsattrs.Length > 0) {
          is_cls_compliant = (clsattrs[0] as CLSCompliantAttribute).IsCompliant;
        } else {
          is_cls_compliant = true;
        }

        ParameterInfo [] parms = mi.GetParameters();
        Type [] methodSig = new Type [parms.Length];
        ParameterAttributes [] methodParams = new ParameterAttributes [parms.Length];
        for (int i = 0; i < parms.Length; i++) {
          methodSig[i] = parms[i].ParameterType;
          methodParams[i] = parms[i].Attributes;
        }

        // Console.WriteLine ("Method: {0} is_dll: {1}", mi.Name, is_dll);

        if (is_dll) {
          // this is a normal DLL import'd method
          // Console.WriteLine ("DLL import method: " + mi.Name);
          MethodBuilder mb = glbuilder.DefinePInvokeMethod (mi.Name, GL_NATIVE_LIBRARY, mi.Name,
                                                            mi.Attributes,
                                                            CallingConventions.Standard,
                                                            mi.ReturnType, methodSig,
                                                            CallingConvention.Winapi,
                                                            CharSet.Ansi);
          mb.SetImplementationFlags(mb.GetMethodImplementationFlags() |
                                    MethodImplAttributes.PreserveSig);

          // Set In/Out/etc. back
          for (int i = 0; i < parms.Length; i++)
            mb.DefineParameter (i+1, methodParams[i], null);

          mb.SetCustomAttribute (GetSuppressUnmanagedCSCAB());
          if (is_cls_compliant)
            mb.SetCustomAttribute (GetCLSCompliantCAB(true));
          else
            mb.SetCustomAttribute (GetCLSCompliantCAB(false));
        } else if (is_ext) {
          // this is an OpenGLExtensionImport method
          OpenGl.OpenGLExtensionImport ogl = extattrs[0] as OpenGl.OpenGLExtensionImport;
          if (ogl == null)
            throw new InvalidProgramException ("Thought we had an OpenGLExtensionImport, guess not?");

          // Console.WriteLine ("OpenGL Extension method: " + mi.Name);
          MethodBuilder mb = glbuilder.DefineMethod (mi.Name, mi.Attributes, mi.ReturnType, methodSig);
          // Set In/Out/etc. back
          for (int i = 0; i < parms.Length; i++)
            mb.DefineParameter (i+1, methodParams[i], null);

          // put attributes
          mb.SetCustomAttribute (GetSuppressUnmanagedCSCAB());
          if (is_cls_compliant)
            mb.SetCustomAttribute (GetCLSCompliantCAB(true));
          else
            mb.SetCustomAttribute (GetCLSCompliantCAB(false));
          // now build the IL
          string fieldname = "ext__" + ogl.ExtensionName + "__" + ogl.EntryPoint;
          FieldInfo addrfield = field_hash[fieldname] as FieldInfo;

          // no workie on win32; the field_hash is probably faster anyway
//        FieldInfo addrfield = glbuilder.GetField(fieldname,
//                                                 BindingFlags.Instance |
//                                                 BindingFlags.Static |
//                                                 BindingFlags.Public |
//                                                 BindingFlags.NonPublic |
//                                                 BindingFlags.DeclaredOnly);

          ILGenerator ilg = mb.GetILGenerator();
          {
            int numargs = methodSig.Length;
            int argoffset = 0;
            if (isInstanceClass)
              argoffset = 1;

            for (int i = argoffset; i < numargs; i++) {
              switch (i) {
              case 0: ilg.Emit(OpCodes.Ldarg_0); break;
              case 1: ilg.Emit(OpCodes.Ldarg_1); break;
              case 2: ilg.Emit(OpCodes.Ldarg_2); break;
              case 3: ilg.Emit(OpCodes.Ldarg_3); break;
              default:ilg.Emit(OpCodes.Ldarg_S, i); break;
              }
            }

            if (isInstanceClass) {
              // load the instance field
              ilg.Emit(OpCodes.Ldarg_0);
              ilg.Emit(OpCodes.Ldfld, addrfield);
            } else {
              // just load the static field
              ilg.Emit(OpCodes.Ldsfld, addrfield);
            }

            // emit Tailcall; have the return take place directly to our
            // caller
            ilg.Emit(OpCodes.Tailcall);

            // XXX these CallingConvetions should be the "default" ones;
            // for some reason, the .net runtime borks on CallingConvention.Default
            // here.
            // SignatureHelper sh = SignatureHelper.GetMethodSigHelper (mbuilder, mi.ReturnType, methodSig);
            // ilg.Emit(OpCodes.Calli, sh);

            ilg.EmitCalli(OpCodes.Calli,
#if !WIN32
                          CallingConvention.Cdecl,
#else
                          CallingConvention.StdCall,
#endif
                          mi.ReturnType, methodSig);

          }
          ilg.Emit(OpCodes.Ret);
        } else {
          // this is a normal method
          // this shouldn't happen
          Console.WriteLine ();
          Console.WriteLine ("WARNING: Skipping non-DLL and non-Extension method " + mi.Name);
        }

        methodCount++;
        if (methodCount % 50 == 0) {
          Console.Write(".");
        }
        if (methodCount % 1000 == 0) {
          Console.Write("[{0}]", methodCount);
        }
      }
    }

    Console.WriteLine();

    glbuilder.CreateType();

    Console.WriteLine ("Type created.");
  }

  static CustomAttributeBuilder CreateGLExtCAB (string extname, string procname) {
    Type [] ctorParams = new Type [] { typeof(string), typeof(string) };
    ConstructorInfo classCtorInfo = typeof(OpenGl.OpenGLExtensionImport).GetConstructor (ctorParams);
    CustomAttributeBuilder cab = new CustomAttributeBuilder (classCtorInfo,
                                                             new object [] { extname, procname } );
    return cab;
  }
}

}
