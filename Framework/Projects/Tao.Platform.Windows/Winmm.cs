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

namespace Tao.Platform.Windows {
    #region Class Documentation
    /// <summary>
    ///     Windows Multimedia binding for .NET, implementing Windows-specific multimedia
    ///     functionality.
    /// </summary>
    /// <remarks>
    ///     Binds functions and definitions in winmm.dll.
    /// </remarks>
    #endregion Class Documentation
    public sealed class Winmm {
        // --- Fields ---
        #region Private Constants
        #region String WINMM_NATIVE_LIBRARY
        /// <summary>
        ///     Specifies Winmm's native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies winmm.dll for Windows.
        /// </remarks>
        private const String WINMM_NATIVE_LIBRARY = "winmm.dll";
        #endregion String WINMM_NATIVE_LIBRARY

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
        #region Int32 SND_SYNC
        /// <summary>
        ///     Synchronous playback of a sound event.  <b>PlaySound</b> returns after the sound
        ///     event completes.
        /// </summary>
        // #define SND_SYNC 0x0000 /* play synchronously (default) */
        public static Int32 SND_SYNC = 0x0000;
        #endregion Int32 SND_SYNC

        #region Int32 SND_ASYNC
        /// <summary>
        ///     The sound is played asynchronously and <b>PlaySound</b> returns immediately after
        ///     beginning the sound.  To terminate an asynchronously played waveform sound, call
        ///     <b>PlaySound</b> with <i>sound</i> set to NULL.
        /// </summary>
        // #define SND_ASYNC 0x0001 /* play asynchronously */
        public static Int32 SND_ASYNC = 0x0001;
        #endregion Int32 SND_ASYNC

        #region Int32 SND_NODEFAULT
        /// <summary>
        ///     No default sound event is used.  If the sound cannot be found, <b>PlaySound</b>
        ///     returns silently without playing the default sound.
        /// </summary>
        // #define SND_NODEFAULT 0x0002 /* silence (!default) if sound not found */
        public static Int32 SND_NODEFAULT = 0x0002;
        #endregion Int32 SND_NODEFAULT

        #region Int32 SND_MEMORY
        /// <summary>
        ///     A sound event's file is loaded in RAM.  The parameter specified by <i>sound</i>
        ///     must point to an image of a sound in memory.
        /// </summary>
        // #define SND_MEMORY 0x0004 /* pszSound points to a memory file */
        public static Int32 SND_MEMORY = 0x0004;
        #endregion Int32 SND_MEMORY

        #region Int32 SND_LOOP
        /// <summary>
        ///     The sound plays repeatedly until <b>PlaySound</b> is called again with the
        ///     <i>sound</i> parameter set to NULL.  You must also specify the
        ///     <see cref="SND_ASYNC" /> flag to indicate an asynchronous sound event.
        /// </summary>
        // #define SND_LOOP 0x0008 /* loop the sound until next sndPlaySound */
        public static Int32 SND_LOOP = 0x0008;
        #endregion Int32 SND_LOOP

        #region Int32 SND_NOSTOP
        /// <summary>
        ///     <para>
        ///         The specified sound event will yield to another sound event that is already
        ///         playing.  If a sound cannot be played because the resource needed to
        ///         generate that sound is busy playing another sound, the function immediately
        ///         returns FALSE without playing the requested sound.
        ///     </para>
        ///     <para>
        ///         If this flag is not specified, <b>PlaySound</b> attempts to stop the currently
        ///         playing sound so that the device can be used to play the new sound.
        ///     </para>
        /// </summary>
        // #define SND_NOSTOP 0x0010 /* don't stop any currently playing sound */
        public static Int32 SND_NOSTOP = 0x0010;
        #endregion Int32 SND_NOSTOP

        #region Int32 SND_NOWAIT
        /// <summary>
        ///     If the driver is busy, return immediately without playing the sound.
        /// </summary>
        // #define SND_NOWAIT 0x00002000L /* don't wait if the driver is busy */
        public static Int32 SND_NOWAIT = 0x00002000;
        #endregion Int32 SND_NOWAIT

