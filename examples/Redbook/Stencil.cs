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
    ///     This program demonstrates use of the stencil buffer for masking nonrectangular
    ///     regions.  Whenever the window is redrawn, a value of 1 is drawn into a
    ///     diamond-shaped region in the stencil buffer.  Elsewhere in the stencil buffer,
    ///     the value is 0.  Then a blue sphere is drawn where the stencil value is 1,
    ///     and yellow torii are drawn where the stencil value is not 1.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/stencil.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Stencil {
        // --- Fields ---
        #region Private Constants
        private const int YELLOWMAT = 1;
        private const int BLUEMAT = 2;
        #endregion Private Constants

        // --- Entry Point ---
        #region Run()
        /// <summary>
        ///     <para>
        ///         Be certain to request stencil bits.
        ///     </para>
        /// </summary>
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH | Glut.GLUT_STENCIL);
            Glut.glutInitWindowSize(400, 400);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("Stencil");
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
            float[] yellowDiffuse = {0.7f, 0.7f, 0.0f, 1.0f};
            float[] yellowSpecular = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] blueDiffuse = {0.1f, 0.1f, 0.7f, 1.0f};
            float[] blueSpecular = {0.1f, 1.0f, 1.0f, 1.0f};
            float[] position = {1.0f, 1.0f, 1.0f, 0.0f};

            Gl.glNewList(YELLOWMAT, Gl.GL_COMPILE);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, yellowDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, yellowSpecular);
                Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, 64.0f);
            Gl.glEndList();

            Gl.glNewList(BLUEMAT, Gl.GL_COMPILE);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, blueDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, blueSpecular);
                Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, 45.0f);
            Gl.glEndList();

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, position);

            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_LIGHTING);

            Gl.glClearStencil(0x0);
            Gl.glEnable(Gl.GL_STENCIL_TEST);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glTranslatef(0.0f, 0.0f, -5.0f);
        }
        #endregion Init()

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     <para>
        ///         Draw a sphere in a diamond-shaped section in the middle of a window with 2
        ///         torii.
        ///     </para>
        /// </summary>
        private static void Display() {
            Gl.glClear(Gl.GL_STENCIL_BUFFER_BIT);

            // create a diamond shaped stencil area
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();
                Gl.glLoadIdentity();
                Gl.glOrtho(-3.0, 3.0, -3.0, 3.0, -1.0, 1.0);
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glPushMatrix();
                    Gl.glLoadIdentity();

                    // Disable color buffer update.
                    Gl.glColorMask(0, 0, 0, 0);
                    Gl.glDisable(Gl.GL_DEPTH_TEST);
                    Gl.glStencilFunc(Gl.GL_ALWAYS, 0x1, 0x1);
                    Gl.glStencilOp(Gl.GL_REPLACE, Gl.GL_REPLACE, Gl.GL_REPLACE);

                    Gl.glBegin(Gl.GL_QUADS);
                        Gl.glVertex3f(-1.0f, 0.0f, 0.0f);
                        Gl.glVertex3f(0.0f, 1.0f, 0.0f);
                        Gl.glVertex3f(1.0f, 0.0f, 0.0f);
                        Gl.glVertex3f(0.0f, -1.0f, 0.0f);
                    Gl.glEnd();
                Gl.glPopMatrix();
                Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
    
            // Enable color buffer update.
            Gl.glColorMask(1, 1, 1, 1);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glStencilOp(Gl.GL_KEEP, Gl.GL_KEEP, Gl.GL_KEEP);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            // draw blue sphere where the stencil is 1
            Gl.glStencilFunc(Gl.GL_EQUAL, 0x1, 0x1);
            Gl.glCallList(BLUEMAT);
            Glut.glutSolidSphere(0.5, 15, 15);

            // draw the tori where the stencil is not 1
            Gl.glStencilFunc(Gl.GL_NOTEQUAL, 0x1, 0x1);
            Gl.glPushMatrix();
                Gl.glRotatef(45.0f, 0.0f, 0.0f, 1.0f);
                Gl.glRotatef(45.0f, 0.0f, 1.0f, 0.0f);
                Gl.glCallList(YELLOWMAT);
                Glut.glutSolidTorus(0.275, 0.85, 15, 15);
                Gl.glPushMatrix();
                    Gl.glRotatef(90.0f, 1.0f, 0.0f, 0.0f);
                    Glut.glutSolidTorus(0.275, 0.85, 15, 15);
                Gl.glPopMatrix();
            Gl.glPopMatrix();

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
        /// <summary>
        ///     <para>
        ///         Whenever the window is reshaped, redefine the coordinate system and redraw
        ///         the stencil area.
        ///     </para>
        /// </summary>
        private static void Reshape(int w, int h) {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45.0, (float) w / (float) h, 3.0, 7.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }
        #endregion Reshape(int w, int h)
    }
}
