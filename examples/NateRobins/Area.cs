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
    area.c
    Nate Robins, 1997

    A simple program to compute the area of a rasterized triangle.
 */
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace NateRobins {
    #region Class Documentation
    /// <summary>
    ///     A simple program to compute the area of a rasterized triangle.
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
    public sealed class Area {
        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_SINGLE);
            Glut.glutInitWindowSize(320, 320);
            Glut.glutInitWindowPosition(50, 50);
            Glut.glutCreateWindow("Area");
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region int GetArea()
        private static int GetArea() {
            float[] buffer = new float[8];
            int i, n, size;
            float a = 0.0f;

            Gl.glFeedbackBuffer(8, Gl.GL_2D, buffer);
            Gl.glRenderMode(Gl.GL_FEEDBACK);
            Draw();
            size = Gl.glRenderMode(Gl.GL_RENDER);

            i = 0;
            while(i < size) {
                if(buffer[i] == Gl.GL_POLYGON_TOKEN) {
                    i++;
                    n = (int) buffer[i];
                    i++;

                    // z component of cross product = twice triangle area, if area is negative,
                    // the triangle is backfacing
                    a = ((buffer[i + 2] - buffer[i + 0]) * (buffer[i + 5] - buffer[i + 1]) - (buffer[i + 4] - buffer[i + 0]) * (buffer[i + 3] - buffer[i + 1])) / 2;
                    i += n * 2;
                }
                else {
                    Console.WriteLine("Unknown token 0x{0} parsed at {1}.", (short) buffer[i], i);
                    i++;
                }
            }

            return (int) a;
        }
        #endregion int GetArea()

        #region Draw()
        private static void Draw() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glColor3ub(255, 255, 255);
            Gl.glBegin(Gl.GL_TRIANGLES);
                Gl.glNormal3f(0.0f, 0.0f, 1.0f);
                Gl.glColor3ub(255, 0, 0);
                Gl.glVertex2i(1, 2);
                Gl.glColor3ub(0, 255, 0);
                Gl.glVertex2i(0, 0);
                Gl.glColor3ub(0, 0, 255);
                Gl.glVertex2i(2, 0);
            Gl.glEnd();

            Glut.glutSwapBuffers();
        }
        #endregion Draw()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Draw();
            Console.WriteLine("Feedback triangle area = {0} pixels.", GetArea());
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

        #region Reshape(int width, int height)
        private static void Reshape(int width, int height) {
            Console.WriteLine("Width = {0}, Height = {1}, Area / 2 = {2}", width, height, width * height / 2);
            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0, 2, 0, 2, -1, 1);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
        }
        #endregion Reshape(int width, int height)
    }
}
