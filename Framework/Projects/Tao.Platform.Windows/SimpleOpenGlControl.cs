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

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tao.OpenGl;

namespace Tao.Platform.Windows {
    #region Class Documentation
    /// <summary>
    ///     Provides a simple OpenGL control allowing quick development of Windows Forms-based
    ///     OpenGL applications.
    /// </summary>
    #endregion Class Documentation
    public class SimpleOpenGlControl : UserControl {
        // --- Fields ---
        #region Private Fields
        private IContainer components;                                      // Required for designer support
        private IntPtr deviceContext = IntPtr.Zero;                         // GDI device context
        private IntPtr renderingContext = IntPtr.Zero;                      // Rendering context
        private IntPtr windowHandle = IntPtr.Zero;                          // Holds our window handle
        private bool autoCheckErrors = false;                               // Should we provide glGetError()?
        private bool autoFinish = false;                                    // Should we provide a glFinish()?
        private bool autoMakeCurrent = true;                                // Should we automatically make the rendering context current?
        private bool autoSwapBuffers = true;                                // Should we automatically swap buffers?
        private byte accumBits = 0;                                         // Accumulation buffer bits
        private byte colorBits = 32;                                        // Color buffer bits
        private byte depthBits = 16;                                        // Depth buffer bits
        private byte stencilBits = 0;                                       // Stencil buffer bits
        private int errorCode = Gl.GL_NO_ERROR;                             // The GL error code
        #endregion Private Fields

        #region Public Properties
        #region AccumBits
        /// <summary>
        ///     Gets and sets the OpenGL control's accumulation buffer depth.
        /// </summary>
        [Category("OpenGL Properties"), Description("Accumulation buffer depth in bits.")]
        public byte AccumBits {
            get {
                return accumBits;
            }
            set {
                accumBits = value;
            }
        }
        #endregion AccumBits

        #region ColorBits
        /// <summary>
        ///     Gets and sets the OpenGL control's color buffer depth.
        /// </summary>
        [Category("OpenGL Properties"), Description("Color buffer depth in bits.")]
        public byte ColorBits {
            get {
                return colorBits;
            }
            set {
                colorBits = value;
            }
        }
        #endregion ColorBits

        #region DepthBits
        /// <summary>
        ///     Gets and sets the OpenGL control's depth buffer (Z-buffer) depth.
        /// </summary>
        [Category("OpenGL Properties"), Description("Depth buffer (Z-buffer) depth in bits.")]
        public byte DepthBits {
            get {
                return depthBits;
            }
            set {
                depthBits = value;
            }
        }
        #endregion DepthBits

        #region StencilBits
        /// <summary>
        ///     Gets and sets the OpenGL control's stencil buffer depth.
        /// </summary>
        [Category("OpenGL Properties"), Description("Stencil buffer depth in bits.")]
        public byte StencilBits {
            get {
                return stencilBits;
            }
            set {
                stencilBits = value;
            }
        }
        #endregion StencilBits

        #region AutoCheckErrors
        /// <summary>
        ///     Gets and sets the OpenGL control's automatic sending of a glGetError command
        ///     after drawing.
        /// </summary>
        [Category("OpenGL Properties"), Description("Automatically send a glGetError command after drawing?")]
        public bool AutoCheckErrors {
            get {
                return autoCheckErrors;
            }
            set {
                autoCheckErrors = value;
            }
        }
        #endregion AutoCheckErrors

        #region AutoFinish
        /// <summary>
        ///     Gets and sets the OpenGL control's automatic sending of a glFinish command
        ///     after drawing.
        /// </summary>
        [Category("OpenGL Properties"), Description("Automatically send a glFinish command after drawing?")]
        public bool AutoFinish {
            get {
                return autoFinish;
            }
            set {
                autoFinish = value;
            }
        }
        #endregion AutoFinish

        #region AutoMakeCurrent
        /// <summary>
        ///     Gets and sets the OpenGL control's automatic forcing of the rendering context to
        ///     be current before drawing.
        /// </summary>
        [Category("OpenGL Properties"), Description("Automatically make the rendering context current before drawing?")]
        public bool AutoMakeCurrent {
            get {
                return autoMakeCurrent;
            }
            set {
                autoMakeCurrent = value;
            }
        }
        #endregion AutoMakeCurrent

        #region AutoSwapBuffers
        /// <summary>
        ///     Gets and sets the OpenGL control's automatic sending of a SwapBuffers command
        ///     after drawing.
        /// </summary>
        [Category("OpenGL Properties"), Description("Automatically send a SwapBuffers command after drawing?")]
        public bool AutoSwapBuffers {
            get {
                return autoSwapBuffers;
            }
            set {
                autoSwapBuffers = value;
            }
        }
        #endregion AutoSwapBuffers
        #endregion Public Properties

