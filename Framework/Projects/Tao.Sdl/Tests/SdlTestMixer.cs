using System;
using System.Threading;
using NUnit.Framework;
using Tao.Sdl;
using System.Runtime.InteropServices;

namespace Tao.Sdl
{
	#region SDL_mixer.h
	/// <summary>
	/// SDL Tests.
	/// </summary>
	[TestFixture]
	public class SdlTestMixer
	{
		int init;

		/// <summary>
		/// 
		/// </summary>
		[SetUp]
		public void Init()
		{
			init = Sdl.SDL_Init(Sdl.SDL_INIT_AUDIO);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LinkedVersion()
		{
			Sdl.SDL_version version = SdlMixer.Mix_Linked_Version();
			//Console.WriteLine("Mixer version: " + version.ToString());
			Assert.AreEqual(version.major.ToString() 
				+ "." + version.minor.ToString() 
				+ "." + version.patch.ToString(), "1.2.5");
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void OpenAudio()
		{

			int results = SdlMixer.Mix_OpenAudio(
				SdlMixer.MIX_DEFAULT_FREQUENCY, 
				(short) SdlMixer.MIX_DEFAULT_FORMAT, 
				2, 
				1024);
			Assert.AreEqual(results,0);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void AllocateChannels()
		{
			int results = SdlMixer.Mix_AllocateChannels(16);
			Assert.AreEqual(results, 16);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void QuerySpec()
		{
			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_AUDIO);
			int results = SdlMixer.Mix_OpenAudio(
				SdlMixer.MIX_DEFAULT_FREQUENCY, 
				(short) SdlMixer.MIX_DEFAULT_FORMAT, 
				2, 
				1024);
			int frequency;
			short format;
			int channels;
			results = SdlMixer.Mix_QuerySpec(out frequency, out format, out channels);
//			Console.WriteLine("freq: " + frequency.ToString());
//			Console.WriteLine("format: " + format.ToString());
//			Console.WriteLine("chan: " + channels.ToString());
//			Console.WriteLine("results: " + results.ToString());
			Assert.AreEqual(frequency, SdlMixer.MIX_DEFAULT_FREQUENCY);
			Assert.AreEqual(format, (short) SdlMixer.MIX_DEFAULT_FORMAT);
			Assert.AreEqual(channels, 2);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadWAV_RW()
		{
			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_AUDIO);
					
			IntPtr resultPtr = SdlMixer.Mix_LoadWAV_RW(Sdl.SDL_RWFromFile("test.wav", "rb"), 1);
			Assert.IsFalse(resultPtr == IntPtr.Zero);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadWAV()
		{
			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_AUDIO);
					
			IntPtr resultPtr = SdlMixer.Mix_LoadWAV("test.wav");
			Assert.IsFalse(resultPtr == IntPtr.Zero);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadMUSwav()
		{
			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_AUDIO);
					
			IntPtr resultPtr = SdlMixer.Mix_LoadMUS("test.wav");
			Assert.IsFalse(resultPtr == IntPtr.Zero);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadMUSmp3()
		{
			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_AUDIO);
					
			IntPtr resultPtr = SdlMixer.Mix_LoadMUS("test.mp3");
			Assert.IsFalse(resultPtr == IntPtr.Zero);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadMUSOGG()
		{
			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_AUDIO);
					
			IntPtr resultPtr = SdlMixer.Mix_LoadMUS("test.ogg");
			Assert.IsFalse(resultPtr == IntPtr.Zero);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SetGetError()
		{
			string error = "Hi there";
			SdlMixer.Mix_SetError(error);
			Assert.AreEqual(SdlMixer.Mix_GetError(), error);
		}
	}
	#endregion SDL_mixer.h
}
