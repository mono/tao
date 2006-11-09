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

/*
 * 3-D gear wheels.  This program is in the public domain.
 *
 * Command line options:
 *    -info      print GL implementation information
 *    -exit      automatically exit after 30 seconds
 *
 *
 * Brian Paul
 *
 *
 * Marcus Geelnard:
 *   - Conversion to GLFW
 *   - Time based rendering (frame rate independent)
 *   - Slightly modified camera that should work better for stereo viewing
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
    ///     Classic gears.
    /// </remarks>
    #endregion Class Documentation
    public sealed class Gears {
        // --- Fields ---
        #region Private Constants
        private const float PI = 3.141592654f;
        #endregion Private Constants

        #region Private Static Fields
        private static bool isRunning = true;
        private static double currentTime = 0;
        private static double oldTime = 0;
        private static double timeDifference = 0;
        private static int frameCount;
        private static int autoExit = 0;
        private static float[] lightPosition = new float[] {5, 5, 10, 0};
        private static float[] redMaterial = new float[] {0.8f, 0.1f, 0, 1};
        private static float[] greenMaterial = new float[] {0, 0.8f, 0.2f, 1};
        private static float[] blueMaterial = new float[] {0.2f, 0.2f, 1, 1};
        private static float rotateX = 20, rotateY = 30, rotateZ = 0;
        private static int gear1, gear2, gear3;
        private static float angle = 0;
        #endregion Private Static Fields

        // --- Application Entry Point ---
        #region Run()
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Run() {
            // Initialise GLFW and open window
            Glfw.glfwInit();
            if(Glfw.glfwOpenWindow(300, 300, 0, 0, 0, 0, 0, 0, Glfw.GLFW_WINDOW) == Gl.GL_FALSE) {
                Glfw.glfwTerminate();
                return;
            }
            Glfw.glfwSetWindowTitle("Gears");
            Glfw.glfwEnable(Glfw.GLFW_KEY_REPEAT);
            Glfw.glfwSwapInterval(0);

            Init();

            // Set callback functions
            Glfw.glfwSetWindowSizeCallback(new Glfw.GLFWwindowsizefun(Reshape));
            Glfw.glfwSetKeyCallback(new Glfw.GLFWkeyfun(Key));

            // Main loop
            while(isRunning) {
                // Draw gears
                Draw();

                // Update animation
                Animate();

                // Swap Buffers
                Glfw.glfwSwapBuffers();

                if(Glfw.glfwGetWindowParam(Glfw.GLFW_OPENED) == Gl.GL_FALSE) {
                    isRunning = false;
                }
            }

            // Close OpenGL window and terminate GLFW
            Glfw.glfwTerminate();
        }
        #endregion Run()

        // --- Private Static Methods ---
        #region Animate()
        /// <summary>
        ///     Updates animation parameters.
        /// </summary>
        private static void Animate() {
            angle += 100 * (float) timeDifference;
        }
        #endregion Animate()

        #region Draw()
        /// <summary>
        ///     OpenGL draw function and timing.
        /// </summary>
        private static void Draw() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glPushMatrix();
                Gl.glRotatef(rotateX, 1, 0, 0);
                Gl.glRotatef(rotateY, 0, 1, 0);
                Gl.glRotatef(rotateZ, 0, 0, 1);

                Gl.glPushMatrix();
                    Gl.glTranslatef(-3, -2, 0);
                    Gl.glRotatef(angle, 0, 0, 1);
                    Gl.glCallList(gear1);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                    Gl.glTranslatef(3.1f, -2, 0);
                    Gl.glRotatef(-2 * angle - 9, 0, 0, 1);
                    Gl.glCallList(gear2);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                    Gl.glTranslatef(-3.1f, 4.2f, 0);
                    Gl.glRotatef(-2 * angle - 25, 0, 0, 1);
                    Gl.glCallList(gear3);
                Gl.glPopMatrix();
            Gl.glPopMatrix();

            frameCount++;

            double newTime = Glfw.glfwGetTime();
            timeDifference = newTime - currentTime;
            currentTime = newTime;

            if(currentTime  - oldTime >= 5.0) {
                double seconds = currentTime - oldTime;
                double fps = frameCount / seconds;
                Console.WriteLine("{0} frames in {1} seconds = {2} FPS", frameCount, seconds, fps);
                oldTime = currentTime;
                frameCount = 0;
                if((currentTime >= 0.999 * autoExit) && (autoExit > 0)) {
                    isRunning = false;
                }
            }
        }
        #endregion Draw()

        #region Gear(float innerRadius, float outerRadius, float width, float teeth, float toothDepth)
        private static void Gear(float innerRadius, float outerRadius, float width, float teeth, float toothDepth) {
            int i;
            float r0, r1, r2;
            float angle, da;
            float u, v, len;

            r0 = innerRadius;
            r1 = outerRadius - toothDepth / 2;
            r2 = outerRadius + toothDepth / 2;

            da = 2 * PI / teeth / 4;

            Gl.glShadeModel(Gl.GL_FLAT);

            Gl.glNormal3f(0, 0, 1);

            // draw front face
            Gl.glBegin(Gl.GL_QUAD_STRIP);
                for(i = 0; i <= teeth; i++) {
                    angle = i * 2 * PI / teeth;
                    Gl.glVertex3f(r0 * (float) Math.Cos(angle), r0 * (float) Math.Sin(angle), width * 0.5f);
                    Gl.glVertex3f(r1 * (float) Math.Cos(angle), r1 * (float) Math.Sin(angle), width * 0.5f);
                    if(i < teeth) {
                        Gl.glVertex3f(r0 * (float) Math.Cos(angle), r0 * (float) Math.Sin(angle), width * 0.5f);
                        Gl.glVertex3f(r1 * (float) Math.Cos(angle + 3 * da), r1 * (float) Math.Sin(angle + 3 * da), width * 0.5f);
                    }
                }
            Gl.glEnd();

            // draw front sides of teeth
            Gl.glBegin(Gl.GL_QUADS);
                da = 2 * PI / teeth / 4;
                for(i = 0; i < teeth; i++) {
                    angle = i * 2 * PI / teeth;
                    Gl.glVertex3f(r1 * (float) Math.Cos(angle), r1 * (float) Math.Sin(angle), width * 0.5f);
                    Gl.glVertex3f(r2 * (float) Math.Cos(angle + da), r2 * (float) Math.Sin(angle + da), width * 0.5f);
                    Gl.glVertex3f(r2 * (float) Math.Cos(angle + 2 * da), r2 * (float) Math.Sin(angle + 2 * da), width * 0.5f);
                    Gl.glVertex3f(r1 * (float) Math.Cos(angle + 3 * da), r1 * (float) Math.Sin(angle + 3 * da), width * 0.5f);
                }
            Gl.glEnd();

            Gl.glNormal3f(0, 0, -1);

            // draw back face
            Gl.glBegin(Gl.GL_QUAD_STRIP);
                for(i = 0; i <= teeth; i++) {
                    angle = i * 2 * PI / teeth;
                    Gl.glVertex3f(r1 * (float) Math.Cos(angle), r1 * (float) Math.Sin(angle), -width * 0.5f);
                    Gl.glVertex3f(r0 * (float) Math.Cos(angle), r0 * (float) Math.Sin(angle), -width * 0.5f);
                    if(i < teeth) {
                        Gl.glVertex3f(r1 * (float) Math.Cos(angle + 3 * da), r1 * (float) Math.Sin(angle + 3 * da), -width * 0.5f);
                        Gl.glVertex3f(r0 * (float) Math.Cos(angle), r0 * (float) Math.Sin(angle), -width * 0.5f);
                    }
                }
            Gl.glEnd();

            // draw back sides of teeth
            Gl.glBegin(Gl.GL_QUADS);
                da = 2 * PI / teeth / 4;
                for(i = 0; i < teeth; i++) {
                    angle = i * 2 * PI / teeth;
                    Gl.glVertex3f(r1 * (float) Math.Cos(angle + 3 * da), r1 * (float) Math.Sin(angle + 3 * da), -width * 0.5f);
                    Gl.glVertex3f(r2 * (float) Math.Cos(angle + 2 * da), r2 * (float) Math.Sin(angle + 2 * da), -width * 0.5f);
                    Gl.glVertex3f(r2 * (float) Math.Cos(angle + da), r2 * (float) Math.Sin(angle + da), -width * 0.5f);
                    Gl.glVertex3f(r1 * (float) Math.Cos(angle), r1 * (float) Math.Sin(angle), -width * 0.5f);
                }
            Gl.glEnd();

            // draw outward faces of teeth
            Gl.glBegin(Gl.GL_QUAD_STRIP);
                for(i = 0; i < teeth; i++) {
                    angle = i * 2 * PI / teeth;
                    Gl.glVertex3f(r1 * (float) Math.Cos(angle), r1 * (float) Math.Sin(angle), width * 0.5f);
                    Gl.glVertex3f(r1 * (float) Math.Cos(angle), r1 * (float) Math.Sin(angle), -width * 0.5f);
                    u = r2 * (float) Math.Cos(angle + da) - r1 * (float) Math.Cos(angle);
                    v = r2 * (float) Math.Sin(angle + da) - r1 * (float) Math.Sin(angle);
                    len = (float) Math.Sqrt(u * u + v * v);
                    u /= len;
                    v /= len;
                    Gl.glNormal3f(v, -u, 0);
                    Gl.glVertex3f(r2 * (float) Math.Cos(angle + da), r2 * (float) Math.Sin(angle + da), width * 0.5f);
                    Gl.glVertex3f(r2 * (float) Math.Cos(angle + da), r2 * (float) Math.Sin(angle + da), -width * 0.5f);
                    Gl.glNormal3f((float) Math.Cos(angle), (float) Math.Sin(angle), 0);
                    Gl.glVertex3f(r2 * (float) Math.Cos(angle + 2 * da), r2 * (float) Math.Sin(angle + 2 * da), width * 0.5f);
                    Gl.glVertex3f(r2 * (float) Math.Cos(angle + 2 * da), r2 * (float) Math.Sin(angle + 2 * da), -width * 0.5f);
                    u = r1 * (float) Math.Cos(angle + 3 * da) - r2 * (float) Math.Cos(angle + 2 * da);
                    v = r1 * (float) Math.Sin(angle + 3 * da) - r2 * (float) Math.Sin(angle + 2 * da);
                    Gl.glNormal3f(v, -u, 0);
                    Gl.glVertex3f(r1 * (float) Math.Cos(angle + 3 * da), r1 * (float) Math.Sin(angle + 3 * da), width * 0.5f);
                    Gl.glVertex3f(r1 * (float) Math.Cos(angle + 3 * da), r1 * (float) Math.Sin(angle + 3 * da), -width * 0.5f);
                    Gl.glNormal3f((float) Math.Cos(angle), (float) Math.Sin(angle), 0);
                }

                Gl.glVertex3f(r1 * (float) Math.Cos(0), r1 * (float) Math.Sin(0), width * 0.5f);
                Gl.glVertex3f(r1 * (float) Math.Cos(0), r1 * (float) Math.Sin(0), -width * 0.5f);
            Gl.glEnd();

            Gl.glShadeModel(Gl.GL_SMOOTH);

            // draw inside radius cylinder
            Gl.glBegin(Gl.GL_QUAD_STRIP);
                for(i = 0; i <= teeth; i++) {
                    angle = i * 2 * PI / teeth;
                    Gl.glNormal3f((float) -Math.Cos(angle), (float) -Math.Sin(angle), 0);
                    Gl.glVertex3f(r0 * (float) Math.Cos(angle), r0 * (float) Math.Sin(angle), -width * 0.5f);
                    Gl.glVertex3f(r0 * (float) Math.Cos(angle), r0 * (float) Math.Sin(angle), width * 0.5f);
                }
            Gl.glEnd();
        }
        #endregion Gear(float innerRadius, float outerRadius, float width, float teeth, float toothDepth)

        #region Init()
        /// <summary>
        ///     Performs program and OpenGL initialization.
        /// </summary>
        /// <param name="arguments">
        ///     The command line arguments.
        /// </param>
        private static void Init() {
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPosition);
            Gl.glEnable(Gl.GL_CULL_FACE);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            // make the gears
            gear1 = Gl.glGenLists(1);
            Gl.glNewList(gear1, Gl.GL_COMPILE);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE, redMaterial);
                Gear(1, 4, 1, 20, 0.7f);
            Gl.glEndList();

            gear2 = Gl.glGenLists(1);
            Gl.glNewList(gear2, Gl.GL_COMPILE);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE, greenMaterial);
                Gear(0.5f, 2, 2, 10, 0.7f);
            Gl.glEndList();

            gear3 = Gl.glGenLists(1);
            Gl.glNewList(gear3, Gl.GL_COMPILE);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE, blueMaterial);
                Gear(1.3f, 2, 0.5f, 10, 0.7f);
            Gl.glEndList();

            Gl.glEnable(Gl.GL_NORMALIZE);

            //for(int i = 0; i < arguments.Length; i++) {
            //    if(arguments[i] == "-info") {
            //        Console.WriteLine("GL_RENDERER   = {0}", Gl.glGetString(Gl.GL_RENDERER));
            //        Console.WriteLine("GL_VERSION    = {0}", Gl.glGetString(Gl.GL_VERSION));
            //        Console.WriteLine("GL_VENDOR     = {0}", Gl.glGetString(Gl.GL_VENDOR));
            //        Console.WriteLine("GL_EXTENSIONS = {0}", Gl.glGetString(Gl.GL_EXTENSIONS));
            //    }
            //    else if(arguments[i] == "-exit") {
            //        autoExit = 30;
            //        Console.WriteLine("Auto Exit after {0} seconds.", autoExit);
            //    }
            //}
        }
        #endregion Init()

        // --- Private GLFW Callback Methods ---
        #region Key(int key, int action)
        /// <summary>
        ///     Changes view angle, exits the app.
        /// </summary>
        /// <param name="key">
        ///     The key.
        /// </param>
        /// <param name="action">
        ///     The key action.
        /// </param>
        private static void Key(int key, int action) {
            if(action != Glfw.GLFW_PRESS) {
                return;
            }

            switch(key) {
                case (int) 'Z':
                    if(Glfw.glfwGetKey(Glfw.GLFW_KEY_LSHIFT) == Gl.GL_TRUE) {
                        rotateZ -= 5;
                    }
                    else {
                        rotateZ += 5;
                    }
                    break;
                case Glfw.GLFW_KEY_ESC:
                    isRunning = false;
                    break;
                case Glfw.GLFW_KEY_UP:
                    rotateX += 5;
                    break;
                case Glfw.GLFW_KEY_DOWN:
                    rotateX -= 5;
                    break;
                case Glfw.GLFW_KEY_LEFT:
                    rotateY += 5;
                    break;
                case Glfw.GLFW_KEY_RIGHT:
                    rotateY -= 5;
                    break;
                default:
                    return;
            }
        }
        #endregion Key(int key, int action)

        #region Reshape(int width, int height)
        /// <summary>
        ///     Reshape callback.
        /// </summary>
        /// <param name="width">
        ///     The window width.
        /// </param>
        /// <param name="height">
        ///     The window height.
        /// </param>
        private static void Reshape(int width, int height) {
            float h = (float) height / (float) width;
            float xMax, zNear, zFar;

            zNear = 5;
            zFar  = 30;
            xMax  = zNear * 0.5f;

            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glFrustum(-xMax, xMax, -xMax * h, xMax * h, zNear, zFar);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glTranslatef(0, 0, -20);
        }
        #endregion Reshape(int width, int height)
    }
}
