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
    nii.c
    Nate Robins, 1997

    Network Integration Incorporated logo.
 */
#endregion Original Credits / License

using System;
using Tao.Glut;
using Tao.OpenGl;

namespace NateRobins {
    #region Class Documentation
    /// <summary>
    ///     Network Integration Incorporated logo.
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
    public sealed class Nii {
        // --- Fields ---
        #region Private Fields
        private static float spinX = -30.0f;
        private static float spinY = 25.0f;
        private static float spinC = 0.0f;
        private static int oldX;
        private static int oldY;
        private static bool toggle;
        
        private static int logoTriangles = 52;
        private static int spinnerTriangles = 12;

        private static float[] logoVertices = {
            -17.0f,  17.0f,  6.0f,      // Front
            -17.0f, -17.0f,  6.0f,
             -5.0f, -17.0f,  6.0f,
             -5.0f,  -7.0f,  6.0f,
              5.0f, -17.0f,  6.0f,
             17.0f, -17.0f,  6.0f,
             17.0f,   9.0f,  6.0f,
              5.0f,   9.0f,  6.0f,
              5.0f,   7.0f,  6.0f,
             -5.0f,  17.0f,  6.0f,
            -17.0f,  17.0f, -6.0f,      // Back
            -17.0f, -17.0f, -6.0f,
             -5.0f, -17.0f, -6.0f,
             -5.0f,  -7.0f, -6.0f,
              5.0f, -17.0f, -6.0f,
             17.0f, -17.0f, -6.0f,
             17.0f,   9.0f, -6.0f,
              5.0f,   9.0f, -6.0f,
              5.0f,   7.0f, -6.0f,
             -5.0f,  17.0f, -6.0f,
              6.0f,   8.0f,  6.0f,
              6.0f, -16.0f,  6.0f,
             16.0f, -16.0f,  6.0f,
             16.0f,   8.0f,  6.0f,
              6.0f,   8.0f, -6.0f,
              6.0f, -16.0f, -6.0f,
             16.0f, -16.0f, -6.0f,
             16.0f,   8.0f, -6.0f
        };

        private static int[] logoIndices = {
             0,  1,  2,                 // Front
             0,  2,  9,
             9,  3,  8,
             8,  3,  4, 
            10, 12, 11,                 // Back
            10, 19, 12,
            19, 18, 13,
            18, 14, 13,
             0,  9, 19,                 // Top Left
             0, 19, 10,
            19,  9,  8,                 // Top Slant
             8, 18, 19,
             8,  7, 17,                 // Small Step
            17, 18,  8,
            17,  7,  6,                 // Below Cube
            17,  6, 16,
             6,  5, 15,                 // Top Right
            16,  6, 15,
             5, 14, 15,                 // Bottom Right
             5,  4, 14,
             4,  3, 13,                 // Bottom Slant
             4, 13, 14,
             2, 12, 13,                 // Step
             2, 13,  3,
             2, 11, 12,                 // Bottom Left
             2,  1, 11,
             1,  0, 10,                 // Left
             1, 10, 11,
             7,  4, 20,                 // Hollow Front
            20,  4, 21,
            21,  4,  5,
            21,  5, 22,
            22,  5,  6,
             6, 23, 22,
             7, 23,  6,
             7, 20, 23,
            17, 24, 14,                 // Hollow Back
            24, 25, 14,
            25, 15, 14,
            25, 26, 15,
            26, 16, 15,
            16, 26, 27,
            17, 16, 27,
            17, 27, 24,
            20, 24, 23,                 // Hollow Top
            24, 27, 23,
            23, 27, 26,                 // Hollow Right
            23, 26, 22,
            20, 21, 25,                 // Hollow Left
            20, 25, 24,
            25, 21, 22,                 // Hollow Bottom
            25, 22, 26
        };

