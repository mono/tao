#region License
/*
MIT License
Copyright ©2003-2005 Tao Framework Team
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
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

namespace Tao.Sdl 
{
	#region Class Documentation
	/// <summary>
	///     Simple DirectMedia Layer binding for .NET, implementing SDL 1.2.9.
	/// </summary>
	/// <remarks>
	/// This library is designed to make it easy to write games that run 
	/// the .NET runtime using the various native high-performance media 
	/// interfaces, (for video, audio, etc) and presenting a single
	///  source-code level API to your application. This is a fairly 
	///  low level API, but using this, completely portable applications 
	///  can be written with a great deal of flexibility.
	/// <p>An introduction to SDL can be found online at: http://www.libsdl.org/intro/ </p>
	/// <p>Binds to functions and definitions in SDL.dll or libSDL.so.</p>
	/// </remarks>
	#endregion Class Documentation
	[SuppressUnmanagedCodeSecurityAttribute()]
	public sealed class Sdl 
	{
		#region Private Constants
		#region string SDL_NATIVE_LIBRARY
		/// <summary>
		///     Specifies SDL's native library archive.
		/// </summary>
		/// <remarks>
		///     Specifies SDL.dll everywhere; will be mapped via .config for mono.
		/// </remarks>
		private const string SDL_NATIVE_LIBRARY = "SDL.dll";
		#endregion string SDL_NATIVE_LIBRARY

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

		private const int BYTE_SIZE = 8;
		#endregion Private Constants

		#region Private Methods
		// OS X compatibility.
		[DllImport("/System/Library/Frameworks/Cocoa.framework/Cocoa", EntryPoint="NSApplicationLoad")]
		private static extern void NSApplicationLoad();
		#endregion Private Methods

		#region Public Constants
		#region SDL.h
		#region SDL_INIT_TIMER
		/// <summary>
		///     The timer subsystem.
		/// </summary>
		// #define SDL_INIT_TIMER 0x00000001
		public const int SDL_INIT_TIMER = 0x00000001;
		#endregion SDL_INIT_TIMER

		#region SDL_INIT_AUDIO
		/// <summary>
		///     The audio subsystem.
		/// </summary>
		// #define SDL_INIT_AUDIO 0x00000010
		public const int SDL_INIT_AUDIO = 0x00000010;
		#endregion SDL_INIT_AUDIO

		#region SDL_INIT_VIDEO
		/// <summary>
		///     The video subsystem.
		/// </summary>
		// #define SDL_INIT_VIDEO 0x00000020
		public const int SDL_INIT_VIDEO = 0x00000020;
		#endregion SDL_INIT_VIDEO

		#region SDL_INIT_CDROM
		/// <summary>
		///     The CD-ROM subsystem.
		/// </summary>
		// #define SDL_INIT_CDROM 0x00000100
		public const int SDL_INIT_CDROM = 0x00000100;
		#endregion SDL_INIT_CDROM

		#region SDL_INIT_JOYSTICK
		/// <summary>
		///     The joystick subsystem.
		/// </summary>
		// #define SDL_INIT_JOYSTICK 0x00000200
		public const int SDL_INIT_JOYSTICK = 0x00000200;
		#endregion SDL_INIT_JOYSTICK

		#region SDL_INIT_NOPARACHUTE
		/// <summary>
		///     Prevents SDL from catching fatal signals.
		/// </summary>
		// #define SDL_INIT_NOPARACHUTE 0x00100000
		public const int SDL_INIT_NOPARACHUTE = 0x00100000;
		#endregion SDL_INIT_NOPARACHUTE

		#region SDL_INIT_EVENTTHREAD
		/// <summary>
		///     Not supported on all OS's.
		/// </summary>
		// #define SDL_INIT_EVENTTHREAD 0x01000000
		public const int SDL_INIT_EVENTTHREAD = 0x01000000;
		#endregion SDL_INIT_EVENTTHREAD

		#region SDL_INIT_EVERYTHING
		/// <summary>
		///     All subsystems. 
		///     These are the flags which may be passed to SDL_Init()
		///     -- you should specify the subsystems which you will be
		///     using in your application..
		/// </summary>
		// #define SDL_INIT_EVERYTHING 0x0000FFFF
		public const int SDL_INIT_EVERYTHING = 0x0000FFFF;
		#endregion SDL_INIT_EVERYTHING
		#endregion SDL.h

		#region SDL_active.h
		#region SDL_APPMOUSEFOCUS
		/// <summary>
		/// The app has mouse coverage
		/// </summary>
		/// <remarks>
		/// The available application states
		/// </remarks>
		public const byte SDL_APPMOUSEFOCUS = 0x01;
		#endregion SDL_APPMOUSEFOCUS

		#region SDL_APPINPUTFOCUS
		/// <summary>
		/// The app has input focus
		/// </summary>
		/// <remarks>
		/// The available application states
		/// </remarks>
		public const byte SDL_APPINPUTFOCUS = 0x02;
		#endregion SDL_APPINPUTFOCUS

		#region SDL_APPACTIVE
		/// <summary>
		/// The application is active
		/// </summary>
		/// <remarks>
		/// The available application states
		/// </remarks>
		public const byte SDL_APPACTIVE = 0x04;
		#endregion SDL_APPACTIVE
		#endregion SDL_active.h

		#region SDL_audio.h
		#region AUDIO_U8
		/// <summary>
		/// Unsigned 8-bit samples.
		/// </summary>
		public const short AUDIO_U8 = 0x0008;
		#endregion AUDIO_U8

		#region AUDIO_S8
		/// <summary>
		/// Signed 8-bit samples.
		/// </summary>
		public const short AUDIO_S8 = unchecked ((short)0x8008);
		#endregion AUDIO_S8

		#region AUDIO_U16LSB
		/// <summary>
		/// Unsigned 16-bit little-endian samples.
		/// </summary>
		public const short AUDIO_U16LSB = 0x0010;
		#endregion AUDIO_U16LSB

		#region AUDIO_S16LSB
		/// <summary>
		/// Signed 16-bit little-endian samples
		/// </summary>
		public const short AUDIO_S16LSB	= unchecked ((short)0x8010);	
		#endregion AUDIO_S16LSB

		#region AUDIO_U16MSB
		/// <summary>
		/// Unsigned 16-bit big-endian samples
		/// </summary>
		public const short AUDIO_U16MSB	= 0x1010;
		#endregion AUDIO_U16MSB

		#region AUDIO_S16MSB
		/// <summary>
		/// Signed 16-bit big-endian samples
		/// </summary>
		public const short AUDIO_S16MSB	= unchecked ((short)0x9010);
		#endregion AUDIO_S16MSB

		#region AUDIO_U16
		/// <summary>
		/// Unsigned 16-bit little-endian samples
		/// </summary>
		public readonly short AUDIO_U16 = AUDIO_U16LSB;
		#endregion AUDIO_U16

		#region AUDIO_S16
		/// <summary>
		/// Signed 16-bit little-endian samples
		/// </summary>
		public readonly short AUDIO_S16 = unchecked((short)AUDIO_S16LSB);
		#endregion AUDIO_S16

		#region SDL_MIX_MAXVOLUME
		/// <summary>
		/// Full audio volume
		/// </summary>
		public const int SDL_MIX_MAXVOLUME = 128;
		#endregion SDL_MIX_MAXVOLUME
		#endregion SDL_audio.h

		#region SDL_byteorder.h
		#region SDL_LIL_ENDIAN
		/// <summary>
		/// Little Endian
		/// </summary>
		/// <remarks>
		/// e.g. i386 machines</remarks>
		public const int SDL_LIL_ENDIAN = 1234;
		#endregion SDL_LIL_ENDIAN

		#region SDL_BIG_ENDIAN
		/// <summary>
		/// Big Endian
		/// </summary>
		/// <remarks>
		/// e.g. Macs
		/// </remarks>
		public const int SDL_BIG_ENDIAN = 4321;
		#endregion SDL_BIG_ENDIAN
		#endregion SDL_byteorder.h
		
		#region SDL_cdrom.h
		#region SDL_MAX_TRACKS
		/// <summary>
		/// The maximum number of CD-ROM tracks on a disk
		/// </summary>
		public const int SDL_MAX_TRACKS = 99;
		#endregion SDL_MAX_TRACKS

		#region SDL_AUDIO_TRACK
		/// <summary>
		/// The types of CD-ROM track possible
		/// </summary>
		public const int SDL_AUDIO_TRACK = 0x00;
		#endregion SDL_AUDIO_TRACK

		#region SDL_DATA_TRACK
		/// <summary>
		/// The types of CD-ROM track possible
		/// </summary>
		public const int SDL_DATA_TRACK = 0x04;
		#endregion SDL_DATA_TRACK

		#region CD_FPS
		/// <summary>
		/// Frames per second.
		/// </summary>
		public const int CD_FPS = 75;
		#endregion CD_FPS
		#endregion SDL_cdrom.h

		// SDL_copying.h -- none
		// SDL_cpuinfo.h -- none
		// SDL_endian.h - skipped for now
		// SDL_error.h -- none

		#region SDL_events.h
		//The nameless enum from SDL_events.h was moved into a set of const
		//instead of a C# enum. This makes it work more like the C Code.
		/// <summary>
		/// Unused (do not remove)
		/// </summary>
		public const int SDL_NOEVENT = 0;		
		/// <summary>
		/// Application loses/gains visibility
		/// </summary>
		[CLSCompliant(false)]
		public const int SDL_ACTIVEEVENT = 1;			
		/// <summary>
		/// Keys pressed
		/// </summary>
		public const int SDL_KEYDOWN = 2;			
		/// <summary>
		/// Keys released
		/// </summary>
		public const int SDL_KEYUP = 3;		
		/// <summary>
		/// Mouse moved
		/// </summary>
		public const int SDL_MOUSEMOTION = 4;			
		/// <summary>
		/// Mouse button pressed
		/// </summary>
		public const int SDL_MOUSEBUTTONDOWN = 5;		
		/// <summary>
		/// Mouse button released
		/// </summary>
		public const int SDL_MOUSEBUTTONUP = 6;		
		/// <summary>
		/// Joystick axis motion
		/// </summary>
		public const int SDL_JOYAXISMOTION = 7;	
		/// <summary>
		/// Joystick trackball motion
		/// </summary>
		public const int SDL_JOYBALLMOTION = 8;	
		/// <summary>
		/// Joystick hat position change
		/// </summary>
		public const int SDL_JOYHATMOTION = 9;	
		/// <summary>
		/// Joystick button pressed
		/// </summary>
		public const int SDL_JOYBUTTONDOWN = 10;	
		/// <summary>
		/// Joystick button released
		/// </summary>
		public const int SDL_JOYBUTTONUP = 11;			
		/// <summary>
		/// User-requested quit
		/// </summary>
		[CLSCompliant(false)]
		public const int SDL_QUIT = 12;		
		/// <summary>
		/// System specific event
		/// </summary>
		[CLSCompliant(false)]
		public const int SDL_SYSWMEVENT = 13;			
		/// <summary>
		/// Reserved for future use..
		/// </summary>
		public const int SDL_EVENT_RESERVEDA = 14;		
		/// <summary>
		/// Reserved for future use..
		/// </summary>
		public const int SDL_EVENT_RESERVEDB = 15;	
		/// <summary>
		/// User resized video mode
		/// </summary>
		public const int SDL_VIDEORESIZE = 16;			
		/// <summary>
		/// Screen needs to be redrawn
		/// </summary>
		public const int SDL_VIDEOEXPOSE = 17;			
		/// <summary>
		/// Reserved for future use..
		/// </summary>
		public const int SDL_EVENT_RESERVED2 = 18;		
		/// <summary>
		/// Reserved for future use..
		/// </summary>
		public const int SDL_EVENT_RESERVED3 = 19;		
		/// <summary>
		/// Reserved for future use..
		/// </summary>
		public const int SDL_EVENT_RESERVED4 = 20;		
		/// <summary>
		/// Reserved for future use..
		/// </summary>
		public const int SDL_EVENT_RESERVED5 = 21;		
		/// <summary>
		/// Reserved for future use..
		/// </summary>
		public const int SDL_EVENT_RESERVED6 = 22;		
		/// <summary>
		/// Reserved for future use..
		/// </summary>
		public const int SDL_EVENT_RESERVED7 = 23;		
		/// <summary>
		/// Events SDL_USEREVENT through SDL_MAXEVENTS-1 are 
		/// for your use.
		/// </summary>
		[CLSCompliant(false)] 
		public const int SDL_USEREVENT = 24;

		/// <summary>
		/// This last event is only for bounding internal arrays
		/// It is the number of bits in the event mask datatype -- Uint32
		/// </summary>
		public const int SDL_NUMEVENTS = 32;

		/// <summary>
		/// 
		/// </summary>
		public const int SDL_ACTIVEEVENTMASK = 1 << SDL_ACTIVEEVENT;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_KEYDOWNMASK = 1 << SDL_KEYDOWN;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_KEYUPMASK = 1 << SDL_KEYUP;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_MOUSEMOTIONMASK = 1 << SDL_MOUSEMOTION;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_MOUSEBUTTONDOWNMASK = 1 << SDL_MOUSEBUTTONDOWN;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_MOUSEBUTTONUPMASK = 1 << SDL_MOUSEBUTTONUP;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_MOUSEEVENTMASK	= (1 << SDL_MOUSEMOTION)| (1 << SDL_MOUSEBUTTONDOWN)| (1 << SDL_MOUSEBUTTONUP);
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_JOYAXISMOTIONMASK = 1 << SDL_JOYAXISMOTION;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_JOYBALLMOTIONMASK = 1 << SDL_JOYBALLMOTION;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_JOYHATMOTIONMASK = 1 << SDL_JOYHATMOTION;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_JOYBUTTONDOWNMASK = 1 << SDL_JOYBUTTONDOWN;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_JOYBUTTONUPMASK = 1 << SDL_JOYBUTTONUP;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_JOYEVENTMASK = (1 << SDL_JOYAXISMOTION) | (1 << SDL_JOYBALLMOTION) | (1 << SDL_JOYHATMOTION) | (1 << SDL_JOYBUTTONDOWN) | (1 << SDL_JOYBUTTONUP);
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_VIDEORESIZEMASK = 1 << SDL_VIDEORESIZE;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_VIDEOEXPOSEMASK = 1 << SDL_VIDEOEXPOSE;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_QUITMASK = 1 << SDL_QUIT;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_SYSWMEVENTMASK = 1 << SDL_SYSWMEVENT;

		/// <summary>
		/// This is the mask which refers to all hotkey bindings.
		/// </summary>
		public const int SDL_ALLEVENTS = unchecked((int) 0xFFFFFFFF);

		/// <summary>
		/// If 'state' is set to SDL_QUERY, SDL_EventState() 
		/// will return the 
		/// current processing state of the specified event.
		/// </summary>
		public const int SDL_QUERY = -1;
		/// <summary>
		/// If 'state' is set to SDL_IGNORE, that event will be 
		/// automatically dropped
		/// from the event queue and will not event be filtered.
		/// </summary>
		public const int SDL_IGNORE = 0;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_DISABLE = 0;
		/// <summary>
		/// If 'state' is set to SDL_ENABLE, that event will 
		/// be processed normally.
		/// </summary>
		public const int SDL_ENABLE = 1;
		#endregion SDL_events.h

		// SDL_getenv.h -- none

		#region SDL_joystick.h
		/// <summary>
		/// Indicates which position a joystick hat is pressed in
		/// </summary>
		public const byte SDL_HAT_CENTERED = 0x00;

		/// <summary>
		/// 
		/// </summary>
		public const byte SDL_HAT_UP = 0x01;

		/// <summary>
		/// 
		/// </summary>
		public const byte SDL_HAT_RIGHT = 0x02;

		/// <summary>
		/// 
		/// </summary>
		public const byte SDL_HAT_DOWN = 0x04;

		/// <summary>
		/// 
		/// </summary>
		public const byte SDL_HAT_LEFT = 0x08;
		/// <summary>
		/// 
		/// </summary>
		public const byte SDL_HAT_RIGHTUP = (SDL_HAT_RIGHT|SDL_HAT_UP);
		/// <summary>
		/// 
		/// </summary>
		public const byte SDL_HAT_RIGHTDOWN = (SDL_HAT_RIGHT|SDL_HAT_DOWN);
		/// <summary>
		/// 
		/// </summary>
		public const byte SDL_HAT_LEFTUP = (SDL_HAT_LEFT|SDL_HAT_UP);
		/// <summary>
		/// 
		/// </summary>
		public const byte SDL_HAT_LEFTDOWN = (SDL_HAT_LEFT|SDL_HAT_DOWN);
		#endregion SDL_joystick.h

		#region SDL_keyboard.h
		/// <summary>
		/// This is the mask which refers to all hotkey bindings.
		/// </summary>
		public const int SDL_ALL_HOTKEYS = unchecked((int) 0xFFFFFFFF);

		/// <summary>
		/// Enable/Disable keyboard repeat.  Keyboard repeat defaults to off. 
		/// 'delay' is the initial delay in ms between the time 
		/// when a key is pressed,
		/// and keyboard repeat begins.
		/// </summary>
		/// <seealso cref="SDL_EnableKeyRepeat"/>
		public const int SDL_DEFAULT_REPEAT_DELAY = 500;
		
		/// <summary>
		/// Enable/Disable keyboard repeat.  Keyboard repeat defaults to off. 
		/// 'interval' is the time in ms between keyboard repeat events.
		/// </summary>
		/// <seealso cref="SDL_EnableKeyRepeat"/>
		public const int SDL_DEFAULT_REPEAT_INTERVAL = 30;
		#endregion SDL_keyboard.h

		#region SDL_keysym.h
		/// <summary>
		/// Both CTRL keys.
		/// </summary>
		public const short KMOD_CTRL = 
			(short) (KMOD_LCTRL|KMOD_RCTRL);

		/// <summary>
		/// Both SHIFT keys.
		/// </summary>
		public const short KMOD_SHIFT = 
			(short) (KMOD_LSHIFT|KMOD_RSHIFT);

		/// <summary>
		/// Both ALT keys.
		/// </summary>
		public const short KMOD_ALT = 
			(short) (KMOD_LALT|KMOD_RALT);

		/// <summary>
		/// Both META keys.
		/// </summary>
		public const short KMOD_META = (
			short) (KMOD_LMETA|KMOD_RMETA);
		#endregion SDL_keysym.h

		// SDL_loadso.h -- skipped
		// SDL_main.h -- none

		#region SDL_mouse.h
		/// <summary>
		/// Used as a mask when testing buttons in buttonstate
		/// Button 1:	Left mouse button
		/// </summary>
		public const byte SDL_BUTTON_LEFT = 1;
		/// <summary>
		/// Button 2:	Middle mouse button
		/// </summary>
		public const byte SDL_BUTTON_MIDDLE = 2;
		/// <summary>
		/// Button 3:	Right mouse button
		/// </summary>
		public const byte SDL_BUTTON_RIGHT = 3;
		/// <summary>
		/// Button 4:	Mouse wheel up	 (may also be a real button)
		/// </summary>
		public const byte SDL_BUTTON_WHEELUP = 4;
		/// <summary>
		/// Button 5:	Mouse wheel down (may also be a real button)
		/// </summary>
		public const byte SDL_BUTTON_WHEELDOWN = 5;
		/// <summary>
		/// 
		/// </summary>
		public const byte SDL_BUTTON_LMASK = SDL_PRESSED << ((byte)SDL_BUTTON_LEFT - 1);
		/// <summary>
		/// 
		/// </summary>
		public const byte SDL_BUTTON_MMASK = SDL_PRESSED << ((byte)SDL_BUTTON_MIDDLE - 1);
		/// <summary>
		/// 
		/// </summary>
		public const byte SDL_BUTTON_RMASK = SDL_PRESSED << ((byte)SDL_BUTTON_RIGHT - 1);
		#endregion SDL_mouse.h

		// SDL_mutex.h -- Skipped. Superceded by System.Threading class
		// SDL_name.h -- none
		// SDL_opengl.h -- superceded by Tao.OpenGL
		// SDL_quit.h -- none
		// SDL_rwops -- skipped for now, might be useful.
		// SDL_syswm.h -- none
		// SDL_thread.h -- skipped. Superceded by System.Threading class

		#region SDL_timer.h
		#region SDL_TIMESLICE
		/// <summary>
		///     The OS scheduler timeslice, in milliseconds.
		/// </summary>
		public const int SDL_TIMESLICE = 10;
		#endregion SDL_TIMESLICE

		#region TIMER_RESOLUTION
		/// <summary>
		///     The maximum resolution of the SDL timer on all platforms.
		/// </summary>
		/// <remarks>
		///     Experimentally determined.
		/// </remarks>
		public const int TIMER_RESOLUTION = 10;
		#endregion TIMER_RESOLUTION
		#endregion SDL_timer.h

		#region SDL_types.h
		/// <summary>
		/// Button in pressed state.
		/// </summary>
		/// <remarks>
		/// SDL_types.h defines SDL_PRESSED and <see cref="SDL_RELEASED"/>
		///  in a nameless enum. Defining SDL_PRESSED as a const works 
		///  better for Tao.SDL purposes</remarks>
		///  <seealso cref="SDL_RELEASED"/>
		public const byte SDL_PRESSED = 0x01;
		/// <summary>
		/// Button in released state.
		/// </summary>
		/// <remarks>
		/// SDL_types.h defines <see cref="SDL_PRESSED"/> and SDL_RELEASED
		///  in a nameless enum. Defining SDL_RELEASED as a const works 
		///  better for Tao.SDL purposes</remarks>
		///  <seealso cref="SDL_PRESSED"/>
		public const byte SDL_RELEASED = 0x00;
		#endregion SDL_types.h

		// SDL_version -- none

		#region SDL_video.h
		#region SDL_ALPHA_OPAQUE
		/// <summary>
		/// Transparency definition of Opaque
		/// </summary>
		/// <remarks>
		/// Define alpha as the opacity of a surface
		/// </remarks>
		public const int SDL_ALPHA_OPAQUE = 255;
		#endregion SDL_ALPHA_OPAQUE

		#region SDL_ALPHA_TRANSPARENT
		/// <summary>
		/// Transparency definition of Transparent
		/// </summary>
		/// <remarks>
		/// Define alpha as the opacity of a surface
		/// </remarks>
		public const int SDL_ALPHA_TRANSPARENT = 0;
		#endregion SDL_ALPHA_TRANSPARENT

		#region SDL_SWSURFACE
		/// <summary>
		/// Surface is in system memory
		/// </summary>
		public const int SDL_SWSURFACE = 0x00000000;
		#endregion SDL_SWSURFACE

		#region SDL_HWSURFACE
		/// <summary>
		/// Surface is in video memory
		/// </summary>
		public const int SDL_HWSURFACE = 0x00000001;
		#endregion SDL_HWSURFACE

		#region SDL_ASYNCBLIT
		/// <summary>
		/// Use asynchronous blits if possible
		/// </summary>
		public const int SDL_ASYNCBLIT = 0X00000004;
		#endregion SDL_ASYNCBLIT

		#region SDL_ANYFORMAT
		/// <summary>
		/// Allow any video depth/pixel-format
		/// </summary>
		public const int SDL_ANYFORMAT = 0X10000000;
		#endregion SDL_ANYFORMAT

		#region SDL_HWPALETTE
		/// <summary>
		/// Surface has exclusive palette
		/// </summary>
		public const int SDL_HWPALETTE = 0x20000000;
		#endregion SDL_HWPALETTE

		#region SDL_DOUBLEBUF
		/// <summary>
		/// Set up double-buffered video mode
		/// </summary>
		public const int SDL_DOUBLEBUF = 0X40000000;
		#endregion SDL_DOUBLEBUF

		#region SDL_FULLSCREEN
		/// <summary>
		/// Full screen display surface.
		/// </summary>
		// #define SDL_FULLSCREEN 0x80000000
		public const int SDL_FULLSCREEN = unchecked((int) 0x80000000);
		#endregion SDL_FULLSCREEN

		#region SDL_OPENGL
		/// <summary>
		/// Create an OpenGL rendering context
		/// </summary>
		public const int SDL_OPENGL = 0x00000002;
		#endregion SDL_OPENGL

		#region SDL_OPENGLBLIT
		/// <summary>
		/// Create an OpenGL rendering context and use it for blitting
		/// </summary>	
		public const int SDL_OPENGLBLIT = 0X0000000A;
		#endregion SDL_OPENGLBLIT
		
		#region SDL_RESIZABLE
		/// <summary>
		/// This video mode may be resized
		/// </summary>
		public const int SDL_RESIZABLE = 0x00000010;
		#endregion SDL_RESIZABLE

		#region SDL_NOFRAME
		/// <summary>
		/// No window caption or edge frame
		/// </summary>
		public const int SDL_NOFRAME = 0X00000020;
		#endregion SDL_NOFRAME

		#region SDL_HWACCEL
		/// <summary>
		/// Blit uses hardware acceleration
		/// </summary>
		public const int SDL_HWACCEL = 0x00000100;
		#endregion SDL_HWACCEL

		#region SDL_SRCCOLORKEY
		/// <summary>
		/// Blit uses a source color key
		/// </summary>
		public const int SDL_SRCCOLORKEY = 0x00001000;   
		#endregion SDL_SRCCOLORKEY

		#region SDL_RLEACCELOK
		/// <summary>
		/// Private flag
		/// </summary>
		public const int SDL_RLEACCELOK = 0x00002000;
		#endregion SDL_RLEACCELOK

		#region SDL_RLEACCEL
		/// <summary>
		/// Surface is RLE encoded
		/// </summary>
		public const int SDL_RLEACCEL = 0X00004000;
		#endregion SDL_RLEACCEL

		#region SDL_SRCALPHA
		/// <summary>
		/// Blit uses source alpha blending
		/// </summary>
		public const int SDL_SRCALPHA = 0x00010000;
		#endregion SDL_SRCALPHA

		#region SDL_PREALLOC
		/// <summary>
		/// Surface uses preallocated memory
		/// </summary>
		public const int SDL_PREALLOC = 0x01000000;
		#endregion SDL_PREALLOC

		#region SDL_YV12_OVERLAY
		/// <summary>
		///One of the most common video overlay formats.
		///For an explanation of these pixel formats, see:
		///http://www.webartz.com/fourcc/indexyuv.htm
		///
		///For information on the relationship between color spaces, see:
		///http://www.neuro.sfc.keio.ac.jp/~aly/polygon/info/color-space-faq.html
		///
		/// Planar mode: Y + V + U  (3 planes)
		/// </summary>
		public const int SDL_YV12_OVERLAY = 0x32315659;	
		#endregion SDL_YV12_OVERLAY

		#region SDL_IYUV_OVERLAY
		/// <summary>
		///One of the most common video overlay formats.
		///For an explanation of these pixel formats, see:
		///http://www.webartz.com/fourcc/indexyuv.htm
		///
		///For information on the relationship between color spaces, see:
		///http://www.neuro.sfc.keio.ac.jp/~aly/polygon/info/color-space-faq.html
		///
		/// Planar mode: Y + U + V  (3 planes)
		/// </summary>
		public const int SDL_IYUV_OVERLAY = 0x56555949;
		#endregion SDL_IYUV_OVERLAY

		#region SDL_YUY2_OVERLAY
		/// <summary>
		///One of the most common video overlay formats.
		///For an explanation of these pixel formats, see:
		///http://www.webartz.com/fourcc/indexyuv.htm
		///
		///For information on the relationship between color spaces, see:
		///http://www.neuro.sfc.keio.ac.jp/~aly/polygon/info/color-space-faq.html
		///
		/// Packed mode: Y0+U0+Y1+V0 (1 plane)
		/// </summary>
		public const int SDL_YUY2_OVERLAY = 0x32595559;
		#endregion SDL_YUY2_OVERLAY
	
		#region SDL_UYVY_OVERLAY
		/// <summary>
		///One of the most common video overlay formats.
		///For an explanation of these pixel formats, see:
		///http://www.webartz.com/fourcc/indexyuv.htm
		///
		///For information on the relationship between color spaces, see:
		///http://www.neuro.sfc.keio.ac.jp/~aly/polygon/info/color-space-faq.html
		///
		/// Packed mode: U0+Y0+V0+Y1 (1 plane)
		/// </summary>
		public const int SDL_UYVY_OVERLAY = 0x59565955;	
		#endregion SDL_UYVY_OVERLAY

		#region SDL_YVYU_OVERLAY
		/// <summary>
		///One of the most common video overlay formats.
		///For an explanation of these pixel formats, see:
		///http://www.webartz.com/fourcc/indexyuv.htm
		///
		///For information on the relationship between color spaces, see:
		///http://www.neuro.sfc.keio.ac.jp/~aly/polygon/info/color-space-faq.html
		///
		/// Packed mode: Y0+V0+Y1+U0 (1 plane)
		/// </summary>
		public const int SDL_YVYU_OVERLAY = 0x55595659;
		#endregion SDL_YVYU_OVERLAY

		#region SDL_LOGPAL
		/// <summary>
		/// Flag for SDL_SetPalette() which represents a logical palette, which controls how blits 
		/// are mapped to/from the surface.
		/// </summary>
		public const byte SDL_LOGPAL = 0x01;
		#endregion SDL_LOGPAL

		#region SDL_PHYSPAL
		/// <summary>
		/// Flag for SDL_SetPalette() which represents a physical palette, which controls how pixels 
		/// look on the screen.
		/// </summary>
		public const byte SDL_PHYSPAL = 0x02;
		#endregion SDL_PHYSPAL

		//Where did this come from?? SDL_GL_DOUBLEBUFFER is in SDL_GLattr
		//		#region SDL_GL_DOUBLEBUFFER
		//		/// <summary>
		//		/// 
		//		/// </summary>
		//		public const int SDL_GL_DOUBLEBUFFER = 5;
		//		#endregion SDL_GL_DOUBLEBUFFER

		#endregion SDL_video.h
		#endregion Public Constants

		#region Public Enums
		// SDL.h -- none
		// SDL_active.h -- none

		#region SDL_audio.h
		#region SDL_audiostatus
		/// <summary>
		/// SDL_audiostatus. Get the current audio state
		/// </summary>
		public const int SDL_AUDIO_STOPPED = 0;
		/// <summary>
		/// SDL_audiostatus. Get the current audio state
		/// </summary>
		public const int SDL_AUDIO_PLAYING = 1;
		/// <summary>
		/// SDL_audiostatus. Get the current audio state
		/// </summary>
		public const int SDL_AUDIO_PAUSED = 2;
		#endregion SDL_audiostatus
		#endregion SDL_audio.h

		// SDL_byteorder.h -- none

		#region SDL_cdrom.h
		#region CDstatus
		/// <summary>
		/// The CD tray is empty.
		/// </summary>
		/// <remarks>
		/// CDstatus enum.
		/// The possible states which a CD-ROM drive can be in.
		/// </remarks>
		public const int CD_TRAYEMPTY = 0;
		/// <summary>
		/// The CD has stopped playing.
		/// </summary>
		/// <remarks>
		/// CDstatus enum.
		/// The possible states which a CD-ROM drive can be in.
		/// </remarks>
		public const int CD_STOPPED = 1;
		/// <summary>
		/// The CD is playing.
		/// </summary>
		/// <remarks>
		/// CDstatus enum.
		/// The possible states which a CD-ROM drive can be in.
		/// </remarks>
		public const int CD_PLAYING = 2;
		/// <summary>
		/// The CD has been paused.
		/// </summary>
		/// <remarks>
		/// CDstatus enum.
		/// The possible states which a CD-ROM drive can be in.
		/// </remarks>
		public const int CD_PAUSED = 3;
		/// <summary>
		/// An error occured while getting the status.
		/// </summary>
		/// <remarks>
		/// CDstatus enum.
		/// The possible states which a CD-ROM drive can be in.
		/// </remarks>
		public const int CD_ERROR = -1;
		#endregion CDstatus
		#endregion SDL_cdrom.h

		// SDL_copying.h -- none
		// SDL_cpuinfo.h -- none
		// SDL_endian.h - skipped for now
		// SDL_error.h -- none

		#region SDL_events.h
		#region SDL_eventaction
		/// <summary>
		/// If 'action' is SDL_ADDEVENT, up to 'numevents' events will 
		/// be added to the back of the event queue.
		/// </summary>
		/// <remarks>
		/// enum SDL_eventaction. 
		/// Various event types.
		/// </remarks>
		/// <seealso cref="SDL_PeepEvents"/>
		public const int SDL_ADDEVENT = 0;
		/// <summary>
		/// If 'action' is SDL_PEEKEVENT, up to 'numevents' events at 
		/// the front of the event queue, matching 'mask', will be 
		/// returned and will not be removed from the queue.
		/// </summary>
		/// <remarks>
		/// enum SDL_eventaction. 
		/// Various event types.
		/// </remarks>
		/// <seealso cref="SDL_PeepEvents"/>
		public const int SDL_PEEKEVENT = 1;
		/// <summary>
		/// If 'action' is SDL_GETEVENT, up to 'numevents' events at 
		/// the front of the event queue, matching 'mask', will be 
		/// returned and will be removed from the queue.
		/// </summary>
		/// <remarks>
		/// enum SDL_eventaction. 
		/// Various event types.
		/// </remarks>
		/// <seealso cref="SDL_PeepEvents"/>
		public const int SDL_GETEVENT = 2;
		#endregion SDL_eventaction
		#endregion SDL_events.h

		// SDL_getenv.h -- none
		// SDL_joystick.h -- none
		// SDL_keyboard.h -- none

		#region SDL_keysym.h
		#region SDLKey
		//		/// <summary>
		//		/// What we really want is a mapping of every raw key on the keyboard.
		//		/// To support international keyboards, we use the range 0xA1 - 0xFF
		//		/// as international virtual keycodes.  
		//		/// We'll follow in the footsteps of X11...
		//		/// The keyboard syms have been cleverly chosen to map to ASCII
		//		/// </summary>
		//		//public enum SDLKey 
		//		//{
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_UNKNOWN		= 0;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_FIRST		= 0;
		/// <summary>
		/// backspace. '\b'
		/// </summary>
		public const int SDLK_BACKSPACE		= 8;
		/// <summary>
		/// tab. '\t'
		/// </summary>
		public const int SDLK_TAB		= 9;
		/// <summary>
		/// clear
		/// </summary>
		public const int SDLK_CLEAR		= 12;
		/// <summary>
		/// return. '\r' 
		/// </summary>
		public const int SDLK_RETURN		= 13;
		/// <summary>
		/// pause
		/// </summary>
		public const int SDLK_PAUSE		= 19;
		/// <summary>
		/// escape. '^['
		/// </summary>
		public const int SDLK_ESCAPE		= 27;
		/// <summary>
		/// space. ' '
		/// </summary>
		public const int SDLK_SPACE		= 32;
		/// <summary>
		/// exclaim. '!'
		/// </summary>
		public const int SDLK_EXCLAIM		= 33;
		/// <summary>
		/// quotedbl. '"'
		/// </summary>
		public const int SDLK_QUOTEDBL		= 34;
		/// <summary>
		/// hash. '#'
		/// </summary>
		public const int SDLK_HASH		= 35;
		/// <summary>
		/// dollar. '$'
		/// </summary>
		public const int SDLK_DOLLAR		= 36;
		/// <summary>
		/// ampersand. '&amp;'
		/// </summary>
		public const int SDLK_AMPERSAND		= 38;
		/// <summary>
		/// quote. '''
		/// </summary>
		public const int SDLK_QUOTE		= 39;
		/// <summary>
		/// left parenthesis. '('
		/// </summary>
		public const int SDLK_LEFTPAREN		= 40;
		/// <summary>
		/// right parenthesis. ')'
		/// </summary>
		public const int SDLK_RIGHTPAREN		= 41;
		/// <summary>
		/// asterisk. '*'
		/// </summary>
		public const int SDLK_ASTERISK		= 42;
		/// <summary>
		/// plus sign. '+'
		/// </summary>
		public const int SDLK_PLUS		= 43;
		/// <summary>
		/// comma. ';'
		/// </summary>
		public const int SDLK_COMMA		= 44;
		/// <summary>
		/// minus sign. '-'
		/// </summary>
		public const int SDLK_MINUS		= 45;
		/// <summary>
		/// period. '.'
		/// </summary>
		public const int SDLK_PERIOD		= 46;
		/// <summary>
		/// forward slash. '/'
		/// </summary>
		public const int SDLK_SLASH		= 47;
		/// <summary>
		/// 0
		/// </summary>
		public const int SDLK_0			= 48;
		/// <summary>
		/// 1
		/// </summary>
		public const int SDLK_1			= 49;
		/// <summary>
		/// 2
		/// </summary>
		public const int SDLK_2			= 50;
		/// <summary>
		/// 3
		/// </summary>
		public const int SDLK_3			= 51;
		/// <summary>
		/// 4
		/// </summary>
		public const int SDLK_4			= 52;
		/// <summary>
		/// 5
		/// </summary>
		public const int SDLK_5			= 53;
		/// <summary>
		/// 6
		/// </summary>
		public const int SDLK_6			= 54;
		/// <summary>
		/// 7
		/// </summary>
		public const int SDLK_7			= 55;
		/// <summary>
		/// 8
		/// </summary>
		public const int SDLK_8			= 56;
		/// <summary>
		/// 9
		/// </summary>
		public const int SDLK_9			= 57;
		/// <summary>
		/// colon. ':'
		/// </summary>
		public const int SDLK_COLON		= 58;
		/// <summary>
		/// semicolon. ';'
		/// </summary>
		public const int SDLK_SEMICOLON		= 59;
		/// <summary>
		/// less-than sign. '&lt;'
		/// </summary>
		public const int SDLK_LESS		= 60;
		/// <summary>
		/// equals sign. '='
		/// </summary>
		public const int SDLK_EQUALS		= 61;
		/// <summary>
		/// greater-than sign. '&gt;'
		/// </summary>
		public const int SDLK_GREATER		= 62;
		/// <summary>
		/// question mark. '?'
		/// </summary>
		public const int SDLK_QUESTION		= 63;
		/// <summary>
		/// at. '@'
		/// </summary>
		public const int SDLK_AT			= 64;
		/* 
			   Skip uppercase letters
			 */
		/// <summary>
		/// left bracket. '['
		/// </summary>
		public const int SDLK_LEFTBRACKET	= 91;
		/// <summary>
		/// backslash. '\'
		/// </summary>
		public const int SDLK_BACKSLASH		= 92;
		/// <summary>
		/// right bracket. ']'
		/// </summary>
		public const int SDLK_RIGHTBRACKET	= 93;
		/// <summary>
		/// caret. '^'
		/// </summary>
		public const int SDLK_CARET		= 94;
		/// <summary>
		/// underscore.'_'
		/// </summary>
		public const int SDLK_UNDERSCORE		= 95;
		/// <summary>
		/// grave. '`'
		/// </summary>
		public const int SDLK_BACKQUOTE		= 96;
		/// <summary>
		/// a
		/// </summary>
		public const int SDLK_a			= 97;
		/// <summary>
		/// b
		/// </summary>
		public const int SDLK_b			= 98;
		/// <summary>
		/// c
		/// </summary>
		public const int SDLK_c			= 99;
		/// <summary>
		/// d
		/// </summary>
		public const int SDLK_d			= 100;
		/// <summary>
		/// e
		/// </summary>
		public const int SDLK_e			= 101;
		/// <summary>
		/// f
		/// </summary>
		public const int SDLK_f			= 102;
		/// <summary>
		/// g
		/// </summary>
		public const int SDLK_g			= 103;
		/// <summary>
		/// h
		/// </summary>
		public const int SDLK_h			= 104;
		/// <summary>
		/// i
		/// </summary>
		public const int SDLK_i			= 105;
		/// <summary>
		/// j
		/// </summary>
		public const int SDLK_j			= 106;
		/// <summary>
		/// k
		/// </summary>
		public const int SDLK_k			= 107;
		/// <summary>
		/// l
		/// </summary>
		public const int SDLK_l			= 108;
		/// <summary>
		/// m
		/// </summary>
		public const int SDLK_m			= 109;
		/// <summary>
		/// n
		/// </summary>
		public const int SDLK_n			= 110;
		/// <summary>
		/// o
		/// </summary>
		public const int SDLK_o			= 111;
		/// <summary>
		/// p
		/// </summary>
		public const int SDLK_p			= 112;
		/// <summary>
		/// q
		/// </summary>
		public const int SDLK_q			= 113;
		/// <summary>
		/// r
		/// </summary>
		public const int SDLK_r			= 114;
		/// <summary>
		/// s
		/// </summary>
		public const int SDLK_s			= 115;
		/// <summary>
		/// t
		/// </summary>
		public const int SDLK_t			= 116;
		/// <summary>
		/// u
		/// </summary>
		public const int SDLK_u			= 117;
		/// <summary>
		/// v
		/// </summary>
		public const int SDLK_v			= 118;
		/// <summary>
		/// w
		/// </summary>
		public const int SDLK_w			= 119;
		/// <summary>
		/// x
		/// </summary>
		public const int SDLK_x			= 120;
		/// <summary>
		/// y
		/// </summary>
		public const int SDLK_y			= 121;
		/// <summary>
		/// z
		/// </summary>
		public const int SDLK_z			= 122;
		/// <summary>
		/// delete. '^?'
		/// </summary>
		public const int SDLK_DELETE		= 127;
		/* End of ASCII mapped keysyms */

		/* International keyboard syms */
		/// <summary>
		/// 0xA0
		/// </summary>
		public const int SDLK_WORLD_0		= 160;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_1		= 161;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_2		= 162;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_3		= 163;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_4		= 164;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_5		= 165;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_6		= 166;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_7		= 167;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_8		= 168;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_9		= 169;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_10		= 170;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_11		= 171;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_12		= 172;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_13		= 173;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_14		= 174;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_15		= 175;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_16		= 176;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_17		= 177;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_18		= 178;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_19		= 179;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_20		= 180;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_21		= 181;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_22		= 182;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_23		= 183;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_24		= 184;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_25		= 185;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_26		= 186;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_27		= 187;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_28		= 188;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_29		= 189;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_30		= 190;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_31		= 191;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_32		= 192;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_33		= 193;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_34		= 194;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_35		= 195;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_36		= 196;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_37		= 197;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_38		= 198;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_39		= 199;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_40		= 200;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_41		= 201;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_42		= 202;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_43		= 203;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_44		= 204;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_45		= 205;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_46		= 206;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_47		= 207;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_48		= 208;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_49		= 209;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_50		= 210;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_51		= 211;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_52		= 212;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_53		= 213;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_54		= 214;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_55		= 215;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_56		= 216;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_57		= 217;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_58		= 218;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_59		= 219;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_60		= 220;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_61		= 221;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_62		= 222;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_63		= 223;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_64		= 224;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_65		= 225;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_66		= 226;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_67		= 227;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_68		= 228;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_69		= 229;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_70		= 230;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_71		= 231;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_72		= 232;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_73		= 233;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_74		= 234;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_75		= 235;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_76		= 236;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_77		= 237;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_78		= 238;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_79		= 239;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_80		= 240;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_81		= 241;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_82		= 242;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_83		= 243;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_84		= 244;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_85		= 245;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_86		= 246;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_87		= 247;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_88		= 248;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_89		= 249;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_90		= 250;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_91		= 251;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_92		= 252;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_93		= 253;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_WORLD_94		= 254;
		/// <summary>
		/// 0xFF
		/// </summary>
		public const int SDLK_WORLD_95		= 255;

		/* Numeric keypad */
		/// <summary>
		/// keypad 0
		/// </summary>
		public const int SDLK_KP0		= 256;
		/// <summary>
		/// keypad 1
		/// </summary>
		public const int SDLK_KP1		= 257;
		/// <summary>
		/// keypad 2
		/// </summary>
		public const int SDLK_KP2		= 258;
		/// <summary>
		/// keypad 3
		/// </summary>
		public const int SDLK_KP3		= 259;
		/// <summary>
		/// keypad 4
		/// </summary>
		public const int SDLK_KP4		= 260;
		/// <summary>
		/// keypad 5
		/// </summary>
		public const int SDLK_KP5		= 261;
		/// <summary>
		/// keypad 6
		/// </summary>
		public const int SDLK_KP6		= 262;
		/// <summary>
		/// keypad 7
		/// </summary>
		public const int SDLK_KP7		= 263;
		/// <summary>
		/// keypad 8
		/// </summary>
		public const int SDLK_KP8		= 264;
		/// <summary>
		/// keypad 9
		/// </summary>
		public const int SDLK_KP9		= 265;
		/// <summary>
		/// keypad period. '.'
		/// </summary>
		public const int SDLK_KP_PERIOD		= 266;
		/// <summary>
		/// keypad divide. '/'
		/// </summary>
		public const int SDLK_KP_DIVIDE		= 267;
		/// <summary>
		/// keypad multiply. '*'
		/// </summary>
		public const int SDLK_KP_MULTIPLY	= 268;
		/// <summary>
		/// keypad minus. '-'
		/// </summary>
		public const int SDLK_KP_MINUS		= 269;
		/// <summary>
		/// keypad plus. '+'
		/// </summary>
		public const int SDLK_KP_PLUS		= 270;
		/// <summary>
		/// keypad enter. '\r'
		/// </summary>
		public const int SDLK_KP_ENTER		= 271;
		/// <summary>
		/// keypad equals. '='
		/// </summary>
		public const int SDLK_KP_EQUALS		= 272;

		/* Arrows + Home/End pad */
		/// <summary>
		/// up arrow
		/// </summary>
		public const int SDLK_UP			= 273;
		/// <summary>
		/// down arrow
		/// </summary>
		public const int SDLK_DOWN		= 274;
		/// <summary>
		/// right arrow
		/// </summary>
		public const int SDLK_RIGHT		= 275;
		/// <summary>
		/// left arrow
		/// </summary>
		public const int SDLK_LEFT		= 276;
		/// <summary>
		/// insert
		/// </summary>
		public const int SDLK_INSERT		= 277;
		/// <summary>
		/// home
		/// </summary>
		public const int SDLK_HOME		= 278;
		/// <summary>
		/// end
		/// </summary>
		public const int SDLK_END		= 279;
		/// <summary>
		/// page up
		/// </summary>
		public const int SDLK_PAGEUP		= 280;
		/// <summary>
		/// page down
		/// </summary>
		public const int SDLK_PAGEDOWN	= 281;

		/* Function keys */
		/// <summary>
		/// F1
		/// </summary>
		public const int SDLK_F1			= 282;
		/// <summary>
		/// F2
		/// </summary>
		public const int SDLK_F2			= 283;
		/// <summary>
		/// F3
		/// </summary>
		public const int SDLK_F3			= 284;
		/// <summary>
		/// F4
		/// </summary>
		public const int SDLK_F4			= 285;
		/// <summary>
		/// F5
		/// </summary>
		public const int SDLK_F5			= 286;
		/// <summary>
		/// F6
		/// </summary>
		public const int SDLK_F6			= 287;
		/// <summary>
		/// F7
		/// </summary>
		public const int SDLK_F7			= 288;
		/// <summary>
		/// F8
		/// </summary>
		public const int SDLK_F8			= 289;
		/// <summary>
		/// F9
		/// </summary>
		public const int SDLK_F9			= 290;
		/// <summary>
		/// F10
		/// </summary>
		public const int SDLK_F10		= 291;
		/// <summary>
		/// F11
		/// </summary>
		public const int SDLK_F11		= 292;
		/// <summary>
		/// F12
		/// </summary>
		public const int SDLK_F12		= 293;
		/// <summary>
		/// F13
		/// </summary>
		public const int SDLK_F13		= 294;
		/// <summary>
		/// F14
		/// </summary>
		public const int SDLK_F14		= 295;
		/// <summary>
		/// F15
		/// </summary>
		public const int SDLK_F15		= 296;

		/* Key state modifier keys */
		/// <summary>
		/// numlock
		/// </summary>
		public const int SDLK_NUMLOCK		= 300;
		/// <summary>
		/// capslock
		/// </summary>
		public const int SDLK_CAPSLOCK		= 301;
		/// <summary>
		/// scrollock
		/// </summary>
		public const int SDLK_SCROLLOCK		= 302;
		/// <summary>
		/// right shift
		/// </summary>
		public const int SDLK_RSHIFT		= 303;
		/// <summary>
		/// left shift
		/// </summary>
		public const int SDLK_LSHIFT		= 304;
		/// <summary>
		/// right ctrl
		/// </summary>
		public const int SDLK_RCTRL		= 305;
		/// <summary>
		/// left ctrl
		/// </summary>
		public const int SDLK_LCTRL		= 306;
		/// <summary>
		/// right alt
		/// </summary>
		public const int SDLK_RALT		= 307;
		/// <summary>
		/// left alt
		/// </summary>
		public const int SDLK_LALT		= 308;
		/// <summary>
		/// right meta
		/// </summary>
		public const int SDLK_RMETA		= 309;
		/// <summary>
		/// left meta
		/// </summary>
		public const int SDLK_LMETA		= 310;
		/// <summary>
		/// Left "Windows" key
		/// </summary>
		public const int SDLK_LSUPER		= 311;
		/// <summary>
		/// Right "Windows" key
		/// </summary>
		public const int SDLK_RSUPER		= 312;
		/// <summary>
		/// "Alt Gr" key. Mode key
		/// </summary>
		public const int SDLK_MODE		= 313;
		/// <summary>
		/// Multi-key compose key
		/// </summary>
		public const int SDLK_COMPOSE		= 314;

		// Miscellaneous function keys
		/// <summary>
		/// help
		/// </summary>
		public const int SDLK_HELP		= 315;
		/// <summary>
		/// print-screen
		/// </summary>
		public const int SDLK_PRINT		= 316;
		/// <summary>
		/// SysRq
		/// </summary>
		public const int SDLK_SYSREQ		= 317;
		/// <summary>
		/// break
		/// </summary>
		public const int SDLK_BREAK		= 318;
		/// <summary>
		/// menu
		/// </summary>
		public const int SDLK_MENU		= 319;
		/// <summary>
		/// Power Macintosh power key
		/// </summary>
		public const int SDLK_POWER		= 320;		
		/// <summary>
		/// Some european keyboards
		/// </summary>
		public const int SDLK_EURO		= 321;		
		/// <summary>
		/// Atari keyboard has Undo
		/// </summary>
		public const int SDLK_UNDO		= 322;

		// Add any other keys here
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_LAST		= 323;
		//	}
		#endregion SDLKey

		#region SDLMod
		/// <summary>
		/// No modifiers applicable
		/// </summary>
		/// <remarks>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </remarks>
		public const int KMOD_NONE  = 0x0000;
		/// <summary>
		/// Left Shift is down
		/// </summary>
		/// <remarks>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </remarks>
		public const int KMOD_LSHIFT= 0x0001;
		/// <summary>
		/// Right Shift is down
		/// </summary>
		/// <remarks>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </remarks>
		public const int KMOD_RSHIFT= 0x0002;
		/// <summary>
		/// Left Control is down
		/// </summary>
		/// <remarks>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </remarks>
		public const int KMOD_LCTRL = 0x0040;
		/// <summary>
		/// Right Control is down
		/// </summary>
		/// <remarks>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </remarks>
		public const int KMOD_RCTRL = 0x0080;
		/// <summary>
		/// Left Alt is down
		/// </summary>
		/// <remarks>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </remarks>
		public const int KMOD_LALT  = 0x0100;
		/// <summary>
		/// Right Alt is down
		/// </summary>
		/// <remarks>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </remarks>
		public const int KMOD_RALT  = 0x0200;
		/// <summary>
		/// Left Meta is down
		/// </summary>
		/// <remarks>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </remarks>
		public const int KMOD_LMETA = 0x0400;
		/// <summary>
		/// Right Meta is down
		/// </summary>
		/// <remarks>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </remarks>
		public const int KMOD_RMETA = 0x0800;
		/// <summary>
		/// Numlock is down
		/// </summary>
		/// <remarks>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </remarks>
		public const int KMOD_NUM   = 0x1000;
		/// <summary>
		/// Capslock is down
		/// </summary>
		/// <remarks>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </remarks>
		public const int KMOD_CAPS  = 0x2000;
		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </remarks>
		public const int KMOD_MODE  = 0x4000;
		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </remarks>
		public const int KMOD_RESERVED = 0x8000;
		#endregion SDLMod
		#endregion SDL_keysym.h

		// SDL_loadso.h -- skipped
		// SDL_main.h -- none
		// SDL_mouse.h -- none
		// SDL_mutex.h -- Skipped. Superceded by System.Threading class
		// SDL_name.h -- none
		// SDL_opengl.h -- skipped. superceded by Tao.OpenGL
		// SDL_quit.h -- none
		// SDL_rwops -- skipped for now, might be useful.

		#region SDL_syswm.h
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_SYSWM_X11 = 0;
		#endregion SDL_syswm.h

		// SDL_thread.h -- Skipped. Superceded by System.Threading class
		// SDL_timer.h -- none

		#region SDL_types.h
		#region SDL_bool
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_FALSE = 0;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_TRUE  = 1;
		#endregion SDL_bool
		#endregion SDL_types.h

		// SDL_version -- none

		#region SDL_video.h
		#region SDL_GLattr
		/// <summary>
		/// Size of the framebuffer red component, in bits
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_RED_SIZE = 0;
		/// <summary>
		/// Size of the framebuffer green component, in bits
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_GREEN_SIZE = 1;
		/// <summary>
		/// Size of the framebuffer blue component, in bits
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_BLUE_SIZE = 2;
		/// <summary>
		/// Size of the framebuffer alpha component, in bits
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// Public enumeration for setting the OpenGL window Attributes
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_ALPHA_SIZE = 3;
		/// <summary>
		/// Size of the framebuffer, in bits
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_BUFFER_SIZE = 4;
		/// <summary>
		/// 0 or 1, enable or disable double buffering
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_DOUBLEBUFFER = 5;
		/// <summary>
		/// Size of the depth buffer, in bits
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_DEPTH_SIZE = 6;
		/// <summary>
		/// Size of the stencil buffer, in bits.
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_STENCIL_SIZE = 7;
		/// <summary>
		/// Size of the accumulation buffer red component, in bits.
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_ACCUM_RED_SIZE = 8;
		/// <summary>
		/// Size of the accumulation buffer green component, in bits.
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_ACCUM_GREEN_SIZE = 9;
		/// <summary>
		/// Size of the accumulation buffer blue component, in bits.
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_ACCUM_BLUE_SIZE = 10;
		/// <summary>
		/// Size of the accumulation buffer alpha component, in bits.
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_ACCUM_ALPHA_SIZE = 11;
		/// <summary>
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_STEREO = 12;
		/// <summary>
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_MULTISAMPLEBUFFERS = 13;
		/// <summary>
		/// Public enumeration for setting the OpenGL window Attributes
		/// </summary>
		/// <remarks>
		/// While you can set most OpenGL attributes normally, 
		/// the attributes list above must be known before SDL 
		/// sets the video mode. These attributes a set and read 
		/// with <see cref="SDL_GL_SetAttribute"/> and 
		/// <see cref="SDL_GL_GetAttribute"/>.
		/// </remarks>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		public const int SDL_GL_MULTISAMPLESAMPLES = 14;
		#endregion SDL_GLattr

		#region SDL_GrabMode
		/// <summary>
		/// Input grab state.
		/// </summary>
		/// <remarks>
		/// enum SDL_GrabMode. 
		/// </remarks>
		/// <see cref="SDL_WM_GrabInput"/>
		public const int SDL_GRAB_QUERY = -1;
		/// <summary>
		/// Input grab state.
		/// </summary>
		/// <remarks>
		/// enum SDL_GrabMode. 
		/// </remarks>
		/// <see cref="SDL_WM_GrabInput"/>
		public const int SDL_GRAB_OFF = 0;
		/// <summary>
		/// Input grab state.
		/// </summary>
		/// <remarks>
		/// enum SDL_GrabMode. 
		/// </remarks>
		/// <see cref="SDL_WM_GrabInput"/>
		public const int SDL_GRAB_ON = 1;
		/// <summary>
		/// Input grab state.
		/// </summary>
		/// <remarks>
		/// enum SDL_GrabMode. 
		/// </remarks>
		/// <see cref="SDL_WM_GrabInput"/>
		public const int SDL_GRAB_FULLSCREEN =2;
		#endregion SDL_GrabMode
		#endregion SDL_video.h
		#endregion Public Enums

		#region Public Structs
		// SDL.h -- none
		// SDL_active.h -- none

		#region SDL_audio.h
		#region SDL_AudioSpec
		/// <summary>
		/// Audio Specification Structure
		/// </summary>
		/// <remarks>The calculated values in this structure are 
		/// calculated by SDL_OpenAudio()
		/// The SDL_AudioSpec structure is used to describe the format of some 
		/// audio data. This structure is used by SDL_OpenAudio and SDL_LoadWAV.
		///  While all fields are used by <see cref="SDL_OpenAudio"/> only 
		///  freq, format, samples
		///   and channels are used by <see cref="SDL_LoadWAV"/>. 
		///   We will detail these common members here.
		///   <p>Marshals C-struct in SDL_audio.h:
		///   <code>
		///   typedef struct{
		///		int freq;
		///		Uint16 format;
		///		Uint8 channels;
		///		Uint8 silence;
		///		Uint16 samples;
		///		Uint32 size;
		///		void (*callback)(void *userdata, Uint8 *stream, int len);
		///		void *userdata;
		///	} SDL_AudioSpec;
		///   </code></p>
		/// </remarks>
		/// <seealso cref="SDL_OpenAudio"/>
		/// <seealso cref="SDL_LoadWAV"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_AudioSpec 
		{
			/// <summary>
			/// Audio frequency in samples per second
			/// </summary>
			/// <remarks>
			/// The number of samples sent to the sound device every second.
			///  Common values are 11025, 22050 and 44100. The higher the better.
			/// </remarks>
			public int freq;	
			/// <summary>
			/// Audio data format.
			/// </summary>
			/// <remarks>
			/// Specifies the size and type of each sample element.
			/// <list type="table">
			///             <item>
			///                 <term><see cref="AUDIO_U8" /></term>
			///                 <description>Unsigned 8-bit samples</description>
			///             </item>
			///             <item>
			///                 <term><see cref="AUDIO_S8" /></term>
			///                 <description>Signed 8-bit samples</description>
			///             </item>
			///             <item>
			///                 <term><see cref="AUDIO_U16"/> <see cref="AUDIO_U16LSB" /></term>
			///                 <description>Unsigned 16-bit little-endian samples</description>
			///             </item>
			///             <item>
			///                 <term><see cref="AUDIO_S16"/> <see cref="AUDIO_S16LSB" /></term>
			///                 <description>Signed 16-bit little-endian samples</description>
			///             </item>
			///             <item>
			///                 <term><see cref="AUDIO_U16MSB" /></term>
			///                 <description>Unsigned 16-bit big-endian samples</description>
			///             </item>
			///             <item>
			///                 <term><see cref="AUDIO_S16MSB" /></term>
			///                 <description>Signed 16-bit big-endian samples</description>
			///             </item>
			///             <item>
			///                 <term><see cref="AUDIO_U16SYS" /></term>
			///                 <description>Either AUDIO_U16LSB or 
			///                 AUDIO_U16MSB depending on you systems endianness
			///                 </description>
			///             </item>
			///             <item>
			///                 <term><see cref="AUDIO_S16SYS" /></term>
			///                 <description>Either AUDIO_S16LSB or 
			///                 AUDIO_S16MSB depending on you systems endianness
			///					</description>
			///             </item>
			///         </list>
			/// </remarks>
			public short format;		
			/// <summary>
			/// Number of channels: 1 mono, 2 stereo.
			/// </summary>
			/// <remarks>
			/// The number of seperate sound channels. 
			/// 1 is mono (single channel), 2 is stereo (dual channel).
			/// </remarks>
			public byte  channels;
			/// <summary>
			/// Audio buffer silence value (calculated).
			/// </summary>
			public byte  silence;	
			/// <summary>
			/// Audio buffer size in samples.
			/// </summary>
			/// <remarks>
			/// When used with <see cref="SDL_OpenAudio"/> this refers 
			/// to the size of the 
			/// audio buffer in samples. A sample a chunk of audio data
			///  of the size specified in format mulitplied by the number
			///   of channels. When the SDL_AudioSpec is used with 
			///   <see cref="SDL_LoadWAV"/> samples is set to 4096.
			/// </remarks>
			public short samples;
			/// <summary>
			/// Necessary for some compile environments. Should not be used
			/// </summary>
			public short padding;		
			/// <summary>
			/// Audio buffer size in bytes (calculated)
			/// </summary>
			public int size;		
			/// <summary>
			/// Callback function for filling the audio buffer
			/// This function is called when the audio device needs more data.
			/// 'stream' is a pointer to the audio data buffer
			/// 'len' is the length of that buffer in bytes.
			/// Once the callback returns, the buffer will no longer be valid.
			/// Stereo samples are stored in a LRLRLR ordering.
			/// </summary>
			/// <param name="userdata"></param>
			/// <param name="stream"></param>
			/// <param name="len"></param>
			public delegate void callback(
				IntPtr userdata, 
				byte[] stream, int len);
			/// <summary>
			/// Pointer the user data which is passed to the callback function
			/// </summary>
			public object userdata;
		}
		#endregion SDL_AudioSpec

		#region SDL_AudioCVT
		/// <summary>
		/// Audio Conversion Structure
		/// </summary>
		/// <remarks>
		/// The SDL_AudioCVT is used to convert audio data between different 
		/// formats. A SDL_AudioCVT structure is created with the 
		/// <see cref="SDL_BuildAudioCVT"/> function, while the actual
		///  conversion is done by the SDL_ConvertAudio function.
		/// <p>Many of the fields in the <see cref="SDL_AudioCVT"/> 
		/// structure should be considered private and their function
		///  will not be discussed here.</p>
		///  <p>
		///  <code>
		///  typedef struct{
		///		int needed;
		///		Uint16 src_format;
		///		Uint16 dest_format;
		///		double rate_incr;
		///		Uint8 *buf;
		///		int len;
		///		int len_cvt;
		///		int len_mult;
		///		double len_ratio;
		///		void (*filters[10])(struct SDL_AudioCVT *cvt, Uint16 format);
		///								int filter_index;
		///							} SDL_AudioCVT;
		///  </code></p>
		/// </remarks>
		/// <seealso cref="SDL_BuildAudioCVT"/>
		/// <seealso cref="SDL_ConvertAudio"/>
		/// <seealso cref="SDL_AudioSpec"/>
		public struct SDL_AudioCVT 
		{
			/// <summary>
			/// Set to 1 if conversion possible
			/// </summary>
			public int needed;			
			/// <summary>
			/// Audio format of the source
			/// </summary>
			public short src_format;		
			/// <summary>
			/// Audio format of the destination
			/// </summary>
			public short dst_format;		
			/// <summary>
			/// Rate conversion increment
			/// </summary>
			public double rate_incr;	
			/// <summary>
			/// Buffer to hold entire audio data
			/// </summary>
			/// <remarks>
			/// This points to the audio data that will be used in the 
			/// conversion. It is both the source and the destination, 
			/// which means the converted audio data overwrites the original
			///  data. It also means that the converted data may be larger 
			///  than the original data (if you were converting from 8-bit
			///   to 16-bit, for instance), so you must ensure buf is large
			///    enough. See below.
			/// <p>IntPtr to byte</p>
			/// </remarks>
			public IntPtr buf;		
			/// <summary>
			/// Length of original audio buffer in bytes
			/// </summary>
			public int    len;			
			/// <summary>
			/// Length of converted audio buffer in bytes (calculated)
			/// </summary>
			/// <remarks>
			/// This is the length of the original audio data in bytes.
			/// </remarks>
			public int    len_cvt;	
			/// <summary>
			/// buf must be len*len_mult bytes in size(calculated)
			/// </summary>
			/// <remarks>
			/// As explained above, the audio buffer needs to be big enough 
			/// to store the converted data, which may be bigger than the 
			/// original audio data. The length of buf should be len*len_mult.
			/// </remarks>
			public int    len_mult;	
			/// <summary>
			/// Final audio size is len*len_ratio
			/// </summary>
			/// <remarks>
			/// When you have finished converting your audio data, you need 
			/// to know how much of your audio buffer is valid. len*len_ratio
			///  is the size of the converted audio data in bytes. This is 
			///  very similar to len_mult, however when the convert audio 
			///  data is shorter than the original len_mult would be 1. 
			///  len_ratio, on the other hand, would be a fractional 
			///  number between 0 and 1.
			/// </remarks>
			public double len_ratio; 	
			
			//Pointers to functions needed for this conversion
			//public void (*filters[10])(IntPtr cvt, short format);

			/// <summary>
			/// Current audio conversion function
			/// </summary>
			public int filter_index;
		}
		#endregion SDL_AudioCVT
		#endregion SDL_audio.h

		// SDL_byteorder.h -- none

		#region SDL_cdrom.h
		#region SDL_CDtrack
		/// <summary>
		/// CD Track Information Structure
		/// </summary>
		/// <remarks>
		/// SDL_CDtrack stores data on each track on a CD, 
		/// its fields should be pretty self explainatory.
		/// It is a member a the <see cref="SDL_CD"/> structure.
		/// <p>Note: Frames can be converted to standard timings.
		/// There are CD_FPS frames per second, 
		/// so SDL_CDtrack.length/CD_FPS=length_in_seconds.</p>
		/// <p>Struct in SDL_cdrom.h
		/// <code>
		/// typedef struct{
		/// Uint8 id;
		/// Uint8 type;
		/// Uint32 length;
		/// Uint32 offset;
		/// } SDL_CDtrack;
		/// </code></p>
		/// </remarks>
		/// <seealso cref="SDL_CD"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_CDtrack 
		{
			/// <summary>
			/// Track number(0-99)
			/// </summary>
			public byte id;
			/// <summary>
			/// Data or audio track
			/// </summary>
			/// <remarks>
			/// SDL_AUDIO_TRACK or SDL_DATA_TRACK
			/// </remarks>
			public byte type;
			/// <summary>
			/// Unused
			/// </summary>
			public short unused;
			/// <summary>
			/// Length, in frames, of this track
			/// </summary>
			public int length;
			/// <summary>
			/// Offset, in frames, from start of disk
			/// </summary>
			public int offset;
		}
		#endregion SDL_CDtrack

		#region SDL_CD
		/// <summary>
		/// CDROM Drive Information.
		/// </summary>
		/// <remarks>
		/// An SDL_CD structure is returned by <see cref="SDL_CDOpen"/>.
		///  It represents an
		///  opened CDROM device and stores information on the layout of the
		///   tracks on the disc.
		/// <p>A frame is the base data unit of a CD. CD_FPS frames is equal
		///  to 1 second of music. SDL provides two macros for converting
		///   between time and frames: FRAMES_TO_MSF(f, M,S,F) and 
		///   MSF_TO_FRAMES.</p>
		/// <p>Struct from SDL_cdrom.h
		/// <code>
		/// typedef struct{
		/// int id;
		/// CDstatus status;
		/// int numtracks;
		/// int cur_track;
		/// int cur_frame;
		/// SDL_CDtrack track[SDL_MAX_TRACKS+1];
		/// } SDL_CD;
		/// </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// int min, sec, frame;
		///		int frame_offset;
		///
		///		FRAMES_TO_MSF(cdrom-&gt;cur_frame, &amp;min, &amp;sec, &amp;frame);
		///		printf("Current Position: %d minutes, %d seconds, %d frames\n", min, sec, frame);
		///
		///		frame_offset=MSF_TO_FRAMES(min, sec, frame);
		/// </code>
		/// </example>
		/// <seealso cref="SDL_CDOpen"/>
		/// <seealso cref="SDL_CDtrack"/>
		[StructLayout(LayoutKind.Sequential)]
			public class SDL_CD 
		{
			/// <summary>
			/// Private drive identifier
			/// </summary>
			public int id;
			/// <summary>
			/// Current drive status
			/// </summary>
			/// <remarks>
			/// SDL_CDStatus enum
			/// </remarks>
			public int status;
			/// <summary>
			/// Number of tracks on the CD
			/// </summary>
			public int numtracks;
			/// <summary>
			/// Current track
			/// </summary>
			public int cur_track;
			/// <summary>
			/// Current frame offset within current track
			/// </summary>
			public int cur_frame;
			/// <summary>
			/// Array of track descriptions. (see <see cref="SDL_CDtrack"/>)
			/// </summary>
			public SDL_CDTrackData track;
			/// <summary>
			/// 
			/// </summary>
			public SDL_CD()
			{
				track = new SDL_CDTrackData();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
			public class SDL_CDTrackData
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=Sdl.SDL_MAX_TRACKS*Sdl.BYTE_SIZE)]
			private byte[] trackData;
			/// <summary>
			/// 
			/// </summary>
			public Sdl.SDL_CDtrack this[int index]
			{
				get
				{
					if ( (index < 0) | (index >= Sdl.SDL_MAX_TRACKS))
					{
						throw new IndexOutOfRangeException();
					}

					Sdl.SDL_CDtrack track;
					GCHandle trackDataHandle = 
						GCHandle.Alloc(trackData, GCHandleType.Pinned);

					try
					{
						IntPtr trackDataBuffer = 
							trackDataHandle.AddrOfPinnedObject();
						trackDataBuffer = (IntPtr)(trackDataBuffer.ToInt32() + 
							(index * Marshal.SizeOf(typeof(Sdl.SDL_CDtrack))));
						track = (Sdl.SDL_CDtrack)Marshal.PtrToStructure(
							trackDataBuffer, typeof(Sdl.SDL_CDtrack));
					}
					finally
					{
						trackDataHandle.Free();
					}
					return track;
				}
			}
			/// <summary>
			/// 
			/// </summary>
			public SDL_CDTrackData()
			{
				trackData = new byte[Sdl.SDL_MAX_TRACKS*Marshal.SizeOf(typeof(Sdl.SDL_CDtrack))];
			}
		}



		#endregion SDL_CD
		#endregion SDL_cdrom.h

		// SDL_copying.h -- none
		// SDL_cpuinfo.h -- none
		// SDL_endian.h - skipped for now
		// SDL_error.h -- none

		#region SDL_events.h
		#region SDL_ActiveEvent
		/// <summary>
		/// Application visibility event structure.
		/// </summary>
		/// <remarks>
		/// SDL_ActiveEvent is a member of the <see cref="SDL_Event"/>
		///  union and is used when an event of type SDL_ACTIVEEVENT 
		///  is reported.
		/// <p>When the mouse leaves or enters the window area a 
		/// SDL_APPMOUSEFOCUS type activation event occurs, if the 
		/// mouse entered the window then gain will be 1, otherwise
		///  gain will be 0. A SDL_APPINPUTFOCUS type activation event
		///   occurs when the application loses or gains keyboard focus. 
		///   This usually occurs when another application is made active.
		///    Finally, a SDL_APPACTIVE type event occurs when the application
		///     is either minimised/iconified (gain=0) or restored.</p>
		/// <p>Note: This event does not occur when an application window is
		///  first created.</p>
		/// <p>Struct in SDL_events.h
		/// <code>
		/// typedef struct{
		/// Uint8 type;
		/// Uint8 gain;
		/// Uint8 state;
		/// } SDL_ActiveEvent;
		/// </code></p>
		/// </remarks>
		/// <seealso cref="SDL_Event"/>
		/// <seealso cref="SDL_GetAppState"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_ActiveEvent 
		{
			/// <summary>
			/// SDL_ACTIVEEVENT
			/// </summary>
			public byte type;
			/// <summary>
			/// 0 if the event is a loss or 1 if it is a gain.
			/// </summary>
			public byte gain;
			/// <summary>
			/// SDL_APPMOUSEFOCUS if mouse focus was gained or lost, 
			/// SDL_APPINPUTFOCUS if input focus was gained or lost, 
			/// or SDL_APPACTIVE if the application was iconified 
			/// (gain=0) or restored(gain=1).
			/// </summary>
			public byte state;
		}
		#endregion SDL_ActiveEvent
	
		#region SDL_KeyboardEvent
		/// <summary>
		/// Keyboard event structure
		/// </summary>
		/// <remarks>
		/// SDL_KeyboardEvent is a member of the <see cref="SDL_Event"/> union 
		/// and is used when an event of type SDL_KEYDOWN or SDL_KEYUP is 
		/// reported.
		/// <p>The type and state actually report the same information, 
		/// they just use different values to do it! A keyboard event occurs
		///  when a key is released (type=SDK_KEYUP or state=SDL_RELEASED) 
		///  and when a key is pressed (type=SDL_KEYDOWN or state=SDL_PRESSED).
		///   The information on what key was pressed or released is in the 
		///   <see cref="SDL_keysym"/> structure.</p>
		/// <p>Note: Repeating SDL_KEYDOWN events will occur if key repeat 
		/// is enabled (see <see cref="SDL_EnableKeyRepeat"/>).</p>
		/// <p>Struct in SDL_events.h
		/// <code>
		/// typedef struct{
		///		Uint8 type;
		///		Uint8 state;
		///		SDL_keysym keysym;
		///	} SDL_KeyboardEvent;
		/// </code></p>
		/// </remarks>
		/// <seealso cref="SDL_Event"/>
		/// <seealso cref="SDL_keysym"/>
		/// <seealso cref="SDL_EnableKeyRepeat"/>
		/// <seealso cref="SDL_EnableUNICODE"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_KeyboardEvent 
		{
			/// <summary>
			/// SDL_KEYDOWN or SDL_KEYUP
			/// </summary>
			public byte type;
			/// <summary>
			/// The keyboard device index
			/// </summary>
			public byte which;
			/// <summary>
			/// SDL_PRESSED or SDL_RELEASED
			/// </summary>
			public byte state;
			/// <summary>
			/// Contains key press information
			/// </summary>
			public SDL_keysym keysym;
		}
		#endregion SDL_KeyboardEvent
		
		#region SDL_MouseMotionEvent
		/// <summary>
		/// Mouse motion event structure
		/// </summary>
		/// <remarks>
		/// SDL_MouseMotionEvent is a member of the <see cref="SDL_Event"/>
		///  union and is 
		/// used when an event of type SDL_MOUSEMOTION is reported.
		/// <p>Simply put, a SDL_MOUSEMOTION type event occurs when a user
		/// moves the mouse within the application window or when 
		/// <see cref="SDL_WarpMouse"/>
		///  is called. Both the absolute (x and y) and relative (xrel and yrel
		///  ) coordinates are reported along with the current button states 
		///  (state). The button state can be interpreted using the SDL_BUTTON 
		///  macro (see <see cref="SDL_GetMouseState"/>).</p>
		/// <p>If the cursor is hidden (<see cref="SDL_ShowCursor"/>(0))
		///  and the input is 
		/// grabbed (<see cref="SDL_WM_GrabInput"/>(SDL_GRAB_ON)), 
		/// then the mouse will give
		///  relative motion events even when the cursor reaches the edge fo 
		///  the screen. This is currently only implemented on Windows and 
		///  Linux/Unix-a-likes.</p>
		/// <p>Struct in SDL_events.h
		/// <code>
		/// typedef struct{
		///		Uint8 type;
		///		Uint8 which;
		///		Uint8 state;
		///		Uint16 x, y;
		///		Sint16 xrel, yrel;
		///	} SDL_MouseMotionEvent;
		/// </code></p>
		/// </remarks>
		/// <seealso cref="SDL_Event"/>
		/// <seealso cref="SDL_MouseButtonEvent"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_MouseMotionEvent 
		{
			/// <summary>
			/// SDL_MOUSEMOTION
			/// </summary>
			public byte type;
			/// <summary>
			/// The mouse device index
			/// </summary>
			public byte which;
			/// <summary>
			/// The current button state
			/// </summary>
			public byte state;
			/// <summary>
			/// The X coordinate of the mouse
			/// </summary>
			public short x;
			/// <summary>
			/// The Y coordinate of the mouse
			/// </summary>
			public short y;
			/// <summary>
			/// The relative motion in the X direction
			/// </summary>
			public short xrel;
			/// <summary>
			/// The relative motion in the Y direction
			/// </summary>
			public short yrel;
		}
		#endregion SDL_MouseMotionEvent
		
		#region SDL_MouseButtonEvent
		/// <summary>
		/// Mouse button event structure
		/// </summary>
		/// <remarks>
		/// SDL_MouseButtonEvent is a member of the <see cref="SDL_Event"/>
		///  union and is used when an event of type SDL_MOUSEBUTTONDOWN or
		///   SDL_MOUSEBUTTONUP is reported.
		/// <p>When a mouse button press or release is detected then number
		///  of the button pressed (from 1 to 255, with 1 usually being the
		///   left button and 2 the right) is placed into button, the position
		///    of the mouse when this event occured is stored in the x and the
		///     y fields. Like <see cref="SDL_KeyboardEvent"/>, information on
		///      whether the event was a press or a release event is stored in
		///       both the type and state fields, but this should be obvious.
		///       </p>
		///       <p>Struct in SDL_events.h
		/// <code>
		/// typedef struct{
		///		Uint8 type;
		///		Uint8 button;
		///		Uint8 state;
		///		Uint16 x, y;
		///	} SDL_MouseButtonEvent;
		/// </code>
		/// </p>
		/// </remarks>
		/// <seealso cref="SDL_Event"/>
		/// <seealso cref="SDL_MouseMotionEvent"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_MouseButtonEvent 
		{
			/// <summary>
			/// SDL_MOUSEBUTTONDOWN or SDL_MOUSEBUTTONUP
			/// </summary>
			public byte type;
			/// <summary>
			/// The mouse device index 
			/// </summary>
			public byte which;
			/// <summary>
			/// The mouse button index (SDL_BUTTON_LEFT, 
			/// SDL_BUTTON_MIDDLE, SDL_BUTTON_RIGHT)
			/// </summary>
			public byte button;
			/// <summary>
			/// SDL_PRESSED or SDL_RELEASED 
			/// </summary>
			public byte state;
			/// <summary>
			/// The X coordinate of the mouse at press/release time
			/// </summary>
			public short x;
			/// <summary>
			/// The Y coordinate of the mouse at press/release time
			/// </summary>
			public short y;
		}
		#endregion SDL_MouseButtonEvent
		
		#region SDL_JoyAxisEvent
		/// <summary>
		/// Joystick axis motion event structure
		/// </summary>
		/// <remarks>
		/// SDL_JoyAxisEvent is a member of the <see cref="SDL_Event"/> union
		///  and is used when an event of type SDL_JOYAXISMOTION is reported.
		/// <p>A SDL_JOYAXISMOTION event occurs when ever a user moves an 
		/// axis on the joystick. The field which is the index of the 
		/// joystick that reported the event and axis is the index of the 
		/// axis (for a more detailed explaination see the Joystick section).
		///  value is the current position of the axis.</p>
		/// <p>
		/// <code>Struct in SDL_cdrom.h
		/// typedef struct{
		///		Uint8 type;
		///		Uint8 which;
		///		Uint8 axis;
		///		Sint16 value;
		///	} SDL_JoyAxisEvent;
		/// </code></p>
		/// </remarks>
		/// <seealso cref="SDL_Event"/>
		/// <seealso cref="SDL_JoystickEventState"/>
		/// <seealso cref="SDL_JoystickGetAxis"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_JoyAxisEvent 
		{
			/// <summary>
			/// SDL_JOYAXISMOTION
			/// </summary>
			public byte type;
			/// <summary>
			/// The joystick device index
			/// </summary>
			public byte which;
			/// <summary>
			/// Joystick axis index
			/// </summary>
			public byte axis;
			/// <summary>
			/// Axis value (range: -32768 to 32767)
			/// </summary>
			public short val;
		}
		#endregion SDL_JoyAxisEvent
		
		#region SDL_JoyBallEvent
		/// <summary>
		/// Joystick trackball motion event structure
		/// </summary>
		/// <remarks>
		/// SDL_JoyBallEvent is a member of the <see cref="SDL_Event"/> union 
		/// and is used when an event of type SDL_JOYBALLMOTION is reported.
		/// <p>A SDL_JOYBALLMOTION event occurs when a user moves a trackball
		///  on the joystick. The field which is the index of the joystick 
		///  that reported the event and ball is the index of the trackball
		///   (for a more detailed explaination see the Joystick section). 
		///   Trackballs only return relative motion, this is the change 
		///   in position on the ball since it was last polled (last cycle 
		///   of the event loop) and it is stored in xrel and yrel.</p>
		/// <p>Struct in SDL_events.h
		/// <code>
		/// typedef struct{
		///		Uint8 type;
		///		Uint8 which;
		///		Uint8 ball;
		///		Sint16 xrel, yrel;
		///	} SDL_JoyBallEvent;
		/// </code></p></remarks>
		/// <seealso cref="SDL_Event"/>
		/// <seealso cref="SDL_JoystickEventState"/>
		/// <seealso cref="SDL_JoystickGetBall"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_JoyBallEvent 
		{
			/// <summary>
			/// SDL_JOYBALLMOTION
			/// </summary>
			public byte type;
			/// <summary>
			/// The joystick device index
			/// </summary>
			public byte which;
			/// <summary>
			/// The joystick trackball index
			/// </summary>
			public byte ball;
			/// <summary>
			/// The relative motion in the X direction
			/// </summary>
			public short xrel;
			/// <summary>
			/// The relative motion in the Y direction
			/// </summary>
			public short yrel;
		}
		#endregion SDL_JoyBallEvent
		
		#region SDL_JoyHatEvent
		/// <summary>
		/// Joystick hat position change event structure
		/// </summary>
		/// <remarks>
		/// SDL_JoyHatEvent is a member of the <see cref="SDL_Event"/> union 
		/// and is used when an event of type SDL_JOYHATMOTION is reported.
		/// <p>A SDL_JOYHATMOTION event occurs when ever a user moves a hat 
		/// on the joystick. The field which is the index of the joystick that
		///  reported the event and hat is the index of the hat (for a more 
		///  detailed exlaination see the Joystick section). value is the 
		///  current position of the hat. It is a logically OR'd combination 
		///  of the following values (whose meanings should be pretty 
		///  obvious:) :</p>
		/// <p>SDL_HAT_CENTERED</p> 
		/// <p>SDL_HAT_UP</p> 
		///	<p>SDL_HAT_RIGHT</p>
		///	<p>SDL_HAT_DOWN</p> 
		///	<p>SDL_HAT_LEFT</p> 
		///	<p>The following defines are also provided:</p>
		///	<p>SDL_HAT_RIGHTUP</p>
		///	<p>SDL_HAT_RIGHTDOWN</p>
		///	<p>SDL_HAT_LEFTUP</p> 
		///	<p>SDL_HAT_LEFTDOWN</p>
		/// <p>Struct from SDL_events.h
		/// <code>
		/// typedef struct{
		///		Uint8 type;
		///		Uint8 which;
		///		Uint8 hat;
		///		Uint8 value;
		///	} SDL_JoyHatEvent;
		/// </code></p></remarks>
		/// <seealso cref="SDL_Event"/>
		/// <seealso cref="SDL_JoystickEventState"/>
		/// <seealso cref="SDL_JoystickGetHat"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_JoyHatEvent 
		{
			/// <summary>
			/// SDL_JOYHATMOTION
			/// </summary>
			public byte type;
			/// <summary>
			/// The joystick device index
			/// </summary>
			public byte which;
			/// <summary>
			/// The joystick hat index
			/// </summary>
			public byte hat;
			/// <summary>
			/// The hat position value:
			///  <p><code>SDL_HAT_LEFTUP   SDL_HAT_UP       SDL_HAT_RIGHTUP
			///  SDL_HAT_LEFT     SDL_HAT_CENTERED SDL_HAT_RIGHT
			///  SDL_HAT_LEFTDOWN SDL_HAT_DOWN     SDL_HAT_RIGHTDOWN</code></p>
			/// Note that zero means the POV is centered.
			/// </summary>
			public byte val;
		}
		#endregion SDL_JoyHatEvent
		
		#region SDL_JoyButtonEvent
		/// <summary>
		/// Joystick button event structure
		/// </summary>
		/// <remarks>
		/// SDL_JoyButtonEvent is a member of the <see cref="SDL_Event"/> 
		/// union and is used when an event of type SDL_JOYBUTTONDOWN or 
		/// SDL_JOYBUTTONUP is reported.
		/// <p>A SDL_JOYBUTTONDOWN or SDL_JOYBUTTONUP event occurs when ever 
		/// a user presses or releases a button on a joystick. The field which
		///  is the index of the joystick that reported the event and button 
		///  is the index of the button (for a more detailed explaination see
		///   the Joystick section). state is the current state or the button
		///    which is either SDL_PRESSED or SDL_RELEASED.</p>
		/// <p>Struct from SDL_events.h
		/// <code>
		/// typedef struct{
		///		Uint8 type;
		///		Uint8 which;
		///		Uint8 button;
		///		Uint8 state;
		///	} SDL_JoyButtonEvent;
		/// </code></p></remarks>
		/// <seealso cref="SDL_Event"/>
		/// <seealso cref="SDL_JoystickEventState"/>
		/// <seealso cref="SDL_JoystickGetButton"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_JoyButtonEvent 
		{
			/// <summary>
			/// SDL_JOYBUTTONDOWN or SDL_JOYBUTTONUP
			/// </summary>
			public byte type;
			/// <summary>
			/// The joystick device index 
			/// </summary>
			public byte which;
			/// <summary>
			/// The joystick button index
			/// </summary>
			public byte button;
			/// <summary>
			/// SDL_PRESSED or SDL_RELEASED
			/// </summary>
			public byte state;
		}
		#endregion SDL_JoyButtonEvent
		
		#region SDL_ResizeEvent
		/// <summary>
		/// Window resized event
		/// </summary>
		/// <remarks>
		/// SDL_ResizeEvent is a member of the <see cref="SDL_Event"/> union 
		/// and is used when an event of type SDL_VIDEORESIZE is reported.
		/// <p>When SDL_RESIZABLE is passed as a flag to 
		/// <see cref="SDL_SetVideoMode"/> the user is allowed to resize the
		///  applications window. When the window is resized an 
		///  SDL_VIDEORESIZE is report, with the new window width and height
		///   values stored in w and h, respectively. When an SDL_VIDEORESIZE
		///    is recieved the window should be resized to the new dimensions
		///     using <see cref="SDL_SetVideoMode"/>.</p>
		/// <p>Struct in SDL_events.h
		/// <code>
		/// typedef struct{
		///		Uint8 type;
		///		int w, h;
		///	} SDL_ResizeEvent;
		/// </code></p></remarks>
		/// <seealso cref="SDL_Event"/>
		/// <seealso cref="SDL_SetVideoMode"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_ResizeEvent 
		{
			/// <summary>
			/// SDL_VIDEORESIZE
			/// </summary>
			public byte type;
			/// <summary>
			/// New width of the window
			/// </summary>
			public int w;
			/// <summary>
			/// New height of the window
			/// </summary>
			public int h;
		}
		#endregion SDL_ResizeEvent
		
		#region SDL_ExposeEvent
		/// <summary>
		/// Screen redraw event
		/// </summary>
		/// <remarks>
		/// SDL_ExposeEvent is a member of the <see cref="SDL_Event"/> union 
		/// and is used whan an event of type SDL_VIDEOEXPOSE is reported.
		/// <p>A VIDEOEXPOSE event is triggered when the screen has been 
		/// modified outside of the application, usually by the window 
		/// manager and needs to be redrawn.</p>
		/// <p>Struct in SDL_events.h
		/// <code>
		/// typedef struct{
		///		Uint8 type
		///		} SDL_ExposeEvent;
		/// </code>
		/// </p>
		/// </remarks>
		/// <seealso cref="SDL_Event"/>
		/// <seealso cref="SDL_SetEventFilter"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_ExposeEvent 
		{
			/// <summary>
			/// SDL_VIDEOEXPOSE
			/// </summary>
			public byte type;
		}
		#endregion SDL_ExposeEvent
		
		#region SDL_QuitEvent
		/// <summary>
		/// Quit requested event
		/// </summary>
		/// <remarks>
		/// SDL_QuitEvent is a member of the <see cref="SDL_Event"/> union 
		/// and is used whan an event of type SDL_QUIT is reported.
		/// <p>As can be seen, the SDL_QuitEvent structure serves no useful 
		/// purpose. The event itself, on the other hand, is very important.
		///  If you filter out or ignore a quit event then it is impossible 
		///  for the user to close the window. On the other hand, if you do 
		///  accept a quit event then the application window will be closed,
		///   and screen updates will still report success event though the 
		///   application will no longer be visible.</p>
		/// <p>Note: The macro SDL_QuitRequested will return non-zero if a 
		/// quit event is pending</p>
		/// <p>Struct in SDL_events.h
		/// <code>
		/// typedef struct{
		///		Uint8 type
		///		} SDL_QuitEvent;
		/// </code></p></remarks>
		/// <seealso cref="SDL_Event"/>
		/// <seealso cref="SDL_SetEventFilter"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_QuitEvent 
		{
			/// <summary>
			/// SDL_QUIT
			/// </summary>
			public byte type;
		}
		#endregion SDL_QuitEvent
		
		#region SDL_UserEvent
		/// <summary>
		/// A user-defined event type
		/// </summary>
		/// <remarks>
		/// SDL_UserEvent is in the user member of the structure 
		/// <see cref="SDL_Event"/>. This event is unique, it is never created
		///  by SDL but only by the user. The event can be pushed onto the 
		///  event queue using <see cref="SDL_PushEvent"/>. 
		///  The contents of the structure 
		///  members or completely up to the programmer, the only requirement
		///   is that type is a value from SDL_USEREVENT to SDL_NUMEVENTS-1 
		///   (inclusive).
		/// <p>Struct in SDL_events.h
		/// <code>
		/// typedef struct{
		///		Uint8 type;
		///		int code;
		///		void *data1;
		///		void *data2;
		///	} SDL_UserEvent;
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// SDL_Event event;
		///
		///		event.type = SDL_USEREVENT;
		///		event.user.code = my_event_code;
		///		event.user.data1 = significant_data;
		///		event.user.data2 = 0;
		///		SDL_PushEvent(&amp;event);
		/// </code>
		/// 
		/// </example>
		/// <seealso cref="SDL_Event"/>
		/// <seealso cref="SDL_PushEvent"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_UserEvent 
		{
			/// <summary>
			/// SDL_USEREVENT through SDL_NUMEVENTS-1
			/// </summary>
			public byte type;
			/// <summary>
			/// User defined event code
			/// </summary>
			public int code;
			/// <summary>
			/// User defined data pointer
			/// </summary>
			public IntPtr data1;
			/// <summary>
			/// User defined data pointer
			/// </summary>
			public IntPtr data2;
		}
		#endregion SDL_UserEvent

		#region SDL_SysWMEvent
		/// <summary>
		/// Platform-dependent window manager event.
		/// </summary>
		/// <remarks>
		/// The system window manager event contains a pointer to 
		/// system-specific information about unknown window manager events.
		///  If you enable this event using <see cref="SDL_EventState"/>, 
		///  it will be generated whenever unhandled events are received from
		///   the window manager. This can be used, for example, to implement
		///    cut-and-paste in your application.
		///    <p>
		///    If you want to obtain system-specific information about the 
		///    window manager, you can fill the version member of a 
		///    SDL_SysWMinfo structure (details can be found in SDL_syswm.h,
		///     which must be included) using the SDL_VERSION() macro found
		///      in SDL_version.h, and pass it to the function:
		///    </p>
		///    <p><code>int SDL_GetWMInfo(SDL_SysWMinfo *info);</code></p>
		/// <p>Struct from SDL_events.h
		/// <code>
		/// typedef struct {
		///		Uint8 type;   /* Always SDL_SYSWMEVENT */
		///		SDL_SysWMmsg *msg;
		/// } SDL_SysWMEvent;
		/// </code>
		/// </p></remarks>
		/// <seealso cref="SDL_EventState"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_SysWMEvent 
		{
			/// <summary>
			/// 
			/// </summary>
			public byte type;
			/// <summary>
			/// IntPtr to SDL_SysWMmsg
			/// </summary>
			public IntPtr msg;
		}
		#endregion SDL_SysWMEvent

		#region SDL_Event
		/// <summary>
		/// General event structure
		/// </summary>
		/// <remarks>
		/// The SDL_Event union is the core to all event handling is SDL,
		///  its probably the most important structure after SDL_Surface.
		///   SDL_Event is a union of all event structures used in SDL, 
		///   using it is a simple matter of knowing which union member
		///    relates to which event type.
		/// <list type="table">
		///             <listheader>
		///                 <term>Event type</term>
		///                 <description>Event Structure</description>
		///             </listheader>
		///             <item>
		///                 <term>SDL_ACTIVEEVENT</term>
		///                 <description><see cref="SDL_ActiveEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_KEYDOWN</term>
		///                 <description><see cref="SDL_KeyboardEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_KEYUP</term>
		///                 <description><see cref="SDL_KeyboardEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_MOUSEMOTION</term>
		///                 <description><see cref="SDL_MouseMotionEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_MOUSEBUTTONDOWN</term>
		///                 <description><see cref="SDL_MouseButtonEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_MOUSEBUTTONUP</term>
		///                 <description><see cref="SDL_MouseButtonEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_JOYAXISMOTION</term>
		///                 <description><see cref="SDL_JoyAxisEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_JOYBALLMOTION</term>
		///                 <description><see cref="SDL_JoyBallEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_JOYHATMOTION</term>
		///                 <description><see cref="SDL_JoyHatEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_JOYBUTTONDOWN</term>
		///                 <description><see cref="SDL_JoyButtonEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_JOYBUTTONUP</term>
		///                 <description><see cref="SDL_JoyButtonEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_QUIT</term>
		///                 <description><see cref="SDL_QuitEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_SYSWMEVENT</term>
		///                 <description><see cref="SDL_SysWMEvent"/></description>
		///             </item> 
		///             <item>
		///                 <term>SDL_VIDEORESIZE</term>
		///                 <description><see cref="SDL_ResizeEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_VIDEOEXPOSE</term>
		///                 <description><see cref="SDL_ExposeEvent"/></description>
		///             </item>
		///             <item>
		///                 <term>SDL_USEREVENT</term>
		///                 <description><see cref="SDL_UserEvent"/></description>
		///             </item>
		///         </list>	
		/// <p>
		/// The SDL_Event structure has two uses
		/// <p>Reading events on the event queue</p>
		/// <p>Placing events on the event queue</p>
		/// <p>Reading events from the event queue is done with either
		///  <see cref="SDL_PollEvent"/> or <see cref="SDL_PeepEvents"/>.
		///   We'll use SDL_PollEvent and step through an example.</p>
		/// <p>First off, we create an empty SDL_Event structure.</p> 
		/// <p><code>SDL_Event test_event;</code></p>
		/// <p>SDL_PollEvent removes the next event from the event queue, if 
		/// there are no events on the queue it returns 0 otherwise it returns 
		/// 1. We use a while loop to process each event in turn.</p>
		/// <p><code>while(SDL_PollEvent(&amp;test_event)) { </code></p>
		/// <p>The SDL_PollEvent function take a pointer to an SDL_Event 
		/// structure that is to be filled with event information. We know
		///  that if SDL_PollEvent removes an event from the queue then the
		///   event information will be placed in our test_event structure, 
		///   but we also know that the type of event will be placed in the 
		///   type member of test_event. So to handle each event type 
		///   seperately we use a switch statement.</p>
		/// <p><code> switch(test_event.type) { </code></p>
		/// <p>We need to know what kind of events we're looking for and the
		///  event type's of those events. So lets assume we want to detect 
		///  where the user is moving the mouse pointer within our application.
		///   We look through our event types and notice that SDL_MOUSEMOTION 
		///   is, more than likely, the event we're looking for. A little more
		///    research tells use that SDL_MOUSEMOTION events are handled 
		///    within the <see cref="SDL_MouseMotionEvent"/> 
		///    structure which is the motion
		///     member of SDL_Event. We can check for the SDL_MOUSEMOTION 
		///     event type within our switch statement like so: </p>
		/// <p><code>case SDL_MOUSEMOTION:</code></p>
		/// <p>All we need do now is read the information out of the 
		/// motion member of test_event.</p> 
		/// <code>
		///		printf("We got a motion event.\n");
		///		printf("Current mouse position is: (%d, %d)\n", test_event.motion.x, test_event.motion.y);
		///		break;
		///		default:
		///		printf("Unhandled Event!\n");
		///		break;
		///	}
		/// }
		/// printf("Event queue empty.\n");</code>
		/// <p>It is also possible to push events onto the event queue 
		/// and so use it as a two-way communication path. Both 
		/// <see cref="SDL_PushEvent"/> and <see cref="SDL_PeepEvents"/>
		///  allow you to place events onto the event queue. This is 
		///  usually used to place a SDL_USEREVENT on the event queue,
		///   however you could use it to post fake input events if you 
		///   wished. Creating your own events is a simple matter of 
		///   choosing the event type you want, setting the type member 
		///   and filling the appropriate member structure with information.
		///   </p><p>
		/// <code>
		///SDL_Event user_event;
		///
		///user_event.type=SDL_USEREVENT;
		///user_event.user.code=2;
		///user_event.user.data1=NULL;
		///user_event.user.data2=NULL;
		///SDL_PushEvent(&amp;user_event);
		///</code>
		/// </p>	   
		/// <p>Union from SDL_events.h
		/// <code>
		/// typedef union{
		///		Uint8 type;
		///		SDL_ActiveEvent active;
		///		SDL_KeyboardEvent key;
		///		SDL_MouseMotionEvent motion;
		///		SDL_MouseButtonEvent button;
		///		SDL_JoyAxisEvent jaxis;
		///		SDL_JoyBallEvent jball;
		///		SDL_JoyHatEvent jhat;
		///		SDL_JoyButtonEvent jbutton;
		///		SDL_ResizeEvent resize;
		///		SDL_ExposeEvent expose;
		///		SDL_QuitEvent quit;
		///		SDL_UserEvent user;
		///		SDL_SywWMEvent syswm;
		///	} SDL_Event;
		/// </code></p></p></remarks>
		/// <seealso cref="SDL_PollEvent"/>
		/// <seealso cref="SDL_PushEvent"/>
		/// <seealso cref="SDL_PeepEvents"/>
		[StructLayout(LayoutKind.Explicit)]
			public struct SDL_Event 
		{
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public byte type;
			/// <summary>
			/// Activation event
			/// </summary>
			[FieldOffset(0)]
			public SDL_ActiveEvent active;
			/// <summary>
			/// Keyboard event
			/// </summary>
			[FieldOffset(0)]
			public SDL_KeyboardEvent key;
			/// <summary>
			/// Mouse motion event
			/// </summary>
			[FieldOffset(0)]
			public SDL_MouseMotionEvent motion;
			/// <summary>
			/// Mouse button event
			/// </summary>
			[FieldOffset(0)]
			public SDL_MouseButtonEvent button;
			/// <summary>
			/// Joystick axis event
			/// </summary>
			[FieldOffset(0)]
			public SDL_JoyAxisEvent jaxis;
			/// <summary>
			/// Joystick trackbell event
			/// </summary>
			[FieldOffset(0)]
			public SDL_JoyBallEvent jball;
			/// <summary>
			/// Joystick hat motion event
			/// </summary>
			[FieldOffset(0)]
			public SDL_JoyHatEvent jhat;
			/// <summary>
			/// Joystick button event
			/// </summary>
			[FieldOffset(0)]
			public SDL_JoyButtonEvent jbutton;
			/// <summary>
			/// Application window resize event
			/// </summary>
			[FieldOffset(0)]
			public SDL_ResizeEvent resize;
			/// <summary>
			/// Application window expose event
			/// </summary>
			[FieldOffset(0)]
			public SDL_ExposeEvent expose;
			/// <summary>
			/// Quit request event
			/// </summary>
			[FieldOffset(0)]
			public SDL_QuitEvent quit;
			/// <summary>
			/// User defined event
			/// </summary>
			[FieldOffset(0)]
			public SDL_UserEvent user;
			/// <summary>
			/// Undefined window manager event
			/// </summary>
			[FieldOffset(0)]
			public SDL_SysWMEvent syswm;
		}
		#endregion SDL_Event
		
		#endregion SDL_events.h

		// SDL_getenv.h -- none

		#region SDL_joystick.h
		#region SDL_Joystick
		///<summary>
		/// TODO. This needs work.
		///</summary>
		///<remarks>
		///<p>
		///		<code>
		///		struct _SDL_Joystick 
		///		{
		///			Uint8 index;		/* Device index */
		///			const char *name;	/* Joystick name - system dependent */
		///			int naxes;		/* Number of axis controls on the joystick */
		///			Sint16 *axes;		/* Current axis states */
		///			int nhats;		/* Number of hats on the joystick */
		///			Uint8 *hats;		/* Current hat states */
		///			int nballs;		/* Number of trackballs on the joystick */
		///			struct balldelta 
		///			{
		///				int dx;
		///				int dy;
		///			} *balls;		/* Current ball motion deltas */
		///			int nbuttons;		/* Number of buttons on the joystick */
		///			Uint8 *buttons;		/* Current button states */
		///			struct joystick_hwdata *hwdata;	/* Driver dependent information */
		///				int ref_count;		/* Reference count for multiple opens */
		///			}
		///			</code>
		///			</p>
		///			</remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_Joystick
		{
			/// <summary>
			/// Device index
			/// </summary>
			public byte index;
			/// <summary>
			/// Joystick name - system dependent
			/// </summary>
			public string name;
			/// <summary>
			/// Number of axis controls on the joystick
			/// </summary>
			public int naxes;
			/// <summary>
			/// Current axis states
			/// </summary>
			public IntPtr axes;
			/// <summary>
			/// Number of hats on the joystick
			/// </summary>
			/// <remarks>
			/// IntPtr to short
			/// </remarks>
			public int nhats;
			/// <summary>
			/// Current hat states
			/// </summary>
			public IntPtr hats;
			/// <summary>
			/// Number of trackballs on the joystick
			/// </summary>
			/// <remarks>
			/// IntPtr to byte
			/// </remarks>
			public int nballs;
			/// <summary>
			/// Current ball motion deltas
			/// </summary>
			/// <remarks>
			/// IntPtr to balldelta
			/// </remarks>
			public IntPtr balls;
			/// <summary>
			/// Number of buttons on the joystick
			/// </summary>
			public int nbuttons;
			/// <summary>
			/// Current button states
			/// </summary>
			/// <remarks>
			/// IntPtr to byte
			/// </remarks>
			public IntPtr buttons;
			/// <summary>
			/// Reference count for multiple opens
			/// </summary>
			/// <remarks>
			/// IntPtr to joystick_hwdata
			/// </remarks>
			public IntPtr hwdata;
		}
		#endregion SDL_Joystick

		#region balldelta
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct balldelta
		{
			/// <summary>
			/// 
			/// </summary>
			public int dx;
			/// <summary>
			/// 
			/// </summary>
			public int dy;
		}
		#endregion balldelta

		#region joystick_hwdata
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct joystick_hwdata
		{
			/// <summary>
			/// 
			/// </summary>
			public int ref_count;
		}
		#endregion joystick_hwdata
		#endregion SDL_joystick.h

		#region SDL_keyboard.h
		#region SDL_keysym
		/// <summary>
		/// The SDL_keysym structure describes a key press or a key release.
		/// </summary>
		/// <remarks>
		/// The SDL_keysym structure describes a key press or a key release. 
		/// The scancode field is hardware specific and should be ignored 
		/// unless you know what your doing. The sym field is the SDLKey 
		/// value of the key being pressed or released. The mod field 
		/// describes the state of the keyboard modifiers at the time the 
		/// key press or release occurred. So a value of KMOD_NUM | KMOD_CAPS
		///  | KMOD_LSHIFT would mean that Numlock, Capslock and the left shift
		///   key were all press (or enabled in the case of the lock keys). 
		///   Finally, the unicode field stores the 16-bit unicode value of 
		///   the key.
		///   <p>Note: It should be noted and understood that this field is
		///    only valid when the SDL_keysym is describing a key press, 
		///    not a key release. Unicode values only make sense on a key 
		///    press because the unicode value describes an international 
		///    character and only key presses produce characters. More 
		///    information on Unicode can be found at www.unicode.org</p>
		///   <p>Note: Unicode translation must be enabled using the 
		///   <see cref="SDL_EnableUNICODE"/> function.
		///   </p>
		///	<p>Struct in SDL_keyboard.h
		///	<code>
		///	typedef struct{
		///		Uint8 scancode;
		///		SDLKey sym;
		///		SDLMod mod;
		///		Uint16 unicode;
		///	} SDL_keysym;
		///	</code></p>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_keysym 
		{
			/// <summary>
			/// Hardware specific scancode.
			/// </summary>
			/// <remarks>
			/// The scancode is hardware dependent, 
			/// and should not be used by general
			/// applications.  
			/// If no hardware scancode is available, it will be 0.
			/// </remarks>
			public byte scancode;
			/// <summary>
			/// SDL virtual keysym.
			/// </summary>
			public int sym;
			/// <summary>
			/// Current key modifiers.
			/// </summary>
			public int mod;
			/// <summary>
			/// Translated character.
			/// </summary>
			/// <remarks>
			/// The 'unicode' translated character is only available 
			/// when character
			/// translation is enabled by the SDL_EnableUNICODE() API.  
			/// If non-zero,
			/// this is a UNICODE character corresponding to the keypress.  
			/// If the
			/// high 9 bits of the character are 0, 
			/// then this maps to the equivalent
			/// ASCII character:
			/// <p><code>
			/// 	char ch;
			///	if ( (keysym.unicode and 0xFF80) == 0 ) {
			///		ch = keysym.unicode and 0x7F;
			///	} else {
			///		An international character..
			///	}</code></p>
			/// </remarks>
			public short unicode;
		}
		#endregion SDL_keysym
		#endregion SDL_keyboard.h

		// SDL_keysym.h -- none
		// SDL_loadso.h -- skipped
		// SDL_main.h -- none

		#region SDL_mouse.h
		#region WMcursor
		/// <summary>
		/// Implementation dependent.
		/// TODO. Fix this.
		/// </summary>
		/// <remarks>
		/// <p>Struct in SDL_mouse.h
		/// <code>
		/// struct WMcursor WMcursor
		/// </code>
		/// </p>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct WMcursor 
		{
		}
		#endregion WMcursor

		#region SDL_Cursor
		/// <summary>
		/// Structure to hold cursor
		/// </summary>
		/// <remarks>
		/// <p>Struct in SDL_mouse.h
		/// <code>
		/// struct {
		///		SDL_Rect area;			/* The area of the mouse cursor */
		///		Sint16 hot_x, hot_y;		/* The "tip" of the cursor */
		///		Uint8 *data;			/* B/W cursor data */
		///		Uint8 *mask;			/* B/W cursor mask */
		///		Uint8 *save[2];			/* Place to save cursor area */
		///		WMcursor *wm_cursor;		/* Window-manager cursor */
		///	} SDL_Cursor
		/// </code>
		/// </p>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_Cursor 
		{
			/// <summary>
			/// The area of the mouse cursor
			/// </summary>
			public SDL_Rect area;
			/// <summary>
			/// The "tip" of the cursor
			/// </summary>
			public short hot_x;
			/// <summary>
			/// The "tip" of the cursor
			/// </summary>
			public short hot_y;
			/// <summary>
			/// B/W cursor data
			/// </summary>
			/// <remarks>
			/// IntPtr to byte
			/// </remarks>
			public IntPtr data;
			/// <summary>
			/// B/W cursor mask
			/// </summary>
			/// <remarks>
			/// IntPtr to byte
			/// </remarks>
			public IntPtr mask;
			/// <summary>
			/// Place to save cursor area
			/// </summary>
			/// <remarks>
			/// IntPtr to byte[2]
			/// </remarks>
			public IntPtr[] save;
			/// <summary>
			/// Window-manager cursor
			/// </summary>
			/// <remarks>
			/// IntPtr to WMcursor
			/// </remarks>
			public IntPtr WMcursor;
		}
		#endregion SDL_Cursor
		#endregion SDL_mouse.h

		// SDL_mutex.h -- Skipped. Superceded by System.Threading class
		// SDL_name.h -- none
		// SDL_opengl.h -- superceded by Tao.OpenGL
		// SDL_quit.h -- none
		// SDL_rwops -- skipped for now, might be useful.
		
		#region SDL_syswm.h
		#region SDL_SysWMmsg_Unix
		/// <summary>
		/// The UNIX custom event structure. TODO
		/// </summary>
		/// <remarks>
		/// <p>Struct in SDL_syswm.h
		/// <code>
		/// struct SDL_SysWMmsg {
		///		SDL_version version;
		///		SDL_SYSWM_TYPE subsystem;
		///		union 
		///		{
		///		XEvent xevent;
		/// 	} event;
		/// };		
		/// </code>
		/// </p>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_SysWMmsg_Unix
		{
			/// <summary>
			/// 
			/// </summary>
			public SDL_version version;
			/// <summary>
			/// 
			/// </summary>
			public int subsystem;
			//TODO
		}
		#endregion SDL_SysWMmsg_Unix

		#region SDL_SysWMinfo_Unix
		/// <summary>
		/// The UNIX custom window manager information structure. TODO
		/// </summary>
		/// <remarks>
		/// When this structure is returned, it holds information about which
		/// low level system it is using, and will be one of SDL_SYSWM_TYPE.
		/// <p>Struct in SDL_syswm.h
		/// <code>
		/// struct SDL_SysWMinfo {
		///		SDL_version version;
		///		SDL_SYSWM_TYPE subsystem;
		///		union 
		///		{
		///		struct 
		///		{
		///			Display *display;	/* The X11 display */
		///			Window window;		/* The X11 display window */
		///			/* These locking functions should be called around
		///					   any X11 functions using the display variable.
		///					   They lock the event thread, so should not be
		///			   called around event functions or from event filters.
		///			 */
		///			void (*lock_func)(void);
		///			void (*unlock_func)(void);
		///
		///			/* Introduced in SDL 1.0.2 */
		///			Window fswindow;	/* The X11 fullscreen window */
		///			Window wmwindow;	/* The X11 managed input window */
		///		} x11;
		///	 } info;
		/// } SDL_SysWMinfo;		
		/// </code>
		/// </p>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_SysWMinfo_Unix
		{
			/// <summary>
			/// 
			/// </summary>
			public SDL_version version;
			/// <summary>
			/// 
			/// </summary>
			public int subsystem;
		}
		#endregion SDL_SysWMinfo_Unix

		#region SDL_SysWMmsg_Windows
		/// <summary>
		/// The Windows custom event structure. TODO
		/// </summary>
		/// <remarks>
		/// <p>Struct in SDL_syswm.h
		/// <code>
		/// struct SDL_SysWMmsg {
		///	SDL_version version;
		///	HWND hwnd;
		///	UINT msg;
		///	WPARAM wParam;
		///	LPARAM lParam;
		/// };		
		/// </code>
		/// </p>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_SysWMmsg_Windows
		{
			/// <summary>
			/// 
			/// </summary>
			public SDL_version version;
			/// <summary>
			/// The window for the message
			/// </summary>
			public int hwnd;
			/// <summary>
			/// The type of message
			/// </summary>
			public int msg;
			/// <summary>
			/// WORD message parameter
			/// </summary>
			public int wParam;
			/// <summary>
			/// LONG message parameter
			/// </summary>
			public IntPtr lParam;
		}
		#endregion SDL_SysWMmsg_Windows

		#region SDL_SysWMinfo_Windows
		/// <summary>
		/// The Windows custom window manager information structure. TODO
		/// </summary>
		/// <remarks>
		/// <p>Struct in SDL_syswm.h
		/// <code>
		/// struct SDL_SysWMinfo {
		///	SDL_version version;
		///	HWND window;
		///	HGLRC hglrc;
		/// } SDL_SysWMinfo;		
		/// </code>
		/// </p>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_SysWMinfo_Windows
		{
			/// <summary>
			/// 
			/// </summary>
			public Sdl.SDL_version version;
			/// <summary>
			/// The Win32 display window
			/// </summary>
			public int window;
			/// <summary>
			/// The OpenGL context, if any
			/// </summary>
			public int hglrc;
		}
		#endregion SDL_SysWMinfo_Windows

		#region SDL_SysWMmsg_RiscOS
		/// <summary>
		/// RISC OS custom event structure
		/// </summary>
		/// <remarks>
		/// <p>Struct in SDL_syswm.h
		/// <code>
		/// struct SDL_SysWMmsg {
		///	SDL_version version;
		///	int eventCode;
		/// int pollBlock[64];
		/// };		
		/// </code>
		/// </p>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_SysWMmsg_RiscOS
		{
			/// <summary>
			/// 
			/// </summary>
			public SDL_version version;
			/// <summary>
			/// The window for the message
			/// </summary>
			public int eventCode;
			/// <summary>
			/// The window for the message
			/// </summary>
			public int[] pollBlock;
		}
		#endregion SDL_SysWMmsg_RiscOS

		#region SDL_SysWMinfo_RiscOS
		/// <summary>
		/// The RISCOS custom window manager information structure 
		/// </summary>
		/// <remarks>
		/// <p>Struct in SDL_syswm.h
		/// <code>
		/// struct SDL_SysWMinfo {
		///	SDL_version version;
		///	int wimpVersion;
		/// int taskHandle;
		/// int window;
		/// };		
		/// </code>
		/// </p>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_SysWMinfo_RiscOS
		{
			/// <summary>
			/// 
			/// </summary>
			public SDL_version version;
			/// <summary>
			/// Wimp version running under
			/// </summary>
			public int wimpVersion;
			/// <summary>
			/// The RISCOS task handle
			/// </summary>
			public int taskHandle;
			/// <summary>
			/// 
			/// </summary>
			public int window;
		}
		#endregion SDL_SysWMinfo_RiscOS

		#region SDL_SysWMmsg
		/// <summary>
		/// The generic custom event structure
		/// </summary>
		/// <remarks>
		/// <p>Struct in SDL_syswm.h
		/// <code>
		/// struct SDL_SysWMmsg {
		///	SDL_version version;
		///	int data;
		/// };		
		/// </code>
		/// </p>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_SysWMmsg
		{
			/// <summary>
			/// 
			/// </summary>
			public SDL_version version;
			/// <summary>
			/// 
			/// </summary>
			public int data;
		}
		#endregion SDL_SysWMmsg

		#region SDL_SysWMinfo
		/// <summary>
		/// The generic custom window manager information structure 
		/// </summary>
		/// <remarks>
		/// <p>Struct in SDL_syswm.h
		/// <code>
		/// struct SDL_SysWMinfo {
		///	SDL_version version;
		///	int data;
		/// };		
		/// </code>
		/// </p>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_SysWMinfo
		{
			/// <summary>
			/// 
			/// </summary>
			public SDL_version version;
			/// <summary>
			/// 
			/// </summary>
			public int data;
		}
		#endregion SDL_SysWMinfo
		#endregion SDL_syswm.h

		// SDL_thread.h -- Skipped. Superceded by System.Threading class
		
		#region SDL_timer.h
		#region SDL_TimerID
		//typedef struct _SDL_TimerID *SDL_TimerID;
		//TODO: write test
		/// <summary>
		///     
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_TimerID 
		{
		}
		#endregion SDL_TimerID
		#endregion SDL_timer.h

		// SDL_types.h

		#region SDL_version.h
		#region SDL_version
		/// <summary>
		/// Structure to hold version number of the SDL library
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_version 
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
		#endregion SDL_version
		#endregion SDL_version.h

		#region SDL_video.h
		#region SDL_Rect
		/// <summary>
		/// Defines a rectangular area.
		/// </summary>
		/// <remarks>
		/// A SDL_Rect defines a rectangular area of pixels. 
		/// It is used by <see cref="SDL_BlitSurface"/> to define blitting 
		/// regions and by several other video functions.
		/// </remarks>
		/// <see cref="SDL_BlitSurface"/>
		/// <see cref="SDL_UpdateRect"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_Rect 
		{
			/// <summary>
			/// x position of the upper-left corner of the rectangle.
			/// </summary>
			public short x;
			/// <summary>
			/// y position of the upper-left corner of the rectangle. 
			/// </summary>
			public short y;
			/// <summary>
			/// The width of the rectangle.
			/// </summary>
			public short w;
			/// <summary>
			/// The height of the rectangle.
			/// </summary>
			public short h;
			/// <summary>
			/// 
			/// </summary>
			/// <param name="x"></param>
			/// <param name="y"></param>
			/// <param name="w"></param>
			/// <param name="h"></param>
			public SDL_Rect( short x, short y, short w, short h)
			{
				this.x = x;
				this.y = y;
				this.w = w;
				this.h = h;
			}
			/// <summary>
			/// 
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				return "x: " + x + ", y: " + y + ", w: " + w + ", h: " + h;
			}
		}
		#endregion SDL_Rect

		#region SDL_Color
		/// <summary>
		/// Format independent color description
		/// </summary>
		/// <remarks>
		/// SDL_Color describes a color in a format independent way. 
		/// You can convert a SDL_Color to a pixel value for a certain 
		/// pixel format using <see cref="SDL_MapRGB"/>.
		/// </remarks>
		/// <seealso cref="SDL_PixelFormat" />
		/// <seealso cref="SDL_SetColors" />
		/// <seealso cref="SDL_Palette" />
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_Color
		{
			/// <summary>
			/// Red Intensity
			/// </summary>
			public byte r;
			/// <summary>
			/// Green Intensity
			/// </summary>
			public byte g;
			/// <summary>
			/// Blue Intensity
			/// </summary>
			public byte b;
			/// <summary>
			/// Alpha Channel
			/// Currently unused
			/// </summary>
			public byte unused;
			/// <summary>
			/// 
			/// </summary>
			/// <param name="r"></param>
			/// <param name="g"></param>
			/// <param name="b"></param>
			public SDL_Color( byte r, byte g, byte b)
			{
				this.r = r;
				this.g = g;
				this.b = b;
				this.unused = 0;
			}
			/// <summary>
			/// 
			/// </summary>
			/// <param name="r"></param>
			/// <param name="g"></param>
			/// <param name="b"></param>
			/// <param name="a"></param>
			public SDL_Color( byte r, byte g, byte b, byte a)
			{
				this.r = r;
				this.g = g;
				this.b = b;
				this.unused = a;
			}
		}
		#endregion SDL_Color

		#region SDL_Palette
		/// <summary>
		/// Color palette for 8-bit pixel formats
		/// </summary>
		/// <remarks>
		/// Each pixel in an 8-bit surface is an index into 
		/// the colors field of the SDL_Palette structure store 
		/// in <see cref="SDL_PixelFormat"/>. A SDL_Palette should never need 
		/// to be created manually. It is automatically created 
		/// when SDL allocates a <see cref="SDL_PixelFormat"/> for a surface. 
		/// The colors values of a <see cref="SDL_Surface"/> 
		/// palette can be set with the <see cref="SDL_SetColors"/>.
		/// </remarks>
		/// <see cref="SDL_Color"/>
		/// <see cref="SDL_Surface"/>
		/// <see cref="SDL_SetColors"/>
		/// <see cref="SDL_SetPalette"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]	
			public struct SDL_Palette 
		{
			/// <summary>
			/// Number of colors used in this palette
			/// </summary>
			public int ncolors;
			/// <summary>
			/// Array of <see cref="SDL_Color"/> 
			/// structures that make up the palette.
			/// </summary>
			public SDL_Color[] colors;
		}
		#endregion SDL_Palette

		#region SDL_PixelFormat
		/// <summary>
		/// Stores surface format information
		/// </summary>
		/// <remarks>
		/// A SDL_PixelFormat describes the format of the pixel data stored at the 
		/// pixels field of a SDL_Surface. Every surface stores a SDL_PixelFormat 
		/// in the format field.
		/// <p>
		/// If you wish to do pixel level modifications on a surface, then 
		///	understanding how SDL stores its color information is essential.
		/// </p>
		/// <p>							
		/// 8-bit pixel formats are the easiest to understand. 
		/// Since its an 8-bit format, we have 8 BitsPerPixel and 1 BytesPerPixel.
		/// Since BytesPerPixel is 1, all pixels are represented by a Uint8 which
		/// contains an index into palette.colors. So, to determine the color 
		/// of a pixel in a 8-bit surface: we read the color index from 
		/// surface.pixels and we use that index to read the SDL_Color 
		/// structure from surface.format.palette.colors. Like so: 
		/// </p>	
		/// <p>
		/// <code>
		///		SDL_Surface *surface;
		///		SDL_PixelFormat *fmt;
		///		SDL_Color *color;
		///		Uint8 index;
		///
		///		.
		///		.
		///
		///		/* Create surface */
		///		.
		///		.
		///		fmt=surface.format;
		///
		///		/* Check the bitdepth of the surface */
		///		if(fmt.BitsPerPixel!=8)
		///	{
		///		fprintf(stderr, "Not an 8-bit surface.\n");
		///		return(-1);
		///	}
		///
		///	/* Lock the surface */
		///	SDL_LockSurface(surface);
		///
		///	/* Get the topleft pixel */
		///	index=*(Uint8 *)surface.pixels;
		///	color=fmt.palette.colors[index];
		///
		///	/* Unlock the surface */
		///	SDL_UnlockSurface(surface);
		///	printf("Pixel Color- Red: %d, Green: %d, Blue: %d. Index: %d\n",
		///	color.r, color.g, color.b, index);
		///	.
		///	.
		///	</code>
		/// </p>
		/// <P>
		///	Pixel formats above 8-bit are an entirely different experience. 
		///	They are considered to be "TrueColor" formats and the color 
		///	information is stored in the pixels themselves, not in a palette. 
		///	The mask, shift and loss fields tell us how the color information
		///	is encoded. The mask fields allow us to isolate each color 
		///	component, the shift fields tell us the number of bits to the 
		///	right of each component in the pixel value and the loss fields
		///	tell us the number of bits lost from each component when 
		///	packing 8-bit color component in a pixel. 
		///	</P>
		///
		///<code>
		///	/* Extracting color components from a 32-bit color value */
		///	SDL_PixelFormat *fmt;
		///	SDL_Surface *surface;
		///	Uint32 temp, pixel;
		///	Uint8 red, green, blue, alpha;
		///	.
		///	.
		///	.
		///	fmt=surface.format;
		///	SDL_LockSurface(surface);
		///	pixel=*((Uint32*)surface.pixels);
		///	SDL_UnlockSurface(surface);
		///
		///	/* Get Red component */
		///	temp=pixel&amp;fmt.Rmask; /* Isolate red component */
		///	temp=temp&gt;&gt;fmt.Rshift;/* Shift it down to 8-bit */
		///	temp=temp&lt;&lt;fmt.Rloss; /* Expand to a full 8-bit number */
		///	red=(Uint8)temp;
		///
		///	/* Get Green component */
		///	temp=pixel&amp;fmt.Gmask; /* Isolate green component */
		///	temp=temp&gt;&gt;fmt.Gshift;/* Shift it down to 8-bit */
		///	temp=temp&lt;&lt;fmt.Gloss; /* Expand to a full 8-bit number */
		///	green=(Uint8)temp;
		///
		///	/* Get Blue component */
		///	temp=pixel&amp;fmt.Bmask; /* Isolate blue component */
		///	temp=temp&gt;&gt;fmt.Bshift;/* Shift it down to 8-bit */
		///	temp=temp&lt;&lt;fmt.Bloss; /* Expand to a full 8-bit number */
		///	blue=(Uint8)temp;
		///
		///	/* Get Alpha component */
		///	temp=pixel&amp;fmt.Amask; /* Isolate alpha component */
		///	temp=temp&gt;&gt;fmt.Ashift;/* Shift it down to 8-bit */
		///	temp=temp&lt;&lt;fmt.Aloss; /* Expand to a full 8-bit number */
		///	alpha=(Uint8)temp;
		///
		///	printf("Pixel Color - R: %d,  G: %d,  B: %d,  A: %d\n", red, green, blue, alpha);
		///	.
		///	.
		///	.
		///	</code>
		/// </remarks>
		/// <see cref="SDL_Surface"/>
		/// <see cref="SDL_MapRGB"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_PixelFormat 
		{
			/// <summary>
			/// Pointer to the palette, or NULL if the BitsPerPixel>8
			/// Pointer to <see cref="SDL_Palette"/>
			/// </summary>
			public IntPtr palette;
			/// <summary>
			/// The number of bits used to represent each pixel in a surface. 
			/// Usually 8, 16, 24 or 32.
			/// </summary>
			public byte BitsPerPixel;
			/// <summary>
			/// The number of bytes used to represent each pixel in a surface. 
			/// Usually one to four.
			/// </summary>
			public byte BytesPerPixel;
			/// <summary>
			/// Precision loss of each color component (2[RGBA]loss)
			/// </summary>
			public byte Rloss;
			/// <summary>
			/// Precision loss of each color component (2[RGBA]loss)
			/// </summary>
			public byte Gloss;
			/// <summary>
			/// Precision loss of each color component (2[RGBA]loss)
			/// </summary>
			public byte Bloss;
			/// <summary>
			/// Precision loss of each color component (2[RGBA]loss)
			/// </summary>
			public byte Aloss;
			/// <summary>
			/// Binary left shift of each color component in the pixel value
			/// </summary>
			public byte Rshift;
			/// <summary>
			/// Binary left shift of each color component in the pixel value
			/// </summary>
			public byte Gshift;
			/// <summary>
			/// Binary left shift of each color component in the pixel value
			/// </summary>
			public byte Bshift;
			/// <summary>
			/// Binary left shift of each color component in the pixel value
			/// </summary>
			public byte Ashift;
			/// <summary>
			/// Binary mask used to retrieve individual color values
			/// </summary>
			public int Rmask;
			/// <summary>
			/// Binary mask used to retrieve individual color values
			/// </summary>
			public int Gmask;
			/// <summary>
			/// Binary mask used to retrieve individual color values
			/// </summary>
			public int Bmask;
			/// <summary>
			/// Binary mask used to retrieve individual color values
			/// </summary>
			public int Amask;
			/// <summary>
			/// Pixel value of transparent pixels
			/// </summary>
			public int colorkey;
			/// <summary>
			/// Overall surface alpha value
			/// </summary>
			public byte alpha;
			/// <summary>
			/// 
			/// </summary>
			/// <param name="palette"></param>
			/// <param name="BitsPerPixel"></param>
			/// <param name="BytesPerPixel"></param>
			/// <param name="Rloss"></param>
			/// <param name="Gloss"></param>
			/// <param name="Bloss"></param>
			/// <param name="Aloss"></param>
			/// <param name="Rshift"></param>
			/// <param name="Gshift"></param>
			/// <param name="Bshift"></param>
			/// <param name="Ashift"></param>
			/// <param name="Rmask"></param>
			/// <param name="Gmask"></param>
			/// <param name="Bmask"></param>
			/// <param name="Amask"></param>
			/// <param name="colorkey"></param>
			/// <param name="alpha"></param>
			public SDL_PixelFormat(IntPtr palette, byte BitsPerPixel,
				byte BytesPerPixel, byte Rloss, byte Gloss,
				byte Bloss, byte Aloss, byte Rshift, byte Gshift,
				byte Bshift, byte Ashift,int Rmask,int Gmask,
				int Bmask,int Amask,int colorkey,byte alpha
				)
			{
				if (BitsPerPixel > 8)
				{
					this.palette = IntPtr.Zero;
				}
				else
				{
					this.palette = palette;
				}
				this.BitsPerPixel = BitsPerPixel;
				this.BytesPerPixel = BytesPerPixel;
				this.Rloss = Rloss;
				this.Gloss = Gloss;
				this.Bloss = Bloss;
				this.Aloss = Aloss;
				this.Rshift = Rshift;
				this.Gshift = Gshift;
				this.Bshift = Bshift;
				this.Ashift = Ashift;
				this.Rmask = Rmask;
				this.Gmask = Gmask;
				this.Bmask = Bmask;
				this.Amask = Amask;
				this.colorkey = colorkey;
				this.alpha = alpha;
			}
		}
		#endregion SDL_PixelFormat

		#region SDL_Surface
		/// <summary>
		/// Graphical Surface Structure.
		/// </summary>
		/// <remarks>
		/// This structure should be treated as read-only, except for 'pixels',
		/// which, if not NULL, contains the raw pixel data for the surface.
		/// SDL_Surface's represent areas of "graphical" memory, memory 
		/// that can be drawn to. The video framebuffer is returned as a 
		/// SDL_Surface by SDL_SetVideoMode and SDL_GetVideoSurface. 
		/// Most of the fields should be pretty obvious. w and h are the 
		/// width and height of the surface in pixels. pixels is a pointer 
		/// to the actual pixel data, the surface should be locked before 
		/// accessing this field. The clip_rect field is the clipping rectangle
		/// as set by SDL_SetClipRect.
		///
		/// <p>The following are supported in the flags field.</p>
		///<code>
		/// SDL_SWSURFACE Surface is stored in system memory
		/// SDL_HWSURFACE Surface is stored in video memory
		/// SDL_ASYNCBLIT Surface uses asynchronous blits if possible
		/// SDL_ANYFORMAT Allows any pixel-format (Display surface)
		/// SDL_HWPALETTE Surface has exclusive palette
		/// SDL_DOUBLEBUF Surface is double buffered (Display surface)
		/// SDL_FULLSCREEN Surface is full screen (Display Surface)
		/// SDL_OPENGL Surface has an OpenGL context (Display Surface)
		/// SDL_OPENGLBLIT Surface supports OpenGL blitting (Display Surface)
		/// SDL_RESIZABLE Surface is resizable (Display Surface)
		/// SDL_HWACCEL Surface blit uses hardware acceleration
		/// SDL_SRCCOLORKEY Surface use colorkey blitting
		/// SDL_RLEACCEL Colorkey blitting is accelerated with RLE
		/// SDL_SRCALPHA Surface blit uses alpha blending
		/// SDL_PREALLOC Surface uses preallocated memory</code>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_Surface 
		{
			/// <summary>
			/// Surface flags
			/// </summary>
			public int flags;
			/// <summary>
			/// Pixel format
			/// Pointer to SDL_PixelFormat
			/// </summary>
			public IntPtr format;
			/// <summary>
			/// Width of the surface
			/// </summary>
			public int w;
			/// <summary>
			/// Height of the surface
			/// </summary>
			public int h;
			/// <summary>
			/// Length of a surface scanline in bytes
			/// </summary>
			public short pitch;
			/// <summary>
			/// Pointer to the actual pixel data
			/// Void pointer.
			/// </summary>
			public IntPtr pixels;
			/// <summary>
			/// 
			/// </summary>
			public int offset;
			/// <summary>
			/// Hardware-specific surface info
			/// </summary>
			public IntPtr hwdata;
			/// <summary>
			/// surface clip rectangle
			/// </summary>
			public SDL_Rect clip_rect;
			/// <summary>
			/// 
			/// </summary>
			public int unused1;
			/// <summary>
			/// Allow recursive locks
			/// </summary>
			public int locked;
			/// <summary>
			/// info for fast blit mapping to other surfaces
			/// </summary>
			public IntPtr map;
			/// <summary>
			/// format version, bumped at every change to invalidate blit maps
			/// </summary>
			public int format_version;
			/// <summary>
			/// Reference count -- used when freeing surface
			/// </summary>
			public int refcount;
		}
		#endregion SDL_Surface

		#region SDL_VideoInfo
		/// <summary>
		/// Video Target information.
		/// Useful for determining the video hardware capabilities.
		/// Not finished. The C struct uses a set of bit-fields that need to be marshalled.
		/// The vfmt IntPtr works and provided useful information.
		/// </summary>
		/// <remarks>
		/// This (read-only) structure is returned by <see cref="SDL_GetVideoInfo"/>. 
		/// It contains information on either the 'best' available mode 
		/// (if called before <see cref="SDL_SetVideoMode"/>) or the current video mode.
		/// </remarks>
		/// <see cref="SDL_GetVideoInfo"/>
		/// <see cref="SDL_PixelFormat"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_VideoInfo 
		{
			/// <summary>
			/// 
			/// </summary>
			public byte field1;

			/// <summary>
			/// 
			/// </summary>
			public byte field2;

			/// <summary>
			/// 
			/// </summary>
			private short unused;

			/// <summary>
			/// Total amount of video memory in Kilobytes.
			/// </summary>
			public int video_mem;


			/// <summary>
			/// Pixel format of the video device. Pointer to SDL_PixelFormat.
			/// </summary>
			public IntPtr vfmt;

			/// <summary>
			/// Is it possible to create hardware surfaces?
			/// </summary>
			public int hw_available
			{
				get
				{
					return (field1 & 1);
				}
			}

			/// <summary>
			/// Is there a window manager available
			/// </summary>
			public int wm_available
			{
				get
				{
					return (field1>>1 & 1);
				}
			}
			/// <summary>
			/// Are hardware to hardware blits accelerated?
			/// </summary>
			public int blit_hw
			{
				get
				{
					return (field2>>1 & 1);
				}
			}
			/// <summary>
			/// Are hardware to hardware colorkey blits accelerated?
			/// </summary>
			public int blit_hw_CC
			{
				get
				{
					return (field2>>2 & 1);
				}
			}

			/// <summary>
			/// Are hardware to hardware alpha blits accelerated?
			/// </summary>
			public int blit_hw_A
			{
				get
				{
					return (field2>>3 & 1);
				}
			}
			/// <summary>
			/// Are software to hardware blits accelerated?
			/// </summary>
			public int blit_sw
			{
				get
				{
					return (field2>>4 & 1);
				}
			}
			/// <summary>
			/// Are software to hardware colorkey blits accelerated?
			/// </summary>
			public int blit_sw_CC
			{
				get
				{
					return (field2>>5 & 1);
				}
			}
			/// <summary>
			/// Are software to hardware alpha blits accelerated?
			/// </summary>
			public int blit_sw_A
			{
				get
				{
					return (field2>>6 & 1);
				}
			}
			/// <summary>
			/// Are color fills accelerated?
			/// </summary>
			public int blit_fill
			{
				get
				{
					return (field2>>7 & 1);
				}
			}
		}
		#endregion SDL_VideoInfo

		#region SDL_Overlay
		/// <summary>
		/// The YUV hardware video overlay
		/// </summary>
		/// <remarks>
		/// A SDL_Overlay is similar to a SDL_Surface except 
		/// it stores a YUV overlay. All the fields are read only, 
		/// except for pixels which should be locked before use. 
		/// The format field stores the format of the overlay 
		/// which is one of the following: 
		/// <code>
		/// SDL_YV12_OVERLAY  0x32315659  /* Planar mode: Y + V + U */
		/// SDL_IYUV_OVERLAY  0x56555949  /* Planar mode: Y + U + V */
		/// SDL_YUY2_OVERLAY  0x32595559  /* Packed mode: Y0+U0+Y1+V0 */
		/// SDL_UYVY_OVERLAY  0x59565955  /* Packed mode: U0+Y0+V0+Y1 */
		/// SDL_YVYU_OVERLAY  0x55595659  /* Packed mode: Y0+V0+Y1+U0 */</code>
		/// 
		/// More information on YUV formats can be found at 
		/// http://www.webartz.com/fourcc/indexyuv.htm.
		/// </remarks>
		/// <see cref="SDL_CreateYUVOverlay"/>
		/// <see cref="SDL_LockYUVOverlay"/>
		/// <see cref="SDL_UnlockYUVOverlay"/>
		/// <see cref="SDL_FreeYUVOverlay"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_Overlay
		{
			/// <summary>
			/// Overlay format (see below)
			/// </summary>
			public int format;
			/// <summary>
			/// Width of overlay
			/// </summary>
			public int w;
			/// <summary>
			/// Height of overlay
			/// </summary>
			public int h;
			/// <summary>
			/// Number of planes in the overlay. Usually either 1 or 3.
			/// </summary>
			public int planes;
			/// <summary>
			/// An array of pitches, one for each plane. 
			/// Pitch is the length of a row in bytes.
			/// </summary>
			public short[] pitches;
			/// <summary>
			/// An array of pointers to the data of each plane. 
			/// The overlay should be locked before these pointers are used.
			/// </summary>
			public IntPtr[] pixels;//TODO double pointer to bytes
			// Hardware-specific surface info
			private IntPtr hwfuncs;
			private IntPtr hwdata;
			/// <summary>
			/// This will be set to 1 if the overlay is hardware accelerated.
			/// </summary>
			public int hw_overlay;
			private int UnusedBits;
		}
		#endregion SDL_Overlay
		#endregion SDL_video.h
		#endregion Public Structs

		#region Private Static Fields
		// Private pointers to NSAutoreleasePool class for Cocoa# on OS X.
		// Used for <see cref="SDL_Init"/> and <see cref="SDL_InitSubSystem"/>.
		private static object pool;

		/// <summary>
		///		Private byte array holding the internal keyboard state.
		/// </summary>
		/// <remarks>
		///		Used for <see cref="SDL_GetKeyState"/>.
		///		Array is sized to fit all the known Key enums.
		/// </remarks>
		private static byte[] keyboardState = new byte[(int)Sdl.SDLK_LAST];

		#endregion Private Static Fields

		#region Constructors & Destructors
		#region Sdl()
		/// <summary>
		///     Prevents instantiation.
		/// </summary>
		private Sdl() 
		{
		}
		#endregion Sdl()
		#endregion Constructors & Destructors

		#region Public Delegates
		#region SDL_events.h
		#region int SDL_EventFilter([Out] SDL_Event evt)
		/// <summary>
		/// This function sets up a filter to process all events before they
		/// change internal state and are posted to the internal event queue.
		/// </summary>
		/// <param name="evt">
		///     Event.
		/// </param>
		/// <returns>
		///     If the filter returns 1, then the event will be added 
		///     to the internal queue. If it returns 0, then the event
		///      will be dropped from the queue. This allows selective
		///       filtering of dynamically.
		/// </returns>
		/// <remarks>
		/// <p>
		///     Binds to C callback in SDL_events.h:
		///     <code>typedef Uint32 (SDLCALL *SDL_EventFilter)(const SDL_Event *event)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_SetEventFilter" />
		/// <seealso cref="SDL_GetEventFilter" />
		[DelegateCallingConventionCdecl]
			public delegate int SDL_EventFilter([Out] SDL_Event evt);
		#endregion int SDL_EventFilter([Out] SDL_Event evt)
		#endregion SDL_events.h

		#region SDL_timer.h
		#region int SDL_TimerCallback(int interval)
		/// <summary>
		///     Prototype for the timer callback.
		/// </summary>
		/// <param name="interval">
		///     The current timer interval.
		/// </param>
		/// <returns>
		///     The next timer interval.
		/// </returns>
		/// <remarks>
		/// <p>
		///     Binds to C callback in SDL_timer.h:
		///     <code>typedef Uint32 (SDLCALL *SDL_TimerCallback)(Uint32 interval, void *param)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_SetTimer" />
		[DelegateCallingConventionCdecl]
			public delegate int SDL_TimerCallback(int interval);
		#endregion int SDL_TimerCallback(int interval)

		#region int SDL_NewTimerCallback(int interval)
		// TODO: Goddamn void* double whammy since it's a delegate
		/// <summary>
		///     Prototype for the new timer callback.
		/// </summary>
		/// <param name="interval">
		///     The current timer interval.
		/// </param>
		/// <returns>
		///     The next timer interval.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The callback function is passed the current timer interval 
		/// and returns the next timer interval.  If the returned 
		/// value is the same as the one passed in, the periodic alarm
		///  continues, otherwise a new alarm is scheduled.  
		///  If the callback returns 0, the periodic alarm is cancelled.
		/// </para>
		/// <p>
		///     Binds to C callback in SDL_timer.h:
		///     <code>typedef Uint32 (SDLCALL *SDL_NewTimerCallback)(Uint32 interval, void *param)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_AddTimer" />
		/// <seealso cref="SDL_RemoveTimer" />
		[DelegateCallingConventionCdecl]
			public delegate int SDL_NewTimerCallback(int interval);
		#endregion int SDL_NewTimerCallback(int interval)
		#endregion SDL_timer.h		
		#endregion Public Delegates

		#region Sdl Methods
		#region SDL.h
		#region int SDL_Init(int flags)
		// Called from SDL_Init
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="SDL_Init"), SuppressUnmanagedCodeSecurity]
		private static extern int __SDL_Init(int flags);

		/// <summary>
		///     Initializes SDL and the specified subsystems.
		/// </summary>
		/// <param name="flags">
		///     <para>
		///         Specifies what part(s) of SDL to initialize:
		///     </para>
		///     <para>
		///         <list type="table">
		///             <listheader>
		///                 <term>Flag</term>
		///                 <description>Description</description>
		///             </listheader>
		///             <item>
		///                 <term><see cref="SDL_INIT_TIMER" /></term>
		///                 <description>Initializes the timer subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_AUDIO" /></term>
		///                 <description>Initializes the audio subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_VIDEO" /></term>
		///                 <description>Initializes the video subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_CDROM" /></term>
		///                 <description>Initializes the CD-ROM subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_JOYSTICK" /></term>
		///                 <description>Initializes the joystick subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_EVERYTHING" /></term>
		///                 <description>Initializes all subsystems.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_NOPARACHUTE" /></term>
		///                 <description>Prevents SDL from catching fatal signals.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_EVENTTHREAD" /></term>
		///                 <description>Not supported on all OS's.</description>
		///             </item>
		///         </list>
		///     </para>
		/// </param>
		/// <returns>
		///     Returns -1 on an error or 0 on success.
		/// </returns>
		/// <remarks>
		///     <para>
		///         Unless the <see cref="SDL_INIT_NOPARACHUTE" /> flag is set, it will install
		///         cleanup signal handlers for some commonly ignored fatal signals (like
		///         SIGSEGV).
		///     </para>
		///     <p>
		///			Binds to C-function call in SDL.h:
		///     <code>extern DECLSPEC int SDLCALL SDL_Init(Uint32 flags)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_InitSubSystem" />
		/// <seealso cref="SDL_Quit" />
		public static int SDL_Init(int flags) 
		{
			//Mac OSX code
			Assembly af = Assembly.LoadWithPartialName("Apple.Foundation");
			if (af != null) 
			{
				System.Type NSAutoreleasePool = af.GetType("NSAutoreleasePool");
				pool = af.CreateInstance("Apple.Foundation.NSAutoreleasePool");
				pool.GetType().GetMethod("init").Invoke(pool, null);
				NSApplicationLoad();
			}
			return __SDL_Init(flags);
		}
		#endregion int SDL_Init(int flags)
		#region int SDL_InitSubSystem(int flags)
		// Called from SDL_InitSubSystem
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="SDL_InitSubSystem"), SuppressUnmanagedCodeSecurity]
		private static extern int __SDL_InitSubSystem(int flags);

		/// <summary>
		///     Initializes specified subsystems.
		/// </summary>
		/// <param name="flags">
		///     <para>
		///         Specifies what part(s) of SDL to initialize:
		///     </para>
		///     <para>
		///         <list type="table">
		///             <listheader>
		///                 <term>Flag</term>
		///                 <description>Description</description>
		///             </listheader>
		///             <item>
		///                 <term><see cref="SDL_INIT_TIMER" /></term>
		///                 <description>Initializes the timer subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_AUDIO" /></term>
		///                 <description>Initializes the audio subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_VIDEO" /></term>
		///                 <description>Initializes the video subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_CDROM" /></term>
		///                 <description>Initializes the CD-ROM subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_JOYSTICK" /></term>
		///                 <description>Initializes the joystick subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_EVERYTHING" /></term>
		///                 <description>Initializes all subsystems.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_NOPARACHUTE" /></term>
		///                 <description>Prevents SDL from catching fatal signals.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_EVENTTHREAD" /></term>
		///                 <description>Not supported on all OS's.</description>
		///             </item>
		///         </list>
		///     </para>
		/// </param>
		/// <returns>
		///     Returns -1 on an error or 0 on success.
		/// </returns>
		/// <remarks>
		///     After SDL has been initialized with <see cref="SDL_Init" /> you may initialize
		///     any uninitialized subsystems with <b>SDL_InitSubSystem</b>.
		///      <p>
		///     Binds to C-function call in SDL.h:
		///     <code>extern DECLSPEC int SDLCALL SDL_InitSubSystem(Uint32 flags)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_Init" />
		/// <seealso cref="SDL_Quit" />
		/// <seealso cref="SDL_QuitSubSystem" />
		/// 
		public static int SDL_InitSubSystem(int flags) 
		{
			// Mac OSX code
			Assembly af = Assembly.LoadWithPartialName("Apple.Foundation");
			if (af != null) 
			{
				System.Type NSAutoreleasePool = af.GetType("NSAutoreleasePool");
				pool = af.CreateInstance("Apple.Foundation.NSAutoreleasePool");
				pool.GetType().GetMethod("init").Invoke(pool, null);
				NSApplicationLoad();
			}
			return __SDL_InitSubSystem(flags);
		}
		#endregion int SDL_InitSubSystem(int flags)

		#region SDL_QuitSubSystem(int flags)
		/// <summary>
		///     Shuts down specified subsystems.
		/// </summary>
		/// <param name="flags">
		///     <para>
		///         Specifies what part(s) of SDL to shut down:
		///     </para>
		///     <para>
		///         <list type="table">
		///             <listheader>
		///                 <term>Flag</term>
		///                 <description>Description</description>
		///             </listheader>
		///             <item>
		///                 <term><see cref="SDL_INIT_TIMER" /></term>
		///                 <description>Shuts down the timer subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_AUDIO" /></term>
		///                 <description>Shuts down the audio subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_VIDEO" /></term>
		///                 <description>Shuts down the video subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_CDROM" /></term>
		///                 <description>Shuts down the CD-ROM subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_JOYSTICK" /></term>
		///                 <description>Shuts down the joystick subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_EVERYTHING" /></term>
		///                 <description>Shuts down all subsystems.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_NOPARACHUTE" /></term>
		///                 <description>Prevents SDL from catching fatal signals.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_EVENTTHREAD" /></term>
		///                 <description>Not supported on all OS's.</description>
		///             </item>
		///         </list>
		///     </para>
		/// </param>
		/// <remarks>
		///     <b>SDL_QuitSubSystem</b> allows you to shut down a subsystem that has been
		///     previously initialized by <see cref="SDL_Init" /> or
		///     <see cref="SDL_InitSubSystem" />.
		///     <p>
		///     Binds to C-function call in SDL.h:
		///     <code>extern DECLSPEC void SDLCALL SDL_QuitSubSystem(Uint32 flags)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_Init" />
		/// <seealso cref="SDL_InitSubSystem" />
		/// <seealso cref="SDL_Quit" />
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void SDL_QuitSubSystem(int flags);
		#endregion SDL_QuitSubSystem(int flags)

		#region int SDL_WasInit(int flags)
		/// <summary>
		///     Checks which SDL subsystems are initialized.
		/// </summary>
		/// <param name="flags">
		///     <para>
		///         Specifies the subsystems you wish to check:
		///     </para>
		///     <para>
		///         <list type="table">
		///             <listheader>
		///                 <term>Flag</term>
		///                 <description>Description</description>
		///             </listheader>
		///             <item>
		///                 <term><see cref="SDL_INIT_TIMER" /></term>
		///                 <description>The timer subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_AUDIO" /></term>
		///                 <description>The audio subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_VIDEO" /></term>
		///                 <description>The video subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_CDROM" /></term>
		///                 <description>The CD-ROM subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_JOYSTICK" /></term>
		///                 <description>The joystick subsystem.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_EVERYTHING" /></term>
		///                 <description>All subsystems.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_NOPARACHUTE" /></term>
		///                 <description>Prevents SDL from catching fatal signals.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_INIT_EVENTTHREAD" /></term>
		///                 <description>Not supported on all OS's.</description>
		///             </item>
		///         </list>
		///     </para>
		/// </param>
		/// <returns>
		///     A bitwised OR'd combination of the initialized subsystems.
		/// </returns>
		/// <remarks>
		///     <b>SDL_WasInit</b> allows you to see which SDL subsytems have been initialized.
		///     <p>
		///     Binds to C-function call in SDL.h:
		///     <code>extern DECLSPEC Uint32 SDLCALL SDL_WasInit(Uint32 flags)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_Init" />
		/// <seealso cref="SDL_InitSubSystem" />
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_WasInit(int flags);
		#endregion int SDL_WasInit(int flags)

		#region SDL_Quit()
		/// <summary>
		///     Shuts down SDL.
		/// </summary>
		/// <remarks>
		///     <b>SDL_Quit</b> shuts down all SDL subsystems and frees the resources allocated
		///     to them.  This should always be called before you exit.
		///     <p>
		///     Binds to C-function call in SDL.h:
		///     <code>extern DECLSPEC void SDLCALL SDL_Quit(void)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_Init" />
		/// <seealso cref="SDL_QuitSubSystem" />
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void SDL_Quit();
		#endregion SDL_Quit()
		#endregion SDL.h

		#region SDL_active.h
		#region byte SDL_GetAppState
		/// <summary>
		/// This function returns the current state of the application, 
		/// which is a bitwise combination of SDL_APPMOUSEFOCUS, 
		/// SDL_APPINPUTFOCUS, and SDL_APPACTIVE.  
		/// </summary>
		/// <remarks>
		/// If SDL_APPACTIVE is set, then the user is able to see 
		/// your application, 
		/// otherwise it has been iconified or disabled.
		/// </remarks>
		/// <returns>Returns the current state of the application, 
		/// which is a bitwise combination of SDL_APPMOUSEFOCUS, 
		/// SDL_APPINPUTFOCUS, and SDL_APPACTIVE
		/// </returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern byte SDL_GetAppState();
		#endregion byte SDL_GetAppState
		#endregion SDL_active.h

		#region SDL_audio.h
		#region int AUDIO_U16SYS
		/// <summary>
		/// Native audio byte ordering
		/// </summary>
		/// <remarks>
		/// <p>Based on code from SDL_audio.h
		/// <code>
		/// #if SDL_BYTEORDER == SDL_LIL_ENDIAN
		/// #define AUDIO_U16SYS	AUDIO_U16LSB
		/// #define AUDIO_S16SYS	AUDIO_S16LSB
		/// #else
		/// #define AUDIO_U16SYS	AUDIO_U16MSB
		/// #define AUDIO_S16SYS	AUDIO_S16MSB
		/// #endif
		/// </code>
		/// </p>
		/// </remarks>
		public static int AUDIO_U16SYS 
		{
			get 
			{
				if (SDL_BYTEORDER == SDL_LIL_ENDIAN) 
				{
					return AUDIO_U16LSB;
				}
				else 
				{
					return AUDIO_U16MSB;
				}
			}
		}
		#endregion int AUDIO_U16SYS

		#region int AUDIO_S16SYS
		/// <summary>
		/// Native audio byte ordering
		/// </summary>
		/// <remarks>
		/// <p>Based on code from SDL_audio.h
		/// <code>
		/// #if SDL_BYTEORDER == SDL_LIL_ENDIAN
		/// #define AUDIO_U16SYS	AUDIO_U16LSB
		/// #define AUDIO_S16SYS	AUDIO_S16LSB
		/// #else
		/// #define AUDIO_U16SYS	AUDIO_U16MSB
		/// #define AUDIO_S16SYS	AUDIO_S16MSB
		/// #endif
		/// </code>
		/// </p>
		/// </remarks>
		public static int AUDIO_S16SYS 
		{
			get 
			{
				if (SDL_BYTEORDER == SDL_LIL_ENDIAN) 
				{
					return AUDIO_S16LSB;
				}
				else 
				{
					return AUDIO_S16MSB;
				}
			}
		}
		#endregion int AUDIO_S16SYS

		#region int SDL_AudioInit(string driver_name)
		/// <summary>
		/// This function is used internally, 
		/// and should not be used unless you
		/// have a specific need to specify the audio driver you want to use.
		/// You should normally use 
		/// <see cref="SDL_Init"/> or <see cref="SDL_InitSubSystem"/>.
		/// </summary>
		/// <remarks>
		/// Binds to C-function call in SDL_audio.h:
		/// <code>int SDL_AudioInit(const char *driver_name)
		/// </code></remarks>
		/// <param name="driver_name">
		/// </param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_AudioInit(string driver_name);
		#endregion int SDL_AudioInit(string driver_name)

		#region void SDL_AudioQuit()
		/// <summary>
		/// This function is used internally, 
		/// and should not be used unless you
		/// have a specific need to specify the audio driver you want to use.
		/// You should normally use SDL_Init() or SDL_InitSubSystem().
		/// </summary>
		/// <remarks>
		/// Binds to C-function call in SDL_audio.h:
		/// <code>void SDL_AudioQuit()
		/// </code></remarks>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_AudioQuit();
		#endregion void SDL_AudioQuit()

		#region string SDL_AudioDriverName(string namebuf, int maxlen)
		/// <summary>
		/// This function fills the given character buffer with the name of the
		/// current audio driver, and returns a pointer to it if the audio
		///  driver has	been initialized.  
		/// </summary>
		/// <remarks>
		/// Binds to C-function call in SDL_audio.h:
		/// <code>char * SDL_AudioDriverName(char *namebuf, int maxlen)
		/// </code>
		/// </remarks>
		/// <returns>It returns NULL if no driver has been initialized.
		/// </returns>
		/// <param name="namebuf"></param>
		/// <param name="maxlen"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern string SDL_AudioDriverName(
			string namebuf, int maxlen);
		#endregion string SDL_AudioDriverName(string namebuf, int maxlen)

		#region int SDL_OpenAudio(IntPtr desired, IntPtr obtained)
		/// <summary>
		/// Opens the audio device with the desired parameters.
		/// </summary>
		/// <remarks>
		/// This function opens the audio device with the desired parameters, 
		/// and returns 0 if successful, placing the actual hardware 
		/// parameters in the structure pointed to by obtained. If obtained
		///  is NULL, the audio data passed to the callback function will 
		///  be guaranteed to be in the requested format, and will be 
		///  automatically converted to the hardware audio format if 
		///  necessary. This function returns -1 if it failed to open
		///   the audio device, or couldn't set up the audio thread.
		///   <p>To open the audio device a desired 
		///   <see cref="SDL_AudioSpec"/> must be created.</p>
		///   <code>
		/// SDL_AudioSpec *desired;
		/// .
		/// .
		/// desired = malloc(sizeof(SDL_AudioSpec)); </code>
		/// <p>You must then fill this structure with 
		/// your desired audio specifications.</p>
		/// <p>desired-&gt;freq</p>
		/// The desired audio frequency in samples-per-second.
		/// <p>desired-&gt;format</p>
		/// The desired audio format (see <see cref="SDL_AudioSpec"/>)
		/// <p>desired-&gt;samples</p>
		/// The desired size of the audio buffer in samples. 
		/// This number should be a power of two, and may be adjusted by the
		///  audio driver to a value more suitable for the hardware. Good
		///   values seem to range between 512 and 8192 inclusive, depending
		///    on the application and CPU speed. Smaller values yield faster
		///     response time, but can lead to underflow if the application
		///      is doing heavy processing and cannot fill the audio buffer
		///       in time. A stereo sample consists of both right and left
		///        channels in LR ordering. Note that the number of samples
		///         is directly related to time by the following formula: 
		///         ms = (samples*1000)/freq
		/// <p>desired-&gt;callback</p>
		/// This should be set to a function that will be called when the
		///  audio device is ready for more data. It is passed a pointer 
		///  to the audio buffer, and the length in bytes of the audio 
		///  buffer. This function usually runs in a separate thread, and 
		///  so you should protect data structures that it accesses by 
		///  calling <see cref="SDL_LockAudio"/> and 
		///  <see cref="SDL_UnlockAudio"/> in your code. The callback 
		///  prototype is: 
		/// <code>
		/// void callback(void *userdata, Uint8 *stream, int len);
		/// </code>
		/// <p>userdata is the pointer stored in userdata field of the
		///  SDL_AudioSpec. stream is a pointer to the audio buffer you
		///   want to fill with information and len is the length of the
		///    audio buffer in bytes.</p>
		/// <p> desired-&gt;userdata</p>
		///<p> This pointer is passed as the first parameter to the 
		///callback function.</p>
		///<p> SDL_OpenAudio reads these fields from the desired 
		///SDL_AudioSpec structure pass to the function and attempts to find 
		///an audio configuration matching your desired. As mentioned above, 
		///if the obtained parameter is NULL then SDL with convert from your
		/// desired audio settings to the hardware settings as it plays.</p>
		///<p>If obtained is NULL then the desired SDL_AudioSpec is your
		/// working specification, otherwise the obtained SDL_AudioSpec 
		/// becomes the working specification and the desirec specification
		///  can be deleted. The data in the working specification is used 
		///  when building SDL_AudioCVT's for converting loaded data to the
		///   hardware format.</p>
		///<p>SDL_OpenAudio calculates the size and silence fields for both 
		///the desired and obtained specifications. The size field stores 
		///the total size of the audio buffer in bytes, while the silence
		/// stores the value used to represent silence in the audio buffer.
		/// </p>									
		/// <p>The audio device starts out playing silence when it's opened,
		/// and should be enabled for playing by calling 
		/// <see cref="SDL_PauseAudio"/>(0) when you are ready for your 
		/// audio callback function to be called. Since the audio driver 
		/// may modify the requested size of the audio buffer, you should
		///  allocate any local mixing buffers after you open the audio 
		///  device.</p>
		///  <p>Binds to C-function call in SDL_audio.h:
		///  <code>int SDL_OpenAudio(SDL_AudioSpec *desired, SDL_AudioSpec *obtained);
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		///
		/// /* Prototype of our callback function */
		///		void my_audio_callback(void *userdata, Uint8 *stream, int len);
		///
		///		/* Open the audio device */
		///		SDL_AudioSpec *desired, *obtained;
		///		SDL_AudioSpec *hardware_spec;
		///
		///		/* Allocate a desired SDL_AudioSpec */
		///		desired = malloc(sizeof(SDL_AudioSpec));
		///
		///		/* Allocate space for the obtained SDL_AudioSpec */
		///		obtained = malloc(sizeof(SDL_AudioSpec));
		///
		///		/* 22050Hz - FM Radio quality */
		///		desired-&gt;freq=22050;
		///
		///		/* 16-bit signed audio */
		///		desired-&gt;format=AUDIO_S16LSB;
		///
		///		/* Mono */
		///		desired-&gt;channels=0;
		///
		///	/* Large audio buffer reduces risk of dropouts but 
		///	increases response time */
		///		desired-&gt;samples=8192;
		///
		///		/* Our callback function */
		///		desired-&gt;callback=my_audio_callback;
		///
		///		desired-&gt;userdata=NULL;
		///
		///		/* Open the audio device */
		///		if ( SDL_OpenAudio(desired, obtained) &lt; 0 )
		///	{
		///		fprintf(stderr, "Couldn't open audio: %s\n", SDL_GetError());
		///		exit(-1);
		///	}
		///	/* desired spec is no longer needed */
		///	free(desired);
		///	hardware_spec=obtained;
		///	.
		///	.
		///	/* Prepare callback for playing */
		///	.
		///	.
		///	.
		///	/* Start playing */
		///	SDL_PauseAudio(0);</code>
		///</example>
		/// <param name="desired">IntPtr to SDL_AudioSpec</param>
		/// <param name="obtained">IntPtr to SDL_AudioSpec</param>
		/// <seealso cref="SDL_AudioSpec"/>
		/// <seealso cref="SDL_LockAudio"/>
		/// <seealso cref="SDL_UnlockAudio"/>
		/// <seealso cref="SDL_PauseAudio"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_OpenAudio(
			IntPtr desired, IntPtr obtained);
		#endregion int SDL_OpenAudio(IntPtr desired, IntPtr obtained)

		#region SDL_audiostatus SDL_GetAudioStatus()
		/// <summary>
		/// Get the current audio state.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_audio.h:
		/// <code>SDL_audiostatus SDL_GetAudioStatus(void)
		/// </code></p>
		/// </remarks>
		/// <returns>Returns either SDL_AUDIO_STOPPED, 
		/// SDL_AUDIO_PAUSED or SDL_AUDIO_PLAYING (SDLaudiostatus enum)
		/// depending on the current audio state.</returns>
		/// <seealso cref="SDL_PauseAudio"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GetAudioStatus();
		#endregion SDL_audiostatus SDL_GetAudioStatus()

		#region void SDL_PauseAudio(int pause_on)
		/// <summary>
		/// Pauses and unpauses the audio callback processing.
		/// </summary>
		/// <remarks>
		/// This function pauses and unpauses the audio callback processing. 
		/// It should be called with pause_on=0 after opening the audio device 
		/// to start playing sound. This is so you can safely initialize data 
		/// for your callback function after opening the audio device. 
		/// Silence will be written to the audio device during the pause.
		/// <p>Binds to C-function call in SDL_audio.h:
		/// <code>void SDL_PauseAudio(int pause_on)
		/// </code></p>
		/// </remarks>
		/// <param name="pause_on"></param>
		/// <seealso cref="SDL_GetAudioStatus"/>
		/// <seealso cref="SDL_OpenAudio"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_PauseAudio(int pause_on);
		#endregion void SDL_PauseAudio(int pause_on)

		//TODO Fix this method
		#region IntPtr SDL_LoadWAV_RW(...)
		/// <summary>
		/// This function loads a WAVE from the data source, 
		/// automatically freeing
		/// that source if 'freesrc' is non-zero.  
		/// For example, to load a WAVE file,
		/// you could do:
		///	SDL_LoadWAV_RW(SDL_RWFromFile("sample.wav", "rb"), 1, ...);
		///	</summary>
		///	<remarks>If this function succeeds, it returns the given SDL_AudioSpec,
		/// filled with the audio data format of the wave data, and sets
		/// 'audio_buf' to a malloc()'d buffer containing the audio data,
		/// and sets 'audio_len' to the length of that audio buffer, in bytes.
		/// You need to free the audio buffer with SDL_FreeWAV() when you are 
		/// done with it.
		/// <p>This function returns NULL and sets the SDL error message if the 
		/// wave file cannot be opened, uses an unknown data format, or is 
		/// corrupt.  Currently raw and MS-ADPCM WAVE files are supported.</p>
		/// <p>Binds to C-function call in SDL_audio.h:
		/// <code>SDL_AudioSpec * SDL_LoadWAV_RW(SDL_RWops *src, int freesrc, SDL_AudioSpec *spec, Uint8 **audio_buf, Uint32 *audio_len)
		/// </code>
		/// </p></remarks>
		/// <param name="audio_buf"></param>
		/// <param name="audio_len"></param>
		/// <param name="freesrc"></param>
		/// <param name="spec"></param>
		/// <param name="src"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_LoadWAV_RW(
			IntPtr src, int freesrc,  out IntPtr spec, 
			out IntPtr audio_buf, out int audio_len);
		#endregion IntPtr SDL_LoadWAV_RW(...)

		//TODO Fix this method
		#region IntPtr SDL_LoadWAV(string file, out IntPtr spec, out byte[] audio_buf, out IntPtr audio_len)
		/// <summary>
		/// Load a WAVE file.
		/// </summary>
		/// <remarks>
		/// SDL_LoadWAV This function loads a WAVE file into memory.
		/// <p>If this function succeeds, it returns the given 
		/// <see cref="SDL_AudioSpec"/>,
		///  filled with the audio data format of the wave data, and sets 
		///  audio_buf to a malloc'd buffer containing the audio data, and
		///   sets audio_len to the length of that audio buffer, in bytes.
		///    You need to free the audio buffer with 
		///    <see cref="SDL_FreeWAV"/> when you are done with it.</p>
		/// <p>This function returns NULL and sets the SDL error message if the
		///  wave file cannot be opened, uses an unknown data format, or is 
		///  corrupt. Currently raw, MS-ADPCM and IMA-ADPCM WAVE files are 
		///  supported.</p>
		/// <p>Binds to C-function call in SDL_audio.h:
		/// <code>
		/// #define SDL_LoadWAV(file, spec, audio_buf, audio_len) 
		/// SDL_LoadWAV_RW(SDL_RWFromFile(file, "rb"),1, spec,audio_buf,audio_len)
		/// 
		/// SDL_AudioSpec *SDL_LoadWAV(const char *file, SDL_AudioSpec *spec, Uint8 **audio_buf, Uint32 *audio_len);
		/// </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// SDL_AudioSpec wav_spec;
		///		Uint32 wav_length;
		///		Uint8 *wav_buffer;
		///
		///		/* Load the WAV */
		///		if( SDL_LoadWAV("test.wav", wav_spec, wav_buffer, wav_length) == NULL )
		///																			{
		///		fprintf(stderr, "Could not open test.wav: %s\n", SDL_GetError());
		///		exit(-1);
		///	}
		///	.
		///	.
		///	.
		///	/* Do stuff with the WAV */
		///	.
		///	.
		///	/* Free It */
		///	SDL_FreeWAV(wav_buffer);
		///	</code>
		/// </example>
		/// <param name="file"></param>
		/// <param name="spec"></param>
		/// <param name="audio_buf"></param>
		/// <param name="audio_len"></param>
		/// <returns>IntPtr to SDL_AudioApec</returns>
		/// <seealso cref="SDL_AudioSpec"/>
		/// <seealso cref="SDL_OpenAudio"/>
		/// <seealso cref="SDL_FreeWAV"/>
		public static IntPtr SDL_LoadWAV(string file, out IntPtr spec, out IntPtr audio_buf, out int audio_len)
		{
			IntPtr result = SDL_LoadWAV_RW(SDL_RWFromFile(file, "rb"), 1, out spec,  out audio_buf, out audio_len);
			Console.WriteLine("audio_len: " + audio_len.ToString());
			return result;

		}
		#endregion IntPtr SDL_LoadWAV(string file, out  spec, out byte[] audio_buf, out IntPtr audio_len)

		#region void SDL_FreeWAV(byte[] audio_buf)
		/// <summary>
		/// Frees previously opened WAV data.
		/// </summary>
		/// <remarks>
		/// After a WAVE file has been opened with <see cref="SDL_LoadWAV"/>
		///  its data can eventually be freed with SDL_FreeWAV. audio_buf is 
		///  a pointer to the buffer created by SDL_LoadWAV.
		///  <p>
		/// <code>
		/// void SDL_FreeWAV(Uint8 *audio_buf)
		/// </code></p>
		/// </remarks>
		/// <param name="audio_buf"></param>
		/// <seealso cref="SDL_LoadWAV"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_FreeWAV(ref IntPtr audio_buf);
		#endregion void SDL_FreeWAV(byte[] audio_buf)

		#region int SDL_BuildAudioCVT(...)
		/// <summary>
		/// Initializes a SDL_AudioCVT structure for conversion
		/// </summary>
		/// <remarks>
		/// Before an <see cref="SDL_AudioCVT"/> structure can be used to 
		/// convert audio data it must be initialized with source and 
		/// destination information. 
		/// <p>src_format and dst_format are the source and destination 
		/// format of the conversion. (For information on audio formats 
		/// see <see cref="SDL_AudioSpec"/>). src_channels and dst_channels
		///  are the number of channels in the source and destination formats.
		///   Finally, src_rate and dst_rate are the frequency or 
		///   samples-per-second of the source and destination formats.
		///    Once again, see <see cref="SDL_AudioSpec"/>.</p>
		///    <p>
		/// <code>
		/// int SDL_BuildAudioCVT(SDL_AudioCVT *cvt, Uint16 src_format, Uint8 src_channels, int src_rate, Uint16 dst_format, Uint8 dst_channels, int dst_rate)
		/// </code></p>
		/// </remarks>
		/// <example>
		/// See <see cref="SDL_ConvertAudio"/>.
		/// </example>
		/// <param name="cvt"></param>
		/// <param name="src_format"></param>
		/// <param name="src_channels"></param>
		/// <param name="src_rate"></param>
		/// <param name="dst_format"></param>
		/// <param name="dst_channels"></param>
		/// <param name="dst_rate"></param>
		/// <returns>
		/// Returns -1 if the filter could not be built or 1 if it could.
		/// </returns>
		/// <seealso cref="SDL_ConvertAudio"/>
		/// <seealso cref="SDL_AudioCVT"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_BuildAudioCVT(IntPtr cvt,
			short src_format, byte src_channels, int src_rate,
			byte dst_format, byte dst_channels, int dst_rate);
		#endregion int SDL_BuildAudioCVT(...)

		#region int SDL_ConvertAudio(IntPtr cvt)
		/// <summary>
		/// Convert audio data to a desired audio format.
		/// </summary>
		/// <remarks>
		/// SDL_ConvertAudio takes one parameter, cvt, which was previously 
		/// initialized. Initilizing a <see cref="SDL_AudioCVT"/> is a two 
		/// step process. First of all, the structure must be passed to 
		/// <see cref="SDL_BuildAudioCVT"/> along with source and destination 
		/// format parameters. Secondly, the cvt->buf and cvt->len fields must
		///  be setup. cvt->buf should point to the audio data and cvt-&gt;len 
		///  should be set to the length of the audio data in bytes. 
		///  Remember, the length of the buffer pointed to by buf show be 
		///  len*len_mult bytes in length.
		/// <p>Once the SDL_AudioCVTstructure is initilized then we can pass 
		/// it to SDL_ConvertAudio, which will convert the audio data pointer
		///  to by cvt->buf. If SDL_ConvertAudio returned 0 then the conversion
		///   was completed successfully, otherwise -1 is returned.</p>
		/// <p>If the conversion completed successfully then the converted
		///  audio data can be read from cvt->buf. The amount of valid, 
		///  converted, audio data in the buffer is equal to 
		///  cvt-&gt;len*cvt-&gt;len_ratio.</p>
		/// <p>
		/// <code>
		/// int SDL_ConvertAudio(SDL_AudioCVT *cvt)
		/// </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// /* Converting some WAV data to hardware format */
		///		void my_audio_callback(void *userdata, Uint8 *stream, int len);
		///
		///		SDL_AudioSpec *desired, *obtained;
		///		SDL_AudioSpec wav_spec;
		///		SDL_AudioCVT  wav_cvt;
		///		Uint32 wav_len;
		///		Uint8 *wav_buf;
		///		int ret;
		///
		///		/* Allocated audio specs */
		///		desired = malloc(sizeof(SDL_AudioSpec));
		///		obtained = malloc(sizeof(SDL_AudioSpec));
		///
		///		/* Set desired format */
		///		desired-&gt;freq=22050;
		///		desired-&gt;format=AUDIO_S16LSB;
		///		desired-&gt;samples=8192;
		///		desired-&gt;callback=my_audio_callback;
		///		desired-&gt;userdata=NULL;
		///
		///		/* Open the audio device */
		///		if ( SDL_OpenAudio(desired, obtained) &lt; 0 )
		///	{
		///		fprintf(stderr, "Couldn't open audio: %s\n", SDL_GetError());
		///		exit(-1);
		///	}
		///       
		///	free(desired);
		///
		///	/* Load the test.wav */
		///	if( SDL_LoadWAV("test.wav", &amp;wav_spec, &amp;wav_buf, &amp;wav_len) == NULL )
		///{
		///	fprintf(stderr, "Could not open test.wav: %s\n", SDL_GetError());
		///	SDL_CloseAudio();
		///	free(obtained);
		///	exit(-1);
		///                                           
		///	/* Build AudioCVT */
		///	ret = SDL_BuildAudioCVT(&amp;wav_cvt,
		///	wav_spec.format, wav_spec.channels, wav_spec.freq,
		///	obtained-&gt;format, obtained-&gt;channels, obtained-&gt;freq);
		///
		///	/* Check that the convert was built */
		///	if(ret==-1)
		///{
		///	fprintf(stderr, "Couldn't build converter!\n");
		///	SDL_CloseAudio();
		///	free(obtained);
		///	SDL_FreeWAV(wav_buf);
		///}
		///
		///	/* Setup for conversion */
		///	wav_cvt.buf = malloc(wav_len * wav_cvt.len_mult);
		///	wav_cvt.len = wav_len;
		///	memcpy(wav_cvt.buf, wav_buf, wav_len);
		///
		///	/* We can delete to original WAV data now */
		///	SDL_FreeWAV(wav_buf);
		///
		///	/* And now we're ready to convert */
		///	SDL_ConvertAudio(&amp;wav_cvt);
		///
		///	/* do whatever */
		///	.
		///	.
		///	.
		///	.
		/// </code>
		/// </example>
		/// <param name="cvt">
		/// IntPtr to <see cref="SDL_AudioCVT"/> struct.
		/// </param>
		/// <returns>
		/// If SDL_ConvertAudio returned 0 then the conversion 
		/// was completed successfully, otherwise -1 is returned.
		/// </returns>
		/// <seealso cref="SDL_AudioCVT"/>
		/// <seealso cref="SDL_BuildAudioCVT"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_ConvertAudio(IntPtr cvt);
		#endregion int SDL_ConvertAudio(IntPtr cvt)

		#region void SDL_MixAudio(IntPtr dst, IntPtr src, int len, int volume)
		/// <summary>
		/// Mix audio data.
		/// </summary>	
		/// <remarks>
		/// This function takes two audio buffers of len bytes each of the 
		/// playing audio format and mixes them, performing addition, 
		/// volume adjustment, and overflow clipping. The volume ranges
		///  from 0 to SDL_MIX_MAXVOLUME and should be set to the maximum
		///   value for full audio volume. Note this does not change hardware
		///    volume. This is provided for convenience -- you can mix your 
		///    own audio data.
		/// <p>Note: Do not use this function for mixing together more than two
		///  streams of sample data. The output from repeated application of 
		///  this function may be distorted by clipping, because there is no 
		///  accumulator with greater range than the input (not to mention this
		///   being an inefficient way of doing it). Use mixing functions from 
		///   SDL_mixer, OpenAL, or write your own mixer instead.</p>
		/// <p>
		/// <code>
		/// void SDL_MixAudio(Uint8 *dst, Uint8 *src, Uint32 len, int volume)
		/// </code></p>
		/// </remarks>	
		/// <param name="dst"></param>
		/// <param name="src"></param>
		/// <param name="len"></param>
		/// <param name="volume"></param>
		/// <seealso cref="SDL_OpenAudio"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_MixAudio(
			IntPtr dst, IntPtr src, int len, int volume);
		#endregion void SDL_MixAudio(IntPtr dst, IntPtr src, int len, int volume)

		#region void SDL_LockAudio()
		/// <summary>
		/// Lock out the callback function.
		/// </summary>
		/// <remarks>
		/// The lock manipulated by these functions protects the callback 
		/// function. During a LockAudio period, you can be guaranteed 
		/// that the callback function is not running. Do not call these 
		/// from the callback function or you will cause deadlock.
		/// <p>Binds to C-function call in SDL_audio.h:
		/// <code>
		/// void SDL_LockAudio(void);
		/// </code>
		/// </p>
		/// </remarks>
		/// <seealso cref="SDL_OpenAudio"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_LockAudio();
		#endregion void SDL_LockAudio()

		#region void SDL_UnlockAudio()
		/// <summary>
		/// Unlock the callback function
		/// </summary>
		/// <remarks>
		/// Unlocks a previous <see cref="SDL_LockAudio"/> call.
		/// <p>Binds to C-function call in SDL_audio.h:
		/// <code>
		/// void SDL_UnlockAudio(void)
		/// </code>
		/// </p>
		/// </remarks>
		/// <seealso cref="SDL_OpenAudio"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_UnlockAudio();
		#endregion void SDL_UnlockAudio()

		#region void SDL_CloseAudio()
		/// <summary>
		/// Shuts down audio processing and closes the audio device.
		/// </summary>
		/// <remarks>
		/// This function shuts down audio processing and closes the audio 
		/// device.
		/// <p>Binds to C-function call in SDL_audio.h:
		/// <code>
		/// void SDL_CloseAudio(void)
		/// </code>
		/// </p>
		/// </remarks>
		/// <seealso cref="SDL_OpenAudio"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_CloseAudio();
		#endregion void SDL_CloseAudio()
		#endregion SDL_audio.h

		#region SDL_byteorder.h
		#region int SDL_BYTEORDER
		/// <summary>
		/// Returns the endianness of the host system. 
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <returns>Returns the endianness of the host system.</returns>
		public static int SDL_BYTEORDER 
		{
			get 
			{
				if (BitConverter.IsLittleEndian) 
				{
					return SDL_LIL_ENDIAN;
				}
				else 
				{
					return SDL_BIG_ENDIAN;
				}
			}
		}
		#endregion int SDL_BYTEORDER
		#endregion SDL_byteorder.h

		#region SDL_cdrom.h
		#region int CD_INDRIVE(CDstatus status)
		/// <summary>
		/// Given a status, returns true if there's a disk in the drive.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-macro call in SDL_cdrom.h:
		/// <code>#define CD_INDRIVE(status)	((int)status > 0)
		/// </code></p>
		/// </remarks>
		/// <param name="status">CDstatus enum</param>
		/// <returns>Returns 1 if true and 0 if false</returns>
		public static int CD_INDRIVE(int status)
		{
			if ((int) status > 0)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
		#endregion int CD_INDRIVE(CDstatus status)

		#region void FRAMES_TO_MSF(int frames, int M, int S, int F)
		/// <summary>
		/// Conversion function from frames to Minute/Second/Frames.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-macro call in SDL_cdrom.h:
		/// <code>#define FRAMES_TO_MSF(f, M,S,F)	{
		/// int value = f;							
		///		*(F) = value%CD_FPS;						
		///		value /= CD_FPS;						
		///		*(S) = value%60;						
		///		value /= 60;							
		///		*(M) = value;							
		///	}
		/// </code></p>
		/// </remarks>
		/// <param name="frames">Frames</param>
		/// <param name="M">Minutes</param>
		/// <param name="S">Seconds</param>
		/// <param name="F">Frames (remainder)</param>
		/// <seealso cref="CD_FPS"/>
		public static void FRAMES_TO_MSF(int frames, out int M, out int S, out int F)
		{
			F = 0;
			S = 0;
			M = 0;
			if (frames != 0)
			{
				F = frames%CD_FPS;
				frames /= CD_FPS;
				S = frames%60;
				frames /= 60;
				M = frames;
			}
		}
		#endregion void FRAMES_TO_MSF(int frames, int M, int S, int F)

		#region int MSF_TO_FRAMES(int M, int S, int F)
		/// <summary>
		/// Conversion function from Minute/Second/Frames to frames.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-macro call in SDL_cdrom.h:
		/// <code>#define MSF_TO_FRAMES(M, S, F)	((M)*60*CD_FPS+(S)*CD_FPS+(F))
		/// </code></p>
		/// </remarks>
		/// <param name="M">Minutes</param>
		/// <param name="S">Seconds</param>
		/// <param name="F">Frames</param>
		/// <seealso cref="CD_FPS"/>
		public static int MSF_TO_FRAMES(int M, int S, int F)
		{
			return (M * 60 * CD_FPS) + (S * CD_FPS) + F;
		}
		#endregion int MSF_TO_FRAMES(int M, int S, int F)

		#region int SDL_CDNumDrives()
		/// <summary>
		/// Returns the number of CD-ROM drives on the 
		/// system.
		/// </summary>
		/// <remarks>
		/// Returns the number of CD-ROM drives on the system, 
		/// or -1 if SDL_Init() has not been called with the SDL_INIT_CDROM 
		/// flag.
		/// <p>Binds to C-function call in SDL_cdrom.h:
		/// <code>int SDL_CDNumDrives(void)
		/// </code></p>
		/// </remarks>
		/// <returns>Returns the number of CD-ROM drives on the system, 
		/// or -1 if SDL_Init() has not been called with the SDL_INIT_CDROM 
		/// flag.
		/// </returns>
		/// <seealso cref="SDL_CDOpen"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDNumDrives();
		#endregion int SDL_CDNumDrives()

		#region string SDL_CDName(int drive)
		/// <summary>
		/// Returns a human-readable, system-dependent identifier for the 
		/// CD-ROM.
		/// </summary>
		/// <remarks>
		/// Drive is the index of the drive. Drive indices start to 0 and end 
		/// at SDL_CDNumDrives()-1.
		/// <p>Binds to C-function in SDL_cdrom.h
		/// <code>const char *SDL_CDName(int drive);
		/// </code></p>
		/// </remarks>
		/// <example>
		/// Example:
		/// "/dev/cdrom"
		/// "E:"
		/// "/dev/disk/ide/1/master"
		/// </example>
		/// <param name="drive"></param>
		/// <returns>
		/// Returns a human-readable, system-dependent identifier for the 
		/// CD-ROM.
		/// </returns>
		/// <seealso cref="SDL_CDNumDrives"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern string SDL_CDName(int drive);
		#endregion string SDL_CDName(int drive)

		#region IntPtr SDL_CDOpen(int drive)
		/// <summary>
		/// Opens a CD-ROM drive for access.
		/// </summary>
		/// <remarks>
		/// Opens a CD-ROM drive for access. It returns a 
		/// <see cref="SDL_CD"/> structure
		///  on success, or NULL if the drive was invalid or busy. This 
		///  newly opened CD-ROM becomes the default CD used when other 
		///  CD functions are passed a NULL CD-ROM handle. 
		/// <p>Drives are numbered starting with 0. Drive 0 is the system
		///  default CD-ROM.</p>
		///  <p>Binds to C-function in SDL_cdrom.h
		///  <code>SDL_CD *SDL_CDOpen(int drive)
		///  </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// SDL_CD *cdrom;
		///		int cur_track;
		///		int min, sec, frame;
		///		SDL_Init(SDL_INIT_CDROM);
		///		atexit(SDL_Quit);
		///
		///		/* Check for CD drives */
		///		if(!SDL_CDNumDrives())
		///			{
		///		/* None found */
		///		fprintf(stderr, "No CDROM devices available\n");
		///		exit(-1);
		///	}
		///
		///	/* Open the default drive */
		///	cdrom=SDL_CDOpen(0);
		///
		///	/* Did if open? Check if cdrom is NULL */
		///	if(!cdrom)
		///{
		///	fprintf(stderr, "Couldn't open drive: %s\n", SDL_GetError());
		///	exit(-1);
		///}
		///
		///	/* Print Volume info */
		///	printf("Name: %s\n", SDL_CDName(0));
		///	printf("Tracks: %d\n", cdrom->numtracks);
		///	for(cur_track=0;cur_track &lt; cdrom-&gt;numtracks; cur_track++)
		///{
		///	FRAMES_TO_MSF(cdrom->track[cur_track].length, &amp;min, &amp;sec, &amp;frame);
		///	printf("\tTrack %d: Length %d:%d\n", cur_track, min, sec);
		///}
		///
		///SDL_CDClose(cdrom);
		///</code>
		/// </example>
		/// <param name="drive"></param>
		/// <returns>It returns a SDL_CD structure
		///  on success, or NULL if the drive was invalid or busy.
		///  </returns>
		///  <seealso cref="SDL_CD"/>
		///  <seealso cref="SDL_CDtrack"/>
		///  <seealso cref="SDL_CDClose"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_CDOpen(int drive);
		#endregion IntPtr SDL_CDOpen(int drive)

		#region CDstatus SDL_CDStatus(IntPtr cdrom)
		/// <summary>
		/// This function returns the current status of the given drive.
		/// </summary>
		/// <remarks>
		/// If the drive has a CD in it, 
		/// the table of contents of the CD and current play position 
		/// of the CD will be stored in the SDL_CD structure.
		/// <p>
		/// The macro CD_INDRIVE is provided for convenience, 
		/// and given a status returns true if there's a disk 
		/// in the drive.</p>
		/// <p>Note: SDL_CDStatus also updates the <see cref="SDL_CD"/> 
		/// structure passed to it.</p>
		/// <p>Binds to C-function in SDL_cdrom.h
		/// <code>CDstatus SDL_CDStatus(SDL_CD *cdrom);
		/// </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// int playTrack(int track)
		///	{
		///		int playing = 0;
		///
		///		if ( CD_INDRIVE(SDL_CDStatus(cdrom)) ) 
		///	{
		///		/* clamp to the actual number of tracks on the CD */
		///		if (track >= cdrom->numtracks) 
		///	{
		///		track = cdrom->numtracks-1;
		///	}
		///
		///	if ( SDL_CDPlayTracks(cdrom, track, 0, 1, 0) == 0 ) 
		///{
		///	playing = 1;
		///}
		///}
		///return playing;
		///}
		///</code>
		/// </example>
		/// <param name="cdrom"></param>
		/// <returns>CDstatus enum</returns>
		/// <seealso cref="SDL_CD"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDStatus(IntPtr cdrom);
		#endregion CDstatus SDL_CDStatus(IntPtr cdrom)

		#region int SDL_CDPlay(IntPtr cdrom, int start, int length)
		/// <summary>
		/// Play a CD. 
		/// </summary>
		/// <remarks>
		/// Plays the given cdrom, starting a frame start for length frames.
		/// <p>Binds to C-function in SDL_cdrom.h
		/// <code>int SDL_CDPlay(SDL_CD *cdrom, int start, int length)
		/// </code></p>
		/// </remarks>
		/// <param name="cdrom"></param>
		/// <param name="start"></param>
		/// <param name="length"></param>
		/// <returns>It returns 0, or -1 if there was an error.</returns>
		/// <seealso cref="SDL_CDPlayTracks"/>
		/// <seealso cref="SDL_CDStop"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDPlay(IntPtr cdrom, int start, 
			int length);
		#endregion int SDL_CDPlay(IntPtr cdrom, int start, int length)

		#region int SDL_CDPlayTracks(...)
		/// <summary>
		/// Play the given CD track(s).
		/// </summary>
		/// <remarks>
		/// SDL_CDPlayTracks plays the given CD starting at track start_track,
		///  for ntracks tracks. 
		/// <p>start_frame is the frame offset, from the beginning of the 
		/// start_track, at which to start. nframes is the frame offset, 
		/// from the beginning of the last track (start_track+ntracks), at
		///  which to end playing.</p>
		/// <p>SDL_CDPlayTracks should only be called after calling 
		/// <see cref="SDL_CDStatus"/> to get track information about 
		/// the CD.</p>
		/// <p>Note: Data tracks are ignored.</p>
		/// <p>Binds to C-function in SDL_cdrom.h
		/// <code>int SDL_CDPlayTracks(SDL_CD *cdrom, int start_track, int start_frame, int ntracks, int nframes))
		/// </code></p>
		/// </remarks>
		/// <example>
		/// <code>
		///		/* assuming cdrom is a previously opened device */
		///		/* Play the entire CD */
		///		if(CD_INDRIVE(SDL_CDStatus(cdrom)))
		///		SDL_CDPlayTracks(cdrom, 0, 0, 0, 0);
		///
		///		/* Play the first track */
		///		if(CD_INDRIVE(SDL_CDStatus(cdrom)))
		///		SDL_CDPlayTracks(cdrom, 0, 0, 1, 0);
		///
		///		/* Play first 15 seconds of the 2nd track */
		///		if(CD_INDRIVE(SDL_CDStatus(cdrom)))
		///		SDL_CDPlayTracks(cdrom, 1, 0, 0, CD_FPS*15);
		///	</code>
		/// </example>
		/// <param name="cdrom"></param>
		/// <param name="start_track"></param>
		/// <param name="start_frame"></param>
		/// <param name="ntracks"></param>
		/// <param name="nframes"></param>
		/// <returns>Returns 0, or -1 if there was an error.</returns>
		/// <seealso cref="SDL_CDPlay"/>
		/// <seealso cref="SDL_CDStatus"/>
		/// <seealso cref="SDL_CD"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDPlayTracks(IntPtr cdrom, 
			int start_track, int start_frame, int ntracks, 
			int nframes);
		#endregion int SDL_CDPlayTracks(...)

		#region int SDL_CDPause(IntPtr cdrom)
		/// <summary>
		/// Pauses a CDROM.
		/// </summary>
		/// <remarks>
		/// Pauses play on the given cdrom.
		/// <p>Binds to C-function in SDL_cdrom.h
		/// <code>int SDL_CDPause(SDL_CD *cdrom)
		/// </code></p>
		/// </remarks>
		/// <param name="cdrom"></param>
		/// <returns>Returns 0, or -1 on error.</returns>
		/// <seealso cref="SDL_CDPlay"/>
		/// <seealso cref="SDL_CDResume"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDPause(IntPtr cdrom);
		#endregion int SDL_CDPause(IntPtr cdrom)

		#region int SDL_CDResume(IntPtr cdrom)
		/// <summary>
		/// Resumes a CDROM.
		/// </summary>
		/// <remarks>
		/// Resumes play on the given cdrom.
		/// <p>Binds to C-function in SDL_cdrom.h
		/// <code>int SDL_CDResume(SDL_CD *cdrom)
		/// </code></p>
		/// </remarks>
		/// <param name="cdrom"></param>
		/// <seealso cref="SDL_CDPlay"/>
		/// <seealso cref="SDL_CDPause"/>
		/// <returns>Returns 0, or -1 on error.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDResume(IntPtr cdrom);
		#endregion int SDL_CDResume(IntPtr cdrom)

		#region int SDL_CDStop(IntPtr cdrom)
		/// <summary>
		/// Stops a CDROM.
		/// </summary>
		/// <remarks>
		/// Stops play on the given cdrom.
		/// <p>Binds to C-function in SDL_cdrom.h
		/// <code>int SDL_CDStop(SDL_CD *cdrom)
		/// </code></p>
		/// </remarks>
		/// <param name="cdrom"></param>
		/// <returns>Returns 0, or -1 on error.</returns>
		/// <seealso cref="SDL_CDPlay"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDStop(IntPtr cdrom);
		#endregion int SDL_CDStop(IntPtr cdrom)

		#region int SDL_CDEject(IntPtr cdrom)
		/// <summary>
		/// Ejects a CDROM.
		/// </summary>
		/// <remarks>
		/// Ejects the given cdrom.
		/// <p>Binds to C-function in SDL_cdrom.h
		/// <code>int SDL_CDEject(SDL_CD *cdrom)
		/// </code></p>
		/// </remarks>
		/// <param name="cdrom"></param>
		/// <returns>Returns 0, or -1 on error.</returns>
		/// <seealso cref="SDL_CD"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDEject(IntPtr cdrom);
		#endregion int SDL_CDEject(IntPtr cdrom)

		#region void SDL_CDClose(IntPtr cdrom)
		/// <summary>
		/// Closes a SDL_CD handle.
		/// </summary>
		/// <remarks>
		/// Closes the given cdrom handle.
		/// <p>Binds to C-function in SDL_cdrom.h
		/// <code>void SDL_CDClose(SDL_CD *cdrom);
		/// </code></p>
		/// </remarks>
		/// <param name="cdrom"></param>
		/// <seealso cref="SDL_CDOpen"/>
		/// <seealso cref="SDL_CD"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_CDClose(IntPtr cdrom);
		#endregion void SDL_CDClose(IntPtr cdrom)
		#endregion SDL_cdrom.h

		// SDL_copying.h -- none

		#region SDL_cpuinfo.h
		#region SDL_bool SDL_HasRDTSC()
		/// <summary>
		///     This function returns true if the CPU has the RDTSC instruction.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_cpuinfo.h:
		///     <code>extern DECLSPEC SDL_bool SDLCALL SDL_HasRDTSC()</code>
		///     </p>
		/// </remarks>
		/// <returns>Returns SDL_TRUE if the CPU has the RDTSC instruction.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_HasRDTSC();
		#endregion SDL_bool SDL_HasRDTSC()

		#region SDL_bool SDL_HasMMX()
		/// <summary>
		///     This function returns true if the CPU has MMX features.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_cpuinfo.h:
		///     <code>extern DECLSPEC SDL_bool SDLCALL SDL_HasMMX()</code>
		///     </p>
		/// </remarks>
		/// <returns>Returns SDL_TRUE if the CPU has MMX features.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_HasMMX();
		#endregion SDL_bool SDL_HasMMX()

		#region SDL_bool SDL_HasMMXExt()
		/// <summary>
		///     This function returns true if the CPU has MMX Ext. features.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_cpuinfo.h:
		///     <code>extern DECLSPEC SDL_bool SDLCALL SDL_HasMMXExt()</code>
		///     </p>
		/// </remarks>
		/// <returns>Returns SDL_TRUE if the CPU has MMX Ext. features.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_HasMMXExt();
		#endregion SDL_bool SDL_HasMMXExt()

		#region SDL_bool SDL_Has3DNow()
		/// <summary>
		///     This function returns true if the CPU has 3DNow features
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_cpuinfo.h:
		///     <code>extern DECLSPEC SDL_bool SDLCALL SDL_SDL_Has3DNow()</code>
		///     </p>
		/// </remarks>
		/// <returns>Returns SDL_TRUE if the CPU has 3DNow features.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_Has3DNow();
		#endregion SDL_bool SDL_Has3DNow()

		#region SDL_bool SDL_HasSSE()
		/// <summary>
		///     This function returns true if the CPU has SSE features
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_cpuinfo.h:
		///     <code>extern DECLSPEC SDL_bool SDLCALL SDL_SDL_HasSSE()</code>
		///     </p>
		/// </remarks>
		/// <returns>Returns SDL_TRUE if the CPU has SSE features.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_HasSSE();
		#endregion SDL_bool SDL_HasSSE()

		#region SDL_bool SDL_HasSSE2()
		/// <summary>
		///     This function returns true if the CPU has SSE2 features
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_cpuinfo.h:
		///     <code>extern DECLSPEC SDL_bool SDLCALL SDL_SDL_HasSSE2()</code>
		///     </p>
		/// </remarks>
		/// <returns>Returns SDL_TRUE if the CPU has SSE2 features.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_HasSSE2();
		#endregion SDL_bool SDL_HasSSE2()

		#region SDL_bool SDL_HasAltiVec()
		/// <summary>
		///     This function returns true if the CPU has AltiVec features
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_cpuinfo.h:
		///     <code>extern DECLSPEC SDL_bool SDLCALL SDL_SDL_HasAltiVec()</code>
		///     </p>
		/// </remarks>
		/// <returns>Returns SDL_TRUE if the CPU has AltiVec features.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_HasAltiVec();
		#endregion SDL_bool SDL_HasAltiVec()

		#endregion SDL_cpuinfo.h

		// SDL_endian.h -- skipped for now, might be useful after SDL_rwops has
		// been implemented.

		#region SDL_error.h
		#region SDL_SetError(string message)
		/// <summary>
		///     Sets an SDL error string.
		/// </summary>
		/// <param name="message">
		///     The error message to set.
		/// </param>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_error.h:
		///     <code>extern DECLSPEC void SDLCALL SDL_SetError(const char *fmt, ...)</code>
		///     </p>
		/// </remarks>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void SDL_SetError(string message);
		#endregion SDL_SetError(string message)

		#region string SDL_GetError()
		/// <summary>
		///     Gets an SDL error string.
		/// </summary>
		/// <returns>
		///     A string containing information about the last internal SDL error.
		/// </returns>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_error.h:
		///     <code>extern DECLSPEC char * SDLCALL SDL_GetError(void)</code>
		///     </p>
		/// </remarks>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern string SDL_GetError();
		#endregion string SDL_GetError()

		#region SDL_ClearError()
		/// <summary>
		///     Clears the SDL error.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Binds to C-function call in SDL_error.h:
		/// <code>extern DECLSPEC void SDLCALL SDL_ClearError(void)</code>
		/// </p>
		/// </remarks>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void SDL_ClearError();
		#endregion SDL_ClearError()
		#endregion SDL_error.h

		#region SDL_events.h
		#region void SDL_PumpEvents()
		/// <summary>
		/// Pumps the event loop, gathering events from the input devices.
		/// </summary>
		/// <remarks>
		/// Pumps the event loop, gathering events from the input devices.
		/// <p>SDL_PumpEvents gathers all the pending input information from
		///  devices and places it on the event queue. Without calls to 
		///  SDL_PumpEvents no events would ever be placed on the queue. 
		///  Often calls the need for SDL_PumpEvents is hidden from the user 
		///  since <see cref="SDL_PollEvent"/> and <see cref="SDL_WaitEvent"/> 
		///  implicitly call SDL_PumpEvents. However, if you are not polling or
		///   waiting for events (e.g. you are filtering them), then you must 
		///   call SDL_PumpEvents to force an event queue update.
		/// </p>
		/// <p>Note: You can only call this function in the thread that set the video mode.</p>
		/// <p>Binds to C-function in SDL_events.h
		/// <code>
		/// void SDL_PumpEvents(void);
		/// </code></p>
		/// </remarks>
		/// <seealso cref="SDL_PollEvent"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_PumpEvents();		
		#endregion void SDL_PumpEvents()

		#region int SDL_PeepEvents(...)
		/// <summary>
		/// Checks the event queue for messages and optionally returns them.
		/// </summary>
		/// <remarks>
		/// Checks the event queue for messages and optionally returns them.
		/// <p>If action is SDL_ADDEVENT, up to numevents events will be added
		///  to the back of the event queue.</p>
		/// <p>If action is SDL_PEEKEVENT, up to numevents events at the front
		///  of the event queue, matching mask, will be returned and 			
		/// will not be removed from the queue.</p>
		/// <p>If action is SDL_GETEVENT, up to numevents events at the front
		///  of the event queue, matching mask, will be returned and 			
		/// will be removed from the queue.</p>
		/// <p>
		/// The mask parameter is an bitwise OR of SDL_EVENTMASK(event_type),
		///  for all event types you are interested in.
		/// </p>
		/// <p>This function is thread-safe.</p>
		/// <p>Binds to C-function in SDL_events.h
		/// <code>
		/// int SDL_PeepEvents(SDL_Event *events, int numevents, SDL_eventaction action, Uint32 mask);
		/// </code></p>
		/// </remarks>
		/// <param name="events"></param>
		/// <param name="numevents"></param>
		/// <param name="action">SDL_eventaction enum</param>
		/// <param name="mask"></param>
		/// <returns>
		/// This function returns the number of events actually stored,
		///  or -1 if there was an error.
		///  </returns>
		///  <seealso cref="SDL_PollEvent"/>
		///  <seealso cref="SDL_Event"/>
		///  <seealso cref="SDL_PushEvent"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_PeepEvents([In, Out]SDL_Event[] events, int numevents, 
			int action, int mask);	
		#endregion int SDL_PeepEvents(...)

		#region int SDL_PollEvent(out SDL_Event sdlEvent)
		/// <summary>
		/// Polls for currently pending events.
		/// </summary>
		/// <remarks>
		/// Polls for currently pending events, 
		/// and returns 1 if there are any pending events, or 0 if there 
		/// are none available. 
		/// <p>If event is not NULL, the next event is removed from the 
		/// queue and stored in that area.</p>
		/// <p>Binds to C-function in SDL_events.h
		/// <code>int SDL_PollEvent(SDL_Event *event);
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// SDL_Event event; /* Event structure */
		///
		///		.
		///		.
		///		.
		///		/* Check for events */
		///		while(SDL_PollEvent(&amp;event))
		///	{  /* Loop until there are no events left on the queue */
		///		switch(event.type)
		///					 {  /* Process the appropiate event type */
		///		case SDL_KEYDOWN:  /* Handle a KEYDOWN event */         
		///		printf("Oh! Key press\n");
		///		break;
		///		case SDL_MOUSEMOTION:
		///		.
		///		.
		///		.
		///		default: /* Report an unhandled event */
		///		printf("I don't know what this event is!\n");
		///	}
		///}
		/// </code>
		/// </example>
		/// <param name="sdlEvent"></param>
		/// <returns>Returns 1 if there are any pending events, 
		/// or 0 if there 
		/// are none available</returns>
		/// <seealso cref="SDL_WaitEvent"/>
		///  <seealso cref="SDL_Event"/>
		///  <seealso cref="SDL_PeepEvents"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_PollEvent(out SDL_Event sdlEvent);
		#endregion int SDL_PollEvent(out SDL_Event sdlEvent)

		#region int SDL_WaitEvent(out SDL_Event evt)
		/// <summary>
		/// Waits indefinitely for the next available event.
		/// </summary>
		/// <remarks>
		/// Waits indefinitely for the next available event, returning 1,
		///  or 0 if there
		/// was an error while waiting for events.  
		/// <p>If 'event' is not NULL, 
		/// the next
		/// event is removed from the queue and stored in that area.</p>
		/// <p>Binds to C-function in SDL_events.h
		/// <code>int SDL_WaitEvent(SDL_Event *event);
		/// </code></p>
		/// </remarks>
		/// <param name="evt"></param>
		/// <returns>Returns 1, or 0 if there was an 
		/// error while waiting for events</returns>
		/// <seealso cref="SDL_Event"/>
		///  <seealso cref="SDL_PollEvent"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_WaitEvent(out SDL_Event evt);
		#endregion int SDL_WaitEvent(out SDL_Event evt)

		#region int SDL_PushEvent(out SDL_Event evt)
		/// <summary>
		/// Pushes an event onto the event queue.
		/// </summary>
		/// <remarks>
		/// The event queue can actually be used as a two way communication 
		/// channel. Not only can events be read from the queue, but the user
		///  can also push their own events onto it. event is a pointer to the
		///   event structure you wish to push onto the queue.
		/// <p>Note: Pushing device input events onto the queue doesn't modify
		///  the state of the device within SDL.</p>
		/// <p>Binds to C-function in SDL_events.h
		/// <code>int SDL_PushEvent(SDL_Event *event)
		/// </code></p></remarks>
		/// <param name="evt"></param>
		/// <returns>
		/// Returns 0 on success or -1 if the event couldn't be pushed.
		/// </returns>
		/// <seealso cref="SDL_Event"/>
		///  <seealso cref="SDL_PollEvent"/>
		///  <seealso cref="SDL_PeepEvents"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_PushEvent(out SDL_Event evt);
		#endregion int SDL_PushEvent(out SDL_Event evt)

		#region void SDL_SetEventFilter(SDL_EventFilter filter)
		/// <summary>
		/// Sets up a filter to process all events before 
		/// they are posted to the event queue.
		/// </summary>
		/// <remarks>
		/// This function sets up a filter to process all events 
		/// before they are posted to the event queue. This is a very powerful
		///  and flexible feature. The filter is prototyped as: 
		/// <p><code>typedef int (*SDL_EventFilter)(const SDL_Event *event);
		/// </code></p>
		/// <p>If the filter returns 1, then the event will be added to the 
		/// internal queue. If it returns 0, then the event will be dropped 
		/// from the queue. This allows selective filtering of dynamically.
		/// </p>
		/// <p>There is one caveat when dealing with the SDL_QUITEVENT event 
		/// type. The event filter is only called when the window manager 
		/// desires to close the application window. If the event filter returns
		///  1, then the window will be closed, otherwise the window will remain
		///   open if possible. If the quit event is generated by an interrupt 
		///   signal, it will bypass the internal queue and be delivered to the
		///    application at the next event poll.</p>
		/// <p>Note: Events pushed onto the queue with 
		/// <see cref="SDL_PushEvent"/> or <see cref="SDL_PeepEvents"/> 
		/// do not get passed through the event filter.</p>
		/// <p>Note: Be Careful! The event filter function may run in a 
		/// different thread so be careful what you do within it.</p>
		/// <p>Binds to C-function in SDL_events.h
		/// <code>void SDL_SetEventFilter(SDL_EventFilter filter);
		/// </code></p>
		/// </remarks>
		/// <param name="filter"></param>
		/// <seealso cref="SDL_Event"/>
		///  <seealso cref="SDL_GetEventFilter"/>
		///  <seealso cref="SDL_PushEvent"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_SetEventFilter(SDL_EventFilter filter);
		#endregion void SDL_SetEventFilter(SDL_EventFilter filter)

		#region SDL_EventFilter SDL_GetEventFilter()
		/// <summary>
		/// Retrieves a pointer to the event filter
		/// </summary>
		/// <remarks>
		/// This function retrieces a pointer to the event filter that was 
		/// previously set using <see cref="SDL_SetEventFilter"/>.
		///  An SDL_EventFilter function is defined as:
		///  <p>
		///  <code>
		///  typedef int (*SDL_EventFilter)(const SDL_Event *event);
		///  </code></p>
		/// <p>Binds to C-function in SDL_events.h
		/// <code>SDL_EventFilter SDL_GetEventFilter(void);
		/// </code></p></remarks>
		/// <returns>
		/// Returns a pointer to the event filter or 
		/// NULL if no filter has been set.
		/// </returns>
		/// <seealso cref="SDL_Event"/>
		///  <seealso cref="SDL_SetEventFilter"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern SDL_EventFilter SDL_GetEventFilter();
		#endregion SDL_EventFilter SDL_GetEventFilter()
		
		#region int SDL_EventState(byte type, int state)
		/// <summary>
		/// This function allows you to set the state of processing certain 
		/// events.
		/// </summary>
		/// <remarks>
		/// This function allows you to set the state of 
		/// processing certain event type's.
		/// <p>If 'state' is set to SDL_IGNORE, that event will be 
		/// automatically
		///  dropped
		/// from the event queue and will not be filtered.</p>
		/// <p>
		/// If 'state' is set to SDL_ENABLE, that event will be processed 
		/// normally.</p>
		/// <p>If 'state' is set to SDL_QUERY, SDL_EventState will return the 
		/// current processing state of the specified event type.</p>
		/// <p>A list of event type's can be found in the 
		/// <see cref="SDL_Event"/>
		///  section.</p>
		/// </remarks>
		/// <param name="type"></param>
		/// <param name="state"></param>
		/// <returns>
		/// Returns 0 on success or -1 if the event couldn't be pushed.
		/// </returns>
		/// <seealso cref="SDL_Event"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_EventState(byte type, int state);
		#endregion int SDL_EventState(byte type, int state)
		#endregion SDL_events.h

		#region SDL_getenv.h
		#region int SDL_putenv(string variable)
		/// <summary>
		///     Puts a variable of the form "name=value" into the environment.
		/// </summary>
		/// <param name="variable">
		///     The "name=value" pair to write to the environment.
		/// </param>
		/// <returns>
		///     Returns -1 on an error or 0 on success.
		/// </returns>
		/// <remarks>
		///     Not all environments have a working putenv(). SDL_putenv() is not available on Windows.
		///     <p>
		///     Binds to C-function call in SDL_getenv.h:
		///     <code>extern DECLSPEC int SDLCALL SDL_putenv(const char *variable)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_getenv" />
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_putenv(string variable);
		#endregion int SDL_putenv(string variable)

		#region string SDL_getenv(string name)
		/// <summary>
		///     Retrieves a variable from the environment.
		/// </summary>
		/// <param name="name">
		///     The name of the environmental variable to retrieve.
		/// </param>
		/// <returns>
		///     The value of the specified environmental variable.
		/// </returns>
		/// <remarks>
		///     Not all environments have a working getenv(). SDL_getenv() is not available on Windows.
		///     <p>Binds to C-function call in SDL_getenv.h:
		///     <code>extern DECLSPEC char * SDLCALL SDL_getenv(const char *name)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_putenv" />
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern string SDL_getenv(string name);
		#endregion string SDL_getenv(string name)
		#endregion SDL_getenv.h

		#region SDL_joystick.h
		#region int SDL_NumJoysticks()
		/// <summary>
		/// Count the number of joysticks attached to the system.
		/// </summary>
		/// <remarks>
		/// Counts the number of joysticks attached to the system.
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>int SDL_NumJoysticks(void)
		/// </code></p>
		/// </remarks>
		/// <returns>
		/// Returns the number of attached joysticks
		/// </returns>
		/// <seealso cref="SDL_JoystickName"/>
		/// <seealso cref="SDL_JoystickOpen"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_NumJoysticks();
		#endregion int SDL_NumJoysticks()

		#region string SDL_JoystickName(int device_index)
		/// <summary>
		/// Get joystick name.
		/// </summary>
		/// <remarks>
		/// Get the implementation dependent name of joystick. 
		/// The index parameter refers to the N'th joystick on the system.
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>const char *SDL_JoystickName(int index)
		/// </code></p>
		/// </remarks>
		/// <param name="device_index"></param>
		/// <returns>
		/// Returns a string containing the joystick name.
		/// </returns>
		/// <example>
		/// <code>
		/// /* Print the names of all attached joysticks */
		///		int num_joy, i;
		///		num_joy=SDL_NumJoysticks();
		///		printf("%d joysticks found\n", num_joy);
		///		for(i=0;i&lt;num_joy;i++)
		///		printf("%s\n", SDL_JoystickName(i));
		/// </code>
		/// </example>
		/// <seealso cref="SDL_JoystickOpen"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern string SDL_JoystickName(int device_index);
		#endregion string SDL_JoystickName(int device_index)

		#region IntPtr SDL_JoystickOpen(int device_index)
		/// <summary>
		/// Open a joystick for use.
		/// </summary>
		/// <remarks>
		/// Opens a joystick for use within SDL. 
		/// The index refers to the N'th joystick in the system. 
		/// A joystick must be opened before it game be used.
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>
		/// </code></p>
		/// </remarks>
		/// <param name="device_index"></param>
		/// <returns>
		/// Returns a IntPtr to a SDL_Joystick structure on success. 
		/// NULL on failure.
		/// </returns>
		/// <example>
		/// <code>
		/// SDL_Joystick *joy;
		/// Check for joystick
		///		if(SDL_NumJoysticks()>0)
		///	{
		///		// Open joystick
		///		joy=SDL_JoystickOpen(0);
		///  
		///		if(joy)
		///	{
		///		printf("Opened Joystick 0\n");
		///		printf("Name: %s\n", SDL_JoystickName(0));
		///		printf("Number of Axes: %d\n", SDL_JoystickNumAxes(joy));
		///		printf("Number of Buttons: %d\n", SDL_JoystickNumButtons(joy));
		///		printf("Number of Balls: %d\n", SDL_JoystickNumBalls(joy));
		///	}
		///	else
		///	printf("Couldn't open Joystick 0\n");
		///  
		///	// Close if opened
		///	if(SDL_JoystickOpened(0))
		///	SDL_JoystickClose(joy);
		///}
		/// </code>
		/// </example>
		/// <seealso cref="SDL_JoystickClose"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_JoystickOpen(int device_index);
		#endregion IntPtr SDL_JoystickOpen(int device_index)

		#region int SDL_JoystickOpened(int device_index)
		/// <summary>
		/// Determine if a joystick has been opened.
		/// </summary>
		/// <remarks>
		/// Determines whether a joystick has already been opened 
		/// within the application. index refers to the N'th joystick
		///  on the system.
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>int SDL_JoystickOpened(int index)
		/// </code></p>
		/// </remarks>
		/// <param name="device_index"></param>
		/// <returns>
		/// Returns 1 if the joystick has been opened, or 0 if it has not.
		/// </returns>
		/// <seealso cref="SDL_JoystickOpen"/>
		/// <seealso cref="SDL_JoystickClose"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickOpened(int device_index);
		#endregion int SDL_JoystickOpened(int device_index)
		
		#region int SDL_JoystickIndex(IntPtr joystick)
		/// <summary>
		/// Get the index of an SDL_Joystick.
		/// </summary>
		/// <remarks>
		/// Returns the index of a given SDL_Joystick structure.
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>int SDL_JoystickIndex(SDL_Joystick *joystick)
		/// </code></p>
		/// </remarks>
		/// <param name="joystick"></param>
		/// <returns>
		/// Index number of the joystick.
		/// </returns>
		/// <seealso cref="SDL_JoystickOpen"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickIndex(IntPtr joystick);
		#endregion int SDL_JoystickIndex(IntPtr joystick)
		
		#region int SDL_JoystickNumAxes(IntPtr joystick)
		/// <summary>
		/// Get the number of joystick axes
		/// </summary>
		/// <remarks>
		/// Return the number of axes available from a 
		/// previously opened SDL_Joystick.
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>int SDL_JoystickNumAxes(SDL_Joystick *joystick)
		/// </code></p>
		/// </remarks>
		/// <param name="joystick"></param>
		/// <returns>
		/// Number of axes.
		/// </returns>
		/// <seealso cref="SDL_JoystickOpen"/>
		/// <seealso cref="SDL_JoystickGetAxis"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickNumAxes(IntPtr joystick);
		#endregion int SDL_JoystickNumAxes(IntPtr joystick)

		#region int SDL_JoystickNumBalls(IntPtr joystick)
		/// <summary>
		/// Get the number of joystick trackballs
		/// </summary>
		/// <remarks>
		/// Return the number of trackballs available from a 
		/// previously opened SDL_Joystick.
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>int SDL_JoystickNumBalls(SDL_Joystick *joystick)
		/// </code></p>
		/// </remarks>
		/// <param name="joystick"></param>
		/// <returns>
		/// Number of trackballs.
		/// </returns>
		/// <seealso cref="SDL_JoystickOpen"/>
		/// <seealso cref="SDL_JoystickGetBall"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickNumBalls(IntPtr joystick);
		#endregion int SDL_JoystickNumBalls(IntPtr joystick)
		
		#region int SDL_JoystickNumHats(IntPtr joystick)
		/// <summary>
		/// Get the number of joystick hats.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>int SDL_JoystickNumHats(SDL_Joystick *joystick);
		/// </code></p>
		/// </remarks>
		/// Return the number of hats available from a previously 
		/// opened SDL_Joystick.
		/// <param name="joystick"></param>
		/// <returns>
		/// Number of hats.
		/// </returns>
		/// <seealso cref="SDL_JoystickOpen"/>
		/// <seealso cref="SDL_JoystickGetHat"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickNumHats(IntPtr joystick);
		#endregion int SDL_JoystickNumHats(IntPtr joystick)
		
		#region int SDL_JoystickNumButtons(IntPtr joystick)
		/// <summary>
		/// Get the number of joystick buttons.
		/// </summary>
		/// <remarks>
		/// Return the number of buttons available from a 
		/// previously opened SDL_Joystick.
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>int SDL_JoystickNumButtons(SDL_Joystick *joystick)
		/// </code></p>
		/// </remarks>
		/// <param name="joystick"></param>
		/// <returns>
		/// Number of buttons.
		/// </returns>
		/// <seealso cref="SDL_JoystickOpen"/>
		/// <seealso cref="SDL_JoystickGetButton"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickNumButtons(IntPtr joystick);
		#endregion int SDL_JoystickNumButtons(IntPtr joystick)

		#region void SDL_JoystickUpdate()
		/// <summary>
		/// Updates the state of all joysticks.
		/// </summary>
		/// <remarks>
		/// Updates the state(position, buttons, etc.) of all open joysticks.
		///  If joystick events have been enabled with 
		///  <see cref="SDL_JoystickEventState"/>
		///   then this is called automatically in the event loop.
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>void SDL_JoystickUpdate(void)
		/// </code></p>
		/// </remarks>
		/// <seealso cref="SDL_JoystickOpen"/>
		/// <seealso cref="SDL_JoystickGetButton"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_JoystickUpdate();
		#endregion void SDL_JoystickUpdate()

		#region int SDL_JoystickEventState(int state)
		/// <summary>
		/// Enable/disable joystick event polling
		/// </summary>
		/// <remarks>
		/// This function is used to enable or disable joystick event 
		/// processing. With joystick event processing disabled you will
		///  have to update joystick states with SDL_JoystickUpdate and 
		///  read the joystick information manually. state is either 
		///  SDL_QUERY, SDL_ENABLE or SDL_IGNORE.
		///  <p>
		///  Note: Joystick event handling is preferred
		///  </p>
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>int SDL_JoystickEventState(int state)
		/// </code></p>
		/// </remarks>
		/// <seealso cref="SDL_JoystickOpen"/>
		/// <seealso cref="SDL_JoystickGetButton"/>
		/// <returns>
		/// If state is SDL_QUERY then the current state is returned,
		///  otherwise the new processing state is returned.
		/// </returns>
		/// <seealso cref="SDL_JoystickUpdate"/>
		/// <seealso cref="SDL_JoyAxisEvent"/>
		/// <seealso cref="SDL_JoyBallEvent"/>
		/// <seealso cref="SDL_JoyButtonEvent"/>
		/// <seealso cref="SDL_JoyHatEvent"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickEventState(int state);
		#endregion int SDL_JoystickEventState(int state)

		#region short SDL_JoystickGetAxis(IntPtr joystick, int axis)
		/// <summary>
		/// Get the current state of an axis.
		/// </summary>
		/// <remarks>
		/// SDL_JoystickGetAxis returns the current state of the 
		/// given axis on the given joystick.
		/// <p>On most modern joysticks the X axis is usually represented 
		/// by axis 0 and the Y axis by axis 1. The value returned by 
		/// SDL_JoystickGetAxis is a signed integer (-32768 to 32768) 
		/// representing the current position of the axis, it maybe necessary
		///  to impose certain tolerances on these values to account for 
		///  jitter. It is worth noting that some joysticks use axes 2 and
		///   3 for extra buttons.</p>
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>Sint16 SDL_JoystickGetAxis(SDL_Joystick *joystick, int axis);
		/// </code></p>
		/// </remarks>
		/// <param name="joystick"></param>
		/// <param name="axis"></param>
		/// <returns>
		/// Returns a short representing the current position of the axis.
		/// </returns>
		/// <example>
		/// <code>
		/// Sint16 x_move, y_move;
		///		SDL_Joystick *joy1;
		///		.
		///		.
		///		x_move=SDL_JoystickGetAxis(joy1, 0);
		///		y_move=SDL_JoystickGetAxis(joy1, 1);
		/// </code>
		/// </example>
		/// <seealso cref="SDL_JoystickNumAxes"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern short SDL_JoystickGetAxis(IntPtr joystick, 
			int axis);
		#endregion short SDL_JoystickGetAxis(IntPtr joystick, int axis)

		#region byte SDL_JoystickGetHat(IntPtr joystick, int hat)
		/// <summary>
		/// Get the current state of a joystick hat
		/// </summary>
		/// <remarks>
		/// SDL_JoystickGetHat returns the current 
		/// state of the given hat on the given joystick.
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>Uint8 SDL_JoystickGetHat(SDL_Joystick *joystick, int hat)
		/// </code></p>
		/// </remarks>
		/// <param name="joystick"></param>
		/// <param name="hat"></param>
		/// <returns>
		/// The current state is returned as a byte which 
		/// is defined as an OR'd combination of one or more of the following:
		/// <code>
		/// SDL_HAT_CENTERED 
		///	SDL_HAT_UP 
		///	SDL_HAT_RIGHT 
		///	SDL_HAT_DOWN 
		///	SDL_HAT_LEFT 
		///	SDL_HAT_RIGHTUP 
		///	SDL_HAT_RIGHTDOWN 
		///	SDL_HAT_LEFTUP 
		/// SDL_HAT_LEFTDOWN 
		/// </code>
		/// </returns>
		/// <seealso cref="SDL_JoystickNumHats"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern byte SDL_JoystickGetHat(IntPtr joystick,
			int hat);
		#endregion byte SDL_JoystickGetHat(IntPtr joystick, int hat)
		
		#region int SDL_JoystickGetBall(...)
		/// <summary>
		/// Get relative trackball motion. 
		/// </summary>
		/// <remarks>
		/// Get the ball axis change.
		/// <p>Trackballs can only return relative motion since 
		/// the last call to SDL_JoystickGetBall, these motion 
		/// deltas a placed into dx and dy.
		/// </p>
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>int SDL_JoystickGetBall(SDL_Joystick *joystick, int ball, int *dx, int *dy);
		/// </code></p>
		/// </remarks>
		/// <param name="joystick"></param>
		/// <param name="ball"></param>
		/// <param name="dx"></param>
		/// <param name="dy"></param>
		/// <returns>
		/// Returns 0 on success or -1 on failure
		/// </returns>
		/// <example>
		/// <code>
		/// int delta_x, delta_y;
		///		SDL_Joystick *joy;
		///		.
		///		.
		///		.
		///		SDL_JoystickUpdate();
		///		if(SDL_JoystickGetBall(joy, 0, &amp;delta_x, &amp;delta_y)==-1)
		///		printf("TrackBall Read Error!\n");
		///		printf("Trackball Delta- X:%d, Y:%d\n", delta_x, delta_y);
		/// </code>
		/// </example>
		/// <seealso cref="SDL_JoystickNumBalls"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickGetBall(IntPtr joystick, 
			int ball, out int dx, out int dy);
		#endregion int SDL_JoystickGetBall(...)
		
		#region byte SDL_JoystickGetButton(IntPtr joystick, int button)
		/// <summary>
		/// Get the current state of a given button on a given joystick.
		/// </summary>
		/// <remarks>
		/// SDL_JoystickGetButton returns the current 
		/// state of the given button on the given joystick.
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>Uint8 SDL_JoystickGetButton(SDL_Joystick *joystick, int button);
		/// </code></p>
		/// </remarks>
		/// <param name="joystick"></param>		
		/// <param name="button"></param>
		/// <returns>
		/// 1 if the button is pressed. Otherwise, 0.
		/// </returns>
		/// <seealso cref="SDL_JoystickNumButtons"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern byte SDL_JoystickGetButton(IntPtr joystick, 
			int button);
		#endregion byte SDL_JoystickGetButton(IntPtr joystick, int button)
		
		#region void SDL_JoystickClose(IntPtr joystick)
		/// <summary>
		/// Closes a previously opened joystick.
		/// </summary>
		/// <remarks>
		/// Close a joystick that was previously opened with 
		/// <see cref="SDL_JoystickOpen"/>.
		/// <p>Binds to C-function in SDL_joystick.h
		/// <code>void SDL_JoystickClose(SDL_Joystick *joystick);
		/// </code></p>
		/// </remarks>
		/// <param name="joystick"></param>
		/// <seealso cref="SDL_JoystickOpen"/>
		/// <seealso cref="SDL_JoystickOpened"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_JoystickClose(IntPtr joystick);
		#endregion void SDL_JoystickClose(IntPtr joystick)
		#endregion SDL_joystick.h

		#region SDL_keyboard.h
		#region int SDL_EnableUNICODE(int enable)
		/// <summary>
		/// Enable UNICODE translation
		/// </summary>
		/// <remarks>
		/// Enables/Disables Unicode keyboard translation.
		/// <p>To obtain the character codes corresponding to received 
		/// keyboard events, Unicode translation must first be turned 
		/// on using this function. The translation incurs a slight overhead
		///  for each keyboard event and is therefore disabled by default. 
		///  For each subsequently received key down event, the unicode member
		///   of the SDL_keysym structure will then contain the corresponding 
		///   character code, or zero for keysyms that do not correspond to 
		///   any character code.</p>
		/// <p>A value of 1 for enable enables Unicode translation; 0 disables
		///  it, and -1 leaves it unchanged (useful for querying the current 
		///  translation mode).</p>
		/// <p>Note that only key press events will be translated, not 
		/// release events.</p>
		/// <p>Binds to C-function in SDL_keyboard.h
		/// <code>int SDL_EnableUNICODE(int enable);
		/// </code></p>
		/// </remarks>
		/// <param name="enable"></param>
		/// <returns>
		/// Returns the previous translation mode (0 or 1).
		/// </returns>
		/// <seealso cref="SDL_keysym"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_EnableUNICODE(int enable);
		#endregion int SDL_EnableUNICODE(int enable)

		#region int SDL_EnableKeyRepeat(int rate, int delay)
		/// <summary>
		/// Set keyboard repeat rate. 
		/// </summary>
		/// <remarks>
		/// Enables or disables the keyboard repeat rate. 
		/// delay specifies how long the key must be pressed before it 
		/// begins repeating, it then repeats at the speed specified by 
		/// interval. Both delay and interval are expressed in milliseconds.
		/// <p>Setting delay to 0 disables key repeating completely. Good 
		/// default values are SDL_DEFAULT_REPEAT_DELAY and 
		/// SDL_DEFAULT_REPEAT_INTERVAL.</p>
		///<p>Binds to C-function in SDL_keyboard.h
		///<code>int SDL_EnableKeyRepeat(int delay, int interval);
		///</code></p>
		/// </remarks>
		/// <param name="rate"></param>
		/// <param name="delay"></param>
		/// <returns>Returns 0 on success and -1 on failure.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_EnableKeyRepeat(int rate, 
			int delay);
		#endregion int SDL_EnableKeyRepeat(int rate, int delay)

		#region IntPtr SDL_GetKeyStateInternal(out int numkeys)
		/// <summary>
		/// Get a snapshot of the current keyboard state. 
		/// </summary>
		/// <remarks>
		/// Returns an array of keystates, indexed by the SDLK_* syms.
		/// Used:
		///	Uint8 *keystate = SDL_GetKeyState(NULL);
		///	if ( keystate[SDLK_RETURN] ) ...  _RETURN_ is pressed.
		///	<p>Binds to C-function in SDL_keyboard.h
		///	<code>Uint8 *SDL_GetKeyState(int *numkeys);
		///	</code></p>
		/// </remarks>
		/// <param name="numkeys"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="SDL_GetKeyState"),
		SuppressUnmanagedCodeSecurity]
		private static extern IntPtr SDL_GetKeyStateInternal(out int numkeys);
		#endregion IntPtr SDL_GetKeyStateInternal(out int numkeys)

		#region byte[] SDL_GetKeyState(out int numkeys)
		/// <summary>
		/// Get a snapshot of the current keyboard state. 
		/// </summary>
		/// <remarks>
		/// Gets a snapshot of the current keyboard state. The current state 
		/// is return as a pointer to an array, the size of this array is 
		/// stored in numkeys. The array is indexed by the SDLK_* symbols. 
		/// A value of 1 means the key is pressed and a value of 0 means its 
		/// not. The pointer returned is a pointer to an internal SDL array 
		/// and should not be freed by the caller.
		/// <p>Note: Use <see cref="SDL_PumpEvents"/> to update the state 
		/// array.</p>
		///	<p>Binds to C-function in SDL_keyboard.h
		///	<code>Uint8 *SDL_GetKeyState(int *numkeys);
		///	</code></p>
		/// </remarks>
		/// <example>
		/// <code>
		/// Uint8 *keystate = SDL_GetKeyState(NULL);
		/// if ( keystate[SDLK_RETURN] ) printf("Return Key Pressed.\n");
		/// </code>
		/// </example>
		/// <param name="numkeys"></param>
		/// <seealso cref="SDL_PumpEvents"/> 
		public static byte[] SDL_GetKeyState(out int numkeys) 
		{
			IntPtr state = SDL_GetKeyStateInternal(out numkeys);

			// update the cached keyboard state
			Marshal.Copy(state, keyboardState, 0, numkeys);

			return keyboardState;
		}
		#endregion byte[] SDL_GetKeyState(out int numkeys)

		#region int SDL_GetModState()
		/// <summary>
		/// Get the state of modifier keys. 
		/// </summary>
		/// <remarks>
		/// Returns the current state of the modifier keys (CTRL, ALT, etc.).
		/// <p>Binds to C-function in SDL_keyboard.h
		/// <code>SDLMod SDL_GetModState(void)
		/// </code></p>
		/// </remarks>
		/// <returns>The return value can be an OR'd combination of the 
		/// SDLMod enum.
		/// </returns>
		/// <seealso cref="SDL_GetKeyState"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GetModState();
		#endregion int SDL_GetModState()
		
		#region void SDL_SetModState(int modstate)
		/// <summary>
		/// Set the current key modifier state. 
		/// </summary>
		/// <remarks>
		/// The inverse of SDL_GetModState, SDL_SetModState allows you to 
		/// impose modifier key states on your application.
		/// <p>Simply pass your desired modifier states into modstate. 
		/// This value my be a logical OR'd combination of 
		/// SDLMod.</p>
		///  <p>Binds to C-function in SDL_keyboard.h
		///  <code>void SDL_SetModState(SDLMod modstate)
		///  </code></p>
		/// </remarks>
		/// <param name="modstate"></param>
		/// <seealso cref="SDL_GetModState"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_SetModState(int modstate);
		#endregion void SDL_SetModState(int modstate)

		#region string SDL_GetKeyName(SDLKey key)
		/// <summary>
		/// Get the name of an SDL virtual keysym
		/// </summary>
		/// <remarks>
		/// Returns the SDL-defined name of the SDLKey key.
		/// <p>Binds to C-function in SDL_keyboard.h
		/// <code>char *SDL_GetKeyName(SDLKey key);
		/// </code></p>
		/// </remarks>
		/// <returns>
		/// Returns the SDL-defined name of the SDLKey key.
		/// </returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern string SDL_GetKeyName(int key);
		#endregion string SDL_GetKeyName(int key)
		#endregion SDL_keyboard.h

		// SDL_keysym.h -- none
		// SDL_loadso.h -- skipped
		// SDL_main.h -- none

		#region SDL_mouse.h
		#region byte SDL_GetMouseState(out int x, out int y)
		/// <summary>
		/// Retrieve the current state of the mouse.
		/// </summary>
		/// <remarks>
		/// The current button state is returned as a button bitmask, w
		/// hich can be tested using the SDL_BUTTON(X) macros, 
		/// and x and y are set to the current mouse cursor position. 
		/// You can pass NULL for either x or y.
		/// <p>Binds to C-function call in SDL_mouse.h:
		/// <code>
		/// Uint8 SDL_GetMouseState(int *x, int *y)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		/// <example>
		/// <code>
		/// SDL_PumpEvents();
		///		if(SDL_GetMouseState(NULL, NULL)&amp;SDL_BUTTON(1))
		///		printf("Mouse Button 1(left) is pressed.\n");
		/// </code>
		/// </example>
		/// <seealso cref="SDL_GetRelativeMouseState"/>
		/// <seealso cref="SDL_PumpEvents"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern byte SDL_GetMouseState(out int x, out int y);
		#endregion byte SDL_GetMouseState(out int x, out int y)

		#region byte SDL_GetRelativeMouseState(out int x, out int y)
		/// <summary>
		/// Retrieve the current state of the mouse.
		/// </summary>
		/// <remarks>
		/// The current button state is returned as a button bitmask, 
		/// which can be tested using the SDL_BUTTON(X) macros, 
		/// and x and y are set to the change in the mouse position 
		/// since the last call to SDL_GetRelativeMouseState or 
		/// since event initialization. You can pass NULL for either x or y.
		///  <p>Binds to C-function call in SDL_mouse.h:
		/// <code>
		/// Uint8 SDL_GetRelativeMouseState(int *x, int *y);
		/// </code>
		/// </p> 
		/// </remarks>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>
		/// The current button state is returned as a button bitmask
		/// </returns>
		/// <seealso cref="SDL_GetMouseState"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern byte SDL_GetRelativeMouseState(out int x, out int y);
		#endregion byte SDL_GetRelativeMouseState(out int x, out int y)

		#region void SDL_WarpMouse(short x, short y)
		/// <summary>
		/// Set the position of the mouse cursor.
		/// </summary>
		/// <remarks>
		/// Set the position of the mouse cursor (generates a mouse 
		/// motion event).
		/// <p>Binds to C-function call in SDL_mouse.h:
		/// <code>
		/// void SDL_WarpMouse(Uint16 x, Uint16 y);
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <seealso cref="SDL_MouseMotionEvent"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_WarpMouse(short x, short y);
		#endregion void SDL_WarpMouse(short x, short y)
		
		#region int SDL_CreateCursor(...)
		/// <summary>
		/// Creates a new mouse cursor.
		/// </summary>
		/// <remarks>
		/// Create a cursor using the specified data and mask (in MSB format). 
		/// The cursor width must be a multiple of 8 bits.
		/// <p>The cursor is created in black and white according to the following:</p>
		/// <code>
		/// data  mask    resulting pixel on screen
		///  0     1       White
		///  1     1       Black
		///  0     0       Transparent
		///  1     0       Inverted color if possible, black if not.
		///  </code>
		/// Cursors created with this function must be freed with 
		/// <see cref="SDL_FreeCursor"/>.
		/// <p>Binds to C-function call in SDL_mouse.h:
		/// <code>
		/// SDL_Cursor *SDL_CreateCursor(Uint8 *data, Uint8 *mask, int w, int h, int hot_x, int hot_y);
		/// </code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// /* Stolen from the mailing list */
		///* Creates a new mouse cursor from an XPM */
		///
		///
		/// /* XPM */
		///static const char *arrow[] = {
		///  /* width height num_colors chars_per_pixel */
		///  "    32    32        3            1",
		///  /* colors */
		/// "X c #000000",
		///  ". c #ffffff",
		///  "  c None",
		///  /* pixels */
		///  "X                               ",
		///  "XX                              ",
		///  "X.X                             ",
		///  "X..X                            ",
		///  "X...X                           ",
		///  "X....X                          ",
		///  "X.....X                         ",
		///  "X......X                        ",
		///  "X.......X                       ",
		///  "X........X                      ",
		///  "X.....XXXXX                     ",
		///  "X..X..X                         ",
		///  "X.X X..X                        ",
		///  "XX  X..X                        ",
		///  "X    X..X                       ",
		///  "     X..X                       ",
		///  "      X..X                      ",
		///  "      X..X                      ",
		///  "       XX                       ",
		///  "                                ",
		///  "                                ",
		///  "                                ",
		///  "                                ",
		///  "                                ",
		///  "                                ",
		///  "                                ",
		///  "                                ",
		///  "                                ",
		///  "                                ",
		///  "                                ",
		///  "                                ",
		///  "                                ",
		///  "0,0"
		///};
		///
		///static SDL_Cursor *init_system_cursor(const char *image[])
		///{
		///  int i, row, col;
		///  Uint8 data[4*32];
		///  Uint8 mask[4*32];
		///  int hot_x, hot_y;
		///
		///  i = -1;
		///  for ( row=0; row&lt;32; ++row ) {
		///    for ( col=0; col&lt;32; ++col ) {
		///      if ( col % 8 ) {
		///        data[i] &lt;&lt;= 1;
		///        mask[i] &lt;&lt;= 1;
		///      } else {
		///        ++i;
		///        data[i] = mask[i] = 0;
		///      }
		///      switch (image[4+row][col]) {
		///        case 'X':
		///          data[i] |= 0x01;
		///          mask[i] |= 0x01;
		///          break;
		///        case '.':
		///          mask[i] |= 0x01;
		///          break;
		///        case ' ':
		///          break;
		///      }
		///    }
		///  }
		///  sscanf(image[4+row], "%d,%d", &amp;hot_x, &amp;hot_y);
		///  return SDL_CreateCursor(data, mask, 32, 32, hot_x, hot_y);
		///}
		/// </code>
		/// </example>
		/// <param name="data"></param>
		/// <param name="h"></param>
		/// <param name="hot_x"></param>
		/// <param name="hot_y"></param>
		/// <param name="mask"></param>
		/// <param name="w"></param>
		/// <returns></returns>
		/// <seealso cref="SDL_FreeCursor"/>
		/// <seealso cref="SDL_SetCursor"/>
		/// <seealso cref="SDL_ShowCursor"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CreateCursor(ref byte data, ref byte mask,
			int w, int h, int hot_x, int hot_y);
		#endregion int SDL_CreateCursor(...)

		#region IntPtr SDL_SetCursor(ref SDL_Cursor cursor)
		/// <summary>
		/// Set the currently active cursor to the specified one. 
		/// </summary>
		/// <remarks>
		/// Sets the currently active cursor to the specified one. 
		/// If the cursor is currently visible, the change will 
		/// be immediately represented on the display.
		/// <p>Binds to C-function call in SDL_mouse.h:
		/// <code>
		/// void *SDL_SetCursor(SDL_Cursor *cursor);
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="cursor"></param>
		/// <returns></returns>
		/// <seealso cref="SDL_GetCursor"/>
		/// <seealso cref="SDL_CreateCursor"/>
		/// <seealso cref="SDL_ShowCursor"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_SetCursor(ref SDL_Cursor cursor);
		#endregion IntPtr SDL_SetCursor(ref SDL_Cursor cursor)

		#region IntPtr SDL_GetCursor()
		/// <summary>
		/// Returns the currently active cursor. 
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_mouse.h:
		/// <code>
		/// SDL_Cursor *SDL_GetCursor(void);
		/// </code>
		/// </p>
		/// </remarks>
		/// <returns>IntPtr to <see cref="SDL_Cursor"/></returns>
		/// <seealso cref="SDL_CreateCursor"/>
		/// <seealso cref="SDL_SetCursor"/>
		/// <seealso cref="SDL_ShowCursor"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_GetCursor();
		#endregion IntPtr SDL_GetCursor()

		#region void SDL_FreeCursor(ref SDL_Cursor cursor)
		/// <summary>
		/// Frees a cursor created with SDL_CreateCursor. 
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_mouse.h:
		/// <code>
		/// void SDL_FreeCursor(SDL_Cursor *cursor)
		/// </code>
		/// </p>
		/// Frees a SDL_Cursor that was created using 
		/// <see cref="SDL_CreateCursor"/>.
		/// </remarks>
		/// <param name="cursor"></param>
		/// <returns></returns>
		/// <seealso cref="SDL_CreateCursor"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_FreeCursor(ref SDL_Cursor cursor);
		#endregion void SDL_FreeCursor(ref SDL_Cursor cursor)
		
		#region int SDL_ShowCursor(int toggle)
		/// <summary>
		/// Toggle whether or not the cursor is shown on the screen.
		/// </summary>
		/// <remarks>
		/// Toggle whether or not the cursor is shown on the screen. 
		/// Passing SDL_ENABLE displays the cursor and passing 
		/// SDL_DISABLE hides it. The current state of the mouse 
		/// cursor can be queried by passing SDL_QUERY, either 
		/// SDL_DISABLE or SDL_ENABLE will be returned.
		/// <p>
		/// The cursor starts off displayed, but can be turned off.
		/// </p>
		/// <p>Binds to C-function call in SDL_mouse.h:
		/// <code>
		/// int SDL_ShowCursor(int toggle);
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="toggle"></param>
		/// <returns></returns>
		/// <seealso cref="SDL_CreateCursor"/>
		/// <seealso cref="SDL_SetCursor"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_ShowCursor(int toggle);
		#endregion int SDL_ShowCursor(int toggle)

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static byte SDL_BUTTON(byte x)
		{
			return (byte)(Sdl.SDL_PRESSED<<(x-1));
		}
		#endregion SDL_mouse.h

		// SDL_mutex.h -- Skipped. Superceded by System.Threading class
		// SDL_name.h -- none
		// SDL_opengl.h -- superceded by Tao.OpenGL
		// SDL_quit.h -- none

		#region SDL_rwops.h
		// This a is bare-minimum implementation. 
		// More bindings may be needed in the future
		#region IntPtr SDL_RWFromFile(string file, string mode)
		/// <summary>
		/// Create SDL_RWops structures from file.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_rwops.h:
		/// <code>
		/// SDL_RWops * SDLCALL SDL_RWFromFile(const char *file, const char *mode)
		/// </code></p></remarks>
		/// <param name="file"></param>
		/// <param name="mode">"rb"</param>
		/// <returns>IntPtr to SDL_RWops</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_RWFromFile(string file, string mode);
		#endregion IntPtr SDL_RWFromFile(string file, string mode)

		#region IntPtr SDL_RWFromMem(byte[] mem, int size)
		/// <summary>
		/// Create SDL_RWops structures from memory.
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_rwops.h:
		/// <code>
		/// SDL_RWops * SDLCALL SDL_RWFromMem(void *mem, int size)
		/// </code></p></remarks>
		/// <param name="mem"></param>
		/// <param name="size"></param>
		/// <returns>IntPtr to SDL_RWops</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_RWFromMem(byte[] mem, int size);
		#endregion IntPtr SDL_RWFromMem(byte[] mem, int size)

		#region IntPtr SDL_RWFromFP(IntPtr fp, int autoclose)
		/// <summary>
		/// SDL_RWFromFP creates a new SDL_RWops structure from a file pointer, opened with stdio. If autoclose is nonzero, the file will be automatically closed when the RWops structure is closed.
		/// </summary>
		/// <remarks>This is not available under Win32, since files opened in an application on that platform cannot be used by a dynamically linked library.</remarks>
		/// <param name="fp"></param>
		/// <param name="autoclose"></param>
		/// <returns>Returns pointer to a new RWops structure, or NULL if it fails.</returns>
		/// <example>
		/// <code>
		/// FILE *fp;
		/// SDL_RWops *rw;
		/// 
		/// fp = fopen("myfile.dat", "rb");
		/// rw = SDL_RWFromFP(fp, 1);
		/// 
		/// // Do things with rw...
		/// SDL_RWclose(rw); // Automatically does an fclose(fp)
		/// </code></example>
		/// <seealso cref="SDL_RWFromFile"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_RWFromFP(IntPtr fp, int autoclose);
		#endregion IntPtr SDL_RWFromFP(IntPtr fp, int autoclose)

		#region IntPtr SDL_RWFromConstMem(IntPtr mem, int size)
		/// <summary>
		/// Prepares a constant memory area for use with RWops.
		/// </summary>
		/// <remarks><see cref="SDL_RWFromConstMem"/> sets up a RWops struct based on a memory area of a certain size. It assumes the memory area is not writable.</remarks>
		/// <param name="mem"></param>
		/// <param name="size"></param>
		/// <returns>Returns a pointer to a new RWops struct, or NULL if it fails.</returns>
		/// <example>
		/// <code>
		/// char bitmap[] = {
		///		66, 77, 86, 2, 0, 0, 0, 0 ...
		///	}
		///	 SDL_RWops *rw;
		///	 SDL_Surface *img;
		///	 
		///	 rw = SDL_RWFromConstMem(bitmap, sizeof(bitmap));
		///	 img = SDL_LoadBMP_RW(rw, 1); // Automatically frees the RWops struct for us
		///	 
		///	 //Do something with img...
		/// </code></example>
		/// <seealso cref="SDL_RWFromMem"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_RWFromConstMem(IntPtr mem, int size);
		#endregion IntPtr SDL_RWFromConstMem(IntPtr mem, int size)

		#region IntPtr SDL_AllocRW()
		/// <summary>
		/// Allocates an empty, unpopulated SDL_RWops structure.
		/// </summary>
		/// <remarks>SDL_AllocRW allocates an empty, unpopulated SDL_RWops structure. You must fill out the fields yourself.</remarks>
		/// <returns>Returns a pointer to the allocated memory on success, or NULL on error.
		/// <p>You must free any memory allocated with <see cref="SDL_AllocRW"/> with <see cref="SDL_FreeRW"/>. Depending on your operating system and compiler, there may be a difference between the malloc() and free() your program uses and the versions SDL calls internally. Trying to mix the two can cause crashing such as segmentation faults.</p></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_AllocRW();
		#endregion IntPtr SDL_AllocRW()

		#region void SDL_FreeRW(IntPtr context)
		/// <summary>
		/// Frees an SDL_RWops structure allocated by <see cref="SDL_AllocRW"/>.
		/// </summary>
		/// <remarks><see cref="SDL_FreeRW"/> frees an SDL_RWops structure previously allocated by <see cref="SDL_AllocRW"/>. Only use it on memory allocated by <see cref="SDL_AllocRW"/>. Any extra memory allocated during creation of the RWops is not freed by <see cref="SDL_FreeRW"/>; the programmer must be responsible for it.</remarks>
		/// <param name="context"></param>
		/// <example>
		/// <code>
		/// #include "SDL_rwops.h"
		/// void dumb_example()
		/// {
		///     SDL_RWops *rw=SDL_AllocRW();
		///     if(rw==NULL) return;
		///     SDL_FreeRW(rw);
		/// }
		/// </code></example>
		/// <seealso cref="SDL_AllocRW"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_FreeRW(IntPtr context);
		#endregion void SDL_FreeRW(IntPtr context);

		#endregion SDL_rwops.h

		#region SDL_syswm.h
		/// <summary>
		///	Gives you custom hooks into the window manager information.
		/// </summary>
		/// <remarks>
		/// This function gives you custom hooks into the window manager information.
		/// It fills the structure pointed to by 'info' with custom information and
		/// returns 1 if the function is implemented.  If it's not implemented, or
		/// the version member of the 'info' structure is invalid, it returns 0. 
		/// 
		/// You typically use this function like this:
		/// SDL_SysWMInfo info;
		/// SDL_VERSION(&amp;info.version);
		/// if ( SDL_GetWMInfo(&amp;info) ) { ... }
		/// <p>Binds to C-function call in SDL_rwops.h:
		/// <code>extern DECLSPEC int SDLCALL SDL_GetWMInfo(SDL_SysWMinfo *info)</code>
		///	</p>
		/// </remarks>
		/// <param name="info">
		/// 	IntPtr to SDL_SysWMinfo struct
		/// </param>
		/// <returns>
		/// It fills the structure pointed to by 'info' 
		/// with custom information and
		/// returns 1 if the function is implemented.  If it's not implemented, or
		/// the version member of the 'info' structure is invalid, it returns 0.
		/// </returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GetWMInfo(out Sdl.SDL_SysWMinfo_Unix info);

		/// <summary>
		///	Gives you custom hooks into the window manager information.
		/// </summary>
		/// <remarks>
		/// This function gives you custom hooks into the window manager information.
		/// It fills the structure pointed to by 'info' with custom information and
		/// returns 1 if the function is implemented.  If it's not implemented, or
		/// the version member of the 'info' structure is invalid, it returns 0. 
		/// 
		/// You typically use this function like this:
		/// SDL_SysWMInfo info;
		/// SDL_VERSION(&amp;info.version);
		/// if ( SDL_GetWMInfo(&amp;info) ) { ... }
		/// <p>Binds to C-function call in SDL_rwops.h:
		/// <code>extern DECLSPEC int SDLCALL SDL_GetWMInfo(SDL_SysWMinfo *info)</code>
		///	</p>
		/// </remarks>
		/// <param name="info">
		/// 	IntPtr to SDL_SysWMinfo struct
		/// </param>
		/// <returns>
		/// It fills the structure pointed to by 'info' 
		/// with custom information and
		/// returns 1 if the function is implemented.  If it's not implemented, or
		/// the version member of the 'info' structure is invalid, it returns 0.
		/// </returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GetWMInfo(out Sdl.SDL_SysWMinfo_Windows info);

		/// <summary>
		///	Gives you custom hooks into the window manager information.
		/// </summary>
		/// <remarks>
		/// This function gives you custom hooks into the window manager information.
		/// It fills the structure pointed to by 'info' with custom information and
		/// returns 1 if the function is implemented.  If it's not implemented, or
		/// the version member of the 'info' structure is invalid, it returns 0. 
		/// 
		/// You typically use this function like this:
		/// SDL_SysWMInfo info;
		/// SDL_VERSION(&amp;info.version);
		/// if ( SDL_GetWMInfo(&amp;info) ) { ... }
		/// <p>Binds to C-function call in SDL_rwops.h:
		/// <code>extern DECLSPEC int SDLCALL SDL_GetWMInfo(SDL_SysWMinfo *info)</code>
		///	</p>
		/// </remarks>
		/// <param name="info">
		/// 	IntPtr to SDL_SysWMinfo struct
		/// </param>
		/// <returns>
		/// It fills the structure pointed to by 'info' 
		/// with custom information and
		/// returns 1 if the function is implemented.  If it's not implemented, or
		/// the version member of the 'info' structure is invalid, it returns 0.
		/// </returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GetWMInfo(out Sdl.SDL_SysWMinfo_RiscOS info);

		/// <summary>
		///	Gives you custom hooks into the window manager information.
		/// </summary>
		/// <remarks>
		/// This function gives you custom hooks into the window manager information.
		/// It fills the structure pointed to by 'info' with custom information and
		/// returns 1 if the function is implemented.  If it's not implemented, or
		/// the version member of the 'info' structure is invalid, it returns 0. 
		/// 
		/// You typically use this function like this:
		/// SDL_SysWMInfo info;
		/// SDL_VERSION(&amp;info.version);
		/// if ( SDL_GetWMInfo(&amp;info) ) { ... }
		/// <p>Binds to C-function call in SDL_rwops.h:
		/// <code>extern DECLSPEC int SDLCALL SDL_GetWMInfo(SDL_SysWMinfo *info)</code>
		///	</p>
		/// </remarks>
		/// <param name="info">
		/// 	IntPtr to SDL_SysWMinfo struct
		/// </param>
		/// <returns>
		/// It fills the structure pointed to by 'info' 
		/// with custom information and
		/// returns 1 if the function is implemented.  If it's not implemented, or
		/// the version member of the 'info' structure is invalid, it returns 0.
		/// </returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GetWMInfo(out Sdl.SDL_SysWMinfo info);
		#endregion SDL_syswm.h

		// SDL_thread.h -- skipped. Superceded by System.Threading class

		#region SDL_timer.h
		#region int SDL_GetTicks()
		/// <summary>
		///     Get the number of milliseconds since the SDL library initialization.
		/// </summary>
		/// <returns>
		///     The number of milliseconds since SDL was initialized.
		/// </returns>
		/// <remarks>
		///     Note that this value wraps if the program runs for more than ~49 days.
		///     <p>
		///     Binds to C-function call in SDL_timer.h:
		///     <code>extern DECLSPEC Uint32 SDLCALL SDL_GetTicks(void)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_Delay" />
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GetTicks();
		#endregion int SDL_GetTicks()

		#region SDL_Delay(int ms)
		/// <summary>
		///     Wait a specified number of milliseconds before returning.
		/// </summary>
		/// <param name="ms">
		///     The number of milliseconds to wait.
		/// </param>
		/// <remarks>
		///     <b>SDL_Delay</b> will wait at least the specified time, but possible longer due
		///     to OS scheduling.  Count on a delay granularity of at least 10 ms.  Some
		///     platforms have shorter clock ticks but this is the most common.
		///     <p>
		///     Binds to C-function call in SDL_timer.h:
		///     <code>extern DECLSPEC void SDLCALL SDL_Delay(Uint32 ms)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_AddTimer" />
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void SDL_Delay(int ms);
		#endregion SDL_Delay(int ms)

		#region int SDL_SetTimer(int interval, SDL_TimerCallback callback)
		/// <summary>
		///     Set a callback to run after the specified number of milliseconds has elapsed.
		/// </summary>
		/// <param name="interval">
		///     The timer interval.
		/// </param>
		/// <param name="callback">
		///     The callback to run.
		/// </param>
		/// <returns>
		///     The next timer interval.
		/// </returns>
		/// <remarks>
		///     <para>
		///         The callback function is passed the current timer interval and returns the
		///         next timer interval.  If the returned value is the same as the one passed
		///         in, the periodic alarm continues, otherwise a new alarm is scheduled.
		///     </para>
		///     <para>
		///         To cancel a currently running timer, call <c>Sdl.SDL_SetTimer(0, null);</c>
		///     </para>
		///     <para>
		///         The timer callback function may run in a different thread than your main
		///         constant, and so shouldn't call any functions from within itself.
		///     </para>
		///     <para>
		///         The maximum resolution of this timer is 10 ms, which means that if you
		///         request a 16 ms timer, your callback will run approximately 20 ms later on
		///         an unloaded system.  If you wanted to set a flag signaling a frame update at
		///         30 frames per second (every 33 ms), you might set a timer for 30 ms.
		///     </para>
		///     <para>
		///         If you use this function, you need to pass <see cref="SDL_INIT_TIMER" /> to
		///         <see cref="SDL_Init" />.
		///     </para>
		///     <para>
		///         This function is kept for compatibility but has been superseded by the new
		///         timer functions <see cref="SDL_AddTimer" /> and
		///         <see cref="SDL_RemoveTimer" /> which support multiple timers.
		///     </para>
		///     <p>
		///     Binds to C-function call in SDL_timer.h:
		///     <code>extern DECLSPEC int SDLCALL SDL_SetTimer(Uint32 interval, 
		///     SDL_TimerCallback callback)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_AddTimer" />
		/// <seealso cref="SDL_TimerCallback" />
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetTimer(int interval, SDL_TimerCallback callback);
		#endregion int SDL_SetTimer(int interval, SDL_TimerCallback callback)

		#region SDL_TimerID SDL_AddTimer(int interval, SDL_NewTimerCallback callback)
		// TODO: Goddamn void* double whammy since it's a delegate
		// TODO write test
		// extern DECLSPEC SDL_TimerID SDLCALL SDL_AddTimer(Uint32 interval, SDL_NewTimerCallback callback, void *param);
		/// <summary>
		///     Add a timer which will call a callback after the 
		///     specified number of milliseconds has elapsed.
		/// </summary>
		/// <param name="callback">
		/// The callback to run.
		/// </param>
		/// <param name="interval">
		/// The timer interval.
		/// </param>
		/// <returns>
		/// Returns an ID value for the added timer or NULL if 
		/// there was an error.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Adds a callback function to be run after the specified number of 
		/// milliseconds has elapsed. The callback function is passed the current 
		/// timer interval and the user supplied parameter from the SDL_AddTimer 
		/// call and returns the next timer interval. If the returned value from 
		/// the callback is the same as the one passed in, the periodic alarm 
		/// continues, otherwise a new alarm is scheduled.
		/// </para>
		/// <para>
		/// To cancel a currently running timer call <see cref="SDL_RemoveTimer" /> 
		/// with the timer ID returned from SDL_AddTimer.
		/// </para>
		/// <para>
		/// The timer callback function may run in a different thread than your main 
		/// program, and so shouldn't call any functions from within itself.
		/// You may always call SDL_PushEvent, however.
		/// </para>
		/// <para>
		/// The granularity of the timer is platform-dependent, 
		/// but you should count on it being at least 10 ms as this is the 
		/// most common number. This means that if you request a 16 ms timer,
		///  your callback will run approximately 20 ms later on an unloaded 
		///  system. If you wanted to set a flag signaling a frame update at 
		///  30 frames per second (every 33 ms), you might set a timer for 
		///  30 ms (see example below). If you use this function, you need 
		///  to pass <see cref="SDL_INIT_TIMER" /> to <see cref="SDL_Init" />.
		/// </para>
		/// <p>
		///     Binds to C-function call in SDL_timer.h:
		///     <code>extern DECLSPEC SDL_TimerID SDLCALL 
		///     SDL_AddTimer(Uint32 interval, 
		///     SDL_NewTimerCallback callback, void *param)</code>
		///     </p>
		/// </remarks>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern SDL_TimerID SDL_AddTimer(int interval, SDL_NewTimerCallback callback);
		#endregion SDL_TimerID SDL_AddTimer(int interval, SDL_NewTimerCallback callback)

		#region SDL_bool SDL_RemoveTimer(SDL_TimerID t)
		//TODO Write Test
		/// <summary>
		///     Remove a timer which was added with <see cref="SDL_AddTimer" />.
		/// </summary>
		/// <param name="t">
		///     The timer ID to remove.
		/// </param>
		/// <returns>
		///     A boolean value indicating success. SDL_TRUE or SDL_FALSE.
		/// </returns>
		/// <remarks>
		/// <p>
		///     Binds to C-function call in SDL_timer.h:
		///     <code>extern DECLSPEC SDL_bool SDLCALL SDL_RemoveTimer(SDL_TimerID t)</code>
		///     </p>
		/// </remarks>
		/// <seealso cref="SDL_AddTimer" />
		// 
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_RemoveTimer(SDL_TimerID t);
		#endregion SDL_bool SDL_RemoveTimer(SDL_TimerID t)
		#endregion SDL_timer.h

		// SDL_types -- none

		#region SDL_version.h
		#region IntPtr SDL_Linked_VersionInternal()
		//     extern DECLSPEC const SDL_version * SDLCALL SDL_Linked_Version(void)
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="SDL_Linked_Version"), SuppressUnmanagedCodeSecurity]
		private static extern IntPtr SDL_Linked_VersionInternal();
		#endregion IntPtr SDL_Linked_VersionInternal()

		#region SDL_version SDL_Linked_Version() 
		/// <summary>
		///     This function gets the version of the dynamically linked SDL library.
		/// </summary>
		/// <returns>
		///     SDL_version struct
		/// </returns>
		/// <remarks>
		///     <p>
		///     Binds to C-function call in SDL_version.h:
		///     <code>extern DECLSPEC const SDL_version * SDLCALL SDL_Linked_Version(void)</code>
		///     </p>
		/// </remarks>
		public static SDL_version SDL_Linked_Version() 
		{ 
			return (Sdl.SDL_version)Marshal.PtrToStructure(
				Sdl.SDL_Linked_VersionInternal(), 
				typeof(Sdl.SDL_version)); 
		} 
		#endregion SDL_version SDL_Linked_Version() 

		#region int SDL_VERSIONNUM( byte major, byte minor, byte patch )
		// This method turns the version numbers into a numeric value: (1,2,3) -> (1203)
		// This assumes that there will never be more than 100 patchlevels
		private static int SDL_VERSIONNUM( byte major, byte minor, byte patch )
		{
			return (int)(major*1000 + minor*100 + patch);
		}
		#endregion int SDL_VERSIONNUM( byte major, byte minor, byte patch )

		#region int SDL_COMPILEDVERSION
		/// <summary>
		/// This returns the current SDL version
		/// </summary>
		/// <remarks>
		///      <p>
		///     Binds to C-function call in SDL_version.h:
		///     <code>#define SDL_COMPILEDVERSION SDL_VERSIONNUM(SDL_MAJOR_VERSION, SDL_MINOR_VERSION, SDL_PATCHLEVEL)</code>
		///     </p>
		/// </remarks>
		/// <returns>
		/// Returns the version number as a numeric value: (1.2.7 -> 1207)
		/// </returns>
		public static int SDL_COMPILEDVERSION
		{
			get
			{
				SDL_version version = Sdl.SDL_Linked_Version();
				return Sdl.SDL_VERSIONNUM(version.major, version.minor, version.patch);
			}
		}
		#endregion int SDL_COMPILEDVERSION

		#region bool SDL_VERSION_ATLEAST( byte major, byte minor, byte patch )
		/// <summary>
		/// Will evaluate to true if SDL version is at least X.Y.Z
		/// </summary>
		/// <param name="major">Major version number</param>
		/// <param name="minor">Minor version number</param>
		/// <param name="patch">Patch version number</param>
		/// <returns>True if the version of SDL is greater or equal to the version numbers passed in.</returns>
		public static bool SDL_VERSION_ATLEAST( byte major, byte minor, byte patch )
		{
			return (Sdl.SDL_COMPILEDVERSION >= Sdl.SDL_VERSIONNUM(
				major, 
				minor, 
				patch));
		}
		#endregion bool SDL_VERSION_ATLEAST( byte major, byte minor, byte patch )
		#endregion SDL_version.h

		#region SDL_video.h
		#region int SDL_MUSTLOCK(IntPtr surface)
		/// <summary>
		/// Evaluates to true if the surface needs to be locked before access
		/// </summary>
		/// <param name="surface"></param>
		/// <returns>
		/// 1 if surface must be locked. 0 if it does not.
		/// </returns>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_video.h:
		///     <code>#define SDL_MUSTLOCK(surface) (surface->offset ||	((surface->flags &amp; (SDL_HWSURFACE|SDL_ASYNCBLIT|SDL_RLEACCEL)) != 0))</code>
		///     </p>
		/// </remarks>
		public static int SDL_MUSTLOCK(IntPtr surface)
		{
			Sdl.SDL_Surface surf = (Sdl.SDL_Surface) Marshal.PtrToStructure(surface, typeof(Sdl.SDL_Surface));
			if (((surf.flags & (Sdl.SDL_HWSURFACE| Sdl.SDL_ASYNCBLIT|Sdl.SDL_RLEACCEL)) !=0))
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
		#endregion int SDL_MUSTLOCK(IntPtr surface)

		// SDL_VideoInit and SDL_VideoQuit -- 
		// these are private functions and will not be implemented.

		#region string SDL_VideoDriverName(string namebuf, int maxlen)
		/// <summary>
		/// This function returns a string with the name of the
		/// video driver.
		/// </summary>
		/// <remarks>
		/// It returns NULL if no driver has been initialized.
		/// <p>Binds to C-function call in SDL_video.h:
		///     <code>extern DECLSPEC char * SDLCALL SDL_VideoDriverName(char *namebuf, int maxlen)</code>
		///     </p>
		/// </remarks>
		/// <returns>
		/// Returns a string containing the driver name. 
		/// It returns null if no driver has been initialized.
		/// </returns>
		/// <param name="maxlen">
		/// Length of string
		/// </param>
		/// <param name="namebuf">
		/// A dummy string that must be initialized before being passed in.
		/// </param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern string SDL_VideoDriverName(string namebuf, 
			int maxlen);
		#endregion string SDL_VideoDriverName(string namebuf, int maxlen)

		#region IntPtr SDL_GetVideoSurface()
		/// <summary>
		/// This function returns a pointer to the current display surface.
		/// </summary>
		/// <remarks>
		/// If SDL is doing format conversion on the display surface, this
		/// function returns the publicly visible surface, not the real video
		/// surface. 
		/// <p>Binds to C-function call in SDL_video.h:
		///     <code>extern DECLSPEC SDL_Surface * SDLCALL SDL_GetVideoSurface(void)</code>
		///     </p>
		/// </remarks>
		/// <returns>
		/// It returns a pointer to a SDL_Surface struct.
		/// </returns>
		/// <seealso cref="SDL_Surface"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_GetVideoSurface();
		#endregion IntPtr SDL_GetVideoSurface()

		#region IntPtr SDL_GetVideoInfo()
		/// <summary>
		/// This function returns a read-only pointer to information 
		/// about the video hardware. 
		/// </summary>
		/// <remarks>
		/// If this is called before <see cref="SDL_SetVideoMode"/>, the 'vfmt'
		/// member of the returned structure will contain the pixel 
		/// format of the "best" video mode.
		/// <p>Binds to C-function call in SDL_video.h:
		///     <code>extern DECLSPEC const SDL_VideoInfo * SDLCALL SDL_GetVideoInfo(void)</code>
		///     </p>
		/// </remarks>
		/// <returns>IntPtr to SDL_VideoInfo struct</returns>
		/// <see cref="SDL_SetVideoMode"/>
		/// <see cref="SDL_VideoInfo"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_GetVideoInfo();
		#endregion IntPtr SDL_GetVideoInfo()

		#region int SDL_VideoModeOK(int width, int height, int bpp, int flags);
		/// <summary>
		/// Check to see if a particular video mode is supported.
		/// </summary>
		/// <remarks>
		/// SDL_VideoModeOK returns 0 if the requested mode is not supported under any 
		/// bit depth,
		/// or returns the bits-per-pixel of the closest available mode 
		/// with the
		/// given width, height and requested <see cref="SDL_Surface"/> flags. See <see cref="SDL_SetVideoMode"/>.
		/// <p>The bits-per-pixel value returned is only a suggested mode. 
		/// You can usually request and bpp you want when setting the video mode 
		/// and SDL will emulate that color depth with a shadow video surface. 
		/// </p>
		/// <p>
		/// The arguments to SDL_VideoModeOK() are the same ones you would 
		/// pass to
		/// <see cref="SDL_SetVideoMode"/>
		/// </p>
		/// <p>Binds to C-function call in SDL_video.h:
		///     <code>extern DECLSPEC int SDLCALL SDL_VideoModeOK(int width, int height, int bpp, Uint32 flags)</code>
		///     </p>
		/// </remarks>
		/// <param name="width">Width of mode</param>
		/// <param name="height">Height of mode</param>
		/// <param name="bpp">bit depth of Mode</param>
		/// <param name="flags"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_VideoModeOK(int width, 
			int height, int bpp, int flags);
		#endregion int SDL_VideoModeOK(int width, int height, int bpp, int flags);

		#region SDL_Rect[] SDL_ListModes(IntPtr format, int flags)
		/// <summary> 
		/// Return a pointer to an array of available screen dimensions for the 
		/// given format and video flags, sorted largest to smallest.  
		/// Returns 
		/// NULL if there are no dimensions available for a particular format, 
		/// or (SDL_Rect **)-1 if any dimension is okay for the given format. 
		/// </summary> 
		/// <remarks> 
		/// If 'format' is NULL, the mode list will be for the format given 
		/// by <see cref="SDL_GetVideoInfo"/>()->vfmt. 
		/// The flag parameter is an OR'd combination of <see cref="SDL_Surface">surface</see> flags. 
		/// The flags are the same as those used <see cref="SDL_SetVideoMode"/> and they 
		/// play a strong role in deciding what modes are valid. 
		/// For instance, if you pass SDL_HWSURFACE as a flag only modes that 
		/// support hardware video surfaces will be returned.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>extern DECLSPEC SDL_Rect ** SDLCALL SDL_ListModes(SDL_PixelFormat *format, Uint32 flags)</code>
		///     </p>
		/// </remarks> 
		/// <param name="format"></param> 
		/// <param name="flags"></param> 
		/// <returns></returns> 
		/// <seealso cref="SDL_SetVideoMode">SDL_SetVideoMode</seealso>
		/// <seealso cref="SDL_GetVideoInfo">SDL_GetVideoInfo</seealso>
		/// <seealso cref="SDL_Rect">SDL_Rect</seealso>
		/// <seealso cref="SDL_PixelFormat">SDL_PixelFormat</seealso>
		[CLSCompliant(false)] 
		public unsafe static SDL_Rect[] SDL_ListModes(IntPtr format, int flags) 
		{ 
			IntPtr rectPtr = SDL_ListModesInternal(IntPtr.Zero, flags); 

			Sdl.SDL_Rect** rects = (Sdl.SDL_Rect**)rectPtr.ToPointer(); 

			int i = 0; 

			ArrayList modes = new ArrayList(); 

			while(rects[i] != null) 
			{ 
				Sdl.SDL_Rect rect = 
					(Sdl.SDL_Rect)Marshal.PtrToStructure(new IntPtr(rects[i]), typeof(Sdl.SDL_Rect)); 

				modes.Insert(0, rect); 

				i++; 
			} 

			return (Sdl.SDL_Rect[])modes.ToArray(typeof(Sdl.SDL_Rect)); 
		}
		#endregion SDL_Rect[] SDL_ListModes(IntPtr format, int flags)

		#region IntPtr SDL_ListModesInternal(IntPtr format, int flags)
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, 
			 EntryPoint="SDL_ListModes"), SuppressUnmanagedCodeSecurity] 
		private static extern IntPtr SDL_ListModesInternal( 
			IntPtr format, int flags); 
		#endregion IntPtr SDL_ListModesInternal(IntPtr format, int flags)

		#region IntPtr SDL_SetVideoMode(int width, int height, int bpp, int flags)
		/// <summary>
		/// Set up a video mode with the specified width, height 
		/// and bits-per-pixel.
		/// </summary>
		/// <remarks>
		/// If 'bpp' is 0, it is treated as the current display bits per pixel.
		/// <p>
		/// The flags parameter is the same as the flags field of the SDL_Surface 
		/// structure. OR'd combinations of the following values are valid.
		/// </p>
		/// <list type="table">
		///		<listheader>
		///                 <term>Flag</term>
		///                 <description>Description</description>
		///             </listheader>
		///             <item>
		///                 <term><see cref="SDL_SWSURFACE" /></term>
		///                 <description>Create the video surface in system memory.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_HWSURFACE" /></term>
		///                 <description>Create the video surface in video memory ,if possible, 
		///                 and you may have to call SDL_LockSurface()
		/// in order to access the raw framebuffer.  Otherwise, the video
		///  surface
		/// will be created in system memory.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_ASYNCBLIT" /></term>
		///                 <description>Enables the use of asynchronous updates 
		///                 of the display surface, but you must always lock before 
		/// accessing pixels.
		/// SDL will wait for updates to complete before returning from the
		///  lock. This will usually slow down 
		///                 blitting on single CPU machines, but may provide a 
		///                 speed increase on SMP systems.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_ANYFORMAT" /></term>
		///                 <description>Normally, if a video surface of the 
		///                 requested bits-per-pixel (bpp) is not available, 
		///                 SDL will emulate one with a shadow surface. 
		///                 Passing SDL_ANYFORMAT prevents this and causes 
		///                 SDL to use the video surface, regardless of its 
		///                 pixel depth.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_HWPALETTE" /></term>
		///                 <description>Give SDL exclusive palette access. 
		///                 Without this flag you may not always get the the 
		///                 colors you request with <see cref="SDL_SetColors"/> 
		///                 or <see cref="SDL_SetPalette"/>. You should
		///  look
		/// at the video surface structure to determine the actual palette.
		/// If SDL cannot guarantee that the colors you request can be set, 
		/// i.e. if the colormap is shared, then the video surface may be
		///  created
		/// under emulation in system memory, overriding the SDL_HWSURFACE
		///  flag.
		///                 </description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_DOUBLEBUF" /></term>
		///                 <description>Enable hardware double buffering; 
		///                 only valid with SDL_HWSURFACE. Calling <see cref="SDL_Flip"/> 
		///                 will flip the buffers and update the screen. 
		///                 All drawing will take place on the surface that 
		///                 is not displayed at the moment. If double buffering 
		///                 could not be enabled then SDL_Flip will just 
		///                 perform a <see cref="SDL_UpdateRect"/> 
		///                 on the entire screen. This is usually slower than the normal 
		/// single-buffering
		/// scheme, but prevents "tearing" artifacts caused by modifying video 
		/// memory while the monitor is refreshing.  It should only be used by 
		/// applications that redraw the entire screen on every update.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_FULLSCREEN" /></term>
		///                 <description>SDL will attempt to use a fullscreen mode. 
		///                 If a hardware resolution change is not possible 
		///                 (for whatever reason), the next higher resolution 
		///                 will be used and the display window centered 
		///                 on a black background. The default is to create a windowed mode
		/// if the current graphics system has a window manager.
		/// If the SDL library is able to set a fullscreen video mode, this
		///  flag 
		/// will be set in the surface that is returned.</description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_OPENGL" /></term>
		///                 <description>Create an OpenGL rendering context. 
		///                 You should have previously set OpenGL 
		///                 video attributes with <see cref="SDL_GL_SetAttribute"/>.
		///                 </description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_OPENGLBLIT" /></term>
		///                 <description>Create an OpenGL rendering context, 
		///                 like above, but allow normal blitting operations. 
		///                 The screen (2D) surface may have an alpha channel,
		///                 and <see cref="SDL_UpdateRects"/> must be used for updating changes 
		///                 to the screen surface. NOTE: This option is kept for 
		///                 compatibility only, and is not recommended for new code.
		///                 </description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_RESIZABLE" /></term>
		///                 <description>Create a resizable window. 
		///                 When the window is resized by the user a 
		///                 <see cref="SDL_VIDEORESIZE"/> event is generated and 
		///                 SDL_SetVideoMode can be called again with the new size.
		///                 </description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_NOFRAME" /></term>
		///                 <description>If possible, SDL_NOFRAME causes 
		///                 SDL to create a window with no title bar or 
		///                 frame decoration. Fullscreen modes automatically 
		///                 have this flag set.
		///                 </description>
		///             </item>
		///         </list>
		/// 
		/// If you rely on functionality provided by certain video flags, 
		/// check the
		/// flags of the returned surface to make sure that functionality 
		/// is available.
		/// SDL will fall back to reduced functionality if the exact flags 
		/// you wanted
		/// are not available.
		/// <p>Whatever flags SDL_SetVideoMode could satisfy are set 
		/// in the flags member of the returned surface.</p>
		/// <p>
		///  The bpp parameter is the number of bits per pixel, 
		///  so a bpp of 24 uses the packed representation of 3 bytes/pixel. 
		///  For the more common 4 bytes/pixel mode, use a bpp of 32. 
		///  Somewhat oddly, both 15 and 16 will request a 2 bytes/pixel mode, 
		///  but different pixel formats.
		/// </p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>extern DECLSPEC SDL_Surface * SDLCALL SDL_SetVideoMode
		/// (int width, int height, int bpp, Uint32 flags);</code>
		/// </p>
		/// </remarks>
		/// <seealso cref="SDL_LockSurface">SDL_LockSurface</seealso>
		/// <seealso cref="SDL_SetColors">SDL_SetColors</seealso>
		/// <seealso cref="SDL_Flip">SDL_Flip</seealso>
		/// <seealso cref="SDL_Surface">SDL_Surface</seealso>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="bpp"></param>
		/// <param name="flags"></param>
		/// <returns>The framebuffer surface, or NULL if it fails. 
		/// The surface returned is freed by SDL_Quit() and should not be 
		/// freed by the caller.
		/// </returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_SetVideoMode(int width, int height,
			int bpp, int flags);
		#endregion IntPtr SDL_SetVideoMode(int width, int height, int bpp, int flags)

		#region void SDL_UpdateRects(IntPtr screen, int numrects, [In, Out] SDL_Rect[] rects)
		/// <summary>
		/// Makes sure the given list of rectangles is updated on the given 
		/// screen.
		/// </summary>
		/// <remarks>
		/// The rectangles must all be confined within the screen boundaries 
		/// (no clipping is done).
		/// <p>
		/// This function should not be called while screen is 
		/// <see also="SDL_LockSurface">locked</see>.
		/// </p>
		/// <p>Note: It is adviced to call this function only once per frame, 
		/// since each call has some processing overhead. This is no restriction 
		/// since you can pass any number of rectangles each time.
		/// </p>
		/// <p>The rectangles are not automatically merged or checked for overlap. 
		/// In general, the programmer can use his knowledge about his particular 
		/// rectangles to merge them in an efficient way, to avoid overdraw.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>extern DECLSPEC void SDLCALL SDL_UpdateRects (SDL_Surface *screen, int numrects, SDL_Rect *rects)</code>
		/// </p>
		/// </remarks>
		/// <seealso cref="SDL_UpdateRect">SDL_UpdateRect</seealso>
		/// <seealso cref="SDL_Rect">SDL_Rect</seealso>
		/// <seealso cref="SDL_Surface">SDL_Surface</seealso>
		/// <seealso cref="SDL_LockSurface">SDL_LockSurface</seealso>
		/// <param name="screen"></param>
		/// <param name="numrects"></param>
		/// <param name="rects"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_UpdateRects(IntPtr screen, 
			int numrects, [In, Out] SDL_Rect[] rects);
		#endregion void SDL_UpdateRects(IntPtr screen, int numrects, [In, Out] SDL_Rect[] rects)

		#region void SDL_UpdateRect(IntPtr screen, int x, int y, int w, int h)
		/// <summary>
		/// Makes sure the given area is updated on the given screen. 
		/// </summary>
		/// <remarks>
		/// <p>The rectangle must be confined within the screen boundaries (no 
		/// clipping is done).
		/// </p>
		/// <p>If 'x', 'y', 'w' and 'h' are all 0, SDL_UpdateRect will update the 
		/// entire screen.</p>
		/// <p>These functions should not be called while 'screen' is 
		/// <see cref="SDL_LockSurface">locked</see>.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>extern DECLSPEC void SDLCALL SDL_UpdateRect (SDL_Surface *screen, Sint32 x, Sint32 y, Uint32 w, Uint32 h)</code>
		/// </p>
		/// </remarks>
		/// <param name="screen"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_UpdateRect(IntPtr screen, int x, 
			int y, int w, int h);
		#endregion void SDL_UpdateRect(IntPtr screen, int x, int y, int w, int h)

		#region int SDL_Flip(IntPtr screen)
		/// <summary>
		/// Swaps screen buffers
		/// </summary>
		/// <remarks>
		/// On hardware that supports double-buffering, this function sets up 
		/// a flip
		/// and returns.  The hardware will wait for vertical retrace, and 
		/// then swap
		/// video buffers before the next video surface blit or lock will
		///  return.
		/// On hardware that does not support double-buffering, this is 
		/// equivalent
		/// to calling <see cref="SDL_UpdateRect"/>(screen, 0, 0, 0, 0)
		/// <p>
		/// The SDL_DOUBLEBUF flag must have been passed to <see cref="SDL_SetVideoMode"/>
		///  when
		/// setting the video mode for this function to perform hardware 
		/// flipping.</p>
		/// </remarks>
		/// <param name="screen"></param>
		/// <returns>
		/// This function returns 0 if successful, or -1 if there was an 
		/// error.
		/// </returns>
		/// <seealso cref="SDL_SetVideoMode">SDL_SetVideoMode</seealso>
		/// <seealso cref="SDL_UpdateRect">SDL_UpdateRect</seealso>
		/// <seealso cref="SDL_Surface">SDL_Surface</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="SDL_Flip"),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_Flip(IntPtr screen);
		#endregion int SDL_Flip(IntPtr screen)

		#region int SDL_SetGamma(float red, float green, float blue)
		/// <summary>
		/// Set the gamma correction for each of the color channels.
		/// </summary>
		/// <remarks>
		/// <p>Sets the "gamma function" for the display of each color component. 
		/// Gamma controls the brightness/contrast of colors displayed on the screen.
		/// A gamma value of 1.0 is identity (i.e., no adjustment is made).
		/// </p>
		/// <p>This function adjusts the gamma based on the "gamma function" 
		/// parameter, you can directly specify lookup tables for gamma adjustment
		///  with SDL_SetGammaRamp.</p>
		///  <p>Not all display hardware is able to change gamma.</p>
		/// <p>The gamma values range (approximately) between 0.1 and 10.0.</p>
		/// <p>If this function isn't supported directly by the hardware, it will
		/// be emulated using gamma ramps, if available.  If successful, this
		/// function returns 0, otherwise it returns -1.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>extern DECLSPEC int SDLCALL SDL_SetGamma(float red, float green, float blue)</code>
		/// </p>
		/// </remarks>
		/// <param name="blue"></param>
		/// <param name="green"></param>
		/// <param name="red"></param>
		/// <returns>
		/// If successful, this
		/// function returns 0, otherwise it returns -1.
		/// </returns>
		/// <seealso cref="SDL_GetGammaRamp">SDL_GetGammaRamp</seealso>
		/// <seealso cref="SDL_SetGammaRamp">SDL_SetGammaRamp</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetGamma(float red, float green, 
			float blue);
		#endregion int SDL_SetGamma(float red, float green, float blue)
		
		#region int SDL_SetGammaRamp(...)
		/// <summary>
		/// Set the gamma translation table for the red, green, and blue
		///  channels
		/// of the video hardware.  
		/// </summary>
		/// <remarks>
		/// Each table is an array of 256 
		/// 16-bit quantities,
		/// representing a mapping between the input and output for that 
		/// channel.
		/// The input is the index into the array, and the output is the 16-bit
		/// gamma value at that index, scaled to the output color precision.
		/// You may pass NULL for any of the channels to leave it unchanged.
		/// </remarks>
		/// <returns>
		/// If the call succeeds, it will return 0.  If the display driver or
		/// hardware does not support gamma translation, or otherwise fails,
		/// this function will return -1.
		/// </returns>
		/// <param name="blue"></param>
		/// <param name="green"></param>
		/// <param name="red"></param>
		/// <seealso cref="SDL_SetGamma">SDL_SetGamma</seealso>
		/// <seealso cref="SDL_GetGammaRamp">SDL_GetGammaRamp</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetGammaRamp([In,Out] short[] red, 
			[In,Out] short[] green,
			[In,Out] short[] blue);
		#endregion int SDL_SetGammaRamp(...)

		#region int SDL_GetGammaRamp(...)
		/// <summary>
		/// Gets the color gamma lookup tables for the display.
		/// </summary>
		/// <remarks>
		/// Gets the gamma translation lookup tables currently used by the display. 
		/// Each table is an array of 256 <see cref="short"/> values.
		/// <p>
		/// You must pass in valid pointers to arrays of 256 16-bit quantities.
		/// Any of the pointers may be NULL to ignore that channel.
		/// </p>
		/// <p>Not all display hardware is able to change gamma.
		/// </p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>int SDLCALL SDL_GetGammaRamp(Uint16 *red, Uint16 *green, Uint16 *blue)</code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// If the call succeeds, it will return 0.  If the display driver or
		/// hardware does not support gamma translation, or otherwise fails,
		/// this function will return -1.
		/// </returns>
		/// <seealso cref="SDL_SetGamma">SDL_SetGamma</seealso>
		/// <seealso cref="SDL_SetGammaRamp">SDL_SetGammaRamp</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GetGammaRamp([In,Out] short[] red, 
			[In,Out] short[] green,
			[In,Out] short[] blue);
		#endregion int SDL_GetGammaRamp(...)

		#region int SDL_SetColors(...)
		/// <summary>
		/// Sets a portion of the colormap for the given 8-bit surface.  		
		/// </summary>
		/// <remarks>
		/// <p>When surface is the surface associated with the current display,
		///  the display colormap will be updated with the requested colors.
		///   If SDL_HWPALETTE was set in <see cref="SDL_SetVideoMode"/> flags, SDL_SetColors
		///    will always return 1, and the palette is guaranteed to be set 
		///    the way you desire, even if the window colormap has to be warped
		///     or run under emulation.</p>
		///     
		/// <p>The color components of a SDL_Color structure are 8-bits in size,
		///  giving you a total of 256^3 =16777216 colors.</p>
		///  <p>Palettized (8-bit) screen surfaces with the SDL_HWPALETTE 
		///     flag have two palettes, a logical palette that is used for 
		///     mapping blits to/from the surface and a physical palette (that 
		///     determines how the hardware will map the colors to the display).
		///      SDL_SetColors modifies both palettes (if present), and is equivalent
		///       to calling SDL_SetPalette with the flags set to 
		///       (SDL_LOGPAL | SDL_PHYSPAL).
		///       </p>
		/// <p>When 'surface' is the surface associated with the current 
		/// display, the
		/// display colormap will be updated with the requested colors.  If 
		/// SDL_HWPALETTE was set in SDL_SetVideoMode() flags, SDL_SetColors()
		/// will always return 1, and the palette is guaranteed to be set 
		/// the way
		/// you desire, even if the window colormap has to be warped or 
		/// run under
		/// emulation.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>extern DECLSPEC int SDLCALL SDL_SetColors(SDL_Surface *surface, SDL_Color *colors, int firstcolor, int ncolors)</code>
		/// </p>
		/// </remarks>
		/// <example>/* Create a display surface with a grayscale palette */
		///		SDL_Surface *screen;
		///		SDL_Color colors[256];
		///		int i;
		///		.
		///		.
		///		.
		///		/* Fill colors with color information */
		///		for(i=0;i&lt;256;i++)
		///	{
		///		colors[i].r=i;
		///		colors[i].g=i;
		///		colors[i].b=i;
		///	}
		///
		///	/* Create display */
		///	screen=SDL_SetVideoMode(640, 480, 8, SDL_HWPALETTE);
		///	if(!screen)
		///{
		///	printf("Couldn't set video mode: %s\n", SDL_GetError());
		///	exit(-1);
		///}
		///
		///	/* Set palette */
		///	SDL_SetColors(screen, colors, 0, 256);
		///	.
		///	.
		///	.
		///	.
		///	</example>
		/// <param name="surface"></param>
		/// <param name="firstcolor"></param>
		/// <param name="ncolors"></param>
		/// <param name="colors"></param>
		/// <returns>
		/// If 'surface' is not a palettized surface, this function does nothing, 
		/// returning 0.
		/// If all of the colors were set as passed to SDL_SetColors(), it will
		/// return 1.  If not all the color entries were set exactly as given,
		/// it will return 0, and you should look at the surface palette to
		/// determine the actual color palette.
		/// </returns>
		/// <seealso cref="SDL_Color">SDL_Color</seealso>
		/// <seealso cref="SDL_Surface">SDL_Surface</seealso>
		/// <seealso cref="SDL_SetPalette">SDL_SetPalette</seealso>
		/// <seealso cref="SDL_SetVideoMode">SDL_SetVideoMode</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetColors(IntPtr surface, [In, Out] SDL_Color[] colors,
			int firstcolor, int ncolors);
		#endregion int SDL_SetColors(...)
	
		#region int SDL_SetPalette(...)
		/// <summary>
		/// Sets the colors in the palette of an 8-bit surface.
		/// </summary>
		/// <remarks>Palettized (8-bit) screen surfaces with the SDL_HWPALETTE 
		/// flag have two palettes, a logical palette that is used for mapping 
		/// blits to/from the surface and a physical palette (that determines 
		/// how the hardware will map the colors to the display). SDL_BlitSurface
		///  always uses the logical palette when blitting surfaces (if it has to
		///   convert between surface pixel formats). Because of this, it is often
		///    useful to modify only one or the other palette to achieve various 
		///    special color effects (e.g., screen fading, color flashes, screen dimming).
		///    
		///    <p>This function can modify either the logical or physical palette 
		///    by specifing SDL_LOGPAL or SDL_PHYSPALthe in the flags parameter.</p>
		///    
		///    <p>When surface is the surface associated with the current display, 
		///    the display colormap will be updated with the requested colors. 
		///    If SDL_HWPALETTE was set in SDL_SetVideoMode flags, SDL_SetPalette 
		///    will always return 1, and the palette is guaranteed to be set the 
		///    way you desire, even if the window colormap has to be warped or run
		///     under emulation.</p>
		///     <p>The color components of a SDL_Color structure are 8-bits 
		///     in size, giving you a total of 2563=16777216 colors.</p>
		/// <p>
		/// 'flags' is one or both of:
		/// SDL_LOGPAL  -- set logical palette, which controls how blits 
		/// are mapped to/from the surface,
		/// SDL_PHYSPAL -- set physical palette, which controls how pixels 
		/// look on the screen
		/// Only screens have physical palettes. Separate change of 
		/// physical/logical
		/// palettes is only possible if the screen has SDL_HWPALETTE set.
		///</p>
		///
		/// SDL_SetColors() is equivalent to calling this function with
		///	flags = (SDL_LOGPAL|SDL_PHYSPAL).
		///	<p>Binds to C-function call in SDL_video.h:
		/// <code>extern DECLSPEC int SDLCALL SDL_SetPalette(SDL_Surface *surface, int flags, SDL_Color *colors, int firstcolor, int ncolors)</code>
		/// </p>
		///     </remarks>
		///     <example><code>
		///     /* Create a display surface with a grayscale palette */
		///		SDL_Surface *screen;
		///		SDL_Color colors[256];
		///		int i;
		///		.
		///		.
		///		.
		///		/* Fill colors with color information */
		///		for(i=0;i&lt;256;i++)
		///	{
		///		colors[i].r=i;
		///		colors[i].g=i;
		///		colors[i].b=i;
		///	}
		///
		///	/* Create display */
		///	screen=SDL_SetVideoMode(640, 480, 8, SDL_HWPALETTE);
		///	if(!screen)
		///{
		///	printf("Couldn't set video mode: %s\n", SDL_GetError());
		///	exit(-1);
		///}
		///
		///	/* Set palette */
		///	SDL_SetPalette(screen, SDL_LOGPAL|SDL_PHYSPAL, colors, 0, 256);
		///	.
		///	.
		///	.
		///	.</code></example>
		/// <param name="surface"></param>
		/// <param name="colors"></param>
		/// <param name="firstcolor"></param>
		/// <param name="flags"></param>
		/// <param name="ncolors"></param>
		/// <returns>
		/// If surface is not a palettized surface, this function does 
		/// nothing, returning 0. If all of the colors were set as passed to 
		/// SDL_SetPalette, it will return 1. If not all the color entries were
		///  set exactly as given, it will return 0, and you should look at the
		///   surface palette to determine the actual color palette.
		/// </returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetPalette(IntPtr surface, int flags,
			[In, Out] SDL_Color[] colors, int firstcolor, int ncolors);
		#endregion int SDL_SetPalette(...)

		#region int SDL_MapRGB(IntPtr format, byte r, byte g, byte b)
		/// <summary>
		/// Map a RGB color value to a pixel format.
		/// </summary>
		/// <remarks>
		/// Maps the RGB color value to the specified pixel format and returns the pixel
		///  value as a 32-bit int.
		/// <p>If the format has a palette (8-bit) the index of the closest 
		/// matching color in the palette will be returned.</p>
		/// <p>If the specified pixel format has an alpha component it will be 
		/// returned as all 1 bits (fully opaque).</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>extern DECLSPEC Uint32 SDLCALL SDL_MapRGB (SDL_PixelFormat *format, Uint8 r, Uint8 g, Uint8 b)</code>
		/// </p>
		/// </remarks>
		/// <param name="format">IntPtr to <see cref="SDL_PixelFormat"/></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		/// <returns>A pixel value best approximating the given RGB color 
		/// value for a given pixel format. If the pixel format bpp (color depth)
		///  is less than 32-bpp then the unused upper bits of the return value 
		///  can safely be ignored (e.g., with a 16-bpp format the return value 
		///  can be assigned to a Uint16, and similarly a Uint8 for an 8-bpp 
		///  format).</returns>
		///  <seealso cref="SDL_GetRGB">SDL_GetRGB</seealso>
		///  <seealso cref="SDL_GetRGBA">SDL_GetRGBA</seealso>
		///  <seealso cref="SDL_MapRGBA">SDL_MapRGBA</seealso>
		///  <seealso cref="SDL_PixelFormat">SDL_PixelFormat</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_MapRGB(IntPtr format, byte r, byte g, 
			byte b);
		#endregion int SDL_MapRGB(IntPtr format, byte r, byte g, byte b)
		
		#region int SDL_MapRGBA(IntPtr format, byte r, byte g, byte b, byte a)
		/// <summary>
		/// Map a RGBA color value to a pixel format.
		/// </summary>
		/// <remarks>
		/// Maps the RGBA color value to the specified pixel format and 
		/// returns the pixel value as a 32-bit int.
		/// <p>If the format has a palette (8-bit) the index of the closest 
		/// matching color in the palette will be returned.</p>
		/// <p>If the specified pixel format has no alpha component the alpha 
		/// value will be ignored (as it will be in formats with a palette).</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>extern DECLSPEC Uint32 SDLCALL SDL_MapRGBA (SDL_PixelFormat *format, Uint8 r, Uint8 g, Uint8 b, Uint8 a)</code>
		/// </p>
		/// </remarks>
		/// <param name="format"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		/// <param name="a"></param>
		/// <returns>A pixel value best approximating the given RGBA 
		/// color value for a given pixel format. If the pixel format 
		/// bpp (color depth) is less than 32-bpp then the unused upper 
		/// bits of the return value can safely be ignored (e.g., with a 
		/// 16-bpp format the return value can be assigned to a Uint16, 
		/// and similarly a Uint8 for an 8-bpp format).</returns>
		/// <seealso cref="SDL_GetRGB">SDL_GetRGB</seealso>
		/// <seealso cref="SDL_GetRGBA">SDL_GetRGBA</seealso>
		/// <seealso cref="SDL_MapRGB">SDL_MapRGB</seealso>
		/// <seealso cref="SDL_PixelFormat">SDL_PixelFormat</seealso> 
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_MapRGBA(IntPtr format, byte r, byte g,
			byte b, byte a);
		#endregion int SDL_MapRGBA(IntPtr format, byte r, byte g, byte b, byte a)

		#region void SDL_GetRGB(int pixel, IntPtr fmt, out byte r, out byte g, out byte b)
		/// <summary>
		/// Get RGB values from a pixel in the specified pixel format.
		/// </summary>
		/// <remarks>
		/// Get RGB component values from a pixel stored in the specified pixel format.
		/// <p>This function uses the entire 8-bit [0..255] range when converting 
		/// color components from pixel formats with less than 8-bits per RGB component
		///  (e.g., a completely white pixel in 16-bit RGB565 format would return 
		///  [0xff, 0xff, 0xff] not [0xf8, 0xfc, 0xf8]).</p>
		///  <p>Binds to C-function call in SDL_video.h:
		/// <code>void SDL_GetRGB(Uint32 pixel, SDL_PixelFormat *fmt, Uint8 *r, Uint8 *g, Uint8 *b);</code>
		/// </p>
		///  </remarks>
		/// <param name="pixel"></param>
		/// <param name="fmt"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		/// <seealso cref="SDL_GetRGBA">SDL_GetRGBA</seealso>
		/// <seealso cref="SDL_MapRGB">SDL_MapRGB</seealso>
		/// <seealso cref="SDL_MapRGBA">SDL_MapRGBA</seealso>
		/// <seealso cref="SDL_PixelFormat">SDL_PixelFormat</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_GetRGB(int pixel, IntPtr fmt, 
			out byte r, out byte g, out byte b);
		#endregion void SDL_GetRGB(int pixel, IntPtr fmt, out byte r, out byte g, out byte b)
		
		#region void SDL_GetRGBA(...)
		/// <summary>
		/// Get RGBA values from a pixel in the specified pixel format.
		/// </summary>
		/// <remarks>
		/// Get RGBA component values from a pixel stored in the specified pixel 
		/// format.
		/// <p>This function uses the entire 8-bit [0..255] range when converting 
		/// color components from pixel formats with less than 8-bits per RGB 
		/// component (e.g., a completely white pixel in 16-bit RGB565 format would
		///  return [0xff, 0xff, 0xff] not [0xf8, 0xfc, 0xf8]).</p>
		/// <p>If the surface has no alpha component, the alpha will be returned 
		/// as 0xff (100% opaque).</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>void SDL_GetRGBA(Uint32 pixel, SDL_PixelFormat *fmt, Uint8 *r, Uint8 *g, Uint8 *b, Uint8 *a)</code>
		/// </p>
		/// </remarks>
		/// <param name="pixel"></param>
		/// <param name="fmt"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		/// <param name="a"></param>
		/// <seealso cref="SDL_GetRGB">SDL_GetRGB</seealso>
		/// <seealso cref="SDL_MapRGB">SDL_MapRGB</seealso>
		/// <seealso cref="SDL_MapRGBA">SDL_MapRGBA</seealso>
		/// <seealso cref="SDL_PixelFormat">SDL_PixelFormat</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_GetRGBA(int pixel, IntPtr fmt, 
			out byte r, out byte g, out byte b, out byte a);
		#endregion void SDL_GetRGBA(...)

		#region IntPtr SDL_CreateRGBSurface(...)
		/// <summary>
		/// Create an empty SDL_Surface
		/// </summary>
		/// <remarks>
		/// Allocate an empty surface (must be called after <see cref="SDL_SetVideoMode"/>).
		/// <p>If depth is 8 bits an empty palette is allocated for the surface, 
		/// otherwise a 'packed-pixel' <see cref="SDL_PixelFormat"/> is created using the 
		/// [RGBA]mask's provided (see SDL_PixelFormat). The flags specifies 
		/// the type of surface that should be created, it is an OR'd combination
		///  of the following possible values.</p>
		/// <list type="table">
		///             <item>
		///                 <term><see cref="SDL_SWSURFACE" /></term>
		///                 <description>
		///                 SDL will create the surface in system memory. 
		///                 This improves the performance of pixel level access, 
		///                 however you may not be able to take advantage of 
		///                 some types of hardware blitting.
		///                 </description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_HWSURFACE" /></term>
		///                 <description>
		///                 SDL will attempt to create the surface in
		///                  video memory. This will allow SDL to take advantage 
		///                  of Video->Video blits (which are often accelerated).
		///                  </description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_SRCCOLORKEY" /></term>
		///                 <description>
		///                 This flag turns on colourkeying for 
		///                 blits from this surface. If SDL_HWSURFACE is also 
		///                 specified and colourkeyed blits are hardware-accelerated,
		///                  then SDL will attempt to place the surface in video 
		///                  memory. Use <see cref="SDL_SetColorKey"/> 
		///                  to set or clear this flag
		///                   after surface creation.
		///                   </description>
		///             </item>
		///             <item>
		///                 <term><see cref="SDL_SRCALPHA" /></term>
		///                 <description>
		///                 This flag turns on alpha-blending for 
		///                 blits from this surface. If SDL_HWSURFACE is also 
		///                 specified and alpha-blending blits are 
		///                 hardware-accelerated, then the surface will be placed 
		///                 in video memory if possible. Use 
		///                 <see cref="SDL_SetAlpha"/> to set 
		///                 or clear this flag after surface creation.
		///                 </description>
		///             </item>
		///         </list>
		///         <p><b>Note:</b> If an alpha-channel is specified (that is, 
		///         if Amask is nonzero), then the SDL_SRCALPHA flag is 
		///         automatically set. You may remove this flag by 
		///         calling <see cref="SDL_SetAlpha"/> after surface creation.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>SDL_Surface *SDL_CreateRGBSurface(Uint32 flags, int width, int height, int depth, Uint32 Rmask, Uint32 Gmask, Uint32 Bmask, Uint32 Amask)</code>
		/// </p>
		/// </remarks>
		/// <example>
		/// /* Create a 32-bit surface with the bytes of each pixel in R,G,B,A order,
		/// as expected by OpenGL for textures */
		/// SDL_Surface *surface;
		/// Uint32 rmask, gmask, bmask, amask;
		///
		/// /* SDL interprets each pixel as a 32-bit number, so our masks must depend
		///   on the endianness (byte order) of the machine */
		///#if SDL_BYTEORDER == SDL_BIG_ENDIAN
		///		rmask = 0xff000000;
		///		gmask = 0x00ff0000;
		///		bmask = 0x0000ff00;
		///		amask = 0x000000ff;
		///#else
		///    rmask = 0x000000ff;
		///    gmask = 0x0000ff00;
		///    bmask = 0x00ff0000;
		///    amask = 0xff000000;
		///#endif
		///
		///		surface = SDL_CreateRGBSurface(SDL_SWSURFACE, width, height, 32,
		///		rmask, gmask, bmask, amask);
		///		if(surface == NULL) 
		///	{
		///		fprintf(stderr, "CreateRGBSurface failed: %s\n", SDL_GetError());
		///		exit(1);
		///	}
		/// </example>
		/// <param name="flags"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="depth"></param>
		/// <param name="Rmask"></param>
		/// <param name="Gmask"></param>
		/// <param name="Bmask"></param>
		/// <param name="Amask"></param>
		/// <returns>IntPtr to <see cref="SDL_Surface"/>, or NULL upon error.</returns>
		/// <seealso cref="SDL_CreateRGBSurfaceFrom">SDL_CreateRGBSurfaceFrom</seealso>
		/// <seealso cref="SDL_FreeSurface">SDL_FreeSurface</seealso>
		/// <seealso cref="SDL_SetVideoMode">SDL_SetVideoMode</seealso>
		/// <seealso cref="SDL_LockSurface">SDL_LockSurface</seealso>
		/// <seealso cref="SDL_PixelFormat">SDL_PixelFormat</seealso>
		/// <seealso cref="SDL_Surface">SDL_Surface</seealso>
		/// <seealso cref="SDL_SetAlpha">SDL_SetAlpha</seealso>
		/// <seealso cref="SDL_SetColorKey">SDL_SetColorKey</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_CreateRGBSurface(int flags, 
			int width, int height, int depth, 
			int Rmask, int Gmask, int Bmask, int Amask);
		#endregion IntPtr SDL_CreateRGBSurface(...)

		#region IntPtr SDL_AllocSurface(...)
		/// <summary>
		/// Same as <see cref="SDL_CreateRGBSurface"/>
		/// </summary>
		/// <param name="flags"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="depth"></param>
		/// <param name="Rmask"></param>
		/// <param name="Gmask"></param>
		/// <param name="Bmask"></param>
		/// <param name="Amask"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="SDL_CreateRGBSurface"),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_AllocSurface(int flags, 
			int width, int height, int depth, 
			int Rmask, int Gmask, int Bmask, int Amask);
		#endregion IntPtr SDL_AllocSurface(...)

		#region IntPtr SDL_CreateRGBSurfaceFrom(...)
		/// <summary>
		/// Create an SDL_Surface from pixel data
		/// </summary>
		/// <remarks>
		/// Creates an SDL_Surface from the provided pixel data.
		/// <p>
		/// The data stored in pixels is assumed to be of the depth specified 
		/// in the parameter list. The pixel data is not copied into the SDL_Surface
		///  structure so it should not be freed until the surface has been freed 
		///  with a called to <see cref="SDL_FreeSurface"/>. pitch is the length of each scanline
		///   in bytes. </p>
		///   <p>
		/// See <see cref="SDL_CreateRGBSurface"/> for a more detailed description of the other 
		/// parameters.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>SDL_Surface *SDL_CreateRGBSurfaceFrom(void *pixels, int width, int height, int depth, int pitch, Uint32 Rmask, Uint32 Gmask, Uint32 Bmask, Uint32 Amask)</code>
		/// </p>
		/// </remarks>
		/// <param name="pixels"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="depth"></param>
		/// <param name="pitch">length of each scanline in bytes.</param>
		/// <param name="Rmask"></param>
		/// <param name="Gmask"></param>
		/// <param name="Bmask"></param>
		/// <param name="Amask"></param>
		/// <returns>Returns the created surface, or NULL upon error.
		/// </returns>
		/// <seealso cref="SDL_CreateRGBSurface"/>
		/// <seealso cref="SDL_FreeSurface"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_CreateRGBSurfaceFrom(IntPtr pixels, 
			int width, int height, int depth, int pitch, int Rmask, 
			int Gmask, int Bmask, int Amask);
		#endregion IntPtr SDL_CreateRGBSurfaceFrom(...)

		#region void SDL_FreeSurface(IntPtr surface)
		/// <summary>
		/// Frees (deletes) a SDL_Surface
		/// </summary>
		/// <remarks>
		/// Frees the resources used by a previously created <see cref="SDL_Surface"/>.
		/// If the surface was created using <see cref="SDL_CreateRGBSurfaceFrom"/> 
		/// then the pixel data is not freed.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>void SDL_FreeSurface(SDL_Surface *surface)</code>
		/// </p>
		/// </remarks>
		/// <param name="surface"></param>
		/// <seealso cref="SDL_CreateRGBSurface">SDL_CreateRGBSurface</seealso>
		/// <seealso cref="SDL_CreateRGBSurfaceFrom">SDL_CreateRGBSurfaceFrom</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_FreeSurface(IntPtr surface);
		#endregion void SDL_FreeSurface(IntPtr surface)

		//		#region void SDL_FreeSurface(ref IntPtr surface)
		//		/// <summary>
		//		/// Frees (deletes) a SDL_Surface
		//		/// </summary>
		//		/// <remarks>
		//		/// Frees the resources used by a previously created <see cref="SDL_Surface"/>.
		//		/// If the surface was created using <see cref="SDL_CreateRGBSurfaceFrom"/> 
		//		/// then the pixel data is not freed.
		//		/// <p>Binds to C-function call in SDL_video.h:
		//		/// <code>void SDL_FreeSurface(SDL_Surface *surface)</code>
		//		/// </p>
		//		/// </remarks>
		//		/// <param name="surface"></param>
		//		/// <seealso cref="SDL_CreateRGBSurface">SDL_CreateRGBSurface</seealso>
		//		/// <seealso cref="SDL_CreateRGBSurfaceFrom">SDL_CreateRGBSurfaceFrom</seealso>
		//		public static void SDL_FreeSurface(ref IntPtr surface)
		//		{
		//			Marshal.DestroyStructure( surface, typeof(SDL_Surface));
		//			SDL_FreeSurfaceInternal(surface);
		//			surface = IntPtr.Zero;
		//		}
		//		#endregion void SDL_FreeSurface(ref IntPtr surface)

		#region int SDL_LockSurface(IntPtr surface)
		/// <summary>
		/// Lock a surface for directly access.
		/// </summary>
		/// <remarks>
		/// SDL_LockSurface sets up a surface for directly accessing the pixels. 
		/// Between calls to SDL_LockSurface and SDL_UnlockSurface, you can write
		///  to and read from <i>surface.pixels</i>, using the pixel format stored in 
		///  <i>surface.format</i>. Once you are done accessing the surface, 
		///  you should use SDL_UnlockSurface to release it.
		/// <p>Not all surfaces require locking. If SDL_MUSTLOCK(surface) evaluates
		///  to 0, then you can read and write to the surface at any time, and the 
		///  pixel format of the surface will not change. </p>
		/// <p>No operating system or library calls should be made between 
		/// lock/unlock pairs, as critical system locks may be held during this time.
		/// </p>
		/// <p>It should be noted, that since SDL 1.1.8 surface locks are recursive.
		///  This means that you can lock a surface multiple times, but each lock
		///   must have a match unlock. </p>
		///<code>
		///		.
		///		SDL_LockSurface( surface );
		///		.
		///		/* Surface is locked */
		///		/* Direct pixel access on surface here */
		///		.
		///		SDL_LockSurface( surface );
		///		.
		///		/* More direct pixel access on surface */
		///		.
		///		SDL_UnlockSurface( surface );
		///		/* Surface is still locked */
		///		/* Note: Is versions &lt; 1.1.8, the surface would have been */
		///		/* no longer locked at this stage                         */
		///		.
		///		SDL_UnlockSurface( surface );
		///		/* Surface is now unlocked */
		///		.
		///		</code>
		///		<p>Binds to C-function call in SDL_video.h:
		/// <code>int SDL_LockSurface(SDL_Surface *surface)</code>
		/// </p>
		/// </remarks>
		/// <param name="surface"></param>
		/// <returns>SDL_LockSurface returns 0, or -1 if the surface couldn't be locked.
		/// </returns>
		/// <seealso cref="SDL_UnlockSurface">SDL_UnlockSurface</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_LockSurface(IntPtr surface);
		#endregion int SDL_LockSurface(IntPtr surface)
		
		#region int SDL_UnlockSurface(IntPtr surface)
		/// <summary>
		/// Unlocks a previously locked surface.
		/// </summary>
		/// <remarks>
		/// Surfaces that were previously locked using <see cref="SDL_LockSurface"/> 
		/// must be unlocked with SDL_UnlockSurface. Surfaces should be 
		/// unlocked as soon as possible.
		/// <p>It should be noted that since 1.1.8, surface 
		/// locks are recursive. See <see cref="SDL_LockSurface"/>.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>void SDL_UnlockSurface(SDL_Surface *surface)</code>
		/// </p>
		/// </remarks>
		/// <param name="surface"></param>
		/// <returns></returns>
		/// <seealso cref="SDL_LockSurface">SDL_LockSurface</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_UnlockSurface(IntPtr surface);
		#endregion int SDL_UnlockSurface(IntPtr surface)
		
		#region IntPtr SDL_LoadBMP_RW(IntPtr src, int freesrc)
		/// <summary>
		/// Load a surface from a seekable SDL data source (memory or file.)
		/// </summary>
		/// <remarks>
		/// If 'freesrc' is non-zero, the source will be closed after being read.
		/// Returns the new surface, or NULL if there was an error.
		/// The new surface should be freed with SDL_FreeSurface().
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>SDL_Surface * SDLCALL SDL_LoadBMP_RW(SDL_RWops *src, int freesrc)
		/// </code></p>
		/// </remarks>
		/// <param name="src">IntPtr to SDL_Surface</param>
		/// <param name="freesrc"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_LoadBMP_RW(IntPtr src, int freesrc);
		#endregion IntPtr SDL_LoadBMP_RW(IntPtr src, int freesrc)

		#region IntPtr SDL_LoadBMP(string file)
		/// <summary>
		/// Load a Windows BMP file into an SDL_Surface.
		/// </summary>
		/// <remarks>
		/// Loads a surface from a named Windows BMP file.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>
		/// SDL_Surface * SDL_LoadBMP(const char *file)
		/// #define SDL_LoadBMP(file)	SDL_LoadBMP_RW(SDL_RWFromFile(file, "rb"), 1)
		/// </code></p>
		/// </remarks>
		/// <param name="file"></param>
		/// <returns>Returns the new surface, or NULL if there was an error.</returns>
		/// <seealso cref="SDL_SaveBMP">SDL_SaveBMP</seealso>
		public static IntPtr SDL_LoadBMP(string file)
		{
			return SDL_LoadBMP_RW(SDL_RWFromFile(file, "rb"), 1);
		}
		#endregion IntPtr SDL_LoadBMP(string file)

		#region int SDL_SaveBMP_RW(IntPtr surface, IntPtr dst, int freedst)
		/// <summary>
		/// Save a surface to a seekable SDL data source (memory or file.)
		/// </summary>
		/// <remarks>If 'freedst' is non-zero, the source will be closed after 
		/// being written.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>
		/// int SDLCALL SDL_SaveBMP_RW (SDL_Surface *surface, SDL_RWops *dst, int freedst)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="surface"></param>
		/// <param name="dst"></param>
		/// <param name="freedst"></param>
		/// <returns>Returns 0 if successful or -1 if there was an error.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SaveBMP_RW(IntPtr surface, IntPtr dst,
			int freedst);
		#endregion int SDL_SaveBMP_RW(IntPtr surface, IntPtr dst, int freedst)

		#region int SDL_SaveBMP(IntPtr surface, string file)
		/// <summary>
		/// Save an SDL_Surface as a Windows BMP file.
		/// </summary>
		/// <remarks>
		/// Saves the SDL_Surface surface as a Windows BMP file named file.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>
		/// int SDL_SaveBMP(SDL_Surface *surface, const char *file);
		/// #define SDL_SaveBMP(surface, file) SDL_SaveBMP_RW(surface, SDL_RWFromFile(file, "wb"), 1)
		/// </code></p>
		/// </remarks>
		/// <param name="file"></param>
		/// <param name="surface"></param>
		/// <returns>Returns 0 if successful or -1 if there was an error.</returns>
		/// <seealso cref="SDL_SaveBMP">SDL_LoadBMP</seealso>
		public static int SDL_SaveBMP(IntPtr surface, string file)
		{
			return SDL_SaveBMP_RW(surface, SDL_RWFromFile(file, "wb"), 1);
		}
		#endregion int SDL_SaveBMP(IntPtr surface, string file)
	
		#region int SDL_SetColorKey(IntPtr surface, int flag, int key)
		/// <summary>
		/// Sets the color key (transparent pixel) in a blittable surface and RLE acceleration.
		/// </summary>
		/// <remarks>
		/// Sets the color key (transparent pixel) in a blittable surface and 
		/// enables or disables RLE blit acceleration.
		/// <p>RLE acceleration can substantially speed up blitting of images 
		/// with large horizontal runs of transparent pixels (i.e., pixels that
		///  match the key value). The key must be of the same pixel format as 
		///  the surface, <see cref="SDL_MapRGB"/> is often useful for obtaining an acceptable 
		///  value.</p>
		/// <p>If flag is SDL_SRCCOLORKEY then key is the transparent pixel value 
		/// in the source image of a blit.</p>		
		/// <p>If flag is OR'd with SDL_RLEACCEL then the surface will be draw 
		/// using RLE acceleration when drawn with <see cref="SDL_BlitSurface"/>. The surface 
		/// will actually be encoded for RLE acceleration the first time 
		/// <see cref="SDL_BlitSurface"/> or <see cref="SDL_DisplayFormat"/> is called on the surface.</p>
		/// <p>If flag is 0, this function clears any current color key.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>int SDL_SetColorKey(SDL_Surface *surface, Uint32 flag, Uint32 key);
		/// </code></p>
		/// </remarks>
		/// <param name="surface"></param>
		/// <param name="flag"></param>
		/// <param name="key"></param>
		/// <returns>
		/// This function returns 0, or -1 if there was an error.
		/// </returns>
		/// <seealso cref="SDL_BlitSurface">SDL_BlitSurface</seealso>
		/// <seealso cref="SDL_DisplayFormat">SDL_DisplayFormat</seealso>
		/// <seealso cref="SDL_MapRGB">SDL_MapRGB</seealso>
		/// <seealso cref="SDL_SetAlpha">SDL_SetAlpha</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetColorKey(IntPtr surface, int flag,
			int key);
		#endregion int SDL_SetColorKey(IntPtr surface, int flag, int key)

		#region int SDL_SetAlpha(IntPtr surface, int flag, byte alpha);
		/// <summary>
		/// Adjust the alpha properties of a surface.
		/// </summary>
		/// <remarks>
		/// SDL_SetAlpha is used for setting the per-surface alpha value and/or
		/// enabling and disabling alpha blending.
		/// <p>The surface parameter specifies which surface whose alpha 
		/// attributes you wish to adjust. flags is used to specify whether
		///  alpha blending should be used (SDL_SRCALPHA) and whether the 
		///  surface should use RLE acceleration for blitting (SDL_RLEACCEL).
		///   flags can be an OR'd combination of these two options, one of 
		///   these options or 0. If SDL_SRCALPHA is not passed as a flag then 
		///   all alpha information is ignored when blitting the surface. The
		///    alpha parameter is the per-surface alpha value; a surface 
		///    need not have an alpha channel to use per-surface alpha and 
		///    blitting can still be accelerated with SDL_RLEACCEL.</p>
		/// <p>Note: The per-surface alpha value of 128 is considered a 
		/// special case and is optimised, so it's much faster than other 
		/// per-surface values.</p>
		/// Alpha effects surface blitting in the following ways:
		/// <list type="table">
		///             <item>
		///                 <term>RGBA-&gt;RGB with SDL_SRCALPHA</term>
		///                 <description>The source is alpha-blended with 
		///                 the destination, using the alpha channel. 
		///                 SDL_SRCCOLORKEY and the per-surface alpha 
		///                 are ignored.</description>
		///             </item>
		///             <item>
		///                 <term>RGBA-&gt;RGB without SDL_SRCALPHA</term>
		///                 <description>The RGB data is copied from the source.
		///                  The source alpha channel and the per-surface
		///                   alpha value are ignored.</description>
		///             </item>
		///             <item>
		///                 <term>RGB-&gt;RGBA with SDL_SRCALPHA</term>
		///                 <description>The source is alpha-blended with the 
		///                 destination using the per-surface alpha value. 
		///                 If SDL_SRCCOLORKEY is set, only the pixels not 
		///                 matching the colorkey value are copied. The alpha 
		///                 channel of the copied pixels is set to opaque.
		///                 </description>
		///             </item>
		///             <item>
		///                 <term>RGB-&gt;RGBA without SDL_SRCALPHA</term>
		///                 <description>The RGB data is copied from the 
		///                 source and the alpha value of the copied pixels
		///                  is set to opaque. If SDL_SRCCOLORKEY is set, 
		///                  only the pixels not matching the colorkey value
		///                   are copied.</description>
		///             </item>
		///             <item>
		///                 <term>RGBA-&gt;RGBA with SDL_SRCALPHA</term>
		///                 <description>The source is alpha-blended with
		///                  the destination using the source alpha channel.
		///                   The alpha channel in the destination surface 
		///                   is left untouched. SDL_SRCCOLORKEY is ignored.
		///                   </description>
		///             </item>
		///             <item>
		///                 <term>RGBA-&gt;RGBA without SDL_SRCALPHA</term>
		///                 <description>The RGBA data is copied to the destination
		///                  surface. If SDL_SRCCOLORKEY is set, only the pixels 
		///                  not matching the colorkey value are copied.
		///                  </description>
		///             </item>
		///             <item>
		///                 <term>RGB-&gt;RGB with SDL_SRCALPHA</term>
		///                 <description>The source is alpha-blended with the 
		///                 destination using the per-surface alpha value. 
		///                 If SDL_SRCCOLORKEY is set, only the pixels not 
		///                 matching the colorkey value are copied.
		///                 </description>
		///             </item>
		///             <item>
		///                 <term>RGB-&gt;RGB without SDL_SRCALPHA</term>
		///                 <description>The RGB data is copied from the source.
		///                  If SDL_SRCCOLORKEY is set, only the pixels not 
		///                  matching the colorkey value are copied.
		///                  </description>
		///             </item>
		///         </list>
		/// <p>Note: Note that RGBA-&gt;RGBA blits (with SDL_SRCALPHA set) keep 
		/// the alpha of the destination surface. This means that you cannot 
		/// compose two arbitrary RGBA surfaces this way and get the result 
		/// you would expect from "overlaying" them; the destination alpha 
		/// will work as a mask.</p>
		/// <p>Also note that per-pixel and per-surface alpha cannot be
		///  combined; the per-pixel alpha is always used if available.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>int SDL_SetAlpha(SDL_Surface *surface, Uint32 flag, Uint8 alpha);
		/// </code></p>
		/// </remarks>
		/// <param name="surface"></param>
		/// <param name="flag"></param>
		/// <param name="alpha"></param>
		/// <returns>This function returns 0, or -1 if there was an error.
		/// </returns>
		/// <seealso cref="SDL_MapRGBA">SDL_MapRGBA</seealso>
		/// <seealso cref="SDL_GetRGBA">SDL_GetRGBA</seealso>
		/// <seealso cref="SDL_DisplayFormatAlpha">SDL_DisplayFormatAlpha</seealso>
		/// <seealso cref="SDL_BlitSurface">SDL_BlitSurface</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetAlpha(IntPtr surface, int flag, 
			byte alpha);
		#endregion int SDL_SetAlpha(IntPtr surface, int flag, byte alpha);

		#region void SDL_SetClipRect(IntPtr surface, ref Sdl_Rect rect)
		/// <summary>
		/// Sets the clipping rectangle for a surface.
		/// </summary>
		/// <remarks>
		/// Sets the clipping rectangle for a surface. When this surface 
		/// is the destination of a blit, only the area within the clip 
		/// rectangle will be drawn into.
		/// <p>The rectangle pointed to by rect will be clipped to the 
		/// edges of the surface so that the clip rectangle for a surface 
		/// can never fall outside the edges of the surface.</p>
		/// <p>If rect is NULL the clipping rectangle will be set to the 
		/// full size of the surface.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>
		/// void SDL_SetClipRect(SDL_Surface *surface, SDL_Rect *rect)
		/// </code></p>
		/// </remarks>
		/// <param name="surface">IntPtr to SDL_Surface</param>
		/// <param name="rect">SDL_Rect</param>
		/// <seealso cref="SDL_GetClipRect">SDL_GetClipRect</seealso>
		/// <seealso cref="SDL_BlitSurface">SDL_BlitSurface</seealso>
		/// <seealso cref="SDL_Surface">SDL_Surface</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_SetClipRect(IntPtr surface, ref SDL_Rect rect);
		#endregion void SDL_SetClipRect(IntPtr surface, ref SDL_Rect rect)
		
		#region void SDL_GetClipRect(IntPtr surface, ref SDL_Rect rect)
		/// <summary>
		/// Gets the clipping rectangle for a surface.
		/// </summary>
		/// <remarks>
		/// Gets the clipping rectangle for a surface. 
		/// When this surface is the destination of a blit, 
		/// only the area within the clip rectangle is drawn into.
		/// <p>The rectangle pointed to by rect will be filled with the 
		/// clipping rectangle of the surface.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>
		/// void SDL_GetClipRect(SDL_Surface *surface, SDL_Rect *rect)
		/// </code></p>
		/// </remarks>
		/// <param name="surface">IntPtr to SDL_Surface</param>
		/// <param name="rect">SDL_Rect</param>
		/// <seealso cref="SDL_SetClipRect">SDL_SetClipRect</seealso>
		/// <seealso cref="SDL_BlitSurface">SDL_BlitSurface</seealso>
		/// <seealso cref="SDL_Surface">SDL_Surface</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_GetClipRect(IntPtr surface, ref SDL_Rect rect);
		#endregion void SDL_GetClipRect(IntPtr surface, ref SDL_Rect rect)
		
		#region IntPtr SDL_ConvertSurface(IntPtr src, IntPtr fmt, int flags)
		/// <summary>
		/// Converts a surface to the same format as another surface.
		/// </summary>
		/// <remarks>
		/// Creates a new surface of the specified format, 
		/// and then copies and maps the given surface to it. 
		/// If this function fails, it returns NULL.
		/// <p>The flags parameter is passed to 
		/// <see cref="SDL_CreateRGBSurface"/> and has those semantics.</p>
		/// <p>This function is used internally by <see cref="SDL_DisplayFormat"/>.</p>
		/// <p>This function can only be called after SDL_Init.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>
		/// SDL_Surface *SDL_ConvertSurface(SDL_Surface *src, SDL_PixelFormat *fmt, Uint32 flags)
		/// </code></p>
		/// </remarks>
		/// <param name="src">IntPtr to SDL_Surface</param>
		/// <param name="fmt">IntPTr to SDL_PixelFormat</param>
		/// <param name="flags"></param>
		/// <returns>
		/// Returns either a pointer to the new surface, or NULL on error.
		/// </returns>
		/// <seealso cref="SDL_CreateRGBSurface">SDL_CreateRGBSurface</seealso>
		/// <seealso cref="SDL_DisplayFormat">SDL_DisplayFormat</seealso>
		/// <seealso cref="SDL_PixelFormat">SDL_PixelFormat</seealso>
		/// <seealso cref="SDL_Surface">SDL_Surface</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_ConvertSurface(IntPtr src, IntPtr fmt,
			int flags);
		#endregion IntPtr SDL_ConvertSurface(IntPtr src, IntPtr fmt, int flags)

		#region int SDL_BlitSurface(IntPtr src, IntPtr srcrect, IntPtr dst, IntPtr dstrect)
		/// <summary>
		/// This performs a fast blit from the source surface to the 
		/// destination surface.
		/// </summary>
		/// <remarks>
		/// This performs a fast blit from the source surface 
		/// to the destination surface.
		/// <p>The width and height in srcrect determine the 
		/// size of the copied rectangle. Only the position is used 
		/// in the dstrect (the width and height are ignored).</p>
		/// <p>If srcrect is NULL, the entire surface is copied. 
		/// If dstrect is NULL, then the destination position 
		/// (upper left corner) is (0, 0).</p>
		/// <p>The final blit rectangle is saved in dstrect after all 
		/// clipping is performed (srcrect is not modified).</p>
		/// <p>The blit function should not be called on a locked surface.</p>
		/// <p> The results of blitting operations vary greatly depending 
		/// on whether SDL_SRCAPLHA is set or not. See SDL_SetAlpha for an
		///  explaination of how this affects your results. Colorkeying and 
		///  alpha attributes also interact with surface blitting, as the
		///  following pseudo-code should hopefully explain. </p>
		/// <code>if (source surface has SDL_SRCALPHA set) 
		///	{
		///		if (source surface has alpha channel (that is, format->Amask != 0))
		///		blit using per-pixel alpha, ignoring any colour key
		///		else {
		///		if (source surface has SDL_SRCCOLORKEY set)
		///			blit using the colour key AND the per-surface alpha value
		///		else
		///			blit using the per-surface alpha value
		///		}
		///} 
		///else 
		///{
		///if (source surface has SDL_SRCCOLORKEY set)
		///blit using the colour key
		///else
		///ordinary opaque rectangular blit
		///}</code>
		///<p>Binds to C-function call in SDL_video.h:
		///<code>int SDL_BlitSurface(SDL_Surface *src, SDL_Rect *srcrect, SDL_Surface *dst, SDL_Rect *dstrect);
		///</code></p>
		/// </remarks>
		/// <param name="src">IntPtr to SDL_Surface</param>
		/// <param name="srcrect">IntPtr to SDL_Rect</param>
		/// <param name="dst">IntPtr to SDL_Surface</param>
		/// <param name="dstrect">IntPtr to SDL_Rect</param>
		/// <returns>If the blit is successful, it returns 0, otherwise it 
		/// returns -1.
		/// <p>If either of the surfaces were in video memory, 
		/// and the blit returns -2, the video memory was lost, 
		/// so it should be reloaded with artwork and re-blitted: </p>
		///
		/// <code>while ( SDL_BlitSurface(image, imgrect, screen, dstrect) == -2 ) 
		///	{
		///		while ( SDL_LockSurface(image)) &lt; 0 )
		///		SDL_Delay(10);
		///		-- Write image pixels to image-&gt;pixels --
		///		SDL_UnlockSurface(image);
		///	}
		///	</code>
		/// <p>This happens under DirectX 5.0 when the system switches away from your 
		/// fullscreen application. Locking the surface will also fail until you 
		/// have access to the video memory again.</p>	
		/// </returns>	
		/// <seealso cref="SDL_LockSurface"/>
		/// <seealso cref="SDL_FillRect"/>
		/// <seealso cref="SDL_Surface"/>
		/// <seealso cref="SDL_Rect"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, 
			 EntryPoint="SDL_UpperBlit"), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_BlitSurface(IntPtr src, ref SDL_Rect srcrect,
			IntPtr dst, ref SDL_Rect dstrect);
		#endregion int SDL_BlitSurface(IntPtr src, IntPtr srcrect, IntPtr dst, IntPtr dstrect)

		//	semi-private --	should not be used and will	not	be implemented.
		//	SDL_UpperBlit									
		//	SDL_LowerBlit

		#region int SDL_FillRect(IntPtr surface, ref SDL_Rect rect, int color)
		/// <summary>
		/// This function performs a fast fill of the given rectangle with some color.
		/// </summary>
		/// <remarks>
		/// This function performs a fast fill of the given rectangle with color. 
		/// If dstrect is NULL, the whole surface will be filled with color.
		/// <p>The color should be a pixel of the format used by the surface,
		///  and can be generated by the <see cref="SDL_MapRGB"/> or 
		///  <see cref="SDL_MapRGBA"/> functions.
		///   If the color value contains an alpha value then the destination
		///    is simply "filled" with that alpha information, no blending 
		///    takes place.</p>
		/// <p>If there is a clip rectangle set on the destination (set via
		///  <see cref="SDL_SetClipRect"/>) then this function will clip based on the 
		///  intersection of the clip rectangle and the dstrect rectangle 
		///  and the dstrect rectangle will be modified to represent the 
		///  area actually filled.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>
		/// int SDL_FillRect(SDL_Surface *dst, SDL_Rect *dstrect, Uint32 color);
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="surface">IntPtr to SDL_Surface</param>
		/// <param name="rect">IntPtr to SDL_Rect</param>
		/// <param name="color"></param>
		/// <returns>
		/// This function returns 0 on success, or -1 on error.
		/// </returns>
		/// <seealso cref="SDL_MapRGB"/>
		/// <seealso cref="SDL_MapRGBA"/>
		/// <seealso cref="SDL_BlitSurface"/>
		/// <seealso cref="SDL_Rect"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_FillRect(IntPtr surface, ref SDL_Rect rect,
			int color);
		#endregion int SDL_FillRect(IntPtr surface, ref SDL_Rect rect, int color)

		#region IntPtr SDL_DisplayFormat(IntPtr surface)
		/// <summary>
		/// Convert a surface to the display format.
		/// </summary>
		/// <remarks>
		/// This function takes a surface and copies it to a new surface of the 
		/// pixel format and colors of the video framebuffer, suitable for fast
		///  blitting onto the display surface. It calls 
		///  <see cref="SDL_ConvertSurface"/>.
		/// <p>If you want to take advantage of hardware colorkey or alpha blit
		///  acceleration, you should set the colorkey and alpha value before 
		///  calling this function.</p>
		/// <p>If you want an alpha channel, see 
		/// <see cref="SDL_DisplayFormatAlpha"/>.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>SDL_Surface *SDL_DisplayFormat(SDL_Surface *surface)
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="surface">IntPtr to SDL_Surface</param>
		/// <returns>IntPtr to SDL_Surface. 
		/// If the conversion fails or runs out of memory, 
		/// it returns NULL</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_DisplayFormat(IntPtr surface);
		#endregion IntPtr SDL_DisplayFormat(IntPtr surface)

		#region IntPtr SDL_DisplayFormatAlpha(IntPtr surface)
		/// <summary>
		/// Convert a surface to the display format.
		/// </summary>
		/// <remarks>
		/// This function takes a surface and copies it to a new surface of the 
		/// pixel format and colors of the video framebuffer plus an alpha channel,
		///  suitable for fast blitting onto the display surface. 
		///  It calls <see cref="SDL_ConvertSurface"/>.
		/// <p>If you want to take advantage of hardware colorkey or alpha blit
		///  acceleration, you should set the colorkey and alpha value before 
		///  calling this function.</p>
		/// <p>This function can be used to convert a colourkey to an alpha 
		/// channel, if the SDL_SRCCOLORKEY flag is set on the surface. The 
		/// generated surface will then be transparent (alpha=0) where the
		///  pixels match the colourkey, and opaque (alpha=255) elsewhere.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>SDL_Surface *SDL_DisplayFormatAlpha(SDL_Surface *surface)
		/// </code></p></remarks>
		/// <param name="surface"></param>
		/// <returns>IntPtr to SDL_Surface. 
		/// If the conversion fails or runs out of memory, 
		/// it returns NULL</returns>
		/// <seealso cref="SDL_ConvertSurface"/>
		/// <seealso cref="SDL_SetAlpha"/>
		/// <seealso cref="SDL_SetColorKey"/>
		/// <seealso cref="SDL_DisplayFormat"/>
		/// <seealso cref="SDL_Surface"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_DisplayFormatAlpha(IntPtr surface);
		#endregion IntPtr SDL_DisplayFormatAlpha(IntPtr surface)

		#region IntPtr SDL_CreateYUVOverlay(...);
		/// <summary>
		/// Create a YUV video overlay.
		/// </summary>
		/// <remarks>
		/// SDL_CreateYUVOverlay creates a YUV overlay of the specified width, 
		/// height and format (see <see cref="SDL_Overlay"/> for a list of 
		/// available formats),
		///  for the provided display. A <see cref="SDL_Overlay"/> 
		///  structure is returned.
		/// <p>The term 'overlay' is a misnomer since, unless the overlay is 
		/// created in hardware, the contents for the display surface underneath
		///  the area where the overlay is shown will be overwritten when the 
		///  overlay is displayed.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>SDL_Overlay *SDL_CreateYUVOverlay(int width, int height, Uint32 format, SDL_Surface *display)
		/// </code></p></remarks>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="format"></param>
		/// <param name="display">IntPtr to SDL_Surface</param>
		/// <returns>IntPtr to SDL_Overlay</returns>
		/// <seealso cref="SDL_Overlay"/>
		/// <seealso cref="SDL_DisplayYUVOverlay"/>
		/// <seealso cref="SDL_FreeYUVOverlay"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_CreateYUVOverlay(int width, int height, int format, IntPtr display);
		#endregion IntPtr SDL_CreateYUVOverlay(...);

		#region int SDL_LockYUVOverlay(IntPtr overlay)
		/// <summary>
		/// Lock an overlay
		/// </summary>
		/// <remarks>
		/// Much the same as <see cref="SDL_LockSurface"/>, 
		/// SDL_LockYUVOverlay locks the overlay for direct access to pixel data.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>int SDL_LockYUVOverlay(SDL_Overlay *overlay)
		/// </code></p></remarks>
		/// <param name="overlay"></param>
		/// <returns>Returns 0 on success, or -1 on an error</returns>
		/// <seealso cref="SDL_UnlockYUVOverlay"/>
		/// <seealso cref="SDL_CreateYUVOverlay"/>
		/// <seealso cref="SDL_Overlay"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_LockYUVOverlay(IntPtr overlay);
		#endregion int SDL_LockYUVOverlay(IntPtr overlay)

		#region void SDL_UnlockYUVOverlay(IntPtr overlay)
		/// <summary>
		/// Unlock an overlay.
		/// </summary>
		/// <remarks>
		/// The opposite to <see cref="SDL_LockYUVOverlay"/>. 
		/// Unlocks a previously locked overlay. 
		/// An overlay must be unlocked before it can be displayed.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>void SDLCALL SDL_UnlockYUVOverlay(SDL_Overlay *overlay)
		/// </code></p></remarks>
		/// <param name="overlay">IntPtr to SDL_Overlay</param>
		/// <seealso cref="SDL_UnlockYUVOverlay"/>
		/// <seealso cref="SDL_CreateYUVOverlay"/>
		/// <seealso cref="SDL_Overlay"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_UnlockYUVOverlay(IntPtr overlay);
		#endregion void SDL_UnlockYUVOverlay(IntPtr overlay)

		#region int SDL_DisplayYUVOverlay(IntPtr overlay, ref SDL_Rect dstrect)
		/// <summary>
		/// Blit the overlay to the display.
		/// </summary>
		/// <remarks>
		/// Blit the overlay to the surface specified when it was <see cref="SDL_CreateYUVOverlay">created</see>. 
		/// The <see cref="SDL_Rect"/> structure, dstrect, specifies the position and size of the 
		/// destination. If the dstrect is a larger or smaller than the overlay then
		///  the overlay will be scaled, this is optimized for 2x scaling.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>SDL_DisplayYUVOverlay(SDL_Overlay *overlay, SDL_Rect *dstrect)
		/// </code></p></remarks>
		/// <param name="overlay">IntPtr to SDL_Overlay</param>
		/// <param name="dstrect">SDL_Rect</param>
		/// <returns>Returns 0 on success.</returns>
		/// <seealso cref="SDL_Overlay"/>
		/// <seealso cref="SDL_CreateYUVOverlay"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_DisplayYUVOverlay(IntPtr overlay, ref SDL_Rect dstrect);
		#endregion int SDL_DisplayYUVOverlay(IntPtr overlay, ref SDL_Rect dstrect)

		#region void SDL_FreeYUVOverlay(IntPtr overlay)
		/// <summary>
		/// Free a YUV video overlay.
		/// </summary>
		/// <remarks>
		/// Frees an <see cref="SDL_Overlay">overlay</see> created by <see cref="SDL_CreateYUVOverlay"/>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>SDL_FreeYUVOverlay(SDL_Overlay *overlay)
		/// </code></p></remarks>
		/// <param name="overlay"></param>
		/// <seealso cref="SDL_Overlay"/>
		/// <seealso cref="SDL_DisplayYUVOverlay"/>
		/// <seealso cref="SDL_CreateYUVOverlay"/>
		/// SDL_Overlay, SDL_DisplayYUVOverlay, SDL_FreeYUVOverlay
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_FreeYUVOverlay(IntPtr overlay);
		#endregion void SDL_FreeYUVOverlay(IntPtr overlay)

		#region int SDL_GL_LoadLibrary(string path)
		/// <summary>
		/// Specify an OpenGL library.
		/// </summary>
		/// <remarks>
		/// If you wish, you may load the OpenGL library at runtime, this must 
		/// be done before <see cref="SDL_SetVideoMode"/> is called. 
		/// The path of the GL 
		/// library is passed to SDL_GL_LoadLibrary and it returns 0 on 
		/// success, or -1 on 
		///  an error. You must then use <see cref="SDL_GL_GetProcAddress"/>
		///   to retrieve 
		///  function pointers to GL functions.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>int SDL_GL_LoadLibrary(const char *path);
		/// </code></p></remarks>
		/// <param name="path"></param>
		/// <returns>Returns 0 on success, or -1 on an error.</returns>
		/// <seealso cref="SDL_GL_GetProcAddress"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GL_LoadLibrary(string path);
		#endregion int SDL_GL_LoadLibrary(string path)

		#region IntPtr SDL_GL_GetProcAddress(string proc)
		/// <summary>
		/// Get the address of a GL function
		/// </summary>
		/// <remarks>
		/// Returns the address of the GL function proc, or NULL if the 
		/// function is not found. If the GL library is loaded at runtime,
		///  with SDL_GL_LoadLibrary, then all GL functions must be retrieved
		///   this way. Usually this is used to retrieve function pointers 
		///   to OpenGL extensions.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>void *SDL_GL_GetProcAddress(const char* proc);
		/// </code></p></remarks>
		/// <example>
		/// <code>
		/// typedef void (*GL_ActiveTextureARB_Func)(unsigned int);
		///		GL_ActiveTextureARB_Func glActiveTextureARB_ptr = 0;
		///		int has_multitexture=1;
		///		.
		///		.
		///		.
		///		/* Get function pointer */
		///		glActiveTextureARB_ptr=(GL_ActiveTextureARB_Func) SDL_GL_GetProcAddress("glActiveTextureARB");
		///
		///		/* Check for a valid function ptr */
		///		if(!glActiveTextureARB_ptr)
		///			{
		///		fprintf(stderr, "Multitexture Extensions not present.\n");
		///		has_multitexture=0;
		///	}
		///	.
		///	.
		///	.
		///	.
		///	if(has_multitexture)
		///{
		///	glActiveTextureARB_ptr(GL_TEXTURE0_ARB);
		///	.
		///	.
		///}
		///	else
		///{
		///	.
		///	.
		///}
		/// </code>
		/// </example>
		/// <param name="proc"></param>
		/// <seealso cref="SDL_GL_LoadLibrary"/>
		/// <returns>Returns the address of the GL function proc, or NULL if the 
		/// function is not found.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_GL_GetProcAddress(string proc);
		#endregion IntPtr SDL_GL_GetProcAddress(string proc)

		#region void SDL_GL_SwapBuffers()
		/// <summary>
		/// Swap OpenGL framebuffers/Update Display
		/// </summary>
		/// <remarks>
		/// Swap the OpenGL buffers, if double-buffering is supported.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>void SDL_GL_SwapBuffers(void )
		/// </code></p></remarks>
		/// <seealso cref="SDL_SetVideoMode"/>
		/// <seealso cref="SDL_GL_SetAttribute"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_GL_SwapBuffers();
		#endregion void SDL_GL_SwapBuffers()

		#region int SDL_GL_SetAttribute(SDL_GLattr attr, int val)
		/// <summary>
		/// Set a special SDL/OpenGL attribute.
		/// </summary>
		/// <remarks>
		/// Sets the OpenGL attribute attr to value. 
		/// The attributes you set don't 
		/// take effect until after a call to <see cref="SDL_SetVideoMode"/>.
		///  You should use 
		/// <see cref="SDL_GL_GetAttribute"/> to check the values after a 
		/// SDL_SetVideoMode call.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>int SDL_GL_SetAttribute(SDL_GLattr attr, int value);
		/// </code></p></remarks>
		/// <param name="attr">SDL_GLattr enum</param>
		/// <param name="val"></param>
		/// <returns>Returns 0 on success, or -1 on error.</returns>
		/// <seealso cref="SDL_GL_GetAttribute"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GL_SetAttribute(int attr, 
			int val);
		#endregion int SDL_GL_SetAttribute(SDL_GLattr attr, int val)
		
		#region int SDL_GL_GetAttribute(SDL_GLattr attr, out int val);
		/// <summary>
		/// Get the value of a special SDL/OpenGL attribute
		/// </summary>
		/// <remarks>
		/// Places the value of the SDL/OpenGL 
		/// attribute attr into value. This is 
		/// useful after a call to <see cref="SDL_SetVideoMode"/> to check 
		/// whether your attributes have been 
		/// <see cref="SDL_GL_SetAttribute">set</see> as you expected.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>int SDL_GL_GetAttribute(SDLGLattr attr, int *value)
		/// </code></p>
		/// </remarks>
		/// <param name="attr">SDL_GLattr enum</param>
		/// <param name="val"></param>
		/// <returns>Returns 0 on success, or -1 on an error.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GL_GetAttribute(int attr, 
			out int val);
		#endregion int SDL_GL_GetAttribute(SDL_GLattr attr, out int val);
	
		//	Private functions that should not be called and will not be implmented.
		//	SDL_GL_UpdateRects
		//	SDL_GL_Lock
		//	SDL_GL_Unlock

		#region void SDL_WM_SetCaption(string title, string icon)
		/// <summary>
		/// Sets the title and icon text of the display window
		/// </summary>
		/// <remarks>
		/// Sets the title-bar and icon name of the display window.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>extern DECLSPEC void SDLCALL SDL_WM_SetCaption(const char *title, const char *icon)</code>
		/// </p>
		/// </remarks>
		/// <seealso cref="SDL_WM_GetCaption">SDL_WM_GetCaption</seealso>
		/// <seealso cref="SDL_WM_SetIcon">SDL_WM_SetIcon</seealso>
		/// <param name="title"></param>
		/// <param name="icon"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_WM_SetCaption(string title, string icon);
		#endregion void SDL_WM_SetCaption(string title, string icon)
		
		#region void SDL_WM_GetCaption(out string title, out string icon)
		/// <summary>
		/// Gets the title and icon text of the display window
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>extern DECLSPEC void SDLCALL SDL_WM_GetCaption(char **title, char **icon)</code>
		/// </p></remarks>
		/// <param name="title"></param>
		/// <param name="icon"></param>
		/// <seealso cref="SDL_WM_SetCaption">SDL_WM_SetCaption</seealso>
		/// <seealso cref="SDL_WM_SetIcon">SDL_WM_SetIcon</seealso>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_WM_GetCaption(out string title, 
			out string icon);
		#endregion void SDL_WM_GetCaption(out string title, out string icon)

		#region void SDL_WM_SetIcon(IntPtr icon, byte[] mask)
		/// <summary>
		/// Sets the icon for the display window.
		/// </summary>
		/// <remarks>
		/// Sets the icon for the display window. Win32 icons must be 32x32.
		/// <p>This function must be called before the first call to 
		/// <see cref="SDL_SetVideoMode"/>.</p>
		/// <p>The mask is a bitmask that describes the shape of the icon.
		///  If mask is NULL, then the shape is determined by the colorkey 
		///  of icon, if any, or makes the icon rectangular (no transparency)
		///   otherwise.</p>
		/// <p>If mask is non-NULL, it points to a bitmap with bits set where
		///  the corresponding pixel should be visible. The format of the bitmap
		///   is as follows: Scanlines come in the usual top-down order. Each 
		///   scanline consists of (width / 8) bytes, rounded up. The most 
		///   significant bit of each byte represents the leftmost pixel.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>void SDL_WM_SetIcon(SDL_Surface *icon, Uint8 *mask);
		/// </code></p>
		/// </remarks>
		/// <example>
		/// <code>SDL_WM_SetIcon(SDL_LoadBMP("icon.bmp"), NULL);
		/// </code></example>
		/// <param name="icon">Pointer to an SDL_Surface</param>
		/// <param name="mask"></param>
		/// <seealso cref="SDL_SetVideoMode"/>
		/// <seealso cref="SDL_WM_SetCaption"/>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_WM_SetIcon(IntPtr icon, byte[] mask);
		#endregion void SDL_WM_SetIcon(IntPtr icon, byte[] mask)
		
		#region int SDL_WM_IconifyWindow()
		/// <summary>Iconify/Minimise the window</summary>
		/// <remarks>
		/// This function iconifies/minimizes the window, and returns 1 if it succeeded.
		/// If the function succeeds, it generates an <see cref="SDL_APPACTIVE"/> loss event.
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>int SDL_WM_IconifyWindow(void)</code></p>
		/// </remarks>
		/// <returns>Returns 1 if it succeeded. 
		/// This function is a noop and returns 0 in non-windowed environments.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_WM_IconifyWindow();
		#endregion int SDL_WM_IconifyWindow()

		#region int SDL_WM_ToggleFullScreen(IntPtr surface);
		/// <summary>
		/// Toggle fullscreen mode without changing the contents of the screen.
		/// </summary>
		/// <remarks>If the display surface does not require locking before accessing
		/// the pixel information, then the memory pointers will not change.
		///<p>If this function was able to toggle fullscreen mode (change from 
		/// running in a window to fullscreen, or vice-versa),
		///  it will return 1.
		/// If it is not implemented, or fails, it returns 0.</p>
		/// <p>The next call to SDL_SetVideoMode() will set the mode fullscreen
		/// attribute based on the flags parameter - if SDL_FULLSCREEN is not
		/// set, then the display will be windowed by default where supported.</p>
		/// <p>This is currently only implemented in the X11 video driver.</p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>int SDL_WM_ToggleFullScreen(SDL_Surface *surface);</code></p>
		/// </remarks>
		/// <param name="surface"></param>
		/// <returns>Returns 0 on failure or 1 on success.</returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_WM_ToggleFullScreen(IntPtr surface);
		#endregion int SDL_WM_ToggleFullScreen(IntPtr surface);

		#region int SDL_WM_GrabInput(SDL_GrabMode mode);
		/// <summary>
		/// Grabs mouse and keyboard input.
		/// </summary>
		/// <remarks>
		/// Grabbing means that the mouse is confined to the application 
		/// window,
		/// and nearly all keyboard input is passed directly to the 
		/// application,
		/// and not interpreted by a window manager, if any.
		/// <p>
		/// When mode is SDL_GRAB_QUERY the grab mode is not changed, but the current grab mode is returned.
		/// </p>
		/// <p>Binds to C-function call in SDL_video.h:
		/// <code>SDL_GrabMode SDL_WM_GrabInput(SDL_GrabMode mode)</code></p>
		/// </remarks>
		/// <param name="mode">SDL_GrabMode</param>
		/// <returns>The current/new SDL_GrabMode.
		/// </returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_WM_GrabInput(int mode);
		#endregion int SDL_WM_GrabInput(SDL_GrabMode mode);
		#endregion SDL_video.h
		#endregion Sdl Methods
	}
}
