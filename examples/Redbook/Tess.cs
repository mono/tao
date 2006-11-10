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
    ///     <para>
    ///         This program demonstrates polygon tessellation.  Two tesselated objects are
    ///         drawn.  The first is a rectangle with a triangular hole.  The second is a
    ///         smooth shaded, self-intersecting star.
    ///     </para>
    ///     <para>
    ///         Note the exterior rectangle is drawn with its vertices in counter-clockwise
    ///         order, but its interior clockwise.  Note the Combine callback is needed for
    ///         the self-intersecting star.  Also note that removing the TessProperty for
    ///         the star will make the interior unshaded (WINDING_ODD).
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Silicon Graphics, Inc.
    ///         http://www.opengl.org/developers/code/examples/redbook/tess.c
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Tess {
        // --- Fields ---
        #region Private Fields
        private static int startList;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(500, 500);
            Glut.glutCreateWindow("Tess");
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
            Glu.GLUtesselator tess;
            double[][] rect = new double[4][] {
                new double[] {50.0, 50.0, 0.0},
                new double[] {200.0, 50.0, 0.0},
                new double[] {200.0, 200.0, 0.0},
                new double[] {50.0, 200.0, 0.0}
            };
            double[][] tri = new double[3][] {
                new double[] {75.0, 75.0, 0.0},
                new double[] {125.0, 175.0, 0.0},
                new double[] {175.0, 75.0, 0.0}
            };
            double[][] star = new double[5][] {
                new double[] {250.0, 50.0, 0.0, 1.0, 0.0, 1.0},
                new double[] {325.0, 200.0, 0.0, 1.0, 1.0, 0.0},
                new double[] {400.0, 50.0, 0.0, 0.0, 1.0, 1.0},
                new double[] {250.0, 150.0, 0.0, 1.0, 0.0, 0.0},
                new double[] {400.0, 150.0, 0.0, 0.0, 1.0, 0.0}
            };

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            startList = Gl.glGenLists(2);

            tess = Glu.gluNewTess();
            Glu.gluTessCallback(tess, Glu.GLU_TESS_VERTEX, new Glu.TessVertexCallback1(Gl.glVertex3dv));
            Glu.gluTessCallback(tess, Glu.GLU_TESS_BEGIN, new Glu.TessBeginCallback(Begin));
            Glu.gluTessCallback(tess, Glu.GLU_TESS_END, new Glu.TessEndCallback(End));
            Glu.gluTessCallback(tess, Glu.GLU_TESS_ERROR, new Glu.TessErrorCallback(Error));

            // rectangle with triangular hole inside
            Gl.glNewList(startList, Gl.GL_COMPILE);
                Gl.glShadeModel(Gl.GL_FLAT);    
                Glu.gluTessBeginPolygon(tess, IntPtr.Zero);
                    Glu.gluTessBeginContour(tess);
                        Glu.gluTessVertex(tess, rect[0], rect[0]);
                        Glu.gluTessVertex(tess, rect[1], rect[1]);
                        Glu.gluTessVertex(tess, rect[2], rect[2]);
                        Glu.gluTessVertex(tess, rect[3], rect[3]);
                    Glu.gluTessEndContour(tess);
                    Glu.gluTessBeginContour(tess);
                        Glu.gluTessVertex(tess, tri[0], tri[0]);
                        Glu.gluTessVertex(tess, tri[1], tri[1]);
                        Glu.gluTessVertex(tess, tri[2], tri[2]);
                    Glu.gluTessEndContour(tess);
                Glu.gluTessEndPolygon(tess);
            Gl.glEndList();

            Glu.gluTessCallback(tess, Glu.GLU_TESS_VERTEX, new Glu.TessVertexCallback1(Vertex));
            Glu.gluTessCallback(tess, Glu.GLU_TESS_BEGIN, new Glu.TessBeginCallback(Begin));
            Glu.gluTessCallback(tess, Glu.GLU_TESS_END, new Glu.TessEndCallback(End));
            Glu.gluTessCallback(tess, Glu.GLU_TESS_ERROR, new Glu.TessErrorCallback(Error));
            Glu.gluTessCallback(tess, Glu.GLU_TESS_COMBINE, new Glu.TessCombineCallback1(Combine));

            // smooth shaded, self-intersecting star
            Gl.glNewList(startList + 1, Gl.GL_COMPILE);
                Gl.glShadeModel(Gl.GL_SMOOTH);    
                Glu.gluTessProperty(tess, Glu.GLU_TESS_WINDING_RULE, Glu.GLU_TESS_WINDING_POSITIVE);
                Glu.gluTessBeginPolygon(tess, IntPtr.Zero);
                    Glu.gluTessBeginContour(tess);
                        Glu.gluTessVertex(tess, star[0], star[0]);
                        Glu.gluTessVertex(tess, star[1], star[1]);
                        Glu.gluTessVertex(tess, star[2], star[2]);
                        Glu.gluTessVertex(tess, star[3], star[3]);
                        Glu.gluTessVertex(tess, star[4], star[4]);
                    Glu.gluTessEndContour(tess);
                Glu.gluTessEndPolygon(tess);
            Gl.glEndList();
            Glu.gluDeleteTess(tess);
        }
        #endregion Init()

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
        ///         average color, normal, or texture coordinate data.  In this program, color
        ///         is weighted.
        ///     </para>
        /// </summary>
        private static void Combine(double[] coordinates, double[] vertexData, float[] weight, double[] dataOut) {
            double[] vertex = new double[6];
            int i;

            vertex[0] = coordinates[0];
            vertex[1] = coordinates[1];
            vertex[2] = coordinates[2];

            for(i = 3; i < 6; i++) {
                vertex[i] = weight[0] * vertexData[i] + weight[1] * vertexData[i] + weight[2] * vertexData[i] + weight[3] * vertexData[i];
            }

            dataOut = vertex;
        }
        #endregion Combine(double[] coordinates, double[][] vertexData, float[] weight, double[] dataOut)

        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glCallList(startList);
            Gl.glCallList(startList + 1);
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
