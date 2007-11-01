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
using System.Runtime.InteropServices;
using System.Text;

namespace Tao.Platform.X11
{
	#region GL Types

	using GLsizeiptrARB = System.IntPtr;
	using GLintptrARB = System.IntPtr;
	using GLhandleARB = System.Int32;
	using GLhalfARB = System.Int16;
	using GLhalfNV = System.Int16;
	using GLcharARB = System.Char;
	using GLsizei = System.Int32;
	using GLsizeiptr = System.IntPtr;
	using GLintptr = System.IntPtr;
	using GLenum = System.Int32;
	using GLboolean = System.Boolean;
	using GLbitfield = System.Int32;
	using GLchar = System.Char;
	using GLbyte = System.Byte;
	using GLubyte = System.Byte;
	using GLshort = System.Int16;
	using GLushort = System.Int16;
	using GLint = System.Int32;
	using GLuint = System.Int32;
	using GLfloat = System.Single;
	using GLclampf = System.Single;
	using GLdouble = System.Double;
	using GLclampd = System.Double;
	using GLstring = System.String;
	using System.Security;

	#endregion GL Types

	#region Class Documentation
	/// <summary>
	///     GLX (OpenGL XWindow Extensions) binding for .NET, implementing GLX 1.4.
	/// </summary>
	/// <remarks>
	///     <para>
	///         Binds functions and definitions in libGL.so.
	///     </para>
	///     <para>
	///         The OpenGL XWindow Extensions (GLX) library contains several groups of functions that
	///         complement the core OpenGL interface by providing integration with XWindows.
    /// </para>
	///     <para>
	///         These utility functions make use of core OpenGL functions, so any OpenGL
	///         implementation is guaranteed to support the utility functions.
	///     </para>
	/// </remarks>
	#endregion Class Documentation
	public class Glx
	{

		#region Constants and Enumerations

		#region string LIBGL
		/// <summary>
		///		Specifies the library the functions are located in.
		/// </summary>
		private const string LIBGL = "libGL.so.1";
		#endregion string LIBGL

		#region CallingConvention CALLING_CONVENTION
		/// <summary>
		///     Specifies the calling convention.
		/// </summary>
		/// <remarks>
		///     Specifies <see cref="CallingConvention.Winapi" /> for Windows and
		///     Linux, to indicate that the default should be used.
		/// </remarks>
		private const CallingConvention CALLING_CONVENTION = CallingConvention.Winapi;
		#endregion CallingConvention CALLING_CONVENTION

        /// <summary>
        /// 
        /// </summary>
		public const bool GLX_VERSION_1_1 = true;
        /// <summary>
        /// 
        /// </summary>
		public const bool GLX_VERSION_1_2 = true;
        /// <summary>
        /// 
        /// </summary>
		public const bool GLX_VERSION_1_3 = true;
        /// <summary>
        /// 
        /// </summary>
		public const bool GLX_VERSION_1_4 = true;

		/*
		** Visual Config Attributes (glXGetConfig, glXGetFBConfigAttrib)
		*/
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_USE_GL = 1;	/* support GLX rendering */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_BUFFER_SIZE = 2;	/* depth of the color buffer */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_LEVEL = 3;	/* level in plane stacking */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_RGBA = 4;	/* true if RGBA mode */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_DOUBLEBUFFER = 5;	/* double buffering supported */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_STEREO = 6;	/* stereo buffering supported */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_AUX_BUFFERS = 7;	/* number of aux buffers */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_RED_SIZE = 8;	/* number of red component bits */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_GREEN_SIZE = 9;	/* number of green component bits */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_BLUE_SIZE = 10;	/* number of blue component bits */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_ALPHA_SIZE = 11;	/* number of alpha component bits */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_DEPTH_SIZE = 12;	/* number of depth bits */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_STENCIL_SIZE = 13;	/* number of stencil bits */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_ACCUM_RED_SIZE = 14;	/* number of red accum bits */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_ACCUM_GREEN_SIZE = 15;	/* number of green accum bits */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_ACCUM_BLUE_SIZE = 16;	/* number of blue accum bits */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_ACCUM_ALPHA_SIZE = 17;	/* number of alpha accum bits */

		/*
		** FBConfig-specific attributes
		*/
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_X_VISUAL_TYPE = 0x22;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_CONFIG_CAVEAT = 0x20;	/* Like visual_info VISUAL_CAVEAT_EXT */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_TYPE = 0x23;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_INDEX_VALUE = 0x24;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_RED_VALUE = 0x25;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_GREEN_VALUE = 0x26;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_BLUE_VALUE = 0x27;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_ALPHA_VALUE = 0x28;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_DRAWABLE_TYPE = 0x8010;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_RENDER_TYPE = 0x8011;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_X_RENDERABLE = 0x8012;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_FBCONFIG_ID = 0x8013;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_MAX_PBUFFER_WIDTH = 0x8016;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_MAX_PBUFFER_HEIGHT = 0x8017;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_MAX_PBUFFER_PIXELS = 0x8018;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_VISUAL_ID = 0x800B;

