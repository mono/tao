#region License
/*
MIT License
Copyright ©2003-2004 Randy Ridge
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
	///	The SDL_gfx library evolved out of the SDL_gfxPrimitives code which 
	///	provided basic drawing routines such as lines, circles or polygons 
	///	and SDL_rotozoom which implemented a interpolating rotozoomer for 
	///	SDL surfaces.
	///	<p>
	///	The current components of the SDL_gfx library are: 
	///
	///	<br>Graphic Primitives (SDL_gfxPrimitves.h)</br> 
	///	<br>Rotozoomer (SDL_rotozoom.h) </br>
	///	<br>Framerate control (SDL_framerate.h) </br>
	///	MMX image filters (SDL_imageFilter.h)</p>
	///	</summary>
	#endregion Class Documentation
	public sealed class SdlGfx
	{
		#region Private Constants
		#region string SDL_GFX_NATIVE_LIBRARY
		/// <summary>
		/// Specifies SdlTtf's native library archive.
		/// </summary>
		/// <remarks>
		/// Specifies SDL_gfx.dll for Windows and libSDL_gfx.so for Linux.
		/// </remarks>
#if WIN32
		private const string SDL_GFX_NATIVE_LIBRARY = "sdlgfx.dll";
#elif LINUX
private const string SDL_GFX_NATIVE_LIBRARY = "libSDL_gfx.so";
#endif
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
		// SDL_gfxPrimitives.h -- none

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
		#endregion Public Constants

		#region Public Structs
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
		#endregion Public Structs

		#region Constructors & Destructors
		#region SdlGfx()
		/// <summary>
		/// Prevents instantiation.
		/// </summary>
		private SdlGfx()
		{
		}
		#endregion SdlGfx()
		#endregion Constructors & Destructors

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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int filledPolygonRGBA(
			IntPtr dst, short[] vx, short[] vy, 
			int n, byte r, byte g, byte b, byte a); 
		#endregion int filledPolygonRGBA(...)

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
		 CallingConvention=CALLING_CONVENTION),
		 SuppressUnmanagedCodeSecurity]
		 public static extern int bezierColor(
			 IntPtr dst, short[]  vx, short[] vy, int n, int s, int color); 
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
		 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
			 CallingConvention=CALLING_CONVENTION),
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
		 CallingConvention=CALLING_CONVENTION),
		 SuppressUnmanagedCodeSecurity]
		 public static extern void gfxPrimitivesSetFont(
			 object fontdata, int cw, int ch); 
		#endregion void gfxPrimitivesSetFont(object fontdata, int cw, int ch)
		#endregion SDL_gfxPrimitives.h

		#region SDL_rotozoom.h
		#region IntPtr rotozoomSurface(...)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="src"></param>
		/// <param name="angle"></param>
		/// <param name="zoom"></param>
		/// <param name="smooth"></param>
		/// <returns></returns>
		[DllImport(SDL_GFX_NATIVE_LIBRARY,
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr rotozoomSurface(
			IntPtr src, double angle, double zoom, int smooth);
		#endregion IntPtr rotozoomSurface(...)

		#region IntPtr rotozoomSurfaceSize(...)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="angle"></param>
		/// <param name="zoom"></param>
		/// <param name="dstheight"></param>
		/// <param name="dstwidth"></param>
		/// <returns></returns>
		[DllImport(SDL_GFX_NATIVE_LIBRARY,
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr rotozoomSurfaceSize(
			int width, int height, double angle, 
			double zoom, out int dstwidth, out int dstheight);
		#endregion IntPtr rotozoomSurfaceSize(...)

		#region IntPtr zoomSurface(...)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="src"></param>
		/// <param name="zoomx"></param>
		/// <param name="zoomy"></param>
		/// <param name="smooth"></param>
		/// <returns></returns>
		[DllImport(SDL_GFX_NATIVE_LIBRARY,
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr zoomSurface(
			IntPtr src, double zoomx, double zoomy, int smooth);
		#endregion IntPtr zoomSurface(...)

		#region IntPtr zoomSurfaceSize(...)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="zoomx"></param>
		/// <param name="zoomy"></param>
		/// <param name="dstheight"></param>
		/// <param name="dstwidth"></param>
		/// <returns></returns>
		[DllImport(SDL_GFX_NATIVE_LIBRARY,
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr zoomSurfaceSize(
			int width, int height,
			double zoomx, double zoomy, out int dstwidth, out int dstheight);
		#endregion IntPtr zoomSurfaceSize(...)
		#endregion SDL_rotozoom.h

		#endregion SdlGfxMethods
	}
}