        private static float[] logoNormals = {
             0.0f,     0.0f,     1.0f,
             0.0f,     0.0f,     1.0f,
             0.0f,     0.0f,     1.0f,
             0.0f,     0.0f,     1.0f,
             0.0f,     0.0f,    -1.0f,
             0.0f,     0.0f,    -1.0f,
             0.0f,     0.0f,    -1.0f,
             0.0f,     0.0f,    -1.0f,
             0.0f,     1.0f,     0.0f,
             0.0f,     1.0f,     0.0f,
             0.7071f,  0.7071f,  0.0f,
             0.7071f,  0.7071f,  0.0f,
            -1.0f,     0.0f,     0.0f,
            -1.0f,     0.0f,     0.0f,
             0.0f,     1.0f,     0.0f,
             0.0f,     1.0f,     0.0f,
             1.0f,     0.0f,     0.0f,
             1.0f,     0.0f,     0.0f,
             0.0f,    -1.0f,     0.0f,
             0.0f,    -1.0f,     0.0f,
            -0.7071f, -0.7071f,  0.0f,
            -0.7071f, -0.7071f,  0.0f,
             1.0f,     0.0f,     0.0f,
             1.0f,     0.0f,     0.0f,
             0.0f,    -1.0f,     0.0f,
             0.0f,    -1.0f,     0.0f,
            -1.0f,     0.0f,     0.0f,
            -1.0f,     0.0f,     0.0f,
             0.0f,     0.0f,     1.0f,
             0.0f,     0.0f,     1.0f,
             0.0f,     0.0f,     1.0f,
             0.0f,     0.0f,     1.0f,
             0.0f,     0.0f,     1.0f,
             0.0f,     0.0f,     1.0f,
             0.0f,     0.0f,     1.0f,
             0.0f,     0.0f,     1.0f,
             0.0f,     0.0f,    -1.0f,
             0.0f,     0.0f,    -1.0f,
             0.0f,     0.0f,    -1.0f,
             0.0f,     0.0f,    -1.0f,
             0.0f,     0.0f,    -1.0f,
             0.0f,     0.0f,    -1.0f,
             0.0f,     0.0f,    -1.0f,
             0.0f,     0.0f,    -1.0f,
             0.0f,    -1.0f,     0.0f,
             0.0f,    -1.0f,     0.0f,
            -1.0f,     0.0f,     0.0f,
            -1.0f,     0.0f,     0.0f,
             1.0f,     0.0f,     0.0f,
             1.0f,     0.0f,     0.0f,
             0.0f,     1.0f,     0.0f,
             0.0f,     1.0f,     0.0f
        };

        private static float[] spinnerVertices = {
            -6.0f,  3.0f,  6.0f,
            -6.0f, -3.0f,  6.0f,
             6.0f, -3.0f,  6.0f,
             6.0f,  3.0f,  6.0f,
            -6.0f,  3.0f, -6.0f,
            -6.0f, -3.0f, -6.0f,
             6.0f, -3.0f, -6.0f,
             6.0f,  3.0f, -6.0f
        };

        private static int[] spinnerIndices = {
            0, 1, 2,
            0, 2, 3,
            0, 3, 7,
            0, 7, 4,
            3, 2, 6,
            3, 6, 7,
            7, 6, 5,
            7, 5, 4,
            6, 2, 1,
            6, 1, 5,
            4, 5, 1,
            4, 1, 0
        };

        private static float[] spinnerNormals = {
             0.0f,  0.0f,  1.0f,
             0.0f,  0.0f,  1.0f,
             0.0f,  1.0f,  0.0f,
             0.0f,  1.0f,  0.0f,
             1.0f,  0.0f,  0.0f,
             1.0f,  0.0f,  0.0f,
             0.0f,  0.0f, -1.0f,
             0.0f,  0.0f, -1.0f,
             0.0f, -1.0f,  0.0f,
             0.0f, -1.0f,  0.0f,
            -1.0f,  0.0f,  0.0f,
            -1.0f,  0.0f,  0.0f
        };
        #endregion Private Fields

        // --- Entry Point ---
        #region Main(string[] args)
        [STAThread]
        public static void Main(string[] args) {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(640, 480);
            Glut.glutInitWindowPosition(50, 50);
            Glut.glutCreateWindow("Network Integration");

            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutIdleFunc(new Glut.IdleCallback(Idle));
            Glut.glutMotionFunc(new Glut.MotionCallback(Motion));
            Glut.glutMouseFunc(new Glut.MouseCallback(Mouse));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutVisibilityFunc(new Glut.VisibilityCallback(Visibility));

            Glut.glutMainLoop();
        }
        #endregion Main(string[] args)

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            int i;

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glPushMatrix();
                Gl.glRotatef(spinY, 1.0f, 0.0f, 0.0f);
                Gl.glRotatef(spinX, 0.0f, 1.0f, 0.0f);

