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
    rotate.c
    Nate Robins, 1997

    An example of rotating a bitmap (w/o OpenGL's help).
 */
#endregion Original Credits / License

using System;
using Tao.Glut;
using Tao.OpenGl;

namespace NateRobins {
    #region Class Documentation
    /// <summary>
    ///     An example of rotating a bitmap (w/o OpenGL's help).
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
    public sealed class Rotate {
        // --- Fields ---
        #region Private Fields
        private static float theta = 0.0f;
        private static int isize;
        private static int width, height;
        private static byte[] image;
        #endregion Private Fields

        // --- Entry Point ---
        #region Main(string[] args)
        [STAThread]
        public static void Main(string[] args) {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(256, 256);
            Glut.glutInitWindowPosition(50, 50);
            Glut.glutCreateWindow("Rotate");

            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutIdleFunc(new Glut.IdleCallback(Idle));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
        #endregion Main(string[] args)

        // --- Application Methods ---
        #region float DegreeToRadian(float degree)
        private static float DegreeToRadian(float degree) {
            return (float) (degree * 3.14159265 / 180.0);
        }
        #endregion float DegreeToRadian(float degree)

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            int x, y;
            int i, j;
            float minX, minY, maxX, maxY;
            float isize2, tmp0, tmp1, tmp2, tmp3;
            float sinTheta, cosTheta;

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            isize2 = (float) isize / 2;
            sinTheta = (float) Math.Sin(DegreeToRadian(theta));
            cosTheta = (float) Math.Cos(DegreeToRadian(theta));

            // Rotate the corners of the image to get the bounding box of the rotated image
            tmp0 = -isize2 * cosTheta - -isize2 * sinTheta;
            tmp1 =  isize2 * cosTheta - -isize2 * sinTheta;
            tmp2 =  isize2 * cosTheta - isize2 * sinTheta;
            tmp3 = -isize2 * cosTheta - isize2 * sinTheta;
            minX = (float) (Math.Min(tmp0, Math.Min(tmp1, Math.Min(tmp2, tmp3))));
            maxX = (float) (Math.Max(tmp0, Math.Max(tmp1, Math.Max(tmp2, tmp3))));

            tmp0 = -isize2 * sinTheta + -isize2 * cosTheta;
            tmp1 =  isize2 * sinTheta + -isize2 * cosTheta;
            tmp2 =  isize2 * sinTheta +  isize2 * cosTheta;
            tmp3 = -isize2 * sinTheta +  isize2 * cosTheta;
            minY = (float) (Math.Min(tmp0, Math.Min(tmp1, Math.Min(tmp2, tmp3))));
            maxY = (float) (Math.Max(tmp0, Math.Max(tmp1, Math.Max(tmp2, tmp3))));

            Gl.glBegin(Gl.GL_POINTS);
                for(j = (int) minY; j < maxY; j++) {
                    for(i = (int) minX; i < maxX; i++) {
                        // Calculate the sample point
                        x = (int) ((i * cosTheta - j * sinTheta) + isize2);
                        y = (int) ((i * sinTheta + j * cosTheta) + isize2);

                        // Skip out if we're going to sample outside the bitmap
                        if(x < 0 || x >= isize || y < 0 || y >= isize) {
                            continue;
                        }

                        Gl.glColor3ub(image[(isize * y + x) * 3 + 0], image[(isize * y + x) * 3 + 1], image[(isize * y + x) * 3 + 2]);
                        Gl.glVertex2i(width / 2 + i, width / 2 + j);
                    }
                }
            Gl.glEnd();

            theta += 6.0f;
            if(theta > 360.0f) {
                theta -= 360.0f;
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
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            width = w;
            height = h;
            isize = width > height ? width / 2 : height / 2;

            image = new byte[isize * isize * 3];

            // Create a pretty color ramp
            for(int j = 0; j < isize; j++) {
                for(int i = 0; i < isize; i++) {
                    image[(isize * j + i) * 3 + 0] = (byte) (255 - (i * j / 255 * 255 / isize));
                    image[(isize * j + i) * 3 + 1] = (byte) (i * 256 / isize);
                    image[(isize * j + i) * 3 + 2] = (byte) (j * 256 / isize);
                }
            }

            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0, width, 0, height, -1, 1);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        #endregion Reshape(int w, int h)
    }
}
