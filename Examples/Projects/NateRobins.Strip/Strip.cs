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
    strip.c
    Nate Robins, 1997

    A simple program to show how to do a 'swaptmesh' to generate a
    longer triangle strip in OpenGL.
 */
#endregion Original Credits / License

using System;
using Tao.Glut;
using Tao.OpenGl;

namespace NateRobins {
    #region Class Documentation
    /// <summary>
    ///     A simple program to show how to do a 'swaptmesh' to generate a longer triangle
    ///     strip in OpenGL.
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
    public sealed class Strip {
        // --- Fields ---
        #region Private Constants
        private const int MAXMESH = 10;
        private const float PI = 3.1415926f;
        #endregion Private Constants

        #region Private Fields
        private static bool wireframe;
        private static float[ , ] mesh = new float[MAXMESH, MAXMESH];
        private static float oldX, oldY, spinX, spinY;
        #endregion Private Fields

        // --- Entry Point ---
        #region Main(string[] args)
        [STAThread]
        public static void Main(string[] args) {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_RGB | Glut.GLUT_SINGLE);
            Glut.glutInitWindowSize(320, 320);
            Glut.glutInitWindowPosition(50, 50);
            Glut.glutCreateWindow("Strip (Click to draw)");

            for(int k = 0; k < MAXMESH; k++) {
                for(int i = 0; i < MAXMESH; i++) {
                    mesh[k, i] = (float) (Math.Sin((float) (i + k) / MAXMESH * PI) * 3);
                }
            }

            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutMotionFunc(new Glut.MotionCallback(Motion));
            Glut.glutMouseFunc(new Glut.MouseCallback(Mouse));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));

            Glut.glutMainLoop();
        }
        #endregion Main(string[] args)

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            bool swap = false;

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glPushMatrix();
                Gl.glTranslatef(-MAXMESH / 2, 0, -MAXMESH * 2);
                Gl.glRotatef(spinX, 0, 1, 0);
                Gl.glRotatef(spinY, 1, 0, 0);

                Gl.glColor3ub(255, 255, 255);
                Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
                    for(int k = 0; k < MAXMESH - 1; k++) {
                        if(swap) {
                            for(int i = MAXMESH - 1; i >= 0; i--) {
                                Gl.glColor3ub(255, 0, 0);
                                Gl.glVertex3f(i, mesh[k, i], k);
                                Gl.glColor3ub(0, 0, 255);
                                Gl.glVertex3f(i, mesh[k + 1, i], k + 1);
                                if(i == 0) {
                                    Gl.glVertex3f(i, mesh[k + 1, i], k + 1); // degenerate
                                }
                            }
                        }
                        else {
                            for(int i = 0; i < MAXMESH; i++) {
                                Gl.glColor3ub(255, 0, 0);
                                Gl.glVertex3f(i, mesh[k, i], k);
                                Gl.glColor3ub(0, 0, 255);
                                Gl.glVertex3f(i, mesh[k + 1, i], k + 1);
                                if(i == MAXMESH - 1) {
                                    Gl.glVertex3f(i, mesh[k + 1, i], k + 1); // degenerate
                                }
                            }
                        }
                        swap = !swap;
                    }
                Gl.glEnd();
            Gl.glPopMatrix();

            Glut.glutSwapBuffers();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case 27:
                    Environment.Exit(0);
                    break;
                case (byte) 'w':
                case (byte) 'W':
                    wireframe = !wireframe;
                    if(wireframe) {
                        Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_LINE);
                    }
                    else {
                        Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_FILL);
                    }
                    break;
                case (byte) 'c':
                case (byte) 'C':
                    if(Gl.glIsEnabled(Gl.GL_CULL_FACE) == Gl.GL_TRUE) {
                        Gl.glDisable(Gl.GL_CULL_FACE);
                    }
                    else {
                        Gl.glEnable(Gl.GL_CULL_FACE);
                    }
                    break;
                default:
                    break;
            }

            Glut.glutPostRedisplay();
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Motion(int x, int y)
        private static void Motion(int x, int y) {
            spinX = x - oldX;
            spinY = y - oldY;
            Glut.glutPostRedisplay();
        }
        #endregion Motion(int x, int y)

        #region Mouse(int button, int state, int x, int y)
        private static void Mouse(int button, int state, int x, int y) {
            oldX = x;
            oldY = y;
            Glut.glutPostRedisplay();
        }
        #endregion Mouse(int button, int state, int x, int y)

        #region Reshape(int width, int height)
        private static void Reshape(int width, int height) {
            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(60.0, (float) width / (float) height, 0.1, 1000.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0.0, 0.0, 3.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
            Gl.glShadeModel(Gl.GL_FLAT);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_LINE);
        }
        #endregion Reshape(int width, int height)
    }
}
