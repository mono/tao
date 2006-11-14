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

namespace Tao.Platform.Windows {
    #region Class Documentation
    /// <summary>
    ///     Kernel binding for .NET, implementing Windows-specific kernel functionality.
    /// </summary>
    /// <remarks>
    ///     Binds functions and definitions in kernel32.dll.
    /// </remarks>
    #endregion Class Documentation
    public static class Kernel
    {
        // --- Fields ---
        #region Private Constants
        #region string KERNEL_NATIVE_LIBRARY
        /// <summary>
        ///     Specifies Kernel32's native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies kernel32.dll for Windows.
        /// </remarks>
        private const string KERNEL_NATIVE_LIBRARY = "kernel32.dll";
        #endregion string KERNEL_NATIVE_LIBRARY

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

        #region Public Structs
        #region MEMORYSTATUS
        /// <summary>
        ///     <para>
        ///         The <b>MEMORYSTATUS</b> structure contains information about the current state
        ///         of both physical and virtual memory.
        ///     </para>
        ///     <para>
        ///         The <see cref="GlobalMemoryStatus" /> function stores information in a
        ///         <b>MEMORYSTATUS</b> structure.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <b>MEMORYSTATUS</b> reflects the state of memory at the time of the call.  It
        ///         reflects the size of the paging file at that time.  The operating system can
        ///         enlarge the paging file up to the maximum size set by the administrator.
        ///     </para>
        ///     <para>
        ///         On computers with more than 4 GB of memory, the <b>MEMORYSTATUS</b> structure
        ///         can return incorrect information.  Windows reports a value of -1 to indicate
        ///         an overflow, while Windows NT reports a value that is the real amount of
        ///         memory, modulo 4 GB.  If your application is at risk for this behavior, use
        ///         the <b>GlobalMemoryStatusEx</b> function instead of the
        ///         <see cref="GlobalMemoryStatus" /> function.
        ///     </para>
        /// </remarks>
        /// <seealso cref="GlobalMemoryStatus" />
        // <seealso cref="GlobalMemoryStatusEx" />
        // typedef struct _MEMORYSTATUS {
        //     DWORD dwLength;
        //     DWORD dwMemoryLoad;
        //     SIZE_T dwTotalPhys;
        //     SIZE_T dwAvailPhys;
        //     SIZE_T dwTotalPageFile;
        //     SIZE_T dwAvailPageFile;
        //     SIZE_T dwTotalVirtual;
        //     SIZE_T dwAvailVirtual;
        // } MEMORYSTATUS, *LPMEMORYSTATUS;
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORYSTATUS {
            #region int Length
            /// <summary>
            ///     Size of the <b>MEMORYSTATUS</b> data structure, in bytes.  You do not need to
            ///     set this member before calling the <see cref="GlobalMemoryStatus" /> function;
            ///     the function sets it.
            /// </summary>
            public int Length;
            #endregion int Length

            #region int MemoryLoad
            /// <summary>
            ///     <para>
            ///         Approximate percentage of total physical memory that is in use.
            ///     </para>
            ///     <para>
            ///         <b>Windows NT:</b>  Percentage of approximately the last 1000 pages of
            ///         physical memory that is in use.
            ///     </para>
            /// </summary>
            public int MemoryLoad;
            #endregion int MemoryLoad

            #region int TotalPhys
            /// <summary>
            ///     Total size of physical memory, in bytes.
            /// </summary>
            public int TotalPhys;
            #endregion int TotalPhys

            #region int AvailPhys
            /// <summary>
            ///     Size of physical memory available, in bytes.
            /// </summary>
            public int AvailPhys;
            #endregion int AvailPhys

            #region int TotalPageFile
            /// <summary>
            ///     Size of the committed memory limit, in bytes.
            /// </summary>
            public int TotalPageFile;
            #endregion int TotalPageFile

            #region int AvailPageFile
            /// <summary>
            ///     Size of available memory to commit, in bytes.
            /// </summary>
            public int AvailPageFile;
            #endregion int AvailPageFile

            #region int TotalVirtual
            /// <summary>
            ///     Total size of the user mode portion of the virtual address space of the
            ///     calling process, in bytes.
            /// </summary>
            public int TotalVirtual;
            #endregion int TotalVirtual

            #region int AvailVirtual
            /// <summary>
            ///     Size of unreserved and uncommitted memory in the user mode portion of the
            ///     virtual address space of the calling process, in bytes.
            /// </summary>
            public int AvailVirtual;
            #endregion int AvailVirtual
        }
        #endregion MEMORYSTATUS

