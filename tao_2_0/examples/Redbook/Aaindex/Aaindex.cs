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
    ///     This program draws shows how to draw anti-aliased lines in color index mode.  It
    ///     draws two diagonal lines to form an X; when 'r' is typed in the window, the
    ///     lines are rotated in opposite directions.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/aaindex.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Aaindex {
        // --- Fields --
        #region Private Constants
        private const int RAMPSIZE = 16;
        private const int RAMP1START = 32;
        private const int RAMP2START = 48;
        #endregion Private Constants

        #region Private Fields
        private static float rotAngle = 0.0f;
        #endregion Private Fields

        // --- Entry Point ---
        #region Main(string[] args)
        /// <summary>
        ///     <para>
        ///         Main Loop.  Open window with initial window size, title bar, color index
        ///         display mode, and handle input events.
        ///     </para>
        /// </summary>
        public static void Main(string[] args) {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_INDEX);
            Glut.glutInitWindowSize(200, 200);
            Glut.glutCreateWindow("Aaindex");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
		#endregion Main(string[] args)

        // --- Application Methods ---
        #region Init()
        /// <summary>
        ///     <para>
        ///         Initialize antialiasing for color index mode, including loading a green color
        ///         ramp starting at RAMP1START, and a blue color ramp starting at RAMP2START.
        ///         The ramps must be a multiple of 16.
        ///     </para>
        /// </summary>
        private static void Init() {
            float shade;

            for(int i = 0; i < RAMPSIZE; i++) {
                shade = (float) i / (float) RAMPSIZE;
                Glut.glutSetColor(RAMP1START + i, 0.0f, shade, 0.0f);
                Glut.glutSetColor(RAMP2START + i, 0.0f, 0.0f, shade);
            }

            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_DONT_CARE);
            Gl.glLineWidth(1.5f);

            Gl.glClearIndex((float) RAMP1START);
        }
        #endregion Init()

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     <para>
        ///         Draw 2 diagonal lines to form an X.
        ///     </para>
        /// </summary>
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glIndexi(RAMP1START);
            Gl.glPushMatrix();
                Gl.glRotatef(-rotAngle, 0.0f, 0.0f, 0.1f);
                Gl.glBegin(Gl.GL_LINES);
                    Gl.glVertex2f(-0.5f, 0.5f);
                    Gl.glVertex2f(0.5f, -0.5f);
                Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glIndexi(RAMP2START);
            Gl.glPushMatrix();
                Gl.glRotatef(rotAngle, 0.0f, 0.0f, 0.1f);
                Gl.glBegin(Gl.GL_LINES);
                    Gl.glVertex2f(0.5f, 0.5f);
                    Gl.glVertex2f(-0.5f, -0.5f);
                Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glFlush();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case (byte) 'r':
                case (byte) 'R':
                    rotAngle += 20.0f;
                    if(rotAngle >= 360.0f) {
                        rotAngle = 0.0f;
                    }
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
                Glu.gluOrtho2D(-1.0, 1.0, -1.0 * h / w, 1.0 * h / w);
            }
            else {
                Glu.gluOrtho2D(-1.0 * w / h, 1.0 * w / h, -1.0, 1.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        #endregion Reshape(int w, int h)
    }
}