        #region Protected Property Overloads
        #region CreateParams CreateParams
        /// <summary>
        ///     Overrides the control's class style parameters.
        /// </summary>
        protected override CreateParams CreateParams { 
            get {
                Int32 CS_VREDRAW = 0x1;
                Int32 CS_HREDRAW = 0x2;
                Int32 CS_OWNDC = 0x20;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_VREDRAW | CS_HREDRAW | CS_OWNDC;
                return cp;
            }
        }
        #endregion CreateParams CreateParams
        #endregion Protected Property Overloads

        // --- Constructors & Destructors ---
        #region SimpleOpenGlControl()
        /// <summary>
        ///     Constructor.  Creates contexts and sets properties.
        /// </summary>
        public SimpleOpenGlControl() {
            InitializeStyles();
            InitializeComponent();
            InitializeBackground();
        }
        #endregion SimpleOpenGlControl()

        #region Dispose(bool disposing)
        /// <summary>
        ///     Disposes the control.
        /// </summary>
        /// <param name="disposing">Was the disposed manually called?</param>
        protected override void Dispose(bool disposing) {
            if(disposing) {
                if(components != null) {
                    components.Dispose();
                }
            }
            DestroyContexts();
            base.Dispose(disposing);
        }
        #endregion Dispose(bool disposing)

        // --- Private Methods ---
        #region InitializeBackground()
        /// <summary>
        ///     Loads the bitmap from the assembly's manifest resource.
        /// </summary>
        private void InitializeBackground() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using(Stream imageStream = assembly.GetManifestResourceStream("TaoButton.jpg")) {
                this.BackgroundImage = (Image) Bitmap.FromStream(imageStream);
            }
        }
        #endregion InitializeBackground()

