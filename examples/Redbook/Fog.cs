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
    ///     This program draws 5 red spheres, each at a different z distance from the eye,
    ///     in different types of fog.  Pressing the f key chooses between 3 types of 
    ///     fog:  exponential, exponential squared, and linear.  In this program, there is
    ///     a fixed density value, as well as fixed start and end values for the linear fog.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/fog.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Fog {
        // --- Fields ---
        #region Private Fields
        private static int fogMode;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        /// <summary>
        ///     <para>
        ///         Open window with initial window size, title bar, RGBA display mode, depth
        ///         buffer, and handle input events.
        ///     </para>
        /// </summary>
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(500, 500);
            Glut.glutCreateWindow("Fog");
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
        ///         Initialize depth buffer, fog, light source, material property, and lighting
        ///         model.
        ///     </para>
        /// </summary>
        private static void Init() {
            float[] position = {0.5f, 0.5f, 3.0f, 0.0f};

            Gl.glEnable(Gl.GL_DEPTH_TEST);

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, position);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            float[] mat = {0.1745f, 0.01175f, 0.01175f};
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, mat);
            mat[0] = 0.61424f;
            mat[1] = 0.04136f;
            mat[2] = 0.04136f;
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat);
            mat[0] = 0.727811f;
            mat[1] = 0.626959f;
            mat[2] = 0.626959f;
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, mat);
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, 0.6f * 128.0f);

            Gl.glEnable(Gl.GL_FOG);
            float[] fogColor = {0.5f, 0.5f, 0.5f, 1.0f};

            fogMode = Gl.GL_EXP;
            Gl.glFogi(Gl.GL_FOG_MODE, fogMode);
            Gl.glFogfv(Gl.GL_FOG_COLOR, fogColor);
            Gl.glFogf(Gl.GL_FOG_DENSITY, 0.35f);
            Gl.glHint(Gl.GL_FOG_HINT, Gl.GL_DONT_CARE);
            Gl.glFogf(Gl.GL_FOG_START, 1.0f);
            Gl.glFogf(Gl.GL_FOG_END, 5.0f);

            Gl.glClearColor(0.5f, 0.5f, 0.5f, 1.0f);  // fog color
        }
        #endregion Init()

        #region RenderSphere(float x, float y, float z)
        private static void RenderSphere(float x, float y, float z) {
            Gl.glPushMatrix();
                Gl.glTranslatef(x, y, z);
                Glut.glutSolidSphere(0.4, 16, 16);
            Gl.glPopMatrix();
        }
        #endregion RenderSphere(float x, float y, float z)

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     <para>
        ///         Display() draws 5 spheres at different z positions.
        ///     </para>
        /// </summary>
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            RenderSphere(-2.0f, -0.5f, -1.0f);
            RenderSphere(-1.0f, -0.5f, -2.0f);
            RenderSphere(0.0f, -0.5f, -3.0f);
            RenderSphere(1.0f, -0.5f, -4.0f);
            RenderSphere(2.0f, -0.5f, -5.0f);
            Gl.glFlush();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case 27:
                    Environment.Exit(0);
                    break;
                case (byte) 'f':
                case (byte) 'F':
                    if(fogMode == Gl.GL_EXP) {
                        fogMode = Gl.GL_EXP2;
                        Console.WriteLine("Fog mode is GL_EXP2");
                    }
                    else if(fogMode == Gl.GL_EXP2) {
                        fogMode = Gl.GL_LINEAR;
                        Console.WriteLine("Fog mode is GL_LINEAR");
                    }
                    else if(fogMode == Gl.GL_LINEAR) {
                        fogMode = Gl.GL_EXP;
                        Console.WriteLine("Fog mode is GL_EXP");
                    }
                    Gl.glFogi(Gl.GL_FOG_MODE, fogMode);
                    Glut.glutPostRedisplay();
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
                Gl.glOrtho(-2.5, 2.5, -2.5 * (float) h / (float) w, 2.5 * (float) h / (float) w, -10.0, 10.0);
            }
            else {
                Gl.glOrtho(-2.5 * (float) w / (float) h, 2.5 * (float) w / (float) h, -2.5, 2.5, -10.0, 10.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        #endregion Reshape(int w, int h)
    }
}