        #region SYSTEM_INFO
        /// <summary>
        ///     The <b>SYSTEM_INFO</b> structure contains information about the current computer
        ///     system.  This includes the architecture and type of the processor, the number of
        ///     processors in the system, the page size, and other such information.
        /// </summary>
        /// <seealso cref="GetSystemInfo" />
        /// <seealso cref="SYSTEM_INFO_UNION" />
        // <seealso cref="MapViewOfFile" />
        // <seealso cref="MapViewOfFileEx" />
        // typedef struct _SYSTEM_INFO {
        //     union {
        //         DWORD dwOemId;          // Obsolete field...do not use
        //         struct {
        //             WORD wProcessorArchitecture;
        //             WORD wReserved;
        //         };
        //     };
        //     DWORD dwPageSize;
        //     LPVOID lpMinimumApplicationAddress;
        //     LPVOID lpMaximumApplicationAddress;
        //     DWORD_PTR dwActiveProcessorMask;
        //     DWORD dwNumberOfProcessors;
        //     DWORD dwProcessorType;
        //     DWORD dwAllocationGranularity;
        //     WORD wProcessorLevel;
        //     WORD wProcessorRevision;
        // } SYSTEM_INFO, *LPSYSTEM_INFO;
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_INFO {
            #region SYSTEM_INFO_UNION SystemInfoUnion
            /// <summary>
            ///     Union for the OemId, ProcessorArchitecture, and Reserved fields of the
            ///     SYSTEM_INFO structure.  See <see cref="SYSTEM_INFO_UNION" />.
            /// </summary>
            public SYSTEM_INFO_UNION SystemInfoUnion;
            #endregion SYSTEM_INFO_UNION SystemInfoUnion

            #region int PageSize
            /// <summary>
            ///     Page size and the granularity of page protection and commitment.  This is the
            ///     page size used by the <b>VirtualAlloc</b> function.
            /// </summary>
            public int PageSize;
            #endregion int PageSize

            #region IntPtr MinimumApplicationAddress
            /// <summary>
            ///     Pointer to the lowest memory address accessible to applications and
            ///     dynamic-link libraries (DLLs).
            /// </summary>
            public IntPtr MinimumApplicationAddress;
            #endregion IntPtr MinimumApplicationAddress

            #region IntPtr MaximumApplicationAddress
            /// <summary>
            ///     Pointer to the highest memory address accessible to applications and DLLs.
            /// </summary>
            public IntPtr MaximumApplicationAddress;
            #endregion IntPtr MaximumApplicationAddress

            #region int ActiveProcessorMask
            /// <summary>
            ///     Mask representing the set of processors configured into the system.  Bit 0 is
            ///     processor 0; bit 31 is processor 31.
            /// </summary>
            public int ActiveProcessorMask;
            #endregion int ActiveProcessorMask

            #region int NumberOfProcessors
            /// <summary>
            ///     Number of processors in the system.
            /// </summary>
            public int NumberOfProcessors;
            #endregion int NumberOfProcessors

            #region int ProcessorType
            /// <summary>
            ///     <para>
            ///         An obsolete member that is retained for compatibility with Windows NT 3.5
            ///         and earlier.  Use the <i>SystemInfoUnion.ProcessorArchitecture</i>,
            ///         <i>ProcessorLevel</i>, and <i>ProcessorRevision</i> members to determine
            ///         the type of processor.
            ///     </para>
            ///     <para>
            ///         <b>Windows Me/98/95:</b>  Specifies the type of processor in the system.
            ///         This member is one of the following values:
            ///     </para>
            ///     <para>
            ///         <see cref="WinNt.PROCESSOR_INTEL_386" />
            ///     </para>
            ///     <para>
            ///         <see cref="WinNt.PROCESSOR_INTEL_486" />
            ///     </para>
            ///     <para>
            ///         <see cref="WinNt.PROCESSOR_INTEL_PENTIUM" />
            ///     </para>
            /// </summary>
            public int ProcessorType;
            #endregion int ProcessorType

            #region int AllocationGranularity
            /// <summary>
            ///     Granularity with which virtual memory is allocated.  For example, a
            ///     <b>VirtualAlloc</b> request to allocate 1 byte will reserve an address space
            ///     of <i>AllocationGranularity</i> bytes.  This value was hard coded as 64K in
            ///     the past, but other hardware architectures may require different values.
            /// </summary>
            public int AllocationGranularity;
            #endregion int AllocationGranularity

            #region int ProcessorLevel
            /// <summary>
            ///     <para>
            ///         System's architecture-dependent processor level.  It should be used only
            ///         for display purposes.  To determine the feature set of a processor, use
            ///         the <see cref="IsProcessorFeaturePresent" /> function.
            ///     </para>
            ///     <para>
            ///         If <i>SystemInfoUnion.ProcessorArchitecture</i> is
            ///         <see cref="WinNt.PROCESSOR_ARCHITECTURE_INTEL" />, <i>ProcessorLevel</i>
            ///         is defined by the CPU vendor.
            ///     </para>
            ///     <para>
            ///         If <i>SystemInfoUnion.ProcessorArchitecture</i> is
            ///         <see cref="WinNt.PROCESSOR_ARCHITECTURE_IA64" />, <i>ProcessorLevel</i> is
            ///         set to 1.
            ///     </para>
            ///     <para>
            ///         If <i>SystemInfoUnion.ProcessorArchitecture</i> is
            ///         <see cref="WinNt.PROCESSOR_ARCHITECTURE_MIPS" />, <i>ProcessorLevel</i> is
            ///         of the form 00xx, where xx is an 8-bit implementation number (bits 8-15 of
            ///         the PRId register).  The member can be the following value:
            ///     </para>
            ///     <para>
            ///         <list type="table">
            ///             <listheader>
            ///                 <term>Value</term>
            ///                 <description>Description</description>
            ///             </listheader>
            ///             <item>
            ///                 <term>0004</term>
            ///                 <description>MIPS R4000</description>
            ///             </item>
            ///         </list>
            ///     </para>
            ///     <para>
            ///         If <i>SystemInfoUnion.ProcessorArchitecture</i> is
            ///         <see cref="WinNt.PROCESSOR_ARCHITECTURE_ALPHA" />, <i>ProcessorLevel</i>
            ///         is of the form xxxx, where xxxx is a 16-bit processor version number (the
            ///         low-order 16 bits of a version number from the firmware).  The member can
            ///         be one of the following values:
            ///     </para>
            ///     <para>
            ///         <list type="table">
            ///             <listheader>
            ///                 <term>Value</term>
            ///                 <description>Description</description>
            ///             </listheader>
            ///             <item>
            ///                 <term>21064</term>
            ///                 <description>Alpha 21064</description>
            ///             </item>
            ///             <item>
            ///                 <term>21066</term>
            ///                 <description>Alpha 21066</description>
            ///             </item>
            ///             <item>
            ///                 <term>21164</term>
            ///                 <description>Alpha 21164</description>
            ///             </item>
            ///         </list>
            ///     </para>
            ///     <para>
            ///         If <i>SystemInfoUnion.ProcessorArchitecture</i> is
            ///         <see cref="WinNt.PROCESSOR_ARCHITECTURE_PPC" />, <i>ProcessorLevel</i> is
            ///         of the form xxxx, where xxxx is a 16-bit processor version number (the
            ///         high-order 16 bits of the Processor Version Register).  The member can be
            ///         one of the following values:
            ///     </para>
            ///     <para>
            ///         <list type="table">
            ///             <listheader>
            ///                 <term>Value</term>
            ///                 <description>Description</description>
            ///             </listheader>
            ///             <item>
            ///                 <term>1</term>
            ///                 <description>PPC 601</description>
            ///             </item>
            ///             <item>
            ///                 <term>3</term>
            ///                 <description>PPC 603</description>
            ///             </item>
            ///             <item>
            ///                 <term>4</term>
            ///                 <description>PPC 604</description>
            ///             </item>
            ///             <item>
            ///                 <term>6</term>
            ///                 <description>PPC 603+</description>
            ///             </item>
            ///             <item>
            ///                 <term>9</term>
            ///                 <description>PPC 604+</description>
            ///             </item>
            ///             <item>
            ///                 <term>20</term>
            ///                 <description>PPC 620</description>
            ///             </item>
            ///         </list>
            ///     </para>
            /// </summary>
            public int ProcessorLevel;
            #endregion int ProcessorLevel

            #region int ProcessorRevision
            /// <summary>
            ///     <para>
            ///         Architecture-dependent processor revision.  The following table shows how
            ///         the revision value is assembled for each type of processor architecture:
            ///     </para>
            ///     <para>
            ///         <list type="table">
            ///             <listheader>
            ///                 <term>Processor</term>
            ///                 <description>Description</description>
            ///             </listheader>
            ///             <item>
            ///                 <term>Intel 80386 or 80486</term>
            ///                 <description>
            ///                     <para>
            ///                         A value of the form xxyz.
            ///                     </para>
            ///                     <para>
            ///                         If xx is equal to 0xFF, y - 0xA is the model number, and
            ///                         z is the stepping identifier.  For example, an Intel
            ///                         80486-D0 system returns 0xFFD0.
            ///                     </para>
            ///                     <para>
            ///                         If xx is not equal to 0xFF, xx + 'A' is the stepping
            ///                         letter and yz is the minor stepping.
            ///                     </para>
            ///                 </description>
            ///             </item>
            ///             <item>
            ///                 <term>Intel Pentium, Cyrix, or NextGen 586</term>
            ///                 <description>
            ///                     <para>
            ///                         A value of the form xxyy, where xx is the model number and
            ///                         yy is the stepping.  Display this value of 0x0201 as
            ///                         follows:
            ///                     </para>
            ///                     <para>
            ///                         Model xx, Stepping yy.
            ///                     </para>
            ///                 </description>
            ///             </item>
            ///             <item>
            ///                 <term>MIPS</term>
            ///                 <description>
            ///                     A value of the form 00xx, where xx is the 8-bit revision
            ///                     number of the processor (the low-order 8 bits of the
            ///                     PRId register).
            ///                 </description>
            ///             </item>
            ///             <item>
            ///                 <term>ALPHA</term>
            ///                 <description>
            ///                     <para>
            ///                         A value of the form xxyy, where xxyy is the low-order 16
            ///                         bits of the processor revision number from the firmware.
            ///                         Display this value as follows:
            ///                     </para>
            ///                     <para>
            ///                         Model A+xx, Pass yy.
            ///                     </para>
            ///                 </description>
            ///             </item>
            ///             <item>
            ///                 <term>PPC</term>
            ///                 <description>
            ///                     <para>
            ///                         A value of the form xxyy, where xxyy is the low-order 16
            ///                         bits of the processor version register.  Display this
            ///                         value as follows:
            ///                     </para>
            ///                     <para>
            ///                         xx.yy.
            ///                     </para>
            ///                 </description>
            ///             </item>
            ///         </list>
            ///     </para>
            /// </summary>
            public int ProcessorRevision;
            #endregion int ProcessorRevision
        }
        #endregion SYSTEM_INFO

        #region SYSTEM_INFO_UNION
        /// <summary>
        ///     Union for the OemId, ProcessorArchitecture, and Reserved fields of the
        ///     <see cref="SYSTEM_INFO" /> structure.
        /// </summary>
        /// <seealso cref="SYSTEM_INFO" />
        //     union {
        //         DWORD dwOemId;          // Obsolete field...do not use
        //         struct {
        //             WORD wProcessorArchitecture;
        //             WORD wReserved;
        //         };
        //     };
        [StructLayout(LayoutKind.Explicit)]
        public struct SYSTEM_INFO_UNION {
            #region int OemId
            /// <summary>
            ///     <para>
            ///         An obsolete member that is retained for compatibility with Windows NT 3.5
            ///         and earlier.  New applications should use the <i>ProcessorArchitecture</i>
            ///         branch of the union.
            ///     </para>
            ///     <para>
            ///         <b>Windows Me/98/95:</b>  The system always sets this member to zero, the
            ///         value defined for <see cref="WinNt.PROCESSOR_ARCHITECTURE_INTEL" />.
            ///     </para>
            /// </summary>
            [FieldOffset(0)]
            public int OemId;
            #endregion int OemId

