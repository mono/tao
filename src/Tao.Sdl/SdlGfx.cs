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
using System.Reflection;
using System.Security;
using System.Runtime.InteropServices;

namespace Tao.Sdl
{
    #region Class Documentation
    /// <summary>
    /// SDL graphics drawing primitives and other support functions
    /// The SDL_gfx library evolved out of the SDL_gfxPrimitives code which
    /// provided basic drawing routines such as lines, circles or polygons
    /// and SDL_rotozoom which implemented a interpolating rotozoomer for
    /// SDL surfaces.
    /// <p>
    /// The current components of the SDL_gfx library are:
    ///
    /// <br>Graphic Primitives (SDL_gfxPrimitves.h)</br>
    /// <br>Rotozoomer (SDL_rotozoom.h) </br>
    /// <br>Framerate control (SDL_framerate.h) </br>
    /// MMX image filters (SDL_imageFilter.h)</p>
    /// </summary>
    #endregion Class Documentation
    [SuppressUnmanagedCodeSecurityAttribute()]
    public static class SdlGfx
    {
        #region Private Constants
        #region string SDL_GFX_NATIVE_LIBRARY
        /// <summary>
        /// Specifies SdlTtf's native library archive.
        /// </summary>
        /// <remarks>
        /// Specifies SDL_gfx.dll everywhere; will be mapped via .config for mono.
        /// </remarks>
        private const string SDL_GFX_NATIVE_LIBRARY = "SDL_gfx.dll";
        #endregion string SDL_GFX_NATIVE_LIBRARY

        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        /// Specifies the calling convention.
        /// </summary>
        /// <remarks>
        /// Specifies <see cref="CallingConvention.Cdecl" />
        /// for Windows and Linux.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION =
            CallingConvention.Cdecl;
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants

        #region Public Constants
        #region SDL_gfxPrimitives.h
        // Not implementing M_PI since it is in System.Math
        // #define M_PI	3.141592654

        /// <summary>
        /// Major Version
        /// </summary>
        public const int SDL_GFXPRIMITIVES_MAJOR = 2;
        /// <summary>
        /// Minor Version
        /// </summary>
        public const int SDL_GFXPRIMITIVES_MINOR = 0;
        /// <summary>
        /// Micro Version
        /// </summary>
        public const int SDL_GFXPRIMITIVES_MICRO = 16;
        #endregion SDL_gfxPrimitives.h

        #region SDL_rotozoom.h
        /// <summary>
        ///
        /// </summary>
        public const int SMOOTHING_OFF = 0;
        /// <summary>
        ///
        /// </summary>
        public const int SMOOTHING_ON = 1;
        #endregion SDL_rotozoom.h

        #region SDL_framerate.h
        /// <summary>
        ///
        /// </summary>
        public const int FPS_UPPER_LIMIT = 200;
        /// <summary>
        ///
        /// </summary>
        public const int FPS_LOWER_LIMIT = 1;
        /// <summary>
        ///
        /// </summary>
        public const int FPS_DEFAULT = 30;
        #endregion SDL_framerate.h

        // SDL_imageFilter.h -- none
        #endregion Public Constants

        #region Public Structs
        // SDL_gfxPrimitives.h -- none

        #region SDL_rotozoom.h
        #region tColorRGBA
        /// <summary>
        ///
        /// </summary>
        public struct tColorRGBA
        {
            /// <summary>
            ///
            /// </summary>
            public byte r;
            /// <summary>
            ///
            /// </summary>
            public byte g;
            /// <summary>
            ///
            /// </summary>
            public byte b;
            /// <summary>
            ///
            /// </summary>
            public byte a;
        }
        #endregion tColorRGBA

        #region tColorY
        /// <summary>
        ///
        /// </summary>
        public struct tColorY
        {
            /// <summary>
            ///
            /// </summary>
            public byte y;
        }
        #endregion tColorY
        #endregion SDL_rotozoom.h

        #region SDL_framerate.h
        #region FPSmanager
        /// <summary>
        ///
        /// </summary>
        public struct FPSmanager
        {
            /// <summary>
            ///
            /// </summary>
            public int framecount;
            /// <summary>
            ///
            /// </summary>
            public float rateticks;
            /// <summary>
            ///
            /// </summary>
            public int lastticks;
            /// <summary>
            ///
            /// </summary>
            public int rate;
        }
        #endregion FPSmanager
        #endregion SDL_framerate.h

        // SDL_imageFilter.h -- none
        #endregion Public Structs

        #region SdlGfx Methods
        #region SDL_gfxPrimitives.h
        #region int pixelColor(IntPtr dst, short x, short y, int color)
        /// <summary>
        /// Pixel
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int pixelColor(IntPtr dst, short x, short y, int color);
        #endregion int pixelColor(IntPtr dst, short x, short y, int color)

        #region int pixelRGBA(...)
        /// <summary>
        /// Pixel
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int pixelRGBA(
            IntPtr dst, short x, short y, byte r,
            byte g, byte b, byte a);
        #endregion int pixelRGBA(...)

        #region int hlineColor(IntPtr dst, short x1, short x2, short y, int color)
        /// <summary>
        /// Horizontal line
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int hlineColor(
            IntPtr dst, short x1, short x2, short y, int color);
        #endregion int hlineColor(IntPtr dst, short x1, short x2, short y, int color)

        #region int hlineRGBA(...)
        /// <summary>
        /// Horizontal line
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int hlineRGBA(
            IntPtr dst, short x1, short x2, short y, byte r,
            byte g, byte b, byte a);
        #endregion int hlineRGBA(...)

        #region int vlineColor(IntPtr dst, short x, short y1, short y2, int color)
        /// <summary>
        /// Vertical line
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int vlineColor(IntPtr dst, short x, short y1, short y2, int color);
        #endregion int vlineColor(IntPtr dst, short x, short y1, short y2, int color)

        #region int vlineRGBA(...)
        /// <summary>
        /// Vertical Line
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int vlineRGBA(IntPtr dst, short x, short y1, short y2, byte r, byte g, byte b, byte a);
        #endregion int vlineRGBA(...)

        #region int rectangleColor(...)
        /// <summary>
        /// Rectangle
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int rectangleColor(
            IntPtr dst, short x1, short y1, short x2, short y2, int color);
        #endregion int rectangleColor(...)

        #region int rectangleRGBA(...)
        /// <summary>
        /// Rectangle
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int rectangleRGBA(IntPtr dst, short x1, short y1,
            short x2, short y2, byte r, byte g, byte b, byte a);
        #endregion int rectangleRGBA(...)

