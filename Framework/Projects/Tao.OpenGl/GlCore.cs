//
//  GlBindingCore
//
//  Copyright (c) 2004  Vladimir Vukicevic  <vladimir@pobox.com>
//
//  This file is part of Tao.
//
//  This library is licensed under the MIT/X11 license.
//  Please see the file MIT.X11 for more information.
//

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Tao.OpenGl {

  //
  // This attribute is used to decorate OpenGL extension entry points.
  // It specifies both the extension name (full name, with GL_ prefix)
  // as well as the library entry point that should be queried for a
  // a particular method.  The field it's applied to will receive the
  // address of the function, whereas the method is only used before
  // postprocessing to tie a particular method with a particular extension.
  //
  [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
  public class OpenGLExtensionImport : Attribute {
    public string ExtensionName;
    public string EntryPoint;

    public OpenGLExtensionImport (string ExtensionName, string EntryPoint) {
      this.ExtensionName = ExtensionName;
      this.EntryPoint = EntryPoint;
    }
  }

  //
  // The GlExtensionLoader singleton, available through GetInstance(),
  // is responsible for loading extensions.
  //
  public class GlExtensionLoader {
    //
    // Data for a particular context; available extensions,
    // already-loaded extensions, etc.
    //

    internal class GlContextInfo {
      public Hashtable AvailableExtensions;
      public Hashtable LoadedExtensions;

      public GlContextInfo() {
        AvailableExtensions = new Hashtable();
        LoadedExtensions = new Hashtable();

        ParseAvailableExtensions();
      }

      public void ParseAvailableExtensions() {
        // assumes that the context is already made current
        IntPtr extstrptr = glGetString(0x00001f03); // GL_EXTENSIONS
        if (extstrptr == IntPtr.Zero)
          return;               // no extensions are available

        string extstr = Marshal.PtrToStringAnsi (extstrptr);

        string [] exts = extstr.Split(' ');
        foreach (string ext in exts) {
          AvailableExtensions[ext] = true;
        }
      }
    }

    // key -> GlContextInfo
    // 0 is special key for the static context
    private static Hashtable ContextInfo;

    static GlExtensionLoader() { 
        ContextInfo = new Hashtable();
    }

    // we can't depend on any symbols from Tao.OpenGl.Gl

    // linux
    [DllImport("libGL.so", EntryPoint="glXGetProcAddress")]
    internal static extern IntPtr glxGetProcAddress(string s);

    // windows
    [DllImport("opengl32.dll", EntryPoint="wglGetProcAddress")]
    internal static extern IntPtr wglGetProcAddress(string s);

    // osx gets complicated
    [DllImport("libdl.dylib", EntryPoint="NSIsSymbolNameDefined")]
    internal static extern bool NSIsSymbolNameDefined(string s);
    [DllImport("libdl.dylib", EntryPoint="NSLookupAndBindSymbol")]
    internal static extern IntPtr NSLookupAndBindSymbol(string s);
    [DllImport("libdl.dylib", EntryPoint="NSAddressOfSymbol")]
    internal static extern IntPtr NSAddressOfSymbol(IntPtr symbol);

    // we can't depend on Tao.OpenGl.Gl for this
    
    [DllImport("opengl32.dll")]
    internal static extern IntPtr glGetString(uint name);

    internal static IntPtr aglGetProcAddress(string s) {
      string fname = "_" + s;
      if (!NSIsSymbolNameDefined(fname))
        return IntPtr.Zero;

      IntPtr symbol = NSLookupAndBindSymbol(fname);
      if (symbol != IntPtr.Zero)
        symbol = NSAddressOfSymbol(symbol);

      return symbol;
    }

    internal static GlContextInfo GetContextInfo(object ctx) {
      // use "0" to mean no context
      if (ctx == null)
        ctx = 0;

      if (!ContextInfo.ContainsKey(ctx)) {
        ContextInfo[ctx] = new GlContextInfo();
      }

      return ContextInfo[ctx] as GlContextInfo;
    }

    //
    // the public entry point for a cross-platform GetProcAddress
    //
    enum GetProcAddressPlatform {
      Unknown,
      Windows,
      X11,
      OSX
    };

    static GetProcAddressPlatform gpaPlatform = GetProcAddressPlatform.Unknown;

    public static IntPtr GetProcAddress(string s) {
      if (gpaPlatform == GetProcAddressPlatform.Unknown) {
        IntPtr result = IntPtr.Zero;

        // WGL?
        try {
          result = wglGetProcAddress(s);
          gpaPlatform = GetProcAddressPlatform.Windows;
          return result;
        } catch (Exception e) {
        }

        // AGL? (before X11, since GLX might exist on OSX)
        try {
          result = aglGetProcAddress(s);
          gpaPlatform = GetProcAddressPlatform.OSX;
          return result;
        } catch (Exception e) {
        }

        // X11?
        try {
          result = glxGetProcAddress(s);
          gpaPlatform = GetProcAddressPlatform.X11;
          return result;
        } catch (Exception e) {
        }

        // Ack!
        throw new NotSupportedException ("Can't figure out how to call GetProcAddress on this platform!");
      } else if (gpaPlatform == GetProcAddressPlatform.Windows) {
        return wglGetProcAddress(s);
      } else if (gpaPlatform == GetProcAddressPlatform.OSX) {
        return aglGetProcAddress(s);
      } else if (gpaPlatform == GetProcAddressPlatform.X11) {
        return glxGetProcAddress(s);
      }

      throw new NotSupportedException ("Shouldn't get here..");
    }

    private GlExtensionLoader () {
    }

    //
    // IsExtensionSupported
    //
    // Asks if the extension with the given name is supported
    // in the global static context.
    //
    public static bool IsExtensionSupported (string extname) {
      return IsExtensionSupported (null, extname);
    }

    //
    // IsExtensionSupported
    //
    // Asks if the extension with the given name is supported
    // in the given context.
    //
    public static bool IsExtensionSupported (object contextGl, string extname) {
      GlContextInfo gci = GetContextInfo(contextGl);
      if (gci.AvailableExtensions.ContainsKey (extname))
        return true;
      return false;
    }

    //
    // LoadExtension
    //
    // Attempt to load the extension with the specified name into the
    // global static context.
    //
    public static bool LoadExtension (string extname) {
      return LoadExtension (null, extname, false);
    }

    //
    // LoadExtension
    //
    // Attempt to load the extension with the specified name into the
    // given context, which must have already been made current.  The
    // object passed in ought to be an instance of
    // Tao.OpenGl.ContextGl, or null.
    //
    public static bool LoadExtension (object contextGl, string extname) {
      return LoadExtension (contextGl, extname, false);
    }

    //
    // LoadExtension
    //
    // Attempt to load the extension with the specified name into the
    // given context, which must have already been made current.  The
    // object passed in ought to be an instance of
    // Tao.OpenGl.ContextGl, or null. If forceLoad is set, attempt
    // to obtain function pointers even if the runtime claims that the
    // extension is not supported.
    //
    public static bool LoadExtension (object contextGl, string extname, bool forceLoad) {
      GlContextInfo gci = GetContextInfo(contextGl);
      if (gci.LoadedExtensions.ContainsKey (extname)) {
        return (bool) gci.LoadedExtensions[extname];
      }

      if (!forceLoad && !gci.AvailableExtensions.ContainsKey (extname)) {
        return false;
      }

      // this will get us either the Tao.OpenGl.Gl or
      // Tao.OpenGl.ContextGl class
      Type glt;
      if (contextGl != null) {
        glt = contextGl.GetType();
      } else {
        glt = StaticGlType;
        if (glt == null) {
          Console.WriteLine ("GL type is null!");
        }
      }

      FieldInfo [] fis = glt.GetFields (BindingFlags.Public |
                                        BindingFlags.DeclaredOnly |
                                        BindingFlags.Static |
                                        BindingFlags.Instance);

      foreach (FieldInfo fi in fis) {
        object [] attrs = fi.GetCustomAttributes (typeof(OpenGLExtensionImport), false);
        if (attrs.Length == 0)
          continue;

        OpenGLExtensionImport oglext = attrs[0] as OpenGLExtensionImport;
        if (oglext.ExtensionName == extname) {
          // did we already load this somehow?
          if (((IntPtr) fi.GetValue(contextGl)) != IntPtr.Zero)
            continue;

          //Console.WriteLine ("Loading " + oglext.EntryPoint + " for " + extname);
          IntPtr procaddr = GetProcAddress (oglext.EntryPoint);
          if (procaddr == IntPtr.Zero) {
            Console.WriteLine ("OpenGL claimed that '{0}' was supported, but couldn't find '{1}' entry point",
                               extname, oglext.EntryPoint);
            // we crash if anyone tries to call this method, but that's ok
            continue;
          }

          fi.SetValue (contextGl, procaddr);
        }
      }

      gci.LoadedExtensions[extname] = true;
      return true;
    }

    //
    // LoadAllExtensions
    //

    public static void LoadAllExtensions () {
      LoadAllExtensions (null);
    }

    public static void LoadAllExtensions (object contextGl) {
      GlContextInfo gci = GetContextInfo(contextGl);

      foreach (string ext in gci.AvailableExtensions.Keys)
	LoadExtension (contextGl, ext, false);
    }

    //
    // Find the Tao.OpenGl.Gl type
    //
    static Type mStaticGlType;
    static Type StaticGlType {
      get {
        if (mStaticGlType != null)
          return mStaticGlType;

        foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies()) {
          mStaticGlType = asm.GetType("Tao.OpenGl.Gl");
          if (mStaticGlType != null)
            return mStaticGlType;
        }

        throw new InvalidProgramException("Can't find Tao.OpenGl.Gl type in any loaded assembly!");
      }
    }
  }
}
