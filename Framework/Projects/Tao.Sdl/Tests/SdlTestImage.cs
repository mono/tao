using System;
using System.Threading;
using NUnit.Framework;
using Tao.Sdl;
using System.Runtime.InteropServices;

namespace Tao.Sdl
{
	#region SDL_image.h
	/// <summary>
	/// SDL Tests.
	/// </summary>
	[TestFixture]
	public class SdlTestImage
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
			init = Sdl.SDL_Init(Sdl.SDL_INIT_VIDEO);
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
		public void isBMP()
		{
			string file = "test.bmp";
			Assert.IsFalse(SdlImage.IMG_isBMP(Sdl.SDL_RWFromFile(file, "rb")) == IntPtr.Zero);
			Assert.AreEqual(SdlImage.IMG_isBMP(Sdl.SDL_RWFromFile("test.jpg", "rb")), IntPtr.Zero);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void isJPG()
		{
			string file = "test.jpg";
			Assert.IsFalse(SdlImage.IMG_isJPG(Sdl.SDL_RWFromFile(file, "rb")) == IntPtr.Zero);
			Assert.AreEqual(SdlImage.IMG_isJPG(Sdl.SDL_RWFromFile("test.bmp", "rb")), IntPtr.Zero);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void isGIF()
		{
			string file = "test.gif";
			Assert.IsFalse(SdlImage.IMG_isGIF(Sdl.SDL_RWFromFile(file, "rb")) == IntPtr.Zero);
			Assert.AreEqual(SdlImage.IMG_isGIF(Sdl.SDL_RWFromFile("test.bmp", "rb")), IntPtr.Zero);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void isPNG()
		{
			string file = "test.png";
			Assert.IsFalse(SdlImage.IMG_isPNG(Sdl.SDL_RWFromFile(file, "rb")) == IntPtr.Zero);
			Assert.AreEqual(SdlImage.IMG_isPNG(Sdl.SDL_RWFromFile("test.bmp", "rb")), IntPtr.Zero);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void isPNM()
		{
			string file = "test.pnm";
			Assert.IsFalse(SdlImage.IMG_isPNM(Sdl.SDL_RWFromFile(file, "rb")) == IntPtr.Zero);
			Assert.AreEqual(SdlImage.IMG_isPNM(Sdl.SDL_RWFromFile("test.bmp", "rb")), IntPtr.Zero);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void isPCX()
		{
			string file = "test.pcx";
			Assert.IsFalse(SdlImage.IMG_isPCX(Sdl.SDL_RWFromFile(file, "rb")) == IntPtr.Zero);
			Assert.AreEqual(SdlImage.IMG_isPCX(Sdl.SDL_RWFromFile("test.bmp", "rb")), IntPtr.Zero);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void isXPM()
		{
			string file = "test.xpm";
			Assert.IsFalse(SdlImage.IMG_isXPM(Sdl.SDL_RWFromFile(file, "rb")) == IntPtr.Zero);
			Assert.AreEqual(SdlImage.IMG_isXPM(Sdl.SDL_RWFromFile("test.bmp", "rb")), IntPtr.Zero);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("Very strange. The TIF files I create in GIMP do not work in this test.")]
		public void isTIF()
		{
			string file = "test.tif";
			Assert.IsFalse(SdlImage.IMG_isTIF(Sdl.SDL_RWFromFile(file, "rb")) == IntPtr.Zero);
			Assert.AreEqual(SdlImage.IMG_isTIF(Sdl.SDL_RWFromFile("test.bmp", "rb")), IntPtr.Zero);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadGIF()
		{
			string file = "test.gif";
			IntPtr surfacePtr = VideoSetup();
			IntPtr imagePtr = SdlImage.IMG_LoadGIF_RW(Sdl.SDL_RWFromFile(file, "rb"));
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,200,200);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,200,200);
			int result = Sdl.SDL_BlitSurface(imagePtr, ref rect1, surfacePtr, ref rect2);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,200,200);
			Thread.Sleep(sleepTime);
			Assert.AreEqual(result, 0);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadJPG()
		{
			string file = "test.jpg";
			IntPtr surfacePtr = VideoSetup();
			IntPtr imagePtr = SdlImage.IMG_LoadJPG_RW(Sdl.SDL_RWFromFile(file, "rb"));
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,200,200);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,200,200);
			int result = Sdl.SDL_BlitSurface(imagePtr, ref rect1, surfacePtr, ref rect2);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,200,200);
			Thread.Sleep(sleepTime);
			Assert.AreEqual(result, 0);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadPNG()
		{
			string file = "test.png";
			IntPtr surfacePtr = VideoSetup();
			IntPtr imagePtr = SdlImage.IMG_LoadPNG_RW(Sdl.SDL_RWFromFile(file, "rb"));
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,200,200);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,200,200);
			int result = Sdl.SDL_BlitSurface(imagePtr, ref rect1, surfacePtr, ref rect2);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,200,200);
			Thread.Sleep(sleepTime);
			Assert.AreEqual(result, 0);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadPCX()
		{
			string file = "test.pcx";
			IntPtr surfacePtr = VideoSetup();
			IntPtr imagePtr = SdlImage.IMG_LoadPCX_RW(Sdl.SDL_RWFromFile(file, "rb"));
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,200,200);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,200,200);
			int result = Sdl.SDL_BlitSurface(imagePtr, ref rect1, surfacePtr, ref rect2);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,200,200);
			Thread.Sleep(sleepTime);
			Assert.AreEqual(result, 0);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadTGA()
		{
			string file = "test.tga";
			IntPtr surfacePtr = VideoSetup();
			IntPtr imagePtr = SdlImage.IMG_LoadTGA_RW(Sdl.SDL_RWFromFile(file, "rb"));
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,200,200);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,200,200);
			int result = Sdl.SDL_BlitSurface(imagePtr, ref rect1, surfacePtr, ref rect2);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,200,200);
			Thread.Sleep(sleepTime);
			Assert.AreEqual(result, 0);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadPNM()
		{
			string file = "test.pnm";
			IntPtr surfacePtr = VideoSetup();
			IntPtr imagePtr = SdlImage.IMG_LoadPNM_RW(Sdl.SDL_RWFromFile(file, "rb"));
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,200,200);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,200,200);
			int result = Sdl.SDL_BlitSurface(imagePtr, ref rect1, surfacePtr, ref rect2);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,200,200);
			Thread.Sleep(sleepTime);
			Assert.AreEqual(result, 0);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadBMP()
		{
			string file = "test.bmp";
			IntPtr surfacePtr = VideoSetup();
			IntPtr imagePtr = SdlImage.IMG_LoadBMP_RW(Sdl.SDL_RWFromFile(file, "rb"));
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,200,200);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,200,200);
			int result = Sdl.SDL_BlitSurface(imagePtr, ref rect1, surfacePtr, ref rect2);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,200,200);
			Thread.Sleep(sleepTime);
			Assert.AreEqual(result, 0);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadXPM()
		{
			string file = "test.xpm";
			IntPtr surfacePtr = VideoSetup();
			IntPtr imagePtr = SdlImage.IMG_LoadXPM_RW(Sdl.SDL_RWFromFile(file, "rb"));
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,200,200);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,200,200);
			int result = Sdl.SDL_BlitSurface(imagePtr, ref rect1, surfacePtr, ref rect2);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,200,200);
			Thread.Sleep(sleepTime);
			Assert.AreEqual(result, 0);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadTIF()
		{
			string file = "test.tif";
			IntPtr surfacePtr = VideoSetup();
			IntPtr imagePtr = SdlImage.IMG_LoadTIF_RW(Sdl.SDL_RWFromFile(file, "rb"));
			Sdl.SDL_Rect rect1 = new Sdl.SDL_Rect(0,0,200,200);
			Sdl.SDL_Rect rect2 = new Sdl.SDL_Rect(0,0,200,200);
			int result = Sdl.SDL_BlitSurface(imagePtr, ref rect1, surfacePtr, ref rect2);
			Sdl.SDL_UpdateRect(surfacePtr, 0,0,200,200);
			Thread.Sleep(sleepTime);
			Assert.AreEqual(result, 0);
		}
	}
	#endregion SDL_image.h
}
