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
    ///     The program opens a window (640x480), and renders a spinning colored triangle (it
    ///     is controlled with both the GLFW timer and the mouse).  It also calculates the
    ///     rendering speed (FPS), which is displayed in the window title bar.
    /// </remarks>
    #endregion Class Documentation
    public sealed class Triangle {
        // --- Application Entry Point ---
        #region Run()
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Run() {
            int windowWidth, windowHeight;
            int mouseX, mouseY;
            bool isRunning;
            double currentTime, startTime, frameRate;
            int frameCount;

            // Initialise GLFW
            Glfw.glfwInit();

            // Open OpenGL window
            if(Glfw.glfwOpenWindow(640, 480, 0, 0, 0, 0, 0, 0, Glfw.GLFW_WINDOW) == Gl.GL_FALSE) {
                Glfw.glfwTerminate();
                return;
            }

            // Enable sticky keys
            Glfw.glfwEnable(Glfw.GLFW_STICKY_KEYS);

            // Disable vertical sync (on cards that support it)
            Glfw.glfwSwapInterval(0);

            // Main loop
            isRunning = true;
            frameCount = 0;
            startTime = Glfw.glfwGetTime();

            while(isRunning) {
                // Get time and mouse position
                currentTime = Glfw.glfwGetTime();
                Glfw.glfwGetMousePos(out mouseX, out mouseY);

                // Calculate and display FPS (frames per second)
                if((currentTime - startTime) > 1.0 || frameCount == 0) {
                    frameRate = frameCount / (currentTime - startTime);
                    Glfw.glfwSetWindowTitle(string.Format("Spinning Triangle ({0:0} FPS)",
                        frameRate));
                    startTime = currentTime;
                    frameCount = 0;
                }

                frameCount++;

                // Get window size (may be different than the requested size)
                Glfw.glfwGetWindowSize(out windowWidth, out windowHeight);
                windowHeight = windowHeight > 0 ? windowHeight : 1;

                // Set viewport
                Gl.glViewport(0, 0, windowWidth, windowHeight);

                // Clear color buffer
                Gl.glClearColor(0, 0, 0, 0);
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

                // Select and setup the projection matrix
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();
                Glu.gluPerspective(65, windowWidth / (double) windowHeight, 1, 100);

                // Select and setup the modelview matrix
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glLoadIdentity();
                Glu.gluLookAt(0, 1, 0,  // Eye-position
                    0, 20, 0,           // View-point
                    0, 0, 1);           // Up-vector

                // Draw a rotating colorful triangle
                Gl.glTranslatef(0, 14, 0);
                Gl.glRotatef(0.3f * (float) mouseX + (float) currentTime * 100, 0, 0, 1);
                Gl.glBegin(Gl.GL_TRIANGLES);
                    Gl.glColor3f(1, 0, 0);
                    Gl.glVertex3f(-5, 0, -4);
                    Gl.glColor3f(0, 1, 0);
                    Gl.glVertex3f(5, 0, -4);
                    Gl.glColor3f(0, 0, 1);
                    Gl.glVertex3f(0, 0, 6);
                Gl.glEnd();

                // Swap buffers
                Glfw.glfwSwapBuffers();

                // Check if the ESC key was pressed or the window was closed
                isRunning = ((Glfw.glfwGetKey(Glfw.GLFW_KEY_ESC) == Glfw.GLFW_RELEASE) &&
                    Glfw.glfwGetWindowParam(Glfw.GLFW_OPENED) == Gl.GL_TRUE);
            }

            // Close OpenGL window and terminate GLFW
            Glfw.glfwTerminate();
        }
        #endregion Run()
    }
}
