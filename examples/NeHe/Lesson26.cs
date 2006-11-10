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
/*  This code has been created by Banu Octavian aka Choko - 20 may 2000
 *  and uses NeHe tutorials as a starting point (window initialization,
 *  texture loading, GL initialization and code for keypresses) - very good
 *  tutorials, Jeff. If anyone is interested about the presented algorithm
 *  please e-mail me at boct@romwest.ro
 *
 *  Code Commmenting And Clean Up By Jeff Molofee ( NeHe )
 *  NeHe Productions  http://nehe.gamedev.net
*/
/*
==========================================================================
                  OpenGL Lesson 26:  Stencil & Reflection
==========================================================================

  Authors Name: Banu Octavian

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
    ///     Lesson 26:  Stencil & Reflection.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Banu Octavian (Choko) & Jeff Molofee (NeHe)
    ///         http://nehe.gamedev.net/data/lessons/lesson.asp?lesson=26
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Morten Lerudjordet & Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Lesson26 : Form {
        // --- Fields ---
        #region Private Static Fields
        private static IntPtr hDC;                                              // Private GDI Device Context
        private static IntPtr hRC;                                              // Permanent Rendering Context
        private static Form form;                                               // Our Current Windows Form
        private static bool[] keys = new bool[256];                             // Array Used For The Keyboard Routine
        private static bool active = true;                                      // Window Active Flag, Set To True By Default
        private static bool fullscreen = true;                                  // Fullscreen Flag, Set To Fullscreen Mode By Default
        private static bool done = false;                                       // Bool Variable To Exit Main Loop

        private static float[] LightAmb = {0.7f, 0.7f, 0.7f, 1};                // Ambient Light
        private static float[] LightDif = {1, 1, 1, 1};                         // Diffuse Light
        private static float[] LightPos = {4, 4, 6, 1};                         // Light Position
        private static Glu.GLUquadric q;                                        // Quadratic For Drawing A Sphere
        private static float xrot = 0;                                          // X Rotation
        private static float yrot = 0;                                          // Y Rotation
        private static float xrotspeed = 0;                                     // X Rotation Speed
        private static float yrotspeed = 0;                                     // Y Rotation Speed
        private static float zoom = -7;                                         // Depth Into The Screen
        private static float height = 2;                                        // Height Of Ball From Floor
        private static int[] texture = new int[3];                              // 3 Textures
        #endregion Private Static Fields

        // --- Constructors & Destructors ---
        #region Lesson26
        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public Lesson26() {
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
        #endregion Lesson26

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
            if(!CreateGLWindow("Banu Octavian & NeHe's Stencil & Reflection Tutorial", 640, 480, 16, fullscreen)) {
                return;                                                         // Quit If Window Was Not Created
            }

            while(!done) {                                                      // Loop That Runs While done = false
                Application.DoEvents();                                         // Process Events

                // Draw The Scene.  Watch For ESC Key And Quit Messages From DrawGLScene()
                if((active && (form != null) && !DrawGLScene()) || keys[(int) Keys.Escape]) {//  Active?  Was There A Quit Received?
                    done = true;                                            // ESC Or DrawGLScene Signalled A Quit
                }
                else {                                                      // Not Time To Quit, Update Screen
                    Gdi.SwapBuffers(hDC);                                   // Swap Buffers (Double Buffering)

                    ProcessKeyboard();                                      // Processed Keyboard Presses

                    if(keys[(int) Keys.F1]) {                               // Is F1 Being Pressed?
                        keys[(int) Keys.F1] = false;                        // If So Make Key false
                        KillGLWindow();                                     // Kill Our Current Window
                        fullscreen = !fullscreen;                           // Toggle Fullscreen / Windowed Mode
                        // Recreate Our OpenGL Window
                        if(!CreateGLWindow("Banu Octavian & NeHe's Stencil & Reflection Tutorial", 640, 480, 16, fullscreen)) {
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

            form = new Lesson26();                                              // Create The Window

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
            pfd.cStencilBits = 1;                                               // Use Stencil Buffer ( * Important * )
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

        #region DrawFloor()
        /// <summary>
        ///     Draws the floor.
        /// </summary>
        private static void DrawFloor() {
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[0]);                     // Select Texture 1 (0)
            Gl.glBegin(Gl.GL_QUADS);                                            // Begin Drawing A Quad
                Gl.glNormal3f(0, 1, 0);                                         // Normal Pointing Up
                Gl.glTexCoord2f(0, 1);                                          // Bottom Left Of Texture
                Gl.glVertex3f(-2, 0, 2);                                        // Bottom Left Corner Of Floor
                Gl.glTexCoord2f(0, 0);                                          // Top Left Of Texture
                Gl.glVertex3f(-2, 0, -2);                                       // Top Left Corner Of Floor
                Gl.glTexCoord2f(1, 0);                                          // Top Right Of Texture
                Gl.glVertex3f(2, 0,-2);                                         // Top Right Corner Of Floor
                Gl.glTexCoord2f(1, 1);                                          // Bottom Right Of Texture
                Gl.glVertex3f(2, 0, 2);                                         // Bottom Right Corner Of Floor
            Gl.glEnd();                                                         // Done Drawing The Quad
        }
        #endregion DrawFloor()

        #region bool DrawGLScene()
        /// <summary>
        ///     Draws everything.
        /// </summary>
        /// <returns>
        ///     Returns <c>true</c> on success, otherwise <c>false</c>.
        /// </returns>
        private static bool DrawGLScene() {
            // Clear Screen, Depth Buffer & Stencil Buffer
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);

            // Clip Plane Equations
            double[] eqr = {0,-1, 0, 0};                                        // Plane Equation To Use For The Reflected Objects

            Gl.glLoadIdentity();                                                // Reset The Modelview Matrix
            Gl.glTranslatef(0, -0.6f, zoom);                                    // Zoom And Raise Camera Above The Floor (Up 0.6 Units)
            Gl.glColorMask(0, 0, 0, 0);                                         // Set Color Mask
            Gl.glEnable(Gl.GL_STENCIL_TEST);                                    // Enable Stencil Buffer For "marking" The Floor
            Gl.glStencilFunc(Gl.GL_ALWAYS, 1, 1);                               // Always Passes, 1 Bit Plane, 1 As Mask
            Gl.glStencilOp(Gl.GL_KEEP, Gl.GL_KEEP, Gl.GL_REPLACE);              // We Set The Stencil Buffer To 1 Where We Draw Any Polygon
                                                                                // Keep If Test Fails, Keep If Test Passes But Buffer Test Fails
                                                                                // Replace If Test Passes
            Gl.glDisable(Gl.GL_DEPTH_TEST);                                     // Disable Depth Testing
            DrawFloor();                                                        // Draw The Floor (Draws To The Stencil Buffer)
                                                                                // We Only Want To Mark It In The Stencil Buffer
            Gl.glEnable(Gl.GL_DEPTH_TEST);                                      // Enable Depth Testing
            Gl.glColorMask(1, 1, 1, 1);                                         // Set Color Mask to TRUE, TRUE, TRUE, TRUE
            Gl.glStencilFunc(Gl.GL_EQUAL, 1, 1);                                // We Draw Only Where The Stencil Is 1
                                                                                // (I.E. Where The Floor Was Drawn)
            Gl.glStencilOp(Gl.GL_KEEP, Gl.GL_KEEP, Gl.GL_KEEP);                 // Don't Change The Stencil Buffer
            Gl.glEnable(Gl.GL_CLIP_PLANE0);                                     // Enable Clip Plane For Removing Artifacts
            // (When The Object Crosses The Floor)
            Gl.glClipPlane(Gl.GL_CLIP_PLANE0, eqr);                             // Equation For Reflected Objects
            Gl.glPushMatrix();                                                  // Push The Matrix Onto The Stack
                Gl.glScalef(1, -1, 1);                                          // Mirror Y Axis
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, LightPos);           // Set Up Light0
                Gl.glTranslatef(0, height, 0);                                  // Position The Object
                Gl.glRotatef(xrot, 1, 0, 0);                                    // Rotate Local Coordinate System On X Axis
                Gl.glRotatef(yrot, 0, 1, 0);                                    // Rotate Local Coordinate System On Y Axis
                DrawObject();                                                   // Draw The Sphere (Reflection)
            Gl.glPopMatrix();                                                   // Pop The Matrix Off The Stack
            Gl.glDisable(Gl.GL_CLIP_PLANE0);                                    // Disable Clip Plane For Drawing The Floor
            Gl.glDisable(Gl.GL_STENCIL_TEST);                                   // We Don't Need The Stencil Buffer Any More (Disable)
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, LightPos);               // Set Up Light0 Position
            Gl.glEnable(Gl.GL_BLEND);                                           // Enable Blending (Otherwise The Reflected Object Wont Show)
            Gl.glDisable(Gl.GL_LIGHTING);                                       // Since We Use Blending, We Disable Lighting
            Gl.glColor4f(1, 1, 1, 0.8f);                                        // Set Color To White With 80% Alpha
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);         // Blending Based On Source Alpha And 1 Minus Dest Alpha
            DrawFloor();                                                        // Draw The Floor To The Screen
            Gl.glEnable(Gl.GL_LIGHTING);                                        // Enable Lighting
            Gl.glDisable(Gl.GL_BLEND);                                          // Disable Blending
            Gl.glTranslatef(0, height, 0);                                      // Position The Ball At Proper Height
            Gl.glRotatef(xrot, 1, 0, 0);                                        // Rotate On The X Axis
            Gl.glRotatef(yrot, 0, 1, 0);                                        // Rotate On The Y Axis
            DrawObject();                                                       // Draw The Ball
            xrot += xrotspeed;                                                  // Update X Rotation Angle By xrotspeed
            yrot += yrotspeed;                                                  // Update Y Rotation Angle By yrotspeed
            Gl.glFlush();                                                       // Flush The GL Pipeline
            return true;                                                        // Everything Went OK
        }
        #endregion bool DrawGLScene()

        #region DrawObject()
        /// <summary>
        ///     Draws our ball.
        /// </summary>
        private static void DrawObject() {
            Gl.glColor3f(1, 1, 1);                                              // Set Color To White
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[1]);                     // Select Texture 2 (1)
            Glu.gluSphere(q, 0.35f, 32, 16);                                    // Draw First Sphere
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[2]);                     // Select Texture 3 (2)
            Gl.glColor4f(1, 1, 1, 0.4f);                                        // Set Color To White With 40% Alpha
            Gl.glEnable(Gl.GL_BLEND);                                           // Enable Blending
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);                         // Set Blending Mode To Mix Based On SRC Alpha
            Gl.glEnable(Gl.GL_TEXTURE_GEN_S);                                   // Enable Sphere Mapping
            Gl.glEnable(Gl.GL_TEXTURE_GEN_T);                                   // Enable Sphere Mapping
            Glu.gluSphere(q, 0.35f, 32, 16);                                    // Draw Another Sphere Using New Texture
            // Textures Will Mix Creating A MultiTexture Effect (Reflection)
            Gl.glDisable(Gl.GL_TEXTURE_GEN_S);                                  // Disable Sphere Mapping
            Gl.glDisable(Gl.GL_TEXTURE_GEN_T);                                  // Disable Sphere Mapping
            Gl.glDisable(Gl.GL_BLEND);                                          // Disable Blending
        }
        #endregion DrawObject()

        #region bool InitGL()
        /// <summary>
        ///     All setup for OpenGL goes here.
        /// </summary>
        /// <returns>
        ///     Returns <c>true</c> on success, otherwise <c>false</c>.
        /// </returns>
        private static bool InitGL() {                                          // All Setup For OpenGL Goes Here
            if(!LoadGLTextures()) {                                             // If Loading The Textures Failed
                return false;                                                   // Return False
            }
            Gl.glShadeModel(Gl.GL_SMOOTH);                                      // Enable Smooth Shading
            Gl.glClearColor(0.2f, 0.5f, 1, 1);                                  // Background
            Gl.glClearDepth(1);                                                 // Depth Buffer Setup
            Gl.glClearStencil(0);                                               // Clear The Stencil Buffer To 0
            Gl.glEnable(Gl.GL_DEPTH_TEST);                                      // Enables Depth Testing
            Gl.glDepthFunc(Gl.GL_LEQUAL);                                       // The Type Of Depth Testing To Do
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);         // Really Nice Perspective Calculations
            Gl.glEnable(Gl.GL_TEXTURE_2D);                                      // Enable 2D Texture Mapping
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, LightAmb);                // Set The Ambient Lighting For Light0
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, LightDif);                // Set The Diffuse Lighting For Light0
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, LightPos);               // Set The Position For Light0
            Gl.glEnable(Gl.GL_LIGHT0);                                          // Enable Light 0
            Gl.glEnable(Gl.GL_LIGHTING);                                        // Enable Lighting
            q = Glu.gluNewQuadric();                                            // Create A New Quadratic
            Glu.gluQuadricNormals(q, Gl.GL_SMOOTH);                             // Generate Smooth Normals For The Quad
            Glu.gluQuadricTexture(q, Gl.GL_TRUE);                               // Enable Texture Coords For The Quad
            Gl.glTexGeni(Gl.GL_S, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_SPHERE_MAP);    // Set Up Sphere Mapping
            Gl.glTexGeni(Gl.GL_T, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_SPHERE_MAP);    // Set Up Sphere Mapping

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

        #region bool LoadGLTextures()
        /// <summary>
        ///     Load bitmaps and convert to textures.
        /// </summary>
        /// <returns>
        ///     <c>true</c> on success, otherwise <c>false</c>.
        /// </returns>
        private static bool LoadGLTextures() {
            bool status = false;                                                // Status Indicator
            Bitmap[] textureImage = new Bitmap[3];                              // Create Storage Space For The Texture

            textureImage[0] = LoadBMP("NeHe.Lesson26.EnvWall.bmp");             // Load The Floor Texture
            textureImage[1] = LoadBMP("NeHe.Lesson26.Ball.bmp");                // Load the Light Texture
            textureImage[2] = LoadBMP("NeHe.Lesson26.EnvRoll.bmp");             // Load the Wall Texture
            // Check For Errors, If Bitmap's Not Found, Quit
            if(textureImage[0] != null && textureImage[1] != null &&
                textureImage[2] != null) {
                status = true;                                                  // Set The Status To True

                Gl.glGenTextures(3, texture);                                   // Create Three Textures
                for(int loop = 0; loop < textureImage.Length; loop++) {         // Loop Through All 3 Textures
                    // Flip The Bitmap Along The Y-Axis
                    textureImage[loop].RotateFlip(RotateFlipType.RotateNoneFlipY);
                    // Rectangle For Locking The Bitmap In Memory
                    Rectangle rectangle = new Rectangle(0, 0, textureImage[loop].Width, textureImage[loop].Height);
                    // Get The Bitmap's Pixel Data From The Locked Bitmap
                    BitmapData bitmapData = textureImage[loop].LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                    // Create Linear Filtered Texture
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

        #region ProcessKeyboard()
        /// <summary>
        ///     Prcess keyboard results.
        /// </summary>
        private static void ProcessKeyboard() {
            if(keys[(int) Keys.Right]) {
                yrotspeed += 0.08f;                                 // Right Arrow Pressed (Increase yrotspeed)
            }
            if(keys[(int) Keys.Left]) {
                yrotspeed -= 0.08f;                                 // Left Arrow Pressed (Decrease yrotspeed)
            }
            if(keys[(int) Keys.Down]) {
                xrotspeed += 0.08f;                                 // Down Arrow Pressed (Increase xrotspeed)
            }
            if(keys[(int) Keys.Up]) {
                xrotspeed -= 0.08f;                                 // Up Arrow Pressed (Decrease xrotspeed)
            }
            if(keys[(int) Keys.A]) {
                zoom += 0.05f;                                      // 'A' Key Pressed ... Zoom In
            }
            if(keys[(int) Keys.Z]) {
                zoom -= 0.05f;                                      // 'Z' Key Pressed ... Zoom Out
            }
            if(keys[(int) Keys.PageUp]) {
                height += 0.03f;                                    // Page Up Key Pressed Move Ball Up
            }
            if(keys[(int) Keys.PageDown]) {
                height -= 0.03f;                                    // Page Down Key Pressed Move Ball Down
            }
        }
        #endregion ProcessKeyboard()

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
