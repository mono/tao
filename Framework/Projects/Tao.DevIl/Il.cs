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

namespace Tao.DevIl {
    #region Class Documentation
    /// <summary>
    ///     Core DevIL library binding for .NET.
    /// </summary>
    #endregion Class Documentation
    public sealed class Il {
        // --- Fields ---
        #region Private Constants
        #region string IL_INTERNAL
        /// <summary>
        ///    Internal IL indicator.
        /// </summary>
        private const string IL_INTERNAL = @"8/FlDH+Biq+s7nti7WlgnPL8mt7lGrv/HWaEc8JmsHdDoHeMpCWuXiMVtGfGd/ph1WjIcO5LweTT5qowuFaL5ETuh410IvLPVqOway5nyqY2IoX7JYak5bgT55fSg8oHav86BxPi/gnbOxzKSv0JsXYDIt9mTvWRFJ1aR+8b7IM=";
        #endregion string IL_INTERNAL

        #region string IL_NATIVE_LIBRARY
        /// <summary>
        ///     Specifies DevIl's native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies devil.dll for Windows and libIL.so for Linux.
        /// </remarks>
        #if WIN32
        private const string IL_NATIVE_LIBRARY = "devil.dll";
        #elif LINUX
        private const string IL_NATIVE_LIBRARY = "libIL.so";
        #endif
        #endregion string IL_NATIVE_LIBRARY

        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.StdCall" /> for Windows and
        ///     <see cref="CallingConvention.Cdecl" /> for Linux.
        /// </remarks>
        #if WIN32
        private const CallingConvention CALLING_CONVENTION = CallingConvention.StdCall;
        #elif LINUX
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;
        #endif
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants

        #region Public Constants
        #region  Core constants
        #region IL_FALSE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FALSE = 0
        public const int IL_FALSE = 0;
        #endregion IL_FALSE

        #region IL_TRUE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TRUE = 1
        public const int IL_TRUE = 1;
        #endregion IL_TRUE

        #region IL_COLOUR_INDEX
        /// <summary>
        /// 
        /// </summary>
        // #define IL_COLOUR_INDEX = 0x1900
        public const int IL_COLOUR_INDEX = 0x1900;
        #endregion IL_COLOUR_INDEX

        #region IL_COLOR_INDEX
        /// <summary>
        /// 
        /// </summary>
        // #define IL_COLOR_INDEX = 0x1900
        public const int IL_COLOR_INDEX = 0x1900;
        #endregion IL_COLOR_INDEX

        #region IL_RGB
        /// <summary>
        /// 
        /// </summary>
        // #define IL_RGB = 0x1907
        public const int IL_RGB = 0x1907;
        #endregion IL_RGB

        #region IL_RGBA
        /// <summary>
        /// 
        /// </summary>
        // #define IL_RGBA = 0x1908
        public const int IL_RGBA = 0x1908;
        #endregion IL_RGBA

        #region IL_BGR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_BGR = 0x80E0
        public const int IL_BGR = 0x80E0;
        #endregion IL_BGR

        #region IL_BGRA
        /// <summary>
        /// 
        /// </summary>
        // #define IL_BGRA = 0x80E1
        public const int IL_BGRA = 0x80E1;
        #endregion IL_BGRA

        #region IL_LUMINANCE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_LUMINANCE = 0x1909
        public const int IL_LUMINANCE = 0x1909;
        #endregion IL_LUMINANCE

        #region IL_LUMINANCE_ALPHA
        /// <summary>
        /// 
        /// </summary>
        // #define IL_LUMINANCE_ALPHA = 0x190A
        public const int IL_LUMINANCE_ALPHA = 0x190A;
        #endregion IL_LUMINANCE_ALPHA

        #region IL_BYTE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_BYTE = 0x1400
        public const int IL_BYTE = 0x1400;
        #endregion IL_BYTE

        #region IL_UNSIGNED_BYTE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_UNSIGNED_BYTE = 0x1401
        public const int IL_UNSIGNED_BYTE = 0x1401;
        #endregion IL_UNSIGNED_BYTE

        #region IL_SHORT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_SHORT = 0x1402
        public const int IL_SHORT = 0x1402;
        #endregion IL_SHORT

        #region IL_UNSIGNED_SHORT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_UNSIGNED_SHORT = 0x1403
        public const int IL_UNSIGNED_SHORT = 0x1403;
        #endregion IL_UNSIGNED_SHORT

        #region IL_INT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_INT = 0x1404
        public const int IL_INT = 0x1404;
        #endregion IL_INT

        #region IL_UNSIGNED_INT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_UNSIGNED_INT = 0x1405
        public const int IL_UNSIGNED_INT = 0x1405;
        #endregion IL_UNSIGNED_INT

        #region IL_FLOAT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FLOAT = 0x1406
        public const int IL_FLOAT = 0x1406;
        #endregion IL_FLOAT

        #region IL_DOUBLE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DOUBLE = 0x140A
        public const int IL_DOUBLE = 0x140A;
        #endregion IL_DOUBLE

        #region IL_VENDOR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_VENDOR = 0x1F00
        public const int IL_VENDOR = 0x1F00;
        #endregion IL_VENDOR

        #region IL_LOAD_EXT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_LOAD_EXT = 0x1F01
        public const int IL_LOAD_EXT = 0x1F01;
        #endregion IL_LOAD_EXT

        #region IL_SAVE_EXT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_SAVE_EXT = 0x1F02
        public const int IL_SAVE_EXT = 0x1F02;
        #endregion IL_SAVE_EXT
        #endregion  Core constants

        #region  IL-specific #define's
        #region IL_VERSION_1_6_1
        /// <summary>
        /// 
        /// </summary>
        // #define IL_VERSION_1_6_1 = 1
        public const int IL_VERSION_1_6_1 = 1;
        #endregion IL_VERSION_1_6_1

        #region IL_VERSION
        /// <summary>
        /// 
        /// </summary>
        // #define IL_VERSION = 161
        public const int IL_VERSION = 161;
        #endregion IL_VERSION
        #endregion  IL-specific #define's

        #region  Attribute Bits
        #region IL_ORIGIN_BIT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_ORIGIN_BIT = 0x00000001
        public const int IL_ORIGIN_BIT = 0x00000001;
        #endregion IL_ORIGIN_BIT

        #region IL_FILE_BIT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FILE_BIT = 0x00000002
        public const int IL_FILE_BIT = 0x00000002;
        #endregion IL_FILE_BIT

        #region IL_PAL_BIT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PAL_BIT = 0x00000004
        public const int IL_PAL_BIT = 0x00000004;
        #endregion IL_PAL_BIT

        #region IL_FORMAT_BIT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FORMAT_BIT = 0x00000008
        public const int IL_FORMAT_BIT = 0x00000008;
        #endregion IL_FORMAT_BIT

        #region IL_TYPE_BIT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TYPE_BIT = 0x00000010
        public const int IL_TYPE_BIT = 0x00000010;
        #endregion IL_TYPE_BIT

        #region IL_COMPRESS_BIT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_COMPRESS_BIT = 0x00000020
        public const int IL_COMPRESS_BIT = 0x00000020;
        #endregion IL_COMPRESS_BIT

        #region IL_LOADFAIL_BIT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_LOADFAIL_BIT = 0x00000040
        public const int IL_LOADFAIL_BIT = 0x00000040;
        #endregion IL_LOADFAIL_BIT

        #region IL_FORMAT_SPECIFIC_BIT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FORMAT_SPECIFIC_BIT = 0x00000080
        public const int IL_FORMAT_SPECIFIC_BIT = 0x00000080;
        #endregion IL_FORMAT_SPECIFIC_BIT

        #region IL_ALL_ATTRIB_BITS
        /// <summary>
        /// 
        /// </summary>
        // #define IL_ALL_ATTRIB_BITS = 0x000FFFFF
        public const int IL_ALL_ATTRIB_BITS = 0x000FFFFF;
        #endregion IL_ALL_ATTRIB_BITS
        #endregion  Attribute Bits

        #region  Palette types
        #region IL_PAL_NONE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PAL_NONE = 0x0400
        public const int IL_PAL_NONE = 0x0400;
        #endregion IL_PAL_NONE

        #region IL_PAL_RGB24
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PAL_RGB24 = 0x0401
        public const int IL_PAL_RGB24 = 0x0401;
        #endregion IL_PAL_RGB24

        #region IL_PAL_RGB32
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PAL_RGB32 = 0x0402
        public const int IL_PAL_RGB32 = 0x0402;
        #endregion IL_PAL_RGB32

        #region IL_PAL_RGBA32
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PAL_RGBA32 = 0x0403
        public const int IL_PAL_RGBA32 = 0x0403;
        #endregion IL_PAL_RGBA32

        #region IL_PAL_BGR24
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PAL_BGR24 = 0x0404
        public const int IL_PAL_BGR24 = 0x0404;
        #endregion IL_PAL_BGR24

        #region IL_PAL_BGR32
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PAL_BGR32 = 0x0405
        public const int IL_PAL_BGR32 = 0x0405;
        #endregion IL_PAL_BGR32

