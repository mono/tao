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
using System.Runtime.InteropServices;

namespace Tao.OpenGl
{
    /// <summary>
    /// OpenGL binding for .NET, implementing OpenGL 2.1, plus extensions.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Tao.OpenGl.Gl contains all OpenGL enums and functions defined in the 2.1 specification.
    /// The official .spec files can be found at: http://opengl.org/registry/.
    /// </para>
    /// <para>
    /// Tao.OpenGl.Gl relies on static initialization to obtain the entry points for OpenGL functions.
    /// The initialization process will introduce a small delay (about 100 ms in a 2GHz machine) when
    /// an OpenGL function is first called. Please ensure that a valid OpenGL context has been
    /// made current in the pertinent thread <b>before</b> any OpenGL functions are called (toolkits
    /// like GLUT, SDL or GLFW will automatically take care of the context initialization process).
    /// Without a valid OpenGL context, Tao.OpenGl.Gl will only be able to retrieve statically exported
    /// entry points (typically corresponding to OpenGL version 1.1 under Windows, 1.3 under Linux and
    /// 1.4 under Windows Vista) - extension methods will fail.
    /// </para>
    /// <para>
    /// You can use the Gl.IsExtensionSupported method to check whether any given OpenGL extension function
    /// exists in the current OpenGL context. You may retrieve the entry point for an extension function by
    /// using the Gl.GetDelegateForExtensionMethod and Gl.GetFunctionPointerForExtensionMethod methods. Keep
    /// in mind that different OpenGL contexts may support different extensions, and under different entry
    /// points. Always check if all required extensions are still supported when changing visuals or pixel
    /// formats.
    /// </para>
    /// <para>
    /// <see href="http://opengl.org/registry/"/>
    /// <seealso cref="Gl.IsExtensionSupported"/>
    /// <seealso cref="Gl.GetDelegateForExtensionMethod"/>
    /// <seealso cref="Gl.GetFunctionPointerForExtensionMethod"/>
    /// </para>
    /// </remarks>
    public static partial class Gl
    {
        #region private enum Platform

        /// <summary>
        /// Enumerates the platforms Tao can run on.
        /// </summary>
        private enum Platform
        {
            Unknown,
            Windows,
            X11,
            X11_ARB,
            OSX
        };

        #endregion private enum Platform

        private static Platform platform = Platform.Unknown;

        #region Platform specific GetFunctionPointerForExtensionMethod dll imports

        // linux
        [DllImport(GL_NATIVE_LIBRARY, EntryPoint = "glXGetProcAddress")]
        internal static extern IntPtr glxGetProcAddress(string s);

        // also linux, for our ARB-y friends
        [DllImport(GL_NATIVE_LIBRARY, EntryPoint = "glXGetProcAddressARB")]
        internal static extern IntPtr glxGetProcAddressARB(string s);

        // windows
        [DllImport(GL_NATIVE_LIBRARY, EntryPoint = "wglGetProcAddress")]
        internal static extern IntPtr wglGetProcAddress(string s);

        // osx gets complicated
        [DllImport(GL_NATIVE_LIBRARY, EntryPoint = "NSIsSymbolNameDefined")]
        internal static extern bool NSIsSymbolNameDefined(string s);
        [DllImport(GL_NATIVE_LIBRARY, EntryPoint = "NSLookupAndBindSymbol")]
        internal static extern IntPtr NSLookupAndBindSymbol(string s);
        [DllImport(GL_NATIVE_LIBRARY, EntryPoint = "NSAddressOfSymbol")]
        internal static extern IntPtr NSAddressOfSymbol(IntPtr symbol);

        internal static IntPtr aglGetProcAddress(string s)
        {
            string fname = "_" + s;
            if (!NSIsSymbolNameDefined(fname))
                return IntPtr.Zero;

            IntPtr symbol = NSLookupAndBindSymbol(fname);
            if (symbol != IntPtr.Zero)
                symbol = NSAddressOfSymbol(symbol);

            return symbol;
        }

