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
using GLuint = System.Int32;
using Lstring = System.String;
#endregion Aliases

namespace Tao.DevIl
{
    #region Class Documentation
    /// <summary>
    ///     DevIL (Developer's Image Library) ILUT binding for .NET.
    /// </summary>
    #endregion Class Documentation
    public sealed class Ilut
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
        #region string ILUT_NATIVE_LIBRARY
        /// <summary>
        /// Specifies the DevIL ILUT native library used in the bindings
        /// </summary>
        /// <remarks>
        /// The Windows dll is specified here universally - note that
        /// under Mono the non-windows native library can be mapped using
        /// the ".config" file mechanism.  Kudos to the Mono team for this
        /// simple yet elegant solution.
        /// </remarks>
        private const string ILUT_NATIVE_LIBRARY = "ILUT.dll";
        #endregion string ILUT_NATIVE_LIBRARY
        #endregion Private Constants

        #region Public Constants

        // #define ILUT_VERSION_1_6_8 1
        public const int ILUT_VERSION_1_6_8 = 1;
        // #define ILUT_VERSION       168
        public const int ILUT_VERSION = 168;
        // #define ILUT_OPENGL_BIT      0x00000001
        public const int ILUT_OPENGL_BIT = 0x00000001;
        // #define ILUT_D3D_BIT         0x00000002
        public const int ILUT_D3D_BIT = 0x00000002;
        // #define ILUT_ALL_ATTRIB_BITS 0x000FFFFF
        public const int ILUT_ALL_ATTRIB_BITS = 0x000FFFFF;
        // #define ILUT_INVALID_ENUM        0x0501
        public const int ILUT_INVALID_ENUM = 0x0501;
        // #define ILUT_OUT_OF_MEMORY       0x0502
        public const int ILUT_OUT_OF_MEMORY = 0x0502;
        // #define ILUT_INVALID_VALUE       0x0505
        public const int ILUT_INVALID_VALUE = 0x0505;
        // #define ILUT_ILLEGAL_OPERATION   0x0506
        public const int ILUT_ILLEGAL_OPERATION = 0x0506;
        // #define ILUT_INVALID_PARAM       0x0509
        public const int ILUT_INVALID_PARAM = 0x0509;
        // #define ILUT_COULD_NOT_OPEN_FILE 0x050A
        public const int ILUT_COULD_NOT_OPEN_FILE = 0x050A;
        // #define ILUT_STACK_OVERFLOW      0x050E
        public const int ILUT_STACK_OVERFLOW = 0x050E;
        // #define ILUT_STACK_UNDERFLOW     0x050F
        public const int ILUT_STACK_UNDERFLOW = 0x050F;
        // #define ILUT_BAD_DIMENSIONS      0x0511
        public const int ILUT_BAD_DIMENSIONS = 0x0511;
        // #define ILUT_NOT_SUPPORTED       0x0550
        public const int ILUT_NOT_SUPPORTED = 0x0550;
        // #define ILUT_PALETTE_MODE         0x0600
        public const int ILUT_PALETTE_MODE = 0x0600;
        // #define ILUT_OPENGL_CONV          0x0610
        public const int ILUT_OPENGL_CONV = 0x0610;
        // #define ILUT_D3D_MIPLEVELS        0x0620
        public const int ILUT_D3D_MIPLEVELS = 0x0620;
        // #define ILUT_MAXTEX_WIDTH         0x0630
        public const int ILUT_MAXTEX_WIDTH = 0x0630;
        // #define ILUT_MAXTEX_HEIGHT        0x0631
        public const int ILUT_MAXTEX_HEIGHT = 0x0631;
        // #define ILUT_MAXTEX_DEPTH         0x0632
        public const int ILUT_MAXTEX_DEPTH = 0x0632;
        // #define ILUT_GL_USE_S3TC          0x0634
        public const int ILUT_GL_USE_S3TC = 0x0634;
        // #define ILUT_D3D_USE_DXTC         0x0634
        public const int ILUT_D3D_USE_DXTC = 0x0634;
        // #define ILUT_GL_GEN_S3TC          0x0635
        public const int ILUT_GL_GEN_S3TC = 0x0635;
        // #define ILUT_D3D_GEN_DXTC         0x0635
        public const int ILUT_D3D_GEN_DXTC = 0x0635;
        // #define ILUT_S3TC_FORMAT          0x0705
        public const int ILUT_S3TC_FORMAT = 0x0705;
        // #define ILUT_DXTC_FORMAT          0x0705
        public const int ILUT_DXTC_FORMAT = 0x0705;
        // #define ILUT_D3D_POOL             0x0706
        public const int ILUT_D3D_POOL = 0x0706;
        // #define ILUT_D3D_ALPHA_KEY_COLOR  0x0707
        public const int ILUT_D3D_ALPHA_KEY_COLOR = 0x0707;
        // #define ILUT_D3D_ALPHA_KEY_COLOUR 0x0707
        public const int ILUT_D3D_ALPHA_KEY_COLOUR = 0x0707;
        // #define ILUT_GL_AUTODETECT_TEXTURE_TARGET 0x0807
        public const int ILUT_GL_AUTODETECT_TEXTURE_TARGET = 0x0807;
        // #define ILUT_VERSION_NUM IL_VERSION_NUM
        public const int ILUT_VERSION_NUM = Il.IL_VERSION_NUM;
        // #define ILUT_VENDOR      IL_VENDOR
        public const int ILUT_VENDOR = Il.IL_VENDOR;
        // #define ILUT_OPENGL    0
        public const int ILUT_OPENGL = 0;
        // #define ILUT_ALLEGRO   1
        public const int ILUT_ALLEGRO = 1;
        // #define ILUT_WIN32     2
        public const int ILUT_WIN32 = 2;
        // #define ILUT_DIRECT3D8 3
        public const int ILUT_DIRECT3D8 = 3;
        // #define	ILUT_DIRECT3D9 4
        public const int ILUT_DIRECT3D9 = 4;