        #region IL_PAL_BGRA32
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PAL_BGRA32 = 0x0406
        public const int IL_PAL_BGRA32 = 0x0406;
        #endregion IL_PAL_BGRA32
        #endregion  Palette types

        #region  Image types
        #region IL_TYPE_UNKNOWN
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TYPE_UNKNOWN = 0x0000
        public const int IL_TYPE_UNKNOWN = 0x0000;
        #endregion IL_TYPE_UNKNOWN

        #region IL_BMP
        /// <summary>
        /// 
        /// </summary>
        // #define IL_BMP = 0x0420
        public const int IL_BMP = 0x0420;
        #endregion IL_BMP

        #region IL_CUT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_CUT = 0x0421
        public const int IL_CUT = 0x0421;
        #endregion IL_CUT

        #region IL_DOOM
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DOOM = 0x0422
        public const int IL_DOOM = 0x0422;
        #endregion IL_DOOM

        #region IL_DOOM_FLAT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DOOM_FLAT = 0x0423
        public const int IL_DOOM_FLAT = 0x0423;
        #endregion IL_DOOM_FLAT

        #region IL_ICO
        /// <summary>
        /// 
        /// </summary>
        // #define IL_ICO = 0x0424
        public const int IL_ICO = 0x0424;
        #endregion IL_ICO

        #region IL_JPG
        /// <summary>
        /// 
        /// </summary>
        // #define IL_JPG = 0x0425
        public const int IL_JPG = 0x0425;
        #endregion IL_JPG

        #region IL_JFIF
        /// <summary>
        /// 
        /// </summary>
        // #define IL_JFIF = 0x0425
        public const int IL_JFIF = 0x0425;
        #endregion IL_JFIF

        #region IL_LBM
        /// <summary>
        /// 
        /// </summary>
        // #define IL_LBM = 0x0426
        public const int IL_LBM = 0x0426;
        #endregion IL_LBM

        #region IL_PCD
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PCD = 0x0427
        public const int IL_PCD = 0x0427;
        #endregion IL_PCD

        #region IL_PCX
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PCX = 0x0428
        public const int IL_PCX = 0x0428;
        #endregion IL_PCX

        #region IL_PIC
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PIC = 0x0429
        public const int IL_PIC = 0x0429;
        #endregion IL_PIC

        #region IL_PNG
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PNG = 0x042A
        public const int IL_PNG = 0x042A;
        #endregion IL_PNG

        #region IL_PNM
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PNM = 0x042B
        public const int IL_PNM = 0x042B;
        #endregion IL_PNM

        #region IL_SGI
        /// <summary>
        /// 
        /// </summary>
        // #define IL_SGI = 0x042C
        public const int IL_SGI = 0x042C;
        #endregion IL_SGI

        #region IL_TGA
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TGA = 0x042D
        public const int IL_TGA = 0x042D;
        #endregion IL_TGA

        #region IL_TIF
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TIF = 0x042E
        public const int IL_TIF = 0x042E;
        #endregion IL_TIF

        #region IL_CHEAD
        /// <summary>
        /// 
        /// </summary>
        // #define IL_CHEAD = 0x042F
        public const int IL_CHEAD = 0x042F;
        #endregion IL_CHEAD

        #region IL_RAW
        /// <summary>
        /// 
        /// </summary>
        // #define IL_RAW = 0x0430
        public const int IL_RAW = 0x0430;
        #endregion IL_RAW

        #region IL_MDL
        /// <summary>
        /// 
        /// </summary>
        // #define IL_MDL = 0x0431
        public const int IL_MDL = 0x0431;
        #endregion IL_MDL

        #region IL_WAL
        /// <summary>
        /// 
        /// </summary>
        // #define IL_WAL = 0x0432
        public const int IL_WAL = 0x0432;
        #endregion IL_WAL

        #region IL_LIF
        /// <summary>
        /// 
        /// </summary>
        // #define IL_LIF = 0x0434
        public const int IL_LIF = 0x0434;
        #endregion IL_LIF

        #region IL_MNG
        /// <summary>
        /// 
        /// </summary>
        // #define IL_MNG = 0x0435
        public const int IL_MNG = 0x0435;
        #endregion IL_MNG

        #region IL_JNG
        /// <summary>
        /// 
        /// </summary>
        // #define IL_JNG = 0x0435
        public const int IL_JNG = 0x0435;
        #endregion IL_JNG

        #region IL_GIF
        /// <summary>
        /// 
        /// </summary>
        // #define IL_GIF = 0x0436
        public const int IL_GIF = 0x0436;
        #endregion IL_GIF

        #region IL_DDS
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DDS = 0x0437
        public const int IL_DDS = 0x0437;
        #endregion IL_DDS

        #region IL_DCX
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DCX = 0x0438
        public const int IL_DCX = 0x0438;
        #endregion IL_DCX

        #region IL_PSD
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PSD = 0x0439
        public const int IL_PSD = 0x0439;
        #endregion IL_PSD

        #region IL_EXIF
        /// <summary>
        /// 
        /// </summary>
        // #define IL_EXIF = 0x043A
        public const int IL_EXIF = 0x043A;
        #endregion IL_EXIF

        #region IL_PSP
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PSP = 0x043B
        public const int IL_PSP = 0x043B;
        #endregion IL_PSP

        #region IL_PIX
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PIX = 0x043C
        public const int IL_PIX = 0x043C;
        #endregion IL_PIX

        #region IL_PXR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PXR = 0x043D
        public const int IL_PXR = 0x043D;
        #endregion IL_PXR

        #region IL_XPM
        /// <summary>
        /// 
        /// </summary>
        // #define IL_XPM = 0x043E
        public const int IL_XPM = 0x043E;
        #endregion IL_XPM

        #region IL_JASC_PAL
        /// <summary>
        /// 
        /// </summary>
        // #define IL_JASC_PAL = 0x0475
        public const int IL_JASC_PAL = 0x0475;
        #endregion IL_JASC_PAL
        #endregion  Image types

        #region  Error Types
        #region IL_NO_ERROR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_NO_ERROR = 0x0000
        public const int IL_NO_ERROR = 0x0000;
        #endregion IL_NO_ERROR

        #region IL_INVALID_ENUM
        /// <summary>
        /// 
        /// </summary>
        // #define IL_INVALID_ENUM = 0x0501
        public const int IL_INVALID_ENUM = 0x0501;
        #endregion IL_INVALID_ENUM

        #region IL_OUT_OF_MEMORY
        /// <summary>
        /// 
        /// </summary>
        // #define IL_OUT_OF_MEMORY = 0x0502
        public const int IL_OUT_OF_MEMORY = 0x0502;
        #endregion IL_OUT_OF_MEMORY

        #region IL_FORMAT_NOT_SUPPORTED
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FORMAT_NOT_SUPPORTED = 0x0503
        public const int IL_FORMAT_NOT_SUPPORTED = 0x0503;
        #endregion IL_FORMAT_NOT_SUPPORTED

        #region IL_INTERNAL_ERROR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_INTERNAL_ERROR = 0x0504
        public const int IL_INTERNAL_ERROR = 0x0504;
        #endregion IL_INTERNAL_ERROR

        #region IL_INVALID_VALUE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_INVALID_VALUE = 0x0505
        public const int IL_INVALID_VALUE = 0x0505;
        #endregion IL_INVALID_VALUE

        #region IL_ILLEGAL_OPERATION
        /// <summary>
        /// 
        /// </summary>
        // #define IL_ILLEGAL_OPERATION = 0x0506
        public const int IL_ILLEGAL_OPERATION = 0x0506;
        #endregion IL_ILLEGAL_OPERATION

        #region IL_ILLEGAL_FILE_VALUE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_ILLEGAL_FILE_VALUE = 0x0507
        public const int IL_ILLEGAL_FILE_VALUE = 0x0507;
        #endregion IL_ILLEGAL_FILE_VALUE

        #region IL_INVALID_FILE_HEADER
        /// <summary>
        /// 
        /// </summary>
        // #define IL_INVALID_FILE_HEADER = 0x0508
        public const int IL_INVALID_FILE_HEADER = 0x0508;
        #endregion IL_INVALID_FILE_HEADER

        #region IL_INVALID_PARAM
        /// <summary>
        /// 
        /// </summary>
        // #define IL_INVALID_PARAM = 0x0509
        public const int IL_INVALID_PARAM = 0x0509;
        #endregion IL_INVALID_PARAM

        #region IL_COULD_NOT_OPEN_FILE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_COULD_NOT_OPEN_FILE = 0x050A
        public const int IL_COULD_NOT_OPEN_FILE = 0x050A;
        #endregion IL_COULD_NOT_OPEN_FILE

        #region IL_INVALID_EXTENSION
        /// <summary>
        /// 
        /// </summary>
        // #define IL_INVALID_EXTENSION = 0x050B
        public const int IL_INVALID_EXTENSION = 0x050B;
        #endregion IL_INVALID_EXTENSION

        #region IL_FILE_ALREADY_EXISTS
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FILE_ALREADY_EXISTS = 0x050C
        public const int IL_FILE_ALREADY_EXISTS = 0x050C;
        #endregion IL_FILE_ALREADY_EXISTS