        #region int boxColor(...)
        /// <summary>
        /// Filled rectangle (Box)
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int boxColor(
            IntPtr dst, short x1, short y1, short x2, short y2, int color);
        #endregion int boxColor(...)

        #region int boxRGBA(...)
        /// <summary>
        /// Filled rectangle (Box)
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int boxRGBA(
            IntPtr dst, short x1, short y1, short x2,
            short y2, byte r, byte g, byte b, byte a);
        #endregion int boxRGBA(...)

        #region int lineColor(...)
        /// <summary>
        /// Line
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int lineColor(
            IntPtr dst, short x1, short y1, short x2, short y2, int color);
        #endregion int lineColor(...)

        #region int lineRGBA(...)
        /// <summary>
        /// Line
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int lineRGBA(
            IntPtr dst, short x1, short y1,
            short x2, short y2, byte r, byte g, byte b, byte a);
        #endregion int lineRGBA(...)

        #region int aalineColor(...)
        /// <summary>
        /// AA Line
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int aalineColor(
            IntPtr dst, short x1, short y1, short x2, short y2, int color);
        #endregion int aalineColor(...)

        #region int aalineRGBA(...)
        /// <summary>
        /// AA Line
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int aalineRGBA(
            IntPtr dst, short x1, short y1,
            short x2, short y2, byte r, byte g, byte b, byte a);
        #endregion int aalineRGBA(...)

        #region int circleColor(IntPtr dst, short x, short y, short r, int color)
        /// <summary>
        /// Circle
        /// </summary>
        /// <remarks>
        ///
        /// <p>Binds to C-function in SDL_gfx.h
        /// <code>
        /// int circleColor(IntPtr dst, short x, short y, short r, int color);
        /// </code></p>
        /// </remarks>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <returns>
        ///
        /// </returns>
        /// <param name="color"></param>
        /// <param name="dst"></param>
        /// <param name="r"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int circleColor(IntPtr dst, short x, short y, short r, int color);
        #endregion int circleColor(IntPtr dst, short x, short y, short r, int color)

        #region int circleRGBA(...)
        /// <summary>
        /// Circle
        /// </summary>
        /// <remarks>
        ///
        /// <p>Binds to C-function in SDL_gfx.h
        /// <code>
        /// int circleRGBA(IntPtr dst, short x, short y, short rad, byte r, byte g, byte b, byte a)
        /// </code></p>
        /// </remarks>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <returns>
        ///
        /// </returns>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="g"></param>
        /// <param name="rad"></param>
        /// <param name="dst"></param>
        /// <param name="r"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int circleRGBA(IntPtr dst, short x, short y, short rad, byte r, byte g, byte b, byte a);
        #endregion int circleRGBA(...)

        #region int filledCircleColor(IntPtr dst, short x, short y, short r, int color)
        /// <summary>
        /// Filled Circle
        /// </summary>
        /// <remarks>
        ///
        /// <p>Binds to C-function in SDL_gfx.h
        /// <code>
        /// int filledCircleColor(IntPtr dst, short x, short y, short r, int color);
        /// </code></p>
        /// </remarks>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <returns>
        ///
        /// </returns>
        /// <param name="color"></param>
        /// <param name="dst"></param>
        /// <param name="r"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int filledCircleColor(IntPtr dst, short x, short y, short r, int color);
        #endregion int filledCircleColor(IntPtr dst, short x, short y, short r, int color)

        #region int filledCircleRGBA(...)
        /// <summary>
        /// Filled Circle
        /// </summary>
        /// <remarks>
        ///
        /// <p>Binds to C-function in SDL_gfx.h
        /// <code>
        /// int filledCircleRGBA(IntPtr dst, short x, short y, short rad, byte r, byte g, byte b, byte a)
        /// </code></p>
        /// </remarks>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <returns>
        ///
        /// </returns>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="g"></param>
        /// <param name="rad"></param>
        /// <param name="dst"></param>
        /// <param name="r"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int filledCircleRGBA(
            IntPtr dst, short x, short y, short rad,
            byte r, byte g, byte b, byte a);
        #endregion int filledCircleRGBA(...)

        #region int aacircleColor(IntPtr dst, short x, short y, short r, int color)
        /// <summary>
        /// AA Circle
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="r"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int aacircleColor(
            IntPtr dst, short x, short y, short r, int color);
        #endregion int aacircleColor(IntPtr dst, short x, short y, short r, int color)