        #endregion Public Constants

        #region Externs
        
        // ILAPI ILboolean		ILAPIENTRY ilutDisable(ILenum Mode);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutDisable(ILenum Mode);

        // ILAPI ILboolean		ILAPIENTRY ilutEnable(ILenum Mode);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutEnable(ILenum Mode);

        // ILAPI ILboolean		ILAPIENTRY ilutGetBoolean(ILenum Mode);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGetBoolean(ILenum Mode);

        // ILAPI ILvoid		ILAPIENTRY ilutGetBooleanv(ILenum Mode, ILboolean *Param);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutGetBooleanv(ILenum Mode, ref byte Param);

        // ILAPI ILint			ILAPIENTRY ilutGetInteger(ILenum Mode);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILint ilutGetInteger(ILenum Mode);

        // ILAPI ILvoid		ILAPIENTRY ilutGetIntegerv(ILenum Mode, ILint *Param);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutGetIntegerv(ILenum Mode, out int Param);

        // ILAPI ILstring		ILAPIENTRY ilutGetString(ILenum StringName);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILstring ilutGetString(ILenum StringName);

        // ILAPI ILvoid		ILAPIENTRY ilutInit(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutInit();

        // ILAPI ILboolean		ILAPIENTRY ilutIsDisabled(ILenum Mode);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutIsDisabled(ILenum Mode);

        // ILAPI ILboolean		ILAPIENTRY ilutIsEnabled(ILenum Mode);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutIsEnabled(ILenum Mode);

        // ILAPI ILvoid		ILAPIENTRY ilutPopAttrib(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutPopAttrib();

        // ILAPI ILvoid		ILAPIENTRY ilutPushAttrib(ILuint Bits);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutPushAttrib(ILenum Bits);

        // ILAPI ILvoid		ILAPIENTRY ilutSetInteger(ILenum Mode, ILint Param);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutSetInteger(ILenum Mode, int Param);

        // ILAPI ILboolean	ILAPIENTRY ilutRenderer(ILenum Renderer);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutRenderer(ILenum Renderer);

        // 	ILAPI GLuint	ILAPIENTRY ilutGLBindTexImage();
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern GLuint ilutGLBindTexImage();

        // 	ILAPI GLuint	ILAPIENTRY ilutGLBindMipmaps(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern GLuint ilutGLBindMipmaps();

