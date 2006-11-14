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
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Tao.OpenGl;

namespace Tao.FreeGlut {
    #region Class Documentation
    /// <summary>
    ///     FreeGLUT (OpenGL Utility Toolkit) binding for .NET, implementing FreeGlut 2.4.0.
    /// </summary>
    #endregion Class Documentation
    public static class Glut
    {
        // --- Fields ---
        #region Private Constants
	#region string FREEGLUT_NATIVE_LIBRARY
	/// <summary>
	///     Specifies FREEGLUT's native library archive.
	/// </summary>
	/// <remarks>
	///     Specifies freeglut.dll everywhere; will be mapped via .config for mono.
	/// </remarks>
	private const string FREEGLUT_NATIVE_LIBRARY = "freeglut.dll";
	#endregion string FREEGLUT_NATIVE_LIBRARY
        
	#region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.Winapi" />.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Winapi;
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants

        #region Public Constants
        #region Versions
        #region int FREEGLUT
        /// <summary>
        ///     FreeGLUT API marker.
        /// </summary>
        // #define FREEGLUT 1
        public const int FREEGLUT = 1;
        #endregion int FREEGLUT

        #region int FREEGLUT_VERSION_2_0
        /// <summary>
        ///     FreeGLUT API version marker.
        /// </summary>
        // #define FREEGLUT_VERSION_2_0 1
        public const int FREEGLUT_VERSION_2_0 = 1;
        #endregion int FREEGLUT_VERSION_2_0

        #region int GLUT_API_VERSION
        /// <summary>
        ///     GLUT API revision.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         GLUT_API_VERSION is updated to reflect incompatible GLUT API changes
        ///         (interface changes, semantic changes, deletions, or additions).
        ///     </para>
        ///     <para>
        ///         GLUT_API_VERSION=1  First public release of GLUT.  11/29/94
        ///     </para>
        ///     <para>
        ///         GLUT_API_VERSION=2  Added support for OpenGL/GLX multisampling, extension.
        ///         Supports new input devices like tablet, dial and button box, and Spaceball.
        ///         Easy to query OpenGL extensions.
        ///     </para>
        ///     <para>
        ///         GLUT_API_VERSION=3  glutMenuStatus added.
        ///     </para>
        ///     <para>
        ///          GLUT_API_VERSION=4  glutInitDisplayString, glutWarpPointer, glutBitmapLength,
        ///          glutStrokeLength, glutWindowStatusFunc, dynamic video resize subAPI,
        ///          glutPostWindowRedisplay, glutKeyboardUpFunc, glutSpecialUpFunc,
        ///          glutIgnoreKeyRepeat, glutSetKeyRepeat, glutJoystickFunc,
        ///          glutForceJoystickFunc (NOT FINALIZED!).
        ///     </para>
        /// </remarks>
        // #define GLUT_API_VERSION 4
        public const int GLUT_API_VERSION = 4;
        #endregion int GLUT_API_VERSION

	#region int GLUT_XLIB_IMPLEMENTATION
	// #define  GLUT_XLIB_IMPLEMENTATION 13
	/// <summary>
        ///     
        /// </summary>
	public const int GLUT_XLIB_IMPLEMENTATION = 13;
	#endregion int GLUT_XLIB_IMPLEMENTATION
        #endregion Versions

        #region Display mode bit masks
        #region int GLUT_RGB
        /// <summary>
        ///     An alias for <see cref="GLUT_RGBA" />.
        /// </summary>
        // #define GLUT_RGB 0
        public const int GLUT_RGB = 0;
        #endregion int GLUT_RGB

        #region int GLUT_RGBA
        /// <summary>
        ///     Bit mask to select an RGBA mode window.  This is the default if neither
        ///     <see cref="GLUT_RGB" />, <i>GLUT_RGBA</i>, nor <see cref="GLUT_INDEX" /> are
        ///     specified.
        /// </summary>
        // #define GLUT_RGBA GLUT_RGB
        public const int GLUT_RGBA = GLUT_RGB;
        #endregion int GLUT_RGBA

        #region int GLUT_INDEX
        /// <summary>
        ///     Bit mask to select a color index mode window.  This overrides
        ///     <see cref="GLUT_RGB" /> or <see cref="GLUT_RGBA" /> if they are also
        ///     specified.
        /// </summary>
        // #define GLUT_INDEX 1
        public const int GLUT_INDEX = 1;
        #endregion int GLUT_INDEX

        #region int GLUT_SINGLE
        /// <summary>
        ///     Bit mask to select a single buffered window.  This is the default if neither
        ///     <see cref="GLUT_DOUBLE" /> or <i>GLUT_SINGLE</i> are specified.
        /// </summary>
        // #define GLUT_SINGLE 0
        public const int GLUT_SINGLE = 0;
        #endregion int GLUT_SINGLE

        #region int GLUT_DOUBLE
        /// <summary>
        ///     Bit mask to select a double buffered window.  This overrides
        ///     <see cref="GLUT_SINGLE" /> if it is also specified.
        /// </summary>
        // #define GLUT_DOUBLE 2
        public const int GLUT_DOUBLE = 2;
        #endregion int GLUT_DOUBLE

        #region int GLUT_ACCUM
        /// <summary>
        ///     Bit mask to select a window with an accumulation buffer.
        /// </summary>
        // #define GLUT_ACCUM 4
        public const int GLUT_ACCUM = 4;
        #endregion int GLUT_ACCUM

        #region int GLUT_ALPHA
        /// <summary>
        ///     Bit mask to select a window with an alpha component to the color buffer(s).
        /// </summary>
        // #define GLUT_ALPHA 8
        public const int GLUT_ALPHA = 8;
        #endregion int GLUT_ALPHA

        #region int GLUT_DEPTH
        /// <summary>
        ///     Bit mask to select a window with a depth buffer.
        /// </summary>
        // #define GLUT_DEPTH 16
        public const int GLUT_DEPTH = 16;
        #endregion int GLUT_DEPTH

        #region int GLUT_STENCIL
        /// <summary>
        ///     Bit mask to select a window with a stencil buffer.
        /// </summary>
        // #define GLUT_STENCIL 32
        public const int GLUT_STENCIL = 32;
        #endregion int GLUT_STENCIL

        #region int GLUT_MULTISAMPLE
        /// <summary>
        ///     Bit mask to select a window with multisampling support.  If multisampling is
        ///     not available, a non-multisampling window will automatically be chosen.  Note:
        ///     both the OpenGL client-side and server-side implementations must support the
        ///     GLX_SAMPLE_SGIS extension for multisampling to be available.
        /// </summary>
        // #define GLUT_MULTISAMPLE 128
        public const int GLUT_MULTISAMPLE = 128;
        #endregion int GLUT_MULTISAMPLE

        #region int GLUT_STEREO
        /// <summary>
        ///     Bit mask to select a stereo window.
        /// </summary>
        // #define GLUT_STEREO 256
        public const int GLUT_STEREO = 256;
        #endregion int GLUT_STEREO

        #region int GLUT_LUMINANCE
        /// <summary>
        ///     Bit mask to select a window with a "luminance" color model.  This model
        ///     provides the functionality of OpenGL's RGBA color model, but the green and
        ///     blue components are not maintained in the frame buffer.  Instead each pixel's
        ///     red component is converted to an index between zero and
        ///     <c>Glut.glutGet(Glut.GLUT_WINDOW_COLORMAP_SIZE) - 1</c> and looked up in a
        ///     per-window color map to determine the color of pixels within the window.  The
        ///     initial colormap of <see cref="GLUT_LUMINANCE" /> windows is initialized to
        ///     be a linear gray ramp, but can be modified with GLUT's colormap routines.
        /// </summary>
        // #define GLUT_LUMINANCE 512
        public const int GLUT_LUMINANCE = 512;
        #endregion int GLUT_LUMINANCE
        #endregion Display mode bit masks

        #region Mouse buttons
        #region int GLUT_LEFT_BUTTON
        /// <summary>
        ///     Left mouse button.
        /// </summary>
        // #define GLUT_LEFT_BUTTON 0
        public const int GLUT_LEFT_BUTTON = 0;
        #endregion int GLUT_LEFT_BUTTON

        #region int GLUT_MIDDLE_BUTTON
        /// <summary>
        ///     Middle mouse button.
        /// </summary>
        // #define GLUT_MIDDLE_BUTTON 1
        public const int GLUT_MIDDLE_BUTTON = 1;
        #endregion int GLUT_MIDDLE_BUTTON

        #region int GLUT_RIGHT_BUTTON
        /// <summary>
        ///     Right mouse button.
        /// </summary>
        // #define GLUT_RIGHT_BUTTON 2
        public const int GLUT_RIGHT_BUTTON = 2;
        #endregion int GLUT_RIGHT_BUTTON
        #endregion Mouse buttons

        #region Mouse button state
        #region int GLUT_DOWN
        /// <summary>
        ///     Mouse button down.
        /// </summary>
        // #define GLUT_DOWN 0
        public const int GLUT_DOWN = 0;
        #endregion int GLUT_DOWN

        #region int GLUT_UP
        /// <summary>
        ///     Mouse button up.
        /// </summary>
        // #define GLUT_UP 1
        public const int GLUT_UP = 1;
        #endregion int GLUT_UP
        #endregion Mouse button state

        #region Function keys
        #region int GLUT_KEY_F1
        /// <summary>
        ///     F1 function key.
        /// </summary>
        // #define GLUT_KEY_F1 1
        public const int GLUT_KEY_F1 = 1;
        #endregion int GLUT_KEY_F1

        #region int GLUT_KEY_F2
        /// <summary>
        ///     F2 function key.
        /// </summary>
        // #define GLUT_KEY_F2 2
        public const int GLUT_KEY_F2 = 2;
        #endregion int GLUT_KEY_F2

        #region int GLUT_KEY_F3
        /// <summary>
        ///     F3 function key.
        /// </summary>
        // #define GLUT_KEY_F3 3
        public const int GLUT_KEY_F3 = 3;
        #endregion int GLUT_KEY_F3

        #region int GLUT_KEY_F4
        /// <summary>
        ///     F4 function key.
        /// </summary>
        // #define GLUT_KEY_F4 4
        public const int GLUT_KEY_F4 = 4;
        #endregion int GLUT_KEY_F4

        #region int GLUT_KEY_F5
        /// <summary>
        ///     F5 function key.
        /// </summary>
        // #define GLUT_KEY_F5 5
        public const int GLUT_KEY_F5 = 5;
        #endregion int GLUT_KEY_F5

        #region int GLUT_KEY_F6
        /// <summary>
        ///     F6 function key.
        /// </summary>
        // #define GLUT_KEY_F6 6
        public const int GLUT_KEY_F6 = 6;
        #endregion int GLUT_KEY_F6

        #region int GLUT_KEY_F7
        /// <summary>
        ///     F7 function key.
        /// </summary>
        // #define GLUT_KEY_F7 7
        public const int GLUT_KEY_F7 = 7;
        #endregion int GLUT_KEY_F7

        #region int GLUT_KEY_F8
        /// <summary>
        ///     F8 function key.
        /// </summary>
        // #define GLUT_KEY_F8 8
        public const int GLUT_KEY_F8 = 8;
        #endregion int GLUT_KEY_F8

        #region int GLUT_KEY_F9
        /// <summary>
        ///     F9 function key.
        /// </summary>
        // #define GLUT_KEY_F9 9
        public const int GLUT_KEY_F9 = 9;
        #endregion int GLUT_KEY_F9

        #region int GLUT_KEY_F10
        /// <summary>
        ///     F10 function key.
        /// </summary>
        // #define GLUT_KEY_F10 10
        public const int GLUT_KEY_F10 = 10;
        #endregion int GLUT_KEY_F10

        #region int GLUT_KEY_F11
        /// <summary>
        ///     F11 function key.
        /// </summary>
        // #define GLUT_KEY_F11 11
        public const int GLUT_KEY_F11 = 11;
        #endregion int GLUT_KEY_F11

        #region int GLUT_KEY_F12
        /// <summary>
        ///     F12 function key.
        /// </summary>
        // #define GLUT_KEY_F12 12
        public const int GLUT_KEY_F12 = 12;
        #endregion int GLUT_KEY_F12
        #endregion Function keys

        #region Directional keys
        #region int GLUT_KEY_LEFT
        /// <summary>
        ///     Left directional key.
        /// </summary>
        // #define GLUT_KEY_LEFT 100
        public const int GLUT_KEY_LEFT = 100;
        #endregion int GLUT_KEY_LEFT

        #region int GLUT_KEY_UP
        /// <summary>
        ///     Up directional key.
        /// </summary>
        // #define GLUT_KEY_UP 101
        public const int GLUT_KEY_UP = 101;
        #endregion int GLUT_KEY_UP

        #region int GLUT_KEY_RIGHT
        /// <summary>
        ///     Right directional key.
        /// </summary>
        // #define GLUT_KEY_RIGHT 102
        public const int GLUT_KEY_RIGHT = 102;
        #endregion int GLUT_KEY_RIGHT

        #region int GLUT_KEY_DOWN
        /// <summary>
        ///     Down directional key.
        /// </summary>
        // #define GLUT_KEY_DOWN 103
        public const int GLUT_KEY_DOWN = 103;
        #endregion int GLUT_KEY_DOWN

        #region int GLUT_KEY_PAGE_UP
        /// <summary>
        ///     Page Up directional key.
        /// </summary>
        // #define GLUT_KEY_PAGE_UP 104
        public const int GLUT_KEY_PAGE_UP = 104;
        #endregion int GLUT_KEY_PAGE_UP

        #region int GLUT_KEY_PAGE_DOWN
        /// <summary>
        ///     Page Down directional key.
        /// </summary>
        // #define GLUT_KEY_PAGE_DOWN 105
        public const int GLUT_KEY_PAGE_DOWN = 105;
        #endregion int GLUT_KEY_PAGE_DOWN

        #region int GLUT_KEY_HOME
        /// <summary>
        ///     Home directional key.
        /// </summary>
        // #define GLUT_KEY_HOME 106
        public const int GLUT_KEY_HOME = 106;
        #endregion int GLUT_KEY_HOME

        #region int GLUT_KEY_END
        /// <summary>
        ///     End directional key.
        /// </summary>
        // #define GLUT_KEY_END 107
        public const int GLUT_KEY_END = 107;
        #endregion int GLUT_KEY_END

        #region int GLUT_KEY_INSERT
        /// <summary>
        ///     Insert directional key.
        /// </summary>
        // #define GLUT_KEY_INSERT 108
        public const int GLUT_KEY_INSERT = 108;
        #endregion int GLUT_KEY_INSERT
        #endregion Directional keys

        #region Entry/exit state
        #region int GLUT_LEFT
        /// <summary>
        ///     Mouse pointer has left the window.
        /// </summary>
        // #define GLUT_LEFT 0
        public const int GLUT_LEFT = 0;
        #endregion int GLUT_LEFT

        #region int GLUT_ENTERED
        /// <summary>
        ///     Mouse pointer has entered the window.
        /// </summary>
        // #define GLUT_ENTERED 1
        public const int GLUT_ENTERED = 1;
        #endregion int GLUT_ENTERED
        #endregion Entry/exit state

        #region Menu usage state
        #region int GLUT_MENU_NOT_IN_USE
        /// <summary>
        ///     Pop-up menus are not in use by the user.
        /// </summary>
        // #define GLUT_MENU_NOT_IN_USE 0
        public const int GLUT_MENU_NOT_IN_USE = 0;
        #endregion int GLUT_MENU_NOT_IN_USE

        #region int GLUT_MENU_IN_USE
        /// <summary>
        ///     Pop-up menus are in use by the user.
        /// </summary>
        // #define GLUT_MENU_IN_USE 1
        public const int GLUT_MENU_IN_USE = 1;
        #endregion int GLUT_MENU_IN_USE
        #endregion Menu usage state

        #region Visibility state
        #region int GLUT_NOT_VISIBLE
        /// <summary>
        ///     The window is not visible.  No part of the window is visible.  All further
        ///     rendering to the window is discarded until the window's visibility changes.
        /// </summary>
        // #define GLUT_NOT_VISIBLE 0
        public const int GLUT_NOT_VISIBLE = 0;
        #endregion int GLUT_NOT_VISIBLE

        #region int GLUT_VISIBLE
        /// <summary>
        ///     The window is visible.  Does not distinguish a window being totally versus
        ///     partially visible.
        /// </summary>
        // #define GLUT_VISIBLE 1
        public const int GLUT_VISIBLE = 1;
        #endregion int GLUT_VISIBLE
        #endregion Visibility state

        #region Window status state
        #region int GLUT_HIDDEN
        /// <summary>
        ///     The window is not shown or iconified.
        /// </summary>
        // #define GLUT_HIDDEN 0
        public const int GLUT_HIDDEN = 0;
        #endregion int GLUT_HIDDEN

        #region int GLUT_FULLY_RETAINED
        /// <summary>
        ///     No pixels belonging to the window are covered by other windows.
        /// </summary>
        // #define GLUT_FULLY_RETAINED 1
        public const int GLUT_FULLY_RETAINED = 1;
        #endregion int GLUT_FULLY_RETAINED

        #region int GLUT_PARTIALLY_RETAINED
        /// <summary>
        ///     Some but not all pixels belonging to the window are covered by other windows.
        /// </summary>
        // #define GLUT_PARTIALLY_RETAINED 2
        public const int GLUT_PARTIALLY_RETAINED = 2;
        #endregion int GLUT_PARTIALLY_RETAINED

        #region int GLUT_FULLY_COVERED
        /// <summary>
        ///     The window is shown but no part of the window is visible.
        /// </summary>
        // #define GLUT_FULLY_COVERED 3
        public const int GLUT_FULLY_COVERED = 3;
        #endregion int GLUT_FULLY_COVERED
        #endregion Window status state

        #region Color index component selection values
        #region int GLUT_RED
        /// <summary>
        ///     Red color component.
        /// </summary>
        // #define GLUT_RED 0
        public const int GLUT_RED = 0;
        #endregion int GLUT_RED

        #region int GLUT_GREEN
        /// <summary>
        ///     Green color component.
        /// </summary>
        // #define GLUT_GREEN 1
        public const int GLUT_GREEN = 1;
        #endregion int GLUT_GREEN

        #region int GLUT_BLUE
        /// <summary>
        ///     Blue color component.
        /// </summary>
        // #define GLUT_BLUE 2
        public const int GLUT_BLUE = 2;
        #endregion int GLUT_BLUE
        #endregion Color index component selection values

        #region glutGet parameters
        #region int GLUT_WINDOW_X
        /// <summary>
        ///     X location in pixels (relative to the screen origin) of the current window.
        /// </summary>
        // #define GLUT_WINDOW_X ((GLenum) 100)
        public const int GLUT_WINDOW_X = 100;
        #endregion int GLUT_WINDOW_X

        #region int GLUT_WINDOW_Y
        /// <summary>
        ///     Y location in pixels (relative to the screen origin) of the current window.
        /// </summary>
        // #define GLUT_WINDOW_Y ((GLenum) 101)
        public const int GLUT_WINDOW_Y = 101;
        #endregion int GLUT_WINDOW_Y

        #region int GLUT_WINDOW_WIDTH
        /// <summary>
        ///     Width in pixels of the current window.
        /// </summary>
        // #define GLUT_WINDOW_WIDTH ((GLenum) 102)
        public const int GLUT_WINDOW_WIDTH = 102;
        #endregion int GLUT_WINDOW_WIDTH

        #region int GLUT_WINDOW_HEIGHT
        /// <summary>
        ///     Height in pixels of the current window.
        /// </summary>
        // #define GLUT_WINDOW_HEIGHT ((GLenum) 103)
        public const int GLUT_WINDOW_HEIGHT = 103;
        #endregion int GLUT_WINDOW_HEIGHT

        #region int GLUT_WINDOW_BUFFER_SIZE
        /// <summary>
        ///     Total number of bits for current window's color buffer.  For an RGBA window,
        ///     this is the sum of <see cref="GLUT_WINDOW_RED_SIZE" />,
        ///     <see cref="GLUT_WINDOW_GREEN_SIZE" />, <see cref="GLUT_WINDOW_BLUE_SIZE" />,
        ///     and <see cref="GLUT_WINDOW_ALPHA_SIZE" />.  For color index windows, this is
        ///     the size of the color indexes.
        /// </summary>
        // #define GLUT_WINDOW_BUFFER_SIZE ((GLenum) 104)
        public const int GLUT_WINDOW_BUFFER_SIZE = 104;
        #endregion int GLUT_WINDOW_BUFFER_SIZE

        #region int GLUT_WINDOW_STENCIL_SIZE
        /// <summary>
        ///     Number of bits in the current window's stencil buffer.
        /// </summary>
        // #define GLUT_WINDOW_STENCIL_SIZE ((GLenum) 105)
        public const int GLUT_WINDOW_STENCIL_SIZE = 105;
        #endregion int GLUT_WINDOW_STENCIL_SIZE

        #region int GLUT_WINDOW_DEPTH_SIZE
        /// <summary>
        ///     Number of bits in the current window's depth buffer.
        /// </summary>
        // #define GLUT_WINDOW_DEPTH_SIZE ((GLenum) 106)
        public const int GLUT_WINDOW_DEPTH_SIZE = 106;
        #endregion int GLUT_WINDOW_DEPTH_SIZE

        #region int GLUT_WINDOW_RED_SIZE
        /// <summary>
        ///     Number of bits of red stored the current window's color buffer.  Zero if the
        ///     window is color index.
        /// </summary>
        // #define GLUT_WINDOW_RED_SIZE ((GLenum) 107)
        public const int GLUT_WINDOW_RED_SIZE = 107;
        #endregion int GLUT_WINDOW_RED_SIZE

        #region int GLUT_WINDOW_GREEN_SIZE
        /// <summary>
        ///     Number of bits of green stored the current window's color buffer.  Zero if the
        ///     window is color index.
        /// </summary>
        // #define GLUT_WINDOW_GREEN_SIZE ((GLenum) 108)
        public const int GLUT_WINDOW_GREEN_SIZE = 108;
        #endregion int GLUT_WINDOW_GREEN_SIZE

        #region int GLUT_WINDOW_BLUE_SIZE
        /// <summary>
        ///     Number of bits of blue stored the current window's color buffer.  Zero if the
        ///     window is color index.
        /// </summary>
        // #define GLUT_WINDOW_BLUE_SIZE ((GLenum) 109)
        public const int GLUT_WINDOW_BLUE_SIZE = 109;
        #endregion int GLUT_WINDOW_BLUE_SIZE

        #region int GLUT_WINDOW_ALPHA_SIZE
        /// <summary>
        ///     Number of bits of alpha stored the current window's color buffer.  Zero if the
        ///     window is color index.
        /// </summary>
        // #define GLUT_WINDOW_ALPHA_SIZE ((GLenum) 110)
        public const int GLUT_WINDOW_ALPHA_SIZE = 110;
        #endregion int GLUT_WINDOW_ALPHA_SIZE

        #region int GLUT_WINDOW_ACCUM_RED_SIZE
        /// <summary>
        ///     Number of bits of red stored in the current window's accumulation buffer.
        ///     Zero if the window is color index.
        /// </summary>
        // #define GLUT_WINDOW_ACCUM_RED_SIZE ((GLenum) 111)
        public const int GLUT_WINDOW_ACCUM_RED_SIZE = 111;
        #endregion int GLUT_WINDOW_ACCUM_RED_SIZE

        #region int GLUT_WINDOW_ACCUM_GREEN_SIZE
        /// <summary>
        ///     Number of bits of green stored in the current window's accumulation buffer.
        ///     Zero if the window is color index.
        /// </summary>
        // #define GLUT_WINDOW_ACCUM_GREEN_SIZE ((GLenum) 112)
        public const int GLUT_WINDOW_ACCUM_GREEN_SIZE = 112;
        #endregion int GLUT_WINDOW_ACCUM_GREEN_SIZE

        #region int GLUT_WINDOW_ACCUM_BLUE_SIZE
        /// <summary>
        ///     Number of bits of blue stored in the current window's accumulation buffer.
        ///     Zero if the window is color index.
        /// </summary>
        // #define GLUT_WINDOW_ACCUM_BLUE_SIZE ((GLenum) 113)
        public const int GLUT_WINDOW_ACCUM_BLUE_SIZE = 113;
        #endregion int GLUT_WINDOW_ACCUM_BLUE_SIZE

        #region int GLUT_WINDOW_ACCUM_ALPHA_SIZE
        /// <summary>
        ///     Number of bits of alpha stored in the current window's accumulation buffer.
        ///     Zero if the window is color index.
        /// </summary>
        // #define GLUT_WINDOW_ACCUM_ALPHA_SIZE ((GLenum) 114)
        public const int GLUT_WINDOW_ACCUM_ALPHA_SIZE = 114;
        #endregion int GLUT_WINDOW_ACCUM_ALPHA_SIZE

        #region int GLUT_WINDOW_DOUBLEBUFFER
        /// <summary>
        ///     One if the current window is double buffered, zero otherwise.
        /// </summary>
        // #define GLUT_WINDOW_DOUBLEBUFFER ((GLenum) 115)
        public const int GLUT_WINDOW_DOUBLEBUFFER = 115;
        #endregion int GLUT_WINDOW_DOUBLEBUFFER

        #region int GLUT_WINDOW_RGBA
        /// <summary>
        ///     One if the current window is RGBA mode, zero otherwise (i.e., color index).
        /// </summary>
        // #define GLUT_WINDOW_RGBA ((GLenum) 116)
        public const int GLUT_WINDOW_RGBA = 116;
        #endregion int GLUT_WINDOW_RGBA

        #region int GLUT_WINDOW_PARENT
        /// <summary>
        ///     The window number of the current window's parent; zero if the window is a
        ///     top-level window.
        /// </summary>
        // #define GLUT_WINDOW_PARENT ((GLenum) 117)
        public const int GLUT_WINDOW_PARENT = 117;
        #endregion int GLUT_WINDOW_PARENT

        #region int GLUT_WINDOW_NUM_CHILDREN
        /// <summary>
        ///     The number of subwindows the current window has (not counting children of
        ///     children).
        /// </summary>
        // #define GLUT_WINDOW_NUM_CHILDREN ((GLenum) 118)
        public const int GLUT_WINDOW_NUM_CHILDREN = 118;
        #endregion int GLUT_WINDOW_NUM_CHILDREN

        #region int GLUT_WINDOW_COLORMAP_SIZE
        /// <summary>
        ///     Size of current window's color index colormap; zero for RGBA color model
        ///     windows.
        /// </summary>
        // #define GLUT_WINDOW_COLORMAP_SIZE ((GLenum) 119)
        public const int GLUT_WINDOW_COLORMAP_SIZE = 119;
        #endregion int GLUT_WINDOW_COLORMAP_SIZE

        #region int GLUT_WINDOW_NUM_SAMPLES
        /// <summary>
        ///     Number of samples for multisampling for the current window.
        /// </summary>
        // #define GLUT_WINDOW_NUM_SAMPLES ((GLenum) 120)
        public const int GLUT_WINDOW_NUM_SAMPLES = 120;
        #endregion int GLUT_WINDOW_NUM_SAMPLES

        #region int GLUT_WINDOW_STEREO
        /// <summary>
        ///     One if the current window is stereo, zero otherwise.
        /// </summary>
        // #define GLUT_WINDOW_STEREO ((GLenum) 121)
        public const int GLUT_WINDOW_STEREO = 121;
        #endregion int GLUT_WINDOW_STEREO

        #region int GLUT_WINDOW_CURSOR
        /// <summary>
        ///     Current cursor for the current window.
        /// </summary>
        // #define GLUT_WINDOW_CURSOR ((GLenum) 122)
        public const int GLUT_WINDOW_CURSOR = 122;
        #endregion int GLUT_WINDOW_CURSOR

        #region int GLUT_SCREEN_WIDTH
        /// <summary>
        ///     Width of the screen in pixels.  Zero indicates the width is unknown or not
        ///     available.
        /// </summary>
        // #define GLUT_SCREEN_WIDTH ((GLenum) 200)
        public const int GLUT_SCREEN_WIDTH = 200;
        #endregion int GLUT_SCREEN_WIDTH

        #region int GLUT_SCREEN_HEIGHT
        /// <summary>
        ///     Height of the screen in pixels.  Zero indicates the height is unknown or not
        ///     available.
        /// </summary>
        // #define GLUT_SCREEN_HEIGHT ((GLenum) 201)
        public const int GLUT_SCREEN_HEIGHT = 201;
        #endregion int GLUT_SCREEN_HEIGHT

        #region int GLUT_SCREEN_WIDTH_MM
        /// <summary>
        ///     Width of the screen in millimeters.  Zero indicates the width is unknown or
        ///     not available.
        /// </summary>
        // #define GLUT_SCREEN_WIDTH_MM ((GLenum) 202)
        public const int GLUT_SCREEN_WIDTH_MM = 202;
        #endregion int GLUT_SCREEN_WIDTH_MM

        #region int GLUT_SCREEN_HEIGHT_MM
        /// <summary>
        ///     Height of the screen in millimeters.  Zero indicates the height is unknown or
        ///     not available.
        /// </summary>
        // #define GLUT_SCREEN_HEIGHT_MM ((GLenum) 203)
        public const int GLUT_SCREEN_HEIGHT_MM = 203;
        #endregion int GLUT_SCREEN_HEIGHT_MM

        #region int GLUT_MENU_NUM_ITEMS
        /// <summary>
        ///     Number of menu items in the current menu.
        /// </summary>
        // #define GLUT_MENU_NUM_ITEMS ((GLenum) 300)
        public const int GLUT_MENU_NUM_ITEMS = 300;
        #endregion int GLUT_MENU_NUM_ITEMS

        #region int GLUT_DISPLAY_MODE_POSSIBLE
        /// <summary>
        ///     Whether the current display mode is supported or not.
        /// </summary>
        // #define GLUT_DISPLAY_MODE_POSSIBLE ((GLenum) 400)
        public const int GLUT_DISPLAY_MODE_POSSIBLE = 400;
        #endregion int GLUT_DISPLAY_MODE_POSSIBLE

        #region int GLUT_INIT_WINDOW_X
        /// <summary>
        ///     The X value of the initial window position.
        /// </summary>
        // #define GLUT_INIT_WINDOW_X ((GLenum) 500)
        public const int GLUT_INIT_WINDOW_X = 500;
        #endregion int GLUT_INIT_WINDOW_X

        #region int GLUT_INIT_WINDOW_Y
        /// <summary>
        ///     The Y value of the initial window position.
        /// </summary>
        // #define GLUT_INIT_WINDOW_Y ((GLenum) 501)
        public const int GLUT_INIT_WINDOW_Y = 501;
        #endregion int GLUT_INIT_WINDOW_Y

        #region int GLUT_INIT_WINDOW_WIDTH
        /// <summary>
        ///     The width value of the initial window size.
        /// </summary>
        // #define GLUT_INIT_WINDOW_WIDTH ((GLenum) 502)
        public const int GLUT_INIT_WINDOW_WIDTH = 502;
        #endregion int GLUT_INIT_WINDOW_WIDTH

        #region int GLUT_INIT_WINDOW_HEIGHT
        /// <summary>
        ///     The height value of the initial window size.
        /// </summary>
        // #define GLUT_INIT_WINDOW_HEIGHT ((GLenum) 503)
        public const int GLUT_INIT_WINDOW_HEIGHT = 503;
        #endregion int GLUT_INIT_WINDOW_HEIGHT

        #region int GLUT_INIT_DISPLAY_MODE
        /// <summary>
        ///     The initial display mode bit mask.
        /// </summary>
        // #define GLUT_INIT_DISPLAY_MODE ((GLenum) 504)
        public const int GLUT_INIT_DISPLAY_MODE = 504;
        #endregion int GLUT_INIT_DISPLAY_MODE

        #region int GLUT_ELAPSED_TIME
        /// <summary>
        ///     Number of milliseconds since <see cref="glutInit()" /> called (or first call to
        ///     <c>glutGet(GLUT_ELAPSED_TIME)</c>).
        /// </summary>
        // #define GLUT_ELAPSED_TIME ((GLenum) 700)
        public const int GLUT_ELAPSED_TIME = 700;
        #endregion int GLUT_ELAPSED_TIME

        #region int GLUT_WINDOW_FORMAT_ID
        /// <summary>
        ///     The window system dependent format ID for the current layer of the current
        ///     window.  On X11 GLUT implementations, this is the X visual ID.  On Win32 GLUT
        ///     implementations, this is the Win32 Pixel Format Descriptor number.  This value
        ///     is returned for debugging, benchmarking, and testing ease.
        /// </summary>
        // #define GLUT_WINDOW_FORMAT_ID ((GLenum) 123)
        public const int GLUT_WINDOW_FORMAT_ID = 123;
        #endregion int GLUT_WINDOW_FORMAT_ID

        #region int GLUT_INIT_STATE
        /// <summary>
        ///     Unknown.
        /// </summary>
        public const int GLUT_INIT_STATE = 124;
        #endregion int GLUT_INIT_STATE
        #endregion glutGet parameters

        #region glutDeviceGet parameters
        #region int GLUT_HAS_KEYBOARD
        /// <summary>
        ///     Non-zero if a keyboard is available; zero if not available.  For most GLUT
        ///     implementations, a keyboard can be assumed.
        /// </summary>
        // #define GLUT_HAS_KEYBOARD ((GLenum) 600)
        public const int GLUT_HAS_KEYBOARD = 600;
        #endregion int GLUT_HAS_KEYBOARD

        #region int GLUT_HAS_MOUSE
        /// <summary>
        ///     Non-zero if a mouse is available; zero if not available.  For most GLUT
        ///     implementations, a keyboard can be assumed.
        /// </summary>
        // #define GLUT_HAS_MOUSE ((GLenum) 601)
        public const int GLUT_HAS_MOUSE = 601;
        #endregion int GLUT_HAS_MOUSE

        #region int GLUT_HAS_SPACEBALL
        /// <summary>
        ///     Non-zero if a Spaceball is available; zero if not available.
        /// </summary>
        // #define GLUT_HAS_SPACEBALL ((GLenum) 602)
        public const int GLUT_HAS_SPACEBALL = 602;
        #endregion int GLUT_HAS_SPACEBALL

        #region int GLUT_HAS_DIAL_AND_BUTTON_BOX
        /// <summary>
        ///     Non-zero if a dial and button box is available; zero if not available.
        /// </summary>
        // #define GLUT_HAS_DIAL_AND_BUTTON_BOX ((GLenum) 603)
        public const int GLUT_HAS_DIAL_AND_BUTTON_BOX = 603;
        #endregion int GLUT_HAS_DIAL_AND_BUTTON_BOX

        #region int GLUT_HAS_TABLET
        /// <summary>
        ///     Non-zero if a tablet is available; zero if not available.
        /// </summary>
        // #define GLUT_HAS_TABLET ((GLenum) 604)
        public const int GLUT_HAS_TABLET = 604;
        #endregion int GLUT_HAS_TABLET

        #region int GLUT_NUM_MOUSE_BUTTONS
        /// <summary>
        ///     Number of buttons supported by the mouse.  If no mouse is supported, zero is
        ///     returned.
        /// </summary>
        // #define GLUT_NUM_MOUSE_BUTTONS ((GLenum) 605)
        public const int GLUT_NUM_MOUSE_BUTTONS = 605;
        #endregion int GLUT_NUM_MOUSE_BUTTONS

        #region int GLUT_NUM_SPACEBALL_BUTTONS
        /// <summary>
        ///     Number of buttons supported by the Spaceball.  If no Spaceball is
        ///     supported, zero is returned.
        /// </summary>
        // #define GLUT_NUM_SPACEBALL_BUTTONS ((GLenum) 606)
        public const int GLUT_NUM_SPACEBALL_BUTTONS = 606;
        #endregion int GLUT_NUM_SPACEBALL_BUTTONS

        #region int GLUT_NUM_BUTTON_BOX_BUTTONS
        /// <summary>
        ///     Number of buttons supported by the dial and button box device.  If no dials
        ///     and button box device is supported, zero is returned.
        /// </summary>
        // #define GLUT_NUM_BUTTON_BOX_BUTTONS ((GLenum) 607)
        public const int GLUT_NUM_BUTTON_BOX_BUTTONS = 607;
        #endregion int GLUT_NUM_BUTTON_BOX_BUTTONS

        #region int GLUT_NUM_DIALS
        /// <summary>
        ///     Number of dials supported by the dial and button box device.  If no dials and
        ///     button box device is supported, zero is returned.
        /// </summary>
        // #define GLUT_NUM_DIALS ((GLenum) 608)
        public const int GLUT_NUM_DIALS = 608;
        #endregion int GLUT_NUM_DIALS

        #region int GLUT_NUM_TABLET_BUTTONS
        /// <summary>
        ///     Number of buttons supported by the tablet.  If no tablet is supported, zero is
        ///     returned.
        /// </summary>
        // #define GLUT_NUM_TABLET_BUTTONS ((GLenum) 609)
        public const int GLUT_NUM_TABLET_BUTTONS = 609;
        #endregion int GLUT_NUM_TABLET_BUTTONS

        #region int GLUT_DEVICE_IGNORE_KEY_REPEAT
        /// <summary>
        ///     Returns true if the current window's auto repeated keys are ignored.  This
        ///     state is controlled by <see cref="glutIgnoreKeyRepeat" />.
        /// </summary>
        // #define GLUT_DEVICE_IGNORE_KEY_REPEAT ((GLenum) 610)
        public const int GLUT_DEVICE_IGNORE_KEY_REPEAT = 610;
        #endregion int GLUT_DEVICE_IGNORE_KEY_REPEAT

        #region int GLUT_DEVICE_KEY_REPEAT
        /// <summary>
        ///     The window system's global key repeat state.  Returns either
        ///     <see cref="GLUT_KEY_REPEAT_OFF" />, <see cref="GLUT_KEY_REPEAT_ON" />, or
        ///     <see cref="GLUT_KEY_REPEAT_DEFAULT" />.  This will not necessarily return the
        ///     value last passed to <see cref="glutSetKeyRepeat" />.
        /// </summary>
        // #define GLUT_DEVICE_KEY_REPEAT ((GLenum) 611)
        public const int GLUT_DEVICE_KEY_REPEAT = 611;
        #endregion int GLUT_DEVICE_KEY_REPEAT

        #region int GLUT_HAS_JOYSTICK
        /// <summary>
        ///     Non-zero if a joystick is available; zero if not available.
        /// </summary>
        // #define GLUT_HAS_JOYSTICK ((GLenum) 612)
        public const int GLUT_HAS_JOYSTICK = 612;
        #endregion int GLUT_HAS_JOYSTICK

        #region int GLUT_OWNS_JOYSTICK
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        /// <remarks>
        ///     Unofficially, this doesn't appear to be implemented.
        /// </remarks>
        // #define GLUT_OWNS_JOYSTICK ((GLenum) 613)
        public const int GLUT_OWNS_JOYSTICK = 613;
        #endregion int GLUT_OWNS_JOYSTICK

        #region int GLUT_JOYSTICK_BUTTONS
        /// <summary>
        ///     Number of buttons supported by the joystick.  If no joystick is supported,
        ///     zero is returned.
        /// </summary>
        // #define GLUT_JOYSTICK_BUTTONS ((GLenum) 614)
        public const int GLUT_JOYSTICK_BUTTONS = 614;
        #endregion int GLUT_JOYSTICK_BUTTONS

