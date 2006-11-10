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
// http://www.dev-gallery.com
#endregion Original Credits / License

using System;
using System.IO;
using System.Text;
using Tao.FreeGlut;
using Tao.OpenAl;
using Tao.OpenGl;

namespace OpenAlExamples {
    #region Class Documentation
    /// <summary>
    ///     Using OpenAL (Open Audio Library) and OpenGL to create a 3D application with 3D sound
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    http://www.dev-gallery.com
    ///         http://www.dev-gallery.com/programming/openAL/basic/basicOpenAL_1.htm
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    ///     <para>
    ///         The author's original code had many ifdefs for linux/windows specific things.
    ///         Using the Tao implementation of OpenAL this should not be necessary.  Also,
    ///         the author used some IASIG methods from OpenAL to set some environments up on
    ///         Windows.  These are poorly documented by OpenAL and I'm not sure what state
    ///         they're in currently, so I've left them out here.
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Boxes {
        // --- Fields ---
        #region Private Constants
        private const int NUM_BUFFERS = 3;
        private const int NUM_SOURCES = 3;
        #endregion Private Constants

        #region Private Fields
        private static float[] listenerPosition = {0, 0, 4};
        private static float[] listenerVelocity = {0, 0, 0};
        private static float[] listenerOrientation = {0, 0, -1, 0, 1, 0};
        private static float[] redPosition = {-2, 0, 0};
        private static float[] redVelocity = {0, 0, 0};
        private static float[] greenPosition = {2, 0, 0};
        private static float[] greenVelocity = {0, 0, 0};
        private static float[] bluePosition = {0, 0, -4};
        private static float[] blueVelocity = {0, 0, 0};
        private static int[] buffer = new int[NUM_BUFFERS];
        private static int[] source = new int[NUM_SOURCES];
        private static int window;
        private static int size;
        private static float frequency;
        private static int format;
        private static IntPtr data = IntPtr.Zero;
        //private static int loop;
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
		/// <summary>
		/// 
		/// </summary>
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(400, 400);
            Alut.alutInit();
            window = Glut.glutCreateWindow("OpenAL & OpenGL | www.dev-gallery.com");
            Init();
            Console.WriteLine("Controls:");
            Console.WriteLine("1: Activate Red Sound");
            Console.WriteLine("2: Activate Green Sound");
            Console.WriteLine("3: Activate Blue Sound");
            Console.WriteLine("4: Deactivate Red Sound");
            Console.WriteLine("5: Deactivate Green Sound");
            Console.WriteLine("6: Deactivate Blue Sound");
            Console.WriteLine("W: Move Forward");
            Console.WriteLine("A: Move Left");
            Console.WriteLine("S: Move Backward");
            Console.WriteLine("D: Move Right");
            Console.WriteLine("ESC: Exit");
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Lesson Methods ---
        #region Display()
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();
                Gl.glRotatef(20, 1, 1, 0);

                Gl.glPushMatrix();
                    Gl.glTranslatef(redPosition[0], redPosition[1], redPosition[2]);
                    Gl.glColor3f(1, 0, 0);
                    Glut.glutWireCube(0.5);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                    Gl.glTranslatef(greenPosition[0], greenPosition[1], greenPosition[2]);
                    Gl.glColor3f(0, 1, 0);
                    Glut.glutWireCube(0.5);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                    Gl.glTranslatef(bluePosition[0], bluePosition[1], bluePosition[2]);
                    Gl.glColor3f(0, 0, 1);
                    Glut.glutWireCube(0.5);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                    Gl.glTranslatef(listenerPosition[0], listenerPosition[1], listenerPosition[2]);
                    Gl.glColor3f(1, 1, 1);
                    Glut.glutWireCube(0.5);
                Gl.glPopMatrix();
            Gl.glPopMatrix();
            Glut.glutSwapBuffers();
        }
        #endregion Display()

        #region string FindFile(string fileName)
        private static string FindFile(string fileName) {
            string originalName = fileName;

            string filePath = Path.Combine("..", "..");
            string fileDirectory = "Data";

            if (File.Exists(fileName))
            {
                filePath = "";
                fileDirectory = "";
            }
            else if (File.Exists(Path.Combine(fileDirectory, fileName)))
            {
                filePath = "";
            }
            //else {
            //    Console.WriteLine("Could not locate file: " + originalName);
            //    return null;
            //}
            return Path.Combine(Path.Combine(filePath, fileDirectory), fileName);
        }
        #endregion string FindFile(string fileName)

