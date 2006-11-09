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
// File: shadow.cpp
// Desc: 2 pass z buffer algorightm using opengl
//
// Autumn 2000 - Ge Wang, Christina Hsu
//-----------------------------------------------------------------------------
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace GeWangExamples
{
    #region Class Documentation
    /// <summary>
    ///     2 pass z buffer algorithm using OpenGL.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Ge Wang
    ///         http://www.gewang.com/projects/samples/opengl/shadow.cpp
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Shadow {
        // --- Fields ---
        #region Private Constants
        private const float STEP = 2.0f;
        private const float PI = 3.14159265359f;
        #endregion Private Constants

        #region Private Fields
        // width and height of the window
        private static int windowWidth = 480;
        private static int windowHeight = 360;

        // whether to animate
        private static bool isRotating = true;

        // light 0 position
        private static float[] lightPosition = {2.0f, 2.0f, 2.0f, 1.0f};

        // clipping planes
        private static double[] clippingPlane = {0.0, 0.0, 1.0, 0.0};

        // depth buffer
        private static float[] depthLight;
        private static float[] depthView;

        private static float increment = 0.0f;
        private static float angle1 = -14.0f;
        private static float angle2 = 0.0f;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run()
        {
            // initialize GLUT
            Glut.glutInit();
            // double buffer, use rgb color, enable depth buffer
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH);
            // initialize the window size
            Glut.glutInitWindowSize(windowWidth, windowHeight);
            // set the window postion
            Glut.glutInitWindowPosition(100, 100);
            // create the window
            Glut.glutCreateWindow("Shadow");

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
            // set fill mode
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
            // set the line width
            Gl.glLineWidth(2.0f);

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

            Console.WriteLine("Press left or right mouse button to rotate.");
        }
        #endregion Init()

        #region Render()
        /// <summary>
        ///     Draws the scene.
        /// </summary>
        private static void Render() {
            Gl.glColor3f(0.4f, 1.0f, 0.4f);
            Glut.glutSolidSphere(0.6, 12, 12);

            Gl.glPushMatrix();
                Gl.glTranslatef(0.6f, 0.35f, 0.6f);
                Gl.glColor3f(1.0f, 0.7f, 0.7f);
                Glut.glutSolidCube(0.2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
                Gl.glTranslatef(0.7f, 0.85f, 0.7f);
                Gl.glRotatef(angle2 += 1, 0.0f, 1.0f, 0.0f);
                Gl.glTranslatef(0.0f, -0.2f, 0.0f);
                Gl.glRotatef(-90, 1.0f, 0.0f, 0.0f);
                Gl.glColor3f(1.0f, 1.0f, 0.4f);
                Glut.glutWireCone(0.2, 0.4, 8, 8);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
                Gl.glTranslatef(-0.9f, -0.9f, -0.1f);
                Gl.glRotatef(90, -0.5f, 0.5f, 0.15f);
                Gl.glRotatef(angle2, 0.0f, 0.0f, 1.0f);
                Gl.glColor3f(1.0f, 0.4f, 1.0f);
                Glut.glutWireTorus(0.2, 0.5, 8, 8);
            Gl.glPopMatrix();
        }
        #endregion Render()

        #region Shadows()
        /// <summary>
        ///     Draws shadow.
        /// </summary>
        private static void Shadows() {
            double[] modelviewMatrix = new double[16];
            double[] projectionMatrix = new double[16];
            int[] viewport = new int[4];
            double objX, objY, objZ;
            float depth;
            float[] p = lightPosition;
            float[] localDepthView, localDepthLight;
            double[] modelviewLight = new double[16];
            double winX, winY, winZ;
            int ix, iy;
            double depth_2;
            int x, y;

            // color of pixels in shadow
            int[] pixel = { 0x7f7f7f7f };
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);

            // get the modelview, project, and viewport
            Gl.glGetDoublev(Gl.GL_MODELVIEW_MATRIX, modelviewMatrix);
            Gl.glGetDoublev(Gl.GL_PROJECTION_MATRIX, projectionMatrix);
            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);

            // get the transformation from light view
            Gl.glPushMatrix();
                Gl.glLoadIdentity();
                Glu.gluLookAt(p[0], p[1], p[2], 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
                Gl.glGetDoublev(Gl.GL_MODELVIEW_MATRIX, modelviewLight);
            Gl.glPopMatrix();

            // set the project matrix to orthographic
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();
                Gl.glLoadIdentity();
                Glu.gluOrtho2D(0.0, (float) windowWidth, 0.0, (float) windowHeight);

                // set the modelview matrix to identity
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glPushMatrix();
                    Gl.glLoadIdentity();

                    // get the current depth buffer
                    Gl.glReadPixels(0, 0, windowWidth, windowHeight, Gl.GL_DEPTH_COMPONENT, Gl.GL_FLOAT, depthView);

                    // get pointers to the depth buffers
                    localDepthView = depthView;
                    localDepthLight = depthLight;

                    int i = 0;
                    // go through every pixel in frame buffer
                    for(y = 0; y < windowHeight; y++) {
                        for(x = 0; x < windowWidth; x++) {
                            // depth at pixel
                            depth = localDepthView[i++];

                            // on the far plane of frustum - don't calculate
                            if(depth > 0.99) {
                                continue;
                            }

                            // get world coordinate from x, y, depth
                            Glu.gluUnProject(x, y, (double) depth, modelviewMatrix, projectionMatrix, viewport, out objX, out objY, out objZ);

                            // get light view screen coordinate and depth
                            Glu.gluProject(objX, objY, objZ, modelviewLight, projectionMatrix, viewport, out winX, out winY, out winZ);

                            ix = (int)(winX + 0.5);
                            iy = (int)(winY + 0.5);

                            // make sure within the screen
                            if(ix >= windowWidth || iy >= windowHeight || ix < 0 || iy < 0) {
                                continue;
                            }

                            // get the depth value from the light
                            depth_2 = (double) depthLight[iy * windowWidth + ix];

                            // is something between the light and the pixel?
                            if((winZ - depth_2) > 0.01) {
                                Gl.glRasterPos2i(x, y);
                                Gl.glDrawPixels(1, 1, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixel);
                            }
                        }
                    }

                // restore modelview transformation
                Gl.glPopMatrix();

                // restore projection
                Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix();

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }
        #endregion Shadows()

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     Called to draw the client area.
        /// </summary>
        private static void Display() {
            int[] buffer = new int[1];
            float[] p = lightPosition;

            // get the current color buffer being drawn to
            Gl.glGetIntegerv(Gl.GL_DRAW_BUFFER, buffer);

            // clear the color and depth buffer
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glPushMatrix();
                Gl.glRotatef(angle1 += increment, 0.0f, 1.0f, 0.0f);

                // set the position of the light
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPosition);

                // switch to viewpoint of light
                Gl.glPushMatrix();
                    // disable drawing into color buffer
                    Gl.glDrawBuffer(Gl.GL_NONE);

                    // set the camera to the viewpoint of the light
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(p[0], p[1], p[2], 0, 0, 0, 0, 1, 0);

                    // draw scene
                    Render();

                    // save the depth buffer
                    Gl.glReadPixels(0, 0, windowWidth, windowHeight, Gl.GL_DEPTH_COMPONENT, Gl.GL_FLOAT, depthLight);

                    // enable drawing into color buffer
                    Gl.glDrawBuffer(buffer[0]);
                Gl.glPopMatrix();

                // clear the depth buffer
                Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);
                // draw scene
                Render();

                // draw the shadow
                Shadows();
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
            }

            Reshape(windowWidth, windowHeight);
            Glut.glutPostRedisplay();
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Idle()
        private static void Idle() {
            // render the scene
            Glut.glutPostRedisplay();
        }
        #endregion Idle()

        #region Mouse(int button, int state, int x, int y)
        /// <summary>
        ///     Called on a mouse event.
        /// </summary>
        private static void Mouse(int button, int state, int x, int y) {
            if(button == Glut.GLUT_LEFT_BUTTON) {
                // rotate
                if(state == Glut.GLUT_DOWN) {
                    increment -= STEP;
                }
                else {
                    increment += STEP;
                }
            }
            else if (button == Glut.GLUT_RIGHT_BUTTON) {
                if(state == Glut.GLUT_DOWN) {
                    increment += STEP;
                }
                else {
                    increment -= STEP;
                }
            }
            else {
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
            Glu.gluLookAt(0.0f, 1.2f, 3.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);

            depthLight = new float[windowWidth * windowHeight];
            depthView = new float[windowWidth * windowHeight];
        }
        #endregion Reshape(int w, int h)
    }
}
