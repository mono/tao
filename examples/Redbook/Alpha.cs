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
    ///     This program draws several overlapping filled polygons to demonstrate the effect
    ///     order has on alpha blending results.  Use the 't' key to toggle the order of
    ///     drawing polygons.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/alpha.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Alpha {
        // --- Fields ---
        #region Private Fields
        private static bool leftFirst = true;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        /// <summary>
        ///     <para>
        ///         Main Loop.  Open window with initial window size, title bar, RGBA display
        ///         mode, and handle input events.
        ///     </para>
        /// </summary>
        /// <param name="args"></param>
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(200, 200);
            Glut.glutCreateWindow("Alpha");
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
        ///         Initialize alpha blending function.
        ///     </para>
        /// </summary>
        private static void Init() {
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glShadeModel(Gl.GL_FLAT);
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
        #endregion Init()

        #region DrawLeftTriangle()
        /// <summary>
        ///     <para>
        ///         Draws yellow triangle on left hand side of screen.
        ///     </para>
        /// </summary>
        private static void DrawLeftTriangle() {
            Gl.glBegin(Gl.GL_TRIANGLES);
                Gl.glColor4f(1.0f, 1.0f, 0.0f, 0.75f);
                Gl.glVertex3f(0.1f, 0.9f, 0.0f);
                Gl.glVertex3f(0.1f, 0.1f, 0.0f);
                Gl.glVertex3f(0.7f, 0.5f, 0.0f);
            Gl.glEnd();
        }
        #endregion DrawLeftTriangle()

        #region DrawRightTriangle()
        /// <summary>
        ///     <para>
        ///         Draws cyan triangle on right hand side of screen.
        ///     </para>
        /// </summary>
        private static void DrawRightTriangle() {
            Gl.glBegin(Gl.GL_TRIANGLES);
                Gl.glColor4f(0.0f, 1.0f, 1.0f, 0.75f);
                Gl.glVertex3f(0.9f, 0.9f, 0.0f);
                Gl.glVertex3f(0.3f, 0.5f, 0.0f);
                Gl.glVertex3f(0.9f, 0.1f, 0.0f);
            Gl.glEnd();
        }
        #endregion DrawRightTriangle()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            if(leftFirst) {
                DrawLeftTriangle();
                DrawRightTriangle();
            }
            else {
                DrawRightTriangle();
                DrawLeftTriangle();
            }
            Gl.glFlush();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case (byte) 't':
                case (byte) 'T':
                    leftFirst = !leftFirst;
                    Glut.glutPostRedisplay();
                    break;
                case (byte) 27:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            if(w <= h) {
                Glu.gluOrtho2D(0.0, 1.0, 0.0, 1.0 * h / w);
            }
            else {
                Glu.gluOrtho2D(0.0, 1.0 * w / h, 0.0, 1.0);
            }
        }
        #endregion Reshape(int w, int h)
    }
}