        #region IL_OUT_FORMAT_SAME
        /// <summary>
        /// 
        /// </summary>
        // #define IL_OUT_FORMAT_SAME = 0x050D
        public const int IL_OUT_FORMAT_SAME = 0x050D;
        #endregion IL_OUT_FORMAT_SAME

        #region IL_STACK_OVERFLOW
        /// <summary>
        /// 
        /// </summary>
        // #define IL_STACK_OVERFLOW = 0x050E
        public const int IL_STACK_OVERFLOW = 0x050E;
        #endregion IL_STACK_OVERFLOW

        #region IL_STACK_UNDERFLOW
        /// <summary>
        /// 
        /// </summary>
        // #define IL_STACK_UNDERFLOW = 0x050F
        public const int IL_STACK_UNDERFLOW = 0x050F;
        #endregion IL_STACK_UNDERFLOW

        #region IL_INVALID_CONVERSION
        /// <summary>
        /// 
        /// </summary>
        // #define IL_INVALID_CONVERSION = 0x0510
        public const int IL_INVALID_CONVERSION = 0x0510;
        #endregion IL_INVALID_CONVERSION

        #region IL_BAD_DIMENSIONS
        /// <summary>
        /// 
        /// </summary>
        // #define IL_BAD_DIMENSIONS = 0x0511
        public const int IL_BAD_DIMENSIONS = 0x0511;
        #endregion IL_BAD_DIMENSIONS

        #region IL_FILE_READ_ERROR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FILE_READ_ERROR = 0x0512
        public const int IL_FILE_READ_ERROR = 0x0512;
        #endregion IL_FILE_READ_ERROR

        #region IL_FILE_WRITE_ERROR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FILE_WRITE_ERROR = 0x0512
        public const int IL_FILE_WRITE_ERROR = 0x0512;
        #endregion IL_FILE_WRITE_ERROR

        #region IL_LIB_GIF_ERROR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_LIB_GIF_ERROR = 0x05E1
        public const int IL_LIB_GIF_ERROR = 0x05E1;
        #endregion IL_LIB_GIF_ERROR

        #region IL_LIB_JPEG_ERROR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_LIB_JPEG_ERROR = 0x05E2
        public const int IL_LIB_JPEG_ERROR = 0x05E2;
        #endregion IL_LIB_JPEG_ERROR

        #region IL_LIB_PNG_ERROR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_LIB_PNG_ERROR = 0x05E3
        public const int IL_LIB_PNG_ERROR = 0x05E3;
        #endregion IL_LIB_PNG_ERROR

        #region IL_LIB_TIFF_ERROR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_LIB_TIFF_ERROR = 0x05E4
        public const int IL_LIB_TIFF_ERROR = 0x05E4;
        #endregion IL_LIB_TIFF_ERROR

        #region IL_LIB_MNG_ERROR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_LIB_MNG_ERROR = 0x05E5
        public const int IL_LIB_MNG_ERROR = 0x05E5;
        #endregion IL_LIB_MNG_ERROR

        #region IL_UNKNOWN_ERROR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_UNKNOWN_ERROR = 0x05FF
        public const int IL_UNKNOWN_ERROR = 0x05FF;
        #endregion IL_UNKNOWN_ERROR
        #endregion  Error Types

        #region  Origin Definitions
        #region IL_ORIGIN_SET
        /// <summary>
        /// 
        /// </summary>
        // #define IL_ORIGIN_SET = 0x0600
        public const int IL_ORIGIN_SET = 0x0600;
        #endregion IL_ORIGIN_SET

        #region IL_ORIGIN_LOWER_LEFT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_ORIGIN_LOWER_LEFT = 0x0601
        public const int IL_ORIGIN_LOWER_LEFT = 0x0601;
        #endregion IL_ORIGIN_LOWER_LEFT

        #region IL_ORIGIN_UPPER_LEFT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_ORIGIN_UPPER_LEFT = 0x0602
        public const int IL_ORIGIN_UPPER_LEFT = 0x0602;
        #endregion IL_ORIGIN_UPPER_LEFT

        #region IL_ORIGIN_MODE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_ORIGIN_MODE = 0x0603
        public const int IL_ORIGIN_MODE = 0x0603;
        #endregion IL_ORIGIN_MODE
        #endregion  Origin Definitions

        #region  Format and Type Mode Definitions
        #region IL_FORMAT_SET
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FORMAT_SET = 0x0610
        public const int IL_FORMAT_SET = 0x0610;
        #endregion IL_FORMAT_SET

        #region IL_FORMAT_MODE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FORMAT_MODE = 0x0611
        public const int IL_FORMAT_MODE = 0x0611;
        #endregion IL_FORMAT_MODE

        #region IL_TYPE_SET
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TYPE_SET = 0x0612
        public const int IL_TYPE_SET = 0x0612;
        #endregion IL_TYPE_SET

        #region IL_TYPE_MODE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TYPE_MODE = 0x0613
        public const int IL_TYPE_MODE = 0x0613;
        #endregion IL_TYPE_MODE
        #endregion  Format and Type Mode Definitions

        #region  File definitions
        #region IL_FILE_OVERWRITE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FILE_OVERWRITE = 0x0620
        public const int IL_FILE_OVERWRITE = 0x0620;
        #endregion IL_FILE_OVERWRITE

        #region IL_FILE_MODE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FILE_MODE = 0x0621
        public const int IL_FILE_MODE = 0x0621;
        #endregion IL_FILE_MODE
        #endregion  File definitions

        #region  Palette definitions
        #region IL_CONV_PAL
        /// <summary>
        /// 
        /// </summary>
        // #define IL_CONV_PAL = 0x0630
        public const int IL_CONV_PAL = 0x0630;
        #endregion IL_CONV_PAL
        #endregion  Palette definitions

        #region  Load fail definitions
        #region IL_DEFAULT_ON_FAIL
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DEFAULT_ON_FAIL = 0x0632
        public const int IL_DEFAULT_ON_FAIL = 0x0632;
        #endregion IL_DEFAULT_ON_FAIL
        #endregion  Load fail definitions

        #region  Key colour definitions
        #region IL_USE_KEY_COLOUR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_USE_KEY_COLOUR = 0x0635
        public const int IL_USE_KEY_COLOUR = 0x0635;
        #endregion IL_USE_KEY_COLOUR

        #region IL_USE_KEY_COLOR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_USE_KEY_COLOR = 0x0635
        public const int IL_USE_KEY_COLOR = 0x0635;
        #endregion IL_USE_KEY_COLOR
        #endregion  Key colour definitions

        #region  Interlace definitions
        #region IL_SAVE_INTERLACED
        /// <summary>
        /// 
        /// </summary>
        // #define IL_SAVE_INTERLACED = 0x0639
        public const int IL_SAVE_INTERLACED = 0x0639;
        #endregion IL_SAVE_INTERLACED

        #region IL_INTERLACE_MODE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_INTERLACE_MODE = 0x063A
        public const int IL_INTERLACE_MODE = 0x063A;
        #endregion IL_INTERLACE_MODE
        #endregion  Interlace definitions

        #region  Quantization definitions
        #region IL_QUANTIZATION_MODE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_QUANTIZATION_MODE = 0x0640
        public const int IL_QUANTIZATION_MODE = 0x0640;
        #endregion IL_QUANTIZATION_MODE

        #region IL_WU_QUANT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_WU_QUANT = 0x0641
        public const int IL_WU_QUANT = 0x0641;
        #endregion IL_WU_QUANT

        #region IL_NEU_QUANT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_NEU_QUANT = 0x0642
        public const int IL_NEU_QUANT = 0x0642;
        #endregion IL_NEU_QUANT

        #region IL_NEU_QUANT_SAMPLE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_NEU_QUANT_SAMPLE = 0x0643
        public const int IL_NEU_QUANT_SAMPLE = 0x0643;
        #endregion IL_NEU_QUANT_SAMPLE
        #endregion  Quantization definitions

        #region  Hints
        #region IL_FASTEST
        /// <summary>
        /// 
        /// </summary>
        // #define IL_FASTEST = 0x0660
        public const int IL_FASTEST = 0x0660;
        #endregion IL_FASTEST

        #region IL_LESS_MEM
        /// <summary>
        /// 
        /// </summary>
        // #define IL_LESS_MEM = 0x0661
        public const int IL_LESS_MEM = 0x0661;
        #endregion IL_LESS_MEM

        #region IL_DONT_CARE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DONT_CARE = 0x0662
        public const int IL_DONT_CARE = 0x0662;
        #endregion IL_DONT_CARE

        #region IL_MEM_SPEED_HINT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_MEM_SPEED_HINT = 0x0665
        public const int IL_MEM_SPEED_HINT = 0x0665;
        #endregion IL_MEM_SPEED_HINT

        #region IL_USE_COMPRESSION
        /// <summary>
        /// 
        /// </summary>
        // #define IL_USE_COMPRESSION = 0x0666
        public const int IL_USE_COMPRESSION = 0x0666;
        #endregion IL_USE_COMPRESSION

