#region License
/*
MIT License
Copyright �2003-2005 Tao Framework Team
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
    ///     This program demonstrates geometric primitives and their attributes.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/lines.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Lines {
        // --- Entry Point ---
        #region Main(string[] args)
        [STAThread]
        public static void Main(string[] args) {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(400, 150);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("Lines");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
        #endregion Main(string[] args)

        // --- Application Methods ---
        #region Init()
        private static void Init() {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glShadeModel(Gl.GL_FLAT);
        }
        #endregion Init()

        #region DrawOneLine(float x1, float y1, float x2, float y2)
        private static void DrawOneLine(float x1, float y1, float x2, float y2) {
            Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex2f(x1, y1);
                Gl.glVertex2f(x2, y2);
            Gl.glEnd();
        }
        #endregion DrawOneLine(float x1, float y1, float x2, float y2)

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            int i;

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            // select white for all lines
            Gl.glColor3f(1.0f, 1.0f, 1.0f);

            // in 1st row, 3 lines, each with a different stipple
            Gl.glEnable(Gl.GL_LINE_STIPPLE);

            Gl.glLineStipple(1, 0x0101);  // dotted
            DrawOneLine(50.0f, 125.0f, 150.0f, 125.0f);
            Gl.glLineStipple(1, 0x00FF);  // dashed
            DrawOneLine(150.0f, 125.0f, 250.0f, 125.0f);
            Gl.glLineStipple(1, 0x1C47);  // dash/dot/dash
            DrawOneLine(250.0f, 125.0f, 350.0f, 125.0f);

            // in 2nd row, 3 wide lines, each with different stipple
            Gl.glLineWidth(5.0f);
            Gl.glLineStipple(1, 0x0101);  // dotted
            DrawOneLine(50.0f, 100.0f, 150.0f, 100.0f);
            Gl.glLineStipple(1, 0x00FF);  // dashed
            DrawOneLine(150.0f, 100.0f, 250.0f, 100.0f);
            Gl.glLineStipple(1, 0x1C47);  // dash/dot/dash
            DrawOneLine(250.0f, 100.0f, 350.0f, 100.0f);
            Gl.glLineWidth(1.0f);

            // in 3rd row, 6 lines, with dash/dot/dash stipple
            // as part of a single connected line strip
            Gl.glLineStipple(1, 0x1C47);  // dash/dot/dash
            Gl.glBegin(Gl.GL_LINE_STRIP);
                for(i = 0; i < 7; i++) {
                    Gl.glVertex2f(50.0f + ((float) i * 50.0f), 75.0f);
                }
            Gl.glEnd();

            // in 4th row, 6 independent lines with same stipple
            for(i = 0; i < 6; i++) {
                DrawOneLine(50.0f + ((float) i * 50.0f), 50.0f, 50.0f + ((float)(i + 1) * 50.0f), 50.0f);
            }

            // in 5th row, 1 line, with dash/dot/dash stipple
            // and a stipple repeat factor of 5
            Gl.glLineStipple(5, 0x1C47);  // dash/dot/dash
            DrawOneLine(50.0f, 25.0f, 350.0f, 25.0f);

            Gl.glDisable(Gl.GL_LINE_STIPPLE);
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
