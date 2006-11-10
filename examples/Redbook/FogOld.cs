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
/* Copyright (c) Mark J. Kilgard, 1994. */
/**
 * (c) Copyright 1993, Silicon Graphics, Inc.
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
 * OpenGL(TM) is a trademark of Silicon Graphics, Inc.
 */
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Redbook {
    #region Class Documentation
    /// <summary>
    ///     This program draws 5 red teapots, each at a different z distance from the eye,
    ///     in different types of fog.  Pressing the left mouse button chooses between 3
    ///     types of fog:  exponential, exponential squared, and linear.  In this program,
    ///     there is a fixed density value, as well as fixed start and end values for the
    ///     linear fog.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Mark J. Kilgard
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class FogOld {
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
            Glut.glutInitWindowSize(450, 150);
            Glut.glutCreateWindow("FogOld");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));

            Glut.glutCreateMenu(new Glut.CreateMenuCallback(Menu));
            Glut.glutAddMenuEntry("Fog EXP", Gl.GL_EXP);
            Glut.glutAddMenuEntry("Fog EXP2", Gl.GL_EXP2);
            Glut.glutAddMenuEntry("Fog LINEAR", Gl.GL_LINEAR);
            Glut.glutAddMenuEntry("Quit", 0);
            Glut.glutAttachMenu(Glut.GLUT_RIGHT_BUTTON);

            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region Init()
        /// <summary>
        ///     <para>
        ///         Initialize z-buffer, projection matrix, light source, and lighting model.  Do
        ///         not specify a material property here.
        ///     </para>
        /// </summary>
        private static void Init() {
            float[] position = {0.0f, 3.0f, 3.0f, 0.0f};
            float[] localView = {0.0f};
            float[] fogColor = {0.5f, 0.5f, 0.5f, 1.0f};

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glDepthFunc(Gl.GL_LESS);

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, position);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, localView);

            Gl.glFrontFace(Gl.GL_CW);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_AUTO_NORMAL);
            Gl.glEnable(Gl.GL_NORMALIZE);
            Gl.glEnable(Gl.GL_FOG);

            fogMode = Gl.GL_EXP;
            Gl.glFogi(Gl.GL_FOG_MODE, fogMode);
            Gl.glFogfv(Gl.GL_FOG_COLOR, fogColor);
            Gl.glFogf(Gl.GL_FOG_DENSITY, 0.35f);
            Gl.glHint(Gl.GL_FOG_HINT, Gl.GL_DONT_CARE);
            Gl.glClearColor(0.5f, 0.5f, 0.5f, 1.0f);
        }
        #endregion Init()

        #region RenderRedTeapot(float x, float y, float z)
        private static void RenderRedTeapot(float x, float y, float z) {
            float[] mat;

            Gl.glPushMatrix();
                Gl.glTranslatef(x, y, z);
                mat = new float[4];
                mat[0] = 0.1745f;
                mat[1] = 0.01175f;
                mat[2] = 0.01175f;
                mat[3] = 1.0f;
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, mat);
                mat = new float[3];
                mat[0] = 0.61424f;
                mat[1] = 0.04136f;
                mat[2] = 0.04136f;
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat);
                mat[0] = 0.727811f;
                mat[1] = 0.626959f;
                mat[2] = 0.626959f;
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, mat);
                Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, 0.6f * 128.0f);
                Glut.glutSolidTeapot(1.0);
            Gl.glPopMatrix();
        }
        #endregion RenderRedTeapot(float x, float y, float z)

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     <para>
        ///         Display() draws 5 teapots at different z positions.
        ///     </para>
        /// </summary>
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            RenderRedTeapot(-4.0f, -0.5f, -1.0f);
            RenderRedTeapot(-2.0f, -0.5f, -2.0f);
            RenderRedTeapot(0.0f, -0.5f, -3.0f);
            RenderRedTeapot(2.0f, -0.5f, -4.0f);
            RenderRedTeapot(4.0f, -0.5f, -5.0f);
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

        #region Menu(int mode)
        private static void Menu(int mode) {
            switch(mode) {
                case Gl.GL_LINEAR:
                    Gl.glFogf(Gl.GL_FOG_START, 1.0f);
                    Gl.glFogf(Gl.GL_FOG_END, 5.0f);
                    Gl.glFogi(Gl.GL_FOG_MODE, mode);
                    Glut.glutPostRedisplay();
                    break;
                case Gl.GL_EXP2:
                case Gl.GL_EXP:
                    Gl.glFogi(Gl.GL_FOG_MODE, mode);
                    Glut.glutPostRedisplay();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion Menu(int mode)

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            if(w <= (h * 3)) {
                Gl.glOrtho(-6.0, 6.0, -2.0 * ((float) h * 3) / (float) w, 2.0 * ((float) h * 3) / (float) w, 0.0, 10.0);
            }
            else {
                Gl.glOrtho(-6.0 * (float) w / ((float) h * 3), 6.0 * (float) w / ((float) h * 3), -2.0, 2.0, 0.0, 10.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        #endregion Reshape(int w, int h)
    }
}