            #region short ProcessorArchitecture
            /// <summary>
            ///     <para>
            ///         System's processor architecture.  This value can be one of the following
            ///         values:
            ///     </para>
            ///     <para>
            ///         <see cref="WinNt.PROCESSOR_ARCHITECTURE_UNKNOWN" />
            ///     </para>
            ///     <para>
            ///         <see cref="WinNt.PROCESSOR_ARCHITECTURE_INTEL" />
            ///     </para>
            ///     <para>
            ///         <b>Windows NT 3.51:</b>  <see cref="WinNt.PROCESSOR_ARCHITECTURE_MIPS" />
            ///     </para>
            ///     <para>
            ///         <b>Windows NT 4.0 and earlier:</b>
            ///         <see cref="WinNt.PROCESSOR_ARCHITECTURE_ALPHA" />
            ///     </para>
            ///     <para>
            ///         <b>Windows NT 4.0 and earlier:</b>
            ///         <see cref="WinNt.PROCESSOR_ARCHITECTURE_PPC" />
            ///     </para>
            ///     <para>
            ///         <b>64-bit Windows:</b>  <see cref="WinNt.PROCESSOR_ARCHITECTURE_IA64" />,
            ///         <see cref="WinNt.PROCESSOR_ARCHITECTURE_IA32_ON_WIN64" />,
            ///         <see cref="WinNt.PROCESSOR_ARCHITECTURE_AMD64" />
            ///     </para>
            /// </summary>
            [FieldOffset(0)]
            public short ProcessorArchitecture;
            #endregion short ProcessorArchitecture

            #region short Reserved
            /// <summary>
            ///     Reserved for future use.
            /// </summary>
            [FieldOffset(2)]
            public short Reserved;
            #endregion short Reserved
        }
        #endregion SYSTEM_INFO_UNION
        #endregion Public Structs

        // --- Public Externs ---
        #region bool Beep(int frequency, int duration)
        /// <summary>
        ///     The <b>Beep</b> function generates simple tones on the speaker.  The function is
        ///     synchronous; it does not return control to its caller until the sound finishes.
        /// </summary>
        /// <param name="frequency">
        ///     <para>
        ///         Frequency of the sound, in hertz.  This parameter must be in the range
        ///         37 through 32,767 (0x25 through 0x7FFF).
        ///     </para>
        ///     <para>
        ///         <b>Windows 95/98/Me:</b>  The <b>Beep</b> function ignores this parameter.
        ///     </para>
        /// </param>
        /// <param name="duration">
        ///     <para>
        ///         Duration of the sound, in milliseconds.
        ///     </para>
        ///     <para>
        ///         <b>Windows 95/98/Me:</b>  The <b>Beep</b> function ignores this parameter.
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
        ///         <b>Terminal Services:</b>  The beep is redirected to the client.
        ///     </para>
        ///     <para>
        ///         <b>Windows 95/98/Me:</b>  On computers with a sound card, the function
        ///         plays the default sound event.  On computers without a sound card, the
        ///         function plays the standard system beep.
        ///     </para>
        /// </remarks>
        // <seealso cref="User.MessageBeep" />
        // WINBASEAPI BOOL WINAPI Beep(IN DWORD dwFreq, IN DWORD dwDuration);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool Beep(int frequency, int duration);
        #endregion bool Beep(int frequency, int duration)

        #region bool FreeLibrary(IntPtr moduleHandle)
        /// <summary>
        ///     The <b>FreeLibrary</b> function decrements the reference count of the loaded
        ///     dynamic-link library (DLL).  When the reference count reaches zero, the module
        ///     is unmapped from the address space of the calling process and the handle is no
        ///     longer valid.
        /// </summary>
        /// <param name="moduleHandle">
        ///     Handle to the loaded DLL module.  The <see cref="LoadLibrary" /> or
        ///     <see cref="GetModuleHandle" /> function returns this handle.
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
        ///         Each process maintains a reference count for each loaded library module.  This
        ///         reference count is incremented each time <see cref="LoadLibrary" /> is called
        ///         and is decremented each time <b>FreeLibrary</b> is called.  A DLL module
        ///         loaded at process initialization due to load-time dynamic linking has a
        ///         reference count of one.  This count is incremented if the same module is
        ///         loaded by a call to <see cref="LoadLibrary" />.
        ///     </para>
        ///     <para>
        ///         Before unmapping a library module, the system enables the DLL to detach from
        ///         the process by calling the DLL's <b>DllMain</b> function, if it has one, with
        ///         the DLL_PROCESS_DETACH value.  Doing so gives the DLL an opportunity to clean
        ///         up resources allocated on behalf of the current process.  After the
        ///         entry-point function returns, the library module is removed from the address
        ///         space of the current process.
        ///     </para>
        ///     <para>
        ///         It is not safe to call <b>FreeLibrary</b> from <b>DllMain</b>.  For more
        ///         information, see the Remarks section in <b>DllMain</b>.
        ///     </para>
        ///     <para>
        ///         Calling <b>FreeLibrary</b> does not affect other processes using the same
        ///         library module.
        ///     </para>
        /// </remarks>
        /// <seealso cref="GetModuleHandle" />
        /// <seealso cref="LoadLibrary" />
        // <seealso cref="DllMain" />
        // <seealso cref="FreeLibraryAndExitThread" />
        // WINBASEAPI BOOL WINAPI FreeLibrary(IN OUT HMODULE hLibModule);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool FreeLibrary(IntPtr moduleHandle);
        #endregion bool FreeLibrary(IntPtr moduleHandle)

        #region int GetDllDirectory(int bufferLength, [Out] StringBuilder buffer)
        /// <summary>
        ///     The <b>GetDllDirectory</b> function retrieves the application-specific portion of
        ///     the search path used to locate DLLs for the application.
        /// </summary>
        /// <param name="bufferLength">
        ///     Size of the output buffer, in characters.
        /// </param>
        /// <param name="buffer">
        ///     Pointer to a buffer that receives the application-specific portion of the search path.
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is the length of the string copied
        ///         to <i>buffer</i>, in characters, not including the terminating null character.
        ///         If the return value is greater than <i>bufferLength</i>, it specifies the size
        ///         of the buffer required for the path.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is zero.  To get extended error
        ///         information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <seealso cref="SetDllDirectory" />
        // WINBASEAPI DWORD WINAPI GetDllDirectoryA(IN DWORD nBufferLength, OUT LPSTR lpBuffer);
        // WINBASEAPI DWORD WINAPI GetDllDirectoryW(IN DWORD nBufferLength, OUT LPWSTR lpBuffer);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, CharSet=CharSet.Auto, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern int GetDllDirectory(int bufferLength, [Out] StringBuilder buffer);
        #endregion int GetDllDirectory(int bufferLength, [Out] StringBuilder buffer)

