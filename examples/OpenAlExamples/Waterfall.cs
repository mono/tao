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
// Dan Ricart (ricart3@tcnj.edu)
#endregion Original Credits / License

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Tao.FreeGlut;
using Tao.OpenAl;
using Tao.OpenGl;

namespace OpenAlExamples {
    #region Class Documentation
    /// <summary>
    ///     Programming 3D Sound With OpenAL
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Dan Ricart
    ///         http://devmaster.net/articles/openal/openal.php
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    ///     <para>
    ///         The author's original code used Windows-specific code for window management, OpenGL
    ///         context creation, timing, and input.  I've taken the liberty of using GLUT such that
    ///         it cross-platform for those non-Windows users.  It's not quite as smooth in the
    ///         animation and control due to TickCount being a poor timer and my poor conversion of
    ///         the mouse handling, however, it's good enough to get by.
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Waterfall {
        // --- Fields ---
        #region Private Constants
        private const float PI_OVER_180 = 0.0174532925f;
        #endregion Private Constants

        #region Private Fields
//        private static int window;
//        private static int windowWidth;
//        private static int windowHeight;
        private static float heading;
        private static float xPosition;
        private static float yPosition;
        private static float zPosition;
        private static float yRotation;
        private static float pitch;
        private static float waterOffset;
        private static int[] texture = new int[6];
        private static Sound sound = new Sound();
        private static int[ , ] collisionArray = new int[18, 19];
        private static int polygonCount;
        private static int waterPolygonCount;
        private static Polygon[] polygons;
        private static Polygon[] waterPolygons;
        private static float currentTime;
        private static float oldTime;
        private static float timeElapsed;
        private static float secondsPerFrame;
        private static float desiredDistance = 2.0f;
        private static float movementValue;
        private static int oldMouseX;
        private static int oldMouseY;
        #endregion Private Fields

        #region Private Structs
        private struct Polygon {
            public float[] X;
            public float[] Y;
            public float[] Z;
            public float[] U;
            public float[] V;
            public int TextureId;
        }
        #endregion Private Structs

        // --- Entry Point ---
        #region Run()
		/// <summary>
		/// 
		/// </summary>
        public static void Run() {
            Initialize();
            Glut.glutMainLoop();
            Finish();
        }
        #endregion Run()

        // --- Lesson Methods ---
        #region Display()
        private static void Display() {
            float sceneRotationY;
            double[] matrix = new double[16];

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);    // Clear The Screen And Depth Buffer
            Gl.glLoadIdentity();                                            // Reset The View

            sceneRotationY = 360.0f - yRotation;                            // Calculate The Scene Rotation

            Gl.glRotatef(pitch, 1, 0, 0);                                   // Adjust Player's Pitch
            Gl.glRotatef(sceneRotationY, 0, 1, 0);                          // Adjust Player's Rotation
            Gl.glTranslatef(-xPosition, -yPosition, -zPosition);            // Move The Player

            DrawLevel();                                                    // Draw The Level
            DrawWater();                                                    // Draw The Water

            Gl.glGetDoublev(Gl.GL_MODELVIEW_MATRIX, matrix);                // Get Current View Matrix

            sound.SetListenerPosition(xPosition, yPosition, zPosition);     // Set Listener Position
            // Set Listener Orientation, First 3 Numbers Are For The Forward Vector, Last Three Are For The Up Vector
            sound.SetListenerOrientation(-(float) matrix[2], -(float) matrix[6], -(float) matrix[10], (float) matrix[1], (float) matrix[5], (float) matrix[9]);

            Gl.glFinish();
            Glut.glutSwapBuffers();                                         // Swap The Buffers
        }
        #endregion Display()

