using System;
using System.Threading;
using NUnit.Framework;
using Tao.Sdl;
using System.Runtime.InteropServices;

namespace Tao.Sdl
{
	#region Smpeg
	/// <summary>
	/// SDL Tests.
	/// </summary>
	[TestFixture]
	public class SmpegTest
	{
		int flags = (Sdl.SDL_HWSURFACE|Sdl.SDL_DOUBLEBUF|Sdl.SDL_ANYFORMAT);
		int bpp = 16;
		int width = 640;
		int height = 480;
		IntPtr surfacePtr;
		Sdl.SDL_Rect rect2;
		int sleepTime = 1000;
		short[] vx = {40, 80, 130, 80, 40};
		short[] vy = {80, 40, 80, 130, 130};
		byte[] src1 = {1,2,3,4};
		byte[] src2 = {2,10,20,40};
		byte[] dest = new byte[4];
		Smpeg.SMPEG_Info info = new Smpeg.SMPEG_Info();
		
		/// <summary>
		/// 
		/// </summary>
		[SetUp]
		public void Init()
		{
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		private void InitSdl()
		{
			Sdl.SDL_Quit();
			int init = Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			//this.SmpegSetup();
			
		}
		private void SmepgSetup()
		{
			surfacePtr = Sdl.SDL_SetVideoMode(
				width, 
				height, 
				bpp, 
				flags);
			rect2 = new Sdl.SDL_Rect(
				0,
				0,
				(short) width,
				(short) height);
			Sdl.SDL_SetClipRect(surfacePtr, ref rect2);
		}
		/// <summary>
		/// 
		/// </summary>
		private void Quit()
		{
			Sdl.SDL_Quit();
		}

		#region smpeg.h
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SMPEG_new()
		{
			this.InitSdl();

			//IntPtr intPtr = Smpeg.SMPEG_new("test.mpg", out info, 0); 
			//IntPtr intPtr = Sdl.SDL_RWFromFile("test.mpg", "rb");
			IntPtr intPtr = Smpeg.SMPEG_new("test.mpg", out info, 0); 
			Console.WriteLine("Smpeg_error: " + Smpeg.SMPEG_error(intPtr));
			Assert.IsFalse(intPtr == IntPtr.Zero);
			this.Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SMPEG_new_rwops()
		{
			this.InitSdl();

			//IntPtr intPtr = Smpeg.SMPEG_new("test.mpg", out info, 0); 
			//IntPtr intPtr = Sdl.SDL_RWFromFile("test.mpg", "rb");
			IntPtr intPtr = Smpeg.SMPEG_new_rwops(Sdl.SDL_RWFromFile("test.mpg", "rb"), out info, 0); 
			Console.WriteLine("Smpeg_error: " + Smpeg.SMPEG_error(intPtr));
			Assert.IsFalse(intPtr == IntPtr.Zero);
			this.Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SMPEG_play()
		{
			this.InitSdl();

			//IntPtr intPtr = Smpeg.SMPEG_new("test.mpg", out info, 0); 
			//IntPtr intPtr = Sdl.SDL_RWFromFile("test.mpg", "rb");
			IntPtr intPtr = Smpeg.SMPEG_new("test.mpg", out info, 0); 
			Console.WriteLine("Smpeg_error: " + Smpeg.SMPEG_error(intPtr));
			Assert.IsFalse(intPtr == IntPtr.Zero);
			Smpeg.SMPEG_play(intPtr);
			Thread.Sleep(sleepTime);
			this.Quit();
		}
		#endregion smpeg.h

		#region MPEGfilter.h
		#endregion MPEGfilter.h
	}
	#endregion SDL_gfx.h
}