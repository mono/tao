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

#region Original Credits / License
/* 
    starfield.c
    Nate Robins, 1997

    An example of starfields in OpenGL.
 */
#endregion Original Credits / License

using System;
using Tao.Glut;
using Tao.OpenGl;

namespace NateRobins {
    #region Class Documentation
    /// <summary>
    ///     An example of starfields in OpenGL.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Nate Robins
    ///         http://www.xmission.com/~nate/sgi.html
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.randyridge.com/Tao/Default.aspx
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Starfield {
        // --- Fields ---
        #region Private Constants
        private const int RANDOMMAX = 0x7fff;
        #endregion Private Constants

        #region Private Fields
        private static bool screensaver = false;
        private static int beenHere = 0;
        private static int numberStars = 150;
        private static Star[] stars;
        private static Random random = new Random();
        #endregion Private Fields

        #region Private Structs
        private struct Star {
            public float X;
            public float Y;
            public float VX;
            public float VY;
        }
        #endregion Private Structs

        // --- Entry Point ---
        #region Main(string[] args)
        [STAThread]
        public static void Main(string[] args) {
            try {
                if(args.Length > 1) {
                    if(args[1] == "-h") {
                        Console.WriteLine(args[0] + " [stars]");
                        Environment.Exit(0);
                    }
                    else {
                        numberStars = Int32.Parse(args[1]);
                    }
                }
            }
            catch(Exception e) {
                Console.WriteLine("Error parsing commandline.  stars should be an integer.  Try again.\n\n" + e.ToString());
                Environment.Exit(-1);
            }

            stars = new Star[numberStars];

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGBA);
            Glut.glutInitWindowSize(320, 320);
            Glut.glutInitWindowPosition(50, 50);
            Glut.glutCreateWindow("Starfield");

            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutIdleFunc(new Glut.IdleCallback(Idle));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));

            if(screensaver) {
                FullscreenMode();
            }
            else {
                WindowedMode();
            }

            Glut.glutMainLoop();
        }
        #endregion Main(string[] args)

        // --- Application Methods ---
        #region Bail(int code)
        private static void Bail(int code) {
            stars = null;
            Environment.Exit(code);
        }
        #endregion Bail(int code)

        #region FullscreenMode()
        private static void FullscreenMode() {
            int oldX = 50;
            int oldY = 50;
            int oldWidth = 320;
            int oldHeight = 320;

            if(screensaver) {
                Glut.glutKeyboardFunc(new Glut.KeyboardCallback(ScreensaverKeyboard));
                Glut.glutPassiveMotionFunc(new Glut.PassiveMotionCallback(ScreensaverPassive));
                Glut.glutMouseFunc(new Glut.MouseCallback(ScreensaverMouse));
            }
            else {
                Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            }
            Glut.glutSetCursor(Glut.GLUT_CURSOR_NONE);

            oldX = Glut.glutGet(Glut.GLUT_WINDOW_X);
            oldY = Glut.glutGet(Glut.GLUT_WINDOW_Y);
            oldWidth = Glut.glutGet(Glut.GLUT_WINDOW_WIDTH);
            oldHeight = Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT);

            Glut.glutFullScreen();
        }
        #endregion FullscreenMode()

        #region WindowedMode()
        private static void WindowedMode() {
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutPassiveMotionFunc(null);
            Glut.glutMouseFunc(null);
            Glut.glutSetCursor(Glut.GLUT_CURSOR_INHERIT);
            Glut.glutPositionWindow(50, 50);
            Glut.glutReshapeWindow(320, 320);
        }
        #endregion WindowedMode()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            int i;

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            for(i = 0; i < numberStars; i++) {
                stars[i].X += stars[i].VX;
                if(stars[i].X < Glut.glutGet(Glut.GLUT_WINDOW_WIDTH)) {
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                        Gl.glColor3ub(0, 0, 0);
                        Gl.glVertex2i((int) (stars[i].X - stars[i].VX * 4), (int) stars[i].Y);
                        Gl.glColor3ub(255, 255, 255);
                        Gl.glVertex2i((int) stars[i].X, (int) stars[i].Y);
                    Gl.glEnd();
                } else {
                    stars[i].X = 0;
                }
            }
    
            Glut.glutSwapBuffers();
        }
        #endregion Display()

        #region Idle()
        private static void Idle() {
            Glut.glutPostRedisplay();
        }
        #endregion Idle()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case 27:
                    Bail(0);
                    break;
                case (byte) 'w':
                case (byte) 'W':
                    WindowedMode();
                    break;
                case (byte) 'f':
                case (byte) 'F':
                    FullscreenMode();
                    break;
                default:
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Reshape(int width, int height)
        private static void Reshape(int width, int height) {
            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0.0, width, 0.0, height, -1.0, 1.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glColor3ub(255, 255, 255);

            for(int i = 0; i < numberStars; i++) {
                stars[i].X = random.Next(RANDOMMAX) % width;
                stars[i].Y = random.Next(RANDOMMAX) % height;
                stars[i].VX = random.Next(RANDOMMAX) / (float) RANDOMMAX * 5 + 2;
                stars[i].VY = 0;
            }
        }
        #endregion Reshape(int width, int height)

        #region ScreensaverKeyboard(byte key, int x, int y)
        private static void ScreensaverKeyboard(byte key, int x, int y) {
            Bail(0);
        }
        #endregion ScreensaverKeyboard(byte key, int x, int y)

        #region ScreensaverMouse(int button, int state, int x, int y)
        private static void ScreensaverMouse(int button, int state, int x, int y) {
            Bail(0);
        }
        #endregion ScreensaverMouse(int button, int state, int x, int y)

        #region ScreensaverPassive(int x, int y)
        private static void ScreensaverPassive(int x, int y) {
            // For some reason, GLUT sends an initial passive motion callback when a window is
            // initialized, so this would immediately terminate the program.  To get around this,
            // see if we've been here before.  (Actually if we've been here twice.)
            if(beenHere > 1) {
                Bail(0);
            }
            beenHere++;
        }
        #endregion ScreensaverPassive(int x, int y)
    }
}