                Gl.glColor3ub(165, 163, 160);
                Gl.glBegin(Gl.GL_TRIANGLES);
                    for(i = 0; i < logoTriangles; i++) {
                        Gl.glNormal3f(logoNormals[3 * i], logoNormals[3 * i + 1], logoNormals[3 * i + 2]);
                        Gl.glVertex3f(logoVertices[(3 * logoIndices[3 * i]) + 0], logoVertices[(3 * logoIndices[3 * i]) + 1], logoVertices[(3 * logoIndices[3 * i]) + 2]);
                        Gl.glVertex3f(logoVertices[(3 * logoIndices[3 * i + 1]) + 0], logoVertices[(3 * logoIndices[3 * i + 1]) + 1], logoVertices[(3 * logoIndices[3 * i + 1]) + 2]);
                        Gl.glVertex3f(logoVertices[(3 * logoIndices[3 * i + 2]) + 0], logoVertices[(3 * logoIndices[3 * i + 2]) + 1], logoVertices[(3 * logoIndices[3 * i + 2]) + 2]);
                    }
                Gl.glEnd();

                Gl.glColor3ub(0, 90, 107);
                Gl.glTranslatef(11.0f, 14.0f, 0.0f);
                Gl.glRotatef(spinC, 0.0f, 1.0f, 0.0f);
                Gl.glBegin(Gl.GL_TRIANGLES);
                    for(i = 0; i < spinnerTriangles; i++) {
                        Gl.glNormal3f(spinnerNormals[3 * i], spinnerNormals[3 * i + 1], spinnerNormals[3 * i + 2]);
                        Gl.glVertex3f(spinnerVertices[(3 * spinnerIndices[3 * i]) + 0], spinnerVertices[(3 * spinnerIndices[3 * i]) + 1], spinnerVertices[(3 * spinnerIndices[3 * i]) + 2]);
                        Gl.glVertex3f(spinnerVertices[(3 * spinnerIndices[3 * i + 1]) + 0], spinnerVertices[(3 * spinnerIndices[3 * i + 1]) + 1], spinnerVertices[(3 * spinnerIndices[3 * i + 1]) + 2]);
                        Gl.glVertex3f(spinnerVertices[(3 * spinnerIndices[3 * i + 2]) + 0], spinnerVertices[(3 * spinnerIndices[3 * i + 2]) + 1], spinnerVertices[(3 * spinnerIndices[3 * i + 2]) + 2]);
                    }
                Gl.glEnd();
            Gl.glPopMatrix();

            Glut.glutSwapBuffers();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case (byte) ' ':
                    spinC = 0;
                    toggle = !toggle;
                    if(toggle) {
                        Glut.glutIdleFunc(null);
                    }
                    else {
                        Glut.glutIdleFunc(new Glut.IdleCallback(Idle));
                    }
                    break;
                case 27:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

            Glut.glutPostRedisplay();
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Idle()
        private static void Idle() {
            spinC += 1;
            if(spinC > 360) {
                spinC = 0;
            }
            Glut.glutPostRedisplay();
        }
        #endregion Idle()

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
            float[] lightPosition = {0.0f, 1.0f, 1.0f, 0.0f};

            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(60.0, (float) width / (float) height, 1.0, 1200.0); 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0.0, 0.0, 60.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPosition);
            Gl.glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_CULL_FACE);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glShadeModel(Gl.GL_SMOOTH);
        }
        #endregion Reshape(int width, int height)

        #region Visibility(int state)
        private static void Visibility(int state) {
            if(state == Glut.GLUT_VISIBLE) {
                Glut.glutIdleFunc(new Glut.IdleCallback(Idle));
            }
            else {
                Glut.glutIdleFunc(null);
            }
        }
        #endregion Visibility(int state)
    }
}
