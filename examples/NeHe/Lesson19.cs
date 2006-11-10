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
 *  This Code Was Created By Jeff Molofee 2000
 *  If You've Found This Code Useful, Please Let Me Know.
 *  Visit My Site At nehe.gamedev.net
*/
/*
==========================================================================
            OpenGL Lesson 19:  Triangle Strip & Particle Engine
==========================================================================

  Authors Name: Jeff Molofee ( NeHe )

  Disclaimer:

  This program may crash your system or run poorly depending on your
  hardware.  The program and code contained in this archive was scanned
  for virii and has passed all test before it was put online.  If you
  use this code in project of your own, send a shout out to the author!

==========================================================================
                        NeHe Productions 1997-2004
==========================================================================
*/
#endregion Original Credits / License

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace NeHe {
    #region Class Documentation
    /// <summary>
    ///     Lesson 19:  Triangle Strip & Particle Engine.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Jeff Molofee (NeHe)
    ///         http://nehe.gamedev.net/data/lessons/lesson.asp?lesson=19
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Lesson19 : Form {
        // --- Fields ---
        #region Private Static Fields
        private static IntPtr hDC;                                              // Private GDI Device Context
        private static IntPtr hRC;                                              // Permanent Rendering Context
        private static Form form;                                               // Our Current Windows Form
        private static bool[] keys = new bool[256];                             // Array Used For The Keyboard Routine
        private static bool active = true;                                      // Window Active Flag, Set To True By Default
        private static bool fullscreen = true;                                  // Fullscreen Flag, Set To Fullscreen Mode By Default
        private static bool done = false;                                       // Bool Variable To Exit Main Loop

        private const int MAX_PARTICLES = 1000;                                 // Number Of Particles To Create
        private static Random rand = new Random();                              // Random Number Generator
        private static bool rainbow = true;                                     // Rainbow Mode?
        private static bool sp;                                                 // Spacebar Pressed?
        private static bool rp;                                                 // Enter Key Pressed?
        private static float slowdown = 2;                                      // Slow Down Particles
        private static float xspeed;                                            // Base X Speed (To Allow Keyboard Direction Of Tail)
        private static float yspeed;                                            // Base Y Speed (To Allow Keyboard Direction Of Tail)
        private static float zoom = -40;                                        // Used To Zoom Out
        private static int loop;                                                // Misc Loop Variable
        private static int col;                                                 // Current Color Selection
        private static int delay;                                               // Rainbow Effect Delay
        private static int[] texture = new int[1];                              // Storage For Our Particle Texture
        private struct particle {                                               // Create A Structure For Particle
            public bool active;                                                 // Active (Yes/No)
            public float life;                                                  // Particle Life
            public float fade;                                                  // Fade Speed
            public float r;                                                     // Red Value
            public float g;                                                     // Green Value
            public float b;                                                     // Blue Value
            public float x;                                                     // X Position
            public float y;                                                     // Y Position
            public float z;                                                     // Z Position
            public float xi;                                                    // X Direction
            public float yi;                                                    // Y Direction
            public float zi;                                                    // Z Direction
            public float xg;                                                    // X Gravity
            public float yg;                                                    // Y Gravity
            public float zg;                                                    // Z Gravity
        }
        private static particle[] particles = new particle[MAX_PARTICLES];      // Particle Array (Room For Particle Info)

        private static float[][] colors = new float[12][] {                     // Rainbow Of Colors
            new float[] {1, 0.5f, 0.5f},
            new float[] {1, 0.75f, 0.5f},
            new float[] {1, 1, 0.5f},
            new float[] {0.75f, 1, 0.5f},
            new float[] {0.5f, 1, 0.5f},
            new float[] {0.5f, 1, 0.75f},
            new float[] {0.5f, 1, 1},
            new float[] {0.5f, 0.75f, 1},
            new float[] {0.5f, 0.5f, 1},
            new float[] {0.75f, 0.5f, 1},
            new float[] {1, 0.5f, 1},
            new float[] {1, 0.5f, 0.75f}
        };
        #endregion Private Static Fields

        // --- Constructors & Destructors ---
        #region Lesson19
        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public Lesson19() {
            this.CreateParams.ClassStyle = this.CreateParams.ClassStyle |       // Redraw On Size, And Own DC For Window.
                User.CS_HREDRAW | User.CS_VREDRAW | User.CS_OWNDC;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);            // No Need To Erase Form Background
            this.SetStyle(ControlStyles.DoubleBuffer, true);                    // Buffer Control
            this.SetStyle(ControlStyles.Opaque, true);                          // No Need To Draw Form Background
            this.SetStyle(ControlStyles.ResizeRedraw, true);                    // Redraw On Resize
            this.SetStyle(ControlStyles.UserPaint, true);                       // We'll Handle Painting Ourselves

            this.Activated += new EventHandler(this.Form_Activated);            // On Activate Event Call Form_Activated
            this.Closing += new CancelEventHandler(this.Form_Closing);          // On Closing Event Call Form_Closing
            this.Deactivate += new EventHandler(this.Form_Deactivate);          // On Deactivate Event Call Form_Deactivate
            this.KeyDown += new KeyEventHandler(this.Form_KeyDown);             // On KeyDown Event Call Form_KeyDown
            this.KeyUp += new KeyEventHandler(this.Form_KeyUp);                 // On KeyUp Event Call Form_KeyUp
            this.Resize += new EventHandler(this.Form_Resize);                  // On Resize Event Call Form_Resize
        }
        #endregion Lesson19

        // --- Entry Point ---
        #region Run()
        /// <summary>
        ///     The application's entry point.
        /// </summary>
        /// <param name="commandLineArguments">
        ///     Any supplied command line arguments.
        /// </param>
        [STAThread]
        public static void Run() {
            // Ask The User Which Screen Mode They Prefer
            if(MessageBox.Show("Would You Like To Run In Fullscreen Mode?", "Start FullScreen?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                fullscreen = false;                                             // Windowed Mode
            }

            // Create Our OpenGL Window
            if(!CreateGLWindow("NeHe's Particle Tutorial", 640, 480, 16, fullscreen)) {
                return;                                                         // Quit If Window Was Not Created
            }

            if(fullscreen) {                                                    // Are We In Fullscreen Mode
                slowdown = 1;                                                   // If So, Speed Up The Particles (3dfx Issue)
            }

            while(!done) {                                                      // Loop That Runs While done = false
                Application.DoEvents();                                         // Process Events

                // Draw The Scene.  Watch For ESC Key And Quit Messages From DrawGLScene()
                if((active && (form != null) && !DrawGLScene()) || keys[(int) Keys.Escape]) {   //  Active?  Was There A Quit Received?
                    done = true;                                            // ESC Or DrawGLScene Signalled A Quit
                }
                else {                                                      // Not Time To Quit, Update Screen
                    Gdi.SwapBuffers(hDC);                                   // Swap Buffers (Double Buffering)

                    if(keys[(int) Keys.Add] && ( slowdown > 1)) {
                        slowdown -= 0.01f;                                  // Speed Up Particles
                    }
                    if(keys[(int) Keys.Subtract] && (slowdown < 4)) {
                        slowdown += 0.01f;                                  // Slow Down Particles
                    }
                    if(keys[(int) Keys.PageUp]) {
                        zoom += 0.1f;                                       // Zoom In
                    }
                    if(keys[(int) Keys.PageDown]) {
                        zoom -= 0.1f;                                       // Zoom Out
                    }
                    if(keys[(int) Keys.Enter] && !rp) {                     // Return Key Pressed
                        rp = true;                                          // Set Flag Telling Us It's Pressed
                        rainbow = !rainbow;                                 // Toggle Rainbow Mode On / Off
                    }
                    if(!keys[(int) Keys.Enter]) {
                        rp = false;                                         // If Return Is Released Clear Flag
                    }
                    // Space Or Rainbow Mode
                    if((keys[(int) Keys.Space] && !sp) || (rainbow && (delay > 25))) {
                        if(keys[(int) Keys.Space]) {
                            rainbow = false;                                // If Spacebar Is Pressed Disable Rainbow Mode
                        }
                        sp = true;                                          // Set Flag Telling Us Space Is Pressed
                        delay = 0;                                          // Reset The Rainbow Color Cycling Delay
                        col++;                                              // Change The Particle Color
                        if(col > 11) {
                            col = 0;                                        // If Color Is To High Reset It
                        }
                    }
                    if(!keys[(int) Keys.Space]) {
                        sp = false;                                         // If Spacebar Is Released Clear Flag
                    }
                    // If Up Arrow And Y Speed Is Less Than 200 Increase Upward Speed
                    if(keys[(int) Keys.Up] && (yspeed < 200)) {
                        yspeed += 1;
                    }
                    // If Down Arrow And Y Speed Is Greater Than -200 Increase Downward Speed
                    if(keys[(int) Keys.Down] && (yspeed > -200)) {
                        yspeed -= 1;
                    }
                    // If Right Arrow And X Speed Is Less Than 200 Increase Speed To The Right
                    if(keys[(int) Keys.Right] && (xspeed < 200)) {
                        xspeed += 1;
                    }
                    // If Left Arrow And X Speed Is Greater Than -200 Increase Speed To The Left
                    if(keys[(int) Keys.Left] && (xspeed > -200)) {
                        xspeed -= 1;
                    }
                    delay++;                                                // Increase Rainbow Mode Color Cycling Delay Counter

                    if(keys[(int) Keys.F1]) {                               // Is F1 Being Pressed?
                        keys[(int) Keys.F1] = false;                        // If So Make Key false
                        KillGLWindow();                                     // Kill Our Current Window
                        fullscreen = !fullscreen;                           // Toggle Fullscreen / Windowed Mode
                        // Recreate Our OpenGL Window
                        if(!CreateGLWindow("NeHe's Particle Tutorial", 640, 480, 16, fullscreen)) {
                            return;                                         // Quit If Window Was Not Created
                        }
                        done = false;                                       // We're Not Done Yet
                    }
                }
            }

            // Shutdown
            KillGLWindow();                                                     // Kill The Window
            return;                                                             // Exit The Program
        }
        #endregion Run()

        // --- Private Static Methods ---
        #region bool CreateGLWindow(string title, int width, int height, int bits, bool fullscreenflag)
        /// <summary>
        ///     Creates our OpenGL Window.
        /// </summary>
        /// <param name="title">
        ///     The title to appear at the top of the window.
        /// </param>
        /// <param name="width">
        ///     The width of the GL window or fullscreen mode.
        /// </param>
        /// <param name="height">
        ///     The height of the GL window or fullscreen mode.
        /// </param>
        /// <param name="bits">
        ///     The number of bits to use for color (8/16/24/32).
        /// </param>
        /// <param name="fullscreenflag">
        ///     Use fullscreen mode (<c>true</c>) or windowed mode (<c>false</c>).
        /// </param>
        /// <returns>
        ///     <c>true</c> on successful window creation, otherwise <c>false</c>.
        /// </returns>
        private static bool CreateGLWindow(string title, int width, int height, int bits, bool fullscreenflag) {
            int pixelFormat;                                                    // Holds The Results After Searching For A Match
            fullscreen = fullscreenflag;                                        // Set The Global Fullscreen Flag
            form = null;                                                        // Null The Form

            GC.Collect();                                                       // Request A Collection
            // This Forces A Swap
            Kernel.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);

            if(fullscreen) {                                                    // Attempt Fullscreen Mode?
                Gdi.DEVMODE dmScreenSettings = new Gdi.DEVMODE();               // Device Mode
                // Size Of The Devmode Structure
                dmScreenSettings.dmSize = (short) Marshal.SizeOf(dmScreenSettings);
                dmScreenSettings.dmPelsWidth = width;                           // Selected Screen Width
                dmScreenSettings.dmPelsHeight = height;                         // Selected Screen Height
                dmScreenSettings.dmBitsPerPel = bits;                           // Selected Bits Per Pixel
                dmScreenSettings.dmFields = Gdi.DM_BITSPERPEL | Gdi.DM_PELSWIDTH | Gdi.DM_PELSHEIGHT;

                // Try To Set Selected Mode And Get Results.  NOTE: CDS_FULLSCREEN Gets Rid Of Start Bar.
                if(User.ChangeDisplaySettings(ref dmScreenSettings, User.CDS_FULLSCREEN) != User.DISP_CHANGE_SUCCESSFUL) {
                    // If The Mode Fails, Offer Two Options.  Quit Or Use Windowed Mode.
                    if(MessageBox.Show("The Requested Fullscreen Mode Is Not Supported By\nYour Video Card.  Use Windowed Mode Instead?", "NeHe GL",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                        fullscreen = false;                                     // Windowed Mode Selected.  Fullscreen = false
                    }
                    else {
                        // Pop up A Message Box Lessing User Know The Program Is Closing.
                        MessageBox.Show("Program Will Now Close.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;                                           // Return false
                    }
                }
            }

            form = new Lesson19();                                              // Create The Window

            if(fullscreen) {                                                    // Are We Still In Fullscreen Mode?
                form.FormBorderStyle = FormBorderStyle.None;                    // No Border
                Cursor.Hide();                                                  // Hide Mouse Pointer
            }
            else {                                                              // If Windowed
                form.FormBorderStyle = FormBorderStyle.Sizable;                 // Sizable
                Cursor.Show();                                                  // Show Mouse Pointer
            }

            form.Width = width;                                                 // Set Window Width
            form.Height = height;                                               // Set Window Height
            form.Text = title;                                                  // Set Window Title

            Gdi.PIXELFORMATDESCRIPTOR pfd = new Gdi.PIXELFORMATDESCRIPTOR();    // pfd Tells Windows How We Want Things To Be
            pfd.nSize = (short) Marshal.SizeOf(pfd);                            // Size Of This Pixel Format Descriptor
            pfd.nVersion = 1;                                                   // Version Number
            pfd.dwFlags = Gdi.PFD_DRAW_TO_WINDOW |                              // Format Must Support Window
                Gdi.PFD_SUPPORT_OPENGL |                                        // Format Must Support OpenGL
                Gdi.PFD_DOUBLEBUFFER;                                           // Format Must Support Double Buffering
            pfd.iPixelType = (byte) Gdi.PFD_TYPE_RGBA;                          // Request An RGBA Format
            pfd.cColorBits = (byte) bits;                                       // Select Our Color Depth
            pfd.cRedBits = 0;                                                   // Color Bits Ignored
            pfd.cRedShift = 0;
            pfd.cGreenBits = 0;
            pfd.cGreenShift = 0;
            pfd.cBlueBits = 0;
            pfd.cBlueShift = 0;
            pfd.cAlphaBits = 0;                                                 // No Alpha Buffer
            pfd.cAlphaShift = 0;                                                // Shift Bit Ignored
            pfd.cAccumBits = 0;                                                 // No Accumulation Buffer
            pfd.cAccumRedBits = 0;                                              // Accumulation Bits Ignored
            pfd.cAccumGreenBits = 0;
            pfd.cAccumBlueBits = 0;
            pfd.cAccumAlphaBits = 0;
            pfd.cDepthBits = 16;                                                // 16Bit Z-Buffer (Depth Buffer)
            pfd.cStencilBits = 0;                                               // No Stencil Buffer
            pfd.cAuxBuffers = 0;                                                // No Auxiliary Buffer
            pfd.iLayerType = (byte) Gdi.PFD_MAIN_PLANE;                         // Main Drawing Layer
            pfd.bReserved = 0;                                                  // Reserved
            pfd.dwLayerMask = 0;                                                // Layer Masks Ignored
            pfd.dwVisibleMask = 0;
            pfd.dwDamageMask = 0;

            hDC = User.GetDC(form.Handle);                                      // Attempt To Get A Device Context
            if(hDC == IntPtr.Zero) {                                            // Did We Get A Device Context?
                KillGLWindow();                                                 // Reset The Display
                MessageBox.Show("Can't Create A GL Device Context.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            pixelFormat = Gdi.ChoosePixelFormat(hDC, ref pfd);                  // Attempt To Find An Appropriate Pixel Format
            if(pixelFormat == 0) {                                              // Did Windows Find A Matching Pixel Format?
                KillGLWindow();                                                 // Reset The Display
                MessageBox.Show("Can't Find A Suitable PixelFormat.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(!Gdi.SetPixelFormat(hDC, pixelFormat, ref pfd)) {                // Are We Able To Set The Pixel Format?
                KillGLWindow();                                                 // Reset The Display
                MessageBox.Show("Can't Set The PixelFormat.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            hRC = Wgl.wglCreateContext(hDC);                                    // Attempt To Get The Rendering Context
            if(hRC == IntPtr.Zero) {                                            // Are We Able To Get A Rendering Context?
                KillGLWindow();                                                 // Reset The Display
                MessageBox.Show("Can't Create A GL Rendering Context.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(!Wgl.wglMakeCurrent(hDC, hRC)) {                                 // Try To Activate The Rendering Context
                KillGLWindow();                                                 // Reset The Display
                MessageBox.Show("Can't Activate The GL Rendering Context.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            form.Show();                                                        // Show The Window
            form.TopMost = true;                                                // Topmost Window
            form.Focus();                                                       // Focus The Window

            if(fullscreen) {                                                    // This Shouldn't Be Necessary, But Is
                Cursor.Hide();
            }
            ReSizeGLScene(width, height);                                       // Set Up Our Perspective GL Screen

            if(!InitGL()) {                                                     // Initialize Our Newly Created GL Window
                KillGLWindow();                                                 // Reset The Display
                MessageBox.Show("Initialization Failed.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;                                                        // Success
        }
        #endregion bool CreateGLWindow(string title, int width, int height, int bits, bool fullscreenflag)

        #region bool DrawGLScene()
        /// <summary>
        ///     Here's where we do all the drawing.
        /// </summary>
        /// <returns>
        ///     <c>true</c> on successful drawing, otherwise <c>false</c>.
        /// </returns>
        private static bool DrawGLScene() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);        // Clear Screen And Depth Buffer
            Gl.glLoadIdentity();                                                // Reset The ModelView Matrix

            for(loop = 0; loop < MAX_PARTICLES; loop++) {                       // Loop Through All The Particles
                if(particles[loop].active) {                                    // If The Particle Is Active
                    float x = particles[loop].x;                                // Grab Our Particle X Position
                    float y = particles[loop].y;                                // Grab Our Particle Y Position
                    float z = particles[loop].z + zoom;                         // Particle Z Pos + Zoom

                    // Draw The Particle Using Our RGB Values, Fade The Particle Based On It's Life
                    Gl.glColor4f(particles[loop].r, particles[loop].g, particles[loop].b, particles[loop].life);

                    Gl.glBegin(Gl.GL_TRIANGLE_STRIP);                           // Build Quad From A Triangle Strip
                        // Top Right
                        Gl.glTexCoord2d(1, 1); Gl.glVertex3f(x + 0.5f, y + 0.5f, z);
                        // Top Left
                        Gl.glTexCoord2d(0, 1); Gl.glVertex3f(x - 0.5f, y + 0.5f, z);
                        // Bottom Right
                        Gl.glTexCoord2d(1, 0); Gl.glVertex3f(x + 0.5f, y - 0.5f, z);
                        // Bottom Left
                        Gl.glTexCoord2d(0, 0); Gl.glVertex3f(x - 0.5f, y - 0.5f, z);
                    Gl.glEnd();                                                 // Done Building Triangle Strip

                    particles[loop].x += particles[loop].xi / (slowdown * 1000);// Move On The X Axis By X Speed
                    particles[loop].y += particles[loop].yi / (slowdown * 1000);// Move On The Y Axis By Y Speed
                    particles[loop].z += particles[loop].zi / (slowdown * 1000);// Move On The Z Axis By Z Speed
                    particles[loop].xi += particles[loop].xg;                   // Take Pull On X Axis Into Account
                    particles[loop].yi += particles[loop].yg;                   // Take Pull On Y Axis Into Account
                    particles[loop].zi += particles[loop].zg;                   // Take Pull On Z Axis Into Account
                    particles[loop].life -= particles[loop].fade;               // Reduce Particles Life By 'Fade'

                    if(particles[loop].life < 0) {                              // If Particle Is Burned Out
                        particles[loop].life = 1;                               // Give It New Life
                        // Random Fade Value
                        particles[loop].fade = ((float) (rand.Next() % 100)) / 1000.0f + 0.003f;
                        particles[loop].x = 0;                                  // Center On X Axis
                        particles[loop].y = 0;                                  // Center On Y Axis
                        particles[loop].z = 0;                                  // Center On Z Axis
                        // X Axis Speed And Direction
                        particles[loop].xi = xspeed + ((float) ((rand.Next() % 60)) - 32.0f);
                        // Y Axis Speed And Direction
                        particles[loop].yi = yspeed + ((float) ((rand.Next() % 60)) - 30.0f);
                        // Z Axis Speed And Direction
                        particles[loop].zi = ((float) ((rand.Next() % 60)) - 30.0f);
                        particles[loop].r = colors[col][0];                     // Select Red From Color Table
                        particles[loop].g = colors[col][1];                     // Select Green From Color Table
                        particles[loop].b = colors[col][2];                     // Select Blue From Color Table
                    }

                    // If Number Pad 8 And Y Gravity Is Less Than 1.5 Increase Pull Upwards
                    if(keys[(int) Keys.NumPad8] && (particles[loop].yg < 1.5f)) {
                        particles[loop].yg += 0.01f;
                    }

                    // If Number Pad 2 And Y Gravity Is Greater Than -1.5 Increase Pull Downwards
                    if(keys[(int) Keys.NumPad2] && (particles[loop].yg > -1.5f)) {
                        particles[loop].yg -= 0.01f;
                    }

                    // If Number Pad 6 And X Gravity Is Less Than 1.5 Increase Pull Right
                    if(keys[(int) Keys.NumPad6] && (particles[loop].xg < 1.5f)) {
                        particles[loop].xg += 0.01f;
                    }

                    // If Number Pad 4 And X Gravity Is Greater Than -1.5 Increase Pull Left
                    if(keys[(int) Keys.NumPad4] && (particles[loop].xg > -1.5f)) {
                        particles[loop].xg -= 0.01f;
                    }

                    if(keys[(int) Keys.Tab]) {                                  // Tab Key Causes A Burst
                        particles[loop].x = 0;                                  // Center On X Axis
                        particles[loop].y = 0;                                  // Center On Y Axis
                        particles[loop].z = 0;                                  // Center On Z Axis
                        // Random Speed On X Axis
                        particles[loop].xi = ((float) ((rand.Next() % 50) - 26.0f)) * 10.0f;
                        // Random Speed On Y Axis
                        particles[loop].yi = ((float) ((rand.Next() % 50) - 25.0f)) * 10.0f;
                        // Random Speed On Z Axis
                        particles[loop].zi = ((float) ((rand.Next() % 50) - 25.0f)) * 10.0f;
                    }
                }
            }

            return true;                                                        // Keep Going
        }
        #endregion bool DrawGLScene()

        #region bool InitGL()
        /// <summary>
        ///     All setup for OpenGL goes here.
        /// </summary>
        /// <returns>
        ///     <c>true</c> on successful initialization, otherwise <c>false</c>.
        /// </returns>
        private static bool InitGL() {
            if(!LoadGLTextures()) {                                             // Jump To Texture Loading Routine
                return false;                                                   // If Texture Didn't Load Return False
            }

            Gl.glShadeModel(Gl.GL_SMOOTH);                                      // Enable Smooth Shading
            Gl.glClearColor(0, 0, 0, 0);                                        // Black Background
            Gl.glClearDepth(1);                                                 // Depth Buffer Setup
            Gl.glDisable(Gl.GL_DEPTH_TEST);                                     // Disable Depth Testing
            Gl.glEnable(Gl.GL_BLEND);                                           // Enable Blending
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);                         // Type Of Blending To Perform
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);         // Really Nice Perspective Calculations
            Gl.glHint(Gl.GL_POINT_SMOOTH_HINT, Gl.GL_NICEST);                   // Really Nice Point Smoothing
            Gl.glEnable(Gl.GL_TEXTURE_2D);                                      // Enable Texture Mapping
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[0]);                     // Select Our Texture
            for(loop = 0; loop < MAX_PARTICLES; loop++) {                       // Initials All The Textures
                particles[loop].active = true;                                  // Make All The Particles Active
                particles[loop].life = 1;                                       // Give All The Particles Full Life
                // Random Fade Speed
                particles[loop].fade = ((float) (rand.Next() % 100)) / 1000.0f + 0.003f;
                particles[loop].r = colors[loop * (12 / MAX_PARTICLES)][0];     // Select Red Rainbow Color
                particles[loop].g = colors[loop * (12 / MAX_PARTICLES)][1];     // Select Red Rainbow Color
                particles[loop].b = colors[loop * (12 / MAX_PARTICLES)][2];     // Select Red Rainbow Color
                // Random Speed On X Axis
                particles[loop].xi = ((float) ((rand.Next() % 50) - 26.0f)) * 10.0f;
                // Random Speed On Y Axis
                particles[loop].yi = ((float) ((rand.Next() % 50) - 25.0f)) * 10.0f;
                // Random Speed On Z Axis
                particles[loop].zi = ((float) ((rand.Next() % 50) - 25.0f)) * 10.0f;
                particles[loop].xg = 0;                                         // Set Horizontal Pull To Zero
                particles[loop].yg = -0.8f;                                     // Set Vertical Pull Downward
                particles[loop].zg = 0;                                         // Set Pull On Z Axis To Zero
            }

            return true;
        }
        #endregion bool InitGL()

        #region KillGLWindow()
        /// <summary>
        ///     Properly kill the window.
        /// </summary>
        private static void KillGLWindow() {
            if(fullscreen) {                                                    // Are We In Fullscreen Mode?
                User.ChangeDisplaySettings(IntPtr.Zero, 0);                     // If So, Switch Back To The Desktop
                Cursor.Show();                                                  // Show Mouse Pointer
            }

            if(hRC != IntPtr.Zero) {                                            // Do We Have A Rendering Context?
                if(!Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero)) {             // Are We Able To Release The DC and RC Contexts?
                    MessageBox.Show("Release Of DC And RC Failed.", "SHUTDOWN ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if(!Wgl.wglDeleteContext(hRC)) {                                // Are We Able To Delete The RC?
                    MessageBox.Show("Release Rendering Context Failed.", "SHUTDOWN ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                hRC = IntPtr.Zero;                                              // Set RC To Null
            }

            if(hDC != IntPtr.Zero) {                                            // Do We Have A Device Context?
                if(form != null && !form.IsDisposed) {                          // Do We Have A Window?
                    if(form.Handle != IntPtr.Zero) {                            // Do We Have A Window Handle?
                        if(!User.ReleaseDC(form.Handle, hDC)) {                 // Are We Able To Release The DC?
                            MessageBox.Show("Release Device Context Failed.", "SHUTDOWN ERROR",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                hDC = IntPtr.Zero;                                              // Set DC To Null
            }

            if(form != null) {                                                  // Do We Have A Windows Form?
                form.Hide();                                                    // Hide The Window
                form.Close();                                                   // Close The Form
                form = null;                                                    // Set form To Null
            }
        }
        #endregion KillGLWindow()

        #region Bitmap LoadBMP(string fileName)
        /// <summary>
        ///     Loads a bitmap image.
        /// </summary>
        /// <param name="fileName">
        ///     The filename to load.
        /// </param>
        /// <returns>
        ///     The bitmap if it exists, otherwise <c>null</c>.
        /// </returns>
        private static Bitmap LoadBMP(string fileName) {
            if(fileName == null || fileName == string.Empty) {                  // Make Sure A Filename Was Given
                return null;                                                    // If Not Return Null
            }

            string fileName1 = string.Format("Data{0}{1}",                      // Look For Data\Filename
                Path.DirectorySeparatorChar, fileName);
            string fileName2 = string.Format("{0}{1}{0}{1}Data{1}{2}",          // Look For ..\..\Data\Filename
                "..", Path.DirectorySeparatorChar, fileName);

            // Make Sure The File Exists In One Of The Usual Directories
            if(!File.Exists(fileName) && !File.Exists(fileName1) && !File.Exists(fileName2)) {
                return null;                                                    // If Not Return Null
            }

            if(File.Exists(fileName)) {                                         // Does The File Exist Here?
                return new Bitmap(fileName);                                    // Load The Bitmap
            }
            else if(File.Exists(fileName1)) {                                   // Does The File Exist Here?
                return new Bitmap(fileName1);                                   // Load The Bitmap
            }
            else if(File.Exists(fileName2)) {                                   // Does The File Exist Here?
                return new Bitmap(fileName2);                                   // Load The Bitmap
            }

            return null;                                                        // If Load Failed Return Null
        }
        #endregion Bitmap LoadBMP(string fileName)

        #region bool LoadGLTextures()
        /// <summary>
        ///     Load bitmaps and convert to textures.
        /// </summary>
        /// <returns>
        ///     <c>true</c> on success, otherwise <c>false</c>.
        /// </returns>
        private static bool LoadGLTextures() {
            bool status = false;                                                // Status Indicator
            Bitmap[] textureImage = new Bitmap[1];                              // Create Storage Space For The Texture

            textureImage[0] = LoadBMP("NeHe.Lesson19.Particle.bmp");            // Load The Bitmap
            // Check For Errors, If Bitmap's Not Found, Quit
            if(textureImage[0] != null) {
                status = true;                                                  // Set The Status To True

                Gl.glGenTextures(1, texture);                                   // Create The Textures

                textureImage[0].RotateFlip(RotateFlipType.RotateNoneFlipY);     // Flip The Bitmap Along The Y-Axis
                // Rectangle For Locking The Bitmap In Memory
                Rectangle rectangle = new Rectangle(0, 0, textureImage[0].Width, textureImage[0].Height);
                // Get The Bitmap's Pixel Data From The Locked Bitmap
                BitmapData bitmapData = textureImage[0].LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                // Create Linear Filtered Texture
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[0]);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
                Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB8, textureImage[0].Width, textureImage[0].Height, 0, Gl.GL_BGR, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);

                if(textureImage[0] != null) {                                   // If Texture Exists
                    textureImage[0].UnlockBits(bitmapData);                     // Unlock The Pixel Data From Memory
                    textureImage[0].Dispose();                                  // Dispose The Bitmap
                }
            }

            return status;                                                      // Return The Status
        }
        #endregion bool LoadGLTextures()

        #region ReSizeGLScene(int width, int height)
        /// <summary>
        ///     Resizes and initializes the GL window.
        /// </summary>
        /// <param name="width">
        ///     The new window width.
        /// </param>
        /// <param name="height">
        ///     The new window height.
        /// </param>
        private static void ReSizeGLScene(int width, int height) {
            if(height == 0) {                                                   // Prevent A Divide By Zero...
                height = 1;                                                     // By Making Height Equal To One
            }

            Gl.glViewport(0, 0, width, height);                                 // Reset The Current Viewport
            Gl.glMatrixMode(Gl.GL_PROJECTION);                                  // Select The Projection Matrix
            Gl.glLoadIdentity();                                                // Reset The Projection Matrix
            Glu.gluPerspective(45, width / (double) height, 0.1, 200);          // Calculate The Aspect Ratio Of The Window
            Gl.glMatrixMode(Gl.GL_MODELVIEW);                                   // Select The Modelview Matrix
            Gl.glLoadIdentity();                                                // Reset The Modelview Matrix
        }
        #endregion ReSizeGLScene(int width, int height)

        // --- Private Instance Event Handlers ---
        #region Form_Activated
        /// <summary>
        ///     Handles the form's activated event.
        /// </summary>
        /// <param name="sender">
        ///     The event sender.
        /// </param>
        /// <param name="e">
        ///     The event arguments.
        /// </param>
        private void Form_Activated(object sender, EventArgs e) {
            active = true;                                                      // Program Is Active
        }
        #endregion Form_Activated

        #region Form_Closing(object sender, CancelEventArgs e)
        /// <summary>
        ///     Handles the form's closing event.
        /// </summary>
        /// <param name="sender">
        ///     The event sender.
        /// </param>
        /// <param name="e">
        ///     The event arguments.
        /// </param>
        private void Form_Closing(object sender, CancelEventArgs e) {
            done = true;                                                        // Send A Quit Message
        }
        #endregion Form_Closing(object sender, CancelEventArgs e)

        #region Form_Deactivate(object sender, EventArgs e)
        /// <summary>
        ///     Handles the form's deactivate event.
        /// </summary>
        /// <param name="sender">
        ///     The event sender.
        /// </param>
        /// <param name="e">
        ///     The event arguments.
        /// </param>
        private void Form_Deactivate(object sender, EventArgs e) {
            active = false;                                                     // Program Is No Longer Active
        }
        #endregion Form_Deactivate(object sender, EventArgs e)

        #region Form_KeyDown(object sender, KeyEventArgs e)
        /// <summary>
        ///     Handles the form's key down event.
        /// </summary>
        /// <param name="sender">
        ///     The event sender.
        /// </param>
        /// <param name="e">
        ///     The event arguments.
        /// </param>
        private void Form_KeyDown(object sender, KeyEventArgs e) {
            keys[e.KeyValue] = true;                                            // Key Has Been Pressed, Mark It As true
        }
        #endregion Form_KeyDown(object sender, KeyEventArgs e)

        #region Form_KeyUp(object sender, KeyEventArgs e)
        /// <summary>
        ///     Handles the form's key down event.
        /// </summary>
        /// <param name="sender">
        ///     The event sender.
        /// </param>
        /// <param name="e">
        ///     The event arguments.
        /// </param>
        private void Form_KeyUp(object sender, KeyEventArgs e) {
            keys[e.KeyValue] = false;                                           // Key Has Been Released, Mark It As false
        }
        #endregion Form_KeyUp(object sender, KeyEventArgs e)

        #region Form_Resize(object sender, EventArgs e)
        /// <summary>
        ///     Handles the form's resize event.
        /// </summary>
        /// <param name="sender">
        ///     The event sender.
        /// </param>
        /// <param name="e">
        ///     The event arguments.
        /// </param>
        private void Form_Resize(object sender, EventArgs e) {
            ReSizeGLScene(form.Width, form.Height);                             // Resize The OpenGL Window
        }
        #endregion Form_Resize(object sender, EventArgs e)
    }
}
