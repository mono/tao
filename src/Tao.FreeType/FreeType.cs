#region License
/*
MIT License
Copyright ©2003-2007 Tao Framework Team
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

// based on http://www.koders.com/csharp/fid840ED1F892217853EE1DD8692B953A84E1D5C2AE.aspx
//
// Amendments are to:
// Init_FreeType, to make the libptr "out"
// New_Face, to make the aface "out"

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security;

namespace Tao.FreeType
{
    #region Class Documentation
    /// <summary>
    ///     FreeType 2 Binding for .NET
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Binds functions and definitions in 
    ///         freetype6.dll (Windows)
    ///         /usr/lib/libfreetype.so.6 (Linux - specifically Fedora Core freetype install location)
    ///         /Library/Frameworks/Mono.framework/Libraries/libfreetype.6.dylib (MacOSX)
    ///     </para>
    ///     <para>
    ///         The FreeType library includes the base data types and function calls to FreeType 2
    ///         to allow access to TrueType and OpenType fonts across platforms.
    ///     </para>
    ///     <para>
    ///         This is not a rendering utility and will not render fonts to the screen. It is an interface
    ///         to the various font formats, and can provide either outline or bitmapped versions
    ///         of font glyphs.
    ///     </para>    
    /// </remarks>
    #endregion Class Documentation

    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryRec_
    {
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /*void*/ user;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /* funcptr */ alloc;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /* funcptr */ free;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /* funcptr */ realloc;
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct StreamRec
    {
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /*byte*/ _base;
        /// <summary>
        /// 
        /// </summary>
        public uint size;
        /// <summary>
        /// 
        /// </summary>
        public uint pos;
        /// <summary>
        /// 
        /// </summary>
        public StreamDesc descriptor;
        /// <summary>
        /// 
        /// </summary>
        public StreamDesc pathname;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /* funcptr */ read;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /* funcptr */ close;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /*MemoryRec_*/ memory;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /*byte*/ cursor;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /*byte*/ limit;
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct StreamDesc
    {
        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public int _value;
        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public IntPtr /*void*/ pointer;
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector
    {
        /// <summary>
        /// 
        /// </summary>
        public int x;
        /// <summary>
        /// 
        /// </summary>
        public int y;
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BBox
    {
        /// <summary>
        /// 
        /// </summary>
        public int xMin;
        /// <summary>
        /// 
        /// </summary>
        public int yMin;
        /// <summary>
        /// 
        /// </summary>
        public int xMax;
        /// <summary>
        /// 
        /// </summary>
        public int yMax;
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Bitmap
    {
        /// <summary>
        /// 
        /// </summary>
        public int rows;
        /// <summary>
        /// 
        /// </summary>
        public int width;
        /// <summary>
        /// 
        /// </summary>
        public int pitch;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /*byte*/ buffer;
        /// <summary>
        /// 
        /// </summary>
        public short num_grays;
        /// <summary>
        /// 
        /// </summary>
        public sbyte pixel_mode;
        /// <summary>
        /// 
        /// </summary>
        public sbyte palette_mode;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /*void*/ palette;
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Outline
    {
        /// <summary>
        /// 
        /// </summary>
        public short n_contours;
        /// <summary>
        /// 
        /// </summary>
        public short n_points;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /*Vector*/ points;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /*sbyte*/ tags;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /*short*/ contours;
        /// <summary>
        /// 
        /// </summary>
        public int flags;
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Outline_Funcs
    {
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /* funcptr */ move_to;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /* funcptr */ line_to;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /* funcptr */ conic_to;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr /* funcptr */ cubic_to;
        /// <summary>
        /// 
        /// </summary>
        public int shift;
        /// <summary>
        /// 
        /// </summary>
        public int delta;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RasterRec_
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Span
    {
        public short x;
        public ushort len;
        public byte coverage;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Raster_Params
    {
        public IntPtr /*Bitmap*/ target;
        public IntPtr /*void*/ source;
        public int flags;
        public IntPtr /* funcptr */ gray_spans;
        public IntPtr /* funcptr */ black_spans;
        public IntPtr /* funcptr */ bit_test;
        public IntPtr /* funcptr */ bit_set;
        public IntPtr /*void*/ user;
        public BBox clip_box;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Raster_Funcs
    {
        public Glyph_Format glyph_format;
        public IntPtr /* funcptr */ raster_new;
        public IntPtr /* funcptr */ raster_reset;
        public IntPtr /* funcptr */ raster_set_mode;
        public IntPtr /* funcptr */ raster_render;
        public IntPtr /* funcptr */ raster_done;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UnitVector
    {
        public short x;
        public short y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix
    {
        public int xx;
        public int xy;
        public int yx;
        public int yy;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Data
    {
        public IntPtr /*byte*/ pointer;
        public int length;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Generic
    {
        public IntPtr /*void*/ data;
        public IntPtr /* funcptr */ finalizer;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ListNodeRec
    {
        public IntPtr /*ListNodeRec*/ prev;
        public IntPtr /*ListNodeRec*/ next;
        public IntPtr /*void*/ data;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ListRec
    {
        public IntPtr /*ListNodeRec*/ head;
        public IntPtr /*ListNodeRec*/ tail;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Glyph_Metrics
    {
        public int width;
        public int height;
        public int horiBearingX;
        public int horiBearingY;
        public int horiAdvance;
        public int vertBearingX;
        public int vertBearingY;
        public int vertAdvance;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Bitmap_Size
    {
        public short height;
        public short width;
        public int size;
        public int x_ppem;
        public int y_ppem;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LibraryRec_
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ModuleRec_
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DriverRec_
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RendererRec_
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FaceRec
    {
        public int num_faces;
        public int face_index;
        public int face_flags;
        public int style_flags;
        public int num_glyphs;
        public IntPtr /*sbyte*/ family_name;
        public IntPtr /*sbyte*/ style_name;
        public int num_fixed_sizes;
        public IntPtr /*Bitmap_Size*/ available_sizes;
        public int num_charmaps;
        public IntPtr /*IntPtr CharMapRec*/ charmaps;
        public Generic generic;
        public BBox bbox;
        public ushort units_per_EM;
        public short ascender;
        public short descender;
        public short height;
        public short max_advance_width;
        public short max_advance_height;
        public short underline_position;
        public short underline_thickness;
        public IntPtr /*GlyphSlotRec*/ glyph;
        public IntPtr /*SizeRec*/ size;
        public IntPtr /*CharMapRec*/ charmap;
        public IntPtr /*DriverRec_*/ driver;
        public IntPtr /*MemoryRec_*/ memory;
        public IntPtr /*StreamRec*/ stream;
        public ListRec sizes_list;
        public Generic autohint;
        public IntPtr /*void*/ extensions;
        public IntPtr /*Face_InternalRec_*/ _internal;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SizeRec
    {
        public IntPtr /*FaceRec*/ face;
        public Generic generic;
        public Size_Metrics metrics;
        public IntPtr /*Size_InternalRec_*/ _internal;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GlyphSlotRec
    {
        public IntPtr /*LibraryRec_*/ library;
        public IntPtr /*FaceRec*/ face;
        public IntPtr /*GlyphSlotRec*/ next;
        public uint reserved;
        public Generic generic;
        public Glyph_Metrics metrics;
        public int linearHoriAdvance;
        public int linearVertAdvance;
        public Vector advance;
        public Glyph_Format format;
        public Bitmap bitmap;
        public int bitmap_left;
        public int bitmap_top;
        public Outline outline;
        public uint num_subglyphs;
        public IntPtr /*SubGlyphRec_*/ subglyphs;
        public IntPtr /*void*/ control_data;
        public int control_len;
        public int lsb_delta;
        public int rsb_delta;
        public IntPtr /*void*/ other;
        public IntPtr /*Slot_InternalRec_*/ _internal;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CharMapRec
    {
        public IntPtr /*FaceRec*/ face;
        public Encoding encoding;
        public ushort platform_id;
        public ushort encoding_id;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Face_InternalRec_
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Size_InternalRec_
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Size_Metrics
    {
        public ushort x_ppem;
        public ushort y_ppem;
        public int x_scale;
        public int y_scale;
        public int ascender;
        public int descender;
        public int height;
        public int max_advance;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SubGlyphRec_
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Slot_InternalRec_
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Parameter
    {
        public uint tag;
        public IntPtr /*void*/ data;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Open_Args
    {
        public uint flags;
        public IntPtr /*byte*/ memory_base;
        public int memory_size;
        public IntPtr /*sbyte*/ pathname;
        public IntPtr /*StreamRec*/ stream;
        public IntPtr /*ModuleRec_*/ driver;
        public int num_params;
        public IntPtr /*Parameter*/ _params;
    }



    public enum Pixel_Mode
    {
        PIXEL_MODE_NONE = 0,
        PIXEL_MODE_MONO,
        PIXEL_MODE_GRAY,
        PIXEL_MODE_GRAY2,
        PIXEL_MODE_GRAY4,
        PIXEL_MODE_LCD,
        PIXEL_MODE_LCD_V,
        PIXEL_MODE_MAX,
    }

    public enum Glyph_Format
    {
        GLYPH_FORMAT_NONE = (int)((uint)0 << 24 | (uint)0 << 16 | (uint)0 << 8 | (uint)0),
        GLYPH_FORMAT_COMPOSITE = (int)((uint)'c' << 24 | (uint)'o' << 16 | (uint)'m' << 8 | (uint)'p'),
        GLYPH_FORMAT_BITMAP = (int)((uint)'b' << 24 | (uint)'i' << 16 | (uint)'t' << 8 | (uint)'s'),
        GLYPH_FORMAT_OUTLINE = (int)((uint)'o' << 24 | (uint)'u' << 16 | (uint)'t' << 8 | (uint)'l'),
        GLYPH_FORMAT_PLOTTER = (int)((uint)'p' << 24 | (uint)'l' << 16 | (uint)'o' << 8 | (uint)'t'),
    }

    public enum Encoding
    {
        ENCODING_NONE = (int)((uint)0 << 24 | (uint)0 << 16 | (uint)0 << 8 | (uint)0),
        ENCODING_MS_SYMBOL = (int)((uint)'s' << 24 | (uint)'y' << 16 | (uint)'m' << 8 | (uint)'b'),
        ENCODING_UNICODE = (int)((uint)'u' << 24 | (uint)'n' << 16 | (uint)'i' << 8 | (uint)'c'),
        ENCODING_SJIS = (int)((uint)'s' << 24 | (uint)'j' << 16 | (uint)'i' << 8 | (uint)'s'),
        ENCODING_GB2312 = (int)((uint)'g' << 24 | (uint)'b' << 16 | (uint)' ' << 8 | (uint)' '),
        ENCODING_BIG5 = (int)((uint)'b' << 24 | (uint)'i' << 16 | (uint)'g' << 8 | (uint)'5'),
        ENCODING_WANSUNG = (int)((uint)'w' << 24 | (uint)'a' << 16 | (uint)'n' << 8 | (uint)'s'),
        ENCODING_JOHAB = (int)((uint)'j' << 24 | (uint)'o' << 16 | (uint)'h' << 8 | (uint)'a'),
        ENCODING_MS_SJIS = (int)(Encoding.ENCODING_SJIS),
        ENCODING_MS_GB2312 = (int)(Encoding.ENCODING_GB2312),
        ENCODING_MS_BIG5 = (int)(Encoding.ENCODING_BIG5),
        ENCODING_MS_WANSUNG = (int)(Encoding.ENCODING_WANSUNG),
        ENCODING_MS_JOHAB = (int)(Encoding.ENCODING_JOHAB),
        ENCODING_ADOBE_STANDARD = (int)((uint)'A' << 24 | (uint)'D' << 16 | (uint)'O' << 8 | (uint)'B'),
        ENCODING_ADOBE_EXPERT = (int)((uint)'A' << 24 | (uint)'D' << 16 | (uint)'B' << 8 | (uint)'E'),
        ENCODING_ADOBE_CUSTOM = (int)((uint)'A' << 24 | (uint)'D' << 16 | (uint)'B' << 8 | (uint)'C'),
        ENCODING_ADOBE_LATIN_1 = (int)((uint)'l' << 24 | (uint)'a' << 16 | (uint)'t' << 8 | (uint)'1'),
        ENCODING_OLD_LATIN_2 = (int)((uint)'l' << 24 | (uint)'a' << 16 | (uint)'t' << 8 | (uint)'2'),
        ENCODING_APPLE_ROMAN = (int)((uint)'a' << 24 | (uint)'r' << 16 | (uint)'m' << 8 | (uint)'n'),
    }

    public enum Render_Mode
    {
        RENDER_MODE_NORMAL = 0,
        RENDER_MODE_LIGHT,
        RENDER_MODE_MONO,
        RENDER_MODE_LCD,
        RENDER_MODE_LCD_V,
        RENDER_MODE_MAX,
    }

    public enum Kerning_Mode
    {
        KERNING_DEFAULT = 0,
        KERNING_UNFITTED,
        KERNING_UNSCALED,
    }

    public class FT
    {

        private const string FT_DLL = "freetype6.dll";
        public static Hashtable ErrorStrings;
        static FT()
        {
            ErrorStrings = new Hashtable();
            ErrorStrings[0x00] = "no error";


            ErrorStrings[0x01] = "cannot open resource";

            ErrorStrings[0x02] = "unknown file format";

            ErrorStrings[0x03] = "broken file";

            ErrorStrings[0x04] = "invalid FreeType version";

            ErrorStrings[0x05] = "module version is too low";

            ErrorStrings[0x06] = "invalid argument";

            ErrorStrings[0x07] = "unimplemented feature";

            ErrorStrings[0x08] = "broken table";

            ErrorStrings[0x09] = "broken offset within table";




            ErrorStrings[0x10] = "invalid glyph index";

            ErrorStrings[0x11] = "invalid character code";

            ErrorStrings[0x12] = "unsupported glyph image format";

            ErrorStrings[0x13] = "cannot render this glyph format";

            ErrorStrings[0x14] = "invalid outline";

            ErrorStrings[0x15] = "invalid composite glyph";

            ErrorStrings[0x16] = "too many hints";

            ErrorStrings[0x17] = "invalid pixel size";




            ErrorStrings[0x20] = "invalid object handle";

            ErrorStrings[0x21] = "invalid library handle";

            ErrorStrings[0x22] = "invalid module handle";

            ErrorStrings[0x23] = "invalid face handle";

            ErrorStrings[0x24] = "invalid size handle";

            ErrorStrings[0x25] = "invalid glyph slot handle";

            ErrorStrings[0x26] = "invalid charmap handle";

            ErrorStrings[0x27] = "invalid cache manager handle";

            ErrorStrings[0x28] = "invalid stream handle";




            ErrorStrings[0x30] = "too many modules";

            ErrorStrings[0x31] = "too many extensions";




            ErrorStrings[0x40] = "out of memory";

            ErrorStrings[0x41] = "unlisted object";




            ErrorStrings[0x51] = "cannot open stream";

            ErrorStrings[0x52] = "invalid stream seek";

            ErrorStrings[0x53] = "invalid stream skip";

            ErrorStrings[0x54] = "invalid stream read";

            ErrorStrings[0x55] = "invalid stream operation";

            ErrorStrings[0x56] = "invalid frame operation";

            ErrorStrings[0x57] = "nested frame access";

            ErrorStrings[0x58] = "invalid frame read";




            ErrorStrings[0x60] = "raster uninitialized";

            ErrorStrings[0x61] = "raster corrupted";

            ErrorStrings[0x62] = "raster overflow";

            ErrorStrings[0x63] = "negative height while rastering";




            ErrorStrings[0x70] = "too many registered caches";




            ErrorStrings[0x80] = "invalid opcode";

            ErrorStrings[0x81] = "too few arguments";

            ErrorStrings[0x82] = "stack overflow";

            ErrorStrings[0x83] = "code overflow";

            ErrorStrings[0x84] = "bad argument";

            ErrorStrings[0x85] = "division by zero";

            ErrorStrings[0x86] = "invalid reference";

            ErrorStrings[0x87] = "found debug opcode";

            ErrorStrings[0x88] = "found ENDF opcode in execution stream";

            ErrorStrings[0x89] = "nested DEFS";

            ErrorStrings[0x8A] = "invalid code range";

            ErrorStrings[0x8B] = "execution context too long";

            ErrorStrings[0x8C] = "too many function definitions";

            ErrorStrings[0x8D] = "too many instruction definitions";

            ErrorStrings[0x8E] = "SFNT font table missing";

            ErrorStrings[0x8F] = "horizontal header (hhea) table missing";

            ErrorStrings[0x90] = "locations (loca) table missing";

            ErrorStrings[0x91] = "name table missing";

            ErrorStrings[0x92] = "character map (cmap) table missing";

            ErrorStrings[0x93] = "horizontal metrics (hmtx) table missing";

            ErrorStrings[0x94] = "PostScript (post) table missing";

            ErrorStrings[0x95] = "invalid horizontal metrics";

            ErrorStrings[0x96] = "invalid character map (cmap) format";

            ErrorStrings[0x97] = "invalid ppem value";

            ErrorStrings[0x98] = "invalid vertical metrics";

            ErrorStrings[0x99] = "could not find context";

            ErrorStrings[0x9A] = "invalid PostScript (post) table format";

            ErrorStrings[0x9B] = "invalid PostScript (post) table";




            ErrorStrings[0xA0] = "opcode syntax error";

            ErrorStrings[0xA1] = "argument stack underflow";

            ErrorStrings[0xA2] = "ignore";




            ErrorStrings[0xB0] = "`STARTFONT' field missing";

            ErrorStrings[0xB1] = "`FONT' field missing";

            ErrorStrings[0xB2] = "`SIZE' field missing";

            ErrorStrings[0xB3] = "`CHARS' field missing";

            ErrorStrings[0xB4] = "`STARTCHAR' field missing";

            ErrorStrings[0xB5] = "`ENCODING' field missing";

            ErrorStrings[0xB6] = "`BBX' field missing";




        }

        public const uint ft_open_driver = 0x8;
        public const uint ft_open_memory = 0x1;
        public const uint ft_open_params = 0x10;
        public const uint ft_open_pathname = 0x4;
        public const uint ft_open_stream = 0x2;
        public const uint ft_outline_even_odd_fill = 0x2;
        public const uint ft_outline_high_precision = 0x100;
        public const uint ft_outline_ignore_dropouts = 0x8;
        public const uint ft_outline_none = 0x0;
        public const uint ft_outline_owner = 0x1;
        public const uint ft_outline_reverse_fill = 0x4;
        public const uint ft_outline_single_pass = 0x200;
        public const uint ft_raster_flag_aa = 0x1;
        public const uint ft_raster_flag_clip = 0x4;
        public const uint ft_raster_flag_default = 0x0;
        public const uint ft_raster_flag_direct = 0x2;
        public const int FREETYPE_MAJOR = 2;
        public const int FREETYPE_MINOR = 1;
        public const int FREETYPE_PATCH = 9;
        public const int ALIGNMENT = 8;
        public const int Curve_Tag_Conic = 0;
        public const int Curve_Tag_Cubic = 2;
        public const int Curve_Tag_On = 1;
        public const int Curve_Tag_Touch_X = 8;
        public const int Curve_Tag_Touch_Y = 16;
        public const int CURVE_TAG_CONIC = 0;
        public const int CURVE_TAG_CUBIC = 2;
        public const int CURVE_TAG_ON = 1;
        public const int CURVE_TAG_TOUCH_X = 8;
        public const int CURVE_TAG_TOUCH_Y = 16;
        public const int LOAD_CROP_BITMAP = 0x40;
        public const int LOAD_DEFAULT = 0x0;
        public const int LOAD_FORCE_AUTOHINT = 0x20;
        public const int LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH = 0x200;
        public const int LOAD_IGNORE_TRANSFORM = 0x800;
        public const int LOAD_LINEAR_DESIGN = 0x2000;
        public const int LOAD_MONOCHROME = 0x1000;
        public const int LOAD_NO_BITMAP = 0x8;
        public const int LOAD_NO_HINTING = 0x2;
        public const int LOAD_NO_RECURSE = 0x400;
        public const int LOAD_NO_SCALE = 0x1;
        public const int LOAD_PEDANTIC = 0x80;
        public const int LOAD_RENDER = 0x4;
        public const int LOAD_SBITS_ONLY = 0x4000;
        public const int LOAD_VERTICAL_LAYOUT = 0x10;
        public const int MAX_MODULES = 32;
        public const uint OPEN_DRIVER = 0x8;
        public const uint OPEN_MEMORY = 0x1;
        public const uint OPEN_PARAMS = 0x10;
        public const uint OPEN_PATHNAME = 0x4;
        public const uint OPEN_STREAM = 0x2;
        public const uint OUTLINE_EVEN_ODD_FILL = 0x2;
        public const uint OUTLINE_HIGH_PRECISION = 0x100;
        public const uint OUTLINE_IGNORE_DROPOUTS = 0x8;
        public const uint OUTLINE_NONE = 0x0;
        public const uint OUTLINE_OWNER = 0x1;
        public const uint OUTLINE_REVERSE_FILL = 0x4;
        public const uint OUTLINE_SINGLE_PASS = 0x200;
        public const uint RASTER_FLAG_AA = 0x1;
        public const uint RASTER_FLAG_CLIP = 0x4;
        public const uint RASTER_FLAG_DEFAULT = 0x0;
        public const uint RASTER_FLAG_DIRECT = 0x2;
        public const int HAVE_FCNTL_H = 1;
        public const int HAVE_UNISTD_H = 1;
        public const int T1_MAX_CHARSTRINGS_OPERANDS = 256;
        public const int T1_MAX_DICT_DEPTH = 5;
        public const int T1_MAX_SUBRS_CALLS = 16;
        public const int Mod_Err_Base = 0;
        public const int Mod_Err_Autohint = 0;
        public const int Mod_Err_BDF = 0;
        public const int Mod_Err_Cache = 0;
        public const int Mod_Err_CFF = 0;
        public const int Mod_Err_CID = 0;
        public const int Mod_Err_Gzip = 0;
        public const int Mod_Err_LZW = 0;
        public const int Mod_Err_PCF = 0;
        public const int Mod_Err_PFR = 0;
        public const int Mod_Err_PSaux = 0;
        public const int Mod_Err_PShinter = 0;
        public const int Mod_Err_PSnames = 0;
        public const int Mod_Err_Raster = 0;
        public const int Mod_Err_SFNT = 0;
        public const int Mod_Err_Smooth = 0;
        public const int Mod_Err_TrueType = 0;
        public const int Mod_Err_Type1 = 0;
        public const int Mod_Err_Type42 = 0;
        public const int Mod_Err_Winfonts = 0;
        public const int Mod_Err_Max = 1;
        public const int Err_Ok = 0x00;
        public const int Err_Cannot_Open_Resource = (int)(0x01 + 0);
        public const int Err_Unknown_File_Format = (int)(0x02 + 0);
        public const int Err_Invalid_File_Format = (int)(0x03 + 0);
        public const int Err_Invalid_Version = (int)(0x04 + 0);
        public const int Err_Lower_Module_Version = (int)(0x05 + 0);
        public const int Err_Invalid_Argument = (int)(0x06 + 0);
        public const int Err_Unimplemented_Feature = (int)(0x07 + 0);
        public const int Err_Invalid_Table = (int)(0x08 + 0);
        public const int Err_Invalid_Offset = (int)(0x09 + 0);
        public const int Err_Invalid_Glyph_Index = (int)(0x10 + 0);
        public const int Err_Invalid_Character_Code = (int)(0x11 + 0);
        public const int Err_Invalid_Glyph_Format = (int)(0x12 + 0);
        public const int Err_Cannot_Render_Glyph = (int)(0x13 + 0);
        public const int Err_Invalid_Outline = (int)(0x14 + 0);
        public const int Err_Invalid_Composite = (int)(0x15 + 0);
        public const int Err_Too_Many_Hints = (int)(0x16 + 0);
        public const int Err_Invalid_Pixel_Size = (int)(0x17 + 0);
        public const int Err_Invalid_Handle = (int)(0x20 + 0);
        public const int Err_Invalid_Library_Handle = (int)(0x21 + 0);
        public const int Err_Invalid_Driver_Handle = (int)(0x22 + 0);
        public const int Err_Invalid_Face_Handle = (int)(0x23 + 0);
        public const int Err_Invalid_Size_Handle = (int)(0x24 + 0);
        public const int Err_Invalid_Slot_Handle = (int)(0x25 + 0);
        public const int Err_Invalid_CharMap_Handle = (int)(0x26 + 0);
        public const int Err_Invalid_Cache_Handle = (int)(0x27 + 0);
        public const int Err_Invalid_Stream_Handle = (int)(0x28 + 0);
        public const int Err_Too_Many_Drivers = (int)(0x30 + 0);
        public const int Err_Too_Many_Extensions = (int)(0x31 + 0);
        public const int Err_Out_Of_Memory = (int)(0x40 + 0);
        public const int Err_Unlisted_Object = (int)(0x41 + 0);
        public const int Err_Cannot_Open_Stream = (int)(0x51 + 0);
        public const int Err_Invalid_Stream_Seek = (int)(0x52 + 0);
        public const int Err_Invalid_Stream_Skip = (int)(0x53 + 0);
        public const int Err_Invalid_Stream_Read = (int)(0x54 + 0);
        public const int Err_Invalid_Stream_Operation = (int)(0x55 + 0);
        public const int Err_Invalid_Frame_Operation = (int)(0x56 + 0);
        public const int Err_Nested_Frame_Access = (int)(0x57 + 0);
        public const int Err_Invalid_Frame_Read = (int)(0x58 + 0);
        public const int Err_Raster_Uninitialized = (int)(0x60 + 0);
        public const int Err_Raster_Corrupted = (int)(0x61 + 0);
        public const int Err_Raster_Overflow = (int)(0x62 + 0);
        public const int Err_Raster_Negative_Height = (int)(0x63 + 0);
        public const int Err_Too_Many_Caches = (int)(0x70 + 0);
        public const int Err_Invalid_Opcode = (int)(0x80 + 0);
        public const int Err_Too_Few_Arguments = (int)(0x81 + 0);
        public const int Err_Stack_Overflow = (int)(0x82 + 0);
        public const int Err_Code_Overflow = (int)(0x83 + 0);
        public const int Err_Bad_Argument = (int)(0x84 + 0);
        public const int Err_Divide_By_Zero = (int)(0x85 + 0);
        public const int Err_Invalid_Reference = (int)(0x86 + 0);
        public const int Err_Debug_OpCode = (int)(0x87 + 0);
        public const int Err_ENDF_In_Exec_Stream = (int)(0x88 + 0);
        public const int Err_Nested_DEFS = (int)(0x89 + 0);
        public const int Err_Invalid_CodeRange = (int)(0x8A + 0);
        public const int Err_Execution_Too_Long = (int)(0x8B + 0);
        public const int Err_Too_Many_Function_Defs = (int)(0x8C + 0);
        public const int Err_Too_Many_Instruction_Defs = (int)(0x8D + 0);
        public const int Err_Table_Missing = (int)(0x8E + 0);
        public const int Err_Horiz_Header_Missing = (int)(0x8F + 0);
        public const int Err_Locations_Missing = (int)(0x90 + 0);
        public const int Err_Name_Table_Missing = (int)(0x91 + 0);
        public const int Err_CMap_Table_Missing = (int)(0x92 + 0);
        public const int Err_Hmtx_Table_Missing = (int)(0x93 + 0);
        public const int Err_Post_Table_Missing = (int)(0x94 + 0);
        public const int Err_Invalid_Horiz_Metrics = (int)(0x95 + 0);
        public const int Err_Invalid_CharMap_Format = (int)(0x96 + 0);
        public const int Err_Invalid_PPem = (int)(0x97 + 0);
        public const int Err_Invalid_Vert_Metrics = (int)(0x98 + 0);
        public const int Err_Could_Not_Find_Context = (int)(0x99 + 0);
        public const int Err_Invalid_Post_Table_Format = (int)(0x9A + 0);
        public const int Err_Invalid_Post_Table = (int)(0x9B + 0);
        public const int Err_Syntax_Error = (int)(0xA0 + 0);
        public const int Err_Stack_Underflow = (int)(0xA1 + 0);
        public const int Err_Ignore = (int)(0xA2 + 0);
        public const int Err_Missing_Startfont_Field = (int)(0xB0 + 0);
        public const int Err_Missing_Font_Field = (int)(0xB1 + 0);
        public const int Err_Missing_Size_Field = (int)(0xB2 + 0);
        public const int Err_Missing_Chars_Field = (int)(0xB3 + 0);
        public const int Err_Missing_Startchar_Field = (int)(0xB4 + 0);
        public const int Err_Missing_Encoding_Field = (int)(0xB5 + 0);
        public const int Err_Missing_Bbx_Field = (int)(0xB6 + 0);

        [DllImport(FT_DLL, EntryPoint = "FT_Init_FreeType"), SuppressUnmanagedCodeSecurity]
        public static extern int Init_FreeType(out IntPtr /*IntPtr LibraryRec_*/ alibrary);

        [DllImport(FT_DLL, EntryPoint = "FT_Library_Version"), SuppressUnmanagedCodeSecurity]
        public static extern void Library_Version(IntPtr /*LibraryRec_*/ library, [In, Out] int[] amajor, [In, Out] int[] aminor, [In, Out] int[] apatch);

        [DllImport(FT_DLL, EntryPoint = "FT_Done_FreeType"), SuppressUnmanagedCodeSecurity]
        public static extern int Done_FreeType(IntPtr /*LibraryRec_*/ library);

        [DllImport(FT_DLL, EntryPoint = "FT_New_Face"), SuppressUnmanagedCodeSecurity]
        public static extern int New_Face(IntPtr /*LibraryRec_*/ library, string filepathname, int face_index, out IntPtr /*IntPtr FaceRec*/ aface);

        [DllImport(FT_DLL, EntryPoint = "FT_New_Memory_Face"), SuppressUnmanagedCodeSecurity]
        public static extern int New_Memory_Face(IntPtr /*LibraryRec_*/ library, [In] byte[] file_base, int file_size, int face_index, IntPtr /*IntPtr FaceRec*/ aface);

        [DllImport(FT_DLL, EntryPoint = "FT_Open_Face"), SuppressUnmanagedCodeSecurity]
        public static extern int Open_Face(IntPtr /*LibraryRec_*/ library, Open_Args args, int face_index, IntPtr /*IntPtr FaceRec*/ aface);

        [DllImport(FT_DLL, EntryPoint = "FT_Attach_File"), SuppressUnmanagedCodeSecurity]
        public static extern int Attach_File(IntPtr /*FaceRec*/ face, string filepathname);

        [DllImport(FT_DLL, EntryPoint = "FT_Attach_Stream"), SuppressUnmanagedCodeSecurity]
        public static extern int Attach_Stream(IntPtr /*FaceRec*/ face, ref Open_Args parameters);

        [DllImport(FT_DLL, EntryPoint = "FT_Done_Face"), SuppressUnmanagedCodeSecurity]
        public static extern int Done_Face(IntPtr /*FaceRec*/ face);

        [DllImport(FT_DLL, EntryPoint = "FT_Set_Char_Size"), SuppressUnmanagedCodeSecurity]
        public static extern int Set_Char_Size(IntPtr /*FaceRec*/ face, int char_width, int char_height, uint horz_resolution, uint vert_resolution);

        [DllImport(FT_DLL, EntryPoint = "FT_Set_Pixel_Sizes"), SuppressUnmanagedCodeSecurity]
        public static extern int Set_Pixel_Sizes(IntPtr /*FaceRec*/ face, uint pixel_width, uint pixel_height);

        [DllImport(FT_DLL, EntryPoint = "FT_Load_Glyph"), SuppressUnmanagedCodeSecurity]
        public static extern int Load_Glyph(IntPtr /*FaceRec*/ face, uint glyph_index, int load_flags);

        [DllImport(FT_DLL, EntryPoint = "FT_Load_Char"), SuppressUnmanagedCodeSecurity]
        public static extern int Load_Char(IntPtr /*FaceRec*/ face, uint char_code, int load_flags);

        [DllImport(FT_DLL, EntryPoint = "FT_Set_Transform"), SuppressUnmanagedCodeSecurity]
        public static extern void Set_Transform(IntPtr /*FaceRec*/ face, ref Matrix matrix, ref Vector delta);

        [DllImport(FT_DLL, EntryPoint = "FT_Render_Glyph"), SuppressUnmanagedCodeSecurity]
        public static extern int Render_Glyph(ref GlyphSlotRec slot, Render_Mode render_mode);

        [DllImport(FT_DLL, EntryPoint = "FT_Get_Kerning"), SuppressUnmanagedCodeSecurity]
        public static extern int Get_Kerning(IntPtr /*FaceRec*/ face, uint left_glyph, uint right_glyph, uint kern_mode, out Vector akerning);

        [DllImport(FT_DLL, EntryPoint = "FT_Get_Glyph_Name"), SuppressUnmanagedCodeSecurity]
        public static extern int Get_Glyph_Name(IntPtr /*FaceRec*/ face, uint glyph_index, IntPtr buffer, uint buffer_max);

        [DllImport(FT_DLL, EntryPoint = "FT_Get_Postscript_Name"), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr /*sbyte*/ Get_Postscript_Name(IntPtr /*FaceRec*/ face);

        [DllImport(FT_DLL, EntryPoint = "FT_Select_Charmap"), SuppressUnmanagedCodeSecurity]
        public static extern int Select_Charmap(IntPtr /*FaceRec*/ face, Encoding encoding);

        [DllImport(FT_DLL, EntryPoint = "FT_Set_Charmap"), SuppressUnmanagedCodeSecurity]
        public static extern int Set_Charmap(IntPtr /*FaceRec*/ face, ref CharMapRec charmap);

        [DllImport(FT_DLL, EntryPoint = "FT_Get_Charmap_Index"), SuppressUnmanagedCodeSecurity]
        public static extern int Get_Charmap_Index(ref CharMapRec charmap);

        [DllImport(FT_DLL, EntryPoint = "FT_Get_Char_Index"), SuppressUnmanagedCodeSecurity]
        public static extern uint Get_Char_Index(IntPtr /*FaceRec*/ face, uint charcode);

        [DllImport(FT_DLL, EntryPoint = "FT_Get_First_Char"), SuppressUnmanagedCodeSecurity]
        public static extern uint Get_First_Char(IntPtr /*FaceRec*/ face, [In, Out] uint[] agindex);

        [DllImport(FT_DLL, EntryPoint = "FT_Get_Next_Char"), SuppressUnmanagedCodeSecurity]
        public static extern uint Get_Next_Char(IntPtr /*FaceRec*/ face, uint char_code, [In, Out] uint[] agindex);

        [DllImport(FT_DLL, EntryPoint = "FT_Get_Name_Index"), SuppressUnmanagedCodeSecurity]
        public static extern uint Get_Name_Index(IntPtr /*FaceRec*/ face, [In, Out] sbyte[] glyph_name);

        [DllImport(FT_DLL, EntryPoint = "FT_MulDiv"), SuppressUnmanagedCodeSecurity]
        public static extern int MulDiv(int a, int b, int c);

        [DllImport(FT_DLL, EntryPoint = "FT_MulFix"), SuppressUnmanagedCodeSecurity]
        public static extern int MulFix(int a, int b);

        [DllImport(FT_DLL, EntryPoint = "FT_DivFix"), SuppressUnmanagedCodeSecurity]
        public static extern int DivFix(int a, int b);

        [DllImport(FT_DLL, EntryPoint = "FT_RoundFix"), SuppressUnmanagedCodeSecurity]
        public static extern int RoundFix(int a);

        [DllImport(FT_DLL, EntryPoint = "FT_CeilFix"), SuppressUnmanagedCodeSecurity]
        public static extern int CeilFix(int a);

        [DllImport(FT_DLL, EntryPoint = "FT_FloorFix"), SuppressUnmanagedCodeSecurity]
        public static extern int FloorFix(int a);

        [DllImport(FT_DLL, EntryPoint = "FT_Vector_Transform"), SuppressUnmanagedCodeSecurity]
        public static extern void Vector_Transform(ref Vector vec, ref Matrix matrix);


    }
}