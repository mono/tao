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
    ///     This program draws a NURBS surface in the shape of a symmetrical hill, using both
    ///     a NURBS curve and pwl (piecewise linear) curve to trim part of the surface.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/trim.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Trim {
        // --- Fields ---
        #region Private Fields
        private static float[ , , ] controlPoints = new float[4, 4, 3];
        private static Glu.GLUnurbs nurb;
        #endregion Private Fields

        // --- Entry Point ---
        #region Main(string[] args)
        [STAThread]
        public static void Main(string[] args) {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(500, 500);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("Trim");
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
        ///         Initialize material property and depth buffer.
        ///     </para>
        /// </summary>
        private static void Init() {
            float[] materialDiffuse = {0.7f, 0.7f, 0.7f, 1.0f};
            float[] materialSpecular = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] materialShininess = {100.0f};

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialSpecular);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, materialShininess);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_AUTO_NORMAL);
            Gl.glEnable(Gl.GL_NORMALIZE);

            InitSurface();

            nurb = Glu.gluNewNurbsRenderer();
            Glu.gluNurbsProperty(nurb, Glu.GLU_SAMPLING_TOLERANCE, 25.0f);
            Glu.gluNurbsProperty(nurb, Glu.GLU_DISPLAY_MODE, Glu.GLU_FILL);
            Glu.gluNurbsCallback(nurb, Glu.GLU_ERROR, new Glu.NurbsErrorCallback(NurbsError));
        }
        #endregion Init()

        #region InitSurface()
        /// <summary>
        ///     <para>
        ///         Initializes the control points of the surface to a small hill.  The control
        ///         points range from -3 to +3 in x, y, and z.
        ///     </para>
        /// </summary>
        private static void InitSurface() {
            int u, v;
            for(u = 0; u < 4; u++) {
                for(v = 0; v < 4; v++) {
                    controlPoints[u, v, 0] = (float) (2.0f * (u - 1.5));
                    controlPoints[u, v, 1] = (float) (2.0f * (v - 1.5));

                    if((u == 1 || u == 2) && (v == 1 || v == 2)) {
                        controlPoints[u, v, 2] = 3.0f;
                    }
                    else {
                        controlPoints[u, v, 2] = -3.0f;
                    }
                }
            }
        }
        #endregion InitSurface()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            float[] knots = {0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f};
            // counter clockwise
            float[ , ] edgePoints = {
                {0.0f, 0.0f},
                {1.0f, 0.0f},
                {1.0f, 1.0f},
                {0.0f, 1.0f},
                {0.0f, 0.0f}
            };
            // clockwise
            float[ , ] curvePoints = {
                {0.25f, 0.5f},
                {0.25f, 0.75f},
                {0.75f, 0.75f},
                {0.75f, 0.5f}
            };
            float[] curveKnots = {0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f};
            // clockwise
            float[ , ] pwlPoints = {
                {0.75f, 0.5f},
                {0.5f, 0.25f},
                {0.25f, 0.5f}
            };

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();
                Gl.glRotatef(330.0f, 1.0f, 0.0f, 0.0f);
                Gl.glScalef(0.5f, 0.5f, 0.5f);

                Glu.gluBeginSurface(nurb);
                    Glu.gluNurbsSurface(nurb, 8, knots, 8, knots, 4 * 3, 3, controlPoints, 4, 4, Gl.GL_MAP2_VERTEX_3);
                    Glu.gluBeginTrim(nurb);
                        Glu.gluPwlCurve(nurb, 5, edgePoints, 2, Glu.GLU_MAP1_TRIM_2);
                    Glu.gluEndTrim(nurb);
                    Glu.gluBeginTrim(nurb);
                        Glu.gluNurbsCurve(nurb, 8, curveKnots, 2, curvePoints, 4, Glu.GLU_MAP1_TRIM_2);
                        Glu.gluPwlCurve(nurb, 3, pwlPoints, 2, Glu.GLU_MAP1_TRIM_2);
                    Glu.gluEndTrim(nurb);
                Glu.gluEndSurface(nurb);
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

        #region NurbsError(int errorCode)
        private static void NurbsError(int errorCode) {
            Console.WriteLine("Nurbs Error: {0}", Glu.gluErrorString(errorCode));
            Environment.Exit(1);
        }
        #endregion NurbsError(int errorCode)

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float) w / (float) h, 3.0, 8.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glTranslatef(0.0f, 0.0f, -5.0f);
        }
        #endregion Reshape(int w, int h)
    }
}
