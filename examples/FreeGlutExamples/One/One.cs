#region License
/*
MIT License
Copyright ©2003-2006 Tao Framework Team
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

#region Original License
/*
Copyright (c) 1999 by Pawel W. Olszta
Written by Pawel W. Olszta, <olszta@sourceforge.net>
Creation date: czw gru  2 11:58:41 CET 1999
*/
#endregion Original License

using System;
using System.IO;
using System.Text;

using Tao.FreeGlut;
using Tao.OpenGl;

namespace FreeGlutExamples
{
    /// <summary>
    /// FreeGlut One Example
    /// </summary>
    /// <remarks>
    ///     Hey! This was the original file where freeglut development started. Just
    ///     note what I have written here at the time. And see the creation date :)
    /// </remarks>
    public class One
    {
        static int g_LeaveGameMode = 0;
        static int g_InGameMode = 1;

        static void PrintText(int nX, int nY, string pszText)
        {
            int lines = 0;

            /*
             * Prepare the OpenGL state
             */
            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glDisable(Gl.GL_DEPTH_TEST);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();

            /*
             * Have an orthogonal projection matrix set
             */
            Gl.glOrtho(0, Glut.glutGet(Glut.GLUT_WINDOW_WIDTH),
                     0, Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT),
                     -1, +1
            );

            /*
             * Now the matrix mode
             */
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();

            /*
             * Now the main text
             */
            Gl.glColor3ub(0, 0, 0);
            Gl.glRasterPos2i(nX, nY);

            for (int i = 0; i < pszText.Length; i++)
            {
                char p = pszText[i];
                if (p == '\n')
                {
                    lines++;
                    Gl.glRasterPos2i(nX, nY - (lines * 18));
                }

                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_18, (int)p);
            }

            /*
             * Revert to the old matrix modes
             */
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix();

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPopMatrix();

