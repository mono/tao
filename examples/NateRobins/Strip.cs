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
    strip.c
    Nate Robins, 1997

    A simple program to show how to do a 'swaptmesh' to generate a
    longer triangle strip in OpenGL.
 */
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
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
    ///         http://www.taoframework.com
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
        #region Run()
        [STAThread]
        public static void Run() {
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
        #endregion Run()

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