        #region int GLUT_JOYSTICK_AXES
        /// <summary>
        ///     Number of axes supported by the joystick.  If no joystick is supposrted, zero
        ///     is returned.
        /// </summary>
        // #define GLUT_JOYSTICK_AXES ((GLenum) 615)
        public const int GLUT_JOYSTICK_AXES = 615;
        #endregion int GLUT_JOYSTICK_AXES

        #region int GLUT_JOYSTICK_POLL_RATE
        /// <summary>
        ///     Returns the current window's joystick poll rate as set by
        ///     <see cref="glutJoystickFunc" />.  If no joystick is supported, the poll rate
        ///     will always be zero.  The joystick poll rate also returns zero if the poll
        ///     rate last specified to <see cref="glutJoystickFunc" /> is negative or a NULL
        ///     callback was registered. 
        /// </summary>
        // #define GLUT_JOYSTICK_POLL_RATE ((GLenum) 616)
        public const int GLUT_JOYSTICK_POLL_RATE = 616;
        #endregion int GLUT_JOYSTICK_POLL_RATE
        #endregion glutDeviceGet parameters

        #region glutLayerGet parameters
        #region int GLUT_OVERLAY_POSSIBLE
        /// <summary>
        ///     Whether an overlay could be established for the current window given the
        ///     current initial display mode.  If false, <see cref="glutEstablishOverlay" />
        ///     will fail with a fatal error if called.
        /// </summary>
        // #define GLUT_OVERLAY_POSSIBLE ((GLenum) 800)
        public const int GLUT_OVERLAY_POSSIBLE = 800;
        #endregion int GLUT_OVERLAY_POSSIBLE

        #region int GLUT_LAYER_IN_USE
        /// <summary>
        ///     Either <see cref="GLUT_NORMAL" /> or <see cref="GLUT_OVERLAY" /> depending on
        ///     whether the normal plane or overlay is the layer in use.
        /// </summary>
        // #define GLUT_LAYER_IN_USE ((GLenum) 801)
        public const int GLUT_LAYER_IN_USE = 801;
        #endregion int GLUT_LAYER_IN_USE

        #region int GLUT_HAS_OVERLAY
        /// <summary>
        ///     If the current window has an overlay established.
        /// </summary>
        // #define GLUT_HAS_OVERLAY ((GLenum) 802)
        public const int GLUT_HAS_OVERLAY = 802;
        #endregion int GLUT_HAS_OVERLAY

        #region int GLUT_TRANSPARENT_INDEX
        /// <summary>
        ///     The transparent color index of the overlay of the current window; negative
        ///     one is returned if no overlay is in use.
        /// </summary>
        // #define GLUT_TRANSPARENT_INDEX ((GLenum) 803)
        public const int GLUT_TRANSPARENT_INDEX = 803;
        #endregion int GLUT_TRANSPARENT_INDEX

        #region int GLUT_NORMAL_DAMAGED
        /// <summary>
        ///     True if the normal plane of the current window has damaged (by window system
        ///     activity) since the last display callback was triggered.  Calling
        ///     <see cref="glutPostRedisplay" /> will not set this true.
        /// </summary>
        // #define GLUT_NORMAL_DAMAGED ((GLenum) 804)
        public const int GLUT_NORMAL_DAMAGED = 804;
        #endregion int GLUT_NORMAL_DAMAGED

        #region int GLUT_OVERLAY_DAMAGED
        /// <summary>
        ///     True if the overlay plane of the current window has damaged (by window system
        ///     activity) since the last display callback was triggered.  Calling
        ///     <see cref="glutPostRedisplay" /> or <see cref="glutPostOverlayRedisplay" />
        ///     will not set this true.  Negative one is returned if no overlay is in use.
        /// </summary>
        // #define GLUT_OVERLAY_DAMAGED ((GLenum) 805)
        public const int GLUT_OVERLAY_DAMAGED = 805;
        #endregion int GLUT_OVERLAY_DAMAGED
        #endregion #region glutLayerGet parameters

        #region glutVideoResizeGet parameters
        #region int GLUT_VIDEO_RESIZE_POSSIBLE
        /// <summary>
        ///     Non-zero if video resizing is supported by the underlying system; zero if not
        ///     supported.  If this is zero, the other video resize GLUT calls do nothing when
        ///     called.
        /// </summary>
        // #define GLUT_VIDEO_RESIZE_POSSIBLE ((GLenum) 900)
        public const int GLUT_VIDEO_RESIZE_POSSIBLE = 900;
        #endregion int GLUT_VIDEO_RESIZE_POSSIBLE

        #region int GLUT_VIDEO_RESIZE_IN_USE
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        // #define GLUT_VIDEO_RESIZE_IN_USE ((GLenum) 901)
        public const int GLUT_VIDEO_RESIZE_IN_USE = 901;
        #endregion int GLUT_VIDEO_RESIZE_IN_USE

        #region int GLUT_VIDEO_RESIZE_X_DELTA
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        // #define GLUT_VIDEO_RESIZE_X_DELTA ((GLenum) 902)
        public const int GLUT_VIDEO_RESIZE_X_DELTA = 902;
        #endregion int GLUT_VIDEO_RESIZE_X_DELTA

        #region int GLUT_VIDEO_RESIZE_Y_DELTA
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        // #define GLUT_VIDEO_RESIZE_Y_DELTA ((GLenum) 903)
        public const int GLUT_VIDEO_RESIZE_Y_DELTA = 903;
        #endregion int GLUT_VIDEO_RESIZE_Y_DELTA

        #region int GLUT_VIDEO_RESIZE_WIDTH_DELTA
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        // #define GLUT_VIDEO_RESIZE_WIDTH_DELTA ((GLenum) 904)
        public const int GLUT_VIDEO_RESIZE_WIDTH_DELTA = 904;
        #endregion int GLUT_VIDEO_RESIZE_WIDTH_DELTA

        #region int GLUT_VIDEO_RESIZE_HEIGHT_DELTA
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        // #define GLUT_VIDEO_RESIZE_HEIGHT_DELTA ((GLenum) 905)
        public const int GLUT_VIDEO_RESIZE_HEIGHT_DELTA = 905;
        #endregion int GLUT_VIDEO_RESIZE_HEIGHT_DELTA

        #region int GLUT_VIDEO_RESIZE_X
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        // #define GLUT_VIDEO_RESIZE_X ((GLenum) 906)
        public const int GLUT_VIDEO_RESIZE_X = 906;
        #endregion int GLUT_VIDEO_RESIZE_X

        #region int GLUT_VIDEO_RESIZE_Y
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        // #define GLUT_VIDEO_RESIZE_Y ((GLenum) 907)
        public const int GLUT_VIDEO_RESIZE_Y = 907;
        #endregion int GLUT_VIDEO_RESIZE_Y

        #region int GLUT_VIDEO_RESIZE_WIDTH
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        // #define GLUT_VIDEO_RESIZE_WIDTH ((GLenum) 908)
        public const int GLUT_VIDEO_RESIZE_WIDTH = 908;
        #endregion int GLUT_VIDEO_RESIZE_WIDTH

        #region int GLUT_VIDEO_RESIZE_HEIGHT
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        // #define GLUT_VIDEO_RESIZE_HEIGHT ((GLenum) 909)
        public const int GLUT_VIDEO_RESIZE_HEIGHT = 909;
        #endregion int GLUT_VIDEO_RESIZE_HEIGHT
        #endregion glutVideoResizeGet parameters

        #region glutUseLayer parameters
        #region int GLUT_NORMAL
        /// <summary>
        ///     The normal plane.
        /// </summary>
        // #define GLUT_NORMAL ((GLenum) 0)
        public const int GLUT_NORMAL = 0;
        #endregion int GLUT_NORMAL

        #region int GLUT_OVERLAY
        /// <summary>
        ///     The overlay plane.
        /// </summary>
        // #define GLUT_OVERLAY ((GLenum) 1)
        public const int GLUT_OVERLAY = 1;
        #endregion int GLUT_OVERLAY
        #endregion glutUseLayer parameters

        #region glutGetModifiers return mask
        #region int GLUT_ACTIVE_SHIFT
        /// <summary>
        ///     Set if the Shift modifier or Caps Lock is active.
        /// </summary>
        // #define GLUT_ACTIVE_SHIFT 1
        public const int GLUT_ACTIVE_SHIFT = 1;
        #endregion int GLUT_ACTIVE_SHIFT

        #region int GLUT_ACTIVE_CTRL
        /// <summary>
        ///     Set if the Ctrl modifier is active.
        /// </summary>
        // #define GLUT_ACTIVE_CTRL 2
        public const int GLUT_ACTIVE_CTRL = 2;
        #endregion int GLUT_ACTIVE_CTRL

        #region int GLUT_ACTIVE_ALT
        /// <summary>
        ///     Set if the Alt modifier is active.
        /// </summary>
        // #define GLUT_ACTIVE_ALT 4
        public const int GLUT_ACTIVE_ALT = 4;
        #endregion int GLUT_ACTIVE_ALT
        #endregion glutGetModifiers return mask

        #region glutSetCursor parameters
        #region Basic arrows
        #region int GLUT_CURSOR_RIGHT_ARROW
        /// <summary>
        ///     Arrow pointing up and to the right.
        /// </summary>
        // #define GLUT_CURSOR_RIGHT_ARROW 0
        public const int GLUT_CURSOR_RIGHT_ARROW = 0;
        #endregion int GLUT_CURSOR_RIGHT_ARROW

        #region int GLUT_CURSOR_LEFT_ARROW
        /// <summary>
        ///     Arrow pointing up and to the left.
        /// </summary>
        // #define GLUT_CURSOR_LEFT_ARROW 1
        public const int GLUT_CURSOR_LEFT_ARROW = 1;
        #endregion int GLUT_CURSOR_LEFT_ARROW
        #endregion Basic arrows

        #region Symbolic cursor shapes
        #region int GLUT_CURSOR_INFO
        /// <summary>
        ///     Pointing hand.
        /// </summary>
        // #define GLUT_CURSOR_INFO 2
        public const int GLUT_CURSOR_INFO = 2;
        #endregion int GLUT_CURSOR_INFO

        #region int GLUT_CURSOR_DESTROY
        /// <summary>
        ///     Skull and cross bones.
        /// </summary>
        // #define GLUT_CURSOR_DESTROY 3
        public const int GLUT_CURSOR_DESTROY = 3;
        #endregion int GLUT_CURSOR_DESTROY

        #region int GLUT_CURSOR_HELP
        /// <summary>
        ///     Question mark.
        /// </summary>
        // #define GLUT_CURSOR_HELP 4
        public const int GLUT_CURSOR_HELP = 4;
        #endregion int GLUT_CURSOR_HELP

        #region int GLUT_CURSOR_CYCLE
        /// <summary>
        ///     Arrows rotating in a circle.
        /// </summary>
        // #define GLUT_CURSOR_CYCLE 5
        public const int GLUT_CURSOR_CYCLE = 5;
        #endregion int GLUT_CURSOR_CYCLE

        #region int GLUT_CURSOR_SPRAY
        /// <summary>
        ///     Spray can.
        /// </summary>
        // #define GLUT_CURSOR_SPRAY 6
        public const int GLUT_CURSOR_SPRAY = 6;
        #endregion int GLUT_CURSOR_SPRAY

        #region int GLUT_CURSOR_WAIT
        /// <summary>
        ///     Wrist watch.
        /// </summary>
        // #define GLUT_CURSOR_WAIT 7
        public const int GLUT_CURSOR_WAIT = 7;
        #endregion int GLUT_CURSOR_WAIT

        #region int GLUT_CURSOR_TEXT
        /// <summary>
        ///     Insertion point cursor for text.
        /// </summary>
        // #define GLUT_CURSOR_TEXT 8
        public const int GLUT_CURSOR_TEXT = 8;
        #endregion int GLUT_CURSOR_TEXT

        #region int GLUT_CURSOR_CROSSHAIR
        /// <summary>
        ///     Simple cross-hair.
        /// </summary>
        // #define GLUT_CURSOR_CROSSHAIR 9
        public const int GLUT_CURSOR_CROSSHAIR = 9;
        #endregion int GLUT_CURSOR_CROSSHAIR
        #endregion Symbolic cursor shapes

        #region Directional cursors
        #region int GLUT_CURSOR_UP_DOWN
        /// <summary>
        ///     Bi-directional pointing up and down.
        /// </summary>
        // #define GLUT_CURSOR_UP_DOWN 10
        public const int GLUT_CURSOR_UP_DOWN = 10;
        #endregion int GLUT_CURSOR_UP_DOWN

        #region int GLUT_CURSOR_LEFT_RIGHT
        /// <summary>
        ///     Bi-directional pointing left and right.
        /// </summary>
        // #define GLUT_CURSOR_LEFT_RIGHT 11
        public const int GLUT_CURSOR_LEFT_RIGHT = 11;
        #endregion int GLUT_CURSOR_LEFT_RIGHT
        #endregion Directional cursors

        #region Sizing cursors
        #region int GLUT_CURSOR_TOP_SIDE
        /// <summary>
        ///     Arrow pointing to top side.
        /// </summary>
        // #define GLUT_CURSOR_TOP_SIDE 12
        public const int GLUT_CURSOR_TOP_SIDE = 12;
        #endregion int GLUT_CURSOR_TOP_SIDE

        #region int GLUT_CURSOR_BOTTOM_SIDE
        /// <summary>
        ///     Arrow pointing to bottom side.
        /// </summary>
        // #define GLUT_CURSOR_BOTTOM_SIDE 13
        public const int GLUT_CURSOR_BOTTOM_SIDE = 13;
        #endregion int GLUT_CURSOR_BOTTOM_SIDE

        #region int GLUT_CURSOR_LEFT_SIDE
        /// <summary>
        ///     Arrow pointing to left side.
        /// </summary>
        // #define GLUT_CURSOR_LEFT_SIDE 14
        public const int GLUT_CURSOR_LEFT_SIDE = 14;
        #endregion int GLUT_CURSOR_LEFT_SIDE

        #region int GLUT_CURSOR_RIGHT_SIDE
        /// <summary>
        ///     Arrow pointing to right side.
        /// </summary>
        // #define GLUT_CURSOR_RIGHT_SIDE 15
        public const int GLUT_CURSOR_RIGHT_SIDE = 15;
        #endregion int GLUT_CURSOR_RIGHT_SIDE

        #region int GLUT_CURSOR_TOP_LEFT_CORNER
        /// <summary>
        ///     Arrow pointing to top-left corner.
        /// </summary>
        // #define GLUT_CURSOR_TOP_LEFT_CORNER 16
        public const int GLUT_CURSOR_TOP_LEFT_CORNER = 16;
        #endregion int GLUT_CURSOR_TOP_LEFT_CORNER

        #region int GLUT_CURSOR_TOP_RIGHT_CORNER
        /// <summary>
        ///     Arrow pointing to top-right corner.
        /// </summary>
        // #define GLUT_CURSOR_TOP_RIGHT_CORNER 17
        public const int GLUT_CURSOR_TOP_RIGHT_CORNER = 17;
        #endregion int GLUT_CURSOR_TOP_RIGHT_CORNER

        #region int GLUT_CURSOR_BOTTOM_RIGHT_CORNER
        /// <summary>
        ///     Arrow pointing to bottom-right corner.
        /// </summary>
        // #define GLUT_CURSOR_BOTTOM_RIGHT_CORNER 18
        public const int GLUT_CURSOR_BOTTOM_RIGHT_CORNER = 18;
        #endregion int GLUT_CURSOR_BOTTOM_RIGHT_CORNER

        #region int GLUT_CURSOR_BOTTOM_LEFT_CORNER
        /// <summary>
        ///     Arrow pointing to bottom-left corner.
        /// </summary>
        // #define GLUT_CURSOR_BOTTOM_LEFT_CORNER 19
        public const int GLUT_CURSOR_BOTTOM_LEFT_CORNER = 19;
        #endregion int GLUT_CURSOR_BOTTOM_LEFT_CORNER
        #endregion Sizing cursors

        #region Inherit from parent window
        #region int GLUT_CURSOR_INHERIT
        /// <summary>
        ///     Use parent's cursor.
        /// </summary>
        // #define GLUT_CURSOR_INHERIT 100
        public const int GLUT_CURSOR_INHERIT = 100;
        #endregion int GLUT_CURSOR_INHERIT
        #endregion Inherit from parent window

        #region Blank cursor
        #region int GLUT_CURSOR_NONE
        /// <summary>
        ///     Invisible cursor.
        /// </summary>
        // #define GLUT_CURSOR_NONE 101
        public const int GLUT_CURSOR_NONE = 101;
        #endregion int GLUT_CURSOR_NONE
        #endregion Blank cursor

        #region Fullscreen crosshair (if available)
        #region int GLUT_CURSOR_FULL_CROSSHAIR
        /// <summary>
        ///     Full-screen cross-hair cursor (if possible, otherwise
        ///     <see cref="GLUT_CURSOR_CROSSHAIR" />.
        /// </summary>
        // #define GLUT_CURSOR_FULL_CROSSHAIR 102
        public const int GLUT_CURSOR_FULL_CROSSHAIR = 102;
        #endregion int GLUT_CURSOR_FULL_CROSSHAIR
        #endregion Fullscreen crosshair (if available)
        #endregion glutSetCursor parameters

        #region glutSetKeyRepeat modes
        #region int GLUT_KEY_REPEAT_OFF
        /// <summary>
        ///     Disable key repeat for the window system on a global basis.
        /// </summary>
        // #define GLUT_KEY_REPEAT_OFF 0
        public const int GLUT_KEY_REPEAT_OFF = 0;
        #endregion int GLUT_KEY_REPEAT_OFF

        #region int GLUT_KEY_REPEAT_ON
        /// <summary>
        ///     Enable key repeat for the window system on a global basis.
        /// </summary>
        // #define GLUT_KEY_REPEAT_ON 1
        public const int GLUT_KEY_REPEAT_ON = 1;
        #endregion int GLUT_KEY_REPEAT_ON

        #region int GLUT_KEY_REPEAT_DEFAULT
        /// <summary>
        ///     Reset the key repeat mode for the window system to its default state.
        /// </summary>
        // #define GLUT_KEY_REPEAT_DEFAULT 2
        public const int GLUT_KEY_REPEAT_DEFAULT = 2;
        #endregion int GLUT_KEY_REPEAT_DEFAULT
        #endregion glutSetKeyRepeat modes

        #region Joystick button masks
        #region int GLUT_JOYSTICK_BUTTON_A
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        // #define GLUT_JOYSTICK_BUTTON_A 1
        public const int GLUT_JOYSTICK_BUTTON_A = 1;
        #endregion int GLUT_JOYSTICK_BUTTON_A

        #region int GLUT_JOYSTICK_BUTTON_B
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        // #define GLUT_JOYSTICK_BUTTON_B 2
        public const int GLUT_JOYSTICK_BUTTON_B = 2;
        #endregion int GLUT_JOYSTICK_BUTTON_B

        #region int GLUT_JOYSTICK_BUTTON_C
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        // #define GLUT_JOYSTICK_BUTTON_C 4
        public const int GLUT_JOYSTICK_BUTTON_C = 4;
        #endregion int GLUT_JOYSTICK_BUTTON_C

        #region int GLUT_JOYSTICK_BUTTON_D
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this constant.
        /// </summary>
        // #define GLUT_JOYSTICK_BUTTON_D 8
        public const int GLUT_JOYSTICK_BUTTON_D = 8;
        #endregion int GLUT_JOYSTICK_BUTTON_D
        #endregion Joystick button masks

        #region glutGameModeGet parameters
        #region int GLUT_GAME_MODE_ACTIVE
        /// <summary>
        ///     Non-zero if GLUT's game mode is active; zero if not active.  Game mode is not
        ///     active initially.  Game mode becomes active when
        ///     <see cref="glutEnterGameMode" /> is called.  Game mode becomes inactive when
        ///     <see cref="glutLeaveGameMode" /> is called.
        /// </summary>
        // #define GLUT_GAME_MODE_ACTIVE ((GLenum) 0)
        public const int GLUT_GAME_MODE_ACTIVE = 0;
        #endregion int GLUT_GAME_MODE_ACTIVE

        #region int GLUT_GAME_MODE_POSSIBLE
        /// <summary>
        ///     Non-zero if the game mode string last specified to
        ///     <see cref="glutGameModeString" /> is a possible game mode configuration; zero
        ///     otherwise.  Being "possible" does not guarantee that if game mode is entered
        ///     with <see cref="glutEnterGameMode" /> that the display settings will actually
        ///     changed.  <see cref="GLUT_GAME_MODE_DISPLAY_CHANGED" /> should be called once
        ///     game mode is entered to determine if the display mode is actually changed.
        /// </summary>
        // #define GLUT_GAME_MODE_POSSIBLE ((GLenum) 1)
        public const int GLUT_GAME_MODE_POSSIBLE = 1;
        #endregion int GLUT_GAME_MODE_POSSIBLE

        #region int GLUT_GAME_MODE_WIDTH
        /// <summary>
        ///     Width in pixels of the screen when game mode is activated.
        /// </summary>
        // #define GLUT_GAME_MODE_WIDTH ((GLenum) 2)
        public const int GLUT_GAME_MODE_WIDTH = 2;
        #endregion int GLUT_GAME_MODE_WIDTH

        #region int GLUT_GAME_MODE_HEIGHT
        /// <summary>
        ///     Height in pixels of the screen when game mode is activated.
        /// </summary>
        // #define GLUT_GAME_MODE_HEIGHT ((GLenum) 3)
        public const int GLUT_GAME_MODE_HEIGHT = 3;
        #endregion int GLUT_GAME_MODE_HEIGHT

        #region int GLUT_GAME_MODE_PIXEL_DEPTH
        /// <summary>
        ///     Pixel depth of the screen when game mode is activiated.
        /// </summary>
        // #define GLUT_GAME_MODE_PIXEL_DEPTH ((GLenum) 4)
        public const int GLUT_GAME_MODE_PIXEL_DEPTH = 4;
        #endregion int GLUT_GAME_MODE_PIXEL_DEPTH

        #region int GLUT_GAME_MODE_REFRESH_RATE
        /// <summary>
        ///     Screen refresh rate in cyles per second (hertz) when game mode is activated.
        ///     Zero is returned if the refresh rate is unknown or cannot be queried.
        /// </summary>
        // #define GLUT_GAME_MODE_REFRESH_RATE ((GLenum) 5)
        public const int GLUT_GAME_MODE_REFRESH_RATE = 5;
        #endregion int GLUT_GAME_MODE_REFRESH_RATE

        #region int GLUT_GAME_MODE_DISPLAY_CHANGED
        /// <summary>
        ///     Non-zero if entering game mode actually changed the display settings.  If the
        ///     game mode string is not possible or the display mode could not be changed for
        ///     any other reason, zero is returned.
        /// </summary>
        // #define GLUT_GAME_MODE_DISPLAY_CHANGED ((GLenum) 6)
        public const int GLUT_GAME_MODE_DISPLAY_CHANGED = 6;
        #endregion int GLUT_GAME_MODE_DISPLAY_CHANGED
        #endregion glutGameModeGet parameters

        #region FreeGLUT Additions
        #region Window Close Actions
        #region int GLUT_ACTION_EXIT
        /// <summary>
        ///     Close window on window close button click.
        /// </summary>
        public const int GLUT_ACTION_EXIT = 0;
        #endregion int GLUT_ACTION_EXIT

        #region int GLUT_ACTION_GLUTMAINLOOP_RETURNS
        /// <summary>
        ///     Return from main loop on window close button click.
        /// </summary>
        public const int GLUT_ACTION_GLUTMAINLOOP_RETURNS = 1;
        #endregion int GLUT_ACTION_GLUTMAINLOOP_RETURNS

        #region int GLUT_ACTION_CONTINUE_EXECUTION
        /// <summary>
        ///     Continue execution on window close button click.
        /// </summary>
        public const int GLUT_ACTION_CONTINUE_EXECUTION = 2;
        #endregion int GLUT_ACTION_CONTINUE_EXECUTION
        #endregion Window Close Actions

        #region Contexts For New Windows
        #region int GLUT_CREATE_NEW_CONTEXT
        /// <summary>
        ///     Create a new context when user opens a new window.
        /// </summary>
        public const int GLUT_CREATE_NEW_CONTEXT = 0;
        #endregion int GLUT_CREATE_NEW_CONTEXT

        #region int GLUT_USE_CURRENT_CONTEXT
        /// <summary>
        ///     Use current context when user opens a new window.
        /// </summary>
        public const int GLUT_USE_CURRENT_CONTEXT = 1;
        #endregion int GLUT_USE_CURRENT_CONTEXT
        
	#region int GLUT_FORCE_INDIRECT_CONTEXT
        /// <summary>
        ///     Direct/Indirect rendering context options (has meaning only in Unix/X11)
        /// </summary>
	public const int GLUT_FORCE_INDIRECT_CONTEXT = 0;
        #endregion int GLUT_FORCE_INDIRECT_CONTEXT
        
	#region int GLUT_ALLOW_DIRECT_CONTEXT
        /// <summary>
        ///     Direct/Indirect rendering context options (has meaning only in Unix/X11)
        /// </summary>
	public const int GLUT_ALLOW_DIRECT_CONTEXT = 1;
        #endregion int GLUT_ALLOW_DIRECT_CONTEXT
        
	#region int GLUT_TRY_DIRECT_CONTEXT
        /// <summary>
        ///     Direct/Indirect rendering context options (has meaning only in Unix/X11)
        /// </summary>
	public const int GLUT_TRY_DIRECT_CONTEXT = 2;
        #endregion int GLUT_TRY_DIRECT_CONTEXT
        
	#region int GLUT_FORCE_DIRECT_CONTEXT
        /// <summary>
        ///     Direct/Indirect rendering context options (has meaning only in Unix/X11)
        /// </summary>
	public const int GLUT_FORCE_DIRECT_CONTEXT = 3;
        #endregion int GLUT_FORCE_DIRECT_CONTEXT
        #endregion Contexts For New Windows

        #region glutGet Parameters
        #region int GLUT_ACTION_ON_WINDOW_CLOSE
        /// <summary>
        ///     Gets current action for window-close.
        /// </summary>
        public const int GLUT_ACTION_ON_WINDOW_CLOSE = 0x01F9;
        #endregion int GLUT_ACTION_ON_WINDOW_CLOSE

        #region int GLUT_WINDOW_BORDER_WIDTH
        /// <summary>
        ///     Gets the window border width.
        /// </summary>
        public const int GLUT_WINDOW_BORDER_WIDTH = 0x01FA;
        #endregion int GLUT_WINDOW_BORDER_WIDTH

        #region int GLUT_WINDOW_HEADER_HEIGHT
        /// <summary>
        ///     Gets window header height.
        /// </summary>
        public const int GLUT_WINDOW_HEADER_HEIGHT = 0x01FB;
        #endregion int GLUT_WINDOW_HEADER_HEIGHT

        #region int GLUT_VERSION
        /// <summary>
        ///     Gets GLUT version.
        /// </summary>
        public const int GLUT_VERSION = 0x01FC;
        #endregion int GLUT_VERSION

        #region int GLUT_RENDERING_CONTEXT
        /// <summary>
        ///     Gets GLUT's rendering context.
        /// </summary>
        public const int GLUT_RENDERING_CONTEXT = 0x01FD;
        #endregion int GLUT_RENDERING_CONTEXT
	
        #region int GLUT_DIRECT_RENDERING
        /// <summary>
        ///     
        /// </summary>
	public const int GLUT_DIRECT_RENDERING = 0x01FE;
        #endregion int GLUT_DIRECT_RENDERING
/*
 * New tokens for glutInitDisplayMode.
 * Only one GLUT_AUXn bit may be used at a time.
 * Value 0x0400 is defined in OpenGLUT.
 */
	#region int GLUT_AUX1
        /// <summary>
        ///     
        /// </summary>
	public const int GLUT_AUX1 = 0x1000;
        #endregion int GLUT_AUX1

	#region int GLUT_AUX2
        /// <summary>
        ///     
        /// </summary>
	public const int GLUT_AUX2 = 0x2000;
        #endregion int GLUT_AUX2

	#region int GLUT_AUX3
        /// <summary>
        ///     
        /// </summary>
	public const int GLUT_AUX3 = 0x4000;
        #endregion int GLUT_AUX3

	#region int GLUT_AUX4
        /// <summary>
        ///     
        /// </summary>
	public const int GLUT_AUX4 = 0x8000;
        #endregion int GLUT_AUX4
        #endregion glutGet Parameters
        #endregion FreeGLUT Additions
        #endregion Public Constants

        #region Public Static Readonly Fields
        #region Fonts
        #region IntPtr GLUT_STROKE_ROMAN
        /// <summary>
        ///     A proportionally spaced Roman Simplex font for ASCII characters 32 through
        ///     127.  The maximum top character in the font is 119.05 units; the bottom
        ///     descends 33.33 units.
        /// </summary>
        // #define GLUT_STROKE_ROMAN ((void*)0)
        // #define GLUT_STROKE_ROMAN (&glutStrokeRoman)
        public static readonly IntPtr GLUT_STROKE_ROMAN;
        #endregion IntPtr GLUT_STROKE_ROMAN

        #region IntPtr GLUT_STROKE_MONO_ROMAN
        /// <summary>
        ///     A mono-spaced spaced Roman Simplex font (same characters as
        ///     <see cref="GLUT_STROKE_ROMAN" />) for ASCII characters 32 through 127.  The
        ///     maximum top character in the font is 119.05 units; the bottom descends 33.33
        ///     units.  Each character is 104.76 units wide.
        /// </summary>
        // #define GLUT_STROKE_MONO_ROMAN ((void*)1)
        // #define GLUT_STROKE_MONO_ROMAN (&glutStrokeMonoRoman)
        public static readonly IntPtr GLUT_STROKE_MONO_ROMAN;
        #endregion IntPtr GLUT_STROKE_MONO_ROMAN

        #region IntPtr GLUT_BITMAP_9_BY_15
        /// <summary>
        ///     A fixed width font with every character fitting in an 9 by 15 pixel rectangle.
        /// </summary>
        // #define GLUT_BITMAP_9_BY_15 ((void*)2)
        // #define GLUT_BITMAP_9_BY_15 (&glutBitmap9By15)
        public static readonly IntPtr GLUT_BITMAP_9_BY_15;
        #endregion IntPtr GLUT_BITMAP_9_BY_15

        #region IntPtr GLUT_BITMAP_8_BY_13
        /// <summary>
        ///     A fixed width font with every character fitting in an 8 by 13 pixel rectangle.
        /// </summary>
        // #define GLUT_BITMAP_8_BY_13 ((void*)3)
        // #define GLUT_BITMAP_8_BY_13 (&glutBitmap8By13)
        public static readonly IntPtr GLUT_BITMAP_8_BY_13;
        #endregion IntPtr GLUT_BITMAP_8_BY_13

        #region IntPtr GLUT_BITMAP_TIMES_ROMAN_10
        /// <summary>
        ///     A 10-point proportional spaced Times Roman font.
        /// </summary>
        // #define GLUT_BITMAP_TIMES_ROMAN_10 ((void*)4)
        // #define GLUT_BITMAP_TIMES_ROMAN_10 (&glutBitmapTimesRoman10)
        public static readonly IntPtr GLUT_BITMAP_TIMES_ROMAN_10;
        #endregion IntPtr GLUT_BITMAP_TIMES_ROMAN_10

        #region IntPtr GLUT_BITMAP_TIMES_ROMAN_24
        /// <summary>
        ///     A 24-point proportional spaced Times Roman font.
        /// </summary>
        // #define GLUT_BITMAP_TIMES_ROMAN_24 ((void*)5)
        // #define GLUT_BITMAP_TIMES_ROMAN_24 (&glutBitmapTimesRoman24)
        public static readonly IntPtr GLUT_BITMAP_TIMES_ROMAN_24;
        #endregion IntPtr GLUT_BITMAP_TIMES_ROMAN_24

        #region IntPtr GLUT_BITMAP_HELVETICA_10
        /// <summary>
        ///     A 10-point proportional spaced Helvetica font.
        /// </summary>
        // #define GLUT_BITMAP_HELVETICA_10 ((void*)6)
        // #define GLUT_BITMAP_HELVETICA_10 (&glutBitmapHelvetica10)
        public static readonly IntPtr GLUT_BITMAP_HELVETICA_10;
        #endregion IntPtr GLUT_BITMAP_HELVETICA_10

        #region IntPtr GLUT_BITMAP_HELVETICA_12
        /// <summary>
        ///     A 12-point proportional spaced Helvetica font.
        /// </summary>
        // #define GLUT_BITMAP_HELVETICA_12 ((void*)7)
        // #define GLUT_BITMAP_HELVETICA_12 (&glutBitmapHelvetica12)
        public static readonly IntPtr GLUT_BITMAP_HELVETICA_12;
        #endregion IntPtr GLUT_BITMAP_HELVETICA_12

        #region IntPtr GLUT_BITMAP_HELVETICA_18
        /// <summary>
        ///     A 18-point proportional spaced Helvetica font.
        /// </summary>
        // #define GLUT_BITMAP_HELVETICA_18 ((void*)8)
        // #define GLUT_BITMAP_HELVETICA_18 (&glutBitmapHelvetica18)
        public static readonly IntPtr GLUT_BITMAP_HELVETICA_18;
        #endregion IntPtr GLUT_BITMAP_HELVETICA_18
        #endregion Fonts
        #endregion Public Static Readonly Fields

        #region Private Fields
        // These fields hold references to any callbacks used so as to prevent the garbage
        // collector from sweeping the delegates even though the application may not be done
        // with them.
        private static ButtonBoxCallback buttonBoxCallback;
        private static CreateMenuCallback createMenuCallback;
        private static DialsCallback dialsCallback;
        private static DisplayCallback displayCallback;
        private static EntryCallback entryCallback;
        private static IdleCallback idleCallback;
        private static JoystickCallback joystickCallback;
        private static KeyboardCallback keyboardCallback;
        private static KeyboardUpCallback keyboardUpCallback;
        private static MenuStateCallback menuStateCallback;
        private static MenuStatusCallback menuStatusCallback;
        private static MotionCallback motionCallback;
        private static MouseCallback mouseCallback;
        private static OverlayDisplayCallback overlayDisplayCallback;
        private static PassiveMotionCallback passiveMotionCallback;
        private static ReshapeCallback reshapeCallback;
        private static SpaceballButtonCallback spaceballButtonCallback;
        private static SpaceballMotionCallback spaceballMotionCallback;
        private static SpaceballRotateCallback spaceballRotateCallback;
        private static SpecialCallback specialCallback;
        private static SpecialUpCallback specialUpCallback;
        private static TabletButtonCallback tabletButtonCallback;
        private static TabletMotionCallback tabletMotionCallback;
        private static TimerCallback timerCallback;
        private static WindowStatusCallback windowStatusCallback;
        private static VisibilityCallback visibilityCallback;

        // --- FreeGLUT Additions ---
        private static MouseWheelCallback mouseWheelCallback;
        private static CloseCallback closeCallback;
        private static WindowCloseCallback windowCloseCallback;
        private static MenuDestroyCallback menuDestroyCallback;
        #endregion Private Fields

        // --- Constructors & Destructors ---
        #region Static Glut()
        /// <summary>
        ///     Static Glut constructor.
        /// </summary>
        /// <remarks>
        ///     Sets up GLUT font addresses.
        /// </remarks>
        static Glut() {
            // TODO: Look into how to implement the broken font shit on Unix.
            // GLUT fonts on non-Windows platforms is broken, probably need to implement the
            // appropriate byte arrays specifiying the font layout...  Ugh.
            unsafe {
                GLUT_STROKE_ROMAN = new IntPtr((void*) 0);
                GLUT_STROKE_MONO_ROMAN = new IntPtr((void*) 1);
                GLUT_BITMAP_9_BY_15 = new IntPtr((void*) 2);
                GLUT_BITMAP_8_BY_13 = new IntPtr((void*) 3);
                GLUT_BITMAP_TIMES_ROMAN_10 = new IntPtr((void*) 4);
                GLUT_BITMAP_TIMES_ROMAN_24 = new IntPtr((void*) 5);
                GLUT_BITMAP_HELVETICA_10 = new IntPtr((void*) 6);
                GLUT_BITMAP_HELVETICA_12 = new IntPtr((void*) 7);
                GLUT_BITMAP_HELVETICA_18 = new IntPtr((void*) 8);
            }
//            GLUT_STROKE_ROMAN = glutStrokeRoman();
//            GLUT_STROKE_MONO_ROMAN = glutStrokeMonoRoman();
//            GLUT_BITMAP_9_BY_15 = glutBitmap9By15();
//            GLUT_BITMAP_8_BY_13 = glutBitmap8By13();
//            GLUT_BITMAP_TIMES_ROMAN_10 = glutBitmapTimesRoman10();
//            GLUT_BITMAP_TIMES_ROMAN_24 = glutBitmapTimesRoman24();
//            GLUT_BITMAP_HELVETICA_10 = glutBitmapHelvetica10();
//            GLUT_BITMAP_HELVETICA_12 = glutBitmapHelvetica12();
//            GLUT_BITMAP_HELVETICA_18 = glutBitmapHelvetica18();
        }
        #endregion Static Glut()

        // --- Public Delegates ---
        #region Callbacks
        #region ButtonBoxCallback(int button, int state)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutButtonBoxFunc" />.
        /// </summary>
        /// <seealso cref="glutButtonBoxFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ButtonBoxCallback(int button, int state);
        #endregion ButtonBoxCallback(int button, int state)

        #region CreateMenuCallback(int val)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutCreateMenu" />.
        /// </summary>
        /// <seealso cref="glutCreateMenu" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CreateMenuCallback(int val);
        #endregion CreateMenuCallback(int val)

        #region DialsCallback(int dial, int val)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutDialsFunc" />.
        /// </summary>
        /// <seealso cref="glutDialsFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DialsCallback(int dial, int val);
        #endregion DialsCallback(int dial, int val)

        #region DisplayCallback()
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutDisplayFunc" />.
        /// </summary>
        /// <seealso cref="glutDisplayFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DisplayCallback();
        #endregion DisplayCallback()

        #region EntryCallback(int state)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutEntryFunc" />.
        /// </summary>
        /// <seealso cref="glutEntryFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void EntryCallback(int state);
        #endregion EntryCallback(int state)

        #region IdleCallback()
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutIdleFunc" />.
        /// </summary>
        /// <seealso cref="glutIdleFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void IdleCallback();
        #endregion IdleCallback()

        #region JoystickCallback(int buttonMask, int x, int y, int z)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutJoystickFunc" />.
        /// </summary>
        /// <seealso cref="glutJoystickFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void JoystickCallback(int buttonMask, int x, int y, int z);
        #endregion JoystickCallback(int buttonMask, int x, int y, int z)

        #region KeyboardCallback(byte key, int x, int y)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutKeyboardFunc" />.
        /// </summary>
        /// <seealso cref="glutKeyboardFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void KeyboardCallback(byte key, int x, int y);
        #endregion KeyboardCallback(byte key, int x, int y)

        #region KeyboardUpCallback(byte key, int x, int y)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutKeyboardUpFunc" />.
        /// </summary>
        /// <seealso cref="glutKeyboardUpFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void KeyboardUpCallback(byte key, int x, int y);
        #endregion KeyboardUpCallback(byte key, int x, int y)