        #region Int32 SND_ALIAS
        /// <summary>
        ///     The <i>sound</i> parameter is a system-event alias in the registry or the WIN.INI
        ///     file.  Do not use with either <see cref="SND_FILENAME" /> or
        ///     <see cref="SND_RESOURCE" />.
        /// </summary>
        // #define SND_ALIAS 0x00010000L /* name is a registry alias */
        public static Int32 SND_ALIAS = 0x00010000;
        #endregion Int32 SND_ALIAS

        #region Int32 SND_ALIAS_ID
        /// <summary>
        ///     The <i>sound</i> parameter is a predefined sound identifier.
        /// </summary>
        // #define SND_ALIAS_ID 0x00110000L /* alias is a predefined ID */
        public static Int32 SND_ALIAS_ID = 0x00110000;
        #endregion Int32 SND_ALIAS_ID

        #region Int32 SND_FILENAME
        /// <summary>
        ///     The <i>sound</i> parameter is a filename.
        /// </summary>
        // #define SND_FILENAME 0x00020000L /* name is file name */
        public static Int32 SND_FILENAME = 0x00020000;
        #endregion Int32 SND_FILENAME

        #region Int32 SND_RESOURCE
        /// <summary>
        ///     The <i>sound</i> parameter is a resource identifier; <i>mod</i> must identify the
        ///     instance that contains the resource.
        /// </summary>
        // #define SND_RESOURCE 0x00040004L /* name is resource name or atom */
        public static Int32 SND_RESOURCE = 0x00040004;
        #endregion Int32 SND_RESOURCE

        #region Int32 SND_PURGE
        /// <summary>
        ///     <para>
        ///         Sounds are to be stopped for the calling task.  If <i>sound</i> is not
        ///         NULL, all instances of the specified sound are stopped.  If <i>sound</i> is
        ///         NULL, all sounds that are playing on behalf of the calling task are stopped.
        ///     </para>
        ///     <para>
        ///         You must also specify the instance handle to stop <see cref="SND_RESOURCE" />
        ///         events.
        ///     </para>
        /// </summary>
        // #define SND_PURGE 0x0040 /* purge non-static events for task */
        public static Int32 SND_PURGE = 0x0040;
        #endregion Int32 SND_PURGE

        #region Int32 SND_APPLICATION
        /// <summary>
        ///     The sound is played using an application-specific association.
        /// </summary>
        // #define SND_APPLICATION 0x0080 /* look for application specific association */
        public static Int32 SND_APPLICATION = 0x0080;
        #endregion Int32 SND_APPLICATION

        #region Int32 TIMERR_BASE
        /// <summary>
        ///     Timer base identifier.
        /// </summary>
        // #define TIMERR_BASE            96
        public static Int32 TIMERR_BASE = 96;
        #endregion Int32 TIMERR_BASE

        #region Int32 TIMERR_NOERROR
        /// <summary>
        ///     Successful.
        /// </summary>
        // #define TIMERR_NOERROR (0) /* no error */
        public static Int32 TIMERR_NOERROR = 0;
        #endregion Int32 TIMERR_NOERROR

        #region Int32 TIMERR_NOCANDO
        /// <summary>
        ///     Resolution specified is out of range.
        /// </summary>
        // #define TIMERR_NOCANDO (TIMERR_BASE+1) /* request not completed */
        public static Int32 TIMERR_NOCANDO = TIMERR_BASE + 1;
        #endregion Int32 TIMERR_NOCANDO
        #endregion Public Constants

        // --- Constructors & Destructors ---
        #region Winmm()
        /// <summary>
        ///     Prevents instantiation.
        /// </summary>
        private Winmm() {
        }
        #endregion Winmm()

