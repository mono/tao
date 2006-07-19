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

#region Original Credits / License
//-----------------------------------------------------------------------------
//Copyright (C) 2003 Will Weisser (ogl@9mm.com)
// *
// * This library is free software; you can redistribute it and/or
// * modify it under the terms of the GNU Lesser General Public
// * License as published by the Free Software Foundation; either
// * version 2.1 of the License, or (at your option) any later version.
// * 
// * This library is distributed in the hope that it will be useful,
// * but WITHOUT ANY WARRANTY; without even the implied warranty of
// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// * Lesser General Public License for more details.
// * 
// * You should have received a copy of the GNU Lesser General Public
// * License along with this library; if not, write to the Free Software
// * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//-----------------------------------------------------------------------------
#endregion Original Credits / License

using System;
using System.Threading;
using Tao.Sdl;
using System.Runtime.InteropServices;
using System.IO;

namespace SdlExamples 
{
	#region Class Documentation
	/// <summary>
	/// Simple Tao.Sdl Example
	/// </summary>
	/// <remarks>
	/// Just draws a bunch of rectangles to the screen. 
	/// To quit, you can close the window, 
	/// press the Escape key or press the 'q' key
	/// <p>Written by David Hudson (jendave@yahoo.com)</p>
	/// <p>This is a reimplementation of an example 
	/// written by Will Weisser (ogl@9mm.com)</p>
	/// </remarks>
	#endregion Class Documentation
	public class SmpegPlayer 
	{		
		//int position = 0;
		//byte[] two = new byte[4096];
		//Smpeg.SMPEG_DisplayCallback callbackDelegate;
		IntPtr surfacePtr;

		#region Run()
		/// <summary>
		/// 
		/// </summary>
		public void Run() 
		{
			Sdl.SDL_Event evt;
			bool quitFlag = false;
			int flags = (Sdl.SDL_HWSURFACE|Sdl.SDL_DOUBLEBUF|Sdl.SDL_ANYFORMAT);
			int bpp = 16;
			int width = 352;
			int height = 240;
			
			Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
			Sdl.SDL_WM_SetCaption("Tao.Sdl Example - SmpegPlayer", "");
			surfacePtr = Sdl.SDL_SetVideoMode(
				width, 
				height, 
				bpp, 
				flags);
			SdlMixer.Mix_OpenAudio(SdlMixer.MIX_DEFAULT_FREQUENCY, unchecked(Sdl.AUDIO_S16LSB), 2, 1024);
			Smpeg.SMPEG_Info info = new Smpeg.SMPEG_Info();

			string filepath = @"../../";
			if (File.Exists("Data/SdlExamples.SmpegPlayer.mpg"))
			{
				filepath = "";
			}

			//SdlMixer.MixFunctionDelegate audioMixer = new SdlMixer.MixFunctionDelegate(this.player);
			//int freq;
			//short format;
			//int channels;
			SdlMixer.Mix_CloseAudio();
			IntPtr intPtr = Smpeg.SMPEG_new(filepath + "Data/SdlExamples.SmpegPlayer.mpg", out info, 1); 
			//Smpeg.SMPEG_enableaudio(intPtr, 0);
			//SdlMixer.Mix_QuerySpec(out freq, out unchecked(format), out channels);
			//Sdl.SDL_AudioSpec audiofmt = new Tao.Sdl.Sdl.SDL_AudioSpec();
			//audiofmt.freq = freq;
			//audiofmt.format = unchecked(format);
			//audiofmt.channels = (byte) channels;
			//Console.WriteLine("Freq: " + audiofmt.freq);
			//Console.WriteLine("Format: " + audiofmt.format);
			//Console.WriteLine("Channels: " + audiofmt.channels);

			Smpeg.SMPEG_getinfo(intPtr, out info);
			Console.WriteLine("Time: " + info.total_time.ToString());
			Console.WriteLine("Width: " + info.width.ToString());
			Console.WriteLine("Height: " + info.height.ToString());
			Console.WriteLine("Size: " + info.total_size.ToString());
			Console.WriteLine("Smpeg_error: " + Smpeg.SMPEG_error(intPtr));
			
			//Smpeg.SMPEG_actualSpec(intPtr, ref audiofmt); 
			//SdlMixer.Mix_HookMusic(audioMixer, intPtr);
			Smpeg.SMPEG_setdisplay(intPtr, surfacePtr, IntPtr.Zero, null);
			
			Smpeg.SMPEG_play(intPtr);
			//Smpeg.SMPEG_loop(intPtr, 1);
			//Smpeg.SMPEG_enableaudio(intPtr, 1);

			while ((Smpeg.SMPEG_status(intPtr) == Smpeg.SMPEG_PLAYING) &&
				(quitFlag == false))
			{
				Sdl.SDL_PollEvent(out evt);

				if (evt.type == Sdl.SDL_QUIT)
				{
					quitFlag = true;
				}
				else if (evt.type == Sdl.SDL_KEYDOWN)
				{
					if ((evt.key.keysym.sym == (int)Sdl.SDLK_ESCAPE) ||
						(evt.key.keysym.sym == (int)Sdl.SDLK_q))
					{
						quitFlag = true;
					}
				}
			}
			Smpeg.SMPEG_stop(intPtr);
			Smpeg.SMPEG_delete(intPtr);
		} 

//		private void player(IntPtr one, byte[] temp, int len)
//		{
//			//position +=len;
//			IntPtr tempPtr = new IntPtr(one.ToInt32() + position);
//			
//			Marshal.Copy(tempPtr, two, 0, len);
//			Smpeg.SMPEG_playAudio(one, two, len);
//			position +=len;
//		}
		#endregion Run()

		#region Main()
		[STAThread]
		static void Main() 
		{
			SmpegPlayer player = new SmpegPlayer();
			player.Run();
		}
		#endregion Main()
	}
}
