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
    ///     Use the accumulation buffer to do full-scene antialiasing on a scene with
    ///     orthographic parallel projection.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/accanti.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Accanti {
        // --- Fields ---
        #region Private Constants
        private const int ACSIZE = 8;
        #endregion Private Constants

        // --- Entry Point ---
        #region Run()
        /// <summary>
        ///     <para>
        ///         Main Loop.  Be certain to request an accumulation buffer.
        ///     </para>
        /// </summary>
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_ACCUM | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(250, 250);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("Accanti");
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
        ///         Initialize antialiasing for RGBA mode, including alpha blending, hint, and
        ///         line width.  Print out implementation specific info on line width granularity
        ///         and width.
        ///     </para>
        /// </summary>
        private static void Init() {
            float[] materialAmbient = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] materialSpecular = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] lightPosition = {0.0f, 0.0f, 10.0f, 1.0f};
            float[] lightModelAmbient = {0.2f, 0.2f, 0.2f, 1.0f};
            
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialAmbient);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialSpecular);
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, 50.0f);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPosition);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, lightModelAmbient);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glShadeModel(Gl.GL_FLAT);

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glClearAccum(0.0f, 0.0f, 0.0f, 0.0f);
        }
        #endregion Init()

        #region DisplayObjects()
        private static void DisplayObjects() {
            float[] torusDiffuse = {0.7f, 0.7f, 0.0f, 1.0f};
            float[] cubeDiffuse = {0.0f, 0.7f, 0.7f, 1.0f};
            float[] sphereDiffuse = {0.7f, 0.0f, 0.7f, 1.0f};
            float[] octaDiffuse = {0.7f, 0.4f, 0.4f, 1.0f};

            Gl.glPushMatrix();
                Gl.glRotatef(30.0f, 1.0f, 0.0f, 0.0f);

                Gl.glPushMatrix();
                    Gl.glTranslatef(-0.80f, 0.35f, 0.0f);
                    Gl.glRotatef(100.0f, 1.0f, 0.0f, 0.0f);
                    Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, torusDiffuse);
                    Glut.glutSolidTorus(0.275f, 0.85f, 16, 16);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                    Gl.glTranslatef(-0.75f, -0.50f, 0.0f);
                    Gl.glRotatef(45.0f, 0.0f, 0.0f, 1.0f);
                    Gl.glRotatef(45.0f, 1.0f, 0.0f, 0.0f);
                    Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, cubeDiffuse);
                    Glut.glutSolidCube(1.5f);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                    Gl.glTranslatef(0.75f, 0.60f, 0.0f);
                    Gl.glRotatef(30.0f, 1.0f, 0.0f, 0.0f);
                    Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, sphereDiffuse);
                    Glut.glutSolidSphere(1.0f, 16, 16);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                    Gl.glTranslatef(0.70f, -0.90f, 0.25f);
                    Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, octaDiffuse);
                    Glut.glutSolidOctahedron();
                Gl.glPopMatrix();
            Gl.glPopMatrix();
        }
        #endregion DisplayObjects()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            int[] viewport = new int[4];

            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);

            Gl.glClear(Gl.GL_ACCUM_BUFFER_BIT);
            for(int jitter = 0; jitter < ACSIZE; jitter++) {
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
                Gl.glPushMatrix();
                // Note that 4.5 is the distance in world space between left and right and bottom
                // and top.  This formula converts fractional pixel movement to world coordinates.
                Gl.glTranslatef((Jitter.j8[jitter].X * 4.5f) / viewport[2], (Jitter.j8[jitter].Y * 4.5f) / viewport[3], 0.0f);
                DisplayObjects();
                Gl.glPopMatrix();
                Gl.glAccum(Gl.GL_ACCUM, 1.0f / ACSIZE);
            }
            Gl.glAccum(Gl.GL_RETURN, 1.0f);
            Gl.glFlush();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
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
                Gl.glOrtho(-2.25, 2.25, -2.25 * h / w, 2.25 * h / w, -10.0, 10.0);
            }
            else {
                Gl.glOrtho(-2.25 * w / h, 2.25 * w / h, -2.25, 2.25, -10.0, 10.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        #endregion Reshape(int w, int h)
    }
}