        // 	ILAPI ILboolean	ILAPIENTRY ilutGLBuildMipmaps(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLBuildMipmaps();

        // 	ILAPI GLuint	ILAPIENTRY ilutGLLoadImage(ILstring FileName);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern GLuint ilutGLLoadImage(ILstring FileName);

        // 	ILAPI ILboolean	ILAPIENTRY ilutGLScreen(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLScreen();

        // 	ILAPI ILboolean	ILAPIENTRY ilutGLScreenie(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLScreenie();

        // 	ILAPI ILboolean	ILAPIENTRY ilutGLSaveImage(ILstring FileName, GLuint TexID);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLSaveImage(ILstring FileName, GLuint TexID);

        // 	ILAPI ILboolean	ILAPIENTRY ilutGLSetTex(GLuint TexID);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLSetTex(GLuint TexID);

        // 	ILAPI ILboolean	ILAPIENTRY ilutGLTexImage(GLuint Level);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLTexImage(GLuint Level);

        // 	ILAPI ILboolean ILAPIENTRY ilutGLSubTex(GLuint TexID, ILuint XOff, ILuint YOff);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLSubTex(GLuint TexID, ILuint XOff, ILuint YOff);

        // 	ILAPI BITMAP* ILAPIENTRY ilutAllegLoadImage(Lstring FileName);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutAllegLoadImage(Lstring FileName);

        // 	ILAPI BITMAP* ILAPIENTRY ilutConvertToAlleg(PALETTE Pal);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutConvertToAlleg(IntPtr Pal);

        // 	ILAPI struct SDL_Surface* ILAPIENTRY ilutConvertToSDLSurface(unsigned int flags);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutConvertToSDLSurface(ILenum flags);

        // 	ILAPI struct SDL_Surface* ILAPIENTRY ilutSDLSurfaceLoadImage(ILstring FileName);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutSDLSurfaceLoadImage(ILstring FileName);

        // 	ILAPI ILboolean    ILAPIENTRY ilutSDLSurfaceFromBitmap(struct SDL_Surface *Bitmap);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutSDLSurfaceFromBitmap(IntPtr Bitmap);

        // 	ILAPI BBitmap ILAPIENTRY ilutConvertToBBitmap(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutConvertToBBitmap();

        // 	ILAPI HBITMAP	ILAPIENTRY ilutConvertToHBitmap(HDC hDC);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutConvertToHBitmap(IntPtr hDC);

        // 	ILAPI HBITMAP	ILAPIENTRY ilutConvertSliceToHBitmap(HDC hDC, ILuint slice);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutConvertSliceToHBitmap(IntPtr hDC, ILenum slice);

        // 	ILAPI ILvoid	ILAPIENTRY ilutFreePaddedData(ILubyte *Data);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutFreePaddedData(ILubyte[] Data);

        // 	ILAPI ILvoid	ILAPIENTRY ilutFreePaddedData(ILubyte *Data);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutFreePaddedData(IntPtr Data);

        // 	ILAPI ILvoid	ILAPIENTRY ilutGetBmpInfo(BITMAPINFO *Info);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutGetBmpInfo(IntPtr Info);

        // 	ILAPI HPALETTE	ILAPIENTRY ilutGetHPal(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutGetHPal();

        // 	ILAPI ILubyte*	ILAPIENTRY ilutGetPaddedData(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILubyte[] ilutGetPaddedData();

        // 	ILAPI ILboolean	ILAPIENTRY ilutGetWinClipboard(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGetWinClipboard();

        // 	ILAPI ILboolean	ILAPIENTRY ilutLoadResource(HINSTANCE hInst, ILint ID, ILstring ResourceType, ILenum Type);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutLoadResource(IntPtr hInst, ILint ID, ILstring ResourceType, ILenum Type);

        // 	ILAPI ILboolean	ILAPIENTRY ilutSetHBitmap(HBITMAP Bitmap);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutSetHBitmap(IntPtr Bitmap);

        // 	ILAPI ILboolean	ILAPIENTRY ilutSetHPal(HPALETTE Pal);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutSetHPal(IntPtr Pal);