        #region MenuStateCallback(int state)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutMenuStateFunc" />.
        /// </summary>
        /// <seealso cref="glutMenuStateFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MenuStateCallback(int state);
        #endregion MenuStateCallback(int state)

        #region MenuStatusCallback(int status, int x, int y)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutMenuStatusFunc" />.
        /// </summary>
        /// <seealso cref="glutMenuStatusFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MenuStatusCallback(int status, int x, int y);
        #endregion MenuStatusCallback(int status, int x, int y)

        #region MotionCallback(int x, int y)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutMotionFunc" />.
        /// </summary>
        /// <seealso cref="glutMotionFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MotionCallback(int x, int y);
        #endregion MotionCallback(int x, int y)

        #region MouseCallback(int button, int state, int x, int y)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutMouseFunc" />.
        /// </summary>
        /// <seealso cref="glutMouseFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MouseCallback(int button, int state, int x, int y);
        #endregion MouseCallback(int button, int state, int x, int y)

        #region OverlayDisplayCallback()
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutOverlayDisplayFunc" />.
        /// </summary>
        /// <seealso cref="glutOverlayDisplayFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OverlayDisplayCallback();
        #endregion OverlayDisplayCallback()

        #region PassiveMotionCallback(int x, int y)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutPassiveMotionFunc" />.
        /// </summary>
        /// <seealso cref="glutPassiveMotionFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PassiveMotionCallback(int x, int y);
        #endregion PassiveMotionCallback(int x, int y)

        #region ReshapeCallback(int width, int height)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutReshapeFunc" />.
        /// </summary>
        /// <seealso cref="glutReshapeFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ReshapeCallback(int width, int height);
        #endregion ReshapeCallback(int width, int height)

        #region SpaceballButtonCallback(int button, int state)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutSpaceballButtonFunc" />.
        /// </summary>
        /// <seealso cref="glutSpaceballButtonFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SpaceballButtonCallback(int button, int state);
        #endregion SpaceballButtonCallback(int button, int state)

        #region SpaceballMotionCallback(int x, int y, int z)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutSpaceballMotionFunc" />.
        /// </summary>
        /// <seealso cref="glutSpaceballMotionFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SpaceballMotionCallback(int x, int y, int z);
        #endregion SpaceballMotionCallback(int x, int y, int z)

        #region SpaceballRotateCallback(int x, int y, int z)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutSpaceballRotateFunc" />.
        /// </summary>
        /// <seealso cref="glutSpaceballRotateFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SpaceballRotateCallback(int x, int y, int z);
        #endregion SpaceballRotateCallback(int x, int y, int z)

        #region SpecialCallback(int key, int x, int y)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutSpecialFunc" />.
        /// </summary>
        /// <seealso cref="glutSpecialFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SpecialCallback(int key, int x, int y);
        #endregion SpecialCallback(int key, int x, int y)

        #region SpecialUpCallback(int key, int x, int y)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutSpecialUpFunc" />.
        /// </summary>
        /// <seealso cref="glutSpecialUpFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SpecialUpCallback(int key, int x, int y);
        #endregion SpecialUpCallback(int key, int x, int y)

        #region TabletButtonCallback(int button, int state, int x, int y)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutTabletButtonFunc" />.
        /// </summary>
        /// <seealso cref="glutTabletButtonFunc" />
        public delegate void TabletButtonCallback(int button, int state, int x, int y);
        #endregion TabletButtonCallback(int button, int state, int x, int y)

        #region TabletMotionCallback(int x, int y)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutTabletMotionFunc" />.
        /// </summary>
        /// <seealso cref="glutTabletMotionFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void TabletMotionCallback(int x, int y);
        #endregion TabletMotionCallback(int x, int y)

        #region TimerCallback(int val)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutTimerFunc" />.
        /// </summary>
        /// <seealso cref="glutTimerFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void TimerCallback(int val);
        #endregion TimerCallback(int val)

        #region WindowStatusCallback(int state)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutWindowStatusFunc" />.
        /// </summary>
        /// <seealso cref="glutWindowStatusFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void WindowStatusCallback(int state);
        #endregion WindowStatusCallback(int state)

        #region VisibilityCallback(int state)
        /// <summary>
        ///     Callback (delegate) for use with <see cref="glutVisibilityFunc" />.
        /// </summary>
        /// <seealso cref="glutVisibilityFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void VisibilityCallback(int state);
        #endregion VisibilityCallback(int state)

        // --- FreeGLUT Additions ---
        #region MouseWheelCallback(int wheel, int direction, int x, int y)
        /// <summary>
        ///     Callback (delegate for use with <see cref="glutMouseWheelFunc" />.
        /// </summary>
        /// <param name="wheel">
        ///     Wheel number.
        /// </param>
        /// <param name="direction">
        ///     Direction, +/- 1.
        /// </param>
        /// <param name="x">
        ///     Pointer X coordinate.
        /// </param>
        /// <param name="y">
        ///     Pointer Y coordinate.
        /// </param>
        /// <remarks>
        ///     This may not work reliably on X Windows.
        /// </remarks>
        /// <seealso cref="glutMouseWheelFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MouseWheelCallback(int wheel, int direction, int x, int y);
        #endregion MouseWheelCallback(int wheel, int direction, int x, int y)

        #region CloseCallback()
        /// <summary>
        ///     Callback (delegate for use with <see cref="glutCloseFunc" />.
        /// </summary>
        /// <seealso cref="glutCloseFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CloseCallback();
        #endregion CloseCallback()

        #region WindowCloseCallback()
        /// <summary>
        ///     Callback (delegate for use with <see cref="glutWMCloseFunc" />.
        /// </summary>
        /// <seealso cref="glutWMCloseFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void WindowCloseCallback();
        #endregion WindowCloseCallback()

        #region MenuDestroyCallback()
        /// <summary>
        ///     Callback (delegate for use with <see cref="glutMenuDestroyFunc" />.
        /// </summary>
        /// <seealso cref="glutMenuDestroyFunc" />
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MenuDestroyCallback();
        #endregion MenuDestroyCallback()
        #endregion Callbacks

        // --- Private Methods ---
        #region Commented-Out LINUX Font Methods
        // TODO: WTF mate...
//        #region IntPtr glutStrokeRoman()
//        /// <summary>
//        ///     Use <see cref="GLUT_STROKE_ROMAN" /> instead.
//        /// </summary>
//        /// <returns>
//        ///     Pointer to font.
//        /// </returns>
//        // GLUTAPI void *glutStrokeRoman;
//        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
//        private static extern IntPtr glutStrokeRoman();
//        #endregion IntPtr glutStrokeRoman()
//
//        #region IntPtr glutStrokeMonoRoman()
//        /// <summary>
//        ///     Use <see cref="GLUT_STROKE_MONO_ROMAN" /> instead.
//        /// </summary>
//        /// <returns>
//        ///     Pointer to font.
//        /// </returns>
//        // GLUTAPI void *glutStrokeMonoRoman;
//        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
//        private static extern IntPtr glutStrokeMonoRoman();
//        #endregion IntPtr glutStrokeMonoRoman()
//
//        #region IntPtr glutBitmap9By15()
//        /// <summary>
//        ///     Use <see cref="GLUT_BITMAP_9_BY_15" /> instead.
//        /// </summary>
//        /// <returns>
//        ///     Pointer to font.
//        /// </returns>
//        // GLUTAPI void *glutBitmap9By15;
//        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
//        private static extern IntPtr glutBitmap9By15();
//        #endregion IntPtr glutBitmap9By15()
//
//        #region IntPtr glutBitmap8By13()
//        /// <summary>
//        ///     Use <see cref="GLUT_BITMAP_8_BY_13" /> instead.
//        /// </summary>
//        /// <returns>
//        ///     Pointer to font.
//        /// </returns>
//        // GLUTAPI void *glutBitmap8By13;
//        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
//        private static extern IntPtr glutBitmap8By13();
//        #endregion IntPtr glutBitmap8By13()
//
//        #region IntPtr glutBitmapTimesRoman10()
//        /// <summary>
//        ///     Use <see cref="GLUT_BITMAP_TIMES_ROMAN_10" /> instead.
//        /// </summary>
//        /// <returns>
//        ///     Pointer to font.
//        /// </returns>
//        // GLUTAPI void *glutBitmapTimesRoman10;
//        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
//        private static extern IntPtr glutBitmapTimesRoman10();
//        #endregion IntPtr glutBitmapTimesRoman10()
//
//        #region IntPtr glutBitmapTimesRoman24()
//        /// <summary>
//        ///     Use <see cref="GLUT_BITMAP_TIMES_ROMAN_24" /> instead.
//        /// </summary>
//        /// <returns>
//        ///     Pointer to font.
//        /// </returns>
//        // GLUTAPI void *glutBitmapTimesRoman24;
//        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
//        private static extern IntPtr glutBitmapTimesRoman24();
//        #endregion IntPtr glutBitmapTimesRoman24()
//
//        #region IntPtr glutBitmapHelvetica10()
//        /// <summary>
//        ///     Use <see cref="GLUT_BITMAP_HELVETICA_10" /> instead.
//        /// </summary>
//        /// <returns>
//        ///     Pointer to font.
//        /// </returns>
//        // GLUTAPI void *glutBitmapHelvetica10;
//        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
//        private static extern IntPtr glutBitmapHelvetica10();
//        #endregion IntPtr glutBitmapHelvetica10()
//
//        #region IntPtr glutBitmapHelvetica12()
//        /// <summary>
//        ///     Use <see cref="GLUT_BITMAP_HELVETICA_12" /> instead.
//        /// </summary>
//        /// <returns>
//        ///     Pointer to font.
//        /// </returns>
//        // GLUTAPI void *glutBitmapHelvetica12;
//        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
//        private static extern IntPtr glutBitmapHelvetica12();
//        #endregion IntPtr glutBitmapHelvetica12()
//
//        #region IntPtr glutBitmapHelvetica18()
//        /// <summary>
//        ///     Use <see cref="GLUT_BITMAP_HELVETICA_18" /> instead.
//        /// </summary>
//        /// <returns>
//        ///     Pointer to font.
//        /// </returns>
//        // GLUTAPI void *glutBitmapHelvetica18;
//        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
//        private static extern IntPtr glutBitmapHelvetica18();
//        #endregion IntPtr glutBitmapHelvetica18()
        #endregion Commented-Out LINUX Font Methods

        // --- Private Externs ---
        #region Internal Callback Sub-API
        #region int __glutCreateMenu([In] CreateMenuCallback func)
        /// <summary>
        ///     Called from <see cref="glutCreateMenu" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION, EntryPoint = "glutCreateMenu"), SuppressUnmanagedCodeSecurity]
        private static extern int __glutCreateMenu([In] CreateMenuCallback func);
        #endregion int __glutCreateMenu([In] CreateMenuCallback func)

        #region __glutDisplayFunc(DisplayCallback func)
        /// <summary>
        ///     Called from <see cref="glutDisplayFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutDisplayFunc(void (GLUTCALLBACK *func)(void));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutDisplayFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutDisplayFunc(DisplayCallback func);
        #endregion __glutDisplayFunc(DisplayCallback func)

        #region __glutReshapeFunc(ReshapeCallback func)
        /// <summary>
        ///     Called from <see cref="glutReshapeFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutReshapeFunc(void (GLUTCALLBACK *func)(int width, int height));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutReshapeFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutReshapeFunc(ReshapeCallback func);
        #endregion __glutReshapeFunc(ReshapeCallback func)

        #region __glutKeyboardFunc(KeyboardCallback func)
        /// <summary>
        ///     Called from <see cref="glutKeyboardFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutKeyboardFunc(void (GLUTCALLBACK *func)(unsigned char key, int x, int y));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutKeyboardFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutKeyboardFunc(KeyboardCallback func);
        #endregion __glutKeyboardFunc(KeyboardCallback func)

        #region __glutMouseFunc(MouseCallback func)
        /// <summary>
        ///     Called from <see cref="glutMouseFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutMouseFunc(void (GLUTCALLBACK *func)(int button, int state, int x, int y));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutMouseFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutMouseFunc(MouseCallback func);
        #endregion __glutMouseFunc(MouseCallback func)

        #region __glutMotionFunc(MotionCallback func)
        /// <summary>
        ///     Called from <see cref="glutMotionFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutMotionFunc(void (GLUTCALLBACK *func)(int x, int y));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutMotionFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutMotionFunc(MotionCallback func);
        #endregion __glutMotionFunc(MotionCallback func)

        #region __glutPassiveMotionFunc(PassiveMotionCallback func)
        /// <summary>
        ///     Called from <see cref="glutPassiveMotionFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutPassiveMotionFunc(void (GLUTCALLBACK *func)(int x, int y));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutPassiveMotionFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutPassiveMotionFunc(PassiveMotionCallback func);
        #endregion __glutPassiveMotionFunc(PassiveMotionCallback func)

        #region __glutEntryFunc(EntryCallback func)
        /// <summary>
        ///     Called from <see cref="glutEntryFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutEntryFunc(void (GLUTCALLBACK *func)(int state));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutEntryFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutEntryFunc(EntryCallback func);
        #endregion __glutEntryFunc(EntryCallback func)

        #region __glutVisibilityFunc(VisibilityCallback func)
        /// <summary>
        ///     Called from <see cref="glutVisibilityFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutVisibilityFunc(void (GLUTCALLBACK *func)(int state));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutVisibilityFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutVisibilityFunc(VisibilityCallback func);
        #endregion __glutVisibilityFunc(VisibilityCallback func)

        #region __glutIdleFunc(IdleCallback func)
        /// <summary>
        ///     Called from <see cref="glutIdleFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutIdleFunc(void (GLUTCALLBACK *func)(void));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutIdleFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutIdleFunc(IdleCallback func);
        #endregion __glutIdleFunc(IdleCallback func)

        #region __glutTimerFunc(int msecs, TimerCallback func, int val)
        /// <summary>
        ///     Called from <see cref="glutTimerFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutTimerFunc(unsigned int millis, void (GLUTCALLBACK *func)(int value), int value);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutTimerFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutTimerFunc(int msecs, TimerCallback func, int val);
        #endregion __glutTimerFunc(int msecs, TimerCallback func, int val)

        #region __glutMenuStateFunc(MenuStateCallback func)
        /// <summary>
        ///     Called from <see cref="glutMenuStateFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutMenuStateFunc(void (GLUTCALLBACK *func)(int state));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutMenuStateFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutMenuStateFunc(MenuStateCallback func);
        #endregion __glutMenuStateFunc(MenuStateCallback func)

        #region __glutSpecialFunc(SpecialCallback func)
        /// <summary>
        ///     Called from <see cref="glutSpecialFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutSpecialFunc(void (GLUTCALLBACK *func)(int key, int x, int y));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutSpecialFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutSpecialFunc(SpecialCallback func);
        #endregion __glutSpecialFunc(SpecialCallback func)

        #region __glutSpaceballMotionFunc(SpaceballMotionCallback func)
        /// <summary>
        ///     Called from <see cref="glutSpaceballMotionFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutSpaceballMotionFunc(void (GLUTCALLBACK *func)(int x, int y, int z));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutSpaceballMotionFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutSpaceballMotionFunc(SpaceballMotionCallback func);
        #endregion __glutSpaceballMotionFunc(SpaceballMotionCallback func)

        #region __glutSpaceballRotateFunc(SpaceballRotateCallback func)
        /// <summary>
        ///     Called from <see cref="glutSpaceballRotateFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutSpaceballRotateFunc(void (GLUTCALLBACK *func)(int x, int y, int z));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutSpaceballRotateFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutSpaceballRotateFunc(SpaceballRotateCallback func);
        #endregion __glutSpaceballRotateFunc(SpaceballRotateCallback func)

        #region __glutSpaceballButtonFunc(SpaceballButtonCallback func)
        /// <summary>
        ///     Called from <see cref="glutSpaceballButtonFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutSpaceballButtonFunc(void (GLUTCALLBACK *func)(int button, int state));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutSpaceballButtonFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutSpaceballButtonFunc(SpaceballButtonCallback func);
        #endregion __glutSpaceballButtonFunc(SpaceballButtonCallback func)

        #region __glutButtonBoxFunc(ButtonBoxCallback func)
        /// <summary>
        ///     Called from <see cref="glutButtonBoxFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutButtonBoxFunc(void (GLUTCALLBACK *func)(int button, int state));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutButtonBoxFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutButtonBoxFunc(ButtonBoxCallback func);
        #endregion __glutButtonBoxFunc(ButtonBoxCallback func)

        #region __glutDialsFunc(DialsCallback func)
        /// <summary>
        ///     Called from <see cref="glutDialsFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutDialsFunc(void (GLUTCALLBACK *func)(int dial, int value));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutDialsFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutDialsFunc(DialsCallback func);
        #endregion __glutDialsFunc(DialsCallback func)

        #region __glutTabletMotionFunc(TabletMotionCallback func)
        /// <summary>
        ///     Called from <see cref="glutTabletMotionFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutTabletMotionFunc(void (GLUTCALLBACK *func)(int x, int y));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutTabletMotionFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutTabletMotionFunc(TabletMotionCallback func);
        #endregion __glutTabletMotionFunc(TabletMotionCallback func)

        #region __glutTabletButtonFunc(TabletButtonCallback func)
        /// <summary>
        ///     Called from <see cref="glutTabletButtonFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutTabletButtonFunc(void (GLUTCALLBACK *func)(int button, int state, int x, int y));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutTabletButtonFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutTabletButtonFunc(TabletButtonCallback func);
        #endregion __glutTabletButtonFunc(TabletButtonCallback func)

        #region __glutMenuStatusFunc(MenuStatusCallback func)
        /// <summary>
        ///     Called from <see cref="glutMenuStatusFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutMenuStatusFunc(void (GLUTCALLBACK *func)(int status, int x, int y));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutMenuStatusFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutMenuStatusFunc(MenuStatusCallback func);
        #endregion __glutMenuStatusFunc(MenuStatusCallback func)

        #region __glutOverlayDisplayFunc(OverlayDisplayCallback func)
        /// <summary>
        ///     Called from <see cref="glutOverlayDisplayFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutOverlayDisplayFunc(void (GLUTCALLBACK *func)(void));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutOverlayDisplayFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutOverlayDisplayFunc(OverlayDisplayCallback func);
        #endregion __glutOverlayDisplayFunc(OverlayDisplayCallback func)

        #region __glutWindowStatusFunc(WindowStatusCallback func)
        /// <summary>
        ///     Called from <see cref="glutWindowStatusFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutWindowStatusFunc(void (GLUTCALLBACK *func)(int state));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutWindowStatusFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutWindowStatusFunc(WindowStatusCallback func);
        #endregion __glutWindowStatusFunc(WindowStatusCallback func)

        #region __glutKeyboardUpFunc(KeyboardUpCallback func)
        /// <summary>
        ///     Called from <see cref="glutKeyboardUpFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutKeyboardUpFunc(void (GLUTCALLBACK *func)(unsigned char key, int x, int y));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutKeyboardUpFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutKeyboardUpFunc(KeyboardUpCallback func);
        #endregion __glutKeyboardUpFunc(KeyboardUpCallback func)

        #region __glutSpecialUpFunc(SpecialUpCallback func)
        /// <summary>
        ///     Called from <see cref="glutSpecialUpFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutSpecialUpFunc(void (GLUTCALLBACK *func)(int key, int x, int y));
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutSpecialUpFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutSpecialUpFunc(SpecialUpCallback func);
        #endregion __glutSpecialUpFunc(SpecialUpCallback func)

        #region __glutJoystickFunc(JoystickCallback func, int pollInterval)
        /// <summary>
        ///     Called from <see cref="glutJoystickFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions.</b>
        /// </remarks>
        // GLUTAPI void APIENTRY glutJoystickFunc(void (GLUTCALLBACK *func)(unsigned int buttonMask, int x, int y, int z), int pollInterval);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutJoystickFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutJoystickFunc(JoystickCallback func, int pollInterval);
        #endregion __glutJoystickFunc(JoystickCallback func, int pollInterval)

        // --- FreeGLUT Additions ---
        #region __glutMouseWheelFunc(MouseWheelCallback func)
        /// <summary>
        ///     Called from <see cref="glutMouseWheelFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions and it's called
        ///     from a non-standard method!</b>
        /// </remarks>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutMouseWheelFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutMouseWheelFunc(MouseWheelCallback func);
        #endregion __glutMouseWheelFunc(MouseWheelCallback func)

        #region __glutCloseFunc(CloseCallback func)
        /// <summary>
        ///     Called from <see cref="glutCloseFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions and it's called
        ///     from a non-standard method!</b>
        /// </remarks>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutCloseFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutCloseFunc(CloseCallback func);
        #endregion __glutCloseFunc(CloseCallback func)

        #region __glutWMCloseFunc(WindowCloseCallback func)
        /// <summary>
        ///     Called from <see cref="glutWMCloseFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions and it's called
        ///     from a non-standard method!</b>
        /// </remarks>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutWMCloseFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutWMCloseFunc(WindowCloseCallback func);
        #endregion __glutWMCloseFunc(WindowCloseCallback func)

        #region __glutMenuDestroyFunc(MenuDestroyCallback func)
        /// <summary>
        ///     Called from <see cref="glutMenuDestroyFunc" />.
        /// </summary>
        /// <remarks>
        ///     <b>This method is not CLS-compliant due to naming conventions and it's called
        ///     from a non-standard method!</b>
        /// </remarks>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="glutMenuDestroyFunc"), SuppressUnmanagedCodeSecurity]
        private static extern void __glutMenuDestroyFunc(MenuDestroyCallback func);
        #endregion __glutMenuDestroyFunc(MenuDestroyCallback func)
        #endregion Internal Callback Sub-API

        // --- Public Externs ---
        #region Initialization Sub-API
        #region glutInit()
        /// <summary>
        ///     Initializes the GLUT library.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         This is a non-standard version of <b>glutInit</b> that passes the appropriate
        ///         commandline arguments automatically.
        ///     </para>
        ///     <para>
        ///         <b>glutInit</b> will initialize the GLUT library and negotiate a session with
        ///         the window system.  During this process, <b>glutInit</b> may cause the
        ///         termination of the GLUT program with an error message to the user if GLUT
        ///         cannot be properly initialized.  Examples of this situation include the
        ///         failure to connect to the window system, the lack of window system support for
        ///         OpenGL, and invalid command line options.
        ///     </para>
        ///     <para>
        ///         <b>glutInit</b> also processes command line options, but the specific options
        ///         parsed are window system dependent.
        ///     </para>
        ///     <para>
        ///         <b>X IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         The X Window System specific options parsed by <b>glutInit</b> are as follows:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>-display DISPLAY</term>
        ///                 <description>
        ///                     Specify the X server to connect to.  If not specified, the value
        ///                     of the DISPLAY environment variable is used.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>-geometry WxH+X+Y</term>
        ///                 <description>
        ///                     Determines where window's should be created on the screen.  The
        ///                     parameter following -geometry should be formatted as a standard X
        ///                     geometry specification.  The effect of using this option is to
        ///                     change the GLUT initial size and initial position the same as if
        ///                     <see cref="glutInitWindowSize" /> or
        ///                     <see cref="glutInitWindowPosition" /> were called directly.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>-iconic</term>
        ///                 <description>
        ///                     Requests all top-level windows be created in an iconic state.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>-indirect</term>
        ///                 <description>
        ///                     Force the use of indirect OpenGL rendering contexts.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>-direct</term>
        ///                 <description>
        ///                     <para>
        ///                         Force the use of direct OpenGL rendering contexts (not all GLX
        ///                         implementations support direct rendering contexts).  A fatal
        ///                         error is generated if direct rendering is not supported by the
        ///                         OpenGL implementation.
        ///                     </para>
        ///                     <para>
        ///                         If neither -indirect or -direct are used to force a particular
        ///                         behavior, GLUT will attempt to use direct rendering if
        ///                         possible and otherwise fallback to indirect rendering.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>-gldebug</term>
        ///                 <description>
        ///                     After processing callbacks and/or events, check if there are any
        ///                     OpenGL errors by calling <see cref="Gl.glGetError" />.  If an
        ///                     error is reported, print out a warning by looking up the error
        ///                     code with /*see cref="Glu.gluErrorString" />*/.  Using this option is
        ///                     helpful in detecting OpenGL run-time errors.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>-sync</term>
        ///                 <description>
        ///                     Enable synchronous X protocol transactions.  This option makes it
        ///                     easier to track down potential X protocol errors.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutInitWindowPosition" />
        /// <seealso cref="glutInitWindowSize" />
        /// <seealso cref="glutMainLoop" />
        public static void glutInit() {
            string[] argsArray = Environment.GetCommandLineArgs();
            StringBuilder[] args = new StringBuilder[argsArray.Length];
            int argsLength = args.Length;

            for(int i = 0; i < argsArray.Length; i++) {
                args[i] = new StringBuilder(argsArray[i], argsArray[i].Length);
            }

            glutInit(ref argsLength, args);
        }
        #endregion glutInit()

        #region glutInit(ref int argcp, [In, Out] StringBuilder[] argv)
        /// <summary>
        ///     Initializes the GLUT library.
        /// </summary>
        /// <param name="argcp">
        ///     A pointer to the program’s unmodified argc variable from main.  Upon return,
        ///     the value pointed to by <i>argcp</i> will be updated, because <b>glutInit</b>
        ///     extracts any command line options intended for the GLUT library.
        /// </param>
        /// <param name="argv">
        ///     The program’s unmodified <i>argv</i> variable from main.  Like <i>argcp</i>,
        ///     the data for <i>argv</i> will be updated because <b>glutInit</b> extracts any
        ///     command line options understood by the GLUT library.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutInit</b> will initialize the GLUT library and negotiate a session with
        ///         the window system.  During this process, <b>glutInit</b> may cause the
        ///         termination of the GLUT program with an error message to the user if GLUT
        ///         cannot be properly initialized.  Examples of this situation include the
        ///         failure to connect to the window system, the lack of window system support for
        ///         OpenGL, and invalid command line options.
        ///     </para>
        ///     <para>
        ///         <b>glutInit</b> also processes command line options, but the specific options
        ///         parsed are window system dependent.
        ///     </para>
        ///     <para>
        ///         <b>X IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         The X Window System specific options parsed by <b>glutInit</b> are as follows:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>-display DISPLAY</term>
        ///                 <description>
        ///                     Specify the X server to connect to.  If not specified, the value
        ///                     of the DISPLAY environment variable is used.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>-geometry WxH+X+Y</term>
        ///                 <description>
        ///                     Determines where window's should be created on the screen.  The
        ///                     parameter following -geometry should be formatted as a standard X
        ///                     geometry specification.  The effect of using this option is to
        ///                     change the GLUT initial size and initial position the same as if
        ///                     <see cref="glutInitWindowSize" /> or
        ///                     <see cref="glutInitWindowPosition" /> were called directly.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>-iconic</term>
        ///                 <description>
        ///                     Requests all top-level windows be created in an iconic state.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>-indirect</term>
        ///                 <description>
        ///                     Force the use of indirect OpenGL rendering contexts.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>-direct</term>
        ///                 <description>
        ///                     <para>
        ///                         Force the use of direct OpenGL rendering contexts (not all GLX
        ///                         implementations support direct rendering contexts).  A fatal
        ///                         error is generated if direct rendering is not supported by the
        ///                         OpenGL implementation.
        ///                     </para>
        ///                     <para>
        ///                         If neither -indirect or -direct are used to force a particular
        ///                         behavior, GLUT will attempt to use direct rendering if
        ///                         possible and otherwise fallback to indirect rendering.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>-gldebug</term>
        ///                 <description>
        ///                     After processing callbacks and/or events, check if there are any
        ///                     OpenGL errors by calling <see cref="Gl.glGetError" />.  If an
        ///                     error is reported, print out a warning by looking up the error
        ///                     code with /*see cref="Glu.gluErrorString" />*/.  Using this option is
        ///                     helpful in detecting OpenGL run-time errors.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>-sync</term>
        ///                 <description>
        ///                     Enable synchronous X protocol transactions.  This option makes it
        ///                     easier to track down potential X protocol errors.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutInitWindowPosition" />
        /// <seealso cref="glutInitWindowSize" />
        /// <seealso cref="glutMainLoop" />
        // GLUTAPI void APIENTRY glutInit(int *argcp, char **argv);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutInit(ref int argcp, StringBuilder[] argv);
        #endregion glutInit(ref int argcp, [In, Out] StringBuilder[] argv)

        #region glutInitDisplayMode(int mode)
        /// <summary>
        ///     Sets the initial display mode.
        /// </summary>
        /// <param name="mode">
        ///     <para>
        ///         Display mode, normally the bitwise OR-ing of GLUT display mode bit masks.  See
        ///         values below:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="GLUT_RGBA" /></term>
        ///                 <description>
        ///                     Bit mask to select an RGBA mode window.  This is the default if
        ///                     neither <see cref="GLUT_RGBA" /> nor <see cref="GLUT_INDEX" />
        ///                     are specified.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_RGB" /></term>
        ///                 <description>An alias for <see cref="GLUT_RGBA" />.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_INDEX" /></term>
        ///                 <description>
        ///                     Bit mask to select a color index mode window.  This overrides
        ///                     <see cref="GLUT_RGBA" /> if it is also specified.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_SINGLE" /></term>
        ///                 <description>
        ///                     Bit mask to select a single buffered window.  This is the default
        ///                     if neither <see cref="GLUT_DOUBLE" /> or
        ///                     <see cref="GLUT_SINGLE" /> are specified.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_DOUBLE" /></term>
        ///                 <description>
        ///                     Bit mask to select a double buffered window.  This overrides
        ///                     <see cref="GLUT_SINGLE" /> if it is also specified.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_ACCUM" /></term>
        ///                 <description>
        ///                     Bit mask to select a window with an accumulation buffer.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_ALPHA" /></term>
        ///                 <description>
        ///                     Bit mask to select a window with an alpha component to the color
        ///                     buffer(s).
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_DEPTH" /></term>
        ///                 <description>
        ///                     Bit mask to select a window with a depth buffer.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_STENCIL" /></term>
        ///                 <description>
        ///                     Bit mask to select a window with a stencil buffer.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_MULTISAMPLE" /></term>
        ///                 <description>
        ///                     Bit mask to select a window with multisampling support.  If
        ///                     multisampling is not available, a non-multisampling window will
        ///                     automatically be chosen.  Note: both the OpenGL client-side and
        ///                     server-side implementations must support the GLX_SAMPLE_SGIS
        ///                     extension for multisampling to be available.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_STEREO" /></term>
        ///                 <description>
        ///                     Bit mask to select a stereo window.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_LUMINANCE" /></term>
        ///                 <description>
        ///                     Bit mask to select a window with a "luminance" color model.  This
        ///                     model provides the functionality of OpenGL's RGBA color model, but
        ///                     the green and blue components are not maintained in the frame
        ///                     buffer.  Instead each pixel's red component is converted to an
        ///                     index between zero and
        ///                     <c>Glut.glutGet(Glut.GLUT_WINDOW_COLORMAP_SIZE) - 1</c> and looked
        ///                     up in a per-window color map to determine the color of pixels
        ///                     within the window.  The initial colormap of
        ///                     <see cref="GLUT_LUMINANCE" /> windows is initialized to be a
        ///                     linear gray ramp, but can be modified with GLUT's colormap
        ///                     routines.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <remarks>
        ///     <para>
        ///         The initial display mode is used when creating top-level windows, subwindows,
        ///         and overlays to determine the OpenGL display mode for the to-be-created
        ///         window or overlay.
        ///     </para>
        ///     <para>
        ///         Note that <see cref="GLUT_RGBA" /> selects the RGBA color model, but it does
        ///         not request any bits of alpha (sometimes called an alpha buffer or destination
        ///         alpha) be allocated.  To request alpha, specify <see cref="GLUT_ALPHA" />.
        ///         The same applies to <see cref="GLUT_LUMINANCE" />.
        ///     </para>
        ///     <para>
        ///         <b>NOTE</b>
        ///     </para>
        ///     <para>
        ///         <see cref="GLUT_LUMINANCE" /> is not supported on most OpenGL platforms.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutInit()" />
        /// <seealso cref="glutInitDisplayString" />
        // GLUTAPI void APIENTRY glutInitDisplayMode(unsigned int mode);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutInitDisplayMode(int mode);
        #endregion glutInitDisplayMode(int mode)

        #region glutInitDisplayString(string str)
        /// <summary>
        ///     Sets the initial display mode via a string.
        /// </summary>
        /// <param name="str">
        ///     Display mode description string, see below.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         The initial display mode description string is used when creating
        ///         top-level windows, subwindows, and overlays to determine the OpenGL display
        ///         mode for the to-be-created window or overlay.
        ///     </para>
        ///     <para>
        ///         The string is a list of zero or more capability descriptions separated by
        ///         spaces and tabs.  Each capability description is a capability name that is
        ///         optionally followed by a comparator and a numeric value.  For example,
        ///         "double" and "depth&gt;=12" are both valid criteria.
        ///     </para>
        ///     <para>
        ///         The capability descriptions are translated into a set of criteria used to
        ///         select the appropriate frame buffer configuration.
        ///     </para>
        ///     <para>
        ///         The criteria are matched in strict left to right order of precdence.  That is,
        ///         the first specified criteria (leftmost) takes precedence over the later
        ///         criteria for non-exact criteria (greater than, less than, etc. comparators).
        ///         Exact criteria (equal, not equal compartors) must match exactly so precedence
        ///         is not relevant.
        ///     </para>
        ///     <para>
        ///         The numeric value is an integer that is parsed according to ANSI C's
        ///         <c>strtol(str, strptr, 0)</c> behavior.  This means that decimal, octal
        ///         (leading 0), and hexidecimal values (leading 0x) are accepted.
        ///     </para>
        ///     <para>
        ///         The valid compartors are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>=</term>
        ///                 <description>Equal.</description>
        ///             </item>
        ///             <item>
        ///                 <term>!=</term>
        ///                 <description>Not equal.</description>
        ///             </item>
        ///             <item>
        ///                 <term>&lt;</term>
        ///                 <description>
        ///                     Less than and preferring larger difference (the least is best).
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>&gt;</term>
        ///                 <description>
        ///                     Greeater than and preferring larger differences (the most is
        ///                     best).
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>&lt;=</term>
        ///                 <description>
        ///                     Less than or equal and preferring larger difference (the least is
        ///                     best).
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>&gt;=</term>
        ///                 <description>
        ///                     Greater than or equal and preferring more instead of less.  This
        ///                     comparator is useful for allocating resources like color precsion
        ///                     or depth buffer precision where the maximum precison is
        ///                     generally preferred.  Contrast with the tilde (~) comprator.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>~</term>
        ///                 <description>
        ///                     Greater than or equal but preferring less instead of more.  This
        ///                     compartor is useful for allocating resources such as stencil bits
        ///                     or auxillary color buffers where you would rather not over
        ///                     allocate.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         When the compartor and numeric value are not specified, each capability name
        ///         has a different default (one default is to require a compartor and numeric
        ///         value).
        ///     </para>
        ///     <para>
        ///         The valid capability names are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>alpha</term>
        ///                 <description>
        ///                     <para>
        ///                         Alpha color buffer precision in bits.
        ///                     </para>
        ///                     <para>
        ///                         Default is "&gt;=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>acca</term>
        ///                 <description>
        ///                     <para>
        ///                         Red, green, blue, and alpha accumulation buffer precision in
        ///                         bits.
        ///                     </para>
        ///                     <para>
        ///                         Default is "&gt;=1" for red, green, blue, and alpha
        ///                         capabilities.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>acc</term>
        ///                 <description>
        ///                     <para>
        ///                         Red, green, and green accumulation buffer precision in bits
        ///                         and zero bits of alpha accumulation buffer precision.
        ///                     </para>
        ///                     <para>
        ///                         Default is "&gt;=1" for red, green, and blue capabilities,
        ///                         and "~0" for the alpha capability.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>blue</term>
        ///                 <description>
        ///                     <para>
        ///                         Blue color buffer precision in bits.
        ///                     </para>
        ///                     <para>
        ///                         Default is "&gt;=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>buffer</term>
        ///                 <description>
        ///                     <para>
        ///                         Number of bits in the color index color buffer.
        ///                     </para>
        ///                     <para>
        ///                         Default is "&gt;=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>conformant</term>
        ///                 <description>
        ///                     <para>
        ///                         bool indicating if the frame buffer configuration is
        ///                         conformant or not.  Conformance information is based on
        ///                         GLX's EXT_visual_rating extension if supported.  If the
        ///                         extension is not supported, all visuals are assumed
        ///                         conformat.
        ///                     </para>
        ///                     <para>
        ///                         Default is "=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>depth</term>
        ///                 <description>
        ///                     <para>
        ///                         Number of bits of precsion in the depth buffer.
        ///                     </para>
        ///                     <para>
        ///                         Default is "&gt;=12".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>double</term>
        ///                 <description>
        ///                     <para>
        ///                         bool indicating if the color buffer is double buffered.
        ///                     </para>
        ///                     <para>
        ///                         Default is "=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>green</term>
        ///                 <description>
        ///                     <para>
        ///                         Green color buffer precision in bits.
        ///                     </para>
        ///                     <para>
        ///                         Default is "&gt;=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>index</term>
        ///                 <description>
        ///                     <para>
        ///                         bool if the color model is color index or not.  True is
        ///                         color index.
        ///                     </para>
        ///                     <para>
        ///                         Default is "&gt;=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>num</term>
        ///                 <description>
        ///                     A special capability name indicating where the value represents
        ///                     the Nth frame buffer configuration matching the description
        ///                     string.  When not specified, <b>glutInitDisplayString</b> also
        ///                     returns the first (best matching) configuration.  <i>num</i>
        ///                     requires a compartor and numeric value.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>red</term>
        ///                 <description>
        ///                     <para>
        ///                         Red color buffer precision in bits.
        ///                     </para>
        ///                     <para>
        ///                         Default is "&gt;=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>rgba</term>
        ///                 <description>
        ///                     <para>
        ///                         Number of bits of red, green, blue, and alpha in the RGBA
        ///                         color buffer.
        ///                     </para>
        ///                     <para>
        ///                         Default is "&gt;=1" for red, green, blue, and alpha
        ///                         capabilities, and "=1" for the RGBA color model capability.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>rgb</term>
        ///                 <description>
        ///                     <para>
        ///                         Number of bits of red, green, and blue in the RGBA color
        ///                         buffer and zero bits of alpha color buffer precision.
        ///                     </para>
        ///                     <para>
        ///                         Default is "&gt;=1" for the red, green, and blue capabilities,
        ///                         and "~0" for alpha capability, and "=1" for the RGBA color
        ///                         model capability.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>luminance</term>
        ///                 <description>
        ///                     <para>
        ///                         Number of bits of red in the RGBA and zero bits of green, blue
        ///                         (alpha not specified) of color buffer precision.
        ///                     </para>
        ///                     <para>
        ///                         Default is "&gt;=1" for the red capabilities, and "=0" for the
        ///                         green and blue capabilities, and "=1" for the RGBA color model
        ///                         capability, and, for X11, "=1" for the StaticGray
        ///                         ("xstaticgray") capability.
        ///                     </para>
        ///                     <para>
        ///                         SGI InfiniteReality (and other future machines) support a
        ///                         16-bit luminance (single channel) display mode (an additional
        ///                         16-bit alpha channel can also be requested).  The red channel
        ///                         maps to gray scale and green and blue channels are not
        ///                         available.  A 16-bit precision luminance display mode is often
        ///                         appropriate for medical imaging applications.  Do not expect
        ///                         many machines to support extended precision luminance display
        ///                         modes.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>stencil</term>
        ///                 <description>Number of bits in the stencil buffer.</description>
        ///             </item>
        ///             <item>
        ///                 <term>single</term>
        ///                 <description>
        ///                     <para>
        ///                         bool indicate the color buffer is single buffered.
        ///                     </para>
        ///                     <para>
        ///                         double buffer capability "=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>stereo</term>
        ///                 <description>
        ///                     <para>
        ///                         bool indicating the color buffer is supports OpenGL-style
        ///                         stereo.
        ///                     </para>
        ///                     <para>
        ///                         Default is "=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>samples</term>
        ///                 <description>
        ///                     <para>
        ///                         Indicates the number of multisamples to use based on GLX's
        ///                         SGIS_multisample extension (for antialiasing).
        ///                     </para>
        ///                     <para>
        ///                         Default is "&lt;=4".  This default means that a GLUT
        ///                         application can request multipsampling if available by simply
        ///                         specifying "samples".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>slow</term>
        ///                 <description>
        ///                     <para>
        ///                         bool indicating if the frame buffer configuration is slow
        ///                         or not.  Slowness information is based on GLX's
        ///                         EXT_visual_rating extension if supported.  If the extension is
        ///                         not supported, all visuals are assumed fast.  Note that
        ///                         slowness is a relative designation relative to other frame
        ///                         buffer configurations available.  The intent of the slow
        ///                         capability is to help programs avoid frame buffer
        ///                         configurations that are slower (but perhaps higher precision)
        ///                         for the current machine.
        ///                     </para>
        ///                     <para>
        ///                         Default is "&gt;=0".  This default means that slow visuals are
        ///                         used in preference to fast visuals, but fast visuals will
        ///                         still be allowed.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>win32pfd</term>
        ///                 <description>
        ///                     Only recognized on GLUT implementations for Win32, this
        ///                     capability name matches the Win32 Pixel Format Descriptor by
        ///                     number.  <i>win32pfd</i> requires a compartor and numeric value.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>xvisual</term>
        ///                 <description>
        ///                     Only recognized on GLUT implementations for the X Window System,
        ///                     this capability name matches the X visual ID by number.
        ///                     xvisual requires a compartor and numeric value.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>xstaticgray</term>
        ///                 <description>
        ///                     <para>
        ///                         Only recognized on GLUT implementations for the X Window
        ///                         System, boolean indicating if the frame buffer configuration's
        ///                         X visual is of type StaticGray.
        ///                     </para>
        ///                     <para>
        ///                         Default is "=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>xgrayscale</term>
        ///                 <description>
        ///                     <para>
        ///                         Only recognized on GLUT implementations for the X Window
        ///                         System, boolean indicating if the frame buffer configuration's
        ///                         X visual is of type GrayScale.
        ///                     </para>
        ///                     <para>
        ///                         Default is "=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>xstaticcolor</term>
        ///                 <description>
        ///                     <para>
        ///                         Only recognized on GLUT implementations for the X Window
        ///                         System, boolean indicating if the frame buffer configuration's
        ///                         X visual is of type StaticColor.
        ///                     </para>
        ///                     <para>
        ///                         Default is "=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>xpseudocolor</term>
        ///                 <description>
        ///                     <para>
        ///                         Only recognized on GLUT implementations for the X Window
        ///                         System, boolean indicating if the frame buffer configuration's
        ///                         X visual is of type PsuedoColor.
        ///                     </para>
        ///                     <para>
        ///                         Default is "=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>xtruecolor</term>
        ///                 <description>
        ///                     <para>
        ///                         Only recognized on GLUT implementations for the X Window
        ///                         System, boolean indicating if the frame buffer configuration's
        ///                         X visual is of type TrueColor.
        ///                     </para>
        ///                     <para>
        ///                         Default is "=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>xdirectcolor</term>
        ///                 <description>
        ///                     <para>
        ///                         Only recognized on GLUT implementations for the X Window
        ///                         System, boolean indicating if the frame buffer configuration's
        ///                         X visual is of type DirectColor.
        ///                     </para>
        ///                     <para>
        ///                         Default is "=1".
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         Unspecifed capability descriptions will result in unspecified criteria being
        ///         generated.  These unspecified criteria help <b>glutInitDisplayString</b>
        ///         behave sensibly with terse display mode description strings.
        ///     </para>
        ///     <para>
        ///         <b>EXAMPLE</b>
        ///     </para>
        ///     <para>
        ///         Here is an example using <b>glutInitDisplayString</b>:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             Glut.glutInitDisplayString("stencil~2 rgb double depth>=16 samples");
        ///         </code>
        ///     </para>
        ///     <para>
        ///         The above call requests a window with an RGBA color model (but requesting no
        ///         bits of alpha), a depth buffer with at least 16 bits of precsion but
        ///         preferring more, mutlisampling if available, and at least 2 bits of stencil
        ///         (favoring less stencil to more as long as 2 bits are available).
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutInit()" />
        /// <seealso cref="glutInitDisplayMode" />
        // GLUTAPI void APIENTRY glutInitDisplayString(const char *string);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutInitDisplayString(string str);
        #endregion glutInitDisplayString(string str)