        // --- Public Externs ---
        #region Boolean PlaySound(String sound, IntPtr mod, Int32 soundFlags)
        /// <summary>
        ///     The <b>PlaySound</b> function plays a sound specified by the given filename,
        ///     resource, or system event.  (A system event may be associated with a sound in the
        ///     registry or in the WIN.INI file.)
        /// </summary>
        /// <param name="sound">
        ///     <para>
        ///         A string that specifies the sound to play.  If this parameter is NULL, any
        ///         currently playing waveform sound is stopped.  To stop a non-waveform sound,
        ///         specify <see cref="SND_PURGE" /> in the <i>soundFlags</i> parameter.
        ///     </para>
        ///     <para>
        ///         Three flags in <i>soundFlags</i> (<see cref="SND_ALIAS" />,
        ///         <see cref="SND_FILENAME" />, and <see cref="SND_RESOURCE" />) determine
        ///         whether the name is interpreted as an alias for a system event, a filename, or
        ///         a resource identifier.  If none of these flags are specified, <b>PlaySound</b>
        ///         searches the registry or the WIN.INI file for an association with the
        ///         specified sound name.  If an association is found, the sound event is played.
        ///         If no association is found in the registry, the name is interpreted as a
        ///         filename.
        ///     </para>
        /// </param>
        /// <param name="mod">
        ///     Handle to the executable file that contains the resource to be loaded.  This
        ///     parameter must be NULL unless <see cref="SND_RESOURCE" /> is specified in
        ///     <i>soundFlags</i>.
        /// </param>
        /// <param name="soundFlags">
        ///     <para>
        ///         Flags for playing the sound.  The following values are defined:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="SND_APPLICATION" /></term>
        ///                 <description>
        ///                     The sound is played using an application-specific association.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="SND_ALIAS" /></term>
        ///                 <description>
        ///                     The <i>sound</i> parameter is a system-event alias in the registry
        ///                     or the WIN.INI file.  Do not use with either
        ///                     <see cref="SND_FILENAME" /> or <see cref="SND_RESOURCE" />.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="SND_ALIAS_ID" /></term>
        ///                 <description>
        ///                     The <i>sound</i> parameter is a predefined sound identifier.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="SND_ASYNC" /></term>
        ///                 <description>
        ///                     The sound is played asynchronously and <b>PlaySound</b> returns
        ///                     immediately after beginning the sound.  To terminate an
        ///                     asynchronously played waveform sound, call <b>PlaySound</b> with
        ///                     <i>sound</i> set to NULL.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="SND_FILENAME" /></term>
        ///                 <description>
        ///                     The <i>sound</i> parameter is a filename.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="SND_LOOP" /></term>
        ///                 <description>
        ///                     The sound plays repeatedly until <b>PlaySound</b> is called again
        ///                     with the <i>sound</i> parameter set to NULL.  You must also
        ///                     specify the <see cref="SND_ASYNC" /> flag to indicate an
        ///                     asynchronous sound event.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="SND_MEMORY" /></term>
        ///                 <description>
        ///                     A sound event's file is loaded in RAM.  The parameter specified by
        ///                     <i>sound</i> must point to an image of a sound in memory.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="SND_NODEFAULT" /></term>
        ///                 <description>
        ///                     No default sound event is used.  If the sound cannot be found,
        ///                     <b>PlaySound</b> returns silently without playing the default
        ///                     sound.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="SND_NOSTOP" /></term>
        ///                 <description>
        ///                     <para>
        ///                         The specified sound event will yield to another sound event
        ///                         that is already playing.  If a sound cannot be played because
        ///                         the resource needed to generate that sound is busy playing
        ///                         another sound, the function immediately returns FALSE without
        ///                         playing the requested sound.
        ///                     </para>
        ///                     <para>
        ///                         If this flag is not specified, <b>PlaySound</b> attempts to
        ///                         stop the currently playing sound so that the device can be
        ///                         used to play the new sound.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="SND_NOWAIT" /></term>
        ///                 <description>
        ///                     If the driver is busy, return immediately without playing the
        ///                     sound.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="SND_PURGE" /></term>
        ///                 <description>
        ///                     <para>
        ///                         Sounds are to be stopped for the calling task.  If
        ///                         <i>sound</i> is not NULL, all instances of the specified sound
        ///                         are stopped.  If <i>sound</i> is NULL, all sounds that are
        ///                         playing on behalf of the calling task are stopped.
        ///                     </para>
        ///                     <para>
        ///                         You must also specify the instance handle to stop
        ///                         <see cref="SND_RESOURCE" /> events.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="SND_RESOURCE" /></term>
        ///                 <description>
        ///                     The <i>sound</i> parameter is a resource identifier; <i>mod</i>
        ///                     must identify the instance that contains the resource.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="SND_SYNC" /></term>
        ///                 <description>
        ///                     Synchronous playback of a sound event.  <b>PlaySound</b> returns
        ///                     after the sound event completes.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <returns>
        ///     Returns TRUE if successful or FALSE otherwise.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The sound specified by <i>sound</i> must fit into available physical memory
        ///         and be playable by an installed waveform-audio device driver.
        ///         <b>PlaySound</b> searches the following directories for sound files: the
        ///         current directory; the Windows directory; the Windows system directory;
        ///         directories listed in the PATH environment variable; and the list of
        ///         directories mapped in a network.  For more information about the directory
        ///         search order, see the documentation for the <b>OpenFile</b> function.
        ///     </para>
        ///     <para>
        ///         If it cannot find the specified sound, <b>PlaySound</b> uses the default
        ///         system event sound entry instead.  If the function can find neither the
        ///         system default entry nor the default sound, it makes no sound and returns
        ///         FALSE.
        ///     </para>
        /// </remarks>
        // WINMMAPI BOOL WINAPI PlaySoundA(IN LPCSTR pszSound, IN HMODULE hmod, IN DWORD fdwSound);
        // WINMMAPI BOOL WINAPI PlaySoundW(IN LPCWSTR pszSound, IN HMODULE hmod, IN DWORD fdwSound);
        [DllImport(WINMM_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, CharSet=CharSet.Auto), SuppressUnmanagedCodeSecurity]
        public static extern Boolean PlaySound(String sound, IntPtr mod, Int32 soundFlags);
        #endregion Boolean PlaySound(String sound, IntPtr mod, Int32 soundFlags)

