#region License
/*
MIT License
Copyright ©2003-2004 Randy Ridge
http://www.randyridge.com/Tao/Default.aspx
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

namespace Tao.DevIl {
    #region Class Documentation
    /// <summary>
    ///     Core DevIL library binding for .NET.
    /// </summary>
    #endregion Class Documentation
    public sealed class Ilu {
        // --- Fields ---
        #region Private Constants
        #region string ILU_NATIVE_LIBRARY
        /// <summary>
        ///     Specifies DevIl's native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies ilu.dll for Windows and libILU.so for Linux.
        /// </remarks>
        #if WIN32
        private const string ILU_NATIVE_LIBRARY = "ilu.dll";
        #elif LINUX
        private const string ILU_NATIVE_LIBRARY = "libILU.so";
        #endif
        #endregion string ILU_NATIVE_LIBRARY

        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.StdCall" /> for Windows and
        ///     <see cref="CallingConvention.Cdecl" /> for Linux.
        /// </remarks>
        #if WIN32
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;
        #elif LINUX
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;
        #endif
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants

        #region Public Constants
        #region  Core Constants
        #region ILU_VERSION_1_6_1
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_VERSION_1_6_1 = 1
        public const int ILU_VERSION_1_6_1 = 1;
        #endregion ILU_VERSION_1_6_1

        #region ILU_VERSION
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_VERSION = 161
        public const int ILU_VERSION = 161;
        #endregion ILU_VERSION

        #region ILU_FILTER
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_FILTER = 0x2600
        public const int ILU_FILTER = 0x2600;
        #endregion ILU_FILTER

        #region ILU_NEAREST
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_NEAREST = 0x2601
        public const int ILU_NEAREST = 0x2601;
        #endregion ILU_NEAREST

        #region ILU_LINEAR
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_LINEAR = 0x2602
        public const int ILU_LINEAR = 0x2602;
        #endregion ILU_LINEAR

        #region ILU_BILINEAR
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_BILINEAR = 0x2603
        public const int ILU_BILINEAR = 0x2603;
        #endregion ILU_BILINEAR

        #region ILU_SCALE_BOX
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_SCALE_BOX = 0x2604
        public const int ILU_SCALE_BOX = 0x2604;
        #endregion ILU_SCALE_BOX

        #region ILU_SCALE_TRIANGLE
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_SCALE_TRIANGLE = 0x2605
        public const int ILU_SCALE_TRIANGLE = 0x2605;
        #endregion ILU_SCALE_TRIANGLE

        #region ILU_SCALE_BELL
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_SCALE_BELL = 0x2606
        public const int ILU_SCALE_BELL = 0x2606;
        #endregion ILU_SCALE_BELL

        #region ILU_SCALE_BSPLINE
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_SCALE_BSPLINE = 0x2607
        public const int ILU_SCALE_BSPLINE = 0x2607;
        #endregion ILU_SCALE_BSPLINE

        #region ILU_SCALE_LANCZOS3
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_SCALE_LANCZOS3 = 0x2608
        public const int ILU_SCALE_LANCZOS3 = 0x2608;
        #endregion ILU_SCALE_LANCZOS3

        #region ILU_SCALE_MITCHELL
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_SCALE_MITCHELL = 0x2609
        public const int ILU_SCALE_MITCHELL = 0x2609;
        #endregion ILU_SCALE_MITCHELL
        #endregion  Core Constants

        #region  Error types
        #region ILU_INVALID_ENUM
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_INVALID_ENUM = 0x0501
        public const int ILU_INVALID_ENUM = 0x0501;
        #endregion ILU_INVALID_ENUM

        #region ILU_OUT_OF_MEMORY
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_OUT_OF_MEMORY = 0x0502
        public const int ILU_OUT_OF_MEMORY = 0x0502;
        #endregion ILU_OUT_OF_MEMORY

        #region ILU_INTERNAL_ERROR
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_INTERNAL_ERROR = 0x0504
        public const int ILU_INTERNAL_ERROR = 0x0504;
        #endregion ILU_INTERNAL_ERROR

        #region ILU_INVALID_VALUE
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_INVALID_VALUE = 0x0505
        public const int ILU_INVALID_VALUE = 0x0505;
        #endregion ILU_INVALID_VALUE

        #region ILU_ILLEGAL_OPERATION
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_ILLEGAL_OPERATION = 0x0506
        public const int ILU_ILLEGAL_OPERATION = 0x0506;
        #endregion ILU_ILLEGAL_OPERATION

        #region ILU_INVALID_PARAM
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_INVALID_PARAM = 0x0509
        public const int ILU_INVALID_PARAM = 0x0509;
        #endregion ILU_INVALID_PARAM
        #endregion  Error types

        #region  Values
        #region ILU_PLACEMENT
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_PLACEMENT = 0x0700
        public const int ILU_PLACEMENT = 0x0700;
        #endregion ILU_PLACEMENT

        #region ILU_LOWER_LEFT
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_LOWER_LEFT = 0x0701
        public const int ILU_LOWER_LEFT = 0x0701;
        #endregion ILU_LOWER_LEFT

        #region ILU_LOWER_RIGHT
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_LOWER_RIGHT = 0x0702
        public const int ILU_LOWER_RIGHT = 0x0702;
        #endregion ILU_LOWER_RIGHT

        #region ILU_UPPER_LEFT
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_UPPER_LEFT = 0x0703
        public const int ILU_UPPER_LEFT = 0x0703;
        #endregion ILU_UPPER_LEFT

        #region ILU_UPPER_RIGHT
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_UPPER_RIGHT = 0x0704
        public const int ILU_UPPER_RIGHT = 0x0704;
        #endregion ILU_UPPER_RIGHT

        #region ILU_CENTER
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_CENTER = 0x0705
        public const int ILU_CENTER = 0x0705;
        #endregion ILU_CENTER

        #region ILU_CONVOLUTION_MATRIX
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_CONVOLUTION_MATRIX = 0x0710
        public const int ILU_CONVOLUTION_MATRIX = 0x0710;
        #endregion ILU_CONVOLUTION_MATRIX

        #region ILU_VERSION_NUM
        /// <summary>
        /// 
        /// </summary>
        // #define ILU_VERSION_NUM = 0x0DE2
        public const int ILU_VERSION_NUM = 0x0DE2;
        #endregion ILU_VERSION_NUM
        #endregion  Values
        #endregion Public Constants

        // --- Externs ---
        #region Externs
        #region bool iluAlienify();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY iluAlienify(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluAlienify();
        #endregion bool iluAlienify();

        #region bool iluBlurAvg(int Iter);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Iter"></param>
        // ILAPI ILboolean ILAPIENTRY iluBlurAvg(ILuint Iter);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluBlurAvg(int Iter);
        #endregion bool iluBlurAvg(int Iter);

        #region bool iluBlurGaussian(int Iter);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Iter"></param>
        // ILAPI ILboolean ILAPIENTRY iluBlurGaussian(ILuint Iter);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluBlurGaussian(int Iter);
        #endregion bool iluBlurGaussian(int Iter);

        #region bool iluBuildMipmaps();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY iluBuildMipmaps(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluBuildMipmaps();
        #endregion bool iluBuildMipmaps();

        #region int iluColoursUsed();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILuint ILAPIENTRY iluColoursUsed(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int iluColoursUsed();
        #endregion int iluColoursUsed();

        #region bool iluCompareImage(int Comp);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Comp"></param>
        // ILAPI ILboolean ILAPIENTRY iluCompareImage(ILuint Comp);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluCompareImage(int Comp);
        #endregion bool iluCompareImage(int Comp);

        #region bool iluContrast(float Contrast);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Contrast"></param>
        // ILAPI ILboolean ILAPIENTRY iluContrast(ILfloat Contrast);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluContrast(float Contrast);
        #endregion bool iluContrast(float Contrast);

        #region bool iluCrop(int XOff, int YOff, int ZOff, int Width, int Height, int Depth);
        /// <summary>
        ///
        /// </summary>
        /// <param name="XOff"></param>
        /// <param name="YOff"></param>
        /// <param name="ZOff"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Depth"></param>
        // ILAPI ILboolean ILAPIENTRY iluCrop(ILuint XOff, ILuint YOff, ILuint ZOff, ILuint Width, ILuint Height, ILuint Depth);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluCrop(int XOff, int YOff, int ZOff, int Width, int Height, int Depth);
        #endregion bool iluCrop(int XOff, int YOff, int ZOff, int Width, int Height, int Depth);

        #region iluDeleteImage(int Id);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Id"></param>
        // ILAPI ILvoid ILAPIENTRY iluDeleteImage(ILuint Id);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void iluDeleteImage(int Id);
        #endregion iluDeleteImage(int Id);

        #region bool iluEdgeDetectE();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY iluEdgeDetectE(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluEdgeDetectE();
        #endregion bool iluEdgeDetectE();

        #region bool iluEdgeDetectP();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY iluEdgeDetectP(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluEdgeDetectP();
        #endregion bool iluEdgeDetectP();

        #region bool iluEdgeDetectS();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY iluEdgeDetectS(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluEdgeDetectS();
        #endregion bool iluEdgeDetectS();

        #region bool iluEmboss();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY iluEmboss(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluEmboss();
        #endregion bool iluEmboss();

        #region bool iluEnlargeCanvas(int Width, int Height, int Depth);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Depth"></param>
        // ILAPI ILboolean ILAPIENTRY iluEnlargeCanvas(ILuint Width, ILuint Height, ILuint Depth);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluEnlargeCanvas(int Width, int Height, int Depth);
        #endregion bool iluEnlargeCanvas(int Width, int Height, int Depth);

        #region bool iluEnlargeImage(float XDim, float YDim, float ZDim);
        /// <summary>
        ///
        /// </summary>
        /// <param name="XDim"></param>
        /// <param name="YDim"></param>
        /// <param name="ZDim"></param>
        // ILAPI ILboolean ILAPIENTRY iluEnlargeImage(ILfloat XDim, ILfloat YDim, ILfloat ZDim);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluEnlargeImage(float XDim, float YDim, float ZDim);
        #endregion bool iluEnlargeImage(float XDim, float YDim, float ZDim);

        #region bool iluEqualize();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY iluEqualize(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluEqualize();
        #endregion bool iluEqualize();

        #region string iluErrorString(int Error);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Error"></param>
        // ILAPI ILstring ILAPIENTRY iluErrorString(ILenum Error);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern string iluErrorString(int Error);
        #endregion string iluErrorString(int Error);

        #region bool iluFlipImage();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY iluFlipImage(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluFlipImage();
        #endregion bool iluFlipImage();

        #region bool iluGammaCorrect(float Gamma);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Gamma"></param>
        // ILAPI ILboolean ILAPIENTRY iluGammaCorrect(ILfloat Gamma);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluGammaCorrect(float Gamma);
        #endregion bool iluGammaCorrect(float Gamma);

        #region int iluGenImage();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILuint ILAPIENTRY iluGenImage(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int iluGenImage();
        #endregion int iluGenImage();

        #region iluGetImageInfo(ref ILinfo Info);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Info"></param>
        // ILAPI ILvoid ILAPIENTRY iluGetImageInfo(ILinfo* Info);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void iluGetImageInfo(ref ILinfo Info);
        #endregion iluGetImageInfo(ref ILinfo Info);

        #region int iluGetInteger(int Mode);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        // ILAPI ILint ILAPIENTRY iluGetInteger(ILenum Mode);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int iluGetInteger(int Mode);
        #endregion int iluGetInteger(int Mode);

        #region iluGetIntegerv(int Mode, ref int Param);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Mode"></param>
        /// <param name="Param"></param>
        // ILAPI ILvoid ILAPIENTRY iluGetIntegerv(ILenum Mode, ILint* Param);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void iluGetIntegerv(int Mode, ref int Param);
        #endregion iluGetIntegerv(int Mode, ref int Param);

        #region string iluGetString(int StringName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="StringName"></param>
        // ILAPI ILstring ILAPIENTRY iluGetString(ILenum StringName);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern string iluGetString(int StringName);
        #endregion string iluGetString(int StringName);

        #region iluImageParameter(int PName, int Param);
        /// <summary>
        ///
        /// </summary>
        /// <param name="PName"></param>
        /// <param name="Param"></param>
        // ILAPI ILvoid ILAPIENTRY iluImageParameter(ILenum PName, ILenum Param);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void iluImageParameter(int PName, int Param);
        #endregion iluImageParameter(int PName, int Param);

        #region iluInit();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILvoid ILAPIENTRY iluInit(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void iluInit();
        #endregion iluInit();

        #region bool iluInvertAlpha();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY iluInvertAlpha(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluInvertAlpha();
        #endregion bool iluInvertAlpha();

        #region int iluLoadImage(string FileName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="FileName"></param>
        // ILAPI ILuint ILAPIENTRY iluLoadImage(ILstring FileName);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern int iluLoadImage(string FileName);
        #endregion int iluLoadImage(string FileName);

        #region bool iluMirror();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY iluMirror(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluMirror();
        #endregion bool iluMirror();

        #region bool iluNegative();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY iluNegative(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluNegative();
        #endregion bool iluNegative();

        #region bool iluNoisify(float Tolerance);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Tolerance"></param>
        // ILAPI ILboolean ILAPIENTRY iluNoisify(ILclampf Tolerance);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluNoisify(float Tolerance);
        #endregion bool iluNoisify(float Tolerance);

        #region bool iluPixelize(int PixSize);
        /// <summary>
        ///
        /// </summary>
        /// <param name="PixSize"></param>
        // ILAPI ILboolean ILAPIENTRY iluPixelize(ILuint PixSize);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluPixelize(int PixSize);
        #endregion bool iluPixelize(int PixSize);

        #region iluRegionfv(ILpointf[] Points, int n);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Points"></param>
        /// <param name="n"></param>
        // ILAPI ILvoid ILAPIENTRY iluRegionfv(ILpointf* Points, ILuint n);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void iluRegionfv(ILpointf[] Points, int n);
        #endregion iluRegionfv(ILpointf[] Points, int n);

        #region iluRegioniv(ILpointi[] Points, int n);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Points"></param>
        /// <param name="n"></param>
        // ILAPI ILvoid ILAPIENTRY iluRegioniv(ILpointi* Points, ILuint n);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern void iluRegioniv(ILpointi[] Points, int n);
        #endregion iluRegioniv(ILpointi[] Points, int n);

        #region bool iluReplaceColour(byte Red, byte Green, byte Blue, float Tolerance);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Red"></param>
        /// <param name="Green"></param>
        /// <param name="Blue"></param>
        /// <param name="Tolerance"></param>
        // ILAPI ILboolean ILAPIENTRY iluReplaceColour(ILubyte Red, ILubyte Green, ILubyte Blue, ILfloat Tolerance);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluReplaceColour(byte Red, byte Green, byte Blue, float Tolerance);
        #endregion bool iluReplaceColour(byte Red, byte Green, byte Blue, float Tolerance);

        #region bool iluRotate(float Angle);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Angle"></param>
        // ILAPI ILboolean ILAPIENTRY iluRotate(ILfloat Angle);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluRotate(float Angle);
        #endregion bool iluRotate(float Angle);

        #region bool iluRotate3D(float x, float y, float z, float Angle);
        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="Angle"></param>
        // ILAPI ILboolean ILAPIENTRY iluRotate3D(ILfloat x, ILfloat y, ILfloat z, ILfloat Angle);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluRotate3D(float x, float y, float z, float Angle);
        #endregion bool iluRotate3D(float x, float y, float z, float Angle);

        #region bool iluSaturate1f(float Saturation);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Saturation"></param>
        // ILAPI ILboolean ILAPIENTRY iluSaturate1f(ILfloat Saturation);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluSaturate1f(float Saturation);
        #endregion bool iluSaturate1f(float Saturation);

        #region bool iluSaturate4f(float r, float g, float b, float Saturation);
        /// <summary>
        ///
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="Saturation"></param>
        // ILAPI ILboolean ILAPIENTRY iluSaturate4f(ILfloat r, ILfloat g, ILfloat b, ILfloat Saturation);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluSaturate4f(float r, float g, float b, float Saturation);
        #endregion bool iluSaturate4f(float r, float g, float b, float Saturation);

        #region bool iluScale(int Width, int Height, int Depth);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Depth"></param>
        // ILAPI ILboolean ILAPIENTRY iluScale(ILuint Width, ILuint Height, ILuint Depth);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluScale(int Width, int Height, int Depth);
        #endregion bool iluScale(int Width, int Height, int Depth);

        #region bool iluScaleColours(float r, float g, float b);
        /// <summary>
        ///
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        // ILAPI ILboolean ILAPIENTRY iluScaleColours(ILfloat r, ILfloat g, ILfloat b);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluScaleColours(float r, float g, float b);
        #endregion bool iluScaleColours(float r, float g, float b);

        #region bool iluSharpen(float Factor, int Iter);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Factor"></param>
        /// <param name="Iter"></param>
        // ILAPI ILboolean ILAPIENTRY iluSharpen(ILfloat Factor, ILuint Iter);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluSharpen(float Factor, int Iter);
        #endregion bool iluSharpen(float Factor, int Iter);

        #region bool iluSwapColours();
        /// <summary>
        ///
        /// </summary>
        // ILAPI ILboolean ILAPIENTRY iluSwapColours(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluSwapColours();
        #endregion bool iluSwapColours();

        #region bool iluWave(float Angle);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Angle"></param>
        // ILAPI ILboolean ILAPIENTRY iluWave(ILfloat Angle);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
        public static extern bool iluWave(float Angle);
        #endregion bool iluWave(float Angle);
        #endregion Externs
    }

    // --- Public Structs ---
    #region Public Structs
    /// <summary>
    ///     
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ILinfo {
        /// <summary>
        ///     The image's id.
        /// </summary>
        int Id;
        /// <summary>
        ///     The image's data.
        /// </summary>
        // TODO: Was ILbyte*, confirm whether it should be array or IntPtr
        byte[] Data;
        /// <summary>
        ///     The image's width.
        /// </summary>
        int Width;
        /// <summary>
        ///     The image's height.
        /// </summary>
        int Height;
        /// <summary>
        ///     The image's depth.
        /// </summary>
        int Depth;
        /// <summary>
        ///     Bytes per pixel (not bits) of the image.
        /// </summary>
        byte Bpp;
        /// <summary>
        ///     The total size of the data (in bytes).
        /// </summary>
        int SizeOfData;
        /// <summary>
        ///     Image format (in IL enum style).
        /// </summary>
        int Format;
        /// <summary>
        ///     Image type (in IL enum style).
        /// </summary>
        int Type;
        /// <summary>
        ///     Origin of the image.
        /// </summary>
        int Origin;
        /// <summary>
        ///     The image's palette
        /// </summary>
        // TODO: Was ILbyte*, confirm whether it should be array or IntPtr
        byte[] Palette;
        /// <summary>
        ///     Palette type.
        /// </summary>
        int PalType;
        /// <summary>
        ///     Palette size.
        /// </summary>
        int PalSize;
        /// <summary>
        ///     Flags for what cube map sides are present.
        /// </summary>
        int CubeFlags;
        /// <summary>
        ///     Number of images following.
        /// </summary>
        int NumNext;
        /// <summary>
        ///     Number of mipmaps.
        /// </summary>
        int NumMips;
        /// <summary>
        ///     Number of layers.
        /// </summary>
        int NumLayers;
    }

    /// <summary>
    ///     
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ILpointf {
        float x, y;
    }

    /// <summary>
    ///     
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ILpointi {
        int x, y;
    }
    #endregion Public Structs
}