        #region glutInitWindowPosition(int x, int y)
        /// <summary>
        ///     Sets the initial window position.
        /// </summary>
        /// <param name="x">
        ///     Window X location in pixels.
        /// </param>
        /// <param name="y">
        ///     Window Y location in pixels.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         Windows created by <see cref="glutCreateWindow" /> will be requested to be
        ///         created with the current initial window position.  The initial value of the
        ///         initial window position GLUT state is -1 and -1.  If either the X or Y
        ///         component to the initial window position is negative, the actual window
        ///         position is left to the window system to determine.
        ///     </para>
        ///     <para>
        ///         The intent of the initial window position values is to provide a suggestion to
        ///         the window system for a window’s initial position.  The window system is not
        ///         obligated to use this information.  Therefore, GLUT programs should not assume
        ///         the window was created at the specified position.
        ///     </para>
        ///     <para>
        ///         <b>Example</b>
        ///     </para>
        ///     <para>
        ///         If you would like your GLUT program to default to starting at a given screen
        ///         location and at a given size, but you would also like to let the user override
        ///         these default via a command line argument (such as -geometry for X11), call
        ///         <see cref="glutInitWindowSize" /> and <see cref="glutInitWindowPosition"/>
        ///         before your call to <see cref="glutInit()" />.  For example:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             using Tao.OpenGL;
        /// 
        ///             [STAThread]
        ///             public static void Main(string[] args) {
        ///                 Glut.glutInitWindowSize(500, 300);
        ///                 Glut.glutInitWindowPosition(100, 100);
        ///                 Glut.glutInit();
        ///             }
        ///         </code>
        ///     </para>
        ///     <para>
        ///         However, if you'd like to force your program to start up at a given size and
        ///         position, call <see cref="glutInitWindowSize" /> and
        ///         <see cref="glutInitWindowPosition" /> after your call to
        ///         <see cref="glutInit()" />. For example:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             using Tao.OpenGL;
        /// 
        ///             [STAThread]
        ///             public static void Main(string[] args) {
        ///                 Glut.glutInit();
        ///                 Glut.glutInitWindowSize(500, 300);
        ///                 Glut.glutInitWindowPosition(100, 100);
        ///             }
        ///         </code>
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutCreateSubWindow" />
        /// <seealso cref="glutGet" />
        /// <seealso cref="glutInit()" />
        /// <seealso cref="glutInitWindowSize" />
        /// <seealso cref="glutReshapeFunc" />
        /// <seealso cref="ReshapeCallback" />
        // GLUTAPI void APIENTRY glutInitWindowPosition(int x, int y);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutInitWindowPosition(int x, int y);
        #endregion glutInitWindowPosition(int x, int y)

        #region glutInitWindowSize(int width, int height)
        /// <summary>
        ///     Sets the initial window size.
        /// </summary>
        /// <param name="width">
        ///     Width in pixels.
        /// </param>
        /// <param name="height">
        ///     Height in pixels.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         Windows created by <see cref="glutCreateWindow" /> will be requested to be
        ///         created with the current initial window size.  The initial value of the
        ///         initial window size GLUT state is 300 by 300.  The initial window size
        ///         components must be greater than zero.
        ///     </para>
        ///     <para>
        ///         The intent of the initial window size values is to provide a suggestion to the
        ///         window system for a window’s initial size.  The window system is not obligated
        ///         to use this information.  Therefore, GLUT programs should not assume the
        ///         window was created at the specified size.  A GLUT program should use the
        ///         window’s reshape callback to determine the true size of the window.
        ///     </para>
        ///     <para>
        ///         <b>Example</b>
        ///     </para>
        ///     <para>
        ///         If you would like your GLUT program to default to starting at a given screen
        ///         location and at a given size, but you would also like to let the user
        ///         override these default via a command line argument (such as -geometry for
        ///         X11), call <see cref="glutInitWindowSize" /> and
        ///         <see cref="glutInitWindowPosition"/> before your call to
        ///         <see cref="glutInit()" />.  For example:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             using Tao.OpenGL;
        /// 
        ///             [STAThread]
        ///             public static void Main(string[] args) {
        ///                 Glut.glutInitWindowSize(500, 300);
        ///                 Glut.glutInitWindowPosition(100, 100);
        ///                 Glut.glutInit();
        ///             }
        ///         </code>
        ///     </para>
        ///     <para>
        ///         However, if you'd like to force your program to start up at a given size and
        ///         position, call <see cref="glutInitWindowSize" /> and
        ///         <see cref="glutInitWindowPosition" /> after your call to
        ///         <see cref="glutInit()" />.  For example:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             using Tao.OpenGL;
        /// 
        ///             [STAThread]
        ///             public static void Main(string[] args) {
        ///                 Glut.glutInit();
        ///                 Glut.glutInitWindowSize(500, 300);
        ///                 Glut.glutInitWindowPosition(100, 100);
        ///             }
        ///         </code>
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutCreateSubWindow" />
        /// <seealso cref="glutGet" />
        /// <seealso cref="glutInit()" />
        /// <seealso cref="glutInitWindowPosition" />
        /// <seealso cref="glutReshapeFunc" />
        /// <seealso cref="ReshapeCallback" />
        // GLUTAPI void APIENTRY glutInitWindowSize(int width, int height);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutInitWindowSize(int width, int height);
        #endregion glutInitWindowSize(int width, int height)
        #endregion Initialization Sub-API

        #region Beginning Event Processing Sub-API
        #region glutMainLoop()
        /// <summary>
        ///     Enters the GLUT event processing loop.
        /// </summary>
        /// <remarks>
        ///     <b>glutMainLoop</b> enters the GLUT event processing loop.  This routine
        ///     should be called at most once in a GLUT program.  Once called, this
        ///     routine will never return.  It will call as necessary any callbacks
        ///     (delegates) that have been registered.
        /// </remarks>
        /// <seealso cref="glutInit()" />
        // GLUTAPI void APIENTRY glutMainLoop(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutMainLoop();
        #endregion glutMainLoop()
        #endregion Beginning Event Processing Sub-API

        #region Window Management Sub-API
        #region int glutCreateWindow(string name)
        /// <summary>
        ///     Creates a top-level window.
        /// </summary>
        /// <param name="name">
        ///     Character string for use as window name.
        /// </param>
        /// <returns>
        ///     The value returned is a unique small integer identifier for the window.  The
        ///     range of allocated identifiers starts at one.  This window identifier can be
        ///     used when calling <see cref="glutSetWindow" />.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         <b>glutCreateWindow</b> creates a top-level window.  The <i>name</i> will be
        ///         provided to the window system as the window’s title.  The intent is that the
        ///         window system will label the window with <i>name</i> as the title.
        ///     </para>
        ///     <para>
        ///         Implicitly, the current window is set to the newly created window.
        ///     </para>
        ///     <para>
        ///         Each created window has a unique associated OpenGL context.  State changes to
        ///         a window’s associated OpenGL context can be done immediately after the window
        ///         is created.
        ///     </para>
        ///     <para>
        ///         The display state of a window is initially for the window to be shown.  But
        ///         the window’s display state is not actually acted upon until
        ///         <see cref="glutMainLoop" /> is entered.  This means until <b>glutMainLoop</b>
        ///         is called, rendering to a created window is ineffective because the window can
        ///         not yet be displayed.
        ///     </para>
        ///     <para>
        ///         <b>X IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         The proper X Inter-Client Communications Convention Manual (ICCCM) top-level
        ///         properties are established.  The WM_COMMAND property that lists the
        ///         commandline used to invoke the GLUT program is only established for the first
        ///         window created.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutCreateMenu" />
        /// <seealso cref="glutCreateSubWindow" />
        /// <seealso cref="glutDestroyWindow" />
        // GLUTAPI int APIENTRY glutCreateWindow(const char *name);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutCreateWindow(string name);
        #endregion int glutCreateWindow(string name)

        #region int glutCreateSubWindow(int win, int x, int y, int width, int height)
        /// <summary>
        ///     Creates a subwindow.
        /// </summary>
        /// <param name="win">
        ///     Identifier of the subwindow’s parent window.
        /// </param>
        /// <param name="x">
        ///     Window X location in pixels relative to parent window’s origin.
        /// </param>
        /// <param name="y">
        ///     Window Y location in pixels relative to parent window’s origin.
        /// </param>
        /// <param name="width">
        ///     Width in pixels.
        /// </param>
        /// <param name="height">
        ///     Height in pixels.
        /// </param>
        /// <returns>
        ///     The value returned is a unique small integer identifier for the window.  The
        ///     range of allocated identifiers starts at one.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         <b>glutCreateSubWindow</b> creates a subwindow of the window identified by
        ///         <i>win</i> of size <i>width</i> and <i>height</i> at location <i>x</i> and
        ///         <i>y</i> within the current window.  Implicitly, the current window is set to
        ///         the newly created subwindow.
        ///     </para>
        ///     <para>
        ///         Each created window has a unique associated OpenGL context.  State changes to
        ///         a window’s associated OpenGL context can be done immediately after the window
        ///         is created.
        ///     </para>
        ///     <para>
        ///         The display state of a window is initially for the window to be shown.  But
        ///         the window’s display state is not actually acted upon until
        ///         <see cref="glutMainLoop" /> is entered.   This means until <b>glutMainLoop</b>
        ///         is called, rendering to a created window is ineffective.  Subwindows can not
        ///         be iconified.
        ///     </para>
        ///     <para>
        ///         Subwindows can be nested arbitrarily deep.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutDestroyWindow" />
        // GLUTAPI int APIENTRY glutCreateSubWindow(int win, int x, int y, int width, int height);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutCreateSubWindow(int win, int x, int y, int width, int height);
        #endregion int glutCreateSubWindow(int win, int x, int y, int width, int height)

        #region glutDestroyWindow(int win)
        /// <summary>
        ///     Destroys the specified window.
        /// </summary>
        /// <param name="win">
        ///     Identifier of GLUT window to destroy.
        /// </param>
        /// <remarks>
        ///     <b>glutDestroyWindow</b> destroys the window specified by <i>win</i> and the
        ///     window’s associated OpenGL context, logical colormap (if the window is color
        ///     index), and overlay and related state (if an overlay has been established).
        ///     Any subwindows of destroyed windows are also destroyed by
        ///     <b>glutDestroyWindow</b>.  If <i>win</i> was the current window, the current
        ///     window becomes invalid (<see cref="glutGetWindow" /> will return zero).
        /// </remarks>
        /// <seealso cref="glutCreateWindow"/>
        /// <seealso cref="glutCreateSubWindow" />
        /// <seealso cref="glutDestroyMenu" />
        // GLUTAPI void APIENTRY glutDestroyWindow(int win);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutDestroyWindow(int win);
        #endregion glutDestroyWindow(int win)

        #region glutPostRedisplay()
        /// <summary>
        ///     Marks the current window as needing to be redisplayed.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <b>glutPostRedisplay</b> marks the normal plane of current window as needing
        ///         to be redisplayed.  The next iteration through <see cref="glutMainLoop" />,
        ///         the window's display callback will be called to redisplay the window's normal
        ///         plane.  Multiple calls to <b>glutPostRedisplay</b> before the next display
        ///         callback opportunity generates only a single redisplay callback.
        ///         <b>glutPostRedisplay</b> may be called within a window's display or overlay
        ///         display callback to re-mark that window for redisplay.
        ///     </para>
        ///     <para>
        ///         Logically, normal plane damage notification for a window is treated as a
        ///         <b>glutPostRedisplay</b> on the damaged window.  Unlike damage reported by the
        ///         window system, <b>glutPostRedisplay</b> will not set to <c>true</c> the normal
        ///         plane's damaged status (returned by
        ///         <c>Glut.glutLayerGet(Glut.GLUT_NORMAL_DAMAGED)</c>.
        ///     </para>
        ///     <para>
        ///         If the window you want to post a redisplay on is not already current (and you
        ///         do not require it to be immediately made current), using
        ///         <see cref="glutPostWindowRedisplay" /> is more efficient than calling
        ///         <see cref="glutSetWindow" /> to the desired window and then calling
        ///         <b>glutPostRedisplay</b>.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutDisplayFunc" />
        /// <seealso cref="glutPostOverlayRedisplay" />
        /// <seealso cref="glutPostWindowRedisplay" />
        // GLUTAPI void APIENTRY glutPostRedisplay(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutPostRedisplay();
        #endregion glutPostRedisplay()

        #region glutPostWindowRedisplay(int win)
        /// <summary>
        ///     Marks the specified window as needing to be redisplayed.
        /// </summary>
        /// <param name="win">
        ///     Identifier of GLUT window to mark for redisplay.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutPostWindowRedisplay</b> marks the specified window as needing to be
        ///         redisplayed.  The next iteration through <see cref="glutMainLoop" />, the
        ///         window's display callback will be called to redisplay the window's normal
        ///         plane.
        ///     </para>
        ///     <para>
        ///         If the window you want to post a redisplay on is not already current (and you
        ///         do not require it to be immediately made current), using
        ///         <b>glutPostWindowRedisplay</b> is more efficient than calling
        ///         <see cref="glutSetWindow" /> to the desired window and then calling
        ///         <see cref="glutPostRedisplay" />.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutDisplayFunc" />
        /// <seealso cref="glutPostOverlayRedisplay" />
        /// <seealso cref="glutPostRedisplay" />
        // GLUTAPI void APIENTRY glutPostWindowRedisplay(int win);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutPostWindowRedisplay(int win);
        #endregion glutPostWindowRedisplay(int win)

        #region glutSwapBuffers()
        /// <summary>
        ///     Swaps the buffers of the current window if double buffered.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Performs a buffer swap on the layer in use for the current window.
        ///         Specifically, <b>glutSwapBuffers</b> promotes the contents of the back buffer
        ///         of the layer in use of the current window to become the contents of the front
        ///         buffer.  The contents of the back buffer then become undefined.  The update
        ///         typically takes place during the vertical retrace of the monitor, rather than
        ///         immediately after <b>glutSwapBuffers</b> is called.
        ///     </para>
        ///     <para>
        ///         An implicit <see cref="Gl.glFlush"/> is done by <b>glutSwapBuffers</b> before
        ///         it returns.  Subsequent OpenGL commands can be issued immediately after
        ///         calling <b>glutSwapBuffers</b>, but are not executed until the buffer exchange
        ///         is completed.
        ///     </para>
        ///     <para>
        ///         If the layer in use is not double buffered, <b>glutSwapBuffers</b> has no
        ///         effect.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutDisplayFunc" />
        /// <seealso cref="glutPostRedisplay" />
        // GLUTAPI void APIENTRY glutSwapBuffers(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSwapBuffers();
        #endregion glutSwapBuffers()

        #region int glutGetWindow()
        /// <summary>
        ///     Returns the identifier of the current window.
        /// </summary>
        /// <returns>
        ///     <b>glutGetWindow</b> returns the identifier of the current window.  If no
        ///     windows exist or the previously current window was destroyed,
        ///     <b>glutGetWindow</b> returns zero.
        /// </returns>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutSetWindow" />
        // GLUTAPI int APIENTRY glutGetWindow(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutGetWindow();
        #endregion int glutGetWindow()

        #region glutSetWindow(int win)
        /// <summary>
        ///     Sets the current window.
        /// </summary>
        /// <param name="win">
        ///     Identifier of GLUT window to make the current window.
        /// </param>
        /// <remarks>
        ///     <b>glutSetWindow</b> sets the current window.  <b>glutSetWindow</b> does not
        ///     change the layer in use for the window; this is done using
        ///     <see cref="glutUseLayer" />.
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutGetWindow" />
        /// <seealso cref="glutSetMenu" />
        // GLUTAPI void APIENTRY glutSetWindow(int win);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSetWindow(int win);
        #endregion glutSetWindow(int win)

        #region glutSetWindowTitle(string name)
        /// <summary>
        ///     Changes the window title of the current top-level window.
        /// </summary>
        /// <param name="name">
        ///     Character string for the window name to be set for the window.
        /// </param>
        /// <remarks>
        ///     <b>glutSetWindowTitle</b> should be called only when the current window is a
        ///     top-level window.  Upon creation of a top-level window, the window title is
        ///     determined by the <i>name</i> parameter to <see cref="glutCreateWindow" />.
        ///     Once created, <b>glutSetWindowTitle</b> can change the window title of
        ///     top-level windows.  Each call requests the window system change the title
        ///     appropriately.  Requests are not buffered or coalesced.  The policy by which
        ///     the window title is displayed is window system dependent.
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutSetIconTitle" />
        // GLUTAPI void APIENTRY glutSetWindowTitle(const char *name);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSetWindowTitle(string name);
        #endregion glutSetWindowTitle(string name)

        #region glutSetIconTitle(string name)
        /// <summary>
        ///     Changes the icon title of the current top-level window.
        /// </summary>
        /// <param name="name">
        ///     Character string for the icon name to be set for the window.
        /// </param>
        /// <remarks>
        ///     <b>glutSetIconTitle</b> should be called only when the current window is a
        ///     top-level window.  Upon creation of a top-level window, the icon name is
        ///     determined by the <i>name</i> parameter to <see cref="glutCreateWindow" />.
        ///     Once created, <b>glutSetIconTitle</b> can change the icon name of top-level
        ///     windows.  Each call requests the window system change the name appropriately.
        ///     Requests are not buffered or coalesced.  The policy by which the icon name are
        ///     displayed is window system dependent.
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutIconifyWindow" />
        /// <seealso cref="glutSetWindowTitle" />
        // GLUTAPI void APIENTRY glutSetIconTitle(const char *name);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSetIconTitle(string name);
        #endregion glutSetIconTitle(string name)

        #region glutPositionWindow(int x, int y)
        /// <summary>
        ///     Requests a change to the position of the current window.
        /// </summary>
        /// <param name="x">
        ///     New X location of window in pixels.
        /// </param>
        /// <param name="y">
        ///     New Y location of window in pixels.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutPositionWindow</b> requests a change in the position of the current
        ///         window.  For top-level windows, the <i>x</i> and <i>y</i> parameters are
        ///         pixel offsets from the screen origin.  For subwindows, the <i>x</i> and
        ///         <i>y</i> parameters are pixel offsets from the window's parent window origin.
        ///     </para>
        ///     <para>
        ///         The requests by <b>glutPositionWindow</b> are not processed immediately.  The
        ///         request is executed after returning to the main event loop.  This allows
        ///         multiple <b>glutPositionWindow</b>, <see cref="glutReshapeWindow" />, and
        ///         <see cref="glutFullScreen" /> requests to the same window to be coalesced.
        ///     </para>
        ///     <para>
        ///         In the case of top-level windows, a <b>glutPositionWindow</b> call is
        ///         considered only a request for positioning the window.  The window system is
        ///         free to apply its own policies to top-level window placement.  The intent is
        ///         that top-level windows should be repositioned according to
        ///         <b>glutPositionWindow's</b> parameters.
        ///     </para>
        ///     <para>
        ///         <b>glutPositionWindow</b> disables the full screen status of a window if
        ///         previously enabled.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutInitWindowPosition" />
        /// <seealso cref="glutReshapeWindow" />
        // GLUTAPI void APIENTRY glutPositionWindow(int x, int y);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutPositionWindow(int x, int y);
        #endregion glutPositionWindow(int x, int y)

        #region glutReshapeWindow(int width, int height)
        /// <summary>
        ///     Requests a change to the size of the current window.
        /// </summary>
        /// <param name="width">
        ///     New width of window in pixels.
        /// </param>
        /// <param name="height">
        ///     New height of window in pixels.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutReshapeWindow</b> requests a change in the size of the current window.
        ///         The <i>width</i> and <i>height</i> parameters are size extents in pixels.  The
        ///         <i>width</i> and <i>height</i> must be positive values.
        ///     </para>
        ///     <para>
        ///         The requests by <b>glutReshapeWindow</b> are not processed immediately.  The
        ///         request is executed after returning to the main event loop.  This allows
        ///         multiple <b>glutReshapeWindow</b>, <see cref="glutPositionWindow" />, and
        ///         <see cref="glutFullScreen" /> requests to the same window to be coalesced.
        ///     </para>
        ///     <para>
        ///         In the case of top-level windows, a <b>glutReshapeWindow</b> call is
        ///         considered only a request for sizing the window.  The window system is free to
        ///         apply its own policies to top-level window sizing.  The intent is that
        ///         top-level windows should be reshaped according to <b>glutReshapeWindow's</b>
        ///         parameters.  Whether a reshape actually takes effect and, if so, the reshaped
        ///         dimensions are reported to the program by a reshape callback.
        ///     </para>
        ///     <para>
        ///         <b>glutReshapeWindow</b> disables the full screen status of a window if
        ///         previously enabled.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutPositionWindow" />
        /// <seealso cref="glutReshapeFunc" />
        // GLUTAPI void APIENTRY glutReshapeWindow(int width, int height);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutReshapeWindow(int width, int height);
        #endregion glutReshapeWindow(int width, int height)

        #region glutPopWindow()
        /// <summary>
        ///     Changes the stacking order of the current window relative to its siblings.
        /// </summary>
        /// <remarks>
        ///     <b>glutPopWindow</b> works on both top-level windows and subwindows.  The
        ///     effect of popping windows does not take place immediately.  Instead the pop is
        ///     saved for execution upon return to the GLUT event loop.  Subsequent pop
        ///     requests on a window replace the previously saved request for that window.
        ///     The effect of popping top-level windows is subject to the window system's
        ///     policy for restacking windows.
        /// </remarks>
        /// <seealso cref="glutHideWindow" />
        /// <seealso cref="glutIconifyWindow" />
        /// <seealso cref="glutPushWindow" />
        /// <seealso cref="glutShowWindow" />
        // GLUTAPI void APIENTRY glutPopWindow(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutPopWindow();
        #endregion glutPopWindow()

        #region glutPushWindow()
        /// <summary>
        ///     Changes the stacking order of the current window relative to its siblings.
        /// </summary>
        /// <remarks>
        ///     <b>glutPushWindow</b> works on both top-level windows and subwindows.  The
        ///     effect of pushing windows does not take place immediately.  Instead the push
        ///     is saved for execution upon return to the GLUT event loop.  Subsequent push
        ///     requests on a window replace the previously saved request for that window.
        ///     The effect of pushing top-level windows is subject to the window system's
        ///     policy for restacking windows.
        /// </remarks>
        /// <seealso cref="glutHideWindow" />
        /// <seealso cref="glutIconifyWindow" />
        /// <seealso cref="glutPopWindow" />
        /// <seealso cref="glutShowWindow" />
        // GLUTAPI void APIENTRY glutPushWindow(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutPushWindow();
        #endregion glutPushWindow()

        #region glutIconifyWindow()
        /// <summary>
        ///     Changes the display status of the current window.
        /// </summary>
        /// <remarks>
        ///     <b>glutIconifyWindow</b> will iconify a top-level window, but GLUT prohibits
        ///     iconification of a subwindow.  The effect of iconifying windows does not take
        ///     place immediately.  Instead the requests are saved for execution upon return
        ///     to the GLUT event loop.  Subsequent iconification requests on a window replace
        ///     the previously saved request for that window.  The effect of iconifying
        ///     top-level windows is subject to the window system's policy for displaying
        ///     windows.
        /// </remarks>
        /// <seealso cref="glutHideWindow" />
        /// <seealso cref="glutPopWindow" />
        /// <seealso cref="glutPushWindow" />
        /// <seealso cref="glutShowWindow" />
        // GLUTAPI void APIENTRY glutIconifyWindow(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutIconifyWindow();
        #endregion glutIconifyWindow()

        #region glutShowWindow()
        /// <summary>
        ///     Changes the display status of the current window.
        /// </summary>
        /// <remarks>
        ///     <b>glutShowWindow</b> will show the current window (though it may still not be
        ///     visible if obscured by other shown windows).  The effect of showing windows
        ///     does not take place immediately.  Instead the requests are saved for execution
        ///     upon return to the GLUT event loop.  Subsequent show requests on a window
        ///     replace the previously saved request for that window.  The effect of showing
        ///     top-level windows is subject to the window system's policy for displaying
        ///     windows.
        /// </remarks>
        /// <seealso cref="glutHideWindow" />
        /// <seealso cref="glutIconifyWindow" />
        /// <seealso cref="glutPopWindow" />
        /// <seealso cref="glutPushWindow" />
        // GLUTAPI void APIENTRY glutShowWindow(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutShowWindow();
        #endregion glutShowWindow()

        #region glutHideWindow()
        /// <summary>
        ///     Changes the display status of the current window.
        /// </summary>
        /// <remarks>
        ///     <b>glutHideWindow</b> will hide the current window.  The effect of hiding
        ///     windows does not take place immediately.  Instead the requests are saved for
        ///     execution upon return to the GLUT event loop.  Subsequent hide requests on a
        ///     window replace the previously saved request for that window.  The effect of
        ///     hiding top-level windows is subject to the window system's policy for
        ///     displaying windows.
        /// </remarks>
        /// <seealso cref="glutIconifyWindow" />
        /// <seealso cref="glutPopWindow" />
        /// <seealso cref="glutPushWindow" />
        /// <seealso cref="glutShowWindow" />
        // GLUTAPI void APIENTRY glutHideWindow(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutHideWindow();
        #endregion glutHideWindow()

        #region glutFullScreen()
        /// <summary>
        ///     Requests that the current window be made full screen.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <b>glutFullScreen</b> requests that the current window be made full screen.
        ///         The exact semantics of what full screen means may vary by window system.  The
        ///         intent is to make the window as large as possible and disable any window
        ///         decorations or borders added by the window system.  The window width and
        ///         height are not guaranteed to be the same as the screen width and height, but
        ///         that is the intent of making a window full screen.
        ///     </para>
        ///     <para>
        ///         <b>glutFullScreen</b> is defined to work only on top-level windows.
        ///     </para>
        ///     <para>
        ///         The <b>glutFullScreen</b> requests are not processed immediately.  The request
        ///         is executed after returning to the main event loop.  This allows multiple
        ///         <see cref="glutReshapeWindow" />, <see cref="glutPositionWindow" />, and
        ///         <b>glutFullScreen</b> requests to the same window to be coalesced.
        ///     </para>
        ///     <para>
        ///         Subsequent <b>glutReshapeWindow</b> and <b>glutPositionWindow</b> requests on
        ///         the window will disable the full screen status of the window.
        ///     </para>
        ///     <para>
        ///         <b>X IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         In the X implementation of GLUT, full screen is implemented by sizing and
        ///         positioning the window to cover the entire screen and posting the
        ///         _MOTIF_WM_HINTS property on the window requesting absolutely no decorations.
        ///         Non-Motif window managers may not respond to _MOTIF_WM_HINTS.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutPositionWindow" />
        /// <seealso cref="glutReshapeWindow" />
        // GLUTAPI void APIENTRY glutFullScreen(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutFullScreen();
        #endregion glutFullScreen()

        #region glutSetCursor(int cursor)
        /// <summary>
        ///     Changes the cursor image of the current window.
        /// </summary>
        /// <param name="cursor">
        ///     <para>
        ///         Name of cursor image to change to. Possible values follow:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_RIGHT_ARROW" /></term>
        ///                 <description>Arrow pointing up and to the right.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_LEFT_ARROW" /></term>
        ///                 <description>Arrow pointing up and to the left.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_INFO" /></term>
        ///                 <description>Pointing hand.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_DESTROY" /></term>
        ///                 <description>Skull and cross bones.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_HELP" /></term>
        ///                 <description>Question mark.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_CYCLE" /></term>
        ///                 <description>Arrows rotating in a circle.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_SPRAY" /></term>
        ///                 <description>Spray can.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_WAIT" /></term>
        ///                 <description>Wrist watch.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_TEXT" /></term>
        ///                 <description>Insertion point cursor for text.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_CROSSHAIR" /></term>
        ///                 <description>Simple cross-hair.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_UP_DOWN" /></term>
        ///                 <description>Bi-directional pointing up and down.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_LEFT_RIGHT" /></term>
        ///                 <description>Bi-directional pointing left and right.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_TOP_SIDE" /></term>
        ///                 <description>Arrow pointing to top side.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_BOTTOM_SIDE" /></term>
        ///                 <description>Arrow pointing to bottom side.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_LEFT_SIDE" /></term>
        ///                 <description>Arrow pointing to left side.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_RIGHT_SIDE" /></term>
        ///                 <description>Arrow pointing to right side.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_TOP_LEFT_CORNER" /></term>
        ///                 <description>Arrow pointing to top-left corner.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_TOP_RIGHT_CORNER" /></term>
        ///                 <description>Arrow pointing to top-right corner.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_BOTTOM_RIGHT_CORNER" /></term>
        ///                 <description>Arrow pointing to bottom-right corner.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_BOTTOM_LEFT_CORNER" /></term>
        ///                 <description>Arrow pointing to bottom-left corner.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_FULL_CROSSHAIR" /></term>
        ///                 <description>
        ///                     Full-screen cross-hair cursor (if possible, otherwise
        ///                     <see cref="GLUT_CURSOR_CROSSHAIR" />).
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_NONE" /></term>
        ///                 <description>Invisible cursor.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_CURSOR_INHERIT" /></term>
        ///                 <description>Use parent's cursor.</description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutSetCursor</b> changes the cursor image of the current window.  Each
        ///         call requests the window system change the cursor appropriately.  The cursor
        ///         image when a window is created is <see cref="GLUT_CURSOR_INHERIT" />.  The
        ///         exact cursor images used are implementation dependent.  The intent is for the
        ///         image to convey the meaning of the cursor name.  For a top-level window,
        ///         <i>GLUT_CURSOR_INHERIT</i> uses the default window system cursor.
        ///     </para>
        ///     <para>
        ///         <b>X IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         GLUT for X uses SGI's _SGI_CROSSHAIR_CURSOR convention to access a full-screen
        ///         cross-hair cursor if possible.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutCreateSubWindow" />
        // GLUTAPI void APIENTRY glutSetCursor(int cursor);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSetCursor(int cursor);
        #endregion glutSetCursor(int cursor)

        #region glutWarpPointer(int x, int y)
        /// <summary>
        ///     Warps the pointer's location.
        /// </summary>
        /// <param name="x">
        ///     X offset relative to the current window's origin (upper left).
        /// </param>
        /// <param name="y">
        ///     Y offset relative to the current window's origin (upper left).
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutWarpPointer</b> warps the window system's pointer to a new location
        ///         relative to the origin of the current window.  The new location will be offset
        ///         <i>x</i> pixels on the X axis and <i>y</i> pixels on the Y axis.  These
        ///         parameters may be negative.  The warp is done immediately.
        ///     </para>
        ///     <para>
        ///         If the pointer would be warped outside the screen's frame buffer region, the
        ///         location will be clamped to the nearest screen edge.  The window system is
        ///         allowed to further constrain the pointer's location in window system dependent
        ///         ways.
        ///     </para>
        ///     <para>
        ///         The following is good advice that applies to <b>glutWarpPointer</b>: "There is
        ///         seldom any reason for calling this function.  The pointer should normally be
        ///         left to the user." (from Xlib's XWarpPointer man page.)
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutMotionFunc" />
        /// <seealso cref="glutMouseFunc" />
        // GLUTAPI void APIENTRY glutWarpPointer(int x, int y);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutWarpPointer(int x, int y);
        #endregion glutWarpPointer(int x, int y)
        #endregion Window Management Sub-API

        #region Overlay Sub-API
        #region glutEstablishOverlay()
        /// <summary>
        ///     Establishes an overlay (if possible) for the current window.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <b>glutEstablishOverlay</b> establishes an overlay (if possible) for the
        ///         current window.  The requested display mode for the overlay is determined by
        ///         the initial display mode.  <c>glutLayerGet(GLUT_OVERLAY_POSSIBLE)</c> can be
        ///         called to determine if an overlay is possible for the current window with the
        ///         current initial display mode.  Do not attempt to establish an overlay when
        ///         one is not possible; GLUT will terminate the program.
        ///     </para>
        ///     <para>
        ///         If <b>glutEstablishOverlay</b> is called when an overlay already exists, the
        ///         existing overlay is first removed, and then a new overlay is established.  The
        ///         state of the old overlay's OpenGL context is discarded.
        ///     </para>
        ///     <para>
        ///         The initial display state of an overlay is shown, however the overlay is only
        ///         actually shown if the overlay's window is shown.
        ///     </para>
        ///     <para>
        ///         Implicitly, the window's layer in use changes to the overlay immediately after
        ///         the overlay is established.
        ///     </para>
        ///     <para>
        ///         <b>EXAMPLE</b>
        ///     </para>
        ///     <para>
        ///         Establishing an overlay is a bit involved, but easy once you get the hang of
        ///         it.  Here is an example:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             int overlaySupport;
        ///             int transparent, red, white;
        ///         
        ///             Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_INDEX);
        ///             overlaySupport = Glut.glutLayerGet(Glut.GLUT_OVERLAY_POSSIBLE);
        ///         
        ///             if(overlaySupport) {
        ///                 Glut.glutEstablishOverlay();
        ///                 Glut.glutHideOverlay();
        ///                 transparent = Glut.glutLayerGet(Glut.GLUT_TRANSPARENT_INDEX);
        ///                 Gl.glClearIndex(transparent);
        ///                 red = (transparent + 1) % Glut.glutGet(Glut.GLUT_WINDOW_COLORMAP_SIZE);
        ///                 white = (transparent + 2) % Glut.glutGet(Glut.GLUT_WINDOW_COLORMAP_SIZE);
        ///                 Glut.glutSetColor(red, 1.0f, 0.0f, 0.0f);
        ///                 Glut.glutSetColor(white, 1.0f, 1.0f, 1.0f);
        ///                 Glut.glutOverlayDisplayFunc(redrawOverlay);
        ///                 Glut.glutReshapFunc(reshape);
        ///             }
        ///             else {
        ///                 System.Console.WriteLine("Sorry, no nifty overlay support!");
        ///             }
        ///         </code>
        ///     </para>
        ///     <para>
        ///         If you setup an overlay and you install a reshape callback, you need to update
        ///         the viewports and possibly projection matrices of both the normal plane and
        ///         the overlay.  For example, your reshape callback might look like this:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             private void Reshape(int w, int h) {
        ///                 if(overlaySupport) {
        ///                     Glut.glutUseLayer(Glut.GLUT_OVERLAY);
        ///                     Gl.glViewport(0, 0, w, h);
        ///                     Gl.glMatrixMode(Gl.GL_PROJECTION);
        ///                     Gl.glLoadIdentity();
        ///                     Glu.gluOrtho2D(0, w, 0, h);
        ///                     Gl.glScalef(1, -1, 1);
        ///                     Gl.glTranslatef(0, -h, 0);
        ///                     Gl.glMatrixMode(Gl.GL_MODELVIEW);
        ///                     Glut.glutUseLayer(Glut.GLUT_NORMAL);
        ///                 }
        ///                 Gl.glViewport(0, 0, w, h);
        ///             }
        ///         </code>
        ///     </para>
        ///     <para>
        ///         See <see cref="glutOverlayDisplayFunc" /> for an example showing one way to
        ///         write your overlay display callback.
        ///     </para>
        ///     <para>
        ///         <b>X IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         GLUT for X uses the SERVER_OVERLAY_VISUALS convention to determine if overlay
        ///         visuals are available.  While the convention allows for opaque overlays (no
        ///         transparency) and overlays with the transparency specified as a bitmask, GLUT
        ///         overlay management only provides access to transparent pixel overlays.
        ///     </para>
        ///     <para>
        ///         Until RGBA overlays are better understood, GLUT only supports color index
        ///         overlays.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutLayerGet" />
        /// <seealso cref="glutOverlayDisplayFunc" />
        /// <seealso cref="glutPostOverlayRedisplay" />
        /// <seealso cref="glutRemoveOverlay" />
        /// <seealso cref="glutShowOverlay" />
        /// <seealso cref="glutUseLayer" />
        // GLUTAPI void APIENTRY glutEstablishOverlay(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutEstablishOverlay();
        #endregion glutEstablishOverlay()