        #region timeBeginPeriod(Int32 period)
        /// <summary>
        ///     The <b>timeBeginPeriod</b> function sets the minimum timer resolution for an
        ///     application or device driver.
        /// </summary>
        /// <param name="period">
        ///     Minimum timer resolution, in milliseconds, for the application or device driver.
        /// </param>
        /// <returns>
        ///     Returns <see cref="TIMERR_NOERROR" /> if successful or
        ///     <see cref="TIMERR_NOCANDO" /> if the resolution specified in <i>period</i> is out
        ///     of range.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         Call this function immediately before using timer services, and call the
        ///         <see cref="timeEndPeriod" /> function immediately after you are finished
        ///         using the timer services.
        ///     </para>
        ///     <para>
        ///         You must match each call to <b>timeBeginPeriod</b> with a call to
        ///         <see cref="timeEndPeriod" />, specifying the same minimum resolution in both
        ///         calls.  An application can make multiple <b>timeBeginPeriod</b> calls as long
        ///         as each call is matched with a call to <see cref="timeEndPeriod" />.
        ///     </para>
        /// </remarks>
        /// <seealso cref="timeEndPeriod" />
        // WINMMAPI MMRESULT WINAPI timeBeginPeriod(IN UINT uPeriod);
        [DllImport(WINMM_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern Int32 timeBeginPeriod(Int32 period);
        #endregion timeBeginPeriod(Int32 period)

        #region timeEndPeriod(Int32 period)
        /// <summary>
        ///     The <b>timeEndPeriod</b> function clears a previously set minimum timer
        ///     resolution.
        /// </summary>
        /// <param name="period">
        ///     Minimum timer resolution specified in the previous call to the
        ///     <see cref="timeBeginPeriod" /> function.
        /// </param>
        /// <returns>
        ///     Returns <see cref="TIMERR_NOERROR" /> if successful or
        ///     <see cref="TIMERR_NOCANDO" /> if the resolution specified in <i>period</i> is out
        ///     of range
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         Call this function immediately after you are finished using timer services.
        ///     </para>
        ///     <para>
        ///         You must match each call to <see cref="timeBeginPeriod" /> with a call to
        ///         <b>timeEndPeriod</b>, specifying the same minimum resolution in both calls.
        ///         An application can make multiple <see cref="timeBeginPeriod" /> calls as long
        ///         as each call is matched with a call to <b>timeEndPeriod</b>.
        ///     </para>
        /// </remarks>
        /// <seealso cref="timeBeginPeriod" />
        // WINMMAPI MMRESULT WINAPI timeEndPeriod(IN UINT uPeriod)
        [DllImport(WINMM_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern Int32 timeEndPeriod(Int32 period);
        #endregion timeEndPeriod(Int32 period)

        #region Int32 timeGetTime()
        /// <summary>
        ///     The <b>timeGetTime</b> function retrieves the system time, in milliseconds.
        ///     The system time is the time elapsed since Windows was started.
        /// </summary>
        /// <returns>
        ///     Returns the system time, in milliseconds.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The only difference between this function and the <b>timeGetSystemTime</b>
        ///         function is that <b>timeGetSystemTime</b> uses the <b>MMTIME</b> structure to
        ///         return the system time.  The <b>timeGetTime</b> function has less overhead
        ///         than <b>timeGetSystemTime</b>.
        ///     </para>
        ///     <para>
        ///         Note that the value returned by the <b>timeGetTime</b> function is a DWORD
        ///         value.  The return value wraps around to 0 every 2^32 milliseconds, which is
        ///         about 49.71 days.  This can cause problems in code that directly uses the
        ///         <b>timeGetTime</b> return value in computations, particularly where the value
        ///         is used to control code execution.  You should always use the difference
        ///         between two <b>timeGetTime</b> return values in computations.
        ///     </para>
        ///     <para>
        ///         <b>Windows NT/2000:</b> The default precision of the <b>timeGetTime</b>
        ///         function can be five milliseconds or more, depending on the machine.  You
        ///         can use the <see cref="timeBeginPeriod" /> and <see cref="timeEndPeriod" />
        ///         functions to increase the precision of <b>timeGetTime</b>.  If you do so, the
        ///         minimum difference between successive values returned by <b>timeGetTime</b>
        ///         can be as large as the minimum period value set using
        ///         <see cref="timeBeginPeriod" /> and <see cref="timeEndPeriod" />.  Use the
        ///         <see cref="Kernel.QueryPerformanceCounter" /> and
        ///         <see cref="Kernel.QueryPerformanceFrequency" /> functions to measure short
        ///         time intervals at a high resolution.
        ///     </para>
        ///     <para>
        ///         <b>Windows 95:</b> The default precision of the <b>timeGetTime</b> function is
        ///         1 millisecond.  In other words, the <b>timeGetTime</b> function can return
        ///         successive values that differ by just 1 millisecond.  This is true no matter
        ///         what calls have been made to the <b>timeBeginPeriod</b> and
        ///         <b>timeEndPeriod</b> functions.
        ///     </para>
        /// </remarks>
        /// <seealso cref="Kernel.QueryPerformanceCounter" />
        /// <seealso cref="Kernel.QueryPerformanceFrequency" />
        /// <seealso cref="timeBeginPeriod" />
        /// <seealso cref="timeEndPeriod" />
        // <seealso cref="MMTIME" />
        // <seealso cref="timeGetSystemTime" />
        // WINMMAPI DWORD WINAPI timeGetTime(void);
        [DllImport(WINMM_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern Int32 timeGetTime();
        #endregion Int32 timeGetTime()
    }
}
