using System;
using System.Threading;
using NUnit.Framework;
using Tao.Sdl;

namespace Tao.Sdl
{
	/// <summary>
	/// SDL Tests.
	/// </summary>
	[TestFixture]
	public class SdlTest
	{
		#region SDL.h
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void InitVideo()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Assert.AreEqual( 0, Tao.Sdl.Sdl.SDL_Init(Sdl.SDL_INIT_VIDEO));
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_VIDEO)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void InitAudio()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Assert.AreEqual( 0, Tao.Sdl.Sdl.SDL_Init(Sdl.SDL_INIT_AUDIO));
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_AUDIO)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void InitTimer()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Assert.AreEqual( 0, Tao.Sdl.Sdl.SDL_Init(Sdl.SDL_INIT_TIMER));
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_TIMER)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void InitCDRom()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Assert.AreEqual( 0, Tao.Sdl.Sdl.SDL_Init(Sdl.SDL_INIT_CDROM));
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_CDROM)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void InitJoystick()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Assert.AreEqual( 0, Tao.Sdl.Sdl.SDL_Init(Sdl.SDL_INIT_JOYSTICK));
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_JOYSTICK)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void InitEverything()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Assert.AreEqual( 0, Tao.Sdl.Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING));
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_EVERYTHING)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void InitSubSystemVideo()
		{
			Assert.AreEqual( 0, Tao.Sdl.Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_VIDEO));
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_VIDEO)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void InitSubSystemAudio()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Assert.AreEqual( 0, Tao.Sdl.Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_AUDIO));
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_AUDIO)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void InitSubSystemTimer()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Assert.AreEqual( 0, Tao.Sdl.Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_TIMER));
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_TIMER)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void InitSubSystemCDRom()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Assert.AreEqual( 0, Tao.Sdl.Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_CDROM));
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_CDROM)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void InitSubSystemJoystick()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Assert.AreEqual( 0, Tao.Sdl.Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_JOYSTICK));
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_JOYSTICK)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void InitSubSystemEverything()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Assert.AreEqual( 0, Tao.Sdl.Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_EVERYTHING));
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_EVERYTHING)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void Quit()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_EVERYTHING)== 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void QuitSubSystemVideo()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_VIDEO);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_VIDEO)!= 0);
			Tao.Sdl.Sdl.SDL_QuitSubSystem(Sdl.SDL_INIT_VIDEO);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_VIDEO)== 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void QuitSubSystemAudio()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_AUDIO);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_AUDIO)!= 0);
			Tao.Sdl.Sdl.SDL_QuitSubSystem(Sdl.SDL_INIT_AUDIO);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_AUDIO)== 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void QuitSubSystemTimer()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_TIMER);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_TIMER)!= 0);
			Tao.Sdl.Sdl.SDL_QuitSubSystem(Sdl.SDL_INIT_TIMER);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_TIMER)== 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void QuitSubSystemCDRom()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_CDROM);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_CDROM)!= 0);
			Tao.Sdl.Sdl.SDL_QuitSubSystem(Sdl.SDL_INIT_CDROM);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_CDROM)== 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void QuitSubSystemJoystick()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_JOYSTICK);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_JOYSTICK)!= 0);
			Tao.Sdl.Sdl.SDL_QuitSubSystem(Sdl.SDL_INIT_JOYSTICK);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_JOYSTICK)== 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void QuitSubSystemEverything()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_EVERYTHING);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_EVERYTHING)!= 0);
			Tao.Sdl.Sdl.SDL_QuitSubSystem(Sdl.SDL_INIT_EVERYTHING);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_EVERYTHING)== 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void WasInitEverything()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_EVERYTHING)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void WasInitVideo()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_Init(Sdl.SDL_INIT_VIDEO);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_VIDEO)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void WasInitAudio()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_Init(Sdl.SDL_INIT_AUDIO);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_AUDIO)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void WasInitCDRom()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_Init(Sdl.SDL_INIT_CDROM);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_CDROM)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void WasInitJoystick()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_Init(Sdl.SDL_INIT_JOYSTICK);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_JOYSTICK)!= 0);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void WasInitTimer()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_Init(Sdl.SDL_INIT_TIMER);
			Assert.IsTrue(Tao.Sdl.Sdl.SDL_WasInit(Sdl.SDL_INIT_TIMER)!= 0);
		}
		#endregion SDL.h

		#region SDL_active.h
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void GetAppState()
		{
			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			byte state = Sdl.SDL_GetAppState();
			Console.WriteLine("SDL_GetAppState(): " + state.ToString());
			Assert.IsTrue(state == 7);
		}
		#endregion SDL_active.h

		#region SDL_byteorder.h

		/// <summary>
		/// Endian Test
		/// </summary>
		[Test]
		public void Endian()
		{
			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
#if WIN32
			Assert.IsTrue(Sdl.SDL_BYTEORDER == Sdl.SDL_LIL_ENDIAN);
#endif

		}
		#endregion SDL_byteorder.h
		
		#region SDL_cpuinfo.h
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SDL_HasMMX()
		{

			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			Assert.IsTrue(Sdl.SDL_HasMMX() == Sdl.SDL_bool.SDL_TRUE);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SDL_HasMMXExt()
		{

			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			Assert.IsFalse(Sdl.SDL_HasMMXExt() == Sdl.SDL_bool.SDL_TRUE);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SDL_Has3DNow()
		{

			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			Assert.IsFalse(Sdl.SDL_Has3DNow() == Sdl.SDL_bool.SDL_TRUE);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SDL_HasAltiVec()
		{

			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			Assert.IsFalse(Sdl.SDL_HasAltiVec() == Sdl.SDL_bool.SDL_TRUE);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SDL_HasRDTSC()
		{

			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			Assert.IsTrue(Sdl.SDL_HasRDTSC() == Sdl.SDL_bool.SDL_TRUE);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SDL_HasSSE()
		{

			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			Assert.IsTrue(Sdl.SDL_HasSSE() == Sdl.SDL_bool.SDL_TRUE);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SDL_HasSSE2()
		{

			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			Assert.IsTrue(Sdl.SDL_HasSSE2() == Sdl.SDL_bool.SDL_TRUE);
		}
		#endregion SDL_cpuinfo.h
		
		#region SDL_error.h
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SetGetError()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_SetError("Nunit test");
			Assert.AreEqual("Nunit test", Tao.Sdl.Sdl.SDL_GetError());
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void ClearError()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_SetError("Nunit test");
			Assert.AreEqual("Nunit test", Tao.Sdl.Sdl.SDL_GetError());
			Tao.Sdl.Sdl.SDL_ClearError();
			Assert.AreEqual("", Tao.Sdl.Sdl.SDL_GetError());
		}

		#endregion SDL_error.h

		#region SDL_getenv.h
		/// <summary>
		/// 
		/// </summary>
		[Test]
#if WIN32
		[ExpectedException(typeof(System.EntryPointNotFoundException))]
#endif
		public void PutEnv()
		{
			Assert.AreEqual(0, Tao.Sdl.Sdl.SDL_putenv("SDLTest"));
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
#if WIN32
		[ExpectedException(typeof(System.EntryPointNotFoundException))]
#endif
		public void GetEnv()
		{
			Tao.Sdl.Sdl.SDL_getenv("HOME");
		}
		#endregion SDL_getenv.h

		#region SDL_timer.h
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void GetTicks()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			int beforeGetTicks = Tao.Sdl.Sdl.SDL_GetTicks();
			Thread.Sleep(100);
			int afterGetTicks = Tao.Sdl.Sdl.SDL_GetTicks();
			//Console.WriteLine("GetTicks(): " + Tao.Sdl.Sdl.SDL_GetTicks().ToString());
			Assert.IsTrue(afterGetTicks - beforeGetTicks >= 100);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void Delay()
		{
			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			int beforeDelay = Sdl.SDL_GetTicks();
			//Console.WriteLine("Before Delay(): " + beforeDelay.ToString());
			Sdl.SDL_Delay(100);
			int afterDelay = Sdl.SDL_GetTicks();
			//Console.WriteLine("After Delay(): " + afterDelay.ToString());
			Assert.IsTrue(afterDelay - beforeDelay >= 100);
		}

		private int PrintTimerInterval(int interval)
		{
			int currentSetTimer = Tao.Sdl.Sdl.SDL_GetTicks();
			Console.WriteLine("Current SetTimer(): " + currentSetTimer.ToString());
			return interval;
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("This test crashes the nunit gui. The problem is with the delay")]
		public void SetTimer()
		{
			Tao.Sdl.Sdl.SDL_Quit();
			Tao.Sdl.Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_TIMER);
			int interval = 10;
			Tao.Sdl.Sdl.SDL_TimerCallback testDelegate;
			testDelegate = new Tao.Sdl.Sdl.SDL_TimerCallback(PrintTimerInterval);
			int beforeSetTimer = Tao.Sdl.Sdl.SDL_GetTicks();
			Console.WriteLine("Before SetTimer(): " + beforeSetTimer.ToString());
			Tao.Sdl.Sdl.SDL_SetTimer(interval, testDelegate);
			//Assert.IsTrue(interval < testDelegate(interval));
			//Thread.Sleep(9);
			//Tao.Sdl.Sdl.SDL_Delay(20);
			int afterSetTimer = Tao.Sdl.Sdl.SDL_GetTicks();
			Console.WriteLine("After SetTimer(): " + afterSetTimer.ToString());
			while (afterSetTimer - beforeSetTimer < 20)
			{
				afterSetTimer = Tao.Sdl.Sdl.SDL_GetTicks();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("Must finish SetTimer test")]
		public void SetTimerCancel()
		{
			Sdl.SDL_Quit();
			Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_TIMER);
			Sdl.SDL_TimerCallback testDelegate;
			testDelegate = new Sdl.SDL_TimerCallback(PrintTimerInterval);
			int interval = 10;
			Sdl.SDL_SetTimer(interval, testDelegate);
			Sdl.SDL_SetTimer(0, null);
		}
		#endregion SDL_timer.h

		#region SDL_version.h
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SdlLinkedVersion()
		{
			Sdl.SDL_version version = Sdl.SDL_Linked_Version();
			Assert.AreEqual(version.major.ToString() 
				+ "." + version.minor.ToString() 
				+ "." + version.patch.ToString(), "1.2.7");
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SdlCompiledVersion()
		{
			Assert.AreEqual(Sdl.SDL_COMPILEDVERSION, 1207);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SdlVersionAtLeast127()
		{
			Assert.IsTrue(Sdl.SDL_VERSION_ATLEAST(1,2,7));
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SdlVersionAtLeast128()
		{
			Assert.IsFalse(Sdl.SDL_VERSION_ATLEAST(1,2,8));
		}
		#endregion SDL_version.h
	}
}
