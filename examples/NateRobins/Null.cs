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
    null.c
    Nate Robins, 1997

    An example of using null bitmaps to place the rasterpos at
    positions that may be clipped.
 */
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace NateRobins {
    #region Class Documentation
    /// <summary>
    ///     An example of using null bitmaps to place the rasterpos at positions that may be
    ///     clipped.
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
    public sealed class Null {
        // --- Fields ---
        #region Private Fields
        private static byte[] image = new byte[256 * 256 * 3];
        private static byte[] nullImage = null;
        private static byte[] bitmap = {0};
        private static int rasterX = 32;
        private static int rasterY = 32;
        private static int oldRasterX;
        private static int oldRasterY;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            int i, j;

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGBA);
            Glut.glutInitWindowSize(320, 320);
            Glut.glutInitWindowPosition(50, 50);
            Glut.glutCreateWindow("Null");

            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutMotionFunc(new Glut.MotionCallback(Motion));
            Glut.glutMouseFunc(new Glut.MouseCallback(Mouse));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));

            // Create a pretty color ramp
            for(j = 0; j < 256; j++) {
                for(i = 0; i < 256; i++) {
                    image[(256 * j + i) * 3 + 0] = (byte) (255 - i * j / 255);
                    image[(256 * j + i) * 3 + 1] = (byte) i;
                    image[(256 * j + i) * 3 + 2] = (byte) j;
                }
            }

            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glRasterPos2i(0, 0);
            Gl.glBitmap(0, 0, 0, 0, rasterX, rasterY, nullImage);
            Gl.glDrawPixels(256, 256, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, image);

            Glut.glutSwapBuffers();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case 27:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Motion(int x, int y)
        private static void Motion(int x, int y) {
            y = Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT) - y;
            rasterX = x - oldRasterX;
            rasterY = y - oldRasterY;
            Glut.glutPostRedisplay();
        }
        #endregion Motion(int x, int y)

        #region Mouse(int button, int state, int x, int y)
        private static void Mouse(int button, int state, int x, int y) {
            y = Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT) - y;
            oldRasterX = x - rasterX;
            oldRasterY = y - rasterY;
        }
        #endregion Mouse(int button, int state, int x, int y)

        #region Reshape(int width, int height)
        private static void Reshape(int width, int height) {
            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0, width, 0, height, -1, 1);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        #endregion Reshape(int width, int height)
    }
}
