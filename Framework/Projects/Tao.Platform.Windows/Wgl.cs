#region License
/*
MIT License
Copyright ©2003-2005 Tao Framework Team
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
using System.Runtime.InteropServices;
using System.Security;

namespace Tao.Platform.Windows {
    #region Class Documentation
    /// <summary>
    ///     <para>
    ///         WGL binding for .NET, implementing Windows-specific OpenGL functionality.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Binds the wgl functions and definitions in opengl32.dll.
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Wgl {
        // --- Fields ---
        #region Private Constants
        #region string WGL_NATIVE_LIBRARY
        /// <summary>
        ///     <para>
        ///         Specifies WGL's native library archive.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Specifies opengl32.dll for Windows.
        ///     </para>
        /// </remarks>
        private const string WGL_NATIVE_LIBRARY = "opengl32.dll";
        #endregion string WGL_NATIVE_LIBRARY

        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.StdCall" />.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.StdCall;
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants

        #region Public Constants
        #region wglSwapLayerBuffers Flags
        #region int WGL_SWAP_MAIN_PLANE
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the main plane.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_MAIN_PLANE     0x00000001
        public const int WGL_SWAP_MAIN_PLANE = 0x00000001;
        #endregion int WGL_SWAP_MAIN_PLANE

        #region int WGL_SWAP_OVERLAY1
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 1.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY1       0x00000002
        public const int WGL_SWAP_OVERLAY1 = 0x00000002;
        #endregion int WGL_SWAP_OVERLAY1

        #region int WGL_SWAP_OVERLAY2
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 2.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY2       0x00000004
        public const int WGL_SWAP_OVERLAY2 = 0x00000004;
        #endregion int WGL_SWAP_OVERLAY2

        #region int WGL_SWAP_OVERLAY3
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 3.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY3       0x00000008
        public const int WGL_SWAP_OVERLAY3 = 0x00000008;
        #endregion int WGL_SWAP_OVERLAY3

        #region int WGL_SWAP_OVERLAY4
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 4.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY4       0x00000010
        public const int WGL_SWAP_OVERLAY4 = 0x00000010;
        #endregion int WGL_SWAP_OVERLAY4

        #region int WGL_SWAP_OVERLAY5
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 5.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY5       0x00000020
        public const int WGL_SWAP_OVERLAY5 = 0x00000020;
        #endregion int WGL_SWAP_OVERLAY5

        #region int WGL_SWAP_OVERLAY1
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 6.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY6       0x00000040
        public const int WGL_SWAP_OVERLAY6 = 0x00000040;
        #endregion int WGL_SWAP_OVERLAY6

        #region int WGL_SWAP_OVERLAY7
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 7.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY7       0x00000080
        public const int WGL_SWAP_OVERLAY7 = 0x00000080;
        #endregion int WGL_SWAP_OVERLAY7

        #region int WGL_SWAP_OVERLAY8
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 8.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY8       0x00000100
        public const int WGL_SWAP_OVERLAY8 = 0x00000100;
        #endregion int WGL_SWAP_OVERLAY8

        #region int WGL_SWAP_OVERLAY9
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 9.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY9       0x00000200
        public const int WGL_SWAP_OVERLAY9 = 0x00000200;
        #endregion int WGL_SWAP_OVERLAY9

        #region int WGL_SWAP_OVERLAY10
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 10.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY10      0x00000400
        public const int WGL_SWAP_OVERLAY10 = 0x00000400;
        #endregion int WGL_SWAP_OVERLAY10

        #region int WGL_SWAP_OVERLAY11
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 11.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY11      0x00000800
        public const int WGL_SWAP_OVERLAY11 = 0x00000800;
        #endregion int WGL_SWAP_OVERLAY11

        #region int WGL_SWAP_OVERLAY12
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 12.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY12      0x00001000
        public const int WGL_SWAP_OVERLAY12 = 0x00001000;
        #endregion int WGL_SWAP_OVERLAY12

        #region int WGL_SWAP_OVERLAY13
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 13.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY13      0x00002000
        public const int WGL_SWAP_OVERLAY13 = 0x00002000;
        #endregion int WGL_SWAP_OVERLAY13

        #region int WGL_SWAP_OVERLAY14
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 14.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY14      0x00004000
        public const int WGL_SWAP_OVERLAY14 = 0x00004000;
        #endregion int WGL_SWAP_OVERLAY14

        #region int WGL_SWAP_OVERLAY15
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the overlay plane 15.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_OVERLAY15      0x00008000
        public const int WGL_SWAP_OVERLAY15 = 0x00008000;
        #endregion int WGL_SWAP_OVERLAY15

        #region int WGL_SWAP_UNDERLAY1
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 1.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY1      0x00010000
        public const int WGL_SWAP_UNDERLAY1 = 0x00010000;
        #endregion int WGL_SWAP_UNDERLAY1

        #region int WGL_SWAP_UNDERLAY2
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 2.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY2      0x00020000
        public const int WGL_SWAP_UNDERLAY2 = 0x00020000;
        #endregion int WGL_SWAP_UNDERLAY2

        #region int WGL_SWAP_UNDERLAY3
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 3.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY3      0x00040000
        public const int WGL_SWAP_UNDERLAY3 = 0x00040000;
        #endregion int WGL_SWAP_UNDERLAY3

        #region int WGL_SWAP_UNDERLAY4
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 4.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY4      0x00080000
        public const int WGL_SWAP_UNDERLAY4 = 0x00080000;
        #endregion int WGL_SWAP_UNDERLAY4

        #region int WGL_SWAP_UNDERLAY5
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 5.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY5      0x00100000
        public const int WGL_SWAP_UNDERLAY5 = 0x00100000;
        #endregion int WGL_SWAP_UNDERLAY5

        #region int WGL_SWAP_UNDERLAY6
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 6.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY6      0x00200000
        public const int WGL_SWAP_UNDERLAY6 = 0x00200000;
        #endregion int WGL_SWAP_UNDERLAY6

        #region int WGL_SWAP_UNDERLAY7
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 7.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY7      0x00400000
        public const int WGL_SWAP_UNDERLAY7 = 0x00400000;
        #endregion int WGL_SWAP_UNDERLAY7

        #region int WGL_SWAP_UNDERLAY8
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 8.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY8      0x00800000
        public const int WGL_SWAP_UNDERLAY8 = 0x00800000;
        #endregion int WGL_SWAP_UNDERLAY8

        #region int WGL_SWAP_UNDERLAY9
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 9.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY9      0x01000000
        public const int WGL_SWAP_UNDERLAY9 = 0x01000000;
        #endregion int WGL_SWAP_UNDERLAY9

        #region int WGL_SWAP_UNDERLAY10
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 10.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY10     0x02000000
        public const int WGL_SWAP_UNDERLAY10 = 0x02000000;
        #endregion int WGL_SWAP_UNDERLAY10

        #region int WGL_SWAP_UNDERLAY11
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 11.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY11     0x04000000
        public const int WGL_SWAP_UNDERLAY11 = 0x04000000;
        #endregion int WGL_SWAP_UNDERLAY11

        #region int WGL_SWAP_UNDERLAY12
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 12.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY12     0x08000000
        public const int WGL_SWAP_UNDERLAY12 = 0x08000000;
        #endregion int WGL_SWAP_UNDERLAY12

        #region int WGL_SWAP_UNDERLAY13
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 13.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY13     0x10000000
        public const int WGL_SWAP_UNDERLAY13 = 0x10000000;
        #endregion int WGL_SWAP_UNDERLAY13

        #region int WGL_SWAP_UNDERLAY14
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 14.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY14     0x20000000
        public const int WGL_SWAP_UNDERLAY14 = 0x20000000;
        #endregion int WGL_SWAP_UNDERLAY14

        #region int WGL_SWAP_UNDERLAY15
        /// <summary>
        ///     <para>
        ///         Swaps the front and back buffers of the underlay plane 15.
        ///     </para>
        /// </summary>
        // #define WGL_SWAP_UNDERLAY15     0x40000000
        public const int WGL_SWAP_UNDERLAY15 = 0x40000000;
        #endregion int WGL_SWAP_UNDERLAY15
        #endregion wglSwapLayerBuffers Flags

        #region wglUseFontOutlines Formats
        #region int WGL_FONT_LINES
        /// <summary>
        ///     <para>
        ///         Fonts with line segments.
        ///     </para>
        /// </summary>
        // #define WGL_FONT_LINES      0
        public const int WGL_FONT_LINES = 0;
        #endregion int WGL_FONT_LINES

        #region int WGL_FONT_POLYGONS
        /// <summary>
        ///     <para>
        ///         Fonts with polygons.
        ///     </para>
        /// </summary>
        // #define WGL_FONT_POLYGONS   1
        public const int WGL_FONT_POLYGONS = 1;
        #endregion int WGL_FONT_POLYGONS
        #endregion wglUseFontOutlines Formats
        #endregion Public Constants

        // --- Constructors & Destructors ---
        #region Wgl()
        /// <summary>
        ///     Prevents instantiation.
        /// </summary>
        private Wgl() {
        }
        #endregion Wgl()

        // --- Public Externs ---
        #region bool wglCopyContext(IntPtr source, IntPtr destination, int mask)
        /// <summary>
        ///     <para>
        ///         The <b>wglCopyContext</b> function copies selected groups of rendering
        ///         states from one OpenGL rendering context to another.
        ///     </para>
        /// </summary>
        /// <param name="source">
        ///     <para>
        ///         Specifies the source OpenGL rendering context whose state information is to
        ///         be copied.
        ///     </para>
        /// </param>
        /// <param name="destination">
        ///     <para>
        ///         Specifies the destination OpenGL rendering context to which state information
        ///         is to be copied.
        ///     </para>
        /// </param>
        /// <param name="mask">
        ///     <para>
        ///         Specifies which groups of the <i>source</i> rendering state are to be copied
        ///         to <i>destination</i>.  It contains the bitwise-OR of the same symbolic names
        ///         that are passed to the <see cref="Tao.OpenGl.Gl.glPushAttrib" /> function.
        ///         You can use <see cref="Tao.OpenGl.Gl.GL_ALL_ATTRIB_BITS" /> to copy all the
        ///         rendering state information.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is true.  If the function fails,
        ///         the return value is false.  To get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         Using the <b>wglCopyContext</b> function, you can synchronize the rendering
        ///         state of two rendering contexts.  You can only copy the rendering state
        ///         between two rendering contexts within the same process.  The rendering
        ///         contexts must be from the same OpenGL implementation.  For example, you can
        ///         always copy a rendering state between two rendering contexts with identical
        ///         pixel format in the same process.
        ///     </para>
        ///     <para>
        ///         You can copy the same state information available only with the
        ///         <see cref="Tao.OpenGl.Gl.glPushAttrib" /> function.  You cannot copy some
        ///         state information, such as pixel pack/unpack state, render mode state, select
        ///         state, and feedback state.  When you call <b>wglCopyContext</b>, make sure
        ///         that the destination rendering context, <i>destination</i>, is not current to
        ///         any thread.
        ///     </para>
        /// </remarks>
        /// <seealso cref="Tao.OpenGl.Gl.glPushAttrib" />
        /// <seealso cref="wglCreateContext" />
        /// <seealso cref="wglCreateLayerContext" />
        /// <seealso cref="wglShareLists" />
        // WINGDIAPI BOOL  WINAPI wglCopyContext(HGLRC, HGLRC, UINT);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglCopyContext(IntPtr source, IntPtr destination, int mask);
        #endregion bool wglCopyContext(IntPtr source, IntPtr destination, int mask)

        #region IntPtr wglCreateContext(IntPtr deviceContext)
        /// <summary>
        ///     <para>
        ///         The <b>wglCreateContext</b> function creates a new OpenGL rendering context,
        ///         which is suitable for drawing on the device referenced by
        ///         <i>deviceContext</i>.  The rendering context has the same pixel format as
        ///         the device context.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Handle to a device context for which the function creates a suitable OpenGL
        ///         rendering context.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is a valid handle to an OpenGL
        ///         rendering context.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is <see cref="IntPtr.Zero"/>.  To get
        ///         extended error information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         A rendering context is not the same as a device context.  Set the pixel
        ///         format of the device context before creating a rendering context.  For more
        ///         information on setting the device context's pixel format, see the
        ///         <see cref="Gdi.SetPixelFormat" /> function.
        ///     </para>
        ///     <para>
        ///         To use OpenGL, you create a rendering context, select it as a thread's
        ///         current rendering context, and then call OpenGL functions.  When you are
        ///         finished with the rendering context, you dispose of it by calling the
        ///         <see cref="wglDeleteContext" /> function.
        ///     </para>
        ///     <para>
        ///         The following code example shows <b>wglCreateContext</b> usage:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             IntPtr hdc;
        ///             IntPtr hglrc;
        ///
        ///             // create a device context
        ///
        ///             // create a rendering context
        ///             hglrc = Wgl.wglCreateContext(hdc);
        ///
        ///             // make it the calling thread's current rendering context
        ///             Wgl.wglMakeCurrent(hdc, hglrc);
        ///
        ///             // call OpenGL APIs as desired...
        ///
        ///             // when the rendering context is no longer needed...
        ///
        ///             // make the rendering context not current
        ///             Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
        ///
        ///             // delete the rendering context
        ///             Wgl.wglDeleteContext(hglrc);
        ///         </code>
        ///     </para>
        /// </remarks>
        /// <seealso cref="Gdi.SetPixelFormat" />
        /// <seealso cref="wglDeleteContext" />
        /// <seealso cref="wglGetCurrentContext" />
        /// <seealso cref="wglGetCurrentDC" />
        /// <seealso cref="wglMakeCurrent" />
        // WINGDIAPI HGLRC WINAPI wglCreateContext(HDC);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr wglCreateContext(IntPtr deviceContext);
        #endregion IntPtr wglCreateContext(IntPtr deviceContext)

        #region IntPtr wglCreateLayerContext(IntPtr deviceContext, int layerPlane)
        /// <summary>
        ///     <para>
        ///         The <b>wglCreateLayerContext</b> function creates a new OpenGL rendering
        ///         context for drawing to a specified layer plane on a device context.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context for a new rendering context.
        ///     </para>
        /// </param>
        /// <param name="layerPlane">
        ///     <para>
        ///         Specifies the layer plane to which you want to bind a rendering context.  The
        ///         value 0 identifies the main plane.  Positive values of <i>layerPlane</i>
        ///         identify overlay planes, where 1 is the first overlay plane over the main
        ///         plane, 2 is the second overlay plane over the first overlay plane, and so on.
        ///         Negative values identify underlay planes, where –1 is the first underlay
        ///         plane under the main plane, –2 is the second underlay plane under the first
        ///         underlay plane, and so on.  The number of overlay and underlay planes is
        ///         given in the <b>bReserved</b> member of the
        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is a handle to an OpenGL rendering
        ///         context.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is <see cref="IntPtr.Zero"/>.  To get
        ///         extended error information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         A rendering context is a port through which all OpenGL commands pass.  Every
        ///         thread that makes OpenGL calls must have one current, active rendering
        ///         context.  A rendering context is not the same as a device context; a
        ///         rendering context contains information specific to OpenGL, while a device
        ///         context contains information specific to GDI.
        ///     </para>
        ///     <para>
        ///         Before you create a rendering context, set the pixel format of the device
        ///         context with the <see cref="Gdi.SetPixelFormat" /> function.  You can use a
        ///         rendering context in a specified layer plane of a window with identical pixel
        ///         formats only.
        ///     </para>
        ///     <para>
        ///         With OpenGL applications that use multiple threads, you create a rendering
        ///         context, select it as the current rendering context of a thread, and make
        ///         OpenGL calls for the specified thread.  When you are finished with the
        ///         rendering context of the thread, call the
        ///         <see cref="Wgl.wglDeleteContext" /> function.
        ///     </para>
        ///     <para>
        ///         The following code example shows how to use <b>wglCreateLayerContext</b>.
        ///     </para>
        ///     <para>
        ///         <code>
        ///             // The following code fragment shows how to render to overlay 1
        ///             // This example assumes that the pixel format of hdc includes
        ///             // overlay plane 1
        ///
        ///             IntPtr hdc;
        ///             IntPtr hglrc;
        ///
        ///             // create a rendering context for overlay plane 1
        ///             hglrc = Wgl.wglCreateLayerContext(hdc, 1);
        ///
        ///             // make it the calling thread's current rendering context
        ///             Wgl.wglMakeCurrent(hdc, hglrc);
        ///
        ///             // call OpenGL functions here...
        ///
        ///             // when the rendering context is no longer needed...
        ///
        ///             // make the rendering context not current
        ///             Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
        ///
        ///             // delete the rendering context
        ///             Wgl.wglDeleteContext(hglrc);
        ///         </code>
        ///     </para>
        /// </remarks>
        /// <seealso cref="Gdi.PIXELFORMATDESCRIPTOR" />
        /// <seealso cref="Gdi.SetPixelFormat" />
        /// <seealso cref="wglCreateContext" />
        /// <seealso cref="wglDeleteContext" />
        /// <seealso cref="wglGetCurrentContext" />
        /// <seealso cref="wglGetCurrentDC" />
        /// <seealso cref="wglMakeCurrent" />
        // WINGDIAPI HGLRC WINAPI wglCreateLayerContext(HDC, int);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr wglCreateLayerContext(IntPtr deviceContext, int layerPlane);
        #endregion IntPtr wglCreateLayerContext(IntPtr deviceContext, int layerPlane)

        #region bool wglDeleteContext(IntPtr renderingContext)
        /// <summary>
        ///     <para>
        ///         The <b>wglDeleteContext</b> function deletes a specified OpenGL rendering
        ///         context.
        ///     </para>
        /// </summary>
        /// <param name="renderingContext">
        ///     <para>
        ///         Handle to an OpenGL rendering context that the function will delete.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is true.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is false.  To get extended error
        ///         information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         It is an error to delete an OpenGL rendering context that is the current
        ///         context of another thread.  However, if a rendering context is the calling
        ///         thread's current context, the <b>wglDeleteContext</b> function changes the
        ///         rendering context to being not current before deleting it.
        ///     </para>
        ///     <para>
        ///         The <b>wglDeleteContext</b> function does not delete the device context
        ///         associated with the OpenGL rendering context when you call the
        ///         <b>wglMakeCurrent</b> function.  After calling <b>wglDeleteContext</b>, you
        ///         must call <see cref="Gdi.DeleteDC" /> to delete the associated device context.
        ///     </para>
        /// </remarks>
        /// <seealso cref="Gdi.DeleteDC" />
        /// <seealso cref="wglCreateContext" />
        /// <seealso cref="wglGetCurrentContext" />
        /// <seealso cref="wglGetCurrentDC" />
        /// <seealso cref="wglMakeCurrent" />
        // WINGDIAPI BOOL WINAPI wglDeleteContext(HGLRC);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglDeleteContext(IntPtr renderingContext);
        #endregion bool wglDeleteContext(IntPtr renderingContext)

        // TODO: Remember why I commented this out... :)

//        #region bool wglDescribeLayerPlane(IntPtr deviceContext, int pixelFormat, int layerPlane, int size, ref Gdi.LAYERPLANEDESCRIPTOR layerPlaneDescriptor)
//        /// <summary>
//        ///     <para>
//        ///         The <b>wglDescribeLayerPlane</b> function obtains information about the layer
//        ///         planes of a given pixel format.
//        ///     </para>
//        /// </summary>
//        /// <param name="deviceContext">
//        ///     <para>
//        ///         Specifies the device context of a window whose layer planes are to be described.
//        ///     </para>
//        /// </param>
//        /// <param name="pixelFormat">
//        ///     <para>
//        ///         Specifies which layer planes of a pixel format are being described.
//        ///     </para>
//        /// </param>
//        /// <param name="layerPlane">
//        ///     <para>
//        ///         Specifies the overlay or underlay plane.  Positive values of
//        ///         <i>layerPlane</i> identify overlay planes, where 1 is the first overlay plane
//        ///         over the main plane, 2 is the second overlay plane over the first overlay
//        ///         plane, and so on.  Negative values identify underlay planes, where –1 is the
//        ///         first underlay plane under the main plane, –2 is the second underlay plane
//        ///         under the first underlay plane, and so on.  The number of overlay and
//        ///         underlay planes is given in the <b>bReserved</b> member of the
//        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure.
//        ///     </para>
//        /// </param>
//        /// <param name="size">
//        ///     <para>
//        ///         Specifies the size, in bytes, of the structure pointed to by
//        ///         <i>layerPlaneDescriptor</i>.  The <b>wglDescribeLayerPlane</b> function
//        ///         stores layer plane data in a <see cref="Gdi.LAYERPLANEDESCRIPTOR" />
//        ///         structure, and stores no more than <i>size</i> of data.  Set the value of
//        ///         <i>size</i> to the size of <see cref="Gdi.LAYERPLANEDESCRIPTOR" />.
//        ///     </para>
//        /// </param>
//        /// <param name="layerPlaneDescriptor">
//        ///     <para>
//        ///         Points to a <see cref="Gdi.LAYERPLANEDESCRIPTOR" /> structure.  The
//        ///         <b>wglDescribeLayerPlane</b> function sets the value of the structure's data
//        ///         members.  The function stores the number of bytes of data copied to the
//        ///         structure in the <b>nSize</b> member.
//        ///     </para>
//        /// </param>
//        /// <returns>
//        ///     <para>
//        ///         If the function succeeds, the return value is true.  In addition, the
//        ///         <b>wglDescribeLayerPlane</b> function sets the members of the
//        ///         <see cref="Gdi.LAYERPLANEDESCRIPTOR" /> structure pointed to by
//        ///         <i>layerPlaneDescriptor</i> according to the specified layer plane
//        ///         (<i>layerPlane</i>) of the specified pixel format (<i>pixelFormat</i>).
//        ///     </para>
//        ///     <para>
//        ///         If the function fails, the return value is false.
//        ///     </para>
//        /// </returns>
//        /// <remarks>
//        ///     <para>
//        ///         The numbering of planes (<i>layerPlane</i>) determines their order.
//        ///         Higher-numbered planes overlay lower-numbered planes.
//        ///     </para>
//        /// </remarks>
//        /// <seealso cref="Gdi.DescribePixelFormat" />
//        /// <seealso cref="Gdi.LAYERPLANEDESCRIPTOR" />
//        /// <seealso cref="Gdi.PIXELFORMATDESCRIPTOR" />
//        /// <seealso cref="Wgl.wglCreateLayerContext" />
//        // WINGDIAPI BOOL  WINAPI wglDescribeLayerPlane(HDC, int, int, UINT, LPLAYERPLANEDESCRIPTOR);
//        [DllImport(WGL_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
//        public static extern bool wglDescribeLayerPlane(IntPtr deviceContext, int pixelFormat, int layerPlane, int size, ref Gdi.LAYERPLANEDESCRIPTOR layerPlaneDescriptor);
//        #endregion bool wglDescribeLayerPlane(IntPtr deviceContext, int pixelFormat, int layerPlane, int size, ref Gdi.LAYERPLANEDESCRIPTOR layerPlaneDescriptor)

        #region IntPtr wglGetCurrentContext()
        /// <summary>
        ///     <para>
        ///         The <b>wglGetCurrentContext</b> function obtains a handle to the current
        ///         OpenGL rendering context of the calling thread.
        ///     </para>
        /// </summary>
        /// <returns>
        ///     <para>
        ///         If the calling thread has a current OpenGL rendering context,
        ///         <b>wglGetCurrentContext</b> returns a handle to that rendering context.
        ///         Otherwise, the return value is <see cref="IntPtr.Zero" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The current OpenGL rendering context of a thread is associated with a device
        ///         context by means of the <see cref="wglMakeCurrent" /> function.  You can use
        ///         the <see cref="wglGetCurrentDC" /> function to obtain a handle to the device
        ///         context associated with the current OpenGL rendering context.
        ///     </para>
        /// </remarks>
        /// <seealso cref="wglCreateContext" />
        /// <seealso cref="wglDeleteContext" />
        /// <seealso cref="wglGetCurrentDC" />
        /// <seealso cref="wglMakeCurrent" />
        // WINGDIAPI HGLRC WINAPI wglGetCurrentContext(VOID);
        [DllImport(WGL_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr wglGetCurrentContext();
        #endregion IntPtr wglGetCurrentContext()

        #region IntPtr wglGetCurrentDC()
        /// <summary>
        ///     <para>
        ///         The <b>wglGetCurrentDC</b> function obtains a handle to the device context
        ///         that is associated with the current OpenGL rendering context of the calling
        ///         thread.
        ///     </para>
        /// </summary>
        /// <returns>
        ///     <para>
        ///         If the calling thread has a current OpenGL rendering context, the function
        ///         returns a handle to the device context associated with that rendering context
        ///         by means of the <see cref="wglMakeCurrent" /> function.  Otherwise, the
        ///         return value is <see cref="IntPtr.Zero" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         You associate a device context with an OpenGL rendering context when it calls
        ///         the <see cref="wglMakeCurrent" /> function.  You can use the
        ///         <see cref="wglGetCurrentContext" /> function to obtain a handle to the
        ///         calling thread's current OpenGL rendering context.
        ///     </para>
        /// </remarks>
        /// <seealso cref="wglCreateContext" />
        /// <seealso cref="wglDeleteContext" />
        /// <seealso cref="wglGetCurrentContext" />
        /// <seealso cref="wglMakeCurrent" />
        // WINGDIAPI HDC   WINAPI wglGetCurrentDC(VOID);
        [DllImport(WGL_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr wglGetCurrentDC();
        #endregion IntPtr wglGetCurrentDC()

        #region int wglGetLayerPaletteEntries(IntPtr deviceContext, int layerPlane, int start, int entries, int[] colors)
        /// <summary>
        ///     <para>
        ///         The <b>wglGetLayerPaletteEntries</b> function retrieves the palette entries
        ///         from a given color-index layer plane for a specified device context.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context of a window whose layer planes are to be
        ///         described.
        ///     </para>
        /// </param>
        /// <param name="layerPlane">
        ///     <para>
        ///         Specifies the overlay or underlay plane.  Positive values of
        ///         <i>layerPlane</i> identify overlay planes, where 1 is the first overlay plane
        ///         over the main plane, 2 is the second overlay plane over the first overlay
        ///         plane, and so on.  Negative values identify underlay planes, where –1 is the
        ///         first underlay plane under the main plane, –2 is the second underlay plane
        ///         under the first underlay plane, and so on.  The number of overlay and
        ///         underlay planes is given in the <b>bReserved</b> member of the
        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure.
        ///     </para>
        /// </param>
        /// <param name="start">
        ///     <para>
        ///         Specifies the first palette entry to be retrieved.
        ///     </para>
        /// </param>
        /// <param name="entries">
        ///     <para>
        ///         Specifies the number of palette entries to be retrieved.
        ///     </para>
        /// </param>
        /// <param name="colors">
        ///     <para>
        ///         Points to an array of <see cref="int" />'s that contain palette RGB color
        ///         values.  The array must contain at least as many structures as specified by
        ///         <i>entries</i>.
        ///     </para>
        ///     <para>
        ///         The color values should be a RGB value as an int in the hexidecimal form
        ///         of 0x00bbggrr.  The low-order byte contains a value for the relative
        ///         intensity of red; the second byte contains a value for green; and the third
        ///         byte contains a value for blue.  The high-order byte must be zero.  The
        ///         maximum value for a single byte is 0xFF.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is the number of entries that were
        ///         set in the palette in the specified layer plane of the window.
        ///     </para>
        ///     <para>
        ///         If the function fails or when no pixel format is selected, the return value
        ///         is zero.  To get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         Each color-index layer plane in a window has a palette with a size 2^n, where
        ///         n is the number of bit planes in the layer plane.  You cannot modify the
        ///         transparent index of a palette.
        ///     </para>
        ///     <para>
        ///         Use the <see cref="wglRealizeLayerPalette" /> function to realize the layer
        ///         palette.  Initially the layer palette contains only entries for white.
        ///     </para>
        ///     <para>
        ///         The <see cref="wglSetLayerPaletteEntries" /> function doesn't set the palette
        ///         entries of the main plane palette.  To update the main plane palette, use
        ///         GDI palette functions.
        ///     </para>
        /// </remarks>
        /// <seealso cref="Gdi.LAYERPLANEDESCRIPTOR" />
        /// <seealso cref="Gdi.PIXELFORMATDESCRIPTOR" />
        /// <seealso cref="wglDescribeLayerPlane" />
        /// <seealso cref="wglRealizeLayerPalette" />
        /// <seealso cref="wglSetLayerPaletteEntries" />
        // WINGDIAPI int WINAPI wglGetLayerPaletteEntries(HDC, int, int, int, COLORREF *);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern int wglGetLayerPaletteEntries(IntPtr deviceContext, int layerPlane, int start, int entries, int[] colors);
        #endregion int wglGetLayerPaletteEntries(IntPtr deviceContext, int layerPlane, int start, int entries, int[] colors)

        #region IntPtr wglGetProcAddress(string extension)
        /// <summary>
        ///     <para>
        ///         The <b>wglGetProcAddress</b> function returns the address of an OpenGL
        ///         extension function for use with the current OpenGL rendering context.
        ///     </para>
        /// </summary>
        /// <param name="extension">
        ///     <para>
        ///         Points to a null-terminated string that is the name of the extension
        ///         function.  The name of the extension function must be identical to a
        ///         corresponding function implemented by OpenGL.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         When the function succeeds, the return value is the address of the extension
        ///         function.
        ///     </para>
        ///     <para>
        ///         When no current rendering context exists or the function fails, the return
        ///         value is <see cref="IntPtr.Zero" />.  To get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The OpenGL library supports multiple implementations of its functions.
        ///         Extension functions supported in one rendering context are not necessarily
        ///         available in a separate rendering context.  Thus, for a given rendering
        ///         context in an application, use the function addresses returned by the
        ///         <b>wglGetProcAddress</b> function only.
        ///     </para>
        ///     <para>
        ///         The spelling and the case of the extension function pointed to by
        ///         <i>extension</i> must be identical to that of a function supported and
        ///         implemented by OpenGL.  Because extension functions are not exported by
        ///         OpenGL, you must use <b>wglGetProcAddress</b> to get the addresses of
        ///         vendor-specific extension functions.
        ///     </para>
        ///     <para>
        ///         The extension function addresses are unique for each pixel format.  All
        ///         rendering contexts of a given pixel format share the same extension function
        ///         addresses.
        ///     </para>
        /// </remarks>
        /// <seealso cref="Tao.OpenGl.Gl.glGetString" />
        /// <seealso cref="wglMakeCurrent" />
        // WINGDIAPI PROC  WINAPI wglGetProcAddress(LPCSTR);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr wglGetProcAddress(string extension);
        #endregion IntPtr wglGetProcAddress(string extension)

        #region bool wglMakeCurrent(IntPtr deviceContext, IntPtr renderingContext)
        /// <summary>
        ///     <para>
        ///         The <b>wglMakeCurrent</b> function makes a specified OpenGL rendering context
        ///         the calling thread's current rendering context.  All subsequent OpenGL calls
        ///         made by the thread are drawn on the device identified by <i>deviceContext</i>.
        ///         You can also use <b>wglMakeCurrent</b> to change the calling thread's current
        ///         rendering context so it's no longer current.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Handle to a device context.  Subsequent OpenGL calls made by the calling
        ///         thread are drawn on the device identified by <i>deviceContext</i>.
        ///     </para>
        /// </param>
        /// <param name="renderingContext">
        ///     <para>
        ///         Handle to an OpenGL rendering context that the function sets as the calling
        ///         thread's rendering context.
        ///     </para>
        ///     <para>
        ///         If <i>rendingContext</i> is <see cref="IntPtr.Zero" />, the function makes
        ///         the calling thread's current rendering context no longer current, and
        ///         releases the device context that is used by the rendering context.  In this
        ///         case, <i>deviceContext</i> is ignored.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         When the <b>wglMakeCurrent</b> function succeeds, the return value is true;
        ///         otherwise the return value is false.  To get extended error information,
        ///         call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The <i>deviceContext</i> parameter must refer to a drawing surface supported
        ///         by OpenGL.  It need not be the same <i>deviceContext</i> that was passed to
        ///         <see cref="wglCreateContext" /> when <i>renderingContext</i> was created, but
        ///         it must be on the same device and have the same pixel format.  GDI
        ///         transformation and clipping in <i>deviceContext</i> are not supported by the
        ///         rendering context.  The current rendering context uses the
        ///         <i>deviceContext</i> device context until the rendering context is no longer
        ///         current.
        ///     </para>
        ///     <para>
        ///         Before switching to the new rendering context, OpenGL flushes any previous
        ///         rendering context that was current to the calling thread.
        ///     </para>
        ///     <para>
        ///         A thread can have one current rendering context.  A process can have multiple
        ///         rendering contexts by means of multithreading.  A thread must set a current
        ///         rendering context before calling any OpenGL functions.  Otherwise, all OpenGL
        ///         calls are ignored.
        ///     </para>
        ///     <para>
        ///         A rendering context can be current to only one thread at a time.  You cannot
        ///         make a rendering context current to multiple threads.
        ///     </para>
        ///     <para>
        ///         An application can perform multithread drawing by making different rendering
        ///         contexts current to different threads, supplying each thread with its own
        ///         rendering context and device context.
        ///     </para>
        ///     <para>
        ///         If an error occurs, the <b>wglMakeCurrent</b> function makes the thread's
        ///         current rendering context not current before returning.
        ///     </para>
        /// </remarks>
        /// <seealso cref="wglCreateContext" />
        /// <seealso cref="wglDeleteContext" />
        /// <seealso cref="wglGetCurrentContext" />
        /// <seealso cref="wglGetCurrentDC" />
        // WINGDIAPI BOOL WINAPI wglMakeCurrent(HDC, HGLRC);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglMakeCurrent(IntPtr deviceContext, IntPtr renderingContext);
        #endregion bool wglMakeCurrent(IntPtr deviceContext, IntPtr renderingContext)

        #region bool wglRealizeLayerPalette(IntPtr deviceContext, int layerPlane, bool realize)
        /// <summary>
        ///     <para>
        ///         The <b>wglRealizeLayerPalette</b> function maps palette entries from a given
        ///         color-index layer plane into the physical palette or initializes the palette
        ///         of an RGBA layer plane.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context of a window whose layer plane palette is to be
        ///         realized into the physical palette.
        ///     </para>
        /// </param>
        /// <param name="layerPlane">
        ///     <para>
        ///         Specifies the overlay or underlay plane.  Positive values of
        ///         <i>layerPlane</i> identify overlay planes, where 1 is the first overlay plane
        ///         over the main plane, 2 is the second overlay plane over the first overlay
        ///         plane, and so on.  Negative values identify underlay planes, where –1 is the
        ///         first underlay plane under the main plane, –2 is the second underlay plane
        ///         under the first underlay plane, and so on.  The number of overlay and
        ///         underlay planes is given in the <b>bReserved</b> member of the
        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure.
        ///     </para>
        /// </param>
        /// <param name="realize">
        ///     <para>
        ///         Indicates whether the palette is to be realized into the physical palette.
        ///         When <i>realize</i> is true, the palette entries are mapped into the physical
        ///         palette where available.  When <i>realize</i> is false, the palette entries
        ///         for the layer plane of the window are no longer needed and might be released
        ///         for use by another foreground window.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is true, even if <i>realize</i> is
        ///         true and the physical palette is not available.  If the function fails or
        ///         when no pixel format is selected, the return value is false.  To get extended
        ///         error information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The physical palette for a layer plane is a shared resource among windows
        ///         with layer planes.  When more than one window attempts to realize a palette
        ///         for a given physical layer plane, only one palette at a time is realized.
        ///         When you call the <b>wglRealizeLayerPalette</b> function, the layer palette
        ///         of a foreground window is always realized first.
        ///     </para>
        ///     <para>
        ///         When a window's layer palette is realized, its palette entries are always
        ///         mapped one-to-one into the physical palette.  Unlike GDI logical palettes,
        ///         with <b>wglRealizeLayerPalette</b> there is no mapping of other windows'
        ///         layer palettes to the current physical palette.
        ///     </para>
        ///     <para>
        ///         Whenever a window becomes the foreground window, call
        ///         <b>wglRealizeLayerPalette</b> to realize its layer palettes again, even if
        ///         the pixel type of the layer plane is RGBA.
        ///     </para>
        ///     <para>
        ///         Because <b>wglRealizeLayerPalette</b> doesn't realize the palette of the
        ///         main plane, use GDI palette functions to realize the main plane palette.
        ///     </para>
        /// </remarks>
        /// <seealso cref="Gdi.LAYERPLANEDESCRIPTOR" />
        /// <seealso cref="Gdi.PIXELFORMATDESCRIPTOR" />
        /// <seealso cref="wglDescribeLayerPlane" />
        /// <seealso cref="wglGetLayerPaletteEntries" />
        /// <seealso cref="wglSetLayerPaletteEntries" />
        // WINGDIAPI BOOL  WINAPI wglRealizeLayerPalette(HDC, int, BOOL);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglRealizeLayerPalette(IntPtr deviceContext, int layerPlane, bool realize);
        #endregion bool wglRealizeLayerPalette(IntPtr deviceContext, int layerPlane, bool realize)

        #region int wglSetLayerPaletteEntries(IntPtr deviceContext, int layerPlane, int start, int entries, int[] colors)
        /// <summary>
        ///     <para>
        ///         The <b>wglSetLayerPaletteEntries</b> function sets the palette entries in a
        ///         given color-index layer plane for a specified device context.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context of a window whose layer palette is to be set.
        ///     </para>
        /// </param>
        /// <param name="layerPlane">
        ///     <para>
        ///         Specifies an overlay or underlay plane.  Positive values of <i>layerPlane</i>
        ///         identify overlay planes, where 1 is the first overlay plane over the main
        ///         plane, 2 is the second overlay plane over the first overlay plane, and so on.
        ///         Negative values identify underlay planes, where –1 is the first underlay
        ///         plane under the main plane, –2 is the second underlay plane under the first
        ///         underlay plane, and so on.  The number of overlay and underlay planes is
        ///         given in the <b>bReserved</b> member of the
        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure.
        ///     </para>
        /// </param>
        /// <param name="start">
        ///     <para>
        ///         Specifies the first palette entry to be set.
        ///     </para>
        /// </param>
        /// <param name="entries">
        ///     <para>
        ///         Specifies the number of palette entries to be set.
        ///     </para>
        /// </param>
        /// <param name="colors">
        ///     <para>
        ///         Points to an array of <see cref="int" />'s that contain palette RGB color
        ///         values.  The array must contain at least as many structures as specified by
        ///         <i>entries</i>.
        ///     </para>
        ///     <para>
        ///         The color values should be a RGB value as an int in the hexidecimal form
        ///         of 0x00bbggrr.  The low-order byte contains a value for the relative
        ///         intensity of red; the second byte contains a value for green; and the third
        ///         byte contains a value for blue.  The high-order byte must be zero.  The
        ///         maximum value for a single byte is 0xFF.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is the number of entries that were
        ///         set in the palette in the specified layer plane of the window.  If the
        ///         function fails or no pixel format is selected, the return value is zero.  To
        ///         get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         Each color-index plane in a window has a palette with a size 2^n, where n is
        ///         the number of bit planes in the layer plane.  You cannot modify the
        ///         transparent index of a palette.
        ///     </para>
        ///     <para>
        ///         Use the <see cref="wglRealizeLayerPalette" /> function to realize the layer
        ///         palette.  Initially the layer palette contains only entries for white.
        ///     </para>
        ///     <para>
        ///         The <b>wglSetLayerPaletteEntries</b> function doesn't set the palette entries
        ///         of the main plane palette.  To update the main plane palette, use GDI palette
        ///         functions.
        ///     </para>
        /// </remarks>
        /// <seealso cref="Gdi.LAYERPLANEDESCRIPTOR" />
        /// <seealso cref="Gdi.PIXELFORMATDESCRIPTOR" />
        /// <seealso cref="wglDescribeLayerPlane" />
        /// <seealso cref="wglGetLayerPaletteEntries" />
        /// <seealso cref="wglRealizeLayerPalette" />
        // WINGDIAPI int WINAPI wglSetLayerPaletteEntries(HDC, int, int, int, CONST COLORREF *);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern int wglSetLayerPaletteEntries(IntPtr deviceContext, int layerPlane, int start, int entries, int[] colors);
        #endregion int wglSetLayerPaletteEntries(IntPtr deviceContext, int layerPlane, int start, int entries, int[] colors)

        #region bool wglShareLists(IntPtr source, IntPtr destination)
        /// <summary>
        ///     <para>
        ///         The <b>wglShareLists</b> function enables multiple OpenGL rendering contexts
        ///         to share a single display-list space.
        ///     </para>
        /// </summary>
        /// <param name="source">
        ///     <para>
        ///         Specifies the OpenGL rendering context with which to share display lists.
        ///     </para>
        /// </param>
        /// <param name="destination">
        ///     <para>
        ///         Specifies the OpenGL rendering context to share display lists with
        ///         <i>source</i>.  The <i>destination</i> parameter should not contain any
        ///         existing display lists when <b>wglShareLists</b> is called.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         When the function succeeds, the return value is true.
        ///     </para>
        ///     <para>
        ///         When the function fails, the return value is false and the display lists are
        ///         not shared.  To get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         When you create an OpenGL rendering context, it has its own display-list
        ///         space.  The <b>wglShareLists</b> function enables a rendering context to
        ///         share the display-list space of another rendering context; any number of
        ///         rendering contexts can share a single display-list space.  Once a rendering
        ///         context shares a display-list space, the rendering context always uses the
        ///         display-list space until the rendering context is deleted.  When the last
        ///         rendering context of a shared display-list space is deleted, the shared
        ///         display-list space is deleted.  All the indexes and definitions of display
        ///         lists in a shared display-list space are shared.
        ///     </para>
        ///     <para>
        ///         You can only share display lists with rendering contexts within the same
        ///         process.  However, not all rendering contexts in a process can share display
        ///         lists.  Rendering contexts can share display lists only if they use the same
        ///         implementation of OpenGL functions.  All client rendering contexts of a given
        ///         pixel format can always share display lists.
        ///     </para>
        ///     <para>
        ///         All rendering contexts of a shared display list must use an identical pixel
        ///         format.  Otherwise the results depend on the implementation of OpenGL used.
        ///     </para>
        ///     <para>
        ///         <b>NOTE</b>
        ///     </para>
        ///     <para>
        ///         The <b>wglShareLists</b> function is only available with OpenGL version 1.01
        ///         or later.  To determine the version number of the implementation of OpenGL,
        ///         call <see cref="Tao.OpenGl.Gl.glGetString" />.
        ///     </para>
        /// </remarks>
        /// <seealso cref="Tao.OpenGl.Gl.glGetString" />
        // WINGDIAPI BOOL  WINAPI wglShareLists(HGLRC, HGLRC);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglShareLists(IntPtr source, IntPtr destination);
        #endregion bool wglShareLists(IntPtr source, IntPtr destination)

        #region bool wglSwapLayerBuffers(IntPtr deviceContext, int planes)
        /// <summary>
        ///     <para>
        ///         The <b>wglSwapLayerBuffers</b> function swaps the front and back buffers in
        ///         the overlay, underlay, and main planes of the window referenced by a
        ///         specified device context.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context of a window whose layer plane palette is to be
        ///         realized into the physical palette.
        ///     </para>
        /// </param>
        /// <param name="planes">
        ///     <para>
        ///         Specifies the overlay, underlay, and main planes whose front and back buffers
        ///         are to be swapped.  The <b>bReserved</b> member of the
        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure specifies the number of
        ///         overlay and underlay planes.  The <i>planes</i> parameter is a bitwise
        ///         combination of the following values:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Meaning</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>WGL_SWAP_MAIN_PLANE</term>
        ///                 <description>
        ///                     Swaps the front and back buffers of the main plane.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>WGL_SWAP_OVERLAYi</term>
        ///                 <description>
        ///                     Swaps the front and back buffers of the overlay plane i, where
        ///                     i is an integer between 1 and 15.  WGL_SWAP_OVERLAY1 identifies
        ///                     the first overlay plane over the main plane, WGL_SWAP_OVERLAY2
        ///                     identifies the second overlay plane over the first overlay plane,
        ///                     and so on.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>WGL_SWAP_UNDERLAYi</term>
        ///                 <description>
        ///                     Swaps the front and back buffers of the underlay plane i, where i
        ///                     is an integer between 1 and 15.  WGL_SWAP_UNDERLAY1 identifies
        ///                     the first underlay plane under the main plane, WGL_SWAP_UNDERLAY2
        ///                     identifies the second underlay plane under the first underlay
        ///                     plane, and so on.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is true.  If the function fails,
        ///         the return value is false.  To get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         When a layer plane doesn't include a back buffer, calling the
        ///         <b>wglSwapLayerBuffers</b> function has no effect on that layer plane.  After
        ///         you call <b>wglSwapLayerBuffers</b>, the state of the back buffer content is
        ///         given in the corresponding <see cref="Gdi.LAYERPLANEDESCRIPTOR" /> structure
        ///         of the layer plane or in the <see cref="Gdi.PIXELFORMATDESCRIPTOR" />
        ///         structure of the main plane.  The <b>wglSwapLayerBuffers</b> function swaps
        ///         the front and back buffers in the specified layer planes simultaneously.
        ///     </para>
        ///     <para>
        ///         Some devices don't support swapping layer planes individually; they swap all
        ///         layer planes as a group.  When the <b>PFD_SWAP_LAYER_BUFFERS</b> flag of the
        ///         <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure is set, it indicates that
        ///         a device can swap individual layer planes and that you can call
        ///         <b>wglSwapLayerBuffers</b>.
        ///     </para>
        ///     <para>
        ///         With applications that use multiple threads, before calling
        ///         <b>wglSwapLayerBuffers</b>, clear all drawing commands in all threads drawing
        ///         to the same window.
        ///     </para>
        /// </remarks>
        /// <seealso cref="Gdi.LAYERPLANEDESCRIPTOR" />
        /// <seealso cref="Gdi.PIXELFORMATDESCRIPTOR" />
        /// <seealso cref="Gdi.SwapBuffers" />
        // WINGDIAPI BOOL  WINAPI wglSwapLayerBuffers(HDC, UINT);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglSwapLayerBuffers(IntPtr deviceContext, int planes);
        #endregion bool wglSwapLayerBuffers(IntPtr deviceContext, int planes)

        #region bool wglUseFontBitmaps(IntPtr deviceContext, int first, int count, int listBase)
        /// <summary>
        ///     <para>
        ///         The <b>wglUseFontBitmaps</b> function creates a set of bitmap display lists
        ///         for use in the current OpenGL rendering context.  The set of bitmap display
        ///         lists is based on the glyphs in the currently selected font in the device
        ///         context.  You can then use bitmaps to draw characters in an OpenGL image.
        ///     </para>
        ///     <para>
        ///         The <b>wglUseFontBitmaps</b> function creates <i>count</i> display lists,
        ///         one for each of a run of <i>count</i> glyphs that begins with the
        ///         <i>first</i> glyph in the <i>deviceContext</i> parameter's selected fonts.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context whose currently selected font will be used to
        ///         form the glyph bitmap display lists in the current OpenGL rendering context.
        ///     </para>
        /// </param>
        /// <param name="first">
        ///     <para>
        ///         Specifies the first glyph in the run of glyphs that will be used to form
        ///         glyph bitmap display lists.
        ///     </para>
        /// </param>
        /// <param name="count">
        ///     <para>
        ///         Specifies the number of glyphs in the run of glyphs that will be used to
        ///         form glyph bitmap display lists.  The function creates <i>count</i> display
        ///         lists, one for each glyph in the run.
        ///     </para>
        /// </param>
        /// <param name="listBase">
        ///     <para>
        ///         Specifies a starting display list.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is true.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is false.  To get extended error
        ///         information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The <b>wglUseFontBitmaps</b> function defines <i>count</i> display lists in
        ///         the current OpenGL rendering context.  Each display list has an identifying
        ///         number, starting at <i>listBase</i>.  Each display list consists of a single
        ///         call to <see cref="Tao.OpenGl.Gl.glBitmap" />.  The definition of bitmap
        ///         <i>listBase + i</i> is taken from the glyph <i>first + i</i> of the font
        ///         currently selected in the device context specified by <i>deviceContext</i>.
        ///         If a glyph is not defined, then the function defines an empty display list
        ///         for it.
        ///     </para>
        ///     <para>
        ///         The <b>wglUseFontBitmaps</b> function creates bitmap text in the plane of the
        ///         screen.  It enables the labeling of objects in OpenGL.
        ///     </para>
        ///     <para>
        ///         In the current version of Microsoft's implementation of OpenGL in Windows NT
        ///         and Windows 95, you cannot make GDI calls to a device context that has a
        ///         double-buffered pixel format.  Therefore, you cannot use the GDI fonts and
        ///         text functions with such device contexts.  You can use the
        ///         <b>wglUseFontBitmaps</b> function to circumvent this limitation and draw text
        ///         in a double-buffered device context.
        ///     </para>
        ///     <para>
        ///         The function determines the parameters of each call to
        ///         <see cref="Tao.OpenGl.Gl.glBitmap" /> as follows:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>glBitmap Parameter</term>
        ///                 <description>Meaning</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>width</term>
        ///                 <description>
        ///                     The width of the glyph's bitmap, as returned in the
        ///                     <b>gmBlackBoxX</b> member of the glyph's
        ///                     <see cref="Gdi.GLYPHMETRICS" /> structure.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>height</term>
        ///                 <description>
        ///                     The height of the glyph's bitmap, as returned in the
        ///                     <b>gmBlackBoxY</b> member of the glyph's
        ///                     <see cref="Gdi.GLYPHMETRICS" /> structure.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>xorig</term>
        ///                 <description>
        ///                     The x offset of the glyph's origin, as returned in the
        ///                     <b>gmptGlyphOrigin.x</b> member of the glyph's
        ///                     <see cref="Gdi.GLYPHMETRICS" /> structure.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>yorig</term>
        ///                 <description>
        ///                     The y offset of the glyph's origin, as returned in the
        ///                     <b>gmptGlyphOrigin.y</b> member of the glyph's
        ///                     <see cref="Gdi.GLYPHMETRICS" /> structure.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>xmove</term>
        ///                 <description>
        ///                     The horizontal distance to the origin of the next character cell,
        ///                     as returned in the <b>gmCellIncX</b> member of the glyph's
        ///                     <see cref="Gdi.GLYPHMETRICS" /> structure.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>ymove</term>
        ///                 <description>
        ///                     The vertical distance to the origin of the next character cell as
        ///                     returned in the <b>gmCellIncY</b> member of the glyph's
        ///                     <see cref="Gdi.GLYPHMETRICS" /> structure.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>bitmap</term>
        ///                 <description>
        ///                     The bitmap for the glyph, as returned by
        ///                     <see cref="Gdi.GetGlyphOutline" /> with <i>uFormat</i> equal to 1.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         The following code example shows how to use <b>wglUseFontBitmaps</b> to draw
        ///         some text:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             IntPtr hdc;
        ///             IntPtr hglrc;
        ///
        ///             // create a rendering context
        ///             hglrc = Wgl.wglCreateContext(hdc);
        ///
        ///             // make it the calling thread's current rendering context
        ///             Wgl.wglMakeCurrent(hdc, hglrc);
        ///
        ///             // now we can call OpenGL API
        ///
        ///             // make the system font the device context's selected font
        ///             Gdi.SelectObject(hdc, Gdi.GetStockObject(SYSTEM_FONT));
        ///
        ///             // create the bitmap display lists
        ///             // we're making images of glyphs 0 thru 255
        ///             // the display list numbering starts at 1000, an arbitrary choice
        ///             Wgl.wglUseFontBitmaps(hdc, 0, 255, 1000);
        ///
        ///             // display a string:
        ///             // indicate start of glyph display lists
        ///             GL.glListBase(1000);
        ///
        ///             z/ now draw the characters in a string
        ///             GL.glCallLists(24, GL.GL_UNSIGNED_SHORT, "Hello Win32 OpenGL World");
        ///         </code>
        ///     </para>
        /// </remarks>
        /// <seealso cref="Gdi.GetGlyphOutline" />
        /// <seealso cref="Tao.OpenGl.Gl.glBitmap" />
        /// <seealso cref="Tao.OpenGl.Gl.glCallLists" />
        /// <seealso cref="Tao.OpenGl.Gl.glListBase" />
        /// <seealso cref="Gdi.GLYPHMETRICS" />
        /// <seealso cref="Wgl.wglUseFontOutlines" />
        // WINGDIAPI BOOL WINAPI wglUseFontBitmapsA(HDC, DWORD, DWORD, DWORD);
        // WINGDIAPI BOOL WINAPI wglUseFontBitmapsW(HDC, DWORD, DWORD, DWORD);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglUseFontBitmaps(IntPtr deviceContext, int first, int count, int listBase);
        #endregion bool wglUseFontBitmaps(IntPtr deviceContext, int first, int count, int listBase)

        #region bool wglUseFontOutlines(IntPtr deviceContext, int first, int count, int listBase, float deviation, float extrusion, int format, [Out, MarshalAs(UnmanagedType.LPArray)] Gdi.GLYPHMETRICSFLOAT[] glyphMetrics)
        /// <summary>
        ///     <para>
        ///         The <b>wglUseFontOutlines</b> function creates a set of display lists, one
        ///         for each glyph of the currently selected outline font of a device context,
        ///         for use with the current rendering context.  The display lists are used to
        ///         draw 3-D characters of TrueType fonts.  Each display list describes a glyph
        ///         outline in floating-point coordinates.
        ///     </para>
        ///     <para>
        ///         The run of glyphs begins with the <i>first</i> glyph of the font of the
        ///         specified device context.  The em square size of the font, the notional grid
        ///         size of the original font outline from which the font is fitted, is mapped to
        ///         1.0 in the x- and y-coordinates in the display lists.  The <i>extrusion</i>
        ///         parameter sets how much depth the font has in the z direction.
        ///     </para>
        ///     <para>
        ///         The <i>glyphMetrics</i> parameter returns a
        ///         <see cref="Gdi.GLYPHMETRICSFLOAT" /> structure that contains information
        ///         about the placement and orientation of each glyph in a character cell.
        ///     </para>
        /// </summary>
        /// <param name="deviceContext">
        ///     <para>
        ///         Specifies the device context with the desired outline font.  The outline font
        ///         of <i>deviceContext</i> is used to create the display lists in the current
        ///         rendering context.
        ///     </para>
        /// </param>
        /// <param name="first">
        ///     <para>
        ///         Specifies the first of the set of glyphs that form the font outline display
        ///         lists.
        ///     </para>
        /// </param>
        /// <param name="count">
        ///     <para>
        ///         Specifies the number of glyphs in the set of glyphs used to form the font
        ///         outline display lists.  The <b>wglUseFontOutlines</b> function creates
        ///         <i>count</i> display lists, one display list for each glyph in a set of
        ///         glyphs.
        ///     </para>
        /// </param>
        /// <param name="listBase">
        ///     <para>
        ///         Specifies a starting display list.
        ///     </para>
        /// </param>
        /// <param name="deviation">
        ///     <para>
        ///         Specifies the maximum chordal deviation from the original outlines.  When
        ///         <i>deviation</i> is zero, the chordal deviation is equivalent to one design
        ///         unit of the original font.  The value of <i>deviation</i> must be equal to
        ///         or greater than 0.
        ///     </para>
        /// </param>
        /// <param name="extrusion">
        ///     <para>
        ///         Specifies how much a font is extruded in the negative z direction.  The
        ///         value must be equal to or greater than 0.  When <i>extrusion</i> is 0, the
        ///         display lists are not extruded.
        ///     </para>
        /// </param>
        /// <param name="format">
        ///     <para>
        ///         Specifies the format, either <see cref="WGL_FONT_LINES" /> or
        ///         <see cref="WGL_FONT_POLYGONS" />, to use in the display lists.  When
        ///         <i>format</i> is <see cref="WGL_FONT_LINES" />, the
        ///         <b>wglUseFontOutlines</b> function creates fonts with line segments.  When
        ///         <i>format</i> is <see cref="WGL_FONT_POLYGONS" />, <b>wglUseFontOutlines</b>
        ///         creates fonts with polygons.
        ///     </para>
        /// </param>
        /// <param name="glyphMetrics">
        ///     <para>
        ///         Points to an array of <i>count</i> <see cref="Gdi.GLYPHMETRICSFLOAT" />
        ///         structures that is to receive the metrics of the glyphs.  When
        ///         <i>glyphMetrics</i> is null, no glyph metrics are returned.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         When the function succeeds, the return value is true.
        ///     </para>
        ///     <para>
        ///         When the function fails, the return value is false and no display lists are
        ///         generated.  To get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The <b>wglUseFontOutlines</b> function defines the glyphs of an outline font
        ///         with display lists in the current rendering context.  The
        ///         <b>wglUseFontOutlines</b> function works with TrueType fonts only; stroke and
        ///         raster fonts are not supported.
        ///     </para>
        ///     <para>
        ///         Each display list consists of either line segments or polygons, and has a
        ///         unique identifying number starting with the <i>listBase</i> number.
        ///     </para>
        ///     <para>
        ///         The <b>wglUseFontOutlines</b> function approximates glyph outlines by
        ///         subdividing the quadratic B-spline curves of the outline into line segments,
        ///         until the distance between the outline and the interpolated midpoint is
        ///         within the value specified by <i>deviation</i>.  This is the final format
        ///         used when <i>format</i> is <see cref="WGL_FONT_LINES" />.  When you specify
        ///         <see cref="WGL_FONT_LINES" />, the display lists created don't contain any
        ///         normals; thus lighting doesn't work properly.  To get the correct lighting of
        ///         lines use <see cref="WGL_FONT_POLYGONS" /> and set
        ///         <c>Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_LINE)</c>.  When you specify
        ///         <i>format</i> as <see cref="WGL_FONT_POLYGONS" /> the outlines are further
        ///         tessellated into separate triangles, triangle fans, triangle strips, or
        ///         quadrilateral strips to create the surface of each glyph.  With
        ///         <see cref="WGL_FONT_POLYGONS" />, the created display lists call
        ///         <c>Gl.glFrontFace(Gl.GL_CW)</c> or <c>Gl.glFrontFace(Gl.GL_CCW)</c>; thus
        ///         the current front-face value might be altered.  For the best appearance of
        ///         text with <see cref="WGL_FONT_POLYGONS" />, cull the back faces as follows:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             Gl.glCullFace(Gl.GL_BACK);
        ///             Gl.glEnable(Gl.GL_CULL_FACE);
        ///         </code>
        ///     </para>
        ///     <para>
        ///         A <see cref="Gdi.GLYPHMETRICSFLOAT" /> structure contains information about
        ///         the placement and orientation of each glyph in a character cell.  The
        ///         <i>glyphMetrics</i> parameter is an array of
        ///         <see cref="Gdi.GLYPHMETRICSFLOAT" /> structures holding the entire set of
        ///         glyphs for a font.  Each display list ends with a translation specified with
        ///         the <b>gmfCellIncX</b> and <b>gmfCellIncY</b> members of the corresponding
        ///         <see cref="Gdi.GLYPHMETRICSFLOAT" /> structure.  The translation enables the
        ///         drawing of successive characters in their natural direction with a single
        ///         call to <see cref="Tao.OpenGl.Gl.glCallLists" />.
        ///     </para>
        ///     <para>
        ///         <b>NOTE</b>
        ///     </para>
        ///     <para>
        ///         With the current release of OpenGL for Windows NT and Windows 95, you cannot
        ///         make GDI calls to a device context when a pixel format is double-buffered.
        ///         You can work around this limitation by using <b>wglUseFontOutlines</b> and
        ///         <see cref="wglUseFontBitmaps" />, when using double-buffered device contexts.
        ///     </para>
        ///     <para>
        ///         The following code example shows how to draw text using
        ///         <b>wglUseFontOutlines</b>:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             IntPtr hdc;  // A TrueType font has already been selected
        ///             IntPtr hglrc;
        ///             Gdi.GLYPHMETRICSFLOAT[] agmf = new Gdi.GLYPHMETRICSFLOAT[256];
        ///
        ///             // Make hglrc the calling thread's current rendering context
        ///             Wgl.wglMakeCurrent(hdc, hglrc);
        ///
        ///             // create display lists for glyphs 0 through 255 with 0.1 extrusion
        ///             // and default deviation. The display list numbering starts at 1000
        ///             // (it could be any number)
        ///             Wgl.wglUseFontOutlines(hdc, 0, 255, 1000, 0.0f, 0.1f, Wgl.WGL_FONT_POLYGONS, ref agmf);
        ///
        ///             // Set up transformation to draw the string
        ///             Gl.glLoadIdentity();
        ///             Gl.glTranslate(0.0f, 0.0f, -5.0f)
        ///             Gl.glScalef(2.0f, 2.0f, 2.0f);
        ///
        ///             // Display a string
        ///             Gl.glListBase(1000); // Indicates the start of display lists for the glyphs
        ///
        ///             // Draw the characters in a string
        ///             Gl.glCallLists(24, Gl.GL_UNSIGNED_SHORT, "Hello Win32 OpenGL World.");
        ///         </code>
        ///     </para>
        /// </remarks>
        /// <seealso cref="Gdi.GLYPHMETRICSFLOAT" />
        /// <seealso cref="Tao.OpenGl.Gl.glCallLists" />
        /// <seealso cref="Tao.OpenGl.Gl.glListBase" />
        /// <seealso cref="Tao.OpenGl.Gl.glTexGenf" />
        /// <seealso cref="wglUseFontBitmaps" />
        // WINGDIAPI BOOL WINAPI wglUseFontOutlinesA(HDC, DWORD, DWORD, DWORD, FLOAT, FLOAT, int, LPGLYPHMETRICSFLOAT);
        // WINGDIAPI BOOL WINAPI wglUseFontOutlinesW(HDC, DWORD, DWORD, DWORD, FLOAT, FLOAT, int, LPGLYPHMETRICSFLOAT);
        [DllImport(WGL_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool wglUseFontOutlines(IntPtr deviceContext, int first, int count, int listBase, float deviation, float extrusion, int format, [Out, MarshalAs(UnmanagedType.LPArray)] Gdi.GLYPHMETRICSFLOAT[] glyphMetrics);
        #endregion bool wglUseFontOutlines(IntPtr deviceContext, int first, int count, int listBase, float deviation, float extrusion, int format, [Out, MarshalAs(UnmanagedType.LPArray)] Gdi.GLYPHMETRICSFLOAT[] glyphMetrics)

        // --- WGL Extensions ---
        #region 3DFX Extensions
        #region WGL_3DFX_multisample (207)
        #region WGL_3DFX_multisample Constants
        #region WGL_SAMPLE_BUFFERS_3DFX
        // #define WGL_SAMPLE_BUFFERS_3DFX 0x2060
        public const int WGL_SAMPLE_BUFFERS_3DFX = 0x2060;
        #endregion WGL_SAMPLE_BUFFERS_3DFX

        #region WGL_SAMPLES_3DFX
        // #define WGL_SAMPLES_3DFX 0x2061
        public const int WGL_SAMPLES_3DFX = 0x2061;
        #endregion WGL_SAMPLES_3DFX
        #endregion WGL_3DFX_multisample Constants
        #endregion WGL_3DFX_multisample (207)
        #endregion 3DFX Extensions

        #region ARB Extensions
        #region WGL_ARB_buffer_region (4)
        #region WGL_ARB_buffer_region Constants
        #region WGL_FRONT_COLOR_BUFFER_BIT_ARB
        // #define WGL_FRONT_COLOR_BUFFER_BIT_ARB 0x00000001
        public const int WGL_FRONT_COLOR_BUFFER_BIT_ARB = 0x00000001;
        #endregion WGL_FRONT_COLOR_BUFFER_BIT_ARB

        #region WGL_BACK_COLOR_BUFFER_BIT_ARB
        // #define WGL_BACK_COLOR_BUFFER_BIT_ARB 0x00000002
        public const int WGL_BACK_COLOR_BUFFER_BIT_ARB = 0x00000002;
        #endregion WGL_BACK_COLOR_BUFFER_BIT_ARB

        #region WGL_DEPTH_BUFFER_BIT_ARB
        // #define WGL_DEPTH_BUFFER_BIT_ARB 0x00000004
        public const int WGL_DEPTH_BUFFER_BIT_ARB = 0x00000004;
        #endregion WGL_DEPTH_BUFFER_BIT_ARB

        #region WGL_STENCIL_BUFFER_BIT_ARB
        // #define WGL_STENCIL_BUFFER_BIT_ARB 0x00000008
        public const int WGL_STENCIL_BUFFER_BIT_ARB = 0x00000008;
        #endregion WGL_STENCIL_BUFFER_BIT_ARB
        #endregion WGL_ARB_buffer_region Constants

        #region WGL_ARB_buffer_region Methods
        #region Overloads for HANDLE wglCreateBufferRegionARB(HDC hDC, GLint iLayerPlane, GLuint uType)
        #region IntPtr wglCreateBufferRegionARB([In] IntPtr extensionPointer, IntPtr hDC, int iLayerPlane, int uType)
        // HANDLE wglCreateBufferRegionARB(HDC hDC, GLint iLayerPlane, GLuint uType)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iLayerPlane\r\nldarg uType\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int,[in]int32,[in]int32)\r\nret")]
        public static IntPtr wglCreateBufferRegionARB([In] IntPtr extensionPointer, IntPtr hDC, int iLayerPlane, int uType) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglCreateBufferRegionARB([In] IntPtr extensionPointer, IntPtr hDC, int iLayerPlane, int uType)

        #region IntPtr wglCreateBufferRegionARB([In] IntPtr extensionPointer, IntPtr hDC, int iLayerPlane, uint uType)
        // HANDLE wglCreateBufferRegionARB(HDC hDC, GLint iLayerPlane, GLuint uType)
        [CLSCompliant(false), IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iLayerPlane\r\nldarg uType\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int,[in]int32,[in]unsigned int32)\r\nret")]
        public static IntPtr wglCreateBufferRegionARB([In] IntPtr extensionPointer, IntPtr hDC, int iLayerPlane, uint uType) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglCreateBufferRegionARB([In] IntPtr extensionPointer, IntPtr hDC, int iLayerPlane, uint uType)
        #endregion Overloads for HANDLE wglCreateBufferRegionARB(HDC hDC, GLint iLayerPlane, GLuint uType)

        #region void wglDeleteBufferRegionARB([In] IntPtr extensionPointer, IntPtr hRegion)
        // GLvoid wglDeleteBufferRegionARB(HANDLE hRegion)
        [IlasmAttribute(".maxstack 2\r\nldarg hRegion\r\nldarg extensionPointer\r\ncalli unmanaged stdcall void([in]native int)\r\nret")]
        public static void wglDeleteBufferRegionARB([In] IntPtr extensionPointer, IntPtr hRegion) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion void wglDeleteBufferRegionARB([In] IntPtr extensionPointer, IntPtr hRegion)

        #region int wglSaveBufferRegionARB([In] IntPtr extensionPointer, IntPtr hRegion, int x, int y, int width, int height)
        // BOOL wglSaveBufferRegionARB(HANDLE hRegion, GLint x, GLint y, GLint width, GLint height)
        [IlasmAttribute(".maxstack 6\r\nldarg hRegion\r\nldarg x\r\nldarg y\r\nldarg width\r\nldarg height\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in]int32)\r\nret")]
        public static int wglSaveBufferRegionARB([In] IntPtr extensionPointer, IntPtr hRegion, int x, int y, int width, int height) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSaveBufferRegionARB([In] IntPtr extensionPointer, IntPtr hRegion, int x, int y, int width, int height)

        #region int wglRestoreBufferRegionARB([In] IntPtr extensionPointer, IntPtr hRegion, int x, int y, int width, int height, int xSrc, int ySrc)
        // BOOL wglRestoreBufferRegionARB(HANDLE hRegion, GLint x, GLint y, GLint width, GLint height, GLint xSrc, GLint ySrc)
        [IlasmAttribute(".maxstack 8\r\nldarg hRegion\r\nldarg x\r\nldarg y\r\nldarg width\r\nldarg height\r\nldarg xSrc\r\nldarg ySrc\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in]int32,[in]int32,[in]int32)\r\nret")]
        public static int wglRestoreBufferRegionARB([In] IntPtr extensionPointer, IntPtr hRegion, int x, int y, int width, int height, int xSrc, int ySrc) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglRestoreBufferRegionARB([In] IntPtr extensionPointer, IntPtr hRegion, int x, int y, int width, int height, int xSrc, int ySrc)
        #endregion WGL_ARB_buffer_region Methods
        #endregion WGL_ARB_buffer_region (4)

        #region WGL_ARB_multisample (5)
        #region WGL_ARB_multisample Constants
        #region WGL_SAMPLE_BUFFERS_ARB
        // #define WGL_SAMPLE_BUFFERS_ARB 0x2041
        public const int WGL_SAMPLE_BUFFERS_ARB = 0x2041;
        #endregion WGL_SAMPLE_BUFFERS_ARB

        #region WGL_SAMPLES_ARB
        // #define WGL_SAMPLES_ARB 0x2042
        public const int WGL_SAMPLES_ARB = 0x2042;
        #endregion WGL_SAMPLES_ARB
        #endregion WGL_ARB_multisample Constants
        #endregion WGL_ARB_multisample (5)

        #region WGL_ARB_extensions_string (8)
        #region WGL_ARB_extensions_string Methods
        #region string wglGetExtensionsStringARB([In] IntPtr extensionPointer, IntPtr hdc)
        // const char* wglGetExtensionsStringARB(HDC hdc)
        [IlasmAttribute(".maxstack 2\r\nldarg hdc\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int)\r\ncall string [mscorlib]System.Runtime.InteropServices.Marshal::PtrToStringAnsi(native int)\r\nret")]
        public static string wglGetExtensionsStringARB([In] IntPtr extensionPointer, IntPtr hdc) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion string wglGetExtensionsStringARB([In] IntPtr extensionPointer, IntPtr hdc)
        #endregion WGL_ARB_extensions_string Methods
        #endregion WGL_ARB_extensions_string (8)

        #region WGL_ARB_pixel_format (9)
        #region WGL_ARB_pixel_format Constants
        #region WGL_NUMBER_PIXEL_FORMATS_ARB
        // #define WGL_NUMBER_PIXEL_FORMATS_ARB 0x2000
        public const int WGL_NUMBER_PIXEL_FORMATS_ARB = 0x2000;
        #endregion WGL_NUMBER_PIXEL_FORMATS_ARB

        #region WGL_DRAW_TO_WINDOW_ARB
        // #define WGL_DRAW_TO_WINDOW_ARB 0x2001
        public const int WGL_DRAW_TO_WINDOW_ARB = 0x2001;
        #endregion WGL_DRAW_TO_WINDOW_ARB

        #region WGL_DRAW_TO_BITMAP_ARB
        // #define WGL_DRAW_TO_BITMAP_ARB 0x2002
        public const int WGL_DRAW_TO_BITMAP_ARB = 0x2002;
        #endregion WGL_DRAW_TO_BITMAP_ARB

        #region WGL_ACCELERATION_ARB
        // #define WGL_ACCELERATION_ARB 0x2003
        public const int WGL_ACCELERATION_ARB = 0x2003;
        #endregion WGL_ACCELERATION_ARB

        #region WGL_NEED_PALETTE_ARB
        // #define WGL_NEED_PALETTE_ARB 0x2004
        public const int WGL_NEED_PALETTE_ARB = 0x2004;
        #endregion WGL_NEED_PALETTE_ARB

        #region WGL_NEED_SYSTEM_PALETTE_ARB
        // #define WGL_NEED_SYSTEM_PALETTE_ARB 0x2005
        public const int WGL_NEED_SYSTEM_PALETTE_ARB = 0x2005;
        #endregion WGL_NEED_SYSTEM_PALETTE_ARB

        #region WGL_SWAP_LAYER_BUFFERS_ARB
        // #define WGL_SWAP_LAYER_BUFFERS_ARB 0x2006
        public const int WGL_SWAP_LAYER_BUFFERS_ARB = 0x2006;
        #endregion WGL_SWAP_LAYER_BUFFERS_ARB

        #region WGL_SWAP_METHOD_ARB
        // #define WGL_SWAP_METHOD_ARB 0x2007
        public const int WGL_SWAP_METHOD_ARB = 0x2007;
        #endregion WGL_SWAP_METHOD_ARB

        #region WGL_NUMBER_OVERLAYS_ARB
        // #define WGL_NUMBER_OVERLAYS_ARB 0x2008
        public const int WGL_NUMBER_OVERLAYS_ARB = 0x2008;
        #endregion WGL_NUMBER_OVERLAYS_ARB

        #region WGL_NUMBER_UNDERLAYS_ARB
        // #define WGL_NUMBER_UNDERLAYS_ARB 0x2009
        public const int WGL_NUMBER_UNDERLAYS_ARB = 0x2009;
        #endregion WGL_NUMBER_UNDERLAYS_ARB

        #region WGL_TRANSPARENT_ARB
        // #define WGL_TRANSPARENT_ARB 0x200A
        public const int WGL_TRANSPARENT_ARB = 0x200A;
        #endregion WGL_TRANSPARENT_ARB

        #region WGL_TRANSPARENT_RED_VALUE_ARB
        // #define WGL_TRANSPARENT_RED_VALUE_ARB 0x2037
        public const int WGL_TRANSPARENT_RED_VALUE_ARB = 0x2037;
        #endregion WGL_TRANSPARENT_RED_VALUE_ARB

        #region WGL_TRANSPARENT_GREEN_VALUE_ARB
        // #define WGL_TRANSPARENT_GREEN_VALUE_ARB 0x2038
        public const int WGL_TRANSPARENT_GREEN_VALUE_ARB = 0x2038;
        #endregion WGL_TRANSPARENT_GREEN_VALUE_ARB

        #region WGL_TRANSPARENT_BLUE_VALUE_ARB
        // #define WGL_TRANSPARENT_BLUE_VALUE_ARB 0x2039
        public const int WGL_TRANSPARENT_BLUE_VALUE_ARB = 0x2039;
        #endregion WGL_TRANSPARENT_BLUE_VALUE_ARB

        #region WGL_TRANSPARENT_ALPHA_VALUE_ARB
        // #define WGL_TRANSPARENT_ALPHA_VALUE_ARB 0x203A
        public const int WGL_TRANSPARENT_ALPHA_VALUE_ARB = 0x203A;
        #endregion WGL_TRANSPARENT_ALPHA_VALUE_ARB

        #region WGL_TRANSPARENT_INDEX_VALUE_ARB
        // #define WGL_TRANSPARENT_INDEX_VALUE_ARB 0x203B
        public const int WGL_TRANSPARENT_INDEX_VALUE_ARB = 0x203B;
        #endregion WGL_TRANSPARENT_INDEX_VALUE_ARB

        #region WGL_SHARE_DEPTH_ARB
        // #define WGL_SHARE_DEPTH_ARB 0x200C
        public const int WGL_SHARE_DEPTH_ARB = 0x200C;
        #endregion WGL_SHARE_DEPTH_ARB

        #region WGL_SHARE_STENCIL_ARB
        // #define WGL_SHARE_STENCIL_ARB 0x200D
        public const int WGL_SHARE_STENCIL_ARB = 0x200D;
        #endregion WGL_SHARE_STENCIL_ARB

        #region WGL_SHARE_ACCUM_ARB
        // #define WGL_SHARE_ACCUM_ARB 0x200E
        public const int WGL_SHARE_ACCUM_ARB = 0x200E;
        #endregion WGL_SHARE_ACCUM_ARB

        #region WGL_SUPPORT_GDI_ARB
        // #define WGL_SUPPORT_GDI_ARB 0x200F
        public const int WGL_SUPPORT_GDI_ARB = 0x200F;
        #endregion WGL_SUPPORT_GDI_ARB

        #region WGL_SUPPORT_OPENGL_ARB
        // #define WGL_SUPPORT_OPENGL_ARB 0x2010
        public const int WGL_SUPPORT_OPENGL_ARB = 0x2010;
        #endregion WGL_SUPPORT_OPENGL_ARB

        #region WGL_DOUBLE_BUFFER_ARB
        // #define WGL_DOUBLE_BUFFER_ARB 0x2011
        public const int WGL_DOUBLE_BUFFER_ARB = 0x2011;
        #endregion WGL_DOUBLE_BUFFER_ARB

        #region WGL_STEREO_ARB
        // #define WGL_STEREO_ARB 0x2012
        public const int WGL_STEREO_ARB = 0x2012;
        #endregion WGL_STEREO_ARB

        #region WGL_PIXEL_TYPE_ARB
        // #define WGL_PIXEL_TYPE_ARB 0x2013
        public const int WGL_PIXEL_TYPE_ARB = 0x2013;
        #endregion WGL_PIXEL_TYPE_ARB

        #region WGL_COLOR_BITS_ARB
        // #define WGL_COLOR_BITS_ARB 0x2014
        public const int WGL_COLOR_BITS_ARB = 0x2014;
        #endregion WGL_COLOR_BITS_ARB

        #region WGL_RED_BITS_ARB
        // #define WGL_RED_BITS_ARB 0x2015
        public const int WGL_RED_BITS_ARB = 0x2015;
        #endregion WGL_RED_BITS_ARB

        #region WGL_RED_SHIFT_ARB
        // #define WGL_RED_SHIFT_ARB 0x2016
        public const int WGL_RED_SHIFT_ARB = 0x2016;
        #endregion WGL_RED_SHIFT_ARB

        #region WGL_GREEN_BITS_ARB
        // #define WGL_GREEN_BITS_ARB 0x2017
        public const int WGL_GREEN_BITS_ARB = 0x2017;
        #endregion WGL_GREEN_BITS_ARB

        #region WGL_GREEN_SHIFT_ARB
        // #define WGL_GREEN_SHIFT_ARB 0x2018
        public const int WGL_GREEN_SHIFT_ARB = 0x2018;
        #endregion WGL_GREEN_SHIFT_ARB

        #region WGL_BLUE_BITS_ARB
        // #define WGL_BLUE_BITS_ARB 0x2019
        public const int WGL_BLUE_BITS_ARB = 0x2019;
        #endregion WGL_BLUE_BITS_ARB

        #region WGL_BLUE_SHIFT_ARB
        // #define WGL_BLUE_SHIFT_ARB 0x201A
        public const int WGL_BLUE_SHIFT_ARB = 0x201A;
        #endregion WGL_BLUE_SHIFT_ARB

        #region WGL_ALPHA_BITS_ARB
        // #define WGL_ALPHA_BITS_ARB 0x201B
        public const int WGL_ALPHA_BITS_ARB = 0x201B;
        #endregion WGL_ALPHA_BITS_ARB

        #region WGL_ALPHA_SHIFT_ARB
        // #define WGL_ALPHA_SHIFT_ARB 0x201C
        public const int WGL_ALPHA_SHIFT_ARB = 0x201C;
        #endregion WGL_ALPHA_SHIFT_ARB

        #region WGL_ACCUM_BITS_ARB
        // #define WGL_ACCUM_BITS_ARB 0x201D
        public const int WGL_ACCUM_BITS_ARB = 0x201D;
        #endregion WGL_ACCUM_BITS_ARB

        #region WGL_ACCUM_RED_BITS_ARB
        // #define WGL_ACCUM_RED_BITS_ARB 0x201E
        public const int WGL_ACCUM_RED_BITS_ARB = 0x201E;
        #endregion WGL_ACCUM_RED_BITS_ARB

        #region WGL_ACCUM_GREEN_BITS_ARB
        // #define WGL_ACCUM_GREEN_BITS_ARB 0x201F
        public const int WGL_ACCUM_GREEN_BITS_ARB = 0x201F;
        #endregion WGL_ACCUM_GREEN_BITS_ARB

        #region WGL_ACCUM_BLUE_BITS_ARB
        // #define WGL_ACCUM_BLUE_BITS_ARB 0x2020
        public const int WGL_ACCUM_BLUE_BITS_ARB = 0x2020;
        #endregion WGL_ACCUM_BLUE_BITS_ARB

        #region WGL_ACCUM_ALPHA_BITS_ARB
        // #define WGL_ACCUM_ALPHA_BITS_ARB 0x2021
        public const int WGL_ACCUM_ALPHA_BITS_ARB = 0x2021;
        #endregion WGL_ACCUM_ALPHA_BITS_ARB

        #region WGL_DEPTH_BITS_ARB
        // #define WGL_DEPTH_BITS_ARB 0x2022
        public const int WGL_DEPTH_BITS_ARB = 0x2022;
        #endregion WGL_DEPTH_BITS_ARB

        #region WGL_STENCIL_BITS_ARB
        // #define WGL_STENCIL_BITS_ARB 0x2023
        public const int WGL_STENCIL_BITS_ARB = 0x2023;
        #endregion WGL_STENCIL_BITS_ARB

        #region WGL_AUX_BUFFERS_ARB
        // #define WGL_AUX_BUFFERS_ARB 0x2024
        public const int WGL_AUX_BUFFERS_ARB = 0x2024;
        #endregion WGL_AUX_BUFFERS_ARB

        #region WGL_NO_ACCELERATION_ARB
        // #define WGL_NO_ACCELERATION_ARB 0x2025
        public const int WGL_NO_ACCELERATION_ARB = 0x2025;
        #endregion WGL_NO_ACCELERATION_ARB

        #region WGL_GENERIC_ACCELERATION_ARB
        // #define WGL_GENERIC_ACCELERATION_ARB 0x2026
        public const int WGL_GENERIC_ACCELERATION_ARB = 0x2026;
        #endregion WGL_GENERIC_ACCELERATION_ARB

        #region WGL_FULL_ACCELERATION_ARB
        // #define WGL_FULL_ACCELERATION_ARB 0x2027
        public const int WGL_FULL_ACCELERATION_ARB = 0x2027;
        #endregion WGL_FULL_ACCELERATION_ARB

        #region WGL_SWAP_EXCHANGE_ARB
        // #define WGL_SWAP_EXCHANGE_ARB 0x2028
        public const int WGL_SWAP_EXCHANGE_ARB = 0x2028;
        #endregion WGL_SWAP_EXCHANGE_ARB

        #region WGL_SWAP_COPY_ARB
        // #define WGL_SWAP_COPY_ARB 0x2029
        public const int WGL_SWAP_COPY_ARB = 0x2029;
        #endregion WGL_SWAP_COPY_ARB

        #region WGL_SWAP_UNDEFINED_ARB
        // #define WGL_SWAP_UNDEFINED_ARB 0x202A
        public const int WGL_SWAP_UNDEFINED_ARB = 0x202A;
        #endregion WGL_SWAP_UNDEFINED_ARB

        #region WGL_TYPE_RGBA_ARB
        // #define WGL_TYPE_RGBA_ARB 0x202B
        public const int WGL_TYPE_RGBA_ARB = 0x202B;
        #endregion WGL_TYPE_RGBA_ARB

        #region WGL_TYPE_COLORINDEX_ARB
        // #define WGL_TYPE_COLORINDEX_ARB 0x202C
        public const int WGL_TYPE_COLORINDEX_ARB = 0x202C;
        #endregion WGL_TYPE_COLORINDEX_ARB
        #endregion WGL_ARB_pixel_format Constants

        #region WGL_ARB_pixel_format Methods
        #region Overloads for BOOL wglGetPixelFormatAttribivARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        #region int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, int[] piValues)
        // BOOL wglGetPixelFormatAttribivARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in]int32[],[out]int32[])\r\nret")]
        public static int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, int[] piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, int[] piValues)

        #region int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out int piValues)
        // BOOL wglGetPixelFormatAttribivARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in][out]int32,[out]int32)\r\nret")]
        public static int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out int piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out int piValues)

        #region int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, IntPtr piAttributes, IntPtr piValues)
        // BOOL wglGetPixelFormatAttribivARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in]native int,[out]native int)\r\nret")]
        public static int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, IntPtr piAttributes, IntPtr piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, IntPtr piAttributes, IntPtr piValues)

        #region int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, IntPtr piAttributes, IntPtr piValues)
        // BOOL wglGetPixelFormatAttribivARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in]native int,[out]native int)\r\nret")]
        public static int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, IntPtr piAttributes, IntPtr piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, IntPtr piAttributes, IntPtr piValues)

        #region int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref int piAttributes, out int piValues)
        // BOOL wglGetPixelFormatAttribivARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in][out]int32,[out]int32)\r\nret")]
        public static int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref int piAttributes, out int piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref int piAttributes, out int piValues)

        #region int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, int[] piValues)
        // BOOL wglGetPixelFormatAttribivARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in]int32[],[out]int32[])\r\nret")]
        public static int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, int[] piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, int[] piValues)

        #region int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, int* piValues)
        // BOOL wglGetPixelFormatAttribivARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in]int32*,[out]int32*)\r\nret")]
        public static unsafe int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, int* piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, int* piValues)
        #endregion Overloads for BOOL wglGetPixelFormatAttribivARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)

        #region Overloads for BOOL wglGetPixelFormatAttribfvARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        #region int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, float[] pfValues)
        // BOOL wglGetPixelFormatAttribfvARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in]int32[],[out]float32[])\r\nret")]
        public static int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, float[] pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, float[] pfValues)

        #region int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out float pfValues)
        // BOOL wglGetPixelFormatAttribfvARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in][out]int32,[out]float32)\r\nret")]
        public static int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out float pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out float pfValues)

        #region int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, IntPtr piAttributes, IntPtr pfValues)
        // BOOL wglGetPixelFormatAttribfvARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in]native int,[out]native int)\r\nret")]
        public static int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, IntPtr piAttributes, IntPtr pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, IntPtr piAttributes, IntPtr pfValues)

        #region int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, IntPtr piAttributes, IntPtr pfValues)
        // BOOL wglGetPixelFormatAttribfvARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in]native int,[out]native int)\r\nret")]
        public static int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, IntPtr piAttributes, IntPtr pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, IntPtr piAttributes, IntPtr pfValues)

        #region int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref int piAttributes, out float pfValues)
        // BOOL wglGetPixelFormatAttribfvARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in][out]int32,[out]float32)\r\nret")]
        public static int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref int piAttributes, out float pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref int piAttributes, out float pfValues)

        #region int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, float[] pfValues)
        // BOOL wglGetPixelFormatAttribfvARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in]int32[],[out]float32[])\r\nret")]
        public static int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, float[] pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, float[] pfValues)

        #region int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, float* pfValues)
        // BOOL wglGetPixelFormatAttribfvARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in]int32*,[out]float32*)\r\nret")]
        public static unsafe int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, float* pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvARB([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, float* pfValues)
        #endregion Overloads for BOOL wglGetPixelFormatAttribfvARB(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)

        #region Overloads for BOOL wglChoosePixelFormatARB(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        #region int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, int nMaxFormats, int[] piFormats, out int nNumFormats)
        // BOOL wglChoosePixelFormatARB(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32[],[in]float32[],[in]int32,[out]int32[],[out]int32)\r\nret")]
        public static int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, int nMaxFormats, int[] piFormats, out int nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, int nMaxFormats, int[] piFormats, out int nNumFormats)

        #region int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, ref int piAttribIList, ref float pfAttribFList, int nMaxFormats, out int piFormats, out int nNumFormats)
        // BOOL wglChoosePixelFormatARB(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in][out]int32,[in][out]float32,[in]int32,[out]int32,[out]int32)\r\nret")]
        public static int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, ref int piAttribIList, ref float pfAttribFList, int nMaxFormats, out int piFormats, out int nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, ref int piAttribIList, ref float pfAttribFList, int nMaxFormats, out int piFormats, out int nNumFormats)

        #region int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, IntPtr piAttribIList, IntPtr pfAttribFList, int nMaxFormats, IntPtr piFormats, out int nNumFormats)
        // BOOL wglChoosePixelFormatARB(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int,[in]native int,[in]int32,[out]native int,[out]int32)\r\nret")]
        public static int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, IntPtr piAttribIList, IntPtr pfAttribFList, int nMaxFormats, IntPtr piFormats, out int nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, IntPtr piAttribIList, IntPtr pfAttribFList, int nMaxFormats, IntPtr piFormats, out int nNumFormats)

        #region int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, IntPtr piAttribIList, IntPtr pfAttribFList, uint nMaxFormats, IntPtr piFormats, out uint nNumFormats)
        // BOOL wglChoosePixelFormatARB(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int,[in]native int,[in]unsigned int32,[out]native int,[out]unsigned int32)\r\nret")]
        public static int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, IntPtr piAttribIList, IntPtr pfAttribFList, uint nMaxFormats, IntPtr piFormats, out uint nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, IntPtr piAttribIList, IntPtr pfAttribFList, uint nMaxFormats, IntPtr piFormats, out uint nNumFormats)

        #region int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, ref int piAttribIList, ref float pfAttribFList, uint nMaxFormats, out int piFormats, out uint nNumFormats)
        // BOOL wglChoosePixelFormatARB(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in][out]int32,[in][out]float32,[in]unsigned int32,[out]int32,[out]unsigned int32)\r\nret")]
        public static int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, ref int piAttribIList, ref float pfAttribFList, uint nMaxFormats, out int piFormats, out uint nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, ref int piAttribIList, ref float pfAttribFList, uint nMaxFormats, out int piFormats, out uint nNumFormats)

        #region int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, uint nMaxFormats, int[] piFormats, out uint nNumFormats)
        // BOOL wglChoosePixelFormatARB(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32[],[in]float32[],[in]unsigned int32,[out]int32[],[out]unsigned int32)\r\nret")]
        public static int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, uint nMaxFormats, int[] piFormats, out uint nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, uint nMaxFormats, int[] piFormats, out uint nNumFormats)

        #region int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, int* piAttribIList, float* pfAttribFList, uint nMaxFormats, int* piFormats, out uint nNumFormats)
        // BOOL wglChoosePixelFormatARB(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32*,[in]float32*,[in]unsigned int32,[out]int32*,[out]unsigned int32)\r\nret")]
        public static unsafe int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, int* piAttribIList, float* pfAttribFList, uint nMaxFormats, int* piFormats, out uint nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatARB([In] IntPtr extensionPointer, IntPtr hdc, int* piAttribIList, float* pfAttribFList, uint nMaxFormats, int* piFormats, out uint nNumFormats)
        #endregion Overloads for BOOL wglChoosePixelFormatARB(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        #endregion WGL_ARB_pixel_format Methods
        #endregion WGL_ARB_pixel_format (9)

        #region WGL_ARB_make_current_read (10)
        #region WGL_ARB_make_current_read Constants
        #region WGL_ERROR_INVALID_PIXEL_TYPE_ARB
        // #define WGL_ERROR_INVALID_PIXEL_TYPE_ARB 0x2043
        public const int WGL_ERROR_INVALID_PIXEL_TYPE_ARB = 0x2043;
        #endregion WGL_ERROR_INVALID_PIXEL_TYPE_ARB

        #region WGL_ERROR_INCOMPATIBLE_DEVICE_CONTEXTS_ARB
        // #define WGL_ERROR_INCOMPATIBLE_DEVICE_CONTEXTS_ARB 0x2054
        public const int WGL_ERROR_INCOMPATIBLE_DEVICE_CONTEXTS_ARB = 0x2054;
        #endregion WGL_ERROR_INCOMPATIBLE_DEVICE_CONTEXTS_ARB
        #endregion WGL_ARB_make_current_read Constants

        #region WGL_ARB_make_current_read Methods
        #region int wglMakeContextCurrentARB([In] IntPtr extensionPointer, IntPtr hDrawDC, IntPtr hReadDC, IntPtr hglrc)
        // BOOL wglMakeContextCurrentARB(HDC hDrawDC, HDC hReadDC, HGLRC hglrc)
        [IlasmAttribute(".maxstack 4\r\nldarg hDrawDC\r\nldarg hReadDC\r\nldarg hglrc\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int,[in]native int)\r\nret")]
        public static int wglMakeContextCurrentARB([In] IntPtr extensionPointer, IntPtr hDrawDC, IntPtr hReadDC, IntPtr hglrc) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglMakeContextCurrentARB([In] IntPtr extensionPointer, IntPtr hDrawDC, IntPtr hReadDC, IntPtr hglrc)

        #region IntPtr wglGetCurrentReadDCARB([In] IntPtr extensionPointer)
        // HDC wglGetCurrentReadDCARB()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int()\r\nret")]
        public static IntPtr wglGetCurrentReadDCARB([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglGetCurrentReadDCARB([In] IntPtr extensionPointer)
        #endregion WGL_ARB_make_current_read Methods
        #endregion WGL_ARB_make_current_read (10)

        #region WGL_ARB_pbuffer (11)
        #region WGL_ARB_pbuffer Constants
        #region WGL_DRAW_TO_PBUFFER_ARB
        // #define WGL_DRAW_TO_PBUFFER_ARB 0x202D
        public const int WGL_DRAW_TO_PBUFFER_ARB = 0x202D;
        #endregion WGL_DRAW_TO_PBUFFER_ARB

        #region WGL_MAX_PBUFFER_PIXELS_ARB
        // #define WGL_MAX_PBUFFER_PIXELS_ARB 0x202E
        public const int WGL_MAX_PBUFFER_PIXELS_ARB = 0x202E;
        #endregion WGL_MAX_PBUFFER_PIXELS_ARB

        #region WGL_MAX_PBUFFER_WIDTH_ARB
        // #define WGL_MAX_PBUFFER_WIDTH_ARB 0x202F
        public const int WGL_MAX_PBUFFER_WIDTH_ARB = 0x202F;
        #endregion WGL_MAX_PBUFFER_WIDTH_ARB

        #region WGL_MAX_PBUFFER_HEIGHT_ARB
        // #define WGL_MAX_PBUFFER_HEIGHT_ARB 0x2030
        public const int WGL_MAX_PBUFFER_HEIGHT_ARB = 0x2030;
        #endregion WGL_MAX_PBUFFER_HEIGHT_ARB

        #region WGL_PBUFFER_LARGEST_ARB
        // #define WGL_PBUFFER_LARGEST_ARB 0x2033
        public const int WGL_PBUFFER_LARGEST_ARB = 0x2033;
        #endregion WGL_PBUFFER_LARGEST_ARB

        #region WGL_PBUFFER_WIDTH_ARB
        // #define WGL_PBUFFER_WIDTH_ARB 0x2034
        public const int WGL_PBUFFER_WIDTH_ARB = 0x2034;
        #endregion WGL_PBUFFER_WIDTH_ARB

        #region WGL_PBUFFER_HEIGHT_ARB
        // #define WGL_PBUFFER_HEIGHT_ARB 0x2035
        public const int WGL_PBUFFER_HEIGHT_ARB = 0x2035;
        #endregion WGL_PBUFFER_HEIGHT_ARB

        #region WGL_PBUFFER_LOST_ARB
        // #define WGL_PBUFFER_LOST_ARB 0x2036
        public const int WGL_PBUFFER_LOST_ARB = 0x2036;
        #endregion WGL_PBUFFER_LOST_ARB
        #endregion WGL_ARB_pbuffer Constants

        #region WGL_ARB_pbuffer Methods
        #region Overloads for HANDLE wglCreatePbufferARB(HDC hDC, GLint iPixelFormat, GLint iWidth, GLint iHeight, const GLint* piAttribList)
        #region IntPtr wglCreatePbufferARB([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, ref int piAttribList)
        // HANDLE wglCreatePbufferARB(HDC hDC, GLint iPixelFormat, GLint iWidth, GLint iHeight, const GLint* piAttribList)
        [IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iPixelFormat\r\nldarg iWidth\r\nldarg iHeight\r\nldarg piAttribList\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int,[in]int32,[in]int32,[in]int32,[in][out]int32)\r\nret")]
        public static IntPtr wglCreatePbufferARB([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, ref int piAttribList) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglCreatePbufferARB([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, ref int piAttribList)

        #region IntPtr wglCreatePbufferARB([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int[] piAttribList)
        // HANDLE wglCreatePbufferARB(HDC hDC, GLint iPixelFormat, GLint iWidth, GLint iHeight, const GLint* piAttribList)
        [IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iPixelFormat\r\nldarg iWidth\r\nldarg iHeight\r\nldarg piAttribList\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int,[in]int32,[in]int32,[in]int32,[in]int32[])\r\nret")]
        public static IntPtr wglCreatePbufferARB([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int[] piAttribList) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglCreatePbufferARB([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int[] piAttribList)

        #region IntPtr wglCreatePbufferARB([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, IntPtr piAttribList)
        // HANDLE wglCreatePbufferARB(HDC hDC, GLint iPixelFormat, GLint iWidth, GLint iHeight, const GLint* piAttribList)
        [IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iPixelFormat\r\nldarg iWidth\r\nldarg iHeight\r\nldarg piAttribList\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int,[in]int32,[in]int32,[in]int32,[in]native int)\r\nret")]
        public static IntPtr wglCreatePbufferARB([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, IntPtr piAttribList) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglCreatePbufferARB([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, IntPtr piAttribList)

        #region IntPtr wglCreatePbufferARB([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int* piAttribList)
        // HANDLE wglCreatePbufferARB(HDC hDC, GLint iPixelFormat, GLint iWidth, GLint iHeight, const GLint* piAttribList)
        [CLSCompliant(false), IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iPixelFormat\r\nldarg iWidth\r\nldarg iHeight\r\nldarg piAttribList\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int,[in]int32,[in]int32,[in]int32,[in]int32*)\r\nret")]
        public static unsafe IntPtr wglCreatePbufferARB([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int* piAttribList) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglCreatePbufferARB([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int* piAttribList)
        #endregion Overloads for HANDLE wglCreatePbufferARB(HDC hDC, GLint iPixelFormat, GLint iWidth, GLint iHeight, const GLint* piAttribList)

        #region IntPtr wglGetPbufferDCARB([In] IntPtr extensionPointer, IntPtr hPbuffer)
        // HDC wglGetPbufferDCARB(HANDLE hPbuffer)
        [IlasmAttribute(".maxstack 2\r\nldarg hPbuffer\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int)\r\nret")]
        public static IntPtr wglGetPbufferDCARB([In] IntPtr extensionPointer, IntPtr hPbuffer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglGetPbufferDCARB([In] IntPtr extensionPointer, IntPtr hPbuffer)

        #region int wglReleasePbufferDCARB([In] IntPtr extensionPointer, IntPtr hPbuffer, IntPtr hDC)
        // GLint wglReleasePbufferDCARB(HANDLE hPbuffer, HDC hDC)
        [IlasmAttribute(".maxstack 3\r\nldarg hPbuffer\r\nldarg hDC\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int)\r\nret")]
        public static int wglReleasePbufferDCARB([In] IntPtr extensionPointer, IntPtr hPbuffer, IntPtr hDC) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglReleasePbufferDCARB([In] IntPtr extensionPointer, IntPtr hPbuffer, IntPtr hDC)

        #region int wglDestroyPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer)
        // BOOL wglDestroyPbufferARB(HANDLE hPbuffer)
        [IlasmAttribute(".maxstack 2\r\nldarg hPbuffer\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int)\r\nret")]
        public static int wglDestroyPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglDestroyPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer)

        #region Overloads for BOOL wglQueryPbufferARB(HANDLE hPbuffer, GLint iAttribute, GLint* piValue)
        #region int wglQueryPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, out int piValue)
        // BOOL wglQueryPbufferARB(HANDLE hPbuffer, GLint iAttribute, GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hPbuffer\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]int32)\r\nret")]
        public static int wglQueryPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, out int piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglQueryPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, out int piValue)

        #region int wglQueryPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, int[] piValue)
        // BOOL wglQueryPbufferARB(HANDLE hPbuffer, GLint iAttribute, GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hPbuffer\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]int32[])\r\nret")]
        public static int wglQueryPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, int[] piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglQueryPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, int[] piValue)

        #region int wglQueryPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, IntPtr piValue)
        // BOOL wglQueryPbufferARB(HANDLE hPbuffer, GLint iAttribute, GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hPbuffer\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]native int)\r\nret")]
        public static int wglQueryPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, IntPtr piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglQueryPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, IntPtr piValue)

        #region int wglQueryPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, int* piValue)
        // BOOL wglQueryPbufferARB(HANDLE hPbuffer, GLint iAttribute, GLint* piValue)
        [CLSCompliant(false), IlasmAttribute(".maxstack 4\r\nldarg hPbuffer\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]int32*)\r\nret")]
        public static unsafe int wglQueryPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, int* piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglQueryPbufferARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, int* piValue)
        #endregion Overloads for BOOL wglQueryPbufferARB(HANDLE hPbuffer, GLint iAttribute, GLint* piValue)
        #endregion WGL_ARB_pbuffer Methods
        #endregion WGL_ARB_pbuffer (11)

        #region WGL_ARB_render_texture (20)
        #region WGL_ARB_render_texture Constants
        #region WGL_BIND_TO_TEXTURE_RGB_ARB
        // #define WGL_BIND_TO_TEXTURE_RGB_ARB 0x2070
        public const int WGL_BIND_TO_TEXTURE_RGB_ARB = 0x2070;
        #endregion WGL_BIND_TO_TEXTURE_RGB_ARB

        #region WGL_BIND_TO_TEXTURE_RGBA_ARB
        // #define WGL_BIND_TO_TEXTURE_RGBA_ARB 0x2071
        public const int WGL_BIND_TO_TEXTURE_RGBA_ARB = 0x2071;
        #endregion WGL_BIND_TO_TEXTURE_RGBA_ARB

        #region WGL_TEXTURE_FORMAT_ARB
        // #define WGL_TEXTURE_FORMAT_ARB 0x2072
        public const int WGL_TEXTURE_FORMAT_ARB = 0x2072;
        #endregion WGL_TEXTURE_FORMAT_ARB

        #region WGL_TEXTURE_TARGET_ARB
        // #define WGL_TEXTURE_TARGET_ARB 0x2073
        public const int WGL_TEXTURE_TARGET_ARB = 0x2073;
        #endregion WGL_TEXTURE_TARGET_ARB

        #region WGL_MIPMAP_TEXTURE_ARB
        // #define WGL_MIPMAP_TEXTURE_ARB 0x2074
        public const int WGL_MIPMAP_TEXTURE_ARB = 0x2074;
        #endregion WGL_MIPMAP_TEXTURE_ARB

        #region WGL_TEXTURE_RGB_ARB
        // #define WGL_TEXTURE_RGB_ARB 0x2075
        public const int WGL_TEXTURE_RGB_ARB = 0x2075;
        #endregion WGL_TEXTURE_RGB_ARB

        #region WGL_TEXTURE_RGBA_ARB
        // #define WGL_TEXTURE_RGBA_ARB 0x2076
        public const int WGL_TEXTURE_RGBA_ARB = 0x2076;
        #endregion WGL_TEXTURE_RGBA_ARB

        #region WGL_NO_TEXTURE_ARB
        // #define WGL_NO_TEXTURE_ARB 0x2077
        public const int WGL_NO_TEXTURE_ARB = 0x2077;
        #endregion WGL_NO_TEXTURE_ARB

        #region WGL_TEXTURE_CUBE_MAP_ARB
        // #define WGL_TEXTURE_CUBE_MAP_ARB 0x2078
        public const int WGL_TEXTURE_CUBE_MAP_ARB = 0x2078;
        #endregion WGL_TEXTURE_CUBE_MAP_ARB

        #region WGL_TEXTURE_1D_ARB
        // #define WGL_TEXTURE_1D_ARB 0x2079
        public const int WGL_TEXTURE_1D_ARB = 0x2079;
        #endregion WGL_TEXTURE_1D_ARB

        #region WGL_TEXTURE_2D_ARB
        // #define WGL_TEXTURE_2D_ARB 0x207A
        public const int WGL_TEXTURE_2D_ARB = 0x207A;
        #endregion WGL_TEXTURE_2D_ARB

        #region WGL_MIPMAP_LEVEL_ARB
        // #define WGL_MIPMAP_LEVEL_ARB 0x207B
        public const int WGL_MIPMAP_LEVEL_ARB = 0x207B;
        #endregion WGL_MIPMAP_LEVEL_ARB

        #region WGL_CUBE_MAP_FACE_ARB
        // #define WGL_CUBE_MAP_FACE_ARB 0x207C
        public const int WGL_CUBE_MAP_FACE_ARB = 0x207C;
        #endregion WGL_CUBE_MAP_FACE_ARB

        #region WGL_TEXTURE_CUBE_MAP_POSITIVE_X_ARB
        // #define WGL_TEXTURE_CUBE_MAP_POSITIVE_X_ARB 0x207D
        public const int WGL_TEXTURE_CUBE_MAP_POSITIVE_X_ARB = 0x207D;
        #endregion WGL_TEXTURE_CUBE_MAP_POSITIVE_X_ARB

        #region WGL_TEXTURE_CUBE_MAP_NEGATIVE_X_ARB
        // #define WGL_TEXTURE_CUBE_MAP_NEGATIVE_X_ARB 0x207E
        public const int WGL_TEXTURE_CUBE_MAP_NEGATIVE_X_ARB = 0x207E;
        #endregion WGL_TEXTURE_CUBE_MAP_NEGATIVE_X_ARB

        #region WGL_TEXTURE_CUBE_MAP_POSITIVE_Y_ARB
        // #define WGL_TEXTURE_CUBE_MAP_POSITIVE_Y_ARB 0x207F
        public const int WGL_TEXTURE_CUBE_MAP_POSITIVE_Y_ARB = 0x207F;
        #endregion WGL_TEXTURE_CUBE_MAP_POSITIVE_Y_ARB

        #region WGL_TEXTURE_CUBE_MAP_NEGATIVE_Y_ARB
        // #define WGL_TEXTURE_CUBE_MAP_NEGATIVE_Y_ARB 0x2080
        public const int WGL_TEXTURE_CUBE_MAP_NEGATIVE_Y_ARB = 0x2080;
        #endregion WGL_TEXTURE_CUBE_MAP_NEGATIVE_Y_ARB

        #region WGL_TEXTURE_CUBE_MAP_POSITIVE_Z_ARB
        // #define WGL_TEXTURE_CUBE_MAP_POSITIVE_Z_ARB 0x2081
        public const int WGL_TEXTURE_CUBE_MAP_POSITIVE_Z_ARB = 0x2081;
        #endregion WGL_TEXTURE_CUBE_MAP_POSITIVE_Z_ARB

        #region WGL_TEXTURE_CUBE_MAP_NEGATIVE_Z_ARB
        // #define WGL_TEXTURE_CUBE_MAP_NEGATIVE_Z_ARB 0x2082
        public const int WGL_TEXTURE_CUBE_MAP_NEGATIVE_Z_ARB = 0x2082;
        #endregion WGL_TEXTURE_CUBE_MAP_NEGATIVE_Z_ARB

        #region WGL_FRONT_LEFT_ARB
        // #define WGL_FRONT_LEFT_ARB 0x2083
        public const int WGL_FRONT_LEFT_ARB = 0x2083;
        #endregion WGL_FRONT_LEFT_ARB

        #region WGL_FRONT_RIGHT_ARB
        // #define WGL_FRONT_RIGHT_ARB 0x2084
        public const int WGL_FRONT_RIGHT_ARB = 0x2084;
        #endregion WGL_FRONT_RIGHT_ARB

        #region WGL_BACK_LEFT_ARB
        // #define WGL_BACK_LEFT_ARB 0x2085
        public const int WGL_BACK_LEFT_ARB = 0x2085;
        #endregion WGL_BACK_LEFT_ARB

        #region WGL_BACK_RIGHT_ARB
        // #define WGL_BACK_RIGHT_ARB 0x2086
        public const int WGL_BACK_RIGHT_ARB = 0x2086;
        #endregion WGL_BACK_RIGHT_ARB

        #region WGL_AUX0_ARB
        // #define WGL_AUX0_ARB 0x2087
        public const int WGL_AUX0_ARB = 0x2087;
        #endregion WGL_AUX0_ARB

        #region WGL_AUX1_ARB
        // #define WGL_AUX1_ARB 0x2088
        public const int WGL_AUX1_ARB = 0x2088;
        #endregion WGL_AUX1_ARB

        #region WGL_AUX2_ARB
        // #define WGL_AUX2_ARB 0x2089
        public const int WGL_AUX2_ARB = 0x2089;
        #endregion WGL_AUX2_ARB

        #region WGL_AUX3_ARB
        // #define WGL_AUX3_ARB 0x208A
        public const int WGL_AUX3_ARB = 0x208A;
        #endregion WGL_AUX3_ARB

        #region WGL_AUX4_ARB
        // #define WGL_AUX4_ARB 0x208B
        public const int WGL_AUX4_ARB = 0x208B;
        #endregion WGL_AUX4_ARB

        #region WGL_AUX5_ARB
        // #define WGL_AUX5_ARB 0x208C
        public const int WGL_AUX5_ARB = 0x208C;
        #endregion WGL_AUX5_ARB

        #region WGL_AUX6_ARB
        // #define WGL_AUX6_ARB 0x208D
        public const int WGL_AUX6_ARB = 0x208D;
        #endregion WGL_AUX6_ARB

        #region WGL_AUX7_ARB
        // #define WGL_AUX7_ARB 0x208E
        public const int WGL_AUX7_ARB = 0x208E;
        #endregion WGL_AUX7_ARB

        #region WGL_AUX8_ARB
        // #define WGL_AUX8_ARB 0x208F
        public const int WGL_AUX8_ARB = 0x208F;
        #endregion WGL_AUX8_ARB

        #region WGL_AUX9_ARB
        // #define WGL_AUX9_ARB 0x2090
        public const int WGL_AUX9_ARB = 0x2090;
        #endregion WGL_AUX9_ARB
        #endregion WGL_ARB_render_texture Constants

        #region WGL_ARB_render_texture Methods
        #region int wglBindTexImageARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iBuffer)
        // BOOL wglBindTexImageARB(HANDLE hPbuffer, GLint iBuffer)
        [IlasmAttribute(".maxstack 3\r\nldarg hPbuffer\r\nldarg iBuffer\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32)\r\nret")]
        public static int wglBindTexImageARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iBuffer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglBindTexImageARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iBuffer)

        #region int wglReleaseTexImageARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iBuffer)
        // BOOL wglReleaseTexImageARB(HANDLE hPbuffer, GLint iBuffer)
        [IlasmAttribute(".maxstack 3\r\nldarg hPbuffer\r\nldarg iBuffer\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32)\r\nret")]
        public static int wglReleaseTexImageARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iBuffer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglReleaseTexImageARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int iBuffer)

        #region Overloads for BOOL wglSetPbufferAttribARB(HANDLE hPbuffer, const GLint* piAttribList)
        #region int wglSetPbufferAttribARB([In] IntPtr extensionPointer, IntPtr hPbuffer, ref int piAttribList)
        // BOOL wglSetPbufferAttribARB(HANDLE hPbuffer, const GLint* piAttribList)
        [IlasmAttribute(".maxstack 3\r\nldarg hPbuffer\r\nldarg piAttribList\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in][out]int32)\r\nret")]
        public static int wglSetPbufferAttribARB([In] IntPtr extensionPointer, IntPtr hPbuffer, ref int piAttribList) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetPbufferAttribARB([In] IntPtr extensionPointer, IntPtr hPbuffer, ref int piAttribList)

        #region int wglSetPbufferAttribARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int[] piAttribList)
        // BOOL wglSetPbufferAttribARB(HANDLE hPbuffer, const GLint* piAttribList)
        [IlasmAttribute(".maxstack 3\r\nldarg hPbuffer\r\nldarg piAttribList\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32[])\r\nret")]
        public static int wglSetPbufferAttribARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int[] piAttribList) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetPbufferAttribARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int[] piAttribList)

        #region int wglSetPbufferAttribARB([In] IntPtr extensionPointer, IntPtr hPbuffer, IntPtr piAttribList)
        // BOOL wglSetPbufferAttribARB(HANDLE hPbuffer, const GLint* piAttribList)
        [IlasmAttribute(".maxstack 3\r\nldarg hPbuffer\r\nldarg piAttribList\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int)\r\nret")]
        public static int wglSetPbufferAttribARB([In] IntPtr extensionPointer, IntPtr hPbuffer, IntPtr piAttribList) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetPbufferAttribARB([In] IntPtr extensionPointer, IntPtr hPbuffer, IntPtr piAttribList)

        #region int wglSetPbufferAttribARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int* piAttribList)
        // BOOL wglSetPbufferAttribARB(HANDLE hPbuffer, const GLint* piAttribList)
        [CLSCompliant(false), IlasmAttribute(".maxstack 3\r\nldarg hPbuffer\r\nldarg piAttribList\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32*)\r\nret")]
        public static unsafe int wglSetPbufferAttribARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int* piAttribList) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetPbufferAttribARB([In] IntPtr extensionPointer, IntPtr hPbuffer, int* piAttribList)
        #endregion Overloads for BOOL wglSetPbufferAttribARB(HANDLE hPbuffer, const GLint* piAttribList)
        #endregion WGL_ARB_render_texture Methods
        #endregion WGL_ARB_render_texture (20)
        #endregion ARB Extensions

        #region ATI Extensions
        #region WGL_ATI_pixel_format_float (278)
        #region WGL_ATI_pixel_format_float Constants
        #region WGL_RGBA_FLOAT_MODE_ATI
        // #define WGL_RGBA_FLOAT_MODE_ATI 0x8820
        public const int WGL_RGBA_FLOAT_MODE_ATI = 0x8820;
        #endregion WGL_RGBA_FLOAT_MODE_ATI

        #region WGL_COLOR_CLEAR_UNCLAMPED_VALUE_ATI
        // #define WGL_COLOR_CLEAR_UNCLAMPED_VALUE_ATI 0x8835
        public const int WGL_COLOR_CLEAR_UNCLAMPED_VALUE_ATI = 0x8835;
        #endregion WGL_COLOR_CLEAR_UNCLAMPED_VALUE_ATI

        #region WGL_TYPE_RGBA_FLOAT_ATI
        // #define WGL_TYPE_RGBA_FLOAT_ATI 0x21A0
        public const int WGL_TYPE_RGBA_FLOAT_ATI = 0x21A0;
        #endregion WGL_TYPE_RGBA_FLOAT_ATI
        #endregion WGL_ATI_pixel_format_float Constants
        #endregion WGL_ATI_pixel_format_float (278)
        #endregion ATI Extensions

        #region EXT Extensions
        #region WGL_EXT_extensions_string (168)
        #region WGL_EXT_extensions_string Methods
        #region string wglGetExtensionsStringEXT([In] IntPtr extensionPointer)
        // char* wglGetExtensionsStringEXT()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int()\r\ncall string [mscorlib]System.Runtime.InteropServices.Marshal::PtrToStringAnsi(native int)\r\nret")]
        public static string wglGetExtensionsStringEXT([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion string wglGetExtensionsStringEXT([In] IntPtr extensionPointer)
        #endregion WGL_EXT_extensions_string Methods
        #endregion WGL_EXT_extensions_string (168)

        #region WGL_EXT_make_current_read (169)
        #region WGL_EXT_make_current_read Methods
        #region int wglMakeContextCurrentEXT([In] IntPtr extensionPointer, IntPtr hDrawDC, IntPtr hReadDC, IntPtr hglrc)
        // BOOL wglMakeContextCurrentEXT(HDC hDrawDC, HDC hReadDC, HGLRC hglrc)
        [IlasmAttribute(".maxstack 4\r\nldarg hDrawDC\r\nldarg hReadDC\r\nldarg hglrc\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int,[in]native int)\r\nret")]
        public static int wglMakeContextCurrentEXT([In] IntPtr extensionPointer, IntPtr hDrawDC, IntPtr hReadDC, IntPtr hglrc) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglMakeContextCurrentEXT([In] IntPtr extensionPointer, IntPtr hDrawDC, IntPtr hReadDC, IntPtr hglrc)

        #region IntPtr wglGetCurrentReadDCEXT([In] IntPtr extensionPointer)
        // HDC wglGetCurrentReadDCEXT()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int()\r\nret")]
        public static IntPtr wglGetCurrentReadDCEXT([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglGetCurrentReadDCEXT([In] IntPtr extensionPointer)
        #endregion WGL_EXT_make_current_read Methods
        #endregion WGL_EXT_make_current_read (169)

        #region WGL_EXT_pixel_format (170)
        #region WGL_EXT_pixel_format Constants
        #region WGL_NUMBER_PIXEL_FORMATS_EXT
        // #define WGL_NUMBER_PIXEL_FORMATS_EXT 0x2000
        public const int WGL_NUMBER_PIXEL_FORMATS_EXT = 0x2000;
        #endregion WGL_NUMBER_PIXEL_FORMATS_EXT

        #region WGL_DRAW_TO_WINDOW_EXT
        // #define WGL_DRAW_TO_WINDOW_EXT 0x2001
        public const int WGL_DRAW_TO_WINDOW_EXT = 0x2001;
        #endregion WGL_DRAW_TO_WINDOW_EXT

        #region WGL_DRAW_TO_BITMAP_EXT
        // #define WGL_DRAW_TO_BITMAP_EXT 0x2002
        public const int WGL_DRAW_TO_BITMAP_EXT = 0x2002;
        #endregion WGL_DRAW_TO_BITMAP_EXT

        #region WGL_ACCELERATION_EXT
        // #define WGL_ACCELERATION_EXT 0x2003
        public const int WGL_ACCELERATION_EXT = 0x2003;
        #endregion WGL_ACCELERATION_EXT

        #region WGL_NEED_PALETTE_EXT
        // #define WGL_NEED_PALETTE_EXT 0x2004
        public const int WGL_NEED_PALETTE_EXT = 0x2004;
        #endregion WGL_NEED_PALETTE_EXT

        #region WGL_NEED_SYSTEM_PALETTE_EXT
        // #define WGL_NEED_SYSTEM_PALETTE_EXT 0x2005
        public const int WGL_NEED_SYSTEM_PALETTE_EXT = 0x2005;
        #endregion WGL_NEED_SYSTEM_PALETTE_EXT

        #region WGL_SWAP_LAYER_BUFFERS_EXT
        // #define WGL_SWAP_LAYER_BUFFERS_EXT 0x2006
        public const int WGL_SWAP_LAYER_BUFFERS_EXT = 0x2006;
        #endregion WGL_SWAP_LAYER_BUFFERS_EXT

        #region WGL_SWAP_METHOD_EXT
        // #define WGL_SWAP_METHOD_EXT 0x2007
        public const int WGL_SWAP_METHOD_EXT = 0x2007;
        #endregion WGL_SWAP_METHOD_EXT

        #region WGL_NUMBER_OVERLAYS_EXT
        // #define WGL_NUMBER_OVERLAYS_EXT 0x2008
        public const int WGL_NUMBER_OVERLAYS_EXT = 0x2008;
        #endregion WGL_NUMBER_OVERLAYS_EXT

        #region WGL_NUMBER_UNDERLAYS_EXT
        // #define WGL_NUMBER_UNDERLAYS_EXT 0x2009
        public const int WGL_NUMBER_UNDERLAYS_EXT = 0x2009;
        #endregion WGL_NUMBER_UNDERLAYS_EXT

        #region WGL_TRANSPARENT_EXT
        // #define WGL_TRANSPARENT_EXT 0x200A
        public const int WGL_TRANSPARENT_EXT = 0x200A;
        #endregion WGL_TRANSPARENT_EXT

        #region WGL_TRANSPARENT_VALUE_EXT
        // #define WGL_TRANSPARENT_VALUE_EXT 0x200B
        public const int WGL_TRANSPARENT_VALUE_EXT = 0x200B;
        #endregion WGL_TRANSPARENT_VALUE_EXT

        #region WGL_SHARE_DEPTH_EXT
        // #define WGL_SHARE_DEPTH_EXT 0x200C
        public const int WGL_SHARE_DEPTH_EXT = 0x200C;
        #endregion WGL_SHARE_DEPTH_EXT

        #region WGL_SHARE_STENCIL_EXT
        // #define WGL_SHARE_STENCIL_EXT 0x200D
        public const int WGL_SHARE_STENCIL_EXT = 0x200D;
        #endregion WGL_SHARE_STENCIL_EXT

        #region WGL_SHARE_ACCUM_EXT
        // #define WGL_SHARE_ACCUM_EXT 0x200E
        public const int WGL_SHARE_ACCUM_EXT = 0x200E;
        #endregion WGL_SHARE_ACCUM_EXT

        #region WGL_SUPPORT_GDI_EXT
        // #define WGL_SUPPORT_GDI_EXT 0x200F
        public const int WGL_SUPPORT_GDI_EXT = 0x200F;
        #endregion WGL_SUPPORT_GDI_EXT

        #region WGL_SUPPORT_OPENGL_EXT
        // #define WGL_SUPPORT_OPENGL_EXT 0x2010
        public const int WGL_SUPPORT_OPENGL_EXT = 0x2010;
        #endregion WGL_SUPPORT_OPENGL_EXT

        #region WGL_DOUBLE_BUFFER_EXT
        // #define WGL_DOUBLE_BUFFER_EXT 0x2011
        public const int WGL_DOUBLE_BUFFER_EXT = 0x2011;
        #endregion WGL_DOUBLE_BUFFER_EXT

        #region WGL_STEREO_EXT
        // #define WGL_STEREO_EXT 0x2012
        public const int WGL_STEREO_EXT = 0x2012;
        #endregion WGL_STEREO_EXT

        #region WGL_PIXEL_TYPE_EXT
        // #define WGL_PIXEL_TYPE_EXT 0x2013
        public const int WGL_PIXEL_TYPE_EXT = 0x2013;
        #endregion WGL_PIXEL_TYPE_EXT

        #region WGL_COLOR_BITS_EXT
        // #define WGL_COLOR_BITS_EXT 0x2014
        public const int WGL_COLOR_BITS_EXT = 0x2014;
        #endregion WGL_COLOR_BITS_EXT

        #region WGL_RED_BITS_EXT
        // #define WGL_RED_BITS_EXT 0x2015
        public const int WGL_RED_BITS_EXT = 0x2015;
        #endregion WGL_RED_BITS_EXT

        #region WGL_RED_SHIFT_EXT
        // #define WGL_RED_SHIFT_EXT 0x2016
        public const int WGL_RED_SHIFT_EXT = 0x2016;
        #endregion WGL_RED_SHIFT_EXT

        #region WGL_GREEN_BITS_EXT
        // #define WGL_GREEN_BITS_EXT 0x2017
        public const int WGL_GREEN_BITS_EXT = 0x2017;
        #endregion WGL_GREEN_BITS_EXT

        #region WGL_GREEN_SHIFT_EXT
        // #define WGL_GREEN_SHIFT_EXT 0x2018
        public const int WGL_GREEN_SHIFT_EXT = 0x2018;
        #endregion WGL_GREEN_SHIFT_EXT

        #region WGL_BLUE_BITS_EXT
        // #define WGL_BLUE_BITS_EXT 0x2019
        public const int WGL_BLUE_BITS_EXT = 0x2019;
        #endregion WGL_BLUE_BITS_EXT

        #region WGL_BLUE_SHIFT_EXT
        // #define WGL_BLUE_SHIFT_EXT 0x201A
        public const int WGL_BLUE_SHIFT_EXT = 0x201A;
        #endregion WGL_BLUE_SHIFT_EXT

        #region WGL_ALPHA_BITS_EXT
        // #define WGL_ALPHA_BITS_EXT 0x201B
        public const int WGL_ALPHA_BITS_EXT = 0x201B;
        #endregion WGL_ALPHA_BITS_EXT

        #region WGL_ALPHA_SHIFT_EXT
        // #define WGL_ALPHA_SHIFT_EXT 0x201C
        public const int WGL_ALPHA_SHIFT_EXT = 0x201C;
        #endregion WGL_ALPHA_SHIFT_EXT

        #region WGL_ACCUM_BITS_EXT
        // #define WGL_ACCUM_BITS_EXT 0x201D
        public const int WGL_ACCUM_BITS_EXT = 0x201D;
        #endregion WGL_ACCUM_BITS_EXT

        #region WGL_ACCUM_RED_BITS_EXT
        // #define WGL_ACCUM_RED_BITS_EXT 0x201E
        public const int WGL_ACCUM_RED_BITS_EXT = 0x201E;
        #endregion WGL_ACCUM_RED_BITS_EXT

        #region WGL_ACCUM_GREEN_BITS_EXT
        // #define WGL_ACCUM_GREEN_BITS_EXT 0x201F
        public const int WGL_ACCUM_GREEN_BITS_EXT = 0x201F;
        #endregion WGL_ACCUM_GREEN_BITS_EXT

        #region WGL_ACCUM_BLUE_BITS_EXT
        // #define WGL_ACCUM_BLUE_BITS_EXT 0x2020
        public const int WGL_ACCUM_BLUE_BITS_EXT = 0x2020;
        #endregion WGL_ACCUM_BLUE_BITS_EXT

        #region WGL_ACCUM_ALPHA_BITS_EXT
        // #define WGL_ACCUM_ALPHA_BITS_EXT 0x2021
        public const int WGL_ACCUM_ALPHA_BITS_EXT = 0x2021;
        #endregion WGL_ACCUM_ALPHA_BITS_EXT

        #region WGL_DEPTH_BITS_EXT
        // #define WGL_DEPTH_BITS_EXT 0x2022
        public const int WGL_DEPTH_BITS_EXT = 0x2022;
        #endregion WGL_DEPTH_BITS_EXT

        #region WGL_STENCIL_BITS_EXT
        // #define WGL_STENCIL_BITS_EXT 0x2023
        public const int WGL_STENCIL_BITS_EXT = 0x2023;
        #endregion WGL_STENCIL_BITS_EXT

        #region WGL_AUX_BUFFERS_EXT
        // #define WGL_AUX_BUFFERS_EXT 0x2024
        public const int WGL_AUX_BUFFERS_EXT = 0x2024;
        #endregion WGL_AUX_BUFFERS_EXT

        #region WGL_NO_ACCELERATION_EXT
        // #define WGL_NO_ACCELERATION_EXT 0x2025
        public const int WGL_NO_ACCELERATION_EXT = 0x2025;
        #endregion WGL_NO_ACCELERATION_EXT

        #region WGL_GENERIC_ACCELERATION_EXT
        // #define WGL_GENERIC_ACCELERATION_EXT 0x2026
        public const int WGL_GENERIC_ACCELERATION_EXT = 0x2026;
        #endregion WGL_GENERIC_ACCELERATION_EXT

        #region WGL_FULL_ACCELERATION_EXT
        // #define WGL_FULL_ACCELERATION_EXT 0x2027
        public const int WGL_FULL_ACCELERATION_EXT = 0x2027;
        #endregion WGL_FULL_ACCELERATION_EXT

        #region WGL_SWAP_EXCHANGE_EXT
        // #define WGL_SWAP_EXCHANGE_EXT 0x2028
        public const int WGL_SWAP_EXCHANGE_EXT = 0x2028;
        #endregion WGL_SWAP_EXCHANGE_EXT

        #region WGL_SWAP_COPY_EXT
        // #define WGL_SWAP_COPY_EXT 0x2029
        public const int WGL_SWAP_COPY_EXT = 0x2029;
        #endregion WGL_SWAP_COPY_EXT

        #region WGL_SWAP_UNDEFINED_EXT
        // #define WGL_SWAP_UNDEFINED_EXT 0x202A
        public const int WGL_SWAP_UNDEFINED_EXT = 0x202A;
        #endregion WGL_SWAP_UNDEFINED_EXT

        #region WGL_TYPE_RGBA_EXT
        // #define WGL_TYPE_RGBA_EXT 0x202B
        public const int WGL_TYPE_RGBA_EXT = 0x202B;
        #endregion WGL_TYPE_RGBA_EXT

        #region WGL_TYPE_COLORINDEX_EXT
        // #define WGL_TYPE_COLORINDEX_EXT 0x202C
        public const int WGL_TYPE_COLORINDEX_EXT = 0x202C;
        #endregion WGL_TYPE_COLORINDEX_EXT
        #endregion WGL_EXT_pixel_format Constants

        #region WGL_EXT_pixel_format Methods
        #region Overloads for BOOL wglGetPixelFormatAttribivEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        #region int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, int[] piValues)
        // BOOL wglGetPixelFormatAttribivEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in]int32[],[out]int32[])\r\nret")]
        public static int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, int[] piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, int[] piValues)

        #region int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out int piValues)
        // BOOL wglGetPixelFormatAttribivEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in][out]int32,[out]int32)\r\nret")]
        public static int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out int piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out int piValues)

        #region int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, IntPtr piAttributes, IntPtr piValues)
        // BOOL wglGetPixelFormatAttribivEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in]native int,[out]native int)\r\nret")]
        public static int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, IntPtr piAttributes, IntPtr piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, IntPtr piAttributes, IntPtr piValues)

        #region int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, IntPtr piAttributes, IntPtr piValues)
        // BOOL wglGetPixelFormatAttribivEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in]native int,[out]native int)\r\nret")]
        public static int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, IntPtr piAttributes, IntPtr piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, IntPtr piAttributes, IntPtr piValues)

        #region int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref int piAttributes, out int piValues)
        // BOOL wglGetPixelFormatAttribivEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in][out]int32,[out]int32)\r\nret")]
        public static int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref int piAttributes, out int piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref int piAttributes, out int piValues)

        #region int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, int[] piValues)
        // BOOL wglGetPixelFormatAttribivEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in]int32[],[out]int32[])\r\nret")]
        public static int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, int[] piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, int[] piValues)

        #region int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, int* piValues)
        // BOOL wglGetPixelFormatAttribivEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg piValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in]int32*,[out]int32*)\r\nret")]
        public static unsafe int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, int* piValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribivEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, int* piValues)
        #endregion Overloads for BOOL wglGetPixelFormatAttribivEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLint* piValues)

        #region Overloads for BOOL wglGetPixelFormatAttribfvEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        #region int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, float[] pfValues)
        // BOOL wglGetPixelFormatAttribfvEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in]int32[],[out]float32[])\r\nret")]
        public static int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, float[] pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, float[] pfValues)

        #region int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out float pfValues)
        // BOOL wglGetPixelFormatAttribfvEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in][out]int32,[out]float32)\r\nret")]
        public static int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out float pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out float pfValues)

        #region int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, IntPtr piAttributes, IntPtr pfValues)
        // BOOL wglGetPixelFormatAttribfvEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]int32,[in]native int,[out]native int)\r\nret")]
        public static int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, IntPtr piAttributes, IntPtr pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, IntPtr piAttributes, IntPtr pfValues)

        #region int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, IntPtr piAttributes, IntPtr pfValues)
        // BOOL wglGetPixelFormatAttribfvEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in]native int,[out]native int)\r\nret")]
        public static int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, IntPtr piAttributes, IntPtr pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, IntPtr piAttributes, IntPtr pfValues)

        #region int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref int piAttributes, out float pfValues)
        // BOOL wglGetPixelFormatAttribfvEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in][out]int32,[out]float32)\r\nret")]
        public static int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref int piAttributes, out float pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, ref int piAttributes, out float pfValues)

        #region int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, float[] pfValues)
        // BOOL wglGetPixelFormatAttribfvEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in]int32[],[out]float32[])\r\nret")]
        public static int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, float[] pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int[] piAttributes, float[] pfValues)

        #region int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, float* pfValues)
        // BOOL wglGetPixelFormatAttribfvEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg iPixelFormat\r\nldarg iLayerPlane\r\nldarg nAttributes\r\nldarg piAttributes\r\nldarg pfValues\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32,[in]unsigned int32,[in]int32*,[out]float32*)\r\nret")]
        public static unsafe int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, float* pfValues) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetPixelFormatAttribfvEXT([In] IntPtr extensionPointer, IntPtr hdc, int iPixelFormat, int iLayerPlane, uint nAttributes, int* piAttributes, float* pfValues)
        #endregion Overloads for BOOL wglGetPixelFormatAttribfvEXT(HDC hdc, GLint iPixelFormat, GLint iLayerPlane, GLuint nAttributes, const GLint* piAttributes, GLfloat* pfValues)

        #region Overloads for BOOL wglChoosePixelFormatEXT(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        #region int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, int nMaxFormats, int[] piFormats, out int nNumFormats)
        // BOOL wglChoosePixelFormatEXT(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32[],[in]float32[],[in]int32,[in]int32[],[out]int32)\r\nret")]
        public static int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, int nMaxFormats, int[] piFormats, out int nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, int nMaxFormats, int[] piFormats, out int nNumFormats)

        #region int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, ref int piAttribIList, ref float pfAttribFList, int nMaxFormats, ref int piFormats, out int nNumFormats)
        // BOOL wglChoosePixelFormatEXT(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in][out]int32,[in][out]float32,[in]int32,[in][out]int32,[out]int32)\r\nret")]
        public static int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, ref int piAttribIList, ref float pfAttribFList, int nMaxFormats, ref int piFormats, out int nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, ref int piAttribIList, ref float pfAttribFList, int nMaxFormats, ref int piFormats, out int nNumFormats)

        #region int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, IntPtr piAttribIList, IntPtr pfAttribFList, int nMaxFormats, IntPtr piFormats, out int nNumFormats)
        // BOOL wglChoosePixelFormatEXT(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int,[in]native int,[in]int32,[in]native int,[out]int32)\r\nret")]
        public static int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, IntPtr piAttribIList, IntPtr pfAttribFList, int nMaxFormats, IntPtr piFormats, out int nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, IntPtr piAttribIList, IntPtr pfAttribFList, int nMaxFormats, IntPtr piFormats, out int nNumFormats)

        #region int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, IntPtr piAttribIList, IntPtr pfAttribFList, uint nMaxFormats, IntPtr piFormats, out uint nNumFormats)
        // BOOL wglChoosePixelFormatEXT(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int,[in]native int,[in]unsigned int32,[in]native int,[out]unsigned int32)\r\nret")]
        public static int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, IntPtr piAttribIList, IntPtr pfAttribFList, uint nMaxFormats, IntPtr piFormats, out uint nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, IntPtr piAttribIList, IntPtr pfAttribFList, uint nMaxFormats, IntPtr piFormats, out uint nNumFormats)

        #region int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, ref int piAttribIList, ref float pfAttribFList, uint nMaxFormats, ref int piFormats, out uint nNumFormats)
        // BOOL wglChoosePixelFormatEXT(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in][out]int32,[in][out]float32,[in]unsigned int32,[in][out]int32,[out]unsigned int32)\r\nret")]
        public static int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, ref int piAttribIList, ref float pfAttribFList, uint nMaxFormats, ref int piFormats, out uint nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, ref int piAttribIList, ref float pfAttribFList, uint nMaxFormats, ref int piFormats, out uint nNumFormats)

        #region int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, uint nMaxFormats, int[] piFormats, out uint nNumFormats)
        // BOOL wglChoosePixelFormatEXT(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32[],[in]float32[],[in]unsigned int32,[in]int32[],[out]unsigned int32)\r\nret")]
        public static int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, uint nMaxFormats, int[] piFormats, out uint nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, uint nMaxFormats, int[] piFormats, out uint nNumFormats)

        #region int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, int* piAttribIList, float* pfAttribFList, uint nMaxFormats, int* piFormats, out uint nNumFormats)
        // BOOL wglChoosePixelFormatEXT(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        [CLSCompliant(false), IlasmAttribute(".maxstack 7\r\nldarg hdc\r\nldarg piAttribIList\r\nldarg pfAttribFList\r\nldarg nMaxFormats\r\nldarg piFormats\r\nldarg nNumFormats\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32*,[in]float32*,[in]unsigned int32,[in]int32*,[out]unsigned int32)\r\nret")]
        public static unsafe int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, int* piAttribIList, float* pfAttribFList, uint nMaxFormats, int* piFormats, out uint nNumFormats) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglChoosePixelFormatEXT([In] IntPtr extensionPointer, IntPtr hdc, int* piAttribIList, float* pfAttribFList, uint nMaxFormats, int* piFormats, out uint nNumFormats)
        #endregion Overloads for BOOL wglChoosePixelFormatEXT(HDC hdc, const GLint* piAttribIList, const GLfloat* pfAttribFList, GLuint nMaxFormats, GLint* piFormats, GLuint* nNumFormats)
        #endregion WGL_EXT_pixel_format Methods
        #endregion WGL_EXT_pixel_format (170)

        #region WGL_EXT_swap_control (172)
        #region WGL_EXT_swap_control Methods
        #region int wglSwapIntervalEXT([In] IntPtr extensionPointer, int interval)
        // BOOL wglSwapIntervalEXT(GLint interval)
        [IlasmAttribute(".maxstack 2\r\nldarg interval\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]int32)\r\nret")]
        public static int wglSwapIntervalEXT([In] IntPtr extensionPointer, int interval) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSwapIntervalEXT([In] IntPtr extensionPointer, int interval)

        #region int wglGetSwapIntervalEXT([In] IntPtr extensionPointer)
        // GLint wglGetSwapIntervalEXT()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32()\r\nret")]
        public static int wglGetSwapIntervalEXT([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetSwapIntervalEXT([In] IntPtr extensionPointer)
        #endregion WGL_EXT_swap_control Methods
        #endregion WGL_EXT_swap_control (172)

        #region WGL_EXT_depth_float (177)
        #region WGL_EXT_depth_float Constants
        #region WGL_DEPTH_FLOAT_EXT
        // #define WGL_DEPTH_FLOAT_EXT 0x2040
        public const int WGL_DEPTH_FLOAT_EXT = 0x2040;
        #endregion WGL_DEPTH_FLOAT_EXT
        #endregion WGL_EXT_depth_float Constants
        #endregion WGL_EXT_depth_float (177)

        #region WGL_EXT_multisample (209)
        #region WGL_EXT_multisample Constants
        #region WGL_SAMPLE_BUFFERS_EXT
        // #define WGL_SAMPLE_BUFFERS_EXT 0x2041
        public const int WGL_SAMPLE_BUFFERS_EXT = 0x2041;
        #endregion WGL_SAMPLE_BUFFERS_EXT

        #region WGL_SAMPLES_EXT
        // #define WGL_SAMPLES_EXT 0x2042
        public const int WGL_SAMPLES_EXT = 0x2042;
        #endregion WGL_SAMPLES_EXT
        #endregion WGL_EXT_multisample Constants
        #endregion WGL_EXT_multisample (209)

        #region WGL_EXT_pbuffer (271)
        #region WGL_EXT_pbuffer Constants
        #region WGL_DRAW_TO_PBUFFER_EXT
        // #define WGL_DRAW_TO_PBUFFER_EXT 0x202D
        public const int WGL_DRAW_TO_PBUFFER_EXT = 0x202D;
        #endregion WGL_DRAW_TO_PBUFFER_EXT

        #region WGL_MAX_PBUFFER_PIXELS_EXT
        // #define WGL_MAX_PBUFFER_PIXELS_EXT 0x202E
        public const int WGL_MAX_PBUFFER_PIXELS_EXT = 0x202E;
        #endregion WGL_MAX_PBUFFER_PIXELS_EXT

        #region WGL_MAX_PBUFFER_WIDTH_EXT
        // #define WGL_MAX_PBUFFER_WIDTH_EXT 0x202F
        public const int WGL_MAX_PBUFFER_WIDTH_EXT = 0x202F;
        #endregion WGL_MAX_PBUFFER_WIDTH_EXT

        #region WGL_MAX_PBUFFER_HEIGHT_EXT
        // #define WGL_MAX_PBUFFER_HEIGHT_EXT 0x2030
        public const int WGL_MAX_PBUFFER_HEIGHT_EXT = 0x2030;
        #endregion WGL_MAX_PBUFFER_HEIGHT_EXT

        #region WGL_OPTIMAL_PBUFFER_WIDTH_EXT
        // #define WGL_OPTIMAL_PBUFFER_WIDTH_EXT 0x2031
        public const int WGL_OPTIMAL_PBUFFER_WIDTH_EXT = 0x2031;
        #endregion WGL_OPTIMAL_PBUFFER_WIDTH_EXT

        #region WGL_OPTIMAL_PBUFFER_HEIGHT_EXT
        // #define WGL_OPTIMAL_PBUFFER_HEIGHT_EXT 0x2032
        public const int WGL_OPTIMAL_PBUFFER_HEIGHT_EXT = 0x2032;
        #endregion WGL_OPTIMAL_PBUFFER_HEIGHT_EXT

        #region WGL_PBUFFER_LARGEST_EXT
        // #define WGL_PBUFFER_LARGEST_EXT 0x2033
        public const int WGL_PBUFFER_LARGEST_EXT = 0x2033;
        #endregion WGL_PBUFFER_LARGEST_EXT

        #region WGL_PBUFFER_WIDTH_EXT
        // #define WGL_PBUFFER_WIDTH_EXT 0x2034
        public const int WGL_PBUFFER_WIDTH_EXT = 0x2034;
        #endregion WGL_PBUFFER_WIDTH_EXT

        #region WGL_PBUFFER_HEIGHT_EXT
        // #define WGL_PBUFFER_HEIGHT_EXT 0x2035
        public const int WGL_PBUFFER_HEIGHT_EXT = 0x2035;
        #endregion WGL_PBUFFER_HEIGHT_EXT
        #endregion WGL_EXT_pbuffer Constants

        #region WGL_EXT_pbuffer Methods
        #region Overloads for HANDLE wglCreatePbufferEXT(HDC hDC, GLint iPixelFormat, GLint iWidth, GLint iHeight, const GLint* piAttribList)
        #region IntPtr wglCreatePbufferEXT([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, ref int piAttribList)
        // HANDLE wglCreatePbufferEXT(HDC hDC, GLint iPixelFormat, GLint iWidth, GLint iHeight, const GLint* piAttribList)
        [IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iPixelFormat\r\nldarg iWidth\r\nldarg iHeight\r\nldarg piAttribList\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int,[in]int32,[in]int32,[in]int32,[in][out]int32)\r\nret")]
        public static IntPtr wglCreatePbufferEXT([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, ref int piAttribList) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglCreatePbufferEXT([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, ref int piAttribList)

        #region IntPtr wglCreatePbufferEXT([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int[] piAttribList)
        // HANDLE wglCreatePbufferEXT(HDC hDC, GLint iPixelFormat, GLint iWidth, GLint iHeight, const GLint* piAttribList)
        [IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iPixelFormat\r\nldarg iWidth\r\nldarg iHeight\r\nldarg piAttribList\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int,[in]int32,[in]int32,[in]int32,[in]int32[])\r\nret")]
        public static IntPtr wglCreatePbufferEXT([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int[] piAttribList) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglCreatePbufferEXT([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int[] piAttribList)

        #region IntPtr wglCreatePbufferEXT([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, IntPtr piAttribList)
        // HANDLE wglCreatePbufferEXT(HDC hDC, GLint iPixelFormat, GLint iWidth, GLint iHeight, const GLint* piAttribList)
        [IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iPixelFormat\r\nldarg iWidth\r\nldarg iHeight\r\nldarg piAttribList\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int,[in]int32,[in]int32,[in]int32,[in]native int)\r\nret")]
        public static IntPtr wglCreatePbufferEXT([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, IntPtr piAttribList) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglCreatePbufferEXT([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, IntPtr piAttribList)

        #region IntPtr wglCreatePbufferEXT([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int* piAttribList)
        // HANDLE wglCreatePbufferEXT(HDC hDC, GLint iPixelFormat, GLint iWidth, GLint iHeight, const GLint* piAttribList)
        [CLSCompliant(false), IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iPixelFormat\r\nldarg iWidth\r\nldarg iHeight\r\nldarg piAttribList\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int,[in]int32,[in]int32,[in]int32,[in]int32*)\r\nret")]
        public static unsafe IntPtr wglCreatePbufferEXT([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int* piAttribList) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglCreatePbufferEXT([In] IntPtr extensionPointer, IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int* piAttribList)
        #endregion Overloads for HANDLE wglCreatePbufferEXT(HDC hDC, GLint iPixelFormat, GLint iWidth, GLint iHeight, const GLint* piAttribList)

        #region IntPtr wglGetPbufferDCEXT([In] IntPtr extensionPointer, IntPtr hPbuffer)
        // HDC wglGetPbufferDCEXT(HANDLE hPbuffer)
        [IlasmAttribute(".maxstack 2\r\nldarg hPbuffer\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int)\r\nret")]
        public static IntPtr wglGetPbufferDCEXT([In] IntPtr extensionPointer, IntPtr hPbuffer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglGetPbufferDCEXT([In] IntPtr extensionPointer, IntPtr hPbuffer)

        #region int wglReleasePbufferDCEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, IntPtr hDC)
        // GLint wglReleasePbufferDCEXT(HANDLE hPbuffer, HDC hDC)
        [IlasmAttribute(".maxstack 3\r\nldarg hPbuffer\r\nldarg hDC\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int)\r\nret")]
        public static int wglReleasePbufferDCEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, IntPtr hDC) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglReleasePbufferDCEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, IntPtr hDC)

        #region int wglDestroyPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer)
        // BOOL wglDestroyPbufferEXT(HANDLE hPbuffer)
        [IlasmAttribute(".maxstack 2\r\nldarg hPbuffer\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int)\r\nret")]
        public static int wglDestroyPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglDestroyPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer)

        #region Overloads for BOOL wglQueryPbufferEXT(HANDLE hPbuffer, GLint iAttribute, GLint* piValue)
        #region int wglQueryPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, ref int piValue)
        // BOOL wglQueryPbufferEXT(HANDLE hPbuffer, GLint iAttribute, GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hPbuffer\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in][out]int32)\r\nret")]
        public static int wglQueryPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, ref int piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglQueryPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, ref int piValue)

        #region int wglQueryPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, int[] piValue)
        // BOOL wglQueryPbufferEXT(HANDLE hPbuffer, GLint iAttribute, GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hPbuffer\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32[])\r\nret")]
        public static int wglQueryPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, int[] piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglQueryPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, int[] piValue)

        #region int wglQueryPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, IntPtr piValue)
        // BOOL wglQueryPbufferEXT(HANDLE hPbuffer, GLint iAttribute, GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hPbuffer\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]native int)\r\nret")]
        public static int wglQueryPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, IntPtr piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglQueryPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, IntPtr piValue)

        #region int wglQueryPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, int* piValue)
        // BOOL wglQueryPbufferEXT(HANDLE hPbuffer, GLint iAttribute, GLint* piValue)
        [CLSCompliant(false), IlasmAttribute(".maxstack 4\r\nldarg hPbuffer\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32*)\r\nret")]
        public static unsafe int wglQueryPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, int* piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglQueryPbufferEXT([In] IntPtr extensionPointer, IntPtr hPbuffer, int iAttribute, int* piValue)
        #endregion Overloads for BOOL wglQueryPbufferEXT(HANDLE hPbuffer, GLint iAttribute, GLint* piValue)
        #endregion WGL_EXT_pbuffer Methods
        #endregion WGL_EXT_pbuffer (271)
        #endregion EXT Extensions

        #region I3D Extensions
        #region WGL_I3D_digital_video_control (250)
        #region WGL_I3D_digital_video_control Constants
        #region WGL_DIGITAL_VIDEO_CURSOR_ALPHA_FRAMEBUFFER_I3D
        // #define WGL_DIGITAL_VIDEO_CURSOR_ALPHA_FRAMEBUFFER_I3D 0x2050
        public const int WGL_DIGITAL_VIDEO_CURSOR_ALPHA_FRAMEBUFFER_I3D = 0x2050;
        #endregion WGL_DIGITAL_VIDEO_CURSOR_ALPHA_FRAMEBUFFER_I3D

        #region WGL_DIGITAL_VIDEO_CURSOR_ALPHA_VALUE_I3D
        // #define WGL_DIGITAL_VIDEO_CURSOR_ALPHA_VALUE_I3D 0x2051
        public const int WGL_DIGITAL_VIDEO_CURSOR_ALPHA_VALUE_I3D = 0x2051;
        #endregion WGL_DIGITAL_VIDEO_CURSOR_ALPHA_VALUE_I3D

        #region WGL_DIGITAL_VIDEO_CURSOR_INCLUDED_I3D
        // #define WGL_DIGITAL_VIDEO_CURSOR_INCLUDED_I3D 0x2052
        public const int WGL_DIGITAL_VIDEO_CURSOR_INCLUDED_I3D = 0x2052;
        #endregion WGL_DIGITAL_VIDEO_CURSOR_INCLUDED_I3D

        #region WGL_DIGITAL_VIDEO_GAMMA_CORRECTED_I3D
        // #define WGL_DIGITAL_VIDEO_GAMMA_CORRECTED_I3D 0x2053
        public const int WGL_DIGITAL_VIDEO_GAMMA_CORRECTED_I3D = 0x2053;
        #endregion WGL_DIGITAL_VIDEO_GAMMA_CORRECTED_I3D
        #endregion WGL_I3D_digital_video_control Constants

        #region WGL_I3D_digital_video_control Methods
        #region Overloads for BOOL wglGetDigitalVideoParametersI3D(HDC hDC, GLint iAttribute, GLint* piValue)
        #region int wglGetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, out int piValue)
        // BOOL wglGetDigitalVideoParametersI3D(HDC hDC, GLint iAttribute, GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]int32)\r\nret")]
        public static int wglGetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, out int piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, out int piValue)

        #region int wglGetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int[] piValue)
        // BOOL wglGetDigitalVideoParametersI3D(HDC hDC, GLint iAttribute, GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]int32[])\r\nret")]
        public static int wglGetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int[] piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int[] piValue)

        #region int wglGetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, IntPtr piValue)
        // BOOL wglGetDigitalVideoParametersI3D(HDC hDC, GLint iAttribute, GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]native int)\r\nret")]
        public static int wglGetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, IntPtr piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, IntPtr piValue)

        #region int wglGetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int* piValue)
        // BOOL wglGetDigitalVideoParametersI3D(HDC hDC, GLint iAttribute, GLint* piValue)
        [CLSCompliant(false), IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]int32*)\r\nret")]
        public static unsafe int wglGetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int* piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int* piValue)
        #endregion Overloads for BOOL wglGetDigitalVideoParametersI3D(HDC hDC, GLint iAttribute, GLint* piValue)

        #region Overloads for BOOL wglSetDigitalVideoParametersI3D(HDC hDC, GLint iAttribute, const GLint* piValue)
        #region int wglSetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, ref int piValue)
        // BOOL wglSetDigitalVideoParametersI3D(HDC hDC, GLint iAttribute, const GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in][out]int32)\r\nret")]
        public static int wglSetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, ref int piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, ref int piValue)

        #region int wglSetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int[] piValue)
        // BOOL wglSetDigitalVideoParametersI3D(HDC hDC, GLint iAttribute, const GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32[])\r\nret")]
        public static int wglSetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int[] piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int[] piValue)

        #region int wglSetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, IntPtr piValue)
        // BOOL wglSetDigitalVideoParametersI3D(HDC hDC, GLint iAttribute, const GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]native int)\r\nret")]
        public static int wglSetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, IntPtr piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, IntPtr piValue)

        #region int wglSetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int* piValue)
        // BOOL wglSetDigitalVideoParametersI3D(HDC hDC, GLint iAttribute, const GLint* piValue)
        [CLSCompliant(false), IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32*)\r\nret")]
        public static unsafe int wglSetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int* piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetDigitalVideoParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int* piValue)
        #endregion Overloads for BOOL wglSetDigitalVideoParametersI3D(HDC hDC, GLint iAttribute, const GLint* piValue)
        #endregion WGL_I3D_digital_video_control Methods
        #endregion WGL_I3D_digital_video_control (250)

        #region WGL_I3D_gamma (251)
        #region WGL_I3D_gamma Constants
        #region WGL_GAMMA_TABLE_SIZE_I3D
        // #define WGL_GAMMA_TABLE_SIZE_I3D 0x204E
        public const int WGL_GAMMA_TABLE_SIZE_I3D = 0x204E;
        #endregion WGL_GAMMA_TABLE_SIZE_I3D

        #region WGL_GAMMA_EXCLUDE_DESKTOP_I3D
        // #define WGL_GAMMA_EXCLUDE_DESKTOP_I3D 0x204F
        public const int WGL_GAMMA_EXCLUDE_DESKTOP_I3D = 0x204F;
        #endregion WGL_GAMMA_EXCLUDE_DESKTOP_I3D
        #endregion WGL_I3D_gamma Constants

        #region WGL_I3D_gamma Methods
        #region Overloads for BOOL wglGetGammaTableParametersI3D(HDC hDC, GLint iAttribute, GLint* piValue)
        #region int wglGetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, out int piValue)
        // BOOL wglGetGammaTableParametersI3D(HDC hDC, GLint iAttribute, GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]int32)\r\nret")]
        public static int wglGetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, out int piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, out int piValue)

        #region int wglGetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int[] piValue)
        // BOOL wglGetGammaTableParametersI3D(HDC hDC, GLint iAttribute, GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]int32[])\r\nret")]
        public static int wglGetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int[] piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int[] piValue)

        #region int wglGetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, IntPtr piValue)
        // BOOL wglGetGammaTableParametersI3D(HDC hDC, GLint iAttribute, GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]native int)\r\nret")]
        public static int wglGetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, IntPtr piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, IntPtr piValue)

        #region int wglGetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int* piValue)
        // BOOL wglGetGammaTableParametersI3D(HDC hDC, GLint iAttribute, GLint* piValue)
        [CLSCompliant(false), IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]int32*)\r\nret")]
        public static unsafe int wglGetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int* piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int* piValue)
        #endregion Overloads for BOOL wglGetGammaTableParametersI3D(HDC hDC, GLint iAttribute, GLint* piValue)

        #region Overloads for BOOL wglSetGammaTableParametersI3D(HDC hDC, GLint iAttribute, const GLint* piValue)
        #region int wglSetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, ref int piValue)
        // BOOL wglSetGammaTableParametersI3D(HDC hDC, GLint iAttribute, const GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in][out]int32)\r\nret")]
        public static int wglSetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, ref int piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, ref int piValue)

        #region int wglSetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int[] piValue)
        // BOOL wglSetGammaTableParametersI3D(HDC hDC, GLint iAttribute, const GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32[])\r\nret")]
        public static int wglSetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int[] piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int[] piValue)

        #region int wglSetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, IntPtr piValue)
        // BOOL wglSetGammaTableParametersI3D(HDC hDC, GLint iAttribute, const GLint* piValue)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]native int)\r\nret")]
        public static int wglSetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, IntPtr piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, IntPtr piValue)

        #region int wglSetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int* piValue)
        // BOOL wglSetGammaTableParametersI3D(HDC hDC, GLint iAttribute, const GLint* piValue)
        [CLSCompliant(false), IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg iAttribute\r\nldarg piValue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int32*)\r\nret")]
        public static unsafe int wglSetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int* piValue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetGammaTableParametersI3D([In] IntPtr extensionPointer, IntPtr hDC, int iAttribute, int* piValue)
        #endregion Overloads for BOOL wglSetGammaTableParametersI3D(HDC hDC, GLint iAttribute, const GLint* piValue)

        #region Overloads for BOOL wglGetGammaTableI3D(HDC hDC, GLint iEntries, GLUSHORT* puRed, GLUSHORT* puGreen, GLUSHORT* puBlue)
        #region int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, short[] puRed, short[] puGreen, short[] puBlue)
        // BOOL wglGetGammaTableI3D(HDC hDC, GLint iEntries, GLUSHORT* puRed, GLUSHORT* puGreen, GLUSHORT* puBlue)
        [IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iEntries\r\nldarg puRed\r\nldarg puGreen\r\nldarg puBlue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]int16[],[out]int16[],[out]int16[])\r\nret")]
        public static int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, short[] puRed, short[] puGreen, short[] puBlue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, short[] puRed, short[] puGreen, short[] puBlue)

        #region int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, out short puRed, out short puGreen, out short puBlue)
        // BOOL wglGetGammaTableI3D(HDC hDC, GLint iEntries, GLUSHORT* puRed, GLUSHORT* puGreen, GLUSHORT* puBlue)
        [IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iEntries\r\nldarg puRed\r\nldarg puGreen\r\nldarg puBlue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]int16,[out]int16,[out]int16)\r\nret")]
        public static int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, out short puRed, out short puGreen, out short puBlue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, out short puRed, out short puGreen, out short puBlue)

        #region int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, IntPtr puRed, IntPtr puGreen, IntPtr puBlue)
        // BOOL wglGetGammaTableI3D(HDC hDC, GLint iEntries, GLUSHORT* puRed, GLUSHORT* puGreen, GLUSHORT* puBlue)
        [IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iEntries\r\nldarg puRed\r\nldarg puGreen\r\nldarg puBlue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]native int,[out]native int,[out]native int)\r\nret")]
        public static int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, IntPtr puRed, IntPtr puGreen, IntPtr puBlue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, IntPtr puRed, IntPtr puGreen, IntPtr puBlue)

        #region int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, out ushort puRed, out ushort puGreen, out ushort puBlue)
        // BOOL wglGetGammaTableI3D(HDC hDC, GLint iEntries, GLUSHORT* puRed, GLUSHORT* puGreen, GLUSHORT* puBlue)
        [CLSCompliant(false), IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iEntries\r\nldarg puRed\r\nldarg puGreen\r\nldarg puBlue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]unsigned int16,[out]unsigned int16,[out]unsigned int16)\r\nret")]
        public static int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, out ushort puRed, out ushort puGreen, out ushort puBlue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, out ushort puRed, out ushort puGreen, out ushort puBlue)

        #region int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ushort[] puRed, ushort[] puGreen, ushort[] puBlue)
        // BOOL wglGetGammaTableI3D(HDC hDC, GLint iEntries, GLUSHORT* puRed, GLUSHORT* puGreen, GLUSHORT* puBlue)
        [CLSCompliant(false), IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iEntries\r\nldarg puRed\r\nldarg puGreen\r\nldarg puBlue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]unsigned int16[],[out]unsigned int16[],[out]unsigned int16[])\r\nret")]
        public static int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ushort[] puRed, ushort[] puGreen, ushort[] puBlue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ushort[] puRed, ushort[] puGreen, ushort[] puBlue)

        #region int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ushort* puRed, ushort* puGreen, ushort* puBlue)
        // BOOL wglGetGammaTableI3D(HDC hDC, GLint iEntries, GLUSHORT* puRed, GLUSHORT* puGreen, GLUSHORT* puBlue)
        [CLSCompliant(false), IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iEntries\r\nldarg puRed\r\nldarg puGreen\r\nldarg puBlue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[out]unsigned int16*,[out]unsigned int16*,[out]unsigned int16*)\r\nret")]
        public static unsafe int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ushort* puRed, ushort* puGreen, ushort* puBlue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ushort* puRed, ushort* puGreen, ushort* puBlue)
        #endregion Overloads for BOOL wglGetGammaTableI3D(HDC hDC, GLint iEntries, GLUSHORT* puRed, GLUSHORT* puGreen, GLUSHORT* puBlue)

        #region Overloads for BOOL wglSetGammaTableI3D(HDC hDC, GLint iEntries, const GLUSHORT* puRed, const GLUSHORT* puGreen, const GLUSHORT* puBlue)
        #region int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, short[] puRed, short[] puGreen, short[] puBlue)
        // BOOL wglSetGammaTableI3D(HDC hDC, GLint iEntries, const GLUSHORT* puRed, const GLUSHORT* puGreen, const GLUSHORT* puBlue)
        [IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iEntries\r\nldarg puRed\r\nldarg puGreen\r\nldarg puBlue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]int16[],[in]int16[],[in]int16[])\r\nret")]
        public static int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, short[] puRed, short[] puGreen, short[] puBlue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, short[] puRed, short[] puGreen, short[] puBlue)

        #region int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ref short puRed, ref short puGreen, ref short puBlue)
        // BOOL wglSetGammaTableI3D(HDC hDC, GLint iEntries, const GLUSHORT* puRed, const GLUSHORT* puGreen, const GLUSHORT* puBlue)
        [IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iEntries\r\nldarg puRed\r\nldarg puGreen\r\nldarg puBlue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in][out]int16,[in][out]int16,[in][out]int16)\r\nret")]
        public static int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ref short puRed, ref short puGreen, ref short puBlue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ref short puRed, ref short puGreen, ref short puBlue)

        #region int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, IntPtr puRed, IntPtr puGreen, IntPtr puBlue)
        // BOOL wglSetGammaTableI3D(HDC hDC, GLint iEntries, const GLUSHORT* puRed, const GLUSHORT* puGreen, const GLUSHORT* puBlue)
        [IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iEntries\r\nldarg puRed\r\nldarg puGreen\r\nldarg puBlue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]native int,[in]native int,[in]native int)\r\nret")]
        public static int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, IntPtr puRed, IntPtr puGreen, IntPtr puBlue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, IntPtr puRed, IntPtr puGreen, IntPtr puBlue)

        #region int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ref ushort puRed, ref ushort puGreen, ref ushort puBlue)
        // BOOL wglSetGammaTableI3D(HDC hDC, GLint iEntries, const GLUSHORT* puRed, const GLUSHORT* puGreen, const GLUSHORT* puBlue)
        [CLSCompliant(false), IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iEntries\r\nldarg puRed\r\nldarg puGreen\r\nldarg puBlue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in][out]unsigned int16,[in][out]unsigned int16,[in][out]unsigned int16)\r\nret")]
        public static int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ref ushort puRed, ref ushort puGreen, ref ushort puBlue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ref ushort puRed, ref ushort puGreen, ref ushort puBlue)

        #region int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ushort[] puRed, ushort[] puGreen, ushort[] puBlue)
        // BOOL wglSetGammaTableI3D(HDC hDC, GLint iEntries, const GLUSHORT* puRed, const GLUSHORT* puGreen, const GLUSHORT* puBlue)
        [CLSCompliant(false), IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iEntries\r\nldarg puRed\r\nldarg puGreen\r\nldarg puBlue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]unsigned int16[],[in]unsigned int16[],[in]unsigned int16[])\r\nret")]
        public static int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ushort[] puRed, ushort[] puGreen, ushort[] puBlue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ushort[] puRed, ushort[] puGreen, ushort[] puBlue)

        #region int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ushort* puRed, ushort* puGreen, ushort* puBlue)
        // BOOL wglSetGammaTableI3D(HDC hDC, GLint iEntries, const GLUSHORT* puRed, const GLUSHORT* puGreen, const GLUSHORT* puBlue)
        [CLSCompliant(false), IlasmAttribute(".maxstack 6\r\nldarg hDC\r\nldarg iEntries\r\nldarg puRed\r\nldarg puGreen\r\nldarg puBlue\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32,[in]unsigned int16*,[in]unsigned int16*,[in]unsigned int16*)\r\nret")]
        public static unsafe int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ushort* puRed, ushort* puGreen, ushort* puBlue) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglSetGammaTableI3D([In] IntPtr extensionPointer, IntPtr hDC, int iEntries, ushort* puRed, ushort* puGreen, ushort* puBlue)
        #endregion Overloads for BOOL wglSetGammaTableI3D(HDC hDC, GLint iEntries, const GLUSHORT* puRed, const GLUSHORT* puGreen, const GLUSHORT* puBlue)
        #endregion WGL_I3D_gamma Methods
        #endregion WGL_I3D_gamma (251)

        #region WGL_I3D_genlock (252)
        #region WGL_I3D_genlock Constants
        #region WGL_GENLOCK_SOURCE_MULTIVIEW_I3D
        // #define WGL_GENLOCK_SOURCE_MULTIVIEW_I3D 0x2044
        public const int WGL_GENLOCK_SOURCE_MULTIVIEW_I3D = 0x2044;
        #endregion WGL_GENLOCK_SOURCE_MULTIVIEW_I3D

        #region WGL_GENLOCK_SOURCE_EXTERNAL_SYNC_I3D
        // #define WGL_GENLOCK_SOURCE_EXTERNAL_SYNC_I3D 0x2045
        public const int WGL_GENLOCK_SOURCE_EXTERNAL_SYNC_I3D = 0x2045;
        #endregion WGL_GENLOCK_SOURCE_EXTERNAL_SYNC_I3D

        #region WGL_GENLOCK_SOURCE_EXTERNAL_FIELD_I3D
        // #define WGL_GENLOCK_SOURCE_EXTERNAL_FIELD_I3D 0x2046
        public const int WGL_GENLOCK_SOURCE_EXTERNAL_FIELD_I3D = 0x2046;
        #endregion WGL_GENLOCK_SOURCE_EXTERNAL_FIELD_I3D

        #region WGL_GENLOCK_SOURCE_EXTERNAL_TTL_I3D
        // #define WGL_GENLOCK_SOURCE_EXTERNAL_TTL_I3D 0x2047
        public const int WGL_GENLOCK_SOURCE_EXTERNAL_TTL_I3D = 0x2047;
        #endregion WGL_GENLOCK_SOURCE_EXTERNAL_TTL_I3D

        #region WGL_GENLOCK_SOURCE_DIGITAL_SYNC_I3D
        // #define WGL_GENLOCK_SOURCE_DIGITAL_SYNC_I3D 0x2048
        public const int WGL_GENLOCK_SOURCE_DIGITAL_SYNC_I3D = 0x2048;
        #endregion WGL_GENLOCK_SOURCE_DIGITAL_SYNC_I3D

        #region WGL_GENLOCK_SOURCE_DIGITAL_FIELD_I3D
        // #define WGL_GENLOCK_SOURCE_DIGITAL_FIELD_I3D 0x2049
        public const int WGL_GENLOCK_SOURCE_DIGITAL_FIELD_I3D = 0x2049;
        #endregion WGL_GENLOCK_SOURCE_DIGITAL_FIELD_I3D

        #region WGL_GENLOCK_SOURCE_EDGE_FALLING_I3D
        // #define WGL_GENLOCK_SOURCE_EDGE_FALLING_I3D 0x204A
        public const int WGL_GENLOCK_SOURCE_EDGE_FALLING_I3D = 0x204A;
        #endregion WGL_GENLOCK_SOURCE_EDGE_FALLING_I3D

        #region WGL_GENLOCK_SOURCE_EDGE_RISING_I3D
        // #define WGL_GENLOCK_SOURCE_EDGE_RISING_I3D 0x204B
        public const int WGL_GENLOCK_SOURCE_EDGE_RISING_I3D = 0x204B;
        #endregion WGL_GENLOCK_SOURCE_EDGE_RISING_I3D

        #region WGL_GENLOCK_SOURCE_EDGE_BOTH_I3D
        // #define WGL_GENLOCK_SOURCE_EDGE_BOTH_I3D 0x204C
        public const int WGL_GENLOCK_SOURCE_EDGE_BOTH_I3D = 0x204C;
        #endregion WGL_GENLOCK_SOURCE_EDGE_BOTH_I3D
        #endregion WGL_I3D_genlock Constants

        #region WGL_I3D_genlock Methods
        #region int wglEnableGenlockI3D([In] IntPtr extensionPointer, IntPtr hDC)
        // BOOL wglEnableGenlockI3D(HDC hDC)
        [IlasmAttribute(".maxstack 2\r\nldarg hDC\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int)\r\nret")]
        public static int wglEnableGenlockI3D([In] IntPtr extensionPointer, IntPtr hDC) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglEnableGenlockI3D([In] IntPtr extensionPointer, IntPtr hDC)

        #region int wglDisableGenlockI3D([In] IntPtr extensionPointer, IntPtr hDC)
        // BOOL wglDisableGenlockI3D(HDC hDC)
        [IlasmAttribute(".maxstack 2\r\nldarg hDC\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int)\r\nret")]
        public static int wglDisableGenlockI3D([In] IntPtr extensionPointer, IntPtr hDC) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglDisableGenlockI3D([In] IntPtr extensionPointer, IntPtr hDC)

        #region int wglIsEnabledGenlockI3D([In] IntPtr extensionPointer, IntPtr hDC, out int pFlag)
        // BOOL wglIsEnabledGenlockI3D(HDC hDC, BOOL* pFlag)
        [IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg pFlag\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[out]int32)\r\nret")]
        public static int wglIsEnabledGenlockI3D([In] IntPtr extensionPointer, IntPtr hDC, out int pFlag) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglIsEnabledGenlockI3D([In] IntPtr extensionPointer, IntPtr hDC, out int pFlag)

        #region Overloads for BOOL wglGenlockSourceI3D(HDC hDC, GLUINT uSource)
        #region int wglGenlockSourceI3D([In] IntPtr extensionPointer, IntPtr hDC, int uSource)
        // BOOL wglGenlockSourceI3D(HDC hDC, GLUINT uSource)
        [IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uSource\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32)\r\nret")]
        public static int wglGenlockSourceI3D([In] IntPtr extensionPointer, IntPtr hDC, int uSource) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGenlockSourceI3D([In] IntPtr extensionPointer, IntPtr hDC, int uSource)

        #region int wglGenlockSourceI3D([In] IntPtr extensionPointer, IntPtr hDC, uint uSource)
        // BOOL wglGenlockSourceI3D(HDC hDC, GLUINT uSource)
        [CLSCompliant(false), IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uSource\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]unsigned int32)\r\nret")]
        public static int wglGenlockSourceI3D([In] IntPtr extensionPointer, IntPtr hDC, uint uSource) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGenlockSourceI3D([In] IntPtr extensionPointer, IntPtr hDC, uint uSource)
        #endregion Overloads for BOOL wglGenlockSourceI3D(HDC hDC, GLUINT uSource)

        #region Overloads for BOOL wglGetGenlockSourceI3D(HDC hDC, GLUINT* uSource)
        #region int wglGetGenlockSourceI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uSource)
        // BOOL wglGetGenlockSourceI3D(HDC hDC, GLUINT* uSource)
        [IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uSource\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[out]int32)\r\nret")]
        public static int wglGetGenlockSourceI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uSource) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGenlockSourceI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uSource)

        #region int wglGetGenlockSourceI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uSource)
        // BOOL wglGetGenlockSourceI3D(HDC hDC, GLUINT* uSource)
        [CLSCompliant(false), IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uSource\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[out]unsigned int32)\r\nret")]
        public static int wglGetGenlockSourceI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uSource) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGenlockSourceI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uSource)
        #endregion Overloads for BOOL wglGetGenlockSourceI3D(HDC hDC, GLUINT* uSource)

        #region Overloads for BOOL wglGenlockSourceEdgeI3D(HDC hDC, GLUINT uEdge)
        #region int wglGenlockSourceEdgeI3D([In] IntPtr extensionPointer, IntPtr hDC, int uEdge)
        // BOOL wglGenlockSourceEdgeI3D(HDC hDC, GLUINT uEdge)
        [IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uEdge\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32)\r\nret")]
        public static int wglGenlockSourceEdgeI3D([In] IntPtr extensionPointer, IntPtr hDC, int uEdge) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGenlockSourceEdgeI3D([In] IntPtr extensionPointer, IntPtr hDC, int uEdge)

        #region int wglGenlockSourceEdgeI3D([In] IntPtr extensionPointer, IntPtr hDC, uint uEdge)
        // BOOL wglGenlockSourceEdgeI3D(HDC hDC, GLUINT uEdge)
        [CLSCompliant(false), IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uEdge\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]unsigned int32)\r\nret")]
        public static int wglGenlockSourceEdgeI3D([In] IntPtr extensionPointer, IntPtr hDC, uint uEdge) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGenlockSourceEdgeI3D([In] IntPtr extensionPointer, IntPtr hDC, uint uEdge)
        #endregion Overloads for BOOL wglGenlockSourceEdgeI3D(HDC hDC, GLUINT uEdge)

        #region Overloads for BOOL wglGetGenlockSourceEdgeI3D(HDC hDC, GLUINT* uEdge)
        #region int wglGetGenlockSourceEdgeI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uEdge)
        // BOOL wglGetGenlockSourceEdgeI3D(HDC hDC, GLUINT* uEdge)
        [IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uEdge\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[out]int32)\r\nret")]
        public static int wglGetGenlockSourceEdgeI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uEdge) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGenlockSourceEdgeI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uEdge)

        #region int wglGetGenlockSourceEdgeI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uEdge)
        // BOOL wglGetGenlockSourceEdgeI3D(HDC hDC, GLUINT* uEdge)
        [CLSCompliant(false), IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uEdge\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[out]unsigned int32)\r\nret")]
        public static int wglGetGenlockSourceEdgeI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uEdge) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGenlockSourceEdgeI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uEdge)
        #endregion Overloads for BOOL wglGetGenlockSourceEdgeI3D(HDC hDC, GLUINT* uEdge)

        #region Overloads for BOOL wglGenlockSampleRateI3D(HDC hDC, GLUINT uRate)
        #region int wglGenlockSampleRateI3D([In] IntPtr extensionPointer, IntPtr hDC, int uRate)
        // BOOL wglGenlockSampleRateI3D(HDC hDC, GLUINT uRate)
        [IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uRate\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32)\r\nret")]
        public static int wglGenlockSampleRateI3D([In] IntPtr extensionPointer, IntPtr hDC, int uRate) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGenlockSampleRateI3D([In] IntPtr extensionPointer, IntPtr hDC, int uRate)

        #region int wglGenlockSampleRateI3D([In] IntPtr extensionPointer, IntPtr hDC, uint uRate)
        // BOOL wglGenlockSampleRateI3D(HDC hDC, GLUINT uRate)
        [CLSCompliant(false), IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uRate\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]unsigned int32)\r\nret")]
        public static int wglGenlockSampleRateI3D([In] IntPtr extensionPointer, IntPtr hDC, uint uRate) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGenlockSampleRateI3D([In] IntPtr extensionPointer, IntPtr hDC, uint uRate)
        #endregion Overloads for BOOL wglGenlockSampleRateI3D(HDC hDC, GLUINT uRate)

        #region Overloads for BOOL wglGetGenlockSampleRateI3D(HDC hDC, GLUINT* uRate)
        #region int wglGetGenlockSampleRateI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uRate)
        // BOOL wglGetGenlockSampleRateI3D(HDC hDC, GLUINT* uRate)
        [IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uRate\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[out]int32)\r\nret")]
        public static int wglGetGenlockSampleRateI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uRate) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGenlockSampleRateI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uRate)

        #region int wglGetGenlockSampleRateI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uRate)
        // BOOL wglGetGenlockSampleRateI3D(HDC hDC, GLUINT* uRate)
        [CLSCompliant(false), IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uRate\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[out]unsigned int32)\r\nret")]
        public static int wglGetGenlockSampleRateI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uRate) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGenlockSampleRateI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uRate)
        #endregion Overloads for BOOL wglGetGenlockSampleRateI3D(HDC hDC, GLUINT* uRate)

        #region Overloads for BOOL wglGenlockSourceDelayI3D(HDC hDC, GLUINT uDelay)
        #region int wglGenlockSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, int uDelay)
        // BOOL wglGenlockSourceDelayI3D(HDC hDC, GLUINT uDelay)
        [IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uDelay\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]int32)\r\nret")]
        public static int wglGenlockSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, int uDelay) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGenlockSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, int uDelay)

        #region int wglGenlockSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, uint uDelay)
        // BOOL wglGenlockSourceDelayI3D(HDC hDC, GLUINT uDelay)
        [CLSCompliant(false), IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uDelay\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]unsigned int32)\r\nret")]
        public static int wglGenlockSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, uint uDelay) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGenlockSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, uint uDelay)
        #endregion Overloads for BOOL wglGenlockSourceDelayI3D(HDC hDC, GLUINT uDelay)

        #region Overloads for BOOL wglGetGenlockSourceDelayI3D(HDC hDC, GLUINT* uDelay)
        #region int wglGetGenlockSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uDelay)
        // BOOL wglGetGenlockSourceDelayI3D(HDC hDC, GLUINT* uDelay)
        [IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uDelay\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[out]int32)\r\nret")]
        public static int wglGetGenlockSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uDelay) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGenlockSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uDelay)

        #region int wglGetGenlockSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uDelay)
        // BOOL wglGetGenlockSourceDelayI3D(HDC hDC, GLUINT* uDelay)
        [CLSCompliant(false), IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg uDelay\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[out]unsigned int32)\r\nret")]
        public static int wglGetGenlockSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uDelay) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetGenlockSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uDelay)
        #endregion Overloads for BOOL wglGetGenlockSourceDelayI3D(HDC hDC, GLUINT* uDelay)

        #region Overloads for BOOL wglQueryGenlockMaxSourceDelayI3D(HDC hDC, GLUINT* uMaxLineDelay, GLUINT* uMaxPixelDelay)
        #region int wglQueryGenlockMaxSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uMaxLineDelay, out int uMaxPixelDelay)
        // BOOL wglQueryGenlockMaxSourceDelayI3D(HDC hDC, GLUINT* uMaxLineDelay, GLUINT* uMaxPixelDelay)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg uMaxLineDelay\r\nldarg uMaxPixelDelay\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[out]int32,[out]int32)\r\nret")]
        public static int wglQueryGenlockMaxSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uMaxLineDelay, out int uMaxPixelDelay) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglQueryGenlockMaxSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, out int uMaxLineDelay, out int uMaxPixelDelay)

        #region int wglQueryGenlockMaxSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uMaxLineDelay, out uint uMaxPixelDelay)
        // BOOL wglQueryGenlockMaxSourceDelayI3D(HDC hDC, GLUINT* uMaxLineDelay, GLUINT* uMaxPixelDelay)
        [CLSCompliant(false), IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg uMaxLineDelay\r\nldarg uMaxPixelDelay\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[out]unsigned int32,[out]unsigned int32)\r\nret")]
        public static int wglQueryGenlockMaxSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uMaxLineDelay, out uint uMaxPixelDelay) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglQueryGenlockMaxSourceDelayI3D([In] IntPtr extensionPointer, IntPtr hDC, out uint uMaxLineDelay, out uint uMaxPixelDelay)
        #endregion Overloads for BOOL wglQueryGenlockMaxSourceDelayI3D(HDC hDC, GLUINT* uMaxLineDelay, GLUINT* uMaxPixelDelay)
        #endregion WGL_I3D_genlock Methods
        #endregion WGL_I3D_genlock (252)

        #region WGL_I3D_image_buffer (253)
        #region WGL_I3D_image_buffer Constants
        #region WGL_IMAGE_BUFFER_MIN_ACCESS_I3D
        // #define WGL_IMAGE_BUFFER_MIN_ACCESS_I3D 0x00000001
        public const int WGL_IMAGE_BUFFER_MIN_ACCESS_I3D = 0x00000001;
        #endregion WGL_IMAGE_BUFFER_MIN_ACCESS_I3D

        #region WGL_IMAGE_BUFFER_LOCK_I3D
        // #define WGL_IMAGE_BUFFER_LOCK_I3D 0x00000002
        public const int WGL_IMAGE_BUFFER_LOCK_I3D = 0x00000002;
        #endregion WGL_IMAGE_BUFFER_LOCK_I3D
        #endregion WGL_I3D_image_buffer Constants

        #region WGL_I3D_image_buffer Methods
        #region Overloads for GLvoid* wglCreateImageBufferI3D(HDC hDC, DWORD dwSize, UINT uFlags)
        #region IntPtr wglCreateImageBufferI3D([In] IntPtr extensionPointer, IntPtr hDC, int dwSize, int uFlags)
        // GLvoid* wglCreateImageBufferI3D(HDC hDC, DWORD dwSize, UINT uFlags)
        [IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg dwSize\r\nldarg uFlags\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int,[in]int32,[in]int32)\r\nret")]
        public static IntPtr wglCreateImageBufferI3D([In] IntPtr extensionPointer, IntPtr hDC, int dwSize, int uFlags) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglCreateImageBufferI3D([In] IntPtr extensionPointer, IntPtr hDC, int dwSize, int uFlags)

        #region IntPtr wglCreateImageBufferI3D([In] IntPtr extensionPointer, IntPtr hDC, int dwSize, uint uFlags)
        // GLvoid* wglCreateImageBufferI3D(HDC hDC, DWORD dwSize, UINT uFlags)
        [CLSCompliant(false), IlasmAttribute(".maxstack 4\r\nldarg hDC\r\nldarg dwSize\r\nldarg uFlags\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]native int,[in]int32,[in]unsigned int32)\r\nret")]
        public static IntPtr wglCreateImageBufferI3D([In] IntPtr extensionPointer, IntPtr hDC, int dwSize, uint uFlags) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglCreateImageBufferI3D([In] IntPtr extensionPointer, IntPtr hDC, int dwSize, uint uFlags)
        #endregion Overloads for GLvoid* wglCreateImageBufferI3D(HDC hDC, DWORD dwSize, UINT uFlags)

        #region int wglDestroyImageBufferI3D([In] IntPtr extensionPointer, IntPtr hDC, IntPtr pAddress)
        // BOOL wglDestroyImageBufferI3D(HDC hDC, GLvoid* pAddress)
        [IlasmAttribute(".maxstack 3\r\nldarg hDC\r\nldarg pAddress\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int)\r\nret")]
        public static int wglDestroyImageBufferI3D([In] IntPtr extensionPointer, IntPtr hDC, IntPtr pAddress) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglDestroyImageBufferI3D([In] IntPtr extensionPointer, IntPtr hDC, IntPtr pAddress)

        #region Overloads for BOOL wglAssociateImageBufferEventsI3D(HDC hdc, HANDLE* pEvent, GLvoid* pAddress, DWORD* pSize, UINT count)
        #region int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, int[] pSize, int count)
        // BOOL wglAssociateImageBufferEventsI3D(HDC hdc, HANDLE* pEvent, GLvoid* pAddress, DWORD* pSize, UINT count)
        [IlasmAttribute(".maxstack 6\r\nldarg hdc\r\nldarg pEvent\r\nldarg pAddress\r\nldarg pSize\r\nldarg count\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int[],[in]native int[],[in]int32[],[in]int32)\r\nret")]
        public static int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, int[] pSize, int count) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, int[] pSize, int count)

        #region int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, ref int pSize, int count)
        // BOOL wglAssociateImageBufferEventsI3D(HDC hdc, HANDLE* pEvent, GLvoid* pAddress, DWORD* pSize, UINT count)
        [IlasmAttribute(".maxstack 6\r\nldarg hdc\r\nldarg pEvent\r\nldarg pAddress\r\nldarg pSize\r\nldarg count\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int[],[in]native int[],[in][out]int32,[in]int32)\r\nret")]
        public static int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, ref int pSize, int count) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, ref int pSize, int count)

        #region int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, IntPtr pSize, int count)
        // BOOL wglAssociateImageBufferEventsI3D(HDC hdc, HANDLE* pEvent, GLvoid* pAddress, DWORD* pSize, UINT count)
        [IlasmAttribute(".maxstack 6\r\nldarg hdc\r\nldarg pEvent\r\nldarg pAddress\r\nldarg pSize\r\nldarg count\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int[],[in]native int[],[in]native int,[in]int32)\r\nret")]
        public static int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, IntPtr pSize, int count) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, IntPtr pSize, int count)

        #region int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, IntPtr pSize, uint count)
        // BOOL wglAssociateImageBufferEventsI3D(HDC hdc, HANDLE* pEvent, GLvoid* pAddress, DWORD* pSize, UINT count)
        [CLSCompliant(false), IlasmAttribute(".maxstack 6\r\nldarg hdc\r\nldarg pEvent\r\nldarg pAddress\r\nldarg pSize\r\nldarg count\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int[],[in]native int[],[in]native int,[in]unsigned int32)\r\nret")]
        public static int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, IntPtr pSize, uint count) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, IntPtr pSize, uint count)

        #region int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, ref int pSize, uint count)
        // BOOL wglAssociateImageBufferEventsI3D(HDC hdc, HANDLE* pEvent, GLvoid* pAddress, DWORD* pSize, UINT count)
        [CLSCompliant(false), IlasmAttribute(".maxstack 6\r\nldarg hdc\r\nldarg pEvent\r\nldarg pAddress\r\nldarg pSize\r\nldarg count\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int[],[in]native int[],[in][out]int32,[in]unsigned int32)\r\nret")]
        public static int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, ref int pSize, uint count) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, ref int pSize, uint count)

        #region int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, int[] pSize, uint count)
        // BOOL wglAssociateImageBufferEventsI3D(HDC hdc, HANDLE* pEvent, GLvoid* pAddress, DWORD* pSize, UINT count)
        [CLSCompliant(false), IlasmAttribute(".maxstack 6\r\nldarg hdc\r\nldarg pEvent\r\nldarg pAddress\r\nldarg pSize\r\nldarg count\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int[],[in]native int[],[in]int32[],[in]unsigned int32)\r\nret")]
        public static int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, int[] pSize, uint count) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, int[] pSize, uint count)

        #region int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, int* pSize, uint count)
        // BOOL wglAssociateImageBufferEventsI3D(HDC hdc, HANDLE* pEvent, GLvoid* pAddress, DWORD* pSize, UINT count)
        [CLSCompliant(false), IlasmAttribute(".maxstack 6\r\nldarg hdc\r\nldarg pEvent\r\nldarg pAddress\r\nldarg pSize\r\nldarg count\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int[],[in]native int[],[in]int32*,[in]unsigned int32)\r\nret")]
        public static unsafe int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, int* pSize, uint count) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglAssociateImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pEvent, IntPtr[] pAddress, int* pSize, uint count)
        #endregion Overloads for BOOL wglAssociateImageBufferEventsI3D(HDC hdc, HANDLE* pEvent, GLvoid* pAddress, DWORD* pSize, UINT count)

        #region Overloads for BOOL wglReleaseImageBufferEventsI3D(HDC hdc, GLvoid* pAddress, UINT count)
        #region int wglReleaseImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pAddress, int count)
        // BOOL wglReleaseImageBufferEventsI3D(HDC hdc, GLvoid* pAddress, UINT count)
        [IlasmAttribute(".maxstack 4\r\nldarg hdc\r\nldarg pAddress\r\nldarg count\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int[],[in]int32)\r\nret")]
        public static int wglReleaseImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pAddress, int count) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglReleaseImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pAddress, int count)

        #region int wglReleaseImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pAddress, uint count)
        // BOOL wglReleaseImageBufferEventsI3D(HDC hdc, GLvoid* pAddress, UINT count)
        [CLSCompliant(false), IlasmAttribute(".maxstack 4\r\nldarg hdc\r\nldarg pAddress\r\nldarg count\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([in]native int,[in]native int[],[in]unsigned int32)\r\nret")]
        public static int wglReleaseImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pAddress, uint count) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglReleaseImageBufferEventsI3D([In] IntPtr extensionPointer, IntPtr hdc, IntPtr[] pAddress, uint count)
        #endregion Overloads for BOOL wglReleaseImageBufferEventsI3D(HDC hdc, GLvoid* pAddress, UINT count)
        #endregion WGL_I3D_image_buffer Methods
        #endregion WGL_I3D_image_buffer (253)

        #region WGL_I3D_swap_frame_lock (254)
        #region WGL_I3D_swap_frame_lock Methods
        #region int wglEnableFrameLockI3D([In] IntPtr extensionPointer)
        // BOOL wglEnableFrameLockI3D()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32()\r\nret")]
        public static int wglEnableFrameLockI3D([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglEnableFrameLockI3D([In] IntPtr extensionPointer)

        #region int wglDisableFrameLockI3D([In] IntPtr extensionPointer)
        // BOOL wglDisableFrameLockI3D()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32()\r\nret")]
        public static int wglDisableFrameLockI3D([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglDisableFrameLockI3D([In] IntPtr extensionPointer)

        #region int wglIsEnabledFrameLockI3D([In] IntPtr extensionPointer, out int pFlag)
        // BOOL wglIsEnabledFrameLockI3D(BOOL* pFlag)
        [IlasmAttribute(".maxstack 2\r\nldarg pFlag\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([out]int32)\r\nret")]
        public static int wglIsEnabledFrameLockI3D([In] IntPtr extensionPointer, out int pFlag) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglIsEnabledFrameLockI3D([In] IntPtr extensionPointer, out int pFlag)

        #region int wglQueryFrameLockMasterI3D([In] IntPtr extensionPointer, out int pFlag)
        // BOOL wglQueryFrameLockMasterI3D(BOOL* pFlag)
        [IlasmAttribute(".maxstack 2\r\nldarg pFlag\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([out]int32)\r\nret")]
        public static int wglQueryFrameLockMasterI3D([In] IntPtr extensionPointer, out int pFlag) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglQueryFrameLockMasterI3D([In] IntPtr extensionPointer, out int pFlag)
        #endregion WGL_I3D_swap_frame_lock Methods
        #endregion WGL_I3D_swap_frame_lock (254)

        #region WGL_I3D_swap_frame_usage (N/A)
        #region WGL_I3D_swap_frame_usage Methods
        #region int wglGetFrameUsageI3D([In] IntPtr extensionPointer, out float pUsage)
        // BOOL wglGetFrameUsageI3D(GLfloat* pUsage)
        [IlasmAttribute(".maxstack 2\r\nldarg pUsage\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([out]float32)\r\nret")]
        public static int wglGetFrameUsageI3D([In] IntPtr extensionPointer, out float pUsage) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetFrameUsageI3D([In] IntPtr extensionPointer, out float pUsage)

        #region int wglBeginFrameTrackingI3D([In] IntPtr extensionPointer)
        // BOOL wglBeginFrameTrackingI3D()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32()\r\nret")]
        public static int wglBeginFrameTrackingI3D([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglBeginFrameTrackingI3D([In] IntPtr extensionPointer)

        #region int wglEndFrameTrackingI3D([In] IntPtr extensionPointer)
        // BOOL wglEndFrameTrackingI3D()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32()\r\nret")]
        public static int wglEndFrameTrackingI3D([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglEndFrameTrackingI3D([In] IntPtr extensionPointer)

        #region int wglQueryFrameTrackingI3D([In] IntPtr extensionPointer, out int pFrameCount, out int pMissedFrames, out float pLastMissedUsage)
        // BOOL wglQueryFrameTrackingI3D(DWORD* pFrameCount, DWORD* pMissedFrames, GLfloat* pLastMissedUsage)
        [IlasmAttribute(".maxstack 4\r\nldarg pFrameCount\r\nldarg pMissedFrames\r\nldarg pLastMissedUsage\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32([out]int32,[out]int32,[out]float32)\r\nret")]
        public static int wglQueryFrameTrackingI3D([In] IntPtr extensionPointer, out int pFrameCount, out int pMissedFrames, out float pLastMissedUsage) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglQueryFrameTrackingI3D([In] IntPtr extensionPointer, out int pFrameCount, out int pMissedFrames, out float pLastMissedUsage)
        #endregion WGL_I3D_swap_frame_usage Methods
        #endregion WGL_I3D_swap_frame_usage (N/A)
        #endregion I3D Extensions

        #region NV Extensions
        #region WGL_NV_render_depth_texture (263)
        #region WGL_NV_render_depth_texture Constants
        #region WGL_BIND_TO_TEXTURE_DEPTH_NV
        // #define WGL_BIND_TO_TEXTURE_DEPTH_NV 0x20A3
        public const int WGL_BIND_TO_TEXTURE_DEPTH_NV = 0x20A3;
        #endregion WGL_BIND_TO_TEXTURE_DEPTH_NV

        #region WGL_BIND_TO_TEXTURE_RECTANGLE_DEPTH_NV
        // #define WGL_BIND_TO_TEXTURE_RECTANGLE_DEPTH_NV 0x20A4
        public const int WGL_BIND_TO_TEXTURE_RECTANGLE_DEPTH_NV = 0x20A4;
        #endregion WGL_BIND_TO_TEXTURE_RECTANGLE_DEPTH_NV

        #region WGL_DEPTH_TEXTURE_FORMAT_NV
        // #define WGL_DEPTH_TEXTURE_FORMAT_NV 0x20A5
        public const int WGL_DEPTH_TEXTURE_FORMAT_NV = 0x20A5;
        #endregion WGL_DEPTH_TEXTURE_FORMAT_NV

        #region WGL_TEXTURE_DEPTH_COMPONENT_NV
        // #define WGL_TEXTURE_DEPTH_COMPONENT_NV 0x20A6
        public const int WGL_TEXTURE_DEPTH_COMPONENT_NV = 0x20A6;
        #endregion WGL_TEXTURE_DEPTH_COMPONENT_NV

        #region WGL_DEPTH_COMPONENT_NV
        // #define WGL_DEPTH_COMPONENT_NV 0x20A7
        public const int WGL_DEPTH_COMPONENT_NV = 0x20A7;
        #endregion WGL_DEPTH_COMPONENT_NV
        #endregion WGL_NV_render_depth_texture Constants
        #endregion WGL_NV_render_depth_texture (263)

        #region WGL_NV_render_texture_rectangle (264)
        #region WGL_NV_render_texture_rectangle Constants
        #region WGL_BIND_TO_TEXTURE_RECTANGLE_RGB_NV
        // #define WGL_BIND_TO_TEXTURE_RECTANGLE_RGB_NV 0x20A0
        public const int WGL_BIND_TO_TEXTURE_RECTANGLE_RGB_NV = 0x20A0;
        #endregion WGL_BIND_TO_TEXTURE_RECTANGLE_RGB_NV

        #region WGL_BIND_TO_TEXTURE_RECTANGLE_RGBA_NV
        // #define WGL_BIND_TO_TEXTURE_RECTANGLE_RGBA_NV 0x20A1
        public const int WGL_BIND_TO_TEXTURE_RECTANGLE_RGBA_NV = 0x20A1;
        #endregion WGL_BIND_TO_TEXTURE_RECTANGLE_RGBA_NV

        #region WGL_TEXTURE_RECTANGLE_NV
        // #define WGL_TEXTURE_RECTANGLE_NV 0x20A2
        public const int WGL_TEXTURE_RECTANGLE_NV = 0x20A2;
        #endregion WGL_TEXTURE_RECTANGLE_NV
        #endregion WGL_NV_render_texture_rectangle Constants
        #endregion WGL_NV_render_texture_rectangle (264)

        #region WGL_NV_float_buffer (281)
        #region WGL_NV_float_buffer Constants
        #region WGL_FLOAT_COMPONENTS_NV
        // #define WGL_FLOAT_COMPONENTS_NV 0x20B0
        public const int WGL_FLOAT_COMPONENTS_NV = 0x20B0;
        #endregion WGL_FLOAT_COMPONENTS_NV

        #region WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_R_NV
        // #define WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_R_NV 0x20B1
        public const int WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_R_NV = 0x20B1;
        #endregion WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_R_NV

        #region WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_RG_NV
        // #define WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_RG_NV 0x20B2
        public const int WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_RG_NV = 0x20B2;
        #endregion WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_RG_NV

        #region WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_RGB_NV
        // #define WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_RGB_NV 0x20B3
        public const int WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_RGB_NV = 0x20B3;
        #endregion WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_RGB_NV

        #region WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_RGBA_NV
        // #define WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_RGBA_NV 0x20B4
        public const int WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_RGBA_NV = 0x20B4;
        #endregion WGL_BIND_TO_TEXTURE_RECTANGLE_FLOAT_RGBA_NV

        #region WGL_TEXTURE_FLOAT_R_NV
        // #define WGL_TEXTURE_FLOAT_R_NV 0x20B5
        public const int WGL_TEXTURE_FLOAT_R_NV = 0x20B5;
        #endregion WGL_TEXTURE_FLOAT_R_NV

        #region WGL_TEXTURE_FLOAT_RG_NV
        // #define WGL_TEXTURE_FLOAT_RG_NV 0x20B6
        public const int WGL_TEXTURE_FLOAT_RG_NV = 0x20B6;
        #endregion WGL_TEXTURE_FLOAT_RG_NV

        #region WGL_TEXTURE_FLOAT_RGB_NV
        // #define WGL_TEXTURE_FLOAT_RGB_NV 0x20B7
        public const int WGL_TEXTURE_FLOAT_RGB_NV = 0x20B7;
        #endregion WGL_TEXTURE_FLOAT_RGB_NV

        #region WGL_TEXTURE_FLOAT_RGBA_NV
        // #define WGL_TEXTURE_FLOAT_RGBA_NV 0x20B8
        public const int WGL_TEXTURE_FLOAT_RGBA_NV = 0x20B8;
        #endregion WGL_TEXTURE_FLOAT_RGBA_NV
        #endregion WGL_NV_float_buffer Constants
        #endregion WGL_NV_float_buffer (281)

        #region WGL_NV_unknown (N/A)
        #region WGL_NV_unknown Methods
        #region IntPtr wglAllocateMemoryNV([In] IntPtr extensionPointer, int size, float readFrequency, float writeFrequency, float priority)
        // GLvoid* wglAllocateMemoryNV(GLsizei size, GLfloat readFrequency, GLfloat writeFrequency, GLfloat priority)
        [IlasmAttribute(".maxstack 5\r\nldarg size\r\nldarg readFrequency\r\nldarg writeFrequency\r\nldarg priority\r\nldarg extensionPointer\r\ncalli unmanaged stdcall native int([in]int32,[in]float32,[in]float32,[in]float32)\r\nret")]
        public static IntPtr wglAllocateMemoryNV([In] IntPtr extensionPointer, int size, float readFrequency, float writeFrequency, float priority) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion IntPtr wglAllocateMemoryNV([In] IntPtr extensionPointer, int size, float readFrequency, float writeFrequency, float priority)

        #region void wglFreeMemoryNV([In] IntPtr extensionPointer, IntPtr pointer)
        // GLvoid wglFreeMemoryNV(GLvoid* pointer)
        [IlasmAttribute(".maxstack 2\r\nldarg pointer\r\nldarg extensionPointer\r\ncalli unmanaged stdcall void([in]native int)\r\nret")]
        public static void wglFreeMemoryNV([In] IntPtr extensionPointer, IntPtr pointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion void wglFreeMemoryNV([In] IntPtr extensionPointer, IntPtr pointer)
        #endregion WGL_NV_unknown Methods
        #endregion WGL_NV_unknown (N/A)
        #endregion NV Extensions

        #region OML Extensions
        #region WGL_OML_sync_control (242)
        #region WGL_OML_sync_control Methods
        #region int wglGetSyncValuesOML([In] IntPtr extensionPointer)
        // BOOL wglGetSyncValuesOML()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32()\r\nret")]
        public static int wglGetSyncValuesOML([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetSyncValuesOML([In] IntPtr extensionPointer)

        #region int wglGetMscRateOML([In] IntPtr extensionPointer)
        // BOOL wglGetMscRateOML()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32()\r\nret")]
        public static int wglGetMscRateOML([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglGetMscRateOML([In] IntPtr extensionPointer)

        #region long wglSwapBuffersMscOML([In] IntPtr extensionPointer)
        // INT64 wglSwapBuffersMscOML()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int64()\r\nret")]
        public static long wglSwapBuffersMscOML([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion long wglSwapBuffersMscOML([In] IntPtr extensionPointer)

        #region long wglSwapLayerBuffersMscOML([In] IntPtr extensionPointer)
        // INT64 wglSwapLayerBuffersMscOML()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int64()\r\nret")]
        public static long wglSwapLayerBuffersMscOML([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion long wglSwapLayerBuffersMscOML([In] IntPtr extensionPointer)

        #region int wglWaitForMscOML([In] IntPtr extensionPointer)
        // BOOL wglWaitForMscOML()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32()\r\nret")]
        public static int wglWaitForMscOML([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglWaitForMscOML([In] IntPtr extensionPointer)

        #region int wglWaitForSbcOML([In] IntPtr extensionPointer)
        // BOOL wglWaitForSbcOML()
        [IlasmAttribute(".maxstack 1\r\nldarg extensionPointer\r\ncalli unmanaged stdcall int32()\r\nret")]
        public static int wglWaitForSbcOML([In] IntPtr extensionPointer) { throw new NotImplementedException( "IL replacement failure." ); }
        #endregion int wglWaitForSbcOML([In] IntPtr extensionPointer)
        #endregion WGL_OML_sync_control Methods
        #endregion WGL_OML_sync_control (242)
        #endregion OML Extensions
    }
}
