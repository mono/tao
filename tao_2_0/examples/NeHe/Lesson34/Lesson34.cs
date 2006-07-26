#region License
/*
MIT License
Copyright �2003-2005 Tao Framework Team
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
 *  This Code Was Created By Ben Humphrey 2001
 *  If You've Found This Code Useful, Please Let Me Know.
 *  Visit NeHe Productions At http://nehe.gamedev.net
*/
/*
==========================================================================
                     OpenGL Lesson 34:  Height Mapping
==========================================================================

  Authors Name: Ben Humphrey ( DigiBen )

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
    ///     Lesson 34:  Height Mapping.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Ben Humphrey ( DigiBen )
    ///         http://nehe.gamedev.net/data/lessons/lesson.asp?lesson=34
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Morten Lerudjordet & Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public class Lesson34 : Form {
        // --- Fields ---
        #region Private Static Fields
        private static IntPtr hDC;                                              // Private GDI Device Context
        private static IntPtr hRC;                                              // Permanent Rendering Context
        private static Form form;                                               // Our Current Windows Form
        private static bool[] keys = new bool[256];                             // Array Used For The Keyboard Routine
        private static bool active = true;                                      // Window Active Flag, Set To True By Default
        private static bool fullscreen = true;                                  // Fullscreen Flag, Set To Fullscreen Mode By Default
        private static bool done = false;                                       // Bool Variable To Exit Main Loop

        private const int MAP_SIZE = 1024;                                      // Size Of Our .RAW Height Map (NEW)
        private const int STEP_SIZE = 16;                                       // Width And Height Of Each Quad (NEW)
        private const float HEIGHT_RATIO = 1.5f;                                // Ratio That The Y Is Scaled According To The X And Z (NEW)
        private static bool bRender = true;                                     // Polygon Flag Set To TRUE By Default (NEW)
        private static byte[] heightMap = new byte[MAP_SIZE * MAP_SIZE];        // Holds The Height Map Data (NEW)
        private static float scaleValue = 0.15f;                                // Scale Value For The Terrain (NEW)
        #endregion Private Static Fields

        // --- Constructors & Destructors ---
        #region Lesson34()
        public Lesson34() {
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
            this.MouseDown += new MouseEventHandler(this.Form_MouseDown);       // On MouseDown Even Call Form_MouseDown
            this.Resize += new EventHandler(this.Form_Resize);                  // On Resize Event Call Form_Resize
        }
        #endregion Lesson34()

        // --- Entry Point ---
        #region Main(string[] commandLineArguments)
        /// <summary>
        ///     The application's entry point.
        /// </summary>
        /// <param name="commandLineArguments">
        ///     Any supplied command line arguments.
        /// </param>
        [STAThread]
        public static void Main(string[] commandLineArguments) {
            // Ask The User Which Screen Mode They Prefer
            if(MessageBox.Show("Would You Like To Run In Fullscreen Mode?", "Start FullScreen?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                fullscreen = false;                                             // Windowed Mode
            }

            // Create Our OpenGL Window
            if(!CreateGLWindow("NeHe & Ben Humphrey's Height Map Tutorial", 640, 480, 16, fullscreen)) {
                return;                                                         // Quit If Window Was Not Created
            }

            while(!done) {                                                      // Loop That Runs While done = false
                Application.DoEvents();                                         // Process Events

                // Draw The Scene.  Watch For ESC Key And Quit Messages From DrawGLScene()
                if((active && (form != null) && !DrawGLScene()) || keys[(int) Keys.Escape]) {
                    //  Active?  Was There A Quit Received?
                    done = true;                                                // ESC Or DrawGLScene Signalled A Quit
                }
                else {                                                          // Not Time To Quit, Update Screen
                    Gdi.SwapBuffers(hDC);                                       // Swap Buffers (Double Buffering)

                    if(keys[(int) Keys.F1]) {                                   // Is F1 Being Pressed?
                        keys[(int) Keys.F1] = false;                            // If So Make Key false
                        KillGLWindow();                                         // Kill Our Current Window
                        fullscreen = !fullscreen;                               // Toggle Fullscreen / Windowed Mode
                        // Recreate Our OpenGL Window
                        if(!CreateGLWindow("NeHe & Ben Humphrey's Height Map Tutorial", 640, 480, 16, fullscreen)) {
                            return;                                             // Quit If Window Was Not Created
                        }
                        done = false;                                           // We're Not Done Yet
                    }

                    if(keys[(int) Keys.Up]) {                                   // Is the UP ARROW key Being Pressed?
                        scaleValue += 0.001f;                                   // Increase the scale value to zoom in
                    }

                    if(keys[(int) Keys.Down]) {                                 // Is the DOWN ARROW key Being Pressed?
                        scaleValue -= 0.001f;                                   // Decrease the scale value to zoom out
                    }
                }
            }

            // Shutdown
            KillGLWindow();                                                     // Kill The Window
            return;                                                             // Exit The Program
        }
        #endregion Main(string[] commandLineArguments)

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

            form = new Lesson34();                                              // Create The Window

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
        ///     Draws everything.
        /// </summary>
        /// <returns>
        ///     Returns <c>true</c> on success, otherwise <c>false</c>.
        /// </returns>
        private static bool DrawGLScene() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);        // Clear The Screen And The Depth Buffer
            Gl.glLoadIdentity();                                                // Reset The Matrix

            Glu.gluLookAt(212, 60, 194, 186, 55, 171, 0, 1, 0);                 // This Determines Where The Camera's Position And View Is
            Gl.glScalef(scaleValue, scaleValue * HEIGHT_RATIO, scaleValue);

            if(!RenderHeightMap(heightMap)) {                                   // Render The Height Map
                return false;
            }
            return true;                                                        // Everything Went OK
        }
        #endregion bool DrawGLScene()

        #region int GetHeight(byte[] heightMap, int x, int y)
        /// <summary>
        ///     Returns the height from a height map index.
        /// </summary>
        /// <param name="heightMap">
        ///     Height map data.
        /// </param>
        /// <param name="x">
        ///     X coordinate value.
        /// </param>
        /// <param name="y">
        ///     Y coordinate value.
        /// </param>
        /// <returns>
        ///     Returns int with height data.
        /// </returns>
        private static int GetHeight(byte[] heightMap, int x, int y) {          // This Returns The Height From A Height Map Index
            x = x % MAP_SIZE;                                                   // Error Check Our x Value
            y = y % MAP_SIZE;                                                   // Error Check Our y Value

            return heightMap[x + (y * MAP_SIZE)];                               // Index Into Our Height Array And Return The Height
        }
        #endregion int GetHeight(byte[] heightMap, int x, int y)

        #region bool InitGL()
        /// <summary>
        ///     All setup for OpenGL goes here.
        /// </summary>
        /// <returns>
        ///     Returns <c>true</c> on success, otherwise <c>false</c>.
        /// </returns>
        private static bool InitGL() {                                          // All Setup For OpenGL Goes Here
            Gl.glShadeModel(Gl.GL_SMOOTH);                                      // Enable Smooth Shading
            Gl.glClearColor(0, 0, 0, 0.5f);                                     // Black Background
            Gl.glClearDepth(1);                                                 // Depth Buffer Setup
            Gl.glEnable(Gl.GL_DEPTH_TEST);                                      // Enables Depth Testing
            Gl.glDepthFunc(Gl.GL_LEQUAL);                                       // The Type Of Depth Testing To Do
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);         // Really Nice Perspective Calculations

            if(!LoadRawFile("NeHe.Lesson34.Terrain.raw", MAP_SIZE * MAP_SIZE, ref heightMap)) {
                return false;                                                   // (NEW) Try To Open Terrain Data
            }

            return true;                                                        // Initialization Went OK
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

        #region bool LoadRawFile(string name, int size, ref byte[] heightMap)
        /// <summary>
        ///     Read data from file.
        /// </summary>
        /// <param name="name">
        ///     Name of file where data resides.
        /// </param>
        /// <param name="size">
        ///     Size of file to be read.
        /// </param>
        /// <param name="heightMap">
        ///     Where data is put when read.
        /// </param>
        /// <returns>
        ///     Returns <c>true</c> if success, <c>false</c> failure.
        /// </returns>
        private static bool LoadRawFile(string name, int size, ref byte[] heightMap) {
            if(name == null || name == string.Empty) {                          // Make Sure A Filename Was Given
                return false;                                                   // If Not Return false
            }

            string fileName1 = string.Format("Data{0}{1}",                      // Look For Data\Filename
                Path.DirectorySeparatorChar, name);
            string fileName2 = string.Format("{0}{1}{0}{1}Data{1}{2}",          // Look For ..\..\Data\Filename
                "..", Path.DirectorySeparatorChar, name);

            // Make Sure The File Exists In One Of The Usual Directories
            if(!File.Exists(name) && !File.Exists(fileName1) && !File.Exists(fileName2)) {
                MessageBox.Show("Can't Find The Height Map!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;                                                   // File Could Not Be Found
            }

            if(File.Exists(fileName1)) {                                        // Does The File Exist Here?
                name = fileName1;                                               // Set To Correct File Path
            }
            else if(File.Exists(fileName2)) {                                   // Does The File Exist Here?
                name = fileName2;                                               // Set To Correct File Path
            }

            // Open The File In Read / Binary Mode
            using(FileStream fs = new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                BinaryReader r = new BinaryReader(fs);
                heightMap = r.ReadBytes(size);
            }
            return true;                                                        // Found And Loaded Data In File
        }
        #endregion bool LoadRawFile(string name, int size, ref byte[] heightMap)

        #region bool RenderHeightMap(byte[] heightMap)
        /// <summary>
        ///     This renders the height map as quads.
        /// </summary>
        /// <param name="heightMap">
        ///     Height map data.
        /// </param>
        private static bool RenderHeightMap(byte[] heightMap) {                 // This Renders The Height Map As Quads
            int X, Y;                                                           // Create Some Variables To Walk The Array With.
            int x, y, z;                                                        // Create Some Variables For Readability

            if(heightMap == null) {                                             // Make Sure Our Height Data Is Valid
                return false;
            }

            if(bRender) {                                                       // What We Want To Render
                Gl.glBegin(Gl.GL_QUADS);                                        // Render Polygons
            }
            else {
                Gl.glBegin(Gl.GL_LINES);                                        // Render Lines Instead
            }

            for(X = 0; X < (MAP_SIZE - STEP_SIZE); X += STEP_SIZE) {
                for (Y = 0; Y < (MAP_SIZE-STEP_SIZE); Y += STEP_SIZE) {
                    // Get The (X, Y, Z) Value For The Bottom Left Vertex
                    x = X;
                    y = GetHeight(heightMap, X, Y);
                    z = Y;

                    SetVertexColor(heightMap, x, z);                            // Set The Color Value Of The Current Vertex
                    Gl.glVertex3i(x, y, z);                                     // Send This Vertex To OpenGL To Be Rendered (Integer Points Are Faster)

                    // Get The (X, Y, Z) Value For The Top Left Vertex
                    x = X;
                    y = GetHeight(heightMap, X, Y + STEP_SIZE);
                    z = Y + STEP_SIZE;

                    SetVertexColor(heightMap, x, z);                            // Set The Color Value Of The Current Vertex
                    Gl.glVertex3i(x, y, z);                                     // Send This Vertex To OpenGL To Be Rendered

                    // Get The (X, Y, Z) Value For The Top Right Vertex
                    x = X + STEP_SIZE;
                    y = GetHeight(heightMap, X + STEP_SIZE, Y + STEP_SIZE);
                    z = Y + STEP_SIZE;

                    SetVertexColor(heightMap, x, z);                            // Set The Color Value Of The Current Vertex
                    Gl.glVertex3i(x, y, z);                                     // Send This Vertex To OpenGL To Be Rendered

                    // Get The (X, Y, Z) Value For The Bottom Right Vertex
                    x = X + STEP_SIZE;
                    y = GetHeight(heightMap, X + STEP_SIZE, Y);
                    z = Y;

                    SetVertexColor(heightMap, x, z);                            // Set The Color Value Of The Current Vertex
                    Gl.glVertex3i(x, y, z);                                     // Send This Vertex To OpenGL To Be Rendered
                }
            }
            Gl.glEnd();
            Gl.glColor4f(1, 1, 1, 1);                                           // Reset The Color
            return true;                                                        // All Good
        }
        #endregion bool RenderHeightMap(byte[] heightMap)

        #region SetVertexColor(byte[] heightMap, int x, int y)
        /// <summary>
        ///     Sets the color value for a particular index, depending on the height index.
        /// </summary>
        /// <param name="heightMap">
        ///     Height map data.
        /// </param>
        /// <param name="x">
        ///     X coordinate value.
        /// </param>
        /// <param name="y">
        ///     Y coordinate value.
        /// </param>
        private static void SetVertexColor(byte[] heightMap, int x, int y) {
            float fColor = -0.15f + (GetHeight(heightMap, x, y ) / 256.0f);
            Gl.glColor3f(0, 0, fColor);                                         // Assign This Blue Shade To The Current Vertex
        }
        #endregion SetVertexColor(byte[] heightMap, int x, int y)

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
            // Calculate The Aspect Ratio Of The Window.  Farthest Distance Changed To 500.0f (NEW)
            Glu.gluPerspective(45, width / (double) height, 0.1, 500);          
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

        #region Form_MouseDown(object sender, MouseEventArgs e)
        /// <summary>
        ///     Handles the form's key down event.
        /// </summary>
        /// <param name="sender">
        ///     The event sender.
        /// </param>
        /// <param name="e">
        ///     The event arguments.
        /// </param>
        public void Form_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                bRender = !bRender;                                             // Change The Rendering State Between Fill And Wireframe
            }
        }
        #endregion Form_MouseDown(object sender, MouseEventArgs e)

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
