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
	multiview.c
	Nate Robins, 1997
	
	Program that shows how to use multiple viewports in a single
	context (using scissoring).
 */
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace NateRobins {
    #region Class Documentation
    /// <summary>
    ///     Program that shows how to use multiple viewports in a single context (using
    ///     scissoring).
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
    public sealed class MultiView {
        // --- Fields ---
        #region Private Fields
        private static int torusList;
        private static float spinX;
        private static float spinY;
        private static int oldX;
        private static int oldY;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(512, 512);
            Glut.glutInitWindowPosition(50, 50);
            Glut.glutCreateWindow("Multiple Viewports");

            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutMotionFunc(new Glut.MotionCallback(Motion));
            Glut.glutMouseFunc(new Glut.MouseCallback(Mouse));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            
            Init();
            BuildLists();
            
            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region BuildLists()
        private static void BuildLists() {
            float[] goldAmbient = {0.24725f, 0.1995f, 0.0745f, 1.0f};
            float[] goldDiffuse = {0.75164f, 0.60648f, 0.22648f, 1.0f};
            float[] goldSpecular = {0.628281f, 0.555802f, 0.366065f, 1.0f};
            float goldShininess = 41.2f;
            float[] silverAmbient = {0.05f, 0.05f, 0.05f, 1.0f};
            float[] silverDiffuse = {0.4f, 0.4f, 0.4f, 1.0f};
            float[] silverSpecular = {0.7f, 0.7f, 0.7f, 1.0f};
            float silverShininess = 12.0f;
    
            torusList = Gl.glGenLists(1);
            Gl.glNewList(torusList, Gl.GL_COMPILE);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, goldAmbient);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, goldDiffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, goldSpecular);
                Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, goldShininess);
                Gl.glMaterialfv(Gl.GL_BACK, Gl.GL_AMBIENT, silverAmbient);
                Gl.glMaterialfv(Gl.GL_BACK, Gl.GL_DIFFUSE, silverDiffuse);
                Gl.glMaterialfv(Gl.GL_BACK, Gl.GL_SPECULAR, silverSpecular);
                Gl.glMaterialf(Gl.GL_BACK, Gl.GL_SHININESS, silverShininess);
                Glut.glutWireTorus(0.3, 0.5, 16, 32);
            Gl.glEndList();
        }
        #endregion BuildLists()

        #region Init()
        private static void Init() {
            float[] lightPosition = {1.0f, 1.0f, 1.0f, 0.0f};

            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPosition);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glDisable(Gl.GL_CULL_FACE);
        }
        #endregion Init()

        #region Projection(int width, int height, int perspective)
        private static void Projection(int width, int height, int perspective) {
            float ratio = (float) width / (float) height;

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            if(perspective > 0) {
                Glu.gluPerspective(60, ratio, 1, 256);
            }
            else  {
                Gl.glOrtho(-ratio, ratio, -ratio, ratio, 1, 256);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0.0, 0.0, 2.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
        }
        #endregion Projection(int width, int height, int perspective)

        #region Text(string text)
        private static void Text(string text) {
            foreach(char c in text) {
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_18, c);
            }
        }
        #endregion Text(string text)

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            int width = Glut.glutGet(Glut.GLUT_WINDOW_WIDTH);
            int height = Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT);

            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0, width, 0, height);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glDisable(Gl.GL_LIGHTING);
                Gl.glColor3ub(255, 255, 255);
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex2i(width / 2, 0);
                Gl.glVertex2i(width / 2, height);
                Gl.glVertex2i(0, height / 2);
                Gl.glVertex2i(width, height / 2);
            Gl.glEnd();

            Gl.glRasterPos2i(5, 5);
            Text("Front");
            Gl.glRasterPos2i(width / 2 + 5, 5);
            Text("Right");
            Gl.glRasterPos2i(5, height / 2 + 5);
            Text("Top");
            Gl.glRasterPos2i(width / 2 + 5, height / 2 + 5);
            Text("Perspective");

            Gl.glEnable(Gl.GL_LIGHTING);

            width = (width + 1) / 2;
            height = (height + 1) / 2;

            Gl.glEnable(Gl.GL_SCISSOR_TEST);

            // Bottom Left
            Gl.glViewport(0, 0, width, height);
            Gl.glScissor(0, 0, width, height);

            // Front
            Projection(width, height, 0);
            Gl.glRotatef(spinY, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(spinX, 0.0f, 1.0f, 0.0f);

            Gl.glCallList(torusList);
    
            // Bottom Right
            Gl.glViewport(width, 0, width, height);
            Gl.glScissor(width, 0, width, height);

            // Right
            Projection(width, height, 0);
            Gl.glRotatef(90.0f, 0.0f, 1.0f, 0.0f);
            Gl.glRotatef(spinY, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(spinX, 0.0f, 1.0f, 0.0f);

            Gl.glCallList(torusList);

            // Top Left
            Gl.glViewport(0, height, width, height);
            Gl.glScissor(0, height, width, height);

            // Top
            Projection(width, height, 0);
            Gl.glRotatef(90.0f, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(spinY, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(spinX, 0.0f, 1.0f, 0.0f);

            Gl.glCallList(torusList);

            // Top Right
            Gl.glViewport(width, height, width, height);
            Gl.glScissor(width, height, width, height);

            // Perspective
            Projection(width, height, 1);
            Gl.glRotatef(30.0f, 0.0f, 1.0f, 0.0f);
            Gl.glRotatef(20.0f, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(spinY, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(spinX, 0.0f, 1.0f, 0.0f);

            Gl.glCallList(torusList);

            Gl.glDisable(Gl.GL_SCISSOR_TEST);

            Glut.glutSwapBuffers();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case 27:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Motion(int x, int y)
        private static void Motion(int x, int y) {
            spinX = x - oldX;
            spinY = y - oldY;
            Glut.glutPostRedisplay();
        }
        #endregion Motion(int x, int y)

        #region Mouse(int button, int state, int x, int y)
        private static void Mouse(int button, int state, int x, int y) {
            oldX = x;
            oldY = y;
            Glut.glutPostRedisplay();
        }
        #endregion Mouse(int button, int state, int x, int y)

        #region Reshape(int width, int height)
        private static void Reshape(int width, int height) {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
        #endregion Reshape(int width, int height)
    }
}
