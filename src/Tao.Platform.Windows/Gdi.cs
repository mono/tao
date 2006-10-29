#region License
/*
MIT License
Copyright ©2003-2006 Tao Framework Team
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
using System.Runtime.InteropServices;
using System.Security;

namespace Tao.Platform.Windows {
    #region Class Documentation
    /// <summary>
    ///     GDI binding for .NET, implementing Windows-specific GDI functionality.
    /// </summary>
    /// <remarks>
    ///     Binds functions and definitions in gdi32.dll.
    /// </remarks>
    #endregion Class Documentation
    public static class Gdi
    {
        // --- Fields ---
        #region Private Constants
        #region string GDI_NATIVE_LIBRARY
        /// <summary>
        ///     Specifies GDI's native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies gdi32.dll for Windows.
        /// </remarks>
        private const string GDI_NATIVE_LIBRARY = "gdi32.dll";
        #endregion string GDI_NATIVE_LIBRARY

        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.StdCall" />.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.StdCall;
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants

        #region Public Constants
        #region LAYERPLANEDESCRIPTOR Pixel Types
        #region int LPD_TYPE_RGBA
        /// <summary>
        ///     RGBA pixels.  Each pixel has four components: red, green, blue, and alpha.
        /// </summary>
        // #define LPD_TYPE_RGBA        0
        public const int LPD_TYPE_RGBA = 0;
        #endregion int LPD_TYPE_RGBA

        #region int LPD_TYPE_COLORINDEX
        /// <summary>
        ///     Color-index pixels.  Each pixel uses a color-index value.
        /// </summary>
        // #define LPD_TYPE_COLORINDEX  1
        public const int LPD_TYPE_COLORINDEX = 1;
        #endregion int LPD_TYPE_COLORINDEX
        #endregion LAYERPLANEDESCRIPTOR Pixel Types

        #region LAYERPLANEDESCRIPTOR Flags
        #region int LPD_DOUBLEBUFFER
        /// <summary>
        ///     The layer plane is double-buffered.  A layer plane can be double-buffered
        ///     even when the main plane is single-buffered and vice versa.
        /// </summary>
        // #define LPD_DOUBLEBUFFER        0x00000001
        public const int LPD_DOUBLEBUFFER = 0x00000001;
        #endregion int LPD_DOUBLEBUFFER

        #region int LPD_STEREO
        /// <summary>
        ///     The layer plane is stereoscopic.  A layer plane can be stereoscopic even
        ///     when the main plane is monoscopic and vice versa.
        /// </summary>
        // #define LPD_STEREO              0x00000002
        public const int LPD_STEREO = 0x00000002;
        #endregion int LPD_STEREO

        #region int LPD_SUPPORT_GDI
        /// <summary>
        ///     The layer plane supports GDI drawing.  The current implementation of OpenGL
        ///     doesn't support this flag.
        /// </summary>
        // #define LPD_SUPPORT_GDI         0x00000010
        public const int LPD_SUPPORT_GDI = 0x00000010;
        #endregion int LPD_SUPPORT_GDI

        #region int LPD_SUPPORT_OPENGL
        /// <summary>
        ///     The layer plane supports OpenGL drawing.
        /// </summary>
        // #define LPD_SUPPORT_OPENGL      0x00000020
        public const int LPD_SUPPORT_OPENGL = 0x00000020;
        #endregion int LPD_SUPPORT_OPENGL

        #region int LPD_SHARE_DEPTH
        /// <summary>
        ///     The layer plane shares the depth buffer with the main plane.
        /// </summary>
        // #define LPD_SHARE_DEPTH         0x00000040
        public const int LPD_SHARE_DEPTH = 0x00000040;
        #endregion int LPD_SHARE_DEPTH

        #region int LPD_SHARE_STENCIL
        /// <summary>
        ///     The layer plane shares the stencil buffer with the main plane.
        /// </summary>
        // #define LPD_SHARE_STENCIL       0x00000080
        public const int LPD_SHARE_STENCIL = 0x00000080;
        #endregion int LPD_SHARE_STENCIL

        #region int LPD_SHARE_ACCUM
        /// <summary>
        ///     The layer plane shares the accumulation buffer with the main plane.
        /// </summary>
        // #define LPD_SHARE_ACCUM         0x00000100
        public const int LPD_SHARE_ACCUM = 0x00000100;
        #endregion int LPD_SHARE_ACCUM

        #region int LPD_SWAP_EXCHANGE
        /// <summary>
        ///     In a double-buffered layer plane, swapping the color buffer exchanges the
        ///     front buffer and back buffer contents.  The back buffer then contains the
        ///     contents of the front buffer before the swap. This flag is a hint only and
        ///     might not be provided by a driver.
        /// </summary>
        // #define LPD_SWAP_EXCHANGE       0x00000200
        public const int LPD_SWAP_EXCHANGE = 0x00000200;
        #endregion int LPD_SWAP_EXCHANGE

        #region int LPD_SWAP_COPY
        /// <summary>
        ///     In a double-buffered layer plane, swapping the color buffer copies the back
        ///     buffer contents to the front buffer.  The swap does not affect the back
        ///     buffer contents. This flag is a hint only and might not be provided by a driver.
        /// </summary>
        // #define LPD_SWAP_COPY           0x00000400
        public const int LPD_SWAP_COPY = 0x00000400;
        #endregion int LPD_SWAP_COPY

        #region int LPD_TRANSPARENT
        /// <summary>
        ///     Contains a transparent color or index value that enables underlying layers
        ///     to show through this layer.  All layer planes, except the lowest-numbered
        ///     underlay layer, have a transparent color or index.
        /// </summary>
        // #define LPD_TRANSPARENT         0x00001000
        public const int LPD_TRANSPARENT = 0x00001000;
        #endregion int LPD_TRANSPARENT
        #endregion LAYERPLANEDESCRIPTOR Flags

        #region PIXELFORMATDESCRIPTOR Pixel Types
        #region int PFD_TYPE_RGBA
        /// <summary>
        ///     RGBA pixels.  Each pixel has four components in this order: red, green, blue,
        ///     and alpha.
        /// </summary>
        // #define PFD_TYPE_RGBA        0
        public const int PFD_TYPE_RGBA = 0;
        #endregion int PFD_TYPE_RGBA

        #region int PFD_TYPE_COLORINDEX
        /// <summary>
        ///     Color-index pixels.  Each pixel uses a color-index value.
        /// </summary>
        // #define PFD_TYPE_COLORINDEX  1
        public const int PFD_TYPE_COLORINDEX = 1;
        #endregion int PFD_TYPE_COLORINDEX
        #endregion PIXELFORMATDESCRIPTOR Pixel Types

        #region PIXELFORMATDESCRIPTOR Layer Types
        #region int PFD_MAIN_PLANE
        /// <summary>
        ///     The layer is the main plane.
        /// </summary>
        // #define PFD_MAIN_PLANE       0
        public const int PFD_MAIN_PLANE = 0;
        #endregion int PFD_MAIN_PLANE

        #region int PFD_OVERLAY_PLANE
        /// <summary>
        ///     The layer is the overlay plane.
        /// </summary>
        // #define PFD_OVERLAY_PLANE    1
        public const int PFD_OVERLAY_PLANE = 1;
        #endregion int PFD_OVERLAY_PLANE

        #region int PFD_UNDERLAY_PLANE
        /// <summary>
        ///     The layer is the underlay plane.
        /// </summary>
        // #define PFD_UNDERLAY_PLANE   (-1)
        public const int PFD_UNDERLAY_PLANE = -1;
        #endregion int PFD_UNDERLAY_PLANE
        #endregion PIXELFORMATDESCRIPTOR Layer Types

        #region PIXELFORMATDESCRIPTOR Flags
        #region int PFD_DOUBLEBUFFER
        /// <summary>
        ///     <para>
        ///         The buffer is double-buffered.  This flag and <see cref="PFD_SUPPORT_GDI" />
        ///         are mutually exclusive in the current generic implementation.
        ///     </para>
        /// </summary>
        // #define PFD_DOUBLEBUFFER            0x00000001
        public const int PFD_DOUBLEBUFFER = 0x00000001;
        #endregion int PFD_DOUBLEBUFFER

        #region int PFD_STEREO
        /// <summary>
        ///     <para>
        ///         The buffer is stereoscopic.  This flag is not supported in the current
        ///         generic implementation.
        ///     </para>
        /// </summary>
        // #define PFD_STEREO                  0x00000002
        public const int PFD_STEREO = 0x00000002;
        #endregion int PFD_STEREO

        #region int PFD_DRAW_TO_WINDOW
        /// <summary>
        ///     <para>
        ///         The buffer can draw to a window or device surface.
        ///     </para>
        /// </summary>
        // #define PFD_DRAW_TO_WINDOW          0x00000004
        public const int PFD_DRAW_TO_WINDOW = 0x00000004;
        #endregion int PFD_DRAW_TO_WINDOW

        #region int PFD_DRAW_TO_BITMAP
        /// <summary>
        ///     <para>
        ///         The buffer can draw to a memory bitmap.
        ///     </para>
        /// </summary>
        // #define PFD_DRAW_TO_BITMAP          0x00000008
        public const int PFD_DRAW_TO_BITMAP = 0x00000008;
        #endregion int PFD_DRAW_TO_BITMAP

        #region int PFD_SUPPORT_GDI
        /// <summary>
        ///     <para>
        ///         The buffer supports GDI drawing.  This flag and
        ///         <see cref="PFD_DOUBLEBUFFER" /> are mutually exclusive in the current generic
        ///         implementation.
        ///     </para>
        /// </summary>
        // #define PFD_SUPPORT_GDI             0x00000010
        public const int PFD_SUPPORT_GDI = 0x00000010;
        #endregion int PFD_SUPPORT_GDI

        #region int PFD_SUPPORT_OPENGL
        /// <summary>
        ///     <para>
        ///         The buffer supports OpenGL drawing.
        ///     </para>
        /// </summary>
        // #define PFD_SUPPORT_OPENGL          0x00000020
        public const int PFD_SUPPORT_OPENGL = 0x00000020;
        #endregion int PFD_SUPPORT_OPENGL

        #region int PFD_GENERIC_FORMAT
        /// <summary>
        ///     <para>
        ///         The pixel format is supported by the GDI software implementation, which is
        ///         also known as the generic implementation.  If this bit is clear, the pixel
        ///         format is supported by a device driver or hardware.
        ///     </para>
        /// </summary>
        // #define PFD_GENERIC_FORMAT          0x00000040
        public const int PFD_GENERIC_FORMAT = 0x00000040;
        #endregion int PFD_GENERIC_FORMAT

        #region int PFD_NEED_PALETTE
        /// <summary>
        ///     <para>
        ///         The buffer uses RGBA pixels on a palette-managed device.  A logical palette
        ///         is required to achieve the best results for this pixel type.  Colors in the
        ///         palette should be specified according to the values of the <b>cRedBits</b>,
        ///         <b>cRedShift</b>, <b>cGreenBits</b>, <b>cGreenShift</b>, <b>cBluebits</b>,
        ///         and <b>cBlueShift</b> members.  The palette should be created and realized in
        ///         the device context before calling <see cref="Wgl.wglMakeCurrent" />.
        ///     </para>
        /// </summary>
        // #define PFD_NEED_PALETTE            0x00000080
        public const int PFD_NEED_PALETTE = 0x00000080;
        #endregion int PFD_NEED_PALETTE

        #region int PFD_NEED_SYSTEM_PALETTE
        /// <summary>
        ///     <para>
        ///         Defined in the pixel format descriptors of hardware that supports one
        ///         hardware palette in 256-color mode only.  For such systems to use
        ///         hardware acceleration, the hardware palette must be in a fixed order
        ///         (for example, 3-3-2) when in RGBA mode or must match the logical palette
        ///         when in color-index mode.
        ///     </para>
        ///     <para>
        ///         When this flag is set, you must call see cref="SetSystemPaletteUse" /> in
        ///         your program to force a one-to-one mapping of the logical palette and the
        ///         system palette.  If your OpenGL hardware supports multiple hardware palettes
        ///         and the device driver can allocate spare hardware palettes for OpenGL, this
        ///         flag is typically clear.
        ///     </para>
        ///     <para>
        ///         This flag is not set in the generic pixel formats.
        ///     </para>
        /// </summary>
        // #define PFD_NEED_SYSTEM_PALETTE     0x00000100
        public const int PFD_NEED_SYSTEM_PALETTE = 0x00000100;
        #endregion int PFD_NEED_SYSTEM_PALETTE

        #region int PFD_SWAP_EXCHANGE
        /// <summary>
        ///     <para>
        ///         Specifies the content of the back buffer in the double-buffered main color
        ///         plane following a buffer swap.  Swapping the color buffers causes the
        ///         exchange of the back buffer's content with the front buffer's content.
        ///         Following the swap, the back buffer's content contains the front buffer's
        ///         content before the swap. <b>PFD_SWAP_EXCHANGE</b> is a hint only and might
        ///         not be provided by a driver.
        ///     </para>
        /// </summary>
        // #define PFD_SWAP_EXCHANGE           0x00000200
        public const int PFD_SWAP_EXCHANGE = 0x00000200;
        #endregion int PFD_SWAP_EXCHANGE

        #region int PFD_SWAP_COPY
        /// <summary>
        ///     <para>
        ///         Specifies the content of the back buffer in the double-buffered main color
        ///         plane following a buffer swap.  Swapping the color buffers causes the content
        ///         of the back buffer to be copied to the front buffer.  The content of the back
        ///         buffer is not affected by the swap.  <b>PFD_SWAP_COPY</b> is a hint only and
        ///         might not be provided by a driver.
        ///     </para>
        /// </summary>
        // #define PFD_SWAP_COPY               0x00000400
        public const int PFD_SWAP_COPY = 0x00000400;
        #endregion int PFD_SWAP_COPY

        #region int PFD_SWAP_LAYER_BUFFERS
        /// <summary>
        ///     <para>
        ///         Indicates whether a device can swap individual layer planes with pixel
        ///         formats that include double-buffered overlay or underlay planes.
        ///         Otherwise all layer planes are swapped together as a group.  When this
        ///         flag is set, <see cref="Wgl.wglSwapLayerBuffers" /> is supported.
        ///     </para>
        /// </summary>
        // #define PFD_SWAP_LAYER_BUFFERS      0x00000800
        public const int PFD_SWAP_LAYER_BUFFERS = 0x00000800;
        #endregion int PFD_SWAP_LAYER_BUFFERS

        #region int PFD_GENERIC_ACCELERATED
        /// <summary>
        ///     <para>
        ///         The pixel format is supported by a device driver that accelerates the generic
        ///         implementation.  If this flag is clear and the
        ///         <see cref="PFD_GENERIC_FORMAT" /> flag is set, the pixel format is supported
        ///         by the generic implementation only.
        ///     </para>
        /// </summary>
        // #define PFD_GENERIC_ACCELERATED     0x00001000
        public const int PFD_GENERIC_ACCELERATED = 0x00001000;
        #endregion int PFD_GENERIC_ACCELERATED

        #region int PFD_SUPPORT_DIRECTDRAW
        /// <summary>
        ///     <para>
        ///         The buffer supports DirectDraw drawing.
        ///     </para>
        /// </summary>
        // #define PFD_SUPPORT_DIRECTDRAW      0x00002000
        public const int PFD_SUPPORT_DIRECTDRAW = 0x00002000;
        #endregion int PFD_SUPPORT_DIRECTDRAW
        #endregion PIXELFORMATDESCRIPTOR Flags

        #region PIXELFORMATDESCRIPTOR Flags For Use In ChoosePixelFormat Only
        #region int PFD_DEPTH_DONTCARE
        /// <summary>
        ///     <para>
        ///         The requested pixel format can either have or not have a depth buffer.  To
        ///         select a pixel format without a depth buffer, you must specify this flag.
        ///         The requested pixel format can be with or without a depth buffer.  Otherwise,
        ///         only pixel formats with a depth buffer are considered.
        ///     </para>
        /// </summary>
        // #define PFD_DEPTH_DONTCARE          0x20000000
        public const int PFD_DEPTH_DONTCARE = 0x20000000;
        #endregion int PFD_DEPTH_DONTCARE

        #region int PFD_DOUBLEBUFFER_DONTCARE
        /// <summary>
        ///     <para>
        ///         The requested pixel format can be either single- or double-buffered.
        ///     </para>
        /// </summary>
        // #define PFD_DOUBLEBUFFER_DONTCARE   0x40000000
        public const int PFD_DOUBLEBUFFER_DONTCARE = 0x40000000;
        #endregion int PFD_DOUBLEBUFFER_DONTCARE

        #region int PFD_STEREO_DONTCARE
        /// <summary>
        ///     <para>
        ///         The requested pixel format can be either monoscopic or stereoscopic.
        ///     </para>
        /// </summary>
        // #define PFD_STEREO_DONTCARE         0x80000000
        public const int PFD_STEREO_DONTCARE = unchecked((int) 0x80000000);
        #endregion int PFD_STEREO_DONTCARE
        #endregion PIXELFORMATDESCRIPTOR Flags For Use In ChoosePixelFormat Only

        /// <summary>
        /// 
        /// </summary>
        public const int DM_BITSPERPEL = 0x00040000;
        /// <summary>
        /// 
        /// </summary>
        public const int DM_PELSWIDTH = 0x00080000;
        /// <summary>
        /// 
        /// </summary>
        public const int DM_PELSHEIGHT = 0x00100000;
        /// <summary>
        /// 
        /// </summary>
        public const int DM_DISPLAYFLAGS = 0x00200000;
        /// <summary>
        /// 
        /// </summary>
        public const int DM_DISPLAYFREQUENCY = 0x00400000;

        /// <summary>
        /// 
        /// </summary>
        // #define OUT_TT_PRECIS 4
        public const int OUT_TT_PRECIS = 4;


        /// <summary>
        /// 
        /// </summary>
        // #define CLIP_DEFAULT_PRECIS 0
        public const int CLIP_DEFAULT_PRECIS = 0;

        /// <summary>
        /// 
        /// </summary>
        // #define DEFAULT_QUALITY 0
        public const int DEFAULT_QUALITY = 0;

        /// <summary>
        /// 
        /// </summary>
        // #define DRAFT_QUALITY 1
        public const int DRAFT_QUALITY = 1;

        /// <summary>
        /// 
        /// </summary>
        // #define PROOF_QUALITY 2
        public const int PROOF_QUALITY = 2;

        /// <summary>
        /// 
        /// </summary>
        // #define NONANTIALIASED_QUALITY 3
        public const int NONANTIALIASED_QUALITY = 3;

        /// <summary>
        /// 
        /// </summary>
        // #define ANTIALIASED_QUALITY 4
        public const int ANTIALIASED_QUALITY = 4;

        /// <summary>
        /// 
        /// </summary>
        // #define CLEARTYPE_QUALITY 5
        public const int CLEARTYPE_QUALITY = 5;

        /// <summary>
        /// 
        /// </summary>
        // #define CLEARTYPE_NATURAL_QUALITY 6
        public const int CLEARTYPE_NATURAL_QUALITY = 6;

        /// <summary>
        /// 
        /// </summary>
        // #define DEFAULT_PITCH 0
        public const int DEFAULT_PITCH = 0;

        /// <summary>
        /// 
        /// </summary>
        // #define FIXED_PITCH 1
        public const int FIXED_PITCH = 1;

        /// <summary>
        /// 
        /// </summary>
        // #define VARIABLE_PITCH 2
        public const int VARIABLE_PITCH = 2;

        /// <summary>
        /// 
        /// </summary>
        // #define MONO_FONT 8
        public const int MONO_FONT = 8;

        /// <summary>
        /// 
        /// </summary>
        // #define ANSI_CHARSET 0
        public const int ANSI_CHARSET = 0;

        /// <summary>
        /// 
        /// </summary>
        // #define DEFAULT_CHARSET 1
        public const int DEFAULT_CHARSET = 1;

        /// <summary>
        /// 
        /// </summary>
        // #define SYMBOL_CHARSET 2
        public const int SYMBOL_CHARSET = 2;

        /// <summary>
        /// 
        /// </summary>
        // #define SHIFTJIS_CHARSET 128
        public const int SHIFTJIS_CHARSET = 128;

        /// <summary>
        /// 
        /// </summary>
        // #define FF_DONTCARE (0<<4)
        public const int FF_DONTCARE = (0 << 4);

        /// <summary>
        /// 
        /// </summary>
        // #define FW_BOLD 700
        public const int FW_BOLD = 700;
        #endregion Public Constants

        // --- Public Structs ---
        #region DEVMODE Struct
        /// <summary>
        ///     <para>
        ///         The <b>DEVMODE</b> data structure contains information about the
        ///         initialization and environment of a printer or a display device.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         A device driver's private data follows the public portion of the
        ///         <b>DEVMODE</b> structure.  The size of the public data can vary for different
        ///         versions of the structure.  The <i>dmSize</i> member specifies the number of
        ///         bytes of public data, and the <i>dmDriverExtra</i> member specifies the
        ///         number of bytes of private data.
        ///     </para>
        /// </remarks>
        /// <seealso cref="User.ChangeDisplaySettings(ref Tao.Platform.Windows.Gdi.DEVMODE, int)" />
        /// <seealso cref="User.EnumDisplaySettings" />
        // <seealso cref="AdvancedDocumentProperties" />
        // <seealso cref="CreateDC" />
        // <seealso cref="CreateIC" />
        // <seealso cref="DeviceCapabilities" />
        // <seealso cref="DocumentProperties" />
        // <seealso cref="OpenPrinter" />
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public struct DEVMODE {
			/// <summary>
			/// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
            public string dmDeviceName;
			/// <summary>
			/// </summary>
            public short dmSpecVersion;
			/// <summary>
			/// </summary>
            public short dmDriverVersion;
			/// <summary>
			/// </summary>
            public short dmSize;
			/// <summary>
			/// </summary>
            public short dmDriverExtra;
			/// <summary>
			/// </summary>
            public int dmFields;
			/// <summary>
			/// 
			/// </summary>
            public short dmOrientation;
			/// <summary>
			/// 
			/// </summary>
            public short dmPaperSize;
			/// <summary>
			/// 
			/// </summary>
            public short dmPaperLength;
			/// <summary>
			/// 
			/// </summary>
            public short dmPaperWidth;
			/// <summary>
			/// 
			/// </summary>
            public short dmScale;
			/// <summary>
			/// 
			/// </summary>
            public short dmCopies;
			/// <summary>
			/// 
			/// </summary>
            public short dmDefaultSource;
			/// <summary>
			/// 
			/// </summary>
            public short dmPrintQuality;
			/// <summary>
			/// 
			/// </summary>
            public short dmColor;
			/// <summary>
			/// 
			/// </summary>
            public short dmDuplex;
			/// <summary>
			/// 
			/// </summary>
            public short dmYResolution;
			/// <summary>
			/// 
			/// </summary>
            public short dmTTOption;
			/// <summary>
			/// 
			/// </summary>
            public short dmCollate;
			/// <summary>
			/// 
			/// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
            public string dmFormName;
			/// <summary>
			/// 
			/// </summary>
            public short dmLogPixels;
			/// <summary>
			/// </summary>
            public int dmBitsPerPel;
			/// <summary>
			/// </summary>
            public int dmPelsWidth;
			/// <summary>
			/// </summary>
            public int dmPelsHeight;
			/// <summary>
			/// </summary>
            public int dmDisplayFlags;
			/// <summary>
			/// 
			/// </summary>
            public int dmDisplayFrequency;
			/// <summary>
			/// </summary>
            public int dmICMMethod;
			/// <summary>
			/// </summary>
            public int dmICMIntent;
			/// <summary>
			/// 
			/// </summary>
            public int dmMediaType;
			/// <summary>
			/// </summary>
            public int dmDitherType;
			/// <summary>
			/// </summary>
            public int dmReserved1;
			/// <summary>
			/// 
			/// </summary>
            public int dmReserved2;
			/// <summary>
			/// </summary>
            public int dmPanningWidth;
			/// <summary>
			/// </summary>
            public int dmPanningHeight;
        }
        #endregion DEVMODE Struct

        #region GLYPHMETRICSFLOAT Struct
        /// <summary>
        /// The <b>GLYPHMETRICSFLOAT</b> structure contains information about the placement and orientation of a glyph in a
        /// character cell.
        /// </summary>
        /// <remarks>The values of <b>GLYPHMETRICSFLOAT</b> are specified as notional units.</remarks>
        /// <seealso cref="POINTFLOAT" />
        /// <seealso cref="Wgl.wglUseFontOutlines" />
        [StructLayout(LayoutKind.Sequential)]
        public struct GLYPHMETRICSFLOAT {
            /// <summary>
            /// Specifies the width of the smallest rectangle (the glyph's black box) that completely encloses the glyph.
            /// </summary>
            public float gmfBlackBoxX;

            /// <summary>
            /// Specifies the height of the smallest rectangle (the glyph's black box) that completely encloses the glyph.
            /// </summary>
            public float gmfBlackBoxY;

            /// <summary>
            /// Specifies the x and y coordinates of the upper-left corner of the smallest rectangle that completely encloses the glyph.
            /// </summary>
            public POINTFLOAT gmfptGlyphOrigin;

            /// <summary>
            /// Specifies the horizontal distance from the origin of the current character cell to the origin of the next character cell.
            /// </summary>
            public float gmfCellIncX;

            /// <summary>
            /// Specifies the vertical distance from the origin of the current character cell to the origin of the next character cell.
            /// </summary>
            public float gmfCellIncY;
        };
        #endregion GLYPHMETRICSFLOAT Struct

        #region PIXELFORMATDESCRIPTOR Struct
        /// <summary>
        ///     The <b>PIXELFORMATDESCRIPTOR</b> structure describes the pixel format of a drawing surface.
        /// </summary>
        /// <remarks>
        ///     Please notice carefully, as documented in the members, that certain pixel format properties are not supported
        ///     in the current generic implementation. The generic implementation is the Microsoft GDI software
        ///     implementation of OpenGL. Hardware manufacturers may enhance parts of OpenGL, and may support some
        ///     pixel format properties not supported by the generic implementation.
        /// </remarks>
        /// <seealso cref="ChoosePixelFormat" />
        /// seealso cref="DescribePixelFormat" />
        /// seealso cref="GetPixelFormat" />
        /// <seealso cref="SetPixelFormat" />
        [StructLayout(LayoutKind.Sequential)]
        public struct PIXELFORMATDESCRIPTOR {
            /// <summary>
            /// Specifies the size of this data structure. This value should be set to <c>sizeof(PIXELFORMATDESCRIPTOR)</c>.
            /// </summary>
            public Int16 nSize;

            /// <summary>
            /// Specifies the version of this data structure. This value should be set to 1.
            /// </summary>
            public Int16 nVersion;

            /// <summary>
            /// A set of bit flags that specify properties of the pixel buffer. The properties are generally not mutually exclusive;
            /// you can set any combination of bit flags, with the exceptions noted.
            /// </summary>
            /// <remarks>
            ///     <para>The following bit flag constants are defined:</para>
            ///     <list type="table">
            ///			<listheader>
            ///				<term>Value</term>
            ///				<description>Meaning</description>
            ///			</listheader>
            ///			<item>
            ///				<term>PFD_DRAW_TO_WINDOW</term>
            ///				<description>The buffer can draw to a window or device surface.</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_DRAW_TO_BITMAP</term>
            ///				<description>The buffer can draw to a memory bitmap.</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_SUPPORT_GDI</term>
            ///				<description>
            ///					The buffer supports GDI drawing. This flag and PFD_DOUBLEBUFFER are mutually exclusive
            ///					in the current generic implementation.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_SUPPORT_OPENGL</term>
            ///				<description>The buffer supports OpenGL drawing.</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_GENERIC_ACCELERATED</term>
            ///				<description>
            ///					The pixel format is supported by a device driver that accelerates the generic implementation.
            ///					If this flag is clear and the PFD_GENERIC_FORMAT flag is set, the pixel format is supported by
            ///					the generic implementation only.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_GENERIC_FORMAT</term>
            ///				<description>
            ///					The pixel format is supported by the GDI software implementation, which is also known as the
            ///					generic implementation. If this bit is clear, the pixel format is supported by a device
            ///					driver or hardware.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_NEED_PALETTE</term>
            ///				<description>
            ///					The buffer uses RGBA pixels on a palette-managed device. A logical palette is required to achieve
            ///					the best results for this pixel type. Colors in the palette should be specified according to the
            ///					values of the <b>cRedBits</b>, <b>cRedShift</b>, <b>cGreenBits</b>, <b>cGreenShift</b>,
            ///					<b>cBluebits</b>, and <b>cBlueShift</b> members. The palette should be created and realized in
            ///					the device context before calling <see cref="Wgl.wglMakeCurrent" />.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_NEED_SYSTEM_PALETTE</term>
            ///				<description>
            ///					Defined in the pixel format descriptors of hardware that supports one hardware palette in
            ///					256-color mode only. For such systems to use hardware acceleration, the hardware palette must be in
            ///					a fixed order (for example, 3-3-2) when in RGBA mode or must match the logical palette when in
            ///					color-index mode.
            ///					
            ///					When this flag is set, you must call SetSystemPaletteUse in your program to force a one-to-one
            ///					mapping of the logical palette and the system palette. If your OpenGL hardware supports multiple
            ///					hardware palettes and the device driver can allocate spare hardware palettes for OpenGL, this
            ///					flag is typically clear.
            ///					
            ///					This flag is not set in the generic pixel formats.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_DOUBLEBUFFER</term>
            ///				<description>
            ///					The buffer is double-buffered. This flag and PFD_SUPPORT_GDI are mutually exclusive in the
            ///					current generic implementation.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_STEREO</term>
            ///				<description>
            ///					The buffer is stereoscopic. This flag is not supported in the current generic implementation.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_SWAP_LAYER_BUFFERS</term>
            ///				<description>
            ///					Indicates whether a device can swap individual layer planes with pixel formats that include
            ///					double-buffered overlay or underlay planes. Otherwise all layer planes are swapped together
            ///					as a group. When this flag is set, <b>wglSwapLayerBuffers</b> is supported.
            ///				</description>
            ///			</item>
            ///		</list>
            ///		<para>You can specify the following bit flags when calling <see cref="ChoosePixelFormat" />.</para>
            ///		<list type="table">
            ///			<listheader>
            ///				<term>Value</term>
            ///				<description>Meaning</description>
            ///			</listheader>
            ///			<item>
            ///				<term>PFD_DEPTH_DONTCARE</term>
            ///				<description>
            ///					The requested pixel format can either have or not have a depth buffer. To select
            ///					a pixel format without a depth buffer, you must specify this flag. The requested pixel format
            ///					can be with or without a depth buffer. Otherwise, only pixel formats with a depth buffer
            ///					are considered.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_DOUBLEBUFFER_DONTCARE</term>
            ///				<description>The requested pixel format can be either single- or double-buffered.</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_STEREO_DONTCARE</term>
            ///				<description>The requested pixel format can be either monoscopic or stereoscopic.</description>
            ///			</item>
            ///		</list>
            ///		<para>
            ///			With the <b>glAddSwapHintRectWIN</b> extension function, two new flags are included for the
            ///			<b>PIXELFORMATDESCRIPTOR</b> pixel format structure.
            ///		</para>
            ///		<list type="table">
            ///			<listheader>
            ///				<term>Value</term>
            ///				<description>Meaning</description>
            ///			</listheader>
            ///			<item>
            ///				<term>PFD_SWAP_COPY</term>
            ///				<description>
            ///					Specifies the content of the back buffer in the double-buffered main color plane following
            ///					a buffer swap. Swapping the color buffers causes the content of the back buffer to be copied
            ///					to the front buffer. The content of the back buffer is not affected by the swap. PFD_SWAP_COPY
            ///					is a hint only and might not be provided by a driver.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_SWAP_EXCHANGE</term>
            ///				<description>
            ///					Specifies the content of the back buffer in the double-buffered main color plane following a
            ///					buffer swap. Swapping the color buffers causes the exchange of the back buffer's content
            ///					with the front buffer's content. Following the swap, the back buffer's content contains the
            ///					front buffer's content before the swap. PFD_SWAP_EXCHANGE is a hint only and might not be
            ///					provided by a driver.
            ///				</description>
            ///			</item>
            ///		</list>
            /// </remarks>
            public Int32 dwFlags;

            /// <summary>
            /// Specifies the type of pixel data. The following types are defined.
            /// </summary>
            /// <remarks>
            ///		<list type="table">
            ///			<listheader>
            ///				<term>Value</term>
            ///				<description>Meaning</description>
            ///			</listheader>
            ///			<item>
            ///				<term>PFD_TYPE_RGBA</term>
            ///				<description>
            ///					RGBA pixels. Each pixel has four components in this order: red, green, blue, and alpha.
            ///				</description>
            ///			</item>
            ///			<item>
            ///				<term>PFD_TYPE_COLORINDEX</term>
            ///				<description>Color-index pixels. Each pixel uses a color-index value.</description>
            ///			</item>
            ///		</list>
            /// </remarks>
            public Byte iPixelType;

            /// <summary>
            /// Specifies the number of color bitplanes in each color buffer. For RGBA pixel types, it is the size
            /// of the color buffer, excluding the alpha bitplanes. For color-index pixels, it is the size of the
            /// color-index buffer.
            /// </summary>
            public Byte cColorBits;

            /// <summary>
            /// Specifies the number of red bitplanes in each RGBA color buffer.
            /// </summary>
            public Byte cRedBits;

            /// <summary>
            /// Specifies the shift count for red bitplanes in each RGBA color buffer.
            /// </summary>
            public Byte cRedShift;

            /// <summary>
            /// Specifies the number of green bitplanes in each RGBA color buffer.
            /// </summary>
            public Byte cGreenBits;

            /// <summary>
            /// Specifies the shift count for green bitplanes in each RGBA color buffer.
            /// </summary>
            public Byte cGreenShift;

            /// <summary>
            /// Specifies the number of blue bitplanes in each RGBA color buffer.
            /// </summary>
            public Byte cBlueBits;

            /// <summary>
            /// Specifies the shift count for blue bitplanes in each RGBA color buffer.
            /// </summary>
            public Byte cBlueShift;

            /// <summary>
            /// Specifies the number of alpha bitplanes in each RGBA color buffer. Alpha bitplanes are not supported.
            /// </summary>
            public Byte cAlphaBits;

            /// <summary>
            /// Specifies the shift count for alpha bitplanes in each RGBA color buffer. Alpha bitplanes are not supported.
            /// </summary>
            public Byte cAlphaShift;

            /// <summary>
            /// Specifies the total number of bitplanes in the accumulation buffer.
            /// </summary>
            public Byte cAccumBits;

            /// <summary>
            /// Specifies the number of red bitplanes in the accumulation buffer.
            /// </summary>
            public Byte cAccumRedBits;

            /// <summary>
            /// Specifies the number of green bitplanes in the accumulation buffer.
            /// </summary>
            public Byte cAccumGreenBits;

            /// <summary>
            /// Specifies the number of blue bitplanes in the accumulation buffer.
            /// </summary>
            public Byte cAccumBlueBits;

            /// <summary>
            /// Specifies the number of alpha bitplanes in the accumulation buffer.
            /// </summary>
            public Byte cAccumAlphaBits;

            /// <summary>
            /// Specifies the depth of the depth (z-axis) buffer.
            /// </summary>
            public Byte cDepthBits;

            /// <summary>
            /// Specifies the depth of the stencil buffer.
            /// </summary>
            public Byte cStencilBits;

            /// <summary>
            /// Specifies the number of auxiliary buffers. Auxiliary buffers are not supported.
            /// </summary>
            public Byte cAuxBuffers;

            /// <summary>
            /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.
            /// </summary>
            /// <remarks>Specifies the type of layer.</remarks>
            public Byte iLayerType;

            /// <summary>
            /// Specifies the number of overlay and underlay planes. Bits 0 through 3 specify up to 15 overlay planes and
            /// bits 4 through 7 specify up to 15 underlay planes.
            /// </summary>
            public Byte bReserved;

            /// <summary>
            /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.
            /// </summary>
            /// <remarks>
            ///		Specifies the layer mask. The layer mask is used in conjunction with the visible mask to determine
            ///		if one layer overlays another.
            /// </remarks>
            public Int32 dwLayerMask;

            /// <summary>
            /// Specifies the transparent color or index of an underlay plane. When the pixel type is RGBA, <b>dwVisibleMask</b>
            /// is a transparent RGB color value. When the pixel type is color index, it is a transparent index value.
            /// </summary>
            public Int32 dwVisibleMask;

            /// <summary>
            /// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used.
            /// </summary>
            /// <remarks>
            ///		Specifies whether more than one pixel format shares the same frame buffer. If the result of the bitwise
            ///		AND of the damage masks between two pixel formats is nonzero, then they share the same buffers.
            /// </remarks>
            public Int32 dwDamageMask;
        };
        #endregion PIXELFORMATDESCRIPTOR Struct

        #region POINTFLOAT Struct
        /// <summary>
        /// The <b>POINTFLOAT</b> structure contains the x and y coordinates of a point.
        /// </summary>
        /// <seealso cref="GLYPHMETRICSFLOAT" />
        [StructLayout(LayoutKind.Sequential)]
        public struct POINTFLOAT {
            /// <summary>
            /// Specifies the horizontal (x) coordinate of a point.
            /// </summary>
            public float X;

            /// <summary>
            /// Specifies the vertical (y) coordinate of a point.
            /// </summary>
            public float Y;
        };
        #endregion POINTFLOAT Struct

        // --- Private Externs ---
        #region bool _SetPixelFormat(IntPtr deviceContext, int pixelFormat, ref PIXELFORMATDESCRIPTOR pixelFormatDescriptor)
        /// <summary>
        /// 
        /// </summary>
        [DllImport(GDI_NATIVE_LIBRARY, EntryPoint="SetPixelFormat", SetLastError=true), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public static extern bool _SetPixelFormat(IntPtr deviceContext, int pixelFormat, ref PIXELFORMATDESCRIPTOR pixelFormatDescriptor);
        #endregion bool _SetPixelFormat(IntPtr deviceContext, int pixelFormat, ref PIXELFORMATDESCRIPTOR pixelFormatDescriptor)

        // --- Public Externs ---
        #region int ChoosePixelFormat(HDC hdc, PIXELFORMATDESCRIPTOR* ppfd)
        /// <summary>
        /// The <b>ChoosePixelFormat</b> function attempts to match an appropriate pixel format supported by a device context
        /// to a given pixel format specification.
        /// </summary>
        /// <param name="deviceContext">
        /// Specifies the device context that the function examines to determine the best match for the pixel format
        /// descriptor pointed to by <i>ppfd</i>.
        /// </param>
        /// <param name="pixelFormatDescriptor">
        /// <para>
        ///		Pointer to a <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure that specifies the requested pixel format.
        ///		In this context, the members of the <b>PIXELFORMATDESCRIPTOR</b> structure that <i>ppfd</i>
        ///		points to are used as follows:
        ///	</para>
        ///	<para>
        ///		<b>nSize</b><br />
        ///		Specifies the size of the <b>PIXELFORMATDESCRIPTOR</b> data structure. Set this member to
        ///		<c>sizeof(PIXELFORMATDESCRIPTOR)</c>.
        ///	</para>
        ///	<para>
        ///		<b>nVersion</b><br />
        ///		Specifies the version number of the <b>PIXELFORMATDESCRIPTOR</b> data structure. Set this member to 1.
        ///	</para>
        ///	<para>
        ///		<b>dwFlags</b><br />
        ///		A set of bit flags that specify properties of the pixel buffer. You can combine the following bit
        ///		flag constants by using bitwise-OR.<br /><br />
        ///		If any of the following flags are set, the <b>ChoosePixelFormat</b> function attempts to match pixel
        ///		formats that also have that flag or flags set. Otherwise, <b>ChoosePixelFormat</b> ignores that flag
        ///		in the pixel formats:<br /><br />
        ///		PFD_DRAW_TO_WINDOW<br />
        ///		PFD_DRAW_TO_BITMAP<br />
        ///		PFD_SUPPORT_GDI<br />
        ///		PFD_SUPPORT_OPENGL<br /><br />
        ///		If any of the following flags are set, <b>ChoosePixelFormat</b> attempts to match pixel formats that
        ///		also have that flag or flags set. Otherwise, it attempts to match pixel formats without that flag set:<br /><br />
        ///		PFD_DOUBLEBUFFER<br />
        ///		PFD_STEREO<br /><br />
        ///		If the following flag is set, the function ignores the PFD_DOUBLEBUFFER flag in the pixel formats:<br /><br />
        ///		PFD_DOUBLEBUFFER_DONTCARE<br /><br />
        ///		If the following flag is set, the function ignores the PFD_STEREO flag in the pixel formats:<br /><br />
        ///		PFD_STEREO_DONTCARE<br />
        ///	</para>
        ///	<para>
        ///		<b>iPixelType</b><br />
        ///		Specifies the type of pixel format for the function to consider:<br /><br />
        ///		PFD_TYPE_RGBA<br />
        ///		PFD_TYPE_COLORINDEX<br />
        ///	</para>
        ///	<para>
        ///		<b>cColorBits</b><br />
        ///		Zero or greater.
        ///	</para>
        ///	<para>
        ///		<b>cRedBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cRedShift</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cGreenBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cGreenShift</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cBlueBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cBlueShift</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cAlphaBits</b><br />
        ///		Zero or greater.
        ///	</para>
        ///	<para>
        ///		<b>cAlphaShift</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cAccumBits</b><br />
        ///		Zero or greater.
        ///	</para>
        ///	<para>
        ///		<b>cAccumRedBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cAccumGreenBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cAccumBlueBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cAccumAlphaBits</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>cDepthBits</b><br />
        ///		Zero or greater.
        ///	</para>
        ///	<para>
        ///		<b>cStencilBits</b><br />
        ///		Zero or greater.
        ///	</para>
        ///	<para>
        ///		<b>cAuxBuffers</b><br />
        ///		Zero or greater.
        ///	</para>
        ///	<para>
        ///		<b>iLayerType</b><br />
        ///		Specifies one of the following layer type values:<br /><br />
        ///		PFD_MAIN_PLANE<br />
        ///		PFD_OVERLAY_PLANE<br />
        ///		PFD_UNDERLAY_PLANE<br />
        ///	</para>
        ///	<para>
        ///		<b>bReserved</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>dwLayerMask</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>dwVisibleMask</b><br />
        ///		Not used.
        ///	</para>
        ///	<para>
        ///		<b>dwDamageMask</b><br />
        ///		Not used.
        ///	</para>
        /// </param>
        /// <returns>
        ///		If the function succeeds, the return value is a pixel format index (one-based) that is the closest match
        ///		to the given pixel format descriptor.<br /><br />
        ///		If the function fails, the return value is zero. To get extended error information,
        ///		call see cref="Kernel.GetLastError" />.
        /// </returns>
        /// <remarks>
        ///		You must ensure that the pixel format matched by the <b>ChoosePixelFormat</b> function satisfies your
        ///		requirements. For example, if you request a pixel format with a 24-bit RGB color buffer but the device
        ///		context offers only 8-bit RGB color buffers, the function returns a pixel format with an 8-bit RGB color
        ///		buffer.<br /><br />
        ///		The following code sample shows how to use <b>ChoosePixelFormat</b> to match a specified pixel
        ///		format:<br /><br />
        ///		<code>
        ///			HDC hdc;
        ///			int pixelFormat;
        ///			Gdi.PIXELFORMATDESCRIPTOR pfd;
        ///
        ///			// size of this pfd
        ///			pfd.nSize = (ushort) sizeof(Gdi.PIXELFORMATDESCRIPTOR);
        ///
        ///			// version number
        ///			pfd.nVersion = 1;
        ///
        ///			// support window, support OpenGL, double buffered
        ///			pfd.dwFlags = Gdi.PFD_DRAW_TO_WINDOW | Gdi.PFD_SUPPORT_OPENGL | Gdi.PFD_DOUBLEBUFFER;
        ///
        ///			// RGBA type
        ///			pfd.iPixelType = Gdi.PFD_TYPE_RGBA;
        ///
        ///			// 24-bit color depth
        ///			pfd.cColorBits = 24;
        ///
        ///			// color bits and shift bits ignored
        ///			pfd.cRedBits = 0;
        ///			pfd.cRedShift = 0;
        ///			pfd.cGreenBits = 0;
        ///			pfd.cGreenShift = 0;
        ///			pfd.cBlueBits = 0;
        ///			pfd.cBlueShift = 0;
        ///			pfd.cAlphaBits = 0;
        ///			pfd.cAlphaShift = 0;
        ///
        ///			// no accumulation buffer, accum bits ignored
        ///			pfd.cAccumBits = 0;
        ///			pfd.cAccumRedBits = 0;
        ///			pfd.cAccumGreenBits = 0;
        ///			pfd.cAccumBlueBits = 0;
        ///			pfd.cAccumAlphaBits = 0;
        ///
        ///			// no stencil buffer
        ///			pfd.cStencilBits = 0;
        ///
        ///			// no auxiliary buffer
        ///			pfd.cAuxBuffers = 0;
        ///
        ///			// main layer
        ///			pfd.iLayerType = Gdi.PFD_MAIN_PLANE;
        ///
        ///			// reserved
        ///			pfd.bReserved = 0;
        ///
        ///			// layer masks ignored
        ///			pfd.dwLayerMask = 0;
        ///			pfd.dwVisibleMask = 0;
        ///			pfd.dwDamageMask = 0;
        ///
        ///			pixelFormat = Gdi.ChoosePixelFormat(hdc, &amp;pfd);
        ///		</code>
        /// </remarks>
        /// seealso cref="DescribePixelFormat" />
        /// seealso cref="GetPixelFormat" />
        /// <seealso cref="SetPixelFormat" />
        [DllImport(GDI_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern int ChoosePixelFormat(IntPtr deviceContext, ref PIXELFORMATDESCRIPTOR pixelFormatDescriptor);
        #endregion int ChoosePixelFormat(HDC hdc, PIXELFORMATDESCRIPTOR* ppfd)

        #region BOOL SetPixelFormat(HDC hdc, int iPixelFormat, PIXELFORMATDESCRIPTOR* ppfd)
        /// <summary>
        /// The <b>SetPixelFormat</b> function sets the pixel format of the specified device context to the format
        /// specified by the <i>iPixelFormat</i> index.
        /// </summary>
        /// <param name="deviceContext">
        ///		Specifies the device context whose pixel format the function attempts to set.
        /// </param>
        /// <param name="pixelFormat">
        ///		Index that identifies the pixel format to set. The various pixel formats supported by a device
        ///		context are identified by one-based indexes.
        /// </param>
        /// <param name="pixelFormatDescriptor">
        ///		Pointer to a <see cref="Gdi.PIXELFORMATDESCRIPTOR" /> structure that contains the logical pixel
        ///		format specification. The system's metafile component uses this structure to record the logical
        ///		pixel format specification. The structure has no other effect upon the behavior of the
        ///		<b>SetPixelFormat</b> function.
        /// </param>
        /// <returns>
        ///		If the function succeeds, the return value is true.<br /><br />
        ///		If the function fails, the return value is false. To get extended error information, call
        ///		see cref="Kernel.GetLastError" />.
        /// </returns>
        /// <remarks>
        ///		If <i>hdc</i> references a window, calling the <b>SetPixelFormat</b> function also changes the pixel format
        ///		of the window. Setting the pixel format of a window more than once can lead to significant complications
        ///		for the Window Manager and for multithread applications, so it is not allowed. An application can only set
        ///		the pixel format of a window one time. Once a window's pixel format is set, it cannot be changed.<br /><br />
        ///
        ///		You should select a pixel format in the device context before calling the <see cref="Wgl.wglCreateContext" />
        ///		function. The <b>wglCreateContext</b> function creates a rendering context for drawing on the device in the
        ///		selected pixel format of the device context.<br /><br />
        ///
        ///		An OpenGL window has its own pixel format. Because of this, only device contexts retrieved for the client
        ///		area of an OpenGL window are allowed to draw into the window. As a result, an OpenGL window should be created
        ///		with the WS_CLIPCHILDREN and WS_CLIPSIBLINGS styles. Additionally, the window class attribute should not
        ///		include the CS_PARENTDC style.<br /><br />
        ///
        ///		The following code example shows <b>SetPixelFormat</b> usage:<br /><br />
        ///
        ///		<code>
        ///			HDC hdc;
        ///			int pixelFormat;
        ///			Gdi.PIXELFORMATDESCRIPTOR pfd;
        ///
        ///			// size of this pfd
        ///			pfd.nSize = (ushort) sizeof(Gdi.PIXELFORMATDESCRIPTOR);
        ///
        ///			// version number
        ///			pfd.nVersion = 1;
        ///
        ///			// support window, support OpenGL, double buffered
        ///			pfd.dwFlags = Gdi.PFD_DRAW_TO_WINDOW | Gdi.PFD_SUPPORT_OPENGL | Gdi.PFD_DOUBLEBUFFER;
        ///
        ///			// RGBA type
        ///			pfd.iPixelType = Gdi.PFD_TYPE_RGBA;
        ///
        ///			// 24-bit color depth
        ///			pfd.cColorBits = 24;
        ///
        ///			// color bits and shift bits ignored
        ///			pfd.cRedBits = 0;
        ///			pfd.cRedShift = 0;
        ///			pfd.cGreenBits = 0;
        ///			pfd.cGreenShift = 0;
        ///			pfd.cBlueBits = 0;
        ///			pfd.cBlueShift = 0;
        ///			pfd.cAlphaBits = 0;
        ///			pfd.cAlphaShift = 0;
        ///
        ///			// no accumulation buffer, accum bits ignored
        ///			pfd.cAccumBits = 0;
        ///			pfd.cAccumRedBits = 0;
        ///			pfd.cAccumGreenBits = 0;
        ///			pfd.cAccumBlueBits = 0;
        ///			pfd.cAccumAlphaBits = 0;
        ///
        ///			// no stencil buffer
        ///			pfd.cStencilBits = 0;
        ///
        ///			// no auxiliary buffer
        ///			pfd.cAuxBuffers = 0;
        ///
        ///			// main layer
        ///			pfd.iLayerType = Gdi.PFD_MAIN_PLANE;
        ///
        ///			// reserved
        ///			pfd.bReserved = 0;
        ///
        ///			// layer masks ignored
        ///			pfd.dwLayerMask = 0;
        ///			pfd.dwVisibleMask = 0;
        ///			pfd.dwDamageMask = 0;
        ///
        ///			pixelFormat = Gdi.ChoosePixelFormat(hdc, &amp;pfd);
        ///			
        ///			// make that the pixel format of the device context
        ///			Gdi.SetPixelFormat(hdc, pixelFormat, &amp;pfd);
        ///		</code>
        /// </remarks>
        /// <seealso cref="ChoosePixelFormat" />
        /// seealso cref="DescribePixelFormat" />
        /// seealso cref="GetPixelFormat" />
        public static bool SetPixelFormat(IntPtr deviceContext, int pixelFormat, ref PIXELFORMATDESCRIPTOR pixelFormatDescriptor) {
            Kernel.LoadLibrary("opengl32.dll");
            return _SetPixelFormat(deviceContext, pixelFormat, ref pixelFormatDescriptor);
        }
        #endregion BOOL SetPixelFormat(HDC hdc, int iPixelFormat, PIXELFORMATDESCRIPTOR* ppfd)

		/// <summary>
		/// 
		/// </summary>
		/// <param name="deviceContext"></param>
		/// <returns></returns>
        [DllImport(GDI_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool SwapBuffers(IntPtr deviceContext);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="deviceContext"></param>
		/// <returns></returns>
        [DllImport(GDI_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="SwapBuffers"), SuppressUnmanagedCodeSecurity]
        public static extern int SwapBuffersFast([In] IntPtr deviceContext);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="height"></param>
		/// <param name="width"></param>
		/// <param name="escapement"></param>
		/// <param name="orientation"></param>
		/// <param name="weight"></param>
		/// <param name="italic"></param>
		/// <param name="underline"></param>
		/// <param name="strikeOut"></param>
		/// <param name="charSet"></param>
		/// <param name="outputPrecision"></param>
		/// <param name="clipPrecision"></param>
		/// <param name="quality"></param>
		/// <param name="pitchAndFamily"></param>
		/// <param name="typeFace"></param>
		/// <returns></returns>
        [DllImport(GDI_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr CreateFont(int height, int width, int escapement, int orientation, int weight, bool italic, bool underline, bool strikeOut, int charSet, int outputPrecision, int clipPrecision, int quality, int pitchAndFamily, string typeFace);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="objectHandle"></param>
		/// <returns></returns>
        [DllImport(GDI_NATIVE_LIBRARY, SetLastError=true), SuppressUnmanagedCodeSecurity]
        public static extern bool DeleteObject(IntPtr objectHandle);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="deviceContext"></param>
		/// <param name="objectHandle"></param>
		/// <returns></returns>
        [DllImport(GDI_NATIVE_LIBRARY), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr SelectObject(IntPtr deviceContext, IntPtr objectHandle);
    }
}
