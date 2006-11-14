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
	/// SMPEG bindings for .NET. 
	/// <p></p>
	/// </summary>
	/// <remarks>
	/// </remarks>
	#endregion Class Documentation
	[SuppressUnmanagedCodeSecurityAttribute()]
	public static class Smpeg 
	{
		#region Private Constants
		#region string SMPEG_NATIVE_LIBRARY
		/// <summary>
		///     Specifies Smpeg's native library archive.
		/// </summary>
		/// <remarks>
		///     Specifies smpeg.dll everywhere; will be mapped via .config for mono.
		/// </remarks>
		private const string SMPEG_NATIVE_LIBRARY = "smpeg.dll";
		#endregion string SMPEG_NATIVE_LIBRARY

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
		#region MPEGfilter.h
		/// <summary>
		/// Filter info flag
		/// </summary>
		public const int SMPEG_FILTER_INFO_MB_ERROR = 1;
		/// <summary>
		/// Filter info flag
		/// </summary>
		public const int SMPEG_FILTER_INFO_PIXEL_ERROR = 2;
		#endregion MPEGfilter.h

		#region smpeg.h
		/// <summary>
		/// Major Version
		/// </summary>
		public const int SMPEG_MAJOR_VERSION = 0;
		/// <summary>
		/// Minor Version
		/// </summary>
		public const int SMPEG_MINOR_VERSION = 4;
		/// <summary>
		/// Patch Version
		/// </summary>
		public const int SMPEG_PATCHLEVEL = 5;
		/// <summary>
		/// MPEG status code. 
		/// </summary>
		/// <remarks>
		/// Part of SMPEGstatus C-style enum
		/// </remarks>
		[CLSCompliant(false)]
		public const int SMPEG_ERROR = -1;
		/// <summary>
		/// MPEG status code. 
		/// </summary>
		/// <remarks>
		/// Part of SMPEGstatus C-style enum
		/// </remarks>
		public const int SMPEG_STOPPED = 0;
		/// <summary>
		/// MPEG status code. 
		/// </summary>
		/// <remarks>
		/// Part of SMPEGstatus C-style enum
		/// </remarks>
		public const int SMPEG_PLAYING = 1;
		#endregion smpeg.h
		#endregion Public Constants

		#region Public Structs
		#region MPEGfilter.h
		#region SMPEG_FilterInfo
		/// <summary>
		/// Filter info from SMPEG
		/// </summary>
		/// <remarks>
		/// <p>Struct in MPEGfilter.h
		/// <code>
		/// typedef struct SMPEG_FilterInfo {
		///		Uint16* yuv_mb_square_error;
		///		Uint16* yuv_pixel_square_error;
		///	}
		/// </code>
		/// </p>
		/// </remarks>
		public struct SMPEG_FilterInfo
		{
			/// <summary>
			/// 
			/// </summary>
			public IntPtr yuv_mb_square_error;
			/// <summary>
			/// 
			/// </summary>
			public IntPtr yuv_pixel_square_error;
		}
		#endregion SMPEG_FilterInfo

		#region SMPEG_Filter
		/// <summary>
		/// The filter definition itself
		/// </summary>
		/// <remarks>
		/// <p>Struct in MPEGfilter.h
		/// <code>
		/// typedef struct SMPEG_Filter {
		///		Uint32 flags;
		///		void * data;
		///		SMPEG_FilterCallback callback;
		///		SMPEG_FilterDestroy destroy;
		///	}
		/// </code></p></remarks>
		[CLSCompliant(false)]
			public struct SMPEG_Filter
		{
			/// <summary>
			/// 
			/// </summary>
			public int flags;
			/// <summary>
			/// 
			/// </summary>
			public object data;
			/// <summary>
			/// 
			/// </summary>
			public SMPEG_FilterCallback callback;
			/// <summary>
			/// 
			/// </summary>
			public SMPEG_FilterDestroy destroy;
		}
		#endregion SMPEG_Filter
		#endregion MPEGfilter.h

		#region smpeg.h
		#region SMPEG_version
		/// <summary>
		/// Structure to hold version number of the SMPEG library
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
		public struct SMPEG_version 
		{
			/// <summary>
			/// Major version
			/// </summary>
			public byte major;
			/// <summary>
			/// Minor version
			/// </summary>
			public byte minor;
			/// <summary>
			/// Patch version
			/// </summary>
			public byte patch;
			/// <summary>
			/// 
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				return (this.major + "." + this.minor + "." + this.patch);
			}
		}
		#endregion SMPEG_version

		#region SMPEG_Info
		/// <summary>
		/// Used to get information about the SMPEG object
		/// </summary>
		/// <remarks>
		/// <p>
		/// <code>
		/// typedef struct _SMPEG_Info {
		///		int has_audio;
		///		int has_video;
		///		int width;
		///		int height;
		///		int current_frame;
		///		double current_fps;
		///		char audio_string[80];
		///		int  audio_current_frame;
		///		Uint32 current_offset;
		///		Uint32 total_size;
		///		double current_time;
		///		double total_time;
		///	} SMPEG_Info;
		/// </code></p></remarks>
		public struct SMPEG_Info
		{
			/// <summary>
			/// 
			/// </summary>
			public int has_audio;
			/// <summary>
			/// 
			/// </summary>
			public int has_video;
			/// <summary>
			/// Width of movie file
			/// </summary>
			public int width;
			/// <summary>
			/// Height of movie file
			/// </summary>
			public int height;
			/// <summary>
			/// 
			/// </summary>
			public int current_frame;
			/// <summary>
			/// 
			/// </summary>
			public double current_fps;
			/// <summary>
			/// 
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=80)]
			public string audio_string;
			/// <summary>
			/// 
			/// </summary>
			public int audio_current_frame;
			/// <summary>
			/// 
			/// </summary>
			public int current_offset;
			/// <summary>
			/// Movie file size in bytes
			/// </summary>
			public int total_size;
			/// <summary>
			/// 
			/// </summary>
			public double current_time;
			/// <summary>
			/// Length of movie file in seconds.
			/// </summary>
			public double total_time;
		}
		#endregion SMPEG_Info
		#endregion smpeg.h
		#endregion Public Structs

		#region Public Delegates
		#region MPEGfilter.h
		#region void SMPEG_FilterCallback(...)
		/// <summary>
		/// Callback function for the filter
		/// </summary>
		/// <remarks>
		/// <p>
		/// <code>
		/// typedef void (* SMPEG_FilterCallback)( SDL_Overlay * dest, SDL_Overlay * source, SDL_Rect * region, SMPEG_FilterInfo * filter_info, void * data );
		/// </code></p></remarks>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SMPEG_FilterCallback(IntPtr dest, IntPtr source, out Sdl.SDL_Rect region, IntPtr filter_info, object data);
		#endregion void SMPEG_FilterCallback(...)

		#region void SMPEG_FilterDestroy(IntPtr filter)
		/// <summary>
		/// Callback function for the filter
		/// </summary>
		/// <remarks>
		/// <p>Binds to a callback function in MPEGfilter.h
		/// <code>
		/// typedef void (* SMPEG_FilterDestroy)( struct SMPEG_Filter * filter )
		/// </code></p></remarks>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SMPEG_FilterDestroy(IntPtr filter);
		#endregion void SMPEG_FilterDestroy(IntPtr filter)
		#endregion MPEGfilter.h

		#region smpeg.h
		#region void SMPEG_DisplayCallback(...)
		/// <summary>
		/// Matches the declaration of SDL_UpdateRect()
		/// </summary>
		/// <remarks>
		/// <p>Binds to a callback function in smpeg.h
		/// <code>
		/// typedef void(*SMPEG_DisplayCallback)(SDL_Surface* dst, int x, int y, unsigned int w, unsigned int h);
		/// </code>
		/// </p>
		/// </remarks>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SMPEG_DisplayCallback(
			IntPtr dst, int x, int y, int w, int h);
		#endregion void SMPEG_DisplayCallback(...)
		#endregion smpeg.h
		#endregion Public Delegates
		
		#region Smpeg Methods
		#region MPEGfilter.h
		#region IntPtr SMPEGfilter_null()
		/// <summary>
		/// The null filter (default). 
		/// It simply copies the source rectangle to the video overlay.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in MPEGfilter.h
		/// <code>
		/// SMPEG_Filter * SMPEGfilter_null(void)
		/// </code></p></remarks>
		/// <returns>IntPtr to <see cref="SMPEG_Filter"/></returns>
		/// <seealso cref="SMPEGfilter_bilinear"/>
		/// <seealso cref="SMPEGfilter_deblocking"/>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SMPEGfilter_null();
		#endregion IntPtr SMPEGfilter_null()

		#region IntPtr SMPEGfilter_bilinear()
		/// <summary>
		/// The bilinear filter. 
		/// A basic low-pass filter that will produce a smoother image.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in MPEGfilter.h
		/// <code>
		/// SMPEG_Filter * SMPEGfilter_bilinear(void)
		/// </code></p></remarks>
		/// <returns>IntPtr to <see cref="SMPEG_Filter"/></returns>
		/// <seealso cref="SMPEGfilter_null"/>
		/// <seealso cref="SMPEGfilter_deblocking"/>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SMPEGfilter_bilinear();
		#endregion IntPtr SMPEGfilter_bilinear()

		#region IntPtr SMPEGfilter_deblocking()
		/// <summary>
		/// The deblocking filter. 
		/// It filters block borders and non-intra coded blocks 
		/// to reduce blockiness
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in MPEGfilter.h
		/// <code>
		/// SMPEG_Filter * SMPEGfilter_deblocking(void)
		/// </code></p></remarks>
		/// <returns>IntPtr to <see cref="SMPEG_Filter"/></returns>
		/// <seealso cref="SMPEGfilter_null"/>
		/// <seealso cref="SMPEGfilter_bilinear"/>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SMPEGfilter_deblocking();
		#endregion IntPtr SMPEGfilter_deblocking()
		#endregion MPEGfilter.h

		#region smpeg.h
		#region SDL_version SMPEG_VERSION() 
		/// <summary>
		/// This method can be used to fill a version structure with the compile-time
		/// version of the SMPEG library.
		/// </summary>
		/// <returns>
		///     This function returns a <see cref="Smpeg.SMPEG_version"/> struct containing the
		///     compiled version number
		/// </returns>
		/// <remarks>
		///     <p>
		///     Binds to C-function call in smpeg.h:
		///     <code>#define SMPEG_VERSION(X)
		/// {
		/// (X)->major = SMPEG_MAJOR_VERSION;
		/// (X)->minor = SMPEG_MINOR_VERSION;
		/// (X)->patch = SMPEG_PATCHLEVEL;
		/// }</code>
		///     </p>
		/// </remarks>
		[CLSCompliant(false)]
		public static Smpeg.SMPEG_version SMPEG_VERSION() 
		{ 
			Smpeg.SMPEG_version smpegVersion = new Smpeg.SMPEG_version();
			smpegVersion.major = SMPEG_MAJOR_VERSION;
			smpegVersion.minor = SMPEG_MINOR_VERSION;
			smpegVersion.patch = SMPEG_PATCHLEVEL;
			return smpegVersion;
		} 
		#endregion SDL_version SMPEG_VERSION() 

		#region IntPtr SMPEG_new(string file, out SMPEG_Info info, int sdl_audio)
		/// <summary>
		/// Create a new SMPEG object from an MPEG file.
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>SMPEG* SMPEG_new(const char *file, SMPEG_Info* info, int sdl_audio);
		/// </code></p></remarks>
		/// <param name="file"></param>
		/// <param name="info">On return, if 'info' is not NULL, 
		/// it will be filled with information about the MPEG object.</param>
		/// <param name="sdl_audio">
		/// The sdl_audio parameter indicates if SMPEG should 
		/// initialize the SDL audio
		/// subsystem. If not, you will have to use the 
		/// SMPEG_playaudio() function below
		/// to extract the decoded data. Never set this parameter to false (i.e. 0). 
		/// This will cause the video playback to run very slowly. 
		/// To disable audio, 
		/// use the <see cref="SMPEG_enableaudio"/> function.</param>
		/// <returns>This function returns a new SMPEG object.  
		/// Use SMPEG_error() to find out whether or not there 
		/// was a problem building the MPEG stream.</returns>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SMPEG_new(string file, out SMPEG_Info info, int sdl_audio);
		#endregion IntPtr SMPEG_new(string file, out SMPEG_Info info, int sdl_audio)

		#region IntPtr SMPEG_new_desrc(int file, out SMPEG_Info info, int sdl_audio)
		/// <summary>
		/// Create a new SMPEG object from a file descriptor.
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>SMPEG* SMPEG_new_descr(int file, SMPEG_Info* info, int sdl_audio)
		/// </code></p></remarks>
		/// <param name="file"></param>
		/// <param name="info">On return, if 'info' is not NULL, 
		/// it will be filled with information about the MPEG object.</param>
		/// <param name="sdl_audio">
		/// The sdl_audio parameter indicates if SMPEG should 
		/// initialize the SDL audio
		/// subsystem. If not, you will have to use the 
		/// SMPEG_playaudio() function below
		/// to extract the decoded data.</param>
		/// <returns>This function returns a new SMPEG object.  
		/// Use SMPEG_error() to find out whether or not there 
		/// was a problem building the MPEG stream.</returns>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SMPEG_new_descr(int file, out SMPEG_Info info, int sdl_audio);
		#endregion IntPtr SMPEG_new_descr(int file, out SMPEG_Info info, int sdl_audio)

		#region IntPtr SMPEG_new_data(object data, int size, out SMPEG_Info info, int sdl_audio)
		/// <summary>
		/// Create a new SMPEG object from for a raw chunk of data.
		/// </summary>
		/// <remarks>
		/// SMPEG makes a copy of the data, so the application is free to 
		/// delete after a successful call to this function.
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// SMPEG* SMPEG_new_data(void *data, int size, SMPEG_Info* info, int sdl_audio)
		/// </code></p></remarks>
		/// <param name="data">Raw chunck of data</param>
		/// <param name="size">Size of chunk</param>
		/// <param name="info">On return, if 'info' is not NULL, 
		/// it will be filled with information about the MPEG object.</param>
		/// <param name="sdl_audio">
		/// The sdl_audio parameter indicates if SMPEG should 
		/// initialize the SDL audio
		/// subsystem. If not, you will have to use the 
		/// SMPEG_playaudio() function below
		/// to extract the decoded data.</param>
		/// <returns>This function returns a new SMPEG object.  
		/// Use SMPEG_error() to find out whether or not there 
		/// was a problem building the MPEG stream.</returns>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SMPEG_new_data(
			object data, int size, out SMPEG_Info info, int sdl_audio);
		#endregion IntPtr SMPEG_new_data(object data, int size, out SMPEG_Info info, int sdl_audio)

		#region IntPtr SMPEG_new_rwops(IntPtr src, out SMPEG_Info info, int sdl_audio);
		/// <summary>
		/// Create a new SMPEG object from a generic SDL_RWops structure.
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// SMPEG* SMPEG_new_rwops(SDL_RWops *src, SMPEG_Info* info, int sdl_audio);
		/// </code></p></remarks>
		/// <param name="src"></param>
		/// <param name="info">On return, if 'info' is not NULL, 
		/// it will be filled with information about the MPEG object.</param>
		/// <param name="sdl_audio">
		/// The sdl_audio parameter indicates if SMPEG should 
		/// initialize the SDL audio
		/// subsystem. If not, you will have to use the 
		/// SMPEG_playaudio() function below
		/// to extract the decoded data.</param>
		/// <returns>This function returns a new SMPEG object.  
		/// Use SMPEG_error() to find out whether or not there 
		/// was a problem building the MPEG stream.</returns>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SMPEG_new_rwops(IntPtr src, out SMPEG_Info info, int sdl_audio);
		#endregion IntPtr SMPEG_new_rwops(IntPtr src, out SMPEG_Info info, int sdl_audio);

		#region void SMPEG_getinfo(IntPtr mpeg, out SMPEG_Info info)
		/// <summary>
		/// Get current information about an SMPEG object
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_getinfo( SMPEG* mpeg, SMPEG_Info* info )
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="info">On return, if 'info' is not NULL, 
		/// it will be filled with information about the MPEG object.</param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_getinfo(IntPtr mpeg, out SMPEG_Info info);
		#endregion void SMPEG_getinfo(IntPtr mpeg, out SMPEG_Info info)

		#region void SMPEG_enableaudio(IntPtr mpeg, int enable)
		/// <summary>
		/// Enable or disable audio playback in MPEG stream
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_enableaudio( SMPEG* mpeg, int enable )
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="enable"></param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_enableaudio(IntPtr mpeg, int enable);
		#endregion void SMPEG_enableaudio(IntPtr mpeg, int enable)

		#region void SMPEG_enablevideo(IntPtr mpeg, int enable)
		/// <summary>
		/// Enable or disable video playback in MPEG stream
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_enablevideo( SMPEG* mpeg, int enable )
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="enable"></param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_enablevideo(IntPtr mpeg, int enable);
		#endregion void SMPEG_enablevideo(IntPtr mpeg, int enable)

		#region void SMPEG_delete( IntPtr mpeg )
		/// <summary>
		/// Delete an SMPEG object.
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_delete( SMPEG* mpeg )
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_delete( IntPtr mpeg );
		#endregion void SMPEG_delete( IntPtr mpeg )

		#region int SMPEG_status( IntPtr mpeg )
		/// <summary>
		/// Get the current status of an SMPEG object
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// SMPEGstatus SMPEG_status( SMPEG* mpeg )
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <returns>
		/// SMPEG status: SMPEG_ERROR, SMPEG_PLAYING, SMPEG_STOPPED
		/// </returns>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int SMPEG_status( IntPtr mpeg );
		#endregion int SMPEG_status( IntPtr mpeg )

		#region void SMPEG_setvolume( IntPtr mpeg, int volume )
		/// <summary>
		/// Set the audio volume of an MPEG stream, in the range 0-100
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_setvolume( SMPEG* mpeg, int volume )
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="volume">Range from 0 - 100.</param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_setvolume( IntPtr mpeg, int volume );
		#endregion void SMPEG_setvolume( IntPtr mpeg, int volume )

		#region void SMPEG_setdisplay(...)
		/// <summary>
		/// Set the destination surface for MPEG video playback
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_setdisplay(SMPEG* mpeg, SDL_Surface* dst, SDL_mutex* surfLock, SMPEG_DisplayCallback callback);
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="dst"></param>
		/// <param name="surfLock">
		/// 'surfLock' is a mutex used to synchronize access to 'dst', 
		/// and can be NULL.
		/// </param>
		/// <param name="callback">
		/// 'callback' is a function called when an area of 'dst' needs 
		/// to be updated.
		///  If 'callback' is NULL, the default function (SDL_UpdateRect) 
		///  will be used.
		///  </param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_setdisplay(
			IntPtr mpeg, IntPtr dst, IntPtr surfLock, 
			SMPEG_DisplayCallback callback);
		#endregion void SMPEG_setdisplay(...)

		#region void SMPEG_loop( IntPtr mpeg, int repeat )
		/// <summary>
		/// Set or clear looping play on an SMPEG object
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_loop( SMPEG* mpeg, int repeat )
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="repeat"></param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_loop( IntPtr mpeg, int repeat );
		#endregion void SMPEG_loop( IntPtr mpeg, int repeat )

		#region void SMPEG_scaleXY( IntPtr mpeg, int width, int height )
		/// <summary>
		/// Scale pixel display on an SMPEG object
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_scaleXY( SMPEG* mpeg, int width, int height )
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_scaleXY( IntPtr mpeg, int width, int height );
		#endregion void SMPEG_scaleXY( IntPtr mpeg, int width, int height )

		#region void SMPEG_scale( IntPtr mpeg, int scale )
		/// <summary>
		/// Scale pixel display on an SMPEG object
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_scale( SMPEG* mpeg, int scale )
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="scale"></param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_scale( IntPtr mpeg, int scale );
		#endregion void SMPEG_scale( IntPtr mpeg, int scale )

		#region void SMPEG_double( IntPtr mpeg, int on )
		/// <summary>
		/// Scale pixel display on an SMPEG object
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// #define SMPEG_double(mpeg, on) \
		///		SMPEG_scale(mpeg, (on) ? 2 : 1)
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="on"></param>
		public static void SMPEG_double( IntPtr mpeg, int on )
		{
			if (on != 0)
			{
				Smpeg.SMPEG_scale(mpeg, 2);
			}
			else
			{
				Smpeg.SMPEG_scale(mpeg, 1);
			}
		}
		#endregion void SMPEG_double( IntPtr mpeg, int on )

		#region void SMPEG_move( IntPtr mpeg, int x, int y )
		/// <summary>
		/// Move the video display area within the destination surface
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_move( SMPEG* mpeg, int x, int y )
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_move( IntPtr mpeg, int x, int y );
		#endregion void SMPEG_move( IntPtr mpeg, int x, int y )

		#region void SMPEG_setdisplayregion(IntPtr mpeg, int x, int y, int w, int h)
		/// <summary>
		/// Set the region of the video to be shown
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_setdisplayregion(SMPEG* mpeg, int x, int y, int w, int h)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="h"></param>
		/// <param name="w"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_setdisplayregion(IntPtr mpeg, int x, int y, int w, int h);
		#endregion void SMPEG_setdisplayregion(IntPtr mpeg, int x, int y, int w, int h)

		#region void SMPEG_play( IntPtr mpeg )
		/// <summary>
		/// Play an SMPEG object
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_play( SMPEG* mpeg )
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_play( IntPtr mpeg );
		#endregion void SMPEG_play( IntPtr mpeg )

		#region void SMPEG_pause( IntPtr mpeg )
		/// <summary>
		/// Pause/Resume playback of an SMPEG object
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_pause( IntPtr mpeg )
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_pause( IntPtr mpeg );
		#endregion void SMPEG_pause( IntPtr mpeg )

		#region void SMPEG_stop( IntPtr mpeg )
		/// <summary>
		/// Stop playback of an SMPEG object
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_stop( SMPEG* mpeg )
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_stop( IntPtr mpeg );
		#endregion void SMPEG_stop( IntPtr mpeg )

		#region void SMPEG_rewind( IntPtr mpeg )
		/// <summary>
		/// Rewind the play position of an SMPEG object 
		/// to the beginning of the MPEG
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_rewind( SMPEG* mpeg )
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_rewind( IntPtr mpeg );
		#endregion void SMPEG_rewind( IntPtr mpeg )

		#region void SMPEG_seek( IntPtr mpeg, int bytes)
		/// <summary>
		/// Seek 'bytes' bytes in the MPEG stream
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_seek( SMPEG* mpeg, int bytes)
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="bytes">Bytes in the MPEG stream.</param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_seek( IntPtr mpeg, int bytes);
		#endregion void SMPEG_seek( IntPtr mpeg, int bytes)

		#region void SMPEG_skip( IntPtr mpeg, float seconds )
		/// <summary>
		/// Skip 'seconds' seconds in the MPEG stream
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_skip( SMPEG* mpeg, float seconds );
		/// </code></p></remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="seconds">Seconds in the MPEG stream.</param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_skip( IntPtr mpeg, float seconds );
		#endregion void SMPEG_skip( IntPtr mpeg, float seconds )

		#region void SMPEG_renderFrame( IntPtr mpeg, int framenum )
		/// <summary>
		/// Render a particular frame in the MPEG video
		/// </summary>
		/// <remarks>
		/// API CHANGE: This function no longer takes a target surface and position.
		///	Use SMPEG_setdisplay() and SMPEG_move() to set this information.
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_renderFrame( SMPEG* mpeg, int framenum )
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="framenum">Frame number</param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_renderFrame( IntPtr mpeg, int framenum );
		#endregion void SMPEG_renderFrame( IntPtr mpeg, int framenum )

		#region void SMPEG_renderFinal( IntPtr mpeg, IntPtr dst, int x, int y )
		/// <summary>
		/// Render the last frame of an MPEG video
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_renderFinal( SMPEG* mpeg, SDL_Surface* dst, int x, int y )
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="dst">SDL_Surface pointer</param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_renderFinal( IntPtr mpeg, IntPtr dst, int x, int y );
		#endregion void SMPEG_renderFinal( IntPtr mpeg, IntPtr dst, int x, int y )

		#region IntPtr SMPEG_filter( IntPtr mpeg, IntPtr filter )
		/// <summary>
		/// Set video filter
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// SMPEG_Filter * SMPEG_filter( SMPEG* mpeg, SMPEG_Filter * filter )
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="filter">IntPtr to SPEG_Filter</param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SMPEG_filter( IntPtr mpeg, IntPtr filter );
		#endregion IntPtr SMPEG_filter( IntPtr mpeg, IntPtr filter )

		#region string SMPEG_error( IntPtr mpeg )
		/// <summary>
		/// SMPEG errors messages.
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// char *SMPEG_error( SMPEG* mpeg );
		/// </code></p></remarks>
		/// <param name="mpeg">MPEG file pointer</param>
		/// <returns>
		/// Return NULL if there is no error in the MPEG stream, 
		/// or an error message
		/// if there was a fatal error in the MPEG stream for the SMPEG object..
		/// </returns>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern string SMPEG_error( IntPtr mpeg );
		#endregion string SMPEG_error( IntPtr mpeg )

		#region int SMPEG_playAudio( IntPtr mpeg, byte[] stream, int len )
		/// <summary>
		/// Exported callback function for audio playback.
		/// </summary>
		/// <remarks>
		/// The function takes a buffer and the amount of data to fill, and returns
		///		   the amount of data in bytes that was actually written.  This will be the
		///		   amount requested unless the MPEG audio has finished.
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// int SMPEG_playAudio( SMPEG *mpeg, Uint8 *stream, int len )
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="mpeg">Handle to MPEG file.</param>
		/// <param name="stream">Bytestream of data</param>
		/// <param name="len">Amount of data to fill</param>
		/// <returns>Amount of data in bytes that was actually written</returns>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int SMPEG_playAudio( IntPtr mpeg, byte[] stream, int len );
		#endregion int SMPEG_playAudio( IntPtr mpeg, byte[] stream, int len )

		#region void SMPEG_playAudioSDL( object mpeg, byte[] stream, int len )
		/// <summary>
		/// Wrapper for SMPEG_playAudio() that can be passed to SDL and SDL_mixer. 
		/// Exported callback function for audio playback.
		/// </summary>
		/// <remarks>
		/// The function takes a buffer and the amount of data to fill, and returns
		///		   the amount of data in bytes that was actually written.  This will be the
		///		   amount requested unless the MPEG audio has finished.
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_playAudioSDL( void *mpeg, Uint8 *stream, int len )
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="mpeg">MPEG object.</param>
		/// <param name="stream">Bytestream of data</param>
		/// <param name="len">Amount of data to fill</param>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_playAudioSDL( IntPtr mpeg, byte[] stream, int len );
		#endregion void SMPEG_playAudioSDL( object mpeg, byte[] stream, int len )

		#region int SMPEG_wantedSpec( IntPtr mpeg, IntPtr wanted )
		/// <summary>
		/// Get the best SDL audio spec for the audio stream 
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// int SMPEG_wantedSpec( SMPEG *mpeg, SDL_AudioSpec *wanted )
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="mpeg">MPEG object.</param>
		/// <param name="wanted">SDL_AudioSpec</param>
		/// <returns></returns>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int SMPEG_wantedSpec( IntPtr mpeg, IntPtr wanted );
		#endregion int SMPEG_wantedSpec( IntPtr mpeg, IntPtr wanted )

		#region void SMPEG_actualSpec( IntPtr mpeg, ref Sdl.SDL_AudioSpec spec )
		/// <summary>
		/// Inform SMPEG of the actual SDL audio spec used for sound playback
		/// </summary>
		/// <remarks>
		/// <p>Binds to a C-function call in smpeg.h
		/// <code>
		/// void SMPEG_actualSpec( SMPEG *mpeg, SDL_AudioSpec *spec )
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="mpeg">MPEG object.</param>
		/// <param name="spec">SDL_AudioSpec</param>
		/// <returns></returns>
		[DllImport(SMPEG_NATIVE_LIBRARY, 
			 CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern void SMPEG_actualSpec( IntPtr mpeg, ref Sdl.SDL_AudioSpec spec );
		#endregion void SMPEG_actualSpec( IntPtr mpeg, ref Sdl.SDL_AudioSpec spec )
		#endregion smpeg.h
		#endregion Smpeg Methods
	}
}
