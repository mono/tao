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
    public static class Ilut
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
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_VERSION_1_6_8 = 1;
        // #define ILUT_VERSION       168
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_VERSION = 168;
        // #define ILUT_OPENGL_BIT      0x00000001
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_OPENGL_BIT = 0x00000001;
        // #define ILUT_D3D_BIT         0x00000002
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_D3D_BIT = 0x00000002;
        // #define ILUT_ALL_ATTRIB_BITS 0x000FFFFF
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_ALL_ATTRIB_BITS = 0x000FFFFF;
        /// <summary>
        /// An unacceptable enumerated value was passed to a function.
        /// </summary>
        // #define ILUT_INVALID_ENUM        0x0501
        public const int ILUT_INVALID_ENUM = 0x0501;
        /// <summary>
        /// Could not allocate enough memory in an operation.
        /// </summary>
        // #define ILUT_OUT_OF_MEMORY       0x0502
        public const int ILUT_OUT_OF_MEMORY = 0x0502;
        /// <summary>
        /// An invalid value was passed to a function or was in a file.
        /// </summary>
        // #define ILUT_INVALID_VALUE       0x0505
        public const int ILUT_INVALID_VALUE = 0x0505;
        /// <summary>
        /// The operation attempted is not allowable in the current state. The function returns with no ill side effects.
        /// </summary>
        // #define ILUT_ILLEGAL_OPERATION   0x0506
        public const int ILUT_ILLEGAL_OPERATION = 0x0506;
        /// <summary>
        /// An invalid parameter was passed to a function, such as a NULL pointer.
        /// </summary>
        // #define ILUT_INVALID_PARAM       0x0509
        public const int ILUT_INVALID_PARAM = 0x0509;
        /// <summary>
        /// Could not open the file specified. The file may already be open by another app or may not exist.
        /// </summary>
        // #define ILUT_COULD_NOT_OPEN_FILE 0x050A
        public const int ILUT_COULD_NOT_OPEN_FILE = 0x050A;
        /// <summary>
        /// One of the internal stacks was already filled, and the user tried to add on to the full stack.
        /// </summary>
        // #define ILUT_STACK_OVERFLOW      0x050E
        public const int ILUT_STACK_OVERFLOW = 0x050E;
        /// <summary>
        /// One of the internal stacks was empty, and the user tried to empty the already empty stack.
        /// </summary>
        // #define ILUT_STACK_UNDERFLOW     0x050F
        public const int ILUT_STACK_UNDERFLOW = 0x050F;
        // #define ILUT_BAD_DIMENSIONS      0x0511
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_BAD_DIMENSIONS = 0x0511;
        /// <summary>
        /// A type is valid but not supported in the current build.
        /// </summary>
        // #define ILUT_NOT_SUPPORTED       0x0550
        public const int ILUT_NOT_SUPPORTED = 0x0550;
        /// <summary>
        /// Whether ilut uses palettes or converts the image to truecolour before sending it to the renderer.
        /// </summary>
        // #define ILUT_PALETTE_MODE         0x0600
        public const int ILUT_PALETTE_MODE = 0x0600;
        /// <summary>
        /// Whether to use GL_RGB8 or GL_RGB, etc. when passing data to OpenGL only.
        /// </summary>
        // #define ILUT_OPENGL_CONV          0x0610
        public const int ILUT_OPENGL_CONV = 0x0610;
        // #define ILUT_D3D_MIPLEVELS        0x0620
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_D3D_MIPLEVELS = 0x0620;
        // #define ILUT_MAXTEX_WIDTH         0x0630
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_MAXTEX_WIDTH = 0x0630;
        // #define ILUT_MAXTEX_HEIGHT        0x0631
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_MAXTEX_HEIGHT = 0x0631;
        // #define ILUT_MAXTEX_DEPTH         0x0632
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_MAXTEX_DEPTH = 0x0632;
        // #define ILUT_GL_USE_S3TC          0x0634
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_GL_USE_S3TC = 0x0634;
        // #define ILUT_D3D_USE_DXTC         0x0634
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_D3D_USE_DXTC = 0x0634;
        // #define ILUT_GL_GEN_S3TC          0x0635
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_GL_GEN_S3TC = 0x0635;
        // #define ILUT_D3D_GEN_DXTC         0x0635
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_D3D_GEN_DXTC = 0x0635;
        // #define ILUT_S3TC_FORMAT          0x0705
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_S3TC_FORMAT = 0x0705;
        // #define ILUT_DXTC_FORMAT          0x0705
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_DXTC_FORMAT = 0x0705;
        // #define ILUT_D3D_POOL             0x0706
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_D3D_POOL = 0x0706;
        // #define ILUT_D3D_ALPHA_KEY_COLOR  0x0707
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_D3D_ALPHA_KEY_COLOR = 0x0707;
        // #define ILUT_D3D_ALPHA_KEY_COLOUR 0x0707
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_D3D_ALPHA_KEY_COLOUR = 0x0707;
        // #define ILUT_GL_AUTODETECT_TEXTURE_TARGET 0x0807
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_GL_AUTODETECT_TEXTURE_TARGET = 0x0807;
        /// <summary>
        /// Returns the version number of the shared library. This can be checked against the ILUT_VERSION #define
        /// </summary>
        // #define ILUT_VERSION_NUM IL_VERSION_NUM
        public const int ILUT_VERSION_NUM = Il.IL_VERSION_NUM;
        // #define ILUT_VENDOR      IL_VENDOR
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_VENDOR = Il.IL_VENDOR;
        // #define ILUT_OPENGL    0
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_OPENGL = 0;
        // #define ILUT_ALLEGRO   1
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_ALLEGRO = 1;
        // #define ILUT_WIN32     2
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_WIN32 = 2;
        // #define ILUT_DIRECT3D8 3
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_DIRECT3D8 = 3;
        // #define	ILUT_DIRECT3D9 4
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_DIRECT3D9 = 4;

        #endregion Public Constants

        #region Externs
        
        // ILAPI ILboolean		ILAPIENTRY ilutDisable(ILenum Mode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Mode"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutDisable(ILenum Mode);

        // ILAPI ILboolean		ILAPIENTRY ilutEnable(ILenum Mode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Mode"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutEnable(ILenum Mode);

        // ILAPI ILboolean		ILAPIENTRY ilutGetBoolean(ILenum Mode);
        /// <summary>
        /// The ilutGetBooleanv return the value of a selected mode.
        /// </summary>
        /// <param name="Mode">The selected mode.</param>
        /// <returns>The ilutGetBoolean returns the value of a selected mode.</returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGetBoolean(ILenum Mode);

        /// <summary>
        /// The ilutGetBoolean return the value of a selected mode.
        /// </summary>
        /// <param name="Mode">The ilutGetBoolean returns the value of a selected mode.</param>
        /// <param name="Param">Used to store the return values.</param>
        // ILAPI ILvoid		ILAPIENTRY ilutGetBooleanv(ILenum Mode, ILboolean *Param);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutGetBooleanv(ILenum Mode, ref byte Param);

        /// <summary>
        /// The ilutGetBoolean return the value of a selected mode.
        /// </summary>
        /// <param name="Mode">The ilutGetBoolean returns the value of a selected mode.</param>
        /// <param name="Param">Used to store the return values.</param>
        // ILAPI ILvoid		ILAPIENTRY ilutGetBooleanv(ILenum Mode, ILboolean *Param);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutGetBooleanv(ILenum Mode, [Out] byte[] Param);

        /// <summary>
        /// The ilutGetInteger return the value of a selected mode.
        /// </summary>
        /// <param name="Mode">The ilutGetBoolean returns the value of a selected mode.</param>
        /// <returns></returns>
        // ILAPI ILint			ILAPIENTRY ilutGetInteger(ILenum Mode);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILint ilutGetInteger(ILenum Mode);

        // ILAPI ILvoid		ILAPIENTRY ilutGetIntegerv(ILenum Mode, ILint *Param);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Mode"></param>
        /// <param name="Param"></param>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutGetIntegerv(ILenum Mode, out int Param);

        // ILAPI ILstring		ILAPIENTRY ilutGetString(ILenum StringName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StringName"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILstring ilutGetString(ILenum StringName);

        /// <summary>
        /// The ilutInit function initializes ILUT.
        /// </summary>
        // ILAPI ILvoid		ILAPIENTRY ilutInit(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutInit();

        /// <summary>
        /// ilutIsDisabled returns whether the mode indicated by Mode is disabled.
        /// </summary>
        /// <param name="Mode">Indicates an OpenIL mode</param>
        /// <returns></returns>
        // ILAPI ILboolean		ILAPIENTRY ilutIsDisabled(ILenum Mode);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutIsDisabled(ILenum Mode);

        /// <summary>
        /// ilutIsEnabled returns whether the mode indicated by Mode is enabled.
        /// </summary>
        /// <param name="Mode">Indicates an OpenIL mode</param>
        /// <returns></returns>
        // ILAPI ILboolean		ILAPIENTRY ilutIsEnabled(ILenum Mode);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutIsEnabled(ILenum Mode);

        /// <summary>
        /// ilutPopAttrib pops the last pushed stack entry off the stack and copies the bits specified when pushed by ilutPushAttrib to the previous set of states.
        /// </summary>
        // ILAPI ILvoid		ILAPIENTRY ilutPopAttrib(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutPopAttrib();

        
        // ILAPI ILvoid		ILAPIENTRY ilutPushAttrib(ILuint Bits);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Bits"></param>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutPushAttrib(ILenum Bits);

        // ILAPI ILvoid		ILAPIENTRY ilutSetInteger(ILenum Mode, ILint Param);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Mode"></param>
        /// <param name="Param"></param>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutSetInteger(ILenum Mode, int Param);

        // ILAPI ILboolean	ILAPIENTRY ilutRenderer(ILenum Renderer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Renderer"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutRenderer(ILenum Renderer);

        /// <summary>
        /// The ilutGLBindTexImage function binds an image to a generated OpenGL texture.
        /// </summary>
        /// <returns></returns>
        // 	ILAPI GLuint	ILAPIENTRY ilutGLBindTexImage();
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern GLuint ilutGLBindTexImage();

        /// <summary>
        /// The ilutGLBindMipmaps function binds an image to an OpenGL texture and creates mipmaps, generates a texture via glGenTextures, binds the current OpenIL image to it, generates mipmaps via gluBuild2DMipmaps and returns the texture name. This function is a more general purpose version of ilutOglBindTexImage.
        /// </summary>
        /// <returns></returns>
        // 	ILAPI GLuint	ILAPIENTRY ilutGLBindMipmaps(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern GLuint ilutGLBindMipmaps();

        /// <summary>
        /// ilutGLBuildMipmaps generates mipmaps via gluBuild2DMipmaps from an image. This function is similar to ilutGLTexImage but creates mipmaps.
        /// </summary>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutGLBuildMipmaps(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLBuildMipmaps();

        /// <summary>
        /// ilutGLLoadImage loads an image directly to an OpenGL texture, skipping the use of OpenIL image names.
        /// </summary>
        /// <param name="FileName">Name of the image to load</param>
        /// <returns></returns>
        // 	ILAPI GLuint	ILAPIENTRY ilutGLLoadImage(ILstring FileName);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern GLuint ilutGLLoadImage(ILstring FileName);

        /// <summary>
        /// ilutGLScreen copies the current OpenGL window contents to the current bound image, effectively taking a screenshot. The new image attributes are that of the current OpenGL window's.
        /// </summary>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutGLScreen(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLScreen();

        /// <summary>
        /// ilutGLScreen copies the current OpenGL window contents to a temporary image, effectively taking a screenshot. The screenshot image is then saved to disk as screen0.tga - screen127.tga (the lowest name it can find). This is just a convenience function that uses ilutGLScreen.
        /// </summary>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutGLScreenie(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLScreenie();

        // 	ILAPI ILboolean	ILAPIENTRY ilutGLSaveImage(ILstring FileName, GLuint TexID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="TexID"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLSaveImage(ILstring FileName, GLuint TexID);

        // 	ILAPI ILboolean	ILAPIENTRY ilutGLSetTex(GLuint TexID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TexID"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLSetTex(GLuint TexID);

        /// <summary>
        /// The ilutGLTexImage function binds an image to an OpenGL texture, simply calls glTexImage2D with the current bound image's data and attributes.
        /// </summary>
        /// <param name="Level">Texture level to place the image at. 0 is the base image level, and anything lower is a mipmap. Use ilActiveMipmap to access OpenIL's mipmaps.</param>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutGLTexImage(GLuint Level);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLTexImage(GLuint Level);

        // 	ILAPI ILboolean ILAPIENTRY ilutGLSubTex(GLuint TexID, ILuint XOff, ILuint YOff);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TexID"></param>
        /// <param name="XOff"></param>
        /// <param name="YOff"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGLSubTex(GLuint TexID, ILuint XOff, ILuint YOff);

        // 	ILAPI BITMAP* ILAPIENTRY ilutAllegLoadImage(Lstring FileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutAllegLoadImage(Lstring FileName);

        // 	ILAPI BITMAP* ILAPIENTRY ilutConvertToAlleg(PALETTE Pal);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pal"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutConvertToAlleg(IntPtr Pal);

        // 	ILAPI struct SDL_Surface* ILAPIENTRY ilutConvertToSDLSurface(unsigned int flags);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutConvertToSDLSurface(ILenum flags);

        // 	ILAPI struct SDL_Surface* ILAPIENTRY ilutSDLSurfaceLoadImage(ILstring FileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutSDLSurfaceLoadImage(ILstring FileName);

        // 	ILAPI ILboolean    ILAPIENTRY ilutSDLSurfaceFromBitmap(struct SDL_Surface *Bitmap);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Bitmap"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutSDLSurfaceFromBitmap(IntPtr Bitmap);

        // 	ILAPI BBitmap ILAPIENTRY ilutConvertToBBitmap(ILvoid);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutConvertToBBitmap();

        /// <summary>
        /// ilutConvertToHBitmap creates a Windows bitmap handle (HBITMAP) copy of the current image, for direct use in Windows.
        /// </summary>
        /// <param name="hDC">The ilutGetBoolean returns the value of a selected mode.</param>
        /// <returns></returns>
        // 	ILAPI HBITMAP	ILAPIENTRY ilutConvertToHBitmap(HDC hDC);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutConvertToHBitmap(IntPtr hDC);

        // 	ILAPI HBITMAP	ILAPIENTRY ilutConvertSliceToHBitmap(HDC hDC, ILuint slice);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hDC"></param>
        /// <param name="slice"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutConvertSliceToHBitmap(IntPtr hDC, ILenum slice);

        // 	ILAPI ILvoid	ILAPIENTRY ilutFreePaddedData(ILubyte *Data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutFreePaddedData(ILubyte[] Data);

        // 	ILAPI ILvoid	ILAPIENTRY ilutFreePaddedData(ILubyte *Data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutFreePaddedData(IntPtr Data);

        /// <summary>
        /// ilutGetBmpInfo fills a BITMAPINFO struct with the current image's information. The BITMAPINFO struct is used commonly used in Windows applications.
        /// </summary>
        /// <param name="Info">BITMAPINFO struct pointer to be filled.</param>
        // 	ILAPI ILvoid	ILAPIENTRY ilutGetBmpInfo(BITMAPINFO *Info);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void ilutGetBmpInfo(IntPtr Info);

        /// <summary>
        /// The ilutGetHPal function returns a Windows-friendly palette. If the current bound image has a palette, ilutGetHPal returns a Windows-compatible copy of the current image's palette in HPAL format.
        /// </summary>
        /// <returns></returns>
        // 	ILAPI HPALETTE	ILAPIENTRY ilutGetHPal(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutGetHPal();

        /// <summary>
        /// ilutGetPaddedData gets a copy of the current image's data, but pads it to be DWORD-aligned, just how Windows likes it. Almost all Windows functions that use images expect the images to be DWORD-aligned. The caller is responsible for freeing the memory returned by ilutGetPaddedData.
        /// </summary>
        /// <returns></returns>
        // 	ILAPI ILubyte*	ILAPIENTRY ilutGetPaddedData(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILubyte[] ilutGetPaddedData();

        /// <summary>
        /// ilutGetWinClipboard copies the contents of the Windows clipboard to the current bound image, resizing as necessary.
        /// </summary>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutGetWinClipboard(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutGetWinClipboard();

        // 	ILAPI ILboolean	ILAPIENTRY ilutLoadResource(HINSTANCE hInst, ILint ID, ILstring ResourceType, ILenum Type);
        /// <summary>
        /// ilutLoadResource is a Windows-specific function that loads a resource as the current bound image. This feature allows you to have images directly in your .exe and not worry whether a particular file is present on the user's harddrive. An alternative, more portable solution is to use ilSave with IL_CHEAD as the Type parameter.
        /// </summary>
        /// <param name="hInst">The application-s HINSTANCE</param>
        /// <param name="ID">The resource identifier of the resource to be loaded</param>
        /// <param name="ResourceType">The type of user-defined resource (name used when creating)</param>
        /// <param name="Type">The type of image to be loaded. Use IL_TYPE_UNKNOWN to let OpenIL determine the type</param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutLoadResource(IntPtr hInst, ILint ID, ILstring ResourceType, ILenum Type);

        /// <summary>
        /// ilutSetHBitmap copies Bitmap to the current bound image in a format OpenIL can understand. The image can then be used just as if you had loaded an image via ilLoadImage. This function is the opposite of ilutConvertToHBitmap.
        /// </summary>
        /// <param name="Bitmap">Bitmap to copy to the current bound image.</param>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutSetHBitmap(HBITMAP Bitmap);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutSetHBitmap(IntPtr Bitmap);

        /// <summary>
        /// ilutSetHPal sets the current iamge's palette from a logical Windows palette handle specified in Pal. If the current image is not colour-indexed, the palette is still loaded, though it will never be used.
        /// </summary>
        /// <param name="Pal">A Windows palette to set the palette from</param>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutSetHPal(HPALETTE Pal);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutSetHPal(IntPtr Pal);

        /// <summary>
        /// ilutSetWinClipboard copies the current bound image to the Windows clipboard.
        /// </summary>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutSetWinClipboard(ILvoid);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutSetWinClipboard();

        /// <summary>
        /// loads an image directly to a Win32 HBITMAP, skipping the use of OpenIL image names.
        /// </summary>
        /// <param name="FileName">Name of the image to load</param>
        /// <param name="hDC">Device context the bitmap should reside in</param>
        /// <returns></returns>
        // 	ILAPI HBITMAP	ILAPIENTRY ilutWinLoadImage(ILstring FileName, HDC hDC);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutWinLoadImage(ILstring FileName, IntPtr hDC);

        // 	ILAPI ILboolean	ILAPIENTRY ilutWinLoadUrl(ILstring Url);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutWinLoadUrl(ILstring Url);

        // 	ILAPI ILboolean ILAPIENTRY ilutWinPrint(ILuint XPos, ILuint YPos, ILuint Width, ILuint Height, HDC hDC);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="XPos"></param>
        /// <param name="YPos"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="hDC"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutWinPrint(ILuint XPos, ILuint YPos, ILuint Width, ILuint Height, IntPtr hDC);

        /// <summary>
        /// ilutWinSaveImage saves Bitmap to FileName. This function is the complement of ilutWinLoadImage.
        /// </summary>
        /// <param name="FileName">Name of the image file to save to</param>
        /// <param name="Bitmap">Win32 HBITMAP to save from</param>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutWinSaveImage(ILstring FileName, HBITMAP Bitmap);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutWinSaveImage(ILstring FileName, IntPtr Bitmap);

        // #endif//ILUT_USE_WIN32
        // 	ILAPI struct IDirect3DTexture8* ILAPIENTRY ilutD3D8Texture(struct IDirect3DDevice8 *Device);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutD3D8Texture(IntPtr Device);

        /// <summary>
        /// The ilutD3D8VolumeTexture function creates a Direct3D 8 texture (IDirect3DVolumeTexture8) from the current bound image.
        /// </summary>
        /// <param name="Device">Pointer to an IDirect3DDevice8 interface, representing the device to be associated with the texture.</param>
        /// <returns></returns>
        // 	ILAPI struct IDirect3DVolumeTexture8* ILAPIENTRY ilutD3D8VolumeTexture(struct IDirect3DDevice8 *Device);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutD3D8VolumeTexture(IntPtr Device);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8TexFromFile(struct IDirect3DDevice8 *Device, char *FileName, struct IDirect3DTexture8 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="FileName"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8TexFromFile(IntPtr Device, string FileName, IntPtr Texture);

        /// <summary>
        /// ilutD3D8VolTexFromFile loads the file named by FileName and converts it to a Direct3D 8 volume texture (IDirect3DVolumeTexture8). This function creates the texture, so the pointer does not even have to be allocated beforehand. This function is functionally equivalent to D3DX's D3DXCreateTextureFromFile but for a volume texture.
        /// </summary>
        /// <param name="Device">Pointer to an IDirect3DDevice8 interface, representing the device to be associated with the texture.</param>
        /// <param name="FileName">File to create the texture from.</param>
        /// <param name="Texture">Address of a pointer to an IDirect3DVolumeTexture8 interface, representing the created texture object.</param>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8VolTexFromFile(struct IDirect3DDevice8 *Device, char *FileName, struct IDirect3DVolumeTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8VolTexFromFile(IntPtr Device, string FileName, IntPtr Texture);

        /// <summary>
        /// ilutD3D8TexFromFileInMemory loads the file present in Lump and converts it to a Direct3D 8 texture (IDirect3DTexture8). This function creates the texture, so the pointer does not even have to be allocated beforehand. This function is functionally equivalent to D3DX's D3DXCreateTextureFromFileInMemory.
        /// </summary>
        /// <param name="Device">Pointer to an IDirect3DDevice8 interface, representing the device to be associated with the texture.</param>
        /// <param name="Lump">Location of memory file.</param>
        /// <param name="Size">Size of Lump in bytes</param>
        /// <param name="Texture">Address of a pointer to an IDirect3DTexture8 interface, representing the created texture object.</param>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8TexFromFileInMemory(struct IDirect3DDevice8 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8TexFromFileInMemory(IntPtr Device, IntPtr Lump, ILuint Size, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8VolTexFromFileInMemory(struct IDirect3DDevice8 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DVolumeTexture8 **Texture);
        /// <summary>
        /// ilutD3D8VolTexFromFileInMemory loads the file present in Lump and converts it to a Direct3D 8 volume texture (IDirect3DVolumeTexture8). This function creates the texture, so the pointer does not even have to be allocated beforehand. This function is functionally equivalent to D3DX's D3DXCreateTextureFromFileInMemory but for a volume texture.
        /// </summary>
        /// <param name="Device">Pointer to an IDirect3DDevice8 interface, representing the device to be associated with the texture.</param>
        /// <param name="Lump">Location of memory file.</param>
        /// <param name="Size">Size of Lump in bytes</param>
        /// <param name="Texture">Address of a pointer to an IDirect3DTexture8 interface, representing the created texture object.</param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8VolTexFromFileInMemory(IntPtr Device, IntPtr Lump, ILuint Size, IntPtr Texture);

        /// <summary>
        /// ilutD3D8TexFromFileInMemory loads the file present in Lump and converts it to a Direct3D 8 texture (IDirect3DTexture8). This function creates the texture, so the pointer does not even have to be allocated beforehand. This function is functionally equivalent to D3DX's D3DXCreateTextureFromFileInMemory.
        /// </summary>
        /// <param name="Device">Pointer to an IDirect3DDevice8 interface, representing the device to be associated with the texture.</param>
        /// <param name="Lump">Location of memory file.</param>
        /// <param name="Size">Size of Lump in bytes</param>
        /// <param name="Texture">Address of a pointer to an IDirect3DTexture8 interface, representing the created texture object.</param>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8TexFromFileInMemory(struct IDirect3DDevice8 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8TexFromFileInMemory(IntPtr Device, byte[] Lump, ILuint Size, IntPtr Texture);

        /// <summary>
        /// ilutD3D8VolTexFromFileInMemory loads the file present in Lump and converts it to a Direct3D 8 volume texture (IDirect3DVolumeTexture8). This function creates the texture, so the pointer does not even have to be allocated beforehand. This function is functionally equivalent to D3DX's D3DXCreateTextureFromFileInMemory but for a volume texture.
        /// </summary>
        /// <param name="Device">Pointer to an IDirect3DDevice8 interface, representing the device to be associated with the texture.</param>
        /// <param name="Lump">Location of memory file.</param>
        /// <param name="Size">Size of Lump in bytes</param>
        /// <param name="Texture">Address of a pointer to an IDirect3DTexture8 interface, representing the created texture object.</param>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8VolTexFromFileInMemory(struct IDirect3DDevice8 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DVolumeTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8VolTexFromFileInMemory(IntPtr Device, byte[] Lump, ILuint Size, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8TexFromFileHandle(struct IDirect3DDevice8 *Device, ILHANDLE File, struct IDirect3DTexture8 **Texture);
        /// <summary>
        /// ilutD3D8TexFromFileInMemory loads the file present in Lump and converts it to a Direct3D 8 texture (IDirect3DTexture8). This function creates the texture, so the pointer does not even have to be allocated beforehand. This function is functionally equivalent to D3DX's D3DXCreateTextureFromFile but with a file handle.
        /// </summary>
        /// <param name="Device">Pointer to an IDirect3DDevice8 interface, representing the device to be associated with the texture.</param>
        /// <param name="File">File handle containing the image file</param>
        /// <param name="Texture">Address of a pointer to an IDirect3DTexture8 interface, representing the created texture object.</param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8TexFromFileHandle(IntPtr Device, ILHANDLE File, IntPtr Texture);

        /// <summary>
        /// ilutD3D8VolTexFromFileHandle loads the file present in File and converts it to a Direct3D 8 volume texture (IDirect3DVolumeTexture8). This function creates the texture, so the pointer does not even have to be allocated beforehand. This function is functionally equivalent to D3DX's D3DXCreateTextureFromFile but with a file handle and a volume texture.
        /// </summary>
        /// <param name="Device">Pointer to an IDirect3DDevice8 interface, representing the device to be associated with the texture.</param>
        /// <param name="File">File handle containing the image file</param>
        /// <param name="Texture">Address of a pointer to an IDirect3DTexture8 interface, representing the created texture object.</param>
        /// <returns></returns>
        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D8VolTexFromFileHandle(struct IDirect3DDevice8 *Device, ILHANDLE File, struct IDirect3DVolumeTexture8 **Texture);
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8VolTexFromFileHandle(IntPtr Device, ILHANDLE File, IntPtr Texture);

        // 	ILAPI ILboolean ILAPIENTRY ilutD3D8TexFromResource(struct IDirect3DDevice8 *Device, HMODULE SrcModule, char *SrcResource, struct IDirect3DTexture8 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="SrcModule"></param>
        /// <param name="SrcResource"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8TexFromResource(IntPtr Device, IntPtr SrcModule, string SrcResource, IntPtr Texture);

        // 	ILAPI ILboolean ILAPIENTRY ilutD3D8VolTexFromResource(struct IDirect3DDevice8 *Device, HMODULE SrcModule, char *SrcResource, struct IDirect3DVolumeTexture8 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="SrcModule"></param>
        /// <param name="SrcResource"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8VolTexFromResource(IntPtr Device, IntPtr SrcModule, string SrcResource, IntPtr Texture);

        // 	ILAPI ILboolean ILAPIENTRY ilutD3D8LoadSurface(struct IDirect3DDevice8 *Device, struct IDirect3DSurface8 *Surface);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="Surface"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D8LoadSurface(IntPtr Device, IntPtr Surface);

        // 	ILAPI struct IDirect3DTexture9*       ILAPIENTRY ilutD3D9Texture       (struct IDirect3DDevice9* Device);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutD3D9Texture(IntPtr Device);

        // 	ILAPI struct IDirect3DVolumeTexture9* ILAPIENTRY ilutD3D9VolumeTexture (struct IDirect3DDevice9* Device);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutD3D9VolumeTexture(IntPtr Device);

        //     ILAPI struct IDirect3DCubeTexture9*       ILAPIENTRY ilutD3D9CubeTexture (struct IDirect3DDevice9* Device);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ilutD3D9CubeTexture(IntPtr Device);

        //     ILAPI ILboolean ILAPIENTRY ilutD3D9CubeTexFromFile(struct IDirect3DDevice9 *Device, char *FileName, struct IDirect3DCubeTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="FileName"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9CubeTexFromFile(IntPtr Device, string FileName, IntPtr Texture);

        //     ILAPI ILboolean ILAPIENTRY ilutD3D9CubeTexFromFileInMemory(struct IDirect3DDevice9 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DCubeTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="Lump"></param>
        /// <param name="Size"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9CubeTexFromFileInMemory(IntPtr Device, IntPtr Lump, ILuint Size, IntPtr Texture);

        //     ILAPI ILboolean ILAPIENTRY ilutD3D9CubeTexFromFileInMemory(struct IDirect3DDevice9 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DCubeTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="Lump"></param>
        /// <param name="Size"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9CubeTexFromFileInMemory(IntPtr Device, byte[] Lump, ILuint Size, IntPtr Texture);

        //     ILAPI ILboolean ILAPIENTRY ilutD3D9CubeTexFromFileHandle(struct IDirect3DDevice9 *Device, ILHANDLE File, struct IDirect3DCubeTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="File"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9CubeTexFromFileHandle(IntPtr Device, ILHANDLE File, IntPtr Texture);

        //     ILAPI ILboolean ILAPIENTRY ilutD3D9CubeTexFromResource(struct IDirect3DDevice9 *Device, HMODULE SrcModule, char *SrcResource, struct IDirect3DCubeTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="SrcModule"></param>
        /// <param name="SrcResource"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9CubeTexFromResource(IntPtr Device, IntPtr SrcModule, string SrcResource, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9TexFromFile(struct IDirect3DDevice9 *Device, char *FileName, struct IDirect3DTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="FileName"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9TexFromFile(IntPtr Device, string FileName, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9VolTexFromFile(struct IDirect3DDevice9 *Device, char *FileName, struct IDirect3DVolumeTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="FileName"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9VolTexFromFile(IntPtr Device, string FileName, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9TexFromFileInMemory(struct IDirect3DDevice9 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="Lump"></param>
        /// <param name="Size"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9TexFromFileInMemory(IntPtr Device, IntPtr Lump, ILuint Size, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9VolTexFromFileInMemory(struct IDirect3DDevice9 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DVolumeTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="Lump"></param>
        /// <param name="Size"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9VolTexFromFileInMemory(IntPtr Device, IntPtr Lump, ILuint Size, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9TexFromFileInMemory(struct IDirect3DDevice9 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="Lump"></param>
        /// <param name="Size"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9TexFromFileInMemory(IntPtr Device, byte[] Lump, ILuint Size, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9VolTexFromFileInMemory(struct IDirect3DDevice9 *Device, ILvoid *Lump, ILuint Size, struct IDirect3DVolumeTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="Lump"></param>
        /// <param name="Size"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9VolTexFromFileInMemory(IntPtr Device, byte[] Lump, ILuint Size, IntPtr Texture);
        
        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9TexFromFileHandle(struct IDirect3DDevice9 *Device, ILHANDLE File, struct IDirect3DTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="File"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9TexFromFileHandle(IntPtr Device, ILHANDLE File, IntPtr Texture);

        // 	ILAPI ILboolean	ILAPIENTRY ilutD3D9VolTexFromFileHandle(struct IDirect3DDevice9 *Device, ILHANDLE File, struct IDirect3DVolumeTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="File"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9VolTexFromFileHandle(IntPtr Device, ILHANDLE File, IntPtr Texture);

        // 	ILAPI ILboolean ILAPIENTRY ilutD3D9TexFromResource(struct IDirect3DDevice9 *Device, HMODULE SrcModule, char *SrcResource, struct IDirect3DTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="SrcModule"></param>
        /// <param name="SrcResource"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9TexFromResource(IntPtr Device, IntPtr SrcModule, string SrcResource, IntPtr Texture);

        // 	ILAPI ILboolean ILAPIENTRY ilutD3D9VolTexFromResource(struct IDirect3DDevice9 *Device, HMODULE SrcModule, char *SrcResource, struct IDirect3DVolumeTexture9 **Texture);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="SrcModule"></param>
        /// <param name="SrcResource"></param>
        /// <param name="Texture"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9VolTexFromResource(IntPtr Device, IntPtr SrcModule, string SrcResource, IntPtr Texture);

        // 	ILAPI ILboolean ILAPIENTRY ilutD3D9LoadSurface(struct IDirect3DDevice9 *Device, struct IDirect3DSurface9 *Surface);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="Surface"></param>
        /// <returns></returns>
        [DllImport(ILUT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern ILboolean ilutD3D9LoadSurface(IntPtr Device, IntPtr Surface);

        #endregion Externs
    }
}