        #region DrawLevel()
        private static void DrawLevel() {
            for(int i = 0; i < polygonCount; i++) {                         // Draw The Level Polygons
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[polygons[i].TextureId]);
                Gl.glBegin(Gl.GL_QUADS);
                    for(int j = 0; j < 4; j++) {
                        Gl.glTexCoord2f(polygons[i].U[j], polygons[i].V[j]);
                        Gl.glVertex3f(polygons[i].X[j], polygons[i].Y[j], polygons[i].Z[j]);
                    }
                Gl.glEnd();
            }
        }
        #endregion DrawLevel()

        #region DrawWater()
        private static void DrawWater() {
            Gl.glEnable(Gl.GL_BLEND);                                       // Enable Blending
            for(int i = 0; i < waterPolygonCount; i++) {                    // Now Draw The Water Polygons
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[waterPolygons[i].TextureId]);

                Gl.glBegin(Gl.GL_QUADS);
                    for(int j = 0; j < 4; j++) {
                        Gl.glTexCoord2f(waterPolygons[i].U[j], waterPolygons[i].V[j] + waterOffset);
                        Gl.glVertex3f(waterPolygons[i].X[j], waterPolygons[i].Y[j], waterPolygons[i].Z[j]);
                    }
                Gl.glEnd();
            }
            Gl.glDisable(Gl.GL_BLEND);                                      // Disable Blending
        }
        #endregion DrawWater()

        #region Finish()
		/// <summary>
		/// 
		/// </summary>
        public static void Finish() {
            sound.Destroy();
            Alut.alutExit();
        }
        #endregion Finish()

        #region string FindFile(string fileName)
        private static string FindFile(string fileName) {
            string originalName = fileName;

            if(File.Exists(fileName)) {
                return fileName;
            }
            else if(File.Exists("Data/" + fileName)) {
                return "Data/" + fileName;
            }
            else if(File.Exists("../../Data/" + fileName)) {
                return "../../Data/" + fileName;
            }
            else {
                Console.WriteLine("Could not locate file: " + originalName);
                return null;
            }
        }
        #endregion string FindFile(string fileName)

        #region Idle()
        private static void Idle() {
            currentTime = Environment.TickCount;
            timeElapsed = currentTime - oldTime;
            secondsPerFrame = timeElapsed / 1000.0f;
            waterOffset += secondsPerFrame / 2.0f;
            if(waterOffset >= 1.0f) {
                waterOffset -= 1.0f;
            }
            // Environment.TickCount's resolution and latency isn't really good enough for this, so I'm manually setting a value
            movementValue = (float) desiredDistance * secondsPerFrame + 0.2f;
            Glut.glutPostRedisplay();
            oldTime = currentTime;
        }
        #endregion Idle()

        #region Initialize()
        private static void Initialize() {
            Console.WriteLine("Controls:");                                 // Print Input Help
            Console.WriteLine("W: Move Forward");
            Console.WriteLine("A: Move Left");
            Console.WriteLine("S: Move Backward");
            Console.WriteLine("D: Move Right");
            Console.WriteLine("Mouse Controls View");
            Console.WriteLine("ESC: Exit");

            Alut.alutInit();                                                // Initialize OpenAL

            Glut.glutInit();                                                // Initialize GLUT
            // Set GL Context Properties
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(640, 480);                              // Set Window Size
            Glut.glutCreateWindow("OpenAL Tutorial");              // Create Window

            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));        // Display Delegate
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));     // Keyboard Delegate
            Glut.glutIdleFunc(new Glut.IdleCallback(Idle));                 // Idle Delegate
            // Mouse Movement Delegate
            Glut.glutPassiveMotionFunc(new Glut.PassiveMotionCallback(Mouse));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));        // Window Resize Delegate

            LoadLevel();                                                    // Load The Level
            LoadWater();                                                    // Load The Water
            LoadCollision();                                                // Load The Collision Map
            xPosition = 3.0f;                                               // Set Our Initial Player Position
            yPosition = 1.0f;
            zPosition = 5.0f;
            LoadSounds();                                                   // Load The Sounds
            LoadTextures();                                                 // Load The Textures
            Gl.glEnable(Gl.GL_TEXTURE_2D);                                  // Enable Texture Mapping
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);                     // Set The Blending Function For Translucency
            Gl.glClearColor(0.0f, 0.8f, 1.0f, 0.0f);                        // Clear Background Color To A Turquiose Blueish Color
            Gl.glClearDepth(1.0);                                           // Enables Clearing Of The Depth Buffer
            Gl.glDepthFunc(Gl.GL_LESS);                                     // The Type Of Depth Test To Do
            Gl.glEnable(Gl.GL_DEPTH_TEST);                                  // Enables Depth Testing
            Gl.glShadeModel(Gl.GL_SMOOTH);                                  // Enables Smooth Color Shading
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);     // Really Nice Perspective Calculations

            oldTime = currentTime = Environment.TickCount;                  // Initialize The Timer
        }
        #endregion Initialize()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            float newX, newZ;
            int xp, zp;

            switch(key) {
                case (byte) 'w':
                case (byte) 'W':
                    newX = xPosition - (float) (Math.Sin(heading * PI_OVER_180) * movementValue);
                    newZ = zPosition;
                    xp = RoundUp(newX);
                    zp = RoundUp(newZ);
                    if(collisionArray[zp, xp] == 1) {
                        newX = xPosition;
                    }
                    else {
                        xPosition -= (float) (Math.Sin(heading * PI_OVER_180) * movementValue);
                    }

                    newZ = zPosition - (float) (Math.Cos(heading * PI_OVER_180) * movementValue);
                    xp = RoundUp(newX);
                    zp = RoundUp(newZ);
                    if(collisionArray[zp, xp] == 1) {
                        newZ = zPosition;
                    }
                    else {
                        zPosition -= (float) (Math.Cos(heading * PI_OVER_180) * movementValue);
                    }
                    break;
                case (byte) 's':
                case (byte) 'S':
                    newX = xPosition + (float) Math.Sin(heading * PI_OVER_180) * movementValue;
                    newZ = zPosition;
                    xp = RoundUp(newX);
                    zp = RoundUp(newZ);
                    if(collisionArray[zp, xp] == 1) {
                        newX = xPosition;
                    }
                    else {
                        xPosition += (float) Math.Sin(heading * PI_OVER_180) * movementValue;
                    }

                    newZ = zPosition + (float) Math.Cos(heading * PI_OVER_180) * movementValue;
                    xp = RoundUp(newX);
                    zp = RoundUp(newZ);
                    if(collisionArray[zp, xp] == 1) {
                        newZ = zPosition;
                    }
                    else {
                        zPosition += (float) Math.Cos(heading * PI_OVER_180) * movementValue;
                    }
                    break;
                case (byte) 'a':
                case (byte) 'A':
                    newX = xPosition + (float) Math.Sin((heading - 90) * PI_OVER_180) * movementValue;
                    newZ = zPosition;
                    xp = RoundUp(newX);
                    zp = RoundUp(newZ);
                    if(collisionArray[zp, xp] == 1) {
                        newX = xPosition;
                    }
                    else {
                        xPosition += (float) Math.Sin((heading - 90) * PI_OVER_180) * movementValue;
                    }

                    newZ = zPosition + (float) Math.Cos((heading - 90) * PI_OVER_180) * movementValue;
                    xp = RoundUp(newX);
                    zp = RoundUp(newZ);
                    if(collisionArray[zp, xp] == 1) {
                        newZ = zPosition;
                    }
                    else {
                        zPosition += (float) Math.Cos((heading - 90) * PI_OVER_180) * movementValue;
                    }
                    break;
                case (byte) 'd':
                case (byte) 'D':
                    newX = xPosition + (float) Math.Sin((heading + 90) * PI_OVER_180) * movementValue;
                    newZ = zPosition;
                    xp = RoundUp(newX);
                    zp = RoundUp(newZ);
                    if(collisionArray[zp, xp] == 1) {
                        newX = xPosition;
                    }
                    else {
                        xPosition += (float) Math.Sin((heading + 90) * PI_OVER_180) * movementValue;
                    }

                    newZ = zPosition + (float) Math.Cos((heading + 90) * PI_OVER_180) * movementValue;
                    xp = RoundUp(newX);
                    zp = RoundUp(newZ);
                    if(collisionArray[zp, xp] == 1) {
                        newZ = zPosition;
                    }
                    else {
                        zPosition += (float) Math.Cos((heading + 90) * PI_OVER_180) * movementValue;
                    }
                    break;
                case 27:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Bitmap LoadBmp(string fileName)
        private static Bitmap LoadBmp(string fileName) {                    // Loads A Bitmap Image
            fileName = FindFile(fileName);
            Bitmap bitmap = new Bitmap(fileName);                           // Load And Return The Bitmap
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);              // Flip The Bitmap Along The Y-Axis
            return bitmap;                                                  // Return The Bitmap
        }
        #endregion Bitmap LoadBmp(string fileName)

        #region LoadCollision()
        private static void LoadCollision() {
            string fileName = FindFile("OpenAlExamples.Waterfall.Collision.txt");
            StreamReader reader = new StreamReader(fileName, new ASCIIEncoding());
            string line = "";
            string[] split;

            for(int i = 17; i >= 0; i--) {
                ReadStr(reader, out line);
                line = line.Trim();
                split = line.Split();
                for(int j = 18; j >= 0; j--) {
                    collisionArray[i, j] = Int32.Parse(split[j]);
                }
            }

            reader.Close();
        }
        #endregion LoadCollision()

        #region LoadLevel()
        private static void LoadLevel() {
            string fileName = FindFile("OpenAlExamples.Waterfall.Level.txt");
            StreamReader reader = new StreamReader(fileName, new ASCIIEncoding());
            string line = "";

            ReadStr(reader, out line);
            polygonCount = Int32.Parse(line);
            polygons = new Polygon[polygonCount];

            for(int i = 0; i < polygonCount; i++) {
                polygons[i].X = new float[4];
                polygons[i].Y = new float[4];
                polygons[i].Z = new float[4];
                polygons[i].U = new float[4];
                polygons[i].V = new float[4];
                for(int j = 0; j < 4; j++) {
                    ReadStr(reader, out line);
                    Match match = Regex.Match(line, @"(?<X>-?\d+.\d+)\s*(?<Y>-?\d+.\d+)\s*(?<Z>-?\d+.\d+)\s*(?<U>-?\d+.\d+)\s*(?<V>-?\d+.\d+)\s*(?<TexId>\d+)", RegexOptions.ExplicitCapture);
                    polygons[i].X[j] = Single.Parse(match.Groups["X"].ToString());
                    polygons[i].Y[j] = Single.Parse(match.Groups["Y"].ToString());
                    polygons[i].Z[j] = Single.Parse(match.Groups["Z"].ToString());
                    polygons[i].U[j] = Single.Parse(match.Groups["U"].ToString());
                    polygons[i].V[j] = Single.Parse(match.Groups["V"].ToString());
                    polygons[i].TextureId = Int32.Parse(match.Groups["TexId"].ToString());
                }
            }

            reader.Close();
        }
        #endregion void LoadLevel()

        #region LoadSounds()
        private static void LoadSounds() {
            string fileName = FindFile("OpenAlExamples.Waterfall.Water.wav");
            sound.Load(fileName, true);                                     // Load The Water Sound
            sound.SetProperties(8.5f, 0.0f, 15.0f, 0.0f, 0.0f, 0.0f);       // Set The Position Of The Sound Effect
            sound.Play();                                                   // Start Playing The Sound
            sound.SetListenerPosition(xPosition, yPosition, zPosition);     // Set The Initial Listener Position
        }
        #endregion LoadSounds()

        #region LoadTextures()
        private static void LoadTextures() {
            Bitmap[] textureImage = new Bitmap[6];                          // Storage Space For The Textures
            Rectangle rectangle;                                            // Rectangle For Locking The Bitmap In Memory
            BitmapData textureData = null;                                  // The Bitmap's Pixel Data

            textureImage[0] = LoadBmp("OpenAlExamples.Waterfall.Grass.bmp");
            textureImage[1] = LoadBmp("OpenAlExamples.Waterfall.Evergreen.bmp");
            textureImage[2] = LoadBmp("OpenAlExamples.Waterfall.Rocks.bmp");
            textureImage[3] = LoadBmp("OpenAlExamples.Waterfall.Water.bmp");
            textureImage[4] = LoadBmp("OpenAlExamples.Waterfall.Dirt.bmp");
            textureImage[5] = LoadBmp("OpenAlExamples.Waterfall.Wood.bmp");

            Gl.glGenTextures(6, texture);                                   // Create The Textures
            for(int i = 0; i < 6; i++) {
                // Select The Whole Bitmap
                rectangle = new Rectangle(0, 0, textureImage[i].Width, textureImage[i].Height);
                // Get The Pixel Data From The Locked Bitmap
                textureData = textureImage[i].LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                // Create Linear Filtered Texture
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[i]);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
                Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB8, textureData.Width, textureData.Height, 0, Gl.GL_BGR, Gl.GL_UNSIGNED_BYTE, textureData.Scan0);

                if(textureImage[i] != null) {                               // If Texture Exists
                    textureImage[i].UnlockBits(textureData);                // Unlock The Pixel Data From Memory
                    textureImage[i].Dispose();                              // Free The Texture Image
                }
            }
        }
        #endregion LoadTextures()

        #region LoadWater()
        private static void LoadWater() {
            string fileName = FindFile("OpenAlExamples.Waterfall.Water.txt");
            StreamReader reader = new StreamReader(fileName, new ASCIIEncoding());
            string line = "";

            ReadStr(reader, out line);
            waterPolygonCount = Int32.Parse(line);
            waterPolygons = new Polygon[waterPolygonCount];

            for(int i = 0; i < waterPolygonCount; i++) {
                waterPolygons[i].X = new float[4];
                waterPolygons[i].Y = new float[4];
                waterPolygons[i].Z = new float[4];
                waterPolygons[i].U = new float[4];
                waterPolygons[i].V = new float[4];
                for(int j = 0; j < 4; j++) {
                    ReadStr(reader, out line);
                    Match match = Regex.Match(line, @"(?<X>-?\d+.\d+)\s*(?<Y>-?\d+.\d+)\s*(?<Z>-?\d+.\d+)\s*(?<U>-?\d+.\d+)\s*(?<V>-?\d+.\d+)\s*(?<TexId>\d+)", RegexOptions.ExplicitCapture);
                    waterPolygons[i].X[j] = Single.Parse(match.Groups["X"].ToString());
                    waterPolygons[i].Y[j] = Single.Parse(match.Groups["Y"].ToString());
                    waterPolygons[i].Z[j] = Single.Parse(match.Groups["Z"].ToString());
                    waterPolygons[i].U[j] = Single.Parse(match.Groups["U"].ToString());
                    waterPolygons[i].V[j] = Single.Parse(match.Groups["V"].ToString());
                    waterPolygons[i].TextureId = Int32.Parse(match.Groups["TexId"].ToString());
                }
            }

            reader.Close();
        }
        #endregion LoadWater()

        #region Mouse(int x, int y)
        private static void Mouse(int x, int y) {
            // Compute Our New Direction
            heading -= x - oldMouseX;
            pitch += y - oldMouseY;
            yRotation = heading;
            oldMouseX = x;
            oldMouseY = y;
        }
        #endregion Mouse(int x, int y)

        #region ReadStr(StreamReader stream, out string text)
        private static void ReadStr(StreamReader stream, out string text) {
            do {
                text = stream.ReadLine();
            } while((text.StartsWith("/")) || (text.StartsWith("\n")) || text == "");
        }
        #endregion ReadStr(StreamReader stream, out string text)

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            if(h == 0) {                                                    // Prevent A Divide By Zero Exception
                h = 1;                                                      // By Making Height Equal At Least One
            }
            //windowWidth = w;
            //windowHeight = h;
            Gl.glViewport(0, 0, w, h);                                      // Reset The Current Viewport
            Gl.glMatrixMode(Gl.GL_PROJECTION);                              // Select The Projection Matrix
            Gl.glLoadIdentity();                                            // Reset The Projection Matrix
            Glu.gluPerspective(45.0, (float) w / (float) h, 0.1, 2000.0);   // Calculate The Aspect Ratio Of The Window
            Gl.glMatrixMode(Gl.GL_MODELVIEW);                               // Select The Modelview Matrix
            Gl.glLoadIdentity();                                            // Reset The Modelview Matrix
        }
        #endregion Reshape(int w, int h)

        #region int RoundUp(float x)
        private static int RoundUp(float x) {
            int n;

            if(x < 0) {
                n = (int) x;
            }
            else {
                n = (int) x + 1;
            }

            return n;
        }
        #endregion int RoundUp(float x)
    }
}
