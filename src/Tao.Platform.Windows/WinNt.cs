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
    ///     WinNT binding for .NET, implementing Windows NT-specific functionality.
    /// </summary>
    #endregion Class Documentation
    public static class WinNt
    {
        // --- Fields ---
        #region Public Constants
        #region int PROCESSOR_INTEL_386
        /// <summary>
        ///     Intel i386 processor.
        /// </summary>
        // #define PROCESSOR_INTEL_386 386
        public const int PROCESSOR_INTEL_386 = 386;
        #endregion int PROCESSOR_INTEL_386

        #region int PROCESSOR_INTEL_486
        /// <summary>
        ///     Intel i486 processor.
        /// </summary>
        // #define PROCESSOR_INTEL_486 486
        public const int PROCESSOR_INTEL_486 = 486;
        #endregion int PROCESSOR_INTEL_486

        #region int PROCESSOR_INTEL_PENTIUM
        /// <summary>
        ///     Intel Pentium processor.
        /// </summary>
        // #define PROCESSOR_INTEL_PENTIUM 586
        public const int PROCESSOR_INTEL_PENTIUM = 586;
        #endregion int PROCESSOR_INTEL_PENTIUM

        #region int PROCESSOR_INTEL_IA64
        /// <summary>
        ///     Intel IA64 processor.
        /// </summary>
        // #define PROCESSOR_INTEL_IA64 2200
        public const int PROCESSOR_INTEL_IA64 = 2200;
        #endregion int PROCESSOR_INTEL_IA64

        #region int PROCESSOR_AMD_X8664
        /// <summary>
        ///     AMD X86 64 processor.
        /// </summary>
        // #define PROCESSOR_AMD_X8664 8664
        public const int PROCESSOR_AMD_X8664 = 8664;
        #endregion int PROCESSOR_AMD_X8664

        #region int PROCESSOR_MIPS_R4000
        /// <summary>
        ///     MIPS R4000, R4101, R3910 processor.
        /// </summary>
        // #define PROCESSOR_MIPS_R4000 4000 // incl R4101 & R3910 for Windows CE
        public const int PROCESSOR_MIPS_R4000 = 4000;
        #endregion int PROCESSOR_MIPS_R4000

        #region int PROCESSOR_ALPHA_21064
        /// <summary>
        ///     Alpha 210 64 processor.
        /// </summary>
        // #define PROCESSOR_ALPHA_21064 21064
        public const int PROCESSOR_ALPHA_21064 = 21064;
        #endregion int PROCESSOR_ALPHA_21064

        #region int PROCESSOR_PPC_601
        /// <summary>
        ///     PPC 601 processor.
        /// </summary>
        // #define PROCESSOR_PPC_601 601
        public const int PROCESSOR_PPC_601 = 601;
        #endregion int PROCESSOR_PPC_601

        #region int PROCESSOR_PPC_603
        /// <summary>
        ///     PPC 603 processor.
        /// </summary>
        // #define PROCESSOR_PPC_603 603
        public const int PROCESSOR_PPC_603 = 603;
        #endregion int PROCESSOR_PPC_603

        #region int PROCESSOR_PPC_604
        /// <summary>
        ///     PPC 604 processor.
        /// </summary>
        // #define PROCESSOR_PPC_604 604
        public const int PROCESSOR_PPC_604 = 604;
        #endregion int PROCESSOR_PPC_604

        #region int PROCESSOR_PPC_620
        /// <summary>
        ///     PPC 620 processor.
        /// </summary>
        // #define PROCESSOR_PPC_620 620
        public const int PROCESSOR_PPC_620 = 620;
        #endregion int PROCESSOR_PPC_620

        #region int PROCESSOR_HITACHI_SH3
        /// <summary>
        ///     Hitachi SH3 processor.
        /// </summary>
        // #define PROCESSOR_HITACHI_SH3 10003 // Windows CE
        public const int PROCESSOR_HITACHI_SH3 = 10003;
        #endregion int PROCESSOR_HITACHI_SH3

        #region int PROCESSOR_HITACHI_SH3E
        /// <summary>
        ///     Hitachi SH3E processor.
        /// </summary>
        // #define PROCESSOR_HITACHI_SH3E 10004 // Windows CE
        public const int PROCESSOR_HITACHI_SH3E = 10004;
        #endregion int PROCESSOR_HITACHI_SH3E

        #region int PROCESSOR_HITACHI_SH4
        /// <summary>
        ///     Hitachi SH4 processor.
        /// </summary>
        // #define PROCESSOR_HITACHI_SH4 10005 // Windows CE
        public const int PROCESSOR_HITACHI_SH4 = 10005;
        #endregion int PROCESSOR_HITACHI_SH4

        #region int PROCESSOR_MOTOROLA_821
        /// <summary>
        ///     Motorola 821 processor.
        /// </summary>
        // #define PROCESSOR_MOTOROLA_821 821 // Windows CE
        public const int PROCESSOR_MOTOROLA_821 = 821;
        #endregion int PROCESSOR_MOTOROLA_821

        #region int PROCESSOR_SHx_SH3
        /// <summary>
        ///     SHx SH3 processor.
        /// </summary>
        // #define PROCESSOR_SHx_SH3 103 // Windows CE
        public const int PROCESSOR_SHx_SH3 = 103;
        #endregion int PROCESSOR_SHx_SH3

        #region int PROCESSOR_SHx_SH4
        /// <summary>
        ///     SHx SH4 processor.
        /// </summary>
        // #define PROCESSOR_SHx_SH4 104 // Windows CE
        public const int PROCESSOR_SHx_SH4 = 104;
        #endregion int PROCESSOR_SHx_SH4

        #region int PROCESSOR_STRONGARM
        /// <summary>
        ///     StrongARM processor.
        /// </summary>
        // #define PROCESSOR_STRONGARM 2577 // Windows CE - 0xA11
        public const int PROCESSOR_STRONGARM = 2577;
        #endregion int PROCESSOR_STRONGARM

        #region int PROCESSOR_ARM720
        /// <summary>
        ///     ARM 720 processor.
        /// </summary>
        // #define PROCESSOR_ARM720 1824 // Windows CE - 0x720
        public const int PROCESSOR_ARM720 = 1824;
        #endregion int PROCESSOR_ARM720

        #region int PROCESSOR_ARM820
        /// <summary>
        ///     ARM 820 processor.
        /// </summary>
        // #define PROCESSOR_ARM820 2080 // Windows CE - 0x820
        public const int PROCESSOR_ARM820 = 2080;
        #endregion int PROCESSOR_ARM820

        #region int PROCESSOR_ARM920
        /// <summary>
        ///     ARM 920 processor.
        /// </summary>
        // #define PROCESSOR_ARM920 2336 // Windows CE - 0x920
        public const int PROCESSOR_ARM920 = 2336;
        #endregion int PROCESSOR_ARM920

        #region int PROCESSOR_ARM_7TDMI
        /// <summary>
        ///     ARM 7TDMI processor.
        /// </summary>
        // #define PROCESSOR_ARM_7TDMI 70001 // Windows CE
        public const int PROCESSOR_ARM_7TDMI = 70001;
        #endregion int PROCESSOR_ARM_7TDMI

        #region int PROCESSOR_OPTIL
        /// <summary>
        ///     MSIL processor.
        /// </summary>
        // #define PROCESSOR_OPTIL 0x494f // MSIL
        public const int PROCESSOR_OPTIL = 0x494f;
        #endregion int PROCESSOR_OPTIL

        #region short PROCESSOR_ARCHITECTURE_INTEL
        /// <summary>
        ///     Intel architecture.
        /// </summary>
        // #define PROCESSOR_ARCHITECTURE_INTEL 0
        public const short PROCESSOR_ARCHITECTURE_INTEL = 0;
        #endregion short PROCESSOR_ARCHITECTURE_INTEL

        #region short PROCESSOR_ARCHITECTURE_MIPS
        /// <summary>
        ///     MIPS architecture.
        /// </summary>
        // #define PROCESSOR_ARCHITECTURE_MIPS 1
        public const short PROCESSOR_ARCHITECTURE_MIPS = 1;
        #endregion short PROCESSOR_ARCHITECTURE_MIPS

        #region short PROCESSOR_ARCHITECTURE_ALPHA
        /// <summary>
        ///     Alpha architecture.
        /// </summary>
        // #define PROCESSOR_ARCHITECTURE_ALPHA 2
        public const short PROCESSOR_ARCHITECTURE_ALPHA = 2;
        #endregion short PROCESSOR_ARCHITECTURE_ALPHA

        #region short PROCESSOR_ARCHITECTURE_PPC
        /// <summary>
        ///     PPC architecture.
        /// </summary>
        // #define PROCESSOR_ARCHITECTURE_PPC 3
        public const short PROCESSOR_ARCHITECTURE_PPC = 3;
        #endregion short PROCESSOR_ARCHITECTURE_PPC

        #region short PROCESSOR_ARCHITECTURE_SHX
        /// <summary>
        ///     SHX architecture.
        /// </summary>
        // #define PROCESSOR_ARCHITECTURE_SHX 4
        public const short PROCESSOR_ARCHITECTURE_SHX = 4;
        #endregion short PROCESSOR_ARCHITECTURE_SHX

        #region short PROCESSOR_ARCHITECTURE_ARM
        /// <summary>
        ///     ARM architecture.
        /// </summary>
        // #define PROCESSOR_ARCHITECTURE_ARM 5
        public const short PROCESSOR_ARCHITECTURE_ARM = 5;
        #endregion short PROCESSOR_ARCHITECTURE_ARM

        #region short PROCESSOR_ARCHITECTURE_IA64
        /// <summary>
        ///     IA64 architecture.
        /// </summary>
        // #define PROCESSOR_ARCHITECTURE_IA64 6
        public const short PROCESSOR_ARCHITECTURE_IA64 = 6;
        #endregion short PROCESSOR_ARCHITECTURE_IA64

        #region short PROCESSOR_ARCHITECTURE_ALPHA64
        /// <summary>
        ///     Alpha64 architecture.
        /// </summary>
        // #define PROCESSOR_ARCHITECTURE_ALPHA64 7
        public const short PROCESSOR_ARCHITECTURE_ALPHA64 = 7;
        #endregion short PROCESSOR_ARCHITECTURE_ALPHA64

        #region short PROCESSOR_ARCHITECTURE_MSIL
        /// <summary>
        ///     MSIL architecture.
        /// </summary>
        // #define PROCESSOR_ARCHITECTURE_MSIL 8
        public const short PROCESSOR_ARCHITECTURE_MSIL = 8;
        #endregion short PROCESSOR_ARCHITECTURE_MSIL

        #region short PROCESSOR_ARCHITECTURE_AMD64
        /// <summary>
        ///     AMD64 architecture.
        /// </summary>
        // #define PROCESSOR_ARCHITECTURE_AMD64 9
        public const short PROCESSOR_ARCHITECTURE_AMD64 = 9;
        #endregion short PROCESSOR_ARCHITECTURE_AMD64

        #region short PROCESSOR_ARCHITECTURE_IA32_ON_WIN64
        /// <summary>
        ///     IA32 On Win64 architecture.
        /// </summary>
        // #define PROCESSOR_ARCHITECTURE_IA32_ON_WIN64 10
        public const short PROCESSOR_ARCHITECTURE_IA32_ON_WIN64 = 10;
        #endregion short PROCESSOR_ARCHITECTURE_IA32_ON_WIN64

        #region short PROCESSOR_ARCHITECTURE_UNKNOWN
        /// <summary>
        ///     Unknown architecture.
        /// </summary>
        // #define PROCESSOR_ARCHITECTURE_UNKNOWN 0xFFFF
        public const short PROCESSOR_ARCHITECTURE_UNKNOWN = unchecked((short) 0xFFFF);
        #endregion short PROCESSOR_ARCHITECTURE_UNKNOWN

        #region int PF_FLOATING_POINT_PRECISION_ERRATA
        /// <summary>
        ///     In rare circumstances, on a Pentium, a floating-point precision error can occur.
        /// </summary>
        // #define PF_FLOATING_POINT_PRECISION_ERRATA 0
        public const int PF_FLOATING_POINT_PRECISION_ERRATA = 0;
        #endregion int PF_FLOATING_POINT_PRECISION_ERRATA

        #region int PF_FLOATING_POINT_EMULATED
        /// <summary>
        ///     Floating-point operations are emulated using a software emulator.
        /// </summary>
        // #define PF_FLOATING_POINT_EMULATED 1
        public const int PF_FLOATING_POINT_EMULATED = 1;
        #endregion int PF_FLOATING_POINT_EMULATED

        #region int PF_COMPARE_EXCHANGE_DOUBLE
        /// <summary>
        ///     The compare and exchange double operation is available (Pentium, MIPS, and Alpha).
        /// </summary>
        // #define PF_COMPARE_EXCHANGE_DOUBLE 2
        public const int PF_COMPARE_EXCHANGE_DOUBLE = 2;
        #endregion int PF_COMPARE_EXCHANGE_DOUBLE

        #region int PF_MMX_INSTRUCTIONS_AVAILABLE
        /// <summary>
        ///     The MMX instruction set is available.
        /// </summary>
        // #define PF_MMX_INSTRUCTIONS_AVAILABLE 3
        public const int PF_MMX_INSTRUCTIONS_AVAILABLE = 3;
        #endregion int PF_MMX_INSTRUCTIONS_AVAILABLE

        #region int PF_PPC_MOVEMEM_64BIT_OK
        /// <summary>
        ///     Unknown.
        /// </summary>
        // #define PF_PPC_MOVEMEM_64BIT_OK 4
        public const int PF_PPC_MOVEMEM_64BIT_OK = 4;
        #endregion int PF_PPC_MOVEMEM_64BIT_OK

        #region int PF_ALPHA_BYTE_INSTRUCTIONS
        /// <summary>
        ///     Unknown.
        /// </summary>
        // #define PF_ALPHA_BYTE_INSTRUCTIONS 5
        public const int PF_ALPHA_BYTE_INSTRUCTIONS = 5;
        #endregion int PF_ALPHA_BYTE_INSTRUCTIONS

        #region int PF_XMMI_INSTRUCTIONS_AVAILABLE
        /// <summary>
        ///     The SSE instruction set is available.
        /// </summary>
        // #define PF_XMMI_INSTRUCTIONS_AVAILABLE 6
        public const int PF_XMMI_INSTRUCTIONS_AVAILABLE = 6;
        #endregion int PF_XMMI_INSTRUCTIONS_AVAILABLE

        #region int PF_3DNOW_INSTRUCTIONS_AVAILABLE
        /// <summary>
        ///     The 3D-Now instruction set is available.
        /// </summary>
        // #define PF_3DNOW_INSTRUCTIONS_AVAILABLE 7
        public const int PF_3DNOW_INSTRUCTIONS_AVAILABLE = 7;
        #endregion int PF_3DNOW_INSTRUCTIONS_AVAILABLE

        #region int PF_RDTSC_INSTRUCTION_AVAILABLE
        /// <summary>
        ///     The RDTSC instruction is available.
        /// </summary>
        // #define PF_RDTSC_INSTRUCTION_AVAILABLE 8
        public const int PF_RDTSC_INSTRUCTION_AVAILABLE = 8;
        #endregion int PF_RDTSC_INSTRUCTION_AVAILABLE

        #region int PF_PAE_ENABLED
        /// <summary>
        ///     The processor is PAE-enabled.
        /// </summary>
        // #define PF_PAE_ENABLED 9
        public const int PF_PAE_ENABLED = 9;
        #endregion int PF_PAE_ENABLED

        #region int PF_XMMI64_INSTRUCTIONS_AVAILABLE
        /// <summary>
        ///     The SSE2 instruction set is available.
        /// </summary>
        // #define PF_XMMI64_INSTRUCTIONS_AVAILABLE 10
        public const int PF_XMMI64_INSTRUCTIONS_AVAILABLE = 10;
        #endregion int PF_XMMI64_INSTRUCTIONS_AVAILABLE
        #endregion Public Constants
    }
}