		/* FBConfigSGIX Attributes */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_OPTIMAL_PBUFFER_WIDTH_SGIX = 0x8019;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_OPTIMAL_PBUFFER_HEIGHT_SGIX = 0x801A;

		/*
		** Error return values from glXGetConfig.  Success is indicated by
		** a value of 0.
		*/
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_BAD_SCREEN = 1;	/* screen # is bad */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_BAD_ATTRIBUTE = 2;	/* attribute to get is bad */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_NO_EXTENSION = 3;	/* no glx extension on server */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_BAD_VISUAL = 4;	/* visual # not known by GLX */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_BAD_CONTEXT = 5;	/* returned only by import_context EXT? */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_BAD_VALUE = 6;	/* returned only by glXSwapIntervalSGI? */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_BAD_ENUM = 7;	/* unused? */

		/* FBConfig attribute values */

		/*
		** Generic "don't care" value for glX ChooseFBConfig attributes (except
		** GLX_LEVEL)
		*/
        /// <summary>
        /// 
        /// </summary>
        [CLSCompliant(false)]
		public const uint GLX_DONT_CARE = 0xFFFFFFFF;

		/* GLX_RENDER_TYPE bits */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_RGBA_BIT = 0x00000001;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_COLOR_INDEX_BIT = 0x00000002;

		/* GLX_DRAWABLE_TYPE bits */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_WINDOW_BIT = 0x00000001;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_PIXMAP_BIT = 0x00000002;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_PBUFFER_BIT = 0x00000004;

		/* GLX_CONFIG_CAVEAT attribute values */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_NONE = 0x8000;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_SLOW_CONFIG = 0x8001;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_NON_CONFORMANT_CONFIG = 0x800D;

		/* GLX_X_VISUAL_TYPE attribute values */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRUE_COLOR = 0x8002;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_DIRECT_COLOR = 0x8003;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_PSEUDO_COLOR = 0x8004;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_STATIC_COLOR = 0x8005;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_GRAY_SCALE = 0x8006;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_STATIC_GRAY = 0x8007;

		/* GLX_TRANSPARENT_TYPE attribute values */
		/* public const int GLX_NONE			   0x8000 */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_RGB = 0x8008;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_INDEX = 0x8009;

		/* glXCreateGLXPbuffer attributes */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_PRESERVED_CONTENTS = 0x801B;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_LARGEST_PBUFFER = 0x801C;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_PBUFFER_HEIGHT = 0x8040;	/* New for GLX 1.3 */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_PBUFFER_WIDTH = 0x8041;	/* New for GLX 1.3 */

		/* glXQueryGLXPBuffer attributes */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_WIDTH = 0x801D;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_HEIGHT = 0x801E;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_EVENT_MASK = 0x801F;

		/* glXCreateNewContext render_type attribute values */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_RGBA_TYPE = 0x8014;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_COLOR_INDEX_TYPE = 0x8015;

		/* glXQueryContext attributes */
		/* public const int GLX_FBCONFIG_ID		  0x8013 */
		/* public const int GLX_RENDER_TYPE		  0x8011 */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_SCREEN = 0x800C;

		/* glXSelectEvent event mask bits */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_PBUFFER_CLOBBER_MASK = 0x08000000;

		/* GLXPbufferClobberEvent event_type values */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_DAMAGED = 0x8020;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_SAVED = 0x8021;

		/* GLXPbufferClobberEvent draw_type values */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_WINDOW = 0x8022;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_PBUFFER = 0x8023;

		/* GLXPbufferClobberEvent buffer_mask bits */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_FRONT_LEFT_BUFFER_BIT = 0x00000001;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_FRONT_RIGHT_BUFFER_BIT = 0x00000002;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_BACK_LEFT_BUFFER_BIT = 0x00000004;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_BACK_RIGHT_BUFFER_BIT = 0x00000008;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_AUX_BUFFERS_BIT = 0x00000010;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_DEPTH_BUFFER_BIT = 0x00000020;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_STENCIL_BUFFER_BIT = 0x00000040;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_ACCUM_BUFFER_BIT = 0x00000080;

		/*
		** Extension return values from glXGetConfig.  These are also
		** accepted as parameter values for glXChooseVisual.
		*/

