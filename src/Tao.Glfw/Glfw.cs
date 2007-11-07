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
using System.Runtime.InteropServices;
using System.Security;
using Tao.OpenGl;

namespace Tao.Glfw {
    #region Class Documentation
    /// <summary>
    ///     GLFW (OpenGL Framework) binding for .NET, implementing GLFW 2.6.0.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Marcus Geelnard is the author of GLFW, more information can be found on the
    ///         GLFW homepage, http://glfw.sourceforge.net.
    ///     </para>
    ///     <para>
    ///         GLFW is a portable API (Application Program Interface) that handles operating
    ///         system specific tasks related to OpenGL programming.  While OpenGL in general
    ///         is portable, easy to use and often results in tidy and compact code, the
    ///         operating system specific mechanisms that are required to set up and manage an
    ///         OpenGL window are quite the opposite.  GLFW tries to remedy this by providing
    ///         the following functionality:
    ///     </para>
    ///     <para>
    ///         <list type="bullet">
    ///             <item>Opening and managing an OpenGL window.</item>
    ///             <item>Keyboard, mouse and joystick input.</item>
    ///             <item>A high precision timer.</item>
    ///             <item>Multi threading support.</item>
    ///             <item>Support for querying and using OpenGL extensions.</item>
    ///             <item>Image file loading support.</item>
    ///         </list>
    ///     </para>
    ///     <para>
    ///         All this functionality is implemented as a set of easy-to-use functions, which
    ///         makes it possible to write an OpenGL application framework in just a few lines
    ///         of code.  The GLFW API is completely operating system and platform independent,
    ///         which makes it very simple to port GLFW based OpenGL applications to a variety
    ///         of platforms.  Currently supported platforms are:
    ///     </para>
    ///     <para>
    ///         <list type="bullet">
    ///             <item>Microsoft Windows 95/98/ME/NT/2000/XP/2003 Server.</item>
    ///             <item>
    ///                 Unix or Unix-like systems running the X Window System, e.g. Linux,
    ///                 IRIX, FreeBSD, Solaris, QNX, and Mac OSX.
    ///             </item>
    ///             <item>
    ///                 Mac OSX (Carbon), only a subset of GLFW is available at this time.
    ///             </item>
    ///             <item>
    ///                 AmigaOS, only a subset of GLFW is available at this time.
    ///             </item>
    ///         </list>
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public static class Glfw
    {

		#region Private Constants

		#region string GLFW_NATIVE_LIBRARY
		/// <summary>
		/// Specifies the GLFW native library used in the bindings
		/// </summary>
		/// <remarks>
		/// The Windows dll is specified here universally - note that
		/// under Mono the non-windows native library can be mapped using
		/// the ".config" file mechanism.  Kudos to the Mono team for this
		/// simple yet elegant solution.
		/// </remarks>
		private const string GLFW_NATIVE_LIBRARY = "glfw.dll";
		#endregion string GLFW_NATIVE_LIBRARY

		#endregion Private Constants

        // --- Fields ---
        #region Public Constants

        #region Version
        #region GLFW_VERSION_MAJOR
        /// <summary>
        ///     Major version number.
        /// </summary>
        // #define GLFW_VERSION_MAJOR 2
        public const int GLFW_VERSION_MAJOR = 2;
        #endregion GLFW_VERSION_MAJOR

        #region GLFW_VERSION_MINOR
        /// <summary>
        ///     Minor version number.
        /// </summary>
        // #define GLFW_VERSION_MINOR 5
        public const int GLFW_VERSION_MINOR = 6;
        #endregion GLFW_VERSION_MINOR

        #region GLFW_VERSION_REVISION
        /// <summary>
        ///     Revision version number.
        /// </summary>
        // #define GLFW_VERSION_REVISION 0
        public const int GLFW_VERSION_REVISION = 0;
        #endregion GLFW_VERSION_REVISION
        #endregion Version

        #region Input State
        #region GLFW_RELEASE
        /// <summary>
        ///     Button or key is not pressed.
        /// </summary>
        // #define GLFW_RELEASE 0
        public const int GLFW_RELEASE = 0;
        #endregion GLFW_RELEASE

        #region GLFW_PRESS
        /// <summary>
        ///     Button or key is pressed.
        /// </summary>
        // #define GLFW_PRESS 1
        public const int GLFW_PRESS = 1;
        #endregion GLFW_PRESS
        #endregion Input States

        #region Keyboard Keys
        #region GLFW_KEY_UNKNOWN
        /// <summary>
        ///     Unknown key.
        /// </summary>
        // #define GLFW_KEY_UNKNOWN -1
        public const int GLFW_KEY_UNKNOWN = -1;
        #endregion GLFW_KEY_UNKNOWN

        #region GLFW_KEY_SPACE
        /// <summary>
        ///     Space bar.
        /// </summary>
        // #define GLFW_KEY_SPACE 32
        public const int GLFW_KEY_SPACE = 32;
        #endregion GLFW_KEY_SPACE

        #region GLFW_KEY_SPECIAL
        /// <summary>
        ///     Delineates start of 'special' keys.
        /// </summary>
        // #define GLFW_KEY_SPECIAL 256
        public const int GLFW_KEY_SPECIAL = 256;
        #endregion GLFW_KEY_SPECIAL

        #region GLFW_KEY_ESC
        /// <summary>
        ///     Escape.
        /// </summary>
        // #define GLFW_KEY_ESC (GLFW_KEY_SPECIAL+1)
        public const int GLFW_KEY_ESC = GLFW_KEY_SPECIAL + 1;
        #endregion GLFW_KEY_ESC

        #region GLFW_KEY_F1
        /// <summary>
        ///     Function key 1.
        /// </summary>
        // #define GLFW_KEY_F1 (GLFW_KEY_SPECIAL+2)
        public const int GLFW_KEY_F1 = GLFW_KEY_SPECIAL + 2;
        #endregion GLFW_KEY_F1

        #region GLFW_KEY_F2
        /// <summary>
        ///     Function key 2.
        /// </summary>
        // #define GLFW_KEY_F2 (GLFW_KEY_SPECIAL+3)
        public const int GLFW_KEY_F2 = GLFW_KEY_SPECIAL + 3;
        #endregion GLFW_KEY_F2

        #region GLFW_KEY_F3
        /// <summary>
        ///     Function key 3.
        /// </summary>
        // #define GLFW_KEY_F3 (GLFW_KEY_SPECIAL+4)
        public const int GLFW_KEY_F3 = GLFW_KEY_SPECIAL + 4;
        #endregion GLFW_KEY_F3

        #region GLFW_KEY_F4
        /// <summary>
        ///     Function key 4.
        /// </summary>
        // #define GLFW_KEY_F4 (GLFW_KEY_SPECIAL+5)
        public const int GLFW_KEY_F4 = GLFW_KEY_SPECIAL + 5;
        #endregion GLFW_KEY_F4

        #region GLFW_KEY_F5
        /// <summary>
        ///     Function key 5.
        /// </summary>
        // #define GLFW_KEY_F5 (GLFW_KEY_SPECIAL+6)
        public const int GLFW_KEY_F5 = GLFW_KEY_SPECIAL + 6;
        #endregion GLFW_KEY_F5

        #region GLFW_KEY_F6
        /// <summary>
        ///     Function key 6.
        /// </summary>
        // #define GLFW_KEY_F6 (GLFW_KEY_SPECIAL+7)
        public const int GLFW_KEY_F6 = GLFW_KEY_SPECIAL + 7;
        #endregion GLFW_KEY_F6

        #region GLFW_KEY_F7
        /// <summary>
        ///     Function key 7.
        /// </summary>
        // #define GLFW_KEY_F7 (GLFW_KEY_SPECIAL+8)
        public const int GLFW_KEY_F7 = GLFW_KEY_SPECIAL + 8;
        #endregion GLFW_KEY_F7

        #region GLFW_KEY_F8
        /// <summary>
        ///     Function key 8.
        /// </summary>
        // #define GLFW_KEY_F8 (GLFW_KEY_SPECIAL+9)
        public const int GLFW_KEY_F8 = GLFW_KEY_SPECIAL + 9;
        #endregion GLFW_KEY_F8

        #region GLFW_KEY_F9
        /// <summary>
        ///     Function key 9.
        /// </summary>
        // #define GLFW_KEY_F9 (GLFW_KEY_SPECIAL+10)
        public const int GLFW_KEY_F9 = GLFW_KEY_SPECIAL + 10;
        #endregion GLFW_KEY_F9

        #region GLFW_KEY_F10
        /// <summary>
        ///     Function key 10.
        /// </summary>
        // #define GLFW_KEY_F10 (GLFW_KEY_SPECIAL+11)
        public const int GLFW_KEY_F10 = GLFW_KEY_SPECIAL + 11;
        #endregion GLFW_KEY_F10

        #region GLFW_KEY_F11
        /// <summary>
        ///     Function key 11.
        /// </summary>
        // #define GLFW_KEY_F11 (GLFW_KEY_SPECIAL+12)
        public const int GLFW_KEY_F11 = GLFW_KEY_SPECIAL + 12;
        #endregion GLFW_KEY_F11

        #region GLFW_KEY_F12
        /// <summary>
        ///     Function key 12.
        /// </summary>
        // #define GLFW_KEY_F12 (GLFW_KEY_SPECIAL+13)
        public const int GLFW_KEY_F12 = GLFW_KEY_SPECIAL + 13;
        #endregion GLFW_KEY_F12

        #region GLFW_KEY_F13
        /// <summary>
        ///     Function key 13.
        /// </summary>
        // #define GLFW_KEY_F13 (GLFW_KEY_SPECIAL+14)
        public const int GLFW_KEY_F13 = GLFW_KEY_SPECIAL + 14;
        #endregion GLFW_KEY_F13

        #region GLFW_KEY_F14
        /// <summary>
        ///     Function key 14.
        /// </summary>
        // #define GLFW_KEY_F14 (GLFW_KEY_SPECIAL+15)
        public const int GLFW_KEY_F14 = GLFW_KEY_SPECIAL + 15;
        #endregion GLFW_KEY_F14

        #region GLFW_KEY_F15
        /// <summary>
        ///     Function key 15.
        /// </summary>
        // #define GLFW_KEY_F15 (GLFW_KEY_SPECIAL+16)
        public const int GLFW_KEY_F15 = GLFW_KEY_SPECIAL + 16;
        #endregion GLFW_KEY_F15

        #region GLFW_KEY_F16
        /// <summary>
        ///     Function key 16.
        /// </summary>
        // #define GLFW_KEY_F16 (GLFW_KEY_SPECIAL+17)
        public const int GLFW_KEY_F16 = GLFW_KEY_SPECIAL + 17;
        #endregion GLFW_KEY_F16

        #region GLFW_KEY_F17
        /// <summary>
        ///     Function key 17.
        /// </summary>
        // #define GLFW_KEY_F17 (GLFW_KEY_SPECIAL+18)
        public const int GLFW_KEY_F17 = GLFW_KEY_SPECIAL + 18;
        #endregion GLFW_KEY_F17

        #region GLFW_KEY_F18
        /// <summary>
        ///     Function key 18.
        /// </summary>
        // #define GLFW_KEY_F18 (GLFW_KEY_SPECIAL+19)
        public const int GLFW_KEY_F18 = GLFW_KEY_SPECIAL + 19;
        #endregion GLFW_KEY_F18

        #region GLFW_KEY_F19
        /// <summary>
        ///     Function key 19.
        /// </summary>
        // #define GLFW_KEY_F19 (GLFW_KEY_SPECIAL+20)
        public const int GLFW_KEY_F19 = GLFW_KEY_SPECIAL + 20;
        #endregion GLFW_KEY_F19

        #region GLFW_KEY_F20
        /// <summary>
        ///     Function key 20.
        /// </summary>
        // #define GLFW_KEY_F20 (GLFW_KEY_SPECIAL+21)
        public const int GLFW_KEY_F20 = GLFW_KEY_SPECIAL + 21;
        #endregion GLFW_KEY_F20

        #region GLFW_KEY_F21
        /// <summary>
        ///     Function key 21.
        /// </summary>
        // #define GLFW_KEY_F21 (GLFW_KEY_SPECIAL+22)
        public const int GLFW_KEY_F21 = GLFW_KEY_SPECIAL + 22;
        #endregion GLFW_KEY_F21

        #region GLFW_KEY_F22
        /// <summary>
        ///     Function key 22.
        /// </summary>
        // #define GLFW_KEY_F22 (GLFW_KEY_SPECIAL+23)
        public const int GLFW_KEY_F22 = GLFW_KEY_SPECIAL + 23;
        #endregion GLFW_KEY_F22

        #region GLFW_KEY_F23
        /// <summary>
        ///     Function key 23.
        /// </summary>
        // #define GLFW_KEY_F23 (GLFW_KEY_SPECIAL+24)
        public const int GLFW_KEY_F23 = GLFW_KEY_SPECIAL + 24;
        #endregion GLFW_KEY_F23

        #region GLFW_KEY_F24
        /// <summary>
        ///     Function key 24.
        /// </summary>
        // #define GLFW_KEY_F24 (GLFW_KEY_SPECIAL+25)
        public const int GLFW_KEY_F24 = GLFW_KEY_SPECIAL + 25;
        #endregion GLFW_KEY_F24

        #region GLFW_KEY_F25
        /// <summary>
        ///     Function key 25.
        /// </summary>
        // #define GLFW_KEY_F25 (GLFW_KEY_SPECIAL+26)
        public const int GLFW_KEY_F25 = GLFW_KEY_SPECIAL + 26;
        #endregion GLFW_KEY_F25

        #region GLFW_KEY_UP
        /// <summary>
        ///     Cursor up.
        /// </summary>
        // #define GLFW_KEY_UP (GLFW_KEY_SPECIAL+27)
        public const int GLFW_KEY_UP = GLFW_KEY_SPECIAL + 27;
        #endregion GLFW_KEY_UP

        #region GLFW_KEY_DOWN
        /// <summary>
        ///     Cursor down.
        /// </summary>
        // #define GLFW_KEY_DOWN (GLFW_KEY_SPECIAL+28)
        public const int GLFW_KEY_DOWN = GLFW_KEY_SPECIAL + 28;
        #endregion GLFW_KEY_DOWN

        #region GLFW_KEY_LEFT
        /// <summary>
        ///     Cursor left.
        /// </summary>
        // #define GLFW_KEY_LEFT (GLFW_KEY_SPECIAL+29)
        public const int GLFW_KEY_LEFT = GLFW_KEY_SPECIAL + 29;
        #endregion GLFW_KEY_LEFT

        #region GLFW_KEY_RIGHT
        /// <summary>
        ///     Cursor right.
        /// </summary>
        // #define GLFW_KEY_RIGHT (GLFW_KEY_SPECIAL+30)
        public const int GLFW_KEY_RIGHT = GLFW_KEY_SPECIAL + 30;
        #endregion GLFW_KEY_RIGHT

        #region GLFW_KEY_LSHIFT
        /// <summary>
        ///     Left shift key.
        /// </summary>
        // #define GLFW_KEY_LSHIFT (GLFW_KEY_SPECIAL+31)
        public const int GLFW_KEY_LSHIFT = GLFW_KEY_SPECIAL + 31;
        #endregion GLFW_KEY_LSHIFT

        #region GLFW_KEY_RSHIFT
        /// <summary>
        ///     Right shift key.
        /// </summary>
        // #define GLFW_KEY_RSHIFT (GLFW_KEY_SPECIAL+32)
        public const int GLFW_KEY_RSHIFT = GLFW_KEY_SPECIAL + 32;
        #endregion GLFW_KEY_RSHIFT

        #region GLFW_KEY_LCTRL
        /// <summary>
        ///     Left control key.
        /// </summary>
        // #define GLFW_KEY_LCTRL (GLFW_KEY_SPECIAL+33)
        public const int GLFW_KEY_LCTRL = GLFW_KEY_SPECIAL + 33;
        #endregion GLFW_KEY_LCTRL

        #region GLFW_KEY_RCTRL
        /// <summary>
        ///     Right control key.
        /// </summary>
        // #define GLFW_KEY_RCTRL (GLFW_KEY_SPECIAL+34)
        public const int GLFW_KEY_RCTRL = GLFW_KEY_SPECIAL + 34;
        #endregion GLFW_KEY_RCTRL

        #region GLFW_KEY_LALT
        /// <summary>
        ///     Left alternate function key.
        /// </summary>
        // #define GLFW_KEY_LALT (GLFW_KEY_SPECIAL+35)
        public const int GLFW_KEY_LALT = GLFW_KEY_SPECIAL + 35;
        #endregion GLFW_KEY_LALT

        #region GLFW_KEY_RALT
        /// <summary>
        ///     Right alternate function key.
        /// </summary>
        // #define GLFW_KEY_RALT (GLFW_KEY_SPECIAL+36)
        public const int GLFW_KEY_RALT = GLFW_KEY_SPECIAL + 36;
        #endregion GLFW_KEY_RALT

        #region GLFW_KEY_TAB
        /// <summary>
        ///     Tabulator.
        /// </summary>
        // #define GLFW_KEY_TAB (GLFW_KEY_SPECIAL+37)
        public const int GLFW_KEY_TAB = GLFW_KEY_SPECIAL + 37;
        #endregion GLFW_KEY_TAB

        #region GLFW_KEY_ENTER
        /// <summary>
        ///     Enter.
        /// </summary>
        // #define GLFW_KEY_ENTER (GLFW_KEY_SPECIAL+38)
        public const int GLFW_KEY_ENTER = GLFW_KEY_SPECIAL + 38;
        #endregion GLFW_KEY_ENTER

        #region GLFW_KEY_BACKSPACE
        /// <summary>
        ///     Backspace.
        /// </summary>
        // #define GLFW_KEY_BACKSPACE (GLFW_KEY_SPECIAL+39)
        public const int GLFW_KEY_BACKSPACE = GLFW_KEY_SPECIAL + 39;
        #endregion GLFW_KEY_BACKSPACE

        #region GLFW_KEY_INSERT
        /// <summary>
        ///     Insert.
        /// </summary>
        // #define GLFW_KEY_INSERT (GLFW_KEY_SPECIAL+40)
        public const int GLFW_KEY_INSERT = GLFW_KEY_SPECIAL + 40;
        #endregion GLFW_KEY_INSERT

        #region GLFW_KEY_DEL
        /// <summary>
        ///     Delete.
        /// </summary>
        // #define GLFW_KEY_DEL (GLFW_KEY_SPECIAL+41)
        public const int GLFW_KEY_DEL = GLFW_KEY_SPECIAL + 41;
        #endregion GLFW_KEY_DEL

        #region GLFW_KEY_PAGEUP
        /// <summary>
        ///     Page up.
        /// </summary>
        // #define GLFW_KEY_PAGEUP (GLFW_KEY_SPECIAL+42)
        public const int GLFW_KEY_PAGEUP = GLFW_KEY_SPECIAL + 42;
        #endregion GLFW_KEY_PAGEUP

        #region GLFW_KEY_PAGEDOWN
        /// <summary>
        ///     Page down.
        /// </summary>
        // #define GLFW_KEY_PAGEDOWN (GLFW_KEY_SPECIAL+43)
        public const int GLFW_KEY_PAGEDOWN = GLFW_KEY_SPECIAL + 43;
        #endregion GLFW_KEY_PAGEDOWN

        #region GLFW_KEY_HOME
        /// <summary>
        ///     Home.
        /// </summary>
        // #define GLFW_KEY_HOME (GLFW_KEY_SPECIAL+44)
        public const int GLFW_KEY_HOME = GLFW_KEY_SPECIAL + 44;
        #endregion GLFW_KEY_HOME

        #region GLFW_KEY_END
        /// <summary>
        ///     End.
        /// </summary>
        // #define GLFW_KEY_END (GLFW_KEY_SPECIAL+45)
        public const int GLFW_KEY_END = GLFW_KEY_SPECIAL + 45;
        #endregion GLFW_KEY_END

        #region GLFW_KEY_KP_0
        /// <summary>
        ///     Keypad numeric key 0.
        /// </summary>
        // #define GLFW_KEY_KP_0 (GLFW_KEY_SPECIAL+46)
        public const int GLFW_KEY_KP_0 = GLFW_KEY_SPECIAL + 46;
        #endregion GLFW_KEY_KP_0

        #region GLFW_KEY_KP_1
        /// <summary>
        ///     Keypad numeric key 1.
        /// </summary>
        // #define GLFW_KEY_KP_1 (GLFW_KEY_SPECIAL+47)
        public const int GLFW_KEY_KP_1 = GLFW_KEY_SPECIAL + 47;
        #endregion GLFW_KEY_KP_1

        #region GLFW_KEY_KP_2
        /// <summary>
        ///     Keypad numeric key 2.
        /// </summary>
        // #define GLFW_KEY_KP_2 (GLFW_KEY_SPECIAL+48)
        public const int GLFW_KEY_KP_2 = GLFW_KEY_SPECIAL + 48;
        #endregion GLFW_KEY_KP_2

        #region GLFW_KEY_KP_3
        /// <summary>
        ///     Keypad numeric key 3.
        /// </summary>
        // #define GLFW_KEY_KP_3 (GLFW_KEY_SPECIAL+49)
        public const int GLFW_KEY_KP_3 = GLFW_KEY_SPECIAL + 49;
        #endregion GLFW_KEY_KP_3

        #region GLFW_KEY_KP_4
        /// <summary>
        ///     Keypad numeric key 4.
        /// </summary>
        // #define GLFW_KEY_KP_4 (GLFW_KEY_SPECIAL+50)
        public const int GLFW_KEY_KP_4 = GLFW_KEY_SPECIAL + 50;
        #endregion GLFW_KEY_KP_4

        #region GLFW_KEY_KP_5
        /// <summary>
        ///     Keypad numeric key 5.
        /// </summary>
        // #define GLFW_KEY_KP_5 (GLFW_KEY_SPECIAL+51)
        public const int GLFW_KEY_KP_5 = GLFW_KEY_SPECIAL + 51;
        #endregion GLFW_KEY_KP_5

        #region GLFW_KEY_KP_6
        /// <summary>
        ///     Keypad numeric key 6.
        /// </summary>
        // #define GLFW_KEY_KP_6 (GLFW_KEY_SPECIAL+52)
        public const int GLFW_KEY_KP_6 = GLFW_KEY_SPECIAL + 52;
        #endregion GLFW_KEY_KP_6

        #region GLFW_KEY_KP_7
        /// <summary>
        ///     Keypad numeric key 7.
        /// </summary>
        // #define GLFW_KEY_KP_7 (GLFW_KEY_SPECIAL+53)
        public const int GLFW_KEY_KP_7 = GLFW_KEY_SPECIAL + 53;
        #endregion GLFW_KEY_KP_7

        #region GLFW_KEY_KP_8
        /// <summary>
        ///     Keypad numeric key 8.
        /// </summary>
        // #define GLFW_KEY_KP_8 (GLFW_KEY_SPECIAL+54)
        public const int GLFW_KEY_KP_8 = GLFW_KEY_SPECIAL + 54;
        #endregion GLFW_KEY_KP_8

        #region GLFW_KEY_KP_9
        /// <summary>
        ///     Keypad numeric key 9.
        /// </summary>
        // #define GLFW_KEY_KP_9 (GLFW_KEY_SPECIAL+55)
        public const int GLFW_KEY_KP_9 = GLFW_KEY_SPECIAL + 55;
        #endregion GLFW_KEY_KP_9

        #region GLFW_KEY_KP_DIVIDE
        /// <summary>
        ///     Keypad divide.
        /// </summary>
        // #define GLFW_KEY_KP_DIVIDE (GLFW_KEY_SPECIAL+56)
        public const int GLFW_KEY_KP_DIVIDE = GLFW_KEY_SPECIAL + 56;
        #endregion GLFW_KEY_KP_DIVIDE

        #region GLFW_KEY_KP_MULTIPLY
        /// <summary>
        ///     Keypad multiply.
        /// </summary>
        // #define GLFW_KEY_KP_MULTIPLY (GLFW_KEY_SPECIAL+57)
        public const int GLFW_KEY_KP_MULTIPLY = GLFW_KEY_SPECIAL + 57;
        #endregion GLFW_KEY_KP_MULTIPLY

        #region GLFW_KEY_KP_SUBTRACT
        /// <summary>
        ///     Keypad subtract.
        /// </summary>
        // #define GLFW_KEY_KP_SUBTRACT (GLFW_KEY_SPECIAL+58)
        public const int GLFW_KEY_KP_SUBTRACT = GLFW_KEY_SPECIAL + 58;
        #endregion GLFW_KEY_KP_SUBTRACT

        #region GLFW_KEY_KP_ADD
        /// <summary>
        ///     Keypad add.
        /// </summary>
        // #define GLFW_KEY_KP_ADD (GLFW_KEY_SPECIAL+59)
        public const int GLFW_KEY_KP_ADD = GLFW_KEY_SPECIAL + 59;
        #endregion GLFW_KEY_KP_ADD

        #region GLFW_KEY_KP_DECIMAL
        /// <summary>
        ///     Keypad decimal.
        /// </summary>
        // #define GLFW_KEY_KP_DECIMAL (GLFW_KEY_SPECIAL+60)
        public const int GLFW_KEY_KP_DECIMAL = GLFW_KEY_SPECIAL + 60;
        #endregion GLFW_KEY_KP_DECIMAL

        #region GLFW_KEY_KP_EQUAL
        /// <summary>
        ///     Keypad equal.
        /// </summary>
        // #define GLFW_KEY_KP_EQUAL (GLFW_KEY_SPECIAL+61)
        public const int GLFW_KEY_KP_EQUAL = GLFW_KEY_SPECIAL + 61;
        #endregion GLFW_KEY_KP_EQUAL

        #region GLFW_KEY_KP_ENTER
        /// <summary>
        ///     Keypad enter.
        /// </summary>
        // #define GLFW_KEY_KP_ENTER (GLFW_KEY_SPECIAL+62)
        public const int GLFW_KEY_KP_ENTER = GLFW_KEY_SPECIAL + 62;
        #endregion GLFW_KEY_KP_ENTER

        #region GLFW_KEY_LAST
        /// <summary>
        ///     Delinates end of 'special' keys.
        /// </summary>
        // #define GLFW_KEY_LAST GLFW_KEY_KP_ENTER
        public const int GLFW_KEY_LAST = GLFW_KEY_KP_ENTER;
        #endregion GLFW_KEY_LAST
        #endregion Keyboard Keys

        #region Mouse Buttons

		#region GLFW_MOUSE_BUTTON_1
		/// <summary>
		///		Mouse identifier 1.
		/// </summary>
		// #define GLFW_MOUSE_BUTTON_1 0
		public const int GLFW_MOUSE_BUTTON_1 = 0;
		#endregion GLFW_MOUSE_BUTTON_1

		#region GLFW_MOUSE_BUTTON_2
		/// <summary>
		/// 	Mouse identifier 2.
		/// </summary>
		// #define GLFW_MOUSE_BUTTON_2 1
		public const int GLFW_MOUSE_BUTTON_2 = 1;
		#endregion GLFW_MOUSE_BUTTON_2

		#region GLFW_MOUSE_BUTTON_3
		/// <summary>
		/// 	Mouse identifier 3.
		/// </summary>
		// #define GLFW_MOUSE_BUTTON_3 2
		public const int GLFW_MOUSE_BUTTON_3 = 2;
		#endregion GLFW_MOUSE_BUTTON_3

		#region GLFW_MOUSE_BUTTON_4
		/// <summary>
		/// 	Mouse identifier 4.
		/// </summary>
		// #define GLFW_MOUSE_BUTTON_4 3
		public const int GLFW_MOUSE_BUTTON_4 = 3;
		#endregion GLFW_MOUSE_BUTTON_4

		#region GLFW_MOUSE_BUTTON_5
		/// <summary>
		/// 	Mouse identifier 5.
		/// </summary>
		// #define GLFW_MOUSE_BUTTON_5 4
		public const int GLFW_MOUSE_BUTTON_5 = 4;
		#endregion GLFW_MOUSE_BUTTON_5

		#region GLFW_MOUSE_BUTTON_6
		/// <summary>
		/// 	Mouse identifier 6.
		/// </summary>
		// #define GLFW_MOUSE_BUTTON_6 5
		public const int GLFW_MOUSE_BUTTON_6 = 5;
		#endregion GLFW_MOUSE_BUTTON_6

		#region GLFW_MOUSE_BUTTON_7
		/// <summary>
		/// 	Mouse identifier 7.
		/// </summary>
		// #define GLFW_MOUSE_BUTTON_7 6
		public const int GLFW_MOUSE_BUTTON_7 = 6;
		#endregion GLFW_MOUSE_BUTTON_7

		#region GLFW_MOUSE_BUTTON_8
		/// <summary>
		/// 	Mouse identifier 8.
		/// </summary>
		// #define GLFW_MOUSE_BUTTON_8 7
		public const int GLFW_MOUSE_BUTTON_8 = 7;
		#endregion GLFW_MOUSE_BUTTON_8

        #region GLFW_MOUSE_BUTTON_LEFT
        /// <summary>
        ///     Left mouse button.
        /// </summary>
        // #define GLFW_MOUSE_BUTTON_LEFT GLFW_MOUSE_BUTTON_1
        public const int GLFW_MOUSE_BUTTON_LEFT = GLFW_MOUSE_BUTTON_1;
        #endregion GLFW_MOUSE_BUTTON_LEFT

        #region GLFW_MOUSE_BUTTON_RIGHT
        /// <summary>
        ///     Right mouse button.
        /// </summary>
        // #define GLFW_MOUSE_BUTTON_RIGHT GLFW_MOUSE_BUTTON_2
        public const int GLFW_MOUSE_BUTTON_RIGHT = GLFW_MOUSE_BUTTON_2;
        #endregion GLFW_MOUSE_BUTTON_RIGHT

        #region GLFW_MOUSE_BUTTON_MIDDLE
        /// <summary>
        ///     Middle mouse button.
        /// </summary>
        // #define GLFW_MOUSE_BUTTON_MIDDLE GLFW_MOUSE_BUTTON_3
        public const int GLFW_MOUSE_BUTTON_MIDDLE = GLFW_MOUSE_BUTTON_3;
        #endregion GLFW_MOUSE_BUTTON_MIDDLE

        #region GLFW_MOUSE_BUTTON_LAST
        /// <summary>
        ///     Delineates the last mouse button.
        /// </summary>
        // #define GLFW_MOUSE_BUTTON_LAST GLFW_MOUSE_BUTTON_8
        public const int GLFW_MOUSE_BUTTON_LAST = GLFW_MOUSE_BUTTON_8;
        #endregion GLFW_MOUSE_BUTTON_LAST
        #endregion Mouse Buttons

        #region Joystick Identifiers
        #region GLFW_JOYSTICK_1
        /// <summary>
        ///     Joystick identifier 1.
        /// </summary>
        // #define GLFW_JOYSTICK_1 0
        public const int GLFW_JOYSTICK_1 = 0;
        #endregion GLFW_JOYSTICK_1

        #region GLFW_JOYSTICK_2
        /// <summary>
        ///     Joystick identifier 2.
        /// </summary>
        // #define GLFW_JOYSTICK_2 1
        public const int GLFW_JOYSTICK_2 = 1;
        #endregion GLFW_JOYSTICK_2

        #region GLFW_JOYSTICK_3
        /// <summary>
        ///     Joystick identifier 3.
        /// </summary>
        // #define GLFW_JOYSTICK_3 2
        public const int GLFW_JOYSTICK_3 = 2;
        #endregion GLFW_JOYSTICK_3

        #region GLFW_JOYSTICK_4
        /// <summary>
        ///     Joystick identifier 4.
        /// </summary>
        // #define GLFW_JOYSTICK_4 3
        public const int GLFW_JOYSTICK_4 = 3;
        #endregion GLFW_JOYSTICK_4

        #region GLFW_JOYSTICK_5
        /// <summary>
        ///     Joystick identifier 5.
        /// </summary>
        // #define GLFW_JOYSTICK_5 4
        public const int GLFW_JOYSTICK_5 = 4;
        #endregion GLFW_JOYSTICK_5

        #region GLFW_JOYSTICK_6
        /// <summary>
        ///     Joystick identifier 6.
        /// </summary>
        // #define GLFW_JOYSTICK_6 5
        public const int GLFW_JOYSTICK_6 = 5;
        #endregion GLFW_JOYSTICK_6

        #region GLFW_JOYSTICK_7
        /// <summary>
        ///     Joystick identifier 7.
        /// </summary>
        // #define GLFW_JOYSTICK_7 6
        public const int GLFW_JOYSTICK_7 = 6;
        #endregion GLFW_JOYSTICK_7

        #region GLFW_JOYSTICK_8
        /// <summary>
        ///     Joystick identifier 8.
        /// </summary>
        // #define GLFW_JOYSTICK_8 7
        public const int GLFW_JOYSTICK_8 = 7;
        #endregion GLFW_JOYSTICK_8

        #region GLFW_JOYSTICK_9
        /// <summary>
        ///     Joystick identifier 9.
        /// </summary>
        // #define GLFW_JOYSTICK_9 8
        public const int GLFW_JOYSTICK_9 = 8;
        #endregion GLFW_JOYSTICK_9

        #region GLFW_JOYSTICK_10
        /// <summary>
        ///     Joystick identifier 10.
        /// </summary>
        // #define GLFW_JOYSTICK_10 9
        public const int GLFW_JOYSTICK_10 = 9;
        #endregion GLFW_JOYSTICK_10

        #region GLFW_JOYSTICK_11
        /// <summary>
        ///     Joystick identifier 11.
        /// </summary>
        // #define GLFW_JOYSTICK_11 10
        public const int GLFW_JOYSTICK_11 = 10;
        #endregion GLFW_JOYSTICK_11

        #region GLFW_JOYSTICK_12
        /// <summary>
        ///     Joystick identifier 12.
        /// </summary>
        // #define GLFW_JOYSTICK_12 11
        public const int GLFW_JOYSTICK_12 = 11;
        #endregion GLFW_JOYSTICK_12

        #region GLFW_JOYSTICK_13
        /// <summary>
        ///     Joystick identifier 13.
        /// </summary>
        // #define GLFW_JOYSTICK_13 12
        public const int GLFW_JOYSTICK_13 = 12;
        #endregion GLFW_JOYSTICK_13

        #region GLFW_JOYSTICK_14
        /// <summary>
        ///     Joystick identifier 14.
        /// </summary>
        // #define GLFW_JOYSTICK_14 13
        public const int GLFW_JOYSTICK_14 = 13;
        #endregion GLFW_JOYSTICK_14

        #region GLFW_JOYSTICK_15
        /// <summary>
        ///     Joystick identifier 15.
        /// </summary>
        // #define GLFW_JOYSTICK_15 14
        public const int GLFW_JOYSTICK_15 = 14;
        #endregion GLFW_JOYSTICK_15

        #region GLFW_JOYSTICK_16
        /// <summary>
        ///     Joystick identifier 16.
        /// </summary>
        // #define GLFW_JOYSTICK_16 15
        public const int GLFW_JOYSTICK_16 = 15;
        #endregion GLFW_JOYSTICK_16

        #region GLFW_JOYSTICK_LAST
        /// <summary>
        ///     Delineates the last joystick identifier.
        /// </summary>
        // #define GLFW_JOYSTICK_LAST GLFW_JOYSTICK_16
        public const int GLFW_JOYSTICK_LAST = GLFW_JOYSTICK_16;
        #endregion GLFW_JOYSTICK_LAST
        #endregion Joystick Identifiers

        #region glfwOpenWindow Modes
        #region GLFW_WINDOW
        /// <summary>
        ///     Normal desktop window.
        /// </summary>
        // #define GLFW_WINDOW 0x00010001
        public const int GLFW_WINDOW = 0x00010001;
        #endregion GLFW_WINDOW

        #region GLFW_FULLSCREEN
        /// <summary>
        ///     Fullscreen window.
        /// </summary>
        // #define GLFW_FULLSCREEN 0x00010002
        public const int GLFW_FULLSCREEN = 0x00010002;
        #endregion GLFW_FULLSCREEN
        #endregion glfwOpenWindow Modes

        #region glfwGetWindowParam Tokens
        #region GLFW_OPENED
        /// <summary>
        ///     <see cref="Gl.GL_TRUE" /> if window is opened, else <see cref="Gl.GL_FALSE" />.
        /// </summary>
        // #define GLFW_OPENED 0x00020001
        public const int GLFW_OPENED = 0x00020001;
        #endregion GLFW_OPENED

        #region GLFW_ACTIVE
        /// <summary>
        ///     <see cref="Gl.GL_TRUE" /> if window has focus, else <see cref="Gl.GL_FALSE" />.
        /// </summary>
        // #define GLFW_ACTIVE 0x00020002
        public const int GLFW_ACTIVE = 0x00020002;
        #endregion GLFW_ACTIVE

        #region GLFW_ICONIFIED
        /// <summary>
        ///     <see cref="Gl.GL_TRUE" /> if window is iconified, else <see cref="Gl.GL_FALSE" />.
        /// </summary>
        // #define GLFW_ICONIFIED 0x00020003
        public const int GLFW_ICONIFIED = 0x00020003;
        #endregion GLFW_ICONIFIED

        #region GLFW_ACCELERATED
        /// <summary>
        ///     <see cref="Gl.GL_TRUE" /> if window is hardware accelerated, else
        ///     <see cref="Gl.GL_FALSE" />.
        /// </summary>
        // #define GLFW_ACCELERATED 0x00020004
        public const int GLFW_ACCELERATED = 0x00020004;
        #endregion GLFW_ACCELERATED

        #region GLFW_RED_BITS
        /// <summary>
        ///     Number of bits for the red color component.
        /// </summary>
        // #define GLFW_RED_BITS 0x00020005
        public const int GLFW_RED_BITS = 0x00020005;
        #endregion GLFW_RED_BITS

        #region GLFW_GREEN_BITS
        /// <summary>
        ///     Number of bits for the green color component.
        /// </summary>
        // #define GLFW_GREEN_BITS 0x00020006
        public const int GLFW_GREEN_BITS = 0x00020006;
        #endregion GLFW_GREEN_BITS

        #region GLFW_BLUE_BITS
        /// <summary>
        ///     Number of bits for the blue color component.
        /// </summary>
        // #define GLFW_BLUE_BITS 0x00020007
        public const int GLFW_BLUE_BITS = 0x00020007;
        #endregion GLFW_BLUE_BITS

        #region GLFW_ALPHA_BITS
        /// <summary>
        ///     Number of bits for the alpha buffer.
        /// </summary>
        // #define GLFW_ALPHA_BITS 0x00020008
        public const int GLFW_ALPHA_BITS = 0x00020008;
        #endregion GLFW_ALPHA_BITS

        #region GLFW_DEPTH_BITS
        /// <summary>
        ///     Number of bits for the depth buffer.
        /// </summary>
        // #define GLFW_DEPTH_BITS 0x00020009
        public const int GLFW_DEPTH_BITS = 0x00020009;
        #endregion GLFW_DEPTH_BITS

        #region GLFW_STENCIL_BITS
        /// <summary>
        ///     Number of bits for the stencil buffer.
        /// </summary>
        // #define GLFW_STENCIL_BITS 0x0002000A
        public const int GLFW_STENCIL_BITS = 0x0002000A;
        #endregion GLFW_STENCIL_BITS
        #endregion glfwGetWindowParam Tokens

        #region glfwGetWindowParam/glfwOpenWindowHint Tokens
        #region GLFW_REFRESH_RATE
        /// <summary>
        ///     Vertical monitor refresh rate in Hz (only used for fullscreen windows).  Zero
        ///     means system default.
        /// </summary>
        // #define GLFW_REFRESH_RATE 0x0002000B
        public const int GLFW_REFRESH_RATE = 0x0002000B;
        #endregion GLFW_REFRESH_RATE

        #region GLFW_ACCUM_RED_BITS
        /// <summary>
        ///     Number of bits for the red channel of the accumulator buffer.
        /// </summary>
        // #define GLFW_ACCUM_RED_BITS 0x0002000C
        public const int GLFW_ACCUM_RED_BITS = 0x0002000C;
        #endregion GLFW_ACCUM_RED_BITS

        #region GLFW_ACCUM_GREEN_BITS
        /// <summary>
        ///     Number of bits for the green channel of the accumulator buffer.
        /// </summary>
        // #define GLFW_ACCUM_GREEN_BITS 0x0002000D
        public const int GLFW_ACCUM_GREEN_BITS = 0x0002000D;
        #endregion GLFW_ACCUM_GREEN_BITS

        #region GLFW_ACCUM_BLUE_BITS
        /// <summary>
        ///     Number of bits for the blue channel of the accumulator buffer.
        /// </summary>
        // #define GLFW_ACCUM_BLUE_BITS 0x0002000E
        public const int GLFW_ACCUM_BLUE_BITS = 0x0002000E;
        #endregion GLFW_ACCUM_BLUE_BITS

        #region GLFW_ACCUM_ALPHA_BITS
        /// <summary>
        ///     Number of bits for the alpha channel of the accumulator buffer.
        /// </summary>
        // #define GLFW_ACCUM_ALPHA_BITS 0x0002000F
        public const int GLFW_ACCUM_ALPHA_BITS = 0x0002000F;
        #endregion GLFW_ACCUM_ALPHA_BITS

        #region GLFW_AUX_BUFFERS
        /// <summary>
        ///     Number of auxiliary buffers.
        /// </summary>
        // #define GLFW_AUX_BUFFERS 0x00020010
        public const int GLFW_AUX_BUFFERS = 0x00020010;
        #endregion GLFW_AUX_BUFFERS

        #region GLFW_STEREO
        /// <summary>
        ///     Specify if stereo rendering should be supported (can be <see cref="Gl.GL_TRUE" />
        ///     or <see cref="Gl.GL_FALSE" />).
        /// </summary>
        // #define GLFW_STEREO 0x00020011
        public const int GLFW_STEREO = 0x00020011;
        #endregion GLFW_STEREO

        #region GLFW_WINDOW_NO_RESIZE
        /// <summary>
        ///     Specify whether the window can be resized (can be <see cref="Gl.GL_TRUE" />
        ///     or <see cref="Gl.GL_FALSE" />).
        /// </summary>
        // #define GLFW_WINDOW_NO_RESIZE 0x00020012
        public const int GLFW_WINDOW_NO_RESIZE = 0x00020012;
        #endregion GLFW_WINDOW_NO_RESIZE

        #region GLFW_FSAA_SAMPLES
        /// <summary>
        ///     Specify if full screen antialiasing should be supported. Zero disabless multisampling, greater
        ///     values define the number of samples.
        /// </summary>
        // #define GLFW_FSAA_SAMPLES 0x00020013
        public const int GLFW_FSAA_SAMPLES = 0x00020013;
        #endregion GLFW_FSAA_SAMPLES

        #endregion glfwGetWindowParam/glfwOpenWindowHint Tokens

        #region glfwEnable/glfwDisable Tokens
        #region  GLFW_MOUSE_CURSOR
        /// <summary>
        ///     Mouse cursor visibility.
        /// </summary>
        // #define GLFW_MOUSE_CURSOR 0x00030001
        public const int GLFW_MOUSE_CURSOR = 0x00030001;
        #endregion  GLFW_MOUSE_CURSOR

        #region  GLFW_STICKY_KEYS
        /// <summary>
        ///     Keyboard key “stickiness".
        /// </summary>
        // #define GLFW_STICKY_KEYS 0x00030002
        public const int GLFW_STICKY_KEYS = 0x00030002;
        #endregion  GLFW_STICKY_KEYS

        #region  GLFW_STICKY_MOUSE_BUTTONS
        /// <summary>
        ///     Mouse button “stickiness”.
        /// </summary>
        // #define GLFW_STICKY_MOUSE_BUTTONS 0x00030003
        public const int GLFW_STICKY_MOUSE_BUTTONS = 0x00030003;
        #endregion  GLFW_STICKY_MOUSE_BUTTONS

        #region  GLFW_SYSTEM_KEYS
        /// <summary>
        ///     Special system key actions.
        /// </summary>
        // #define GLFW_SYSTEM_KEYS 0x00030004
        public const int GLFW_SYSTEM_KEYS = 0x00030004;
        #endregion  GLFW_SYSTEM_KEYS

        #region  GLFW_KEY_REPEAT
        /// <summary>
        ///     Keyboard key repeat.
        /// </summary>
        // #define GLFW_KEY_REPEAT 0x00030005
        public const int GLFW_KEY_REPEAT = 0x00030005;
        #endregion  GLFW_KEY_REPEAT

        #region  GLFW_AUTO_POLL_EVENTS
        /// <summary>
        ///     Automatic event polling when <see cref="glfwSwapBuffers" /> is called.
        /// </summary>
        // #define GLFW_AUTO_POLL_EVENTS 0x00030006
        public const int GLFW_AUTO_POLL_EVENTS = 0x00030006;
        #endregion  GLFW_AUTO_POLL_EVENTS
        #endregion glfwEnable/glfwDisable Tokens

        #region glfwWaitThread Wait Modes
        #region GLFW_WAIT
        /// <summary>
        ///     Waiting.
        /// </summary>
        // #define GLFW_WAIT 0x00040001
        public const int GLFW_WAIT = 0x00040001;
        #endregion GLFW_WAIT

        #region GLFW_NOWAIT
        /// <summary>
        ///     No waiting.
        /// </summary>
        // #define GLFW_NOWAIT 0x00040002
        public const int GLFW_NOWAIT = 0x00040002;
        #endregion GLFW_NOWAIT
        #endregion glfwWaitThread Wait Modes

        #region glfwGetJoystickParam Tokens
        #region GLFW_PRESENT
        /// <summary>
        ///     <see cref="Gl.GL_TRUE" /> if the joystick is connected, else
        ///     <see cref="Gl.GL_FALSE" />.
        /// </summary>
        // #define GLFW_PRESENT 0x00050001
        public const int GLFW_PRESENT = 0x00050001;
        #endregion GLFW_PRESENT

        #region GLFW_AXES
        /// <summary>
        ///     Number of axes supported by the joystick.
        /// </summary>
        // #define GLFW_AXES 0x00050002
        public const int GLFW_AXES = 0x00050002;
        #endregion GLFW_AXES

        #region GLFW_BUTTONS
        /// <summary>
        ///     Number of buttons supported by the joystick.
        /// </summary>
        // #define GLFW_BUTTONS 0x00050003
        public const int GLFW_BUTTONS = 0x00050003;
        #endregion GLFW_BUTTONS
        #endregion glfwGetJoystickParam Tokens

        #region glfwReadImage/glfwLoadTexture2D Flags
        #region GLFW_NO_RESCALE_BIT
        /// <summary>
        ///     Do not rescale image to closest 2^m * 2^n resolution.
        /// </summary>
        // #define GLFW_NO_RESCALE_BIT 0x00000001
        public const int GLFW_NO_RESCALE_BIT = 0x00000001;
        #endregion GLFW_NO_RESCALE_BIT

        #region GLFW_ORIGIN_UL_BIT
        /// <summary>
        ///     Specifies that the origin of the loaded image should be in the upper left corner
        ///     (default is the lower left corner).
        /// </summary>
        // #define GLFW_ORIGIN_UL_BIT 0x00000002
        public const int GLFW_ORIGIN_UL_BIT = 0x00000002;
        #endregion GLFW_ORIGIN_UL_BIT

        #region GLFW_BUILD_MIPMAPS_BIT
        /// <summary>
        ///     Automatically build and upload all mipmap levels.
        /// </summary>
        // #define GLFW_BUILD_MIPMAPS_BIT 0x00000004
        public const int GLFW_BUILD_MIPMAPS_BIT = 0x00000004;
        #endregion GLFW_BUILD_MIPMAPS_BIT

        #region GLFW_ALPHA_MAP_BIT
        /// <summary>
        ///     Single component alpha maps.
        /// </summary>
        // #define GLFW_ALPHA_MAP_BIT 0x00000008
        public const int GLFW_ALPHA_MAP_BIT = 0x00000008;
        #endregion GLFW_ALPHA_MAP_BIT
        #endregion glfwReadImage/glfwLoadTexture2D Flags

        #region Time
        /// <summary>
        ///     Infinite amount of time.
        /// </summary>
        // #define GLFW_INFINITY 100000.0
        public const double GLFW_INFINITY = 100000;
        #endregion Time

        #endregion Public Constants

        #region Public Structs

        #region GLFWvidmode
        /// <summary>
        ///     Video mode.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GLFWvidmode {
            #region int Width
            /// <summary>
            ///     Video width resolution.
            /// </summary>
            // int Width;
            public int Width;
            #endregion int Width

            #region int Height
            /// <summary>
            ///     Video height resolution.
            /// </summary>
            // int Height;
            public int Height;
            #endregion int Height

            #region int RedBits
            /// <summary>
            ///     Number of red bits.
            /// </summary>
            // int RedBits;
            public int RedBits;
            #endregion int RedBits

            #region int BlueBits
            /// <summary>
            ///     Number of blue bits.
            /// </summary>
            // int BlueBits;
            public int BlueBits;
            #endregion int BlueBits

            #region int GreenBits
            /// <summary>
            ///     Number of green bits.
            /// </summary>
            // int GreenBits;
            public int GreenBits;
            #endregion int GreenBits
        }
        #endregion GLFWvidmode

