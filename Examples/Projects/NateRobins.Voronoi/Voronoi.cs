#region License
/*
BSD License
Copyright ©2003-2004 Randy Ridge
http://www.randyridge.com/Tao/Default.aspx
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

1. Redistributions of source code must retain the above copyright notice,
   this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither Randy Ridge nor the names of any Tao contributors may be used to
   endorse or promote products derived from this software without specific
   prior written permission.

   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
   "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
   LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
   FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
   COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
   INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
   BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
   LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
   CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
   LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
   ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
   POSSIBILITY OF SUCH DAMAGE.
*/
#endregion License

#region Original Credits / License
/* 
   voronoi.c
   Nate Robins, 1997.

   Uses the depth buffer to intersect cones drawn at each point
   selected by the user, thus creating a voronoi diagram.
 */
#endregion Original Credits / License

using System;
using Tao.Glut;
using Tao.OpenGl;

namespace NateRobins {
    #region Class Documentation
    /// <summary>
    ///     Uses the depth buffer to intersect cones drawn at each point selected by the
    ///     user, thus creating a voronoi diagram.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Nate Robins
    ///         http://www.xmission.com/~nate/sgi.html
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.randyridge.com/Tao/Default.aspx
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Voronoi {
        // --- Fields ---
        #region Private Fields
        private static Node points;
        private static int width = 256;
        private static int height = 256;
        private static bool drawPoints = false;
        private static Random random = new Random();
        #endregion Private Fields

        // --- Entry Point ---
        #region Main(string[] args)
        [STAThread]
        public static void Main(string[] args) {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowPosition(50, 50);
            Glut.glutCreateWindow("Voronoi");

            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutMouseFunc(new Glut.MouseCallback(Mouse));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));

            Glut.glutCreateMenu(new Glut.CreateMenuCallback(Menu));
            Glut.glutAddMenuEntry("Voronoi", 0);
            Glut.glutAddMenuEntry("", 0);
            Glut.glutAddMenuEntry("[r] Reset", (int) 'r');
            Glut.glutAddMenuEntry("[p] Toggle points", (int) 'p');
            Glut.glutAddMenuEntry("", 0);
            Glut.glutAddMenuEntry("Quit", 27);
            Glut.glutAttachMenu(Glut.GLUT_RIGHT_BUTTON);

            Init();

            Glut.glutMainLoop();
        }
        #endregion Main(string[] args)

        // --- Application Methods ---
        #region Init()
        private static void Init() {
            Node point;

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glDepthFunc(Gl.GL_LEQUAL);
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glPointSize(4.0f);

            while(points != null) {
                point = points;
                points = points.Next;
                point = null;
            }
        }
        #endregion Init()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            Node point;

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            point = points;
            while(point != null) {
                Gl.glPushMatrix();
                    Gl.glColor3ub(point.R, point.G, point.B);
                    Gl.glTranslatef(point.X, point.Y, 0.0f);
                    Glut.glutSolidCone(width > height ? width : height, 1.0, 32, 1);
                    if(drawPoints) {
                        Gl.glDepthFunc(Gl.GL_ALWAYS);
                        Gl.glColor3ub(255, 255, 255);
                        Gl.glBegin(Gl.GL_POINTS);
                            Gl.glVertex2i(0, 0);
                        Gl.glEnd();
                        Gl.glDepthFunc(Gl.GL_LEQUAL);
                    }
                Gl.glPopMatrix();
                point = point.Next;
            }
  
            Glut.glutSwapBuffers();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            Node point;

            switch(key) {
                case 27:
                    while(points != null) {
                        point = points;
                        points = points.Next;
                        point = null;
                    }
                    Environment.Exit(0);
                    break;
                case (byte) 'r':
                case (byte) 'R':
                    while(points != null) {
                        point = points;
                        points = points.Next;
                        point = null;
                    }
                    break;
                case (byte) 'p':
                case (byte) 'P':
                    drawPoints = !drawPoints;
                    break;
                case (byte) '\r':
                    Init();
                    break;
                default:
                    break;
            }

            Glut.glutPostRedisplay();
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Menu(int value)
        private static void Menu(int value) {
            Keyboard((byte) value, 0, 0);
        }
        #endregion Menu(int value)

        #region Mouse(int button, int state, int x, int y)
        private static void Mouse(int button, int state, int x, int y) {
            Node point;

            if(button == Glut.GLUT_LEFT_BUTTON && state == Glut.GLUT_DOWN) {
                point = new Node();
                point.Next = points;
                point.X = x;
                point.Y = y;
                point.R = (byte) (random.Next() % 256);
                point.G = (byte) (random.Next() % 256);
                point.B = (byte) (random.Next() % 256);
                points = point;
                Glut.glutPostRedisplay();
            }
        }
        #endregion Mouse(int button, int state, int x, int y)

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            Node point;

            // Rescale points so they are in their 'relative' position when the window size
            // changes.
            point = points;
            while(point != null) {
                point.X *= (float) w / width;
                point.Y *= (float) h / height;
                point = point.Next;
            }
            width = w;
            height = h;

            Gl.glViewport(0, 0, width, height);
  
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0, width, height, 0, -1, 1);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
        }
        #endregion Reshape(int w, int h)
    }
}
