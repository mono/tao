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

#region Aliases
using ILHANDLE = System.IntPtr;
//typedef unsigned int   ILenum;
using ILenum = System.Int32;
//typedef unsigned char  ILboolean;
using ILboolean = System.Boolean;
//typedef unsigned int   ILbitfield;
using ILbitfield = System.UInt32;
//typedef char           ILbyte;
using ILbyte = System.Byte;
//typedef short          ILshort;
using ILshort = System.Int16;
//typedef int            ILint;
using ILint = System.Int32;
//typedef int            ILsizei;
using ILsizei = System.Int32;
//typedef unsigned char  ILubyte;
using ILubyte = System.Byte;
//typedef unsigned short ILushort;
using ILushort = System.UInt16;
//typedef unsigned int   ILuint;
using ILuint = System.Int32;
//typedef float          ILfloat;
using ILfloat = System.Single;
//typedef float          ILclampf;
using ILclampf = System.Single;
//typedef double         ILdouble;
using ILdouble = System.Double;
//typedef double         ILclampd;
using ILclampd = System.Double;
//typedef void           ILvoid;
//using ILvoid = void;
using ILstring = System.String;
#endregion Aliases

namespace Tao.DevIl
{
    #region Class Documentation
    /// <summary>
    ///     DevIL (Developer's Image Library) ILU binding for .NET.
    /// </summary>
    #endregion Class Documentation
    public sealed class Ilu
    {
        // --- Fields ---
        #region Private Constants
        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.Cdecl" /> for Windows and
        ///     Linux.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;
        #endregion CallingConvention CALLING_CONVENTION
        #region string ILU_NATIVE_LIBRARY
        /// <summary>
        /// Specifies the DevIL ILU native library used in the bindings
        /// </summary>
        /// <remarks>
        /// The Windows dll is specified here universally - note that
        /// under Mono the non-windows native library can be mapped using
        /// the ".config" file mechanism.  Kudos to the Mono team for this
        /// simple yet elegant solution.
        /// </remarks>
        private const string ILU_NATIVE_LIBRARY = "ILU.dll";
        #endregion string ILU_NATIVE_LIBRARY
        #endregion Private Constants

        #region Public Constants

        // #define ILU_VERSION_1_6_8 1
        public const int ILU_VERSION_1_6_8 = 1;
        // #define ILU_VERSION       168
        public const int ILU_VERSION = 168;
        // #define ILU_FILTER         0x2600
        public const int ILU_FILTER = 0x2600;
        // #define ILU_NEAREST        0x2601
        public const int ILU_NEAREST = 0x2601;
        // #define ILU_LINEAR         0x2602
        public const int ILU_LINEAR = 0x2602;
        // #define ILU_BILINEAR       0x2603
        public const int ILU_BILINEAR = 0x2603;
        // #define ILU_SCALE_BOX      0x2604
        public const int ILU_SCALE_BOX = 0x2604;
        // #define ILU_SCALE_TRIANGLE 0x2605
        public const int ILU_SCALE_TRIANGLE = 0x2605;
        // #define ILU_SCALE_BELL     0x2606
        public const int ILU_SCALE_BELL = 0x2606;
        // #define ILU_SCALE_BSPLINE  0x2607
        public const int ILU_SCALE_BSPLINE = 0x2607;
        // #define ILU_SCALE_LANCZOS3 0x2608
        public const int ILU_SCALE_LANCZOS3 = 0x2608;
        // #define ILU_SCALE_MITCHELL 0x2609
        public const int ILU_SCALE_MITCHELL = 0x2609;
        // #define ILU_INVALID_ENUM      0x0501
        public const int ILU_INVALID_ENUM = 0x0501;
        // #define ILU_OUT_OF_MEMORY     0x0502
        public const int ILU_OUT_OF_MEMORY = 0x0502;
        // #define ILU_INTERNAL_ERROR    0x0504
        public const int ILU_INTERNAL_ERROR = 0x0504;
        // #define ILU_INVALID_VALUE     0x0505
        public const int ILU_INVALID_VALUE = 0x0505;
        // #define ILU_ILLEGAL_OPERATION 0x0506
        public const int ILU_ILLEGAL_OPERATION = 0x0506;
        // #define ILU_INVALID_PARAM     0x0509
        public const int ILU_INVALID_PARAM = 0x0509;
        // #define ILU_PLACEMENT          0x0700
        public const int ILU_PLACEMENT = 0x0700;
        // #define ILU_LOWER_LEFT         0x0701
        public const int ILU_LOWER_LEFT = 0x0701;
        // #define ILU_LOWER_RIGHT        0x0702
        public const int ILU_LOWER_RIGHT = 0x0702;
        // #define ILU_UPPER_LEFT         0x0703
        public const int ILU_UPPER_LEFT = 0x0703;
        // #define ILU_UPPER_RIGHT        0x0704
        public const int ILU_UPPER_RIGHT = 0x0704;
        // #define ILU_CENTER             0x0705
        public const int ILU_CENTER = 0x0705;
        // #define ILU_CONVOLUTION_MATRIX 0x0710
        public const int ILU_CONVOLUTION_MATRIX = 0x0710;
        // #define ILU_VERSION_NUM IL_VERSION_NUM
        public const int ILU_VERSION_NUM = Il.IL_VERSION_NUM;
        // #define ILU_VENDOR      IL_VENDOR
        public const int ILU_VENDOR = Il.IL_VENDOR;