        #region InitializeComponent()
        /// <summary>
        ///     Required for designer support.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            // 
            // SimpleOpenGlControl
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Size = new System.Drawing.Size(50, 50);
        }
        #endregion InitializeComponent()

        #region InitializeStyles()
        /// <summary>
        ///     Initializes the control's styles.
        /// </summary>
        private void InitializeStyles() {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, false);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }
        #endregion InitializeStyles()

        // --- Public Methods ---
        #region DestroyContexts()
        public void DestroyContexts() {
            if(renderingContext != IntPtr.Zero) {
                Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                Wgl.wglDeleteContext(renderingContext);
                renderingContext = IntPtr.Zero;
            }

            if(deviceContext != IntPtr.Zero) {
                if(windowHandle != IntPtr.Zero) {
                    User.ReleaseDC(windowHandle, deviceContext);
                }
                deviceContext = IntPtr.Zero;
            }
        }
        #endregion DestroyContexts()

        #region Draw()
        /// <summary>
        ///     Sends an <see cref="UserControl.Invalidate" /> command to this control, thus
        ///     forcing a redraw to occur.
        /// </summary>
        public void Draw() {
            this.Invalidate();
        }
        #endregion Draw()

        #region InitializeContexts()
        /// <summary>
        ///     Creates the OpenGL contexts.
        /// </summary>
        public void InitializeContexts() {
            int pixelFormat;                                                // Holds the selected pixel format

            windowHandle = this.Handle;                                     // Get window handle

            if(windowHandle == IntPtr.Zero) {                               // No window handle means something is wrong
                MessageBox.Show("Window creation error.  No window handle.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            Gdi.PIXELFORMATDESCRIPTOR pfd = new Gdi.PIXELFORMATDESCRIPTOR();// The pixel format descriptor
            pfd.nSize = (short) Marshal.SizeOf(pfd);                        // Size of the pixel format descriptor
            pfd.nVersion = 1;                                               // Version number (always 1)
            pfd.dwFlags = Gdi.PFD_DRAW_TO_WINDOW |                          // Format must support windowed mode
                        Gdi.PFD_SUPPORT_OPENGL |                            // Format must support OpenGL
                        Gdi.PFD_DOUBLEBUFFER;                               // Must support double buffering
            pfd.iPixelType = (byte) Gdi.PFD_TYPE_RGBA;                      // Request an RGBA format
            pfd.cColorBits = (byte) colorBits;                              // Select our color depth
            pfd.cRedBits = 0;                                               // Individual color bits ignored
            pfd.cRedShift = 0;
            pfd.cGreenBits = 0;
            pfd.cGreenShift = 0;
            pfd.cBlueBits = 0;
            pfd.cBlueShift = 0;
            pfd.cAlphaBits = 0;                                             // No alpha buffer
            pfd.cAlphaShift = 0;                                            // Alpha shift bit ignored
            pfd.cAccumBits = accumBits;                                     // Accumulation buffer
            pfd.cAccumRedBits = 0;                                          // Individual accumulation bits ignored
            pfd.cAccumGreenBits = 0;
            pfd.cAccumBlueBits = 0;
            pfd.cAccumAlphaBits = 0;
            pfd.cDepthBits = depthBits;                                     // Z-buffer (depth buffer)
            pfd.cStencilBits = stencilBits;                                 // No stencil buffer
            pfd.cAuxBuffers = 0;                                            // No auxiliary buffer
            pfd.iLayerType = (byte) Gdi.PFD_MAIN_PLANE;                     // Main drawing layer
            pfd.bReserved = 0;                                              // Reserved
            pfd.dwLayerMask = 0;                                            // Layer masks ignored
            pfd.dwVisibleMask = 0;
            pfd.dwDamageMask = 0;

            deviceContext = User.GetDC(windowHandle);                       // Attempt to get the device context
            if(deviceContext == IntPtr.Zero) {                              // Did we not get a device context?
                MessageBox.Show("Can not create a GL device context.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            pixelFormat = Gdi.ChoosePixelFormat(deviceContext, ref pfd);    // Attempt to find an appropriate pixel format
            if(pixelFormat == 0) {                                          // Did windows not find a matching pixel format?
                MessageBox.Show("Can not find a suitable PixelFormat.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            if(!Gdi.SetPixelFormat(deviceContext, pixelFormat, ref pfd)) {  // Are we not able to set the pixel format?
                MessageBox.Show("Can not set the chosen PixelFormat.  Chosen PixelFormat was " + pixelFormat + ".", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            renderingContext = Wgl.wglCreateContext(deviceContext);         // Attempt to get the rendering context
            if(renderingContext == IntPtr.Zero) {                           // Are we not able to get a rendering context?
                MessageBox.Show("Can not create a GL rendering context.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            MakeCurrent();                                                  // Attempt to activate the rendering context

            // Force A Reset On The Working Set Size
            Kernel.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
        }
        #endregion InitializeContexts()

        #region MakeCurrent()
        public void MakeCurrent() {
            // Are we not able to activate the rending context?
            //if(deviceContext == IntPtr.Zero || renderingContext == IntPtr.Zero || !Wgl.wglMakeCurrent(deviceContext, renderingContext)) {
            if(!Wgl.wglMakeCurrent(deviceContext, renderingContext)) {
                MessageBox.Show("Can not activate the GL rendering context.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }
        #endregion MakeCurrent()

        #region SwapBuffers()
        public void SwapBuffers() {
            Gdi.SwapBuffersFast(deviceContext);
        }
        #endregion SwapBuffers()

        // --- Events ---
        #region OnPaint(PaintEventArgs e)
        /// <summary>
        ///     Paints the control.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e) {
            if(this.DesignMode) {
                e.Graphics.Clear(this.BackColor);
                e.Graphics.DrawImage(this.BackgroundImage, this.ClientRectangle, 0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height, GraphicsUnit.Pixel);
                e.Graphics.Flush();
                return;
            }

            if(deviceContext == IntPtr.Zero || renderingContext == IntPtr.Zero) {
                MessageBox.Show("No device or rendering context available!");
                return;
            }

            if(autoMakeCurrent) {
                MakeCurrent();
            }

            base.OnPaint(e);

            if(autoFinish) {
                Gl.glFinish();
            }

            if(autoCheckErrors) {
                errorCode = Gl.glGetError();
                if(errorCode != Gl.GL_NO_ERROR) {
                    switch(errorCode) {
                        case Gl.GL_INVALID_ENUM:
                            MessageBox.Show("GL_INVALID_ENUM - An unacceptable value has been specified for an enumerated argument.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case Gl.GL_INVALID_VALUE:
                            MessageBox.Show("GL_INVALID_VALUE - A numeric argument is out of range.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case Gl.GL_INVALID_OPERATION:
                            MessageBox.Show("GL_INVALID_OPERATION - The specified operation is not allowed in the current state.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case Gl.GL_STACK_OVERFLOW:
                            MessageBox.Show("GL_STACK_OVERFLOW - This function would cause a stack overflow.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case Gl.GL_STACK_UNDERFLOW:
                            MessageBox.Show("GL_STACK_UNDERFLOW - This function would cause a stack underflow.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case Gl.GL_OUT_OF_MEMORY:
                            MessageBox.Show("GL_OUT_OF_MEMORY - There is not enough memory left to execute the function.  The state of OpenGL has been left undefined.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        default:
                            MessageBox.Show("Unknown GL error.  This should never happen.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                    }
                }
            }

            if(autoSwapBuffers) {
                SwapBuffers();
            }
        }
        #endregion OnPaint(PaintEventArgs e)

        #region OnPaintBackground(PaintEventArgs e)
        /// <summary>
        ///     Paints the background.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e) {
        }
        #endregion OnPaintBackground(PaintEventArgs e)
    }
}
