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
    ///     This is an illustration of the selection mode and name stack, which detects
    ///     whether objects which collide with a viewing volume.  First, four triangles and
    ///     a rectangular box representing a viewing volume are drawn (drawScene routine).
    ///     The green triangle and yellow triangles appear to lie within the viewing volume,
    ///     but the red triangle appears to lie outside it.  Then the selection mode is
    ///     entered (SelectObjects routine).  Drawing to the screen ceases.  To see if any
    ///     collisions occur, the four triangles are called.  In this example, the green
    ///     triangle causes one hit with the name 1, and the yellow triangles cause one hit
    ///     with the name 3.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/select.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Select {
        // --- Fields ---
        #region Private Constants
        private const int BUFSIZE = 512;
        #endregion Private Constants

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(200, 200);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("Select");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region Init()
        private static void Init() {
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glShadeModel(Gl.GL_FLAT);
        }
        #endregion Init()

        #region DrawScene()
        /// <summary>
        ///     <para>
        ///         Draws 4 triangles and a wire frame which represents the viewing volume.
        ///     </para>
        /// </summary>
        private static void DrawScene() {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(40.0, 4.0 / 3.0, 1.0, 100.0);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(7.5, 7.5, 12.5, 2.5, 2.5, -5.0, 0.0, 1.0, 0.0);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);	// green triangle
            DrawTriangle(2.0f, 2.0f, 3.0f, 2.0f, 2.5f, 3.0f, -5.0f);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);	// red triangle
            DrawTriangle(2.0f, 7.0f, 3.0f, 7.0f, 2.5f, 8.0f, -5.0f);
            Gl.glColor3f(1.0f, 1.0f, 0.0f);	// yellow triangles
            DrawTriangle(2.0f, 2.0f, 3.0f, 2.0f, 2.5f, 3.0f, 0.0f);
            DrawTriangle(2.0f, 2.0f, 3.0f, 2.0f, 2.5f, 3.0f, -10.0f);
            DrawViewVolume(0.0f, 5.0f, 0.0f, 5.0f, 0.0f, 10.0f);
        }
        #endregion DrawScene()

        #region DrawTriangle(float x1, float y1, float x2, float y2, float x3, float y3, float z)
        /// <summary>
        ///     <para>
        ///         Draw a triangle with vertices at (x1, y1), (x2, y2), and (x3, y3) at z units
        ///         away from the origin
        ///     </para>
        /// </summary>
        private static void DrawTriangle(float x1, float y1, float x2, float y2, float x3, float y3, float z) {
            Gl.glBegin(Gl.GL_TRIANGLES);
                Gl.glVertex3f(x1, y1, z);
                Gl.glVertex3f(x2, y2, z);
                Gl.glVertex3f(x3, y3, z);
            Gl.glEnd();
        }
        #endregion DrawTriangle(float x1, float y1, float x2, float y2, float x3, float y3, float z)

        #region DrawViewVolume(float x1, float x2, float y1, float y2, float z1, float z2)
        /// <summary>
        ///     <para>
        ///         Draws a rectangular box with these outer x, y, and z values.
        ///     </para>
        /// </summary>
        private static void DrawViewVolume(float x1, float x2, float y1, float y2, float z1, float z2) {
            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glBegin(Gl.GL_LINE_LOOP);
                Gl.glVertex3f(x1, y1, -z1);
                Gl.glVertex3f(x2, y1, -z1);
                Gl.glVertex3f(x2, y2, -z1);
                Gl.glVertex3f(x1, y2, -z1);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
                Gl.glVertex3f(x1, y1, -z2);
                Gl.glVertex3f(x2, y1, -z2);
                Gl.glVertex3f(x2, y2, -z2);
                Gl.glVertex3f(x1, y2, -z2);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINES); // 4 lines
                Gl.glVertex3f(x1, y1, -z1);
                Gl.glVertex3f(x1, y1, -z2);
                Gl.glVertex3f(x1, y2, -z1);
                Gl.glVertex3f(x1, y2, -z2);
                Gl.glVertex3f(x2, y1, -z1);
                Gl.glVertex3f(x2, y1, -z2);
                Gl.glVertex3f(x2, y2, -z1);
                Gl.glVertex3f(x2, y2, -z2);
            Gl.glEnd();
        }
        #endregion DrawViewVolume(float x1, float x2, float y1, float y2, float z1, float z2)

        #region ProcessHits(int hits, int[] buffer)
        /// <summary>
        ///     <para>
        ///         ProcessHits prints out the contents of the selection array.
        ///     </para>
        /// </summary>
        private static void ProcessHits(int hits, int[] buffer) {
            int i, j;
            int names;
            int[] ptr;

            Console.WriteLine("hits = {0}", hits);
            ptr = buffer;
            for(i = 0; i < hits; i++) {	//  for each hit
                names = ptr[i];
                Console.WriteLine(" number of names for hit = {0}", names);
                i++;
                Console.WriteLine("  z1 is {0}", (float) ptr[i] / 0x7fffffff);
                i++;
                Console.WriteLine("  z2 is {0}", (float) ptr[i] / 0x7fffffff);
                i++;
                Console.Write("   the name is ");
                for(j = 0; j < names; j++) {	// for each name
                    Console.Write("{0} ", ptr[i]);
                    i++;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #endregion ProcessHits(int hits, int[] buffer)

        #region SelectObjects()
        /// <summary>
        ///     <para>
        ///         SelectObjects "draws" the triangles in selection mode, assigning names for
        ///         the triangles.  Note that the third and fourth triangles share one name, so
        ///         that if either or both triangles intersects the viewing/clipping volume,
        ///         only one hit will be registered.
        ///     </para>
        /// </summary>
        private static void SelectObjects() {
            int[] selectBuffer = new int[BUFSIZE];
            int hits;

            Gl.glSelectBuffer(BUFSIZE, selectBuffer);
            Gl.glRenderMode(Gl.GL_SELECT);

            Gl.glInitNames();
            Gl.glPushName(0);

            Gl.glPushMatrix();
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();
                Gl.glOrtho(0.0, 5.0, 0.0, 5.0, 0.0, 10.0);
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glLoadIdentity();
                Gl.glLoadName(1);
                DrawTriangle(2.0f, 2.0f, 3.0f, 2.0f, 2.5f, 3.0f, -5.0f);
                Gl.glLoadName(2);
                DrawTriangle(2.0f, 7.0f, 3.0f, 7.0f, 2.5f, 8.0f, -5.0f);
                Gl.glLoadName(3);
                DrawTriangle(2.0f, 2.0f, 3.0f, 2.0f, 2.5f, 3.0f, 0.0f);
                DrawTriangle(2.0f, 2.0f, 3.0f, 2.0f, 2.5f, 3.0f, -10.0f);
            Gl.glPopMatrix();
            Gl.glFlush();

            hits = Gl.glRenderMode(Gl.GL_RENDER);
            ProcessHits(hits, selectBuffer);
        }
        #endregion SelectObjects()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            DrawScene();
            SelectObjects();
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
    }
}
