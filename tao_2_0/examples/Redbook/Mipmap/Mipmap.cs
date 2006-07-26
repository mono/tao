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
    ///     This program demonstrates using mipmaps for texture maps.  To overtly show the
    ///     effect of mipmaps, each mipmap reduction level has a solidly colored, contrasting
    ///     texture image.  Thus, the quadrilateral which is drawn is drawn with several
    ///     different colors.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/mipmap.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Mipmap {
        // --- Fields ---
        #region Private Fields
        private static byte[ , , ] mipmapImage32 = new byte[32, 32, 4];
        private static byte[ , , ] mipmapImage16 = new byte[16, 16, 4];
        private static byte[ , , ] mipmapImage8 = new byte[8, 8, 4];
        private static byte[ , , ] mipmapImage4 = new byte[4, 4, 4];
        private static byte[ , , ] mipmapImage2 = new byte[2, 2, 4];
        private static byte[ , , ] mipmapImage1 = new byte[1, 1, 4];
        private static int texture;
        #endregion Private Fields

        // --- Entry Point ---
        #region Main(string[] args)
        [STAThread]
        public static void Main(string[] args) {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(500, 500);
            Glut.glutCreateWindow("Mipmap");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
        #endregion Main(string[] args)

        // --- Application Methods ---
        #region Init()
        private static void Init() {
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glShadeModel(Gl.GL_FLAT);

            Gl.glTranslatef(0.0f, 0.0f, -3.6f);
            MakeImages();
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);

            Gl.glGenTextures(1, out texture);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST_MIPMAP_NEAREST);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, 32, 32, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, mipmapImage32);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 1, Gl.GL_RGBA, 16, 16, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, mipmapImage16);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 2, Gl.GL_RGBA, 8, 8, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, mipmapImage8);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 3, Gl.GL_RGBA, 4, 4, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, mipmapImage4);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 4, Gl.GL_RGBA, 2, 2, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, mipmapImage2);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 5, Gl.GL_RGBA, 1, 1, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, mipmapImage1);

            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_DECAL);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
        }
        #endregion Init()

        #region MakeImages()
        private static void MakeImages() {
            int i, j;

            for(i = 0; i < 32; i++) {
                for(j = 0; j < 32; j++) {
                    mipmapImage32[i, j, 0] = 255;
                    mipmapImage32[i, j, 1] = 255;
                    mipmapImage32[i, j, 2] = 0;
                    mipmapImage32[i, j, 3] = 255;
                }
            }
            for(i = 0; i < 16; i++) {
                for(j = 0; j < 16; j++) {
                    mipmapImage16[i, j, 0] = 255;
                    mipmapImage16[i, j, 1] = 0;
                    mipmapImage16[i, j, 2] = 255;
                    mipmapImage16[i, j, 3] = 255;
                }
            }
            for(i = 0; i < 8; i++) {
                for(j = 0; j < 8; j++) {
                    mipmapImage8[i, j, 0] = 255;
                    mipmapImage8[i, j, 1] = 0;
                    mipmapImage8[i, j, 2] = 0;
                    mipmapImage8[i, j, 3] = 255;
                }
            }
            for(i = 0; i < 4; i++) {
                for(j = 0; j < 4; j++) {
                    mipmapImage4[i, j, 0] = 0;
                    mipmapImage4[i, j, 1] = 255;
                    mipmapImage4[i, j, 2] = 0;
                    mipmapImage4[i, j, 3] = 255;
                }
            }
            for(i = 0; i < 2; i++) {
                for(j = 0; j < 2; j++) {
                    mipmapImage2[i, j, 0] = 0;
                    mipmapImage2[i, j, 1] = 0;
                    mipmapImage2[i, j, 2] = 255;
                    mipmapImage2[i, j, 3] = 255;
                }
            }
            mipmapImage1[0, 0, 0] = 255;
            mipmapImage1[0, 0, 1] = 255;
            mipmapImage1[0, 0, 2] = 255;
            mipmapImage1[0, 0, 3] = 255;
        }
        #endregion MakeImages()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture);
            Gl.glBegin(Gl.GL_QUADS);
                Gl.glTexCoord2f(0.0f, 0.0f);
                Gl.glVertex3f(-2.0f, -1.0f, 0.0f);
                Gl.glTexCoord2f(0.0f, 8.0f);
                Gl.glVertex3f(-2.0f, 1.0f, 0.0f);
                Gl.glTexCoord2f(8.0f, 8.0f);
                Gl.glVertex3f(2000.0f, 1.0f, -6000.0f);
                Gl.glTexCoord2f(8.0f, 0.0f);
                Gl.glVertex3f(2000.0f, -1.0f, -6000.0f);
            Gl.glEnd();
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
            Glu.gluPerspective(60.0, (float) w / (float) h, 1.0, 30000.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        #endregion Reshape(int w, int h)
    }
}
