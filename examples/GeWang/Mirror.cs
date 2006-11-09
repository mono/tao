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
// File: mirror.cpp
// Desc: sample shows a simple mirror placed on the xy plane
//       this a special case of mirror placement (greatly simplified)
//       the general method:
//           - make stencil mask of mirror pane
//           - draw inverted mirror image with stencil mask
//           - draw mirror pane to depth buffer
//           - draw normal scene without stencil
//           - blend mirror pane for effect
//
// Autumn 2000 - Ge Wang, Eric McGimpsey, Christina Hsu
//-----------------------------------------------------------------------------
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace GeWangExamples
{
    #region Class Documentation
    /// <summary>
    ///     Shows a simple mirror placed on the xy plane.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Ge Wang
    ///         http://www.gewang.com/projects/samples/opengl/mirror.cpp
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Mirror {
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
        private static float[] light0Position = {10.0f, 5.0f, 0.0f, 1.0f};

        // clipping planes
        private static double[] clippingPlane = {0.0, 0.0, 1.0, 0.0};
        private static float increment = 0.0f;
        private static float angle = 0.0f;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run()
        {
            // initialize GLUT
            Glut.glutInit();
            // double buffer, use rgb color, enable depth and stencil buffers
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB | Glut.GLUT_DEPTH | Glut.GLUT_STENCIL);
            // initialize the window size
            Glut.glutInitWindowSize(windowWidth, windowHeight);
            // set the window postion
            Glut.glutInitWindowPosition(100, 100);
            // create the window
            Glut.glutCreateWindow("Mirror");

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

        #region DrawMirror(float val)
        /// <summary>
        ///     Draws mirror pane.
        /// </summary>
        private static void DrawMirror(float val) {
            Gl.glVertex3f(val, val, 0.0f);
            Gl.glVertex3f(-val, val, 0.0f);
            Gl.glVertex3f(-val, -val, 0.0f);
            Gl.glVertex3f(val, -val, 0.0f);
        }
        #endregion DrawMirror(float val)

        #region Render()
        /// <summary>
        ///     Draws the scene.
        /// </summary>
        private static void Render() {
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0Position);

            Gl.glPushMatrix();
                Gl.glColor3f(0.4f, 1.0f, 0.4f);
                Gl.glTranslatef(0.0f, 0.0f, 2.5f);
                Glut.glutSolidSphere(0.5, 12, 12);

                Gl.glTranslatef(0.5f, 0.0f, -0.7f);
                Gl.glColor3f(1.0f, 0.4f, 0.4f);
                Glut.glutSolidCube(0.3);

                Gl.glTranslatef(-0.5f, 0.0f, -0.2f);
                Gl.glRotatef(-90, 1.0f, 0.0f, 0.0f);
                Gl.glColor3f(1.0f, 1.0f, 0.4f);
                Glut.glutSolidCone(0.3, 0.6, 8, 8);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
                Gl.glTranslatef(0.2f, 0.3f, -2.0f);
                Gl.glColor3f(0.9f, 0.4f, 0.9f);
                Glut.glutWireTorus(0.3f, 0.8f, 8, 8);
            Gl.glPopMatrix();
        }
        #endregion Render()

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     Called to draw the client area.
        /// </summary>
        private static void Display() {
            float val = 0.8f;
            int[] buffer = { 0 };

            // get the current color buffer being drawn to
            Gl.glGetIntegerv(Gl.GL_DRAW_BUFFER, buffer);
            
            Gl.glPushMatrix();
                // rotate the viewpoint
                Gl.glRotatef(angle += increment, 0.0f, 1.0f, 0.0f);

                // set the clear value
                Gl.glClearStencil(0x0);
                // clear the stencil buffer
                Gl.glClear(Gl.GL_STENCIL_BUFFER_BIT);
                // always pass the stencil test
                Gl.glStencilFunc(Gl.GL_ALWAYS, 0x1, 0x1);
                // set the operation to modify the stencil buffer
                Gl.glStencilOp(Gl.GL_REPLACE, Gl.GL_REPLACE, Gl.GL_REPLACE);
                // disable drawing to the color buffer
                Gl.glDrawBuffer(Gl.GL_NONE);
                // enable stencil
                Gl.glEnable(Gl.GL_STENCIL_TEST);

                // draw the stencil mask
                Gl.glBegin(Gl.GL_QUADS);
                    DrawMirror(val);
                Gl.glEnd();

                // reenable drawing to color buffer
                Gl.glDrawBuffer(buffer[0]);
                // make stencil buffer read only
                Gl.glStencilOp(Gl.GL_KEEP, Gl.GL_KEEP, Gl.GL_KEEP);

                // clear the color and depth buffers
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

                // draw the mirror image
                Gl.glPushMatrix();
                    // invert image about xy plane
                    Gl.glScalef(1.0f, 1.0f, -1.0f);

                    // invert the clipping plane based on the view point
                    if(Math.Cos(angle * PI / 180.0) < 0.0) {
                        clippingPlane[2] = -1.0;
                    }
                    else {
                        clippingPlane[2] = 1.0;
                    }

                    // clip one side of the plane
                    Gl.glClipPlane(Gl.GL_CLIP_PLANE0, clippingPlane);
                    Gl.glEnable(Gl.GL_CLIP_PLANE0);
                    
                    // draw only where the stencil buffer == 1
                    Gl.glStencilFunc(Gl.GL_EQUAL, 0x1, 0x1);
                    // draw the object
                    Render();

                    // turn off clipping plane
                    Gl.glDisable(Gl.GL_CLIP_PLANE0);
                Gl.glPopMatrix();

                // disable the stencil buffer
                Gl.glDisable(Gl.GL_STENCIL_TEST);
                // disable drawing to the color buffer
                Gl.glDrawBuffer(Gl.GL_NONE);

                // draw the mirror pane into depth buffer -
                // to prevent object behind mirror from being render
                Gl.glBegin(Gl.GL_QUADS);
                    DrawMirror(val);
                Gl.glEnd();

                // enable drawing to the color buffer
                Gl.glDrawBuffer(buffer[0]);

                // draw the normal image, without stencil test
                Gl.glPushMatrix();
                    Render();
                Gl.glPopMatrix();

                // draw the outline of the mirror
                Gl.glColor3f(0.4f, 0.4f, 1.0f);
                Gl.glBegin(Gl.GL_LINE_LOOP);
                    DrawMirror(val);
                Gl.glEnd();

                // mirror shine
                Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
                Gl.glEnable(Gl.GL_BLEND);
                Gl.glDepthMask(Gl.GL_FALSE);
                Gl.glDepthFunc(Gl.GL_LEQUAL);
                Gl.glDisable(Gl.GL_LIGHTING);

                Gl.glColor4f(1.0f, 1.0f, 1.0f, 0.2f);
                Gl.glTranslatef(0.0f, 0.0f, 0.01f * (float) clippingPlane[2]);
                Gl.glBegin(Gl.GL_QUADS);
                    DrawMirror(val);
                Gl.glEnd();

                Gl.glDisable(Gl.GL_BLEND);
                Gl.glDepthMask(Gl.GL_TRUE);
                Gl.glDepthFunc(Gl.GL_LESS);
                Gl.glEnable(Gl.GL_LIGHTING);
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
            Glu.gluLookAt(0.0f, 1.0f, 5.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
        }
        #endregion Reshape(int w, int h)
    }
}
