#region License
/*
MIT License
Copyright ©2003-2004 Randy Ridge
http://www.randyridge.com/Tao/Default.aspx
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
    /// SdlMixer is a simple multi-channel audio mixer. 
    /// It supports 8 channels of 16 bit stereo audio, plus a 
    /// single channel of music, mixed by the popular MikMod MOD, 
    /// Timidity MIDI and SMPEG MP3 libraries. 
    /// The mixer can currently load Microsoft WAVE files and 
    /// Creative Labs VOC files as audio samples, and can load MIDI 
    /// files via Timidity and the following music formats via 
    /// MikMod: .MOD .S3M .IT .XM. It can load Ogg Vorbis streams 
    /// as music if built with the Ogg Vorbis libraries, and 
    /// finally it can load MP3 music using the SMPEG library. 
    /// The process of mixing MIDI files to wave output is very CPU 
    /// intensive, so if playing regular WAVE files sound great, but
    ///  playing MIDI files sound choppy, try using 8-bit audio, 
    ///  mono audio, or lower frequencies. 
    /// </summary>
    /// <remarks>
    /// This assumes you have gotten SDL_mixer and installed it 
    /// on your system. SDL_mixer has an INSTALL document in the
    ///  source distribution to help you get it compiled and installed. 
    ///	SDL_mixer supports playing music and sound samples from 
    ///	the following formats:
    ///	- WAVE/RIFF (.wav)
    ///	- AIFF (.aiff)
    ///	- VOC (.voc)
    ///	- MOD (.mod .xm .s3m .669 .it .med and more) using included mikmod
    ///	- MIDI (.mid) using timidity or native midi hardware
    ///	- OggVorbis (.ogg) requiring ogg/vorbis libraries on system
    ///	- MP3 (.mp3) requiring SMPEG library on system
    ///	- also any command-line player, which is not mixed by SDL_mixer...
    ///	
    ///	When using SDL_mixer functions you need to avoid the 
    ///	following functions from SDL: 
    ///
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
    ///	Using it may cause problems as well. 
    ///	You may call the following functions freely: 
    ///
    ///	SDL_AudioDriverName 
    ///	This will still work as usual. 
    ///	SDL_GetAudioStatus 
    ///	This will still work, though it will likely return 
    ///	SDL_AUDIO_PLAYING even though SDL_mixer is just playing silence. 
    ///	It is also a BAD idea to call SDL_mixer and SDL audio 
    ///	functions from a callback. Callbacks include Effects 
    ///	functions and other SDL_mixer audio hooks. 
    /// </remarks>
    #endregion Class Documentation
    public sealed class SdlMixer {
        #region Private Constants
        #region String SDL_MIXER_NATIVE_LIBRARY
        //#if WIN32
        /// <summary>
        ///     Specifies Sdl_mixer native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies SDL_mixer.dll for Windows.
        /// </remarks>
        private const String SDL_MIXER_NATIVE_LIBRARY = "SDL_mixer";
        #endregion String SDL_MIXER_NATIVE_LIBRARY
        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.Cdecl" /> for Windows.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = 
            CallingConvention.Cdecl;
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants

        #region Public Constants
        /// <summary>
        /// The default mixer has 8 simultaneous mixing channels
        /// </summary>
        public const Int32 MIX_CHANNELS = 8;
        /// <summary>
        /// 
        /// </summary>
        public const Int32 MIX_DEFAULT_FREQUENCY = 22050;

        /// <summary>
        /// 
        /// </summary>
        public static Int32 MIX_DEFAULT_FORMAT {
            get {
                return Sdl.AUDIO_S16SYS;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public const Int32 MIX_DEFAULT_CHANNELS = 2;

        /// <summary>
        /// Volume of a chunk
        /// </summary>
        public const Int32 MIX_MAX_VOLUME = 128;

        /// <summary>
        /// 
        /// </summary>
        public const Int32 MIX_CHANNEL_POST = -2;

        #endregion Public Constants

        #region Public Enums
        /// <summary>
        /// Specifies an audio format to mix audio in
        /// </summary>
        public enum AudioFormat {
            /// <summary>
            /// Unsigned 8-bit
            /// </summary>
            U8 = 0x0008,
            /// <summary>
            /// Signed 8-bit
            /// </summary>
            S8 = 0x8008,
            /// <summary>
            /// Unsigned 16-bit, little-endian
            /// </summary>
            U16LSB = 0x0010,
            /// <summary>
            /// Signed 16-bit, little-endian
            /// </summary>
            S16LSB = 0x8010,
            /// <summary>
            /// Unsigned 16-bit, big-endian
            /// </summary>
            U16MSB = 0x1010,
            /// <summary>
            /// Signed 16-bit, big-endian
            /// </summary>
            S16MSB = 0x9010,
            /// <summary>
            /// Default, equal to S16LSB
            /// </summary>
            Default = 0x8010
        }

        /// <summary>
        /// The different fading types supported
        /// </summary>
        public enum Mix_Fading {
            /// <summary>
            /// 
            /// </summary>
            MIX_NO_FADING,
            /// <summary>
            /// 
            /// </summary>
            MIX_FADING_OUT,
            /// <summary>
            /// 
            /// </summary>
            MIX_FADING_IN
        }

        /// <summary>
        /// 
        /// </summary>
        public enum Mix_MusicType {
            /// <summary>
            /// 
            /// </summary>
            MUS_NONE,
            /// <summary>
            /// 
            /// </summary>
            MUS_CMD,
            /// <summary>
            /// 
            /// </summary>
            MUS_WAV,
            /// <summary>
            /// 
            /// </summary>
            MUS_MOD,
            /// <summary>
            /// 
            /// </summary>
            MUS_MID,
            /// <summary>
            /// 
            /// </summary>
            MUS_OGG,
            /// <summary>
            /// 
            /// </summary>
            MUS_MP3
        } 
        #endregion Public Enums

        #region Public Structs

        /// <summary>
        /// The internal format for an audio chunk
        /// </summary>
        public struct Mix_Chunk {
            /// <summary>
            /// 
            /// </summary>
            public Int32 allocated;
            /// <summary>
            /// 
            /// </summary>
            public IntPtr abuf;
            /// <summary>
            /// 
            /// </summary>
            public Int32 alen;
            /// <summary>
            /// Per-sample volume, 0-128
            /// </summary>
            public Byte volume;
        } 
        #endregion Public Structs

        #region Public Delegates
        /// <summary>
        /// 
        /// </summary>
        public delegate void MusicFinishedDelegate();

        /// <summary>
        /// 
        /// </summary>
        public delegate void ChannelFinishedDelegate(Int32 channel);
        #endregion Public Delegates

        #region Static SdlMixer()
        // --- Constructors & Destructors ---
        /// <summary>
        ///     Static Sdl constructor. All the functionality of 
        ///     the SDL library is available through this class 
        ///     and its properties.
        /// </summary>
        static SdlMixer() {
            foreach(MethodInfo mi in 
                Type.GetType("Tao.SimpleDirectMediaLayer.SdlMixer").GetMethods()) {
                try {
                    Marshal.Prelink(mi);
                }
                catch {}
            }
        }
        #endregion Static SdlMixer()

        #region SdlMixer()
        /// <summary>
        ///     Prevents instantiation.
        /// </summary>
        private SdlMixer() {
        }
        #endregion SdlMixer()

        /// <summary>
        /// This function gets the version of the dynamically 
        /// linked SDL_mixer library.
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr Mix_Linked_Version();
	
        /// <summary>
        /// Open the mixer with a certain audio format
        /// </summary>
        /// <remarks>
        /// Initialize the mixer API.
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
        ///	          trying to open with different format parameters.
        ///	          
        ///	          format is based on SDL audio support, see SDL_audio.h. Here are the values listed there:
        ///
        ///
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
        ///
        ///
        /// MIX_DEFAULT_FORMAT is the same as AUDIO_S16SYS.
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
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_OpenAudio(
            Int32 frequency, Int16 format, Int32 channels, Int32 chunksize);

        /// <summary>
        /// Dynamically change the number of channels managed by the mixer.
        /// If decreasing the number of channels, the upper channels are
        /// stopped. 
        /// This function returns the new number of allocated channels.
        /// </summary>
        /// <remarks>
        /// A negative number will not do anything, 
        /// it will tell you how many channels are currently allocated. 
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
        /// </param>
        /// <returns>
        /// The number of channels allocated.
        /// Never fails...but a high number of channels
        /// can segfault if you run out of memory. We're talking REALLY high!
        /// </returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_AllocateChannels(Int32 numchans);

        /// <summary>
        /// Find out what the actual audio device parameters are.
        /// This function returns 1 if the audio has been opened, 0 otherwise.
        /// </summary>
        /// <remarks>
        /// Get the actual audio format in use by the opened 
        /// audio device.
        ///  This may or may not match the parameters you
        ///   passed to Mix_OpenAudio.
        /// </remarks>
        /// <param name="channels">
        /// A pointer to an int where the 
        /// number of audio channels will be stored.
        /// 2 will mean stereo, 1 will mean mono.
        /// </param>
        /// <param name="format">
        /// A pointer to a Int16 where the output format actually
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
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_QuerySpec(
            IntPtr frequency, 
            IntPtr format, IntPtr channels);

        /// <summary>
        /// Load a wave file or a music (.mod .s3m .it .xm) file
        /// </summary>
        /// <remarks>
        /// Load src for use as a sample. 
        /// This can load WAVE, AIFF, RIFF, OGG, and VOC formats. 
        /// Using SDL_RWops is not covered here, but they enable 
        /// you to load from almost any source.
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
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr Mix_LoadWAV_RW(IntPtr src, Int32 freesrc);

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
        /// </remarks>
        /// <returns>
        /// a pointer to the sample as a Mix_Chunk. 
        /// NULL is returned on errors.
        /// </returns>
        public static IntPtr Mix_LoadWAV(String file) {
            return Mix_LoadWAV_RW(Sdl.SDL_RWFromFile(file, "rb"), 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr Mix_LoadMUS(string file);

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
        /// </remarks>
        /// <param name="mem">
        /// Memory buffer containing a WAVE file in output format. 
        /// </param>
        /// <returns>
        /// a pointer to the sample as a Mix_Chunk. 
        /// NULL is returned on errors.
        /// </returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY,
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr Mix_QuickLoad_WAV(
            IntPtr mem);

        /// <summary>
        /// Load raw audio data of the mixer format from a memory buffer 
        /// </summary>
        /// <remarks>
        /// Note: This function does very little checking. 
        /// If the format mismatches the output format it 
        /// will not return an error. This is probably a 
        /// dangerous function to use. 
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
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr Mix_QuickLoad_RAW(
            IntPtr mem, Int32 len);

        /// <summary>
        /// Free an audio chunk previously loaded
        /// </summary>
        /// <remarks>
        /// Free the memory used in chunk, and free chunk itself as well. 
        /// Do not use chunk after this without loading a new sample to 
        /// it. Note: It's a bad idea to free a chunk that is still 
        /// being played...
        /// </remarks>
        /// <param name="chunk">
        /// Pointer to the Mix_Chunk to free.
        /// </param>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern void Mix_FreeChunk(IntPtr chunk);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="music"></param>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void Mix_FreeMusic(IntPtr music);

        /// <summary>
        /// Find out the music format of a mixer music, 
        /// or the currently playing music, if 'music' is NULL.
        /// </summary>
        /// <param name="music"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Mix_MusicType Mix_GetMusicType(IntPtr music);

        //Set a function that is called after all mixing is performed.
        //This can be used to provide real-time visual display of 
        //the audio stream
        //or add a custom mixer filter for the stream data.	
        //[DllImport(SDL_MIXER_NATIVE_LIBRARY, 				
        //CallingConvention=CALLING_CONVENTION),
        //SuppressUnmanagedCodeSecurity]
        //public static extern void Mix_SetPostMix(void (*mix_func)
        //(IntPtr udata, IntPtr stream, Int32 len), IntPtr arg);

        /* Add your own music player or additional mixer function.
   If 'mix_func' is NULL, the default music player is re-enabled.
 */
        //		extern DECLSPEC void SDLCALL Mix_HookMusic(void (*mix_func)
        //		(void *udata, Uint8 *stream, int len), void *arg);

        //		extern DECLSPEC void SDLCALL Mix_HookMusicFinished(
        //		void (*music_finished)(void));

        /// <summary>
        /// Add your own callback when the music has finished playing.
        /// This callback is only called if the music finishes naturally.
        /// </summary>
        /// <param name="music_finished"></param>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void Mix_HookMusicFinished(
            MusicFinishedDelegate music_finished);

        /// <summary>
        /// Get a pointer to the user data for the current music hook
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr Mix_GetMusicHookData();

        /// <summary>
        /// Add your own callback when a channel has finished playing. NULL
        ///  to disable callback. The callback may be called from the 
        ///  mixer's audio 
        ///  callback or it could be called as a result of 
        ///  Mix_HaltChannel(), etc.
        ///  do not call SDL_LockAudio() from this callback; 
        ///  you will either be 
        ///  inside the audio callback, or SDL_mixer will 
        ///  explicitly lock the audio
        ///  before calling your callback.
        /// </summary>
        /// <param name="channel_finished"></param>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void Mix_ChannelFinished(
            ChannelFinishedDelegate channel_finished);

        /// <summary>
        /// Set the panning of a channel. 
        /// The left and right channels are specified
        ///  as integers between 0 and 255, quietest to loudest, 
        ///  respectively.
        ///
        /// Technically, this is just individual volume control 
        /// for a sample with
        ///  two (stereo) channels, so it can be used for more 
        ///  than just panning.
        ///  If you want real panning, call it like this:
        ///
        ///   Mix_SetPanning(channel, left, 255 - left);
        ///
        /// ...which isn't so hard.
        ///
        /// Setting (channel) to MIX_CHANNEL_POST registers this 
        /// as a posteffect, and
        ///  the panning will be done to the final mixed stream 
        ///  before passing it on
        ///  to the audio device.
        ///
        /// This uses the Mix_RegisterEffect() API internally, 
        /// and returns without
        ///  registering the effect function if the audio device 
        ///  is not configured
        ///  for stereo output. Setting both (left) and (right) 
        ///  to 255 causes this
        ///  effect to be unregistered, since that is the data's 
        ///  normal state.
        ///
        /// returns zero if error (no such channel or 
        /// Mix_RegisterEffect() fails),
        ///  nonzero if panning effect enabled. 
        ///  Note that an audio device in mono
        ///  mode is a no-op, but this call will return 
        ///  successful in that case.
        ///  Error messages can be retrieved from Mix_GetError().
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_SetPanning(
            Int32 channel, Byte left, Byte right);

        /// <summary>
        /// Set the position of a channel. 
        /// (angle) is an integer from 0 to 360, that
        ///  specifies the location of the sound in relation 
        ///  to the listener. (angle)
        ///  will be reduced as neccesary 
        ///  (540 becomes 180 degrees, -100 becomes 260).
        ///  Angle 0 is due north, and rotates 
        ///  clockwise as the value increases.
        ///  For efficiency, the precision of this 
        ///  effect may be limited (angles 1
        ///  through 7 might all produce the same effect, 
        ///  8 through 15 are equal, etc).
        ///  (distance) is an integer between 0 and 255 
        ///  that specifies the space
        ///  between the sound and the listener. 
        ///  The larger the number, the further
        ///  away the sound is. Using 255 does not guarantee 
        ///  that the channel will be
        ///  culled from the mixing process or be completely silent. 
        ///  For efficiency,
        ///  the precision of this effect may be limited 
        ///  (distance 0 through 5 might
        ///  all produce the same effect, 6 through 10 are equal, etc).
        ///   Setting (angle)
        ///  and (distance) to 0 unregisters this effect, since the data
        ///   would be
        ///  unchanged.
        ///
        /// If you need more precise positional audio, 
        /// consider using OpenAL for
        ///  spatialized effects instead of SDL_mixer. 
        ///  This is only meant to be a
        ///  basic effect for simple "3D" games.
        ///
        /// If the audio device is configured for mono output, 
        /// then you won't get
        ///  any effectiveness from the angle; however, 
        ///  distance attenuation on the
        ///  channel will still occur. While this effect 
        ///  will function with stereo
        ///  voices, it makes more sense to use voices with 
        ///  only one channel of sound,
        ///  so when they are mixed through this effect, 
        ///  the positioning will sound
        ///  correct. You can convert them to mono through 
        ///  SDL before giving them to
        ///  the mixer in the first place if you like.
        ///
        /// Setting (channel) to MIX_CHANNEL_POST registers this 
        /// as a posteffect, and
        ///  the positioning will be done to the final mixed stream
        ///   before passing it
        ///  on to the audio device.
        ///
        /// This is a convenience wrapper over Mix_SetDistance()
        ///  and Mix_SetPanning().
        ///
        /// returns zero if error (no such channel or 
        /// Mix_RegisterEffect() fails),
        ///  nonzero if position effect is enabled.
        ///  Error messages can be retrieved from Mix_GetError().
        /// 
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="angle"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_SetPosition(
            Int32 channel, Int16 angle, Byte distance);

        /// <summary>
        /// Set the "distance" of a channel. (distance) is an integer 
        /// from 0 to 255
        ///  that specifies the location of the sound in relation to 
        ///  the listener.
        ///  Distance 0 is overlapping the listener, and 255 is as far 
        ///  away as possible
        ///  A distance of 255 does not guarantee silence; in such a case, 
        ///  you might
        ///  want to try changing the chunk's volume, or just cull the 
        ///  sample from the
        ///  mixing process with Mix_HaltChannel().
        /// For efficiency, the precision of this effect may be 
        /// limited (distances 1
        ///  through 7 might all produce the same effect, 8 through 
        ///  15 are equal, etc).
        ///  (distance) is an integer between 0 and 255 that specifies 
        ///  the space
        ///  between the sound and the listener. The larger the number, 
        ///  the further
        ///  away the sound is.
        /// Setting (distance) to 0 unregisters this effect, since the 
        /// data would be
        ///  unchanged.
        /// If you need more precise positional audio, consider using 
        /// OpenAL for
        ///  spatialized effects instead of SDL_mixer. This is only 
        ///  meant to be a
        ///  basic effect for simple "3D" games.
        ///
        /// Setting (channel) to MIX_CHANNEL_POST registers this as 
        /// a posteffect, and
        ///  the distance attenuation will be done to the final mixed 
        ///  stream before
        ///  passing it on to the audio device.
        ///
        /// This uses the Mix_RegisterEffect() API internally.
        ///
        /// returns zero if error (no such channel or 
        /// Mix_RegisterEffect() fails),
        ///  nonzero if position effect is enabled.
        ///  Error messages can be retrieved from Mix_GetError().
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_SetDistance(
            Int32 channel, Byte distance);

        /// <summary>
        /// Causes a channel to reverse its stereo. 
        /// This is handy if the user has his
        ///  speakers hooked up backwards, or you would like to 
        ///  have a minor bit of
        ///  psychedelia in your sound code.  :)  
        ///  Calling this function with (flip)
        ///  set to non-zero reverses the chunks's usual channels. 
        ///  If (flip) is zero,
        ///  the effect is unregistered.
        ///
        /// This uses the Mix_RegisterEffect() API internally, 
        /// and thus is probably
        ///  more CPU intensive than having the user just plug in 
        ///  his speakers
        ///  correctly. Mix_SetReverseStereo() returns without registering 
        ///  the effect
        ///  function if the audio device is not configured for stereo
        ///   output.
        ///
        /// If you specify MIX_CHANNEL_POST for (channel), 
        /// then this the effect is used
        ///  on the final mixed stream before sending it on to 
        ///  the audio device (a
        ///  posteffect).
        ///
        /// returns zero if error (no such channel or 
        /// Mix_RegisterEffect() fails),
        ///  nonzero if reversing effect is enabled. 
        ///  Note that an audio device in mono
        ///  mode is a no-op, but this call will return 
        ///  successful in that case.
        ///  Error messages can be retrieved from Mix_GetError().
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="flip"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_SetReverseStereo(
            Int32 channel, Int32 flip);

        /// <summary>
        /// Reserve the first channels (0 -> n-1) for the application, 
        /// i.e. don't allocate
        /// them dynamically to the next sample if requested with 
        /// a -1 value below.
        /// </summary>
        /// <param name="num"></param>
        /// <returns>Returns the number of reserved channels.</returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_ReserveChannels(Int32 num);

        /// <summary>
        /// Attach a tag to a channel. A tag can be assigned to several mixer
        /// channels, to form groups of channels.
        /// If 'tag' is -1, the tag is removed (actually -1 is the tag used to
        /// represent the group of all the channels).
        /// </summary>
        /// <param name="which"></param>
        /// <param name="tag"></param>
        /// <returns>Returns true if everything was OK.</returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_GroupChannel(int which, int tag);

        /// <summary>
        /// Assign several consecutive channels to a group
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_GroupChannels(
            int from, int to, int tag);

        /// <summary>
        /// Finds the first available channel in a group of channels,
        /// returning -1 if none are available.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_GroupAvailable(int tag);

        /// <summary>
        /// Returns the number of channels in a group. This is also a subtle
        /// way to get the total number of channels when 'tag' is -1
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_GroupCount(int tag);

        /// <summary>
        /// Finds the "oldest" sample playing in a group of channels
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_GroupOldest(int tag);

        /// <summary>
        /// Finds the "most recent" (i.e. last) 
        /// sample playing in a group of channels
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_GroupNewer(int tag);

        /// <summary>
        /// Play an audio chunk on a specific channel.
        /// If the specified channel is -1, play on the first free channel.
        /// If 'loops' is greater than zero, loop the sound that many times.
        /// If 'loops' is -1, loop inifinitely (~65000 times).
        /// </summary>
        /// <remarks>
        /// If the sample is long enough and has enough 
        /// loops then the sample will stop after ticks milliseconds. 
        /// Otherwise this function is the same as 4.3.3 Mix_PlayChannel.
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
        /// the sound is played at most 'ticks' milliseconds.
        /// Millisecond limit to play sample, at most.
        /// If not enough loops or the sample chunk is not long enough,
        /// then the sample may stop before this timeout occurs.
        /// -1 means play forever.
        /// </param>
        /// <returns>
        /// Returns which channel was used to play the sound.
        /// the channel the sample is played on. 
        /// On any errors, -1 is returned.
        /// </returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_PlayChannelTimed(
            Int32 channel, IntPtr chunk, Int32 loops, Int32 ticks);

        /// <summary>
        /// Play an audio chunk on a specific channel.
        /// If the specified channel is -1, play on the first free channel.
        /// If 'loops' is greater than zero, loop the sound that many times.
        /// If 'loops' is -1, loop inifinitely (~65000 times).
        /// </summary>
        /// <remarks>
        /// Play chunk on channel, or if channel is -1, 
        /// pick the first free unreserved channel. 
        /// The sample will play for loops+1 number of times, 
        /// unless stopped by halt, or fade out, or setting a 
        /// new expiration time of less time than it would have 
        /// originally taken to play the loops, or closing the mixer.
        /// Note: this just calls Mix_PlayChannelTimed() 
        /// with ticks set to -1. 
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
        public static Int32 Mix_PlayChannel(
            Int32 channel, IntPtr chunk, Int32 loops) {
            return Mix_PlayChannelTimed(channel, chunk, loops, -1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="music"></param>
        /// <param name="loops"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_PlayMusic(IntPtr music, Int32 loops);

        /// <summary>
        /// Fade in music or a channel over "ms" milliseconds, 
        /// same semantics as the "Play" functions
        /// </summary>
        /// <param name="music"></param>
        /// <param name="loops"></param>
        /// <param name="ms"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_FadeInMusic(
            IntPtr music, Int32 loops, Int32 ms);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="music"></param>
        /// <param name="loops"></param>
        /// <param name="ms"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_FadeInMusicPos(
            IntPtr music, Int32 loops, Int32 ms, double position);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="chunk"></param>
        /// <param name="loops"></param>
        /// <param name="ms"></param>
        /// <param name="ticks"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_FadeInChannelTimed(
            Int32 channel, IntPtr chunk, Int32 loops, Int32 ms, Int32 ticks);

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
        /// Note: this just calls Mix_FadeInChannelTimed() 
        /// with ticks set to -1.
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
        public static Int32 Mix_FadeInChannel(
            Int32 channel, IntPtr chunk, Int32 loops, Int32 ms) {
            return Mix_FadeInChannelTimed(channel, chunk, loops, ms, -1);
        }

        /// <summary>
        /// Set the volume in the range of 0-128 of a specific 
        /// channel or chunk.
        /// If the specified channel is -1, set volume for all channels.
        /// Returns the original volume.
        /// If the specified volume is -1, just return the current volume.
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
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_Volume(Int32 channel, Int32 volume);

        /// <summary>
        /// Set mix volume
        /// </summary>
        /// <remarks>
        /// Set chunk->volume to volume.
        /// The volume setting will take effect 
        /// when the chunk is used on a channel, 
        /// being mixed into the output.
        /// </remarks>
        /// <param name="chunk">
        /// Pointer to the Mix_Chunk to set the volume in.
        /// </param>
        /// <param name="volume">
        /// The volume to use from 0 to MIX_MAX_VOLUME(128).
        /// If greater than MIX_MAX_VOLUME,
        /// then it will be set to MIX_MAX_VOLUME.
        /// If less than 0 then chunk->volume will not be set.
        /// </param>
        /// <returns>
        /// previous chunk->volume setting. 
        /// if you passed a negative value for volume then this 
        /// volume is still the current volume for the chunk.
        /// </returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_VolumeChunk(
            IntPtr chunk, Int32 volume);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="volume"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_VolumeMusic(Int32 volume);

        /// <summary>
        /// Halt playing of a particular channel
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_HaltChannel(Int32 channel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_HaltGroup(Int32 tag);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_HaltMusic();

        /// <summary>
        /// Change the expiration delay for a particular channel.
        /// The sample will stop playing after the 'ticks' 
        /// milliseconds have elapsed,
        /// or remove the expiration if 'ticks' is -1
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="ticks"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_ExpireChannel(
            Int32 channel, Int32 ticks);

        /// <summary>
        /// Halt a channel, fading it out progressively till it's silent
        /// The ms parameter indicates the number of milliseconds the fading
        /// will take.
        /// </summary>
        /// <param name="which"></param>
        /// <param name="ms"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_FadeOutChannel(Int32 which, Int32 ms);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="ms"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_FadeOutGroup(Int32 tag, Int32 ms);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_FadeOutMusic(Int32 ms);

        /// <summary>
        /// Query the fading status of a channel
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Mix_Fading Mix_FadingMusic();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="which"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Mix_Fading Mix_FadingChannel(Int32 which);

        /// <summary>
        /// Pause a particular channel
        /// </summary>
        /// <param name="channel"></param>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern void Mix_Pause(Int32 channel);

        /// <summary>
        /// Resume a particular channel
        /// </summary>
        /// <param name="channel"></param>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern void Mix_Resume(Int32 channel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_Paused(Int32 channel);

        /// <summary>
        /// Pause the music stream
        /// </summary>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern void Mix_PauseMusic();

        /// <summary>
        /// Resume the music stream
        /// </summary>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern void Mix_ResumeMusic();

        /// <summary>
        /// 
        /// </summary>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern void Mix_RewindMusic();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_PausedMusic();

        /// <summary>
        /// Set the current position in the music stream.
        /// This returns 0 if successful, or -1 if it failed or 
        /// isn't implemented.
        /// This function is only implemented for MOD music formats 
        /// (set pattern order number) and for OGG music 
        /// (set position in seconds), at the moment.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION),
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_SetMusicPosition(double position);

        /// <summary>
        /// Check the status of a specific channel.
        /// If the specified channel is -1, check all channels.
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_Playing(Int32 channel);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_PlayingMusic();

        /// <summary>
        /// Stop music and set external music playback command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_SetMusicCMD(String command);

        /// <summary>
        /// Synchro value is set by MikMod from modules while playing
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_SetSynchroValue(Int32 value);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern Int32 Mix_GetSynchroValue();

        /// <summary>
        /// Get the Mix_Chunk currently associated with a mixer channel
        /// Returns NULL if it's an invalid channel, 
        /// or there's no chunk associated.
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern IntPtr Mix_GetChunk(Int32 channel);

        /// <summary>
        /// Close the mixer, halting all playing audio
        /// </summary>
        /// <remarks>
        /// Shutdown and cleanup the mixer API.
        /// After calling this all audio is stopped, 
        /// the device is closed, and the SDL_mixer functions 
        /// should not be used. You may, of course, 
        /// use Mix_OpenAudio to start 
        /// the functionality again.
        /// Note: This function doesn't do anything until you
        /// have called it the same number of times that you called
        ///  Mix_OpenAudio. You may use Mix_QuerySpec to find out how many
        ///   times Mix_CloseAudio needs to be called before the device is
        ///    actually closed.
        /// </remarks>
        /// <returns></returns>
        [DllImport(SDL_MIXER_NATIVE_LIBRARY, 
             CallingConvention=CALLING_CONVENTION), 
        SuppressUnmanagedCodeSecurity]
        public static extern void Mix_CloseAudio();
    }
}
