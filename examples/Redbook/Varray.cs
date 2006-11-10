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
    ///     This program demonstrates vertex arrays.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/varray.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Varray {
        // --- Fields ---
        #region Private Constants
        private const int POINTER = 1;
        private const int INTERLEAVED = 2;
        private const int DRAWARRAY = 1;
        private const int ARRAYELEMENT = 2;
        private const int DRAWELEMENTS = 3;
        #endregion Private Constants

        #region Private Fields
        private static int setupMethod = POINTER;
        private static int derefMethod = DRAWARRAY;

        private static float[] intertwined = {
            1.0f, 0.2f, 1.0f, 100.0f, 100.0f, 0.0f,
            1.0f, 0.2f, 0.2f, 0.0f, 200.0f, 0.0f,
            1.0f, 1.0f, 0.2f, 100.0f, 300.0f, 0.0f,
            0.2f, 1.0f, 0.2f, 200.0f, 300.0f, 0.0f,
            0.2f, 1.0f, 1.0f, 300.0f, 200.0f, 0.0f,
            0.2f, 0.2f, 1.0f, 200.0f, 100.0f, 0.0f
        };

        private static int[] vertices = {
            25, 25,
            100, 325,
            175, 25,
            175, 325,
            250, 25,
            325, 325
        };

        private static float[] colors = {
            1.0f, 0.2f, 0.2f,
            0.2f, 0.2f, 1.0f,
            0.8f, 1.0f, 0.2f,
            0.75f, 0.75f, 0.75f,
            0.35f, 0.35f, 0.35f,
            0.5f, 0.5f, 0.5f
        };
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(350, 350);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("Varray");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutMouseFunc(new Glut.MouseCallback(Mouse));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region Init()
        private static void Init() {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glShadeModel(Gl.GL_SMOOTH);
            SetupPointers();
        }
        #endregion Init()

        #region SetupInterleave()
        private static void SetupInterleave() {
            Gl.glInterleavedArrays(Gl.GL_C3F_V3F, 0, intertwined);
        }
        #endregion SetupInterleave()

        #region SetupPointers()
        private static void SetupPointers() {
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);

            Gl.glVertexPointer(2, Gl.GL_INT, 0, vertices);
            Gl.glColorPointer(3, Gl.GL_FLOAT, 0, colors);
        }
        #endregion SetupPointers()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            if(derefMethod == DRAWARRAY) {
                Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, 6);
            }
            else if(derefMethod == ARRAYELEMENT) {
                Gl.glBegin(Gl.GL_TRIANGLES);
                    Gl.glArrayElement(2);
                    Gl.glArrayElement(3);
                    Gl.glArrayElement(5);
                Gl.glEnd();
            }
            else if(derefMethod == DRAWELEMENTS) {
                int[] indices = {0, 1, 3, 4};

                Gl.glDrawElements(Gl.GL_POLYGON, 4, Gl.GL_UNSIGNED_INT, indices);
            }
            Gl.glFlush();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case 27:
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Mouse(int button, int state, int x, int y)
        private static void Mouse(int button, int state, int x, int y) {
            switch(button) {
                case Glut.GLUT_LEFT_BUTTON:
                    if(state == Glut.GLUT_DOWN) {
                        if(setupMethod == POINTER) {
                            setupMethod = INTERLEAVED;
                            SetupInterleave();
                        }
                        else if(setupMethod == INTERLEAVED) {
                            setupMethod = POINTER;
                            SetupPointers();
                        }
                        Glut.glutPostRedisplay();
                    }
                    break;
                case Glut.GLUT_MIDDLE_BUTTON:
                case Glut.GLUT_RIGHT_BUTTON:
                    if(state == Glut.GLUT_DOWN) {
                        if(derefMethod == DRAWARRAY) {
                            derefMethod = ARRAYELEMENT;
                        }
                        else if(derefMethod == ARRAYELEMENT) {
                            derefMethod = DRAWELEMENTS;
                        }
                        else if (derefMethod == DRAWELEMENTS) {
                            derefMethod = DRAWARRAY;
                        }
                        Glut.glutPostRedisplay();
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion Mouse(int button, int state, int x, int y)

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, (double) w, 0.0, (double) h);
        }
        #endregion Reshape(int w, int h)
    }
}