        #endregion  Platform specific GetFunctionPointerForExtensionMethod dll imports

        #region public static IntPtr GetFunctionPointerForExtensionMethod(string name)

        /// <summary>
        /// Retrieves the entry point for a dynamically exported OpenGL function.
        /// </summary>
        /// <param name="name">The function string for the OpenGL function (eg. "glNewList")</param>
        /// <returns>
        /// An IntPtr contaning the address for the entry point, or IntPtr.Zero if the specified
        /// OpenGL function is not dynamically exported.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The Marshal.GetDelegateForFunctionPointer method can be used to turn the return value
        /// into a call-able delegate.
        /// </para>
        /// <para>
        /// This function is cross-platform. It determines the underlying platform and uses the
        /// correct wgl, glx or agl GetAddress function to retrieve the function pointer.
        /// </para>
        /// <see cref="Marshal.GetDelegateForFunctionPointer"/>
        /// <seealso cref="Gl.GetDelegateForExtensionMethod"/>
        /// </remarks>
        public static IntPtr GetFunctionPointerForExtensionMethod(string name)
        {
            if (platform == Platform.Unknown)
            {
                IntPtr result = IntPtr.Zero;

                // WGL?
                try
                {
                    result = wglGetProcAddress(name);
                    platform = Platform.Windows;
                    return result;
                }
                catch (Exception)
                { }

                // AGL? (before X11, since GLX might exist on OSX)
                try
                {
                    result = aglGetProcAddress(name);
                    platform = Platform.OSX;
                    return result;
                }
                catch (Exception)
                { }

                // X11?
                try
                {
                    result = glxGetProcAddress(name);
                    platform = Platform.X11;
                    return result;
                }
                catch (Exception)
                { }

                // X11 ARB?
                try
                {
                    result = glxGetProcAddressARB(name);
                    platform = Platform.X11_ARB;
                    return result;
                }
                catch (Exception)
                { }

                // Ack!
                throw new NotSupportedException("Can't figure out how to call GetProcAddress on this platform!");
            }
            else if (platform == Platform.Windows)
            {
                return wglGetProcAddress(name);
            }
            else if (platform == Platform.OSX)
            {
                return aglGetProcAddress(name);
            }
            else if (platform == Platform.X11)
            {
                return glxGetProcAddress(name);
            }
            else if (platform == Platform.X11_ARB)
            {
                return glxGetProcAddressARB(name);
            }

            throw new NotSupportedException("Shouldn't get here..");
        }

        #endregion public static IntPtr GetFunctionPointerForExtensionMethod(string s)

        #region public static Delegate GetDelegateForExtensionMethod(string name, Type signature)

        /// <summary>
        /// Creates a System.Delegate that can be used to call a dynamically exported OpenGL function.
        /// </summary>
        /// <param name="name">The function string for the OpenGL function (eg. "glNewList")</param>
        /// <param name="signature">The signature of the OpenGL function.</param>
        /// <returns>
        /// A System.Delegate that can be used to call this OpenGL function or null
        /// if the function is not available in the current OpenGL context.
        /// </returns>
        public static Delegate GetDelegateForExtensionMethod(string name, Type signature)
        {
            IntPtr address = GetFunctionPointerForExtensionMethod(name);
            if (address == IntPtr.Zero)
            {
                return null;
            }
            else
            {
                return Marshal.GetDelegateForFunctionPointer(address, signature);
            }
        }

        #endregion public static Delegate GetAddress(string name, Type signature)

        #region public static bool IsExtensionSupported(string name)

        /// <summary>
        /// Determines whether the specified OpenGL extension function is available in
        /// the current OpenGL context.
        /// </summary>
        /// <param name="name">The function string for the OpenGL function (eg. "glNewList")</param>
        /// <returns>True if the specified extension function is available, false otherwise.</returns>
        public static bool IsExtensionSupported(string name)
        {
            if (GetFunctionPointerForExtensionMethod(name) == IntPtr.Zero)
                return false;
            return true;
        }

        #endregion public static bool IsExtensionSupported(string name)
    }
}
