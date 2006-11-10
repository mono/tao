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
    ///     This program demonstrates the use of the GL lighting model.  Several objects are
    ///     drawn using different material characteristics.  A single light source
    ///     illuminates the objects.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/material.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Material {
        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(600, 450);
            Glut.glutCreateWindow("Material");
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
        ///         Initialize Z-buffer, projection matrix, light source, and lighting model.  Do
        ///         not specify a material property here.
        ///     </para>
        /// </summary>
        private static void Init() {
            float[] ambient = {0.0f, 0.0f, 0.0f, 1.0f};
            float[] diffuse = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] specular = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] position = {0.0f, 3.0f, 2.0f, 0.0f};
            float[] modelAmbient = {0.4f, 0.4f, 0.4f, 1.0f};
            float[] localView = {0.0f};

            Gl.glClearColor(0.0f, 0.1f, 0.1f, 0.0f);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glShadeModel(Gl.GL_SMOOTH);

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, position);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, modelAmbient);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, localView);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
        }
        #endregion Init()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            /*  Draw twelve spheres in 3 rows with 4 columns.  
            *   The spheres in the first row have materials with no ambient reflection.
            *   The second row has materials with significant ambient reflection.
            *   The third row has materials with colored ambient reflection.
            *
            *   The first column has materials with blue, diffuse reflection only.
            *   The second column has blue diffuse reflection, as well as specular
            *   reflection with a low shininess exponent.
            *   The third column has blue diffuse reflection, as well as specular
            *   reflection with a high shininess exponent (a more concentrated highlight).
            *   The fourth column has materials which also include an emissive component.
            *
            *   Gl.glTranslatef() is used to move spheres to their appropriate locations.
            */
            float[] materialNone = {0.0f, 0.0f, 0.0f, 1.0f};
            float[] materialAmbient = {0.7f, 0.7f, 0.7f, 1.0f};
            float[] materialAmbientColor = {0.8f, 0.8f, 0.2f, 1.0f};
            float[] materialDiffuse = {0.1f, 0.5f, 0.8f, 1.0f};
            float[] materialSpecular = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] materialEmission = {0.3f, 0.2f, 0.2f, 0.0f};
            float[] shininessNone = {0.0f};
            float[] shininessLow = {5.0f};
            float[] shininessHigh = {100.0f};

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            // draw sphere in first row, first column diffuse reflection only; no ambient or
            // specular
            Gl.glPushMatrix();
                Gl.glTranslatef(-3.75f, 3.0f, 0.0f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininessNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialNone);
                Glut.glutSolidSphere(1.0f, 16, 16);
            Gl.glPopMatrix();

            // draw sphere in first row, second column diffuse and specular reflection; low
            // shininess; no ambient
            Gl.glPushMatrix();
                Gl.glTranslatef(-1.25f, 3.0f, 0.0f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialSpecular);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininessLow);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialNone);
                Glut.glutSolidSphere(1.0f, 16, 16);
            Gl.glPopMatrix();

            // draw sphere in first row, third column diffuse and specular reflection; high
            // shininess; no ambient
            Gl.glPushMatrix();
                Gl.glTranslatef(1.25f, 3.0f, 0.0f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialSpecular);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininessHigh);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialNone);
                Glut.glutSolidSphere(1.0f, 16, 16);
            Gl.glPopMatrix();

            // draw sphere in first row, fourth column diffuse reflection; emission; no ambient
            // or specular reflection
            Gl.glPushMatrix();
                Gl.glTranslatef(3.75f, 3.0f, 0.0f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininessNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialEmission);
                Glut.glutSolidSphere(1.0f, 16, 16);
            Gl.glPopMatrix();

            // draw sphere in second row, first column ambient and diffuse reflection; no
            // specular
            Gl.glPushMatrix();
                Gl.glTranslatef(-3.75f, 0.0f, 0.0f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialAmbient);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininessNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialNone);
                Glut.glutSolidSphere(1.0f, 16, 16);
            Gl.glPopMatrix();

            // draw sphere in second row, second column ambient, diffuse and specular reflection;
            // low shininess
            Gl.glPushMatrix();
                Gl.glTranslatef(-1.25f, 0.0f, 0.0f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialAmbient);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialSpecular);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininessLow);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialNone);
                Glut.glutSolidSphere(1.0f, 16, 16);
            Gl.glPopMatrix();

            // draw sphere in second row, third column ambient, diffuse and specular reflection;
            // high shininess
            Gl.glPushMatrix();
                Gl.glTranslatef(1.25f, 0.0f, 0.0f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialAmbient);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialSpecular);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininessHigh);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialNone);
                Glut.glutSolidSphere(1.0f, 16, 16);
            Gl.glPopMatrix();

            // draw sphere in second row, fourth column ambient and diffuse reflection; emission;
            // no specular
            Gl.glPushMatrix();
                Gl.glTranslatef(3.75f, 0.0f, 0.0f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialAmbient);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininessNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialEmission);
                Glut.glutSolidSphere(1.0f, 16, 16);
            Gl.glPopMatrix();

            // draw sphere in third row, first column colored ambient and diffuse reflection; no
            // specular
            Gl.glPushMatrix();
                Gl.glTranslatef(-3.75f, -3.0f, 0.0f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialAmbientColor);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininessNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialNone);
                Glut.glutSolidSphere(1.0f, 16, 16);
            Gl.glPopMatrix();

            // draw sphere in third row, second column colored ambient, diffuse and specular
            // reflection; low shininess
            Gl.glPushMatrix();
                Gl.glTranslatef(-1.25f, -3.0f, 0.0f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialAmbientColor);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialSpecular);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininessLow);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialNone);
                Glut.glutSolidSphere(1.0f, 16, 16);
            Gl.glPopMatrix();

            // draw sphere in third row, third column colored ambient, diffuse and specular
            // reflection; high shininess
            Gl.glPushMatrix();
                Gl.glTranslatef(1.25f, -3.0f, 0.0f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialAmbientColor);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialSpecular);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininessHigh);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialNone);
                Glut.glutSolidSphere(1.0f, 16, 16);
            Gl.glPopMatrix();

            // draw sphere in third row, fourth column colored ambient and diffuse reflection;
            // emission; no specular
            Gl.glPushMatrix();
                Gl.glTranslatef(3.75f, -3.0f, 0.0f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialAmbientColor);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininessNone);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialEmission);
                Glut.glutSolidSphere(1.0f, 16, 16);
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
            if(w <= h * 2) {
                Gl.glOrtho(-6.0, 6.0, -3.0 * ((float) h * 2) / (float) w, 3.0 * ((float) h * 2) / (float) w, -10.0, 10.0);
            }
            else {
                Gl.glOrtho(-6.0 * (float) w / ((float) h * 2), 6.0 * (float) w / ((float) h * 2), -3.0, 3.0, -10.0, 10.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        #endregion Reshape(int w, int h)
    }
}