        // 	ILAPI ILboolean	ILAPIENTRY ilutSetWinClipboard(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutSetWinClipboard();

        // 	ILAPI HBITMAP	ILAPIENTRY ilutWinLoadImage(ILstring FileName, HDC hDC);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutWinLoadImage(ILstring FileName, IntPtr hDC);

        // 	ILAPI ILboolean	ILAPIENTRY ilutWinLoadUrl(ILstring Url);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutWinLoadUrl(ILstring Url);

        // 	ILAPI ILboolean ILAPIENTRY ilutWinPrint(ILuint XPos, ILuint YPos, ILuint Width, ILuint Height, HDC hDC);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutWinPrint(ILuint XPos, ILuint YPos, ILuint Width, ILuint Height, IntPtr hDC);

        // 	ILAPI ILboolean	ILAPIENTRY ilutWinSaveImage(ILstring FileName, HBITMAP Bitmap);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutWinSaveImage(ILstring FileName, IntPtr Bitmap);

        // #endif//ILUT_USE_WIN32
        // 	ILAPI struct IDirect3DTexture8* ILAPIENTRY ilutD3D8Texture(struct IDirect3DDevice8 *Device);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutD3D8Texture(IntPtr Device);

        // 	ILAPI struct IDirect3DVolumeTexture8* ILAPIENTRY ilutD3D8VolumeTexture(struct IDirect3DDevice8 *Device);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutD3D8VolumeTexture(IntPtr Device);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8TexFromFile(struct IDirect3DDevice8 *Device, char *FileName, struct IDirect3DTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8TexFromFile(IntPtr Device, string FileName, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8VolTexFromFile(struct IDirect3DDevice8 *Device, char *FileName, struct IDirect3DVolumeTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8VolTexFromFile(IntPtr Device, string FileName, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8TexFromFileInMemory(struct IDirect3DDevice8 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8TexFromFileInMemory(IntPtr Device, IntPtr Lump, ILuint Size, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8VolTexFromFileInMemory(struct IDirect3DDevice8 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DVolumeTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8VolTexFromFileInMemory(IntPtr Device, IntPtr Lump, ILuint Size, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8TexFromFileInMemory(struct IDirect3DDevice8 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8TexFromFileInMemory(IntPtr Device, byte[] Lump, ILuint Size, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8VolTexFromFileInMemory(struct IDirect3DDevice8 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DVolumeTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8VolTexFromFileInMemory(IntPtr Device, byte[] Lump, ILuint Size, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8TexFromFileHandle(struct IDirect3DDevice8 *Device, ILHANDLE File, struct IDirect3DTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8TexFromFileHandle(IntPtr Device, ILHANDLE File, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8VolTexFromFileHandle(struct IDirect3DDevice8 *Device, ILHANDLE File, struct IDirect3DVolumeTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8VolTexFromFileHandle(IntPtr Device, ILHANDLE File, IntPtr Texture);

        // 	ILAPI ILboolean ILAPIENTRY ilutD3D8TexFromResource(struct IDirect3DDevice8 *Device, HMODULE SrcModule, char *SrcResource, struct IDirect3DTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8TexFromResource(IntPtr Device, IntPtr SrcModule, string SrcResource, IntPtr Texture);

        // 	ILAPI ILboolean ILAPIENTRY ilutD3D8VolTexFromResource(struct IDirect3DDevice8 *Device, HMODULE SrcModule, char *SrcResource, struct IDirect3DVolumeTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8VolTexFromResource(IntPtr Device, IntPtr SrcModule, string SrcResource, IntPtr Texture);

        // 	ILAPI ILboolean ILAPIENTRY ilutD3D8LoadSurface(struct IDirect3DDevice8 *Device, struct IDirect3DSurface8 *Surface);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8LoadSurface(IntPtr Device, IntPtr Surface);

        // 	ILAPI struct IDirect3DTexture9*       ILAPIENTRY ilutD3D9Texture       (struct IDirect3DDevice9* Device);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutD3D9Texture(IntPtr Device);

        // 	ILAPI struct IDirect3DVolumeTexture9* ILAPIENTRY ilutD3D9VolumeTexture (struct IDirect3DDevice9* Device);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutD3D9VolumeTexture(IntPtr Device);

