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
    ///     This program uses evaluators to generate a curved surface and automatically
    ///     generated texture coordinates.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/texturesurf.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class TextureSurf {
        // --- Fields ---
        #region Private Constants
        private const int IMAGEWIDTH = 64;
        private const int IMAGEHEIGHT = 64;
        #endregion Private Constants

        #region Private Fields
        private static byte[] image = new byte[IMAGEWIDTH * IMAGEHEIGHT * 3];

        private static float[/* 4*4*3 */] controlPoints = {
            -1.5f, -1.5f, 4.0f,
            -0.5f, -1.5f, 2.0f,
            0.5f, -1.5f, -1.0f,
            1.5f, -1.5f, 2.0f,
        
            -1.5f, -0.5f, 1.0f,
            -0.5f, -0.5f, 3.0f,
            0.5f, -0.5f, 0.0f,
            1.5f, -0.5f, -1.0f,
        
            -1.5f, 0.5f, 4.0f,
            -0.5f, 0.5f, 0.0f,
            0.5f, 0.5f, 3.0f,
            1.5f, 0.5f, 4.0f,
        
            -1.5f, 1.5f, -2.0f,
            -0.5f, 1.5f, -2.0f,
            0.5f, 1.5f, 0.0f,
            1.5f, 1.5f, -1.0f
        };

        private static float[/* 2*2*2 */] texturePoints = {
                0.0f, 0.0f,
                0.0f, 1.0f,
            
                1.0f, 0.0f,
                1.0f, 1.0f
        };
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(500, 500);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("TextureSurf");
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
            Gl.glMap2f(Gl.GL_MAP2_VERTEX_3, 0, 1, 3, 4, 0, 1, 12, 4, controlPoints);
            Gl.glMap2f(Gl.GL_MAP2_TEXTURE_COORD_2, 0, 1, 2, 2, 0, 1, 4, 2, texturePoints);
            Gl.glEnable(Gl.GL_MAP2_TEXTURE_COORD_2);
            Gl.glEnable(Gl.GL_MAP2_VERTEX_3);
            Gl.glMapGrid2f(20, 0, 1, 20, 0, 1);
            MakeImage();
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_DECAL);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, IMAGEWIDTH, IMAGEHEIGHT, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, image);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glShadeModel(Gl.GL_FLAT);
        }
        #endregion Init()

        #region MakeImage()
        private static void MakeImage() {
            int i, j;
            float ti, tj;
   
            for(i = 0; i < IMAGEWIDTH; i++) {
                ti = 2.0f * 3.14159265f * i / IMAGEWIDTH;
                for(j = 0; j < IMAGEHEIGHT; j++) {
                    tj = 2.0f * 3.14159265f * j / IMAGEHEIGHT;
                    image[3 * (IMAGEHEIGHT * i + j)] = (byte) (127 * (1.0 + Math.Sin(ti)));
                    image[3 * (IMAGEHEIGHT * i + j) + 1] = (byte) (127 * (1.0 + Math.Cos(2 * tj)));
                    image[3 * (IMAGEHEIGHT * i + j) + 2] = (byte) (127 * (1.0 + Math.Cos(ti + tj)));
                }
            }
        }
        #endregion MakeImage()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glEvalMesh2(Gl.GL_FILL, 0, 20, 0, 20);
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
                Gl.glOrtho(-4.0, 4.0, -4.0 * (float) h / (float) w, 4.0 * (float) h / (float) w, -4.0, 4.0);
            }
            else {
                Gl.glOrtho(-4.0 * (float) w / (float) h, 4.0 * (float) w / (float) h, -4.0, 4.0, -4.0, 4.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glRotatef(85.0f, 1.0f, 1.0f, 1.0f);
        }
        #endregion Reshape(int w, int h)
    }
}
