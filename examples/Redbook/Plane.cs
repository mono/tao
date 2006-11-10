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
/*
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
    ///     This program shows couple quads, with differing materials and lighting.
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
    public sealed class Plane {
        // --- Entry Point ---
        #region Run()
        /// <summary>
        ///     <para>
        ///         Open window with initial window size, title bar, RGBA display mode, and
        ///         handle input events.
        ///     </para>
        /// </summary>
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(500, 200);
            Glut.glutCreateWindow("Plane");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region DrawPlane()
        private static void DrawPlane() {
            Gl.glBegin(Gl.GL_QUADS);
                Gl.glNormal3f(0.0f, 0.0f, 1.0f);
                Gl.glVertex3f(-1.0f, -1.0f, 0.0f);
                Gl.glVertex3f(0.0f, -1.0f, 0.0f);
                Gl.glVertex3f(0.0f, 0.0f, 0.0f);
                Gl.glVertex3f(-1.0f, 0.0f, 0.0f);

                Gl.glNormal3f(0.0f, 0.0f, 1.0f);
                Gl.glVertex3f(0.0f, -1.0f, 0.0f);
                Gl.glVertex3f(1.0f, -1.0f, 0.0f);
                Gl.glVertex3f(1.0f, 0.0f, 0.0f);
                Gl.glVertex3f(0.0f, 0.0f, 0.0f);

                Gl.glNormal3f(0.0f, 0.0f, 1.0f);
                Gl.glVertex3f(0.0f, 0.0f, 0.0f);
                Gl.glVertex3f(1.0f, 0.0f, 0.0f);
                Gl.glVertex3f(1.0f, 1.0f, 0.0f);
                Gl.glVertex3f(0.0f, 1.0f, 0.0f);

                Gl.glNormal3f(0.0f, 0.0f, 1.0f);
                Gl.glVertex3f(0.0f, 0.0f, 0.0f);
                Gl.glVertex3f(0.0f, 1.0f, 0.0f);
                Gl.glVertex3f(-1.0f, 1.0f, 0.0f);
                Gl.glVertex3f(-1.0f, 0.0f, 0.0f);
            Gl.glEnd();
        }
        #endregion DrawPlane()

        #region Init()
        /// <summary>
        ///     <para>
        ///         Initialize light source, material property, and lighting model.
        ///     </para>
        /// </summary>
        private static void Init() {
            // materialSpecular and materialShininess are NOT default values
            float[] materialAmbient = {0.0f, 0.0f, 0.0f, 1.0f};
            float[] materialDiffuse = {0.4f, 0.4f, 0.4f, 1.0f};
            float[] materialSpecular = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] materialShininess = {15.0f};
            float[] lightAmbient = {0.0f, 0.0f, 0.0f, 1.0f};
            float[] lightDiffuse = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] lightSpecular = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] lightModelAmbient = {0.2f, 0.2f, 0.2f, 1.0f};

            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialAmbient);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialSpecular);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, materialShininess);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, lightAmbient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, lightDiffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, lightSpecular);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, lightModelAmbient);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glDepthFunc(Gl.GL_LESS);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
        }
        #endregion Init()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            float[] infiniteLight = {1.0f, 1.0f, 1.0f, 0.0f};
            float[] localLight = {1.0f, 1.0f, 1.0f, 1.0f};

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glPushMatrix ();
                Gl.glTranslatef(-1.5f, 0.0f, 0.0f);
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, infiniteLight);
                DrawPlane();
            Gl.glPopMatrix();

            Gl.glPushMatrix ();
                Gl.glTranslatef(1.5f, 0.0f, 0.0f);
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, localLight);
                DrawPlane();
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
        private static void Reshape(int w, int h) {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            if(w <= h) {
                Gl.glOrtho (-1.5, 1.5, -1.5 * (double) h / (double) w, 1.5 * (double) h / (double) w, -10.0, 10.0);
            }
            else {
                Gl.glOrtho(-1.5 * (double) w / (double) h, 1.5 * (double) w / (double) h, -1.5, 1.5, -10.0, 10.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }
        #endregion Reshape(int w, int h)
    }
}
