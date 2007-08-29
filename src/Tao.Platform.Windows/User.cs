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

namespace Tao.Platform.Windows {
    #region Class Documentation
    /// <summary>
    ///     User binding for .NET, implementing Windows-specific user functionality.
    /// </summary>
    /// <remarks>
    ///     Binds functions and definitions in user32.dll.
    /// </remarks>
    #endregion Class Documentation
    public static class User
    {
        // --- Fields ---
        #region Private Constants
        #region string USER_NATIVE_LIBRARY
        /// <summary>
        ///     Specifies User32's native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies user32.dll for Windows.
        /// </remarks>
        private const string USER_NATIVE_LIBRARY = "user32.dll";
        #endregion string USER_NATIVE_LIBRARY

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

        #region Class styles
        // #define CS_VREDRAW 0x0001
		/// <summary>
		/// 
		/// </summary>
        public const int CS_VREDRAW = 0x0001;

        // #define CS_HREDRAW 0x0002
		/// <summary>
		/// 
		/// </summary>
        public const int CS_HREDRAW = 0x0002;

        // #define CS_DBLCLKS 0x0008
		/// <summary>
		/// 
		/// </summary>
        public const int CS_DBLCLKS = 0x0008;

        // #define CS_OWNDC 0x0020
		/// <summary>
		/// 
		/// </summary>
        public const int CS_OWNDC = 0x0020;

        // #define CS_CLASSDC 0x0040
		/// <summary>
		/// 
		/// </summary>
        public const int CS_CLASSDC = 0x0040;

        // #define CS_PARENTDC 0x0080
		/// <summary>
		/// 
		/// </summary>
        public const int CS_PARENTDC = 0x0080;

        // #define CS_NOCLOSE 0x0200
		/// <summary>
		/// 
		/// </summary>
        public const int CS_NOCLOSE = 0x0200;

        // #define CS_SAVEBITS 0x0800
		/// <summary>
		/// 
		/// </summary>
        public const int CS_SAVEBITS = 0x0800;

        // #define CS_BYTEALIGNCLIENT 0x1000
		/// <summary>
		/// 
		/// </summary>
        public const int CS_BYTEALIGNCLIENT = 0x1000;

        // #define CS_BYTEALIGNWINDOW 0x2000
		/// <summary>
		/// 
		/// </summary>
        public const int CS_BYTEALIGNWINDOW = 0x2000;

        // #define CS_GLOBALCLASS 0x4000
		/// <summary>
		/// 
		/// </summary>
        public const int CS_GLOBALCLASS = 0x4000;

        // #define CS_IME 0x00010000
		/// <summary>
		/// 
		/// </summary>
        public const int CS_IME = 0x00010000;

        // #define CS_DROPSHADOW 0x00020000
		/// <summary>
		/// 
		/// </summary>
        public const int CS_DROPSHADOW = 0x00020000;
        #endregion Class styles

        // #define CDS_UPDATEREGISTRY 0x00000001
		/// <summary>
		/// 
		/// </summary>
        public const int CDS_UPDATEREGISTRY = 0x00000001;

        // #define CDS_TEST 0x00000002
		/// <summary>
		/// 
		/// </summary>
        public const int CDS_TEST = 0x00000002;

        // #define CDS_FULLSCREEN 0x00000004
		/// <summary>
		/// 
		/// </summary>
        public const int CDS_FULLSCREEN = 0x00000004;

        // #define CDS_GLOBAL 0x00000008
        // #define CDS_SET_PRIMARY 0x00000010
        // #define CDS_VIDEOPARAMETERS 0x00000020
        // #define CDS_RESET 0x40000000
        // #define CDS_NORESET 0x10000000

        // #define DISP_CHANGE_SUCCESSFUL 0
		/// <summary>
		/// 
		/// </summary>
        public const int DISP_CHANGE_SUCCESSFUL = 0;

