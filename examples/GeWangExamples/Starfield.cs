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
// File: starfield.cpp
// Desc: 3d opengl/glut starfield
//
// summer 2001 - Ge Wang & Adrenaline University c++ class
//-----------------------------------------------------------------------------
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace GeWangExamples
{
    #region Class Documentation
    /// <summary>
    ///     3D starfield.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Ge Wang
    ///         http://www.gewang.com/projects/samples/opengl/starfield.cpp
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Starfield
    {
        // --- Fields ---
        #region Private Constants
        private const int NUMBER_STARS = 400;
        private const float FAR_PLANE = -40.0f;
        private const float NEAR_PLANE = 3.0f;
        private const float GAP = 0.0f;
        private const float FIELD_WIDTH = 30.0f;
        private const float FIELD_HEIGHT = 25.0f;
        private const float RADIUS = 1.0f;
        private const float DEFAULT_SPEED = 0.2f;
        private const int RAND_MAX = 0x7fff;
        #endregion Private Constants

        #region Private Fields
        // width and height of the window
        private static int windowWidth = 640;
        private static int windowHeight = 480;

        // light position
        private static float[] lightPosition = { 0.0f, 0.0f, 3.0f, 1.0f };

        // the location
        private static float[][] xyz = new float[NUMBER_STARS][];
        // the colors
        private static float[][] colors = new float[NUMBER_STARS][];

        // the alpha and red components of polygon to blend
        private static float alpha = 0.3f;
        private static float red = 0.0f;
        private static float speed = DEFAULT_SPEED;
        private static float speedIncrement = 0.0f;
        private static float inc = 0.0f;
        private static Random rand = new Random();
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
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
            Glut.glutCreateWindow("Starfield");

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
        #region Init()
        /// <summary>
        ///     Sets initial OpenGL states and initializes any application data.
        /// </summary>
        private static void Init()
        {
            // set the GL clear color - use when the color buffer is cleared
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            // set the shading model to 'smooth'
            Gl.glShadeModel(Gl.GL_SMOOTH);
            // enable depth
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            // draw in fill
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
            // set the initial line width
            Gl.glLineWidth(1.0f);

            // enable lighting
            Gl.glEnable(Gl.GL_LIGHTING);
            // enable lighting for front
            Gl.glLightModeli(Gl.GL_FRONT, Gl.GL_TRUE);
            // material have diffuse and ambient lighting 
            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);
            // enable color
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            // enable light 0
            Gl.glEnable(Gl.GL_LIGHT0);

            // set light attenuation
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_CONSTANT_ATTENUATION, 0.01f);
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_LINEAR_ATTENUATION, 0.2f);
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_QUADRATIC_ATTENUATION, 0.001f);

            // clear the color buffer once
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            // randomly generate
            for (int i = 0; i < NUMBER_STARS; i++)
            {
                xyz[i] = new float[3];
                xyz[i][0] = ((float)rand.Next(RAND_MAX) / RAND_MAX - 0.5f) * FIELD_WIDTH;
                xyz[i][1] = ((float)rand.Next(RAND_MAX) / RAND_MAX - 0.5f) * FIELD_HEIGHT;
                xyz[i][2] = ((float)rand.Next(RAND_MAX) / RAND_MAX) * (NEAR_PLANE - FAR_PLANE + GAP) + FAR_PLANE;

                colors[i] = new float[3];
                colors[i][0] = (float)rand.Next(RAND_MAX) / RAND_MAX;
                colors[i][1] = (float)rand.Next(RAND_MAX) / RAND_MAX;
                colors[i][2] = (float)rand.Next(RAND_MAX) / RAND_MAX;
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("OpenGL flying simulation");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("[L/R] mouse button - accelerate forward/backwards");
            Console.WriteLine("                     (try going backwards)");
            Console.WriteLine("middle mouse button - reset to default speed");
            Console.WriteLine("'=' or '+' - increase tail");
            Console.WriteLine("'-' - decrease tail");
            Console.WriteLine("'q' - quit progrqam");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
        #endregion Init()

        #region Render()
        private static void Render()
        {
            inc += 0.01f;
            Gl.glRotatef(50 * (float)(Math.Cos(inc)), 0.0f, 0.0f, 1.0f);

            speed += speedIncrement;
            for (int i = 0; i < NUMBER_STARS; i++)
            {
                Gl.glPushMatrix();
                Gl.glTranslatef(xyz[i][0], xyz[i][1], xyz[i][2]);
                Gl.glColor3fv(colors[i]);
                Glut.glutSolidSphere(0.1f, 5, 5);
                Gl.glPopMatrix();

                // increment z
                xyz[i][2] += speed;

                // check to see if passed view
                if (xyz[i][2] > NEAR_PLANE + GAP)
                {
                    float d;
                    if ((d = (float)(Math.Sqrt(xyz[i][0] * xyz[i][0] + xyz[i][1] * xyz[i][1]))) < RADIUS)
                    {
                        red += (RADIUS - d) / RADIUS;
                        if (red > 2.5f)
                        {
                            red = 2.5f;
                        }
                    }

                    xyz[i][0] = ((float)rand.Next(RAND_MAX) / RAND_MAX - 0.5f) * FIELD_WIDTH;
                    xyz[i][1] = ((float)rand.Next(RAND_MAX) / RAND_MAX - 0.5f) * FIELD_HEIGHT;
                    xyz[i][2] = FAR_PLANE;
                }
                else if (xyz[i][2] < FAR_PLANE)
                {
                    xyz[i][0] = ((float)rand.Next(RAND_MAX) / RAND_MAX - 0.5f) * FIELD_WIDTH;
                    xyz[i][1] = ((float)rand.Next(RAND_MAX) / RAND_MAX - 0.5f) * FIELD_HEIGHT;
                    xyz[i][2] = NEAR_PLANE;
                }
            }
        }
        #endregion Render()

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     Called to draw the client area.
        /// </summary>
        private static void Display()
        {
            // clear the depth buffer
            Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);

            // enable blending
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

            // disable lighting
            Gl.glDisable(Gl.GL_LIGHTING);
            // disable depth test
            Gl.glDisable(Gl.GL_DEPTH_TEST);
            // blend in a polygon
            Gl.glColor4f(red, red, red, alpha);

            // reduce the red component
            red -= 0.02f;
            if (red < 0.0f)
            {
                red = 0.0f;
            }

            // draw the polygons
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3f(-1.0f, -1.0f, 2.0f);
            Gl.glVertex3f(-1.0f, 1.0f, 2.0f);
            Gl.glVertex3f(1.0f, 1.0f, 2.0f);
            Gl.glVertex3f(1.0f, -1.0f, 2.0f);
            Gl.glEnd();

            // enable lighting
            Gl.glEnable(Gl.GL_LIGHTING);
            // enable depth test
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            // disable blending
            Gl.glDisable(Gl.GL_BLEND);

            // save the current matrix state, so transformation will
            // not persist across displayFunc calls, since we
            // will do a glPopMatrix() at the end of this function
            Gl.glPushMatrix();
            // render the scene
            Render();
            // restore the matrix state
            Gl.glPopMatrix();

            // flush the buffer
            Gl.glFlush();
            // swap the double buffer
            Glut.glutSwapBuffers();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        /// <summary>
        ///     Called on a key event.
        /// </summary>
        private static void Keyboard(byte key, int x, int y)
        {
            switch (key)
            {
                case 27:
                case (byte)'Q':
                case (byte)'q':
                    Environment.Exit(0);
                    break;
                case (byte)'+':
                case (byte)'=':
                    alpha -= 0.02f;
                    if (alpha < 0.05f)
                    {
                        alpha = 0.05f;
                    }
                    break;
                case (byte)'-':
                    alpha += 0.02f;
                    if (alpha > 1.0f)
                    {
                        alpha = 1.0f;
                    }
                    break;
            }

            Glut.glutPostRedisplay();
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Idle()
        private static void Idle()
        {
            // invalidates the current window, so GLUT will call display function
            Glut.glutPostRedisplay();
        }
        #endregion Idle()

        #region Mouse(int button, int state, int x, int y)
        /// <summary>
        ///     Called on a mouse event.
        /// </summary>
        private static void Mouse(int button, int state, int x, int y)
        {
            if (button == Glut.GLUT_LEFT_BUTTON)
            {
                // when left mouse button is down, go forward faster
                if (state == Glut.GLUT_DOWN)
                {
                    speedIncrement += 0.02f;
                }
                else if (state == Glut.GLUT_UP)
                {
                    speedIncrement -= 0.02f;
                }
            }
            else if (button == Glut.GLUT_RIGHT_BUTTON)
            {
                // when right mouse button down, go backwards faster
                if (state == Glut.GLUT_DOWN)
                {
                    speedIncrement -= 0.02f;
                }
                else if (state == Glut.GLUT_UP)
                {
                    speedIncrement += 0.02f;
                }
            }
            else if (button == Glut.GLUT_MIDDLE_BUTTON)
            {
                if (state == Glut.GLUT_DOWN)
                {
                    speed = DEFAULT_SPEED;
                    speedIncrement = 0;
                }
            }
        }
        #endregion Mouse(int button, int state, int x, int y)

        #region Reshape(int w, int h)
        /// <summary>
        ///     Called when window size changes.
        /// </summary>
        private static void Reshape(int w, int h)
        {
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
            Glu.gluPerspective(64.0, (float)w / (float)h, 0.1, 300.0);
            // set the matrix mode to modelview
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            // load the identity matrix
            Gl.glLoadIdentity();
            // position the view point
            Glu.gluLookAt(0.0f, 0.0, 3.0f, 0.0f, 0.0f, 0.0f, 0.0f, 2.0f, 3.0f);
            // set the position of the light
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPosition);
        }
        #endregion Reshape(int w, int h)
    }
}