        #region int GetModuleFileName(IntPtr module, [Out] StringBuilder fileName, int size)
        /// <summary>
        ///     <para>
        ///         The <b>GetModuleFileName</b> function retrieves the fully qualified path for
        ///         the specified module.
        ///     </para>
        ///     <para>
        ///         To specify the process that contains the module, use the
        ///         <b>GetModuleFileNameEx</b> function.
        ///     </para>
        /// </summary>
        /// <param name="module">
        ///     Handle to the module whose path is being requested.  If this parameter is NULL,
        ///     <b>GetModuleFileName</b> retrieves the path for the current module.
        /// </param>
        /// <param name="fileName">
        ///     <para>
        ///         Pointer to a buffer that receives a null-terminated string that specifies the
        ///         fully-qualified path of the module.  If the length of the path exceeds the
        ///         size specified by the <i>size</i> parameter, the function succeeds and the
        ///         string is truncated to <i>size</i> characters and null terminated.
        ///     </para>
        ///     <para>
        ///         The path can have the prefix "\\?\", depending on how the module was loaded.
        ///     </para>
        /// </param>
        /// <param name="size">
        ///     Size of the <i>filename</i> buffer, in TCHARs.
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is the length of the string copied
        ///         to the buffer, in TCHARs.  If the buffer is too small to hold the module name,
        ///         the string is truncated to <i>size</i>, and the function returns <i>size</i>.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is zero.  To get extended error
        ///         information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         If a DLL is loaded in two processes, its file name in one process may differ
        ///         in case from its file name in the other process.
        ///     </para>
        ///     <para>
        ///         For the ANSI version of the function, the number of TCHARs is the number of
        ///         bytes; for the Unicode version, it is the number of characters.
        ///     </para>
        ///     <para>
        ///         <b>Windows Me/98/95:</b>  This function retrieves long file names when an
        ///         application's version number is greater than or equal to 4.00 and the long
        ///         file name is available.  Otherwise, it returns only 8.3 format file names.
        ///     </para>
        /// </remarks>
        /// <seealso cref="GetModuleHandle" />
        /// <seealso cref="LoadLibrary" />
        // <seealso cref="GetModuleFileNameEx" />
        // WINBASEAPI DWORD WINAPI GetModuleFileNameA(IN HMODULE hModule, OUT LPSTR lpFilename, IN DWORD nSize);
        // WINBASEAPI DWORD WINAPI GetModuleFileNameW(IN HMODULE hModule, OUT LPWSTR lpFilename, IN DWORD nSize);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, CharSet=CharSet.Auto, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern int GetModuleFileName(IntPtr module, [Out] StringBuilder fileName, int size);
        #endregion int GetModuleFileName(IntPtr module, [Out] StringBuilder fileName, int size)

        #region IntPtr GetModuleHandle(string moduleName)
        /// <summary>
        ///     <para>
        ///         The <b>GetModuleHandle</b> function retrieves a module handle for the
        ///         specified module if the file has been mapped into the address space of the
        ///         calling process.
        ///     </para>
        ///     <para>
        ///         To avoid the race conditions described in the Remarks section, use the
        ///         <b>GetModuleHandleEx</b> function.
        ///     </para>
        /// </summary>
        /// <param name="moduleName">
        ///     <para>
        ///         Pointer to a null-terminated string that contains the name of the module
        ///         (either a .dll or .exe file).  If the file name extension is omitted, the
        ///         default library extension .dll is appended.  The file name string can include
        ///         a trailing point character (.) to indicate that the module name has no
        ///         extension.  The string does not have to specify a path.  When specifying a
        ///         path, be sure to use backslashes (\), not forward slashes (/).  The name is
        ///         compared (case independently) to the names of modules currently mapped into
        ///         the address space of the calling process.
        ///     </para>
        ///     <para>
        ///         If this parameter is NULL, <b>GetModuleHandle</b> returns a handle to the
        ///         file used to create the calling process.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is a handle to the specified module
        ///         (IntPtr).
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is NULL (IntPtr.Zero).  To get
        ///         extended error information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The returned handle is not global or inheritable.  It cannot be duplicated
        ///         or used by another process.
        ///     </para>
        ///     <para>
        ///         The <b>GetModuleHandle</b> function returns a handle to a mapped module
        ///         without incrementing its reference count.  Therefore, use care when passing
        ///         the handle to the <see cref="FreeLibrary" /> function, because doing so can
        ///         cause a DLL module to be unmapped prematurely.
        ///     </para>
        ///     <para>
        ///         This function must be used carefully in a multithreaded application.  There
        ///         is no guarantee that the module handle remains valid between the time this
        ///         function returns the handle and the time it is used.  For example, a thread
        ///         retrieves a module handle, but before it uses the handle, a second thread
        ///         frees the module.  If the system loads another module, it could reuse the
        ///         module handle that was recently freed.  Therefore, first thread would have
        ///         a handle to a module different than the one intended.
        ///     </para>
        /// </remarks>
        /// <seealso cref="FreeLibrary" />
        /// <seealso cref="GetModuleFileName" />
        // <seealso cref="GetModuleHandleEx" />
        // WINBASEAPI HMODULE WINAPI GetModuleHandleA(IN LPCSTR lpModuleName);
        // WINBASEAPI HMODULE WINAPI GetModuleHandleW(IN LPCWSTR lpModuleName);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, CharSet=CharSet.Auto, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr GetModuleHandle(string moduleName);
        #endregion IntPtr GetModuleHandle(string moduleName)

        #region IntPtr GetProcAddress(IntPtr module, string processName)
        /// <summary>
        ///     The <b>GetProcAddress</b> function retrieves the address of an exported function
        ///     or variable from the specified dynamic-link library (DLL).
        /// </summary>
        /// <param name="module">
        ///     Handle to the DLL module that contains the function or variable.  The
        ///     <see cref="LoadLibrary" /> or <see cref="GetModuleHandle" /> function returns
        ///     this handle.
        /// </param>
        /// <param name="processName">
        ///     Pointer to a null-terminated string that specifies the function or variable name,
        ///     or the function's ordinal value.  If this parameter is an ordinal value, it must
        ///     be in the low-order word; the high-order word must be zero.
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is the address of the exported
        ///         function or variable.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is NULL (IntPtr.Zero).  To get
        ///         extended error information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The spelling and case of a function name pointed to by <i>processName</i> must
        ///         be identical to that in the EXPORTS statement of the source DLL's
        ///         module-definition (.def) file.  The exported names of functions may differ
        ///         from the names you use when calling these functions in your code.  This
        ///         difference is hidden by macros used in the SDK header files.
        ///     </para>
        ///     <para>
        ///         The <i>processName</i> parameter can identify the DLL function by specifying
        ///         an ordinal value associated with the function in the EXPORTS statement.
        ///         <b>GetProcAddress</b> verifies that the specified ordinal is in the range 1
        ///         through the highest ordinal value exported in the .def file.  The function
        ///         then uses the ordinal as an index to read the function's address from a
        ///         function table.  If the .def file does not number the functions consecutively
        ///         from 1 to N (where N is the number of exported functions), an error can occur
        ///         where <b>GetProcAddress</b> returns an invalid, non-NULL address, even though
        ///         there is no function with the specified ordinal.
        ///     </para>
        ///     <para>
        ///         In cases where the function may not exist, the function should be specified by
        ///         name rather than by ordinal value.
        ///     </para>
        /// </remarks>
        /// <seealso cref="FreeLibrary" />
        /// <seealso cref="GetModuleHandle" />
        /// <seealso cref="LoadLibrary" />
        // WINBASEAPI FARPROC WINAPI GetProcAddress(IN HMODULE hModule, IN LPCSTR lpProcName);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, CharSet=CharSet.Ansi, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr GetProcAddress(IntPtr module, string processName);
        #endregion IntPtr GetProcAddress(IntPtr module, string processName)

        #region bool GetProcessWorkingSetSize(IntPtr process, out int minimumWorkingSetSize, out int maximumWorkingSetSize)
        /// <summary>
        ///     The <b>GetProcessWorkingSetSize</b> function retrieves the minimum and maximum
        ///     working set sizes of the specified process.
        /// </summary>
        /// <param name="process">
        ///     Handle to the process whose working set sizes will be obtained.  The handle must
        ///     have the PROCESS_QUERY_INFORMATION access right.
        /// </param>
        /// <param name="minimumWorkingSetSize">
        ///     Pointer to a variable that receives the minimum working set size of the specified
        ///     process, in bytes.  The virtual memory manager attempts to keep at least this much
        ///     memory resident in the process whenever the process is active.
        /// </param>
        /// <param name="maximumWorkingSetSize">
        ///     Pointer to a variable that receives the maximum working set size of the specified
        ///     process, in bytes.  The virtual memory manager attempts to keep no more than this
        ///     much memory resident in the process whenever the process is active when memory is
        ///     in short supply.
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
        ///     The "working set" of a process is the set of memory pages currently visible to
        ///     the process in physical RAM memory.  These pages are resident and available for
        ///     an application to use without triggering a page fault.  The minimum and maximum
        ///     working set sizes affect the virtual memory paging behavior of a process.
        /// </remarks>
        /// <seealso cref="SetProcessWorkingSetSize" />
        // WINBASEAPI BOOL WINAPI GetProcessWorkingSetSize(IN HANDLE hProcess, OUT PSIZE_T lpMinimumWorkingSetSize, OUT PSIZE_T lpMaximumWorkingSetSize);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool GetProcessWorkingSetSize(IntPtr process, out int minimumWorkingSetSize, out int maximumWorkingSetSize);
        #endregion bool GetProcessWorkingSetSize(IntPtr process, out int minimumWorkingSetSize, out int maximumWorkingSetSize)

