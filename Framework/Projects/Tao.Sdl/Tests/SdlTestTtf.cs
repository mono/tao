using System;
using System.Threading;
using NUnit.Framework;
using Tao.Sdl;
using System.Runtime.InteropServices;

namespace Tao.Sdl
{
	#region SDL_ttf.h
	/// <summary>
	/// SDL Tests.
	/// </summary>
	[TestFixture]
	public class SdlTestTtf
	{
		int init;
		int flags;
		int bpp;
		int width;
		int height;
		//IntPtr surfacePtr;
		int sleepTime;

		/// <summary>
		/// 
		/// </summary>
		[SetUp]
		public void Init()
		{
			init = Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			flags = (Sdl.SDL_HWSURFACE|Sdl.SDL_DOUBLEBUF|Sdl.SDL_ANYFORMAT);
			bpp = 16;
			width = 640;
			height = 480;
			sleepTime = 500;
			//surfacePtr = IntPtr.Zero;
			//Sdl.SDL_FreeSurfaceInternal(surfacePtr);
		}
		/// <summary>
		/// 
		/// </summary>
		private IntPtr VideoSetup()
		{
			Sdl.SDL_Quit();
			init = Sdl.SDL_Init(Sdl.SDL_INIT_VIDEO);
			IntPtr surfacePtr;
			//Assert.IsNotNull(surfacePtr);
			//Sdl.SDL_FreeSurface(surfacePtr);
			surfacePtr = Sdl.SDL_SetVideoMode(
				width, 
				height, 
				bpp, 
				flags);
			Assert.IsNotNull(surfacePtr);
			return surfacePtr;
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LinkedVersion()
		{
			Sdl.SDL_version version = SdlTtf.TTF_Linked_Version();
			//Console.WriteLine("Ttf version: " + version.ToString());
			Assert.AreEqual(version.major.ToString() 
				+ "." + version.minor.ToString() 
				+ "." + version.patch.ToString(), "2.0.6");
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void TTF_Init()
		{
			Tao.Sdl.SdlTtf.TTF_Quit();
			Assert.AreEqual( 0, Tao.Sdl.SdlTtf.TTF_Init());
			Assert.IsTrue(Tao.Sdl.SdlTtf.TTF_WasInit()!= 0);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void TTF_Quit()
		{
			SdlTtf.TTF_Quit();
			Assert.AreEqual(SdlTtf.TTF_WasInit(), 0);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void OpenFont()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 10);
			Assert.IsFalse(fontPtr == IntPtr.Zero);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void OpenFontIndex()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFontIndex("Vera.ttf", 10, 0);
			Assert.IsFalse(fontPtr == IntPtr.Zero);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void OpenFontRW()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFontRW(Sdl.SDL_RWFromFile("Vera.ttf", "rb"), 1, 12);
			Assert.IsFalse(fontPtr == IntPtr.Zero);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void OpenFontIndexRW()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFontIndexRW(Sdl.SDL_RWFromFile("Vera.ttf", "rb"), 1, 12, 0);
			Assert.IsFalse(fontPtr == IntPtr.Zero);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void CloseFont()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFontIndexRW(Sdl.SDL_RWFromFile("Vera.ttf", "rb"), 1, 12, 0);
			SdlTtf.TTF_CloseFont(fontPtr);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SetGetFontStyle()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 10);
			SdlTtf.TTF_SetFontStyle(fontPtr, SdlTtf.TTF_STYLE_BOLD|SdlTtf.TTF_STYLE_ITALIC);
			Assert.AreEqual(SdlTtf.TTF_STYLE_BOLD|SdlTtf.TTF_STYLE_ITALIC, SdlTtf.TTF_GetFontStyle(fontPtr));
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("For some reason, the FontHeight returns back 3pt higher that what was pased by OpenFont")]
		public void FontHeight()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 9);
			Assert.AreEqual(SdlTtf.TTF_FontHeight(fontPtr), 12);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void FontAscent()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 10);
			Assert.AreEqual(SdlTtf.TTF_FontAscent(fontPtr), 10);
			//Console.WriteLine("FontAscent:" + result.ToString());
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void FontDescent()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 10);
			Assert.AreEqual(SdlTtf.TTF_FontDescent(fontPtr), -2);
			//Console.WriteLine("FontDescent:" + SdlTtf.TTF_FontDescent(fontPtr).ToString());
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void FontLineSkip()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 10);
			Assert.AreEqual(SdlTtf.TTF_FontLineSkip(fontPtr), 14);
			//Console.WriteLine("FontLineSkip:" + SdlTtf.TTF_FontLineSkip(fontPtr).ToString());
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void FontFaces()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 10);
			Assert.AreEqual(SdlTtf.TTF_FontFaces(fontPtr), 4294967297);
			//Console.WriteLine("FontFaces:" + SdlTtf.TTF_FontFaces(fontPtr).ToString());
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void FontFaceIsFixedWidth()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 10);
			Assert.AreEqual(SdlTtf.TTF_FontFaceIsFixedWidth(fontPtr), 0);
			IntPtr fontPtrMono = SdlTtf.TTF_OpenFont("VeraMono.ttf", 10);
			Assert.IsTrue(SdlTtf.TTF_FontFaceIsFixedWidth(fontPtrMono) != 0);
			//Console.WriteLine("FontFaceIsFixedWidth:" + 
			//	SdlTtf.TTF_FontFaceIsFixedWidth(fontPtrMono).ToString());
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("Works fine when run alone. When run as part of the suite is messes up several other tests.")]
		public void FontFaceFamilyName()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 10);
			//Console.WriteLine("FontFaceFamily:" + SdlTtf.TTF_FontFaceFamilyName(fontPtr).ToString());
			Assert.AreEqual(SdlTtf.TTF_FontFaceFamilyName(fontPtr).ToString(), "Bitstream Vera Sans");
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("Works fine when run alone. When run as part of the suite is messes up several other tests.")]
		public void FontFaceStyleName()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 10);
			//Console.WriteLine("FontFaceStyleName:" + SdlTtf.TTF_FontFaceStyleName(fontPtr).ToString());
			Assert.AreEqual(SdlTtf.TTF_FontFaceStyleName(fontPtr).ToString(), "Roman");
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void GlyphMetrics()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 12);
			int minx;
			int miny;
			int maxx;
			int maxy;
			int advance;
			int result;

			result = SdlTtf.TTF_GlyphMetrics(fontPtr, 1 , out minx, out maxx,out  miny, out maxy, out advance);
			Assert.AreEqual(minx, 1);
			Assert.AreEqual(maxx, 7);
			Assert.AreEqual(miny, -3);
			Assert.AreEqual(maxy, 8);
			Assert.AreEqual(advance, 7);
