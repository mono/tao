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
    ///     This program demonstrates the use of some of the Glu.gluQuadric* routines.
    ///     Quadric objects are created with some quadric properties and the callback routine
    ///     to handle errors.  Note that the cylinder has no top or bottom and the circle
    ///     has a hole in it.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/quadric.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Quadric {
        // --- Fields ---
        #region Private Fields
        private static int startList;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(500, 500);
            Glut.glutCreateWindow("Quadric");
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
            Glu.GLUquadric quadric;
            float[] materialAmbient = {0.5f, 0.5f, 0.5f, 1.0f};
            float[] materialSpecular = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] materialShininess = {50.0f};
            float[] lightPosition = {1.0f, 1.0f, 1.0f, 0.0f};
            float[] modelAmbient = {0.5f, 0.5f, 0.5f, 1.0f};

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, materialAmbient);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialSpecular);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, materialShininess);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPosition);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, modelAmbient);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            //  Create 4 display lists, each with a different quadric object.  Different drawing
            //  styles and surface normal specifications are demonstrated.
            startList = Gl.glGenLists(4);
            quadric = Glu.gluNewQuadric();
            Glu.gluQuadricCallback(quadric, Glu.GLU_ERROR, new Glu.QuadricErrorCallback(Error));

            Glu.gluQuadricDrawStyle(quadric, Glu.GLU_FILL); // smooth shaded
            Glu.gluQuadricNormals(quadric, Glu.GLU_SMOOTH);
            Gl.glNewList(startList, Gl.GL_COMPILE);
                Glu.gluSphere(quadric, 0.75, 15, 10);
            Gl.glEndList();

            Glu.gluQuadricDrawStyle(quadric, Glu.GLU_FILL); // flat shaded
            Glu.gluQuadricNormals(quadric, Glu.GLU_FLAT);
            Gl.glNewList(startList + 1, Gl.GL_COMPILE);
                Glu.gluCylinder(quadric, 0.5, 0.3, 1.0, 15, 5);
            Gl.glEndList();

            Glu.gluQuadricDrawStyle(quadric, Glu.GLU_LINE); // all polygons wireframe
            Glu.gluQuadricNormals(quadric, Glu.GLU_NONE);
            Gl.glNewList(startList + 2, Gl.GL_COMPILE);
                Glu.gluDisk(quadric, 0.25, 1.0, 20, 4);
            Gl.glEndList();

            Glu.gluQuadricDrawStyle(quadric, Glu.GLU_SILHOUETTE); // boundary only
            Glu.gluQuadricNormals(quadric, Glu.GLU_NONE);
            Gl.glNewList(startList + 3, Gl.GL_COMPILE);
                Glu.gluPartialDisk(quadric, 0.0, 1.0, 20, 4, 0.0, 225.0);
            Gl.glEndList();
        }
        #endregion Init()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();
                Gl.glEnable(Gl.GL_LIGHTING);
                Gl.glShadeModel(Gl.GL_SMOOTH);
                Gl.glTranslatef(-1.0f, -1.0f, 0.0f);
                Gl.glCallList(startList);

                Gl.glShadeModel(Gl.GL_FLAT);
                Gl.glTranslatef(0.0f, 2.0f, 0.0f);
                Gl.glPushMatrix();
                    Gl.glRotatef(300.0f, 1.0f, 0.0f, 0.0f);
                    Gl.glCallList(startList + 1);
                Gl.glPopMatrix();

                Gl.glDisable(Gl.GL_LIGHTING);
                Gl.glColor3f(0.0f, 1.0f, 1.0f);
                Gl.glTranslatef(2.0f, -2.0f, 0.0f);
                Gl.glCallList(startList + 2);

                Gl.glColor3f(1.0f, 1.0f, 0.0f);
                Gl.glTranslatef(0.0f, 2.0f, 0.0f);
                Gl.glCallList(startList + 3);
            Gl.glPopMatrix();
            Gl.glFlush();
        }
        #endregion Display()

        #region void Error(int errorCode)
        private static void Error(int errorCode) {
            string errorString;
            errorString = Glu.gluErrorString(errorCode);
            Console.WriteLine("Quadric Error: {0}", errorString);
            Environment.Exit(1);
        }
        #endregion void Error(int errorCode)

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
