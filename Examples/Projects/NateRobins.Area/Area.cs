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
    area.c
    Nate Robins, 1997

    A simple program to compute the area of a rasterized triangle.
 */
#endregion Original Credits / License

using System;
using Tao.Glut;
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
    ///         http://www.randyridge.com/Tao/Default.aspx
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Area {
        // --- Entry Point ---
        #region Main(string[] args)
        [STAThread]
        public static void Main(string[] args) {
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
        #endregion Main(string[] args)

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
