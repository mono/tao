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
    public static class Ilu
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
        /// <summary>
        /// A Parameter was invalid or out of range
        /// </summary>
        // #define ILU_INVALID_ENUM      0x0501
        public const int ILU_INVALID_ENUM = 0x0501;
        /// <summary>
        /// Could not allocate enough memory in an operation
        /// </summary>
        // #define ILU_OUT_OF_MEMORY     0x0502
        public const int ILU_OUT_OF_MEMORY = 0x0502;
        /// <summary>
        /// A serious error has occurred.
        /// </summary>
        // #define ILU_INTERNAL_ERROR    0x0504
        public const int ILU_INTERNAL_ERROR = 0x0504;
        /// <summary>
        /// An invalid value was passed to a function or was in a file
        /// </summary>
        // #define ILU_INVALID_VALUE     0x0505
        public const int ILU_INVALID_VALUE = 0x0505;
        /// <summary>
        /// 	The operation attempted is not allowable in the current state. The function returns with no ill side effects. Generally there is currently no image bound or it has been deleted via ilDeleteImages. You should use ilGenImages and ilBindImage before calling the function.
        /// </summary>
        // #define ILU_ILLEGAL_OPERATION 0x0506
        public const int ILU_ILLEGAL_OPERATION = 0x0506;
        /// <summary>
        /// A Parameter was invalid or out of range
        /// </summary>
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

        /// <summary>
        /// The story behind this function is actually sorta funny. I had been using a picture of me (contact me if you want it! =) as a test image, and I started working on some colour matrix filters. Well, my first attempt screwed-up, because I had changed the equations to accomodate my bgr image, but I transposed the equations entirely wrong. I got a really neat output, though, where I looked like an alien. =) I decided to keep the screw-up and placed it in iluAlienify. I can't say I've ever run across a filter like this before.
        /// </summary>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluAlienify(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluAlienify();

        /// <summary>
        /// iluBlurAvg blurs an image using an averaging convolution filter. The filter is applied up to Iter number of times, giving more of a blurring effect the higher Iter is.
        /// </summary>
        /// <param name="Iter">Number of iterations of blurring to perform.</param>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluBlurAvg(ILuint Iter);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluBlurAvg(ILuint Iter);

        /// <summary>
        /// iluBlurGaussian blurs an image using a Gaussian convolution filter, which usually gives better results than the filter used by iluBlurAvg. The filter is applied up to Iter number of times, giving more of a blurring effect the higher Iter is.
        /// </summary>
        /// <param name="Iter">Number of iterations of blurring to perform.</param>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluBlurGaussian(ILuint Iter);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluBlurGaussian(ILuint Iter);

        /// <summary>
        /// iluBuildMipmaps generates power-of-2 mipmaps for an image. If the image does not have power-of-2 dimensions, then the image is resized via iluScale. Mipmaps are then generated for the image, down to a 1x1 image. To use the mipmaps, see ilActiveMipmap.
        /// </summary>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluBuildMipmaps(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluBuildMipmaps();

        /// <summary>
        /// iluColoursUsed creates a copy of the image data, quicksorts it and counts the number of unique colours in the image. This value is returned without affecting the original image.
        /// </summary>
        /// <returns></returns>
        // ILAPI ILuint         ILAPIENTRY iluColoursUsed(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint iluColoursUsed();

        /// <summary>
        /// iluCompareImage compares the current image to the image having the name in Comp. If both images are identical, IL_TRUE is returned. IL_FALSE is returned if the images are not identical. The bound image before calling this function remains the bound image after calling ilCompareImage.
        /// </summary>
        /// <param name="Comp">The image to compare with.</param>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluCompareImage(ILuint Comp);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluCompareImage(ILuint Comp);

        /// <summary>
        /// iluContrast changes the contrast of an image by using interpolation and extrapolation. Common values for Contrast are in the range -0.5 to 1.7. Anything below 0.0 generates a negative of the image with varying contrast. 1.0 outputs the original image. 0.0 - 1.0 lowers the contrast of the image. 1.0 - 1.7 increases the contrast of the image. This effect is caused by interpolating (or extrapolating) the source image with a totally grey image.
        /// </summary>
        /// <param name="Contrast">The factor to contrast by</param>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluContrast(ILfloat Contrast);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluContrast(ILfloat Contrast);

        /// <summary>
        /// iluCrop "crops" the current image to new dimensions. The new image appears the same as the original, but portions of the image are clipped-off, depending on the values of the parameters of these functions. If XOff + Width, YOff + Height or ZOff + Depth is larger than the current image's dimensions, ILU_ILLEGAL_OPERATION is set. If ZOff is minus or equal to one the crop will be done only on 2 dimensions
        /// </summary>
        /// <param name="XOff">Number of pixels to skip in the x direction.</param>
        /// <param name="YOff">Number of pixels to skip in the y direction.</param>
        /// <param name="ZOff">Number of pixels to skip in the z direction.</param>
        /// <param name="Width">Number of pixels to preserve in the x direction.</param>
        /// <param name="Height">Number of pixels to preserve in the y direction.</param>
        /// <param name="Depth">Number of pixels to preserve in the z direction.</param>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluCrop(ILuint XOff, ILuint YOff, ILuint ZOff, ILuint Width, ILuint Height, ILuint Depth);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluCrop(ILuint XOff, ILuint YOff, ILuint ZOff, ILuint Width, ILuint Height, ILuint Depth);

        /// <summary>
        /// iluDeleteImage is a convenience function to delete a single image instead of calling ilDeleteImages
        /// </summary>
        /// <param name="Id">The image name to delete</param>
        // ILAPI ILvoid         ILAPIENTRY iluDeleteImage(ILuint Id);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void iluDeleteImage(ILuint Id);

        /// <summary>
        /// iluEdgeDetectP detects the edges in the current image by combining two convolution filters. The filters used are Prewitt filters.
        /// </summary>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluEdgeDetectE(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEdgeDetectE();

        /// <summary>
        /// iluEdgeDetectP detects the edges in the current image by combining two convolution filters. The filters used are Prewitt filters.
        /// </summary>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluEdgeDetectP(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEdgeDetectP();

        /// <summary>
        /// iluEdgeDetectS detects the edges in the current image by combining two convolution filters. The filters used are Sobel filters.
        /// </summary>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluEdgeDetectS(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEdgeDetectS();

        /// <summary>
        /// iluEmboss embosses an image, causing it to have a "relief" feel to it using a convolution filter:
        /// </summary>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluEmboss(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEmboss();

        /// <summary>
        /// iluEnlargeCanvas enlarges the canvas of the current image, clearing the background to the colour specified in ilClearColour. To control the placement of the image, use iluImageParameter
        /// </summary>
        /// <param name="Width">New image width - must be larger than the current image's width.</param>
        /// <param name="Height">New image height - must be larger than the current image's width.</param>
        /// <param name="Depth">New image depth - must be larger than the current image's width.</param>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluEnlargeCanvas(ILuint Width, ILuint Height, ILuint Depth);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEnlargeCanvas(ILuint Width, ILuint Height, ILuint Depth);

        // ILAPI ILboolean      ILAPIENTRY iluEnlargeImage(ILfloat XDim, ILfloat YDim, ILfloat ZDim);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEnlargeImage(ILfloat XDim, ILfloat YDim, ILfloat ZDim);

        // ILAPI ILboolean      ILAPIENTRY iluEqualize(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluEqualize();

        /// <summary>
        /// iluErrorString returns a human-readable string of the error in Error. This can be useful for displaying the human-readable error in your program to let the user know wtf just happened.
        /// </summary>
        /// <param name="Error">Enum that describes the string to be retrieved.</param>
        /// <returns></returns>
        // ILAPI ILstring 		 ILAPIENTRY iluErrorString(ILenum Error);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILstring iluErrorString(ILenum Error);

        // ILAPI ILboolean      ILAPIENTRY iluConvolution(ILint *matrix, ILint scale, ILint bias);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluConvolution(ILint[] matrix, ILint scale, ILint bias);

        /// <summary>
        /// iluFlipImage inverts an image over the x axis. The image will be upside-down after calling this function. If this function is called twice in succession, the image is restored to its original state. A version of this function in OpenIL is used throughout internally when loading images to correct images that would otherwise be upside-down. Using ilOriginFunc will essentially tell the library which way is up.
        /// </summary>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluFlipImage(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluFlipImage();

        /// <summary>
        /// reater than 1.0, the image is brightened. It uses interpolation so it's slower then iluGammaCorrectScale
        /// </summary>
        /// <param name="Gamma">Gamma correction.</param>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluGammaCorrect(ILfloat Gamma);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluGammaCorrect(ILfloat Gamma);

        /// <summary>
        /// iluGenImage is a convenience function to delete a single image instead of calling ilGenImages
        /// </summary>
        /// <returns></returns>
        // ILAPI ILuint         ILAPIENTRY iluGenImage(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint iluGenImage();

        /// <summary>
        /// The iluGetImageInfo function retrieves information about the current image in an ILinfo struct. This is useful when you are repeatedly calling ilGetInteger and is more efficient in this case.
        /// </summary>
        /// <param name="Info">ILinfo struct to receive the image information.</param>
        // ILAPI ILvoid         ILAPIENTRY iluGetImageInfo(ILinfo *Info);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void iluGetImageInfo(out ILinfo Info);

        /// <summary>
        /// The iluGetInteger function returns the value of a selected mode
        /// </summary>
        /// <param name="Mode">The mode value to be returned.</param>
        /// <returns></returns>
        // ILAPI ILint          ILAPIENTRY iluGetInteger(ILenum Mode);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILint iluGetInteger(ILenum Mode);

        /// <summary>
        /// The iluGetIntegerv function returns the mode value in the Param parameter.
        /// </summary>
        /// <param name="Mode">The mode value to be returned.</param>
        /// <param name="Param">When used, the value is stored here instead of returned..</param>
        // ILAPI ILvoid         ILAPIENTRY iluGetIntegerv(ILenum Mode, ILint *Param);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void iluGetIntegerv(ILenum Mode, out ILint Param);

        /// <summary>
        /// iluGetString returns a constant human-readable string describing the current OpenILU implementation.
        /// </summary>
        /// <param name="StringName">Enum that describes the string to be retrieved.</param>
        /// <returns></returns>
        // ILAPI ILstring 		 ILAPIENTRY iluGetString(ILenum StringName);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILstring iluGetString(ILenum StringName);

        /// <summary>
        /// iluImageParameter modifies the behaviour of some ilu functions. Right now, it controls the behaviour of iluEnlargeCanvas and iluScale. For ILU_FILTER, values for Param other than ILU_NEAREST, ILU_LINEAR and ILU_BILINEAR are higher-quality scaling filters and take longer to perform.
        /// </summary>
        /// <param name="PName">Parameter name</param>
        /// <param name="Param">Behaviour to use</param>
        // ILAPI ILvoid         ILAPIENTRY iluImageParameter(ILenum PName, ILenum Param);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void iluImageParameter(ILenum PName, ILenum Param);

        /// <summary>
        /// iluInit starts ILU and must be called prior to using ILU
        /// </summary>
        // ILAPI ILvoid         ILAPIENTRY iluInit(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void iluInit();

        /// <summary>
        /// iluInvertAlpha inverts the alpha of the currently bound image.
        /// </summary>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluInvertAlpha(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluInvertAlpha();

        // ILAPI ILuint         ILAPIENTRY iluLoadImage(const ILstring FileName);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint iluLoadImage(ILstring FileName);

        /// <summary>
        /// iluMirror mirrors an image across its y axis, making it appear backwards.
        /// </summary>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluMirror(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluMirror();

        /// <summary>
        /// iluNegative creates a negative version of an image, like it was viewed as a picture negative instead of the actual picture. The effect is caused by inverting the image's colours, such as a green pixel would become purple (red-blue).
        /// </summary>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluNegative(ILvoid);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluNegative();

        // ILAPI ILboolean      ILAPIENTRY iluNoisify(ILclampf Tolerance);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluNoisify(ILclampf Tolerance);

        /// <summary>
        /// iluPixelize performs the effect that can be seen on television, where people want their identity to remain anonymous, so the editors cover the person's face with a very blocky pixelized version. PixSize specifies how blocky the image should be, with 1 being the lowest blockiness (doesn't change the image).
        /// </summary>
        /// <param name="PixSize">New pixel size</param>
        /// <returns></returns>
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

        /// <summary>
        /// iluRotate simply rotates an image about the center by Angle degrees. The background where there is space left by the rotation will be set to the clear colour.
        /// </summary>
        /// <param name="Angle">Angle in degrees to rotate the image.</param>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluRotate(ILfloat Angle);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluRotate(ILfloat Angle);

        // ILAPI ILboolean      ILAPIENTRY iluRotate3D(ILfloat x, ILfloat y, ILfloat z, ILfloat Angle);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluRotate3D(ILfloat x, ILfloat y, ILfloat z, ILfloat Angle);

        /// <summary>
        /// iluSaturate1f applies a saturation consistent with the IL_LUMINANCE conversion values to red, green and blue.
        /// </summary>
        /// <param name="Saturation">Amount of saturation to apply to the current bound image. the value must go from -1.0 to 1.0</param>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluSaturate1f(ILfloat Saturation);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluSaturate1f(ILfloat Saturation);

        /// <summary>
        /// iluScaleColours scales the individual colour components of the current bound image. Using 1.0f as any of the parameters yields that colour component's original plane in the new image.
        /// </summary>
        /// <param name="r">Amount of red to use from the original image</param>
        /// <param name="g">Amount of green to use from the original image</param>
        /// <param name="b">Amount of blue to use from the original image</param>
        /// <param name="Saturation"></param>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluSaturate4f(ILfloat r, ILfloat g, ILfloat b, ILfloat Saturation);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluSaturate4f(ILfloat r, ILfloat g, ILfloat b, ILfloat Saturation);

        /// <summary>
        /// The iluScale function scales the image to the new dimensions specified, shrinking or enlarging the image, depending on the image's original dimensions. There are different filters that can be used to scale an image, and which filter to use can be specified via iluImageParameter.
        /// </summary>
        /// <param name="Width">New width of the image.</param>
        /// <param name="Height">New height of the image.</param>
        /// <param name="Depth">New depth of the image.</param>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluScale(ILuint Width, ILuint Height, ILuint Depth);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluScale(ILuint Width, ILuint Height, ILuint Depth);

        // ILAPI ILboolean      ILAPIENTRY iluScaleColours(ILfloat r, ILfloat g, ILfloat b);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluScaleColours(ILfloat r, ILfloat g, ILfloat b);

        /// <summary>
        /// iluSharpen can actually either sharpen or blur an image, depending on the value of Factor. iluBlurAvg and iluBlurGaussian are much faster for blurring, though. When Factor is 1.0, the image goes unchanged. When Factor is in the range 0.0 - 1.0, the current image is blurred. When Factor is in the range 1.0 - 2.5, the current image is sharpened. To achieve a more pronounced sharpening/blurring effect, simply increase the number of iterations by increasing the value passed in Iter.
        /// </summary>
        /// <param name="Factor">Factor to sharpen by.</param>
        /// <param name="Iter">Number of iterations to perform on the image.</param>
        /// <returns></returns>
        // ILAPI ILboolean      ILAPIENTRY iluSharpen(ILfloat Factor, ILuint Iter);
        [DllImport(ILU_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean iluSharpen(ILfloat Factor, ILuint Iter);

        /// <summary>
        /// iluSwapColours "swaps" the colour order of the current image. If the current image is in bgr(a) format, iluSwapColours will change the image to use rgb(a) format, or vice-versa. This can be helpful when you want to manipulate the image data yourself but only want to use a certain colour order. To determine the current colour order, call ilGetInteger with the IL_IMAGE_FORMAT parameter.
        /// </summary>
        /// <returns></returns>
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

    #region ILinfo
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
    #endregion ILinfo

    #region ILpointf
    // typedef struct ILpointf
    // {
    // 	ILfloat x, y;
    // } ILpointf;
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct ILpointf
    {
        public ILfloat x, y;
    };
    #endregion ILpointf

    #region ILpointi
    // typedef struct ILpointi
    // {
    // 	ILint x, y;
    // } ILpointi;
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct ILpointi
    {
        public ILint x, y;
    };
    #endregion ILpointi

    #endregion Public Structs
}
