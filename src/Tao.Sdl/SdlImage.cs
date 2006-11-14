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
using System.Reflection;
using System.Security;
using System.Runtime.InteropServices;

namespace Tao.Sdl 
{
	#region Class Documentation
	/// <summary>
	/// SDL_Image bindings for .NET. 
	/// <p>A simple library to load images of various formats as SDL surfaces.</p>
	/// </summary>
	/// <remarks>
	/// Images provide the basic visual building blocks for any user 
	/// interface. Colors and fun shapes are the stuff that we as kids 
	/// looked at for 
	///  hours at a time while trying to shoot down big aliens and rescue 
	///  pixelated princesses. Now it's our turn to make the images that 
	///  others will remember later in life perhaps. Now how do we get 
	///  this dang images into our SDL programs, and be flexible in the 
	///  handling of the images so that we don't even have to worry about 
	///  what various formats they may be in? This is where SDLimage makes 
	///  all of our lives easier. This document doesn't help you make 
	///  artwork, but it will give you the functional knowledge on how to 
	///  get that art into your game. Now go forth and make your Stick Figure 
	///  of Justice, someone else might fill in for your lack of artistry, 
	///  at least you won't have to make much of an effort to include the 
	///  new and better art into your code. 
	///  <p>
	///	This is a simple library to load images of various formats as 
	///	SDL surfaces.</p>
	///	<p>This library supports BMP, PNM (PPM/PGM/PBM), XPM, LBM, PCX, 
	///	GIF, JPEG, PNG,
	///	TGA, and TIFF formats.</p>
	///<p>
	///	<br>JPEG support requires the JPEG library.</br>
	///	<br>PNG support requires the PNG library.
	///	and the Zlib library.</br>
	///	<br>TIFF support requires the TIFF library.</br>
	///	</p>
	///	<p>
	///	SDL_image supports loading and decoding images from the 
	///	following formats:</p>
	///	<code>
	///	TGA TrueVision Targa (MUST have .tga) 
	///	
	///	BMP Windows Bitmap(.bmp) 
	///	
	///	PNM Portable Anymap (.pnm)
	///	
	///		.pbm = Portable BitMap (mono)
	///		.pgm = Portable GreyMap (256 greys)
	///		.ppm = Portable PixMap (full color) 
	///		
	///	XPM X11 Pixmap (.xpm) can be #included directly in code
	///		This is NOT the same as XBM(X11 Bitmap) format, which is for monocolor
	///		images. 
	///		
	///	XCF 
	///	
	///	GIMP native (.xcf) (XCF = eXperimental Computing Facility?)
	///	This format is always changing, and since there's no library supplied
	///	by the GIMP project to load XCF, the loader may frequently fail to 
	///	load much of any image from an XCF file. It's better to load this 
	///	in GIMP and convert to a better supported image format. 
	///	
	///	PCX ZSoft IBM PC Paintbrush (.pcx) 
	///	GIF CompuServe Graphics Interchange Format (.gif) 
	///	JPG Joint Photographic Experts Group JFIF format (.jpg or .jpeg) 
	///	TIF Tagged Image File Format (.tif or .tiff) 
	///	LBM Interleaved Bitmap (.lbm or .iff) FORM : ILBM or PBM(packed bitmap)
	///	HAM6, HAM8, and 24bit types are not supported. 
	///	PNG Portable Network Graphics (.png) 
	///	</code>
	/// </remarks>
	#endregion Class Documentation
	[SuppressUnmanagedCodeSecurityAttribute()]
	public static class SdlImage 
	{
		#region Private Constants
		#region string SDL_IMAGE_NATIVE_LIBRARY
		/// <summary>
		///     Specifies SdlImage's native library archive.
		/// </summary>
		/// <remarks>
		///     Specifies SDL_image.dll everywhere; will be mapped via .config for mono.
		/// </remarks>
		private const string SDL_IMAGE_NATIVE_LIBRARY = "SDL_image.dll";

		#endregion string SDL_IMAGE_NATIVE_LIBRARY

		#region CallingConvention CALLING_CONVENTION
		/// <summary>
		///     Specifies the calling convention.
		/// </summary>
		/// <remarks>
		///     Specifies <see cref="CallingConvention.Cdecl" /> 
		///     for Windows and Linux.
		/// </remarks>
		private const CallingConvention CALLING_CONVENTION = 
			CallingConvention.Cdecl;
		#endregion CallingConvention CALLING_CONVENTION
		#endregion Private Constants
	
