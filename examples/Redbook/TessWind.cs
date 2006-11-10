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
    ///     This program demonstrates the winding rule polygon tessellation property.  Four
    ///     tessellated objects are drawn, each with very different contours.  When the w key
    ///     is pressed, the objects are drawn with a different winding rule.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/tesswind.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class TessWind {
        // --- Fields ---
        #region Private Fields
        private static double currentWinding = Glu.GLU_TESS_WINDING_ODD;
        private static Glu.GLUtesselator tess;
        private static int list;

        private static double[][] rects = new double[12][] {
            new double[] {50.0, 50.0, 0.0},
            new double[] {300.0, 50.0, 0.0},
            new double[] {300.0, 300.0, 0.0},
            new double[] {50.0, 300.0, 0.0},
            new double[] {100.0, 100.0, 0.0},
            new double[] {250.0, 100.0, 0.0},
            new double[] {250.0, 250.0, 0.0},
            new double[] {100.0, 250.0, 0.0},
            new double[] {150.0, 150.0, 0.0},
            new double[] {200.0, 150.0, 0.0},
            new double[] {200.0, 200.0, 0.0},
            new double[] {150.0, 200.0, 0.0}
        };
        private static double[][] spiral = new double[16][] {
            new double[] {400.0, 250.0, 0.0},
            new double[] {400.0, 50.0, 0.0},
            new double[] {50.0, 50.0, 0.0},
            new double[] {50.0, 400.0, 0.0},
            new double[] {350.0, 400.0, 0.0},
            new double[] {350.0, 100.0, 0.0},
            new double[] {100.0, 100.0, 0.0},
            new double[] {100.0, 350.0, 0.0},
            new double[] {300.0, 350.0, 0.0},
            new double[] {300.0, 150.0, 0.0},
            new double[] {150.0, 150.0, 0.0},
            new double[] {150.0, 300.0, 0.0},
            new double[] {250.0, 300.0, 0.0},
            new double[] {250.0, 200.0, 0.0},
            new double[] {200.0, 200.0, 0.0},
            new double[] {200.0, 250.0, 0.0}
        };
        private static double[][] quad1 = new double[4][] {
            new double[] {50.0, 150.0, 0.0},
            new double[] {350.0, 150.0, 0.0},
            new double[] {350.0, 200.0, 0.0},
            new double[] {50.0, 200.0, 0.0}
        };
        private static double[][] quad2 = new double[4][] {
            new double[] {100.0, 100.0, 0.0},
            new double[] {300.0, 100.0, 0.0},
            new double[] {300.0, 350.0, 0.0},
            new double[] {100.0, 350.0, 0.0}
        };
        private static double[][] tri = new double[3][] {
            new double[] {200.0, 50.0, 0.0},
            new double[] {250.0, 300.0, 0.0},
            new double[] {150.0, 300.0, 0.0}
        };
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(500, 500);
            Glut.glutCreateWindow("TessWind");
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
            Gl.glShadeModel(Gl.GL_FLAT);
            tess = Glu.gluNewTess();
            Glu.gluTessCallback(tess, Glu.GLU_TESS_VERTEX, new Glu.TessVertexCallback1(Gl.glVertex3dv));
            Glu.gluTessCallback(tess, Glu.GLU_TESS_BEGIN, new Glu.TessBeginCallback(Begin));
            Glu.gluTessCallback(tess, Glu.GLU_TESS_END, new Glu.TessEndCallback(End));
            Glu.gluTessCallback(tess, Glu.GLU_TESS_ERROR, new Glu.TessErrorCallback(Error));
            Glu.gluTessCallback(tess, Glu.GLU_TESS_COMBINE, new Glu.TessCombineCallback1(Combine));

            list = Gl.glGenLists(4);
            MakeNewLists();
        }
        #endregion Init()

        #region MakeNewLists()
        /// <summary>
        ///     <para>
        ///         Make four display lists, each with a different tessellated object.
        ///     </para>
        /// </summary>
        private static void MakeNewLists() {
            int i;

            Glu.gluTessProperty(tess, Glu.GLU_TESS_WINDING_RULE, currentWinding);

            Gl.glNewList(list, Gl.GL_COMPILE);
                Glu.gluTessBeginPolygon(tess, IntPtr.Zero);
                    Glu.gluTessBeginContour(tess);
                        for(i = 0; i < 4; i++) {
                            Glu.gluTessVertex(tess, rects[i], rects[i]);
                        }
                    Glu.gluTessEndContour(tess);
                    Glu.gluTessBeginContour(tess);
                        for(i = 4; i < 8; i++) {
                            Glu.gluTessVertex(tess, rects[i], rects[i]);
                        }
                    Glu.gluTessEndContour(tess);
                    Glu.gluTessBeginContour(tess);
                        for(i = 8; i < 12; i++) {
                            Glu.gluTessVertex(tess, rects[i], rects[i]);
                        }
                    Glu.gluTessEndContour(tess);
                Glu.gluTessEndPolygon(tess);
            Gl.glEndList();

            Gl.glNewList(list + 1, Gl.GL_COMPILE);
                Glu.gluTessBeginPolygon(tess, IntPtr.Zero);
                    Glu.gluTessBeginContour(tess);
                        for(i = 0; i < 4; i++) {
                            Glu.gluTessVertex(tess, rects[i], rects[i]);
                        }
                    Glu.gluTessEndContour(tess);
                    Glu.gluTessBeginContour(tess);
                        for(i = 7; i >= 4; i--) {
                            Glu.gluTessVertex(tess, rects[i], rects[i]);
                        }
                    Glu.gluTessEndContour(tess);
                    Glu.gluTessBeginContour(tess);
                        for(i = 11; i >= 8; i--) {
                            Glu.gluTessVertex(tess, rects[i], rects[i]);
                        }
                    Glu.gluTessEndContour(tess);
                Glu.gluTessEndPolygon(tess);
            Gl.glEndList();

            Gl.glNewList(list + 2, Gl.GL_COMPILE);
                Glu.gluTessBeginPolygon(tess, IntPtr.Zero);
                    Glu.gluTessBeginContour(tess);
                        for(i = 0; i < 16; i++) {
                            Glu.gluTessVertex(tess, spiral[i], spiral[i]);
                        }
                    Glu.gluTessEndContour(tess);
                Glu.gluTessEndPolygon(tess);
            Gl.glEndList();

            Gl.glNewList(list + 3, Gl.GL_COMPILE);
                Glu.gluTessBeginPolygon(tess, IntPtr.Zero);
                    Glu.gluTessBeginContour(tess);
                        for(i = 0; i < 4; i++) {
                            Glu.gluTessVertex(tess, quad1[i], quad1[i]);
                        }
                    Glu.gluTessEndContour(tess);
                    Glu.gluTessBeginContour(tess);
                        for(i = 0; i < 4; i++) {
                            Glu.gluTessVertex(tess, quad2[i], quad2[i]);
                        }
                    Glu.gluTessEndContour(tess);
                    Glu.gluTessBeginContour(tess);
                        for(i = 0; i < 3; i++) {
                            Glu.gluTessVertex(tess, tri[i], tri[i]);
                        }
                    Glu.gluTessEndContour(tess);
                Glu.gluTessEndPolygon(tess);
            Gl.glEndList();
        }
        #endregion MakeNewLists()

        // --- Callbacks ---
        #region Begin(int which)
        private static void Begin(int which) {
            Gl.glBegin(which);
        }
        #endregion Begin(int which)

        #region Combine(double[] coordinates, double[][] vertexData, float[] weight, double[] dataOut)
        /// <summary>
        ///     <para>
        ///         The Combine callback is used to create a new vertex when edges intersect.
        ///         coordinate location is trivial to calculate, but weight[4] may be used to
        ///         average color, normal, or texture coordinate data.
        ///     </para>
        /// </summary>
        private static void Combine(double[] coordinates, double[] vertexData, float[] weight, double[] dataOut) {
            double[] vertex = new double[3];

            vertex[0] = coordinates[0];
            vertex[1] = coordinates[1];
            vertex[2] = coordinates[2];
            dataOut = vertex;
        }
        #endregion Combine(double[] coordinates, double[][] vertexData, float[] weight, double[] dataOut)

        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glPushMatrix(); 
                Gl.glCallList(list);
                Gl.glTranslatef(0.0f, 500.0f, 0.0f);
                Gl.glCallList(list + 1);
                Gl.glTranslatef(500.0f, -500.0f, 0.0f);
                Gl.glCallList(list + 2);
                Gl.glTranslatef(0.0f, 500.0f, 0.0f);
                Gl.glCallList(list + 3);
            Gl.glPopMatrix();
            Gl.glFlush();
        }
        #endregion Display()

        #region End()
        private static void End() {
            Gl.glEnd();
        }
        #endregion End()

        #region Error(int errorCode)
        private static void Error(int errorCode) {
            Console.WriteLine("Tessellation Error: {0}", Glu.gluErrorString(errorCode));
            Environment.Exit(1);
        }
        #endregion Error(int errorCode)

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case 27:
                    Environment.Exit(0);
                    break;
                case (byte) 'w':
                case (byte) 'W':
                    if(currentWinding == Glu.GLU_TESS_WINDING_ODD) {
                        currentWinding = Glu.GLU_TESS_WINDING_NONZERO;
                    }
                    else if(currentWinding == Glu.GLU_TESS_WINDING_NONZERO) {
                        currentWinding = Glu.GLU_TESS_WINDING_POSITIVE;
                    }
                    else if(currentWinding == Glu.GLU_TESS_WINDING_POSITIVE) {
                        currentWinding = Glu.GLU_TESS_WINDING_NEGATIVE;
                    }
                    else if(currentWinding == Glu.GLU_TESS_WINDING_NEGATIVE) {
                        currentWinding = Glu.GLU_TESS_WINDING_ABS_GEQ_TWO;
                    }
                    else if(currentWinding == Glu.GLU_TESS_WINDING_ABS_GEQ_TWO) {
                        currentWinding = Glu.GLU_TESS_WINDING_ODD;
                    }
                    MakeNewLists();
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
                Glu.gluOrtho2D(0.0, 1000.0, 0.0, 1000.0 * (double) h / (double) w);
            }
            else {
                Glu.gluOrtho2D(0.0, 1000.0 * (double) w / (double) h, 0.0, 1000.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        #endregion Reshape(int w, int h)

        #region Vertex(double[] vertex)
        private static void Vertex(double[] vertex) {
            double[] pointer;

            pointer = vertex;
            //Gl.glColor3dv(pointer);
            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glVertex3dv(vertex);
        }
        #endregion Vertex(double[] vertex)
    }
}
