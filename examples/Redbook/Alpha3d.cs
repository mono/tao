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
    ///     This program demonstrates how to intermix opaque and alpha blended polygons in
    ///     the same scene, by using glDepthMask.  Press the 'a' key to animate moving the
    ///     transparent object through the opaque object.  Press the 'r' key to reset the
    ///     scene.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/alpha3D.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Alpha3d {
        // --- Fields ---
        #region Private Constants
        private const float MAXZ = 8.0f;
        private const float MINZ = -8.0f;
        private const float ZINC = 0.4f;
        #endregion Private Constants

        #region Private Fields
        private static float solidZ = MAXZ;
        private static float transparentZ = MINZ;
        private static int sphereList, cubeList;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(500, 500);
            Glut.glutCreateWindow("Alpha3d");
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
            float[] materialSpecular = {1.0f, 1.0f, 1.0f, 0.15f};
            float[] materialShininess = {100.0f};
            float[] position = {0.5f, 0.5f, 1.0f, 0.0f};

            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, materialSpecular);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, materialShininess);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, position);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            sphereList = Gl.glGenLists(1);
            Gl.glNewList(sphereList, Gl.GL_COMPILE);
                Glut.glutSolidSphere(0.4f, 16, 16);
            Gl.glEndList();

            cubeList = Gl.glGenLists(1);
            Gl.glNewList(cubeList, Gl.GL_COMPILE);
                Glut.glutSolidCube(0.6f);
            Gl.glEndList();
        }
        #endregion Init()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            float[] materialSolid = {0.75f, 0.75f, 0.0f, 1.0f};
            float[] materialZero = {0.0f, 0.0f, 0.0f, 1.0f};
            float[] materialTransparent = {0.0f, 0.8f, 0.8f, 0.6f};
            float[] materialEmission = {0.0f, 0.3f, 0.3f, 0.6f};

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glPushMatrix();
                Gl.glTranslatef(-0.15f, -0.15f, solidZ);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialZero);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialSolid);
                Gl.glCallList(sphereList);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
                Gl.glTranslatef(0.15f, 0.15f, transparentZ);
                Gl.glRotatef(15.0f, 1.0f, 1.0f, 0.0f);
                Gl.glRotatef(30.0f, 0.0f, 1.0f, 0.0f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, materialEmission);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, materialTransparent);
                Gl.glEnable(Gl.GL_BLEND);
                Gl.glDepthMask((byte) Gl.GL_FALSE);
                Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);
                Gl.glCallList(cubeList);
                Gl.glDepthMask((byte) Gl.GL_TRUE);
                Gl.glDisable(Gl.GL_BLEND);
            Gl.glPopMatrix();

            Gl.glFlush();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case (byte) 'a':
                case (byte) 'A':
                    solidZ = MAXZ;
                    transparentZ = MINZ;
                    Glut.glutIdleFunc(new Glut.IdleCallback(Idle));
                    break;
                case (byte) 'r':
                case (byte) 'R':
                    solidZ = MAXZ;
                    transparentZ = MINZ;
                    Glut.glutPostRedisplay();
                    break;
                case (byte) 27:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Idle()
        private static void Idle() {
            if(solidZ <= MINZ || transparentZ >= MAXZ) {
                Glut.glutIdleFunc(null);
            }
            else {
                solidZ -= ZINC;
                transparentZ += ZINC;
                Glut.glutPostRedisplay();
            }
        }
        #endregion Idle()

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            if(w <= h) {
                Gl.glOrtho(-1.5, 1.5, -1.5 * h / w, 1.5 * h / w, -10.0, 10.0);
            }
            else {
                Gl.glOrtho(-1.5 * w / h, 1.5 * w / h, -1.5, 1.5, -10.0, 10.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        #endregion Reshape(int w, int h)
    }
}
