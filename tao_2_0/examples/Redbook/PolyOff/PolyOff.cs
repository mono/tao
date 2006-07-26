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
    ///     This program demonstrates polygon offset to draw a shaded polygon and its
    ///     wireframe counterpart without ugly visual artifacts ("stitching").
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/polyoff.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class PolyOff {
        // --- Fields ---
        #region Private Fields
        private static int list;
        private static int spinX = 0;
        private static int spinY = 0;
        private static float distance = 0.0f;
        private static float polyFactor = 1.0f;
        private static float polyUnits = 1.0f;
        #endregion Private Fields

        // --- Entry Point ---
        #region Main(string[] args)
        [STAThread]
        public static void Main(string[] args) {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            Glut.glutCreateWindow("PolyOff");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutMouseFunc(new Glut.MouseCallback(Mouse));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
        #endregion Main(string[] args)

        // --- Application Methods ---
        #region Init()
        private static void Init() {
            float[] lightAmbient = {0.0f, 0.0f, 0.0f, 1.0f};
            float[] lightDiffuse = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] lightSpecular = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] lightPosition = {1.0f, 1.0f, 1.0f, 0.0f};
            float[] globalAmbient = {0.2f, 0.2f, 0.2f, 1.0f};

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            list = Gl.glGenLists(1);
            Gl.glNewList(list, Gl.GL_COMPILE);
                Glut.glutSolidSphere(1.0, 20, 12);
            Gl.glEndList();

            Gl.glEnable(Gl.GL_DEPTH_TEST);

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, lightAmbient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, lightDiffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, lightSpecular);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPosition);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, globalAmbient);
        }
        #endregion Init()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            float[] materialAmbient = {0.8f, 0.8f, 0.8f, 1.0f};
            float[] materialDiffuse = {1.0f, 0.0f, 0.5f, 1.0f};
            float[] materialSpecular = {1.0f, 1.0f, 1.0f, 1.0f};
            float[] gray = {0.8f, 0.8f, 0.8f, 1.0f};
            float[] black = {0.0f, 0.0f, 0.0f, 1.0f};

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();
                Gl.glTranslatef(0.0f, 0.0f, distance);
                Gl.glRotatef((float) spinX, 1.0f, 0.0f, 0.0f);
                Gl.glRotatef((float) spinY, 0.0f, 1.0f, 0.0f);

                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE, gray);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, black);
                Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, 0.0f);
                Gl.glEnable(Gl.GL_LIGHTING);
                Gl.glEnable(Gl.GL_LIGHT0);
                Gl.glEnable(Gl.GL_POLYGON_OFFSET_FILL);
                Gl.glPolygonOffset(polyFactor, polyUnits);
                Gl.glCallList(list);
                Gl.glDisable(Gl.GL_POLYGON_OFFSET_FILL);

                Gl.glDisable(Gl.GL_LIGHTING);
                Gl.glDisable(Gl.GL_LIGHT0);
                Gl.glColor3f(1.0f, 1.0f, 1.0f);
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
                Gl.glCallList(list);
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
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
                case (byte) 't':
                    if(distance < 4.0f) {
                        distance = (distance + 0.5f);
                        Glut.glutPostRedisplay();
                    }
                    break;
                case (byte) 'T':
                    if(distance > -5.0f) {
                        distance = (distance - 0.5f);
                        Glut.glutPostRedisplay();
                    }
                    break;
                case (byte) 'F':
                    polyFactor = polyFactor + 0.1f;
                    Console.WriteLine("polyFactor is {0}", polyFactor);
                    Glut.glutPostRedisplay();
                    break;
                case (byte) 'f':
                    polyFactor = polyFactor - 0.1f;
                    Console.WriteLine("polyFactor is {0}", polyFactor);
                    Glut.glutPostRedisplay();
                    break;
                case (byte) 'U':
                    polyUnits = polyUnits + 1.0f;
                    Console.WriteLine("polyUnits is {0}", polyUnits);
                    Glut.glutPostRedisplay();
                    break;
                case (byte) 'u':
                    polyUnits = polyUnits - 1.0f;
                    Console.WriteLine("polyUnits is {0}", polyUnits);
                    break;
                default:
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Mouse(int button, int state, int x, int y)
        private static void Mouse(int button, int state, int x, int y) {
            switch(button) {
                case Glut.GLUT_LEFT_BUTTON:
                    switch(state) {
                        case Glut.GLUT_DOWN:
                            spinX = (spinX + 5) % 360; 
                            Glut.glutPostRedisplay();
                            break;
                        default:
                            break;
                    }
                    break;
                case Glut.GLUT_RIGHT_BUTTON:
                    switch(state) {
                        case Glut.GLUT_DOWN:
                            spinY = (spinY + 5) % 360; 
                            Glut.glutPostRedisplay();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion Mouse(int button, int state, int x, int y)

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45.0, (float) w / (float) h, 1.0, 10.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0.0, 0.0, 5.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
        }
        #endregion Reshape(int w, int h)
    }
}
