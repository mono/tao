#region License
/*
MIT License
Copyright ©2003-2004 Randy Ridge
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
using System.Runtime.InteropServices;
using System.Security;

namespace Tao.Sdl {
	#region Class Documentation
	/// <summary>
	///     Simple DirectMedia Layer binding for .NET, implementing SDL 1.2.7.
	/// </summary>
	/// <remarks>
	///     Binds functions and definitions in SDL.dll or libSDL.so.
	/// </remarks>
	#endregion Class Documentation
	public sealed class Sdl {
		// --- Fields ---
		#region Private Constants
		#region string SDL_NATIVE_LIBRARY
		/// <summary>
		///     Specifies SDL's native library archive.
		/// </summary>
		/// <remarks>
		///     Specifies SDL.dll for Windows and libSDL.so for Linux.
		/// </remarks>
#if WIN32
        private const string SDL_NATIVE_LIBRARY = "SDL.dll";
#elif LINUX
		private const string SDL_NATIVE_LIBRARY = "libSDL.so";
#endif
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
		#endregion Private Constants

		#region Public Constants
		// SDL
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

		// SDL_main -- none

		// SDL_types -- none

		// SDL_getenv -- none

		// SDL_error -- none

		// TODO: SDL_rwops -- skipped for now, might be useful.

		// SDL_timer
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

		/// <summary>
		/// Surface is in system memory
		/// </summary>
		public const int SDL_SWSURFACE = 0x00000000;

		/// <summary>
		/// Surface is in video memory
		/// </summary>
		public const int SDL_HWSURFACE = 0x00000001;

		/// <summary>
		///     Full screen display surface.
		/// </summary>
		// #define SDL_FULLSCREEN 0x80000000
		public const int SDL_FULLSCREEN = unchecked((int) 0x80000000);

		/// <summary>
		/// Surface has exclusive palette
		/// </summary>
		public const int SDL_HWPALETTE = 0x20000000;

		/// <summary>
		/// Create an OpenGL rendering context
		/// </summary>
		public const int SDL_OPENGL = 0x00000002;

		/// <summary>
		/// 
		/// </summary>
		public const int SDL_GL_DOUBLEBUFFER = 5;

		/// <summary>
		/// This video mode may be resized
		/// </summary>
		public const int SDL_RESIZABLE = 0x00000010;

		/// <summary>
		/// Blit uses hardware acceleration
		/// </summary>
		public const int SDL_HWACCEL = 0x00000100;

		/// <summary>
		/// Blit uses source alpha blending
		/// </summary>
		public const int SDL_SRCALPHA = 0x00010000;

		/// <summary>
		/// The app has mouse coverage
		/// </summary>
		/// <remarks>
		/// The available application states
		/// </remarks>
		public const Byte SDL_APPMOUSEFOCUS = 0x01;

		/// <summary>
		/// The app has input focus
		/// </summary>
		/// <remarks>
		/// The available application states
		/// </remarks>
		public const Byte SDL_APPINPUTFOCUS = 0x02;

		/// <summary>
		/// The application is active
		/// </summary>
		/// <remarks>
		/// The available application states
		/// </remarks>
		public const Byte SDL_APPACTIVE = 0x04;

		/// <summary>
		/// Unsigned 8-bit samples
		/// </summary>
		public const int AUDIO_U8 = 0x0008;

		/// <summary>
		/// Signed 8-bit samples
		/// </summary>
		public const int AUDIO_S8 = 0x8008;

		/// <summary>
		/// Unsigned 16-bit samples
		/// </summary>
		public const int AUDIO_U16LSB = 0x0010;

		/// <summary>
		/// Signed 16-bit samples
		/// </summary>
		public const int AUDIO_S16LSB	= 0x8010;	
		/// <summary>
		/// As above, but big-endian byte order
		/// </summary>
		public const int AUDIO_U16MSB	= 0x1010;
		/// <summary>
		/// As above, but big-endian byte order
		/// </summary>
		public const int AUDIO_S16MSB	= 0x9010;
		/// <summary>
		/// Audio format flags (defaults to LSB byte order)
		/// </summary>
		public int AUDIO_U16 = AUDIO_U16LSB;

		/// <summary>
		/// Audio format flags (defaults to LSB byte order)
		/// </summary>
		public int AUDIO_S16 = AUDIO_S16LSB;

		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_ESCAPE = 27;
		/// <summary>
		/// 
		/// </summary>
		public const int SDLK_F1 = 282;
		/// <summary>
		/// Use asynchronous blits if possible
		/// </summary>
		public const int SDL_ASYNCBLIT = 0X00000004;
		/// <summary>
		/// Allow any video depth/pixel-format
		/// </summary>
		public const int SDL_ANYFORMAT = 0X10000000;
		/// <summary>
		/// Set up double-buffered video mode
		/// </summary>
		public const int SDL_DOUBLEBUF = 0X40000000;
		/// <summary>
		/// Create an OpenGL rendering context and use it for blitting
		/// </summary>	
		public const int SDL_OPENGLBLIT = 0X0000000A;
		/// <summary>
		/// No window caption or edge frame
		/// </summary>
		public const int SDL_NOFRAME = 0X00000020;
		/// <summary>
		/// Surface is RLE encoded
		/// </summary>
		public const int SDL_RLEACCEL = 0X00004000;
		/// <summary>
		/// Blit uses a source color key
		/// </summary>
		public const int SDL_SRCCOLORKEY = 0x00001000;   
 
		/// <summary>
		/// Private flag
		/// </summary>
		public const int SDL_RLEACCELOK = 0x00002000;

		/// <summary>
		/// The maximum number of CD-ROM tracks on a disk
		/// </summary>
		public const int SDL_MAX_TRACKS = 99;

		/// <summary>
		/// The types of CD-ROM track possible
		/// </summary>
		public const int SDL_AUDIO_TRACK = 0x00;
		/// <summary>
		/// The types of CD-ROM track possible
		/// </summary>
		public const int SDL_DATA_TRACK = 0x04;

		/// <summary>
		/// Frames per second.
		/// </summary>
		public const int CD_FPS = 75;

		/// <summary>
		/// The most common video overlay formats.
		///For an explanation of these pixel formats, see:
		///http://www.webartz.com/fourcc/indexyuv.htm
		///
		///For information on the relationship between color spaces, see:
		///http://www.neuro.sfc.keio.ac.jp/~aly/polygon/info/color-space-faq.html
		///
		/// Planar mode: Y + V + U  (3 planes)
		/// </summary>
		public const int SDL_YV12_OVERLAY = 0x32315659;	

		/// <summary>
		/// Planar mode: Y + U + V  (3 planes)
		/// </summary>
		public const int SDL_IYUV_OVERLAY = 0x56555949;

		/// <summary>
		/// Packed mode: Y0+U0+Y1+V0 (1 plane)
		/// </summary>
		public const int SDL_YUY2_OVERLAY = 0x32595559;
	
		/// <summary>
		/// Packed mode: U0+Y0+V0+Y1 (1 plane)
		/// </summary>
		public const int SDL_UYVY_OVERLAY = 0x59565955;	

		/// <summary>
		/// Packed mode: Y0+V0+Y1+U0 (1 plane)
		/// </summary>
		public const int SDL_YVYU_OVERLAY = 0x55595659;

		/// <summary>
		/// Indicates which position a joystick hat is pressed in
		/// </summary>
		public const Byte SDL_HAT_CENTERED = 0x00;

		/// <summary>
		/// 
		/// </summary>
		public const Byte SDL_HAT_UP = 0x01;

		/// <summary>
		/// 
		/// </summary>
		public const Byte SDL_HAT_RIGHT = 0x02;

		/// <summary>
		/// 
		/// </summary>
		public const Byte SDL_HAT_DOWN = 0x04;

		/// <summary>
		/// 
		/// </summary>
		public const Byte SDL_HAT_LEFT = 0x08;
		/// <summary>
		/// 
		/// </summary>
		public const Byte SDL_HAT_RIGHTUP = (SDL_HAT_RIGHT|SDL_HAT_UP);
		/// <summary>
		/// 
		/// </summary>
		public const Byte SDL_HAT_RIGHTDOWN = (SDL_HAT_RIGHT|SDL_HAT_DOWN);
		/// <summary>
		/// 
		/// </summary>
		public const Byte SDL_HAT_LEFTUP = (SDL_HAT_LEFT|SDL_HAT_UP);
		/// <summary>
		/// 
		/// </summary>
		public const Byte SDL_HAT_LEFTDOWN = (SDL_HAT_LEFT|SDL_HAT_DOWN);

		/// <summary>
		/// Used as a mask when testing buttons in buttonstate
		/// Button 1:	Left mouse button
		/// </summary>
		public const int SDL_BUTTON_LEFT = 1;
		/// <summary>
		/// Button 2:	Middle mouse button
		/// </summary>
		public const int SDL_BUTTON_MIDDLE = 2;
		/// <summary>
		/// Button 3:	Right mouse button
		/// </summary>
		public const int SDL_BUTTON_RIGHT = 3;
		/// <summary>
		/// Button 4:	Mouse wheel up	 (may also be a real button)
		/// </summary>
		public const int SDL_BUTTON_WHEELUP = 4;
		/// <summary>
		/// Button 5:	Mouse wheel down (may also be a real button)
		/// </summary>
		public const int SDL_BUTTON_WHEELDOWN = 5;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_BUTTON_LMASK = SDL_PRESSED << ((int)SDL_BUTTON_LEFT - 1);
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_BUTTON_MMASK = SDL_PRESSED << ((int)SDL_BUTTON_MIDDLE - 1);
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_BUTTON_RMASK = SDL_PRESSED << ((int)SDL_BUTTON_RIGHT - 1);
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_ACTIVEEVENTMASK		= 1 << SDL_ACTIVEEVENT;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_KEYDOWNMASK			= 1 << SDL_KEYDOWN;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_KEYUPMASK				= 1 << SDL_KEYUP;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_MOUSEMOTIONMASK		= 1 << SDL_MOUSEMOTION;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_MOUSEBUTTONDOWNMASK	= 1 << SDL_MOUSEBUTTONDOWN;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_MOUSEBUTTONUPMASK		= 1 << SDL_MOUSEBUTTONUP;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_MOUSEEVENTMASK			= (1 << SDL_MOUSEMOTION)| (1 << SDL_MOUSEBUTTONDOWN)| (1 << SDL_MOUSEBUTTONUP);
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_JOYAXISMOTIONMASK		= 1 << SDL_JOYAXISMOTION;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_JOYBALLMOTIONMASK		= 1 << SDL_JOYBALLMOTION;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_JOYHATMOTIONMASK		= 1 << SDL_JOYHATMOTION;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_JOYBUTTONDOWNMASK		= 1 << SDL_JOYBUTTONDOWN;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_JOYBUTTONUPMASK		= 1 << SDL_JOYBUTTONUP;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_JOYEVENTMASK			= (1 << SDL_JOYAXISMOTION) | (1 << SDL_JOYBALLMOTION) | (1 << SDL_JOYHATMOTION) | (1 << SDL_JOYBUTTONDOWN) | (1 << SDL_JOYBUTTONUP);
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_VIDEORESIZEMASK		= 1 << SDL_VIDEORESIZE;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_VIDEOEXPOSEMASK		= 1 << SDL_VIDEOEXPOSE;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_QUITMASK				= 1 << SDL_QUIT;
		// TODO:
		//public const int SDL_SYSWMEVENTMASK			= 1 << SDL_SYSWMEVENT;

		/// <summary>
		///		Button in pressed state.
		/// </summary>
		public const int SDL_PRESSED = 0x01;

		/// <summary>
		///		Button in released state.
		/// </summary>
		public const int SDL_RELEASED = 0x00;

		/// <summary>
		/// 
		/// </summary>
		public const short KMOD_CTRL = 
			(short) (SDLMod.KMOD_LCTRL|SDLMod.KMOD_RCTRL);
		/// <summary>
		/// 
		/// </summary>
		public const short KMOD_SHIFT = 
			(short) (SDLMod.KMOD_LSHIFT|SDLMod.KMOD_RSHIFT);
		/// <summary>
		/// 
		/// </summary>
		public const short KMOD_ALT = 
			(short) (SDLMod.KMOD_LALT|SDLMod.KMOD_RALT);
		/// <summary>
		/// 
		/// </summary>
		public const short KMOD_META = (
			short) (SDLMod.KMOD_LMETA|SDLMod.KMOD_RMETA);
		
		/// <summary>
		/// Enable/Disable keyboard repeat.  Keyboard repeat defaults to off. 
		/// 'delay' is the initial delay in ms between the time 
		/// when a key is pressed,
		/// and keyboard repeat begins.
		/// </summary>
		public const int SDL_DEFAULT_REPEAT_DELAY = 500;
		
		/// <summary>
		/// Enable/Disable keyboard repeat.  Keyboard repeat defaults to off. 
		/// 'interval' is the time in ms between keyboard repeat events.
		/// </summary>
		public const int SDL_DEFAULT_REPEAT_INTERVAL = 30;

		/// <summary>
		///
		/// </summary>
		public const int SDL_ALL_HOTKEYS = unchecked((int) 0xFFFFFFFF);

		/// <summary>
		/// This is the mask which refers to all hotkey bindings.
		/// </summary>
		public const int SDL_ALLEVENTS = unchecked((int) 0xFFFFFFFF);


		/// <summary>
		/// Transparency definition of Opaque
		/// </summary>
		/// <remarks>
		/// Define alpha as the opacity of a surface
		/// </remarks>
		public const int SDL_ALPHA_OPAQUE = 255;

		/// <summary>
		/// Transparency definition of Transparent
		/// </summary>
		/// <remarks>
		/// Define alpha as the opacity of a surface
		/// </remarks>
		public const int SDL_ALPHA_TRANSPARENT = 0;

		/// <summary>
		/// flags for SDL_SetPalette()
		/// </summary>
		public const Byte SDL_LOGPAL = 0x01;

		/// <summary>
		/// flags for SDL_SetPalette()
		/// </summary>
		public const Byte SDL_PHYSPAL = 0x02;

		/// <summary>
		/// 
		/// </summary>
		public const int SDL_QUERY = -1;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_IGNORE = 0;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_DISABLE = 0;
		/// <summary>
		/// 
		/// </summary>
		public const int SDL_ENABLE = 1;

		/// <summary>
		/// 
		/// </summary>
		public const int SDL_LIL_ENDIAN = 1234;

		/// <summary>
		/// 
		/// </summary>
		public const int SDL_BIG_ENDIAN = 4321;

		/// <summary>
		/// Full audio volume
		/// </summary>
		public const int SDL_MIX_MAXVOLUME = 128;
		
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
		// /// <summary>
		// /// System specific event
		// /// </summary>
		// public const int SDL_SYSWMEVENT = 13;			
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

		// /// <summary>
		// /// Events SDL_USEREVENT through SDL_MAXEVENTS-1 are 
		// /// for your use.
		// /// </summary>
		// public const int SDL_USEREVENT = 24;

		/// <summary>
		/// This last event is only for bounding internal arrays
		/// It is the number of bits in the event mask datatype -- Uint32
		/// </summary>
		public const int SDL_NUMEVENTS = 32;
		
		#endregion Public Constants

		#region Public Enums
		/// <summary>
		/// The possible states which a CD-ROM drive can be in.
		/// </summary>
		public enum CDStatus {
			/// <summary>
			/// The CD tray is empty.
			/// </summary>
			CD_TRAYEMPTY,
			/// <summary>
			/// The CD has stopped playing.
			/// </summary>
			CD_STOPPED,
			/// <summary>
			/// The CD is playing.
			/// </summary>
			CD_PLAYING,
			/// <summary>
			/// The CD has been paused.
			/// </summary>
			CD_PAUSED,
			/// <summary>
			/// An error occured while getting the status.
			/// </summary>
			CD_ERROR = -1
		}

		/// <summary>
		/// OpenGL Attributes
		/// </summary>
		public enum SDL_GLattr {
			/// <summary>
			/// Size of the framebuffer red component, in bits
			/// </summary>
			SDL_GL_RED_SIZE,
			/// <summary>
			/// Size of the framebuffer green component, in bits
			/// </summary>
			SDL_GL_GREEN_SIZE,
			/// <summary>
			/// Size of the framebuffer blue component, in bits
			/// </summary>
			SDL_GL_BLUE_SIZE,
			/// <summary>
			/// Size of the framebuffer alpha component, in bits
			/// </summary>
			SDL_GL_ALPHA_SIZE,
			/// <summary>
			/// Size of the framebuffer, in bits
			/// </summary>
			SDL_GL_BUFFER_SIZE,
			/// <summary>
			/// 0 or 1, enable or disable double buffering
			/// </summary>
			SDL_GL_DOUBLEBUFFER,
			/// <summary>
			/// Size of the depth buffer, in bits
			/// </summary>
			SDL_GL_DEPTH_SIZE,
			/// <summary>
			/// Size of the stencil buffer, in bits.
			/// </summary>
			SDL_GL_STENCIL_SIZE,
			/// <summary>
			/// Size of the accumulation buffer red component, in bits.
			/// </summary>
			SDL_GL_ACCUM_RED_SIZE,
			/// <summary>
			/// Size of the accumulation buffer green component, in bits.
			/// </summary>
			SDL_GL_ACCUM_GREEN_SIZE,
			/// <summary>
			/// Size of the accumulation buffer blue component, in bits.
			/// </summary>
			SDL_GL_ACCUM_BLUE_SIZE,
			/// <summary>
			/// Size of the accumulation buffer alpha component, in bits.
			/// </summary>
			SDL_GL_ACCUM_ALPHA_SIZE,
			/// <summary>
			/// 
			/// </summary>
			SDL_GL_STEREO,
			/// <summary>
			/// 
			/// </summary>
			SDL_GL_MULTISAMPLEBUFFERS,
			/// <summary>
			/// 
			/// </summary>
			SDL_GL_MULTISAMPLESAMPLES
		}

		/// <summary>
		/// Enumeration of valid key mods (possibly OR'd together) 
		/// </summary>
		public enum SDLMod {
			
			/// <summary>
			/// 
			/// </summary>
			KMOD_NONE  = 0x0000,
			/// <summary>
			/// 
			/// </summary>
			KMOD_LSHIFT= 0x0001,
			/// <summary>
			/// 
			/// </summary>
			KMOD_RSHIFT= 0x0002,
			/// <summary>
			/// 
			/// </summary>
			KMOD_LCTRL = 0x0040,
			/// <summary>
			/// 
			/// </summary>
			KMOD_RCTRL = 0x0080,
			/// <summary>
			/// 
			/// </summary>
			KMOD_LALT  = 0x0100,
			/// <summary>
			/// 
			/// </summary>
			KMOD_RALT  = 0x0200,
			/// <summary>
			/// 
			/// </summary>
			KMOD_LMETA = 0x0400,
			/// <summary>
			/// 
			/// </summary>
			KMOD_RMETA = 0x0800,
			/// <summary>
			/// 
			/// </summary>
			KMOD_NUM   = 0x1000,
			/// <summary>
			/// 
			/// </summary>
			KMOD_CAPS  = 0x2000,
			/// <summary>
			/// 
			/// </summary>
			KMOD_MODE  = 0x4000,
			/// <summary>
			/// 
			/// </summary>
			KMOD_RESERVED = 0x8000
		}
	
		/// <summary>
		/// What we really want is a mapping of every raw key on the keyboard.
		/// To support international keyboards, we use the range 0xA1 - 0xFF
		/// as international virtual keycodes.  
		/// We'll follow in the footsteps of X11...
		/// The keyboard syms have been cleverly chosen to map to ASCII
		/// </summary>
		public enum SDLKey {
			
			/// <summary>
			/// 
			/// </summary>
			SDLK_UNKNOWN		= 0,
			/// <summary>
			/// 
			/// </summary>
			SDLK_FIRST		= 0,
			/// <summary>
			/// 
			/// </summary>
			SDLK_BACKSPACE		= 8,
			/// <summary>
			/// 
			/// </summary>
			SDLK_TAB		= 9,
			/// <summary>
			/// 
			/// </summary>
			SDLK_CLEAR		= 12,
			/// <summary>
			/// 
			/// </summary>
			SDLK_RETURN		= 13,
			/// <summary>
			/// 
			/// </summary>
			SDLK_PAUSE		= 19,
			/// <summary>
			/// 
			/// </summary>
			SDLK_ESCAPE		= 27,
			/// <summary>
			/// 
			/// </summary>
			SDLK_SPACE		= 32,
			/// <summary>
			/// 
			/// </summary>
			SDLK_EXCLAIM		= 33,
			/// <summary>
			/// 
			/// </summary>
			SDLK_QUOTEDBL		= 34,
			/// <summary>
			/// 
			/// </summary>
			SDLK_HASH		= 35,
			/// <summary>
			/// 
			/// </summary>
			SDLK_DOLLAR		= 36,
			/// <summary>
			/// 
			/// </summary>
			SDLK_AMPERSAND		= 38,
			/// <summary>
			/// 
			/// </summary>
			SDLK_QUOTE		= 39,
			/// <summary>
			/// 
			/// </summary>
			SDLK_LEFTPAREN		= 40,
			/// <summary>
			/// 
			/// </summary>
			SDLK_RIGHTPAREN		= 41,
			/// <summary>
			/// 
			/// </summary>
			SDLK_ASTERISK		= 42,
			/// <summary>
			/// 
			/// </summary>
			SDLK_PLUS		= 43,
			/// <summary>
			/// 
			/// </summary>
			SDLK_COMMA		= 44,
			/// <summary>
			/// 
			/// </summary>
			SDLK_MINUS		= 45,
			/// <summary>
			/// 
			/// </summary>
			SDLK_PERIOD		= 46,
			/// <summary>
			/// 
			/// </summary>
			SDLK_SLASH		= 47,
			/// <summary>
			/// 
			/// </summary>
			SDLK_0			= 48,
			/// <summary>
			/// 
			/// </summary>
			SDLK_1			= 49,
			/// <summary>
			/// 
			/// </summary>
			SDLK_2			= 50,
			/// <summary>
			/// 
			/// </summary>
			SDLK_3			= 51,
			/// <summary>
			/// 
			/// </summary>
			SDLK_4			= 52,
			/// <summary>
			/// 
			/// </summary>
			SDLK_5			= 53,
			/// <summary>
			/// 
			/// </summary>
			SDLK_6			= 54,
			/// <summary>
			/// 
			/// </summary>
			SDLK_7			= 55,
			/// <summary>
			/// 
			/// </summary>
			SDLK_8			= 56,
			/// <summary>
			/// 
			/// </summary>
			SDLK_9			= 57,
			/// <summary>
			/// 
			/// </summary>
			SDLK_COLON		= 58,
			/// <summary>
			/// 
			/// </summary>
			SDLK_SEMICOLON		= 59,
			/// <summary>
			/// 
			/// </summary>
			SDLK_LESS		= 60,
			/// <summary>
			/// 
			/// </summary>
			SDLK_EQUALS		= 61,
			/// <summary>
			/// 
			/// </summary>
			SDLK_GREATER		= 62,
			/// <summary>
			/// 
			/// </summary>
			SDLK_QUESTION		= 63,
			/// <summary>
			/// 
			/// </summary>
			SDLK_AT			= 64,
			/* 
			   Skip uppercase letters
			 */
			/// <summary>
			/// 
			/// </summary>
			SDLK_LEFTBRACKET	= 91,
			/// <summary>
			/// 
			/// </summary>
			SDLK_BACKSLASH		= 92,
			/// <summary>
			/// 
			/// </summary>
			SDLK_RIGHTBRACKET	= 93,
			/// <summary>
			/// 
			/// </summary>
			SDLK_CARET		= 94,
			/// <summary>
			/// 
			/// </summary>
			SDLK_UNDERSCORE		= 95,
			/// <summary>
			/// 
			/// </summary>
			SDLK_BACKQUOTE		= 96,
			/// <summary>
			/// 
			/// </summary>
			SDLK_a			= 97,
			/// <summary>
			/// 
			/// </summary>
			SDLK_b			= 98,
			/// <summary>
			/// 
			/// </summary>
			SDLK_c			= 99,
			/// <summary>
			/// 
			/// </summary>
			SDLK_d			= 100,
			/// <summary>
			/// 
			/// </summary>
			SDLK_e			= 101,
			/// <summary>
			/// 
			/// </summary>
			SDLK_f			= 102,
			/// <summary>
			/// 
			/// </summary>
			SDLK_g			= 103,
			/// <summary>
			/// 
			/// </summary>
			SDLK_h			= 104,
			/// <summary>
			/// 
			/// </summary>
			SDLK_i			= 105,
			/// <summary>
			/// 
			/// </summary>
			SDLK_j			= 106,
			/// <summary>
			/// 
			/// </summary>
			SDLK_k			= 107,
			/// <summary>
			/// 
			/// </summary>
			SDLK_l			= 108,
			/// <summary>
			/// 
			/// </summary>
			SDLK_m			= 109,
			/// <summary>
			/// 
			/// </summary>
			SDLK_n			= 110,
			/// <summary>
			/// 
			/// </summary>
			SDLK_o			= 111,
			/// <summary>
			/// 
			/// </summary>
			SDLK_p			= 112,
			/// <summary>
			/// 
			/// </summary>
			SDLK_q			= 113,
			/// <summary>
			/// 
			/// </summary>
			SDLK_r			= 114,
			/// <summary>
			/// 
			/// </summary>
			SDLK_s			= 115,
			/// <summary>
			/// 
			/// </summary>
			SDLK_t			= 116,
			/// <summary>
			/// 
			/// </summary>
			SDLK_u			= 117,
			/// <summary>
			/// 
			/// </summary>
			SDLK_v			= 118,
			/// <summary>
			/// 
			/// </summary>
			SDLK_w			= 119,
			/// <summary>
			/// 
			/// </summary>
			SDLK_x			= 120,
			/// <summary>
			/// 
			/// </summary>
			SDLK_y			= 121,
			/// <summary>
			/// 
			/// </summary>
			SDLK_z			= 122,
			/// <summary>
			/// 
			/// </summary>
			SDLK_DELETE		= 127,
			/* End of ASCII mapped keysyms */

			/* International keyboard syms */
			/// <summary>
			/// 0xA0
			/// </summary>
			SDLK_WORLD_0		= 160,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_1		= 161,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_2		= 162,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_3		= 163,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_4		= 164,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_5		= 165,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_6		= 166,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_7		= 167,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_8		= 168,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_9		= 169,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_10		= 170,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_11		= 171,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_12		= 172,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_13		= 173,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_14		= 174,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_15		= 175,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_16		= 176,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_17		= 177,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_18		= 178,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_19		= 179,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_20		= 180,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_21		= 181,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_22		= 182,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_23		= 183,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_24		= 184,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_25		= 185,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_26		= 186,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_27		= 187,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_28		= 188,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_29		= 189,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_30		= 190,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_31		= 191,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_32		= 192,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_33		= 193,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_34		= 194,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_35		= 195,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_36		= 196,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_37		= 197,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_38		= 198,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_39		= 199,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_40		= 200,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_41		= 201,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_42		= 202,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_43		= 203,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_44		= 204,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_45		= 205,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_46		= 206,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_47		= 207,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_48		= 208,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_49		= 209,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_50		= 210,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_51		= 211,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_52		= 212,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_53		= 213,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_54		= 214,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_55		= 215,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_56		= 216,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_57		= 217,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_58		= 218,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_59		= 219,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_60		= 220,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_61		= 221,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_62		= 222,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_63		= 223,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_64		= 224,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_65		= 225,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_66		= 226,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_67		= 227,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_68		= 228,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_69		= 229,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_70		= 230,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_71		= 231,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_72		= 232,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_73		= 233,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_74		= 234,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_75		= 235,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_76		= 236,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_77		= 237,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_78		= 238,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_79		= 239,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_80		= 240,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_81		= 241,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_82		= 242,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_83		= 243,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_84		= 244,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_85		= 245,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_86		= 246,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_87		= 247,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_88		= 248,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_89		= 249,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_90		= 250,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_91		= 251,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_92		= 252,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_93		= 253,
			/// <summary>
			/// 
			/// </summary>
			SDLK_WORLD_94		= 254,
			/// <summary>
			/// 0xFF
			/// </summary>
			SDLK_WORLD_95		= 255,

			/* Numeric keypad */
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP0		= 256,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP1		= 257,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP2		= 258,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP3		= 259,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP4		= 260,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP5		= 261,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP6		= 262,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP7		= 263,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP8		= 264,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP9		= 265,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP_PERIOD		= 266,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP_DIVIDE		= 267,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP_MULTIPLY	= 268,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP_MINUS		= 269,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP_PLUS		= 270,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP_ENTER		= 271,
			/// <summary>
			/// 
			/// </summary>
			SDLK_KP_EQUALS		= 272,

			/* Arrows + Home/End pad */
			/// <summary>
			/// 
			/// </summary>
			SDLK_UP			= 273,
			/// <summary>
			/// 
			/// </summary>
			SDLK_DOWN		= 274,
			/// <summary>
			/// 
			/// </summary>
			SDLK_RIGHT		= 275,
			/// <summary>
			/// 
			/// </summary>
			SDLK_LEFT		= 276,
			/// <summary>
			/// 
			/// </summary>
			SDLK_INSERT		= 277,
			/// <summary>
			/// 
			/// </summary>
			SDLK_HOME		= 278,
			/// <summary>
			/// 
			/// </summary>
			SDLK_END		= 279,
			/// <summary>
			/// 
			/// </summary>
			SDLK_PAGEUP		= 280,
			/// <summary>
			/// 
			/// </summary>
			SDLK_PAGEDOWN	= 281,

			/* Function keys */
			/// <summary>
			/// 
			/// </summary>
			SDLK_F1			= 282,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F2			= 283,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F3			= 284,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F4			= 285,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F5			= 286,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F6			= 287,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F7			= 288,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F8			= 289,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F9			= 290,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F10		= 291,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F11		= 292,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F12		= 293,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F13		= 294,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F14		= 295,
			/// <summary>
			/// 
			/// </summary>
			SDLK_F15		= 296,

			/* Key state modifier keys */
			/// <summary>
			/// 
			/// </summary>
			SDLK_NUMLOCK		= 300,
			/// <summary>
			/// 
			/// </summary>
			SDLK_CAPSLOCK		= 301,
			/// <summary>
			/// 
			/// </summary>
			SDLK_SCROLLOCK		= 302,
			/// <summary>
			/// 
			/// </summary>
			SDLK_RSHIFT		= 303,
			/// <summary>
			/// 
			/// </summary>
			SDLK_LSHIFT		= 304,
			/// <summary>
			/// 
			/// </summary>
			SDLK_RCTRL		= 305,
			/// <summary>
			/// 
			/// </summary>
			SDLK_LCTRL		= 306,
			/// <summary>
			/// 
			/// </summary>
			SDLK_RALT		= 307,
			/// <summary>
			/// 
			/// </summary>
			SDLK_LALT		= 308,
			/// <summary>
			/// 
			/// </summary>
			SDLK_RMETA		= 309,
			/// <summary>
			/// 
			/// </summary>
			SDLK_LMETA		= 310,
			/// <summary>
			/// Left "Windows" key
			/// </summary>
			SDLK_LSUPER		= 311,
			/// <summary>
			/// Right "Windows" key
			/// </summary>
			SDLK_RSUPER		= 312,
			/// <summary>
			/// "Alt Gr" key
			/// </summary>
			SDLK_MODE		= 313,
			/// <summary>
			/// Multi-key compose key
			/// </summary>
			SDLK_COMPOSE		= 314,

			// Miscellaneous function keys
			/// <summary>
			/// 
			/// </summary>
			SDLK_HELP		= 315,
			/// <summary>
			/// 
			/// </summary>
			SDLK_PRINT		= 316,
			/// <summary>
			/// 
			/// </summary>
			SDLK_SYSREQ		= 317,
			/// <summary>
			/// 
			/// </summary>
			SDLK_BREAK		= 318,
			/// <summary>
			/// 
			/// </summary>
			SDLK_MENU		= 319,
			/// <summary>
			/// Power Macintosh power key
			/// </summary>
			SDLK_POWER		= 320,		
			/// <summary>
			/// Some european keyboards
			/// </summary>
			SDLK_EURO		= 321,		
			/// <summary>
			/// Atari keyboard has Undo
			/// </summary>
			SDLK_UNDO		= 322,

			// Add any other keys here
			/// <summary>
			/// 
			/// </summary>
			SDLK_LAST

		}
		/// <summary>
		/// General keyboard/mouse state definitions
		/// </summary>
		public enum KeyState {
			/// <summary>
			/// 
			/// </summary>
			SDL_PRESSED = 0x01, 
			/// <summary>
			/// 
			/// </summary>
			SDL_RELEASED = 0x00
		}

		/// <summary>
		/// This function allows you to set and query the input grab state of
		/// the application.  It returns the new input grab state.
		/// </summary>
		public enum SDL_GrabMode {
			/// <summary>
			/// 
			/// </summary>
			SDL_GRAB_QUERY = -1,
			/// <summary>
			/// 
			/// </summary>
			SDL_GRAB_OFF = 0,
			/// <summary>
			/// 
			/// </summary>
			SDL_GRAB_ON = 1
		}

		/// <summary>
		/// Get the current audio state
		/// </summary>
		public enum SDL_audiostatus {
			/// <summary>
			/// 
			/// </summary>
			SDL_AUDIO_STOPPED = 0,
			/// <summary>
			/// 
			/// </summary>
			SDL_AUDIO_PLAYING,
			/// <summary>
			/// 
			/// </summary>
			SDL_AUDIO_PAUSED
		}

		/// <summary>
		/// Various event types.
		/// </summary>
		public enum SDL_eventaction {
			/// <summary>
			/// 
			/// </summary>
			SDL_ADDEVENT,
			/// <summary>
			/// 
			/// </summary>
			SDL_PEEKEVENT,
			/// <summary>
			/// 
			/// </summary>
			SDL_GETEVENT
		}

		#endregion Public Enums

		#region Public Structs
		// structs
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_Color {
			/// <summary>
			/// Red Channel
			/// </summary>
			public Byte r;
			/// <summary>
			/// Green Channel
			/// </summary>
			public Byte g;
			/// <summary>
			/// Blue Channel
			/// </summary>
			public Byte b;
			/// <summary>
			/// Alpha Channel
			/// Currently unused
			/// </summary>
			public Byte unused;
		}
		
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_Rect {
			/// <summary>
			/// 
			/// </summary>
			public short x;
			/// <summary>
			/// 
			/// </summary>
			public short y;
			/// <summary>
			/// 
			/// </summary>
			public short w;
			/// <summary>
			/// 
			/// </summary>
			public short h;
		}
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_Palette {
			/// <summary>
			/// 
			/// </summary>
			public int ncolors;
			/// <summary>
			/// 
			/// </summary>
			public SDL_Color colors;
		}
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_PixelFormat {
			/// <summary>
			/// 
			/// </summary>
			public IntPtr palette;
			/// <summary>
			/// 
			/// </summary>
			public Byte BitsPerPixel;
			/// <summary>
			/// 
			/// </summary>
			public Byte BytesPerPixel;
			/// <summary>
			/// 
			/// </summary>
			public Byte Rloss;
			/// <summary>
			/// 
			/// </summary>
			public Byte Gloss;
			/// <summary>
			/// 
			/// </summary>
			public Byte Bloss;
			/// <summary>
			/// 
			/// </summary>
			public Byte Aloss;
			/// <summary>
			/// 
			/// </summary>
			public Byte Rshift;
			/// <summary>
			/// 
			/// </summary>
			public Byte Gshift;
			/// <summary>
			/// 
			/// </summary>
			public Byte Bshift;
			/// <summary>
			/// 
			/// </summary>
			public Byte Ashift;
			/// <summary>
			/// 
			/// </summary>
			public int Rmask;
			/// <summary>
			/// 
			/// </summary>
			public int Gmask;
			/// <summary>
			/// 
			/// </summary>
			public int Bmask;
			/// <summary>
			/// 
			/// </summary>
			public int Amask;
			/// <summary>
			/// 
			/// </summary>
			public int colorkey;
			/// <summary>
			/// 
			/// </summary>
			public Byte alpha;
		}
		/// <summary>
		/// This structure should be treated as read-only, except for 'pixels',
		/// which, if not NULL, contains the raw pixel data for the surface.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_Surface {
			/// <summary>
			/// 
			/// </summary>
			public int flags;
			/// <summary>
			/// 
			/// </summary>
			public SDL_PixelFormat format;
			/// <summary>
			/// 
			/// </summary>
			public int w;
			/// <summary>
			/// 
			/// </summary>
			public int h;
			/// <summary>
			/// 
			/// </summary>
			public short pitch;
			/// <summary>
			/// 
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
			/// clipping information
			/// </summary>
			public SDL_Rect clip_rect;
			/// <summary>
			/// 
			/// </summary>
			public int unused1;
			/// <summary>
			/// 
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
			/// 
			/// </summary>
			public int refcount;
		}
		/// <summary>
		/// - The scancode is hardware dependent, 
		/// and should not be used by general
		/// applications.  If no hardware scancode is available, it will be 0.
		/// </summary>
		/// <remarks>
		/// - The 'unicode' translated character is only available 
		/// when character
		/// translation is enabled by the SDL_EnableUNICODE() API.  
		/// If non-zero,
		/// this is a UNICODE character corresponding to the keypress.  
		/// If the
		/// high 9 bits of the character are 0, 
		/// then this maps to the equivalent
		/// ASCII character:
		/// 	char ch;
		///	if ( (keysym.unicode and 0xFF80) == 0 ) {
		///		ch = keysym.unicode and 0x7F;
		///	} else {
		///		An international character..
		///	}
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_keysym {
			/// <summary>
			/// Hardware specific scancode.
			/// </summary>
			public Byte scancode;
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
			public short unicode;
		}
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
			public struct SDL_Event {
			//The Tao version is much different from the old SDL.NET version
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public Byte type;
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public SDL_ActiveEvent active;
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public SDL_KeyboardEvent key;
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public SDL_MouseMotionEvent motion;
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public SDL_MouseButtonEvent button;
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public SDL_JoyAxisEvent jaxis;
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public SDL_JoyBallEvent jball;
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public SDL_JoyHatEvent jhat;
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public SDL_JoyButtonEvent jbutton;
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public SDL_ResizeEvent resize;
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public SDL_ExposeEvent expose;
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public SDL_QuitEvent quit;
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public SDL_UserEvent user;
			/// <summary>
			/// 
			/// </summary>
			[FieldOffset(0)]
			public SDL_SysWMEvent syswm;
		}
		
		/// <summary>
		/// Application visibility event structure.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_ActiveEvent {
			/// <summary>
			/// SDL_ACTIVEEVENT
			/// </summary>
			public Byte type;
			/// <summary>
			/// Whether given states were gained or lost (1/0)
			/// </summary>
			public Byte gain;
			/// <summary>
			/// A mask of the focus states
			/// </summary>
			public Byte state;
		}
		
		/// <summary>
		/// Keyboard event structure
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_KeyboardEvent {
			/// <summary>
			/// SDL_KEYDOWN or SDL_KEYUP
			/// </summary>
			public Byte type;
			/// <summary>
			/// The keyboard device index
			/// </summary>
			public Byte which;
			/// <summary>
			/// SDL_PRESSED or SDL_RELEASED
			/// </summary>
			public Byte state;
			/// <summary>
			/// 
			/// </summary>
			public SDL_keysym keysym;
		}
		
		/// <summary>
		/// Mouse motion event structure
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_MouseMotionEvent {
			/// <summary>
			/// SDL_MOUSEMOTION
			/// </summary>
			public Byte type;
			/// <summary>
			/// The mouse device index
			/// </summary>
			public Byte which;
			/// <summary>
			/// The current button state
			/// </summary>
			public Byte state;
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
		
		/// <summary>
		/// Mouse button event structure
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_MouseButtonEvent {
			/// <summary>
			/// SDL_MOUSEBUTTONDOWN or SDL_MOUSEBUTTONUP
			/// </summary>
			public Byte type;
			/// <summary>
			/// The mouse device index 
			/// </summary>
			public Byte which;
			/// <summary>
			/// The mouse button index
			/// </summary>
			public Byte button;
			/// <summary>
			/// SDL_PRESSED or SDL_RELEASED 
			/// </summary>
			public Byte state;
			/// <summary>
			/// The X coordinate of the mouse at press time
			/// </summary>
			public short x;
			/// <summary>
			/// The Y coordinate of the mouse at press time
			/// </summary>
			public short y;
		}
		
		/// <summary>
		/// Joystick axis motion event structure
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_JoyAxisEvent {
			/// <summary>
			/// SDL_JOYBALLMOTION
			/// </summary>
			public Byte type;
			/// <summary>
			/// The joystick device index
			/// </summary>
			public Byte which;
			/// <summary>
			/// The joystick trackball index
			/// </summary>
			public Byte axis;
			/// <summary>
			/// The axis value (range: -32768 to 32767)
			/// </summary>
			public short value;
		}
		
		/// <summary>
		/// Joystick trackball motion event structure
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_JoyBallEvent {
			/// <summary>
			/// SDL_JOYBALLMOTION
			/// </summary>
			public Byte type;
			/// <summary>
			/// The joystick device index
			/// </summary>
			public Byte which;
			/// <summary>
			/// The joystick trackball index
			/// </summary>
			public Byte ball;
			/// <summary>
			/// The relative motion in the X direction
			/// </summary>
			public short xrel;
			/// <summary>
			/// The relative motion in the Y direction
			/// </summary>
			public short yrel;
		}
		
		/// <summary>
		/// Joystick hat position change event structure
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_JoyHatEvent {
			/// <summary>
			/// SDL_JOYHATMOTION
			/// </summary>
			public Byte type;
			/// <summary>
			/// The joystick device index
			/// </summary>
			public Byte which;
			/// <summary>
			/// The joystick hat index
			/// </summary>
			public Byte hat;
			/// <summary>
			/// The hat position value:
			///  SDL_HAT_LEFTUP   SDL_HAT_UP       SDL_HAT_RIGHTUP
			///  SDL_HAT_LEFT     SDL_HAT_CENTERED SDL_HAT_RIGHT
			///  SDL_HAT_LEFTDOWN SDL_HAT_DOWN     SDL_HAT_RIGHTDOWN
			/// Note that zero means the POV is centered.
			/// </summary>
			public Byte value;
		}
		
		/// <summary>
		/// Joystick button event structure
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_JoyButtonEvent {
			/// <summary>
			/// SDL_JOYBUTTONDOWN or SDL_JOYBUTTONUP
			/// </summary>
			public Byte type;
			/// <summary>
			/// The joystick device index 
			/// </summary>
			public Byte which;
			/// <summary>
			/// The joystick button index
			/// </summary>
			public Byte button;
			/// <summary>
			/// SDL_PRESSED or SDL_RELEASED
			/// </summary>
			public Byte state;
		}
		
		/// <summary>
		/// The "window resized" event
		/// When you get this event, you are responsible for 
		/// setting a new video
		/// mode with the new width and height.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_ResizeEvent {
			/// <summary>
			/// SDL_VIDEORESIZE
			/// </summary>
			public Byte type;
			/// <summary>
			/// New width
			/// </summary>
			public int w;
			/// <summary>
			/// New height
			/// </summary>
			public int h;
		}
		
		/// <summary>
		/// The "screen redraw" event
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_ExposeEvent {
			/// <summary>
			/// SDL_VIDEOEXPOSE
			/// </summary>
			public Byte type;
		}
		
		/// <summary>
		/// The "quit requested" event
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_QuitEvent {
			/// <summary>
			/// SDL_QUIT
			/// </summary>
			public Byte type;
		}
		
		/// <summary>
		/// A user-defined event type
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_UserEvent {
			/// <summary>
			/// SDL_USEREVENT through SDL_NUMEVENTS-1
			/// </summary>
			public Byte type;
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

		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_SysWMmsg {
			/// <summary>
			/// 
			/// </summary>
			public Byte type;
			/// <summary>
			///
			/// </summary>
			public IntPtr msg;
		}
		
		/// <summary>
		/// CD Track Information Structure
		/// </summary>
		/// <remarks>
		/// SDL_CDtrack stores data on each track on a CD, 
		/// its fields should be pretty self explainatory.
		/// It is a member a the SDL_CD structure.
		/// Note: Frames can be converted to standard timings.
		/// There are CD_FPS frames per second, 
		/// so SDL_CDtrack.length/CD_FPS=length_in_seconds.
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_CDtrack {
			/// <summary>
			/// Track number(0-99)
			/// </summary>
			public Byte id;
			/// <summary>
			/// Data or audio track
			/// </summary>
			/// <remarks>
			/// SDL_AUDIO_TRACK or SDL_DATA_TRACK
			/// </remarks>
			public Byte type;
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

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// This structure is only current as of the last call 
		/// to SDL_CDStatus().
		/// The numtracks, cur_track and cur_frame are only valid 
		/// if there's a CD in drive.
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_CD {
			/// <summary>
			/// Private drive identifier
			/// </summary>
			public int id;
			/// <summary>
			/// Current drive status
			/// </summary>
			public CDStatus status;
			/// <summary>
			/// Number of tracks on disk
			/// </summary>
			public int numtracks;
			/// <summary>
			/// Current track position
			/// </summary>
			public int cur_track;
			/// <summary>
			/// Current frame offset within current track
			/// </summary>
			public int cur_frame;
			/// <summary>
			/// 
			/// </summary>
			public SDL_CDtrack[] track;
			//[MarshalAs(UnmanagedType.ByValArray, SizeConst=1200)]
			//public Byte[] track;
		}
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_SysWMEvent {
			/// <summary>
			/// 
			/// </summary>
			public Byte type;
			/// <summary>
			/// 
			/// </summary>
			public IntPtr msg;
		}
		/// <summary>
		/// Structure to hold version number of the SDL library
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_version {
			/// <summary>
			/// 
			/// </summary>
			public Byte major;
			/// <summary>
			/// 
			/// </summary>
			public Byte minor;
			/// <summary>
			/// 
			/// </summary>
			public Byte patch;

		}

		/// <summary>
		/// Useful for determining the video hardware capabilities
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_VideoInfo {
			/// <summary>
			/// Flag: Can you create hardware surfaces?
			/// </summary>
			public int hw_available;
			/// <summary>
			/// Flag: Can you talk to a window manager?
			/// </summary>
			public int wm_available;
			/// <summary>
			/// 
			/// </summary>
			public int UnusedBits1;
			/// <summary>
			/// 
			/// </summary>
			public int UnusedBits2;
			/// <summary>
			/// Flag: Accelerated blits HW --> HW
			/// </summary>
			public int blit_hw;
			/// <summary>
			/// Accelerated blits with Colorkey
			/// </summary>
			public int blit_hw_CC;
			/// <summary>
			/// Flag: Accelerated blits with Alpha
			/// </summary>
			public int blit_hw_A;
			/// <summary>
			/// Flag: Accelerated blits SW --> HW
			/// </summary>
			public int blit_sw;
			/// <summary>
			/// Flag: Accelerated blits with Colorkey
			/// </summary>
			public int blit_sw_CC;
			/// <summary>
			/// Flag: Accelerated blits with Alpha.
			/// </summary>
			public int blit_sw_A;
			/// <summary>
			/// Flag: Accelerated color fill
			/// </summary>
			public int blit_fill;
			/// <summary>
			/// 
			/// </summary>
			public int UnusedBits3;
			/// <summary>
			/// The total amount of video memory (in K)
			/// </summary>
			public int video_mem;
			/// <summary>
			/// Value: The format of the video surface
			/// </summary>
			public SDL_PixelFormat vfmt;
		}

		/// <summary>
		/// Structure to hold cursor
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct SDL_Cursor {
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
			public IntPtr data;
			/// <summary>
			/// B/W cursor mask
			/// </summary>
			public IntPtr mask;
			/// <summary>
			/// Place to save cursor area
			/// </summary>
			public IntPtr[] save;
			/// <summary>
			/// Window-manager cursor
			/// </summary>
			public IntPtr WMcursor;
		}
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
			public struct WMcursor {
		}	

		/// <summary>
		/// The calculated values in this structure are 
		/// calculated by SDL_OpenAudio()
		/// </summary>
		public struct SDL_AudioSpec {

			/// <summary>
			/// DSP frequency -- samples per second
			/// </summary>
			public int freq;	
			/// <summary>
			/// Audio data format
			/// </summary>
			public short format;		
			/// <summary>
			/// Number of channels: 1 mono, 2 stereo
			/// </summary>
			public Byte  channels;
			/// <summary>
			/// Audio buffer silence value (calculated)
			/// </summary>
			public Byte  silence;	
			/// <summary>
			/// Audio buffer size in samples (power of 2)
			/// </summary>
			public short samples;
			/// <summary>
			/// Necessary for some compile environments
			/// </summary>
			public short padding;		
			/// <summary>
			/// Audio buffer size in bytes (calculated)
			/// </summary>
			public int size;		
			//			/// <summary>
			//			/// This function is called when the audio device needs more data.
			//			/// 'stream' is a pointer to the audio data buffer
			//			/// 'len' is the length of that buffer in bytes.
			//			/// Once the callback returns, the buffer will no longer be valid.
			//			/// Stereo samples are stored in a LRLRLR ordering.
			//			/// </summary>
			//			/// <param name="userdata"></param>
			//			/// <param name="stream"></param>
			//			/// <param name="len"></param>
			//			public void callback(IntPtr userdata, IntPtr stream, int len)
			//			{}
			/// <summary>
			/// 
			/// </summary>
			public IntPtr  userdata;
		}

		/// <summary>
		/// A structure to hold a set of audio conversion filters and buffers
		/// </summary>
		public struct SDL_AudioCVT {
			/// <summary>
			/// Set to 1 if conversion possible
			/// </summary>
			public int needed;			/*  */
			/// <summary>
			/// Source audio format
			/// </summary>
			public short src_format;		/*  */
			/// <summary>
			/// Target audio format
			/// </summary>
			public short dst_format;		
			/// <summary>
			/// Rate conversion increment
			/// </summary>
			public double rate_incr;	
			/// <summary>
			/// Buffer to hold entire audio data
			/// </summary>
			public IntPtr buf;		
			/// <summary>
			/// Length of original audio buffer
			/// </summary>
			public int    len;			
			/// <summary>
			/// Length of converted audio buffer
			/// </summary>
			public int    len_cvt;	
			/// <summary>
			/// buffer must be len*len_mult big
			/// </summary>
			public int    len_mult;	
			/// <summary>
			/// Given len, final size is len*len_ratio
			/// </summary>
			public double len_ratio; 	
			
			//public void (*filters[10])(IntPtr cvt, short format);

			/// <summary>
			/// Current audio conversion function
			/// </summary>
			public int filter_index;
		}
		#endregion Public Structs

		#region Private Static Fields

		/// <summary>
		///		Private byte array holding the internal keyboard state.
		/// </summary>
		/// <remarks>
		///		Used for <see cref="SDL_GetKeyState"/>.
		///		Array is sized to fit all the known Key enums.
		/// </remarks>
		private static byte[] keyboardState = new byte[(int)Sdl.SDLKey.SDLK_LAST];

		#endregion Private Static Fields

		// --- Constructors & Destructors ---
		#region Sdl()
		/// <summary>
		///     Prevents instantiation.
		/// </summary>
		private Sdl() 
		{
		}

		/// <summary>
		/// Static Sdl constructor. All the functionality of 
		/// the SDL library is available through this class 
		/// and its properties.
		/// Explicit static constructor tells the C# compiler
		/// not to mark type as beforefieldinit.
		/// </summary>
		static Sdl() 
		{
		}
		#endregion Sdl()

		// --- Public Delegates ---
		// SDL_timer
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
		/// <seealso cref="SDL_SetTimer" />
		// typedef Uint32 (SDLCALL *SDL_TimerCallback)(Uint32 interval);
		public delegate int SDL_TimerCallback(int interval);
		#endregion int SDL_TimerCallback(int interval)

		// TODO: Goddamn void* double whammy since it's a delegate
		/// <summary>
		///
		/// </summary>
		public delegate int SDL_NewTimerCallback(int interval);

		// --- Public Externs ---
		// SDL
		#region int SDL_Init(int flags)
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
		/// </remarks>
		/// <seealso cref="SDL_InitSubSystem" />
		/// <seealso cref="SDL_Quit" />
		// extern DECLSPEC int SDLCALL SDL_Init(Uint32 flags);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_Init(int flags);
		#endregion int SDL_Init(int flags)

		#region int SDL_InitSubSystem(int flags)
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
		/// </remarks>
		/// <seealso cref="SDL_Init" />
		/// <seealso cref="SDL_Quit" />
		/// <seealso cref="SDL_QuitSubSystem" />
		// extern DECLSPEC int SDLCALL SDL_InitSubSystem(Uint32 flags);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_InitSubSystem(int flags);
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
		/// </remarks>
		/// <seealso cref="SDL_Init" />
		/// <seealso cref="SDL_InitSubSystem" />
		/// <seealso cref="SDL_Quit" />
		// extern DECLSPEC void SDLCALL SDL_QuitSubSystem(Uint32 flags);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
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
		/// </remarks>
		/// <seealso cref="SDL_Init" />
		/// <seealso cref="SDL_InitSubSystem" />
		// extern DECLSPEC Uint32 SDLCALL SDL_WasInit(Uint32 flags);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_WasInit(int flags);
		#endregion int SDL_WasInit(int flags)

		#region SDL_Quit()
		/// <summary>
		///     Shuts down SDL.
		/// </summary>
		/// <remarks>
		///     <b>SDL_Quit</b> shuts down all SDL subsystems and frees the resources allocated
		///     to them.  This should always be called before you exit.
		/// </remarks>
		/// <seealso cref="SDL_Init" />
		/// <seealso cref="SDL_QuitSubSystem" />
		// extern DECLSPEC void SDLCALL SDL_Quit(void);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
		public static extern void SDL_Quit();
		#endregion SDL_Quit()

		// SDL_main -- none

		// SDL_types -- none

		// SDL_getenv
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
		///     Not all environments have a working putenv() 
		/// </remarks>
		/// <seealso cref="SDL_getenv" />
		// extern DECLSPEC int SDLCALL SDL_putenv(const char *variable);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
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
		///     Not all environments have a working getenv() 
		/// </remarks>
		/// <seealso cref="SDL_putenv" />
		// extern DECLSPEC char * SDLCALL SDL_getenv(const char *name);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
		public static extern string SDL_getenv(string name);
		#endregion string SDL_getenv(string name)

		// SDL_error
		#region SDL_SetError(string message)
		/// <summary>
		///     Sets an SDL error string.
		/// </summary>
		/// <param name="message">
		///     The error message to set.
		/// </param>
		// extern DECLSPEC void SDLCALL SDL_SetError(const char *fmt, ...);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
		public static extern void SDL_SetError(string message);
		#endregion SDL_SetError(string message)

		#region string SDL_GetError()
		/// <summary>
		///     Gets an SDL error string.
		/// </summary>
		/// <returns>
		///     A string containing information about the last internal SDL error.
		/// </returns>
		// extern DECLSPEC char * SDLCALL SDL_GetError(void);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
		public static extern string SDL_GetError();
		#endregion string SDL_GetError()

		#region SDL_ClearError()
		/// <summary>
		///     Clears the SDL error.
		/// </summary>
		// extern DECLSPEC void SDLCALL SDL_ClearError(void);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
		public static extern void SDL_ClearError();
		#endregion SDL_ClearError()

		// TODO: SDL_rwops -- skipped for now, might be useful

		// SDL_timer
		#region int SDL_GetTicks()
		/// <summary>
		///     Get the number of milliseconds since the SDL library initialization.
		/// </summary>
		/// <returns>
		///     The number of milliseconds since SDL was initialized.
		/// </returns>
		/// <remarks>
		///     Note that this value wraps if the program runs for more than ~49 days.
		/// </remarks>
		/// <seealso cref="SDL_Delay" />
		// extern DECLSPEC Uint32 SDLCALL SDL_GetTicks(void);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
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
		///     platforms have shorter clock ticks but this is the most common
		/// </remarks>
		/// <seealso cref="SDL_AddTimer" />
		// extern DECLSPEC void SDLCALL SDL_Delay(Uint32 ms);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
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
		/// </remarks>
		/// <seealso cref="SDL_AddTimer" />
		/// <seealso cref="SDL_TimerCallback" />
		// extern DECLSPEC int SDLCALL SDL_SetTimer(Uint32 interval, SDL_TimerCallback callback);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetTimer(int interval, SDL_TimerCallback callback);
		#endregion int SDL_SetTimer(int interval, SDL_TimerCallback callback)
		/// <summary>
		///     
		/// </summary>
		public struct SDL_TimerID {
		}
		// TODO: Goddamn void* double whammy since it's a delegate
		// extern DECLSPEC SDL_TimerID SDLCALL SDL_AddTimer(Uint32 interval, SDL_NewTimerCallback callback, void *param);
		/// <summary>
		///     
		/// </summary>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
		public static extern SDL_TimerID SDL_AddTimer(int interval, SDL_NewTimerCallback callback, IntPtr param);

		/// <summary>
		///     
		/// </summary>
		public struct SDL_bool {
		}
		#region SDL_bool SDL_RemoveTimer(SDL_TimerID t)
		/// <summary>
		///     Remove a timer which was added with <see cref="SDL_AddTimer" />.
		/// </summary>
		/// <param name="t">
		///     The timer ID to remove.
		/// </param>
		/// <returns>
		///     A boolean value indicating success.
		/// </returns>
		/// <seealso cref="SDL_AddTimer" />
		// extern DECLSPEC SDL_bool SDLCALL SDL_RemoveTimer(SDL_TimerID t);
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, ExactSpelling=true), SuppressUnmanagedCodeSecurity]
		public static extern SDL_bool SDL_RemoveTimer(SDL_TimerID t);
		#endregion SDL_bool SDL_RemoveTimer(SDL_TimerID t)

		// extern DECLSPEC SDL_Rect ** SDLCALL SDL_ListModes(SDL_PixelFormat *format, Uint32 flags); 
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, 
			 EntryPoint="SDL_ListModes"), SuppressUnmanagedCodeSecurity] 
		private static extern IntPtr SDL_ListModesInternal( 
			IntPtr format, int flags); 

		/// <summary> 
		/// Return a pointer to an array of available screen dimensions for the 
		/// given format and video flags, sorted largest to smallest.  
		/// Returns 
		/// NULL if there are no dimensions available for a particular format, 
		/// or (SDL_Rect **)-1 if any dimension is okay for the given format. 
		/// </summary> 
		/// <remarks> 
		/// If 'format' is NULL, the mode list will be for the format given 
		/// by SDL_GetVideoInfo()->vfmt 
		/// </remarks> 
		/// <param name="format"></param> 
		/// <param name="flags"></param> 
		/// <returns></returns> 
		public unsafe static SDL_Rect[] SDL_ListModes(IntPtr format, 
			int flags) { 
			IntPtr rectPtr = SDL_ListModesInternal(IntPtr.Zero, flags); 

			Sdl.SDL_Rect** rects = (Sdl.SDL_Rect**)rectPtr.ToPointer(); 

			int i = 0; 

			ArrayList modes = new ArrayList(); 

			while(rects[i] != null) { 
				Sdl.SDL_Rect rect = 
					(Sdl.SDL_Rect)Marshal.PtrToStructure(new IntPtr(rects[i]), typeof(Sdl.SDL_Rect)); 

				modes.Insert(0, rect); 

				i++; 
			} 

			return (Sdl.SDL_Rect[])modes.ToArray(typeof(Sdl.SDL_Rect)); 
		} 

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
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern Byte SDL_GetAppState();

		/// <summary>
		/// This function fills the given character buffer with the name of the
		/// video driver, and returns a pointer to it if the video driver has
		/// been initialized.
		/// </summary>
		/// <remarks>
		/// It returns NULL if no driver has been initialized.
		/// </remarks>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern String SDL_VideoDriverName(String namebuf, 
			int maxlen);
		
		/// <summary>
		/// This function returns a read-only pointer to information 
		/// about the video hardware. 
		/// </summary>
		/// <remarks>
		/// If this is called before SDL_SetVideoMode(), the 'vfmt'
		/// member of the returned structure will contain the pixel 
		/// format of the
		/// "best" video mode.
		/// </remarks>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern SDL_VideoInfo SDL_GetVideoInfo();

		//Keyboard
		/// <summary>
		/// If 'delay' is set to 0, keyboard repeat is disabled. 
		/// </summary>
		/// <remarks>
		///
		/// </remarks>
		/// <param name="rate"></param>
		/// <param name="delay"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_EnableKeyRepeat(int rate, 
			int delay);

		/// <summary>
		/// Get a snapshot of the current state of the keyboard. 
		/// </summary>
		/// <remarks>
		/// Returns an array of keystates, indexed by the SDLK_* syms.
		/// Used:
		///	Uint8 *keystate = SDL_GetKeyState(NULL);
		///	if ( keystate[SDLK_RETURN] ) ...  _RETURN_ is pressed.
		/// </remarks>
		/// <param name="numkeys"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="SDL_GetKeyState"),
		SuppressUnmanagedCodeSecurity]
		private static extern IntPtr SDL_GetKeyStateInternal(out int numkeys);

		/// <summary>
		/// Get a snapshot of the current state of the keyboard. 
		/// </summary>
		/// <remarks>
		/// Returns an array of keystates, indexed by the SDLK_* syms.
		/// Used:
		///	Uint8 *keystate = SDL_GetKeyState(NULL);
		///	if ( keystate[SDLK_RETURN] ) ...  _RETURN_ is pressed.
		/// </remarks>
		/// <param name="numkeys"></param>
		public static byte[] SDL_GetKeyState(out int numkeys) {
			IntPtr state = SDL_GetKeyStateInternal(out numkeys);

			// update the cached keyboard state
			Marshal.Copy(state, keyboardState, 0, numkeys);

			return keyboardState;
		}

		/// <summary>
		/// Get the current key modifier state. 
		/// </summary>
		/// <remarks>
		/// </remarks>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern SDLMod SDL_GetModState();
		
		/// <summary>
		/// Set the current key modifier state. 
		/// </summary>
		/// <remarks>
		/// This does not change the keyboard state, only the key modifier
		///  flags.
		/// </remarks>
		/// <param name="modstate"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_SetModState(SDLMod modstate);

		/// <summary>
		/// Get the name of an SDL virtual keysym
		/// </summary>
		/// <remarks>
		/// </remarks>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern String SDL_GetKeyName(SDLKey key);
		
		/// <summary>
		/// Enable/Disable UNICODE translation of keyboard input.
		/// </summary>
		/// <remarks>
		/// This translation has some overhead, so translation defaults off.
		/// If 'enable' is 1, translation is enabled.
		/// If 'enable' is 0, translation is disabled.
		/// If 'enable' is -1, the translation state is not changed.
		/// It returns the previous state of keyboard translation.
		/// </remarks>
		/// <param name="enable"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_EnableUNICODE(int enable);
		
		// Video
		/// <summary>
		/// Set up a video mode with the specified width, height 
		/// and bits-per-pixel.
		/// If 'bpp' is 0, it is treated as the current display bits per pixel.
		///
		/// If SDL_ANYFORMAT is set in 'flags', the SDL library will try to 
		/// set the
		/// requested bits-per-pixel, but will return whatever video pixel 
		/// format is
		/// available.  The default is to emulate the requested pixel format 
		/// if it
		/// is not natively available.
		///
		/// If SDL_HWSURFACE is set in 'flags', the video surface will be 
		/// placed in
		/// video memory, if possible, and you may have to call 
		/// SDL_LockSurface()
		/// in order to access the raw framebuffer.  Otherwise, the video
		///  surface
		/// will be created in system memory.
		///
		/// If SDL_ASYNCBLIT is set in 'flags', SDL will try to perform 
		/// rectangle
		/// updates asynchronously, but you must always lock before 
		/// accessing pixels.
		/// SDL will wait for updates to complete before returning from the
		///  lock.
		///
		/// If SDL_HWPALETTE is set in 'flags', the SDL library will guarantee
		/// that the colors set by SDL_SetColors() will be the colors you get.
		/// Otherwise, in 8-bit mode, SDL_SetColors() may not be able to set
		///  all
		/// of the colors exactly the way they are requested, and you should
		///  look
		/// at the video surface structure to determine the actual palette.
		/// If SDL cannot guarantee that the colors you request can be set, 
		/// i.e. if the colormap is shared, then the video surface may be
		///  created
		/// under emulation in system memory, overriding the SDL_HWSURFACE
		///  flag.
		///
		/// If SDL_FULLSCREEN is set in 'flags', the SDL library will try to
		///  set
		/// a fullscreen video mode.  The default is to create a windowed mode
		/// if the current graphics system has a window manager.
		/// If the SDL library is able to set a fullscreen video mode, this
		///  flag 
		/// will be set in the surface that is returned.
		///
		/// If SDL_DOUBLEBUF is set in 'flags', the SDL library will try 
		/// to set up
		/// two surfaces in video memory and swap between them when you call 
		/// SDL_Flip().  This is usually slower than the normal 
		/// single-buffering
		/// scheme, but prevents "tearing" artifacts caused by modifying video 
		/// memory while the monitor is refreshing.  It should only be used by 
		/// applications that redraw the entire screen on every update.
		///
		/// If SDL_RESIZABLE is set in 'flags', the SDL library will allow the
		/// window manager, if any, to resize the window at runtime.  When this
		/// occurs, SDL will send a SDL_VIDEORESIZE event to you application,
		/// and you must respond to the event by re-calling SDL_SetVideoMode()
		/// with the requested size (or another size that suits the
		/// application).
		///
		/// If SDL_NOFRAME is set in 'flags', the SDL library will create 
		/// a window
		/// without any title bar or frame decoration.  Fullscreen video 
		/// modes have
		/// this flag set automatically.
		///
		/// This function returns the video framebuffer surface, or NULL 
		/// if it fails.
		/// </summary>
		/// <remarks>
		/// If you rely on functionality provided by certain video flags, 
		/// check the
		/// flags of the returned surface to make sure that functionality 
		/// is available.
		/// SDL will fall back to reduced functionality if the exact flags 
		/// you wanted
		/// are not available.
		/// </remarks>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="bpp"></param>
		/// <param name="flags"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_SetVideoMode(int width, int height,
			int bpp, int flags);

		/// <summary>
		/// Check to see if a particular video mode is supported.
		/// It returns 0 if the requested mode is not supported under any 
		/// bit depth,
		/// or returns the bits-per-pixel of the closest available mode 
		/// with the
		/// given width and height.  If this bits-per-pixel is different 
		/// from the
		/// one used when setting the video mode, SDL_SetVideoMode() will 
		/// succeed,
		/// but will emulate the requested bits-per-pixel with a shadow 
		/// surface.
		/// </summary>
		/// <remarks>
		/// The arguments to SDL_VideoModeOK() are the same ones you would 
		/// pass to
		/// SDL_SetVideoMode()
		/// </remarks>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="bpp"></param>
		/// <param name="flags"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_VideoModeOK(int width, 
			int height, int bpp, int flags);
		
		/// <summary>
		/// Makes sure the given list of rectangles is updated on the given 
		/// screen.
		/// If 'x', 'y', 'w' and 'h' are all 0, SDL_UpdateRect will update 
		/// the entire
		/// screen.
		/// </summary>
		/// <remarks>
		/// These functions should not be called while 'screen' is locked.
		/// </remarks>
		/// <param name="screen"></param>
		/// <param name="numrects"></param>
		/// <param name="rects"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_UpdateRects(IntPtr screen, 
			int numrects, IntPtr rects);

		/// <summary>
		/// Makes sure the given list of rectangles is updated on the given
		///  screen.
		/// If 'x', 'y', 'w' and 'h' are all 0, SDL_UpdateRect will update the
		///  entire
		/// screen.
		/// </summary>
		/// <remarks>
		/// These functions should not be called while 'screen' is locked.
		/// </remarks>
		/// <param name="screen"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_UpdateRect(IntPtr screen, int x, 
			int y, int w, int h);
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="surface"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_FreeSurface(IntPtr surface);

		/// <summary>
		/// On hardware that supports double-buffering, this function sets up 
		/// a flip
		/// and returns.  The hardware will wait for vertical retrace, and 
		/// then swap
		/// video buffers before the next video surface blit or lock will
		///  return.
		/// On hardware that doesn not support double-buffering, this is 
		/// equivalent
		/// to calling SDL_UpdateRect(screen, 0, 0, 0, 0);
		/// The SDL_DOUBLEBUF flag must have been passed to SDL_SetVideoMode()
		///  when
		/// setting the video mode for this function to perform hardware 
		/// flipping.
		/// This function returns 0 if successful, or -1 if there was an 
		/// error.
		/// </summary>
		/// <param name="screen"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_Flip(IntPtr screen);
		
		/// <summary>
		/// Set the gamma correction for each of the color channels.
		/// The gamma values range (approximately) between 0.1 and 10.0 
		/// </summary>
		/// <remarks>
		/// If this function isn't supported directly by the hardware, it will
		/// be emulated using gamma ramps, if available.  If successful, this
		/// function returns 0, otherwise it returns -1.
		/// </remarks>
		/// <param name="blue"></param>
		/// <param name="green"></param>
		/// <param name="red"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetGamma(float red, float green, 
			float blue);
		
		/// <summary>
		/// Set the gamma translation table for the red, green, and blue
		///  channels
		/// of the video hardware.  Each table is an array of 256 
		/// 16-bit quantities,
		/// representing a mapping between the input and output for that 
		/// channel.
		/// The input is the index into the array, and the output is the 16-bit
		/// gamma value at that index, scaled to the output color precision.
		/// </summary>
		/// <remarks>
		/// You may pass NULL for any of the channels to leave it unchanged.
		/// If the call succeeds, it will return 0.  If the display driver or
		/// hardware does not support gamma translation, or otherwise fails,
		/// this function will return -1.
		/// </remarks>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetGammaRamp(IntPtr red, IntPtr green,
			IntPtr blue);

		/// <summary>
		/// Retrieve the current values of the gamma translation tables.
		/// </summary>
		/// <remarks>
		/// You must pass in valid pointers to arrays of 256 16-bit quantities.
		/// Any of the pointers may be NULL to ignore that channel.
		/// If the call succeeds, it will return 0.  If the display driver or
		/// hardware does not support gamma translation, or otherwise fails,
		/// this function will return -1.
		/// </remarks>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GetGammaRamp(IntPtr red, IntPtr green,
			IntPtr blue);
		
		/// <summary>
		/// This function performs a fast fill of the given rectangle with 
		/// 'color'
		/// The given rectangle is clipped to the destination surface clip area
		/// and the final fill rectangle is saved in the passed in pointer.
		/// If 'dstrect' is NULL, the whole surface will be filled with 'color'
		/// The color should be a pixel of the format used by the surface, and 
		/// can be generated by the SDL_MapRGB() function.
		/// This function returns 0 on success, or -1 on error.
		/// </summary>
		/// <param name="surface"></param>
		/// <param name="rect"></param>
		/// <param name="color"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_FillRect(IntPtr surface, IntPtr rect,
			int color);
		
		/// <summary>
		/// Maps an RGB triple to an opaque pixel value for a given pixel
		///  format.
		/// </summary>
		/// <remarks>
		///
		/// </remarks>
		/// <param name="format"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_MapRGB(IntPtr format, Byte r, Byte g, 
			Byte b);
		
		/// <summary>
		/// Maps an RGBA quadruple to a pixel value for a given pixel format.
		/// </summary>
		/// <remarks>
		///
		/// </remarks>
		/// <param name="format"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		/// <param name="a"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_MapRGBA(IntPtr format, Byte r, Byte g,
			Byte b, Byte a);

		/// <summary>
		/// Maps a pixel value into the RGB components for a given pixel 
		/// format.
		/// </summary>
		/// <param name="pixel"></param>
		/// <param name="fmt"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_GetRGB(int pixel, IntPtr fmt, 
			out Byte r, out Byte g, out Byte b);
		
		/// <summary>
		/// Maps a pixel value into the RGBA components for a given pixel
		///  format
		/// </summary>
		/// <param name="pixel"></param>
		/// <param name="fmt"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		/// <param name="a"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_GetRGBA(int pixel, IntPtr fmt, 
			out Byte r, out Byte g, out Byte b, out Byte a);

		//Mouse
		/// <summary>
		/// Retrieve the current state of the mouse.
		/// </summary>
		/// <remarks>
		/// The current button state is returned as a button bitmask, 
		/// and x and y are set to the current mouse cursor position.  
		/// You can pass NULL for either x or y.
		/// </remarks>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern Byte SDL_GetMouseState(out int x, out int y);

		/// <summary>
		/// Retrieve the current state of the mouse.
		/// </summary>
		/// <remarks>
		/// The current button state is returned as a button bitmask, 
		/// and x and y are set to the mouse deltas since the last call to
		///  SDL_GetRelativeMouseState().  
		/// </remarks>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern Byte SDL_GetRelativeMouseState(out int x, out int y);
		
		/// <summary>
		/// Create a cursor using the specified data and mask (in MSB format).
		/// The cursor width must be a multiple of 8 bits. 
		/// </summary>
		/// <remarks>
		/// The cursor is created in black and white according to the 
		/// following:
		/// data  mask    resulting pixel on screen
		///  0     1       White
		///  1     1       Black
		///  0     0       Transparent
		///  1     0       Inverted color if possible, black if not.
		///
		/// Cursors created with this function must be freed with 
		/// SDL_FreeCursor().
		/// </remarks>
		/// <param name="data"></param>
		/// <param name="h"></param>
		/// <param name="hot_x"></param>
		/// <param name="hot_y"></param>
		/// <param name="mask"></param>
		/// <param name="w"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CreateCursor(IntPtr data, IntPtr mask,
			int w, int h, int hot_x, int hot_y);

		/// <summary>
		/// Set the currently active cursor to the specified one. 
		/// </summary>
		/// <remarks>
		/// If the cursor is currently visible, the change will be immediately 
		/// represented on the display.
		/// </remarks>
		/// <param name="cursor"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_SetCursor(IntPtr cursor);

		/// <summary>
		/// Returns the currently active cursor. 
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_GetCursor();

		/// <summary>
		/// Deallocates a cursor created with SDL_CreateCursor(). 
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="cursor"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_FreeCursor(IntPtr cursor);
		
		/// <summary>
		/// Toggle whether or not the cursor is shown on the screen.
		/// </summary>
		/// <remarks>
		/// The cursor start off displayed, but can be turned off.
		/// SDL_ShowCursor() returns 1 if the cursor was being displayed
		/// before the call, or 0 if it was not.  You can query the current
		/// state by passing a 'toggle' value of -1.
		/// </remarks>
		/// <param name="toggle"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_ShowCursor(int toggle);
		
		/// <summary>
		/// Set the position of the mouse cursor (generates a mouse motion 
		/// event).
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_WarpMouse(short x, short y);
		
		/// <summary>
		/// Allocate and free an RGB surface (must be called 
		/// after SDL_SetVideoMode)
		/// If the depth is 4 or 8 bits, an empty palette is allocated 
		/// for the surface.
		/// If the depth is greater than 8 bits, the pixel format is set 
		/// using the
		/// flags '[RGB]mask'.
		/// If the function runs out of memory, it will return NULL.
		/// </summary>
		/// <remarks>
		///The 'flags' tell what kind of surface to create.
		/// SDL_SWSURFACE means that the surface should be created in 
		/// system memory.
		/// SDL_HWSURFACE means that the surface should be created in 
		/// video memory,
		/// with the same format as the display surface.  This is useful 
		/// for surfaces
		/// that will not change much, to take advantage of hardware
		///  acceleration
		/// when being blitted to the display surface.
		/// SDL_ASYNCBLIT means that SDL will try to perform asynchronous 
		/// blits with
		/// this surface, but you must always lock it before accessing the 
		/// pixels.
		/// SDL will wait for current blits to finish before returning from 
		/// the lock.
		/// SDL_SRCCOLORKEY indicates that the surface will be used for 
		/// colorkey blits.
		/// If the hardware supports acceleration of colorkey blits between
		/// two surfaces in video memory, SDL will try to place the surface in
		/// video memory. If this isn't possible or if there is no hardware
		/// acceleration available, the surface will be placed in system 
		/// memory.
		/// SDL_SRCALPHA means that the surface will be used for alpha 
		/// blits and 
		/// if the hardware supports hardware acceleration of alpha 
		/// blits between
		/// two surfaces in video memory, to place the surface in video memory
		/// if possible, otherwise it will be placed in system memory.
		/// If the surface is created in video memory, blits will be 
		/// _much_ faster,
		/// but the surface format must be identical to the video 
		/// surface format,
		/// and the only way to access the pixels member of the surface 
		/// is to use
		/// the SDL_LockSurface() and SDL_UnlockSurface() calls.
		/// If the requested surface actually resides in video memory,
		///  SDL_HWSURFACE
		/// will be set in the flags member of the returned surface.  
		/// If for some reason the surface could not be placed in 
		/// video memory, 
		/// it will not have
		/// the SDL_HWSURFACE flag set, and will be created in system 
		/// memory instead.
		/// </remarks>
		/// <param name="flags"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="depth"></param>
		/// <param name="Rmask"></param>
		/// <param name="Gmask"></param>
		/// <param name="Bmask"></param>
		/// <param name="Amask"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_CreateRGBSurface(int flags, 
			int width, int height, int depth, 
			int Rmask, int Gmask, int Bmask, int Amask);

		/// <summary>
		/// Allocate and free an RGB surface (must be called after
		///  SDL_SetVideoMode)
		/// If the depth is 4 or 8 bits, an empty palette is allocated 
		/// for the surface.
		/// If the depth is greater than 8 bits, the pixel format is set 
		/// using the
		/// flags '[RGB]mask'.
		/// If the function runs out of memory, it will return NULL. 
		/// </summary>
		/// <remarks>
		///The 'flags' tell what kind of surface to create.
		/// SDL_SWSURFACE means that the surface should be created in 
		/// system memory.
		/// SDL_HWSURFACE means that the surface should be created in 
		/// video memory,
		/// with the same format as the display surface.  This is useful 
		/// for surfaces
		/// that will not change much, to take advantage of hardware
		/// acceleration
		/// when being blitted to the display surface.
		/// SDL_ASYNCBLIT means that SDL will try to perform asynchronous 
		/// blits with
		/// this surface, but you must always lock it before accessing the 
		/// pixels.
		/// SDL will wait for current blits to finish before returning
		///  from the lock.
		/// SDL_SRCCOLORKEY indicates that the surface will be used for
		///  colorkey blits.
		/// If the hardware supports acceleration of colorkey blits between
		/// two surfaces in video memory, SDL will try to place the surface in
		/// video memory. If this isn't possible or if there is no hardware
		/// acceleration available, the surface will be placed in system 
		/// memory.
		/// SDL_SRCALPHA means that the surface will be used for alpha 
		/// blits and 
		/// if the hardware supports hardware acceleration of alpha 
		/// blits between
		/// two surfaces in video memory, to place the surface in video memory
		/// if possible, otherwise it will be placed in system memory.
		/// If the surface is created in video memory, blits will be 
		/// _much_ faster,
		/// but the surface format must be identical to the video 
		/// surface format,
		/// and the only way to access the pixels member of the surface 
		/// is to use
		/// the SDL_LockSurface() and SDL_UnlockSurface() calls.
		/// If the requested surface actually resides in video memory,
		///  SDL_HWSURFACE
		/// will be set in the flags member of the returned surface.
		///   If for some
		/// reason the surface could not be placed in video memory, 
		/// it will not have
		/// the SDL_HWSURFACE flag set, and will be created in system 
		/// memory instead.
		/// </remarks>
		/// <param name="pixels"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="depth"></param>
		/// <param name="pitch"></param>
		/// <param name="Rmask"></param>
		/// <param name="Gmask"></param>
		/// <param name="Bmask"></param>
		/// <param name="Amask"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_CreateRGBSurfaceFrom(IntPtr pixels, 
			int width, int height, int depth, int pitch, int Rmask, 
			int Gmask, int Bmask, int Amask);
		
		/// <summary>
		/// This performs a fast blit from the source surface to the 
		/// destination
		/// surface.  It assumes that the source and destination rectangles are
		/// the same size.  If either 'srcrect' or 'dstrect' are NULL, 
		/// the entire
		/// surface (src or dst) is copied.  The final blit rectangles 
		/// are saved
		/// in 'srcrect' and 'dstrect' after all clipping is performed.
		/// If the blit is successful, it returns 0, otherwise it returns -1.
		///
		/// The blit function should not be called on a locked surface.
		///
		/// The blit semantics for surfaces with and without alpha and 
		/// colorkey
		/// are defined as follows:
		///
		/// RGBA->RGB:
		///     SDL_SRCALPHA set:
		/// 	alpha-blend (using alpha-channel).
		/// 	SDL_SRCCOLORKEY ignored.
		///     SDL_SRCALPHA not set:
		/// 	copy RGB.
		/// 	if SDL_SRCCOLORKEY set, only copy the pixels matching the
		/// 	RGB values of the source colour key, ignoring alpha in the
		/// 	comparison.
		/// 
		/// RGB->RGBA:
		///     SDL_SRCALPHA set:
		/// 	alpha-blend (using the source per-surface alpha value);
		/// 	set destination alpha to opaque.
		///     SDL_SRCALPHA not set:
		/// 	copy RGB, set destination alpha to source per-surface alpha 
		/// 	value.
		///     both:
		/// 	if SDL_SRCCOLORKEY set, only copy the pixels matching the
		/// 	source colour key.
		/// 
		/// RGBA->RGBA:
		///     SDL_SRCALPHA set:
		/// 	alpha-blend (using the source alpha channel) the RGB values;
		/// 	leave destination alpha untouched. [Note: is this correct?]
		/// 	SDL_SRCCOLORKEY ignored.
		///     SDL_SRCALPHA not set:
		/// 	copy all of RGBA to the destination.
		/// 	if SDL_SRCCOLORKEY set, only copy the pixels matching the
		/// 	RGB values of the source colour key, ignoring alpha in the
		/// 	comparison.
		/// 
		/// RGB->RGB: 
		///     SDL_SRCALPHA set:
		/// 	alpha-blend (using the source per-surface alpha value).
		///     SDL_SRCALPHA not set:
		/// 	copy RGB.
		///     both:
		/// 	if SDL_SRCCOLORKEY set, only copy the pixels matching the
		/// 	source colour key.
		///
		/// If either of the surfaces were in video memory, and the blit 
		/// returns -2,
		/// the video memory was lost, so it should be reloaded with 
		/// artwork and 
		/// re-blitted:
		/// while ( SDL_BlitSurface(image, imgrect, screen, dstrect) == -2 ) 
		/// {
		///	while ( SDL_LockSurface(image) 0 )
		///	Sleep(10);
		///	-- Write image pixels to image-pixels --
		///	SDL_UnlockSurface(image);
		/// }
		/// This happens under DirectX 5.0 when the system switches away 
		/// from your
		/// fullscreen application.  The lock will also fail until you 
		/// have access
		/// to the video memory again.
		/// </summary>
		/// <param name="src"></param>
		/// <param name="srcrect"></param>
		/// <param name="dst"></param>
		/// <param name="dstrect"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, 
			 EntryPoint="SDL_UpperBlit"), SuppressUnmanagedCodeSecurity]
		public static extern int SDL_BlitSurface(IntPtr src, IntPtr srcrect,
			IntPtr dst, IntPtr dstrect);
		
		/// <summary>
		/// This function returns a pointer to the current display surface.
		/// </summary>
		/// <remarks>
		/// If SDL is doing format conversion on the display surface, this
		/// function returns the publicly visible surface, not the real video
		/// surface.
		/// </remarks>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_GetVideoSurface();
		
		/// <summary>
		/// SDL_LockSurface() sets up a surface for directly accessing 
		/// the pixels.
		/// Between calls to SDL_LockSurface()/SDL_UnlockSurface(),
		///  you can write
		/// to and read from 'surface->pixels', using the pixel format 
		/// stored in 
		/// 'surface->format'.  Once you are done accessing the surface, 
		/// you should 
		/// use SDL_UnlockSurface() to release it.
		///
		/// Not all surfaces require locking.  If SDL_MUSTLOCK(surface)
		///  evaluates
		/// to 0, then you can read and write to the surface at any time,
		///  and the
		/// pixel format of the surface will not change.  In particular, if the
		/// SDL_HWSURFACE flag is not given when calling SDL_SetVideoMode(),
		///  you
		/// will not need to lock the display surface before accessing it.
		/// 
		/// No operating system or library calls should be made between 
		/// lock/unlock
		/// pairs, as critical system locks may be held during this time. 
		/// </summary>
		/// <remarks>
		/// SDL_LockSurface() returns 0, or -1 if the surface couldn't be 
		///locked.
		/// </remarks>
		/// <param name="surface"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_LockSurface(IntPtr surface);
		
		/// <summary>
		/// SDL_LockSurface() sets up a surface for directly accessing the 
		/// pixels.
		/// Between calls to SDL_LockSurface()/SDL_UnlockSurface(), 
		/// you can write
		/// to and read from 'surface->pixels', using the pixel format
		/// stored in 
		/// 'surface->format'.  Once you are done accessing the surface, 
		/// you should 
		/// use SDL_UnlockSurface() to release it.
		///
		/// Not all surfaces require locking.  If SDL_MUSTLOCK(surface)
		///  evaluates
		/// to 0, then you can read and write to the surface at any time,
		///  and the
		/// pixel format of the surface will not change.  In particular, 
		/// if the
		/// SDL_HWSURFACE flag is not given when calling SDL_SetVideoMode(),
		///  you
		/// will not need to lock the display surface before accessing it.
		/// 
		/// No operating system or library calls should be made between 
		/// lock/unlock
		/// pairs, as critical system locks may be held during this time. 
		/// </summary>
		/// <param name="surface"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_UnlockSurface(IntPtr surface);
		
		/// <summary>
		/// Load a surface from a seekable SDL data source (memory or file.)
		/// If 'freesrc' is non-zero, the source will be closed 
		/// after being read.
		/// Returns the new surface, or NULL if there was an error. 
		/// </summary>
		/// <remarks>
		/// The new surface should be freed with SDL_FreeSurface().
		/// </remarks>
		/// <param name="src"></param>
		/// <param name="freesrc"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_LoadBMP_RW(IntPtr src, int freesrc);
		
		/// <summary>
		/// Save a surface to a seekable SDL data source (memory or file.)
		/// If 'freedst' is non-zero, the source will be closed after 
		/// being written.
		/// Returns 0 if successful or -1 if there was an error.
		/// </summary>
		/// <param name="surface"></param>
		/// <param name="dst"></param>
		/// <param name="freedst"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SaveBMP_RW(IntPtr surface, IntPtr dst,
			int freedst);
		
		/// <summary>
		/// Sets a portion of the colormap for the given 8-bit surface.  
		/// If 'surface'
		/// is not a palettized surface, this function does nothing, 
		/// returning 0.
		/// If all of the colors were set as passed to SDL_SetColors(), it will
		/// return 1.  If not all the color entries were set exactly as given,
		/// it will return 0, and you should look at the surface palette to
		/// determine the actual color palette.
		/// </summary>
		/// <remarks>
		/// When 'surface' is the surface associated with the current 
		/// display, the
		/// display colormap will be updated with the requested colors.  If 
		/// SDL_HWPALETTE was set in SDL_SetVideoMode() flags, SDL_SetColors()
		/// will always return 1, and the palette is guaranteed to be set 
		/// the way
		/// you desire, even if the window colormap has to be warped or 
		/// run under
		/// emulation.
		/// </remarks>
		/// <param name="surface"></param>
		/// <param name="firstcolor"></param>
		/// <param name="ncolors"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetColors(IntPtr surface, 
			int firstcolor, int ncolors);
	
		/// <summary>
		///  Sets a portion of the colormap for a given 8-bit surface.
		/// 'flags' is one or both of:
		/// SDL_LOGPAL  -- set logical palette, which controls how blits 
		/// are mapped
		///                to/from the surface,
		/// SDL_PHYSPAL -- set physical palette, which controls how pixels 
		/// look on
		///                the screen
		/// Only screens have physical palettes. Separate change of 
		/// physical/logical
		/// palettes is only possible if the screen has SDL_HWPALETTE set.
		///
		/// The return value is 1 if all colours could be set as requested,
		///  and 0
		/// otherwise.
		/// </summary>
		/// <remarks>
		/// SDL_SetColors() is equivalent to calling this function with
		///	flags = (SDL_LOGPAL|SDL_PHYSPAL).
		/// </remarks>
		/// <param name="surface"></param>
		/// <param name="colors"></param>
		/// <param name="firstcolor"></param>
		/// <param name="flags"></param>
		/// <param name="ncolors"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetPalette(IntPtr surface, int flags,
			IntPtr colors, int firstcolor, int ncolors);
		
		/// <summary>
		/// Sets the color key (transparent pixel) in a blittable surface.
		/// If 'flag' is SDL_SRCCOLORKEY (optionally OR'd with SDL_RLEACCEL), 
		/// 'key' will be the transparent pixel in the source image of a blit.
		/// SDL_RLEACCEL requests RLE acceleration for the surface if present,
		/// and removes RLE acceleration if absent.
		/// </summary>
		/// <remarks>
		/// If 'flag' is 0, this function clears any current color key.
		/// This function returns 0, or -1 if there was an error.
		/// </remarks>
		/// <param name="surface"></param>
		/// <param name="flag"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetColorKey(IntPtr surface, int flag,
			int key);
		
		/// <summary>
		/// Sets the clipping rectangle for the destination surface in a blit.
		///
		/// If the clip rectangle is NULL, clipping will be disabled.
		/// If the clip rectangle doesn't intersect the surface, 
		/// the function will
		/// return SDL_FALSE and blits will be completely clipped.  
		/// Otherwise the
		/// function returns SDL_TRUE and blits to the surface will be 
		/// clipped to
		/// the intersection of the surface area and the clipping rectangle. 
		/// </summary>
		/// <remarks>
		/// Note that blits are automatically clipped to the edges of the 
		/// source
		/// and destination surfaces.
		/// </remarks>
		/// <param name="surface"></param>
		/// <param name="rect"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_SetClipRect(IntPtr surface, IntPtr rect);
		
		/// <summary>
		/// Gets the clipping rectangle for the destination surface in a blit.
		/// 'rect' must be a pointer to a valid rectangle which will be filled
		/// with the correct values.
		/// </summary>
		/// <param name="surface"></param>
		/// <param name="rect"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_GetClipRect(IntPtr surface, IntPtr rect);
		
		/// <summary>
		/// This function takes a surface and copies it to a new surface of the
		/// pixel format and colors of the video framebuffer, suitable for fast
		/// blitting onto the display surface.  It calls SDL_ConvertSurface()
		///
		/// If you want to take advantage of hardware colorkey or alpha blit
		/// acceleration, you should set the colorkey and alpha value before
		/// calling this function.
		///
		/// If the conversion fails or runs out of memory, it returns NULL
		/// </summary>
		/// <param name="surface"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_DisplayFormat(IntPtr surface);

		/// <summary>
		/// This function takes a surface and copies it to a new surface of the
		/// pixel format and colors of the video framebuffer (if possible),
		/// suitable for fast alpha blitting onto the display surface.
		/// The new surface will always have an alpha channel.
		///
		/// If you want to take advantage of hardware colorkey or alpha blit
		/// acceleration, you should set the colorkey and alpha value before
		/// calling this function.
		///
		/// If the conversion fails or runs out of memory, it returns NULL
		/// </summary>
		/// <param name="surface"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_DisplayFormatAlpha(IntPtr surface);

		/// <summary>
		/// Creates a new surface of the specified format, and then copies 
		/// and maps 
		/// the given surface to it so the blit of the converted surface 
		/// will be as 
		/// fast as possible.  If this function fails, it returns NULL.
		///
		/// The 'flags' parameter is passed to SDL_CreateRGBSurface() 
		/// and has those 
		/// semantics.  You can also pass SDL_RLEACCEL in the flags parameter
		///  and
		/// SDL will try to RLE accelerate colorkey and alpha blits 
		/// in the resulting
		/// surface.
		///
		/// This function is used internally by SDL_DisplayFormat().
		/// </summary>
		/// <param name="src"></param>
		/// <param name="fmt"></param>
		/// <param name="flags"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_ConvertSurface(IntPtr src, IntPtr fmt,
			int flags);
		
		//Mridul
		/// <summary>
		/// This function sets the alpha value for the entire surface, 
		/// as opposed to
		/// using the alpha component of each pixel. This value measures 
		/// the range
		/// of transparency of the surface, 0 being completely transparent to
		///  255
		/// being completely opaque. An 'alpha' value of 255 causes blits to be
		/// opaque, the source pixels copied to the destination 
		/// (the default). Note
		/// that per-surface alpha can be combined with colorkey transparency.
		///
		/// If 'flag' is 0, alpha blending is disabled for the surface.
		/// If 'flag' is SDL_SRCALPHA, alpha blending is enabled for the 
		/// surface.
		/// OR:ing the flag with SDL_RLEACCEL requests RLE acceleration for the
		/// surface; if SDL_RLEACCEL is not specified, the RLE accel will 
		/// be removed.
		/// </summary>
		/// <remarks>
		/// The 'alpha' parameter is ignored for surfaces that have an alpha
		///  channel.
		/// </remarks>
		/// <param name="surface"></param>
		/// <param name="flag"></param>
		/// <param name="alpha"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_SetAlpha(IntPtr surface, int flag, 
			Byte alpha);
		
		// RWops
		/// <summary>
		/// 
		/// </summary>
		/// <param name="file"></param>
		/// <param name="mode"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_RWFromFile(String file, String mode);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="mem"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_RWFromMem(Byte[] mem, int size);
		
		//Events

		/// <summary>
		/// Checks the event queue for messages and optionally returns them.
		/// </summary>
		/// <remarks>
		/// Checks the event queue for messages and optionally returns them.
		/// If action is SDL_ADDEVENT, up to numevents events will be added to the back of the event queue.
		/// If action is SDL_PEEKEVENT, up to numevents events at the front of the event queue, matching mask, will be returned and 			/// will not be removed from the queue.
		/// If action is SDL_GETEVENT, up to numevents events at the front of the event queue, matching mask, will be returned and 			/// will be removed from the queue.
		/// </remarks>
		/// <param name="events"></param>
		/// <param name="numEvents"></param>
		/// <param name="action"></param>
		/// <param name="mask"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_PeepEvents([Out]SDL_Event[] events, int numEvents, SDL_eventaction action, int mask);	

		/// <summary>
		/// Polls for currently pending events, and returns 1 if there are 
		/// any pending
		/// events, or 0 if there are none available.  If 'event' is not 
		/// NULL, the next
		/// event is removed from the queue and stored in that area. 
		/// </summary>
		/// <param name="sdlEvent"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_PollEvent(out SDL_Event sdlEvent);
		
		/// <summary>
		/// This function allows you to set the state of processing certain 
		/// events.
		/// If 'state' is set to SDL_IGNORE, that event will be automatically
		///  dropped
		/// from the event queue and will not event be filtered.
		/// If 'state' is set to SDL_ENABLE, that event will be processed 
		/// normally.
		/// If 'state' is set to SDL_QUERY, SDL_EventState() will return the 
		/// current processing state of the specified event.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_EventState(Byte type, int state);

		/// <summary>
		/// Waits indefinitely for the next available event, returning 1,
		///  or 0 if there
		/// was an error while waiting for events.  If 'event' is not NULL, 
		/// the next
		/// event is removed from the queue and stored in that area.
		/// </summary>
		/// <param name="evt"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_WaitEvent(out SDL_Event evt);

		/// <summary>
		/// Pumps the event loop, gathering events from the input devices.
		/// </summary>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_PumpEvents();		

		/// <summary>
		/// Add an event to the event queue.
		/// This function returns 0 if the event queue was full, or -1
		/// if there was some other error.  Returns 1 on success.
		/// </summary>
		/// <param name="evt"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_PushEvent(out SDL_Event evt);
		
		// WM
		/// <summary>
		/// Sets the title and icon text of the display window
		/// </summary>
		/// <param name="title"></param>
		/// <param name="icon"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_WM_SetCaption(string title, string icon);
		
		/// <summary>
		/// Gets the title and icon text of the display window
		/// </summary>
		/// <param name="title"></param>
		/// <param name="icon"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_WM_GetCaption(out string title, 
			out string icon);

		/// <summary>
		/// Sets the icon for the display window.
		/// This function must be called before the first call to 
		/// SDL_SetVideoMode().
		/// It takes an icon surface, and a mask in MSB format.
		/// If 'mask' is NULL, the entire icon surface will be used as the
		///  icon.
		/// </summary>
		/// <param name="icon"></param>
		/// <param name="mask"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_WM_SetIcon(IntPtr icon, IntPtr mask);
		
		/// <summary>
		/// This function iconifies the window, and returns 1 if it succeeded.
		/// If the function succeeds, it generates an SDL_APPACTIVE loss event.
		/// This function is a noop and returns 0 in non-windowed environments.
		/// </summary>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_WM_IconifyWindow();
		
		/// <summary>
		/// Grabbing means that the mouse is confined to the application 
		/// window,
		/// and nearly all keyboard input is passed directly to the 
		/// application,
		/// and not interpreted by a window manager, if any.
		/// </summary>
		/// <param name="mode"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_WM_GrabInput(SDL_GrabMode mode);

		/// <summary>
		/// Toggle fullscreen mode without changing the contents of the screen.
		/// If the display surface does not require locking before accessing
		/// the pixel information, then the memory pointers will not change.
		///
		/// If this function was able to toggle fullscreen mode (change from 
		/// running in a window to fullscreen, or vice-versa),
		///  it will return 1.
		/// If it is not implemented, or fails, it returns 0.
		///
		/// The next call to SDL_SetVideoMode() will set the mode fullscreen
		/// attribute based on the flags parameter - if SDL_FULLSCREEN is not
		/// set, then the display will be windowed by default where supported.
		///
		/// This is currently only implemented in the X11 video driver.
		/// </summary>
		/// <param name="surface"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_WM_ToggleFullScreen(IntPtr surface);

		// Joystick
		/// <summary>
		/// Count the number of joysticks attached to the system.
		/// </summary>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_NumJoysticks();

		/// <summary>
		/// Get the implementation dependent name of a joystick.
		/// This can be called before any joysticks are opened.
		/// If no name can be found, this function returns NULL.
		/// </summary>
		/// <param name="device_index"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern string SDL_JoystickName(int device_index);

		/// <summary>
		/// Open a joystick for use - the index passed as an argument refers to
		/// the N'th joystick on the system.  This index is the value which
		///  will
		/// identify this joystick in future joystick events.
		/// </summary>
		/// <remarks>
		/// This function returns a joystick identifier, 
		/// or NULL if an error occurred.
		/// </remarks>
		/// <param name="device_index"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_JoystickOpen(int device_index);

		/// <summary>
		/// Checks if the joystick has been opened.
		/// </summary>
		/// <remarks>
		/// Returns 1 if the joystick has been opened, or 0 if it has not.
		/// </remarks>
		/// <param name="device_index"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickOpened(int device_index);
		
		/// <summary>
		/// Get the device index of an opened joystick.
		/// </summary>
		/// <param name="joystick"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickIndex(IntPtr joystick);
		
		/// <summary>
		/// Get the number of general axis controls on a joystick.
		/// </summary>
		/// <param name="joystick"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickNumAxes(IntPtr joystick);

		/// <summary>
		/// Get the number of trackballs on a joystick.
		/// </summary>
		/// <remarks>
		/// Joystick trackballs have only relative motion events associated
		/// with them and their state cannot be polled.
		/// </remarks>
		/// <param name="joystick"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickNumBalls(IntPtr joystick);
		
		/// <summary>
		/// Get the number of POV hats on a joystick.
		/// </summary>
		/// <param name="joystick"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickNumHats(IntPtr joystick);
		
		/// <summary>
		/// Get the number of buttons on a joystick.
		/// </summary>
		/// <param name="joystick"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_JoystickNumButtons(IntPtr joystick);

		/// <summary>
		/// Get the current state of an axis control on a joystick
		/// </summary>
		/// <remarks>
		/// The state is a value ranging from -32768 to 32767.
		/// The axis indices start at index 0.
		/// </remarks>
		/// <param name="joystick"></param>
		/// <param name="axis"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_JoystickGetAxis(IntPtr joystick, 
			int axis);

		/// <summary>
		/// Get the hat index. 
		/// </summary>
		/// <remarks>
		/// The hat indices start at index 0.
		/// </remarks>
		/// <param name="joystick"></param>
		/// <param name="hat"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_JoystickGetHat(IntPtr joystick,
			int hat);
		
		/// <summary>
		/// Get the ball axis change since the last poll. 
		/// </summary>
		/// <remarks>
		/// This returns 0, or -1 if you passed it invalid parameters.
		/// The ball indices start at index 0.
		/// </remarks>
		/// <param name="joystick"></param>
		/// <param name="ball"></param>
		/// <param name="dx"></param>
		/// <param name="dy"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_JoystickGetBall(IntPtr joystick, 
			int ball, IntPtr dx, IntPtr dy);
		
		/// <summary>
		/// Get the current state of a button on a joystick. 
		/// </summary>
		/// <remarks>
		/// The ball indices start at index 0.
		/// </remarks>
		/// <param name="joystick"></param>		
		/// <param name="button"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_JoystickGetButton(IntPtr joystick, 
			int button);
		
		/// <summary>
		/// Close a joystick previously opened with SDL_JoystickOpen(). 
		/// </summary>
		/// <param name="joystick"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_JoystickClose(IntPtr joystick);
		
		// OpenGL
		/// <summary>
		/// Swap the OpenGL buffers, if double-buffering is supported.
		/// </summary>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_GL_SwapBuffers();

		/// <summary>
		/// Set an attribute of the OpenGL subsystem before intialization.
		/// </summary>
		/// <param name="attr"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GL_SetAttribute(SDL_GLattr attr, 
			int value);
		
		/// <summary>
		/// Get an attribute of the OpenGL subsystem from the windowing
		/// interface, such as glX. This is of course different from getting
		/// the values from SDL's internal OpenGL subsystem, which only
		/// stores the values you request before initialization.
		///
		/// Developers should track the values they pass into
		///  SDL_GL_SetAttribute
		/// themselves if they want to retrieve these values.
		/// </summary>
		/// <param name="attr"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_GL_GetAttribute(SDL_GLattr attr, 
			out int val);
		
		/// <summary>
		///		
		/// </summary>
		/// <param name="extension"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_GL_GetProcAddress(string extension);
 
		// CD-Rom
		/// <summary>
		/// SDL_CDNumDrives -- Returns the number of CD-ROM drives on the 
		/// system.
		/// </summary>
		/// <remarks>
		/// Returns the number of CD-ROM drives on the system, 
		/// or -1 if SDL_Init() has not been called with the SDL_INIT_CDROM 
		/// flag.
		/// </remarks>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDNumDrives();

		/// <summary>
		/// Returns a human-readable, system-dependent identifier for the 
		/// CD-ROM.
		/// </summary>
		/// <remarks>
		/// Drive is the index of the drive. Drive indices start to 0 and end 
		/// at SDL_CDNumDrives()-1.
		/// Example:
		/// "/dev/cdrom"
		/// "E:"
		/// "/dev/disk/ide/1/master"
		/// </remarks>
		/// <param name="drive"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern string SDL_CDName(int drive);

		/// <summary>
		/// Opens a CD-ROM drive for access.  
		/// It returns a drive handle on success,
		/// or NULL if the drive was invalid or busy.  
		/// This newly opened CD-ROM becomes the default CD 
		/// used when other CD functions are passed a NULL CD-ROM handle.
		/// </summary>
		/// <remarks>
		/// Drives are numbered starting with 0.  Drive 0 is the system 
		/// default CD-ROM.
		/// Opens a CD-ROM drive for access. It returns a SDL_CD structure 
		/// on success, 
		/// or NULL if the drive was invalid or busy. 
		/// This newly opened CD-ROM becomes the default CD used 
		/// when other CD functions are passed a NULL CD-ROM handle.
		/// </remarks>
		/// <param name="drive"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_CDOpen(int drive);

		/// <summary>
		/// This function returns the current status of the given drive.
		/// </summary>
		/// <remarks>
		/// If the drive has a CD in it, 
		/// the table of contents of the CD and current play position 
		/// of the CD will be stored in the SDL_CD structure.
		/// </remarks>
		/// <param name="cdrom"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), 
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDStatus(IntPtr cdrom);

		/// <summary>
		/// Play the given CD starting at 'start' frame for 'length' frames. 
		/// </summary>
		/// <remarks>
		/// It returns 0, or -1 if there was an error.
		/// </remarks>
		/// <param name="cdrom"></param>
		/// <param name="start"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDPlay(IntPtr cdrom, int start, 
			int length);

		/// <summary>
		/// Play the given CD starting at 'start_track' and 
		/// 'start_frame' for 'ntracks' tracks and 'nframes' frames.  
		/// If both 'ntrack' and 'nframe' are 0,
		/// play until the end of the CD. 
		/// This function will skip data tracks.
		/// </summary>
		/// <remarks>
		/// This function should only be called after calling SDL_CDStatus()
		///  to 
		/// get track information about the CD.
		/// For example:
		/// // Play entire CD:
		/// if ( CD_INDRIVE(SDL_CDStatus(cdrom)) )
		/// SDL_CDPlayTracks(cdrom, 0, 0, 0, 0);
		/// // Play last track:
		/// if ( CD_INDRIVE(SDL_CDStatus(cdrom)) ) {
		/// SDL_CDPlayTracks(cdrom, cdrom->numtracks-1, 0, 0, 0);
		/// }
		/// // Play first and second track and 10 seconds of third track:
		/// if ( CD_INDRIVE(SDL_CDStatus(cdrom)) )
		/// SDL_CDPlayTracks(cdrom, 0, 0, 2, 10);
		///
		/// This function returns 0, or -1 if there was an error.
		/// </remarks>
		/// <param name="cdrom"></param>
		/// <param name="start_track"></param>
		/// <param name="start_frame"></param>
		/// <param name="ntracks"></param>
		/// <param name="nframes"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDPlayTracks(IntPtr cdrom, 
			int start_track, int start_frame, int ntracks, 
			int nframes);

		/// <summary>
		/// Pause play.
		/// </summary>
		/// <remarks>
		/// Returns 0, or -1 on error.
		/// </remarks>
		/// <param name="cdrom"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDPause(IntPtr cdrom);

		/// <summary>
		/// Resume play.
		/// </summary>
		/// <remarks>
		/// Returns 0, or -1 on error.
		/// </remarks>
		/// <param name="cdrom"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDResume(IntPtr cdrom);

		/// <summary>
		/// Stop play.
		/// </summary>
		/// <remarks>
		/// Returns 0, or -1 on error.
		/// </remarks>
		/// <param name="cdrom"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDStop(IntPtr cdrom);

		/// <summary>
		/// Eject CD-ROM
		/// </summary>
		/// <remarks>
		/// Returns 0, or -1 on error.
		/// </remarks>
		/// <param name="cdrom"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_CDEject(IntPtr cdrom);

		/// <summary>
		/// Closes the handle for the CD-ROM drive
		/// </summary>
		/// <param name="cdrom"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_CDClose(IntPtr cdrom);

		/// <summary>
		/// 
		/// </summary>
		public static int SDL_BYTEORDER {
			get {
				if (BitConverter.IsLittleEndian) {
					return SDL_LIL_ENDIAN;
				}
				else {
					return SDL_BIG_ENDIAN;
				}
			}
		}

		/// <summary>
		/// Native audio byte ordering
		/// </summary>
		public static int AUDIO_U16SYS {
			get {
				if (SDL_BYTEORDER == SDL_LIL_ENDIAN) {
					return AUDIO_U16LSB;
				}
				else {
					return AUDIO_U16MSB;
				}
			}
		}

		/// <summary>
		/// Native audio byte ordering
		/// </summary>
		public static int AUDIO_S16SYS {
			get {
				if (SDL_BYTEORDER == SDL_LIL_ENDIAN) {
					return AUDIO_S16LSB;
				}
				else {
					return AUDIO_S16MSB;
				}
			}
		}

		/// <summary>
		/// This function is used internally, 
		/// and should not be used unless you
		/// have a specific need to specify the audio driver you want to use.
		/// You should normally use SDL_Init() or SDL_InitSubSystem().
		/// </summary>
		/// <param name="driver_name">
		/// </param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_AudioInit(String driver_name);

		/// <summary>
		/// This function is used internally, 
		/// and should not be used unless you
		/// have a specific need to specify the audio driver you want to use.
		/// You should normally use SDL_Init() or SDL_InitSubSystem().
		/// </summary>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_AudioQuit();

		/// <summary>
		/// This function fills the given character buffer with the name of the
		/// current audio driver, and returns a pointer to it if the audio
		///  driver has	been initialized.  
		///  It returns NULL if no driver has been initialized.
		/// </summary>
		/// <param name="buf"></param>
		/// <param name="maxlen"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern String SDL_AudioDriverName(
			String buf, int maxlen);

		/// <summary>
		/// This function opens the audio device with the desired 
		/// parameters, and
		///	returns 0 if successful, placing the actual hardware 
		/// parameters in the
		/// structure pointed to by 'obtained'.  
		/// If 'obtained' is NULL, the audio
		/// data passed to the callback function will be guaranteed 
		/// to be in the
		/// requested format, and will be automatically converted to the 
		/// hardware
		/// audio format if necessary.  This function returns -1 if it failed 
		/// to open the audio device, or couldn't set up the audio thread.
		/// When filling in the desired audio spec structure,
		/// 'desired->freq' should be the desired audio frequency in 
		/// samples-per-second.
		/// 'desired->format' should be the desired audio format.
		/// 'desired->samples' is the desired size of the audio buffer,
		///  in samples.
		/// This number should be a power of two, and may be adjusted 
		/// by the audio
		/// driver to a value more suitable for the hardware. 
		///  Good values seem to
		/// range between 512 and 8096 inclusive, depending on the 
		/// application and
		/// CPU speed.  Smaller values yield faster response time, 
		/// but can lead
		/// to underflow if the application is doing heavy processing and 
		/// cannot
		/// fill the audio buffer in time.  A stereo sample consists 
		/// of both right
		/// and left channels in LR ordering.
		/// Note that the number of samples is directly related to 
		/// time by the
		/// following formula:  ms = (samples*1000)/freq
		/// 'desired->size' is the size in bytes of the audio buffer, and is
		/// calculated by SDL_OpenAudio().
		/// 'desired->silence' is the value used to set the buffer to silence,
		/// and is calculated by SDL_OpenAudio().
		/// 'desired->callback' should be set to a function that will be 
		/// called
		/// when the audio device is ready for more data.  
		/// It is passed a pointer
		/// to the audio buffer, and the length in bytes of the audio buffer.
		/// This function usually runs in a separate thread, and so you should
		/// protect data structures that it accesses by calling SDL_LockAudio()
		/// and SDL_UnlockAudio() in your code.
		/// 'desired->userdata' is passed as the first parameter to 
		/// your callback
		/// function. The audio device starts out playing silence when
		///  it's opened, and should be enabled for playing by calling
		///   SDL_PauseAudio(0) when you are ready
		/// for your audio callback function to be called.  Since the 
		/// audio driver
		/// may modify the requested size of the audio buffer,
		///  you should allocate
		///any local mixing buffers after you open the audio device.
		/// </summary>
		/// <param name="desired"></param>
		/// <param name="obtained"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_OpenAudio(
			IntPtr desired, IntPtr obtained);

		/// <summary>
		/// Get the current audio state
		/// </summary>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern SDL_audiostatus SDL_GetAudioStatus();

		/// <summary>
		/// This function pauses and unpauses the audio callback processing.
		/// It should be called with a parameter of 0 after opening the audio
		/// device to start playing sound.  
		/// This is so you can safely initialize
		/// data for your callback function after opening the audio device.
		/// Silence will be written to the audio device during the pause.
		/// </summary>
		/// <param name="pause_on"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_PauseAudio(int pause_on);

		/// <summary>
		/// This function loads a WAVE from the data source, 
		/// automatically freeing
		/// that source if 'freesrc' is non-zero.  
		/// For example, to load a WAVE file,
		/// you could do:
		///	SDL_LoadWAV_RW(SDL_RWFromFile("sample.wav", "rb"), 1, ...);
		///
		/// If this function succeeds, it returns the given SDL_AudioSpec,
		/// filled with the audio data format of the wave data, and sets
		/// 'audio_buf' to a malloc()'d buffer containing the audio data,
		/// and sets 'audio_len' to the length of that audio buffer, in bytes.
		/// You need to free the audio buffer with SDL_FreeWAV() when you are 
		/// done with it.
		///
		/// This function returns NULL and sets the SDL error message if the 
		/// wave file cannot be opened, uses an unknown data format, or is 
		/// corrupt.  Currently raw and MS-ADPCM WAVE files are supported.
		/// </summary>
		/// <param name="audio_buf"></param>
		/// <param name="audio_len"></param>
		/// <param name="freesrc"></param>
		/// <param name="spec"></param>
		/// <param name="src"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDL_LoadWAV_RW(
			IntPtr src, int freesrc, IntPtr spec, 
			Byte[] audio_buf, IntPtr audio_len);


		//* Compatibility convenience function -- loads a WAV from a file */
		//#define SDL_LoadWAV(file, spec, audio_buf, audio_len) \
		//SDL_LoadWAV_RW(SDL_RWFromFile(file, "rb"),1, spec,audio_buf,audio_len)

		/// <summary>
		/// This function frees data previously allocated with SDL_LoadWAV_RW()
		/// </summary>
		/// <param name="audio_buf"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_FreeWAV(IntPtr audio_buf);

		/// <summary>
		/// This function takes a source format and rate and a 
		/// destination format
		/// and rate, and initializes the 'cvt' structure with 
		/// information needed
		/// by SDL_ConvertAudio() to convert a buffer of audio 
		/// data from one format
		/// to the other.
		/// This function returns 0, or -1 if there was an error.
		/// </summary>
		/// <param name="cvt"></param>
		/// <param name="src_format"></param>
		/// <param name="src_channels"></param>
		/// <param name="src_rate"></param>
		/// <param name="dst_format"></param>
		/// <param name="dst_channels"></param>
		/// <param name="dst_rate"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_BuildAudioCVT(IntPtr cvt,
			short src_format, Byte src_channels, int src_rate,
			Byte dst_format, Byte dst_channels, int dst_rate);

		/// <summary>
		/// Once you have initialized the 'cvt' structure using
		///  SDL_BuildAudioCVT(),
		/// created an audio buffer cvt->buf, and filled it with 
		/// cvt->len bytes of
		/// audio data in the source format, this function will 
		/// convert it in-place
		/// to the desired format.
		/// The data conversion may expand the size of the audio data, 
		/// so the buffer
		/// cvt->buf should be allocated after the cvt structure is 
		/// initialized by
		/// SDL_BuildAudioCVT(), and should be cvt->len///cvt->len_mult 
		/// bytes long.
		/// </summary>
		/// <param name="cvt"></param>
		/// <returns></returns>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern int SDL_ConvertAudio(IntPtr cvt);

		/// <summary>
		/// This takes two audio buffers of the playing audio format and mixes
		/// them, performing addition, volume adjustment, and overflow 
		/// clipping.
		/// The volume ranges from 0 - 128, and should be set 
		/// to SDL_MIX_MAXVOLUME
		/// for full audio volume.  Note this does not change hardware volume.
		/// This is provided for convenience -- 
		/// you can mix your own audio data.
		/// </summary>		
		/// <param name="dst"></param>
		/// <param name="src"></param>
		/// <param name="len"></param>
		/// <param name="volume"></param>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_MixAudio(
			IntPtr dst, IntPtr src, int len, int volume);

		/// <summary>
		/// The lock manipulated by these functions 
		/// protects the callback function.
		/// During a LockAudio/UnlockAudio pair, 
		/// you can be guaranteed that the
		/// callback function is not running.  
		/// Do not call these from the callback
		/// function or you will cause deadlock.
		/// </summary>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_LockAudio();

		/// <summary>
		/// The lock manipulated by these functions protects 
		/// the callback function.
		/// During a LockAudio/UnlockAudio pair, you can be guaranteed that the
		/// callback function is not running. 
		///  Do not call these from the callback
		/// function or you will cause deadlock.
		/// </summary>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_UnlockAudio();

		/// <summary>
		/// This function shuts down audio processing and 
		/// closes the audio device.
		/// </summary>
		[DllImport(SDL_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION),
		SuppressUnmanagedCodeSecurity]
		public static extern void SDL_CloseAudio();
	}
}