        #region int GetSystemDirectory([Out] StringBuilder buffer, int size)
        /// <summary>
        ///     <para>
        ///         The <b>GetSystemDirectory</b> function retrieves the path of the system
        ///         directory.  The system directory contains system such files such as
        ///         dynamic-link libraries, drivers, and font files.
        ///     </para>
        ///     <para>
        ///         This function is provided primarily for compatibility.  Applications should
        ///         store code in the Program Files folder and persistent data in the Application
        ///         Data folder in the user's profile.
        ///     </para>
        /// </summary>
        /// <param name="buffer">
        ///     Pointer to the buffer to receive the null-terminated string containing the path.
        ///     This path does not end with a backslash unless the system directory is the root
        ///     directory.  For example, if the system directory is named Windows\System on drive
        ///     C, the path of the system directory retrieved by this function is
        ///     C:\Windows\System.
        /// </param>
        /// <param name="size">
        ///     Maximum size of the buffer, in TCHARs.  This value should be set to at least
        ///     MAX_PATH+1 to allow sufficient space for the path and the null terminator.
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is the length, in TCHARs, of the
        ///         string copied to the buffer, not including the terminating null character.  If
        ///         the length is greater than the size of the buffer, the return value is the
        ///         size of the buffer required to hold the path.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is zero.  To get extended error
        ///         information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     Applications should not create files in the system directory.  If the user is
        ///     running a shared version of the operating system, the application does not have
        ///     write access to the system directory.
        /// </remarks>
        /// <seealso cref="GetWindowsDirectory" />
        // <seealso cref="GetCurrentDirectory" />
        // <seealso cref="SetCurrentDirectory" />
        // WINBASEAPI UINT WINAPI GetSystemDirectoryA(OUT LPSTR lpBuffer, IN UINT uSize);
        // WINBASEAPI UINT WINAPI GetSystemDirectoryW(OUT LPWSTR lpBuffer, IN UINT uSize);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, CharSet=CharSet.Auto, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern int GetSystemDirectory([Out] StringBuilder buffer, int size);
        #endregion int GetSystemDirectory([Out] StringBuilder buffer, int size)

        #region GetSystemInfo(out SYSTEM_INFO systemInfo)
        /// <summary>
        ///     <para>
        ///         The <b>GetSystemInfo</b> function returns information about the current
        ///         system.
        ///     </para>
        ///     <para>
        ///         To retrieve accurate information for a Win32-based application running on
        ///         WOW64, call the <b>GetNativeSystemInfo</b> function.
        ///     </para>
        /// </summary>
        /// <param name="systemInfo">
        ///     Pointer to a <see cref="SYSTEM_INFO" /> structure that receives the information.
        /// </param>
        /// <seealso cref="SYSTEM_INFO" />
        // <seealso cref="GetNativeSystemInfo" />
        // WINBASEAPI VOID WINAPI GetSystemInfo(OUT LPSYSTEM_INFO lpSystemInfo);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void GetSystemInfo(out SYSTEM_INFO systemInfo);
        #endregion GetSystemInfo(out SYSTEM_INFO systemInfo)

        #region int GetSystemWindowsDirectory([Out] StringBuilder buffer, int size)
        /// <summary>
        ///     The <b>GetSystemWindowsDirectory</b> function retrieves the path of the shared
        ///     Windows directory on a multi-user system.
        /// </summary>
        /// <param name="buffer">
        ///     Pointer to the buffer to receive a null-terminated string containing the path.
        ///     This path does not end with a backslash unless the Windows directory is the root
        ///     directory.  For example, if the Windows directory is named Windows on drive C,
        ///     the path of the Windows directory retrieved by this function is C:\Windows.  If
        ///     the system was installed in the root directory of drive C, the path retrieved
        ///     is C:\.
        /// </param>
        /// <param name="size">
        ///     Maximum size of the buffer specified by the <i>buffer</i> parameter, in TCHARs.
        ///     This value should be set to at least MAX_PATH+1 to allow sufficient space for the
        ///     path and the null-terminating character.
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is the length of the string copied
        ///         to the buffer, in TCHARs, not including the terminating null character.
        ///     </para>
        ///     <para>
        ///         If the length is greater than the size of the buffer, the return value is the
        ///         size of the buffer required to hold the path.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is zero.  To get extended error
        ///         information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         On a system that is running Terminal Server, each user has a unique Windows
        ///         directory.  The system Windows directory is shared by all users, so it is the
        ///         directory where an application should store initialization and help files that
        ///         apply to all users.
        ///     </para>
        ///     <para>
        ///         With Terminal Services, the <b>GetSystemWindowsDirectory</b> function
        ///         retrieves the path of the system Windows directory, while the
        ///         <see cref="GetWindowsDirectory" /> function retrieves the path of a Windows
        ///         directory that is private for each user.  On a single-user system,
        ///         <b>GetSystemWindowsDirectory</b> is the same as
        ///         <see cref="GetWindowsDirectory" />.
        ///     </para>
        ///     <para>
        ///         <b>Windows NT 4.0 Terminal Server Edition:</b>  To retrieve the shared
        ///         Windows directory, call <see cref="GetSystemDirectory" /> and trim the
        ///         "System32" element from the end of the returned path.
        ///     </para>
        /// </remarks>
        /// <seealso cref="GetWindowsDirectory" />
        // WINBASEAPI UINT WINAPI GetSystemWindowsDirectoryA(OUT LPSTR lpBuffer, IN UINT uSize);
        // WINBASEAPI UINT WINAPI GetSystemWindowsDirectoryW(OUT LPWSTR lpBuffer, IN UINT uSize);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, CharSet=CharSet.Auto, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern int GetSystemWindowsDirectory([Out] StringBuilder buffer, int size);
        #endregion int GetSystemWindowsDirectory([Out] StringBuilder buffer, int size)

        #region int GetTickCount()
        /// <summary>
        ///     The <b>GetTickCount</b> function retrieves the number of milliseconds that have
        ///     elapsed since the system was started.  It is limited to the resolution of the
        ///     system timer.  To obtain the system timer resolution, use the
        ///     <b>GetSystemTimeAdjustment</b> function.
        /// </summary>
        /// <returns>
        ///     The return value is the number of milliseconds that have elapsed since the system
        ///     was started.
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The elapsed time is stored as a DWORD value.  Therefore, the time will wrap
        ///         around to zero if the system is run continuously for 49.7 days.
        ///     </para>
        ///     <para>
        ///         If you need a higher resolution timer, use a multimedia timer or a
        ///         high-resolution timer.
        ///     </para>
        ///     <para>
        ///         To obtain the time elapsed since the computer was started, retrieve the System
        ///         Up Time counter in the performance data in the registry key
        ///         HKEY_PERFORMANCE_DATA.  The value returned is an 8-byte value.
        ///     </para>
        /// </remarks>
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int GetTickCount();
        #endregion int GetTickCount()

