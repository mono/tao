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

namespace Tao 
{

	/// <summary>
	/// 
	/// </summary>
	public class GlPostProcess 
	{
		// .config files are used to map this in mono
		/// <summary>
		/// 
		/// </summary>
		public const string GL_NATIVE_LIBRARY = "opengl32.dll";

		static Hashtable field_hash;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string [] args) 
		{
			if (args.Length < 3 || args.Length > 4) 
			{
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
		/// <summary>
		/// 
		/// </summary>
		/// <param name="isCLScompliant"></param>
		/// <returns></returns>
		public static CustomAttributeBuilder GetCLSCompliantCAB (bool isCLScompliant) 
		{
			if (clsCAB == null) 
			{
				ConstructorInfo clsCI = typeof(CLSCompliantAttribute).GetConstructor(new Type [] { typeof(bool) });
				clsCAB = new CustomAttributeBuilder (clsCI, new object [] { isCLScompliant });
			}
			return clsCAB;
		}

		static CustomAttributeBuilder sumcsCAB = null;
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static CustomAttributeBuilder GetSuppressUnmanagedCSCAB () 
		{
			if (sumcsCAB == null) 
			{
				ConstructorInfo sumcsCI = typeof(SuppressUnmanagedCodeSecurityAttribute).GetConstructor(new Type [] {});
				sumcsCAB = new CustomAttributeBuilder(sumcsCI, new object [] {});
			}
			return sumcsCAB;
		}

		static CustomAttributeBuilder outCAB = null;
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static CustomAttributeBuilder GetOutCAB () 
		{
			if (outCAB == null) 
			{
				ConstructorInfo outCI = typeof(OutAttribute).GetConstructor(new Type [] {});
				outCAB = new CustomAttributeBuilder(outCI, new object [] {});
			}
			return outCAB;
		}

		static CustomAttributeBuilder uvfCAB = null;
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static CustomAttributeBuilder GetUnverifiableCodeCAB () 
		{
			if (uvfCAB == null) 
			{
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

		// see below for win32 hack
		static FieldInfo win32SigField;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="mbuilder"></param>
		/// <param name="inputAssembly"></param>
		/// <param name="typeName"></param>
		/// <param name="isInstanceClass"></param>
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

			foreach (MemberInfo qi in glMembers) 
			{
				// Fields
				FieldInfo fi = qi as FieldInfo;
				if (fi != null) 
				{
					// Console.WriteLine ("FIELD: " + fi.Name);
					FieldBuilder fb = glbuilder.DefineField (fi.Name, fi.FieldType, fi.Attributes);
					// only set constants in the non-instance class
					if (fi.FieldType != typeof(System.IntPtr) && !isInstanceClass) 
					{
						fb.SetConstant (fi.GetValue (gltype));
					} 
					else 
					{
						object [] extattrs = fi.GetCustomAttributes (typeof(OpenGl.OpenGLExtensionImport), false);
						if (extattrs.Length > 0) 
						{
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
				if (mi != null) 
				{
					bool is_ext;
					bool is_dll;
					bool is_cls_compliant;
					object [] extattrs = mi.GetCustomAttributes (typeof(OpenGl.OpenGLExtensionImport), false);
					object [] clsattrs = mi.GetCustomAttributes (typeof(CLSCompliantAttribute), false);

					is_ext = (extattrs.Length > 0);
					is_dll = (mi.Attributes & MethodAttributes.PinvokeImpl) != 0;

					if (clsattrs.Length > 0) 
					{
						is_cls_compliant = (clsattrs[0] as CLSCompliantAttribute).IsCompliant;
					} 
					else 
					{
						is_cls_compliant = true;
					}

					ParameterInfo [] parms = mi.GetParameters();
					Type [] methodSig = new Type [parms.Length];
					ParameterAttributes [] methodParams = new ParameterAttributes [parms.Length];
					for (int i = 0; i < parms.Length; i++) 
					{
						methodSig[i] = parms[i].ParameterType;
						methodParams[i] = parms[i].Attributes;
					}

					// Console.WriteLine ("Method: {0} is_dll: {1}", mi.Name, is_dll);

					if (is_dll) 
					{
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
					} 
					else if (is_ext) 
					{
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

						for (int i = argoffset; i < numargs; i++) 
						{
							switch (i) 
							{
								case 0: ilg.Emit(OpCodes.Ldarg_0); break;
								case 1: ilg.Emit(OpCodes.Ldarg_1); break;
								case 2: ilg.Emit(OpCodes.Ldarg_2); break;
								case 3: ilg.Emit(OpCodes.Ldarg_3); break;
								default:ilg.Emit(OpCodes.Ldarg_S, i); break;
							}
						}

						if (isInstanceClass) 
						{
							// load the instance field
							ilg.Emit(OpCodes.Ldarg_0);
							ilg.Emit(OpCodes.Ldfld, addrfield);
						} 
						else 
						{
							// just load the static field
							ilg.Emit(OpCodes.Ldsfld, addrfield);
						}

						// emit Tailcall; have the return take place directly to our
						// caller
						ilg.Emit(OpCodes.Tailcall);

						// The .NET 1.1 runtime doesn't let us emit
						// CallingConvention.Winapi here, or anything else that
						// might mean "Use whatever the default platform calling
						// convention is", like p/invoke can have.
						//
						// However, Mono 1.0 /does/ let us emit Winapi/Default,
						// and both .NET 1.1 and Mono handle this as intended
						// (stdcall on .NET, cdecl on Mono/Linux).  By my reading
						// of ECMA-335 (CLI), 22.2.2, this should be allowed, and
						// I'm not sure why MS's impl doesn't allow it.  However,
						// the .NET System.Reflection.Emit leaves a lot to be
						// desired anyway.
						//
						// So, the issue is how to emit this.  On WIN32, we simply
						// create our own SignatureHelper, and munge the internal
						// signature byte.  Fun, eh?

#if !WIN32
	    // Mono?  Just emit normally.
            ilg.EmitCalli(OpCodes.Calli,
                          CallingConvention.Winapi,
                          mi.ReturnType, methodSig);
#else

						// We're too smart for our own good.  We don't tell win32 how to do stack
						// cleanup, so it leaves things littering the stack.  So, we can't do this.
						// GRRRrrr.
#if true
						ilg.EmitCalli(OpCodes.Calli,
							CallingConvention.StdCall,
							mi.ReturnType, methodSig);
#else
	    // Win32?  Let the fun begin.
	    if (win32SigField == null)
	      win32SigField = typeof(SignatureHelper).GetField("m_signature", BindingFlags.Instance | BindingFlags.NonPublic);

            SignatureHelper sh = SignatureHelper.GetMethodSigHelper (mbuilder,
								     CallingConvention.StdCall,	// lie
								     mi.ReturnType);
	    // munge calling convention; the value in the first byte will be 0x2 for StdCall (1 minus
	    // the CallingConvention enum value).  We set to 0.
	    Array sigArr = win32SigField.GetValue(sh) as Array;
	    sigArr.SetValue((byte) 0, 0);
	    // then add the rest of the args.
	    foreach (Type t in methodSig)
	      sh.AddArgument(t);

            ilg.Emit(OpCodes.Calli, sh);
#endif
#endif

					}
						ilg.Emit(OpCodes.Ret);
					} 
					else 
					{
						// this is a normal method
						// this shouldn't happen
						Console.WriteLine ();
						Console.WriteLine ("WARNING: Skipping non-DLL and non-Extension method " + mi.Name);
					}

					methodCount++;
					if (methodCount % 50 == 0) 
					{
						Console.Write(".");
					}
					if (methodCount % 1000 == 0) 
					{
						Console.Write("[{0}]", methodCount);
					}
				}
			}

			Console.WriteLine();

			glbuilder.CreateType();

			Console.WriteLine ("Type created.");
		}

		static CustomAttributeBuilder CreateGLExtCAB (string extname, string procname) 
		{
			Type [] ctorParams = new Type [] { typeof(string), typeof(string) };
			ConstructorInfo classCtorInfo = typeof(OpenGl.OpenGLExtensionImport).GetConstructor (ctorParams);
			CustomAttributeBuilder cab = new CustomAttributeBuilder (classCtorInfo,
				new object [] { extname, procname } );
			return cab;
		}
	}

}
