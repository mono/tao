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
    maiden.c
    Nate Robins, 1997

    A killer "Iron Maiden rocks out with OpenGL" demo (according to
    Mark Kilgard).
 */
#endregion Original Credits / License

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace NateRobins {
    #region Class Documentation
    /// <summary>
    ///     A killer "Iron Maiden rocks out with OpenGL" demo (according to Mark Kilgard).
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
    public sealed class Maiden {
        // --- Fields ---
        #region Private Constants
        private static int RI = 4;                  // Inner radius of torus
        private static int RO = 8;                  // Outer radius of torus
        private static int COLORS = 12;
        private static int NUMBERSTARS = 500;
        private static int RANDOMMAX = 0x7fff;
        #endregion Private Constants

        #region Private Fields
        private static Random random = new Random();
        private static Star[] stars = new Star[NUMBERSTARS];
        private static int lod = 24;                // Level of detail
        private static float spinX, spinY, spinZ;
        private static int numberSpheres = 12;
        private static int numberTextures = 4;
        private static int mode = Gl.GL_MODULATE;   // Modulate, decal
        private static int filter = Gl.GL_LINEAR;   // Texture filtering mode
        private static bool drawBackground = true;  // Draw background image?
        private static bool drawStars = true;       // Draw stars?
        private static bool texturing = true;       // Texturing?
        private static bool performanceTiming;      // Performance timing?
        private static bool frozen;                 // Animation frozen?
        private static int width, height;
        private static int backgroundTexture = 1;
        private static int i, start, last, end, step;

        private static byte[/*COLORS*/,/*3*/] colors = {
            {255,   0,   0},
            {255, 128,   0},
            {255, 255,   0},
            {128, 255,   0},
            {  0, 255,   0},
            {  0, 255, 128},
            {  0, 255, 255},
            {  0, 128, 255},
            {  0,   0, 255},
            {128,   0, 255},
            {255,   0, 255},
            {255,   0, 128}
        };

        private static string[] textureNames = {
            "NateRobins.Maiden.DeadOne.ppm",
            "NateRobins.Maiden.Virus.ppm",
            "NateRobins.Maiden.Ace.ppm",
            "NateRobins.Maiden.Space.ppm"
        };
        #endregion Private Fields

        #region Private Structs
        private struct Star {
            public float X, Y;
            public float VX, VY;
        }
        #endregion Private Structs

        // --- Entry Point ---
        #region Run()
        [STAThread]
        public static void Run() 
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE | Glut.GLUT_MULTISAMPLE | Glut.GLUT_RGBA);
            Glut.glutInitWindowSize(800, 600);
            Glut.glutInitWindowPosition(50, 50);
            Glut.glutCreateWindow("Maiden");

            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutIdleFunc(new Glut.IdleCallback(Idle));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutSpecialFunc(new Glut.SpecialCallback(Special));

            Glut.glutCreateMenu(new Glut.CreateMenuCallback(Menu));
            Glut.glutAddMenuEntry("Toggle texture mapping", (int) 't');
            Glut.glutAddMenuEntry("Toggle texture mode", (int) 'm');
            Glut.glutAddMenuEntry("Toggle filter mode", (int) 'f');
            Glut.glutAddMenuEntry("Toggle performance", (int) 'p');
            Glut.glutAddMenuEntry("Toggle background", (int) 'b');
            Glut.glutAddMenuEntry("Toggle animation", (int) ' ');
            Glut.glutAddMenuEntry("Toggle culling", (int) 'c');
            Glut.glutAddMenuEntry("Toggle stars", (int) '*');
            Glut.glutAddMenuEntry("Time full frame (no swap)", (int) 'n');
            Glut.glutAddMenuEntry("Print pixels/frame", (int) 'r');
            Glut.glutAddMenuEntry("", 0);
            Glut.glutAddMenuEntry("> and < keys change # of textures", 0);
            Glut.glutAddMenuEntry("Arrows up/down change level of detail", 0);
            Glut.glutAddMenuEntry("Arrows right/left change # of spheres", 0);
            Glut.glutAddMenuEntry("1-4 keys change background image", 0);
            Glut.glutAddMenuEntry("", 0);
            Glut.glutAddMenuEntry("Quit", (int) 'r');
            Glut.glutAttachMenu(Glut.GLUT_RIGHT_BUTTON);

            Init();
            LoadTextures();

            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region Color(byte color)
        private static void Color(byte color) {
            int index = COLORS / numberSpheres * color;

            Gl.glColor3ub(colors[index, 0], colors[index, 1], colors[index, 2]);
        }
        #endregion Color(byte color)

        #region Init()
        private static void Init() {
            float[] Ka = {0.2f, 0.2f, 0.2f, 1.0f};
            float[] Ks = {1.0f, 1.0f, 1.0f, 1.0f};

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_CULL_FACE);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_DIFFUSE);
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, 64);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, Ks);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, Ka);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, filter);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, filter);
        }
        #endregion Init()

        #region LoadTextures()
        private static void LoadTextures() {
            int w = 0;
            int h = 0;
            byte[] texture;

            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);

            // XXX - RE bug - must enable texture before bind.
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            for(int i = 0; i < 4; i++) {
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, i + 1);
                texture = PpmRead(textureNames[i], ref w, ref h);
                Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, 3, w, h, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, texture);
                texture = null;
            }

            /* XXX - RE bug - must enable texture before bind. */
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }
        #endregion LoadTextures()
        
        #region int Pixels()
        private static int Pixels() {
            int i, j, n, values;
            float ax, ay, bx, by, area, acc = 0;
            float[] buffer;

            // Calculate the size of the feedback buffer:
            //      lod * lod * 2 = number of triangles in the torus
            //      lod * 2 = number of triangles in each cap of a sphere
            //      lod * (lod - 2) * 2 = number of triangles in latitudinal strips of a sphere
            //      *8 = 3 vertices (2 values each) + polygon token and a vertex count
            //      NUMBERSTARS * 5 = line token + 2 vertices (2 values each)
            //      5 * 3 = (possibly 5) bitmap tokens + 1 vertex each (2 values each)
            buffer = new float[((lod * lod * 2 + (lod * 2 + lod * (lod - 2) * 2) * numberSpheres) * 8 + NUMBERSTARS * 5 + 5 * 3)];
            Gl.glFeedbackBuffer((lod * lod * 2 + (lod * 2 + lod * (lod - 2) * 2) * numberSpheres) * 8 + NUMBERSTARS * 5 + 5 * 3, Gl.GL_2D, buffer);
            Gl.glRenderMode(Gl.GL_FEEDBACK);
            Display();
            values = Gl.glRenderMode(Gl.GL_RENDER);
            i = 0;
            while(i < values) {
                if(buffer[i] == Gl.GL_POLYGON_TOKEN) {
                    i++;
                    n = (int) buffer[i];
                    i++;
                    for(j = 0; j < n - 2; j++) {
                        ax = buffer[i + 2 + 2 * j] - buffer[i + 0]; 
                        ay = buffer[i + 3 + 2 * j] - buffer[i + 1];
                        bx = buffer[i + 4 + 2 * j] - buffer[i + 0]; 
                        by = buffer[i + 5 + 2 * j] - buffer[i + 1];
                        area = ax * by - bx * ay;
                        acc += (area < 0) ? -area : area; // -area = backfacing polygon
                        i += n * 2;
                    }
                }
                else if(buffer[i] == Gl.GL_LINE_RESET_TOKEN) {
                    i++;
                    // Assume left-to-right horizontal lines
                    acc += buffer[i + 2] - buffer[i + 0];
                    i += 4;
                }
                else if(buffer[i] == Gl.GL_BITMAP_TOKEN) {
                    i++;
                    // Skip past bitmap tokens
                    i += 2;
                }
                else {
                    Console.WriteLine("Unknown token found 0x{0:x4} at {1}!", buffer[i], i);
                    i++;
                }
            }
            buffer = null;
    
            acc /= 2.0f;

            return (int) acc;
        }
        #endregion int Pixels()

        #region byte[] PpmRead(string fileName, ref int width, ref int height)
        /// <summary>
        ///     Reads a PPM raw (type P6) file.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         The PPM file has a header that should look something like:
        ///         P6
        ///         # comment
        ///         width height max_value
        ///         rgbrgbrgb...
        ///     </para>
        ///     <para>
        ///         "P6" is the magic cookie which identifies the file type and should be the
        ///         only characters on the first line followed by a carriage return.  Any line
        ///         starting with a # mark will be treated as a comment and discarded.  After the
        ///         magic cookie, three integer values are expected: width, height of the image
        ///         and the maximum value for a pixel (max_value must be &lt; 256 for PPM raw
        ///         files).  The data section consists of width*height rgb triplets (one byte
        ///         each) in binary format (i.e., such as that written with fwrite() or
        ///         equivalent).
        ///     </para>
        ///     <para>
        ///         The rgb data is returned as an array of unsigned chars (packed rgb).  The
        ///         malloc()'d memory should be free()'d by the caller.  If an error occurs, an
        ///         error message is sent to stderr and NULL is returned.
        ///     </para>
        /// </remarks>
        private static byte[] PpmRead(string fileName, ref int width, ref int height) {
            FileStream file;
            BinaryReader reader;
            byte[] image;
            byte[] head = new byte[70];
            int maxValue = 0;
            string header = "";
            int dataPosition = 0;

            try {
                if(File.Exists(Path.Combine("Data", fileName))) {
                    fileName = Path.Combine("Data", fileName);
                }
                else {
                    fileName = Path.Combine(Path.Combine(Path.Combine("..", ".."), "Data"), fileName);
                }

                file = File.Open(fileName, FileMode.Open, FileAccess.Read);
                reader = new BinaryReader(file);

                // Grab first two chars of the file and make sure that it has the correct
                // magic cookie for a raw PPM file.
                head = reader.ReadBytes(70);
                if(head[0] != (byte) 'P' && head[1] != (byte) '6') {
                    Console.WriteLine(fileName + ": Not a raw PPM file!");
                    return null;
                }

                // Grab the three elements in the header (width, height, maxval).
                header = Encoding.ASCII.GetString(head);

                // Strip magic
                Regex magic = new Regex(@"P6\s*", RegexOptions.Compiled | RegexOptions.Multiline);
                Match magicMatch = magic.Match(header);
                if(magicMatch.Success) {
                    header = header.Remove(magicMatch.Groups[0].Index, magicMatch.Groups[0].Length);
                    dataPosition += magicMatch.Groups[0].Length;
                }

                Regex comment = new Regex(@"^#.*\s*", RegexOptions.Compiled | RegexOptions.Multiline);
                Regex element = new Regex(@"\s*\d*\s*", RegexOptions.Compiled | RegexOptions.Multiline);

                // Gather elements
                int i = 0;
                bool endComments = false;
                while(i < 3) {
                    // Strip comments
                    if(!endComments) {
                        Match commentMatch = comment.Match(header);
                        if(commentMatch.Success) {
                            header = header.Remove(commentMatch.Groups[0].Index, commentMatch.Groups[0].Length);
                            dataPosition += commentMatch.Groups[0].Length;
                            commentMatch = comment.Match(header);
                            commentMatch.NextMatch();
                        }
                    }
                    Match elementMatch = element.Match(header);
                    if(elementMatch.Success) {
                        if(i == 0) {
                            width = Int32.Parse(elementMatch.Groups[0].ToString().Trim());
                        }
                        if(i == 1) {
                            height = Int32.Parse(elementMatch.Groups[0].ToString().Trim());
                        }
                        if(i == 2) {
                            maxValue = Int32.Parse(elementMatch.Groups[0].ToString().Trim());
                        }
                        header = header.Remove(elementMatch.Groups[0].Index, elementMatch.Groups[0].Length);
                        dataPosition += elementMatch.Groups[0].Length;
                        elementMatch = element.Match(header);
                        elementMatch.NextMatch();
                        endComments = true;
                        i++;
                    }
                }
                reader.Close();
                file.Close();
                file = File.Open(fileName, FileMode.Open, FileAccess.Read);
                reader = new BinaryReader(file);
                // Grab all the image data in one fell swoop
                image = new byte[width * height * 3];
                reader.ReadBytes(dataPosition);
                image = reader.ReadBytes(width * height * 3);

                reader.Close();
                file.Close();

                return image;
            }
            catch(Exception e) {
                Console.WriteLine("Error loading PPM file: " + fileName);
                Console.WriteLine(e.ToString());
            }

            return null;
        }
        #endregion byte[] PpmRead(string fileName, ref int width, ref int height)

        #region Sphere(int texture)
        private static void Sphere(int texture) {
            if(texturing) {
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture);
                Glut.glutSolidSphere(RI, lod, lod);
            }
            else {
                Glut.glutSolidSphere(RI, lod, lod);
            }
        }
        #endregion Sphere(int texture)

        // --- Callbacks ---
        #region Display()
        private static void Display() {
            if(performanceTiming) {
                start = Glut.glutGet(Glut.GLUT_ELAPSED_TIME);
            }

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            if(drawBackground || drawStars || performanceTiming) {
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glPushMatrix();
                    Gl.glLoadIdentity();
                    Gl.glOrtho(0, width, 0, height, -1, 1);
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glPushMatrix();
                        Gl.glLoadIdentity();
                        Gl.glDepthMask(Gl.GL_FALSE);
                        Gl.glDisable(Gl.GL_DEPTH_TEST);
                        Gl.glDisable(Gl.GL_LIGHTING);

                        if(drawBackground) {
                            Gl.glEnable(Gl.GL_TEXTURE_2D);
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, backgroundTexture);
                            Gl.glColor3ub(255, 255, 255);
                            Gl.glBegin(Gl.GL_QUADS);
                                Gl.glTexCoord2i(0, 0);
                                Gl.glVertex2i(0, 0);
                                Gl.glTexCoord2i(1, 0);
                                Gl.glVertex2i(width, 0);
                                Gl.glTexCoord2i(1, 1);
                                Gl.glVertex2i(width, height);
                                Gl.glTexCoord2i(0, 1);
                                Gl.glVertex2i(0, height);
                            Gl.glEnd();
                            Gl.glDisable(Gl.GL_TEXTURE_2D);
                        }

                        if(drawStars) {
                            Gl.glEnable(Gl.GL_BLEND);
                            Gl.glBegin(Gl.GL_LINES);
                                for(i = 0; i < NUMBERSTARS; i++) {
                                    stars[i].X += stars[i].VX;
                                    if(stars[i].X < width) {
                                        Gl.glColor4ub(0, 0, 0, 0);
                                        Gl.glVertex2i((int) (stars[i].X - stars[i].VX * 3), (int) stars[i].Y);
                                        Gl.glColor4ub(255, 255, 255, 255);
                                        Gl.glVertex2i((int) stars[i].X, (int) stars[i].Y);
                                    }
                                    else {
                                        stars[i].X = 0;
                                    }
                                }
                            Gl.glEnd();
                            Gl.glDisable(Gl.GL_BLEND);
                        }

                        if(performanceTiming) {
                            float fps = (1.0f / ((float) (end - last) / 1000.0f));
                            string s = fps.ToString("F1") + " FPS";

                            Gl.glColor3ub(255, 255, 255);
                            Gl.glRasterPos2i(5, 5);
                            foreach(char c in s) {
                                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_HELVETICA_18, c);
                            }
                            last = start;
                        }

                        Gl.glEnable(Gl.GL_LIGHTING);
                        Gl.glEnable(Gl.GL_DEPTH_TEST);
                        Gl.glDepthMask(Gl.GL_TRUE);
                        Gl.glMatrixMode(Gl.GL_PROJECTION);
                    Gl.glPopMatrix();
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glPopMatrix();
            }

            Gl.glPushMatrix();
                if(texturing) {
                    Gl.glTexGeni(Gl.GL_S, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_SPHERE_MAP);
                    Gl.glTexGeni(Gl.GL_T, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_SPHERE_MAP);
                    Gl.glEnable(Gl.GL_TEXTURE_GEN_S);
                    Gl.glEnable(Gl.GL_TEXTURE_GEN_T);
                    Gl.glEnable(Gl.GL_TEXTURE_2D);
                }

                Gl.glRotatef(spinY, 0, 1, 0);
                Gl.glColor3ub(196, 196, 196);
                Glut.glutSolidTorus(RI, RO, lod, lod);

                step = (int) (360.0 / numberSpheres);
                for(i = 0; i < numberSpheres; i++) {
                    Gl.glPushMatrix();
                        Gl.glRotatef(step * i + spinZ, 0, 0, 1);
                        Gl.glTranslatef(0, RO, 0);
                        Gl.glRotatef(step * i + spinX, 1, 0, 0);
                        Gl.glTranslatef(0, RI + RI, 0);
                        Color((byte) i);
                        Sphere(i % numberTextures + 1);
                    Gl.glPopMatrix();
                }

                if(texturing) {
                    Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
                    Gl.glDisable(Gl.GL_TEXTURE_GEN_T);
                    Gl.glDisable(Gl.GL_TEXTURE_2D);
                }
            Gl.glPopMatrix();

            Glut.glutSwapBuffers();

            if(performanceTiming) {
                end = Glut.glutGet(Glut.GLUT_ELAPSED_TIME);
            }
        }
        #endregion Display()

        #region Idle()
        private static void Idle() {
            if(!frozen) {
                spinY += 0.5f;
                if(spinY > 360) {
                    spinY -= 360;
                }

                spinX += 10;
                if(spinX > 360) {
                    spinX -= 360;
                }

                spinZ += 1;
                if(spinZ > 360) {
                    spinZ -= 360;
                }
            }

            Glut.glutPostRedisplay();
        }
        #endregion Idle()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case 27:
                    Environment.Exit(0);
                    break;
                case (byte) 'p':
                case (byte) 'P':
                    performanceTiming = !performanceTiming;
                    break;
                case (byte) 't':
                case (byte) 'T':
                    texturing = !texturing;
                    break;
                case (byte) 'm':
                case (byte) 'M':
                    if(mode == Gl.GL_REPLACE) {
                        mode = Gl.GL_MODULATE;
                    }
                    else {
                        mode = Gl.GL_REPLACE;
                    }
                    Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, mode);
                    Console.WriteLine("{0} mode.", mode == Gl.GL_MODULATE ? "GL_MODULATE" : "GL_REPLACE");
                    break;
                case (byte) 'f':
                case (byte) 'F':
                    if(filter == Gl.GL_NEAREST) {
                        filter = Gl.GL_LINEAR;
                    }
                    else {
                        filter = Gl.GL_NEAREST;
                    }
                    for(int i = 0; i < numberTextures; i++) {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, i + 1);
                        Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, filter);
                        Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, filter);
                    }
                    Console.WriteLine("{0} filtering.", filter == Gl.GL_LINEAR ? "GL_LINEAR" : "GL_NEAREST");
                    break;
                case (byte) '>':
                case (byte) '.':
                    numberTextures++;
                    if(numberTextures > 4) {
                        numberTextures = 4;
                    }
                    break;
                case (byte) '<':
                case (byte) ',':
                    numberTextures--;
                    if(numberTextures < 1) {
                        numberTextures = 1;
                    }
                    break;
                case (byte) 'b':
                case (byte) 'B':
                    drawBackground = !drawBackground;
                    break;
                case (byte) '*':
                case (byte) '8':
                    drawStars = !drawStars;
                    break;
                case (byte) 'r':
                case (byte) 'R':
                    Console.WriteLine("{0:F1} triangles, {1:F1} pixels.", lod * lod * 2 + (lod * 2 + lod * (lod - 2) * 2) * numberSpheres, Pixels());
                    break;
                case (byte) 'c':
                case (byte) 'C':
                    if(Gl.glIsEnabled(Gl.GL_CULL_FACE) == Gl.GL_TRUE) {
                        Gl.glDisable(Gl.GL_CULL_FACE);
                    }
                    else {
                        Gl.glEnable(Gl.GL_CULL_FACE);
                    }
                    Console.WriteLine("Culling {0}.", (Gl.glIsEnabled(Gl.GL_CULL_FACE) == Gl.GL_TRUE) ? "enabled" : "disabled");
                    break;
                case (byte) ' ':
                    frozen = !frozen;
                    break;
                case (byte) '1':
                case (byte) '!':
                    backgroundTexture = 1;
                    break;
                case (byte) '2':
                case (byte) '@':
                    backgroundTexture = 2;
                    break;
                case (byte) '3':
                case (byte) '#':
                    backgroundTexture = 3;
                    break;
                case (byte) '4':
                case (byte) '$':
                    backgroundTexture = 4;
                    break;
                default:
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Menu(int value)
        private static void Menu(int value) {
            Keyboard((byte) value, 0, 0);
        }
        #endregion Menu(int value)

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            if(h <= 0) {
                h = 1;
            }
            if(w <= 0) {
                w = 1;
            }
            width = w;
            height = h;
            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(120, (float) width / (float) height, 0.1, 1000.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0, 0, 20, 0, 0, 0, 0, 1, 0);

            for(int i = 0; i < NUMBERSTARS; i++) {
                stars[i].X = random.Next(RANDOMMAX) % width;
                stars[i].Y = random.Next(RANDOMMAX) % height;
                stars[i].VX = random.Next(RANDOMMAX) / (float) RANDOMMAX * 5 + 2;
                stars[i].VY = 0;
            }
        }
        #endregion Reshape(int w, int h)

        #region Special(int value, int x, int y)
        private static void Special(int value, int x, int y) {
            switch(value) {
                case Glut.GLUT_KEY_UP:
                    lod++;
                    if(lod > 32) {
                        lod = 32;
                    }
                    break;
                case Glut.GLUT_KEY_DOWN:
                    lod--;
                    if(lod < 3) {
                        lod = 3;
                    }
                    break;
                case Glut.GLUT_KEY_RIGHT:
                    numberSpheres++;
                    if(numberSpheres > COLORS) {
                        numberSpheres = COLORS;
                    }
                    break;
                case Glut.GLUT_KEY_LEFT:
                    numberSpheres--;
                    if(numberSpheres < 1) {
                        numberSpheres = 1;
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion Special(int value, int x, int y)
    }
}
