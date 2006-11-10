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
 *  This Code Was Created By Pet & Commented/Cleaned Up By Jeff Molofee
 *  If You've Found This Code Useful, Please Let Me Know.
 *  Visit NeHe Productions At http://nehe.gamedev.net
 */
/*
==========================================================================
                    OpenGL Lesson 25:  Morphing Points
==========================================================================

  Authors Name: Piotr Cieslak

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
    ///     Lesson 25: Morphing Points.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:   Piotr Cieslak & Jeff Molofee (NeHe)
    ///         http://nehe.gamedev.net/data/lessons/lesson.asp?lesson=25
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public class Lesson25 : Form {
        // --- Fields ---
        #region Private Static Fields
        private static IntPtr hDC;                                              // Private GDI Device Context
        private static IntPtr hRC;                                              // Permanent Rendering Context
        private static Form form;                                               // Our Current Windows Form
        private static bool[] keys = new bool[256];                             // Array Used For The Keyboard Routine
        private static bool active = true;                                      // Window Active Flag, Set To True By Default
        private static bool fullscreen = true;                                  // Fullscreen Flag, Set To Fullscreen Mode By Default
        private static bool done = false;                                       // Bool Variable To Exit Main Loop

        private static float xrot;                                              // X Rotation
        private static float yrot;                                              // Y Rotation
        private static float zrot;                                              // Z Rotation
        private static float xspeed;                                            // X Rotation Speed
        private static float yspeed;                                            // Y Rotation Speed
        private static float zspeed;                                            // Z Rotation Speed
        private static float cx;                                                // X Position
        private static float cy;                                                // Y Position
        private static float cz = -15;                                          // Z Position

        private static int key = 1;                                             // Make Sure Same Morph Key Is Not Pressed
        private static int step = 0;                                            // Step Counter
        private static int steps = 200;                                         // Maximum Number Of Steps
        private static bool morph;                                              // Morphing?

        private static int maxver;                                              // Maximum Number Of Vertices
        private static Thing morph1, morph2, morph3, morph4;                    // Our 4 Morphable Objects
        private static Thing helper, source, destination;                       // Helper Object, Source Object, Destination Object

        private static Random rand = new Random();                              // Random Number Generator

        private struct Vertex {                                                 // Structure For 3d Points
            public float X;                                                     // X Coordinate
            public float Y;                                                     // Y Coordinate
            public float Z;                                                     // Z Coordinate
        }

        private struct Thing {                                                  // Structure For An Object
            public int Verts;                                                   // Number Of Vertices For The Object
            public Vertex[] Points;                                             // Vertices
        }
        #endregion Private Static Fields

        // --- Constructors & Destructors ---
        #region Lesson25
        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public Lesson25() {
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
        #endregion Lesson25

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
                fullscreen = false;                                              // Windowed Mode
            }

            // Create Our OpenGL Window
            if(!CreateGLWindow("Piotr Cieslak & NeHe's Morphing Points Tutorial", 640, 480, 16, fullscreen)) {
                return;                                                         // Quit If Window Was Not Created
            }

            while(!done) {                                                      // Loop That Runs While done = false
                Application.DoEvents();                                         // Process Events

                // Draw The Scene.  Watch For ESC Key And Quit Messages From DrawGLScene()
                if(active && keys[(int) Keys.Escape] || form == null) {         //  Active?  Was There A Quit Received?
                    done = true;                                                // ESC Or DrawGLScene Signalled A Quit
                }
                else {                                                          // Not Time To Quit, Update Screen
                    DrawGLScene();                                              // Draw
                    Gdi.SwapBuffers(hDC);                                       // Swap Buffers (Double Buffering)

                    if(keys[(int) Keys.PageUp]) {                               // Is Page Up Being Pressed?
                        zspeed += 0.01f;                                        // Increase zspeed
                    }
                    if(keys[(int) Keys.PageDown]) {                             // Is Page Down Being Pressed?
                        zspeed -= 0.01f;                                        // Decrease zspeed
                    }
                    if(keys[(int) Keys.Down]) {                                 // Is Down Arrow Being Pressed?
                        xspeed += 0.01f;                                        // Increase xspeed
                    }
                    if(keys[(int) Keys.Up]) {                                   // Is Up Arrow Being Pressed?
                        xspeed -= 0.01f;                                        // Decrease xspeed
                    }
                    if(keys[(int) Keys.Right]) {                                // Is Right Arrow Being Pressed?
                        yspeed += 0.01f;                                        // Increase yspeed
                    }
                    if(keys[(int) Keys.Left]) {                                 // Is Left Arrow Being Pressed?
                        yspeed -= 0.01f;                                        // Decrease yspeed
                    }
                    if(keys[(int) Keys.Q]) {                                    // Is Q Key Being Pressed?
                        cz -= 0.01f;                                            // Move Object Away From Viewer
                    }
                    if(keys[(int) Keys.Z]) {                                    // Is Z Key Being Pressed?
                        cz += 0.01f;                                            // Move Object Towards Viewer
                    }
                    if(keys[(int) Keys.W]) {                                    // Is W Key Being Pressed?
                        cy += 0.01f;                                            // Move Object Up
                    }
                    if(keys[(int) Keys.S]) {                                    // Is S Key Being Pressed?
                        cy -= 0.01f;                                            // Move Object Down
                    }
                    if(keys[(int) Keys.D]) {                                    // Is W Key Being Pressed?
                        cx += 0.01f;                                            // Move Object Right
                    }
                    if(keys[(int) Keys.A]) {                                    // Is S Key Being Pressed?
                        cx -= 0.01f;                                            // Move Object Left
                    }

                    if(keys[(int) Keys.D1] && (key != 1) && !morph) {           // Is 1 Pressed, key Not Equal To 1 And Morph False?
                        key = 1;                                                // Sets key To 1 (To Prevent Pressing 1 2x In A Row)
                        morph = true;                                           // Set morph To True (Starts Morphing Process)
                        destination = morph1;                                   // Destination Object To Morph To Becomes morph1
                    }
                    if(keys[(int) Keys.D2] && (key != 2) && !morph) {           // Is 2 Pressed, key Not Equal To 2 And Morph False?
                        key = 2;                                                // Sets key To 2 (To Prevent Pressing 2 2x In A Row)
                        morph = true;                                           // Set morph To True (Starts Morphing Process)
                        destination = morph2;                                   // Destination Object To Morph To Becomes morph2
                    }
                    if(keys[(int) Keys.D3] && (key != 3) && !morph) {           // Is 3 Pressed, key Not Equal To 3 And Morph False?
                        key = 3;                                                // Sets key To 3 (To Prevent Pressing 3 2x In A Row)
                        morph = true;                                           // Set morph To True (Starts Morphing Process)
                        destination = morph3;                                   // Destination Object To Morph To Becomes morph3
                    }
                    if(keys[(int) Keys.D4] && (key != 4) && !morph) {           // Is 4 Pressed, key Not Equal To 4 And Morph False?
                        key = 4;                                                // Sets key To 4 (To Prevent Pressing 4 2x In A Row)
                        morph = true;                                           // Set morph To True (Starts Morphing Process)
                        destination = morph4;                                   // Destination Object To Morph To Becomes morph4
                    }

                    if(keys[(int) Keys.F1]) {                                   // Is F1 Being Pressed?
                        keys[(int) Keys.F1] = false;                            // If So Make Key false
                        KillGLWindow();                                         // Kill Our Current Window
                        fullscreen = !fullscreen;                               // Toggle Fullscreen / Windowed Mode
                        // Recreate Our OpenGL Window
                        if(!CreateGLWindow("NeHe & TipTup's Environment Mapping Tutorial", 640, 480, 16, fullscreen)) {
                            return;                                             // Quit If Window Was Not Created
                        }
                        done = false;                                           // We're Not Done Yet
                    }
                }
            }

            // Shutdown
            KillGLWindow();                                                     // Kill The Window
            return;                                                             // Exit The Program
        }
        #endregion Run()

        // --- Private Static Methods ---
        #region AllocateThing(ref Thing thing, int number)
        /// <summary>
        ///     Allocate memory for each object.
        /// </summary>
        /// <param name="thing">
        ///     The object.
        /// </param>
        /// <param name="number">
        ///     The number of points to allocate.
        /// </param>
        private static void AllocateThing(ref Thing thing, int number) {
            thing.Points = new Vertex[number];
        }
        #endregion AllocateThing(ref Thing thing, int number)

        #region Vertex Calculate(int i)
        /// <summary>
        ///     Calculates movement of points during morphing.
        /// </summary>
        /// <param name="i">
        ///     The number of the point to calculate.
        /// </param>
        /// <returns>
        ///     A Vertex.
        /// </returns>
        private static Vertex Calculate(int i) {
            // This Makes Points Move At A Speed So They All Get To Their Destination At The Same Time
            Vertex a;                                                                   // Temporary Vertex Called a
            a.X = (source.Points[i].X - destination.Points[i].X) / steps;               // a.X Value Equals Source X - Destination X Divided By Steps
            a.Y = (source.Points[i].Y - destination.Points[i].Y) / steps;               // a.Y Value Equals Source Y - Destination Y Divided By Steps
            a.Z = (source.Points[i].Z - destination.Points[i].Z) / steps;               // a.Z Value Equals Source Z - Destination Z Divided By Steps
            return a;                                                                   // Return The Results
        }
        #endregion Vertex Calculate(int i)

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

            form = new Lesson25();                                              // Create The Window

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

        #region DrawGLScene()
        /// <summary>
        ///     Draws everything.
        /// </summary>
        /// <returns>
        ///     Returns <c>true</c> on success, otherwise <c>false</c>.
        /// </returns>
        private static void DrawGLScene() {                                     // Here's Where We Do All The Drawing
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);        // Clear The Screen And The Depth Buffer
            Gl.glLoadIdentity();                                                // Reset The View
            Gl.glTranslatef(cx, cy, cz);                                        // Translate The The Current Position To Start Drawing
            Gl.glRotatef(xrot, 1, 0, 0);                                        // Rotate On The X Axis By xrot
            Gl.glRotatef(yrot, 0, 1, 0);                                        // Rotate On The Y Axis By yrot
            Gl.glRotatef(zrot, 0, 0, 1);                                        // Rotate On The Z Axis By zrot

            xrot += xspeed;
            yrot += yspeed;
            zrot += zspeed;                                                     // Increase xrot,yrot & zrot by xspeed, yspeed & zspeed

            float tx, ty, tz;                                                   // Temp X, Y & Z Variables
            Vertex q;                                                           // Holds Returned Calculated Values For One Vertex

            Gl.glBegin(Gl.GL_POINTS);                                           // Begin Drawing Points
            for(int i = 0; i < morph1.Verts; i++) {                             // Loop Through All The Verts Of morph1 (All Objects Have
                if(morph) {                                                     // The Same Amount Of Verts For Simplicity, Could Use maxver Also)
                    q = Calculate(i);
                }
                else {
                    q.X = q.Y = q.Z = 0;                                        // If morph Is True Calculate Movement Otherwise Movement=0
                }
                helper.Points[i].X -= q.X;                                      // Subtract q.x Units From helper.points[i].x (Move On X Axis)
                helper.Points[i].Y -= q.Y;                                      // Subtract q.y Units From helper.points[i].y (Move On Y Axis)
                helper.Points[i].Z -= q.Z;                                      // Subtract q.z Units From helper.points[i].z (Move On Z Axis)
                tx = helper.Points[i].X;                                        // Make Temp X Variable Equal To Helper's X Variable
                ty = helper.Points[i].Y;                                        // Make Temp Y Variable Equal To Helper's Y Variable
                tz = helper.Points[i].Z;                                        // Make Temp Z Variable Equal To Helper's Z Variable

                Gl.glColor3f(0, 1, 1);                                          // Set Color To A Bright Shade Of Off Blue
                Gl.glVertex3f(tx, ty, tz);                                      // Draw A Point At The Current Temp Values (Vertex)
                Gl.glColor3f(0, 0.5f, 1);                                       // Darken Color A Bit
                tx -= 2 * q.X;
                ty -= 2 * q.Y;
                ty -= 2 * q.Y;                                                  // Calculate Two Positions Ahead
                Gl.glVertex3f(tx, ty, tz);                                      // Draw A Second Point At The Newly Calculate Position
                Gl.glColor3f(0, 0, 1);                                          // Set Color To A Very Dark Blue
                tx -= 2 * q.X;
                ty -= 2 * q.Y;
                ty -= 2 * q.Y;                                                  // Calculate Two More Positions Ahead
                Gl.glVertex3f(tx, ty, tz);                                      // Draw A Third Point At The Second New Position
            }                                                                   // This Creates A Ghostly Tail As Points Move
            Gl.glEnd();                                                         // Done Drawing Points

            // If We're Morphing And We Haven't Gone Through All 200 Steps Increase Our Step Counter
            // Otherwise Set Morphing To False, Make Source=Destination And Set The Step Counter Back To Zero.
            if(morph && step <= steps) {
                step++;
            }
            else {
                morph = false;
                source = destination;
                step = 0;
            }
        }
        #endregion DrawGLScene()

        #region bool InitGL()
        /// <summary>
        ///     All setup for OpenGL goes here.
        /// </summary>
        /// <returns>
        ///     Returns <c>true</c> on success, otherwise <c>false</c>.
        /// </returns>
        private static bool InitGL() {                                          // All Setup For OpenGL Goes Here
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);                         // Set The Blending Function For Translucency
            Gl.glClearColor(0, 0, 0, 0);                                        // This Will Clear The Background Color To Black
            Gl.glClearDepth(1);                                                 // Enables Clearing Of The Depth Buffer
            Gl.glDepthFunc(Gl.GL_LESS);                                         // The Type Of Depth Test To Do
            Gl.glEnable(Gl.GL_DEPTH_TEST);                                      // Enables Depth Testing
            Gl.glShadeModel(Gl.GL_SMOOTH);                                      // Enables Smooth Color Shading
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);         // Really Nice Perspective Calculations

            maxver = 0;                                                         // Sets Max Vertices To 0 By Default

            LoadThing("NeHe.Lesson25.Sphere.txt", ref morph1);                  // Load The First Object Into morph1 From File sphere.txt
            LoadThing("NeHe.Lesson25.Torus.txt", ref morph2);                   // Load The Second Object Into morph2 From File torus.txt
            LoadThing("NeHe.Lesson25.Tube.txt", ref morph3);                    // Load The Third Object Into morph3 From File tube.txt

            AllocateThing(ref morph4, 486);                                     // Manually Reserver Ram For A 4th 468 Vertice Object (morph4)
            for(int i = 0; i < 486; i++) {                                      // Loop Through All 468 Vertices
                morph4.Points[i].X = ((float) (rand.Next() % 14000) / 1000) - 7;// morph4 X Point Becomes A Random Float Value From -7 to 7
                morph4.Points[i].Y = ((float) (rand.Next() % 14000) / 1000) - 7;// morph4 Y Point Becomes A Random Float Value From -7 to 7
                morph4.Points[i].Z = ((float) (rand.Next() % 14000) / 1000) - 7;// morph4 Z Point Becomes A Random Float Value From -7 to 7
            }

            LoadThing("NeHe.Lesson25.Sphere.txt", ref helper);                  // Load sphere.txt Object Into Helper (Used As Starting Point)
            source = destination = morph1;                                      // Source & Destination Are Set To Equal First Object (morph1)

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

        #region LoadThing(string filename, ref Thing k)
        /// <summary>
        ///     Loads Object from a file.
        /// </summary>
        /// <param name="filename">
        ///     The file to load.
        /// </param>
        /// <param name="k">
        ///     The Object to save to.
        /// </param>
        private static void LoadThing(string filename, ref Thing k) {
            int ver;                                                                    // Will Hold Vertice Count
            float rx, ry, rz;                                                           // Hold Vertex X, Y & Z Position
            string oneline = "";                                                        // The Line We've Read
            string[] splitter;                                                          // Array For Split Values
            StreamReader reader = null;                                                 // Our StreamReader
            ASCIIEncoding encoding = new ASCIIEncoding();                               // ASCII Encoding

            try {
                if(filename == null || filename == string.Empty) {                      // Make Sure A Filename Was Given
                    return;                                                             // If Not Return
                }

                string fileName1 = string.Format("Data{0}{1}",                          // Look For Data\Filename
                    Path.DirectorySeparatorChar, filename);
                string fileName2 = string.Format("{0}{1}{0}{1}Data{1}{2}",              // Look For ..\..\Data\Filename
                    "..", Path.DirectorySeparatorChar, filename);

                // Make Sure The File Exists In One Of The Usual Directories
                if(!File.Exists(filename) && !File.Exists(fileName1) && !File.Exists(fileName2)) {
                    return;                                                             // If Not Return Null
                }

                if(File.Exists(filename)) {                                             // Does The File Exist Here?
                    reader = new StreamReader(filename, encoding);                          // Open The File As ASCII Text
                }
                else if(File.Exists(fileName1)) {                                       // Does The File Exist Here?
                    reader = new StreamReader(fileName1, encoding);                     // Open The File As ASCII Text
                }
                else if(File.Exists(fileName2)) {                                       // Does The File Exist Here?
                    reader = new StreamReader(fileName2, encoding);                     // Open The File As ASCII Text
                }

                oneline = reader.ReadLine();                                            // Read The First Line
                splitter = oneline.Split();                                             // Split The Line On Spaces

                // The First Item In The Array Will Contain The String "Vertices:", Which We Will Ignore
                ver = Convert.ToInt32(splitter[1]);                                     // Save The Number Of Triangles To ver As An int
                k.Verts = ver;                                                          // Sets PointObjects (k) verts Variable To Equal The Value Of ver
                AllocateThing(ref k, ver);                                              // Jumps To Code That Allocates Ram To Hold The Object

                for(int vertloop = 0; vertloop < ver; vertloop++) {                     // Loop Through The Vertices
                    oneline = reader.ReadLine();                                        // Reads In The Next Line Of Text
                    if(oneline != null) {                                               // If The Line's Not null
                        splitter = oneline.Split();                                     // Split The Line On Spaces
                        rx = float.Parse(splitter[0]);                                  // Save The X Value As A Float
                        ry = float.Parse(splitter[1]);                                  // Save The Y Value As A Float
                        rz = float.Parse(splitter[2]);                                  // Save The Z Value As A Float
                        k.Points[vertloop].X = rx;                                      // Sets PointObjects (k) points.x Value To rx
                        k.Points[vertloop].Y = ry;                                      // Sets PointObjects (k) points.y Value To ry
                        k.Points[vertloop].Z = rz;                                      // Sets PointObjects (k) points.z Value To rz
                    }
                }

                if(ver > maxver) {                                                      // If ver Is Greater Than maxver
                    // maxver Keeps Track Of The Highest Number Of Vertices Used In Any Of The Objects
                    maxver = ver;                                                       // Set maxver Equal To ver
                }
            }
            catch(Exception e) {
                // Handle Any Exceptions While Loading Object Data, Exit App
                string errorMsg = "An Error Occurred While Loading And Parsing Object Data:\n\t" + filename + "\n" + "\n\nStack Trace:\n\t" + e.StackTrace + "\n";
                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                done = true;
            }
            finally {
                if(reader != null) {
                    reader.Close();                                                     // Close The StreamReader
                }
            }
        }
        #endregion LoadThing(string filename, ref Thing k)

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
