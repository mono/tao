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
    ///     This program draws filled polygons with antialiased edges.  The special
    ///     GL_SRC_ALPHA_SATURATE blending function is used.  Pressing the 't' key turns the
    ///     antialiasing on and off.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/aapoly.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Aapoly {
        // --- Fields --
        #region Private Constants
        private const int FACES = 6;
        #endregion Private Constants

        #region Private Fields
        private static bool polySmooth = true;

        private static float[/*8*/, /*3*/] v = new float [8, 3];
        private static float[/*8*/, /*4*/] c = {
            {0.0f, 0.0f, 0.0f, 1.0f},
            {1.0f, 0.0f, 0.0f, 1.0f},
            {0.0f, 1.0f, 0.0f, 1.0f},
            {1.0f, 1.0f, 0.0f, 1.0f},
            {0.0f, 0.0f, 1.0f, 1.0f},
            {1.0f, 0.0f, 1.0f, 1.0f},
            {0.0f, 1.0f, 1.0f, 1.0f},
            {1.0f, 1.0f, 1.0f, 1.0f}
        };

        // indices of front, top, left, bottom, right, back faces
        private static byte[/*6*/, /*4*/] indices = {
            {4, 5, 6, 7},
            {2, 3, 7, 6},
            {0, 4, 7, 3},
            {0, 1, 5, 4},
            {1, 5, 6, 2},
            {0, 3, 2, 1}
        };
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        /// <summary>
        ///     <para>
        ///         Main Loop.
        ///     </para>
        /// </summary>
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_ALPHA | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(200, 200);
            Glut.glutCreateWindow("Aapoly");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
		#endregion Run()

        // --- Application Methods ---
        #region Init()
        private static void Init() {
            Gl.glCullFace(Gl.GL_BACK);
            Gl.glEnable(Gl.GL_CULL_FACE);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA_SATURATE, Gl.GL_ONE);
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
        #endregion Init()

        #region DrawCube(float x0, float x1, float y0, float y1, float z0, float z1)
        private static void DrawCube(float x0, float x1, float y0, float y1, float z0, float z1) {
            v[0, 0] = v[3, 0] = v[4, 0] = v[7, 0] = x0;
            v[1, 0] = v[2, 0] = v[5, 0] = v[6, 0] = x1;
            v[0, 1] = v[1, 1] = v[4, 1] = v[5, 1] = y0;
            v[2, 1] = v[3, 1] = v[6, 1] = v[7, 1] = y1;
            v[0, 2] = v[1, 2] = v[2, 2] = v[3, 2] = z0;
            v[4, 2] = v[5, 2] = v[6, 2] = v[7, 2] = z1;

            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, v);
            Gl.glColorPointer(4, Gl.GL_FLOAT, 0, c);
            Gl.glDrawElements(Gl.GL_QUADS, FACES * 4, Gl.GL_UNSIGNED_BYTE, indices);
            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);
        }
        #endregion DrawCube(float x0, float x1, float y0, float y1, float z0, float z1)

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     <para>
        ///         Note:  polygons must be drawn from front to back for proper blending.
        ///     </para>
        /// </summary>
        private static void Display() {
            if(polySmooth) {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                Gl.glEnable(Gl.GL_BLEND);
                Gl.glEnable(Gl.GL_POLYGON_SMOOTH);
                Gl.glDisable(Gl.GL_DEPTH_TEST);
            }
            else {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
                Gl.glDisable(Gl.GL_BLEND);
                Gl.glDisable(Gl.GL_POLYGON_SMOOTH);
                Gl.glEnable(Gl.GL_DEPTH_TEST);
            }

            Gl.glPushMatrix();
                Gl.glTranslatef(0.0f, 0.0f, -8.0f);    
                Gl.glRotatef(30.0f, 1.0f, 0.0f, 0.0f);
                Gl.glRotatef(60.0f, 0.0f, 1.0f, 0.0f); 
                DrawCube(-0.5f, 0.5f, -0.5f, 0.5f, -0.5f, 0.5f);
            Gl.glPopMatrix ();

            Gl.glFlush ();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case (byte) 't':
                case (byte) 'T':
                    polySmooth = !polySmooth;
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
            Glu.gluPerspective(30.0, (float) w / (float) h, 1.0, 20.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        #endregion Reshape(int w, int h)
    }
}
