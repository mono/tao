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
    ///     This program demonstrates some characters of a stroke (vector) font.  The
    ///     characters are represented by display lists, which are given numbers which
    ///     correspond to the ASCII values of the characters.  Use of Gl.glCallLists()
    ///     is demonstrated.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/stroke.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Stroke {
        // --- Fields ---
        #region Private Constants
        private const int PT = 1;
        private const int STROKE = 2;
        private const int END = 3;
        #endregion Private Constants

        #region Private Fields
        private static string test1 = "A SPARE SERAPE APPEARS AS";
        private static string test2 = "APES PREPARE RARE PEPPERS";

        private static CharPoint[] Adata = {
            new CharPoint(0, 0, PT),
            new CharPoint(0, 9, PT),
            new CharPoint(1, 10, PT),
            new CharPoint(4, 10, PT),
            new CharPoint(5, 9, PT),
            new CharPoint(5, 0, STROKE),
            new CharPoint(0, 5, PT),
            new CharPoint(5, 5, END)
        };

		private static CharPoint[] Edata = {
			new CharPoint(5, 0, PT),
			new CharPoint(0, 0, PT),
			new CharPoint(0, 10, PT),
			new CharPoint(5, 10, STROKE),
			new CharPoint(0, 5, PT),
			new CharPoint(4, 5, END)
		};

		private static CharPoint[] Pdata = {
			new CharPoint(0, 0, PT),
			new CharPoint(0, 10, PT),
			new CharPoint(4, 10, PT),
			new CharPoint(5, 9, PT),
			new CharPoint(5, 6, PT),
			new CharPoint(4, 5, PT),
			new CharPoint(0, 5, END)
		};

		private static CharPoint[] Rdata = {
			new CharPoint(0, 0, PT),
			new CharPoint(0, 10, PT),
			new CharPoint(4, 10, PT),
			new CharPoint(5, 9, PT),
			new CharPoint(5, 6, PT),
			new CharPoint(4, 5, PT),
			new CharPoint(0, 5, STROKE),
			new CharPoint(3, 5, PT),
			new CharPoint(5, 0, END)
		};

		private static CharPoint[] Sdata = {
			new CharPoint(0, 1, PT),
			new CharPoint(1, 0, PT),
			new CharPoint(4, 0, PT),
			new CharPoint(5, 1, PT),
			new CharPoint(5, 4, PT),
			new CharPoint(4, 5, PT),
			new CharPoint(1, 5, PT),
			new CharPoint(0, 6, PT),
			new CharPoint(0, 9, PT),
			new CharPoint(1, 10, PT),
			new CharPoint(4, 10, PT),
			new CharPoint(5, 9, END)
		};
        #endregion Private Fields

        #region Private Structs
        private struct CharPoint {
            public float X;
            public float Y;
            public int Type;

            public CharPoint(float x, float y, int type) {
                X = x;
                Y = y;
                Type = type;
            }
        }
        #endregion Private Structs

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
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(440, 120);
            Glut.glutCreateWindow("Stroke");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region DrawLetter(CharPoint[] letter)
        /// <summary>
        ///     <para>
        ///         Interprets the instructions from the array for that letter and renders
        ///         the letter with line segments.
        ///     </para>
        /// </summary>
        private static void DrawLetter(CharPoint[] letter) {
            int i = 0;

            Gl.glBegin(Gl.GL_LINE_STRIP);
            while(i < letter.Length) {
                switch(letter[i].Type) {
                    case PT:
                        Gl.glVertex2f(letter[i].X, letter[i].Y);
                        break;
                    case STROKE:
                        Gl.glVertex2f(letter[i].X, letter[i].Y);
                        Gl.glEnd();
                        Gl.glBegin(Gl.GL_LINE_STRIP);
                        break;
                    case END:
                        Gl.glVertex2f(letter[i].X, letter[i].Y);
                        Gl.glEnd();
                        Gl.glTranslatef(8.0f, 0.0f, 0.0f);
                        return;
                }
                i++;
            }
        }
        #endregion DrawLetter(CharPoint[] letter)

        #region Init()
        /// <summary>
        ///     <para>
        ///         Create a display list for each of 6 characters.
        ///     </para>
        /// </summary>
        private static void Init() {
            int list;

            Gl.glShadeModel(Gl.GL_FLAT);

            list = Gl.glGenLists(128);
            Gl.glListBase(list);
            Gl.glNewList(list + 'A', Gl.GL_COMPILE);
                DrawLetter(Adata);
            Gl.glEndList();
            Gl.glNewList(list + 'E', Gl.GL_COMPILE);
                DrawLetter(Edata);
            Gl.glEndList();
            Gl.glNewList(list + 'P', Gl.GL_COMPILE);
                DrawLetter(Pdata);
            Gl.glEndList();
            Gl.glNewList(list + 'R', Gl.GL_COMPILE);
                DrawLetter(Rdata);
            Gl.glEndList();
            Gl.glNewList(list + 'S', Gl.GL_COMPILE);
                DrawLetter(Sdata);
            Gl.glEndList();
            Gl.glNewList(list + ' ', Gl.GL_COMPILE);
                Gl.glTranslatef(8.0f, 0.0f, 0.0f);
            Gl.glEndList();
        }
        #endregion Init()

        #region PrintStrokedString(string text)
        private static void PrintStrokedString(string text) {
            byte [] textbytes = new byte[text.Length];
            for (int i = 0; i < text.Length; i++) textbytes[i] = (byte) text[i];
            Gl.glCallLists(text.Length, Gl.GL_BYTE, textbytes);
        }
        #endregion PrintStrokedString(string text)

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glPushMatrix();
                Gl.glScalef(2.0f, 2.0f, 2.0f);
                Gl.glTranslatef(10.0f, 30.0f, 0.0f);
                PrintStrokedString(test1);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
                Gl.glScalef(2.0f, 2.0f, 2.0f);
                Gl.glTranslatef(10.0f, 13.0f, 0.0f);
                PrintStrokedString(test2);
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
                case (byte) ' ':
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
            Glu.gluOrtho2D(0.0, (double) w, 0.0, (double) h);
        }
        #endregion Reshape(int w, int h)
    }
}
