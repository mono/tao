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
using Tao.Sdl;
using System.IO;
using System.Runtime.InteropServices;

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
	public class Rectangles 
	{		
		#region Run()
		/// <summary>
		/// 
		/// </summary>
        [STAThread]
		public static void Run() 
		{
			int flags = (Sdl.SDL_HWSURFACE|Sdl.SDL_DOUBLEBUF|Sdl.SDL_ANYFORMAT);
			int bpp = 16;
			int width = 640;
			int height = 480;
			bool quitFlag = false;

			Random rand = new Random();

            string filePath = Path.Combine("..", "..");
            string fileDirectory = "Data";
            string fileName = "SdlExamples.Rectangles.sound.ogg";
            if (File.Exists(fileName))
            {
                filePath = "";
                fileDirectory = "";
            }
            else if (File.Exists(Path.Combine(fileDirectory, fileName)))
            {
                filePath = "";
            }

            string file = Path.Combine(Path.Combine(filePath, fileDirectory), fileName);

			Sdl.SDL_Event evt;

            try
            {
                Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
                Sdl.SDL_WM_SetCaption("Tao.Sdl Example - Rectangles", "");
                IntPtr surfacePtr = Sdl.SDL_SetVideoMode(
                    width,
                    height,
                    bpp,
                    flags);

                int result = SdlMixer.Mix_OpenAudio(
                    SdlMixer.MIX_DEFAULT_FREQUENCY,
                    (short)SdlMixer.MIX_DEFAULT_FORMAT,
                    2,
                    1024);
                IntPtr chunkPtr = SdlMixer.Mix_LoadMUS(file);

                SdlMixer.MusicFinishedDelegate musicStopped =
                    new SdlMixer.MusicFinishedDelegate(musicHasStopped);
                SdlMixer.Mix_HookMusicFinished(musicStopped);

                result = SdlMixer.Mix_PlayMusic(chunkPtr, 1);
                if (result == -1)
                {
                    Console.WriteLine("Music Error: " + Sdl.SDL_GetError());
                }

                int rmask = 0x00000000;
                int gmask = 0x00ff0000;
                int bmask = 0x0000ff00;
                int amask = 0x000000ff;

                IntPtr rgbSurfacePtr = Sdl.SDL_CreateRGBSurface(
                    flags,
                    width,
                    height,
                    bpp,
                    rmask,
                    gmask,
                    bmask,
                    amask);

                Sdl.SDL_Rect rect = new Sdl.SDL_Rect(
                    0,
                    0,
                    (short)width,
                    (short)height);
                result = Sdl.SDL_FillRect(rgbSurfacePtr, ref rect, 0);

                Sdl.SDL_Rect rect2;

                IntPtr videoInfoPointer = Sdl.SDL_GetVideoInfo();
                if (videoInfoPointer == IntPtr.Zero)
                {
                    throw new ApplicationException(string.Format("Video query failed: {0}", Sdl.SDL_GetError()));
                }

                Sdl.SDL_VideoInfo videoInfo = (Sdl.SDL_VideoInfo)
                    Marshal.PtrToStructure(videoInfoPointer,
                    typeof(Sdl.SDL_VideoInfo));
                Console.WriteLine("Hi There");

                Sdl.SDL_PixelFormat pixelFormat = (Sdl.SDL_PixelFormat)
                    Marshal.PtrToStructure(videoInfo.vfmt,
                    typeof(Sdl.SDL_PixelFormat));

                Console.WriteLine(videoInfo.hw_available);
                Console.WriteLine(videoInfo.wm_available);
                Console.WriteLine(videoInfo.blit_hw);
                Console.WriteLine(videoInfo.blit_hw_CC);
                Console.WriteLine(videoInfo.blit_hw_A);
                Console.WriteLine(videoInfo.blit_sw);
                Console.WriteLine(videoInfo.blit_hw_CC);
                Console.WriteLine(videoInfo.blit_hw_A);
                Console.WriteLine(videoInfo.blit_fill);
                Console.WriteLine(videoInfo.video_mem);
                Console.WriteLine(pixelFormat.BitsPerPixel);
                Console.WriteLine(pixelFormat.BytesPerPixel);
                Console.WriteLine(pixelFormat.Rmask);
                Console.WriteLine(pixelFormat.Gmask);
                Console.WriteLine(pixelFormat.Bmask);
                Console.WriteLine(pixelFormat.Amask);

                int numevents = 10;
                Sdl.SDL_Event[] events = new Sdl.SDL_Event[numevents];
                events[0].type = Sdl.SDL_KEYDOWN;
                events[0].key.keysym.sym = (int)Sdl.SDLK_p;
                events[1].type = Sdl.SDL_KEYDOWN;
                events[1].key.keysym.sym = (int)Sdl.SDLK_z;
                int result2 = Sdl.SDL_PeepEvents(events, numevents, Sdl.SDL_ADDEVENT, Sdl.SDL_KEYDOWNMASK);
                Console.WriteLine("Addevent result: " + result2);

                while (quitFlag == false)
                {
                    result = Sdl.SDL_PollEvent(out evt);

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
                        if (evt.key.keysym.sym == (int)Sdl.SDLK_p)
                        {
                            Console.WriteLine("Key p event was added");
                        }
                        if (evt.key.keysym.sym == (int)Sdl.SDLK_z)
                        {
                            Console.WriteLine("Key z event was added");
                        }
                    }

                    rect2 = new Sdl.SDL_Rect(
                        (short)rand.Next(-300, width),
                        (short)rand.Next(-300, height),
                        (short)rand.Next(20, 300),
                        (short)rand.Next(20, 300));

                    try
                    {
                        result = Sdl.SDL_FillRect(
                            surfacePtr,
                            ref rect2,
                            rand.Next(100000));
                        result = Sdl.SDL_BlitSurface(
                            rgbSurfacePtr,
                            ref rect2,
                            surfacePtr,
                            ref rect);
                        result = Sdl.SDL_Flip(surfacePtr);
                    }
                    catch (Exception) { }
                }
            }
            catch
            {
                Sdl.SDL_Quit();
                throw;
            }
            finally
            {
                Sdl.SDL_Quit();
            }
		}
		#endregion Run()

		private static void musicHasStopped()
		{
			Console.WriteLine("The Music has stopped!");
		}
	}
}
