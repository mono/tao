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
// File: clipping.cpp
// Desc: sample shows the usage of clipping planes in OpenGL
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
    ///     Shows the usage of clipping planes in OpenGL.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Ge Wang
    ///         http://www.gewang.com/projects/samples/opengl/clipping.cpp
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class ClippingPlanes {
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

        // fill mode
        private static int fillMode = Gl.GL_FILL;

        // light 0 position
        private static float[] light0Position = {2.0f, 1.2f, 4.0f, 1.0f};

        // light 1 parameters
        private static float[] light1Ambient = {0.2f, 0.2f, 0.2f, 1.0f};
        private static float[] light1Diffuse = {1.0f, 1.0f, 1.0f, 1.0f};
        private static float[] light1Specular = {1.0f, 1.0f, 1.0f, 1.0f};
        private static float[] light1Position = {-2.0f, 0.0f, -4.0f, 1.0f};

        // toggle each of 3 clipping planes
        private static bool useClip1 = false;
        private static bool useClip2 = false;
        private static bool useClip3 = false;

        // clipping planes
        private static double[] clippingPlane1 = {1.0, 0.0, 0.0, 0.0};
        private static double[] clippingPlane2 = {0.0, 1.0, 0.0, 0.0};
        private static double[] clippingPlane3 = {0.0, 0.0, 1.0, 0.0};

        // modelview stuff
        private static float angleY = 32.0f;
        private static float increment = 0.0f;
        private static float eyeY = 0;

        // translation for the clipping planes
        private static float clipX = 0.0f;
        private static float clipY = 0.0f;
        private static float clipZ = 0.0f;
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
            Glut.glutCreateWindow("Clipping Planes");

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
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, fillMode);

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

            // setup and enable light 1
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light1Ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light1Diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light1Specular);
            Gl.glEnable(Gl.GL_LIGHT1);

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Clipping Planes sample in OpenGL");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("'1' - toggle x=0 halfplane");
            Console.WriteLine("'2' - toggle y=0 halfplane");
            Console.WriteLine("'3' - toggle z=0 halfplane");
            Console.WriteLine("'j', 'l' - translate x=0 halfplane (when toggled)");
            Console.WriteLine("',', 'i' - translate y=0 halfplane (when toggled)");
            Console.WriteLine("'u', 'm' - translate x=0 halfplane (when toggled)");
            Console.WriteLine("'x', 'y', 'z' - reverse the corresponding half plane");
            Console.WriteLine();
            Console.WriteLine("'-', '=' - rotate about y-axis");
            Console.WriteLine("(L/R) mouse buttons - rotate about y-axis");
            Console.WriteLine("'[', ']' - rotate viewpoint about x-axis");
            Console.WriteLine("'f' - toggle fill/wireframe drawmode");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
        }
        #endregion Init()

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     Called to draw the client area.
        /// </summary>
        private static void Display() {
            // clear the color and depth buffers
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glPushMatrix();
                // rotate the sphere about y axis
                Gl.glRotatef(angleY += increment, 0.0f, 1.0f, 0.0f);

                // set up the clipping planes
                Gl.glPushMatrix();
                    Gl.glTranslatef(clipX, 0.0f, 0.0f);
                    Gl.glClipPlane(Gl.GL_CLIP_PLANE0, clippingPlane1);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                    Gl.glTranslatef(0.0f, clipY, 0.0f);
                    Gl.glClipPlane(Gl.GL_CLIP_PLANE1, clippingPlane2);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                    Gl.glTranslatef(0.0f, 0.0f, clipZ);
                    Gl.glClipPlane(Gl.GL_CLIP_PLANE2, clippingPlane3);
                Gl.glPopMatrix();

                // enable each clipping plane
                if(useClip1) {
                    Gl.glEnable(Gl.GL_CLIP_PLANE0);
                }
                else {
                    Gl.glDisable(Gl.GL_CLIP_PLANE0);
                }

                if(useClip2) {
                    Gl.glEnable(Gl.GL_CLIP_PLANE1);
                }
                else {
                    Gl.glDisable(Gl.GL_CLIP_PLANE1);
                }

                if(useClip3) {
                    Gl.glEnable(Gl.GL_CLIP_PLANE2);
                }
                else {
                    Gl.glDisable(Gl.GL_CLIP_PLANE2);
                }

                // draw spheres inside of spheres
                Gl.glColor3f(0.4f, 0.4f, 1.0f);
                Glut.glutSolidSphere(0.23, 16, 16);

                Gl.glColor3f(1.0f, 0.4f, 0.4f);
                Glut.glutSolidSphere(0.45, 16, 16);

                Gl.glColor3f(1.0f, 0.8f, 0.4f);
                Glut.glutSolidSphere(0.71, 16, 16);

                Gl.glColor3f(0.4f, 1.0f, 0.4f);
                Glut.glutSolidSphere(1.0, 16, 16);
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
                case (byte) 'f':
                    fillMode = (fillMode == Gl.GL_FILL ? Gl.GL_LINE : Gl.GL_FILL);
                    Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, fillMode);
                    break;
                // toggle the 3 clipping planes
                case (byte) '1':
                    useClip1 = !useClip1;
                    break;
                case (byte) '2':
                    useClip2 = !useClip2;
                    break;
                case (byte) '3':
                    useClip3 = !useClip3;
                    break;
                // quit app
                case 27:
                case (byte) 'Q':
                case (byte) 'q':
                    Environment.Exit(0);
                    break;
                // set the rotation along the y axis
                case (byte) '-':
                    angleY -= STEP * 4.0f;
                    break;
                case (byte) '=':
                    angleY += STEP * 4.0f;
                    break;
                // move the view point up and down
                case (byte) '[':
                    eyeY -= 0.1f;
                    break;
                case (byte) ']':
                    eyeY += 0.1f;
                    break;
                // translate each clipping plane
                case (byte) 'j':
                    if(useClip1 && clipX > -1.0f) {
                        clipX -= 0.1f;
                    }
                    break;
                case (byte) 'l':
                    if(useClip1 && clipX < 1.0f) {
                        clipX += 0.1f;
                    }
                    break;
                case (byte) ',':
                    if(useClip2 && clipY > -1.0f) {
                        clipY -= 0.1f;
                    }
                    break;
                case (byte) 'i':
                    if(useClip2 && clipY < 1.0f) {
                        clipY += 0.1f;
                    }
                    break;
                case (byte) 'u':
                    if(useClip3 && clipZ > -1.0f) {
                        clipZ -= 0.1f;
                    }
                    break;
                case (byte) 'm':
                    if(useClip3 && clipZ < 1.0f) {
                        clipZ += 0.1f;
                    }
                    break;
                // reverse the half space that is removed
                case (byte) 'x':
                    clippingPlane1[0] *= -1;
                    break;
                case (byte) 'y':
                    clippingPlane2[1] *= -1;
                    break;
                case (byte) 'z':
                    clippingPlane3[2] *= -1;
                    break;
            }


            // do a reshape since eyeY might have changed
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
            Glu.gluLookAt(0.0f, 3.5f * Math.Sin(eyeY), 3.5f * Math.Cos(eyeY), 0.0f, 0.0f, 0.0f, 0.0f, (Math.Cos(eyeY) < 0 ? -1.0f : 1.0f), 0.0f);

            // set the position of the lights
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0Position);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light1Position);
        }
        #endregion Reshape(int w, int h)
    }
}