        #region glutRemoveOverlay()
        /// <summary>
        ///     Removes the overlay (if one exists) from the current window.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <b>glutRemoveOverlay</b> removes the overlay (if one exists).  It is safe to
        ///         call <b>glutRemoveOverlay</b> even if no overlay is currently established --
        ///         it does nothing in this case.  Implicitly, the window's layer in use changes
        ///         to the normal plane immediately once the overlay is removed.
        ///     </para>
        ///     <para>
        ///         If the program intends to re-establish the overlay later, it is typically
        ///         faster and less resource intensive to use <see cref="glutHideOverlay" /> and
        ///         <see cref="glutShowOverlay" /> to simply change the display status of the
        ///         overlay.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutDestroyWindow" />
        /// <seealso cref="glutEstablishOverlay" />
        // GLUTAPI void APIENTRY glutRemoveOverlay(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutRemoveOverlay();
        #endregion glutRemoveOverlay()

        #region glutUseLayer(int layer)
        /// <summary>
        ///     Changes the layer in use for the current window.
        /// </summary>
        /// <param name="layer">
        ///     Either <see cref="GLUT_NORMAL" /> or <see cref="GLUT_OVERLAY" />, selecting
        ///     the normal plane or overlay respectively.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutUseLayer</b> changes the per-window layer in use for the current
        ///         window, selecting either the normal plane or overlay.  The overlay should only
        ///         be specified if an overlay exists, however windows without an overlay may
        ///         still call <c>Glut.glutUseLayer(Glut.GLUT_NORMAL)</c>.  OpenGL commands for
        ///         the window are directed to the current layer in use.
        ///     </para>
        ///     <para>
        ///         To query the layer in use for a window, call
        ///         <c>Glut.glutLayerGet(Glut.GLUT_LAYER_IN_USE)</c>.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutEstablishOverlay" />
        /// <seealso cref="glutSetWindow" />
        // GLUTAPI void APIENTRY glutUseLayer(GLenum layer);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutUseLayer(int layer);
        #endregion glutUseLayer(int layer)

        #region glutPostOverlayRedisplay()
        /// <summary>
        ///     Marks the overlay of the current window as needing to be redisplayed.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <b>glutPostOverlayRedisplay</b> marks the overlay of current window as needing
        ///         to be redisplayed.  The next iteration through <see cref="glutMainLoop" />,
        ///         the window's overlay display callback (or simply the display callback if no
        ///         overlay display callback is registered) will be called to redisplay the
        ///         window's overlay plane.  Multiple calls to <b>glutPostOverlayRedisplay</b>
        ///         before the next display callback opportunity (or overlay display callback
        ///         opportunity if one is registered) generate only a single redisplay.
        ///         <b>glutPostOverlayRedisplay</b> may be called within a window's display or
        ///         overlay display callback to re-mark that window for redisplay.
        ///     </para>
        ///     <para>
        ///         Logically, overlay damage notification for a window is treated as a
        ///         <b>glutPostOverlayRedisplay</b> on the damaged window.  Unlike damage reported
        ///         by the window system, <b>glutPostOverlayRedisplay</b> will not set to
        ///         <c>true</c> the overlay's damaged status (returned by
        ///         <c>Glut.glutLayerGet(Glut.GLUT_OVERLAY_DAMAGED)</c>.
        ///     </para>
        ///     <para>
        ///         If the window you want to post an overlay redisplay on is not already current
        ///         (and you do not require it to be immediately made current), using
        ///         <see cref="glutPostWindowOverlayRedisplay" /> is more efficient than calling
        ///         <see cref="glutSetWindow" /> to the desired window and then calling
        ///         <b>glutPostOverlayRedisplay</b>.
        ///     </para>
        ///     <para>
        ///         <b>EXAMPLE</b>
        ///     </para>
        ///     <para>
        ///         If you are doing an interactive effect like rubberbanding in the overlay, it
        ///         is a good idea to structure your rendering to minimize flicker (most overlays
        ///         are single-buffered).  Only clear the overlay if you know that the window has
        ///         been damaged.  Otherwise, try to simply erase what you last drew and redraw
        ///         it in an updated position.  Here is an example overlay display callback used
        ///         to implement overlay rubberbanding:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             private void redrawOverlay() {
        ///                 static int prevStretchX, prevStretchY;
        ///             
        ///                 if(Glut.glutLayerGet(Glut.GLUT_OVERLAY_DAMAGED)) {
        ///                     // Damage means we need a full clear.
        ///                     Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
        ///                 }
        ///                 else {
        ///                     // Undraw last rubber-band.
        ///                     Gl.glBegin(Gl.GL_LINE_LOOP);
        ///                         Gl.glVertex2i(anchorX, anchorY);
        ///                         Gl.glVertex2i(anchorX, prevStretchY);
        ///                         Gl.glVertex2i(prevStretchX, anchorY);
        ///                     Gl.glEnd();
        ///                 }
        ///             
        ///                 Gl.glIndexi(red);
        ///                 Gl.glBegin(Gl.GL_LINE_LOOP);
        ///                     Gl.glVertex2i(anchorX, anchorY);
        ///                     Gl.glVertex2i(anchorX, stretchY);
        ///                     Gl.glVertex2i(stretchX, stretchY);
        ///                     Gl.glVertex2i(stretchX, anchorY);
        ///                 Gl.glEnd();
        ///             
        ///                 prevStretchX = stretchX;
        ///                 prevStretchY = stretchY;
        ///             }
        ///         </code>
        ///     </para>
        ///     <para>
        ///         Notice how <c>Glut.glutLayerGet(Glut.GLUT_OVERLAY_DAMAGED)</c> is used to
        ///         determine if a clear needs to take place because of damage; if a clear is
        ///         unnecessary, it is faster to just draw the last rubberband using the
        ///         transparent pixel.
        ///     </para>
        ///     <para>
        ///         When the application is through with the rubberbanding effect, the best way to
        ///         get rid of the rubberband is to simply hide the overlay by calling
        ///         <see cref="glutHideOverlay" />.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutEstablishOverlay" />
        /// <seealso cref="glutHideOverlay" />
        /// <seealso cref="glutLayerGet" />
        /// <seealso cref="glutMainLoop" />
        /// <seealso cref="glutPostRedisplay" />
        /// <seealso cref="glutPostWindowOverlayRedisplay" />
        // GLUTAPI void APIENTRY glutPostOverlayRedisplay(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutPostOverlayRedisplay();
        #endregion glutPostOverlayRedisplay()

        #region glutPostWindowOverlayRedisplay(int win)
        /// <summary>
        ///     Marks the overlay of the specified window as needing to be redisplayed.
        /// </summary>
        /// <param name="win">
        ///     Identifier of GLUT window for which to post the overlay redisplay.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutPostWindowOverlayRedisplay</b> marks the overlay of specified window as
        ///         needing to be redisplayed.  The next iteration through
        ///         <see cref="glutMainLoop" />, the window's overlay display callback (or simply
        ///         the display callback if no overlay display callback is registered) will be
        ///         called to redisplay the window's overlay plane.  Multiple calls to
        ///         <b>glutPostWindowOverlayRedisplay</b> before the next display callback
        ///         opportunity (or overlay display callback opportunity if one is registered)
        ///         generate only a single redisplay.  <b>glutPostWindowOverlayRedisplay</b> may
        ///         be called within a window's display or overlay display callback to re-mark
        ///         that window for redisplay.
        ///     </para>
        ///     <para>
        ///         Logically, overlay damage notification for a window is treated as a
        ///         <b>glutPostWindowOverlayRedisplay</b> on the damaged window.  Unlike damage
        ///         reported by the window system, <b>glutPostWindowOverlayRedisplay</b> will not
        ///         set to <c>true</c> the overlay's damaged status (returned by
        ///         <c>Glut.glutLayerGet(Glut.GLUT_OVERLAY_DAMAGED)</c>.
        ///     </para>
        ///     <para>
        ///         If the window you want to post an overlay redisplay on is not already current
        ///         (and you do not require it to be immediately made current), using
        ///         <b>glutPostWindowOverlayRedisplay</b> is more efficient than calling
        ///         <see cref="glutSetWindow" /> to the desired window and then calling
        ///         <see cref="glutPostOverlayRedisplay" />.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutEstablishOverlay" />
        /// <seealso cref="glutHideOverlay" />
        /// <seealso cref="glutLayerGet" />
        /// <seealso cref="glutMainLoop" />
        /// <seealso cref="glutPostOverlayRedisplay" />
        /// <seealso cref="glutPostRedisplay" />
        // GLUTAPI void APIENTRY glutPostWindowOverlayRedisplay(int win);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutPostWindowOverlayRedisplay(int win);
        #endregion glutPostWindowOverlayRedisplay(int win)

        #region glutShowOverlay()
        /// <summary>
        ///     Shows the overlay of the current window.
        /// </summary>
        /// <remarks>
        ///     <b>glutShowOverlay</b> shows the overlay of the current window.  The effect of
        ///     showing an overlay takes place immediately.  Note that <b>glutShowOverlay</b>
        ///     will not actually display the overlay unless the window is also shown (and
        ///     even a shown window may be obscured by other windows, thereby obscuring the
        ///     overlay).  It is typically faster and less resource intensive to use these
        ///     routines to control the display status of an overlay as opposed to removing
        ///     and re-establishing the overlay.
        /// </remarks>
        /// <seealso cref="glutEstablishOverlay" />
        /// <seealso cref="glutHideOverlay" />
        /// <seealso cref="glutShowWindow" />
        // GLUTAPI void APIENTRY glutShowOverlay(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutShowOverlay();
        #endregion glutShowOverlay()

        #region glutHideOverlay()
        /// <summary>
        ///     Hides the overlay of the current window.
        /// </summary>
        /// <remarks>
        ///     <b>glutHideOverlay</b> hides the overlay of the current window.  The effect of
        ///     hiding an overlay takes place immediately.  It is typically faster and less
        ///     resource intensive to use these routines to control the display status of an
        ///     overlay as opposed to removing and re-establishing the overlay.
        /// </remarks>
        /// <seealso cref="glutEstablishOverlay" />
        /// <seealso cref="glutShowOverlay" />
        /// <seealso cref="glutShowWindow" />
        // GLUTAPI void APIENTRY glutHideOverlay(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutHideOverlay();
        #endregion glutHideOverlay()
        #endregion Overlay Sub-API

        #region Menu Sub-API
        #region glutDestroyMenu(int menu)
        /// <summary>
        ///     Destroys the specified menu.
        /// </summary>
        /// <param name="menu">
        ///     The identifier of the menu to destroy.
        /// </param>
        /// <remarks>
        ///     <b>glutDestroyMenu</b> destroys the specified menu by <i>menu</i>.  If
        ///     <i>menu</i> was the current menu, the current menu becomes invalid and
        ///     <see cref="glutGetMenu" /> will return zero.
        /// </remarks>
        /// <seealso cref="glutCreateMenu" />
        /// <seealso cref="glutGetMenu" />
        // GLUTAPI void APIENTRY glutDestroyMenu(int menu);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutDestroyMenu(int menu);
        #endregion glutDestroyMenu(int menu)

        #region int glutGetMenu()
        /// <summary>
        ///     Returns the identifier of the current menu.
        /// </summary>
        /// <returns>
        ///     Returns the identifier of the current menu.  If no menus exist or the previous
        ///     current menu was destroyed, <b>glutGetMenu</b> returns zero.
        /// </returns>
        /// <remarks>
        ///     Returns the identifier of the current menu.  If no menus exist or the previous
        ///     current menu was destroyed, <b>glutGetMenu</b> returns zero.
        /// </remarks>
        /// <seealso cref="glutSetMenu" />
        // GLUTAPI int APIENTRY glutGetMenu(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutGetMenu();
        #endregion int glutGetMenu()

        #region glutSetMenu(int menu)
        /// <summary>
        ///     Sets the current menu.
        /// </summary>
        /// <param name="menu">
        ///     The identifier of the menu to make the current menu.
        /// </param>
        /// <remarks>
        ///     <b>glutSetMenu</b> sets the current menu.
        /// </remarks>
        /// <seealso cref="glutGetMenu" />
        // GLUTAPI void APIENTRY glutSetMenu(int menu);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSetMenu(int menu);
        #endregion glutSetMenu(int menu)

        #region glutAddMenuEntry(string name, int val)
        /// <summary>
        ///     Adds a menu entry to the bottom of the current menu.
        /// </summary>
        /// <param name="name">
        ///     string to display in the menu entry.
        /// </param>
        /// <param name="val">
        ///     Value to return to the menu's callback function if the menu entry is selected.
        /// </param>
        /// <remarks>
        ///     <b>glutAddMenuEntry</b> adds a menu entry to the bottom of the current menu.
        ///     The string <i>name</i> will be displayed for the newly added menu entry.  If
        ///     the menu entry is selected by the user, the menu's callback will be called
        ///     passing <i>val</i> as the callback's parameter.
        /// </remarks>
        /// <seealso cref="glutAddSubMenu" />
        /// <seealso cref="glutChangeToMenuEntry" />
        /// <seealso cref="glutCreateMenu" />
        /// <seealso cref="glutRemoveMenuItem" />
        // GLUTAPI void APIENTRY glutAddMenuEntry(const char *label, int val);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutAddMenuEntry(string name, int val);
        #endregion glutAddMenuEntry(string name, int val)

        #region glutAddSubMenu(string name, int menu)
        /// <summary>
        ///     Adds a sub-menu trigger to the bottom of the current menu.
        /// </summary>
        /// <param name="name">
        ///     string to display in the menu item from which to cascade the sub-menu.
        /// </param>
        /// <param name="menu">
        ///     Identifier of the menu to cascade from this sub-menu menu item.
        /// </param>
        /// <remarks>
        ///     <b>glutAddSubMenu</b> adds a sub-menu trigger to the bottom of the current
        ///     menu.  The string <i>name</i> will be displayed for the newly added sub-menu
        ///     trigger.  If the sub-menu trigger is entered, the sub-menu numbered
        ///     <i>menu</i> will be cascaded, allowing sub-menu menu items to be selected.
        /// </remarks>
        /// <seealso cref="glutAddMenuEntry" />
        /// <seealso cref="glutChangeToSubMenu" />
        /// <seealso cref="glutRemoveMenuItem" />
        // GLUTAPI void APIENTRY glutAddSubMenu(const char *label, int menu);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutAddSubMenu(string name, int menu);
        #endregion glutAddSubMenu(string name, int menu)

        #region glutChangeToMenuEntry(int entry, string name, int val)
        /// <summary>
        ///     Changes the specified menu item in the current menu into a menu entry.
        /// </summary>
        /// <param name="entry">
        ///     Index into the menu items of the current menu (1 is the topmost menu item).
        /// </param>
        /// <param name="name">
        ///     string to display in the menu entry.
        /// </param>
        /// <param name="val">
        ///     Value to return to the menu's callback function if the menu entry is selected.
        /// </param>
        /// <remarks>
        ///     <b>glutChangeToMenuEntry</b> changes the specified menu entry in the current
        ///     menu into a menu entry.  The <i>entry</i> parameter determines which menu item
        ///     should be changed, with one being the topmost item.  <i>entry</i> must be
        ///     between 1 and <c>Glut.glutGet(Glut.GLUT_MENU_NUM_ITEMS)</c> inclusive.  The
        ///     menu item to change does not have to be a menu entry already.  The string
        ///     <i>name</i> will be displayed for the newly changed menu entry.  The
        ///     <i>val</i> will be returned to the menu's callback if this menu entry is
        ///     selected.
        /// </remarks>
        /// <seealso cref="glutAddMenuEntry" />
        /// <seealso cref="glutChangeToSubMenu" />
        /// <seealso cref="glutRemoveMenuItem" />
        // GLUTAPI void APIENTRY glutChangeToMenuEntry(int item, const char *label, int val);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutChangeToMenuEntry(int entry, string name, int val);
        #endregion glutChangeToMenuEntry(int entry, string name, int val)

        #region glutChangeToSubMenu(int entry, string name, int menu)
        /// <summary>
        ///     Changes the specified menu item in the current menu into a sub-menu trigger.
        /// </summary>
        /// <param name="entry">
        ///     Index into the menu items of the current menu (1 is the topmost menu item).
        /// </param>
        /// <param name="name">
        ///     string to display in the menu item to cascade the sub-menu from.
        /// </param>
        /// <param name="menu">
        ///     Identifier of the menu to cascade from this sub-menu menu item.
        /// </param>
        /// <remarks>
        ///     <b>glutChangeToSubMenu</b> changes the specified menu item in the current menu
        ///     into a sub-menu trigger.  The <i>entry</i> parameter determines which menu
        ///     item should be changed, with one being the topmost item.  <i>entry</i> must be
        ///     between 1 and <c>Glut.glutGet(Glut.GLUT_MENU_NUM_ITEMS)</c> inclusive.  The
        ///     menu item to change does not have to be a sub-menu trigger already.  The
        ///     string <i>name</i> will be displayed for the newly changed sub-menu trigger.
        ///     The <i>menu</i> identifier names the sub-menu to cascade from the newly added
        ///     sub-menu trigger.
        /// </remarks>
        /// <seealso cref="glutAddSubMenu" />
        /// <seealso cref="glutChangeToMenuEntry" />
        /// <seealso cref="glutRemoveMenuItem" />
        // GLUTAPI void APIENTRY glutChangeToSubMenu(int item, const char *label, int menu);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutChangeToSubMenu(int entry, string name, int menu);
        #endregion glutChangeToSubMenu(int entry, string name, int menu)

        #region glutRemoveMenuItem(int entry)
        /// <summary>
        ///     Removes the specified menu item.
        /// </summary>
        /// <param name="entry">
        ///     Index into the menu items of the current menu (1 is the topmost menu item).
        /// </param>
        /// <remarks>
        ///     <b>glutRemoveMenuItem</b> remove the entry menu item regardless of whether it
        ///     is a menu entry or sub-menu trigger.  <i>entry</i> must be between 1 and
        ///     <c>Glut.glutGet(Glut.GLUT_MENU_NUM_ITEMS)</c> inclusive.  Menu items below
        ///     the removed menu item are renumbered.
        /// </remarks>
        /// <seealso cref="glutAddMenuEntry" />
        /// <seealso cref="glutAddSubMenu" />
        /// <seealso cref="glutChangeToMenuEntry" />
        /// <seealso cref="glutChangeToSubMenu" />
        // GLUTAPI void APIENTRY glutRemoveMenuItem(int item);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutRemoveMenuItem(int entry);
        #endregion glutRemoveMenuItem(int entry)

        #region glutAttachMenu(int button)
        /// <summary>
        ///     Attaches a mouse button for the current window to the identifier of the current
        ///     menu.
        /// </summary>
        /// <param name="button">
        ///     The button to attach a menu.
        /// </param>
        /// <remarks>
        ///     <b>glutAttachMenu</b> attaches a mouse button for the current window to the
        ///     identifier of the current menu.  By attaching a menu identifier to a button,
        ///     the named menu will be popped up when the user presses the specified button.
        ///     <i>button</i> should be one of <see cref="GLUT_LEFT_BUTTON" />,
        ///     <see cref="GLUT_MIDDLE_BUTTON" />, and <see cref="GLUT_RIGHT_BUTTON" />.
        ///     Note that the menu is attached to the button by identifier, not by reference.
        /// </remarks>
        /// <seealso cref="glutCreateMenu" />
        /// <seealso cref="glutDetachMenu" />
        /// <seealso cref="glutMenuStatusFunc" />
        /// <seealso cref="glutMouseFunc" />
        // GLUTAPI void APIENTRY glutAttachMenu(int button);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutAttachMenu(int button);
        #endregion glutAttachMenu(int button)

        #region glutDetachMenu(int button)
        /// <summary>
        ///     Detaches an attached mouse button from the current window.
        /// </summary>
        /// <param name="button">
        ///     The button to detach a menu.
        /// </param>
        /// <remarks>
        ///     <b>glutDetachMenu</b> detaches an attached mouse button from the current
        ///     window.  <i>button</i> should be one of <see cref="GLUT_LEFT_BUTTON" />,
        ///     <see cref="GLUT_MIDDLE_BUTTON" />, and <see cref="GLUT_RIGHT_BUTTON" />.  Note
        ///     that the menu is attached to the button by identifier, not by reference.
        /// </remarks>
        /// <seealso cref="glutAttachMenu" />
        /// <seealso cref="glutCreateMenu" />
        /// <seealso cref="glutDetachMenu" />
        /// <seealso cref="glutMenuStatusFunc" />
        /// <seealso cref="glutMouseFunc" />
        // GLUTAPI void APIENTRY glutDetachMenu(int button);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutDetachMenu(int button);
        #endregion glutDetachMenu(int button)
        #endregion Menu Sub-API

        #region Callback Sub-API
        #region int glutCreateMenu([In] CreateMenuCallback func)
        /// <summary>
        ///     Creates a new pop-up menu.
        /// </summary>
        /// <param name="func">
        ///     The callback function for the menu that is called when a menu entry from the
        ///     menu is selected.  The value passed to the callback is determined by the value
        ///     for the selected menu entry.  See <see cref="CreateMenuCallback" />.
        /// </param>
        /// <returns>
        ///     Returns a unique small integer identifier.  The range of allocated identifiers
        ///     starts at one.  The menu identifier range is separate from the window
        ///     identifier range.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         <b>glutCreateMenu</b> creates a new pop-up menu and returns a unique small
        ///         integer identifier.  The range of allocated identifiers starts at one.  The
        ///         menu identifier range is separate from the window identifier range.
        ///         Implicitly, the current menu is set to the newly created menu.  This menu
        ///         identifier can be used when calling <see cref="glutSetMenu" />.
        ///     </para>
        ///     <para>
        ///         When the menu callback is called because a menu entry is selected for the
        ///         menu, the current menu will be implicitly set to the menu with the selected
        ///         entry before the callback is made.
        ///     </para>
        ///     <para>
        ///         <b>EXAMPLE</b>
        ///     </para>
        ///     <para>
        ///         Here is a quick example of how to create a GLUT popup menu with two submenus
        ///         and attach it to the right button of the current window:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             int submenu1, submenu2;
        ///
        ///             submenu1 = Glut.glutCreateMenu(selectMessage);
        ///             Glut.glutAddMenuEntry("abc", 1);
        ///             Glut.glutAddMenuEntry("ABC", 2);
        ///
        ///             submenu2 = Glut.glutCreateMenu(selectColor);
        ///             Glut.glutAddMenuEntry("Green", 1);
        ///             Glut.glutAddMenuEntry("Red", 2);
        ///             Glut.glutAddMenuEntry("White", 3);
        ///
        ///             Glut.glutCreateMenu(selectFont);
        ///             Glut.glutAddMenuEntry("9 by 15", 0);
        ///             Glut.glutAddMenuEntry("Times Roman 10", 1);
        ///             Glut.glutAddMenuEntry("Times Roman 24", 2);
        ///             Glut.glutAddSubMenu("Messages", submenu1);
        ///             Glut.glutAddSubMenu("Color", submenu2);
        ///             Glut.glutAttachMenu(Glut.GLUT_RIGHT_BUTTON);
        ///         </code>
        ///     </para>
        ///     <para>
        ///         <b>X IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         If available, GLUT for X will take advantage of overlay planes for
        ///         implementing pop-up menus.  The use of overlay planes can eliminate display
        ///         callbacks when pop-up menus are deactivated.  The SERVER_OVERLAY_VISUALS
        ///         convention is used to determine if overlay visuals are available.
        ///     </para>
        /// </remarks>
        /// <seealso cref="CreateMenuCallback" />
        /// <seealso cref="glutAttachMenu" />
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutDestroyMenu" />
        /// <seealso cref="glutSetMenu" />
        // GLUTAPI int APIENTRY glutCreateMenu(void (GLUTCALLBACK *func)(int));
        public static int glutCreateMenu([In] CreateMenuCallback func) {
            createMenuCallback = func;
            return __glutCreateMenu(createMenuCallback);
        }
        #endregion int glutCreateMenu([In] CreateMenuCallback func)

        #region glutDisplayFunc([In] DisplayCallback func)
        /// <summary>
        ///     Sets the display callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new display callback function.  See <see cref="DisplayCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutDisplayFunc</b> sets the display callback for the current window.  When
        ///         GLUT determines that the normal plane for the window needs to be redisplayed,
        ///         the display callback for the window is called.  Before the callback, the
        ///         current window is set to the window needing to be redisplayed and (if no
        ///         overlay display callback is registered) the layer in use is set to the normal
        ///         plane.  The display callback is called with no parameters.  The entire normal
        ///         plane region should be redisplayed in response to the callback (this includes
        ///         ancillary buffers if your program depends on their state).
        ///     </para>
        ///     <para>
        ///         GLUT determines when the display callback should be triggered based on the
        ///         window's redisplay state.  The redisplay state for a window can be either set
        ///         explicitly by calling <see cref="glutPostRedisplay" /> or implicitly as the
        ///         result of window damage reported by the window system.  Multiple posted
        ///         redisplays for a window are coalesced by GLUT to minimize the number of
        ///         display callbacks called.
        ///     </para>
        ///     <para>
        ///         When an overlay is established for a window, but there is no overlay display
        ///         callback registered, the display callback is used for redisplaying both the
        ///         overlay and normal plane (that is, it will be called if either the redisplay
        ///         state or overlay redisplay state is set).  In this case, the layer in use is
        ///         not implicitly changed on entry to the display callback.
        ///     </para>
        ///     <para>
        ///         See <see cref="glutOverlayDisplayFunc" /> to understand how distinct callbacks
        ///         for the overlay and normal plane of a window may be established.
        ///     </para>
        ///     <para>
        ///         When a window is created, no display callback exists for the window.  It is
        ///         the responsibility of the programmer to install a display callback for the
        ///         window before the window is shown.  A display callback must be registered for
        ///         any window that is shown.  If a window becomes displayed without a display
        ///         callback being registered, a fatal error occurs.  Passing <c>null</c> to
        ///         <b>glutDisplayFunc</b> is illegal as of GLUT 3.0; there is no way to
        ///         "deregister" a display callback (though another callback routine can always be
        ///         registered).
        ///     </para>
        ///     <para>
        ///         Upon return from the display callback, the normal damaged state of the window
        ///         (returned by calling <c>Glut.glutLayerGet(Glut.GLUT_NORMAL_DAMAGED)</c> is
        ///         cleared.  If there is no overlay display callback registered the overlay
        ///         damaged state of the window (returned by calling
        ///         <c>Glut.glutLayerGet(Glut.GLUT_OVERLAY_DAMAGED)</c> is also cleared.
        ///     </para>
        /// </remarks>
        /// <seealso cref="DisplayCallback" />
        /// <seealso cref="glutLayerGet" />
        /// <seealso cref="glutOverlayDisplayFunc" />
        // GLUTAPI void APIENTRY glutDisplayFunc(void (GLUTCALLBACK *func)(void));
        public static void glutDisplayFunc([In] DisplayCallback func) {
            displayCallback = func;
            __glutDisplayFunc(displayCallback);
        }
        #endregion glutDisplayFunc([In] DisplayCallback func)

        #region glutReshapeFunc([In] ReshapeCallback func)
        /// <summary>
        ///     Sets the reshape callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new reshape callback function.  See <see cref="ReshapeCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutReshapeFunc</b> sets the reshape callback for the current window.  The
        ///         reshape callback is triggered when a window is reshaped.  A reshape callback
        ///         is also triggered immediately before a window's first display callback after a
        ///         window is created or whenever an overlay for the window is established.  The
        ///         <i>width</i> and <i>height</i> parameters of the callback specify the new
        ///         window size in pixels.  Before the callback, the current window is set to the
        ///         window that has been reshaped.
        ///     </para>
        ///     <para>
        ///         If a reshape callback is not registered for a window or <c>null</c> is passed
        ///         to <b>glutReshapeFunc</b> (to deregister a previously registered callback),
        ///         the default reshape callback is used.  This default callback will simply call
        ///         <c>Gl.glViewport(0, 0, width, height)</c> on the normal plane (and on the
        ///         overlay if one exists).
        ///     </para>
        ///     <para>
        ///         If an overlay is established for the window, a single reshape callback is
        ///         generated.  It is the callback's responsibility to update both the normal
        ///         plane and overlay for the window (changing the layer in use as necessary).
        ///     </para>
        ///     <para>
        ///         When a top-level window is reshaped, subwindows are not reshaped.  It is up to
        ///         the GLUT program to manage the size and positions of subwindows within a
        ///         top-level window.  Still, reshape callbacks will be triggered for subwindows
        ///         when their size is changed using <see cref="glutReshapeWindow" />.
        ///     </para>
        /// </remarks>
        /// <seealso cref="ReshapeCallback" />
        /// <seealso cref="glutReshapeWindow" />
        // GLUTAPI void APIENTRY glutReshapeFunc(void (GLUTCALLBACK *func)(int width, int height));
        public static void glutReshapeFunc([In] ReshapeCallback func) {
            reshapeCallback = func;
            __glutReshapeFunc(reshapeCallback);
        }
        #endregion glutReshapeFunc([In] ReshapeCallback func)

        #region glutKeyboardFunc([In] KeyboardCallback func)
        /// <summary>
        ///     Sets the keyboard callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new keyboard callback function.  See <see cref="KeyboardCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutKeyboardFunc</b> sets the keyboard callback for the current window.
        ///         When a user types into the window, each key press generating an ASCII
        ///         character will generate a keyboard callback.  The <i>key</i> callback
        ///         parameter is the generated ASCII character.  The state of modifier keys such
        ///         as Shift cannot be determined directly; their only effect will be on the
        ///         returned ASCII data.  The <i>x</i> and <i>y</i> callback parameters indicate
        ///         the mouse location in window relative coordinates when the key was pressed.
        ///         When a new window is created, no keyboard callback is initially registered,
        ///         and ASCII key strokes in the window are ignored.  Passing <c>null</c> to
        ///         <b>glutKeyboardFunc</b> disables the generation of keyboard callbacks.
        ///     </para>
        ///     <para>
        ///         During a keyboard callback, <see cref="glutGetModifiers" /> may be called to
        ///         determine the state of modifier keys when the keystroke generating the
        ///         callback occurred.
        ///     </para>
        ///     <para>
        ///         Also, see <see cref="glutSpecialFunc" /> for a means to detect non-ASCII key
        ///         strokes.
        ///     </para>
        /// </remarks>
        /// <seealso cref="KeyboardCallback" />
        /// <seealso cref="glutGetModifiers" />
        /// <seealso cref="glutSpecialFunc" />
        // GLUTAPI void APIENTRY glutKeyboardFunc(void (GLUTCALLBACK *func)(unsigned char key, int x, int y));
        public static void glutKeyboardFunc([In] KeyboardCallback func) {
            keyboardCallback = func;
            __glutKeyboardFunc(keyboardCallback);
        }
        #endregion glutKeyboardFunc([In] KeyboardCallback func)

        #region glutMouseFunc([In] MouseCallback func)
        /// <summary>
        ///     Sets the mouse callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new mouse callback function.  See <see cref="MouseCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutMouseFunc</b> sets the mouse callback for the current window.  When a
        ///         user presses and releases mouse buttons in the window, each press and each
        ///         release generates a mouse callback.  The <i>button</i> parameter is one of
        ///         <see cref="GLUT_LEFT_BUTTON" />, <see cref="GLUT_MIDDLE_BUTTON" />, or
        ///         <see cref="GLUT_RIGHT_BUTTON" />.  For systems with only two mouse buttons, it
        ///         may not be possible to generate the <i>GLUT_MIDDLE_BUTTON</i> callback.  For
        ///         systems with a single mouse button, it may be possible to generate only a
        ///         <i>GLUT_LEFT_BUTTON</i> callback.  The <i>state</i> parameter is either
        ///         <see cref="GLUT_UP" /> or <see cref="GLUT_DOWN" /> indicating whether the
        ///         callback was due to a release or press respectively.  The <i>x</i> and
        ///         <i>y</i> callback parameters indicate the window relative coordinates when the
        ///         mouse button state changed.  If a <i>GLUT_DOWN</i> callback for a specific
        ///         button is triggered, the program can assume a <i>GLUT_UP</i> callback for the
        ///         same button will be generated (assuming the window still has a mouse callback
        ///         registered) when the mouse button is released even if the mouse has moved
        ///         outside the window.
        ///     </para>
        ///     <para>
        ///         If a menu is attached to a button for a window, mouse callbacks will not be
        ///         generated for that button.
        ///     </para>
        ///     <para>
        ///         During a mouse callback, <see cref="glutGetModifiers" /> may be called to
        ///         determine the state of modifier keys when the mouse event generating the
        ///         callback occurred.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutMouseFunc</b> disables the generation of mouse
        ///         callbacks.
        ///     </para>
        /// </remarks>
        /// <seealso cref="MouseCallback" />
        /// <seealso cref="glutGetModifiers" />
        // GLUTAPI void APIENTRY glutMouseFunc(void (GLUTCALLBACK *func)(int button, int state, int x, int y));
        public static void glutMouseFunc([In] MouseCallback func) {
            mouseCallback = func;
            __glutMouseFunc(mouseCallback);
        }
        #endregion glutMouseFunc([In] MouseCallback func)

        #region glutMotionFunc([In] MotionCallback func)
        /// <summary>
        ///     Sets the motion callbacks for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new motion callback function.  See <see cref="MotionCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutMotionFunc</b> sets the motion callback for the current window.  The
        ///         motion callback for a window is called when the mouse moves within the window
        ///         while one or more mouse buttons are pressed.
        ///     </para>
        ///     <para>
        ///         The <i>x</i> and <i>y</i> callback parameters indicate the mouse location in
        ///         window relative coordinates.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutMotionFunc</b> disables the generation of the
        ///         motion callback.
        ///     </para>
        /// </remarks>
        /// <seealso cref="MotionCallback" />
        /// <seealso cref="glutPassiveMotionFunc" />
        // GLUTAPI void APIENTRY glutMotionFunc(void (GLUTCALLBACK *func)(int x, int y));
        public static void glutMotionFunc([In] MotionCallback func) {
            motionCallback = func;
            __glutMotionFunc(motionCallback);
        }
        #endregion glutMotionFunc([In] MotionCallback func)

        #region glutPassiveMotionFunc([In] PassiveMotionCallback func)
        /// <summary>
        ///     Sets the passive motion callbacks for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new passive motion callback function.  See
        ///     <see cref="PassiveMotionCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutPassiveMotionFunc</b> sets the passive motion callback for the current
        ///         window.  The passive motion callback for a window is called when the mouse
        ///         moves within the window while no mouse buttons are pressed.
        ///     </para>
        ///     <para>
        ///         The <i>x</i> and <i>y</i> callback parameters indicate the mouse location in
        ///         window relative coordinates.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutPassiveMotionFunc</b> disables the generation of
        ///         the passive motion callback.
        ///     </para>
        /// </remarks>
        /// <seealso cref="PassiveMotionCallback" />
        /// <seealso cref="glutMotionFunc" />
        // GLUTAPI void APIENTRY glutPassiveMotionFunc(void (GLUTCALLBACK *func)(int x, int y));
        public static void glutPassiveMotionFunc([In] PassiveMotionCallback func) {
            passiveMotionCallback = func;
            __glutPassiveMotionFunc(passiveMotionCallback);
        }
        #endregion glutPassiveMotionFunc([In] PassiveMotionCallback func)

        #region glutEntryFunc([In] EntryCallback func)
        /// <summary>
        ///     Sets the mouse enter/leave callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new entry callback function.  See <see cref="EntryCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutEntryFunc</b> sets the mouse enter/leave callback for the current
        ///         window.  The state callback parameter is either <see cref="GLUT_LEFT" /> or
        ///         <see cref="GLUT_ENTERED" /> depending on if the mouse pointer has last left or
        ///         entered the window.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutEntryFunc</b> disables the generation of the
        ///         mouse enter/leave callback.
        ///     </para>
        ///     <para>
        ///         Some window systems may not generate accurate enter/leave callbacks.
        ///     </para>
        /// </remarks>
        /// <seealso cref="EntryCallback" />
        // GLUTAPI void APIENTRY glutEntryFunc(void (GLUTCALLBACK *func)(int state));
        public static void glutEntryFunc([In] EntryCallback func) {
            entryCallback = func;
            __glutEntryFunc(entryCallback);
        }
        #endregion glutEntryFunc([In] EntryCallback func)

        #region glutVisibilityFunc([In] VisibilityCallback func)
        /// <summary>
        ///     Sets the visibility callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new visibility callback function.  See <see cref="VisibilityCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutVisibilityFunc</b> sets the visibility callback for the current window.
        ///         The visibility callback for a window is called when the visibility of a
        ///         window changes.  The state callback parameter is either
        ///         <see cref="GLUT_NOT_VISIBLE" /> or <see cref="GLUT_VISIBLE" /> depending on
        ///         the current visibility of the window.  <i>GLUT_VISIBLE</i> does not
        ///         distinguish a window being totally versus partially visible.
        ///         <i>GLUT_NOT_VISIBLE</i> means no part of the window is visible, i.e., until
        ///         the window's visibility changes, all further rendering to the window is
        ///         discarded.
        ///     </para>
        ///     <para>
        ///         GLUT considers a window visible if any pixel of the window is visible or any
        ///         pixel of any descendant window is visible on the screen.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutVisibilityFunc</b> disables the generation of
        ///         the visibility callback.
        ///     </para>
        ///     <para>
        ///         If the visibility callback for a window is disabled and later re-enabled, the
        ///         visibility status of the window is undefined; any change in window visibility
        ///         will be reported, that is if you disable a visibility callback and re-enable
        ///         the callback, you are guaranteed the next visibility change will be reported.
        ///     </para>
        /// </remarks>
        /// <seealso cref="VisibilityCallback" />
        // GLUTAPI void APIENTRY glutVisibilityFunc(void (GLUTCALLBACK *func)(int state));
        public static void glutVisibilityFunc([In] VisibilityCallback func) {
            visibilityCallback = func;
            __glutVisibilityFunc(visibilityCallback);
        }
        #endregion glutVisibilityFunc([In] VisibilityCallback func)