        //     ILAPI struct IDirect3DCubeTexture9*       ILAPIENTRY ilutD3D9CubeTexture (struct IDirect3DDevice9* Device);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutD3D9CubeTexture(IntPtr Device);

        //     ILAPI ILboolean ILAPIENTRY ilutD3D9CubeTexFromFile(struct IDirect3DDevice9 *Device, char *FileName, struct IDirect3DCubeTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9CubeTexFromFile(IntPtr Device, string FileName, IntPtr Texture);

        //     ILAPI ILboolean ILAPIENTRY ilutD3D9CubeTexFromFileInMemory(struct IDirect3DDevice9 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DCubeTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9CubeTexFromFileInMemory(IntPtr Device, IntPtr Lump, ILuint Size, IntPtr Texture);

        //     ILAPI ILboolean ILAPIENTRY ilutD3D9CubeTexFromFileInMemory(struct IDirect3DDevice9 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DCubeTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9CubeTexFromFileInMemory(IntPtr Device, byte[] Lump, ILuint Size, IntPtr Texture);

        //     ILAPI ILboolean ILAPIENTRY ilutD3D9CubeTexFromFileHandle(struct IDirect3DDevice9 *Device, ILHANDLE File, struct IDirect3DCubeTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9CubeTexFromFileHandle(IntPtr Device, ILHANDLE File, IntPtr Texture);

        //     ILAPI ILboolean ILAPIENTRY ilutD3D9CubeTexFromResource(struct IDirect3DDevice9 *Device, HMODULE SrcModule, char *SrcResource, struct IDirect3DCubeTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9CubeTexFromResource(IntPtr Device, IntPtr SrcModule, string SrcResource, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9TexFromFile(struct IDirect3DDevice9 *Device, char *FileName, struct IDirect3DTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9TexFromFile(IntPtr Device, string FileName, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9VolTexFromFile(struct IDirect3DDevice9 *Device, char *FileName, struct IDirect3DVolumeTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9VolTexFromFile(IntPtr Device, string FileName, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9TexFromFileInMemory(struct IDirect3DDevice9 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9TexFromFileInMemory(IntPtr Device, IntPtr Lump, ILuint Size, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9VolTexFromFileInMemory(struct IDirect3DDevice9 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DVolumeTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9VolTexFromFileInMemory(IntPtr Device, IntPtr Lump, ILuint Size, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9TexFromFileInMemory(struct IDirect3DDevice9 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9TexFromFileInMemory(IntPtr Device, byte[] Lump, ILuint Size, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9VolTexFromFileInMemory(struct IDirect3DDevice9 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DVolumeTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9VolTexFromFileInMemory(IntPtr Device, byte[] Lump, ILuint Size, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9TexFromFileHandle(struct IDirect3DDevice9 *Device, ILHANDLE File, struct IDirect3DTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9TexFromFileHandle(IntPtr Device, ILHANDLE File, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9VolTexFromFileHandle(struct IDirect3DDevice9 *Device, ILHANDLE File, struct IDirect3DVolumeTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9VolTexFromFileHandle(IntPtr Device, ILHANDLE File, IntPtr Texture);

        // 	ILAPI ILboolean ILAPIENTRY ilutD3D9TexFromResource(struct IDirect3DDevice9 *Device, HMODULE SrcModule, char *SrcResource, struct IDirect3DTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9TexFromResource(IntPtr Device, IntPtr SrcModule, string SrcResource, IntPtr Texture);

        // 	ILAPI ILboolean ILAPIENTRY ilutD3D9VolTexFromResource(struct IDirect3DDevice9 *Device, HMODULE SrcModule, char *SrcResource, struct IDirect3DVolumeTexture9 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9VolTexFromResource(IntPtr Device, IntPtr SrcModule, string SrcResource, IntPtr Texture);

        // 	ILAPI ILboolean ILAPIENTRY ilutD3D9LoadSurface(struct IDirect3DDevice9 *Device, struct IDirect3DSurface9 *Surface);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9LoadSurface(IntPtr Device, IntPtr Surface);

        #endregion Externs
    }
}