        #region IL_NO_COMPRESSION
        /// <summary>
        /// 
        /// </summary>
        // #define IL_NO_COMPRESSION = 0x0667
        public const int IL_NO_COMPRESSION = 0x0667;
        #endregion IL_NO_COMPRESSION

        #region IL_COMPRESSION_HINT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_COMPRESSION_HINT = 0x0668
        public const int IL_COMPRESSION_HINT = 0x0668;
        #endregion IL_COMPRESSION_HINT
        #endregion  Hints

        #region  Subimage types
        #region IL_SUB_NEXT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_SUB_NEXT = 0x0680
        public const int IL_SUB_NEXT = 0x0680;
        #endregion IL_SUB_NEXT

        #region IL_SUB_MIPMAP
        /// <summary>
        /// 
        /// </summary>
        // #define IL_SUB_MIPMAP = 0x0681
        public const int IL_SUB_MIPMAP = 0x0681;
        #endregion IL_SUB_MIPMAP

        #region IL_SUB_LAYER
        /// <summary>
        /// 
        /// </summary>
        // #define IL_SUB_LAYER = 0x0682
        public const int IL_SUB_LAYER = 0x0682;
        #endregion IL_SUB_LAYER
        #endregion  Subimage types

        #region  Compression definitions
        #region IL_COMPRESS_MODE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_COMPRESS_MODE = 0x0700
        public const int IL_COMPRESS_MODE = 0x0700;
        #endregion IL_COMPRESS_MODE

        #region IL_COMPRESS_NONE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_COMPRESS_NONE = 0x0701
        public const int IL_COMPRESS_NONE = 0x0701;
        #endregion IL_COMPRESS_NONE

        #region IL_COMPRESS_RLE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_COMPRESS_RLE = 0x0702
        public const int IL_COMPRESS_RLE = 0x0702;
        #endregion IL_COMPRESS_RLE

        #region IL_COMPRESS_LZO
        /// <summary>
        /// 
        /// </summary>
        // #define IL_COMPRESS_LZO = 0x0703
        public const int IL_COMPRESS_LZO = 0x0703;
        #endregion IL_COMPRESS_LZO

        #region IL_COMPRESS_ZLIB
        /// <summary>
        /// 
        /// </summary>
        // #define IL_COMPRESS_ZLIB = 0x0704
        public const int IL_COMPRESS_ZLIB = 0x0704;
        #endregion IL_COMPRESS_ZLIB
        #endregion  Compression definitions

        #region  File format-specific values
        #region IL_TGA_CREATE_STAMP
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TGA_CREATE_STAMP = 0x0710
        public const int IL_TGA_CREATE_STAMP = 0x0710;
        #endregion IL_TGA_CREATE_STAMP

        #region IL_JPG_QUALITY
        /// <summary>
        /// 
        /// </summary>
        // #define IL_JPG_QUALITY = 0x0711
        public const int IL_JPG_QUALITY = 0x0711;
        #endregion IL_JPG_QUALITY

        #region IL_PNG_INTERLACE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PNG_INTERLACE = 0x0712
        public const int IL_PNG_INTERLACE = 0x0712;
        #endregion IL_PNG_INTERLACE

        #region IL_TGA_RLE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TGA_RLE = 0x0713
        public const int IL_TGA_RLE = 0x0713;
        #endregion IL_TGA_RLE

        #region IL_BMP_RLE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_BMP_RLE = 0x0714
        public const int IL_BMP_RLE = 0x0714;
        #endregion IL_BMP_RLE

        #region IL_SGI_RLE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_SGI_RLE = 0x0715
        public const int IL_SGI_RLE = 0x0715;
        #endregion IL_SGI_RLE

        #region IL_TGA_ID_STRING
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TGA_ID_STRING = 0x0717
        public const int IL_TGA_ID_STRING = 0x0717;
        #endregion IL_TGA_ID_STRING

        #region IL_TGA_AUTHNAME_STRING
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TGA_AUTHNAME_STRING = 0x0718
        public const int IL_TGA_AUTHNAME_STRING = 0x0718;
        #endregion IL_TGA_AUTHNAME_STRING

        #region IL_TGA_AUTHCOMMENT_STRING
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TGA_AUTHCOMMENT_STRING = 0x0719
        public const int IL_TGA_AUTHCOMMENT_STRING = 0x0719;
        #endregion IL_TGA_AUTHCOMMENT_STRING

        #region IL_PNG_AUTHNAME_STRING
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PNG_AUTHNAME_STRING = 0x071A
        public const int IL_PNG_AUTHNAME_STRING = 0x071A;
        #endregion IL_PNG_AUTHNAME_STRING

        #region IL_PNG_TITLE_STRING
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PNG_TITLE_STRING = 0x071B
        public const int IL_PNG_TITLE_STRING = 0x071B;
        #endregion IL_PNG_TITLE_STRING

        #region IL_PNG_DESCRIPTION_STRING
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PNG_DESCRIPTION_STRING = 0x071C
        public const int IL_PNG_DESCRIPTION_STRING = 0x071C;
        #endregion IL_PNG_DESCRIPTION_STRING

        #region IL_TIF_DESCRIPTION_STRING
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TIF_DESCRIPTION_STRING = 0x071D
        public const int IL_TIF_DESCRIPTION_STRING = 0x071D;
        #endregion IL_TIF_DESCRIPTION_STRING

        #region IL_TIF_HOSTCOMPUTER_STRING
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TIF_HOSTCOMPUTER_STRING = 0x071E
        public const int IL_TIF_HOSTCOMPUTER_STRING = 0x071E;
        #endregion IL_TIF_HOSTCOMPUTER_STRING

        #region IL_TIF_DOCUMENTNAME_STRING
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TIF_DOCUMENTNAME_STRING = 0x071F
        public const int IL_TIF_DOCUMENTNAME_STRING = 0x071F;
        #endregion IL_TIF_DOCUMENTNAME_STRING

        #region IL_TIF_AUTHNAME_STRING
        /// <summary>
        /// 
        /// </summary>
        // #define IL_TIF_AUTHNAME_STRING = 0x0720
        public const int IL_TIF_AUTHNAME_STRING = 0x0720;
        #endregion IL_TIF_AUTHNAME_STRING

        #region IL_JPG_SAVE_FORMAT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_JPG_SAVE_FORMAT = 0x0721
        public const int IL_JPG_SAVE_FORMAT = 0x0721;
        #endregion IL_JPG_SAVE_FORMAT

        #region IL_CHEAD_HEADER_STRING
        /// <summary>
        /// 
        /// </summary>
        // #define IL_CHEAD_HEADER_STRING = 0x0722
        public const int IL_CHEAD_HEADER_STRING = 0x0722;
        #endregion IL_CHEAD_HEADER_STRING

        #region IL_PCD_PICNUM
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PCD_PICNUM = 0x0723
        public const int IL_PCD_PICNUM = 0x0723;
        #endregion IL_PCD_PICNUM
        #endregion  File format-specific values

        #region  DXTC definitions
        #region IL_DXTC_FORMAT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DXTC_FORMAT = 0x0705
        public const int IL_DXTC_FORMAT = 0x0705;
        #endregion IL_DXTC_FORMAT

        #region IL_DXT1
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DXT1 = 0x0706
        public const int IL_DXT1 = 0x0706;
        #endregion IL_DXT1

        #region IL_DXT2
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DXT2 = 0x0707
        public const int IL_DXT2 = 0x0707;
        #endregion IL_DXT2

        #region IL_DXT3
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DXT3 = 0x0708
        public const int IL_DXT3 = 0x0708;
        #endregion IL_DXT3

        #region IL_DXT4
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DXT4 = 0x0709
        public const int IL_DXT4 = 0x0709;
        #endregion IL_DXT4

        #region IL_DXT5
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DXT5 = 0x070A
        public const int IL_DXT5 = 0x070A;
        #endregion IL_DXT5

        #region IL_DXT_NO_COMP
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DXT_NO_COMP = 0x070B
        public const int IL_DXT_NO_COMP = 0x070B;
        #endregion IL_DXT_NO_COMP

        #region IL_KEEP_DXTC_DATA
        /// <summary>
        /// 
        /// </summary>
        // #define IL_KEEP_DXTC_DATA = 0x070C
        public const int IL_KEEP_DXTC_DATA = 0x070C;
        #endregion IL_KEEP_DXTC_DATA

        #region IL_DXTC_DATA_FORMAT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_DXTC_DATA_FORMAT = 0x070D
        public const int IL_DXTC_DATA_FORMAT = 0x070D;
        #endregion IL_DXTC_DATA_FORMAT
        #endregion  DXTC definitions

        #region  Cube map definitions
        #region IL_CUBEMAP_POSITIVEX
        /// <summary>
        /// 
        /// </summary>
        // #define IL_CUBEMAP_POSITIVEX = 0x00000400
        public const int IL_CUBEMAP_POSITIVEX = 0x00000400;
        #endregion IL_CUBEMAP_POSITIVEX

