#region License
/*
MIT License
Copyright �2003-2005 Tao Framework Team
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
	public class GfxPrimitives 
	{		
		#region Run()
		/// <summary>
		///  
		/// </summary>
		public void Run() 
		{
			int flags = (Sdl.SDL_HWSURFACE|Sdl.SDL_DOUBLEBUF|Sdl.SDL_ANYFORMAT);
			int bpp = 16;
			int width = 640;
			int height = 480;
			bool quitFlag = false;

			Random rand = new Random();
			
			//string musicFile = "Data/SdlExamples.Reactangles.sound.ogg";

			Sdl.SDL_Event evt;

			try 
			{
				Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
				Sdl.SDL_WM_SetCaption("Tao.Sdl Example - GfxPrimitives", "");
				IntPtr surfacePtr = Sdl.SDL_SetVideoMode(
					width, 
					height, 
					bpp, 
					flags);

				Sdl.SDL_Rect rect2 = 
					new Sdl.SDL_Rect(0,0, (short) width, (short) height);
				Sdl.SDL_SetClipRect(surfacePtr, ref rect2);
				while (quitFlag == false) 
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

					try 
					{
						SdlGfx.filledCircleRGBA(surfacePtr, (short)rand.Next(10,width - 100),(short)rand.Next(10, height - 100), (short)rand.Next(10,100),(byte)rand.Next(255), (byte)rand.Next(255),(byte)rand.Next(255), (byte)rand.Next(255));
						Sdl.SDL_Flip(surfacePtr);
						Thread.Sleep(100);
					} 
					catch (Exception) {}
				}
			} 
			catch 
			{
				Sdl.SDL_Quit();
				throw; 
			}
		}
		#endregion Run()

		#region Main()
		[STAThread]
		static void Main() 
		{
			GfxPrimitives gfxPrimitives = new GfxPrimitives();
			gfxPrimitives.Run();
		}
		#endregion Main()
	}
}
