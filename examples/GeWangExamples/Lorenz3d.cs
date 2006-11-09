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
//-----------------------------------------------------------------------------
// File: lorenz3d.cpp
// Desc: 3d animation (with roller coaster view!) for lorenz attractor.
//
//       [L|R] mouse buttons - rotate ( 3rd person only )
//       's' start the tracer over
//       'p' toggle plot [all] or [to tracer]
//       'v' change view between [3rd person] and [roller coaster]
//       'm' toggle drawing mode between line | points
//       '-' or '=' zoom in or out ( 3rd person only )
//
// autumn 2000 - Ge Wang - implementation
//             - Dr. Xiaobai Sun (xiaobai@cs.duke.edu) - professor
//
//       http://www.gewang.com/projects/lorenz3d/
//-----------------------------------------------------------------------------
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace GeWangExamples
{
    #region Class Documentation
    /// <summary>
    ///     3d animation (with roller coaster view!) for lorenz attractor.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Ge Wang
    ///         http://www.gewang.com/projects/lorenz3d/lorenz3d.cpp
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Lorenz3d {
        // --- Fields ---
        #region Private Constants
        private const float LORENZ3D_VERSION = 1.00f;
        private const float FLT_MAX = 1E+37f;
        #endregion Private Constants

        #region Private Fields
        // width and height of the window
        private static int windowWidth = 480;
        private static int windowHeight = 360;

        // axis parallel bounding box
        private static float[] boundLow = {FLT_MAX, FLT_MAX, FLT_MAX};
        private static float[] boundHigh = {-FLT_MAX, -FLT_MAX, -FLT_MAX};

        // the vertex array of data points
        private static float[][] vertexArray;
        private static int numberOfVertices = 0;

        // the current glBegin draw mode
        private static int drawingMode = Gl.GL_LINE_STRIP;

        // 3rd person or the in your face
        private static bool viewRollerCoaster = false;

        // draw to tracer
        private static bool drawTracer = false;
        // start the tracer over
        private static bool resetTracer = false;

        // increment to change rotation
        private static float delta = 4.8f;
        // angle in degree to rotate
        private static float rotation = 0.0f;
        // zoom factor
        private static float zoomFactor = 0.0f;

        private static int index = 0;
        private static float deg = 128.0f;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run()
        {
            // initialize GLUT
            Glut.glutInit();
            // double buffer, use rgb color, enable depth buffers
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            // initialize the window size
            Glut.glutInitWindowSize(windowWidth, windowHeight);
            // set the window postion
            Glut.glutInitWindowPosition(100, 100);
            // create the window
            Glut.glutCreateWindow("Lorenz3d");

            // set the display function - called when redrawing
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            // set the idle function - called when idle
            Glut.glutIdleFunc(new Glut.IdleCallback(Idle));
            // set the keyboard function - called on keyboard events
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            // set the mouse function - called on mouse stuff
            Glut.glutMouseFunc(new Glut.MouseCallback(Mouse));
            // set the reshape function - called when client area changes
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));

            // do our own initialization
            Init();

            // let GLUT handle the current thread from here
            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region BuildVertices(double a, double b, double c, double T, double h, double x, double y, double z)
        private static void BuildVertices(double a, double b, double c, double T, double h, double x, double y, double z) {
            double _x = x;
            double _y = y;
            double _z = z;

            // clean up any memory
            CleanUp();

            // num = T / h
            numberOfVertices = (int) (T / h + 0.5);

            // allocate data point array
            vertexArray = new float[numberOfVertices][];

            for(int i = 0; i < numberOfVertices; i++) {
                // allocate the current data point
                vertexArray[i] = new float[3];

                // calculate the next vertex
                vertexArray[i][0] = (float) _x;
                vertexArray[i][1] = (float) _y;
                vertexArray[i][2] = (float) _z;

                // find bounding box
                if(_x < boundLow[0]) {
                    boundLow[0] = (float) _x;
                }
                if(_y < boundLow[1]) { 
                    boundLow[1] = (float) _y;
                }
                if(_z < boundLow[2]) {
                    boundLow[2] = (float) _z;
                }

                if(_x > boundHigh[0]) {
                    boundHigh[0] = (float) _x;
                }
                if(_y > boundHigh[1]) {
                    boundHigh[1] = (float) _y;
                }
                if(_z > boundHigh[2]) {
                    boundHigh[2] = (float) _z;
                }

                // calculate next point by forward Euler
                _x = x + h * (a * (y - x));
                _y = y + h * (x * (b - z) - y);
                _z = z + h * (x * y - c * z);

                x = _x;
                y = _y;
                z = _z;
            }

            // reshape since the bounding box could have been changed
            Reshape(windowWidth, windowHeight);
        }
        #endregion BuildVertices(double a, double b, double c, double T, double h, double x, double y, double z)

        #region CleanUp()
        private static void CleanUp() {
            vertexArray = null;
            numberOfVertices = 0;
            for(int i = 0; i < 3; i++) {
                boundLow[i] = FLT_MAX;
                boundHigh[i] = -FLT_MAX;
            }
        }
        #endregion CleanUp()

        #region Init()
        /// <summary>
        ///     Sets initial OpenGL states and initializes any application data.
        /// </summary>
        private static void Init() {
            // set the GL clear color - use when the color buffer is cleared
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            // set the shading model to 'smooth'
            Gl.glShadeModel(Gl.GL_SMOOTH);
            // render front of polygons
            Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_POLYGON);
            // enable depth
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            // set the initial line width
            Gl.glLineWidth(1.0f);

            // construct lorenz data points
            BuildVertices(10.0, 28.0, 8.0 / 3.0, 100.0, 0.01, 0.1, 0.0, 0.0);

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Lorenz Attractor 3D (v{0:F2})", LORENZ3D_VERSION);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("[L/R] mouse button - (3rd person view) rotate view\n");
            Console.WriteLine("'s' - reset tracer to beginning");
            Console.WriteLine("'p' - toggle plot [all points] | [up to tracer]");
            Console.WriteLine("'v' - toggle [3rd person] | [roller coaster] view");
            Console.WriteLine("    (try differrent combinations of 's','p','v')\n");
            Console.WriteLine("'-' - (3rd person view) zoom in");
            Console.WriteLine("'=' - (3rd person view) zoom out");
            Console.WriteLine("'m' - (3rd person view) mode [line] | [point]\n");
            Console.WriteLine("'q' - quit progrqam");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("http://www.gewang.com/projects/lorenz3d/");
            Console.WriteLine("http://www.taoframework.com");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
        #endregion Init()

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     Called to draw the client area.
        /// </summary>
        private static void Display() {
            float mz = (boundLow[2] + boundHigh[2]) / 2;
            int i;
            int num = (drawTracer ? index : numberOfVertices - 1);

            // clear the color
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();
                // increment our current index (where tracer is)
                if(++index >= numberOfVertices) {
                    index = 0;
                }
                if(resetTracer) {
                    index = 0;
                    resetTracer = false;
                }

                // make references to next 4 data points
                float[] a = vertexArray[index];
                float[] b = vertexArray[(index + 1 >= numberOfVertices - 1 ? 0 : index + 1)];
                float[] c = vertexArray[(index + 2 >= numberOfVertices - 1 ? 0 : index + 2)];
                float[] d = vertexArray[(index + 3 >= numberOfVertices - 1 ? 0 : index + 3)];

                if(!viewRollerCoaster) { // 3rd person
                    // rotates the polygon about the z-axis
                    Gl.glRotatef(deg, 0.0f, 1.0f, 0.0f);
                    deg += rotation;

                    // center on axis of rotation
                    Gl.glTranslatef(0.0f, 0.0f, -mz);
                }
                else { // 1st person
                    // roller coaster view (chase the tracer)
                    Glu.gluLookAt(a[0], a[1], a[2], d[0], d[1], d[2], 0.0, 1.0, 1.0);
                    Gl.glTranslatef(0.0f, -0.3f, 0.0f);
                }

                Gl.glColor3f(0.8f, 1.0f, 0.4f);
                Gl.glBegin(viewRollerCoaster ? Gl.GL_LINE_STRIP : drawingMode);
                    // draw data points
                    for(i = 0; i <= num; i++) {
                        Gl.glVertex3fv(vertexArray[i]);
                    }

                    // extra lines for roller coaster view
                    if(viewRollerCoaster && drawTracer) {
                        Gl.glVertex3fv(b);
                        Gl.glColor3f(0.8f, 0.8f, 0.4f);
                        Gl.glVertex3fv(c);
                        Gl.glColor3f(0.8f, 0.4f, 0.4f);
                        Gl.glVertex3fv(d);
                    }
                Gl.glEnd();

                // the tracer
                Gl.glColor3f(1.0f, 0.0f, 0.0f);
                if(!viewRollerCoaster) {
                    // 3rd person
                    Gl.glTranslatef(a[0], a[1], a[2]);
                    Glut.glutSolidSphere(0.5, 10, 10);
                }
                else {
                    // roller coaster view
                    Gl.glTranslatef(d[0], d[1], d[2]);
                    Glut.glutWireSphere(0.3, 10, 10);
                    Gl.glColor3f(1.0f, 1.0f, 0.6f);
                    Glut.glutWireSphere(0.03, 5, 3);
                }
            Gl.glPopMatrix();
            Gl.glFlush();
            Glut.glutSwapBuffers();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        /// <summary>
        ///     Called on a key event.
        /// </summary>
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case 27:
                case (byte) 'Q':
                case (byte) 'q':
                    CleanUp();
                    Environment.Exit(0);
                    break;
                case (byte) '+':
                case (byte) '=':
                    // rotate right
                    zoomFactor -= 1.0f;
                    break;
                case (byte) '-':
                case (byte) '_':
                    // rotate left
                    zoomFactor += 1.0f;
                    break;
                case (byte) 'v':
                    // toggle roller coaster view | standard
                    viewRollerCoaster = !viewRollerCoaster;
                    break;
                case (byte) 'p':
                    // toggle draw to tracer
                    drawTracer = !drawTracer;
                    break;
                case (byte) 's':
                    // reset the tracer
                    resetTracer = true;
                    break;
                case (byte) 'm':
                    drawingMode = (drawingMode == Gl.GL_LINE_STRIP ? Gl.GL_POINTS : Gl.GL_LINE_STRIP);
                    break;
            }

            Reshape(windowWidth, windowHeight);
            Glut.glutPostRedisplay();
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Idle()
        private static void Idle() {
            // invalidates the current window, so GLUT will call display function
            Glut.glutPostRedisplay();
        }
        #endregion Idle()

        #region Mouse(int button, int state, int x, int y)
        /// <summary>
        ///     Called on a mouse event.
        /// </summary>
        private static void Mouse(int button, int state, int x, int y) {
            if(button == Glut.GLUT_LEFT_BUTTON) {
                // when left mouse button is down, move left
                if(state == Glut.GLUT_DOWN) {
                    rotation -= delta;
                }
                else if(state == Glut.GLUT_UP) {
                    rotation += delta;
                }
            }
            else if( button == Glut.GLUT_RIGHT_BUTTON) {
                // when right mouse button down, move right
                if(state == Glut.GLUT_DOWN) {
                    rotation += delta;
                }
                else if(state == Glut.GLUT_UP) {
                    rotation -= delta;
                }
            }
            else {
                // reset the increment
                rotation = 0.0f;
            }

            Glut.glutPostRedisplay();
        }
        #endregion Mouse(int button, int state, int x, int y)

        #region Reshape(int w, int h)
        /// <summary>
        ///     Called when window size changes.
        /// </summary>
        private static void Reshape(int w, int h) {
            // save the new window size
            windowWidth = w;
            windowHeight = h;
            // map the view port to the client area
            Gl.glViewport(0, 0, w, h);
            // set the matrix mode to project
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // load the identity matrix
            Gl.glLoadIdentity();

            if(viewRollerCoaster) {
                Glu.gluPerspective(80.0, (double) w / h, 0.0001, 300.0);
            }
            else {
                Glu.gluPerspective(64.0, (double) w / h, 1.0, 300.0);
            }

            // set the matrix mode to the modelview matrix
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            // load the identity matrix into the modelview matrix
            Gl.glLoadIdentity();

            if(!viewRollerCoaster) {
                // if not 1st person center our view
                float mx = (boundLow[0] + boundHigh[0]) / 2;
                float mz = (boundLow[2] + boundHigh[2]) / 2;
                Gl.glTranslatef(mx, 0.0f, -mz * 2 + zoomFactor);
            }
        }
        #endregion Reshape(int w, int h)
    }
}