        #region IL_CUBEMAP_NEGATIVEX
        /// <summary>
        /// 
        /// </summary>
        // #define IL_CUBEMAP_NEGATIVEX = 0x00000800
        public const int IL_CUBEMAP_NEGATIVEX = 0x00000800;
        #endregion IL_CUBEMAP_NEGATIVEX

        #region IL_CUBEMAP_POSITIVEY
        /// <summary>
        /// 
        /// </summary>
        // #define IL_CUBEMAP_POSITIVEY = 0x00001000
        public const int IL_CUBEMAP_POSITIVEY = 0x00001000;
        #endregion IL_CUBEMAP_POSITIVEY

        #region IL_CUBEMAP_NEGATIVEY
        /// <summary>
        /// 
        /// </summary>
        // #define IL_CUBEMAP_NEGATIVEY = 0x00002000
        public const int IL_CUBEMAP_NEGATIVEY = 0x00002000;
        #endregion IL_CUBEMAP_NEGATIVEY

        #region IL_CUBEMAP_POSITIVEZ
        /// <summary>
        /// 
        /// </summary>
        // #define IL_CUBEMAP_POSITIVEZ = 0x00004000
        public const int IL_CUBEMAP_POSITIVEZ = 0x00004000;
        #endregion IL_CUBEMAP_POSITIVEZ

        #region IL_CUBEMAP_NEGATIVEZ
        /// <summary>
        /// 
        /// </summary>
        // #define IL_CUBEMAP_NEGATIVEZ = 0x00008000
        public const int IL_CUBEMAP_NEGATIVEZ = 0x00008000;
        #endregion IL_CUBEMAP_NEGATIVEZ
        #endregion  Cube map definitions

        #region  Values
        #region IL_VERSION_NUM
        /// <summary>
        /// 
        /// </summary>
        // #define IL_VERSION_NUM = 0x0DE2
        public const int IL_VERSION_NUM = 0x0DE2;
        #endregion IL_VERSION_NUM

        #region IL_IMAGE_WIDTH
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_WIDTH = 0x0DE4
        public const int IL_IMAGE_WIDTH = 0x0DE4;
        #endregion IL_IMAGE_WIDTH

        #region IL_IMAGE_HEIGHT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_HEIGHT = 0x0DE5
        public const int IL_IMAGE_HEIGHT = 0x0DE5;
        #endregion IL_IMAGE_HEIGHT

        #region IL_IMAGE_DEPTH
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_DEPTH = 0x0DE6
        public const int IL_IMAGE_DEPTH = 0x0DE6;
        #endregion IL_IMAGE_DEPTH

        #region IL_IMAGE_SIZE_OF_DATA
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_SIZE_OF_DATA = 0x0DE7
        public const int IL_IMAGE_SIZE_OF_DATA = 0x0DE7;
        #endregion IL_IMAGE_SIZE_OF_DATA

        #region IL_IMAGE_BPP
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_BPP = 0x0DE8
        public const int IL_IMAGE_BPP = 0x0DE8;
        #endregion IL_IMAGE_BPP

        #region IL_IMAGE_BYTES_PER_PIXEL
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_BYTES_PER_PIXEL = 0x0DE8
        public const int IL_IMAGE_BYTES_PER_PIXEL = 0x0DE8;
        #endregion IL_IMAGE_BYTES_PER_PIXEL

        #region IL_IMAGE_BITS_PER_PIXEL
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_BITS_PER_PIXEL = 0x0DE9
        public const int IL_IMAGE_BITS_PER_PIXEL = 0x0DE9;
        #endregion IL_IMAGE_BITS_PER_PIXEL

        #region IL_IMAGE_FORMAT
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_FORMAT = 0x0DEA
        public const int IL_IMAGE_FORMAT = 0x0DEA;
        #endregion IL_IMAGE_FORMAT

        #region IL_IMAGE_TYPE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_TYPE = 0x0DEB
        public const int IL_IMAGE_TYPE = 0x0DEB;
        #endregion IL_IMAGE_TYPE

        #region IL_PALETTE_TYPE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PALETTE_TYPE = 0x0DEC
        public const int IL_PALETTE_TYPE = 0x0DEC;
        #endregion IL_PALETTE_TYPE

        #region IL_PALETTE_SIZE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PALETTE_SIZE = 0x0DED
        public const int IL_PALETTE_SIZE = 0x0DED;
        #endregion IL_PALETTE_SIZE

        #region IL_PALETTE_BPP
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PALETTE_BPP = 0x0DEE
        public const int IL_PALETTE_BPP = 0x0DEE;
        #endregion IL_PALETTE_BPP

        #region IL_PALETTE_NUM_COLS
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PALETTE_NUM_COLS = 0x0DEF
        public const int IL_PALETTE_NUM_COLS = 0x0DEF;
        #endregion IL_PALETTE_NUM_COLS

        #region IL_PALETTE_BASE_TYPE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_PALETTE_BASE_TYPE = 0x0DF0
        public const int IL_PALETTE_BASE_TYPE = 0x0DF0;
        #endregion IL_PALETTE_BASE_TYPE

        #region IL_NUM_IMAGES
        /// <summary>
        /// 
        /// </summary>
        // #define IL_NUM_IMAGES = 0x0DF1
        public const int IL_NUM_IMAGES = 0x0DF1;
        #endregion IL_NUM_IMAGES

        #region IL_NUM_MIPMAPS
        /// <summary>
        /// 
        /// </summary>
        // #define IL_NUM_MIPMAPS = 0x0DF2
        public const int IL_NUM_MIPMAPS = 0x0DF2;
        #endregion IL_NUM_MIPMAPS

        #region IL_NUM_LAYERS
        /// <summary>
        /// 
        /// </summary>
        // #define IL_NUM_LAYERS = 0x0DF3
        public const int IL_NUM_LAYERS = 0x0DF3;
        #endregion IL_NUM_LAYERS

        #region IL_ACTIVE_IMAGE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_ACTIVE_IMAGE = 0x0DF4
        public const int IL_ACTIVE_IMAGE = 0x0DF4;
        #endregion IL_ACTIVE_IMAGE

        #region IL_ACTIVE_MIPMAP
        /// <summary>
        /// 
        /// </summary>
        // #define IL_ACTIVE_MIPMAP = 0x0DF5
        public const int IL_ACTIVE_MIPMAP = 0x0DF5;
        #endregion IL_ACTIVE_MIPMAP

        #region IL_ACTIVE_LAYER
        /// <summary>
        /// 
        /// </summary>
        // #define IL_ACTIVE_LAYER = 0x0DF6
        public const int IL_ACTIVE_LAYER = 0x0DF6;
        #endregion IL_ACTIVE_LAYER

        #region IL_CUR_IMAGE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_CUR_IMAGE = 0x0DF7
        public const int IL_CUR_IMAGE = 0x0DF7;
        #endregion IL_CUR_IMAGE

        #region IL_IMAGE_DURATION
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_DURATION = 0x0DF8
        public const int IL_IMAGE_DURATION = 0x0DF8;
        #endregion IL_IMAGE_DURATION

        #region IL_IMAGE_PLANESIZE
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_PLANESIZE = 0x0DF9
        public const int IL_IMAGE_PLANESIZE = 0x0DF9;
        #endregion IL_IMAGE_PLANESIZE

        #region IL_IMAGE_BPC
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_BPC = 0x0DFA
        public const int IL_IMAGE_BPC = 0x0DFA;
        #endregion IL_IMAGE_BPC

        #region IL_IMAGE_OFFX
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_OFFX = 0x0DFB
        public const int IL_IMAGE_OFFX = 0x0DFB;
        #endregion IL_IMAGE_OFFX

        #region IL_IMAGE_OFFY
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_OFFY = 0x0DFC
        public const int IL_IMAGE_OFFY = 0x0DFC;
        #endregion IL_IMAGE_OFFY

        #region IL_IMAGE_CUBEFLAGS
        /// <summary>
        /// 
        /// </summary>
        // #define IL_IMAGE_CUBEFLAGS = 0x0DFD
        public const int IL_IMAGE_CUBEFLAGS = 0x0DFD;
        #endregion IL_IMAGE_CUBEFLAGS

        #region IL_SEEK_SET
        /// <summary>
        /// 
        /// </summary>
        // #define IL_SEEK_SET = 0
        public const int IL_SEEK_SET = 0;
        #endregion IL_SEEK_SET

        #region IL_SEEK_CUR
        /// <summary>
        /// 
        /// </summary>
        // #define IL_SEEK_CUR = 1
        public const int IL_SEEK_CUR = 1;
        #endregion IL_SEEK_CUR

        #region IL_SEEK_END
        /// <summary>
        /// 
        /// </summary>
        // #define IL_SEEK_END = 2
        public const int IL_SEEK_END = 2;
        #endregion IL_SEEK_END

        #region IL_EOF
        /// <summary>
        /// 
        /// </summary>
        // #define IL_EOF = -1
        public const int IL_EOF = -1;
        #endregion IL_EOF
        #endregion  Values
        #endregion Public Constants

