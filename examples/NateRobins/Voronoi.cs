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
   voronoi.c
   Nate Robins, 1997.

   Uses the depth buffer to intersect cones drawn at each point
   selected by the user, thus creating a voronoi diagram.
 */
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
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
    ///         http://www.taoframework.com
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
        #region Run()
        [STAThread]
        public static void Run() {
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
        #endregion Run()

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