        #endregion Public Constants

        #region Externs

        // ILAPI ILboolean      ILAPIENTRY iluAlienify(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluAlienify();

        // ILAPI ILboolean      ILAPIENTRY iluBlurAvg(ILuint Iter);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluBlurAvg(ILuint Iter);

        // ILAPI ILboolean      ILAPIENTRY iluBlurGaussian(ILuint Iter);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluBlurGaussian(ILuint Iter);

        // ILAPI ILboolean      ILAPIENTRY iluBuildMipmaps(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluBuildMipmaps();

        // ILAPI ILuint         ILAPIENTRY iluColoursUsed(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint iluColoursUsed();

        // ILAPI ILboolean      ILAPIENTRY iluCompareImage(ILuint Comp);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluCompareImage(ILuint Comp);

        // ILAPI ILboolean      ILAPIENTRY iluContrast(ILfloat Contrast);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluContrast(ILfloat Contrast);

        // ILAPI ILboolean      ILAPIENTRY iluCrop(ILuint XOff, ILuint YOff, ILuint ZOff, ILuint Width, ILuint Height, ILuint Depth);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluCrop(ILuint XOff, ILuint YOff, ILuint ZOff, ILuint Width, ILuint Height, ILuint Depth);

        // ILAPI ILvoid         ILAPIENTRY iluDeleteImage(ILuint Id);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void iluDeleteImage(ILuint Id);

        // ILAPI ILboolean      ILAPIENTRY iluEdgeDetectE(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEdgeDetectE();

        // ILAPI ILboolean      ILAPIENTRY iluEdgeDetectP(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEdgeDetectP();

        // ILAPI ILboolean      ILAPIENTRY iluEdgeDetectS(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEdgeDetectS();

        // ILAPI ILboolean      ILAPIENTRY iluEmboss(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEmboss();

        // ILAPI ILboolean      ILAPIENTRY iluEnlargeCanvas(ILuint Width, ILuint Height, ILuint Depth);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEnlargeCanvas(ILuint Width, ILuint Height, ILuint Depth);

        // ILAPI ILboolean      ILAPIENTRY iluEnlargeImage(ILfloat XDim, ILfloat YDim, ILfloat ZDim);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEnlargeImage(ILfloat XDim, ILfloat YDim, ILfloat ZDim);

        // ILAPI ILboolean      ILAPIENTRY iluEqualize(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEqualize();

        // ILAPI ILstring 		 ILAPIENTRY iluErrorString(ILenum Error);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILstring iluErrorString(ILenum Error);

        // ILAPI ILboolean      ILAPIENTRY iluConvolution(ILint *matrix, ILint scale, ILint bias);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluConvolution(ILint[] matrix, ILint scale, ILint bias);

        // ILAPI ILboolean      ILAPIENTRY iluFlipImage(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluFlipImage();

        // ILAPI ILboolean      ILAPIENTRY iluGammaCorrect(ILfloat Gamma);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluGammaCorrect(ILfloat Gamma);

        // ILAPI ILuint         ILAPIENTRY iluGenImage(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint iluGenImage();

        // ILAPI ILvoid         ILAPIENTRY iluGetImageInfo(ILinfo *Info);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void iluGetImageInfo(out ILinfo Info);

        // ILAPI ILint          ILAPIENTRY iluGetInteger(ILenum Mode);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILint iluGetInteger(ILenum Mode);

        // ILAPI ILvoid         ILAPIENTRY iluGetIntegerv(ILenum Mode, ILint *Param);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void iluGetIntegerv(ILenum Mode, out ILint Param);

        // ILAPI ILstring 		 ILAPIENTRY iluGetString(ILenum StringName);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILstring iluGetString(ILenum StringName);

        // ILAPI ILvoid         ILAPIENTRY iluImageParameter(ILenum PName, ILenum Param);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void iluImageParameter(ILenum PName, ILenum Param);

        // ILAPI ILvoid         ILAPIENTRY iluInit(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void iluInit();

        // ILAPI ILboolean      ILAPIENTRY iluInvertAlpha(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluInvertAlpha();

        // ILAPI ILuint         ILAPIENTRY iluLoadImage(const ILstring FileName);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint iluLoadImage(ILstring FileName);

        // ILAPI ILboolean      ILAPIENTRY iluMirror(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluMirror();

        // ILAPI ILboolean      ILAPIENTRY iluNegative(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluNegative();