        #region int GetWindowsDirectory([Out] StringBuilder buffer, int size)
        /// <summary>
        ///     <para>
        ///         The <b>GetWindowsDirectory</b> function retrieves the path of the Windows
        ///         directory.  The Windows directory contains such files as applications,
        ///         initialization files, and help files.
        ///     </para>
        ///     <para>
        ///         This function is provided primarily for compatibility.  Applications should
        ///         store code in the Program Files folder and persistent data in the Application
        ///         Data folder in the user's profile.
        ///     </para>
        /// </summary>
        /// <param name="buffer">
        ///     Pointer to the buffer to receive the null-terminated string containing the path.
        ///     This path does not end with a backslash unless the Windows directory is the root
        ///     directory.  For example, if the Windows directory is named Windows on drive C, the
        ///     path of the Windows directory retrieved by this function is C:\Windows.  If the
        ///     system was installed in the root directory of drive C, the path retrieved is C:\.
        /// </param>
        /// <param name="size">
        ///     Maximum size of the buffer specified by the <i>buffer</i> parameter, in TCHARs.
        ///     This value should be set to MAX_PATH.
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is the length of the string copied
        ///         to the buffer, in TCHARs, not including the terminating null character.
        ///     </para>
        ///     <para>
        ///         If the length is greater than the size of the buffer, the return value is the
        ///         size of the buffer required to hold the path.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is zero.  To get extended error
        ///         information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         The Windows directory is the directory where an application should store
        ///         initialization and help files. If the user is running a shared version of the
        ///         system, the Windows directory is guaranteed to be private for each user.
        ///     </para>
        ///     <para>
        ///         If an application creates other files that it wants to store on a per-user
        ///         basis, it should place them in the directory specified by the HOMEPATH
        ///         environment variable.  This directory will be different for each user, if so
        ///         specified by an administrator, through the User Manager administrative tool.
        ///         HOMEPATH always specifies either the user's home directory, which is
        ///         guaranteed to be private for each user, or a default directory (for example,
        ///         C:\USERS\DEFAULT) where the user will have all access.
        ///     </para>
        ///     <para>
        ///         <b>Terminal Services:</b>  If the application is running in a Terminal
        ///         Services environment, each user has a unique Windows directory.  If an
        ///         application that is not Terminal-Services-aware calls this function, it
        ///         retrieves the path of the Windows directory on the client, not the Windows
        ///         directory on the server.
        ///     </para>
        /// </remarks>
        /// <seealso cref="GetSystemDirectory" />
        /// <seealso cref="GetSystemWindowsDirectory" />
        // <seealso cref="GetCurrentDirectory" />
        // WINBASEAPI UINT WINAPI GetWindowsDirectoryA(OUT LPSTR lpBuffer, IN UINT uSize);
        // WINBASEAPI UINT WINAPI GetWindowsDirectoryW(OUT LPWSTR lpBuffer, IN UINT uSize);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, CharSet=CharSet.Auto, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern int GetWindowsDirectory([Out] StringBuilder buffer, int size);
        #endregion int GetWindowsDirectory([Out] StringBuilder buffer, int size)

        #region GlobalMemoryStatus(out MEMORYSTATUS buffer)
        /// <summary>
        ///     <para>
        ///         The <b>GlobalMemoryStatus</b> function obtains information about the system's
        ///         current usage of both physical and virtual memory.
        ///     </para>
        ///     <para>
        ///         To obtain information about the extended portion of the virtual address space,
        ///         or if your application may run on computers with more than 4 GB of main
        ///         memory, use the <b>GlobalMemoryStatusEx</b> function.
        ///     </para>
        /// </summary>
        /// <param name="buffer">
        ///     Pointer to a <see cref="MEMORYSTATUS" /> structure.  The <b>GlobalMemoryStatus</b>
        ///     function stores information about current memory availability into this structure.
        /// </param>
        /// <remarks>
        ///     <para>
        ///         You can use the <b>GlobalMemoryStatus</b> function to determine how much
        ///         memory your application can allocate without severely impacting other
        ///         applications.
        ///     </para>
        ///     <para>
        ///         The information returned by the <b>GlobalMemoryStatus</b> function is
        ///         volatile.  There is no guarantee that two sequential calls to this function
        ///         will return the same information.
        ///     </para>
        ///     <para>
        ///         On computers with more than 4 GB of memory, the <b>GlobalMemoryStatus</b>
        ///         function can return incorrect information.  Windows 2000 and later report a
        ///         value of -1 to indicate an overflow.  Earlier versions of Windows NT report a
        ///         value that is the real amount of memory, modulo 4 GB.  For this reason, use
        ///         the <b>GlobalMemoryStatusEx</b> function instead.
        ///     </para>
        ///     <para>
        ///         On Intel x86 computers with more than 2 GB and less than 4 GB of memory, the
        ///         <b>GlobalMemoryStatus</b> function will always return 2 GB in the
        ///         <see cref="MEMORYSTATUS.TotalPhys" /> member of the
        ///         <see cref="MEMORYSTATUS" /> structure.  Similarly, if the total available
        ///         memory is between 2 and 4 GB, the <see cref="MEMORYSTATUS.AvailPhys" /> member
        ///         of the <see cref="MEMORYSTATUS" /> structure will be rounded down to 2 GB.  If
        ///         the executable is linked using the /LARGEADDRESSWARE linker option, then the
        ///         <b>GlobalMemoryStatus</b> function will return the correct amount of physical
        ///         memory in both members.
        ///     </para>
        /// </remarks>
        /// <seealso cref="MEMORYSTATUS" />
        // <seealso cref="GlobalMemoryStatusEx" />
        // WINBASEAPI VOID WINAPI GlobalMemoryStatus(IN OUT LPMEMORYSTATUS lpBuffer);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void GlobalMemoryStatus(out MEMORYSTATUS buffer);
        #endregion GlobalMemoryStatus(out MEMORYSTATUS buffer)

        #region bool IsProcessorFeaturePresent(int processorFeature)
        /// <summary>
        ///     The <b>IsProcessorFeaturePresent</b> function determines whether the specified
        ///     processor feature is supported by the current computer.
        /// </summary>
        /// <param name="processorFeature">
        ///     <para>
        ///         Processor feature to be tested.  This parameter can be one of the following
        ///         values:
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Value</term>
        ///                 <description>Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term><see cref="WinNt.PF_3DNOW_INSTRUCTIONS_AVAILABLE" /></term>
        ///                 <description>
        ///                     The 3D-Now instruction set is available.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="WinNt.PF_COMPARE_EXCHANGE_DOUBLE" /></term>
        ///                 <description>
        ///                     The compare and exchange double operation is available (Pentium,
        ///                     MIPS, and Alpha).
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="WinNt.PF_FLOATING_POINT_EMULATED" /></term>
        ///                 <description>
        ///                     <para>
        ///                         Floating-point operations are emulated using a software
        ///                         emulator.
        ///                     </para>
        ///                     <para>
        ///                         This function returns true if floating-point operations are
        ///                         emulated; otherwise, it returns false.
        ///                     </para>
        ///                     <para>
        ///                         <b>Windows NT 4.0:</b>  This function returns false if
        ///                         floating-point operations are emulated; otherwise, it returns
        ///                         true.  This behavior is a bug that is fixed in later versions.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="WinNt.PF_FLOATING_POINT_PRECISION_ERRATA" /></term>
        ///                 <description>
        ///                     <b>Pentium:</b>  In rare circumstances, a floating-point precision
        ///                     error can occur.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="WinNt.PF_MMX_INSTRUCTIONS_AVAILABLE" /></term>
        ///                 <description>
        ///                     The MMX instruction set is available.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="WinNt.PF_PAE_ENABLED" /></term>
        ///                 <description>
        ///                     The processor is PAE-enabled.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="WinNt.PF_RDTSC_INSTRUCTION_AVAILABLE" /></term>
        ///                 <description>
        ///                     The RDTSC instruction is available.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="WinNt.PF_XMMI_INSTRUCTIONS_AVAILABLE" /></term>
        ///                 <description>
        ///                     The SSE instruction set is available.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term><see cref="WinNt.PF_XMMI64_INSTRUCTIONS_AVAILABLE" /></term>
        ///                 <description>
        ///                     The SSE2 instruction set is available.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the feature is supported, the return value is true.
        ///     </para>
        ///     <para>
        ///         If the feature is not supported, the return value is false.
        ///     </para>
        /// </returns>
        // WINBASEAPI BOOL WINAPI IsProcessorFeaturePresent(IN DWORD ProcessorFeature);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern bool IsProcessorFeaturePresent(int processorFeature);
        #endregion bool IsProcessorFeaturePresent(int processorFeature)