        #region glutIdleFunc([In] IdleCallback func)
        /// <summary>
        ///     Sets the global idle callback.
        /// </summary>
        /// <param name="func">
        ///     The new idle callback function.  See <see cref="IdleCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutIdleFunc</b> sets the global idle callback to be func so a GLUT program
        ///         can perform background processing tasks or continuous animation when window
        ///         system events are not being received.  If enabled, the idle callback is
        ///         continuously called when events are not being received.  The callback routine
        ///         has no parameters.  The current window and current menu will not be changed
        ///         before the idle callback.  Programs with multiple windows and/or menus should
        ///         explicitly set the current window and/or current menu and not rely on its
        ///         current setting.
        ///     </para>
        ///     <para>
        ///         The amount of computation and rendering done in an idle callback should be
        ///         minimized to avoid affecting the program's interactive response.  In general,
        ///         not more than a single frame of rendering should be done in an idle callback.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutIdleFunc</b> disables the generation of the idle
        ///         callback.
        ///     </para>
        /// </remarks>
        /// <seealso cref="IdleCallback" />
        // GLUTAPI void APIENTRY glutIdleFunc(void (GLUTCALLBACK *func)(void));
        public static void glutIdleFunc([In] IdleCallback func) {
            idleCallback = func;
            __glutIdleFunc(idleCallback);
        }
        #endregion glutIdleFunc([In] IdleCallback func)

        #region glutTimerFunc(int msecs, [In] TimerCallback func, int val)
        /// <summary>
        ///     Registers a timer callback to be triggered in a specified number of milliseconds.
        /// </summary>
        /// <param name="msecs">
        ///     The number of milliseconds between calls to the timer callback.
        /// </param>
        /// <param name="func">
        ///     The new timer callback function.  See <see cref="TimerCallback" />.
        /// </param>
        /// <param name="val">
        ///     The value to be passed to the timer callback.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutTimerFunc</b> registers the timer callback <i>func</i> to be triggered
        ///         in at least <i>msecs</i> milliseconds.  The <i>val</i> parameter to the timer
        ///         callback will be the value of the <i>val</i> parameter to
        ///         <b>glutTimerFunc</b>.  Multiple timer callbacks at same or differing times may
        ///         be registered simultaneously.
        ///     </para>
        ///     <para>
        ///         The number of milliseconds is a lower bound on the time before the callback is
        ///         generated.  GLUT attempts to deliver the timer callback as soon as possible
        ///         after the expiration of the callback's time interval.
        ///     </para>
        ///     <para>
        ///         There is no support for canceling a registered callback.  Instead, ignore a
        ///         callback based on its <i>val</i> parameter when it is triggered.
        ///     </para>
        /// </remarks>
        /// <seealso cref="TimerCallback" />
        // GLUTAPI void APIENTRY glutTimerFunc(unsigned int millis, void (GLUTCALLBACK *func)(int value), int value);
        public static void glutTimerFunc(int msecs, [In] TimerCallback func, int val) {
            timerCallback = func;
            __glutTimerFunc(msecs, timerCallback, val);
        }
        #endregion glutTimerFunc(int msecs, [In] TimerCallback func, int val)

        #region glutMenuStateFunc([In] MenuStateCallback func)
        /// <summary>
        ///     A deprecated version of the <see cref="glutMenuStatusFunc" /> routine.
        /// </summary>
        /// <param name="func">
        ///     The new menu state callback function.  <see cref="MenuStateCallback" />.
        /// </param>
        /// <remarks>
        ///     The only difference is <b>glutMenuStateFunc</b> callback prototype does not
        ///     deliver the two additional <i>x</i> and <i>y</i> coordinates.
        /// </remarks>
        /// <seealso cref="MenuStateCallback" />
        /// <seealso cref="MenuStatusCallback" />
        /// <seealso cref="glutMenuStatusFunc" />
        // GLUTAPI void APIENTRY glutMenuStateFunc(void (GLUTCALLBACK *func)(int state));
        public static void glutMenuStateFunc([In] MenuStateCallback func) {
            menuStateCallback = func;
            __glutMenuStateFunc(menuStateCallback);
        }
        #endregion glutMenuStateFunc([In] MenuStateCallback func)

        #region glutSpecialFunc([In] SpecialCallback func)
        /// <summary>
        ///     Sets the special keyboard callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new special callback function.  See <see cref="SpecialCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutSpecialFunc</b> sets the special keyboard callback for the current
        ///         window.  The special keyboard callback is triggered when keyboard function or
        ///         directional keys are pressed.  The <i>key</i> callback parameter is a
        ///         GLUT_KEY_* constant for the special key pressed.  The <i>x</i> and <i>y</i>
        ///         callback parameters indicate the mouse in window relative coordinates when the
        ///         key was pressed.  When a new window is created, no special callback is
        ///         initially registered and special key strokes in the window are ignored.
        ///         Passing <c>null</c> to <b>glutSpecialFunc</b> disables the generation of
        ///         special callbacks.
        ///     </para>
        ///     <para>
        ///         During a special callback, <see cref="glutGetModifiers" /> may be called to
        ///         determine the state of modifier keys when the keystroke generating the
        ///         callback occurred.
        ///     </para>
        ///     <para>
        ///         An implementation should do its best to provide ways to generate all the
        ///         GLUT_KEY_* special keys.  The available GLUT_KEY_* values are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F1" /></term>
        ///                 <description>F1 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F2" /></term>
        ///                 <description>F2 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F3" /></term>
        ///                 <description>F3 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F4" /></term>
        ///                 <description>F4 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F5" /></term>
        ///                 <description>F5 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F6" /></term>
        ///                 <description>F6 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F7" /></term>
        ///                 <description>F7 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F8" /></term>
        ///                 <description>F8 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F9" /></term>
        ///                 <description>F9 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F10" /></term>
        ///                 <description>F10 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F11" /></term>
        ///                 <description>F11 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F12" /></term>
        ///                 <description>F12 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_LEFT" /></term>
        ///                 <description>Left directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_UP" /></term>
        ///                 <description>Up directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_RIGHT" /></term>
        ///                 <description>Right directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_DOWN" /></term>
        ///                 <description>Down directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_PAGE_UP" /></term>
        ///                 <description>Page up directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_PAGE_DOWN" /></term>
        ///                 <description>Page down directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_HOME" /></term>
        ///                 <description>Home directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_END" /></term>
        ///                 <description>End directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_INSERT" /></term>
        ///                 <description>Insert directional key.</description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         Note that the escape, backspace, and delete keys are generated as an ASCII
        ///         character.
        ///     </para>
        /// </remarks>
        /// <seealso cref="SpecialCallback" />
        /// <seealso cref="glutGetModifiers" />
        // GLUTAPI void APIENTRY glutSpecialFunc(void (GLUTCALLBACK *func)(int key, int x, int y));
        public static void glutSpecialFunc([In] SpecialCallback func) {
            specialCallback = func;
            __glutSpecialFunc(specialCallback);
        }
        #endregion glutSpecialFunc([In] SpecialCallback func)

        #region glutSpaceballMotionFunc([In] SpaceballMotionCallback func)
        /// <summary>
        ///     Sets the Spaceball motion callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new Spaceball motion callback function.  See
        ///     <see cref="SpaceballMotionCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutSpaceballMotionFunc</b> sets the Spaceball motion callback for the
        ///         current window.  The Spaceball motion callback for a window is called when the
        ///         window has Spaceball input focus (normally, when the mouse is in the window)
        ///         and the user generates Spaceball translations.  The <i>x</i>, <i>y</i>, and
        ///         <i>z</i> callback parameters indicate the translations along the X, Y, and Z
        ///         axes.  The callback parameters are normalized to be within the range of -1000
        ///         to 1000 inclusive.
        ///     </para>
        ///     <para>
        ///         Registering a Spaceball motion callback when a Spaceball device is not
        ///         available has no effect and is not an error.  In this case, no Spaceball
        ///         motion callbacks will be generated.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutSpaceballMotionFunc</b> disables the generation
        ///         of Spaceball motion callbacks.  When a new window is created, no Spaceball
        ///         motion callback is initially registered.
        ///     </para>
        /// </remarks>
        /// <seealso cref="SpaceballMotionCallback" />
        // GLUTAPI void APIENTRY glutSpaceballMotionFunc(void (GLUTCALLBACK *func)(int x, int y, int z));
        public static void glutSpaceballMotionFunc([In] SpaceballMotionCallback func) {
            spaceballMotionCallback = func;
            __glutSpaceballMotionFunc(spaceballMotionCallback);
        }
        #endregion glutSpaceballMotionFunc([In] SpaceballMotionCallback func)

        #region glutSpaceballRotateFunc([In] SpaceballRotateCallback func)
        /// <summary>
        ///     Sets the Spaceball rotation callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new Spaceball rotate callback function.  See
        ///     <see cref="SpaceballRotateCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutSpaceballRotateFunc</b> sets the Spaceball rotate callback for the
        ///         current window.  The Spaceball rotate callback for a window is called when the
        ///         window has Spaceball input focus (normally, when the mouse is in the window)
        ///         and the user generates Spaceball rotations.  The <i>x</i>, <i>y</i>, and
        ///         <i>z</i> callback parameters indicate the rotation along the X, Y, and Z
        ///         axes.  The callback parameters are normalized to be within the range of -1800
        ///         to 1800 inclusive.
        ///     </para>
        ///     <para>
        ///         Registering a Spaceball rotate callback when a Spaceball device is not
        ///         available is ineffectual and not an error.  In this case, no Spaceball rotate
        ///         callbacks will be generated.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutSpaceballRotateFunc</b> disables the generation
        ///         of Spaceball rotate callbacks.  When a new window is created, no Spaceball
        ///         rotate callback is initially registered.
        ///     </para>
        /// </remarks>
        /// <seealso cref="SpaceballRotateCallback" />
        // GLUTAPI void APIENTRY glutSpaceballRotateFunc(void (GLUTCALLBACK *func)(int x, int y, int z));
        public static void glutSpaceballRotateFunc([In] SpaceballRotateCallback func) {
            spaceballRotateCallback = func;
            __glutSpaceballRotateFunc(spaceballRotateCallback);
        }
        #endregion glutSpaceballRotateFunc([In] SpaceballRotateCallback func)

        #region glutSpaceballButtonFunc([In] SpaceballButtonCallback func)
        /// <summary>
        ///     Sets the Spaceball button callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new Spaceball button callback function.  See
        ///     <see cref="SpaceballButtonCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutSpaceballButtonFunc</b> sets the Spaceball button callback for the
        ///         current window.  The Spaceball button callback for a window is called when the
        ///         window has Spaceball input focus (normally, when the mouse is in the window)
        ///         and the user generates Spaceball button presses.  The <i>button</i> parameter
        ///         will be the button number (starting at one).  The number of available
        ///         Spaceball buttons can be determined with
        ///         <c>glutDeviceGet(GLUT_NUM_SPACEBALL_BUTTONS)</c>.  The <i>state</i> is either
        ///         <see cref="GLUT_UP" /> or <see cref="GLUT_DOWN" /> indicating whether the
        ///         callback was due to a release or press respectively.
        ///     </para>
        ///     <para>
        ///         Registering a Spaceball button callback when a Spaceball device is not
        ///         available is ineffectual and not an error.  In this case, no Spaceball button
        ///         callbacks will be generated.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutSpaceballButtonFunc</b> disables the generation
        ///         of Spaceball button callbacks.  When a new window is created, no Spaceball
        ///         button callback is initially registered.
        ///     </para>
        /// </remarks>
        /// <seealso cref="SpaceballButtonCallback" />
        /// <seealso cref="glutDeviceGet" />
        // GLUTAPI void APIENTRY glutSpaceballButtonFunc(void (GLUTCALLBACK *func)(int button, int state));
        public static void glutSpaceballButtonFunc([In] SpaceballButtonCallback func) {
            spaceballButtonCallback = func;
            __glutSpaceballButtonFunc(spaceballButtonCallback);
        }
        #endregion glutSpaceballButtonFunc([In] SpaceballButtonCallback func)

        #region glutButtonBoxFunc([In] ButtonBoxCallback func)
        /// <summary>
        ///     Sets the dial and button box button callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new button box callback function.  See <see cref="ButtonBoxCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutButtonBoxFunc</b> sets the dial and button box button callback for the
        ///         current window.  The dial and button box button callback for a window is
        ///         called when the window has dial and button box input focus (normally, when the
        ///         mouse is in the window) and the user generates dial and button box button
        ///         presses.  The <i>button</i> parameter will be the button number (starting at
        ///         one).  The number of available dial and button box buttons can be determined
        ///         with <c>Glut.glutDeviceGet(Glut.GLUT_NUM_BUTTON_BOX_BUTTONS)</c>.  The
        ///         <i>state</i> is either <see cref="GLUT_UP" /> or <see cref="GLUT_DOWN" />
        ///         indicating whether the callback was due to a release or press respectively.
        ///     </para>
        ///     <para>
        ///         Registering a dial and button box button callback when a dial and button box
        ///         device is not available is ineffectual and not an error.  In this case, no
        ///         dial and button box button callbacks will be generated.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutButtonBoxFunc</b> disables the generation of
        ///         dial and button box button callbacks.  When a new window is created, no dial
        ///         and button box button callback is initially registered.
        ///     </para>
        /// </remarks>
        /// <seealso cref="ButtonBoxCallback" />
        /// <seealso cref="glutDeviceGet" />
        // GLUTAPI void APIENTRY glutButtonBoxFunc(void (GLUTCALLBACK *func)(int button, int state));
        public static void glutButtonBoxFunc([In] ButtonBoxCallback func) {
            buttonBoxCallback = func;
            __glutButtonBoxFunc(buttonBoxCallback);
        }
        #endregion glutButtonBoxFunc([In] ButtonBoxCallback func)

        #region glutDialsFunc([In] DialsCallback func)
        /// <summary>
        ///     Sets the dial and button box dials callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new dials callback function.  See <see cref="DialsCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutDialsFunc</b> sets the dial and button box dials callback for the
        ///         current window.  The dial and button box dials callback for a window is called
        ///         when the window has dial and button box input focus (normally, when the mouse
        ///         is in the window) and the user generates dial and button box dial changes.
        ///         The <i>dial</i> parameter will be the dial number (starting at one).  The
        ///         number of available dial and button box dials can be determined with
        ///         <c>Glut.glutDeviceGet(Glut.GLUT_NUM_DIALS)</c>.  The <i>val</i> measures the
        ///         absolute rotation in degrees.  Dial values do not "roll over" with each
        ///         complete rotation but continue to accumulate degrees (until the <c>int</c>
        ///         dial value overflows).
        ///     </para>
        ///     <para>
        ///         Registering a dial and button box dials callback when a dial and button box
        ///         device is not available is ineffectual and not an error.  In this case, no
        ///         dial and button box dials callbacks will be generated.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutDialsFunc</b> disables the generation of dial
        ///         and button box dials callbacks.  When a new window is created, no dial and
        ///         button box dials callback is initially registered.
        ///     </para>
        /// </remarks>
        /// <seealso cref="DialsCallback" />
        /// <seealso cref="glutDeviceGet" />
        // GLUTAPI void APIENTRY glutDialsFunc(void (GLUTCALLBACK *func)(int dial, int value));
        public static void glutDialsFunc([In] DialsCallback func) {
            dialsCallback = func;
            __glutDialsFunc(dialsCallback);
        }
        #endregion glutDialsFunc([In] DialsCallback func)

        #region glutTabletMotionFunc([In] TabletMotionCallback func)
        /// <summary>
        ///     Sets the tablet motion callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new tablet motion callback function.  See
        ///     <see cref="TabletMotionCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutTabletMotionFunc</b> sets the tablet motion callback for the current
        ///         window.  The tablet motion callback for a window is called when the window has
        ///         tablet input focus (normally, when the mouse is in the window) and the user
        ///         generates tablet motion.  The <i>x</i> and <i>y</i> callback parameters
        ///         indicate the absolute position of the tablet "puck" on the tablet.  The
        ///         callback parameters are normalized to be within the range of 0 to 2000
        ///         inclusive.
        ///     </para>
        ///     <para>
        ///         Registering a tablet motion callback when a tablet device is not available is
        ///         ineffectual and not an error.  In this case, no tablet motion callbacks will
        ///         be generated.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutTabletMotionFunc</b> disables the generation of
        ///         tablet motion callbacks.  When a new window is created, no tablet motion
        ///         callback is initially registered.
        ///     </para>
        /// </remarks>
        /// <seealso cref="TabletMotionCallback" />
        // GLUTAPI void APIENTRY glutTabletMotionFunc(void (GLUTCALLBACK *func)(int x, int y));
        public static void glutTabletMotionFunc([In] TabletMotionCallback func) {
            tabletMotionCallback = func;
            __glutTabletMotionFunc(tabletMotionCallback);
        }
        #endregion glutTabletMotionFunc([In] TabletMotionCallback func)

        #region glutTabletButtonFunc([In] TabletButtonCallback func)
        /// <summary>
        ///     Sets the tablet button callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new tablet button callback function.  See
        ///     <see cref="TabletButtonCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutTabletButtonFunc</b> sets the tablet button callback for the current
        ///         window.  The tablet button callback for a window is called when the window has
        ///         tablet input focus (normally, when the mouse is in the window) and the user
        ///         generates tablet button presses.  The <i>button</i> parameter will be the
        ///         button number (starting at one).  The number of available tablet buttons can
        ///         be determined with <c>Glut.glutDeviceGet(Glut.GLUT_NUM_TABLET_BUTTONS)</c>.
        ///         The <i>state</i> is either <see cref="GLUT_UP" /> or <see cref="GLUT_DOWN" />
        ///         indicating whether the callback was due to a release or press respectively.
        ///         The <i>x</i> and <i>y</i> callback parameters indicate the window relative
        ///         coordinates when the tablet button state changed.
        ///     </para>
        ///     <para>
        ///         Registering a tablet button callback when a tablet device is not available is
        ///         ineffectual and not an error.  In this case, no tablet button callbacks will
        ///         be generated.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutTabletButtonFunc</b> disables the generation of
        ///         tablet button callbacks.  When a new window is created, no tablet button
        ///         callback is initially registered.
        ///     </para>
        /// </remarks>
        /// <seealso cref="TabletButtonCallback" />
        /// <seealso cref="glutDeviceGet" />
        // GLUTAPI void APIENTRY glutTabletButtonFunc(void (GLUTCALLBACK *func)(int button, int state, int x, int y));
        public static void glutTabletButtonFunc([In] TabletButtonCallback func) {
            tabletButtonCallback = func;
            __glutTabletButtonFunc(tabletButtonCallback);
        }
        #endregion glutTabletButtonFunc([In] TabletButtonCallback func)

        #region glutMenuStatusFunc([In] MenuStatusCallback func)
        /// <summary>
        ///     Sets the global menu status callback.
        /// </summary>
        /// <param name="func">
        ///     The new menu status button callback function.  See
        ///     <see cref="MenuStatusCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutMenuStatusFunc</b> sets the global menu status callback so a GLUT
        ///         program can determine when a menu is in use or not.  When a menu status
        ///         callback is registered, it will be called with the value
        ///         <see cref="GLUT_MENU_IN_USE" /> for its <i>val</i> parameter when pop-up menus
        ///         are in use by the user; and the callback will be called with the value
        ///         <see cref="GLUT_MENU_NOT_IN_USE" /> for its <i>status</i> parameter when
        ///         pop-up menus are no longer in use.  The <i>x</i> and <i>y</i> parameters
        ///         indicate the location in window coordinates of the button press that caused
        ///         the menu to go into use, or the location where the menu was released (may be
        ///         outside the window).  The <i>func</i> parameter names the callback function.
        ///         Other callbacks continue to operate (except mouse motion callbacks) when
        ///         pop-up menus are in use so the menu status callback allows a program to
        ///         suspend animation or other tasks when menus are in use.  The cascading and
        ///         unmapping of sub-menus from an initial pop-up menu does not generate menu
        ///         status callbacks.  There is a single menu status callback for GLUT.
        ///     </para>
        ///     <para>
        ///         When the menu status callback is called, the current menu will be set to the
        ///         initial pop-up menu in both the <i>GLUT_MENU_IN_USE</i> and
        ///         <i>GLUT_MENU_NOT_IN_USE</i> cases.  The current window will be set to the
        ///         window from which the initial menu was popped up from, also in both cases.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutMenuStatusFunc</b> disables the generation of
        ///         the menu status callback.
        ///     </para>
        ///     <para>
        ///         <see cref="glutMenuStateFunc" /> is a deprecated version of the
        ///         <b>glutMenuStatusFunc</b> routine.  The only difference is
        ///         <b>glutMenuStateFunc</b> callback prototype does not deliver the two
        ///         additional <i>x</i> and <i>y</i> coordinates.
        ///     </para>
        /// </remarks>
        /// <seealso cref="MenuStateCallback" />
        /// <seealso cref="MenuStatusCallback" />
        /// <seealso cref="glutMenuStateFunc" />
        // GLUTAPI void APIENTRY glutMenuStatusFunc(void (GLUTCALLBACK *func)(int status, int x, int y));
        public static void glutMenuStatusFunc([In] MenuStatusCallback func) {
            menuStatusCallback = func;
            __glutMenuStatusFunc(menuStatusCallback);
        }
        #endregion glutMenuStatusFunc([In] MenuStatusCallback func)

        #region glutOverlayDisplayFunc([In] OverlayDisplayCallback func)
        /// <summary>
        ///     Sets the overlay display callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new overlay display callback function.  See
        ///     <see cref="OverlayDisplayCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutDisplayFunc</b> sets the overlay display callback for the current
        ///         window.  The overlay display callback is functionally the same as the window's
        ///         display callback except that the overlay display callback is used to redisplay
        ///         the window's overlay.
        ///     </para>
        ///     <para>
        ///         When GLUT determines that the overlay display for the window needs to be
        ///         redisplayed, the overlay display callback for the window is called.  Before
        ///         the callback, the current window is set to the window needing to be
        ///         redisplayed and the layer in use is set to the overlay.  The overlay display
        ///         callback is called with no parameters.  The entire overlay region should be
        ///         redisplayed in response to the callback (this includes ancillary buffers if
        ///         your program depends on their state).
        ///     </para>
        ///     <para>
        ///         GLUT determines when the overlay display callback should be triggered based on
        ///         the window's overlay redisplay state.  The overlay redisplay state for a
        ///         window can be either set explicitly by calling
        ///         <see cref="glutPostOverlayRedisplay" /> or implicitly as the result of window
        ///         damage reported by the window system.  Multiple posted overlay redisplays for
        ///         a window are coalesced by GLUT to minimize the number of overlay display
        ///         callbacks called.
        ///     </para>
        ///     <para>
        ///         Upon return from the overlay display callback, the overlay damaged state of
        ///         the window (returned by calling
        ///         <c>Glut.glutLayerGet(Glut.GLUT_OVERLAY_DAMAMGED)</c> is cleared.
        ///     </para>
        ///     <para>
        ///         The overlay display callback can be deregistered by passing <c>null</c> to
        ///         <see cref="glutOverlayDisplayFunc" />.  The overlay display callback is
        ///         initially <c>null</c> when an overlay is established.  See
        ///         <see cref="glutDisplayFunc" /> to understand how the display callback alone is
        ///         used if an overlay display callback is not registered.
        ///     </para>
        /// </remarks>
        /// <seealso cref="DisplayCallback" />
        /// <seealso cref="OverlayDisplayCallback" />
        /// <seealso cref="glutDisplayFunc" />
        /// <seealso cref="glutPostOverlayRedisplay" />
        // GLUTAPI void APIENTRY glutOverlayDisplayFunc(void (GLUTCALLBACK *func)(void));
        public static void glutOverlayDisplayFunc([In] OverlayDisplayCallback func) {
            overlayDisplayCallback = func;
            __glutOverlayDisplayFunc(overlayDisplayCallback);
        }
        #endregion glutOverlayDisplayFunc([In] OverlayDisplayCallback func)

        #region glutWindowStatusFunc([In] WindowStatusCallback func)
        /// <summary>
        ///     Sets the window status callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new window status callback function.  See
        ///     <see cref="WindowStatusCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutWindowStatusFunc</b> sets the window status callback for the current
        ///         window.  The window status callback for a window is called when the window
        ///         status (visibility) of a window changes.  The state callback parameter is one
        ///         of <see cref="GLUT_HIDDEN" />, <see cref="GLUT_FULLY_RETAINED" />,
        ///         <see cref="GLUT_PARTIALLY_RETAINED" />, or <see cref="GLUT_FULLY_COVERED" />
        ///         depending on the current window status of the window.  <i>GLUT_HIDDEN</i>
        ///         means that the window is either not shown (often meaning that the window is
        ///         iconified).  <i>GLUT_FULLY_RETAINED</i> means that the window is fully
        ///         retained (no pixels belonging to the window are covered by other windows).
        ///         <i>GLUT_PARTIALLY_RETAINED</i> means that the window is partially retained
        ///         (some but not all pixels belonging to the window are covered by other
        ///         windows).  <i>GLUT_FULLY_COVERED</i> means the window is shown but no part of
        ///         the window is visible, i.e., until the window's status changes, all further
        ///         rendering to the window is discarded.
        ///     </para>
        ///     <para>
        ///         GLUT considers a window visible if any pixel of the window is visible or any
        ///         pixel of any descendant window is visible on the screen.
        ///     </para>
        ///     <para>
        ///         GLUT applications are encouraged to disable rendering and/or animation when
        ///         windows have a status of either <i>GLUT_HIDDEN</i> or
        ///         <i>GLUT_FULLY_COVERED</i>.
        ///     </para>
        ///     <para>
        ///         Passing <c>null</c> to <b>glutWindowStatusFunc</b> disables the generation of
        ///         the window status callback.
        ///     </para>
        ///     <para>
        ///         If the window status callback for a window is disabled and later re-enabled,
        ///         the window status of the window is undefined; any change in window window
        ///         status will be reported, that is if you disable a window status callback and
        ///         re-enable the callback, you are guaranteed the next window status change will
        ///         be reported.
        ///     </para>
        ///     <para>
        ///         Setting the window status callback for a window disables the visibility
        ///         callback set for the window (and vice versa).  The visibility callback is set
        ///         with <see cref="glutVisibilityFunc" />.  <b>glutVisibilityFunc</b> is
        ///         deprecated in favor of the more informative <b>glutWindowStatusFunc</b>.
        ///     </para>
        /// </remarks>
        /// <seealso cref="WindowStatusCallback" />
        /// <seealso cref="VisibilityCallback" />
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutPopWindow" />
        /// <seealso cref="glutVisibilityFunc" />
        // GLUTAPI void APIENTRY glutWindowStatusFunc(void (GLUTCALLBACK *func)(int state));
        public static void glutWindowStatusFunc([In] WindowStatusCallback func) {
            windowStatusCallback = func;
            __glutWindowStatusFunc(windowStatusCallback);
        }
        #endregion glutWindowStatusFunc([In] WindowStatusCallback func)

        #region glutKeyboardUpFunc([In] KeyboardUpCallback func)
        /// <summary>
        ///     Sets the keyboard up (key release) callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new keyboard up callback function.  See <see cref="KeyboardUpCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutKeyboardUpFunc</b> sets the keyboard up (key release) callback for the
        ///         current window.  When a user types into the window, each key release matching
        ///         an ASCII character will generate a keyboard up callback.  The <i>key</i>
        ///         callback parameter is the generated ASCII character.  The state of modifier
        ///         keys such as Shift cannot be determined directly; their only effect will be on
        ///         the returned ASCII data.  The <i>x</i> and <i>y</i> callback parameters
        ///         indicate the mouse location in window relative coordinates when the key was
        ///         pressed.  When a new window is created, no keyboard callback is initially
        ///         registered, and ASCII key strokes in the window are ignored.  Passing
        ///         <c>null</c> to <b>glutKeyboardUpFunc</b> disables the generation of
        ///         keyboard up callbacks.
        ///     </para>
        ///     <para>
        ///         During a keyboard up callback, <see cref="glutGetModifiers" /> may be called
        ///         to determine the state of modifier keys when the keystroke generating the
        ///         callback occurred.
        ///     </para>
        ///     <para>
        ///         To avoid the reporting of key release/press pairs due to auto repeat, use
        ///         <see cref="glutIgnoreKeyRepeat" /> to ignore auto repeated keystrokes.
        ///     </para>
        ///     <para>
        ///         There is no guarantee that the keyboard press callback will match the exact
        ///         ASCII character as the keyboard up callback.  For example, the key down may
        ///         be for a lowercase b, but the key release may report an uppercase B if the
        ///         shift state has changed.  The same applies to symbols and control characters.
        ///         The precise behavior is window system dependent.
        ///     </para>
        ///     <para>
        ///         Use <see cref="glutSpecialUpFunc" /> for a means to detect non-ASCII key
        ///         release.
        ///     </para>
        /// </remarks>
        /// <seealso cref="KeyboardUpCallback" />
        /// <seealso cref="glutButtonBoxFunc" />
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutGetModifiers" />
        /// <seealso cref="glutIgnoreKeyRepeat" />
        /// <seealso cref="glutKeyboardFunc" />
        /// <seealso cref="glutMouseFunc" />
        /// <seealso cref="glutSpaceballButtonFunc" />
        /// <seealso cref="glutSpecialFunc" />
        /// <seealso cref="glutSpecialUpFunc" />
        /// <seealso cref="glutTabletButtonFunc" />
        // GLUTAPI void APIENTRY glutKeyboardUpFunc(void (GLUTCALLBACK *func)(unsigned char key, int x, int y));
        public static void glutKeyboardUpFunc([In] KeyboardUpCallback func) {
            keyboardUpCallback = func;
            __glutKeyboardUpFunc(keyboardUpCallback);
        }
        #endregion glutKeyboardUpFunc([In] KeyboardUpCallback func)

        #region glutSpecialUpFunc([In] SpecialUpCallback func)
        /// <summary>
        ///     Sets the special keyboard up (key release) callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new special keyboard up callback function.
        ///     <see cref="SpecialUpCallback" />.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutSpecialUpFunc</b> sets the special keyboard up (key release) callback
        ///         for the current window.  The special keyboard up callback is triggered when
        ///         keyboard function or directional keys are released.  The <i>key</i> callback
        ///         parameter is a GLUT_KEY_* constant for the special key pressed.  The <i>x</i>
        ///         and <i>y</i> callback parameters indicate the mouse in window relative
        ///         coordinates when the key was pressed.  When a new window is created, no
        ///         special up callback is initially registered and special key releases in the
        ///         window are ignored.  Passing <c>null</c> to <b>glutSpecialUpFunc</b> disables
        ///         the generation of special up callbacks.
        ///     </para>
        ///     <para>
        ///         During a special up callback, <see cref="glutGetModifiers" /> may be called to
        ///         determine the state of modifier keys when the key release generating the
        ///         callback occurred.
        ///     </para>
        ///     <para>
        ///         To avoid the reporting of key release/press pairs due to auto repeat, use
        ///         <see cref="glutIgnoreKeyRepeat" /> to ignore auto repeated keystrokes.
        ///     </para>
        ///     <para>
        ///         An implementation should do its best to provide ways to generate all the
        ///         GLUT_KEY_* special keys.  The available GLUT_KEY_* values are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F1" /></term>
        ///                 <description>F1 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F2" /></term>
        ///                 <description>F2 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F3" /></term>
        ///                 <description>F3 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F4" /></term>
        ///                 <description>F4 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F5" /></term>
        ///                 <description>F5 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F6" /></term>
        ///                 <description>F6 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F7" /></term>
        ///                 <description>F7 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F8" /></term>
        ///                 <description>F8 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F9" /></term>
        ///                 <description>F9 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F10" /></term>
        ///                 <description>F10 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F11" /></term>
        ///                 <description>F11 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_F12" /></term>
        ///                 <description>F12 function key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_LEFT" /></term>
        ///                 <description>Left directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_UP" /></term>
        ///                 <description>Up directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_RIGHT" /></term>
        ///                 <description>Right directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_DOWN" /></term>
        ///                 <description>Down directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_PAGE_UP" /></term>
        ///                 <description>Page up directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_PAGE_DOWN" /></term>
        ///                 <description>Page down directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_HOME" /></term>
        ///                 <description>Home directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_END" /></term>
        ///                 <description>End directional key.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_INSERT" /></term>
        ///                 <description>Insert directional key.</description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         Note that the escape, backspace, and delete keys are generated as an ASCII
        ///         character.
        ///     </para>
        /// </remarks>
        /// <seealso cref="SpecialUpCallback" />
        /// <seealso cref="glutButtonBoxFunc" />
        /// <seealso cref="glutGetModifiers" />
        /// <seealso cref="glutIgnoreKeyRepeat" />
        /// <seealso cref="glutKeyboardFunc" />
        /// <seealso cref="glutKeyboardUpFunc" />
        /// <seealso cref="glutMouseFunc" />
        /// <seealso cref="glutSpaceballButtonFunc" />
        /// <seealso cref="glutSpecialFunc" />
        /// <seealso cref="glutTabletButtonFunc" />
        // GLUTAPI void APIENTRY glutSpecialUpFunc(void (GLUTCALLBACK *func)(int key, int x, int y));
        public static void glutSpecialUpFunc([In] SpecialUpCallback func) {
            specialUpCallback = func;
            __glutSpecialUpFunc(specialUpCallback);
        }
        #endregion glutSpecialUpFunc([In] SpecialUpCallback func)

        #region glutJoystickFunc([In] JoystickCallback func, int pollInterval)
        /// <summary>
        ///     Sets the joystick callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new joystick callback function.  See <see cref="JoystickCallback" />.
        /// </param>
        /// <param name="pollInterval">
        ///     Joystick polling interval in milliseconds.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutJoystickFunc</b> sets the joystick callback for the current window.
        ///     </para>
        ///     <para>
        ///         The joystick callback is called either due to polling of the joystick at the
        ///         uniform timer interval specified by <i>pollInterval</i> (in milliseconds) or
        ///         in response to calling <see cref="glutForceJoystickFunc" />.  If the
        ///         <i>pollInterval</i> is non-positive, no joystick polling is performed and the
        ///         GLUT application must frequently (usually from an idle callback) call
        ///         <b>glutForceJoystickFunc</b>.
        ///     </para>
        ///     <para>
        ///         The joystick buttons are reported by the callback's <i>buttonMask</i>
        ///         parameter.  The constants <see cref="GLUT_JOYSTICK_BUTTON_A" /> (0x1),
        ///         <see cref="GLUT_JOYSTICK_BUTTON_B" /> (0x2),
        ///         <see cref="GLUT_JOYSTICK_BUTTON_C" /> (0x4), and
        ///         <see cref="GLUT_JOYSTICK_BUTTON_D" /> (0x8) are provided for programming
        ///         convience.
        ///     </para>
        ///     <para>
        ///         The <i>x</i>, <i>y</i>, and <i>z</i> callback parameters report the X, Y, and
        ///         Z axes of the joystick.  The joystick is centered at (0, 0, 0).  X, Y, and Z
        ///         are scaled to range between -1000 and 1000.  Moving the joystick left reports
        ///         negative X; right reports positive X.  Pulling the stick towards you reports
        ///         negative Y; push the stick away from you reports positive Y.  If the joystick
        ///         has a third axis (rudder or up/down), down reports negative Z; up reports
        ///         positive Z.
        ///     </para>
        ///     <para>
        ///         Passing a <c>null</c> to <b>glutJoystickFunc</b> disables the generation of
        ///         joystick callbacks.  Without a joystick callback registered,
        ///         <b>glutForceJoystickFunc</b> does nothing.
        ///     </para>
        ///     <para>
        ///         When a new window is created, no joystick callback is initially registered.
        ///     </para>
        ///     <para>
        ///         <b>LIMITATIONS</b>
        ///     </para>
        ///     <para>
        ///         The GLUT joystick callback only reports the first 3 axes and 32 buttons.
        ///         GLUT supports only a single joystick.
        ///     </para>
        ///     <para>
        ///         <b>X IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         The GLUT 3.7 implementation of GLUT for X11 supports the joystick API, but not
        ///         joystick input.  A future implementation of GLUT for X11 may add joystick
        ///         support.
        ///     </para>
        ///     <para>
        ///         <b>WIN32 IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         The GLUT 3.7 implementation of GLUT for Win32 supports the joystick API and
        ///         joystick input, but does so through the dated <c>joySetCapture</c> and
        ///         <c>joyGetPosEx</c> Win32 Multimedia API.  The GLUT 3.7 joystick support for
        ///         Win32 has all the limitations of the Win32 Multimedia API joystick support.
        ///         A future implementation of GLUT for Win32 may use DirectInput.
        ///     </para>
        ///     <para>
        ///         <b>GLUT IMPLEMENTATION NOTES FOR NON-ANALOG JOYSTICKS</b>
        ///     </para>
        ///     <para>
        ///         If the connected joystick does not return (x, y, z) as a continuous range (for
        ///         example, an 8 position Atari 2600 joystick), the implementation should report
        ///         the most extreme (x, y, z) location.  That is, if a 2D joystick is pushed to
        ///         the upper left, report (-1000, 1000, 0).
        ///     </para>
        /// </remarks>
        /// <seealso cref="JoystickCallback" />
        /// <seealso cref="glutButtonBoxFunc" />
        /// <seealso cref="glutDeviceGet" />
        /// <seealso cref="glutForceJoystickFunc" />
        /// <seealso cref="glutMotionFunc" />
        /// <seealso cref="glutMouseFunc" />
        /// <seealso cref="glutSpaceballButtonFunc" />
        /// <seealso cref="glutSpaceballMotionFunc" />
        /// <seealso cref="glutTabletButtonFunc" />
        // GLUTAPI void APIENTRY glutJoystickFunc(void (GLUTCALLBACK *func)(unsigned int buttonMask, int x, int y, int z), int pollInterval);
        public static void glutJoystickFunc([In] JoystickCallback func, int pollInterval) {
            joystickCallback = func;
            __glutJoystickFunc(joystickCallback, pollInterval);
        }
        #endregion glutJoystickFunc([In] JoystickCallback func, int pollInterval)
        #endregion Callback Sub-API

        #region Color Index Sub-API
        #region glutSetColor(int cell, float red, float green, float blue)
        /// <summary>
        ///     Sets the color of a colormap entry in the layer of use for the current window.
        /// </summary>
        /// <param name="cell">
        ///     Color cell index (starting at zero).
        /// </param>
        /// <param name="red">
        ///     Red intensity (clamped between 0.0 and 1.0 inclusive).
        /// </param>
        /// <param name="green">
        ///     Green intensity (clamped between 0.0 and 1.0 inclusive).
        /// </param>
        /// <param name="blue">
        ///     Blue intensity (clamped between 0.0 and 1.0 inclusive).
        /// </param>
        /// <remarks>
        ///     Sets the <i>cell</i> color index colormap entry of the current window's
        ///     logical colormap for the layer in use with the color specified by <i>red</i>,
        ///     <i>green</i>, and <i>blue</i>.  The layer in use of the current window should
        ///     be a color index window.  <i>cell</i> should be zero or greater and less than
        ///     the total number of colormap entries for the window.  If the layer in use's
        ///     colormap was copied by reference, a <b>glutSetColor</b> call will force the
        ///     duplication of the colormap.  Do not attempt to set the color of an overlay's
        ///     transparent index.
        /// </remarks>
        /// <seealso cref="glutCopyColormap" />
        /// <seealso cref="glutGetColor" />
        /// <seealso cref="glutInitDisplayMode" />
        // GLUTAPI void APIENTRY glutSetColor(int cell, GLfloat red, GLfloat green, GLfloat blue);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSetColor(int cell, float red, float green, float blue);
        #endregion glutSetColor(int cell, float red, float green, float blue)

