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
    ///     perspective projection, using the special routines accFrustum() and
    ///     accPerspective().
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/accpersp.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Accpersp {
        // --- Fields ---
        #region Private Constants
        private const float PI = 3.14159265358979323846f;
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
            Glut.glutCreateWindow("Accpersp");
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

        #region AccFrustum(double left, double right, double bottom, double top, double near, double far, double pixdx, double pixdy, double eyedx, double eyedy, double focus)
        /// <summary>
        ///     <para>
        ///         The first 6 arguments are identical to the glFrustum() call.
        ///     </para>
        ///     <para>
        ///         pixdx and pixdy are anti-alias jitter in pixels.  Set both equal to 0.0 for
        ///         no anti-alias jitter.  eyedx and eyedy are depth-of field jitter in pixels.
        ///         Set both equal to 0.0 for no depth of field effects.
        ///     </para>
        ///     <para>
        ///         focus is distance from eye to plane in focus.  focus must be greater than,
        ///         but not equal to 0.0.
        ///     </para>
        ///     <para>
        ///         Note that accFrustum() calls glTranslatef().  You will probably want to
        ///         insure that your ModelView matrix has been initialized to identity before
        ///         calling AccFrustum().
        ///     </para>
        /// </summary>
        private static void AccFrustum(double left, double right, double bottom, double top, double near, double far, double pixdx, double pixdy, double eyedx, double eyedy, double focus) {
            double xwsize, ywsize; 
            double dx, dy;
            int[] viewport = new int[4];

            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);

            xwsize = right - left;
            ywsize = top - bottom;

            dx = -(pixdx * xwsize / (double) viewport[2] + eyedx * near / focus);
            dy = -(pixdy * ywsize / (double) viewport[3] + eyedy * near / focus);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glFrustum(left + dx, right + dx, bottom + dy, top + dy, near, far);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glTranslatef((float) -eyedx, (float) -eyedy, 0.0f);
        }
        #endregion AccFrustum(double left, double right, double bottom, double top, double near, double far, double pixdx, double pixdy, double eyedx, double eyedy, double focus)

        #region AccPerspective(double fovy, double aspect, double near, double far, double pixdx, double pixdy, double eyedx, double eyedy, double focus)
        /// <summary>
        ///     <para>
        ///         The first 4 arguments are identical to the gluPerspective() call.
        ///     </para>
        ///     <para>
        ///         pixdx and pixdy are anti-alias jitter in pixels.  Set both equal to 0.0 for
        ///         no anti-alias jitter.  eyedx and eyedy are depth-of field jitter in pixels.
        ///         Set both equal to 0.0 for no depth of field effects.
        ///     </para>
        ///     <para>
        ///         focus is distance from eye to plane in focus.  focus must be greater than,
        ///         but not equal to 0.0.
        ///     </para>
        ///     <para>
        ///         Note that AccPerspective() calls AccFrustum().
        ///     </para>
        /// </summary>
        private static void AccPerspective(double fovy, double aspect, double near, double far, double pixdx, double pixdy, double eyedx, double eyedy, double focus) {
            double fov2, left, right, bottom, top;

            fov2 = ((fovy * PI) / 180.0) / 2.0;

            top = near / (Math.Cos(fov2) / Math.Sin(fov2));
            bottom = -top;

            right = top * aspect;
            left = -right;

            AccFrustum(left, right, bottom, top, near, far, pixdx, pixdy, eyedx, eyedy, focus);
        }
        #endregion AccPerspective(double fovy, double aspect, double near, double far, double pixdx, double pixdy, double eyedx, double eyedy, double focus)

        #region DisplayObjects()
        private static void DisplayObjects() {
            float[] torusDiffuse = {0.7f, 0.7f, 0.0f, 1.0f};
            float[] cubeDiffuse = {0.0f, 0.7f, 0.7f, 1.0f};
            float[] sphereDiffuse = {0.7f, 0.0f, 0.7f, 1.0f};
            float[] octaDiffuse = {0.7f, 0.4f, 0.4f, 1.0f};

            Gl.glPushMatrix();
                Gl.glTranslatef(0.0f, 0.0f, -5.0f);
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
                AccPerspective(50.0, (double) viewport[2] / (double) viewport[3], 1.0, 15.0, Jitter.j8[jitter].X, Jitter.j8[jitter].Y, 0.0, 0.0, 1.0);
                DisplayObjects();
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
        }
        #endregion Reshape(int w, int h)
    }
}