		#region Public Constants
		/// <summary>
		/// Major Version
		/// </summary>
		public const int SDL_IMAGE_MAJOR_VERSION = 1;
		/// <summary>
		/// Minor Version
		/// </summary>
		public const int SDL_IMAGE_MINOR_VERSION = 2;
		/// <summary>
		/// Patch Version
		/// </summary>
		public const int SDL_IMAGE_PATCHLEVEL = 5;
		#endregion Public Constants
		
		#region SdlImage Methods
		#region SDL_version SDL_IMAGE_VERSION() 
		/// <summary>
		/// This method can be used to fill a version structure with the compile-time
		/// version of the SDL_image library.
		/// </summary>
		/// <returns>
		///     This function returns a <see cref="Sdl.SDL_version"/> struct containing the
		///     compiled version number
		/// </returns>
		/// <remarks>
		///     <p>
		///     Binds to C-function call in SDL_image.h:
		///     <code>#define SDL_IMAGE_VERSION(X)
		/// {
		/// (X)->major = SDL_IMAGE_MAJOR_VERSION;
		/// (X)->minor = SDL_IMAGE_MINOR_VERSION;
		/// (X)->patch = SDL_IMAGE_PATCHLEVEL;
		/// }</code>
		///     </p>
		/// </remarks>
		public static Sdl.SDL_version SDL_IMAGE_VERSION() 
		{ 
			Sdl.SDL_version sdlVersion = new Sdl.SDL_version();
			sdlVersion.major = SDL_IMAGE_MAJOR_VERSION;
			sdlVersion.minor = SDL_IMAGE_MINOR_VERSION;
			sdlVersion.patch = SDL_IMAGE_PATCHLEVEL;
			return sdlVersion;
		} 
		#endregion SDL_version SDL_IMAGE_VERSION() 