//			Console.WriteLine("minx: " + minx.ToString());
//			Console.WriteLine("maxx: " + maxx.ToString());
//			Console.WriteLine("miny: " + miny.ToString());
//			Console.WriteLine("maxy: " + maxy.ToString());
//			Console.WriteLine("advance: " + advance.ToString());
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SizeText()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 10);
			int w; 
			int h;
			int result = SdlTtf.TTF_SizeText(fontPtr, "hello", out w, out h);
//			Console.WriteLine("w: " + w.ToString());
//			Console.WriteLine("h: " + h.ToString());
			Assert.AreEqual(w, 6);
			Assert.AreEqual(h, 13);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SizeUTF8()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 10);
			int w; 
			int h;
			int result = SdlTtf.TTF_SizeUTF8(fontPtr, "hello", out w, out h);
						Console.WriteLine("w: " + w.ToString());
						Console.WriteLine("h: " + h.ToString());
			Assert.AreEqual(w, 6);
			Assert.AreEqual(h, 13);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SizeUNICODE()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 10);
			int w; 
			int h;
			int result = SdlTtf.TTF_SizeUNICODE(fontPtr, "hello", out w, out h);
						Console.WriteLine("w: " + w.ToString());
						Console.WriteLine("h: " + h.ToString());
			Assert.AreEqual(w, 22);
			Assert.AreEqual(h, 13);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void RenderText_Solid()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr surfacePtr = VideoSetup();
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,400,400);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,400,400);
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 24);
			Sdl.SDL_Color color = new Sdl.SDL_Color(254, 0, 0);
			IntPtr fontSurfacePtr = SdlTtf.TTF_RenderText_Solid(fontPtr, "hello", color);
			Assert.IsFalse(fontSurfacePtr == IntPtr.Zero);
			int result = Sdl.SDL_BlitSurface(fontSurfacePtr, ref rect1, surfacePtr, ref rect2);
			Assert.AreEqual(result, 0);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,400,400);
			Thread.Sleep(sleepTime);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void RenderUTF8_Solid()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr surfacePtr = VideoSetup();
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,400,400);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,400,400);
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 24);
			Sdl.SDL_Color color = new Sdl.SDL_Color(254, 0, 0);
			IntPtr fontSurfacePtr = SdlTtf.TTF_RenderUTF8_Solid(fontPtr, "hello", color);
			Assert.IsFalse(fontSurfacePtr == IntPtr.Zero);
			int result = Sdl.SDL_BlitSurface(fontSurfacePtr, ref rect1, surfacePtr, ref rect2);
			Assert.AreEqual(result, 0);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,400,400);
			Thread.Sleep(sleepTime);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void RenderUNICODE_Solid()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr surfacePtr = VideoSetup();
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,400,400);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,400,400);
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 24);
			Sdl.SDL_Color color = new Sdl.SDL_Color(254, 0, 0);
			IntPtr fontSurfacePtr = SdlTtf.TTF_RenderUNICODE_Solid(fontPtr, "hello", color);
			Assert.IsFalse(fontSurfacePtr == IntPtr.Zero);
			int result = Sdl.SDL_BlitSurface(fontSurfacePtr, ref rect1, surfacePtr, ref rect2);
			Assert.AreEqual(result, 0);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,400,400);
			Thread.Sleep(sleepTime);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void RenderGlyph_Solid()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr surfacePtr = VideoSetup();
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,400,400);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,400,400);
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 24);
			Sdl.SDL_Color color = new Sdl.SDL_Color(254, 0, 0);
			IntPtr fontSurfacePtr = SdlTtf.TTF_RenderGlyph_Solid(fontPtr, 1000, color);
			Assert.IsFalse(fontSurfacePtr == IntPtr.Zero);
			int result = Sdl.SDL_BlitSurface(fontSurfacePtr, ref rect1, surfacePtr, ref rect2);
			Assert.AreEqual(result, 0);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,400,400);
			Thread.Sleep(sleepTime);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void RenderText_Shaded()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr surfacePtr = VideoSetup();
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,400,400);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,400,400);
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 24);
			Sdl.SDL_Color colorfg = new Sdl.SDL_Color(254, 0, 0);
			Sdl.SDL_Color colorbg = new Sdl.SDL_Color(0, 254, 0);
			IntPtr fontSurfacePtr = SdlTtf.TTF_RenderText_Shaded(fontPtr, "hello", colorfg, colorbg);
			Assert.IsFalse(fontSurfacePtr == IntPtr.Zero);
			int result = Sdl.SDL_BlitSurface(fontSurfacePtr, ref rect1, surfacePtr, ref rect2);
			Assert.AreEqual(result, 0);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,400,400);
			Thread.Sleep(sleepTime);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void RenderUTF8_Shaded()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr surfacePtr = VideoSetup();
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,400,400);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,400,400);
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 24);
			Sdl.SDL_Color colorfg = new Sdl.SDL_Color(254, 0, 0);
			Sdl.SDL_Color colorbg = new Sdl.SDL_Color(0, 254, 0);
			IntPtr fontSurfacePtr = SdlTtf.TTF_RenderUTF8_Shaded(fontPtr, "hello", colorfg, colorbg);
			Assert.IsFalse(fontSurfacePtr == IntPtr.Zero);
			int result = Sdl.SDL_BlitSurface(fontSurfacePtr, ref rect1, surfacePtr, ref rect2);
			Assert.AreEqual(result, 0);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,400,400);
			Thread.Sleep(sleepTime);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void RenderUNICODE_Shaded()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr surfacePtr = VideoSetup();
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,400,400);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,400,400);
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 24);
			Sdl.SDL_Color colorfg = new Sdl.SDL_Color(254, 0, 0);
			Sdl.SDL_Color colorbg = new Sdl.SDL_Color(0, 254, 0);
			IntPtr fontSurfacePtr = SdlTtf.TTF_RenderUNICODE_Shaded(fontPtr, "hello", colorfg, colorbg);
			Assert.IsFalse(fontSurfacePtr == IntPtr.Zero);
			int result = Sdl.SDL_BlitSurface(fontSurfacePtr, ref rect1, surfacePtr, ref rect2);
			Assert.AreEqual(result, 0);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,400,400);
			Thread.Sleep(sleepTime);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void RenderGlyph_Shaded()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr surfacePtr = VideoSetup();
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,400,400);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,400,400);
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 24);
			Sdl.SDL_Color colorfg = new Sdl.SDL_Color(254, 0, 0);
			Sdl.SDL_Color colorbg = new Sdl.SDL_Color(0, 254, 0);
			IntPtr fontSurfacePtr = SdlTtf.TTF_RenderGlyph_Shaded(fontPtr, 1000, colorfg, colorbg);
			Assert.IsFalse(fontSurfacePtr == IntPtr.Zero);
			int result = Sdl.SDL_BlitSurface(fontSurfacePtr, ref rect1, surfacePtr, ref rect2);
			Assert.AreEqual(result, 0);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,400,400);
			Thread.Sleep(sleepTime);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void RenderText_Blended()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr surfacePtr = VideoSetup();
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,400,400);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,400,400);
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 24);
			Sdl.SDL_Color colorfg = new Sdl.SDL_Color(254, 0, 0);
			IntPtr fontSurfacePtr = SdlTtf.TTF_RenderText_Blended(fontPtr, "hello", colorfg);
			Assert.IsFalse(fontSurfacePtr == IntPtr.Zero);
			int result = Sdl.SDL_BlitSurface(fontSurfacePtr, ref rect1, surfacePtr, ref rect2);
			Assert.AreEqual(result, 0);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,400,400);
			Thread.Sleep(sleepTime);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void RenderUTF8_Blended()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr surfacePtr = VideoSetup();
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,400,400);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,400,400);
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 24);
			Sdl.SDL_Color colorfg = new Sdl.SDL_Color(254, 0, 0);
			IntPtr fontSurfacePtr = SdlTtf.TTF_RenderUTF8_Blended(fontPtr, "hello", colorfg);
			Assert.IsFalse(fontSurfacePtr == IntPtr.Zero);
			int result = Sdl.SDL_BlitSurface(fontSurfacePtr, ref rect1, surfacePtr, ref rect2);
			Assert.AreEqual(result, 0);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,400,400);
			Thread.Sleep(sleepTime);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void RenderUNICODE_Blended()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr surfacePtr = VideoSetup();
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,400,400);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,400,400);
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 24);
			Sdl.SDL_Color colorfg = new Sdl.SDL_Color(254, 0, 0);
			IntPtr fontSurfacePtr = SdlTtf.TTF_RenderUNICODE_Blended(fontPtr, "hello", colorfg);
			Assert.IsFalse(fontSurfacePtr == IntPtr.Zero);
			int result = Sdl.SDL_BlitSurface(fontSurfacePtr, ref rect1, surfacePtr, ref rect2);
			Assert.AreEqual(result, 0);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,400,400);
			Thread.Sleep(sleepTime);
			SdlTtf.TTF_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void RenderGlyph_Blended()
		{
			SdlTtf.TTF_Quit();
			SdlTtf.TTF_Init();
			IntPtr surfacePtr = VideoSetup();
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,400,400);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,400,400);
			IntPtr fontPtr = SdlTtf.TTF_OpenFont("Vera.ttf", 24);
			Sdl.SDL_Color colorfg = new Sdl.SDL_Color(254, 0, 0);
			IntPtr fontSurfacePtr = SdlTtf.TTF_RenderGlyph_Blended(fontPtr, 1000, colorfg);
			Assert.IsFalse(fontSurfacePtr == IntPtr.Zero);
			int result = Sdl.SDL_BlitSurface(fontSurfacePtr, ref rect1, surfacePtr, ref rect2);
			Assert.AreEqual(result, 0);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,400,400);
			Thread.Sleep(sleepTime);
			SdlTtf.TTF_Quit();
		}
	}
	#endregion SDL_ttf.h
}