        // --- Externs ---
        #region Externs
        #region ilGetIntegerv(int Mode, ref int Param);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        /// <param name="Param"></param>
        // ILAPI ILvoid ILAPIENTRY ilGetIntegerv(ILenum Mode, ILint* Param);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilGetIntegerv(int Mode, ref int Param);
        #endregion ilGetIntegerv(int Mode, ref int Param);

        #region bool ilActiveImage(int Number);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Number"></param>
        // ILAPI ILboolean ILAPIENTRY ilActiveImage(ILuint Number);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilActiveImage(int Number);
        #endregion bool ilActiveImage(int Number);

        #region bool ilActiveLayer(int Number);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Number"></param>
        // ILAPI ILboolean ILAPIENTRY ilActiveLayer(ILuint Number);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilActiveLayer(int Number);
        #endregion bool ilActiveLayer(int Number);

        #region bool ilActiveMipmap(int Number);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Number"></param>
        // ILAPI ILboolean ILAPIENTRY ilActiveMipmap(ILuint Number);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilActiveMipmap(int Number);
        #endregion bool ilActiveMipmap(int Number);

        #region bool ilApplyPal(string FileName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="FileName"></param>
        // ILAPI ILboolean ILAPIENTRY ilApplyPal(ILstring FileName);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilApplyPal(string FileName);
        #endregion bool ilApplyPal(string FileName);

        #region bool ilApplyProfile(string InProfile, string OutProfile);
        /// <summary>
        ///
        /// </summary>
        /// <param name="InProfile"></param>
        /// <param name="OutProfile"></param>
        // ILAPI ILboolean ILAPIENTRY ilApplyProfile(ILstring InProfile, ILstring OutProfile);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilApplyProfile(string InProfile, string OutProfile);
        #endregion bool ilApplyProfile(string InProfile, string OutProfile);

        #region ilBindImage(int Image);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Image"></param>
        // ILAPI ILvoid ILAPIENTRY ilBindImage(ILuint Image);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilBindImage(int Image);
        #endregion ilBindImage(int Image);

        #region bool ilBlit(int Source, int DestX, int DestY, int DestZ, int SrcX, int SrcY, int SrcZ, int Width, int Height, int Depth);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="DestX"></param>
        /// <param name="DestY"></param>
        /// <param name="DestZ"></param>
        /// <param name="SrcX"></param>
        /// <param name="SrcY"></param>
        /// <param name="SrcZ"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Depth"></param>
        // ILAPI ILboolean ILAPIENTRY ilBlit(ILuint Source, ILint DestX, ILint DestY, ILint DestZ, ILuint SrcX, ILuint SrcY, ILuint SrcZ, ILuint Width, ILuint Height, ILuint Depth);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilBlit(int Source, int DestX, int DestY, int DestZ, int SrcX, int SrcY, int SrcZ, int Width, int Height, int Depth);
        #endregion bool ilBlit(int Source, int DestX, int DestY, int DestZ, int SrcX, int SrcY, int SrcZ, int Width, int Height, int Depth);

        #region ilClearColour(float Red, float Green, float Blue, float Alpha);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Red"></param>
        /// <param name="Green"></param>
        /// <param name="Blue"></param>
        /// <param name="Alpha"></param>
        // ILAPI ILvoid ILAPIENTRY ilClearColour(ILclampf Red, ILclampf Green, ILclampf Blue, ILclampf Alpha);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilClearColour(float Red, float Green, float Blue, float Alpha);
        #endregion ilClearColour(float Red, float Green, float Blue, float Alpha);

        #region bool ilClearImage();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY ilClearImage(ILvoid);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilClearImage();
        #endregion bool ilClearImage();

        #region int ilCloneCurImage();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILuint ILAPIENTRY ilCloneCurImage(ILvoid);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int ilCloneCurImage();
        #endregion int ilCloneCurImage();

        #region bool ilCompressFunc(int Mode);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        // ILAPI ILboolean ILAPIENTRY ilCompressFunc(ILenum Mode);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilCompressFunc(int Mode);
        #endregion bool ilCompressFunc(int Mode);

        #region bool ilConvertImage(int DestFormat, int DestType);
        /// <summary>
        ///
        /// </summary>
        /// <param name="DestFormat"></param>
        /// <param name="DestType"></param>
        // ILAPI ILboolean ILAPIENTRY ilConvertImage(ILenum DestFormat, ILenum DestType);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilConvertImage(int DestFormat, int DestType);
        #endregion bool ilConvertImage(int DestFormat, int DestType);

        #region bool ilConvertPal(int DestFormat);
        /// <summary>
        ///
        /// </summary>
        /// <param name="DestFormat"></param>
        // ILAPI ILboolean ILAPIENTRY ilConvertPal(ILenum DestFormat);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilConvertPal(int DestFormat);
        #endregion bool ilConvertPal(int DestFormat);

        #region bool ilCopyImage(int Src);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Src"></param>
        // ILAPI ILboolean ILAPIENTRY ilCopyImage(ILuint Src);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilCopyImage(int Src);
        #endregion bool ilCopyImage(int Src);

        #region int ilCopyPixels(int XOff, int YOff, int ZOff, int Width, int Height, int Depth, int Format, int Type, IntPtr Data);
        /// <summary>
        ///
        /// </summary>
        /// <param name="XOff"></param>
        /// <param name="YOff"></param>
        /// <param name="ZOff"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Depth"></param>
        /// <param name="Format"></param>
        /// <param name="Type"></param>
        /// <param name="Data"></param>
        // ILAPI ILuint ILAPIENTRY ilCopyPixels(ILuint XOff, ILuint YOff, ILuint ZOff, ILuint Width, ILuint Height, ILuint Depth, ILenum Format, ILenum Type, ILvoid* Data);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int ilCopyPixels(int XOff, int YOff, int ZOff, int Width, int Height, int Depth, int Format, int Type, IntPtr Data);
        #endregion int ilCopyPixels(int XOff, int YOff, int ZOff, int Width, int Height, int Depth, int Format, int Type, IntPtr Data);

        #region int ilCopyPixels(int XOff, int YOff, int ZOff, int Width, int Height, int Depth, int Format, int Type, byte[] Data);
        /// <summary>
        ///
        /// </summary>
        /// <param name="XOff"></param>
        /// <param name="YOff"></param>
        /// <param name="ZOff"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Depth"></param>
        /// <param name="Format"></param>
        /// <param name="Type"></param>
        /// <param name="Data"></param>
        // ILAPI ILuint ILAPIENTRY ilCopyPixels(ILuint XOff, ILuint YOff, ILuint ZOff, ILuint Width, ILuint Height, ILuint Depth, ILenum Format, ILenum Type, ILvoid* Data);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int ilCopyPixels(int XOff, int YOff, int ZOff, int Width, int Height, int Depth, int Format, int Type, byte[] Data);
        #endregion int ilCopyPixels(int XOff, int YOff, int ZOff, int Width, int Height, int Depth, int Format, int Type, byte[] Data);

        #region int ilCreateSubImage(int Type, int Num);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Num"></param>
        // ILAPI ILuint ILAPIENTRY ilCreateSubImage(ILenum Type, ILuint Num);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int ilCreateSubImage(int Type, int Num);
        #endregion int ilCreateSubImage(int Type, int Num);

        #region bool ilDefaultImage();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY ilDefaultImage(ILvoid);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilDefaultImage();
        #endregion bool ilDefaultImage();

        #region ilDeleteImages(int Num, ref int Images);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="Images"></param>
        // ILAPI ILvoid ILAPIENTRY ilDeleteImages(ILsizei Num, ILuint* Images);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilDeleteImages(int Num, ref int Images);
        #endregion ilDeleteImages(int Num, ref int Images);

        #region ilDeleteImages(int Num, int[] Images);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="Images"></param>
        // ILAPI ILvoid ILAPIENTRY ilDeleteImages(ILsizei Num, ILuint* Images);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilDeleteImages(int Num, int[] Images);
        #endregion ilDeleteImages(int Num, int[] Images);

        #region bool ilDisable(int Mode);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        // ILAPI ILboolean ILAPIENTRY ilDisable(ILenum Mode);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilDisable(int Mode);
        #endregion bool ilDisable(int Mode);

        #region bool ilEnable(int Mode);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        // ILAPI ILboolean ILAPIENTRY ilEnable(ILenum Mode);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilEnable(int Mode);
        #endregion bool ilEnable(int Mode);

        #region bool ilFormatFunc(int Mode);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        // ILAPI ILboolean ILAPIENTRY ilFormatFunc(ILenum Mode);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilFormatFunc(int Mode);
        #endregion bool ilFormatFunc(int Mode);

        #region ilGenImages(int Num, out int Images);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="Images"></param>
        // ILAPI ILvoid ILAPIENTRY ilGenImages(ILsizei Num, ILuint* Images);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilGenImages(int Num, out int Images);
        #endregion ilGenImages(int Num, out int Images);

        #region IntPtr ilGetAlpha(int Type);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Type"></param>
        // ILAPI ILubyte* ILAPIENTRY ilGetAlpha(ILenum Type);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilGetAlpha(int Type);
        #endregion IntPtr ilGetAlpha(int Type);

