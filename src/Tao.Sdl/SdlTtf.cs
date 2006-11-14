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
	/// This library supports Sdl_ttf 2.0.8.
	/// This library is a wrapper around the excellent FreeType 1.2 library,
	///  available at: http://www.freetype.org
	/// <p>
	///	WARNING: There may be patent issues with using the FreeType library.
	///	 Check the FreeType website for up-to-date details. 
	///	 </p>
	///	 <p>
	///	This library allows you to use TrueType fonts to render text in SDL
	///	 applications. 
	/// </p>
	/// <p>
	///	Be careful when including fonts with your application, as many of 
	///	them are copyrighted. 
	///	The Microsoft fonts, for example, are not freely redistributable 
	///	and even the free "web" 
	///	fonts they provide are only redistributable in their special 
	///	executable installer form (May 1998). 
	///	There are plenty of freeware and shareware fonts available on the 
	///	Internet though, and may suit your purposes. 
	///	</p>
	/// </summary>
	/// <remarks>
	/// SDL_ttf supports loading fonts from TrueType font files, 
	/// normally ending in .ttf, though some .fon files are also valid for 
	/// use. Note that most fonts are copyrighted, check the license on the 
	/// font before you use and redistribute
	/// </remarks>
	#endregion Class Documentation
	[SuppressUnmanagedCodeSecurityAttribute()]
	public static class SdlTtf 
	{
		#region Private Constants
		#region string SDL_TTF_NATIVE_LIBRARY
		/// <summary>
		///     Specifies SdlTtf's native library archive.
		/// </summary>
		/// <remarks>
		///     Specifies SDL_ttf.dll everywhere; will be mapped via .config for mono.
		/// </remarks>
		private const string SDL_TTF_NATIVE_LIBRARY = "SDL_ttf.dll";
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
		/// Major Version
		/// </summary>
		public const int TTF_MAJOR_VERSION = 2;
		/// <summary>
		/// Minor Version
		/// </summary>
		public const int TTF_MINOR_VERSION = 0;
		/// <summary>
		/// Patch Version
		/// </summary>
		public const int TTF_PATCHLEVEL = 8;
		/// <summary>
		/// Used to indicate regular, normal, plain rendering style.
		/// </summary>
		public const byte TTF_STYLE_NORMAL = 0x00;
		/// <summary>
		/// Used to indicate bold rendering style. 
		/// This is used a bitmask along with other styles.
		/// </summary>
		public const byte TTF_STYLE_BOLD = 0x01;
		/// <summary>
		/// Used to indicate italicized rendering style. 
		/// This is used a bitmask along with other styles.
		/// </summary>
		public const byte TTF_STYLE_ITALIC = 0x02;
		/// <summary>
		/// Used to indicate underlined rendering style. 
		/// This is used a bitmask along with other styles.
		/// </summary>
		public const byte TTF_STYLE_UNDERLINE = 0x04;
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
		#region TTF_Font
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
		/// <p>Struct in SDL_ttf.h
		/// <code>struct _TTF_Font TTF_Font;
		/// </code></p>
		/// </remarks>
		public struct TTF_Font 
		{
		}
		#endregion TTF_Font
		#endregion Public Structs
	
		#region SdlTtf Methods
		#region SDL_version TTF_VERSION() 
		/// <summary>
		/// This method can be used to fill a version structure with the compile-time
		/// version of the SDL_ttf library.
		/// </summary>
		/// <returns>
		///     This function returns a <see cref="Sdl.SDL_version"/> struct containing the
		///     compiled version number
		/// </returns>
		/// <remarks>
		///     <p>
		///     Binds to C-function call in SDL_ttf.h:
		///     <code>#define SDL_TTF_VERSION(X)
		/// {
		/// (X)->major = SDL_TTF_MAJOR_VERSION;
		/// (X)->minor = SDL_TTF_MINOR_VERSION;
		/// (X)->patch = SDL_TTF_PATCHLEVEL;
		/// }</code>
		///     </p>
		/// </remarks>
		public static Sdl.SDL_version TTF_VERSION() 
		{ 
			Sdl.SDL_version sdlVersion = new Sdl.SDL_version();
			sdlVersion.major = TTF_MAJOR_VERSION;
			sdlVersion.minor = TTF_MINOR_VERSION;
			sdlVersion.patch = TTF_PATCHLEVEL;
			return sdlVersion;
		} 
		#endregion SDL_version TTF_VERSION() 

		#region IntPtr TTF_Linked_VersionInternal()
		//     const SDL_version * TTF_Linked_Version(void)
		[DllImport(SDL_TTF_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="TTF_Linked_Version"), SuppressUnmanagedCodeSecurity]
		private static extern IntPtr TTF_Linked_VersionInternal();
		#endregion IntPtr TTF_Linked_VersionInternal()

		#region SDL_version TTF_Linked_Version() 
		/// <summary>
		///     Using this you can compare the runtime version to the 
		/// version that you compiled with.
		/// </summary>
		/// <returns>
		///     This function gets the version of the dynamically 
		/// linked SDL_ttf library in an <see cref="Sdl.SDL_version"/> struct.
		/// </returns>
		/// <remarks>
		///     <p>
		///     Binds to C-function call in SDL_ttf.h:
		///     <code>const SDL_version * TTF_Linked_Version(void)</code>
		///     </p>
		/// </remarks>
		public static Sdl.SDL_version TTF_Linked_Version() 
		{ 
			return (Sdl.SDL_version)Marshal.PtrToStructure(
				TTF_Linked_VersionInternal(), 
				typeof(Sdl.SDL_version)); 
		} 
		#endregion SDL_version TTF_Linked_Version() 

		#region void TTF_ByteSwappedUNICODE(int swapped)
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
		///  <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  void TTF_ByteSwappedUNICODE(int swapped)
		///  </code></p>
		/// </remarks>
		/// <param name="swapped">
		/// if non-zero then UNICODE data is byte swapped relative to the 
		/// CPU's native endianess.<p>
		/// if zero, then do not swap UNICODE data, 
		/// use the CPU's native endianess.</p>
		/// </param>
		/// <example>
		/// <code>
		/// // Turn on byte swapping for UNICODE text
		/// TTF_ByteSwappedUNICODE(1);
		/// </code>
		/// </example>
		/// <returns></returns>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void TTF_ByteSwappedUNICODE(int swapped);
		#endregion void TTF_ByteSwappedUNICODE(int swapped)

		#region int TTF_Init()
		/// <summary>
		/// Initialize the TTF engine - returns 0 if successful, -1 on error
		/// </summary>
		/// <remarks>
		/// Initialize the truetype font API.
		/// <p>
		/// This must be called before using other functions in this 
		/// library, excepting TTF_WasInit.</p>
		/// <p>
		/// SDL does not have to be initialized before this call.</p>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  int TTF_Init()
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// if(TTF_Init()==-1) {
		///		printf("TTF_Init: %s\n", TTF_GetError());
		///		exit(2);
		///	}
		/// </code>
		/// </example>
		/// <returns>
		/// 0 on success, -1 on errors 
		/// </returns>
		/// <seealso cref="TTF_WasInit"/>
		/// <seealso cref="TTF_Quit"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int TTF_Init();
		#endregion int TTF_Init()

		#region IntPtr TTF_OpenFont(string file, int ptsize)
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
		///  <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  TTF_Font *TTF_OpenFont(const char *file, int ptsize)
		///  </code></p>
		///  </remarks>
		///  <example>
		/// <code>
		/// // load font.ttf at size 16 into font
		///		TTF_Font *font;
		///		font=TTF_OpenFont("font.ttf", 16);
		///		if(!font) 
		///	{
		///		printf("TTF_OpenFont: %s\n", TTF_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <returns>
		/// a pointer to the font as a TTF_Font. NULL is returned on errors.
		/// </returns>
		/// <seealso cref="TTF_OpenFontIndex"/>
		/// <seealso cref="TTF_OpenFontRW"/>
		/// <seealso cref="TTF_CloseFont"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_OpenFont(string file, int ptsize);
		#endregion IntPtr TTF_OpenFont(string file, int ptsize)

		#region IntPtr TTF_OpenFontIndex(string file, int ptsize, long index)
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
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  TTF_Font *TTF_OpenFontIndex(const char *file, int ptsize, long index)
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load font.ttf, face 0, at size 16 into font
		///		TTF_Font *font;
		///		font=TTF_OpenFontIndex("font.ttf", 16, 0);
		///		if(!font) 
		///	{
		///		printf("TTF_OpenFontIndex: %s\n", TTF_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <returns>
		/// a pointer to the font as a TTF_Font. NULL is returned on errors.
		/// </returns>
		/// <seealso cref="TTF_OpenFontIndexRW"/>
		/// <seealso cref="TTF_OpenFont"/>
		/// <seealso cref="TTF_CloseFont"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_OpenFontIndex(
			string file, int ptsize, long index);
		#endregion IntPtr TTF_OpenFontIndex(string file, int ptsize, long index)

		#region IntPtr TTF_OpenFontRW(IntPtr src, int freesrc, int ptsize)
		/// <summary>
		/// Open a font file suing RWOps and create a font of the specified point size.
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
		/// <p>
		/// NOTE: src is not checked for NULL, so be careful.</p>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  TTF_Font *TTF_OpenFontRW(SDL_RWops *src, int freesrc, int ptsize)
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load font.ttf at size 16 into font
		///		TTF_Font *font;
		///		font=TTF_OpenFontRW(SDL_RWFromFile("font.ttf"), 1, 16);
		///		if(!font) 
		///	{
		///		printf("TTF_OpenFontRW: %s\n", TTF_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <returns>
		/// a pointer to the font as a TTF_Font. NULL is returned on errors.
		/// </returns>
		/// <seealso cref="TTF_OpenFontIndexRW"/>
		/// <seealso cref="TTF_OpenFont"/>
		/// <seealso cref="TTF_CloseFont"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_OpenFontRW(
			IntPtr src, 
			int freesrc, 
			int ptsize);
		#endregion IntPtr TTF_OpenFontRW(IntPtr src, int freesrc, int ptsize)

		#region IntPtr TTF_OpenFontIndexRW(...)
		/// <summary>
		/// Open a font file using RWOps with an index and create 
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
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  TTF_Font *TTF_OpenFontIndexRW(SDL_RWops *src, int freesrc, int ptsize, long index)
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load font.ttf, face 0, at size 16 into font
		///		TTF_Font *font;
		///		font=TTF_OpenFontRW(SDL_RWFromFile("font.ttf"), 1, 16, 0);
		///		if(!font) 
		///	{
		///		printf("TTF_OpenFontIndexRW: %s\n", TTF_GetError());
		///		// handle error
		///	}
		/// </code>
		/// </example>
		/// <returns>
		/// a pointer to the font as a TTF_Font. NULL is returned on errors.
		/// </returns>
		/// <seealso cref="TTF_OpenFontIndex"/>
		/// <seealso cref="TTF_OpenFontRW"/>
		/// <seealso cref="TTF_CloseFont"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_OpenFontIndexRW(
			IntPtr src, int freesrc, int ptsize, long index);
		#endregion IntPtr TTF_OpenFontIndexRW(...)

		#region void TTF_SetFontStyle(IntPtr font, int style)
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
		/// <p>
		/// NOTE: Passing a NULL font into this function will cause a segfault.
		/// </p>
		/// <p>
		/// NOTE: This will flush the internal cache of previously rendered
		///  glyphs, even if there is no change in style, so it may be best 
		///  to check the current style using TTF_GetFontStyle first.
		///  </p>
		/// <p>
		/// NOTE: I've seen that combining TTF_STYLE_UNDERLINE with anything 
		/// can cause a segfault, other combinations may also do this. 
		/// Some brave soul may find the cause of this and fix it...
		/// </p>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  void TTF_SetFontStyle(TTF_Font *font, int style)
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // set the loaded font's style to bold italics
		///		//TTF_Font *font;
		///		TTF_SetFontStyle(font, TTF_STYLE_BOLD|TTF_STYLE_ITALIC);
		///
		///		// render some text in bold italics...
		///
		///		// set the loaded font's style back to normal
		///		TTF_SetFontStyle(font, TTF_STYLE_NORMAL);
		/// </code>
		/// </example>
		/// <seealso cref="TTF_GetFontStyle"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void TTF_SetFontStyle(IntPtr font, int style);
		#endregion void TTF_SetFontStyle(IntPtr font, int style)

		#region int TTF_GetFontStyle(IntPtr font)
		/// <summary>
		/// Retrieve the font style
		/// This font style is implemented by modifying the font glyphs, and
		/// doesn't reflect any inherent properties of the truetype font file.
		/// </summary>
		/// <remarks>
		/// Get the rendering style of the loaded font.
		///<p>
		/// NOTE: Passing a NULL font into this function will cause a segfault.
		/// </p>
		/// </remarks>
		/// <param name="font">The loaded font to get the style of </param>
		/// <returns>
		/// The style as a bitmask composed of the following masks:
		/// <br>TTF_STYLE_BOLD</br>
		/// <br>TTF_STYLE_ITALIC</br>
		/// <br>TTF_STYLE_UNDERLINE</br>
		/// <p>If no style is set then TTF_STYLE_NORMAL is returned.</p>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  int TTF_GetFontStyle(TTF_Font *font)
		///  </code></p>
		/// </returns>
		/// <example>
		/// <code>
		/// // get the loaded font's style
		///		//TTF_Font *font;
		///		int style;
		///		style=TTF_GetFontStyle(font);
		///		printf("The font style is:");
		///		if(style==TTF_STYLE_NORMAL)
		///		printf(" normal");
		///		else 
		///	{
		///		if(style&amp;TTF_STYLE_BOLD)
		///		printf(" bold");
		///		if(style&amp;TTF_STYLE_ITALIC)
		///		printf(" italic");
		///		if(style&amp;TTF_STYLE_UNDERLINE)
		///		printf(" underline");
		///	}
		///	printf("\n");
		/// </code>
		/// </example>
		/// <seealso cref="TTF_SetFontStyle"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int TTF_GetFontStyle(IntPtr font);
		#endregion int TTF_GetFontStyle(IntPtr font)

		#region int TTF_FontHeight(IntPtr font)
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
		/// <p>
		/// NOTE: Passing a NULL font into this function will cause a segfault.</p>
		/// </remarks>
		/// <returns>
		/// The maximum pixel height of all glyphs in the font.
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  int TTF_FontHeight(TTF_Font *font)
		///  </code></p>
		/// </returns>
		/// <example>
		/// <code>
		/// // get the loaded font's max height
		///		//TTF_Font *font;
		///		printf("The font max height is: %d\n", TTF_FontHeight(font));
		/// </code>
		/// </example>
		/// <seealso cref="TTF_FontAscent"/>
		/// <seealso cref="TTF_FontDescent"/>
		/// <seealso cref="TTF_FontLineSkip"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int TTF_FontHeight(IntPtr font);
		#endregion int TTF_FontHeight(IntPtr font)

		#region int TTF_FontAscent(IntPtr font)
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
		/// <p>
		/// It could be used when drawing an individual glyph relative to 
		/// a top point, by combining it with the glyph's maxy metric to 
		/// resolve the top of the rectangle used when blitting the glyph 
		/// on the screen.</p>
		/// <p>
		/// rect.y = top + TTF_FontAscent(font) - glyph_metric.maxy;
		/// </p>
		/// <p>NOTE: Passing a NULL font into this function will 
		/// cause a segfault.</p>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  int TTF_FontAscent(TTF_Font *font)
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // get the loaded font's max ascent
		///		//TTF_Font *font;
		///
		///		printf("The font ascent is: %d\n", TTF_FontAscent(font));
		/// </code>
		/// </example>
		/// <returns>
		/// The maximum pixel ascent of all glyphs in the font.
		/// </returns>
		/// <seealso cref="TTF_FontHeight"/>
		/// <seealso cref="TTF_FontDescent"/>
		/// <seealso cref="TTF_FontLineSkip"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int TTF_FontAscent(IntPtr font);
		#endregion int TTF_FontAscent(IntPtr font)

		#region int TTF_FontDescent(IntPtr font)
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
		/// <p>
		/// rect.y = bottom - TTF_FontDescent(font) - glyph_metric.maxy;
		/// </p>
		/// <p>NOTE: Passing a NULL font into this function will cause a segfault.</p>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  int TTF_FontDescent(TTF_Font *font)
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // get the loaded font's max descent
		///		//TTF_Font *font;
		///
		///		printf("The font descent is: %d\n", TTF_FontDescent(font));
		/// </code>
		/// </example>
		/// <returns>
		/// The maximum pixel height of all glyphs in the font.
		/// </returns>
		/// <seealso cref="TTF_FontHeight"/>
		/// <seealso cref="TTF_FontAscent"/>
		/// <seealso cref="TTF_FontLineSkip"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int TTF_FontDescent(IntPtr font);
		#endregion int TTF_FontDescent(IntPtr font)

		#region int TTF_FontLineSkip(IntPtr font)
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
		/// <p>
		/// NOTE: Passing a NULL font into this function will cause a segfault.
		/// </p>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  int TTF_FontLineSkip(TTF_Font *font)
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // get the loaded font's max descent
		///		//TTF_Font *font;
		///
		///		printf("The font descent is: %d\n", TTF_FontDescent(font));
		/// </code>
		/// </example>
		/// <returns>
		/// The maximum pixel height of all glyphs in the font.
		/// </returns>
		/// <seealso cref="TTF_FontHeight"/>
		/// <seealso cref="TTF_FontAscent"/>
		/// <seealso cref="TTF_FontDescent"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int TTF_FontLineSkip(IntPtr font);
		#endregion int TTF_FontLineSkip(IntPtr font)

		#region long TTF_FontFaces(IntPtr font)
		/// <summary>
		/// Get the number of faces of the font
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  long TTF_FontFaces(TTF_Font *font)
		///  </code></p>
		///  </remarks>
		///  <example>
		/// <code>
		/// 
		/// </code>
		/// </example>
		/// <param name="font"></param>
		/// <returns>Number of faces in a font</returns>
		/// <seealso cref="TTF_FontFaceIsFixedWidth"/>
		/// <seealso cref="TTF_FontFaceFamilyName"/>
		/// <seealso cref="TTF_FontFaceStyleName"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern long TTF_FontFaces(IntPtr font);
		#endregion long TTF_FontFaces(IntPtr font)

		#region int TTF_FontFaceIsFixedWidth(IntPtr font)
		/// <summary>
		/// Get whether font is monospaced or not.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  int TTF_FontFaceIsFixedWidth(TTF_Font *font)
		///  </code></p>
		///  </remarks>
		///  <example>
		/// <code>
		/// 
		/// </code>
		/// </example>
		/// <param name="font"></param>
		/// <returns>1 if true, 0 if false</returns>
		/// <seealso cref="TTF_FontFaces"/>
		/// <seealso cref="TTF_FontFaceFamilyName"/>
		/// <seealso cref="TTF_FontFaceStyleName"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int TTF_FontFaceIsFixedWidth(IntPtr font);
		#endregion int TTF_FontFaceIsFixedWidth(IntPtr font)

		#region string TTF_FontFaceFamilyName(IntPtr font)
		/// <summary>
		/// Get current font face family name string.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  char * TTF_FontFaceFamilyName(TTF_Font *font)
		///  </code></p>
		///  </remarks>
		///  <example>
		/// <code>
		/// 
		/// </code>
		/// </example>
		/// <param name="font"></param>
		/// <returns>Name of font family</returns>
		/// <seealso cref="TTF_FontFaces"/>
		/// <seealso cref="TTF_FontFaceIsFixedWidth"/>
		/// <seealso cref="TTF_FontFaceStyleName"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern string TTF_FontFaceFamilyName(IntPtr font);
		#endregion string TTF_FontFaceFamilyName(IntPtr font)

		#region string TTF_FontFaceStyleName(IntPtr font)
		/// <summary>
		/// Get current font face style name string.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  char * TTF_FontFaceStyleName(TTF_Font *font)
		///  </code></p>
		///  </remarks>
		///  <example>
		/// <code>
		/// 
		/// </code>
		/// </example>
		/// <param name="font"></param>
		/// <returns></returns>
		/// <seealso cref="TTF_FontFaces"/>
		/// <seealso cref="TTF_FontFaceIsFixedWidth"/>
		/// <seealso cref="TTF_FontFaceFamilyName"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern string TTF_FontFaceStyleName(IntPtr font);
		#endregion string TTF_FontFaceStyleName(IntPtr font)

		#region int TTF_GlyphMetrics(...)
		/// <summary>
		/// Get individual font glyph metrics 
		/// </summary>
		/// <remarks>
		/// To understand what these metrics mean, here is a useful link:
		/// http://freetype.sourceforge.net/freetype2/docs/tutorial/step2.html
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  int TTF_GlyphMetrics(TTF_Font *font, Uint16 ch, int *minx, int *maxx, int *miny, int *maxy, int *advance)
		///  </code></p>
		///  </remarks>
		///  <example>
		/// <code>
		/// 
		/// </code>
		/// </example>
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
			out int minx, 
			out int maxx, 
			out int miny, 
			out int maxy, 
			out int advance);
		#endregion int TTF_GlyphMetrics(...)

		#region int TTF_SizeText(...)
		/// <summary>
		/// Get size of LATIN1 text string as would be rendered 
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  int TTF_SizeText(TTF_Font *font, const char *text, int *w, int *h)
		///  </code></p>
		///  </remarks>
		///  <example>
		/// <code>
		/// 
		/// </code>
		/// </example>
		/// <param name="font"></param>
		/// <param name="text"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <returns></returns>
		/// <seealso cref="TTF_SizeUTF8"/>
		/// <seealso cref="TTF_SizeUNICODE"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int TTF_SizeText(
			IntPtr font, 
			[MarshalAs(UnmanagedType.LPWStr)] string text, 
			out int w, out int h);
		#endregion int TTF_SizeText(...)

		#region int TTF_SizeUTF8(...)
		/// <summary>
		/// Get size of UTF8 text string as would be rendered
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  int SDLCALL TTF_SizeUTF8(TTF_Font *font, const char *text, int *w, int *h)
		///  </code></p>
		///  </remarks>
		///  <example>
		/// <code>
		/// 
		/// </code>
		/// </example>
		/// <param name="font"></param>
		/// <param name="text"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <returns></returns>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_SizeUNICODE"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int TTF_SizeUTF8(
			IntPtr font, 
			[MarshalAs(UnmanagedType.LPWStr)] string text, 
			out int w, out int h);
		#endregion int TTF_SizeUTF8(...)

		#region int TTF_SizeUNICODE(...)
		/// <summary>
		/// Get size of UNICODE text string as would be rendered 
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  int SDLCALL TTF_SizeUNICODE(TTF_Font *font, const Uint16 *text, int *w, int *h)
		///  </code></p>
		///  </remarks>
		///  <example>
		/// <code>
		/// 
		/// </code>
		/// </example>
		/// <param name="font"></param>
		/// <param name="text"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <returns></returns>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_SizeUTF8"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int TTF_SizeUNICODE(
			IntPtr font, 
			[MarshalAs(UnmanagedType.LPWStr)] string text, 
			out int w, 
			out int h);
		#endregion int TTF_SizeUNICODE(...)

		#region IntPtr TTF_RenderText_Solid(...)
		/// <summary>
		/// Draw LATIN1 text in solid mode.
		/// </summary>
		/// <param name="font">
		/// Font to render the text with.
		///  A NULL pointer is not checked.
		///  </param>
		/// <param name="text">
		/// The LATIN1 null terminated string to render.
		/// </param>
		/// <param name="fg">
		/// The color to render the text in. This becomes colormap index 1.
		/// </param>
		/// <returns>
		/// a pointer to a new SDL_Surface. 
		/// NULL is returned on errors.
		/// </returns>
		/// <remarks>
		/// <p>This function renders text using a TTF_Font.
		/// This mode of rendering is:</p>
		///	<p>Solid</p>
		///	<p>Quick and Dirty</p>
		///	<p>Create an 8-bit palettized surface and render the given
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
		/// Use this mode for FPS and other fast changing updating text displays.</p> 
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  SDL_Surface * TTF_RenderText_Solid(TTF_Font *font, const char *text, SDL_Color fg)
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // Turn on byte swapping for UNICODE text
		///		SDL_Surface *text_surface;
		///		if(!(text_surface=TTF_RenderText_Solid(font,"Hello World!", &amp;color))) 
		///	{
		///		//handle error here, perhaps print TTF_GetError at least
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_RenderUTF8_Solid"/>
		/// <seealso cref="TTF_RenderUNICODE_Solid"/>
		/// <seealso cref="TTF_RenderGlyph_Solid"/>
		/// <seealso cref="TTF_RenderText_Shaded"/>
		/// <seealso cref="TTF_RenderText_Blended"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY,
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_RenderText_Solid(
			IntPtr font, string text, Sdl.SDL_Color fg);
		#endregion IntPtr TTF_RenderText_Solid(...)

		#region IntPtr TTF_RenderUTF8_Solid(...)
		/// <summary>
		/// Draw UTF8 text in solid mode.
		/// </summary>
		/// <remarks>
		/// <p>This function renders text using a TTF_Font.
		/// This mode of rendering is:</p>
		///	<p>Solid</p>
		///	<p>Quick and Dirty</p>
		///	<p>Create an 8-bit palettized surface and render the given
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
		/// Use this mode for FPS and other fast changing updating text displays.</p> 
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  SDL_Surface * TTF_RenderUTF8_Solid(TTF_Font *font,const char *text, SDL_Color fg)
		///  </code></p>
		///  </remarks>
		/// <param name="font">
		/// Font to render the text with.
		///  A NULL pointer is not checked.
		///  </param>
		/// <param name="text">
		/// The UTF8 null terminated string to render.
		/// </param>
		/// <param name="fg">
		/// The color to render the text in. This becomes colormap index 1.
		/// </param>
		/// <returns>
		/// a pointer to a new SDL_Surface. 
		/// NULL is returned on errors.
		/// </returns>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_RenderText_Solid"/>
		/// <seealso cref="TTF_RenderUNICODE_Solid"/>
		/// <seealso cref="TTF_RenderGlyph_Solid"/>
		/// <seealso cref="TTF_RenderText_Shaded"/>
		/// <seealso cref="TTF_RenderText_Blended"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_RenderUTF8_Solid(
			IntPtr font, 
			string text, Sdl.SDL_Color fg);
		#endregion IntPtr TTF_RenderUTF8_Solid(...)

		#region IntPtr TTF_RenderUNICODE_Solid(...)
		/// <summary>
		/// Draw UNICODE text in solid mode.
		/// </summary>
		/// <remarks>
		/// <p>This function renders text using a TTF_Font.
		/// This mode of rendering is:</p>
		///	<p>Solid</p>
		///	<p>Quick and Dirty</p>
		///	<p>Create an 8-bit palettized surface and render the given
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
		/// Use this mode for FPS and other fast changing updating text displays.</p> 
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  SDL_Surface * SDLCALL TTF_RenderUNICODE_Solid(TTF_Font *font, const Uint16 *text, SDL_Color fg)
		///  </code></p>
		///  </remarks>
		/// <param name="font">
		/// Font to render the text with.
		///  A NULL pointer is not checked.
		///  </param>
		/// <param name="text">
		/// The UNICODE null terminated string to render.
		/// </param>
		/// <param name="fg">
		/// The color to render the text in. This becomes colormap index 1.
		/// </param>
		/// <returns>
		/// This function returns the new surface, 
		/// or NULL if there was an error.
		/// </returns>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_RenderText_Solid"/>
		/// <seealso cref="TTF_RenderUTF8_Solid"/>
		/// <seealso cref="TTF_RenderGlyph_Solid"/>
		/// <seealso cref="TTF_RenderText_Shaded"/>
		/// <seealso cref="TTF_RenderText_Blended"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_RenderUNICODE_Solid(
			IntPtr font, 
			[MarshalAs(UnmanagedType.LPWStr)] 
			string text, 
			Sdl.SDL_Color fg);
		#endregion IntPtr TTF_RenderUNICODE_Solid(...)

		#region IntPtr TTF_RenderGlyph_Solid(...)
		/// <summary>
		/// Draw a UNICODE glyph in solid mode.
		/// </summary>
		/// <remarks>
		/// <p>This function renders text using a TTF_Font.
		/// This mode of rendering is:</p>
		///	<p>Solid</p>
		///	<p>Quick and Dirty</p>
		///	<p>Create an 8-bit palettized surface and render the given
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
		/// The glyph is rendered without any padding or
		/// centering in the X direction, 
		/// and aligned normally in the Y direction.
		/// The resulting surface should blit faster than the Blended one. 
		/// Use this mode for FPS and other fast changing updating text displays.</p> 
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  SDL_Surface * SDLCALL TTF_RenderGlyph_Solid(TTF_Font *font, Uint16 ch, SDL_Color fg)
		///  </code></p>
		///  </remarks>
		/// <param name="font">Font to render glyph with.
		///  A NULL pointer is not checked.</param>
		/// <param name="ch">
		/// The glyph to render
		/// </param>
		/// <param name="fg">
		/// The color to render the text in. 
		/// This becomes colormap index 1.
		/// </param>
		/// <returns>
		/// This function returns the new surface, 
		/// or NULL if there was an error.
		/// </returns>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_RenderText_Solid"/>
		/// <seealso cref="TTF_RenderUTF8_Solid"/>
		/// <seealso cref="TTF_RenderUNICODE_Solid"/>
		/// <seealso cref="TTF_RenderText_Shaded"/>
		/// <seealso cref="TTF_RenderText_Blended"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_RenderGlyph_Solid(
			IntPtr font, 
			short ch, 
			Sdl.SDL_Color fg);
		#endregion IntPtr TTF_RenderGlyph_Solid(...)

		#region IntPtr TTF_RenderText_Shaded(..)	
		/// <summary>
		/// Draw LATIN1 text in shaded mode.
		/// </summary>
		/// <remarks>
		/// <p>Shaded</p> 
		/// <p>Slow and Nice, but with a Solid Box</p>
		/// <p>Create an 8-bit palettized surface and render the 
		/// given text at high quality with the given font and colors.
		///  The 0 pixel value is background, while other pixels have 
		///  varying degrees of the foreground color from the background
		///   color. This results in a box of the background color around
		///    the text in the foreground color. The text is antialiased.
		///     This will render slower than Solid, but in about the same
		///      time as Blended mode. The resulting surface should blit 
		///      as fast as Solid, once it is made. Use this when you need
		///       nice text, and can live with a box...</p>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  SDL_Surface * TTF_RenderText_Shaded(TTF_Font *font, const char *text, SDL_Color fg, SDL_Color bg)
		///  </code></p>
		/// </remarks>
		/// <param name="font">Font to render the text with.
		///  A NULL pointer is not checked.</param>
		/// <param name="fg">
		/// The color to render the text in. 
		/// This becomes colormap index 1.
		/// </param>
		/// <param name="bg">
		/// The background color to render in.
		/// </param>
		/// <param name="text">
		/// The LATIN1 null terminated string to render.
		/// </param>
		/// <returns>
		/// This function returns the new surface, 
		/// or NULL if there was an error.
		/// </returns>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_RenderText_Solid"/>
		/// <seealso cref="TTF_RenderUTF8_Shaded"/>
		/// <seealso cref="TTF_RenderUNICODE_Shaded"/>
		/// <seealso cref="TTF_RenderGlyph_Shaded"/>
		/// <seealso cref="TTF_RenderText_Blended"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_RenderText_Shaded(
			IntPtr font, string text, 
			Sdl.SDL_Color fg, Sdl.SDL_Color bg);
		#endregion IntPtr TTF_RenderText_Shaded(..)

		#region IntPtr TTF_RenderUTF8_Shaded(..)
		/// <summary>
		/// Draw UTF8 text in shaded mode.
		/// </summary>
		/// <remarks>
		/// <p>Shaded</p> 
		/// <p>Slow and Nice, but with a Solid Box</p>
		/// <p>Create an 8-bit palettized surface and render the 
		/// given text at high quality with the given font and colors.
		///  The 0 pixel value is background, while other pixels have 
		///  varying degrees of the foreground color from the background
		///   color. This results in a box of the background color around
		///    the text in the foreground color. The text is antialiased.
		///     This will render slower than Solid, but in about the same
		///      time as Blended mode. The resulting surface should blit 
		///      as fast as Solid, once it is made. Use this when you need
		///       nice text, and can live with a box...</p>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  SDL_Surface * TTF_RenderUTF8_Shaded(TTF_Font *font, const char *text, SDL_Color fg, SDL_Color bg)
		///  </code></p>
		/// </remarks>
		/// <param name="font">Font to render the text with.
		///  A NULL pointer is not checked.</param>
		/// <param name="fg">
		/// The color to render the text in. 
		/// This becomes colormap index 1.
		/// </param>
		/// <param name="bg">
		/// The background color to render in.
		/// </param>
		/// <param name="text">
		/// The UTF8 null terminated string to render.
		/// </param>
		/// <returns>
		/// This function returns the new surface, 
		/// or NULL if there was an error.
		/// </returns>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_RenderText_Solid"/>
		/// <seealso cref="TTF_RenderText_Shaded"/>
		/// <seealso cref="TTF_RenderUNICODE_Shaded"/>
		/// <seealso cref="TTF_RenderGlyph_Shaded"/>
		/// <seealso cref="TTF_RenderText_Blended"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_RenderUTF8_Shaded(
			IntPtr font, string text, 
			Sdl.SDL_Color fg, Sdl.SDL_Color bg);
		#endregion IntPtr TTF_RenderUTF8_Shaded(..)

		#region IntPtr TTF_RenderUNICODE_Shaded(...)	
		/// <summary>
		/// Draw UNICODE text in shaded mode.
		/// </summary>
		/// <remarks>
		/// <p>Shaded</p> 
		/// <p>Slow and Nice, but with a Solid Box</p>
		/// <p>Create an 8-bit palettized surface and render the 
		/// given text at high quality with the given font and colors.
		///  The 0 pixel value is background, while other pixels have 
		///  varying degrees of the foreground color from the background
		///   color. This results in a box of the background color around
		///    the text in the foreground color. The text is antialiased.
		///     This will render slower than Solid, but in about the same
		///      time as Blended mode. The resulting surface should blit 
		///      as fast as Solid, once it is made. Use this when you need
		///       nice text, and can live with a box...</p>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  SDL_Surface * TTF_RenderUNICODE_Shaded(TTF_Font *font, const Uint16 *text, SDL_Color fg, SDL_Color bg)
		///  </code></p>
		/// </remarks>
		/// <param name="font">Font to render the text with.
		///  A NULL pointer is not checked.</param>
		/// <param name="fg">
		/// The color to render the text in. 
		/// This becomes colormap index 1.
		/// </param>
		/// <param name="bg">
		/// The background color to render in.
		/// </param>
		/// <param name="text">
		/// The UNICODE string to render.
		/// </param>
		/// <returns>
		/// This function returns the new surface, 
		/// or NULL if there was an error.
		/// </returns>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_RenderText_Solid"/>
		/// <seealso cref="TTF_RenderText_Shaded"/>
		/// <seealso cref="TTF_RenderUTF8_Shaded"/>
		/// <seealso cref="TTF_RenderGlyph_Shaded"/>
		/// <seealso cref="TTF_RenderText_Blended"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_RenderUNICODE_Shaded(
			IntPtr font, 
			[MarshalAs(UnmanagedType.LPWStr)] 
			string text, 
			Sdl.SDL_Color fg, 
			Sdl.SDL_Color bg);
		#endregion IntPtr TTF_RenderUNICODE_Shaded(...)

		#region IntPtr TTF_RenderGlyph_Shaded(...)
		/// <summary>
		/// Draw a UNICODE glyph in shaded mode.
		/// </summary>
		/// <remarks>
		/// <p>Shaded</p> 
		/// <p>Slow and Nice, but with a Solid Box</p>
		/// <p>Create an 8-bit palettized surface and render the 
		/// given text at high quality with the given font and colors.
		///  The 0 pixel value is background, while other pixels have 
		///  varying degrees of the foreground color from the background
		///   color. This results in a box of the background color around
		///    the text in the foreground color. The text is antialiased.
		///     This will render slower than Solid, but in about the same
		///      time as Blended mode. The resulting surface should blit 
		///      as fast as Solid, once it is made. Use this when you need
		///       nice text, and can live with a box...</p>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  SDL_Surface * TTF_RenderGlyph_Shaded(TTF_Font *font, Uint16 ch, SDL_Color fg, SDL_Color bg)
		///  </code></p>
		/// </remarks>
		/// <param name="font">Font to render the text with.
		///  A NULL pointer is not checked.</param>
		/// <param name="fg">
		/// The color to render the text in. 
		/// This becomes colormap index 1.
		/// </param>
		/// <param name="bg">
		/// The background color to render in.
		/// </param>
		/// <param name="ch">
		/// The glyph to render.
		/// </param>
		/// <returns>
		/// This function returns the new surface, 
		/// or NULL if there was an error.
		/// </returns>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_RenderText_Solid"/>
		/// <seealso cref="TTF_RenderText_Shaded"/>
		/// <seealso cref="TTF_RenderUTF8_Shaded"/>
		/// <seealso cref="TTF_RenderUNICODE_Shaded"/>
		/// <seealso cref="TTF_RenderText_Blended"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_RenderGlyph_Shaded(
			IntPtr font, short ch, 
			Sdl.SDL_Color fg, Sdl.SDL_Color bg);
		#endregion IntPtr TTF_RenderGlyph_Shaded(...)

		#region IntPtr TTF_RenderText_Blended(...)
		/// <summary>
		/// Draw LATIN1 text in blended mode.
		/// </summary>
		/// <param name="font">
		/// Font to render the text with.
		///  A NULL pointer is not checked.
		///  </param>
		/// <param name="text">
		/// The LATIN1 null terminated string to render.
		/// </param>
		/// <param name="fg">
		/// The color to render the text in. This becomes colormap index 1.
		/// </param>
		/// <returns>
		/// a pointer to a new SDL_Surface. 
		/// NULL is returned on errors.
		/// </returns>
		/// <remarks>
		/// <p>This function renders text using a TTF_Font.
		/// This mode of rendering is:</p>
		///	<p>Blended</p>
		///	<p>Slow Slow Slow, but Ultra Nice over another image</p>
		///	<p>Create a 32-bit ARGB surface and render the given text at high
		///	 quality, using alpha blending to dither the font with the given 
		///	 color. This results in a surface with alpha transparency, so you
		///	  don't have a solid colored box around the text. The text is 
		///	  antialiased. This will render slower than Solid, but in about 
		///	  the same time as Shaded mode. The resulting surface will blit 
		///	  slower than if you had used Solid or Shaded. Use this when you
		///	   want high quality, and the text isn't changing too fast.</p> 
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  SDL_Surface * SDLCALL TTF_RenderText_Blended(TTF_Font *font, const char *text, SDL_Color fg)
		///  </code></p>
		/// </remarks>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_RenderUTF8_Blended"/>
		/// <seealso cref="TTF_RenderUNICODE_Blended"/>
		/// <seealso cref="TTF_RenderGlyph_Blended"/>
		/// <seealso cref="TTF_RenderText_Shaded"/>
		/// <seealso cref="TTF_RenderText_Solid"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_RenderText_Blended(
			IntPtr font, string text, Sdl.SDL_Color fg);
		#endregion IntPtr TTF_RenderText_Blended(...)

		#region IntPtr TTF_RenderUTF8_Blended(...)
		/// <summary>
		/// Draw UTF8 text in blended mode.
		/// </summary>
		/// <param name="font">
		/// Font to render the text with.
		///  A NULL pointer is not checked.
		///  </param>
		/// <param name="text">
		/// The UTF8 null terminated string to render.
		/// </param>
		/// <param name="fg">
		/// The color to render the text in. This becomes colormap index 1.
		/// </param>
		/// <returns>
		/// a pointer to a new SDL_Surface. 
		/// NULL is returned on errors.
		/// </returns>
		/// <remarks>
		/// <p>This function renders text using a TTF_Font.
		/// This mode of rendering is:</p>
		///	<p>Blended</p>
		///	<p>Slow Slow Slow, but Ultra Nice over another image</p>
		///	<p>Create a 32-bit ARGB surface and render the given text at high
		///	 quality, using alpha blending to dither the font with the given 
		///	 color. This results in a surface with alpha transparency, so you
		///	  don't have a solid colored box around the text. The text is 
		///	  antialiased. This will render slower than Solid, but in about 
		///	  the same time as Shaded mode. The resulting surface will blit 
		///	  slower than if you had used Solid or Shaded. Use this when you
		///	   want high quality, and the text isn't changing too fast.</p> 
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  SDL_Surface * SDLCALL TTF_RenderUTF8_Blended(TTF_Font *font, const char *text, SDL_Color fg)
		///  </code></p>
		/// </remarks>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_RenderText_Blended"/>
		/// <seealso cref="TTF_RenderUNICODE_Blended"/>
		/// <seealso cref="TTF_RenderGlyph_Blended"/>
		/// <seealso cref="TTF_RenderText_Shaded"/>
		/// <seealso cref="TTF_RenderText_Solid"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_RenderUTF8_Blended(
			IntPtr font, string text, Sdl.SDL_Color fg);
		#endregion IntPtr TTF_RenderUTF8_Blended(...)

		#region IntPtr TTF_RenderUNICODE_Blended(...)
		/// <summary>
		/// Draw UNICODE text in blended mode.
		/// </summary>
		/// <param name="font">
		/// Font to render the text with.
		///  A NULL pointer is not checked.
		///  </param>
		/// <param name="text">
		/// The UNICODE string to render.
		/// </param>
		/// <param name="fg">
		/// The color to render the text in. This becomes colormap index 1.
		/// </param>
		/// <returns>
		/// a pointer to a new SDL_Surface. 
		/// NULL is returned on errors.
		/// </returns>
		/// <remarks>
		/// <p>This function renders text using a TTF_Font.
		/// This mode of rendering is:</p>
		///	<p>Blended</p>
		///	<p>Slow Slow Slow, but Ultra Nice over another image</p>
		///	<p>Create a 32-bit ARGB surface and render the given text at high
		///	 quality, using alpha blending to dither the font with the given 
		///	 color. This results in a surface with alpha transparency, so you
		///	  don't have a solid colored box around the text. The text is 
		///	  antialiased. This will render slower than Solid, but in about 
		///	  the same time as Shaded mode. The resulting surface will blit 
		///	  slower than if you had used Solid or Shaded. Use this when you
		///	   want high quality, and the text isn't changing too fast.</p> 
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  SDL_Surface * TTF_RenderUNICODE_Blended(TTF_Font *font, const Uint16 *text, SDL_Color fg)
		///  </code></p>
		/// </remarks>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_RenderText_Blended"/>
		/// <seealso cref="TTF_RenderUTF8_Blended"/>
		/// <seealso cref="TTF_RenderGlyph_Blended"/>
		/// <seealso cref="TTF_RenderText_Shaded"/>
		/// <seealso cref="TTF_RenderText_Solid"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_RenderUNICODE_Blended(
			IntPtr font, 
			[MarshalAs(UnmanagedType.LPWStr)] string text,
			Sdl.SDL_Color fg);
		#endregion IntPtr TTF_RenderUNICODE_Blended(...)

		#region IntPtr TTF_RenderGlyph_Blended(...)
		/// <summary>
		/// Draw a UNICODE glyph in blended mode.
		/// </summary>
		/// <param name="font">
		/// Font to render the text with.
		///  A NULL pointer is not checked.
		///  </param>
		/// <param name="ch">
		/// The glyph to render.
		/// </param>
		/// <param name="fg">
		/// The color to render the text in. This becomes colormap index 1.
		/// </param>
		/// <returns>
		/// a pointer to a new SDL_Surface. 
		/// NULL is returned on errors.
		/// </returns>
		/// <remarks>
		/// <p>This function renders text using a TTF_Font.
		/// This mode of rendering is:</p>
		///	<p>Blended</p>
		///	<p>Slow Slow Slow, but Ultra Nice over another image</p>
		///	<p>Create a 32-bit ARGB surface and render the given text at high
		///	 quality, using alpha blending to dither the font with the given 
		///	 color. This results in a surface with alpha transparency, so you
		///	  don't have a solid colored box around the text. The text is 
		///	  antialiased. This will render slower than Solid, but in about 
		///	  the same time as Shaded mode. The resulting surface will blit 
		///	  slower than if you had used Solid or Shaded. Use this when you
		///	   want high quality, and the text isn't changing too fast.</p> 
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  SDL_Surface * TTF_RenderUNICODE_Blended(TTF_Font *font, const Uint16 *text, SDL_Color fg)
		///  </code></p>
		/// </remarks>
		/// <seealso cref="TTF_SizeText"/>
		/// <seealso cref="TTF_RenderText_Blended"/>
		/// <seealso cref="TTF_RenderUTF8_Blended"/>
		/// <seealso cref="TTF_RenderUNICODE_Blended"/>
		/// <seealso cref="TTF_RenderText_Shaded"/>
		/// <seealso cref="TTF_RenderText_Solid"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr TTF_RenderGlyph_Blended(
			IntPtr font, 
			short ch, 
			Sdl.SDL_Color fg);
		#endregion IntPtr TTF_RenderGlyph_Blended(...)

		#region void TTF_CloseFont(IntPtr font)
		/// <summary>
		/// Close an opened font file
		/// </summary>
		/// <remarks>
		/// Free the memory used by font, and free font itself as well. 
		/// Do not use font after this without loading a new font to it.
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  void TTF_CloseFont(TTF_Font *font)
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // free the font
		///		// TTF_Font *font;
		///		TTF_CloseFont(font);
		///		font=NULL; // to be safe...
		/// </code>
		/// </example>
		/// <param name="font">
		/// Pointer to the TTF_Font to free.
		/// </param>
		/// <seealso cref="TTF_OpenFont"/>
		/// <seealso cref="TTF_OpenFontIndex"/>
		/// <seealso cref="TTF_OpenFontRW"/>
		/// <seealso cref="TTF_CloseFont"/>
		/// <seealso cref="TTF_OpenFontIndexRW"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void TTF_CloseFont(IntPtr font);
		#endregion void TTF_CloseFont(IntPtr font)

		#region void TTF_Quit()
		/// <summary>
		/// De-initialize the TTF engine
		/// </summary>
		/// <remarks>
		/// Shutdown and cleanup the truetype font API.
		/// <p>After calling this the SDL_ttf functions should not be used, 
		/// excepting TTF_WasInit. You may, of course, 
		/// use TTF_Init to use the functionality again.</p>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  void TTF_Quit() 
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// TTF_Quit();
		/// // you could SDL_Quit(); here...or not.
		/// </code>
		/// </example>
		/// <seealso cref="TTF_Init"/>
		/// <seealso cref="TTF_WasInit"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void TTF_Quit();
		#endregion void TTF_Quit()

		#region int TTF_WasInit()
		/// <summary>
		/// Check if the TTF engine is initialized.
		/// </summary>
		/// <remarks>
		/// Query the initilization status of the truetype font API.
		/// <p>You may, of course, use this before TTF_Init to avoid 
		/// initilizing twice in a row. Or use this to determine 
		/// if you need to call TTF_Quit.</p>
		/// <p>Binds to C-function in SDL_ttf.h
		///  <code>
		///  int TTF_WasInit() 
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// if(!TTF_WasInit() &amp;&amp; TTF_Init()==-1) {
		///		printf("TTF_Init: %s\n", TTF_GetError());
		///		exit(1);
		///	}
		/// </code>
		/// </example>
		/// <returns></returns>
		/// <seealso cref="TTF_Init"/>
		/// <seealso cref="TTF_Quit"/>
		[DllImport(SDL_TTF_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int TTF_WasInit();
		#endregion int TTF_WasInit()

		#region void TTF_SetError(string message)
		/// <summary>
		/// Set the current error string
		/// </summary>
		/// <remarks>
		/// This is the same as SDL_SetError, which sets the error string
		/// which may be fetched with TTF_GetError (or SDL_GetError). 
		/// This functions acts like printf, except that it is limited to
		///  SDL_ERRBUFIZE(1024) chars in length. It only accepts the 
		///  following format types: %s, %d, %f, %p. No variations are 
		///  supported, like %.2f would not work. For any more specifics 
		///  read the SDL docs.
		/// <p>Binds to C-function in SDL_image.h
		/// <code>
		/// void TTF_SetError(const char *fmt, ...)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// int myfunc(int i) {
		///		TTF_SetError("myfunc is not implemented! %d was passed in.",i);
		///		return(-1);
		///	}
		/// </code></example>
		/// <param name="message"></param>
		/// <seealso cref="TTF_GetError"/>
		public static void TTF_SetError(string message)
		{
			Sdl.SDL_SetError(message);
		}
		#endregion void TTF_SetError(string message)

		#region string TTF_GetError()
		/// <summary>
		/// Get the current error string
		/// </summary>
		/// <remarks>
		/// This is the same as SDL_GetError, which returns the last error set 
		/// as a string which you may use to tell the user what happened when 
		/// an error status has been returned from an SDL_ttf function call.
		/// <p>Binds to C-function in SDL_ttf.h
		/// <code>
		/// char *TTF_GetError() 
		/// </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// a char pointer (string) containing a humam 
		/// readable version or the reason for the last error that
		///  occured.
		///  </returns>
		///  <example>
		///  <code>
		///  printf("Oh My Goodness, an error : %s", TTF_GetError());
		///  </code>
		///  </example>
		/// <seealso cref="TTF_SetError"/>
		public static string TTF_GetError()
		{
			return Sdl.SDL_GetError();
		}
		#endregion string TTF_GetError()
		#endregion SdlTtfMethods
	}
}
