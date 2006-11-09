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
// File: xform.cpp
// Desc: sample shows how usage of modelview transformations in OpenGL
//
// Autumn 2000 - Ge Wang - implementation
//-----------------------------------------------------------------------------
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace GeWangExamples
{
    #region Class Documentation
    /// <summary>
    ///     Shows how usage of modelview transformations in OpenGL.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Ge Wang
    ///         http://www.gewang.com/projects/samples/opengl/xform.cpp
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Xform {
        // --- Fields ---
        #region Private Constants
        private const float PI = 3.1415926f;
        private const float RADIUS = 0.4f;
        #endregion Private Constants

        #region Private Fields
        // width and height of the window
        private static int windowWidth = 640;
        private static int windowHeight = 420;

        // whether to animate
        private static bool isRotating = true;

        // data points for wheel
        private static float[][] vertexArray;
        private static int numberOfVertices = 0;

        // the grid
        private static float[][] grid;
        private static int gridPoints = 0;

        // x position of object
        private static float objectPositionX = 0.0f;
        // z postion of object
        private static float objectPositionZ = 0.0f;
        // increment for x on each cycle
        private static float increment = 0.0f;
        // the speed and direction of the wheels
        private static float factor = 1.0f;
        // the y for the pos of viewer
        private static float viewerPositionY = 3.0f;

        private static float rotateZ = 0.0f;
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
            Glut.glutCreateWindow("Xform");

            // set the display function - called when redrawing
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            // set the idle function - called when idle
            if(isRotating) {
                Glut.glutIdleFunc(new Glut.IdleCallback(Idle));
            }
            else {
                Glut.glutIdleFunc(null);
            }
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
        #region Init()
        /// <summary>
        ///     Sets initial OpenGL states and initializes any application data.
        /// </summary>
        private static void Init() {
            // set the GL clear color - use when the color buffer is cleared
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            // set the shading model to 'smooth'
            Gl.glShadeModel(Gl.GL_SMOOTH);
            // enable depth
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            // set the front faces of polygons
            Gl.glFrontFace(Gl.GL_CCW);
            // draw in wireframe
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);

            // build data points for wheels
            BuildVertices(16);

            // build data points for grid
            BuildGrid(11, 11, 1.0f);

            Console.WriteLine("hold left mouse button - move car left");
            Console.WriteLine("hold right mouse button - move car right");
            Console.WriteLine("center mouse button - resets position");
            Console.WriteLine("'[' - move car left");
            Console.WriteLine("'-' - move car near");
            Console.WriteLine("'=' - move car far");
            Console.WriteLine("'u' - move camera up");
            Console.WriteLine("'d' - move camera down");
        }
        #endregion Init()

        #region BuildGrid(int x, int z, float space)
        /// <summary>
        ///     Builds the grid.
        /// </summary>
        private static void BuildGrid(int x, int z, float space) {
            int i;

            // allocate the grid
            gridPoints = (x + z) * 2;
            grid = new float[gridPoints][];

            float width = (x - 1) * space * 2;
            float height = (z - 1) * space * 2;

            // generate the points for the grid
            for(i = 0; i < x * 2; i += 2) {
                grid[i] = new float[3];
                grid[i + 1] = new float[3];

                grid[i][0] = i * space;
                grid[i][1] = 0;
                grid[i][2] = 0;

                grid[i + 1][0] = i * space;
                grid[i + 1][1] = 0;
                grid[i + 1][2] = -height;
            }

            for(i = 0; i < z * 2; i += 2) {
                grid[i + x * 2] = new float[3];
                grid[i + x * 2 + 1] = new float[3];

                grid[i + x * 2][0] = 0;
                grid[i + x * 2][1] = 0;
                grid[i + x * 2][2] = -i * space;

                grid[i + x * 2 + 1][0] = width;
                grid[i + x * 2 + 1][1] = 0;
                grid[i + x * 2 + 1][2] = -i * space;
            }
        }
        #endregion BuildGrid(int x, int z, float space)

        #region BuildVertices(int vertices)
        /// <summary>
        ///     Builds the vertex and color arrays for a N-sided polygon.
        /// </summary>
        private static void BuildVertices(int vertices) {
            // this is the degrees between two vertices adjacent
            float inc = 360.0f / (float) vertices;
            // the radios of the vertice
            float radius = RADIUS;

            // make sure we have at least 3 vertices
            if(vertices < 3 ) {
                return;
            }

            // allocate the vert and color arrays
            vertexArray = new float[vertices][];
            numberOfVertices = vertices;

            for(int i = 0; i < vertices; i++) {
                vertexArray[i] = new float[3];

                // calculate the next vertex
                vertexArray[i][0] = (float) (Math.Cos((inc * i) * PI / 180.0f) * radius);//(Math.Cos(inc * i) * radius);
                vertexArray[i][1] = (float) (Math.Sin((inc * i) * PI / 180.0f) * radius);//(Math.Sin(inc * i) * radius);
                vertexArray[i][2] = 0.0f;
            }
        }
        #endregion BuildVertices(int vertices)

        #region RenderFrame()
        /// <summary>
        ///     Draw the frame of the car.
        /// </summary>
        private static void RenderFrame() {
            float y1 = RADIUS / 2, y2 = y1 * 1.2f;
            float x1 = -1.04f, x2 = 1.04f;
            float z1 = 0.5f, z2 = -0.5f;

            // draw the frame
            Gl.glBegin(Gl.GL_QUAD_STRIP);
                Gl.glVertex3f(x1, 0.0f, z1);
                Gl.glVertex3f(x1, y1, z1);

                Gl.glVertex3f(x2, 0.0f, z1);
                Gl.glVertex3f(x2, y2, z1);

                Gl.glVertex3f(x2, 0.0f, z2);
                Gl.glVertex3f(x2, y2, z2);

                Gl.glVertex3f(x1, 0.0f, z2);
                Gl.glVertex3f(x1, y1, z2);

                Gl.glVertex3f(x1, 0.0f, z1);
                Gl.glVertex3f(x1, y1, z1);
            Gl.glEnd();
        }
        #endregion RenderFrame()

        #region RenderGrid()
        /// <summary>
        ///     Draws grid in object coordinate.
        /// </summary>
        private static void RenderGrid() {
            Gl.glBegin(Gl.GL_LINES);
                for(int i = 0; i < gridPoints; i += 2) {
                    Gl.glVertex3fv(grid[i]);
                    Gl.glVertex3fv(grid[i + 1]);
                }
            Gl.glEnd();
        }
        #endregion RenderGrid()

        #region RenderObject()
        /// <summary>
        ///     Draws object in object coordinate.
        /// </summary>
        private static void RenderObject() {
            // left near wheel
            Gl.glColor3f(1.0f, 0.8f, 0.2f);
            Gl.glPushMatrix();
                Gl.glTranslatef(-1.0f, RADIUS, 0.5f);
                Gl.glRotatef(rotateZ, 0.0f, 0.0f, 1.0f);
                RenderWheel();
            Gl.glPopMatrix();
    
            // left far wheel
            Gl.glPushMatrix();
                Gl.glTranslatef(-1.0f, RADIUS, -0.5f);
                Gl.glRotatef(rotateZ, 0.0f, 0.0f, 1.0f);
                RenderWheel();
            Gl.glPopMatrix();

            // right near wheel
            Gl.glPushMatrix();
                Gl.glTranslatef(1.0f, RADIUS, 0.5f);
                Gl.glRotatef(rotateZ, 0.0f, 0.0f, 1.0f);
                RenderWheel();
            Gl.glPopMatrix();

            // right far wheel
            Gl.glPushMatrix();
                Gl.glTranslatef(1.0f, RADIUS, -0.5f);
                Gl.glRotatef(rotateZ, 0.0f, 0.0f, 1.0f);
                RenderWheel();
            Gl.glPopMatrix();

            // rotate the wheel for next time
            rotateZ += 1.0f * factor;

            // draw the frame of the object
            Gl.glColor3f(0.6f, 0.6f, 1.0f);
            Gl.glPushMatrix();
                Gl.glTranslatef(0.0f, RADIUS, 0.0f);
                RenderFrame();
            Gl.glPopMatrix();
        }
        #endregion RenderObject()

        #region RenderWheel()
        /// <summary>
        ///     Draw a wheel in local coordinate.
        /// </summary>
        private static void RenderWheel() {
            int i;

            // draw one wheel
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
                Gl.glVertex3f(0.0f, 0.0f, 0.0f);
                for(i = 0; i < numberOfVertices; i++) {
                    Gl.glVertex3fv(vertexArray[i]);
                }
                Gl.glVertex3fv(vertexArray[0]);
            Gl.glEnd();
        }
        #endregion RenderWheel()

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     Called to draw the client area.
        /// </summary>
        private static void Display() {
            // clear the color and depth buffers
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            // draw the world grid
            Gl.glPushMatrix();
                // position the grid
                Gl.glTranslatef(-10.0f, 0.0f, 10.0f);

                // draw the grid
                Gl.glLineWidth(1.0f);
                Gl.glColor3f(0.2f, 1.0f, 0.2f);
                RenderGrid();
            Gl.glPopMatrix();

            // draw the car
            Gl.glPushMatrix();
                // translate to (x, 0, z) world coordinate
                Gl.glTranslatef(objectPositionX, 0.0f, objectPositionZ);
                Gl.glLineWidth(2.0f);

                // draw the object
                RenderObject();
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
                    Environment.Exit(0);
                    break;
                case (byte) '[':
                    // move object towards -x
                    objectPositionX -= 0.05f;
                    factor = 1.0f;
                    break;
                case (byte) ']':
                    // move object towards x
                    objectPositionX += 0.05f;
                    // let the wheel turn clockwise
                    factor = -1.0f;
                    break;
                case (byte) '=':
                    // move further
                    objectPositionZ -= 0.1f;
                    break;
                case (byte) '-':
                    // move closer
                    objectPositionZ += 0.1f;
                    break;
                case (byte) '0':
                    // reset the location of object
                    objectPositionX = 0.0f;
                    increment = 0.0f;
                    break;
                case (byte) 'u':
                    // move view up
                    viewerPositionY += 0.2f;
                    Reshape(windowWidth, windowHeight);
                    break;
                case (byte) 'd':
                    // move view down
                    viewerPositionY -= 0.2f;
                    Reshape(windowWidth, windowHeight);
                    break;
            }

            Glut.glutPostRedisplay();
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Idle()
        private static void Idle() {
            // render the scene
            Glut.glutPostRedisplay();

            // increment the x position
            objectPositionX += increment;
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
                    increment -= 0.01f;
                    factor = 1.0f;
                }
                else {
                    increment += 0.01f;
                }
            }
            else if(button == Glut.GLUT_RIGHT_BUTTON) {
                // when right mouse button down, move right
                if(state == Glut.GLUT_DOWN) {
                    increment += 0.01f;
                    factor = -1.0f;
                }
                else {
                    increment -= 0.01f;
                }
            }
            else {
                // reset the location of object
                objectPositionX = 0.0f;
                increment = 0.0f;
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
            // create the viewing frustum
            Glu.gluPerspective(45.0, (float) w / (float) h, 1.0, 300.0);
            // set the matrix mode to modelview
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            // load the identity matrix
            Gl.glLoadIdentity();
            // position the view point
            Glu.gluLookAt(0.0f, viewerPositionY, 5.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
        }
        #endregion Reshape(int w, int h)
    }
}