		#region IntPtr IMG_Linked_VersionInternal()
		//     const SDL_version * IMG_Linked_Version(void)
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="IMG_Linked_Version"), SuppressUnmanagedCodeSecurity]
		private static extern IntPtr IMG_Linked_VersionInternal();
		#endregion IntPtr IMG_Linked_VersionInternal()

		#region SDL_version IMG_Linked_Version() 
		/// <summary>
		///     Using this you can compare the runtime version to the 
		/// version that you compiled with.
		/// </summary>
		/// <returns>
		///     This function gets the version of the dynamically 
		/// linked SDL_image library in an <see cref="Sdl.SDL_version"/> struct.
		/// </returns>
		/// <remarks>
		///     <p>
		///     Binds to C-function call in SDL_image.h:
		///     <code>const SDL_version * IMG_Linked_Version(void)</code>
		///     </p>
		/// </remarks>
		public static Sdl.SDL_version IMG_Linked_Version() 
		{ 
			return (Sdl.SDL_version)Marshal.PtrToStructure(
				IMG_Linked_VersionInternal(), 
				typeof(Sdl.SDL_version)); 
		} 
		#endregion SDL_version IMG_Linked_Version() 

		#region IntPtr IMG_LoadTyped_RW(IntPtr src, int freesrc, string type)
		/// <summary>
		/// Load an image from an SDL data source.
		/// The 'type' may be one of: "BMP", "GIF", "PNG", etc.
		/// If the image format supports a transparent pixel, SDL will set the
		/// colorkey for the surface.  You can enable RLE acceleration on the
		/// surface afterwards by calling:
		/// SDL_SetColorKey(image, SDL_RLEACCEL, image.format.colorkey);
		/// </summary>
		/// <param name="freesrc">
		/// A non-zero value mean is will automatically close/free 
		/// the src for you. 
		/// </param>
		/// <param name="src">
		/// The image is loaded from this. 
		/// </param>
		/// <param name="type">
		/// A string that indicates which format type to interpret the image 
		/// as.
		/// <p>Here is a list of the currently recognized strings 
		/// (case is not important):</p>
		/// <br>"TGA"</br>
		/// <br>"BMP"</br>
		/// <br>"PNM"</br>
		/// <br>"XPM"</br>
		/// <br>"XCF"</br>
		/// <br>"PCX"</br>
		/// <br>"GIF"</br>
		/// <br>"JPG"</br>
		/// <br>"TIF"</br>
		/// <br>"LBM"</br>
		/// <br>"PNG"</br>
		/// </param>
		/// <remarks>
		/// Load src for use as a surface. 
		/// This can load all supported image formats. 
		/// This method does not guarantee that the format 
		/// specified by type is the format of the loaded image, 
		/// except in the case when TGA format is specified 
		/// (or any other non-magicable format). 
		/// Using SDL_RWops is not covered here, 
		/// but they enable you to load from almost any source. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_LoadTyped_RW(SDL_RWops *src, int freesrc, char *type)
		/// </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors. 
		/// </returns>
		/// <example>
		/// <code>
		/// // load sample.tga into image
		///		SDL_Surface *image;
		///		image=IMG_Load_RW(SDL_RWFromFile("sample.tga", "rb"), 1, "TGA");
		///		if(!image) 
		///	{
		///		printf("IMG_Load_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_Load"/>
		/// <seealso cref="IMG_Load_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_LoadTyped_RW(
			IntPtr src, 
			int freesrc, 
			string type);
		#endregion IntPtr IMG_LoadTyped_RW(IntPtr src, int freesrc, string type)

		#region IntPtr IMG_Load(string file)
		/// <summary>
		/// Load from a file.
		/// </summary>
		/// <remarks>
		/// Load file for use as an image in a new surface. 
		/// This actually calls IMG_LoadTyped_RW, with the file extension 
		/// used as the type string. This can load all supported image files,
		/// including TGA as long as the filename ends with ".tga". 
		/// It is best to call this outside of event loops, and rather 
		/// keep the loaded images around until you are really done with 
		/// them, as disk speed and image conversion to a surface is not 
		/// that speedy. Don't forget to SDL_FreeSurface the returned 
		/// surface pointer when you are through with it. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_Load(const char *file)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="file">
		/// Image file name to load a surface from. 
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, such as no support 
		/// built for the image, or a file reading error. 
		/// </returns>
		/// <example>
		/// <code>
		/// // load sample.png into image
		///		SDL_Surface *image;
		///		image=IMG_Load("sample.png");
		///		if(!image) 
		///	{
		///		printf("IMG_Load: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_Load_RW"/>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_Load(string file);
		#endregion IntPtr IMG_Load(string file)

		#region IntPtr IMG_Load_RW(IntPtr src, int freesrc)
		/// <summary>
		/// Load an image of an unspecified format
		/// </summary>
		/// <param name="freesrc">
		/// A non-zero value mean is will automatically close/free 
		/// the src for you. 
		/// </param>
		/// <param name="src">
		/// The image is loaded from pointer. 
		/// </param>
		/// <remarks>
		/// Load src for use as a surface. 
		/// This can load all supported image formats, except TGA. 
		/// Using SDL_RWops is not covered here, 
		/// but they enable you to load from almost any source. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_Load_RW(SDL_RWops *src, int freesrc)
		/// </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors. 
		/// </returns>
		/// <example>
		/// <code>
		/// // load sample.png in to image
		///		SDL_Surface *image;
		///	image=IMG_Load_RW(SDL_RWFromFile("sample.png", "rb"), 1);
		///		if(!image) 
		///	{
		///		printf("IMG_Load_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_Load"/>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_Load_RW(IntPtr src, int freesrc);
		#endregion IntPtr IMG_Load_RW(IntPtr src, int freesrc)

		//int IMG_InvertAlpha(int on) is a deprecated function.

		#region IntPtr IMG_isBMP(IntPtr src)
		/// <summary>
		/// Test for valid, supported BMP file.
		/// </summary>
		/// <remarks>
		/// If the BMP format is supported, 
		/// then the image data is tested to see if it is readable as a BMP,
		///  otherwise it returns false (Zero). 
		///  <p>Binds to C-function in SDL_image.h
		/// <code>
		/// int IMG_isBMP(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="src"></param>
		/// <returns>
		/// 1 if the image is a BMP and the BMP format support is
		///  compiled into SDL_image. 0 is returned otherwise. 
		/// </returns>
		/// <example>
		/// <code>
		/// // Test sample.bmp to see if it is a BMP
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.bmp", "rb");
		///		if(IMG_isBMP(rwop))
		///		printf("sample.bmp is a BMP file.\n");
		///		else
		///		printf("sample.bmp is not a BMP file, or BMP support is not available.\n");
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_isBMP(IntPtr src);
		#endregion IntPtr IMG_isBMP(IntPtr src)

		#region IntPtr IMG_isPNM(IntPtr src)
		/// <summary>
		/// Test for valid, supported PNM file.
		/// </summary>
		/// <remarks>
		/// If the PNM format is supported, 
		/// then the image data is tested to see if it is readable as a PNM,
		///  otherwise it returns false (Zero). 
		///  <p>Binds to C-function in SDL_image.h
		/// <code>
		/// int IMG_isPNM(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="src"></param>
		/// <returns>
		/// 1 if the image is a PNM and the PNM format support is
		///  compiled into SDL_image. 0 is returned otherwise. 
		/// </returns>
		/// <example>
		/// <code>
		/// // Test sample.pnm to see if it is a PNM
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.pnm", "rb");
		///		if(IMG_isPNM(rwop))
		///		printf("sample.pnm is a PNM file.\n");
		///		else
		///		printf("sample.pnm is not a PNM file, or PNM support is not available.\n");
		/// </code></example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_isPNM(IntPtr src);
		#endregion IntPtr IMG_isPNM(IntPtr src)

		#region IntPtr IMG_isXPM(IntPtr src)
		/// <summary>
		/// Test for valid, supported XPM file.
		/// </summary>
		/// <remarks>
		/// If the XPM format is supported, 
		/// then the image data is tested to see if it is readable as a XPM,
		///  otherwise it returns false (Zero). 
		///  <p>Binds to C-function in SDL_image.h
		/// <code>
		/// int IMG_isXPM(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="src"></param>
		/// <returns>
		/// 1 if the image is a XPM and the XPM format support is
		///  compiled into SDL_image. 0 is returned otherwise. 
		/// </returns>
		/// <example>
		/// <code>
		/// // Test sample.xpm to see if it is a XPM
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.xpm", "rb");
		///		if(IMG_isXPM(rwop))
		///		printf("sample.xpm is a XPM file.\n");
		///		else
		///		printf("sample.xpm is not a XPM file, or XPM support is not available.\n");
		/// </code></example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_isXPM(IntPtr src);
		#endregion IntPtr IMG_isXPM(IntPtr src)

		#region IntPtr IMG_isXV(IntPtr src)
		/// <summary>
		/// Test for valid, supported XV file.
		/// </summary>
		/// <remarks>
		/// If the XV format is supported, 
		/// then the image data is tested to see if it is readable as a XV,
		///  otherwise it returns false (Zero). 
		///  <p>Binds to C-function in SDL_image.h
		/// <code>
		/// int IMG_isXV(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="src"></param>
		/// <returns>
		/// 1 if the image is a XV and the XV format support is
		///  compiled into SDL_image. 0 is returned otherwise. 
		/// </returns>
		/// <example>
		/// <code>
		/// // Test sample.xv to see if it is a XV
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.xv", "rb");
		///		if(IMG_isXV(rwop))
		///		printf("sample.xpm is a XV file.\n");
		///		else
		///		printf("sample.xpm is not a XV file, or XV support is not available.\n");
		/// </code></example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_isXV(IntPtr src);
		#endregion IntPtr IMG_isXV(IntPtr src)

		#region IntPtr IMG_isXCF(IntPtr src)
		/// <summary>
		/// Test for valid, supported XCF file.
		/// </summary>
		/// <remarks>
		/// If the XCF format is supported, 
		/// then the image data is tested to see if it is readable as a XCF,
		///  otherwise it returns false (Zero). 
		///  <p>Binds to C-function in SDL_image.h
		/// <code>
		/// int IMG_isXCF(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="src"></param>
		/// <returns>
		/// 1 if the image is a XCF and the XCF format support is
		///  compiled into SDL_image. 0 is returned otherwise. 
		/// </returns>
		/// <example>
		/// <code>
		/// // Test sample.xcf to see if it is a XCF
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.xcf", "rb");
		///		if(IMG_isXCF(rwop))
		///		printf("sample.xcf is a XCF file.\n");
		///		else
		///		printf("sample.xcf is not a XCF file, or XCF support is not available.\n");
		/// </code></example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_isXCF(IntPtr src);
		#endregion IntPtr IMG_isXCF(IntPtr src)

		#region IntPtr IMG_isPCX(IntPtr src)
		/// <summary>
		/// Test for valid, supported PCX file.
		/// </summary>
		/// <remarks>
		/// If the PCX format is supported, 
		/// then the image data is tested to see if it is readable as a PCX,
		///  otherwise it returns false (Zero). 
		///  <p>Binds to C-function in SDL_image.h
		/// <code>
		/// int IMG_isPCX(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="src"></param>
		/// <returns>
		/// 1 if the image is a PCX and the PCX format support is
		///  compiled into SDL_image. 0 is returned otherwise. 
		/// </returns>
		/// <example>
		/// <code>
		/// // Test sample.pcx to see if it is a PCX
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.pcx", "rb");
		///		if(IMG_isPCX(rwop))
		///		printf("sample.pcx is a PCX file.\n");
		///		else
		///		printf("sample.pcx is not a PCX file, or PCX support is not available.\n");
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_isPCX(IntPtr src);
		#endregion IntPtr IMG_isPCX(IntPtr src)

		#region IntPtr IMG_isGIF(IntPtr src)
		/// <summary>
		/// Test for valid, supported GIF file.
		/// </summary>
		/// <remarks>
		/// If the GIF format is supported, 
		/// then the image data is tested to see if it is readable as a GIF,
		///  otherwise it returns false (Zero). 
		///  <p>Binds to C-function in SDL_image.h
		/// <code>
		/// int IMG_isGIF(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="src"></param>
		/// <returns>
		/// 1 if the image is a GIF and the GIF format support is
		///  compiled into SDL_image. 0 is returned otherwise. 
		/// </returns>
		/// <example>
		/// <code>
		/// // Test sample.gif to see if it is a GIF
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.gif", "rb");
		///		if(IMG_isGIF(rwop))
		///		printf("sample.gif is a GIF file.\n");
		///		else
		///		printf("sample.gif is not a GIF file, or GIF support is not available.\n");
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_isGIF(IntPtr src);
		#endregion IntPtr IMG_isGIF(IntPtr src)

		#region IntPtr IMG_isJPG(IntPtr src)
		/// <summary>
		/// Test for valid, supported JPG file.
		/// </summary>
		/// <remarks>
		/// If the JPG format is supported, 
		/// then the image data is tested to see if it is readable as a JPG,
		///  otherwise it returns false (Zero). 
		///  <p>Binds to C-function in SDL_image.h
		/// <code>
		/// int IMG_isJPG(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="src"></param>
		/// <returns>
		/// 1 if the image is a JPG and the JPG format support is
		///  compiled into SDL_image. 0 is returned otherwise. 
		/// </returns>
		/// <example>
		/// <code>
		/// // Test sample.jpg to see if it is a JPG
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.jpg", "rb");
		///		if(IMG_isJPG(rwop))
		///		printf("sample.jpg is a JPG file.\n");
		///		else
		///		printf("sample.jpg is not a JPG file, or JPG support is not available.\n");
		/// </code></example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_isJPG(IntPtr src);
		#endregion IntPtr IMG_isJPG(IntPtr src)

		#region IntPtr IMG_isTIF(IntPtr src)
		/// <summary>
		/// Test for valid, supported TIF file.
		/// </summary>
		/// <remarks>
		/// If the TIF format is supported, 
		/// then the image data is tested to see if it is readable as a TIF,
		///  otherwise it returns false (Zero). 
		///  <p>Binds to C-function in SDL_image.h
		/// <code>
		/// int IMG_isTIF(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="src"></param>
		/// <returns>
		/// 1 if the image is a TIF and the TIF format support is
		///  compiled into SDL_image. 0 is returned otherwise. 
		/// </returns>
		/// <example>
		/// <code>
		/// // Test sample.tif to see if it is a TIF
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.tif", "rb");
		///		if(IMG_isTIF(rwop))
		///		printf("sample.tif is a TIF file.\n");
		///		else
		///		printf("sample.tif is not a TIF file, or TIF support is not available.\n");
		/// </code></example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_isTIF(IntPtr src);
		#endregion IntPtr IMG_isTIF(IntPtr src)

		#region IntPtr IMG_isPNG(IntPtr src)
		/// <summary>
		/// Test for valid, supported PNG file.
		/// </summary>
		/// <remarks>
		/// If the PNG format is supported, 
		/// then the image data is tested to see if it is readable as a PNG,
		///  otherwise it returns false (Zero). 
		///  <p>Binds to C-function in SDL_image.h
		/// <code>
		/// int IMG_isPNG(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="src"></param>
		/// <returns>
		/// 1 if the image is a PNG and the PNG format support is
		///  compiled into SDL_image. 0 is returned otherwise. 
		/// </returns>
		/// <example>
		/// <code>
		/// // Test sample.png to see if it is a PNG
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.png", "rb");
		///		if(IMG_isPNG(rwop))
		///		printf("sample.png is a PNG file.\n");
		///		else
		///		printf("sample.png is not a PNG file, or PNG support is not available.\n");
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_isPNG(IntPtr src);
		#endregion IntPtr IMG_isPNG(IntPtr src)

		#region IntPtr IMG_isLBM(IntPtr src)
		/// <summary>
		/// Test for valid, supported LBM file.
		/// </summary>
		/// <remarks>
		/// If the LBM format is supported, 
		/// then the image data is tested to see if it is readable as a LBM,
		///  otherwise it returns false (Zero). 
		///  <p>Binds to C-function in SDL_image.h
		/// <code>
		/// int IMG_isLBM(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="src"></param>
		/// <returns>
		/// 1 if the image is a LBM and the LBM format support is
		///  compiled into SDL_image. 0 is returned otherwise. 
		/// </returns>
		/// <example>
		/// <code>
		/// // Test sample.lbm to see if it is a LBM
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.lbm", "rb");
		///		if(IMG_isLBM(rwop))
		///		printf("sample.lbm is a LBM file.\n");
		///		else
		///		printf("sample.lbm is not a LBM file, or LBM support is not available.\n");
		/// </code></example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_isLBM(IntPtr src);
		#endregion IntPtr IMG_isLBM(IntPtr src)

		#region IntPtr IMG_LoadBMP_RW(IntPtr src)
		/// <summary>
		/// Load a .BMP image.
		/// </summary>
		/// <param name="src">
		/// The BMP image is loaded from this
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, like if BMP is not supported, 
		/// or a read error. 
		/// </returns>
		/// <remarks>
		/// Load src as a BMP image for use as a surface, 
		/// if BMP support is compiled into the SDL_image library. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_LoadBMP_RW(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load sample.bmp into image
		///		SDL_Surface *image;
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.bmp", "rb");
		///		image=IMG_LoadBMP_RW(rwop);
		///		if(!image) 
		///	{
		///		printf("IMG_LoadBMP_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code></example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		/// <seealso cref="IMG_isBMP"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_LoadBMP_RW(IntPtr src);
		#endregion IntPtr IMG_LoadBMP_RW(IntPtr src)
		
		#region IntPtr IMG_LoadPNM_RW(IntPtr src)
		/// <summary>
		/// Load a .PNM image.
		/// </summary>
		/// <param name="src">
		/// The PNM image is loaded from this
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, like if PNM is not supported, 
		/// or a read error. 
		/// </returns>
		/// <remarks>
		/// Load src as a PNM image for use as a surface, 
		/// if PNM support is compiled into the SDL_image library. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_LoadPNM_RW(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load sample.pnm into image
		///		SDL_Surface *image;
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.pnm", "rb");
		///		image=IMG_LoadPNM_RW(rwop);
		///		if(!image) 
		///	{
		///		printf("IMG_LoadPNM_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		/// <seealso cref="IMG_isPNM"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_LoadPNM_RW(IntPtr src);
		#endregion IntPtr IMG_LoadPNM_RW(IntPtr src)
		
		#region IntPtr IMG_LoadXPM_RW(IntPtr src)
		/// <summary>
		/// Load a .XPM image.
		/// </summary>
		/// <param name="src">
		/// The XPM image is loaded from this
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, like if XPM is not supported, 
		/// or a read error. 
		/// </returns>
		/// <remarks>
		/// Load src as a XPM image for use as a surface, 
		/// if XPM support is compiled into the SDL_image library. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_LoadXPM_RW(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load sample.xpm into image
		///		SDL_Surface *image;
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.xpm", "rb");
		///		image=IMG_LoadXPM_RW(rwop);
		///		if(!image) 
		///	{
		///		printf("IMG_LoadXPM_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		/// <seealso cref="IMG_isXPM"/>
		/// <seealso cref="IMG_ReadXPMFromArray"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_LoadXPM_RW(IntPtr src);
		#endregion IntPtr IMG_LoadXPM_RW(IntPtr src)
		
		#region IntPtr IMG_LoadXCF_RW(IntPtr src)
		/// <summary>
		/// Load a .XCF image.
		/// </summary>
		/// <param name="src">
		/// The XCF image is loaded from this
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, like if XCF is not supported, 
		/// or a read error. 
		/// </returns>
		/// <remarks>
		/// Load src as a XCF image for use as a surface, 
		/// if XCF support is compiled into the SDL_image library. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_LoadXCF_RW(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load sample.xcf into image
		///		SDL_Surface *image;
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.xcf", "rb");
		///		image=IMG_LoadXCF_RW(rwop);
		///		if(!image) 
		///	{
		///		printf("IMG_LoadXCF_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		/// <seealso cref="IMG_isXCF"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_LoadXCF_RW(IntPtr src);
		#endregion IntPtr IMG_LoadXCF_RW(IntPtr src)

		#region IntPtr IMG_LoadXV_RW(IntPtr src)
		/// <summary>
		/// Load a .XV image.
		/// </summary>
		/// <param name="src">
		/// The XV image is loaded from this
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, like if XV is not supported, 
		/// or a read error. 
		/// </returns>
		/// <remarks>
		/// Load src as a XV image for use as a surface, 
		/// if XV support is compiled into the SDL_image library. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_LoadXV_RW(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load sample.xv into image
		///		SDL_Surface *image;
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.xv", "rb");
		///		image=IMG_LoadXV_RW(rwop);
		///		if(!image) 
		///	{
		///		printf("IMG_LoadXV_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		/// <seealso cref="IMG_isXV"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_LoadXV_RW(IntPtr src);
		#endregion IntPtr IMG_LoadXV_RW(IntPtr src)
		
		#region IntPtr IMG_LoadPCX_RW(IntPtr src)
		/// <summary>
		/// Load a .PCX image.
		/// </summary>
		/// <param name="src">
		/// The PCX image is loaded from this
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, like if PCX is not supported, 
		/// or a read error. 
		/// </returns>
		/// <remarks>
		/// Load src as a PCX image for use as a surface, 
		/// if PCX support is compiled into the SDL_image library. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_LoadPCX_RW(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load sample.pcx into image
		///		SDL_Surface *image;
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.pcx", "rb");
		///		image=IMG_LoadPCX_RW(rwop);
		///		if(!image) 
		///	{
		///		printf("IMG_LoadPCX_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		/// <seealso cref="IMG_isPCX"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_LoadPCX_RW(IntPtr src);
		#endregion IntPtr IMG_LoadPCX_RW(IntPtr src)
		
		#region IntPtr IMG_LoadGIF_RW(IntPtr src)
		/// <summary>
		/// Load a .GIF image.
		/// </summary>
		/// <param name="src">
		/// The GIF image is loaded from this
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, like if GIF is not supported, 
		/// or a read error. 
		/// </returns>
		/// <remarks>
		/// Load src as a GIF image for use as a surface, 
		/// if GIF support is compiled into the SDL_image library. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_LoadGIF_RW(SDL_RWops *src)
		/// </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load sample.gif into image
		///		SDL_Surface *image;
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.gif", "rb");
		///		image=IMG_LoadGIF_RW(rwop);
		///		if(!image) 
		///	{
		///		printf("IMG_LoadGIF_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		/// <seealso cref="IMG_isGIF"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_LoadGIF_RW(IntPtr src);
		#endregion IntPtr IMG_LoadGIF_RW(IntPtr src)
		
		#region IntPtr IMG_LoadJPG_RW(IntPtr src)
		/// <summary>
		/// Load a .JPG image.
		/// </summary>
		/// <param name="src">
		/// The JPG image is loaded from this
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, like if JPG is not supported, 
		/// or a read error. 
		/// </returns>
		/// <remarks>
		/// Load src as a JPG image for use as a surface, 
		/// if JPG support is compiled into the SDL_image library. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_LoadJPG_RW(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load sample.jpg into image
		///		SDL_Surface *image;
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.jpg", "rb");
		///		image=IMG_LoadJPG_RW(rwop);
		///		if(!image) 
		///	{
		///		printf("IMG_LoadJPG_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		/// <seealso cref="IMG_isJPG"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_LoadJPG_RW(IntPtr src);
		#endregion IntPtr IMG_LoadJPG_RW(IntPtr src)
		
		#region IntPtr IMG_LoadTIF_RW(IntPtr src)
		/// <summary>
		/// Load a .TIF image.
		/// </summary>
		/// <param name="src">
		/// The TIF image is loaded from this
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, like if TIF is not supported, 
		/// or a read error. 
		/// </returns>
		/// <remarks>
		/// Load src as a TIF image for use as a surface, 
		/// if TIF support is compiled into the SDL_image library. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_LoadTIF_RW(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load sample.tif into image
		///		SDL_Surface *image;
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.tif", "rb");
		///		image=IMG_LoadTIF_RW(rwop);
		///		if(!image) 
		///	{
		///		printf("IMG_LoadTIF_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		/// <seealso cref="IMG_isTIF"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_LoadTIF_RW(IntPtr src);
		#endregion IntPtr IMG_LoadTIF_RW(IntPtr src)
		
		#region IntPtr IMG_LoadPNG_RW(IntPtr src)
		/// <summary>
		/// Load a .PNG image.
		/// </summary>
		/// <param name="src">
		/// The PNG image is loaded from this
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, like if PNG is not supported, 
		/// or a read error. 
		/// </returns>
		/// <remarks>
		/// Load src as a PNG image for use as a surface, 
		/// if PNG support is compiled into the SDL_image library. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_LoadPNG_RW(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load sample.png into image
		///		SDL_Surface *image;
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.png", "rb");
		///		image=IMG_LoadPNG_RW(rwop);
		///		if(!image) 
		///	{
		///		printf("IMG_LoadPNG_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		/// <seealso cref="IMG_isPNG"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_LoadPNG_RW(IntPtr src);
		#endregion IntPtr IMG_LoadPNG_RW(IntPtr src)

		#region IntPtr IMG_LoadTGA_RW(IntPtr src)
		/// <summary>
		/// Load a .TGA image.
		/// </summary>
		/// <param name="src">
		/// The BMP image is loaded from this
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, like if BMP is not supported, 
		/// or a read error. 
		/// </returns>
		/// <remarks>
		/// Load src as a TGA image for use as a surface, 
		/// if TGA support is compiled into the SDL_image library. 
		/// If you try to load a non TGA image, 
		/// you might succeed even when it's not TGA image formatted data, 
		/// this is because the TGA has no magic, 
		/// which is a way of identifying a filetype from a 
		/// signature in it's contents. So be careful with this. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>SDL_Surface *IMG_LoadTGA_RW(SDL_RWops *src)
		/// </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load sample.tga into image
		///		SDL_Surface *image;
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.tga", "rb");
		///		image=IMG_LoadTGA_RW(rwop);
		///		if(!image) 
		///	{
		///		printf("IMG_LoadTGA_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_LoadTGA_RW(IntPtr src);
		#endregion IntPtr IMG_LoadTGA_RW(IntPtr src)

		#region IntPtr IMG_LoadLBM_RW(IntPtr src)
		/// <summary>
		/// Load a .LBM image.
		/// </summary>
		/// <param name="src">
		/// The LBM image is loaded from this
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, like if LBM is not supported, 
		/// or a read error. 
		/// </returns>
		/// <remarks>
		/// Load src as a LBM image for use as a surface, 
		/// if LBM support is compiled into the SDL_image library. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_LoadLBM_RW(SDL_RWops *src)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load sample.lbm into image
		///		SDL_Surface *image;
		///		SDL_RWops *rwop;
		///		rwop=SDL_RWFromFile("sample.lbm", "rb");
		///		image=IMG_LoadLBM_RW(rwop);
		///		if(!image) 
		///	{
		///		printf("IMG_LoadLBM_RW: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="IMG_LoadTyped_RW"/>
		/// <seealso cref="IMG_isLBM"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_LoadLBM_RW(IntPtr src);
		#endregion IntPtr IMG_LoadLBM_RW(IntPtr src)

		#region IntPtr IMG_ReadXPMFromArray(string[] src)
		/// <summary>
		/// Load a .XPM image from an array.
		/// </summary>
		/// <param name="src">
		/// The source xpm data. The XPM image is loaded from this.
		/// </param>
		/// <returns>
		/// a pointer to the image as a new SDL_Surface. 
		/// NULL is returned on errors, like if XPM is not supported, 
		/// or a read error. 
		/// </returns>
		/// <remarks>
		/// Load src as a XPM image for use as a surface, 
		/// if XPM support is compiled into the SDL_image library. 
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// SDL_Surface *IMG_ReadXPMFromArray(char **xpm)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load sample.xpm into image
		///#include "sample.xpm"
		///		SDL_Surface *image;
		///		image=IMG_ReadXPMFromArray(sample_xpm);
		///		if(!image) 
		///	{
		///		printf("IMG_ReadXPMFromArray: %s\n", IMG_GetError());
		///		// handle error
		///	}
		/// </code></example>
		/// <seealso cref="IMG_LoadXPM_RW"/>
		[DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr IMG_ReadXPMFromArray(string[] src);
		#endregion IntPtr IMG_ReadXPMFromArray(string[] src)

		#region void IMG_SetError(string message)
		/// <summary>
		/// Set the current error string
		/// </summary>
		/// <remarks>
		/// This is the same as SDL_SetError, which sets the error string
		///  which may be fetched with IMG_GetError (or SDL_GetError). 
		///  This functions acts like printf, except that it is limited 
		///  to SDL_ERRBUFIZE(1024) chars in length. It only accepts the
		///   following format types: %s, %d, %f, %p. No variations are 
		///   supported, like %.2f would not work. For any more specifics
		///    read the SDL docs.
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// void IMG_SetError(const char *fmt, ...)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// int myimagefunc(int i) {
		///		IMG_SetError("myimagefunc is not implemented! %d was passed in.",i);
		///		return(-1);
		///	}
		/// </code></example>
		/// <param name="message"></param>
		/// <seealso cref="IMG_GetError"/>
		public static void IMG_SetError(string message)
		{
			Sdl.SDL_SetError(message);
		}
		#endregion void IMG_SetError(string message)

		#region string IMG_GetError()
		/// <summary>
		/// Get the current error string
		/// </summary>
		/// <remarks>
		/// This is the same as SDL_GetError, which returns the last 
		/// error set as a string which you may use to tell the user 
		/// what happened when an error status has been returned from
		///  an SDL_image function call.
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// char *IMG_GetError() 
		/// </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// a char pointer (string) containing a humam 
		/// readable version or the reason for the last error that
		///  occured.
		///  </returns>
		/// <seealso cref="IMG_SetError"/>
		public static string IMG_GetError()
		{
			return Sdl.SDL_GetError();
		}
		#endregion string IMG_GetError()
		#endregion SdlImage Methods
	}
}
