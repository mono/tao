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
 *  This Code Was Created By Lionel Brits & Jeff Molofee 2000
 *  A HUGE Thanks To Fredric Echols For Cleaning Up
 *  And Optimizing The Base Code, Making It More Flexible!
 *  If You've Found This Code Useful, Please Let Me Know.
 *  Visit My Site At nehe.gamedev.net
*/
/*
==========================================================================
         OpenGL Lesson 10:  Loading And Moving Through A 3D World
==========================================================================

  Authors Name: Lionel Brits

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
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace NeHe {
    #region Class Documentation
    /// <summary>
    ///     Lesson 10:  Loading And Moving Through A 3D World.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Lionel Brits & Jeff Molofee (NeHe)
    ///         http://nehe.gamedev.net/data/lessons/lesson.asp?lesson=10
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Lesson10 : Form {
        // --- Fields ---
        #region Private Static Fields
        private static IntPtr hDC;                                              // Private GDI Device Context
        private static IntPtr hRC;                                              // Permanent Rendering Context
        private static Form form;                                               // Our Current Windows Form
        private static bool[] keys = new bool[256];                             // Array Used For The Keyboard Routine
        private static bool active = true;                                      // Window Active Flag, Set To True By Default
        private static bool fullscreen = true;                                  // Fullscreen Flag, Set To Fullscreen Mode By Default
        private static bool done = false;                                       // Bool Variable To Exit Main Loop

        private static bool blend;                                              // Blending ON/OFF
        private static bool bp;                                                 // B Pressed?
        private static bool fp;                                                 // F Pressed?
        private const float piover180 = 0.0174532925f;
        private static float heading;
        private static float xpos;
        private static float zpos;
        private static float yrot;                                              // Y Rotation
        private static float walkbias = 0;
        private static float walkbiasangle = 0;
        private static float lookupdown = 0;
        private static float z = 0;                                             // Depth Into The Screen
        private static int filter;                                              // Which Filter To Use
        private static int[] texture = new int[3];                              // Storage For 3 Textures
        private struct Vertex {
            public float x, y, z;
            public float u, v;
        }
        private struct Triangle {
            public Vertex[] vertex;
        }
        private struct Sector {
            public int numtriangles;
            public Triangle[] triangle;
        };
        private static Sector sector;                                           // Our Model Goes Here:
        #endregion Private Static Fields

        // --- Constructors & Destructors ---
        #region Lesson10
        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public Lesson10() {
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
        #endregion Lesson10

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
            if(!CreateGLWindow("Lionel Brits & NeHe's 3D World Tutorial", 640, 480, 16, fullscreen)) {
                return;                                                         // Quit If Window Was Not Created
            }

            while(!done) {                                                      // Loop That Runs While done = false
                Application.DoEvents();                                         // Process Events

                // Draw The Scene.  Watch For ESC Key And Quit Messages From DrawGLScene()
                if((active && (form != null) && !DrawGLScene()) || keys[(int) Keys.Escape]) {   //  Active?  Was There A Quit Received?
                    done = true;                                            // ESC Or DrawGLScene Signalled A Quit
                }
                else {                                                      // Not Time To Quit, Update Screen
                    Gdi.SwapBuffers(hDC);                                   // Swap Buffers (Double Buffering)

                    if(keys[(int) Keys.B] && !bp) {
                        bp = true;
                        blend = !blend;
                        if(!blend) {
                            Gl.glDisable(Gl.GL_BLEND);
                            Gl.glEnable(Gl.GL_DEPTH_TEST);
                        }
                        else {
                            Gl.glEnable(Gl.GL_BLEND);
                            Gl.glDisable(Gl.GL_DEPTH_TEST);
                        }
                    }
                    if(!keys[(int) Keys.B]) {
                        bp = false;
                    }
                    if(keys[(int) Keys.F] && !fp) {
                        fp = true;
                        filter += 1;
                        if(filter > 2) {
                            filter = 0;
                        }
                    }
                    if(!keys[(int) Keys.F]) {
                        fp = false;
                    }
                    if(keys[(int) Keys.PageUp]) {
                        z -= 0.02f;
                    }
                    if(keys[(int) Keys.PageDown]) {
                        z += 0.02f;
                    }
                    if(keys[(int) Keys.Up]) {
                        xpos -= (float) Math.Sin(heading * piover180) * 0.05f;
                        zpos -= (float) Math.Cos(heading * piover180) * 0.05f;
                        if(walkbiasangle >= 359) {
                            walkbiasangle = 0;
                        }
                        else {
                            walkbiasangle += 10;
                        }
                        walkbias = (float) Math.Sin(walkbiasangle * piover180) / 20;
                    }
                    if(keys[(int) Keys.Down]) {
                        xpos += (float) Math.Sin(heading * piover180) * 0.05f;
                        zpos += (float) Math.Cos(heading * piover180) * 0.05f;
                        if(walkbiasangle <= 1) {
                            walkbiasangle = 359;
                        }
                        else {
                            walkbiasangle -= 10;
                        }
                        walkbias = (float) Math.Sin(walkbiasangle * piover180) / 20;
                    }
                    if(keys[(int) Keys.Right]) {
                        heading -= 1;
                        yrot = heading;
                    }
                    if(keys[(int) Keys.Left]) {
                        heading += 1;
                        yrot = heading;
                    }
                    if(keys[(int) Keys.PageUp]) {
                        lookupdown -= 1;
                    }
                    if(keys[(int) Keys.PageDown]) {
                        lookupdown += 1;
                    }

                    if(keys[(int) Keys.F1]) {                                       // Is F1 Being Pressed?
                        keys[(int) Keys.F1] = false;                                // If So Make Key false
                        KillGLWindow();                                             // Kill Our Current Window
                        fullscreen = !fullscreen;                                   // Toggle Fullscreen / Windowed Mode
                        // Recreate Our OpenGL Window
                        if(!CreateGLWindow("Lionel Brits & NeHe's 3D World Tutorial", 640, 480, 16, fullscreen)) {
                            return;                                                 // Quit If Window Was Not Created
                        }
                        done = false;                                               // We're Not Done Yet
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

            form = new Lesson10();                                              // Create The Window

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
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);        // Clear The Screen And The Depth Buffer
            Gl.glLoadIdentity();                                                // Reset The View

            float x_m, y_m, z_m, u_m, v_m;
            float xtrans = -xpos;
            float ztrans = -zpos;
            float ytrans = -walkbias - 0.25f;
            float sceneroty = 360 - yrot;
            int numtriangles;

            Gl.glRotatef(lookupdown, 1, 0, 0);
            Gl.glRotatef(sceneroty, 0, 1, 0);
            Gl.glTranslatef(xtrans, ytrans, ztrans);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[filter]);
            numtriangles = sector.numtriangles;
            // Process Each Triangle
            for(int loop_m = 0; loop_m < numtriangles; loop_m++) {
                Gl.glBegin(Gl.GL_TRIANGLES);
                    Gl.glNormal3f(0, 0, 1);
                    x_m = sector.triangle[loop_m].vertex[0].x;
                    y_m = sector.triangle[loop_m].vertex[0].y;
                    z_m = sector.triangle[loop_m].vertex[0].z;
                    u_m = sector.triangle[loop_m].vertex[0].u;
                    v_m = sector.triangle[loop_m].vertex[0].v;
                    Gl.glTexCoord2f(u_m, v_m); Gl.glVertex3f(x_m, y_m, z_m);

                    x_m = sector.triangle[loop_m].vertex[1].x;
                    y_m = sector.triangle[loop_m].vertex[1].y;
                    z_m = sector.triangle[loop_m].vertex[1].z;
                    u_m = sector.triangle[loop_m].vertex[1].u;
                    v_m = sector.triangle[loop_m].vertex[1].v;
                    Gl.glTexCoord2f(u_m, v_m); Gl.glVertex3f(x_m, y_m, z_m);

                    x_m = sector.triangle[loop_m].vertex[2].x;
                    y_m = sector.triangle[loop_m].vertex[2].y;
                    z_m = sector.triangle[loop_m].vertex[2].z;
                    u_m = sector.triangle[loop_m].vertex[2].u;
                    v_m = sector.triangle[loop_m].vertex[2].v;
                    Gl.glTexCoord2f(u_m, v_m); Gl.glVertex3f(x_m, y_m, z_m);
                Gl.glEnd();
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

            Gl.glEnable(Gl.GL_TEXTURE_2D);                                      // Enable Texture Mapping
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);                         // Set The Blending Function For Translucency
            Gl.glClearColor(0, 0, 0, 0);                                        // This Will Clear The Background Color To Black
            Gl.glClearDepth(1);                                                 // Enables Clearing Of The Depth Buffer
            Gl.glDepthFunc(Gl.GL_LESS);                                         // The Type Of Depth Test To Do
            Gl.glEnable(Gl.GL_DEPTH_TEST);                                      // Enables Depth Testing
            Gl.glShadeModel(Gl.GL_SMOOTH);                                      // Enables Smooth Color Shading
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);         // Really Nice Perspective Calculations
            return SetupWorld();                                                // Return Success Based On Successfully Loading World
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

            textureImage[0] = LoadBMP("NeHe.Lesson10.Mud.bmp");                 // Load The Bitmap
            // Check For Errors, If Bitmap's Not Found, Quit
            if(textureImage[0] != null) {
                status = true;                                                  // Set The Status To True

                Gl.glGenTextures(3, texture);                            // Create Three Texture

                textureImage[0].RotateFlip(RotateFlipType.RotateNoneFlipY);     // Flip The Bitmap Along The Y-Axis
                // Rectangle For Locking The Bitmap In Memory
                Rectangle rectangle = new Rectangle(0, 0, textureImage[0].Width, textureImage[0].Height);
                // Get The Bitmap's Pixel Data From The Locked Bitmap
                BitmapData bitmapData = textureImage[0].LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                // Create Nearest Filtered Texture
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[0]);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
                Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB8, textureImage[0].Width, textureImage[0].Height, 0, Gl.GL_BGR, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);

                // Create Linear Filtered Texture
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[1]);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
                Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB8, textureImage[0].Width, textureImage[0].Height, 0, Gl.GL_BGR, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);

                // Create MipMapped Texture
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[2]);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR_MIPMAP_NEAREST);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
                Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, Gl.GL_RGB8, textureImage[0].Width, textureImage[0].Height, Gl.GL_BGR, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);

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
            Glu.gluPerspective(45, width / (double) height, 0.1, 100);          // Calculate The Aspect Ratio Of The Window
            Gl.glMatrixMode(Gl.GL_MODELVIEW);                                   // Select The Modelview Matrix
            Gl.glLoadIdentity();                                                // Reset The Modelview Matrix
        }
        #endregion ReSizeGLScene(int width, int height)

        #region SetupWorld()
        /// <summary>
        ///     Loads and parses the world.
        /// </summary>
        /// <returns>
        ///     <c>true</c> on successful load, otherwise <c>false</c>.
        /// </returns>
        private static bool SetupWorld() {
            // This Method Is Pretty Ugly.  The .Net Framework Doesn't Have An Analogous Implementation
            // Of C/C++'s sscanf().  As Such You Have To Manually Parse A File, You Can Either Do So
            // Procedurally Like I'm Doing Here, Or Use Some RegEx's.  To Make It A Bit Easier I Modified
            // The World.txt File To Remove Comments, Empty Lines And Excess Spaces.  Sorry For The
            // Ugliness, I'm Too Lazy To Clean It Up.
            float x, y, z, u, v;                                                // Local Vertex Information
            int numtriangles;                                                   // Local Number Of Triangles
            string oneline = "";                                                // The Line We've Read
            string[] splitter;                                                  // Array For Split Values
            StreamReader reader = null;                                         // Our StreamReader
            ASCIIEncoding encoding = new ASCIIEncoding();                       // ASCII Encoding
            string fileName = @"NeHe.Lesson10.World.txt";                       // The File To Load
            string fileName1 = string.Format("Data{0}{1}",                      // Look For Data\Filename
                Path.DirectorySeparatorChar, fileName);
            string fileName2 = string.Format("{0}{1}{0}{1}Data{1}{2}",          // Look For ..\..\Data\Filename
                "..", Path.DirectorySeparatorChar, fileName);

            // Make Sure The File Exists In One Of The Usual Directories
            if(!File.Exists(fileName) && !File.Exists(fileName1) && !File.Exists(fileName2)) {
                return false;                                                   // If Not Return False
            }

            if(File.Exists(fileName)) {                                         // Does The File Exist Here?
                //fileName = fileName;                                            // Do Nothing
            }
            else if(File.Exists(fileName1)) {                                   // Does The File Exist Here?
                fileName = fileName1;                                           // Swap Filename
            }
            else if(File.Exists(fileName2)) {                                   // Does The File Exist Here?
                fileName = fileName2;                                           // Swap Filename
            }

            reader = new StreamReader(fileName, encoding);                      // Open The File As ASCII Text

            oneline = reader.ReadLine();                                        // Read The First Line
            splitter = oneline.Split();                                         // Split The Line On Spaces

            // The First Item In The Array Will Contain The String "NUMPOLLIES", Which We Will Ignore
            numtriangles = Convert.ToInt32(splitter[1]);                        // Save The Number Of Triangles As An int

            sector.triangle = new Triangle[numtriangles];                       // Initialize The Triangles And Save To sector
            sector.numtriangles = numtriangles;                                 // Save The Number Of Triangles In sector

            for(int triloop = 0; triloop < numtriangles; triloop++) {           // For Every Triangle
                sector.triangle[triloop].vertex = new Vertex[3];                // Initialize The Vertices In sector
                for(int vertloop = 0; vertloop < 3; vertloop++) {               // For Every Vertex
                    oneline = reader.ReadLine();                                // Read A Line
                    if(oneline != null) {                                       // If The Line Isn't null
                        splitter = oneline.Split();                             // Split The Line On Spaces
                        x = Single.Parse(splitter[0]);                          // Save x As A float
                        y = Single.Parse(splitter[1]);                          // Save y As A float
                        z = Single.Parse(splitter[2]);                          // Save z As A float
                        u = Single.Parse(splitter[3]);                          // Save u As A float
                        v = Single.Parse(splitter[4]);                          // Save v As A float
                        sector.triangle[triloop].vertex[vertloop].x = x;        // Save x To sector's Current triangle's vertex x
                        sector.triangle[triloop].vertex[vertloop].y = y;        // Save y To sector's Current triangle's vertex y
                        sector.triangle[triloop].vertex[vertloop].z = z;        // Save z To sector's Current triangle's vertex z
                        sector.triangle[triloop].vertex[vertloop].u = u;        // Save u To sector's Current triangle's vertex u
                        sector.triangle[triloop].vertex[vertloop].v = v;        // Save v To sector's Current triangle's vertex v
                    }
                }
            }
            if(reader != null) {
                reader.Close();                                                 // Close The StreamReader
            }

            return true;                                                        // We've Made It
        }
        #endregion SetupWorld()

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