        /// <summary>
        /// 
        /// </summary>
		public const int GLX_X_VISUAL_TYPE_EXT = 0x22;	/* visual_info extension type */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_TYPE_EXT = 0x23;	/* visual_info extension */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_INDEX_VALUE_EXT = 0x24;	/* visual_info extension */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_RED_VALUE_EXT = 0x25;	/* visual_info extension */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_GREEN_VALUE_EXT = 0x26;	/* visual_info extension */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_BLUE_VALUE_EXT = 0x27;	/* visual_info extension */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_ALPHA_VALUE_EXT = 0x28;	/* visual_info extension */

		/* Property values for visual_type */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRUE_COLOR_EXT = 0x8002;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_DIRECT_COLOR_EXT = 0x8003;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_PSEUDO_COLOR_EXT = 0x8004;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_STATIC_COLOR_EXT = 0x8005;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_GRAY_SCALE_EXT = 0x8006;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_STATIC_GRAY_EXT = 0x8007;

		/* Property values for transparent pixel */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_NONE_EXT = 0x8000;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_RGB_EXT = 0x8008;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_TRANSPARENT_INDEX_EXT = 0x8009;

		/* Property values for visual_rating */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_VISUAL_CAVEAT_EXT = 0x20;  /* visual_rating extension type */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_SLOW_VISUAL_EXT = 0x8001;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_NON_CONFORMANT_VISUAL_EXT = 0x800D;

		/* Property values for swap method (GLX_OML_swap_method) */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_SWAP_METHOD_OML = 0x8060;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_SWAP_EXCHANGE_OML = 0x8061;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_SWAP_COPY_OML = 0x8062;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_SWAP_UNDEFINED_OML = 0x8063;

		/* Property values for multi-sampling */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_VISUAL_SELECT_GROUP_SGIX = 0x8028;	/* visuals grouped by select priority */

		/*
		** Names for attributes to glXGetClientString.
		*/
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_VENDOR = 0x1;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_VERSION = 0x2;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_EXTENSIONS = 0x3;

		/*
		** Names for attributes to glXQueryContextInfoEXT.
		*/
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_SHARE_CONTEXT_EXT = 0x800A;	/* id of share context */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_VISUAL_ID_EXT = 0x800B;	/* id of context's visual */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_SCREEN_EXT = 0x800C;	/* screen number */

		/*
		 * GLX 1.4 and later:
		 */
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_SAMPLE_BUFFERS_SGIS = 100000;
        /// <summary>
        /// 
        /// </summary>
		public const int GLX_SAMPLES_SGIS = 100001;

		/* GLX extensions */
        /// <summary>
        /// 
        /// </summary>
		public const bool GLX_EXT_import_context = true;
        /// <summary>
        /// 
        /// </summary>
		public const bool GLX_EXT_visual_info = true;
        /// <summary>
        /// 
        /// </summary>
		public const bool GLX_EXT_visual_rating = true;
        /// <summary>
        /// 
        /// </summary>
		public const bool GLX_ARB_get_proc_address = true;

		#endregion Constants and Enumerations

		#region GLX functions