        #region IntPtr LoadLibrary(string fileName)
        /// <summary>
        ///     The <b>LoadLibrary</b> function maps the specified executable module into the
        ///     address space of the calling process.
        /// </summary>
        /// <param name="fileName">
        ///     <para>
        ///         Pointer to a null-terminated string that names the executable module (either
        ///         a .dll or .exe file).  The name specified is the file name of the module and
        ///         is not related to the name stored in the library module itself, as specified
        ///         by the LIBRARY keyword in the module-definition (.def) file.
        ///     </para>
        ///     <para>
        ///         If the string specifies a path but the file does not exist in the specified
        ///         directory, the function fails.  When specifying a path, be sure to use
        ///         backslashes (\), not forward slashes (/).
        ///     </para>
        ///     <para>
        ///         If the string does not specify a path, the function uses a standard search
        ///         strategy to find the file.  See the Remarks for more information.
        ///     </para>
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is a handle to the module (IntPtr).
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is NULL (IntPtr.Zero).  To get
        ///         extended error information, call <see cref="Marshal.GetLastWin32Error" />.
        ///     </para>
        ///     <para>
        ///         <b>Windows Me/98/95:</b>  If you are using <b>LoadLibrary</b> to load a module
        ///         that contains a resource whose numeric identifier is greater than 0x7FFF,
        ///         <b>LoadLibrary</b> fails.  If you are attempting to load a 16-bit DLL directly
        ///         from 32-bit code, <b>LoadLibrary</b> fails.  If you are attempting to load a
        ///         DLL whose subsystem version is greater than 4.0, <b>LoadLibrary</b> fails.  If
        ///         your <b>DllMain</b> function tries to call the Unicode version of a function,
        ///         <b>LoadLibrary</b> fails.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         <b>LoadLibrary</b> can be used to map a DLL module and return a handle that
        ///         can be used in <see cref="GetProcAddress" /> to get the address of a DLL
        ///         function.  <b>LoadLibrary</b> can also be used to map other executable
        ///         modules.  For example, the function can specify an .exe file to get a
        ///         handle that can be used in <b>FindResource</b> or <b>LoadResource</b>.
        ///         However, do not use <b>LoadLibrary</b> to run an .exe file, use the
        ///         <b>CreateProcess</b> function.
        ///     </para>
        ///     <para>
        ///         If the module is a DLL not already mapped for the calling process, the system
        ///         calls the DLL's <b>DllMain</b> function with the DLL_PROCESS_ATTACH value.  If
        ///         the DLL's entry-point function does not return TRUE, <b>LoadLibrary</b> fails
        ///         and returns NULL.  (The system immediately calls your entry-point function
        ///         with DLL_PROCESS_DETACH and unloads the DLL.)
        ///     </para>
        ///     <para>
        ///         It is not safe to call <b>LoadLibrary</b> from <b>DllMain</b>.  For more
        ///         information, see the Remarks section in <b>DllMain</b>.
        ///     </para>
        ///     <para>
        ///         Module handles are not global or inheritable.  A call to <b>LoadLibrary</b> by
        ///         one process does not produce a handle that another process can use — for
        ///         example, in calling <see cref="GetProcAddress" />.  The other process must
        ///         make its own call to <b>LoadLibrary</b> for the module before calling
        ///         <see cref="GetProcAddress" />.
        ///     </para>
        ///     <para>
        ///         If no file name extension is specified in the <i>fileName</i> parameter, the
        ///         default library extension .dll is appended.  However, the file name string
        ///         can include a trailing point character (.) to indicate that the module name
        ///         has no extension.  When no path is specified, the function searches for loaded
        ///         modules whose base name matches the base name of the module to be loaded.  If
        ///         the name matches, the load succeeds.  Otherwise, the function searches for the
        ///         file in the following sequence:
        ///     </para>
        ///     <para>
        ///         <list type="number">
        ///             <item>
        ///                 <description>
        ///                     The directory from which the application loaded.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                     The current directory.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                     The system directory.  Use the <see cref="GetSystemDirectory" />
        ///                     function to get the path of this directory.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                     <para>
        ///                         The 16-bit system directory.  There is no function that
        ///                         obtains the path of this directory, but it is searched.
        ///                     </para>
        ///                     <para>
        ///                         <b>Windows Me/98/95:</b>  This directory does not exist.
        ///                     </para>
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                     The Windows directory.  Use the <see cref="GetWindowsDirectory" />
        ///                     function to get the path of this directory.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                     The directories that are listed in the PATH environment variable.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         <b>Windows Server 2003, Windows XP SP1:</b>  The default value of
        ///         HKLM\System\CurrentControlSet\Control\Session Manager\SafeDllSearchMode is 1
        ///         (current directory is searched after the system and Windows directories).
        ///     </para>
        ///     <para>
        ///         <b>Windows XP:</b>  If
        ///         HKLM\System\CurrentControlSet\Control\Session Manager\SafeDllSearchMode is 1,
        ///         the current directory is searched after the system and Windows directories,
        ///         but before the directories in the PATH environment variable.  The default
        ///         value is 0 (current directory is searched before the system and Windows
        ///         directories).
        ///     </para>
        ///     <para>
        ///         The first directory searched is the one directory containing the image file
        ///         used to create the calling process (for more information, see the
        ///         <b>CreateProcess</b> function).  Doing this allows private dynamic-link
        ///         library (DLL) files associated with a process to be found without adding the
        ///         process's installed directory to the PATH environment variable.
        ///     </para>
        ///     <para>
        ///         The search path can be altered using the <see cref="SetDllDirectory" />
        ///         function.  This solution is recommended instead of using
        ///         <b>SetCurrentDirectory</b> or hard-coding the full path to the DLL.
        ///     </para>
        ///     <para>
        ///         If a path is specified and there is a redirection file for the application,
        ///         the function searches for the module in the application's directory.  If the
        ///         module exists in the application's directory, the <b>LoadLibrary</b> function
        ///         ignores the specified path and loads the module from the application's
        ///         directory.  If the module does not exist in the application's directory,
        ///         <b>LoadLibrary</b> loads the module from the specified directory.
        ///     </para>
        /// </remarks>
        /// <seealso cref="FreeLibrary" />
        /// <seealso cref="GetProcAddress" />
        /// <seealso cref="GetSystemDirectory" />
        /// <seealso cref="GetWindowsDirectory" />
        /// <seealso cref="SetDllDirectory" />
        // <seealso cref="DllMain" />
        // <seealso cref="FindResource" />
        // <seealso cref="LoadLibraryEx" />
        // <seealso cref="LoadResource" />
        // WINBASEAPI HMODULE WINAPI LoadLibraryA(IN LPCSTR lpLibFileName);
        // WINBASEAPI HMODULE WINAPI LoadLibraryW(IN LPCWSTR lpLibFileName);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, CharSet=CharSet.Auto, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr LoadLibrary(string fileName);
        #endregion IntPtr LoadLibrary(string fileName)

        #region bool QueryPerformanceCounter(out long performanceCount)
        /// <summary>
        ///     The <b>QueryPerformanceCounter</b> function retrieves the current value of the
        ///     high-resolution performance counter.
        /// </summary>
        /// <param name="performanceCount">
        ///     Pointer to a variable that receives the current performance-counter value, in
        ///     counts.
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
        ///     On a multiprocessor machine, it should not matter which processor is called.
        ///     However, you can get different results on different processors due to bugs in the
        ///     BIOS or the HAL.  To specify processor affinity for a thread, use the
        ///     <b>SetThreadAffinityMask</b> function.
        /// </remarks>
        /// <seealso cref="QueryPerformanceCounterFast" />
        /// <seealso cref="QueryPerformanceFrequency" />
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool QueryPerformanceCounter(out long performanceCount);
        #endregion bool QueryPerformanceCounter(out long performanceCount)