        // #define DISP_CHANGE_RESTART 1
		/// <summary>
		/// 
		/// </summary>
        public const int DISP_CHANGE_RESTART = 1;

        // #define DISP_CHANGE_FAILED -1
		/// <summary>
		/// 
		/// </summary>
        public const int DISP_CHANGE_FAILED = -1;

        // #define DISP_CHANGE_BADMODE -2
        // #define DISP_CHANGE_NOTUPDATED -3
        // #define DISP_CHANGE_BADFLAGS -4
        // #define DISP_CHANGE_BADPARAM -5
        // #define DISP_CHANGE_BADDUALVIEW -6

		/// <summary>
		/// 
		/// </summary>
        public const int ENUM_CURRENT_SETTINGS = -1;

        /// <summary>
        /// 
        /// </summary>
        [CLSCompliant(false)]
        public enum SHOWWINDOW : uint
        {
            /// <summary>
            /// 
            /// </summary>
            SW_HIDE = 0,
            /// <summary>
            /// 
            /// </summary>
            SW_SHOWNORMAL = 1,
            /// <summary>
            /// 
            /// </summary>
            SW_NORMAL = 1,
            /// <summary>
            /// 
            /// </summary>
            SW_SHOWMINIMIZED = 2,
            /// <summary>
            /// 
            /// </summary>
            SW_SHOWMAXIMIZED = 3,
            /// <summary>
            /// 
            /// </summary>
            SW_MAXIMIZE = 3,
            /// <summary>
            /// 
            /// </summary>
            SW_SHOWNOACTIVATE = 4,
            /// <summary>
            /// 
            /// </summary>
            SW_SHOW = 5,
            /// <summary>
            /// 
            /// </summary>
            SW_MINIMIZE = 6,
            /// <summary>
            /// 
            /// </summary>
            SW_SHOWMINNOACTIVE = 7,
            /// <summary>
            /// 
            /// </summary>
            SW_SHOWNA = 8,
            /// <summary>
            /// 
            /// </summary>
            SW_RESTORE = 9,
            /// <summary>
            /// 
            /// </summary>
            SW_SHOWDEFAULT = 10,
            /// <summary>
            /// 
            /// </summary>
            SW_FORCEMINIMIZE = 11,
            /// <summary>
            /// 
            /// </summary>
            SW_MAX = 11,
        }

        #endregion Public Constants

