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
    ///     Use of multiple names and picking are demonstrated.  A 3x3 grid of squares is
    ///     drawn.  When the left mouse button is pressed, all squares under the cursor
    ///     position have their color changed.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/picksquare.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class PickSquare {
        // --- Fields ---
        #region Private Constants
        private const int BUFSIZE = 512;
        #endregion Private Constants

        #region Private Fields
        private static int[ , ] board = new int[3, 3];
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(100, 100);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("PickSquare");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutMouseFunc(new Glut.MouseCallback(Mouse));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region DrawSquares(int mode)
        /// <summary>
        ///     <para>
        ///         The nine squares are drawn.  In selection mode, each square is given two
        ///         names:  one for the row and the other for the column on the grid.  The color
        ///         of each square is determined by its position on the grid, and the value in
        ///         the board[][] array.
        ///     </para>
        /// </summary>
        private static void DrawSquares(int mode) {
            int i, j;
            for(i = 0; i < 3; i++) {
                if(mode == Gl.GL_SELECT) {
                    Gl.glLoadName(i);
                }
                for(j = 0; j < 3; j ++) {
                    if(mode == Gl.GL_SELECT) {
                        Gl.glPushName(j);
                    }
                    Gl.glColor3f((float) i / 3.0f, (float) j / 3.0f, (float) board[i, j] / 3.0f);
                    Gl.glRecti(i, j, i + 1, j + 1);
                    if(mode == Gl.GL_SELECT) {
                        Gl.glPopName();
                    }
                }
            }
        }
        #endregion DrawSquares(int mode)

        #region Init()
        /// <summary>
        ///     <para>
        ///         Clear color value for every square on the board.
        ///     </para>
        /// </summary>
        private static void Init() {
            int i, j;
            for(i = 0; i < 3; i++) {
                for(j = 0; j < 3; j ++) {
                    board[i, j] = 0;
                }
            }
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
        #endregion Init()

        #region ProcessHits(int hits, int[] buffer)
        /// <summary>
        ///     <para>
        ///         Prints out the contents of the selection array.
        ///     </para>
        /// </summary>
        private static void ProcessHits(int hits, int[] buffer) {
            int i, j;
            int ii = 0;
            int jj = 0;
            int names;
            int[] ptr;

            Console.WriteLine("hits = {0}", hits);
            ptr = buffer;
            for(i = 0; i < hits; i++) {  // for each hit
                names = ptr[i];
                Console.WriteLine(" number of names for this hit = {0}", names);
                i++;;
                Console.WriteLine("  z1 is {0}", (float) ptr[i] / 0x7fffffff);
                i++;
                Console.WriteLine("  z2 is {0}", (float) ptr[i] / 0x7fffffff);
                i++;
                Console.Write("   names are ");
                for(j = 0; j < names; j++) {  // for each name
                    Console.Write("{0} ", ptr[i]);
                    if(j == 0) {  // set row and column
                        ii = ptr[i];
                    }
                    else if(j == 1) {
                        jj = ptr[i];
                    }
                    i++;
                }
                Console.WriteLine();
                board[ii, jj] = (board[ii, jj] + 1) % 3;
            }
            Console.WriteLine();
        }
        #endregion ProcessHits(int hits, int[] buffer)

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            DrawSquares(Gl.GL_RENDER);
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
        /// <summary>
        ///     <para>
        ///         Sets up selection mode, name stack, and projection matrix for picking.  Then
        ///         the objects are drawn.
        ///     </para>
        /// </summary>
        private static void Mouse(int button, int state, int x, int y) {
            int[] selectBuffer = new int[BUFSIZE];
            int hits;
            int[] viewport = new int[4];

            if(button != Glut.GLUT_LEFT_BUTTON || state != Glut.GLUT_DOWN) {
                return;
            }

            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);

            Gl.glSelectBuffer(BUFSIZE, selectBuffer);
            Gl.glRenderMode(Gl.GL_SELECT);

            Gl.glInitNames();
            Gl.glPushName(0);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();
                Gl.glLoadIdentity();
                // create 5x5 pixel picking region near cursor location
                Glu.gluPickMatrix((double) x, (double) (viewport[3] - y), 5.0, 5.0, viewport);
                Glu.gluOrtho2D (0.0, 3.0, 0.0, 3.0);
                DrawSquares(Gl.GL_SELECT);
                Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix();
            Gl.glFlush();

            hits = Gl.glRenderMode(Gl.GL_RENDER);
            ProcessHits(hits, selectBuffer);
            Glut.glutPostRedisplay();
        }
        #endregion Mouse(int button, int state, int x, int y)

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, 3.0, 0.0, 3.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        #endregion Reshape(int w, int h)
    }
}
