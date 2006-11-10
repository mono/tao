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
    ///     This program demonstrates use of OpenGL feedback.  First,a lighting environment
    ///     is set up and a few lines are drawn.  Then feedback mode is entered, and the
    ///     same lines are drawn.  The results in the feedback buffer are printed.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/feedback.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Feedback {
        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(100, 100);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("Feedback");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region DrawGeometry(int mode)
        /// <summary>
        ///     <para>
        ///         Draw a few lines and two points, one of which will be clipped.  If in
        ///         feedback mode, a passthrough token is issued between the each primitive.
        ///     </para>
        /// </summary>
        private static void DrawGeometry(int mode) {
            Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glNormal3f(0.0f, 0.0f, 1.0f);
                Gl.glVertex3f(30.0f, 30.0f, 0.0f);
                Gl.glVertex3f(50.0f, 60.0f, 0.0f);
                Gl.glVertex3f(70.0f, 40.0f, 0.0f);
            Gl.glEnd();

            if(mode == Gl.GL_FEEDBACK) {
                Gl.glPassThrough(1.0f);
            }

            Gl.glBegin(Gl.GL_POINTS);
                Gl.glVertex3f(-100.0f, -100.0f, -100.0f);  //  will be clipped
            Gl.glEnd();
            
            if(mode == Gl.GL_FEEDBACK) {
                Gl.glPassThrough(2.0f);
            }

            Gl.glBegin(Gl.GL_POINTS);
                Gl.glNormal3f(0.0f, 0.0f, 1.0f);
                Gl.glVertex3f(50.0f, 50.0f, 0.0f);
            Gl.glEnd();
        }
        #endregion DrawGeometry(int mode)

        #region Init()
        private static void Init() {
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
        }
        #endregion Init()

        #region Print3dColorVertex(int size, int count, float[] buffer)
        /// <summary>
        ///     <para>
        ///         Write contents of one vertex to console.
        ///     </para>
        /// </summary>
        private static void Print3dColorVertex(int size, int count, float[] buffer) {
            Console.Write("  ");
            for(int i = 0; i < 7; i++) {
                Console.Write("{0:F2} ", buffer[size - count]);
                count = count - 1;
            }
            Console.Write("\n");
        }
        #endregion Print3dColorVertex(int size, int count, float[] buffer)

        #region PrintBuffer(int size, float[] buffer)
        /// <summary>
        ///     <para>
        ///         Write the contents of the entire buffer.  (Parse tokens!)
        ///     </para>
        /// </summary>
        private static void PrintBuffer(int size, float[] buffer) {
            int count;
            float token;

            count = size;
            while(count != 0) {
                token = buffer[size - count];
                count--;
                if(token == Gl.GL_PASS_THROUGH_TOKEN) {
                    Console.WriteLine("GL_PASS_THROUGH_TOKEN");
                    Console.WriteLine("  {0:F2}", buffer[size - count]);
                    count--;
                }
                else if(token == Gl.GL_POINT_TOKEN) {
                    Console.WriteLine("GL_POINT_TOKEN");
                    Print3dColorVertex(size, count, buffer);
                }
                else if(token == Gl.GL_LINE_TOKEN) {
                    Console.WriteLine("GL_LINE_TOKEN");
                    Print3dColorVertex(size, count, buffer);
                    Print3dColorVertex(size, count, buffer);
                }
                else if(token == Gl.GL_LINE_RESET_TOKEN) {
                    Console.WriteLine("GL_LINE_RESET_TOKEN");
                    Print3dColorVertex(size, count, buffer);
                    Print3dColorVertex(size, count, buffer);
                }
            }
        }
        #endregion PrintBuffer(int size, float[] buffer)

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            float[] feedBuffer = new float[1024];
            int size;

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0.0, 100.0, 0.0, 100.0, 0.0, 1.0);

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            DrawGeometry(Gl.GL_RENDER);

            Gl.glFeedbackBuffer(1024, Gl.GL_3D_COLOR, feedBuffer);
            Gl.glRenderMode(Gl.GL_FEEDBACK);
            DrawGeometry(Gl.GL_FEEDBACK);

            size = Gl.glRenderMode(Gl.GL_RENDER);
            PrintBuffer(size, feedBuffer);
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
