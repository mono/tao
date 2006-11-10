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
    ///     This program draws a texture mapped teapot with automatically generated texture
    ///     coordinates.  The texture is rendered as stripes on the teapot.  Initially, the
    ///     object is drawn with texture coordinates based upon the object coordinates of the
    ///     vertex and distance from the plane x = 0.  Pressing the 'e' key changes the
    ///     coordinate generation to eye coordinates of the vertex.  Pressing the 'o' key
    ///     switches it back to the object coordinates.  Pressing the 's' key changes the
    ///     plane to a slanted one (x + y + z = 0).  Pressing the 'x' key switches it back to
    ///     x = 0.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/texgen.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class TexGen {
        // --- Fields ---
        #region Private Constants
        private const int STRIPEWIDTH = 32;
        #endregion Private Constants

        #region Private Fields
        private static byte[] stripeImage = new byte[STRIPEWIDTH * 4];
        private static int[] texture = new int[1];

        // planes for texture coordinate generation
        private static float[] xequalzero = {1.0f, 0.0f, 0.0f, 0.0f};
        private static float[] slanted = {1.0f, 1.0f, 1.0f, 0.0f};
        private static float[] currentCoeff;
        private static int currentPlane;
        private static int currentGenMode;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(256, 256);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("TexGen");
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
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glShadeModel(Gl.GL_SMOOTH);

            MakeStripeImage();
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);

            Gl.glGenTextures(1, texture);
            Gl.glBindTexture(Gl.GL_TEXTURE_1D, texture[0]);
            Gl.glTexParameteri(Gl.GL_TEXTURE_1D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_1D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_1D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexImage1D(Gl.GL_TEXTURE_1D, 0, Gl.GL_RGBA, STRIPEWIDTH, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, stripeImage);

            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);
            currentCoeff = xequalzero;
            currentGenMode = Gl.GL_OBJECT_LINEAR;
            currentPlane = Gl.GL_OBJECT_PLANE;
            Gl.glTexGeni(Gl.GL_S, Gl.GL_TEXTURE_GEN_MODE, currentGenMode);
            Gl.glTexGenfv(Gl.GL_S, currentPlane, currentCoeff);

            Gl.glEnable(Gl.GL_TEXTURE_GEN_S);
            Gl.glEnable(Gl.GL_TEXTURE_1D);
            Gl.glEnable(Gl.GL_CULL_FACE);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_AUTO_NORMAL);
            Gl.glEnable(Gl.GL_NORMALIZE);
            Gl.glFrontFace(Gl.GL_CW);
            Gl.glCullFace(Gl.GL_BACK);
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, 64.0f);
        }
        #endregion Init()

        #region MakeStripeImage()
        private static void MakeStripeImage() {
            for(int j = 0; j < STRIPEWIDTH; j++) {
                stripeImage[4 * j] = (byte) ((j <= 4) ? 255 : 0);
                stripeImage[4 * j + 1] = (byte) ((j > 4) ? 255 : 0);
                stripeImage[4 * j + 2] = (byte) 0;
                stripeImage[4 * j + 3] = (byte) 255;
            }
        }
        #endregion MakeStripeImage()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();
                Gl.glRotatef(45.0f, 0.0f, 0.0f, 1.0f);
                Gl.glBindTexture(Gl.GL_TEXTURE_1D, texture[0]);
                Glut.glutSolidTeapot(2.0);
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
                case (byte) 'e':
                case (byte) 'E':
                    currentGenMode = Gl.GL_EYE_LINEAR;
                    currentPlane = Gl.GL_EYE_PLANE;
                    Gl.glTexGeni(Gl.GL_S, Gl.GL_TEXTURE_GEN_MODE, currentGenMode);
                    Gl.glTexGenfv(Gl.GL_S, currentPlane, currentCoeff);
                    Glut.glutPostRedisplay();
                    break;
                case (byte) 'o':
                case (byte) 'O':
                    currentGenMode = Gl.GL_OBJECT_LINEAR;
                    currentPlane = Gl.GL_OBJECT_PLANE;
                    Gl.glTexGeni(Gl.GL_S, Gl.GL_TEXTURE_GEN_MODE, currentGenMode);
                    Gl.glTexGenfv(Gl.GL_S, currentPlane, currentCoeff);
                    Glut.glutPostRedisplay();
                    break;
                case (byte) 's':
                case (byte) 'S':
                    currentCoeff = slanted;
                    Gl.glTexGenfv(Gl.GL_S, currentPlane, currentCoeff);
                    Glut.glutPostRedisplay();
                    break;
                case (byte) 'x':
                case (byte) 'X':
                    currentCoeff = xequalzero;
                    Gl.glTexGenfv(Gl.GL_S, currentPlane, currentCoeff);
                    Glut.glutPostRedisplay();
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
                Gl.glOrtho(-3.5, 3.5, -3.5 * (float) h / (float) w, 3.5 * (float) h / (float) w, -3.5, 3.5);
            }
            else {
                Gl.glOrtho(-3.5 * (float) w / (float) h, 3.5 * (float) w / (float) h, -3.5, 3.5, -3.5, 3.5);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        #endregion Reshape(int w, int h)
    }
}
