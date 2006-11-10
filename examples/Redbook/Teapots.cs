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
    ///     This program demonstrates lots of material properties.  A single light source
    ///     illuminates the objects.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/teapots.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Teapots {
        // --- Fields ---
        #region Private Fields
        private static int teapotList;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        /// <summary>
        ///     <para>
        ///         Main Loop.  Open window with initial window size, title bar, RGBA display
        ///         mode, and handle input events.
        ///     </para>
        /// </summary>
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(500, 600);
            Glut.glutInitWindowPosition(50, 50);
            Glut.glutCreateWindow("Teapots");
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
        /// Initialize depth buffer, projection matrix, light source, and lighting model.
        /// Do not specify a material property here.
        /// </summary>
        private static void Init() {
            float[] ambient = {0.0f, 0.0f, 0.0f, 1.0f};
            float[] diffuse = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] specular = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] position = {0.0f, 3.0f, 3.0f, 0.0f};

            float[] lmodel_ambient = {0.2f, 0.2f, 0.2f, 1.0f};
            float[] local_view = {0.0f};

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, position);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, local_view);

            Gl.glFrontFace(Gl.GL_CW);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_AUTO_NORMAL);
            Gl.glEnable(Gl.GL_NORMALIZE);
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            // Be effecient, make teapot display list
            teapotList = Gl.glGenLists(1);
            Gl.glNewList(teapotList, Gl.GL_COMPILE);
                Glut.glutSolidTeapot(1.0);
            Gl.glEndList();
        }
        #endregion Init()

        #region RenderTeapot(float x, float y, float ambr, float ambg, float ambb, float difr, float difg, float difb, float specr, float specg, float specb, float shine)
        /// <summary>
        ///     <para>
        ///         Move object into position.  Use 3rd through 12th parameters to specify the
        ///         material property.  Draw a teapot.
        ///     </para>
        /// </summary>
        private static void RenderTeapot(float x, float y, float ambr, float ambg, float ambb, float difr, float difg, float difb, float specr, float specg, float specb, float shine) {
            float[] mat = new float[4];

            Gl.glPushMatrix();
                Gl.glTranslatef(x, y, 0.0f);
                mat[0] = ambr;
                mat[1] = ambg;
                mat[2] = ambb;
                mat[3] = 1.0f;
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, mat);
                mat[0] = difr;
                mat[1] = difg;
                mat[2] = difb;
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat);
                mat[0] = specr;
                mat[1] = specg;
                mat[2] = specb;
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, mat);
                Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, shine * 128.0f);
                Gl.glCallList(teapotList);
            Gl.glPopMatrix();
        }
        #endregion RenderTeapot(float x, float y, float ambr, float ambg, float ambb, float difr, float difg, float difb, float specr, float specg, float specb, float shine)

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     <para>
        ///         First column:  emerald, jade, obsidian, pearl, ruby, turquoise.
        ///     </para>
        ///     <para>
        ///         2nd column:  brass, bronze, chrome, copper, gold, silver.
        ///     </para>
        ///     <para>
        ///         3rd column:  black, cyan, green, red, white, yellow plastic.
        ///     </para>
        ///     <para>
        ///         4th column:  black, cyan, green, red, white, yellow rubber.
        ///     </para>
        /// </summary>
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            RenderTeapot(2.0f, 17.0f, 0.0215f, 0.1745f, 0.0215f, 0.07568f, 0.61424f, 0.07568f, 0.633f, 0.727811f, 0.633f, 0.6f);
            RenderTeapot(2.0f, 14.0f, 0.135f, 0.2225f, 0.1575f, 0.54f, 0.89f, 0.63f, 0.316228f, 0.316228f, 0.316228f, 0.1f);
            RenderTeapot(2.0f, 11.0f, 0.05375f, 0.05f, 0.06625f, 0.18275f, 0.17f, 0.22525f, 0.332741f, 0.328634f, 0.346435f, 0.3f);
            RenderTeapot(2.0f, 8.0f, 0.25f, 0.20725f, 0.20725f, 1f, 0.829f, 0.829f, 0.296648f, 0.296648f, 0.296648f, 0.088f);
            RenderTeapot(2.0f, 5.0f, 0.1745f, 0.01175f, 0.01175f, 0.61424f, 0.04136f, 0.04136f, 0.727811f, 0.626959f, 0.626959f, 0.6f);
            RenderTeapot(2.0f, 2.0f, 0.1f, 0.18725f, 0.1745f, 0.396f, 0.74151f, 0.69102f, 0.297254f, 0.30829f, 0.306678f, 0.1f);
            RenderTeapot(6.0f, 17.0f, 0.329412f, 0.223529f, 0.027451f, 0.780392f, 0.568627f, 0.113725f, 0.992157f, 0.941176f, 0.807843f, 0.21794872f);
            RenderTeapot(6.0f, 14.0f, 0.2125f, 0.1275f, 0.054f, 0.714f, 0.4284f, 0.18144f, 0.393548f, 0.271906f, 0.166721f, 0.2f);
            RenderTeapot(6.0f, 11.0f, 0.25f, 0.25f, 0.25f, 0.4f, 0.4f, 0.4f, 0.774597f, 0.774597f, 0.774597f, 0.6f);
            RenderTeapot(6.0f, 8.0f, 0.19125f, 0.0735f, 0.0225f, 0.7038f, 0.27048f, 0.0828f, 0.256777f, 0.137622f, 0.086014f, 0.1f);
            RenderTeapot(6.0f, 5.0f, 0.24725f, 0.1995f, 0.0745f, 0.75164f, 0.60648f, 0.22648f, 0.628281f, 0.555802f, 0.366065f, 0.4f);
            RenderTeapot(6.0f, 2.0f, 0.19225f, 0.19225f, 0.19225f, 0.50754f, 0.50754f, 0.50754f, 0.508273f, 0.508273f, 0.508273f, 0.4f);
            RenderTeapot(10.0f, 17.0f, 0.0f, 0.0f, 0.0f, 0.01f, 0.01f, 0.01f, 0.50f, 0.50f, 0.50f, 0.25f);
            RenderTeapot(10.0f, 14.0f, 0.0f, 0.1f, 0.06f, 0.0f, 0.50980392f, 0.50980392f, 0.50196078f, 0.50196078f, 0.50196078f, 0.25f);
            RenderTeapot(10.0f, 11.0f, 0.0f, 0.0f, 0.0f, 0.1f, 0.35f, 0.1f, 0.45f, 0.55f, 0.45f, 0.25f);
            RenderTeapot(10.0f, 8.0f, 0.0f, 0.0f, 0.0f, 0.5f, 0.0f, 0.0f, 0.7f, 0.6f, 0.6f, 0.25f);
            RenderTeapot(10.0f, 5.0f, 0.0f, 0.0f, 0.0f, 0.55f, 0.55f, 0.55f, 0.70f, 0.70f, 0.70f, 0.25f);
            RenderTeapot(10.0f, 2.0f, 0.0f, 0.0f, 0.0f, 0.5f, 0.5f, 0.0f, 0.60f, 0.60f, 0.50f, 0.25f);
            RenderTeapot(14.0f, 17.0f, 0.02f, 0.02f, 0.02f, 0.01f, 0.01f, 0.01f, 0.4f, 0.4f, 0.4f, 0.078125f);
            RenderTeapot(14.0f, 14.0f, 0.0f, 0.05f, 0.05f, 0.4f, 0.5f, 0.5f, 0.04f, 0.7f, 0.7f, 0.078125f);
            RenderTeapot(14.0f, 11.0f, 0.0f, 0.05f, 0.0f, 0.4f, 0.5f, 0.4f, 0.04f, 0.7f, 0.04f, 0.078125f);
            RenderTeapot(14.0f, 8.0f, 0.05f, 0.0f, 0.0f, 0.5f, 0.4f, 0.4f, 0.7f, 0.04f, 0.04f, 0.078125f);
            RenderTeapot(14.0f, 5.0f, 0.05f, 0.05f, 0.05f, 0.5f, 0.5f, 0.5f, 0.7f, 0.7f, 0.7f, 0.078125f);
            RenderTeapot(14.0f, 2.0f, 0.05f, 0.05f, 0.0f, 0.5f, 0.5f, 0.4f, 0.7f, 0.7f, 0.04f, 0.078125f);
            Gl.glFlush();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case (byte) 27:
                    Environment.Exit(0);
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
                Gl.glOrtho(0.0, 16.0, 0.0, 16.0 * h / w, -10.0, 10.0);
            }
            else {
                Gl.glOrtho(0.0, 16.0 * w / h, 0.0, 16.0, -10.0, 10.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }
        #endregion Reshape(int w, int h)
    }
}