        #region bool ilGetBoolean(int Mode);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        // ILAPI ILboolean ILAPIENTRY ilGetBoolean(ILenum Mode);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilGetBoolean(int Mode);
        #endregion bool ilGetBoolean(int Mode);

        #region ilGetBooleanv(int Mode, out bool[] Param);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        /// <param name="Param"></param>
        // ILAPI ILvoid ILAPIENTRY ilGetBooleanv(ILenum Mode, ILboolean* Param);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilGetBooleanv(int Mode, out bool[] Param);
        #endregion ilGetBooleanv(int Mode, out bool[] Param);

        #region IntPtr ilGetData();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILubyte* ILAPIENTRY ilGetData(ILvoid);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilGetData();
        #endregion IntPtr ilGetData();

        #region int ilGetDXTCData(IntPtr Buffer, int BufferSize, int DXTCFormat);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="BufferSize"></param>
        /// <param name="DXTCFormat"></param>
        // ILAPI ILuint ILAPIENTRY ilGetDXTCData(ILvoid* Buffer, ILuint BufferSize, ILenum DXTCFormat);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int ilGetDXTCData(IntPtr Buffer, int BufferSize, int DXTCFormat);
        #endregion int ilGetDXTCData(IntPtr Buffer, int BufferSize, int DXTCFormat);

        #region int ilGetDXTCData(byte[] Buffer, int BufferSize, int DXTCFormat);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="BufferSize"></param>
        /// <param name="DXTCFormat"></param>
        // ILAPI ILuint ILAPIENTRY ilGetDXTCData(ILvoid* Buffer, ILuint BufferSize, ILenum DXTCFormat);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int ilGetDXTCData(byte[] Buffer, int BufferSize, int DXTCFormat);
        #endregion int ilGetDXTCData(byte[] Buffer, int BufferSize, int DXTCFormat);

        #region int ilGetError();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILenum ILAPIENTRY ilGetError(ILvoid);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int ilGetError();
        #endregion int ilGetError();

        #region int ilGetInteger(int Mode);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        // ILAPI ILint ILAPIENTRY ilGetInteger(ILenum Mode);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int ilGetInteger(int Mode);
        #endregion int ilGetInteger(int Mode);

        #region int ilGetLumpPos();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILuint ILAPIENTRY ilGetLumpPos(ILvoid);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int ilGetLumpPos();
        #endregion int ilGetLumpPos();

        #region IntPtr ilGetPalette();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILubyte* ILAPIENTRY ilGetPalette(ILvoid);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilGetPalette();
        #endregion IntPtr ilGetPalette();

        #region string ilGetString(int StringName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="StringName"></param>
        // ILAPI ILstring ILAPIENTRY ilGetString(ILenum StringName);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern string ilGetString(int StringName);
        #endregion string ilGetString(int StringName);

        #region ilHint(int Target, int Mode);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Target"></param>
        /// <param name="Mode"></param>
        // ILAPI ILvoid ILAPIENTRY ilHint(ILenum Target, ILenum Mode);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilHint(int Target, int Mode);
        #endregion ilHint(int Target, int Mode);

        #region ilInit();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILvoid ILAPIENTRY ilInit(ILvoid);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilInit();
        #endregion ilInit();

        #region bool ilIsDisabled(int Mode);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        // ILAPI ILboolean ILAPIENTRY ilIsDisabled(ILenum Mode);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilIsDisabled(int Mode);
        #endregion bool ilIsDisabled(int Mode);

        #region bool ilIsEnabled(int Mode);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        // ILAPI ILboolean ILAPIENTRY ilIsEnabled(ILenum Mode);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilIsEnabled(int Mode);
        #endregion bool ilIsEnabled(int Mode);

        #region bool ilIsImage(int Image);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Image"></param>
        // ILAPI ILboolean ILAPIENTRY ilIsImage(ILuint Image);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilIsImage(int Image);
        #endregion bool ilIsImage(int Image);

        #region bool ilIsValid(int Type, string FileName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="FileName"></param>
        // ILAPI ILboolean ILAPIENTRY ilIsValid(ILenum Type, ILstring FileName);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilIsValid(int Type, string FileName);
        #endregion bool ilIsValid(int Type, string FileName);

        #region bool ilIsValidL(int Type, IntPtr Lump, int Size);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Lump"></param>
        /// <param name="Size"></param>
        // ILAPI ILboolean ILAPIENTRY ilIsValidL(ILenum Type, ILvoid* Lump, ILuint Size);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilIsValidL(int Type, IntPtr Lump, int Size);
        #endregion bool ilIsValidL(int Type, IntPtr Lump, int Size);

        #region ilKeyColour(float Red, float Green, float Blue, float Alpha);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Red"></param>
        /// <param name="Green"></param>
        /// <param name="Blue"></param>
        /// <param name="Alpha"></param>
        // ILAPI ILvoid ILAPIENTRY ilKeyColour(ILclampf Red, ILclampf Green, ILclampf Blue, ILclampf Alpha);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilKeyColour(float Red, float Green, float Blue, float Alpha);
        #endregion ilKeyColour(float Red, float Green, float Blue, float Alpha);

        #region bool ilLoad(int Type, string FileName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="FileName"></param>
        // ILAPI ILboolean ILAPIENTRY ilLoad(ILenum Type, ILstring FileName);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilLoad(int Type, string FileName);
        #endregion bool ilLoad(int Type, string FileName);

        #region bool ilLoadImage(string FileName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="FileName"></param>
        // ILAPI ILboolean ILAPIENTRY ilLoadImage(ILstring FileName);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilLoadImage(string FileName);
        #endregion bool ilLoadImage(string FileName);

        #region bool ilLoadL(int Type, IntPtr Lump, int Size);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Lump"></param>
        /// <param name="Size"></param>
        // ILAPI ILboolean ILAPIENTRY ilLoadL(ILenum Type, ILvoid* Lump, ILuint Size);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilLoadL(int Type, IntPtr Lump, int Size);
        #endregion bool ilLoadL(int Type, IntPtr Lump, int Size);

        #region bool ilLoadL(int Type, byte[] Lump, int Size);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Lump"></param>
        /// <param name="Size"></param>
        // ILAPI ILboolean ILAPIENTRY ilLoadL(ILenum Type, ILvoid* Lump, ILuint Size);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilLoadL(int Type, byte[] Lump, int Size);
        #endregion bool ilLoadL(int Type, byte[] Lump, int Size);

        #region bool ilLoadPal(string FileName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="FileName"></param>
        // ILAPI ILboolean ILAPIENTRY ilLoadPal(ILstring FileName);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilLoadPal(string FileName);
        #endregion bool ilLoadPal(string FileName);

        #region bool ilOriginFunc(int Mode);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        // ILAPI ILboolean ILAPIENTRY ilOriginFunc(ILenum Mode);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilOriginFunc(int Mode);
        #endregion bool ilOriginFunc(int Mode);

        #region bool ilOverlayImage(int Source, int XCoord, int YCoord, int ZCoord);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="XCoord"></param>
        /// <param name="YCoord"></param>
        /// <param name="ZCoord"></param>
        // ILAPI ILboolean ILAPIENTRY ilOverlayImage(ILuint Source, ILint XCoord, ILint YCoord, ILint ZCoord);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilOverlayImage(int Source, int XCoord, int YCoord, int ZCoord);
        #endregion bool ilOverlayImage(int Source, int XCoord, int YCoord, int ZCoord);

        #region ilPopAttrib();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILvoid ILAPIENTRY ilPopAttrib(ILvoid);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilPopAttrib();
        #endregion ilPopAttrib();

        #region ilPushAttrib(int Bits);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Bits"></param>
        // ILAPI ILvoid ILAPIENTRY ilPushAttrib(ILuint Bits);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilPushAttrib(int Bits);
        #endregion ilPushAttrib(int Bits);

        #region ilRegisterFormat(int Format);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Format"></param>
        // ILAPI ILvoid ILAPIENTRY ilRegisterFormat(ILenum Format);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilRegisterFormat(int Format);
        #endregion ilRegisterFormat(int Format);

        #region bool ilRegisterMipNum(int Num);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Num"></param>
        // ILAPI ILboolean ILAPIENTRY ilRegisterMipNum(ILuint Num);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilRegisterMipNum(int Num);
        #endregion bool ilRegisterMipNum(int Num);

        #region bool ilRegisterNumImages(int Num);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Num"></param>
        // ILAPI ILboolean ILAPIENTRY ilRegisterNumImages(ILuint Num);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilRegisterNumImages(int Num);
        #endregion bool ilRegisterNumImages(int Num);

        #region ilRegisterOrigin(int Origin);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Origin"></param>
        // ILAPI ILvoid ILAPIENTRY ilRegisterOrigin(ILenum Origin);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilRegisterOrigin(int Origin);
        #endregion ilRegisterOrigin(int Origin);