        #region int aacircleRGBA(...)
        /// <summary>
        /// AA Circle
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rad"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int aacircleRGBA(
            IntPtr dst, short x, short y,
            short rad, byte r, byte g, byte b, byte a);
        #endregion int aacircleRGBA(...)

        #region int ellipseColor(...)
        /// <summary>
        /// Ellipse
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int ellipseColor(
            IntPtr dst, short x, short y, short rx, short ry, int color);
        #endregion int ellipseColor(...)

        #region int ellipseRGBA(...)
        /// <summary>
        /// Ellipse
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int ellipseRGBA(
            IntPtr dst, short x, short y,
            short rx, short ry, byte r, byte g, byte b, byte a);
        #endregion int ellipseRGBA(...)

        #region int aaellipseColor(...)
        /// <summary>
        /// AA Ellipse
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="xc"></param>
        /// <param name="yc"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int aaellipseColor(
            IntPtr dst, short xc, short yc, short rx, short ry, int color);
        #endregion int aaellipseColor(...)

        #region int aaellipseRGBA(...)
        /// <summary>
        /// AA Ellipse
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int aaellipseRGBA(
            IntPtr dst, short x, short y,
            short rx, short ry, byte r, byte g, byte b, byte a);
        #endregion int aaellipseRGBA(...)

        #region int filledEllipseColor(...)
        /// <summary>
        /// Filled Ellipse
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int filledEllipseColor(
            IntPtr dst, short x, short y, short rx, short ry, int color);
        #endregion int filledEllipseColor(...)

        #region int filledEllipseRGBA(...)
        /// <summary>
        /// Filled Ellipse
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int filledEllipseRGBA(
            IntPtr dst, short x, short y,
            short rx, short ry, byte r, byte g, byte b, byte a);
        #endregion int filledEllipseRGBA(...)

        #region int pieColor(...)
        /// <summary>
        /// Pie
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rad"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int pieColor(
            IntPtr dst, short x, short y, short rad,
            short start, short end, int color);
        #endregion int pieColor(...)

        #region int pieRGBA(...)
        /// <summary>
        /// Pie
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rad"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int pieRGBA(
            IntPtr dst, short x, short y, short rad,
            short start, short end, byte r, byte g, byte b, byte a);
        #endregion int pieRGBA(...)

        #region int filledPieColor(...)
        /// <summary>
        /// Filled Pie
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rad"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int filledPieColor(
            IntPtr dst, short x, short y, short rad,
            short start, short end, int color);
        #endregion int filledPieColor(...)

        #region int filledPieRGBA(...)
        /// <summary>
        /// Filled Pie
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rad"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int filledPieRGBA(
            IntPtr dst, short x, short y, short rad,
            short start, short end, byte r, byte g, byte b, byte a);
        #endregion int filledPieRGBA(...)

        #region int trigonColor(...)
        /// <summary>
        /// Trigon
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int trigonColor(
            IntPtr dst, short x1, short y1, short x2,
            short y2, short x3, short y3, int color);
        #endregion int trigonColor(...)

        #region int trigonRGBA(...)
        /// <summary>
        /// Trigon
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int trigonRGBA(
            IntPtr dst, short x1, short y1, short x2,
            short y2, short x3, short y3,
            byte r, byte g, byte b, byte a);
        #endregion int trigonRGBA(...)

        #region int aatrigonColor(...)
        /// <summary>
        /// AA-Trigon
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int aatrigonColor(
            IntPtr dst, short x1, short y1, short x2,
            short y2, short x3, short y3, int color);
        #endregion int aatrigonColor(...)

        #region int aatrigonRGBA(...)
        /// <summary>
        /// AA-Trigon
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int aatrigonRGBA(
            IntPtr dst, short x1, short y1, short x2,
            short y2, short x3, short y3,
            byte r, byte g, byte b, byte a);
        #endregion int aatrigonRGBA(...)

        #region int filledTrigonColor(...)
        /// <summary>
        /// Filled Trigon
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int filledTrigonColor(
            IntPtr dst, short x1, short y1, short x2,
            short y2, short x3, short y3, int color);
        #endregion int filledTrigonColor(...)

        #region int filledTrigonRGBA(...)
        /// <summary>
        /// Filled Trigon
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int filledTrigonRGBA(
            IntPtr dst, short x1, short y1, short x2,
            short y2, short x3, short y3,
            byte r, byte g, byte b, byte a);
        #endregion int filledTrigonRGBA(...)

        #region int polygonColor(...)
        /// <summary>
        /// Polygon
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="vx"></param>
        /// <param name="vy"></param>
        /// <param name="n"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int polygonColor(
            IntPtr dst, short[] vx, short[] vy, int n, int color);
        #endregion int polygonColor(...)

        #region int polygonRGBA(...)
        /// <summary>
        /// Polygon
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="vx"></param>
        /// <param name="vy"></param>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int polygonRGBA(
            IntPtr dst, short[] vx, short[] vy,
            int n, byte r, byte g, byte b, byte a);
        #endregion int polygonRGBA(...)

        #region int aapolygonColor(...)
        /// <summary>
        /// AA-Polygon
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="vx"></param>
        /// <param name="vy"></param>
        /// <param name="n"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int aapolygonColor(
            IntPtr dst, short[] vx, short[] vy, int n, int color);
        #endregion int aapolygonColor(...)

        #region int aapolygonRGBA(...)
        /// <summary>
        /// AA-Polygon
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="vx"></param>
        /// <param name="vy"></param>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int aapolygonRGBA(
            IntPtr dst, short[] vx, short[] vy,
            int n, byte r, byte g, byte b, byte a);
        #endregion int aapolygonRGBA(...)

        #region int filledPolygonColor(...)
        /// <summary>
        /// Filled Polygon
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="vx"></param>
        /// <param name="vy"></param>
        /// <param name="n"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int filledPolygonColor(
            IntPtr dst, short[] vx, short[] vy, int n, int color);
        #endregion int filledPolygonColor(...)

        #region int filledPolygonRGBA(...)
        /// <summary>
        /// Filled Polygon
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="vx"></param>
        /// <param name="vy"></param>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int filledPolygonRGBA(
            IntPtr dst, short[] vx, short[] vy,
            int n, byte r, byte g, byte b, byte a);
        #endregion int filledPolygonRGBA(...)

        #region int texturedPolygon(...)
        /// <summary>
        /// Textured Polygon
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="vx"></param>
        /// <param name="vy"></param>
        /// <param name="n"></param>
        /// <param name="texture"></param>
        /// <param name="texture_dx"></param>
        /// <param name="texture_dy"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int texturedPolygon(
            IntPtr dst, short[] vx, short[] vy,
            int n, IntPtr texture, int texture_dx, int texture_dy);
        #endregion int texturedPolygon(...)

        #region int bezierColor(...)
        /// <summary>
        /// Bezier
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="vx"></param>
        /// <param name="vy"></param>
        /// <param name="n"></param>
        /// <param name="s">number of steps</param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int bezierColor(
            IntPtr dst, short[] vx, short[] vy, int n, int s, int color);
        #endregion int bezierColor(...)

        #region int bezierRGBA(...)
        /// <summary>
        /// Bezier
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="vx"></param>
        /// <param name="vy"></param>
        /// <param name="n"></param>
        /// <param name="s">number of steps</param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int bezierRGBA(
            IntPtr dst, short[] vx, short[] vy,
            int n, int s, byte r, byte g, byte b, byte a);
        #endregion int bezierRGBA(...)

        #region int characterColor(IntPtr dst, short x, short y, char c, int color)
        /// <summary>
        /// Character
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="c"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int characterColor(
            IntPtr dst, short x, short y, char c, int color);
        #endregion int characterColor(IntPtr dst, short x, short y, char c, int color)

        #region int characterRGBA(...)
        /// <summary>
        /// Character
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="c"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int characterRGBA(
            IntPtr dst, short x, short y, char c, byte r, byte g, byte b, byte a);
        #endregion int characterRGBA(...)

        #region int stringColor(...)
        /// <summary>
        /// String
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="c"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int stringColor(
            IntPtr dst, short x, short y, string c, int color);
        #endregion int stringColor(...)

        #region int stringRGBA(...)
        /// <summary>
        /// String
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="c"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int stringRGBA(
            IntPtr dst, short x, short y, string c,
            byte r, byte g, byte b, byte a);
        #endregion int stringRGBA(...)

        #region void gfxPrimitivesSetFont(object fontdata, int cw, int ch)
        /// <summary>
        ///
        /// </summary>
        /// <param name="fontdata"></param>
        /// <param name="cw">Width</param>
        /// <param name="ch">Height</param>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void gfxPrimitivesSetFont(
            object fontdata, int cw, int ch);
        #endregion void gfxPrimitivesSetFont(object fontdata, int cw, int ch)
        #endregion SDL_gfxPrimitives.h

        #region SDL_rotozoom.h
        #region IntPtr rotozoomSurface(...)
        /// <summary>
        /// Rotates and zoomes a 32bit or 8bit 'src' surface to newly created 'dst' surface.
        /// 'angle' is the rotation in degrees. 'zoom' a scaling factor. If 'smooth' is 1
        /// then the destination 32bit surface is anti-aliased. If the surface is not 8bit
        /// or 32bit RGBA/ABGR it will be converted into a 32bit RGBA format on the fly.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="angle"></param>
        /// <param name="zoom"></param>
        /// <param name="smooth"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr rotozoomSurface(
            IntPtr src, double angle, double zoom, int smooth);
        #endregion IntPtr rotozoomSurface(...)

        #region IntPtr rotozoomSurfaceXY(...)
        /// <summary>
        /// Rotates and zoomes a 32bit or 8bit 'src' surface to newly created 'dst' surface. 
        /// 'angle' is the rotation in degrees. 
        /// 'zoomx' and 'zoomy' are scaling factors that  can also be negative. 
        /// In this case the corresponding axis is flipped.  
        /// If 'smooth'   is 1 then the destination 32bit surface is anti-aliased. 
        /// If the surface is not 8bit  or 32bit RGBA/ABGR it will be converted into 
        /// a 32bit RGBA format on the fly.   
        /// Note: Flipping currently only works with antialiasing turned off.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="angle"></param>
        /// <param name="zoomx"></param>
        /// <param name="zoomy"></param>
        /// <param name="smooth"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr rotozoomSurfaceXY(
            IntPtr src, double angle, double zoomx, double zoomy, int smooth);
        #endregion IntPtr rotozoomSurfaceXY(...)

        #region void rotozoomSurfaceSize(...)
        /// <summary>
        /// Returns the size of the target surface for a rotozoomSurface() call
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="angle"></param>
        /// <param name="zoom"></param>
        /// <param name="dstheight"></param>
        /// <param name="dstwidth"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void rotozoomSurfaceSize(
            int width, int height, double angle,
            double zoom, out int dstwidth, out int dstheight);
        #endregion void rotozoomSurfaceSize(...)

        #region void rotozoomSurfaceSizeXY(...)
        /// <summary>
        /// Returns the size of the target surface for a rotozoomSurface() call
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="angle"></param>
        /// <param name="zoomx"></param>
        /// <param name="zoomy"></param>
        /// <param name="dstheight"></param>
        /// <param name="dstwidth"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void rotozoomSurfaceSizeXY(
            int width, int height, double angle,
            double zoomx, double zoomy, out int dstwidth, out int dstheight);
        #endregion void rotozoomSurfaceSizeXY(...)

        #region IntPtr zoomSurface(...)
        /// <summary>
        /// Zooms a 32bit or 8bit 'src' surface to newly created 'dst' surface.
        /// 'zoomx' and 'zoomy' are scaling factors for width and height. If 'smooth' is 1
        /// then the destination 32bit surface is anti-aliased. If the surface is not 8bit
        /// or 32bit RGBA/ABGR it will be converted into a 32bit RGBA format on the fly.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="zoomx"></param>
        /// <param name="zoomy"></param>
        /// <param name="smooth"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr zoomSurface(
            IntPtr src, double zoomx, double zoomy, int smooth);
        #endregion IntPtr zoomSurface(...)

        #region void zoomSurfaceSize(...)
        /// <summary>
        /// Returns the size of the target surface for a zoomSurface() call
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zoomx"></param>
        /// <param name="zoomy"></param>
        /// <param name="dstheight"></param>
        /// <param name="dstwidth"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void zoomSurfaceSize(
            int width, int height,
            double zoomx, double zoomy, out int dstwidth, out int dstheight);
        #endregion void zoomSurfaceSize(...)

        #region IntPtr shrinkSurface(...)
        /// <summary>
        /// Shrinks a 32bit or 8bit 'src' surface ti a newly created 'dst' surface.
        /// 'factorx' and 'factory' are the shrinking ratios (i.e. 2=1/2 the size,
        /// 3=1/3 the size, etc.) The destination surface is antialiased by averaging
        /// the source box RGBA or Y information. If the surface is not 8bit
        /// or 32bit RGBA/ABGR it will be converted into a 32bit RGBA format on the fly.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="factorx"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr shrinkSurface(
            IntPtr src, int factorx, int factory);
        #endregion IntPtr shrinkSurface(...)

        #endregion SDL_rotozoom.h

        #region SDL_framerate.h
        #region void SDL_initFramerate(IntPtr manager)
        /// <summary>
        ///
        /// </summary>
        /// <remarks>
        /// <p>
        /// Binds to C-function call in SDL_framerate.h.
        /// <code>
        /// void SDL_initFramerate(FPSmanager * manager)
        /// </code>
        /// </p>
        /// </remarks>
        /// <param name="manager">IntPtr to FPSmanager struct</param>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void SDL_initFramerate(IntPtr manager);
        #endregion void SDL_initFramerate(IntPtr manager)

        #region int SDL_setFramerate(IntPtr manager, int rate)
        /// <summary>
        ///
        /// </summary>
        /// <remarks>
        /// <p>
        /// Binds to C-function call in SDL_framerate.h.
        /// <code>
        /// int SDL_setFramerate(FPSmanager * manager, int rate)
        /// </code>
        /// </p>
        /// </remarks>
        /// <param name="manager">IntPtr to FPSmanager struct</param>
        /// <param name="rate"></param>
        /// <returns>Returns 0 for success and -1 for error</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_setFramerate(IntPtr manager, int rate);
        #endregion int SDL_setFramerate(IntPtr manager, int rate)

        #region int SDL_getFramerate(IntPtr manager)
        /// <summary>
        ///
        /// </summary>
        /// <remarks>
        /// <p>
        /// Binds to C-function call in SDL_framerate.h.
        /// <code>
        /// int SDL_getFramerate(FPSmanager * manager)
        /// </code>
        /// </p>
        /// </remarks>
        /// <param name="manager">IntPtr to FPSmanager struct</param>
        /// <returns>Returns value for success and -1 for error</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_getFramerate(IntPtr manager);
        #endregion int SDL_getFramerate(IntPtr manager)

        #region void SDL_framerateDelay(IntPtr manager)
        /// <summary>
        ///
        /// </summary>
        /// <remarks>
        /// <p>
        /// Binds to C-function call in SDL_framerate.h.
        /// <code>
        /// void SDL_framerateDelay(FPSmanager * manager)
        /// </code>
        /// </p>
        /// </remarks>
        /// <param name="manager">IntPtr to FPSmanager struct</param>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void SDL_framerateDelay(IntPtr manager);
        #endregion void SDL_framerateDelay(IntPtr manager)
        #endregion SDL_framerate.h

        #region SDL_imageFilter.h
        #region int SDL_imageFilterMMXdetect()
        /// <summary>
        /// Detect MMX capability in CPU
        /// </summary>
        /// <remarks>
        /// <p>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterMMXdetect(void)
        /// </code>
        /// </p>
        /// </remarks>
        /// <returns>
        /// Returns 0 for success and -1 for Error.
        /// </returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterMMXdetect();
        #endregion int SDL_imageFilterMMXdetect()

        #region void SDL_imageFilterMMXoff()
        /// <summary>
        /// Force use of MMX off.
        /// </summary>
        /// <remarks>
        /// <p>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// void SDL_imageFilterMMXoff(void)
        /// </code>
        /// </p>
        /// </remarks>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void SDL_imageFilterMMXoff();
        #endregion void SDL_imageFilterMMXoff()

        #region void SDL_imageFilterMMXon()
        /// <summary>
        /// Turn possible use of MMX back on
        /// </summary>
        /// <remarks>
        /// <p>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// void SDL_imageFilterMMXon(void)
        /// </code>
        /// </p>
        /// </remarks>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void SDL_imageFilterMMXon();
        #endregion void SDL_imageFilterMMXon()

        #region int SDL_imageFilterAdd(byte[] Src1, byte[] Src2, byte[] Dest, int length)
        /// <summary>
        /// SDL_imageFilterAdd: D = saturation255(S1 + S2)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterAdd(unsigned char *Src1, unsigned char *Src2, unsigned char *Dest, int length)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Src2">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterAdd(byte[] Src1, byte[] Src2, byte[] Dest, int length);
        #endregion int SDL_imageFilterAdd(byte[] Src1, byte[] Src2, byte[] Dest, int length)

        #region int SDL_imageFilterMean(byte[] Src1, byte[] Src2, byte[] Dest, int length)
        /// <summary>
        /// SDL_imageFilterMean: D = S1/2 + S2/2
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterMean(unsigned char *Src1, unsigned char *Src2, unsigned char *Dest, int length)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Src2">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterMean(byte[] Src1, byte[] Src2, byte[] Dest, int length);
        #endregion int SDL_imageFilterMean(byte[] Src1, byte[] Src2, byte[] Dest, int length)

        #region int SDL_imageFilterSub(byte[] Src1, byte[] Src2, byte[] Dest, int length)
        /// <summary>
        /// SDL_imageFilterSub: D = saturation0(S1 - S2)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_framerate.h.
        /// <code>
        /// int SDL_imageFilterSub(unsigned char *Src1, unsigned char *Src2, unsigned char *Dest, int length)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Src2">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterSub(byte[] Src1, byte[] Src2, byte[] Dest, int length);
        #endregion int SDL_imageFilterSub(byte[] Src1, byte[] Src2, byte[] Dest, int length)

        #region int SDL_imageFilterAbsDiff(byte[] Src1, byte[] Src2, byte[] Dest, int length)
        /// <summary>
        /// SDL_imageFilterAbsDiff: D = | S1 - S2 |
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterAbsDiff(unsigned char *Src1, unsigned char *Src2, unsigned char *Dest, int length)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Src2">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterAbsDiff(byte[] Src1, byte[] Src2, byte[] Dest, int length);
        #endregion int SDL_imageFilterAbsDiff(byte[] Src1, byte[] Src2, byte[] Dest, int length)

        #region int SDL_imageFilterMult(byte[] Src1, byte[] Src2, byte[] Dest, int length)
        /// <summary>
        /// SDL_imageFilterMult: D = saturation(S1 * S2)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterMult(unsigned char *Src1, unsigned char *Src2, unsigned char *Dest, int length)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Src2">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterMult(byte[] Src1, byte[] Src2, byte[] Dest, int length);
        #endregion int SDL_imageFilterMult(byte[] Src1, byte[] Src2, byte[] Dest, int length)

        #region int SDL_imageFilterMultNor(byte[] Src1, byte[] Src2, byte[] Dest, int length)
        /// <summary>
        /// SDL_imageFilterMultNor: D = S1 * S2 (non-MMX)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterMultNor(unsigned char *Src1, unsigned char *Src2, unsigned char *Dest, int length)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Src2">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterMultNor(byte[] Src1, byte[] Src2, byte[] Dest, int length);
        #endregion int SDL_imageFilterMultNor(byte[] Src1, byte[] Src2, byte[] Dest, int length)

        #region int SDL_imageFilterMultDivby2(byte[] Src1, byte[] Src2, byte[] Dest, int length)
        /// <summary>
        /// SDL_imageFilterMultDivby2: D = saturation255(S1/2 * S2)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterMultDivby2(unsigned char *Src1, unsigned char *Src2, unsigned char *Dest, int length)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Src2">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterMultDivby2(byte[] Src1, byte[] Src2, byte[] Dest, int length);
        #endregion int SDL_imageFilterMultDivby2(byte[] Src1, byte[] Src2, byte[] Dest, int length)

        #region int SDL_imageFilterMultDivby4(byte[] Src1, byte[] Src2, byte[] Dest, int length)
        /// <summary>
        /// SDL_imageFilterMultDivby4: D = saturation255(S1/2 * S2)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterMultDivby4(unsigned char *Src1, unsigned char *Src2, unsigned char *Dest, int length)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Src2">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterMultDivby4(byte[] Src1, byte[] Src2, byte[] Dest, int length);
        #endregion int SDL_imageFilterMultDivby4(byte[] Src1, byte[] Src2, byte[] Dest, int length)

        #region int SDL_imageFilterBitAnd(byte[] Src1, byte[] Src2, byte[] Dest, int length
        /// <summary>
        /// SDL_imageFilterBitAnd: D = S1 &amp; S2
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterBitAnd(unsigned char *Src1, unsigned char *Src2, unsigned char *Dest, int length)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Src2">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterBitAnd(byte[] Src1, byte[] Src2, byte[] Dest, int length);
        #endregion int SDL_imageFilterBitAnd(byte[] Src1, byte[] Src2, byte[] Dest, int length

        #region int SDL_imageFilterBitOr(byte[] Src1, byte[] Src2, byte[] Dest, int length)
        /// <summary>
        /// SDL_imageFilterBitOr: D = S1 | S2
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterBitAnd(unsigned char *Src1, unsigned char *Src2, unsigned char *Dest, int length)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Src2">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterBitOr(byte[] Src1, byte[] Src2, byte[] Dest, int length);
        #endregion int SDL_imageFilterBitOr(byte[] Src1, byte[] Src2, byte[] Dest, int length)

        #region int SDL_imageFilterDiv(byte[] Src1, byte[] Src2, byte[] Dest, int length)
        /// <summary>
        /// SDL_imageFilterDiv: D = S1 / S2 (non-MMX)
        /// </summary>
        /// <remarks>
        /// int SDL_imageFilterDiv(unsigned char *Src1, unsigned char *Src2, unsigned char *Dest, int length)
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Src2">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterDiv(byte[] Src1, byte[] Src2, byte[] Dest, int length);
        #endregion int SDL_imageFilterDiv(byte[] Src1, byte[] Src2, byte[] Dest, int length)

        #region int SDL_imageFilterBitNegation(byte[] Src1, byte[] Dest, int length)
        /// <summary>
        /// SDL_imageFilterBitNegation: D = !S
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterNegation(unsigned char *Src1, unsigned char *Src2, unsigned char *Dest, int length)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterBitNegation(byte[] Src1, byte[] Dest, int length);
        #endregion int SDL_imageFilterBitNegation(byte[] Src1, byte[] Dest, int length)

        #region int SDL_imageFilterAddByte(byte[] Src1, byte[] Dest, int length, byte C)
        /// <summary>
        /// SDL_imageFilterAddByte: D = saturation255(S + C)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterAddByte(unsigned char *Src1, unsigned char *Dest, int length, unsigned char C)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="C">Byte to add</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterAddByte(byte[] Src1, byte[] Dest, int length, byte C);
        #endregion int SDL_imageFilterAddByte(byte[] Src1, byte[] Dest, int length, byte C)

        #region int SDL_imageFilterAddUint(byte[] Src1, byte[] Dest, int length, int C)
        /// <summary>
        /// SDL_imageFilterAddUint: D = saturation255(S + (uint)C)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterAddUint(unsigned char *Src1, unsigned char *Dest, int length, unsigned int C)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="C">int to add</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterAddUint(byte[] Src1, byte[] Dest, int length, int C);
        #endregion int SDL_imageFilterAddUint(byte[] Src1, byte[] Dest, int length, int C)

        #region int SDL_imageFilterAddBytetoHalf(byte[] Src1, byte[] Dest, int length, byte C)
        /// <summary>
        /// SDL_imageFilterAddByteToHalf: D = saturation255(S/2 + C)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterAddByteToHalf(unsigned char *Src1, unsigned char *Dest, int length, unsigned char C)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="C">Byte to add</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterAddByteToHalf(byte[] Src1, byte[] Dest, int length, byte C);
        #endregion int SDL_imageFilterAddBytetoHalf(byte[] Src1, byte[] Dest, int length, byte C)

        #region int SDL_imageFilterSubByte(byte[] Src1, byte[] Dest, int length, byte C)
        /// <summary>
        /// SDL_imageFilterSubByte: D = saturation0(S - C)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterSubByte(unsigned char *Src1, unsigned char *Dest, int length, unsigned char C)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="C">Byte to add</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterSubByte(byte[] Src1, byte[] Dest, int length, byte C);
        #endregion int SDL_imageFilterSubByte(byte[] Src1, byte[] Dest, int length, byte C)

        #region int SDL_imageFilterSubUint(byte[] Src1, byte[] Dest, int length, int C)
        /// <summary>
        /// SDL_imageFilterSubUint: D = saturation0(S - (uint)C)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterSubUint(unsigned char *Src1, unsigned char *Dest, int length, unsigned int C)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="C">int to add</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterSubUint(byte[] Src1, byte[] Dest, int length, int C);
        #endregion int SDL_imageFilterSubUint(byte[] Src1, byte[] Dest, int length, int C)

        #region int SDL_imageFilterShiftRight(byte[] Src1, byte[] Dest, int length, byte N)
        /// <summary>
        /// SDL_imageFilterShiftRight: D = saturation0(S >> N)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterShiftRight(unsigned char *Src1, unsigned char *Dest, int length, unsigned char C)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="N">Shift</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterShiftRight(byte[] Src1, byte[] Dest, int length, byte N);
        #endregion int SDL_imageFilterShiftRight(byte[] Src1, byte[] Dest, int length, byte N)

        #region int SDL_imageFilterShiftRightUint(byte[] Src1, byte[] Dest, int length, byte N)
        /// <summary>
        /// SDL_imageFilterShiftRightUint: D = saturation0((uint)S >> N)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterShiftRightUint(unsigned char *Src1, unsigned char *Dest, int length, unsigned char C)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="N">Shift</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterShiftRightUint(byte[] Src1, byte[] Dest, int length, byte N);
        #endregion int SDL_imageFilterShiftRightUint(byte[] Src1, byte[] Dest, int length, byte N)

        #region int SDL_imageFilterMultByByte(byte[] Src1, byte[] Dest, int length, byte C)
        /// <summary>
        /// SDL_imageFilterMultByByte: D = saturation255(S * C)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterMultByByte(unsigned char *Src1, unsigned char *Dest, int length, unsigned char C)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="C">Byte</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterMultByByte(byte[] Src1, byte[] Dest, int length, byte C);
        #endregion int SDL_imageFilterMultByByte(byte[] Src1, byte[] Dest, int length, byte C)

        #region int SDL_imageFilterShiftRightAndMultByByte(byte[] Src1, byte[] Dest, int length, byte N, byte C)
        /// <summary>
        /// SDL_imageFilterShiftRightAndMultByByte: D = saturation255((S >> N) * C)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterShiftRightAndMultByByte(unsigned char *Src1, unsigned char *Dest, int length, unsigned char N, unsigned char C)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="C">Byte</param>
        /// <param name="N">Shift</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterShiftRightAndMultByByte(
            byte[] Src1, byte[] Dest, int length, byte N, byte C);
        #endregion int SDL_imageFilterShiftRightAndMultByByte(byte[] Src1, byte[] Dest, int length, byte N, byte C)

        #region int SDL_imageFilterShiftLeftByte(byte[] Src1, byte[] Dest, int length, byte N)
        /// <summary>
        /// SDL_imageFilterShiftLeftByte: D = (S &lt;&lt; N)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterShiftLeftByte(unsigned char *Src1, unsigned char *Dest, int length, unsigned char N)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="N">Shift</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterShiftLeftByte(byte[] Src1, byte[] Dest, int length, byte N);
        #endregion int SDL_imageFilterShiftLeftByte(byte[] Src1, byte[] Dest, int length, byte N)

        #region int SDL_imageFilterShiftLeft(byte[] Src1, byte[] Dest, int length, byte N)
        /// <summary>
        /// SDL_imageFilterShiftLeft: D = saturation255(S &lt;&lt; N)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterShiftLeft(unsigned char *Src1, unsigned char *Dest, int length, unsigned char N)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="N">Shift</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterShiftLeft(byte[] Src1, byte[] Dest, int length, byte N);
        #endregion int SDL_imageFilterShiftLeft(byte[] Src1, byte[] Dest, int length, byte N)

        #region int SDL_imageFilterShiftLeftUint(byte[] Src1, byte[] Dest, int length, byte N)
        /// <summary>
        /// SDL_imageFilterShiftLeftUint: D = ((uint)S &lt;&lt; N)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterShiftLeftUint(unsigned char *Src1, unsigned char *Dest, int length, unsigned char N)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="N">Shift</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterShiftLeftUint(byte[] Src1, byte[] Dest, int length, byte N);
        #endregion int SDL_imageFilterShiftLeftUint(byte[] Src1, byte[] Dest, int length, byte N)

        #region int SDL_imageFilterBinarizeUsingThreshold((byte[] Src1, byte[] Dest, int length, byte T)
        /// <summary>
        /// SDL_imageFilterBinarizeUsingThreshold: D = S >= T ? 255:0
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterBinarizeUsingThreshold(unsigned char *Src1, unsigned char *Dest, int length, unsigned char T);
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="T">Threshold</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterBinarizeUsingThreshold(
            byte[] Src1, byte[] Dest, int length, byte T);
        #endregion int SDL_imageFilterBinarizeUsingThreshold((byte[] Src1, byte[] Dest, int length, byte T)

        #region int SDL_imageFilterClipToRange(...)
        /// <summary>
        /// SDL_imageFilterClipToRange: D = (S &gt;= Tmin) &amp; (S &lt;= Tmax) 255:0
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterClipToRange(unsigned char *Src1, unsigned char *Dest, int length, unsigned char Tmin, unsigned char Tmax);
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="Tmin">Threshold</param>
        /// <param name="Tmax">Threshold</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterClipToRange(
            byte[] Src1, byte[] Dest, int length, byte Tmin, byte Tmax);
        #endregion int SDL_imageFilterClipToRange(...)

        #region int SDL_imageFilterNormalizeLinear(...)
        /// <summary>
        /// SDL_imageFilterNormalizeLinear: D = saturation255((Nmax - Nmin)/(Cmax - Cmin)*(S - Cmin) + Nmin)
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterNormalizeLinear(unsigned char *Src1, unsigned char *Dest, int length, int Cmin, int Cmax, int Nmin, int Nmax);
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="Nmin">Threshold</param>
        /// <param name="Nmax">Threshold</param>
        /// <param name="Cmin">Threshold</param>
        /// <param name="Cmax">Threshold</param>
        /// <param name="length">Size of array</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterNormalizeLinear(
            byte[] Src1, byte[] Dest, int length,
            int Cmin, int Cmax, int Nmin, int Nmax);
        #endregion int SDL_imageFilterNormalizeLinear(...)

        #region int SDL_imageFilterConvolveKernel3x3Divide(...)
        /// <summary>
        /// SDL_imageFilterConvolveKernel3x3Divide: Dij = saturation0and255( ... ). For MMX processors only.
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterConvolveKernel3x3Divide(unsigned char *Src, unsigned char *Dest, int rows, int columns, signed short *Kernel, unsigned char Divisor);
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="rows">Threshold</param>
        /// <param name="columns">Threshold</param>
        /// <param name="Kernel">Size of array</param>
        /// <param name="Divisor"></param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterConvolveKernel3x3Divide(
            byte[] Src1, byte[] Dest, int rows,
            int columns, short[] Kernel, byte Divisor);
        #endregion int SDL_imageFilterConvolveKernel3x3Divide(...)

        #region int SDL_imageFilterConvolveKernel5x5Divide(...)
        /// <summary>
        /// SDL_imageFilterConvolveKernel5x5Divide: Dij = saturation0and255( ... ). For MMX processors only.
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterConvolveKernel5x5Divide(unsigned char *Src, unsigned char *Dest, int rows, int columns, signed short *Kernel, unsigned char Divisor);
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="columns"></param>
        /// <param name="Divisor"></param>
        /// <param name="Kernel"></param>
        /// <param name="rows"></param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterConvolveKernel5x5Divide(
            byte[] Src1, byte[] Dest, int rows,
            int columns, short[] Kernel, byte Divisor);
        #endregion int SDL_imageFilterConvolveKernel5x5Divide(...)

        #region int SDL_imageFilterConvolveKernel7x7Divide(...)
        /// <summary>
        /// SDL_imageFilterConvolveKernel7x7Divide: Dij = saturation0and255( ... ). For MMX processors only.
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterConvolveKernel7x7Divide(unsigned char *Src, unsigned char *Dest, int rows, int columns, signed short *Kernel, unsigned char Divisor);
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="columns"></param>
        /// <param name="Divisor"></param>
        /// <param name="Kernel"></param>
        /// <param name="rows"></param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterConvolveKernel7x7Divide(
            byte[] Src1, byte[] Dest, int rows,
            int columns, short[] Kernel, byte Divisor);
        #endregion int SDL_imageFilterConvolveKernel7x7Divide(...)

        #region int SDL_imageFilterConvolveKernel9x9Divide(...)
        /// <summary>
        /// SDL_imageFilterConvolveKernel9x9Divide: Dij = saturation0and255( ... ). For MMX processors only.
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterConvolveKernel9x9Divide(unsigned char *Src, unsigned char *Dest, int rows, int columns, signed short *Kernel, unsigned char Divisor);
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="columns"></param>
        /// <param name="Divisor"></param>
        /// <param name="Kernel"></param>
        /// <param name="rows"></param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterConvolveKernel9x9Divide(
            byte[] Src1, byte[] Dest, int rows,
            int columns, short[] Kernel, byte Divisor);
        #endregion int SDL_imageFilterConvolveKernel9x9Divide(...)

        #region int SDL_imageFilterConvolveKernel3x3ShiftRight(...)
        /// <summary>
        /// SDL_imageFilterConvolveKernel3x3ShiftRight: Dij = saturation0and255( ... ). For MMX processors only.
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterConvolveKernel3x3ShiftRight(unsigned char *Src, unsigned char *Dest, int rows, int columns, signed short *Kernel, unsigned char NRightShift);
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="columns"></param>
        /// <param name="NRightShift"></param>
        /// <param name="Kernel"></param>
        /// <param name="rows"></param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterConvolveKernel3x3ShiftRight(
            byte[] Src1, byte[] Dest, int rows,
            int columns, short[] Kernel, byte NRightShift);
        #endregion int SDL_imageFilterConvolveKernel3x3ShiftRight(...)

        #region int SDL_imageFilterConvolveKernel5x5ShiftRight(...)
        /// <summary>
        /// SDL_imageFilterConvolveKernel5x5ShiftRight: Dij = saturation0and255( ... ). For MMX processors only.
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterConvolveKernel5x5ShiftRight(unsigned char *Src, unsigned char *Dest, int rows, int columns, signed short *Kernel, unsigned char NRightShift);
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="columns"></param>
        /// <param name="NRightShift"></param>
        /// <param name="Kernel"></param>
        /// <param name="rows"></param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterConvolveKernel5x5ShiftRight(
            byte[] Src1, byte[] Dest, int rows,
            int columns, short[] Kernel, byte NRightShift);
        #endregion int SDL_imageFilterConvolveKernel5x5ShiftRight(...)

        #region int SDL_imageFilterConvolveKernel7x7ShiftRight(...)
        /// <summary>
        /// SDL_imageFilterConvolveKernel7x7ShiftRight: Dij = saturation0and255( ... ). For MMX processors only.
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterConvolveKernel7x7ShiftRight(unsigned char *Src, unsigned char *Dest, int rows, int columns, signed short *Kernel, unsigned char NRightShift);
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="rows">Threshold</param>
        /// <param name="columns">Threshold</param>
        /// <param name="Kernel">Size of array</param>
        /// <param name="NRightShift"></param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterConvolveKernel7x7ShiftRight(
            byte[] Src1, byte[] Dest, int rows,
            int columns, short[] Kernel, byte NRightShift);
        #endregion int SDL_imageFilterConvolveKernel7x7ShiftRight(...)

        #region int SDL_imageFilterConvolveKernel9x9ShiftRight(...)
        /// <summary>
        /// SDL_imageFilterConvolveKernel9x9ShiftRight: Dij = saturation0and255( ... ). For MMX processors only.
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterConvolveKernel9x9ShiftRight(unsigned char *Src, unsigned char *Dest, int rows, int columns, signed short *Kernel, unsigned char NRightShift);
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="rows">Threshold</param>
        /// <param name="columns">Threshold</param>
        /// <param name="Kernel">Size of array</param>
        /// <param name="NRightShift"></param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterConvolveKernel9x9ShiftRight(
            byte[] Src1, byte[] Dest, int rows,
            int columns, short[] Kernel, byte NRightShift);
        #endregion int SDL_imageFilterConvolveKernel9x9ShiftRight(...)

        #region int SDL_imageFilterSobelX(byte[] Src1, byte[] Dest, int rows, int columns)
        /// <summary>
        /// SDL_imageFilterSobelX: Dij = saturation255( ... ). For MMX processors only.
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterSobelX(unsigned char *Src, unsigned char *Dest, int rows, int columns)
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="rows">Threshold</param>
        /// <param name="columns">Threshold</param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterSobelX(byte[] Src1, byte[] Dest, int rows, int columns);
        #endregion int SDL_imageFilterSobelX(byte[] Src1, byte[] Dest, int rows, int columns)

        #region int SDL_imageFilterSobelXShiftRight(...)
        /// <summary>
        /// SDL_imageFilterSobelXShiftRight: Dij = saturation255( ... ). For MMX processors only.
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// int SDL_imageFilterSobelXShiftRight(unsigned char *Src, unsigned char *Dest, int rows, int columns, unsigned char NRightShift);
        /// </code>
        /// </remarks>
        /// <param name="Src1">Array of bytes</param>
        /// <param name="Dest">Array of bytes returned after operation.</param>
        /// <param name="rows">Threshold</param>
        /// <param name="columns">Threshold</param>
        /// <param name="NRightShift"></param>
        /// <returns>Returns 0 for success and -1 for Error.</returns>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_imageFilterSobelXShiftRight(
            byte[] Src1, byte[] Dest, int rows, int columns, byte NRightShift);
        #endregion int SDL_imageFilterSobelXShiftRight(...)

        #region void SDL_imageFilterAlignStack()
        /// <summary>
        /// Align stack to 32 byte boundary -- Functionality untested! --. For MMX processors only.
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// void SDL_imageFilterAlignStack(void)
        /// </code>
        /// </remarks>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void SDL_imageFilterAlignStack();
        #endregion void SDL_imageFilterAlignStack()

        #region void SDL_imageFilterRestoreStack()
        /// <summary>
        /// Restore stack to 32 byte boundary -- Functionality untested! --. For MMX processors only.
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_imageFilter.h.
        /// <code>
        /// void SDL_imageFilterRestoreStack(void)
        /// </code>
        /// </remarks>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void SDL_imageFilterRestoreStack();
        #endregion void SDL_imageFilterRestoreStack()
        #endregion SDL_imageFilter.h

        #region SDL_gfxBlitFunc.h

        #region int SDL_gfxBlitRGBA(IntPtr src, ref Sdl.SDL_Rect srcrect, IntPtr dst, Sdl.SDL_Rect dstrect)
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_gfxBlitFunc.h.
        /// <code>
        /// int  SDL_gfxBlitRGBA(SDL_Surface * src, SDL_Rect * srcrect, SDL_Surface * dst, SDL_Rect * dstrect);
        /// </code>
        /// </remarks>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_gfxBlitRGBA(IntPtr src, ref Sdl.SDL_Rect srcrect, IntPtr dst, Sdl.SDL_Rect dstrect);
        #endregion int SDL_gfxBlitRGBA(IntPtr src, ref Sdl.SDL_Rect srcrect, IntPtr dst, Sdl.SDL_Rect dstrect)

        #region int SDL_gfxSetAlpha(IntPtr src, byte a)
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Binds to C-function call in SDL_gfxBlitFunc.h.
        /// <code>
        /// int SDL_gfxSetAlpha(SDL_Surface * src, Uint8 a);
        /// </code>
        /// </remarks>
        [DllImport(SDL_GFX_NATIVE_LIBRARY,
             CallingConvention = CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int SDL_gfxSetAlpha(IntPtr src, byte a);
        #endregion int SDL_gfxSetAlpha(IntPtr src, byte a)

        #endregion SDL_gfxBlitFunc.h

        #endregion SdlGfxMethods
    }
}
