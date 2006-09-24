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
    ///     DevIL (Developer's Image Library) IL binding for .NET, implementing DevIL 1.6.8 RC2.
    /// </summary>
    #endregion Class Documentation
    public sealed class Il
    {
        // --- Fields ---
        #region Private Constants
        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.Winapi" />.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Winapi;
        #endregion CallingConvention CALLING_CONVENTION
        #region string DEVIL_NATIVE_LIBRARY
        /// <summary>
        /// Specifies the DevIL native library used in the bindings
        /// </summary>
        /// <remarks>
        /// The Windows dll is specified here universally - note that
        /// under Mono the non-windows native library can be mapped using
        /// the ".config" file mechanism.  Kudos to the Mono team for this
        /// simple yet elegant solution.
        /// </remarks>
        private const string DEVIL_NATIVE_LIBRARY = "DevIL.dll";
        #endregion string DEVIL_NATIVE_LIBRARY
        #endregion Private Constants

        #region Public Constants

        public const int IL_FALSE = 0;
        public const int IL_TRUE = 1;
        public const int IL_COLOUR_INDEX = 0x1900;
        public const int IL_COLOR_INDEX = 0x1900;
        public const int IL_RGB = 0x1907;
        public const int IL_RGBA = 0x1908;
        public const int IL_BGR = 0x80E0;
        public const int IL_BGRA = 0x80E1;
        public const int IL_LUMINANCE = 0x1909;
        public const int IL_LUMINANCE_ALPHA = 0x190A;
        public const int IL_BYTE = 0x1400;
        public const int IL_UNSIGNED_BYTE = 0x1401;
        public const int IL_SHORT = 0x1402;
        public const int IL_UNSIGNED_SHORT = 0x1403;
        public const int IL_INT = 0x1404;
        public const int IL_UNSIGNED_INT = 0x1405;
        public const int IL_FLOAT = 0x1406;
        public const int IL_DOUBLE = 0x140A;
        /// <summary>
        /// Describes the OpenIL vendor and should be used only with ilGetString
        /// </summary>
        public const int IL_VENDOR = 0x1F00;
        public const int IL_LOAD_EXT = 0x1F01;
        public const int IL_SAVE_EXT = 0x1F02;
        public const int IL_VERSION_1_6_8 = 1;
        /// <summary>
        /// Used to retrive a string describing the current OpenIL version.
        /// </summary>
        public const int IL_VERSION = 168;
        /// <summary>
        /// Preserves the origin state set by ilOriginFunc.
        /// </summary>
        public const int IL_ORIGIN_BIT = 0x00000001;
        /// <summary>
        /// Preserves whether OpenIL is allowed to overwrite files when saving (set by ilEnable, ilDisable).
        /// </summary>
        public const int IL_FILE_BIT = 0x00000002;
        /// <summary>
        /// d to truecolour images (set by <see cref="ilEnable"/>, <see cref="ilDisable"/>).
        /// </summary>
        public const int IL_PAL_BIT = 0x00000004;
        public const int IL_FORMAT_BIT = 0x00000008;
        public const int IL_TYPE_BIT = 0x00000010;
        public const int IL_COMPRESS_BIT = 0x00000020;
        public const int IL_LOADFAIL_BIT = 0x00000040;
        public const int IL_FORMAT_SPECIFIC_BIT = 0x00000080;
        /// <summary>
        /// Preserves all OpenIL states and attributes.
        /// </summary>
        public const int IL_ALL_ATTRIB_BITS = 0x000FFFFF;
        public const int IL_PAL_NONE = 0x0400;
        public const int IL_PAL_RGB24 = 0x0401;
        public const int IL_PAL_RGB32 = 0x0402;
        public const int IL_PAL_RGBA32 = 0x0403;
        public const int IL_PAL_BGR24 = 0x0404;
        public const int IL_PAL_BGR32 = 0x0405;
        public const int IL_PAL_BGRA32 = 0x0406;
        /// <summary>
        /// Tells OpenIL to try to determine the type of image present in FileName, File or Lump.
        /// </summary>
        public const int IL_TYPE_UNKNOWN = 0x0000;
        /// <summary>
        /// Microsoft bitmap .
        /// </summary>
        public const int IL_BMP = 0x0420;
        /// <summary>
        /// Dr. Halo .cut image.
        /// </summary>
        public const int IL_CUT = 0x0421;
        /// <summary>
        /// Doom texture.
        /// </summary>
        public const int IL_DOOM = 0x0422;
        /// <summary>
        /// Doom flat (floor).
        /// </summary>
        public const int IL_DOOM_FLAT = 0x0423;
        /// <summary>
        /// Microsoft icon (.ico).
        /// </summary>
        public const int IL_ICO = 0x0424;
        /// <summary>
        /// Jpeg.
        /// </summary>
        public const int IL_JPG = 0x0425;
        public const int IL_JFIF = 0x0425;
        public const int IL_LBM = 0x0426;
        /// <summary>
        /// Kodak PhotoCD image.
        /// </summary>
        public const int IL_PCD = 0x0427;
        /// <summary>
        ///  .pcx Image.
        /// </summary>
        public const int IL_PCX = 0x0428;
        /// <summary>
        /// Softimage Pic image.
        /// </summary>
        public const int IL_PIC = 0x0429;
        /// <summary>
        /// Portable Network Graphics (.png) image.
        /// </summary>
        public const int IL_PNG = 0x042A;
        /// <summary>
        /// Portable AnyMap (.pbm, .pgm or .ppm).
        /// </summary>
        public const int IL_PNM = 0x042B;
        /// <summary>
        /// SGI (.bw, .rgb, .rgba or .sgi).
        /// </summary>
        public const int IL_SGI = 0x042C;
        /// <summary>
        /// TrueVision Targa.
        /// </summary>
        public const int IL_TGA = 0x042D;
        /// <summary>
        /// TIFF (.tif or .tiff) image.
        /// </summary>
        public const int IL_TIF = 0x042E;
        /// <summary>
        /// C Header.
        /// </summary>
        public const int IL_CHEAD = 0x042F;
        /// <summary>
        /// Raw data with a 13-byte header.
        /// </summary>
        public const int IL_RAW = 0x0430;
        /// <summary>
        /// Half-Life model file (.mdl).
        /// </summary>
        public const int IL_MDL = 0x0431;
        /// <summary>
        /// Quake .wal texture.
        /// </summary>
        public const int IL_WAL = 0x0432;
        /// <summary>
        /// Homeworld image.
        /// </summary>
        public const int IL_LIF = 0x0434;
        /// <summary>
        /// Load a Multiple Network Graphics (.mng).
        /// </summary>
        public const int IL_MNG = 0x0435;
        public const int IL_JNG = 0x0435;
        /// <summary>
        /// Graphics Interchange Format file.
        /// </summary>
        public const int IL_GIF = 0x0436;
        /// <summary>
        /// DirectDraw Surface image.
        /// </summary>
        public const int IL_DDS = 0x0437;
        /// <summary>
        /// .dcx image.
        /// </summary>
        public const int IL_DCX = 0x0438;
        /// <summary>
        /// PhotoShop (.psd) file.
        /// </summary>
        public const int IL_PSD = 0x0439;
        public const int IL_EXIF = 0x043A;
        /// <summary>
        /// Paint Shop Pro file.
        /// </summary>
        public const int IL_PSP = 0x043B;
        /// <summary>
        /// Alias | Wavefront .pix file.
        /// </summary>
        public const int IL_PIX = 0x043C;
        /// <summary>
        /// Pxrar (.pxr) file.
        /// </summary>
        public const int IL_PXR = 0x043D;
        /// <summary>
        /// .xpm file.
        /// </summary>
        public const int IL_XPM = 0x043E;
        /// <summary>
        /// RADIANCE High Dynamic Range Image.
        /// </summary>
        public const int IL_HDR = 0x043F;
        /// <summary>
        /// Load the file into the current image's palette as a Paint Shop Pro (Jasc) palette.
        /// </summary>
        public const int IL_JASC_PAL = 0x0475;
        /// <summary>
        /// No detectable error has occured.
        /// </summary>
        public const int IL_NO_ERROR = 0x0000;
        /// <summary>
        /// An invalid value have been used, which was not part of the set of values that can be used. In the function documentation there should be a more specific descriptionanation.
        /// </summary>
        public const int IL_INVALID_ENUM = 0x0501;
        /// <summary>
        /// Could not allocate enough memory for the image data.
        /// </summary>
        public const int IL_OUT_OF_MEMORY = 0x0502;
        /// <summary>
        /// The format a function tried to use was not able to be used by that function.
        /// </summary>
        public const int IL_FORMAT_NOT_SUPPORTED = 0x0503;
        /// <summary>
        /// A serious error has occurred.
        /// </summary>
        public const int IL_INTERNAL_ERROR = 0x0504;
        /// <summary>
        /// An invalid value was passed to a function or was in a file.
        /// </summary>
        public const int IL_INVALID_VALUE = 0x0505;
        /// <summary>
        /// The operation attempted is not allowable in the current state. The function returns with no ill side effects. Generally there is currently no image bound or it has been deleted via ilDeleteImages. You should use ilGenImages and ilBindImage before calling the function.
        /// </summary>
        public const int IL_ILLEGAL_OPERATION = 0x0506;
        /// <summary>
        /// An illegal value was found in a file trying to be loaded.
        /// </summary>
        public const int IL_ILLEGAL_FILE_VALUE = 0x0507;
        /// <summary>
        ///  	s header was incorrect.
        /// </summary>
        public const int IL_INVALID_FILE_HEADER = 0x0508;
        /// <summary>
        /// An invalid value have been used, which was not part of the set of values that can be used. In the function documentation there should be a more specific descriptionanation.
        /// </summary>
        public const int IL_INVALID_PARAM = 0x0509;
        /// <summary>
        /// Could not open the file specified. The file may already be open by another app or may not exist.
        /// </summary>
        public const int IL_COULD_NOT_OPEN_FILE = 0x050A;
        /// <summary>
        /// The extension of the specified filename was not correct for the type of image-loading function.
        /// </summary>
        public const int IL_INVALID_EXTENSION = 0x050B;
        /// <summary>
        /// The filename specified already belongs to another file. To overwrite files by default read more at ilEnable function.
        /// </summary>
        public const int IL_FILE_ALREADY_EXISTS = 0x050C;
        /// <summary>
        /// Tried to convert an image from its format to the same format.
        /// </summary>
        public const int IL_OUT_FORMAT_SAME = 0x050D;
        /// <summary>
        /// One of the internal stacks was already filled, and the user tried to add on to the full stack.
        /// </summary>
        public const int IL_STACK_OVERFLOW = 0x050E;
        /// <summary>
        /// One of the internal stacks was empty, and the user tried to empty the already empty stack.
        /// </summary>
        public const int IL_STACK_UNDERFLOW = 0x050F;
        /// <summary>
        /// During a conversion destination format and/or dest type was an invalid identifier. In the function documentation there should be a more specific descriptionanation.
        /// </summary>
        public const int IL_INVALID_CONVERSION = 0x0510;
        public const int IL_BAD_DIMENSIONS = 0x0511;
        public const int IL_FILE_READ_ERROR = 0x0512;
        public const int IL_FILE_WRITE_ERROR = 0x0512;
        public const int IL_LIB_GIF_ERROR = 0x05E1;
        /// <summary>
        /// An error occurred in the libjpeg library.
        /// </summary>
        public const int IL_LIB_JPEG_ERROR = 0x05E2;
        /// <summary>
        /// An error occurred in the libpng library.
        /// </summary>
        public const int IL_LIB_PNG_ERROR = 0x05E3;
        public const int IL_LIB_TIFF_ERROR = 0x05E4;
        public const int IL_LIB_MNG_ERROR = 0x05E5;
        /// <summary>
        /// No function sets this yet, but it is possible (not probable) it may be used in the future.
        /// </summary>
        public const int IL_UNKNOWN_ERROR = 0x05FF;
        /// <summary>
        /// nabled, the origin is specified at an absolute position, and all images loaded or saved adhere to this set origin. For more information, check out ilOriginFunc.
        /// </summary>
        public const int IL_ORIGIN_SET = 0x0600;
        public const int IL_ORIGIN_LOWER_LEFT = 0x0601;
        public const int IL_ORIGIN_UPPER_LEFT = 0x0602;
        /// <summary>
        /// Returns the current origin position.
        /// </summary>
        public const int IL_ORIGIN_MODE = 0x0603;
        /// <summary>
        /// Returns whether all images loaded are converted to a specific format.
        /// </summary>
        public const int IL_FORMAT_SET = 0x0610;
        public const int IL_FORMAT_MODE = 0x0611;
        /// <summary>
        /// Returns whether all images loaded are converted to a specific type.
        /// </summary>
        public const int IL_TYPE_SET = 0x0612;
        /// <summary>
        /// Returns the type images are converted to upon loading.
        /// </summary>
        public const int IL_TYPE_MODE = 0x0613;
        public const int IL_FILE_OVERWRITE = 0x0620;
        /// <summary>
        /// Returns whether file overwriting when saving is enabled.
        /// </summary>
        public const int IL_FILE_MODE = 0x0621;
        /// <summary>
        /// d images to their base types, e.g. converting to a bgra image.
        /// </summary>
        public const int IL_CONV_PAL = 0x0630;
        public const int IL_DEFAULT_ON_FAIL = 0x0632;
        /// <summary>
        /// Returns whether OpenIL uses a key colour (not used yet).
        /// </summary>
        public const int IL_USE_KEY_COLOUR = 0x0635;
        /// <summary>
        /// Returns whether OpenIL uses a key colour (not used yet).
        /// </summary>
        public const int IL_USE_KEY_COLOR = 0x0635;
        public const int IL_SAVE_INTERLACED = 0x0639;
        public const int IL_INTERLACE_MODE = 0x063A;
        public const int IL_QUANTIZATION_MODE = 0x0640;
        public const int IL_WU_QUANT = 0x0641;
        public const int IL_NEU_QUANT = 0x0642;
        public const int IL_NEU_QUANT_SAMPLE = 0x0643;
        public const int IL_MAX_QUANT_INDEXS = 0x0644;
        /// <summary>
        /// Makes the target use a faster but more memory-intensive algorithm.
        /// </summary>
        public const int IL_FASTEST = 0x0660;
        /// <summary>
        /// Makes the target use less memory but a potentially slower algorithm.
        /// </summary>
        public const int IL_LESS_MEM = 0x0661;
        /// <summary>
        /// The client does not have a preference.
        /// </summary>
        public const int IL_DONT_CARE = 0x0662;
        /// <summary>
        /// Controls the memory used vs. speed tradeoff.
        /// </summary>
        public const int IL_MEM_SPEED_HINT = 0x0665;
        /// <summary>
        /// Specifies that OpenIL should use compression when saving, if possible.
        /// </summary>
        public const int IL_USE_COMPRESSION = 0x0666;
        /// <summary>
        /// Specifies that OpenIL should never use compression when saving.
        /// </summary>
        public const int IL_NO_COMPRESSION = 0x0667;
        /// <summary>
        /// Controls whether compression is used when saving images.
        /// </summary>
        public const int IL_COMPRESSION_HINT = 0x0668;
        public const int IL_SUB_NEXT = 0x0680;
        public const int IL_SUB_MIPMAP = 0x0681;
        public const int IL_SUB_LAYER = 0x0682;
        public const int IL_COMPRESS_MODE = 0x0700;
        public const int IL_COMPRESS_NONE = 0x0701;
        public const int IL_COMPRESS_RLE = 0x0702;
        public const int IL_COMPRESS_LZO = 0x0703;
        public const int IL_COMPRESS_ZLIB = 0x0704;
        public const int IL_TGA_CREATE_STAMP = 0x0710;
        public const int IL_JPG_QUALITY = 0x0711;
        public const int IL_PNG_INTERLACE = 0x0712;
        public const int IL_TGA_RLE = 0x0713;
        public const int IL_BMP_RLE = 0x0714;
        public const int IL_SGI_RLE = 0x0715;
        public const int IL_TGA_ID_STRING = 0x0717;
        public const int IL_TGA_AUTHNAME_STRING = 0x0718;
        public const int IL_TGA_AUTHCOMMENT_STRING = 0x0719;
        public const int IL_PNG_AUTHNAME_STRING = 0x071A;
        public const int IL_PNG_TITLE_STRING = 0x071B;
        public const int IL_PNG_DESCRIPTION_STRING = 0x071C;
        public const int IL_TIF_DESCRIPTION_STRING = 0x071D;
        public const int IL_TIF_HOSTCOMPUTER_STRING = 0x071E;
        public const int IL_TIF_DOCUMENTNAME_STRING = 0x071F;
        public const int IL_TIF_AUTHNAME_STRING = 0x0720;
        public const int IL_JPG_SAVE_FORMAT = 0x0721;
        public const int IL_CHEAD_HEADER_STRING = 0x0722;
        public const int IL_PCD_PICNUM = 0x0723;
        public const int IL_PNG_ALPHA_INDEX = 0x0724;
        public const int IL_DXTC_FORMAT = 0x0705;
        public const int IL_DXT1 = 0x0706;
        public const int IL_DXT2 = 0x0707;
        public const int IL_DXT3 = 0x0708;
        public const int IL_DXT4 = 0x0709;
        public const int IL_DXT5 = 0x070A;
        public const int IL_DXT_NO_COMP = 0x070B;
        public const int IL_KEEP_DXTC_DATA = 0x070C;
        public const int IL_DXTC_DATA_FORMAT = 0x070D;
        public const int IL_3DC = 0x070E;
        public const int IL_RXGB = 0x070F;
        public const int IL_ATI1N = 0x0710;
        public const int IL_CUBEMAP_POSITIVEX = 0x00000400;
        public const int IL_CUBEMAP_NEGATIVEX = 0x00000800;
        public const int IL_CUBEMAP_POSITIVEY = 0x00001000;
        public const int IL_CUBEMAP_NEGATIVEY = 0x00002000;
        public const int IL_CUBEMAP_POSITIVEZ = 0x00004000;
        public const int IL_CUBEMAP_NEGATIVEZ = 0x00008000;
        /// <summary>
        /// Returns the version number of the shared library. This can be checked against the IL_VERSION #define.
        /// </summary>
        public const int IL_VERSION_NUM = 0x0DE2;
        /// <summary>
        /// s width.
        /// </summary>
        public const int IL_IMAGE_WIDTH = 0x0DE4;
        /// <summary>
        /// s height.
        /// </summary>
        public const int IL_IMAGE_HEIGHT = 0x0DE5;
        public const int IL_IMAGE_DEPTH = 0x0DE6;
        public const int IL_IMAGE_SIZE_OF_DATA = 0x0DE7;
        public const int IL_IMAGE_BPP = 0x0DE8;
        /// <summary>
        /// s data.
        /// </summary>
        public const int IL_IMAGE_BYTES_PER_PIXEL = 0x0DE8;
        /// <summary>
        /// s data.
        /// </summary>
        public const int IL_IMAGE_BITS_PER_PIXEL = 0x0DE9;
        /// <summary>
        /// Returns the current image format.
        /// </summary>
        public const int IL_IMAGE_FORMAT = 0x0DEA;
        /// <summary>
        /// Returns the current images type.
        /// </summary>
        public const int IL_IMAGE_TYPE = 0x0DEB;
        /// <summary>
        /// Returns the palette type of the current image.
        /// </summary>
        public const int IL_PALETTE_TYPE = 0x0DEC;
        public const int IL_PALETTE_SIZE = 0x0DED;
        /// <summary>
        /// Returns the bytes per pixel of the current images palette.
        /// </summary>
        public const int IL_PALETTE_BPP = 0x0DEE;
        /// <summary>
        /// Returns the number of colours of the current images palette.
        /// </summary>
        public const int IL_PALETTE_NUM_COLS = 0x0DEF;
        public const int IL_PALETTE_BASE_TYPE = 0x0DF0;
        /// <summary>
        /// Returns the number of images in the current image animation chain.
        /// </summary>
        public const int IL_NUM_IMAGES = 0x0DF1;
        /// <summary>
        /// Returns the number of mipmaps of the current image.
        /// </summary>
        public const int IL_NUM_MIPMAPS = 0x0DF2;
        public const int IL_NUM_LAYERS = 0x0DF3;
        /// <summary>
        /// Returns the current image number.
        /// </summary>
        public const int IL_ACTIVE_IMAGE = 0x0DF4;
        /// <summary>
        /// Returns the current mipmap number.
        /// </summary>
        public const int IL_ACTIVE_MIPMAP = 0x0DF5;
        /// <summary>
        /// Returns the current layer number.
        /// </summary>
        public const int IL_ACTIVE_LAYER = 0x0DF6;
        /// <summary>
        /// Returns the current bound image name.
        /// </summary>
        public const int IL_CUR_IMAGE = 0x0DF7;
        public const int IL_IMAGE_DURATION = 0x0DF8;
        public const int IL_IMAGE_PLANESIZE = 0x0DF9;
        public const int IL_IMAGE_BPC = 0x0DFA;
        public const int IL_IMAGE_OFFX = 0x0DFB;
        public const int IL_IMAGE_OFFY = 0x0DFC;
        public const int IL_IMAGE_CUBEFLAGS = 0x0DFD;
        public const int IL_IMAGE_ORIGIN = 0x0DFE;
        public const int IL_IMAGE_CHANNELS = 0x0DFF;
        public const int IL_SEEK_SET = 0;
        public const int IL_SEEK_CUR = 1;
        public const int IL_SEEK_END = 2;
        public const int IL_EOF = -1;

        #endregion Public Constants

        #region Delegates

        // Callback functions for file reading
        //typedef ILvoid    (ILAPIENTRY *fCloseRProc)(ILHANDLE);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void fCloseRProc(ILHANDLE handle);
        //typedef ILboolean (ILAPIENTRY *fEofProc)   (ILHANDLE);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ILboolean fEofProc(ILHANDLE handle);
        //typedef ILint     (ILAPIENTRY *fGetcProc)  (ILHANDLE);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ILint fGetcProc(ILHANDLE handle);
        //typedef ILHANDLE  (ILAPIENTRY *fOpenRProc) (const ILstring);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ILHANDLE fOpenRProc(ILstring str);
        //typedef ILint     (ILAPIENTRY *fReadProc)  (void*, ILuint, ILuint, ILHANDLE);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ILint fReadProc(IntPtr ptr, ILuint a, ILuint b, ILHANDLE handle);
        //typedef ILint     (ILAPIENTRY *fSeekRProc) (ILHANDLE, ILint, ILint);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ILint fSeekRProc(ILHANDLE handle, ILint a, ILint b);
        //typedef ILint     (ILAPIENTRY *fTellRProc) (ILHANDLE);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ILint fTellRProc(ILHANDLE handle);

        // Callback functions for file writing
        //typedef ILvoid   (ILAPIENTRY *fCloseWProc)(ILHANDLE);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void fCloseWProc(ILHANDLE handle);
        //typedef ILHANDLE (ILAPIENTRY *fOpenWProc) (const ILstring);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ILHANDLE fOpenWProc(ILstring str);
        //typedef ILint    (ILAPIENTRY *fPutcProc)  (ILubyte, ILHANDLE);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ILint fPutcProc(ILubyte byt, ILHANDLE handle);
        //typedef ILint    (ILAPIENTRY *fSeekWProc) (ILHANDLE, ILint, ILint);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ILint fSeekWProc(ILHANDLE handle, ILint a, ILint b);
        //typedef ILint    (ILAPIENTRY *fTellWProc) (ILHANDLE);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ILint fTellWProc(ILHANDLE handle);
        //typedef ILint    (ILAPIENTRY *fWriteProc) (const void*, ILuint, ILuint, ILHANDLE);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ILint fWriteProc(IntPtr ptr, ILuint a, ILuint b, ILHANDLE handle);

        // Callback functions for allocation and deallocation
        //typedef ILvoid* (ILAPIENTRY *mAlloc)(ILuint);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void mAlloc(ILuint a);
        //typedef ILvoid  (ILAPIENTRY *mFree) (ILvoid*);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void mFree(IntPtr ptr);

        // Registered format procedures
        //typedef ILenum (ILAPIENTRY *IL_LOADPROC)(const ILstring);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ILenum IL_LOADPROC(ILstring str);
        //typedef ILenum (ILAPIENTRY *IL_SAVEPROC)(const ILstring);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ILenum IL_SAVEPROC(ILstring str);

        #endregion Delegates

        #region Externs

        // ImageLib Functions
        // ILAPI ILboolean ILAPIENTRY ilActiveImage(ILuint Number);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilActiveImage(ILuint Number);

        // ILAPI ILboolean ILAPIENTRY ilActiveLayer(ILuint Number);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilActiveLayer(ILuint Number);

        // ILAPI ILboolean ILAPIENTRY ilActiveMipmap(ILuint Number);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilActiveMipmap(ILuint Number);

        // ILAPI ILboolean ILAPIENTRY ilApplyPal(const ILstring FileName);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilApplyPal(ILstring FileName);

        // ILAPI ILboolean ILAPIENTRY ilApplyProfile(ILstring InProfile, ILstring OutProfile);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilApplyProfile(ILstring InProfile, ILstring OutProfile);

        // ILAPI ILvoid    ILAPIENTRY ilBindImage(ILuint Image);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilBindImage(ILuint Image);

        // ILAPI ILboolean ILAPIENTRY ilBlit(ILuint Source, ILint DestX, ILint DestY, ILint DestZ, ILuint SrcX, ILuint SrcY, ILuint SrcZ, ILuint Width, ILuint Height, ILuint Depth);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilBlit(ILuint Source, ILint DestX, ILint DestY, ILint DestZ, ILuint SrcX, ILuint SrcY, ILuint SrcZ, ILuint Width, ILuint Height, ILuint Depth);

        // ILAPI ILvoid    ILAPIENTRY ilClearColour(ILclampf Red, ILclampf Green, ILclampf Blue, ILclampf Alpha);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilClearColour(ILclampf Red, ILclampf Green, ILclampf Blue, ILclampf Alpha);

        // ILAPI ILboolean ILAPIENTRY ilClearImage(ILvoid);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilClearImage();

        // ILAPI ILuint    ILAPIENTRY ilCloneCurImage(ILvoid);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint ilCloneCurImage();

        // ILAPI ILboolean ILAPIENTRY ilCompressFunc(ILenum Mode);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilCompressFunc(ILenum Mode);

        // ILAPI ILboolean ILAPIENTRY ilConvertImage(ILenum DestFormat, ILenum DestType);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilConvertImage(ILenum DestFormat, ILenum DestType);

        // ILAPI ILboolean ILAPIENTRY ilConvertPal(ILenum DestFormat);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilConvertPal(ILenum DestFormat);

        // ILAPI ILboolean ILAPIENTRY ilCopyImage(ILuint Src);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilCopyImage(ILuint Src);

        // ILAPI ILuint    ILAPIENTRY ilCopyPixels(ILuint XOff, ILuint YOff, ILuint ZOff, ILuint Width, ILuint Height, ILuint Depth, ILenum Format, ILenum Type, ILvoid *Data);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint ilCopyPixels(ILuint XOff, ILuint YOff, ILuint ZOff, ILuint Width, ILuint Height, ILuint Depth, ILenum Format, ILenum Type, IntPtr Data);

        // ILAPI ILuint    ILAPIENTRY ilCreateSubImage(ILenum Type, ILuint Num);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint ilCreateSubImage(ILenum Type, ILuint Num);

        // ILAPI ILboolean ILAPIENTRY ilDefaultImage(ILvoid);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilDefaultImage();

        // ILAPI ILvoid    ILAPIENTRY ilDeleteImage(const ILuint Num);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilDeleteImage(ILuint Num);

        // ILAPI ILvoid    ILAPIENTRY ilDeleteImages(ILsizei Num, const ILuint *Images);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilDeleteImages(ILsizei Num, ref ILuint Images);

        // ILAPI ILvoid    ILAPIENTRY ilDeleteImages(ILsizei Num, const ILuint *Images);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilDeleteImages(ILsizei Num, ILuint[] Images);

        // ILAPI ILboolean ILAPIENTRY ilDisable(ILenum Mode);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilDisable(ILenum Mode);

        // ILAPI ILboolean ILAPIENTRY ilEnable(ILenum Mode);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilEnable(ILenum Mode);

        // ILAPI ILboolean ILAPIENTRY ilFormatFunc(ILenum Mode);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilFormatFunc(ILenum Mode);

        // ILAPI ILvoid    ILAPIENTRY ilGenImages(ILsizei Num, ILuint *Images);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilGenImages(ILsizei Num, out ILuint Images);


        // ILAPI ILvoid    ILAPIENTRY ilGenImages(ILsizei Num, ILuint *Images);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilGenImages(ILsizei Num, [Out] ILuint[] Images);

        // ILAPI ILint		ILAPIENTRY ilGenImage();
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILint ilGenImage();

        // ILAPI ILubyte*  ILAPIENTRY ilGetAlpha(ILenum Type);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilGetAlpha(ILenum Type);

        // ILAPI ILboolean ILAPIENTRY ilGetBoolean(ILenum Mode);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilGetBoolean(ILenum Mode);

        // ILAPI ILvoid    ILAPIENTRY ilGetBooleanv(ILenum Mode, ILboolean *Param);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilGetBooleanv(ILenum Mode, out ILboolean Param);

        // ILAPI ILubyte*  ILAPIENTRY ilGetData(ILvoid);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilGetData();

        // ILAPI ILuint    ILAPIENTRY ilGetDXTCData(ILvoid *Buffer, ILuint BufferSize, ILenum DXTCFormat);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint ilGetDXTCData(IntPtr Buffer, ILuint BufferSize, ILenum DXTCFormat);

        // ILAPI ILenum    ILAPIENTRY ilGetError(ILvoid);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILenum ilGetError();

        // ILAPI ILint     ILAPIENTRY ilGetInteger(ILenum Mode);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILint ilGetInteger(ILenum Mode);

        // ILAPI ILvoid    ILAPIENTRY ilGetIntegerv(ILenum Mode, ILint *Param);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilGetIntegerv(ILenum Mode, out ILint Param);

        // ILAPI ILvoid    ILAPIENTRY ilGetIntegerv(ILenum Mode, ILint *Param);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilGetIntegerv(ILenum Mode, [Out] ILint[] Param);

        // ILAPI ILuint    ILAPIENTRY ilGetLumpPos(ILvoid);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint ilGetLumpPos();

        // ILAPI ILubyte*  ILAPIENTRY ilGetPalette(ILvoid);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilGetPalette();

        // ILAPI ILstring  ILAPIENTRY ilGetString(ILenum StringName);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILstring ilGetString(ILenum StringName);

        // ILAPI ILvoid    ILAPIENTRY ilHint(ILenum Target, ILenum Mode);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilHint(ILenum Target, ILenum Mode);

        // ILAPI ILvoid    ILAPIENTRY ilInit(ILvoid);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilInit();

        // ILAPI ILboolean ILAPIENTRY ilIsDisabled(ILenum Mode);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilIsDisabled(ILenum Mode);

        // ILAPI ILboolean ILAPIENTRY ilIsEnabled(ILenum Mode);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilIsEnabled(ILenum Mode);

        // ILAPI ILboolean ILAPIENTRY ilIsImage(ILuint Image);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilIsImage(ILuint Image);

        // ILAPI ILboolean ILAPIENTRY ilIsValid(ILenum Type, ILstring FileName);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilIsValid(ILenum Type, ILstring FileName);

        // ILAPI ILboolean ILAPIENTRY ilIsValidF(ILenum Type, ILHANDLE File);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilIsValidF(ILenum Type, ILHANDLE File);

        // ILAPI ILboolean ILAPIENTRY ilIsValidL(ILenum Type, ILvoid *Lump, ILuint Size);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilIsValidL(ILenum Type, IntPtr Lump, ILuint Size);

        // ILAPI ILboolean ILAPIENTRY ilIsValidL(ILenum Type, ILvoid *Lump, ILuint Size);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilIsValidL(ILenum Type, byte[] Lump, ILuint Size);

        // ILAPI ILvoid    ILAPIENTRY ilKeyColour(ILclampf Red, ILclampf Green, ILclampf Blue, ILclampf Alpha);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilKeyColour(ILclampf Red, ILclampf Green, ILclampf Blue, ILclampf Alpha);

        // ILAPI ILboolean ILAPIENTRY ilLoad(ILenum Type, const ILstring FileName);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilLoad(ILenum Type, ILstring FileName);

        // ILAPI ILboolean ILAPIENTRY ilLoadF(ILenum Type, ILHANDLE File);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilLoadF(ILenum Type, ILHANDLE File);

        // ILAPI ILboolean ILAPIENTRY ilLoadImage(const ILstring FileName);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilLoadImage(ILstring FileName);

        // ILAPI ILboolean ILAPIENTRY ilLoadL(ILenum Type, const ILvoid *Lump, ILuint Size);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilLoadL(ILenum Type, IntPtr Lump, ILuint Size);

        // ILAPI ILboolean ILAPIENTRY ilLoadL(ILenum Type, const ILvoid *Lump, ILuint Size);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilLoadL(ILenum Type, byte[] Lump, ILuint Size);

        // ILAPI ILboolean ILAPIENTRY ilLoadPal(const ILstring FileName);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilLoadPal(ILstring FileName);

        // ILAPI ILvoid    ILAPIENTRY ilModAlpha( ILdouble AlphaValue );
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilModAlpha(ILdouble AlphaValue);

        // ILAPI ILboolean ILAPIENTRY ilOriginFunc(ILenum Mode);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern byte ilOriginFunc(ILenum Mode);

        // ILAPI ILboolean ILAPIENTRY ilOverlayImage(ILuint Source, ILint XCoord, ILint YCoord, ILint ZCoord);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilOverlayImage(ILuint Source, ILint XCoord, ILint YCoord, ILint ZCoord);

        // ILAPI ILvoid    ILAPIENTRY ilPopAttrib(ILvoid);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilPopAttrib();

        // ILAPI ILvoid    ILAPIENTRY ilPushAttrib(ILuint Bits);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilPushAttrib(ILuint Bits);

        // ILAPI ILvoid    ILAPIENTRY ilRegisterFormat(ILenum Format);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilRegisterFormat(ILenum Format);

        // ILAPI ILboolean ILAPIENTRY ilRegisterLoad(const ILstring Ext, IL_LOADPROC Load);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilRegisterLoad(ILstring Ext, IL_LOADPROC Load);

        // ILAPI ILboolean ILAPIENTRY ilRegisterMipNum(ILuint Num);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilRegisterMipNum(ILuint Num);

        // ILAPI ILboolean ILAPIENTRY ilRegisterNumImages(ILuint Num);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilRegisterNumImages(ILuint Num);

        // ILAPI ILvoid    ILAPIENTRY ilRegisterOrigin(ILenum Origin);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilRegisterOrigin(ILenum Origin);

        // ILAPI ILvoid    ILAPIENTRY ilRegisterPal(ILvoid *Pal, ILuint Size, ILenum Type);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilRegisterPal(IntPtr Pal, ILuint Size, ILenum Type);

        // ILAPI ILboolean ILAPIENTRY ilRegisterSave(const ILstring Ext, IL_SAVEPROC Save);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilRegisterSave(ILstring Ext, IL_SAVEPROC Save);

        // ILAPI ILvoid    ILAPIENTRY ilRegisterType(ILenum Type);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilRegisterType(ILenum Type);

        // ILAPI ILboolean ILAPIENTRY ilRemoveLoad(const ILstring Ext);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilRemoveLoad(ILstring Ext);

        // ILAPI ILboolean ILAPIENTRY ilRemoveSave(const ILstring Ext);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilRemoveSave(ILstring Ext);

        // ILAPI ILvoid    ILAPIENTRY ilResetMemory(ILvoid);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilResetMemory();

        // ILAPI ILvoid    ILAPIENTRY ilResetRead(ILvoid);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilResetRead();

        // ILAPI ILvoid    ILAPIENTRY ilResetWrite(ILvoid);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilResetWrite();

        // ILAPI ILboolean ILAPIENTRY ilSave(ILenum Type, ILstring FileName);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilSave(ILenum Type, ILstring FileName);

        // ILAPI ILuint    ILAPIENTRY ilSaveF(ILenum Type, ILHANDLE File);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint ilSaveF(ILenum Type, ILHANDLE File);

        // ILAPI ILboolean ILAPIENTRY ilSaveImage(const ILstring FileName);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilSaveImage(ILstring FileName);

        // ILAPI ILuint    ILAPIENTRY ilSaveL(ILenum Type, ILvoid *Lump, ILuint Size);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint ilSaveL(ILenum Type, IntPtr Lump, ILuint Size);

        // ILAPI ILuint    ILAPIENTRY ilSaveL(ILenum Type, ILvoid *Lump, ILuint Size);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILuint ilSaveL(ILenum Type, byte[] Lump, ILuint Size);

        // ILAPI ILboolean ILAPIENTRY ilSavePal(const ILstring FileName);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilSavePal(ILstring FileName);

        // ILAPI ILvoid    ILAPIENTRY ilSetAlpha( ILdouble AlphaValue );
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilSetAlpha(ILdouble AlphaValue);

        // ILAPI ILboolean ILAPIENTRY ilSetData(ILvoid *Data);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilSetData(IntPtr Data);

        // ILAPI ILboolean ILAPIENTRY ilSetDuration(ILuint Duration);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilSetDuration(ILuint Duration);

        // ILAPI ILvoid    ILAPIENTRY ilSetInteger(ILenum Mode, ILint Param);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilSetInteger(ILenum Mode, ILint Param);

        // ILAPI ILvoid    ILAPIENTRY ilSetMemory(mAlloc, mFree);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilSetMemory(mAlloc param0, mFree param1);

        // ILAPI ILvoid    ILAPIENTRY ilSetPixels(ILint XOff, ILint YOff, ILint ZOff, ILuint Width, ILuint Height, ILuint Depth, ILenum Format, ILenum Type, ILvoid *Data);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilSetPixels(ILint XOff, ILint YOff, ILint ZOff, ILuint Width, ILuint Height, ILuint Depth, ILuint Format, ILuint Type, IntPtr Data);

        // ILAPI ILvoid    ILAPIENTRY ilSetRead(fOpenRProc, fCloseRProc, fEofProc, fGetcProc, fReadProc, fSeekRProc, fTellRProc);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilSetRead(fOpenRProc param0, fCloseRProc param1, fEofProc param2, fGetcProc param3, fReadProc param4, fSeekRProc param5, fTellRProc param6);

        // ILAPI ILvoid    ILAPIENTRY ilSetString(ILenum Mode, const char *String);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilSetString(ILenum Mode, string str);

        // ILAPI ILvoid    ILAPIENTRY ilSetWrite(fOpenWProc, fCloseWProc, fPutcProc, fSeekWProc, fTellWProc, fWriteProc);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilSetWrite(fOpenWProc param0, fCloseWProc param1, fPutcProc param2, fSeekWProc param3, fTellWProc param4, fWriteProc param5);

        // ILAPI ILvoid    ILAPIENTRY ilShutDown(ILvoid);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilShutDown();

        // ILAPI ILboolean ILAPIENTRY ilTexImage(ILuint Width, ILuint Height, ILuint Depth, ILubyte numChannels, ILenum Format, ILenum Type, ILvoid *Data);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilTexImage(ILuint Width, ILuint Height, ILuint Depth, ILubyte numChannels, ILenum Format, ILenum Type, IntPtr Data);

        // ILAPI ILenum    ILAPIENTRY ilTypeFromExt(const ILstring FileName);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILenum ilTypeFromExt(ILstring FileName);

        // ILAPI ILboolean ILAPIENTRY ilTypeFunc(ILenum Mode);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilTypeFunc(ILenum Mode);

        // ILAPI ILboolean ILAPIENTRY ilLoadData(const ILstring FileName, ILuint Width, ILuint Height, ILuint Depth, ILubyte Bpp);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilLoadData(ILstring FileName, ILuint Width, ILuint Height, ILuint Depth, ILubyte Bpp);

        // ILAPI ILboolean ILAPIENTRY ilLoadDataF(ILHANDLE File, ILuint Width, ILuint Height, ILuint Depth, ILubyte Bpp);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilLoadDataF(ILHANDLE File, ILuint Width, ILuint Height, ILuint Depth, ILubyte Bpp);

        // ILAPI ILboolean ILAPIENTRY ilLoadDataL(ILvoid *Lump, ILuint Size, ILuint Width, ILuint Height, ILuint Depth, ILubyte Bpp);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilLoadDataL(IntPtr Lump, ILuint Size, ILuint Width, ILuint Height, ILuint Depth, ILubyte Bpp);

        // ILAPI ILboolean ILAPIENTRY ilLoadDataL(ILvoid *Lump, ILuint Size, ILuint Width, ILuint Height, ILuint Depth, ILubyte Bpp);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilLoadDataL(byte[] Lump, ILuint Size, ILuint Width, ILuint Height, ILuint Depth, ILubyte Bpp);

        // ILAPI ILboolean ILAPIENTRY ilSaveData(const ILstring FileName);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilSaveData(ILstring FileName);

        // ILAPI ILboolean ILAPIENTRY ilLoadFromJpegStruct(ILvoid* JpegDecompressorPtr);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilLoadFromJpegStruct(IntPtr JpegDecompressorPtr);

        // ILAPI ILboolean ILAPIENTRY ilSaveFromJpegStruct(ILvoid* JpegCompressorPtr);
        [DllImport(DEVIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilSaveFromJpegStruct(IntPtr JpegCompressorPtr);

        #endregion Externs
    }
}