        #region GLFWimage
        /// <summary>
        ///     Image information.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GLFWimage {
            #region int Width
            /// <summary>
            ///     Image width resolution.
            /// </summary>
            // int Width;
            public int Width;
            #endregion int Width

            #region int Height
            /// <summary>
            ///     Image height resolution.
            /// </summary>
            // int Height;
            public int Height;
            #endregion int Height

            #region int Format
            /// <summary>
            ///     OpenGL pixel format.
            /// </summary>
            // int Format;
            public int Format;
            #endregion int Format

            #region int BytesPerPixel
            /// <summary>
            ///     Number of bytes per pixel.
            /// </summary>
            // int BytesPerPixel;
            public int BytesPerPixel;
            #endregion int BytesPerPixel

            #region byte[] Data
            /// <summary>
            ///     Image pixel data.
            /// </summary>
            // unsigned char *Data;
            public byte[] Data;
            #endregion byte[] Data
        }
        #endregion GLFWimage

        #endregion Public Structs

        #region Public Delegates

        #region GLFWwindowsizefun(int width, int height)
        /// <summary>
        ///     Callback function that will be called every time the window size changes.
        /// </summary>
        // typedef void (GLFWCALL * GLFWwindowsizefun)(int,int);
        public delegate void GLFWwindowsizefun(int width, int height);
        #endregion GLFWwindowsizefun(int width, int height)

		#region GLFWwindowclosefun()
		/// <summary>
		///     Callback function that will be called every time the window closes.
		/// </summary>
		// typedef int  (GLFWCALL * GLFWwindowclosefun)(void);
		public delegate int GLFWwindowclosefun();
		#endregion GLFWwindowclosefun()

		#region GLFWwindowrefreshfun()
		/// <summary>
		///     Callback function that will be called every time the window refreshes.
		/// </summary>
		// typedef void (GLFWCALL * GLFWwindowrefreshfun)(void);
		public delegate void GLFWwindowrefreshfun();
		#endregion GLFWwindowrefreshfun()

        #region GLFWmousebuttonfun(int button, int action)
        /// <summary>
        ///     Callback function that will be called every time a mouse button is pressed
        ///     or released.
        /// </summary>
        // typedef void (GLFWCALL * GLFWmousebuttonfun)(int,int);
        public delegate void GLFWmousebuttonfun(int button, int action);
        #endregion GLFWmousebuttonfun(int button, int action)

        #region GLFWmouseposfun(int x, int y)
        /// <summary>
        ///     Callback function that will be called every time the mouse is moved.
        /// </summary>
        // typedef void (GLFWCALL * GLFWmouseposfun)(int,int);
        public delegate void GLFWmouseposfun(int x, int y);
        #endregion GLFWmouseposfun(int x, int y)

        #region GLFWmousewheelfun(int position)
        /// <summary>
        ///     Callback function that will be called every time the mouse wheel is moved.
        /// </summary>
        // typedef void (GLFWCALL * GLFWmousewheelfun)(int);
        public delegate void GLFWmousewheelfun(int position);
        #endregion GLFWmousewheelfun(int position)

        #region GLFWkeyfun(int key, int action)
        /// <summary>
        ///     Callback function that will be called every time a key is pressed or released.
        /// </summary>
        // typedef void (GLFWCALL * GLFWkeyfun)(int,int);
        public delegate void GLFWkeyfun(int key, int action);
        #endregion GLFWkeyfun(int key, int action)

        #region GLFWcharfun(int character, int action)
        /// <summary>
        ///     Callback function that will be called every time a printable character is
        ///     generated by the keyboard.
        /// </summary>
        // typedef void (GLFWCALL * GLFWcharfun)(int,int);
        public delegate void GLFWcharfun(int character, int action);
        #endregion GLFWcharfun(int character, int action)

		#region void GLFWthreadfun(IntPtr arg)
        // TODO: Test the damn void* delegate!
        /// <summary>
        ///     Callback function that acts as the entry point for the new thread.
        /// </summary>
        // typedef void (GLFWCALL * GLFWthreadfun)(void *);
        public delegate void GLFWthreadfun(IntPtr arg);
		#endregion void GLFWthreadfun(IntPtr arg)

        #endregion Public Delegates

        // --- Public Externs ---
        #region Initialization, Termination, and Version Querying

        #region int glfwInit()
        /// <summary>
        ///     Initializes GLFW.
        /// </summary>
        /// <returns>
        ///     On success <see cref="Gl.GL_TRUE" /> is returned; otherwise <see cref="Gl.GL_FALSE" />.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         No other GLFW functions may be used before this function has been called.
        ///     </para>
        ///     <para>
        ///         This function may take several seconds to complete on some systems, while
        ///         on other systems it may take only a fraction of a second to complete.
        ///     </para>
        /// </remarks>
        // GLFWAPI int GLFWAPIENTRY glfwInit(void);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern int glfwInit();
        #endregion int glfwInit()

        #region glfwTerminate()
        /// <summary>
        ///     Terminates GLFW.
        /// </summary>
        /// <remarks>
        ///     Among other things it closes the window, if it is opened, and kills any running
        ///     threads.  This function must be called before a program exits.
        /// </remarks>
        // GLFWAPI void GLFWAPIENTRY glfwTerminate(void);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwTerminate();
        #endregion glfwTerminate()

        #region glfwGetVersion(out int major, out int minor, out int revision)
        /// <summary>
        ///     Returns the GLFW library version.
        /// </summary>
        /// <param name="major">
        ///     Pointer to an integer that will hold the major version number.
        /// </param>
        /// <param name="minor">
        ///     Pointer to an integer that will hold the minor version number.
        /// </param>
        /// <param name="revision">
        ///     Pointer to an integer that will hold the revision.
        /// </param>
        // GLFWAPI void GLFWAPIENTRY glfwGetVersion(int *major, int *minor, int *rev);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwGetVersion(out int major, out int minor, out int revision);
        #endregion glfwGetVersion(out int major, out int minor, out int revision)

        #endregion Initialization, Termination, and Version Querying

        #region Window Handling
        #region int glfwOpenWindow(int width, int height, int redBits, int greenBits, int blueBits, int alphaBits, int depthBits, int stencilBits, int mode)
        /// <summary>
        ///     Opens a window that best matches the parameters given to the function.
        /// </summary>
        /// <param name="width">
        ///     The width of the window.  If <paramref name="width" /> is zero, it will be
        ///     calculated as width = <c>(4 / 3) * height</c>, if <paramref name="height" /> is
        ///     not zero.  If both <paramref name="width" /> and <paramref name="height" /> are
        ///     zero, then <paramref name="width" /> will be set to 640.
        /// </param>
        /// <param name="height">
        ///     The height of the window.  If <paramref name="height" /> is zero, it will be
        ///     calculated as <c>height = (3 / 4) * width</c>, if <paramref name="width" /> is
        ///     not zero.  If both <paramref name="width" /> and <paramref name="height" /> are
        ///     zero, then <paramref name="height" /> will be set to 480.
        /// </param>
        /// <param name="redBits">
        ///     The number of bits to use for the red color component of the color buffer
        ///     (0 means default color depth).  For instance, setting redbits = 5, greenbits = 6,
        ///     and bluebits = 5 will generate a 16-bit color buffer, if possible.
        /// </param>
        /// <param name="greenBits">
        ///     The number of bits to use for the green color component of the color buffer
        ///     (0 means default color depth).  For instance, setting redbits = 5, greenbits = 6,
        ///     and bluebits = 5 will generate a 16-bit color buffer, if possible.
        /// </param>
        /// <param name="blueBits">
        ///     The number of bits to use for the blue color component of the color buffer
        ///     (0 means default color depth).  For instance, setting redbits = 5, greenbits = 6,
        ///     and bluebits = 5 will generate a 16-bit color buffer, if possible.
        /// </param>
        /// <param name="alphaBits">
        ///     The number of bits to use for the alpha buffer (0 means no alpha buffer).
        /// </param>
        /// <param name="depthBits">
        ///     The number of bits to use for the depth buffer (0 means no depth buffer).
        /// </param>
        /// <param name="stencilBits">
        ///     The number of bits to use for the stencil buffer (0 means no stencil buffer).
        /// </param>
        /// <param name="mode">
        ///     Selects which type of OpenGL window to use. mode can be either
        ///     <see cref="GLFW_WINDOW" />, which will generate a normal desktop window, or
        ///     <see cref="GLFW_FULLSCREEN" />, which will generate a window which covers the
        ///     entire screen.  When <see cref="GLFW_FULLSCREEN" /> is selected, the video mode
        ///     will be changed to the resolution that closest matches the
        ///     <paramref name="width" /> and <paramref name="height" /> parameters.
        /// </param>
        /// <returns>
        ///     On success <see cref="Gl.GL_TRUE" /> is returned; otherwise <see cref="Gl.GL_FALSE" />.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         How well the resulting window matches the desired window depends mostly
        ///         on the available hardware and OpenGL drivers.  In general, selecting a
        ///         fullscreen mode has better chances of generating a close match than does
        ///         a normal desktop window, since GLFW can freely select from all the available
        ///         video modes.  A desktop window is normally restricted to the video mode of
        ///         the desktop.
        ///     </para>
        ///     <para>
        ///         For additional control of window properties, see
        ///         <see cref="glfwOpenWindowHint" />.
        ///     </para>
        ///     <para>
        ///         In fullscreen mode the mouse cursor is hidden by default, and any system
        ///         screensavers are prohibited from starting.  In windowed mode the mouse cursor
        ///         is visible, and screensavers are allowed to start.  To change the visibility
        ///         of the mouse cursor, use <see cref="glfwEnable" /> or
        ///         <see cref="glfwDisable" /> with the argument <see cref="GLFW_MOUSE_CURSOR" />.
        ///     </para>
        ///     <para>
        ///         In order to determine the actual properties of an opened window, use
        ///         <see cref="glfwGetWindowParam" /> and <see cref="glfwGetWindowSize" />
        ///         (or <see cref="glfwSetWindowSizeCallback" />).
        ///     </para>
        /// </remarks>
        // GLFWAPI int GLFWAPIENTRY glfwOpenWindow(int width, int height, int redbits, int greenbits, int bluebits, int alphabits, int depthbits, int stencilbits, int mode);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern int glfwOpenWindow(int width, int height, int redBits, int greenBits, int blueBits, int alphaBits, int depthBits, int stencilBits, int mode);
        #endregion int glfwOpenWindow(int width, int height, int redBits, int greenBits, int blueBits, int alphaBits, int depthBits, int stencilBits, int mode)

        // TODO: Fill in documentation starting here ****************

        #region glfwOpenWindowHint(int target, int hint)
        /// <summary>
        ///     Sets additional properties for a window that is to be opened.
        /// </summary>
        /// <param name="target">
        /// 
        /// </param>
        /// <param name="hint">
        /// 
        /// </param>
        /// <remarks>
        ///     <para>
        ///         For a hint to be registered, the function must be called before calling
        ///         <see cref="glfwOpenWindow" />.  When the <see cref="glfwOpenWindow" />
        ///         function is called, any hints that were registered with the
        ///         <b>glfwOpenWindowHint</b> function are used for setting the
        ///         corresponding window properties, and then all hints are reset to their
        ///         default values.
        ///     </para>
        /// </remarks>
        // GLFWAPI void GLFWAPIENTRY glfwOpenWindowHint(int target, int hint);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwOpenWindowHint(int target, int hint);
        #endregion glfwOpenWindowHint(int target, int hint)

        #region glfwCloseWindow()
        /// <summary>
        ///		The function closes an opened window and destroys the associated OpenGL context.
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwCloseWindow(void);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwCloseWindow();
        #endregion glfwCloseWindow()

		#region glfwSetWindowTitle(string title)
		/// <summary>
		///		Changes the title of the opened window.
		/// </summary>
		/// <param name="title">
		///		Pointer to a null terminated ISO 8859-1 (8-bit Latin 1) string that holds the title of the window.
		///	</param>
		/// <remarks>
		///		<para>
		///			The title property of a window is often used in situations other than for the window title, such as the title of an application icon when it is in iconified state.
		///		</para>
		///	</remarks>
        // GLFWAPI void GLFWAPIENTRY glfwSetWindowTitle(const char *title);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwSetWindowTitle(string title);
		#endregion glfwSetWindowTitle(string title)

		#region glfwGetWindowSize(out int width, out int height)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwGetWindowSize(int *width, int *height);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwGetWindowSize(out int width, out int height);
		#endregion glfwGetWindowSize(out int width, out int height)

		#region glfwSetWindowSize(int width, int height)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSetWindowSize(int width, int height);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwSetWindowSize(int width, int height);
		#endregion glfwSetWindowSize(int width, int height)

		#region glfwSetWindowPos(int x, int y)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSetWindowPos(int x, int y);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwSetWindowPos(int x, int y);
		#endregion glfwSetWindowPos(int x, int y)

		#region glfwIconifyWindow()
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwIconifyWindow(void);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwIconifyWindow();
		#endregion glfwIconifyWindow()

		#region glfwRestoreWindow()
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwRestoreWindow(void);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwRestoreWindow();
		#endregion glfwRestoreWindow()

		#region glfwSwapBuffers()
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSwapBuffers(void);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwSwapBuffers();
		#endregion glfwSwapBuffers()

		#region glfwSwapInterval(int interval)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSwapInterval(int interval);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwSwapInterval(int interval);
		#endregion glfwSwapInterval(int interval)

		#region int glfwGetWindowParam(int param)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int GLFWAPIENTRY glfwGetWindowParam(int param);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern int glfwGetWindowParam(int param);
		#endregion int glfwGetWindowParam(int param)

		#region glfwSetWindowSizeCallback(GLFWwindowsizefun cbfun)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSetWindowSizeCallback(GLFWwindowsizefun cbfun);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwSetWindowSizeCallback(GLFWwindowsizefun cbfun);
		#endregion glfwSetWindowSizeCallback(GLFWwindowsizefun cbfun)

		#region glfwSetWindowCloseCallback(GLFWwindowclosefun cbfun)
		/// <summary>
		///		Selects which function to be called upon a window close event.
		/// </summary>
		/// <remarks>
		///		<para>
		///			A window has to be opened for this function to have any effect.
		///		</para>
		///		<para>
		///			Window close events are recorded continuously, but only reported when glfwPollEvents, glfwWaitEvents or glfwSwapBuffers is called.
		///		</para>
		///		<para>
		///			The OpenGLTM context is still valid when this function is called.
		///		</para>
		///		<para>
		///			Note that the window close callback function is not called when glfwCloseWindow is called, but only when the close request comes from the window manager.
		///		</para>
		///		<para>
		///			Do not call glfwCloseWindow from a window close callback function. Close the window by returning GL_TRUE from the function.
		///		</para>
		///	</remarks>
		/// <param name="cbfun">
		///		Pointer to a callback function that will be called when a user requests that the window should be closed.
		///	</param>
		// GLFWAPI void GLFWAPIENTRY glfwSetWindowCloseCallback( GLFWwindowclosefun cbfun );
		[DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwSetWindowCloseCallback(GLFWwindowclosefun cbfun);
		#endregion glfwSetWindowCloseCallback(GLFWwindowclosefun cbfun)

		#region glfwSetWindowRefreshCallback(GLFWwindowrefreshfun cbfun)
		/// <summary>
		///		The function selects which function to be called upon a window refresh event, which occurs when any part of the window client area has been damaged, and needs to be repainted (for instance, if a part of the window that was previously occluded by another window has become visible).
		/// </summary>
		/// <remarks>
		///		<para>
		///			A window has to be opened for this function to have any effect.
		///		</para>
		///		<para>
		///			Window refresh events are recorded continuously, but only reported when glfwPollEvents, glfwWaitEvents or glfwSwapBuffers is called.
		///		</para>
		///	</remarks>
		/// <param name="cbfun">
		///		Pointer to a callback function that will be called when the window client area needs to be refreshed.
		///	</param>
		// GLFWAPI void GLFWAPIENTRY glfwSetWindowRefreshCallback( GLFWwindowrefreshfun cbfun );
		[DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwSetWindowRefreshCallback(GLFWwindowrefreshfun cbfun);
		#endregion glfwSetWindowRefreshCallback(GLFWwindowrefreshfun cbfun)

        #endregion Window Handling

        #region Video Mode

		#region int glfwGetVideoModes([Out] GLFWvidmode[] list, int maxcount)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int GLFWAPIENTRY glfwGetVideoModes(GLFWvidmode *list, int maxcount);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern int glfwGetVideoModes([Out] GLFWvidmode[] list, int maxcount);
		#endregion int glfwGetVideoModes([Out] GLFWvidmode[] list, int maxcount)

		#region glfwGetDesktopMode(out GLFWvidmode mode)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwGetDesktopMode(GLFWvidmode *mode);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwGetDesktopMode(out GLFWvidmode mode);
		#endregion glfwGetDesktopMode(out GLFWvidmode mode)

        #endregion Video Mode

        #region Input Handling

		#region void glfwPollEvents()
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwPollEvents(void);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwPollEvents();
		#endregion void glfwPollEvents()

		#region void glfwWaitEvents()
		/// <summary>
		/// 
		/// </summary>
		// GLFWAPI void GLFWAPIENTRY glfwWaitEvents(void);
		[DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwWaitEvents();
		#endregion void glfwWaitEvents()

		#region int glfwGetKey(int key)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int GLFWAPIENTRY glfwGetKey(int key);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern int glfwGetKey(int key);
		#endregion int glfwGetKey(int key)

		#region int glfwGetMouseButton(int button)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int GLFWAPIENTRY glfwGetMouseButton(int button);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern int glfwGetMouseButton(int button);
		#endregion int glfwGetMouseButton(int button)

		#region void glfwGetMousePos(out int xPosition, out int yPosition)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwGetMousePos(int *xpos, int *ypos);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwGetMousePos(out int xPosition, out int yPosition);
		#endregion void glfwGetMousePos(out int xPosition, out int yPosition)

		#region void glfwSetMousePos(int xPosition, int yPosition)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSetMousePos(int xpos, int ypos);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwSetMousePos(int xPosition, int yPosition);
		#endregion void glfwSetMousePos(int xPosition, int yPosition)

		#region int glfwGetMouseWheel()
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int GLFWAPIENTRY glfwGetMouseWheel(void);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern int glfwGetMouseWheel();
		#endregion int glfwGetMouseWheel()

		#region void glfwSetMouseWheel(int position)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSetMouseWheel(int pos);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwSetMouseWheel(int position);
		#endregion void glfwSetMouseWheel(int position)

		#region void glfwSetKeyCallback(GLFWkeyfun cbfun)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSetKeyCallback(GLFWkeyfun cbfun);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwSetKeyCallback(GLFWkeyfun cbfun);
		#endregion void glfwSetKeyCallback(GLFWkeyfun cbfun)

		#region void glfwSetCharCallback(GLFWcharfun cbfun)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSetCharCallback(GLFWcharfun cbfun);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwSetCharCallback(GLFWcharfun cbfun);
		#endregion void glfwSetCharCallback(GLFWcharfun cbfun)

		#region void glfwSetMouseButtonCallback(GLFWmousebuttonfun cbfun)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSetMouseButtonCallback(GLFWmousebuttonfun cbfun);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwSetMouseButtonCallback(GLFWmousebuttonfun cbfun);
		#endregion void glfwSetMouseButtonCallback(GLFWmousebuttonfun cbfun)

		#region void glfwSetMousePosCallback(GLFWmouseposfun cbfun)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSetMousePosCallback(GLFWmouseposfun cbfun);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwSetMousePosCallback(GLFWmouseposfun cbfun);
		#endregion void glfwSetMousePosCallback(GLFWmouseposfun cbfun)

		#region void glfwSetMouseWheelCallback(GLFWmousewheelfun cbfun)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSetMouseWheelCallback(GLFWmousewheelfun cbfun);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwSetMouseWheelCallback(GLFWmousewheelfun cbfun);
		#endregion void glfwSetMouseWheelCallback(GLFWmousewheelfun cbfun)

		#region int glfwGetJoystickParam(int joystick, int parameter)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int GLFWAPIENTRY glfwGetJoystickParam(int joy, int param);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern int glfwGetJoystickParam(int joystick, int parameter);
		#endregion int glfwGetJoystickParam(int joystick, int parameter)

		#region int glfwGetJoystickPos(int joy, [Out] float[] position, int numberOfAxes)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int GLFWAPIENTRY glfwGetJoystickPos(int joy, float *pos, int numaxes);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern int glfwGetJoystickPos(int joy, [Out] float[] position, int numberOfAxes);
		#endregion int glfwGetJoystickPos(int joy, [Out] float[] position, int numberOfAxes)

		#region int glfwGetJoystickButtons(int joystick, [Out] byte[] buttons, int numberOfButtons)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int GLFWAPIENTRY glfwGetJoystickButtons(int joy, unsigned char *buttons, int numbuttons);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern int glfwGetJoystickButtons(int joystick, [Out] byte[] buttons, int numberOfButtons);
		#endregion int glfwGetJoystickButtons(int joystick, [Out] byte[] buttons, int numberOfButtons)

        #endregion Input Handling

        #region Time

		#region extern double glfwGetTime()
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI double GLFWAPIENTRY glfwGetTime(void);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern double glfwGetTime();
		#endregion extern double glfwGetTime()

		#region void glfwSetTime(double time)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSetTime(double time);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwSetTime(double time);
		#endregion void glfwSetTime(double time)

		#region void glfwSleep(double time)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSleep(double time);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwSleep(double time);
		#endregion void glfwSleep(double time)

        #endregion Time

        #region Extension Support

		#region int glfwExtensionSupported(string extension)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int GLFWAPIENTRY glfwExtensionSupported(const char *extension);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern int glfwExtensionSupported(string extension);
		#endregion int glfwExtensionSupported(string extension)

		#region IntPtr glfwGetProcAddress(string procName)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void* GLFWAPIENTRY glfwGetProcAddress(const char *procname);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glfwGetProcAddress(string procName);
		#endregion IntPtr glfwGetProcAddress(string procName)

		#region void glfwGetGLVersion(out int major, out int minor, out int revision)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwGetGLVersion(int *major, int *minor, int *rev);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwGetGLVersion(out int major, out int minor, out int revision);
		#endregion void glfwGetGLVersion(out int major, out int minor, out int revision)

        #endregion Extension Support

        #region Threading Support

		#region int glfwCreateThread(GLFWthreadfun fun, IntPtr arg)
        // TODO: Test the damn void* delegate.
		/// <summary>
		///		The function creates a new thread, which executes within the same
		///		address space as the calling process. The thread entry point is
		///		specified with the fun argument.
		/// </summary>
		/// <param name="fun">
		///		A pointer to a function that acts as the entry point for the new
		///		thread.
		///	</param>
		/// <param name="arg">
		///		An arbitrary argument for the thread. arg will be passed as the
		///		argument to the thread function pointed to by fun. For instance,
		///		arg can point to data that is to be processed by the thread.
		///	</param>
		/// <returns>
		///		The function returns a thread identification number if the thread
		///		was created successfully. This number is always positive. If the
		///		function fails, a negative number is returned.
		///	</returns>
		///	<remarks>
		///		<para>
		///			Once the thread function fun returns, the thread dies.
		///		</para>
		///		<para>
		///			Even if the function returns a positive thread ID, indicating
		///			that the thread was created successfully, the thread may be
		///			unable to execute, for instance if the thread start address
		///			is not a valid thread entry point.
		///		</para>
		///	</remarks>
        //GLFWAPI GLFWthread GLFWAPIENTRY glfwCreateThread(GLFWthreadfun fun, void *arg);
		[DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern int glfwCreateThread(GLFWthreadfun fun, IntPtr arg);
		#endregion int glfwCreateThread(GLFWthreadfun fun, IntPtr arg)

		#region void glfwDestroyThread(int id)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwDestroyThread(GLFWthread ID);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwDestroyThread(int id);
		#endregion void glfwDestroyThread(int id)

		#region int glfwWaitThread(int id, int waitMode)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int GLFWAPIENTRY glfwWaitThread(GLFWthread ID, int waitmode);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern int glfwWaitThread(int id, int waitMode);
		#endregion int glfwWaitThread(int id, int waitMode)

		#region int glfwGetThreadID()
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI GLFWthread GLFWAPIENTRY glfwGetThreadID(void);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern int glfwGetThreadID();
		#endregion int glfwGetThreadID()

		#region IntPtr glfwCreateMutex()
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI GLFWmutex GLFWAPIENTRY glfwCreateMutex(void);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr glfwCreateMutex();
		#endregion IntPtr glfwCreateMutex()

		#region void glfwDestroyMutex([In] IntPtr mutex)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwDestroyMutex(GLFWmutex mutex);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwDestroyMutex([In] IntPtr mutex);
		#endregion void glfwDestroyMutex([In] IntPtr mutex)

		#region void glfwLockMutex([In] IntPtr mutex)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwLockMutex(GLFWmutex mutex);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwLockMutex([In] IntPtr mutex);
		#endregion void glfwLockMutex([In] IntPtr mutex)

		#region void glfwUnlockMutex([In] IntPtr mutex)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwUnlockMutex(GLFWmutex mutex);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwUnlockMutex([In] IntPtr mutex);
		#endregion void glfwUnlockMutex([In] IntPtr mutex)

		#region IntPtr glfwCreateCond()
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI GLFWcond GLFWAPIENTRY glfwCreateCond(void);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glfwCreateCond();
		#endregion IntPtr glfwCreateCond()

		#region IntPtr glfwDestroyCond([In] IntPtr cond)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwDestroyCond(GLFWcond cond);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr glfwDestroyCond([In] IntPtr cond);
		#endregion IntPtr glfwDestroyCond([In] IntPtr cond)

		#region void glfwWaitCond([In] IntPtr cond, [In] IntPtr mutex, double timeout)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwWaitCond(GLFWcond cond, GLFWmutex mutex, double timeout);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwWaitCond([In] IntPtr cond, [In] IntPtr mutex, double timeout);
		#endregion void glfwWaitCond([In] IntPtr cond, [In] IntPtr mutex, double timeout)

		#region void glfwSignalCond([In] IntPtr cond)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwSignalCond(GLFWcond cond);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwSignalCond([In] IntPtr cond);
		#endregion void glfwSignalCond([In] IntPtr cond)

		#region void glfwBroadcastCond([In] IntPtr cond)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwBroadcastCond(GLFWcond cond);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwBroadcastCond([In] IntPtr cond);
		#endregion void glfwBroadcastCond([In] IntPtr cond)

		#region int glfwGetNumberOfProcessors()
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int GLFWAPIENTRY glfwGetNumberOfProcessors(void);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern int glfwGetNumberOfProcessors();
		#endregion int glfwGetNumberOfProcessors()

        #endregion Threading Support

        #region Enable/Disable

		#region void glfwEnable(int token)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwEnable(int token);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwEnable(int token);
		#endregion void glfwEnable(int token)

		#region void glfwDisable(int token)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwDisable(int token);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
		public static extern void glfwDisable(int token);
		#endregion void glfwDisable(int token)

        #endregion Enable/Disable

        #region Image/Texture I/O Support

		#region int glfwReadImage(string name, out GLFWimage image, int flags)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int GLFWAPIENTRY glfwReadImage(const char *name, GLFWimage *img, int flags);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern int glfwReadImage(string name, out GLFWimage image, int flags);
		#endregion int glfwReadImage(string name, out GLFWimage image, int flags)

        #region int glfwReadMemoryImage(IntPtr data, int size, out GLFWimage image, int flags)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int  GLFWAPIENTRY glfwReadMemoryImage( const void *data, long size, GLFWimage *img, int flags );
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern int glfwReadMemoryImage(IntPtr data, int size, out GLFWimage image, int flags);
        #endregion int glfwReadMemoryImage(IntPtr data, int size, out GLFWimage image, int flags)

        #region void glfwFreeImage(ref GLFWimage image)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI void GLFWAPIENTRY glfwFreeImage(GLFWimage *img);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern void glfwFreeImage(ref GLFWimage image);
		#endregion void glfwFreeImage(ref GLFWimage image)

		#region int glfwLoadTexture2D(string name, int flags)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int GLFWAPIENTRY glfwLoadTexture2D(const char *name, int flags);
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern int glfwLoadTexture2D(string name, int flags);
		#endregion int glfwLoadTexture2D(string name, int flags)

        #region int glfwLoadMemoryTexture2D(IntPtr data, int size, int flags)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int  GLFWAPIENTRY glfwLoadMemoryTexture2D( const void *data, long size, int flags );
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern int glfwLoadMemoryTexture2D(IntPtr data, int size, int flags);
        #endregion int glfwLoadMemoryTexture2D(IntPtr data, int size, int flags)

        #region int glfwLoadTextureImage2D(ref GLFWimage img, int flags)
        /// <summary>
        /// 
        /// </summary>
        // GLFWAPI int  GLFWAPIENTRY glfwLoadTextureImage2D( GLFWimage *img, int flags );
        [DllImport(GLFW_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern int glfwLoadTextureImage2D(ref GLFWimage img, int flags);
        #endregion int glfwLoadTextureImage2D(ref GLFWimage img, int flags)

        #endregion Image/Texture I/O Support
    }
}
