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
    /// This library is a wrapper around the excellent FreeType 1.2 library,
    ///  available at: Freetype Homepage 
    ///
    ///	WARNING: There may be patent issues with using the FreeType library.
    ///	 Check the FreeType website for up-to-date details. 
    ///	This library allows you to use TrueType fonts to render text in SDL
    ///	 applications. 
    ///
    ///	Be careful when including fonts with your application, as many of 
    ///	them are copyrighted. 
    ///	The Microsoft fonts, for example, are not freely redistributable 
    ///	and even the free "web" 
    ///	fonts they provide are only redistributable in their special 
    ///	executable installer form (May 1998). 
    ///	There are plenty of freeware and shareware fonts available on the 
    ///	Internet though, and may suit your purposes. 
    /// </summary>
    /// <remarks>
    /// SDL_ttf supports loading fonts from TrueType font files, 
    /// normally ending in .ttf, though some .fon files are also valid for 
    /// use. Note that most fonts are copyrighted, check the license on the 
    /// font before you use and redistribute
    /// </remarks>
    #endregion Class Documentation
    public sealed class SdlTtf {
		// --- Fields ---
        #region Private Constants
        #region string SDL_TTF_NATIVE_LIBRARY
        /// <summary>
        ///     Specifies SdlTtf's native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies SDL_ttf.dll for Windows and libSDL_ttf.so for Linux.
        /// </remarks>
#if WIN32
		private const string SDL_TTF_NATIVE_LIBRARY = "SDL_ttf.dll";
#elif LINUX
		private const string SDL_TTF_NATIVE_LIBRARY = "libSDL_ttf.so";
#endif	
        #endregion string SDL_TTF_NATIVE_LIBRARY

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
        /// Used to indicate regular, normal, plain rendering style.
        /// </summary>
        public const Byte TTF_STYLE_NORMAL = 0x00;
        /// <summary>
        /// Used to indicate bold rendering style. 
        /// This is used a bitmask along with other styles.
        /// </summary>
        public const Byte TTF_STYLE_BOLD = 0x01;
        /// <summary>
        /// Used to indicate italicized rendering style. 
        /// This is used a bitmask along with other styles.
        /// </summary>
        public const Byte TTF_STYLE_ITALIC = 0x02;
        /// <summary>
        /// Used to indicate underlined rendering style. 
        /// This is used a bitmask along with other styles.
        /// </summary>
        public const Byte TTF_STYLE_UNDERLINE = 0x04;
        /// <summary>
        /// This allows you to switch byte-order of UNICODE text data 
        /// to native order, meaning the mode of your CPU. This is meant
        /// to be used in a UNICODE string that you are using with the 
        /// SDL_ttf API.
        /// </summary>
        public const int UNICODE_BOM_NATIVE = 0xFEFF;
        /// <summary>
        /// This allows you to switch byte-order of UNICODE text data to
        ///  swapped order, meaning the reversed mode of your CPU. 
        ///  So if your CPU is LSB, then the data will be interpreted
        ///   as MSB. This is meant to be used in a UNICODE string 
        ///   that you are using with the SDL_ttf API.
        /// </summary>
        public const int UNICODE_BOM_SWAPPED = 0xFFFE;
        #endregion Public Constants

        #region Public Structs
        /// <summary>
        /// The opaque holder of a loaded font
        /// </summary>
        /// <remarks>
        /// The opaque holder of a loaded font. You should always be using 
        /// a pointer of this type, as in TTF_Font*, and not just plain 
        /// TTF_Font. This stores the font data in a struct that is exposed
        /// only by using the API functions to get information. 
        /// You should not try to access the struct data directly, 
        /// since the struct may change in different versions of the API, 
        /// and thus your program would be unreliable.
        /// </remarks>
        public struct TTF_Font {
        }
        #endregion Public Structs

		 // --- Constructors & Destructors ---
        #region SdlTtf()
        /// <summary>
        ///     Prevents instantiation.
        /// </summary>
        private SdlTtf() 
		{
        }

        /// <summary>
		/// Static SdlTtf constructor. All the functionality of 
		/// the SDLTtf library is available through this class 
		/// and its properties.
		/// Explicit static constructor tells the C# compiler
		/// not to mark type as beforefieldinit.     
        /// </summary>
        static SdlTtf() 
		{
        }
        #endregion SdlTtf()

        /// <summary>
        /// Using this you can compare the runtime version to the 
        /// version that you compiled with. 
        /// </summary>
        /// <remarks>
        /// This function gets the version of the dynamically 
        /// linked SDL_ttf library.
        /// </remarks>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_Linked_Version();

        /// <summary>
        /// This function tells the library whether UNICODE text is generally
        /// byteswapped.  A UNICODE BOM character in a string will override
        /// this setting for the remainder of that string.
        /// </summary>
        /// <remarks>
        /// This function tells SDL_ttf whether UNICODE (Uint16 per character)
        ///  text is generally byteswapped. A UNICODE_BOM_NATIVE or 
        ///  UNICODE_BOM_SWAPPED character in a string will temporarily 
        ///  override this setting for the remainder of that string, 
        ///  however this setting will be restored for the next one. 
        ///  The default mode is non-swapped, native endianess of the CPU. 
        /// </remarks>
        /// <param name="swapped">
        /// if non-zero then UNICODE data is byte swapped relative to the 
        /// CPU's native endianess.
        /// if zero, then do not swap UNICODE data, 
        /// use the CPU's native endianess.
        /// </param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern int TTF_ByteSwappedUNICODE(int swapped);

        /// <summary>
        /// Initialize the TTF engine - returns 0 if successful, -1 on error
        /// </summary>
        /// <remarks>
        /// Initialize the truetype font API.
        /// This must be called before using other functions in this 
        /// library, excepting TTF_WasInit.
        /// SDL does not have to be initialized before this call. 
        /// </remarks>
        /// <returns>
        /// 0 on success, -1 on errors 
        /// </returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int TTF_Init();

        /// <summary>
        /// Open a font file and create a font of the specified point size.
        /// Some .fon fonts will have several sizes embedded in the file, so the
        /// point size becomes the index of choosing which size.  
        /// If the value
        /// is too high, the last indexed size will be the default.
        /// </summary>
        /// <param name="file">File name to load font from.</param>
        /// <param name="ptsize">Point size (based on 72DPI) to load font as.
        ///  This basically translates to pixel height.</param>
        ///  <remarks>
        ///  Load file for use as a font, at ptsize size. 
        ///  This is actually TTF_OpenFontIndex(file, ptsize, 0). 
        ///  This can load TTF and FON files.
        ///  </remarks>
        /// <returns>
        /// a pointer to the font as a TTF_Font. NULL is returned on errors.
        /// </returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_OpenFont(string file, int ptsize);

        /// <summary>
        /// Open a font file and create a font of the specified point size.
        /// Some .fon fonts will have several sizes embedded in the file, so the
        /// point size becomes the index of choosing which size.  
        /// If the value
        /// is too high, the last indexed size will be the default.
        /// </summary>
        /// <param name="file">File name to load font from.</param>
        /// <param name="ptsize">
        /// Point size (based on 72DPI) to load font as.
        /// This basically translates to pixel height.
        /// </param>
        /// <param name="index">
        /// choose a font face from a multiple font face containing file. 
        /// The first face is always index 0.
        /// </param>
        /// <remarks>
        /// Load file, face index, for use as a font, at ptsize size. 
        /// This is actually TTF_OpenFontIndexRW(SDL_RWFromFile(file), 
        /// ptsize, index), but checks that the RWops it creates is 
        /// not NULL. This can load TTF and FON files.
        /// </remarks>
        /// <returns>
        /// a pointer to the font as a TTF_Font. NULL is returned on errors.
        /// </returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_OpenFontIndex(
            string file, int ptsize, long index);

        /// <summary>
        /// Open a font file and create a font of the specified point size.
        /// Some .fon fonts will have several sizes embedded in the file, so the
        /// point size becomes the index of choosing which size.  
        /// If the value
        /// is too high, the last indexed size will be the default.
        /// </summary>
        /// <param name="src">The font is loaded from this.</param>
        /// <param name="freesrc">
        /// A non-zero value mean is will automatically close/free the 
        /// src for you.
        /// </param>
        /// <param name="ptsize">
        /// Point size (based on 72DPI) to load font as. 
        /// This basically translates to pixel height.
        /// </param>
        /// <remarks>
        /// Load src for use as a font, at ptsize size. 
        /// This is actually TTF_OpenFontIndexRW(src, freesrc, ptsize, 0).
        /// This can load TTF and FON formats.
        /// Using SDL_RWops is not covered here, 
        /// but they enable you to load from almost any source.
        ///
        /// NOTE: src is not checked for NULL, so be careful.
        /// </remarks>
        /// <returns>
        /// a pointer to the font as a TTF_Font. NULL is returned on errors.
        /// </returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_OpenFontRW(
            IntPtr src, 
            int freesrc, 
            int ptsize);

        /// <summary>
        /// Open a font file from memory with an index and create 
        /// a font of the specified point size.
        /// Some .fon fonts will have several sizes embedded in the file, so the
        /// point size becomes the index of choosing which size.  
        /// If the value
        /// is too high, the last indexed size will be the default.
        /// </summary>
        /// <param name="freesrc">
        /// A non-zero value mean is will automatically close/free 
        /// the src for you.
        /// </param>
        /// <param name="index">
        /// choose a font face from a multiple font face containing file. 
        /// The first face is always index 0.
        /// </param>
        /// <param name="src">The font is loaded from this.</param>
        /// <param name="ptsize">
        /// Point size (based on 72DPI) to load font as. 
        /// This basically translates to pixel height.
        /// </param>
        /// <remarks>
        /// Load src, face index, for use as a font, at ptsize size. 
        /// This can load TTF and FON formats.
        /// Using SDL_RWops is not covered here, 
        /// but they enable you to load from almost any source.
        /// 
        /// NOTE: src is not checked for NULL, so be careful.
        /// </remarks>
        /// <returns>
        /// a pointer to the font as a TTF_Font. NULL is returned on errors.
        /// </returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_OpenFontIndexRW(
            IntPtr src, int freesrc, int ptsize, long index);

        /// <summary>
        /// Set the font style
        /// This font style is implemented by modifying the font glyphs, and
        /// doesn't reflect any inherent properties of the truetype font file.
        /// </summary>
        /// <param name="font">The loaded font to get the style of </param>
        /// <param name="style">
        /// A bitmask of the desired style composed 
        /// from the TTF_STYLE_* defined values
        /// </param>
        /// <remarks>
        /// Set the rendering style of the loaded font.
        ///
        /// NOTE: Passing a NULL font into this function will cause a segfault.
        ///
        /// NOTE: This will flush the internal cache of previously rendered
        ///  glyphs, even if there is no change in style, so it may be best 
        ///  to check the current style using TTF_GetFontStyle first.
        ///
        /// NOTE: I've seen that combining TTF_STYLE_UNDERLINE with anything 
        /// can cause a segfault, other combinations may also do this. 
        /// Some brave soul may find the cause of this and fix it... 
        /// </remarks>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern void TTF_SetFontStyle(IntPtr font, int style);

        /// <summary>
        /// Retrieve the font style
        /// This font style is implemented by modifying the font glyphs, and
        /// doesn't reflect any inherent properties of the truetype font file.
        /// </summary>
        /// <remarks>
        /// Get the rendering style of the loaded font.
        ///
        /// NOTE: Passing a NULL font into this function will cause a segfault.
        /// </remarks>
        /// <param name="font">The loaded font to get the style of </param>
        /// <returns>
        /// The style as a bitmask composed of the following masks:
        /// TTF_STYLE_BOLD
        /// TTF_STYLE_ITALIC
        /// TTF_STYLE_UNDERLINE
        /// If no style is set then TTF_STYLE_NORMAL is returned.
        /// </returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int TTF_GetFontStyle(IntPtr font);

        /// <summary>
        /// Get the total height of the font - usually equal to point size
        /// </summary>
        /// <param name="font">
        /// The loaded font to get the max height of 
        /// </param>
        /// <remarks>
        /// Get the maximum pixel height of all glyphs of the loaded font. 
        /// You may use this height for rendering text as close together 
        /// vertically as possible, though adding at least one pixel height
        ///  to it will space it so they can't touch. Remember that SDL_ttf 
        ///  doesn't handle multiline printing, so you are responsible for 
        ///  line spacing, see the TTF_FontLineSkip as well.
        ///
        /// NOTE: Passing a NULL font into this function will cause a segfault.
        /// </remarks>
        /// <returns>
        /// The maximum pixel height of all glyphs in the font.
        /// </returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern int TTF_FontHeight(IntPtr font);

        /// <summary>
        /// Get font max ascent (y above origin).
        /// Get the offset from the baseline to the top of the font
        /// This is a positive value, relative to the baseline.
        /// </summary>
        /// <param name="font">The loaded font to get the ascent 
        /// (height above baseline) of </param>
        /// <remarks>
        /// Get the maximum pixel ascent of all glyphs of the loaded font. 
        /// This can also be interpreted as the distance from the top of 
        /// the font to the baseline.
        /// It could be used when drawing an individual glyph relative to 
        /// a top point, by combining it with the glyph's maxy metric to 
        /// resolve the top of the rectangle used when blitting the glyph 
        /// on the screen.
        ///
        /// rect.y = top + TTF_FontAscent(font) - glyph_metric.maxy;
        ///
        /// NOTE: Passing a NULL font into this function will cause a segfault.
        /// </remarks>
        /// <returns>
        /// The maximum pixel ascent of all glyphs in the font.
        /// </returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern int TTF_FontAscent(IntPtr font);

        /// <summary>
        /// Get font min descent (y below origin).
        /// Get the offset from the baseline to the bottom of the font
        /// This is a negative value, relative to the baseline.
        /// </summary>
        /// <param name="font">
        /// The loaded font to get the descent (height below baseline) of 
        /// </param>
        /// <remarks>
        /// Get the maximum pixel descent of all glyphs of the loaded font. 
        /// This can also be interpreted as the distance from the baseline 
        /// to the bottom of the font.
        /// It could be used when drawing an individual glyph relative to a 
        /// bottom point, by combining it with the glyph's maxy metric 
        /// to resolve the top of the rectangle used when blitting the 
        /// glyph on the screen.
        ///
        /// rect.y = bottom - TTF_FontDescent(font) - glyph_metric.maxy;
        ///
        /// NOTE: Passing a NULL font into this function will cause a segfault.
        /// </remarks>
        /// <returns>
        /// The maximum pixel height of all glyphs in the font.
        /// </returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern int TTF_FontDescent(IntPtr font);

        /// <summary>
        /// Get the recommended spacing between lines of text for this font.
        /// </summary>
        /// <param name="font">
        /// The loaded font to get the line skip height of 
        /// </param>
        /// <remarks>
        /// Get the reccomended pixel height of a rendered line of text 
        /// of the loaded font. This is usually larger than the 
        /// TTF_FontHeight of the font.
        ///
        /// NOTE: Passing a NULL font into this function will cause a segfault.
        /// </remarks>
        /// <returns>
        /// The maximum pixel height of all glyphs in the font.
        /// </returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern int TTF_FontLineSkip(IntPtr font);

        /// <summary>
        /// Get the number of faces of the font
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern long TTF_FontFaces(IntPtr font);

        /// <summary>
        /// Get whether font is monospaced or not.
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern int TTF_FontFaceIsFixedWidth(IntPtr font);

        /// <summary>
        /// Get current font face family name string.
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern string TTF_FontFaceFamilyName(IntPtr font);

        /// <summary>
        /// Get current font face style name string.
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern string TTF_FontFaceStyleName(IntPtr font);

        /// <summary>
        /// Get individual font glyph metrics 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="ch"></param>
        /// <param name="minx"></param>
        /// <param name="maxx"></param>
        /// <param name="miny"></param>
        /// <param name="maxy"></param>
        /// <param name="advance"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern int TTF_GlyphMetrics(
            IntPtr font, 
            short ch,
            IntPtr minx, 
            IntPtr maxx, 
            IntPtr miny, 
            IntPtr maxy, 
            IntPtr advance);

        /// <summary>
        /// Get size of LATIN1 text string as would be rendered 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int TTF_SizeText(
            IntPtr font, 
            [MarshalAs(UnmanagedType.LPWStr)] string text, 
            out int w, out int h);

        /// <summary>
        /// Get size of UTF8 text string as would be rendered
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int TTF_SizeUTF8(
            IntPtr font, 
            [MarshalAs(UnmanagedType.LPWStr)] string text, 
            out int w, out int h);

        /// <summary>
        /// Get size of UNICODE text string as would be rendered 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern int TTF_SizeUNICODE(
            IntPtr font, 
            [MarshalAs(UnmanagedType.LPWStr)] string text, 
            out int w, 
            out int h);

        /// <summary>
        /// Create an 8-bit palettized surface and render the given text at
        /// fast quality with the given font and color.  The 0 pixel is the
        /// colorkey, giving a transparent background, and the 1 pixel is set
        /// to the text color.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="fg"></param>
        /// <returns>
        /// This function returns the new surface, 
        /// or NULL if there was an error.
        /// </returns>
        /// <remarks>
        /// These functions render text using a TTF_Font.
        /// There are three modes of rendering:
        ///
        ///	Solid 
        ///	Quick and Dirty
        ///	 Create an 8-bit palettized surface and render the given
        ///	text at fast quality with the given font and color. 
        ///	The 0 pixel value is the colorkey, giving a transparent
        ///	background, and the 1 pixel value is set to the text
        ///	color. The colormap is set to have the desired 
        ///	foreground color at index 1, this allows you to 
        ///	change the color without having to render the text 
        ///	again. Colormap index 0 is of course not drawn, 
        ///	since it is the colorkey, and thus transparent, 
        ///	though it's actual color is 255 minus each RGB 
        ///	component of the foreground. This is the fastest 
        /// rendering speed of all the rendering modes. This results in no box 
        /// around the text, but the text is not as smooth. 
        /// The resulting surface should blit faster than the Blended one. 
        /// Use this mode for FPS and other fast changing updating text displays. 
        ///		Shaded 
        ///		Slow and Nice, but with a Solid Box
        ///	Create an 8-bit palettized 
        ///	surface and render the given text at high quality with 
        ///	the given font 
        ///	and colors. The 0 pixel value is background, while other 
        ///	pixels have 
        ///	varying degrees of the foreground color from the background color. 
        ///	This results in a box of the background color around the text 
        ///	in the 
        ///	foreground color. The text is antialiased. This will render 
        ///	slower than 
        ///	Solid, but in about the same time as Blended mode. The resulting 
        ///	surface should blit as fast as Solid, once it is made. Use this 
        ///	when you need nice text, and can live with a box... 
        ///		Blended 
        ///			Slow Slow Slow, but Ultra Nice over another image
        ///		Create a 32-bit ARGB surface and render the given text 
        ///		at high quality, using alpha blending to dither the font 
        ///		with the given color. This results in a surface with alpha
        ///		 transparency, so you don't have a solid colored box around 
        ///		 the text. The text 
        ///		is antialiased. This will render slower than Solid, but 
        ///		in about the same time as Shaded mode. The resulting 
        ///		surface will blit slower than if you had used Solid 
        ///		or Shaded. Use this when you want high quality,
        ///		 and the text isn't changing too fast.
        /// </remarks>
        [DllImport(SDL_TTF_NATIVE_LIBRARY,
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_RenderText_Solid(
            IntPtr font, string text, Sdl.SDL_Color fg);

        /// <summary>
        /// Draw UTF8 text in solid mode.
        /// Create an 8-bit palettized surface and render the given text at
        /// fast quality with the given font and color.  The 0 pixel is the	
        /// colorkey, giving a transparent background, and the 1 pixel is set
        /// to the text color.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="fg"></param>
        /// <returns>
        /// This function returns the new surface, 
        /// or NULL if there was an error.
        /// </returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_RenderUTF8_Solid(
            IntPtr font, 
            string text, Sdl.SDL_Color fg);

        /// <summary>
        /// Draw UNICODE text in solid mode.
        /// Create an 8-bit palettized surface and render the given text at
        /// fast quality with the given font and color.  The 0 pixel is the
        /// colorkey, giving a transparent background, and the 1 pixel is set
        /// to the text color.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="fg"></param>
        /// <returns>
        /// This function returns the new surface, 
        /// or NULL if there was an error.
        /// </returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_RenderUNICODE_Solid(
            IntPtr font, 
            [MarshalAs(UnmanagedType.LPWStr)] 
            string text, 
            Sdl.SDL_Color fg);

        /// <summary>
        /// Draw a UNICODE glyph in solid mode.
        /// Create an 8-bit palettized surface and render the given glyph at
        /// fast quality with the given font and color.  The 0 pixel is the
        /// colorkey, giving a transparent background, and the 1 pixel is set
        /// to the text color.  The glyph is rendered without any padding or
        /// centering in the X direction, 
        /// and aligned normally in the Y direction.
        /// This function returns the new surface, 
        /// or NULL if there was an error.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="ch"></param>
        /// <param name="fg"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_RenderGlyph_Solid(
            IntPtr font, 
            short ch, 
            Sdl.SDL_Color fg);
		
        /// <summary>
        /// Draw LATIN1 text in shaded mode.
        /// Create an 8-bit palettized surface and render the given text at
        /// high quality with the given font and colors.  
        /// The 0 pixel is background,
        /// while other pixels have varying degrees of the foreground color.
        /// This function returns the new surface, 
        /// or NULL if there was an error.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="fg"></param>
        /// <param name="bg"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_RenderText_Shaded(
            IntPtr font, string text, 
            Sdl.SDL_Color fg, Sdl.SDL_Color bg);

        /// <summary>
        /// Draw UTF8 text in shaded mode.
        /// Create an 8-bit palettized surface and render the given text at
        /// high quality with the given font and colors.  
        /// The 0 pixel is background,
        /// while other pixels have varying degrees of the foreground color.
        /// This function returns the new surface, 
        /// or NULL if there was an error.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="fg"></param>
        /// <param name="bg"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_RenderUTF8_Shaded(
            IntPtr font, string text, 
            Sdl.SDL_Color fg, Sdl.SDL_Color bg);
		
        /// <summary>
        /// Draw UNICODE text in shaded mode.
        /// Create an 8-bit palettized surface and render the given text at
        /// high quality with the given font and colors.  
        /// The 0 pixel is background,
        /// while other pixels have varying degrees of the foreground color.
        /// This function returns the new surface, 
        /// or NULL if there was an error.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="fg"></param>
        /// <param name="bg"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_RenderUNICODE_Shaded(
            IntPtr font, 
            [MarshalAs(UnmanagedType.LPWStr)] 
            string text, 
            Sdl.SDL_Color fg, 
            Sdl.SDL_Color bg);

        /// <summary>
        /// Draw a UNICODE glyph in shaded mode.
        /// Create an 8-bit palettized surface and render the given glyph at
        /// high quality with the given font and colors.  
        /// The 0 pixel is background,
        /// while other pixels have varying degrees of the foreground color.
        /// The glyph is rendered without any padding or centering in the X
        /// direction, and aligned normally in the Y direction.
        /// This function returns the new surface, 
        /// or NULL if there was an error.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="ch"></param>
        /// <param name="fg"></param>
        /// <param name="bg"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_RenderGlyph_Shaded(
            IntPtr font, short ch, 
            Sdl.SDL_Color fg, Sdl.SDL_Color bg);

        /// <summary>
        /// Draw LATIN1 text in blended mode.
        /// Create a 32-bit ARGB surface and render the 
        /// given text at high quality,
        /// using alpha blending to dither the font with the given color.
        /// This function returns the new surface, 
        /// or NULL if there was an error.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="fg"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_RenderText_Blended(
            IntPtr font, string text, Sdl.SDL_Color fg);

        /// <summary>
        /// Draw UTF8 text in blended mode.
        /// Create a 32-bit ARGB surface and render the 
        /// given text at high quality,
        /// using alpha blending to dither the font with the given color.
        /// This function returns the new surface, 
        /// or NULL if there was an error.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="fg"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_RenderUTF8_Blended(
            IntPtr font, string text, Sdl.SDL_Color fg);

        /// <summary>
        /// Draw UNICODE text in blended mode.
        /// Create a 32-bit ARGB surface and render the 
        /// given text at high quality,
        /// using alpha blending to dither the font with the given color.
        /// This function returns the new surface, 
        /// or NULL if there was an error.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="fg"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_RenderUNICODE_Blended(
            IntPtr font, 
            [MarshalAs(UnmanagedType.LPWStr)] string text,
            Sdl.SDL_Color fg);

        /// <summary>
        /// Draw a UNICODE glyph in blended mode.
        /// Create a 32-bit ARGB surface and render the 
        /// given glyph at high quality,
        /// using alpha blending to dither the font with the given color.
        /// The glyph is rendered without any padding or centering in the X
        /// direction, and aligned normally in the Y direction.
        /// This function returns the new surface, 
        /// or NULL if there was an error.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="ch"></param>
        /// <param name="fg"></param>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr TTF_RenderGlyph_Blended(
            IntPtr font, 
            short ch, 
            Sdl.SDL_Color fg);

        /// <summary>
        /// Close an opened font file
        /// </summary>
        /// <remarks>
        /// Free the memory used by font, and free font itself as well. 
        /// Do not use font after this without loading a new font to it.
        /// </remarks>
        /// <param name="font">
        /// Pointer to the TTF_Font to free.
        /// </param>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern void TTF_CloseFont(IntPtr font);

        /// <summary>
        /// De-initialize the TTF engine
        /// </summary>
        /// <remarks>
        /// Shutdown and cleanup the truetype font API.
        /// After calling this the SDL_ttf functions should not be used, 
        /// excepting TTF_WasInit. You may, of course, 
        /// use TTF_Init to use the functionality again. 
        /// </remarks>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern void TTF_Quit();

        /// <summary>
        /// Check if the TTF engine is initialized.
        /// </summary>
        /// <remarks>
        /// Query the initilization status of the truetype font API.
        /// You may, of course, use this before TTF_Init to avoid 
        /// initilizing twice in a row. Or use this to determine 
        /// if you need to call TTF_Quit. 
        /// </remarks>
        /// <returns></returns>
        [DllImport(SDL_TTF_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern int TTF_WasInit();
    }
}