        // --- Public Externs ---
        #region int ChangeDisplaySettings(ref Gdi.DEVMODE devMode, int flags)
        /// <summary>
        ///     <para>
        ///         The <b>ChangeDisplaySettings</b> function changes the settings of the default
        ///         display device to the specified graphics mode.
        ///     </para>
        ///     <para>
        ///         To change the settings of a specified display device, use the
        ///         <b>ChangeDisplaySettingsEx</b> function.
        ///     </para>
        /// </summary>
        /// <param name="devMode">
        ///     <para>
        ///         Pointer to a <see cref="Gdi.DEVMODE" /> structure that describes the new
        ///         graphics mode.  If <i>devMode</i> is NULL, all the values currently in the
        ///         registry will be used for the display setting.  Passing NULL for the
        ///         <i>devMode</i> parameter and 0 for the <i>flags</i> parameter is the easiest
        ///         way to return to the default mode after a dynamic mode change.
        ///     </para>
        ///     <para>
        ///         The <see cref="Gdi.DEVMODE.dmSize" /> member of <see cref="Gdi.DEVMODE" />
        ///         must be initialized to the size, in bytes, of the <see cref="Gdi.DEVMODE" />
        ///         structure.  The <see cref="Gdi.DEVMODE.dmDriverExtra" /> member of
        ///         <see cref="Gdi.DEVMODE" /> must be initialized to indicate the number of bytes
        ///         of private driver data following the <see cref="Gdi.DEVMODE" /> structure.  In
        ///         addition, you can use any or all of the following members of the
        ///         <see cref="Gdi.DEVMODE" /> structure:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="Gdi.DEVMODE.dmBitsPerPel" /></term>
        ///                 <description>Bits per pixel.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DEVMODE.dmPelsWidth" /></term>
        ///                 <description>Pixel width.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DEVMODE.dmPelsHeight" /></term>
        ///                 <description>Pixel height.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DEVMODE.dmDisplayFlags" /></term>
        ///                 <description>Mode flags.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DEVMODE.dmDisplayFrequency" /></term>
        ///                 <description>Mode frequency.</description>
        ///             </item>
        ///             <item>
        ///                 <term>dmPosition</term>
        ///                 <description>
        ///                     <b>Windows 98/Me, Windows 2000/XP:</b> Position of the device in
        ///                     a multimonitor configuration.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         In addition to using one or more of the preceding <see cref="Gdi.DEVMODE" />
        ///         members, you must also set one or more of the following values in the
        ///         <see cref="Gdi.DEVMODE.dmFields" /> member to change the display setting:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="Gdi.DM_BITSPERPEL" /></term>
        ///                 <description>
        ///                     Use the <see cref="Gdi.DEVMODE.dmBitsPerPel" /> value.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DM_PELSWIDTH" /></term>
        ///                 <description>
        ///                     Use the <see cref="Gdi.DEVMODE.dmPelsWidth" /> value.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DM_PELSHEIGHT" /></term>
        ///                 <description>
        ///                     Use the <see cref="Gdi.DEVMODE.dmPelsHeight" /> value.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DM_DISPLAYFLAGS" /></term>
        ///                 <description>
        ///                     Use the <see cref="Gdi.DEVMODE.dmDisplayFlags" /> value.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DM_DISPLAYFREQUENCY" /></term>
        ///                 <description>
        ///                     Use the <see cref="Gdi.DEVMODE.dmDisplayFrequency" /> value.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DM_POSITION" </term>
        ///                 <description>
        ///                     <b>Windows 98/Me, Windows 2000/XP:</b> Use the dmPosition value.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <param name="flags">
        ///     <para>
        ///         Indicates how the graphics mode should be changed.  This parameter can be one
        ///         of the following values:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>0</term>
        ///                 <description>
        ///                     The graphics mode for the current screen will be changed
        ///                     dynamically.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_FULLSCREEN" </term>
        ///                 <description>
        ///                     <para>
        ///                         The mode is temporary in nature.
        ///                     </para>
        ///                     <para>
        ///                         <b>Windows NT/2000/XP:</b> If you change to and from another
        ///                         desktop, this mode will not be reset.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_GLOBAL" </term>
        ///                 <description>
        ///                     The settings will be saved in the global settings area so that
        ///                     they will affect all users on the machine.  Otherwise, only the
        ///                     settings for the user are modified.  This flag is only valid when
        ///                     specified with the see cref="Gdi.CDS_UPDATEREGISTRY"  flag.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_NORESET" </term>
        ///                 <description>
        ///                     The settings will be saved in the registry, but will not take
        ///                     affect.  This flag is only valid when specified with the
        ///                     see cref="Gdi.CDS_UPDATEREGISTRY"  flag.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_RESET" </term>
        ///                 <description>
        ///                     The settings should be changed, even if the requested settings are
        ///                     the same as the current settings.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_SET_PRIMARY" </term>
        ///                 <description>
        ///                     This device will become the primary device.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_TEST" </term>
        ///                 <description>
        ///                     The system tests if the requested graphics mode could be set.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_UPDATEREGISTRY" </term>
        ///                 <description>
        ///                     The graphics mode for the current screen will be changed
        ///                     dynamically and the graphics mode will be updated in the registry.
        ///                     The mode information is stored in the USER profile.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         Specifying see cref="Gdi.CDS_TEST"  allows an application to determine
        ///         which graphics modes are actually valid, without causing the system to
        ///         change to that graphics mode.
        ///     </para>
        ///     <para>
        ///         If see cref="Gdi.CDS_UPDATEREGISTRY"  is specified and it is possible to
        ///         change the graphics mode dynamically, the information is stored in the
        ///         registry and see cref="Gdi.DISP_CHANGE_SUCCESSFUL"  is returned.  If it is
        ///         not possible to change the graphics mode dynamically, the information is
        ///         stored in the registry and see cref="Gdi.DISP_CHANGE_RESTART"  is returned.
        ///     </para>
        ///     <para>
        ///         <b>Windows NT/2000/XP:</b>  If see cref="Gdi.CDS_UPDATEREGISTRY"  is
        ///         specified and the information could not be stored in the registry, the
        ///         graphics mode is not changed and see cref="Gdi.DISP_CHANGE_NOTUPDATED"  is
        ///         returned.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         The <b>ChangeDisplaySettings</b> function returns one of the following values:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_SUCCESSFUL" </term>
        ///                 <description>
        ///                     The settings change was successful.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_BADDUALVIEW" </term>
        ///                 <description>
        ///                     <b>Windows XP:</b>  The settings change was unsuccessful because
        ///                     system is DualView capable.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_BADFLAGS" </term>
        ///                 <description>
        ///                     An invalid set of flags was passed in.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_BADMODE" </term>
        ///                 <description>
        ///                     The graphics mode is not supported.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_BADPARAM" </term>
        ///                 <description>
        ///                     An invalid parameter was passed in.  This can include an invalid
        ///                     flag or combination of flags.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_FAILED" </term>
        ///                 <description>
        ///                     The display driver failed the specified graphics mode.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_NOTUPDATED" </term>
        ///                 <description>
        ///                     <b>Windows NT/2000/XP:</b>  Unable to write settings to the
        ///                     registry.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_RESTART" </term>
        ///                 <description>
        ///                     The computer must be restarted in order for the graphics mode to
        ///                     work.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         To ensure that the <see cref="Gdi.DEVMODE" /> structure passed to
        ///         <b>ChangeDisplaySettings</b> is valid and contains only values supported by
        ///         the display driver, use the <see cref="Gdi.DEVMODE" /> returned by the
        ///         <see cref="EnumDisplaySettings" /> function.
        ///     </para>
        ///     <para>
        ///         When the display mode is changed dynamically, the <b>WM_DISPLAYCHANGE</b>
        ///         message is sent to all running applications with the following message
        ///         parameters:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>wParam</term>
        ///                 <description>New bits per pixel.</description>
        ///             </item>
        ///             <item>
        ///                 <term>LOWORD(lParam)</term>
        ///                 <description>New pixel width.</description>
        ///             </item>
        ///             <item>
        ///                 <term>HIWORD(lParam)</term>
        ///                 <description>New pixel height.</description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         <b>Windows 95/98/Me:</b>  If the calling thread has any windows,
        ///         <b>ChangeDisplaySettings</b> sends them the <b>WM_DISPLAYCHANGE</b> message
        ///         immediately (for windows in all other threads, the message is sent when the
        ///         thread can receive nonqueued messages).  This may cause the shell to get its
        ///         message too soon and could squash icons.  To avoid this problem, have
        ///         <b>ChangeDisplaySettings</b> do resolution switching by calling on a thread
        ///         with no windows, for example, a new thread.
        ///     </para>
        /// </remarks>
        /// seealso cref="CreateDC" 
        /// <seealso cref="Gdi.DEVMODE" />
        /// <seealso cref="EnumDisplaySettings" />
        // <seealso cref="ChangeDisplaySettingsEx" />
        // <seealso cref="EnumDisplayDevices" />
        // <seealso cref="WM_DISPLAYCHANGE" />
        // WINUSERAPI LONG WINAPI ChangeDisplaySettingsA(IN LPDEVMODEA lpDevMode, IN DWORD dwFlags);
        // WINUSERAPI LONG WINAPI ChangeDisplaySettingsW(IN LPDEVMODEW lpDevMode, IN DWORD dwFlags);
        [DllImport(USER_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, CharSet=CharSet.Auto, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern int ChangeDisplaySettings(ref Gdi.DEVMODE devMode, int flags);
        #endregion int ChangeDisplaySettings(ref Gdi.DEVMODE devMode, int flags)

        #region int ChangeDisplaySettings(IntPtr devMode, int flags)
        /// <summary>
        ///     <para>
        ///         The <b>ChangeDisplaySettings</b> function changes the settings of the default
        ///         display device to the specified graphics mode.
        ///     </para>
        ///     <para>
        ///         To change the settings of a specified display device, use the
        ///         <b>ChangeDisplaySettingsEx</b> function.
        ///     </para>
        /// </summary>
        /// <param name="devMode">
        ///     <para>
        ///         Pointer to a <see cref="Gdi.DEVMODE" /> structure that describes the new
        ///         graphics mode.  If <i>devMode</i> is NULL, all the values currently in the
        ///         registry will be used for the display setting.  Passing NULL for the
        ///         <i>devMode</i> parameter and 0 for the <i>flags</i> parameter is the easiest
        ///         way to return to the default mode after a dynamic mode change.
        ///     </para>
        ///     <para>
        ///         The <see cref="Gdi.DEVMODE.dmSize" /> member of <see cref="Gdi.DEVMODE" />
        ///         must be initialized to the size, in bytes, of the <see cref="Gdi.DEVMODE" />
        ///         structure.  The <see cref="Gdi.DEVMODE.dmDriverExtra" /> member of
        ///         <see cref="Gdi.DEVMODE" /> must be initialized to indicate the number of bytes
        ///         of private driver data following the <see cref="Gdi.DEVMODE" /> structure.  In
        ///         addition, you can use any or all of the following members of the
        ///         <see cref="Gdi.DEVMODE" /> structure:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="Gdi.DEVMODE.dmBitsPerPel" /></term>
        ///                 <description>Bits per pixel.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DEVMODE.dmPelsWidth" /></term>
        ///                 <description>Pixel width.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DEVMODE.dmPelsHeight" /></term>
        ///                 <description>Pixel height.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DEVMODE.dmDisplayFlags" /></term>
        ///                 <description>Mode flags.</description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DEVMODE.dmDisplayFrequency" /></term>
        ///                 <description>Mode frequency.</description>
        ///             </item>
        ///             <item>
        ///                 <term>dmPosition</term>
        ///                 <description>
        ///                     <b>Windows 98/Me, Windows 2000/XP:</b> Position of the device in
        ///                     a multimonitor configuration.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         In addition to using one or more of the preceding <see cref="Gdi.DEVMODE" />
        ///         members, you must also set one or more of the following values in the
        ///         <see cref="Gdi.DEVMODE.dmFields" /> member to change the display setting:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="Gdi.DM_BITSPERPEL" /></term>
        ///                 <description>
        ///                     Use the <see cref="Gdi.DEVMODE.dmBitsPerPel" /> value.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DM_PELSWIDTH" /></term>
        ///                 <description>
        ///                     Use the <see cref="Gdi.DEVMODE.dmPelsWidth" /> value.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DM_PELSHEIGHT" /></term>
        ///                 <description>
        ///                     Use the <see cref="Gdi.DEVMODE.dmPelsHeight" /> value.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DM_DISPLAYFLAGS" /></term>
        ///                 <description>
        ///                     Use the <see cref="Gdi.DEVMODE.dmDisplayFlags" /> value.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="Gdi.DM_DISPLAYFREQUENCY" /></term>
        ///                 <description>
        ///                     Use the <see cref="Gdi.DEVMODE.dmDisplayFrequency" /> value.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DM_POSITION" /></term>
        ///                 <description>
        ///                     <b>Windows 98/Me, Windows 2000/XP:</b> Use the dmPosition value.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <param name="flags">
        ///     <para>
        ///         Indicates how the graphics mode should be changed.  This parameter can be one
        ///         of the following values:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>0</term>
        ///                 <description>
        ///                     The graphics mode for the current screen will be changed
        ///                     dynamically.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_FULLSCREEN" </term>
        ///                 <description>
        ///                     <para>
        ///                         The mode is temporary in nature.
        ///                     </para>
        ///                     <para>
        ///                         <b>Windows NT/2000/XP:</b> If you change to and from another
        ///                         desktop, this mode will not be reset.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_GLOBAL" </term>
        ///                 <description>
        ///                     The settings will be saved in the global settings area so that
        ///                     they will affect all users on the machine.  Otherwise, only the
        ///                     settings for the user are modified.  This flag is only valid when
        ///                     specified with the see cref="Gdi.CDS_UPDATEREGISTRY"  flag.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_NORESET" </term>
        ///                 <description>
        ///                     The settings will be saved in the registry, but will not take
        ///                     affect.  This flag is only valid when specified with the
        ///                     see cref="Gdi.CDS_UPDATEREGISTRY"  flag.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_RESET" </term>
        ///                 <description>
        ///                     The settings should be changed, even if the requested settings are
        ///                     the same as the current settings.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_SET_PRIMARY" </term>
        ///                 <description>
        ///                     This device will become the primary device.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_TEST" /></term>
        ///                 <description>
        ///                     The system tests if the requested graphics mode could be set.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.CDS_UPDATEREGISTRY" /></term>
        ///                 <description>
        ///                     The graphics mode for the current screen will be changed
        ///                     dynamically and the graphics mode will be updated in the registry.
        ///                     The mode information is stored in the USER profile.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         Specifying see cref="Gdi.CDS_TEST" /> allows an application to determine
        ///         which graphics modes are actually valid, without causing the system to
        ///         change to that graphics mode.
        ///     </para>
        ///     <para>
        ///         If see cref="Gdi.CDS_UPDATEREGISTRY" /> is specified and it is possible to
        ///         change the graphics mode dynamically, the information is stored in the
        ///         registry and see cref="Gdi.DISP_CHANGE_SUCCESSFUL" /> is returned.  If it is
        ///         not possible to change the graphics mode dynamically, the information is
        ///         stored in the registry and see cref="Gdi.DISP_CHANGE_RESTART" /> is returned.
        ///     </para>
        ///     <para>
        ///         <b>Windows NT/2000/XP:</b>  If see cref="Gdi.CDS_UPDATEREGISTRY" /> is
        ///         specified and the information could not be stored in the registry, the
        ///         graphics mode is not changed and see cref="Gdi.DISP_CHANGE_NOTUPDATED" /> is
        ///         returned.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         The <b>ChangeDisplaySettings</b> function returns one of the following values:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_SUCCESSFUL" /></term>
        ///                 <description>
        ///                     The settings change was successful.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_BADDUALVIEW" /></term>
        ///                 <description>
        ///                     <b>Windows XP:</b>  The settings change was unsuccessful because
        ///                     system is DualView capable.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_BADFLAGS" /></term>
        ///                 <description>
        ///                     An invalid set of flags was passed in.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_BADMODE" </term>
        ///                 <description>
        ///                     The graphics mode is not supported.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_BADPARAM" </term>
        ///                 <description>
        ///                     An invalid parameter was passed in.  This can include an invalid
        ///                     flag or combination of flags.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_FAILED" /></term>
        ///                 <description>
        ///                     The display driver failed the specified graphics mode.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_NOTUPDATED" /></term>
        ///                 <description>
        ///                     <b>Windows NT/2000/XP:</b>  Unable to write settings to the
        ///                     registry.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>see cref="Gdi.DISP_CHANGE_RESTART" /></term>
        ///                 <description>
        ///                     The computer must be restarted in order for the graphics mode to
        ///                     work.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         To ensure that the <see cref="Gdi.DEVMODE" /> structure passed to
        ///         <b>ChangeDisplaySettings</b> is valid and contains only values supported by
        ///         the display driver, use the <see cref="Gdi.DEVMODE" /> returned by the
        ///         <see cref="EnumDisplaySettings" /> function.
        ///     </para>
        ///     <para>
        ///         When the display mode is changed dynamically, the <b>WM_DISPLAYCHANGE</b>
        ///         message is sent to all running applications with the following message
        ///         parameters:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>wParam</term>
        ///                 <description>New bits per pixel.</description>
        ///             </item>
        ///             <item>
        ///                 <term>LOWORD(lParam)</term>
        ///                 <description>New pixel width.</description>
        ///             </item>
        ///             <item>
        ///                 <term>HIWORD(lParam)</term>
        ///                 <description>New pixel height.</description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         <b>Windows 95/98/Me:</b>  If the calling thread has any windows,
        ///         <b>ChangeDisplaySettings</b> sends them the <b>WM_DISPLAYCHANGE</b> message
        ///         immediately (for windows in all other threads, the message is sent when the
        ///         thread can receive nonqueued messages).  This may cause the shell to get its
        ///         message too soon and could squash icons.  To avoid this problem, have
        ///         <b>ChangeDisplaySettings</b> do resolution switching by calling on a thread
        ///         with no windows, for example, a new thread.
        ///     </para>
        /// </remarks>
        /// seealso cref="CreateDC" />
        /// <seealso cref="Gdi.DEVMODE" />
        /// <seealso cref="EnumDisplaySettings" />
        // <seealso cref="ChangeDisplaySettingsEx" />
        // <seealso cref="EnumDisplayDevices" />
        // <seealso cref="WM_DISPLAYCHANGE" />
        // WINUSERAPI LONG WINAPI ChangeDisplaySettingsA(IN LPDEVMODEA lpDevMode, IN DWORD dwFlags);
        // WINUSERAPI LONG WINAPI ChangeDisplaySettingsW(IN LPDEVMODEW lpDevMode, IN DWORD dwFlags);
        [DllImport(USER_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, CharSet=CharSet.Auto, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern int ChangeDisplaySettings(IntPtr devMode, int flags);
        #endregion int ChangeDisplaySettings(IntPtr devMode, int flags)

		/// <summary>
		/// 
		/// </summary>
		/// <param name="deviceName"></param>
		/// <param name="modeNumber"></param>
		/// <param name="devMode"></param>
		/// <returns></returns>
        [DllImport(USER_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, CharSet=CharSet.Auto, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool EnumDisplaySettings(string deviceName, int modeNumber, out Gdi.DEVMODE devMode);

        #region IntPtr GetDC(IntPtr windowHandle)
        /// <summary>
        ///     <para>
        ///         The <b>GetDC</b> function retrieves a handle to a display device context (DC)
        ///         for the client area of a specified window or for the entire screen.  You can
        ///         use the returned handle in subsequent GDI functions to draw in the DC.
        ///     </para>
        ///     <para>
        ///         The see cref="GetDCEx" /> function is an extension to <b>GetDC</b>, which
        ///         gives an application more control over how and whether clipping occurs in the
        ///         client area.
        ///     </para>
        /// </summary>
        /// <param name="windowHandle">
        ///     <para>
        ///         Handle to the window whose DC is to be retrieved.  If this value is null,
        ///         <b>GetDC</b> retrieves the DC for the entire screen.
        ///     </para>
        ///     <para>
        ///         <b>Windows 98/Me, Windows 2000/XP:</b> To get the DC for a specific display
        ///         monitor, use the see cref="EnumDisplayMonitors" /> and
        ///         see cref="Gdi.CreateDC" /> functions.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is a handle to the DC for the
        ///         specified window's client area.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is null.
        ///     </para>
        ///     <para>
        ///         <b>Windows NT/2000/XP:</b> To get extended error information, call
        ///         <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The <b>GetDC</b> function retrieves a common, class, or private DC depending
        ///         on the class style of the specified window.  For class and private DCs,
        ///         <b>GetDC</b> leaves the previously assigned attributes unchanged.  However,
        ///         for common DCs, <b>GetDC</b> assigns default attributes to the DC each time
        ///         it is retrieved.  For example, the default font is System, which is a bitmap
        ///         font.  Because of this, the handle for a common DC returned by <b>GetDC</b>
        ///         does not tell you what font, color, or brush was used when the window was
        ///         drawn.  To determine the font, call see cref="GetTextFace" />.
        ///     </para>
        ///     <para>
        ///         Note that the handle to the DC can only be used by a single thread at any one
        ///         time.
        ///     </para>
        ///     <para>
        ///         After painting with a common DC, the <see cref="ReleaseDC" /> function must
        ///         be called to release the DC.  Class and private DCs do not have to be
        ///         released.  <see cref="ReleaseDC" /> must be called from the same thread that
        ///         called <b>GetDC</b>.  The number of DCs is limited only by available memory.
        ///     </para>
        ///     <para>
        ///         <b>Windows 95/98/Me:</b> There are only 5 common DCs available per thread,
        ///         thus failure to release a DC can prevent other applications from accessing
        ///         one.
        ///     </para>
        /// </remarks>
        /// seealso cref="GetDCEx" />
        /// <seealso cref="ReleaseDC" />
        /// seealso cref="GetTextFace" />
        /// seealso cref="GetWindowDC" />
        // WINUSERAPI HDC WINAPI GetDC(IN HWND hWnd);
        [DllImport(USER_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr GetDC(IntPtr windowHandle);
        #endregion IntPtr GetDC(IntPtr windowHandle)

        #region bool ReleaseDC(IntPtr windowHandle, IntPtr deviceContext)
        /// <summary>
        ///     <para>
        ///         The <b>ReleaseDC</b> function releases a device context (DC), freeing it for
        ///         use by other applications.  The effect of the <b>ReleaseDC</b> function
        ///         depends on the type of DC.  It frees only common and window DCs.  It has no
        ///         effect on class or private DCs.
        ///     </para>
        /// </summary>
        /// <param name="windowHandle">
        ///     <para>
        ///         Handle to the window whose DC is to be released.
        ///     </para>
        /// </param>
        /// <param name="deviceContext">
        ///     <para>
        ///         Handle to the DC to be released.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         The return value indicates whether the DC was released.  If the DC was
        ///         released, the return value is true.
        ///     </para>
        ///     <para>
        ///         If the DC was not released, the return value is false.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The application must call the <b>ReleaseDC</b> function for each call to the
        ///         see cref="GetWindowDC" /> function and for each call to the
        ///         <see cref="GetDC" /> function that retrieves a common DC.
        ///     </para>
        ///     <para>
        ///         An application cannot use the <b>ReleaseDC</b> function to release a DC that
        ///         was created by calling the see cref="Gdi.CreateDC" /> function; instead, it
        ///         must use the see cref="Gdi.DeleteDC" /> function.  <b>ReleaseDC</b> must be
        ///         called from the same thread that called <b>GetDC</b>.
        ///     </para>
        /// </remarks>
        /// seealso cref="Gdi.CreateDC" />
        /// seealso cref="Gdi.DeleteDC" />
        /// <seealso cref="GetDC" />
        /// seealso cref="GetWindowDC" />
        // WINUSERAPI int WINAPI ReleaseDC(IN HWND hWnd, IN HDC hDC);
        [DllImport(USER_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern bool ReleaseDC(IntPtr windowHandle, IntPtr deviceContext);
        #endregion bool ReleaseDC(IntPtr windowHandle, IntPtr deviceContext)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWndChild"></param>
        /// <param name="hWndNewParent"></param>
        /// <returns></returns>
        [DllImport(USER_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport(USER_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport(USER_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hWndInsertAfter"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="uFlags"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(USER_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    }
}
