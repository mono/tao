#region License
/*
MIT License
Copyright ©2003-2004 Randy Ridge
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

namespace Tao.Sdl {
    #region Class Documentation
    /// <summary>
    /// SDL_Image bindings for .NET. 
    /// A simple library to load images of various formats as SDL surfaces.
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
    ///	This is a simple library to load images of various formats as 
    ///	SDL surfaces.
    ///	This library supports BMP, PNM (PPM/PGM/PBM), XPM, LBM, PCX, 
    ///	GIF, JPEG, PNG,
    ///	TGA, and TIFF formats.
    ///
    ///	JPEG support requires the JPEG library.
    ///	PNG support requires the PNG library.
    ///	and the Zlib library.
    ///	TIFF support requires the TIFF library.
    ///	
    ///	
    ///	SDL_image supports loading and decoding images from the 
    ///	following formats:
    ///	TGA 
    ///	TrueVision Targa (MUST have .tga) 
    ///	BMP 
    ///	Windows Bitmap(.bmp) 
    ///	PNM 
    ///	Portable Anymap (.pnm)
    ///	.pbm = Portable BitMap (mono)
    ///	.pgm = Portable GreyMap (256 greys)
    ///	.ppm = Portable PixMap (full color) 
    ///	XPM 
    ///	X11 Pixmap (.xpm) can be #included directly in code
    ///	This is NOT the same as XBM(X11 Bitmap) format, which is for monocolor
    ///	images. 
    ///	XCF 
    ///	GIMP native (.xcf) (XCF = eXperimental Computing Facility?)
    ///	This format is always changing, and since there's no library supplied
    ///	by the GIMP project to load XCF, the loader may frequently fail to 
    ///	load much of any image from an XCF file. It's better to load this 
    ///	in GIMP and convert to a better supported image format. 
    ///	PCX 
    ///	ZSoft IBM PC Paintbrush (.pcx) 
    ///	GIF 
    ///	CompuServe Graphics Interchange Format (.gif) 
    ///	JPG 
    ///	Joint Photographic Experts Group JFIF format (.jpg or .jpeg) 
    ///	TIF 
    ///	Tagged Image File Format (.tif or .tiff) 
    ///	LBM 
    ///	Interleaved Bitmap (.lbm or .iff) FORM : ILBM or PBM(packed bitmap)
    ///	HAM6, HAM8, and 24bit types are not supported. 
    ///	PNG 
    ///	Portable Network Graphics (.png) 
    /// </remarks>
    #endregion Class Documentation
    public sealed class SdlImage {
		// --- Fields ---
        #region Private Constants
        #region string SDL_IMAGE_NATIVE_LIBRARY
        /// <summary>
        ///     Specifies SdlImage's native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies SDL_image.dll for Windows and libSDL_image.so for Linux.
        /// </remarks>
#if WIN32
		private const string SDL_IMAGE_NATIVE_LIBRARY = "SDL_image.dll";
#elif LINUX
		private const string SDL_IMAGE_NATIVE_LIBRARY = "libSDL_image.so";
#endif
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

        // --- Constructors & Destructors ---
		#region SdlImage()
        /// <summary>
        /// Prevents instantiation.
        /// </summary>
        private SdlImage() {
        }

        /// <summary>
		/// Static SdlImage constructor. All the functionality of 
		/// the SDLImage library is available through this class 
		/// and its properties.
		/// Explicit static constructor tells the C# compiler
		/// not to mark type as beforefieldinit.
        /// </summary>
        static SdlImage() 
		{
        }
        #endregion SdlImage()

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
        /// Here is a list of the currently recognized strings 
        /// (case is not important):
        /// "TGA"
        /// "BMP"
        /// "PNM"
        /// "XPM"
        /// "XCF"
        /// "PCX"
        /// "GIF"
        /// "JPG"
        /// "TIF"
        /// "LBM"
        /// "PNG"
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
        /// </remarks>
        /// <returns>
        /// a pointer to the image as a new SDL_Surface. 
        /// NULL is returned on errors. 
        /// </returns>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_LoadTyped_RW(
            IntPtr src, 
            int freesrc, 
            string type);

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
        /// </remarks>
        /// <param name="file">
        /// Image file name to load a surface from. 
        /// </param>
        /// <returns>
        /// a pointer to the image as a new SDL_Surface. 
        /// NULL is returned on errors, such as no support 
        /// built for the image, or a file reading error. 
        /// </returns>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_Load(string file);

        /// <summary>
        /// Load an image of an unspecified format
        /// </summary>
        /// <param name="freesrc">
        /// A non-zero value mean is will automatically close/free 
        /// the src for you. 
        /// </param>
        /// <param name="src">
        /// The image is loaded from this. 
        /// </param>
        /// <remarks>
        /// Load src for use as a surface. 
        /// This can load all supported image formats, except TGA. 
        /// Using SDL_RWops is not covered here, 
        /// but they enable you to load from almost any source. 
        /// </remarks>
        /// <returns>
        /// a pointer to the image as a new SDL_Surface. 
        /// NULL is returned on errors. 
        /// </returns>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_Load_RW(IntPtr src, int freesrc);

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
        /// </remarks>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_LoadBMP_RW(IntPtr src);
		
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
        /// </remarks>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_LoadPNM_RW(IntPtr src);
		
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
        /// </remarks>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_LoadXPM_RW(IntPtr src);
		
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
        /// </remarks>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_LoadXCF_RW(IntPtr src);
		
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
        /// </remarks>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_LoadPCX_RW(IntPtr src);
		
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
        /// </remarks>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_LoadGIF_RW(IntPtr src);
		
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
        /// </remarks>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_LoadJPG_RW(IntPtr src);
		
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
        /// </remarks>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_LoadTIF_RW(IntPtr src);
		
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
        /// </remarks>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_LoadPNG_RW(IntPtr src);

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
        /// </remarks>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_LoadTGA_RW(IntPtr src);

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
        /// </remarks>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_LoadLBM_RW(IntPtr src);

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
        /// </remarks>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_ReadXPMFromArray(IntPtr[] src);

        /// <summary>
        /// Test for valid, supported BMP file.
        /// </summary>
        /// <remarks>
        /// If the BMP format is supported, 
        /// then the image data is tested to see if it is readable as a BMP,
        ///  otherwise it returns false (Zero). 
        /// </remarks>
        /// <param name="src"></param>
        /// <returns>
        /// 1 if the image is a BMP and the BMP format support is
        ///  compiled into SDL_image. 0 is returned otherwise. 
        /// </returns>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_isBMP(IntPtr src);

        /// <summary>
        /// Test for valid, supported PNM file.
        /// </summary>
        /// <remarks>
        /// If the PNM format is supported, 
        /// then the image data is tested to see if it is readable as a PNM,
        ///  otherwise it returns false (Zero). 
        /// </remarks>
        /// <param name="src"></param>
        /// <returns>
        /// 1 if the image is a PNM and the PNM format support is
        ///  compiled into SDL_image. 0 is returned otherwise. 
        /// </returns>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_isPNM(IntPtr src);

        /// <summary>
        /// Test for valid, supported XPM file.
        /// </summary>
        /// <remarks>
        /// If the XPM format is supported, 
        /// then the image data is tested to see if it is readable as a XPM,
        ///  otherwise it returns false (Zero). 
        /// </remarks>
        /// <param name="src"></param>
        /// <returns>
        /// 1 if the image is a XPM and the XPM format support is
        ///  compiled into SDL_image. 0 is returned otherwise. 
        /// </returns>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_isXPM(IntPtr src);

        /// <summary>
        /// Test for valid, supported XCF file.
        /// </summary>
        /// <remarks>
        /// If the XCF format is supported, 
        /// then the image data is tested to see if it is readable as a XCF,
        ///  otherwise it returns false (Zero). 
        /// </remarks>
        /// <param name="src"></param>
        /// <returns>
        /// 1 if the image is a XCF and the XCF format support is
        ///  compiled into SDL_image. 0 is returned otherwise. 
        /// </returns>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_isXCF(IntPtr src);

        /// <summary>
        /// Test for valid, supported PCX file.
        /// </summary>
        /// <remarks>
        /// If the PCX format is supported, 
        /// then the image data is tested to see if it is readable as a PCX,
        ///  otherwise it returns false (Zero). 
        /// </remarks>
        /// <param name="src"></param>
        /// <returns>
        /// 1 if the image is a PCX and the PCX format support is
        ///  compiled into SDL_image. 0 is returned otherwise. 
        /// </returns>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_isPCX(IntPtr src);

        /// <summary>
        /// Test for valid, supported GIF file.
        /// </summary>
        /// <remarks>
        /// If the GIF format is supported, 
        /// then the image data is tested to see if it is readable as a GIF,
        ///  otherwise it returns false (Zero). 
        /// </remarks>
        /// <param name="src"></param>
        /// <returns>
        /// 1 if the image is a GIF and the GIF format support is
        ///  compiled into SDL_image. 0 is returned otherwise. 
        /// </returns>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_isGIF(IntPtr src);

        /// <summary>
        /// Test for valid, supported JPG file.
        /// </summary>
        /// <remarks>
        /// If the JPG format is supported, 
        /// then the image data is tested to see if it is readable as a JPG,
        ///  otherwise it returns false (Zero). 
        /// </remarks>
        /// <param name="src"></param>
        /// <returns>
        /// 1 if the image is a JPG and the JPG format support is
        ///  compiled into SDL_image. 0 is returned otherwise. 
        /// </returns>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_isJPG(IntPtr src);

        /// <summary>
        /// Test for valid, supported TIF file.
        /// </summary>
        /// <remarks>
        /// If the TIF format is supported, 
        /// then the image data is tested to see if it is readable as a TIF,
        ///  otherwise it returns false (Zero). 
        /// </remarks>
        /// <param name="src"></param>
        /// <returns>
        /// 1 if the image is a TIF and the TIF format support is
        ///  compiled into SDL_image. 0 is returned otherwise. 
        /// </returns>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_isTIF(IntPtr src);

        /// <summary>
        /// Test for valid, supported PNG file.
        /// </summary>
        /// <remarks>
        /// If the PNG format is supported, 
        /// then the image data is tested to see if it is readable as a PNG,
        ///  otherwise it returns false (Zero). 
        /// </remarks>
        /// <param name="src"></param>
        /// <returns>
        /// 1 if the image is a PNG and the PNG format support is
        ///  compiled into SDL_image. 0 is returned otherwise. 
        /// </returns>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_isPNG(IntPtr src);

        /// <summary>
        /// Test for valid, supported LBM file.
        /// </summary>
        /// <remarks>
        /// If the LBM format is supported, 
        /// then the image data is tested to see if it is readable as a LBM,
        ///  otherwise it returns false (Zero). 
        /// </remarks>
        /// <param name="src"></param>
        /// <returns>
        /// 1 if the image is a LBM and the LBM format support is
        ///  compiled into SDL_image. 0 is returned otherwise. 
        /// </returns>
        [DllImport(SDL_IMAGE_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IMG_isLBM(IntPtr src);
    }
}