        #region ilRegisterPal(IntPtr Pal, int Size, int Type);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Pal"></param>
        /// <param name="Size"></param>
        /// <param name="Type"></param>
        // ILAPI ILvoid ILAPIENTRY ilRegisterPal(ILvoid* Pal, ILuint Size, ILenum Type);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilRegisterPal(IntPtr Pal, int Size, int Type);
        #endregion ilRegisterPal(IntPtr Pal, int Size, int Type);

        #region ilRegisterType(int Type);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Type"></param>
        // ILAPI ILvoid ILAPIENTRY ilRegisterType(ILenum Type);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilRegisterType(int Type);
        #endregion ilRegisterType(int Type);

        #region bool ilRemoveLoad(string Ext);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Ext"></param>
        // ILAPI ILboolean ILAPIENTRY ilRemoveLoad(ILstring Ext);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilRemoveLoad(string Ext);
        #endregion bool ilRemoveLoad(string Ext);

        #region bool ilRemoveSave(string Ext);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Ext"></param>
        // ILAPI ILboolean ILAPIENTRY ilRemoveSave(ILstring Ext);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilRemoveSave(string Ext);
        #endregion bool ilRemoveSave(string Ext);

        #region ilResetMemory();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILvoid ILAPIENTRY ilResetMemory(ILvoid);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilResetMemory();
        #endregion ilResetMemory();

        #region ilResetRead();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILvoid ILAPIENTRY ilResetRead(ILvoid);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilResetRead();
        #endregion ilResetRead();

        #region ilResetWrite();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILvoid ILAPIENTRY ilResetWrite(ILvoid);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilResetWrite();
        #endregion ilResetWrite();

        #region bool ilSave(int Type, string FileName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="FileName"></param>
        // ILAPI ILboolean ILAPIENTRY ilSave(ILenum Type, ILstring FileName);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilSave(int Type, string FileName);
        #endregion bool ilSave(int Type, string FileName);

        #region bool ilSaveImage(string FileName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="FileName"></param>
        // ILAPI ILboolean ILAPIENTRY ilSaveImage(ILstring FileName);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilSaveImage(string FileName);
        #endregion bool ilSaveImage(string FileName);

        #region int ilSaveL(int Type, IntPtr Lump, int Size);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Lump"></param>
        /// <param name="Size"></param>
        // ILAPI ILuint ILAPIENTRY ilSaveL(ILenum Type, ILvoid* Lump, ILuint Size);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int ilSaveL(int Type, IntPtr Lump, int Size);
        #endregion int ilSaveL(int Type, IntPtr Lump, int Size);

        #region bool ilSavePal(string FileName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="FileName"></param>
        // ILAPI ILboolean ILAPIENTRY ilSavePal(ILstring FileName);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilSavePal(string FileName);
        #endregion bool ilSavePal(string FileName);

        #region bool ilSetData(IntPtr Data);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Data"></param>
        // ILAPI ILboolean ILAPIENTRY ilSetData(ILvoid* Data);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilSetData(IntPtr Data);
        #endregion bool ilSetData(IntPtr Data);

        #region bool ilSetDuration(int Duration);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Duration"></param>
        // ILAPI ILboolean ILAPIENTRY ilSetDuration(ILuint Duration);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilSetDuration(int Duration);
        #endregion bool ilSetDuration(int Duration);

        #region ilSetInteger(int Mode, int Param);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        /// <param name="Param"></param>
        // ILAPI ILvoid ILAPIENTRY ilSetInteger(ILenum Mode, ILint Param);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilSetInteger(int Mode, int Param);
        #endregion ilSetInteger(int Mode, int Param);

        #region ilSetPixels(int XOff, int YOff, int ZOff, int Width, int Height, int Depth, int Format, int Type, IntPtr Data);
        /// <summary>
        ///
        /// </summary>
        /// <param name="XOff"></param>
        /// <param name="YOff"></param>
        /// <param name="ZOff"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Depth"></param>
        /// <param name="Format"></param>
        /// <param name="Type"></param>
        /// <param name="Data"></param>
        // ILAPI ILvoid ILAPIENTRY ilSetPixels(ILint XOff, ILint YOff, ILint ZOff, ILuint Width, ILuint Height, ILuint Depth, ILenum Format, ILenum Type, ILvoid* Data);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilSetPixels(int XOff, int YOff, int ZOff, int Width, int Height, int Depth, int Format, int Type, IntPtr Data);
        #endregion ilSetPixels(int XOff, int YOff, int ZOff, int Width, int Height, int Depth, int Format, int Type, IntPtr Data);

        #region ilSetString(int Mode, string String);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        /// <param name="String"></param>
        // ILAPI ILvoid ILAPIENTRY ilSetString(ILenum Mode, char* String);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilSetString(int Mode, string String);
        #endregion ilSetString(int Mode, string String);

        #region ilShutDown();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILvoid ILAPIENTRY ilShutDown(ILvoid);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void ilShutDown();
        #endregion ilShutDown();

        #region bool ilTexImage(int Width, int Height, int Depth, byte Bpp, int Format, int Type, IntPtr Data);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Depth"></param>
        /// <param name="Bpp"></param>
        /// <param name="Format"></param>
        /// <param name="Type"></param>
        /// <param name="Data"></param>
        // ILAPI ILboolean ILAPIENTRY ilTexImage(ILuint Width, ILuint Height, ILuint Depth, ILubyte Bpp, ILenum Format, ILenum Type, ILvoid* Data);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilTexImage(int Width, int Height, int Depth, byte Bpp, int Format, int Type, IntPtr Data);
        #endregion bool ilTexImage(int Width, int Height, int Depth, byte Bpp, int Format, int Type, IntPtr Data);

        #region bool ilTexImage(int Width, int Height, int Depth, byte Bpp, int Format, int Type, byte[] Data);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Depth"></param>
        /// <param name="Bpp"></param>
        /// <param name="Format"></param>
        /// <param name="Type"></param>
        /// <param name="Data"></param>
        // ILAPI ILboolean ILAPIENTRY ilTexImage(ILuint Width, ILuint Height, ILuint Depth, ILubyte Bpp, ILenum Format, ILenum Type, ILvoid* Data);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilTexImage(int Width, int Height, int Depth, byte Bpp, int Format, int Type, byte[] Data);
        #endregion bool ilTexImage(int Width, int Height, int Depth, byte Bpp, int Format, int Type, byte[] Data);

        #region bool ilTypeFunc(int Mode);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        // ILAPI ILboolean ILAPIENTRY ilTypeFunc(ILenum Mode);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilTypeFunc(int Mode);
        #endregion bool ilTypeFunc(int Mode);

        #region bool ilLoadData(string FileName, int Width, int Height, int Depth, byte Bpp);
        /// <summary>
        ///
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Depth"></param>
        /// <param name="Bpp"></param>
        // ILAPI ILboolean ILAPIENTRY ilLoadData(ILstring FileName, ILuint Width, ILuint Height, ILuint Depth, ILubyte Bpp);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilLoadData(string FileName, int Width, int Height, int Depth, byte Bpp);
        #endregion bool ilLoadData(string FileName, int Width, int Height, int Depth, byte Bpp);

        #region bool ilLoadDataL(IntPtr Lump, int Size, int Width, int Height, int Depth, byte Bpp);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Lump"></param>
        /// <param name="Size"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Depth"></param>
        /// <param name="Bpp"></param>
        // ILAPI ILboolean ILAPIENTRY ilLoadDataL(ILvoid* Lump, ILuint Size, ILuint Width, ILuint Height, ILuint Depth, ILubyte Bpp);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilLoadDataL(IntPtr Lump, int Size, int Width, int Height, int Depth, byte Bpp);
        #endregion bool ilLoadDataL(IntPtr Lump, int Size, int Width, int Height, int Depth, byte Bpp);

        #region bool ilSaveData(string FileName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="FileName"></param>
        // ILAPI ILboolean ILAPIENTRY ilSaveData(ILstring FileName);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilSaveData(string FileName);
        #endregion bool ilSaveData(string FileName);

        #region bool ilLoadFromJpegStruct(IntPtr JpegDecompressorPtr);
        /// <summary>
        ///
        /// </summary>
        /// <param name="JpegDecompressorPtr"></param>
        // ILAPI ILboolean ILAPIENTRY ilLoadFromJpegStruct(ILvoid* JpegDecompressorPtr);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilLoadFromJpegStruct(IntPtr JpegDecompressorPtr);
        #endregion bool ilLoadFromJpegStruct(IntPtr JpegDecompressorPtr);

        #region bool ilSaveFromJpegStruct(IntPtr JpegCompressorPtr);
        /// <summary>
        ///
        /// </summary>
        /// <param name="JpegCompressorPtr"></param>
        // ILAPI ILboolean ILAPIENTRY ilSaveFromJpegStruct(ILvoid* JpegCompressorPtr);
        [DllImport(IL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool ilSaveFromJpegStruct(IntPtr JpegCompressorPtr);
        #endregion bool ilSaveFromJpegStruct(IntPtr JpegCompressorPtr);
        #endregion Externs
    }
}