        // ILAPI ILboolean      ILAPIENTRY iluNoisify(ILclampf Tolerance);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluNoisify(ILclampf Tolerance);

        // ILAPI ILboolean      ILAPIENTRY iluPixelize(ILuint PixSize);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluPixelize(ILuint PixSize);

        // ILAPI ILvoid         ILAPIENTRY iluRegionfv(ILpointf *Points, ILuint n);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void iluRegionfv(ILpointf[] Points, ILuint n);

        // ILAPI ILvoid         ILAPIENTRY iluRegioniv(ILpointi *Points, ILuint n);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void iluRegioniv(ILpointi[] Points, ILuint n);

        // ILAPI ILboolean      ILAPIENTRY iluReplaceColour(ILubyte Red, ILubyte Green, ILubyte Blue, ILfloat Tolerance);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluReplaceColour(ILubyte Red, ILubyte Green, ILubyte Blue, ILfloat Tolerance);

        // ILAPI ILboolean      ILAPIENTRY iluRotate(ILfloat Angle);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluRotate(ILfloat Angle);

        // ILAPI ILboolean      ILAPIENTRY iluRotate3D(ILfloat x, ILfloat y, ILfloat z, ILfloat Angle);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluRotate3D(ILfloat x, ILfloat y, ILfloat z, ILfloat Angle);

        // ILAPI ILboolean      ILAPIENTRY iluSaturate1f(ILfloat Saturation);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluSaturate1f(ILfloat Saturation);

        // ILAPI ILboolean      ILAPIENTRY iluSaturate4f(ILfloat r, ILfloat g, ILfloat b, ILfloat Saturation);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluSaturate4f(ILfloat r, ILfloat g, ILfloat b, ILfloat Saturation);

        // ILAPI ILboolean      ILAPIENTRY iluScale(ILuint Width, ILuint Height, ILuint Depth);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluScale(ILuint Width, ILuint Height, ILuint Depth);

        // ILAPI ILboolean      ILAPIENTRY iluScaleColours(ILfloat r, ILfloat g, ILfloat b);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluScaleColours(ILfloat r, ILfloat g, ILfloat b);

        // ILAPI ILboolean      ILAPIENTRY iluSharpen(ILfloat Factor, ILuint Iter);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluSharpen(ILfloat Factor, ILuint Iter);

        // ILAPI ILboolean      ILAPIENTRY iluSwapColours(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluSwapColours();

        // ILAPI ILboolean      ILAPIENTRY iluWave(ILfloat Angle);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluWave(ILfloat Angle);
        
        #endregion Externs
    }

    // --- Public Structs ---
    #region Public Structs
    // typedef struct ILinfo
    // {
    // 	ILuint  Id;         // the image's id
    // 	ILubyte *Data;      // the image's data
    // 	ILuint  Width;      // the image's width
    // 	ILuint  Height;     // the image's height
    // 	ILuint  Depth;      // the image's depth
    // 	ILubyte Bpp;        // bytes per pixel (not bits) of the image
    // 	ILuint  SizeOfData; // the total size of the data (in bytes)
    // 	ILenum  Format;     // image format (in IL enum style)
    // 	ILenum  Type;       // image type (in IL enum style)
    // 	ILenum  Origin;     // origin of the image
    // 	ILubyte *Palette;   // the image's palette
    // 	ILenum  PalType;    // palette type
    // 	ILuint  PalSize;    // palette size
    // 	ILenum  CubeFlags;  // flags for what cube map sides are present
    // 	ILuint  NumNext;    // number of images following
    // 	ILuint  NumMips;    // number of mipmaps
    // 	ILuint  NumLayers;  // number of layers
    // } ILinfo;
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct ILinfo
    {
        ILuint Id;         // the image's id
        ILubyte[] Data;      // the image's data
        ILuint Width;      // the image's width
        ILuint Height;     // the image's height
        ILuint Depth;      // the image's depth
        ILubyte Bpp;        // bytes per pixel (not bits) of the image
        ILuint SizeOfData; // the total size of the data (in bytes)
        ILenum Format;     // image format (in IL enum style)
        ILenum Type;       // image type (in IL enum style)
        ILenum Origin;     // origin of the image
        ILubyte[] Palette;   // the image's palette
        ILenum PalType;    // palette type
        ILuint PalSize;    // palette size
        ILenum CubeFlags;  // flags for what cube map sides are present
        ILuint NumNext;    // number of images following
        ILuint NumMips;    // number of mipmaps
        ILuint NumLayers;  // number of layers
    };

    // typedef struct ILpointf
    // {
    // 	ILfloat x, y;
    // } ILpointf;
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct ILpointf
    {
        public ILfloat x, y;
    };

    // typedef struct ILpointi
    // {
    // 	ILint x, y;
    // } ILpointi;
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct ILpointi
    {
        public ILint x, y;
    };
    #endregion Public Structs
}
