#region License
/*
BSD License
Copyright ©2003-2004 Randy Ridge
http://www.randyridge.com/Tao/Default.aspx
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

1. Redistributions of source code must retain the above copyright notice,
   this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither Randy Ridge nor the names of any Tao contributors may be used to
   endorse or promote products derived from this software without specific
   prior written permission.

   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
   "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
   LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
   FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
   COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
   INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
   BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
   LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
   CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
   LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
   ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
   POSSIBILITY OF SUCH DAMAGE.
*/
#endregion License

#region Original Credits/License
/*
Copyright (c) 2002-2004 Marcus Geelnard

This software is provided 'as-is', without any express or implied
warranty. In no event will the authors be held liable for any damages
arising from the use of this software.

Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it
freely, subject to the following restrictions:

1. The origin of this software must not be misrepresented; you must not
   claim that you wrote the original software. If you use this software
   in a product, an acknowledgment in the product documentation would
   be appreciated but is not required.

2. Altered source versions must be plainly marked as such, and must not
   be misrepresented as being the original software.

3. This notice may not be removed or altered from any source
   distribution.

Marcus Geelnard
marcus.geelnard at home.se
*/
#endregion Original Credits/License

using System;
using Tao.Glfw;
using Tao.OpenGl;

namespace GlfwExamples {
    #region Class Documentation
    /// <summary>
    ///     This is a small test application for GLFW.
    /// </summary>
    /// <remarks>
    ///     The program lists all available fullscreen video modes.
    /// </remarks>
    #endregion Class Documentation
    public sealed class ListModes {
        // --- Fields ---
        #region Private Constants
        // Maximum number of modes that we want to list
        private const int MAX_NUMBER_OF_MODES = 400;
        #endregion Private Constants

        // --- Application Entry Point ---
        #region Main(string[] args)
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args) {
            Glfw.GLFWvidmode desktopMode;
            Glfw.GLFWvidmode[] availableModes = new Glfw.GLFWvidmode[MAX_NUMBER_OF_MODES];
            int modeCount;

            // Initialize GLFW
            if(Glfw.glfwInit() == Gl.GL_FALSE) {
                return;
            }

            // Show desktop video mode
            Glfw.glfwGetDesktopMode(out desktopMode);
            Console.WriteLine("Desktop mode: {0} x {1} x {2}", desktopMode.Width,
                desktopMode.Height, desktopMode.RedBits + desktopMode.GreenBits +
                desktopMode.BlueBits);

            // List available video modes
            modeCount = Glfw.glfwGetVideoModes(availableModes, MAX_NUMBER_OF_MODES);
            Console.WriteLine("Available modes:");
            for(int i = 0; i < modeCount; i++) {
                Console.WriteLine("{0}: {1} x {2} x {3}", i, availableModes[i].Width,
                    availableModes[i].Height, availableModes[i].RedBits +
                    availableModes[i].GreenBits + availableModes[i].BlueBits);
            }

            // Terminate GLFW
            Glfw.glfwTerminate();

            Console.Write("\n\nPress Enter to exit...");
            Console.ReadLine();
        }
        #endregion Main(string[] args)
    }
}