        #region float glutGetColor(int cell, int component)
        /// <summary>
        ///     Retrieves a red, green, or blue component for a given color index colormap entry
        ///     for the layer in use's logical colormap for the current window.
        /// </summary>
        /// <param name="cell">
        ///     Color cell index (starting at zero).
        /// </param>
        /// <param name="component">
        ///     One of <see cref="GLUT_RED" />, <see cref="GLUT_GREEN" />, or
        ///     <see cref="GLUT_BLUE"/>.
        /// </param>
        /// <returns>
        ///     For valid color indices, the value returned is a floating point value between
        ///     0.0 and 1.0 inclusive.  <b>glutGetColor</b> will return -1.0 if the color
        ///     index specified is an overlay's transparent index, less than zero, or greater
        ///     or equal to the value returned by
        ///     <c>Glut.glutGet(Glut.GLUT_WINDOW_COLORMAP_SIZE)</c>, that is if the color
        ///     index is transparent or outside the valid range of color indices.
        /// </returns>
        /// <remarks>
        ///     <b>glutGetColor</b> retrieves a red, green, or blue component for a given
        ///     color index colormap entry for the current window's logical colormap.  The
        ///     current window should be a color index window.  <i>cell</i> should be zero or
        ///     greater and less than the total number of colormap entries for the window.
        /// </remarks>
        /// <seealso cref="glutCopyColormap" />
        /// <seealso cref="glutGet" />
        /// <seealso cref="glutSetColor" />
        // GLUTAPI GLfloat APIENTRY glutGetColor(int cell, int component);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern float glutGetColor(int cell, int component);
        #endregion float glutGetColor(int cell, int component)

        #region glutCopyColormap(int win)
        /// <summary>
        ///     Copies the logical colormap for the layer in use from a specified window to the
        ///     current window.
        /// </summary>
        /// <param name="win">
        ///     The identifier of the window to copy the logical colormap from.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutCopyColormap</b> copies (lazily if possible to promote sharing) the
        ///         logical colormap from a specified window to the current window's layer in use.
        ///         The copy will be from the normal plane to the normal plane; or from the
        ///         overlay to the overlay (never across different layers).  Once a colormap has
        ///         been copied, avoid setting cells in the colormap with
        ///         <see cref="glutSetColor" /> since that will force an actual copy of the
        ///         colormap if it was previously copied by reference.  <b>glutCopyColormap</b>
        ///         should only be called when both the current window and the <i>win</i> window
        ///         are color index windows.
        ///     </para>
        ///     <para>
        ///         <b>EXAMPLE</b>
        ///     </para>
        ///     <para>
        ///         Here is an example of how to create two color index GLUT windows with their
        ///         colormaps loaded identically and so that the windows are likely to share the
        ///         same colormap:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             int win1, win2;
        ///         
        ///             Glut.glutInitDisplayMode(Glut.GLUT_INDEX);
        ///             win1 = Glut.glutCreateWindow("First color index window");
        ///             Glut.glutSetColor(0, 0.0f, 0.0f, 0.0f); // black
        ///             Glut.glutSetColor(1, 0.5f, 0.5f, 0.5f); // gray
        ///             Glut.glutSetColor(2, 1.0f, 1.0f, 1.0f); // white
        ///             Glut.glutSetColor(3, 1.0f, 0.0f, 0.0f); // red
        ///
        ///             win2 = Glut.glutCreateWindow("Second color index window");
        ///             Glut.glutCopyColormap(win1);
        ///         </code>
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutGetColor" />
        /// <seealso cref="glutSetColor" />
        // GLUTAPI void APIENTRY glutCopyColormap(int win);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutCopyColormap(int win);
        #endregion glutCopyColormap(int win)
        #endregion Color Index Sub-API

        #region State Retrieval Sub-API
        #region int glutGet(int state)
        /// <summary>
        ///     Retrieves simple GLUT state represented by integers.
        /// </summary>
        /// <param name="state">
        ///     <para>
        ///         Name of state to retrieve.  Valid values are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_X" /></term>
        ///                 <description>
        ///                     X location in pixels (relative to the screen origin) of the
        ///                     current window.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_Y" /></term>
        ///                 <description>
        ///                     Y location in pixels (relative to the screen origin) of the
        ///                     current window.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_WIDTH" /></term>
        ///                 <description>
        ///                     Width in pixels of the current window.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_HEIGHT" /></term>
        ///                 <description>
        ///                     Height in pixels of the current window.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_BUFFER_SIZE" /></term>
        ///                 <description>
        ///                     Total number of bits for current window's color buffer.  For an
        ///                     RGBA window, this is the sum of
        ///                     <see cref="GLUT_WINDOW_RED_SIZE" />,
        ///                     <see cref="GLUT_WINDOW_GREEN_SIZE" />,
        ///                     <see cref="GLUT_WINDOW_BLUE_SIZE" />, and
        ///                     <see cref="GLUT_WINDOW_ALPHA_SIZE" />.  For color index windows,
        ///                     this is the size of the color indexes.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_STENCIL_SIZE" /></term>
        ///                 <description>
        ///                     Number of bits in the current window's stencil buffer.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_DEPTH_SIZE" /></term>
        ///                 <description>
        ///                     Number of bits in the current window's depth buffer.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_RED_SIZE" /></term>
        ///                 <description>
        ///                     Number of bits of red stored the current window's color buffer.
        ///                     Zero if the window is color index.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_GREEN_SIZE" /></term>
        ///                 <description>
        ///                     Number of bits of green stored the current window's color buffer.
        ///                     Zero if the window is color index.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_BLUE_SIZE" /></term>
        ///                 <description>
        ///                     Number of bits of blue stored the current window's color buffer.
        ///                     Zero if the window is color index.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_ALPHA_SIZE" /></term>
        ///                 <description>
        ///                     Number of bits of alpha stored the current window's color buffer.
        ///                     Zero if the window is color index.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_ACCUM_RED_SIZE" /></term>
        ///                 <description>
        ///                     Number of bits of red stored in the current window's accumulation
        ///                     buffer.  Zero if the window is color index.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_ACCUM_GREEN_SIZE" /></term>
        ///                 <description>
        ///                     Number of bits of green stored in the current window's
        ///                     accumulation buffer.  Zero if the window is color index.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_ACCUM_BLUE_SIZE" /></term>
        ///                 <description>
        ///                     Number of bits of blue stored in the current window's
        ///                     accumulation buffer.  Zero if the window is color index.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_ACCUM_ALPHA_SIZE" /></term>
        ///                 <description>
        ///                     Number of bits of alpha stored in the current window's
        ///                     accumulation buffer.  Zero if the window is color index.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_DOUBLEBUFFER" /></term>
        ///                 <description>
        ///                     One if the current window is double buffered, zero otherwise.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_RGBA" /></term>
        ///                 <description>
        ///                     One if the current window is RGBA mode, zero otherwise (i.e.,
        ///                     color index).
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_PARENT" /></term>
        ///                 <description>
        ///                     The window number of the current window's parent; zero if the
        ///                     window is a top-level window.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_NUM_CHILDREN" /></term>
        ///                 <description>
        ///                     The number of subwindows the current window has (not counting
        ///                     children of children).
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_COLORMAP_SIZE" /></term>
        ///                 <description>
        ///                     Size of current window's color index colormap; zero for RGBA
        ///                     color model windows.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_NUM_SAMPLES" /></term>
        ///                 <description>
        ///                     Number of samples for multisampling for the current window.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_STEREO" /></term>
        ///                 <description>
        ///                     One if the current window is stereo, zero otherwise.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_WINDOW_CURSOR" /></term>
        ///                 <description>
        ///                     Current cursor for the current window.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_SCREEN_WIDTH" /></term>
        ///                 <description>
        ///                     Width of the screen in pixels.  Zero indicates the width is
        ///                     unknown or not available.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_SCREEN_HEIGHT" /></term>
        ///                 <description>
        ///                     Height of the screen in pixels.  Zero indicates the height is
        ///                     unknown or not available.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_SCREEN_WIDTH_MM" /></term>
        ///                 <description>
        ///                     Width of the screen in millimeters.  Zero indicates the width is
        ///                     unknown or not available.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_SCREEN_HEIGHT_MM" /></term>
        ///                 <description>
        ///                     Height of the screen in millimeters.  Zero indicates the height
        ///                     is unknown or not available.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_MENU_NUM_ITEMS" /></term>
        ///                 <description>
        ///                     Number of menu items in the current menu.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_DISPLAY_MODE_POSSIBLE" /></term>
        ///                 <description>
        ///                     Whether the current display mode is supported or not.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_INIT_DISPLAY_MODE" /></term>
        ///                 <description>
        ///                     The initial display mode bit mask.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_INIT_WINDOW_X" /></term>
        ///                 <description>
        ///                     The X value of the initial window position.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_INIT_WINDOW_Y" /></term>
        ///                 <description>
        ///                     The Y value of the initial window position.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_INIT_WINDOW_WIDTH" /></term>
        ///                 <description>
        ///                     The width value of the initial window size.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_INIT_WINDOW_HEIGHT" /></term>
        ///                 <description>
        ///                     The height value of the initial window size.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_ELAPSED_TIME" /></term>
        ///                 <description>
        ///                     Number of milliseconds since <see cref="glutInit()" /> called (or
        ///                     first call to <c>Glut.glutGet(Glut.GLUT_ELAPSED_TIME)</c>).
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <returns>
        ///     GLUT state represented by integers.
        /// </returns>
        /// <remarks>
        ///     <b>glutGet</b> retrieves simple GLUT state represented by integers.  The
        ///     <i>state</i> parameter determines what type of state to return.  Window
        ///     capability state is returned for the layer in use.  GLUT state names
        ///     beginning with GLUT_WINDOW_ return state for the current window.  GLUT state
        ///     names beginning with GLUT_MENU_ return state for the current menu.  Other
        ///     GLUT state names return global state.  Requesting state for an invalid GLUT
        ///     state name returns negative one.
        /// </remarks>
        /// <seealso cref="glutDeviceGet" />
        /// <seealso cref="glutExtensionSupported" />
        /// <seealso cref="glutGetColor" />
        /// <seealso cref="glutGetMenu" />
        /// <seealso cref="glutGetModifiers" />
        /// <seealso cref="glutGetWindow" />
        /// <seealso cref="glutLayerGet" />
        // GLUTAPI int APIENTRY glutGet(GLenum type);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutGet(int state);
        #endregion int glutGet(int state)

        #region int glutDeviceGet(int info)
        /// <summary>
        ///     Retrieves GLUT device information represented by integers.
        /// </summary>
        /// <param name="info">
        ///     <para>
        ///         Name of device information to retrieve.  Valid values are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="GLUT_HAS_KEYBOARD" /></term>
        ///                 <description>
        ///                     Non-zero if a keyboard is available; zero if not available.  For
        ///                     most GLUT implementations, a keyboard can be assumed.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_HAS_MOUSE" /></term>
        ///                 <description>
        ///                     Non-zero if a mouse is available; zero if not available.  For
        ///                     most GLUT implementations, a keyboard can be assumed.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_HAS_SPACEBALL" /></term>
        ///                 <description>
        ///                     Non-zero if a Spaceball is available; zero if not available.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_HAS_DIAL_AND_BUTTON_BOX" /></term>
        ///                 <description>
        ///                     Non-zero if a dial and button box is available; zero if not
        ///                     available.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_HAS_TABLET" /></term>
        ///                 <description>
        ///                     Non-zero if a tablet is available; zero if not available.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_NUM_MOUSE_BUTTONS" /></term>
        ///                 <description>
        ///                     Number of buttons supported by the mouse.  If no mouse is
        ///                     supported, zero is returned.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_NUM_SPACEBALL_BUTTONS" /></term>
        ///                 <description>
        ///                     Number of buttons supported by the Spaceball.  If no Spaceball is
        ///                     supported, zero is returned.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_NUM_BUTTON_BOX_BUTTONS" /></term>
        ///                 <description>
        ///                     Number of buttons supported by the dial and button box device.
        ///                     If no dials and button box device is supported, zero is returned.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_NUM_DIALS" /></term>
        ///                 <description>
        ///                     Number of dials supported by the dial and button box device.  If
        ///                     no dials and button box device is supported, zero is returned.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_NUM_TABLET_BUTTONS" /></term>
        ///                 <description>
        ///                     Number of buttons supported by the tablet.  If no tablet is
        ///                     supported, zero is returned.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <returns>
        ///     <b>glutDeviceGet</b> retrieves GLUT device information represented by
        ///     integers.  The <i>info</i> parameter determines what type of device
        ///     information to return.  Requesting device information for an invalid GLUT
        ///     device information name returns negative one.
        /// </returns>
        /// <remarks>
        ///     <b>glutDeviceGet</b> retrieves GLUT device information represented by
        ///     integers.  The <i>info</i> parameter determines what type of device
        ///     information to return.  Requesting device information for an invalid GLUT
        ///     device information name returns negative one.
        /// </remarks>
        /// <seealso cref="glutButtonBoxFunc" />
        /// <seealso cref="glutDialsFunc" />
        /// <seealso cref="glutGet" />
        /// <seealso cref="glutIgnoreKeyRepeat" />
        /// <seealso cref="glutJoystickFunc" />
        /// <seealso cref="glutKeyboardFunc" />
        /// <seealso cref="glutMouseFunc" />
        /// <seealso cref="glutSetKeyRepeat" />
        /// <seealso cref="glutSpaceballMotionFunc" />
        /// <seealso cref="glutTabletButtonFunc" />
        /// <seealso cref="glutTabletMotionFunc" />
        // GLUTAPI int APIENTRY glutDeviceGet(GLenum type);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutDeviceGet(int info);
        #endregion int glutDeviceGet(int info)

        #region int glutExtensionSupported(string extension)
        /// <summary>
        ///     Helps to easily determine whether a given OpenGL extension is supported.
        /// </summary>
        /// <param name="extension">
        ///     Name of OpenGL extension to query.
        /// </param>
        /// <returns>
        ///     Returns non-zero if the extension is supported, zero if not supported.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         <b>glutExtensionSupported</b> helps to easily determine whether a given
        ///         OpenGL extension is supported or not.  The <i>extension</i> parameter names
        ///         the extension to query.  The supported extensions can also be determined with
        ///         <c>Gl.glGetString(Gl.GL_EXTENSIONS)</c>, but <b>glutExtensionSupported</b>
        ///         does the correct parsing of the returned string.
        ///     </para>
        ///     <para>
        ///         There must be a valid current window to call <b>glutExtensionSupported</b>.
        ///     </para>
        ///     <para>
        ///         <b>glutExtensionSupported</b> only returns information about OpenGL
        ///         extensions only.  This means window system dependent extensions (for example,
        ///         GLX extensions) are not reported by <b>glutExtensionSupported</b>.
        ///     </para>
        ///     <para>
        ///         <b>EXAMPLE</b>
        ///     </para>
        ///     <para>
        ///         <code>
        ///             if(!Glut.glutExtensionSupported("GL_EXT_texture")) {
        ///                 System.Console.WriteLine("Missing the texture extension!");
        ///                 System.Environment.Exit(1);
        ///             }
        ///         </code>
        ///     </para>
        ///     <para>
        ///         Notice that the name argument includes both the GL prefix and the extension
        ///         family prefix (EXT).
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutGet" />
        /// <seealso cref="Gl.glGetString" />
        // GLUTAPI int APIENTRY glutExtensionSupported(const char *name);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutExtensionSupported(string extension);
        #endregion int glutExtensionSupported(string extension)

        #region int glutGetModifiers()
        /// <summary>
        ///     Returns the modifier key state when certain callbacks were generated.
        /// </summary>
        /// <returns>
        ///     <para>
        ///         Returns the modifier key state at the time the input event for a keyboard,
        ///         special, or mouse callback is generated.  Valid values are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="GLUT_ACTIVE_SHIFT" /></term>
        ///                 <description>
        ///                     Set if the Shift modifier or Caps Lock is active.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_ACTIVE_CTRL" /></term>
        ///                 <description>
        ///                     Set if the Ctrl modifier is active.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_ACTIVE_ALT" /></term>
        ///                 <description>
        ///                     Set if the Alt modifier is active.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <b>glutGetModifiers</b> returns the modifier key state at the time the input
        ///     event for a keyboard, special, or mouse callback is generated.  This routine
        ///     may only be called while a keyboard, special, or mouse callback is being
        ///     handled.  The window system is permitted to intercept window system defined
        ///     modifier key strokes or mouse buttons, in which case, no GLUT callback will
        ///     be generated.  This interception will be independent of use of
        ///     <b>glutGetModifiers</b>.
        /// </remarks>
        /// <seealso cref="glutKeyboardFunc" />
        /// <seealso cref="glutMouseFunc" />
        /// <seealso cref="glutSpecialFunc" />
        // GLUTAPI int APIENTRY glutGetModifiers(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutGetModifiers();
        #endregion int glutGetModifiers()

        #region int glutLayerGet(int info)
        /// <summary>
        ///     Retrieves GLUT state pertaining to the layers of the current window.
        /// </summary>
        /// <param name="info">
        ///     <para>
        ///         Name of device information to retrieve.  Valid values are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="GLUT_OVERLAY_POSSIBLE" /></term>
        ///                 <description>
        ///                     Whether an overlay could be established for the current window
        ///                     given the current initial display mode.  If false,
        ///                     <see cref="glutEstablishOverlay" /> will fail with a fatal error
        ///                     if called.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_LAYER_IN_USE" /></term>
        ///                 <description>
        ///                     Either <see cref="GLUT_NORMAL" /> or <see cref="GLUT_OVERLAY" />
        ///                     depending on whether the normal plane or overlay is the layer in
        ///                     use.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_HAS_OVERLAY" /></term>
        ///                 <description>
        ///                     If the current window has an overlay established.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_TRANSPARENT_INDEX" /></term>
        ///                 <description>
        ///                     The transparent color index of the overlay of the current window;
        ///                     negative one is returned if no overlay is in use.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_NORMAL_DAMAGED" /></term>
        ///                 <description>
        ///                     True if the normal plane of the current window has damaged (by
        ///                     window system activity) since the last display callback was
        ///                     triggered.  Calling <see cref="glutPostRedisplay" /> will not set
        ///                     this true.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_OVERLAY_DAMAGED" /></term>
        ///                 <description>
        ///                     True if the overlay plane of the current window has damaged (by
        ///                     window system activity) since the last display callback was
        ///                     triggered.  Calling <see cref="glutPostRedisplay" /> or
        ///                     <see cref="glutPostOverlayRedisplay" /> will not set this true.
        ///                     Negative one is returned if no overlay is in use.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <returns>
        ///     Retrieves GLUT layer information for the current window represented by
        ///     integers.  The <i>info</i> parameter determines what type of layer
        ///     information to return.
        /// </returns>
        /// <seealso cref="glutCreateWindow" />
        /// <seealso cref="glutEstablishOverlay" />
        /// <seealso cref="glutSetColor" />
        // GLUTAPI int APIENTRY glutLayerGet(GLenum type);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutLayerGet(int info);
        #endregion int glutLayerGet(int info)
        #endregion State Retrieval Sub-API

        #region Font Sub-API
        #region glutBitmapCharacter([In] IntPtr font, int character)
        /// <summary>
        ///     Renders a bitmap character using OpenGL.
        /// </summary>
        /// <param name="font">
        ///     <para>
        ///         Bitmap font to use.  Without using any display lists,
        ///         <b>glutBitmapCharacter</b> renders the character in the named bitmap font.
        ///         The available fonts are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="GLUT_BITMAP_8_BY_13" /></term>
        ///                 <description>
        ///                     A fixed width font with every character fitting in an 8 by 13
        ///                     pixel rectangle.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_BITMAP_9_BY_15" /></term>
        ///                 <description>
        ///                     A fixed width font with every character fitting in an 9 by 15
        ///                     pixel rectangle.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_BITMAP_TIMES_ROMAN_10" /></term>
        ///                 <description>
        ///                     A 10-point proportional spaced Times Roman font.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_BITMAP_TIMES_ROMAN_24" /></term>
        ///                 <description>
        ///                     A 24-point proportional spaced Times Roman font.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_BITMAP_HELVETICA_10" /></term>
        ///                 <description>
        ///                     A 10-point proportional spaced Helvetica font.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_BITMAP_HELVETICA_12" /></term>
        ///                 <description>
        ///                     A 12-point proportional spaced Helvetica font.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_BITMAP_HELVETICA_18" /></term>
        ///                 <description>
        ///                     A 18-point proportional spaced Helvetica font.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <param name="character">
        ///     Character to render (not confined to 8 bits).
        /// </param>
        /// <remarks>
        ///     <para>
        ///         Rendering a nonexistent character has no effect.  <b>glutBitmapCharacter</b>
        ///         automatically sets the OpenGL unpack pixel storage modes it needs
        ///         appropriately and saves and restores the previous modes before returning.
        ///         The generated call to <c>Gl.glBitmap</c> will adjust the current raster
        ///         position based on the width of the character.
        ///     </para>
        ///     <para>
        ///         <b>EXAMPLE</b>
        ///     </para>
        ///     <para>
        ///         Here is a routine that shows how to render a string of text with
        ///         <b>glutBitmapCharacter</b>:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             private void PrintText(float x, float y, string text) {
        ///                 Gl.glRasterPos2f(x, y);
        ///                 foreach(char c in text) {
        ///                     Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_18, c);
        ///                 }
        ///             }
        ///         </code>
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutBitmapWidth" />
        /// <seealso cref="glutStrokeCharacter" />
        // GLUTAPI void APIENTRY glutBitmapCharacter(void *font, int character);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutBitmapCharacter([In] IntPtr font, int character);
        #endregion glutBitmapCharacter([In] IntPtr font, int character)

        #region int glutBitmapWidth([In] IntPtr font, int character)
        /// <summary>
        ///     Returns the width of a bitmap character.
        /// </summary>
        /// <param name="font">
        ///     Bitmap font to use.  For valid values see the
        ///     <see cref="glutBitmapCharacter" /> description.
        /// </param>
        /// <param name="character">
        ///     Character to return width of (not confined to 8 bits).
        /// </param>
        /// <returns>
        ///     Returns the width in pixels of a bitmap character in a supported bitmap font.
        /// </returns>
        /// <remarks>
        ///     <b>glutBitmapWidth</b> returns the width in pixels of a bitmap character in a
        ///     supported bitmap font.  While the width of characters in a font may vary
        ///     (though fixed width fonts do not vary), the maximum height characteristics of
        ///     a particular font are fixed.
        /// </remarks>
        /// <seealso cref="glutBitmapCharacter" />
        /// <seealso cref="glutStrokeWidth" />
        // GLUTAPI int APIENTRY glutBitmapWidth(void *font, int character);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutBitmapWidth([In] IntPtr font, int character);
        #endregion int glutBitmapWidth([In] IntPtr font, int character)

        #region glutStrokeCharacter([In] IntPtr font, int character)
        /// <summary>
        ///     Renders a stroke character using OpenGL.
        /// </summary>
        /// <param name="font">
        ///     <para>
        ///         Stroke font to use.  Without using any display lists,
        ///         <b>glutStrokeCharacter</b> renders the character in the named stroke font.
        ///         The available fonts are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="GLUT_STROKE_ROMAN" /></term>
        ///                 <description>
        ///                     A proportionally spaced Roman Simplex font for ASCII characters
        ///                     32 through 127.  The maximum top character in the font is 119.05
        ///                     units; the bottom descends 33.33 units.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_STROKE_MONO_ROMAN" /></term>
        ///                 <description>
        ///                     A mono-spaced spaced Roman Simplex font (same characters as
        ///                     <see cref="GLUT_STROKE_ROMAN" />) for ASCII characters 32 through
        ///                     127.  The maximum top character in the font is 119.05 units; the
        ///                     bottom descends 33.33 units. Each character is 104.76 units wide.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <param name="character">
        ///     Character to render (not confined to 8 bits).
        /// </param>
        /// <remarks>
        ///     <para>
        ///         Rendering a nonexistent character has no effect.  A <c>Gl.glTranslatef</c> is
        ///         used to translate the current model view matrix to advance the width of the
        ///         character.
        ///     </para>
        ///     <para>
        ///         <b>EXAMPLE</b>
        ///     </para>
        ///     <para>
        ///         Here is a routine that shows how to render a text string with
        ///         <b>glutStrokeCharacter</b>:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             private void PrintText(float x, float y, string text) {
        ///                 GL.glPushMatrix();
        ///                     Gl.glTranslatef(x, y, 0);
        ///                     foreach(char c in text) {
        ///                         Glut.glutStrokeCharacter(Glut.GLUT_STROKE_ROMAN, c);
        ///                     }
        ///                 Gl.glPopMatrix();
        ///             }
        ///         </code>
        ///     </para>
        ///     <para>
        ///         If you want to draw stroke font text using wide, antialiased lines, use:
        ///     </para>
        ///     <para>
        ///         <code>
        ///             Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
        ///             Gl.glEnable(Gl.GL_BLEND);
        ///             Gl.glEnable(Gl.GL_LINE_SMOOTH);
        ///             Gl.glLineWidth(2.0f);
        ///             PrintText(200, 225, "This is antialiased.");
        ///         </code>
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutBitmapCharacter" />
        /// <seealso cref="glutStrokeWidth" />
        // GLUTAPI void APIENTRY glutStrokeCharacter(void *font, int character);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutStrokeCharacter([In] IntPtr font, int character);
        #endregion glutStrokeCharacter([In] IntPtr font, int character)

        #region int glutStrokeWidth([In] IntPtr font, int character)
        /// <summary>
        ///     Returns the width of a stroke character.
        /// </summary>
        /// <param name="font">
        ///     Stroke font to use.  For valid values see the
        ///     <see cref="glutStrokeCharacter" /> description.
        /// </param>
        /// <param name="character">
        ///     Character to return width of (not confined to 8 bits).
        /// </param>
        /// <returns>
        ///     Returns the width in pixels of a stroke character in a supported stroke font.
        /// </returns>
        /// <remarks>
        ///     <b>glutStrokeWidth</b> returns the width in pixels of a stroke character in a
        ///     supported stroke font.  While the width of characters in a font may vary
        ///     (though fixed width fonts do not vary), the maximum height characteristics of
        ///     a particular font are fixed.
        /// </remarks>
        /// <seealso cref="glutBitmapWidth" />
        /// <seealso cref="glutStrokeCharacter" />
        // GLUTAPI int APIENTRY glutStrokeWidth(void *font, int character);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutStrokeWidth([In] IntPtr font, int character);
        #endregion int glutStrokeWidth([In] IntPtr font, int character)

        #region int glutBitmapLength([In] IntPtr font, string text)
        /// <summary>
        ///     Returns the length of a bitmap font string.
        /// </summary>
        /// <param name="font">
        ///     Bitmap font to use.  For valid values, see the
        ///     <see cref="glutBitmapCharacter" /> description.
        /// </param>
        /// <param name="text">
        ///     Text string.
        /// </param>
        /// <returns>
        ///     Length of string in pixels.
        /// </returns>
        /// <remarks>
        ///     <b>glutBitmapLength</b> returns the length in pixels of a string (8-bit
        ///     characters).  This length is equivalent to summing all the widths returned by
        ///     <see cref="glutBitmapWidth" /> for each character in the string.
        /// </remarks>
        /// <seealso cref="glutBitmapCharacter" />
        /// <seealso cref="glutStrokeWidth" />
        // GLUTAPI int APIENTRY glutBitmapLength(void *font, const unsigned char *string);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutBitmapLength([In] IntPtr font, string text);
        #endregion int glutBitmapLength([In] IntPtr font, string text)

        #region int glutStrokeLength([In] IntPtr font, string text)
        /// <summary>
        ///     Returns the length of a stroke font string.
        /// </summary>
        /// <param name="font">
        ///     Stroke font to use.  For valid values see the
        ///     <see cref="glutStrokeCharacter" /> description.
        /// </param>
        /// <param name="text">
        ///     Text string.
        /// </param>
        /// <returns>
        ///     The length in modeling units of a string.
        /// </returns>
        /// <remarks>
        ///     <b>glutStrokeLength</b> returns the length in modeling units of a string
        ///     (8-bit characters).  This length is equivalent to summing all the widths
        ///     returned by <see cref="glutStrokeWidth" /> for each character in the string.
        /// </remarks>
        /// <seealso cref="glutBitmapWidth" />
        /// <seealso cref="glutStrokeCharacter" />
        // GLUTAPI int APIENTRY glutStrokeLength(void *font, const unsigned char *string);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutStrokeLength(IntPtr font, string text);
        #endregion int glutStrokeLength(IntPtr font, string text)
        #endregion Font Sub-API

        #region Pre-Built Models Sub-API
        #region glutWireSphere(double radius, int slices, int stacks)
        /// <summary>
        ///     Renders a wireframe sphere.
        /// </summary>
        /// <param name="radius">
        ///     The radius of the sphere.
        /// </param>
        /// <param name="slices">
        ///     The number of subdivisions around the Z axis (similar to lines of longitude).
        /// </param>
        /// <param name="stacks">
        ///     The number of subdivisions along the Z axis (similar to lines of latitude).
        /// </param>
        /// <remarks>
        ///     <b>glutWireSphere</b> renders a wireframe sphere centered at the modeling
        ///     coordinates origin of the specified <i>radius</i>.  The sphere is subdivided
        ///     around the Z axis into <i>slices</i> and along the Z axis into <i>stacks</i>.
        /// </remarks>
        /// <seealso cref="glutSolidSphere" />
        // GLUTAPI void APIENTRY glutWireSphere(GLdouble radius, GLint slices, GLint stacks);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutWireSphere(double radius, int slices, int stacks);
        #endregion glutWireSphere(double radius, int slices, int stacks)

        #region glutSolidSphere(double radius, int slices, int stacks)
        /// <summary>
        ///     Renders a solid sphere.
        /// </summary>
        /// <param name="radius">
        ///     The radius of the sphere.
        /// </param>
        /// <param name="slices">
        ///     The number of subdivisions around the Z axis (similar to lines of longitude).
        /// </param>
        /// <param name="stacks">
        ///     The number of subdivisions along the Z axis (similar to lines of latitude).
        /// </param>
        /// <remarks>
        ///     <b>glutSolidSphere</b> renders a solid sphere centered at the modeling
        ///     coordinates origin of the specified <i>radius</i>.  The sphere is subdivided
        ///     around the Z axis into <i>slices</i> and along the Z axis into <i>stacks</i>.
        /// </remarks>
        /// <seealso cref="glutWireSphere" />
        // GLUTAPI void APIENTRY glutSolidSphere(GLdouble radius, GLint slices, GLint stacks);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSolidSphere(double radius, int slices, int stacks);
        #endregion glutSolidSphere(double radius, int slices, int stacks)

        #region glutWireCone(double baseRadius, double height, int slices, int stacks)
        /// <summary>
        ///     Renders a wireframe cone.
        /// </summary>
        /// <param name="baseRadius">
        ///     The radius of the base of the cone.
        /// </param>
        /// <param name="height">
        ///     The height of the cone.
        /// </param>
        /// <param name="slices">
        ///     The number of subdivisions around the Z axis.
        /// </param>
        /// <param name="stacks">
        ///     The number of subdivisions along the Z axis.
        /// </param>
        /// <remarks>
        ///     <b>glutWireCone</b> renders a wireframe cone oriented along the Z axis.  The
        ///     <i>baseRadius</i> of the cone is placed at Z = 0, and the top at
        ///     Z = <i>height</i>.  The cone is subdivided around the Z axis into
        ///     <i>slices</i>, and along the Z axis into <i>stacks</i>.
        /// </remarks>
        /// <seealso cref="glutSolidCone" />
        // GLUTAPI void APIENTRY glutWireCone(GLdouble base, GLdouble height, GLint slices, GLint stacks);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutWireCone(double baseRadius, double height, int slices, int stacks);
        #endregion glutWireCone(double baseRadius, double height, int slices, int stacks)

        #region glutSolidCone(double baseRadius, double height, int slices, int stacks)
        /// <summary>
        ///     Renders a solid cone.
        /// </summary>
        /// <param name="baseRadius">
        ///     The radius of the base of the cone.
        /// </param>
        /// <param name="height">
        ///     The height of the cone.
        /// </param>
        /// <param name="slices">
        ///     The number of subdivisions around the Z axis.
        /// </param>
        /// <param name="stacks">
        ///     The number of subdivisions along the Z axis.
        /// </param>
        /// <remarks>
        ///     <b>glutSolidCone</b> renders a solid cone oriented along the Z axis.  The
        ///     <i>baseRadius</i> of the cone is placed at Z = 0, and the top at
        ///     Z = <i>height</i>.  The cone is subdivided around the Z axis into
        ///     <i>slices</i>, and along the Z axis into <i>stacks</i>.
        /// </remarks>
        /// <seealso cref="glutWireCone" />
        // GLUTAPI void APIENTRY glutSolidCone(GLdouble base, GLdouble height, GLint slices, GLint stacks);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSolidCone(double baseRadius, double height, int slices, int stacks);
        #endregion glutSolidCone(double baseRadius, double height, int slices, int stacks)

        #region glutWireCube(double size)
        /// <summary>
        ///     Renders a wireframe cube.
        /// </summary>
        /// <param name="size">
        ///     Length of the sides of the cube.
        /// </param>
        /// <remarks>
        ///     <b>glutWireCube</b> renders a wireframe cube.  The cube is centered at the
        ///     modeling coordinates origin with sides of length <i>size</i>.
        /// </remarks>
        /// <seealso cref="glutSolidCube" />
        // GLUTAPI void APIENTRY glutWireCube(GLdouble size);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutWireCube(double size);
        #endregion glutWireCube(double size)

        #region glutSolidCube(double size)
        /// <summary>
        ///     Renders a solid cube.
        /// </summary>
        /// <param name="size">
        ///     Length of the sides of the cube.
        /// </param>
        /// <remarks>
        ///     <b>glutSolidCube</b> renders a solid cube.  The cube is centered at the
        ///     modeling coordinates origin with sides of length <i>size</i>.
        /// </remarks>
        /// <seealso cref="glutWireCube" />
        // GLUTAPI void APIENTRY glutSolidCube(GLdouble size);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSolidCube(double size);
        #endregion glutSolidCube(double size)

        #region glutWireTorus(double innerRadius, double outerRadius, int sides, int rings)
        /// <summary>
        ///     Renders a wireframe torus (doughnut).
        /// </summary>
        /// <param name="innerRadius">
        ///     Inner radius of the torus.
        /// </param>
        /// <param name="outerRadius">
        ///     Outer radius of the torus.
        /// </param>
        /// <param name="sides">
        ///     Number of sides for each radial section.
        /// </param>
        /// <param name="rings">
        ///     Number of radial divisions for the torus.
        /// </param>
        /// <remarks>
        ///     <b>glutWireTorus</b> renders a wireframe torus (doughnut) centered at the
        ///     modeling coordinates origin whose axis is aligned with the Z axis.
        /// </remarks>
        /// <seealso cref="glutSolidTorus" />
        // GLUTAPI void APIENTRY glutWireTorus(GLdouble innerRadius, GLdouble outerRadius, GLint sides, GLint rings);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutWireTorus(double innerRadius, double outerRadius, int sides, int rings);
        #endregion glutWireTorus(double innerRadius, double outerRadius, int sides, int rings)

        #region glutSolidTorus(double innerRadius, double outerRadius, int sides, int rings)
        /// <summary>
        ///     Renders a solid torus (doughnut).
        /// </summary>
        /// <param name="innerRadius">
        ///     Inner radius of the torus.
        /// </param>
        /// <param name="outerRadius">
        ///     Outer radius of the torus.
        /// </param>
        /// <param name="sides">
        ///     Number of sides for each radial section.
        /// </param>
        /// <param name="rings">
        ///     Number of radial divisions for the torus.
        /// </param>
        /// <remarks>
        ///     <b>glutSolidTorus</b> renders a solid torus (doughnut) centered at the
        ///     modeling coordinates origin whose axis is aligned with the Z axis.
        /// </remarks>
        /// <seealso cref="glutWireTorus" />
        // GLUTAPI void APIENTRY glutSolidTorus(GLdouble innerRadius, GLdouble outerRadius, GLint sides, GLint rings);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSolidTorus(double innerRadius, double outerRadius, int sides, int rings);
        #endregion glutSolidTorus(double innerRadius, double outerRadius, int sides, int rings)

        #region glutWireDodecahedron()
        /// <summary>
        ///     Renders a wireframe dodecahedron (12-sided regular solid).
        /// </summary>
        /// <remarks>
        ///     <b>glutWireDodecahedron</b> renders a wireframe dodecahedron centered at the
        ///     modeling coordinates origin with a radius of <c>Sqrt(3)</c>.
        /// </remarks>
        /// <seealso cref="glutSolidDodecahedron" />
        // GLUTAPI void APIENTRY glutWireDodecahedron(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutWireDodecahedron();
        #endregion glutWireDodecahedron()

        #region glutSolidDodecahedron()
        /// <summary>
        ///     Renders a solid dodecahedron (12-sided regular solid).
        /// </summary>
        /// <remarks>
        ///     <b>glutSolidDodecahedron</b> renders a solid dodecahedron centered at the
        ///     modeling coordinates origin with a radius of <c>Sqrt(3)</c>.
        /// </remarks>
        /// <seealso cref="glutWireDodecahedron" />
        // GLUTAPI void APIENTRY glutSolidDodecahedron(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSolidDodecahedron();
        #endregion glutSolidDodecahedron()

        #region glutWireTeapot(double size)
        /// <summary>
        ///     Renders a wireframe teapot.
        /// </summary>
        /// <param name="size">
        ///     Relative size of the teapot.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutWireTeapot</b> renders a wireframe teapot.  Both surface normals and
        ///         texture coordinates for the teapot are generated.  The teapot is generated
        ///         with OpenGL evaluators.
        ///     </para>
        ///     <para>
        ///         <b>Footnote</b>
        ///     </para>
        ///     <para>
        ///         Yes, the classic computer graphics teapot modeled by Martin Newell in 1975.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutSolidTeapot" />
        // GLUTAPI void APIENTRY glutWireTeapot(GLdouble size);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutWireTeapot(double size);
        #endregion glutWireTeapot(double size)

        #region glutSolidTeapot(double size)
        /// <summary>
        ///     Renders a solid teapot.
        /// </summary>
        /// <param name="size">
        ///     Relative size of the teapot.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutSolidTeapot</b> renders a solid teapot.  Both surface normals and
        ///         texture coordinates for the teapot are generated.  The teapot is generated
        ///         with OpenGL evaluators.
        ///     </para>
        ///     <para>
        ///         <b>Footnote</b>
        ///     </para>
        ///     <para>
        ///         Yes, the classic computer graphics teapot modeled by Martin Newell in 1975.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutWireTeapot" />
        // GLUTAPI void APIENTRY glutSolidTeapot(GLdouble size);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSolidTeapot(double size);
        #endregion glutSolidTeapot(double size)

