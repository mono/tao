#region License
/*
BSD License
Copyright ©2003-2004 Randy Ridge
http://www.randyridge.com/Tao/Default.aspx
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

1. Redistributions of source code must retain the above copyright notice,
   this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither Randy Ridge nor the names of any Tao contributors may be used to
   endorse or promote products derived from this software without specific
   prior written permission.

   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
   "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
   LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
   FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
   COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
   INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
   BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
   LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
   CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
   LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
   ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
   POSSIBILITY OF SUCH DAMAGE.
*/
#endregion License

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Tao.Platform.Unix.Libc.Sys {
    #region Class Documentation
    /// <summary>
    ///     POSIX (mostly GNU and compatibles) libc time.h bindings for the CLI.
    /// </summary>
    /// <remarks>
    ///     Binds functions and definitions in libc.so that are defined in sys/time.h.
    /// </remarks>
    #endregion Class Documentation
    public sealed class Time {
        // --- Structures ---
        #region timeval
        /// <summary>
        ///     This structure represents 32-bit UNIX time, plus the elapsed
        ///     microseconds since the previous UNIX clock tick.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)] 
        public struct timeval {
            #region int tv_sec
            /// <summary>
            ///     Seconds.
            /// </summary>
            // time_t tvsec;
            public int tv_sec;
            #endregion int tv_sec

            #region int tv_usec
            /// <summary>
            ///     Microseconds.
            /// </summary>
            // suseconds_t tv_usec;
            public int tv_usec;
            #endregion int tv_usec
        }
        #endregion timeval

        #region timezone
        /// <summary>
        ///     This structure represents timezone and DST settings.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct timezone {
            #region int tz_minuteswest
            /// <summary>
            ///     Minutes west of Greenwich.
            /// </summary>
            // int tz_minuteswest;
            public int tz_minuteswest;
            #endregion int tx_minuteswest

            #region int tz_dsttime
            /// <summary>
            ///     Type of DST correction.
            /// </summary>
            // int tz_dsttime;
            public int tz_dsttime;
            #endregion int tz_dsttime
        }
        #endregion timezone

        // --- Fields ---
        #region Private Constants
        #region Private Constant LIBC_NATIVE_LIBRARY
        /// <summary>
        ///     Specifies libc's native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies glibc's libc.so for the GNU System and most Posix systems.
        /// </remarks>
        private const string LIBC_NATIVE_LIBRARY = "libc";
        #endregion string LIBC_NATIVE_LIBRARY

        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.Cdecl" />.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants

        // --- Constructors & Destructors ---
        #region Time()
        /// <summary>
        ///     Prevents instantiation.
        /// </summary>
        private Time() {
        }
        #endregion Time()

        // --- Public Externs ---
        #region int gettimeofday(out timeval tv, out timezone tz)
        /// <summary>
        ///     Allows you to get the current UNIX time, as well as the microseconds
        ///     elapsed since the last second's rollover.
        /// </summary>
        /// <param name="tv">
        ///     <para>
        ///         A reference to a timeval structure.  This structure will have the
        ///         <see cref="timeval.tv_sec" /> field set to the current number of
        ///         seconds elapsed since the beginning of the epoch, or 00:00 hours,
        ///         January 1st, 1970 GMT.  The <see cref="timeval.tv_usec" /> is set
        ///         to the number of microseconds elapsed since the last second.
        ///     </para>
        ///     <para>
        ///         <c>usecs_since_1970 = ((tv.tv_sec * 1000000) + tv.tv_usec);</c>
        ///     </para>
        /// </param>
        /// <param name="tz">
        ///     <para>
        ///         A reference to a timezone structure.  This structure will have
        ///         <see cref="timezone.tz_minuteswest" /> set to the number of minutes
        ///         west of Greenwich.
        ///     </para>
        ///     <para>
        ///         For instance, users in North American Eastern Time will recieve a
        ///         value of 300.
        ///     </para>
        /// </param>
        // int gettimeofday(struct timeval *tv, struct timezone *tz);
        [DllImport(LIBC_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int gettimeofday(out timeval tv, out timezone tz);
        #endregion int gettimeofday(out timeval tv, out timezone tz)
    }
}
