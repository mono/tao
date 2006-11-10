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
 *  And Modified By Giuseppe D'Agata (waveform@tiscalinet.it)
 *  If You've Found This Code Useful, Please Let Me Know.
 *  Visit My Site At nehe.gamedev.net
*/
/*
==========================================================================
                 OpenGL Lesson 17:  2D Bitmap Texture Font
==========================================================================

  Authors Name: Giuseppe D'Agata

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
    ///     Lesson 17:  2D Bitmap Texture Font.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Giuseppe D'Agata & Jeff Molofee (NeHe)
    ///         http://nehe.gamedev.net/data/lessons/lesson.asp?lesson=17
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Lesson17 : Form {
        // --- Fields ---
        #region Private Static Fields
        private static IntPtr hDC;                                              // Private GDI Device Context
        private static IntPtr hRC;                                              // Permanent Rendering Context
        private static Form form;                                               // Our Current Windows Form
        private static bool[] keys = new bool[256];                             // Array Used For The Keyboard Routine
        private static bool active = true;                                      // Window Active Flag, Set To True By Default
        private static bool fullscreen = true;                                  // Fullscreen Flag, Set To Fullscreen Mode By Default
        private static bool done = false;                                       // Bool Variable To Exit Main Loop

        private static int fontbase;                                            // Base Display List For The Font
        private static int[] texture = new int[2];                              // Storage For Our Font Texture
        private static int loop;                                                // Generic Loop Variable
        private static float cnt1;                                              // 1st Counter Used To Move Text & For Coloring
        private static float cnt2;                                              // 2nd Counter Used To Move Text & For Coloring
        #endregion Private Static Fields

        // --- Constructors & Destructors ---
        #region Lesson17
        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public Lesson17() {
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
        #endregion Lesson17

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
            if(!CreateGLWindow("NeHe & Giuseppe D'Agata's 2D Font Tutorial", 640, 480, 16, fullscreen)) {
                return;                                                         // Quit If Window Was Not Created
            }

            while(!done) {                                                      // Loop That Runs While done = false
                Application.DoEvents();                                         // Process Events

                // Draw The Scene.  Watch For ESC Key And Quit Messages From DrawGLScene()
                if((active && (form != null) && !DrawGLScene()) || keys[(int) Keys.Escape]) {   //  Active?  Was There A Quit Received?
                    done = true;                                                // ESC Or DrawGLScene Signalled A Quit
                }
                else {                                                          // Not Time To Quit, Update Screen
                    Gdi.SwapBuffers(hDC);                                       // Swap Buffers (Double Buffering)
                }

                if(keys[(int) Keys.F1]) {                                       // Is F1 Being Pressed?
                    keys[(int) Keys.F1] = false;                                // If So Make Key false
                    KillGLWindow();                                             // Kill Our Current Window
                    fullscreen = !fullscreen;                                   // Toggle Fullscreen / Windowed Mode
                    // Recreate Our OpenGL Window
                    if(!CreateGLWindow("NeHe & Giuseppe D'Agata's 2D Font Tutorial", 640, 480, 16, fullscreen)) {
                        return;                                                 // Quit If Window Was Not Created
                    }
                    done = false;                                               // We're Not Done Yet
                }
            }

            // Shutdown
            KillGLWindow();                                                     // Kill The Window
            return;                                                             // Exit The Program
        }
        #endregion Run()

        // --- Private Static Methods ---
        #region BuildFont()
        /// <summary>
        ///     Build our font display list.
        /// </summary>
        private static void BuildFont() {
            float cx;                                                           // Holds Our X Character Coord
            float cy;                                                           // Holds Our Y Character Coord
            fontbase = Gl.glGenLists(256);                                      // Creating 256 Display Lists
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[0]);                     // Select Our Font Texture
            for(loop = 0; loop < 256; loop++) {                                 // Loop Through All 256 Lists
                cx = ((float) (loop % 16)) / 16.0f;                             // X Position Of Current Character
                cy = ((float) (loop / 16)) / 16.0f;                             // Y Position Of Current Character
                Gl.glNewList(fontbase + loop, Gl.GL_COMPILE);                   // Start Building A List
                    Gl.glBegin(Gl.GL_QUADS);                                    // Use A Quad For Each Character
                        Gl.glTexCoord2f(cx, 1 - cy - 0.0625f);                  // Texture Coord (Bottom Left)
                        Gl.glVertex2i(0, 0);                                    // Vertex Coord (Bottom Left)
                        Gl.glTexCoord2f(cx + 0.0625f, 1 - cy - 0.0625f);        // Texture Coord (Bottom Right)
                        Gl.glVertex2i(16, 0);                                   // Vertex Coord (Bottom Right)
                        Gl.glTexCoord2f(cx + 0.0625f, 1 - cy);                  // Texture Coord (Top Right)
                        Gl.glVertex2i(16, 16);                                  // Vertex Coord (Top Right)
                        Gl.glTexCoord2f(cx, 1 - cy);                            // Texture Coord (Top Left)
                        Gl.glVertex2i(0, 16);                                   // Vertex Coord (Top Left)
                    Gl.glEnd();                                                 // Done Building Our Quad (Character)
                    Gl.glTranslated(10, 0, 0);                                  // Move To The Right Of The Character
                Gl.glEndList();                                                 // Done Building The Display List
            }                                                                   // Loop Until All 256 Are Built
        }
        #endregion BuildFont()

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

            form = new Lesson17();                                              // Create The Window

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
            Gl.glLoadIdentity();                                                // Reset The Modelview Matrix
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[1]);                     // Select Our Second Texture
            Gl.glTranslatef(0, 0, -5);                                          // Move Into The Screen 5 Units
            Gl.glRotatef(45, 0, 0, 1);                                          // Rotate On The Z Axis 45 Degrees (Clockwise)
            Gl.glRotatef(cnt1 * 30, 1, 1, 0);                                   // Rotate On The X & Y Axis By cnt1 (Left To Right)
            Gl.glDisable(Gl.GL_BLEND);                                          // Disable Blending Before We Draw In 3D
            Gl.glColor3f(1, 1, 1);                                              // Bright White
            Gl.glBegin(Gl.GL_QUADS);                                            // Draw Our First Texture Mapped Quad
                Gl.glTexCoord2d(0, 0);                                          // First Texture Coord
                Gl.glVertex2f(-1, 1);                                           // First Vertex
                Gl.glTexCoord2d(1, 0);                                          // Second Texture Coord
                Gl.glVertex2f(1, 1);                                            // Second Vertex
                Gl.glTexCoord2d(1, 1);                                          // Third Texture Coord
                Gl.glVertex2f(1, -1);                                           // Third Vertex
                Gl.glTexCoord2d(0, 1);                                          // Fourth Texture Coord
                Gl.glVertex2f(-1, -1);                                          // Fourth Vertex
            Gl.glEnd();                                                         // Done Drawing The First Quad
            Gl.glRotatef(90, 1, 1, 0);                                          // Rotate On The X & Y Axis By 90 Degrees (Left To Right)
            Gl.glBegin(Gl.GL_QUADS);                                            // Draw Our Second Texture Mapped Quad
                Gl.glTexCoord2d(0, 0);                                          // First Texture Coord
                Gl.glVertex2f(-1, 1);                                           // First Vertex
                Gl.glTexCoord2d(1, 0);                                          // Second Texture Coord
                Gl.glVertex2f(1, 1);                                            // Second Vertex
                Gl.glTexCoord2d(1, 1);                                          // Third Texture Coord
                Gl.glVertex2f(1, -1);                                           // Third Vertex
                Gl.glTexCoord2d(0, 1);                                          // Fourth Texture Coord
                Gl.glVertex2f(-1, -1);                                          // Fourth Vertex
            Gl.glEnd();                                                         // Done Drawing Our Second Quad
            Gl.glEnable(Gl.GL_BLEND);                                           // Enable Blending

            Gl.glLoadIdentity();                                                // Reset The View
            // Pulsing Colors Based On Text Position
            Gl.glColor3f(1.0f * ((float) (Math.Cos(cnt1))), 1.0f * ((float) (Math.Sin(cnt2))), 1.0f - 0.5f * ((float) (Math.Cos(cnt1 + cnt2))));
            // Print GL Text To The Screen
            glPrint((int) ((280 + 250 * Math.Cos(cnt1))), (int) (235 + 200 * Math.Sin(cnt2)), "NeHe", 0);
            Gl.glColor3f(1.0f * ((float) (Math.Sin(cnt2))), 1.0f - 0.5f * ((float) (Math.Cos(cnt1 + cnt2))), 1.0f * ((float) (Math.Cos(cnt1))));
            // Print GL Text To The Screen
            glPrint((int) ((280 + 230 * Math.Cos(cnt2))), (int) (235 + 200 * Math.Sin(cnt1)), "OpenGL", 1);
            Gl.glColor3f(0, 0, 1);                                              // Set Color To Blue
            glPrint((int) (240 + 200 * Math.Cos((cnt2 + cnt1) / 5)), 2, "Giuseppe D'Agata", 0);
            Gl.glColor3f(1, 1, 1);                                              // Set Color To White
            glPrint((int) (242 + 200 * Math.Cos((cnt2+cnt1) / 5)), 2, "Giuseppe D'Agata", 0);
            cnt1 += 0.01f;                                                      // Increase The First Counter
            cnt2 += 0.0081f;                                                    // Increase The Second Counter
            return true;
        }
        #endregion bool DrawGLScene()

        #region glPrint(int x, int y, string text, int charset)
        /// <summary>
        ///     Where the printing happens.
        /// </summary>
        /// <param name="x">
        ///     X coordinate.
        /// </param>
        /// <param name="y">
        ///     Y coordinate.
        /// </param>
        /// <param name="text">
        ///     The text to print.
        /// </param>
        /// <param name="charset">
        ///     The character set.
        /// </param>
        private static void glPrint(int x, int y, string text, int charset) {
            if(charset > 1) {
                charset = 1;
            }
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[0]);                     // Select Our Font Texture
            Gl.glDisable(Gl.GL_DEPTH_TEST);                                     // Disables Depth Testing
            Gl.glMatrixMode(Gl.GL_PROJECTION);                                  // Select The Projection Matrix
            Gl.glPushMatrix();                                                  // Store The Projection Matrix
                Gl.glLoadIdentity();                                            // Reset The Projection Matrix
                Gl.glOrtho(0, 640, 0, 480, -1, 1);                              // Set Up An Ortho Screen
                Gl.glMatrixMode(Gl.GL_MODELVIEW);                               // Select The Modelview Matrix
                Gl.glPushMatrix();                                              // Store The Modelview Matrix
                    Gl.glLoadIdentity();                                        // Reset The Modelview Matrix
                    Gl.glTranslated(x, y, 0);                                   // Position The Text (0,0 - Bottom Left)
                    Gl.glListBase(fontbase - 32 + (128 * charset));             // Choose The Font Set (0 or 1)
		    // .NET: We can't draw text directly, it's a string!
		    byte [] textbytes = new byte [text.Length];
		    for (int i = 0; i < text.Length; i++) textbytes[i] = (byte) text[i];
                    Gl.glCallLists(text.Length, Gl.GL_UNSIGNED_BYTE, textbytes);// Write The Text To The Screen
                    Gl.glMatrixMode(Gl.GL_PROJECTION);                          // Select The Projection Matrix
                Gl.glPopMatrix();                                               // Restore The Old Projection Matrix
                Gl.glMatrixMode(Gl.GL_MODELVIEW);                               // Select The Modelview Matrix
            Gl.glPopMatrix();                                                   // Restore The Old Projection Matrix
            Gl.glEnable(Gl.GL_DEPTH_TEST);                                      // Enables Depth Testing
        }
        #endregion glPrint(int x, int y, string text, int charset)

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
            BuildFont();                                                        // Build The Font
            Gl.glClearColor(0, 0, 0, 0);                                        // Clear The Background Color To Black
            Gl.glClearDepth(1);                                                 // Enables Clearing Of The Depth Buffer
            Gl.glDepthFunc(Gl.GL_LEQUAL);                                       // The Type Of Depth Test To Do
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);                         // Select The Type Of Blending
            Gl.glShadeModel(Gl.GL_SMOOTH);                                      // Enables Smooth Color Shading
            Gl.glEnable(Gl.GL_TEXTURE_2D);                                      // Enable 2D Texture Mapping
            return true;
        }
        #endregion bool InitGL()

        #region KillFont()
        /// <summary>
        ///     Delete the font from memory.
        /// </summary>
        private static void KillFont() {
            Gl.glDeleteLists(fontbase, 256);                                    // Delete All 256 Display Lists
        }
        #endregion KillFont()

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

            KillFont();                                                         // Kill The Font
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
            Bitmap[] textureImage = new Bitmap[2];                              // Create Storage Space For The Textures

            textureImage[0] = LoadBMP("NeHe.Lesson17.Font.bmp");                // Load The Bitmaps
            textureImage[1] = LoadBMP("NeHe.Lesson17.Bumps.bmp");

            // Check For Errors, If The Bitmaps Are Not Found, Quit
            if(textureImage[0] != null && textureImage[1] != null) {
                status = true;                                                  // Set The Status To True

                Gl.glGenTextures(2, texture);                            // Create Two Textures

                for(loop = 0; loop < textureImage.Length; loop++) {
                    // Flip The Bitmap Along The Y-Axis
                    textureImage[loop].RotateFlip(RotateFlipType.RotateNoneFlipY);
                    // Rectangle For Locking The Bitmap In Memory
                    Rectangle rectangle = new Rectangle(0, 0, textureImage[loop].Width, textureImage[loop].Height);
                    // Get The Bitmap's Pixel Data From The Locked Bitmap
                    BitmapData bitmapData = textureImage[loop].LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                    // Typical Texture Generation Using Data From The Bitmap
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[loop]);
                    Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
                    Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB8, textureImage[loop].Width, textureImage[loop].Height, 0, Gl.GL_BGR, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);

                    if(textureImage[loop] != null) {                            // If Texture Exists
                        textureImage[loop].UnlockBits(bitmapData);              // Unlock The Pixel Data From Memory
                        textureImage[loop].Dispose();                           // Dispose The Bitmap
                    }
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
