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
		private void InitAudio()
		{
			Sdl.SDL_Quit();
			Sdl.SDL_Init(Sdl.SDL_INIT_AUDIO);
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
			InitAudio();	
			int results = SdlMixer.Mix_AllocateChannels(16);
			Assert.AreEqual(results, 16);
			Sdl.SDL_Quit();
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
			InitAudio();		
			IntPtr resultPtr = SdlMixer.Mix_LoadWAV_RW(Sdl.SDL_RWFromFile("test.wav", "rb"), 1);
			Assert.IsFalse(resultPtr == IntPtr.Zero);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadWAV()
		{
			InitAudio();		
			IntPtr resultPtr = SdlMixer.Mix_LoadWAV("test.wav");
			Assert.IsFalse(resultPtr == IntPtr.Zero);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadMUSwav()
		{
			InitAudio();		
			IntPtr resultPtr = SdlMixer.Mix_LoadMUS("test.wav");
			Assert.IsFalse(resultPtr == IntPtr.Zero);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadMUSmp3()
		{
			InitAudio();		
			IntPtr resultPtr = SdlMixer.Mix_LoadMUS("test.mp3");
			Assert.IsFalse(resultPtr == IntPtr.Zero);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void LoadMUSOGG()
		{
			InitAudio();		
			IntPtr resultPtr = SdlMixer.Mix_LoadMUS("test.ogg");
			Assert.IsFalse(resultPtr == IntPtr.Zero);
			Sdl.SDL_Quit();
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
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void QuickLoad_WAV()
		{
			InitAudio();		
			IntPtr resultPtr = SdlMixer.Mix_QuickLoad_WAV(Sdl.SDL_RWFromFile("test.wav", "rb"));
			Assert.IsFalse(resultPtr == IntPtr.Zero);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void QuickLoad_RAW()
		{
			InitAudio();		
			IntPtr resultPtr = SdlMixer.Mix_QuickLoad_RAW(Sdl.SDL_RWFromFile("test.wav", "rb"), 1000);
			Assert.IsFalse(resultPtr == IntPtr.Zero);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void FreeChunk()
		{
			InitAudio();		
			IntPtr wavPtr = Sdl.SDL_RWFromFile("test.wav", "rb");
			SdlMixer.Mix_FreeChunk(wavPtr);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void FreeMusic()
		{
			InitAudio();		
			IntPtr wavPtr = Sdl.SDL_RWFromFile("test.wav", "rb");
			SdlMixer.Mix_FreeMusic(wavPtr);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void GetMusicType()
		{
			InitAudio();	
			IntPtr resultPtr = SdlMixer.Mix_LoadMUS("test.wav");
			SdlMixer.Mix_MusicType musicType = SdlMixer.Mix_GetMusicType(resultPtr);
			Console.WriteLine("musictype:" + musicType);
			//Assert.IsFalse(resultPtr == IntPtr.Zero);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("Not finished")]
		public void SetPostMix()
		{

		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("Not finished")]
		public void HookMusic()
		{

		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("Not finished")]
		public void HookMusicFinished()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("Not finished")]
		public void GetMusicHookData()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("Not finished")]
		public void ChannelFinished()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("Not finished")]
		public void RegisterEffect()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("Not finished")]
		public void UnregisterEffect()
		{

		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		[Ignore("Not finished")]
		public void UnregisterAllEffects()
		{

		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SetPanning()
		{
			InitAudio();	
			int result = SdlMixer.Mix_SetPanning(1, 255,127);
			Assert.IsTrue(result != 0);
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SetPosition()
		{
			InitAudio();	
			int result = SdlMixer.Mix_SetPosition(1, 90, 100);
			Assert.IsTrue(result != 0);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SetDistance()
		{
			InitAudio();	
			int result = SdlMixer.Mix_SetDistance(1, 140);
			Assert.IsTrue(result != 0);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void SetReverseStereo()
		{
			InitAudio();	
			int result = SdlMixer.Mix_SetReverseStereo(SdlMixer.MIX_CHANNEL_POST, 1);
			Assert.IsTrue(result != 0);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void ReserveChannels()
		{
			InitAudio();	
			int result = SdlMixer.Mix_ReserveChannels(1);
			//Console.WriteLine("ReserveChannels: " + result.ToString());
			Assert.IsTrue(result == 1);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void GroupChannel()
		{
			InitAudio();	
			int result = SdlMixer.Mix_GroupChannel(1, 1);
			//Console.WriteLine("ReserveChannels: " + result.ToString());
			Assert.IsTrue(result == 1);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void GroupChannels()
		{
			InitAudio();	
			int result = SdlMixer.Mix_GroupChannels(0, 7, 1);
			//Console.WriteLine("ReserveChannels: " + result.ToString());
			Assert.IsTrue(result == 8);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void GroupAvailable()
		{
			InitAudio();	
			int result = SdlMixer.Mix_GroupChannel(1, 1);
			result = SdlMixer.Mix_GroupAvailable(1);
			//Console.WriteLine("ReserveChannels: " + result.ToString());
			Assert.IsTrue(result != -1);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void GroupCount()
		{
			InitAudio();	
			int result = SdlMixer.Mix_GroupChannel(1, 1);
			result = SdlMixer.Mix_GroupCount(1);
			//Console.WriteLine("ReserveChannels: " + result.ToString());
			Assert.IsTrue(result == 1);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void GroupOldest()
		{
			InitAudio();	
			int result = SdlMixer.Mix_GroupChannels(0, 7, 1);
			result = SdlMixer.Mix_GroupOldest(1);
			//Console.WriteLine("GroupOldest: " + result.ToString());
			Assert.IsTrue(result == -1);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void GroupNewer()
		{
			InitAudio();	
			int result = SdlMixer.Mix_GroupChannels(0, 7, 1);
			result = SdlMixer.Mix_GroupOldest(1);
			//Console.WriteLine("GroupOldest: " + result.ToString());
			Assert.IsTrue(result == -1);
			Sdl.SDL_Quit();
		}
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void PlayChannelTimed()
		{
			InitAudio();	
			int result = SdlMixer.Mix_GroupChannels(0, 7, 1);
			IntPtr chunkPtr = SdlMixer.Mix_LoadWAV("test.wav");
			result = SdlMixer.Mix_PlayChannelTimed(-1, chunkPtr, -1, 500);
			Thread.Sleep(500);
			Console.WriteLine("PlayChannelTimed: " + result.ToString());
			Assert.IsTrue(result != -1);
			Sdl.SDL_Quit();
		}
	}
	#endregion SDL_mixer.h
}