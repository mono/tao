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
    ///     This program demonstrates drawing pixels and shows the effect of
    ///     Gl.glDrawPixels(), Gl.glCopyPixels(), and Gl.glPixelZoom().  Interaction:
    ///     moving the mouse while pressing the mouse button will copy the image in the
    ///     lower-left corner of the window to the mouse position, using the current pixel
    ///     zoom factors.  There is no attempt to prevent you from drawing over the original
    ///     image.  If you press the 'r' key, the original image and zoom factors are reset.
    ///     If you press the 'z' or 'Z' keys, you change the zoom factors.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/image.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Image {
        // --- Fields ---
        #region Private Constants
        private const int CHECKWIDTH = 64;
        private const int CHECKHEIGHT = 64;
        #endregion Private Constants

        #region Private Fields
        private static byte[ , , ] checkImage = new byte[CHECKWIDTH, CHECKHEIGHT, 3];
        private static double zoomFactor = 1.0;
        private static int height;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(250, 250);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("Image");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutMotionFunc(new Glut.MotionCallback(Motion));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region Init()
        private static void Init() {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glShadeModel(Gl.GL_FLAT);
            MakeCheckImage();
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
        }
        #endregion Init()

        #region MakeCheckImage()
        private static void MakeCheckImage() {
            int i, j, c;

            for(i = 0; i < CHECKWIDTH; i++) {
                for(j = 0; j < CHECKHEIGHT; j++) {
                    if(((i & 0x8) == 0) ^ ((j & 0x8) == 0)) {
                        c = 255;
                    }
                    else {
                        c = 0;
                    }
                    checkImage[i, j, 0] = (byte) c;
                    checkImage[i, j, 1] = (byte) c;
                    checkImage[i, j, 2] = (byte) c;
                }
            }
        }
        #endregion MakeCheckImage()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glRasterPos2i(0, 0);
            Gl.glDrawPixels(CHECKWIDTH, CHECKHEIGHT, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, checkImage);
            Gl.glFlush();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case 27:
                    Environment.Exit(0);
                    break;
                case (byte) 'r':
                case (byte) 'R':
                    zoomFactor = 1.0;
                    Glut.glutPostRedisplay();
                    Console.WriteLine("zoomFactor reset to 1.0");
                    break;
                case (byte) 'z':
                    zoomFactor += 0.5;
                    if(zoomFactor >= 3.0) {
                        zoomFactor = 3.0;
                    }
                    Console.WriteLine("zoomFactor is now {0:F1}", zoomFactor);
                    break;
                case (byte) 'Z':
                    zoomFactor -= 0.5;
                    if(zoomFactor <= 0.5) {
                        zoomFactor = 0.5;
                    }
                    Console.WriteLine("zoomFactor is now {0:F1}", zoomFactor);
                    break;
                default:
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Motion(int x, int y)
        private static void Motion(int x, int y) {
            Gl.glRasterPos2i(x, height - y);
            Gl.glPixelZoom((float) zoomFactor, (float) zoomFactor);
            Gl.glCopyPixels(0, 0, CHECKWIDTH, CHECKHEIGHT, Gl.GL_COLOR);
            Gl.glPixelZoom(1.0f, 1.0f);
            Gl.glFlush();
        }
        #endregion Motion(int x, int y)

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            Gl.glViewport(0, 0, w, h);
            height = h;
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, (double) w, 0.0, (double) h);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity ();
        }
        #endregion Reshape(int w, int h)
    }
}
