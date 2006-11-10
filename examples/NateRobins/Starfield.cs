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
/* 
    starfield.c
    Nate Robins, 1997

    An example of starfields in OpenGL.
 */
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
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
    ///         http://www.taoframework.com
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
        #region Run()
        [STAThread]
        public static void Run() 
        {
            try 
            {
                //if(args.Length > 1) 
                //{
                //    if(args[1] == "-h") {
                //        Console.WriteLine(args[0] + " [stars]");
                //        Environment.Exit(0);
                //    }
                //    else {
                //        numberStars = Int32.Parse(args[1]);
                //    }
                //}
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
        #endregion Run()

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
