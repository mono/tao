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
 * Copyright (c) 1993-1997, Silicon Graphics, Inc.
 * ALL RIGHTS RESERVED 
 * Permission to use, copy, modify, and distribute this software for 
 * any purpose and without fee is hereby granted, provided that the above
 * copyright notice appear in all copies and that both the copyright notice
 * and this permission notice appear in supporting documentation, and that 
 * the name of Silicon Graphics, Inc. not be used in advertising
 * or publicity pertaining to distribution of the software without specific,
 * written prior permission. 
 *
 * THE MATERIAL EMBODIED ON THIS SOFTWARE IS PROVIDED TO YOU "AS-IS"
 * AND WITHOUT WARRANTY OF ANY KIND, EXPRESS, IMPLIED OR OTHERWISE,
 * INCLUDING WITHOUT LIMITATION, ANY WARRANTY OF MERCHANTABILITY OR
 * FITNESS FOR A PARTICULAR PURPOSE.  IN NO EVENT SHALL SILICON
 * GRAPHICS, INC.  BE LIABLE TO YOU OR ANYONE ELSE FOR ANY DIRECT,
 * SPECIAL, INCIDENTAL, INDIRECT OR CONSEQUENTIAL DAMAGES OF ANY
 * KIND, OR ANY DAMAGES WHATSOEVER, INCLUDING WITHOUT LIMITATION,
 * LOSS OF PROFIT, LOSS OF USE, SAVINGS OR REVENUE, OR THE CLAIMS OF
 * THIRD PARTIES, WHETHER OR NOT SILICON GRAPHICS, INC.  HAS BEEN
 * ADVISED OF THE POSSIBILITY OF SUCH LOSS, HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, ARISING OUT OF OR IN CONNECTION WITH THE
 * POSSESSION, USE OR PERFORMANCE OF THIS SOFTWARE.
 * 
 * US Government Users Restricted Rights 
 * Use, duplication, or disclosure by the Government is subject to
 * restrictions set forth in FAR 52.227.19(c)(2) or subparagraph
 * (c)(1)(ii) of the Rights in Technical Data and Computer Software
 * clause at DFARS 252.227-7013 and/or in similar or successor
 * clauses in the FAR or the DOD or NASA FAR Supplement.
 * Unpublished-- rights reserved under the copyright laws of the
 * United States.  Contractor/manufacturer is Silicon Graphics,
 * Inc., 2011 N.  Shoreline Blvd., Mountain View, CA 94039-7311.
 *
 * OpenGL(R) is a registered trademark of Silicon Graphics, Inc.
 */
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Redbook {
    #region Class Documentation
    /// <summary>
    ///     This program demonstrates the creation of a display list.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/torus.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Torus {
        // --- Fields ---
        #region Private Constants
        private const double PI = 3.14159265358979323846;
        #endregion Private Constants

        #region Private Fields
        private static int torus;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(200, 200);
            Glut.glutCreateWindow("Torus");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region Init()
        /// <summary>
        ///     <para>
        ///         Create display list with torus and initialize state.
        ///     </para>
        /// </summary>
        private static void Init() {
            torus = Gl.glGenLists(1);
            Gl.glNewList(torus, Gl.GL_COMPILE);
                DrawTorus(8, 25);
            Gl.glEndList();

            Gl.glShadeModel(Gl.GL_FLAT);
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
        #endregion Init()

        #region DrawTorus(int c, int t)
        /// <summary>
        ///     <para>
        ///         Draw a torus.
        ///     </para>
        /// </summary>
        private static void DrawTorus(int numc, int numt) {
            int i, j, k;
            double s, t, x, y, z, twoPi;

            twoPi = 2 * PI;
            for(i = 0; i < numc; i++) {
                Gl.glBegin(Gl.GL_QUAD_STRIP);
                    for(j = 0; j <= numt; j++) {
                        for(k = 1; k >= 0; k--) {
                            s = (i + k) % numc + 0.5;
                            t = j % numt;

                            x = (1 + 0.1 * Math.Cos(s * twoPi / numc)) * Math.Cos(t * twoPi / numt);
                            y = (1 + 0.1 * Math.Cos(s * twoPi / numc)) * Math.Sin(t * twoPi / numt);
                            z = 0.1 * Math.Sin(s * twoPi / numc);
                            Gl.glVertex3f((float) x, (float) y, (float) z);
                        }
                    }
                Gl.glEnd();
            }
        }
        #endregion DrawTorus(int c, int t)

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     <para>
        ///         Clear window and draw torus.
        ///     </para>
        /// </summary>
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glCallList(torus);
            Gl.glFlush();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        /// <summary>
        ///     <para>
        ///         Rotate about x-axis when "x" typed; rotate about y-axis when "y" typed;
        ///         "i" returns torus to original view
        ///     </para>
        /// </summary>
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case 27:
                    Environment.Exit(0);
                    break;
                case (byte) 'x':
                case (byte) 'X':
                    Gl.glRotatef(30.0f, 1.0f, 0.0f, 0.0f);
                    Glut.glutPostRedisplay();
                    break;
                case (byte) 'y':
                case (byte) 'Y':
                    Gl.glRotatef(30.0f, 0.0f, 1.0f, 0.0f);
                    Glut.glutPostRedisplay();
                    break;
                case (byte) 'i':
                case (byte) 'I':
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(0, 0, 10, 0, 0, 0, 0, 1, 0);
                    Glut.glutPostRedisplay();
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Reshape(int w, int h)
        /// <summary>
        ///     <para>
        ///         Handle window resize.
        ///     </para>
        /// </summary>
        private static void Reshape(int w, int h) {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(30, (float) w / (float) h, 1.0, 100.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0, 0, 10, 0, 0, 0, 0, 1, 0);
        }
        #endregion Reshape(int w, int h)
    }
}
