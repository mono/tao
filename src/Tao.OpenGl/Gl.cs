using System;
using System.Runtime.InteropServices;

namespace Tao.OpenGl
{
    #region Types
    using GLsizeiptrARB = System.IntPtr;
    using GLintptrARB = System.IntPtr;
    using GLhandleARB = System.Int32;
    using GLhalfARB = System.Int16;
    using GLhalfNV = System.Int16;
    using GLcharARB = System.Char;
    using GLsizeiptr = System.IntPtr;
    using GLintptr = System.IntPtr;
    using GLenum = System.Int32;
    using GLboolean = System.Int32;
    using GLbitfield = System.Int32;
    using GLchar = System.Char;
    using GLbyte = System.Byte;
    using GLubyte = System.Byte;
    using GLshort = System.Int16;
    using GLushort = System.Int16;
    using GLint = System.Int32;
    using GLuint = System.Int32;
    using GLsizei = System.Int32;
    using GLfloat = System.Single;
    using GLclampf = System.Single;
    using GLdouble = System.Double;
    using GLclampd = System.Double;
    using GLstring = System.String;
    #endregion

    public static partial class Gl
    {
        #region Constants
        public const GLuint GL_VERSION_1_1 = 1;
        public const GLuint GL_VERSION_1_2 = 1;
        public const GLuint GL_VERSION_1_3 = 1;
        public const GLuint GL_VERSION_1_4 = 1;
        public const GLuint GL_VERSION_1_5 = 1;
        public const GLuint GL_ARB_imaging = 1;
        public const GLuint GL_EXT_abgr = 1;
        public const GLuint GL_EXT_blend_color = 1;
        public const GLuint GL_EXT_blend_logic_op = 1;
        public const GLuint GL_EXT_blend_minmax = 1;
        public const GLuint GL_EXT_blend_subtract = 1;
        public const GLuint GL_EXT_cmyka = 1;
        public const GLuint GL_EXT_convolution = 1;
        public const GLuint GL_EXT_copy_texture = 1;
        public const GLuint GL_EXT_histogram = 1;
        public const GLuint GL_EXT_packed_pixels = 1;
        public const GLuint GL_EXT_point_parameters = 1;
        public const GLuint GL_EXT_polygon_offset = 1;
        public const GLuint GL_EXT_rescale_normal = 1;
        public const GLuint GL_EXT_shared_texture_palette = 1;
        public const GLuint GL_EXT_subtexture = 1;
        public const GLuint GL_EXT_texture = 1;
        public const GLuint GL_EXT_texture3D = 1;
        public const GLuint GL_EXT_texture_object = 1;
        public const GLuint GL_EXT_vertex_array = 1;
        public const GLuint GL_SGIS_detail_texture = 1;
        public const GLuint GL_SGIS_fog_function = 1;
        public const GLuint GL_SGIS_generate_mipmap = 1;
        public const GLuint GL_SGIS_multisample = 1;
        public const GLuint GL_SGIS_pixel_texture = 1;
        public const GLuint GL_SGIS_point_line_texgen = 1;
        public const GLuint GL_SGIS_point_parameters = 1;
        public const GLuint GL_SGIS_sharpen_texture = 1;
        public const GLuint GL_SGIS_texture4D = 1;
        public const GLuint GL_SGIS_texture_border_clamp = 1;
        public const GLuint GL_SGIS_texture_edge_clamp = 1;
        public const GLuint GL_SGIS_texture_filter4 = 1;
        public const GLuint GL_SGIS_texture_lod = 1;
        public const GLuint GL_SGIS_texture_select = 1;
        public const GLuint GL_SGIX_async = 1;
        public const GLuint GL_SGIX_async_histogram = 1;
        public const GLuint GL_SGIX_async_pixel = 1;
        public const GLuint GL_SGIX_blend_alpha_minmax = 1;
        public const GLuint GL_SGIX_calligraphic_fragment = 1;
        public const GLuint GL_SGIX_clipmap = 1;
        public const GLuint GL_SGIX_convolution_accuracy = 1;
        public const GLuint GL_SGIX_depth_texture = 1;
        public const GLuint GL_SGIX_flush_raster = 1;
        public const GLuint GL_SGIX_fog_offset = 1;
        public const GLuint GL_SGIX_fragment_lighting = 1;
        public const GLuint GL_SGIX_framezoom = 1;
        public const GLuint GL_SGIX_icc_texture = 1;
        public const GLuint GL_SGIX_impact_pixel_texture = 1;
        public const GLuint GL_SGIX_instruments = 1;
        public const GLuint GL_SGIX_interlace = 1;
        public const GLuint GL_SGIX_ir_instrument1 = 1;
        public const GLuint GL_SGIX_list_priority = 1;
        public const GLuint GL_SGIX_pixel_texture = 1;
        public const GLuint GL_SGIX_pixel_tiles = 1;
        public const GLuint GL_SGIX_polynomial_ffd = 1;
        public const GLuint GL_SGIX_reference_plane = 1;
        public const GLuint GL_SGIX_resample = 1;
        public const GLuint GL_SGIX_scalebias_hint = 1;
        public const GLuint GL_SGIX_shadow = 1;
        public const GLuint GL_SGIX_shadow_ambient = 1;
        public const GLuint GL_SGIX_sprite = 1;
        public const GLuint GL_SGIX_subsample = 1;
        public const GLuint GL_SGIX_tag_sample_buffer = 1;
        public const GLuint GL_SGIX_texture_add_env = 1;
        public const GLuint GL_SGIX_texture_coordinate_clamp = 1;
        public const GLuint GL_SGIX_texture_lod_bias = 1;
        public const GLuint GL_SGIX_texture_multi_buffer = 1;
        public const GLuint GL_SGIX_texture_scale_bias = 1;
        public const GLuint GL_SGIX_vertex_preclip = 1;
        public const GLuint GL_SGIX_ycrcb = 1;
        public const GLuint GL_SGI_color_matrix = 1;
        public const GLuint GL_SGI_color_table = 1;
        public const GLuint GL_SGI_texture_color_table = 1;
        public const GLuint GL_CURRENT_BIT = 0x00000001;
        public const GLuint GL_POINT_BIT = 0x00000002;
        public const GLuint GL_LINE_BIT = 0x00000004;
        public const GLuint GL_POLYGON_BIT = 0x00000008;
        public const GLuint GL_POLYGON_STIPPLE_BIT = 0x00000010;
        public const GLuint GL_PIXEL_MODE_BIT = 0x00000020;
        public const GLuint GL_LIGHTING_BIT = 0x00000040;
        public const GLuint GL_FOG_BIT = 0x00000080;
        public const GLuint GL_DEPTH_BUFFER_BIT = 0x00000100;
        public const GLuint GL_ACCUM_BUFFER_BIT = 0x00000200;
        public const GLuint GL_STENCIL_BUFFER_BIT = 0x00000400;
        public const GLuint GL_VIEWPORT_BIT = 0x00000800;
        public const GLuint GL_TRANSFORM_BIT = 0x00001000;
        public const GLuint GL_ENABLE_BIT = 0x00002000;
        public const GLuint GL_COLOR_BUFFER_BIT = 0x00004000;
        public const GLuint GL_HINT_BIT = 0x00008000;
        public const GLuint GL_EVAL_BIT = 0x00010000;
        public const GLuint GL_LIST_BIT = 0x00020000;
        public const GLuint GL_TEXTURE_BIT = 0x00040000;
        public const GLuint GL_SCISSOR_BIT = 0x00080000;
        public const GLuint GL_ALL_ATTRIB_BITS = unchecked((int)0xFFFFFFFF);
        public const GLuint GL_CLIENT_PIXEL_STORE_BIT = 0x00000001;
        public const GLuint GL_CLIENT_VERTEX_ARRAY_BIT = 0x00000002;
        public const GLuint GL_CLIENT_ALL_ATTRIB_BITS = unchecked((int)0xFFFFFFFF);
        public const GLuint GL_FALSE = 0;
        public const GLuint GL_TRUE = 1;
        public const GLuint GL_POINTS = 0x0000;
        public const GLuint GL_LINES = 0x0001;
        public const GLuint GL_LINE_LOOP = 0x0002;
        public const GLuint GL_LINE_STRIP = 0x0003;
        public const GLuint GL_TRIANGLES = 0x0004;
        public const GLuint GL_TRIANGLE_STRIP = 0x0005;
        public const GLuint GL_TRIANGLE_FAN = 0x0006;
        public const GLuint GL_QUADS = 0x0007;
        public const GLuint GL_QUAD_STRIP = 0x0008;
        public const GLuint GL_POLYGON = 0x0009;
        public const GLuint GL_ACCUM = 0x0100;
        public const GLuint GL_LOAD = 0x0101;
        public const GLuint GL_RETURN = 0x0102;
        public const GLuint GL_MULT = 0x0103;
        public const GLuint GL_ADD = 0x0104;
        public const GLuint GL_NEVER = 0x0200;
        public const GLuint GL_LESS = 0x0201;
        public const GLuint GL_EQUAL = 0x0202;
        public const GLuint GL_LEQUAL = 0x0203;
        public const GLuint GL_GREATER = 0x0204;
        public const GLuint GL_NOTEQUAL = 0x0205;
        public const GLuint GL_GEQUAL = 0x0206;
        public const GLuint GL_ALWAYS = 0x0207;
        public const GLuint GL_ZERO = 0;
        public const GLuint GL_ONE = 1;
        public const GLuint GL_SRC_COLOR = 0x0300;
        public const GLuint GL_ONE_MINUS_SRC_COLOR = 0x0301;
        public const GLuint GL_SRC_ALPHA = 0x0302;
        public const GLuint GL_ONE_MINUS_SRC_ALPHA = 0x0303;
        public const GLuint GL_DST_ALPHA = 0x0304;
        public const GLuint GL_ONE_MINUS_DST_ALPHA = 0x0305;
        public const GLuint GL_DST_COLOR = 0x0306;
        public const GLuint GL_ONE_MINUS_DST_COLOR = 0x0307;
        public const GLuint GL_SRC_ALPHA_SATURATE = 0x0308;
        public const GLuint GL_NONE = 0;
        public const GLuint GL_FRONT_LEFT = 0x0400;
        public const GLuint GL_FRONT_RIGHT = 0x0401;
        public const GLuint GL_BACK_LEFT = 0x0402;
        public const GLuint GL_BACK_RIGHT = 0x0403;
        public const GLuint GL_FRONT = 0x0404;
        public const GLuint GL_BACK = 0x0405;
        public const GLuint GL_LEFT = 0x0406;
        public const GLuint GL_RIGHT = 0x0407;
        public const GLuint GL_FRONT_AND_BACK = 0x0408;
        public const GLuint GL_AUX0 = 0x0409;
        public const GLuint GL_AUX1 = 0x040A;
        public const GLuint GL_AUX2 = 0x040B;
        public const GLuint GL_AUX3 = 0x040C;
        public const GLuint GL_NO_ERROR = 0;
        public const GLuint GL_INVALID_ENUM = 0x0500;
        public const GLuint GL_INVALID_VALUE = 0x0501;
        public const GLuint GL_INVALID_OPERATION = 0x0502;
        public const GLuint GL_STACK_OVERFLOW = 0x0503;
        public const GLuint GL_STACK_UNDERFLOW = 0x0504;
        public const GLuint GL_OUT_OF_MEMORY = 0x0505;
        public const GLuint GL_2D = 0x0600;
        public const GLuint GL_3D = 0x0601;
        public const GLuint GL_3D_COLOR = 0x0602;
        public const GLuint GL_3D_COLOR_TEXTURE = 0x0603;
        public const GLuint GL_4D_COLOR_TEXTURE = 0x0604;
        public const GLuint GL_PASS_THROUGH_TOKEN = 0x0700;
        public const GLuint GL_POINT_TOKEN = 0x0701;
        public const GLuint GL_LINE_TOKEN = 0x0702;
        public const GLuint GL_POLYGON_TOKEN = 0x0703;
        public const GLuint GL_BITMAP_TOKEN = 0x0704;
        public const GLuint GL_DRAW_PIXEL_TOKEN = 0x0705;
        public const GLuint GL_COPY_PIXEL_TOKEN = 0x0706;
        public const GLuint GL_LINE_RESET_TOKEN = 0x0707;
        public const GLuint GL_TEXTURE_DEFORMATION_BIT_SGIX = 0x00000001;
        public const GLuint GL_GEOMETRY_DEFORMATION_BIT_SGIX = 0x00000002;
        public const GLuint GL_EXP = 0x0800;
        public const GLuint GL_EXP2 = 0x0801;
        public const GLuint GL_CW = 0x0900;
        public const GLuint GL_CCW = 0x0901;
        public const GLuint GL_COEFF = 0x0A00;
        public const GLuint GL_ORDER = 0x0A01;
        public const GLuint GL_DOMAIN = 0x0A02;
        public const GLuint GL_PIXEL_MAP_I_TO_I = 0x0C70;
        public const GLuint GL_PIXEL_MAP_S_TO_S = 0x0C71;
        public const GLuint GL_PIXEL_MAP_I_TO_R = 0x0C72;
        public const GLuint GL_PIXEL_MAP_I_TO_G = 0x0C73;
        public const GLuint GL_PIXEL_MAP_I_TO_B = 0x0C74;
        public const GLuint GL_PIXEL_MAP_I_TO_A = 0x0C75;
        public const GLuint GL_PIXEL_MAP_R_TO_R = 0x0C76;
        public const GLuint GL_PIXEL_MAP_G_TO_G = 0x0C77;
        public const GLuint GL_PIXEL_MAP_B_TO_B = 0x0C78;
        public const GLuint GL_PIXEL_MAP_A_TO_A = 0x0C79;
        public const GLuint GL_VERTEX_ARRAY_POINTER = 0x808E;
        public const GLuint GL_NORMAL_ARRAY_POINTER = 0x808F;
        public const GLuint GL_COLOR_ARRAY_POINTER = 0x8090;
        public const GLuint GL_INDEX_ARRAY_POINTER = 0x8091;
        public const GLuint GL_TEXTURE_COORD_ARRAY_POINTER = 0x8092;
        public const GLuint GL_EDGE_FLAG_ARRAY_POINTER = 0x8093;
        public const GLuint GL_FEEDBACK_BUFFER_POINTER = 0x0DF0;
        public const GLuint GL_SELECTION_BUFFER_POINTER = 0x0DF3;
        public const GLuint GL_CURRENT_COLOR = 0x0B00;
        public const GLuint GL_CURRENT_INDEX = 0x0B01;
        public const GLuint GL_CURRENT_NORMAL = 0x0B02;
        public const GLuint GL_CURRENT_TEXTURE_COORDS = 0x0B03;
        public const GLuint GL_CURRENT_RASTER_COLOR = 0x0B04;
        public const GLuint GL_CURRENT_RASTER_INDEX = 0x0B05;
        public const GLuint GL_CURRENT_RASTER_TEXTURE_COORDS = 0x0B06;
        public const GLuint GL_CURRENT_RASTER_POSITION = 0x0B07;
        public const GLuint GL_CURRENT_RASTER_POSITION_VALID = 0x0B08;
        public const GLuint GL_CURRENT_RASTER_DISTANCE = 0x0B09;
        public const GLuint GL_POINT_SMOOTH = 0x0B10;
        public const GLuint GL_POINT_SIZE = 0x0B11;
        public const GLuint GL_POINT_SIZE_RANGE = 0x0B12;
        public const GLuint GL_POINT_SIZE_GRANULARITY = 0x0B13;
        public const GLuint GL_LINE_SMOOTH = 0x0B20;
        public const GLuint GL_LINE_WIDTH = 0x0B21;
        public const GLuint GL_LINE_WIDTH_RANGE = 0x0B22;
        public const GLuint GL_LINE_WIDTH_GRANULARITY = 0x0B23;
        public const GLuint GL_LINE_STIPPLE = 0x0B24;
        public const GLuint GL_LINE_STIPPLE_PATTERN = 0x0B25;
        public const GLuint GL_LINE_STIPPLE_REPEAT = 0x0B26;
        public const GLuint GL_LIST_MODE = 0x0B30;
        public const GLuint GL_MAX_LIST_NESTING = 0x0B31;
        public const GLuint GL_LIST_BASE = 0x0B32;
        public const GLuint GL_LIST_INDEX = 0x0B33;
        public const GLuint GL_POLYGON_MODE = 0x0B40;
        public const GLuint GL_POLYGON_SMOOTH = 0x0B41;
        public const GLuint GL_POLYGON_STIPPLE = 0x0B42;
        public const GLuint GL_EDGE_FLAG = 0x0B43;
        public const GLuint GL_CULL_FACE = 0x0B44;
        public const GLuint GL_CULL_FACE_MODE = 0x0B45;
        public const GLuint GL_FRONT_FACE = 0x0B46;
        public const GLuint GL_LIGHTING = 0x0B50;
        public const GLuint GL_LIGHT_MODEL_LOCAL_VIEWER = 0x0B51;
        public const GLuint GL_LIGHT_MODEL_TWO_SIDE = 0x0B52;
        public const GLuint GL_LIGHT_MODEL_AMBIENT = 0x0B53;
        public const GLuint GL_SHADE_MODEL = 0x0B54;
        public const GLuint GL_COLOR_MATERIAL_FACE = 0x0B55;
        public const GLuint GL_COLOR_MATERIAL_PARAMETER = 0x0B56;
        public const GLuint GL_COLOR_MATERIAL = 0x0B57;
        public const GLuint GL_FOG = 0x0B60;
        public const GLuint GL_FOG_INDEX = 0x0B61;
        public const GLuint GL_FOG_DENSITY = 0x0B62;
        public const GLuint GL_FOG_START = 0x0B63;
        public const GLuint GL_FOG_END = 0x0B64;
        public const GLuint GL_FOG_MODE = 0x0B65;
        public const GLuint GL_FOG_COLOR = 0x0B66;
        public const GLuint GL_DEPTH_RANGE = 0x0B70;
        public const GLuint GL_DEPTH_TEST = 0x0B71;
        public const GLuint GL_DEPTH_WRITEMASK = 0x0B72;
        public const GLuint GL_DEPTH_CLEAR_VALUE = 0x0B73;
        public const GLuint GL_DEPTH_FUNC = 0x0B74;
        public const GLuint GL_ACCUM_CLEAR_VALUE = 0x0B80;
        public const GLuint GL_STENCIL_TEST = 0x0B90;
        public const GLuint GL_STENCIL_CLEAR_VALUE = 0x0B91;
        public const GLuint GL_STENCIL_FUNC = 0x0B92;
        public const GLuint GL_STENCIL_VALUE_MASK = 0x0B93;
        public const GLuint GL_STENCIL_FAIL = 0x0B94;
        public const GLuint GL_STENCIL_PASS_DEPTH_FAIL = 0x0B95;
        public const GLuint GL_STENCIL_PASS_DEPTH_PASS = 0x0B96;
        public const GLuint GL_STENCIL_REF = 0x0B97;
        public const GLuint GL_STENCIL_WRITEMASK = 0x0B98;
        public const GLuint GL_MATRIX_MODE = 0x0BA0;
        public const GLuint GL_NORMALIZE = 0x0BA1;
        public const GLuint GL_VIEWPORT = 0x0BA2;
        public const GLuint GL_MODELVIEW_STACK_DEPTH = 0x0BA3;
        public const GLuint GL_PROJECTION_STACK_DEPTH = 0x0BA4;
        public const GLuint GL_TEXTURE_STACK_DEPTH = 0x0BA5;
        public const GLuint GL_MODELVIEW_MATRIX = 0x0BA6;
        public const GLuint GL_PROJECTION_MATRIX = 0x0BA7;
        public const GLuint GL_TEXTURE_MATRIX = 0x0BA8;
        public const GLuint GL_ATTRIB_STACK_DEPTH = 0x0BB0;
        public const GLuint GL_CLIENT_ATTRIB_STACK_DEPTH = 0x0BB1;
        public const GLuint GL_ALPHA_TEST = 0x0BC0;
        public const GLuint GL_ALPHA_TEST_FUNC = 0x0BC1;
        public const GLuint GL_ALPHA_TEST_REF = 0x0BC2;
        public const GLuint GL_DITHER = 0x0BD0;
        public const GLuint GL_BLEND_DST = 0x0BE0;
        public const GLuint GL_BLEND_SRC = 0x0BE1;
        public const GLuint GL_BLEND = 0x0BE2;
        public const GLuint GL_LOGIC_OP_MODE = 0x0BF0;
        public const GLuint GL_INDEX_LOGIC_OP = 0x0BF1;
        public const GLuint GL_LOGIC_OP = 0x0BF1;
        public const GLuint GL_COLOR_LOGIC_OP = 0x0BF2;
        public const GLuint GL_AUX_BUFFERS = 0x0C00;
        public const GLuint GL_DRAW_BUFFER = 0x0C01;
        public const GLuint GL_READ_BUFFER = 0x0C02;
        public const GLuint GL_SCISSOR_BOX = 0x0C10;
        public const GLuint GL_SCISSOR_TEST = 0x0C11;
        public const GLuint GL_INDEX_CLEAR_VALUE = 0x0C20;
        public const GLuint GL_INDEX_WRITEMASK = 0x0C21;
        public const GLuint GL_COLOR_CLEAR_VALUE = 0x0C22;
        public const GLuint GL_COLOR_WRITEMASK = 0x0C23;
        public const GLuint GL_INDEX_MODE = 0x0C30;
        public const GLuint GL_RGBA_MODE = 0x0C31;
        public const GLuint GL_DOUBLEBUFFER = 0x0C32;
        public const GLuint GL_STEREO = 0x0C33;
        public const GLuint GL_RENDER_MODE = 0x0C40;
        public const GLuint GL_PERSPECTIVE_CORRECTION_HINT = 0x0C50;
        public const GLuint GL_POINT_SMOOTH_HINT = 0x0C51;
        public const GLuint GL_LINE_SMOOTH_HINT = 0x0C52;
        public const GLuint GL_POLYGON_SMOOTH_HINT = 0x0C53;
        public const GLuint GL_FOG_HINT = 0x0C54;
        public const GLuint GL_TEXTURE_GEN_S = 0x0C60;
        public const GLuint GL_TEXTURE_GEN_T = 0x0C61;
        public const GLuint GL_TEXTURE_GEN_R = 0x0C62;
        public const GLuint GL_TEXTURE_GEN_Q = 0x0C63;
        public const GLuint GL_PIXEL_MAP_I_TO_I_SIZE = 0x0CB0;
        public const GLuint GL_PIXEL_MAP_S_TO_S_SIZE = 0x0CB1;
        public const GLuint GL_PIXEL_MAP_I_TO_R_SIZE = 0x0CB2;
        public const GLuint GL_PIXEL_MAP_I_TO_G_SIZE = 0x0CB3;
        public const GLuint GL_PIXEL_MAP_I_TO_B_SIZE = 0x0CB4;
        public const GLuint GL_PIXEL_MAP_I_TO_A_SIZE = 0x0CB5;
        public const GLuint GL_PIXEL_MAP_R_TO_R_SIZE = 0x0CB6;
        public const GLuint GL_PIXEL_MAP_G_TO_G_SIZE = 0x0CB7;
        public const GLuint GL_PIXEL_MAP_B_TO_B_SIZE = 0x0CB8;
        public const GLuint GL_PIXEL_MAP_A_TO_A_SIZE = 0x0CB9;
        public const GLuint GL_UNPACK_SWAP_BYTES = 0x0CF0;
        public const GLuint GL_UNPACK_LSB_FIRST = 0x0CF1;
        public const GLuint GL_UNPACK_ROW_LENGTH = 0x0CF2;
        public const GLuint GL_UNPACK_SKIP_ROWS = 0x0CF3;
        public const GLuint GL_UNPACK_SKIP_PIXELS = 0x0CF4;
        public const GLuint GL_UNPACK_ALIGNMENT = 0x0CF5;
        public const GLuint GL_PACK_SWAP_BYTES = 0x0D00;
        public const GLuint GL_PACK_LSB_FIRST = 0x0D01;
        public const GLuint GL_PACK_ROW_LENGTH = 0x0D02;
        public const GLuint GL_PACK_SKIP_ROWS = 0x0D03;
        public const GLuint GL_PACK_SKIP_PIXELS = 0x0D04;
        public const GLuint GL_PACK_ALIGNMENT = 0x0D05;
        public const GLuint GL_MAP_COLOR = 0x0D10;
        public const GLuint GL_MAP_STENCIL = 0x0D11;
        public const GLuint GL_INDEX_SHIFT = 0x0D12;
        public const GLuint GL_INDEX_OFFSET = 0x0D13;
        public const GLuint GL_RED_SCALE = 0x0D14;
        public const GLuint GL_RED_BIAS = 0x0D15;
        public const GLuint GL_ZOOM_X = 0x0D16;
        public const GLuint GL_ZOOM_Y = 0x0D17;
        public const GLuint GL_GREEN_SCALE = 0x0D18;
        public const GLuint GL_GREEN_BIAS = 0x0D19;
        public const GLuint GL_BLUE_SCALE = 0x0D1A;
        public const GLuint GL_BLUE_BIAS = 0x0D1B;
        public const GLuint GL_ALPHA_SCALE = 0x0D1C;
        public const GLuint GL_ALPHA_BIAS = 0x0D1D;
        public const GLuint GL_DEPTH_SCALE = 0x0D1E;
        public const GLuint GL_DEPTH_BIAS = 0x0D1F;
        public const GLuint GL_MAX_EVAL_ORDER = 0x0D30;
        public const GLuint GL_MAX_LIGHTS = 0x0D31;
        public const GLuint GL_MAX_CLIP_PLANES = 0x0D32;
        public const GLuint GL_MAX_TEXTURE_SIZE = 0x0D33;
        public const GLuint GL_MAX_PIXEL_MAP_TABLE = 0x0D34;
        public const GLuint GL_MAX_ATTRIB_STACK_DEPTH = 0x0D35;
        public const GLuint GL_MAX_MODELVIEW_STACK_DEPTH = 0x0D36;
        public const GLuint GL_MAX_NAME_STACK_DEPTH = 0x0D37;
        public const GLuint GL_MAX_PROJECTION_STACK_DEPTH = 0x0D38;
        public const GLuint GL_MAX_TEXTURE_STACK_DEPTH = 0x0D39;
        public const GLuint GL_MAX_VIEWPORT_DIMS = 0x0D3A;
        public const GLuint GL_MAX_CLIENT_ATTRIB_STACK_DEPTH = 0x0D3B;
        public const GLuint GL_SUBPIXEL_BITS = 0x0D50;
        public const GLuint GL_INDEX_BITS = 0x0D51;
        public const GLuint GL_RED_BITS = 0x0D52;
        public const GLuint GL_GREEN_BITS = 0x0D53;
        public const GLuint GL_BLUE_BITS = 0x0D54;
        public const GLuint GL_ALPHA_BITS = 0x0D55;
        public const GLuint GL_DEPTH_BITS = 0x0D56;
        public const GLuint GL_STENCIL_BITS = 0x0D57;
        public const GLuint GL_ACCUM_RED_BITS = 0x0D58;
        public const GLuint GL_ACCUM_GREEN_BITS = 0x0D59;
        public const GLuint GL_ACCUM_BLUE_BITS = 0x0D5A;
        public const GLuint GL_ACCUM_ALPHA_BITS = 0x0D5B;
        public const GLuint GL_NAME_STACK_DEPTH = 0x0D70;
        public const GLuint GL_AUTO_NORMAL = 0x0D80;
        public const GLuint GL_MAP1_COLOR_4 = 0x0D90;
        public const GLuint GL_MAP1_INDEX = 0x0D91;
        public const GLuint GL_MAP1_NORMAL = 0x0D92;
        public const GLuint GL_MAP1_TEXTURE_COORD_1 = 0x0D93;
        public const GLuint GL_MAP1_TEXTURE_COORD_2 = 0x0D94;
        public const GLuint GL_MAP1_TEXTURE_COORD_3 = 0x0D95;
        public const GLuint GL_MAP1_TEXTURE_COORD_4 = 0x0D96;
        public const GLuint GL_MAP1_VERTEX_3 = 0x0D97;
        public const GLuint GL_MAP1_VERTEX_4 = 0x0D98;
        public const GLuint GL_MAP2_COLOR_4 = 0x0DB0;
        public const GLuint GL_MAP2_INDEX = 0x0DB1;
        public const GLuint GL_MAP2_NORMAL = 0x0DB2;
        public const GLuint GL_MAP2_TEXTURE_COORD_1 = 0x0DB3;
        public const GLuint GL_MAP2_TEXTURE_COORD_2 = 0x0DB4;
        public const GLuint GL_MAP2_TEXTURE_COORD_3 = 0x0DB5;
        public const GLuint GL_MAP2_TEXTURE_COORD_4 = 0x0DB6;
        public const GLuint GL_MAP2_VERTEX_3 = 0x0DB7;
        public const GLuint GL_MAP2_VERTEX_4 = 0x0DB8;
        public const GLuint GL_MAP1_GRID_DOMAIN = 0x0DD0;
        public const GLuint GL_MAP1_GRID_SEGMENTS = 0x0DD1;
        public const GLuint GL_MAP2_GRID_DOMAIN = 0x0DD2;
        public const GLuint GL_MAP2_GRID_SEGMENTS = 0x0DD3;
        public const GLuint GL_TEXTURE_1D = 0x0DE0;
        public const GLuint GL_TEXTURE_2D = 0x0DE1;
        public const GLuint GL_FEEDBACK_BUFFER_SIZE = 0x0DF1;
        public const GLuint GL_FEEDBACK_BUFFER_TYPE = 0x0DF2;
        public const GLuint GL_SELECTION_BUFFER_SIZE = 0x0DF4;
        public const GLuint GL_POLYGON_OFFSET_UNITS = 0x2A00;
        public const GLuint GL_POLYGON_OFFSET_POINT = 0x2A01;
        public const GLuint GL_POLYGON_OFFSET_LINE = 0x2A02;
        public const GLuint GL_POLYGON_OFFSET_FILL = 0x8037;
        public const GLuint GL_POLYGON_OFFSET_FACTOR = 0x8038;
        public const GLuint GL_TEXTURE_BINDING_1D = 0x8068;
        public const GLuint GL_TEXTURE_BINDING_2D = 0x8069;
        public const GLuint GL_TEXTURE_BINDING_3D = 0x806A;
        public const GLuint GL_VERTEX_ARRAY = 0x8074;
        public const GLuint GL_NORMAL_ARRAY = 0x8075;
        public const GLuint GL_COLOR_ARRAY = 0x8076;
        public const GLuint GL_INDEX_ARRAY = 0x8077;
        public const GLuint GL_TEXTURE_COORD_ARRAY = 0x8078;
        public const GLuint GL_EDGE_FLAG_ARRAY = 0x8079;
        public const GLuint GL_VERTEX_ARRAY_SIZE = 0x807A;
        public const GLuint GL_VERTEX_ARRAY_TYPE = 0x807B;
        public const GLuint GL_VERTEX_ARRAY_STRIDE = 0x807C;
        public const GLuint GL_NORMAL_ARRAY_TYPE = 0x807E;
        public const GLuint GL_NORMAL_ARRAY_STRIDE = 0x807F;
        public const GLuint GL_COLOR_ARRAY_SIZE = 0x8081;
        public const GLuint GL_COLOR_ARRAY_TYPE = 0x8082;
        public const GLuint GL_COLOR_ARRAY_STRIDE = 0x8083;
        public const GLuint GL_INDEX_ARRAY_TYPE = 0x8085;
        public const GLuint GL_INDEX_ARRAY_STRIDE = 0x8086;
        public const GLuint GL_TEXTURE_COORD_ARRAY_SIZE = 0x8088;
        public const GLuint GL_TEXTURE_COORD_ARRAY_TYPE = 0x8089;
        public const GLuint GL_TEXTURE_COORD_ARRAY_STRIDE = 0x808A;
        public const GLuint GL_EDGE_FLAG_ARRAY_STRIDE = 0x808C;
        public const GLuint GL_TEXTURE_WIDTH = 0x1000;
        public const GLuint GL_TEXTURE_HEIGHT = 0x1001;
        public const GLuint GL_TEXTURE_INTERNAL_FORMAT = 0x1003;
        public const GLuint GL_TEXTURE_COMPONENTS = 0x1003;
        public const GLuint GL_TEXTURE_BORDER_COLOR = 0x1004;
        public const GLuint GL_TEXTURE_BORDER = 0x1005;
        public const GLuint GL_TEXTURE_RED_SIZE = 0x805C;
        public const GLuint GL_TEXTURE_GREEN_SIZE = 0x805D;
        public const GLuint GL_TEXTURE_BLUE_SIZE = 0x805E;
        public const GLuint GL_TEXTURE_ALPHA_SIZE = 0x805F;
        public const GLuint GL_TEXTURE_LUMINANCE_SIZE = 0x8060;
        public const GLuint GL_TEXTURE_INTENSITY_SIZE = 0x8061;
        public const GLuint GL_TEXTURE_PRIORITY = 0x8066;
        public const GLuint GL_TEXTURE_RESIDENT = 0x8067;
        public const GLuint GL_DONT_CARE = 0x1100;
        public const GLuint GL_FASTEST = 0x1101;
        public const GLuint GL_NICEST = 0x1102;
        public const GLuint GL_AMBIENT = 0x1200;
        public const GLuint GL_DIFFUSE = 0x1201;
        public const GLuint GL_SPECULAR = 0x1202;
        public const GLuint GL_POSITION = 0x1203;
        public const GLuint GL_SPOT_DIRECTION = 0x1204;
        public const GLuint GL_SPOT_EXPONENT = 0x1205;
        public const GLuint GL_SPOT_CUTOFF = 0x1206;
        public const GLuint GL_CONSTANT_ATTENUATION = 0x1207;
        public const GLuint GL_LINEAR_ATTENUATION = 0x1208;
        public const GLuint GL_QUADRATIC_ATTENUATION = 0x1209;
        public const GLuint GL_COMPILE = 0x1300;
        public const GLuint GL_COMPILE_AND_EXECUTE = 0x1301;
        public const GLuint GL_BYTE = 0x1400;
        public const GLuint GL_UNSIGNED_BYTE = 0x1401;
        public const GLuint GL_SHORT = 0x1402;
        public const GLuint GL_UNSIGNED_SHORT = 0x1403;
        public const GLuint GL_INT = 0x1404;
        public const GLuint GL_UNSIGNED_INT = 0x1405;
        public const GLuint GL_FLOAT = 0x1406;
        public const GLuint GL_2_BYTES = 0x1407;
        public const GLuint GL_3_BYTES = 0x1408;
        public const GLuint GL_4_BYTES = 0x1409;
        public const GLuint GL_DOUBLE = 0x140A;
        public const GLuint GL_DOUBLE_EXT = 0x140A;
        public const GLuint GL_CLEAR = 0x1500;
        public const GLuint GL_AND = 0x1501;
        public const GLuint GL_AND_REVERSE = 0x1502;
        public const GLuint GL_COPY = 0x1503;
        public const GLuint GL_AND_INVERTED = 0x1504;
        public const GLuint GL_NOOP = 0x1505;
        public const GLuint GL_XOR = 0x1506;
        public const GLuint GL_OR = 0x1507;
        public const GLuint GL_NOR = 0x1508;
        public const GLuint GL_EQUIV = 0x1509;
        public const GLuint GL_INVERT = 0x150A;
        public const GLuint GL_OR_REVERSE = 0x150B;
        public const GLuint GL_COPY_INVERTED = 0x150C;
        public const GLuint GL_OR_INVERTED = 0x150D;
        public const GLuint GL_NAND = 0x150E;
        public const GLuint GL_SET = 0x150F;
        public const GLuint GL_EMISSION = 0x1600;
        public const GLuint GL_SHININESS = 0x1601;
        public const GLuint GL_AMBIENT_AND_DIFFUSE = 0x1602;
        public const GLuint GL_COLOR_INDEXES = 0x1603;
        public const GLuint GL_MODELVIEW = 0x1700;
        public const GLuint GL_PROJECTION = 0x1701;
        public const GLuint GL_TEXTURE = 0x1702;
        public const GLuint GL_COLOR = 0x1800;
        public const GLuint GL_DEPTH = 0x1801;
        public const GLuint GL_STENCIL = 0x1802;
        public const GLuint GL_COLOR_INDEX = 0x1900;
        public const GLuint GL_STENCIL_INDEX = 0x1901;
        public const GLuint GL_DEPTH_COMPONENT = 0x1902;
        public const GLuint GL_RED = 0x1903;
        public const GLuint GL_GREEN = 0x1904;
        public const GLuint GL_BLUE = 0x1905;
        public const GLuint GL_ALPHA = 0x1906;
        public const GLuint GL_RGB = 0x1907;
        public const GLuint GL_RGBA = 0x1908;
        public const GLuint GL_LUMINANCE = 0x1909;
        public const GLuint GL_LUMINANCE_ALPHA = 0x190A;
        public const GLuint GL_BITMAP = 0x1A00;
        public const GLuint GL_POINT = 0x1B00;
        public const GLuint GL_LINE = 0x1B01;
        public const GLuint GL_FILL = 0x1B02;
        public const GLuint GL_RENDER = 0x1C00;
        public const GLuint GL_FEEDBACK = 0x1C01;
        public const GLuint GL_SELECT = 0x1C02;
        public const GLuint GL_FLAT = 0x1D00;
        public const GLuint GL_SMOOTH = 0x1D01;
        public const GLuint GL_KEEP = 0x1E00;
        public const GLuint GL_REPLACE = 0x1E01;
        public const GLuint GL_INCR = 0x1E02;
        public const GLuint GL_DECR = 0x1E03;
        public const GLuint GL_VENDOR = 0x1F00;
        public const GLuint GL_RENDERER = 0x1F01;
        public const GLuint GL_VERSION = 0x1F02;
        public const GLuint GL_EXTENSIONS = 0x1F03;
        public const GLuint GL_S = 0x2000;
        public const GLuint GL_T = 0x2001;
        public const GLuint GL_R = 0x2002;
        public const GLuint GL_Q = 0x2003;
        public const GLuint GL_MODULATE = 0x2100;
        public const GLuint GL_DECAL = 0x2101;
        public const GLuint GL_TEXTURE_ENV_MODE = 0x2200;
        public const GLuint GL_TEXTURE_ENV_COLOR = 0x2201;
        public const GLuint GL_TEXTURE_ENV = 0x2300;
        public const GLuint GL_EYE_LINEAR = 0x2400;
        public const GLuint GL_OBJECT_LINEAR = 0x2401;
        public const GLuint GL_SPHERE_MAP = 0x2402;
        public const GLuint GL_TEXTURE_GEN_MODE = 0x2500;
        public const GLuint GL_OBJECT_PLANE = 0x2501;
        public const GLuint GL_EYE_PLANE = 0x2502;
        public const GLuint GL_NEAREST = 0x2600;
        public const GLuint GL_LINEAR = 0x2601;
        public const GLuint GL_NEAREST_MIPMAP_NEAREST = 0x2700;
        public const GLuint GL_LINEAR_MIPMAP_NEAREST = 0x2701;
        public const GLuint GL_NEAREST_MIPMAP_LINEAR = 0x2702;
        public const GLuint GL_LINEAR_MIPMAP_LINEAR = 0x2703;
        public const GLuint GL_TEXTURE_MAG_FILTER = 0x2800;
        public const GLuint GL_TEXTURE_MIN_FILTER = 0x2801;
        public const GLuint GL_TEXTURE_WRAP_S = 0x2802;
        public const GLuint GL_TEXTURE_WRAP_T = 0x2803;
        public const GLuint GL_PROXY_TEXTURE_1D = 0x8063;
        public const GLuint GL_PROXY_TEXTURE_2D = 0x8064;
        public const GLuint GL_CLAMP = 0x2900;
        public const GLuint GL_REPEAT = 0x2901;
        public const GLuint GL_R3_G3_B2 = 0x2A10;
        public const GLuint GL_ALPHA4 = 0x803B;
        public const GLuint GL_ALPHA8 = 0x803C;
        public const GLuint GL_ALPHA12 = 0x803D;
        public const GLuint GL_ALPHA16 = 0x803E;
        public const GLuint GL_LUMINANCE4 = 0x803F;
        public const GLuint GL_LUMINANCE8 = 0x8040;
        public const GLuint GL_LUMINANCE12 = 0x8041;
        public const GLuint GL_LUMINANCE16 = 0x8042;
        public const GLuint GL_LUMINANCE4_ALPHA4 = 0x8043;
        public const GLuint GL_LUMINANCE6_ALPHA2 = 0x8044;
        public const GLuint GL_LUMINANCE8_ALPHA8 = 0x8045;
        public const GLuint GL_LUMINANCE12_ALPHA4 = 0x8046;
        public const GLuint GL_LUMINANCE12_ALPHA12 = 0x8047;
        public const GLuint GL_LUMINANCE16_ALPHA16 = 0x8048;
        public const GLuint GL_INTENSITY = 0x8049;
        public const GLuint GL_INTENSITY4 = 0x804A;
        public const GLuint GL_INTENSITY8 = 0x804B;
        public const GLuint GL_INTENSITY12 = 0x804C;
        public const GLuint GL_INTENSITY16 = 0x804D;
        public const GLuint GL_RGB4 = 0x804F;
        public const GLuint GL_RGB5 = 0x8050;
        public const GLuint GL_RGB8 = 0x8051;
        public const GLuint GL_RGB10 = 0x8052;
        public const GLuint GL_RGB12 = 0x8053;
        public const GLuint GL_RGB16 = 0x8054;
        public const GLuint GL_RGBA2 = 0x8055;
        public const GLuint GL_RGBA4 = 0x8056;
        public const GLuint GL_RGB5_A1 = 0x8057;
        public const GLuint GL_RGBA8 = 0x8058;
        public const GLuint GL_RGB10_A2 = 0x8059;
        public const GLuint GL_RGBA12 = 0x805A;
        public const GLuint GL_RGBA16 = 0x805B;
        public const GLuint GL_V2F = 0x2A20;
        public const GLuint GL_V3F = 0x2A21;
        public const GLuint GL_C4UB_V2F = 0x2A22;
        public const GLuint GL_C4UB_V3F = 0x2A23;
        public const GLuint GL_C3F_V3F = 0x2A24;
        public const GLuint GL_N3F_V3F = 0x2A25;
        public const GLuint GL_C4F_N3F_V3F = 0x2A26;
        public const GLuint GL_T2F_V3F = 0x2A27;
        public const GLuint GL_T4F_V4F = 0x2A28;
        public const GLuint GL_T2F_C4UB_V3F = 0x2A29;
        public const GLuint GL_T2F_C3F_V3F = 0x2A2A;
        public const GLuint GL_T2F_N3F_V3F = 0x2A2B;
        public const GLuint GL_T2F_C4F_N3F_V3F = 0x2A2C;
        public const GLuint GL_T4F_C4F_N3F_V4F = 0x2A2D;
        public const GLuint GL_CLIP_PLANE0 = 0x3000;
        public const GLuint GL_CLIP_PLANE1 = 0x3001;
        public const GLuint GL_CLIP_PLANE2 = 0x3002;
        public const GLuint GL_CLIP_PLANE3 = 0x3003;
        public const GLuint GL_CLIP_PLANE4 = 0x3004;
        public const GLuint GL_CLIP_PLANE5 = 0x3005;
        public const GLuint GL_LIGHT0 = 0x4000;
        public const GLuint GL_LIGHT1 = 0x4001;
        public const GLuint GL_LIGHT2 = 0x4002;
        public const GLuint GL_LIGHT3 = 0x4003;
        public const GLuint GL_LIGHT4 = 0x4004;
        public const GLuint GL_LIGHT5 = 0x4005;
        public const GLuint GL_LIGHT6 = 0x4006;
        public const GLuint GL_LIGHT7 = 0x4007;
        public const GLuint GL_ABGR_EXT = 0x8000;
        public const GLuint GL_CONSTANT_COLOR = 0x8001;
        public const GLuint GL_CONSTANT_COLOR_EXT = 0x8001;
        public const GLuint GL_ONE_MINUS_CONSTANT_COLOR = 0x8002;
        public const GLuint GL_ONE_MINUS_CONSTANT_COLOR_EXT = 0x8002;
        public const GLuint GL_CONSTANT_ALPHA = 0x8003;
        public const GLuint GL_CONSTANT_ALPHA_EXT = 0x8003;
        public const GLuint GL_ONE_MINUS_CONSTANT_ALPHA = 0x8004;
        public const GLuint GL_ONE_MINUS_CONSTANT_ALPHA_EXT = 0x8004;
        public const GLuint GL_BLEND_COLOR = 0x8005;
        public const GLuint GL_BLEND_COLOR_EXT = 0x8005;
        public const GLuint GL_FUNC_ADD = 0x8006;
        public const GLuint GL_FUNC_ADD_EXT = 0x8006;
        public const GLuint GL_MIN = 0x8007;
        public const GLuint GL_MIN_EXT = 0x8007;
        public const GLuint GL_MAX = 0x8008;
        public const GLuint GL_MAX_EXT = 0x8008;
        public const GLuint GL_BLEND_EQUATION = 0x8009;
        public const GLuint GL_BLEND_EQUATION_EXT = 0x8009;
        public const GLuint GL_FUNC_SUBTRACT = 0x800A;
        public const GLuint GL_FUNC_SUBTRACT_EXT = 0x800A;
        public const GLuint GL_FUNC_REVERSE_SUBTRACT = 0x800B;
        public const GLuint GL_FUNC_REVERSE_SUBTRACT_EXT = 0x800B;
        public const GLuint GL_CMYK_EXT = 0x800C;
        public const GLuint GL_CMYKA_EXT = 0x800D;
        public const GLuint GL_PACK_CMYK_HINT_EXT = 0x800E;
        public const GLuint GL_UNPACK_CMYK_HINT_EXT = 0x800F;
        public const GLuint GL_CONVOLUTION_1D = 0x8010;
        public const GLuint GL_CONVOLUTION_1D_EXT = 0x8010;
        public const GLuint GL_CONVOLUTION_2D = 0x8011;
        public const GLuint GL_CONVOLUTION_2D_EXT = 0x8011;
        public const GLuint GL_SEPARABLE_2D = 0x8012;
        public const GLuint GL_SEPARABLE_2D_EXT = 0x8012;
        public const GLuint GL_CONVOLUTION_BORDER_MODE = 0x8013;
        public const GLuint GL_CONVOLUTION_BORDER_MODE_EXT = 0x8013;
        public const GLuint GL_CONVOLUTION_FILTER_SCALE = 0x8014;
        public const GLuint GL_CONVOLUTION_FILTER_SCALE_EXT = 0x8014;
        public const GLuint GL_CONVOLUTION_FILTER_BIAS = 0x8015;
        public const GLuint GL_CONVOLUTION_FILTER_BIAS_EXT = 0x8015;
        public const GLuint GL_REDUCE = 0x8016;
        public const GLuint GL_REDUCE_EXT = 0x8016;
        public const GLuint GL_CONVOLUTION_FORMAT = 0x8017;
        public const GLuint GL_CONVOLUTION_FORMAT_EXT = 0x8017;
        public const GLuint GL_CONVOLUTION_WIDTH = 0x8018;
        public const GLuint GL_CONVOLUTION_WIDTH_EXT = 0x8018;
        public const GLuint GL_CONVOLUTION_HEIGHT = 0x8019;
        public const GLuint GL_CONVOLUTION_HEIGHT_EXT = 0x8019;
        public const GLuint GL_MAX_CONVOLUTION_WIDTH = 0x801A;
        public const GLuint GL_MAX_CONVOLUTION_WIDTH_EXT = 0x801A;
        public const GLuint GL_MAX_CONVOLUTION_HEIGHT = 0x801B;
        public const GLuint GL_MAX_CONVOLUTION_HEIGHT_EXT = 0x801B;
        public const GLuint GL_POST_CONVOLUTION_RED_SCALE = 0x801C;
        public const GLuint GL_POST_CONVOLUTION_RED_SCALE_EXT = 0x801C;
        public const GLuint GL_POST_CONVOLUTION_GREEN_SCALE = 0x801D;
        public const GLuint GL_POST_CONVOLUTION_GREEN_SCALE_EXT = 0x801D;
        public const GLuint GL_POST_CONVOLUTION_BLUE_SCALE = 0x801E;
        public const GLuint GL_POST_CONVOLUTION_BLUE_SCALE_EXT = 0x801E;
        public const GLuint GL_POST_CONVOLUTION_ALPHA_SCALE = 0x801F;
        public const GLuint GL_POST_CONVOLUTION_ALPHA_SCALE_EXT = 0x801F;
        public const GLuint GL_POST_CONVOLUTION_RED_BIAS = 0x8020;
        public const GLuint GL_POST_CONVOLUTION_RED_BIAS_EXT = 0x8020;
        public const GLuint GL_POST_CONVOLUTION_GREEN_BIAS = 0x8021;
        public const GLuint GL_POST_CONVOLUTION_GREEN_BIAS_EXT = 0x8021;
        public const GLuint GL_POST_CONVOLUTION_BLUE_BIAS = 0x8022;
        public const GLuint GL_POST_CONVOLUTION_BLUE_BIAS_EXT = 0x8022;
        public const GLuint GL_POST_CONVOLUTION_ALPHA_BIAS = 0x8023;
        public const GLuint GL_POST_CONVOLUTION_ALPHA_BIAS_EXT = 0x8023;
        public const GLuint GL_HISTOGRAM = 0x8024;
        public const GLuint GL_HISTOGRAM_EXT = 0x8024;
        public const GLuint GL_PROXY_HISTOGRAM = 0x8025;
        public const GLuint GL_PROXY_HISTOGRAM_EXT = 0x8025;
        public const GLuint GL_HISTOGRAM_WIDTH = 0x8026;
        public const GLuint GL_HISTOGRAM_WIDTH_EXT = 0x8026;
        public const GLuint GL_HISTOGRAM_FORMAT = 0x8027;
        public const GLuint GL_HISTOGRAM_FORMAT_EXT = 0x8027;
        public const GLuint GL_HISTOGRAM_RED_SIZE = 0x8028;
        public const GLuint GL_HISTOGRAM_RED_SIZE_EXT = 0x8028;
        public const GLuint GL_HISTOGRAM_GREEN_SIZE = 0x8029;
        public const GLuint GL_HISTOGRAM_GREEN_SIZE_EXT = 0x8029;
        public const GLuint GL_HISTOGRAM_BLUE_SIZE = 0x802A;
        public const GLuint GL_HISTOGRAM_BLUE_SIZE_EXT = 0x802A;
        public const GLuint GL_HISTOGRAM_ALPHA_SIZE = 0x802B;
        public const GLuint GL_HISTOGRAM_ALPHA_SIZE_EXT = 0x802B;
        public const GLuint GL_HISTOGRAM_LUMINANCE_SIZE = 0x802C;
        public const GLuint GL_HISTOGRAM_LUMINANCE_SIZE_EXT = 0x802C;
        public const GLuint GL_HISTOGRAM_SINK = 0x802D;
        public const GLuint GL_HISTOGRAM_SINK_EXT = 0x802D;
        public const GLuint GL_MINMAX = 0x802E;
        public const GLuint GL_MINMAX_EXT = 0x802E;
        public const GLuint GL_MINMAX_FORMAT = 0x802F;
        public const GLuint GL_MINMAX_FORMAT_EXT = 0x802F;
        public const GLuint GL_MINMAX_SINK = 0x8030;
        public const GLuint GL_MINMAX_SINK_EXT = 0x8030;
        public const GLuint GL_TABLE_TOO_LARGE = 0x8031;
        public const GLuint GL_TABLE_TOO_LARGE_EXT = 0x8031;
        public const GLuint GL_UNSIGNED_BYTE_3_3_2 = 0x8032;
        public const GLuint GL_UNSIGNED_BYTE_3_3_2_EXT = 0x8032;
        public const GLuint GL_UNSIGNED_SHORT_4_4_4_4 = 0x8033;
        public const GLuint GL_UNSIGNED_SHORT_4_4_4_4_EXT = 0x8033;
        public const GLuint GL_UNSIGNED_SHORT_5_5_5_1 = 0x8034;
        public const GLuint GL_UNSIGNED_SHORT_5_5_5_1_EXT = 0x8034;
        public const GLuint GL_UNSIGNED_INT_8_8_8_8 = 0x8035;
        public const GLuint GL_UNSIGNED_INT_8_8_8_8_EXT = 0x8035;
        public const GLuint GL_UNSIGNED_INT_10_10_10_2 = 0x8036;
        public const GLuint GL_UNSIGNED_INT_10_10_10_2_EXT = 0x8036;
        public const GLuint GL_UNSIGNED_BYTE_2_3_3_REV = 0x8362;
        public const GLuint GL_UNSIGNED_BYTE_2_3_3_REV_EXT = 0x8362;
        public const GLuint GL_UNSIGNED_SHORT_5_6_5 = 0x8363;
        public const GLuint GL_UNSIGNED_SHORT_5_6_5_EXT = 0x8363;
        public const GLuint GL_UNSIGNED_SHORT_5_6_5_REV = 0x8364;
        public const GLuint GL_UNSIGNED_SHORT_5_6_5_REV_EXT = 0x8364;
        public const GLuint GL_UNSIGNED_SHORT_4_4_4_4_REV = 0x8365;
        public const GLuint GL_UNSIGNED_SHORT_4_4_4_4_REV_EXT = 0x8365;
        public const GLuint GL_UNSIGNED_SHORT_1_5_5_5_REV = 0x8366;
        public const GLuint GL_UNSIGNED_SHORT_1_5_5_5_REV_EXT = 0x8366;
        public const GLuint GL_UNSIGNED_INT_8_8_8_8_REV = 0x8367;
        public const GLuint GL_UNSIGNED_INT_8_8_8_8_REV_EXT = 0x8367;
        public const GLuint GL_UNSIGNED_INT_2_10_10_10_REV = 0x8368;
        public const GLuint GL_UNSIGNED_INT_2_10_10_10_REV_EXT = 0x8368;
        public const GLuint GL_POLYGON_OFFSET_EXT = 0x8037;
        public const GLuint GL_POLYGON_OFFSET_FACTOR_EXT = 0x8038;
        public const GLuint GL_POLYGON_OFFSET_BIAS_EXT = 0x8039;
        public const GLuint GL_RESCALE_NORMAL = 0x803A;
        public const GLuint GL_RESCALE_NORMAL_EXT = 0x803A;
        public const GLuint GL_ALPHA4_EXT = 0x803B;
        public const GLuint GL_ALPHA8_EXT = 0x803C;
        public const GLuint GL_ALPHA12_EXT = 0x803D;
        public const GLuint GL_ALPHA16_EXT = 0x803E;
        public const GLuint GL_LUMINANCE4_EXT = 0x803F;
        public const GLuint GL_LUMINANCE8_EXT = 0x8040;
        public const GLuint GL_LUMINANCE12_EXT = 0x8041;
        public const GLuint GL_LUMINANCE16_EXT = 0x8042;
        public const GLuint GL_LUMINANCE4_ALPHA4_EXT = 0x8043;
        public const GLuint GL_LUMINANCE6_ALPHA2_EXT = 0x8044;
        public const GLuint GL_LUMINANCE8_ALPHA8_EXT = 0x8045;
        public const GLuint GL_LUMINANCE12_ALPHA4_EXT = 0x8046;
        public const GLuint GL_LUMINANCE12_ALPHA12_EXT = 0x8047;
        public const GLuint GL_LUMINANCE16_ALPHA16_EXT = 0x8048;
        public const GLuint GL_INTENSITY_EXT = 0x8049;
        public const GLuint GL_INTENSITY4_EXT = 0x804A;
        public const GLuint GL_INTENSITY8_EXT = 0x804B;
        public const GLuint GL_INTENSITY12_EXT = 0x804C;
        public const GLuint GL_INTENSITY16_EXT = 0x804D;
        public const GLuint GL_RGB2_EXT = 0x804E;
        public const GLuint GL_RGB4_EXT = 0x804F;
        public const GLuint GL_RGB5_EXT = 0x8050;
        public const GLuint GL_RGB8_EXT = 0x8051;
        public const GLuint GL_RGB10_EXT = 0x8052;
        public const GLuint GL_RGB12_EXT = 0x8053;
        public const GLuint GL_RGB16_EXT = 0x8054;
        public const GLuint GL_RGBA2_EXT = 0x8055;
        public const GLuint GL_RGBA4_EXT = 0x8056;
        public const GLuint GL_RGB5_A1_EXT = 0x8057;
        public const GLuint GL_RGBA8_EXT = 0x8058;
        public const GLuint GL_RGB10_A2_EXT = 0x8059;
        public const GLuint GL_RGBA12_EXT = 0x805A;
        public const GLuint GL_RGBA16_EXT = 0x805B;
        public const GLuint GL_TEXTURE_RED_SIZE_EXT = 0x805C;
        public const GLuint GL_TEXTURE_GREEN_SIZE_EXT = 0x805D;
        public const GLuint GL_TEXTURE_BLUE_SIZE_EXT = 0x805E;
        public const GLuint GL_TEXTURE_ALPHA_SIZE_EXT = 0x805F;
        public const GLuint GL_TEXTURE_LUMINANCE_SIZE_EXT = 0x8060;
        public const GLuint GL_TEXTURE_INTENSITY_SIZE_EXT = 0x8061;
        public const GLuint GL_REPLACE_EXT = 0x8062;
        public const GLuint GL_PROXY_TEXTURE_1D_EXT = 0x8063;
        public const GLuint GL_PROXY_TEXTURE_2D_EXT = 0x8064;
        public const GLuint GL_TEXTURE_TOO_LARGE_EXT = 0x8065;
        public const GLuint GL_TEXTURE_PRIORITY_EXT = 0x8066;
        public const GLuint GL_TEXTURE_RESIDENT_EXT = 0x8067;
        public const GLuint GL_TEXTURE_1D_BINDING_EXT = 0x8068;
        public const GLuint GL_TEXTURE_2D_BINDING_EXT = 0x8069;
        public const GLuint GL_TEXTURE_3D_BINDING_EXT = 0x806A;
        public const GLuint GL_PACK_SKIP_IMAGES = 0x806B;
        public const GLuint GL_PACK_SKIP_IMAGES_EXT = 0x806B;
        public const GLuint GL_PACK_IMAGE_HEIGHT = 0x806C;
        public const GLuint GL_PACK_IMAGE_HEIGHT_EXT = 0x806C;
        public const GLuint GL_UNPACK_SKIP_IMAGES = 0x806D;
        public const GLuint GL_UNPACK_SKIP_IMAGES_EXT = 0x806D;
        public const GLuint GL_UNPACK_IMAGE_HEIGHT = 0x806E;
        public const GLuint GL_UNPACK_IMAGE_HEIGHT_EXT = 0x806E;
        public const GLuint GL_TEXTURE_3D = 0x806F;
        public const GLuint GL_TEXTURE_3D_EXT = 0x806F;
        public const GLuint GL_PROXY_TEXTURE_3D = 0x8070;
        public const GLuint GL_PROXY_TEXTURE_3D_EXT = 0x8070;
        public const GLuint GL_TEXTURE_DEPTH = 0x8071;
        public const GLuint GL_TEXTURE_DEPTH_EXT = 0x8071;
        public const GLuint GL_TEXTURE_WRAP_R = 0x8072;
        public const GLuint GL_TEXTURE_WRAP_R_EXT = 0x8072;
        public const GLuint GL_MAX_3D_TEXTURE_SIZE = 0x8073;
        public const GLuint GL_MAX_3D_TEXTURE_SIZE_EXT = 0x8073;
        public const GLuint GL_VERTEX_ARRAY_EXT = 0x8074;
        public const GLuint GL_NORMAL_ARRAY_EXT = 0x8075;
        public const GLuint GL_COLOR_ARRAY_EXT = 0x8076;
        public const GLuint GL_INDEX_ARRAY_EXT = 0x8077;
        public const GLuint GL_TEXTURE_COORD_ARRAY_EXT = 0x8078;
        public const GLuint GL_EDGE_FLAG_ARRAY_EXT = 0x8079;
        public const GLuint GL_VERTEX_ARRAY_SIZE_EXT = 0x807A;
        public const GLuint GL_VERTEX_ARRAY_TYPE_EXT = 0x807B;
        public const GLuint GL_VERTEX_ARRAY_STRIDE_EXT = 0x807C;
        public const GLuint GL_VERTEX_ARRAY_COUNT_EXT = 0x807D;
        public const GLuint GL_NORMAL_ARRAY_TYPE_EXT = 0x807E;
        public const GLuint GL_NORMAL_ARRAY_STRIDE_EXT = 0x807F;
        public const GLuint GL_NORMAL_ARRAY_COUNT_EXT = 0x8080;
        public const GLuint GL_COLOR_ARRAY_SIZE_EXT = 0x8081;
        public const GLuint GL_COLOR_ARRAY_TYPE_EXT = 0x8082;
        public const GLuint GL_COLOR_ARRAY_STRIDE_EXT = 0x8083;
        public const GLuint GL_COLOR_ARRAY_COUNT_EXT = 0x8084;
        public const GLuint GL_INDEX_ARRAY_TYPE_EXT = 0x8085;
        public const GLuint GL_INDEX_ARRAY_STRIDE_EXT = 0x8086;
        public const GLuint GL_INDEX_ARRAY_COUNT_EXT = 0x8087;
        public const GLuint GL_TEXTURE_COORD_ARRAY_SIZE_EXT = 0x8088;
        public const GLuint GL_TEXTURE_COORD_ARRAY_TYPE_EXT = 0x8089;
        public const GLuint GL_TEXTURE_COORD_ARRAY_STRIDE_EXT = 0x808A;
        public const GLuint GL_TEXTURE_COORD_ARRAY_COUNT_EXT = 0x808B;
        public const GLuint GL_EDGE_FLAG_ARRAY_STRIDE_EXT = 0x808C;
        public const GLuint GL_EDGE_FLAG_ARRAY_COUNT_EXT = 0x808D;
        public const GLuint GL_VERTEX_ARRAY_POINTER_EXT = 0x808E;
        public const GLuint GL_NORMAL_ARRAY_POINTER_EXT = 0x808F;
        public const GLuint GL_COLOR_ARRAY_POINTER_EXT = 0x8090;
        public const GLuint GL_INDEX_ARRAY_POINTER_EXT = 0x8091;
        public const GLuint GL_TEXTURE_COORD_ARRAY_POINTER_EXT = 0x8092;
        public const GLuint GL_EDGE_FLAG_ARRAY_POINTER_EXT = 0x8093;
        public const GLuint GL_INTERLACE_SGIX = 0x8094;
        public const GLuint GL_DETAIL_TEXTURE_2D_SGIS = 0x8095;
        public const GLuint GL_DETAIL_TEXTURE_2D_BINDING_SGIS = 0x8096;
        public const GLuint GL_LINEAR_DETAIL_SGIS = 0x8097;
        public const GLuint GL_LINEAR_DETAIL_ALPHA_SGIS = 0x8098;
        public const GLuint GL_LINEAR_DETAIL_COLOR_SGIS = 0x8099;
        public const GLuint GL_DETAIL_TEXTURE_LEVEL_SGIS = 0x809A;
        public const GLuint GL_DETAIL_TEXTURE_MODE_SGIS = 0x809B;
        public const GLuint GL_DETAIL_TEXTURE_FUNC_POINTS_SGIS = 0x809C;
        public const GLuint GL_MULTISAMPLE = 0x809D;
        public const GLuint GL_MULTISAMPLE_ARB = 0x809D;
        public const GLuint GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E;
        public const GLuint GL_SAMPLE_ALPHA_TO_COVERAGE_ARB = 0x809E;
        public const GLuint GL_SAMPLE_ALPHA_TO_ONE = 0x809F;
        public const GLuint GL_SAMPLE_ALPHA_TO_ONE_ARB = 0x809F;
        public const GLuint GL_SAMPLE_COVERAGE = 0x80A0;
        public const GLuint GL_SAMPLE_COVERAGE_ARB = 0x80A0;
        public const GLuint GL_SAMPLE_BUFFERS = 0x80A8;
        public const GLuint GL_SAMPLE_BUFFERS_ARB = 0x80A8;
        public const GLuint GL_SAMPLES = 0x80A9;
        public const GLuint GL_SAMPLES_ARB = 0x80A9;
        public const GLuint GL_SAMPLE_COVERAGE_VALUE = 0x80AA;
        public const GLuint GL_SAMPLE_COVERAGE_VALUE_ARB = 0x80AA;
        public const GLuint GL_SAMPLE_COVERAGE_INVERT = 0x80AB;
        public const GLuint GL_SAMPLE_COVERAGE_INVERT_ARB = 0x80AB;
        public const GLuint GL_MULTISAMPLE_SGIS = 0x809D;
        public const GLuint GL_SAMPLE_ALPHA_TO_MASK_SGIS = 0x809E;
        public const GLuint GL_SAMPLE_ALPHA_TO_ONE_SGIS = 0x809F;
        public const GLuint GL_SAMPLE_MASK_SGIS = 0x80A0;
        public const GLuint GL_1PASS_SGIS = 0x80A1;
        public const GLuint GL_2PASS_0_SGIS = 0x80A2;
        public const GLuint GL_2PASS_1_SGIS = 0x80A3;
        public const GLuint GL_4PASS_0_SGIS = 0x80A4;
        public const GLuint GL_4PASS_1_SGIS = 0x80A5;
        public const GLuint GL_4PASS_2_SGIS = 0x80A6;
        public const GLuint GL_4PASS_3_SGIS = 0x80A7;
        public const GLuint GL_SAMPLE_BUFFERS_SGIS = 0x80A8;
        public const GLuint GL_SAMPLES_SGIS = 0x80A9;
        public const GLuint GL_SAMPLE_MASK_VALUE_SGIS = 0x80AA;
        public const GLuint GL_SAMPLE_MASK_INVERT_SGIS = 0x80AB;
        public const GLuint GL_SAMPLE_PATTERN_SGIS = 0x80AC;
        public const GLuint GL_LINEAR_SHARPEN_SGIS = 0x80AD;
        public const GLuint GL_LINEAR_SHARPEN_ALPHA_SGIS = 0x80AE;
        public const GLuint GL_LINEAR_SHARPEN_COLOR_SGIS = 0x80AF;
        public const GLuint GL_SHARPEN_TEXTURE_FUNC_POINTS_SGIS = 0x80B0;
        public const GLuint GL_COLOR_MATRIX = 0x80B1;
        public const GLuint GL_COLOR_MATRIX_SGI = 0x80B1;
        public const GLuint GL_COLOR_MATRIX_STACK_DEPTH = 0x80B2;
        public const GLuint GL_COLOR_MATRIX_STACK_DEPTH_SGI = 0x80B2;
        public const GLuint GL_MAX_COLOR_MATRIX_STACK_DEPTH = 0x80B3;
        public const GLuint GL_MAX_COLOR_MATRIX_STACK_DEPTH_SGI = 0x80B3;
        public const GLuint GL_POST_COLOR_MATRIX_RED_SCALE = 0x80B4;
        public const GLuint GL_POST_COLOR_MATRIX_RED_SCALE_SGI = 0x80B4;
        public const GLuint GL_POST_COLOR_MATRIX_GREEN_SCALE = 0x80B5;
        public const GLuint GL_POST_COLOR_MATRIX_GREEN_SCALE_SGI = 0x80B5;
        public const GLuint GL_POST_COLOR_MATRIX_BLUE_SCALE = 0x80B6;
        public const GLuint GL_POST_COLOR_MATRIX_BLUE_SCALE_SGI = 0x80B6;
        public const GLuint GL_POST_COLOR_MATRIX_ALPHA_SCALE = 0x80B7;
        public const GLuint GL_POST_COLOR_MATRIX_ALPHA_SCALE_SGI = 0x80B7;
        public const GLuint GL_POST_COLOR_MATRIX_RED_BIAS = 0x80B8;
        public const GLuint GL_POST_COLOR_MATRIX_RED_BIAS_SGI = 0x80B8;
        public const GLuint GL_POST_COLOR_MATRIX_GREEN_BIAS = 0x80B9;
        public const GLuint GL_POST_COLOR_MATRIX_GREEN_BIAS_SGI = 0x80B9;
        public const GLuint GL_POST_COLOR_MATRIX_BLUE_BIAS = 0x80BA;
        public const GLuint GL_POST_COLOR_MATRIX_BLUE_BIAS_SGI = 0x80BA;
        public const GLuint GL_POST_COLOR_MATRIX_ALPHA_BIAS = 0x80BB;
        public const GLuint GL_POST_COLOR_MATRIX_ALPHA_BIAS_SGI = 0x80BB;
        public const GLuint GL_TEXTURE_COLOR_TABLE_SGI = 0x80BC;
        public const GLuint GL_PROXY_TEXTURE_COLOR_TABLE_SGI = 0x80BD;
        public const GLuint GL_TEXTURE_ENV_BIAS_SGIX = 0x80BE;
        public const GLuint GL_SHADOW_AMBIENT_SGIX = 0x80BF;
        public const GLuint GL_COLOR_TABLE = 0x80D0;
        public const GLuint GL_COLOR_TABLE_SGI = 0x80D0;
        public const GLuint GL_POST_CONVOLUTION_COLOR_TABLE = 0x80D1;
        public const GLuint GL_POST_CONVOLUTION_COLOR_TABLE_SGI = 0x80D1;
        public const GLuint GL_POST_COLOR_MATRIX_COLOR_TABLE = 0x80D2;
        public const GLuint GL_POST_COLOR_MATRIX_COLOR_TABLE_SGI = 0x80D2;
        public const GLuint GL_PROXY_COLOR_TABLE = 0x80D3;
        public const GLuint GL_PROXY_COLOR_TABLE_SGI = 0x80D3;
        public const GLuint GL_PROXY_POST_CONVOLUTION_COLOR_TABLE = 0x80D4;
        public const GLuint GL_PROXY_POST_CONVOLUTION_COLOR_TABLE_SGI = 0x80D4;
        public const GLuint GL_PROXY_POST_COLOR_MATRIX_COLOR_TABLE = 0x80D5;
        public const GLuint GL_PROXY_POST_COLOR_MATRIX_COLOR_TABLE_SGI = 0x80D5;
        public const GLuint GL_COLOR_TABLE_SCALE = 0x80D6;
        public const GLuint GL_COLOR_TABLE_SCALE_SGI = 0x80D6;
        public const GLuint GL_COLOR_TABLE_BIAS = 0x80D7;
        public const GLuint GL_COLOR_TABLE_BIAS_SGI = 0x80D7;
        public const GLuint GL_COLOR_TABLE_FORMAT = 0x80D8;
        public const GLuint GL_COLOR_TABLE_FORMAT_SGI = 0x80D8;
        public const GLuint GL_COLOR_TABLE_WIDTH = 0x80D9;
        public const GLuint GL_COLOR_TABLE_WIDTH_SGI = 0x80D9;
        public const GLuint GL_COLOR_TABLE_RED_SIZE = 0x80DA;
        public const GLuint GL_COLOR_TABLE_RED_SIZE_SGI = 0x80DA;
        public const GLuint GL_COLOR_TABLE_GREEN_SIZE = 0x80DB;
        public const GLuint GL_COLOR_TABLE_GREEN_SIZE_SGI = 0x80DB;
        public const GLuint GL_COLOR_TABLE_BLUE_SIZE = 0x80DC;
        public const GLuint GL_COLOR_TABLE_BLUE_SIZE_SGI = 0x80DC;
        public const GLuint GL_COLOR_TABLE_ALPHA_SIZE = 0x80DD;
        public const GLuint GL_COLOR_TABLE_ALPHA_SIZE_SGI = 0x80DD;
        public const GLuint GL_COLOR_TABLE_LUMINANCE_SIZE = 0x80DE;
        public const GLuint GL_COLOR_TABLE_LUMINANCE_SIZE_SGI = 0x80DE;
        public const GLuint GL_COLOR_TABLE_INTENSITY_SIZE = 0x80DF;
        public const GLuint GL_COLOR_TABLE_INTENSITY_SIZE_SGI = 0x80DF;
        public const GLuint GL_BGR = 0x80E0;
        public const GLuint GL_BGR_EXT = 0x80E0;
        public const GLuint GL_BGRA = 0x80E1;
        public const GLuint GL_BGRA_EXT = 0x80E1;
        public const GLuint GL_MAX_ELEMENTS_VERTICES = 0x80E8;
        public const GLuint GL_MAX_ELEMENTS_INDICES = 0x80E9;
        public const GLuint GL_DUAL_ALPHA4_SGIS = 0x8110;
        public const GLuint GL_DUAL_ALPHA8_SGIS = 0x8111;
        public const GLuint GL_DUAL_ALPHA12_SGIS = 0x8112;
        public const GLuint GL_DUAL_ALPHA16_SGIS = 0x8113;
        public const GLuint GL_DUAL_LUMINANCE4_SGIS = 0x8114;
        public const GLuint GL_DUAL_LUMINANCE8_SGIS = 0x8115;
        public const GLuint GL_DUAL_LUMINANCE12_SGIS = 0x8116;
        public const GLuint GL_DUAL_LUMINANCE16_SGIS = 0x8117;
        public const GLuint GL_DUAL_INTENSITY4_SGIS = 0x8118;
        public const GLuint GL_DUAL_INTENSITY8_SGIS = 0x8119;
        public const GLuint GL_DUAL_INTENSITY12_SGIS = 0x811A;
        public const GLuint GL_DUAL_INTENSITY16_SGIS = 0x811B;
        public const GLuint GL_DUAL_LUMINANCE_ALPHA4_SGIS = 0x811C;
        public const GLuint GL_DUAL_LUMINANCE_ALPHA8_SGIS = 0x811D;
        public const GLuint GL_QUAD_ALPHA4_SGIS = 0x811E;
        public const GLuint GL_QUAD_ALPHA8_SGIS = 0x811F;
        public const GLuint GL_QUAD_LUMINANCE4_SGIS = 0x8120;
        public const GLuint GL_QUAD_LUMINANCE8_SGIS = 0x8121;
        public const GLuint GL_QUAD_INTENSITY4_SGIS = 0x8122;
        public const GLuint GL_QUAD_INTENSITY8_SGIS = 0x8123;
        public const GLuint GL_DUAL_TEXTURE_SELECT_SGIS = 0x8124;
        public const GLuint GL_QUAD_TEXTURE_SELECT_SGIS = 0x8125;
        public const GLuint GL_POINT_SIZE_MIN = 0x8126;
        public const GLuint GL_POINT_SIZE_MIN_ARB = 0x8126;
        public const GLuint GL_POINT_SIZE_MIN_EXT = 0x8126;
        public const GLuint GL_POINT_SIZE_MIN_SGIS = 0x8126;
        public const GLuint GL_POINT_SIZE_MAX = 0x8127;
        public const GLuint GL_POINT_SIZE_MAX_ARB = 0x8127;
        public const GLuint GL_POINT_SIZE_MAX_EXT = 0x8127;
        public const GLuint GL_POINT_SIZE_MAX_SGIS = 0x8127;
        public const GLuint GL_POINT_FADE_THRESHOLD_SIZE = 0x8128;
        public const GLuint GL_POINT_FADE_THRESHOLD_SIZE_ARB = 0x8128;
        public const GLuint GL_POINT_FADE_THRESHOLD_SIZE_EXT = 0x8128;
        public const GLuint GL_POINT_FADE_THRESHOLD_SIZE_SGIS = 0x8128;
        public const GLuint GL_POINT_DISTANCE_ATTENUATION = 0x8129;
        public const GLuint GL_POINT_DISTANCE_ATTENUATION_ARB = 0x8129;
        public const GLuint GL_DISTANCE_ATTENUATION_EXT = 0x8129;
        public const GLuint GL_DISTANCE_ATTENUATION_SGIS = 0x8129;
        public const GLuint GL_FOG_FUNC_SGIS = 0x812A;
        public const GLuint GL_FOG_FUNC_POINTS_SGIS = 0x812B;
        public const GLuint GL_MAX_FOG_FUNC_POINTS_SGIS = 0x812C;
        public const GLuint GL_CLAMP_TO_BORDER = 0x812D;
        public const GLuint GL_CLAMP_TO_BORDER_ARB = 0x812D;
        public const GLuint GL_CLAMP_TO_BORDER_SGIS = 0x812D;
        public const GLuint GL_TEXTURE_MULTI_BUFFER_HINT_SGIX = 0x812E;
        public const GLuint GL_CLAMP_TO_EDGE = 0x812F;
        public const GLuint GL_CLAMP_TO_EDGE_SGIS = 0x812F;
        public const GLuint GL_PACK_SKIP_VOLUMES_SGIS = 0x8130;
        public const GLuint GL_PACK_IMAGE_DEPTH_SGIS = 0x8131;
        public const GLuint GL_UNPACK_SKIP_VOLUMES_SGIS = 0x8132;
        public const GLuint GL_UNPACK_IMAGE_DEPTH_SGIS = 0x8133;
        public const GLuint GL_TEXTURE_4D_SGIS = 0x8134;
        public const GLuint GL_PROXY_TEXTURE_4D_SGIS = 0x8135;
        public const GLuint GL_TEXTURE_4DSIZE_SGIS = 0x8136;
        public const GLuint GL_TEXTURE_WRAP_Q_SGIS = 0x8137;
        public const GLuint GL_MAX_4D_TEXTURE_SIZE_SGIS = 0x8138;
        public const GLuint GL_TEXTURE_4D_BINDING_SGIS = 0x814F;
        public const GLuint GL_PIXEL_TEX_GEN_SGIX = 0x8139;
        public const GLuint GL_PIXEL_TEX_GEN_MODE_SGIX = 0x832B;
        public const GLuint GL_TEXTURE_MIN_LOD = 0x813A;
        public const GLuint GL_TEXTURE_MIN_LOD_SGIS = 0x813A;
        public const GLuint GL_TEXTURE_MAX_LOD = 0x813B;
        public const GLuint GL_TEXTURE_MAX_LOD_SGIS = 0x813B;
        public const GLuint GL_TEXTURE_BASE_LEVEL = 0x813C;
        public const GLuint GL_TEXTURE_BASE_LEVEL_SGIS = 0x813C;
        public const GLuint GL_TEXTURE_MAX_LEVEL = 0x813D;
        public const GLuint GL_TEXTURE_MAX_LEVEL_SGIS = 0x813D;
        public const GLuint GL_PIXEL_TILE_BEST_ALIGNMENT_SGIX = 0x813E;
        public const GLuint GL_PIXEL_TILE_CACHE_INCREMENT_SGIX = 0x813F;
        public const GLuint GL_PIXEL_TILE_WIDTH_SGIX = 0x8140;
        public const GLuint GL_PIXEL_TILE_HEIGHT_SGIX = 0x8141;
        public const GLuint GL_PIXEL_TILE_GRID_WIDTH_SGIX = 0x8142;
        public const GLuint GL_PIXEL_TILE_GRID_HEIGHT_SGIX = 0x8143;
        public const GLuint GL_PIXEL_TILE_GRID_DEPTH_SGIX = 0x8144;
        public const GLuint GL_PIXEL_TILE_CACHE_SIZE_SGIX = 0x8145;
        public const GLuint GL_FILTER4_SGIS = 0x8146;
        public const GLuint GL_TEXTURE_FILTER4_SIZE_SGIS = 0x8147;
        public const GLuint GL_SPRITE_SGIX = 0x8148;
        public const GLuint GL_SPRITE_MODE_SGIX = 0x8149;
        public const GLuint GL_SPRITE_AXIS_SGIX = 0x814A;
        public const GLuint GL_SPRITE_TRANSLATION_SGIX = 0x814B;
        public const GLuint GL_SPRITE_AXIAL_SGIX = 0x814C;
        public const GLuint GL_SPRITE_OBJECT_ALIGNED_SGIX = 0x814D;
        public const GLuint GL_SPRITE_EYE_ALIGNED_SGIX = 0x814E;
        public const GLuint GL_IGNORE_BORDER_HP = 0x8150;
        public const GLuint GL_CONSTANT_BORDER = 0x8151;
        public const GLuint GL_CONSTANT_BORDER_HP = 0x8151;
        public const GLuint GL_REPLICATE_BORDER = 0x8153;
        public const GLuint GL_REPLICATE_BORDER_HP = 0x8153;
        public const GLuint GL_CONVOLUTION_BORDER_COLOR = 0x8154;
        public const GLuint GL_CONVOLUTION_BORDER_COLOR_HP = 0x8154;
        public const GLuint GL_LINEAR_CLIPMAP_LINEAR_SGIX = 0x8170;
        public const GLuint GL_TEXTURE_CLIPMAP_CENTER_SGIX = 0x8171;
        public const GLuint GL_TEXTURE_CLIPMAP_FRAME_SGIX = 0x8172;
        public const GLuint GL_TEXTURE_CLIPMAP_OFFSET_SGIX = 0x8173;
        public const GLuint GL_TEXTURE_CLIPMAP_VIRTUAL_DEPTH_SGIX = 0x8174;
        public const GLuint GL_TEXTURE_CLIPMAP_LOD_OFFSET_SGIX = 0x8175;
        public const GLuint GL_TEXTURE_CLIPMAP_DEPTH_SGIX = 0x8176;
        public const GLuint GL_MAX_CLIPMAP_DEPTH_SGIX = 0x8177;
        public const GLuint GL_MAX_CLIPMAP_VIRTUAL_DEPTH_SGIX = 0x8178;
        public const GLuint GL_NEAREST_CLIPMAP_NEAREST_SGIX = 0x844D;
        public const GLuint GL_NEAREST_CLIPMAP_LINEAR_SGIX = 0x844E;
        public const GLuint GL_LINEAR_CLIPMAP_NEAREST_SGIX = 0x844F;
        public const GLuint GL_POST_TEXTURE_FILTER_BIAS_SGIX = 0x8179;
        public const GLuint GL_POST_TEXTURE_FILTER_SCALE_SGIX = 0x817A;
        public const GLuint GL_POST_TEXTURE_FILTER_BIAS_RANGE_SGIX = 0x817B;
        public const GLuint GL_POST_TEXTURE_FILTER_SCALE_RANGE_SGIX = 0x817C;
        public const GLuint GL_REFERENCE_PLANE_SGIX = 0x817D;
        public const GLuint GL_REFERENCE_PLANE_EQUATION_SGIX = 0x817E;
        public const GLuint GL_IR_INSTRUMENT1_SGIX = 0x817F;
        public const GLuint GL_INSTRUMENT_BUFFER_POINTER_SGIX = 0x8180;
        public const GLuint GL_INSTRUMENT_MEASUREMENTS_SGIX = 0x8181;
        public const GLuint GL_LIST_PRIORITY_SGIX = 0x8182;
        public const GLuint GL_CALLIGRAPHIC_FRAGMENT_SGIX = 0x8183;
        public const GLuint GL_PIXEL_TEX_GEN_Q_CEILING_SGIX = 0x8184;
        public const GLuint GL_PIXEL_TEX_GEN_Q_ROUND_SGIX = 0x8185;
        public const GLuint GL_PIXEL_TEX_GEN_Q_FLOOR_SGIX = 0x8186;
        public const GLuint GL_PIXEL_TEX_GEN_ALPHA_REPLACE_SGIX = 0x8187;
        public const GLuint GL_PIXEL_TEX_GEN_ALPHA_NO_REPLACE_SGIX = 0x8188;
        public const GLuint GL_PIXEL_TEX_GEN_ALPHA_LS_SGIX = 0x8189;
        public const GLuint GL_PIXEL_TEX_GEN_ALPHA_MS_SGIX = 0x818A;
        public const GLuint GL_FRAMEZOOM_SGIX = 0x818B;
        public const GLuint GL_FRAMEZOOM_FACTOR_SGIX = 0x818C;
        public const GLuint GL_MAX_FRAMEZOOM_FACTOR_SGIX = 0x818D;
        public const GLuint GL_TEXTURE_LOD_BIAS_S_SGIX = 0x818E;
        public const GLuint GL_TEXTURE_LOD_BIAS_T_SGIX = 0x818F;
        public const GLuint GL_TEXTURE_LOD_BIAS_R_SGIX = 0x8190;
        public const GLuint GL_GENERATE_MIPMAP = 0x8191;
        public const GLuint GL_GENERATE_MIPMAP_SGIS = 0x8191;
        public const GLuint GL_GENERATE_MIPMAP_HINT = 0x8192;
        public const GLuint GL_GENERATE_MIPMAP_HINT_SGIS = 0x8192;
        public const GLuint GL_GEOMETRY_DEFORMATION_SGIX = 0x8194;
        public const GLuint GL_TEXTURE_DEFORMATION_SGIX = 0x8195;
        public const GLuint GL_DEFORMATIONS_MASK_SGIX = 0x8196;
        public const GLuint GL_MAX_DEFORMATION_ORDER_SGIX = 0x8197;
        public const GLuint GL_FOG_OFFSET_SGIX = 0x8198;
        public const GLuint GL_FOG_OFFSET_VALUE_SGIX = 0x8199;
        public const GLuint GL_TEXTURE_COMPARE_SGIX = 0x819A;
        public const GLuint GL_TEXTURE_COMPARE_OPERATOR_SGIX = 0x819B;
        public const GLuint GL_TEXTURE_LEQUAL_R_SGIX = 0x819C;
        public const GLuint GL_TEXTURE_GEQUAL_R_SGIX = 0x819D;
        public const GLuint GL_DEPTH_COMPONENT16 = 0x81A5;
        public const GLuint GL_DEPTH_COMPONENT16_SGIX = 0x81A5;
        public const GLuint GL_DEPTH_COMPONENT24 = 0x81A6;
        public const GLuint GL_DEPTH_COMPONENT24_SGIX = 0x81A6;
        public const GLuint GL_DEPTH_COMPONENT32 = 0x81A7;
        public const GLuint GL_DEPTH_COMPONENT32_SGIX = 0x81A7;
        public const GLuint GL_YCRCB_422_SGIX = 0x81BB;
        public const GLuint GL_YCRCB_444_SGIX = 0x81BC;
        public const GLuint GL_TEXTURE_COLOR_WRITEMASK_SGIS = 0x81EF;
        public const GLuint GL_EYE_DISTANCE_TO_POINT_SGIS = 0x81F0;
        public const GLuint GL_OBJECT_DISTANCE_TO_POINT_SGIS = 0x81F1;
        public const GLuint GL_EYE_DISTANCE_TO_LINE_SGIS = 0x81F2;
        public const GLuint GL_OBJECT_DISTANCE_TO_LINE_SGIS = 0x81F3;
        public const GLuint GL_EYE_POINT_SGIS = 0x81F4;
        public const GLuint GL_OBJECT_POINT_SGIS = 0x81F5;
        public const GLuint GL_EYE_LINE_SGIS = 0x81F6;
        public const GLuint GL_OBJECT_LINE_SGIS = 0x81F7;
        public const GLuint GL_LIGHT_MODEL_COLOR_CONTROL = 0x81F8;
        public const GLuint GL_LIGHT_MODEL_COLOR_CONTROL_EXT = 0x81F8;
        public const GLuint GL_SINGLE_COLOR = 0x81F9;
        public const GLuint GL_SINGLE_COLOR_EXT = 0x81F9;
        public const GLuint GL_SEPARATE_SPECULAR_COLOR = 0x81FA;
        public const GLuint GL_SEPARATE_SPECULAR_COLOR_EXT = 0x81FA;
        public const GLuint GL_SHARED_TEXTURE_PALETTE_EXT = 0x81FB;
        public const GLuint GL_CONVOLUTION_HINT_SGIX = 0x8316;
        public const GLuint GL_ALPHA_MIN_SGIX = 0x8320;
        public const GLuint GL_ALPHA_MAX_SGIX = 0x8321;
        public const GLuint GL_ASYNC_HISTOGRAM_SGIX = 0x832C;
        public const GLuint GL_MAX_ASYNC_HISTOGRAM_SGIX = 0x832D;
        public const GLuint GL_PIXEL_TRANSFORM_2D_EXT = 0x8330;
        public const GLuint GL_PIXEL_MAG_FILTER_EXT = 0x8331;
        public const GLuint GL_PIXEL_MIN_FILTER_EXT = 0x8332;
        public const GLuint GL_PIXEL_CUBIC_WEIGHT_EXT = 0x8333;
        public const GLuint GL_CUBIC_EXT = 0x8334;
        public const GLuint GL_AVERAGE_EXT = 0x8335;
        public const GLuint GL_PIXEL_TRANSFORM_2D_STACK_DEPTH_EXT = 0x8336;
        public const GLuint GL_MAX_PIXEL_TRANSFORM_2D_STACK_DEPTH_EXT = 0x8337;
        public const GLuint GL_PIXEL_TRANSFORM_2D_MATRIX_EXT = 0x8338;
        public const GLuint GL_PIXEL_TEXTURE_SGIS = 0x8353;
        public const GLuint GL_PIXEL_FRAGMENT_RGB_SOURCE_SGIS = 0x8354;
        public const GLuint GL_PIXEL_FRAGMENT_ALPHA_SOURCE_SGIS = 0x8355;
        public const GLuint GL_PIXEL_GROUP_COLOR_SGIS = 0x8356;
        public const GLuint GL_ASYNC_TEX_IMAGE_SGIX = 0x835C;
        public const GLuint GL_ASYNC_DRAW_PIXELS_SGIX = 0x835D;
        public const GLuint GL_ASYNC_READ_PIXELS_SGIX = 0x835E;
        public const GLuint GL_MAX_ASYNC_TEX_IMAGE_SGIX = 0x835F;
        public const GLuint GL_MAX_ASYNC_DRAW_PIXELS_SGIX = 0x8360;
        public const GLuint GL_MAX_ASYNC_READ_PIXELS_SGIX = 0x8361;
        public const GLuint GL_TEXTURE_MAX_CLAMP_S_SGIX = 0x8369;
        public const GLuint GL_TEXTURE_MAX_CLAMP_T_SGIX = 0x836A;
        public const GLuint GL_TEXTURE_MAX_CLAMP_R_SGIX = 0x836B;
        public const GLuint GL_FOG_FACTOR_TO_ALPHA_SGIX = 0x836F;
        public const GLuint GL_VERTEX_PRECLIP_SGIX = 0x83EE;
        public const GLuint GL_VERTEX_PRECLIP_HINT_SGIX = 0x83EF;
        public const GLuint GL_COMPRESSED_RGB_S3TC_DXT1_EXT = 0x83F0;
        public const GLuint GL_COMPRESSED_RGBA_S3TC_DXT1_EXT = 0x83F1;
        public const GLuint GL_COMPRESSED_RGBA_S3TC_DXT3_EXT = 0x83F2;
        public const GLuint GL_COMPRESSED_RGBA_S3TC_DXT5_EXT = 0x83F3;
        public const GLuint GL_PARALLEL_ARRAYS_INTEL = 0x83F4;
        public const GLuint GL_VERTEX_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F5;
        public const GLuint GL_NORMAL_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F6;
        public const GLuint GL_COLOR_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F7;
        public const GLuint GL_TEXTURE_COORD_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F8;
        public const GLuint GL_FRAGMENT_LIGHTING_SGIX = 0x8400;
        public const GLuint GL_FRAGMENT_COLOR_MATERIAL_SGIX = 0x8401;
        public const GLuint GL_FRAGMENT_COLOR_MATERIAL_FACE_SGIX = 0x8402;
        public const GLuint GL_FRAGMENT_COLOR_MATERIAL_PARAMETER_SGIX = 0x8403;
        public const GLuint GL_MAX_FRAGMENT_LIGHTS_SGIX = 0x8404;
        public const GLuint GL_MAX_ACTIVE_LIGHTS_SGIX = 0x8405;
        public const GLuint GL_CURRENT_RASTER_NORMAL_SGIX = 0x8406;
        public const GLuint GL_LIGHT_ENV_MODE_SGIX = 0x8407;
        public const GLuint GL_FRAGMENT_LIGHT_MODEL_LOCAL_VIEWER_SGIX = 0x8408;
        public const GLuint GL_FRAGMENT_LIGHT_MODEL_TWO_SIDE_SGIX = 0x8409;
        public const GLuint GL_FRAGMENT_LIGHT_MODEL_AMBIENT_SGIX = 0x840A;
        public const GLuint GL_FRAGMENT_LIGHT_MODEL_NORMAL_INTERPOLATION_SGIX = 0x840B;
        public const GLuint GL_FRAGMENT_LIGHT0_SGIX = 0x840C;
        public const GLuint GL_FRAGMENT_LIGHT1_SGIX = 0x840D;
        public const GLuint GL_FRAGMENT_LIGHT2_SGIX = 0x840E;
        public const GLuint GL_FRAGMENT_LIGHT3_SGIX = 0x840F;
        public const GLuint GL_FRAGMENT_LIGHT4_SGIX = 0x8410;
        public const GLuint GL_FRAGMENT_LIGHT5_SGIX = 0x8411;
        public const GLuint GL_FRAGMENT_LIGHT6_SGIX = 0x8412;
        public const GLuint GL_FRAGMENT_LIGHT7_SGIX = 0x8413;
        public const GLuint GL_PACK_RESAMPLE_SGIX = 0x842C;
        public const GLuint GL_UNPACK_RESAMPLE_SGIX = 0x842D;
        public const GLuint GL_RESAMPLE_REPLICATE_SGIX = 0x842E;
        public const GLuint GL_RESAMPLE_ZERO_FILL_SGIX = 0x842F;
        public const GLuint GL_RESAMPLE_DECIMATE_SGIX = 0x8430;
        public const GLuint GL_RGB_ICC_SGIX = 0x8460;
        public const GLuint GL_RGBA_ICC_SGIX = 0x8461;
        public const GLuint GL_ALPHA_ICC_SGIX = 0x8462;
        public const GLuint GL_LUMINANCE_ICC_SGIX = 0x8463;
        public const GLuint GL_INTENSITY_ICC_SGIX = 0x8464;
        public const GLuint GL_LUMINANCE_ALPHA_ICC_SGIX = 0x8465;
        public const GLuint GL_R5_G6_B5_ICC_SGIX = 0x8466;
        public const GLuint GL_R5_G6_B5_A8_ICC_SGIX = 0x8467;
        public const GLuint GL_ALPHA16_ICC_SGIX = 0x8468;
        public const GLuint GL_LUMINANCE16_ICC_SGIX = 0x8469;
        public const GLuint GL_INTENSITY16_ICC_SGIX = 0x846A;
        public const GLuint GL_LUMINANCE16_ALPHA8_ICC_SGIX = 0x846B;
        public const GLuint GL_SMOOTH_POINT_SIZE_RANGE = 0x0B12;
        public const GLuint GL_SMOOTH_POINT_SIZE_GRANULARITY = 0x0B13;
        public const GLuint GL_SMOOTH_LINE_WIDTH_RANGE = 0x0B22;
        public const GLuint GL_SMOOTH_LINE_WIDTH_GRANULARITY = 0x0B23;
        public const GLuint GL_ALIASED_POINT_SIZE_RANGE = 0x846D;
        public const GLuint GL_ALIASED_LINE_WIDTH_RANGE = 0x846E;
        public const GLuint GL_PACK_SUBSAMPLE_RATE_SGIX = 0x85A0;
        public const GLuint GL_UNPACK_SUBSAMPLE_RATE_SGIX = 0x85A1;
        public const GLuint GL_PIXEL_SUBSAMPLE_4444_SGIX = 0x85A2;
        public const GLuint GL_PIXEL_SUBSAMPLE_2424_SGIX = 0x85A3;
        public const GLuint GL_PIXEL_SUBSAMPLE_4242_SGIX = 0x85A4;
        public const GLuint GL_TEXTURE0 = 0x84C0;
        public const GLuint GL_TEXTURE1 = 0x84C1;
        public const GLuint GL_TEXTURE2 = 0x84C2;
        public const GLuint GL_TEXTURE3 = 0x84C3;
        public const GLuint GL_TEXTURE4 = 0x84C4;
        public const GLuint GL_TEXTURE5 = 0x84C5;
        public const GLuint GL_TEXTURE6 = 0x84C6;
        public const GLuint GL_TEXTURE7 = 0x84C7;
        public const GLuint GL_TEXTURE8 = 0x84C8;
        public const GLuint GL_TEXTURE9 = 0x84C9;
        public const GLuint GL_TEXTURE10 = 0x84CA;
        public const GLuint GL_TEXTURE11 = 0x84CB;
        public const GLuint GL_TEXTURE12 = 0x84CC;
        public const GLuint GL_TEXTURE13 = 0x84CD;
        public const GLuint GL_TEXTURE14 = 0x84CE;
        public const GLuint GL_TEXTURE15 = 0x84CF;
        public const GLuint GL_TEXTURE16 = 0x84D0;
        public const GLuint GL_TEXTURE17 = 0x84D1;
        public const GLuint GL_TEXTURE18 = 0x84D2;
        public const GLuint GL_TEXTURE19 = 0x84D3;
        public const GLuint GL_TEXTURE20 = 0x84D4;
        public const GLuint GL_TEXTURE21 = 0x84D5;
        public const GLuint GL_TEXTURE22 = 0x84D6;
        public const GLuint GL_TEXTURE23 = 0x84D7;
        public const GLuint GL_TEXTURE24 = 0x84D8;
        public const GLuint GL_TEXTURE25 = 0x84D9;
        public const GLuint GL_TEXTURE26 = 0x84DA;
        public const GLuint GL_TEXTURE27 = 0x84DB;
        public const GLuint GL_TEXTURE28 = 0x84DC;
        public const GLuint GL_TEXTURE29 = 0x84DD;
        public const GLuint GL_TEXTURE30 = 0x84DE;
        public const GLuint GL_TEXTURE31 = 0x84DF;
        public const GLuint GL_ACTIVE_TEXTURE = 0x84E0;
        public const GLuint GL_CLIENT_ACTIVE_TEXTURE = 0x84E1;
        public const GLuint GL_MAX_TEXTURE_UNITS = 0x84E2;
        public const GLuint GL_TRANSPOSE_MODELVIEW_MATRIX = 0x84E3;
        public const GLuint GL_TRANSPOSE_PROJECTION_MATRIX = 0x84E4;
        public const GLuint GL_TRANSPOSE_TEXTURE_MATRIX = 0x84E5;
        public const GLuint GL_TRANSPOSE_COLOR_MATRIX = 0x84E6;
        public const GLuint GL_MULTISAMPLE_BIT = 0x20000000;
        public const GLuint GL_NORMAL_MAP = 0x8511;
        public const GLuint GL_REFLECTION_MAP = 0x8512;
        public const GLuint GL_TEXTURE_CUBE_MAP = 0x8513;
        public const GLuint GL_TEXTURE_BINDING_CUBE_MAP = 0x8514;
        public const GLuint GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515;
        public const GLuint GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516;
        public const GLuint GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517;
        public const GLuint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518;
        public const GLuint GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519;
        public const GLuint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A;
        public const GLuint GL_PROXY_TEXTURE_CUBE_MAP = 0x851B;
        public const GLuint GL_MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C;
        public const GLuint GL_COMPRESSED_ALPHA = 0x84E9;
        public const GLuint GL_COMPRESSED_LUMINANCE = 0x84EA;
        public const GLuint GL_COMPRESSED_LUMINANCE_ALPHA = 0x84EB;
        public const GLuint GL_COMPRESSED_INTENSITY = 0x84EC;
        public const GLuint GL_COMPRESSED_RGB = 0x84ED;
        public const GLuint GL_COMPRESSED_RGBA = 0x84EE;
        public const GLuint GL_TEXTURE_COMPRESSION_HINT = 0x84EF;
        public const GLuint GL_TEXTURE_COMPRESSED_IMAGE_SIZE = 0x86A0;
        public const GLuint GL_TEXTURE_COMPRESSED = 0x86A1;
        public const GLuint GL_NUM_COMPRESSED_TEXTURE_FORMATS = 0x86A2;
        public const GLuint GL_COMPRESSED_TEXTURE_FORMATS = 0x86A3;
        public const GLuint GL_COMBINE = 0x8570;
        public const GLuint GL_COMBINE_RGB = 0x8571;
        public const GLuint GL_COMBINE_ALPHA = 0x8572;
        public const GLuint GL_SOURCE0_RGB = 0x8580;
        public const GLuint GL_SOURCE1_RGB = 0x8581;
        public const GLuint GL_SOURCE2_RGB = 0x8582;
        public const GLuint GL_SOURCE0_ALPHA = 0x8588;
        public const GLuint GL_SOURCE1_ALPHA = 0x8589;
        public const GLuint GL_SOURCE2_ALPHA = 0x858A;
        public const GLuint GL_OPERAND0_RGB = 0x8590;
        public const GLuint GL_OPERAND1_RGB = 0x8591;
        public const GLuint GL_OPERAND2_RGB = 0x8592;
        public const GLuint GL_OPERAND0_ALPHA = 0x8598;
        public const GLuint GL_OPERAND1_ALPHA = 0x8599;
        public const GLuint GL_OPERAND2_ALPHA = 0x859A;
        public const GLuint GL_RGB_SCALE = 0x8573;
        public const GLuint GL_ADD_SIGNED = 0x8574;
        public const GLuint GL_INTERPOLATE = 0x8575;
        public const GLuint GL_SUBTRACT = 0x84E7;
        public const GLuint GL_CONSTANT = 0x8576;
        public const GLuint GL_PRIMARY_COLOR = 0x8577;
        public const GLuint GL_PREVIOUS = 0x8578;
        public const GLuint GL_DOT3_RGB = 0x86AE;
        public const GLuint GL_DOT3_RGBA = 0x86AF;
        public const GLuint GL_BLEND_DST_RGB = 0x80C8;
        public const GLuint GL_BLEND_SRC_RGB = 0x80C9;
        public const GLuint GL_BLEND_DST_ALPHA = 0x80CA;
        public const GLuint GL_BLEND_SRC_ALPHA = 0x80CB;
        public const GLuint GL_MIRRORED_REPEAT = 0x8370;
        public const GLuint GL_FOG_COORDINATE_SOURCE = 0x8450;
        public const GLuint GL_FOG_COORDINATE = 0x8451;
        public const GLuint GL_FRAGMENT_DEPTH = 0x8452;
        public const GLuint GL_CURRENT_FOG_COORDINATE = 0x8453;
        public const GLuint GL_FOG_COORDINATE_ARRAY_TYPE = 0x8454;
        public const GLuint GL_FOG_COORDINATE_ARRAY_STRIDE = 0x8455;
        public const GLuint GL_FOG_COORDINATE_ARRAY_POINTER = 0x8456;
        public const GLuint GL_FOG_COORDINATE_ARRAY = 0x8457;
        public const GLuint GL_COLOR_SUM = 0x8458;
        public const GLuint GL_CURRENT_SECONDARY_COLOR = 0x8459;
        public const GLuint GL_SECONDARY_COLOR_ARRAY_SIZE = 0x845A;
        public const GLuint GL_SECONDARY_COLOR_ARRAY_TYPE = 0x845B;
        public const GLuint GL_SECONDARY_COLOR_ARRAY_STRIDE = 0x845C;
        public const GLuint GL_SECONDARY_COLOR_ARRAY_POINTER = 0x845D;
        public const GLuint GL_SECONDARY_COLOR_ARRAY = 0x845E;
        public const GLuint GL_MAX_TEXTURE_LOD_BIAS = 0x84FD;
        public const GLuint GL_TEXTURE_FILTER_CONTROL = 0x8500;
        public const GLuint GL_TEXTURE_LOD_BIAS = 0x8501;
        public const GLuint GL_INCR_WRAP = 0x8507;
        public const GLuint GL_DECR_WRAP = 0x8508;
        public const GLuint GL_TEXTURE_DEPTH_SIZE = 0x884A;
        public const GLuint GL_DEPTH_TEXTURE_MODE = 0x884B;
        public const GLuint GL_TEXTURE_COMPARE_MODE = 0x884C;
        public const GLuint GL_TEXTURE_COMPARE_FUNC = 0x884D;
        public const GLuint GL_COMPARE_R_TO_TEXTURE = 0x884E;
        public const GLuint GL_BUFFER_SIZE = 0x8764;
        public const GLuint GL_BUFFER_USAGE = 0x8765;
        public const GLuint GL_QUERY_COUNTER_BITS = 0x8864;
        public const GLuint GL_CURRENT_QUERY = 0x8865;
        public const GLuint GL_QUERY_RESULT = 0x8866;
        public const GLuint GL_QUERY_RESULT_AVAILABLE = 0x8867;
        public const GLuint GL_ARRAY_BUFFER = 0x8892;
        public const GLuint GL_ELEMENT_ARRAY_BUFFER = 0x8893;
        public const GLuint GL_ARRAY_BUFFER_BINDING = 0x8894;
        public const GLuint GL_ELEMENT_ARRAY_BUFFER_BINDING = 0x8895;
        public const GLuint GL_VERTEX_ARRAY_BUFFER_BINDING = 0x8896;
        public const GLuint GL_NORMAL_ARRAY_BUFFER_BINDING = 0x8897;
        public const GLuint GL_COLOR_ARRAY_BUFFER_BINDING = 0x8898;
        public const GLuint GL_INDEX_ARRAY_BUFFER_BINDING = 0x8899;
        public const GLuint GL_TEXTURE_COORD_ARRAY_BUFFER_BINDING = 0x889A;
        public const GLuint GL_EDGE_FLAG_ARRAY_BUFFER_BINDING = 0x889B;
        public const GLuint GL_SECONDARY_COLOR_ARRAY_BUFFER_BINDING = 0x889C;
        public const GLuint GL_FOG_COORDINATE_ARRAY_BUFFER_BINDING = 0x889D;
        public const GLuint GL_WEIGHT_ARRAY_BUFFER_BINDING = 0x889E;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F;
        public const GLuint GL_READ_ONLY = 0x88B8;
        public const GLuint GL_WRITE_ONLY = 0x88B9;
        public const GLuint GL_READ_WRITE = 0x88BA;
        public const GLuint GL_BUFFER_ACCESS = 0x88BB;
        public const GLuint GL_BUFFER_MAPPED = 0x88BC;
        public const GLuint GL_BUFFER_MAP_POINTER = 0x88BD;
        public const GLuint GL_STREAM_DRAW = 0x88E0;
        public const GLuint GL_STREAM_READ = 0x88E1;
        public const GLuint GL_STREAM_COPY = 0x88E2;
        public const GLuint GL_STATIC_DRAW = 0x88E4;
        public const GLuint GL_STATIC_READ = 0x88E5;
        public const GLuint GL_STATIC_COPY = 0x88E6;
        public const GLuint GL_DYNAMIC_DRAW = 0x88E8;
        public const GLuint GL_DYNAMIC_READ = 0x88E9;
        public const GLuint GL_DYNAMIC_COPY = 0x88EA;
        public const GLuint GL_SAMPLES_PASSED = 0x8914;
        public const GLuint GL_FOG_COORD_SRC = GL_FOG_COORDINATE_SOURCE;
        public const GLuint GL_FOG_COORD = GL_FOG_COORDINATE;
        public const GLuint GL_CURRENT_FOG_COORD = GL_CURRENT_FOG_COORDINATE;
        public const GLuint GL_FOG_COORD_ARRAY_TYPE = GL_FOG_COORDINATE_ARRAY_TYPE;
        public const GLuint GL_FOG_COORD_ARRAY_STRIDE = GL_FOG_COORDINATE_ARRAY_STRIDE;
        public const GLuint GL_FOG_COORD_ARRAY_POINTER = GL_FOG_COORDINATE_ARRAY_POINTER;
        public const GLuint GL_FOG_COORD_ARRAY = GL_FOG_COORDINATE_ARRAY;
        public const GLuint GL_FOG_COORD_ARRAY_BUFFER_BINDING = GL_FOG_COORDINATE_ARRAY_BUFFER_BINDING;
        public const GLuint GL_SRC0_RGB = GL_SOURCE0_RGB;
        public const GLuint GL_SRC1_RGB = GL_SOURCE1_RGB;
        public const GLuint GL_SRC2_RGB = GL_SOURCE2_RGB;
        public const GLuint GL_SRC0_ALPHA = GL_SOURCE0_ALPHA;
        public const GLuint GL_SRC1_ALPHA = GL_SOURCE1_ALPHA;
        public const GLuint GL_SRC2_ALPHA = GL_SOURCE2_ALPHA;
        public const GLuint GL_BLEND_EQUATION_RGB = GL_BLEND_EQUATION;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_SIZE = 0x8623;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_TYPE = 0x8625;
        public const GLuint GL_CURRENT_VERTEX_ATTRIB = 0x8626;
        public const GLuint GL_VERTEX_PROGRAM_POINT_SIZE = 0x8642;
        public const GLuint GL_VERTEX_PROGRAM_TWO_SIDE = 0x8643;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_POINTER = 0x8645;
        public const GLuint GL_STENCIL_BACK_FUNC = 0x8800;
        public const GLuint GL_STENCIL_BACK_FAIL = 0x8801;
        public const GLuint GL_STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802;
        public const GLuint GL_STENCIL_BACK_PASS_DEPTH_PASS = 0x8803;
        public const GLuint GL_MAX_DRAW_BUFFERS = 0x8824;
        public const GLuint GL_DRAW_BUFFER0 = 0x8825;
        public const GLuint GL_DRAW_BUFFER1 = 0x8826;
        public const GLuint GL_DRAW_BUFFER2 = 0x8827;
        public const GLuint GL_DRAW_BUFFER3 = 0x8828;
        public const GLuint GL_DRAW_BUFFER4 = 0x8829;
        public const GLuint GL_DRAW_BUFFER5 = 0x882A;
        public const GLuint GL_DRAW_BUFFER6 = 0x882B;
        public const GLuint GL_DRAW_BUFFER7 = 0x882C;
        public const GLuint GL_DRAW_BUFFER8 = 0x882D;
        public const GLuint GL_DRAW_BUFFER9 = 0x882E;
        public const GLuint GL_DRAW_BUFFER10 = 0x882F;
        public const GLuint GL_DRAW_BUFFER11 = 0x8830;
        public const GLuint GL_DRAW_BUFFER12 = 0x8831;
        public const GLuint GL_DRAW_BUFFER13 = 0x8832;
        public const GLuint GL_DRAW_BUFFER14 = 0x8833;
        public const GLuint GL_DRAW_BUFFER15 = 0x8834;
        public const GLuint GL_BLEND_EQUATION_ALPHA = 0x883D;
        public const GLuint GL_POINT_SPRITE = 0x8861;
        public const GLuint GL_COORD_REPLACE = 0x8862;
        public const GLuint GL_MAX_VERTEX_ATTRIBS = 0x8869;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A;
        public const GLuint GL_MAX_TEXTURE_COORDS = 0x8871;
        public const GLuint GL_MAX_TEXTURE_IMAGE_UNITS = 0x8872;
        public const GLuint GL_FRAGMENT_SHADER = 0x8B30;
        public const GLuint GL_VERTEX_SHADER = 0x8B31;
        public const GLuint GL_MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49;
        public const GLuint GL_MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A;
        public const GLuint GL_MAX_VARYING_FLOATS = 0x8B4B;
        public const GLuint GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C;
        public const GLuint GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D;
        public const GLuint GL_SHADER_TYPE = 0x8B4F;
        public const GLuint GL_FLOAT_VEC2 = 0x8B50;
        public const GLuint GL_FLOAT_VEC3 = 0x8B51;
        public const GLuint GL_FLOAT_VEC4 = 0x8B52;
        public const GLuint GL_INT_VEC2 = 0x8B53;
        public const GLuint GL_INT_VEC3 = 0x8B54;
        public const GLuint GL_INT_VEC4 = 0x8B55;
        public const GLuint GL_BOOL = 0x8B56;
        public const GLuint GL_BOOL_VEC2 = 0x8B57;
        public const GLuint GL_BOOL_VEC3 = 0x8B58;
        public const GLuint GL_BOOL_VEC4 = 0x8B59;
        public const GLuint GL_FLOAT_MAT2 = 0x8B5A;
        public const GLuint GL_FLOAT_MAT3 = 0x8B5B;
        public const GLuint GL_FLOAT_MAT4 = 0x8B5C;
        public const GLuint GL_SAMPLER_1D = 0x8B5D;
        public const GLuint GL_SAMPLER_2D = 0x8B5E;
        public const GLuint GL_SAMPLER_3D = 0x8B5F;
        public const GLuint GL_SAMPLER_CUBE = 0x8B60;
        public const GLuint GL_SAMPLER_1D_SHADOW = 0x8B61;
        public const GLuint GL_SAMPLER_2D_SHADOW = 0x8B62;
        public const GLuint GL_DELETE_STATUS = 0x8B80;
        public const GLuint GL_COMPILE_STATUS = 0x8B81;
        public const GLuint GL_LINK_STATUS = 0x8B82;
        public const GLuint GL_VALIDATE_STATUS = 0x8B83;
        public const GLuint GL_INFO_LOG_LENGTH = 0x8B84;
        public const GLuint GL_ATTACHED_SHADERS = 0x8B85;
        public const GLuint GL_ACTIVE_UNIFORMS = 0x8B86;
        public const GLuint GL_ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87;
        public const GLuint GL_SHADER_SOURCE_LENGTH = 0x8B88;
        public const GLuint GL_ACTIVE_ATTRIBUTES = 0x8B89;
        public const GLuint GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A;
        public const GLuint GL_FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8B;
        public const GLuint GL_SHADING_LANGUAGE_VERSION = 0x8B8C;
        public const GLuint GL_CURRENT_PROGRAM = 0x8B8D;
        public const GLuint GL_POINT_SPRITE_COORD_ORIGIN = 0x8CA0;
        public const GLuint GL_LOWER_LEFT = 0x8CA1;
        public const GLuint GL_UPPER_LEFT = 0x8CA2;
        public const GLuint GL_STENCIL_BACK_REF = 0x8CA3;
        public const GLuint GL_STENCIL_BACK_VALUE_MASK = 0x8CA4;
        public const GLuint GL_STENCIL_BACK_WRITEMASK = 0x8CA5;
        public const GLuint GL_TEXTURE0_ARB = 0x84C0;
        public const GLuint GL_TEXTURE1_ARB = 0x84C1;
        public const GLuint GL_TEXTURE2_ARB = 0x84C2;
        public const GLuint GL_TEXTURE3_ARB = 0x84C3;
        public const GLuint GL_TEXTURE4_ARB = 0x84C4;
        public const GLuint GL_TEXTURE5_ARB = 0x84C5;
        public const GLuint GL_TEXTURE6_ARB = 0x84C6;
        public const GLuint GL_TEXTURE7_ARB = 0x84C7;
        public const GLuint GL_TEXTURE8_ARB = 0x84C8;
        public const GLuint GL_TEXTURE9_ARB = 0x84C9;
        public const GLuint GL_TEXTURE10_ARB = 0x84CA;
        public const GLuint GL_TEXTURE11_ARB = 0x84CB;
        public const GLuint GL_TEXTURE12_ARB = 0x84CC;
        public const GLuint GL_TEXTURE13_ARB = 0x84CD;
        public const GLuint GL_TEXTURE14_ARB = 0x84CE;
        public const GLuint GL_TEXTURE15_ARB = 0x84CF;
        public const GLuint GL_TEXTURE16_ARB = 0x84D0;
        public const GLuint GL_TEXTURE17_ARB = 0x84D1;
        public const GLuint GL_TEXTURE18_ARB = 0x84D2;
        public const GLuint GL_TEXTURE19_ARB = 0x84D3;
        public const GLuint GL_TEXTURE20_ARB = 0x84D4;
        public const GLuint GL_TEXTURE21_ARB = 0x84D5;
        public const GLuint GL_TEXTURE22_ARB = 0x84D6;
        public const GLuint GL_TEXTURE23_ARB = 0x84D7;
        public const GLuint GL_TEXTURE24_ARB = 0x84D8;
        public const GLuint GL_TEXTURE25_ARB = 0x84D9;
        public const GLuint GL_TEXTURE26_ARB = 0x84DA;
        public const GLuint GL_TEXTURE27_ARB = 0x84DB;
        public const GLuint GL_TEXTURE28_ARB = 0x84DC;
        public const GLuint GL_TEXTURE29_ARB = 0x84DD;
        public const GLuint GL_TEXTURE30_ARB = 0x84DE;
        public const GLuint GL_TEXTURE31_ARB = 0x84DF;
        public const GLuint GL_ACTIVE_TEXTURE_ARB = 0x84E0;
        public const GLuint GL_CLIENT_ACTIVE_TEXTURE_ARB = 0x84E1;
        public const GLuint GL_MAX_TEXTURE_UNITS_ARB = 0x84E2;
        public const GLuint GL_TRANSPOSE_MODELVIEW_MATRIX_ARB = 0x84E3;
        public const GLuint GL_TRANSPOSE_PROJECTION_MATRIX_ARB = 0x84E4;
        public const GLuint GL_TRANSPOSE_TEXTURE_MATRIX_ARB = 0x84E5;
        public const GLuint GL_TRANSPOSE_COLOR_MATRIX_ARB = 0x84E6;
        public const GLuint GL_MULTISAMPLE_BIT_ARB = 0x20000000;
        public const GLuint GL_NORMAL_MAP_ARB = 0x8511;
        public const GLuint GL_REFLECTION_MAP_ARB = 0x8512;
        public const GLuint GL_TEXTURE_CUBE_MAP_ARB = 0x8513;
        public const GLuint GL_TEXTURE_BINDING_CUBE_MAP_ARB = 0x8514;
        public const GLuint GL_TEXTURE_CUBE_MAP_POSITIVE_X_ARB = 0x8515;
        public const GLuint GL_TEXTURE_CUBE_MAP_NEGATIVE_X_ARB = 0x8516;
        public const GLuint GL_TEXTURE_CUBE_MAP_POSITIVE_Y_ARB = 0x8517;
        public const GLuint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y_ARB = 0x8518;
        public const GLuint GL_TEXTURE_CUBE_MAP_POSITIVE_Z_ARB = 0x8519;
        public const GLuint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z_ARB = 0x851A;
        public const GLuint GL_PROXY_TEXTURE_CUBE_MAP_ARB = 0x851B;
        public const GLuint GL_MAX_CUBE_MAP_TEXTURE_SIZE_ARB = 0x851C;
        public const GLuint GL_COMPRESSED_ALPHA_ARB = 0x84E9;
        public const GLuint GL_COMPRESSED_LUMINANCE_ARB = 0x84EA;
        public const GLuint GL_COMPRESSED_LUMINANCE_ALPHA_ARB = 0x84EB;
        public const GLuint GL_COMPRESSED_INTENSITY_ARB = 0x84EC;
        public const GLuint GL_COMPRESSED_RGB_ARB = 0x84ED;
        public const GLuint GL_COMPRESSED_RGBA_ARB = 0x84EE;
        public const GLuint GL_TEXTURE_COMPRESSION_HINT_ARB = 0x84EF;
        public const GLuint GL_TEXTURE_COMPRESSED_IMAGE_SIZE_ARB = 0x86A0;
        public const GLuint GL_TEXTURE_COMPRESSED_ARB = 0x86A1;
        public const GLuint GL_NUM_COMPRESSED_TEXTURE_FORMATS_ARB = 0x86A2;
        public const GLuint GL_COMPRESSED_TEXTURE_FORMATS_ARB = 0x86A3;
        public const GLuint GL_MAX_VERTEX_UNITS_ARB = 0x86A4;
        public const GLuint GL_ACTIVE_VERTEX_UNITS_ARB = 0x86A5;
        public const GLuint GL_WEIGHT_SUM_UNITY_ARB = 0x86A6;
        public const GLuint GL_VERTEX_BLEND_ARB = 0x86A7;
        public const GLuint GL_CURRENT_WEIGHT_ARB = 0x86A8;
        public const GLuint GL_WEIGHT_ARRAY_TYPE_ARB = 0x86A9;
        public const GLuint GL_WEIGHT_ARRAY_STRIDE_ARB = 0x86AA;
        public const GLuint GL_WEIGHT_ARRAY_SIZE_ARB = 0x86AB;
        public const GLuint GL_WEIGHT_ARRAY_POINTER_ARB = 0x86AC;
        public const GLuint GL_WEIGHT_ARRAY_ARB = 0x86AD;
        public const GLuint GL_MODELVIEW0_ARB = 0x1700;
        public const GLuint GL_MODELVIEW1_ARB = 0x850A;
        public const GLuint GL_MODELVIEW2_ARB = 0x8722;
        public const GLuint GL_MODELVIEW3_ARB = 0x8723;
        public const GLuint GL_MODELVIEW4_ARB = 0x8724;
        public const GLuint GL_MODELVIEW5_ARB = 0x8725;
        public const GLuint GL_MODELVIEW6_ARB = 0x8726;
        public const GLuint GL_MODELVIEW7_ARB = 0x8727;
        public const GLuint GL_MODELVIEW8_ARB = 0x8728;
        public const GLuint GL_MODELVIEW9_ARB = 0x8729;
        public const GLuint GL_MODELVIEW10_ARB = 0x872A;
        public const GLuint GL_MODELVIEW11_ARB = 0x872B;
        public const GLuint GL_MODELVIEW12_ARB = 0x872C;
        public const GLuint GL_MODELVIEW13_ARB = 0x872D;
        public const GLuint GL_MODELVIEW14_ARB = 0x872E;
        public const GLuint GL_MODELVIEW15_ARB = 0x872F;
        public const GLuint GL_MODELVIEW16_ARB = 0x8730;
        public const GLuint GL_MODELVIEW17_ARB = 0x8731;
        public const GLuint GL_MODELVIEW18_ARB = 0x8732;
        public const GLuint GL_MODELVIEW19_ARB = 0x8733;
        public const GLuint GL_MODELVIEW20_ARB = 0x8734;
        public const GLuint GL_MODELVIEW21_ARB = 0x8735;
        public const GLuint GL_MODELVIEW22_ARB = 0x8736;
        public const GLuint GL_MODELVIEW23_ARB = 0x8737;
        public const GLuint GL_MODELVIEW24_ARB = 0x8738;
        public const GLuint GL_MODELVIEW25_ARB = 0x8739;
        public const GLuint GL_MODELVIEW26_ARB = 0x873A;
        public const GLuint GL_MODELVIEW27_ARB = 0x873B;
        public const GLuint GL_MODELVIEW28_ARB = 0x873C;
        public const GLuint GL_MODELVIEW29_ARB = 0x873D;
        public const GLuint GL_MODELVIEW30_ARB = 0x873E;
        public const GLuint GL_MODELVIEW31_ARB = 0x873F;
        public const GLuint GL_MATRIX_PALETTE_ARB = 0x8840;
        public const GLuint GL_MAX_MATRIX_PALETTE_STACK_DEPTH_ARB = 0x8841;
        public const GLuint GL_MAX_PALETTE_MATRICES_ARB = 0x8842;
        public const GLuint GL_CURRENT_PALETTE_MATRIX_ARB = 0x8843;
        public const GLuint GL_MATRIX_INDEX_ARRAY_ARB = 0x8844;
        public const GLuint GL_CURRENT_MATRIX_INDEX_ARB = 0x8845;
        public const GLuint GL_MATRIX_INDEX_ARRAY_SIZE_ARB = 0x8846;
        public const GLuint GL_MATRIX_INDEX_ARRAY_TYPE_ARB = 0x8847;
        public const GLuint GL_MATRIX_INDEX_ARRAY_STRIDE_ARB = 0x8848;
        public const GLuint GL_MATRIX_INDEX_ARRAY_POINTER_ARB = 0x8849;
        public const GLuint GL_COMBINE_ARB = 0x8570;
        public const GLuint GL_COMBINE_RGB_ARB = 0x8571;
        public const GLuint GL_COMBINE_ALPHA_ARB = 0x8572;
        public const GLuint GL_SOURCE0_RGB_ARB = 0x8580;
        public const GLuint GL_SOURCE1_RGB_ARB = 0x8581;
        public const GLuint GL_SOURCE2_RGB_ARB = 0x8582;
        public const GLuint GL_SOURCE0_ALPHA_ARB = 0x8588;
        public const GLuint GL_SOURCE1_ALPHA_ARB = 0x8589;
        public const GLuint GL_SOURCE2_ALPHA_ARB = 0x858A;
        public const GLuint GL_OPERAND0_RGB_ARB = 0x8590;
        public const GLuint GL_OPERAND1_RGB_ARB = 0x8591;
        public const GLuint GL_OPERAND2_RGB_ARB = 0x8592;
        public const GLuint GL_OPERAND0_ALPHA_ARB = 0x8598;
        public const GLuint GL_OPERAND1_ALPHA_ARB = 0x8599;
        public const GLuint GL_OPERAND2_ALPHA_ARB = 0x859A;
        public const GLuint GL_RGB_SCALE_ARB = 0x8573;
        public const GLuint GL_ADD_SIGNED_ARB = 0x8574;
        public const GLuint GL_INTERPOLATE_ARB = 0x8575;
        public const GLuint GL_SUBTRACT_ARB = 0x84E7;
        public const GLuint GL_CONSTANT_ARB = 0x8576;
        public const GLuint GL_PRIMARY_COLOR_ARB = 0x8577;
        public const GLuint GL_PREVIOUS_ARB = 0x8578;
        public const GLuint GL_DOT3_RGB_ARB = 0x86AE;
        public const GLuint GL_DOT3_RGBA_ARB = 0x86AF;
        public const GLuint GL_MIRRORED_REPEAT_ARB = 0x8370;
        public const GLuint GL_DEPTH_COMPONENT16_ARB = 0x81A5;
        public const GLuint GL_DEPTH_COMPONENT24_ARB = 0x81A6;
        public const GLuint GL_DEPTH_COMPONENT32_ARB = 0x81A7;
        public const GLuint GL_TEXTURE_DEPTH_SIZE_ARB = 0x884A;
        public const GLuint GL_DEPTH_TEXTURE_MODE_ARB = 0x884B;
        public const GLuint GL_TEXTURE_COMPARE_MODE_ARB = 0x884C;
        public const GLuint GL_TEXTURE_COMPARE_FUNC_ARB = 0x884D;
        public const GLuint GL_COMPARE_R_TO_TEXTURE_ARB = 0x884E;
        public const GLuint GL_TEXTURE_COMPARE_FAIL_VALUE_ARB = 0x80BF;
        public const GLuint GL_COLOR_SUM_ARB = 0x8458;
        public const GLuint GL_VERTEX_PROGRAM_ARB = 0x8620;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_ENABLED_ARB = 0x8622;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_SIZE_ARB = 0x8623;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_STRIDE_ARB = 0x8624;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_TYPE_ARB = 0x8625;
        public const GLuint GL_CURRENT_VERTEX_ATTRIB_ARB = 0x8626;
        public const GLuint GL_PROGRAM_LENGTH_ARB = 0x8627;
        public const GLuint GL_PROGRAM_STRING_ARB = 0x8628;
        public const GLuint GL_MAX_PROGRAM_MATRIX_STACK_DEPTH_ARB = 0x862E;
        public const GLuint GL_MAX_PROGRAM_MATRICES_ARB = 0x862F;
        public const GLuint GL_CURRENT_MATRIX_STACK_DEPTH_ARB = 0x8640;
        public const GLuint GL_CURRENT_MATRIX_ARB = 0x8641;
        public const GLuint GL_VERTEX_PROGRAM_POINT_SIZE_ARB = 0x8642;
        public const GLuint GL_VERTEX_PROGRAM_TWO_SIDE_ARB = 0x8643;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_POINTER_ARB = 0x8645;
        public const GLuint GL_PROGRAM_ERROR_POSITION_ARB = 0x864B;
        public const GLuint GL_PROGRAM_BINDING_ARB = 0x8677;
        public const GLuint GL_MAX_VERTEX_ATTRIBS_ARB = 0x8869;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_NORMALIZED_ARB = 0x886A;
        public const GLuint GL_PROGRAM_ERROR_STRING_ARB = 0x8874;
        public const GLuint GL_PROGRAM_FORMAT_ASCII_ARB = 0x8875;
        public const GLuint GL_PROGRAM_FORMAT_ARB = 0x8876;
        public const GLuint GL_PROGRAM_INSTRUCTIONS_ARB = 0x88A0;
        public const GLuint GL_MAX_PROGRAM_INSTRUCTIONS_ARB = 0x88A1;
        public const GLuint GL_PROGRAM_NATIVE_INSTRUCTIONS_ARB = 0x88A2;
        public const GLuint GL_MAX_PROGRAM_NATIVE_INSTRUCTIONS_ARB = 0x88A3;
        public const GLuint GL_PROGRAM_TEMPORARIES_ARB = 0x88A4;
        public const GLuint GL_MAX_PROGRAM_TEMPORARIES_ARB = 0x88A5;
        public const GLuint GL_PROGRAM_NATIVE_TEMPORARIES_ARB = 0x88A6;
        public const GLuint GL_MAX_PROGRAM_NATIVE_TEMPORARIES_ARB = 0x88A7;
        public const GLuint GL_PROGRAM_PARAMETERS_ARB = 0x88A8;
        public const GLuint GL_MAX_PROGRAM_PARAMETERS_ARB = 0x88A9;
        public const GLuint GL_PROGRAM_NATIVE_PARAMETERS_ARB = 0x88AA;
        public const GLuint GL_MAX_PROGRAM_NATIVE_PARAMETERS_ARB = 0x88AB;
        public const GLuint GL_PROGRAM_ATTRIBS_ARB = 0x88AC;
        public const GLuint GL_MAX_PROGRAM_ATTRIBS_ARB = 0x88AD;
        public const GLuint GL_PROGRAM_NATIVE_ATTRIBS_ARB = 0x88AE;
        public const GLuint GL_MAX_PROGRAM_NATIVE_ATTRIBS_ARB = 0x88AF;
        public const GLuint GL_PROGRAM_ADDRESS_REGISTERS_ARB = 0x88B0;
        public const GLuint GL_MAX_PROGRAM_ADDRESS_REGISTERS_ARB = 0x88B1;
        public const GLuint GL_PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB = 0x88B2;
        public const GLuint GL_MAX_PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB = 0x88B3;
        public const GLuint GL_MAX_PROGRAM_LOCAL_PARAMETERS_ARB = 0x88B4;
        public const GLuint GL_MAX_PROGRAM_ENV_PARAMETERS_ARB = 0x88B5;
        public const GLuint GL_PROGRAM_UNDER_NATIVE_LIMITS_ARB = 0x88B6;
        public const GLuint GL_TRANSPOSE_CURRENT_MATRIX_ARB = 0x88B7;
        public const GLuint GL_MATRIX0_ARB = 0x88C0;
        public const GLuint GL_MATRIX1_ARB = 0x88C1;
        public const GLuint GL_MATRIX2_ARB = 0x88C2;
        public const GLuint GL_MATRIX3_ARB = 0x88C3;
        public const GLuint GL_MATRIX4_ARB = 0x88C4;
        public const GLuint GL_MATRIX5_ARB = 0x88C5;
        public const GLuint GL_MATRIX6_ARB = 0x88C6;
        public const GLuint GL_MATRIX7_ARB = 0x88C7;
        public const GLuint GL_MATRIX8_ARB = 0x88C8;
        public const GLuint GL_MATRIX9_ARB = 0x88C9;
        public const GLuint GL_MATRIX10_ARB = 0x88CA;
        public const GLuint GL_MATRIX11_ARB = 0x88CB;
        public const GLuint GL_MATRIX12_ARB = 0x88CC;
        public const GLuint GL_MATRIX13_ARB = 0x88CD;
        public const GLuint GL_MATRIX14_ARB = 0x88CE;
        public const GLuint GL_MATRIX15_ARB = 0x88CF;
        public const GLuint GL_MATRIX16_ARB = 0x88D0;
        public const GLuint GL_MATRIX17_ARB = 0x88D1;
        public const GLuint GL_MATRIX18_ARB = 0x88D2;
        public const GLuint GL_MATRIX19_ARB = 0x88D3;
        public const GLuint GL_MATRIX20_ARB = 0x88D4;
        public const GLuint GL_MATRIX21_ARB = 0x88D5;
        public const GLuint GL_MATRIX22_ARB = 0x88D6;
        public const GLuint GL_MATRIX23_ARB = 0x88D7;
        public const GLuint GL_MATRIX24_ARB = 0x88D8;
        public const GLuint GL_MATRIX25_ARB = 0x88D9;
        public const GLuint GL_MATRIX26_ARB = 0x88DA;
        public const GLuint GL_MATRIX27_ARB = 0x88DB;
        public const GLuint GL_MATRIX28_ARB = 0x88DC;
        public const GLuint GL_MATRIX29_ARB = 0x88DD;
        public const GLuint GL_MATRIX30_ARB = 0x88DE;
        public const GLuint GL_MATRIX31_ARB = 0x88DF;
        public const GLuint GL_FRAGMENT_PROGRAM_ARB = 0x8804;
        public const GLuint GL_PROGRAM_ALU_INSTRUCTIONS_ARB = 0x8805;
        public const GLuint GL_PROGRAM_TEX_INSTRUCTIONS_ARB = 0x8806;
        public const GLuint GL_PROGRAM_TEX_INDIRECTIONS_ARB = 0x8807;
        public const GLuint GL_PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB = 0x8808;
        public const GLuint GL_PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB = 0x8809;
        public const GLuint GL_PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB = 0x880A;
        public const GLuint GL_MAX_PROGRAM_ALU_INSTRUCTIONS_ARB = 0x880B;
        public const GLuint GL_MAX_PROGRAM_TEX_INSTRUCTIONS_ARB = 0x880C;
        public const GLuint GL_MAX_PROGRAM_TEX_INDIRECTIONS_ARB = 0x880D;
        public const GLuint GL_MAX_PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB = 0x880E;
        public const GLuint GL_MAX_PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB = 0x880F;
        public const GLuint GL_MAX_PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB = 0x8810;
        public const GLuint GL_MAX_TEXTURE_COORDS_ARB = 0x8871;
        public const GLuint GL_MAX_TEXTURE_IMAGE_UNITS_ARB = 0x8872;
        public const GLuint GL_BUFFER_SIZE_ARB = 0x8764;
        public const GLuint GL_BUFFER_USAGE_ARB = 0x8765;
        public const GLuint GL_ARRAY_BUFFER_ARB = 0x8892;
        public const GLuint GL_ELEMENT_ARRAY_BUFFER_ARB = 0x8893;
        public const GLuint GL_ARRAY_BUFFER_BINDING_ARB = 0x8894;
        public const GLuint GL_ELEMENT_ARRAY_BUFFER_BINDING_ARB = 0x8895;
        public const GLuint GL_VERTEX_ARRAY_BUFFER_BINDING_ARB = 0x8896;
        public const GLuint GL_NORMAL_ARRAY_BUFFER_BINDING_ARB = 0x8897;
        public const GLuint GL_COLOR_ARRAY_BUFFER_BINDING_ARB = 0x8898;
        public const GLuint GL_INDEX_ARRAY_BUFFER_BINDING_ARB = 0x8899;
        public const GLuint GL_TEXTURE_COORD_ARRAY_BUFFER_BINDING_ARB = 0x889A;
        public const GLuint GL_EDGE_FLAG_ARRAY_BUFFER_BINDING_ARB = 0x889B;
        public const GLuint GL_SECONDARY_COLOR_ARRAY_BUFFER_BINDING_ARB = 0x889C;
        public const GLuint GL_FOG_COORDINATE_ARRAY_BUFFER_BINDING_ARB = 0x889D;
        public const GLuint GL_WEIGHT_ARRAY_BUFFER_BINDING_ARB = 0x889E;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING_ARB = 0x889F;
        public const GLuint GL_READ_ONLY_ARB = 0x88B8;
        public const GLuint GL_WRITE_ONLY_ARB = 0x88B9;
        public const GLuint GL_READ_WRITE_ARB = 0x88BA;
        public const GLuint GL_BUFFER_ACCESS_ARB = 0x88BB;
        public const GLuint GL_BUFFER_MAPPED_ARB = 0x88BC;
        public const GLuint GL_BUFFER_MAP_POINTER_ARB = 0x88BD;
        public const GLuint GL_STREAM_DRAW_ARB = 0x88E0;
        public const GLuint GL_STREAM_READ_ARB = 0x88E1;
        public const GLuint GL_STREAM_COPY_ARB = 0x88E2;
        public const GLuint GL_STATIC_DRAW_ARB = 0x88E4;
        public const GLuint GL_STATIC_READ_ARB = 0x88E5;
        public const GLuint GL_STATIC_COPY_ARB = 0x88E6;
        public const GLuint GL_DYNAMIC_DRAW_ARB = 0x88E8;
        public const GLuint GL_DYNAMIC_READ_ARB = 0x88E9;
        public const GLuint GL_DYNAMIC_COPY_ARB = 0x88EA;
        public const GLuint GL_QUERY_COUNTER_BITS_ARB = 0x8864;
        public const GLuint GL_CURRENT_QUERY_ARB = 0x8865;
        public const GLuint GL_QUERY_RESULT_ARB = 0x8866;
        public const GLuint GL_QUERY_RESULT_AVAILABLE_ARB = 0x8867;
        public const GLuint GL_SAMPLES_PASSED_ARB = 0x8914;
        public const GLuint GL_PROGRAM_OBJECT_ARB = 0x8B40;
        public const GLuint GL_SHADER_OBJECT_ARB = 0x8B48;
        public const GLuint GL_OBJECT_TYPE_ARB = 0x8B4E;
        public const GLuint GL_OBJECT_SUBTYPE_ARB = 0x8B4F;
        public const GLuint GL_FLOAT_VEC2_ARB = 0x8B50;
        public const GLuint GL_FLOAT_VEC3_ARB = 0x8B51;
        public const GLuint GL_FLOAT_VEC4_ARB = 0x8B52;
        public const GLuint GL_INT_VEC2_ARB = 0x8B53;
        public const GLuint GL_INT_VEC3_ARB = 0x8B54;
        public const GLuint GL_INT_VEC4_ARB = 0x8B55;
        public const GLuint GL_BOOL_ARB = 0x8B56;
        public const GLuint GL_BOOL_VEC2_ARB = 0x8B57;
        public const GLuint GL_BOOL_VEC3_ARB = 0x8B58;
        public const GLuint GL_BOOL_VEC4_ARB = 0x8B59;
        public const GLuint GL_FLOAT_MAT2_ARB = 0x8B5A;
        public const GLuint GL_FLOAT_MAT3_ARB = 0x8B5B;
        public const GLuint GL_FLOAT_MAT4_ARB = 0x8B5C;
        public const GLuint GL_SAMPLER_1D_ARB = 0x8B5D;
        public const GLuint GL_SAMPLER_2D_ARB = 0x8B5E;
        public const GLuint GL_SAMPLER_3D_ARB = 0x8B5F;
        public const GLuint GL_SAMPLER_CUBE_ARB = 0x8B60;
        public const GLuint GL_SAMPLER_1D_SHADOW_ARB = 0x8B61;
        public const GLuint GL_SAMPLER_2D_SHADOW_ARB = 0x8B62;
        public const GLuint GL_SAMPLER_2D_RECT_ARB = 0x8B63;
        public const GLuint GL_SAMPLER_2D_RECT_SHADOW_ARB = 0x8B64;
        public const GLuint GL_OBJECT_DELETE_STATUS_ARB = 0x8B80;
        public const GLuint GL_OBJECT_COMPILE_STATUS_ARB = 0x8B81;
        public const GLuint GL_OBJECT_LINK_STATUS_ARB = 0x8B82;
        public const GLuint GL_OBJECT_VALIDATE_STATUS_ARB = 0x8B83;
        public const GLuint GL_OBJECT_INFO_LOG_LENGTH_ARB = 0x8B84;
        public const GLuint GL_OBJECT_ATTACHED_OBJECTS_ARB = 0x8B85;
        public const GLuint GL_OBJECT_ACTIVE_UNIFORMS_ARB = 0x8B86;
        public const GLuint GL_OBJECT_ACTIVE_UNIFORM_MAX_LENGTH_ARB = 0x8B87;
        public const GLuint GL_OBJECT_SHADER_SOURCE_LENGTH_ARB = 0x8B88;
        public const GLuint GL_VERTEX_SHADER_ARB = 0x8B31;
        public const GLuint GL_MAX_VERTEX_UNIFORM_COMPONENTS_ARB = 0x8B4A;
        public const GLuint GL_MAX_VARYING_FLOATS_ARB = 0x8B4B;
        public const GLuint GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS_ARB = 0x8B4C;
        public const GLuint GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS_ARB = 0x8B4D;
        public const GLuint GL_OBJECT_ACTIVE_ATTRIBUTES_ARB = 0x8B89;
        public const GLuint GL_OBJECT_ACTIVE_ATTRIBUTE_MAX_LENGTH_ARB = 0x8B8A;
        public const GLuint GL_FRAGMENT_SHADER_ARB = 0x8B30;
        public const GLuint GL_MAX_FRAGMENT_UNIFORM_COMPONENTS_ARB = 0x8B49;
        public const GLuint GL_FRAGMENT_SHADER_DERIVATIVE_HINT_ARB = 0x8B8B;
        public const GLuint GL_SHADING_LANGUAGE_VERSION_ARB = 0x8B8C;
        public const GLuint GL_POINT_SPRITE_ARB = 0x8861;
        public const GLuint GL_COORD_REPLACE_ARB = 0x8862;
        public const GLuint GL_MAX_DRAW_BUFFERS_ARB = 0x8824;
        public const GLuint GL_DRAW_BUFFER0_ARB = 0x8825;
        public const GLuint GL_DRAW_BUFFER1_ARB = 0x8826;
        public const GLuint GL_DRAW_BUFFER2_ARB = 0x8827;
        public const GLuint GL_DRAW_BUFFER3_ARB = 0x8828;
        public const GLuint GL_DRAW_BUFFER4_ARB = 0x8829;
        public const GLuint GL_DRAW_BUFFER5_ARB = 0x882A;
        public const GLuint GL_DRAW_BUFFER6_ARB = 0x882B;
        public const GLuint GL_DRAW_BUFFER7_ARB = 0x882C;
        public const GLuint GL_DRAW_BUFFER8_ARB = 0x882D;
        public const GLuint GL_DRAW_BUFFER9_ARB = 0x882E;
        public const GLuint GL_DRAW_BUFFER10_ARB = 0x882F;
        public const GLuint GL_DRAW_BUFFER11_ARB = 0x8830;
        public const GLuint GL_DRAW_BUFFER12_ARB = 0x8831;
        public const GLuint GL_DRAW_BUFFER13_ARB = 0x8832;
        public const GLuint GL_DRAW_BUFFER14_ARB = 0x8833;
        public const GLuint GL_DRAW_BUFFER15_ARB = 0x8834;
        public const GLuint GL_TEXTURE_RECTANGLE_ARB = 0x84F5;
        public const GLuint GL_TEXTURE_BINDING_RECTANGLE_ARB = 0x84F6;
        public const GLuint GL_PROXY_TEXTURE_RECTANGLE_ARB = 0x84F7;
        public const GLuint GL_MAX_RECTANGLE_TEXTURE_SIZE_ARB = 0x84F8;
        public const GLuint GL_RGBA_FLOAT_MODE_ARB = 0x8820;
        public const GLuint GL_CLAMP_VERTEX_COLOR_ARB = 0x891A;
        public const GLuint GL_CLAMP_FRAGMENT_COLOR_ARB = 0x891B;
        public const GLuint GL_CLAMP_READ_COLOR_ARB = 0x891C;
        public const GLuint GL_FIXED_ONLY_ARB = 0x891D;
        public const GLuint GL_HALF_FLOAT_ARB = 0x140B;
        public const GLuint GL_TEXTURE_RED_TYPE_ARB = 0x8C10;
        public const GLuint GL_TEXTURE_GREEN_TYPE_ARB = 0x8C11;
        public const GLuint GL_TEXTURE_BLUE_TYPE_ARB = 0x8C12;
        public const GLuint GL_TEXTURE_ALPHA_TYPE_ARB = 0x8C13;
        public const GLuint GL_TEXTURE_LUMINANCE_TYPE_ARB = 0x8C14;
        public const GLuint GL_TEXTURE_INTENSITY_TYPE_ARB = 0x8C15;
        public const GLuint GL_TEXTURE_DEPTH_TYPE_ARB = 0x8C16;
        public const GLuint GL_UNSIGNED_NORMALIZED_ARB = 0x8C17;
        public const GLuint GL_RGBA32F_ARB = 0x8814;
        public const GLuint GL_RGB32F_ARB = 0x8815;
        public const GLuint GL_ALPHA32F_ARB = 0x8816;
        public const GLuint GL_INTENSITY32F_ARB = 0x8817;
        public const GLuint GL_LUMINANCE32F_ARB = 0x8818;
        public const GLuint GL_LUMINANCE_ALPHA32F_ARB = 0x8819;
        public const GLuint GL_RGBA16F_ARB = 0x881A;
        public const GLuint GL_RGB16F_ARB = 0x881B;
        public const GLuint GL_ALPHA16F_ARB = 0x881C;
        public const GLuint GL_INTENSITY16F_ARB = 0x881D;
        public const GLuint GL_LUMINANCE16F_ARB = 0x881E;
        public const GLuint GL_LUMINANCE_ALPHA16F_ARB = 0x881F;
        public const GLuint GL_PIXEL_PACK_BUFFER_ARB = 0x88EB;
        public const GLuint GL_PIXEL_UNPACK_BUFFER_ARB = 0x88EC;
        public const GLuint GL_PIXEL_PACK_BUFFER_BINDING_ARB = 0x88ED;
        public const GLuint GL_PIXEL_UNPACK_BUFFER_BINDING_ARB = 0x88EF;
        public const GLuint GL_IMAGE_SCALE_X_HP = 0x8155;
        public const GLuint GL_IMAGE_SCALE_Y_HP = 0x8156;
        public const GLuint GL_IMAGE_TRANSLATE_X_HP = 0x8157;
        public const GLuint GL_IMAGE_TRANSLATE_Y_HP = 0x8158;
        public const GLuint GL_IMAGE_ROTATE_ANGLE_HP = 0x8159;
        public const GLuint GL_IMAGE_ROTATE_ORIGIN_X_HP = 0x815A;
        public const GLuint GL_IMAGE_ROTATE_ORIGIN_Y_HP = 0x815B;
        public const GLuint GL_IMAGE_MAG_FILTER_HP = 0x815C;
        public const GLuint GL_IMAGE_MIN_FILTER_HP = 0x815D;
        public const GLuint GL_IMAGE_CUBIC_WEIGHT_HP = 0x815E;
        public const GLuint GL_CUBIC_HP = 0x815F;
        public const GLuint GL_AVERAGE_HP = 0x8160;
        public const GLuint GL_IMAGE_TRANSFORM_2D_HP = 0x8161;
        public const GLuint GL_POST_IMAGE_TRANSFORM_COLOR_TABLE_HP = 0x8162;
        public const GLuint GL_PROXY_POST_IMAGE_TRANSFORM_COLOR_TABLE_HP = 0x8163;
        public const GLuint GL_VERTEX_DATA_HINT_PGI = 0x1A22A;
        public const GLuint GL_VERTEX_CONSISTENT_HINT_PGI = 0x1A22B;
        public const GLuint GL_MATERIAL_SIDE_HINT_PGI = 0x1A22C;
        public const GLuint GL_MAX_VERTEX_HINT_PGI = 0x1A22D;
        public const GLuint GL_COLOR3_BIT_PGI = 0x00010000;
        public const GLuint GL_COLOR4_BIT_PGI = 0x00020000;
        public const GLuint GL_EDGEFLAG_BIT_PGI = 0x00040000;
        public const GLuint GL_INDEX_BIT_PGI = 0x00080000;
        public const GLuint GL_MAT_AMBIENT_BIT_PGI = 0x00100000;
        public const GLuint GL_MAT_AMBIENT_AND_DIFFUSE_BIT_PGI = 0x00200000;
        public const GLuint GL_MAT_DIFFUSE_BIT_PGI = 0x00400000;
        public const GLuint GL_MAT_EMISSION_BIT_PGI = 0x00800000;
        public const GLuint GL_MAT_COLOR_INDEXES_BIT_PGI = 0x01000000;
        public const GLuint GL_MAT_SHININESS_BIT_PGI = 0x02000000;
        public const GLuint GL_MAT_SPECULAR_BIT_PGI = 0x04000000;
        public const GLuint GL_NORMAL_BIT_PGI = 0x08000000;
        public const GLuint GL_TEXCOORD1_BIT_PGI = 0x10000000;
        public const GLuint GL_TEXCOORD2_BIT_PGI = 0x20000000;
        public const GLuint GL_TEXCOORD3_BIT_PGI = 0x40000000;
        public const GLuint GL_TEXCOORD4_BIT_PGI = unchecked((int)0x80000000);
        public const GLuint GL_VERTEX23_BIT_PGI = 0x00000004;
        public const GLuint GL_VERTEX4_BIT_PGI = 0x00000008;
        public const GLuint GL_PREFER_DOUBLEBUFFER_HINT_PGI = 0x1A1F8;
        public const GLuint GL_CONSERVE_MEMORY_HINT_PGI = 0x1A1FD;
        public const GLuint GL_RECLAIM_MEMORY_HINT_PGI = 0x1A1FE;
        public const GLuint GL_NATIVE_GRAPHICS_HANDLE_PGI = 0x1A202;
        public const GLuint GL_NATIVE_GRAPHICS_BEGIN_HINT_PGI = 0x1A203;
        public const GLuint GL_NATIVE_GRAPHICS_END_HINT_PGI = 0x1A204;
        public const GLuint GL_ALWAYS_FAST_HINT_PGI = 0x1A20C;
        public const GLuint GL_ALWAYS_SOFT_HINT_PGI = 0x1A20D;
        public const GLuint GL_ALLOW_DRAW_OBJ_HINT_PGI = 0x1A20E;
        public const GLuint GL_ALLOW_DRAW_WIN_HINT_PGI = 0x1A20F;
        public const GLuint GL_ALLOW_DRAW_FRG_HINT_PGI = 0x1A210;
        public const GLuint GL_ALLOW_DRAW_MEM_HINT_PGI = 0x1A211;
        public const GLuint GL_STRICT_DEPTHFUNC_HINT_PGI = 0x1A216;
        public const GLuint GL_STRICT_LIGHTING_HINT_PGI = 0x1A217;
        public const GLuint GL_STRICT_SCISSOR_HINT_PGI = 0x1A218;
        public const GLuint GL_FULL_STIPPLE_HINT_PGI = 0x1A219;
        public const GLuint GL_CLIP_NEAR_HINT_PGI = 0x1A220;
        public const GLuint GL_CLIP_FAR_HINT_PGI = 0x1A221;
        public const GLuint GL_WIDE_LINE_HINT_PGI = 0x1A222;
        public const GLuint GL_BACK_NORMALS_HINT_PGI = 0x1A223;
        public const GLuint GL_COLOR_INDEX1_EXT = 0x80E2;
        public const GLuint GL_COLOR_INDEX2_EXT = 0x80E3;
        public const GLuint GL_COLOR_INDEX4_EXT = 0x80E4;
        public const GLuint GL_COLOR_INDEX8_EXT = 0x80E5;
        public const GLuint GL_COLOR_INDEX12_EXT = 0x80E6;
        public const GLuint GL_COLOR_INDEX16_EXT = 0x80E7;
        public const GLuint GL_TEXTURE_INDEX_SIZE_EXT = 0x80ED;
        public const GLuint GL_CLIP_VOLUME_CLIPPING_HINT_EXT = 0x80F0;
        public const GLuint GL_INDEX_MATERIAL_EXT = 0x81B8;
        public const GLuint GL_INDEX_MATERIAL_PARAMETER_EXT = 0x81B9;
        public const GLuint GL_INDEX_MATERIAL_FACE_EXT = 0x81BA;
        public const GLuint GL_INDEX_TEST_EXT = 0x81B5;
        public const GLuint GL_INDEX_TEST_FUNC_EXT = 0x81B6;
        public const GLuint GL_INDEX_TEST_REF_EXT = 0x81B7;
        public const GLuint GL_IUI_V2F_EXT = 0x81AD;
        public const GLuint GL_IUI_V3F_EXT = 0x81AE;
        public const GLuint GL_IUI_N3F_V2F_EXT = 0x81AF;
        public const GLuint GL_IUI_N3F_V3F_EXT = 0x81B0;
        public const GLuint GL_T2F_IUI_V2F_EXT = 0x81B1;
        public const GLuint GL_T2F_IUI_V3F_EXT = 0x81B2;
        public const GLuint GL_T2F_IUI_N3F_V2F_EXT = 0x81B3;
        public const GLuint GL_T2F_IUI_N3F_V3F_EXT = 0x81B4;
        public const GLuint GL_ARRAY_ELEMENT_LOCK_FIRST_EXT = 0x81A8;
        public const GLuint GL_ARRAY_ELEMENT_LOCK_COUNT_EXT = 0x81A9;
        public const GLuint GL_CULL_VERTEX_EXT = 0x81AA;
        public const GLuint GL_CULL_VERTEX_EYE_POSITION_EXT = 0x81AB;
        public const GLuint GL_CULL_VERTEX_OBJECT_POSITION_EXT = 0x81AC;
        public const GLuint GL_RASTER_POSITION_UNCLIPPED_IBM = 0x19262;
        public const GLuint GL_TEXTURE_LIGHTING_MODE_HP = 0x8167;
        public const GLuint GL_TEXTURE_POST_SPECULAR_HP = 0x8168;
        public const GLuint GL_TEXTURE_PRE_SPECULAR_HP = 0x8169;
        public const GLuint GL_MAX_ELEMENTS_VERTICES_EXT = 0x80E8;
        public const GLuint GL_MAX_ELEMENTS_INDICES_EXT = 0x80E9;
        public const GLuint GL_PHONG_WIN = 0x80EA;
        public const GLuint GL_PHONG_HINT_WIN = 0x80EB;
        public const GLuint GL_FOG_SPECULAR_TEXTURE_WIN = 0x80EC;
        public const GLuint GL_FRAGMENT_MATERIAL_EXT = 0x8349;
        public const GLuint GL_FRAGMENT_NORMAL_EXT = 0x834A;
        public const GLuint GL_FRAGMENT_COLOR_EXT = 0x834C;
        public const GLuint GL_ATTENUATION_EXT = 0x834D;
        public const GLuint GL_SHADOW_ATTENUATION_EXT = 0x834E;
        public const GLuint GL_TEXTURE_APPLICATION_MODE_EXT = 0x834F;
        public const GLuint GL_TEXTURE_LIGHT_EXT = 0x8350;
        public const GLuint GL_TEXTURE_MATERIAL_FACE_EXT = 0x8351;
        public const GLuint GL_TEXTURE_MATERIAL_PARAMETER_EXT = 0x8352;
        public const GLuint GL_ASYNC_MARKER_SGIX = 0x8329;
        public const GLuint GL_OCCLUSION_TEST_HP = 0x8165;
        public const GLuint GL_OCCLUSION_TEST_RESULT_HP = 0x8166;
        public const GLuint GL_COLOR_SUM_EXT = 0x8458;
        public const GLuint GL_CURRENT_SECONDARY_COLOR_EXT = 0x8459;
        public const GLuint GL_SECONDARY_COLOR_ARRAY_SIZE_EXT = 0x845A;
        public const GLuint GL_SECONDARY_COLOR_ARRAY_TYPE_EXT = 0x845B;
        public const GLuint GL_SECONDARY_COLOR_ARRAY_STRIDE_EXT = 0x845C;
        public const GLuint GL_SECONDARY_COLOR_ARRAY_POINTER_EXT = 0x845D;
        public const GLuint GL_SECONDARY_COLOR_ARRAY_EXT = 0x845E;
        public const GLuint GL_PERTURB_EXT = 0x85AE;
        public const GLuint GL_TEXTURE_NORMAL_EXT = 0x85AF;
        public const GLuint GL_FOG_COORDINATE_SOURCE_EXT = 0x8450;
        public const GLuint GL_FOG_COORDINATE_EXT = 0x8451;
        public const GLuint GL_FRAGMENT_DEPTH_EXT = 0x8452;
        public const GLuint GL_CURRENT_FOG_COORDINATE_EXT = 0x8453;
        public const GLuint GL_FOG_COORDINATE_ARRAY_TYPE_EXT = 0x8454;
        public const GLuint GL_FOG_COORDINATE_ARRAY_STRIDE_EXT = 0x8455;
        public const GLuint GL_FOG_COORDINATE_ARRAY_POINTER_EXT = 0x8456;
        public const GLuint GL_FOG_COORDINATE_ARRAY_EXT = 0x8457;
        public const GLuint GL_SCREEN_COORDINATES_REND = 0x8490;
        public const GLuint GL_INVERTED_SCREEN_W_REND = 0x8491;
        public const GLuint GL_TANGENT_ARRAY_EXT = 0x8439;
        public const GLuint GL_BINORMAL_ARRAY_EXT = 0x843A;
        public const GLuint GL_CURRENT_TANGENT_EXT = 0x843B;
        public const GLuint GL_CURRENT_BINORMAL_EXT = 0x843C;
        public const GLuint GL_TANGENT_ARRAY_TYPE_EXT = 0x843E;
        public const GLuint GL_TANGENT_ARRAY_STRIDE_EXT = 0x843F;
        public const GLuint GL_BINORMAL_ARRAY_TYPE_EXT = 0x8440;
        public const GLuint GL_BINORMAL_ARRAY_STRIDE_EXT = 0x8441;
        public const GLuint GL_TANGENT_ARRAY_POINTER_EXT = 0x8442;
        public const GLuint GL_BINORMAL_ARRAY_POINTER_EXT = 0x8443;
        public const GLuint GL_MAP1_TANGENT_EXT = 0x8444;
        public const GLuint GL_MAP2_TANGENT_EXT = 0x8445;
        public const GLuint GL_MAP1_BINORMAL_EXT = 0x8446;
        public const GLuint GL_MAP2_BINORMAL_EXT = 0x8447;
        public const GLuint GL_COMBINE_EXT = 0x8570;
        public const GLuint GL_COMBINE_RGB_EXT = 0x8571;
        public const GLuint GL_COMBINE_ALPHA_EXT = 0x8572;
        public const GLuint GL_RGB_SCALE_EXT = 0x8573;
        public const GLuint GL_ADD_SIGNED_EXT = 0x8574;
        public const GLuint GL_INTERPOLATE_EXT = 0x8575;
        public const GLuint GL_CONSTANT_EXT = 0x8576;
        public const GLuint GL_PRIMARY_COLOR_EXT = 0x8577;
        public const GLuint GL_PREVIOUS_EXT = 0x8578;
        public const GLuint GL_SOURCE0_RGB_EXT = 0x8580;
        public const GLuint GL_SOURCE1_RGB_EXT = 0x8581;
        public const GLuint GL_SOURCE2_RGB_EXT = 0x8582;
        public const GLuint GL_SOURCE0_ALPHA_EXT = 0x8588;
        public const GLuint GL_SOURCE1_ALPHA_EXT = 0x8589;
        public const GLuint GL_SOURCE2_ALPHA_EXT = 0x858A;
        public const GLuint GL_OPERAND0_RGB_EXT = 0x8590;
        public const GLuint GL_OPERAND1_RGB_EXT = 0x8591;
        public const GLuint GL_OPERAND2_RGB_EXT = 0x8592;
        public const GLuint GL_OPERAND0_ALPHA_EXT = 0x8598;
        public const GLuint GL_OPERAND1_ALPHA_EXT = 0x8599;
        public const GLuint GL_OPERAND2_ALPHA_EXT = 0x859A;
        public const GLuint GL_LIGHT_MODEL_SPECULAR_VECTOR_APPLE = 0x85B0;
        public const GLuint GL_TRANSFORM_HINT_APPLE = 0x85B1;
        public const GLuint GL_FOG_SCALE_SGIX = 0x81FC;
        public const GLuint GL_FOG_SCALE_VALUE_SGIX = 0x81FD;
        public const GLuint GL_UNPACK_CONSTANT_DATA_SUNX = 0x81D5;
        public const GLuint GL_TEXTURE_CONSTANT_DATA_SUNX = 0x81D6;
        public const GLuint GL_GLOBAL_ALPHA_SUN = 0x81D9;
        public const GLuint GL_GLOBAL_ALPHA_FACTOR_SUN = 0x81DA;
        public const GLuint GL_RESTART_SUN = 0x0001;
        public const GLuint GL_REPLACE_MIDDLE_SUN = 0x0002;
        public const GLuint GL_REPLACE_OLDEST_SUN = 0x0003;
        public const GLuint GL_TRIANGLE_LIST_SUN = 0x81D7;
        public const GLuint GL_REPLACEMENT_CODE_SUN = 0x81D8;
        public const GLuint GL_REPLACEMENT_CODE_ARRAY_SUN = 0x85C0;
        public const GLuint GL_REPLACEMENT_CODE_ARRAY_TYPE_SUN = 0x85C1;
        public const GLuint GL_REPLACEMENT_CODE_ARRAY_STRIDE_SUN = 0x85C2;
        public const GLuint GL_REPLACEMENT_CODE_ARRAY_POINTER_SUN = 0x85C3;
        public const GLuint GL_R1UI_V3F_SUN = 0x85C4;
        public const GLuint GL_R1UI_C4UB_V3F_SUN = 0x85C5;
        public const GLuint GL_R1UI_C3F_V3F_SUN = 0x85C6;
        public const GLuint GL_R1UI_N3F_V3F_SUN = 0x85C7;
        public const GLuint GL_R1UI_C4F_N3F_V3F_SUN = 0x85C8;
        public const GLuint GL_R1UI_T2F_V3F_SUN = 0x85C9;
        public const GLuint GL_R1UI_T2F_N3F_V3F_SUN = 0x85CA;
        public const GLuint GL_R1UI_T2F_C4F_N3F_V3F_SUN = 0x85CB;
        public const GLuint GL_BLEND_DST_RGB_EXT = 0x80C8;
        public const GLuint GL_BLEND_SRC_RGB_EXT = 0x80C9;
        public const GLuint GL_BLEND_DST_ALPHA_EXT = 0x80CA;
        public const GLuint GL_BLEND_SRC_ALPHA_EXT = 0x80CB;
        public const GLuint GL_RED_MIN_CLAMP_INGR = 0x8560;
        public const GLuint GL_GREEN_MIN_CLAMP_INGR = 0x8561;
        public const GLuint GL_BLUE_MIN_CLAMP_INGR = 0x8562;
        public const GLuint GL_ALPHA_MIN_CLAMP_INGR = 0x8563;
        public const GLuint GL_RED_MAX_CLAMP_INGR = 0x8564;
        public const GLuint GL_GREEN_MAX_CLAMP_INGR = 0x8565;
        public const GLuint GL_BLUE_MAX_CLAMP_INGR = 0x8566;
        public const GLuint GL_ALPHA_MAX_CLAMP_INGR = 0x8567;
        public const GLuint GL_INTERLACE_READ_INGR = 0x8568;
        public const GLuint GL_INCR_WRAP_EXT = 0x8507;
        public const GLuint GL_DECR_WRAP_EXT = 0x8508;
        public const GLuint GL_422_EXT = 0x80CC;
        public const GLuint GL_422_REV_EXT = 0x80CD;
        public const GLuint GL_422_AVERAGE_EXT = 0x80CE;
        public const GLuint GL_422_REV_AVERAGE_EXT = 0x80CF;
        public const GLuint GL_NORMAL_MAP_NV = 0x8511;
        public const GLuint GL_REFLECTION_MAP_NV = 0x8512;
        public const GLuint GL_NORMAL_MAP_EXT = 0x8511;
        public const GLuint GL_REFLECTION_MAP_EXT = 0x8512;
        public const GLuint GL_TEXTURE_CUBE_MAP_EXT = 0x8513;
        public const GLuint GL_TEXTURE_BINDING_CUBE_MAP_EXT = 0x8514;
        public const GLuint GL_TEXTURE_CUBE_MAP_POSITIVE_X_EXT = 0x8515;
        public const GLuint GL_TEXTURE_CUBE_MAP_NEGATIVE_X_EXT = 0x8516;
        public const GLuint GL_TEXTURE_CUBE_MAP_POSITIVE_Y_EXT = 0x8517;
        public const GLuint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y_EXT = 0x8518;
        public const GLuint GL_TEXTURE_CUBE_MAP_POSITIVE_Z_EXT = 0x8519;
        public const GLuint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z_EXT = 0x851A;
        public const GLuint GL_PROXY_TEXTURE_CUBE_MAP_EXT = 0x851B;
        public const GLuint GL_MAX_CUBE_MAP_TEXTURE_SIZE_EXT = 0x851C;
        public const GLuint GL_WRAP_BORDER_SUN = 0x81D4;
        public const GLuint GL_MAX_TEXTURE_LOD_BIAS_EXT = 0x84FD;
        public const GLuint GL_TEXTURE_FILTER_CONTROL_EXT = 0x8500;
        public const GLuint GL_TEXTURE_LOD_BIAS_EXT = 0x8501;
        public const GLuint GL_TEXTURE_MAX_ANISOTROPY_EXT = 0x84FE;
        public const GLuint GL_MAX_TEXTURE_MAX_ANISOTROPY_EXT = 0x84FF;
        public const GLuint GL_MODELVIEW0_STACK_DEPTH_EXT = GL_MODELVIEW_STACK_DEPTH;
        public const GLuint GL_MODELVIEW1_STACK_DEPTH_EXT = 0x8502;
        public const GLuint GL_MODELVIEW0_MATRIX_EXT = GL_MODELVIEW_MATRIX;
        public const GLuint GL_MODELVIEW1_MATRIX_EXT = 0x8506;
        public const GLuint GL_VERTEX_WEIGHTING_EXT = 0x8509;
        public const GLuint GL_MODELVIEW0_EXT = GL_MODELVIEW;
        public const GLuint GL_MODELVIEW1_EXT = 0x850A;
        public const GLuint GL_CURRENT_VERTEX_WEIGHT_EXT = 0x850B;
        public const GLuint GL_VERTEX_WEIGHT_ARRAY_EXT = 0x850C;
        public const GLuint GL_VERTEX_WEIGHT_ARRAY_SIZE_EXT = 0x850D;
        public const GLuint GL_VERTEX_WEIGHT_ARRAY_TYPE_EXT = 0x850E;
        public const GLuint GL_VERTEX_WEIGHT_ARRAY_STRIDE_EXT = 0x850F;
        public const GLuint GL_VERTEX_WEIGHT_ARRAY_POINTER_EXT = 0x8510;
        public const GLuint GL_MAX_SHININESS_NV = 0x8504;
        public const GLuint GL_MAX_SPOT_EXPONENT_NV = 0x8505;
        public const GLuint GL_VERTEX_ARRAY_RANGE_NV = 0x851D;
        public const GLuint GL_VERTEX_ARRAY_RANGE_LENGTH_NV = 0x851E;
        public const GLuint GL_VERTEX_ARRAY_RANGE_VALID_NV = 0x851F;
        public const GLuint GL_MAX_VERTEX_ARRAY_RANGE_ELEMENT_NV = 0x8520;
        public const GLuint GL_VERTEX_ARRAY_RANGE_POINTER_NV = 0x8521;
        public const GLuint GL_REGISTER_COMBINERS_NV = 0x8522;
        public const GLuint GL_VARIABLE_A_NV = 0x8523;
        public const GLuint GL_VARIABLE_B_NV = 0x8524;
        public const GLuint GL_VARIABLE_C_NV = 0x8525;
        public const GLuint GL_VARIABLE_D_NV = 0x8526;
        public const GLuint GL_VARIABLE_E_NV = 0x8527;
        public const GLuint GL_VARIABLE_F_NV = 0x8528;
        public const GLuint GL_VARIABLE_G_NV = 0x8529;
        public const GLuint GL_CONSTANT_COLOR0_NV = 0x852A;
        public const GLuint GL_CONSTANT_COLOR1_NV = 0x852B;
        public const GLuint GL_PRIMARY_COLOR_NV = 0x852C;
        public const GLuint GL_SECONDARY_COLOR_NV = 0x852D;
        public const GLuint GL_SPARE0_NV = 0x852E;
        public const GLuint GL_SPARE1_NV = 0x852F;
        public const GLuint GL_DISCARD_NV = 0x8530;
        public const GLuint GL_E_TIMES_F_NV = 0x8531;
        public const GLuint GL_SPARE0_PLUS_SECONDARY_COLOR_NV = 0x8532;
        public const GLuint GL_UNSIGNED_IDENTITY_NV = 0x8536;
        public const GLuint GL_UNSIGNED_INVERT_NV = 0x8537;
        public const GLuint GL_EXPAND_NORMAL_NV = 0x8538;
        public const GLuint GL_EXPAND_NEGATE_NV = 0x8539;
        public const GLuint GL_HALF_BIAS_NORMAL_NV = 0x853A;
        public const GLuint GL_HALF_BIAS_NEGATE_NV = 0x853B;
        public const GLuint GL_SIGNED_IDENTITY_NV = 0x853C;
        public const GLuint GL_SIGNED_NEGATE_NV = 0x853D;
        public const GLuint GL_SCALE_BY_TWO_NV = 0x853E;
        public const GLuint GL_SCALE_BY_FOUR_NV = 0x853F;
        public const GLuint GL_SCALE_BY_ONE_HALF_NV = 0x8540;
        public const GLuint GL_BIAS_BY_NEGATIVE_ONE_HALF_NV = 0x8541;
        public const GLuint GL_COMBINER_INPUT_NV = 0x8542;
        public const GLuint GL_COMBINER_MAPPING_NV = 0x8543;
        public const GLuint GL_COMBINER_COMPONENT_USAGE_NV = 0x8544;
        public const GLuint GL_COMBINER_AB_DOT_PRODUCT_NV = 0x8545;
        public const GLuint GL_COMBINER_CD_DOT_PRODUCT_NV = 0x8546;
        public const GLuint GL_COMBINER_MUX_SUM_NV = 0x8547;
        public const GLuint GL_COMBINER_SCALE_NV = 0x8548;
        public const GLuint GL_COMBINER_BIAS_NV = 0x8549;
        public const GLuint GL_COMBINER_AB_OUTPUT_NV = 0x854A;
        public const GLuint GL_COMBINER_CD_OUTPUT_NV = 0x854B;
        public const GLuint GL_COMBINER_SUM_OUTPUT_NV = 0x854C;
        public const GLuint GL_MAX_GENERAL_COMBINERS_NV = 0x854D;
        public const GLuint GL_NUM_GENERAL_COMBINERS_NV = 0x854E;
        public const GLuint GL_COLOR_SUM_CLAMP_NV = 0x854F;
        public const GLuint GL_COMBINER0_NV = 0x8550;
        public const GLuint GL_COMBINER1_NV = 0x8551;
        public const GLuint GL_COMBINER2_NV = 0x8552;
        public const GLuint GL_COMBINER3_NV = 0x8553;
        public const GLuint GL_COMBINER4_NV = 0x8554;
        public const GLuint GL_COMBINER5_NV = 0x8555;
        public const GLuint GL_COMBINER6_NV = 0x8556;
        public const GLuint GL_COMBINER7_NV = 0x8557;
        public const GLuint GL_FOG_DISTANCE_MODE_NV = 0x855A;
        public const GLuint GL_EYE_RADIAL_NV = 0x855B;
        public const GLuint GL_EYE_PLANE_ABSOLUTE_NV = 0x855C;
        public const GLuint GL_EMBOSS_LIGHT_NV = 0x855D;
        public const GLuint GL_EMBOSS_CONSTANT_NV = 0x855E;
        public const GLuint GL_EMBOSS_MAP_NV = 0x855F;
        public const GLuint GL_COMBINE4_NV = 0x8503;
        public const GLuint GL_SOURCE3_RGB_NV = 0x8583;
        public const GLuint GL_SOURCE3_ALPHA_NV = 0x858B;
        public const GLuint GL_OPERAND3_RGB_NV = 0x8593;
        public const GLuint GL_OPERAND3_ALPHA_NV = 0x859B;
        public const GLuint GL_CULL_VERTEX_IBM = 103050;
        public const GLuint GL_VERTEX_ARRAY_LIST_IBM = 103070;
        public const GLuint GL_NORMAL_ARRAY_LIST_IBM = 103071;
        public const GLuint GL_COLOR_ARRAY_LIST_IBM = 103072;
        public const GLuint GL_INDEX_ARRAY_LIST_IBM = 103073;
        public const GLuint GL_TEXTURE_COORD_ARRAY_LIST_IBM = 103074;
        public const GLuint GL_EDGE_FLAG_ARRAY_LIST_IBM = 103075;
        public const GLuint GL_FOG_COORDINATE_ARRAY_LIST_IBM = 103076;
        public const GLuint GL_SECONDARY_COLOR_ARRAY_LIST_IBM = 103077;
        public const GLuint GL_VERTEX_ARRAY_LIST_STRIDE_IBM = 103080;
        public const GLuint GL_NORMAL_ARRAY_LIST_STRIDE_IBM = 103081;
        public const GLuint GL_COLOR_ARRAY_LIST_STRIDE_IBM = 103082;
        public const GLuint GL_INDEX_ARRAY_LIST_STRIDE_IBM = 103083;
        public const GLuint GL_TEXTURE_COORD_ARRAY_LIST_STRIDE_IBM = 103084;
        public const GLuint GL_EDGE_FLAG_ARRAY_LIST_STRIDE_IBM = 103085;
        public const GLuint GL_FOG_COORDINATE_ARRAY_LIST_STRIDE_IBM = 103086;
        public const GLuint GL_SECONDARY_COLOR_ARRAY_LIST_STRIDE_IBM = 103087;
        public const GLuint GL_YCRCB_SGIX = 0x8318;
        public const GLuint GL_YCRCBA_SGIX = 0x8319;
        public const GLuint GL_DEPTH_PASS_INSTRUMENT_SGIX = 0x8310;
        public const GLuint GL_DEPTH_PASS_INSTRUMENT_COUNTERS_SGIX = 0x8311;
        public const GLuint GL_DEPTH_PASS_INSTRUMENT_MAX_SGIX = 0x8312;
        public const GLuint GL_COMPRESSED_RGB_FXT1_3DFX = 0x86B0;
        public const GLuint GL_COMPRESSED_RGBA_FXT1_3DFX = 0x86B1;
        public const GLuint GL_MULTISAMPLE_3DFX = 0x86B2;
        public const GLuint GL_SAMPLE_BUFFERS_3DFX = 0x86B3;
        public const GLuint GL_SAMPLES_3DFX = 0x86B4;
        public const GLuint GL_MULTISAMPLE_BIT_3DFX = 0x20000000;
        public const GLuint GL_MULTISAMPLE_EXT = 0x809D;
        public const GLuint GL_SAMPLE_ALPHA_TO_MASK_EXT = 0x809E;
        public const GLuint GL_SAMPLE_ALPHA_TO_ONE_EXT = 0x809F;
        public const GLuint GL_SAMPLE_MASK_EXT = 0x80A0;
        public const GLuint GL_1PASS_EXT = 0x80A1;
        public const GLuint GL_2PASS_0_EXT = 0x80A2;
        public const GLuint GL_2PASS_1_EXT = 0x80A3;
        public const GLuint GL_4PASS_0_EXT = 0x80A4;
        public const GLuint GL_4PASS_1_EXT = 0x80A5;
        public const GLuint GL_4PASS_2_EXT = 0x80A6;
        public const GLuint GL_4PASS_3_EXT = 0x80A7;
        public const GLuint GL_SAMPLE_BUFFERS_EXT = 0x80A8;
        public const GLuint GL_SAMPLES_EXT = 0x80A9;
        public const GLuint GL_SAMPLE_MASK_VALUE_EXT = 0x80AA;
        public const GLuint GL_SAMPLE_MASK_INVERT_EXT = 0x80AB;
        public const GLuint GL_SAMPLE_PATTERN_EXT = 0x80AC;
        public const GLuint GL_MULTISAMPLE_BIT_EXT = 0x20000000;
        public const GLuint GL_DOT3_RGB_EXT = 0x8740;
        public const GLuint GL_DOT3_RGBA_EXT = 0x8741;
        public const GLuint GL_MIRROR_CLAMP_ATI = 0x8742;
        public const GLuint GL_MIRROR_CLAMP_TO_EDGE_ATI = 0x8743;
        public const GLuint GL_ALL_COMPLETED_NV = 0x84F2;
        public const GLuint GL_FENCE_STATUS_NV = 0x84F3;
        public const GLuint GL_FENCE_CONDITION_NV = 0x84F4;
        public const GLuint GL_MIRRORED_REPEAT_IBM = 0x8370;
        public const GLuint GL_EVAL_2D_NV = 0x86C0;
        public const GLuint GL_EVAL_TRIANGULAR_2D_NV = 0x86C1;
        public const GLuint GL_MAP_TESSELLATION_NV = 0x86C2;
        public const GLuint GL_MAP_ATTRIB_U_ORDER_NV = 0x86C3;
        public const GLuint GL_MAP_ATTRIB_V_ORDER_NV = 0x86C4;
        public const GLuint GL_EVAL_FRACTIONAL_TESSELLATION_NV = 0x86C5;
        public const GLuint GL_EVAL_VERTEX_ATTRIB0_NV = 0x86C6;
        public const GLuint GL_EVAL_VERTEX_ATTRIB1_NV = 0x86C7;
        public const GLuint GL_EVAL_VERTEX_ATTRIB2_NV = 0x86C8;
        public const GLuint GL_EVAL_VERTEX_ATTRIB3_NV = 0x86C9;
        public const GLuint GL_EVAL_VERTEX_ATTRIB4_NV = 0x86CA;
        public const GLuint GL_EVAL_VERTEX_ATTRIB5_NV = 0x86CB;
        public const GLuint GL_EVAL_VERTEX_ATTRIB6_NV = 0x86CC;
        public const GLuint GL_EVAL_VERTEX_ATTRIB7_NV = 0x86CD;
        public const GLuint GL_EVAL_VERTEX_ATTRIB8_NV = 0x86CE;
        public const GLuint GL_EVAL_VERTEX_ATTRIB9_NV = 0x86CF;
        public const GLuint GL_EVAL_VERTEX_ATTRIB10_NV = 0x86D0;
        public const GLuint GL_EVAL_VERTEX_ATTRIB11_NV = 0x86D1;
        public const GLuint GL_EVAL_VERTEX_ATTRIB12_NV = 0x86D2;
        public const GLuint GL_EVAL_VERTEX_ATTRIB13_NV = 0x86D3;
        public const GLuint GL_EVAL_VERTEX_ATTRIB14_NV = 0x86D4;
        public const GLuint GL_EVAL_VERTEX_ATTRIB15_NV = 0x86D5;
        public const GLuint GL_MAX_MAP_TESSELLATION_NV = 0x86D6;
        public const GLuint GL_MAX_RATIONAL_EVAL_ORDER_NV = 0x86D7;
        public const GLuint GL_DEPTH_STENCIL_NV = 0x84F9;
        public const GLuint GL_UNSIGNED_INT_24_8_NV = 0x84FA;
        public const GLuint GL_PER_STAGE_CONSTANTS_NV = 0x8535;
        public const GLuint GL_TEXTURE_RECTANGLE_NV = 0x84F5;
        public const GLuint GL_TEXTURE_BINDING_RECTANGLE_NV = 0x84F6;
        public const GLuint GL_PROXY_TEXTURE_RECTANGLE_NV = 0x84F7;
        public const GLuint GL_MAX_RECTANGLE_TEXTURE_SIZE_NV = 0x84F8;
        public const GLuint GL_OFFSET_TEXTURE_RECTANGLE_NV = 0x864C;
        public const GLuint GL_OFFSET_TEXTURE_RECTANGLE_SCALE_NV = 0x864D;
        public const GLuint GL_DOT_PRODUCT_TEXTURE_RECTANGLE_NV = 0x864E;
        public const GLuint GL_RGBA_UNSIGNED_DOT_PRODUCT_MAPPING_NV = 0x86D9;
        public const GLuint GL_UNSIGNED_INT_S8_S8_8_8_NV = 0x86DA;
        public const GLuint GL_UNSIGNED_INT_8_8_S8_S8_REV_NV = 0x86DB;
        public const GLuint GL_DSDT_MAG_INTENSITY_NV = 0x86DC;
        public const GLuint GL_SHADER_CONSISTENT_NV = 0x86DD;
        public const GLuint GL_TEXTURE_SHADER_NV = 0x86DE;
        public const GLuint GL_SHADER_OPERATION_NV = 0x86DF;
        public const GLuint GL_CULL_MODES_NV = 0x86E0;
        public const GLuint GL_OFFSET_TEXTURE_MATRIX_NV = 0x86E1;
        public const GLuint GL_OFFSET_TEXTURE_SCALE_NV = 0x86E2;
        public const GLuint GL_OFFSET_TEXTURE_BIAS_NV = 0x86E3;
        public const GLuint GL_OFFSET_TEXTURE_2D_MATRIX_NV = GL_OFFSET_TEXTURE_MATRIX_NV;
        public const GLuint GL_OFFSET_TEXTURE_2D_SCALE_NV = GL_OFFSET_TEXTURE_SCALE_NV;
        public const GLuint GL_OFFSET_TEXTURE_2D_BIAS_NV = GL_OFFSET_TEXTURE_BIAS_NV;
        public const GLuint GL_PREVIOUS_TEXTURE_INPUT_NV = 0x86E4;
        public const GLuint GL_CONST_EYE_NV = 0x86E5;
        public const GLuint GL_PASS_THROUGH_NV = 0x86E6;
        public const GLuint GL_CULL_FRAGMENT_NV = 0x86E7;
        public const GLuint GL_OFFSET_TEXTURE_2D_NV = 0x86E8;
        public const GLuint GL_DEPENDENT_AR_TEXTURE_2D_NV = 0x86E9;
        public const GLuint GL_DEPENDENT_GB_TEXTURE_2D_NV = 0x86EA;
        public const GLuint GL_DOT_PRODUCT_NV = 0x86EC;
        public const GLuint GL_DOT_PRODUCT_DEPTH_REPLACE_NV = 0x86ED;
        public const GLuint GL_DOT_PRODUCT_TEXTURE_2D_NV = 0x86EE;
        public const GLuint GL_DOT_PRODUCT_TEXTURE_CUBE_MAP_NV = 0x86F0;
        public const GLuint GL_DOT_PRODUCT_DIFFUSE_CUBE_MAP_NV = 0x86F1;
        public const GLuint GL_DOT_PRODUCT_REFLECT_CUBE_MAP_NV = 0x86F2;
        public const GLuint GL_DOT_PRODUCT_CONST_EYE_REFLECT_CUBE_MAP_NV = 0x86F3;
        public const GLuint GL_HILO_NV = 0x86F4;
        public const GLuint GL_DSDT_NV = 0x86F5;
        public const GLuint GL_DSDT_MAG_NV = 0x86F6;
        public const GLuint GL_DSDT_MAG_VIB_NV = 0x86F7;
        public const GLuint GL_HILO16_NV = 0x86F8;
        public const GLuint GL_SIGNED_HILO_NV = 0x86F9;
        public const GLuint GL_SIGNED_HILO16_NV = 0x86FA;
        public const GLuint GL_SIGNED_RGBA_NV = 0x86FB;
        public const GLuint GL_SIGNED_RGBA8_NV = 0x86FC;
        public const GLuint GL_SIGNED_RGB_NV = 0x86FE;
        public const GLuint GL_SIGNED_RGB8_NV = 0x86FF;
        public const GLuint GL_SIGNED_LUMINANCE_NV = 0x8701;
        public const GLuint GL_SIGNED_LUMINANCE8_NV = 0x8702;
        public const GLuint GL_SIGNED_LUMINANCE_ALPHA_NV = 0x8703;
        public const GLuint GL_SIGNED_LUMINANCE8_ALPHA8_NV = 0x8704;
        public const GLuint GL_SIGNED_ALPHA_NV = 0x8705;
        public const GLuint GL_SIGNED_ALPHA8_NV = 0x8706;
        public const GLuint GL_SIGNED_INTENSITY_NV = 0x8707;
        public const GLuint GL_SIGNED_INTENSITY8_NV = 0x8708;
        public const GLuint GL_DSDT8_NV = 0x8709;
        public const GLuint GL_DSDT8_MAG8_NV = 0x870A;
        public const GLuint GL_DSDT8_MAG8_INTENSITY8_NV = 0x870B;
        public const GLuint GL_SIGNED_RGB_UNSIGNED_ALPHA_NV = 0x870C;
        public const GLuint GL_SIGNED_RGB8_UNSIGNED_ALPHA8_NV = 0x870D;
        public const GLuint GL_HI_SCALE_NV = 0x870E;
        public const GLuint GL_LO_SCALE_NV = 0x870F;
        public const GLuint GL_DS_SCALE_NV = 0x8710;
        public const GLuint GL_DT_SCALE_NV = 0x8711;
        public const GLuint GL_MAGNITUDE_SCALE_NV = 0x8712;
        public const GLuint GL_VIBRANCE_SCALE_NV = 0x8713;
        public const GLuint GL_HI_BIAS_NV = 0x8714;
        public const GLuint GL_LO_BIAS_NV = 0x8715;
        public const GLuint GL_DS_BIAS_NV = 0x8716;
        public const GLuint GL_DT_BIAS_NV = 0x8717;
        public const GLuint GL_MAGNITUDE_BIAS_NV = 0x8718;
        public const GLuint GL_VIBRANCE_BIAS_NV = 0x8719;
        public const GLuint GL_TEXTURE_BORDER_VALUES_NV = 0x871A;
        public const GLuint GL_TEXTURE_HI_SIZE_NV = 0x871B;
        public const GLuint GL_TEXTURE_LO_SIZE_NV = 0x871C;
        public const GLuint GL_TEXTURE_DS_SIZE_NV = 0x871D;
        public const GLuint GL_TEXTURE_DT_SIZE_NV = 0x871E;
        public const GLuint GL_TEXTURE_MAG_SIZE_NV = 0x871F;
        public const GLuint GL_DOT_PRODUCT_TEXTURE_3D_NV = 0x86EF;
        public const GLuint GL_VERTEX_ARRAY_RANGE_WITHOUT_FLUSH_NV = 0x8533;
        public const GLuint GL_VERTEX_PROGRAM_NV = 0x8620;
        public const GLuint GL_VERTEX_STATE_PROGRAM_NV = 0x8621;
        public const GLuint GL_ATTRIB_ARRAY_SIZE_NV = 0x8623;
        public const GLuint GL_ATTRIB_ARRAY_STRIDE_NV = 0x8624;
        public const GLuint GL_ATTRIB_ARRAY_TYPE_NV = 0x8625;
        public const GLuint GL_CURRENT_ATTRIB_NV = 0x8626;
        public const GLuint GL_PROGRAM_LENGTH_NV = 0x8627;
        public const GLuint GL_PROGRAM_STRING_NV = 0x8628;
        public const GLuint GL_MODELVIEW_PROJECTION_NV = 0x8629;
        public const GLuint GL_IDENTITY_NV = 0x862A;
        public const GLuint GL_INVERSE_NV = 0x862B;
        public const GLuint GL_TRANSPOSE_NV = 0x862C;
        public const GLuint GL_INVERSE_TRANSPOSE_NV = 0x862D;
        public const GLuint GL_MAX_TRACK_MATRIX_STACK_DEPTH_NV = 0x862E;
        public const GLuint GL_MAX_TRACK_MATRICES_NV = 0x862F;
        public const GLuint GL_MATRIX0_NV = 0x8630;
        public const GLuint GL_MATRIX1_NV = 0x8631;
        public const GLuint GL_MATRIX2_NV = 0x8632;
        public const GLuint GL_MATRIX3_NV = 0x8633;
        public const GLuint GL_MATRIX4_NV = 0x8634;
        public const GLuint GL_MATRIX5_NV = 0x8635;
        public const GLuint GL_MATRIX6_NV = 0x8636;
        public const GLuint GL_MATRIX7_NV = 0x8637;
        public const GLuint GL_CURRENT_MATRIX_STACK_DEPTH_NV = 0x8640;
        public const GLuint GL_CURRENT_MATRIX_NV = 0x8641;
        public const GLuint GL_VERTEX_PROGRAM_POINT_SIZE_NV = 0x8642;
        public const GLuint GL_VERTEX_PROGRAM_TWO_SIDE_NV = 0x8643;
        public const GLuint GL_PROGRAM_PARAMETER_NV = 0x8644;
        public const GLuint GL_ATTRIB_ARRAY_POINTER_NV = 0x8645;
        public const GLuint GL_PROGRAM_TARGET_NV = 0x8646;
        public const GLuint GL_PROGRAM_RESIDENT_NV = 0x8647;
        public const GLuint GL_TRACK_MATRIX_NV = 0x8648;
        public const GLuint GL_TRACK_MATRIX_TRANSFORM_NV = 0x8649;
        public const GLuint GL_VERTEX_PROGRAM_BINDING_NV = 0x864A;
        public const GLuint GL_PROGRAM_ERROR_POSITION_NV = 0x864B;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY0_NV = 0x8650;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY1_NV = 0x8651;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY2_NV = 0x8652;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY3_NV = 0x8653;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY4_NV = 0x8654;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY5_NV = 0x8655;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY6_NV = 0x8656;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY7_NV = 0x8657;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY8_NV = 0x8658;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY9_NV = 0x8659;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY10_NV = 0x865A;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY11_NV = 0x865B;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY12_NV = 0x865C;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY13_NV = 0x865D;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY14_NV = 0x865E;
        public const GLuint GL_VERTEX_ATTRIB_ARRAY15_NV = 0x865F;
        public const GLuint GL_MAP1_VERTEX_ATTRIB0_4_NV = 0x8660;
        public const GLuint GL_MAP1_VERTEX_ATTRIB1_4_NV = 0x8661;
        public const GLuint GL_MAP1_VERTEX_ATTRIB2_4_NV = 0x8662;
        public const GLuint GL_MAP1_VERTEX_ATTRIB3_4_NV = 0x8663;
        public const GLuint GL_MAP1_VERTEX_ATTRIB4_4_NV = 0x8664;
        public const GLuint GL_MAP1_VERTEX_ATTRIB5_4_NV = 0x8665;
        public const GLuint GL_MAP1_VERTEX_ATTRIB6_4_NV = 0x8666;
        public const GLuint GL_MAP1_VERTEX_ATTRIB7_4_NV = 0x8667;
        public const GLuint GL_MAP1_VERTEX_ATTRIB8_4_NV = 0x8668;
        public const GLuint GL_MAP1_VERTEX_ATTRIB9_4_NV = 0x8669;
        public const GLuint GL_MAP1_VERTEX_ATTRIB10_4_NV = 0x866A;
        public const GLuint GL_MAP1_VERTEX_ATTRIB11_4_NV = 0x866B;
        public const GLuint GL_MAP1_VERTEX_ATTRIB12_4_NV = 0x866C;
        public const GLuint GL_MAP1_VERTEX_ATTRIB13_4_NV = 0x866D;
        public const GLuint GL_MAP1_VERTEX_ATTRIB14_4_NV = 0x866E;
        public const GLuint GL_MAP1_VERTEX_ATTRIB15_4_NV = 0x866F;
        public const GLuint GL_MAP2_VERTEX_ATTRIB0_4_NV = 0x8670;
        public const GLuint GL_MAP2_VERTEX_ATTRIB1_4_NV = 0x8671;
        public const GLuint GL_MAP2_VERTEX_ATTRIB2_4_NV = 0x8672;
        public const GLuint GL_MAP2_VERTEX_ATTRIB3_4_NV = 0x8673;
        public const GLuint GL_MAP2_VERTEX_ATTRIB4_4_NV = 0x8674;
        public const GLuint GL_MAP2_VERTEX_ATTRIB5_4_NV = 0x8675;
        public const GLuint GL_MAP2_VERTEX_ATTRIB6_4_NV = 0x8676;
        public const GLuint GL_MAP2_VERTEX_ATTRIB7_4_NV = 0x8677;
        public const GLuint GL_MAP2_VERTEX_ATTRIB8_4_NV = 0x8678;
        public const GLuint GL_MAP2_VERTEX_ATTRIB9_4_NV = 0x8679;
        public const GLuint GL_MAP2_VERTEX_ATTRIB10_4_NV = 0x867A;
        public const GLuint GL_MAP2_VERTEX_ATTRIB11_4_NV = 0x867B;
        public const GLuint GL_MAP2_VERTEX_ATTRIB12_4_NV = 0x867C;
        public const GLuint GL_MAP2_VERTEX_ATTRIB13_4_NV = 0x867D;
        public const GLuint GL_MAP2_VERTEX_ATTRIB14_4_NV = 0x867E;
        public const GLuint GL_MAP2_VERTEX_ATTRIB15_4_NV = 0x867F;
        public const GLuint GL_SCALEBIAS_HINT_SGIX = 0x8322;
        public const GLuint GL_INTERLACE_OML = 0x8980;
        public const GLuint GL_INTERLACE_READ_OML = 0x8981;
        public const GLuint GL_FORMAT_SUBSAMPLE_24_24_OML = 0x8982;
        public const GLuint GL_FORMAT_SUBSAMPLE_244_244_OML = 0x8983;
        public const GLuint GL_PACK_RESAMPLE_OML = 0x8984;
        public const GLuint GL_UNPACK_RESAMPLE_OML = 0x8985;
        public const GLuint GL_RESAMPLE_REPLICATE_OML = 0x8986;
        public const GLuint GL_RESAMPLE_ZERO_FILL_OML = 0x8987;
        public const GLuint GL_RESAMPLE_AVERAGE_OML = 0x8988;
        public const GLuint GL_RESAMPLE_DECIMATE_OML = 0x8989;
        public const GLuint GL_DEPTH_STENCIL_TO_RGBA_NV = 0x886E;
        public const GLuint GL_DEPTH_STENCIL_TO_BGRA_NV = 0x886F;
        public const GLuint GL_BUMP_ROT_MATRIX_ATI = 0x8775;
        public const GLuint GL_BUMP_ROT_MATRIX_SIZE_ATI = 0x8776;
        public const GLuint GL_BUMP_NUM_TEX_UNITS_ATI = 0x8777;
        public const GLuint GL_BUMP_TEX_UNITS_ATI = 0x8778;
        public const GLuint GL_DUDV_ATI = 0x8779;
        public const GLuint GL_DU8DV8_ATI = 0x877A;
        public const GLuint GL_BUMP_ENVMAP_ATI = 0x877B;
        public const GLuint GL_BUMP_TARGET_ATI = 0x877C;
        public const GLuint GL_FRAGMENT_SHADER_ATI = 0x8920;
        public const GLuint GL_REG_0_ATI = 0x8921;
        public const GLuint GL_REG_1_ATI = 0x8922;
        public const GLuint GL_REG_2_ATI = 0x8923;
        public const GLuint GL_REG_3_ATI = 0x8924;
        public const GLuint GL_REG_4_ATI = 0x8925;
        public const GLuint GL_REG_5_ATI = 0x8926;
        public const GLuint GL_REG_6_ATI = 0x8927;
        public const GLuint GL_REG_7_ATI = 0x8928;
        public const GLuint GL_REG_8_ATI = 0x8929;
        public const GLuint GL_REG_9_ATI = 0x892A;
        public const GLuint GL_REG_10_ATI = 0x892B;
        public const GLuint GL_REG_11_ATI = 0x892C;
        public const GLuint GL_REG_12_ATI = 0x892D;
        public const GLuint GL_REG_13_ATI = 0x892E;
        public const GLuint GL_REG_14_ATI = 0x892F;
        public const GLuint GL_REG_15_ATI = 0x8930;
        public const GLuint GL_REG_16_ATI = 0x8931;
        public const GLuint GL_REG_17_ATI = 0x8932;
        public const GLuint GL_REG_18_ATI = 0x8933;
        public const GLuint GL_REG_19_ATI = 0x8934;
        public const GLuint GL_REG_20_ATI = 0x8935;
        public const GLuint GL_REG_21_ATI = 0x8936;
        public const GLuint GL_REG_22_ATI = 0x8937;
        public const GLuint GL_REG_23_ATI = 0x8938;
        public const GLuint GL_REG_24_ATI = 0x8939;
        public const GLuint GL_REG_25_ATI = 0x893A;
        public const GLuint GL_REG_26_ATI = 0x893B;
        public const GLuint GL_REG_27_ATI = 0x893C;
        public const GLuint GL_REG_28_ATI = 0x893D;
        public const GLuint GL_REG_29_ATI = 0x893E;
        public const GLuint GL_REG_30_ATI = 0x893F;
        public const GLuint GL_REG_31_ATI = 0x8940;
        public const GLuint GL_CON_0_ATI = 0x8941;
        public const GLuint GL_CON_1_ATI = 0x8942;
        public const GLuint GL_CON_2_ATI = 0x8943;
        public const GLuint GL_CON_3_ATI = 0x8944;
        public const GLuint GL_CON_4_ATI = 0x8945;
        public const GLuint GL_CON_5_ATI = 0x8946;
        public const GLuint GL_CON_6_ATI = 0x8947;
        public const GLuint GL_CON_7_ATI = 0x8948;
        public const GLuint GL_CON_8_ATI = 0x8949;
        public const GLuint GL_CON_9_ATI = 0x894A;
        public const GLuint GL_CON_10_ATI = 0x894B;
        public const GLuint GL_CON_11_ATI = 0x894C;
        public const GLuint GL_CON_12_ATI = 0x894D;
        public const GLuint GL_CON_13_ATI = 0x894E;
        public const GLuint GL_CON_14_ATI = 0x894F;
        public const GLuint GL_CON_15_ATI = 0x8950;
        public const GLuint GL_CON_16_ATI = 0x8951;
        public const GLuint GL_CON_17_ATI = 0x8952;
        public const GLuint GL_CON_18_ATI = 0x8953;
        public const GLuint GL_CON_19_ATI = 0x8954;
        public const GLuint GL_CON_20_ATI = 0x8955;
        public const GLuint GL_CON_21_ATI = 0x8956;
        public const GLuint GL_CON_22_ATI = 0x8957;
        public const GLuint GL_CON_23_ATI = 0x8958;
        public const GLuint GL_CON_24_ATI = 0x8959;
        public const GLuint GL_CON_25_ATI = 0x895A;
        public const GLuint GL_CON_26_ATI = 0x895B;
        public const GLuint GL_CON_27_ATI = 0x895C;
        public const GLuint GL_CON_28_ATI = 0x895D;
        public const GLuint GL_CON_29_ATI = 0x895E;
        public const GLuint GL_CON_30_ATI = 0x895F;
        public const GLuint GL_CON_31_ATI = 0x8960;
        public const GLuint GL_MOV_ATI = 0x8961;
        public const GLuint GL_ADD_ATI = 0x8963;
        public const GLuint GL_MUL_ATI = 0x8964;
        public const GLuint GL_SUB_ATI = 0x8965;
        public const GLuint GL_DOT3_ATI = 0x8966;
        public const GLuint GL_DOT4_ATI = 0x8967;
        public const GLuint GL_MAD_ATI = 0x8968;
        public const GLuint GL_LERP_ATI = 0x8969;
        public const GLuint GL_CND_ATI = 0x896A;
        public const GLuint GL_CND0_ATI = 0x896B;
        public const GLuint GL_DOT2_ADD_ATI = 0x896C;
        public const GLuint GL_SECONDARY_INTERPOLATOR_ATI = 0x896D;
        public const GLuint GL_NUM_FRAGMENT_REGISTERS_ATI = 0x896E;
        public const GLuint GL_NUM_FRAGMENT_CONSTANTS_ATI = 0x896F;
        public const GLuint GL_NUM_PASSES_ATI = 0x8970;
        public const GLuint GL_NUM_INSTRUCTIONS_PER_PASS_ATI = 0x8971;
        public const GLuint GL_NUM_INSTRUCTIONS_TOTAL_ATI = 0x8972;
        public const GLuint GL_NUM_INPUT_INTERPOLATOR_COMPONENTS_ATI = 0x8973;
        public const GLuint GL_NUM_LOOPBACK_COMPONENTS_ATI = 0x8974;
        public const GLuint GL_COLOR_ALPHA_PAIRING_ATI = 0x8975;
        public const GLuint GL_SWIZZLE_STR_ATI = 0x8976;
        public const GLuint GL_SWIZZLE_STQ_ATI = 0x8977;
        public const GLuint GL_SWIZZLE_STR_DR_ATI = 0x8978;
        public const GLuint GL_SWIZZLE_STQ_DQ_ATI = 0x8979;
        public const GLuint GL_SWIZZLE_STRQ_ATI = 0x897A;
        public const GLuint GL_SWIZZLE_STRQ_DQ_ATI = 0x897B;
        public const GLuint GL_RED_BIT_ATI = 0x00000001;
        public const GLuint GL_GREEN_BIT_ATI = 0x00000002;
        public const GLuint GL_BLUE_BIT_ATI = 0x00000004;
        public const GLuint GL_2X_BIT_ATI = 0x00000001;
        public const GLuint GL_4X_BIT_ATI = 0x00000002;
        public const GLuint GL_8X_BIT_ATI = 0x00000004;
        public const GLuint GL_HALF_BIT_ATI = 0x00000008;
        public const GLuint GL_QUARTER_BIT_ATI = 0x00000010;
        public const GLuint GL_EIGHTH_BIT_ATI = 0x00000020;
        public const GLuint GL_SATURATE_BIT_ATI = 0x00000040;
        public const GLuint GL_COMP_BIT_ATI = 0x00000002;
        public const GLuint GL_NEGATE_BIT_ATI = 0x00000004;
        public const GLuint GL_BIAS_BIT_ATI = 0x00000008;
        public const GLuint GL_PN_TRIANGLES_ATI = 0x87F0;
        public const GLuint GL_MAX_PN_TRIANGLES_TESSELATION_LEVEL_ATI = 0x87F1;
        public const GLuint GL_PN_TRIANGLES_POINT_MODE_ATI = 0x87F2;
        public const GLuint GL_PN_TRIANGLES_NORMAL_MODE_ATI = 0x87F3;
        public const GLuint GL_PN_TRIANGLES_TESSELATION_LEVEL_ATI = 0x87F4;
        public const GLuint GL_PN_TRIANGLES_POINT_MODE_LINEAR_ATI = 0x87F5;
        public const GLuint GL_PN_TRIANGLES_POINT_MODE_CUBIC_ATI = 0x87F6;
        public const GLuint GL_PN_TRIANGLES_NORMAL_MODE_LINEAR_ATI = 0x87F7;
        public const GLuint GL_PN_TRIANGLES_NORMAL_MODE_QUADRATIC_ATI = 0x87F8;
        public const GLuint GL_STATIC_ATI = 0x8760;
        public const GLuint GL_DYNAMIC_ATI = 0x8761;
        public const GLuint GL_PRESERVE_ATI = 0x8762;
        public const GLuint GL_DISCARD_ATI = 0x8763;
        public const GLuint GL_OBJECT_BUFFER_SIZE_ATI = 0x8764;
        public const GLuint GL_OBJECT_BUFFER_USAGE_ATI = 0x8765;
        public const GLuint GL_ARRAY_OBJECT_BUFFER_ATI = 0x8766;
        public const GLuint GL_ARRAY_OBJECT_OFFSET_ATI = 0x8767;
        public const GLuint GL_VERTEX_SHADER_EXT = 0x8780;
        public const GLuint GL_VERTEX_SHADER_BINDING_EXT = 0x8781;
        public const GLuint GL_OP_INDEX_EXT = 0x8782;
        public const GLuint GL_OP_NEGATE_EXT = 0x8783;
        public const GLuint GL_OP_DOT3_EXT = 0x8784;
        public const GLuint GL_OP_DOT4_EXT = 0x8785;
        public const GLuint GL_OP_MUL_EXT = 0x8786;
        public const GLuint GL_OP_ADD_EXT = 0x8787;
        public const GLuint GL_OP_MADD_EXT = 0x8788;
        public const GLuint GL_OP_FRAC_EXT = 0x8789;
        public const GLuint GL_OP_MAX_EXT = 0x878A;
        public const GLuint GL_OP_MIN_EXT = 0x878B;
        public const GLuint GL_OP_SET_GE_EXT = 0x878C;
        public const GLuint GL_OP_SET_LT_EXT = 0x878D;
        public const GLuint GL_OP_CLAMP_EXT = 0x878E;
        public const GLuint GL_OP_FLOOR_EXT = 0x878F;
        public const GLuint GL_OP_ROUND_EXT = 0x8790;
        public const GLuint GL_OP_EXP_BASE_2_EXT = 0x8791;
        public const GLuint GL_OP_LOG_BASE_2_EXT = 0x8792;
        public const GLuint GL_OP_POWER_EXT = 0x8793;
        public const GLuint GL_OP_RECIP_EXT = 0x8794;
        public const GLuint GL_OP_RECIP_SQRT_EXT = 0x8795;
        public const GLuint GL_OP_SUB_EXT = 0x8796;
        public const GLuint GL_OP_CROSS_PRODUCT_EXT = 0x8797;
        public const GLuint GL_OP_MULTIPLY_MATRIX_EXT = 0x8798;
        public const GLuint GL_OP_MOV_EXT = 0x8799;
        public const GLuint GL_OUTPUT_VERTEX_EXT = 0x879A;
        public const GLuint GL_OUTPUT_COLOR0_EXT = 0x879B;
        public const GLuint GL_OUTPUT_COLOR1_EXT = 0x879C;
        public const GLuint GL_OUTPUT_TEXTURE_COORD0_EXT = 0x879D;
        public const GLuint GL_OUTPUT_TEXTURE_COORD1_EXT = 0x879E;
        public const GLuint GL_OUTPUT_TEXTURE_COORD2_EXT = 0x879F;
        public const GLuint GL_OUTPUT_TEXTURE_COORD3_EXT = 0x87A0;
        public const GLuint GL_OUTPUT_TEXTURE_COORD4_EXT = 0x87A1;
        public const GLuint GL_OUTPUT_TEXTURE_COORD5_EXT = 0x87A2;
        public const GLuint GL_OUTPUT_TEXTURE_COORD6_EXT = 0x87A3;
        public const GLuint GL_OUTPUT_TEXTURE_COORD7_EXT = 0x87A4;
        public const GLuint GL_OUTPUT_TEXTURE_COORD8_EXT = 0x87A5;
        public const GLuint GL_OUTPUT_TEXTURE_COORD9_EXT = 0x87A6;
        public const GLuint GL_OUTPUT_TEXTURE_COORD10_EXT = 0x87A7;
        public const GLuint GL_OUTPUT_TEXTURE_COORD11_EXT = 0x87A8;
        public const GLuint GL_OUTPUT_TEXTURE_COORD12_EXT = 0x87A9;
        public const GLuint GL_OUTPUT_TEXTURE_COORD13_EXT = 0x87AA;
        public const GLuint GL_OUTPUT_TEXTURE_COORD14_EXT = 0x87AB;
        public const GLuint GL_OUTPUT_TEXTURE_COORD15_EXT = 0x87AC;
        public const GLuint GL_OUTPUT_TEXTURE_COORD16_EXT = 0x87AD;
        public const GLuint GL_OUTPUT_TEXTURE_COORD17_EXT = 0x87AE;
        public const GLuint GL_OUTPUT_TEXTURE_COORD18_EXT = 0x87AF;
        public const GLuint GL_OUTPUT_TEXTURE_COORD19_EXT = 0x87B0;
        public const GLuint GL_OUTPUT_TEXTURE_COORD20_EXT = 0x87B1;
        public const GLuint GL_OUTPUT_TEXTURE_COORD21_EXT = 0x87B2;
        public const GLuint GL_OUTPUT_TEXTURE_COORD22_EXT = 0x87B3;
        public const GLuint GL_OUTPUT_TEXTURE_COORD23_EXT = 0x87B4;
        public const GLuint GL_OUTPUT_TEXTURE_COORD24_EXT = 0x87B5;
        public const GLuint GL_OUTPUT_TEXTURE_COORD25_EXT = 0x87B6;
        public const GLuint GL_OUTPUT_TEXTURE_COORD26_EXT = 0x87B7;
        public const GLuint GL_OUTPUT_TEXTURE_COORD27_EXT = 0x87B8;
        public const GLuint GL_OUTPUT_TEXTURE_COORD28_EXT = 0x87B9;
        public const GLuint GL_OUTPUT_TEXTURE_COORD29_EXT = 0x87BA;
        public const GLuint GL_OUTPUT_TEXTURE_COORD30_EXT = 0x87BB;
        public const GLuint GL_OUTPUT_TEXTURE_COORD31_EXT = 0x87BC;
        public const GLuint GL_OUTPUT_FOG_EXT = 0x87BD;
        public const GLuint GL_SCALAR_EXT = 0x87BE;
        public const GLuint GL_VECTOR_EXT = 0x87BF;
        public const GLuint GL_MATRIX_EXT = 0x87C0;
        public const GLuint GL_VARIANT_EXT = 0x87C1;
        public const GLuint GL_INVARIANT_EXT = 0x87C2;
        public const GLuint GL_LOCAL_CONSTANT_EXT = 0x87C3;
        public const GLuint GL_LOCAL_EXT = 0x87C4;
        public const GLuint GL_MAX_VERTEX_SHADER_INSTRUCTIONS_EXT = 0x87C5;
        public const GLuint GL_MAX_VERTEX_SHADER_VARIANTS_EXT = 0x87C6;
        public const GLuint GL_MAX_VERTEX_SHADER_INVARIANTS_EXT = 0x87C7;
        public const GLuint GL_MAX_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = 0x87C8;
        public const GLuint GL_MAX_VERTEX_SHADER_LOCALS_EXT = 0x87C9;
        public const GLuint GL_MAX_OPTIMIZED_VERTEX_SHADER_INSTRUCTIONS_EXT = 0x87CA;
        public const GLuint GL_MAX_OPTIMIZED_VERTEX_SHADER_VARIANTS_EXT = 0x87CB;
        public const GLuint GL_MAX_OPTIMIZED_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = 0x87CC;
        public const GLuint GL_MAX_OPTIMIZED_VERTEX_SHADER_INVARIANTS_EXT = 0x87CD;
        public const GLuint GL_MAX_OPTIMIZED_VERTEX_SHADER_LOCALS_EXT = 0x87CE;
        public const GLuint GL_VERTEX_SHADER_INSTRUCTIONS_EXT = 0x87CF;
        public const GLuint GL_VERTEX_SHADER_VARIANTS_EXT = 0x87D0;
        public const GLuint GL_VERTEX_SHADER_INVARIANTS_EXT = 0x87D1;
        public const GLuint GL_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = 0x87D2;
        public const GLuint GL_VERTEX_SHADER_LOCALS_EXT = 0x87D3;
        public const GLuint GL_VERTEX_SHADER_OPTIMIZED_EXT = 0x87D4;
        public const GLuint GL_X_EXT = 0x87D5;
        public const GLuint GL_Y_EXT = 0x87D6;
        public const GLuint GL_Z_EXT = 0x87D7;
        public const GLuint GL_W_EXT = 0x87D8;
        public const GLuint GL_NEGATIVE_X_EXT = 0x87D9;
        public const GLuint GL_NEGATIVE_Y_EXT = 0x87DA;
        public const GLuint GL_NEGATIVE_Z_EXT = 0x87DB;
        public const GLuint GL_NEGATIVE_W_EXT = 0x87DC;
        public const GLuint GL_ZERO_EXT = 0x87DD;
        public const GLuint GL_ONE_EXT = 0x87DE;
        public const GLuint GL_NEGATIVE_ONE_EXT = 0x87DF;
        public const GLuint GL_NORMALIZED_RANGE_EXT = 0x87E0;
        public const GLuint GL_FULL_RANGE_EXT = 0x87E1;
        public const GLuint GL_CURRENT_VERTEX_EXT = 0x87E2;
        public const GLuint GL_MVP_MATRIX_EXT = 0x87E3;
        public const GLuint GL_VARIANT_VALUE_EXT = 0x87E4;
        public const GLuint GL_VARIANT_DATATYPE_EXT = 0x87E5;
        public const GLuint GL_VARIANT_ARRAY_STRIDE_EXT = 0x87E6;
        public const GLuint GL_VARIANT_ARRAY_TYPE_EXT = 0x87E7;
        public const GLuint GL_VARIANT_ARRAY_EXT = 0x87E8;
        public const GLuint GL_VARIANT_ARRAY_POINTER_EXT = 0x87E9;
        public const GLuint GL_INVARIANT_VALUE_EXT = 0x87EA;
        public const GLuint GL_INVARIANT_DATATYPE_EXT = 0x87EB;
        public const GLuint GL_LOCAL_CONSTANT_VALUE_EXT = 0x87EC;
        public const GLuint GL_LOCAL_CONSTANT_DATATYPE_EXT = 0x87ED;
        public const GLuint GL_MAX_VERTEX_STREAMS_ATI = 0x876B;
        public const GLuint GL_VERTEX_STREAM0_ATI = 0x876C;
        public const GLuint GL_VERTEX_STREAM1_ATI = 0x876D;
        public const GLuint GL_VERTEX_STREAM2_ATI = 0x876E;
        public const GLuint GL_VERTEX_STREAM3_ATI = 0x876F;
        public const GLuint GL_VERTEX_STREAM4_ATI = 0x8770;
        public const GLuint GL_VERTEX_STREAM5_ATI = 0x8771;
        public const GLuint GL_VERTEX_STREAM6_ATI = 0x8772;
        public const GLuint GL_VERTEX_STREAM7_ATI = 0x8773;
        public const GLuint GL_VERTEX_SOURCE_ATI = 0x8774;
        public const GLuint GL_ELEMENT_ARRAY_ATI = 0x8768;
        public const GLuint GL_ELEMENT_ARRAY_TYPE_ATI = 0x8769;
        public const GLuint GL_ELEMENT_ARRAY_POINTER_ATI = 0x876A;
        public const GLuint GL_QUAD_MESH_SUN = 0x8614;
        public const GLuint GL_TRIANGLE_MESH_SUN = 0x8615;
        public const GLuint GL_SLICE_ACCUM_SUN = 0x85CC;
        public const GLuint GL_MULTISAMPLE_FILTER_HINT_NV = 0x8534;
        public const GLuint GL_DEPTH_CLAMP_NV = 0x864F;
        public const GLuint GL_PIXEL_COUNTER_BITS_NV = 0x8864;
        public const GLuint GL_CURRENT_OCCLUSION_QUERY_ID_NV = 0x8865;
        public const GLuint GL_PIXEL_COUNT_NV = 0x8866;
        public const GLuint GL_PIXEL_COUNT_AVAILABLE_NV = 0x8867;
        public const GLuint GL_POINT_SPRITE_NV = 0x8861;
        public const GLuint GL_COORD_REPLACE_NV = 0x8862;
        public const GLuint GL_POINT_SPRITE_R_MODE_NV = 0x8863;
        public const GLuint GL_OFFSET_PROJECTIVE_TEXTURE_2D_NV = 0x8850;
        public const GLuint GL_OFFSET_PROJECTIVE_TEXTURE_2D_SCALE_NV = 0x8851;
        public const GLuint GL_OFFSET_PROJECTIVE_TEXTURE_RECTANGLE_NV = 0x8852;
        public const GLuint GL_OFFSET_PROJECTIVE_TEXTURE_RECTANGLE_SCALE_NV = 0x8853;
        public const GLuint GL_OFFSET_HILO_TEXTURE_2D_NV = 0x8854;
        public const GLuint GL_OFFSET_HILO_TEXTURE_RECTANGLE_NV = 0x8855;
        public const GLuint GL_OFFSET_HILO_PROJECTIVE_TEXTURE_2D_NV = 0x8856;
        public const GLuint GL_OFFSET_HILO_PROJECTIVE_TEXTURE_RECTANGLE_NV = 0x8857;
        public const GLuint GL_DEPENDENT_HILO_TEXTURE_2D_NV = 0x8858;
        public const GLuint GL_DEPENDENT_RGB_TEXTURE_3D_NV = 0x8859;
        public const GLuint GL_DEPENDENT_RGB_TEXTURE_CUBE_MAP_NV = 0x885A;
        public const GLuint GL_DOT_PRODUCT_PASS_THROUGH_NV = 0x885B;
        public const GLuint GL_DOT_PRODUCT_TEXTURE_1D_NV = 0x885C;
        public const GLuint GL_DOT_PRODUCT_AFFINE_DEPTH_REPLACE_NV = 0x885D;
        public const GLuint GL_HILO8_NV = 0x885E;
        public const GLuint GL_SIGNED_HILO8_NV = 0x885F;
        public const GLuint GL_FORCE_BLUE_TO_ONE_NV = 0x8860;
        public const GLuint GL_STENCIL_TEST_TWO_SIDE_EXT = 0x8910;
        public const GLuint GL_ACTIVE_STENCIL_FACE_EXT = 0x8911;
        public const GLuint GL_TEXT_FRAGMENT_SHADER_ATI = 0x8200;
        public const GLuint GL_UNPACK_CLIENT_STORAGE_APPLE = 0x85B2;
        public const GLuint GL_ELEMENT_ARRAY_APPLE = 0x8768;
        public const GLuint GL_ELEMENT_ARRAY_TYPE_APPLE = 0x8769;
        public const GLuint GL_ELEMENT_ARRAY_POINTER_APPLE = 0x876A;
        public const GLuint GL_DRAW_PIXELS_APPLE = 0x8A0A;
        public const GLuint GL_FENCE_APPLE = 0x8A0B;
        public const GLuint GL_VERTEX_ARRAY_BINDING_APPLE = 0x85B5;
        public const GLuint GL_VERTEX_ARRAY_RANGE_APPLE = 0x851D;
        public const GLuint GL_VERTEX_ARRAY_RANGE_LENGTH_APPLE = 0x851E;
        public const GLuint GL_VERTEX_ARRAY_STORAGE_HINT_APPLE = 0x851F;
        public const GLuint GL_VERTEX_ARRAY_RANGE_POINTER_APPLE = 0x8521;
        public const GLuint GL_STORAGE_CACHED_APPLE = 0x85BE;
        public const GLuint GL_STORAGE_SHARED_APPLE = 0x85BF;
        public const GLuint GL_YCBCR_422_APPLE = 0x85B9;
        public const GLuint GL_UNSIGNED_SHORT_8_8_APPLE = 0x85BA;
        public const GLuint GL_UNSIGNED_SHORT_8_8_REV_APPLE = 0x85BB;
        public const GLuint GL_RGB_S3TC = 0x83A0;
        public const GLuint GL_RGB4_S3TC = 0x83A1;
        public const GLuint GL_RGBA_S3TC = 0x83A2;
        public const GLuint GL_RGBA4_S3TC = 0x83A3;
        public const GLuint GL_MAX_DRAW_BUFFERS_ATI = 0x8824;
        public const GLuint GL_DRAW_BUFFER0_ATI = 0x8825;
        public const GLuint GL_DRAW_BUFFER1_ATI = 0x8826;
        public const GLuint GL_DRAW_BUFFER2_ATI = 0x8827;
        public const GLuint GL_DRAW_BUFFER3_ATI = 0x8828;
        public const GLuint GL_DRAW_BUFFER4_ATI = 0x8829;
        public const GLuint GL_DRAW_BUFFER5_ATI = 0x882A;
        public const GLuint GL_DRAW_BUFFER6_ATI = 0x882B;
        public const GLuint GL_DRAW_BUFFER7_ATI = 0x882C;
        public const GLuint GL_DRAW_BUFFER8_ATI = 0x882D;
        public const GLuint GL_DRAW_BUFFER9_ATI = 0x882E;
        public const GLuint GL_DRAW_BUFFER10_ATI = 0x882F;
        public const GLuint GL_DRAW_BUFFER11_ATI = 0x8830;
        public const GLuint GL_DRAW_BUFFER12_ATI = 0x8831;
        public const GLuint GL_DRAW_BUFFER13_ATI = 0x8832;
        public const GLuint GL_DRAW_BUFFER14_ATI = 0x8833;
        public const GLuint GL_DRAW_BUFFER15_ATI = 0x8834;
        public const GLuint GL_TYPE_RGBA_FLOAT_ATI = 0x8820;
        public const GLuint GL_COLOR_CLEAR_UNCLAMPED_VALUE_ATI = 0x8835;
        public const GLuint GL_MODULATE_ADD_ATI = 0x8744;
        public const GLuint GL_MODULATE_SIGNED_ADD_ATI = 0x8745;
        public const GLuint GL_MODULATE_SUBTRACT_ATI = 0x8746;
        public const GLuint GL_RGBA_FLOAT32_ATI = 0x8814;
        public const GLuint GL_RGB_FLOAT32_ATI = 0x8815;
        public const GLuint GL_ALPHA_FLOAT32_ATI = 0x8816;
        public const GLuint GL_INTENSITY_FLOAT32_ATI = 0x8817;
        public const GLuint GL_LUMINANCE_FLOAT32_ATI = 0x8818;
        public const GLuint GL_LUMINANCE_ALPHA_FLOAT32_ATI = 0x8819;
        public const GLuint GL_RGBA_FLOAT16_ATI = 0x881A;
        public const GLuint GL_RGB_FLOAT16_ATI = 0x881B;
        public const GLuint GL_ALPHA_FLOAT16_ATI = 0x881C;
        public const GLuint GL_INTENSITY_FLOAT16_ATI = 0x881D;
        public const GLuint GL_LUMINANCE_FLOAT16_ATI = 0x881E;
        public const GLuint GL_LUMINANCE_ALPHA_FLOAT16_ATI = 0x881F;
        public const GLuint GL_FLOAT_R_NV = 0x8880;
        public const GLuint GL_FLOAT_RG_NV = 0x8881;
        public const GLuint GL_FLOAT_RGB_NV = 0x8882;
        public const GLuint GL_FLOAT_RGBA_NV = 0x8883;
        public const GLuint GL_FLOAT_R16_NV = 0x8884;
        public const GLuint GL_FLOAT_R32_NV = 0x8885;
        public const GLuint GL_FLOAT_RG16_NV = 0x8886;
        public const GLuint GL_FLOAT_RG32_NV = 0x8887;
        public const GLuint GL_FLOAT_RGB16_NV = 0x8888;
        public const GLuint GL_FLOAT_RGB32_NV = 0x8889;
        public const GLuint GL_FLOAT_RGBA16_NV = 0x888A;
        public const GLuint GL_FLOAT_RGBA32_NV = 0x888B;
        public const GLuint GL_TEXTURE_FLOAT_COMPONENTS_NV = 0x888C;
        public const GLuint GL_FLOAT_CLEAR_COLOR_VALUE_NV = 0x888D;
        public const GLuint GL_FLOAT_RGBA_MODE_NV = 0x888E;
        public const GLuint GL_MAX_FRAGMENT_PROGRAM_LOCAL_PARAMETERS_NV = 0x8868;
        public const GLuint GL_FRAGMENT_PROGRAM_NV = 0x8870;
        public const GLuint GL_MAX_TEXTURE_COORDS_NV = 0x8871;
        public const GLuint GL_MAX_TEXTURE_IMAGE_UNITS_NV = 0x8872;
        public const GLuint GL_FRAGMENT_PROGRAM_BINDING_NV = 0x8873;
        public const GLuint GL_PROGRAM_ERROR_STRING_NV = 0x8874;
        public const GLuint GL_HALF_FLOAT_NV = 0x140B;
        public const GLuint GL_WRITE_PIXEL_DATA_RANGE_NV = 0x8878;
        public const GLuint GL_READ_PIXEL_DATA_RANGE_NV = 0x8879;
        public const GLuint GL_WRITE_PIXEL_DATA_RANGE_LENGTH_NV = 0x887A;
        public const GLuint GL_READ_PIXEL_DATA_RANGE_LENGTH_NV = 0x887B;
        public const GLuint GL_WRITE_PIXEL_DATA_RANGE_POINTER_NV = 0x887C;
        public const GLuint GL_READ_PIXEL_DATA_RANGE_POINTER_NV = 0x887D;
        public const GLuint GL_PRIMITIVE_RESTART_NV = 0x8558;
        public const GLuint GL_PRIMITIVE_RESTART_INDEX_NV = 0x8559;
        public const GLuint GL_TEXTURE_UNSIGNED_REMAP_MODE_NV = 0x888F;
        public const GLuint GL_STENCIL_BACK_FUNC_ATI = 0x8800;
        public const GLuint GL_STENCIL_BACK_FAIL_ATI = 0x8801;
        public const GLuint GL_STENCIL_BACK_PASS_DEPTH_FAIL_ATI = 0x8802;
        public const GLuint GL_STENCIL_BACK_PASS_DEPTH_PASS_ATI = 0x8803;
        public const GLuint GL_IMPLEMENTATION_COLOR_READ_TYPE_OES = 0x8B9A;
        public const GLuint GL_IMPLEMENTATION_COLOR_READ_FORMAT_OES = 0x8B9B;
        public const GLuint GL_DEPTH_BOUNDS_TEST_EXT = 0x8890;
        public const GLuint GL_DEPTH_BOUNDS_EXT = 0x8891;
        public const GLuint GL_MIRROR_CLAMP_EXT = 0x8742;
        public const GLuint GL_MIRROR_CLAMP_TO_EDGE_EXT = 0x8743;
        public const GLuint GL_MIRROR_CLAMP_TO_BORDER_EXT = 0x8912;
        public const GLuint GL_BLEND_EQUATION_RGB_EXT = GL_BLEND_EQUATION;
        public const GLuint GL_BLEND_EQUATION_ALPHA_EXT = 0x883D;
        public const GLuint GL_PACK_INVERT_MESA = 0x8758;
        public const GLuint GL_UNSIGNED_SHORT_8_8_MESA = 0x85BA;
        public const GLuint GL_UNSIGNED_SHORT_8_8_REV_MESA = 0x85BB;
        public const GLuint GL_YCBCR_MESA = 0x8757;
        public const GLuint GL_PIXEL_PACK_BUFFER_EXT = 0x88EB;
        public const GLuint GL_PIXEL_UNPACK_BUFFER_EXT = 0x88EC;
        public const GLuint GL_PIXEL_PACK_BUFFER_BINDING_EXT = 0x88ED;
        public const GLuint GL_PIXEL_UNPACK_BUFFER_BINDING_EXT = 0x88EF;
        public const GLuint GL_MAX_PROGRAM_EXEC_INSTRUCTIONS_NV = 0x88F4;
        public const GLuint GL_MAX_PROGRAM_CALL_DEPTH_NV = 0x88F5;
        public const GLuint GL_MAX_PROGRAM_IF_DEPTH_NV = 0x88F6;
        public const GLuint GL_MAX_PROGRAM_LOOP_DEPTH_NV = 0x88F7;
        public const GLuint GL_MAX_PROGRAM_LOOP_COUNT_NV = 0x88F8;
        public const GLuint GL_INVALID_FRAMEBUFFER_OPERATION_EXT = 0x0506;
        public const GLuint GL_MAX_RENDERBUFFER_SIZE_EXT = 0x84E8;
        public const GLuint GL_FRAMEBUFFER_BINDING_EXT = 0x8CA6;
        public const GLuint GL_RENDERBUFFER_BINDING_EXT = 0x8CA7;
        public const GLuint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE_EXT = 0x8CD0;
        public const GLuint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME_EXT = 0x8CD1;
        public const GLuint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL_EXT = 0x8CD2;
        public const GLuint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE_EXT = 0x8CD3;
        public const GLuint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_3D_ZOFFSET_EXT = 0x8CD4;
        public const GLuint GL_FRAMEBUFFER_COMPLETE_EXT = 0x8CD5;
        public const GLuint GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENTS_EXT = 0x8CD6;
        public const GLuint GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT_EXT = 0x8CD7;
        public const GLuint GL_FRAMEBUFFER_INCOMPLETE_DUPLICATE_ATTACHMENT_EXT = 0x8CD8;
        public const GLuint GL_FRAMEBUFFER_INCOMPLETE_DIMENSIONS_EXT = 0x8CD9;
        public const GLuint GL_FRAMEBUFFER_INCOMPLETE_FORMATS_EXT = 0x8CDA;
        public const GLuint GL_FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER_EXT = 0x8CDB;
        public const GLuint GL_FRAMEBUFFER_INCOMPLETE_READ_BUFFER_EXT = 0x8CDC;
        public const GLuint GL_FRAMEBUFFER_UNSUPPORTED_EXT = 0x8CDD;
        public const GLuint GL_FRAMEBUFFER_STATUS_ERROR_EXT = 0x8CDE;
        public const GLuint GL_MAX_COLOR_ATTACHMENTS_EXT = 0x8CDF;
        public const GLuint GL_COLOR_ATTACHMENT0_EXT = 0x8CE0;
        public const GLuint GL_COLOR_ATTACHMENT1_EXT = 0x8CE1;
        public const GLuint GL_COLOR_ATTACHMENT2_EXT = 0x8CE2;
        public const GLuint GL_COLOR_ATTACHMENT3_EXT = 0x8CE3;
        public const GLuint GL_COLOR_ATTACHMENT4_EXT = 0x8CE4;
        public const GLuint GL_COLOR_ATTACHMENT5_EXT = 0x8CE5;
        public const GLuint GL_COLOR_ATTACHMENT6_EXT = 0x8CE6;
        public const GLuint GL_COLOR_ATTACHMENT7_EXT = 0x8CE7;
        public const GLuint GL_COLOR_ATTACHMENT8_EXT = 0x8CE8;
        public const GLuint GL_COLOR_ATTACHMENT9_EXT = 0x8CE9;
        public const GLuint GL_COLOR_ATTACHMENT10_EXT = 0x8CEA;
        public const GLuint GL_COLOR_ATTACHMENT11_EXT = 0x8CEB;
        public const GLuint GL_COLOR_ATTACHMENT12_EXT = 0x8CEC;
        public const GLuint GL_COLOR_ATTACHMENT13_EXT = 0x8CED;
        public const GLuint GL_COLOR_ATTACHMENT14_EXT = 0x8CEE;
        public const GLuint GL_COLOR_ATTACHMENT15_EXT = 0x8CEF;
        public const GLuint GL_DEPTH_ATTACHMENT_EXT = 0x8D00;
        public const GLuint GL_STENCIL_ATTACHMENT_EXT = 0x8D20;
        public const GLuint GL_FRAMEBUFFER_EXT = 0x8D40;
        public const GLuint GL_RENDERBUFFER_EXT = 0x8D41;
        public const GLuint GL_RENDERBUFFER_WIDTH_EXT = 0x8D42;
        public const GLuint GL_RENDERBUFFER_HEIGHT_EXT = 0x8D43;
        public const GLuint GL_RENDERBUFFER_INTERNAL_FORMAT_EXT = 0x8D44;
        public const GLuint GL_STENCIL_INDEX_EXT = 0x8D45;
        public const GLuint GL_STENCIL_INDEX1_EXT = 0x8D46;
        public const GLuint GL_STENCIL_INDEX4_EXT = 0x8D47;
        public const GLuint GL_STENCIL_INDEX8_EXT = 0x8D48;
        public const GLuint GL_STENCIL_INDEX16_EXT = 0x8D49;
        #endregion

        #region Function signatures

        public static class Delegates
        {
            public delegate void glNewList(GLuint list, GLenum mode);
            public delegate void glEndList();
            public delegate void glCallList(GLuint list);
            public delegate void glCallLists_(GLsizei n, GLenum type, IntPtr lists);
            public delegate void glDeleteLists(GLuint list, GLsizei range);
            public delegate GLuint glGenLists(GLsizei range);
            public delegate void glListBase(GLuint @base);
            public delegate void glBegin(GLenum mode);
            public delegate void glBitmap_(GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, IntPtr bitmap);
            public delegate void glColor3b(GLbyte red, GLbyte green, GLbyte blue);
            public delegate void glColor3bv_(IntPtr v);
            public delegate void glColor3d(GLdouble red, GLdouble green, GLdouble blue);
            public delegate void glColor3dv_(IntPtr v);
            public delegate void glColor3f(GLfloat red, GLfloat green, GLfloat blue);
            public delegate void glColor3fv_(IntPtr v);
            public delegate void glColor3i(GLint red, GLint green, GLint blue);
            public delegate void glColor3iv_(IntPtr v);
            public delegate void glColor3s(GLshort red, GLshort green, GLshort blue);
            public delegate void glColor3sv_(IntPtr v);
            public delegate void glColor3ub(GLubyte red, GLubyte green, GLubyte blue);
            public delegate void glColor3ubv_(IntPtr v);
            public delegate void glColor3ui(GLuint red, GLuint green, GLuint blue);
            public delegate void glColor3uiv_(IntPtr v);
            public delegate void glColor3us(GLushort red, GLushort green, GLushort blue);
            public delegate void glColor3usv_(IntPtr v);
            public delegate void glColor4b(GLbyte red, GLbyte green, GLbyte blue, GLbyte alpha);
            public delegate void glColor4bv_(IntPtr v);
            public delegate void glColor4d(GLdouble red, GLdouble green, GLdouble blue, GLdouble alpha);
            public delegate void glColor4dv_(IntPtr v);
            public delegate void glColor4f(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);
            public delegate void glColor4fv_(IntPtr v);
            public delegate void glColor4i(GLint red, GLint green, GLint blue, GLint alpha);
            public delegate void glColor4iv_(IntPtr v);
            public delegate void glColor4s(GLshort red, GLshort green, GLshort blue, GLshort alpha);
            public delegate void glColor4sv_(IntPtr v);
            public delegate void glColor4ub(GLubyte red, GLubyte green, GLubyte blue, GLubyte alpha);
            public delegate void glColor4ubv_(IntPtr v);
            public delegate void glColor4ui(GLuint red, GLuint green, GLuint blue, GLuint alpha);
            public delegate void glColor4uiv_(IntPtr v);
            public delegate void glColor4us(GLushort red, GLushort green, GLushort blue, GLushort alpha);
            public delegate void glColor4usv_(IntPtr v);
            public delegate void glEdgeFlag(GLboolean flag);
            public delegate void glEdgeFlagv_(IntPtr flag);
            public delegate void glEnd();
            public delegate void glIndexd(GLdouble c);
            public delegate void glIndexdv_(IntPtr c);
            public delegate void glIndexf(GLfloat c);
            public delegate void glIndexfv_(IntPtr c);
            public delegate void glIndexi(GLint c);
            public delegate void glIndexiv_(IntPtr c);
            public delegate void glIndexs(GLshort c);
            public delegate void glIndexsv_(IntPtr c);
            public delegate void glNormal3b(GLbyte nx, GLbyte ny, GLbyte nz);
            public delegate void glNormal3bv_(IntPtr v);
            public delegate void glNormal3d(GLdouble nx, GLdouble ny, GLdouble nz);
            public delegate void glNormal3dv_(IntPtr v);
            public delegate void glNormal3f(GLfloat nx, GLfloat ny, GLfloat nz);
            public delegate void glNormal3fv_(IntPtr v);
            public delegate void glNormal3i(GLint nx, GLint ny, GLint nz);
            public delegate void glNormal3iv_(IntPtr v);
            public delegate void glNormal3s(GLshort nx, GLshort ny, GLshort nz);
            public delegate void glNormal3sv_(IntPtr v);
            public delegate void glRasterPos2d(GLdouble x, GLdouble y);
            public delegate void glRasterPos2dv_(IntPtr v);
            public delegate void glRasterPos2f(GLfloat x, GLfloat y);
            public delegate void glRasterPos2fv_(IntPtr v);
            public delegate void glRasterPos2i(GLint x, GLint y);
            public delegate void glRasterPos2iv_(IntPtr v);
            public delegate void glRasterPos2s(GLshort x, GLshort y);
            public delegate void glRasterPos2sv_(IntPtr v);
            public delegate void glRasterPos3d(GLdouble x, GLdouble y, GLdouble z);
            public delegate void glRasterPos3dv_(IntPtr v);
            public delegate void glRasterPos3f(GLfloat x, GLfloat y, GLfloat z);
            public delegate void glRasterPos3fv_(IntPtr v);
            public delegate void glRasterPos3i(GLint x, GLint y, GLint z);
            public delegate void glRasterPos3iv_(IntPtr v);
            public delegate void glRasterPos3s(GLshort x, GLshort y, GLshort z);
            public delegate void glRasterPos3sv_(IntPtr v);
            public delegate void glRasterPos4d(GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            public delegate void glRasterPos4dv_(IntPtr v);
            public delegate void glRasterPos4f(GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            public delegate void glRasterPos4fv_(IntPtr v);
            public delegate void glRasterPos4i(GLint x, GLint y, GLint z, GLint w);
            public delegate void glRasterPos4iv_(IntPtr v);
            public delegate void glRasterPos4s(GLshort x, GLshort y, GLshort z, GLshort w);
            public delegate void glRasterPos4sv_(IntPtr v);
            public delegate void glRectd(GLdouble x1, GLdouble y1, GLdouble x2, GLdouble y2);
            public delegate void glRectdv_(IntPtr v1, IntPtr v2);
            public delegate void glRectf(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2);
            public delegate void glRectfv_(IntPtr v1, IntPtr v2);
            public delegate void glRecti(GLint x1, GLint y1, GLint x2, GLint y2);
            public delegate void glRectiv_(IntPtr v1, IntPtr v2);
            public delegate void glRects(GLshort x1, GLshort y1, GLshort x2, GLshort y2);
            public delegate void glRectsv_(IntPtr v1, IntPtr v2);
            public delegate void glTexCoord1d(GLdouble s);
            public delegate void glTexCoord1dv_(IntPtr v);
            public delegate void glTexCoord1f(GLfloat s);
            public delegate void glTexCoord1fv_(IntPtr v);
            public delegate void glTexCoord1i(GLint s);
            public delegate void glTexCoord1iv_(IntPtr v);
            public delegate void glTexCoord1s(GLshort s);
            public delegate void glTexCoord1sv_(IntPtr v);
            public delegate void glTexCoord2d(GLdouble s, GLdouble t);
            public delegate void glTexCoord2dv_(IntPtr v);
            public delegate void glTexCoord2f(GLfloat s, GLfloat t);
            public delegate void glTexCoord2fv_(IntPtr v);
            public delegate void glTexCoord2i(GLint s, GLint t);
            public delegate void glTexCoord2iv_(IntPtr v);
            public delegate void glTexCoord2s(GLshort s, GLshort t);
            public delegate void glTexCoord2sv_(IntPtr v);
            public delegate void glTexCoord3d(GLdouble s, GLdouble t, GLdouble r);
            public delegate void glTexCoord3dv_(IntPtr v);
            public delegate void glTexCoord3f(GLfloat s, GLfloat t, GLfloat r);
            public delegate void glTexCoord3fv_(IntPtr v);
            public delegate void glTexCoord3i(GLint s, GLint t, GLint r);
            public delegate void glTexCoord3iv_(IntPtr v);
            public delegate void glTexCoord3s(GLshort s, GLshort t, GLshort r);
            public delegate void glTexCoord3sv_(IntPtr v);
            public delegate void glTexCoord4d(GLdouble s, GLdouble t, GLdouble r, GLdouble q);
            public delegate void glTexCoord4dv_(IntPtr v);
            public delegate void glTexCoord4f(GLfloat s, GLfloat t, GLfloat r, GLfloat q);
            public delegate void glTexCoord4fv_(IntPtr v);
            public delegate void glTexCoord4i(GLint s, GLint t, GLint r, GLint q);
            public delegate void glTexCoord4iv_(IntPtr v);
            public delegate void glTexCoord4s(GLshort s, GLshort t, GLshort r, GLshort q);
            public delegate void glTexCoord4sv_(IntPtr v);
            public delegate void glVertex2d(GLdouble x, GLdouble y);
            public delegate void glVertex2dv_(IntPtr v);
            public delegate void glVertex2f(GLfloat x, GLfloat y);
            public delegate void glVertex2fv_(IntPtr v);
            public delegate void glVertex2i(GLint x, GLint y);
            public delegate void glVertex2iv_(IntPtr v);
            public delegate void glVertex2s(GLshort x, GLshort y);
            public delegate void glVertex2sv_(IntPtr v);
            public delegate void glVertex3d(GLdouble x, GLdouble y, GLdouble z);
            public delegate void glVertex3dv_(IntPtr v);
            public delegate void glVertex3f(GLfloat x, GLfloat y, GLfloat z);
            public delegate void glVertex3fv_(IntPtr v);
            public delegate void glVertex3i(GLint x, GLint y, GLint z);
            public delegate void glVertex3iv_(IntPtr v);
            public delegate void glVertex3s(GLshort x, GLshort y, GLshort z);
            public delegate void glVertex3sv_(IntPtr v);
            public delegate void glVertex4d(GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            public delegate void glVertex4dv_(IntPtr v);
            public delegate void glVertex4f(GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            public delegate void glVertex4fv_(IntPtr v);
            public delegate void glVertex4i(GLint x, GLint y, GLint z, GLint w);
            public delegate void glVertex4iv_(IntPtr v);
            public delegate void glVertex4s(GLshort x, GLshort y, GLshort z, GLshort w);
            public delegate void glVertex4sv_(IntPtr v);
            public delegate void glClipPlane_(GLenum plane, IntPtr equation);
            public delegate void glColorMaterial(GLenum face, GLenum mode);
            public delegate void glCullFace(GLenum mode);
            public delegate void glFogf(GLenum pname, GLfloat param);
            public delegate void glFogfv_(GLenum pname, IntPtr parameters);
            public delegate void glFogi(GLenum pname, GLint param);
            public delegate void glFogiv_(GLenum pname, IntPtr parameters);
            public delegate void glFrontFace(GLenum mode);
            public delegate void glHint(GLenum target, GLenum mode);
            public delegate void glLightf(GLenum light, GLenum pname, GLfloat param);
            public delegate void glLightfv_(GLenum light, GLenum pname, IntPtr parameters);
            public delegate void glLighti(GLenum light, GLenum pname, GLint param);
            public delegate void glLightiv_(GLenum light, GLenum pname, IntPtr parameters);
            public delegate void glLightModelf(GLenum pname, GLfloat param);
            public delegate void glLightModelfv_(GLenum pname, IntPtr parameters);
            public delegate void glLightModeli(GLenum pname, GLint param);
            public delegate void glLightModeliv_(GLenum pname, IntPtr parameters);
            public delegate void glLineStipple_(GLint factor, GLushort pattern);
            public delegate void glLineWidth(GLfloat width);
            public delegate void glMaterialf(GLenum face, GLenum pname, GLfloat param);
            public delegate void glMaterialfv_(GLenum face, GLenum pname, IntPtr parameters);
            public delegate void glMateriali(GLenum face, GLenum pname, GLint param);
            public delegate void glMaterialiv_(GLenum face, GLenum pname, IntPtr parameters);
            public delegate void glPointSize(GLfloat size);
            public delegate void glPolygonMode(GLenum face, GLenum mode);
            public delegate void glPolygonStipple_(IntPtr mask);
            public delegate void glScissor(GLint x, GLint y, GLsizei width, GLsizei height);
            public delegate void glShadeModel(GLenum mode);
            public delegate void glTexParameterf(GLenum target, GLenum pname, GLfloat param);
            public delegate void glTexParameterfv_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glTexParameteri(GLenum target, GLenum pname, GLint param);
            public delegate void glTexParameteriv_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glTexImage1D_(GLenum target, GLint level, GLint internalformat, GLsizei width, GLint border, GLenum format, GLenum type, IntPtr pixels);
            public delegate void glTexImage2D_(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, IntPtr pixels);
            public delegate void glTexEnvf(GLenum target, GLenum pname, GLfloat param);
            public delegate void glTexEnvfv_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glTexEnvi(GLenum target, GLenum pname, GLint param);
            public delegate void glTexEnviv_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glTexGend(GLenum coord, GLenum pname, GLdouble param);
            public delegate void glTexGendv_(GLenum coord, GLenum pname, IntPtr parameters);
            public delegate void glTexGenf(GLenum coord, GLenum pname, GLfloat param);
            public delegate void glTexGenfv_(GLenum coord, GLenum pname, IntPtr parameters);
            public delegate void glTexGeni(GLenum coord, GLenum pname, GLint param);
            public delegate void glTexGeniv_(GLenum coord, GLenum pname, IntPtr parameters);
            public delegate void glFeedbackBuffer(GLsizei size, GLenum type, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] buffer);
            public delegate void glSelectBuffer(GLsizei size, [MarshalAs(UnmanagedType.LPArray)] GLuint[] buffer);
            public delegate GLint glRenderMode(GLenum mode);
            public delegate void glInitNames();
            public delegate void glLoadName(GLuint name);
            public delegate void glPassThrough(GLfloat token);
            public delegate void glPopName();
            public delegate void glPushName(GLuint name);
            public delegate void glDrawBuffer(GLenum mode);
            public delegate void glClear(GLbitfield mask);
            public delegate void glClearAccum(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);
            public delegate void glClearIndex(GLfloat c);
            public delegate void glClearColor(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);
            public delegate void glClearStencil(GLint s);
            public delegate void glClearDepth(GLclampd depth);
            public delegate void glStencilMask(GLuint mask);
            public delegate void glColorMask(GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha);
            public delegate void glDepthMask(GLboolean flag);
            public delegate void glIndexMask(GLuint mask);
            public delegate void glAccum(GLenum op, GLfloat value);
            public delegate void glDisable(GLenum cap);
            public delegate void glEnable(GLenum cap);
            public delegate void glFinish();
            public delegate void glFlush();
            public delegate void glPopAttrib();
            public delegate void glPushAttrib(GLbitfield mask);
            public delegate void glMap1d_(GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, IntPtr points);
            public delegate void glMap1f_(GLenum target, GLfloat u1, GLfloat u2, GLint stride, GLint order, IntPtr points);
            public delegate void glMap2d_(GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, IntPtr points);
            public delegate void glMap2f_(GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, IntPtr points);
            public delegate void glMapGrid1d(GLint un, GLdouble u1, GLdouble u2);
            public delegate void glMapGrid1f(GLint un, GLfloat u1, GLfloat u2);
            public delegate void glMapGrid2d(GLint un, GLdouble u1, GLdouble u2, GLint vn, GLdouble v1, GLdouble v2);
            public delegate void glMapGrid2f(GLint un, GLfloat u1, GLfloat u2, GLint vn, GLfloat v1, GLfloat v2);
            public delegate void glEvalCoord1d(GLdouble u);
            public delegate void glEvalCoord1dv_(IntPtr u);
            public delegate void glEvalCoord1f(GLfloat u);
            public delegate void glEvalCoord1fv_(IntPtr u);
            public delegate void glEvalCoord2d(GLdouble u, GLdouble v);
            public delegate void glEvalCoord2dv_(IntPtr u);
            public delegate void glEvalCoord2f(GLfloat u, GLfloat v);
            public delegate void glEvalCoord2fv_(IntPtr u);
            public delegate void glEvalMesh1(GLenum mode, GLint i1, GLint i2);
            public delegate void glEvalPoint1(GLint i);
            public delegate void glEvalMesh2(GLenum mode, GLint i1, GLint i2, GLint j1, GLint j2);
            public delegate void glEvalPoint2(GLint i, GLint j);
            public delegate void glAlphaFunc(GLenum func, GLclampf reference);
            public delegate void glBlendFunc(GLenum sfactor, GLenum dfactor);
            public delegate void glLogicOp(GLenum opcode);
            public delegate void glStencilFunc(GLenum func, GLint reference, GLuint mask);
            public delegate void glStencilOp(GLenum fail, GLenum zfail, GLenum zpass);
            public delegate void glDepthFunc(GLenum func);
            public delegate void glPixelZoom(GLfloat xfactor, GLfloat yfactor);
            public delegate void glPixelTransferf(GLenum pname, GLfloat param);
            public delegate void glPixelTransferi(GLenum pname, GLint param);
            public delegate void glPixelStoref(GLenum pname, GLfloat param);
            public delegate void glPixelStorei(GLenum pname, GLint param);
            public delegate void glPixelMapfv_(GLenum map, GLint mapsize, IntPtr values);
            public delegate void glPixelMapuiv_(GLenum map, GLint mapsize, IntPtr values);
            public delegate void glPixelMapusv_(GLenum map, GLint mapsize, IntPtr values);
            public delegate void glReadBuffer(GLenum mode);
            public delegate void glCopyPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum type);
            public delegate void glReadPixels_(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);
            public delegate void glDrawPixels_(GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);
            public delegate void glGetBooleanv(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLboolean[] parameters);
            public delegate void glGetClipPlane(GLenum plane, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] equation);
            public delegate void glGetDoublev(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] parameters);
            public delegate GLenum glGetError();
            public delegate void glGetFloatv(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetIntegerv(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetLightfv(GLenum light, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetLightiv(GLenum light, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetMapdv(GLenum target, GLenum query, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] v);
            public delegate void glGetMapfv(GLenum target, GLenum query, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] v);
            public delegate void glGetMapiv(GLenum target, GLenum query, [MarshalAs(UnmanagedType.LPArray)] GLint[] v);
            public delegate void glGetMaterialfv(GLenum face, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetMaterialiv(GLenum face, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetPixelMapfv(GLenum map, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] values);
            public delegate void glGetPixelMapuiv(GLenum map, [MarshalAs(UnmanagedType.LPArray)] GLuint[] values);
            public delegate void glGetPixelMapusv(GLenum map, [MarshalAs(UnmanagedType.LPArray)] GLushort[] values);
            public delegate void glGetPolygonStipple([MarshalAs(UnmanagedType.LPArray)] GLubyte[] mask);
            public delegate IntPtr glGetString_(GLenum name);
            public delegate void glGetTexEnvfv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetTexEnviv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetTexGendv(GLenum coord, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] parameters);
            public delegate void glGetTexGenfv(GLenum coord, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetTexGeniv(GLenum coord, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetTexImage_(GLenum target, GLint level, GLenum format, GLenum type, IntPtr pixels);
            public delegate void glGetTexParameterfv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetTexParameteriv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetTexLevelParameterfv(GLenum target, GLint level, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetTexLevelParameteriv(GLenum target, GLint level, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate GLboolean glIsEnabled(GLenum cap);
            public delegate GLboolean glIsList(GLuint list);
            public delegate void glDepthRange(GLclampd near, GLclampd far);
            public delegate void glFrustum(GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble zNear, GLdouble zFar);
            public delegate void glLoadIdentity();
            public delegate void glLoadMatrixf_(IntPtr m);
            public delegate void glLoadMatrixd_(IntPtr m);
            public delegate void glMatrixMode(GLenum mode);
            public delegate void glMultMatrixf_(IntPtr m);
            public delegate void glMultMatrixd_(IntPtr m);
            public delegate void glOrtho(GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble zNear, GLdouble zFar);
            public delegate void glPopMatrix();
            public delegate void glPushMatrix();
            public delegate void glRotated(GLdouble angle, GLdouble x, GLdouble y, GLdouble z);
            public delegate void glRotatef(GLfloat angle, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glScaled(GLdouble x, GLdouble y, GLdouble z);
            public delegate void glScalef(GLfloat x, GLfloat y, GLfloat z);
            public delegate void glTranslated(GLdouble x, GLdouble y, GLdouble z);
            public delegate void glTranslatef(GLfloat x, GLfloat y, GLfloat z);
            public delegate void glViewport(GLint x, GLint y, GLsizei width, GLsizei height);
            public delegate void glArrayElement(GLint i);
            public delegate void glColorPointer_(GLint size, GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glDisableClientState(GLenum array);
            public delegate void glDrawArrays(GLenum mode, GLint first, GLsizei count);
            public delegate void glDrawElements_(GLenum mode, GLsizei count, GLenum type, IntPtr indices);
            public delegate void glEdgeFlagPointer_(GLsizei stride, IntPtr pointer);
            public delegate void glEnableClientState(GLenum array);
            public delegate void glGetPointerv(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] parameters);
            public delegate void glIndexPointer_(GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glInterleavedArrays_(GLenum format, GLsizei stride, IntPtr pointer);
            public delegate void glNormalPointer_(GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glTexCoordPointer_(GLint size, GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glVertexPointer_(GLint size, GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glPolygonOffset(GLfloat factor, GLfloat units);
            public delegate void glCopyTexImage1D(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLint border);
            public delegate void glCopyTexImage2D(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border);
            public delegate void glCopyTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);
            public delegate void glCopyTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);
            public delegate void glTexSubImage1D_(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, IntPtr pixels);
            public delegate void glTexSubImage2D_(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);
            public delegate GLboolean glAreTexturesResident_(GLsizei n, IntPtr textures, [MarshalAs(UnmanagedType.LPArray)] GLboolean[] residences);
            public delegate void glBindTexture(GLenum target, GLuint texture);
            public delegate void glDeleteTextures_(GLsizei n, IntPtr textures);
            public delegate void glGenTextures(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] textures);
            public delegate GLboolean glIsTexture(GLuint texture);
            public delegate void glPrioritizeTextures_(GLsizei n, IntPtr textures, IntPtr priorities);
            public delegate void glIndexub(GLubyte c);
            public delegate void glIndexubv_(IntPtr c);
            public delegate void glPopClientAttrib();
            public delegate void glPushClientAttrib(GLbitfield mask);
            public delegate void glBlendColor(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);
            public delegate void glBlendEquation(GLenum mode);
            public delegate void glDrawRangeElements_(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, IntPtr indices);
            public delegate void glColorTable_(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr table);
            public delegate void glColorTableParameterfv_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glColorTableParameteriv_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glCopyColorTable(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);
            public delegate void glGetColorTable_(GLenum target, GLenum format, GLenum type, IntPtr table);
            public delegate void glGetColorTableParameterfv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetColorTableParameteriv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glColorSubTable_(GLenum target, GLsizei start, GLsizei count, GLenum format, GLenum type, IntPtr data);
            public delegate void glCopyColorSubTable(GLenum target, GLsizei start, GLint x, GLint y, GLsizei width);
            public delegate void glConvolutionFilter1D_(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr image);
            public delegate void glConvolutionFilter2D_(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr image);
            public delegate void glConvolutionParameterf(GLenum target, GLenum pname, GLfloat parameters);
            public delegate void glConvolutionParameterfv_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glConvolutionParameteri(GLenum target, GLenum pname, GLint parameters);
            public delegate void glConvolutionParameteriv_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glCopyConvolutionFilter1D(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);
            public delegate void glCopyConvolutionFilter2D(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height);
            public delegate void glGetConvolutionFilter_(GLenum target, GLenum format, GLenum type, IntPtr image);
            public delegate void glGetConvolutionParameterfv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetConvolutionParameteriv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetSeparableFilter_(GLenum target, GLenum format, GLenum type, IntPtr row, IntPtr column, IntPtr span);
            public delegate void glSeparableFilter2D_(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr row, IntPtr column);
            public delegate void glGetHistogram_(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values);
            public delegate void glGetHistogramParameterfv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetHistogramParameteriv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetMinmax_(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values);
            public delegate void glGetMinmaxParameterfv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetMinmaxParameteriv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glHistogram(GLenum target, GLsizei width, GLenum internalformat, GLboolean sink);
            public delegate void glMinmax(GLenum target, GLenum internalformat, GLboolean sink);
            public delegate void glResetHistogram(GLenum target);
            public delegate void glResetMinmax(GLenum target);
            public delegate void glTexImage3D_(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, IntPtr pixels);
            public delegate void glTexSubImage3D_(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr pixels);
            public delegate void glCopyTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);
            public delegate void glActiveTexture(GLenum texture);
            public delegate void glClientActiveTexture(GLenum texture);
            public delegate void glMultiTexCoord1d(GLenum target, GLdouble s);
            public delegate void glMultiTexCoord1dv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord1f(GLenum target, GLfloat s);
            public delegate void glMultiTexCoord1fv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord1i(GLenum target, GLint s);
            public delegate void glMultiTexCoord1iv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord1s(GLenum target, GLshort s);
            public delegate void glMultiTexCoord1sv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord2d(GLenum target, GLdouble s, GLdouble t);
            public delegate void glMultiTexCoord2dv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord2f(GLenum target, GLfloat s, GLfloat t);
            public delegate void glMultiTexCoord2fv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord2i(GLenum target, GLint s, GLint t);
            public delegate void glMultiTexCoord2iv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord2s(GLenum target, GLshort s, GLshort t);
            public delegate void glMultiTexCoord2sv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord3d(GLenum target, GLdouble s, GLdouble t, GLdouble r);
            public delegate void glMultiTexCoord3dv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord3f(GLenum target, GLfloat s, GLfloat t, GLfloat r);
            public delegate void glMultiTexCoord3fv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord3i(GLenum target, GLint s, GLint t, GLint r);
            public delegate void glMultiTexCoord3iv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord3s(GLenum target, GLshort s, GLshort t, GLshort r);
            public delegate void glMultiTexCoord3sv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord4d(GLenum target, GLdouble s, GLdouble t, GLdouble r, GLdouble q);
            public delegate void glMultiTexCoord4dv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord4f(GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q);
            public delegate void glMultiTexCoord4fv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord4i(GLenum target, GLint s, GLint t, GLint r, GLint q);
            public delegate void glMultiTexCoord4iv_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord4s(GLenum target, GLshort s, GLshort t, GLshort r, GLshort q);
            public delegate void glMultiTexCoord4sv_(GLenum target, IntPtr v);
            public delegate void glLoadTransposeMatrixf_(IntPtr m);
            public delegate void glLoadTransposeMatrixd_(IntPtr m);
            public delegate void glMultTransposeMatrixf_(IntPtr m);
            public delegate void glMultTransposeMatrixd_(IntPtr m);
            public delegate void glSampleCoverage(GLclampf value, GLboolean invert);
            public delegate void glCompressedTexImage3D_(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, IntPtr data);
            public delegate void glCompressedTexImage2D_(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, IntPtr data);
            public delegate void glCompressedTexImage1D_(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, IntPtr data);
            public delegate void glCompressedTexSubImage3D_(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, IntPtr data);
            public delegate void glCompressedTexSubImage2D_(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, IntPtr data);
            public delegate void glCompressedTexSubImage1D_(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, IntPtr data);
            public delegate void glGetCompressedTexImage_(GLenum target, GLint level, IntPtr img);
            public delegate void glBlendFuncSeparate(GLenum sfactorRGB, GLenum dfactorRGB, GLenum sfactorAlpha, GLenum dfactorAlpha);
            public delegate void glFogCoordf(GLfloat coord);
            public delegate void glFogCoordfv_(IntPtr coord);
            public delegate void glFogCoordd(GLdouble coord);
            public delegate void glFogCoorddv_(IntPtr coord);
            public delegate void glFogCoordPointer_(GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glMultiDrawArrays(GLenum mode, [MarshalAs(UnmanagedType.LPArray)] GLint[] first, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] count, GLsizei primcount);
            public delegate void glMultiDrawElements_(GLenum mode, IntPtr count, GLenum type, IntPtr indices, GLsizei primcount);
            public delegate void glPointParameterf(GLenum pname, GLfloat param);
            public delegate void glPointParameterfv_(GLenum pname, IntPtr parameters);
            public delegate void glPointParameteri(GLenum pname, GLint param);
            public delegate void glPointParameteriv_(GLenum pname, IntPtr parameters);
            public delegate void glSecondaryColor3b(GLbyte red, GLbyte green, GLbyte blue);
            public delegate void glSecondaryColor3bv_(IntPtr v);
            public delegate void glSecondaryColor3d(GLdouble red, GLdouble green, GLdouble blue);
            public delegate void glSecondaryColor3dv_(IntPtr v);
            public delegate void glSecondaryColor3f(GLfloat red, GLfloat green, GLfloat blue);
            public delegate void glSecondaryColor3fv_(IntPtr v);
            public delegate void glSecondaryColor3i(GLint red, GLint green, GLint blue);
            public delegate void glSecondaryColor3iv_(IntPtr v);
            public delegate void glSecondaryColor3s(GLshort red, GLshort green, GLshort blue);
            public delegate void glSecondaryColor3sv_(IntPtr v);
            public delegate void glSecondaryColor3ub(GLubyte red, GLubyte green, GLubyte blue);
            public delegate void glSecondaryColor3ubv_(IntPtr v);
            public delegate void glSecondaryColor3ui(GLuint red, GLuint green, GLuint blue);
            public delegate void glSecondaryColor3uiv_(IntPtr v);
            public delegate void glSecondaryColor3us(GLushort red, GLushort green, GLushort blue);
            public delegate void glSecondaryColor3usv_(IntPtr v);
            public delegate void glSecondaryColorPointer_(GLint size, GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glWindowPos2d(GLdouble x, GLdouble y);
            public delegate void glWindowPos2dv_(IntPtr v);
            public delegate void glWindowPos2f(GLfloat x, GLfloat y);
            public delegate void glWindowPos2fv_(IntPtr v);
            public delegate void glWindowPos2i(GLint x, GLint y);
            public delegate void glWindowPos2iv_(IntPtr v);
            public delegate void glWindowPos2s(GLshort x, GLshort y);
            public delegate void glWindowPos2sv_(IntPtr v);
            public delegate void glWindowPos3d(GLdouble x, GLdouble y, GLdouble z);
            public delegate void glWindowPos3dv_(IntPtr v);
            public delegate void glWindowPos3f(GLfloat x, GLfloat y, GLfloat z);
            public delegate void glWindowPos3fv_(IntPtr v);
            public delegate void glWindowPos3i(GLint x, GLint y, GLint z);
            public delegate void glWindowPos3iv_(IntPtr v);
            public delegate void glWindowPos3s(GLshort x, GLshort y, GLshort z);
            public delegate void glWindowPos3sv_(IntPtr v);
            public delegate void glGenQueries(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] ids);
            public delegate void glDeleteQueries_(GLsizei n, IntPtr ids);
            public delegate GLboolean glIsQuery(GLuint id);
            public delegate void glBeginQuery(GLenum target, GLuint id);
            public delegate void glEndQuery(GLenum target);
            public delegate void glGetQueryiv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetQueryObjectiv(GLuint id, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetQueryObjectuiv(GLuint id, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLuint[] parameters);
            public delegate void glBindBuffer(GLenum target, GLuint buffer);
            public delegate void glDeleteBuffers_(GLsizei n, IntPtr buffers);
            public delegate void glGenBuffers(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] buffers);
            public delegate GLboolean glIsBuffer(GLuint buffer);
            public delegate void glBufferData_(GLenum target, GLsizeiptr size, IntPtr data, GLenum usage);
            public delegate void glBufferSubData_(GLenum target, GLintptr offset, GLsizeiptr size, IntPtr data);
            public delegate void glGetBufferSubData_(GLenum target, GLintptr offset, GLsizeiptr size, IntPtr data);
            public delegate IntPtr glMapBuffer(GLenum target, GLenum access);
            public delegate GLboolean glUnmapBuffer(GLenum target);
            public delegate void glGetBufferParameteriv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetBufferPointerv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] parameters);
            public delegate void glBlendEquationSeparate(GLenum modeRGB, GLenum modeAlpha);
            public delegate void glDrawBuffers_(GLsizei n, IntPtr bufs);
            public delegate void glStencilOpSeparate(GLenum face, GLenum sfail, GLenum dpfail, GLenum dppass);
            public delegate void glStencilFuncSeparate(GLenum frontfunc, GLenum backfunc, GLint reference, GLuint mask);
            public delegate void glStencilMaskSeparate(GLenum face, GLuint mask);
            public delegate void glAttachShader(GLuint program, GLuint shader);
            public delegate void glBindAttribLocation_(GLuint program, GLuint index, IntPtr name);
            public delegate void glCompileShader(GLuint shader);
            public delegate GLuint glCreateProgram();
            public delegate GLuint glCreateShader(GLenum type);
            public delegate void glDeleteProgram(GLuint program);
            public delegate void glDeleteShader(GLuint shader);
            public delegate void glDetachShader(GLuint program, GLuint shader);
            public delegate void glDisableVertexAttribArray(GLuint index);
            public delegate void glEnableVertexAttribArray(GLuint index);
            public delegate void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLint[] size, [MarshalAs(UnmanagedType.LPArray)] GLenum[] type, [MarshalAs(UnmanagedType.LPArray)] GLchar[] name);
            public delegate void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLint[] size, [MarshalAs(UnmanagedType.LPArray)] GLenum[] type, [MarshalAs(UnmanagedType.LPArray)] GLchar[] name);
            public delegate void glGetAttachedShaders(GLuint program, GLsizei maxCount, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] count, [MarshalAs(UnmanagedType.LPArray)] GLuint[] obj);
            public delegate GLint glGetAttribLocation_(GLuint program, IntPtr name);
            public delegate void glGetProgramiv(GLuint program, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetProgramInfoLog(GLuint program, GLsizei bufSize, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLchar[] infoLog);
            public delegate void glGetShaderiv(GLuint shader, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetShaderInfoLog(GLuint shader, GLsizei bufSize, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLchar[] infoLog);
            public delegate void glGetShaderSource(GLuint shader, GLsizei bufSize, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLchar[] source);
            public delegate GLint glGetUniformLocation_(GLuint program, IntPtr name);
            public delegate void glGetUniformfv(GLuint program, GLint location, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetUniformiv(GLuint program, GLint location, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetVertexAttribdv(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] parameters);
            public delegate void glGetVertexAttribfv(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetVertexAttribiv(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetVertexAttribPointerv(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] pointer);
            public delegate GLboolean glIsProgram(GLuint program);
            public delegate GLboolean glIsShader(GLuint shader);
            public delegate void glLinkProgram(GLuint program);
            public delegate void glShaderSource_(GLuint shader, GLsizei count, string[] @string, IntPtr length);
            public delegate void glUseProgram(GLuint program);
            public delegate void glUniform1f(GLint location, GLfloat v0);
            public delegate void glUniform2f(GLint location, GLfloat v0, GLfloat v1);
            public delegate void glUniform3f(GLint location, GLfloat v0, GLfloat v1, GLfloat v2);
            public delegate void glUniform4f(GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);
            public delegate void glUniform1i(GLint location, GLint v0);
            public delegate void glUniform2i(GLint location, GLint v0, GLint v1);
            public delegate void glUniform3i(GLint location, GLint v0, GLint v1, GLint v2);
            public delegate void glUniform4i(GLint location, GLint v0, GLint v1, GLint v2, GLint v3);
            public delegate void glUniform1fv_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform2fv_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform3fv_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform4fv_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform1iv_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform2iv_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform3iv_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform4iv_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniformMatrix2fv_(GLint location, GLsizei count, GLboolean transpose, IntPtr value);
            public delegate void glUniformMatrix3fv_(GLint location, GLsizei count, GLboolean transpose, IntPtr value);
            public delegate void glUniformMatrix4fv_(GLint location, GLsizei count, GLboolean transpose, IntPtr value);
            public delegate void glValidateProgram(GLuint program);
            public delegate void glVertexAttrib1d(GLuint index, GLdouble x);
            public delegate void glVertexAttrib1dv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib1f(GLuint index, GLfloat x);
            public delegate void glVertexAttrib1fv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib1s(GLuint index, GLshort x);
            public delegate void glVertexAttrib1sv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib2d(GLuint index, GLdouble x, GLdouble y);
            public delegate void glVertexAttrib2dv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib2f(GLuint index, GLfloat x, GLfloat y);
            public delegate void glVertexAttrib2fv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib2s(GLuint index, GLshort x, GLshort y);
            public delegate void glVertexAttrib2sv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib3d(GLuint index, GLdouble x, GLdouble y, GLdouble z);
            public delegate void glVertexAttrib3dv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib3f(GLuint index, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glVertexAttrib3fv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib3s(GLuint index, GLshort x, GLshort y, GLshort z);
            public delegate void glVertexAttrib3sv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4Nbv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4Niv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4Nsv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4Nub(GLuint index, GLubyte x, GLubyte y, GLubyte z, GLubyte w);
            public delegate void glVertexAttrib4Nubv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4Nuiv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4Nusv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4bv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4d(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            public delegate void glVertexAttrib4dv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4f(GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            public delegate void glVertexAttrib4fv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4iv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4s(GLuint index, GLshort x, GLshort y, GLshort z, GLshort w);
            public delegate void glVertexAttrib4sv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4ubv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4uiv_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4usv_(GLuint index, IntPtr v);
            public delegate void glVertexAttribPointer_(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, IntPtr pointer);
            public delegate void glActiveTextureARB(GLenum texture);
            public delegate void glClientActiveTextureARB(GLenum texture);
            public delegate void glMultiTexCoord1dARB(GLenum target, GLdouble s);
            public delegate void glMultiTexCoord1dvARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord1fARB(GLenum target, GLfloat s);
            public delegate void glMultiTexCoord1fvARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord1iARB(GLenum target, GLint s);
            public delegate void glMultiTexCoord1ivARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord1sARB(GLenum target, GLshort s);
            public delegate void glMultiTexCoord1svARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord2dARB(GLenum target, GLdouble s, GLdouble t);
            public delegate void glMultiTexCoord2dvARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord2fARB(GLenum target, GLfloat s, GLfloat t);
            public delegate void glMultiTexCoord2fvARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord2iARB(GLenum target, GLint s, GLint t);
            public delegate void glMultiTexCoord2ivARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord2sARB(GLenum target, GLshort s, GLshort t);
            public delegate void glMultiTexCoord2svARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord3dARB(GLenum target, GLdouble s, GLdouble t, GLdouble r);
            public delegate void glMultiTexCoord3dvARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord3fARB(GLenum target, GLfloat s, GLfloat t, GLfloat r);
            public delegate void glMultiTexCoord3fvARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord3iARB(GLenum target, GLint s, GLint t, GLint r);
            public delegate void glMultiTexCoord3ivARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord3sARB(GLenum target, GLshort s, GLshort t, GLshort r);
            public delegate void glMultiTexCoord3svARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord4dARB(GLenum target, GLdouble s, GLdouble t, GLdouble r, GLdouble q);
            public delegate void glMultiTexCoord4dvARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord4fARB(GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q);
            public delegate void glMultiTexCoord4fvARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord4iARB(GLenum target, GLint s, GLint t, GLint r, GLint q);
            public delegate void glMultiTexCoord4ivARB_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord4sARB(GLenum target, GLshort s, GLshort t, GLshort r, GLshort q);
            public delegate void glMultiTexCoord4svARB_(GLenum target, IntPtr v);
            public delegate void glLoadTransposeMatrixfARB_(IntPtr m);
            public delegate void glLoadTransposeMatrixdARB_(IntPtr m);
            public delegate void glMultTransposeMatrixfARB_(IntPtr m);
            public delegate void glMultTransposeMatrixdARB_(IntPtr m);
            public delegate void glSampleCoverageARB(GLclampf value, GLboolean invert);
            public delegate void glCompressedTexImage3DARB_(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, IntPtr data);
            public delegate void glCompressedTexImage2DARB_(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, IntPtr data);
            public delegate void glCompressedTexImage1DARB_(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, IntPtr data);
            public delegate void glCompressedTexSubImage3DARB_(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, IntPtr data);
            public delegate void glCompressedTexSubImage2DARB_(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, IntPtr data);
            public delegate void glCompressedTexSubImage1DARB_(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, IntPtr data);
            public delegate void glGetCompressedTexImageARB_(GLenum target, GLint level, IntPtr img);
            public delegate void glPointParameterfARB(GLenum pname, GLfloat param);
            public delegate void glPointParameterfvARB_(GLenum pname, IntPtr parameters);
            public delegate void glWeightbvARB_(GLint size, IntPtr weights);
            public delegate void glWeightsvARB_(GLint size, IntPtr weights);
            public delegate void glWeightivARB_(GLint size, IntPtr weights);
            public delegate void glWeightfvARB_(GLint size, IntPtr weights);
            public delegate void glWeightdvARB_(GLint size, IntPtr weights);
            public delegate void glWeightubvARB_(GLint size, IntPtr weights);
            public delegate void glWeightusvARB_(GLint size, IntPtr weights);
            public delegate void glWeightuivARB_(GLint size, IntPtr weights);
            public delegate void glWeightPointerARB_(GLint size, GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glVertexBlendARB(GLint count);
            public delegate void glCurrentPaletteMatrixARB(GLint index);
            public delegate void glMatrixIndexubvARB_(GLint size, IntPtr indices);
            public delegate void glMatrixIndexusvARB_(GLint size, IntPtr indices);
            public delegate void glMatrixIndexuivARB_(GLint size, IntPtr indices);
            public delegate void glMatrixIndexPointerARB_(GLint size, GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glWindowPos2dARB(GLdouble x, GLdouble y);
            public delegate void glWindowPos2dvARB_(IntPtr v);
            public delegate void glWindowPos2fARB(GLfloat x, GLfloat y);
            public delegate void glWindowPos2fvARB_(IntPtr v);
            public delegate void glWindowPos2iARB(GLint x, GLint y);
            public delegate void glWindowPos2ivARB_(IntPtr v);
            public delegate void glWindowPos2sARB(GLshort x, GLshort y);
            public delegate void glWindowPos2svARB_(IntPtr v);
            public delegate void glWindowPos3dARB(GLdouble x, GLdouble y, GLdouble z);
            public delegate void glWindowPos3dvARB_(IntPtr v);
            public delegate void glWindowPos3fARB(GLfloat x, GLfloat y, GLfloat z);
            public delegate void glWindowPos3fvARB_(IntPtr v);
            public delegate void glWindowPos3iARB(GLint x, GLint y, GLint z);
            public delegate void glWindowPos3ivARB_(IntPtr v);
            public delegate void glWindowPos3sARB(GLshort x, GLshort y, GLshort z);
            public delegate void glWindowPos3svARB_(IntPtr v);
            public delegate void glVertexAttrib1dARB(GLuint index, GLdouble x);
            public delegate void glVertexAttrib1dvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib1fARB(GLuint index, GLfloat x);
            public delegate void glVertexAttrib1fvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib1sARB(GLuint index, GLshort x);
            public delegate void glVertexAttrib1svARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib2dARB(GLuint index, GLdouble x, GLdouble y);
            public delegate void glVertexAttrib2dvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib2fARB(GLuint index, GLfloat x, GLfloat y);
            public delegate void glVertexAttrib2fvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib2sARB(GLuint index, GLshort x, GLshort y);
            public delegate void glVertexAttrib2svARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib3dARB(GLuint index, GLdouble x, GLdouble y, GLdouble z);
            public delegate void glVertexAttrib3dvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib3fARB(GLuint index, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glVertexAttrib3fvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib3sARB(GLuint index, GLshort x, GLshort y, GLshort z);
            public delegate void glVertexAttrib3svARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4NbvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4NivARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4NsvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4NubARB(GLuint index, GLubyte x, GLubyte y, GLubyte z, GLubyte w);
            public delegate void glVertexAttrib4NubvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4NuivARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4NusvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4bvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4dARB(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            public delegate void glVertexAttrib4dvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4fARB(GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            public delegate void glVertexAttrib4fvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4ivARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4sARB(GLuint index, GLshort x, GLshort y, GLshort z, GLshort w);
            public delegate void glVertexAttrib4svARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4ubvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4uivARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4usvARB_(GLuint index, IntPtr v);
            public delegate void glVertexAttribPointerARB_(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, IntPtr pointer);
            public delegate void glEnableVertexAttribArrayARB(GLuint index);
            public delegate void glDisableVertexAttribArrayARB(GLuint index);
            public delegate void glProgramStringARB_(GLenum target, GLenum format, GLsizei len, IntPtr @string);
            public delegate void glBindProgramARB(GLenum target, GLuint program);
            public delegate void glDeleteProgramsARB_(GLsizei n, IntPtr programs);
            public delegate void glGenProgramsARB(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] programs);
            public delegate void glProgramEnvParameter4dARB(GLenum target, GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            public delegate void glProgramEnvParameter4dvARB_(GLenum target, GLuint index, IntPtr parameters);
            public delegate void glProgramEnvParameter4fARB(GLenum target, GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            public delegate void glProgramEnvParameter4fvARB_(GLenum target, GLuint index, IntPtr parameters);
            public delegate void glProgramLocalParameter4dARB(GLenum target, GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            public delegate void glProgramLocalParameter4dvARB_(GLenum target, GLuint index, IntPtr parameters);
            public delegate void glProgramLocalParameter4fARB(GLenum target, GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            public delegate void glProgramLocalParameter4fvARB_(GLenum target, GLuint index, IntPtr parameters);
            public delegate void glGetProgramEnvParameterdvARB(GLenum target, GLuint index, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] parameters);
            public delegate void glGetProgramEnvParameterfvARB(GLenum target, GLuint index, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetProgramLocalParameterdvARB(GLenum target, GLuint index, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] parameters);
            public delegate void glGetProgramLocalParameterfvARB(GLenum target, GLuint index, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetProgramivARB(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetProgramStringARB_(GLenum target, GLenum pname, IntPtr @string);
            public delegate void glGetVertexAttribdvARB(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] parameters);
            public delegate void glGetVertexAttribfvARB(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetVertexAttribivARB(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetVertexAttribPointervARB(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] pointer);
            public delegate GLboolean glIsProgramARB(GLuint program);
            public delegate void glBindBufferARB(GLenum target, GLuint buffer);
            public delegate void glDeleteBuffersARB_(GLsizei n, IntPtr buffers);
            public delegate void glGenBuffersARB(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] buffers);
            public delegate GLboolean glIsBufferARB(GLuint buffer);
            public delegate void glBufferDataARB_(GLenum target, GLsizeiptrARB size, IntPtr data, GLenum usage);
            public delegate void glBufferSubDataARB_(GLenum target, GLintptrARB offset, GLsizeiptrARB size, IntPtr data);
            public delegate void glGetBufferSubDataARB_(GLenum target, GLintptrARB offset, GLsizeiptrARB size, IntPtr data);
            public delegate IntPtr glMapBufferARB(GLenum target, GLenum access);
            public delegate GLboolean glUnmapBufferARB(GLenum target);
            public delegate void glGetBufferParameterivARB(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetBufferPointervARB(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] parameters);
            public delegate void glGenQueriesARB(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] ids);
            public delegate void glDeleteQueriesARB_(GLsizei n, IntPtr ids);
            public delegate GLboolean glIsQueryARB(GLuint id);
            public delegate void glBeginQueryARB(GLenum target, GLuint id);
            public delegate void glEndQueryARB(GLenum target);
            public delegate void glGetQueryivARB(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetQueryObjectivARB(GLuint id, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetQueryObjectuivARB(GLuint id, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLuint[] parameters);
            public delegate void glDeleteObjectARB(GLhandleARB obj);
            public delegate GLhandleARB glGetHandleARB(GLenum pname);
            public delegate void glDetachObjectARB(GLhandleARB containerObj, GLhandleARB attachedObj);
            public delegate GLhandleARB glCreateShaderObjectARB(GLenum shaderType);
            public delegate void glShaderSourceARB_(GLhandleARB shaderObj, GLsizei count, IntPtr @string, IntPtr length);
            public delegate void glCompileShaderARB(GLhandleARB shaderObj);
            public delegate GLhandleARB glCreateProgramObjectARB();
            public delegate void glAttachObjectARB(GLhandleARB containerObj, GLhandleARB obj);
            public delegate void glLinkProgramARB(GLhandleARB programObj);
            public delegate void glUseProgramObjectARB(GLhandleARB programObj);
            public delegate void glValidateProgramARB(GLhandleARB programObj);
            public delegate void glUniform1fARB(GLint location, GLfloat v0);
            public delegate void glUniform2fARB(GLint location, GLfloat v0, GLfloat v1);
            public delegate void glUniform3fARB(GLint location, GLfloat v0, GLfloat v1, GLfloat v2);
            public delegate void glUniform4fARB(GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);
            public delegate void glUniform1iARB(GLint location, GLint v0);
            public delegate void glUniform2iARB(GLint location, GLint v0, GLint v1);
            public delegate void glUniform3iARB(GLint location, GLint v0, GLint v1, GLint v2);
            public delegate void glUniform4iARB(GLint location, GLint v0, GLint v1, GLint v2, GLint v3);
            public delegate void glUniform1fvARB_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform2fvARB_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform3fvARB_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform4fvARB_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform1ivARB_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform2ivARB_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform3ivARB_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniform4ivARB_(GLint location, GLsizei count, IntPtr value);
            public delegate void glUniformMatrix2fvARB_(GLint location, GLsizei count, GLboolean transpose, IntPtr value);
            public delegate void glUniformMatrix3fvARB_(GLint location, GLsizei count, GLboolean transpose, IntPtr value);
            public delegate void glUniformMatrix4fvARB_(GLint location, GLsizei count, GLboolean transpose, IntPtr value);
            public delegate void glGetObjectParameterfvARB(GLhandleARB obj, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetObjectParameterivARB(GLhandleARB obj, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetInfoLogARB(GLhandleARB obj, GLsizei maxLength, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLcharARB[] infoLog);
            public delegate void glGetAttachedObjectsARB(GLhandleARB containerObj, GLsizei maxCount, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] count, [MarshalAs(UnmanagedType.LPArray)] GLhandleARB[] obj);
            public delegate GLint glGetUniformLocationARB_(GLhandleARB programObj, IntPtr name);
            public delegate void glGetActiveUniformARB(GLhandleARB programObj, GLuint index, GLsizei maxLength, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLint[] size, [MarshalAs(UnmanagedType.LPArray)] GLenum[] type, [MarshalAs(UnmanagedType.LPArray)] GLcharARB[] name);
            public delegate void glGetUniformfvARB(GLhandleARB programObj, GLint location, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetUniformivARB(GLhandleARB programObj, GLint location, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetShaderSourceARB(GLhandleARB obj, GLsizei maxLength, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLcharARB[] source);
            public delegate void glBindAttribLocationARB_(GLhandleARB programObj, GLuint index, IntPtr name);
            public delegate void glGetActiveAttribARB(GLhandleARB programObj, GLuint index, GLsizei maxLength, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLint[] size, [MarshalAs(UnmanagedType.LPArray)] GLenum[] type, [MarshalAs(UnmanagedType.LPArray)] GLcharARB[] name);
            public delegate GLint glGetAttribLocationARB_(GLhandleARB programObj, IntPtr name);
            public delegate void glDrawBuffersARB_(GLsizei n, IntPtr bufs);
            public delegate void glClampColorARB(GLenum target, GLenum clamp);
            public delegate void glBlendColorEXT(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);
            public delegate void glPolygonOffsetEXT(GLfloat factor, GLfloat bias);
            public delegate void glTexImage3DEXT_(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, IntPtr pixels);
            public delegate void glTexSubImage3DEXT_(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr pixels);
            public delegate void glGetTexFilterFuncSGIS(GLenum target, GLenum filter, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] weights);
            public delegate void glTexFilterFuncSGIS_(GLenum target, GLenum filter, GLsizei n, IntPtr weights);
            public delegate void glTexSubImage1DEXT_(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, IntPtr pixels);
            public delegate void glTexSubImage2DEXT_(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);
            public delegate void glCopyTexImage1DEXT(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLint border);
            public delegate void glCopyTexImage2DEXT(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border);
            public delegate void glCopyTexSubImage1DEXT(GLenum target, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);
            public delegate void glCopyTexSubImage2DEXT(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);
            public delegate void glCopyTexSubImage3DEXT(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);
            public delegate void glGetHistogramEXT_(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values);
            public delegate void glGetHistogramParameterfvEXT(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetHistogramParameterivEXT(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetMinmaxEXT_(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values);
            public delegate void glGetMinmaxParameterfvEXT(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetMinmaxParameterivEXT(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glHistogramEXT(GLenum target, GLsizei width, GLenum internalformat, GLboolean sink);
            public delegate void glMinmaxEXT(GLenum target, GLenum internalformat, GLboolean sink);
            public delegate void glResetHistogramEXT(GLenum target);
            public delegate void glResetMinmaxEXT(GLenum target);
            public delegate void glConvolutionFilter1DEXT_(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr image);
            public delegate void glConvolutionFilter2DEXT_(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr image);
            public delegate void glConvolutionParameterfEXT(GLenum target, GLenum pname, GLfloat parameters);
            public delegate void glConvolutionParameterfvEXT_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glConvolutionParameteriEXT(GLenum target, GLenum pname, GLint parameters);
            public delegate void glConvolutionParameterivEXT_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glCopyConvolutionFilter1DEXT(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);
            public delegate void glCopyConvolutionFilter2DEXT(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height);
            public delegate void glGetConvolutionFilterEXT_(GLenum target, GLenum format, GLenum type, IntPtr image);
            public delegate void glGetConvolutionParameterfvEXT(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetConvolutionParameterivEXT(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetSeparableFilterEXT_(GLenum target, GLenum format, GLenum type, IntPtr row, IntPtr column, IntPtr span);
            public delegate void glSeparableFilter2DEXT_(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr row, IntPtr column);
            public delegate void glColorTableSGI_(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr table);
            public delegate void glColorTableParameterfvSGI_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glColorTableParameterivSGI_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glCopyColorTableSGI(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);
            public delegate void glGetColorTableSGI_(GLenum target, GLenum format, GLenum type, IntPtr table);
            public delegate void glGetColorTableParameterfvSGI(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetColorTableParameterivSGI(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glPixelTexGenSGIX(GLenum mode);
            public delegate void glPixelTexGenParameteriSGIS(GLenum pname, GLint param);
            public delegate void glPixelTexGenParameterivSGIS_(GLenum pname, IntPtr parameters);
            public delegate void glPixelTexGenParameterfSGIS(GLenum pname, GLfloat param);
            public delegate void glPixelTexGenParameterfvSGIS_(GLenum pname, IntPtr parameters);
            public delegate void glGetPixelTexGenParameterivSGIS(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetPixelTexGenParameterfvSGIS(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glTexImage4DSGIS_(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLsizei size4d, GLint border, GLenum format, GLenum type, IntPtr pixels);
            public delegate void glTexSubImage4DSGIS_(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint woffset, GLsizei width, GLsizei height, GLsizei depth, GLsizei size4d, GLenum format, GLenum type, IntPtr pixels);
            public delegate GLboolean glAreTexturesResidentEXT_(GLsizei n, IntPtr textures, [MarshalAs(UnmanagedType.LPArray)] GLboolean[] residences);
            public delegate void glBindTextureEXT(GLenum target, GLuint texture);
            public delegate void glDeleteTexturesEXT_(GLsizei n, IntPtr textures);
            public delegate void glGenTexturesEXT(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] textures);
            public delegate GLboolean glIsTextureEXT(GLuint texture);
            public delegate void glPrioritizeTexturesEXT_(GLsizei n, IntPtr textures, IntPtr priorities);
            public delegate void glDetailTexFuncSGIS_(GLenum target, GLsizei n, IntPtr points);
            public delegate void glGetDetailTexFuncSGIS(GLenum target, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] points);
            public delegate void glSharpenTexFuncSGIS_(GLenum target, GLsizei n, IntPtr points);
            public delegate void glGetSharpenTexFuncSGIS(GLenum target, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] points);
            public delegate void glSampleMaskSGIS(GLclampf value, GLboolean invert);
            public delegate void glSamplePatternSGIS(GLenum pattern);
            public delegate void glArrayElementEXT(GLint i);
            public delegate void glColorPointerEXT_(GLint size, GLenum type, GLsizei stride, GLsizei count, IntPtr pointer);
            public delegate void glDrawArraysEXT(GLenum mode, GLint first, GLsizei count);
            public delegate void glEdgeFlagPointerEXT_(GLsizei stride, GLsizei count, IntPtr pointer);
            public delegate void glGetPointervEXT(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] parameters);
            public delegate void glIndexPointerEXT_(GLenum type, GLsizei stride, GLsizei count, IntPtr pointer);
            public delegate void glNormalPointerEXT_(GLenum type, GLsizei stride, GLsizei count, IntPtr pointer);
            public delegate void glTexCoordPointerEXT_(GLint size, GLenum type, GLsizei stride, GLsizei count, IntPtr pointer);
            public delegate void glVertexPointerEXT_(GLint size, GLenum type, GLsizei stride, GLsizei count, IntPtr pointer);
            public delegate void glBlendEquationEXT(GLenum mode);
            public delegate void glSpriteParameterfSGIX(GLenum pname, GLfloat param);
            public delegate void glSpriteParameterfvSGIX_(GLenum pname, IntPtr parameters);
            public delegate void glSpriteParameteriSGIX(GLenum pname, GLint param);
            public delegate void glSpriteParameterivSGIX_(GLenum pname, IntPtr parameters);
            public delegate void glPointParameterfEXT(GLenum pname, GLfloat param);
            public delegate void glPointParameterfvEXT_(GLenum pname, IntPtr parameters);
            public delegate void glPointParameterfSGIS(GLenum pname, GLfloat param);
            public delegate void glPointParameterfvSGIS_(GLenum pname, IntPtr parameters);
            public delegate GLint glGetInstrumentsSGIX();
            public delegate void glInstrumentsBufferSGIX(GLsizei size, [MarshalAs(UnmanagedType.LPArray)] GLint[] buffer);
            public delegate GLint glPollInstrumentsSGIX([MarshalAs(UnmanagedType.LPArray)] GLint[] marker_p);
            public delegate void glReadInstrumentsSGIX(GLint marker);
            public delegate void glStartInstrumentsSGIX();
            public delegate void glStopInstrumentsSGIX(GLint marker);
            public delegate void glFrameZoomSGIX(GLint factor);
            public delegate void glTagSampleBufferSGIX();
            public delegate void glDeformationMap3dSGIX_(GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, GLdouble w1, GLdouble w2, GLint wstride, GLint worder, IntPtr points);
            public delegate void glDeformationMap3fSGIX_(GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, GLfloat w1, GLfloat w2, GLint wstride, GLint worder, IntPtr points);
            public delegate void glDeformSGIX(GLbitfield mask);
            public delegate void glLoadIdentityDeformationMapSGIX(GLbitfield mask);
            public delegate void glReferencePlaneSGIX_(IntPtr equation);
            public delegate void glFlushRasterSGIX();
            public delegate void glFogFuncSGIS_(GLsizei n, IntPtr points);
            public delegate void glGetFogFuncSGIS([MarshalAs(UnmanagedType.LPArray)] GLfloat[] points);
            public delegate void glImageTransformParameteriHP(GLenum target, GLenum pname, GLint param);
            public delegate void glImageTransformParameterfHP(GLenum target, GLenum pname, GLfloat param);
            public delegate void glImageTransformParameterivHP_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glImageTransformParameterfvHP_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glGetImageTransformParameterivHP(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetImageTransformParameterfvHP(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glColorSubTableEXT_(GLenum target, GLsizei start, GLsizei count, GLenum format, GLenum type, IntPtr data);
            public delegate void glCopyColorSubTableEXT(GLenum target, GLsizei start, GLint x, GLint y, GLsizei width);
            public delegate void glHintPGI(GLenum target, GLint mode);
            public delegate void glColorTableEXT_(GLenum target, GLenum internalFormat, GLsizei width, GLenum format, GLenum type, IntPtr table);
            public delegate void glGetColorTableEXT_(GLenum target, GLenum format, GLenum type, IntPtr data);
            public delegate void glGetColorTableParameterivEXT(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetColorTableParameterfvEXT(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetListParameterfvSGIX(GLuint list, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetListParameterivSGIX(GLuint list, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glListParameterfSGIX(GLuint list, GLenum pname, GLfloat param);
            public delegate void glListParameterfvSGIX_(GLuint list, GLenum pname, IntPtr parameters);
            public delegate void glListParameteriSGIX(GLuint list, GLenum pname, GLint param);
            public delegate void glListParameterivSGIX_(GLuint list, GLenum pname, IntPtr parameters);
            public delegate void glIndexMaterialEXT(GLenum face, GLenum mode);
            public delegate void glIndexFuncEXT(GLenum func, GLclampf reference);
            public delegate void glLockArraysEXT(GLint first, GLsizei count);
            public delegate void glUnlockArraysEXT();
            public delegate void glCullParameterdvEXT(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] parameters);
            public delegate void glCullParameterfvEXT(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glFragmentColorMaterialSGIX(GLenum face, GLenum mode);
            public delegate void glFragmentLightfSGIX(GLenum light, GLenum pname, GLfloat param);
            public delegate void glFragmentLightfvSGIX_(GLenum light, GLenum pname, IntPtr parameters);
            public delegate void glFragmentLightiSGIX(GLenum light, GLenum pname, GLint param);
            public delegate void glFragmentLightivSGIX_(GLenum light, GLenum pname, IntPtr parameters);
            public delegate void glFragmentLightModelfSGIX(GLenum pname, GLfloat param);
            public delegate void glFragmentLightModelfvSGIX_(GLenum pname, IntPtr parameters);
            public delegate void glFragmentLightModeliSGIX(GLenum pname, GLint param);
            public delegate void glFragmentLightModelivSGIX_(GLenum pname, IntPtr parameters);
            public delegate void glFragmentMaterialfSGIX(GLenum face, GLenum pname, GLfloat param);
            public delegate void glFragmentMaterialfvSGIX_(GLenum face, GLenum pname, IntPtr parameters);
            public delegate void glFragmentMaterialiSGIX(GLenum face, GLenum pname, GLint param);
            public delegate void glFragmentMaterialivSGIX_(GLenum face, GLenum pname, IntPtr parameters);
            public delegate void glGetFragmentLightfvSGIX(GLenum light, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetFragmentLightivSGIX(GLenum light, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetFragmentMaterialfvSGIX(GLenum face, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetFragmentMaterialivSGIX(GLenum face, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glLightEnviSGIX(GLenum pname, GLint param);
            public delegate void glDrawRangeElementsEXT_(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, IntPtr indices);
            public delegate void glApplyTextureEXT(GLenum mode);
            public delegate void glTextureLightEXT(GLenum pname);
            public delegate void glTextureMaterialEXT(GLenum face, GLenum mode);
            public delegate void glAsyncMarkerSGIX(GLuint marker);
            public delegate GLint glFinishAsyncSGIX([MarshalAs(UnmanagedType.LPArray)] GLuint[] markerp);
            public delegate GLint glPollAsyncSGIX([MarshalAs(UnmanagedType.LPArray)] GLuint[] markerp);
            public delegate GLuint glGenAsyncMarkersSGIX(GLsizei range);
            public delegate void glDeleteAsyncMarkersSGIX(GLuint marker, GLsizei range);
            public delegate GLboolean glIsAsyncMarkerSGIX(GLuint marker);
            public delegate void glVertexPointervINTEL_(GLint size, GLenum type, IntPtr pointer);
            public delegate void glNormalPointervINTEL_(GLenum type, IntPtr pointer);
            public delegate void glColorPointervINTEL_(GLint size, GLenum type, IntPtr pointer);
            public delegate void glTexCoordPointervINTEL_(GLint size, GLenum type, IntPtr pointer);
            public delegate void glPixelTransformParameteriEXT(GLenum target, GLenum pname, GLint param);
            public delegate void glPixelTransformParameterfEXT(GLenum target, GLenum pname, GLfloat param);
            public delegate void glPixelTransformParameterivEXT_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glPixelTransformParameterfvEXT_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glSecondaryColor3bEXT(GLbyte red, GLbyte green, GLbyte blue);
            public delegate void glSecondaryColor3bvEXT_(IntPtr v);
            public delegate void glSecondaryColor3dEXT(GLdouble red, GLdouble green, GLdouble blue);
            public delegate void glSecondaryColor3dvEXT_(IntPtr v);
            public delegate void glSecondaryColor3fEXT(GLfloat red, GLfloat green, GLfloat blue);
            public delegate void glSecondaryColor3fvEXT_(IntPtr v);
            public delegate void glSecondaryColor3iEXT(GLint red, GLint green, GLint blue);
            public delegate void glSecondaryColor3ivEXT_(IntPtr v);
            public delegate void glSecondaryColor3sEXT(GLshort red, GLshort green, GLshort blue);
            public delegate void glSecondaryColor3svEXT_(IntPtr v);
            public delegate void glSecondaryColor3ubEXT(GLubyte red, GLubyte green, GLubyte blue);
            public delegate void glSecondaryColor3ubvEXT_(IntPtr v);
            public delegate void glSecondaryColor3uiEXT(GLuint red, GLuint green, GLuint blue);
            public delegate void glSecondaryColor3uivEXT_(IntPtr v);
            public delegate void glSecondaryColor3usEXT(GLushort red, GLushort green, GLushort blue);
            public delegate void glSecondaryColor3usvEXT_(IntPtr v);
            public delegate void glSecondaryColorPointerEXT_(GLint size, GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glTextureNormalEXT(GLenum mode);
            public delegate void glMultiDrawArraysEXT(GLenum mode, [MarshalAs(UnmanagedType.LPArray)] GLint[] first, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] count, GLsizei primcount);
            public delegate void glMultiDrawElementsEXT_(GLenum mode, IntPtr count, GLenum type, IntPtr indices, GLsizei primcount);
            public delegate void glFogCoordfEXT(GLfloat coord);
            public delegate void glFogCoordfvEXT_(IntPtr coord);
            public delegate void glFogCoorddEXT(GLdouble coord);
            public delegate void glFogCoorddvEXT_(IntPtr coord);
            public delegate void glFogCoordPointerEXT_(GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glTangent3bEXT(GLbyte tx, GLbyte ty, GLbyte tz);
            public delegate void glTangent3bvEXT_(IntPtr v);
            public delegate void glTangent3dEXT(GLdouble tx, GLdouble ty, GLdouble tz);
            public delegate void glTangent3dvEXT_(IntPtr v);
            public delegate void glTangent3fEXT(GLfloat tx, GLfloat ty, GLfloat tz);
            public delegate void glTangent3fvEXT_(IntPtr v);
            public delegate void glTangent3iEXT(GLint tx, GLint ty, GLint tz);
            public delegate void glTangent3ivEXT_(IntPtr v);
            public delegate void glTangent3sEXT(GLshort tx, GLshort ty, GLshort tz);
            public delegate void glTangent3svEXT_(IntPtr v);
            public delegate void glBinormal3bEXT(GLbyte bx, GLbyte by, GLbyte bz);
            public delegate void glBinormal3bvEXT_(IntPtr v);
            public delegate void glBinormal3dEXT(GLdouble bx, GLdouble by, GLdouble bz);
            public delegate void glBinormal3dvEXT_(IntPtr v);
            public delegate void glBinormal3fEXT(GLfloat bx, GLfloat by, GLfloat bz);
            public delegate void glBinormal3fvEXT_(IntPtr v);
            public delegate void glBinormal3iEXT(GLint bx, GLint by, GLint bz);
            public delegate void glBinormal3ivEXT_(IntPtr v);
            public delegate void glBinormal3sEXT(GLshort bx, GLshort by, GLshort bz);
            public delegate void glBinormal3svEXT_(IntPtr v);
            public delegate void glTangentPointerEXT_(GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glBinormalPointerEXT_(GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glFinishTextureSUNX();
            public delegate void glGlobalAlphaFactorbSUN(GLbyte factor);
            public delegate void glGlobalAlphaFactorsSUN(GLshort factor);
            public delegate void glGlobalAlphaFactoriSUN(GLint factor);
            public delegate void glGlobalAlphaFactorfSUN(GLfloat factor);
            public delegate void glGlobalAlphaFactordSUN(GLdouble factor);
            public delegate void glGlobalAlphaFactorubSUN(GLubyte factor);
            public delegate void glGlobalAlphaFactorusSUN(GLushort factor);
            public delegate void glGlobalAlphaFactoruiSUN(GLuint factor);
            public delegate void glReplacementCodeuiSUN(GLuint code);
            public delegate void glReplacementCodeusSUN(GLushort code);
            public delegate void glReplacementCodeubSUN(GLubyte code);
            public delegate void glReplacementCodeuivSUN_(IntPtr code);
            public delegate void glReplacementCodeusvSUN_(IntPtr code);
            public delegate void glReplacementCodeubvSUN_(IntPtr code);
            public delegate void glReplacementCodePointerSUN_(GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glColor4ubVertex2fSUN(GLubyte r, GLubyte g, GLubyte b, GLubyte a, GLfloat x, GLfloat y);
            public delegate void glColor4ubVertex2fvSUN_(IntPtr c, IntPtr v);
            public delegate void glColor4ubVertex3fSUN(GLubyte r, GLubyte g, GLubyte b, GLubyte a, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glColor4ubVertex3fvSUN_(IntPtr c, IntPtr v);
            public delegate void glColor3fVertex3fSUN(GLfloat r, GLfloat g, GLfloat b, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glColor3fVertex3fvSUN_(IntPtr c, IntPtr v);
            public delegate void glNormal3fVertex3fSUN(GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glNormal3fVertex3fvSUN_(IntPtr n, IntPtr v);
            public delegate void glColor4fNormal3fVertex3fSUN(GLfloat r, GLfloat g, GLfloat b, GLfloat a, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glColor4fNormal3fVertex3fvSUN_(IntPtr c, IntPtr n, IntPtr v);
            public delegate void glTexCoord2fVertex3fSUN(GLfloat s, GLfloat t, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glTexCoord2fVertex3fvSUN_(IntPtr tc, IntPtr v);
            public delegate void glTexCoord4fVertex4fSUN(GLfloat s, GLfloat t, GLfloat p, GLfloat q, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            public delegate void glTexCoord4fVertex4fvSUN_(IntPtr tc, IntPtr v);
            public delegate void glTexCoord2fColor4ubVertex3fSUN(GLfloat s, GLfloat t, GLubyte r, GLubyte g, GLubyte b, GLubyte a, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glTexCoord2fColor4ubVertex3fvSUN_(IntPtr tc, IntPtr c, IntPtr v);
            public delegate void glTexCoord2fColor3fVertex3fSUN(GLfloat s, GLfloat t, GLfloat r, GLfloat g, GLfloat b, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glTexCoord2fColor3fVertex3fvSUN_(IntPtr tc, IntPtr c, IntPtr v);
            public delegate void glTexCoord2fNormal3fVertex3fSUN(GLfloat s, GLfloat t, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glTexCoord2fNormal3fVertex3fvSUN_(IntPtr tc, IntPtr n, IntPtr v);
            public delegate void glTexCoord2fColor4fNormal3fVertex3fSUN(GLfloat s, GLfloat t, GLfloat r, GLfloat g, GLfloat b, GLfloat a, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glTexCoord2fColor4fNormal3fVertex3fvSUN_(IntPtr tc, IntPtr c, IntPtr n, IntPtr v);
            public delegate void glTexCoord4fColor4fNormal3fVertex4fSUN(GLfloat s, GLfloat t, GLfloat p, GLfloat q, GLfloat r, GLfloat g, GLfloat b, GLfloat a, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            public delegate void glTexCoord4fColor4fNormal3fVertex4fvSUN_(IntPtr tc, IntPtr c, IntPtr n, IntPtr v);
            public delegate void glReplacementCodeuiVertex3fSUN(GLuint rc, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glReplacementCodeuiVertex3fvSUN_(IntPtr rc, IntPtr v);
            public delegate void glReplacementCodeuiColor4ubVertex3fSUN(GLuint rc, GLubyte r, GLubyte g, GLubyte b, GLubyte a, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glReplacementCodeuiColor4ubVertex3fvSUN_(IntPtr rc, IntPtr c, IntPtr v);
            public delegate void glReplacementCodeuiColor3fVertex3fSUN(GLuint rc, GLfloat r, GLfloat g, GLfloat b, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glReplacementCodeuiColor3fVertex3fvSUN_(IntPtr rc, IntPtr c, IntPtr v);
            public delegate void glReplacementCodeuiNormal3fVertex3fSUN(GLuint rc, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glReplacementCodeuiNormal3fVertex3fvSUN_(IntPtr rc, IntPtr n, IntPtr v);
            public delegate void glReplacementCodeuiColor4fNormal3fVertex3fSUN(GLuint rc, GLfloat r, GLfloat g, GLfloat b, GLfloat a, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glReplacementCodeuiColor4fNormal3fVertex3fvSUN_(IntPtr rc, IntPtr c, IntPtr n, IntPtr v);
            public delegate void glReplacementCodeuiTexCoord2fVertex3fSUN(GLuint rc, GLfloat s, GLfloat t, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glReplacementCodeuiTexCoord2fVertex3fvSUN_(IntPtr rc, IntPtr tc, IntPtr v);
            public delegate void glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN(GLuint rc, GLfloat s, GLfloat t, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN_(IntPtr rc, IntPtr tc, IntPtr n, IntPtr v);
            public delegate void glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN(GLuint rc, GLfloat s, GLfloat t, GLfloat r, GLfloat g, GLfloat b, GLfloat a, GLfloat nx, GLfloat ny, GLfloat nz, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN_(IntPtr rc, IntPtr tc, IntPtr c, IntPtr n, IntPtr v);
            public delegate void glBlendFuncSeparateEXT(GLenum sfactorRGB, GLenum dfactorRGB, GLenum sfactorAlpha, GLenum dfactorAlpha);
            public delegate void glBlendFuncSeparateINGR(GLenum sfactorRGB, GLenum dfactorRGB, GLenum sfactorAlpha, GLenum dfactorAlpha);
            public delegate void glVertexWeightfEXT(GLfloat weight);
            public delegate void glVertexWeightfvEXT_(IntPtr weight);
            public delegate void glVertexWeightPointerEXT_(GLsizei size, GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glFlushVertexArrayRangeNV();
            public delegate void glVertexArrayRangeNV_(GLsizei length, IntPtr pointer);
            public delegate void glCombinerParameterfvNV_(GLenum pname, IntPtr parameters);
            public delegate void glCombinerParameterfNV(GLenum pname, GLfloat param);
            public delegate void glCombinerParameterivNV_(GLenum pname, IntPtr parameters);
            public delegate void glCombinerParameteriNV(GLenum pname, GLint param);
            public delegate void glCombinerInputNV(GLenum stage, GLenum portion, GLenum variable, GLenum input, GLenum mapping, GLenum componentUsage);
            public delegate void glCombinerOutputNV(GLenum stage, GLenum portion, GLenum abOutput, GLenum cdOutput, GLenum sumOutput, GLenum scale, GLenum bias, GLboolean abDotProduct, GLboolean cdDotProduct, GLboolean muxSum);
            public delegate void glFinalCombinerInputNV(GLenum variable, GLenum input, GLenum mapping, GLenum componentUsage);
            public delegate void glGetCombinerInputParameterfvNV(GLenum stage, GLenum portion, GLenum variable, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetCombinerInputParameterivNV(GLenum stage, GLenum portion, GLenum variable, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetCombinerOutputParameterfvNV(GLenum stage, GLenum portion, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetCombinerOutputParameterivNV(GLenum stage, GLenum portion, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetFinalCombinerInputParameterfvNV(GLenum variable, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetFinalCombinerInputParameterivNV(GLenum variable, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glResizeBuffersMESA();
            public delegate void glWindowPos2dMESA(GLdouble x, GLdouble y);
            public delegate void glWindowPos2dvMESA_(IntPtr v);
            public delegate void glWindowPos2fMESA(GLfloat x, GLfloat y);
            public delegate void glWindowPos2fvMESA_(IntPtr v);
            public delegate void glWindowPos2iMESA(GLint x, GLint y);
            public delegate void glWindowPos2ivMESA_(IntPtr v);
            public delegate void glWindowPos2sMESA(GLshort x, GLshort y);
            public delegate void glWindowPos2svMESA_(IntPtr v);
            public delegate void glWindowPos3dMESA(GLdouble x, GLdouble y, GLdouble z);
            public delegate void glWindowPos3dvMESA_(IntPtr v);
            public delegate void glWindowPos3fMESA(GLfloat x, GLfloat y, GLfloat z);
            public delegate void glWindowPos3fvMESA_(IntPtr v);
            public delegate void glWindowPos3iMESA(GLint x, GLint y, GLint z);
            public delegate void glWindowPos3ivMESA_(IntPtr v);
            public delegate void glWindowPos3sMESA(GLshort x, GLshort y, GLshort z);
            public delegate void glWindowPos3svMESA_(IntPtr v);
            public delegate void glWindowPos4dMESA(GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            public delegate void glWindowPos4dvMESA_(IntPtr v);
            public delegate void glWindowPos4fMESA(GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            public delegate void glWindowPos4fvMESA_(IntPtr v);
            public delegate void glWindowPos4iMESA(GLint x, GLint y, GLint z, GLint w);
            public delegate void glWindowPos4ivMESA_(IntPtr v);
            public delegate void glWindowPos4sMESA(GLshort x, GLshort y, GLshort z, GLshort w);
            public delegate void glWindowPos4svMESA_(IntPtr v);
            public delegate void glMultiModeDrawArraysIBM_(IntPtr mode, IntPtr first, IntPtr count, GLsizei primcount, GLint modestride);
            public delegate void glMultiModeDrawElementsIBM_(IntPtr mode, IntPtr count, GLenum type, IntPtr indices, GLsizei primcount, GLint modestride);
            public delegate void glColorPointerListIBM_(GLint size, GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);
            public delegate void glSecondaryColorPointerListIBM_(GLint size, GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);
            public delegate void glEdgeFlagPointerListIBM_(GLint stride, IntPtr pointer, GLint ptrstride);
            public delegate void glFogCoordPointerListIBM_(GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);
            public delegate void glIndexPointerListIBM_(GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);
            public delegate void glNormalPointerListIBM_(GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);
            public delegate void glTexCoordPointerListIBM_(GLint size, GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);
            public delegate void glVertexPointerListIBM_(GLint size, GLenum type, GLint stride, IntPtr pointer, GLint ptrstride);
            public delegate void glTbufferMask3DFX(GLuint mask);
            public delegate void glSampleMaskEXT(GLclampf value, GLboolean invert);
            public delegate void glSamplePatternEXT(GLenum pattern);
            public delegate void glTextureColorMaskSGIS(GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha);
            public delegate void glIglooInterfaceSGIX_(GLenum pname, IntPtr parameters);
            public delegate void glDeleteFencesNV_(GLsizei n, IntPtr fences);
            public delegate void glGenFencesNV(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] fences);
            public delegate GLboolean glIsFenceNV(GLuint fence);
            public delegate GLboolean glTestFenceNV(GLuint fence);
            public delegate void glGetFenceivNV(GLuint fence, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glFinishFenceNV(GLuint fence);
            public delegate void glSetFenceNV(GLuint fence, GLenum condition);
            public delegate void glMapControlPointsNV_(GLenum target, GLuint index, GLenum type, GLsizei ustride, GLsizei vstride, GLint uorder, GLint vorder, GLboolean packed, IntPtr points);
            public delegate void glMapParameterivNV_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glMapParameterfvNV_(GLenum target, GLenum pname, IntPtr parameters);
            public delegate void glGetMapControlPointsNV_(GLenum target, GLuint index, GLenum type, GLsizei ustride, GLsizei vstride, GLboolean packed, IntPtr points);
            public delegate void glGetMapParameterivNV(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetMapParameterfvNV(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetMapAttribParameterivNV(GLenum target, GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetMapAttribParameterfvNV(GLenum target, GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glEvalMapsNV(GLenum target, GLenum mode);
            public delegate void glCombinerStageParameterfvNV_(GLenum stage, GLenum pname, IntPtr parameters);
            public delegate void glGetCombinerStageParameterfvNV(GLenum stage, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate GLboolean glAreProgramsResidentNV_(GLsizei n, IntPtr programs, [MarshalAs(UnmanagedType.LPArray)] GLboolean[] residences);
            public delegate void glBindProgramNV(GLenum target, GLuint id);
            public delegate void glDeleteProgramsNV_(GLsizei n, IntPtr programs);
            public delegate void glExecuteProgramNV_(GLenum target, GLuint id, IntPtr parameters);
            public delegate void glGenProgramsNV(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] programs);
            public delegate void glGetProgramParameterdvNV(GLenum target, GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] parameters);
            public delegate void glGetProgramParameterfvNV(GLenum target, GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetProgramivNV(GLuint id, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetProgramStringNV(GLuint id, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLubyte[] program);
            public delegate void glGetTrackMatrixivNV(GLenum target, GLuint address, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetVertexAttribdvNV(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] parameters);
            public delegate void glGetVertexAttribfvNV(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetVertexAttribivNV(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetVertexAttribPointervNV(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] pointer);
            public delegate GLboolean glIsProgramNV(GLuint id);
            public delegate void glLoadProgramNV_(GLenum target, GLuint id, GLsizei len, IntPtr program);
            public delegate void glProgramParameter4dNV(GLenum target, GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            public delegate void glProgramParameter4dvNV_(GLenum target, GLuint index, IntPtr v);
            public delegate void glProgramParameter4fNV(GLenum target, GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            public delegate void glProgramParameter4fvNV_(GLenum target, GLuint index, IntPtr v);
            public delegate void glProgramParameters4dvNV_(GLenum target, GLuint index, GLuint count, IntPtr v);
            public delegate void glProgramParameters4fvNV_(GLenum target, GLuint index, GLuint count, IntPtr v);
            public delegate void glRequestResidentProgramsNV_(GLsizei n, IntPtr programs);
            public delegate void glTrackMatrixNV(GLenum target, GLuint address, GLenum matrix, GLenum transform);
            public delegate void glVertexAttribPointerNV_(GLuint index, GLint fsize, GLenum type, GLsizei stride, IntPtr pointer);
            public delegate void glVertexAttrib1dNV(GLuint index, GLdouble x);
            public delegate void glVertexAttrib1dvNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib1fNV(GLuint index, GLfloat x);
            public delegate void glVertexAttrib1fvNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib1sNV(GLuint index, GLshort x);
            public delegate void glVertexAttrib1svNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib2dNV(GLuint index, GLdouble x, GLdouble y);
            public delegate void glVertexAttrib2dvNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib2fNV(GLuint index, GLfloat x, GLfloat y);
            public delegate void glVertexAttrib2fvNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib2sNV(GLuint index, GLshort x, GLshort y);
            public delegate void glVertexAttrib2svNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib3dNV(GLuint index, GLdouble x, GLdouble y, GLdouble z);
            public delegate void glVertexAttrib3dvNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib3fNV(GLuint index, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glVertexAttrib3fvNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib3sNV(GLuint index, GLshort x, GLshort y, GLshort z);
            public delegate void glVertexAttrib3svNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4dNV(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            public delegate void glVertexAttrib4dvNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4fNV(GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            public delegate void glVertexAttrib4fvNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4sNV(GLuint index, GLshort x, GLshort y, GLshort z, GLshort w);
            public delegate void glVertexAttrib4svNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4ubNV(GLuint index, GLubyte x, GLubyte y, GLubyte z, GLubyte w);
            public delegate void glVertexAttrib4ubvNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttribs1dvNV_(GLuint index, GLsizei count, IntPtr v);
            public delegate void glVertexAttribs1fvNV_(GLuint index, GLsizei count, IntPtr v);
            public delegate void glVertexAttribs1svNV_(GLuint index, GLsizei count, IntPtr v);
            public delegate void glVertexAttribs2dvNV_(GLuint index, GLsizei count, IntPtr v);
            public delegate void glVertexAttribs2fvNV_(GLuint index, GLsizei count, IntPtr v);
            public delegate void glVertexAttribs2svNV_(GLuint index, GLsizei count, IntPtr v);
            public delegate void glVertexAttribs3dvNV_(GLuint index, GLsizei count, IntPtr v);
            public delegate void glVertexAttribs3fvNV_(GLuint index, GLsizei count, IntPtr v);
            public delegate void glVertexAttribs3svNV_(GLuint index, GLsizei count, IntPtr v);
            public delegate void glVertexAttribs4dvNV_(GLuint index, GLsizei count, IntPtr v);
            public delegate void glVertexAttribs4fvNV_(GLuint index, GLsizei count, IntPtr v);
            public delegate void glVertexAttribs4svNV_(GLuint index, GLsizei count, IntPtr v);
            public delegate void glVertexAttribs4ubvNV_(GLuint index, GLsizei count, IntPtr v);
            public delegate void glTexBumpParameterivATI_(GLenum pname, IntPtr param);
            public delegate void glTexBumpParameterfvATI_(GLenum pname, IntPtr param);
            public delegate void glGetTexBumpParameterivATI(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] param);
            public delegate void glGetTexBumpParameterfvATI(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] param);
            public delegate GLuint glGenFragmentShadersATI(GLuint range);
            public delegate void glBindFragmentShaderATI(GLuint id);
            public delegate void glDeleteFragmentShaderATI(GLuint id);
            public delegate void glBeginFragmentShaderATI();
            public delegate void glEndFragmentShaderATI();
            public delegate void glPassTexCoordATI(GLuint dst, GLuint coord, GLenum swizzle);
            public delegate void glSampleMapATI(GLuint dst, GLuint interp, GLenum swizzle);
            public delegate void glColorFragmentOp1ATI(GLenum op, GLuint dst, GLuint dstMask, GLuint dstMod, GLuint arg1, GLuint arg1Rep, GLuint arg1Mod);
            public delegate void glColorFragmentOp2ATI(GLenum op, GLuint dst, GLuint dstMask, GLuint dstMod, GLuint arg1, GLuint arg1Rep, GLuint arg1Mod, GLuint arg2, GLuint arg2Rep, GLuint arg2Mod);
            public delegate void glColorFragmentOp3ATI(GLenum op, GLuint dst, GLuint dstMask, GLuint dstMod, GLuint arg1, GLuint arg1Rep, GLuint arg1Mod, GLuint arg2, GLuint arg2Rep, GLuint arg2Mod, GLuint arg3, GLuint arg3Rep, GLuint arg3Mod);
            public delegate void glAlphaFragmentOp1ATI(GLenum op, GLuint dst, GLuint dstMod, GLuint arg1, GLuint arg1Rep, GLuint arg1Mod);
            public delegate void glAlphaFragmentOp2ATI(GLenum op, GLuint dst, GLuint dstMod, GLuint arg1, GLuint arg1Rep, GLuint arg1Mod, GLuint arg2, GLuint arg2Rep, GLuint arg2Mod);
            public delegate void glAlphaFragmentOp3ATI(GLenum op, GLuint dst, GLuint dstMod, GLuint arg1, GLuint arg1Rep, GLuint arg1Mod, GLuint arg2, GLuint arg2Rep, GLuint arg2Mod, GLuint arg3, GLuint arg3Rep, GLuint arg3Mod);
            public delegate void glSetFragmentShaderConstantATI_(GLuint dst, IntPtr value);
            public delegate void glPNTrianglesiATI(GLenum pname, GLint param);
            public delegate void glPNTrianglesfATI(GLenum pname, GLfloat param);
            public delegate GLuint glNewObjectBufferATI_(GLsizei size, IntPtr pointer, GLenum usage);
            public delegate GLboolean glIsObjectBufferATI(GLuint buffer);
            public delegate void glUpdateObjectBufferATI_(GLuint buffer, GLuint offset, GLsizei size, IntPtr pointer, GLenum preserve);
            public delegate void glGetObjectBufferfvATI(GLuint buffer, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetObjectBufferivATI(GLuint buffer, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glFreeObjectBufferATI(GLuint buffer);
            public delegate void glArrayObjectATI(GLenum array, GLint size, GLenum type, GLsizei stride, GLuint buffer, GLuint offset);
            public delegate void glGetArrayObjectfvATI(GLenum array, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetArrayObjectivATI(GLenum array, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glVariantArrayObjectATI(GLuint id, GLenum type, GLsizei stride, GLuint buffer, GLuint offset);
            public delegate void glGetVariantArrayObjectfvATI(GLuint id, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetVariantArrayObjectivATI(GLuint id, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glBeginVertexShaderEXT();
            public delegate void glEndVertexShaderEXT();
            public delegate void glBindVertexShaderEXT(GLuint id);
            public delegate GLuint glGenVertexShadersEXT(GLuint range);
            public delegate void glDeleteVertexShaderEXT(GLuint id);
            public delegate void glShaderOp1EXT(GLenum op, GLuint res, GLuint arg1);
            public delegate void glShaderOp2EXT(GLenum op, GLuint res, GLuint arg1, GLuint arg2);
            public delegate void glShaderOp3EXT(GLenum op, GLuint res, GLuint arg1, GLuint arg2, GLuint arg3);
            public delegate void glSwizzleEXT(GLuint res, GLuint @in, GLenum outX, GLenum outY, GLenum outZ, GLenum outW);
            public delegate void glWriteMaskEXT(GLuint res, GLuint @in, GLenum outX, GLenum outY, GLenum outZ, GLenum outW);
            public delegate void glInsertComponentEXT(GLuint res, GLuint src, GLuint num);
            public delegate void glExtractComponentEXT(GLuint res, GLuint src, GLuint num);
            public delegate GLuint glGenSymbolsEXT(GLenum datatype, GLenum storagetype, GLenum range, GLuint components);
            public delegate void glSetInvariantEXT_(GLuint id, GLenum type, IntPtr addr);
            public delegate void glSetLocalConstantEXT_(GLuint id, GLenum type, IntPtr addr);
            public delegate void glVariantbvEXT_(GLuint id, IntPtr addr);
            public delegate void glVariantsvEXT_(GLuint id, IntPtr addr);
            public delegate void glVariantivEXT_(GLuint id, IntPtr addr);
            public delegate void glVariantfvEXT_(GLuint id, IntPtr addr);
            public delegate void glVariantdvEXT_(GLuint id, IntPtr addr);
            public delegate void glVariantubvEXT_(GLuint id, IntPtr addr);
            public delegate void glVariantusvEXT_(GLuint id, IntPtr addr);
            public delegate void glVariantuivEXT_(GLuint id, IntPtr addr);
            public delegate void glVariantPointerEXT_(GLuint id, GLenum type, GLuint stride, IntPtr addr);
            public delegate void glEnableVariantClientStateEXT(GLuint id);
            public delegate void glDisableVariantClientStateEXT(GLuint id);
            public delegate GLuint glBindLightParameterEXT(GLenum light, GLenum value);
            public delegate GLuint glBindMaterialParameterEXT(GLenum face, GLenum value);
            public delegate GLuint glBindTexGenParameterEXT(GLenum unit, GLenum coord, GLenum value);
            public delegate GLuint glBindTextureUnitParameterEXT(GLenum unit, GLenum value);
            public delegate GLuint glBindParameterEXT(GLenum value);
            public delegate GLboolean glIsVariantEnabledEXT(GLuint id, GLenum cap);
            public delegate void glGetVariantBooleanvEXT(GLuint id, GLenum value, [MarshalAs(UnmanagedType.LPArray)] GLboolean[] data);
            public delegate void glGetVariantIntegervEXT(GLuint id, GLenum value, [MarshalAs(UnmanagedType.LPArray)] GLint[] data);
            public delegate void glGetVariantFloatvEXT(GLuint id, GLenum value, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] data);
            public delegate void glGetVariantPointervEXT(GLuint id, GLenum value, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] data);
            public delegate void glGetInvariantBooleanvEXT(GLuint id, GLenum value, [MarshalAs(UnmanagedType.LPArray)] GLboolean[] data);
            public delegate void glGetInvariantIntegervEXT(GLuint id, GLenum value, [MarshalAs(UnmanagedType.LPArray)] GLint[] data);
            public delegate void glGetInvariantFloatvEXT(GLuint id, GLenum value, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] data);
            public delegate void glGetLocalConstantBooleanvEXT(GLuint id, GLenum value, [MarshalAs(UnmanagedType.LPArray)] GLboolean[] data);
            public delegate void glGetLocalConstantIntegervEXT(GLuint id, GLenum value, [MarshalAs(UnmanagedType.LPArray)] GLint[] data);
            public delegate void glGetLocalConstantFloatvEXT(GLuint id, GLenum value, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] data);
            public delegate void glVertexStream1sATI(GLenum stream, GLshort x);
            public delegate void glVertexStream1svATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream1iATI(GLenum stream, GLint x);
            public delegate void glVertexStream1ivATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream1fATI(GLenum stream, GLfloat x);
            public delegate void glVertexStream1fvATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream1dATI(GLenum stream, GLdouble x);
            public delegate void glVertexStream1dvATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream2sATI(GLenum stream, GLshort x, GLshort y);
            public delegate void glVertexStream2svATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream2iATI(GLenum stream, GLint x, GLint y);
            public delegate void glVertexStream2ivATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream2fATI(GLenum stream, GLfloat x, GLfloat y);
            public delegate void glVertexStream2fvATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream2dATI(GLenum stream, GLdouble x, GLdouble y);
            public delegate void glVertexStream2dvATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream3sATI(GLenum stream, GLshort x, GLshort y, GLshort z);
            public delegate void glVertexStream3svATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream3iATI(GLenum stream, GLint x, GLint y, GLint z);
            public delegate void glVertexStream3ivATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream3fATI(GLenum stream, GLfloat x, GLfloat y, GLfloat z);
            public delegate void glVertexStream3fvATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream3dATI(GLenum stream, GLdouble x, GLdouble y, GLdouble z);
            public delegate void glVertexStream3dvATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream4sATI(GLenum stream, GLshort x, GLshort y, GLshort z, GLshort w);
            public delegate void glVertexStream4svATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream4iATI(GLenum stream, GLint x, GLint y, GLint z, GLint w);
            public delegate void glVertexStream4ivATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream4fATI(GLenum stream, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            public delegate void glVertexStream4fvATI_(GLenum stream, IntPtr coords);
            public delegate void glVertexStream4dATI(GLenum stream, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            public delegate void glVertexStream4dvATI_(GLenum stream, IntPtr coords);
            public delegate void glNormalStream3bATI(GLenum stream, GLbyte nx, GLbyte ny, GLbyte nz);
            public delegate void glNormalStream3bvATI_(GLenum stream, IntPtr coords);
            public delegate void glNormalStream3sATI(GLenum stream, GLshort nx, GLshort ny, GLshort nz);
            public delegate void glNormalStream3svATI_(GLenum stream, IntPtr coords);
            public delegate void glNormalStream3iATI(GLenum stream, GLint nx, GLint ny, GLint nz);
            public delegate void glNormalStream3ivATI_(GLenum stream, IntPtr coords);
            public delegate void glNormalStream3fATI(GLenum stream, GLfloat nx, GLfloat ny, GLfloat nz);
            public delegate void glNormalStream3fvATI_(GLenum stream, IntPtr coords);
            public delegate void glNormalStream3dATI(GLenum stream, GLdouble nx, GLdouble ny, GLdouble nz);
            public delegate void glNormalStream3dvATI_(GLenum stream, IntPtr coords);
            public delegate void glClientActiveVertexStreamATI(GLenum stream);
            public delegate void glVertexBlendEnviATI(GLenum pname, GLint param);
            public delegate void glVertexBlendEnvfATI(GLenum pname, GLfloat param);
            public delegate void glElementPointerATI_(GLenum type, IntPtr pointer);
            public delegate void glDrawElementArrayATI(GLenum mode, GLsizei count);
            public delegate void glDrawRangeElementArrayATI(GLenum mode, GLuint start, GLuint end, GLsizei count);
            public delegate void glDrawMeshArraysSUN(GLenum mode, GLint first, GLsizei count, GLsizei width);
            public delegate void glGenOcclusionQueriesNV(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] ids);
            public delegate void glDeleteOcclusionQueriesNV_(GLsizei n, IntPtr ids);
            public delegate GLboolean glIsOcclusionQueryNV(GLuint id);
            public delegate void glBeginOcclusionQueryNV(GLuint id);
            public delegate void glEndOcclusionQueryNV();
            public delegate void glGetOcclusionQueryivNV(GLuint id, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGetOcclusionQueryuivNV(GLuint id, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLuint[] parameters);
            public delegate void glPointParameteriNV(GLenum pname, GLint param);
            public delegate void glPointParameterivNV_(GLenum pname, IntPtr parameters);
            public delegate void glActiveStencilFaceEXT(GLenum face);
            public delegate void glElementPointerAPPLE_(GLenum type, IntPtr pointer);
            public delegate void glDrawElementArrayAPPLE(GLenum mode, GLint first, GLsizei count);
            public delegate void glDrawRangeElementArrayAPPLE(GLenum mode, GLuint start, GLuint end, GLint first, GLsizei count);
            public delegate void glMultiDrawElementArrayAPPLE_(GLenum mode, IntPtr first, IntPtr count, GLsizei primcount);
            public delegate void glMultiDrawRangeElementArrayAPPLE_(GLenum mode, GLuint start, GLuint end, IntPtr first, IntPtr count, GLsizei primcount);
            public delegate void glGenFencesAPPLE(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] fences);
            public delegate void glDeleteFencesAPPLE_(GLsizei n, IntPtr fences);
            public delegate void glSetFenceAPPLE(GLuint fence);
            public delegate GLboolean glIsFenceAPPLE(GLuint fence);
            public delegate GLboolean glTestFenceAPPLE(GLuint fence);
            public delegate void glFinishFenceAPPLE(GLuint fence);
            public delegate GLboolean glTestObjectAPPLE(GLenum @object, GLuint name);
            public delegate void glFinishObjectAPPLE(GLenum @object, GLint name);
            public delegate void glBindVertexArrayAPPLE(GLuint array);
            public delegate void glDeleteVertexArraysAPPLE_(GLsizei n, IntPtr arrays);
            public delegate void glGenVertexArraysAPPLE_(GLsizei n, IntPtr arrays);
            public delegate GLboolean glIsVertexArrayAPPLE(GLuint array);
            public delegate void glVertexArrayRangeAPPLE_(GLsizei length, IntPtr pointer);
            public delegate void glFlushVertexArrayRangeAPPLE_(GLsizei length, IntPtr pointer);
            public delegate void glVertexArrayParameteriAPPLE(GLenum pname, GLint param);
            public delegate void glDrawBuffersATI_(GLsizei n, IntPtr bufs);
            public delegate void glProgramNamedParameter4fNV_(GLuint id, GLsizei len, IntPtr name, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            public delegate void glProgramNamedParameter4dNV_(GLuint id, GLsizei len, IntPtr name, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            public delegate void glProgramNamedParameter4fvNV_(GLuint id, GLsizei len, IntPtr name, IntPtr v);
            public delegate void glProgramNamedParameter4dvNV_(GLuint id, GLsizei len, IntPtr name, IntPtr v);
            public delegate void glGetProgramNamedParameterfvNV_(GLuint id, GLsizei len, IntPtr name, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetProgramNamedParameterdvNV_(GLuint id, GLsizei len, IntPtr name, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] parameters);
            public delegate void glVertex2hNV(GLhalfNV x, GLhalfNV y);
            public delegate void glVertex2hvNV_(IntPtr v);
            public delegate void glVertex3hNV(GLhalfNV x, GLhalfNV y, GLhalfNV z);
            public delegate void glVertex3hvNV_(IntPtr v);
            public delegate void glVertex4hNV(GLhalfNV x, GLhalfNV y, GLhalfNV z, GLhalfNV w);
            public delegate void glVertex4hvNV_(IntPtr v);
            public delegate void glNormal3hNV(GLhalfNV nx, GLhalfNV ny, GLhalfNV nz);
            public delegate void glNormal3hvNV_(IntPtr v);
            public delegate void glColor3hNV(GLhalfNV red, GLhalfNV green, GLhalfNV blue);
            public delegate void glColor3hvNV_(IntPtr v);
            public delegate void glColor4hNV(GLhalfNV red, GLhalfNV green, GLhalfNV blue, GLhalfNV alpha);
            public delegate void glColor4hvNV_(IntPtr v);
            public delegate void glTexCoord1hNV(GLhalfNV s);
            public delegate void glTexCoord1hvNV_(IntPtr v);
            public delegate void glTexCoord2hNV(GLhalfNV s, GLhalfNV t);
            public delegate void glTexCoord2hvNV_(IntPtr v);
            public delegate void glTexCoord3hNV(GLhalfNV s, GLhalfNV t, GLhalfNV r);
            public delegate void glTexCoord3hvNV_(IntPtr v);
            public delegate void glTexCoord4hNV(GLhalfNV s, GLhalfNV t, GLhalfNV r, GLhalfNV q);
            public delegate void glTexCoord4hvNV_(IntPtr v);
            public delegate void glMultiTexCoord1hNV(GLenum target, GLhalfNV s);
            public delegate void glMultiTexCoord1hvNV_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord2hNV(GLenum target, GLhalfNV s, GLhalfNV t);
            public delegate void glMultiTexCoord2hvNV_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord3hNV(GLenum target, GLhalfNV s, GLhalfNV t, GLhalfNV r);
            public delegate void glMultiTexCoord3hvNV_(GLenum target, IntPtr v);
            public delegate void glMultiTexCoord4hNV(GLenum target, GLhalfNV s, GLhalfNV t, GLhalfNV r, GLhalfNV q);
            public delegate void glMultiTexCoord4hvNV_(GLenum target, IntPtr v);
            public delegate void glFogCoordhNV(GLhalfNV fog);
            public delegate void glFogCoordhvNV_(IntPtr fog);
            public delegate void glSecondaryColor3hNV(GLhalfNV red, GLhalfNV green, GLhalfNV blue);
            public delegate void glSecondaryColor3hvNV_(IntPtr v);
            public delegate void glVertexWeighthNV(GLhalfNV weight);
            public delegate void glVertexWeighthvNV_(IntPtr weight);
            public delegate void glVertexAttrib1hNV(GLuint index, GLhalfNV x);
            public delegate void glVertexAttrib1hvNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib2hNV(GLuint index, GLhalfNV x, GLhalfNV y);
            public delegate void glVertexAttrib2hvNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib3hNV(GLuint index, GLhalfNV x, GLhalfNV y, GLhalfNV z);
            public delegate void glVertexAttrib3hvNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttrib4hNV(GLuint index, GLhalfNV x, GLhalfNV y, GLhalfNV z, GLhalfNV w);
            public delegate void glVertexAttrib4hvNV_(GLuint index, IntPtr v);
            public delegate void glVertexAttribs1hvNV_(GLuint index, GLsizei n, IntPtr v);
            public delegate void glVertexAttribs2hvNV_(GLuint index, GLsizei n, IntPtr v);
            public delegate void glVertexAttribs3hvNV_(GLuint index, GLsizei n, IntPtr v);
            public delegate void glVertexAttribs4hvNV_(GLuint index, GLsizei n, IntPtr v);
            public delegate void glPixelDataRangeNV_(GLenum target, GLsizei length, IntPtr pointer);
            public delegate void glFlushPixelDataRangeNV(GLenum target);
            public delegate void glPrimitiveRestartNV();
            public delegate void glPrimitiveRestartIndexNV(GLuint index);
            public delegate IntPtr glMapObjectBufferATI(GLuint buffer);
            public delegate void glUnmapObjectBufferATI(GLuint buffer);
            public delegate void glStencilOpSeparateATI(GLenum face, GLenum sfail, GLenum dpfail, GLenum dppass);
            public delegate void glStencilFuncSeparateATI(GLenum frontfunc, GLenum backfunc, GLint reference, GLuint mask);
            public delegate void glVertexAttribArrayObjectATI(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, GLuint buffer, GLuint offset);
            public delegate void glGetVertexAttribArrayObjectfvATI(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            public delegate void glGetVertexAttribArrayObjectivATI(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glDepthBoundsEXT(GLclampd zmin, GLclampd zmax);
            public delegate void glBlendEquationSeparateEXT(GLenum modeRGB, GLenum modeAlpha);
            public delegate GLboolean glIsRenderbufferEXT(GLuint renderbuffer);
            public delegate void glBindRenderbufferEXT(GLenum target, GLuint renderbuffer);
            public delegate void glDeleteRenderbuffersEXT_(GLsizei n, IntPtr renderbuffers);
            public delegate void glGenRenderbuffersEXT(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] renderbuffers);
            public delegate void glRenderbufferStorageEXT(GLenum target, GLenum internalformat, GLsizei width, GLsizei height);
            public delegate void glGetRenderbufferParameterivEXT(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate GLboolean glIsFramebufferEXT(GLuint framebuffer);
            public delegate void glBindFramebufferEXT(GLenum target, GLuint framebuffer);
            public delegate void glDeleteFramebuffersEXT_(GLsizei n, IntPtr framebuffers);
            public delegate void glGenFramebuffersEXT(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] framebuffers);
            public delegate GLenum glCheckFramebufferStatusEXT(GLenum target);
            public delegate void glFramebufferTexture1DEXT(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level);
            public delegate void glFramebufferTexture2DEXT(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level);
            public delegate void glFramebufferTexture3DEXT(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level, GLint zoffset);
            public delegate void glFramebufferRenderbufferEXT(GLenum target, GLenum attachment, GLenum renderbuffertarget, GLuint renderbuffer);
            public delegate void glGetFramebufferAttachmentParameterivEXT(GLenum target, GLenum attachment, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            public delegate void glGenerateMipmapEXT(GLenum target);
            public delegate void glStringMarkerGREMEDY_(GLsizei len, IntPtr @string);
        }
        #endregion

        #region Imports

        internal class Imports
        {
            [DllImport("opengl32", EntryPoint = "glNewList")]
            public static extern void glNewList(GLuint list, GLenum mode);
            [DllImport("opengl32", EntryPoint = "glEndList")]
            public static extern void glEndList();
            [DllImport("opengl32", EntryPoint = "glCallList")]
            public static extern void glCallList(GLuint list);
            [DllImport("opengl32", EntryPoint = "glCallLists")]
            public static extern void glCallLists_(GLsizei n, GLenum type, IntPtr lists);
            [DllImport("opengl32", EntryPoint = "glDeleteLists")]
            public static extern void glDeleteLists(GLuint list, GLsizei range);
            [DllImport("opengl32", EntryPoint = "glGenLists")]
            public static extern GLuint glGenLists(GLsizei range);
            [DllImport("opengl32", EntryPoint = "glListBase")]
            public static extern void glListBase(GLuint @base);
            [DllImport("opengl32", EntryPoint = "glBegin")]
            public static extern void glBegin(GLenum mode);
            [DllImport("opengl32", EntryPoint = "glBitmap")]
            public static extern void glBitmap_(GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, IntPtr bitmap);
            [DllImport("opengl32", EntryPoint = "glColor3b")]
            public static extern void glColor3b(GLbyte red, GLbyte green, GLbyte blue);
            [DllImport("opengl32", EntryPoint = "glColor3bv")]
            public static extern void glColor3bv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor3d")]
            public static extern void glColor3d(GLdouble red, GLdouble green, GLdouble blue);
            [DllImport("opengl32", EntryPoint = "glColor3dv")]
            public static extern void glColor3dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor3f")]
            public static extern void glColor3f(GLfloat red, GLfloat green, GLfloat blue);
            [DllImport("opengl32", EntryPoint = "glColor3fv")]
            public static extern void glColor3fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor3i")]
            public static extern void glColor3i(GLint red, GLint green, GLint blue);
            [DllImport("opengl32", EntryPoint = "glColor3iv")]
            public static extern void glColor3iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor3s")]
            public static extern void glColor3s(GLshort red, GLshort green, GLshort blue);
            [DllImport("opengl32", EntryPoint = "glColor3sv")]
            public static extern void glColor3sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor3ub")]
            public static extern void glColor3ub(GLubyte red, GLubyte green, GLubyte blue);
            [DllImport("opengl32", EntryPoint = "glColor3ubv")]
            public static extern void glColor3ubv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor3ui")]
            public static extern void glColor3ui(GLuint red, GLuint green, GLuint blue);
            [DllImport("opengl32", EntryPoint = "glColor3uiv")]
            public static extern void glColor3uiv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor3us")]
            public static extern void glColor3us(GLushort red, GLushort green, GLushort blue);
            [DllImport("opengl32", EntryPoint = "glColor3usv")]
            public static extern void glColor3usv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor4b")]
            public static extern void glColor4b(GLbyte red, GLbyte green, GLbyte blue, GLbyte alpha);
            [DllImport("opengl32", EntryPoint = "glColor4bv")]
            public static extern void glColor4bv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor4d")]
            public static extern void glColor4d(GLdouble red, GLdouble green, GLdouble blue, GLdouble alpha);
            [DllImport("opengl32", EntryPoint = "glColor4dv")]
            public static extern void glColor4dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor4f")]
            public static extern void glColor4f(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);
            [DllImport("opengl32", EntryPoint = "glColor4fv")]
            public static extern void glColor4fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor4i")]
            public static extern void glColor4i(GLint red, GLint green, GLint blue, GLint alpha);
            [DllImport("opengl32", EntryPoint = "glColor4iv")]
            public static extern void glColor4iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor4s")]
            public static extern void glColor4s(GLshort red, GLshort green, GLshort blue, GLshort alpha);
            [DllImport("opengl32", EntryPoint = "glColor4sv")]
            public static extern void glColor4sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor4ub")]
            public static extern void glColor4ub(GLubyte red, GLubyte green, GLubyte blue, GLubyte alpha);
            [DllImport("opengl32", EntryPoint = "glColor4ubv")]
            public static extern void glColor4ubv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor4ui")]
            public static extern void glColor4ui(GLuint red, GLuint green, GLuint blue, GLuint alpha);
            [DllImport("opengl32", EntryPoint = "glColor4uiv")]
            public static extern void glColor4uiv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glColor4us")]
            public static extern void glColor4us(GLushort red, GLushort green, GLushort blue, GLushort alpha);
            [DllImport("opengl32", EntryPoint = "glColor4usv")]
            public static extern void glColor4usv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glEdgeFlag")]
            public static extern void glEdgeFlag(GLboolean flag);
            [DllImport("opengl32", EntryPoint = "glEdgeFlagv")]
            public static extern void glEdgeFlagv_(IntPtr flag);
            [DllImport("opengl32", EntryPoint = "glEnd")]
            public static extern void glEnd();
            [DllImport("opengl32", EntryPoint = "glIndexd")]
            public static extern void glIndexd(GLdouble c);
            [DllImport("opengl32", EntryPoint = "glIndexdv")]
            public static extern void glIndexdv_(IntPtr c);
            [DllImport("opengl32", EntryPoint = "glIndexf")]
            public static extern void glIndexf(GLfloat c);
            [DllImport("opengl32", EntryPoint = "glIndexfv")]
            public static extern void glIndexfv_(IntPtr c);
            [DllImport("opengl32", EntryPoint = "glIndexi")]
            public static extern void glIndexi(GLint c);
            [DllImport("opengl32", EntryPoint = "glIndexiv")]
            public static extern void glIndexiv_(IntPtr c);
            [DllImport("opengl32", EntryPoint = "glIndexs")]
            public static extern void glIndexs(GLshort c);
            [DllImport("opengl32", EntryPoint = "glIndexsv")]
            public static extern void glIndexsv_(IntPtr c);
            [DllImport("opengl32", EntryPoint = "glNormal3b")]
            public static extern void glNormal3b(GLbyte nx, GLbyte ny, GLbyte nz);
            [DllImport("opengl32", EntryPoint = "glNormal3bv")]
            public static extern void glNormal3bv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glNormal3d")]
            public static extern void glNormal3d(GLdouble nx, GLdouble ny, GLdouble nz);
            [DllImport("opengl32", EntryPoint = "glNormal3dv")]
            public static extern void glNormal3dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glNormal3f")]
            public static extern void glNormal3f(GLfloat nx, GLfloat ny, GLfloat nz);
            [DllImport("opengl32", EntryPoint = "glNormal3fv")]
            public static extern void glNormal3fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glNormal3i")]
            public static extern void glNormal3i(GLint nx, GLint ny, GLint nz);
            [DllImport("opengl32", EntryPoint = "glNormal3iv")]
            public static extern void glNormal3iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glNormal3s")]
            public static extern void glNormal3s(GLshort nx, GLshort ny, GLshort nz);
            [DllImport("opengl32", EntryPoint = "glNormal3sv")]
            public static extern void glNormal3sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glRasterPos2d")]
            public static extern void glRasterPos2d(GLdouble x, GLdouble y);
            [DllImport("opengl32", EntryPoint = "glRasterPos2dv")]
            public static extern void glRasterPos2dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glRasterPos2f")]
            public static extern void glRasterPos2f(GLfloat x, GLfloat y);
            [DllImport("opengl32", EntryPoint = "glRasterPos2fv")]
            public static extern void glRasterPos2fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glRasterPos2i")]
            public static extern void glRasterPos2i(GLint x, GLint y);
            [DllImport("opengl32", EntryPoint = "glRasterPos2iv")]
            public static extern void glRasterPos2iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glRasterPos2s")]
            public static extern void glRasterPos2s(GLshort x, GLshort y);
            [DllImport("opengl32", EntryPoint = "glRasterPos2sv")]
            public static extern void glRasterPos2sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glRasterPos3d")]
            public static extern void glRasterPos3d(GLdouble x, GLdouble y, GLdouble z);
            [DllImport("opengl32", EntryPoint = "glRasterPos3dv")]
            public static extern void glRasterPos3dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glRasterPos3f")]
            public static extern void glRasterPos3f(GLfloat x, GLfloat y, GLfloat z);
            [DllImport("opengl32", EntryPoint = "glRasterPos3fv")]
            public static extern void glRasterPos3fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glRasterPos3i")]
            public static extern void glRasterPos3i(GLint x, GLint y, GLint z);
            [DllImport("opengl32", EntryPoint = "glRasterPos3iv")]
            public static extern void glRasterPos3iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glRasterPos3s")]
            public static extern void glRasterPos3s(GLshort x, GLshort y, GLshort z);
            [DllImport("opengl32", EntryPoint = "glRasterPos3sv")]
            public static extern void glRasterPos3sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glRasterPos4d")]
            public static extern void glRasterPos4d(GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            [DllImport("opengl32", EntryPoint = "glRasterPos4dv")]
            public static extern void glRasterPos4dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glRasterPos4f")]
            public static extern void glRasterPos4f(GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            [DllImport("opengl32", EntryPoint = "glRasterPos4fv")]
            public static extern void glRasterPos4fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glRasterPos4i")]
            public static extern void glRasterPos4i(GLint x, GLint y, GLint z, GLint w);
            [DllImport("opengl32", EntryPoint = "glRasterPos4iv")]
            public static extern void glRasterPos4iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glRasterPos4s")]
            public static extern void glRasterPos4s(GLshort x, GLshort y, GLshort z, GLshort w);
            [DllImport("opengl32", EntryPoint = "glRasterPos4sv")]
            public static extern void glRasterPos4sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glRectd")]
            public static extern void glRectd(GLdouble x1, GLdouble y1, GLdouble x2, GLdouble y2);
            [DllImport("opengl32", EntryPoint = "glRectdv")]
            public static extern void glRectdv_(IntPtr v1, IntPtr v2);
            [DllImport("opengl32", EntryPoint = "glRectf")]
            public static extern void glRectf(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2);
            [DllImport("opengl32", EntryPoint = "glRectfv")]
            public static extern void glRectfv_(IntPtr v1, IntPtr v2);
            [DllImport("opengl32", EntryPoint = "glRecti")]
            public static extern void glRecti(GLint x1, GLint y1, GLint x2, GLint y2);
            [DllImport("opengl32", EntryPoint = "glRectiv")]
            public static extern void glRectiv_(IntPtr v1, IntPtr v2);
            [DllImport("opengl32", EntryPoint = "glRects")]
            public static extern void glRects(GLshort x1, GLshort y1, GLshort x2, GLshort y2);
            [DllImport("opengl32", EntryPoint = "glRectsv")]
            public static extern void glRectsv_(IntPtr v1, IntPtr v2);
            [DllImport("opengl32", EntryPoint = "glTexCoord1d")]
            public static extern void glTexCoord1d(GLdouble s);
            [DllImport("opengl32", EntryPoint = "glTexCoord1dv")]
            public static extern void glTexCoord1dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord1f")]
            public static extern void glTexCoord1f(GLfloat s);
            [DllImport("opengl32", EntryPoint = "glTexCoord1fv")]
            public static extern void glTexCoord1fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord1i")]
            public static extern void glTexCoord1i(GLint s);
            [DllImport("opengl32", EntryPoint = "glTexCoord1iv")]
            public static extern void glTexCoord1iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord1s")]
            public static extern void glTexCoord1s(GLshort s);
            [DllImport("opengl32", EntryPoint = "glTexCoord1sv")]
            public static extern void glTexCoord1sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord2d")]
            public static extern void glTexCoord2d(GLdouble s, GLdouble t);
            [DllImport("opengl32", EntryPoint = "glTexCoord2dv")]
            public static extern void glTexCoord2dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord2f")]
            public static extern void glTexCoord2f(GLfloat s, GLfloat t);
            [DllImport("opengl32", EntryPoint = "glTexCoord2fv")]
            public static extern void glTexCoord2fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord2i")]
            public static extern void glTexCoord2i(GLint s, GLint t);
            [DllImport("opengl32", EntryPoint = "glTexCoord2iv")]
            public static extern void glTexCoord2iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord2s")]
            public static extern void glTexCoord2s(GLshort s, GLshort t);
            [DllImport("opengl32", EntryPoint = "glTexCoord2sv")]
            public static extern void glTexCoord2sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord3d")]
            public static extern void glTexCoord3d(GLdouble s, GLdouble t, GLdouble r);
            [DllImport("opengl32", EntryPoint = "glTexCoord3dv")]
            public static extern void glTexCoord3dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord3f")]
            public static extern void glTexCoord3f(GLfloat s, GLfloat t, GLfloat r);
            [DllImport("opengl32", EntryPoint = "glTexCoord3fv")]
            public static extern void glTexCoord3fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord3i")]
            public static extern void glTexCoord3i(GLint s, GLint t, GLint r);
            [DllImport("opengl32", EntryPoint = "glTexCoord3iv")]
            public static extern void glTexCoord3iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord3s")]
            public static extern void glTexCoord3s(GLshort s, GLshort t, GLshort r);
            [DllImport("opengl32", EntryPoint = "glTexCoord3sv")]
            public static extern void glTexCoord3sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord4d")]
            public static extern void glTexCoord4d(GLdouble s, GLdouble t, GLdouble r, GLdouble q);
            [DllImport("opengl32", EntryPoint = "glTexCoord4dv")]
            public static extern void glTexCoord4dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord4f")]
            public static extern void glTexCoord4f(GLfloat s, GLfloat t, GLfloat r, GLfloat q);
            [DllImport("opengl32", EntryPoint = "glTexCoord4fv")]
            public static extern void glTexCoord4fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord4i")]
            public static extern void glTexCoord4i(GLint s, GLint t, GLint r, GLint q);
            [DllImport("opengl32", EntryPoint = "glTexCoord4iv")]
            public static extern void glTexCoord4iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glTexCoord4s")]
            public static extern void glTexCoord4s(GLshort s, GLshort t, GLshort r, GLshort q);
            [DllImport("opengl32", EntryPoint = "glTexCoord4sv")]
            public static extern void glTexCoord4sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertex2d")]
            public static extern void glVertex2d(GLdouble x, GLdouble y);
            [DllImport("opengl32", EntryPoint = "glVertex2dv")]
            public static extern void glVertex2dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertex2f")]
            public static extern void glVertex2f(GLfloat x, GLfloat y);
            [DllImport("opengl32", EntryPoint = "glVertex2fv")]
            public static extern void glVertex2fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertex2i")]
            public static extern void glVertex2i(GLint x, GLint y);
            [DllImport("opengl32", EntryPoint = "glVertex2iv")]
            public static extern void glVertex2iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertex2s")]
            public static extern void glVertex2s(GLshort x, GLshort y);
            [DllImport("opengl32", EntryPoint = "glVertex2sv")]
            public static extern void glVertex2sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertex3d")]
            public static extern void glVertex3d(GLdouble x, GLdouble y, GLdouble z);
            [DllImport("opengl32", EntryPoint = "glVertex3dv")]
            public static extern void glVertex3dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertex3f")]
            public static extern void glVertex3f(GLfloat x, GLfloat y, GLfloat z);
            [DllImport("opengl32", EntryPoint = "glVertex3fv")]
            public static extern void glVertex3fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertex3i")]
            public static extern void glVertex3i(GLint x, GLint y, GLint z);
            [DllImport("opengl32", EntryPoint = "glVertex3iv")]
            public static extern void glVertex3iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertex3s")]
            public static extern void glVertex3s(GLshort x, GLshort y, GLshort z);
            [DllImport("opengl32", EntryPoint = "glVertex3sv")]
            public static extern void glVertex3sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertex4d")]
            public static extern void glVertex4d(GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            [DllImport("opengl32", EntryPoint = "glVertex4dv")]
            public static extern void glVertex4dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertex4f")]
            public static extern void glVertex4f(GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            [DllImport("opengl32", EntryPoint = "glVertex4fv")]
            public static extern void glVertex4fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertex4i")]
            public static extern void glVertex4i(GLint x, GLint y, GLint z, GLint w);
            [DllImport("opengl32", EntryPoint = "glVertex4iv")]
            public static extern void glVertex4iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertex4s")]
            public static extern void glVertex4s(GLshort x, GLshort y, GLshort z, GLshort w);
            [DllImport("opengl32", EntryPoint = "glVertex4sv")]
            public static extern void glVertex4sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glClipPlane")]
            public static extern void glClipPlane_(GLenum plane, IntPtr equation);
            [DllImport("opengl32", EntryPoint = "glColorMaterial")]
            public static extern void glColorMaterial(GLenum face, GLenum mode);
            [DllImport("opengl32", EntryPoint = "glCullFace")]
            public static extern void glCullFace(GLenum mode);
            [DllImport("opengl32", EntryPoint = "glFogf")]
            public static extern void glFogf(GLenum pname, GLfloat param);
            [DllImport("opengl32", EntryPoint = "glFogfv")]
            public static extern void glFogfv_(GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glFogi")]
            public static extern void glFogi(GLenum pname, GLint param);
            [DllImport("opengl32", EntryPoint = "glFogiv")]
            public static extern void glFogiv_(GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glFrontFace")]
            public static extern void glFrontFace(GLenum mode);
            [DllImport("opengl32", EntryPoint = "glHint")]
            public static extern void glHint(GLenum target, GLenum mode);
            [DllImport("opengl32", EntryPoint = "glLightf")]
            public static extern void glLightf(GLenum light, GLenum pname, GLfloat param);
            [DllImport("opengl32", EntryPoint = "glLightfv")]
            public static extern void glLightfv_(GLenum light, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glLighti")]
            public static extern void glLighti(GLenum light, GLenum pname, GLint param);
            [DllImport("opengl32", EntryPoint = "glLightiv")]
            public static extern void glLightiv_(GLenum light, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glLightModelf")]
            public static extern void glLightModelf(GLenum pname, GLfloat param);
            [DllImport("opengl32", EntryPoint = "glLightModelfv")]
            public static extern void glLightModelfv_(GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glLightModeli")]
            public static extern void glLightModeli(GLenum pname, GLint param);
            [DllImport("opengl32", EntryPoint = "glLightModeliv")]
            public static extern void glLightModeliv_(GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glLineStipple")]
            public static extern void glLineStipple_(GLint factor, GLushort pattern);
            [DllImport("opengl32", EntryPoint = "glLineWidth")]
            public static extern void glLineWidth(GLfloat width);
            [DllImport("opengl32", EntryPoint = "glMaterialf")]
            public static extern void glMaterialf(GLenum face, GLenum pname, GLfloat param);
            [DllImport("opengl32", EntryPoint = "glMaterialfv")]
            public static extern void glMaterialfv_(GLenum face, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glMateriali")]
            public static extern void glMateriali(GLenum face, GLenum pname, GLint param);
            [DllImport("opengl32", EntryPoint = "glMaterialiv")]
            public static extern void glMaterialiv_(GLenum face, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glPointSize")]
            public static extern void glPointSize(GLfloat size);
            [DllImport("opengl32", EntryPoint = "glPolygonMode")]
            public static extern void glPolygonMode(GLenum face, GLenum mode);
            [DllImport("opengl32", EntryPoint = "glPolygonStipple")]
            public static extern void glPolygonStipple_(IntPtr mask);
            [DllImport("opengl32", EntryPoint = "glScissor")]
            public static extern void glScissor(GLint x, GLint y, GLsizei width, GLsizei height);
            [DllImport("opengl32", EntryPoint = "glShadeModel")]
            public static extern void glShadeModel(GLenum mode);
            [DllImport("opengl32", EntryPoint = "glTexParameterf")]
            public static extern void glTexParameterf(GLenum target, GLenum pname, GLfloat param);
            [DllImport("opengl32", EntryPoint = "glTexParameterfv")]
            public static extern void glTexParameterfv_(GLenum target, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glTexParameteri")]
            public static extern void glTexParameteri(GLenum target, GLenum pname, GLint param);
            [DllImport("opengl32", EntryPoint = "glTexParameteriv")]
            public static extern void glTexParameteriv_(GLenum target, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glTexImage1D")]
            public static extern void glTexImage1D_(GLenum target, GLint level, GLint internalformat, GLsizei width, GLint border, GLenum format, GLenum type, IntPtr pixels);
            [DllImport("opengl32", EntryPoint = "glTexImage2D")]
            public static extern void glTexImage2D_(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, IntPtr pixels);
            [DllImport("opengl32", EntryPoint = "glTexEnvf")]
            public static extern void glTexEnvf(GLenum target, GLenum pname, GLfloat param);
            [DllImport("opengl32", EntryPoint = "glTexEnvfv")]
            public static extern void glTexEnvfv_(GLenum target, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glTexEnvi")]
            public static extern void glTexEnvi(GLenum target, GLenum pname, GLint param);
            [DllImport("opengl32", EntryPoint = "glTexEnviv")]
            public static extern void glTexEnviv_(GLenum target, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glTexGend")]
            public static extern void glTexGend(GLenum coord, GLenum pname, GLdouble param);
            [DllImport("opengl32", EntryPoint = "glTexGendv")]
            public static extern void glTexGendv_(GLenum coord, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glTexGenf")]
            public static extern void glTexGenf(GLenum coord, GLenum pname, GLfloat param);
            [DllImport("opengl32", EntryPoint = "glTexGenfv")]
            public static extern void glTexGenfv_(GLenum coord, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glTexGeni")]
            public static extern void glTexGeni(GLenum coord, GLenum pname, GLint param);
            [DllImport("opengl32", EntryPoint = "glTexGeniv")]
            public static extern void glTexGeniv_(GLenum coord, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glFeedbackBuffer")]
            public static extern void glFeedbackBuffer(GLsizei size, GLenum type, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] buffer);
            [DllImport("opengl32", EntryPoint = "glSelectBuffer")]
            public static extern void glSelectBuffer(GLsizei size, [MarshalAs(UnmanagedType.LPArray)] GLuint[] buffer);
            [DllImport("opengl32", EntryPoint = "glRenderMode")]
            public static extern GLint glRenderMode(GLenum mode);
            [DllImport("opengl32", EntryPoint = "glInitNames")]
            public static extern void glInitNames();
            [DllImport("opengl32", EntryPoint = "glLoadName")]
            public static extern void glLoadName(GLuint name);
            [DllImport("opengl32", EntryPoint = "glPassThrough")]
            public static extern void glPassThrough(GLfloat token);
            [DllImport("opengl32", EntryPoint = "glPopName")]
            public static extern void glPopName();
            [DllImport("opengl32", EntryPoint = "glPushName")]
            public static extern void glPushName(GLuint name);
            [DllImport("opengl32", EntryPoint = "glDrawBuffer")]
            public static extern void glDrawBuffer(GLenum mode);
            [DllImport("opengl32", EntryPoint = "glClear")]
            public static extern void glClear(GLbitfield mask);
            [DllImport("opengl32", EntryPoint = "glClearAccum")]
            public static extern void glClearAccum(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);
            [DllImport("opengl32", EntryPoint = "glClearIndex")]
            public static extern void glClearIndex(GLfloat c);
            [DllImport("opengl32", EntryPoint = "glClearColor")]
            public static extern void glClearColor(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);
            [DllImport("opengl32", EntryPoint = "glClearStencil")]
            public static extern void glClearStencil(GLint s);
            [DllImport("opengl32", EntryPoint = "glClearDepth")]
            public static extern void glClearDepth(GLclampd depth);
            [DllImport("opengl32", EntryPoint = "glStencilMask")]
            public static extern void glStencilMask(GLuint mask);
            [DllImport("opengl32", EntryPoint = "glColorMask")]
            public static extern void glColorMask(GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha);
            [DllImport("opengl32", EntryPoint = "glDepthMask")]
            public static extern void glDepthMask(GLboolean flag);
            [DllImport("opengl32", EntryPoint = "glIndexMask")]
            public static extern void glIndexMask(GLuint mask);
            [DllImport("opengl32", EntryPoint = "glAccum")]
            public static extern void glAccum(GLenum op, GLfloat value);
            [DllImport("opengl32", EntryPoint = "glDisable")]
            public static extern void glDisable(GLenum cap);
            [DllImport("opengl32", EntryPoint = "glEnable")]
            public static extern void glEnable(GLenum cap);
            [DllImport("opengl32", EntryPoint = "glFinish")]
            public static extern void glFinish();
            [DllImport("opengl32", EntryPoint = "glFlush")]
            public static extern void glFlush();
            [DllImport("opengl32", EntryPoint = "glPopAttrib")]
            public static extern void glPopAttrib();
            [DllImport("opengl32", EntryPoint = "glPushAttrib")]
            public static extern void glPushAttrib(GLbitfield mask);
            [DllImport("opengl32", EntryPoint = "glMap1d")]
            public static extern void glMap1d_(GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, IntPtr points);
            [DllImport("opengl32", EntryPoint = "glMap1f")]
            public static extern void glMap1f_(GLenum target, GLfloat u1, GLfloat u2, GLint stride, GLint order, IntPtr points);
            [DllImport("opengl32", EntryPoint = "glMap2d")]
            public static extern void glMap2d_(GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, IntPtr points);
            [DllImport("opengl32", EntryPoint = "glMap2f")]
            public static extern void glMap2f_(GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, IntPtr points);
            [DllImport("opengl32", EntryPoint = "glMapGrid1d")]
            public static extern void glMapGrid1d(GLint un, GLdouble u1, GLdouble u2);
            [DllImport("opengl32", EntryPoint = "glMapGrid1f")]
            public static extern void glMapGrid1f(GLint un, GLfloat u1, GLfloat u2);
            [DllImport("opengl32", EntryPoint = "glMapGrid2d")]
            public static extern void glMapGrid2d(GLint un, GLdouble u1, GLdouble u2, GLint vn, GLdouble v1, GLdouble v2);
            [DllImport("opengl32", EntryPoint = "glMapGrid2f")]
            public static extern void glMapGrid2f(GLint un, GLfloat u1, GLfloat u2, GLint vn, GLfloat v1, GLfloat v2);
            [DllImport("opengl32", EntryPoint = "glEvalCoord1d")]
            public static extern void glEvalCoord1d(GLdouble u);
            [DllImport("opengl32", EntryPoint = "glEvalCoord1dv")]
            public static extern void glEvalCoord1dv_(IntPtr u);
            [DllImport("opengl32", EntryPoint = "glEvalCoord1f")]
            public static extern void glEvalCoord1f(GLfloat u);
            [DllImport("opengl32", EntryPoint = "glEvalCoord1fv")]
            public static extern void glEvalCoord1fv_(IntPtr u);
            [DllImport("opengl32", EntryPoint = "glEvalCoord2d")]
            public static extern void glEvalCoord2d(GLdouble u, GLdouble v);
            [DllImport("opengl32", EntryPoint = "glEvalCoord2dv")]
            public static extern void glEvalCoord2dv_(IntPtr u);
            [DllImport("opengl32", EntryPoint = "glEvalCoord2f")]
            public static extern void glEvalCoord2f(GLfloat u, GLfloat v);
            [DllImport("opengl32", EntryPoint = "glEvalCoord2fv")]
            public static extern void glEvalCoord2fv_(IntPtr u);
            [DllImport("opengl32", EntryPoint = "glEvalMesh1")]
            public static extern void glEvalMesh1(GLenum mode, GLint i1, GLint i2);
            [DllImport("opengl32", EntryPoint = "glEvalPoint1")]
            public static extern void glEvalPoint1(GLint i);
            [DllImport("opengl32", EntryPoint = "glEvalMesh2")]
            public static extern void glEvalMesh2(GLenum mode, GLint i1, GLint i2, GLint j1, GLint j2);
            [DllImport("opengl32", EntryPoint = "glEvalPoint2")]
            public static extern void glEvalPoint2(GLint i, GLint j);
            [DllImport("opengl32", EntryPoint = "glAlphaFunc")]
            public static extern void glAlphaFunc(GLenum func, GLclampf reference);
            [DllImport("opengl32", EntryPoint = "glBlendFunc")]
            public static extern void glBlendFunc(GLenum sfactor, GLenum dfactor);
            [DllImport("opengl32", EntryPoint = "glLogicOp")]
            public static extern void glLogicOp(GLenum opcode);
            [DllImport("opengl32", EntryPoint = "glStencilFunc")]
            public static extern void glStencilFunc(GLenum func, GLint reference, GLuint mask);
            [DllImport("opengl32", EntryPoint = "glStencilOp")]
            public static extern void glStencilOp(GLenum fail, GLenum zfail, GLenum zpass);
            [DllImport("opengl32", EntryPoint = "glDepthFunc")]
            public static extern void glDepthFunc(GLenum func);
            [DllImport("opengl32", EntryPoint = "glPixelZoom")]
            public static extern void glPixelZoom(GLfloat xfactor, GLfloat yfactor);
            [DllImport("opengl32", EntryPoint = "glPixelTransferf")]
            public static extern void glPixelTransferf(GLenum pname, GLfloat param);
            [DllImport("opengl32", EntryPoint = "glPixelTransferi")]
            public static extern void glPixelTransferi(GLenum pname, GLint param);
            [DllImport("opengl32", EntryPoint = "glPixelStoref")]
            public static extern void glPixelStoref(GLenum pname, GLfloat param);
            [DllImport("opengl32", EntryPoint = "glPixelStorei")]
            public static extern void glPixelStorei(GLenum pname, GLint param);
            [DllImport("opengl32", EntryPoint = "glPixelMapfv")]
            public static extern void glPixelMapfv_(GLenum map, GLint mapsize, IntPtr values);
            [DllImport("opengl32", EntryPoint = "glPixelMapuiv")]
            public static extern void glPixelMapuiv_(GLenum map, GLint mapsize, IntPtr values);
            [DllImport("opengl32", EntryPoint = "glPixelMapusv")]
            public static extern void glPixelMapusv_(GLenum map, GLint mapsize, IntPtr values);
            [DllImport("opengl32", EntryPoint = "glReadBuffer")]
            public static extern void glReadBuffer(GLenum mode);
            [DllImport("opengl32", EntryPoint = "glCopyPixels")]
            public static extern void glCopyPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum type);
            [DllImport("opengl32", EntryPoint = "glReadPixels")]
            public static extern void glReadPixels_(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);
            [DllImport("opengl32", EntryPoint = "glDrawPixels")]
            public static extern void glDrawPixels_(GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);
            [DllImport("opengl32", EntryPoint = "glGetBooleanv")]
            public static extern void glGetBooleanv(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLboolean[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetClipPlane")]
            public static extern void glGetClipPlane(GLenum plane, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] equation);
            [DllImport("opengl32", EntryPoint = "glGetDoublev")]
            public static extern void glGetDoublev(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetError")]
            public static extern GLenum glGetError();
            [DllImport("opengl32", EntryPoint = "glGetFloatv")]
            public static extern void glGetFloatv(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetIntegerv")]
            public static extern void glGetIntegerv(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetLightfv")]
            public static extern void glGetLightfv(GLenum light, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetLightiv")]
            public static extern void glGetLightiv(GLenum light, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetMapdv")]
            public static extern void glGetMapdv(GLenum target, GLenum query, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] v);
            [DllImport("opengl32", EntryPoint = "glGetMapfv")]
            public static extern void glGetMapfv(GLenum target, GLenum query, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] v);
            [DllImport("opengl32", EntryPoint = "glGetMapiv")]
            public static extern void glGetMapiv(GLenum target, GLenum query, [MarshalAs(UnmanagedType.LPArray)] GLint[] v);
            [DllImport("opengl32", EntryPoint = "glGetMaterialfv")]
            public static extern void glGetMaterialfv(GLenum face, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetMaterialiv")]
            public static extern void glGetMaterialiv(GLenum face, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetPixelMapfv")]
            public static extern void glGetPixelMapfv(GLenum map, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] values);
            [DllImport("opengl32", EntryPoint = "glGetPixelMapuiv")]
            public static extern void glGetPixelMapuiv(GLenum map, [MarshalAs(UnmanagedType.LPArray)] GLuint[] values);
            [DllImport("opengl32", EntryPoint = "glGetPixelMapusv")]
            public static extern void glGetPixelMapusv(GLenum map, [MarshalAs(UnmanagedType.LPArray)] GLushort[] values);
            [DllImport("opengl32", EntryPoint = "glGetPolygonStipple")]
            public static extern void glGetPolygonStipple([MarshalAs(UnmanagedType.LPArray)] GLubyte[] mask);
            [DllImport("opengl32", EntryPoint = "glGetString")]
            public static extern IntPtr glGetString_(GLenum name);
            [DllImport("opengl32", EntryPoint = "glGetTexEnvfv")]
            public static extern void glGetTexEnvfv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetTexEnviv")]
            public static extern void glGetTexEnviv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetTexGendv")]
            public static extern void glGetTexGendv(GLenum coord, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetTexGenfv")]
            public static extern void glGetTexGenfv(GLenum coord, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetTexGeniv")]
            public static extern void glGetTexGeniv(GLenum coord, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetTexImage")]
            public static extern void glGetTexImage_(GLenum target, GLint level, GLenum format, GLenum type, IntPtr pixels);
            [DllImport("opengl32", EntryPoint = "glGetTexParameterfv")]
            public static extern void glGetTexParameterfv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetTexParameteriv")]
            public static extern void glGetTexParameteriv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetTexLevelParameterfv")]
            public static extern void glGetTexLevelParameterfv(GLenum target, GLint level, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetTexLevelParameteriv")]
            public static extern void glGetTexLevelParameteriv(GLenum target, GLint level, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glIsEnabled")]
            public static extern GLboolean glIsEnabled(GLenum cap);
            [DllImport("opengl32", EntryPoint = "glIsList")]
            public static extern GLboolean glIsList(GLuint list);
            [DllImport("opengl32", EntryPoint = "glDepthRange")]
            public static extern void glDepthRange(GLclampd near, GLclampd far);
            [DllImport("opengl32", EntryPoint = "glFrustum")]
            public static extern void glFrustum(GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble zNear, GLdouble zFar);
            [DllImport("opengl32", EntryPoint = "glLoadIdentity")]
            public static extern void glLoadIdentity();
            [DllImport("opengl32", EntryPoint = "glLoadMatrixf")]
            public static extern void glLoadMatrixf_(IntPtr m);
            [DllImport("opengl32", EntryPoint = "glLoadMatrixd")]
            public static extern void glLoadMatrixd_(IntPtr m);
            [DllImport("opengl32", EntryPoint = "glMatrixMode")]
            public static extern void glMatrixMode(GLenum mode);
            [DllImport("opengl32", EntryPoint = "glMultMatrixf")]
            public static extern void glMultMatrixf_(IntPtr m);
            [DllImport("opengl32", EntryPoint = "glMultMatrixd")]
            public static extern void glMultMatrixd_(IntPtr m);
            [DllImport("opengl32", EntryPoint = "glOrtho")]
            public static extern void glOrtho(GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble zNear, GLdouble zFar);
            [DllImport("opengl32", EntryPoint = "glPopMatrix")]
            public static extern void glPopMatrix();
            [DllImport("opengl32", EntryPoint = "glPushMatrix")]
            public static extern void glPushMatrix();
            [DllImport("opengl32", EntryPoint = "glRotated")]
            public static extern void glRotated(GLdouble angle, GLdouble x, GLdouble y, GLdouble z);
            [DllImport("opengl32", EntryPoint = "glRotatef")]
            public static extern void glRotatef(GLfloat angle, GLfloat x, GLfloat y, GLfloat z);
            [DllImport("opengl32", EntryPoint = "glScaled")]
            public static extern void glScaled(GLdouble x, GLdouble y, GLdouble z);
            [DllImport("opengl32", EntryPoint = "glScalef")]
            public static extern void glScalef(GLfloat x, GLfloat y, GLfloat z);
            [DllImport("opengl32", EntryPoint = "glTranslated")]
            public static extern void glTranslated(GLdouble x, GLdouble y, GLdouble z);
            [DllImport("opengl32", EntryPoint = "glTranslatef")]
            public static extern void glTranslatef(GLfloat x, GLfloat y, GLfloat z);
            [DllImport("opengl32", EntryPoint = "glViewport")]
            public static extern void glViewport(GLint x, GLint y, GLsizei width, GLsizei height);
            [DllImport("opengl32", EntryPoint = "glArrayElement")]
            public static extern void glArrayElement(GLint i);
            [DllImport("opengl32", EntryPoint = "glColorPointer")]
            public static extern void glColorPointer_(GLint size, GLenum type, GLsizei stride, IntPtr pointer);
            [DllImport("opengl32", EntryPoint = "glDisableClientState")]
            public static extern void glDisableClientState(GLenum array);
            [DllImport("opengl32", EntryPoint = "glDrawArrays")]
            public static extern void glDrawArrays(GLenum mode, GLint first, GLsizei count);
            [DllImport("opengl32", EntryPoint = "glDrawElements")]
            public static extern void glDrawElements_(GLenum mode, GLsizei count, GLenum type, IntPtr indices);
            [DllImport("opengl32", EntryPoint = "glEdgeFlagPointer")]
            public static extern void glEdgeFlagPointer_(GLsizei stride, IntPtr pointer);
            [DllImport("opengl32", EntryPoint = "glEnableClientState")]
            public static extern void glEnableClientState(GLenum array);
            [DllImport("opengl32", EntryPoint = "glGetPointerv")]
            public static extern void glGetPointerv(GLenum pname, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] parameters);
            [DllImport("opengl32", EntryPoint = "glIndexPointer")]
            public static extern void glIndexPointer_(GLenum type, GLsizei stride, IntPtr pointer);
            [DllImport("opengl32", EntryPoint = "glInterleavedArrays")]
            public static extern void glInterleavedArrays_(GLenum format, GLsizei stride, IntPtr pointer);
            [DllImport("opengl32", EntryPoint = "glNormalPointer")]
            public static extern void glNormalPointer_(GLenum type, GLsizei stride, IntPtr pointer);
            [DllImport("opengl32", EntryPoint = "glTexCoordPointer")]
            public static extern void glTexCoordPointer_(GLint size, GLenum type, GLsizei stride, IntPtr pointer);
            [DllImport("opengl32", EntryPoint = "glVertexPointer")]
            public static extern void glVertexPointer_(GLint size, GLenum type, GLsizei stride, IntPtr pointer);
            [DllImport("opengl32", EntryPoint = "glPolygonOffset")]
            public static extern void glPolygonOffset(GLfloat factor, GLfloat units);
            [DllImport("opengl32", EntryPoint = "glCopyTexImage1D")]
            public static extern void glCopyTexImage1D(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLint border);
            [DllImport("opengl32", EntryPoint = "glCopyTexImage2D")]
            public static extern void glCopyTexImage2D(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border);
            [DllImport("opengl32", EntryPoint = "glCopyTexSubImage1D")]
            public static extern void glCopyTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);
            [DllImport("opengl32", EntryPoint = "glCopyTexSubImage2D")]
            public static extern void glCopyTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);
            [DllImport("opengl32", EntryPoint = "glTexSubImage1D")]
            public static extern void glTexSubImage1D_(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, IntPtr pixels);
            [DllImport("opengl32", EntryPoint = "glTexSubImage2D")]
            public static extern void glTexSubImage2D_(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);
            [DllImport("opengl32", EntryPoint = "glAreTexturesResident")]
            public static extern GLboolean glAreTexturesResident_(GLsizei n, IntPtr textures, [MarshalAs(UnmanagedType.LPArray)] GLboolean[] residences);
            [DllImport("opengl32", EntryPoint = "glBindTexture")]
            public static extern void glBindTexture(GLenum target, GLuint texture);
            [DllImport("opengl32", EntryPoint = "glDeleteTextures")]
            public static extern void glDeleteTextures_(GLsizei n, IntPtr textures);
            [DllImport("opengl32", EntryPoint = "glGenTextures")]
            public static extern void glGenTextures(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] textures);
            [DllImport("opengl32", EntryPoint = "glIsTexture")]
            public static extern GLboolean glIsTexture(GLuint texture);
            [DllImport("opengl32", EntryPoint = "glPrioritizeTextures")]
            public static extern void glPrioritizeTextures_(GLsizei n, IntPtr textures, IntPtr priorities);
            [DllImport("opengl32", EntryPoint = "glIndexub")]
            public static extern void glIndexub(GLubyte c);
            [DllImport("opengl32", EntryPoint = "glIndexubv")]
            public static extern void glIndexubv_(IntPtr c);
            [DllImport("opengl32", EntryPoint = "glPopClientAttrib")]
            public static extern void glPopClientAttrib();
            [DllImport("opengl32", EntryPoint = "glPushClientAttrib")]
            public static extern void glPushClientAttrib(GLbitfield mask);
            [DllImport("opengl32", EntryPoint = "glBlendColor")]
            public static extern void glBlendColor(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);
            [DllImport("opengl32", EntryPoint = "glBlendEquation")]
            public static extern void glBlendEquation(GLenum mode);
            [DllImport("opengl32", EntryPoint = "glDrawRangeElements")]
            public static extern void glDrawRangeElements_(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, IntPtr indices);
            [DllImport("opengl32", EntryPoint = "glColorTable")]
            public static extern void glColorTable_(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr table);
            [DllImport("opengl32", EntryPoint = "glColorTableParameterfv")]
            public static extern void glColorTableParameterfv_(GLenum target, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glColorTableParameteriv")]
            public static extern void glColorTableParameteriv_(GLenum target, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glCopyColorTable")]
            public static extern void glCopyColorTable(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);
            [DllImport("opengl32", EntryPoint = "glGetColorTable")]
            public static extern void glGetColorTable_(GLenum target, GLenum format, GLenum type, IntPtr table);
            [DllImport("opengl32", EntryPoint = "glGetColorTableParameterfv")]
            public static extern void glGetColorTableParameterfv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetColorTableParameteriv")]
            public static extern void glGetColorTableParameteriv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glColorSubTable")]
            public static extern void glColorSubTable_(GLenum target, GLsizei start, GLsizei count, GLenum format, GLenum type, IntPtr data);
            [DllImport("opengl32", EntryPoint = "glCopyColorSubTable")]
            public static extern void glCopyColorSubTable(GLenum target, GLsizei start, GLint x, GLint y, GLsizei width);
            [DllImport("opengl32", EntryPoint = "glConvolutionFilter1D")]
            public static extern void glConvolutionFilter1D_(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr image);
            [DllImport("opengl32", EntryPoint = "glConvolutionFilter2D")]
            public static extern void glConvolutionFilter2D_(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr image);
            [DllImport("opengl32", EntryPoint = "glConvolutionParameterf")]
            public static extern void glConvolutionParameterf(GLenum target, GLenum pname, GLfloat parameters);
            [DllImport("opengl32", EntryPoint = "glConvolutionParameterfv")]
            public static extern void glConvolutionParameterfv_(GLenum target, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glConvolutionParameteri")]
            public static extern void glConvolutionParameteri(GLenum target, GLenum pname, GLint parameters);
            [DllImport("opengl32", EntryPoint = "glConvolutionParameteriv")]
            public static extern void glConvolutionParameteriv_(GLenum target, GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glCopyConvolutionFilter1D")]
            public static extern void glCopyConvolutionFilter1D(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);
            [DllImport("opengl32", EntryPoint = "glCopyConvolutionFilter2D")]
            public static extern void glCopyConvolutionFilter2D(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height);
            [DllImport("opengl32", EntryPoint = "glGetConvolutionFilter")]
            public static extern void glGetConvolutionFilter_(GLenum target, GLenum format, GLenum type, IntPtr image);
            [DllImport("opengl32", EntryPoint = "glGetConvolutionParameterfv")]
            public static extern void glGetConvolutionParameterfv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetConvolutionParameteriv")]
            public static extern void glGetConvolutionParameteriv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetSeparableFilter")]
            public static extern void glGetSeparableFilter_(GLenum target, GLenum format, GLenum type, IntPtr row, IntPtr column, IntPtr span);
            [DllImport("opengl32", EntryPoint = "glSeparableFilter2D")]
            public static extern void glSeparableFilter2D_(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr row, IntPtr column);
            [DllImport("opengl32", EntryPoint = "glGetHistogram")]
            public static extern void glGetHistogram_(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values);
            [DllImport("opengl32", EntryPoint = "glGetHistogramParameterfv")]
            public static extern void glGetHistogramParameterfv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetHistogramParameteriv")]
            public static extern void glGetHistogramParameteriv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetMinmax")]
            public static extern void glGetMinmax_(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values);
            [DllImport("opengl32", EntryPoint = "glGetMinmaxParameterfv")]
            public static extern void glGetMinmaxParameterfv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetMinmaxParameteriv")]
            public static extern void glGetMinmaxParameteriv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glHistogram")]
            public static extern void glHistogram(GLenum target, GLsizei width, GLenum internalformat, GLboolean sink);
            [DllImport("opengl32", EntryPoint = "glMinmax")]
            public static extern void glMinmax(GLenum target, GLenum internalformat, GLboolean sink);
            [DllImport("opengl32", EntryPoint = "glResetHistogram")]
            public static extern void glResetHistogram(GLenum target);
            [DllImport("opengl32", EntryPoint = "glResetMinmax")]
            public static extern void glResetMinmax(GLenum target);
            [DllImport("opengl32", EntryPoint = "glTexImage3D")]
            public static extern void glTexImage3D_(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, IntPtr pixels);
            [DllImport("opengl32", EntryPoint = "glTexSubImage3D")]
            public static extern void glTexSubImage3D_(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr pixels);
            [DllImport("opengl32", EntryPoint = "glCopyTexSubImage3D")]
            public static extern void glCopyTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);
            [DllImport("opengl32", EntryPoint = "glActiveTexture")]
            public static extern void glActiveTexture(GLenum texture);
            [DllImport("opengl32", EntryPoint = "glClientActiveTexture")]
            public static extern void glClientActiveTexture(GLenum texture);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord1d")]
            public static extern void glMultiTexCoord1d(GLenum target, GLdouble s);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord1dv")]
            public static extern void glMultiTexCoord1dv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord1f")]
            public static extern void glMultiTexCoord1f(GLenum target, GLfloat s);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord1fv")]
            public static extern void glMultiTexCoord1fv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord1i")]
            public static extern void glMultiTexCoord1i(GLenum target, GLint s);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord1iv")]
            public static extern void glMultiTexCoord1iv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord1s")]
            public static extern void glMultiTexCoord1s(GLenum target, GLshort s);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord1sv")]
            public static extern void glMultiTexCoord1sv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord2d")]
            public static extern void glMultiTexCoord2d(GLenum target, GLdouble s, GLdouble t);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord2dv")]
            public static extern void glMultiTexCoord2dv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord2f")]
            public static extern void glMultiTexCoord2f(GLenum target, GLfloat s, GLfloat t);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord2fv")]
            public static extern void glMultiTexCoord2fv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord2i")]
            public static extern void glMultiTexCoord2i(GLenum target, GLint s, GLint t);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord2iv")]
            public static extern void glMultiTexCoord2iv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord2s")]
            public static extern void glMultiTexCoord2s(GLenum target, GLshort s, GLshort t);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord2sv")]
            public static extern void glMultiTexCoord2sv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord3d")]
            public static extern void glMultiTexCoord3d(GLenum target, GLdouble s, GLdouble t, GLdouble r);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord3dv")]
            public static extern void glMultiTexCoord3dv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord3f")]
            public static extern void glMultiTexCoord3f(GLenum target, GLfloat s, GLfloat t, GLfloat r);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord3fv")]
            public static extern void glMultiTexCoord3fv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord3i")]
            public static extern void glMultiTexCoord3i(GLenum target, GLint s, GLint t, GLint r);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord3iv")]
            public static extern void glMultiTexCoord3iv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord3s")]
            public static extern void glMultiTexCoord3s(GLenum target, GLshort s, GLshort t, GLshort r);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord3sv")]
            public static extern void glMultiTexCoord3sv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord4d")]
            public static extern void glMultiTexCoord4d(GLenum target, GLdouble s, GLdouble t, GLdouble r, GLdouble q);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord4dv")]
            public static extern void glMultiTexCoord4dv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord4f")]
            public static extern void glMultiTexCoord4f(GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord4fv")]
            public static extern void glMultiTexCoord4fv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord4i")]
            public static extern void glMultiTexCoord4i(GLenum target, GLint s, GLint t, GLint r, GLint q);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord4iv")]
            public static extern void glMultiTexCoord4iv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord4s")]
            public static extern void glMultiTexCoord4s(GLenum target, GLshort s, GLshort t, GLshort r, GLshort q);
            [DllImport("opengl32", EntryPoint = "glMultiTexCoord4sv")]
            public static extern void glMultiTexCoord4sv_(GLenum target, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glLoadTransposeMatrixf")]
            public static extern void glLoadTransposeMatrixf_(IntPtr m);
            [DllImport("opengl32", EntryPoint = "glLoadTransposeMatrixd")]
            public static extern void glLoadTransposeMatrixd_(IntPtr m);
            [DllImport("opengl32", EntryPoint = "glMultTransposeMatrixf")]
            public static extern void glMultTransposeMatrixf_(IntPtr m);
            [DllImport("opengl32", EntryPoint = "glMultTransposeMatrixd")]
            public static extern void glMultTransposeMatrixd_(IntPtr m);
            [DllImport("opengl32", EntryPoint = "glSampleCoverage")]
            public static extern void glSampleCoverage(GLclampf value, GLboolean invert);
            [DllImport("opengl32", EntryPoint = "glCompressedTexImage3D")]
            public static extern void glCompressedTexImage3D_(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, IntPtr data);
            [DllImport("opengl32", EntryPoint = "glCompressedTexImage2D")]
            public static extern void glCompressedTexImage2D_(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, IntPtr data);
            [DllImport("opengl32", EntryPoint = "glCompressedTexImage1D")]
            public static extern void glCompressedTexImage1D_(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, IntPtr data);
            [DllImport("opengl32", EntryPoint = "glCompressedTexSubImage3D")]
            public static extern void glCompressedTexSubImage3D_(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, IntPtr data);
            [DllImport("opengl32", EntryPoint = "glCompressedTexSubImage2D")]
            public static extern void glCompressedTexSubImage2D_(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, IntPtr data);
            [DllImport("opengl32", EntryPoint = "glCompressedTexSubImage1D")]
            public static extern void glCompressedTexSubImage1D_(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, IntPtr data);
            [DllImport("opengl32", EntryPoint = "glGetCompressedTexImage")]
            public static extern void glGetCompressedTexImage_(GLenum target, GLint level, IntPtr img);
            [DllImport("opengl32", EntryPoint = "glBlendFuncSeparate")]
            public static extern void glBlendFuncSeparate(GLenum sfactorRGB, GLenum dfactorRGB, GLenum sfactorAlpha, GLenum dfactorAlpha);
            [DllImport("opengl32", EntryPoint = "glFogCoordf")]
            public static extern void glFogCoordf(GLfloat coord);
            [DllImport("opengl32", EntryPoint = "glFogCoordfv")]
            public static extern void glFogCoordfv_(IntPtr coord);
            [DllImport("opengl32", EntryPoint = "glFogCoordd")]
            public static extern void glFogCoordd(GLdouble coord);
            [DllImport("opengl32", EntryPoint = "glFogCoorddv")]
            public static extern void glFogCoorddv_(IntPtr coord);
            [DllImport("opengl32", EntryPoint = "glFogCoordPointer")]
            public static extern void glFogCoordPointer_(GLenum type, GLsizei stride, IntPtr pointer);
            [DllImport("opengl32", EntryPoint = "glMultiDrawArrays")]
            public static extern void glMultiDrawArrays(GLenum mode, [MarshalAs(UnmanagedType.LPArray)] GLint[] first, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] count, GLsizei primcount);
            [DllImport("opengl32", EntryPoint = "glMultiDrawElements")]
            public static extern void glMultiDrawElements_(GLenum mode, IntPtr count, GLenum type, IntPtr indices, GLsizei primcount);
            [DllImport("opengl32", EntryPoint = "glPointParameterf")]
            public static extern void glPointParameterf(GLenum pname, GLfloat param);
            [DllImport("opengl32", EntryPoint = "glPointParameterfv")]
            public static extern void glPointParameterfv_(GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glPointParameteri")]
            public static extern void glPointParameteri(GLenum pname, GLint param);
            [DllImport("opengl32", EntryPoint = "glPointParameteriv")]
            public static extern void glPointParameteriv_(GLenum pname, IntPtr parameters);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3b")]
            public static extern void glSecondaryColor3b(GLbyte red, GLbyte green, GLbyte blue);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3bv")]
            public static extern void glSecondaryColor3bv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3d")]
            public static extern void glSecondaryColor3d(GLdouble red, GLdouble green, GLdouble blue);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3dv")]
            public static extern void glSecondaryColor3dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3f")]
            public static extern void glSecondaryColor3f(GLfloat red, GLfloat green, GLfloat blue);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3fv")]
            public static extern void glSecondaryColor3fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3i")]
            public static extern void glSecondaryColor3i(GLint red, GLint green, GLint blue);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3iv")]
            public static extern void glSecondaryColor3iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3s")]
            public static extern void glSecondaryColor3s(GLshort red, GLshort green, GLshort blue);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3sv")]
            public static extern void glSecondaryColor3sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3ub")]
            public static extern void glSecondaryColor3ub(GLubyte red, GLubyte green, GLubyte blue);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3ubv")]
            public static extern void glSecondaryColor3ubv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3ui")]
            public static extern void glSecondaryColor3ui(GLuint red, GLuint green, GLuint blue);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3uiv")]
            public static extern void glSecondaryColor3uiv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3us")]
            public static extern void glSecondaryColor3us(GLushort red, GLushort green, GLushort blue);
            [DllImport("opengl32", EntryPoint = "glSecondaryColor3usv")]
            public static extern void glSecondaryColor3usv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glSecondaryColorPointer")]
            public static extern void glSecondaryColorPointer_(GLint size, GLenum type, GLsizei stride, IntPtr pointer);
            [DllImport("opengl32", EntryPoint = "glWindowPos2d")]
            public static extern void glWindowPos2d(GLdouble x, GLdouble y);
            [DllImport("opengl32", EntryPoint = "glWindowPos2dv")]
            public static extern void glWindowPos2dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glWindowPos2f")]
            public static extern void glWindowPos2f(GLfloat x, GLfloat y);
            [DllImport("opengl32", EntryPoint = "glWindowPos2fv")]
            public static extern void glWindowPos2fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glWindowPos2i")]
            public static extern void glWindowPos2i(GLint x, GLint y);
            [DllImport("opengl32", EntryPoint = "glWindowPos2iv")]
            public static extern void glWindowPos2iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glWindowPos2s")]
            public static extern void glWindowPos2s(GLshort x, GLshort y);
            [DllImport("opengl32", EntryPoint = "glWindowPos2sv")]
            public static extern void glWindowPos2sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glWindowPos3d")]
            public static extern void glWindowPos3d(GLdouble x, GLdouble y, GLdouble z);
            [DllImport("opengl32", EntryPoint = "glWindowPos3dv")]
            public static extern void glWindowPos3dv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glWindowPos3f")]
            public static extern void glWindowPos3f(GLfloat x, GLfloat y, GLfloat z);
            [DllImport("opengl32", EntryPoint = "glWindowPos3fv")]
            public static extern void glWindowPos3fv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glWindowPos3i")]
            public static extern void glWindowPos3i(GLint x, GLint y, GLint z);
            [DllImport("opengl32", EntryPoint = "glWindowPos3iv")]
            public static extern void glWindowPos3iv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glWindowPos3s")]
            public static extern void glWindowPos3s(GLshort x, GLshort y, GLshort z);
            [DllImport("opengl32", EntryPoint = "glWindowPos3sv")]
            public static extern void glWindowPos3sv_(IntPtr v);
            [DllImport("opengl32", EntryPoint = "glGenQueries")]
            public static extern void glGenQueries(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] ids);
            [DllImport("opengl32", EntryPoint = "glDeleteQueries")]
            public static extern void glDeleteQueries_(GLsizei n, IntPtr ids);
            [DllImport("opengl32", EntryPoint = "glIsQuery")]
            public static extern GLboolean glIsQuery(GLuint id);
            [DllImport("opengl32", EntryPoint = "glBeginQuery")]
            public static extern void glBeginQuery(GLenum target, GLuint id);
            [DllImport("opengl32", EntryPoint = "glEndQuery")]
            public static extern void glEndQuery(GLenum target);
            [DllImport("opengl32", EntryPoint = "glGetQueryiv")]
            public static extern void glGetQueryiv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetQueryObjectiv")]
            public static extern void glGetQueryObjectiv(GLuint id, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetQueryObjectuiv")]
            public static extern void glGetQueryObjectuiv(GLuint id, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLuint[] parameters);
            [DllImport("opengl32", EntryPoint = "glBindBuffer")]
            public static extern void glBindBuffer(GLenum target, GLuint buffer);
            [DllImport("opengl32", EntryPoint = "glDeleteBuffers")]
            public static extern void glDeleteBuffers_(GLsizei n, IntPtr buffers);
            [DllImport("opengl32", EntryPoint = "glGenBuffers")]
            public static extern void glGenBuffers(GLsizei n, [MarshalAs(UnmanagedType.LPArray)] GLuint[] buffers);
            [DllImport("opengl32", EntryPoint = "glIsBuffer")]
            public static extern GLboolean glIsBuffer(GLuint buffer);
            [DllImport("opengl32", EntryPoint = "glBufferData")]
            public static extern void glBufferData_(GLenum target, GLsizeiptr size, IntPtr data, GLenum usage);
            [DllImport("opengl32", EntryPoint = "glBufferSubData")]
            public static extern void glBufferSubData_(GLenum target, GLintptr offset, GLsizeiptr size, IntPtr data);
            [DllImport("opengl32", EntryPoint = "glGetBufferSubData")]
            public static extern void glGetBufferSubData_(GLenum target, GLintptr offset, GLsizeiptr size, IntPtr data);
            [DllImport("opengl32", EntryPoint = "glMapBuffer")]
            public static extern IntPtr glMapBuffer(GLenum target, GLenum access);
            [DllImport("opengl32", EntryPoint = "glUnmapBuffer")]
            public static extern GLboolean glUnmapBuffer(GLenum target);
            [DllImport("opengl32", EntryPoint = "glGetBufferParameteriv")]
            public static extern void glGetBufferParameteriv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetBufferPointerv")]
            public static extern void glGetBufferPointerv(GLenum target, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] parameters);
            [DllImport("opengl32", EntryPoint = "glBlendEquationSeparate")]
            public static extern void glBlendEquationSeparate(GLenum modeRGB, GLenum modeAlpha);
            [DllImport("opengl32", EntryPoint = "glDrawBuffers")]
            public static extern void glDrawBuffers_(GLsizei n, IntPtr bufs);
            [DllImport("opengl32", EntryPoint = "glStencilOpSeparate")]
            public static extern void glStencilOpSeparate(GLenum face, GLenum sfail, GLenum dpfail, GLenum dppass);
            [DllImport("opengl32", EntryPoint = "glStencilFuncSeparate")]
            public static extern void glStencilFuncSeparate(GLenum frontfunc, GLenum backfunc, GLint reference, GLuint mask);
            [DllImport("opengl32", EntryPoint = "glStencilMaskSeparate")]
            public static extern void glStencilMaskSeparate(GLenum face, GLuint mask);
            [DllImport("opengl32", EntryPoint = "glAttachShader")]
            public static extern void glAttachShader(GLuint program, GLuint shader);
            [DllImport("opengl32", EntryPoint = "glBindAttribLocation")]
            public static extern void glBindAttribLocation_(GLuint program, GLuint index, IntPtr name);
            [DllImport("opengl32", EntryPoint = "glCompileShader")]
            public static extern void glCompileShader(GLuint shader);
            [DllImport("opengl32", EntryPoint = "glCreateProgram")]
            public static extern GLuint glCreateProgram();
            [DllImport("opengl32", EntryPoint = "glCreateShader")]
            public static extern GLuint glCreateShader(GLenum type);
            [DllImport("opengl32", EntryPoint = "glDeleteProgram")]
            public static extern void glDeleteProgram(GLuint program);
            [DllImport("opengl32", EntryPoint = "glDeleteShader")]
            public static extern void glDeleteShader(GLuint shader);
            [DllImport("opengl32", EntryPoint = "glDetachShader")]
            public static extern void glDetachShader(GLuint program, GLuint shader);
            [DllImport("opengl32", EntryPoint = "glDisableVertexAttribArray")]
            public static extern void glDisableVertexAttribArray(GLuint index);
            [DllImport("opengl32", EntryPoint = "glEnableVertexAttribArray")]
            public static extern void glEnableVertexAttribArray(GLuint index);
            [DllImport("opengl32", EntryPoint = "glGetActiveAttrib")]
            public static extern void glGetActiveAttrib(GLuint program, GLuint index, GLsizei bufSize, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLint[] size, [MarshalAs(UnmanagedType.LPArray)] GLenum[] type, [MarshalAs(UnmanagedType.LPArray)] GLchar[] name);
            [DllImport("opengl32", EntryPoint = "glGetActiveUniform")]
            public static extern void glGetActiveUniform(GLuint program, GLuint index, GLsizei bufSize, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLint[] size, [MarshalAs(UnmanagedType.LPArray)] GLenum[] type, [MarshalAs(UnmanagedType.LPArray)] GLchar[] name);
            [DllImport("opengl32", EntryPoint = "glGetAttachedShaders")]
            public static extern void glGetAttachedShaders(GLuint program, GLsizei maxCount, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] count, [MarshalAs(UnmanagedType.LPArray)] GLuint[] obj);
            [DllImport("opengl32", EntryPoint = "glGetAttribLocation")]
            public static extern GLint glGetAttribLocation_(GLuint program, IntPtr name);
            [DllImport("opengl32", EntryPoint = "glGetProgramiv")]
            public static extern void glGetProgramiv(GLuint program, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetProgramInfoLog")]
            public static extern void glGetProgramInfoLog(GLuint program, GLsizei bufSize, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLchar[] infoLog);
            [DllImport("opengl32", EntryPoint = "glGetShaderiv")]
            public static extern void glGetShaderiv(GLuint shader, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetShaderInfoLog")]
            public static extern void glGetShaderInfoLog(GLuint shader, GLsizei bufSize, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLchar[] infoLog);
            [DllImport("opengl32", EntryPoint = "glGetShaderSource")]
            public static extern void glGetShaderSource(GLuint shader, GLsizei bufSize, [MarshalAs(UnmanagedType.LPArray)] GLsizei[] length, [MarshalAs(UnmanagedType.LPArray)] GLchar[] source);
            [DllImport("opengl32", EntryPoint = "glGetUniformLocation")]
            public static extern GLint glGetUniformLocation_(GLuint program, IntPtr name);
            [DllImport("opengl32", EntryPoint = "glGetUniformfv")]
            public static extern void glGetUniformfv(GLuint program, GLint location, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetUniformiv")]
            public static extern void glGetUniformiv(GLuint program, GLint location, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetVertexAttribdv")]
            public static extern void glGetVertexAttribdv(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLdouble[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetVertexAttribfv")]
            public static extern void glGetVertexAttribfv(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLfloat[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetVertexAttribiv")]
            public static extern void glGetVertexAttribiv(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] GLint[] parameters);
            [DllImport("opengl32", EntryPoint = "glGetVertexAttribPointerv")]
            public static extern void glGetVertexAttribPointerv(GLuint index, GLenum pname, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] pointer);
            [DllImport("opengl32", EntryPoint = "glIsProgram")]
            public static extern GLboolean glIsProgram(GLuint program);
            [DllImport("opengl32", EntryPoint = "glIsShader")]
            public static extern GLboolean glIsShader(GLuint shader);
            [DllImport("opengl32", EntryPoint = "glLinkProgram")]
            public static extern void glLinkProgram(GLuint program);
            [DllImport("opengl32", EntryPoint = "glShaderSource")]
            public static extern void glShaderSource_(GLuint shader, GLsizei count, string[] @string, IntPtr length);
            [DllImport("opengl32", EntryPoint = "glUseProgram")]
            public static extern void glUseProgram(GLuint program);
            [DllImport("opengl32", EntryPoint = "glUniform1f")]
            public static extern void glUniform1f(GLint location, GLfloat v0);
            [DllImport("opengl32", EntryPoint = "glUniform2f")]
            public static extern void glUniform2f(GLint location, GLfloat v0, GLfloat v1);
            [DllImport("opengl32", EntryPoint = "glUniform3f")]
            public static extern void glUniform3f(GLint location, GLfloat v0, GLfloat v1, GLfloat v2);
            [DllImport("opengl32", EntryPoint = "glUniform4f")]
            public static extern void glUniform4f(GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);
            [DllImport("opengl32", EntryPoint = "glUniform1i")]
            public static extern void glUniform1i(GLint location, GLint v0);
            [DllImport("opengl32", EntryPoint = "glUniform2i")]
            public static extern void glUniform2i(GLint location, GLint v0, GLint v1);
            [DllImport("opengl32", EntryPoint = "glUniform3i")]
            public static extern void glUniform3i(GLint location, GLint v0, GLint v1, GLint v2);
            [DllImport("opengl32", EntryPoint = "glUniform4i")]
            public static extern void glUniform4i(GLint location, GLint v0, GLint v1, GLint v2, GLint v3);
            [DllImport("opengl32", EntryPoint = "glUniform1fv")]
            public static extern void glUniform1fv_(GLint location, GLsizei count, IntPtr value);
            [DllImport("opengl32", EntryPoint = "glUniform2fv")]
            public static extern void glUniform2fv_(GLint location, GLsizei count, IntPtr value);
            [DllImport("opengl32", EntryPoint = "glUniform3fv")]
            public static extern void glUniform3fv_(GLint location, GLsizei count, IntPtr value);
            [DllImport("opengl32", EntryPoint = "glUniform4fv")]
            public static extern void glUniform4fv_(GLint location, GLsizei count, IntPtr value);
            [DllImport("opengl32", EntryPoint = "glUniform1iv")]
            public static extern void glUniform1iv_(GLint location, GLsizei count, IntPtr value);
            [DllImport("opengl32", EntryPoint = "glUniform2iv")]
            public static extern void glUniform2iv_(GLint location, GLsizei count, IntPtr value);
            [DllImport("opengl32", EntryPoint = "glUniform3iv")]
            public static extern void glUniform3iv_(GLint location, GLsizei count, IntPtr value);
            [DllImport("opengl32", EntryPoint = "glUniform4iv")]
            public static extern void glUniform4iv_(GLint location, GLsizei count, IntPtr value);
            [DllImport("opengl32", EntryPoint = "glUniformMatrix2fv")]
            public static extern void glUniformMatrix2fv_(GLint location, GLsizei count, GLboolean transpose, IntPtr value);
            [DllImport("opengl32", EntryPoint = "glUniformMatrix3fv")]
            public static extern void glUniformMatrix3fv_(GLint location, GLsizei count, GLboolean transpose, IntPtr value);
            [DllImport("opengl32", EntryPoint = "glUniformMatrix4fv")]
            public static extern void glUniformMatrix4fv_(GLint location, GLsizei count, GLboolean transpose, IntPtr value);
            [DllImport("opengl32", EntryPoint = "glValidateProgram")]
            public static extern void glValidateProgram(GLuint program);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib1d")]
            public static extern void glVertexAttrib1d(GLuint index, GLdouble x);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib1dv")]
            public static extern void glVertexAttrib1dv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib1f")]
            public static extern void glVertexAttrib1f(GLuint index, GLfloat x);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib1fv")]
            public static extern void glVertexAttrib1fv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib1s")]
            public static extern void glVertexAttrib1s(GLuint index, GLshort x);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib1sv")]
            public static extern void glVertexAttrib1sv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib2d")]
            public static extern void glVertexAttrib2d(GLuint index, GLdouble x, GLdouble y);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib2dv")]
            public static extern void glVertexAttrib2dv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib2f")]
            public static extern void glVertexAttrib2f(GLuint index, GLfloat x, GLfloat y);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib2fv")]
            public static extern void glVertexAttrib2fv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib2s")]
            public static extern void glVertexAttrib2s(GLuint index, GLshort x, GLshort y);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib2sv")]
            public static extern void glVertexAttrib2sv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib3d")]
            public static extern void glVertexAttrib3d(GLuint index, GLdouble x, GLdouble y, GLdouble z);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib3dv")]
            public static extern void glVertexAttrib3dv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib3f")]
            public static extern void glVertexAttrib3f(GLuint index, GLfloat x, GLfloat y, GLfloat z);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib3fv")]
            public static extern void glVertexAttrib3fv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib3s")]
            public static extern void glVertexAttrib3s(GLuint index, GLshort x, GLshort y, GLshort z);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib3sv")]
            public static extern void glVertexAttrib3sv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4Nbv")]
            public static extern void glVertexAttrib4Nbv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4Niv")]
            public static extern void glVertexAttrib4Niv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4Nsv")]
            public static extern void glVertexAttrib4Nsv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4Nub")]
            public static extern void glVertexAttrib4Nub(GLuint index, GLubyte x, GLubyte y, GLubyte z, GLubyte w);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4Nubv")]
            public static extern void glVertexAttrib4Nubv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4Nuiv")]
            public static extern void glVertexAttrib4Nuiv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4Nusv")]
            public static extern void glVertexAttrib4Nusv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4bv")]
            public static extern void glVertexAttrib4bv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4d")]
            public static extern void glVertexAttrib4d(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4dv")]
            public static extern void glVertexAttrib4dv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4f")]
            public static extern void glVertexAttrib4f(GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4fv")]
            public static extern void glVertexAttrib4fv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4iv")]
            public static extern void glVertexAttrib4iv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4s")]
            public static extern void glVertexAttrib4s(GLuint index, GLshort x, GLshort y, GLshort z, GLshort w);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4sv")]
            public static extern void glVertexAttrib4sv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4ubv")]
            public static extern void glVertexAttrib4ubv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4uiv")]
            public static extern void glVertexAttrib4uiv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttrib4usv")]
            public static extern void glVertexAttrib4usv_(GLuint index, IntPtr v);
            [DllImport("opengl32", EntryPoint = "glVertexAttribPointer")]
            public static extern void glVertexAttribPointer_(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, IntPtr pointer);
        }
        #endregion

        #region Function initialisation

        public static Delegates.glNewList glNewList = (Delegates.glNewList)GetAddress("glNewList", typeof(Delegates.glNewList));
        public static Delegates.glEndList glEndList = (Delegates.glEndList)GetAddress("glEndList", typeof(Delegates.glEndList));
        public static Delegates.glCallList glCallList = (Delegates.glCallList)GetAddress("glCallList", typeof(Delegates.glCallList));
        public static Delegates.glCallLists_ glCallLists_ = (Delegates.glCallLists_)GetAddress("glCallLists", typeof(Delegates.glCallLists_));
        public static Delegates.glDeleteLists glDeleteLists = (Delegates.glDeleteLists)GetAddress("glDeleteLists", typeof(Delegates.glDeleteLists));
        public static Delegates.glGenLists glGenLists = (Delegates.glGenLists)GetAddress("glGenLists", typeof(Delegates.glGenLists));
        public static Delegates.glListBase glListBase = (Delegates.glListBase)GetAddress("glListBase", typeof(Delegates.glListBase));
        public static Delegates.glBegin glBegin = (Delegates.glBegin)GetAddress("glBegin", typeof(Delegates.glBegin));
        public static Delegates.glBitmap_ glBitmap_ = (Delegates.glBitmap_)GetAddress("glBitmap", typeof(Delegates.glBitmap_));
        public static Delegates.glColor3b glColor3b = (Delegates.glColor3b)GetAddress("glColor3b", typeof(Delegates.glColor3b));
        public static Delegates.glColor3bv_ glColor3bv_ = (Delegates.glColor3bv_)GetAddress("glColor3bv", typeof(Delegates.glColor3bv_));
        public static Delegates.glColor3d glColor3d = (Delegates.glColor3d)GetAddress("glColor3d", typeof(Delegates.glColor3d));
        public static Delegates.glColor3dv_ glColor3dv_ = (Delegates.glColor3dv_)GetAddress("glColor3dv", typeof(Delegates.glColor3dv_));
        public static Delegates.glColor3f glColor3f = (Delegates.glColor3f)GetAddress("glColor3f", typeof(Delegates.glColor3f));
        public static Delegates.glColor3fv_ glColor3fv_ = (Delegates.glColor3fv_)GetAddress("glColor3fv", typeof(Delegates.glColor3fv_));
        public static Delegates.glColor3i glColor3i = (Delegates.glColor3i)GetAddress("glColor3i", typeof(Delegates.glColor3i));
        public static Delegates.glColor3iv_ glColor3iv_ = (Delegates.glColor3iv_)GetAddress("glColor3iv", typeof(Delegates.glColor3iv_));
        public static Delegates.glColor3s glColor3s = (Delegates.glColor3s)GetAddress("glColor3s", typeof(Delegates.glColor3s));
        public static Delegates.glColor3sv_ glColor3sv_ = (Delegates.glColor3sv_)GetAddress("glColor3sv", typeof(Delegates.glColor3sv_));
        public static Delegates.glColor3ub glColor3ub = (Delegates.glColor3ub)GetAddress("glColor3ub", typeof(Delegates.glColor3ub));
        public static Delegates.glColor3ubv_ glColor3ubv_ = (Delegates.glColor3ubv_)GetAddress("glColor3ubv", typeof(Delegates.glColor3ubv_));
        public static Delegates.glColor3ui glColor3ui = (Delegates.glColor3ui)GetAddress("glColor3ui", typeof(Delegates.glColor3ui));
        public static Delegates.glColor3uiv_ glColor3uiv_ = (Delegates.glColor3uiv_)GetAddress("glColor3uiv", typeof(Delegates.glColor3uiv_));
        public static Delegates.glColor3us glColor3us = (Delegates.glColor3us)GetAddress("glColor3us", typeof(Delegates.glColor3us));
        public static Delegates.glColor3usv_ glColor3usv_ = (Delegates.glColor3usv_)GetAddress("glColor3usv", typeof(Delegates.glColor3usv_));
        public static Delegates.glColor4b glColor4b = (Delegates.glColor4b)GetAddress("glColor4b", typeof(Delegates.glColor4b));
        public static Delegates.glColor4bv_ glColor4bv_ = (Delegates.glColor4bv_)GetAddress("glColor4bv", typeof(Delegates.glColor4bv_));
        public static Delegates.glColor4d glColor4d = (Delegates.glColor4d)GetAddress("glColor4d", typeof(Delegates.glColor4d));
        public static Delegates.glColor4dv_ glColor4dv_ = (Delegates.glColor4dv_)GetAddress("glColor4dv", typeof(Delegates.glColor4dv_));
        public static Delegates.glColor4f glColor4f = (Delegates.glColor4f)GetAddress("glColor4f", typeof(Delegates.glColor4f));
        public static Delegates.glColor4fv_ glColor4fv_ = (Delegates.glColor4fv_)GetAddress("glColor4fv", typeof(Delegates.glColor4fv_));
        public static Delegates.glColor4i glColor4i = (Delegates.glColor4i)GetAddress("glColor4i", typeof(Delegates.glColor4i));
        public static Delegates.glColor4iv_ glColor4iv_ = (Delegates.glColor4iv_)GetAddress("glColor4iv", typeof(Delegates.glColor4iv_));
        public static Delegates.glColor4s glColor4s = (Delegates.glColor4s)GetAddress("glColor4s", typeof(Delegates.glColor4s));
        public static Delegates.glColor4sv_ glColor4sv_ = (Delegates.glColor4sv_)GetAddress("glColor4sv", typeof(Delegates.glColor4sv_));
        public static Delegates.glColor4ub glColor4ub = (Delegates.glColor4ub)GetAddress("glColor4ub", typeof(Delegates.glColor4ub));
        public static Delegates.glColor4ubv_ glColor4ubv_ = (Delegates.glColor4ubv_)GetAddress("glColor4ubv", typeof(Delegates.glColor4ubv_));
        public static Delegates.glColor4ui glColor4ui = (Delegates.glColor4ui)GetAddress("glColor4ui", typeof(Delegates.glColor4ui));
        public static Delegates.glColor4uiv_ glColor4uiv_ = (Delegates.glColor4uiv_)GetAddress("glColor4uiv", typeof(Delegates.glColor4uiv_));
        public static Delegates.glColor4us glColor4us = (Delegates.glColor4us)GetAddress("glColor4us", typeof(Delegates.glColor4us));
        public static Delegates.glColor4usv_ glColor4usv_ = (Delegates.glColor4usv_)GetAddress("glColor4usv", typeof(Delegates.glColor4usv_));
        public static Delegates.glEdgeFlag glEdgeFlag = (Delegates.glEdgeFlag)GetAddress("glEdgeFlag", typeof(Delegates.glEdgeFlag));
        public static Delegates.glEdgeFlagv_ glEdgeFlagv_ = (Delegates.glEdgeFlagv_)GetAddress("glEdgeFlagv", typeof(Delegates.glEdgeFlagv_));
        public static Delegates.glEnd glEnd = (Delegates.glEnd)GetAddress("glEnd", typeof(Delegates.glEnd));
        public static Delegates.glIndexd glIndexd = (Delegates.glIndexd)GetAddress("glIndexd", typeof(Delegates.glIndexd));
        public static Delegates.glIndexdv_ glIndexdv_ = (Delegates.glIndexdv_)GetAddress("glIndexdv", typeof(Delegates.glIndexdv_));
        public static Delegates.glIndexf glIndexf = (Delegates.glIndexf)GetAddress("glIndexf", typeof(Delegates.glIndexf));
        public static Delegates.glIndexfv_ glIndexfv_ = (Delegates.glIndexfv_)GetAddress("glIndexfv", typeof(Delegates.glIndexfv_));
        public static Delegates.glIndexi glIndexi = (Delegates.glIndexi)GetAddress("glIndexi", typeof(Delegates.glIndexi));
        public static Delegates.glIndexiv_ glIndexiv_ = (Delegates.glIndexiv_)GetAddress("glIndexiv", typeof(Delegates.glIndexiv_));
        public static Delegates.glIndexs glIndexs = (Delegates.glIndexs)GetAddress("glIndexs", typeof(Delegates.glIndexs));
        public static Delegates.glIndexsv_ glIndexsv_ = (Delegates.glIndexsv_)GetAddress("glIndexsv", typeof(Delegates.glIndexsv_));
        public static Delegates.glNormal3b glNormal3b = (Delegates.glNormal3b)GetAddress("glNormal3b", typeof(Delegates.glNormal3b));
        public static Delegates.glNormal3bv_ glNormal3bv_ = (Delegates.glNormal3bv_)GetAddress("glNormal3bv", typeof(Delegates.glNormal3bv_));
        public static Delegates.glNormal3d glNormal3d = (Delegates.glNormal3d)GetAddress("glNormal3d", typeof(Delegates.glNormal3d));
        public static Delegates.glNormal3dv_ glNormal3dv_ = (Delegates.glNormal3dv_)GetAddress("glNormal3dv", typeof(Delegates.glNormal3dv_));
        public static Delegates.glNormal3f glNormal3f = (Delegates.glNormal3f)GetAddress("glNormal3f", typeof(Delegates.glNormal3f));
        public static Delegates.glNormal3fv_ glNormal3fv_ = (Delegates.glNormal3fv_)GetAddress("glNormal3fv", typeof(Delegates.glNormal3fv_));
        public static Delegates.glNormal3i glNormal3i = (Delegates.glNormal3i)GetAddress("glNormal3i", typeof(Delegates.glNormal3i));
        public static Delegates.glNormal3iv_ glNormal3iv_ = (Delegates.glNormal3iv_)GetAddress("glNormal3iv", typeof(Delegates.glNormal3iv_));
        public static Delegates.glNormal3s glNormal3s = (Delegates.glNormal3s)GetAddress("glNormal3s", typeof(Delegates.glNormal3s));
        public static Delegates.glNormal3sv_ glNormal3sv_ = (Delegates.glNormal3sv_)GetAddress("glNormal3sv", typeof(Delegates.glNormal3sv_));
        public static Delegates.glRasterPos2d glRasterPos2d = (Delegates.glRasterPos2d)GetAddress("glRasterPos2d", typeof(Delegates.glRasterPos2d));
        public static Delegates.glRasterPos2dv_ glRasterPos2dv_ = (Delegates.glRasterPos2dv_)GetAddress("glRasterPos2dv", typeof(Delegates.glRasterPos2dv_));
        public static Delegates.glRasterPos2f glRasterPos2f = (Delegates.glRasterPos2f)GetAddress("glRasterPos2f", typeof(Delegates.glRasterPos2f));
        public static Delegates.glRasterPos2fv_ glRasterPos2fv_ = (Delegates.glRasterPos2fv_)GetAddress("glRasterPos2fv", typeof(Delegates.glRasterPos2fv_));
        public static Delegates.glRasterPos2i glRasterPos2i = (Delegates.glRasterPos2i)GetAddress("glRasterPos2i", typeof(Delegates.glRasterPos2i));
        public static Delegates.glRasterPos2iv_ glRasterPos2iv_ = (Delegates.glRasterPos2iv_)GetAddress("glRasterPos2iv", typeof(Delegates.glRasterPos2iv_));
        public static Delegates.glRasterPos2s glRasterPos2s = (Delegates.glRasterPos2s)GetAddress("glRasterPos2s", typeof(Delegates.glRasterPos2s));
        public static Delegates.glRasterPos2sv_ glRasterPos2sv_ = (Delegates.glRasterPos2sv_)GetAddress("glRasterPos2sv", typeof(Delegates.glRasterPos2sv_));
        public static Delegates.glRasterPos3d glRasterPos3d = (Delegates.glRasterPos3d)GetAddress("glRasterPos3d", typeof(Delegates.glRasterPos3d));
        public static Delegates.glRasterPos3dv_ glRasterPos3dv_ = (Delegates.glRasterPos3dv_)GetAddress("glRasterPos3dv", typeof(Delegates.glRasterPos3dv_));
        public static Delegates.glRasterPos3f glRasterPos3f = (Delegates.glRasterPos3f)GetAddress("glRasterPos3f", typeof(Delegates.glRasterPos3f));
        public static Delegates.glRasterPos3fv_ glRasterPos3fv_ = (Delegates.glRasterPos3fv_)GetAddress("glRasterPos3fv", typeof(Delegates.glRasterPos3fv_));
        public static Delegates.glRasterPos3i glRasterPos3i = (Delegates.glRasterPos3i)GetAddress("glRasterPos3i", typeof(Delegates.glRasterPos3i));
        public static Delegates.glRasterPos3iv_ glRasterPos3iv_ = (Delegates.glRasterPos3iv_)GetAddress("glRasterPos3iv", typeof(Delegates.glRasterPos3iv_));
        public static Delegates.glRasterPos3s glRasterPos3s = (Delegates.glRasterPos3s)GetAddress("glRasterPos3s", typeof(Delegates.glRasterPos3s));
        public static Delegates.glRasterPos3sv_ glRasterPos3sv_ = (Delegates.glRasterPos3sv_)GetAddress("glRasterPos3sv", typeof(Delegates.glRasterPos3sv_));
        public static Delegates.glRasterPos4d glRasterPos4d = (Delegates.glRasterPos4d)GetAddress("glRasterPos4d", typeof(Delegates.glRasterPos4d));
        public static Delegates.glRasterPos4dv_ glRasterPos4dv_ = (Delegates.glRasterPos4dv_)GetAddress("glRasterPos4dv", typeof(Delegates.glRasterPos4dv_));
        public static Delegates.glRasterPos4f glRasterPos4f = (Delegates.glRasterPos4f)GetAddress("glRasterPos4f", typeof(Delegates.glRasterPos4f));
        public static Delegates.glRasterPos4fv_ glRasterPos4fv_ = (Delegates.glRasterPos4fv_)GetAddress("glRasterPos4fv", typeof(Delegates.glRasterPos4fv_));
        public static Delegates.glRasterPos4i glRasterPos4i = (Delegates.glRasterPos4i)GetAddress("glRasterPos4i", typeof(Delegates.glRasterPos4i));
        public static Delegates.glRasterPos4iv_ glRasterPos4iv_ = (Delegates.glRasterPos4iv_)GetAddress("glRasterPos4iv", typeof(Delegates.glRasterPos4iv_));
        public static Delegates.glRasterPos4s glRasterPos4s = (Delegates.glRasterPos4s)GetAddress("glRasterPos4s", typeof(Delegates.glRasterPos4s));
        public static Delegates.glRasterPos4sv_ glRasterPos4sv_ = (Delegates.glRasterPos4sv_)GetAddress("glRasterPos4sv", typeof(Delegates.glRasterPos4sv_));
        public static Delegates.glRectd glRectd = (Delegates.glRectd)GetAddress("glRectd", typeof(Delegates.glRectd));
        public static Delegates.glRectdv_ glRectdv_ = (Delegates.glRectdv_)GetAddress("glRectdv", typeof(Delegates.glRectdv_));
        public static Delegates.glRectf glRectf = (Delegates.glRectf)GetAddress("glRectf", typeof(Delegates.glRectf));
        public static Delegates.glRectfv_ glRectfv_ = (Delegates.glRectfv_)GetAddress("glRectfv", typeof(Delegates.glRectfv_));
        public static Delegates.glRecti glRecti = (Delegates.glRecti)GetAddress("glRecti", typeof(Delegates.glRecti));
        public static Delegates.glRectiv_ glRectiv_ = (Delegates.glRectiv_)GetAddress("glRectiv", typeof(Delegates.glRectiv_));
        public static Delegates.glRects glRects = (Delegates.glRects)GetAddress("glRects", typeof(Delegates.glRects));
        public static Delegates.glRectsv_ glRectsv_ = (Delegates.glRectsv_)GetAddress("glRectsv", typeof(Delegates.glRectsv_));
        public static Delegates.glTexCoord1d glTexCoord1d = (Delegates.glTexCoord1d)GetAddress("glTexCoord1d", typeof(Delegates.glTexCoord1d));
        public static Delegates.glTexCoord1dv_ glTexCoord1dv_ = (Delegates.glTexCoord1dv_)GetAddress("glTexCoord1dv", typeof(Delegates.glTexCoord1dv_));
        public static Delegates.glTexCoord1f glTexCoord1f = (Delegates.glTexCoord1f)GetAddress("glTexCoord1f", typeof(Delegates.glTexCoord1f));
        public static Delegates.glTexCoord1fv_ glTexCoord1fv_ = (Delegates.glTexCoord1fv_)GetAddress("glTexCoord1fv", typeof(Delegates.glTexCoord1fv_));
        public static Delegates.glTexCoord1i glTexCoord1i = (Delegates.glTexCoord1i)GetAddress("glTexCoord1i", typeof(Delegates.glTexCoord1i));
        public static Delegates.glTexCoord1iv_ glTexCoord1iv_ = (Delegates.glTexCoord1iv_)GetAddress("glTexCoord1iv", typeof(Delegates.glTexCoord1iv_));
        public static Delegates.glTexCoord1s glTexCoord1s = (Delegates.glTexCoord1s)GetAddress("glTexCoord1s", typeof(Delegates.glTexCoord1s));
        public static Delegates.glTexCoord1sv_ glTexCoord1sv_ = (Delegates.glTexCoord1sv_)GetAddress("glTexCoord1sv", typeof(Delegates.glTexCoord1sv_));
        public static Delegates.glTexCoord2d glTexCoord2d = (Delegates.glTexCoord2d)GetAddress("glTexCoord2d", typeof(Delegates.glTexCoord2d));
        public static Delegates.glTexCoord2dv_ glTexCoord2dv_ = (Delegates.glTexCoord2dv_)GetAddress("glTexCoord2dv", typeof(Delegates.glTexCoord2dv_));
        public static Delegates.glTexCoord2f glTexCoord2f = (Delegates.glTexCoord2f)GetAddress("glTexCoord2f", typeof(Delegates.glTexCoord2f));
        public static Delegates.glTexCoord2fv_ glTexCoord2fv_ = (Delegates.glTexCoord2fv_)GetAddress("glTexCoord2fv", typeof(Delegates.glTexCoord2fv_));
        public static Delegates.glTexCoord2i glTexCoord2i = (Delegates.glTexCoord2i)GetAddress("glTexCoord2i", typeof(Delegates.glTexCoord2i));
        public static Delegates.glTexCoord2iv_ glTexCoord2iv_ = (Delegates.glTexCoord2iv_)GetAddress("glTexCoord2iv", typeof(Delegates.glTexCoord2iv_));
        public static Delegates.glTexCoord2s glTexCoord2s = (Delegates.glTexCoord2s)GetAddress("glTexCoord2s", typeof(Delegates.glTexCoord2s));
        public static Delegates.glTexCoord2sv_ glTexCoord2sv_ = (Delegates.glTexCoord2sv_)GetAddress("glTexCoord2sv", typeof(Delegates.glTexCoord2sv_));
        public static Delegates.glTexCoord3d glTexCoord3d = (Delegates.glTexCoord3d)GetAddress("glTexCoord3d", typeof(Delegates.glTexCoord3d));
        public static Delegates.glTexCoord3dv_ glTexCoord3dv_ = (Delegates.glTexCoord3dv_)GetAddress("glTexCoord3dv", typeof(Delegates.glTexCoord3dv_));
        public static Delegates.glTexCoord3f glTexCoord3f = (Delegates.glTexCoord3f)GetAddress("glTexCoord3f", typeof(Delegates.glTexCoord3f));
        public static Delegates.glTexCoord3fv_ glTexCoord3fv_ = (Delegates.glTexCoord3fv_)GetAddress("glTexCoord3fv", typeof(Delegates.glTexCoord3fv_));
        public static Delegates.glTexCoord3i glTexCoord3i = (Delegates.glTexCoord3i)GetAddress("glTexCoord3i", typeof(Delegates.glTexCoord3i));
        public static Delegates.glTexCoord3iv_ glTexCoord3iv_ = (Delegates.glTexCoord3iv_)GetAddress("glTexCoord3iv", typeof(Delegates.glTexCoord3iv_));
        public static Delegates.glTexCoord3s glTexCoord3s = (Delegates.glTexCoord3s)GetAddress("glTexCoord3s", typeof(Delegates.glTexCoord3s));
        public static Delegates.glTexCoord3sv_ glTexCoord3sv_ = (Delegates.glTexCoord3sv_)GetAddress("glTexCoord3sv", typeof(Delegates.glTexCoord3sv_));
        public static Delegates.glTexCoord4d glTexCoord4d = (Delegates.glTexCoord4d)GetAddress("glTexCoord4d", typeof(Delegates.glTexCoord4d));
        public static Delegates.glTexCoord4dv_ glTexCoord4dv_ = (Delegates.glTexCoord4dv_)GetAddress("glTexCoord4dv", typeof(Delegates.glTexCoord4dv_));
        public static Delegates.glTexCoord4f glTexCoord4f = (Delegates.glTexCoord4f)GetAddress("glTexCoord4f", typeof(Delegates.glTexCoord4f));
        public static Delegates.glTexCoord4fv_ glTexCoord4fv_ = (Delegates.glTexCoord4fv_)GetAddress("glTexCoord4fv", typeof(Delegates.glTexCoord4fv_));
        public static Delegates.glTexCoord4i glTexCoord4i = (Delegates.glTexCoord4i)GetAddress("glTexCoord4i", typeof(Delegates.glTexCoord4i));
        public static Delegates.glTexCoord4iv_ glTexCoord4iv_ = (Delegates.glTexCoord4iv_)GetAddress("glTexCoord4iv", typeof(Delegates.glTexCoord4iv_));
        public static Delegates.glTexCoord4s glTexCoord4s = (Delegates.glTexCoord4s)GetAddress("glTexCoord4s", typeof(Delegates.glTexCoord4s));
        public static Delegates.glTexCoord4sv_ glTexCoord4sv_ = (Delegates.glTexCoord4sv_)GetAddress("glTexCoord4sv", typeof(Delegates.glTexCoord4sv_));
        public static Delegates.glVertex2d glVertex2d = (Delegates.glVertex2d)GetAddress("glVertex2d", typeof(Delegates.glVertex2d));
        public static Delegates.glVertex2dv_ glVertex2dv_ = (Delegates.glVertex2dv_)GetAddress("glVertex2dv", typeof(Delegates.glVertex2dv_));
        public static Delegates.glVertex2f glVertex2f = (Delegates.glVertex2f)GetAddress("glVertex2f", typeof(Delegates.glVertex2f));
        public static Delegates.glVertex2fv_ glVertex2fv_ = (Delegates.glVertex2fv_)GetAddress("glVertex2fv", typeof(Delegates.glVertex2fv_));
        public static Delegates.glVertex2i glVertex2i = (Delegates.glVertex2i)GetAddress("glVertex2i", typeof(Delegates.glVertex2i));
        public static Delegates.glVertex2iv_ glVertex2iv_ = (Delegates.glVertex2iv_)GetAddress("glVertex2iv", typeof(Delegates.glVertex2iv_));
        public static Delegates.glVertex2s glVertex2s = (Delegates.glVertex2s)GetAddress("glVertex2s", typeof(Delegates.glVertex2s));
        public static Delegates.glVertex2sv_ glVertex2sv_ = (Delegates.glVertex2sv_)GetAddress("glVertex2sv", typeof(Delegates.glVertex2sv_));
        public static Delegates.glVertex3d glVertex3d = (Delegates.glVertex3d)GetAddress("glVertex3d", typeof(Delegates.glVertex3d));
        public static Delegates.glVertex3dv_ glVertex3dv_ = (Delegates.glVertex3dv_)GetAddress("glVertex3dv", typeof(Delegates.glVertex3dv_));
        public static Delegates.glVertex3f glVertex3f = (Delegates.glVertex3f)GetAddress("glVertex3f", typeof(Delegates.glVertex3f));
        public static Delegates.glVertex3fv_ glVertex3fv_ = (Delegates.glVertex3fv_)GetAddress("glVertex3fv", typeof(Delegates.glVertex3fv_));
        public static Delegates.glVertex3i glVertex3i = (Delegates.glVertex3i)GetAddress("glVertex3i", typeof(Delegates.glVertex3i));
        public static Delegates.glVertex3iv_ glVertex3iv_ = (Delegates.glVertex3iv_)GetAddress("glVertex3iv", typeof(Delegates.glVertex3iv_));
        public static Delegates.glVertex3s glVertex3s = (Delegates.glVertex3s)GetAddress("glVertex3s", typeof(Delegates.glVertex3s));
        public static Delegates.glVertex3sv_ glVertex3sv_ = (Delegates.glVertex3sv_)GetAddress("glVertex3sv", typeof(Delegates.glVertex3sv_));
        public static Delegates.glVertex4d glVertex4d = (Delegates.glVertex4d)GetAddress("glVertex4d", typeof(Delegates.glVertex4d));
        public static Delegates.glVertex4dv_ glVertex4dv_ = (Delegates.glVertex4dv_)GetAddress("glVertex4dv", typeof(Delegates.glVertex4dv_));
        public static Delegates.glVertex4f glVertex4f = (Delegates.glVertex4f)GetAddress("glVertex4f", typeof(Delegates.glVertex4f));
        public static Delegates.glVertex4fv_ glVertex4fv_ = (Delegates.glVertex4fv_)GetAddress("glVertex4fv", typeof(Delegates.glVertex4fv_));
        public static Delegates.glVertex4i glVertex4i = (Delegates.glVertex4i)GetAddress("glVertex4i", typeof(Delegates.glVertex4i));
        public static Delegates.glVertex4iv_ glVertex4iv_ = (Delegates.glVertex4iv_)GetAddress("glVertex4iv", typeof(Delegates.glVertex4iv_));
        public static Delegates.glVertex4s glVertex4s = (Delegates.glVertex4s)GetAddress("glVertex4s", typeof(Delegates.glVertex4s));
        public static Delegates.glVertex4sv_ glVertex4sv_ = (Delegates.glVertex4sv_)GetAddress("glVertex4sv", typeof(Delegates.glVertex4sv_));
        public static Delegates.glClipPlane_ glClipPlane_ = (Delegates.glClipPlane_)GetAddress("glClipPlane", typeof(Delegates.glClipPlane_));
        public static Delegates.glColorMaterial glColorMaterial = (Delegates.glColorMaterial)GetAddress("glColorMaterial", typeof(Delegates.glColorMaterial));
        public static Delegates.glCullFace glCullFace = (Delegates.glCullFace)GetAddress("glCullFace", typeof(Delegates.glCullFace));
        public static Delegates.glFogf glFogf = (Delegates.glFogf)GetAddress("glFogf", typeof(Delegates.glFogf));
        public static Delegates.glFogfv_ glFogfv_ = (Delegates.glFogfv_)GetAddress("glFogfv", typeof(Delegates.glFogfv_));
        public static Delegates.glFogi glFogi = (Delegates.glFogi)GetAddress("glFogi", typeof(Delegates.glFogi));
        public static Delegates.glFogiv_ glFogiv_ = (Delegates.glFogiv_)GetAddress("glFogiv", typeof(Delegates.glFogiv_));
        public static Delegates.glFrontFace glFrontFace = (Delegates.glFrontFace)GetAddress("glFrontFace", typeof(Delegates.glFrontFace));
        public static Delegates.glHint glHint = (Delegates.glHint)GetAddress("glHint", typeof(Delegates.glHint));
        public static Delegates.glLightf glLightf = (Delegates.glLightf)GetAddress("glLightf", typeof(Delegates.glLightf));
        public static Delegates.glLightfv_ glLightfv_ = (Delegates.glLightfv_)GetAddress("glLightfv", typeof(Delegates.glLightfv_));
        public static Delegates.glLighti glLighti = (Delegates.glLighti)GetAddress("glLighti", typeof(Delegates.glLighti));
        public static Delegates.glLightiv_ glLightiv_ = (Delegates.glLightiv_)GetAddress("glLightiv", typeof(Delegates.glLightiv_));
        public static Delegates.glLightModelf glLightModelf = (Delegates.glLightModelf)GetAddress("glLightModelf", typeof(Delegates.glLightModelf));
        public static Delegates.glLightModelfv_ glLightModelfv_ = (Delegates.glLightModelfv_)GetAddress("glLightModelfv", typeof(Delegates.glLightModelfv_));
        public static Delegates.glLightModeli glLightModeli = (Delegates.glLightModeli)GetAddress("glLightModeli", typeof(Delegates.glLightModeli));
        public static Delegates.glLightModeliv_ glLightModeliv_ = (Delegates.glLightModeliv_)GetAddress("glLightModeliv", typeof(Delegates.glLightModeliv_));
        public static Delegates.glLineStipple_ glLineStipple_ = (Delegates.glLineStipple_)GetAddress("glLineStipple", typeof(Delegates.glLineStipple_));
        public static Delegates.glLineWidth glLineWidth = (Delegates.glLineWidth)GetAddress("glLineWidth", typeof(Delegates.glLineWidth));
        public static Delegates.glMaterialf glMaterialf = (Delegates.glMaterialf)GetAddress("glMaterialf", typeof(Delegates.glMaterialf));
        public static Delegates.glMaterialfv_ glMaterialfv_ = (Delegates.glMaterialfv_)GetAddress("glMaterialfv", typeof(Delegates.glMaterialfv_));
        public static Delegates.glMateriali glMateriali = (Delegates.glMateriali)GetAddress("glMateriali", typeof(Delegates.glMateriali));
        public static Delegates.glMaterialiv_ glMaterialiv_ = (Delegates.glMaterialiv_)GetAddress("glMaterialiv", typeof(Delegates.glMaterialiv_));
        public static Delegates.glPointSize glPointSize = (Delegates.glPointSize)GetAddress("glPointSize", typeof(Delegates.glPointSize));
        public static Delegates.glPolygonMode glPolygonMode = (Delegates.glPolygonMode)GetAddress("glPolygonMode", typeof(Delegates.glPolygonMode));
        public static Delegates.glPolygonStipple_ glPolygonStipple_ = (Delegates.glPolygonStipple_)GetAddress("glPolygonStipple", typeof(Delegates.glPolygonStipple_));
        public static Delegates.glScissor glScissor = (Delegates.glScissor)GetAddress("glScissor", typeof(Delegates.glScissor));
        public static Delegates.glShadeModel glShadeModel = (Delegates.glShadeModel)GetAddress("glShadeModel", typeof(Delegates.glShadeModel));
        public static Delegates.glTexParameterf glTexParameterf = (Delegates.glTexParameterf)GetAddress("glTexParameterf", typeof(Delegates.glTexParameterf));
        public static Delegates.glTexParameterfv_ glTexParameterfv_ = (Delegates.glTexParameterfv_)GetAddress("glTexParameterfv", typeof(Delegates.glTexParameterfv_));
        public static Delegates.glTexParameteri glTexParameteri = (Delegates.glTexParameteri)GetAddress("glTexParameteri", typeof(Delegates.glTexParameteri));
        public static Delegates.glTexParameteriv_ glTexParameteriv_ = (Delegates.glTexParameteriv_)GetAddress("glTexParameteriv", typeof(Delegates.glTexParameteriv_));
        public static Delegates.glTexImage1D_ glTexImage1D_ = (Delegates.glTexImage1D_)GetAddress("glTexImage1D", typeof(Delegates.glTexImage1D_));
        public static Delegates.glTexImage2D_ glTexImage2D_ = (Delegates.glTexImage2D_)GetAddress("glTexImage2D", typeof(Delegates.glTexImage2D_));
        public static Delegates.glTexEnvf glTexEnvf = (Delegates.glTexEnvf)GetAddress("glTexEnvf", typeof(Delegates.glTexEnvf));
        public static Delegates.glTexEnvfv_ glTexEnvfv_ = (Delegates.glTexEnvfv_)GetAddress("glTexEnvfv", typeof(Delegates.glTexEnvfv_));
        public static Delegates.glTexEnvi glTexEnvi = (Delegates.glTexEnvi)GetAddress("glTexEnvi", typeof(Delegates.glTexEnvi));
        public static Delegates.glTexEnviv_ glTexEnviv_ = (Delegates.glTexEnviv_)GetAddress("glTexEnviv", typeof(Delegates.glTexEnviv_));
        public static Delegates.glTexGend glTexGend = (Delegates.glTexGend)GetAddress("glTexGend", typeof(Delegates.glTexGend));
        public static Delegates.glTexGendv_ glTexGendv_ = (Delegates.glTexGendv_)GetAddress("glTexGendv", typeof(Delegates.glTexGendv_));
        public static Delegates.glTexGenf glTexGenf = (Delegates.glTexGenf)GetAddress("glTexGenf", typeof(Delegates.glTexGenf));
        public static Delegates.glTexGenfv_ glTexGenfv_ = (Delegates.glTexGenfv_)GetAddress("glTexGenfv", typeof(Delegates.glTexGenfv_));
        public static Delegates.glTexGeni glTexGeni = (Delegates.glTexGeni)GetAddress("glTexGeni", typeof(Delegates.glTexGeni));
        public static Delegates.glTexGeniv_ glTexGeniv_ = (Delegates.glTexGeniv_)GetAddress("glTexGeniv", typeof(Delegates.glTexGeniv_));
        public static Delegates.glFeedbackBuffer glFeedbackBuffer = (Delegates.glFeedbackBuffer)GetAddress("glFeedbackBuffer", typeof(Delegates.glFeedbackBuffer));
        public static Delegates.glSelectBuffer glSelectBuffer = (Delegates.glSelectBuffer)GetAddress("glSelectBuffer", typeof(Delegates.glSelectBuffer));
        public static Delegates.glRenderMode glRenderMode = (Delegates.glRenderMode)GetAddress("glRenderMode", typeof(Delegates.glRenderMode));
        public static Delegates.glInitNames glInitNames = (Delegates.glInitNames)GetAddress("glInitNames", typeof(Delegates.glInitNames));
        public static Delegates.glLoadName glLoadName = (Delegates.glLoadName)GetAddress("glLoadName", typeof(Delegates.glLoadName));
        public static Delegates.glPassThrough glPassThrough = (Delegates.glPassThrough)GetAddress("glPassThrough", typeof(Delegates.glPassThrough));
        public static Delegates.glPopName glPopName = (Delegates.glPopName)GetAddress("glPopName", typeof(Delegates.glPopName));
        public static Delegates.glPushName glPushName = (Delegates.glPushName)GetAddress("glPushName", typeof(Delegates.glPushName));
        public static Delegates.glDrawBuffer glDrawBuffer = (Delegates.glDrawBuffer)GetAddress("glDrawBuffer", typeof(Delegates.glDrawBuffer));
        public static Delegates.glClear glClear = (Delegates.glClear)GetAddress("glClear", typeof(Delegates.glClear));
        public static Delegates.glClearAccum glClearAccum = (Delegates.glClearAccum)GetAddress("glClearAccum", typeof(Delegates.glClearAccum));
        public static Delegates.glClearIndex glClearIndex = (Delegates.glClearIndex)GetAddress("glClearIndex", typeof(Delegates.glClearIndex));
        public static Delegates.glClearColor glClearColor = (Delegates.glClearColor)GetAddress("glClearColor", typeof(Delegates.glClearColor));
        public static Delegates.glClearStencil glClearStencil = (Delegates.glClearStencil)GetAddress("glClearStencil", typeof(Delegates.glClearStencil));
        public static Delegates.glClearDepth glClearDepth = (Delegates.glClearDepth)GetAddress("glClearDepth", typeof(Delegates.glClearDepth));
        public static Delegates.glStencilMask glStencilMask = (Delegates.glStencilMask)GetAddress("glStencilMask", typeof(Delegates.glStencilMask));
        public static Delegates.glColorMask glColorMask = (Delegates.glColorMask)GetAddress("glColorMask", typeof(Delegates.glColorMask));
        public static Delegates.glDepthMask glDepthMask = (Delegates.glDepthMask)GetAddress("glDepthMask", typeof(Delegates.glDepthMask));
        public static Delegates.glIndexMask glIndexMask = (Delegates.glIndexMask)GetAddress("glIndexMask", typeof(Delegates.glIndexMask));
        public static Delegates.glAccum glAccum = (Delegates.glAccum)GetAddress("glAccum", typeof(Delegates.glAccum));
        public static Delegates.glDisable glDisable = (Delegates.glDisable)GetAddress("glDisable", typeof(Delegates.glDisable));
        public static Delegates.glEnable glEnable = (Delegates.glEnable)GetAddress("glEnable", typeof(Delegates.glEnable));
        public static Delegates.glFinish glFinish = (Delegates.glFinish)GetAddress("glFinish", typeof(Delegates.glFinish));
        public static Delegates.glFlush glFlush = (Delegates.glFlush)GetAddress("glFlush", typeof(Delegates.glFlush));
        public static Delegates.glPopAttrib glPopAttrib = (Delegates.glPopAttrib)GetAddress("glPopAttrib", typeof(Delegates.glPopAttrib));
        public static Delegates.glPushAttrib glPushAttrib = (Delegates.glPushAttrib)GetAddress("glPushAttrib", typeof(Delegates.glPushAttrib));
        public static Delegates.glMap1d_ glMap1d_ = (Delegates.glMap1d_)GetAddress("glMap1d", typeof(Delegates.glMap1d_));
        public static Delegates.glMap1f_ glMap1f_ = (Delegates.glMap1f_)GetAddress("glMap1f", typeof(Delegates.glMap1f_));
        public static Delegates.glMap2d_ glMap2d_ = (Delegates.glMap2d_)GetAddress("glMap2d", typeof(Delegates.glMap2d_));
        public static Delegates.glMap2f_ glMap2f_ = (Delegates.glMap2f_)GetAddress("glMap2f", typeof(Delegates.glMap2f_));
        public static Delegates.glMapGrid1d glMapGrid1d = (Delegates.glMapGrid1d)GetAddress("glMapGrid1d", typeof(Delegates.glMapGrid1d));
        public static Delegates.glMapGrid1f glMapGrid1f = (Delegates.glMapGrid1f)GetAddress("glMapGrid1f", typeof(Delegates.glMapGrid1f));
        public static Delegates.glMapGrid2d glMapGrid2d = (Delegates.glMapGrid2d)GetAddress("glMapGrid2d", typeof(Delegates.glMapGrid2d));
        public static Delegates.glMapGrid2f glMapGrid2f = (Delegates.glMapGrid2f)GetAddress("glMapGrid2f", typeof(Delegates.glMapGrid2f));
        public static Delegates.glEvalCoord1d glEvalCoord1d = (Delegates.glEvalCoord1d)GetAddress("glEvalCoord1d", typeof(Delegates.glEvalCoord1d));
        public static Delegates.glEvalCoord1dv_ glEvalCoord1dv_ = (Delegates.glEvalCoord1dv_)GetAddress("glEvalCoord1dv", typeof(Delegates.glEvalCoord1dv_));
        public static Delegates.glEvalCoord1f glEvalCoord1f = (Delegates.glEvalCoord1f)GetAddress("glEvalCoord1f", typeof(Delegates.glEvalCoord1f));
        public static Delegates.glEvalCoord1fv_ glEvalCoord1fv_ = (Delegates.glEvalCoord1fv_)GetAddress("glEvalCoord1fv", typeof(Delegates.glEvalCoord1fv_));
        public static Delegates.glEvalCoord2d glEvalCoord2d = (Delegates.glEvalCoord2d)GetAddress("glEvalCoord2d", typeof(Delegates.glEvalCoord2d));
        public static Delegates.glEvalCoord2dv_ glEvalCoord2dv_ = (Delegates.glEvalCoord2dv_)GetAddress("glEvalCoord2dv", typeof(Delegates.glEvalCoord2dv_));
        public static Delegates.glEvalCoord2f glEvalCoord2f = (Delegates.glEvalCoord2f)GetAddress("glEvalCoord2f", typeof(Delegates.glEvalCoord2f));
        public static Delegates.glEvalCoord2fv_ glEvalCoord2fv_ = (Delegates.glEvalCoord2fv_)GetAddress("glEvalCoord2fv", typeof(Delegates.glEvalCoord2fv_));
        public static Delegates.glEvalMesh1 glEvalMesh1 = (Delegates.glEvalMesh1)GetAddress("glEvalMesh1", typeof(Delegates.glEvalMesh1));
        public static Delegates.glEvalPoint1 glEvalPoint1 = (Delegates.glEvalPoint1)GetAddress("glEvalPoint1", typeof(Delegates.glEvalPoint1));
        public static Delegates.glEvalMesh2 glEvalMesh2 = (Delegates.glEvalMesh2)GetAddress("glEvalMesh2", typeof(Delegates.glEvalMesh2));
        public static Delegates.glEvalPoint2 glEvalPoint2 = (Delegates.glEvalPoint2)GetAddress("glEvalPoint2", typeof(Delegates.glEvalPoint2));
        public static Delegates.glAlphaFunc glAlphaFunc = (Delegates.glAlphaFunc)GetAddress("glAlphaFunc", typeof(Delegates.glAlphaFunc));
        public static Delegates.glBlendFunc glBlendFunc = (Delegates.glBlendFunc)GetAddress("glBlendFunc", typeof(Delegates.glBlendFunc));
        public static Delegates.glLogicOp glLogicOp = (Delegates.glLogicOp)GetAddress("glLogicOp", typeof(Delegates.glLogicOp));
        public static Delegates.glStencilFunc glStencilFunc = (Delegates.glStencilFunc)GetAddress("glStencilFunc", typeof(Delegates.glStencilFunc));
        public static Delegates.glStencilOp glStencilOp = (Delegates.glStencilOp)GetAddress("glStencilOp", typeof(Delegates.glStencilOp));
        public static Delegates.glDepthFunc glDepthFunc = (Delegates.glDepthFunc)GetAddress("glDepthFunc", typeof(Delegates.glDepthFunc));
        public static Delegates.glPixelZoom glPixelZoom = (Delegates.glPixelZoom)GetAddress("glPixelZoom", typeof(Delegates.glPixelZoom));
        public static Delegates.glPixelTransferf glPixelTransferf = (Delegates.glPixelTransferf)GetAddress("glPixelTransferf", typeof(Delegates.glPixelTransferf));
        public static Delegates.glPixelTransferi glPixelTransferi = (Delegates.glPixelTransferi)GetAddress("glPixelTransferi", typeof(Delegates.glPixelTransferi));
        public static Delegates.glPixelStoref glPixelStoref = (Delegates.glPixelStoref)GetAddress("glPixelStoref", typeof(Delegates.glPixelStoref));
        public static Delegates.glPixelStorei glPixelStorei = (Delegates.glPixelStorei)GetAddress("glPixelStorei", typeof(Delegates.glPixelStorei));
        public static Delegates.glPixelMapfv_ glPixelMapfv_ = (Delegates.glPixelMapfv_)GetAddress("glPixelMapfv", typeof(Delegates.glPixelMapfv_));
        public static Delegates.glPixelMapuiv_ glPixelMapuiv_ = (Delegates.glPixelMapuiv_)GetAddress("glPixelMapuiv", typeof(Delegates.glPixelMapuiv_));
        public static Delegates.glPixelMapusv_ glPixelMapusv_ = (Delegates.glPixelMapusv_)GetAddress("glPixelMapusv", typeof(Delegates.glPixelMapusv_));
        public static Delegates.glReadBuffer glReadBuffer = (Delegates.glReadBuffer)GetAddress("glReadBuffer", typeof(Delegates.glReadBuffer));
        public static Delegates.glCopyPixels glCopyPixels = (Delegates.glCopyPixels)GetAddress("glCopyPixels", typeof(Delegates.glCopyPixels));
        public static Delegates.glReadPixels_ glReadPixels_ = (Delegates.glReadPixels_)GetAddress("glReadPixels", typeof(Delegates.glReadPixels_));
        public static Delegates.glDrawPixels_ glDrawPixels_ = (Delegates.glDrawPixels_)GetAddress("glDrawPixels", typeof(Delegates.glDrawPixels_));
        public static Delegates.glGetBooleanv glGetBooleanv = (Delegates.glGetBooleanv)GetAddress("glGetBooleanv", typeof(Delegates.glGetBooleanv));
        public static Delegates.glGetClipPlane glGetClipPlane = (Delegates.glGetClipPlane)GetAddress("glGetClipPlane", typeof(Delegates.glGetClipPlane));
        public static Delegates.glGetDoublev glGetDoublev = (Delegates.glGetDoublev)GetAddress("glGetDoublev", typeof(Delegates.glGetDoublev));
        public static Delegates.glGetError glGetError = (Delegates.glGetError)GetAddress("glGetError", typeof(Delegates.glGetError));
        public static Delegates.glGetFloatv glGetFloatv = (Delegates.glGetFloatv)GetAddress("glGetFloatv", typeof(Delegates.glGetFloatv));
        public static Delegates.glGetIntegerv glGetIntegerv = (Delegates.glGetIntegerv)GetAddress("glGetIntegerv", typeof(Delegates.glGetIntegerv));
        public static Delegates.glGetLightfv glGetLightfv = (Delegates.glGetLightfv)GetAddress("glGetLightfv", typeof(Delegates.glGetLightfv));
        public static Delegates.glGetLightiv glGetLightiv = (Delegates.glGetLightiv)GetAddress("glGetLightiv", typeof(Delegates.glGetLightiv));
        public static Delegates.glGetMapdv glGetMapdv = (Delegates.glGetMapdv)GetAddress("glGetMapdv", typeof(Delegates.glGetMapdv));
        public static Delegates.glGetMapfv glGetMapfv = (Delegates.glGetMapfv)GetAddress("glGetMapfv", typeof(Delegates.glGetMapfv));
        public static Delegates.glGetMapiv glGetMapiv = (Delegates.glGetMapiv)GetAddress("glGetMapiv", typeof(Delegates.glGetMapiv));
        public static Delegates.glGetMaterialfv glGetMaterialfv = (Delegates.glGetMaterialfv)GetAddress("glGetMaterialfv", typeof(Delegates.glGetMaterialfv));
        public static Delegates.glGetMaterialiv glGetMaterialiv = (Delegates.glGetMaterialiv)GetAddress("glGetMaterialiv", typeof(Delegates.glGetMaterialiv));
        public static Delegates.glGetPixelMapfv glGetPixelMapfv = (Delegates.glGetPixelMapfv)GetAddress("glGetPixelMapfv", typeof(Delegates.glGetPixelMapfv));
        public static Delegates.glGetPixelMapuiv glGetPixelMapuiv = (Delegates.glGetPixelMapuiv)GetAddress("glGetPixelMapuiv", typeof(Delegates.glGetPixelMapuiv));
        public static Delegates.glGetPixelMapusv glGetPixelMapusv = (Delegates.glGetPixelMapusv)GetAddress("glGetPixelMapusv", typeof(Delegates.glGetPixelMapusv));
        public static Delegates.glGetPolygonStipple glGetPolygonStipple = (Delegates.glGetPolygonStipple)GetAddress("glGetPolygonStipple", typeof(Delegates.glGetPolygonStipple));
        public static Delegates.glGetString_ glGetString_ = (Delegates.glGetString_)GetAddress("glGetString", typeof(Delegates.glGetString_));
        public static Delegates.glGetTexEnvfv glGetTexEnvfv = (Delegates.glGetTexEnvfv)GetAddress("glGetTexEnvfv", typeof(Delegates.glGetTexEnvfv));
        public static Delegates.glGetTexEnviv glGetTexEnviv = (Delegates.glGetTexEnviv)GetAddress("glGetTexEnviv", typeof(Delegates.glGetTexEnviv));
        public static Delegates.glGetTexGendv glGetTexGendv = (Delegates.glGetTexGendv)GetAddress("glGetTexGendv", typeof(Delegates.glGetTexGendv));
        public static Delegates.glGetTexGenfv glGetTexGenfv = (Delegates.glGetTexGenfv)GetAddress("glGetTexGenfv", typeof(Delegates.glGetTexGenfv));
        public static Delegates.glGetTexGeniv glGetTexGeniv = (Delegates.glGetTexGeniv)GetAddress("glGetTexGeniv", typeof(Delegates.glGetTexGeniv));
        public static Delegates.glGetTexImage_ glGetTexImage_ = (Delegates.glGetTexImage_)GetAddress("glGetTexImage", typeof(Delegates.glGetTexImage_));
        public static Delegates.glGetTexParameterfv glGetTexParameterfv = (Delegates.glGetTexParameterfv)GetAddress("glGetTexParameterfv", typeof(Delegates.glGetTexParameterfv));
        public static Delegates.glGetTexParameteriv glGetTexParameteriv = (Delegates.glGetTexParameteriv)GetAddress("glGetTexParameteriv", typeof(Delegates.glGetTexParameteriv));
        public static Delegates.glGetTexLevelParameterfv glGetTexLevelParameterfv = (Delegates.glGetTexLevelParameterfv)GetAddress("glGetTexLevelParameterfv", typeof(Delegates.glGetTexLevelParameterfv));
        public static Delegates.glGetTexLevelParameteriv glGetTexLevelParameteriv = (Delegates.glGetTexLevelParameteriv)GetAddress("glGetTexLevelParameteriv", typeof(Delegates.glGetTexLevelParameteriv));
        public static Delegates.glIsEnabled glIsEnabled = (Delegates.glIsEnabled)GetAddress("glIsEnabled", typeof(Delegates.glIsEnabled));
        public static Delegates.glIsList glIsList = (Delegates.glIsList)GetAddress("glIsList", typeof(Delegates.glIsList));
        public static Delegates.glDepthRange glDepthRange = (Delegates.glDepthRange)GetAddress("glDepthRange", typeof(Delegates.glDepthRange));
        public static Delegates.glFrustum glFrustum = (Delegates.glFrustum)GetAddress("glFrustum", typeof(Delegates.glFrustum));
        public static Delegates.glLoadIdentity glLoadIdentity = (Delegates.glLoadIdentity)GetAddress("glLoadIdentity", typeof(Delegates.glLoadIdentity));
        public static Delegates.glLoadMatrixf_ glLoadMatrixf_ = (Delegates.glLoadMatrixf_)GetAddress("glLoadMatrixf", typeof(Delegates.glLoadMatrixf_));
        public static Delegates.glLoadMatrixd_ glLoadMatrixd_ = (Delegates.glLoadMatrixd_)GetAddress("glLoadMatrixd", typeof(Delegates.glLoadMatrixd_));
        public static Delegates.glMatrixMode glMatrixMode = (Delegates.glMatrixMode)GetAddress("glMatrixMode", typeof(Delegates.glMatrixMode));
        public static Delegates.glMultMatrixf_ glMultMatrixf_ = (Delegates.glMultMatrixf_)GetAddress("glMultMatrixf", typeof(Delegates.glMultMatrixf_));
        public static Delegates.glMultMatrixd_ glMultMatrixd_ = (Delegates.glMultMatrixd_)GetAddress("glMultMatrixd", typeof(Delegates.glMultMatrixd_));
        public static Delegates.glOrtho glOrtho = (Delegates.glOrtho)GetAddress("glOrtho", typeof(Delegates.glOrtho));
        public static Delegates.glPopMatrix glPopMatrix = (Delegates.glPopMatrix)GetAddress("glPopMatrix", typeof(Delegates.glPopMatrix));
        public static Delegates.glPushMatrix glPushMatrix = (Delegates.glPushMatrix)GetAddress("glPushMatrix", typeof(Delegates.glPushMatrix));
        public static Delegates.glRotated glRotated = (Delegates.glRotated)GetAddress("glRotated", typeof(Delegates.glRotated));
        public static Delegates.glRotatef glRotatef = (Delegates.glRotatef)GetAddress("glRotatef", typeof(Delegates.glRotatef));
        public static Delegates.glScaled glScaled = (Delegates.glScaled)GetAddress("glScaled", typeof(Delegates.glScaled));
        public static Delegates.glScalef glScalef = (Delegates.glScalef)GetAddress("glScalef", typeof(Delegates.glScalef));
        public static Delegates.glTranslated glTranslated = (Delegates.glTranslated)GetAddress("glTranslated", typeof(Delegates.glTranslated));
        public static Delegates.glTranslatef glTranslatef = (Delegates.glTranslatef)GetAddress("glTranslatef", typeof(Delegates.glTranslatef));
        public static Delegates.glViewport glViewport = (Delegates.glViewport)GetAddress("glViewport", typeof(Delegates.glViewport));
        public static Delegates.glArrayElement glArrayElement = (Delegates.glArrayElement)GetAddress("glArrayElement", typeof(Delegates.glArrayElement));
        public static Delegates.glColorPointer_ glColorPointer_ = (Delegates.glColorPointer_)GetAddress("glColorPointer", typeof(Delegates.glColorPointer_));
        public static Delegates.glDisableClientState glDisableClientState = (Delegates.glDisableClientState)GetAddress("glDisableClientState", typeof(Delegates.glDisableClientState));
        public static Delegates.glDrawArrays glDrawArrays = (Delegates.glDrawArrays)GetAddress("glDrawArrays", typeof(Delegates.glDrawArrays));
        public static Delegates.glDrawElements_ glDrawElements_ = (Delegates.glDrawElements_)GetAddress("glDrawElements", typeof(Delegates.glDrawElements_));
        public static Delegates.glEdgeFlagPointer_ glEdgeFlagPointer_ = (Delegates.glEdgeFlagPointer_)GetAddress("glEdgeFlagPointer", typeof(Delegates.glEdgeFlagPointer_));
        public static Delegates.glEnableClientState glEnableClientState = (Delegates.glEnableClientState)GetAddress("glEnableClientState", typeof(Delegates.glEnableClientState));
        public static Delegates.glGetPointerv glGetPointerv = (Delegates.glGetPointerv)GetAddress("glGetPointerv", typeof(Delegates.glGetPointerv));
        public static Delegates.glIndexPointer_ glIndexPointer_ = (Delegates.glIndexPointer_)GetAddress("glIndexPointer", typeof(Delegates.glIndexPointer_));
        public static Delegates.glInterleavedArrays_ glInterleavedArrays_ = (Delegates.glInterleavedArrays_)GetAddress("glInterleavedArrays", typeof(Delegates.glInterleavedArrays_));
        public static Delegates.glNormalPointer_ glNormalPointer_ = (Delegates.glNormalPointer_)GetAddress("glNormalPointer", typeof(Delegates.glNormalPointer_));
        public static Delegates.glTexCoordPointer_ glTexCoordPointer_ = (Delegates.glTexCoordPointer_)GetAddress("glTexCoordPointer", typeof(Delegates.glTexCoordPointer_));
        public static Delegates.glVertexPointer_ glVertexPointer_ = (Delegates.glVertexPointer_)GetAddress("glVertexPointer", typeof(Delegates.glVertexPointer_));
        public static Delegates.glPolygonOffset glPolygonOffset = (Delegates.glPolygonOffset)GetAddress("glPolygonOffset", typeof(Delegates.glPolygonOffset));
        public static Delegates.glCopyTexImage1D glCopyTexImage1D = (Delegates.glCopyTexImage1D)GetAddress("glCopyTexImage1D", typeof(Delegates.glCopyTexImage1D));
        public static Delegates.glCopyTexImage2D glCopyTexImage2D = (Delegates.glCopyTexImage2D)GetAddress("glCopyTexImage2D", typeof(Delegates.glCopyTexImage2D));
        public static Delegates.glCopyTexSubImage1D glCopyTexSubImage1D = (Delegates.glCopyTexSubImage1D)GetAddress("glCopyTexSubImage1D", typeof(Delegates.glCopyTexSubImage1D));
        public static Delegates.glCopyTexSubImage2D glCopyTexSubImage2D = (Delegates.glCopyTexSubImage2D)GetAddress("glCopyTexSubImage2D", typeof(Delegates.glCopyTexSubImage2D));
        public static Delegates.glTexSubImage1D_ glTexSubImage1D_ = (Delegates.glTexSubImage1D_)GetAddress("glTexSubImage1D", typeof(Delegates.glTexSubImage1D_));
        public static Delegates.glTexSubImage2D_ glTexSubImage2D_ = (Delegates.glTexSubImage2D_)GetAddress("glTexSubImage2D", typeof(Delegates.glTexSubImage2D_));
        public static Delegates.glAreTexturesResident_ glAreTexturesResident_ = (Delegates.glAreTexturesResident_)GetAddress("glAreTexturesResident", typeof(Delegates.glAreTexturesResident_));
        public static Delegates.glBindTexture glBindTexture = (Delegates.glBindTexture)GetAddress("glBindTexture", typeof(Delegates.glBindTexture));
        public static Delegates.glDeleteTextures_ glDeleteTextures_ = (Delegates.glDeleteTextures_)GetAddress("glDeleteTextures", typeof(Delegates.glDeleteTextures_));
        public static Delegates.glGenTextures glGenTextures = (Delegates.glGenTextures)GetAddress("glGenTextures", typeof(Delegates.glGenTextures));
        public static Delegates.glIsTexture glIsTexture = (Delegates.glIsTexture)GetAddress("glIsTexture", typeof(Delegates.glIsTexture));
        public static Delegates.glPrioritizeTextures_ glPrioritizeTextures_ = (Delegates.glPrioritizeTextures_)GetAddress("glPrioritizeTextures", typeof(Delegates.glPrioritizeTextures_));
        public static Delegates.glIndexub glIndexub = (Delegates.glIndexub)GetAddress("glIndexub", typeof(Delegates.glIndexub));
        public static Delegates.glIndexubv_ glIndexubv_ = (Delegates.glIndexubv_)GetAddress("glIndexubv", typeof(Delegates.glIndexubv_));
        public static Delegates.glPopClientAttrib glPopClientAttrib = (Delegates.glPopClientAttrib)GetAddress("glPopClientAttrib", typeof(Delegates.glPopClientAttrib));
        public static Delegates.glPushClientAttrib glPushClientAttrib = (Delegates.glPushClientAttrib)GetAddress("glPushClientAttrib", typeof(Delegates.glPushClientAttrib));
        public static Delegates.glBlendColor glBlendColor = (Delegates.glBlendColor)GetAddress("glBlendColor", typeof(Delegates.glBlendColor));
        public static Delegates.glBlendEquation glBlendEquation = (Delegates.glBlendEquation)GetAddress("glBlendEquation", typeof(Delegates.glBlendEquation));
        public static Delegates.glDrawRangeElements_ glDrawRangeElements_ = (Delegates.glDrawRangeElements_)GetAddress("glDrawRangeElements", typeof(Delegates.glDrawRangeElements_));
        public static Delegates.glColorTable_ glColorTable_ = (Delegates.glColorTable_)GetAddress("glColorTable", typeof(Delegates.glColorTable_));
        public static Delegates.glColorTableParameterfv_ glColorTableParameterfv_ = (Delegates.glColorTableParameterfv_)GetAddress("glColorTableParameterfv", typeof(Delegates.glColorTableParameterfv_));
        public static Delegates.glColorTableParameteriv_ glColorTableParameteriv_ = (Delegates.glColorTableParameteriv_)GetAddress("glColorTableParameteriv", typeof(Delegates.glColorTableParameteriv_));
        public static Delegates.glCopyColorTable glCopyColorTable = (Delegates.glCopyColorTable)GetAddress("glCopyColorTable", typeof(Delegates.glCopyColorTable));
        public static Delegates.glGetColorTable_ glGetColorTable_ = (Delegates.glGetColorTable_)GetAddress("glGetColorTable", typeof(Delegates.glGetColorTable_));
        public static Delegates.glGetColorTableParameterfv glGetColorTableParameterfv = (Delegates.glGetColorTableParameterfv)GetAddress("glGetColorTableParameterfv", typeof(Delegates.glGetColorTableParameterfv));
        public static Delegates.glGetColorTableParameteriv glGetColorTableParameteriv = (Delegates.glGetColorTableParameteriv)GetAddress("glGetColorTableParameteriv", typeof(Delegates.glGetColorTableParameteriv));
        public static Delegates.glColorSubTable_ glColorSubTable_ = (Delegates.glColorSubTable_)GetAddress("glColorSubTable", typeof(Delegates.glColorSubTable_));
        public static Delegates.glCopyColorSubTable glCopyColorSubTable = (Delegates.glCopyColorSubTable)GetAddress("glCopyColorSubTable", typeof(Delegates.glCopyColorSubTable));
        public static Delegates.glConvolutionFilter1D_ glConvolutionFilter1D_ = (Delegates.glConvolutionFilter1D_)GetAddress("glConvolutionFilter1D", typeof(Delegates.glConvolutionFilter1D_));
        public static Delegates.glConvolutionFilter2D_ glConvolutionFilter2D_ = (Delegates.glConvolutionFilter2D_)GetAddress("glConvolutionFilter2D", typeof(Delegates.glConvolutionFilter2D_));
        public static Delegates.glConvolutionParameterf glConvolutionParameterf = (Delegates.glConvolutionParameterf)GetAddress("glConvolutionParameterf", typeof(Delegates.glConvolutionParameterf));
        public static Delegates.glConvolutionParameterfv_ glConvolutionParameterfv_ = (Delegates.glConvolutionParameterfv_)GetAddress("glConvolutionParameterfv", typeof(Delegates.glConvolutionParameterfv_));
        public static Delegates.glConvolutionParameteri glConvolutionParameteri = (Delegates.glConvolutionParameteri)GetAddress("glConvolutionParameteri", typeof(Delegates.glConvolutionParameteri));
        public static Delegates.glConvolutionParameteriv_ glConvolutionParameteriv_ = (Delegates.glConvolutionParameteriv_)GetAddress("glConvolutionParameteriv", typeof(Delegates.glConvolutionParameteriv_));
        public static Delegates.glCopyConvolutionFilter1D glCopyConvolutionFilter1D = (Delegates.glCopyConvolutionFilter1D)GetAddress("glCopyConvolutionFilter1D", typeof(Delegates.glCopyConvolutionFilter1D));
        public static Delegates.glCopyConvolutionFilter2D glCopyConvolutionFilter2D = (Delegates.glCopyConvolutionFilter2D)GetAddress("glCopyConvolutionFilter2D", typeof(Delegates.glCopyConvolutionFilter2D));
        public static Delegates.glGetConvolutionFilter_ glGetConvolutionFilter_ = (Delegates.glGetConvolutionFilter_)GetAddress("glGetConvolutionFilter", typeof(Delegates.glGetConvolutionFilter_));
        public static Delegates.glGetConvolutionParameterfv glGetConvolutionParameterfv = (Delegates.glGetConvolutionParameterfv)GetAddress("glGetConvolutionParameterfv", typeof(Delegates.glGetConvolutionParameterfv));
        public static Delegates.glGetConvolutionParameteriv glGetConvolutionParameteriv = (Delegates.glGetConvolutionParameteriv)GetAddress("glGetConvolutionParameteriv", typeof(Delegates.glGetConvolutionParameteriv));
        public static Delegates.glGetSeparableFilter_ glGetSeparableFilter_ = (Delegates.glGetSeparableFilter_)GetAddress("glGetSeparableFilter", typeof(Delegates.glGetSeparableFilter_));
        public static Delegates.glSeparableFilter2D_ glSeparableFilter2D_ = (Delegates.glSeparableFilter2D_)GetAddress("glSeparableFilter2D", typeof(Delegates.glSeparableFilter2D_));
        public static Delegates.glGetHistogram_ glGetHistogram_ = (Delegates.glGetHistogram_)GetAddress("glGetHistogram", typeof(Delegates.glGetHistogram_));
        public static Delegates.glGetHistogramParameterfv glGetHistogramParameterfv = (Delegates.glGetHistogramParameterfv)GetAddress("glGetHistogramParameterfv", typeof(Delegates.glGetHistogramParameterfv));
        public static Delegates.glGetHistogramParameteriv glGetHistogramParameteriv = (Delegates.glGetHistogramParameteriv)GetAddress("glGetHistogramParameteriv", typeof(Delegates.glGetHistogramParameteriv));
        public static Delegates.glGetMinmax_ glGetMinmax_ = (Delegates.glGetMinmax_)GetAddress("glGetMinmax", typeof(Delegates.glGetMinmax_));
        public static Delegates.glGetMinmaxParameterfv glGetMinmaxParameterfv = (Delegates.glGetMinmaxParameterfv)GetAddress("glGetMinmaxParameterfv", typeof(Delegates.glGetMinmaxParameterfv));
        public static Delegates.glGetMinmaxParameteriv glGetMinmaxParameteriv = (Delegates.glGetMinmaxParameteriv)GetAddress("glGetMinmaxParameteriv", typeof(Delegates.glGetMinmaxParameteriv));
        public static Delegates.glHistogram glHistogram = (Delegates.glHistogram)GetAddress("glHistogram", typeof(Delegates.glHistogram));
        public static Delegates.glMinmax glMinmax = (Delegates.glMinmax)GetAddress("glMinmax", typeof(Delegates.glMinmax));
        public static Delegates.glResetHistogram glResetHistogram = (Delegates.glResetHistogram)GetAddress("glResetHistogram", typeof(Delegates.glResetHistogram));
        public static Delegates.glResetMinmax glResetMinmax = (Delegates.glResetMinmax)GetAddress("glResetMinmax", typeof(Delegates.glResetMinmax));
        public static Delegates.glTexImage3D_ glTexImage3D_ = (Delegates.glTexImage3D_)GetAddress("glTexImage3D", typeof(Delegates.glTexImage3D_));
        public static Delegates.glTexSubImage3D_ glTexSubImage3D_ = (Delegates.glTexSubImage3D_)GetAddress("glTexSubImage3D", typeof(Delegates.glTexSubImage3D_));
        public static Delegates.glCopyTexSubImage3D glCopyTexSubImage3D = (Delegates.glCopyTexSubImage3D)GetAddress("glCopyTexSubImage3D", typeof(Delegates.glCopyTexSubImage3D));
        public static Delegates.glActiveTexture glActiveTexture = (Delegates.glActiveTexture)GetAddress("glActiveTexture", typeof(Delegates.glActiveTexture));
        public static Delegates.glClientActiveTexture glClientActiveTexture = (Delegates.glClientActiveTexture)GetAddress("glClientActiveTexture", typeof(Delegates.glClientActiveTexture));
        public static Delegates.glMultiTexCoord1d glMultiTexCoord1d = (Delegates.glMultiTexCoord1d)GetAddress("glMultiTexCoord1d", typeof(Delegates.glMultiTexCoord1d));
        public static Delegates.glMultiTexCoord1dv_ glMultiTexCoord1dv_ = (Delegates.glMultiTexCoord1dv_)GetAddress("glMultiTexCoord1dv", typeof(Delegates.glMultiTexCoord1dv_));
        public static Delegates.glMultiTexCoord1f glMultiTexCoord1f = (Delegates.glMultiTexCoord1f)GetAddress("glMultiTexCoord1f", typeof(Delegates.glMultiTexCoord1f));
        public static Delegates.glMultiTexCoord1fv_ glMultiTexCoord1fv_ = (Delegates.glMultiTexCoord1fv_)GetAddress("glMultiTexCoord1fv", typeof(Delegates.glMultiTexCoord1fv_));
        public static Delegates.glMultiTexCoord1i glMultiTexCoord1i = (Delegates.glMultiTexCoord1i)GetAddress("glMultiTexCoord1i", typeof(Delegates.glMultiTexCoord1i));
        public static Delegates.glMultiTexCoord1iv_ glMultiTexCoord1iv_ = (Delegates.glMultiTexCoord1iv_)GetAddress("glMultiTexCoord1iv", typeof(Delegates.glMultiTexCoord1iv_));
        public static Delegates.glMultiTexCoord1s glMultiTexCoord1s = (Delegates.glMultiTexCoord1s)GetAddress("glMultiTexCoord1s", typeof(Delegates.glMultiTexCoord1s));
        public static Delegates.glMultiTexCoord1sv_ glMultiTexCoord1sv_ = (Delegates.glMultiTexCoord1sv_)GetAddress("glMultiTexCoord1sv", typeof(Delegates.glMultiTexCoord1sv_));
        public static Delegates.glMultiTexCoord2d glMultiTexCoord2d = (Delegates.glMultiTexCoord2d)GetAddress("glMultiTexCoord2d", typeof(Delegates.glMultiTexCoord2d));
        public static Delegates.glMultiTexCoord2dv_ glMultiTexCoord2dv_ = (Delegates.glMultiTexCoord2dv_)GetAddress("glMultiTexCoord2dv", typeof(Delegates.glMultiTexCoord2dv_));
        public static Delegates.glMultiTexCoord2f glMultiTexCoord2f = (Delegates.glMultiTexCoord2f)GetAddress("glMultiTexCoord2f", typeof(Delegates.glMultiTexCoord2f));
        public static Delegates.glMultiTexCoord2fv_ glMultiTexCoord2fv_ = (Delegates.glMultiTexCoord2fv_)GetAddress("glMultiTexCoord2fv", typeof(Delegates.glMultiTexCoord2fv_));
        public static Delegates.glMultiTexCoord2i glMultiTexCoord2i = (Delegates.glMultiTexCoord2i)GetAddress("glMultiTexCoord2i", typeof(Delegates.glMultiTexCoord2i));
        public static Delegates.glMultiTexCoord2iv_ glMultiTexCoord2iv_ = (Delegates.glMultiTexCoord2iv_)GetAddress("glMultiTexCoord2iv", typeof(Delegates.glMultiTexCoord2iv_));
        public static Delegates.glMultiTexCoord2s glMultiTexCoord2s = (Delegates.glMultiTexCoord2s)GetAddress("glMultiTexCoord2s", typeof(Delegates.glMultiTexCoord2s));
        public static Delegates.glMultiTexCoord2sv_ glMultiTexCoord2sv_ = (Delegates.glMultiTexCoord2sv_)GetAddress("glMultiTexCoord2sv", typeof(Delegates.glMultiTexCoord2sv_));
        public static Delegates.glMultiTexCoord3d glMultiTexCoord3d = (Delegates.glMultiTexCoord3d)GetAddress("glMultiTexCoord3d", typeof(Delegates.glMultiTexCoord3d));
        public static Delegates.glMultiTexCoord3dv_ glMultiTexCoord3dv_ = (Delegates.glMultiTexCoord3dv_)GetAddress("glMultiTexCoord3dv", typeof(Delegates.glMultiTexCoord3dv_));
        public static Delegates.glMultiTexCoord3f glMultiTexCoord3f = (Delegates.glMultiTexCoord3f)GetAddress("glMultiTexCoord3f", typeof(Delegates.glMultiTexCoord3f));
        public static Delegates.glMultiTexCoord3fv_ glMultiTexCoord3fv_ = (Delegates.glMultiTexCoord3fv_)GetAddress("glMultiTexCoord3fv", typeof(Delegates.glMultiTexCoord3fv_));
        public static Delegates.glMultiTexCoord3i glMultiTexCoord3i = (Delegates.glMultiTexCoord3i)GetAddress("glMultiTexCoord3i", typeof(Delegates.glMultiTexCoord3i));
        public static Delegates.glMultiTexCoord3iv_ glMultiTexCoord3iv_ = (Delegates.glMultiTexCoord3iv_)GetAddress("glMultiTexCoord3iv", typeof(Delegates.glMultiTexCoord3iv_));
        public static Delegates.glMultiTexCoord3s glMultiTexCoord3s = (Delegates.glMultiTexCoord3s)GetAddress("glMultiTexCoord3s", typeof(Delegates.glMultiTexCoord3s));
        public static Delegates.glMultiTexCoord3sv_ glMultiTexCoord3sv_ = (Delegates.glMultiTexCoord3sv_)GetAddress("glMultiTexCoord3sv", typeof(Delegates.glMultiTexCoord3sv_));
        public static Delegates.glMultiTexCoord4d glMultiTexCoord4d = (Delegates.glMultiTexCoord4d)GetAddress("glMultiTexCoord4d", typeof(Delegates.glMultiTexCoord4d));
        public static Delegates.glMultiTexCoord4dv_ glMultiTexCoord4dv_ = (Delegates.glMultiTexCoord4dv_)GetAddress("glMultiTexCoord4dv", typeof(Delegates.glMultiTexCoord4dv_));
        public static Delegates.glMultiTexCoord4f glMultiTexCoord4f = (Delegates.glMultiTexCoord4f)GetAddress("glMultiTexCoord4f", typeof(Delegates.glMultiTexCoord4f));
        public static Delegates.glMultiTexCoord4fv_ glMultiTexCoord4fv_ = (Delegates.glMultiTexCoord4fv_)GetAddress("glMultiTexCoord4fv", typeof(Delegates.glMultiTexCoord4fv_));
        public static Delegates.glMultiTexCoord4i glMultiTexCoord4i = (Delegates.glMultiTexCoord4i)GetAddress("glMultiTexCoord4i", typeof(Delegates.glMultiTexCoord4i));
        public static Delegates.glMultiTexCoord4iv_ glMultiTexCoord4iv_ = (Delegates.glMultiTexCoord4iv_)GetAddress("glMultiTexCoord4iv", typeof(Delegates.glMultiTexCoord4iv_));
        public static Delegates.glMultiTexCoord4s glMultiTexCoord4s = (Delegates.glMultiTexCoord4s)GetAddress("glMultiTexCoord4s", typeof(Delegates.glMultiTexCoord4s));
        public static Delegates.glMultiTexCoord4sv_ glMultiTexCoord4sv_ = (Delegates.glMultiTexCoord4sv_)GetAddress("glMultiTexCoord4sv", typeof(Delegates.glMultiTexCoord4sv_));
        public static Delegates.glLoadTransposeMatrixf_ glLoadTransposeMatrixf_ = (Delegates.glLoadTransposeMatrixf_)GetAddress("glLoadTransposeMatrixf", typeof(Delegates.glLoadTransposeMatrixf_));
        public static Delegates.glLoadTransposeMatrixd_ glLoadTransposeMatrixd_ = (Delegates.glLoadTransposeMatrixd_)GetAddress("glLoadTransposeMatrixd", typeof(Delegates.glLoadTransposeMatrixd_));
        public static Delegates.glMultTransposeMatrixf_ glMultTransposeMatrixf_ = (Delegates.glMultTransposeMatrixf_)GetAddress("glMultTransposeMatrixf", typeof(Delegates.glMultTransposeMatrixf_));
        public static Delegates.glMultTransposeMatrixd_ glMultTransposeMatrixd_ = (Delegates.glMultTransposeMatrixd_)GetAddress("glMultTransposeMatrixd", typeof(Delegates.glMultTransposeMatrixd_));
        public static Delegates.glSampleCoverage glSampleCoverage = (Delegates.glSampleCoverage)GetAddress("glSampleCoverage", typeof(Delegates.glSampleCoverage));
        public static Delegates.glCompressedTexImage3D_ glCompressedTexImage3D_ = (Delegates.glCompressedTexImage3D_)GetAddress("glCompressedTexImage3D", typeof(Delegates.glCompressedTexImage3D_));
        public static Delegates.glCompressedTexImage2D_ glCompressedTexImage2D_ = (Delegates.glCompressedTexImage2D_)GetAddress("glCompressedTexImage2D", typeof(Delegates.glCompressedTexImage2D_));
        public static Delegates.glCompressedTexImage1D_ glCompressedTexImage1D_ = (Delegates.glCompressedTexImage1D_)GetAddress("glCompressedTexImage1D", typeof(Delegates.glCompressedTexImage1D_));
        public static Delegates.glCompressedTexSubImage3D_ glCompressedTexSubImage3D_ = (Delegates.glCompressedTexSubImage3D_)GetAddress("glCompressedTexSubImage3D", typeof(Delegates.glCompressedTexSubImage3D_));
        public static Delegates.glCompressedTexSubImage2D_ glCompressedTexSubImage2D_ = (Delegates.glCompressedTexSubImage2D_)GetAddress("glCompressedTexSubImage2D", typeof(Delegates.glCompressedTexSubImage2D_));
        public static Delegates.glCompressedTexSubImage1D_ glCompressedTexSubImage1D_ = (Delegates.glCompressedTexSubImage1D_)GetAddress("glCompressedTexSubImage1D", typeof(Delegates.glCompressedTexSubImage1D_));
        public static Delegates.glGetCompressedTexImage_ glGetCompressedTexImage_ = (Delegates.glGetCompressedTexImage_)GetAddress("glGetCompressedTexImage", typeof(Delegates.glGetCompressedTexImage_));
        public static Delegates.glBlendFuncSeparate glBlendFuncSeparate = (Delegates.glBlendFuncSeparate)GetAddress("glBlendFuncSeparate", typeof(Delegates.glBlendFuncSeparate));
        public static Delegates.glFogCoordf glFogCoordf = (Delegates.glFogCoordf)GetAddress("glFogCoordf", typeof(Delegates.glFogCoordf));
        public static Delegates.glFogCoordfv_ glFogCoordfv_ = (Delegates.glFogCoordfv_)GetAddress("glFogCoordfv", typeof(Delegates.glFogCoordfv_));
        public static Delegates.glFogCoordd glFogCoordd = (Delegates.glFogCoordd)GetAddress("glFogCoordd", typeof(Delegates.glFogCoordd));
        public static Delegates.glFogCoorddv_ glFogCoorddv_ = (Delegates.glFogCoorddv_)GetAddress("glFogCoorddv", typeof(Delegates.glFogCoorddv_));
        public static Delegates.glFogCoordPointer_ glFogCoordPointer_ = (Delegates.glFogCoordPointer_)GetAddress("glFogCoordPointer", typeof(Delegates.glFogCoordPointer_));
        public static Delegates.glMultiDrawArrays glMultiDrawArrays = (Delegates.glMultiDrawArrays)GetAddress("glMultiDrawArrays", typeof(Delegates.glMultiDrawArrays));
        public static Delegates.glMultiDrawElements_ glMultiDrawElements_ = (Delegates.glMultiDrawElements_)GetAddress("glMultiDrawElements", typeof(Delegates.glMultiDrawElements_));
        public static Delegates.glPointParameterf glPointParameterf = (Delegates.glPointParameterf)GetAddress("glPointParameterf", typeof(Delegates.glPointParameterf));
        public static Delegates.glPointParameterfv_ glPointParameterfv_ = (Delegates.glPointParameterfv_)GetAddress("glPointParameterfv", typeof(Delegates.glPointParameterfv_));
        public static Delegates.glPointParameteri glPointParameteri = (Delegates.glPointParameteri)GetAddress("glPointParameteri", typeof(Delegates.glPointParameteri));
        public static Delegates.glPointParameteriv_ glPointParameteriv_ = (Delegates.glPointParameteriv_)GetAddress("glPointParameteriv", typeof(Delegates.glPointParameteriv_));
        public static Delegates.glSecondaryColor3b glSecondaryColor3b = (Delegates.glSecondaryColor3b)GetAddress("glSecondaryColor3b", typeof(Delegates.glSecondaryColor3b));
        public static Delegates.glSecondaryColor3bv_ glSecondaryColor3bv_ = (Delegates.glSecondaryColor3bv_)GetAddress("glSecondaryColor3bv", typeof(Delegates.glSecondaryColor3bv_));
        public static Delegates.glSecondaryColor3d glSecondaryColor3d = (Delegates.glSecondaryColor3d)GetAddress("glSecondaryColor3d", typeof(Delegates.glSecondaryColor3d));
        public static Delegates.glSecondaryColor3dv_ glSecondaryColor3dv_ = (Delegates.glSecondaryColor3dv_)GetAddress("glSecondaryColor3dv", typeof(Delegates.glSecondaryColor3dv_));
        public static Delegates.glSecondaryColor3f glSecondaryColor3f = (Delegates.glSecondaryColor3f)GetAddress("glSecondaryColor3f", typeof(Delegates.glSecondaryColor3f));
        public static Delegates.glSecondaryColor3fv_ glSecondaryColor3fv_ = (Delegates.glSecondaryColor3fv_)GetAddress("glSecondaryColor3fv", typeof(Delegates.glSecondaryColor3fv_));
        public static Delegates.glSecondaryColor3i glSecondaryColor3i = (Delegates.glSecondaryColor3i)GetAddress("glSecondaryColor3i", typeof(Delegates.glSecondaryColor3i));
        public static Delegates.glSecondaryColor3iv_ glSecondaryColor3iv_ = (Delegates.glSecondaryColor3iv_)GetAddress("glSecondaryColor3iv", typeof(Delegates.glSecondaryColor3iv_));
        public static Delegates.glSecondaryColor3s glSecondaryColor3s = (Delegates.glSecondaryColor3s)GetAddress("glSecondaryColor3s", typeof(Delegates.glSecondaryColor3s));
        public static Delegates.glSecondaryColor3sv_ glSecondaryColor3sv_ = (Delegates.glSecondaryColor3sv_)GetAddress("glSecondaryColor3sv", typeof(Delegates.glSecondaryColor3sv_));
        public static Delegates.glSecondaryColor3ub glSecondaryColor3ub = (Delegates.glSecondaryColor3ub)GetAddress("glSecondaryColor3ub", typeof(Delegates.glSecondaryColor3ub));
        public static Delegates.glSecondaryColor3ubv_ glSecondaryColor3ubv_ = (Delegates.glSecondaryColor3ubv_)GetAddress("glSecondaryColor3ubv", typeof(Delegates.glSecondaryColor3ubv_));
        public static Delegates.glSecondaryColor3ui glSecondaryColor3ui = (Delegates.glSecondaryColor3ui)GetAddress("glSecondaryColor3ui", typeof(Delegates.glSecondaryColor3ui));
        public static Delegates.glSecondaryColor3uiv_ glSecondaryColor3uiv_ = (Delegates.glSecondaryColor3uiv_)GetAddress("glSecondaryColor3uiv", typeof(Delegates.glSecondaryColor3uiv_));
        public static Delegates.glSecondaryColor3us glSecondaryColor3us = (Delegates.glSecondaryColor3us)GetAddress("glSecondaryColor3us", typeof(Delegates.glSecondaryColor3us));
        public static Delegates.glSecondaryColor3usv_ glSecondaryColor3usv_ = (Delegates.glSecondaryColor3usv_)GetAddress("glSecondaryColor3usv", typeof(Delegates.glSecondaryColor3usv_));
        public static Delegates.glSecondaryColorPointer_ glSecondaryColorPointer_ = (Delegates.glSecondaryColorPointer_)GetAddress("glSecondaryColorPointer", typeof(Delegates.glSecondaryColorPointer_));
        public static Delegates.glWindowPos2d glWindowPos2d = (Delegates.glWindowPos2d)GetAddress("glWindowPos2d", typeof(Delegates.glWindowPos2d));
        public static Delegates.glWindowPos2dv_ glWindowPos2dv_ = (Delegates.glWindowPos2dv_)GetAddress("glWindowPos2dv", typeof(Delegates.glWindowPos2dv_));
        public static Delegates.glWindowPos2f glWindowPos2f = (Delegates.glWindowPos2f)GetAddress("glWindowPos2f", typeof(Delegates.glWindowPos2f));
        public static Delegates.glWindowPos2fv_ glWindowPos2fv_ = (Delegates.glWindowPos2fv_)GetAddress("glWindowPos2fv", typeof(Delegates.glWindowPos2fv_));
        public static Delegates.glWindowPos2i glWindowPos2i = (Delegates.glWindowPos2i)GetAddress("glWindowPos2i", typeof(Delegates.glWindowPos2i));
        public static Delegates.glWindowPos2iv_ glWindowPos2iv_ = (Delegates.glWindowPos2iv_)GetAddress("glWindowPos2iv", typeof(Delegates.glWindowPos2iv_));
        public static Delegates.glWindowPos2s glWindowPos2s = (Delegates.glWindowPos2s)GetAddress("glWindowPos2s", typeof(Delegates.glWindowPos2s));
        public static Delegates.glWindowPos2sv_ glWindowPos2sv_ = (Delegates.glWindowPos2sv_)GetAddress("glWindowPos2sv", typeof(Delegates.glWindowPos2sv_));
        public static Delegates.glWindowPos3d glWindowPos3d = (Delegates.glWindowPos3d)GetAddress("glWindowPos3d", typeof(Delegates.glWindowPos3d));
        public static Delegates.glWindowPos3dv_ glWindowPos3dv_ = (Delegates.glWindowPos3dv_)GetAddress("glWindowPos3dv", typeof(Delegates.glWindowPos3dv_));
        public static Delegates.glWindowPos3f glWindowPos3f = (Delegates.glWindowPos3f)GetAddress("glWindowPos3f", typeof(Delegates.glWindowPos3f));
        public static Delegates.glWindowPos3fv_ glWindowPos3fv_ = (Delegates.glWindowPos3fv_)GetAddress("glWindowPos3fv", typeof(Delegates.glWindowPos3fv_));
        public static Delegates.glWindowPos3i glWindowPos3i = (Delegates.glWindowPos3i)GetAddress("glWindowPos3i", typeof(Delegates.glWindowPos3i));
        public static Delegates.glWindowPos3iv_ glWindowPos3iv_ = (Delegates.glWindowPos3iv_)GetAddress("glWindowPos3iv", typeof(Delegates.glWindowPos3iv_));
        public static Delegates.glWindowPos3s glWindowPos3s = (Delegates.glWindowPos3s)GetAddress("glWindowPos3s", typeof(Delegates.glWindowPos3s));
        public static Delegates.glWindowPos3sv_ glWindowPos3sv_ = (Delegates.glWindowPos3sv_)GetAddress("glWindowPos3sv", typeof(Delegates.glWindowPos3sv_));
        public static Delegates.glGenQueries glGenQueries = (Delegates.glGenQueries)GetAddress("glGenQueries", typeof(Delegates.glGenQueries));
        public static Delegates.glDeleteQueries_ glDeleteQueries_ = (Delegates.glDeleteQueries_)GetAddress("glDeleteQueries", typeof(Delegates.glDeleteQueries_));
        public static Delegates.glIsQuery glIsQuery = (Delegates.glIsQuery)GetAddress("glIsQuery", typeof(Delegates.glIsQuery));
        public static Delegates.glBeginQuery glBeginQuery = (Delegates.glBeginQuery)GetAddress("glBeginQuery", typeof(Delegates.glBeginQuery));
        public static Delegates.glEndQuery glEndQuery = (Delegates.glEndQuery)GetAddress("glEndQuery", typeof(Delegates.glEndQuery));
        public static Delegates.glGetQueryiv glGetQueryiv = (Delegates.glGetQueryiv)GetAddress("glGetQueryiv", typeof(Delegates.glGetQueryiv));
        public static Delegates.glGetQueryObjectiv glGetQueryObjectiv = (Delegates.glGetQueryObjectiv)GetAddress("glGetQueryObjectiv", typeof(Delegates.glGetQueryObjectiv));
        public static Delegates.glGetQueryObjectuiv glGetQueryObjectuiv = (Delegates.glGetQueryObjectuiv)GetAddress("glGetQueryObjectuiv", typeof(Delegates.glGetQueryObjectuiv));
        public static Delegates.glBindBuffer glBindBuffer = (Delegates.glBindBuffer)GetAddress("glBindBuffer", typeof(Delegates.glBindBuffer));
        public static Delegates.glDeleteBuffers_ glDeleteBuffers_ = (Delegates.glDeleteBuffers_)GetAddress("glDeleteBuffers", typeof(Delegates.glDeleteBuffers_));
        public static Delegates.glGenBuffers glGenBuffers = (Delegates.glGenBuffers)GetAddress("glGenBuffers", typeof(Delegates.glGenBuffers));
        public static Delegates.glIsBuffer glIsBuffer = (Delegates.glIsBuffer)GetAddress("glIsBuffer", typeof(Delegates.glIsBuffer));
        public static Delegates.glBufferData_ glBufferData_ = (Delegates.glBufferData_)GetAddress("glBufferData", typeof(Delegates.glBufferData_));
        public static Delegates.glBufferSubData_ glBufferSubData_ = (Delegates.glBufferSubData_)GetAddress("glBufferSubData", typeof(Delegates.glBufferSubData_));
        public static Delegates.glGetBufferSubData_ glGetBufferSubData_ = (Delegates.glGetBufferSubData_)GetAddress("glGetBufferSubData", typeof(Delegates.glGetBufferSubData_));
        public static Delegates.glMapBuffer glMapBuffer = (Delegates.glMapBuffer)GetAddress("glMapBuffer", typeof(Delegates.glMapBuffer));
        public static Delegates.glUnmapBuffer glUnmapBuffer = (Delegates.glUnmapBuffer)GetAddress("glUnmapBuffer", typeof(Delegates.glUnmapBuffer));
        public static Delegates.glGetBufferParameteriv glGetBufferParameteriv = (Delegates.glGetBufferParameteriv)GetAddress("glGetBufferParameteriv", typeof(Delegates.glGetBufferParameteriv));
        public static Delegates.glGetBufferPointerv glGetBufferPointerv = (Delegates.glGetBufferPointerv)GetAddress("glGetBufferPointerv", typeof(Delegates.glGetBufferPointerv));
        public static Delegates.glBlendEquationSeparate glBlendEquationSeparate = (Delegates.glBlendEquationSeparate)GetAddress("glBlendEquationSeparate", typeof(Delegates.glBlendEquationSeparate));
        public static Delegates.glDrawBuffers_ glDrawBuffers_ = (Delegates.glDrawBuffers_)GetAddress("glDrawBuffers", typeof(Delegates.glDrawBuffers_));
        public static Delegates.glStencilOpSeparate glStencilOpSeparate = (Delegates.glStencilOpSeparate)GetAddress("glStencilOpSeparate", typeof(Delegates.glStencilOpSeparate));
        public static Delegates.glStencilFuncSeparate glStencilFuncSeparate = (Delegates.glStencilFuncSeparate)GetAddress("glStencilFuncSeparate", typeof(Delegates.glStencilFuncSeparate));
        public static Delegates.glStencilMaskSeparate glStencilMaskSeparate = (Delegates.glStencilMaskSeparate)GetAddress("glStencilMaskSeparate", typeof(Delegates.glStencilMaskSeparate));
        public static Delegates.glAttachShader glAttachShader = (Delegates.glAttachShader)GetAddress("glAttachShader", typeof(Delegates.glAttachShader));
        public static Delegates.glBindAttribLocation_ glBindAttribLocation_ = (Delegates.glBindAttribLocation_)GetAddress("glBindAttribLocation", typeof(Delegates.glBindAttribLocation_));
        public static Delegates.glCompileShader glCompileShader = (Delegates.glCompileShader)GetAddress("glCompileShader", typeof(Delegates.glCompileShader));
        public static Delegates.glCreateProgram glCreateProgram = (Delegates.glCreateProgram)GetAddress("glCreateProgram", typeof(Delegates.glCreateProgram));
        public static Delegates.glCreateShader glCreateShader = (Delegates.glCreateShader)GetAddress("glCreateShader", typeof(Delegates.glCreateShader));
        public static Delegates.glDeleteProgram glDeleteProgram = (Delegates.glDeleteProgram)GetAddress("glDeleteProgram", typeof(Delegates.glDeleteProgram));
        public static Delegates.glDeleteShader glDeleteShader = (Delegates.glDeleteShader)GetAddress("glDeleteShader", typeof(Delegates.glDeleteShader));
        public static Delegates.glDetachShader glDetachShader = (Delegates.glDetachShader)GetAddress("glDetachShader", typeof(Delegates.glDetachShader));
        public static Delegates.glDisableVertexAttribArray glDisableVertexAttribArray = (Delegates.glDisableVertexAttribArray)GetAddress("glDisableVertexAttribArray", typeof(Delegates.glDisableVertexAttribArray));
        public static Delegates.glEnableVertexAttribArray glEnableVertexAttribArray = (Delegates.glEnableVertexAttribArray)GetAddress("glEnableVertexAttribArray", typeof(Delegates.glEnableVertexAttribArray));
        public static Delegates.glGetActiveAttrib glGetActiveAttrib = (Delegates.glGetActiveAttrib)GetAddress("glGetActiveAttrib", typeof(Delegates.glGetActiveAttrib));
        public static Delegates.glGetActiveUniform glGetActiveUniform = (Delegates.glGetActiveUniform)GetAddress("glGetActiveUniform", typeof(Delegates.glGetActiveUniform));
        public static Delegates.glGetAttachedShaders glGetAttachedShaders = (Delegates.glGetAttachedShaders)GetAddress("glGetAttachedShaders", typeof(Delegates.glGetAttachedShaders));
        public static Delegates.glGetAttribLocation_ glGetAttribLocation_ = (Delegates.glGetAttribLocation_)GetAddress("glGetAttribLocation", typeof(Delegates.glGetAttribLocation_));
        public static Delegates.glGetProgramiv glGetProgramiv = (Delegates.glGetProgramiv)GetAddress("glGetProgramiv", typeof(Delegates.glGetProgramiv));
        public static Delegates.glGetProgramInfoLog glGetProgramInfoLog = (Delegates.glGetProgramInfoLog)GetAddress("glGetProgramInfoLog", typeof(Delegates.glGetProgramInfoLog));
        public static Delegates.glGetShaderiv glGetShaderiv = (Delegates.glGetShaderiv)GetAddress("glGetShaderiv", typeof(Delegates.glGetShaderiv));
        public static Delegates.glGetShaderInfoLog glGetShaderInfoLog = (Delegates.glGetShaderInfoLog)GetAddress("glGetShaderInfoLog", typeof(Delegates.glGetShaderInfoLog));
        public static Delegates.glGetShaderSource glGetShaderSource = (Delegates.glGetShaderSource)GetAddress("glGetShaderSource", typeof(Delegates.glGetShaderSource));
        public static Delegates.glGetUniformLocation_ glGetUniformLocation_ = (Delegates.glGetUniformLocation_)GetAddress("glGetUniformLocation", typeof(Delegates.glGetUniformLocation_));
        public static Delegates.glGetUniformfv glGetUniformfv = (Delegates.glGetUniformfv)GetAddress("glGetUniformfv", typeof(Delegates.glGetUniformfv));
        public static Delegates.glGetUniformiv glGetUniformiv = (Delegates.glGetUniformiv)GetAddress("glGetUniformiv", typeof(Delegates.glGetUniformiv));
        public static Delegates.glGetVertexAttribdv glGetVertexAttribdv = (Delegates.glGetVertexAttribdv)GetAddress("glGetVertexAttribdv", typeof(Delegates.glGetVertexAttribdv));
        public static Delegates.glGetVertexAttribfv glGetVertexAttribfv = (Delegates.glGetVertexAttribfv)GetAddress("glGetVertexAttribfv", typeof(Delegates.glGetVertexAttribfv));
        public static Delegates.glGetVertexAttribiv glGetVertexAttribiv = (Delegates.glGetVertexAttribiv)GetAddress("glGetVertexAttribiv", typeof(Delegates.glGetVertexAttribiv));
        public static Delegates.glGetVertexAttribPointerv glGetVertexAttribPointerv = (Delegates.glGetVertexAttribPointerv)GetAddress("glGetVertexAttribPointerv", typeof(Delegates.glGetVertexAttribPointerv));
        public static Delegates.glIsProgram glIsProgram = (Delegates.glIsProgram)GetAddress("glIsProgram", typeof(Delegates.glIsProgram));
        public static Delegates.glIsShader glIsShader = (Delegates.glIsShader)GetAddress("glIsShader", typeof(Delegates.glIsShader));
        public static Delegates.glLinkProgram glLinkProgram = (Delegates.glLinkProgram)GetAddress("glLinkProgram", typeof(Delegates.glLinkProgram));
        public static Delegates.glShaderSource_ glShaderSource_ = (Delegates.glShaderSource_)GetAddress("glShaderSource", typeof(Delegates.glShaderSource_));
        public static Delegates.glUseProgram glUseProgram = (Delegates.glUseProgram)GetAddress("glUseProgram", typeof(Delegates.glUseProgram));
        public static Delegates.glUniform1f glUniform1f = (Delegates.glUniform1f)GetAddress("glUniform1f", typeof(Delegates.glUniform1f));
        public static Delegates.glUniform2f glUniform2f = (Delegates.glUniform2f)GetAddress("glUniform2f", typeof(Delegates.glUniform2f));
        public static Delegates.glUniform3f glUniform3f = (Delegates.glUniform3f)GetAddress("glUniform3f", typeof(Delegates.glUniform3f));
        public static Delegates.glUniform4f glUniform4f = (Delegates.glUniform4f)GetAddress("glUniform4f", typeof(Delegates.glUniform4f));
        public static Delegates.glUniform1i glUniform1i = (Delegates.glUniform1i)GetAddress("glUniform1i", typeof(Delegates.glUniform1i));
        public static Delegates.glUniform2i glUniform2i = (Delegates.glUniform2i)GetAddress("glUniform2i", typeof(Delegates.glUniform2i));
        public static Delegates.glUniform3i glUniform3i = (Delegates.glUniform3i)GetAddress("glUniform3i", typeof(Delegates.glUniform3i));
        public static Delegates.glUniform4i glUniform4i = (Delegates.glUniform4i)GetAddress("glUniform4i", typeof(Delegates.glUniform4i));
        public static Delegates.glUniform1fv_ glUniform1fv_ = (Delegates.glUniform1fv_)GetAddress("glUniform1fv", typeof(Delegates.glUniform1fv_));
        public static Delegates.glUniform2fv_ glUniform2fv_ = (Delegates.glUniform2fv_)GetAddress("glUniform2fv", typeof(Delegates.glUniform2fv_));
        public static Delegates.glUniform3fv_ glUniform3fv_ = (Delegates.glUniform3fv_)GetAddress("glUniform3fv", typeof(Delegates.glUniform3fv_));
        public static Delegates.glUniform4fv_ glUniform4fv_ = (Delegates.glUniform4fv_)GetAddress("glUniform4fv", typeof(Delegates.glUniform4fv_));
        public static Delegates.glUniform1iv_ glUniform1iv_ = (Delegates.glUniform1iv_)GetAddress("glUniform1iv", typeof(Delegates.glUniform1iv_));
        public static Delegates.glUniform2iv_ glUniform2iv_ = (Delegates.glUniform2iv_)GetAddress("glUniform2iv", typeof(Delegates.glUniform2iv_));
        public static Delegates.glUniform3iv_ glUniform3iv_ = (Delegates.glUniform3iv_)GetAddress("glUniform3iv", typeof(Delegates.glUniform3iv_));
        public static Delegates.glUniform4iv_ glUniform4iv_ = (Delegates.glUniform4iv_)GetAddress("glUniform4iv", typeof(Delegates.glUniform4iv_));
        public static Delegates.glUniformMatrix2fv_ glUniformMatrix2fv_ = (Delegates.glUniformMatrix2fv_)GetAddress("glUniformMatrix2fv", typeof(Delegates.glUniformMatrix2fv_));
        public static Delegates.glUniformMatrix3fv_ glUniformMatrix3fv_ = (Delegates.glUniformMatrix3fv_)GetAddress("glUniformMatrix3fv", typeof(Delegates.glUniformMatrix3fv_));
        public static Delegates.glUniformMatrix4fv_ glUniformMatrix4fv_ = (Delegates.glUniformMatrix4fv_)GetAddress("glUniformMatrix4fv", typeof(Delegates.glUniformMatrix4fv_));
        public static Delegates.glValidateProgram glValidateProgram = (Delegates.glValidateProgram)GetAddress("glValidateProgram", typeof(Delegates.glValidateProgram));
        public static Delegates.glVertexAttrib1d glVertexAttrib1d = (Delegates.glVertexAttrib1d)GetAddress("glVertexAttrib1d", typeof(Delegates.glVertexAttrib1d));
        public static Delegates.glVertexAttrib1dv_ glVertexAttrib1dv_ = (Delegates.glVertexAttrib1dv_)GetAddress("glVertexAttrib1dv", typeof(Delegates.glVertexAttrib1dv_));
        public static Delegates.glVertexAttrib1f glVertexAttrib1f = (Delegates.glVertexAttrib1f)GetAddress("glVertexAttrib1f", typeof(Delegates.glVertexAttrib1f));
        public static Delegates.glVertexAttrib1fv_ glVertexAttrib1fv_ = (Delegates.glVertexAttrib1fv_)GetAddress("glVertexAttrib1fv", typeof(Delegates.glVertexAttrib1fv_));
        public static Delegates.glVertexAttrib1s glVertexAttrib1s = (Delegates.glVertexAttrib1s)GetAddress("glVertexAttrib1s", typeof(Delegates.glVertexAttrib1s));
        public static Delegates.glVertexAttrib1sv_ glVertexAttrib1sv_ = (Delegates.glVertexAttrib1sv_)GetAddress("glVertexAttrib1sv", typeof(Delegates.glVertexAttrib1sv_));
        public static Delegates.glVertexAttrib2d glVertexAttrib2d = (Delegates.glVertexAttrib2d)GetAddress("glVertexAttrib2d", typeof(Delegates.glVertexAttrib2d));
        public static Delegates.glVertexAttrib2dv_ glVertexAttrib2dv_ = (Delegates.glVertexAttrib2dv_)GetAddress("glVertexAttrib2dv", typeof(Delegates.glVertexAttrib2dv_));
        public static Delegates.glVertexAttrib2f glVertexAttrib2f = (Delegates.glVertexAttrib2f)GetAddress("glVertexAttrib2f", typeof(Delegates.glVertexAttrib2f));
        public static Delegates.glVertexAttrib2fv_ glVertexAttrib2fv_ = (Delegates.glVertexAttrib2fv_)GetAddress("glVertexAttrib2fv", typeof(Delegates.glVertexAttrib2fv_));
        public static Delegates.glVertexAttrib2s glVertexAttrib2s = (Delegates.glVertexAttrib2s)GetAddress("glVertexAttrib2s", typeof(Delegates.glVertexAttrib2s));
        public static Delegates.glVertexAttrib2sv_ glVertexAttrib2sv_ = (Delegates.glVertexAttrib2sv_)GetAddress("glVertexAttrib2sv", typeof(Delegates.glVertexAttrib2sv_));
        public static Delegates.glVertexAttrib3d glVertexAttrib3d = (Delegates.glVertexAttrib3d)GetAddress("glVertexAttrib3d", typeof(Delegates.glVertexAttrib3d));
        public static Delegates.glVertexAttrib3dv_ glVertexAttrib3dv_ = (Delegates.glVertexAttrib3dv_)GetAddress("glVertexAttrib3dv", typeof(Delegates.glVertexAttrib3dv_));
        public static Delegates.glVertexAttrib3f glVertexAttrib3f = (Delegates.glVertexAttrib3f)GetAddress("glVertexAttrib3f", typeof(Delegates.glVertexAttrib3f));
        public static Delegates.glVertexAttrib3fv_ glVertexAttrib3fv_ = (Delegates.glVertexAttrib3fv_)GetAddress("glVertexAttrib3fv", typeof(Delegates.glVertexAttrib3fv_));
        public static Delegates.glVertexAttrib3s glVertexAttrib3s = (Delegates.glVertexAttrib3s)GetAddress("glVertexAttrib3s", typeof(Delegates.glVertexAttrib3s));
        public static Delegates.glVertexAttrib3sv_ glVertexAttrib3sv_ = (Delegates.glVertexAttrib3sv_)GetAddress("glVertexAttrib3sv", typeof(Delegates.glVertexAttrib3sv_));
        public static Delegates.glVertexAttrib4Nbv_ glVertexAttrib4Nbv_ = (Delegates.glVertexAttrib4Nbv_)GetAddress("glVertexAttrib4Nbv", typeof(Delegates.glVertexAttrib4Nbv_));
        public static Delegates.glVertexAttrib4Niv_ glVertexAttrib4Niv_ = (Delegates.glVertexAttrib4Niv_)GetAddress("glVertexAttrib4Niv", typeof(Delegates.glVertexAttrib4Niv_));
        public static Delegates.glVertexAttrib4Nsv_ glVertexAttrib4Nsv_ = (Delegates.glVertexAttrib4Nsv_)GetAddress("glVertexAttrib4Nsv", typeof(Delegates.glVertexAttrib4Nsv_));
        public static Delegates.glVertexAttrib4Nub glVertexAttrib4Nub = (Delegates.glVertexAttrib4Nub)GetAddress("glVertexAttrib4Nub", typeof(Delegates.glVertexAttrib4Nub));
        public static Delegates.glVertexAttrib4Nubv_ glVertexAttrib4Nubv_ = (Delegates.glVertexAttrib4Nubv_)GetAddress("glVertexAttrib4Nubv", typeof(Delegates.glVertexAttrib4Nubv_));
        public static Delegates.glVertexAttrib4Nuiv_ glVertexAttrib4Nuiv_ = (Delegates.glVertexAttrib4Nuiv_)GetAddress("glVertexAttrib4Nuiv", typeof(Delegates.glVertexAttrib4Nuiv_));
        public static Delegates.glVertexAttrib4Nusv_ glVertexAttrib4Nusv_ = (Delegates.glVertexAttrib4Nusv_)GetAddress("glVertexAttrib4Nusv", typeof(Delegates.glVertexAttrib4Nusv_));
        public static Delegates.glVertexAttrib4bv_ glVertexAttrib4bv_ = (Delegates.glVertexAttrib4bv_)GetAddress("glVertexAttrib4bv", typeof(Delegates.glVertexAttrib4bv_));
        public static Delegates.glVertexAttrib4d glVertexAttrib4d = (Delegates.glVertexAttrib4d)GetAddress("glVertexAttrib4d", typeof(Delegates.glVertexAttrib4d));
        public static Delegates.glVertexAttrib4dv_ glVertexAttrib4dv_ = (Delegates.glVertexAttrib4dv_)GetAddress("glVertexAttrib4dv", typeof(Delegates.glVertexAttrib4dv_));
        public static Delegates.glVertexAttrib4f glVertexAttrib4f = (Delegates.glVertexAttrib4f)GetAddress("glVertexAttrib4f", typeof(Delegates.glVertexAttrib4f));
        public static Delegates.glVertexAttrib4fv_ glVertexAttrib4fv_ = (Delegates.glVertexAttrib4fv_)GetAddress("glVertexAttrib4fv", typeof(Delegates.glVertexAttrib4fv_));
        public static Delegates.glVertexAttrib4iv_ glVertexAttrib4iv_ = (Delegates.glVertexAttrib4iv_)GetAddress("glVertexAttrib4iv", typeof(Delegates.glVertexAttrib4iv_));
        public static Delegates.glVertexAttrib4s glVertexAttrib4s = (Delegates.glVertexAttrib4s)GetAddress("glVertexAttrib4s", typeof(Delegates.glVertexAttrib4s));
        public static Delegates.glVertexAttrib4sv_ glVertexAttrib4sv_ = (Delegates.glVertexAttrib4sv_)GetAddress("glVertexAttrib4sv", typeof(Delegates.glVertexAttrib4sv_));
        public static Delegates.glVertexAttrib4ubv_ glVertexAttrib4ubv_ = (Delegates.glVertexAttrib4ubv_)GetAddress("glVertexAttrib4ubv", typeof(Delegates.glVertexAttrib4ubv_));
        public static Delegates.glVertexAttrib4uiv_ glVertexAttrib4uiv_ = (Delegates.glVertexAttrib4uiv_)GetAddress("glVertexAttrib4uiv", typeof(Delegates.glVertexAttrib4uiv_));
        public static Delegates.glVertexAttrib4usv_ glVertexAttrib4usv_ = (Delegates.glVertexAttrib4usv_)GetAddress("glVertexAttrib4usv", typeof(Delegates.glVertexAttrib4usv_));
        public static Delegates.glVertexAttribPointer_ glVertexAttribPointer_ = (Delegates.glVertexAttribPointer_)GetAddress("glVertexAttribPointer", typeof(Delegates.glVertexAttribPointer_));
        public static Delegates.glActiveTextureARB glActiveTextureARB = (Delegates.glActiveTextureARB)GetAddress("glActiveTextureARB", typeof(Delegates.glActiveTextureARB));
        public static Delegates.glClientActiveTextureARB glClientActiveTextureARB = (Delegates.glClientActiveTextureARB)GetAddress("glClientActiveTextureARB", typeof(Delegates.glClientActiveTextureARB));
        public static Delegates.glMultiTexCoord1dARB glMultiTexCoord1dARB = (Delegates.glMultiTexCoord1dARB)GetAddress("glMultiTexCoord1dARB", typeof(Delegates.glMultiTexCoord1dARB));
        public static Delegates.glMultiTexCoord1dvARB_ glMultiTexCoord1dvARB_ = (Delegates.glMultiTexCoord1dvARB_)GetAddress("glMultiTexCoord1dvARB", typeof(Delegates.glMultiTexCoord1dvARB_));
        public static Delegates.glMultiTexCoord1fARB glMultiTexCoord1fARB = (Delegates.glMultiTexCoord1fARB)GetAddress("glMultiTexCoord1fARB", typeof(Delegates.glMultiTexCoord1fARB));
        public static Delegates.glMultiTexCoord1fvARB_ glMultiTexCoord1fvARB_ = (Delegates.glMultiTexCoord1fvARB_)GetAddress("glMultiTexCoord1fvARB", typeof(Delegates.glMultiTexCoord1fvARB_));
        public static Delegates.glMultiTexCoord1iARB glMultiTexCoord1iARB = (Delegates.glMultiTexCoord1iARB)GetAddress("glMultiTexCoord1iARB", typeof(Delegates.glMultiTexCoord1iARB));
        public static Delegates.glMultiTexCoord1ivARB_ glMultiTexCoord1ivARB_ = (Delegates.glMultiTexCoord1ivARB_)GetAddress("glMultiTexCoord1ivARB", typeof(Delegates.glMultiTexCoord1ivARB_));
        public static Delegates.glMultiTexCoord1sARB glMultiTexCoord1sARB = (Delegates.glMultiTexCoord1sARB)GetAddress("glMultiTexCoord1sARB", typeof(Delegates.glMultiTexCoord1sARB));
        public static Delegates.glMultiTexCoord1svARB_ glMultiTexCoord1svARB_ = (Delegates.glMultiTexCoord1svARB_)GetAddress("glMultiTexCoord1svARB", typeof(Delegates.glMultiTexCoord1svARB_));
        public static Delegates.glMultiTexCoord2dARB glMultiTexCoord2dARB = (Delegates.glMultiTexCoord2dARB)GetAddress("glMultiTexCoord2dARB", typeof(Delegates.glMultiTexCoord2dARB));
        public static Delegates.glMultiTexCoord2dvARB_ glMultiTexCoord2dvARB_ = (Delegates.glMultiTexCoord2dvARB_)GetAddress("glMultiTexCoord2dvARB", typeof(Delegates.glMultiTexCoord2dvARB_));
        public static Delegates.glMultiTexCoord2fARB glMultiTexCoord2fARB = (Delegates.glMultiTexCoord2fARB)GetAddress("glMultiTexCoord2fARB", typeof(Delegates.glMultiTexCoord2fARB));
        public static Delegates.glMultiTexCoord2fvARB_ glMultiTexCoord2fvARB_ = (Delegates.glMultiTexCoord2fvARB_)GetAddress("glMultiTexCoord2fvARB", typeof(Delegates.glMultiTexCoord2fvARB_));
        public static Delegates.glMultiTexCoord2iARB glMultiTexCoord2iARB = (Delegates.glMultiTexCoord2iARB)GetAddress("glMultiTexCoord2iARB", typeof(Delegates.glMultiTexCoord2iARB));
        public static Delegates.glMultiTexCoord2ivARB_ glMultiTexCoord2ivARB_ = (Delegates.glMultiTexCoord2ivARB_)GetAddress("glMultiTexCoord2ivARB", typeof(Delegates.glMultiTexCoord2ivARB_));
        public static Delegates.glMultiTexCoord2sARB glMultiTexCoord2sARB = (Delegates.glMultiTexCoord2sARB)GetAddress("glMultiTexCoord2sARB", typeof(Delegates.glMultiTexCoord2sARB));
        public static Delegates.glMultiTexCoord2svARB_ glMultiTexCoord2svARB_ = (Delegates.glMultiTexCoord2svARB_)GetAddress("glMultiTexCoord2svARB", typeof(Delegates.glMultiTexCoord2svARB_));
        public static Delegates.glMultiTexCoord3dARB glMultiTexCoord3dARB = (Delegates.glMultiTexCoord3dARB)GetAddress("glMultiTexCoord3dARB", typeof(Delegates.glMultiTexCoord3dARB));
        public static Delegates.glMultiTexCoord3dvARB_ glMultiTexCoord3dvARB_ = (Delegates.glMultiTexCoord3dvARB_)GetAddress("glMultiTexCoord3dvARB", typeof(Delegates.glMultiTexCoord3dvARB_));
        public static Delegates.glMultiTexCoord3fARB glMultiTexCoord3fARB = (Delegates.glMultiTexCoord3fARB)GetAddress("glMultiTexCoord3fARB", typeof(Delegates.glMultiTexCoord3fARB));
        public static Delegates.glMultiTexCoord3fvARB_ glMultiTexCoord3fvARB_ = (Delegates.glMultiTexCoord3fvARB_)GetAddress("glMultiTexCoord3fvARB", typeof(Delegates.glMultiTexCoord3fvARB_));
        public static Delegates.glMultiTexCoord3iARB glMultiTexCoord3iARB = (Delegates.glMultiTexCoord3iARB)GetAddress("glMultiTexCoord3iARB", typeof(Delegates.glMultiTexCoord3iARB));
        public static Delegates.glMultiTexCoord3ivARB_ glMultiTexCoord3ivARB_ = (Delegates.glMultiTexCoord3ivARB_)GetAddress("glMultiTexCoord3ivARB", typeof(Delegates.glMultiTexCoord3ivARB_));
        public static Delegates.glMultiTexCoord3sARB glMultiTexCoord3sARB = (Delegates.glMultiTexCoord3sARB)GetAddress("glMultiTexCoord3sARB", typeof(Delegates.glMultiTexCoord3sARB));
        public static Delegates.glMultiTexCoord3svARB_ glMultiTexCoord3svARB_ = (Delegates.glMultiTexCoord3svARB_)GetAddress("glMultiTexCoord3svARB", typeof(Delegates.glMultiTexCoord3svARB_));
        public static Delegates.glMultiTexCoord4dARB glMultiTexCoord4dARB = (Delegates.glMultiTexCoord4dARB)GetAddress("glMultiTexCoord4dARB", typeof(Delegates.glMultiTexCoord4dARB));
        public static Delegates.glMultiTexCoord4dvARB_ glMultiTexCoord4dvARB_ = (Delegates.glMultiTexCoord4dvARB_)GetAddress("glMultiTexCoord4dvARB", typeof(Delegates.glMultiTexCoord4dvARB_));
        public static Delegates.glMultiTexCoord4fARB glMultiTexCoord4fARB = (Delegates.glMultiTexCoord4fARB)GetAddress("glMultiTexCoord4fARB", typeof(Delegates.glMultiTexCoord4fARB));
        public static Delegates.glMultiTexCoord4fvARB_ glMultiTexCoord4fvARB_ = (Delegates.glMultiTexCoord4fvARB_)GetAddress("glMultiTexCoord4fvARB", typeof(Delegates.glMultiTexCoord4fvARB_));
        public static Delegates.glMultiTexCoord4iARB glMultiTexCoord4iARB = (Delegates.glMultiTexCoord4iARB)GetAddress("glMultiTexCoord4iARB", typeof(Delegates.glMultiTexCoord4iARB));
        public static Delegates.glMultiTexCoord4ivARB_ glMultiTexCoord4ivARB_ = (Delegates.glMultiTexCoord4ivARB_)GetAddress("glMultiTexCoord4ivARB", typeof(Delegates.glMultiTexCoord4ivARB_));
        public static Delegates.glMultiTexCoord4sARB glMultiTexCoord4sARB = (Delegates.glMultiTexCoord4sARB)GetAddress("glMultiTexCoord4sARB", typeof(Delegates.glMultiTexCoord4sARB));
        public static Delegates.glMultiTexCoord4svARB_ glMultiTexCoord4svARB_ = (Delegates.glMultiTexCoord4svARB_)GetAddress("glMultiTexCoord4svARB", typeof(Delegates.glMultiTexCoord4svARB_));
        public static Delegates.glLoadTransposeMatrixfARB_ glLoadTransposeMatrixfARB_ = (Delegates.glLoadTransposeMatrixfARB_)GetAddress("glLoadTransposeMatrixfARB", typeof(Delegates.glLoadTransposeMatrixfARB_));
        public static Delegates.glLoadTransposeMatrixdARB_ glLoadTransposeMatrixdARB_ = (Delegates.glLoadTransposeMatrixdARB_)GetAddress("glLoadTransposeMatrixdARB", typeof(Delegates.glLoadTransposeMatrixdARB_));
        public static Delegates.glMultTransposeMatrixfARB_ glMultTransposeMatrixfARB_ = (Delegates.glMultTransposeMatrixfARB_)GetAddress("glMultTransposeMatrixfARB", typeof(Delegates.glMultTransposeMatrixfARB_));
        public static Delegates.glMultTransposeMatrixdARB_ glMultTransposeMatrixdARB_ = (Delegates.glMultTransposeMatrixdARB_)GetAddress("glMultTransposeMatrixdARB", typeof(Delegates.glMultTransposeMatrixdARB_));
        public static Delegates.glSampleCoverageARB glSampleCoverageARB = (Delegates.glSampleCoverageARB)GetAddress("glSampleCoverageARB", typeof(Delegates.glSampleCoverageARB));
        public static Delegates.glCompressedTexImage3DARB_ glCompressedTexImage3DARB_ = (Delegates.glCompressedTexImage3DARB_)GetAddress("glCompressedTexImage3DARB", typeof(Delegates.glCompressedTexImage3DARB_));
        public static Delegates.glCompressedTexImage2DARB_ glCompressedTexImage2DARB_ = (Delegates.glCompressedTexImage2DARB_)GetAddress("glCompressedTexImage2DARB", typeof(Delegates.glCompressedTexImage2DARB_));
        public static Delegates.glCompressedTexImage1DARB_ glCompressedTexImage1DARB_ = (Delegates.glCompressedTexImage1DARB_)GetAddress("glCompressedTexImage1DARB", typeof(Delegates.glCompressedTexImage1DARB_));
        public static Delegates.glCompressedTexSubImage3DARB_ glCompressedTexSubImage3DARB_ = (Delegates.glCompressedTexSubImage3DARB_)GetAddress("glCompressedTexSubImage3DARB", typeof(Delegates.glCompressedTexSubImage3DARB_));
        public static Delegates.glCompressedTexSubImage2DARB_ glCompressedTexSubImage2DARB_ = (Delegates.glCompressedTexSubImage2DARB_)GetAddress("glCompressedTexSubImage2DARB", typeof(Delegates.glCompressedTexSubImage2DARB_));
        public static Delegates.glCompressedTexSubImage1DARB_ glCompressedTexSubImage1DARB_ = (Delegates.glCompressedTexSubImage1DARB_)GetAddress("glCompressedTexSubImage1DARB", typeof(Delegates.glCompressedTexSubImage1DARB_));
        public static Delegates.glGetCompressedTexImageARB_ glGetCompressedTexImageARB_ = (Delegates.glGetCompressedTexImageARB_)GetAddress("glGetCompressedTexImageARB", typeof(Delegates.glGetCompressedTexImageARB_));
        public static Delegates.glPointParameterfARB glPointParameterfARB = (Delegates.glPointParameterfARB)GetAddress("glPointParameterfARB", typeof(Delegates.glPointParameterfARB));
        public static Delegates.glPointParameterfvARB_ glPointParameterfvARB_ = (Delegates.glPointParameterfvARB_)GetAddress("glPointParameterfvARB", typeof(Delegates.glPointParameterfvARB_));
        public static Delegates.glWeightbvARB_ glWeightbvARB_ = (Delegates.glWeightbvARB_)GetAddress("glWeightbvARB", typeof(Delegates.glWeightbvARB_));
        public static Delegates.glWeightsvARB_ glWeightsvARB_ = (Delegates.glWeightsvARB_)GetAddress("glWeightsvARB", typeof(Delegates.glWeightsvARB_));
        public static Delegates.glWeightivARB_ glWeightivARB_ = (Delegates.glWeightivARB_)GetAddress("glWeightivARB", typeof(Delegates.glWeightivARB_));
        public static Delegates.glWeightfvARB_ glWeightfvARB_ = (Delegates.glWeightfvARB_)GetAddress("glWeightfvARB", typeof(Delegates.glWeightfvARB_));
        public static Delegates.glWeightdvARB_ glWeightdvARB_ = (Delegates.glWeightdvARB_)GetAddress("glWeightdvARB", typeof(Delegates.glWeightdvARB_));
        public static Delegates.glWeightubvARB_ glWeightubvARB_ = (Delegates.glWeightubvARB_)GetAddress("glWeightubvARB", typeof(Delegates.glWeightubvARB_));
        public static Delegates.glWeightusvARB_ glWeightusvARB_ = (Delegates.glWeightusvARB_)GetAddress("glWeightusvARB", typeof(Delegates.glWeightusvARB_));
        public static Delegates.glWeightuivARB_ glWeightuivARB_ = (Delegates.glWeightuivARB_)GetAddress("glWeightuivARB", typeof(Delegates.glWeightuivARB_));
        public static Delegates.glWeightPointerARB_ glWeightPointerARB_ = (Delegates.glWeightPointerARB_)GetAddress("glWeightPointerARB", typeof(Delegates.glWeightPointerARB_));
        public static Delegates.glVertexBlendARB glVertexBlendARB = (Delegates.glVertexBlendARB)GetAddress("glVertexBlendARB", typeof(Delegates.glVertexBlendARB));
        public static Delegates.glCurrentPaletteMatrixARB glCurrentPaletteMatrixARB = (Delegates.glCurrentPaletteMatrixARB)GetAddress("glCurrentPaletteMatrixARB", typeof(Delegates.glCurrentPaletteMatrixARB));
        public static Delegates.glMatrixIndexubvARB_ glMatrixIndexubvARB_ = (Delegates.glMatrixIndexubvARB_)GetAddress("glMatrixIndexubvARB", typeof(Delegates.glMatrixIndexubvARB_));
        public static Delegates.glMatrixIndexusvARB_ glMatrixIndexusvARB_ = (Delegates.glMatrixIndexusvARB_)GetAddress("glMatrixIndexusvARB", typeof(Delegates.glMatrixIndexusvARB_));
        public static Delegates.glMatrixIndexuivARB_ glMatrixIndexuivARB_ = (Delegates.glMatrixIndexuivARB_)GetAddress("glMatrixIndexuivARB", typeof(Delegates.glMatrixIndexuivARB_));
        public static Delegates.glMatrixIndexPointerARB_ glMatrixIndexPointerARB_ = (Delegates.glMatrixIndexPointerARB_)GetAddress("glMatrixIndexPointerARB", typeof(Delegates.glMatrixIndexPointerARB_));
        public static Delegates.glWindowPos2dARB glWindowPos2dARB = (Delegates.glWindowPos2dARB)GetAddress("glWindowPos2dARB", typeof(Delegates.glWindowPos2dARB));
        public static Delegates.glWindowPos2dvARB_ glWindowPos2dvARB_ = (Delegates.glWindowPos2dvARB_)GetAddress("glWindowPos2dvARB", typeof(Delegates.glWindowPos2dvARB_));
        public static Delegates.glWindowPos2fARB glWindowPos2fARB = (Delegates.glWindowPos2fARB)GetAddress("glWindowPos2fARB", typeof(Delegates.glWindowPos2fARB));
        public static Delegates.glWindowPos2fvARB_ glWindowPos2fvARB_ = (Delegates.glWindowPos2fvARB_)GetAddress("glWindowPos2fvARB", typeof(Delegates.glWindowPos2fvARB_));
        public static Delegates.glWindowPos2iARB glWindowPos2iARB = (Delegates.glWindowPos2iARB)GetAddress("glWindowPos2iARB", typeof(Delegates.glWindowPos2iARB));
        public static Delegates.glWindowPos2ivARB_ glWindowPos2ivARB_ = (Delegates.glWindowPos2ivARB_)GetAddress("glWindowPos2ivARB", typeof(Delegates.glWindowPos2ivARB_));
        public static Delegates.glWindowPos2sARB glWindowPos2sARB = (Delegates.glWindowPos2sARB)GetAddress("glWindowPos2sARB", typeof(Delegates.glWindowPos2sARB));
        public static Delegates.glWindowPos2svARB_ glWindowPos2svARB_ = (Delegates.glWindowPos2svARB_)GetAddress("glWindowPos2svARB", typeof(Delegates.glWindowPos2svARB_));
        public static Delegates.glWindowPos3dARB glWindowPos3dARB = (Delegates.glWindowPos3dARB)GetAddress("glWindowPos3dARB", typeof(Delegates.glWindowPos3dARB));
        public static Delegates.glWindowPos3dvARB_ glWindowPos3dvARB_ = (Delegates.glWindowPos3dvARB_)GetAddress("glWindowPos3dvARB", typeof(Delegates.glWindowPos3dvARB_));
        public static Delegates.glWindowPos3fARB glWindowPos3fARB = (Delegates.glWindowPos3fARB)GetAddress("glWindowPos3fARB", typeof(Delegates.glWindowPos3fARB));
        public static Delegates.glWindowPos3fvARB_ glWindowPos3fvARB_ = (Delegates.glWindowPos3fvARB_)GetAddress("glWindowPos3fvARB", typeof(Delegates.glWindowPos3fvARB_));
        public static Delegates.glWindowPos3iARB glWindowPos3iARB = (Delegates.glWindowPos3iARB)GetAddress("glWindowPos3iARB", typeof(Delegates.glWindowPos3iARB));
        public static Delegates.glWindowPos3ivARB_ glWindowPos3ivARB_ = (Delegates.glWindowPos3ivARB_)GetAddress("glWindowPos3ivARB", typeof(Delegates.glWindowPos3ivARB_));
        public static Delegates.glWindowPos3sARB glWindowPos3sARB = (Delegates.glWindowPos3sARB)GetAddress("glWindowPos3sARB", typeof(Delegates.glWindowPos3sARB));
        public static Delegates.glWindowPos3svARB_ glWindowPos3svARB_ = (Delegates.glWindowPos3svARB_)GetAddress("glWindowPos3svARB", typeof(Delegates.glWindowPos3svARB_));
        public static Delegates.glVertexAttrib1dARB glVertexAttrib1dARB = (Delegates.glVertexAttrib1dARB)GetAddress("glVertexAttrib1dARB", typeof(Delegates.glVertexAttrib1dARB));
        public static Delegates.glVertexAttrib1dvARB_ glVertexAttrib1dvARB_ = (Delegates.glVertexAttrib1dvARB_)GetAddress("glVertexAttrib1dvARB", typeof(Delegates.glVertexAttrib1dvARB_));
        public static Delegates.glVertexAttrib1fARB glVertexAttrib1fARB = (Delegates.glVertexAttrib1fARB)GetAddress("glVertexAttrib1fARB", typeof(Delegates.glVertexAttrib1fARB));
        public static Delegates.glVertexAttrib1fvARB_ glVertexAttrib1fvARB_ = (Delegates.glVertexAttrib1fvARB_)GetAddress("glVertexAttrib1fvARB", typeof(Delegates.glVertexAttrib1fvARB_));
        public static Delegates.glVertexAttrib1sARB glVertexAttrib1sARB = (Delegates.glVertexAttrib1sARB)GetAddress("glVertexAttrib1sARB", typeof(Delegates.glVertexAttrib1sARB));
        public static Delegates.glVertexAttrib1svARB_ glVertexAttrib1svARB_ = (Delegates.glVertexAttrib1svARB_)GetAddress("glVertexAttrib1svARB", typeof(Delegates.glVertexAttrib1svARB_));
        public static Delegates.glVertexAttrib2dARB glVertexAttrib2dARB = (Delegates.glVertexAttrib2dARB)GetAddress("glVertexAttrib2dARB", typeof(Delegates.glVertexAttrib2dARB));
        public static Delegates.glVertexAttrib2dvARB_ glVertexAttrib2dvARB_ = (Delegates.glVertexAttrib2dvARB_)GetAddress("glVertexAttrib2dvARB", typeof(Delegates.glVertexAttrib2dvARB_));
        public static Delegates.glVertexAttrib2fARB glVertexAttrib2fARB = (Delegates.glVertexAttrib2fARB)GetAddress("glVertexAttrib2fARB", typeof(Delegates.glVertexAttrib2fARB));
        public static Delegates.glVertexAttrib2fvARB_ glVertexAttrib2fvARB_ = (Delegates.glVertexAttrib2fvARB_)GetAddress("glVertexAttrib2fvARB", typeof(Delegates.glVertexAttrib2fvARB_));
        public static Delegates.glVertexAttrib2sARB glVertexAttrib2sARB = (Delegates.glVertexAttrib2sARB)GetAddress("glVertexAttrib2sARB", typeof(Delegates.glVertexAttrib2sARB));
        public static Delegates.glVertexAttrib2svARB_ glVertexAttrib2svARB_ = (Delegates.glVertexAttrib2svARB_)GetAddress("glVertexAttrib2svARB", typeof(Delegates.glVertexAttrib2svARB_));
        public static Delegates.glVertexAttrib3dARB glVertexAttrib3dARB = (Delegates.glVertexAttrib3dARB)GetAddress("glVertexAttrib3dARB", typeof(Delegates.glVertexAttrib3dARB));
        public static Delegates.glVertexAttrib3dvARB_ glVertexAttrib3dvARB_ = (Delegates.glVertexAttrib3dvARB_)GetAddress("glVertexAttrib3dvARB", typeof(Delegates.glVertexAttrib3dvARB_));
        public static Delegates.glVertexAttrib3fARB glVertexAttrib3fARB = (Delegates.glVertexAttrib3fARB)GetAddress("glVertexAttrib3fARB", typeof(Delegates.glVertexAttrib3fARB));
        public static Delegates.glVertexAttrib3fvARB_ glVertexAttrib3fvARB_ = (Delegates.glVertexAttrib3fvARB_)GetAddress("glVertexAttrib3fvARB", typeof(Delegates.glVertexAttrib3fvARB_));
        public static Delegates.glVertexAttrib3sARB glVertexAttrib3sARB = (Delegates.glVertexAttrib3sARB)GetAddress("glVertexAttrib3sARB", typeof(Delegates.glVertexAttrib3sARB));
        public static Delegates.glVertexAttrib3svARB_ glVertexAttrib3svARB_ = (Delegates.glVertexAttrib3svARB_)GetAddress("glVertexAttrib3svARB", typeof(Delegates.glVertexAttrib3svARB_));
        public static Delegates.glVertexAttrib4NbvARB_ glVertexAttrib4NbvARB_ = (Delegates.glVertexAttrib4NbvARB_)GetAddress("glVertexAttrib4NbvARB", typeof(Delegates.glVertexAttrib4NbvARB_));
        public static Delegates.glVertexAttrib4NivARB_ glVertexAttrib4NivARB_ = (Delegates.glVertexAttrib4NivARB_)GetAddress("glVertexAttrib4NivARB", typeof(Delegates.glVertexAttrib4NivARB_));
        public static Delegates.glVertexAttrib4NsvARB_ glVertexAttrib4NsvARB_ = (Delegates.glVertexAttrib4NsvARB_)GetAddress("glVertexAttrib4NsvARB", typeof(Delegates.glVertexAttrib4NsvARB_));
        public static Delegates.glVertexAttrib4NubARB glVertexAttrib4NubARB = (Delegates.glVertexAttrib4NubARB)GetAddress("glVertexAttrib4NubARB", typeof(Delegates.glVertexAttrib4NubARB));
        public static Delegates.glVertexAttrib4NubvARB_ glVertexAttrib4NubvARB_ = (Delegates.glVertexAttrib4NubvARB_)GetAddress("glVertexAttrib4NubvARB", typeof(Delegates.glVertexAttrib4NubvARB_));
        public static Delegates.glVertexAttrib4NuivARB_ glVertexAttrib4NuivARB_ = (Delegates.glVertexAttrib4NuivARB_)GetAddress("glVertexAttrib4NuivARB", typeof(Delegates.glVertexAttrib4NuivARB_));
        public static Delegates.glVertexAttrib4NusvARB_ glVertexAttrib4NusvARB_ = (Delegates.glVertexAttrib4NusvARB_)GetAddress("glVertexAttrib4NusvARB", typeof(Delegates.glVertexAttrib4NusvARB_));
        public static Delegates.glVertexAttrib4bvARB_ glVertexAttrib4bvARB_ = (Delegates.glVertexAttrib4bvARB_)GetAddress("glVertexAttrib4bvARB", typeof(Delegates.glVertexAttrib4bvARB_));
        public static Delegates.glVertexAttrib4dARB glVertexAttrib4dARB = (Delegates.glVertexAttrib4dARB)GetAddress("glVertexAttrib4dARB", typeof(Delegates.glVertexAttrib4dARB));
        public static Delegates.glVertexAttrib4dvARB_ glVertexAttrib4dvARB_ = (Delegates.glVertexAttrib4dvARB_)GetAddress("glVertexAttrib4dvARB", typeof(Delegates.glVertexAttrib4dvARB_));
        public static Delegates.glVertexAttrib4fARB glVertexAttrib4fARB = (Delegates.glVertexAttrib4fARB)GetAddress("glVertexAttrib4fARB", typeof(Delegates.glVertexAttrib4fARB));
        public static Delegates.glVertexAttrib4fvARB_ glVertexAttrib4fvARB_ = (Delegates.glVertexAttrib4fvARB_)GetAddress("glVertexAttrib4fvARB", typeof(Delegates.glVertexAttrib4fvARB_));
        public static Delegates.glVertexAttrib4ivARB_ glVertexAttrib4ivARB_ = (Delegates.glVertexAttrib4ivARB_)GetAddress("glVertexAttrib4ivARB", typeof(Delegates.glVertexAttrib4ivARB_));
        public static Delegates.glVertexAttrib4sARB glVertexAttrib4sARB = (Delegates.glVertexAttrib4sARB)GetAddress("glVertexAttrib4sARB", typeof(Delegates.glVertexAttrib4sARB));
        public static Delegates.glVertexAttrib4svARB_ glVertexAttrib4svARB_ = (Delegates.glVertexAttrib4svARB_)GetAddress("glVertexAttrib4svARB", typeof(Delegates.glVertexAttrib4svARB_));
        public static Delegates.glVertexAttrib4ubvARB_ glVertexAttrib4ubvARB_ = (Delegates.glVertexAttrib4ubvARB_)GetAddress("glVertexAttrib4ubvARB", typeof(Delegates.glVertexAttrib4ubvARB_));
        public static Delegates.glVertexAttrib4uivARB_ glVertexAttrib4uivARB_ = (Delegates.glVertexAttrib4uivARB_)GetAddress("glVertexAttrib4uivARB", typeof(Delegates.glVertexAttrib4uivARB_));
        public static Delegates.glVertexAttrib4usvARB_ glVertexAttrib4usvARB_ = (Delegates.glVertexAttrib4usvARB_)GetAddress("glVertexAttrib4usvARB", typeof(Delegates.glVertexAttrib4usvARB_));
        public static Delegates.glVertexAttribPointerARB_ glVertexAttribPointerARB_ = (Delegates.glVertexAttribPointerARB_)GetAddress("glVertexAttribPointerARB", typeof(Delegates.glVertexAttribPointerARB_));
        public static Delegates.glEnableVertexAttribArrayARB glEnableVertexAttribArrayARB = (Delegates.glEnableVertexAttribArrayARB)GetAddress("glEnableVertexAttribArrayARB", typeof(Delegates.glEnableVertexAttribArrayARB));
        public static Delegates.glDisableVertexAttribArrayARB glDisableVertexAttribArrayARB = (Delegates.glDisableVertexAttribArrayARB)GetAddress("glDisableVertexAttribArrayARB", typeof(Delegates.glDisableVertexAttribArrayARB));
        public static Delegates.glProgramStringARB_ glProgramStringARB_ = (Delegates.glProgramStringARB_)GetAddress("glProgramStringARB", typeof(Delegates.glProgramStringARB_));
        public static Delegates.glBindProgramARB glBindProgramARB = (Delegates.glBindProgramARB)GetAddress("glBindProgramARB", typeof(Delegates.glBindProgramARB));
        public static Delegates.glDeleteProgramsARB_ glDeleteProgramsARB_ = (Delegates.glDeleteProgramsARB_)GetAddress("glDeleteProgramsARB", typeof(Delegates.glDeleteProgramsARB_));
        public static Delegates.glGenProgramsARB glGenProgramsARB = (Delegates.glGenProgramsARB)GetAddress("glGenProgramsARB", typeof(Delegates.glGenProgramsARB));
        public static Delegates.glProgramEnvParameter4dARB glProgramEnvParameter4dARB = (Delegates.glProgramEnvParameter4dARB)GetAddress("glProgramEnvParameter4dARB", typeof(Delegates.glProgramEnvParameter4dARB));
        public static Delegates.glProgramEnvParameter4dvARB_ glProgramEnvParameter4dvARB_ = (Delegates.glProgramEnvParameter4dvARB_)GetAddress("glProgramEnvParameter4dvARB", typeof(Delegates.glProgramEnvParameter4dvARB_));
        public static Delegates.glProgramEnvParameter4fARB glProgramEnvParameter4fARB = (Delegates.glProgramEnvParameter4fARB)GetAddress("glProgramEnvParameter4fARB", typeof(Delegates.glProgramEnvParameter4fARB));
        public static Delegates.glProgramEnvParameter4fvARB_ glProgramEnvParameter4fvARB_ = (Delegates.glProgramEnvParameter4fvARB_)GetAddress("glProgramEnvParameter4fvARB", typeof(Delegates.glProgramEnvParameter4fvARB_));
        public static Delegates.glProgramLocalParameter4dARB glProgramLocalParameter4dARB = (Delegates.glProgramLocalParameter4dARB)GetAddress("glProgramLocalParameter4dARB", typeof(Delegates.glProgramLocalParameter4dARB));
        public static Delegates.glProgramLocalParameter4dvARB_ glProgramLocalParameter4dvARB_ = (Delegates.glProgramLocalParameter4dvARB_)GetAddress("glProgramLocalParameter4dvARB", typeof(Delegates.glProgramLocalParameter4dvARB_));
        public static Delegates.glProgramLocalParameter4fARB glProgramLocalParameter4fARB = (Delegates.glProgramLocalParameter4fARB)GetAddress("glProgramLocalParameter4fARB", typeof(Delegates.glProgramLocalParameter4fARB));
        public static Delegates.glProgramLocalParameter4fvARB_ glProgramLocalParameter4fvARB_ = (Delegates.glProgramLocalParameter4fvARB_)GetAddress("glProgramLocalParameter4fvARB", typeof(Delegates.glProgramLocalParameter4fvARB_));
        public static Delegates.glGetProgramEnvParameterdvARB glGetProgramEnvParameterdvARB = (Delegates.glGetProgramEnvParameterdvARB)GetAddress("glGetProgramEnvParameterdvARB", typeof(Delegates.glGetProgramEnvParameterdvARB));
        public static Delegates.glGetProgramEnvParameterfvARB glGetProgramEnvParameterfvARB = (Delegates.glGetProgramEnvParameterfvARB)GetAddress("glGetProgramEnvParameterfvARB", typeof(Delegates.glGetProgramEnvParameterfvARB));
        public static Delegates.glGetProgramLocalParameterdvARB glGetProgramLocalParameterdvARB = (Delegates.glGetProgramLocalParameterdvARB)GetAddress("glGetProgramLocalParameterdvARB", typeof(Delegates.glGetProgramLocalParameterdvARB));
        public static Delegates.glGetProgramLocalParameterfvARB glGetProgramLocalParameterfvARB = (Delegates.glGetProgramLocalParameterfvARB)GetAddress("glGetProgramLocalParameterfvARB", typeof(Delegates.glGetProgramLocalParameterfvARB));
        public static Delegates.glGetProgramivARB glGetProgramivARB = (Delegates.glGetProgramivARB)GetAddress("glGetProgramivARB", typeof(Delegates.glGetProgramivARB));
        public static Delegates.glGetProgramStringARB_ glGetProgramStringARB_ = (Delegates.glGetProgramStringARB_)GetAddress("glGetProgramStringARB", typeof(Delegates.glGetProgramStringARB_));
        public static Delegates.glGetVertexAttribdvARB glGetVertexAttribdvARB = (Delegates.glGetVertexAttribdvARB)GetAddress("glGetVertexAttribdvARB", typeof(Delegates.glGetVertexAttribdvARB));
        public static Delegates.glGetVertexAttribfvARB glGetVertexAttribfvARB = (Delegates.glGetVertexAttribfvARB)GetAddress("glGetVertexAttribfvARB", typeof(Delegates.glGetVertexAttribfvARB));
        public static Delegates.glGetVertexAttribivARB glGetVertexAttribivARB = (Delegates.glGetVertexAttribivARB)GetAddress("glGetVertexAttribivARB", typeof(Delegates.glGetVertexAttribivARB));
        public static Delegates.glGetVertexAttribPointervARB glGetVertexAttribPointervARB = (Delegates.glGetVertexAttribPointervARB)GetAddress("glGetVertexAttribPointervARB", typeof(Delegates.glGetVertexAttribPointervARB));
        public static Delegates.glIsProgramARB glIsProgramARB = (Delegates.glIsProgramARB)GetAddress("glIsProgramARB", typeof(Delegates.glIsProgramARB));
        public static Delegates.glBindBufferARB glBindBufferARB = (Delegates.glBindBufferARB)GetAddress("glBindBufferARB", typeof(Delegates.glBindBufferARB));
        public static Delegates.glDeleteBuffersARB_ glDeleteBuffersARB_ = (Delegates.glDeleteBuffersARB_)GetAddress("glDeleteBuffersARB", typeof(Delegates.glDeleteBuffersARB_));
        public static Delegates.glGenBuffersARB glGenBuffersARB = (Delegates.glGenBuffersARB)GetAddress("glGenBuffersARB", typeof(Delegates.glGenBuffersARB));
        public static Delegates.glIsBufferARB glIsBufferARB = (Delegates.glIsBufferARB)GetAddress("glIsBufferARB", typeof(Delegates.glIsBufferARB));
        public static Delegates.glBufferDataARB_ glBufferDataARB_ = (Delegates.glBufferDataARB_)GetAddress("glBufferDataARB", typeof(Delegates.glBufferDataARB_));
        public static Delegates.glBufferSubDataARB_ glBufferSubDataARB_ = (Delegates.glBufferSubDataARB_)GetAddress("glBufferSubDataARB", typeof(Delegates.glBufferSubDataARB_));
        public static Delegates.glGetBufferSubDataARB_ glGetBufferSubDataARB_ = (Delegates.glGetBufferSubDataARB_)GetAddress("glGetBufferSubDataARB", typeof(Delegates.glGetBufferSubDataARB_));
        public static Delegates.glMapBufferARB glMapBufferARB = (Delegates.glMapBufferARB)GetAddress("glMapBufferARB", typeof(Delegates.glMapBufferARB));
        public static Delegates.glUnmapBufferARB glUnmapBufferARB = (Delegates.glUnmapBufferARB)GetAddress("glUnmapBufferARB", typeof(Delegates.glUnmapBufferARB));
        public static Delegates.glGetBufferParameterivARB glGetBufferParameterivARB = (Delegates.glGetBufferParameterivARB)GetAddress("glGetBufferParameterivARB", typeof(Delegates.glGetBufferParameterivARB));
        public static Delegates.glGetBufferPointervARB glGetBufferPointervARB = (Delegates.glGetBufferPointervARB)GetAddress("glGetBufferPointervARB", typeof(Delegates.glGetBufferPointervARB));
        public static Delegates.glGenQueriesARB glGenQueriesARB = (Delegates.glGenQueriesARB)GetAddress("glGenQueriesARB", typeof(Delegates.glGenQueriesARB));
        public static Delegates.glDeleteQueriesARB_ glDeleteQueriesARB_ = (Delegates.glDeleteQueriesARB_)GetAddress("glDeleteQueriesARB", typeof(Delegates.glDeleteQueriesARB_));
        public static Delegates.glIsQueryARB glIsQueryARB = (Delegates.glIsQueryARB)GetAddress("glIsQueryARB", typeof(Delegates.glIsQueryARB));
        public static Delegates.glBeginQueryARB glBeginQueryARB = (Delegates.glBeginQueryARB)GetAddress("glBeginQueryARB", typeof(Delegates.glBeginQueryARB));
        public static Delegates.glEndQueryARB glEndQueryARB = (Delegates.glEndQueryARB)GetAddress("glEndQueryARB", typeof(Delegates.glEndQueryARB));
        public static Delegates.glGetQueryivARB glGetQueryivARB = (Delegates.glGetQueryivARB)GetAddress("glGetQueryivARB", typeof(Delegates.glGetQueryivARB));
        public static Delegates.glGetQueryObjectivARB glGetQueryObjectivARB = (Delegates.glGetQueryObjectivARB)GetAddress("glGetQueryObjectivARB", typeof(Delegates.glGetQueryObjectivARB));
        public static Delegates.glGetQueryObjectuivARB glGetQueryObjectuivARB = (Delegates.glGetQueryObjectuivARB)GetAddress("glGetQueryObjectuivARB", typeof(Delegates.glGetQueryObjectuivARB));
        public static Delegates.glDeleteObjectARB glDeleteObjectARB = (Delegates.glDeleteObjectARB)GetAddress("glDeleteObjectARB", typeof(Delegates.glDeleteObjectARB));
        public static Delegates.glGetHandleARB glGetHandleARB = (Delegates.glGetHandleARB)GetAddress("glGetHandleARB", typeof(Delegates.glGetHandleARB));
        public static Delegates.glDetachObjectARB glDetachObjectARB = (Delegates.glDetachObjectARB)GetAddress("glDetachObjectARB", typeof(Delegates.glDetachObjectARB));
        public static Delegates.glCreateShaderObjectARB glCreateShaderObjectARB = (Delegates.glCreateShaderObjectARB)GetAddress("glCreateShaderObjectARB", typeof(Delegates.glCreateShaderObjectARB));
        public static Delegates.glShaderSourceARB_ glShaderSourceARB_ = (Delegates.glShaderSourceARB_)GetAddress("glShaderSourceARB", typeof(Delegates.glShaderSourceARB_));
        public static Delegates.glCompileShaderARB glCompileShaderARB = (Delegates.glCompileShaderARB)GetAddress("glCompileShaderARB", typeof(Delegates.glCompileShaderARB));
        public static Delegates.glCreateProgramObjectARB glCreateProgramObjectARB = (Delegates.glCreateProgramObjectARB)GetAddress("glCreateProgramObjectARB", typeof(Delegates.glCreateProgramObjectARB));
        public static Delegates.glAttachObjectARB glAttachObjectARB = (Delegates.glAttachObjectARB)GetAddress("glAttachObjectARB", typeof(Delegates.glAttachObjectARB));
        public static Delegates.glLinkProgramARB glLinkProgramARB = (Delegates.glLinkProgramARB)GetAddress("glLinkProgramARB", typeof(Delegates.glLinkProgramARB));
        public static Delegates.glUseProgramObjectARB glUseProgramObjectARB = (Delegates.glUseProgramObjectARB)GetAddress("glUseProgramObjectARB", typeof(Delegates.glUseProgramObjectARB));
        public static Delegates.glValidateProgramARB glValidateProgramARB = (Delegates.glValidateProgramARB)GetAddress("glValidateProgramARB", typeof(Delegates.glValidateProgramARB));
        public static Delegates.glUniform1fARB glUniform1fARB = (Delegates.glUniform1fARB)GetAddress("glUniform1fARB", typeof(Delegates.glUniform1fARB));
        public static Delegates.glUniform2fARB glUniform2fARB = (Delegates.glUniform2fARB)GetAddress("glUniform2fARB", typeof(Delegates.glUniform2fARB));
        public static Delegates.glUniform3fARB glUniform3fARB = (Delegates.glUniform3fARB)GetAddress("glUniform3fARB", typeof(Delegates.glUniform3fARB));
        public static Delegates.glUniform4fARB glUniform4fARB = (Delegates.glUniform4fARB)GetAddress("glUniform4fARB", typeof(Delegates.glUniform4fARB));
        public static Delegates.glUniform1iARB glUniform1iARB = (Delegates.glUniform1iARB)GetAddress("glUniform1iARB", typeof(Delegates.glUniform1iARB));
        public static Delegates.glUniform2iARB glUniform2iARB = (Delegates.glUniform2iARB)GetAddress("glUniform2iARB", typeof(Delegates.glUniform2iARB));
        public static Delegates.glUniform3iARB glUniform3iARB = (Delegates.glUniform3iARB)GetAddress("glUniform3iARB", typeof(Delegates.glUniform3iARB));
        public static Delegates.glUniform4iARB glUniform4iARB = (Delegates.glUniform4iARB)GetAddress("glUniform4iARB", typeof(Delegates.glUniform4iARB));
        public static Delegates.glUniform1fvARB_ glUniform1fvARB_ = (Delegates.glUniform1fvARB_)GetAddress("glUniform1fvARB", typeof(Delegates.glUniform1fvARB_));
        public static Delegates.glUniform2fvARB_ glUniform2fvARB_ = (Delegates.glUniform2fvARB_)GetAddress("glUniform2fvARB", typeof(Delegates.glUniform2fvARB_));
        public static Delegates.glUniform3fvARB_ glUniform3fvARB_ = (Delegates.glUniform3fvARB_)GetAddress("glUniform3fvARB", typeof(Delegates.glUniform3fvARB_));
        public static Delegates.glUniform4fvARB_ glUniform4fvARB_ = (Delegates.glUniform4fvARB_)GetAddress("glUniform4fvARB", typeof(Delegates.glUniform4fvARB_));
        public static Delegates.glUniform1ivARB_ glUniform1ivARB_ = (Delegates.glUniform1ivARB_)GetAddress("glUniform1ivARB", typeof(Delegates.glUniform1ivARB_));
        public static Delegates.glUniform2ivARB_ glUniform2ivARB_ = (Delegates.glUniform2ivARB_)GetAddress("glUniform2ivARB", typeof(Delegates.glUniform2ivARB_));
        public static Delegates.glUniform3ivARB_ glUniform3ivARB_ = (Delegates.glUniform3ivARB_)GetAddress("glUniform3ivARB", typeof(Delegates.glUniform3ivARB_));
        public static Delegates.glUniform4ivARB_ glUniform4ivARB_ = (Delegates.glUniform4ivARB_)GetAddress("glUniform4ivARB", typeof(Delegates.glUniform4ivARB_));
        public static Delegates.glUniformMatrix2fvARB_ glUniformMatrix2fvARB_ = (Delegates.glUniformMatrix2fvARB_)GetAddress("glUniformMatrix2fvARB", typeof(Delegates.glUniformMatrix2fvARB_));
        public static Delegates.glUniformMatrix3fvARB_ glUniformMatrix3fvARB_ = (Delegates.glUniformMatrix3fvARB_)GetAddress("glUniformMatrix3fvARB", typeof(Delegates.glUniformMatrix3fvARB_));
        public static Delegates.glUniformMatrix4fvARB_ glUniformMatrix4fvARB_ = (Delegates.glUniformMatrix4fvARB_)GetAddress("glUniformMatrix4fvARB", typeof(Delegates.glUniformMatrix4fvARB_));
        public static Delegates.glGetObjectParameterfvARB glGetObjectParameterfvARB = (Delegates.glGetObjectParameterfvARB)GetAddress("glGetObjectParameterfvARB", typeof(Delegates.glGetObjectParameterfvARB));
        public static Delegates.glGetObjectParameterivARB glGetObjectParameterivARB = (Delegates.glGetObjectParameterivARB)GetAddress("glGetObjectParameterivARB", typeof(Delegates.glGetObjectParameterivARB));
        public static Delegates.glGetInfoLogARB glGetInfoLogARB = (Delegates.glGetInfoLogARB)GetAddress("glGetInfoLogARB", typeof(Delegates.glGetInfoLogARB));
        public static Delegates.glGetAttachedObjectsARB glGetAttachedObjectsARB = (Delegates.glGetAttachedObjectsARB)GetAddress("glGetAttachedObjectsARB", typeof(Delegates.glGetAttachedObjectsARB));
        public static Delegates.glGetUniformLocationARB_ glGetUniformLocationARB_ = (Delegates.glGetUniformLocationARB_)GetAddress("glGetUniformLocationARB", typeof(Delegates.glGetUniformLocationARB_));
        public static Delegates.glGetActiveUniformARB glGetActiveUniformARB = (Delegates.glGetActiveUniformARB)GetAddress("glGetActiveUniformARB", typeof(Delegates.glGetActiveUniformARB));
        public static Delegates.glGetUniformfvARB glGetUniformfvARB = (Delegates.glGetUniformfvARB)GetAddress("glGetUniformfvARB", typeof(Delegates.glGetUniformfvARB));
        public static Delegates.glGetUniformivARB glGetUniformivARB = (Delegates.glGetUniformivARB)GetAddress("glGetUniformivARB", typeof(Delegates.glGetUniformivARB));
        public static Delegates.glGetShaderSourceARB glGetShaderSourceARB = (Delegates.glGetShaderSourceARB)GetAddress("glGetShaderSourceARB", typeof(Delegates.glGetShaderSourceARB));
        public static Delegates.glBindAttribLocationARB_ glBindAttribLocationARB_ = (Delegates.glBindAttribLocationARB_)GetAddress("glBindAttribLocationARB", typeof(Delegates.glBindAttribLocationARB_));
        public static Delegates.glGetActiveAttribARB glGetActiveAttribARB = (Delegates.glGetActiveAttribARB)GetAddress("glGetActiveAttribARB", typeof(Delegates.glGetActiveAttribARB));
        public static Delegates.glGetAttribLocationARB_ glGetAttribLocationARB_ = (Delegates.glGetAttribLocationARB_)GetAddress("glGetAttribLocationARB", typeof(Delegates.glGetAttribLocationARB_));
        public static Delegates.glDrawBuffersARB_ glDrawBuffersARB_ = (Delegates.glDrawBuffersARB_)GetAddress("glDrawBuffersARB", typeof(Delegates.glDrawBuffersARB_));
        public static Delegates.glClampColorARB glClampColorARB = (Delegates.glClampColorARB)GetAddress("glClampColorARB", typeof(Delegates.glClampColorARB));
        public static Delegates.glBlendColorEXT glBlendColorEXT = (Delegates.glBlendColorEXT)GetAddress("glBlendColorEXT", typeof(Delegates.glBlendColorEXT));
        public static Delegates.glPolygonOffsetEXT glPolygonOffsetEXT = (Delegates.glPolygonOffsetEXT)GetAddress("glPolygonOffsetEXT", typeof(Delegates.glPolygonOffsetEXT));
        public static Delegates.glTexImage3DEXT_ glTexImage3DEXT_ = (Delegates.glTexImage3DEXT_)GetAddress("glTexImage3DEXT", typeof(Delegates.glTexImage3DEXT_));
        public static Delegates.glTexSubImage3DEXT_ glTexSubImage3DEXT_ = (Delegates.glTexSubImage3DEXT_)GetAddress("glTexSubImage3DEXT", typeof(Delegates.glTexSubImage3DEXT_));
        public static Delegates.glGetTexFilterFuncSGIS glGetTexFilterFuncSGIS = (Delegates.glGetTexFilterFuncSGIS)GetAddress("glGetTexFilterFuncSGIS", typeof(Delegates.glGetTexFilterFuncSGIS));
        public static Delegates.glTexFilterFuncSGIS_ glTexFilterFuncSGIS_ = (Delegates.glTexFilterFuncSGIS_)GetAddress("glTexFilterFuncSGIS", typeof(Delegates.glTexFilterFuncSGIS_));
        public static Delegates.glTexSubImage1DEXT_ glTexSubImage1DEXT_ = (Delegates.glTexSubImage1DEXT_)GetAddress("glTexSubImage1DEXT", typeof(Delegates.glTexSubImage1DEXT_));
        public static Delegates.glTexSubImage2DEXT_ glTexSubImage2DEXT_ = (Delegates.glTexSubImage2DEXT_)GetAddress("glTexSubImage2DEXT", typeof(Delegates.glTexSubImage2DEXT_));
        public static Delegates.glCopyTexImage1DEXT glCopyTexImage1DEXT = (Delegates.glCopyTexImage1DEXT)GetAddress("glCopyTexImage1DEXT", typeof(Delegates.glCopyTexImage1DEXT));
        public static Delegates.glCopyTexImage2DEXT glCopyTexImage2DEXT = (Delegates.glCopyTexImage2DEXT)GetAddress("glCopyTexImage2DEXT", typeof(Delegates.glCopyTexImage2DEXT));
        public static Delegates.glCopyTexSubImage1DEXT glCopyTexSubImage1DEXT = (Delegates.glCopyTexSubImage1DEXT)GetAddress("glCopyTexSubImage1DEXT", typeof(Delegates.glCopyTexSubImage1DEXT));
        public static Delegates.glCopyTexSubImage2DEXT glCopyTexSubImage2DEXT = (Delegates.glCopyTexSubImage2DEXT)GetAddress("glCopyTexSubImage2DEXT", typeof(Delegates.glCopyTexSubImage2DEXT));
        public static Delegates.glCopyTexSubImage3DEXT glCopyTexSubImage3DEXT = (Delegates.glCopyTexSubImage3DEXT)GetAddress("glCopyTexSubImage3DEXT", typeof(Delegates.glCopyTexSubImage3DEXT));
        public static Delegates.glGetHistogramEXT_ glGetHistogramEXT_ = (Delegates.glGetHistogramEXT_)GetAddress("glGetHistogramEXT", typeof(Delegates.glGetHistogramEXT_));
        public static Delegates.glGetHistogramParameterfvEXT glGetHistogramParameterfvEXT = (Delegates.glGetHistogramParameterfvEXT)GetAddress("glGetHistogramParameterfvEXT", typeof(Delegates.glGetHistogramParameterfvEXT));
        public static Delegates.glGetHistogramParameterivEXT glGetHistogramParameterivEXT = (Delegates.glGetHistogramParameterivEXT)GetAddress("glGetHistogramParameterivEXT", typeof(Delegates.glGetHistogramParameterivEXT));
        public static Delegates.glGetMinmaxEXT_ glGetMinmaxEXT_ = (Delegates.glGetMinmaxEXT_)GetAddress("glGetMinmaxEXT", typeof(Delegates.glGetMinmaxEXT_));
        public static Delegates.glGetMinmaxParameterfvEXT glGetMinmaxParameterfvEXT = (Delegates.glGetMinmaxParameterfvEXT)GetAddress("glGetMinmaxParameterfvEXT", typeof(Delegates.glGetMinmaxParameterfvEXT));
        public static Delegates.glGetMinmaxParameterivEXT glGetMinmaxParameterivEXT = (Delegates.glGetMinmaxParameterivEXT)GetAddress("glGetMinmaxParameterivEXT", typeof(Delegates.glGetMinmaxParameterivEXT));
        public static Delegates.glHistogramEXT glHistogramEXT = (Delegates.glHistogramEXT)GetAddress("glHistogramEXT", typeof(Delegates.glHistogramEXT));
        public static Delegates.glMinmaxEXT glMinmaxEXT = (Delegates.glMinmaxEXT)GetAddress("glMinmaxEXT", typeof(Delegates.glMinmaxEXT));
        public static Delegates.glResetHistogramEXT glResetHistogramEXT = (Delegates.glResetHistogramEXT)GetAddress("glResetHistogramEXT", typeof(Delegates.glResetHistogramEXT));
        public static Delegates.glResetMinmaxEXT glResetMinmaxEXT = (Delegates.glResetMinmaxEXT)GetAddress("glResetMinmaxEXT", typeof(Delegates.glResetMinmaxEXT));
        public static Delegates.glConvolutionFilter1DEXT_ glConvolutionFilter1DEXT_ = (Delegates.glConvolutionFilter1DEXT_)GetAddress("glConvolutionFilter1DEXT", typeof(Delegates.glConvolutionFilter1DEXT_));
        public static Delegates.glConvolutionFilter2DEXT_ glConvolutionFilter2DEXT_ = (Delegates.glConvolutionFilter2DEXT_)GetAddress("glConvolutionFilter2DEXT", typeof(Delegates.glConvolutionFilter2DEXT_));
        public static Delegates.glConvolutionParameterfEXT glConvolutionParameterfEXT = (Delegates.glConvolutionParameterfEXT)GetAddress("glConvolutionParameterfEXT", typeof(Delegates.glConvolutionParameterfEXT));
        public static Delegates.glConvolutionParameterfvEXT_ glConvolutionParameterfvEXT_ = (Delegates.glConvolutionParameterfvEXT_)GetAddress("glConvolutionParameterfvEXT", typeof(Delegates.glConvolutionParameterfvEXT_));
        public static Delegates.glConvolutionParameteriEXT glConvolutionParameteriEXT = (Delegates.glConvolutionParameteriEXT)GetAddress("glConvolutionParameteriEXT", typeof(Delegates.glConvolutionParameteriEXT));
        public static Delegates.glConvolutionParameterivEXT_ glConvolutionParameterivEXT_ = (Delegates.glConvolutionParameterivEXT_)GetAddress("glConvolutionParameterivEXT", typeof(Delegates.glConvolutionParameterivEXT_));
        public static Delegates.glCopyConvolutionFilter1DEXT glCopyConvolutionFilter1DEXT = (Delegates.glCopyConvolutionFilter1DEXT)GetAddress("glCopyConvolutionFilter1DEXT", typeof(Delegates.glCopyConvolutionFilter1DEXT));
        public static Delegates.glCopyConvolutionFilter2DEXT glCopyConvolutionFilter2DEXT = (Delegates.glCopyConvolutionFilter2DEXT)GetAddress("glCopyConvolutionFilter2DEXT", typeof(Delegates.glCopyConvolutionFilter2DEXT));
        public static Delegates.glGetConvolutionFilterEXT_ glGetConvolutionFilterEXT_ = (Delegates.glGetConvolutionFilterEXT_)GetAddress("glGetConvolutionFilterEXT", typeof(Delegates.glGetConvolutionFilterEXT_));
        public static Delegates.glGetConvolutionParameterfvEXT glGetConvolutionParameterfvEXT = (Delegates.glGetConvolutionParameterfvEXT)GetAddress("glGetConvolutionParameterfvEXT", typeof(Delegates.glGetConvolutionParameterfvEXT));
        public static Delegates.glGetConvolutionParameterivEXT glGetConvolutionParameterivEXT = (Delegates.glGetConvolutionParameterivEXT)GetAddress("glGetConvolutionParameterivEXT", typeof(Delegates.glGetConvolutionParameterivEXT));
        public static Delegates.glGetSeparableFilterEXT_ glGetSeparableFilterEXT_ = (Delegates.glGetSeparableFilterEXT_)GetAddress("glGetSeparableFilterEXT", typeof(Delegates.glGetSeparableFilterEXT_));
        public static Delegates.glSeparableFilter2DEXT_ glSeparableFilter2DEXT_ = (Delegates.glSeparableFilter2DEXT_)GetAddress("glSeparableFilter2DEXT", typeof(Delegates.glSeparableFilter2DEXT_));
        public static Delegates.glColorTableSGI_ glColorTableSGI_ = (Delegates.glColorTableSGI_)GetAddress("glColorTableSGI", typeof(Delegates.glColorTableSGI_));
        public static Delegates.glColorTableParameterfvSGI_ glColorTableParameterfvSGI_ = (Delegates.glColorTableParameterfvSGI_)GetAddress("glColorTableParameterfvSGI", typeof(Delegates.glColorTableParameterfvSGI_));
        public static Delegates.glColorTableParameterivSGI_ glColorTableParameterivSGI_ = (Delegates.glColorTableParameterivSGI_)GetAddress("glColorTableParameterivSGI", typeof(Delegates.glColorTableParameterivSGI_));
        public static Delegates.glCopyColorTableSGI glCopyColorTableSGI = (Delegates.glCopyColorTableSGI)GetAddress("glCopyColorTableSGI", typeof(Delegates.glCopyColorTableSGI));
        public static Delegates.glGetColorTableSGI_ glGetColorTableSGI_ = (Delegates.glGetColorTableSGI_)GetAddress("glGetColorTableSGI", typeof(Delegates.glGetColorTableSGI_));
        public static Delegates.glGetColorTableParameterfvSGI glGetColorTableParameterfvSGI = (Delegates.glGetColorTableParameterfvSGI)GetAddress("glGetColorTableParameterfvSGI", typeof(Delegates.glGetColorTableParameterfvSGI));
        public static Delegates.glGetColorTableParameterivSGI glGetColorTableParameterivSGI = (Delegates.glGetColorTableParameterivSGI)GetAddress("glGetColorTableParameterivSGI", typeof(Delegates.glGetColorTableParameterivSGI));
        public static Delegates.glPixelTexGenSGIX glPixelTexGenSGIX = (Delegates.glPixelTexGenSGIX)GetAddress("glPixelTexGenSGIX", typeof(Delegates.glPixelTexGenSGIX));
        public static Delegates.glPixelTexGenParameteriSGIS glPixelTexGenParameteriSGIS = (Delegates.glPixelTexGenParameteriSGIS)GetAddress("glPixelTexGenParameteriSGIS", typeof(Delegates.glPixelTexGenParameteriSGIS));
        public static Delegates.glPixelTexGenParameterivSGIS_ glPixelTexGenParameterivSGIS_ = (Delegates.glPixelTexGenParameterivSGIS_)GetAddress("glPixelTexGenParameterivSGIS", typeof(Delegates.glPixelTexGenParameterivSGIS_));
        public static Delegates.glPixelTexGenParameterfSGIS glPixelTexGenParameterfSGIS = (Delegates.glPixelTexGenParameterfSGIS)GetAddress("glPixelTexGenParameterfSGIS", typeof(Delegates.glPixelTexGenParameterfSGIS));
        public static Delegates.glPixelTexGenParameterfvSGIS_ glPixelTexGenParameterfvSGIS_ = (Delegates.glPixelTexGenParameterfvSGIS_)GetAddress("glPixelTexGenParameterfvSGIS", typeof(Delegates.glPixelTexGenParameterfvSGIS_));
        public static Delegates.glGetPixelTexGenParameterivSGIS glGetPixelTexGenParameterivSGIS = (Delegates.glGetPixelTexGenParameterivSGIS)GetAddress("glGetPixelTexGenParameterivSGIS", typeof(Delegates.glGetPixelTexGenParameterivSGIS));
        public static Delegates.glGetPixelTexGenParameterfvSGIS glGetPixelTexGenParameterfvSGIS = (Delegates.glGetPixelTexGenParameterfvSGIS)GetAddress("glGetPixelTexGenParameterfvSGIS", typeof(Delegates.glGetPixelTexGenParameterfvSGIS));
        public static Delegates.glTexImage4DSGIS_ glTexImage4DSGIS_ = (Delegates.glTexImage4DSGIS_)GetAddress("glTexImage4DSGIS", typeof(Delegates.glTexImage4DSGIS_));
        public static Delegates.glTexSubImage4DSGIS_ glTexSubImage4DSGIS_ = (Delegates.glTexSubImage4DSGIS_)GetAddress("glTexSubImage4DSGIS", typeof(Delegates.glTexSubImage4DSGIS_));
        public static Delegates.glAreTexturesResidentEXT_ glAreTexturesResidentEXT_ = (Delegates.glAreTexturesResidentEXT_)GetAddress("glAreTexturesResidentEXT", typeof(Delegates.glAreTexturesResidentEXT_));
        public static Delegates.glBindTextureEXT glBindTextureEXT = (Delegates.glBindTextureEXT)GetAddress("glBindTextureEXT", typeof(Delegates.glBindTextureEXT));
        public static Delegates.glDeleteTexturesEXT_ glDeleteTexturesEXT_ = (Delegates.glDeleteTexturesEXT_)GetAddress("glDeleteTexturesEXT", typeof(Delegates.glDeleteTexturesEXT_));
        public static Delegates.glGenTexturesEXT glGenTexturesEXT = (Delegates.glGenTexturesEXT)GetAddress("glGenTexturesEXT", typeof(Delegates.glGenTexturesEXT));
        public static Delegates.glIsTextureEXT glIsTextureEXT = (Delegates.glIsTextureEXT)GetAddress("glIsTextureEXT", typeof(Delegates.glIsTextureEXT));
        public static Delegates.glPrioritizeTexturesEXT_ glPrioritizeTexturesEXT_ = (Delegates.glPrioritizeTexturesEXT_)GetAddress("glPrioritizeTexturesEXT", typeof(Delegates.glPrioritizeTexturesEXT_));
        public static Delegates.glDetailTexFuncSGIS_ glDetailTexFuncSGIS_ = (Delegates.glDetailTexFuncSGIS_)GetAddress("glDetailTexFuncSGIS", typeof(Delegates.glDetailTexFuncSGIS_));
        public static Delegates.glGetDetailTexFuncSGIS glGetDetailTexFuncSGIS = (Delegates.glGetDetailTexFuncSGIS)GetAddress("glGetDetailTexFuncSGIS", typeof(Delegates.glGetDetailTexFuncSGIS));
        public static Delegates.glSharpenTexFuncSGIS_ glSharpenTexFuncSGIS_ = (Delegates.glSharpenTexFuncSGIS_)GetAddress("glSharpenTexFuncSGIS", typeof(Delegates.glSharpenTexFuncSGIS_));
        public static Delegates.glGetSharpenTexFuncSGIS glGetSharpenTexFuncSGIS = (Delegates.glGetSharpenTexFuncSGIS)GetAddress("glGetSharpenTexFuncSGIS", typeof(Delegates.glGetSharpenTexFuncSGIS));
        public static Delegates.glSampleMaskSGIS glSampleMaskSGIS = (Delegates.glSampleMaskSGIS)GetAddress("glSampleMaskSGIS", typeof(Delegates.glSampleMaskSGIS));
        public static Delegates.glSamplePatternSGIS glSamplePatternSGIS = (Delegates.glSamplePatternSGIS)GetAddress("glSamplePatternSGIS", typeof(Delegates.glSamplePatternSGIS));
        public static Delegates.glArrayElementEXT glArrayElementEXT = (Delegates.glArrayElementEXT)GetAddress("glArrayElementEXT", typeof(Delegates.glArrayElementEXT));
        public static Delegates.glColorPointerEXT_ glColorPointerEXT_ = (Delegates.glColorPointerEXT_)GetAddress("glColorPointerEXT", typeof(Delegates.glColorPointerEXT_));
        public static Delegates.glDrawArraysEXT glDrawArraysEXT = (Delegates.glDrawArraysEXT)GetAddress("glDrawArraysEXT", typeof(Delegates.glDrawArraysEXT));
        public static Delegates.glEdgeFlagPointerEXT_ glEdgeFlagPointerEXT_ = (Delegates.glEdgeFlagPointerEXT_)GetAddress("glEdgeFlagPointerEXT", typeof(Delegates.glEdgeFlagPointerEXT_));
        public static Delegates.glGetPointervEXT glGetPointervEXT = (Delegates.glGetPointervEXT)GetAddress("glGetPointervEXT", typeof(Delegates.glGetPointervEXT));
        public static Delegates.glIndexPointerEXT_ glIndexPointerEXT_ = (Delegates.glIndexPointerEXT_)GetAddress("glIndexPointerEXT", typeof(Delegates.glIndexPointerEXT_));
        public static Delegates.glNormalPointerEXT_ glNormalPointerEXT_ = (Delegates.glNormalPointerEXT_)GetAddress("glNormalPointerEXT", typeof(Delegates.glNormalPointerEXT_));
        public static Delegates.glTexCoordPointerEXT_ glTexCoordPointerEXT_ = (Delegates.glTexCoordPointerEXT_)GetAddress("glTexCoordPointerEXT", typeof(Delegates.glTexCoordPointerEXT_));
        public static Delegates.glVertexPointerEXT_ glVertexPointerEXT_ = (Delegates.glVertexPointerEXT_)GetAddress("glVertexPointerEXT", typeof(Delegates.glVertexPointerEXT_));
        public static Delegates.glBlendEquationEXT glBlendEquationEXT = (Delegates.glBlendEquationEXT)GetAddress("glBlendEquationEXT", typeof(Delegates.glBlendEquationEXT));
        public static Delegates.glSpriteParameterfSGIX glSpriteParameterfSGIX = (Delegates.glSpriteParameterfSGIX)GetAddress("glSpriteParameterfSGIX", typeof(Delegates.glSpriteParameterfSGIX));
        public static Delegates.glSpriteParameterfvSGIX_ glSpriteParameterfvSGIX_ = (Delegates.glSpriteParameterfvSGIX_)GetAddress("glSpriteParameterfvSGIX", typeof(Delegates.glSpriteParameterfvSGIX_));
        public static Delegates.glSpriteParameteriSGIX glSpriteParameteriSGIX = (Delegates.glSpriteParameteriSGIX)GetAddress("glSpriteParameteriSGIX", typeof(Delegates.glSpriteParameteriSGIX));
        public static Delegates.glSpriteParameterivSGIX_ glSpriteParameterivSGIX_ = (Delegates.glSpriteParameterivSGIX_)GetAddress("glSpriteParameterivSGIX", typeof(Delegates.glSpriteParameterivSGIX_));
        public static Delegates.glPointParameterfEXT glPointParameterfEXT = (Delegates.glPointParameterfEXT)GetAddress("glPointParameterfEXT", typeof(Delegates.glPointParameterfEXT));
        public static Delegates.glPointParameterfvEXT_ glPointParameterfvEXT_ = (Delegates.glPointParameterfvEXT_)GetAddress("glPointParameterfvEXT", typeof(Delegates.glPointParameterfvEXT_));
        public static Delegates.glPointParameterfSGIS glPointParameterfSGIS = (Delegates.glPointParameterfSGIS)GetAddress("glPointParameterfSGIS", typeof(Delegates.glPointParameterfSGIS));
        public static Delegates.glPointParameterfvSGIS_ glPointParameterfvSGIS_ = (Delegates.glPointParameterfvSGIS_)GetAddress("glPointParameterfvSGIS", typeof(Delegates.glPointParameterfvSGIS_));
        public static Delegates.glGetInstrumentsSGIX glGetInstrumentsSGIX = (Delegates.glGetInstrumentsSGIX)GetAddress("glGetInstrumentsSGIX", typeof(Delegates.glGetInstrumentsSGIX));
        public static Delegates.glInstrumentsBufferSGIX glInstrumentsBufferSGIX = (Delegates.glInstrumentsBufferSGIX)GetAddress("glInstrumentsBufferSGIX", typeof(Delegates.glInstrumentsBufferSGIX));
        public static Delegates.glPollInstrumentsSGIX glPollInstrumentsSGIX = (Delegates.glPollInstrumentsSGIX)GetAddress("glPollInstrumentsSGIX", typeof(Delegates.glPollInstrumentsSGIX));
        public static Delegates.glReadInstrumentsSGIX glReadInstrumentsSGIX = (Delegates.glReadInstrumentsSGIX)GetAddress("glReadInstrumentsSGIX", typeof(Delegates.glReadInstrumentsSGIX));
        public static Delegates.glStartInstrumentsSGIX glStartInstrumentsSGIX = (Delegates.glStartInstrumentsSGIX)GetAddress("glStartInstrumentsSGIX", typeof(Delegates.glStartInstrumentsSGIX));
        public static Delegates.glStopInstrumentsSGIX glStopInstrumentsSGIX = (Delegates.glStopInstrumentsSGIX)GetAddress("glStopInstrumentsSGIX", typeof(Delegates.glStopInstrumentsSGIX));
        public static Delegates.glFrameZoomSGIX glFrameZoomSGIX = (Delegates.glFrameZoomSGIX)GetAddress("glFrameZoomSGIX", typeof(Delegates.glFrameZoomSGIX));
        public static Delegates.glTagSampleBufferSGIX glTagSampleBufferSGIX = (Delegates.glTagSampleBufferSGIX)GetAddress("glTagSampleBufferSGIX", typeof(Delegates.glTagSampleBufferSGIX));
        public static Delegates.glDeformationMap3dSGIX_ glDeformationMap3dSGIX_ = (Delegates.glDeformationMap3dSGIX_)GetAddress("glDeformationMap3dSGIX", typeof(Delegates.glDeformationMap3dSGIX_));
        public static Delegates.glDeformationMap3fSGIX_ glDeformationMap3fSGIX_ = (Delegates.glDeformationMap3fSGIX_)GetAddress("glDeformationMap3fSGIX", typeof(Delegates.glDeformationMap3fSGIX_));
        public static Delegates.glDeformSGIX glDeformSGIX = (Delegates.glDeformSGIX)GetAddress("glDeformSGIX", typeof(Delegates.glDeformSGIX));
        public static Delegates.glLoadIdentityDeformationMapSGIX glLoadIdentityDeformationMapSGIX = (Delegates.glLoadIdentityDeformationMapSGIX)GetAddress("glLoadIdentityDeformationMapSGIX", typeof(Delegates.glLoadIdentityDeformationMapSGIX));
        public static Delegates.glReferencePlaneSGIX_ glReferencePlaneSGIX_ = (Delegates.glReferencePlaneSGIX_)GetAddress("glReferencePlaneSGIX", typeof(Delegates.glReferencePlaneSGIX_));
        public static Delegates.glFlushRasterSGIX glFlushRasterSGIX = (Delegates.glFlushRasterSGIX)GetAddress("glFlushRasterSGIX", typeof(Delegates.glFlushRasterSGIX));
        public static Delegates.glFogFuncSGIS_ glFogFuncSGIS_ = (Delegates.glFogFuncSGIS_)GetAddress("glFogFuncSGIS", typeof(Delegates.glFogFuncSGIS_));
        public static Delegates.glGetFogFuncSGIS glGetFogFuncSGIS = (Delegates.glGetFogFuncSGIS)GetAddress("glGetFogFuncSGIS", typeof(Delegates.glGetFogFuncSGIS));
        public static Delegates.glImageTransformParameteriHP glImageTransformParameteriHP = (Delegates.glImageTransformParameteriHP)GetAddress("glImageTransformParameteriHP", typeof(Delegates.glImageTransformParameteriHP));
        public static Delegates.glImageTransformParameterfHP glImageTransformParameterfHP = (Delegates.glImageTransformParameterfHP)GetAddress("glImageTransformParameterfHP", typeof(Delegates.glImageTransformParameterfHP));
        public static Delegates.glImageTransformParameterivHP_ glImageTransformParameterivHP_ = (Delegates.glImageTransformParameterivHP_)GetAddress("glImageTransformParameterivHP", typeof(Delegates.glImageTransformParameterivHP_));
        public static Delegates.glImageTransformParameterfvHP_ glImageTransformParameterfvHP_ = (Delegates.glImageTransformParameterfvHP_)GetAddress("glImageTransformParameterfvHP", typeof(Delegates.glImageTransformParameterfvHP_));
        public static Delegates.glGetImageTransformParameterivHP glGetImageTransformParameterivHP = (Delegates.glGetImageTransformParameterivHP)GetAddress("glGetImageTransformParameterivHP", typeof(Delegates.glGetImageTransformParameterivHP));
        public static Delegates.glGetImageTransformParameterfvHP glGetImageTransformParameterfvHP = (Delegates.glGetImageTransformParameterfvHP)GetAddress("glGetImageTransformParameterfvHP", typeof(Delegates.glGetImageTransformParameterfvHP));
        public static Delegates.glColorSubTableEXT_ glColorSubTableEXT_ = (Delegates.glColorSubTableEXT_)GetAddress("glColorSubTableEXT", typeof(Delegates.glColorSubTableEXT_));
        public static Delegates.glCopyColorSubTableEXT glCopyColorSubTableEXT = (Delegates.glCopyColorSubTableEXT)GetAddress("glCopyColorSubTableEXT", typeof(Delegates.glCopyColorSubTableEXT));
        public static Delegates.glHintPGI glHintPGI = (Delegates.glHintPGI)GetAddress("glHintPGI", typeof(Delegates.glHintPGI));
        public static Delegates.glColorTableEXT_ glColorTableEXT_ = (Delegates.glColorTableEXT_)GetAddress("glColorTableEXT", typeof(Delegates.glColorTableEXT_));
        public static Delegates.glGetColorTableEXT_ glGetColorTableEXT_ = (Delegates.glGetColorTableEXT_)GetAddress("glGetColorTableEXT", typeof(Delegates.glGetColorTableEXT_));
        public static Delegates.glGetColorTableParameterivEXT glGetColorTableParameterivEXT = (Delegates.glGetColorTableParameterivEXT)GetAddress("glGetColorTableParameterivEXT", typeof(Delegates.glGetColorTableParameterivEXT));
        public static Delegates.glGetColorTableParameterfvEXT glGetColorTableParameterfvEXT = (Delegates.glGetColorTableParameterfvEXT)GetAddress("glGetColorTableParameterfvEXT", typeof(Delegates.glGetColorTableParameterfvEXT));
        public static Delegates.glGetListParameterfvSGIX glGetListParameterfvSGIX = (Delegates.glGetListParameterfvSGIX)GetAddress("glGetListParameterfvSGIX", typeof(Delegates.glGetListParameterfvSGIX));
        public static Delegates.glGetListParameterivSGIX glGetListParameterivSGIX = (Delegates.glGetListParameterivSGIX)GetAddress("glGetListParameterivSGIX", typeof(Delegates.glGetListParameterivSGIX));
        public static Delegates.glListParameterfSGIX glListParameterfSGIX = (Delegates.glListParameterfSGIX)GetAddress("glListParameterfSGIX", typeof(Delegates.glListParameterfSGIX));
        public static Delegates.glListParameterfvSGIX_ glListParameterfvSGIX_ = (Delegates.glListParameterfvSGIX_)GetAddress("glListParameterfvSGIX", typeof(Delegates.glListParameterfvSGIX_));
        public static Delegates.glListParameteriSGIX glListParameteriSGIX = (Delegates.glListParameteriSGIX)GetAddress("glListParameteriSGIX", typeof(Delegates.glListParameteriSGIX));
        public static Delegates.glListParameterivSGIX_ glListParameterivSGIX_ = (Delegates.glListParameterivSGIX_)GetAddress("glListParameterivSGIX", typeof(Delegates.glListParameterivSGIX_));
        public static Delegates.glIndexMaterialEXT glIndexMaterialEXT = (Delegates.glIndexMaterialEXT)GetAddress("glIndexMaterialEXT", typeof(Delegates.glIndexMaterialEXT));
        public static Delegates.glIndexFuncEXT glIndexFuncEXT = (Delegates.glIndexFuncEXT)GetAddress("glIndexFuncEXT", typeof(Delegates.glIndexFuncEXT));
        public static Delegates.glLockArraysEXT glLockArraysEXT = (Delegates.glLockArraysEXT)GetAddress("glLockArraysEXT", typeof(Delegates.glLockArraysEXT));
        public static Delegates.glUnlockArraysEXT glUnlockArraysEXT = (Delegates.glUnlockArraysEXT)GetAddress("glUnlockArraysEXT", typeof(Delegates.glUnlockArraysEXT));
        public static Delegates.glCullParameterdvEXT glCullParameterdvEXT = (Delegates.glCullParameterdvEXT)GetAddress("glCullParameterdvEXT", typeof(Delegates.glCullParameterdvEXT));
        public static Delegates.glCullParameterfvEXT glCullParameterfvEXT = (Delegates.glCullParameterfvEXT)GetAddress("glCullParameterfvEXT", typeof(Delegates.glCullParameterfvEXT));
        public static Delegates.glFragmentColorMaterialSGIX glFragmentColorMaterialSGIX = (Delegates.glFragmentColorMaterialSGIX)GetAddress("glFragmentColorMaterialSGIX", typeof(Delegates.glFragmentColorMaterialSGIX));
        public static Delegates.glFragmentLightfSGIX glFragmentLightfSGIX = (Delegates.glFragmentLightfSGIX)GetAddress("glFragmentLightfSGIX", typeof(Delegates.glFragmentLightfSGIX));
        public static Delegates.glFragmentLightfvSGIX_ glFragmentLightfvSGIX_ = (Delegates.glFragmentLightfvSGIX_)GetAddress("glFragmentLightfvSGIX", typeof(Delegates.glFragmentLightfvSGIX_));
        public static Delegates.glFragmentLightiSGIX glFragmentLightiSGIX = (Delegates.glFragmentLightiSGIX)GetAddress("glFragmentLightiSGIX", typeof(Delegates.glFragmentLightiSGIX));
        public static Delegates.glFragmentLightivSGIX_ glFragmentLightivSGIX_ = (Delegates.glFragmentLightivSGIX_)GetAddress("glFragmentLightivSGIX", typeof(Delegates.glFragmentLightivSGIX_));
        public static Delegates.glFragmentLightModelfSGIX glFragmentLightModelfSGIX = (Delegates.glFragmentLightModelfSGIX)GetAddress("glFragmentLightModelfSGIX", typeof(Delegates.glFragmentLightModelfSGIX));
        public static Delegates.glFragmentLightModelfvSGIX_ glFragmentLightModelfvSGIX_ = (Delegates.glFragmentLightModelfvSGIX_)GetAddress("glFragmentLightModelfvSGIX", typeof(Delegates.glFragmentLightModelfvSGIX_));
        public static Delegates.glFragmentLightModeliSGIX glFragmentLightModeliSGIX = (Delegates.glFragmentLightModeliSGIX)GetAddress("glFragmentLightModeliSGIX", typeof(Delegates.glFragmentLightModeliSGIX));
        public static Delegates.glFragmentLightModelivSGIX_ glFragmentLightModelivSGIX_ = (Delegates.glFragmentLightModelivSGIX_)GetAddress("glFragmentLightModelivSGIX", typeof(Delegates.glFragmentLightModelivSGIX_));
        public static Delegates.glFragmentMaterialfSGIX glFragmentMaterialfSGIX = (Delegates.glFragmentMaterialfSGIX)GetAddress("glFragmentMaterialfSGIX", typeof(Delegates.glFragmentMaterialfSGIX));
        public static Delegates.glFragmentMaterialfvSGIX_ glFragmentMaterialfvSGIX_ = (Delegates.glFragmentMaterialfvSGIX_)GetAddress("glFragmentMaterialfvSGIX", typeof(Delegates.glFragmentMaterialfvSGIX_));
        public static Delegates.glFragmentMaterialiSGIX glFragmentMaterialiSGIX = (Delegates.glFragmentMaterialiSGIX)GetAddress("glFragmentMaterialiSGIX", typeof(Delegates.glFragmentMaterialiSGIX));
        public static Delegates.glFragmentMaterialivSGIX_ glFragmentMaterialivSGIX_ = (Delegates.glFragmentMaterialivSGIX_)GetAddress("glFragmentMaterialivSGIX", typeof(Delegates.glFragmentMaterialivSGIX_));
        public static Delegates.glGetFragmentLightfvSGIX glGetFragmentLightfvSGIX = (Delegates.glGetFragmentLightfvSGIX)GetAddress("glGetFragmentLightfvSGIX", typeof(Delegates.glGetFragmentLightfvSGIX));
        public static Delegates.glGetFragmentLightivSGIX glGetFragmentLightivSGIX = (Delegates.glGetFragmentLightivSGIX)GetAddress("glGetFragmentLightivSGIX", typeof(Delegates.glGetFragmentLightivSGIX));
        public static Delegates.glGetFragmentMaterialfvSGIX glGetFragmentMaterialfvSGIX = (Delegates.glGetFragmentMaterialfvSGIX)GetAddress("glGetFragmentMaterialfvSGIX", typeof(Delegates.glGetFragmentMaterialfvSGIX));
        public static Delegates.glGetFragmentMaterialivSGIX glGetFragmentMaterialivSGIX = (Delegates.glGetFragmentMaterialivSGIX)GetAddress("glGetFragmentMaterialivSGIX", typeof(Delegates.glGetFragmentMaterialivSGIX));
        public static Delegates.glLightEnviSGIX glLightEnviSGIX = (Delegates.glLightEnviSGIX)GetAddress("glLightEnviSGIX", typeof(Delegates.glLightEnviSGIX));
        public static Delegates.glDrawRangeElementsEXT_ glDrawRangeElementsEXT_ = (Delegates.glDrawRangeElementsEXT_)GetAddress("glDrawRangeElementsEXT", typeof(Delegates.glDrawRangeElementsEXT_));
        public static Delegates.glApplyTextureEXT glApplyTextureEXT = (Delegates.glApplyTextureEXT)GetAddress("glApplyTextureEXT", typeof(Delegates.glApplyTextureEXT));
        public static Delegates.glTextureLightEXT glTextureLightEXT = (Delegates.glTextureLightEXT)GetAddress("glTextureLightEXT", typeof(Delegates.glTextureLightEXT));
        public static Delegates.glTextureMaterialEXT glTextureMaterialEXT = (Delegates.glTextureMaterialEXT)GetAddress("glTextureMaterialEXT", typeof(Delegates.glTextureMaterialEXT));
        public static Delegates.glAsyncMarkerSGIX glAsyncMarkerSGIX = (Delegates.glAsyncMarkerSGIX)GetAddress("glAsyncMarkerSGIX", typeof(Delegates.glAsyncMarkerSGIX));
        public static Delegates.glFinishAsyncSGIX glFinishAsyncSGIX = (Delegates.glFinishAsyncSGIX)GetAddress("glFinishAsyncSGIX", typeof(Delegates.glFinishAsyncSGIX));
        public static Delegates.glPollAsyncSGIX glPollAsyncSGIX = (Delegates.glPollAsyncSGIX)GetAddress("glPollAsyncSGIX", typeof(Delegates.glPollAsyncSGIX));
        public static Delegates.glGenAsyncMarkersSGIX glGenAsyncMarkersSGIX = (Delegates.glGenAsyncMarkersSGIX)GetAddress("glGenAsyncMarkersSGIX", typeof(Delegates.glGenAsyncMarkersSGIX));
        public static Delegates.glDeleteAsyncMarkersSGIX glDeleteAsyncMarkersSGIX = (Delegates.glDeleteAsyncMarkersSGIX)GetAddress("glDeleteAsyncMarkersSGIX", typeof(Delegates.glDeleteAsyncMarkersSGIX));
        public static Delegates.glIsAsyncMarkerSGIX glIsAsyncMarkerSGIX = (Delegates.glIsAsyncMarkerSGIX)GetAddress("glIsAsyncMarkerSGIX", typeof(Delegates.glIsAsyncMarkerSGIX));
        public static Delegates.glVertexPointervINTEL_ glVertexPointervINTEL_ = (Delegates.glVertexPointervINTEL_)GetAddress("glVertexPointervINTEL", typeof(Delegates.glVertexPointervINTEL_));
        public static Delegates.glNormalPointervINTEL_ glNormalPointervINTEL_ = (Delegates.glNormalPointervINTEL_)GetAddress("glNormalPointervINTEL", typeof(Delegates.glNormalPointervINTEL_));
        public static Delegates.glColorPointervINTEL_ glColorPointervINTEL_ = (Delegates.glColorPointervINTEL_)GetAddress("glColorPointervINTEL", typeof(Delegates.glColorPointervINTEL_));
        public static Delegates.glTexCoordPointervINTEL_ glTexCoordPointervINTEL_ = (Delegates.glTexCoordPointervINTEL_)GetAddress("glTexCoordPointervINTEL", typeof(Delegates.glTexCoordPointervINTEL_));
        public static Delegates.glPixelTransformParameteriEXT glPixelTransformParameteriEXT = (Delegates.glPixelTransformParameteriEXT)GetAddress("glPixelTransformParameteriEXT", typeof(Delegates.glPixelTransformParameteriEXT));
        public static Delegates.glPixelTransformParameterfEXT glPixelTransformParameterfEXT = (Delegates.glPixelTransformParameterfEXT)GetAddress("glPixelTransformParameterfEXT", typeof(Delegates.glPixelTransformParameterfEXT));
        public static Delegates.glPixelTransformParameterivEXT_ glPixelTransformParameterivEXT_ = (Delegates.glPixelTransformParameterivEXT_)GetAddress("glPixelTransformParameterivEXT", typeof(Delegates.glPixelTransformParameterivEXT_));
        public static Delegates.glPixelTransformParameterfvEXT_ glPixelTransformParameterfvEXT_ = (Delegates.glPixelTransformParameterfvEXT_)GetAddress("glPixelTransformParameterfvEXT", typeof(Delegates.glPixelTransformParameterfvEXT_));
        public static Delegates.glSecondaryColor3bEXT glSecondaryColor3bEXT = (Delegates.glSecondaryColor3bEXT)GetAddress("glSecondaryColor3bEXT", typeof(Delegates.glSecondaryColor3bEXT));
        public static Delegates.glSecondaryColor3bvEXT_ glSecondaryColor3bvEXT_ = (Delegates.glSecondaryColor3bvEXT_)GetAddress("glSecondaryColor3bvEXT", typeof(Delegates.glSecondaryColor3bvEXT_));
        public static Delegates.glSecondaryColor3dEXT glSecondaryColor3dEXT = (Delegates.glSecondaryColor3dEXT)GetAddress("glSecondaryColor3dEXT", typeof(Delegates.glSecondaryColor3dEXT));
        public static Delegates.glSecondaryColor3dvEXT_ glSecondaryColor3dvEXT_ = (Delegates.glSecondaryColor3dvEXT_)GetAddress("glSecondaryColor3dvEXT", typeof(Delegates.glSecondaryColor3dvEXT_));
        public static Delegates.glSecondaryColor3fEXT glSecondaryColor3fEXT = (Delegates.glSecondaryColor3fEXT)GetAddress("glSecondaryColor3fEXT", typeof(Delegates.glSecondaryColor3fEXT));
        public static Delegates.glSecondaryColor3fvEXT_ glSecondaryColor3fvEXT_ = (Delegates.glSecondaryColor3fvEXT_)GetAddress("glSecondaryColor3fvEXT", typeof(Delegates.glSecondaryColor3fvEXT_));
        public static Delegates.glSecondaryColor3iEXT glSecondaryColor3iEXT = (Delegates.glSecondaryColor3iEXT)GetAddress("glSecondaryColor3iEXT", typeof(Delegates.glSecondaryColor3iEXT));
        public static Delegates.glSecondaryColor3ivEXT_ glSecondaryColor3ivEXT_ = (Delegates.glSecondaryColor3ivEXT_)GetAddress("glSecondaryColor3ivEXT", typeof(Delegates.glSecondaryColor3ivEXT_));
        public static Delegates.glSecondaryColor3sEXT glSecondaryColor3sEXT = (Delegates.glSecondaryColor3sEXT)GetAddress("glSecondaryColor3sEXT", typeof(Delegates.glSecondaryColor3sEXT));
        public static Delegates.glSecondaryColor3svEXT_ glSecondaryColor3svEXT_ = (Delegates.glSecondaryColor3svEXT_)GetAddress("glSecondaryColor3svEXT", typeof(Delegates.glSecondaryColor3svEXT_));
        public static Delegates.glSecondaryColor3ubEXT glSecondaryColor3ubEXT = (Delegates.glSecondaryColor3ubEXT)GetAddress("glSecondaryColor3ubEXT", typeof(Delegates.glSecondaryColor3ubEXT));
        public static Delegates.glSecondaryColor3ubvEXT_ glSecondaryColor3ubvEXT_ = (Delegates.glSecondaryColor3ubvEXT_)GetAddress("glSecondaryColor3ubvEXT", typeof(Delegates.glSecondaryColor3ubvEXT_));
        public static Delegates.glSecondaryColor3uiEXT glSecondaryColor3uiEXT = (Delegates.glSecondaryColor3uiEXT)GetAddress("glSecondaryColor3uiEXT", typeof(Delegates.glSecondaryColor3uiEXT));
        public static Delegates.glSecondaryColor3uivEXT_ glSecondaryColor3uivEXT_ = (Delegates.glSecondaryColor3uivEXT_)GetAddress("glSecondaryColor3uivEXT", typeof(Delegates.glSecondaryColor3uivEXT_));
        public static Delegates.glSecondaryColor3usEXT glSecondaryColor3usEXT = (Delegates.glSecondaryColor3usEXT)GetAddress("glSecondaryColor3usEXT", typeof(Delegates.glSecondaryColor3usEXT));
        public static Delegates.glSecondaryColor3usvEXT_ glSecondaryColor3usvEXT_ = (Delegates.glSecondaryColor3usvEXT_)GetAddress("glSecondaryColor3usvEXT", typeof(Delegates.glSecondaryColor3usvEXT_));
        public static Delegates.glSecondaryColorPointerEXT_ glSecondaryColorPointerEXT_ = (Delegates.glSecondaryColorPointerEXT_)GetAddress("glSecondaryColorPointerEXT", typeof(Delegates.glSecondaryColorPointerEXT_));
        public static Delegates.glTextureNormalEXT glTextureNormalEXT = (Delegates.glTextureNormalEXT)GetAddress("glTextureNormalEXT", typeof(Delegates.glTextureNormalEXT));
        public static Delegates.glMultiDrawArraysEXT glMultiDrawArraysEXT = (Delegates.glMultiDrawArraysEXT)GetAddress("glMultiDrawArraysEXT", typeof(Delegates.glMultiDrawArraysEXT));
        public static Delegates.glMultiDrawElementsEXT_ glMultiDrawElementsEXT_ = (Delegates.glMultiDrawElementsEXT_)GetAddress("glMultiDrawElementsEXT", typeof(Delegates.glMultiDrawElementsEXT_));
        public static Delegates.glFogCoordfEXT glFogCoordfEXT = (Delegates.glFogCoordfEXT)GetAddress("glFogCoordfEXT", typeof(Delegates.glFogCoordfEXT));
        public static Delegates.glFogCoordfvEXT_ glFogCoordfvEXT_ = (Delegates.glFogCoordfvEXT_)GetAddress("glFogCoordfvEXT", typeof(Delegates.glFogCoordfvEXT_));
        public static Delegates.glFogCoorddEXT glFogCoorddEXT = (Delegates.glFogCoorddEXT)GetAddress("glFogCoorddEXT", typeof(Delegates.glFogCoorddEXT));
        public static Delegates.glFogCoorddvEXT_ glFogCoorddvEXT_ = (Delegates.glFogCoorddvEXT_)GetAddress("glFogCoorddvEXT", typeof(Delegates.glFogCoorddvEXT_));
        public static Delegates.glFogCoordPointerEXT_ glFogCoordPointerEXT_ = (Delegates.glFogCoordPointerEXT_)GetAddress("glFogCoordPointerEXT", typeof(Delegates.glFogCoordPointerEXT_));
        public static Delegates.glTangent3bEXT glTangent3bEXT = (Delegates.glTangent3bEXT)GetAddress("glTangent3bEXT", typeof(Delegates.glTangent3bEXT));
        public static Delegates.glTangent3bvEXT_ glTangent3bvEXT_ = (Delegates.glTangent3bvEXT_)GetAddress("glTangent3bvEXT", typeof(Delegates.glTangent3bvEXT_));
        public static Delegates.glTangent3dEXT glTangent3dEXT = (Delegates.glTangent3dEXT)GetAddress("glTangent3dEXT", typeof(Delegates.glTangent3dEXT));
        public static Delegates.glTangent3dvEXT_ glTangent3dvEXT_ = (Delegates.glTangent3dvEXT_)GetAddress("glTangent3dvEXT", typeof(Delegates.glTangent3dvEXT_));
        public static Delegates.glTangent3fEXT glTangent3fEXT = (Delegates.glTangent3fEXT)GetAddress("glTangent3fEXT", typeof(Delegates.glTangent3fEXT));
        public static Delegates.glTangent3fvEXT_ glTangent3fvEXT_ = (Delegates.glTangent3fvEXT_)GetAddress("glTangent3fvEXT", typeof(Delegates.glTangent3fvEXT_));
        public static Delegates.glTangent3iEXT glTangent3iEXT = (Delegates.glTangent3iEXT)GetAddress("glTangent3iEXT", typeof(Delegates.glTangent3iEXT));
        public static Delegates.glTangent3ivEXT_ glTangent3ivEXT_ = (Delegates.glTangent3ivEXT_)GetAddress("glTangent3ivEXT", typeof(Delegates.glTangent3ivEXT_));
        public static Delegates.glTangent3sEXT glTangent3sEXT = (Delegates.glTangent3sEXT)GetAddress("glTangent3sEXT", typeof(Delegates.glTangent3sEXT));
        public static Delegates.glTangent3svEXT_ glTangent3svEXT_ = (Delegates.glTangent3svEXT_)GetAddress("glTangent3svEXT", typeof(Delegates.glTangent3svEXT_));
        public static Delegates.glBinormal3bEXT glBinormal3bEXT = (Delegates.glBinormal3bEXT)GetAddress("glBinormal3bEXT", typeof(Delegates.glBinormal3bEXT));
        public static Delegates.glBinormal3bvEXT_ glBinormal3bvEXT_ = (Delegates.glBinormal3bvEXT_)GetAddress("glBinormal3bvEXT", typeof(Delegates.glBinormal3bvEXT_));
        public static Delegates.glBinormal3dEXT glBinormal3dEXT = (Delegates.glBinormal3dEXT)GetAddress("glBinormal3dEXT", typeof(Delegates.glBinormal3dEXT));
        public static Delegates.glBinormal3dvEXT_ glBinormal3dvEXT_ = (Delegates.glBinormal3dvEXT_)GetAddress("glBinormal3dvEXT", typeof(Delegates.glBinormal3dvEXT_));
        public static Delegates.glBinormal3fEXT glBinormal3fEXT = (Delegates.glBinormal3fEXT)GetAddress("glBinormal3fEXT", typeof(Delegates.glBinormal3fEXT));
        public static Delegates.glBinormal3fvEXT_ glBinormal3fvEXT_ = (Delegates.glBinormal3fvEXT_)GetAddress("glBinormal3fvEXT", typeof(Delegates.glBinormal3fvEXT_));
        public static Delegates.glBinormal3iEXT glBinormal3iEXT = (Delegates.glBinormal3iEXT)GetAddress("glBinormal3iEXT", typeof(Delegates.glBinormal3iEXT));
        public static Delegates.glBinormal3ivEXT_ glBinormal3ivEXT_ = (Delegates.glBinormal3ivEXT_)GetAddress("glBinormal3ivEXT", typeof(Delegates.glBinormal3ivEXT_));
        public static Delegates.glBinormal3sEXT glBinormal3sEXT = (Delegates.glBinormal3sEXT)GetAddress("glBinormal3sEXT", typeof(Delegates.glBinormal3sEXT));
        public static Delegates.glBinormal3svEXT_ glBinormal3svEXT_ = (Delegates.glBinormal3svEXT_)GetAddress("glBinormal3svEXT", typeof(Delegates.glBinormal3svEXT_));
        public static Delegates.glTangentPointerEXT_ glTangentPointerEXT_ = (Delegates.glTangentPointerEXT_)GetAddress("glTangentPointerEXT", typeof(Delegates.glTangentPointerEXT_));
        public static Delegates.glBinormalPointerEXT_ glBinormalPointerEXT_ = (Delegates.glBinormalPointerEXT_)GetAddress("glBinormalPointerEXT", typeof(Delegates.glBinormalPointerEXT_));
        public static Delegates.glFinishTextureSUNX glFinishTextureSUNX = (Delegates.glFinishTextureSUNX)GetAddress("glFinishTextureSUNX", typeof(Delegates.glFinishTextureSUNX));
        public static Delegates.glGlobalAlphaFactorbSUN glGlobalAlphaFactorbSUN = (Delegates.glGlobalAlphaFactorbSUN)GetAddress("glGlobalAlphaFactorbSUN", typeof(Delegates.glGlobalAlphaFactorbSUN));
        public static Delegates.glGlobalAlphaFactorsSUN glGlobalAlphaFactorsSUN = (Delegates.glGlobalAlphaFactorsSUN)GetAddress("glGlobalAlphaFactorsSUN", typeof(Delegates.glGlobalAlphaFactorsSUN));
        public static Delegates.glGlobalAlphaFactoriSUN glGlobalAlphaFactoriSUN = (Delegates.glGlobalAlphaFactoriSUN)GetAddress("glGlobalAlphaFactoriSUN", typeof(Delegates.glGlobalAlphaFactoriSUN));
        public static Delegates.glGlobalAlphaFactorfSUN glGlobalAlphaFactorfSUN = (Delegates.glGlobalAlphaFactorfSUN)GetAddress("glGlobalAlphaFactorfSUN", typeof(Delegates.glGlobalAlphaFactorfSUN));
        public static Delegates.glGlobalAlphaFactordSUN glGlobalAlphaFactordSUN = (Delegates.glGlobalAlphaFactordSUN)GetAddress("glGlobalAlphaFactordSUN", typeof(Delegates.glGlobalAlphaFactordSUN));
        public static Delegates.glGlobalAlphaFactorubSUN glGlobalAlphaFactorubSUN = (Delegates.glGlobalAlphaFactorubSUN)GetAddress("glGlobalAlphaFactorubSUN", typeof(Delegates.glGlobalAlphaFactorubSUN));
        public static Delegates.glGlobalAlphaFactorusSUN glGlobalAlphaFactorusSUN = (Delegates.glGlobalAlphaFactorusSUN)GetAddress("glGlobalAlphaFactorusSUN", typeof(Delegates.glGlobalAlphaFactorusSUN));
        public static Delegates.glGlobalAlphaFactoruiSUN glGlobalAlphaFactoruiSUN = (Delegates.glGlobalAlphaFactoruiSUN)GetAddress("glGlobalAlphaFactoruiSUN", typeof(Delegates.glGlobalAlphaFactoruiSUN));
        public static Delegates.glReplacementCodeuiSUN glReplacementCodeuiSUN = (Delegates.glReplacementCodeuiSUN)GetAddress("glReplacementCodeuiSUN", typeof(Delegates.glReplacementCodeuiSUN));
        public static Delegates.glReplacementCodeusSUN glReplacementCodeusSUN = (Delegates.glReplacementCodeusSUN)GetAddress("glReplacementCodeusSUN", typeof(Delegates.glReplacementCodeusSUN));
        public static Delegates.glReplacementCodeubSUN glReplacementCodeubSUN = (Delegates.glReplacementCodeubSUN)GetAddress("glReplacementCodeubSUN", typeof(Delegates.glReplacementCodeubSUN));
        public static Delegates.glReplacementCodeuivSUN_ glReplacementCodeuivSUN_ = (Delegates.glReplacementCodeuivSUN_)GetAddress("glReplacementCodeuivSUN", typeof(Delegates.glReplacementCodeuivSUN_));
        public static Delegates.glReplacementCodeusvSUN_ glReplacementCodeusvSUN_ = (Delegates.glReplacementCodeusvSUN_)GetAddress("glReplacementCodeusvSUN", typeof(Delegates.glReplacementCodeusvSUN_));
        public static Delegates.glReplacementCodeubvSUN_ glReplacementCodeubvSUN_ = (Delegates.glReplacementCodeubvSUN_)GetAddress("glReplacementCodeubvSUN", typeof(Delegates.glReplacementCodeubvSUN_));
        public static Delegates.glReplacementCodePointerSUN_ glReplacementCodePointerSUN_ = (Delegates.glReplacementCodePointerSUN_)GetAddress("glReplacementCodePointerSUN", typeof(Delegates.glReplacementCodePointerSUN_));
        public static Delegates.glColor4ubVertex2fSUN glColor4ubVertex2fSUN = (Delegates.glColor4ubVertex2fSUN)GetAddress("glColor4ubVertex2fSUN", typeof(Delegates.glColor4ubVertex2fSUN));
        public static Delegates.glColor4ubVertex2fvSUN_ glColor4ubVertex2fvSUN_ = (Delegates.glColor4ubVertex2fvSUN_)GetAddress("glColor4ubVertex2fvSUN", typeof(Delegates.glColor4ubVertex2fvSUN_));
        public static Delegates.glColor4ubVertex3fSUN glColor4ubVertex3fSUN = (Delegates.glColor4ubVertex3fSUN)GetAddress("glColor4ubVertex3fSUN", typeof(Delegates.glColor4ubVertex3fSUN));
        public static Delegates.glColor4ubVertex3fvSUN_ glColor4ubVertex3fvSUN_ = (Delegates.glColor4ubVertex3fvSUN_)GetAddress("glColor4ubVertex3fvSUN", typeof(Delegates.glColor4ubVertex3fvSUN_));
        public static Delegates.glColor3fVertex3fSUN glColor3fVertex3fSUN = (Delegates.glColor3fVertex3fSUN)GetAddress("glColor3fVertex3fSUN", typeof(Delegates.glColor3fVertex3fSUN));
        public static Delegates.glColor3fVertex3fvSUN_ glColor3fVertex3fvSUN_ = (Delegates.glColor3fVertex3fvSUN_)GetAddress("glColor3fVertex3fvSUN", typeof(Delegates.glColor3fVertex3fvSUN_));
        public static Delegates.glNormal3fVertex3fSUN glNormal3fVertex3fSUN = (Delegates.glNormal3fVertex3fSUN)GetAddress("glNormal3fVertex3fSUN", typeof(Delegates.glNormal3fVertex3fSUN));
        public static Delegates.glNormal3fVertex3fvSUN_ glNormal3fVertex3fvSUN_ = (Delegates.glNormal3fVertex3fvSUN_)GetAddress("glNormal3fVertex3fvSUN", typeof(Delegates.glNormal3fVertex3fvSUN_));
        public static Delegates.glColor4fNormal3fVertex3fSUN glColor4fNormal3fVertex3fSUN = (Delegates.glColor4fNormal3fVertex3fSUN)GetAddress("glColor4fNormal3fVertex3fSUN", typeof(Delegates.glColor4fNormal3fVertex3fSUN));
        public static Delegates.glColor4fNormal3fVertex3fvSUN_ glColor4fNormal3fVertex3fvSUN_ = (Delegates.glColor4fNormal3fVertex3fvSUN_)GetAddress("glColor4fNormal3fVertex3fvSUN", typeof(Delegates.glColor4fNormal3fVertex3fvSUN_));
        public static Delegates.glTexCoord2fVertex3fSUN glTexCoord2fVertex3fSUN = (Delegates.glTexCoord2fVertex3fSUN)GetAddress("glTexCoord2fVertex3fSUN", typeof(Delegates.glTexCoord2fVertex3fSUN));
        public static Delegates.glTexCoord2fVertex3fvSUN_ glTexCoord2fVertex3fvSUN_ = (Delegates.glTexCoord2fVertex3fvSUN_)GetAddress("glTexCoord2fVertex3fvSUN", typeof(Delegates.glTexCoord2fVertex3fvSUN_));
        public static Delegates.glTexCoord4fVertex4fSUN glTexCoord4fVertex4fSUN = (Delegates.glTexCoord4fVertex4fSUN)GetAddress("glTexCoord4fVertex4fSUN", typeof(Delegates.glTexCoord4fVertex4fSUN));
        public static Delegates.glTexCoord4fVertex4fvSUN_ glTexCoord4fVertex4fvSUN_ = (Delegates.glTexCoord4fVertex4fvSUN_)GetAddress("glTexCoord4fVertex4fvSUN", typeof(Delegates.glTexCoord4fVertex4fvSUN_));
        public static Delegates.glTexCoord2fColor4ubVertex3fSUN glTexCoord2fColor4ubVertex3fSUN = (Delegates.glTexCoord2fColor4ubVertex3fSUN)GetAddress("glTexCoord2fColor4ubVertex3fSUN", typeof(Delegates.glTexCoord2fColor4ubVertex3fSUN));
        public static Delegates.glTexCoord2fColor4ubVertex3fvSUN_ glTexCoord2fColor4ubVertex3fvSUN_ = (Delegates.glTexCoord2fColor4ubVertex3fvSUN_)GetAddress("glTexCoord2fColor4ubVertex3fvSUN", typeof(Delegates.glTexCoord2fColor4ubVertex3fvSUN_));
        public static Delegates.glTexCoord2fColor3fVertex3fSUN glTexCoord2fColor3fVertex3fSUN = (Delegates.glTexCoord2fColor3fVertex3fSUN)GetAddress("glTexCoord2fColor3fVertex3fSUN", typeof(Delegates.glTexCoord2fColor3fVertex3fSUN));
        public static Delegates.glTexCoord2fColor3fVertex3fvSUN_ glTexCoord2fColor3fVertex3fvSUN_ = (Delegates.glTexCoord2fColor3fVertex3fvSUN_)GetAddress("glTexCoord2fColor3fVertex3fvSUN", typeof(Delegates.glTexCoord2fColor3fVertex3fvSUN_));
        public static Delegates.glTexCoord2fNormal3fVertex3fSUN glTexCoord2fNormal3fVertex3fSUN = (Delegates.glTexCoord2fNormal3fVertex3fSUN)GetAddress("glTexCoord2fNormal3fVertex3fSUN", typeof(Delegates.glTexCoord2fNormal3fVertex3fSUN));
        public static Delegates.glTexCoord2fNormal3fVertex3fvSUN_ glTexCoord2fNormal3fVertex3fvSUN_ = (Delegates.glTexCoord2fNormal3fVertex3fvSUN_)GetAddress("glTexCoord2fNormal3fVertex3fvSUN", typeof(Delegates.glTexCoord2fNormal3fVertex3fvSUN_));
        public static Delegates.glTexCoord2fColor4fNormal3fVertex3fSUN glTexCoord2fColor4fNormal3fVertex3fSUN = (Delegates.glTexCoord2fColor4fNormal3fVertex3fSUN)GetAddress("glTexCoord2fColor4fNormal3fVertex3fSUN", typeof(Delegates.glTexCoord2fColor4fNormal3fVertex3fSUN));
        public static Delegates.glTexCoord2fColor4fNormal3fVertex3fvSUN_ glTexCoord2fColor4fNormal3fVertex3fvSUN_ = (Delegates.glTexCoord2fColor4fNormal3fVertex3fvSUN_)GetAddress("glTexCoord2fColor4fNormal3fVertex3fvSUN", typeof(Delegates.glTexCoord2fColor4fNormal3fVertex3fvSUN_));
        public static Delegates.glTexCoord4fColor4fNormal3fVertex4fSUN glTexCoord4fColor4fNormal3fVertex4fSUN = (Delegates.glTexCoord4fColor4fNormal3fVertex4fSUN)GetAddress("glTexCoord4fColor4fNormal3fVertex4fSUN", typeof(Delegates.glTexCoord4fColor4fNormal3fVertex4fSUN));
        public static Delegates.glTexCoord4fColor4fNormal3fVertex4fvSUN_ glTexCoord4fColor4fNormal3fVertex4fvSUN_ = (Delegates.glTexCoord4fColor4fNormal3fVertex4fvSUN_)GetAddress("glTexCoord4fColor4fNormal3fVertex4fvSUN", typeof(Delegates.glTexCoord4fColor4fNormal3fVertex4fvSUN_));
        public static Delegates.glReplacementCodeuiVertex3fSUN glReplacementCodeuiVertex3fSUN = (Delegates.glReplacementCodeuiVertex3fSUN)GetAddress("glReplacementCodeuiVertex3fSUN", typeof(Delegates.glReplacementCodeuiVertex3fSUN));
        public static Delegates.glReplacementCodeuiVertex3fvSUN_ glReplacementCodeuiVertex3fvSUN_ = (Delegates.glReplacementCodeuiVertex3fvSUN_)GetAddress("glReplacementCodeuiVertex3fvSUN", typeof(Delegates.glReplacementCodeuiVertex3fvSUN_));
        public static Delegates.glReplacementCodeuiColor4ubVertex3fSUN glReplacementCodeuiColor4ubVertex3fSUN = (Delegates.glReplacementCodeuiColor4ubVertex3fSUN)GetAddress("glReplacementCodeuiColor4ubVertex3fSUN", typeof(Delegates.glReplacementCodeuiColor4ubVertex3fSUN));
        public static Delegates.glReplacementCodeuiColor4ubVertex3fvSUN_ glReplacementCodeuiColor4ubVertex3fvSUN_ = (Delegates.glReplacementCodeuiColor4ubVertex3fvSUN_)GetAddress("glReplacementCodeuiColor4ubVertex3fvSUN", typeof(Delegates.glReplacementCodeuiColor4ubVertex3fvSUN_));
        public static Delegates.glReplacementCodeuiColor3fVertex3fSUN glReplacementCodeuiColor3fVertex3fSUN = (Delegates.glReplacementCodeuiColor3fVertex3fSUN)GetAddress("glReplacementCodeuiColor3fVertex3fSUN", typeof(Delegates.glReplacementCodeuiColor3fVertex3fSUN));
        public static Delegates.glReplacementCodeuiColor3fVertex3fvSUN_ glReplacementCodeuiColor3fVertex3fvSUN_ = (Delegates.glReplacementCodeuiColor3fVertex3fvSUN_)GetAddress("glReplacementCodeuiColor3fVertex3fvSUN", typeof(Delegates.glReplacementCodeuiColor3fVertex3fvSUN_));
        public static Delegates.glReplacementCodeuiNormal3fVertex3fSUN glReplacementCodeuiNormal3fVertex3fSUN = (Delegates.glReplacementCodeuiNormal3fVertex3fSUN)GetAddress("glReplacementCodeuiNormal3fVertex3fSUN", typeof(Delegates.glReplacementCodeuiNormal3fVertex3fSUN));
        public static Delegates.glReplacementCodeuiNormal3fVertex3fvSUN_ glReplacementCodeuiNormal3fVertex3fvSUN_ = (Delegates.glReplacementCodeuiNormal3fVertex3fvSUN_)GetAddress("glReplacementCodeuiNormal3fVertex3fvSUN", typeof(Delegates.glReplacementCodeuiNormal3fVertex3fvSUN_));
        public static Delegates.glReplacementCodeuiColor4fNormal3fVertex3fSUN glReplacementCodeuiColor4fNormal3fVertex3fSUN = (Delegates.glReplacementCodeuiColor4fNormal3fVertex3fSUN)GetAddress("glReplacementCodeuiColor4fNormal3fVertex3fSUN", typeof(Delegates.glReplacementCodeuiColor4fNormal3fVertex3fSUN));
        public static Delegates.glReplacementCodeuiColor4fNormal3fVertex3fvSUN_ glReplacementCodeuiColor4fNormal3fVertex3fvSUN_ = (Delegates.glReplacementCodeuiColor4fNormal3fVertex3fvSUN_)GetAddress("glReplacementCodeuiColor4fNormal3fVertex3fvSUN", typeof(Delegates.glReplacementCodeuiColor4fNormal3fVertex3fvSUN_));
        public static Delegates.glReplacementCodeuiTexCoord2fVertex3fSUN glReplacementCodeuiTexCoord2fVertex3fSUN = (Delegates.glReplacementCodeuiTexCoord2fVertex3fSUN)GetAddress("glReplacementCodeuiTexCoord2fVertex3fSUN", typeof(Delegates.glReplacementCodeuiTexCoord2fVertex3fSUN));
        public static Delegates.glReplacementCodeuiTexCoord2fVertex3fvSUN_ glReplacementCodeuiTexCoord2fVertex3fvSUN_ = (Delegates.glReplacementCodeuiTexCoord2fVertex3fvSUN_)GetAddress("glReplacementCodeuiTexCoord2fVertex3fvSUN", typeof(Delegates.glReplacementCodeuiTexCoord2fVertex3fvSUN_));
        public static Delegates.glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN = (Delegates.glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN)GetAddress("glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN", typeof(Delegates.glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN));
        public static Delegates.glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN_ glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN_ = (Delegates.glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN_)GetAddress("glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN", typeof(Delegates.glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN_));
        public static Delegates.glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN = (Delegates.glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN)GetAddress("glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN", typeof(Delegates.glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN));
        public static Delegates.glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN_ glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN_ = (Delegates.glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN_)GetAddress("glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN", typeof(Delegates.glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN_));
        public static Delegates.glBlendFuncSeparateEXT glBlendFuncSeparateEXT = (Delegates.glBlendFuncSeparateEXT)GetAddress("glBlendFuncSeparateEXT", typeof(Delegates.glBlendFuncSeparateEXT));
        public static Delegates.glBlendFuncSeparateINGR glBlendFuncSeparateINGR = (Delegates.glBlendFuncSeparateINGR)GetAddress("glBlendFuncSeparateINGR", typeof(Delegates.glBlendFuncSeparateINGR));
        public static Delegates.glVertexWeightfEXT glVertexWeightfEXT = (Delegates.glVertexWeightfEXT)GetAddress("glVertexWeightfEXT", typeof(Delegates.glVertexWeightfEXT));
        public static Delegates.glVertexWeightfvEXT_ glVertexWeightfvEXT_ = (Delegates.glVertexWeightfvEXT_)GetAddress("glVertexWeightfvEXT", typeof(Delegates.glVertexWeightfvEXT_));
        public static Delegates.glVertexWeightPointerEXT_ glVertexWeightPointerEXT_ = (Delegates.glVertexWeightPointerEXT_)GetAddress("glVertexWeightPointerEXT", typeof(Delegates.glVertexWeightPointerEXT_));
        public static Delegates.glFlushVertexArrayRangeNV glFlushVertexArrayRangeNV = (Delegates.glFlushVertexArrayRangeNV)GetAddress("glFlushVertexArrayRangeNV", typeof(Delegates.glFlushVertexArrayRangeNV));
        public static Delegates.glVertexArrayRangeNV_ glVertexArrayRangeNV_ = (Delegates.glVertexArrayRangeNV_)GetAddress("glVertexArrayRangeNV", typeof(Delegates.glVertexArrayRangeNV_));
        public static Delegates.glCombinerParameterfvNV_ glCombinerParameterfvNV_ = (Delegates.glCombinerParameterfvNV_)GetAddress("glCombinerParameterfvNV", typeof(Delegates.glCombinerParameterfvNV_));
        public static Delegates.glCombinerParameterfNV glCombinerParameterfNV = (Delegates.glCombinerParameterfNV)GetAddress("glCombinerParameterfNV", typeof(Delegates.glCombinerParameterfNV));
        public static Delegates.glCombinerParameterivNV_ glCombinerParameterivNV_ = (Delegates.glCombinerParameterivNV_)GetAddress("glCombinerParameterivNV", typeof(Delegates.glCombinerParameterivNV_));
        public static Delegates.glCombinerParameteriNV glCombinerParameteriNV = (Delegates.glCombinerParameteriNV)GetAddress("glCombinerParameteriNV", typeof(Delegates.glCombinerParameteriNV));
        public static Delegates.glCombinerInputNV glCombinerInputNV = (Delegates.glCombinerInputNV)GetAddress("glCombinerInputNV", typeof(Delegates.glCombinerInputNV));
        public static Delegates.glCombinerOutputNV glCombinerOutputNV = (Delegates.glCombinerOutputNV)GetAddress("glCombinerOutputNV", typeof(Delegates.glCombinerOutputNV));
        public static Delegates.glFinalCombinerInputNV glFinalCombinerInputNV = (Delegates.glFinalCombinerInputNV)GetAddress("glFinalCombinerInputNV", typeof(Delegates.glFinalCombinerInputNV));
        public static Delegates.glGetCombinerInputParameterfvNV glGetCombinerInputParameterfvNV = (Delegates.glGetCombinerInputParameterfvNV)GetAddress("glGetCombinerInputParameterfvNV", typeof(Delegates.glGetCombinerInputParameterfvNV));
        public static Delegates.glGetCombinerInputParameterivNV glGetCombinerInputParameterivNV = (Delegates.glGetCombinerInputParameterivNV)GetAddress("glGetCombinerInputParameterivNV", typeof(Delegates.glGetCombinerInputParameterivNV));
        public static Delegates.glGetCombinerOutputParameterfvNV glGetCombinerOutputParameterfvNV = (Delegates.glGetCombinerOutputParameterfvNV)GetAddress("glGetCombinerOutputParameterfvNV", typeof(Delegates.glGetCombinerOutputParameterfvNV));
        public static Delegates.glGetCombinerOutputParameterivNV glGetCombinerOutputParameterivNV = (Delegates.glGetCombinerOutputParameterivNV)GetAddress("glGetCombinerOutputParameterivNV", typeof(Delegates.glGetCombinerOutputParameterivNV));
        public static Delegates.glGetFinalCombinerInputParameterfvNV glGetFinalCombinerInputParameterfvNV = (Delegates.glGetFinalCombinerInputParameterfvNV)GetAddress("glGetFinalCombinerInputParameterfvNV", typeof(Delegates.glGetFinalCombinerInputParameterfvNV));
        public static Delegates.glGetFinalCombinerInputParameterivNV glGetFinalCombinerInputParameterivNV = (Delegates.glGetFinalCombinerInputParameterivNV)GetAddress("glGetFinalCombinerInputParameterivNV", typeof(Delegates.glGetFinalCombinerInputParameterivNV));
        public static Delegates.glResizeBuffersMESA glResizeBuffersMESA = (Delegates.glResizeBuffersMESA)GetAddress("glResizeBuffersMESA", typeof(Delegates.glResizeBuffersMESA));
        public static Delegates.glWindowPos2dMESA glWindowPos2dMESA = (Delegates.glWindowPos2dMESA)GetAddress("glWindowPos2dMESA", typeof(Delegates.glWindowPos2dMESA));
        public static Delegates.glWindowPos2dvMESA_ glWindowPos2dvMESA_ = (Delegates.glWindowPos2dvMESA_)GetAddress("glWindowPos2dvMESA", typeof(Delegates.glWindowPos2dvMESA_));
        public static Delegates.glWindowPos2fMESA glWindowPos2fMESA = (Delegates.glWindowPos2fMESA)GetAddress("glWindowPos2fMESA", typeof(Delegates.glWindowPos2fMESA));
        public static Delegates.glWindowPos2fvMESA_ glWindowPos2fvMESA_ = (Delegates.glWindowPos2fvMESA_)GetAddress("glWindowPos2fvMESA", typeof(Delegates.glWindowPos2fvMESA_));
        public static Delegates.glWindowPos2iMESA glWindowPos2iMESA = (Delegates.glWindowPos2iMESA)GetAddress("glWindowPos2iMESA", typeof(Delegates.glWindowPos2iMESA));
        public static Delegates.glWindowPos2ivMESA_ glWindowPos2ivMESA_ = (Delegates.glWindowPos2ivMESA_)GetAddress("glWindowPos2ivMESA", typeof(Delegates.glWindowPos2ivMESA_));
        public static Delegates.glWindowPos2sMESA glWindowPos2sMESA = (Delegates.glWindowPos2sMESA)GetAddress("glWindowPos2sMESA", typeof(Delegates.glWindowPos2sMESA));
        public static Delegates.glWindowPos2svMESA_ glWindowPos2svMESA_ = (Delegates.glWindowPos2svMESA_)GetAddress("glWindowPos2svMESA", typeof(Delegates.glWindowPos2svMESA_));
        public static Delegates.glWindowPos3dMESA glWindowPos3dMESA = (Delegates.glWindowPos3dMESA)GetAddress("glWindowPos3dMESA", typeof(Delegates.glWindowPos3dMESA));
        public static Delegates.glWindowPos3dvMESA_ glWindowPos3dvMESA_ = (Delegates.glWindowPos3dvMESA_)GetAddress("glWindowPos3dvMESA", typeof(Delegates.glWindowPos3dvMESA_));
        public static Delegates.glWindowPos3fMESA glWindowPos3fMESA = (Delegates.glWindowPos3fMESA)GetAddress("glWindowPos3fMESA", typeof(Delegates.glWindowPos3fMESA));
        public static Delegates.glWindowPos3fvMESA_ glWindowPos3fvMESA_ = (Delegates.glWindowPos3fvMESA_)GetAddress("glWindowPos3fvMESA", typeof(Delegates.glWindowPos3fvMESA_));
        public static Delegates.glWindowPos3iMESA glWindowPos3iMESA = (Delegates.glWindowPos3iMESA)GetAddress("glWindowPos3iMESA", typeof(Delegates.glWindowPos3iMESA));
        public static Delegates.glWindowPos3ivMESA_ glWindowPos3ivMESA_ = (Delegates.glWindowPos3ivMESA_)GetAddress("glWindowPos3ivMESA", typeof(Delegates.glWindowPos3ivMESA_));
        public static Delegates.glWindowPos3sMESA glWindowPos3sMESA = (Delegates.glWindowPos3sMESA)GetAddress("glWindowPos3sMESA", typeof(Delegates.glWindowPos3sMESA));
        public static Delegates.glWindowPos3svMESA_ glWindowPos3svMESA_ = (Delegates.glWindowPos3svMESA_)GetAddress("glWindowPos3svMESA", typeof(Delegates.glWindowPos3svMESA_));
        public static Delegates.glWindowPos4dMESA glWindowPos4dMESA = (Delegates.glWindowPos4dMESA)GetAddress("glWindowPos4dMESA", typeof(Delegates.glWindowPos4dMESA));
        public static Delegates.glWindowPos4dvMESA_ glWindowPos4dvMESA_ = (Delegates.glWindowPos4dvMESA_)GetAddress("glWindowPos4dvMESA", typeof(Delegates.glWindowPos4dvMESA_));
        public static Delegates.glWindowPos4fMESA glWindowPos4fMESA = (Delegates.glWindowPos4fMESA)GetAddress("glWindowPos4fMESA", typeof(Delegates.glWindowPos4fMESA));
        public static Delegates.glWindowPos4fvMESA_ glWindowPos4fvMESA_ = (Delegates.glWindowPos4fvMESA_)GetAddress("glWindowPos4fvMESA", typeof(Delegates.glWindowPos4fvMESA_));
        public static Delegates.glWindowPos4iMESA glWindowPos4iMESA = (Delegates.glWindowPos4iMESA)GetAddress("glWindowPos4iMESA", typeof(Delegates.glWindowPos4iMESA));
        public static Delegates.glWindowPos4ivMESA_ glWindowPos4ivMESA_ = (Delegates.glWindowPos4ivMESA_)GetAddress("glWindowPos4ivMESA", typeof(Delegates.glWindowPos4ivMESA_));
        public static Delegates.glWindowPos4sMESA glWindowPos4sMESA = (Delegates.glWindowPos4sMESA)GetAddress("glWindowPos4sMESA", typeof(Delegates.glWindowPos4sMESA));
        public static Delegates.glWindowPos4svMESA_ glWindowPos4svMESA_ = (Delegates.glWindowPos4svMESA_)GetAddress("glWindowPos4svMESA", typeof(Delegates.glWindowPos4svMESA_));
        public static Delegates.glMultiModeDrawArraysIBM_ glMultiModeDrawArraysIBM_ = (Delegates.glMultiModeDrawArraysIBM_)GetAddress("glMultiModeDrawArraysIBM", typeof(Delegates.glMultiModeDrawArraysIBM_));
        public static Delegates.glMultiModeDrawElementsIBM_ glMultiModeDrawElementsIBM_ = (Delegates.glMultiModeDrawElementsIBM_)GetAddress("glMultiModeDrawElementsIBM", typeof(Delegates.glMultiModeDrawElementsIBM_));
        public static Delegates.glColorPointerListIBM_ glColorPointerListIBM_ = (Delegates.glColorPointerListIBM_)GetAddress("glColorPointerListIBM", typeof(Delegates.glColorPointerListIBM_));
        public static Delegates.glSecondaryColorPointerListIBM_ glSecondaryColorPointerListIBM_ = (Delegates.glSecondaryColorPointerListIBM_)GetAddress("glSecondaryColorPointerListIBM", typeof(Delegates.glSecondaryColorPointerListIBM_));
        public static Delegates.glEdgeFlagPointerListIBM_ glEdgeFlagPointerListIBM_ = (Delegates.glEdgeFlagPointerListIBM_)GetAddress("glEdgeFlagPointerListIBM", typeof(Delegates.glEdgeFlagPointerListIBM_));
        public static Delegates.glFogCoordPointerListIBM_ glFogCoordPointerListIBM_ = (Delegates.glFogCoordPointerListIBM_)GetAddress("glFogCoordPointerListIBM", typeof(Delegates.glFogCoordPointerListIBM_));
        public static Delegates.glIndexPointerListIBM_ glIndexPointerListIBM_ = (Delegates.glIndexPointerListIBM_)GetAddress("glIndexPointerListIBM", typeof(Delegates.glIndexPointerListIBM_));
        public static Delegates.glNormalPointerListIBM_ glNormalPointerListIBM_ = (Delegates.glNormalPointerListIBM_)GetAddress("glNormalPointerListIBM", typeof(Delegates.glNormalPointerListIBM_));
        public static Delegates.glTexCoordPointerListIBM_ glTexCoordPointerListIBM_ = (Delegates.glTexCoordPointerListIBM_)GetAddress("glTexCoordPointerListIBM", typeof(Delegates.glTexCoordPointerListIBM_));
        public static Delegates.glVertexPointerListIBM_ glVertexPointerListIBM_ = (Delegates.glVertexPointerListIBM_)GetAddress("glVertexPointerListIBM", typeof(Delegates.glVertexPointerListIBM_));
        public static Delegates.glTbufferMask3DFX glTbufferMask3DFX = (Delegates.glTbufferMask3DFX)GetAddress("glTbufferMask3DFX", typeof(Delegates.glTbufferMask3DFX));
        public static Delegates.glSampleMaskEXT glSampleMaskEXT = (Delegates.glSampleMaskEXT)GetAddress("glSampleMaskEXT", typeof(Delegates.glSampleMaskEXT));
        public static Delegates.glSamplePatternEXT glSamplePatternEXT = (Delegates.glSamplePatternEXT)GetAddress("glSamplePatternEXT", typeof(Delegates.glSamplePatternEXT));
        public static Delegates.glTextureColorMaskSGIS glTextureColorMaskSGIS = (Delegates.glTextureColorMaskSGIS)GetAddress("glTextureColorMaskSGIS", typeof(Delegates.glTextureColorMaskSGIS));
        public static Delegates.glIglooInterfaceSGIX_ glIglooInterfaceSGIX_ = (Delegates.glIglooInterfaceSGIX_)GetAddress("glIglooInterfaceSGIX", typeof(Delegates.glIglooInterfaceSGIX_));
        public static Delegates.glDeleteFencesNV_ glDeleteFencesNV_ = (Delegates.glDeleteFencesNV_)GetAddress("glDeleteFencesNV", typeof(Delegates.glDeleteFencesNV_));
        public static Delegates.glGenFencesNV glGenFencesNV = (Delegates.glGenFencesNV)GetAddress("glGenFencesNV", typeof(Delegates.glGenFencesNV));
        public static Delegates.glIsFenceNV glIsFenceNV = (Delegates.glIsFenceNV)GetAddress("glIsFenceNV", typeof(Delegates.glIsFenceNV));
        public static Delegates.glTestFenceNV glTestFenceNV = (Delegates.glTestFenceNV)GetAddress("glTestFenceNV", typeof(Delegates.glTestFenceNV));
        public static Delegates.glGetFenceivNV glGetFenceivNV = (Delegates.glGetFenceivNV)GetAddress("glGetFenceivNV", typeof(Delegates.glGetFenceivNV));
        public static Delegates.glFinishFenceNV glFinishFenceNV = (Delegates.glFinishFenceNV)GetAddress("glFinishFenceNV", typeof(Delegates.glFinishFenceNV));
        public static Delegates.glSetFenceNV glSetFenceNV = (Delegates.glSetFenceNV)GetAddress("glSetFenceNV", typeof(Delegates.glSetFenceNV));
        public static Delegates.glMapControlPointsNV_ glMapControlPointsNV_ = (Delegates.glMapControlPointsNV_)GetAddress("glMapControlPointsNV", typeof(Delegates.glMapControlPointsNV_));
        public static Delegates.glMapParameterivNV_ glMapParameterivNV_ = (Delegates.glMapParameterivNV_)GetAddress("glMapParameterivNV", typeof(Delegates.glMapParameterivNV_));
        public static Delegates.glMapParameterfvNV_ glMapParameterfvNV_ = (Delegates.glMapParameterfvNV_)GetAddress("glMapParameterfvNV", typeof(Delegates.glMapParameterfvNV_));
        public static Delegates.glGetMapControlPointsNV_ glGetMapControlPointsNV_ = (Delegates.glGetMapControlPointsNV_)GetAddress("glGetMapControlPointsNV", typeof(Delegates.glGetMapControlPointsNV_));
        public static Delegates.glGetMapParameterivNV glGetMapParameterivNV = (Delegates.glGetMapParameterivNV)GetAddress("glGetMapParameterivNV", typeof(Delegates.glGetMapParameterivNV));
        public static Delegates.glGetMapParameterfvNV glGetMapParameterfvNV = (Delegates.glGetMapParameterfvNV)GetAddress("glGetMapParameterfvNV", typeof(Delegates.glGetMapParameterfvNV));
        public static Delegates.glGetMapAttribParameterivNV glGetMapAttribParameterivNV = (Delegates.glGetMapAttribParameterivNV)GetAddress("glGetMapAttribParameterivNV", typeof(Delegates.glGetMapAttribParameterivNV));
        public static Delegates.glGetMapAttribParameterfvNV glGetMapAttribParameterfvNV = (Delegates.glGetMapAttribParameterfvNV)GetAddress("glGetMapAttribParameterfvNV", typeof(Delegates.glGetMapAttribParameterfvNV));
        public static Delegates.glEvalMapsNV glEvalMapsNV = (Delegates.glEvalMapsNV)GetAddress("glEvalMapsNV", typeof(Delegates.glEvalMapsNV));
        public static Delegates.glCombinerStageParameterfvNV_ glCombinerStageParameterfvNV_ = (Delegates.glCombinerStageParameterfvNV_)GetAddress("glCombinerStageParameterfvNV", typeof(Delegates.glCombinerStageParameterfvNV_));
        public static Delegates.glGetCombinerStageParameterfvNV glGetCombinerStageParameterfvNV = (Delegates.glGetCombinerStageParameterfvNV)GetAddress("glGetCombinerStageParameterfvNV", typeof(Delegates.glGetCombinerStageParameterfvNV));
        public static Delegates.glAreProgramsResidentNV_ glAreProgramsResidentNV_ = (Delegates.glAreProgramsResidentNV_)GetAddress("glAreProgramsResidentNV", typeof(Delegates.glAreProgramsResidentNV_));
        public static Delegates.glBindProgramNV glBindProgramNV = (Delegates.glBindProgramNV)GetAddress("glBindProgramNV", typeof(Delegates.glBindProgramNV));
        public static Delegates.glDeleteProgramsNV_ glDeleteProgramsNV_ = (Delegates.glDeleteProgramsNV_)GetAddress("glDeleteProgramsNV", typeof(Delegates.glDeleteProgramsNV_));
        public static Delegates.glExecuteProgramNV_ glExecuteProgramNV_ = (Delegates.glExecuteProgramNV_)GetAddress("glExecuteProgramNV", typeof(Delegates.glExecuteProgramNV_));
        public static Delegates.glGenProgramsNV glGenProgramsNV = (Delegates.glGenProgramsNV)GetAddress("glGenProgramsNV", typeof(Delegates.glGenProgramsNV));
        public static Delegates.glGetProgramParameterdvNV glGetProgramParameterdvNV = (Delegates.glGetProgramParameterdvNV)GetAddress("glGetProgramParameterdvNV", typeof(Delegates.glGetProgramParameterdvNV));
        public static Delegates.glGetProgramParameterfvNV glGetProgramParameterfvNV = (Delegates.glGetProgramParameterfvNV)GetAddress("glGetProgramParameterfvNV", typeof(Delegates.glGetProgramParameterfvNV));
        public static Delegates.glGetProgramivNV glGetProgramivNV = (Delegates.glGetProgramivNV)GetAddress("glGetProgramivNV", typeof(Delegates.glGetProgramivNV));
        public static Delegates.glGetProgramStringNV glGetProgramStringNV = (Delegates.glGetProgramStringNV)GetAddress("glGetProgramStringNV", typeof(Delegates.glGetProgramStringNV));
        public static Delegates.glGetTrackMatrixivNV glGetTrackMatrixivNV = (Delegates.glGetTrackMatrixivNV)GetAddress("glGetTrackMatrixivNV", typeof(Delegates.glGetTrackMatrixivNV));
        public static Delegates.glGetVertexAttribdvNV glGetVertexAttribdvNV = (Delegates.glGetVertexAttribdvNV)GetAddress("glGetVertexAttribdvNV", typeof(Delegates.glGetVertexAttribdvNV));
        public static Delegates.glGetVertexAttribfvNV glGetVertexAttribfvNV = (Delegates.glGetVertexAttribfvNV)GetAddress("glGetVertexAttribfvNV", typeof(Delegates.glGetVertexAttribfvNV));
        public static Delegates.glGetVertexAttribivNV glGetVertexAttribivNV = (Delegates.glGetVertexAttribivNV)GetAddress("glGetVertexAttribivNV", typeof(Delegates.glGetVertexAttribivNV));
        public static Delegates.glGetVertexAttribPointervNV glGetVertexAttribPointervNV = (Delegates.glGetVertexAttribPointervNV)GetAddress("glGetVertexAttribPointervNV", typeof(Delegates.glGetVertexAttribPointervNV));
        public static Delegates.glIsProgramNV glIsProgramNV = (Delegates.glIsProgramNV)GetAddress("glIsProgramNV", typeof(Delegates.glIsProgramNV));
        public static Delegates.glLoadProgramNV_ glLoadProgramNV_ = (Delegates.glLoadProgramNV_)GetAddress("glLoadProgramNV", typeof(Delegates.glLoadProgramNV_));
        public static Delegates.glProgramParameter4dNV glProgramParameter4dNV = (Delegates.glProgramParameter4dNV)GetAddress("glProgramParameter4dNV", typeof(Delegates.glProgramParameter4dNV));
        public static Delegates.glProgramParameter4dvNV_ glProgramParameter4dvNV_ = (Delegates.glProgramParameter4dvNV_)GetAddress("glProgramParameter4dvNV", typeof(Delegates.glProgramParameter4dvNV_));
        public static Delegates.glProgramParameter4fNV glProgramParameter4fNV = (Delegates.glProgramParameter4fNV)GetAddress("glProgramParameter4fNV", typeof(Delegates.glProgramParameter4fNV));
        public static Delegates.glProgramParameter4fvNV_ glProgramParameter4fvNV_ = (Delegates.glProgramParameter4fvNV_)GetAddress("glProgramParameter4fvNV", typeof(Delegates.glProgramParameter4fvNV_));
        public static Delegates.glProgramParameters4dvNV_ glProgramParameters4dvNV_ = (Delegates.glProgramParameters4dvNV_)GetAddress("glProgramParameters4dvNV", typeof(Delegates.glProgramParameters4dvNV_));
        public static Delegates.glProgramParameters4fvNV_ glProgramParameters4fvNV_ = (Delegates.glProgramParameters4fvNV_)GetAddress("glProgramParameters4fvNV", typeof(Delegates.glProgramParameters4fvNV_));
        public static Delegates.glRequestResidentProgramsNV_ glRequestResidentProgramsNV_ = (Delegates.glRequestResidentProgramsNV_)GetAddress("glRequestResidentProgramsNV", typeof(Delegates.glRequestResidentProgramsNV_));
        public static Delegates.glTrackMatrixNV glTrackMatrixNV = (Delegates.glTrackMatrixNV)GetAddress("glTrackMatrixNV", typeof(Delegates.glTrackMatrixNV));
        public static Delegates.glVertexAttribPointerNV_ glVertexAttribPointerNV_ = (Delegates.glVertexAttribPointerNV_)GetAddress("glVertexAttribPointerNV", typeof(Delegates.glVertexAttribPointerNV_));
        public static Delegates.glVertexAttrib1dNV glVertexAttrib1dNV = (Delegates.glVertexAttrib1dNV)GetAddress("glVertexAttrib1dNV", typeof(Delegates.glVertexAttrib1dNV));
        public static Delegates.glVertexAttrib1dvNV_ glVertexAttrib1dvNV_ = (Delegates.glVertexAttrib1dvNV_)GetAddress("glVertexAttrib1dvNV", typeof(Delegates.glVertexAttrib1dvNV_));
        public static Delegates.glVertexAttrib1fNV glVertexAttrib1fNV = (Delegates.glVertexAttrib1fNV)GetAddress("glVertexAttrib1fNV", typeof(Delegates.glVertexAttrib1fNV));
        public static Delegates.glVertexAttrib1fvNV_ glVertexAttrib1fvNV_ = (Delegates.glVertexAttrib1fvNV_)GetAddress("glVertexAttrib1fvNV", typeof(Delegates.glVertexAttrib1fvNV_));
        public static Delegates.glVertexAttrib1sNV glVertexAttrib1sNV = (Delegates.glVertexAttrib1sNV)GetAddress("glVertexAttrib1sNV", typeof(Delegates.glVertexAttrib1sNV));
        public static Delegates.glVertexAttrib1svNV_ glVertexAttrib1svNV_ = (Delegates.glVertexAttrib1svNV_)GetAddress("glVertexAttrib1svNV", typeof(Delegates.glVertexAttrib1svNV_));
        public static Delegates.glVertexAttrib2dNV glVertexAttrib2dNV = (Delegates.glVertexAttrib2dNV)GetAddress("glVertexAttrib2dNV", typeof(Delegates.glVertexAttrib2dNV));
        public static Delegates.glVertexAttrib2dvNV_ glVertexAttrib2dvNV_ = (Delegates.glVertexAttrib2dvNV_)GetAddress("glVertexAttrib2dvNV", typeof(Delegates.glVertexAttrib2dvNV_));
        public static Delegates.glVertexAttrib2fNV glVertexAttrib2fNV = (Delegates.glVertexAttrib2fNV)GetAddress("glVertexAttrib2fNV", typeof(Delegates.glVertexAttrib2fNV));
        public static Delegates.glVertexAttrib2fvNV_ glVertexAttrib2fvNV_ = (Delegates.glVertexAttrib2fvNV_)GetAddress("glVertexAttrib2fvNV", typeof(Delegates.glVertexAttrib2fvNV_));
        public static Delegates.glVertexAttrib2sNV glVertexAttrib2sNV = (Delegates.glVertexAttrib2sNV)GetAddress("glVertexAttrib2sNV", typeof(Delegates.glVertexAttrib2sNV));
        public static Delegates.glVertexAttrib2svNV_ glVertexAttrib2svNV_ = (Delegates.glVertexAttrib2svNV_)GetAddress("glVertexAttrib2svNV", typeof(Delegates.glVertexAttrib2svNV_));
        public static Delegates.glVertexAttrib3dNV glVertexAttrib3dNV = (Delegates.glVertexAttrib3dNV)GetAddress("glVertexAttrib3dNV", typeof(Delegates.glVertexAttrib3dNV));
        public static Delegates.glVertexAttrib3dvNV_ glVertexAttrib3dvNV_ = (Delegates.glVertexAttrib3dvNV_)GetAddress("glVertexAttrib3dvNV", typeof(Delegates.glVertexAttrib3dvNV_));
        public static Delegates.glVertexAttrib3fNV glVertexAttrib3fNV = (Delegates.glVertexAttrib3fNV)GetAddress("glVertexAttrib3fNV", typeof(Delegates.glVertexAttrib3fNV));
        public static Delegates.glVertexAttrib3fvNV_ glVertexAttrib3fvNV_ = (Delegates.glVertexAttrib3fvNV_)GetAddress("glVertexAttrib3fvNV", typeof(Delegates.glVertexAttrib3fvNV_));
        public static Delegates.glVertexAttrib3sNV glVertexAttrib3sNV = (Delegates.glVertexAttrib3sNV)GetAddress("glVertexAttrib3sNV", typeof(Delegates.glVertexAttrib3sNV));
        public static Delegates.glVertexAttrib3svNV_ glVertexAttrib3svNV_ = (Delegates.glVertexAttrib3svNV_)GetAddress("glVertexAttrib3svNV", typeof(Delegates.glVertexAttrib3svNV_));
        public static Delegates.glVertexAttrib4dNV glVertexAttrib4dNV = (Delegates.glVertexAttrib4dNV)GetAddress("glVertexAttrib4dNV", typeof(Delegates.glVertexAttrib4dNV));
        public static Delegates.glVertexAttrib4dvNV_ glVertexAttrib4dvNV_ = (Delegates.glVertexAttrib4dvNV_)GetAddress("glVertexAttrib4dvNV", typeof(Delegates.glVertexAttrib4dvNV_));
        public static Delegates.glVertexAttrib4fNV glVertexAttrib4fNV = (Delegates.glVertexAttrib4fNV)GetAddress("glVertexAttrib4fNV", typeof(Delegates.glVertexAttrib4fNV));
        public static Delegates.glVertexAttrib4fvNV_ glVertexAttrib4fvNV_ = (Delegates.glVertexAttrib4fvNV_)GetAddress("glVertexAttrib4fvNV", typeof(Delegates.glVertexAttrib4fvNV_));
        public static Delegates.glVertexAttrib4sNV glVertexAttrib4sNV = (Delegates.glVertexAttrib4sNV)GetAddress("glVertexAttrib4sNV", typeof(Delegates.glVertexAttrib4sNV));
        public static Delegates.glVertexAttrib4svNV_ glVertexAttrib4svNV_ = (Delegates.glVertexAttrib4svNV_)GetAddress("glVertexAttrib4svNV", typeof(Delegates.glVertexAttrib4svNV_));
        public static Delegates.glVertexAttrib4ubNV glVertexAttrib4ubNV = (Delegates.glVertexAttrib4ubNV)GetAddress("glVertexAttrib4ubNV", typeof(Delegates.glVertexAttrib4ubNV));
        public static Delegates.glVertexAttrib4ubvNV_ glVertexAttrib4ubvNV_ = (Delegates.glVertexAttrib4ubvNV_)GetAddress("glVertexAttrib4ubvNV", typeof(Delegates.glVertexAttrib4ubvNV_));
        public static Delegates.glVertexAttribs1dvNV_ glVertexAttribs1dvNV_ = (Delegates.glVertexAttribs1dvNV_)GetAddress("glVertexAttribs1dvNV", typeof(Delegates.glVertexAttribs1dvNV_));
        public static Delegates.glVertexAttribs1fvNV_ glVertexAttribs1fvNV_ = (Delegates.glVertexAttribs1fvNV_)GetAddress("glVertexAttribs1fvNV", typeof(Delegates.glVertexAttribs1fvNV_));
        public static Delegates.glVertexAttribs1svNV_ glVertexAttribs1svNV_ = (Delegates.glVertexAttribs1svNV_)GetAddress("glVertexAttribs1svNV", typeof(Delegates.glVertexAttribs1svNV_));
        public static Delegates.glVertexAttribs2dvNV_ glVertexAttribs2dvNV_ = (Delegates.glVertexAttribs2dvNV_)GetAddress("glVertexAttribs2dvNV", typeof(Delegates.glVertexAttribs2dvNV_));
        public static Delegates.glVertexAttribs2fvNV_ glVertexAttribs2fvNV_ = (Delegates.glVertexAttribs2fvNV_)GetAddress("glVertexAttribs2fvNV", typeof(Delegates.glVertexAttribs2fvNV_));
        public static Delegates.glVertexAttribs2svNV_ glVertexAttribs2svNV_ = (Delegates.glVertexAttribs2svNV_)GetAddress("glVertexAttribs2svNV", typeof(Delegates.glVertexAttribs2svNV_));
        public static Delegates.glVertexAttribs3dvNV_ glVertexAttribs3dvNV_ = (Delegates.glVertexAttribs3dvNV_)GetAddress("glVertexAttribs3dvNV", typeof(Delegates.glVertexAttribs3dvNV_));
        public static Delegates.glVertexAttribs3fvNV_ glVertexAttribs3fvNV_ = (Delegates.glVertexAttribs3fvNV_)GetAddress("glVertexAttribs3fvNV", typeof(Delegates.glVertexAttribs3fvNV_));
        public static Delegates.glVertexAttribs3svNV_ glVertexAttribs3svNV_ = (Delegates.glVertexAttribs3svNV_)GetAddress("glVertexAttribs3svNV", typeof(Delegates.glVertexAttribs3svNV_));
        public static Delegates.glVertexAttribs4dvNV_ glVertexAttribs4dvNV_ = (Delegates.glVertexAttribs4dvNV_)GetAddress("glVertexAttribs4dvNV", typeof(Delegates.glVertexAttribs4dvNV_));
        public static Delegates.glVertexAttribs4fvNV_ glVertexAttribs4fvNV_ = (Delegates.glVertexAttribs4fvNV_)GetAddress("glVertexAttribs4fvNV", typeof(Delegates.glVertexAttribs4fvNV_));
        public static Delegates.glVertexAttribs4svNV_ glVertexAttribs4svNV_ = (Delegates.glVertexAttribs4svNV_)GetAddress("glVertexAttribs4svNV", typeof(Delegates.glVertexAttribs4svNV_));
        public static Delegates.glVertexAttribs4ubvNV_ glVertexAttribs4ubvNV_ = (Delegates.glVertexAttribs4ubvNV_)GetAddress("glVertexAttribs4ubvNV", typeof(Delegates.glVertexAttribs4ubvNV_));
        public static Delegates.glTexBumpParameterivATI_ glTexBumpParameterivATI_ = (Delegates.glTexBumpParameterivATI_)GetAddress("glTexBumpParameterivATI", typeof(Delegates.glTexBumpParameterivATI_));
        public static Delegates.glTexBumpParameterfvATI_ glTexBumpParameterfvATI_ = (Delegates.glTexBumpParameterfvATI_)GetAddress("glTexBumpParameterfvATI", typeof(Delegates.glTexBumpParameterfvATI_));
        public static Delegates.glGetTexBumpParameterivATI glGetTexBumpParameterivATI = (Delegates.glGetTexBumpParameterivATI)GetAddress("glGetTexBumpParameterivATI", typeof(Delegates.glGetTexBumpParameterivATI));
        public static Delegates.glGetTexBumpParameterfvATI glGetTexBumpParameterfvATI = (Delegates.glGetTexBumpParameterfvATI)GetAddress("glGetTexBumpParameterfvATI", typeof(Delegates.glGetTexBumpParameterfvATI));
        public static Delegates.glGenFragmentShadersATI glGenFragmentShadersATI = (Delegates.glGenFragmentShadersATI)GetAddress("glGenFragmentShadersATI", typeof(Delegates.glGenFragmentShadersATI));
        public static Delegates.glBindFragmentShaderATI glBindFragmentShaderATI = (Delegates.glBindFragmentShaderATI)GetAddress("glBindFragmentShaderATI", typeof(Delegates.glBindFragmentShaderATI));
        public static Delegates.glDeleteFragmentShaderATI glDeleteFragmentShaderATI = (Delegates.glDeleteFragmentShaderATI)GetAddress("glDeleteFragmentShaderATI", typeof(Delegates.glDeleteFragmentShaderATI));
        public static Delegates.glBeginFragmentShaderATI glBeginFragmentShaderATI = (Delegates.glBeginFragmentShaderATI)GetAddress("glBeginFragmentShaderATI", typeof(Delegates.glBeginFragmentShaderATI));
        public static Delegates.glEndFragmentShaderATI glEndFragmentShaderATI = (Delegates.glEndFragmentShaderATI)GetAddress("glEndFragmentShaderATI", typeof(Delegates.glEndFragmentShaderATI));
        public static Delegates.glPassTexCoordATI glPassTexCoordATI = (Delegates.glPassTexCoordATI)GetAddress("glPassTexCoordATI", typeof(Delegates.glPassTexCoordATI));
        public static Delegates.glSampleMapATI glSampleMapATI = (Delegates.glSampleMapATI)GetAddress("glSampleMapATI", typeof(Delegates.glSampleMapATI));
        public static Delegates.glColorFragmentOp1ATI glColorFragmentOp1ATI = (Delegates.glColorFragmentOp1ATI)GetAddress("glColorFragmentOp1ATI", typeof(Delegates.glColorFragmentOp1ATI));
        public static Delegates.glColorFragmentOp2ATI glColorFragmentOp2ATI = (Delegates.glColorFragmentOp2ATI)GetAddress("glColorFragmentOp2ATI", typeof(Delegates.glColorFragmentOp2ATI));
        public static Delegates.glColorFragmentOp3ATI glColorFragmentOp3ATI = (Delegates.glColorFragmentOp3ATI)GetAddress("glColorFragmentOp3ATI", typeof(Delegates.glColorFragmentOp3ATI));
        public static Delegates.glAlphaFragmentOp1ATI glAlphaFragmentOp1ATI = (Delegates.glAlphaFragmentOp1ATI)GetAddress("glAlphaFragmentOp1ATI", typeof(Delegates.glAlphaFragmentOp1ATI));
        public static Delegates.glAlphaFragmentOp2ATI glAlphaFragmentOp2ATI = (Delegates.glAlphaFragmentOp2ATI)GetAddress("glAlphaFragmentOp2ATI", typeof(Delegates.glAlphaFragmentOp2ATI));
        public static Delegates.glAlphaFragmentOp3ATI glAlphaFragmentOp3ATI = (Delegates.glAlphaFragmentOp3ATI)GetAddress("glAlphaFragmentOp3ATI", typeof(Delegates.glAlphaFragmentOp3ATI));
        public static Delegates.glSetFragmentShaderConstantATI_ glSetFragmentShaderConstantATI_ = (Delegates.glSetFragmentShaderConstantATI_)GetAddress("glSetFragmentShaderConstantATI", typeof(Delegates.glSetFragmentShaderConstantATI_));
        public static Delegates.glPNTrianglesiATI glPNTrianglesiATI = (Delegates.glPNTrianglesiATI)GetAddress("glPNTrianglesiATI", typeof(Delegates.glPNTrianglesiATI));
        public static Delegates.glPNTrianglesfATI glPNTrianglesfATI = (Delegates.glPNTrianglesfATI)GetAddress("glPNTrianglesfATI", typeof(Delegates.glPNTrianglesfATI));
        public static Delegates.glNewObjectBufferATI_ glNewObjectBufferATI_ = (Delegates.glNewObjectBufferATI_)GetAddress("glNewObjectBufferATI", typeof(Delegates.glNewObjectBufferATI_));
        public static Delegates.glIsObjectBufferATI glIsObjectBufferATI = (Delegates.glIsObjectBufferATI)GetAddress("glIsObjectBufferATI", typeof(Delegates.glIsObjectBufferATI));
        public static Delegates.glUpdateObjectBufferATI_ glUpdateObjectBufferATI_ = (Delegates.glUpdateObjectBufferATI_)GetAddress("glUpdateObjectBufferATI", typeof(Delegates.glUpdateObjectBufferATI_));
        public static Delegates.glGetObjectBufferfvATI glGetObjectBufferfvATI = (Delegates.glGetObjectBufferfvATI)GetAddress("glGetObjectBufferfvATI", typeof(Delegates.glGetObjectBufferfvATI));
        public static Delegates.glGetObjectBufferivATI glGetObjectBufferivATI = (Delegates.glGetObjectBufferivATI)GetAddress("glGetObjectBufferivATI", typeof(Delegates.glGetObjectBufferivATI));
        public static Delegates.glFreeObjectBufferATI glFreeObjectBufferATI = (Delegates.glFreeObjectBufferATI)GetAddress("glFreeObjectBufferATI", typeof(Delegates.glFreeObjectBufferATI));
        public static Delegates.glArrayObjectATI glArrayObjectATI = (Delegates.glArrayObjectATI)GetAddress("glArrayObjectATI", typeof(Delegates.glArrayObjectATI));
        public static Delegates.glGetArrayObjectfvATI glGetArrayObjectfvATI = (Delegates.glGetArrayObjectfvATI)GetAddress("glGetArrayObjectfvATI", typeof(Delegates.glGetArrayObjectfvATI));
        public static Delegates.glGetArrayObjectivATI glGetArrayObjectivATI = (Delegates.glGetArrayObjectivATI)GetAddress("glGetArrayObjectivATI", typeof(Delegates.glGetArrayObjectivATI));
        public static Delegates.glVariantArrayObjectATI glVariantArrayObjectATI = (Delegates.glVariantArrayObjectATI)GetAddress("glVariantArrayObjectATI", typeof(Delegates.glVariantArrayObjectATI));
        public static Delegates.glGetVariantArrayObjectfvATI glGetVariantArrayObjectfvATI = (Delegates.glGetVariantArrayObjectfvATI)GetAddress("glGetVariantArrayObjectfvATI", typeof(Delegates.glGetVariantArrayObjectfvATI));
        public static Delegates.glGetVariantArrayObjectivATI glGetVariantArrayObjectivATI = (Delegates.glGetVariantArrayObjectivATI)GetAddress("glGetVariantArrayObjectivATI", typeof(Delegates.glGetVariantArrayObjectivATI));
        public static Delegates.glBeginVertexShaderEXT glBeginVertexShaderEXT = (Delegates.glBeginVertexShaderEXT)GetAddress("glBeginVertexShaderEXT", typeof(Delegates.glBeginVertexShaderEXT));
        public static Delegates.glEndVertexShaderEXT glEndVertexShaderEXT = (Delegates.glEndVertexShaderEXT)GetAddress("glEndVertexShaderEXT", typeof(Delegates.glEndVertexShaderEXT));
        public static Delegates.glBindVertexShaderEXT glBindVertexShaderEXT = (Delegates.glBindVertexShaderEXT)GetAddress("glBindVertexShaderEXT", typeof(Delegates.glBindVertexShaderEXT));
        public static Delegates.glGenVertexShadersEXT glGenVertexShadersEXT = (Delegates.glGenVertexShadersEXT)GetAddress("glGenVertexShadersEXT", typeof(Delegates.glGenVertexShadersEXT));
        public static Delegates.glDeleteVertexShaderEXT glDeleteVertexShaderEXT = (Delegates.glDeleteVertexShaderEXT)GetAddress("glDeleteVertexShaderEXT", typeof(Delegates.glDeleteVertexShaderEXT));
        public static Delegates.glShaderOp1EXT glShaderOp1EXT = (Delegates.glShaderOp1EXT)GetAddress("glShaderOp1EXT", typeof(Delegates.glShaderOp1EXT));
        public static Delegates.glShaderOp2EXT glShaderOp2EXT = (Delegates.glShaderOp2EXT)GetAddress("glShaderOp2EXT", typeof(Delegates.glShaderOp2EXT));
        public static Delegates.glShaderOp3EXT glShaderOp3EXT = (Delegates.glShaderOp3EXT)GetAddress("glShaderOp3EXT", typeof(Delegates.glShaderOp3EXT));
        public static Delegates.glSwizzleEXT glSwizzleEXT = (Delegates.glSwizzleEXT)GetAddress("glSwizzleEXT", typeof(Delegates.glSwizzleEXT));
        public static Delegates.glWriteMaskEXT glWriteMaskEXT = (Delegates.glWriteMaskEXT)GetAddress("glWriteMaskEXT", typeof(Delegates.glWriteMaskEXT));
        public static Delegates.glInsertComponentEXT glInsertComponentEXT = (Delegates.glInsertComponentEXT)GetAddress("glInsertComponentEXT", typeof(Delegates.glInsertComponentEXT));
        public static Delegates.glExtractComponentEXT glExtractComponentEXT = (Delegates.glExtractComponentEXT)GetAddress("glExtractComponentEXT", typeof(Delegates.glExtractComponentEXT));
        public static Delegates.glGenSymbolsEXT glGenSymbolsEXT = (Delegates.glGenSymbolsEXT)GetAddress("glGenSymbolsEXT", typeof(Delegates.glGenSymbolsEXT));
        public static Delegates.glSetInvariantEXT_ glSetInvariantEXT_ = (Delegates.glSetInvariantEXT_)GetAddress("glSetInvariantEXT", typeof(Delegates.glSetInvariantEXT_));
        public static Delegates.glSetLocalConstantEXT_ glSetLocalConstantEXT_ = (Delegates.glSetLocalConstantEXT_)GetAddress("glSetLocalConstantEXT", typeof(Delegates.glSetLocalConstantEXT_));
        public static Delegates.glVariantbvEXT_ glVariantbvEXT_ = (Delegates.glVariantbvEXT_)GetAddress("glVariantbvEXT", typeof(Delegates.glVariantbvEXT_));
        public static Delegates.glVariantsvEXT_ glVariantsvEXT_ = (Delegates.glVariantsvEXT_)GetAddress("glVariantsvEXT", typeof(Delegates.glVariantsvEXT_));
        public static Delegates.glVariantivEXT_ glVariantivEXT_ = (Delegates.glVariantivEXT_)GetAddress("glVariantivEXT", typeof(Delegates.glVariantivEXT_));
        public static Delegates.glVariantfvEXT_ glVariantfvEXT_ = (Delegates.glVariantfvEXT_)GetAddress("glVariantfvEXT", typeof(Delegates.glVariantfvEXT_));
        public static Delegates.glVariantdvEXT_ glVariantdvEXT_ = (Delegates.glVariantdvEXT_)GetAddress("glVariantdvEXT", typeof(Delegates.glVariantdvEXT_));
        public static Delegates.glVariantubvEXT_ glVariantubvEXT_ = (Delegates.glVariantubvEXT_)GetAddress("glVariantubvEXT", typeof(Delegates.glVariantubvEXT_));
        public static Delegates.glVariantusvEXT_ glVariantusvEXT_ = (Delegates.glVariantusvEXT_)GetAddress("glVariantusvEXT", typeof(Delegates.glVariantusvEXT_));
        public static Delegates.glVariantuivEXT_ glVariantuivEXT_ = (Delegates.glVariantuivEXT_)GetAddress("glVariantuivEXT", typeof(Delegates.glVariantuivEXT_));
        public static Delegates.glVariantPointerEXT_ glVariantPointerEXT_ = (Delegates.glVariantPointerEXT_)GetAddress("glVariantPointerEXT", typeof(Delegates.glVariantPointerEXT_));
        public static Delegates.glEnableVariantClientStateEXT glEnableVariantClientStateEXT = (Delegates.glEnableVariantClientStateEXT)GetAddress("glEnableVariantClientStateEXT", typeof(Delegates.glEnableVariantClientStateEXT));
        public static Delegates.glDisableVariantClientStateEXT glDisableVariantClientStateEXT = (Delegates.glDisableVariantClientStateEXT)GetAddress("glDisableVariantClientStateEXT", typeof(Delegates.glDisableVariantClientStateEXT));
        public static Delegates.glBindLightParameterEXT glBindLightParameterEXT = (Delegates.glBindLightParameterEXT)GetAddress("glBindLightParameterEXT", typeof(Delegates.glBindLightParameterEXT));
        public static Delegates.glBindMaterialParameterEXT glBindMaterialParameterEXT = (Delegates.glBindMaterialParameterEXT)GetAddress("glBindMaterialParameterEXT", typeof(Delegates.glBindMaterialParameterEXT));
        public static Delegates.glBindTexGenParameterEXT glBindTexGenParameterEXT = (Delegates.glBindTexGenParameterEXT)GetAddress("glBindTexGenParameterEXT", typeof(Delegates.glBindTexGenParameterEXT));
        public static Delegates.glBindTextureUnitParameterEXT glBindTextureUnitParameterEXT = (Delegates.glBindTextureUnitParameterEXT)GetAddress("glBindTextureUnitParameterEXT", typeof(Delegates.glBindTextureUnitParameterEXT));
        public static Delegates.glBindParameterEXT glBindParameterEXT = (Delegates.glBindParameterEXT)GetAddress("glBindParameterEXT", typeof(Delegates.glBindParameterEXT));
        public static Delegates.glIsVariantEnabledEXT glIsVariantEnabledEXT = (Delegates.glIsVariantEnabledEXT)GetAddress("glIsVariantEnabledEXT", typeof(Delegates.glIsVariantEnabledEXT));
        public static Delegates.glGetVariantBooleanvEXT glGetVariantBooleanvEXT = (Delegates.glGetVariantBooleanvEXT)GetAddress("glGetVariantBooleanvEXT", typeof(Delegates.glGetVariantBooleanvEXT));
        public static Delegates.glGetVariantIntegervEXT glGetVariantIntegervEXT = (Delegates.glGetVariantIntegervEXT)GetAddress("glGetVariantIntegervEXT", typeof(Delegates.glGetVariantIntegervEXT));
        public static Delegates.glGetVariantFloatvEXT glGetVariantFloatvEXT = (Delegates.glGetVariantFloatvEXT)GetAddress("glGetVariantFloatvEXT", typeof(Delegates.glGetVariantFloatvEXT));
        public static Delegates.glGetVariantPointervEXT glGetVariantPointervEXT = (Delegates.glGetVariantPointervEXT)GetAddress("glGetVariantPointervEXT", typeof(Delegates.glGetVariantPointervEXT));
        public static Delegates.glGetInvariantBooleanvEXT glGetInvariantBooleanvEXT = (Delegates.glGetInvariantBooleanvEXT)GetAddress("glGetInvariantBooleanvEXT", typeof(Delegates.glGetInvariantBooleanvEXT));
        public static Delegates.glGetInvariantIntegervEXT glGetInvariantIntegervEXT = (Delegates.glGetInvariantIntegervEXT)GetAddress("glGetInvariantIntegervEXT", typeof(Delegates.glGetInvariantIntegervEXT));
        public static Delegates.glGetInvariantFloatvEXT glGetInvariantFloatvEXT = (Delegates.glGetInvariantFloatvEXT)GetAddress("glGetInvariantFloatvEXT", typeof(Delegates.glGetInvariantFloatvEXT));
        public static Delegates.glGetLocalConstantBooleanvEXT glGetLocalConstantBooleanvEXT = (Delegates.glGetLocalConstantBooleanvEXT)GetAddress("glGetLocalConstantBooleanvEXT", typeof(Delegates.glGetLocalConstantBooleanvEXT));
        public static Delegates.glGetLocalConstantIntegervEXT glGetLocalConstantIntegervEXT = (Delegates.glGetLocalConstantIntegervEXT)GetAddress("glGetLocalConstantIntegervEXT", typeof(Delegates.glGetLocalConstantIntegervEXT));
        public static Delegates.glGetLocalConstantFloatvEXT glGetLocalConstantFloatvEXT = (Delegates.glGetLocalConstantFloatvEXT)GetAddress("glGetLocalConstantFloatvEXT", typeof(Delegates.glGetLocalConstantFloatvEXT));
        public static Delegates.glVertexStream1sATI glVertexStream1sATI = (Delegates.glVertexStream1sATI)GetAddress("glVertexStream1sATI", typeof(Delegates.glVertexStream1sATI));
        public static Delegates.glVertexStream1svATI_ glVertexStream1svATI_ = (Delegates.glVertexStream1svATI_)GetAddress("glVertexStream1svATI", typeof(Delegates.glVertexStream1svATI_));
        public static Delegates.glVertexStream1iATI glVertexStream1iATI = (Delegates.glVertexStream1iATI)GetAddress("glVertexStream1iATI", typeof(Delegates.glVertexStream1iATI));
        public static Delegates.glVertexStream1ivATI_ glVertexStream1ivATI_ = (Delegates.glVertexStream1ivATI_)GetAddress("glVertexStream1ivATI", typeof(Delegates.glVertexStream1ivATI_));
        public static Delegates.glVertexStream1fATI glVertexStream1fATI = (Delegates.glVertexStream1fATI)GetAddress("glVertexStream1fATI", typeof(Delegates.glVertexStream1fATI));
        public static Delegates.glVertexStream1fvATI_ glVertexStream1fvATI_ = (Delegates.glVertexStream1fvATI_)GetAddress("glVertexStream1fvATI", typeof(Delegates.glVertexStream1fvATI_));
        public static Delegates.glVertexStream1dATI glVertexStream1dATI = (Delegates.glVertexStream1dATI)GetAddress("glVertexStream1dATI", typeof(Delegates.glVertexStream1dATI));
        public static Delegates.glVertexStream1dvATI_ glVertexStream1dvATI_ = (Delegates.glVertexStream1dvATI_)GetAddress("glVertexStream1dvATI", typeof(Delegates.glVertexStream1dvATI_));
        public static Delegates.glVertexStream2sATI glVertexStream2sATI = (Delegates.glVertexStream2sATI)GetAddress("glVertexStream2sATI", typeof(Delegates.glVertexStream2sATI));
        public static Delegates.glVertexStream2svATI_ glVertexStream2svATI_ = (Delegates.glVertexStream2svATI_)GetAddress("glVertexStream2svATI", typeof(Delegates.glVertexStream2svATI_));
        public static Delegates.glVertexStream2iATI glVertexStream2iATI = (Delegates.glVertexStream2iATI)GetAddress("glVertexStream2iATI", typeof(Delegates.glVertexStream2iATI));
        public static Delegates.glVertexStream2ivATI_ glVertexStream2ivATI_ = (Delegates.glVertexStream2ivATI_)GetAddress("glVertexStream2ivATI", typeof(Delegates.glVertexStream2ivATI_));
        public static Delegates.glVertexStream2fATI glVertexStream2fATI = (Delegates.glVertexStream2fATI)GetAddress("glVertexStream2fATI", typeof(Delegates.glVertexStream2fATI));
        public static Delegates.glVertexStream2fvATI_ glVertexStream2fvATI_ = (Delegates.glVertexStream2fvATI_)GetAddress("glVertexStream2fvATI", typeof(Delegates.glVertexStream2fvATI_));
        public static Delegates.glVertexStream2dATI glVertexStream2dATI = (Delegates.glVertexStream2dATI)GetAddress("glVertexStream2dATI", typeof(Delegates.glVertexStream2dATI));
        public static Delegates.glVertexStream2dvATI_ glVertexStream2dvATI_ = (Delegates.glVertexStream2dvATI_)GetAddress("glVertexStream2dvATI", typeof(Delegates.glVertexStream2dvATI_));
        public static Delegates.glVertexStream3sATI glVertexStream3sATI = (Delegates.glVertexStream3sATI)GetAddress("glVertexStream3sATI", typeof(Delegates.glVertexStream3sATI));
        public static Delegates.glVertexStream3svATI_ glVertexStream3svATI_ = (Delegates.glVertexStream3svATI_)GetAddress("glVertexStream3svATI", typeof(Delegates.glVertexStream3svATI_));
        public static Delegates.glVertexStream3iATI glVertexStream3iATI = (Delegates.glVertexStream3iATI)GetAddress("glVertexStream3iATI", typeof(Delegates.glVertexStream3iATI));
        public static Delegates.glVertexStream3ivATI_ glVertexStream3ivATI_ = (Delegates.glVertexStream3ivATI_)GetAddress("glVertexStream3ivATI", typeof(Delegates.glVertexStream3ivATI_));
        public static Delegates.glVertexStream3fATI glVertexStream3fATI = (Delegates.glVertexStream3fATI)GetAddress("glVertexStream3fATI", typeof(Delegates.glVertexStream3fATI));
        public static Delegates.glVertexStream3fvATI_ glVertexStream3fvATI_ = (Delegates.glVertexStream3fvATI_)GetAddress("glVertexStream3fvATI", typeof(Delegates.glVertexStream3fvATI_));
        public static Delegates.glVertexStream3dATI glVertexStream3dATI = (Delegates.glVertexStream3dATI)GetAddress("glVertexStream3dATI", typeof(Delegates.glVertexStream3dATI));
        public static Delegates.glVertexStream3dvATI_ glVertexStream3dvATI_ = (Delegates.glVertexStream3dvATI_)GetAddress("glVertexStream3dvATI", typeof(Delegates.glVertexStream3dvATI_));
        public static Delegates.glVertexStream4sATI glVertexStream4sATI = (Delegates.glVertexStream4sATI)GetAddress("glVertexStream4sATI", typeof(Delegates.glVertexStream4sATI));
        public static Delegates.glVertexStream4svATI_ glVertexStream4svATI_ = (Delegates.glVertexStream4svATI_)GetAddress("glVertexStream4svATI", typeof(Delegates.glVertexStream4svATI_));
        public static Delegates.glVertexStream4iATI glVertexStream4iATI = (Delegates.glVertexStream4iATI)GetAddress("glVertexStream4iATI", typeof(Delegates.glVertexStream4iATI));
        public static Delegates.glVertexStream4ivATI_ glVertexStream4ivATI_ = (Delegates.glVertexStream4ivATI_)GetAddress("glVertexStream4ivATI", typeof(Delegates.glVertexStream4ivATI_));
        public static Delegates.glVertexStream4fATI glVertexStream4fATI = (Delegates.glVertexStream4fATI)GetAddress("glVertexStream4fATI", typeof(Delegates.glVertexStream4fATI));
        public static Delegates.glVertexStream4fvATI_ glVertexStream4fvATI_ = (Delegates.glVertexStream4fvATI_)GetAddress("glVertexStream4fvATI", typeof(Delegates.glVertexStream4fvATI_));
        public static Delegates.glVertexStream4dATI glVertexStream4dATI = (Delegates.glVertexStream4dATI)GetAddress("glVertexStream4dATI", typeof(Delegates.glVertexStream4dATI));
        public static Delegates.glVertexStream4dvATI_ glVertexStream4dvATI_ = (Delegates.glVertexStream4dvATI_)GetAddress("glVertexStream4dvATI", typeof(Delegates.glVertexStream4dvATI_));
        public static Delegates.glNormalStream3bATI glNormalStream3bATI = (Delegates.glNormalStream3bATI)GetAddress("glNormalStream3bATI", typeof(Delegates.glNormalStream3bATI));
        public static Delegates.glNormalStream3bvATI_ glNormalStream3bvATI_ = (Delegates.glNormalStream3bvATI_)GetAddress("glNormalStream3bvATI", typeof(Delegates.glNormalStream3bvATI_));
        public static Delegates.glNormalStream3sATI glNormalStream3sATI = (Delegates.glNormalStream3sATI)GetAddress("glNormalStream3sATI", typeof(Delegates.glNormalStream3sATI));
        public static Delegates.glNormalStream3svATI_ glNormalStream3svATI_ = (Delegates.glNormalStream3svATI_)GetAddress("glNormalStream3svATI", typeof(Delegates.glNormalStream3svATI_));
        public static Delegates.glNormalStream3iATI glNormalStream3iATI = (Delegates.glNormalStream3iATI)GetAddress("glNormalStream3iATI", typeof(Delegates.glNormalStream3iATI));
        public static Delegates.glNormalStream3ivATI_ glNormalStream3ivATI_ = (Delegates.glNormalStream3ivATI_)GetAddress("glNormalStream3ivATI", typeof(Delegates.glNormalStream3ivATI_));
        public static Delegates.glNormalStream3fATI glNormalStream3fATI = (Delegates.glNormalStream3fATI)GetAddress("glNormalStream3fATI", typeof(Delegates.glNormalStream3fATI));
        public static Delegates.glNormalStream3fvATI_ glNormalStream3fvATI_ = (Delegates.glNormalStream3fvATI_)GetAddress("glNormalStream3fvATI", typeof(Delegates.glNormalStream3fvATI_));
        public static Delegates.glNormalStream3dATI glNormalStream3dATI = (Delegates.glNormalStream3dATI)GetAddress("glNormalStream3dATI", typeof(Delegates.glNormalStream3dATI));
        public static Delegates.glNormalStream3dvATI_ glNormalStream3dvATI_ = (Delegates.glNormalStream3dvATI_)GetAddress("glNormalStream3dvATI", typeof(Delegates.glNormalStream3dvATI_));
        public static Delegates.glClientActiveVertexStreamATI glClientActiveVertexStreamATI = (Delegates.glClientActiveVertexStreamATI)GetAddress("glClientActiveVertexStreamATI", typeof(Delegates.glClientActiveVertexStreamATI));
        public static Delegates.glVertexBlendEnviATI glVertexBlendEnviATI = (Delegates.glVertexBlendEnviATI)GetAddress("glVertexBlendEnviATI", typeof(Delegates.glVertexBlendEnviATI));
        public static Delegates.glVertexBlendEnvfATI glVertexBlendEnvfATI = (Delegates.glVertexBlendEnvfATI)GetAddress("glVertexBlendEnvfATI", typeof(Delegates.glVertexBlendEnvfATI));
        public static Delegates.glElementPointerATI_ glElementPointerATI_ = (Delegates.glElementPointerATI_)GetAddress("glElementPointerATI", typeof(Delegates.glElementPointerATI_));
        public static Delegates.glDrawElementArrayATI glDrawElementArrayATI = (Delegates.glDrawElementArrayATI)GetAddress("glDrawElementArrayATI", typeof(Delegates.glDrawElementArrayATI));
        public static Delegates.glDrawRangeElementArrayATI glDrawRangeElementArrayATI = (Delegates.glDrawRangeElementArrayATI)GetAddress("glDrawRangeElementArrayATI", typeof(Delegates.glDrawRangeElementArrayATI));
        public static Delegates.glDrawMeshArraysSUN glDrawMeshArraysSUN = (Delegates.glDrawMeshArraysSUN)GetAddress("glDrawMeshArraysSUN", typeof(Delegates.glDrawMeshArraysSUN));
        public static Delegates.glGenOcclusionQueriesNV glGenOcclusionQueriesNV = (Delegates.glGenOcclusionQueriesNV)GetAddress("glGenOcclusionQueriesNV", typeof(Delegates.glGenOcclusionQueriesNV));
        public static Delegates.glDeleteOcclusionQueriesNV_ glDeleteOcclusionQueriesNV_ = (Delegates.glDeleteOcclusionQueriesNV_)GetAddress("glDeleteOcclusionQueriesNV", typeof(Delegates.glDeleteOcclusionQueriesNV_));
        public static Delegates.glIsOcclusionQueryNV glIsOcclusionQueryNV = (Delegates.glIsOcclusionQueryNV)GetAddress("glIsOcclusionQueryNV", typeof(Delegates.glIsOcclusionQueryNV));
        public static Delegates.glBeginOcclusionQueryNV glBeginOcclusionQueryNV = (Delegates.glBeginOcclusionQueryNV)GetAddress("glBeginOcclusionQueryNV", typeof(Delegates.glBeginOcclusionQueryNV));
        public static Delegates.glEndOcclusionQueryNV glEndOcclusionQueryNV = (Delegates.glEndOcclusionQueryNV)GetAddress("glEndOcclusionQueryNV", typeof(Delegates.glEndOcclusionQueryNV));
        public static Delegates.glGetOcclusionQueryivNV glGetOcclusionQueryivNV = (Delegates.glGetOcclusionQueryivNV)GetAddress("glGetOcclusionQueryivNV", typeof(Delegates.glGetOcclusionQueryivNV));
        public static Delegates.glGetOcclusionQueryuivNV glGetOcclusionQueryuivNV = (Delegates.glGetOcclusionQueryuivNV)GetAddress("glGetOcclusionQueryuivNV", typeof(Delegates.glGetOcclusionQueryuivNV));
        public static Delegates.glPointParameteriNV glPointParameteriNV = (Delegates.glPointParameteriNV)GetAddress("glPointParameteriNV", typeof(Delegates.glPointParameteriNV));
        public static Delegates.glPointParameterivNV_ glPointParameterivNV_ = (Delegates.glPointParameterivNV_)GetAddress("glPointParameterivNV", typeof(Delegates.glPointParameterivNV_));
        public static Delegates.glActiveStencilFaceEXT glActiveStencilFaceEXT = (Delegates.glActiveStencilFaceEXT)GetAddress("glActiveStencilFaceEXT", typeof(Delegates.glActiveStencilFaceEXT));
        public static Delegates.glElementPointerAPPLE_ glElementPointerAPPLE_ = (Delegates.glElementPointerAPPLE_)GetAddress("glElementPointerAPPLE", typeof(Delegates.glElementPointerAPPLE_));
        public static Delegates.glDrawElementArrayAPPLE glDrawElementArrayAPPLE = (Delegates.glDrawElementArrayAPPLE)GetAddress("glDrawElementArrayAPPLE", typeof(Delegates.glDrawElementArrayAPPLE));
        public static Delegates.glDrawRangeElementArrayAPPLE glDrawRangeElementArrayAPPLE = (Delegates.glDrawRangeElementArrayAPPLE)GetAddress("glDrawRangeElementArrayAPPLE", typeof(Delegates.glDrawRangeElementArrayAPPLE));
        public static Delegates.glMultiDrawElementArrayAPPLE_ glMultiDrawElementArrayAPPLE_ = (Delegates.glMultiDrawElementArrayAPPLE_)GetAddress("glMultiDrawElementArrayAPPLE", typeof(Delegates.glMultiDrawElementArrayAPPLE_));
        public static Delegates.glMultiDrawRangeElementArrayAPPLE_ glMultiDrawRangeElementArrayAPPLE_ = (Delegates.glMultiDrawRangeElementArrayAPPLE_)GetAddress("glMultiDrawRangeElementArrayAPPLE", typeof(Delegates.glMultiDrawRangeElementArrayAPPLE_));
        public static Delegates.glGenFencesAPPLE glGenFencesAPPLE = (Delegates.glGenFencesAPPLE)GetAddress("glGenFencesAPPLE", typeof(Delegates.glGenFencesAPPLE));
        public static Delegates.glDeleteFencesAPPLE_ glDeleteFencesAPPLE_ = (Delegates.glDeleteFencesAPPLE_)GetAddress("glDeleteFencesAPPLE", typeof(Delegates.glDeleteFencesAPPLE_));
        public static Delegates.glSetFenceAPPLE glSetFenceAPPLE = (Delegates.glSetFenceAPPLE)GetAddress("glSetFenceAPPLE", typeof(Delegates.glSetFenceAPPLE));
        public static Delegates.glIsFenceAPPLE glIsFenceAPPLE = (Delegates.glIsFenceAPPLE)GetAddress("glIsFenceAPPLE", typeof(Delegates.glIsFenceAPPLE));
        public static Delegates.glTestFenceAPPLE glTestFenceAPPLE = (Delegates.glTestFenceAPPLE)GetAddress("glTestFenceAPPLE", typeof(Delegates.glTestFenceAPPLE));
        public static Delegates.glFinishFenceAPPLE glFinishFenceAPPLE = (Delegates.glFinishFenceAPPLE)GetAddress("glFinishFenceAPPLE", typeof(Delegates.glFinishFenceAPPLE));
        public static Delegates.glTestObjectAPPLE glTestObjectAPPLE = (Delegates.glTestObjectAPPLE)GetAddress("glTestObjectAPPLE", typeof(Delegates.glTestObjectAPPLE));
        public static Delegates.glFinishObjectAPPLE glFinishObjectAPPLE = (Delegates.glFinishObjectAPPLE)GetAddress("glFinishObjectAPPLE", typeof(Delegates.glFinishObjectAPPLE));
        public static Delegates.glBindVertexArrayAPPLE glBindVertexArrayAPPLE = (Delegates.glBindVertexArrayAPPLE)GetAddress("glBindVertexArrayAPPLE", typeof(Delegates.glBindVertexArrayAPPLE));
        public static Delegates.glDeleteVertexArraysAPPLE_ glDeleteVertexArraysAPPLE_ = (Delegates.glDeleteVertexArraysAPPLE_)GetAddress("glDeleteVertexArraysAPPLE", typeof(Delegates.glDeleteVertexArraysAPPLE_));
        public static Delegates.glGenVertexArraysAPPLE_ glGenVertexArraysAPPLE_ = (Delegates.glGenVertexArraysAPPLE_)GetAddress("glGenVertexArraysAPPLE", typeof(Delegates.glGenVertexArraysAPPLE_));
        public static Delegates.glIsVertexArrayAPPLE glIsVertexArrayAPPLE = (Delegates.glIsVertexArrayAPPLE)GetAddress("glIsVertexArrayAPPLE", typeof(Delegates.glIsVertexArrayAPPLE));
        public static Delegates.glVertexArrayRangeAPPLE_ glVertexArrayRangeAPPLE_ = (Delegates.glVertexArrayRangeAPPLE_)GetAddress("glVertexArrayRangeAPPLE", typeof(Delegates.glVertexArrayRangeAPPLE_));
        public static Delegates.glFlushVertexArrayRangeAPPLE_ glFlushVertexArrayRangeAPPLE_ = (Delegates.glFlushVertexArrayRangeAPPLE_)GetAddress("glFlushVertexArrayRangeAPPLE", typeof(Delegates.glFlushVertexArrayRangeAPPLE_));
        public static Delegates.glVertexArrayParameteriAPPLE glVertexArrayParameteriAPPLE = (Delegates.glVertexArrayParameteriAPPLE)GetAddress("glVertexArrayParameteriAPPLE", typeof(Delegates.glVertexArrayParameteriAPPLE));
        public static Delegates.glDrawBuffersATI_ glDrawBuffersATI_ = (Delegates.glDrawBuffersATI_)GetAddress("glDrawBuffersATI", typeof(Delegates.glDrawBuffersATI_));
        public static Delegates.glProgramNamedParameter4fNV_ glProgramNamedParameter4fNV_ = (Delegates.glProgramNamedParameter4fNV_)GetAddress("glProgramNamedParameter4fNV", typeof(Delegates.glProgramNamedParameter4fNV_));
        public static Delegates.glProgramNamedParameter4dNV_ glProgramNamedParameter4dNV_ = (Delegates.glProgramNamedParameter4dNV_)GetAddress("glProgramNamedParameter4dNV", typeof(Delegates.glProgramNamedParameter4dNV_));
        public static Delegates.glProgramNamedParameter4fvNV_ glProgramNamedParameter4fvNV_ = (Delegates.glProgramNamedParameter4fvNV_)GetAddress("glProgramNamedParameter4fvNV", typeof(Delegates.glProgramNamedParameter4fvNV_));
        public static Delegates.glProgramNamedParameter4dvNV_ glProgramNamedParameter4dvNV_ = (Delegates.glProgramNamedParameter4dvNV_)GetAddress("glProgramNamedParameter4dvNV", typeof(Delegates.glProgramNamedParameter4dvNV_));
        public static Delegates.glGetProgramNamedParameterfvNV_ glGetProgramNamedParameterfvNV_ = (Delegates.glGetProgramNamedParameterfvNV_)GetAddress("glGetProgramNamedParameterfvNV", typeof(Delegates.glGetProgramNamedParameterfvNV_));
        public static Delegates.glGetProgramNamedParameterdvNV_ glGetProgramNamedParameterdvNV_ = (Delegates.glGetProgramNamedParameterdvNV_)GetAddress("glGetProgramNamedParameterdvNV", typeof(Delegates.glGetProgramNamedParameterdvNV_));
        public static Delegates.glVertex2hNV glVertex2hNV = (Delegates.glVertex2hNV)GetAddress("glVertex2hNV", typeof(Delegates.glVertex2hNV));
        public static Delegates.glVertex2hvNV_ glVertex2hvNV_ = (Delegates.glVertex2hvNV_)GetAddress("glVertex2hvNV", typeof(Delegates.glVertex2hvNV_));
        public static Delegates.glVertex3hNV glVertex3hNV = (Delegates.glVertex3hNV)GetAddress("glVertex3hNV", typeof(Delegates.glVertex3hNV));
        public static Delegates.glVertex3hvNV_ glVertex3hvNV_ = (Delegates.glVertex3hvNV_)GetAddress("glVertex3hvNV", typeof(Delegates.glVertex3hvNV_));
        public static Delegates.glVertex4hNV glVertex4hNV = (Delegates.glVertex4hNV)GetAddress("glVertex4hNV", typeof(Delegates.glVertex4hNV));
        public static Delegates.glVertex4hvNV_ glVertex4hvNV_ = (Delegates.glVertex4hvNV_)GetAddress("glVertex4hvNV", typeof(Delegates.glVertex4hvNV_));
        public static Delegates.glNormal3hNV glNormal3hNV = (Delegates.glNormal3hNV)GetAddress("glNormal3hNV", typeof(Delegates.glNormal3hNV));
        public static Delegates.glNormal3hvNV_ glNormal3hvNV_ = (Delegates.glNormal3hvNV_)GetAddress("glNormal3hvNV", typeof(Delegates.glNormal3hvNV_));
        public static Delegates.glColor3hNV glColor3hNV = (Delegates.glColor3hNV)GetAddress("glColor3hNV", typeof(Delegates.glColor3hNV));
        public static Delegates.glColor3hvNV_ glColor3hvNV_ = (Delegates.glColor3hvNV_)GetAddress("glColor3hvNV", typeof(Delegates.glColor3hvNV_));
        public static Delegates.glColor4hNV glColor4hNV = (Delegates.glColor4hNV)GetAddress("glColor4hNV", typeof(Delegates.glColor4hNV));
        public static Delegates.glColor4hvNV_ glColor4hvNV_ = (Delegates.glColor4hvNV_)GetAddress("glColor4hvNV", typeof(Delegates.glColor4hvNV_));
        public static Delegates.glTexCoord1hNV glTexCoord1hNV = (Delegates.glTexCoord1hNV)GetAddress("glTexCoord1hNV", typeof(Delegates.glTexCoord1hNV));
        public static Delegates.glTexCoord1hvNV_ glTexCoord1hvNV_ = (Delegates.glTexCoord1hvNV_)GetAddress("glTexCoord1hvNV", typeof(Delegates.glTexCoord1hvNV_));
        public static Delegates.glTexCoord2hNV glTexCoord2hNV = (Delegates.glTexCoord2hNV)GetAddress("glTexCoord2hNV", typeof(Delegates.glTexCoord2hNV));
        public static Delegates.glTexCoord2hvNV_ glTexCoord2hvNV_ = (Delegates.glTexCoord2hvNV_)GetAddress("glTexCoord2hvNV", typeof(Delegates.glTexCoord2hvNV_));
        public static Delegates.glTexCoord3hNV glTexCoord3hNV = (Delegates.glTexCoord3hNV)GetAddress("glTexCoord3hNV", typeof(Delegates.glTexCoord3hNV));
        public static Delegates.glTexCoord3hvNV_ glTexCoord3hvNV_ = (Delegates.glTexCoord3hvNV_)GetAddress("glTexCoord3hvNV", typeof(Delegates.glTexCoord3hvNV_));
        public static Delegates.glTexCoord4hNV glTexCoord4hNV = (Delegates.glTexCoord4hNV)GetAddress("glTexCoord4hNV", typeof(Delegates.glTexCoord4hNV));
        public static Delegates.glTexCoord4hvNV_ glTexCoord4hvNV_ = (Delegates.glTexCoord4hvNV_)GetAddress("glTexCoord4hvNV", typeof(Delegates.glTexCoord4hvNV_));
        public static Delegates.glMultiTexCoord1hNV glMultiTexCoord1hNV = (Delegates.glMultiTexCoord1hNV)GetAddress("glMultiTexCoord1hNV", typeof(Delegates.glMultiTexCoord1hNV));
        public static Delegates.glMultiTexCoord1hvNV_ glMultiTexCoord1hvNV_ = (Delegates.glMultiTexCoord1hvNV_)GetAddress("glMultiTexCoord1hvNV", typeof(Delegates.glMultiTexCoord1hvNV_));
        public static Delegates.glMultiTexCoord2hNV glMultiTexCoord2hNV = (Delegates.glMultiTexCoord2hNV)GetAddress("glMultiTexCoord2hNV", typeof(Delegates.glMultiTexCoord2hNV));
        public static Delegates.glMultiTexCoord2hvNV_ glMultiTexCoord2hvNV_ = (Delegates.glMultiTexCoord2hvNV_)GetAddress("glMultiTexCoord2hvNV", typeof(Delegates.glMultiTexCoord2hvNV_));
        public static Delegates.glMultiTexCoord3hNV glMultiTexCoord3hNV = (Delegates.glMultiTexCoord3hNV)GetAddress("glMultiTexCoord3hNV", typeof(Delegates.glMultiTexCoord3hNV));
        public static Delegates.glMultiTexCoord3hvNV_ glMultiTexCoord3hvNV_ = (Delegates.glMultiTexCoord3hvNV_)GetAddress("glMultiTexCoord3hvNV", typeof(Delegates.glMultiTexCoord3hvNV_));
        public static Delegates.glMultiTexCoord4hNV glMultiTexCoord4hNV = (Delegates.glMultiTexCoord4hNV)GetAddress("glMultiTexCoord4hNV", typeof(Delegates.glMultiTexCoord4hNV));
        public static Delegates.glMultiTexCoord4hvNV_ glMultiTexCoord4hvNV_ = (Delegates.glMultiTexCoord4hvNV_)GetAddress("glMultiTexCoord4hvNV", typeof(Delegates.glMultiTexCoord4hvNV_));
        public static Delegates.glFogCoordhNV glFogCoordhNV = (Delegates.glFogCoordhNV)GetAddress("glFogCoordhNV", typeof(Delegates.glFogCoordhNV));
        public static Delegates.glFogCoordhvNV_ glFogCoordhvNV_ = (Delegates.glFogCoordhvNV_)GetAddress("glFogCoordhvNV", typeof(Delegates.glFogCoordhvNV_));
        public static Delegates.glSecondaryColor3hNV glSecondaryColor3hNV = (Delegates.glSecondaryColor3hNV)GetAddress("glSecondaryColor3hNV", typeof(Delegates.glSecondaryColor3hNV));
        public static Delegates.glSecondaryColor3hvNV_ glSecondaryColor3hvNV_ = (Delegates.glSecondaryColor3hvNV_)GetAddress("glSecondaryColor3hvNV", typeof(Delegates.glSecondaryColor3hvNV_));
        public static Delegates.glVertexWeighthNV glVertexWeighthNV = (Delegates.glVertexWeighthNV)GetAddress("glVertexWeighthNV", typeof(Delegates.glVertexWeighthNV));
        public static Delegates.glVertexWeighthvNV_ glVertexWeighthvNV_ = (Delegates.glVertexWeighthvNV_)GetAddress("glVertexWeighthvNV", typeof(Delegates.glVertexWeighthvNV_));
        public static Delegates.glVertexAttrib1hNV glVertexAttrib1hNV = (Delegates.glVertexAttrib1hNV)GetAddress("glVertexAttrib1hNV", typeof(Delegates.glVertexAttrib1hNV));
        public static Delegates.glVertexAttrib1hvNV_ glVertexAttrib1hvNV_ = (Delegates.glVertexAttrib1hvNV_)GetAddress("glVertexAttrib1hvNV", typeof(Delegates.glVertexAttrib1hvNV_));
        public static Delegates.glVertexAttrib2hNV glVertexAttrib2hNV = (Delegates.glVertexAttrib2hNV)GetAddress("glVertexAttrib2hNV", typeof(Delegates.glVertexAttrib2hNV));
        public static Delegates.glVertexAttrib2hvNV_ glVertexAttrib2hvNV_ = (Delegates.glVertexAttrib2hvNV_)GetAddress("glVertexAttrib2hvNV", typeof(Delegates.glVertexAttrib2hvNV_));
        public static Delegates.glVertexAttrib3hNV glVertexAttrib3hNV = (Delegates.glVertexAttrib3hNV)GetAddress("glVertexAttrib3hNV", typeof(Delegates.glVertexAttrib3hNV));
        public static Delegates.glVertexAttrib3hvNV_ glVertexAttrib3hvNV_ = (Delegates.glVertexAttrib3hvNV_)GetAddress("glVertexAttrib3hvNV", typeof(Delegates.glVertexAttrib3hvNV_));
        public static Delegates.glVertexAttrib4hNV glVertexAttrib4hNV = (Delegates.glVertexAttrib4hNV)GetAddress("glVertexAttrib4hNV", typeof(Delegates.glVertexAttrib4hNV));
        public static Delegates.glVertexAttrib4hvNV_ glVertexAttrib4hvNV_ = (Delegates.glVertexAttrib4hvNV_)GetAddress("glVertexAttrib4hvNV", typeof(Delegates.glVertexAttrib4hvNV_));
        public static Delegates.glVertexAttribs1hvNV_ glVertexAttribs1hvNV_ = (Delegates.glVertexAttribs1hvNV_)GetAddress("glVertexAttribs1hvNV", typeof(Delegates.glVertexAttribs1hvNV_));
        public static Delegates.glVertexAttribs2hvNV_ glVertexAttribs2hvNV_ = (Delegates.glVertexAttribs2hvNV_)GetAddress("glVertexAttribs2hvNV", typeof(Delegates.glVertexAttribs2hvNV_));
        public static Delegates.glVertexAttribs3hvNV_ glVertexAttribs3hvNV_ = (Delegates.glVertexAttribs3hvNV_)GetAddress("glVertexAttribs3hvNV", typeof(Delegates.glVertexAttribs3hvNV_));
        public static Delegates.glVertexAttribs4hvNV_ glVertexAttribs4hvNV_ = (Delegates.glVertexAttribs4hvNV_)GetAddress("glVertexAttribs4hvNV", typeof(Delegates.glVertexAttribs4hvNV_));
        public static Delegates.glPixelDataRangeNV_ glPixelDataRangeNV_ = (Delegates.glPixelDataRangeNV_)GetAddress("glPixelDataRangeNV", typeof(Delegates.glPixelDataRangeNV_));
        public static Delegates.glFlushPixelDataRangeNV glFlushPixelDataRangeNV = (Delegates.glFlushPixelDataRangeNV)GetAddress("glFlushPixelDataRangeNV", typeof(Delegates.glFlushPixelDataRangeNV));
        public static Delegates.glPrimitiveRestartNV glPrimitiveRestartNV = (Delegates.glPrimitiveRestartNV)GetAddress("glPrimitiveRestartNV", typeof(Delegates.glPrimitiveRestartNV));
        public static Delegates.glPrimitiveRestartIndexNV glPrimitiveRestartIndexNV = (Delegates.glPrimitiveRestartIndexNV)GetAddress("glPrimitiveRestartIndexNV", typeof(Delegates.glPrimitiveRestartIndexNV));
        public static Delegates.glMapObjectBufferATI glMapObjectBufferATI = (Delegates.glMapObjectBufferATI)GetAddress("glMapObjectBufferATI", typeof(Delegates.glMapObjectBufferATI));
        public static Delegates.glUnmapObjectBufferATI glUnmapObjectBufferATI = (Delegates.glUnmapObjectBufferATI)GetAddress("glUnmapObjectBufferATI", typeof(Delegates.glUnmapObjectBufferATI));
        public static Delegates.glStencilOpSeparateATI glStencilOpSeparateATI = (Delegates.glStencilOpSeparateATI)GetAddress("glStencilOpSeparateATI", typeof(Delegates.glStencilOpSeparateATI));
        public static Delegates.glStencilFuncSeparateATI glStencilFuncSeparateATI = (Delegates.glStencilFuncSeparateATI)GetAddress("glStencilFuncSeparateATI", typeof(Delegates.glStencilFuncSeparateATI));
        public static Delegates.glVertexAttribArrayObjectATI glVertexAttribArrayObjectATI = (Delegates.glVertexAttribArrayObjectATI)GetAddress("glVertexAttribArrayObjectATI", typeof(Delegates.glVertexAttribArrayObjectATI));
        public static Delegates.glGetVertexAttribArrayObjectfvATI glGetVertexAttribArrayObjectfvATI = (Delegates.glGetVertexAttribArrayObjectfvATI)GetAddress("glGetVertexAttribArrayObjectfvATI", typeof(Delegates.glGetVertexAttribArrayObjectfvATI));
        public static Delegates.glGetVertexAttribArrayObjectivATI glGetVertexAttribArrayObjectivATI = (Delegates.glGetVertexAttribArrayObjectivATI)GetAddress("glGetVertexAttribArrayObjectivATI", typeof(Delegates.glGetVertexAttribArrayObjectivATI));
        public static Delegates.glDepthBoundsEXT glDepthBoundsEXT = (Delegates.glDepthBoundsEXT)GetAddress("glDepthBoundsEXT", typeof(Delegates.glDepthBoundsEXT));
        public static Delegates.glBlendEquationSeparateEXT glBlendEquationSeparateEXT = (Delegates.glBlendEquationSeparateEXT)GetAddress("glBlendEquationSeparateEXT", typeof(Delegates.glBlendEquationSeparateEXT));
        public static Delegates.glIsRenderbufferEXT glIsRenderbufferEXT = (Delegates.glIsRenderbufferEXT)GetAddress("glIsRenderbufferEXT", typeof(Delegates.glIsRenderbufferEXT));
        public static Delegates.glBindRenderbufferEXT glBindRenderbufferEXT = (Delegates.glBindRenderbufferEXT)GetAddress("glBindRenderbufferEXT", typeof(Delegates.glBindRenderbufferEXT));
        public static Delegates.glDeleteRenderbuffersEXT_ glDeleteRenderbuffersEXT_ = (Delegates.glDeleteRenderbuffersEXT_)GetAddress("glDeleteRenderbuffersEXT", typeof(Delegates.glDeleteRenderbuffersEXT_));
        public static Delegates.glGenRenderbuffersEXT glGenRenderbuffersEXT = (Delegates.glGenRenderbuffersEXT)GetAddress("glGenRenderbuffersEXT", typeof(Delegates.glGenRenderbuffersEXT));
        public static Delegates.glRenderbufferStorageEXT glRenderbufferStorageEXT = (Delegates.glRenderbufferStorageEXT)GetAddress("glRenderbufferStorageEXT", typeof(Delegates.glRenderbufferStorageEXT));
        public static Delegates.glGetRenderbufferParameterivEXT glGetRenderbufferParameterivEXT = (Delegates.glGetRenderbufferParameterivEXT)GetAddress("glGetRenderbufferParameterivEXT", typeof(Delegates.glGetRenderbufferParameterivEXT));
        public static Delegates.glIsFramebufferEXT glIsFramebufferEXT = (Delegates.glIsFramebufferEXT)GetAddress("glIsFramebufferEXT", typeof(Delegates.glIsFramebufferEXT));
        public static Delegates.glBindFramebufferEXT glBindFramebufferEXT = (Delegates.glBindFramebufferEXT)GetAddress("glBindFramebufferEXT", typeof(Delegates.glBindFramebufferEXT));
        public static Delegates.glDeleteFramebuffersEXT_ glDeleteFramebuffersEXT_ = (Delegates.glDeleteFramebuffersEXT_)GetAddress("glDeleteFramebuffersEXT", typeof(Delegates.glDeleteFramebuffersEXT_));
        public static Delegates.glGenFramebuffersEXT glGenFramebuffersEXT = (Delegates.glGenFramebuffersEXT)GetAddress("glGenFramebuffersEXT", typeof(Delegates.glGenFramebuffersEXT));
        public static Delegates.glCheckFramebufferStatusEXT glCheckFramebufferStatusEXT = (Delegates.glCheckFramebufferStatusEXT)GetAddress("glCheckFramebufferStatusEXT", typeof(Delegates.glCheckFramebufferStatusEXT));
        public static Delegates.glFramebufferTexture1DEXT glFramebufferTexture1DEXT = (Delegates.glFramebufferTexture1DEXT)GetAddress("glFramebufferTexture1DEXT", typeof(Delegates.glFramebufferTexture1DEXT));
        public static Delegates.glFramebufferTexture2DEXT glFramebufferTexture2DEXT = (Delegates.glFramebufferTexture2DEXT)GetAddress("glFramebufferTexture2DEXT", typeof(Delegates.glFramebufferTexture2DEXT));
        public static Delegates.glFramebufferTexture3DEXT glFramebufferTexture3DEXT = (Delegates.glFramebufferTexture3DEXT)GetAddress("glFramebufferTexture3DEXT", typeof(Delegates.glFramebufferTexture3DEXT));
        public static Delegates.glFramebufferRenderbufferEXT glFramebufferRenderbufferEXT = (Delegates.glFramebufferRenderbufferEXT)GetAddress("glFramebufferRenderbufferEXT", typeof(Delegates.glFramebufferRenderbufferEXT));
        public static Delegates.glGetFramebufferAttachmentParameterivEXT glGetFramebufferAttachmentParameterivEXT = (Delegates.glGetFramebufferAttachmentParameterivEXT)GetAddress("glGetFramebufferAttachmentParameterivEXT", typeof(Delegates.glGetFramebufferAttachmentParameterivEXT));
        public static Delegates.glGenerateMipmapEXT glGenerateMipmapEXT = (Delegates.glGenerateMipmapEXT)GetAddress("glGenerateMipmapEXT", typeof(Delegates.glGenerateMipmapEXT));
        public static Delegates.glStringMarkerGREMEDY_ glStringMarkerGREMEDY_ = (Delegates.glStringMarkerGREMEDY_)GetAddress("glStringMarkerGREMEDY", typeof(Delegates.glStringMarkerGREMEDY_));
        #endregion

        #region Wrappers

        #region glCallLists
        public static void glCallLists(GLsizei n, GLenum type, object lists)
        {
            GCHandle h0 = GCHandle.Alloc(lists, GCHandleType.Pinned);
            try
            {
                glCallLists_(n, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glCallLists(GLsizei n, GLenum type, IntPtr lists)
        {
            glCallLists_(n, type, lists);
        }
        #endregion

        #region glBitmap
        public static void glBitmap(GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, object bitmap)
        {
            GCHandle h0 = GCHandle.Alloc(bitmap, GCHandleType.Pinned);
            try
            {
                glBitmap_(width, height, xorig, yorig, xmove, ymove, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glBitmap(GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, IntPtr bitmap)
        {
            glBitmap_(width, height, xorig, yorig, xmove, ymove, bitmap);
        }
        public static void glBitmap(GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, GLubyte[] bitmap)
        {
            GCHandle h0 = GCHandle.Alloc(bitmap, GCHandleType.Pinned);
            try
            {
                glBitmap_(width, height, xorig, yorig, xmove, ymove, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor3bv
        public static void glColor3bv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3bv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor3bv(IntPtr v)
        {
            glColor3bv_(v);
        }
        public static void glColor3bv(GLbyte[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3bv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor3dv
        public static void glColor3dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor3dv(IntPtr v)
        {
            glColor3dv_(v);
        }
        public static void glColor3dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor3fv
        public static void glColor3fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor3fv(IntPtr v)
        {
            glColor3fv_(v);
        }
        public static void glColor3fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor3iv
        public static void glColor3iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor3iv(IntPtr v)
        {
            glColor3iv_(v);
        }
        public static void glColor3iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor3sv
        public static void glColor3sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor3sv(IntPtr v)
        {
            glColor3sv_(v);
        }
        public static void glColor3sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor3ubv
        public static void glColor3ubv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3ubv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor3ubv(IntPtr v)
        {
            glColor3ubv_(v);
        }
        public static void glColor3ubv(GLubyte[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3ubv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor3uiv
        public static void glColor3uiv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3uiv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor3uiv(IntPtr v)
        {
            glColor3uiv_(v);
        }
        public static void glColor3uiv(GLuint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3uiv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor3usv
        public static void glColor3usv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3usv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor3usv(IntPtr v)
        {
            glColor3usv_(v);
        }
        public static void glColor3usv(GLushort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor3usv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor4bv
        public static void glColor4bv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4bv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor4bv(IntPtr v)
        {
            glColor4bv_(v);
        }
        public static void glColor4bv(GLbyte[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4bv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor4dv
        public static void glColor4dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor4dv(IntPtr v)
        {
            glColor4dv_(v);
        }
        public static void glColor4dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor4fv
        public static void glColor4fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor4fv(IntPtr v)
        {
            glColor4fv_(v);
        }
        public static void glColor4fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor4iv
        public static void glColor4iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor4iv(IntPtr v)
        {
            glColor4iv_(v);
        }
        public static void glColor4iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor4sv
        public static void glColor4sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor4sv(IntPtr v)
        {
            glColor4sv_(v);
        }
        public static void glColor4sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor4ubv
        public static void glColor4ubv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4ubv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor4ubv(IntPtr v)
        {
            glColor4ubv_(v);
        }
        public static void glColor4ubv(GLubyte[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4ubv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor4uiv
        public static void glColor4uiv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4uiv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor4uiv(IntPtr v)
        {
            glColor4uiv_(v);
        }
        public static void glColor4uiv(GLuint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4uiv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColor4usv
        public static void glColor4usv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4usv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColor4usv(IntPtr v)
        {
            glColor4usv_(v);
        }
        public static void glColor4usv(GLushort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glColor4usv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glEdgeFlagv
        public static void glEdgeFlagv(object flag)
        {
            GCHandle h0 = GCHandle.Alloc(flag, GCHandleType.Pinned);
            try
            {
                glEdgeFlagv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glEdgeFlagv(IntPtr flag)
        {
            glEdgeFlagv_(flag);
        }
        public static void glEdgeFlagv(GLboolean[] flag)
        {
            GCHandle h0 = GCHandle.Alloc(flag, GCHandleType.Pinned);
            try
            {
                glEdgeFlagv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glIndexdv
        public static void glIndexdv(object c)
        {
            GCHandle h0 = GCHandle.Alloc(c, GCHandleType.Pinned);
            try
            {
                glIndexdv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glIndexdv(IntPtr c)
        {
            glIndexdv_(c);
        }
        public static void glIndexdv(GLdouble[] c)
        {
            GCHandle h0 = GCHandle.Alloc(c, GCHandleType.Pinned);
            try
            {
                glIndexdv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glIndexfv
        public static void glIndexfv(object c)
        {
            GCHandle h0 = GCHandle.Alloc(c, GCHandleType.Pinned);
            try
            {
                glIndexfv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glIndexfv(IntPtr c)
        {
            glIndexfv_(c);
        }
        public static void glIndexfv(GLfloat[] c)
        {
            GCHandle h0 = GCHandle.Alloc(c, GCHandleType.Pinned);
            try
            {
                glIndexfv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glIndexiv
        public static void glIndexiv(object c)
        {
            GCHandle h0 = GCHandle.Alloc(c, GCHandleType.Pinned);
            try
            {
                glIndexiv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glIndexiv(IntPtr c)
        {
            glIndexiv_(c);
        }
        public static void glIndexiv(GLint[] c)
        {
            GCHandle h0 = GCHandle.Alloc(c, GCHandleType.Pinned);
            try
            {
                glIndexiv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glIndexsv
        public static void glIndexsv(object c)
        {
            GCHandle h0 = GCHandle.Alloc(c, GCHandleType.Pinned);
            try
            {
                glIndexsv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glIndexsv(IntPtr c)
        {
            glIndexsv_(c);
        }
        public static void glIndexsv(GLshort[] c)
        {
            GCHandle h0 = GCHandle.Alloc(c, GCHandleType.Pinned);
            try
            {
                glIndexsv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glNormal3bv
        public static void glNormal3bv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glNormal3bv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glNormal3bv(IntPtr v)
        {
            glNormal3bv_(v);
        }
        public static void glNormal3bv(GLbyte[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glNormal3bv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glNormal3dv
        public static void glNormal3dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glNormal3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glNormal3dv(IntPtr v)
        {
            glNormal3dv_(v);
        }
        public static void glNormal3dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glNormal3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glNormal3fv
        public static void glNormal3fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glNormal3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glNormal3fv(IntPtr v)
        {
            glNormal3fv_(v);
        }
        public static void glNormal3fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glNormal3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glNormal3iv
        public static void glNormal3iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glNormal3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glNormal3iv(IntPtr v)
        {
            glNormal3iv_(v);
        }
        public static void glNormal3iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glNormal3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glNormal3sv
        public static void glNormal3sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glNormal3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glNormal3sv(IntPtr v)
        {
            glNormal3sv_(v);
        }
        public static void glNormal3sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glNormal3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glRasterPos2dv
        public static void glRasterPos2dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos2dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glRasterPos2dv(IntPtr v)
        {
            glRasterPos2dv_(v);
        }
        public static void glRasterPos2dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos2dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glRasterPos2fv
        public static void glRasterPos2fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos2fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glRasterPos2fv(IntPtr v)
        {
            glRasterPos2fv_(v);
        }
        public static void glRasterPos2fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos2fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glRasterPos2iv
        public static void glRasterPos2iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos2iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glRasterPos2iv(IntPtr v)
        {
            glRasterPos2iv_(v);
        }
        public static void glRasterPos2iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos2iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glRasterPos2sv
        public static void glRasterPos2sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos2sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glRasterPos2sv(IntPtr v)
        {
            glRasterPos2sv_(v);
        }
        public static void glRasterPos2sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos2sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glRasterPos3dv
        public static void glRasterPos3dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glRasterPos3dv(IntPtr v)
        {
            glRasterPos3dv_(v);
        }
        public static void glRasterPos3dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glRasterPos3fv
        public static void glRasterPos3fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glRasterPos3fv(IntPtr v)
        {
            glRasterPos3fv_(v);
        }
        public static void glRasterPos3fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glRasterPos3iv
        public static void glRasterPos3iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glRasterPos3iv(IntPtr v)
        {
            glRasterPos3iv_(v);
        }
        public static void glRasterPos3iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glRasterPos3sv
        public static void glRasterPos3sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glRasterPos3sv(IntPtr v)
        {
            glRasterPos3sv_(v);
        }
        public static void glRasterPos3sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glRasterPos4dv
        public static void glRasterPos4dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos4dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glRasterPos4dv(IntPtr v)
        {
            glRasterPos4dv_(v);
        }
        public static void glRasterPos4dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos4dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glRasterPos4fv
        public static void glRasterPos4fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos4fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glRasterPos4fv(IntPtr v)
        {
            glRasterPos4fv_(v);
        }
        public static void glRasterPos4fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos4fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glRasterPos4iv
        public static void glRasterPos4iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos4iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glRasterPos4iv(IntPtr v)
        {
            glRasterPos4iv_(v);
        }
        public static void glRasterPos4iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos4iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glRasterPos4sv
        public static void glRasterPos4sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos4sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glRasterPos4sv(IntPtr v)
        {
            glRasterPos4sv_(v);
        }
        public static void glRasterPos4sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glRasterPos4sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glRectdv
        public static void glRectdv(object v1, object v2)
        {
            GCHandle h0 = GCHandle.Alloc(v1, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(v2, GCHandleType.Pinned);
            try
            {
                glRectdv_(h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject());
            }
            finally
            {
                h1.Free();
                h0.Free();
            }
        }
        public static void glRectdv(IntPtr v1, IntPtr v2)
        {
            glRectdv_(v1, v2);
        }
        public static void glRectdv(GLdouble[] v1, GLdouble[] v2)
        {
            GCHandle h0 = GCHandle.Alloc(v1, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(v2, GCHandleType.Pinned);
            try
            {
                glRectdv_(h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject());
            }
            finally
            {
                h1.Free();
                h0.Free();
            }
        }
        #endregion

        #region glRectfv
        public static void glRectfv(object v1, object v2)
        {
            GCHandle h0 = GCHandle.Alloc(v1, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(v2, GCHandleType.Pinned);
            try
            {
                glRectfv_(h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject());
            }
            finally
            {
                h1.Free();
                h0.Free();
            }
        }
        public static void glRectfv(IntPtr v1, IntPtr v2)
        {
            glRectfv_(v1, v2);
        }
        public static void glRectfv(GLfloat[] v1, GLfloat[] v2)
        {
            GCHandle h0 = GCHandle.Alloc(v1, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(v2, GCHandleType.Pinned);
            try
            {
                glRectfv_(h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject());
            }
            finally
            {
                h1.Free();
                h0.Free();
            }
        }
        #endregion

        #region glRectiv
        public static void glRectiv(object v1, object v2)
        {
            GCHandle h0 = GCHandle.Alloc(v1, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(v2, GCHandleType.Pinned);
            try
            {
                glRectiv_(h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject());
            }
            finally
            {
                h1.Free();
                h0.Free();
            }
        }
        public static void glRectiv(IntPtr v1, IntPtr v2)
        {
            glRectiv_(v1, v2);
        }
        public static void glRectiv(GLint[] v1, GLint[] v2)
        {
            GCHandle h0 = GCHandle.Alloc(v1, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(v2, GCHandleType.Pinned);
            try
            {
                glRectiv_(h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject());
            }
            finally
            {
                h1.Free();
                h0.Free();
            }
        }
        #endregion

        #region glRectsv
        public static void glRectsv(object v1, object v2)
        {
            GCHandle h0 = GCHandle.Alloc(v1, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(v2, GCHandleType.Pinned);
            try
            {
                glRectsv_(h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject());
            }
            finally
            {
                h1.Free();
                h0.Free();
            }
        }
        public static void glRectsv(IntPtr v1, IntPtr v2)
        {
            glRectsv_(v1, v2);
        }
        public static void glRectsv(GLshort[] v1, GLshort[] v2)
        {
            GCHandle h0 = GCHandle.Alloc(v1, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(v2, GCHandleType.Pinned);
            try
            {
                glRectsv_(h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject());
            }
            finally
            {
                h1.Free();
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord1dv
        public static void glTexCoord1dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord1dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord1dv(IntPtr v)
        {
            glTexCoord1dv_(v);
        }
        public static void glTexCoord1dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord1dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord1fv
        public static void glTexCoord1fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord1fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord1fv(IntPtr v)
        {
            glTexCoord1fv_(v);
        }
        public static void glTexCoord1fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord1fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord1iv
        public static void glTexCoord1iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord1iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord1iv(IntPtr v)
        {
            glTexCoord1iv_(v);
        }
        public static void glTexCoord1iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord1iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord1sv
        public static void glTexCoord1sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord1sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord1sv(IntPtr v)
        {
            glTexCoord1sv_(v);
        }
        public static void glTexCoord1sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord1sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord2dv
        public static void glTexCoord2dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord2dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord2dv(IntPtr v)
        {
            glTexCoord2dv_(v);
        }
        public static void glTexCoord2dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord2dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord2fv
        public static void glTexCoord2fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord2fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord2fv(IntPtr v)
        {
            glTexCoord2fv_(v);
        }
        public static void glTexCoord2fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord2fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord2iv
        public static void glTexCoord2iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord2iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord2iv(IntPtr v)
        {
            glTexCoord2iv_(v);
        }
        public static void glTexCoord2iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord2iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord2sv
        public static void glTexCoord2sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord2sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord2sv(IntPtr v)
        {
            glTexCoord2sv_(v);
        }
        public static void glTexCoord2sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord2sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord3dv
        public static void glTexCoord3dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord3dv(IntPtr v)
        {
            glTexCoord3dv_(v);
        }
        public static void glTexCoord3dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord3fv
        public static void glTexCoord3fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord3fv(IntPtr v)
        {
            glTexCoord3fv_(v);
        }
        public static void glTexCoord3fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord3iv
        public static void glTexCoord3iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord3iv(IntPtr v)
        {
            glTexCoord3iv_(v);
        }
        public static void glTexCoord3iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord3sv
        public static void glTexCoord3sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord3sv(IntPtr v)
        {
            glTexCoord3sv_(v);
        }
        public static void glTexCoord3sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord4dv
        public static void glTexCoord4dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord4dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord4dv(IntPtr v)
        {
            glTexCoord4dv_(v);
        }
        public static void glTexCoord4dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord4dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord4fv
        public static void glTexCoord4fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord4fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord4fv(IntPtr v)
        {
            glTexCoord4fv_(v);
        }
        public static void glTexCoord4fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord4fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord4iv
        public static void glTexCoord4iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord4iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord4iv(IntPtr v)
        {
            glTexCoord4iv_(v);
        }
        public static void glTexCoord4iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord4iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexCoord4sv
        public static void glTexCoord4sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord4sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoord4sv(IntPtr v)
        {
            glTexCoord4sv_(v);
        }
        public static void glTexCoord4sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glTexCoord4sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertex2dv
        public static void glVertex2dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex2dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertex2dv(IntPtr v)
        {
            glVertex2dv_(v);
        }
        public static void glVertex2dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex2dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertex2fv
        public static void glVertex2fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex2fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertex2fv(IntPtr v)
        {
            glVertex2fv_(v);
        }
        public static void glVertex2fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex2fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertex2iv
        public static void glVertex2iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex2iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertex2iv(IntPtr v)
        {
            glVertex2iv_(v);
        }
        public static void glVertex2iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex2iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertex2sv
        public static void glVertex2sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex2sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertex2sv(IntPtr v)
        {
            glVertex2sv_(v);
        }
        public static void glVertex2sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex2sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertex3dv
        public static void glVertex3dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertex3dv(IntPtr v)
        {
            glVertex3dv_(v);
        }
        public static void glVertex3dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertex3fv
        public static void glVertex3fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertex3fv(IntPtr v)
        {
            glVertex3fv_(v);
        }
        public static void glVertex3fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertex3iv
        public static void glVertex3iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertex3iv(IntPtr v)
        {
            glVertex3iv_(v);
        }
        public static void glVertex3iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertex3sv
        public static void glVertex3sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertex3sv(IntPtr v)
        {
            glVertex3sv_(v);
        }
        public static void glVertex3sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertex4dv
        public static void glVertex4dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex4dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertex4dv(IntPtr v)
        {
            glVertex4dv_(v);
        }
        public static void glVertex4dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex4dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertex4fv
        public static void glVertex4fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex4fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertex4fv(IntPtr v)
        {
            glVertex4fv_(v);
        }
        public static void glVertex4fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex4fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertex4iv
        public static void glVertex4iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex4iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertex4iv(IntPtr v)
        {
            glVertex4iv_(v);
        }
        public static void glVertex4iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex4iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertex4sv
        public static void glVertex4sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex4sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertex4sv(IntPtr v)
        {
            glVertex4sv_(v);
        }
        public static void glVertex4sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertex4sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glClipPlane
        public static void glClipPlane(GLenum plane, object equation)
        {
            GCHandle h0 = GCHandle.Alloc(equation, GCHandleType.Pinned);
            try
            {
                glClipPlane_(plane, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glClipPlane(GLenum plane, IntPtr equation)
        {
            glClipPlane_(plane, equation);
        }
        public static void glClipPlane(GLenum plane, GLdouble[] equation)
        {
            GCHandle h0 = GCHandle.Alloc(equation, GCHandleType.Pinned);
            try
            {
                glClipPlane_(plane, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glFogfv
        public static void glFogfv(GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glFogfv_(pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glFogfv(GLenum pname, IntPtr parameters)
        {
            glFogfv_(pname, parameters);
        }
        public static void glFogfv(GLenum pname, GLfloat[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glFogfv_(pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glFogiv
        public static void glFogiv(GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glFogiv_(pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glFogiv(GLenum pname, IntPtr parameters)
        {
            glFogiv_(pname, parameters);
        }
        public static void glFogiv(GLenum pname, GLint[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glFogiv_(pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glLightfv
        public static void glLightfv(GLenum light, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glLightfv_(light, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glLightfv(GLenum light, GLenum pname, IntPtr parameters)
        {
            glLightfv_(light, pname, parameters);
        }
        public static void glLightfv(GLenum light, GLenum pname, GLfloat[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glLightfv_(light, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glLightiv
        public static void glLightiv(GLenum light, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glLightiv_(light, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glLightiv(GLenum light, GLenum pname, IntPtr parameters)
        {
            glLightiv_(light, pname, parameters);
        }
        public static void glLightiv(GLenum light, GLenum pname, GLint[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glLightiv_(light, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glLightModelfv
        public static void glLightModelfv(GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glLightModelfv_(pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glLightModelfv(GLenum pname, IntPtr parameters)
        {
            glLightModelfv_(pname, parameters);
        }
        public static void glLightModelfv(GLenum pname, GLfloat[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glLightModelfv_(pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glLightModeliv
        public static void glLightModeliv(GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glLightModeliv_(pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glLightModeliv(GLenum pname, IntPtr parameters)
        {
            glLightModeliv_(pname, parameters);
        }
        public static void glLightModeliv(GLenum pname, GLint[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glLightModeliv_(pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glLineStipple
        public static void glLineStipple(GLint factor, GLint pattern)
        {
             glLineStipple_(factor, unchecked((GLushort)pattern));
        }
        #endregion

        #region glMaterialfv
        public static void glMaterialfv(GLenum face, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glMaterialfv_(face, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMaterialfv(GLenum face, GLenum pname, IntPtr parameters)
        {
            glMaterialfv_(face, pname, parameters);
        }
        public static void glMaterialfv(GLenum face, GLenum pname, GLfloat[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glMaterialfv_(face, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMaterialiv
        public static void glMaterialiv(GLenum face, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glMaterialiv_(face, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMaterialiv(GLenum face, GLenum pname, IntPtr parameters)
        {
            glMaterialiv_(face, pname, parameters);
        }
        public static void glMaterialiv(GLenum face, GLenum pname, GLint[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glMaterialiv_(face, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glPolygonStipple
        public static void glPolygonStipple(object mask)
        {
            GCHandle h0 = GCHandle.Alloc(mask, GCHandleType.Pinned);
            try
            {
                glPolygonStipple_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glPolygonStipple(IntPtr mask)
        {
            glPolygonStipple_(mask);
        }
        public static void glPolygonStipple(GLubyte[] mask)
        {
            GCHandle h0 = GCHandle.Alloc(mask, GCHandleType.Pinned);
            try
            {
                glPolygonStipple_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexParameterfv
        public static void glTexParameterfv(GLenum target, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexParameterfv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexParameterfv(GLenum target, GLenum pname, IntPtr parameters)
        {
            glTexParameterfv_(target, pname, parameters);
        }
        public static void glTexParameterfv(GLenum target, GLenum pname, GLfloat[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexParameterfv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexParameteriv
        public static void glTexParameteriv(GLenum target, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexParameteriv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexParameteriv(GLenum target, GLenum pname, IntPtr parameters)
        {
            glTexParameteriv_(target, pname, parameters);
        }
        public static void glTexParameteriv(GLenum target, GLenum pname, GLint[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexParameteriv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexImage1D
        public static void glTexImage1D(GLenum target, GLint level, GLint internalformat, GLsizei width, GLint border, GLenum format, GLenum type, object pixels)
        {
            GCHandle h0 = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glTexImage1D_(target, level, internalformat, width, border, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexImage1D(GLenum target, GLint level, GLint internalformat, GLsizei width, GLint border, GLenum format, GLenum type, IntPtr pixels)
        {
            glTexImage1D_(target, level, internalformat, width, border, format, type, pixels);
        }
        #endregion

        #region glTexImage2D
        public static void glTexImage2D(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, object pixels)
        {
            GCHandle h0 = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glTexImage2D_(target, level, internalformat, width, height, border, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexImage2D(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, IntPtr pixels)
        {
            glTexImage2D_(target, level, internalformat, width, height, border, format, type, pixels);
        }
        #endregion

        #region glTexEnvfv
        public static void glTexEnvfv(GLenum target, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexEnvfv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexEnvfv(GLenum target, GLenum pname, IntPtr parameters)
        {
            glTexEnvfv_(target, pname, parameters);
        }
        public static void glTexEnvfv(GLenum target, GLenum pname, GLfloat[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexEnvfv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexEnviv
        public static void glTexEnviv(GLenum target, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexEnviv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexEnviv(GLenum target, GLenum pname, IntPtr parameters)
        {
            glTexEnviv_(target, pname, parameters);
        }
        public static void glTexEnviv(GLenum target, GLenum pname, GLint[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexEnviv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexGendv
        public static void glTexGendv(GLenum coord, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexGendv_(coord, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexGendv(GLenum coord, GLenum pname, IntPtr parameters)
        {
            glTexGendv_(coord, pname, parameters);
        }
        public static void glTexGendv(GLenum coord, GLenum pname, GLdouble[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexGendv_(coord, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexGenfv
        public static void glTexGenfv(GLenum coord, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexGenfv_(coord, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexGenfv(GLenum coord, GLenum pname, IntPtr parameters)
        {
            glTexGenfv_(coord, pname, parameters);
        }
        public static void glTexGenfv(GLenum coord, GLenum pname, GLfloat[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexGenfv_(coord, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glTexGeniv
        public static void glTexGeniv(GLenum coord, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexGeniv_(coord, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexGeniv(GLenum coord, GLenum pname, IntPtr parameters)
        {
            glTexGeniv_(coord, pname, parameters);
        }
        public static void glTexGeniv(GLenum coord, GLenum pname, GLint[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glTexGeniv_(coord, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMap1d
        public static void glMap1d(GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, object points)
        {
            GCHandle h0 = GCHandle.Alloc(points, GCHandleType.Pinned);
            try
            {
                glMap1d_(target, u1, u2, stride, order, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMap1d(GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, IntPtr points)
        {
            glMap1d_(target, u1, u2, stride, order, points);
        }
        public static void glMap1d(GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, GLdouble[] points)
        {
            GCHandle h0 = GCHandle.Alloc(points, GCHandleType.Pinned);
            try
            {
                glMap1d_(target, u1, u2, stride, order, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMap1f
        public static void glMap1f(GLenum target, GLfloat u1, GLfloat u2, GLint stride, GLint order, object points)
        {
            GCHandle h0 = GCHandle.Alloc(points, GCHandleType.Pinned);
            try
            {
                glMap1f_(target, u1, u2, stride, order, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMap1f(GLenum target, GLfloat u1, GLfloat u2, GLint stride, GLint order, IntPtr points)
        {
            glMap1f_(target, u1, u2, stride, order, points);
        }
        public static void glMap1f(GLenum target, GLfloat u1, GLfloat u2, GLint stride, GLint order, GLfloat[] points)
        {
            GCHandle h0 = GCHandle.Alloc(points, GCHandleType.Pinned);
            try
            {
                glMap1f_(target, u1, u2, stride, order, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMap2d
        public static void glMap2d(GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, object points)
        {
            GCHandle h0 = GCHandle.Alloc(points, GCHandleType.Pinned);
            try
            {
                glMap2d_(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMap2d(GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, IntPtr points)
        {
            glMap2d_(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points);
        }
        public static void glMap2d(GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, GLdouble[] points)
        {
            GCHandle h0 = GCHandle.Alloc(points, GCHandleType.Pinned);
            try
            {
                glMap2d_(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMap2f
        public static void glMap2f(GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, object points)
        {
            GCHandle h0 = GCHandle.Alloc(points, GCHandleType.Pinned);
            try
            {
                glMap2f_(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMap2f(GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, IntPtr points)
        {
            glMap2f_(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points);
        }
        public static void glMap2f(GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, GLfloat[] points)
        {
            GCHandle h0 = GCHandle.Alloc(points, GCHandleType.Pinned);
            try
            {
                glMap2f_(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glEvalCoord1dv
        public static void glEvalCoord1dv(object u)
        {
            GCHandle h0 = GCHandle.Alloc(u, GCHandleType.Pinned);
            try
            {
                glEvalCoord1dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glEvalCoord1dv(IntPtr u)
        {
            glEvalCoord1dv_(u);
        }
        public static void glEvalCoord1dv(GLdouble[] u)
        {
            GCHandle h0 = GCHandle.Alloc(u, GCHandleType.Pinned);
            try
            {
                glEvalCoord1dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glEvalCoord1fv
        public static void glEvalCoord1fv(object u)
        {
            GCHandle h0 = GCHandle.Alloc(u, GCHandleType.Pinned);
            try
            {
                glEvalCoord1fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glEvalCoord1fv(IntPtr u)
        {
            glEvalCoord1fv_(u);
        }
        public static void glEvalCoord1fv(GLfloat[] u)
        {
            GCHandle h0 = GCHandle.Alloc(u, GCHandleType.Pinned);
            try
            {
                glEvalCoord1fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glEvalCoord2dv
        public static void glEvalCoord2dv(object u)
        {
            GCHandle h0 = GCHandle.Alloc(u, GCHandleType.Pinned);
            try
            {
                glEvalCoord2dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glEvalCoord2dv(IntPtr u)
        {
            glEvalCoord2dv_(u);
        }
        public static void glEvalCoord2dv(GLdouble[] u)
        {
            GCHandle h0 = GCHandle.Alloc(u, GCHandleType.Pinned);
            try
            {
                glEvalCoord2dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glEvalCoord2fv
        public static void glEvalCoord2fv(object u)
        {
            GCHandle h0 = GCHandle.Alloc(u, GCHandleType.Pinned);
            try
            {
                glEvalCoord2fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glEvalCoord2fv(IntPtr u)
        {
            glEvalCoord2fv_(u);
        }
        public static void glEvalCoord2fv(GLfloat[] u)
        {
            GCHandle h0 = GCHandle.Alloc(u, GCHandleType.Pinned);
            try
            {
                glEvalCoord2fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glPixelMapfv
        public static void glPixelMapfv(GLenum map, GLint mapsize, object values)
        {
            GCHandle h0 = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                glPixelMapfv_(map, mapsize, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glPixelMapfv(GLenum map, GLint mapsize, IntPtr values)
        {
            glPixelMapfv_(map, mapsize, values);
        }
        public static void glPixelMapfv(GLenum map, GLint mapsize, GLfloat[] values)
        {
            GCHandle h0 = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                glPixelMapfv_(map, mapsize, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glPixelMapuiv
        public static void glPixelMapuiv(GLenum map, GLint mapsize, object values)
        {
            GCHandle h0 = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                glPixelMapuiv_(map, mapsize, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glPixelMapuiv(GLenum map, GLint mapsize, IntPtr values)
        {
            glPixelMapuiv_(map, mapsize, values);
        }
        public static void glPixelMapuiv(GLenum map, GLint mapsize, GLuint[] values)
        {
            GCHandle h0 = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                glPixelMapuiv_(map, mapsize, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glPixelMapusv
        public static void glPixelMapusv(GLenum map, GLint mapsize, object values)
        {
            GCHandle h0 = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                glPixelMapusv_(map, mapsize, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glPixelMapusv(GLenum map, GLint mapsize, IntPtr values)
        {
            glPixelMapusv_(map, mapsize, values);
        }
        public static void glPixelMapusv(GLenum map, GLint mapsize, GLushort[] values)
        {
            GCHandle h0 = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                glPixelMapusv_(map, mapsize, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glReadPixels
        public static void glReadPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, object pixels)
        {
            GCHandle h0 = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glReadPixels_(x, y, width, height, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glReadPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels)
        {
            glReadPixels_(x, y, width, height, format, type, pixels);
        }
        #endregion

        #region glDrawPixels
        public static void glDrawPixels(GLsizei width, GLsizei height, GLenum format, GLenum type, object pixels)
        {
            GCHandle h0 = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glDrawPixels_(width, height, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glDrawPixels(GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels)
        {
            glDrawPixels_(width, height, format, type, pixels);
        }
        #endregion

        #region glGetString
        public static string glGetString(GLenum name)
        {
             return Marshal.PtrToStringAnsi(glGetString_(name));
        }
        #endregion

        #region glGetTexImage
        public static void glGetTexImage(GLenum target, GLint level, GLenum format, GLenum type, object pixels)
        {
            GCHandle h0 = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glGetTexImage_(target, level, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glGetTexImage(GLenum target, GLint level, GLenum format, GLenum type, IntPtr pixels)
        {
            glGetTexImage_(target, level, format, type, pixels);
        }
        #endregion

        #region glLoadMatrixf
        public static void glLoadMatrixf(object m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glLoadMatrixf_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glLoadMatrixf(IntPtr m)
        {
            glLoadMatrixf_(m);
        }
        public static void glLoadMatrixf(GLfloat[] m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glLoadMatrixf_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glLoadMatrixd
        public static void glLoadMatrixd(object m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glLoadMatrixd_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glLoadMatrixd(IntPtr m)
        {
            glLoadMatrixd_(m);
        }
        public static void glLoadMatrixd(GLdouble[] m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glLoadMatrixd_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultMatrixf
        public static void glMultMatrixf(object m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glMultMatrixf_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultMatrixf(IntPtr m)
        {
            glMultMatrixf_(m);
        }
        public static void glMultMatrixf(GLfloat[] m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glMultMatrixf_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultMatrixd
        public static void glMultMatrixd(object m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glMultMatrixd_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultMatrixd(IntPtr m)
        {
            glMultMatrixd_(m);
        }
        public static void glMultMatrixd(GLdouble[] m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glMultMatrixd_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColorPointer
        public static void glColorPointer(GLint size, GLenum type, GLsizei stride, object pointer)
        {
            GCHandle h0 = GCHandle.Alloc(pointer, GCHandleType.Pinned);
            try
            {
                glColorPointer_(size, type, stride, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColorPointer(GLint size, GLenum type, GLsizei stride, IntPtr pointer)
        {
            glColorPointer_(size, type, stride, pointer);
        }
        #endregion

        #region glDrawElements
        public static void glDrawElements(GLenum mode, GLsizei count, GLenum type, object indices)
        {
            GCHandle h0 = GCHandle.Alloc(indices, GCHandleType.Pinned);
            try
            {
                glDrawElements_(mode, count, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glDrawElements(GLenum mode, GLsizei count, GLenum type, IntPtr indices)
        {
            glDrawElements_(mode, count, type, indices);
        }
        #endregion

        #region glEdgeFlagPointer
        public static void glEdgeFlagPointer(GLsizei stride, object pointer)
        {
            GCHandle h0 = GCHandle.Alloc(pointer, GCHandleType.Pinned);
            try
            {
                glEdgeFlagPointer_(stride, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glEdgeFlagPointer(GLsizei stride, IntPtr pointer)
        {
            glEdgeFlagPointer_(stride, pointer);
        }
        #endregion

        #region glIndexPointer
        public static void glIndexPointer(GLenum type, GLsizei stride, object pointer)
        {
            GCHandle h0 = GCHandle.Alloc(pointer, GCHandleType.Pinned);
            try
            {
                glIndexPointer_(type, stride, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glIndexPointer(GLenum type, GLsizei stride, IntPtr pointer)
        {
            glIndexPointer_(type, stride, pointer);
        }
        #endregion

        #region glInterleavedArrays
        public static void glInterleavedArrays(GLenum format, GLsizei stride, object pointer)
        {
            GCHandle h0 = GCHandle.Alloc(pointer, GCHandleType.Pinned);
            try
            {
                glInterleavedArrays_(format, stride, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glInterleavedArrays(GLenum format, GLsizei stride, IntPtr pointer)
        {
            glInterleavedArrays_(format, stride, pointer);
        }
        #endregion

        #region glNormalPointer
        public static void glNormalPointer(GLenum type, GLsizei stride, object pointer)
        {
            GCHandle h0 = GCHandle.Alloc(pointer, GCHandleType.Pinned);
            try
            {
                glNormalPointer_(type, stride, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glNormalPointer(GLenum type, GLsizei stride, IntPtr pointer)
        {
            glNormalPointer_(type, stride, pointer);
        }
        #endregion

        #region glTexCoordPointer
        public static void glTexCoordPointer(GLint size, GLenum type, GLsizei stride, object pointer)
        {
            GCHandle h0 = GCHandle.Alloc(pointer, GCHandleType.Pinned);
            try
            {
                glTexCoordPointer_(size, type, stride, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexCoordPointer(GLint size, GLenum type, GLsizei stride, IntPtr pointer)
        {
            glTexCoordPointer_(size, type, stride, pointer);
        }
        #endregion

        #region glVertexPointer
        public static void glVertexPointer(GLint size, GLenum type, GLsizei stride, object pointer)
        {
            GCHandle h0 = GCHandle.Alloc(pointer, GCHandleType.Pinned);
            try
            {
                glVertexPointer_(size, type, stride, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexPointer(GLint size, GLenum type, GLsizei stride, IntPtr pointer)
        {
            glVertexPointer_(size, type, stride, pointer);
        }
        #endregion

        #region glTexSubImage1D
        public static void glTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, object pixels)
        {
            GCHandle h0 = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glTexSubImage1D_(target, level, xoffset, width, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, IntPtr pixels)
        {
            glTexSubImage1D_(target, level, xoffset, width, format, type, pixels);
        }
        #endregion

        #region glTexSubImage2D
        public static void glTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, object pixels)
        {
            GCHandle h0 = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glTexSubImage2D_(target, level, xoffset, yoffset, width, height, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels)
        {
            glTexSubImage2D_(target, level, xoffset, yoffset, width, height, format, type, pixels);
        }
        #endregion

        #region glAreTexturesResident
        public static GLboolean glAreTexturesResident(GLsizei n, object textures, [MarshalAs(UnmanagedType.LPArray)] GLboolean[] residences)
        {
            GCHandle h0 = GCHandle.Alloc(textures, GCHandleType.Pinned);
            try
            {
                return glAreTexturesResident_(n, h0.AddrOfPinnedObject(), residences);
            }
            finally
            {
                h0.Free();
            }
        }
        public static GLboolean glAreTexturesResident(GLsizei n, IntPtr textures, [MarshalAs(UnmanagedType.LPArray)] GLboolean[] residences)
        {
            return glAreTexturesResident_(n, textures, residences);
        }
        public static GLboolean glAreTexturesResident(GLsizei n, GLuint[] textures, [MarshalAs(UnmanagedType.LPArray)] GLboolean[] residences)
        {
            GCHandle h0 = GCHandle.Alloc(textures, GCHandleType.Pinned);
            try
            {
                return glAreTexturesResident_(n, h0.AddrOfPinnedObject(), residences);
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glDeleteTextures
        public static void glDeleteTextures(GLsizei n, object textures)
        {
            GCHandle h0 = GCHandle.Alloc(textures, GCHandleType.Pinned);
            try
            {
                glDeleteTextures_(n, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glDeleteTextures(GLsizei n, IntPtr textures)
        {
            glDeleteTextures_(n, textures);
        }
        public static void glDeleteTextures(GLsizei n, GLuint[] textures)
        {
            GCHandle h0 = GCHandle.Alloc(textures, GCHandleType.Pinned);
            try
            {
                glDeleteTextures_(n, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glPrioritizeTextures
        public static void glPrioritizeTextures(GLsizei n, object textures, object priorities)
        {
            GCHandle h0 = GCHandle.Alloc(textures, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(priorities, GCHandleType.Pinned);
            try
            {
                glPrioritizeTextures_(n, h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject());
            }
            finally
            {
                h1.Free();
                h0.Free();
            }
        }
        public static void glPrioritizeTextures(GLsizei n, IntPtr textures, IntPtr priorities)
        {
            glPrioritizeTextures_(n, textures, priorities);
        }
        public static void glPrioritizeTextures(GLsizei n, GLuint[] textures, GLclampf[] priorities)
        {
            GCHandle h0 = GCHandle.Alloc(textures, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(priorities, GCHandleType.Pinned);
            try
            {
                glPrioritizeTextures_(n, h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject());
            }
            finally
            {
                h1.Free();
                h0.Free();
            }
        }
        #endregion

        #region glIndexubv
        public static void glIndexubv(object c)
        {
            GCHandle h0 = GCHandle.Alloc(c, GCHandleType.Pinned);
            try
            {
                glIndexubv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glIndexubv(IntPtr c)
        {
            glIndexubv_(c);
        }
        public static void glIndexubv(GLubyte[] c)
        {
            GCHandle h0 = GCHandle.Alloc(c, GCHandleType.Pinned);
            try
            {
                glIndexubv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glDrawRangeElements
        public static void glDrawRangeElements(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, object indices)
        {
            GCHandle h0 = GCHandle.Alloc(indices, GCHandleType.Pinned);
            try
            {
                glDrawRangeElements_(mode, start, end, count, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glDrawRangeElements(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, IntPtr indices)
        {
            glDrawRangeElements_(mode, start, end, count, type, indices);
        }
        #endregion

        #region glColorTable
        public static void glColorTable(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, object table)
        {
            GCHandle h0 = GCHandle.Alloc(table, GCHandleType.Pinned);
            try
            {
                glColorTable_(target, internalformat, width, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColorTable(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr table)
        {
            glColorTable_(target, internalformat, width, format, type, table);
        }
        #endregion

        #region glColorTableParameterfv
        public static void glColorTableParameterfv(GLenum target, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glColorTableParameterfv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColorTableParameterfv(GLenum target, GLenum pname, IntPtr parameters)
        {
            glColorTableParameterfv_(target, pname, parameters);
        }
        public static void glColorTableParameterfv(GLenum target, GLenum pname, GLfloat[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glColorTableParameterfv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glColorTableParameteriv
        public static void glColorTableParameteriv(GLenum target, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glColorTableParameteriv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColorTableParameteriv(GLenum target, GLenum pname, IntPtr parameters)
        {
            glColorTableParameteriv_(target, pname, parameters);
        }
        public static void glColorTableParameteriv(GLenum target, GLenum pname, GLint[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glColorTableParameteriv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glGetColorTable
        public static void glGetColorTable(GLenum target, GLenum format, GLenum type, object table)
        {
            GCHandle h0 = GCHandle.Alloc(table, GCHandleType.Pinned);
            try
            {
                glGetColorTable_(target, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glGetColorTable(GLenum target, GLenum format, GLenum type, IntPtr table)
        {
            glGetColorTable_(target, format, type, table);
        }
        #endregion

        #region glColorSubTable
        public static void glColorSubTable(GLenum target, GLsizei start, GLsizei count, GLenum format, GLenum type, object data)
        {
            GCHandle h0 = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glColorSubTable_(target, start, count, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glColorSubTable(GLenum target, GLsizei start, GLsizei count, GLenum format, GLenum type, IntPtr data)
        {
            glColorSubTable_(target, start, count, format, type, data);
        }
        #endregion

        #region glConvolutionFilter1D
        public static void glConvolutionFilter1D(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, object image)
        {
            GCHandle h0 = GCHandle.Alloc(image, GCHandleType.Pinned);
            try
            {
                glConvolutionFilter1D_(target, internalformat, width, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glConvolutionFilter1D(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, IntPtr image)
        {
            glConvolutionFilter1D_(target, internalformat, width, format, type, image);
        }
        #endregion

        #region glConvolutionFilter2D
        public static void glConvolutionFilter2D(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, object image)
        {
            GCHandle h0 = GCHandle.Alloc(image, GCHandleType.Pinned);
            try
            {
                glConvolutionFilter2D_(target, internalformat, width, height, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glConvolutionFilter2D(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr image)
        {
            glConvolutionFilter2D_(target, internalformat, width, height, format, type, image);
        }
        #endregion

        #region glConvolutionParameterfv
        public static void glConvolutionParameterfv(GLenum target, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glConvolutionParameterfv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glConvolutionParameterfv(GLenum target, GLenum pname, IntPtr parameters)
        {
            glConvolutionParameterfv_(target, pname, parameters);
        }
        public static void glConvolutionParameterfv(GLenum target, GLenum pname, GLfloat[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glConvolutionParameterfv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glConvolutionParameteriv
        public static void glConvolutionParameteriv(GLenum target, GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glConvolutionParameteriv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glConvolutionParameteriv(GLenum target, GLenum pname, IntPtr parameters)
        {
            glConvolutionParameteriv_(target, pname, parameters);
        }
        public static void glConvolutionParameteriv(GLenum target, GLenum pname, GLint[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glConvolutionParameteriv_(target, pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glGetConvolutionFilter
        public static void glGetConvolutionFilter(GLenum target, GLenum format, GLenum type, object image)
        {
            GCHandle h0 = GCHandle.Alloc(image, GCHandleType.Pinned);
            try
            {
                glGetConvolutionFilter_(target, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glGetConvolutionFilter(GLenum target, GLenum format, GLenum type, IntPtr image)
        {
            glGetConvolutionFilter_(target, format, type, image);
        }
        #endregion

        #region glGetSeparableFilter
        public static void glGetSeparableFilter(GLenum target, GLenum format, GLenum type, object row, object column, object span)
        {
            GCHandle h0 = GCHandle.Alloc(row, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(column, GCHandleType.Pinned);
            GCHandle h2 = GCHandle.Alloc(span, GCHandleType.Pinned);
            try
            {
                glGetSeparableFilter_(target, format, type, h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject(), h2.AddrOfPinnedObject());
            }
            finally
            {
                h2.Free();
                h1.Free();
                h0.Free();
            }
        }
        public static void glGetSeparableFilter(GLenum target, GLenum format, GLenum type, IntPtr row, IntPtr column, IntPtr span)
        {
            glGetSeparableFilter_(target, format, type, row, column, span);
        }
        #endregion

        #region glSeparableFilter2D
        public static void glSeparableFilter2D(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, object row, object column)
        {
            GCHandle h0 = GCHandle.Alloc(row, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(column, GCHandleType.Pinned);
            try
            {
                glSeparableFilter2D_(target, internalformat, width, height, format, type, h0.AddrOfPinnedObject(), h1.AddrOfPinnedObject());
            }
            finally
            {
                h1.Free();
                h0.Free();
            }
        }
        public static void glSeparableFilter2D(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr row, IntPtr column)
        {
            glSeparableFilter2D_(target, internalformat, width, height, format, type, row, column);
        }
        #endregion

        #region glGetHistogram
        public static void glGetHistogram(GLenum target, GLboolean reset, GLenum format, GLenum type, object values)
        {
            GCHandle h0 = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                glGetHistogram_(target, reset, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glGetHistogram(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values)
        {
            glGetHistogram_(target, reset, format, type, values);
        }
        #endregion

        #region glGetMinmax
        public static void glGetMinmax(GLenum target, GLboolean reset, GLenum format, GLenum type, object values)
        {
            GCHandle h0 = GCHandle.Alloc(values, GCHandleType.Pinned);
            try
            {
                glGetMinmax_(target, reset, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glGetMinmax(GLenum target, GLboolean reset, GLenum format, GLenum type, IntPtr values)
        {
            glGetMinmax_(target, reset, format, type, values);
        }
        #endregion

        #region glTexImage3D
        public static void glTexImage3D(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, object pixels)
        {
            GCHandle h0 = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glTexImage3D_(target, level, internalformat, width, height, depth, border, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexImage3D(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, IntPtr pixels)
        {
            glTexImage3D_(target, level, internalformat, width, height, depth, border, format, type, pixels);
        }
        #endregion

        #region glTexSubImage3D
        public static void glTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, object pixels)
        {
            GCHandle h0 = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glTexSubImage3D_(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr pixels)
        {
            glTexSubImage3D_(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
        }
        #endregion

        #region glMultiTexCoord1dv
        public static void glMultiTexCoord1dv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord1dv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord1dv(GLenum target, IntPtr v)
        {
            glMultiTexCoord1dv_(target, v);
        }
        public static void glMultiTexCoord1dv(GLenum target, GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord1dv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord1fv
        public static void glMultiTexCoord1fv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord1fv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord1fv(GLenum target, IntPtr v)
        {
            glMultiTexCoord1fv_(target, v);
        }
        public static void glMultiTexCoord1fv(GLenum target, GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord1fv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord1iv
        public static void glMultiTexCoord1iv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord1iv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord1iv(GLenum target, IntPtr v)
        {
            glMultiTexCoord1iv_(target, v);
        }
        public static void glMultiTexCoord1iv(GLenum target, GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord1iv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord1sv
        public static void glMultiTexCoord1sv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord1sv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord1sv(GLenum target, IntPtr v)
        {
            glMultiTexCoord1sv_(target, v);
        }
        public static void glMultiTexCoord1sv(GLenum target, GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord1sv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord2dv
        public static void glMultiTexCoord2dv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord2dv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord2dv(GLenum target, IntPtr v)
        {
            glMultiTexCoord2dv_(target, v);
        }
        public static void glMultiTexCoord2dv(GLenum target, GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord2dv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord2fv
        public static void glMultiTexCoord2fv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord2fv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord2fv(GLenum target, IntPtr v)
        {
            glMultiTexCoord2fv_(target, v);
        }
        public static void glMultiTexCoord2fv(GLenum target, GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord2fv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord2iv
        public static void glMultiTexCoord2iv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord2iv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord2iv(GLenum target, IntPtr v)
        {
            glMultiTexCoord2iv_(target, v);
        }
        public static void glMultiTexCoord2iv(GLenum target, GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord2iv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord2sv
        public static void glMultiTexCoord2sv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord2sv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord2sv(GLenum target, IntPtr v)
        {
            glMultiTexCoord2sv_(target, v);
        }
        public static void glMultiTexCoord2sv(GLenum target, GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord2sv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord3dv
        public static void glMultiTexCoord3dv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord3dv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord3dv(GLenum target, IntPtr v)
        {
            glMultiTexCoord3dv_(target, v);
        }
        public static void glMultiTexCoord3dv(GLenum target, GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord3dv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord3fv
        public static void glMultiTexCoord3fv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord3fv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord3fv(GLenum target, IntPtr v)
        {
            glMultiTexCoord3fv_(target, v);
        }
        public static void glMultiTexCoord3fv(GLenum target, GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord3fv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord3iv
        public static void glMultiTexCoord3iv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord3iv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord3iv(GLenum target, IntPtr v)
        {
            glMultiTexCoord3iv_(target, v);
        }
        public static void glMultiTexCoord3iv(GLenum target, GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord3iv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord3sv
        public static void glMultiTexCoord3sv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord3sv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord3sv(GLenum target, IntPtr v)
        {
            glMultiTexCoord3sv_(target, v);
        }
        public static void glMultiTexCoord3sv(GLenum target, GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord3sv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord4dv
        public static void glMultiTexCoord4dv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord4dv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord4dv(GLenum target, IntPtr v)
        {
            glMultiTexCoord4dv_(target, v);
        }
        public static void glMultiTexCoord4dv(GLenum target, GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord4dv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord4fv
        public static void glMultiTexCoord4fv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord4fv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord4fv(GLenum target, IntPtr v)
        {
            glMultiTexCoord4fv_(target, v);
        }
        public static void glMultiTexCoord4fv(GLenum target, GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord4fv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord4iv
        public static void glMultiTexCoord4iv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord4iv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord4iv(GLenum target, IntPtr v)
        {
            glMultiTexCoord4iv_(target, v);
        }
        public static void glMultiTexCoord4iv(GLenum target, GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord4iv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultiTexCoord4sv
        public static void glMultiTexCoord4sv(GLenum target, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord4sv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultiTexCoord4sv(GLenum target, IntPtr v)
        {
            glMultiTexCoord4sv_(target, v);
        }
        public static void glMultiTexCoord4sv(GLenum target, GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glMultiTexCoord4sv_(target, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glLoadTransposeMatrixf
        public static void glLoadTransposeMatrixf(object m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glLoadTransposeMatrixf_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glLoadTransposeMatrixf(IntPtr m)
        {
            glLoadTransposeMatrixf_(m);
        }
        public static void glLoadTransposeMatrixf(GLfloat[] m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glLoadTransposeMatrixf_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glLoadTransposeMatrixd
        public static void glLoadTransposeMatrixd(object m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glLoadTransposeMatrixd_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glLoadTransposeMatrixd(IntPtr m)
        {
            glLoadTransposeMatrixd_(m);
        }
        public static void glLoadTransposeMatrixd(GLdouble[] m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glLoadTransposeMatrixd_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultTransposeMatrixf
        public static void glMultTransposeMatrixf(object m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glMultTransposeMatrixf_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultTransposeMatrixf(IntPtr m)
        {
            glMultTransposeMatrixf_(m);
        }
        public static void glMultTransposeMatrixf(GLfloat[] m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glMultTransposeMatrixf_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glMultTransposeMatrixd
        public static void glMultTransposeMatrixd(object m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glMultTransposeMatrixd_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glMultTransposeMatrixd(IntPtr m)
        {
            glMultTransposeMatrixd_(m);
        }
        public static void glMultTransposeMatrixd(GLdouble[] m)
        {
            GCHandle h0 = GCHandle.Alloc(m, GCHandleType.Pinned);
            try
            {
                glMultTransposeMatrixd_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glCompressedTexImage3D
        public static void glCompressedTexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, object data)
        {
            GCHandle h0 = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glCompressedTexImage3D_(target, level, internalformat, width, height, depth, border, imageSize, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glCompressedTexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, IntPtr data)
        {
            glCompressedTexImage3D_(target, level, internalformat, width, height, depth, border, imageSize, data);
        }
        #endregion

        #region glCompressedTexImage2D
        public static void glCompressedTexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, object data)
        {
            GCHandle h0 = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glCompressedTexImage2D_(target, level, internalformat, width, height, border, imageSize, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glCompressedTexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, IntPtr data)
        {
            glCompressedTexImage2D_(target, level, internalformat, width, height, border, imageSize, data);
        }
        #endregion

        #region glCompressedTexImage1D
        public static void glCompressedTexImage1D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, object data)
        {
            GCHandle h0 = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glCompressedTexImage1D_(target, level, internalformat, width, border, imageSize, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glCompressedTexImage1D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, IntPtr data)
        {
            glCompressedTexImage1D_(target, level, internalformat, width, border, imageSize, data);
        }
        #endregion

        #region glCompressedTexSubImage3D
        public static void glCompressedTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, object data)
        {
            GCHandle h0 = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glCompressedTexSubImage3D_(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glCompressedTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, IntPtr data)
        {
            glCompressedTexSubImage3D_(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
        }
        #endregion

        #region glCompressedTexSubImage2D
        public static void glCompressedTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, object data)
        {
            GCHandle h0 = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glCompressedTexSubImage2D_(target, level, xoffset, yoffset, width, height, format, imageSize, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glCompressedTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, IntPtr data)
        {
            glCompressedTexSubImage2D_(target, level, xoffset, yoffset, width, height, format, imageSize, data);
        }
        #endregion

        #region glCompressedTexSubImage1D
        public static void glCompressedTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, object data)
        {
            GCHandle h0 = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glCompressedTexSubImage1D_(target, level, xoffset, width, format, imageSize, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glCompressedTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, IntPtr data)
        {
            glCompressedTexSubImage1D_(target, level, xoffset, width, format, imageSize, data);
        }
        #endregion

        #region glGetCompressedTexImage
        public static void glGetCompressedTexImage(GLenum target, GLint level, object img)
        {
            GCHandle h0 = GCHandle.Alloc(img, GCHandleType.Pinned);
            try
            {
                glGetCompressedTexImage_(target, level, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glGetCompressedTexImage(GLenum target, GLint level, IntPtr img)
        {
            glGetCompressedTexImage_(target, level, img);
        }
        #endregion

        #region glFogCoordfv
        public static void glFogCoordfv(object coord)
        {
            GCHandle h0 = GCHandle.Alloc(coord, GCHandleType.Pinned);
            try
            {
                glFogCoordfv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glFogCoordfv(IntPtr coord)
        {
            glFogCoordfv_(coord);
        }
        public static void glFogCoordfv(GLfloat[] coord)
        {
            GCHandle h0 = GCHandle.Alloc(coord, GCHandleType.Pinned);
            try
            {
                glFogCoordfv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glFogCoorddv
        public static void glFogCoorddv(object coord)
        {
            GCHandle h0 = GCHandle.Alloc(coord, GCHandleType.Pinned);
            try
            {
                glFogCoorddv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glFogCoorddv(IntPtr coord)
        {
            glFogCoorddv_(coord);
        }
        public static void glFogCoorddv(GLdouble[] coord)
        {
            GCHandle h0 = GCHandle.Alloc(coord, GCHandleType.Pinned);
            try
            {
                glFogCoorddv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glFogCoordPointer
        public static void glFogCoordPointer(GLenum type, GLsizei stride, object pointer)
        {
            GCHandle h0 = GCHandle.Alloc(pointer, GCHandleType.Pinned);
            try
            {
                glFogCoordPointer_(type, stride, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glFogCoordPointer(GLenum type, GLsizei stride, IntPtr pointer)
        {
            glFogCoordPointer_(type, stride, pointer);
        }
        #endregion

        #region glMultiDrawElements
        public static void glMultiDrawElements(GLenum mode, object count, GLenum type, object indices, GLsizei primcount)
        {
            GCHandle h0 = GCHandle.Alloc(count, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(indices, GCHandleType.Pinned);
            try
            {
                glMultiDrawElements_(mode, h0.AddrOfPinnedObject(), type, h1.AddrOfPinnedObject(), primcount);
            }
            finally
            {
                h1.Free();
                h0.Free();
            }
        }
        public static void glMultiDrawElements(GLenum mode, IntPtr count, GLenum type, IntPtr indices, GLsizei primcount)
        {
            glMultiDrawElements_(mode, count, type, indices, primcount);
        }
        public static void glMultiDrawElements(GLenum mode, GLsizei[] count, GLenum type, IntPtr[] indices, GLsizei primcount)
        {
            GCHandle h0 = GCHandle.Alloc(count, GCHandleType.Pinned);
            GCHandle h1 = GCHandle.Alloc(indices, GCHandleType.Pinned);
            try
            {
                glMultiDrawElements_(mode, h0.AddrOfPinnedObject(), type, h1.AddrOfPinnedObject(), primcount);
            }
            finally
            {
                h1.Free();
                h0.Free();
            }
        }
        #endregion

        #region glPointParameterfv
        public static void glPointParameterfv(GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glPointParameterfv_(pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glPointParameterfv(GLenum pname, IntPtr parameters)
        {
            glPointParameterfv_(pname, parameters);
        }
        public static void glPointParameterfv(GLenum pname, GLfloat[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glPointParameterfv_(pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glPointParameteriv
        public static void glPointParameteriv(GLenum pname, object parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glPointParameteriv_(pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glPointParameteriv(GLenum pname, IntPtr parameters)
        {
            glPointParameteriv_(pname, parameters);
        }
        public static void glPointParameteriv(GLenum pname, GLint[] parameters)
        {
            GCHandle h0 = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            try
            {
                glPointParameteriv_(pname, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glSecondaryColor3bv
        public static void glSecondaryColor3bv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3bv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glSecondaryColor3bv(IntPtr v)
        {
            glSecondaryColor3bv_(v);
        }
        public static void glSecondaryColor3bv(GLbyte[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3bv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glSecondaryColor3dv
        public static void glSecondaryColor3dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glSecondaryColor3dv(IntPtr v)
        {
            glSecondaryColor3dv_(v);
        }
        public static void glSecondaryColor3dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glSecondaryColor3fv
        public static void glSecondaryColor3fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glSecondaryColor3fv(IntPtr v)
        {
            glSecondaryColor3fv_(v);
        }
        public static void glSecondaryColor3fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glSecondaryColor3iv
        public static void glSecondaryColor3iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glSecondaryColor3iv(IntPtr v)
        {
            glSecondaryColor3iv_(v);
        }
        public static void glSecondaryColor3iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glSecondaryColor3sv
        public static void glSecondaryColor3sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glSecondaryColor3sv(IntPtr v)
        {
            glSecondaryColor3sv_(v);
        }
        public static void glSecondaryColor3sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glSecondaryColor3ubv
        public static void glSecondaryColor3ubv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3ubv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glSecondaryColor3ubv(IntPtr v)
        {
            glSecondaryColor3ubv_(v);
        }
        public static void glSecondaryColor3ubv(GLubyte[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3ubv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glSecondaryColor3uiv
        public static void glSecondaryColor3uiv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3uiv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glSecondaryColor3uiv(IntPtr v)
        {
            glSecondaryColor3uiv_(v);
        }
        public static void glSecondaryColor3uiv(GLuint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3uiv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glSecondaryColor3usv
        public static void glSecondaryColor3usv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3usv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glSecondaryColor3usv(IntPtr v)
        {
            glSecondaryColor3usv_(v);
        }
        public static void glSecondaryColor3usv(GLushort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glSecondaryColor3usv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glSecondaryColorPointer
        public static void glSecondaryColorPointer(GLint size, GLenum type, GLsizei stride, object pointer)
        {
            GCHandle h0 = GCHandle.Alloc(pointer, GCHandleType.Pinned);
            try
            {
                glSecondaryColorPointer_(size, type, stride, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glSecondaryColorPointer(GLint size, GLenum type, GLsizei stride, IntPtr pointer)
        {
            glSecondaryColorPointer_(size, type, stride, pointer);
        }
        #endregion

        #region glWindowPos2dv
        public static void glWindowPos2dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos2dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glWindowPos2dv(IntPtr v)
        {
            glWindowPos2dv_(v);
        }
        public static void glWindowPos2dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos2dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glWindowPos2fv
        public static void glWindowPos2fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos2fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glWindowPos2fv(IntPtr v)
        {
            glWindowPos2fv_(v);
        }
        public static void glWindowPos2fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos2fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glWindowPos2iv
        public static void glWindowPos2iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos2iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glWindowPos2iv(IntPtr v)
        {
            glWindowPos2iv_(v);
        }
        public static void glWindowPos2iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos2iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glWindowPos2sv
        public static void glWindowPos2sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos2sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glWindowPos2sv(IntPtr v)
        {
            glWindowPos2sv_(v);
        }
        public static void glWindowPos2sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos2sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glWindowPos3dv
        public static void glWindowPos3dv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glWindowPos3dv(IntPtr v)
        {
            glWindowPos3dv_(v);
        }
        public static void glWindowPos3dv(GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos3dv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glWindowPos3fv
        public static void glWindowPos3fv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glWindowPos3fv(IntPtr v)
        {
            glWindowPos3fv_(v);
        }
        public static void glWindowPos3fv(GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos3fv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glWindowPos3iv
        public static void glWindowPos3iv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glWindowPos3iv(IntPtr v)
        {
            glWindowPos3iv_(v);
        }
        public static void glWindowPos3iv(GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos3iv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glWindowPos3sv
        public static void glWindowPos3sv(object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glWindowPos3sv(IntPtr v)
        {
            glWindowPos3sv_(v);
        }
        public static void glWindowPos3sv(GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glWindowPos3sv_(h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glDeleteQueries
        public static void glDeleteQueries(GLsizei n, object ids)
        {
            GCHandle h0 = GCHandle.Alloc(ids, GCHandleType.Pinned);
            try
            {
                glDeleteQueries_(n, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glDeleteQueries(GLsizei n, IntPtr ids)
        {
            glDeleteQueries_(n, ids);
        }
        public static void glDeleteQueries(GLsizei n, GLuint[] ids)
        {
            GCHandle h0 = GCHandle.Alloc(ids, GCHandleType.Pinned);
            try
            {
                glDeleteQueries_(n, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glDeleteBuffers
        public static void glDeleteBuffers(GLsizei n, object buffers)
        {
            GCHandle h0 = GCHandle.Alloc(buffers, GCHandleType.Pinned);
            try
            {
                glDeleteBuffers_(n, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glDeleteBuffers(GLsizei n, IntPtr buffers)
        {
            glDeleteBuffers_(n, buffers);
        }
        public static void glDeleteBuffers(GLsizei n, GLuint[] buffers)
        {
            GCHandle h0 = GCHandle.Alloc(buffers, GCHandleType.Pinned);
            try
            {
                glDeleteBuffers_(n, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glBufferData
        public static void glBufferData(GLenum target, GLsizeiptr size, object data, GLenum usage)
        {
            GCHandle h0 = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glBufferData_(target, size, h0.AddrOfPinnedObject(), usage);
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glBufferData(GLenum target, GLsizeiptr size, IntPtr data, GLenum usage)
        {
            glBufferData_(target, size, data, usage);
        }
        #endregion

        #region glBufferSubData
        public static void glBufferSubData(GLenum target, GLintptr offset, GLsizeiptr size, object data)
        {
            GCHandle h0 = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glBufferSubData_(target, offset, size, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glBufferSubData(GLenum target, GLintptr offset, GLsizeiptr size, IntPtr data)
        {
            glBufferSubData_(target, offset, size, data);
        }
        #endregion

        #region glGetBufferSubData
        public static void glGetBufferSubData(GLenum target, GLintptr offset, GLsizeiptr size, object data)
        {
            GCHandle h0 = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glGetBufferSubData_(target, offset, size, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glGetBufferSubData(GLenum target, GLintptr offset, GLsizeiptr size, IntPtr data)
        {
            glGetBufferSubData_(target, offset, size, data);
        }
        #endregion

        #region glDrawBuffers
        public static void glDrawBuffers(GLsizei n, object bufs)
        {
            GCHandle h0 = GCHandle.Alloc(bufs, GCHandleType.Pinned);
            try
            {
                glDrawBuffers_(n, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glDrawBuffers(GLsizei n, IntPtr bufs)
        {
            glDrawBuffers_(n, bufs);
        }
        public static void glDrawBuffers(GLsizei n, GLenum[] bufs)
        {
            GCHandle h0 = GCHandle.Alloc(bufs, GCHandleType.Pinned);
            try
            {
                glDrawBuffers_(n, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glBindAttribLocation
        public static void glBindAttribLocation(GLuint program, GLuint index, object name)
        {
            GCHandle h0 = GCHandle.Alloc(name, GCHandleType.Pinned);
            try
            {
                glBindAttribLocation_(program, index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glBindAttribLocation(GLuint program, GLuint index, IntPtr name)
        {
            glBindAttribLocation_(program, index, name);
        }
        public static void glBindAttribLocation(GLuint program, GLuint index, GLchar[] name)
        {
            GCHandle h0 = GCHandle.Alloc(name, GCHandleType.Pinned);
            try
            {
                glBindAttribLocation_(program, index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glGetAttribLocation
        public static GLint glGetAttribLocation(GLuint program, object name)
        {
            GCHandle h0 = GCHandle.Alloc(name, GCHandleType.Pinned);
            try
            {
                return glGetAttribLocation_(program, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static GLint glGetAttribLocation(GLuint program, IntPtr name)
        {
            return glGetAttribLocation_(program, name);
        }
        public static GLint glGetAttribLocation(GLuint program, GLchar[] name)
        {
            GCHandle h0 = GCHandle.Alloc(name, GCHandleType.Pinned);
            try
            {
                return glGetAttribLocation_(program, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glGetUniformLocation
        public static GLint glGetUniformLocation(GLuint program, object name)
        {
            GCHandle h0 = GCHandle.Alloc(name, GCHandleType.Pinned);
            try
            {
                return glGetUniformLocation_(program, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static GLint glGetUniformLocation(GLuint program, IntPtr name)
        {
            return glGetUniformLocation_(program, name);
        }
        public static GLint glGetUniformLocation(GLuint program, GLchar[] name)
        {
            GCHandle h0 = GCHandle.Alloc(name, GCHandleType.Pinned);
            try
            {
                return glGetUniformLocation_(program, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glShaderSource
        public static void glShaderSource(GLuint shader, GLsizei count, string[] @string, object length)
        {
            GCHandle h0 = GCHandle.Alloc(length, GCHandleType.Pinned);
            try
            {
                glShaderSource_(shader, count, @string, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glShaderSource(GLuint shader, GLsizei count, string[] @string, IntPtr length)
        {
            glShaderSource_(shader, count, @string, length);
        }
        public static void glShaderSource(GLuint shader, GLsizei count, string[] @string, GLint[] length)
        {
            GCHandle h0 = GCHandle.Alloc(length, GCHandleType.Pinned);
            try
            {
                glShaderSource_(shader, count, @string, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glUniform1fv
        public static void glUniform1fv(GLint location, GLsizei count, object value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform1fv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glUniform1fv(GLint location, GLsizei count, IntPtr value)
        {
            glUniform1fv_(location, count, value);
        }
        public static void glUniform1fv(GLint location, GLsizei count, GLfloat[] value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform1fv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glUniform2fv
        public static void glUniform2fv(GLint location, GLsizei count, object value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform2fv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glUniform2fv(GLint location, GLsizei count, IntPtr value)
        {
            glUniform2fv_(location, count, value);
        }
        public static void glUniform2fv(GLint location, GLsizei count, GLfloat[] value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform2fv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glUniform3fv
        public static void glUniform3fv(GLint location, GLsizei count, object value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform3fv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glUniform3fv(GLint location, GLsizei count, IntPtr value)
        {
            glUniform3fv_(location, count, value);
        }
        public static void glUniform3fv(GLint location, GLsizei count, GLfloat[] value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform3fv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glUniform4fv
        public static void glUniform4fv(GLint location, GLsizei count, object value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform4fv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glUniform4fv(GLint location, GLsizei count, IntPtr value)
        {
            glUniform4fv_(location, count, value);
        }
        public static void glUniform4fv(GLint location, GLsizei count, GLfloat[] value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform4fv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glUniform1iv
        public static void glUniform1iv(GLint location, GLsizei count, object value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform1iv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glUniform1iv(GLint location, GLsizei count, IntPtr value)
        {
            glUniform1iv_(location, count, value);
        }
        public static void glUniform1iv(GLint location, GLsizei count, GLint[] value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform1iv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glUniform2iv
        public static void glUniform2iv(GLint location, GLsizei count, object value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform2iv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glUniform2iv(GLint location, GLsizei count, IntPtr value)
        {
            glUniform2iv_(location, count, value);
        }
        public static void glUniform2iv(GLint location, GLsizei count, GLint[] value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform2iv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glUniform3iv
        public static void glUniform3iv(GLint location, GLsizei count, object value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform3iv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glUniform3iv(GLint location, GLsizei count, IntPtr value)
        {
            glUniform3iv_(location, count, value);
        }
        public static void glUniform3iv(GLint location, GLsizei count, GLint[] value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform3iv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glUniform4iv
        public static void glUniform4iv(GLint location, GLsizei count, object value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform4iv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glUniform4iv(GLint location, GLsizei count, IntPtr value)
        {
            glUniform4iv_(location, count, value);
        }
        public static void glUniform4iv(GLint location, GLsizei count, GLint[] value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniform4iv_(location, count, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glUniformMatrix2fv
        public static void glUniformMatrix2fv(GLint location, GLsizei count, GLboolean transpose, object value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniformMatrix2fv_(location, count, transpose, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glUniformMatrix2fv(GLint location, GLsizei count, GLboolean transpose, IntPtr value)
        {
            glUniformMatrix2fv_(location, count, transpose, value);
        }
        public static void glUniformMatrix2fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniformMatrix2fv_(location, count, transpose, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glUniformMatrix3fv
        public static void glUniformMatrix3fv(GLint location, GLsizei count, GLboolean transpose, object value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniformMatrix3fv_(location, count, transpose, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glUniformMatrix3fv(GLint location, GLsizei count, GLboolean transpose, IntPtr value)
        {
            glUniformMatrix3fv_(location, count, transpose, value);
        }
        public static void glUniformMatrix3fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniformMatrix3fv_(location, count, transpose, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glUniformMatrix4fv
        public static void glUniformMatrix4fv(GLint location, GLsizei count, GLboolean transpose, object value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniformMatrix4fv_(location, count, transpose, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glUniformMatrix4fv(GLint location, GLsizei count, GLboolean transpose, IntPtr value)
        {
            glUniformMatrix4fv_(location, count, transpose, value);
        }
        public static void glUniformMatrix4fv(GLint location, GLsizei count, GLboolean transpose, GLfloat[] value)
        {
            GCHandle h0 = GCHandle.Alloc(value, GCHandleType.Pinned);
            try
            {
                glUniformMatrix4fv_(location, count, transpose, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib1dv
        public static void glVertexAttrib1dv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib1dv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib1dv(GLuint index, IntPtr v)
        {
            glVertexAttrib1dv_(index, v);
        }
        public static void glVertexAttrib1dv(GLuint index, GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib1dv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib1fv
        public static void glVertexAttrib1fv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib1fv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib1fv(GLuint index, IntPtr v)
        {
            glVertexAttrib1fv_(index, v);
        }
        public static void glVertexAttrib1fv(GLuint index, GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib1fv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib1sv
        public static void glVertexAttrib1sv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib1sv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib1sv(GLuint index, IntPtr v)
        {
            glVertexAttrib1sv_(index, v);
        }
        public static void glVertexAttrib1sv(GLuint index, GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib1sv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib2dv
        public static void glVertexAttrib2dv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib2dv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib2dv(GLuint index, IntPtr v)
        {
            glVertexAttrib2dv_(index, v);
        }
        public static void glVertexAttrib2dv(GLuint index, GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib2dv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib2fv
        public static void glVertexAttrib2fv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib2fv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib2fv(GLuint index, IntPtr v)
        {
            glVertexAttrib2fv_(index, v);
        }
        public static void glVertexAttrib2fv(GLuint index, GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib2fv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib2sv
        public static void glVertexAttrib2sv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib2sv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib2sv(GLuint index, IntPtr v)
        {
            glVertexAttrib2sv_(index, v);
        }
        public static void glVertexAttrib2sv(GLuint index, GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib2sv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib3dv
        public static void glVertexAttrib3dv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib3dv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib3dv(GLuint index, IntPtr v)
        {
            glVertexAttrib3dv_(index, v);
        }
        public static void glVertexAttrib3dv(GLuint index, GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib3dv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib3fv
        public static void glVertexAttrib3fv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib3fv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib3fv(GLuint index, IntPtr v)
        {
            glVertexAttrib3fv_(index, v);
        }
        public static void glVertexAttrib3fv(GLuint index, GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib3fv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib3sv
        public static void glVertexAttrib3sv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib3sv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib3sv(GLuint index, IntPtr v)
        {
            glVertexAttrib3sv_(index, v);
        }
        public static void glVertexAttrib3sv(GLuint index, GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib3sv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4Nbv
        public static void glVertexAttrib4Nbv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4Nbv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4Nbv(GLuint index, IntPtr v)
        {
            glVertexAttrib4Nbv_(index, v);
        }
        public static void glVertexAttrib4Nbv(GLuint index, GLbyte[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4Nbv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4Niv
        public static void glVertexAttrib4Niv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4Niv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4Niv(GLuint index, IntPtr v)
        {
            glVertexAttrib4Niv_(index, v);
        }
        public static void glVertexAttrib4Niv(GLuint index, GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4Niv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4Nsv
        public static void glVertexAttrib4Nsv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4Nsv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4Nsv(GLuint index, IntPtr v)
        {
            glVertexAttrib4Nsv_(index, v);
        }
        public static void glVertexAttrib4Nsv(GLuint index, GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4Nsv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4Nubv
        public static void glVertexAttrib4Nubv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4Nubv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4Nubv(GLuint index, IntPtr v)
        {
            glVertexAttrib4Nubv_(index, v);
        }
        public static void glVertexAttrib4Nubv(GLuint index, GLubyte[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4Nubv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4Nuiv
        public static void glVertexAttrib4Nuiv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4Nuiv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4Nuiv(GLuint index, IntPtr v)
        {
            glVertexAttrib4Nuiv_(index, v);
        }
        public static void glVertexAttrib4Nuiv(GLuint index, GLuint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4Nuiv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4Nusv
        public static void glVertexAttrib4Nusv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4Nusv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4Nusv(GLuint index, IntPtr v)
        {
            glVertexAttrib4Nusv_(index, v);
        }
        public static void glVertexAttrib4Nusv(GLuint index, GLushort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4Nusv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4bv
        public static void glVertexAttrib4bv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4bv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4bv(GLuint index, IntPtr v)
        {
            glVertexAttrib4bv_(index, v);
        }
        public static void glVertexAttrib4bv(GLuint index, GLbyte[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4bv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4dv
        public static void glVertexAttrib4dv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4dv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4dv(GLuint index, IntPtr v)
        {
            glVertexAttrib4dv_(index, v);
        }
        public static void glVertexAttrib4dv(GLuint index, GLdouble[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4dv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4fv
        public static void glVertexAttrib4fv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4fv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4fv(GLuint index, IntPtr v)
        {
            glVertexAttrib4fv_(index, v);
        }
        public static void glVertexAttrib4fv(GLuint index, GLfloat[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4fv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4iv
        public static void glVertexAttrib4iv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4iv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4iv(GLuint index, IntPtr v)
        {
            glVertexAttrib4iv_(index, v);
        }
        public static void glVertexAttrib4iv(GLuint index, GLint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4iv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4sv
        public static void glVertexAttrib4sv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4sv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4sv(GLuint index, IntPtr v)
        {
            glVertexAttrib4sv_(index, v);
        }
        public static void glVertexAttrib4sv(GLuint index, GLshort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4sv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4ubv
        public static void glVertexAttrib4ubv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4ubv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4ubv(GLuint index, IntPtr v)
        {
            glVertexAttrib4ubv_(index, v);
        }
        public static void glVertexAttrib4ubv(GLuint index, GLubyte[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4ubv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4uiv
        public static void glVertexAttrib4uiv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4uiv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4uiv(GLuint index, IntPtr v)
        {
            glVertexAttrib4uiv_(index, v);
        }
        public static void glVertexAttrib4uiv(GLuint index, GLuint[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4uiv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttrib4usv
        public static void glVertexAttrib4usv(GLuint index, object v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4usv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttrib4usv(GLuint index, IntPtr v)
        {
            glVertexAttrib4usv_(index, v);
        }
        public static void glVertexAttrib4usv(GLuint index, GLushort[] v)
        {
            GCHandle h0 = GCHandle.Alloc(v, GCHandleType.Pinned);
            try
            {
                glVertexAttrib4usv_(index, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        #endregion

        #region glVertexAttribPointer
        public static void glVertexAttribPointer(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, object pointer)
        {
            GCHandle h0 = GCHandle.Alloc(pointer, GCHandleType.Pinned);
            try
            {
                glVertexAttribPointer_(index, size, type, normalized, stride, h0.AddrOfPinnedObject());
            }
            finally
            {
                h0.Free();
            }
        }
        public static void glVertexAttribPointer(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, IntPtr pointer)
        {
            glVertexAttribPointer_(index, size, type, normalized, stride, pointer);
        }
        #endregion

    #endregion

        #region static Constructor

        static Gl()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major < 6 || Environment.OSVersion.Platform == PlatformID.Win32Windows)
            {
                #region Older Windows Core
                Gl.glNewList = new Gl.Delegates.glNewList(Imports.glNewList);
                Gl.glEndList = new Gl.Delegates.glEndList(Imports.glEndList);
                Gl.glCallList = new Gl.Delegates.glCallList(Imports.glCallList);
                Gl.glCallLists_ = new Gl.Delegates.glCallLists_(Imports.glCallLists_);
                Gl.glDeleteLists = new Gl.Delegates.glDeleteLists(Imports.glDeleteLists);
                Gl.glGenLists = new Gl.Delegates.glGenLists(Imports.glGenLists);
                Gl.glListBase = new Gl.Delegates.glListBase(Imports.glListBase);
                Gl.glBegin = new Gl.Delegates.glBegin(Imports.glBegin);
                Gl.glBitmap_ = new Gl.Delegates.glBitmap_(Imports.glBitmap_);
                Gl.glColor3b = new Gl.Delegates.glColor3b(Imports.glColor3b);
                Gl.glColor3bv_ = new Gl.Delegates.glColor3bv_(Imports.glColor3bv_);
                Gl.glColor3d = new Gl.Delegates.glColor3d(Imports.glColor3d);
                Gl.glColor3dv_ = new Gl.Delegates.glColor3dv_(Imports.glColor3dv_);
                Gl.glColor3f = new Gl.Delegates.glColor3f(Imports.glColor3f);
                Gl.glColor3fv_ = new Gl.Delegates.glColor3fv_(Imports.glColor3fv_);
                Gl.glColor3i = new Gl.Delegates.glColor3i(Imports.glColor3i);
                Gl.glColor3iv_ = new Gl.Delegates.glColor3iv_(Imports.glColor3iv_);
                Gl.glColor3s = new Gl.Delegates.glColor3s(Imports.glColor3s);
                Gl.glColor3sv_ = new Gl.Delegates.glColor3sv_(Imports.glColor3sv_);
                Gl.glColor3ub = new Gl.Delegates.glColor3ub(Imports.glColor3ub);
                Gl.glColor3ubv_ = new Gl.Delegates.glColor3ubv_(Imports.glColor3ubv_);
                Gl.glColor3ui = new Gl.Delegates.glColor3ui(Imports.glColor3ui);
                Gl.glColor3uiv_ = new Gl.Delegates.glColor3uiv_(Imports.glColor3uiv_);
                Gl.glColor3us = new Gl.Delegates.glColor3us(Imports.glColor3us);
                Gl.glColor3usv_ = new Gl.Delegates.glColor3usv_(Imports.glColor3usv_);
                Gl.glColor4b = new Gl.Delegates.glColor4b(Imports.glColor4b);
                Gl.glColor4bv_ = new Gl.Delegates.glColor4bv_(Imports.glColor4bv_);
                Gl.glColor4d = new Gl.Delegates.glColor4d(Imports.glColor4d);
                Gl.glColor4dv_ = new Gl.Delegates.glColor4dv_(Imports.glColor4dv_);
                Gl.glColor4f = new Gl.Delegates.glColor4f(Imports.glColor4f);
                Gl.glColor4fv_ = new Gl.Delegates.glColor4fv_(Imports.glColor4fv_);
                Gl.glColor4i = new Gl.Delegates.glColor4i(Imports.glColor4i);
                Gl.glColor4iv_ = new Gl.Delegates.glColor4iv_(Imports.glColor4iv_);
                Gl.glColor4s = new Gl.Delegates.glColor4s(Imports.glColor4s);
                Gl.glColor4sv_ = new Gl.Delegates.glColor4sv_(Imports.glColor4sv_);
                Gl.glColor4ub = new Gl.Delegates.glColor4ub(Imports.glColor4ub);
                Gl.glColor4ubv_ = new Gl.Delegates.glColor4ubv_(Imports.glColor4ubv_);
                Gl.glColor4ui = new Gl.Delegates.glColor4ui(Imports.glColor4ui);
                Gl.glColor4uiv_ = new Gl.Delegates.glColor4uiv_(Imports.glColor4uiv_);
                Gl.glColor4us = new Gl.Delegates.glColor4us(Imports.glColor4us);
                Gl.glColor4usv_ = new Gl.Delegates.glColor4usv_(Imports.glColor4usv_);
                Gl.glEdgeFlag = new Gl.Delegates.glEdgeFlag(Imports.glEdgeFlag);
                Gl.glEdgeFlagv_ = new Gl.Delegates.glEdgeFlagv_(Imports.glEdgeFlagv_);
                Gl.glEnd = new Gl.Delegates.glEnd(Imports.glEnd);
                Gl.glIndexd = new Gl.Delegates.glIndexd(Imports.glIndexd);
                Gl.glIndexdv_ = new Gl.Delegates.glIndexdv_(Imports.glIndexdv_);
                Gl.glIndexf = new Gl.Delegates.glIndexf(Imports.glIndexf);
                Gl.glIndexfv_ = new Gl.Delegates.glIndexfv_(Imports.glIndexfv_);
                Gl.glIndexi = new Gl.Delegates.glIndexi(Imports.glIndexi);
                Gl.glIndexiv_ = new Gl.Delegates.glIndexiv_(Imports.glIndexiv_);
                Gl.glIndexs = new Gl.Delegates.glIndexs(Imports.glIndexs);
                Gl.glIndexsv_ = new Gl.Delegates.glIndexsv_(Imports.glIndexsv_);
                Gl.glNormal3b = new Gl.Delegates.glNormal3b(Imports.glNormal3b);
                Gl.glNormal3bv_ = new Gl.Delegates.glNormal3bv_(Imports.glNormal3bv_);
                Gl.glNormal3d = new Gl.Delegates.glNormal3d(Imports.glNormal3d);
                Gl.glNormal3dv_ = new Gl.Delegates.glNormal3dv_(Imports.glNormal3dv_);
                Gl.glNormal3f = new Gl.Delegates.glNormal3f(Imports.glNormal3f);
                Gl.glNormal3fv_ = new Gl.Delegates.glNormal3fv_(Imports.glNormal3fv_);
                Gl.glNormal3i = new Gl.Delegates.glNormal3i(Imports.glNormal3i);
                Gl.glNormal3iv_ = new Gl.Delegates.glNormal3iv_(Imports.glNormal3iv_);
                Gl.glNormal3s = new Gl.Delegates.glNormal3s(Imports.glNormal3s);
                Gl.glNormal3sv_ = new Gl.Delegates.glNormal3sv_(Imports.glNormal3sv_);
                Gl.glRasterPos2d = new Gl.Delegates.glRasterPos2d(Imports.glRasterPos2d);
                Gl.glRasterPos2dv_ = new Gl.Delegates.glRasterPos2dv_(Imports.glRasterPos2dv_);
                Gl.glRasterPos2f = new Gl.Delegates.glRasterPos2f(Imports.glRasterPos2f);
                Gl.glRasterPos2fv_ = new Gl.Delegates.glRasterPos2fv_(Imports.glRasterPos2fv_);
                Gl.glRasterPos2i = new Gl.Delegates.glRasterPos2i(Imports.glRasterPos2i);
                Gl.glRasterPos2iv_ = new Gl.Delegates.glRasterPos2iv_(Imports.glRasterPos2iv_);
                Gl.glRasterPos2s = new Gl.Delegates.glRasterPos2s(Imports.glRasterPos2s);
                Gl.glRasterPos2sv_ = new Gl.Delegates.glRasterPos2sv_(Imports.glRasterPos2sv_);
                Gl.glRasterPos3d = new Gl.Delegates.glRasterPos3d(Imports.glRasterPos3d);
                Gl.glRasterPos3dv_ = new Gl.Delegates.glRasterPos3dv_(Imports.glRasterPos3dv_);
                Gl.glRasterPos3f = new Gl.Delegates.glRasterPos3f(Imports.glRasterPos3f);
                Gl.glRasterPos3fv_ = new Gl.Delegates.glRasterPos3fv_(Imports.glRasterPos3fv_);
                Gl.glRasterPos3i = new Gl.Delegates.glRasterPos3i(Imports.glRasterPos3i);
                Gl.glRasterPos3iv_ = new Gl.Delegates.glRasterPos3iv_(Imports.glRasterPos3iv_);
                Gl.glRasterPos3s = new Gl.Delegates.glRasterPos3s(Imports.glRasterPos3s);
                Gl.glRasterPos3sv_ = new Gl.Delegates.glRasterPos3sv_(Imports.glRasterPos3sv_);
                Gl.glRasterPos4d = new Gl.Delegates.glRasterPos4d(Imports.glRasterPos4d);
                Gl.glRasterPos4dv_ = new Gl.Delegates.glRasterPos4dv_(Imports.glRasterPos4dv_);
                Gl.glRasterPos4f = new Gl.Delegates.glRasterPos4f(Imports.glRasterPos4f);
                Gl.glRasterPos4fv_ = new Gl.Delegates.glRasterPos4fv_(Imports.glRasterPos4fv_);
                Gl.glRasterPos4i = new Gl.Delegates.glRasterPos4i(Imports.glRasterPos4i);
                Gl.glRasterPos4iv_ = new Gl.Delegates.glRasterPos4iv_(Imports.glRasterPos4iv_);
                Gl.glRasterPos4s = new Gl.Delegates.glRasterPos4s(Imports.glRasterPos4s);
                Gl.glRasterPos4sv_ = new Gl.Delegates.glRasterPos4sv_(Imports.glRasterPos4sv_);
                Gl.glRectd = new Gl.Delegates.glRectd(Imports.glRectd);
                Gl.glRectdv_ = new Gl.Delegates.glRectdv_(Imports.glRectdv_);
                Gl.glRectf = new Gl.Delegates.glRectf(Imports.glRectf);
                Gl.glRectfv_ = new Gl.Delegates.glRectfv_(Imports.glRectfv_);
                Gl.glRecti = new Gl.Delegates.glRecti(Imports.glRecti);
                Gl.glRectiv_ = new Gl.Delegates.glRectiv_(Imports.glRectiv_);
                Gl.glRects = new Gl.Delegates.glRects(Imports.glRects);
                Gl.glRectsv_ = new Gl.Delegates.glRectsv_(Imports.glRectsv_);
                Gl.glTexCoord1d = new Gl.Delegates.glTexCoord1d(Imports.glTexCoord1d);
                Gl.glTexCoord1dv_ = new Gl.Delegates.glTexCoord1dv_(Imports.glTexCoord1dv_);
                Gl.glTexCoord1f = new Gl.Delegates.glTexCoord1f(Imports.glTexCoord1f);
                Gl.glTexCoord1fv_ = new Gl.Delegates.glTexCoord1fv_(Imports.glTexCoord1fv_);
                Gl.glTexCoord1i = new Gl.Delegates.glTexCoord1i(Imports.glTexCoord1i);
                Gl.glTexCoord1iv_ = new Gl.Delegates.glTexCoord1iv_(Imports.glTexCoord1iv_);
                Gl.glTexCoord1s = new Gl.Delegates.glTexCoord1s(Imports.glTexCoord1s);
                Gl.glTexCoord1sv_ = new Gl.Delegates.glTexCoord1sv_(Imports.glTexCoord1sv_);
                Gl.glTexCoord2d = new Gl.Delegates.glTexCoord2d(Imports.glTexCoord2d);
                Gl.glTexCoord2dv_ = new Gl.Delegates.glTexCoord2dv_(Imports.glTexCoord2dv_);
                Gl.glTexCoord2f = new Gl.Delegates.glTexCoord2f(Imports.glTexCoord2f);
                Gl.glTexCoord2fv_ = new Gl.Delegates.glTexCoord2fv_(Imports.glTexCoord2fv_);
                Gl.glTexCoord2i = new Gl.Delegates.glTexCoord2i(Imports.glTexCoord2i);
                Gl.glTexCoord2iv_ = new Gl.Delegates.glTexCoord2iv_(Imports.glTexCoord2iv_);
                Gl.glTexCoord2s = new Gl.Delegates.glTexCoord2s(Imports.glTexCoord2s);
                Gl.glTexCoord2sv_ = new Gl.Delegates.glTexCoord2sv_(Imports.glTexCoord2sv_);
                Gl.glTexCoord3d = new Gl.Delegates.glTexCoord3d(Imports.glTexCoord3d);
                Gl.glTexCoord3dv_ = new Gl.Delegates.glTexCoord3dv_(Imports.glTexCoord3dv_);
                Gl.glTexCoord3f = new Gl.Delegates.glTexCoord3f(Imports.glTexCoord3f);
                Gl.glTexCoord3fv_ = new Gl.Delegates.glTexCoord3fv_(Imports.glTexCoord3fv_);
                Gl.glTexCoord3i = new Gl.Delegates.glTexCoord3i(Imports.glTexCoord3i);
                Gl.glTexCoord3iv_ = new Gl.Delegates.glTexCoord3iv_(Imports.glTexCoord3iv_);
                Gl.glTexCoord3s = new Gl.Delegates.glTexCoord3s(Imports.glTexCoord3s);
                Gl.glTexCoord3sv_ = new Gl.Delegates.glTexCoord3sv_(Imports.glTexCoord3sv_);
                Gl.glTexCoord4d = new Gl.Delegates.glTexCoord4d(Imports.glTexCoord4d);
                Gl.glTexCoord4dv_ = new Gl.Delegates.glTexCoord4dv_(Imports.glTexCoord4dv_);
                Gl.glTexCoord4f = new Gl.Delegates.glTexCoord4f(Imports.glTexCoord4f);
                Gl.glTexCoord4fv_ = new Gl.Delegates.glTexCoord4fv_(Imports.glTexCoord4fv_);
                Gl.glTexCoord4i = new Gl.Delegates.glTexCoord4i(Imports.glTexCoord4i);
                Gl.glTexCoord4iv_ = new Gl.Delegates.glTexCoord4iv_(Imports.glTexCoord4iv_);
                Gl.glTexCoord4s = new Gl.Delegates.glTexCoord4s(Imports.glTexCoord4s);
                Gl.glTexCoord4sv_ = new Gl.Delegates.glTexCoord4sv_(Imports.glTexCoord4sv_);
                Gl.glVertex2d = new Gl.Delegates.glVertex2d(Imports.glVertex2d);
                Gl.glVertex2dv_ = new Gl.Delegates.glVertex2dv_(Imports.glVertex2dv_);
                Gl.glVertex2f = new Gl.Delegates.glVertex2f(Imports.glVertex2f);
                Gl.glVertex2fv_ = new Gl.Delegates.glVertex2fv_(Imports.glVertex2fv_);
                Gl.glVertex2i = new Gl.Delegates.glVertex2i(Imports.glVertex2i);
                Gl.glVertex2iv_ = new Gl.Delegates.glVertex2iv_(Imports.glVertex2iv_);
                Gl.glVertex2s = new Gl.Delegates.glVertex2s(Imports.glVertex2s);
                Gl.glVertex2sv_ = new Gl.Delegates.glVertex2sv_(Imports.glVertex2sv_);
                Gl.glVertex3d = new Gl.Delegates.glVertex3d(Imports.glVertex3d);
                Gl.glVertex3dv_ = new Gl.Delegates.glVertex3dv_(Imports.glVertex3dv_);
                Gl.glVertex3f = new Gl.Delegates.glVertex3f(Imports.glVertex3f);
                Gl.glVertex3fv_ = new Gl.Delegates.glVertex3fv_(Imports.glVertex3fv_);
                Gl.glVertex3i = new Gl.Delegates.glVertex3i(Imports.glVertex3i);
                Gl.glVertex3iv_ = new Gl.Delegates.glVertex3iv_(Imports.glVertex3iv_);
                Gl.glVertex3s = new Gl.Delegates.glVertex3s(Imports.glVertex3s);
                Gl.glVertex3sv_ = new Gl.Delegates.glVertex3sv_(Imports.glVertex3sv_);
                Gl.glVertex4d = new Gl.Delegates.glVertex4d(Imports.glVertex4d);
                Gl.glVertex4dv_ = new Gl.Delegates.glVertex4dv_(Imports.glVertex4dv_);
                Gl.glVertex4f = new Gl.Delegates.glVertex4f(Imports.glVertex4f);
                Gl.glVertex4fv_ = new Gl.Delegates.glVertex4fv_(Imports.glVertex4fv_);
                Gl.glVertex4i = new Gl.Delegates.glVertex4i(Imports.glVertex4i);
                Gl.glVertex4iv_ = new Gl.Delegates.glVertex4iv_(Imports.glVertex4iv_);
                Gl.glVertex4s = new Gl.Delegates.glVertex4s(Imports.glVertex4s);
                Gl.glVertex4sv_ = new Gl.Delegates.glVertex4sv_(Imports.glVertex4sv_);
                Gl.glClipPlane_ = new Gl.Delegates.glClipPlane_(Imports.glClipPlane_);
                Gl.glColorMaterial = new Gl.Delegates.glColorMaterial(Imports.glColorMaterial);
                Gl.glCullFace = new Gl.Delegates.glCullFace(Imports.glCullFace);
                Gl.glFogf = new Gl.Delegates.glFogf(Imports.glFogf);
                Gl.glFogfv_ = new Gl.Delegates.glFogfv_(Imports.glFogfv_);
                Gl.glFogi = new Gl.Delegates.glFogi(Imports.glFogi);
                Gl.glFogiv_ = new Gl.Delegates.glFogiv_(Imports.glFogiv_);
                Gl.glFrontFace = new Gl.Delegates.glFrontFace(Imports.glFrontFace);
                Gl.glHint = new Gl.Delegates.glHint(Imports.glHint);
                Gl.glLightf = new Gl.Delegates.glLightf(Imports.glLightf);
                Gl.glLightfv_ = new Gl.Delegates.glLightfv_(Imports.glLightfv_);
                Gl.glLighti = new Gl.Delegates.glLighti(Imports.glLighti);
                Gl.glLightiv_ = new Gl.Delegates.glLightiv_(Imports.glLightiv_);
                Gl.glLightModelf = new Gl.Delegates.glLightModelf(Imports.glLightModelf);
                Gl.glLightModelfv_ = new Gl.Delegates.glLightModelfv_(Imports.glLightModelfv_);
                Gl.glLightModeli = new Gl.Delegates.glLightModeli(Imports.glLightModeli);
                Gl.glLightModeliv_ = new Gl.Delegates.glLightModeliv_(Imports.glLightModeliv_);
                Gl.glLineStipple_ = new Gl.Delegates.glLineStipple_(Imports.glLineStipple_);
                Gl.glLineWidth = new Gl.Delegates.glLineWidth(Imports.glLineWidth);
                Gl.glMaterialf = new Gl.Delegates.glMaterialf(Imports.glMaterialf);
                Gl.glMaterialfv_ = new Gl.Delegates.glMaterialfv_(Imports.glMaterialfv_);
                Gl.glMateriali = new Gl.Delegates.glMateriali(Imports.glMateriali);
                Gl.glMaterialiv_ = new Gl.Delegates.glMaterialiv_(Imports.glMaterialiv_);
                Gl.glPointSize = new Gl.Delegates.glPointSize(Imports.glPointSize);
                Gl.glPolygonMode = new Gl.Delegates.glPolygonMode(Imports.glPolygonMode);
                Gl.glPolygonStipple_ = new Gl.Delegates.glPolygonStipple_(Imports.glPolygonStipple_);
                Gl.glScissor = new Gl.Delegates.glScissor(Imports.glScissor);
                Gl.glShadeModel = new Gl.Delegates.glShadeModel(Imports.glShadeModel);
                Gl.glTexParameterf = new Gl.Delegates.glTexParameterf(Imports.glTexParameterf);
                Gl.glTexParameterfv_ = new Gl.Delegates.glTexParameterfv_(Imports.glTexParameterfv_);
                Gl.glTexParameteri = new Gl.Delegates.glTexParameteri(Imports.glTexParameteri);
                Gl.glTexParameteriv_ = new Gl.Delegates.glTexParameteriv_(Imports.glTexParameteriv_);
                Gl.glTexImage1D_ = new Gl.Delegates.glTexImage1D_(Imports.glTexImage1D_);
                Gl.glTexImage2D_ = new Gl.Delegates.glTexImage2D_(Imports.glTexImage2D_);
                Gl.glTexEnvf = new Gl.Delegates.glTexEnvf(Imports.glTexEnvf);
                Gl.glTexEnvfv_ = new Gl.Delegates.glTexEnvfv_(Imports.glTexEnvfv_);
                Gl.glTexEnvi = new Gl.Delegates.glTexEnvi(Imports.glTexEnvi);
                Gl.glTexEnviv_ = new Gl.Delegates.glTexEnviv_(Imports.glTexEnviv_);
                Gl.glTexGend = new Gl.Delegates.glTexGend(Imports.glTexGend);
                Gl.glTexGendv_ = new Gl.Delegates.glTexGendv_(Imports.glTexGendv_);
                Gl.glTexGenf = new Gl.Delegates.glTexGenf(Imports.glTexGenf);
                Gl.glTexGenfv_ = new Gl.Delegates.glTexGenfv_(Imports.glTexGenfv_);
                Gl.glTexGeni = new Gl.Delegates.glTexGeni(Imports.glTexGeni);
                Gl.glTexGeniv_ = new Gl.Delegates.glTexGeniv_(Imports.glTexGeniv_);
                Gl.glFeedbackBuffer = new Gl.Delegates.glFeedbackBuffer(Imports.glFeedbackBuffer);
                Gl.glSelectBuffer = new Gl.Delegates.glSelectBuffer(Imports.glSelectBuffer);
                Gl.glRenderMode = new Gl.Delegates.glRenderMode(Imports.glRenderMode);
                Gl.glInitNames = new Gl.Delegates.glInitNames(Imports.glInitNames);
                Gl.glLoadName = new Gl.Delegates.glLoadName(Imports.glLoadName);
                Gl.glPassThrough = new Gl.Delegates.glPassThrough(Imports.glPassThrough);
                Gl.glPopName = new Gl.Delegates.glPopName(Imports.glPopName);
                Gl.glPushName = new Gl.Delegates.glPushName(Imports.glPushName);
                Gl.glDrawBuffer = new Gl.Delegates.glDrawBuffer(Imports.glDrawBuffer);
                Gl.glClear = new Gl.Delegates.glClear(Imports.glClear);
                Gl.glClearAccum = new Gl.Delegates.glClearAccum(Imports.glClearAccum);
                Gl.glClearIndex = new Gl.Delegates.glClearIndex(Imports.glClearIndex);
                Gl.glClearColor = new Gl.Delegates.glClearColor(Imports.glClearColor);
                Gl.glClearStencil = new Gl.Delegates.glClearStencil(Imports.glClearStencil);
                Gl.glClearDepth = new Gl.Delegates.glClearDepth(Imports.glClearDepth);
                Gl.glStencilMask = new Gl.Delegates.glStencilMask(Imports.glStencilMask);
                Gl.glColorMask = new Gl.Delegates.glColorMask(Imports.glColorMask);
                Gl.glDepthMask = new Gl.Delegates.glDepthMask(Imports.glDepthMask);
                Gl.glIndexMask = new Gl.Delegates.glIndexMask(Imports.glIndexMask);
                Gl.glAccum = new Gl.Delegates.glAccum(Imports.glAccum);
                Gl.glDisable = new Gl.Delegates.glDisable(Imports.glDisable);
                Gl.glEnable = new Gl.Delegates.glEnable(Imports.glEnable);
                Gl.glFinish = new Gl.Delegates.glFinish(Imports.glFinish);
                Gl.glFlush = new Gl.Delegates.glFlush(Imports.glFlush);
                Gl.glPopAttrib = new Gl.Delegates.glPopAttrib(Imports.glPopAttrib);
                Gl.glPushAttrib = new Gl.Delegates.glPushAttrib(Imports.glPushAttrib);
                Gl.glMap1d_ = new Gl.Delegates.glMap1d_(Imports.glMap1d_);
                Gl.glMap1f_ = new Gl.Delegates.glMap1f_(Imports.glMap1f_);
                Gl.glMap2d_ = new Gl.Delegates.glMap2d_(Imports.glMap2d_);
                Gl.glMap2f_ = new Gl.Delegates.glMap2f_(Imports.glMap2f_);
                Gl.glMapGrid1d = new Gl.Delegates.glMapGrid1d(Imports.glMapGrid1d);
                Gl.glMapGrid1f = new Gl.Delegates.glMapGrid1f(Imports.glMapGrid1f);
                Gl.glMapGrid2d = new Gl.Delegates.glMapGrid2d(Imports.glMapGrid2d);
                Gl.glMapGrid2f = new Gl.Delegates.glMapGrid2f(Imports.glMapGrid2f);
                Gl.glEvalCoord1d = new Gl.Delegates.glEvalCoord1d(Imports.glEvalCoord1d);
                Gl.glEvalCoord1dv_ = new Gl.Delegates.glEvalCoord1dv_(Imports.glEvalCoord1dv_);
                Gl.glEvalCoord1f = new Gl.Delegates.glEvalCoord1f(Imports.glEvalCoord1f);
                Gl.glEvalCoord1fv_ = new Gl.Delegates.glEvalCoord1fv_(Imports.glEvalCoord1fv_);
                Gl.glEvalCoord2d = new Gl.Delegates.glEvalCoord2d(Imports.glEvalCoord2d);
                Gl.glEvalCoord2dv_ = new Gl.Delegates.glEvalCoord2dv_(Imports.glEvalCoord2dv_);
                Gl.glEvalCoord2f = new Gl.Delegates.glEvalCoord2f(Imports.glEvalCoord2f);
                Gl.glEvalCoord2fv_ = new Gl.Delegates.glEvalCoord2fv_(Imports.glEvalCoord2fv_);
                Gl.glEvalMesh1 = new Gl.Delegates.glEvalMesh1(Imports.glEvalMesh1);
                Gl.glEvalPoint1 = new Gl.Delegates.glEvalPoint1(Imports.glEvalPoint1);
                Gl.glEvalMesh2 = new Gl.Delegates.glEvalMesh2(Imports.glEvalMesh2);
                Gl.glEvalPoint2 = new Gl.Delegates.glEvalPoint2(Imports.glEvalPoint2);
                Gl.glAlphaFunc = new Gl.Delegates.glAlphaFunc(Imports.glAlphaFunc);
                Gl.glBlendFunc = new Gl.Delegates.glBlendFunc(Imports.glBlendFunc);
                Gl.glLogicOp = new Gl.Delegates.glLogicOp(Imports.glLogicOp);
                Gl.glStencilFunc = new Gl.Delegates.glStencilFunc(Imports.glStencilFunc);
                Gl.glStencilOp = new Gl.Delegates.glStencilOp(Imports.glStencilOp);
                Gl.glDepthFunc = new Gl.Delegates.glDepthFunc(Imports.glDepthFunc);
                Gl.glPixelZoom = new Gl.Delegates.glPixelZoom(Imports.glPixelZoom);
                Gl.glPixelTransferf = new Gl.Delegates.glPixelTransferf(Imports.glPixelTransferf);
                Gl.glPixelTransferi = new Gl.Delegates.glPixelTransferi(Imports.glPixelTransferi);
                Gl.glPixelStoref = new Gl.Delegates.glPixelStoref(Imports.glPixelStoref);
                Gl.glPixelStorei = new Gl.Delegates.glPixelStorei(Imports.glPixelStorei);
                Gl.glPixelMapfv_ = new Gl.Delegates.glPixelMapfv_(Imports.glPixelMapfv_);
                Gl.glPixelMapuiv_ = new Gl.Delegates.glPixelMapuiv_(Imports.glPixelMapuiv_);
                Gl.glPixelMapusv_ = new Gl.Delegates.glPixelMapusv_(Imports.glPixelMapusv_);
                Gl.glReadBuffer = new Gl.Delegates.glReadBuffer(Imports.glReadBuffer);
                Gl.glCopyPixels = new Gl.Delegates.glCopyPixels(Imports.glCopyPixels);
                Gl.glReadPixels_ = new Gl.Delegates.glReadPixels_(Imports.glReadPixels_);
                Gl.glDrawPixels_ = new Gl.Delegates.glDrawPixels_(Imports.glDrawPixels_);
                Gl.glGetBooleanv = new Gl.Delegates.glGetBooleanv(Imports.glGetBooleanv);
                Gl.glGetClipPlane = new Gl.Delegates.glGetClipPlane(Imports.glGetClipPlane);
                Gl.glGetDoublev = new Gl.Delegates.glGetDoublev(Imports.glGetDoublev);
                Gl.glGetError = new Gl.Delegates.glGetError(Imports.glGetError);
                Gl.glGetFloatv = new Gl.Delegates.glGetFloatv(Imports.glGetFloatv);
                Gl.glGetIntegerv = new Gl.Delegates.glGetIntegerv(Imports.glGetIntegerv);
                Gl.glGetLightfv = new Gl.Delegates.glGetLightfv(Imports.glGetLightfv);
                Gl.glGetLightiv = new Gl.Delegates.glGetLightiv(Imports.glGetLightiv);
                Gl.glGetMapdv = new Gl.Delegates.glGetMapdv(Imports.glGetMapdv);
                Gl.glGetMapfv = new Gl.Delegates.glGetMapfv(Imports.glGetMapfv);
                Gl.glGetMapiv = new Gl.Delegates.glGetMapiv(Imports.glGetMapiv);
                Gl.glGetMaterialfv = new Gl.Delegates.glGetMaterialfv(Imports.glGetMaterialfv);
                Gl.glGetMaterialiv = new Gl.Delegates.glGetMaterialiv(Imports.glGetMaterialiv);
                Gl.glGetPixelMapfv = new Gl.Delegates.glGetPixelMapfv(Imports.glGetPixelMapfv);
                Gl.glGetPixelMapuiv = new Gl.Delegates.glGetPixelMapuiv(Imports.glGetPixelMapuiv);
                Gl.glGetPixelMapusv = new Gl.Delegates.glGetPixelMapusv(Imports.glGetPixelMapusv);
                Gl.glGetPolygonStipple = new Gl.Delegates.glGetPolygonStipple(Imports.glGetPolygonStipple);
                Gl.glGetString_ = new Gl.Delegates.glGetString_(Imports.glGetString_);
                Gl.glGetTexEnvfv = new Gl.Delegates.glGetTexEnvfv(Imports.glGetTexEnvfv);
                Gl.glGetTexEnviv = new Gl.Delegates.glGetTexEnviv(Imports.glGetTexEnviv);
                Gl.glGetTexGendv = new Gl.Delegates.glGetTexGendv(Imports.glGetTexGendv);
                Gl.glGetTexGenfv = new Gl.Delegates.glGetTexGenfv(Imports.glGetTexGenfv);
                Gl.glGetTexGeniv = new Gl.Delegates.glGetTexGeniv(Imports.glGetTexGeniv);
                Gl.glGetTexImage_ = new Gl.Delegates.glGetTexImage_(Imports.glGetTexImage_);
                Gl.glGetTexParameterfv = new Gl.Delegates.glGetTexParameterfv(Imports.glGetTexParameterfv);
                Gl.glGetTexParameteriv = new Gl.Delegates.glGetTexParameteriv(Imports.glGetTexParameteriv);
                Gl.glGetTexLevelParameterfv = new Gl.Delegates.glGetTexLevelParameterfv(Imports.glGetTexLevelParameterfv);
                Gl.glGetTexLevelParameteriv = new Gl.Delegates.glGetTexLevelParameteriv(Imports.glGetTexLevelParameteriv);
                Gl.glIsEnabled = new Gl.Delegates.glIsEnabled(Imports.glIsEnabled);
                Gl.glIsList = new Gl.Delegates.glIsList(Imports.glIsList);
                Gl.glDepthRange = new Gl.Delegates.glDepthRange(Imports.glDepthRange);
                Gl.glFrustum = new Gl.Delegates.glFrustum(Imports.glFrustum);
                Gl.glLoadIdentity = new Gl.Delegates.glLoadIdentity(Imports.glLoadIdentity);
                Gl.glLoadMatrixf_ = new Gl.Delegates.glLoadMatrixf_(Imports.glLoadMatrixf_);
                Gl.glLoadMatrixd_ = new Gl.Delegates.glLoadMatrixd_(Imports.glLoadMatrixd_);
                Gl.glMatrixMode = new Gl.Delegates.glMatrixMode(Imports.glMatrixMode);
                Gl.glMultMatrixf_ = new Gl.Delegates.glMultMatrixf_(Imports.glMultMatrixf_);
                Gl.glMultMatrixd_ = new Gl.Delegates.glMultMatrixd_(Imports.glMultMatrixd_);
                Gl.glOrtho = new Gl.Delegates.glOrtho(Imports.glOrtho);
                Gl.glPopMatrix = new Gl.Delegates.glPopMatrix(Imports.glPopMatrix);
                Gl.glPushMatrix = new Gl.Delegates.glPushMatrix(Imports.glPushMatrix);
                Gl.glRotated = new Gl.Delegates.glRotated(Imports.glRotated);
                Gl.glRotatef = new Gl.Delegates.glRotatef(Imports.glRotatef);
                Gl.glScaled = new Gl.Delegates.glScaled(Imports.glScaled);
                Gl.glScalef = new Gl.Delegates.glScalef(Imports.glScalef);
                Gl.glTranslated = new Gl.Delegates.glTranslated(Imports.glTranslated);
                Gl.glTranslatef = new Gl.Delegates.glTranslatef(Imports.glTranslatef);
                Gl.glViewport = new Gl.Delegates.glViewport(Imports.glViewport);
                Gl.glArrayElement = new Gl.Delegates.glArrayElement(Imports.glArrayElement);
                Gl.glColorPointer_ = new Gl.Delegates.glColorPointer_(Imports.glColorPointer_);
                Gl.glDisableClientState = new Gl.Delegates.glDisableClientState(Imports.glDisableClientState);
                Gl.glDrawArrays = new Gl.Delegates.glDrawArrays(Imports.glDrawArrays);
                Gl.glDrawElements_ = new Gl.Delegates.glDrawElements_(Imports.glDrawElements_);
                Gl.glEdgeFlagPointer_ = new Gl.Delegates.glEdgeFlagPointer_(Imports.glEdgeFlagPointer_);
                Gl.glEnableClientState = new Gl.Delegates.glEnableClientState(Imports.glEnableClientState);
                Gl.glGetPointerv = new Gl.Delegates.glGetPointerv(Imports.glGetPointerv);
                Gl.glIndexPointer_ = new Gl.Delegates.glIndexPointer_(Imports.glIndexPointer_);
                Gl.glInterleavedArrays_ = new Gl.Delegates.glInterleavedArrays_(Imports.glInterleavedArrays_);
                Gl.glNormalPointer_ = new Gl.Delegates.glNormalPointer_(Imports.glNormalPointer_);
                Gl.glTexCoordPointer_ = new Gl.Delegates.glTexCoordPointer_(Imports.glTexCoordPointer_);
                Gl.glVertexPointer_ = new Gl.Delegates.glVertexPointer_(Imports.glVertexPointer_);
                Gl.glPolygonOffset = new Gl.Delegates.glPolygonOffset(Imports.glPolygonOffset);
                Gl.glCopyTexImage1D = new Gl.Delegates.glCopyTexImage1D(Imports.glCopyTexImage1D);
                Gl.glCopyTexImage2D = new Gl.Delegates.glCopyTexImage2D(Imports.glCopyTexImage2D);
                Gl.glCopyTexSubImage1D = new Gl.Delegates.glCopyTexSubImage1D(Imports.glCopyTexSubImage1D);
                Gl.glCopyTexSubImage2D = new Gl.Delegates.glCopyTexSubImage2D(Imports.glCopyTexSubImage2D);
                Gl.glTexSubImage1D_ = new Gl.Delegates.glTexSubImage1D_(Imports.glTexSubImage1D_);
                Gl.glTexSubImage2D_ = new Gl.Delegates.glTexSubImage2D_(Imports.glTexSubImage2D_);
                Gl.glAreTexturesResident_ = new Gl.Delegates.glAreTexturesResident_(Imports.glAreTexturesResident_);
                Gl.glBindTexture = new Gl.Delegates.glBindTexture(Imports.glBindTexture);
                Gl.glDeleteTextures_ = new Gl.Delegates.glDeleteTextures_(Imports.glDeleteTextures_);
                Gl.glGenTextures = new Gl.Delegates.glGenTextures(Imports.glGenTextures);
                Gl.glIsTexture = new Gl.Delegates.glIsTexture(Imports.glIsTexture);
                Gl.glPrioritizeTextures_ = new Gl.Delegates.glPrioritizeTextures_(Imports.glPrioritizeTextures_);
                Gl.glIndexub = new Gl.Delegates.glIndexub(Imports.glIndexub);
                Gl.glIndexubv_ = new Gl.Delegates.glIndexubv_(Imports.glIndexubv_);
                Gl.glPopClientAttrib = new Gl.Delegates.glPopClientAttrib(Imports.glPopClientAttrib);
                Gl.glPushClientAttrib = new Gl.Delegates.glPushClientAttrib(Imports.glPushClientAttrib);
                #endregion
            }
            else if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
            {
                #region Windows Vista Core
                Gl.glNewList = new Gl.Delegates.glNewList(Imports.glNewList);
                Gl.glEndList = new Gl.Delegates.glEndList(Imports.glEndList);
                Gl.glCallList = new Gl.Delegates.glCallList(Imports.glCallList);
                Gl.glCallLists_ = new Gl.Delegates.glCallLists_(Imports.glCallLists_);
                Gl.glDeleteLists = new Gl.Delegates.glDeleteLists(Imports.glDeleteLists);
                Gl.glGenLists = new Gl.Delegates.glGenLists(Imports.glGenLists);
                Gl.glListBase = new Gl.Delegates.glListBase(Imports.glListBase);
                Gl.glBegin = new Gl.Delegates.glBegin(Imports.glBegin);
                Gl.glBitmap_ = new Gl.Delegates.glBitmap_(Imports.glBitmap_);
                Gl.glColor3b = new Gl.Delegates.glColor3b(Imports.glColor3b);
                Gl.glColor3bv_ = new Gl.Delegates.glColor3bv_(Imports.glColor3bv_);
                Gl.glColor3d = new Gl.Delegates.glColor3d(Imports.glColor3d);
                Gl.glColor3dv_ = new Gl.Delegates.glColor3dv_(Imports.glColor3dv_);
                Gl.glColor3f = new Gl.Delegates.glColor3f(Imports.glColor3f);
                Gl.glColor3fv_ = new Gl.Delegates.glColor3fv_(Imports.glColor3fv_);
                Gl.glColor3i = new Gl.Delegates.glColor3i(Imports.glColor3i);
                Gl.glColor3iv_ = new Gl.Delegates.glColor3iv_(Imports.glColor3iv_);
                Gl.glColor3s = new Gl.Delegates.glColor3s(Imports.glColor3s);
                Gl.glColor3sv_ = new Gl.Delegates.glColor3sv_(Imports.glColor3sv_);
                Gl.glColor3ub = new Gl.Delegates.glColor3ub(Imports.glColor3ub);
                Gl.glColor3ubv_ = new Gl.Delegates.glColor3ubv_(Imports.glColor3ubv_);
                Gl.glColor3ui = new Gl.Delegates.glColor3ui(Imports.glColor3ui);
                Gl.glColor3uiv_ = new Gl.Delegates.glColor3uiv_(Imports.glColor3uiv_);
                Gl.glColor3us = new Gl.Delegates.glColor3us(Imports.glColor3us);
                Gl.glColor3usv_ = new Gl.Delegates.glColor3usv_(Imports.glColor3usv_);
                Gl.glColor4b = new Gl.Delegates.glColor4b(Imports.glColor4b);
                Gl.glColor4bv_ = new Gl.Delegates.glColor4bv_(Imports.glColor4bv_);
                Gl.glColor4d = new Gl.Delegates.glColor4d(Imports.glColor4d);
                Gl.glColor4dv_ = new Gl.Delegates.glColor4dv_(Imports.glColor4dv_);
                Gl.glColor4f = new Gl.Delegates.glColor4f(Imports.glColor4f);
                Gl.glColor4fv_ = new Gl.Delegates.glColor4fv_(Imports.glColor4fv_);
                Gl.glColor4i = new Gl.Delegates.glColor4i(Imports.glColor4i);
                Gl.glColor4iv_ = new Gl.Delegates.glColor4iv_(Imports.glColor4iv_);
                Gl.glColor4s = new Gl.Delegates.glColor4s(Imports.glColor4s);
                Gl.glColor4sv_ = new Gl.Delegates.glColor4sv_(Imports.glColor4sv_);
                Gl.glColor4ub = new Gl.Delegates.glColor4ub(Imports.glColor4ub);
                Gl.glColor4ubv_ = new Gl.Delegates.glColor4ubv_(Imports.glColor4ubv_);
                Gl.glColor4ui = new Gl.Delegates.glColor4ui(Imports.glColor4ui);
                Gl.glColor4uiv_ = new Gl.Delegates.glColor4uiv_(Imports.glColor4uiv_);
                Gl.glColor4us = new Gl.Delegates.glColor4us(Imports.glColor4us);
                Gl.glColor4usv_ = new Gl.Delegates.glColor4usv_(Imports.glColor4usv_);
                Gl.glEdgeFlag = new Gl.Delegates.glEdgeFlag(Imports.glEdgeFlag);
                Gl.glEdgeFlagv_ = new Gl.Delegates.glEdgeFlagv_(Imports.glEdgeFlagv_);
                Gl.glEnd = new Gl.Delegates.glEnd(Imports.glEnd);
                Gl.glIndexd = new Gl.Delegates.glIndexd(Imports.glIndexd);
                Gl.glIndexdv_ = new Gl.Delegates.glIndexdv_(Imports.glIndexdv_);
                Gl.glIndexf = new Gl.Delegates.glIndexf(Imports.glIndexf);
                Gl.glIndexfv_ = new Gl.Delegates.glIndexfv_(Imports.glIndexfv_);
                Gl.glIndexi = new Gl.Delegates.glIndexi(Imports.glIndexi);
                Gl.glIndexiv_ = new Gl.Delegates.glIndexiv_(Imports.glIndexiv_);
                Gl.glIndexs = new Gl.Delegates.glIndexs(Imports.glIndexs);
                Gl.glIndexsv_ = new Gl.Delegates.glIndexsv_(Imports.glIndexsv_);
                Gl.glNormal3b = new Gl.Delegates.glNormal3b(Imports.glNormal3b);
                Gl.glNormal3bv_ = new Gl.Delegates.glNormal3bv_(Imports.glNormal3bv_);
                Gl.glNormal3d = new Gl.Delegates.glNormal3d(Imports.glNormal3d);
                Gl.glNormal3dv_ = new Gl.Delegates.glNormal3dv_(Imports.glNormal3dv_);
                Gl.glNormal3f = new Gl.Delegates.glNormal3f(Imports.glNormal3f);
                Gl.glNormal3fv_ = new Gl.Delegates.glNormal3fv_(Imports.glNormal3fv_);
                Gl.glNormal3i = new Gl.Delegates.glNormal3i(Imports.glNormal3i);
                Gl.glNormal3iv_ = new Gl.Delegates.glNormal3iv_(Imports.glNormal3iv_);
                Gl.glNormal3s = new Gl.Delegates.glNormal3s(Imports.glNormal3s);
                Gl.glNormal3sv_ = new Gl.Delegates.glNormal3sv_(Imports.glNormal3sv_);
                Gl.glRasterPos2d = new Gl.Delegates.glRasterPos2d(Imports.glRasterPos2d);
                Gl.glRasterPos2dv_ = new Gl.Delegates.glRasterPos2dv_(Imports.glRasterPos2dv_);
                Gl.glRasterPos2f = new Gl.Delegates.glRasterPos2f(Imports.glRasterPos2f);
                Gl.glRasterPos2fv_ = new Gl.Delegates.glRasterPos2fv_(Imports.glRasterPos2fv_);
                Gl.glRasterPos2i = new Gl.Delegates.glRasterPos2i(Imports.glRasterPos2i);
                Gl.glRasterPos2iv_ = new Gl.Delegates.glRasterPos2iv_(Imports.glRasterPos2iv_);
                Gl.glRasterPos2s = new Gl.Delegates.glRasterPos2s(Imports.glRasterPos2s);
                Gl.glRasterPos2sv_ = new Gl.Delegates.glRasterPos2sv_(Imports.glRasterPos2sv_);
                Gl.glRasterPos3d = new Gl.Delegates.glRasterPos3d(Imports.glRasterPos3d);
                Gl.glRasterPos3dv_ = new Gl.Delegates.glRasterPos3dv_(Imports.glRasterPos3dv_);
                Gl.glRasterPos3f = new Gl.Delegates.glRasterPos3f(Imports.glRasterPos3f);
                Gl.glRasterPos3fv_ = new Gl.Delegates.glRasterPos3fv_(Imports.glRasterPos3fv_);
                Gl.glRasterPos3i = new Gl.Delegates.glRasterPos3i(Imports.glRasterPos3i);
                Gl.glRasterPos3iv_ = new Gl.Delegates.glRasterPos3iv_(Imports.glRasterPos3iv_);
                Gl.glRasterPos3s = new Gl.Delegates.glRasterPos3s(Imports.glRasterPos3s);
                Gl.glRasterPos3sv_ = new Gl.Delegates.glRasterPos3sv_(Imports.glRasterPos3sv_);
                Gl.glRasterPos4d = new Gl.Delegates.glRasterPos4d(Imports.glRasterPos4d);
                Gl.glRasterPos4dv_ = new Gl.Delegates.glRasterPos4dv_(Imports.glRasterPos4dv_);
                Gl.glRasterPos4f = new Gl.Delegates.glRasterPos4f(Imports.glRasterPos4f);
                Gl.glRasterPos4fv_ = new Gl.Delegates.glRasterPos4fv_(Imports.glRasterPos4fv_);
                Gl.glRasterPos4i = new Gl.Delegates.glRasterPos4i(Imports.glRasterPos4i);
                Gl.glRasterPos4iv_ = new Gl.Delegates.glRasterPos4iv_(Imports.glRasterPos4iv_);
                Gl.glRasterPos4s = new Gl.Delegates.glRasterPos4s(Imports.glRasterPos4s);
                Gl.glRasterPos4sv_ = new Gl.Delegates.glRasterPos4sv_(Imports.glRasterPos4sv_);
                Gl.glRectd = new Gl.Delegates.glRectd(Imports.glRectd);
                Gl.glRectdv_ = new Gl.Delegates.glRectdv_(Imports.glRectdv_);
                Gl.glRectf = new Gl.Delegates.glRectf(Imports.glRectf);
                Gl.glRectfv_ = new Gl.Delegates.glRectfv_(Imports.glRectfv_);
                Gl.glRecti = new Gl.Delegates.glRecti(Imports.glRecti);
                Gl.glRectiv_ = new Gl.Delegates.glRectiv_(Imports.glRectiv_);
                Gl.glRects = new Gl.Delegates.glRects(Imports.glRects);
                Gl.glRectsv_ = new Gl.Delegates.glRectsv_(Imports.glRectsv_);
                Gl.glTexCoord1d = new Gl.Delegates.glTexCoord1d(Imports.glTexCoord1d);
                Gl.glTexCoord1dv_ = new Gl.Delegates.glTexCoord1dv_(Imports.glTexCoord1dv_);
                Gl.glTexCoord1f = new Gl.Delegates.glTexCoord1f(Imports.glTexCoord1f);
                Gl.glTexCoord1fv_ = new Gl.Delegates.glTexCoord1fv_(Imports.glTexCoord1fv_);
                Gl.glTexCoord1i = new Gl.Delegates.glTexCoord1i(Imports.glTexCoord1i);
                Gl.glTexCoord1iv_ = new Gl.Delegates.glTexCoord1iv_(Imports.glTexCoord1iv_);
                Gl.glTexCoord1s = new Gl.Delegates.glTexCoord1s(Imports.glTexCoord1s);
                Gl.glTexCoord1sv_ = new Gl.Delegates.glTexCoord1sv_(Imports.glTexCoord1sv_);
                Gl.glTexCoord2d = new Gl.Delegates.glTexCoord2d(Imports.glTexCoord2d);
                Gl.glTexCoord2dv_ = new Gl.Delegates.glTexCoord2dv_(Imports.glTexCoord2dv_);
                Gl.glTexCoord2f = new Gl.Delegates.glTexCoord2f(Imports.glTexCoord2f);
                Gl.glTexCoord2fv_ = new Gl.Delegates.glTexCoord2fv_(Imports.glTexCoord2fv_);
                Gl.glTexCoord2i = new Gl.Delegates.glTexCoord2i(Imports.glTexCoord2i);
                Gl.glTexCoord2iv_ = new Gl.Delegates.glTexCoord2iv_(Imports.glTexCoord2iv_);
                Gl.glTexCoord2s = new Gl.Delegates.glTexCoord2s(Imports.glTexCoord2s);
                Gl.glTexCoord2sv_ = new Gl.Delegates.glTexCoord2sv_(Imports.glTexCoord2sv_);
                Gl.glTexCoord3d = new Gl.Delegates.glTexCoord3d(Imports.glTexCoord3d);
                Gl.glTexCoord3dv_ = new Gl.Delegates.glTexCoord3dv_(Imports.glTexCoord3dv_);
                Gl.glTexCoord3f = new Gl.Delegates.glTexCoord3f(Imports.glTexCoord3f);
                Gl.glTexCoord3fv_ = new Gl.Delegates.glTexCoord3fv_(Imports.glTexCoord3fv_);
                Gl.glTexCoord3i = new Gl.Delegates.glTexCoord3i(Imports.glTexCoord3i);
                Gl.glTexCoord3iv_ = new Gl.Delegates.glTexCoord3iv_(Imports.glTexCoord3iv_);
                Gl.glTexCoord3s = new Gl.Delegates.glTexCoord3s(Imports.glTexCoord3s);
                Gl.glTexCoord3sv_ = new Gl.Delegates.glTexCoord3sv_(Imports.glTexCoord3sv_);
                Gl.glTexCoord4d = new Gl.Delegates.glTexCoord4d(Imports.glTexCoord4d);
                Gl.glTexCoord4dv_ = new Gl.Delegates.glTexCoord4dv_(Imports.glTexCoord4dv_);
                Gl.glTexCoord4f = new Gl.Delegates.glTexCoord4f(Imports.glTexCoord4f);
                Gl.glTexCoord4fv_ = new Gl.Delegates.glTexCoord4fv_(Imports.glTexCoord4fv_);
                Gl.glTexCoord4i = new Gl.Delegates.glTexCoord4i(Imports.glTexCoord4i);
                Gl.glTexCoord4iv_ = new Gl.Delegates.glTexCoord4iv_(Imports.glTexCoord4iv_);
                Gl.glTexCoord4s = new Gl.Delegates.glTexCoord4s(Imports.glTexCoord4s);
                Gl.glTexCoord4sv_ = new Gl.Delegates.glTexCoord4sv_(Imports.glTexCoord4sv_);
                Gl.glVertex2d = new Gl.Delegates.glVertex2d(Imports.glVertex2d);
                Gl.glVertex2dv_ = new Gl.Delegates.glVertex2dv_(Imports.glVertex2dv_);
                Gl.glVertex2f = new Gl.Delegates.glVertex2f(Imports.glVertex2f);
                Gl.glVertex2fv_ = new Gl.Delegates.glVertex2fv_(Imports.glVertex2fv_);
                Gl.glVertex2i = new Gl.Delegates.glVertex2i(Imports.glVertex2i);
                Gl.glVertex2iv_ = new Gl.Delegates.glVertex2iv_(Imports.glVertex2iv_);
                Gl.glVertex2s = new Gl.Delegates.glVertex2s(Imports.glVertex2s);
                Gl.glVertex2sv_ = new Gl.Delegates.glVertex2sv_(Imports.glVertex2sv_);
                Gl.glVertex3d = new Gl.Delegates.glVertex3d(Imports.glVertex3d);
                Gl.glVertex3dv_ = new Gl.Delegates.glVertex3dv_(Imports.glVertex3dv_);
                Gl.glVertex3f = new Gl.Delegates.glVertex3f(Imports.glVertex3f);
                Gl.glVertex3fv_ = new Gl.Delegates.glVertex3fv_(Imports.glVertex3fv_);
                Gl.glVertex3i = new Gl.Delegates.glVertex3i(Imports.glVertex3i);
                Gl.glVertex3iv_ = new Gl.Delegates.glVertex3iv_(Imports.glVertex3iv_);
                Gl.glVertex3s = new Gl.Delegates.glVertex3s(Imports.glVertex3s);
                Gl.glVertex3sv_ = new Gl.Delegates.glVertex3sv_(Imports.glVertex3sv_);
                Gl.glVertex4d = new Gl.Delegates.glVertex4d(Imports.glVertex4d);
                Gl.glVertex4dv_ = new Gl.Delegates.glVertex4dv_(Imports.glVertex4dv_);
                Gl.glVertex4f = new Gl.Delegates.glVertex4f(Imports.glVertex4f);
                Gl.glVertex4fv_ = new Gl.Delegates.glVertex4fv_(Imports.glVertex4fv_);
                Gl.glVertex4i = new Gl.Delegates.glVertex4i(Imports.glVertex4i);
                Gl.glVertex4iv_ = new Gl.Delegates.glVertex4iv_(Imports.glVertex4iv_);
                Gl.glVertex4s = new Gl.Delegates.glVertex4s(Imports.glVertex4s);
                Gl.glVertex4sv_ = new Gl.Delegates.glVertex4sv_(Imports.glVertex4sv_);
                Gl.glClipPlane_ = new Gl.Delegates.glClipPlane_(Imports.glClipPlane_);
                Gl.glColorMaterial = new Gl.Delegates.glColorMaterial(Imports.glColorMaterial);
                Gl.glCullFace = new Gl.Delegates.glCullFace(Imports.glCullFace);
                Gl.glFogf = new Gl.Delegates.glFogf(Imports.glFogf);
                Gl.glFogfv_ = new Gl.Delegates.glFogfv_(Imports.glFogfv_);
                Gl.glFogi = new Gl.Delegates.glFogi(Imports.glFogi);
                Gl.glFogiv_ = new Gl.Delegates.glFogiv_(Imports.glFogiv_);
                Gl.glFrontFace = new Gl.Delegates.glFrontFace(Imports.glFrontFace);
                Gl.glHint = new Gl.Delegates.glHint(Imports.glHint);
                Gl.glLightf = new Gl.Delegates.glLightf(Imports.glLightf);
                Gl.glLightfv_ = new Gl.Delegates.glLightfv_(Imports.glLightfv_);
                Gl.glLighti = new Gl.Delegates.glLighti(Imports.glLighti);
                Gl.glLightiv_ = new Gl.Delegates.glLightiv_(Imports.glLightiv_);
                Gl.glLightModelf = new Gl.Delegates.glLightModelf(Imports.glLightModelf);
                Gl.glLightModelfv_ = new Gl.Delegates.glLightModelfv_(Imports.glLightModelfv_);
                Gl.glLightModeli = new Gl.Delegates.glLightModeli(Imports.glLightModeli);
                Gl.glLightModeliv_ = new Gl.Delegates.glLightModeliv_(Imports.glLightModeliv_);
                Gl.glLineStipple_ = new Gl.Delegates.glLineStipple_(Imports.glLineStipple_);
                Gl.glLineWidth = new Gl.Delegates.glLineWidth(Imports.glLineWidth);
                Gl.glMaterialf = new Gl.Delegates.glMaterialf(Imports.glMaterialf);
                Gl.glMaterialfv_ = new Gl.Delegates.glMaterialfv_(Imports.glMaterialfv_);
                Gl.glMateriali = new Gl.Delegates.glMateriali(Imports.glMateriali);
                Gl.glMaterialiv_ = new Gl.Delegates.glMaterialiv_(Imports.glMaterialiv_);
                Gl.glPointSize = new Gl.Delegates.glPointSize(Imports.glPointSize);
                Gl.glPolygonMode = new Gl.Delegates.glPolygonMode(Imports.glPolygonMode);
                Gl.glPolygonStipple_ = new Gl.Delegates.glPolygonStipple_(Imports.glPolygonStipple_);
                Gl.glScissor = new Gl.Delegates.glScissor(Imports.glScissor);
                Gl.glShadeModel = new Gl.Delegates.glShadeModel(Imports.glShadeModel);
                Gl.glTexParameterf = new Gl.Delegates.glTexParameterf(Imports.glTexParameterf);
                Gl.glTexParameterfv_ = new Gl.Delegates.glTexParameterfv_(Imports.glTexParameterfv_);
                Gl.glTexParameteri = new Gl.Delegates.glTexParameteri(Imports.glTexParameteri);
                Gl.glTexParameteriv_ = new Gl.Delegates.glTexParameteriv_(Imports.glTexParameteriv_);
                Gl.glTexImage1D_ = new Gl.Delegates.glTexImage1D_(Imports.glTexImage1D_);
                Gl.glTexImage2D_ = new Gl.Delegates.glTexImage2D_(Imports.glTexImage2D_);
                Gl.glTexEnvf = new Gl.Delegates.glTexEnvf(Imports.glTexEnvf);
                Gl.glTexEnvfv_ = new Gl.Delegates.glTexEnvfv_(Imports.glTexEnvfv_);
                Gl.glTexEnvi = new Gl.Delegates.glTexEnvi(Imports.glTexEnvi);
                Gl.glTexEnviv_ = new Gl.Delegates.glTexEnviv_(Imports.glTexEnviv_);
                Gl.glTexGend = new Gl.Delegates.glTexGend(Imports.glTexGend);
                Gl.glTexGendv_ = new Gl.Delegates.glTexGendv_(Imports.glTexGendv_);
                Gl.glTexGenf = new Gl.Delegates.glTexGenf(Imports.glTexGenf);
                Gl.glTexGenfv_ = new Gl.Delegates.glTexGenfv_(Imports.glTexGenfv_);
                Gl.glTexGeni = new Gl.Delegates.glTexGeni(Imports.glTexGeni);
                Gl.glTexGeniv_ = new Gl.Delegates.glTexGeniv_(Imports.glTexGeniv_);
                Gl.glFeedbackBuffer = new Gl.Delegates.glFeedbackBuffer(Imports.glFeedbackBuffer);
                Gl.glSelectBuffer = new Gl.Delegates.glSelectBuffer(Imports.glSelectBuffer);
                Gl.glRenderMode = new Gl.Delegates.glRenderMode(Imports.glRenderMode);
                Gl.glInitNames = new Gl.Delegates.glInitNames(Imports.glInitNames);
                Gl.glLoadName = new Gl.Delegates.glLoadName(Imports.glLoadName);
                Gl.glPassThrough = new Gl.Delegates.glPassThrough(Imports.glPassThrough);
                Gl.glPopName = new Gl.Delegates.glPopName(Imports.glPopName);
                Gl.glPushName = new Gl.Delegates.glPushName(Imports.glPushName);
                Gl.glDrawBuffer = new Gl.Delegates.glDrawBuffer(Imports.glDrawBuffer);
                Gl.glClear = new Gl.Delegates.glClear(Imports.glClear);
                Gl.glClearAccum = new Gl.Delegates.glClearAccum(Imports.glClearAccum);
                Gl.glClearIndex = new Gl.Delegates.glClearIndex(Imports.glClearIndex);
                Gl.glClearColor = new Gl.Delegates.glClearColor(Imports.glClearColor);
                Gl.glClearStencil = new Gl.Delegates.glClearStencil(Imports.glClearStencil);
                Gl.glClearDepth = new Gl.Delegates.glClearDepth(Imports.glClearDepth);
                Gl.glStencilMask = new Gl.Delegates.glStencilMask(Imports.glStencilMask);
                Gl.glColorMask = new Gl.Delegates.glColorMask(Imports.glColorMask);
                Gl.glDepthMask = new Gl.Delegates.glDepthMask(Imports.glDepthMask);
                Gl.glIndexMask = new Gl.Delegates.glIndexMask(Imports.glIndexMask);
                Gl.glAccum = new Gl.Delegates.glAccum(Imports.glAccum);
                Gl.glDisable = new Gl.Delegates.glDisable(Imports.glDisable);
                Gl.glEnable = new Gl.Delegates.glEnable(Imports.glEnable);
                Gl.glFinish = new Gl.Delegates.glFinish(Imports.glFinish);
                Gl.glFlush = new Gl.Delegates.glFlush(Imports.glFlush);
                Gl.glPopAttrib = new Gl.Delegates.glPopAttrib(Imports.glPopAttrib);
                Gl.glPushAttrib = new Gl.Delegates.glPushAttrib(Imports.glPushAttrib);
                Gl.glMap1d_ = new Gl.Delegates.glMap1d_(Imports.glMap1d_);
                Gl.glMap1f_ = new Gl.Delegates.glMap1f_(Imports.glMap1f_);
                Gl.glMap2d_ = new Gl.Delegates.glMap2d_(Imports.glMap2d_);
                Gl.glMap2f_ = new Gl.Delegates.glMap2f_(Imports.glMap2f_);
                Gl.glMapGrid1d = new Gl.Delegates.glMapGrid1d(Imports.glMapGrid1d);
                Gl.glMapGrid1f = new Gl.Delegates.glMapGrid1f(Imports.glMapGrid1f);
                Gl.glMapGrid2d = new Gl.Delegates.glMapGrid2d(Imports.glMapGrid2d);
                Gl.glMapGrid2f = new Gl.Delegates.glMapGrid2f(Imports.glMapGrid2f);
                Gl.glEvalCoord1d = new Gl.Delegates.glEvalCoord1d(Imports.glEvalCoord1d);
                Gl.glEvalCoord1dv_ = new Gl.Delegates.glEvalCoord1dv_(Imports.glEvalCoord1dv_);
                Gl.glEvalCoord1f = new Gl.Delegates.glEvalCoord1f(Imports.glEvalCoord1f);
                Gl.glEvalCoord1fv_ = new Gl.Delegates.glEvalCoord1fv_(Imports.glEvalCoord1fv_);
                Gl.glEvalCoord2d = new Gl.Delegates.glEvalCoord2d(Imports.glEvalCoord2d);
                Gl.glEvalCoord2dv_ = new Gl.Delegates.glEvalCoord2dv_(Imports.glEvalCoord2dv_);
                Gl.glEvalCoord2f = new Gl.Delegates.glEvalCoord2f(Imports.glEvalCoord2f);
                Gl.glEvalCoord2fv_ = new Gl.Delegates.glEvalCoord2fv_(Imports.glEvalCoord2fv_);
                Gl.glEvalMesh1 = new Gl.Delegates.glEvalMesh1(Imports.glEvalMesh1);
                Gl.glEvalPoint1 = new Gl.Delegates.glEvalPoint1(Imports.glEvalPoint1);
                Gl.glEvalMesh2 = new Gl.Delegates.glEvalMesh2(Imports.glEvalMesh2);
                Gl.glEvalPoint2 = new Gl.Delegates.glEvalPoint2(Imports.glEvalPoint2);
                Gl.glAlphaFunc = new Gl.Delegates.glAlphaFunc(Imports.glAlphaFunc);
                Gl.glBlendFunc = new Gl.Delegates.glBlendFunc(Imports.glBlendFunc);
                Gl.glLogicOp = new Gl.Delegates.glLogicOp(Imports.glLogicOp);
                Gl.glStencilFunc = new Gl.Delegates.glStencilFunc(Imports.glStencilFunc);
                Gl.glStencilOp = new Gl.Delegates.glStencilOp(Imports.glStencilOp);
                Gl.glDepthFunc = new Gl.Delegates.glDepthFunc(Imports.glDepthFunc);
                Gl.glPixelZoom = new Gl.Delegates.glPixelZoom(Imports.glPixelZoom);
                Gl.glPixelTransferf = new Gl.Delegates.glPixelTransferf(Imports.glPixelTransferf);
                Gl.glPixelTransferi = new Gl.Delegates.glPixelTransferi(Imports.glPixelTransferi);
                Gl.glPixelStoref = new Gl.Delegates.glPixelStoref(Imports.glPixelStoref);
                Gl.glPixelStorei = new Gl.Delegates.glPixelStorei(Imports.glPixelStorei);
                Gl.glPixelMapfv_ = new Gl.Delegates.glPixelMapfv_(Imports.glPixelMapfv_);
                Gl.glPixelMapuiv_ = new Gl.Delegates.glPixelMapuiv_(Imports.glPixelMapuiv_);
                Gl.glPixelMapusv_ = new Gl.Delegates.glPixelMapusv_(Imports.glPixelMapusv_);
                Gl.glReadBuffer = new Gl.Delegates.glReadBuffer(Imports.glReadBuffer);
                Gl.glCopyPixels = new Gl.Delegates.glCopyPixels(Imports.glCopyPixels);
                Gl.glReadPixels_ = new Gl.Delegates.glReadPixels_(Imports.glReadPixels_);
                Gl.glDrawPixels_ = new Gl.Delegates.glDrawPixels_(Imports.glDrawPixels_);
                Gl.glGetBooleanv = new Gl.Delegates.glGetBooleanv(Imports.glGetBooleanv);
                Gl.glGetClipPlane = new Gl.Delegates.glGetClipPlane(Imports.glGetClipPlane);
                Gl.glGetDoublev = new Gl.Delegates.glGetDoublev(Imports.glGetDoublev);
                Gl.glGetError = new Gl.Delegates.glGetError(Imports.glGetError);
                Gl.glGetFloatv = new Gl.Delegates.glGetFloatv(Imports.glGetFloatv);
                Gl.glGetIntegerv = new Gl.Delegates.glGetIntegerv(Imports.glGetIntegerv);
                Gl.glGetLightfv = new Gl.Delegates.glGetLightfv(Imports.glGetLightfv);
                Gl.glGetLightiv = new Gl.Delegates.glGetLightiv(Imports.glGetLightiv);
                Gl.glGetMapdv = new Gl.Delegates.glGetMapdv(Imports.glGetMapdv);
                Gl.glGetMapfv = new Gl.Delegates.glGetMapfv(Imports.glGetMapfv);
                Gl.glGetMapiv = new Gl.Delegates.glGetMapiv(Imports.glGetMapiv);
                Gl.glGetMaterialfv = new Gl.Delegates.glGetMaterialfv(Imports.glGetMaterialfv);
                Gl.glGetMaterialiv = new Gl.Delegates.glGetMaterialiv(Imports.glGetMaterialiv);
                Gl.glGetPixelMapfv = new Gl.Delegates.glGetPixelMapfv(Imports.glGetPixelMapfv);
                Gl.glGetPixelMapuiv = new Gl.Delegates.glGetPixelMapuiv(Imports.glGetPixelMapuiv);
                Gl.glGetPixelMapusv = new Gl.Delegates.glGetPixelMapusv(Imports.glGetPixelMapusv);
                Gl.glGetPolygonStipple = new Gl.Delegates.glGetPolygonStipple(Imports.glGetPolygonStipple);
                Gl.glGetString_ = new Gl.Delegates.glGetString_(Imports.glGetString_);
                Gl.glGetTexEnvfv = new Gl.Delegates.glGetTexEnvfv(Imports.glGetTexEnvfv);
                Gl.glGetTexEnviv = new Gl.Delegates.glGetTexEnviv(Imports.glGetTexEnviv);
                Gl.glGetTexGendv = new Gl.Delegates.glGetTexGendv(Imports.glGetTexGendv);
                Gl.glGetTexGenfv = new Gl.Delegates.glGetTexGenfv(Imports.glGetTexGenfv);
                Gl.glGetTexGeniv = new Gl.Delegates.glGetTexGeniv(Imports.glGetTexGeniv);
                Gl.glGetTexImage_ = new Gl.Delegates.glGetTexImage_(Imports.glGetTexImage_);
                Gl.glGetTexParameterfv = new Gl.Delegates.glGetTexParameterfv(Imports.glGetTexParameterfv);
                Gl.glGetTexParameteriv = new Gl.Delegates.glGetTexParameteriv(Imports.glGetTexParameteriv);
                Gl.glGetTexLevelParameterfv = new Gl.Delegates.glGetTexLevelParameterfv(Imports.glGetTexLevelParameterfv);
                Gl.glGetTexLevelParameteriv = new Gl.Delegates.glGetTexLevelParameteriv(Imports.glGetTexLevelParameteriv);
                Gl.glIsEnabled = new Gl.Delegates.glIsEnabled(Imports.glIsEnabled);
                Gl.glIsList = new Gl.Delegates.glIsList(Imports.glIsList);
                Gl.glDepthRange = new Gl.Delegates.glDepthRange(Imports.glDepthRange);
                Gl.glFrustum = new Gl.Delegates.glFrustum(Imports.glFrustum);
                Gl.glLoadIdentity = new Gl.Delegates.glLoadIdentity(Imports.glLoadIdentity);
                Gl.glLoadMatrixf_ = new Gl.Delegates.glLoadMatrixf_(Imports.glLoadMatrixf_);
                Gl.glLoadMatrixd_ = new Gl.Delegates.glLoadMatrixd_(Imports.glLoadMatrixd_);
                Gl.glMatrixMode = new Gl.Delegates.glMatrixMode(Imports.glMatrixMode);
                Gl.glMultMatrixf_ = new Gl.Delegates.glMultMatrixf_(Imports.glMultMatrixf_);
                Gl.glMultMatrixd_ = new Gl.Delegates.glMultMatrixd_(Imports.glMultMatrixd_);
                Gl.glOrtho = new Gl.Delegates.glOrtho(Imports.glOrtho);
                Gl.glPopMatrix = new Gl.Delegates.glPopMatrix(Imports.glPopMatrix);
                Gl.glPushMatrix = new Gl.Delegates.glPushMatrix(Imports.glPushMatrix);
                Gl.glRotated = new Gl.Delegates.glRotated(Imports.glRotated);
                Gl.glRotatef = new Gl.Delegates.glRotatef(Imports.glRotatef);
                Gl.glScaled = new Gl.Delegates.glScaled(Imports.glScaled);
                Gl.glScalef = new Gl.Delegates.glScalef(Imports.glScalef);
                Gl.glTranslated = new Gl.Delegates.glTranslated(Imports.glTranslated);
                Gl.glTranslatef = new Gl.Delegates.glTranslatef(Imports.glTranslatef);
                Gl.glViewport = new Gl.Delegates.glViewport(Imports.glViewport);
                Gl.glArrayElement = new Gl.Delegates.glArrayElement(Imports.glArrayElement);
                Gl.glColorPointer_ = new Gl.Delegates.glColorPointer_(Imports.glColorPointer_);
                Gl.glDisableClientState = new Gl.Delegates.glDisableClientState(Imports.glDisableClientState);
                Gl.glDrawArrays = new Gl.Delegates.glDrawArrays(Imports.glDrawArrays);
                Gl.glDrawElements_ = new Gl.Delegates.glDrawElements_(Imports.glDrawElements_);
                Gl.glEdgeFlagPointer_ = new Gl.Delegates.glEdgeFlagPointer_(Imports.glEdgeFlagPointer_);
                Gl.glEnableClientState = new Gl.Delegates.glEnableClientState(Imports.glEnableClientState);
                Gl.glGetPointerv = new Gl.Delegates.glGetPointerv(Imports.glGetPointerv);
                Gl.glIndexPointer_ = new Gl.Delegates.glIndexPointer_(Imports.glIndexPointer_);
                Gl.glInterleavedArrays_ = new Gl.Delegates.glInterleavedArrays_(Imports.glInterleavedArrays_);
                Gl.glNormalPointer_ = new Gl.Delegates.glNormalPointer_(Imports.glNormalPointer_);
                Gl.glTexCoordPointer_ = new Gl.Delegates.glTexCoordPointer_(Imports.glTexCoordPointer_);
                Gl.glVertexPointer_ = new Gl.Delegates.glVertexPointer_(Imports.glVertexPointer_);
                Gl.glPolygonOffset = new Gl.Delegates.glPolygonOffset(Imports.glPolygonOffset);
                Gl.glCopyTexImage1D = new Gl.Delegates.glCopyTexImage1D(Imports.glCopyTexImage1D);
                Gl.glCopyTexImage2D = new Gl.Delegates.glCopyTexImage2D(Imports.glCopyTexImage2D);
                Gl.glCopyTexSubImage1D = new Gl.Delegates.glCopyTexSubImage1D(Imports.glCopyTexSubImage1D);
                Gl.glCopyTexSubImage2D = new Gl.Delegates.glCopyTexSubImage2D(Imports.glCopyTexSubImage2D);
                Gl.glTexSubImage1D_ = new Gl.Delegates.glTexSubImage1D_(Imports.glTexSubImage1D_);
                Gl.glTexSubImage2D_ = new Gl.Delegates.glTexSubImage2D_(Imports.glTexSubImage2D_);
                Gl.glAreTexturesResident_ = new Gl.Delegates.glAreTexturesResident_(Imports.glAreTexturesResident_);
                Gl.glBindTexture = new Gl.Delegates.glBindTexture(Imports.glBindTexture);
                Gl.glDeleteTextures_ = new Gl.Delegates.glDeleteTextures_(Imports.glDeleteTextures_);
                Gl.glGenTextures = new Gl.Delegates.glGenTextures(Imports.glGenTextures);
                Gl.glIsTexture = new Gl.Delegates.glIsTexture(Imports.glIsTexture);
                Gl.glPrioritizeTextures_ = new Gl.Delegates.glPrioritizeTextures_(Imports.glPrioritizeTextures_);
                Gl.glIndexub = new Gl.Delegates.glIndexub(Imports.glIndexub);
                Gl.glIndexubv_ = new Gl.Delegates.glIndexubv_(Imports.glIndexubv_);
                Gl.glPopClientAttrib = new Gl.Delegates.glPopClientAttrib(Imports.glPopClientAttrib);
                Gl.glPushClientAttrib = new Gl.Delegates.glPushClientAttrib(Imports.glPushClientAttrib);
                Gl.glBlendColor = new Gl.Delegates.glBlendColor(Imports.glBlendColor);
                Gl.glBlendEquation = new Gl.Delegates.glBlendEquation(Imports.glBlendEquation);
                Gl.glDrawRangeElements_ = new Gl.Delegates.glDrawRangeElements_(Imports.glDrawRangeElements_);
                Gl.glColorTable_ = new Gl.Delegates.glColorTable_(Imports.glColorTable_);
                Gl.glColorTableParameterfv_ = new Gl.Delegates.glColorTableParameterfv_(Imports.glColorTableParameterfv_);
                Gl.glColorTableParameteriv_ = new Gl.Delegates.glColorTableParameteriv_(Imports.glColorTableParameteriv_);
                Gl.glCopyColorTable = new Gl.Delegates.glCopyColorTable(Imports.glCopyColorTable);
                Gl.glGetColorTable_ = new Gl.Delegates.glGetColorTable_(Imports.glGetColorTable_);
                Gl.glGetColorTableParameterfv = new Gl.Delegates.glGetColorTableParameterfv(Imports.glGetColorTableParameterfv);
                Gl.glGetColorTableParameteriv = new Gl.Delegates.glGetColorTableParameteriv(Imports.glGetColorTableParameteriv);
                Gl.glColorSubTable_ = new Gl.Delegates.glColorSubTable_(Imports.glColorSubTable_);
                Gl.glCopyColorSubTable = new Gl.Delegates.glCopyColorSubTable(Imports.glCopyColorSubTable);
                Gl.glConvolutionFilter1D_ = new Gl.Delegates.glConvolutionFilter1D_(Imports.glConvolutionFilter1D_);
                Gl.glConvolutionFilter2D_ = new Gl.Delegates.glConvolutionFilter2D_(Imports.glConvolutionFilter2D_);
                Gl.glConvolutionParameterf = new Gl.Delegates.glConvolutionParameterf(Imports.glConvolutionParameterf);
                Gl.glConvolutionParameterfv_ = new Gl.Delegates.glConvolutionParameterfv_(Imports.glConvolutionParameterfv_);
                Gl.glConvolutionParameteri = new Gl.Delegates.glConvolutionParameteri(Imports.glConvolutionParameteri);
                Gl.glConvolutionParameteriv_ = new Gl.Delegates.glConvolutionParameteriv_(Imports.glConvolutionParameteriv_);
                Gl.glCopyConvolutionFilter1D = new Gl.Delegates.glCopyConvolutionFilter1D(Imports.glCopyConvolutionFilter1D);
                Gl.glCopyConvolutionFilter2D = new Gl.Delegates.glCopyConvolutionFilter2D(Imports.glCopyConvolutionFilter2D);
                Gl.glGetConvolutionFilter_ = new Gl.Delegates.glGetConvolutionFilter_(Imports.glGetConvolutionFilter_);
                Gl.glGetConvolutionParameterfv = new Gl.Delegates.glGetConvolutionParameterfv(Imports.glGetConvolutionParameterfv);
                Gl.glGetConvolutionParameteriv = new Gl.Delegates.glGetConvolutionParameteriv(Imports.glGetConvolutionParameteriv);
                Gl.glGetSeparableFilter_ = new Gl.Delegates.glGetSeparableFilter_(Imports.glGetSeparableFilter_);
                Gl.glSeparableFilter2D_ = new Gl.Delegates.glSeparableFilter2D_(Imports.glSeparableFilter2D_);
                Gl.glGetHistogram_ = new Gl.Delegates.glGetHistogram_(Imports.glGetHistogram_);
                Gl.glGetHistogramParameterfv = new Gl.Delegates.glGetHistogramParameterfv(Imports.glGetHistogramParameterfv);
                Gl.glGetHistogramParameteriv = new Gl.Delegates.glGetHistogramParameteriv(Imports.glGetHistogramParameteriv);
                Gl.glGetMinmax_ = new Gl.Delegates.glGetMinmax_(Imports.glGetMinmax_);
                Gl.glGetMinmaxParameterfv = new Gl.Delegates.glGetMinmaxParameterfv(Imports.glGetMinmaxParameterfv);
                Gl.glGetMinmaxParameteriv = new Gl.Delegates.glGetMinmaxParameteriv(Imports.glGetMinmaxParameteriv);
                Gl.glHistogram = new Gl.Delegates.glHistogram(Imports.glHistogram);
                Gl.glMinmax = new Gl.Delegates.glMinmax(Imports.glMinmax);
                Gl.glResetHistogram = new Gl.Delegates.glResetHistogram(Imports.glResetHistogram);
                Gl.glResetMinmax = new Gl.Delegates.glResetMinmax(Imports.glResetMinmax);
                Gl.glTexImage3D_ = new Gl.Delegates.glTexImage3D_(Imports.glTexImage3D_);
                Gl.glTexSubImage3D_ = new Gl.Delegates.glTexSubImage3D_(Imports.glTexSubImage3D_);
                Gl.glCopyTexSubImage3D = new Gl.Delegates.glCopyTexSubImage3D(Imports.glCopyTexSubImage3D);
                Gl.glActiveTexture = new Gl.Delegates.glActiveTexture(Imports.glActiveTexture);
                Gl.glClientActiveTexture = new Gl.Delegates.glClientActiveTexture(Imports.glClientActiveTexture);
                Gl.glMultiTexCoord1d = new Gl.Delegates.glMultiTexCoord1d(Imports.glMultiTexCoord1d);
                Gl.glMultiTexCoord1dv_ = new Gl.Delegates.glMultiTexCoord1dv_(Imports.glMultiTexCoord1dv_);
                Gl.glMultiTexCoord1f = new Gl.Delegates.glMultiTexCoord1f(Imports.glMultiTexCoord1f);
                Gl.glMultiTexCoord1fv_ = new Gl.Delegates.glMultiTexCoord1fv_(Imports.glMultiTexCoord1fv_);
                Gl.glMultiTexCoord1i = new Gl.Delegates.glMultiTexCoord1i(Imports.glMultiTexCoord1i);
                Gl.glMultiTexCoord1iv_ = new Gl.Delegates.glMultiTexCoord1iv_(Imports.glMultiTexCoord1iv_);
                Gl.glMultiTexCoord1s = new Gl.Delegates.glMultiTexCoord1s(Imports.glMultiTexCoord1s);
                Gl.glMultiTexCoord1sv_ = new Gl.Delegates.glMultiTexCoord1sv_(Imports.glMultiTexCoord1sv_);
                Gl.glMultiTexCoord2d = new Gl.Delegates.glMultiTexCoord2d(Imports.glMultiTexCoord2d);
                Gl.glMultiTexCoord2dv_ = new Gl.Delegates.glMultiTexCoord2dv_(Imports.glMultiTexCoord2dv_);
                Gl.glMultiTexCoord2f = new Gl.Delegates.glMultiTexCoord2f(Imports.glMultiTexCoord2f);
                Gl.glMultiTexCoord2fv_ = new Gl.Delegates.glMultiTexCoord2fv_(Imports.glMultiTexCoord2fv_);
                Gl.glMultiTexCoord2i = new Gl.Delegates.glMultiTexCoord2i(Imports.glMultiTexCoord2i);
                Gl.glMultiTexCoord2iv_ = new Gl.Delegates.glMultiTexCoord2iv_(Imports.glMultiTexCoord2iv_);
                Gl.glMultiTexCoord2s = new Gl.Delegates.glMultiTexCoord2s(Imports.glMultiTexCoord2s);
                Gl.glMultiTexCoord2sv_ = new Gl.Delegates.glMultiTexCoord2sv_(Imports.glMultiTexCoord2sv_);
                Gl.glMultiTexCoord3d = new Gl.Delegates.glMultiTexCoord3d(Imports.glMultiTexCoord3d);
                Gl.glMultiTexCoord3dv_ = new Gl.Delegates.glMultiTexCoord3dv_(Imports.glMultiTexCoord3dv_);
                Gl.glMultiTexCoord3f = new Gl.Delegates.glMultiTexCoord3f(Imports.glMultiTexCoord3f);
                Gl.glMultiTexCoord3fv_ = new Gl.Delegates.glMultiTexCoord3fv_(Imports.glMultiTexCoord3fv_);
                Gl.glMultiTexCoord3i = new Gl.Delegates.glMultiTexCoord3i(Imports.glMultiTexCoord3i);
                Gl.glMultiTexCoord3iv_ = new Gl.Delegates.glMultiTexCoord3iv_(Imports.glMultiTexCoord3iv_);
                Gl.glMultiTexCoord3s = new Gl.Delegates.glMultiTexCoord3s(Imports.glMultiTexCoord3s);
                Gl.glMultiTexCoord3sv_ = new Gl.Delegates.glMultiTexCoord3sv_(Imports.glMultiTexCoord3sv_);
                Gl.glMultiTexCoord4d = new Gl.Delegates.glMultiTexCoord4d(Imports.glMultiTexCoord4d);
                Gl.glMultiTexCoord4dv_ = new Gl.Delegates.glMultiTexCoord4dv_(Imports.glMultiTexCoord4dv_);
                Gl.glMultiTexCoord4f = new Gl.Delegates.glMultiTexCoord4f(Imports.glMultiTexCoord4f);
                Gl.glMultiTexCoord4fv_ = new Gl.Delegates.glMultiTexCoord4fv_(Imports.glMultiTexCoord4fv_);
                Gl.glMultiTexCoord4i = new Gl.Delegates.glMultiTexCoord4i(Imports.glMultiTexCoord4i);
                Gl.glMultiTexCoord4iv_ = new Gl.Delegates.glMultiTexCoord4iv_(Imports.glMultiTexCoord4iv_);
                Gl.glMultiTexCoord4s = new Gl.Delegates.glMultiTexCoord4s(Imports.glMultiTexCoord4s);
                Gl.glMultiTexCoord4sv_ = new Gl.Delegates.glMultiTexCoord4sv_(Imports.glMultiTexCoord4sv_);
                Gl.glLoadTransposeMatrixf_ = new Gl.Delegates.glLoadTransposeMatrixf_(Imports.glLoadTransposeMatrixf_);
                Gl.glLoadTransposeMatrixd_ = new Gl.Delegates.glLoadTransposeMatrixd_(Imports.glLoadTransposeMatrixd_);
                Gl.glMultTransposeMatrixf_ = new Gl.Delegates.glMultTransposeMatrixf_(Imports.glMultTransposeMatrixf_);
                Gl.glMultTransposeMatrixd_ = new Gl.Delegates.glMultTransposeMatrixd_(Imports.glMultTransposeMatrixd_);
                Gl.glSampleCoverage = new Gl.Delegates.glSampleCoverage(Imports.glSampleCoverage);
                Gl.glCompressedTexImage3D_ = new Gl.Delegates.glCompressedTexImage3D_(Imports.glCompressedTexImage3D_);
                Gl.glCompressedTexImage2D_ = new Gl.Delegates.glCompressedTexImage2D_(Imports.glCompressedTexImage2D_);
                Gl.glCompressedTexImage1D_ = new Gl.Delegates.glCompressedTexImage1D_(Imports.glCompressedTexImage1D_);
                Gl.glCompressedTexSubImage3D_ = new Gl.Delegates.glCompressedTexSubImage3D_(Imports.glCompressedTexSubImage3D_);
                Gl.glCompressedTexSubImage2D_ = new Gl.Delegates.glCompressedTexSubImage2D_(Imports.glCompressedTexSubImage2D_);
                Gl.glCompressedTexSubImage1D_ = new Gl.Delegates.glCompressedTexSubImage1D_(Imports.glCompressedTexSubImage1D_);
                Gl.glGetCompressedTexImage_ = new Gl.Delegates.glGetCompressedTexImage_(Imports.glGetCompressedTexImage_);
                Gl.glBlendFuncSeparate = new Gl.Delegates.glBlendFuncSeparate(Imports.glBlendFuncSeparate);
                Gl.glFogCoordf = new Gl.Delegates.glFogCoordf(Imports.glFogCoordf);
                Gl.glFogCoordfv_ = new Gl.Delegates.glFogCoordfv_(Imports.glFogCoordfv_);
                Gl.glFogCoordd = new Gl.Delegates.glFogCoordd(Imports.glFogCoordd);
                Gl.glFogCoorddv_ = new Gl.Delegates.glFogCoorddv_(Imports.glFogCoorddv_);
                Gl.glFogCoordPointer_ = new Gl.Delegates.glFogCoordPointer_(Imports.glFogCoordPointer_);
                Gl.glMultiDrawArrays = new Gl.Delegates.glMultiDrawArrays(Imports.glMultiDrawArrays);
                Gl.glMultiDrawElements_ = new Gl.Delegates.glMultiDrawElements_(Imports.glMultiDrawElements_);
                Gl.glPointParameterf = new Gl.Delegates.glPointParameterf(Imports.glPointParameterf);
                Gl.glPointParameterfv_ = new Gl.Delegates.glPointParameterfv_(Imports.glPointParameterfv_);
                Gl.glPointParameteri = new Gl.Delegates.glPointParameteri(Imports.glPointParameteri);
                Gl.glPointParameteriv_ = new Gl.Delegates.glPointParameteriv_(Imports.glPointParameteriv_);
                Gl.glSecondaryColor3b = new Gl.Delegates.glSecondaryColor3b(Imports.glSecondaryColor3b);
                Gl.glSecondaryColor3bv_ = new Gl.Delegates.glSecondaryColor3bv_(Imports.glSecondaryColor3bv_);
                Gl.glSecondaryColor3d = new Gl.Delegates.glSecondaryColor3d(Imports.glSecondaryColor3d);
                Gl.glSecondaryColor3dv_ = new Gl.Delegates.glSecondaryColor3dv_(Imports.glSecondaryColor3dv_);
                Gl.glSecondaryColor3f = new Gl.Delegates.glSecondaryColor3f(Imports.glSecondaryColor3f);
                Gl.glSecondaryColor3fv_ = new Gl.Delegates.glSecondaryColor3fv_(Imports.glSecondaryColor3fv_);
                Gl.glSecondaryColor3i = new Gl.Delegates.glSecondaryColor3i(Imports.glSecondaryColor3i);
                Gl.glSecondaryColor3iv_ = new Gl.Delegates.glSecondaryColor3iv_(Imports.glSecondaryColor3iv_);
                Gl.glSecondaryColor3s = new Gl.Delegates.glSecondaryColor3s(Imports.glSecondaryColor3s);
                Gl.glSecondaryColor3sv_ = new Gl.Delegates.glSecondaryColor3sv_(Imports.glSecondaryColor3sv_);
                Gl.glSecondaryColor3ub = new Gl.Delegates.glSecondaryColor3ub(Imports.glSecondaryColor3ub);
                Gl.glSecondaryColor3ubv_ = new Gl.Delegates.glSecondaryColor3ubv_(Imports.glSecondaryColor3ubv_);
                Gl.glSecondaryColor3ui = new Gl.Delegates.glSecondaryColor3ui(Imports.glSecondaryColor3ui);
                Gl.glSecondaryColor3uiv_ = new Gl.Delegates.glSecondaryColor3uiv_(Imports.glSecondaryColor3uiv_);
                Gl.glSecondaryColor3us = new Gl.Delegates.glSecondaryColor3us(Imports.glSecondaryColor3us);
                Gl.glSecondaryColor3usv_ = new Gl.Delegates.glSecondaryColor3usv_(Imports.glSecondaryColor3usv_);
                Gl.glSecondaryColorPointer_ = new Gl.Delegates.glSecondaryColorPointer_(Imports.glSecondaryColorPointer_);
                Gl.glWindowPos2d = new Gl.Delegates.glWindowPos2d(Imports.glWindowPos2d);
                Gl.glWindowPos2dv_ = new Gl.Delegates.glWindowPos2dv_(Imports.glWindowPos2dv_);
                Gl.glWindowPos2f = new Gl.Delegates.glWindowPos2f(Imports.glWindowPos2f);
                Gl.glWindowPos2fv_ = new Gl.Delegates.glWindowPos2fv_(Imports.glWindowPos2fv_);
                Gl.glWindowPos2i = new Gl.Delegates.glWindowPos2i(Imports.glWindowPos2i);
                Gl.glWindowPos2iv_ = new Gl.Delegates.glWindowPos2iv_(Imports.glWindowPos2iv_);
                Gl.glWindowPos2s = new Gl.Delegates.glWindowPos2s(Imports.glWindowPos2s);
                Gl.glWindowPos2sv_ = new Gl.Delegates.glWindowPos2sv_(Imports.glWindowPos2sv_);
                Gl.glWindowPos3d = new Gl.Delegates.glWindowPos3d(Imports.glWindowPos3d);
                Gl.glWindowPos3dv_ = new Gl.Delegates.glWindowPos3dv_(Imports.glWindowPos3dv_);
                Gl.glWindowPos3f = new Gl.Delegates.glWindowPos3f(Imports.glWindowPos3f);
                Gl.glWindowPos3fv_ = new Gl.Delegates.glWindowPos3fv_(Imports.glWindowPos3fv_);
                Gl.glWindowPos3i = new Gl.Delegates.glWindowPos3i(Imports.glWindowPos3i);
                Gl.glWindowPos3iv_ = new Gl.Delegates.glWindowPos3iv_(Imports.glWindowPos3iv_);
                Gl.glWindowPos3s = new Gl.Delegates.glWindowPos3s(Imports.glWindowPos3s);
                Gl.glWindowPos3sv_ = new Gl.Delegates.glWindowPos3sv_(Imports.glWindowPos3sv_);
                #endregion
            }
            else if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                #region X11 Core
                Gl.glNewList = new Gl.Delegates.glNewList(Imports.glNewList);
                Gl.glEndList = new Gl.Delegates.glEndList(Imports.glEndList);
                Gl.glCallList = new Gl.Delegates.glCallList(Imports.glCallList);
                Gl.glCallLists_ = new Gl.Delegates.glCallLists_(Imports.glCallLists_);
                Gl.glDeleteLists = new Gl.Delegates.glDeleteLists(Imports.glDeleteLists);
                Gl.glGenLists = new Gl.Delegates.glGenLists(Imports.glGenLists);
                Gl.glListBase = new Gl.Delegates.glListBase(Imports.glListBase);
                Gl.glBegin = new Gl.Delegates.glBegin(Imports.glBegin);
                Gl.glBitmap_ = new Gl.Delegates.glBitmap_(Imports.glBitmap_);
                Gl.glColor3b = new Gl.Delegates.glColor3b(Imports.glColor3b);
                Gl.glColor3bv_ = new Gl.Delegates.glColor3bv_(Imports.glColor3bv_);
                Gl.glColor3d = new Gl.Delegates.glColor3d(Imports.glColor3d);
                Gl.glColor3dv_ = new Gl.Delegates.glColor3dv_(Imports.glColor3dv_);
                Gl.glColor3f = new Gl.Delegates.glColor3f(Imports.glColor3f);
                Gl.glColor3fv_ = new Gl.Delegates.glColor3fv_(Imports.glColor3fv_);
                Gl.glColor3i = new Gl.Delegates.glColor3i(Imports.glColor3i);
                Gl.glColor3iv_ = new Gl.Delegates.glColor3iv_(Imports.glColor3iv_);
                Gl.glColor3s = new Gl.Delegates.glColor3s(Imports.glColor3s);
                Gl.glColor3sv_ = new Gl.Delegates.glColor3sv_(Imports.glColor3sv_);
                Gl.glColor3ub = new Gl.Delegates.glColor3ub(Imports.glColor3ub);
                Gl.glColor3ubv_ = new Gl.Delegates.glColor3ubv_(Imports.glColor3ubv_);
                Gl.glColor3ui = new Gl.Delegates.glColor3ui(Imports.glColor3ui);
                Gl.glColor3uiv_ = new Gl.Delegates.glColor3uiv_(Imports.glColor3uiv_);
                Gl.glColor3us = new Gl.Delegates.glColor3us(Imports.glColor3us);
                Gl.glColor3usv_ = new Gl.Delegates.glColor3usv_(Imports.glColor3usv_);
                Gl.glColor4b = new Gl.Delegates.glColor4b(Imports.glColor4b);
                Gl.glColor4bv_ = new Gl.Delegates.glColor4bv_(Imports.glColor4bv_);
                Gl.glColor4d = new Gl.Delegates.glColor4d(Imports.glColor4d);
                Gl.glColor4dv_ = new Gl.Delegates.glColor4dv_(Imports.glColor4dv_);
                Gl.glColor4f = new Gl.Delegates.glColor4f(Imports.glColor4f);
                Gl.glColor4fv_ = new Gl.Delegates.glColor4fv_(Imports.glColor4fv_);
                Gl.glColor4i = new Gl.Delegates.glColor4i(Imports.glColor4i);
                Gl.glColor4iv_ = new Gl.Delegates.glColor4iv_(Imports.glColor4iv_);
                Gl.glColor4s = new Gl.Delegates.glColor4s(Imports.glColor4s);
                Gl.glColor4sv_ = new Gl.Delegates.glColor4sv_(Imports.glColor4sv_);
                Gl.glColor4ub = new Gl.Delegates.glColor4ub(Imports.glColor4ub);
                Gl.glColor4ubv_ = new Gl.Delegates.glColor4ubv_(Imports.glColor4ubv_);
                Gl.glColor4ui = new Gl.Delegates.glColor4ui(Imports.glColor4ui);
                Gl.glColor4uiv_ = new Gl.Delegates.glColor4uiv_(Imports.glColor4uiv_);
                Gl.glColor4us = new Gl.Delegates.glColor4us(Imports.glColor4us);
                Gl.glColor4usv_ = new Gl.Delegates.glColor4usv_(Imports.glColor4usv_);
                Gl.glEdgeFlag = new Gl.Delegates.glEdgeFlag(Imports.glEdgeFlag);
                Gl.glEdgeFlagv_ = new Gl.Delegates.glEdgeFlagv_(Imports.glEdgeFlagv_);
                Gl.glEnd = new Gl.Delegates.glEnd(Imports.glEnd);
                Gl.glIndexd = new Gl.Delegates.glIndexd(Imports.glIndexd);
                Gl.glIndexdv_ = new Gl.Delegates.glIndexdv_(Imports.glIndexdv_);
                Gl.glIndexf = new Gl.Delegates.glIndexf(Imports.glIndexf);
                Gl.glIndexfv_ = new Gl.Delegates.glIndexfv_(Imports.glIndexfv_);
                Gl.glIndexi = new Gl.Delegates.glIndexi(Imports.glIndexi);
                Gl.glIndexiv_ = new Gl.Delegates.glIndexiv_(Imports.glIndexiv_);
                Gl.glIndexs = new Gl.Delegates.glIndexs(Imports.glIndexs);
                Gl.glIndexsv_ = new Gl.Delegates.glIndexsv_(Imports.glIndexsv_);
                Gl.glNormal3b = new Gl.Delegates.glNormal3b(Imports.glNormal3b);
                Gl.glNormal3bv_ = new Gl.Delegates.glNormal3bv_(Imports.glNormal3bv_);
                Gl.glNormal3d = new Gl.Delegates.glNormal3d(Imports.glNormal3d);
                Gl.glNormal3dv_ = new Gl.Delegates.glNormal3dv_(Imports.glNormal3dv_);
                Gl.glNormal3f = new Gl.Delegates.glNormal3f(Imports.glNormal3f);
                Gl.glNormal3fv_ = new Gl.Delegates.glNormal3fv_(Imports.glNormal3fv_);
                Gl.glNormal3i = new Gl.Delegates.glNormal3i(Imports.glNormal3i);
                Gl.glNormal3iv_ = new Gl.Delegates.glNormal3iv_(Imports.glNormal3iv_);
                Gl.glNormal3s = new Gl.Delegates.glNormal3s(Imports.glNormal3s);
                Gl.glNormal3sv_ = new Gl.Delegates.glNormal3sv_(Imports.glNormal3sv_);
                Gl.glRasterPos2d = new Gl.Delegates.glRasterPos2d(Imports.glRasterPos2d);
                Gl.glRasterPos2dv_ = new Gl.Delegates.glRasterPos2dv_(Imports.glRasterPos2dv_);
                Gl.glRasterPos2f = new Gl.Delegates.glRasterPos2f(Imports.glRasterPos2f);
                Gl.glRasterPos2fv_ = new Gl.Delegates.glRasterPos2fv_(Imports.glRasterPos2fv_);
                Gl.glRasterPos2i = new Gl.Delegates.glRasterPos2i(Imports.glRasterPos2i);
                Gl.glRasterPos2iv_ = new Gl.Delegates.glRasterPos2iv_(Imports.glRasterPos2iv_);
                Gl.glRasterPos2s = new Gl.Delegates.glRasterPos2s(Imports.glRasterPos2s);
                Gl.glRasterPos2sv_ = new Gl.Delegates.glRasterPos2sv_(Imports.glRasterPos2sv_);
                Gl.glRasterPos3d = new Gl.Delegates.glRasterPos3d(Imports.glRasterPos3d);
                Gl.glRasterPos3dv_ = new Gl.Delegates.glRasterPos3dv_(Imports.glRasterPos3dv_);
                Gl.glRasterPos3f = new Gl.Delegates.glRasterPos3f(Imports.glRasterPos3f);
                Gl.glRasterPos3fv_ = new Gl.Delegates.glRasterPos3fv_(Imports.glRasterPos3fv_);
                Gl.glRasterPos3i = new Gl.Delegates.glRasterPos3i(Imports.glRasterPos3i);
                Gl.glRasterPos3iv_ = new Gl.Delegates.glRasterPos3iv_(Imports.glRasterPos3iv_);
                Gl.glRasterPos3s = new Gl.Delegates.glRasterPos3s(Imports.glRasterPos3s);
                Gl.glRasterPos3sv_ = new Gl.Delegates.glRasterPos3sv_(Imports.glRasterPos3sv_);
                Gl.glRasterPos4d = new Gl.Delegates.glRasterPos4d(Imports.glRasterPos4d);
                Gl.glRasterPos4dv_ = new Gl.Delegates.glRasterPos4dv_(Imports.glRasterPos4dv_);
                Gl.glRasterPos4f = new Gl.Delegates.glRasterPos4f(Imports.glRasterPos4f);
                Gl.glRasterPos4fv_ = new Gl.Delegates.glRasterPos4fv_(Imports.glRasterPos4fv_);
                Gl.glRasterPos4i = new Gl.Delegates.glRasterPos4i(Imports.glRasterPos4i);
                Gl.glRasterPos4iv_ = new Gl.Delegates.glRasterPos4iv_(Imports.glRasterPos4iv_);
                Gl.glRasterPos4s = new Gl.Delegates.glRasterPos4s(Imports.glRasterPos4s);
                Gl.glRasterPos4sv_ = new Gl.Delegates.glRasterPos4sv_(Imports.glRasterPos4sv_);
                Gl.glRectd = new Gl.Delegates.glRectd(Imports.glRectd);
                Gl.glRectdv_ = new Gl.Delegates.glRectdv_(Imports.glRectdv_);
                Gl.glRectf = new Gl.Delegates.glRectf(Imports.glRectf);
                Gl.glRectfv_ = new Gl.Delegates.glRectfv_(Imports.glRectfv_);
                Gl.glRecti = new Gl.Delegates.glRecti(Imports.glRecti);
                Gl.glRectiv_ = new Gl.Delegates.glRectiv_(Imports.glRectiv_);
                Gl.glRects = new Gl.Delegates.glRects(Imports.glRects);
                Gl.glRectsv_ = new Gl.Delegates.glRectsv_(Imports.glRectsv_);
                Gl.glTexCoord1d = new Gl.Delegates.glTexCoord1d(Imports.glTexCoord1d);
                Gl.glTexCoord1dv_ = new Gl.Delegates.glTexCoord1dv_(Imports.glTexCoord1dv_);
                Gl.glTexCoord1f = new Gl.Delegates.glTexCoord1f(Imports.glTexCoord1f);
                Gl.glTexCoord1fv_ = new Gl.Delegates.glTexCoord1fv_(Imports.glTexCoord1fv_);
                Gl.glTexCoord1i = new Gl.Delegates.glTexCoord1i(Imports.glTexCoord1i);
                Gl.glTexCoord1iv_ = new Gl.Delegates.glTexCoord1iv_(Imports.glTexCoord1iv_);
                Gl.glTexCoord1s = new Gl.Delegates.glTexCoord1s(Imports.glTexCoord1s);
                Gl.glTexCoord1sv_ = new Gl.Delegates.glTexCoord1sv_(Imports.glTexCoord1sv_);
                Gl.glTexCoord2d = new Gl.Delegates.glTexCoord2d(Imports.glTexCoord2d);
                Gl.glTexCoord2dv_ = new Gl.Delegates.glTexCoord2dv_(Imports.glTexCoord2dv_);
                Gl.glTexCoord2f = new Gl.Delegates.glTexCoord2f(Imports.glTexCoord2f);
                Gl.glTexCoord2fv_ = new Gl.Delegates.glTexCoord2fv_(Imports.glTexCoord2fv_);
                Gl.glTexCoord2i = new Gl.Delegates.glTexCoord2i(Imports.glTexCoord2i);
                Gl.glTexCoord2iv_ = new Gl.Delegates.glTexCoord2iv_(Imports.glTexCoord2iv_);
                Gl.glTexCoord2s = new Gl.Delegates.glTexCoord2s(Imports.glTexCoord2s);
                Gl.glTexCoord2sv_ = new Gl.Delegates.glTexCoord2sv_(Imports.glTexCoord2sv_);
                Gl.glTexCoord3d = new Gl.Delegates.glTexCoord3d(Imports.glTexCoord3d);
                Gl.glTexCoord3dv_ = new Gl.Delegates.glTexCoord3dv_(Imports.glTexCoord3dv_);
                Gl.glTexCoord3f = new Gl.Delegates.glTexCoord3f(Imports.glTexCoord3f);
                Gl.glTexCoord3fv_ = new Gl.Delegates.glTexCoord3fv_(Imports.glTexCoord3fv_);
                Gl.glTexCoord3i = new Gl.Delegates.glTexCoord3i(Imports.glTexCoord3i);
                Gl.glTexCoord3iv_ = new Gl.Delegates.glTexCoord3iv_(Imports.glTexCoord3iv_);
                Gl.glTexCoord3s = new Gl.Delegates.glTexCoord3s(Imports.glTexCoord3s);
                Gl.glTexCoord3sv_ = new Gl.Delegates.glTexCoord3sv_(Imports.glTexCoord3sv_);
                Gl.glTexCoord4d = new Gl.Delegates.glTexCoord4d(Imports.glTexCoord4d);
                Gl.glTexCoord4dv_ = new Gl.Delegates.glTexCoord4dv_(Imports.glTexCoord4dv_);
                Gl.glTexCoord4f = new Gl.Delegates.glTexCoord4f(Imports.glTexCoord4f);
                Gl.glTexCoord4fv_ = new Gl.Delegates.glTexCoord4fv_(Imports.glTexCoord4fv_);
                Gl.glTexCoord4i = new Gl.Delegates.glTexCoord4i(Imports.glTexCoord4i);
                Gl.glTexCoord4iv_ = new Gl.Delegates.glTexCoord4iv_(Imports.glTexCoord4iv_);
                Gl.glTexCoord4s = new Gl.Delegates.glTexCoord4s(Imports.glTexCoord4s);
                Gl.glTexCoord4sv_ = new Gl.Delegates.glTexCoord4sv_(Imports.glTexCoord4sv_);
                Gl.glVertex2d = new Gl.Delegates.glVertex2d(Imports.glVertex2d);
                Gl.glVertex2dv_ = new Gl.Delegates.glVertex2dv_(Imports.glVertex2dv_);
                Gl.glVertex2f = new Gl.Delegates.glVertex2f(Imports.glVertex2f);
                Gl.glVertex2fv_ = new Gl.Delegates.glVertex2fv_(Imports.glVertex2fv_);
                Gl.glVertex2i = new Gl.Delegates.glVertex2i(Imports.glVertex2i);
                Gl.glVertex2iv_ = new Gl.Delegates.glVertex2iv_(Imports.glVertex2iv_);
                Gl.glVertex2s = new Gl.Delegates.glVertex2s(Imports.glVertex2s);
                Gl.glVertex2sv_ = new Gl.Delegates.glVertex2sv_(Imports.glVertex2sv_);
                Gl.glVertex3d = new Gl.Delegates.glVertex3d(Imports.glVertex3d);
                Gl.glVertex3dv_ = new Gl.Delegates.glVertex3dv_(Imports.glVertex3dv_);
                Gl.glVertex3f = new Gl.Delegates.glVertex3f(Imports.glVertex3f);
                Gl.glVertex3fv_ = new Gl.Delegates.glVertex3fv_(Imports.glVertex3fv_);
                Gl.glVertex3i = new Gl.Delegates.glVertex3i(Imports.glVertex3i);
                Gl.glVertex3iv_ = new Gl.Delegates.glVertex3iv_(Imports.glVertex3iv_);
                Gl.glVertex3s = new Gl.Delegates.glVertex3s(Imports.glVertex3s);
                Gl.glVertex3sv_ = new Gl.Delegates.glVertex3sv_(Imports.glVertex3sv_);
                Gl.glVertex4d = new Gl.Delegates.glVertex4d(Imports.glVertex4d);
                Gl.glVertex4dv_ = new Gl.Delegates.glVertex4dv_(Imports.glVertex4dv_);
                Gl.glVertex4f = new Gl.Delegates.glVertex4f(Imports.glVertex4f);
                Gl.glVertex4fv_ = new Gl.Delegates.glVertex4fv_(Imports.glVertex4fv_);
                Gl.glVertex4i = new Gl.Delegates.glVertex4i(Imports.glVertex4i);
                Gl.glVertex4iv_ = new Gl.Delegates.glVertex4iv_(Imports.glVertex4iv_);
                Gl.glVertex4s = new Gl.Delegates.glVertex4s(Imports.glVertex4s);
                Gl.glVertex4sv_ = new Gl.Delegates.glVertex4sv_(Imports.glVertex4sv_);
                Gl.glClipPlane_ = new Gl.Delegates.glClipPlane_(Imports.glClipPlane_);
                Gl.glColorMaterial = new Gl.Delegates.glColorMaterial(Imports.glColorMaterial);
                Gl.glCullFace = new Gl.Delegates.glCullFace(Imports.glCullFace);
                Gl.glFogf = new Gl.Delegates.glFogf(Imports.glFogf);
                Gl.glFogfv_ = new Gl.Delegates.glFogfv_(Imports.glFogfv_);
                Gl.glFogi = new Gl.Delegates.glFogi(Imports.glFogi);
                Gl.glFogiv_ = new Gl.Delegates.glFogiv_(Imports.glFogiv_);
                Gl.glFrontFace = new Gl.Delegates.glFrontFace(Imports.glFrontFace);
                Gl.glHint = new Gl.Delegates.glHint(Imports.glHint);
                Gl.glLightf = new Gl.Delegates.glLightf(Imports.glLightf);
                Gl.glLightfv_ = new Gl.Delegates.glLightfv_(Imports.glLightfv_);
                Gl.glLighti = new Gl.Delegates.glLighti(Imports.glLighti);
                Gl.glLightiv_ = new Gl.Delegates.glLightiv_(Imports.glLightiv_);
                Gl.glLightModelf = new Gl.Delegates.glLightModelf(Imports.glLightModelf);
                Gl.glLightModelfv_ = new Gl.Delegates.glLightModelfv_(Imports.glLightModelfv_);
                Gl.glLightModeli = new Gl.Delegates.glLightModeli(Imports.glLightModeli);
                Gl.glLightModeliv_ = new Gl.Delegates.glLightModeliv_(Imports.glLightModeliv_);
                Gl.glLineStipple_ = new Gl.Delegates.glLineStipple_(Imports.glLineStipple_);
                Gl.glLineWidth = new Gl.Delegates.glLineWidth(Imports.glLineWidth);
                Gl.glMaterialf = new Gl.Delegates.glMaterialf(Imports.glMaterialf);
                Gl.glMaterialfv_ = new Gl.Delegates.glMaterialfv_(Imports.glMaterialfv_);
                Gl.glMateriali = new Gl.Delegates.glMateriali(Imports.glMateriali);
                Gl.glMaterialiv_ = new Gl.Delegates.glMaterialiv_(Imports.glMaterialiv_);
                Gl.glPointSize = new Gl.Delegates.glPointSize(Imports.glPointSize);
                Gl.glPolygonMode = new Gl.Delegates.glPolygonMode(Imports.glPolygonMode);
                Gl.glPolygonStipple_ = new Gl.Delegates.glPolygonStipple_(Imports.glPolygonStipple_);
                Gl.glScissor = new Gl.Delegates.glScissor(Imports.glScissor);
                Gl.glShadeModel = new Gl.Delegates.glShadeModel(Imports.glShadeModel);
                Gl.glTexParameterf = new Gl.Delegates.glTexParameterf(Imports.glTexParameterf);
                Gl.glTexParameterfv_ = new Gl.Delegates.glTexParameterfv_(Imports.glTexParameterfv_);
                Gl.glTexParameteri = new Gl.Delegates.glTexParameteri(Imports.glTexParameteri);
                Gl.glTexParameteriv_ = new Gl.Delegates.glTexParameteriv_(Imports.glTexParameteriv_);
                Gl.glTexImage1D_ = new Gl.Delegates.glTexImage1D_(Imports.glTexImage1D_);
                Gl.glTexImage2D_ = new Gl.Delegates.glTexImage2D_(Imports.glTexImage2D_);
                Gl.glTexEnvf = new Gl.Delegates.glTexEnvf(Imports.glTexEnvf);
                Gl.glTexEnvfv_ = new Gl.Delegates.glTexEnvfv_(Imports.glTexEnvfv_);
                Gl.glTexEnvi = new Gl.Delegates.glTexEnvi(Imports.glTexEnvi);
                Gl.glTexEnviv_ = new Gl.Delegates.glTexEnviv_(Imports.glTexEnviv_);
                Gl.glTexGend = new Gl.Delegates.glTexGend(Imports.glTexGend);
                Gl.glTexGendv_ = new Gl.Delegates.glTexGendv_(Imports.glTexGendv_);
                Gl.glTexGenf = new Gl.Delegates.glTexGenf(Imports.glTexGenf);
                Gl.glTexGenfv_ = new Gl.Delegates.glTexGenfv_(Imports.glTexGenfv_);
                Gl.glTexGeni = new Gl.Delegates.glTexGeni(Imports.glTexGeni);
                Gl.glTexGeniv_ = new Gl.Delegates.glTexGeniv_(Imports.glTexGeniv_);
                Gl.glFeedbackBuffer = new Gl.Delegates.glFeedbackBuffer(Imports.glFeedbackBuffer);
                Gl.glSelectBuffer = new Gl.Delegates.glSelectBuffer(Imports.glSelectBuffer);
                Gl.glRenderMode = new Gl.Delegates.glRenderMode(Imports.glRenderMode);
                Gl.glInitNames = new Gl.Delegates.glInitNames(Imports.glInitNames);
                Gl.glLoadName = new Gl.Delegates.glLoadName(Imports.glLoadName);
                Gl.glPassThrough = new Gl.Delegates.glPassThrough(Imports.glPassThrough);
                Gl.glPopName = new Gl.Delegates.glPopName(Imports.glPopName);
                Gl.glPushName = new Gl.Delegates.glPushName(Imports.glPushName);
                Gl.glDrawBuffer = new Gl.Delegates.glDrawBuffer(Imports.glDrawBuffer);
                Gl.glClear = new Gl.Delegates.glClear(Imports.glClear);
                Gl.glClearAccum = new Gl.Delegates.glClearAccum(Imports.glClearAccum);
                Gl.glClearIndex = new Gl.Delegates.glClearIndex(Imports.glClearIndex);
                Gl.glClearColor = new Gl.Delegates.glClearColor(Imports.glClearColor);
                Gl.glClearStencil = new Gl.Delegates.glClearStencil(Imports.glClearStencil);
                Gl.glClearDepth = new Gl.Delegates.glClearDepth(Imports.glClearDepth);
                Gl.glStencilMask = new Gl.Delegates.glStencilMask(Imports.glStencilMask);
                Gl.glColorMask = new Gl.Delegates.glColorMask(Imports.glColorMask);
                Gl.glDepthMask = new Gl.Delegates.glDepthMask(Imports.glDepthMask);
                Gl.glIndexMask = new Gl.Delegates.glIndexMask(Imports.glIndexMask);
                Gl.glAccum = new Gl.Delegates.glAccum(Imports.glAccum);
                Gl.glDisable = new Gl.Delegates.glDisable(Imports.glDisable);
                Gl.glEnable = new Gl.Delegates.glEnable(Imports.glEnable);
                Gl.glFinish = new Gl.Delegates.glFinish(Imports.glFinish);
                Gl.glFlush = new Gl.Delegates.glFlush(Imports.glFlush);
                Gl.glPopAttrib = new Gl.Delegates.glPopAttrib(Imports.glPopAttrib);
                Gl.glPushAttrib = new Gl.Delegates.glPushAttrib(Imports.glPushAttrib);
                Gl.glMap1d_ = new Gl.Delegates.glMap1d_(Imports.glMap1d_);
                Gl.glMap1f_ = new Gl.Delegates.glMap1f_(Imports.glMap1f_);
                Gl.glMap2d_ = new Gl.Delegates.glMap2d_(Imports.glMap2d_);
                Gl.glMap2f_ = new Gl.Delegates.glMap2f_(Imports.glMap2f_);
                Gl.glMapGrid1d = new Gl.Delegates.glMapGrid1d(Imports.glMapGrid1d);
                Gl.glMapGrid1f = new Gl.Delegates.glMapGrid1f(Imports.glMapGrid1f);
                Gl.glMapGrid2d = new Gl.Delegates.glMapGrid2d(Imports.glMapGrid2d);
                Gl.glMapGrid2f = new Gl.Delegates.glMapGrid2f(Imports.glMapGrid2f);
                Gl.glEvalCoord1d = new Gl.Delegates.glEvalCoord1d(Imports.glEvalCoord1d);
                Gl.glEvalCoord1dv_ = new Gl.Delegates.glEvalCoord1dv_(Imports.glEvalCoord1dv_);
                Gl.glEvalCoord1f = new Gl.Delegates.glEvalCoord1f(Imports.glEvalCoord1f);
                Gl.glEvalCoord1fv_ = new Gl.Delegates.glEvalCoord1fv_(Imports.glEvalCoord1fv_);
                Gl.glEvalCoord2d = new Gl.Delegates.glEvalCoord2d(Imports.glEvalCoord2d);
                Gl.glEvalCoord2dv_ = new Gl.Delegates.glEvalCoord2dv_(Imports.glEvalCoord2dv_);
                Gl.glEvalCoord2f = new Gl.Delegates.glEvalCoord2f(Imports.glEvalCoord2f);
                Gl.glEvalCoord2fv_ = new Gl.Delegates.glEvalCoord2fv_(Imports.glEvalCoord2fv_);
                Gl.glEvalMesh1 = new Gl.Delegates.glEvalMesh1(Imports.glEvalMesh1);
                Gl.glEvalPoint1 = new Gl.Delegates.glEvalPoint1(Imports.glEvalPoint1);
                Gl.glEvalMesh2 = new Gl.Delegates.glEvalMesh2(Imports.glEvalMesh2);
                Gl.glEvalPoint2 = new Gl.Delegates.glEvalPoint2(Imports.glEvalPoint2);
                Gl.glAlphaFunc = new Gl.Delegates.glAlphaFunc(Imports.glAlphaFunc);
                Gl.glBlendFunc = new Gl.Delegates.glBlendFunc(Imports.glBlendFunc);
                Gl.glLogicOp = new Gl.Delegates.glLogicOp(Imports.glLogicOp);
                Gl.glStencilFunc = new Gl.Delegates.glStencilFunc(Imports.glStencilFunc);
                Gl.glStencilOp = new Gl.Delegates.glStencilOp(Imports.glStencilOp);
                Gl.glDepthFunc = new Gl.Delegates.glDepthFunc(Imports.glDepthFunc);
                Gl.glPixelZoom = new Gl.Delegates.glPixelZoom(Imports.glPixelZoom);
                Gl.glPixelTransferf = new Gl.Delegates.glPixelTransferf(Imports.glPixelTransferf);
                Gl.glPixelTransferi = new Gl.Delegates.glPixelTransferi(Imports.glPixelTransferi);
                Gl.glPixelStoref = new Gl.Delegates.glPixelStoref(Imports.glPixelStoref);
                Gl.glPixelStorei = new Gl.Delegates.glPixelStorei(Imports.glPixelStorei);
                Gl.glPixelMapfv_ = new Gl.Delegates.glPixelMapfv_(Imports.glPixelMapfv_);
                Gl.glPixelMapuiv_ = new Gl.Delegates.glPixelMapuiv_(Imports.glPixelMapuiv_);
                Gl.glPixelMapusv_ = new Gl.Delegates.glPixelMapusv_(Imports.glPixelMapusv_);
                Gl.glReadBuffer = new Gl.Delegates.glReadBuffer(Imports.glReadBuffer);
                Gl.glCopyPixels = new Gl.Delegates.glCopyPixels(Imports.glCopyPixels);
                Gl.glReadPixels_ = new Gl.Delegates.glReadPixels_(Imports.glReadPixels_);
                Gl.glDrawPixels_ = new Gl.Delegates.glDrawPixels_(Imports.glDrawPixels_);
                Gl.glGetBooleanv = new Gl.Delegates.glGetBooleanv(Imports.glGetBooleanv);
                Gl.glGetClipPlane = new Gl.Delegates.glGetClipPlane(Imports.glGetClipPlane);
                Gl.glGetDoublev = new Gl.Delegates.glGetDoublev(Imports.glGetDoublev);
                Gl.glGetError = new Gl.Delegates.glGetError(Imports.glGetError);
                Gl.glGetFloatv = new Gl.Delegates.glGetFloatv(Imports.glGetFloatv);
                Gl.glGetIntegerv = new Gl.Delegates.glGetIntegerv(Imports.glGetIntegerv);
                Gl.glGetLightfv = new Gl.Delegates.glGetLightfv(Imports.glGetLightfv);
                Gl.glGetLightiv = new Gl.Delegates.glGetLightiv(Imports.glGetLightiv);
                Gl.glGetMapdv = new Gl.Delegates.glGetMapdv(Imports.glGetMapdv);
                Gl.glGetMapfv = new Gl.Delegates.glGetMapfv(Imports.glGetMapfv);
                Gl.glGetMapiv = new Gl.Delegates.glGetMapiv(Imports.glGetMapiv);
                Gl.glGetMaterialfv = new Gl.Delegates.glGetMaterialfv(Imports.glGetMaterialfv);
                Gl.glGetMaterialiv = new Gl.Delegates.glGetMaterialiv(Imports.glGetMaterialiv);
                Gl.glGetPixelMapfv = new Gl.Delegates.glGetPixelMapfv(Imports.glGetPixelMapfv);
                Gl.glGetPixelMapuiv = new Gl.Delegates.glGetPixelMapuiv(Imports.glGetPixelMapuiv);
                Gl.glGetPixelMapusv = new Gl.Delegates.glGetPixelMapusv(Imports.glGetPixelMapusv);
                Gl.glGetPolygonStipple = new Gl.Delegates.glGetPolygonStipple(Imports.glGetPolygonStipple);
                Gl.glGetString_ = new Gl.Delegates.glGetString_(Imports.glGetString_);
                Gl.glGetTexEnvfv = new Gl.Delegates.glGetTexEnvfv(Imports.glGetTexEnvfv);
                Gl.glGetTexEnviv = new Gl.Delegates.glGetTexEnviv(Imports.glGetTexEnviv);
                Gl.glGetTexGendv = new Gl.Delegates.glGetTexGendv(Imports.glGetTexGendv);
                Gl.glGetTexGenfv = new Gl.Delegates.glGetTexGenfv(Imports.glGetTexGenfv);
                Gl.glGetTexGeniv = new Gl.Delegates.glGetTexGeniv(Imports.glGetTexGeniv);
                Gl.glGetTexImage_ = new Gl.Delegates.glGetTexImage_(Imports.glGetTexImage_);
                Gl.glGetTexParameterfv = new Gl.Delegates.glGetTexParameterfv(Imports.glGetTexParameterfv);
                Gl.glGetTexParameteriv = new Gl.Delegates.glGetTexParameteriv(Imports.glGetTexParameteriv);
                Gl.glGetTexLevelParameterfv = new Gl.Delegates.glGetTexLevelParameterfv(Imports.glGetTexLevelParameterfv);
                Gl.glGetTexLevelParameteriv = new Gl.Delegates.glGetTexLevelParameteriv(Imports.glGetTexLevelParameteriv);
                Gl.glIsEnabled = new Gl.Delegates.glIsEnabled(Imports.glIsEnabled);
                Gl.glIsList = new Gl.Delegates.glIsList(Imports.glIsList);
                Gl.glDepthRange = new Gl.Delegates.glDepthRange(Imports.glDepthRange);
                Gl.glFrustum = new Gl.Delegates.glFrustum(Imports.glFrustum);
                Gl.glLoadIdentity = new Gl.Delegates.glLoadIdentity(Imports.glLoadIdentity);
                Gl.glLoadMatrixf_ = new Gl.Delegates.glLoadMatrixf_(Imports.glLoadMatrixf_);
                Gl.glLoadMatrixd_ = new Gl.Delegates.glLoadMatrixd_(Imports.glLoadMatrixd_);
                Gl.glMatrixMode = new Gl.Delegates.glMatrixMode(Imports.glMatrixMode);
                Gl.glMultMatrixf_ = new Gl.Delegates.glMultMatrixf_(Imports.glMultMatrixf_);
                Gl.glMultMatrixd_ = new Gl.Delegates.glMultMatrixd_(Imports.glMultMatrixd_);
                Gl.glOrtho = new Gl.Delegates.glOrtho(Imports.glOrtho);
                Gl.glPopMatrix = new Gl.Delegates.glPopMatrix(Imports.glPopMatrix);
                Gl.glPushMatrix = new Gl.Delegates.glPushMatrix(Imports.glPushMatrix);
                Gl.glRotated = new Gl.Delegates.glRotated(Imports.glRotated);
                Gl.glRotatef = new Gl.Delegates.glRotatef(Imports.glRotatef);
                Gl.glScaled = new Gl.Delegates.glScaled(Imports.glScaled);
                Gl.glScalef = new Gl.Delegates.glScalef(Imports.glScalef);
                Gl.glTranslated = new Gl.Delegates.glTranslated(Imports.glTranslated);
                Gl.glTranslatef = new Gl.Delegates.glTranslatef(Imports.glTranslatef);
                Gl.glViewport = new Gl.Delegates.glViewport(Imports.glViewport);
                Gl.glArrayElement = new Gl.Delegates.glArrayElement(Imports.glArrayElement);
                Gl.glColorPointer_ = new Gl.Delegates.glColorPointer_(Imports.glColorPointer_);
                Gl.glDisableClientState = new Gl.Delegates.glDisableClientState(Imports.glDisableClientState);
                Gl.glDrawArrays = new Gl.Delegates.glDrawArrays(Imports.glDrawArrays);
                Gl.glDrawElements_ = new Gl.Delegates.glDrawElements_(Imports.glDrawElements_);
                Gl.glEdgeFlagPointer_ = new Gl.Delegates.glEdgeFlagPointer_(Imports.glEdgeFlagPointer_);
                Gl.glEnableClientState = new Gl.Delegates.glEnableClientState(Imports.glEnableClientState);
                Gl.glGetPointerv = new Gl.Delegates.glGetPointerv(Imports.glGetPointerv);
                Gl.glIndexPointer_ = new Gl.Delegates.glIndexPointer_(Imports.glIndexPointer_);
                Gl.glInterleavedArrays_ = new Gl.Delegates.glInterleavedArrays_(Imports.glInterleavedArrays_);
                Gl.glNormalPointer_ = new Gl.Delegates.glNormalPointer_(Imports.glNormalPointer_);
                Gl.glTexCoordPointer_ = new Gl.Delegates.glTexCoordPointer_(Imports.glTexCoordPointer_);
                Gl.glVertexPointer_ = new Gl.Delegates.glVertexPointer_(Imports.glVertexPointer_);
                Gl.glPolygonOffset = new Gl.Delegates.glPolygonOffset(Imports.glPolygonOffset);
                Gl.glCopyTexImage1D = new Gl.Delegates.glCopyTexImage1D(Imports.glCopyTexImage1D);
                Gl.glCopyTexImage2D = new Gl.Delegates.glCopyTexImage2D(Imports.glCopyTexImage2D);
                Gl.glCopyTexSubImage1D = new Gl.Delegates.glCopyTexSubImage1D(Imports.glCopyTexSubImage1D);
                Gl.glCopyTexSubImage2D = new Gl.Delegates.glCopyTexSubImage2D(Imports.glCopyTexSubImage2D);
                Gl.glTexSubImage1D_ = new Gl.Delegates.glTexSubImage1D_(Imports.glTexSubImage1D_);
                Gl.glTexSubImage2D_ = new Gl.Delegates.glTexSubImage2D_(Imports.glTexSubImage2D_);
                Gl.glAreTexturesResident_ = new Gl.Delegates.glAreTexturesResident_(Imports.glAreTexturesResident_);
                Gl.glBindTexture = new Gl.Delegates.glBindTexture(Imports.glBindTexture);
                Gl.glDeleteTextures_ = new Gl.Delegates.glDeleteTextures_(Imports.glDeleteTextures_);
                Gl.glGenTextures = new Gl.Delegates.glGenTextures(Imports.glGenTextures);
                Gl.glIsTexture = new Gl.Delegates.glIsTexture(Imports.glIsTexture);
                Gl.glPrioritizeTextures_ = new Gl.Delegates.glPrioritizeTextures_(Imports.glPrioritizeTextures_);
                Gl.glIndexub = new Gl.Delegates.glIndexub(Imports.glIndexub);
                Gl.glIndexubv_ = new Gl.Delegates.glIndexubv_(Imports.glIndexubv_);
                Gl.glPopClientAttrib = new Gl.Delegates.glPopClientAttrib(Imports.glPopClientAttrib);
                Gl.glPushClientAttrib = new Gl.Delegates.glPushClientAttrib(Imports.glPushClientAttrib);
                Gl.glBlendColor = new Gl.Delegates.glBlendColor(Imports.glBlendColor);
                Gl.glBlendEquation = new Gl.Delegates.glBlendEquation(Imports.glBlendEquation);
                Gl.glDrawRangeElements_ = new Gl.Delegates.glDrawRangeElements_(Imports.glDrawRangeElements_);
                Gl.glColorTable_ = new Gl.Delegates.glColorTable_(Imports.glColorTable_);
                Gl.glColorTableParameterfv_ = new Gl.Delegates.glColorTableParameterfv_(Imports.glColorTableParameterfv_);
                Gl.glColorTableParameteriv_ = new Gl.Delegates.glColorTableParameteriv_(Imports.glColorTableParameteriv_);
                Gl.glCopyColorTable = new Gl.Delegates.glCopyColorTable(Imports.glCopyColorTable);
                Gl.glGetColorTable_ = new Gl.Delegates.glGetColorTable_(Imports.glGetColorTable_);
                Gl.glGetColorTableParameterfv = new Gl.Delegates.glGetColorTableParameterfv(Imports.glGetColorTableParameterfv);
                Gl.glGetColorTableParameteriv = new Gl.Delegates.glGetColorTableParameteriv(Imports.glGetColorTableParameteriv);
                Gl.glColorSubTable_ = new Gl.Delegates.glColorSubTable_(Imports.glColorSubTable_);
                Gl.glCopyColorSubTable = new Gl.Delegates.glCopyColorSubTable(Imports.glCopyColorSubTable);
                Gl.glConvolutionFilter1D_ = new Gl.Delegates.glConvolutionFilter1D_(Imports.glConvolutionFilter1D_);
                Gl.glConvolutionFilter2D_ = new Gl.Delegates.glConvolutionFilter2D_(Imports.glConvolutionFilter2D_);
                Gl.glConvolutionParameterf = new Gl.Delegates.glConvolutionParameterf(Imports.glConvolutionParameterf);
                Gl.glConvolutionParameterfv_ = new Gl.Delegates.glConvolutionParameterfv_(Imports.glConvolutionParameterfv_);
                Gl.glConvolutionParameteri = new Gl.Delegates.glConvolutionParameteri(Imports.glConvolutionParameteri);
                Gl.glConvolutionParameteriv_ = new Gl.Delegates.glConvolutionParameteriv_(Imports.glConvolutionParameteriv_);
                Gl.glCopyConvolutionFilter1D = new Gl.Delegates.glCopyConvolutionFilter1D(Imports.glCopyConvolutionFilter1D);
                Gl.glCopyConvolutionFilter2D = new Gl.Delegates.glCopyConvolutionFilter2D(Imports.glCopyConvolutionFilter2D);
                Gl.glGetConvolutionFilter_ = new Gl.Delegates.glGetConvolutionFilter_(Imports.glGetConvolutionFilter_);
                Gl.glGetConvolutionParameterfv = new Gl.Delegates.glGetConvolutionParameterfv(Imports.glGetConvolutionParameterfv);
                Gl.glGetConvolutionParameteriv = new Gl.Delegates.glGetConvolutionParameteriv(Imports.glGetConvolutionParameteriv);
                Gl.glGetSeparableFilter_ = new Gl.Delegates.glGetSeparableFilter_(Imports.glGetSeparableFilter_);
                Gl.glSeparableFilter2D_ = new Gl.Delegates.glSeparableFilter2D_(Imports.glSeparableFilter2D_);
                Gl.glGetHistogram_ = new Gl.Delegates.glGetHistogram_(Imports.glGetHistogram_);
                Gl.glGetHistogramParameterfv = new Gl.Delegates.glGetHistogramParameterfv(Imports.glGetHistogramParameterfv);
                Gl.glGetHistogramParameteriv = new Gl.Delegates.glGetHistogramParameteriv(Imports.glGetHistogramParameteriv);
                Gl.glGetMinmax_ = new Gl.Delegates.glGetMinmax_(Imports.glGetMinmax_);
                Gl.glGetMinmaxParameterfv = new Gl.Delegates.glGetMinmaxParameterfv(Imports.glGetMinmaxParameterfv);
                Gl.glGetMinmaxParameteriv = new Gl.Delegates.glGetMinmaxParameteriv(Imports.glGetMinmaxParameteriv);
                Gl.glHistogram = new Gl.Delegates.glHistogram(Imports.glHistogram);
                Gl.glMinmax = new Gl.Delegates.glMinmax(Imports.glMinmax);
                Gl.glResetHistogram = new Gl.Delegates.glResetHistogram(Imports.glResetHistogram);
                Gl.glResetMinmax = new Gl.Delegates.glResetMinmax(Imports.glResetMinmax);
                Gl.glTexImage3D_ = new Gl.Delegates.glTexImage3D_(Imports.glTexImage3D_);
                Gl.glTexSubImage3D_ = new Gl.Delegates.glTexSubImage3D_(Imports.glTexSubImage3D_);
                Gl.glCopyTexSubImage3D = new Gl.Delegates.glCopyTexSubImage3D(Imports.glCopyTexSubImage3D);
                Gl.glActiveTexture = new Gl.Delegates.glActiveTexture(Imports.glActiveTexture);
                Gl.glClientActiveTexture = new Gl.Delegates.glClientActiveTexture(Imports.glClientActiveTexture);
                Gl.glMultiTexCoord1d = new Gl.Delegates.glMultiTexCoord1d(Imports.glMultiTexCoord1d);
                Gl.glMultiTexCoord1dv_ = new Gl.Delegates.glMultiTexCoord1dv_(Imports.glMultiTexCoord1dv_);
                Gl.glMultiTexCoord1f = new Gl.Delegates.glMultiTexCoord1f(Imports.glMultiTexCoord1f);
                Gl.glMultiTexCoord1fv_ = new Gl.Delegates.glMultiTexCoord1fv_(Imports.glMultiTexCoord1fv_);
                Gl.glMultiTexCoord1i = new Gl.Delegates.glMultiTexCoord1i(Imports.glMultiTexCoord1i);
                Gl.glMultiTexCoord1iv_ = new Gl.Delegates.glMultiTexCoord1iv_(Imports.glMultiTexCoord1iv_);
                Gl.glMultiTexCoord1s = new Gl.Delegates.glMultiTexCoord1s(Imports.glMultiTexCoord1s);
                Gl.glMultiTexCoord1sv_ = new Gl.Delegates.glMultiTexCoord1sv_(Imports.glMultiTexCoord1sv_);
                Gl.glMultiTexCoord2d = new Gl.Delegates.glMultiTexCoord2d(Imports.glMultiTexCoord2d);
                Gl.glMultiTexCoord2dv_ = new Gl.Delegates.glMultiTexCoord2dv_(Imports.glMultiTexCoord2dv_);
                Gl.glMultiTexCoord2f = new Gl.Delegates.glMultiTexCoord2f(Imports.glMultiTexCoord2f);
                Gl.glMultiTexCoord2fv_ = new Gl.Delegates.glMultiTexCoord2fv_(Imports.glMultiTexCoord2fv_);
                Gl.glMultiTexCoord2i = new Gl.Delegates.glMultiTexCoord2i(Imports.glMultiTexCoord2i);
                Gl.glMultiTexCoord2iv_ = new Gl.Delegates.glMultiTexCoord2iv_(Imports.glMultiTexCoord2iv_);
                Gl.glMultiTexCoord2s = new Gl.Delegates.glMultiTexCoord2s(Imports.glMultiTexCoord2s);
                Gl.glMultiTexCoord2sv_ = new Gl.Delegates.glMultiTexCoord2sv_(Imports.glMultiTexCoord2sv_);
                Gl.glMultiTexCoord3d = new Gl.Delegates.glMultiTexCoord3d(Imports.glMultiTexCoord3d);
                Gl.glMultiTexCoord3dv_ = new Gl.Delegates.glMultiTexCoord3dv_(Imports.glMultiTexCoord3dv_);
                Gl.glMultiTexCoord3f = new Gl.Delegates.glMultiTexCoord3f(Imports.glMultiTexCoord3f);
                Gl.glMultiTexCoord3fv_ = new Gl.Delegates.glMultiTexCoord3fv_(Imports.glMultiTexCoord3fv_);
                Gl.glMultiTexCoord3i = new Gl.Delegates.glMultiTexCoord3i(Imports.glMultiTexCoord3i);
                Gl.glMultiTexCoord3iv_ = new Gl.Delegates.glMultiTexCoord3iv_(Imports.glMultiTexCoord3iv_);
                Gl.glMultiTexCoord3s = new Gl.Delegates.glMultiTexCoord3s(Imports.glMultiTexCoord3s);
                Gl.glMultiTexCoord3sv_ = new Gl.Delegates.glMultiTexCoord3sv_(Imports.glMultiTexCoord3sv_);
                Gl.glMultiTexCoord4d = new Gl.Delegates.glMultiTexCoord4d(Imports.glMultiTexCoord4d);
                Gl.glMultiTexCoord4dv_ = new Gl.Delegates.glMultiTexCoord4dv_(Imports.glMultiTexCoord4dv_);
                Gl.glMultiTexCoord4f = new Gl.Delegates.glMultiTexCoord4f(Imports.glMultiTexCoord4f);
                Gl.glMultiTexCoord4fv_ = new Gl.Delegates.glMultiTexCoord4fv_(Imports.glMultiTexCoord4fv_);
                Gl.glMultiTexCoord4i = new Gl.Delegates.glMultiTexCoord4i(Imports.glMultiTexCoord4i);
                Gl.glMultiTexCoord4iv_ = new Gl.Delegates.glMultiTexCoord4iv_(Imports.glMultiTexCoord4iv_);
                Gl.glMultiTexCoord4s = new Gl.Delegates.glMultiTexCoord4s(Imports.glMultiTexCoord4s);
                Gl.glMultiTexCoord4sv_ = new Gl.Delegates.glMultiTexCoord4sv_(Imports.glMultiTexCoord4sv_);
                Gl.glLoadTransposeMatrixf_ = new Gl.Delegates.glLoadTransposeMatrixf_(Imports.glLoadTransposeMatrixf_);
                Gl.glLoadTransposeMatrixd_ = new Gl.Delegates.glLoadTransposeMatrixd_(Imports.glLoadTransposeMatrixd_);
                Gl.glMultTransposeMatrixf_ = new Gl.Delegates.glMultTransposeMatrixf_(Imports.glMultTransposeMatrixf_);
                Gl.glMultTransposeMatrixd_ = new Gl.Delegates.glMultTransposeMatrixd_(Imports.glMultTransposeMatrixd_);
                Gl.glSampleCoverage = new Gl.Delegates.glSampleCoverage(Imports.glSampleCoverage);
                Gl.glCompressedTexImage3D_ = new Gl.Delegates.glCompressedTexImage3D_(Imports.glCompressedTexImage3D_);
                Gl.glCompressedTexImage2D_ = new Gl.Delegates.glCompressedTexImage2D_(Imports.glCompressedTexImage2D_);
                Gl.glCompressedTexImage1D_ = new Gl.Delegates.glCompressedTexImage1D_(Imports.glCompressedTexImage1D_);
                Gl.glCompressedTexSubImage3D_ = new Gl.Delegates.glCompressedTexSubImage3D_(Imports.glCompressedTexSubImage3D_);
                Gl.glCompressedTexSubImage2D_ = new Gl.Delegates.glCompressedTexSubImage2D_(Imports.glCompressedTexSubImage2D_);
                Gl.glCompressedTexSubImage1D_ = new Gl.Delegates.glCompressedTexSubImage1D_(Imports.glCompressedTexSubImage1D_);
                Gl.glGetCompressedTexImage_ = new Gl.Delegates.glGetCompressedTexImage_(Imports.glGetCompressedTexImage_);
                Gl.glBlendFuncSeparate = new Gl.Delegates.glBlendFuncSeparate(Imports.glBlendFuncSeparate);
                Gl.glFogCoordf = new Gl.Delegates.glFogCoordf(Imports.glFogCoordf);
                Gl.glFogCoordfv_ = new Gl.Delegates.glFogCoordfv_(Imports.glFogCoordfv_);
                Gl.glFogCoordd = new Gl.Delegates.glFogCoordd(Imports.glFogCoordd);
                Gl.glFogCoorddv_ = new Gl.Delegates.glFogCoorddv_(Imports.glFogCoorddv_);
                Gl.glFogCoordPointer_ = new Gl.Delegates.glFogCoordPointer_(Imports.glFogCoordPointer_);
                Gl.glMultiDrawArrays = new Gl.Delegates.glMultiDrawArrays(Imports.glMultiDrawArrays);
                Gl.glMultiDrawElements_ = new Gl.Delegates.glMultiDrawElements_(Imports.glMultiDrawElements_);
                Gl.glPointParameterf = new Gl.Delegates.glPointParameterf(Imports.glPointParameterf);
                Gl.glPointParameterfv_ = new Gl.Delegates.glPointParameterfv_(Imports.glPointParameterfv_);
                Gl.glPointParameteri = new Gl.Delegates.glPointParameteri(Imports.glPointParameteri);
                Gl.glPointParameteriv_ = new Gl.Delegates.glPointParameteriv_(Imports.glPointParameteriv_);
                Gl.glSecondaryColor3b = new Gl.Delegates.glSecondaryColor3b(Imports.glSecondaryColor3b);
                Gl.glSecondaryColor3bv_ = new Gl.Delegates.glSecondaryColor3bv_(Imports.glSecondaryColor3bv_);
                Gl.glSecondaryColor3d = new Gl.Delegates.glSecondaryColor3d(Imports.glSecondaryColor3d);
                Gl.glSecondaryColor3dv_ = new Gl.Delegates.glSecondaryColor3dv_(Imports.glSecondaryColor3dv_);
                Gl.glSecondaryColor3f = new Gl.Delegates.glSecondaryColor3f(Imports.glSecondaryColor3f);
                Gl.glSecondaryColor3fv_ = new Gl.Delegates.glSecondaryColor3fv_(Imports.glSecondaryColor3fv_);
                Gl.glSecondaryColor3i = new Gl.Delegates.glSecondaryColor3i(Imports.glSecondaryColor3i);
                Gl.glSecondaryColor3iv_ = new Gl.Delegates.glSecondaryColor3iv_(Imports.glSecondaryColor3iv_);
                Gl.glSecondaryColor3s = new Gl.Delegates.glSecondaryColor3s(Imports.glSecondaryColor3s);
                Gl.glSecondaryColor3sv_ = new Gl.Delegates.glSecondaryColor3sv_(Imports.glSecondaryColor3sv_);
                Gl.glSecondaryColor3ub = new Gl.Delegates.glSecondaryColor3ub(Imports.glSecondaryColor3ub);
                Gl.glSecondaryColor3ubv_ = new Gl.Delegates.glSecondaryColor3ubv_(Imports.glSecondaryColor3ubv_);
                Gl.glSecondaryColor3ui = new Gl.Delegates.glSecondaryColor3ui(Imports.glSecondaryColor3ui);
                Gl.glSecondaryColor3uiv_ = new Gl.Delegates.glSecondaryColor3uiv_(Imports.glSecondaryColor3uiv_);
                Gl.glSecondaryColor3us = new Gl.Delegates.glSecondaryColor3us(Imports.glSecondaryColor3us);
                Gl.glSecondaryColor3usv_ = new Gl.Delegates.glSecondaryColor3usv_(Imports.glSecondaryColor3usv_);
                Gl.glSecondaryColorPointer_ = new Gl.Delegates.glSecondaryColorPointer_(Imports.glSecondaryColorPointer_);
                Gl.glWindowPos2d = new Gl.Delegates.glWindowPos2d(Imports.glWindowPos2d);
                Gl.glWindowPos2dv_ = new Gl.Delegates.glWindowPos2dv_(Imports.glWindowPos2dv_);
                Gl.glWindowPos2f = new Gl.Delegates.glWindowPos2f(Imports.glWindowPos2f);
                Gl.glWindowPos2fv_ = new Gl.Delegates.glWindowPos2fv_(Imports.glWindowPos2fv_);
                Gl.glWindowPos2i = new Gl.Delegates.glWindowPos2i(Imports.glWindowPos2i);
                Gl.glWindowPos2iv_ = new Gl.Delegates.glWindowPos2iv_(Imports.glWindowPos2iv_);
                Gl.glWindowPos2s = new Gl.Delegates.glWindowPos2s(Imports.glWindowPos2s);
                Gl.glWindowPos2sv_ = new Gl.Delegates.glWindowPos2sv_(Imports.glWindowPos2sv_);
                Gl.glWindowPos3d = new Gl.Delegates.glWindowPos3d(Imports.glWindowPos3d);
                Gl.glWindowPos3dv_ = new Gl.Delegates.glWindowPos3dv_(Imports.glWindowPos3dv_);
                Gl.glWindowPos3f = new Gl.Delegates.glWindowPos3f(Imports.glWindowPos3f);
                Gl.glWindowPos3fv_ = new Gl.Delegates.glWindowPos3fv_(Imports.glWindowPos3fv_);
                Gl.glWindowPos3i = new Gl.Delegates.glWindowPos3i(Imports.glWindowPos3i);
                Gl.glWindowPos3iv_ = new Gl.Delegates.glWindowPos3iv_(Imports.glWindowPos3iv_);
                Gl.glWindowPos3s = new Gl.Delegates.glWindowPos3s(Imports.glWindowPos3s);
                Gl.glWindowPos3sv_ = new Gl.Delegates.glWindowPos3sv_(Imports.glWindowPos3sv_);
                Gl.glGenQueries = new Gl.Delegates.glGenQueries(Imports.glGenQueries);
                Gl.glDeleteQueries_ = new Gl.Delegates.glDeleteQueries_(Imports.glDeleteQueries_);
                Gl.glIsQuery = new Gl.Delegates.glIsQuery(Imports.glIsQuery);
                Gl.glBeginQuery = new Gl.Delegates.glBeginQuery(Imports.glBeginQuery);
                Gl.glEndQuery = new Gl.Delegates.glEndQuery(Imports.glEndQuery);
                Gl.glGetQueryiv = new Gl.Delegates.glGetQueryiv(Imports.glGetQueryiv);
                Gl.glGetQueryObjectiv = new Gl.Delegates.glGetQueryObjectiv(Imports.glGetQueryObjectiv);
                Gl.glGetQueryObjectuiv = new Gl.Delegates.glGetQueryObjectuiv(Imports.glGetQueryObjectuiv);
                Gl.glBindBuffer = new Gl.Delegates.glBindBuffer(Imports.glBindBuffer);
                Gl.glDeleteBuffers_ = new Gl.Delegates.glDeleteBuffers_(Imports.glDeleteBuffers_);
                Gl.glGenBuffers = new Gl.Delegates.glGenBuffers(Imports.glGenBuffers);
                Gl.glIsBuffer = new Gl.Delegates.glIsBuffer(Imports.glIsBuffer);
                Gl.glBufferData_ = new Gl.Delegates.glBufferData_(Imports.glBufferData_);
                Gl.glBufferSubData_ = new Gl.Delegates.glBufferSubData_(Imports.glBufferSubData_);
                Gl.glGetBufferSubData_ = new Gl.Delegates.glGetBufferSubData_(Imports.glGetBufferSubData_);
                Gl.glMapBuffer = new Gl.Delegates.glMapBuffer(Imports.glMapBuffer);
                Gl.glUnmapBuffer = new Gl.Delegates.glUnmapBuffer(Imports.glUnmapBuffer);
                Gl.glGetBufferParameteriv = new Gl.Delegates.glGetBufferParameteriv(Imports.glGetBufferParameteriv);
                Gl.glGetBufferPointerv = new Gl.Delegates.glGetBufferPointerv(Imports.glGetBufferPointerv);
                Gl.glBlendEquationSeparate = new Gl.Delegates.glBlendEquationSeparate(Imports.glBlendEquationSeparate);
                Gl.glDrawBuffers_ = new Gl.Delegates.glDrawBuffers_(Imports.glDrawBuffers_);
                Gl.glStencilOpSeparate = new Gl.Delegates.glStencilOpSeparate(Imports.glStencilOpSeparate);
                Gl.glStencilFuncSeparate = new Gl.Delegates.glStencilFuncSeparate(Imports.glStencilFuncSeparate);
                Gl.glStencilMaskSeparate = new Gl.Delegates.glStencilMaskSeparate(Imports.glStencilMaskSeparate);
                Gl.glAttachShader = new Gl.Delegates.glAttachShader(Imports.glAttachShader);
                Gl.glBindAttribLocation_ = new Gl.Delegates.glBindAttribLocation_(Imports.glBindAttribLocation_);
                Gl.glCompileShader = new Gl.Delegates.glCompileShader(Imports.glCompileShader);
                Gl.glCreateProgram = new Gl.Delegates.glCreateProgram(Imports.glCreateProgram);
                Gl.glCreateShader = new Gl.Delegates.glCreateShader(Imports.glCreateShader);
                Gl.glDeleteProgram = new Gl.Delegates.glDeleteProgram(Imports.glDeleteProgram);
                Gl.glDeleteShader = new Gl.Delegates.glDeleteShader(Imports.glDeleteShader);
                Gl.glDetachShader = new Gl.Delegates.glDetachShader(Imports.glDetachShader);
                Gl.glDisableVertexAttribArray = new Gl.Delegates.glDisableVertexAttribArray(Imports.glDisableVertexAttribArray);
                Gl.glEnableVertexAttribArray = new Gl.Delegates.glEnableVertexAttribArray(Imports.glEnableVertexAttribArray);
                Gl.glGetActiveAttrib = new Gl.Delegates.glGetActiveAttrib(Imports.glGetActiveAttrib);
                Gl.glGetActiveUniform = new Gl.Delegates.glGetActiveUniform(Imports.glGetActiveUniform);
                Gl.glGetAttachedShaders = new Gl.Delegates.glGetAttachedShaders(Imports.glGetAttachedShaders);
                Gl.glGetAttribLocation_ = new Gl.Delegates.glGetAttribLocation_(Imports.glGetAttribLocation_);
                Gl.glGetProgramiv = new Gl.Delegates.glGetProgramiv(Imports.glGetProgramiv);
                Gl.glGetProgramInfoLog = new Gl.Delegates.glGetProgramInfoLog(Imports.glGetProgramInfoLog);
                Gl.glGetShaderiv = new Gl.Delegates.glGetShaderiv(Imports.glGetShaderiv);
                Gl.glGetShaderInfoLog = new Gl.Delegates.glGetShaderInfoLog(Imports.glGetShaderInfoLog);
                Gl.glGetShaderSource = new Gl.Delegates.glGetShaderSource(Imports.glGetShaderSource);
                Gl.glGetUniformLocation_ = new Gl.Delegates.glGetUniformLocation_(Imports.glGetUniformLocation_);
                Gl.glGetUniformfv = new Gl.Delegates.glGetUniformfv(Imports.glGetUniformfv);
                Gl.glGetUniformiv = new Gl.Delegates.glGetUniformiv(Imports.glGetUniformiv);
                Gl.glGetVertexAttribdv = new Gl.Delegates.glGetVertexAttribdv(Imports.glGetVertexAttribdv);
                Gl.glGetVertexAttribfv = new Gl.Delegates.glGetVertexAttribfv(Imports.glGetVertexAttribfv);
                Gl.glGetVertexAttribiv = new Gl.Delegates.glGetVertexAttribiv(Imports.glGetVertexAttribiv);
                Gl.glGetVertexAttribPointerv = new Gl.Delegates.glGetVertexAttribPointerv(Imports.glGetVertexAttribPointerv);
                Gl.glIsProgram = new Gl.Delegates.glIsProgram(Imports.glIsProgram);
                Gl.glIsShader = new Gl.Delegates.glIsShader(Imports.glIsShader);
                Gl.glLinkProgram = new Gl.Delegates.glLinkProgram(Imports.glLinkProgram);
                Gl.glShaderSource_ = new Gl.Delegates.glShaderSource_(Imports.glShaderSource_);
                Gl.glUseProgram = new Gl.Delegates.glUseProgram(Imports.glUseProgram);
                Gl.glUniform1f = new Gl.Delegates.glUniform1f(Imports.glUniform1f);
                Gl.glUniform2f = new Gl.Delegates.glUniform2f(Imports.glUniform2f);
                Gl.glUniform3f = new Gl.Delegates.glUniform3f(Imports.glUniform3f);
                Gl.glUniform4f = new Gl.Delegates.glUniform4f(Imports.glUniform4f);
                Gl.glUniform1i = new Gl.Delegates.glUniform1i(Imports.glUniform1i);
                Gl.glUniform2i = new Gl.Delegates.glUniform2i(Imports.glUniform2i);
                Gl.glUniform3i = new Gl.Delegates.glUniform3i(Imports.glUniform3i);
                Gl.glUniform4i = new Gl.Delegates.glUniform4i(Imports.glUniform4i);
                Gl.glUniform1fv_ = new Gl.Delegates.glUniform1fv_(Imports.glUniform1fv_);
                Gl.glUniform2fv_ = new Gl.Delegates.glUniform2fv_(Imports.glUniform2fv_);
                Gl.glUniform3fv_ = new Gl.Delegates.glUniform3fv_(Imports.glUniform3fv_);
                Gl.glUniform4fv_ = new Gl.Delegates.glUniform4fv_(Imports.glUniform4fv_);
                Gl.glUniform1iv_ = new Gl.Delegates.glUniform1iv_(Imports.glUniform1iv_);
                Gl.glUniform2iv_ = new Gl.Delegates.glUniform2iv_(Imports.glUniform2iv_);
                Gl.glUniform3iv_ = new Gl.Delegates.glUniform3iv_(Imports.glUniform3iv_);
                Gl.glUniform4iv_ = new Gl.Delegates.glUniform4iv_(Imports.glUniform4iv_);
                Gl.glUniformMatrix2fv_ = new Gl.Delegates.glUniformMatrix2fv_(Imports.glUniformMatrix2fv_);
                Gl.glUniformMatrix3fv_ = new Gl.Delegates.glUniformMatrix3fv_(Imports.glUniformMatrix3fv_);
                Gl.glUniformMatrix4fv_ = new Gl.Delegates.glUniformMatrix4fv_(Imports.glUniformMatrix4fv_);
                Gl.glValidateProgram = new Gl.Delegates.glValidateProgram(Imports.glValidateProgram);
                Gl.glVertexAttrib1d = new Gl.Delegates.glVertexAttrib1d(Imports.glVertexAttrib1d);
                Gl.glVertexAttrib1dv_ = new Gl.Delegates.glVertexAttrib1dv_(Imports.glVertexAttrib1dv_);
                Gl.glVertexAttrib1f = new Gl.Delegates.glVertexAttrib1f(Imports.glVertexAttrib1f);
                Gl.glVertexAttrib1fv_ = new Gl.Delegates.glVertexAttrib1fv_(Imports.glVertexAttrib1fv_);
                Gl.glVertexAttrib1s = new Gl.Delegates.glVertexAttrib1s(Imports.glVertexAttrib1s);
                Gl.glVertexAttrib1sv_ = new Gl.Delegates.glVertexAttrib1sv_(Imports.glVertexAttrib1sv_);
                Gl.glVertexAttrib2d = new Gl.Delegates.glVertexAttrib2d(Imports.glVertexAttrib2d);
                Gl.glVertexAttrib2dv_ = new Gl.Delegates.glVertexAttrib2dv_(Imports.glVertexAttrib2dv_);
                Gl.glVertexAttrib2f = new Gl.Delegates.glVertexAttrib2f(Imports.glVertexAttrib2f);
                Gl.glVertexAttrib2fv_ = new Gl.Delegates.glVertexAttrib2fv_(Imports.glVertexAttrib2fv_);
                Gl.glVertexAttrib2s = new Gl.Delegates.glVertexAttrib2s(Imports.glVertexAttrib2s);
                Gl.glVertexAttrib2sv_ = new Gl.Delegates.glVertexAttrib2sv_(Imports.glVertexAttrib2sv_);
                Gl.glVertexAttrib3d = new Gl.Delegates.glVertexAttrib3d(Imports.glVertexAttrib3d);
                Gl.glVertexAttrib3dv_ = new Gl.Delegates.glVertexAttrib3dv_(Imports.glVertexAttrib3dv_);
                Gl.glVertexAttrib3f = new Gl.Delegates.glVertexAttrib3f(Imports.glVertexAttrib3f);
                Gl.glVertexAttrib3fv_ = new Gl.Delegates.glVertexAttrib3fv_(Imports.glVertexAttrib3fv_);
                Gl.glVertexAttrib3s = new Gl.Delegates.glVertexAttrib3s(Imports.glVertexAttrib3s);
                Gl.glVertexAttrib3sv_ = new Gl.Delegates.glVertexAttrib3sv_(Imports.glVertexAttrib3sv_);
                Gl.glVertexAttrib4Nbv_ = new Gl.Delegates.glVertexAttrib4Nbv_(Imports.glVertexAttrib4Nbv_);
                Gl.glVertexAttrib4Niv_ = new Gl.Delegates.glVertexAttrib4Niv_(Imports.glVertexAttrib4Niv_);
                Gl.glVertexAttrib4Nsv_ = new Gl.Delegates.glVertexAttrib4Nsv_(Imports.glVertexAttrib4Nsv_);
                Gl.glVertexAttrib4Nub = new Gl.Delegates.glVertexAttrib4Nub(Imports.glVertexAttrib4Nub);
                Gl.glVertexAttrib4Nubv_ = new Gl.Delegates.glVertexAttrib4Nubv_(Imports.glVertexAttrib4Nubv_);
                Gl.glVertexAttrib4Nuiv_ = new Gl.Delegates.glVertexAttrib4Nuiv_(Imports.glVertexAttrib4Nuiv_);
                Gl.glVertexAttrib4Nusv_ = new Gl.Delegates.glVertexAttrib4Nusv_(Imports.glVertexAttrib4Nusv_);
                Gl.glVertexAttrib4bv_ = new Gl.Delegates.glVertexAttrib4bv_(Imports.glVertexAttrib4bv_);
                Gl.glVertexAttrib4d = new Gl.Delegates.glVertexAttrib4d(Imports.glVertexAttrib4d);
                Gl.glVertexAttrib4dv_ = new Gl.Delegates.glVertexAttrib4dv_(Imports.glVertexAttrib4dv_);
                Gl.glVertexAttrib4f = new Gl.Delegates.glVertexAttrib4f(Imports.glVertexAttrib4f);
                Gl.glVertexAttrib4fv_ = new Gl.Delegates.glVertexAttrib4fv_(Imports.glVertexAttrib4fv_);
                Gl.glVertexAttrib4iv_ = new Gl.Delegates.glVertexAttrib4iv_(Imports.glVertexAttrib4iv_);
                Gl.glVertexAttrib4s = new Gl.Delegates.glVertexAttrib4s(Imports.glVertexAttrib4s);
                Gl.glVertexAttrib4sv_ = new Gl.Delegates.glVertexAttrib4sv_(Imports.glVertexAttrib4sv_);
                Gl.glVertexAttrib4ubv_ = new Gl.Delegates.glVertexAttrib4ubv_(Imports.glVertexAttrib4ubv_);
                Gl.glVertexAttrib4uiv_ = new Gl.Delegates.glVertexAttrib4uiv_(Imports.glVertexAttrib4uiv_);
                Gl.glVertexAttrib4usv_ = new Gl.Delegates.glVertexAttrib4usv_(Imports.glVertexAttrib4usv_);
                Gl.glVertexAttribPointer_ = new Gl.Delegates.glVertexAttribPointer_(Imports.glVertexAttribPointer_);
                #endregion
            }
        }
        #endregion

        public static Delegate GetAddress(string s, Type function_signature)
        {
            IntPtr address = Tao.OpenGl.GlExtensionLoader.GetProcAddress(s);
            if (address == IntPtr.Zero)
                return null;
            else
                return Marshal.GetDelegateForFunctionPointer(address, function_signature);
        }
    }
}