        #region Init()
        private static void Init() {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            Al.alListenerfv(Al.AL_POSITION, listenerPosition);
            Al.alListenerfv(Al.AL_VELOCITY, listenerVelocity);
            Al.alListenerfv(Al.AL_ORIENTATION, listenerOrientation);

            Al.alGetError();
            Al.alGenBuffers(NUM_BUFFERS, buffer);
            if(Al.alGetError() != Al.AL_NO_ERROR) {
                Console.WriteLine("Error creating buffers.");
                Environment.Exit(-1);
            }

            string fileName = "";
            fileName = FindFile("OpenAlExamples.Boxes.C.wav");
            if(fileName == null) {
                Environment.Exit(-1);
            }
            data = Alut.alutLoadMemoryFromFile(fileName, out format, out size, out frequency);
			Al.alBufferData(buffer[0], format, data, size, (int)frequency);
            //Alut.alutUnloadWAV(format, out data, size, frequency);

            fileName = FindFile("OpenAlExamples.Boxes.B.wav");
            if(fileName == null) {
                Environment.Exit(-1);
            }
            data = Alut.alutLoadMemoryFromFile(fileName, out format, out size, out frequency);
            Al.alBufferData(buffer[1], format, data, size, (int)frequency);
            //Alut.alutUnloadWAV(format, out data, size, frequency);

            fileName = FindFile("OpenAlExamples.Boxes.A.wav");
            if(fileName == null) {
                Environment.Exit(-1);
            }
            data = Alut.alutLoadMemoryFromFile(fileName, out format, out size, out frequency);
            Al.alBufferData(buffer[2], format, data, size, (int)frequency);
            //Alut.alutUnloadWAV(format, out data, size, frequency);

            Al.alGetError();
            Al.alGenSources(NUM_SOURCES, source);
            if(Al.alGetError() != Al.AL_NO_ERROR) {
                Console.WriteLine("Error creating sources.");
                Environment.Exit(-1);
            }

            Al.alSourcef(source[0], Al.AL_PITCH, 1.0f);
            Al.alSourcef(source[0], Al.AL_GAIN, 1.0f);
            Al.alSourcefv(source[0], Al.AL_POSITION, redPosition);
            Al.alSourcefv(source[0], Al.AL_VELOCITY, redVelocity);
            Al.alSourcei(source[0], Al.AL_BUFFER, buffer[0]);
            Al.alSourcei(source[0], Al.AL_LOOPING, Al.AL_TRUE);

            Al.alSourcef(source[1], Al.AL_PITCH, 1.0f);
            Al.alSourcef(source[1], Al.AL_GAIN, 1.0f);
            Al.alSourcefv(source[1], Al.AL_POSITION, greenPosition);
            Al.alSourcefv(source[1], Al.AL_VELOCITY, greenVelocity);
            Al.alSourcei(source[1], Al.AL_BUFFER, buffer[1]);
            Al.alSourcei(source[1], Al.AL_LOOPING, Al.AL_TRUE);

            Al.alSourcef(source[2], Al.AL_PITCH, 1.0f);
            Al.alSourcef(source[2], Al.AL_GAIN, 1.0f);
            Al.alSourcefv(source[2], Al.AL_POSITION, bluePosition);
            Al.alSourcefv(source[2], Al.AL_VELOCITY, blueVelocity);
            Al.alSourcei(source[2], Al.AL_BUFFER, buffer[2]);
            Al.alSourcei(source[2], Al.AL_LOOPING, Al.AL_TRUE);
        }
        #endregion Init()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case (byte) '1':
                    Al.alSourcePlay(source[0]);
                    break;
                case (byte) '2':
                    Al.alSourcePlay(source[1]);
                    break;
                case (byte) '3':
                    Al.alSourcePlay(source[2]);
                    break;
                case (byte) '4':
                    Al.alSourceStop(source[0]);
                    break;
                case (byte) '5':
                    Al.alSourceStop(source[1]);
                    break;
                case (byte) '6':
                    Al.alSourceStop(source[2]);
                    break;
                case (byte) 'w':
                case (byte) 'W':
                    listenerPosition[2] -= 0.1f;
                    Al.alListenerfv(Al.AL_POSITION, listenerPosition);
                    break;
                case (byte) 'a':
                case (byte) 'A':
                    listenerPosition[0] -= 0.1f;
                    Al.alListenerfv(Al.AL_POSITION, listenerPosition);
                    break;
                case (byte) 's':
                case (byte) 'S':
                    listenerPosition[2] += 0.1f;
                    Al.alListenerfv(Al.AL_POSITION, listenerPosition);
                    break;
                case (byte) 'd':
                case (byte) 'D':
                    listenerPosition[0] += 0.1f;
                    Al.alListenerfv(Al.AL_POSITION, listenerPosition);
                    break;
                case 27:
                    Al.alSourceStop(source[2]);
                    Al.alSourceStop(source[1]);
                    Al.alSourceStop(source[0]);
                    Alut.alutExit();
                    Glut.glutDestroyWindow(window);
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Glut.glutPostRedisplay();
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(60.0, (float)w / (float) h, 1.0, 30.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glTranslatef(0.0f, 0.0f, -6.6f);
        }
        #endregion Reshape(int w, int h)
    }
}
