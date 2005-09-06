#region License
/*
MIT License
Copyright ©2003-2005 Tao Framework Team
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
		#endregion Private Constants

		#region Public Constants
		#region Version
		#region ILUT_VERSION_1_6_7
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_VERSION_1_6_7 = 1;
		#endregion ILUT_VERSION_1_6_7

		#region ILUT_VERSION
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_VERSION = 167;
		#endregion ILUT_VERSION

		#region ILUT_VERSION_NUM
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_VERSION_NUM = Il.IL_VERSION_NUM;
		#endregion ILUT_VERSION_NUM

		#region ILUT_VENDOR
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_VENDOR = Il.IL_VENDOR;
		#endregion ILUT_VENDOR
		#endregion Version
        
		#region RenderingApis
		#region ILUT_OPENGL
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_OPENGL = 0; 
		#endregion ILUT_OPENGL
		#region ILUT_ALLEGRO
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_ALLEGRO = 1;
		#endregion ILUT_ALLEGRO
		#region ILUT_WIN32
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_WIN32 = 2;
		#endregion ILUT_WIN32
		#region ILUT_DIRECT3D8
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_DIRECT3D8	= 3;
		#endregion ILUT_DIRECT3D8
		#region ILUT_DIRECT3D9
		public const int ILUT_DIRECT3D9	= 4;
		#endregion
		#endregion RenderingApis
        
		#region AttributeBits
		#region ILUT_OPENGL_BIT
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_OPENGL_BIT = 0x00000001;
		#endregion ILUT_OPENGL_BIT
        
		#region ILUT_ALL_ATTRIB_BITS
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_ALL_ATTRIB_BITS = 0x000FFFFF;
		#endregion ILUT_ALL_ATTRIB_BITS
		#endregion AttributeBits
        
		#region ErrorTypes
		#region ILUT_INVALID_ENUM
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_INVALID_ENUM = 0x0501;
		#endregion ILUT_INVALID_ENUM
        
		#region ILUT_OUT_OF_MEMORY
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_OUT_OF_MEMORY = 0x0502;
		#endregion ILUT_OUT_OF_MEMORY
        
		#region ILUT_INVALID_VALUE
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_INVALID_VALUE = 0x0505;
		#endregion ILUT_INVALID_VALUE
        
		#region ILUT_ILLEGAL_OPERATION
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_ILLEGAL_OPERATION = 0x0506;
		#endregion ILUT_ILLEGAL_OPERATION
        
		#region ILUT_INVALID_PARAM
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_INVALID_PARAM = 0x0509;
		#endregion ILUT_INVALID_PARAM
        
		#region ILUT_COULD_NOT_OPEN_FILE
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_COULD_NOT_OPEN_FILE = 0x050A;
		#endregion ILUT_COULD_NOT_OPEN_FILE
        
		#region ILUT_STACK_OVERFLOW
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_STACK_OVERFLOW = 0x050E;
		#endregion ILUT_STACK_OVERFLOW
        
		#region ILUT_STACK_UNDERFLOW
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_STACK_UNDERFLOW = 0x050F;
		#endregion ILUT_STACK_UNDERFLOW
        
		#region ILUT_BAD_DIMENSIONS
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_BAD_DIMENSIONS = 0x0511;
		#endregion ILUT_BAD_DIMENSIONS
        
		#region ILUT_NOT_SUPPORTED
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_NOT_SUPPORTED = 0x0550;
		#endregion ILUT_NOT_SUPPORTED
		#endregion ErrorTypes
        
		#region StateDefinitions
		#region ILUT_PALETTE_MODE
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_PALETTE_MODE = 0x0600;
		#endregion ILUT_PALETTE_MODE
        
		#region ILUT_OPENGL_CONV
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_OPENGL_CONV = 0x0610;
		#endregion ILUT_OPENGL_CONV
        
		#region ILUT_MAXTEX_WIDTH
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_MAXTEX_WIDTH = 0x0630;
		#endregion ILUT_MAXTEX_WIDTH
        
		#region ILUT_MAXTEX_HEIGHT
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_MAXTEX_HEIGHT = 0x0631;
		#endregion ILUT_MAXTEX_HEIGHT
        
		#region ILUT_MAXTEX_DEPTH
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_MAXTEX_DEPTH = 0x0632;
		#endregion ILUT_MAXTEX_DEPTH
        
		#region ILUT_GL_USE_S3TC
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_GL_USE_S3TC = 0x0634;
		#endregion ILUT_GL_USE_S3TC
        
		#region ILUT_GL_GEN_S3TC
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_GL_GEN_S3TC = 0x0635;
		#endregion ILUT_GL_GEN_S3TC
        
		#region ILUT_S3TC_FORMAT
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_S3TC_FORMAT = 0x0705;
		#endregion ILUT_S3TC_FORMAT
        
		#region ILUT_GL_AUTODETECT_TEXTURE_TARGET
		/// <summary>
		/// 
		/// </summary>
		public const int ILUT_GL_AUTODETECT_TEXTURE_TARGET = 0x0807;
		#endregion ILUT_GL_AUTODETECT_TEXTURE_TARGET
		#endregion StateDefinitions
		#endregion Public Constants
        
		// --- Externs ---
		#region Externs
		#region int ilutRenderer(int Renderer);
		/// <summary>
		/// The <b>ilutRenderer</b> function initializes the renderer to use OpenILUT with.
		/// </summary>
		/// <param name="Renderer">Renderer enum of the renderer to switch to. Accepted values are: <see cref="ILUT_OPENGL"/>, <see cref="ILUT_ALLEGRO"/> and <see cref="ILUT_DIRECTX"/>.</param>
		/// <returns></returns>
		/// <remarks><b>ilutRenderer</b> switches the renderer OpenILUT uses and sets OpenILUT to use it. Note that the availability of these #define's is determined by whether their respective <see cref="ILUT_USE_X"/> #define is uncommented. For example, if <see cref="ILUT_USE_OPENGL"/> is undefined in ilut.h, <see cref="ILUT_OPENGL"/> will not be available.</remarks>  
		// ILAPI ILboolean ILAPIENTRY ilutRenderer(ILenum Renderer);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int ilutRenderer(int Renderer);
		#endregion int ilutRenderer(int Renderer);
        
		#region bool ilutEnable(int Mode);
		/// <summary>
		/// Enable an ILUT state.
		/// </summary>
		/// <remarks>
		/// <b>ilutEnable</b> enables a mode specified by Mode.
		/// </remarks>	
		/// <param name="Mode">Mode to enable.</param>        
		// ILAPI ILboolean ILAPIENTRY ilutEnable(ILenum Mode);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern bool ilutEnable(int Mode);
		#endregion bool ilutEnable(int Mode);
        
		#region bool ilutDisable(int Mode);
		/// <summary>
		/// Disable an ILUT state.
		/// </summary>
		/// <remarks>
		/// <b>ilutDisable</b> disables a mode specified by Mode.
		/// </remarks>
		/// <param name="Mode">Mode to disable.</param>    
		// ILAPI ILboolean ILAPIENTRY ilutDisable(ILenum Mode);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern bool ilutDisable(int mode);
		#endregion bool ilutDisable(int Mode);
        
		#region bool ilutGetBoolean(int Mode);
		/// <summary>
		/// This function returns the value of a selected mode.
		/// </summary>
		/// <param name="Mode">The mode value to be returned.</param>
		// ILAPI ILboolean ILAPIENTRY ilutGetBoolean(ILenum Mode);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern bool ilutGetBoolean(int Mode);
		#endregion bool ilutGetBoolean(int Mode);
        
		#region void ilutGetBooleanv(int Mode, IntPtr Param);
		/// <summary>
		///	This function returns the value of a selected mode.	
		/// </summary>
		/// <param name="Mode">The mode value to be returned.</param>
		/// <param name="Param">The value is stored here instead of returned.</param>
		// ILAPI ILvoid ILAPIENTRY ilutGetBooleanv(ILenum Mode, ILboolean *Param);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void ilutGetBooleanv(int Mode, IntPtr Param);
		#endregion void ilutGetBooleanv(int Mode, IntPtr Param);
        
		#region int ilutGetInteger(int Mode);
		/// <summary>
		///This function returns the value of a selected mode.	
		/// </summary>
		/// <param name="Mode">The mode value to be returned.</param>
		// ILAPI ILint ILAPIENTRY ilutGetInteger(ILenum Mode);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int ilutGetInteger(int Mode);
		#endregion int ilutGetInteger(int Mode);
        
		#region void ilutGetIntegerv(int Mode, IntPtr Param);
		/// <summary>
		///	This function returns the value of a selected mode.	
		/// </summary>
		/// <param name="Mode">The mode value to be returned.</param>
		/// <param name="Param">The value is stored here instead of returned.</param>
		// ILAPI ILvoid ILAPIENTRY ilutGetIntegerv(ILenum Mode, ILint *Param);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void ilutGetIntegerv(int Mode, IntPtr Param);
		#endregion void ilutGetIntegerv(int Mode, IntPtr Param);
        
		#region string ilutGetString(int StringName);
		/// <summary>
		/// The <b>ilutGetString</b> function returns a string describing the OpenILUT implementation.
		/// </summary>
		/// <param name="StringName">Enum that describes the string to be retrieved.</param>
		/// <remarks>
		/// <para>ilutGetString returns a constant human-readable string describing the current OpenILUT implementation. Values accepted for StringName are:</para>
		/// <para><b>ILUT_VENDOR</b> - Describes the OpenILUT vendor (currently Abysmal Software).</para>
		/// <para><b>ILUT_VERSION</b> - Use ilutGetInteger with ILUT_VERSION_NUM to check for version differences instead.</para>
		/// </remarks>
		// ILAPI const ILstring ILAPIENTRY ilutGetString(ILenum StringName);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern string ilutGetString(int StringName);
		#endregion string ilutGetString(int StringName);
        
		#region void ilutInit();
		/// <summary>
		/// The <b>ilutInit</b> function initializes ILUT.
		/// </summary>
		/// <remarks><b>ilutInit</b> starts ILUT and must be called prior to using ILUT.</remarks>
		/// <seealso cref="ilInit"/>
		/// <seealso cref="iluInit"/>
		// ILAPI ILvoid ILAPIENTRY ilutInit(ILvoid);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void ilutInit();
		#endregion void ilutInit();
        
		#region bool ilutIsDisabled(int Mode);
		/// <summary>
		/// Returns whether a mode is disabled.
		/// </summary>
		/// <param name="Mode">An enum indicating an ilut mode.</param>
		// ILAPI ILboolean ILAPIENTRY ilutIsDisabled(ILenum Mode);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern bool ilutIsDisabled(int Mode);
		#endregion bool ilutIsDisabled(int Mode);
        
		#region bool ilutIsEnabled(int Mode);
		/// <summary>
		///Returns whether a mode is enabled.
		/// </summary>
		/// <param name="Mode">An enum indicating an ilut mode.</param>
		// ILAPI ILboolean ILAPIENTRY ilutIsEnabled(ILenum Mode);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern bool ilutIsEnabled(int Mode);
		#endregion bool ilutIsEnabled(int Mode);
        
		#region void ilutPopAttrib();
		/// <summary>
		/// The <b>ilutPopAttrib</b> function "pops" the last entry off the state stack into the current states.
		/// </summary>
		/// <remarks><b>ilutPopAttrib</b> pops the last pushed stack entry off the stack and copies the bits specified when pushed by <see cref="ilutPushAttrib"/> to the previous set of states.</remarks>
		// ILAPI ILvoid ILAPIENTRY ilutPopAttrib(ILvoid);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void ilutPopAttrib();
		#endregion void ilutPopAttrib();
        
		#region void ilutPushAttrib(int Bits);
		/// <summary>
		/// The <b>ilutPushAttrib</b> function pushes a new set of modes and attributes onto the state stack.
		/// </summary>
		/// <param name="Bits">Attribute bits to push.</param>
		/// <remarks><b>ilutPushAttrib</b> pushes a new set of modes and attributes onto the state stack, allowing for "a fresh start".</remarks>
		/// <seealso cref="ilutPopAttrib"/>
		// ILAPI ILvoid ILAPIENTRY ilutPushAttrib(ILuint Bits);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void ilutPushAttrib(int Bits);
		#endregion void ilutPushAttrib(int Bits);
        
		#region void ilutSetInteger(int Mode, int Param);
		/// <summary>
		/// The <b>ilutSetInteger</b> function sets the value of a selected mode.
		/// </summary>
		/// <param name="Mode">The mode value to be returned.</param>
		/// <param name="Param">The value to set the mode with.</param>
		/// <remarks><b>ilutSetInteger</b> is <see cref="ilutGetInteger"/>'s counterpart.</remarks>
		// ILAPI ILvoid ILAPIENTRY ilutSetInteger(ILenum Mode, ILint Param);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void ilutSetInteger(int Mode, int Param);
		#endregion void ilutSetInteger(int Mode, int Param);
        
		#region OpenGL Functions
		#region int ilutGLBindTexImage();
		/// <summary>
		/// The <b>ilutGLBindTexImage</b> function binds an image to a generated OpenGL texture.
		/// </summary>
		/// <seealso cref="ilGenImages"/>
		/// <seealso cref="ilBindImage"/>
		/// <seealso cref="ilutOglBuildMipmaps"/>
		/// <seealso cref="ilutOglScreen"/>
		/// <seealso cref="ilutGLTexImage"/>
		// ILAPI ILboolean ILAPIENTRY ilutGLTexImage(GLuint Level);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int ilutGLBindTexImage();
		#endregion int ilutGLBindTexImage();
        
		#region int ilutGLBindMipmaps();
		/// <summary>
		///The <b>ilutGLBindMipmaps</b> function binds an image to an OpenGL texture and creates mipmaps.
		/// </summary>
		/// <remarks><b>ilutGLBindMipmaps</b> generates a texture via glGenTextures, binds the current OpenIL image to it, generates mipmaps via gluBuild2DMipmaps and returns the texture name. This function is a more general purpose version of <see cref="ilutOglBindTexImage"/>.</remarks>
		/// <seealso cref="ilGenImages"/>
		/// <seealso cref="ilBindImage"/>
		/// <seealso cref="ilutOglBuildMipmaps"/>
		/// <seealso cref="ilutGLBindTexImage"/>
		// ILAPI GLuint ILAPIENTRY ilutGLBindMipmaps(ILvoid);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int ilutGLBindMipmaps();
		#endregion int ilutGLBindMipmaps();
        
		#region bool ilutGLBuildMipmaps();
		/// <summary>
		///The <b>ilutGLBuildMipmaps</b> function creates mipmaps from an image for OpenGL to use.
		/// </summary>
		/// <remarks><b>ilutGLBuildMipmaps</b> generates mipmaps via gluBuild2DMipmaps from an image. This function is similar to <see cref="ilutGLTexImage"/> but creates mipmaps.</remarks>
		/// <seealso cref="ilGenImages"/>
		/// <seealso cref="ilBindImage"/>
		/// <seealso cref="ilutGLBindMipmaps"/>
		// ILAPI ILboolean ILAPIENTRY ilutGLBuildMipmaps(ILvoid);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern bool ilutGLBuildMipmaps();
		#endregion bool ilutGLBuildMipmaps();
        
		#region bool ilutGLLoadImage(string FileName);
		/// <summary>
		///The <b>ilutGLLoadImage</b> function loads an image to an OpenGL texture.
		/// </summary>
		/// <param name="FileName">Name of the image file to load.</param>
		/// <remarks><b>ilutGLLoadImage</b> loads an image directly to an OpenGL texture, skipping the use of OpenIL image names.</remarks>
		/// <seealso cref="ilLoadImage"/>
		/// <seealso cref="ilutWinLoadImage"/>
		// ILAPI GLuint ILAPIENTRY ilutGLLoadImage(const ILstring FileName);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern bool ilutGLLoadImage(string FileName);
		#endregion bool ilutGLLoadImage(string FileName);
        
		#region bool ilutGLScreen();
		/// <summary>
		///The <b>ilutGLScreen</b> function takes a screenshot of the current OpenGL window.
		/// </summary>
		/// <remarks><b>ilutGLScreen</b> copies the current OpenGL window contents to the current bound image, effectively taking a screenshot. The new image attributes are that of the current OpenGL window's.</remarks>
		/// <seealso cref="ilGenImages"/>
		/// <seealso cref="ilBindImage"/>
		/// <seealso cref="ilutGLScreenie"/>
		// ILAPI ILboolean ILAPIENTRY ilutGLScreen(ILvoid);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern bool ilutGLScreen();
		#endregion bool ilutGLScreen();
        
		#region bool ilutGLScreenie();
		/// <summary>
		///The <b>ilutGLScreen</b> function takes a screenie of the current OpenGL window.
		/// </summary>
		/// <remarks><b>ilutGLScreen</b> copies the current OpenGL window contents to a temporary image, effectively taking a screenshot. The screenshot image is then saved to disk as screen0.tga - screen127.tga (the lowest name it can find). This is just a convenience function that uses <see cref="ilutGLScreen"/>.</remarks>
		/// <seealso cref="ilGenImages"/>
		/// <seealso cref="ilBindImage"/>
		/// <seealso cref="ilutGLScreen"/>
		// ILAPI ILboolean ILAPIENTRY ilutGLScreenie(ILvoid);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern bool ilutGLScreenie();
		#endregion bool ilutGLScreenie();
        
		#region bool ilutGLSaveImage(string FileName, int TexID);
		/// <summary>
		///
		/// </summary>
		/// <param name="FileName"></param>
		/// <param name="TexID"></param>
		// ILAPI ILboolean ILAPIENTRY ilutGLSaveImage(const ILstring FileName, GLuint TexID);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern bool ilutGLSaveImage(string FileName, int TexID);
		#endregion bool ilutGLSaveImage(string FileName, int TexID);
        
		#region bool ilutGLSetTex(int TexID);
		/// <summary>
		///
		/// </summary>
		/// <param name="TexID"></param>
		// ILAPI ILboolean ILAPIENTRY ilutGLSetTex(GLuint TexID);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern bool ilutGLSetTex(int TexID);
		#endregion bool ilutGLSetTex(int TexID);
        
		#region bool ilutGLTexImage(int Level);
		/// <summary>
		///The <b>ilutGLTexImage</b> function binds an image to an OpenGL texture.
		/// </summary>
		/// <param name="Level">Texture level to place the image at. 0 is the base image level, and anything lower is a mipmap. Use <see cref="ilActiveMipmap"/> to access OpenIL's mipmaps.</param>
		/// <remarks><b>ilutGLTexImage</b> simply calls glTexImage2D with the current bound image's data and attributes.</remarks>
		/// <seealso cref="ilGenImages"/>
		/// <seealso cref="ilBindImage"/>
		/// <seealso cref="ilActiveMipmap"/>
		/// <seealso cref="ilutOglBindTexImage"/>
		/// <seealso cref="ilutOglBuildMipmaps"/>
		/// <seealso cref="ilutOglScreen"/>
		/// <seealso cref="ilutGLScreenie"/>
		// ILAPI ILboolean ILAPIENTRY ilutGLTexImage(GLuint Level);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern bool ilutGLTexImage(int Level);
		#endregion bool ilutGLTexImage(int Level);
		#endregion OpenGL Functions
        
		#region SDL Functions
		#region IntPtr ilutConvertToSDLSurface(int flags);
		/// <summary>
		///The <b>ilutConvertToSDLSurface</b> function returns an SDL-compatible version of the currently bound image.
		/// </summary>
		/// <param name="flags">Flags to be used with SDL_CreateRGBSurface. Please refer to the SDL documentation for more information.</param>
		/// <remarks><b>ilutConvertToSDLSurface</b> creates a SDL_Surface copy of the currently bound image, for direct use in SDL.</remarks>
		/// <seealso cref="ilGenImages"/>
		/// <seealso cref="ilBindImage"/>
		// ILAPI SDL_Surface* ILAPIENTRY ilutConvertToSDLSurface(unsigned int flags);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr ilutConvertToSDLSurface(int flags);
		#endregion IntPtr ilutConvertToSDLSurface(int flags);
        
		#region IntPtr ilutSDLSurfaceLoadImage(string FileName);
		/// <summary>
		/// The <b>ilutSDLSurfaceLoadImage</b> function loads an image to a SDL surface.
		/// </summary>
		/// <param name="FileName">Name of the image file to load.</param>
		/// <remarks><b>ilutSDLSurfaceLoadImage</b> loads an image directly to a SDL_Surface, skipping the use of DevIL image names.</remarks>
		/// <seealso cref="ilGenImages"/>
		/// <seealso cref="ilBindImage"/>
		/// <seealso cref="ilutConvertToSDLSurface"/>
		/// <seealso cref="ilLoadImage"/>
		// ILAPI SDL_Surface*	ILAPIENTRY ilutSDLSurfaceLoadImage(const ILstring FileName);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr ilutSDLSurfaceLoadImage(string FileName);
		#endregion IntPtr ilutSDLSurfaceLoadImage(string FileName);
        
		#region bool ilutSDLSurfaceFromBitmap(IntPtr Bitmap);
		/// <summary>
		///
		/// </summary>
		/// <param name="Bitmap"></param>
		// ILAPI ILboolean ILAPIENTRY ilutSDLSurfaceFromBitmap(SDL_Surface *Bitmap);
		[DllImport("ilut.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern bool ilutSDLSurfaceFromBitmap(IntPtr Bitmap);
		#endregion bool ilutSDLSurfaceFromBitmap(IntPtr Bitmap);
		#endregion SDL Functions
		#endregion Externs
	}
}