        #region glutWireOctahedron()
        /// <summary>
        ///     Renders wireframe octahedron (8-sided regular solid).
        /// </summary>
        /// <remarks>
        ///     <b>glutWireOctahedron</b> renders a wireframe octahedron centered at the
        ///     modeling coordinates origin with a radius of 1.0.
        /// </remarks>
        /// <seealso cref="glutSolidOctahedron" />
        // GLUTAPI void APIENTRY glutWireOctahedron(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutWireOctahedron();
        #endregion glutWireOctahedron()

        #region glutSolidOctahedron()
        /// <summary>
        ///     Renders solid octahedron (8-sided regular solid).
        /// </summary>
        /// <remarks>
        ///     <b>glutSolidOctahedron</b> renders a solid octahedron centered at the
        ///     modeling coordinates origin with a radius of 1.0.
        /// </remarks>
        /// <seealso cref="glutWireOctahedron" />
        // GLUTAPI void APIENTRY glutSolidOctahedron(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSolidOctahedron();
        #endregion glutSolidOctahedron()

        #region glutWireTetrahedron()
        /// <summary>
        ///     Renders a wireframe tetrahedron (4-sided regular solid).
        /// </summary>
        /// <remarks>
        ///     <b>glutWireTetrahedron</b> renders a wireframe tetrahedron centered at the
        ///     modeling coordinates origin with a radius of <c>Sqrt(3)</c>.
        /// </remarks>
        /// <seealso cref="glutSolidTetrahedron" />
        // GLUTAPI void APIENTRY glutWireTetrahedron(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutWireTetrahedron();
        #endregion glutWireTetrahedron()

        #region glutSolidTetrahedron()
        /// <summary>
        ///     Renders a solid tetrahedron (4-sided regular solid).
        /// </summary>
        /// <remarks>
        ///     <b>glutSolidTetrahedron</b> renders a solid tetrahedron centered at the
        ///     modeling coordinates origin with a radius of <c>Sqrt(3)</c>.
        /// </remarks>
        /// <seealso cref="glutWireTetrahedron" />
        // GLUTAPI void APIENTRY glutSolidTetrahedron(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSolidTetrahedron();
        #endregion glutSolidTetrahedron()

        #region glutWireIcosahedron()
        /// <summary>
        ///     Renders a wireframe icosahedron (20-sided regular solid).
        /// </summary>
        /// <remarks>
        ///     <b>glutWireIcosahedron</b> renders a wireframe icosahedron.  The icosahedron
        ///     is centered at the modeling coordinates origin and has a radius of 1.0.
        /// </remarks>
        /// <seealso cref="glutSolidIcosahedron" />
        // GLUTAPI void APIENTRY glutWireIcosahedron(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutWireIcosahedron();
        #endregion glutWireIcosahedron()

        #region glutSolidIcosahedron()
        /// <summary>
        ///     Renders a solid icosahedron (20-sided regular solid).
        /// </summary>
        /// <remarks>
        ///     <b>glutSolidIcosahedron</b> renders a solid icosahedron.  The icosahedron is
        ///     centered at the modeling coordinates origin and has a radius of 1.0.
        /// </remarks>
        /// <seealso cref="glutWireIcosahedron" />
        // GLUTAPI void APIENTRY glutSolidIcosahedron(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSolidIcosahedron();
        #endregion glutSolidIcosahedron()
        #endregion Pre-built Models Sub-API

        #region Video Resize Sub-API
        #region int glutVideoResizeGet(int param)
        /// <summary>
        ///     Retrieves GLUT video resize information represented by integers.
        /// </summary>
        /// <param name="param">
        ///     <para>
        ///         Name of video resize information to retrieve.  Available values are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="GLUT_VIDEO_RESIZE_POSSIBLE" /></term>
        ///                 <description>
        ///                     Non-zero if video resizing is supported by the underlying system;
        ///                     zero if not supported.  If this is zero, the other video resize
        ///                     GLUT calls do nothing when called.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_VIDEO_RESIZE_X_DELTA" /></term>
        ///                 <description>Unknown</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_VIDEO_RESIZE_Y_DELTA" /></term>
        ///                 <description>Unknown</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_VIDEO_RESIZE_WIDTH_DELTA" /></term>
        ///                 <description>Unknown</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_VIDEO_RESIZE_HEIGHT_DELTA" /></term>
        ///                 <description>Unknown</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_VIDEO_RESIZE_X" /></term>
        ///                 <description>Unknown</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_VIDEO_RESIZE_Y" /></term>
        ///                 <description>Unknown</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_VIDEO_RESIZE_WIDTH" /></term>
        ///                 <description>Unknown</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_VIDEO_RESIZE_HEIGHT" /></term>
        ///                 <description>Unknown</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_VIDEO_RESIZE_IN_USE" /></term>
        ///                 <description>Unknown</description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutVideoResizeGet</b> retrieves GLUT video resizing information
        ///         represented by integers.  The <i>param</i> parameter determines what type of
        ///         video resize information to return.
        ///     </para>
        ///     <para>
        ///         <b>X IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         The current implementation uses the <c>SGIX_video_resize</c> GLX extension.
        ///         This extension is currently supported on SGI's InfiniteReality-based systems.
        ///     </para>
        ///     <para>
        ///         <b>WIN32 IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         The current implementation never reports that video resizing is possible.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutGet" />
        /// <seealso cref="glutSetupVideoResizing" />
        /// <seealso cref="glutStopVideoResizing" />
        /// <seealso cref="glutVideoPan" />
        /// <seealso cref="glutVideoResize" />
        // GLUTAPI int APIENTRY glutVideoResizeGet(GLenum param);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutVideoResizeGet(int param);
        #endregion int glutVideoResizeGet(int param)

        #region glutSetupVideoResizing()
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </summary>
        /// <remarks>
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </remarks>
        // GLUTAPI void APIENTRY glutSetupVideoResizing(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSetupVideoResizing();
        #endregion glutSetupVideoResizing()

        #region glutStopVideoResizing()
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </summary>
        /// <remarks>
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </remarks>
        // GLUTAPI void APIENTRY glutStopVideoResizing(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutStopVideoResizing();
        #endregion glutStopVideoResizing()

        #region glutVideoResize(int x, int y, int width, int height)
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </summary>
        /// <param name="x">
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </param>
        /// <param name="y">
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </param>
        /// <param name="width">
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </param>
        /// <param name="height">
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </param>
        /// <remarks>
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </remarks>
        // GLUTAPI void APIENTRY glutVideoResize(int x, int y, int width, int height);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutVideoResize(int x, int y, int width, int height);
        #endregion glutVideoResize(int x, int y, int width, int height)

        #region glutVideoPan(int x, int y, int width, int height)
        /// <summary>
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </summary>
        /// <param name="x">
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </param>
        /// <param name="y">
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </param>
        /// <param name="width">
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </param>
        /// <param name="height">
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </param>
        /// <remarks>
        ///     Unknown.  Unable to locate definitive documentation on this method.
        /// </remarks>
        // GLUTAPI void APIENTRY glutVideoPan(int x, int y, int width, int height);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutVideoPan(int x, int y, int width, int height);
        #endregion glutVideoPan(int x, int y, int width, int height)
        #endregion Video Resize Sub-API

        #region Debugging Sub-API
        #region glutReportErrors()
        /// <summary>
        ///     Prints out OpenGL run-time errors.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <b>glutReportErrors</b> prints out any OpenGL run-time errors pending and
        ///         clears the errors.  This routine typically should only be used for debugging
        ///         purposes since calling it will slow OpenGL programs.  It is provided as a
        ///         convenience; all the routine does is call <see cref="Gl.glGetError" /> until
        ///         no more errors are reported.  Any errors detected are reported with a GLUT
        ///         warning and the corresponding text message generated by
        ///         /*see cref="Glu.gluErrorString" />*/.
        ///     </para>
        ///     <para>
        ///         Calling <b>glutReportErrors</b> repeatedly in your program can help isolate
        ///         OpenGL errors to the offending OpenGL command.  Remember that you can use the
        ///         <c>-gldebug</c> option to detect OpenGL errors in any GLUT program.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutCreateWindow" />
        /// /*seealso cref="Glu.gluErrorString" />*/
        /// <seealso cref="Gl.glGetError" />
        /// <seealso cref="glutInit()" />
        /// <seealso cref="glutInitDisplayMode" />
        // GLUTAPI void APIENTRY glutReportErrors(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutReportErrors();
        #endregion glutReportErrors()
        #endregion Debugging Sub-API

        #region Device Control Sub-API
        #region glutIgnoreKeyRepeat(int ignore)
        /// <summary>
        ///     Determines if auto repeat keystrokes are reported to the current window.
        /// </summary>
        /// <param name="ignore">
        ///     Non-zero indicates auto repeat keystrokes should not be reported by the
        ///     keyboard and special callbacks; zero indicates that auto repeat keystrokes
        ///     will be reported.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutIgnoreKeyRepeat</b> determines if auto repeat keystrokes are reported
        ///         to the current window.  The ignore auto repeat state of a window can be
        ///         queried with <c>Glut.glutDeviceGet(Glut.GLUT_DEVICE_IGNORE_KEY_REPEAT)</c>.
        ///     </para>
        ///     <para>
        ///         Ignoring auto repeated keystrokes is generally done in conjunction with using
        ///         the <see cref="glutKeyboardUpFunc" /> and <see cref="glutSpecialUpFunc" />
        ///         callbacks to repeat key releases.  If you do not ignore auto repeated
        ///         keystrokes, your GLUT application will experience repeated release/press
        ///         callbacks.  Games using the keyboard will typically want to ignore key
        ///         repeat.
        ///     </para>
        ///     <para>
        ///         <b>X IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         X11 sends <c>KeyPress</c> events repeatedly when the window system's global
        ///         auto repeat is enabled.  <b>glutIgnoreKeyRepeat</b> can prevent these auto
        ///         repeated keystrokes from being reported as keyboard or special callbacks, but
        ///         there is still some minimal overhead by the X server to continually stream
        ///         <c>KeyPress</c> events to the GLUT application.  The
        ///         <see cref="glutSetKeyRepeat" /> routine can be used to actually disable the
        ///         global sending of auto repeated <c>KeyPress</c> events.  Note that
        ///         <see cref="glutSetKeyRepeat" /> affects the global window system auto repeat
        ///         state so other applications will not auto repeat if you disable auto repeat
        ///         globally through <see cref="glutSetKeyRepeat" />.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutDeviceGet" />
        /// <seealso cref="glutKeyboardFunc" />
        /// <seealso cref="glutKeyboardUpFunc" />
        /// <seealso cref="glutSetKeyRepeat" />
        /// <seealso cref="glutSpecialFunc" />
        /// <seealso cref="glutSpecialUpFunc" />
        // GLUTAPI void APIENTRY glutIgnoreKeyRepeat(int ignore);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutIgnoreKeyRepeat(int ignore);
        #endregion glutIgnoreKeyRepeat(int ignore)

        #region glutSetKeyRepeat(int repeatMode)
        /// <summary>
        ///     Sets the key repeat mode for the window system.
        /// </summary>
        /// <param name="repeatMode">
        ///     <para>
        ///         Mode for setting key repeat to.  Available modes are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_REPEAT_OFF" /></term>
        ///                 <description>
        ///                     Disable key repeat for the window system on a global basis if
        ///                     possible.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_REPEAT_ON" /></term>
        ///                 <description>
        ///                     Enable key repeat for the window system on a global basis if
        ///                     possible.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_KEY_REPEAT_DEFAULT" /></term>
        ///                 <description>
        ///                     Reset the key repeat mode for the window system to its default
        ///                     state if possible.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutSetKeyRepeat</b> sets the key repeat mode for the window system on a
        ///         global basis if possible.  If supported by the window system, the key repeat
        ///         can either be enabled, disabled, or set to the window system's default key
        ///         repeat state.
        ///     </para>
        ///     <para>
        ///         <b>X IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         X11 sends <c>KeyPress</c> events repeatedly when the window system's global
        ///         auto repeat is enabled.  <see cref="glutIgnoreKeyRepeat" /> can prevent these
        ///         auto repeated keystrokes from being reported as keyboard or special
        ///         callbacks, but there is still some minimal overhead by the X server to
        ///         continually stream <c>KeyPress</c> events to the GLUT application.  The
        ///         <b>glutSetKeyRepeat</b> routine can be used to actually disable the global
        ///         sending of auto repeated <c>KeyPress</c> events.  Note that
        ///         <b>glutSetKeyRepeat</b> affects the global window system auto repeat state so
        ///         other applications will not auto repeat if you disable auto repeat globally
        ///         through <b>glutSetKeyRepeat</b>.
        ///     </para>
        ///     <para>
        ///         GLUT applications using the X11 GLUT implemenation should disable key repeat
        ///         with <b>glutSetKeyRepeat</b> to disable key repeats most efficiently.
        ///     </para>
        ///     <para>
        ///         <b>WIN32 IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         The Win32 implementation of <b>glutSetKeyRepeat</b> does nothing.  The
        ///         <see cref="glutIgnoreKeyRepeat" /> routine can be used in the Win32 GLUT
        ///         implementation to ignore repeated keys on a per-window basis without changing
        ///         the global window system key repeat. 
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutDeviceGet" />
        /// <seealso cref="glutIgnoreKeyRepeat" />
        /// <seealso cref="glutKeyboardFunc" />
        /// <seealso cref="glutKeyboardUpFunc" />
        /// <seealso cref="glutSpecialFunc" />
        /// <seealso cref="glutSpecialUpFunc" />
        // GLUTAPI void APIENTRY glutSetKeyRepeat(int repeatMode);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSetKeyRepeat(int repeatMode);
        #endregion glutSetKeyRepeat(int repeatMode)

        #region glutForceJoystickFunc()
        /// <summary>
        ///     Forces current window's joystick callback to be called.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <b>glutForceJoystickFunc</b> forces the current window's joystick callback to
        ///         be called, reporting the latest joystick state.
        ///     </para>
        ///     <para>
        ///         The joystick callback is called either due to polling of the joystick at the
        ///         uniform timer interval set by <see cref="glutJoystickFunc" />'s
        ///         <i>pollInterval</i> (specified in milliseconds) or in response to calling
        ///         <b>glutForceJoystickFunc</b>.  If the <i>pollInterval</i> is non-positive, no
        ///         joystick polling is performed and the GLUT application must frequently
        ///         (usually from an idle callback) call <b>glutForceJoystickFunc</b>.
        ///     </para>
        ///     <para>
        ///         The joystick callback will be called once (if one exists) for each time
        ///         <b>glutForceJoystickFunc</b> is called.  The callback is called from
        ///         <see cref="glutJoystickFunc" />.  That is, when
        ///         <see cref="glutJoystickFunc" /> returns, the callback will have already
        ///         happened.
        ///     </para>
        ///     <para>
        ///         <b>X IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         The GLUT 3.7 implementation of GLUT for X11 supports the joystick API, but
        ///         not actual joystick input.  A future implementation of GLUT for X11 may add
        ///         joystick support.
        ///     </para>
        ///     <para>
        ///         <b>WIN32 IMPLEMENTATION NOTES</b>
        ///     </para>
        ///     <para>
        ///         The GLUT 3.7 implementation of GLUT for Win32 supports the joystick API and
        ///         joystick input, but does so through the dated <c>joySetCapture</c> and
        ///         <c>joyGetPosEx</c> Win32 Multimedia API.  The GLUT 3.7 joystick support for
        ///         Win32 has all the limitations of the Win32 Multimedia API joystick support.
        ///         A future implementation of GLUT for Win32 may use DirectInput.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutJoystickFunc" />
        // GLUTAPI void APIENTRY glutForceJoystickFunc(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutForceJoystickFunc();
        #endregion glutForceJoystickFunc()
        #endregion Device Control Sub-API

        #region Game Mode Sub-API
        #region glutGameModeString(string str)
        /// <summary>
        ///     Sets the game mode configuration via a string.
        /// </summary>
        /// <param name="str">
        ///     string for selecting a game mode configuration.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         <b>glutGameModeString</b> sets the game mode configuration via a string.  The
        ///         game mode configuration string for GLUT's fullscreen game mode describes the
        ///         suitable screen width and height in pixels, the pixel depth in bits, and the
        ///         video refresh frequency in hertz.  The game mode configuration string can
        ///         also specify a window system dependent display mode.
        ///     </para>
        ///     <para>
        ///         The string is a list of zero or more capability descriptions seperated by
        ///         spaces and tabs.  Each capability description is a capability name that is
        ///         followed by a comparator and a numeric value.  (Unlike the display mode
        ///         string specified using <see cref="glutInitDisplayString" />, the comparator
        ///         and numeric value are <i>not</i> optional.)  For example, <c>"width>=640"</c>
        ///         and <c>"bpp=32"</c> are both valid criteria.
        ///     </para>
        ///     <para>
        ///         The capability descriptions are translated into a set of criteria used to
        ///         select the appropriate game mode configuration.
        ///     </para>
        ///     <para>
        ///         The criteria are matched in strict left to right order of precdence.  That
        ///         is, the first specified criteria (leftmost) takes precedence over the later
        ///         criteria for non-exact criteria (greater than, less than, etc. comparators).
        ///         Exact criteria (equal, not equal compartors) must match exactly so precedence
        ///         is not relevant.
        ///     </para>
        ///     <para>
        ///         The numeric value is an integer that is parsed according to ANSI C's
        ///         <c>strtol(str, strptr, 0)</c> behavior.  This means that decimal, octal
        ///         (leading 0), and hexidecimal values (leading 0x) are accepeted.
        ///     </para>
        ///     <para>
        ///         The valid compartors are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>=</term>
        ///                 <description>Equal.</description>
        ///             </item>
        ///             <item>
        ///                 <term>!=</term>
        ///                 <description>Not equal.</description>
        ///             </item>
        ///             <item>
        ///                 <term>&lt;</term>
        ///                 <description>
        ///                     Less than and preferring larger difference (the least is best).
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>&gt;</term>
        ///                 <description>
        ///                     Greater than and preferring larger differences (the most is
        ///                     best).
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>&lt;=</term>
        ///                 <description>
        ///                     Less than or equal and preferring larger difference (the least is
        ///                     best).
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>&gt;=</term>
        ///                 <description>
        ///                     Greater than or equal and preferring more instead of less.  This
        ///                     comparator is useful for allocating resources like color precsion
        ///                     or depth buffer precision where the maximum precison is generally
        ///                     preferred.  Contrast with the tilde (~) comprator.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>~</term>
        ///                 <description>
        ///                     Greater than or equal but preferring less instead of more.  This
        ///                     compartor is useful for allocating resources such as stencil bits
        ///                     or auxillary color buffers where you would rather not over
        ///                     allocate.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         The valid capability names are:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>bpp</term>
        ///                 <description>Bits per pixel for the frame buffer.</description>
        ///             </item>
        ///             <item>
        ///                 <term>height</term>
        ///                 <description>Height of the screen in pixels.</description>
        ///             </item>
        ///             <item>
        ///                 <term>hertz</term>
        ///                 <description>Video refresh rate of the screen in hertz.</description>
        ///             </item>
        ///             <item>
        ///                 <term>num</term>
        ///                 <description>
        ///                     Number of the window system depenedent display mode
        ///                     configuration.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>width</term>
        ///                 <description>Width of the screen in pixels.</description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         An additional compact screen resolution description format is supported.
        ///         This compact description convienently encodes the screen resolution
        ///         description in a single phrase.  For example, <c>"640x480:16@60"</c>
        ///         requests a 640 by 480 pixel screen with 16 bits per pixel at a 60 hertz video
        ///         refresh rate.  A compact screen resolution description can be mixed with
        ///         conventional capability descriptions.
        ///     </para>
        ///     <para>
        ///         The compact screen resolution description format is as follows:
        ///     </para>
        ///     <para>
        ///         <c>[width "x" height][":" bitsPerPixel]["@" videoRate]</c>
        ///     </para>
        ///     <para>
        ///         Unspecifed capability descriptions will result in unspecified criteria being
        ///         generated.  These unspecified criteria help <b>glutGameModeString</b> behave
        ///         sensibly with terse game mode description strings.
        ///     </para>
        /// </remarks>
        // GLUTAPI void APIENTRY glutGameModeString(const char *string);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutGameModeString(string str);
        #endregion glutGameModeString(string str)

        #region int glutEnterGameMode()
        /// <summary>
        ///     Enters GLUT's game mode.
        /// </summary>
        /// <returns>
        ///     This is defined in the header as an <c>int</c>, however, from the
        ///     documentation that I've seen, I believe it should be a <c>void</c>.  You
        ///     should check your game mode state after entering game mode with:
        ///     <see cref="glutGameModeGet"/> passing appropriate parameters.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         <b>glutEnterGameMode</b> is designed to enable high-performance fullscreen
        ///         GLUT rendering, possibly at a different screen display format.  Calling
        ///         <b>glutEnterGameMode</b> creates a special fullscreen GLUT window (with its
        ///         own callbacks and OpenGL rendering context state).  If the game mode string
        ///         describes a possible screen display format, GLUT also changes the screen
        ///         display format to the one described by the game mode string.
        ///     </para>
        ///     <para>
        ///         When game mode is entered, certain GLUT functionality is disable to
        ///         facilitate high-performance fullscreen rendering.  GLUT pop-up menus are not
        ///         available while in game mode.  Other created windows and subwindows are not
        ///         displayed in GLUT game mode.  Game mode will also hide all other applications
        ///         running on the computer's display screen.  The intent of these restrictions
        ///         is to eliminate window clipping issues, permit screen display format changes,
        ///         and permit fullscreen rendering optimization such as page flipping for
        ///         fullscreen buffer swaps.
        ///     </para>
        ///     <para>
        ///         The following GLUT routines are ignored in game mode:
        ///     </para>
        ///     <para>
        ///         <list type="bullet">
        ///             <item><see cref="glutFullScreen" /></item>
        ///             <item><see cref="glutHideWindow" /></item>
        ///             <item><see cref="glutIconifyWindow" /></item>
        ///             <item><see cref="glutPopWindow" /></item>
        ///             <item><see cref="glutPositionWindow" /></item>
        ///             <item><see cref="glutPushWindow" /></item>
        ///             <item><see cref="glutReshapeWindow" /></item>
        ///             <item><see cref="glutSetIconTitle" /></item>
        ///             <item><see cref="glutSetWindowTitle" /></item>
        ///             <item><see cref="glutShowWindow" /></item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         <b>glutEnterGameMode</b> can be called when already in game mode.  This will
        ///         destroy the previous game mode window (including any OpenGL rendering state)
        ///         and create a new game mode window with a new OpenGL rendering context.  Also
        ///         if <b>glutEnterGameMode</b> is called when already in game mode and if the
        ///         game mode string has changed and describes a possible screen display format,
        ///         the new screen display format takes effect.  A reshape callback is generated
        ///         if the game mode window changes size due to a screen display format change.
        ///     </para>
        ///     <para>
        ///         Re-entering game mode provides a mechanism for changing the screen display
        ///         format while already in game mode.  Note though that the game mode window's
        ///         OpenGL state is lost in this process and the application is responsible for
        ///         re-initializing the newly created game mode window OpenGL state when
        ///         re-entering game mode.
        ///     </para>
        ///     <para>
        ///         Game mode cannot be entered while pop-up menus are in use.
        ///     </para>
        ///     <para>
        ///         Note that the <b>glutEnterGameMode</b> and <see cref="glutFullScreen" />
        ///         routines operate differently.  <see cref="glutFullScreen" /> simply makes the
        ///         current window match the size of the screen.  <see cref="glutFullScreen" />
        ///         does not change the screen display format and does not disable any GLUT
        ///         features such as pop-up menus; <see cref="glutFullScreen" /> continues to
        ///         operate in a "windowed" mode of operation.  <b>glutEnterGameMode</b>
        ///         creates a new window style, possibly changes the screen display mode, limits
        ///         GLUT functionality, and hides other applications.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutGameModeGet" />
        /// <seealso cref="glutGameModeString" />
        /// <seealso cref="glutInitDisplayString" />
        /// <seealso cref="glutLeaveGameMode" />
        // GLUTAPI int APIENTRY glutEnterGameMode(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutEnterGameMode();
        #endregion int glutEnterGameMode()

        #region glutLeaveGameMode()
        /// <summary>
        ///     Leaves GLUT's game mode.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <b>glutLeaveGameMode</b> leaves the GLUT game mode and returns the screen
        ///         display format to its default format.
        ///     </para>
        ///     <para>
        ///         After leaving game mode, the GLUT functionality disabled in game mode is
        ///         available again.  The game mode window (and its OpenGL rendering state) is
        ///         destroyed when leaving game mode.  Any windows and subwindows created before
        ///         entering the game mode are displayed in their previous locations.  The OpenGL
        ///         state of normal GLUT windows and subwindows is not disturbed by entering
        ///         and/or leaving game mode.
        ///     </para>
        /// </remarks>
        /// <seealso cref="glutEnterGameMode" />
        /// <seealso cref="glutGameModeGet" />
        /// <seealso cref="glutGameModeString" />
        /// <seealso cref="glutInitDisplayString" />
        // GLUTAPI void APIENTRY glutLeaveGameMode(void);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutLeaveGameMode();
        #endregion glutLeaveGameMode()

        #region int glutGameModeGet(int mode)
        /// <summary>
        ///     Retrieves GLUT device information represented by integers.
        /// </summary>
        /// <param name="mode">
        ///     Name of game mode information to retrieve.
        /// </param>
        /// <returns>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="GLUT_GAME_MODE_ACTIVE" /></term>
        ///                 <description>
        ///                     Non-zero if GLUT's game mode is active; zero if not active.  Game
        ///                     mode is not active initially.  Game mode becomes active when
        ///                     <see cref="glutEnterGameMode" /> is called.  Game mode becomes
        ///                     inactive when <see cref="glutLeaveGameMode" /> is called.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_GAME_MODE_POSSIBLE" /></term>
        ///                 <description>
        ///                     Non-zero if the game mode string last specified to
        ///                     <see cref="glutGameModeString" /> is a possible game mode
        ///                     configuration; zero otherwise.  Being "possible" does not
        ///                     guarantee that if game mode is entered with
        ///                     <see cref="glutEnterGameMode" /> that the display settings will
        ///                     actually changed.  <see cref="GLUT_GAME_MODE_DISPLAY_CHANGED" />
        ///                     should be called once game mode is entered to determine if the
        ///                     display mode is actually changed.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_GAME_MODE_WIDTH" /></term>
        ///                 <description>
        ///                     Width in pixels of the screen when game mode is activated.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_GAME_MODE_HEIGHT" /></term>
        ///                 <description>
        ///                     Height in pixels of the screen when game mode is activated.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_GAME_MODE_PIXEL_DEPTH" /></term>
        ///                 <description>
        ///                     Pixel depth of the screen when game mode is activiated.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_GAME_MODE_REFRESH_RATE" /></term>
        ///                 <description>
        ///                     Screen refresh rate in cyles per second (hertz) when game mode is
        ///                     activated.  Zero is returned if the refresh rate is unknown or
        ///                     cannot be queried.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="GLUT_GAME_MODE_DISPLAY_CHANGED" /></term>
        ///                 <description>
        ///                     Non-zero if entering game mode actually changed the display
        ///                     settings.  If the game mode string is not possible or the display
        ///                     mode could not be changed for any other reason, zero is returned.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <b>glutGameModeGet</b> retrieves GLUT game mode information represented by
        ///     integers.  The <i>mode</i> parameter determines what type of game mode
        ///     information to return.  Requesting game mode information for an invalid GLUT
        ///     game mode information name returns negative one.
        /// </remarks>
        /// <seealso cref="glutDeviceGet" />
        /// <seealso cref="glutEnterGameMode" />
        /// <seealso cref="glutGameModeString" />
        /// <seealso cref="glutGet" />
        /// <seealso cref="glutLayerGet" />
        /// <seealso cref="glutLeaveGameMode" />
        // GLUTAPI int APIENTRY glutGameModeGet(GLenum mode);
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutGameModeGet(int mode);
        #endregion int glutGameModeGet(int mode)
        #endregion Game Mode Sub-API

        #region FreeGLUT Additions
        #region Process Loop
        #region glutMainLoopEvent()
        /// <summary>
        ///     Performs the main loop event and returns control.
        /// </summary>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutMainLoopEvent();
        #endregion glutMainLoopEvent()

        #region glutLeaveMainLoop()
        /// <summary>
        ///     Leaves the main loop.
        /// </summary>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutLeaveMainLoop();
        #endregion glutLeaveMainLoop()
        #endregion Process Loop

        #region Window Callbacks
        #region glutMouseWheelFunc([In] MouseWheelCallback func)
        /// <summary>
        ///     Sets the mouse wheel callback.
        /// </summary>
        /// <param name="func">
        ///     The new mouse wheel callback function.  See <see cref="MouseWheelCallback" />.
        /// </param>
        public static void glutMouseWheelFunc([In] MouseWheelCallback func) {
            mouseWheelCallback = func;
            __glutMouseWheelFunc(mouseWheelCallback);
        }
        #endregion glutMouseWheelFunc([In] MouseWheelCallback func)

        #region glutCloseFunc([In] CloseCallback func)
        /// <summary>
        ///     Sets the close callback.
        /// </summary>
        /// <param name="func">
        ///     The new close callback function.  See <see cref="CloseCallback" />.
        /// </param>
        public static void glutCloseFunc([In] CloseCallback func) {
            closeCallback = func;
            __glutCloseFunc(closeCallback);
        }
        #endregion glutCloseFunc([In] CloseCallback func)

        #region glutWMCloseFunc([In] WindowCloseCallback func)
        /// <summary>
        ///     Sets the window close callback for the current window.
        /// </summary>
        /// <param name="func">
        ///     The new window close callback function.  See <see cref="WindowCloseCallback" />.
        /// </param>
        public static void glutWMCloseFunc([In] WindowCloseCallback func) {
            windowCloseCallback = func;
            __glutWMCloseFunc(windowCloseCallback);
        }
        #endregion glutWMCloseFunc([In] WindowCloseCallback func)

        #region glutMenuDestroyFunc([In] MenuDestroyCallback func)
        /// <summary>
        ///     Sets the menu destroy callback.
        /// </summary>
        /// <param name="func">
        ///     The new menu destroy callback function.  See <see cref="MenuDestroyCallback" />.
        /// </param>
        public static void glutMenuDestroyFunc([In] MenuDestroyCallback func) {
            menuDestroyCallback = func;
            __glutMenuDestroyFunc(menuDestroyCallback);
        }
        #endregion glutMenuDestroyFunc([In] MenuDestroyCallback func)
        #endregion Window Callbacks

        #region State
        #region glutSetOption(int optionFlag, int value)
        /// <summary>
        ///     Sets simple GLUT state represented by integers.
        /// </summary>
        /// <param name="optionFlag">
        ///     The option to set.
        /// </param>
        /// <param name="value">
        ///     The value to set for the option.
        /// </param>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSetOption(int optionFlag, int value);
        #endregion glutSetOption(int optionFlag, int value)

        #region IntPtr glutGetWindowData()
        /// <summary>
        ///     Get the user data for the current window.
        /// </summary>
        /// <returns>
        ///     An <see cref="IntPtr" /> associated with the current window as set with <see cref="glutSetupWindowData" />.
        /// </returns>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr glutGetWindowData();
        #endregion IntPtr glutGetWindowData()

        #region glutSetupWindowData(IntPtr data)
        /// <summary>
        ///     Set the user data for the current window.
        /// </summary>
        /// <param name="data">
        ///     Arbitrary client-supplied <see cref="IntPtr" />.
        /// </param>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSetupWindowData(IntPtr data);
        #endregion glutSetupWindowData(IntPtr data)

        #region IntPtr glutGetMenuData()
        /// <summary>
        ///     Rerieves user data from a menu.
        /// </summary>
        /// <returns>
        ///     A previously stored arbitrary user data <see cref="IntPtr" /> from the current menu.
        /// </returns>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr glutGetMenuData();
        #endregion IntPtr glutGetMenuData()

        #region glutSetMenuData(IntPtr data)
        /// <summary>
        ///     Stores user data in a menu.
        /// </summary>
        /// <param name="data">
        ///     An arbitrary client <see cref="IntPtr" />.
        /// </param>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSetMenuData(IntPtr data);
        #endregion glutSetMenuData(IntPtr data)
        #endregion State

        #region Font
        #region int glutBitmapHeight(IntPtr font)
        /// <summary>
        ///     Returns the height of a given font, in pixels.
        /// </summary>
        /// <param name="font">
        ///     A bitmapped font identifier.
        /// </param>
        /// <returns>
        ///     Returns 0 if font is invalid, otherwise, the font's height, in pixels.
        /// </returns>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int glutBitmapHeight(IntPtr font);
        #endregion int glutBitmapHeight(IntPtr font)

        #region float glutStrokeHeight(IntPtr font)
        /// <summary>
        ///     Returns the height of a given font.
        /// </summary>
        /// <param name="font">
        ///     A GLUT stroked font identifier.
        /// </param>
        /// <returns>
        ///     Returns 0 if fontID is invalid, otherwise, the height of the font in pixels.
        /// </returns>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern float glutStrokeHeight(IntPtr font);
        #endregion float glutStrokeHeight(IntPtr font)

        #region glutBitmapString(IntPtr font, string str)
        /// <summary>
        ///     Draw a string of bitmapped characters.
        /// </summary>
        /// <param name="font">
        ///     A bitmapped font identifier.
        /// </param>
        /// <param name="str">
        ///     The string to draw.
        /// </param>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutBitmapString(IntPtr font, string str);
        #endregion glutBitmapString(IntPtr font, string str)

        #region glutStrokeString(IntPtr font, string str)
        /// <summary>
        ///     Draw a string of stroked characters.
        /// </summary>
        /// <param name="font">
        ///     A GLUT stroked font identifier.
        /// </param>
        /// <param name="str">
        ///     The string to draw.
        /// </param>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutStrokeString(IntPtr font, string str);
        #endregion glutStrokeString(IntPtr font, string str)
        #endregion Font

        #region Geometry
        #region glutWireRhombicDodecahedron()
        /// <summary>
        ///     Draw a wireframe rhombic dodecahedron.
        /// </summary>
        /// <remarks>
        ///     This function draws a wireframe dodecahedron whose facets are rhombic and whose vertices are at unit radius.
        ///     No facet lies normal to any coordinate axes. The polyhedron is centered at the origin.
        /// </remarks>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutWireRhombicDodecahedron();
        #endregion glutWireRhombicDodecahedron()

        #region glutSolidRhombicDodecahedron()
        /// <summary>
        ///     Draw a solid rhombic dodecahedron.
        /// </summary>
        /// <remarks>
        ///     This function draws a solid-shaded dodecahedron whose facets are rhombic and whose vertices are at unit radius.
        ///     No facet lies normal to any coordinate axes. The polyhedron is centered at the origin.
        /// </remarks>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSolidRhombicDodecahedron();
        #endregion glutSolidRhombicDodecahedron()

        #region glutWireSierpinskiSponge(int levels, double[] offset, double scale)
        /// <summary>
        ///     Draw a wireframe Spierspinski's sponge
        /// </summary>
        /// <param name="levels">
        ///     Recursive depth.
        /// </param>
        /// <param name="offset">
        ///     Location vector.
        /// </param>
        /// <param name="scale">
        ///     Relative size.
        /// </param>
        /// <remarks>
        ///     This function recursively draws a few levels of Sierpinski's Sponge in wireframe.
        ///     If <paramref name="levels" /> is 0, draws 1 tetrahedron. The <paramref name="offset" /> is a translation.
        ///     The z axis is normal to the base. The sponge is centered at the origin.
        /// </remarks>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutWireSierpinskiSponge(int levels, double[] offset, double scale);
        #endregion glutWireSierpinskiSponge(int levels, double[] offset, double scale)

        #region glutSolidSierpinskiSponge(int levels, double[] offset, double scale)
        /// <summary>
        ///     Draw a solid Spierspinski's sponge.
        /// </summary>
        /// <param name="levels">
        ///     Recursive depth.
        /// </param>
        /// <param name="offset">
        ///     Location vector.
        /// </param>
        /// <param name="scale">
        ///     Relative size.
        /// </param>
        /// <remarks>
        ///     This function recursively draws a few levels of a solid-shaded Sierpinski's Sponge. If <paramref name="levels" /> is 0,
        ///     draws 1 tetrahedron. The <paramref name="offset" /> is a translation. The z axis is normal to the base. The sponge is
        ///     centered at the origin.
        /// </remarks>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSolidSierpinskiSponge(int levels, double[] offset, double scale);
        #endregion glutSolidSierpinskiSponge(int levels, double[] offset, double scale)

        #region glutWireCylinder(double radius, double height, int slices, int stacks)
        /// <summary>
        ///     Draw a wireframe cylinder.
        /// </summary>
        /// <param name="radius">
        ///     Radius of cylinder.
        /// </param>
        /// <param name="height">
        ///     Z height.
        /// </param>
        /// <param name="slices">
        ///     Number of divisions around the z axis.
        /// </param>
        /// <param name="stacks">
        ///     Number of divisions along the z axis.
        /// </param>
        /// <remarks>
        ///     Draws a wireframe of a cylinder, the center of whose base is at the origin, and whose axis parallels the z axis.
        /// </remarks>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutWireCylinder(double radius, double height, int slices, int stacks);
        #endregion glutWireCylinder(double radius, double height, int slices, int stacks)

        #region glutSolidCylinder(double radius, double height, int slices, int stacks)
        /// <summary>
        ///     Draw a solid cylinder.
        /// </summary>
        /// <param name="radius">
        ///     Radius of cylinder.
        /// </param>
        /// <param name="height">
        ///     Z height.
        /// </param>
        /// <param name="slices">
        ///     Number of divisions around the z axis.
        /// </param>
        /// <param name="stacks">
        ///     Number of divisions along the z axis.
        /// </param>
        /// <remarks>
        ///     Draws a solid of a cylinder, the center of whose base is at the origin, and whose axis parallels the z axis.
        /// </remarks>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void glutSolidCylinder(double radius, double height, int slices, int stacks);
        #endregion glutSolidCylinder(double radius, double height, int slices, int stacks)
        #endregion Geometry

        #region Extension
        #region IntPtr glutGetProcAddress(string procName)
        /// <summary>
        ///     Determine if an procedure or extension is available.
        /// </summary>
        /// <param name="procName">
        ///     Procedure name.
        /// </param>
        /// <returns>
        ///     <para>
        ///         Given a function name, searches for the function (or "procedure", hence "Proc") in internal tables.
        ///         If the function is found, a pointer to the function is returned. If the function is not found,
        ///         <see cref="IntPtr.Zero" /> is returned.
        ///     </para>
        ///     <para>
        ///         In addition to an internal freeglut table, this function will also consult glX (on X systems) or
        ///         wgl (on WIN32 and WINCE), if the freeglut tables do not have the requested function. It should
        ///         return any OpenGL, glX, or wgl function if those functions are available.
        ///     </para>
        /// </returns>
        [DllImport(FREEGLUT_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr glutGetProcAddress(string procName);
        #endregion IntPtr glutGetProcAddress(string procName)
        
	#region void GLUTprocDelegate()
	// typedef void (*GLUTproc)();
        /// <summary>
	///
        /// </summary>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GLUTprocDelegate();
        #endregion void GLUTprocDelegate()
        #endregion Extension
        #endregion FreeGLUT Additions
    }
}