            /*
             * Restore the old OpenGL states
             */
            Gl.glColor4f(1.0f, 1.0f, 1.0f, 1.0f);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
        }

        /*
         * This is the display routine for our sample FreeGLUT windows
         */
        static float g_fTime = 0.0f;

        public static void SampleDisplay()
        {
            /*
             * Clear the screen
             */
            Gl.glClearColor(0f, 0.5f, 1f, 1f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            /*
             * Have the cube rotated
             */
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();

            Gl.glRotatef(g_fTime, 0, 0, 1);
            Gl.glRotatef(g_fTime, 0, 1, 0);
            Gl.glRotatef(g_fTime, 1, 0, 0);

            /*
             * And then drawn...
             */
            Gl.glColor3f(1, 1, 0);
            /* glutWireCube( 20.0 ); */
            Glut.glutWireTeapot(20.0);
            /* glutWireSpher( 15.0, 15, 15 ); */
            /* glColor3f( 0, 1, 0 ); */
            /* glutWireCube( 30.0 ); */
            /* glutSolidCone( 10, 20, 10, 2 ); */

            /*
             * Don't forget about the model-view matrix
             */
            Gl.glPopMatrix();

            /*
             * Draw a silly text
             */
            if (g_InGameMode == 0)
                PrintText(20, 20, "Hello there cruel world!");
            else
                PrintText(20, 20, "Press ESC to leave the game mode!");

            /*
             * And swap this context's buffers
             */
            Glut.glutSwapBuffers();
        }

        /*
         * This is a sample idle function
         */
        static void SampleIdle()
        {
            g_fTime += 0.5f;

            if (g_LeaveGameMode == 1)
            {
                Glut.glutLeaveGameMode();
                g_LeaveGameMode = 0;
                g_InGameMode = 0;
            }
        }

        /*
         * The reshape function
         */
        static void SampleReshape(int nWidth, int nHeight)
        {
            float fAspect = (float)nHeight / (float)nWidth;
            float[] fPos = new float[4] { 0.0f, 0.0f, 10.0f, 0.0f };
            float[] fCol = new float[4] { 0.5f, 1.0f, 0.0f, 1.0f };

            /*
             * Update the viewport first
             */
            Gl.glViewport(0, 0, nWidth, nHeight);

            /*
             * Then the projection matrix
             */
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glFrustum(-1.0, 1.0, -fAspect, fAspect, 1.0, 80.0);

            /*
             * Move back the camera a bit
             */
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glTranslatef(0.0f, 0.0f, -40.0f);

            /*
             * Enable some features...
             */
            Gl.glEnable(Gl.GL_CULL_FACE);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_NORMALIZE);

            /*
             * Set up some lighting
             */
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, fPos);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            /*
             * Set up a sample material
             */
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE, fCol);
        }

        /*
         * A sample keyboard callback
         */
        static void SampleKeyboard(byte cChar, int nMouseX, int nMouseY)
        {
            Console.WriteLine("SampleKeyboard(): keypress '%c' at (%i,%i)\n",
                    cChar, nMouseX, nMouseY);
        }

        /*
         * A sample keyboard callback (for game mode window)
         */
        static void SampleGameModeKeyboard(byte cChar, int nMouseX, int nMouseY)
        {
            if (cChar == 27)
                g_LeaveGameMode = 1;
        }


        /*
        * A sample special callback
        */
        static void SampleSpecial(int nSpecial, int nMouseX, int nMouseY)
        {
            Console.WriteLine("SampleSpecial(): special keypress %i at (%i,%i)\n",
                    nSpecial, nMouseX, nMouseY);
        }

        /*
         * A sample menu callback
         */
        static void SampleMenu(int menuID)
        {
            /*
             * Just print something funny
             */
            Console.WriteLine("SampleMenu() callback executed, menuID is %i\n", menuID);
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            int menuID, subMenuA, subMenuB;

            Glut.glutInitDisplayString("stencil~2 rgb double depth>=16 samples");
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Glut.glutInitWindowPosition(100, 100);

            Glut.glutInit();

            subMenuA = Glut.glutCreateMenu(SampleMenu);
            Glut.glutAddMenuEntry("Sub menu A1 (01)", 1);
            Glut.glutAddMenuEntry("Sub menu A2 (02)", 2);
            Glut.glutAddMenuEntry("Sub menu A3 (03)", 3);

            subMenuB = Glut.glutCreateMenu(SampleMenu);
            Glut.glutAddMenuEntry("Sub menu B1 (04)", 4);
            Glut.glutAddMenuEntry("Sub menu B2 (05)", 5);
            Glut.glutAddMenuEntry("Sub menu B3 (06)", 6);
            Glut.glutAddSubMenu("Going to sub menu A", subMenuA);

            menuID = Glut.glutCreateMenu(SampleMenu);
            Glut.glutAddMenuEntry("Entry one", 1);
            Glut.glutAddMenuEntry("Entry two", 2);
            Glut.glutAddMenuEntry("Entry three", 3);
            Glut.glutAddMenuEntry("Entry four", 4);
            Glut.glutAddMenuEntry("Entry five", 5);
            Glut.glutAddSubMenu("Enter sub menu A", subMenuA);
            Glut.glutAddSubMenu("Enter sub menu B", subMenuB);

            Glut.glutCreateWindow("Hello world!");
            Glut.glutDisplayFunc(new Glut.DisplayCallback(SampleDisplay));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(SampleReshape));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(SampleKeyboard));
            Glut.glutSpecialFunc(new Glut.SpecialCallback(SampleSpecial));
            Glut.glutIdleFunc(new Glut.IdleCallback(SampleIdle));
            Glut.glutAttachMenu(Glut.GLUT_LEFT_BUTTON);

            Glut.glutInitWindowPosition(200, 200);
            Glut.glutCreateWindow("I am not Jan B.");
            Glut.glutDisplayFunc(new Glut.DisplayCallback(SampleDisplay));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(SampleReshape));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(SampleKeyboard));
            Glut.glutSpecialFunc(new Glut.SpecialCallback(SampleSpecial));
            Glut.glutIdleFunc(new Glut.IdleCallback(SampleIdle));
            Glut.glutAttachMenu(Glut.GLUT_LEFT_BUTTON);

            Console.WriteLine("Testing game mode string parsing, don't panic!\n");
            Glut.glutGameModeString("320x240:32@100");
            Glut.glutGameModeString("640x480:16@72");
            Glut.glutGameModeString("1024x768");
            Glut.glutGameModeString(":32@120");
            Glut.glutGameModeString("Toudi glupcze, Danwin bedzie moj!");
            Glut.glutGameModeString("640x480:16@72");

            Glut.glutEnterGameMode();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(SampleDisplay));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(SampleReshape));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(SampleGameModeKeyboard));
            Glut.glutIdleFunc(new Glut.IdleCallback(SampleIdle));
            Glut.glutAttachMenu(Glut.GLUT_LEFT_BUTTON);

            Console.WriteLine("current window is %ix%i+%i+%i",
                    Glut.glutGet(Glut.GLUT_WINDOW_X), Glut.glutGet(Glut.GLUT_WINDOW_Y),
                    Glut.glutGet(Glut.GLUT_WINDOW_WIDTH), Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT)
            );

            /*
             * Enter the main FreeGLUT processing loop
             */
            Glut.glutMainLoop();

            Console.WriteLine("glutMainLoop() termination works fine!\n");
        }
    }
}