        #region int QueryPerformanceCounterFast(out long performanceCount)
        /// <summary>
        ///     The <b>QueryPerformanceCounterFast</b> function retrieves the current value of the
        ///     high-resolution performance counter.
        /// </summary>
        /// <param name="performanceCount">
        ///     Pointer to a variable that receives the current performance-counter value, in
        ///     counts.
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the function succeeds, the return value is true.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is false.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <para>
        ///         This version of <see cref="QueryPerformanceCounter" /> is slightly faster.  It
        ///         does not set the last Windows error.  Use with care.
        ///     </para>
        ///     <para>
        ///         On a multiprocessor machine, it should not matter which processor is called.
        ///         However, you can get different results on different processors due to bugs in
        ///         the BIOS or the HAL.  To specify processor affinity for a thread, use the
        ///         <b>SetThreadAffinityMask</b> function.
        ///     </para>
        /// </remarks>
        /// <seealso cref="QueryPerformanceCounter" />
        /// <seealso cref="QueryPerformanceFrequency" />
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="QueryPerformanceCounter"), SuppressUnmanagedCodeSecurity]
        public static extern int QueryPerformanceCounterFast(out long performanceCount);
        #endregion int QueryPerformanceCounterFast(out long performanceCount)

        #region bool QueryPerformanceFrequency(out long frequency)
        /// <summary>
        ///     The <b>QueryPerformanceFrequency</b> function retrieves the frequency of the
        ///     high-resolution performance counter, if one exists.  The frequency cannot change
        ///     while the system is running.
        /// </summary>
        /// <param name="frequency">
        ///     Pointer to a variable that receives the current performance-counter frequency, in
        ///     counts per second.  If the installed hardware does not support a high-resolution
        ///     performance counter, this parameter can be zero.
        /// </param>
        /// <returns>
        ///     <para>
        ///         If the installed hardware supports a high-resolution performance counter, the
        ///         return value is true.
        ///     </para>
        ///     <para>
        ///         If the function fails, the return value is false.  To get extended error
        ///         information, call <see cref="Marshal.GetLastWin32Error" />.  For example, if
        ///         the installed hardware does not support a high-resolution performance counter,
        ///         the function fails.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     <b>Note</b>  The frequency of the high-resolution performance counter is not the
        ///     processor speed.
        /// </remarks>
        /// <seealso cref="QueryPerformanceCounter" />
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool QueryPerformanceFrequency(out long frequency);
        #endregion #region bool QueryPerformanceFrequency(out long frequency)

        #region bool SetDllDirectory(string pathName)
        /// <summary>
        ///     The <b>SetDllDirectory</b> function modifies the search path used to locate DLLs
        ///     for the application.
        /// </summary>
        /// <param name="pathName">
        ///     Pointer to a null-terminated string that specifies the directories to be added to
        ///     the search path, separated by semicolons.  If this parameter is NULL, the default
        ///     search path is used.
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
        ///         The <b>SetDllDirectory</b> function affects all subsequent calls to the
        ///         <see cref="LoadLibrary" /> and <b>LoadLibraryEx</b> functions.  After calling
        ///         <b>SetDllDirectory</b>, the DLL search path is:
        ///     </para>
        ///     <para>
        ///         <list type="number">
        ///             <item>
        ///                 <description>
        ///                     The directory from which the application loaded.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                     The directory specified by the <i>pathName</i> parameter.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                     The system directory.  Use the <see cref="GetSystemDirectory" />
        ///                     function to get the path of this directory.  The name of this
        ///                     directory is System32.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                     The 16-bit system directory.  There is no function that obtains
        ///                     the path of this directory, but it is searched.  The name of this
        ///                     directory is System.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                     The Windows directory.  Use the <see cref="GetWindowsDirectory" />
        ///                     function to get the path of this directory.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                     The directories that are listed in the PATH environment variable.
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        ///         To revert to the default search path used by <see cref="LoadLibrary" /> and
        ///         <b>LoadLibraryEx</b>, call <b>SetDllDirectory</b> with NULL.
        ///     </para>
        /// </remarks>
        /// <seealso cref="GetDllDirectory" />
        /// <seealso cref="GetSystemDirectory" />
        /// <seealso cref="GetWindowsDirectory" />
        /// <seealso cref="LoadLibrary" />
        // <seealso cref="LoadLibraryEx" />
        // WINBASEAPI BOOL WINAPI SetDllDirectoryA(IN LPCSTR lpPathName);
        // WINBASEAPI BOOL WINAPI SetDllDirectoryW(IN LPCWSTR lpPathName);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, CharSet=CharSet.Auto, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool SetDllDirectory(string pathName);
        #endregion bool SetDllDirectory(string pathName)

        #region bool SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize)
        /// <summary>
        ///     The <b>SetProcessWorkingSetSize</b> function sets the minimum and maximum working
        ///     set sizes for the specified process.
        /// </summary>
        /// <param name="process">
        ///     <para>
        ///         Handle to the process whose working set sizes is to be set.
        ///     </para>
        ///     <para>
        ///         The handle must have the PROCESS_SET_QUOTA access right.
        ///     </para>
        /// </param>
        /// <param name="minimumWorkingSetSize">
        ///     <para>
        ///         Minimum working set size for the process, in bytes.  The virtual memory
        ///         manager attempts to keep at least this much memory resident in the
        ///         process whenever the process is active.
        ///     </para>
        ///     <para>
        ///         If both <i>minimumWorkingSetSize</i> and <i>maximumWorkingSetSize</i> have the
        ///         value -1, the function temporarily trims the working set of the specified
        ///         process to zero.  This essentially swaps the process out of physical RAM
        ///         memory.
        ///     </para>
        /// </param>
        /// <param name="maximumWorkingSetSize">
        ///     <para>
        ///         Maximum working set size for the process, in bytes.  The virtual memory
        ///         manager attempts to keep no more than this much memory resident in the
        ///         process whenever the process is active and memory is in short supply.
        ///     </para>
        ///     <para>
        ///         If both <i>minimumWorkingSetSize</i> and <i>maximumWorkingSetSize</i> have the
        ///         value -1, the function temporarily trims the working set of the specified
        ///         process to zero.  This essentially swaps the process out of physical RAM
        ///         memory.
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
        ///         The working set of a process is the set of memory pages currently visible to
        ///         the process in physical RAM memory.  These pages are resident and available
        ///         for an application to use without triggering a page fault.  The minimum and
        ///         maximum working set sizes affect the virtual memory paging behavior of a
        ///         process.
        ///     </para>
        ///     <para>
        ///         The working set of the specified process can be emptied by specifying the
        ///         value -1 for both the minimum and maximum working set sizes.
        ///     </para>
        ///     <para>
        ///         If the values of either <i>minimumWorkingSetSize</i> or
        ///         <i>maximumWorkingSetSize</i> are greater than the process' current working
        ///         set sizes, the specified process must have the SE_INC_BASE_PRIORITY_NAME
        ///         privilege.  Users in the Administrators and Power Users groups generally
        ///         have this privilege.
        ///     </para>
        ///     <para>
        ///         The operating system allocates working set sizes on a first-come,
        ///         first-served basis.  For example, if an application successfully sets 40
        ///         megabytes as its minimum working set size on a 64-megabyte system, and a
        ///         second application requests a 40-megabyte working set size, the operating
        ///         system denies the second application's request.
        ///     </para>
        ///     <para>
        ///         Using the <b>SetProcessWorkingSetSize</b> function to set an application's
        ///         minimum and maximum working set sizes does not guarantee that the requested
        ///         memory will be reserved, or that it will remain resident at all times.  When
        ///         the application is idle, or a low-memory situation causes a demand for memory,
        ///         the operating system can reduce the application's working set.  An application
        ///         can use the <b>VirtualLock</b> function to lock ranges of the application's
        ///         virtual address space in memory; however, that can potentially degrade the
        ///         performance of the system.
        ///     </para>
        ///     <para>
        ///         When you increase the working set size of an application, you are taking away
        ///         physical memory from the rest of the system.  This can degrade the performance
        ///         of other applications and the system as a whole.  It can also lead to failures
        ///         of operations that require physical memory to be present; for example,
        ///         creating processes, threads, and kernel pool.  Thus, you must use the
        ///         <b>SetProcessWorkingSetSize</b> function carefully.  You must always consider
        ///         the performance of the whole system when you are designing an application.
        ///     </para>
        /// </remarks>
        /// <seealso cref="GetProcessWorkingSetSize" />
        // <seealso cref="VirtualLock" />
        // WINBASEAPI BOOL WINAPI SetProcessWorkingSetSize(IN HANDLE hProcess, IN SIZE_T dwMinimumWorkingSetSize, IN SIZE_T dwMaximumWorkingSetSize);
        [DllImport(KERNEL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        #endregion bool SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize)
    }
}
