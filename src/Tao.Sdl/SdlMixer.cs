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
	/// <p>SdlMixer is a simple multi-channel audio mixer. 
	/// It supports 8 channels of 16 bit stereo audio, plus a 
	/// single channel of music, mixed by the popular MikMod MOD, 
	/// Timidity MIDI and SMPEG MP3 libraries.</p> 
	/// <p>
	/// The mixer can currently load Microsoft WAVE files and 
	/// Creative Labs VOC files as audio samples, and can load MIDI 
	/// files via Timidity and the following music formats via 
	/// MikMod: .MOD .S3M .IT .XM. It can load Ogg Vorbis streams 
	/// as music if built with the Ogg Vorbis libraries, and 
	/// finally it can load MP3 music using the SMPEG library.</p> 
	/// <p>
	/// The process of mixing MIDI files to wave output is very CPU 
	/// intensive, so if playing regular WAVE files sound great, but
	///  playing MIDI files sound choppy, try using 8-bit audio, 
	///  mono audio, or lower frequencies.</p>
	/// </summary>
	/// <remarks>
	/// This assumes you have gotten SDL_mixer and installed it 
	/// on your system. SDL_mixer has an INSTALL document in the
	///  source distribution to help you get it compiled and installed. 
	///	SDL_mixer supports playing music and sound samples from 
	///	the following formats:
	///	<code>
	///	- WAVE/RIFF (.wav)
	///	- AIFF (.aiff)
	///	- VOC (.voc)
	///	- MOD (.mod .xm .s3m .669 .it .med and more) using included mikmod
	///	- MIDI (.mid) using timidity or native midi hardware
	///	- OggVorbis (.ogg) requiring ogg/vorbis libraries on system
	///	- MP3 (.mp3) requiring SMPEG library on system
	///	- also any command-line player, which is not mixed by SDL_mixer...
	///	</code>
	///	<p>
	///	When using SDL_mixer functions you need to avoid the 
	///	following functions from SDL:</p>
	/// <p><code>
	///	SDL_OpenAudio 
	///	Use Mix_OpenAudio instead. 
	///	SDL_CloseAudio 
	///	Use Mix_CloseAudio instead. 
	///	SDL_PauseAudio 
	///	Use Mix_Pause(-1) and Mix_PauseMusic instead, to pause.
	///	Use Mix_Resume(-1) and Mix_ResumeMusic instead, to unpause. 
	///	SDL_LockAudio 
	///	This is just not needed since SDL_mixer handles this for you.
	///	Using it may cause problems as well. 
	///	SDL_UnlockAudio 
	///	This is just not needed since SDL_mixer handles this for you.
	///	Using it may cause problems as well. </code></p>
	///	<p>You may call the following functions freely:</p> 
	/// <code>
	///	SDL_AudioDriverName 
	///	This will still work as usual. 
	///	SDL_GetAudioStatus 
	///	This will still work, though it will likely return 
	///	SDL_AUDIO_PLAYING even though SDL_mixer is just playing silence. 
	///	It is also a BAD idea to call SDL_mixer and SDL audio 
	///	functions from a callback. Callbacks include Effects 
	///	functions and other SDL_mixer audio hooks. </code>
	/// </remarks>
	#endregion Class Documentation
	[SuppressUnmanagedCodeSecurityAttribute()]
	public static class SdlMixer 
	{
		#region Private Constants
		#region string SDL_MIXER_NATIVE_LIBRARY
		/// <summary>
		///     Specifies SdlMixer native library archive.
		/// </summary>
		/// <remarks>
		///     Specifies SDL_mixer.dll everywhere; will be mapped via .config for mono.
		/// </remarks>
		private const string SDL_MIXER_NATIVE_LIBRARY = "SDL_mixer.dll";
		#endregion string SDL_MIXER_NATIVE_LIBRARY

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
		public const int MIX_MAJOR_VERSION = 1;
		/// <summary>
		/// Minor Version
		/// </summary>
		public const int MIX_MINOR_VERSION = 2;
		/// <summary>
		/// Patch Version
		/// </summary>
		public const int MIX_PATCHLEVEL = 7;
		/// <summary>
		/// The default mixer has this many simultaneous mixing 
		/// channels after the first call to Mix_OpenAudio.
		/// </summary>
		public const int MIX_CHANNELS = 8;

		/// <summary>
		/// Good default sample rate in Hz (samples per second)
		///  for PC sound cards.
		/// </summary>
		public const int MIX_DEFAULT_FREQUENCY = 22050;

		/// <summary>
		/// The suggested default is signed 16bit samples in host byte order.
		/// </summary>
		public static int MIX_DEFAULT_FORMAT 
		{
			get 
			{
				if (Sdl.SDL_BYTEORDER == Sdl.SDL_LIL_ENDIAN)
				{
					return Sdl.AUDIO_S16SYS;
				}
				else
				{
					return Sdl.AUDIO_S16MSB;
				}
			}
		}

		/// <summary>
		/// Stereo sound is a good default.
		/// </summary>
		public const int MIX_DEFAULT_CHANNELS = 2;

		/// <summary>
		/// Maximum value for any volume setting.
		/// </summary>
		/// <remarks>
		/// This is currently the same as <see cref="Sdl.SDL_MIX_MAXVOLUME"/>.
		/// </remarks>
		public const int MIX_MAX_VOLUME = 128;

		/// <summary>
		/// This is the channel number used for post processing effects.
		/// </summary>
		public const int MIX_CHANNEL_POST = -2;

		/// <summary>
		/// A convience definition for the string name of the
		///  environment variable to define when you desire 
		///  the internal effects to sacrifice quality and/or 
		///  RAM for speed. The environment variable must be 
		///  set (else nonexisting) before Mix_OpenAudio is 
		///  called for the setting to take effect.
		/// </summary>
		public const string MIX_EFFECTSMAXSPEED = "MIX_EFFECTSMAXSPEED";
		#endregion Public Constants

		#region Public Enums
		#region Mix_Fading
		//        /// <summary>
		//        /// Fader effect type enumerations
		//        /// </summary>
		//        /// <remarks>
		//        /// Return values from Mix_FadingMusic and Mix_FadingChannel
		//        ///  are of these enumerated values. If no fading is taking 
		//        ///  place on the queried channel or music, then MIX_NO_FADING
		//        ///   is returned. Otherwise they are self explanatory.
		//        /// </remarks>
		//        /// <seealso cref="Mix_FadingChannel"/>
		//        /// <seealso cref="Mix_FadingMusic"/>
		//       public enum Mix_Fading {
		/// <summary>
		/// 
		/// </summary>
		public const int MIX_NO_FADING = 0;
		/// <summary>
		/// 
		/// </summary>
		public const int MIX_FADING_OUT = 1;
		/// <summary>
		/// 
		/// </summary>
		public const int MIX_FADING_IN = 2;
		// }
		#endregion Mix_Fading

		#region Mix_MusicType
		//        /// <summary>
		//        /// Music type enumerations
		//        /// </summary>
		//        /// <remarks>
		//		/// Return values from Mix_GetMusicType are of these enumerated values.
		//		/// If no music is playing then MUS_NONE is returned.
		//		/// If music is playing via an external command then MUS_CMD is returned.
		//		/// Otherwise they are self explanatory.
		//		/// </remarks>
		//		/// <seealso cref="Mix_GetMusicType"/>
		//       public enum Mix_MusicType 
		//		{
		/// <summary>
		/// 
		/// </summary>
		public const int MUS_NONE = 0;
		/// <summary>
		/// 
		/// </summary>
		public const int MUS_CMD = 1;
		/// <summary>
		/// 
		/// </summary>
		public const int MUS_WAV = 2;
		/// <summary>
		/// 
		/// </summary>
		public const int MUS_MOD = 3;
		/// <summary>
		/// 
		/// </summary>
		public const int MUS_MID = 4;
		/// <summary>
		/// 
		/// </summary>
		public const int MUS_OGG = 5;
		/// <summary>
		/// 
		/// </summary>
		public const int MUS_MP3 = 6;
		//       } 
		#endregion Mix_MusicType
		#endregion Public Enums

		#region Public Structs
		#region Mix_Chunk
		/// <summary>
		/// The internal format for an audio chunk
		/// </summary>
		/// <remarks>
		/// The internal format for an audio chunk. 
		/// This stores the sample data, the length in bytes of that data,
		///  and the volume to use when mixing the sample. 
		///  <p>Struct in SDL_mixer.h
		///  <code>
		///  typedef struct Mix_Chunk {
		///		int allocated;
		///		Uint8 *abuf;
		///		Uint32 alen;
		///		Uint8 volume;     /* Per-sample volume, 0-128 */
		///	} Mix_Chunk;
		///  </code></p>
		/// </remarks>
		/// <seealso cref="Mix_VolumeChunk"/>
		/// <seealso cref="Mix_GetChunk"/>
		/// <seealso cref="Mix_LoadWAV"/>
		/// <seealso cref="Mix_LoadWAV_RW"/>
		/// <seealso cref="Mix_FreeChunk"/>
		public struct Mix_Chunk 
		{
			/// <summary>
			/// a boolean indicating whether to free abuf when the chunk 
			/// is freed.
			/// </summary>
			/// <remarks>0 if the memory was not allocated and thus not 
			/// owned by this chunk.
			/// 1 if the memory was allocated and is thus owned by this chunk.
			/// </remarks>
			public int allocated;
			/// <summary>
			/// Pointer to the sample data, which is 
			/// in the output format and sample rate.
			/// </summary>
			public IntPtr abuf;
			/// <summary>
			/// Length of abuf in bytes.
			/// </summary>
			public int alen;
			/// <summary>
			/// 0 = silent, 128 = max volume. 
			/// This takes effect when mixing.
			/// </summary>
			public byte volume;
		} 
		#endregion Mix_Chunk
		#endregion Public Structs

		#region Public Delegates
		#region void MusicFinishedDelegate()
		/// <summary>
		/// 
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MusicFinishedDelegate();
		#endregion void MusicFinishedDelegate()

		#region void MixFunctionDelegate(IntPtr udata, IntPtr stream, int len)
		/// <summary>
		/// 
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MixFunctionDelegate(IntPtr udata, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] stream, int len);
		#endregion void MixFunctionDelegate(IntPtr udata, IntPtr stream, int len)

		#region void ChannelFinishedDelegate(int channel)
		/// <summary>
		/// 
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ChannelFinishedDelegate(int channel);
		#endregion void ChannelFinishedDelegate(int channel)

		#region void MixEffectFunctionDelegate(...)
		/// <summary>
		/// Special effect callback function pointer
		/// </summary>
		/// <remarks>
		/// This is the prototype for effect processing functions. 
		/// These functions are used to apply effects processing on 
		/// a sample chunk. As a channel plays a sample, the registered 
		/// effect functions are called. Each effect would then read and
		///  perhaps alter the len bytes of stream. It may also be 
		///  advantageous to keep the effect state in the udata, with would 
		///  be setup when registering the effect function on a channel.
		/// <p>
		/// <code>
		/// void (*Mix_EffectFunc_t)(int chan, void *stream, int len, void *udata)
		/// </code></p>
		/// </remarks>
		/// <param name="chan">
		/// The channel number that this effect is effecting now.
		/// MIX_CHANNEL_POST is passed in for post processing effects over the 
		/// final mix.
		/// </param>
		/// <param name="stream">
		/// The buffer containing the current sample to process.
		/// </param>
		/// <param name="len">
		/// The length of stream in bytes.
		/// </param>
		/// <param name="udata">
		/// User data pointer that was passed in to Mix_RegisterEffect 
		/// when registering this effect processor function.
		/// </param>
		/// <seealso cref="Mix_RegisterEffect"/>
		/// <seealso cref="Mix_UnregisterEffect"/>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MixEffectFunctionDelegate(int chan, IntPtr stream, int len, IntPtr udata);
		#endregion void MixEffectFunctionDelegate(...)

		#region void MixEffectDoneDelegate(int chan, IntPtr udata)
		/// <summary>
		/// Special effect done callback function pointer
		/// </summary>
		/// <remarks>
		/// This is the prototype for effect processing functions. 
		/// This is called when a channel has finished playing, or 
		/// halted, or is deallocated. This is also called when a processor
		/// is unregistered while processing is active. At that time the effects
		///  processing function may want to reset some internal variables or 
		///  free some memory. It should free memory at least, because the 
		///  processor could be freed after this call.
		/// <p>
		/// <code>void (*Mix_EffectDone_t)(int chan, void *udata)
		/// </code></p></remarks>
		/// <param name="chan">
		/// The channel number that this effect is effecting now.
		/// MIX_CHANNEL_POST is passed in for post processing effects over the 
		/// final mix.
		/// </param>
		/// <param name="udata">
		/// User data pointer that was passed in to Mix_RegisterEffect 
		/// when registering this effect processor function.
		/// </param>
		/// <seealso cref="Mix_RegisterEffect"/>
		/// <seealso cref="Mix_UnregisterEffect"/>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MixEffectDoneDelegate(int chan, IntPtr udata);
		#endregion void MixEffectDoneDelegate(int chan, IntPtr udata)
		#endregion Public Delegates
		
		#region SdlMixer Methods
		#region SDL_version MIX_VERSION() 
		/// <summary>
		/// This method can be used to fill a version structure with the compile-time
		/// version of the SDL_mixer library.
		/// </summary>
		/// <returns>
		///     This function returns a <see cref="Sdl.SDL_version"/> struct containing the
		///     compiled version number
		/// </returns>
		/// <remarks>
		///     <p>
		///     Binds to C-function call in SDL_mixer.h:
		///     <code>#define SDL_MIX_VERSION(X)
		/// {
		/// (X)->major = SDL_MIX_MAJOR_VERSION;
		/// (X)->minor = SDL_MIX_MINOR_VERSION;
		/// (X)->patch = SDL_MIX_PATCHLEVEL;
		/// }</code>
		///     </p>
		/// </remarks>
		public static Sdl.SDL_version MIX_VERSION() 
		{ 
			Sdl.SDL_version sdlVersion = new Sdl.SDL_version();
			sdlVersion.major = MIX_MAJOR_VERSION;
			sdlVersion.minor = MIX_MINOR_VERSION;
			sdlVersion.patch = MIX_PATCHLEVEL;
			return sdlVersion;
		} 
		#endregion SDL_version MIX_VERSION() 

		#region IntPtr Mix_Linked_VersionInternal()
		//     const SDL_version * Mix_Linked_Version(void)
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="Mix_Linked_Version"), SuppressUnmanagedCodeSecurity]
		private static extern IntPtr Mix_Linked_VersionInternal();
		#endregion IntPtr Mix_Linked_VersionInternal()

		#region SDL_version Mix_Linked_Version() 
		/// <summary>
		///     Using this you can compare the runtime version to the 
		/// version that you compiled with.
		/// </summary>
		/// <returns>
		///     This function gets the version of the dynamically 
		/// linked SDL_mixer library in an <see cref="Sdl.SDL_version"/> struct.
		/// </returns>
		/// <remarks>
		///     <p>
		///     Binds to C-function call in SDL_mixer.h:
		///     <code>const SDL_version * Mix_Linked_Version(void)</code>
		///     </p>
		/// </remarks>
		public static Sdl.SDL_version Mix_Linked_Version() 
		{ 
			return (Sdl.SDL_version)Marshal.PtrToStructure(
				Mix_Linked_VersionInternal(), 
				typeof(Sdl.SDL_version)); 
		} 
		#endregion SDL_version Mix_Linked_Version() 
	
		#region int Mix_OpenAudio(...)
		/// <summary>
		/// Open the mixer with a certain audio format
		/// </summary>
		/// <remarks>
		/// Initialize the mixer API.
		/// <p>
		///	This must be called before using other functions in this 
		///	library.
		///	SDL must be initialized with SDL_INIT_AUDIO before this call. 
		///	frequency would be 44100 for 44.1KHz, which is CD audio rate. 
		///	Most games use 22050, because 44100 requires too much CPU power
		///	 on older computers. chunksize is the size of each mixed sample.
		///	  The smaller this is the more your hooks will be called. 
		///	  If make this too small on a slow system, sound may skip. 
		///	  If made to large, sound effects will lag behind the action more.
		///	   You want a happy medium for your target computer.
		///	    You also may make this 4096, or larger, if you are
		///	     just playing music. MIX_CHANNELS(8) mixing channels
		///	      will be allocated by default. You may call this function
		///	       multiple times, however you will have to call Mix_CloseAudio
		///	        just as many times for the device to actually close.
		///	         The format will not changed on subsequent calls. 
		///	         So you will have to close all the way before
		///	          trying to open with different format parameters.</p>
		///	          
		///	          <p>format is based on SDL audio support, see SDL_audio.h. Here are the values listed there:</p>
		///
		/// <code>
		/// AUDIO_U8
		/// Unsigned 8-bit samples
		///
		/// AUDIO_S8
		/// Signed 8-bit samples
		///
		/// AUDIO_U16LSB
		/// Unsigned 16-bit samples, in little-endian byte order
		///
		/// AUDIO_S16LSB
		/// Signed 16-bit samples, in little-endian byte order
		///
		/// AUDIO_U16MSB
		/// Unsigned 16-bit samples, in big-endian byte order
		///
		/// AUDIO_S16MSB
		/// Signed 16-bit samples, in big-endian byte order
		///
		/// AUDIO_U16
		/// same as AUDIO_U16LSB (for backwards compatability probably)
		///
		/// AUDIO_S16
		/// same as AUDIO_S16LSB (for backwards compatability probably)
		///
		/// AUDIO_U16SYS
		/// Unsigned 16-bit samples, in system byte order
		///
		/// AUDIO_S16SYS
		/// Signed 16-bit samples, in system byte order
		/// </code>
		///
		/// <p>MIX_DEFAULT_FORMAT is the same as AUDIO_S16SYS.</p>
		/// <p>Binds to C-funtion in SDL_mixer.h
		/// <code>
		/// int Mix_OpenAudio(int frequency, Uint16 format, int channels, int chunksize)
		/// </code></p>
		/// </remarks>
		/// <param name="frequency">
		/// Output sampling frequency in samples per second (Hz).
		/// you might use MIX_DEFAULT_FREQUENCY(22050) 
		/// since that is a good value for most games.
		/// </param>
		/// <param name="format">
		/// Output sample format.
		/// </param>
		/// <param name="channels">
		/// Number of sound channels in output.
		/// Set to 2 for stereo, 1 for mono. 
		/// This has nothing to do with mixing channels.
		/// </param>
		/// <param name="chunksize">
		/// Bytes used per output sample.
		/// </param>
		/// <returns>
		/// 0 on success, -1 on errors 
		/// </returns>
		/// <example>
		/// <code>
		/// // start SDL with audio support
		///		if(SDL_Init(SDL_INIT_AUDIO)==-1) 
		///	{
		///		printf("SDL_Init: %s\n", SDL_GetError());
		///		exit(1);
		///	}
		///	// open 44.1KHz, signed 16bit, system byte order,
		///	//      stereo audio, using 1024 byte chunks
		///	if(Mix_OpenAudio(44100, MIX_DEFAULT_FORMAT, 2, 1024)==-1) 
		///{
		///	printf("Mix_OpenAudio: %s\n", Mix_GetError());
		///	exit(2);
		///}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_CloseAudio"/>
		/// <seealso cref="Mix_QuerySpec"/>
		/// <seealso cref="Mix_AllocateChannels"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_OpenAudio(
			int frequency, short format, int channels, int chunksize);
		#endregion int Mix_OpenAudio(...)

		#region int Mix_AllocateChannels(int numchans)
		/// <summary>
		/// Dynamically change the number of channels managed by the mixer.
		/// If decreasing the number of channels, the upper channels are
		/// stopped. 
		/// <p>This function returns the new number of allocated channels.</p>
		/// </summary>
		/// <remarks>
		/// Set the number of channels being mixed. 
		/// This can be called multiple times, 
		/// even with sounds playing. If numchans is less
		///  than the current number of channels, then the
		///   higher channels will be stopped, freed, and
		///    therefore not mixed any longer. It's 
		///    probably not a good idea to change the
		///     size 1000 times a second though.
		/// If any channels are deallocated, 
		/// any callback set by Mix_ChannelFinished 
		/// will be called when each channel 
		/// is halted to be freed. Note: passing 
		/// in zero WILL free all mixing channels, 
		/// however music will still play. 
		/// </remarks>
		/// <param name="numchans">
		/// Number of channels to allocate for mixing. 
		/// A negative number will not do anything, it will tell
		///  you how many channels are currently allocated.
		/// </param>
		/// <returns>
		/// The number of channels allocated.
		/// Never fails...but a high number of channels
		/// can segfault if you run out of memory. We're talking REALLY high!
		/// </returns>
		/// <example>
		/// <code>
		/// // allocate 16 mixing channels
		/// Mix_AllocateChannels(16);
		/// </code></example>
		/// <seealso cref="Mix_OpenAudio"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_AllocateChannels(int numchans);
		#endregion int Mix_AllocateChannels(int numchans)

		#region int Mix_QuerySpec(out int frequency, out short format, out int channels)
		/// <summary>
		/// Get output format.
		/// </summary>
		/// <remarks>
		/// Get the actual audio format in use by the opened 
		/// audio device.
		///  This may or may not match the parameters you
		///   passed to Mix_OpenAudio.
		///   <p>Binds to C-function in SDL_mixer.h
		///   <code>int Mix_QuerySpec(int *frequency, Uint16 *format, int *channels)
		///   </code></p>
		/// </remarks>
		/// <param name="channels">
		/// A pointer to an int where the 
		/// number of audio channels will be stored.
		/// 2 will mean stereo, 1 will mean mono.
		/// </param>
		/// <param name="format">
		/// A pointer to a short where the output format actually
		///  being used by the audio device will be stored.
		/// </param>
		/// <param name="frequency">
		/// A pointer to an int 
		/// where the frequency actually used by the opened 
		/// audio device will be stored. 
		/// </param>
		/// <returns>
		/// 0 on error. If the device was open the number of times 
		/// it was opened will be returned. The values of the 
		/// arguments variables are not set on an error.
		/// </returns>
		/// <example>
		/// <code>
		/// // get and print the audio format in use
		///		int numtimesopened, frequency, channels;
		///		Uint16 format;
		///		numtimesopened=Mix_QuerySpec(&amp;frequency, &amp;format, &amp;channels);
		///		if(!numtimesopened) 
		///	{
		///		printf("Mix_QuerySpec: %s\n",Mix_GetError());
		///	}
		///	else 
		///{
		///	char *format_str="Unknown";
		///	switch(format) 
		///{
		///	case AUDIO_U8: format_str="U8"; break;
		///	case AUDIO_S8: format_str="S8"; break;
		///	case AUDIO_U16LSB: format_str="U16LSB"; break;
		///	case AUDIO_S16LSB: format_str="S16LSB"; break;
		///	case AUDIO_U16MSB: format_str="U16MSB"; break;
		///	case AUDIO_S16MSB: format_str="S16MSB"; break;
		///}
		///	printf("opened=%d times  frequency=%dHz  format=%s  channels=%d",
		///	numtimesopened, frequency, format, channels);
		///}
		/// </code>
		/// </example>
		///  <seealso cref="Mix_OpenAudio"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_QuerySpec(
			out int frequency, 
			out short format, out int channels);
		#endregion int Mix_QuerySpec(out int frequency, out short format, out int channels)

		#region IntPtr Mix_LoadWAV_RW(IntPtr src, int freesrc)
		/// <summary>
		/// Load a wave file or a music (.mod .s3m .it .xm) file
		/// </summary>
		/// <remarks>
		/// Load src for use as a sample. 
		/// This can load WAVE, AIFF, RIFF, OGG, and VOC formats. 
		/// Using SDL_RWops is not covered here, but they enable 
		/// you to load from almost any source.
		/// <p>Binds to C-function in SDL_mixer.h
		///   <code>Mix_Chunk *Mix_LoadWAV_RW(SDL_RWops *src, int freesrc)
		///   </code></p>
		/// </remarks>
		/// <param name="src">
		/// The source SDL_RWops as a pointer. 
		/// The sample is loaded from this.
		/// </param>
		/// <param name="freesrc">
		/// A non-zero value mean is will automatically 
		/// close/free the src for you.
		/// </param>
		/// <returns>
		/// a pointer to the sample as a Mix_Chunk. 
		/// NULL is returned on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // load sample.wav in to sample
		///		Mix_Chunk *sample;
		///		sample=Mix_LoadWAV_RW(SDL_RWFromFile("sample.wav", "rb"), 1);
		///		if(!sample) 
		///	{
		///		printf("Mix_LoadWAV_RW: %s\n", Mix_GetError());
		///		// handle error
		///	}
		/// </code></example>
		/// <seealso cref="Mix_LoadWAV"/>
		/// <seealso cref="Mix_QuickLoad_WAV"/>
		/// <seealso cref="Mix_FreeChunk"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr Mix_LoadWAV_RW(IntPtr src, int freesrc);
		#endregion IntPtr Mix_LoadWAV_RW(IntPtr src, int freesrc)

		#region IntPtr Mix_LoadWAV(string file)
		/// <summary>
		/// Load WAV from a file.
		/// </summary>
		/// <param name="file">
		/// File name to load sample from.
		/// </param>
		/// <remarks>
		/// Load file for use as a sample. 
		/// This is actually Mix_LoadWAV_RW(SDL_RWFromFile(file, "rb"), 1).
		///  This can load WAVE, AIFF, RIFF, OGG, and VOC files.
		///  <p>Binds to C-function in SDL_mixer.h
		///   <code>Mix_Chunk *Mix_LoadWAV(char *file)
		///   </code></p>
		/// </remarks>
		/// <returns>
		/// a pointer to the sample as a Mix_Chunk. 
		/// NULL is returned on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // load sample.wav in to sample
		///		Mix_Chunk *sample;
		///		sample=Mix_LoadWAV("sample.wav");
		///		if(!sample) 
		///	{
		///		printf("Mix_LoadWAV: %s\n", Mix_GetError());
		///		// handle error
		///	}
		/// </code></example>
		/// <seealso cref="Mix_LoadWAV_RW"/>
		/// <seealso cref="Mix_QuickLoad_WAV"/>
		/// <seealso cref="Mix_FreeChunk"/>
		public static IntPtr Mix_LoadWAV(string file) 
		{
			return Mix_LoadWAV_RW(Sdl.SDL_RWFromFile(file, "rb"), 1);
		}
		#endregion IntPtr Mix_LoadWAV(string file)

		#region IntPtr Mix_LoadMUS(string file)
		/// <summary>
		/// Load a music file into a Mix_Music
		/// </summary>
		/// <param name="file">Name of music file to use.
		/// </param>
		/// <returns>
		/// A pointer to a Mix_Music. NULL is returned on errors.
		/// </returns>
		/// <remarks>
		/// Load music file to use. This can load WAVE, MOD, MIDI, OGG, MP3, 
		/// and any file that you use a command to play with.
		/// <p>If you are using an external command to play the music, 
		/// you must call Mix_SetMusicCMD before this, otherwise the 
		/// internal players will be used. Alternatively, if you have 
		/// set an external command up and don't want to use it, you 
		/// must call Mix_SetMusicCMD(NULL) to use the built-in players 
		/// again.</p>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>Mix_Music *Mix_LoadMUS(const char *file)
		/// </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // load the MP3 file "music.mp3" to play as music
		///		Mix_Music *music;
		///		music=Mix_LoadMUS("music.mp3");
		///		if(!music) 
		///	{
		///		printf("Mix_LoadMUS(\"music.mp3\"): %s\n", Mix_GetError());
		///		// this might be a critical error...
		///	}
		/// </code></example>
		/// <seealso cref="Mix_SetMusicCMD"/>
		/// <seealso cref="Mix_PlayMusic"/>
		/// <seealso cref="Mix_FadeInMusic"/>
		/// <seealso cref="Mix_FadeInMusicPos"/> 
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr Mix_LoadMUS(string file);
		#endregion IntPtr Mix_LoadMUS(string file)

		#region IntPtr Mix_LoadMUS_RW(IntPtr rw)
		/// <summary>
		/// Load a music file from an SDL_RWop object (Ogg and MikMod specific currently)
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>Mix_Music *Mix_LoadMUS_RW(SDL_RWops *rw)
		/// </code></p>
		/// </remarks>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr Mix_LoadMUS_RW(IntPtr rw);
		#endregion IntPtr Mix_LoadMUS_RW(IntPtr rw)

		#region IntPtr Mix_QuickLoad_WAV(IntPtr mem)
		/// <summary>
		/// Load a wave file of the mixer format from a memory buffer
		/// </summary>
		/// <remarks>
		/// Load mem as a WAVE/RIFF file into a new sample. 
		/// The WAVE in mem must be already in the output format.
		///  It would be better to use Mix_LoadWAV_RW if you aren't sure.
		/// Note: This function does very little checking. 
		/// If the format mismatches the output format, or 
		/// if the buffer is not a WAVE, it will not return an error.
		///  This is probably a dangerous function to use.
		///  <p>Binds to C-function in SDL_mixer.h
		/// <code>Mix_Chunk *Mix_QuickLoad_WAV(Uint8 *mem)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="mem">
		/// Memory buffer containing a WAVE file in output format. 
		/// </param>
		/// <returns>
		/// a pointer to the sample as a Mix_Chunk. 
		/// NULL is returned on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // quick-load a wave from memory
		///		// Uint8 *wave; // I assume you have the wave loaded raw,
		///		// or compiled in the program...
		///		Mix_Chunk *wave_chunk;
		///		if(!(wave_chunk=Mix_QuickLoad_WAV(wave))) 
		///	{
		///		printf("Mix_QuickLoad_WAV: %s\n", Mix_GetError());
		///		// handle error
		///	}
		///	</code></example>
		///	<seealso cref="Mix_LoadWAV"/>
		/// <seealso cref="Mix_QuickLoad_RAW"/>
		/// <seealso cref="Mix_FreeChunk"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY,
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr Mix_QuickLoad_WAV(
			IntPtr mem);
		#endregion IntPtr Mix_QuickLoad_WAV(IntPtr mem)

		#region IntPtr Mix_QuickLoad_RAW(IntPtr mem, int len)
		/// <summary>
		/// Load raw audio data of the mixer format from a memory buffer 
		/// </summary>
		/// <remarks>
		/// Load mem as a raw sample. The data in mem must be already in 
		/// the output format. If you aren't sure what you are doing, 
		/// this is not a good function for you!
		/// <p>Note: This function does very little checking. 
		/// If the format mismatches the output format it 
		/// will not return an error. This is probably a 
		/// dangerous function to use.</p>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>Mix_Chunk *Mix_QuickLoad_RAW(Uint8 *mem)
		/// </code>
		/// </p> 
		/// </remarks>
		/// <param name="len"></param>
		/// <param name="mem">
		/// Memory buffer containing a WAVE file in output format. 
		/// Load mem as a raw sample. 
		/// The data in mem must be already in the output format. 
		/// If you aren't sure what you are doing, 
		/// this is not a good function for you!
		/// </param>
		/// <returns>
		/// a pointer to the sample as a Mix_Chunk. 
		/// NULL is returned on errors, such as when out of memory.
		/// </returns>
		/// <example>
		/// <code>
		/// // quick-load a raw sample from memory
		///		// Uint8 *raw; // I assume you have the raw data here,
		///		// or compiled in the program...
		///		Mix_Chunk *raw_chunk;
		///		if(!(raw_chunk=Mix_QuickLoad_RAW(raw))) 
		///	{
		///		printf("Mix_QuickLoad_RAW: %s\n", Mix_GetError());
		///		// handle error
		///	}
		/// </code></example>
		/// <seealso cref="Mix_LoadWAV"/>
		/// <seealso cref="Mix_QuickLoad_WAV"/>
		/// <seealso cref="Mix_FreeChunk"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr Mix_QuickLoad_RAW(
			IntPtr mem, int len);
		#endregion IntPtr Mix_QuickLoad_RAW(IntPtr mem, int len)

		#region void Mix_FreeChunk(IntPtr chunk)
		/// <summary>
		/// Free an audio chunk previously loaded
		/// </summary>
		/// <remarks>
		/// Free the memory used in chunk, and free chunk itself as well. 
		/// Do not use chunk after this without loading a new sample to 
		/// it. Note: It's a bad idea to free a chunk that is still 
		/// being played...
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>void Mix_FreeChunk(Mix_Chunk *chunk)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="chunk">
		/// Pointer to the Mix_Chunk to free.
		/// </param>
		/// <example>
		/// <code>
		/// // free the sample
		///		// Mix_Chunk *sample;
		///		Mix_FreeChunk(sample);
		///		sample=NULL; // to be safe...
		///		</code></example>
		///	<seealso cref="Mix_LoadWAV"/>
		/// <seealso cref="Mix_QuickLoad_WAV"/>
		/// <seealso cref="Mix_LoadWAV_RW"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void Mix_FreeChunk(IntPtr chunk);
		#endregion void Mix_FreeChunk(IntPtr chunk)

		#region void Mix_FreeMusic(IntPtr music)
		/// <summary>
		/// Free a Mix_Music
		/// </summary>
		/// <remarks>
		/// Free the loaded music. If music is playing it will be halted. 
		/// If music is fading out, then this function will wait (blocking)
		///  until the fade out is complete.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>void Mix_FreeMusic(Mix_Music *music)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // free music
		///		Mix_Music *music;
		///		Mix_FreeMusic(music);
		///		music=NULL; // so we know we freed it...
		/// </code>
		/// </example>
		/// <param name="music">Pointer to Mix_Music to free.</param>
		/// <seealso cref="Mix_LoadMUS"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void Mix_FreeMusic(IntPtr music);
		#endregion void Mix_FreeMusic(IntPtr music)

		#region Mix_MusicType Mix_GetMusicType(IntPtr music)
		/// <summary>
		/// Find out the music format of a mixer music, 
		/// or the currently playing music, if 'music' is NULL.
		/// </summary>
		/// <remarks>
		/// Tells you the file format encoding of the music. 
		/// This may be handy when used with Mix_SetMusicPosition,
		/// and other music functions that vary based on the type 
		/// of music being played. If you want to know the type of 
		/// music currently being played, pass in NULL to music.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>Mix_MusicType Mix_GetMusicType(const Mix_Music *music)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="music">The music to get the type of.
		/// NULL will get the currently playing music type.
		/// </param>
		/// <returns>The type of music or if music is NULL then 
		/// the currently playing music type, otherwise MUS_NONE
		///  if no music is playing.</returns>
		///  <seealso cref="Mix_SetPosition"/>
		///  <example>
		///  <code>
		///  // print the type of music currently playing
		///		switch(Mix_GetMusicType(NULL))
		///	{
		///		case MUS_NONE:
		///		MUS_CMD:
		///		printf("Command based music is playing.\n");
		///		break;
		///		MUS_WAV:
		///		printf("WAVE/RIFF music is playing.\n");
		///		break;
		///		MUS_MOD:
		///		printf("MOD music is playing.\n");
		///		break;
		///		MUS_MID:
		///		printf("MIDI music is playing.\n");
		///		break;
		///		MUS_OGG:
		///		printf("OGG music is playing.\n");
		///		break;
		///		MUS_MP3:
		///		printf("MP3 music is playing.\n");
		///		break;
		///		default:
		///		printf("Unknown music is playing.\n");
		///		break;
		///	}
		///  </code></example>
		///  <seealso cref="Mix_SetPosition"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_GetMusicType(IntPtr music);
		#endregion Mix_MusicType Mix_GetMusicType(IntPtr music)

		#region void Mix_SetPostMix(MixFunctionDelegate mix_func, IntPtr arg)
		/// <summary>
		/// Hook in a postmix processor
		/// </summary>
		/// <remarks>
		/// Hook a processor function mix_func to the postmix stream for post
		///  processing effects. You may just be reading the data and 
		///  displaying it, or you may be altering the stream to add an
		///  echo. Most processors also have state data that they allocate 
		///  as they are in use, this would be stored in the arg pointer
		///   data space. This processor is never really finished, until
		///    the audio device is closed, or you pass NULL as the mix_func.
		/// <p>There can only be one postmix function used at a time through 
		/// this method. Use 
		/// Mix_RegisterEffect(MIX_CHANNEL_POST, mix_func, NULL, arg) to 
		/// use multiple postmix processors.</p>
		/// <p>This postmix processor is run AFTER all the registered 
		/// postmixers set up by Mix_RegisterEffect.</p>
		/// <p>
		/// <code>void Mix_SetPostMix(void (*mix_func)(void *udata, Uint8 *stream, int len), void *arg)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // make a passthru processor function that does nothing...
		///		void noEffect(void *udata, Uint8 *stream, int len)
		///		{
		///			// you could work with stream here...
		///		}
		///		...
		///		// register noEffect as a postmix processor
		///		Mix_SetPostMix(noEffect, NULL);
		/// </code>
		/// </example>
		/// <param name="mix_func">The function pointer for the postmix processor.
		/// NULL unregisters the current postmixer.</param>
		/// <param name="arg">A pointer to data to pass into the mix_func's 
		/// udata parameter. It is a good place to keep the state data for 
		/// the processor, especially if the processor is made to handle 
		/// multiple channels at the same time.
		/// This may be NULL, depending on the processor.</param>
		/// <seealso cref="Mix_RegisterEffect"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void Mix_SetPostMix(MixFunctionDelegate mix_func, IntPtr arg);
		#endregion void Mix_SetPostMix(MixFunctionDelegate mix_func, IntPtr arg)

		#region void Mix_HookMusic(MixFunctionDelegate mix_func, IntPtr arg)
		/// <summary>
		/// Hook for a custom music player
		/// </summary>
		/// <remarks>
		/// This sets up a custom music player function. The function will 
		/// be called with arg passed into the udata parameter when the 
		/// mix_func is called. The stream parameter passes in the audio 
		/// stream buffer to be filled with len bytes of music. The music 
		/// player will then be called automatically when the mixer needs 
		/// it. Music playing will start as soon as this is called. All the 
		/// music playing and stopping functions have no effect on music 
		/// after this. Pause and resume will work. Using a custom music 
		/// player and the internal music player is not possible, the custom 
		/// music player takes priority. To stop the custom music player call
		///  Mix_HookMusic(NULL, NULL).
		/// <p>NOTE: NEVER call SDL_Mixer functions, nor SDL_LockAudio, 
		/// from a callback function.</p>
		/// <p>
		/// <code>void Mix_HookMusic(void (*mix_func)(void *udata, Uint8 *stream, int len), void *arg)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // make a music play function
		///		// it expects udata to be a pointer to an int
		///		void myMusicPlayer(void *udata, Uint8 *stream, int len)
		///		{
		///			int i, pos=*(int*)udata;
		///
		///			// fill buffer with...uh...music...
		///			for(i=0; i&lt;len; i++)
		///				stream[i]=(i+pos)&amp;ff;
		///
		///			// set udata for next time
		///			pos+=len;
		///			*(int*)udata=pos;
		///		}
		///		...
		///		// use myMusicPlayer for playing...uh...music
		///		int music_pos=0;
		///		Mix_HookMusic(myMusicPlayer, &amp;music_pos);
		/// </code>
		/// </example>
		/// <param name="mix_func">Function pointer to a music player mixer function.
		/// NULL will stop the use of the music player, 
		/// returning the mixer to using the internal music players 
		/// like usual.</param>
		/// <param name="arg">
		/// This is passed to the mix_func's udata parameter when it is called.
		/// </param>
		/// <seealso cref="Mix_SetMusicCMD"/>
		/// <seealso cref="Mix_GetMusicHookData"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void Mix_HookMusic(MixFunctionDelegate mix_func, IntPtr arg);
		#endregion void Mix_HookMusic(MixFunctionDelegate mix_func, IntPtr arg)

		#region void Mix_HookMusicFinished(MusicFinishedDelegate music_finished)
		/// <summary>
		/// Add your own callback when the music has finished playing.
		/// This callback is only called if the music finishes naturally.
		/// </summary>
		/// <remarks>
		/// This sets up a function to be called when music playback is halted. 
		/// Any time music stops, the music_finished function will be called. 
		/// Call with NULL to remove the callback.
		/// <p>NOTE: NEVER call SDL_Mixer functions, nor SDL_LockAudio, 
		/// from a callback function.</p>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>void Mix_HookMusicFinished(void (*music_finished)())
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="music_finished">
		/// Function pointer to a void function(). 
		/// NULL will remove the hook.
		/// </param>
		/// <example>
		/// <code>
		/// // make a music finished function
		///		void musicFinished()
		///		{
		///			printf("Music stopped.\n");
		///		}
		///		...
		///		// use musicFinished for when music stops
		///		Mix_HookMusicFinished(musicFinished);
		/// </code></example>
		/// <seealso cref="Mix_HaltMusic"/>
		/// <seealso cref="Mix_FadeOutMusic"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void Mix_HookMusicFinished(MusicFinishedDelegate music_finished);
		#endregion void Mix_HookMusicFinished(MusicFinishedDelegate music_finished)

		#region IntPtr Mix_GetMusicHookData()
		/// <summary>
		/// Get a pointer to the user data for the current music hook
		/// </summary>
		/// <remarks>
		/// Get the arg passed into Mix_HookMusic.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>void *Mix_GetMusicHookData()
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // retrieve the music hook data pointer
		/// void *data;
		/// data=Mix_GetMusicHookData();
		/// </code></example>
		/// <returns>the arg pointer.</returns>
		/// <seealso cref="Mix_HookMusic"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr Mix_GetMusicHookData();
		#endregion IntPtr Mix_GetMusicHookData()

		#region void Mix_ChannelFinished(ChannelFinishedDelegate channel_finished)
		/// <summary>
		/// Set callback for when channel finishes playing
		/// </summary>
		/// <remarks>
		/// When channel playback is halted, then the specified 
		/// channel_finished function is called. The channel parameter 
		/// will contain the channel number that has finished.
		/// <p>NOTE: NEVER call SDL_Mixer functions, 
		/// nor SDL_LockAudio, from a callback function.</p>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>void Mix_ChannelFinished(void (*channel_finished)(int channel))
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // a simple channel_finished function
		///		void channelDone(int channel) 
		///		{
		///			printf("channel %d finished playback.\n",channel);
		///		}
		///
		///		// make a channelDone function
		///		void channelDone(int channel)
		///		{
		///			printf("channel %d finished playing.\n", channel);
		///		}
		///		...
		///		// set the callback for when a channel stops playing
		///		Mix_ChannelFinished(channelDone);
		/// </code></example>
		/// <param name="channel_finished">
		/// Function to call when any channel finishes playback. 
		/// </param>
		/// <seealso cref="Mix_HaltChannel"/>
		/// <seealso cref="Mix_ExpireChannel"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void Mix_ChannelFinished(
			ChannelFinishedDelegate channel_finished);
		#endregion void Mix_ChannelFinished(ChannelFinishedDelegate channel_finished)

		#region int Mix_RegisterEffect(...)
		/// <summary>
		/// Hook a processor to a channel
		/// </summary>
		/// <remarks>
		/// Hook a processor function f into a channel for post processing
		///  effects. You may just be reading the data and displaying it, 
		///  or you may be altering the stream to add an echo. Most 
		///  processors also have state data that they allocate as they 
		///  are in use, this would be stored in the arg pointer data space.
		///   When a processor is finished being used, any function passed 
		///   into d will be called, which is when your processor should clean
		///    up the data in the arg data space.
		/// <p>The effects are put into a linked list, and always appended to 
		/// the end, meaning they always work on previously registered effects
		///  output. Effects may be added multiple times in a row. Effects are
		///   cumulative this way.</p>
		/// <p>
		/// <code>int Mix_RegisterEffect(int chan, Mix_EffectFunc_t f, Mix_EffectDone_t d, void *arg)
		/// </code></p></remarks>
		/// <param name="f">
		/// The function pointer for the effects processor.
		/// </param>
		/// <param name="arg"></param>
		/// <param name="chan">channel number to register f and d on.
		/// Use MIX_CHANNEL_POST to process the postmix stream.</param>
		/// <param name="d">
		/// The function pointer for any cleanup routine to be called 
		/// when the channel is done playing a sample.
		/// This may be NULL for any processors that don't need to 
		/// clean up any memory or other dynamic data.
		/// </param>
		/// <returns>
		/// Zero on errors, such as a nonexisting channel
		/// </returns>
		/// <example>
		/// <code>
		/// // make a passthru processor function that does nothing...
		///		void noEffect(int chan, void *stream, int len, void *udata)
		///		{
		///			// you could work with stream here...
		///		}
		///		...
		///		// register noEffect as a postmix processor
		///		if(!Mix_RegisterEffect(MIX_CHANNEL_POST, noEffect, NULL, NULL)) 
		///	{
		///		printf("Mix_RegisterEffect: %s\n", Mix_GetError());
		///	}
		/// </code></example>
		/// <seealso cref="Mix_UnregisterEffect"/>
		/// <seealso cref="Mix_UnregisterAllEffects"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_RegisterEffect(int chan, 
			MixEffectFunctionDelegate f, 
			MixEffectDoneDelegate d,
			IntPtr arg);
		#endregion int Mix_RegisterEffect(...)

		#region int Mix_UnregisterEffect(...)
		/// <summary>
		/// Unhook a processor from a channel
		/// </summary>
		/// <remarks>
		/// Remove the oldest (first found) registered effect function 
		/// f from the effect list for channel. This only removes the 
		/// first found occurance of that function, so it may need to 
		/// be called multiple times if you added the same function multiple
		///  times, just stop removing when Mix_UnregisterEffect returns an
		///   error, to remove all occurances of f from a channel.
		/// <p>If the channel is active the registered effect will have its 
		/// Mix_EffectDone_t function called, if it was specified in 
		/// Mix_RegisterEffect.</p>
		/// <p>
		/// <code>int Mix_UnregisterEffect(int channel, Mix_EffectFunc_t f)
		/// </code></p></remarks>
		/// <param name="f">The function to remove from channel.</param>
		/// <param name="chan">Channel number to remove f from as a post processor.
		/// <p>Use MIX_CHANNEL_POST for the postmix stream.</p></param>
		/// <returns>
		/// Zero on errors, such as invalid channel, 
		/// or effect function not registered on channel.
		/// </returns>
		/// <example>
		/// <code>
		/// // unregister the noEffect from the postmix effects
		/// // this removes all occurances of noEffect registered to the postmix
		/// while(Mix_UnregisterEffect(MIX_CHANNEL_POST, noEffect));
		/// // you may print Mix_GetError() if you want to check it.
		/// // it should say "No such effect registered" after this loop.
		/// </code></example>
		/// <seealso cref="Mix_RegisterEffect"/>
		/// <seealso cref="Mix_UnregisterAllEffects"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_UnregisterEffect(int chan, 
			MixEffectFunctionDelegate f);
		#endregion int Mix_UnregisterEffect(...)

		#region int Mix_UnregisterAllEffects(int channel)
		/// <summary>
		/// Unhook all processors from a channel
		/// </summary>
		/// <remarks>
		/// This removes all effects registered to channel. 
		/// If the channel is active all the registered effects will 
		/// have their Mix_EffectDone_t functions called, if they 
		/// were specified in Mix_RegisterEffect.
		/// <p>
		/// <code>int Mix_UnregisterAllEffects(int channel)
		/// </code></p></remarks>
		/// <param name="channel">
		/// Channel to remove all effects from.
		/// Use MIX_CHANNEL_POST for the postmix stream.
		/// </param>
		/// <returns>
		/// Zero on errors, such as channel not existing.
		/// </returns>
		/// <example>
		/// <code>
		/// // remove all effects from channel 0
		///		if(!Mix_UnregisterAllEffects(0)) 
		///	{
		///		printf("Mix_UnregisterAllEffects: %s\n", Mix_GetError());
		///	}
		/// </code></example>
		/// <seealso cref="Mix_UnregisterEffect"/>
		/// <seealso cref="Mix_RegisterEffect"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_UnregisterAllEffects(int channel);
		#endregion int Mix_UnregisterAllEffects(int channel)

		#region int Mix_SetPanning(int channel, byte left, byte right)
		/// <summary>
		/// Stereo panning
		/// </summary>
		/// <remarks>
		/// This effect will only work on stereo audio. Meaning you called 
		/// Mix_OpenAudio with 2 channels (MIX_DEFAULT_CHANNELS). The easiest
		///  way to do true panning is to call 
		///  Mix_SetPanning(channel, left, 254 - left); so that the total 
		///  volume is correct, if you consider the maximum volume to be 127
		///   per channel for center, or 254 max for left, this works, but 
		///   about halves the effective volume.
		/// <p>This Function registers the effect for you, so don't try to 
		/// Mix_RegisterEffect it yourself.</p>
		/// <p>NOTE: Setting both left and right to 255 will unregister the 
		/// effect from channel. You cannot unregister it any other way, 
		/// unless you use Mix_UnregisterAllEffects on the channel.</p>
		/// <p>NOTE: Using this function on a mono audio device will not
		/// register the effect, nor will it return an error status.</p>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_SetPanning(int channel, Uint8 left, Uint8 right)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel number to register this effect on.
		/// Use MIX_CHANNEL_POST to process the postmix stream.
		/// </param>
		/// <param name="left">
		/// Volume for the left channel, range is 0(silence) to 255(loud) 
		/// </param>
		/// <param name="right">
		/// Volume for the left channel, range is 0(silence) to 255(loud)
		/// </param>
		/// <returns>
		/// Zero on errors, such as bad channel, or if Mix_RegisterEffect failed.
		/// </returns>
		/// <example>
		/// <code>
		/// // pan channel 1 halfway to the left
		///		if(!Mix_SetPanning(1, 255, 127)) 
		///	{
		///		printf("Mix_SetPanning: %s\n", Mix_GetError());
		///		// no panning, is it ok?
		///	}
		///	</code>
		/// </example>
		/// <seealso cref="Mix_SetPosition"/>
		/// <seealso cref="Mix_UnregisterAllEffects"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_SetPanning(
			int channel, byte left, byte right);
		#endregion int Mix_SetPanning(int channel, byte left, byte right)

		#region int Mix_SetPosition(int channel, short angle, byte distance)
		/// <summary>
		/// Panning(angular) and distance
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_SetPosition(int channel, Sint16 angle, Uint8 distance)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel number to register this effect on.
		/// Use MIX_CHANNEL_POST to process the postmix stream.
		/// </param>
		/// <param name="angle">
		/// Direction in relation to forward from 0 to 360 degrees. 
		/// Larger angles will be reduced to this range using angles % 360.
		/// 0 = directly in front.
		/// 90 = directly to the right.
		/// 180 = directly behind.
		/// 270 = directly to the left.
		/// So you can see it goes clockwise starting at directly in front.
		/// This ends up being similar in effect to Mix_SetPanning.
		/// </param>
		/// <param name="distance">
		/// The distance from the listener, from 0(near/loud) to 255(far/quiet).
		/// This is the same as the Mix_SetDistance effect.
		///	</param>
		/// <returns>
		/// Zero on errors, such as an invalid channel, 
		/// or if Mix_RegisterEffect failed.
		/// </returns>
		/// <example>
		/// <code>
		/// // set channel 2 to be behind and right, and 100 units away
		///		if(!Mix_SetPosition(2, 135, 100)) 
		///	{
		///		printf("Mix_SetPosition: %s\n", Mix_GetError());
		///		// no position effect, is it ok?
		///	}
		/// </code></example>
		/// <seealso cref="Mix_SetPanning"/>
		/// <seealso cref="Mix_SetDistance"/>
		/// <seealso cref="Mix_UnregisterAllEffects"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_SetPosition(
			int channel, short angle, byte distance);
		#endregion int Mix_SetPosition(int channel, short angle, byte distance)

		#region int Mix_SetDistance(int channel, byte distance)
		/// <summary>
		/// Distance attenuation (volume)
		/// </summary>
		/// <remarks>
		/// This effect simulates a simple attenuation of volume due to distance. 
		/// The volume never quite reaches silence, even at max distance.
		/// NOTE: Using a distance of 0 will cause the effect to unregister 
		/// itself from channel. You cannot unregister it any other way, 
		/// unless you use Mix_UnregisterAllEffects on the channel.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_SetDistance(int channel, Uint8 distance)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel number to register this effect on.
		/// Use MIX_CHANNEL_POST to process the postmix stream.
		/// </param>
		/// <param name="distance">
		/// Specify the distance from the listener, 
		/// from 0(close/loud) to 255(far/quiet). 
		/// </param>
		/// <returns>
		/// Zero on errors, such as an invalid channel, 
		/// or if Mix_RegisterEffect failed.
		/// </returns>
		/// <example>
		/// <code>
		/// // distance channel 1 to be farthest away
		///		if(!Mix_SetDistance(1, 255)) 
		///	{
		///		printf("Mix_SetDistance: %s\n", Mix_GetError());
		///		// no distance, is it ok?
		///	}
		/// </code></example>
		/// <seealso cref="Mix_SetPosition"/>
		/// <seealso cref="Mix_UnregisterAllEffects"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_SetDistance(
			int channel, byte distance);
		#endregion int Mix_SetDistance(int channel, byte distance)

		// int Mix_SetReverb(int channel, Uint8 echo) is not part of the public API

		#region int Mix_SetReverseStereo(int channel, int flip)
		/// <summary>
		/// Swap stereo left and right
		/// </summary>
		/// <remarks>
		/// Simple reverse stereo, swaps left and right channel sound.
		/// <p>NOTE: Using a flip of 0, will cause the effect to unregister 
		/// itself from channel. You cannot unregister it any other way, 
		/// unless you use Mix_UnregisterAllEffects on the channel.</p>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_SetReverseStereo(int channel, int flip)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel number to register this effect on.
		/// Use MIX_CHANNEL_POST to process the postmix stream.
		/// </param>
		/// <param name="flip">
		/// Must be non-zero to work, means nothing to the effect processor itself.
		/// set to zero to unregister the effect from channel.
		/// </param>
		/// <returns>
		/// Zero on errors, such as an invalid channel, or if Mix_RegisterEffect failed.
		/// </returns>
		/// <example>
		/// <code>
		/// // set the total mixer output to be reverse stereo
		///		if(!Mix_SetReverseStereo(MIX_CHANNEL_POST, 1)) 
		///	{
		///		printf("Mix_SetReverseStereo: %s\n", Mix_GetError());
		///		// no reverse stereo, is it ok?
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_UnregisterAllEffects"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_SetReverseStereo(
			int channel, int flip);
		#endregion int Mix_SetReverseStereo(int channel, int flip)

		#region int Mix_ReserveChannels(int num)
		/// <summary>
		/// Prevent channels from being used in default group
		/// </summary>
		/// <remarks>
		/// Reserve num channels from being used when playing samples when 
		/// passing in -1 as a channel number to playback functions. The 
		/// channels are reserved starting from channel 0 to num-1. Passing
		///  in zero will unreserve all channels. Normally SDL_mixer starts 
		///  without any channels reserved.
		///  <p>
		///  The following functions are affected by this setting:
		///  <br><see cref="Mix_PlayChannel"/></br>
		///  <br><see cref="Mix_PlayChannelTimed"/></br>
		///  <br><see cref="Mix_FadeInChannel"/></br>
		///  <br><see cref="Mix_FadeInChannelTimed"/></br>
		///  </p>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_ReserveChannels(int num)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="num">
		/// Number of channels to reserve from default mixing.
		/// Zero removes all reservations.
		/// </param>
		/// <returns>The number of channels reserved. 
		/// Never fails, but may return less channels than you ask for,
		///  depending on the number of channels previously allocated.
		///  </returns>
		///  <example>
		///  <code>
		///  // reserve the first 8 mixing channels
		///		int reserved_count;
		///		reserved_count=Mix_ReserveChannels(8);
		///		if(reserved_count!=8) 
		///	{
		///		printf("reserved %d channels from default mixing.\n",reserved_count);
		///		printf("8 channels were not reserved!\n");
		///		// this might be a critical error...
		///	}
		///  </code></example>
		///  <seealso cref="Mix_AllocateChannels"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_ReserveChannels(int num);
		#endregion int Mix_ReserveChannels(int num)

		#region int Mix_GroupChannel(int which, int tag)
		/// <summary>
		/// Add/remove channel to/from group
		/// </summary>
		/// <remarks>
		/// Add which channel to group tag, or reset 
		/// it's group to the default group tag (-1).
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_GroupChannel(int which, int tag)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="which">
		/// Channel number of channels to assign tag to.
		/// </param>
		/// <param name="tag">
		/// A group number Any positive numbers (including zero).
		/// -1 is the default group. Use -1 to remove a group tag essentially.
		/// </param>
		/// <returns>
		/// True(1) on success. False(0) is returned when 
		/// the channel specified is invalid.
		/// </returns>
		/// <example>
		/// <code>
		/// // add channel 0 to group 1
		///		if(!Mix_GroupChannel(0,1)) 
		///	{
		///		// bad channel, apparently channel 1 isn't allocated
		///	}
		/// </code></example>
		/// <seealso cref="Mix_GroupChannels"/>
		/// <seealso cref="Mix_AllocateChannels"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_GroupChannel(int which, int tag);
		#endregion int Mix_GroupChannel(int which, int tag)

		#region int Mix_GroupChannels(int from, int to, int tag)
		/// <summary>
		/// Assign several consecutive channels to a group
		/// </summary>
		/// <remarks>
		/// Add channels starting at from up through to to group tag, 
		/// or reset it's group to the default group tag (-1). 
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_GroupChannels(int from, int to, int tag)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="from">
		/// First Channel number of channels to assign tag to. 
		/// Must be less or equal to to.
		/// </param>
		/// <param name="to">
		/// Last Channel number of channels to assign tag to. Must be greater or equal to from.
		/// </param>
		/// <param name="tag">
		/// A group number. Any positive numbers (including zero).
		/// -1 is the default group. Use -1 to remove a group tag essentially.
		/// </param>
		/// <returns>
		/// The number of tagged channels on success. If that number is less 
		/// than to-from+1 then some channels were no tagged because they didn't 
		/// exist.
		/// </returns>
		/// <example>
		/// <code>
		/// // add channels 0 through 7 to group 1
		///		if(Mix_GroupChannels(0,7,1)!=8) 
		///	{
		///		// some bad channels, apparently some channels aren't allocated
		///	}
		/// </code></example>
		/// <seealso cref="Mix_GroupChannel"/>
		/// <seealso cref="Mix_AllocateChannels"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_GroupChannels(
			int from, int to, int tag);
		#endregion int Mix_GroupChannels(int from, int to, int tag)

		#region int Mix_GroupAvailable(int tag)
		/// <summary>
		/// Get first inactive channel in group.
		/// </summary>
		/// <remarks>
		/// Find the first available (not playing) channel in group tag.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_GroupAvailable(int tag)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="tag">
		/// A group number Any positive numbers (including zero).
		/// -1 will search ALL channels.
		/// </param>
		/// <returns>
		/// The channel found on success. -1 is returned when no 
		/// channels in the group are available.
		/// </returns>
		/// <example>
		/// <code>
		/// // find the first available channel in group 1
		///		int channel;
		///		channel=Mix_GroupAvailable(1);
		///		if (channel==-1) 
		///	{
		///		// no channel available...
		///		// perhaps search for oldest or newest channel in use...
		///	}
		/// </code></example>
		/// <seealso cref="Mix_GroupOldest"/>
		/// <seealso cref="Mix_GroupNewer"/>
		/// <seealso cref="Mix_GroupChannel"/>
		/// <seealso cref="Mix_GroupChannels"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_GroupAvailable(int tag);
		#endregion int Mix_GroupAvailable(int tag)

		#region int Mix_GroupCount(int tag)
		/// <summary>
		/// Get number of channels in group.
		/// </summary>
		/// <remarks>
		/// Count the number of channels in group tag.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_GroupCount(int tag)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="tag">
		/// A group number Any positive numbers (including zero).
		/// -1 will count ALL channels.
		/// </param>
		/// <returns>
		/// The number of channels found in the group. This function never fails.
		/// </returns>
		/// <example>
		/// <code>
		/// // count the number of channels in group 1
		/// printf("There are %d channels in group 1\n", Mix_GroupCount(1));
		/// </code></example>
		/// <seealso cref="Mix_GroupChannel"/>
		/// <seealso cref="Mix_GroupChannels"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_GroupCount(int tag);
		#endregion int Mix_GroupCount(int tag)

		#region int Mix_GroupOldest(int tag)
		/// <summary>
		/// Get oldest busy channel in group
		/// </summary>
		/// <remarks>
		/// Find the oldest actively playing channel in group tag.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_GroupOldest(int tag)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="tag">
		/// A group number Any positive numbers (including zero).
		/// -1 will search ALL channels.
		/// </param>
		/// <returns>
		/// The channel found on success. -1 is returned when no channels in
		///  the group are playing or the group is empty.
		/// </returns>
		/// <example>
		/// <code>
		/// // find the oldest playing channel in group 1
		///		int channel;
		///		channel=Mix_GroupOldest(1);
		///		if (channel==-1) 
		///	{
		///		// no channel playing or allocated...
		///		// perhaps just search for an available channel...
		///	}
		/// </code></example>
		/// <seealso cref="Mix_GroupNewer"/>
		/// <seealso cref="Mix_GroupAvailable"/>
		/// <seealso cref="Mix_GroupChannel"/>
		/// <seealso cref="Mix_GroupChannels"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_GroupOldest(int tag);
		#endregion int Mix_GroupOldest(int tag)

		#region int Mix_GroupNewer(int tag)
		/// <summary>
		/// Get youngest busy channel in group
		/// </summary>
		/// <remarks>
		/// Find the newest, most recently started, actively playing 
		/// channel in group tag.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_GroupNewer(int tag)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="tag">
		/// A group number Any positive numbers (including zero).
		/// -1 will search ALL channels.
		/// </param>
		/// <returns>
		/// The channel found on success. -1 is returned when no channels in 
		/// the group are playing or the group is empty.
		/// </returns>
		/// <example>
		/// <code>
		/// // find the newest playing channel in group 1
		///		int channel;
		///		channel=Mix_GroupNewer(1);
		///		if (channel==-1) 
		///	{
		///		// no channel playing or allocated...
		///		// perhaps just search for an available channel...
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_GroupOldest"/>
		/// <seealso cref="Mix_GroupAvailable"/>
		/// <seealso cref="Mix_GroupChannel"/>
		/// <seealso cref="Mix_GroupChannels"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_GroupNewer(int tag);
		#endregion int Mix_GroupNewer(int tag)

		#region int Mix_PlayChannelTimed(...)
		/// <summary>
		/// Play loop and limit by time.
		/// </summary>
		/// <remarks>
		/// If the sample is long enough and has enough 
		/// loops then the sample will stop after ticks milliseconds. 
		/// Otherwise this function is the same as <see cref="Mix_PlayChannel"/>.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_PlayChannelTimed(int channel, Mix_Chunk *chunk, int loops, int ticks)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel to play on, or -1 for the first free unreserved channel.
		/// </param>
		/// <param name="chunk">
		/// Sample to play.
		/// </param>
		/// <param name="loops">
		/// Number of loops, -1 is infinite loops.
		/// Passing one here plays the sample twice (1 loop).
		/// </param>
		/// <param name="ticks">
		/// Millisecond limit to play sample, at most.
		/// If not enough loops or the sample chunk is not long enough,
		/// then the sample may stop before this timeout occurs.
		/// -1 means play forever.
		/// </param>
		/// <returns>
		/// the channel the sample is played on. 
		/// On any errors, -1 is returned.
		/// </returns>
		/// <example>
		/// <code>
		/// // play sample on first free unreserved channel
		///		// play it for half a second
		///		// Mix_Chunk *sample; //previously loaded
		///		if(Mix_PlayChannelTimed(-1, sample, -1 , 500)==-1) 
		///	{
		///		printf("Mix_PlayChannel: %s\n",Mix_GetError());
		///		// may be critical error, or maybe just no channels were free.
		///		// you could allocated another channel in that case...
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_PlayChannel"/>
		/// <seealso cref="Mix_FadeInChannelTimed"/>
		/// <seealso cref="Mix_FadeOutChannel"/>
		/// <seealso cref="Mix_ReserveChannels"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_PlayChannelTimed(
			int channel, IntPtr chunk, int loops, int ticks);
		#endregion int Mix_PlayChannelTimed(...)

		#region int Mix_PlayChannel(int channel, IntPtr chunk, int loops)
		/// <summary>
		/// Play loop.
		/// </summary>
		/// <remarks>
		/// Play chunk on channel, or if channel is -1, 
		/// pick the first free unreserved channel. 
		/// The sample will play for loops+1 number of times, 
		/// unless stopped by halt, or fade out, or setting a 
		/// new expiration time of less time than it would have 
		/// originally taken to play the loops, or closing the mixer.
		/// <p>Note: this just calls Mix_PlayChannelTimed() 
		/// with ticks set to -1.</p>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_PlayChannel(int channel, Mix_Chunk *chunk, int loops)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel to play on, or -1 for the first free unreserved channel. 
		/// </param>
		/// <param name="chunk">
		/// Sample to play. 
		/// </param>
		/// <param name="loops">
		/// Number of loops, -1 is infinite loops.
		/// Passing one here plays the sample twice (1 loop).
		/// </param>
		/// <returns>
		/// the channel the sample is played on. On any errors,
		///  -1 is returned.
		/// </returns>
		/// <example>
		/// <code>
		/// // play sample on first free unreserved channel
		///		// play it exactly once through
		///		// Mix_Chunk *sample; //previously loaded
		///		if(Mix_PlayChannel(-1, sample, 1)==-1) 
		///	{
		///		printf("Mix_PlayChannel: %s\n",Mix_GetError());
		///		// may be critical error, or maybe just no channels were free.
		///		// you could allocated another channel in that case...
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_PlayChannelTimed"/>
		/// <seealso cref="Mix_FadeInChannel"/>
		/// <seealso cref="Mix_HaltChannel"/>
		/// <seealso cref="Mix_ExpireChannel"/>
		/// <seealso cref="Mix_ReserveChannels"/>
		public static int Mix_PlayChannel(int channel, IntPtr chunk, int loops)
		{
			return Mix_PlayChannelTimed(channel, chunk, loops, -1);
		}
		#endregion int Mix_PlayChannel(int channel, IntPtr chunk, int loops)

		#region int Mix_PlayMusic(IntPtr music, int loops)
		/// <summary>
		/// Play music, with looping
		/// </summary>
		/// <remarks>
		/// Play the loaded music loop times through from start to finish. 
		/// The previous music will be halted, or if fading out it waits
		///  (blocking) for that to finish.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_PlayMusic(Mix_Music *music, int loops)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="music">
		/// Pointer to Mix_Music to play.
		/// </param>
		/// <param name="loops">
		/// number of times to play through the music.
		/// <br>0 plays the music zero times...</br>
		/// <br>-1 plays the music forever (or as close as it can get to that)</br>
		/// </param>
		/// <returns>
		/// 0 on success, or -1 on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // play music forever
		///		// Mix_Music *music; // I assume this has been loaded already
		///		if(Mix_PlayMusic(music, -1)==-1) 
		///	{
		///		printf("Mix_PlayMusic: %s\n", Mix_GetError());
		///		// well, there's no music, but most games don't break without music...
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_FadeInMusic"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_PlayMusic(IntPtr music, int loops);
		#endregion int Mix_PlayMusic(IntPtr music, int loops)

		#region int Mix_FadeInMusic(IntPtr music, int loops, int ms)
		/// <summary>
		/// Play music, with looping, and fade in
		/// </summary>
		/// <remarks>
		/// Fade in over ms milliseconds of time, the loaded music, 
		/// playing it loop times through from start to finish.
		/// The fade in effect only applies to the first loop.
		/// Any previous music will be halted, or if it is fading out i
		/// t will wait (blocking) for the fade to complete.
		/// This function is the same as Mix_FadeInMusicPos(music, loops, ms, 0).
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_FadeInMusic(Mix_Music *music, int loops, int ms)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="music">
		/// Pointer to Mix_Music to play.
		/// </param>
		/// <param name="loops">
		/// number of times to play through the music.
		/// <br>
		/// 0 plays the music zero times...
		/// </br>
		/// <br>
		/// -1 plays the music forever (or as close as it can get to that)
		/// </br>
		/// </param>
		/// <param name="ms">
		/// Milliseconds for the fade-in effect to complete.
		/// </param>
		/// <returns>
		/// 0 on success, or -1 on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // play music forever, fading in over 2 seconds
		///		// Mix_Music *music; // I assume this has been loaded already
		///		if(Mix_FadeInMusic(music, -1, 2000)==-1) 
		///	{
		///		printf("Mix_FadeInMusic: %s\n", Mix_GetError());
		///		// well, there's no music, but most games don't break without music...
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_PlayMusic"/>
		/// <seealso cref="Mix_FadeInMusicPos"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_FadeInMusic(IntPtr music, int loops, int ms);
		#endregion int Mix_FadeInMusic(IntPtr music, int loops, int ms)

		#region int Mix_FadeInMusicPos(...)
		/// <summary>
		/// Play music from a start point, with looping, and fade in
		/// </summary>
		/// <remarks>
		/// Fade in over ms milliseconds of time, the loaded music, 
		/// playing it loop times through from start to finish.
		/// The fade in effect only applies to the first loop. The first
		///  time the music is played, it posistion will be set to position,
		///   which means different things for different types of music files,
		///    see Mix_SetMusicPosition for more info on that. Any previous 
		///    music will be halted, or if it is fading out it will wait 
		///    (blocking) for the fade to complete.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_FadeInMusicPos(Mix_Music *music, int loops, int ms, double position)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="music">
		/// Pointer to Mix_Music to play.
		/// </param>
		/// <param name="loops">
		/// number of times to play through the music.
		/// <br>
		/// 0 plays the music zero times...
		/// </br>
		/// <br>
		/// -1 plays the music forever (or as close as it can get to that)
		/// </br>
		/// </param>
		/// <param name="ms">
		/// Milliseconds for the fade-in effect to complete.
		/// </param>
		/// <param name="position">
		/// Position to play from, see <see cref="Mix_SetMusicPosition"/> for meaning.
		/// </param>
		/// <returns>
		/// 0 on success, or -1 on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // play music forever, fading in over 2 seconds
		///		// Mix_Music *music; // I assume this has been loaded already
		///		if(Mix_FadeInMusicPos(music, -1, 2000)==-1) 
		///	{
		///		printf("Mix_FadeInMusic: %s\n", Mix_GetError());
		///		// well, there's no music, but most games don't break without music...
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_PlayMusic"/>
		/// <seealso cref="Mix_FadeInMusic"/>
		/// <seealso cref="Mix_SetMusicPosition"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_FadeInMusicPos(
			IntPtr music, int loops, int ms, double position);
		#endregion int Mix_FadeInMusicPos(...)

		#region int Mix_FadeInChannelTimed(...)
		/// <summary>
		/// Play loop with fade in and limit by time
		/// </summary>
		/// <remarks>
		/// If the sample is long enough and has enough loops then the sample
		///  will stop after ticks milliseconds. Otherwise this function 
		///  is the same as <see cref="Mix_FadeInChannel"/>.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_FadeInChannelTimed(int channel, Mix_Chunk *chunk, int loops, int ms, int ticks)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel to play on, or -1 for the first free unreserved channel.
		/// </param>
		/// <param name="chunk">
		/// Sample to play.
		/// </param>
		/// <param name="loops">
		/// Number of loops, -1 is infinite loops.
		/// </param>
		/// <param name="ms">
		/// Milliseconds of time that the fade-in effect should 
		/// take to go from silence to full volume.
		/// </param>
		/// <param name="ticks">Millisecond limit to play sample, at most.
		/// If not enough loops or the sample chunk is not long enough, 
		/// then the sample may stop before this timeout occurs.
		///  -1 means play forever.</param>
		/// <returns>
		/// the channel the sample is played on. On any errors, -1 is returned.
		/// </returns>
		/// <example>
		/// <code>
		/// // play sample on first free unreserved channel
		///		// play it for half a second
		///		// Mix_Chunk *sample; //previously loaded
		///		if(Mix_PlayChannelTimed(-1, sample, -1 , 500)==-1) 
		///	{
		///		printf("Mix_PlayChannel: %s\n",Mix_GetError());
		///		// may be critical error, or maybe just no channels were free.
		///		// you could allocated another channel in that case...
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_PlayChannelTimed"/>
		/// <seealso cref="Mix_FadeInChannel"/>
		/// <seealso cref="Mix_HaltChannel"/>
		/// <seealso cref="Mix_FadingChannel"/>
		/// <seealso cref="Mix_ReserveChannels"/>
		/// <seealso cref="Mix_ExpireChannel"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_FadeInChannelTimed(
			int channel, IntPtr chunk, int loops, int ms, int ticks);
		#endregion int Mix_FadeInChannelTimed(...)

		#region int Mix_FadeInChannel(...)
		/// <summary>
		/// Play loop with fade in
		/// </summary>
		/// <remarks>
		/// Play chunk on channel, or if channel is -1, 
		/// pick the first free unreserved channel.
		/// The channel volume starts at 0 and fades up to 
		/// full volume over ms milliseconds of time. 
		/// The sample may end before the fade-in is 
		/// complete if it is too short or doesn't have enough loops. 
		/// The sample will play for loops+1 number of times, 
		/// unless stopped by halt, or fade out, or setting 
		/// a new expiration time of less time than it would 
		/// have originally taken to play the loops, or closing the mixer.
		/// Note: this just calls <see cref="Mix_FadeInChannelTimed"/> 
		/// with ticks set to -1.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_FadeInChannel(int channel, Mix_Chunk *chunk, int loops, int ms)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel to play on, or -1 for the first free unreserved channel.
		/// </param>
		/// <param name="chunk">Sample to play.</param>
		/// <param name="loops">
		/// Number of loops, -1 is infinite loops.
		/// Passing one here plays the sample twice (1 loop).
		/// </param>
		/// <param name="ms">
		/// Milliseconds of time that the fade-in effect 
		/// should take to go from silence to full volume.
		/// </param>
		/// <returns>
		/// the channel the sample is played on. 
		/// On any errors, -1 is returned.
		/// </returns>
		/// <example>
		/// <code>
		/// // play sample on first free unreserved channel
		///		// play it exactly 3 times through
		///		// fade in over one second
		///		// Mix_Chunk *sample; //previously loaded
		///		if(Mix_FadeInChannel(-1, sample, 3, 1000)==-1) 
		///	{
		///		printf("Mix_FadeInChannel: %s\n",Mix_GetError());
		///		// may be critical error, or maybe just no channels were free.
		///		// you could allocated another channel in that case...
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_PlayChannel"/>
		/// <seealso cref="Mix_FadeInChannelTimed"/>
		/// <seealso cref="Mix_FadingChannel"/>
		/// <seealso cref="Mix_FadeOutChannel"/>
		/// <seealso cref="Mix_ReserveChannels"/>
		public static int Mix_FadeInChannel(
			int channel, IntPtr chunk, int loops, int ms) 
		{
			return Mix_FadeInChannelTimed(channel, chunk, loops, ms, -1);
		}
		#endregion int Mix_FadeInChannel(...)

		#region int Mix_Volume(int channel, int volume)
		/// <summary>
		/// Set the mix volume of a channel
		/// </summary>
		/// <remarks>
		/// Set the volume for any allocated channel. 
		/// If channel is -1 then all channels at are set at once. 
		/// The volume is applied during the final mix, along 
		/// with the sample volume. So setting this volume to 
		/// 64 will halve the output of all samples played on 
		/// the specified channel. All channels default to a 
		/// volume of 128, which is the max. Newly allocated 
		/// channels will have the max volume set, so setting 
		/// all channels volumes does not affect subsequent 
		/// channel allocations.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_Volume(int channel, int volume)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel to set mix volume for.
		/// -1 will set the volume for all allocated channels.
		/// </param>
		/// <param name="volume">
		/// The volume to use from 0 to MIX_MAX_VOLUME(128).
		/// If greater than MIX_MAX_VOLUME,
		/// then it will be set to MIX_MAX_VOLUME.
		/// If less than 0 then the volume will not be set.
		/// </param>
		/// <returns>
		/// current volume of the channel. 
		/// If channel is -1, the average volume is returned.
		/// </returns>
		/// <example>
		/// <code>
		/// // set channel 1 to half volume
		///		Mix_Volume(1,MIX_MAX_VOLUME/2);
		///
		///		// print the average volume
		///		printf("Average volume is %d\n",Mix_Volume(-1,-1));
		/// </code>
		/// </example>
		/// <seealso cref="Mix_VolumeChunk"/>
		/// <seealso cref="Mix_VolumeMusic"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_Volume(int channel, int volume);
		#endregion int Mix_Volume(int channel, int volume)

		#region int Mix_VolumeChunk(IntPtr chunk, int volume)
		/// <summary>
		/// Set mix volume
		/// </summary>
		/// <remarks>
		/// Set chunk-&gt;volume to volume.
		/// The volume setting will take effect 
		/// when the chunk is used on a channel, 
		/// being mixed into the output.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_VolumeChunk(Mix_Chunk *chunk, int volume)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="chunk">
		/// Pointer to the Mix_Chunk to set the volume in.
		/// </param>
		/// <param name="volume">
		/// The volume to use from 0 to MIX_MAX_VOLUME(128).
		/// If greater than MIX_MAX_VOLUME,
		/// then it will be set to MIX_MAX_VOLUME.
		/// If less than 0 then chunk-&gt;volume will not be set.
		/// </param>
		/// <returns>
		/// previous chunk-&gt;volume setting. 
		/// if you passed a negative value for volume then this 
		/// volume is still the current volume for the chunk.
		/// </returns>
		/// <example>
		/// <code>
		/// // set the sample's volume to 1/2
		///		// Mix_Chunk *sample;
		///		int previous_volume;
		///		previous_volume=Mix_VolumeChunk(sample, MIX_MAX_VOLUME/2);
		/// 	printf("previous_volume: %d\n", previous_volume);
		/// </code>
		/// </example>
		/// <seealso cref="Mix_Chunk"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_VolumeChunk(IntPtr chunk, int volume);
		#endregion int Mix_VolumeChunk(IntPtr chunk, int volume)

		#region int Mix_VolumeMusic(int volume)
		/// <summary>
		/// Set music volume
		/// </summary>
		/// <remarks>
		/// Set the volume to volume, if it is 0 or greater, and return the 
		/// previous volume setting. Setting the volume during a fade will 
		/// not work, the faders use this function to perform their effect! 
		/// Setting volume while using an external music player set by 
		/// <see cref="Mix_SetMusicCMD"/> will have no effect, and 
		/// <see cref="Mix_GetError"/> will 
		/// show the reason why not.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_VolumeMusic(int volume)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="volume">
		/// Music volume, from 0 to MIX_MAX_VOLUME(128).
		/// Values greater than MIX_MAX_VOLUME will use MIX_MAX_VOLUME.
		/// -1 does not set the volume, but does return the current volume setting.
		/// </param>
		/// <returns>
		/// The previous volume setting.
		/// </returns>
		/// <example>
		/// <code>
		/// // set the music volume to 1/2 maximum, and then check it
		///		printf("volume was    : %d\n", Mix_VolumeMusic(MIX_MAX_VOLUME/2));
		///		printf("volume is now : %d\n", Mix_VolumeMusic(-1));
		/// </code>
		/// </example>
		/// <seealso cref="Mix_FadeInMusic"/>
		/// <seealso cref="Mix_FadeOutMusic"/>
		/// <seealso cref="Mix_SetMusicCMD"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_VolumeMusic(int volume);
		#endregion int Mix_VolumeMusic(int volume)

		#region int Mix_HaltChannel(int channel)
		/// <summary>
		/// Stop playing on a channel
		/// </summary>
		/// <remarks>
		/// Halt channel playback, or all channels if -1 is passed in.
		/// Any callback set by Mix_ChannelFinished will be called.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_HaltChannel(int channel)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel to stop playing, or -1 for all channels.
		/// </param>
		/// <returns>
		/// always returns zero. (kinda silly)
		/// </returns>
		/// <example>
		/// <code>
		/// // halt playback on all channels
		/// Mix_HaltChannel(-1);
		/// </code></example>
		/// <seealso cref="Mix_ExpireChannel"/>
		/// <seealso cref="Mix_FadeOutChannel"/>
		/// <seealso cref="Mix_ChannelFinished"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_HaltChannel(int channel);
		#endregion int Mix_HaltChannel(int channel)

		#region int Mix_HaltGroup(int tag)
		/// <summary>
		/// Stop a group 
		/// </summary>
		/// <remarks>
		/// Halt playback on all channels in group tag.
		/// Any callback set by Mix_ChannelFinished will be called once for each channel that stops. 
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_HaltGroup(int tag)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="tag">
		/// Group to fade out.
		/// NOTE: -1 will NOT halt all channels. Use Mix_HaltChannel(-1) for that instead.
		/// </param>
		/// <returns>
		/// always returns zero. (more silly than <see cref="Mix_HaltChannel"/>) 
		/// </returns>
		/// <example>
		/// <code>
		/// // halt playback on all channels in group 1
		/// Mix_HaltGroup(1);
		/// </code>
		/// </example>
		/// <seealso cref="Mix_FadeOutGroup"/>
		/// <seealso cref="Mix_HaltChannel"/>
		/// <seealso cref="Mix_ChannelFinished"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_HaltGroup(int tag);
		#endregion int Mix_HaltGroup(int tag)

		#region int Mix_HaltMusic()
		/// <summary>
		/// Stop music playback
		/// </summary>
		/// <remarks>
		/// Halt playback of music. This interrupts music fader effects. 
		/// Any callback set by Mix_HookMusicFinished will be called 
		/// when the music stops.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_HaltMusic()
		/// </code>
		/// </p>
		/// </remarks>
		/// <returns>always returns zero. (even more silly than Mix_HaltGroup)
		/// </returns>
		/// <example>
		/// <code>
		/// // halt music playback
		/// Mix_HaltMusic();
		/// </code>
		/// </example>
		/// <seealso cref="Mix_FadeOutMusic"/>
		/// <seealso cref="Mix_HookMusicFinished"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_HaltMusic();
		#endregion int Mix_HaltMusic()

		#region int Mix_ExpireChannel(int channel, int ticks)
		/// <summary>
		/// Change the timed stoppage of a channel
		/// </summary>
		/// <remarks>
		/// Halt channel playback, or all channels if -1 is passed in,
		///  after ticks milliseconds. Any callback set by 
		///  <see cref="Mix_ChannelFinished"/> 
		///  will be called when the channel expires.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_ExpireChannel(int channel, int ticks)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel to stop playing, or -1 for all channels.
		/// </param>
		/// <param name="ticks">
		/// Milliseconds until channel(s) halt playback. 
		/// </param>
		/// <returns>
		/// Number of channels set to expire. Whether or not they are active.
		/// </returns>
		/// <example>
		/// <code>
		/// // halt playback on all channels in 2 seconds
		/// Mix_ExpireChannel(-1, 2000);
		/// </code>
		/// </example>
		/// <seealso cref="Mix_HaltChannel"/>
		/// <seealso cref="Mix_FadeOutChannel"/>
		/// <seealso cref="Mix_ChannelFinished"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_ExpireChannel(int channel, int ticks);
		#endregion int Mix_ExpireChannel(int channel, int ticks)

		#region int Mix_FadeOutChannel(int which, int ms)
		/// <summary>
		/// Stop playing channel after timed fade out
		/// </summary>
		/// <remarks>
		/// Gradually fade out which channel over ms milliseconds starting 
		/// from now. The channel will be halted after the fade out is 
		/// completed. Only channels that are playing are set to fade out,
		///  including paused channels. Any callback set by 
		///  <see cref="Mix_ChannelFinished"/> will be called when the channel
		///   finishes fading out.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_FadeOutChannel(int which, int ms)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="which">
		/// Channel to fade out, or -1 to fade all channels out.
		/// </param>
		/// <param name="ms">
		/// Milliseconds of time that the fade-out effect 
		/// should take to go to silence, starting now.
		/// </param>
		/// <returns>The number of channels set to fade out.
		/// </returns>
		/// <example>
		/// <code>
		/// // fade out all channels to finish 3 seconds from now
		/// printf("starting fade out of %d channels\n", Mix_FadeOutChannel(-1, 3000));
		/// </code>
		/// </example>
		/// <seealso cref="Mix_FadeInChannel"/>
		/// <seealso cref="Mix_FadeInChannelTimed"/>
		/// <seealso cref="Mix_FadingChannel"/>
		/// <seealso cref="Mix_ChannelFinished"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_FadeOutChannel(int which, int ms);
		#endregion int Mix_FadeOutChannel(int which, int ms)

		#region int Mix_FadeOutGroup(int tag, int ms)
		/// <summary>
		/// Fade out a group over time
		/// </summary>
		/// <remarks>
		/// Gradually fade out channels in group tag over ms milliseconds
		///  starting from now. The channels will be halted after the fade
		///   out is completed. Only channels that are playing are set to 
		///   fade out, including paused channels. Any callback set by 
		///   <see cref="Mix_ChannelFinished"/> will be called when each 
		///   channel finishes fading out.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_FadeOutGroup(int tag, int ms)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="tag">
		/// Group to fade out.
		/// NOTE: -1 will NOT fade all channels out. 
		/// Use Mix_FadeOutChannel(-1) for that instead.
		/// </param>
		/// <param name="ms">
		/// Milliseconds of time that the fade-out effect 
		/// should take to go to silence, starting now.
		/// </param>
		/// <returns>
		/// The number of channels set to fade out.
		/// </returns>
		/// <example>
		/// <code>
		/// // fade out all channels in group 1 to finish 3 seconds from now
		/// printf("starting fade out of %d channels\n", Mix_FadeOutGroup(1, 3000));
		/// </code>
		/// </example>
		/// <seealso cref="Mix_HaltGroup"/>
		/// <seealso cref="Mix_FadeOutChannel"/>
		/// <seealso cref="Mix_FadingChannel"/>
		/// <seealso cref="Mix_ChannelFinished"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_FadeOutGroup(int tag, int ms);
		#endregion int Mix_FadeOutGroup(int tag, int ms)

		#region int Mix_FadeOutMusic(int ms)
		/// <summary>
		/// Stop music, with fade out
		/// </summary>
		/// <remarks>
		/// Gradually fade out the music over ms milliseconds starting from 
		/// now. The music will be halted after the fade out is completed. 
		/// Only when music is playing and not fading already are set to 
		/// fade out, including paused channels. Any callback set by 
		/// <see cref="Mix_HookMusicFinished"/> will be called when 
		/// the music finishes fading out.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_FadeOutMusic(int ms)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="ms">
		/// Milliseconds of time that the fade-out effect 
		/// should take to go to silence, starting now.
		/// </param>
		/// <returns>1 on success, 0 on failure.</returns>
		/// <example>
		/// <code>
		/// // fade out music to finish 3 seconds from now
		///		while(!Mix_FadeOutMusic(3000) &amp;&amp; Mix_PlayingMusic()) 
		///	{
		///		// wait for any fades to complete
		///		SDL_Delay(100);
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_HaltMusic"/>
		/// <seealso cref="Mix_FadingMusic"/>
		/// <seealso cref="Mix_PlayingMusic"/>
		/// <seealso cref="Mix_HookMusicFinished"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_FadeOutMusic(int ms);
		#endregion int Mix_FadeOutMusic(int ms)

		#region Mix_Fading Mix_FadingMusic()
		/// <summary>
		/// Get status of current music fade activity
		/// </summary>
		/// <remarks>
		/// Tells you if music is fading in, out, or not at all. 
		/// Does not tell you if the channel is playing anything, 
		/// or paused, so you'd need to test that separately.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>Mix_Fading Mix_FadingMusic() 
		/// </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// the fading status. Never returns an error.
		/// </returns>
		/// <example>
		/// <code>
		/// // check the music fade status
		///		switch(Mix_FadingMusic()) 
		///	{
		///		case MIX_NO_FADING:
		///		printf("Not fading music.\n");
		///		break;
		///		case MIX_FADING_OUT:
		///		printf("Fading out music.\n");
		///		break;
		///		case MIX_FADING_IN:
		///		printf("Fading in music.\n");
		///		break;
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_PausedMusic"/>
		/// <seealso cref="Mix_PlayingMusic"/>
		/// <seealso cref="Mix_FadeInMusicPos"/>
		/// <seealso cref="Mix_FadeOutMusic"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_FadingMusic();
		#endregion Mix_Fading Mix_FadingMusic()

		#region Mix_Fading Mix_FadingChannel(int which)
		/// <summary>
		/// Get the fade status of a channel
		/// </summary>
		/// <remarks>
		/// Tells you if which channel is fading in, out, or not. 
		/// Does not tell you if the channel is playing anything, 
		/// or paused, so you'd need to test that separately.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>Mix_Fading Mix_FadingChannel(int which)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="which">
		/// Channel to get the fade activity status from.
		/// -1 is not valid, and will probably crash the program.
		/// </param>
		/// <returns>the fading status. Never returns an error.
		/// </returns>
		/// <example>
		/// <code>
		/// // check the fade status on channel 0
		///		switch(Mix_FadingChannel(0)) 
		///	{
		///	case MIX_NO_FADING:
		///		printf("Not fading.\n");
		///		break;
		///		case MIX_FADING_OUT:
		///		printf("Fading out.\n");
		///		break;
		///		case MIX_FADING_IN:
		///		printf("Fading in.\n");
		///		break;
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_Paused"/>
		/// <seealso cref="Mix_Playing"/>
		/// <seealso cref="Mix_FadeInChannel"/>
		/// <seealso cref="Mix_FadeInChannelTimed"/>
		/// <seealso cref="Mix_FadeOutChannel"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_FadingChannel(int which);
		#endregion Mix_Fading Mix_FadingChannel(int which)

		#region void Mix_Pause(int channel)
		/// <summary>
		/// Pause a particular channel
		/// </summary>
		/// <remarks>
		/// Pause channel, or all playing channels if -1 is passed in. 
		/// You may still halt a paused channel.
		/// Note: Only channels which are actively playing will be paused.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>void Mix_Pause(int channel)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel to pause on, or -1 for all channels.
		/// </param>
		/// <example>
		/// <code>
		/// // pause all sample playback
		/// Mix_Pause(-1);
		/// </code>
		/// </example>
		/// <seealso cref="Mix_Resume"/>
		/// <seealso cref="Mix_Paused"/>
		/// <seealso cref="Mix_HaltChannel"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void Mix_Pause(int channel);
		#endregion void Mix_Pause(int channel)

		#region void Mix_Resume(int channel)
		/// <summary>
		/// Resume a paused channel
		/// </summary>
		/// <remarks>
		/// Unpause channel, or all playing and 
		/// paused channels if -1 is passed in.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>void Mix_Resume(int channel)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel to resume playing, or -1 for all channels.
		/// </param>
		/// <example>
		/// <code>
		/// // resume playback on all previously active channels
		/// Mix_Resume(-1);
		/// </code>
		/// </example>
		/// <seealso cref="Mix_Pause"/>
		/// <seealso cref="Mix_Paused"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void Mix_Resume(int channel);
		#endregion void Mix_Resume(int channel)

		#region int Mix_Paused(int channel)
		/// <summary>
		/// Get the pause status of a channel
		/// </summary>
		/// <remarks>
		/// Tells you if channel is paused, or not.
		/// Note: Does not check if the channel has been halted 
		/// after it was paused, which may seem a little weird.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_Paused(int channel)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel to test whether it is paused or not.
		/// -1 will tell you how many channels are paused.
		/// </param>
		/// <returns>
		/// Zero if the channel is not paused. Otherwise if you passed in -1,
		///  the number of paused channels is returned. If you passed in a 
		///  specific channel, then 1 is returned if it is paused.
		/// </returns>
		/// <example>
		/// <code>
		/// // check the pause status on all channels
		/// printf("%d channels are paused\n", Mix_Paused(-1));
		/// </code>
		/// </example>
		/// <seealso cref="Mix_Playing"/>
		/// <seealso cref="Mix_Pause"/>
		/// <seealso cref="Mix_Resume"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_Paused(int channel);
		#endregion int Mix_Paused(int channel)

		#region void Mix_PauseMusic()
		/// <summary>
		/// Pause music
		/// </summary>
		/// <remarks>
		/// Pause the music playback. You may halt paused music.
		/// Note: Music can only be paused if it is actively playing.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>void Mix_PauseMusic()
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // pause music playback
		/// Mix_PauseMusic();
		/// </code>
		/// </example>
		/// <seealso cref="Mix_ResumeMusic"/>
		/// <seealso cref="Mix_PausedMusic"/>
		/// <seealso cref="Mix_HaltMusic"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void Mix_PauseMusic();
		#endregion void Mix_PauseMusic()

		#region void Mix_ResumeMusic()
		/// <summary>
		/// Resume paused music
		/// </summary>
		/// <remarks>
		/// Unpause the music. This is safe to use on halted, 
		/// paused, and already playing music.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>void Mix_ResumeMusic() 
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // resume music playback
		/// Mix_ResumeMusic();
		/// </code>
		/// </example>
		/// <seealso cref="Mix_PauseMusic"/>
		/// <seealso cref="Mix_PausedMusic"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void Mix_ResumeMusic();
		#endregion void Mix_ResumeMusic()

		#region void Mix_RewindMusic()
		/// <summary>
		/// Rewind music to beginning
		/// </summary>
		/// <remarks>
		/// Rewind the music to the start. This is safe to use on halted, 
		/// paused, and already playing music. It is not useful to rewind
		///  the music immediately after starting playback, because it 
		///  starts at the beginning by default.
		///  <p>This function only works for these streams: 
		///  MOD, OGG, MP3, Native MIDI.</p>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>void Mix_RewindMusic() 
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // rewind music playback to the start
		/// Mix_RewindMusic();
		/// </code>
		/// </example>
		/// <seealso cref="Mix_PlayMusic"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void Mix_RewindMusic();
		#endregion void Mix_RewindMusic()

		#region int Mix_PausedMusic()
		/// <summary>
		/// Test whether music is paused
		/// </summary>
		/// <remarks>
		/// Tells you if music is paused, or not.
		/// Note: Does not check if the music was been halted 
		/// after it was paused, which may seem a little weird.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_PausedMusic()
		/// </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// Zero if music is not paused. 1 if it is paused. 
		/// </returns>
		/// <example>
		/// <code>
		/// // check the music pause status
		/// printf("music is%s paused\n", Mix_PausedMusic()?"":" not");
		/// </code>
		/// </example>
		/// <seealso cref="Mix_PlayingMusic"/>
		/// <seealso cref="Mix_PauseMusic"/>
		/// <seealso cref="Mix_ResumeMusic"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_PausedMusic();
		#endregion int Mix_PausedMusic()

		#region int Mix_SetMusicPosition(double position)
		/// <summary>
		/// Set position of playback in stream.
		/// </summary>
		/// <remarks>
		/// Set the position of the currently playing music. 
		/// The position takes different meanings for different music sources.
		/// It only works on the music sources listed below.
		/// <code>
		/// MOD 
		/// The double is cast to Uint16 and used for a pattern number in the module.
		/// Passing zero is similar to rewinding the song. 
		/// OGG 
		/// Jumps to position seconds from the beginning of the song. 
		/// MP3 
		/// Jumps to position seconds from the current position in the stream.
		/// </code>
		/// So you may want to call Mix_RewindMusic before this.
		/// Does not go in reverse...negative values do nothing.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_SetMusicPosition(double position)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="position">Position to play from.</param>
		/// <returns>
		/// 0 on success, or -1 if the codec doesn't support this function. 
		/// </returns>
		/// <example>
		/// <code>
		/// // skip one minute into the song, from the start
		/// // this assumes you are playing an MP3
		///		Mix_RewindMusic();
		///		if(Mix_SetMusicPosition(60.0)==-1) 
		///	{
		///		printf("Mix_SetMusicPosition: %s\n", Mix_GetError());
		///	}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_FadeInMusicPos"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_SetMusicPosition(double position);
		#endregion int Mix_SetMusicPosition(double position)

		#region int Mix_Playing(int channel)
		/// <summary>
		/// Get the active playing status of a channel
		/// </summary>
		/// <remarks>
		/// Tells you if channel is playing, or not.
		/// Note: Does not check if the channel has been paused.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_Playing(int channel)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel to test whether it is playing or not.
		/// -1 will tell you how many channels are playing.
		/// </param>
		/// <returns>
		/// Zero if the channel is not playing. Otherwise if you passed in -1, 
		/// the number of channels playing is returned. If you passed in a 
		/// specific channel, then 1 is returned if it is playing.</returns>
		/// <example>
		/// <code>
		/// // check how many channels are playing samples
		/// printf("%d channels are playing\n", Mix_Playing(-1));
		/// </code>
		/// </example>
		/// <seealso cref="Mix_Paused"/>
		/// <seealso cref="Mix_PlayChannel"/>
		/// <seealso cref="Mix_Pause"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_Playing(int channel);
		#endregion int Mix_Playing(int channel)

		#region int Mix_PlayingMusic()
		/// <summary>
		/// Test whether music is playing
		/// </summary>
		/// <remarks>
		/// Tells you if music is actively playing, or not.
		/// Note: Does not check if the channel has been paused.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_PlayingMusic() 
		/// </code>
		/// </p>
		/// </remarks>
		/// <returns></returns>
		/// <example>
		/// <code>
		/// // check if music is playing
		/// printf("music is%s playing.\n", Mix_PlayingMusic()?"":" not");
		/// </code>
		/// </example>
		/// <seealso cref="Mix_PausedMusic"/>
		/// <seealso cref="Mix_FadingMusic"/>
		/// <seealso cref="Mix_PlayMusic"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_PlayingMusic();
		#endregion int Mix_PlayingMusic()

		#region int Mix_SetMusicCMD(string command)
		/// <summary>
		/// Use external program for music playback
		/// </summary>
		/// <remarks>
		/// Setup a command line music player to use to play music. 
		/// Any music playing will be halted. The music file to play 
		/// is set by calling <see cref="Mix_LoadMUS"/>(filename), 
		/// and the filename is appended as the last argument on the 
		/// commandline. This allows you to reuse the music command 
		/// to play multiple files. The command will be sent signals 
		/// SIGTERM to halt, SIGSTOP to pause, and SIGCONT to resume. 
		/// The command program should react correctly to those signals
		///  for it to function properly with SDL_Mixer. 
		///  <see cref="Mix_VolumeMusic"/> has no effect when using an 
		///  external music player, and <see cref="Mix_GetError"/> will 
		///  have an error code set. You should set the music volume in 
		///  the music player's command if the music player supports that.
		///   Looping music works, by calling the command again when the 
		///   previous music player process has ended. Playing music 
		///   through a command uses a forked process to execute the music command.
		/// <p>To use the internal music players set the command to NULL.</p>
		/// <p>NOTE: External music is not mixed by SDL_mixer, 
		/// so no post-processing hooks will be for music.</p>
		/// <p>NOTE: Playing music through an external command may not work 
		/// if the sound driver does not support multiple openings of the 
		/// audio device, since SDL_Mixer already has the audio device 
		/// open for playing samples through channels.</p>
		/// <p>NOTE: Commands are not totally portable, so be careful.</p>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_SetMusicCMD(const char *command)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="command">
		/// System command to play the music. Should be a complete command,
		///  as if typed in to the command line, but it should expect the 
		///  filename to be added as the last argument.
		/// NULL will turn off using an external command for music, 
		/// returning to the internal music playing functionality.
		/// </param>
		/// <returns>
		/// 0 on success, or -1 on any errors, such as running out of memory.
		/// </returns>
		/// <example>
		/// <code>
		/// // use mpg123 to play music
		///		Mix_Music *music=NULL;
		///		if(Mix_SetMusicCMD("mpg123 -q")==-1) 
		///	{
		///		perror("Mix_SetMusicCMD");
		///	} 
		///	else 
		///{
		///	// play some mp3 file
		///	music=Mix_LoadMUS("music.mp3");
		///	if(music) 
		///{
		///	Mix_PlayMusic(music,1);
		///}
		///}
		/// </code>
		/// </example>
		/// <seealso cref="Mix_PlayMusic"/>
		/// <seealso cref="Mix_VolumeMusic"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_SetMusicCMD(string command);
		#endregion int Mix_SetMusicCMD(string command)

		#region int Mix_SetSynchroValue(int value)
		/// <summary>
		/// Synchro value is set by MikMod from modules while playing
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_SetSynchroValue(int value)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <seealso cref="Mix_GetSynchroValue"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_SetSynchroValue(int value);
		#endregion int Mix_SetSynchroValue(int value)

		#region int Mix_GetSynchroValue()
		/// <summary>
		/// Synchro value is set by MikMod from modules while playing
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>int Mix_GetSynchroValue(void)
		/// </code>
		/// </p>
		/// </remarks>
		/// <returns></returns>
		/// <seealso cref="Mix_SetSynchroValue"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int Mix_GetSynchroValue();
		#endregion int Mix_GetSynchroValue()

		#region IntPtr Mix_GetChunk(int channel)
		/// <summary>
		/// Get the sample playing on a channel
		/// </summary>
		/// <remarks>
		/// Get the most recent sample chunk pointer played on channel. 
		/// This pointer may be currently playing, or just the last used.
		/// Note: The actual chunk may have been freed, so this pointer 
		/// may not be valid anymore.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>Mix_Chunk *Mix_GetChunk(int channel)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="channel">
		/// Channel to get the current Mix_Chunk playing.
		/// -1 is not valid, but will not crash the program.
		/// </param>
		/// <returns>
		/// Pointer to the Mix_Chunk. NULL is returned if the channel is not 
		/// allocated, or if the channel has not played any samples yet.
		/// </returns>
		/// <example>
		/// <code>
		/// // get the last chunk used by channel 0
		/// printf("Mix_Chunk* last in use on channel 0 was: %08p\n", Mix_GetChunk(0));
		/// </code>
		/// </example>
		/// <seealso cref="Mix_Chunk"/>
		/// <seealso cref="Mix_Playing"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr Mix_GetChunk(int channel);
		#endregion IntPtr Mix_GetChunk(int channel)

		#region void Mix_CloseAudio()
		/// <summary>
		/// Close sound mixer
		/// </summary>
		/// <remarks>
		/// <p>Shutdown and cleanup the mixer API.</p>
		/// After calling this all audio is stopped, 
		/// the device is closed, and the SDL_mixer functions 
		/// should not be used. You may, of course, 
		/// use Mix_OpenAudio to start 
		/// the functionality again.
		/// <p>Note: This function doesn't do anything until you
		/// have called it the same number of times that you called
		///  <see cref="Mix_OpenAudio"/>. You may use 
		///  <see cref="Mix_QuerySpec"/> to find out how many
		///   times Mix_CloseAudio needs to be called before the device is
		///    actually closed.</p>
		///    <p>Binds to C-function in SDL_mixer.h
		/// <code>void Mix_CloseAudio()
		/// </code>
		/// </p>
		/// </remarks>
		/// <returns></returns>
		/// <example>
		/// <code>
		/// Mix_CloseAudio();
		/// // you could SDL_Quit(); here...or not.
		/// </code>
		/// </example>
		/// <seealso cref="Mix_OpenAudio"/>
		/// <seealso cref="Mix_QuerySpec"/>
		[DllImport(SDL_MIXER_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void Mix_CloseAudio();
		#endregion void Mix_CloseAudio()

		#region void Mix_SetError(string message)
		/// <summary>
		/// Set the current error string
		/// </summary>
		/// <remarks>
		/// This is the same as SDL_SetError, which sets the error string
		/// which may be fetched with Mix_GetError (or SDL_GetError). 
		/// This functions acts like printf, except that it is limited to
		///  SDL_ERRBUFIZE(1024) chars in length. It only accepts the 
		///  following format types: %s, %d, %f, %p. No variations are 
		///  supported, like %.2f would not work. For any more specifics 
		///  read the SDL docs.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>
		/// void Mix_SetError(const char *fmt, ...)
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// int mymixfunc(int i) {
		///		Mix_SetError("mymixfunc is not implemented! %d was passed in.",i);
		///		return(-1);
		///	}
		/// </code></example>
		/// <param name="message"></param>
		/// <seealso cref="Mix_GetError"/>
		public static void Mix_SetError(string message)
		{
			Sdl.SDL_SetError(message);
		}
		#endregion void Mix_SetError(string message)

		#region string Mix_GetError()
		/// <summary>
		/// Get the current error string
		/// </summary>
		/// <remarks>
		/// This is the same as SDL_GetError, which returns the last error set 
		/// as a string which you may use to tell the user what happened when 
		/// an error status has been returned from an SDL_mixer function call.
		/// <p>Binds to C-function in SDL_mixer.h
		/// <code>
		/// char *Mix_GetError() 
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
		///  printf("Oh My Goodness, an error : %s", Mix_GetError());
		///  </code>
		///  </example>
		/// <seealso cref="Mix_SetError"/>
		public static string Mix_GetError()
		{
			return Sdl.SDL_GetError();
		}
		#endregion string Mix_GetError()
		#endregion SdlMixer Methods
	}
}
