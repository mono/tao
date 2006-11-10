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
    qix.c
    Nate Robins, 1997

    An example of a 'qix'-like line demo, but without the traditional
    erase lines, and with anti-aliased lines.
 */
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace NateRobins {
    #region Class Documentation
    /// <summary>
    ///     An example of a 'qix'-like line demo, but without the traditional erase lines,
    ///     and with anti-aliased lines.
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
    public sealed class Qix {
        // --- Fields ---
        #region Private Constants
        private const int COLORS = 48;
        #endregion Private Constants

        #region Private Fields
        private static bool screensaver = false;
        private static Point first;
        private static Point second;
        private static int beenHere;
        private static int color;
        private static int points = 73;
        private static float step = 27.232743f;
        private static float firstX = 0.223487f;
        private static float firstY = 0.532978f;
        private static float secondX = 0.63257f;
        private static float secondY = 0.325897f;

        private static byte[/*COLORS*/,/*3*/] colors = {
            {255,   0,   0},
            {255,  32,   0},
            {255,  64,   0},
            {255,  96,   0},
            {255, 128,   0},
            {255, 160,   0},
            {255, 192,   0},
            {255, 224,   0},
            {255, 255,   0},
            {224, 255,   0},
            {192, 255,   0},
            {160, 255,   0},
            {128, 255,   0},
            { 96, 255,   0},
            { 64, 255,   0},
            { 32, 255,   0},
            {  0, 255,   0},
            {  0, 255,  32},
            {  0, 255,  64},
            {  0, 255,  96},
            {  0, 255, 128},
            {  0, 255, 160},
            {  0, 255, 192},
            {  0, 255, 224},
            {  0, 255, 255},
            {  0, 224, 255},
            {  0, 196, 255},
            {  0, 160, 255},
            {  0, 128, 255},
            {  0,  96, 255},
            {  0,  64, 255},
            {  0,  32, 255},
            {  0,   0, 255},
            { 32,   0, 255},
            { 64,   0, 255},
            { 96,   0, 255},
            {128,   0, 255},
            {160,   0, 255},
            {196,   0, 255},
            {224,   0, 255},
            {255,   0, 255},
            {255,   0, 224},
            {255,   0, 196},
            {255,   0, 160},
            {255,   0, 128},
            {255,   0,  96},
            {255,   0,  64},
            {255,   0,  32}
        };
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() {
            try {
                //if(args.Length > 1) {
                //    if(args[1] == "-h") {
                //        Console.WriteLine(args[0] + " [lines] [step]");
                //        Environment.Exit(0);
                //    }
                //    else {
                //        points = Int32.Parse(args[1]);
                //        if(args.Length > 2) {
                //            step = Single.Parse(args[2]);
                //        }
                //    }
                //}
            }
            catch(Exception e) {
                Console.WriteLine("Error parsing commandline.  lines should be an integer, step should be a float.  Try again.\n\n" + e.ToString());
                Environment.Exit(-1);
            }

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGBA);
            Glut.glutInitWindowSize(320, 320);
            Glut.glutInitWindowPosition(50, 50);
            Glut.glutCreateWindow("Qix");

            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutIdleFunc(new Glut.IdleCallback(Idle));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));

            if(screensaver) {
                FullscreenMode();
            }
            else {
                WindowedMode();
            }

            InitLines();

            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region Bail(int code)
        private static void Bail(int code) {
            int i;
            Point nuke;

            for(i = 0; i < points; i++) {
                nuke = first;
                first = first.Next;
                nuke = null;
            }

            for(i = 0; i < points; i++) {
                nuke = second;
                second = second.Next;
                nuke = null;
            }

            Environment.Exit(code);
        }
        #endregion Bail(int code)

        #region FullscreenMode()
        private static void FullscreenMode() {
            int oldX = 50;
            int oldY = 50;
            int oldWidth = 320;
            int oldHeight = 320;

            if(screensaver) {
                Glut.glutKeyboardFunc(new Glut.KeyboardCallback(ScreensaverKeyboard));
                Glut.glutPassiveMotionFunc(new Glut.PassiveMotionCallback(ScreensaverPassive));
                Glut.glutMouseFunc(new Glut.MouseCallback(ScreensaverMouse));
            }
            else {
                Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            }
            Glut.glutSetCursor(Glut.GLUT_CURSOR_NONE);

            oldX = Glut.glutGet(Glut.GLUT_WINDOW_X);
            oldY = Glut.glutGet(Glut.GLUT_WINDOW_Y);
            oldWidth = Glut.glutGet(Glut.GLUT_WINDOW_WIDTH);
            oldHeight = Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT);

            Glut.glutFullScreen();
        }
        #endregion FullscreenMode()

        #region InitLines()
        private static void InitLines() {
            int i;
            Point newborn;
            Random random = new Random();

            firstX *= step;
            firstY *= step;
            secondX *= step;
            secondY *= step;

            for(i = 0; i < points; i++) {
                newborn = new Point();
                newborn.Next = first;
                newborn.X = -1.0f;
                newborn.Y = -1.0f;
                first = newborn;
            }

            newborn = first;
            while(newborn.Next != null) {
                newborn = newborn.Next;
            }
            newborn.Next = first;

            first.X = random.Next() % Glut.glutGet(Glut.GLUT_WINDOW_WIDTH);
            first.Y = random.Next() % Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT);

            for(i = 0; i < points; i++) {
                newborn = new Point();
                newborn.Next = second;
                newborn.X = -1.0f;
                newborn.Y = -1.0f;
                second = newborn;
            }

            newborn = second;
            while(newborn.Next != null) {
                newborn = newborn.Next;
            }
            newborn.Next = second;

            second.X = random.Next() % Glut.glutGet(Glut.GLUT_WINDOW_WIDTH);
            second.Y = random.Next() % Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT);
        }
        #endregion InitLines()

        #region WindowedMode()
        private static void WindowedMode() {
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutPassiveMotionFunc(null);
            Glut.glutMouseFunc(null);
            Glut.glutSetCursor(Glut.GLUT_CURSOR_INHERIT);
            Glut.glutPositionWindow(50, 50);
            Glut.glutReshapeWindow(320, 320);
        }
        #endregion WindowedMode()

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            int i;
        
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            first.Next.X = first.X + firstX;
            first.Next.Y = first.Y + firstY;
            first = first.Next;

            if(first.X < 0) {
                first.X = 0;
                firstX = -firstX;
            }
            else if(first.X > Glut.glutGet(Glut.GLUT_WINDOW_WIDTH)) {
                first.X = Glut.glutGet(Glut.GLUT_WINDOW_WIDTH);
                firstX = -firstX;
            }

            if(first.Y < 0) {
                first.Y = 0;
                firstY = -firstY;
            }
            else if(first.Y > Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT)) {
                first.Y = Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT);
                firstY = -firstY;
            }

            second.Next.X = second.X + secondX;
            second.Next.Y = second.Y + secondY;
            second = second.Next;

            if(second.X < 0) {
                second.X = 0;
                secondX = -secondX;
            }
            else if(second.X > Glut.glutGet(Glut.GLUT_WINDOW_WIDTH)) {
                second.X = Glut.glutGet(Glut.GLUT_WINDOW_WIDTH);
                secondX = -secondX;
            }

            if(second.Y < 0) {
                second.Y = 0;
                secondY = -secondY;
            }
            else if(second.Y > Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT)) {
                second.Y = Glut.glutGet(Glut.GLUT_WINDOW_HEIGHT);
                secondY = -secondY;
            }

            Gl.glBegin(Gl.GL_LINES);
                for(i = 0; i < points; i++) {
                    Gl.glVertex2i((int) first.X, (int) first.Y);
                    Gl.glVertex2i((int) second.X, (int) second.Y);
                    Gl.glColor3ub(colors[((color + i) % COLORS), 0], colors[((color + i) % COLORS), 1], colors[((color + i) % COLORS), 2]);
                    first = first.Next;
                    second = second.Next;
                }
            Gl.glEnd();

            color++;
            if(color >= COLORS) {
                color = 0;
            }

            Glut.glutSwapBuffers();
        }
        #endregion Display()

        #region Idle()
        private static void Idle() {
            Glut.glutPostRedisplay();
        }
        #endregion Idle()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case 27:
                    Bail(0);
                    break;
                case (byte) 'w':
                case (byte) 'W':
                    WindowedMode();
                    break;
                case (byte) 'f':
                case (byte) 'F':
                    FullscreenMode();
                    break;
                default:
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Reshape(int width, int height)
        private static void Reshape(int width, int height) {
            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0.0, width, 0.0, height, -1.0, 1.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
        }
        #endregion Reshape(int width, int height)

        #region ScreensaverKeyboard(byte key, int x, int y)
        private static void ScreensaverKeyboard(byte key, int x, int y) {
            Bail(0);
        }
        #endregion ScreensaverKeyboard(byte key, int x, int y)

        #region ScreensaverMouse(int button, int state, int x, int y)
        private static void ScreensaverMouse(int button, int state, int x, int y) {
            Bail(0);
        }
        #endregion ScreensaverMouse(int button, int state, int x, int y)

        #region ScreensaverPassive(int x, int y)
        private static void ScreensaverPassive(int x, int y) {
            // For some reason, GLUT sends an initial passive motion callback when a window is
            // initialized, so this would immediately terminate the program.  To get around this,
            // see if we've been here before.  (Actually if we've been here twice.)
            if(beenHere > 1) {
                Bail(0);
            }
            beenHere++;
        }
        #endregion ScreensaverPassive(int x, int y)

        #region Visibility(int state)
        private static void Visibility(int state) {
            if(state == Glut.GLUT_VISIBLE) {
                Glut.glutIdleFunc(new Glut.IdleCallback(Idle));
            }
            else {
                Glut.glutIdleFunc(null);
            }
        }
        #endregion Visibility(int state)
    }
}