		#region IntPtr glXChooseVisual( IntPtr dpy, int screen, IntPtr attriblist )
		//extern XVisualInfo* glXChooseVisual (Display *dpy, int screen, int *attribList);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="screen"></param>
        /// <param name="attriblist"></param>
        /// <returns></returns>
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXChooseVisual" ), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glXChooseVisual( IntPtr dpy, int screen, IntPtr attriblist );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="screen"></param>
        /// <param name="attrib"></param>
        /// <returns></returns>
		public static IntPtr glXChooseVisual( IntPtr dpy, int screen, int attrib )
		{
			GCHandle h0 = GCHandle.Alloc( attrib, GCHandleType.Pinned );

			try
			{
				return glXChooseVisual( dpy, screen, h0.AddrOfPinnedObject() );
			}
			finally
			{
				h0.Free();
			}
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="screen"></param>
        /// <param name="attriblist"></param>
        /// <returns></returns>
		public static IntPtr glXChooseVisual( IntPtr dpy, int screen, int[] attriblist )
		{
			GCHandle h0 = GCHandle.Alloc( attriblist, GCHandleType.Pinned );

			try
			{
				return glXChooseVisual( dpy, screen, h0.AddrOfPinnedObject() );
			}
			finally
			{
				h0.Free();
			}
		}
		#endregion IntPtr glXChooseVisual( IntPtr dpy, int screen, IntPtr attriblist )

		#region void glXCopyContext( IntPtr dpy, IntPtr src, IntPtr dst, ulong mask )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="src"></param>
		/// <param name="dst"></param>
		/// <param name="mask"></param>
		//extern void glXCopyContext (Display *dpy, GLXContext src, GLXContext dst, unsigned long mask);
        [CLSCompliant(false)]
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXCopyContext" ), SuppressUnmanagedCodeSecurity]
		public static extern void glXCopyContext( IntPtr dpy, IntPtr src, IntPtr dst, ulong mask );
		#endregion void glXCopyContext( IntPtr dpy, IntPtr src, IntPtr dst, ulong mask )

		#region IntPtr glXCreateContext( IntPtr dpy, IntPtr vis, IntPtr shareList, bool direct )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="vis"></param>
		/// <param name="shareList"></param>
		/// <param name="direct"></param>
		/// <returns></returns>
		//extern GLXContext glXCreateContext (Display *dpy, XVisualInfo *vis, GLXContext shareList, Bool direct);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXCreateContext" ), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glXCreateContext( IntPtr dpy, IntPtr vis, IntPtr shareList, bool direct );
		#endregion IntPtr glXCreateContext( IntPtr dpy, IntPtr vis, IntPtr shareList, bool direct )

		#region IntPtr glXCreateGLXPixmap( IntPtr dpy, IntPtr vis, Pixmap pixmap )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="vis"></param>
		/// <param name="pixmap"></param>
		/// <returns></returns>
		//extern GLXPixmap glXCreateGLXPixmap (Display *dpy, XVisualInfo *vis, Pixmap pixmap);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXCreateGLXPixmap" ), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glXCreateGLXPixmap( IntPtr dpy, IntPtr vis, IntPtr pixmap );
		#endregion IntPtr glXCreateGLXPixmap( IntPtr dpy, IntPtr vis, Pixmap pixmap )

		#region void glXDestroyContext( IntPtr dpy, IntPtr context )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="context"></param>
		//extern void glXDestroyContext (Display *dpy, GLXContext ctx);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXDestroyContext" ), SuppressUnmanagedCodeSecurity]
		public static extern void glXDestroyContext( IntPtr dpy, IntPtr context );
		#endregion void glXDestroyContext( IntPtr dpy, IntPtr context )

		#region void glXDestroyGLXPixmap( IntPtr dpy, IntPtr pix )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="pix"></param>
		//extern void glXDestroyGLXPixmap (Display *dpy, GLXPixmap pix);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXDestroyGLXPixmap" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern void glXDestroyGLXPixmap( IntPtr dpy, IntPtr pix );
		#endregion void glXDestroyGLXPixmap( IntPtr dpy, IntPtr pix )

		#region int glXGetConfig( IntPtr dpy, IntPtr vis, int attrib, IntPtr value )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="vis"></param>
		/// <param name="attrib"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		//extern int glXGetConfig (Display *dpy, XVisualInfo *vis, int attrib, int *value);		
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetConfig" ), SuppressUnmanagedCodeSecurity]
		public static extern int glXGetConfig( IntPtr dpy, IntPtr vis, int attrib, IntPtr value );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="vis"></param>
        /// <param name="attrib"></param>
        /// <param name="val"></param>
        /// <returns></returns>
		public static int glXGetConfig( IntPtr dpy, IntPtr vis, int attrib, int val )
		{
			GCHandle h0 = GCHandle.Alloc( val, GCHandleType.Pinned );

			try
			{
                XVisualInfo info = (XVisualInfo)Marshal.PtrToStructure(vis, typeof(XVisualInfo));
				return glXChooseVisual( dpy, info.screen, h0.AddrOfPinnedObject().ToInt32() ).ToInt32();
			}
			finally
			{
				h0.Free();
			}
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="vis"></param>
        /// <param name="attrib"></param>
        /// <param name="val"></param>
        /// <returns></returns>
		public static int glXGetConfig( IntPtr dpy, IntPtr vis, int attrib, int[] val )
		{
			GCHandle h0 = GCHandle.Alloc( val, GCHandleType.Pinned );

			try
			{
                XVisualInfo info = (XVisualInfo)Marshal.PtrToStructure(vis, typeof(XVisualInfo));
                return glXChooseVisual(dpy, info.screen, h0.AddrOfPinnedObject().ToInt32()).ToInt32();
			}
			finally
			{
				h0.Free();
			}
		}
		#endregion int glXGetConfig( IntPtr dpy, IntPtr vis, int attrib, IntPtr value )

		#region IntPtr glXGetCurrentContext()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		//extern GLXContext glXGetCurrentContext (void);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetCurrentContext" ), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glXGetCurrentContext();
		#endregion IntPtr glXGetCurrentContext()

		#region IntPtr glXGetCurrentDrawable()
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		//extern GLXDrawable glXGetCurrentDrawable (void);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetCurrentDrawable" ), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glXGetCurrentDrawable();
		#endregion IntPtr glXGetCurrentDrawable()

		#region bool glXIsDirect( IntPtr dpy, IntPtr ctx )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="ctx"></param>
		/// <returns></returns>
		//extern Bool glXIsDirect (Display *dpy, GLXContext ctx);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXIsDirect" ), SuppressUnmanagedCodeSecurity]
		public static extern bool glXIsDirect( IntPtr dpy, IntPtr ctx );
		#endregion bool glXIsDirect( IntPtr dpy, IntPtr ctx )

		#region bool glXMakeCurrent( IntPtr display, IntPtr drawable, IntPtr context )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="display"></param>
		/// <param name="drawable"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		//extern Bool glXMakeCurrent (Display *dpy, GLXDrawable drawable, GLXContext ctx);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXMakeCurrent" ), SuppressUnmanagedCodeSecurity]
		public static extern bool glXMakeCurrent( IntPtr display, IntPtr drawable, IntPtr context );
		#endregion bool glXMakeCurrent( IntPtr display, IntPtr drawable, IntPtr context )

		#region bool glXQueryExtension( IntPtr dpy, IntPtr errorBase, IntPtr eventBase )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="errorBase"></param>
		/// <param name="eventBase"></param>
		/// <returns></returns>
		//extern Bool glXQueryExtension (Display *dpy, int *errorBase, int *eventBase);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXQueryExtension" ), SuppressUnmanagedCodeSecurity]
		public static extern bool glXQueryExtension( IntPtr dpy, IntPtr errorBase, IntPtr eventBase );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="errorBase"></param>
        /// <param name="eventBase"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXQueryExtension"), SuppressUnmanagedCodeSecurity]
		public static unsafe extern bool glXQueryExtension( IntPtr dpy, int* errorBase, int* eventBase );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="errorBase"></param>
        /// <param name="eventBase"></param>
        /// <returns></returns>
		public static unsafe bool glXQueryExtension( IntPtr dpy, int errorBase, int eventBase )
		{
			GCHandle h0 = GCHandle.Alloc( errorBase, GCHandleType.Pinned );
			GCHandle h1 = GCHandle.Alloc( eventBase, GCHandleType.Pinned );

			try
			{
				return glXQueryExtension( dpy, h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject() );
			}
			finally
			{
				h0.Free();
				h1.Free();
			}
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="errorBase"></param>
        /// <param name="eventBase"></param>
        /// <returns></returns>
		public static unsafe bool glXQueryExtension( IntPtr dpy, int[] errorBase, int[] eventBase )
		{
			GCHandle h0 = GCHandle.Alloc( errorBase, GCHandleType.Pinned );
			GCHandle h1 = GCHandle.Alloc( eventBase, GCHandleType.Pinned );

			try
			{
				return glXQueryExtension( dpy, h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject() );
			}
			finally
			{
				h0.Free();
				h1.Free();
			}
		}
		#endregion bool glXQueryExtension( IntPtr dpy, IntPtr errorBase, IntPtr eventBase )

		#region bool glXQueryVersion( IntPtr dpy, IntPtr major, IntPtr minor )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="major"></param>
		/// <param name="minor"></param>
		/// <returns></returns>
		//extern Bool glXQueryVersion (Display *dpy, int *major, int *minor);		
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXQueryVersion" ), SuppressUnmanagedCodeSecurity]
		public static extern bool glXQueryVersion( IntPtr dpy, IntPtr major, IntPtr minor );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXQueryVersion"), SuppressUnmanagedCodeSecurity]
		public static unsafe extern bool glXQueryVersion( IntPtr dpy, int* major, int* minor );
		//public static unsafe extern bool glXQueryVersion( IntPtr dpy, out int major, out int minor )
		//{
		//	return new NotImplementedException();
		//}
		//public static unsafe extern bool glXQueryVersion( IntPtr dpy, out int[] major, out int[] minor )
		//{
		//	return new NotImplementedException();
		//}
		#endregion bool glXQueryVersion( IntPtr dpy, IntPtr major, IntPtr minor )

		#region void glXSwapBuffers( IntPtr display, IntPtr drawable )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="display"></param>
		/// <param name="drawable"></param>
		//extern void glXSwapBuffers (Display *dpy, GLXDrawable drawable);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXSwapBuffers" ), SuppressUnmanagedCodeSecurity]
		public static extern void glXSwapBuffers( IntPtr display, IntPtr drawable );
		#endregion void glXSwapBuffers( IntPtr display, IntPtr drawable )

		#region void glXUseXFont( IntPtr font, int first, int count, int listBase )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="font"></param>
		/// <param name="first"></param>
		/// <param name="count"></param>
		/// <param name="listBase"></param>
		//extern void glXUseXFont (Font font, int first, int count, int listBase);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXUseXFont" ), SuppressUnmanagedCodeSecurity]
		public static extern void glXUseXFont( IntPtr font, int first, int count, int listBase );
		#endregion void glXUseXFont( IntPtr font, int first, int count, int listBase )

		#region void glXWaitGL()
		/// <summary>
		/// 
		/// </summary>
		//extern void glXWaitGL (void);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXWaitGL" ), SuppressUnmanagedCodeSecurity]
		public static extern void glXWaitGL();
		#endregion void glXWaitGL()

		#region void glXWaitX()
		/// <summary>
		/// 
		/// </summary>
		//extern void glXWaitX (void);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXWaitX" ), SuppressUnmanagedCodeSecurity]
		public static extern void glXWaitX();
		#endregion void glXWaitX()

		#region IntPtr glXGetClientString( IntPtr dpy, int name )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		//extern const char * glXGetClientString (Display *dpy, int name );
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetClientString" ), SuppressUnmanagedCodeSecurity]
		public static extern string glXGetClientString( IntPtr dpy, int name );
		#endregion IntPtr glXGetClientString( IntPtr dpy, int name )

		#region IntPtr glXQueryServerString( IntPtr dpy, int screen, int name )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="screen"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		//extern const char * glXQueryServerString (Display *dpy, int screen, int name );
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXQueryServerString" ), SuppressUnmanagedCodeSecurity]
		public static extern string glXQueryServerString( IntPtr dpy, int screen, int name );
		#endregion IntPtr glXQueryServerString( IntPtr dpy, int screen, int name )

		#region IntPtr glXQueryExtensionsString( IntPtr dpy, int screen )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="screen"></param>
		/// <returns></returns>
		//extern const char * glXQueryExtensionsString (Display *dpy, int screen );
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXQueryExtensionsString" ), SuppressUnmanagedCodeSecurity]
		public static extern string glXQueryExtensionsString( IntPtr dpy, int screen );
		#endregion IntPtr glXQueryExtensionsString( IntPtr dpy, int screen )

		/* New for GLX 1.3 */

		#region IntPtr glXGetFBConfigs( IntPtr dpy, int screen, int* nelements )
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="screen"></param>
		/// <param name="nelements"></param>
		/// <returns></returns>
		//extern GLXFBConfig * glXGetFBConfigs (Display *dpy, int screen, int *nelements);
        [CLSCompliant(false)]
        [DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetFBConfigs" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern IntPtr glXGetFBConfigs( IntPtr dpy, int screen, int* nelements );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="screen"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetFBConfigs"), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glXGetFBConfigs( IntPtr dpy, int screen, int element );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="screen"></param>
        /// <param name="nelements"></param>
        /// <returns></returns>
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetFBConfigs"), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glXGetFBConfigs( IntPtr dpy, int screen, int[] nelements );
		#endregion IntPtr glXGetFBConfigs( IntPtr dpy, int screen, int* nelements )

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="screen"></param>
		/// <param name="attrib_list"></param>
		/// <param name="nelements"></param>
		/// <returns></returns>
		//extern GLXFBConfig * glXChooseFBConfig (Display *dpy, int screen, const int *attrib_list, int *nelements);
        [CLSCompliant(false)]
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXChooseFBConfig" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern IntPtr glXChooseFBConfig( IntPtr dpy, int screen, int* attrib_list, int* nelements );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="screen"></param>
        /// <param name="attrib_list"></param>
        /// <param name="nelements"></param>
        /// <returns></returns>
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXChooseFBConfig"), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glXChooseFBConfig( IntPtr dpy, int screen, int attrib_list, int nelements );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="screen"></param>
        /// <param name="attrib_list"></param>
        /// <param name="nelements"></param>
        /// <returns></returns>
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXChooseFBConfig"), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glXChooseFBConfig( IntPtr dpy, int screen, int[] attrib_list, int[] nelements );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="config"></param>
		/// <param name="attribute"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		//extern int glXGetFBConfigAttrib (Display *dpy, GLXFBConfig config, int attribute, int *value);
        [CLSCompliant(false)]
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetFBConfigAttrib" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern int glXGetFBConfigAttrib( IntPtr dpy, IntPtr config, int attribute, int* value );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="config"></param>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetFBConfigAttrib"), SuppressUnmanagedCodeSecurity]
		public static extern int glXGetFBConfigAttrib( IntPtr dpy, IntPtr config, int attribute, int value );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="config"></param>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetFBConfigAttrib"), SuppressUnmanagedCodeSecurity]
		public static extern int glXGetFBConfigAttrib( IntPtr dpy, IntPtr config, int attribute, int[] value );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="config"></param>
		/// <returns></returns>
		//extern XVisualInfo * glXGetVisualFromFBConfig (Display *dpy, GLXFBConfig config);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetVisualFromFBConfig" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern IntPtr glXGetVisualFromFBConfig(IntPtr dpy, IntPtr config );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="config"></param>
		/// <param name="win"></param>
		/// <param name="attrib_list"></param>
		/// <returns></returns>
		//extern GLXWindow glXCreateWindow (Display *dpy, GLXFBConfig config, Window win, const int *attrib_list);
        [CLSCompliant(false)]
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXCreateWindow" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern int glXCreateWindow( IntPtr dpy, IntPtr config, int win, int* attrib_list );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="config"></param>
        /// <param name="win"></param>
        /// <param name="attrib_list"></param>
        /// <returns></returns>
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXCreateWindow"), SuppressUnmanagedCodeSecurity]
		public static extern int glXCreateWindow( IntPtr dpy, IntPtr config, int win, int[] attrib_list );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="win"></param>
		//extern void glXDestroyWindow (Display *dpy, GLXWindow win);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXDestroyWindow" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern void glXDestroyWindow( IntPtr dpy, int win );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="config"></param>
		/// <param name="pixmap"></param>
		/// <param name="attrib_list"></param>
		/// <returns></returns>
		//extern GLXPixmap glXCreatePixmap (Display *dpy, GLXFBConfig config, Pixmap pixmap, const int *attrib_list);
        [CLSCompliant(false)]
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXCreatePixmap" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern int glXCreatePixmap( IntPtr dpy, IntPtr config, IntPtr pixmap, int* attrib_list );
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="config"></param>
        /// <param name="pixmap"></param>
        /// <param name="attrib_list"></param>
        /// <returns></returns>
        [DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXCreatePixmap" ), SuppressUnmanagedCodeSecurity]
        public static extern int glXCreatePixmap( IntPtr dpy, IntPtr config, IntPtr pixmap, int[] attrib_list );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="pixmap"></param>
		//extern void glXDestroyPixmap (Display *dpy, GLXPixmap pixmap);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXDestroyPixmap" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern void glXDestroyPixmap( IntPtr dpy, int pixmap );
		//public static void glXDestroyPixmap( IntPtr dpy, int pixmap );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="config"></param>
		/// <param name="attrib_list"></param>
		/// <returns></returns>
		//extern GLXPbuffer glXCreatePbuffer (Display *dpy, GLXFBConfig config, const int *attrib_list);
        [CLSCompliant(false)]
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXCreatePbuffer" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern IntPtr glXCreatePbuffer( IntPtr dpy, IntPtr config, int* attrib_list );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="config"></param>
        /// <param name="attrib_list"></param>
        /// <returns></returns>
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXCreatePbuffer"), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glXCreatePbuffer( IntPtr dpy, IntPtr config, int[] attrib_list );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="pbuf"></param>
		//extern void glXDestroyPbuffer (Display *dpy, GLXPbuffer pbuf);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXDestroyPbuffer" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern void glXDestroyPbuffer( IntPtr dpy, IntPtr pbuf );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="draw"></param>
		/// <param name="attribute"></param>
		/// <param name="value"></param>
		//extern void glXQueryDrawable (Display *dpy, GLXDrawable draw, int attribute, unsigned int *value);
        [CLSCompliant(false)]
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXQueryDrawable" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern void glXQueryDrawable( IntPtr dpy, IntPtr draw, int attribute, uint* value );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="draw"></param>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        [CLSCompliant(false)]
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXQueryDrawable"), SuppressUnmanagedCodeSecurity]
		public static extern void glXQueryDrawable( IntPtr dpy, IntPtr draw, int attribute, uint[] value );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="config"></param>
		/// <param name="render_type"></param>
		/// <param name="share_list"></param>
		/// <param name="direct"></param>
		/// <returns></returns>
		//extern GLXContext glXCreateNewContext (Display *dpy, GLXFBConfig config, int render_type, GLXContext share_list, Bool direct);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXCreateNewContext" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern IntPtr glXCreateNewContext( IntPtr dpy, IntPtr config, int render_type, IntPtr share_list, bool direct );


		/// <summary>
		/// 
		/// </summary>
		/// <param name="display"></param>
		/// <param name="draw"></param>
		/// <param name="read"></param>
		/// <param name="ctx"></param>
		/// <returns></returns>
		//extern Bool glXMakeContextCurrent (Display *display, GLXDrawable draw, GLXDrawable read, GLXContext ctx);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXMakeContextCurrent" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern bool glXMakeContextCurrent( IntPtr display, IntPtr draw, IntPtr read, IntPtr ctx );

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		//extern GLXDrawable glXGetCurrentReadDrawable (void);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetCurrentReadDrawable" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern IntPtr glXGetCurrentReadDrawable();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		//extern Display * glXGetCurrentDisplay (void);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetCurrentDisplay" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern IntPtr glXGetCurrentDisplay();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="ctx"></param>
		/// <param name="attribute"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		//extern int glXQueryContext (Display *dpy, GLXContext ctx, int attribute, int *value);
        [CLSCompliant(false)]
        [DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXQueryContext" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern int glXQueryContext( IntPtr dpy, IntPtr ctx, int attribute, int* value );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="ctx"></param>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXQueryContext"), SuppressUnmanagedCodeSecurity]
		public static extern int glXQueryContext( IntPtr dpy, IntPtr ctx, int attribute, int value );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="ctx"></param>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXQueryContext" ), SuppressUnmanagedCodeSecurity]
		public static extern int glXQueryContext( IntPtr dpy, IntPtr ctx, int attribute, int[] value );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="draw"></param>
		/// <param name="event_mask"></param>
		//extern void glXSelectEvent (Display *dpy, GLXDrawable draw, unsigned long event_mask);		
        [CLSCompliant(false)]
        [DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXSelectEvent" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern void glXSelectEvent( IntPtr dpy, IntPtr draw, ulong event_mask );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="draw"></param>
		/// <param name="event_mask"></param>
		//extern void glXGetSelectedEvent (Display *dpy, GLXDrawable draw, unsigned long *event_mask);
        [CLSCompliant(false)]
        [DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetSelectedEvent" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern void glXGetSelectedEvent( IntPtr dpy, IntPtr draw, ulong* event_mask );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="draw"></param>
        /// <param name="event_mask"></param>
        [CLSCompliant(false)]
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetSelectedEvent"), SuppressUnmanagedCodeSecurity]
        public static unsafe extern void glXGetSelectedEvent( IntPtr dpy, IntPtr draw, ulong event_mask );

		/* GLX 1.4 and later */

		/// <summary>
		/// 
		/// </summary>
		/// <param name="procName"></param>
		/// <returns></returns>
		//extern void (*glXGetProcAddress(const GLubyte *procname))(void);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetProcAddress" ), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glxGetProcAddress( [MarshalAs( UnmanagedType.LPTStr )] string procName );


		/* GLX extensions */

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		/// <returns></returns>
		//extern GLXContextID glXGetContextIDEXT (const GLXContext ctx);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetContextIDEXT" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern int glXGetContextIDEXT( IntPtr ctx );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="contextID"></param>
		/// <returns></returns>
		//extern GLXContext glXImportContextEXT (Display *dpy, GLXContextID contextID);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXImportContextEXT" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern IntPtr glXImportContextEXT( IntPtr dpy, int contextID );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="ctx"></param>
		//extern void glXFreeContextEXT (Display *dpy, GLXContext ctx);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXFreeContextEXT" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern void glXFreeContextEXT( IntPtr dpy, IntPtr ctx );

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dpy"></param>
		/// <param name="ctx"></param>
		/// <param name="attribute"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		//extern int glXQueryContextInfoEXT (Display *dpy, GLXContext ctx, int attribute, int *value);
        [CLSCompliant(false)]
        [DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXQueryContextInfoEXT" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern int glXQueryContextInfoEXT( IntPtr dpy, IntPtr ctx, int attribute, int* value );
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpy"></param>
        /// <param name="ctx"></param>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImport(LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXQueryContextInfoEXT"), SuppressUnmanagedCodeSecurity]
        public static unsafe extern int glXQueryContextInfoEXT( IntPtr dpy, IntPtr ctx, int attribute, int value );

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		//extern Display * glXGetCurrentDisplayEXT (void);
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetCurrentDisplayEXT" ), SuppressUnmanagedCodeSecurity]
		public static unsafe extern IntPtr glXGetCurrentDisplayEXT();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="procName"></param>
		/// <returns></returns>
		//extern void (*glXGetProcAddressARB(const GLubyte *procName))( void );
		[DllImport( LIBGL, CallingConvention = CALLING_CONVENTION, EntryPoint = "glXGetProcAddressARB" ), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glXGetProcAddressARB( [MarshalAs( UnmanagedType.LPTStr )] string procName );

		#endregion
	}
}
