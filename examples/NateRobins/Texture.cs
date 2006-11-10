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
    texture.c
    Nate Robins, 1997

    A simple program to show how to do texture mapping.
 */
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace NateRobins {
    #region Class Documentation
    /// <summary>
    ///     A simple program to show how to do texture mapping.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Nate Robins
    ///         http://www.xmission.com/~nate/sgi.html
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Texture {
        // --- Fields ---
        #region Private Fields
        private static byte[] texture = {
            0x80, 0x80, 0x80, 0xff, 0xff, 0xff, 0x80, 0x80, 0x80, 0xff, 0xff, 0xff,
            0xff, 0xff, 0xff, 0x80, 0x80, 0x80, 0xff, 0xff, 0xff, 0x80, 0x80, 0x80,
            0x80, 0x80, 0x80, 0xff, 0xff, 0xff, 0x80, 0x80, 0x80, 0xff, 0xff, 0xff,
            0xff, 0xff, 0xff, 0x80, 0x80, 0x80, 0xff, 0xff, 0xff, 0x80, 0x80, 0x80,
        };
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_SINGLE);
            Glut.glutInitWindowSize(320, 320);
            Glut.glutInitWindowPosition(50, 50);
            Glut.glutCreateWindow("Texture");

            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));

            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glColor3ub(255, 255, 255);
            Gl.glBegin(Gl.GL_TRIANGLES);
                Gl.glNormal3f(0.0f, 0.0f, 1.0f);
                Gl.glColor3ub(255, 0, 0);
                Gl.glTexCoord2f(0.5f, 1.0f);
                Gl.glVertex2f(0.0f, 2.0f);
                Gl.glColor3ub(0, 255, 0);
                Gl.glTexCoord2f(0.0f, 0.0f);
                Gl.glVertex2f(-2.0f, -2.0f);
                Gl.glColor3ub(0, 0, 255);
                Gl.glTexCoord2f(1.0f, 0.0f);
                Gl.glVertex2f(2.0f, -2.0f);
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
                default:
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Reshape(int width, int height)
        private static void Reshape(int width, int height) {
            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(60, 1.0, 0.1, 1000.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0, 0, 5, 0, 0, 0, 0, 1, 0);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, 3, 4, 4, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, texture);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);
        }
        #endregion Reshape(int width, int height)
    }
}
