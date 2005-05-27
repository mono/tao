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
using System.Runtime.InteropServices;
using System.Security;

namespace Tao.Cg {
    #region Class Documentation
    /// <summary>
    ///     Cg core runtime binding for .NET, implementing Cg 1.2.1.
    /// </summary>
    /// <remarks>
    ///     Binds functions and definitions in cgGL.dll or libcgGL.so.
    /// </remarks>
    #endregion Class Documentation
    public sealed class CgGl {
        #region Private Constants
        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.Cdecl" /> for Windows and Linux.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants

        #region Public Constants

        #region Enums
        #region CG_GL_MATRIX_IDENTITY
        /// <summary>
        /// Identity matrix.
        /// </summary>
        /// CG_GL_MATRIX_IDENTITY = 0
        public const int CG_GL_MATRIX_IDENTITY = 0;
        #endregion

        #region CG_GL_MATRIX_TRANSPOSE
        /// <summary>
        /// Transpose matrix.
        /// </summary>
        /// CG_GL_MATRIX_TRANSPOSE = 1
        public const int CG_GL_MATRIX_TRANSPOSE = 1;

        #endregion

        #region CG_GL_MATRIX_INVERSE
        /// <summary>
        /// Inverse matrix.
        /// </summary>
        /// CG_GL_MATRIX_INVERSE = 2
        public const int CG_GL_MATRIX_INVERSE = 2;
        #endregion

        #region CG_GL_MATRIX_INVERSE_TRANSPOSE
        /// <summary>
        /// Inverse and transpose the matrix.
        /// </summary>
        /// CG_GL_MATRIX_INVERSE_TRANSPOSE = 3
        public const int CG_GL_MATRIX_INVERSE_TRANSPOSE = 3;
        #endregion


        #region CG_GL_MODELVIEW_MATRIX
        /// <summary>
        /// Modelview matrix.
        /// </summary>
        /// CG_GL_MODELVIEW_MATRIX = 4
        public const int CG_GL_MODELVIEW_MATRIX = 4;
        #endregion

        #region CG_GL_PROJECTION_MATRIX
        /// <summary>
        /// Projection matrix.
        /// </summary>
        /// CG_GL_PROJECTION_MATRIX = 5
        public const int CG_GL_PROJECTION_MATRIX = 5;

        #endregion

        #region CG_GL_TEXTURE_MATRIX
        /// <summary>
        /// Texture matrix.
        /// </summary>
        /// CG_GL_TEXTURE_MATRIX = 6
        public const int CG_GL_TEXTURE_MATRIX = 6;
        #endregion

        #region CG_GL_MODELVIEW_PROJECTION_MATRIX
        /// <summary>
        /// Concatenated modelview and projection matrices.
        /// </summary>
        /// CG_GL_MATRIX_INVERSE_TRANSPOSE = 7
        public const int CG_GL_MODELVIEW_PROJECTION_MATRIX = 7;
        #endregion


        #region CG_GL_VERTEX
        /// <summary>
        /// Vertex profile (returned by cgGLGetLatestProfile)
        /// </summary>
        /// CG_GL_VERTEX = 8
        public const int CG_GL_VERTEX = 8;
        #endregion

        #region CG_GL_FRAGMENT
        /// <summary>
        /// Fragment profile (returned by cgGLGetLatestProfile)
        /// </summary>
        /// CG_GL_FRAGMENT = 9
        public const int CG_GL_FRAGMENT = 9;
        #endregion
        #endregion Enums


        #endregion Public Constants

        // --- Constructors & Destructors ---
        #region CgGl()
        /// <summary>
        ///     Prevents instantiation.
        /// </summary>
        private CgGl() {
        }
        #endregion CgGl()

        // --- Public Externs ---
        #region Program Functions

        #region void cgGLIsProgramLoaded(IntPtr program)
        /// <summary>
        /// Returns true if the specified program is loaded.
        /// </summary>
        /// <param name="program">
        /// Handle to the program.
        /// </param>
        /// <returns>
        /// True if the specified program is loaded.
        /// </returns>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern bool cgGLIsProgramLoaded(IntPtr program);
        #endregion bool cgGLIsProgramLoaded(IntPtr program)

        #region void cgGLGetProgramID(IntPtr program)
        /// <summary>
        /// Returns the program's ID.
        /// </summary>
        /// <param name="program">
        /// Handle to the program.
        /// </param>
        /// <returns>
        /// Program's ID.
        /// </returns>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGLGetProgramID(IntPtr program);
        #endregion bool cgGLGetProgramID(IntPtr program)

        #region void cgGLLoadProgram(IntPtr program)
        /// <summary>
        /// Loads program to OpenGL pipeline
        /// </summary>
        /// <param name="program">
        /// Handle to the program to load.
        /// </param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLLoadProgram(IntPtr program);
        #endregion void cgGLLoadProgram(IntPtr program)

        #region void cgGLBindProgram(IntPtr program)
        /// <summary>
        /// Bind the program to the current OpenGL API state.
        /// </summary>
        /// <param name="program">
        /// Handle to the program to bind.
        /// </param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLBindProgram(IntPtr program);
        #endregion void cgGLBindProgram(IntPtr program)

        #region void cgGLUnbindProgram(int profile)
        /// <summary>
        /// Unbinds the program bound in a profile.
        /// </summary>
        /// <param name="profile">
        /// Handle to the profile to unbind programs from.
        /// </param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLUnbindProgram(int profile);
        #endregion void cgGLUnbindProgram(int profile)


        #endregion

        #region Profile Functions

        #region void cgGLSetOptimalOptions(int profile)
        /// <summary>
        /// Sets the best compiler options available by card, driver and selected profile.
        /// </summary>
        /// <param name="profile">
        /// Profile.
        /// </param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetOptimalOptions(int profile);
        #endregion void cgGLSetOptimalOptions(int profile)

        #region int cgGLGetLatestProfile(int profile_type)
        /// <summary>
        /// Returns the best profile available.
        /// </summary>
        /// <param name="profile_type">
        /// CG_GL_VERTEX or CG_GL_FRAGMENT program to look for the best matching profile.
        /// </param>
        /// <returns>
        /// Returns the best profile available.
        /// </returns>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGLGetLatestProfile(int profile_type);
        #endregion int cgGLGetLatestProfile(int profile_type)

        #region bool cgGLIsProfileSupported(int profile)
        /// <summary>
        /// Checks if the profile is supported.
        /// </summary>
        /// <param name="profile">
        /// The profile to check the support of.
        /// </param>
        /// <returns>
        /// Returns true if the profile is supported.
        /// </returns>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern bool cgGLIsProfileSupported(int profile);
        #endregion bool cgGLIsProfileSupported(int profile)

        #region void cgGLEnableProfile(int profile)
        /// <summary>
        /// Enables the selected profile.
        /// </summary>
        /// <param name="profile">
        /// Profile to enable.
        /// </param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLEnableProfile(int profile);
        #endregion void cgGLEnableProfile(int profile)

        #region void cgGLDisableProfile(int profile)
        /// <summary>
        /// Disables the selected profile.
        /// </summary>
        /// <param name="profile">
        /// Profile to disable.
        /// </param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLDisableProfile(int profile);
        #endregion void cgGLDisableProfile(int profile)


        #endregion 

        #region Parameter Managment Functions
        #region cgGLSetParameterPointer
        #region void cgGLSetParameterPointer(IntPtr param, int fsize, int type, int stride, [In] float* pointer)
        /// <summary>
        /// Sets parameter with attribute array.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="fsize">Number of coordinates per vertex.</param>
        /// <param name="type">Data type of each coordinate.</param>
        /// <param name="stride">Specifies the byte offset between consecutive vertices. If stride is 0 the array is assumed to be tightly packed.</param>
        /// <param name="pointer">The pointer to the first coordinate in the vertex array.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameterPointer(IntPtr param, int fsize, int type, int stride, [In] void* pointer);
        #endregion void cgGLSetParameterPointer(IntPtr param, int fsize, int type, int stride, [In] void* pointer)
        #region void cgGLSetParameterPointer(IntPtr param, int fsize, int type, int stride, [In] IntPtr pointer)
        /// <summary>
        /// Sets parameter with attribute array.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="fsize">Number of coordinates per vertex.</param>
        /// <param name="type">Data type of each coordinate.</param>
        /// <param name="stride">Specifies the byte offset between consecutive vertices. If stride is 0 the array is assumed to be tightly packed.</param>
        /// <param name="pointer">The pointer to the first coordinate in the vertex array.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterPointer(IntPtr param, int fsize, int type, int stride, [In] IntPtr pointer);
        #endregion void cgGLSetParameterPointer(IntPtr param, int fsize, int type, int stride, [In] IntPtr pointer)
        #endregion

        #region void cgGLEnableClientState(IntPtr param)
        /// <summary>
        ///     Enables a vertex attribute in OpenGL state.
        /// </summary>
        /// <param name="param">Parameter to enable.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLEnableClientState(IntPtr param);
        #endregion void cgGLEnableClientState(IntPtr param)
        #region void cgGLDisableClientState(IntPtr param)
        /// <summary>
        ///     Disables a vertex attribute in OpenGL state.
        /// </summary>
        /// <param name="param">Parameter to disable.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLDisableClientState(IntPtr param);
        #endregion void cgGLDisableClientState(IntPtr param)

        #region cgGLSetParameterNf
        #region void cgGLSetParameter1f(IntPtr param, float x)
        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter1f(IntPtr param, float x);
        #endregion void cgGLSetParameter1f(IntPtr param, float x)

        #region void cgGLSetParameter2f(IntPtr param, float x, float y)
        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter2f(IntPtr param, float x, float y);
        #endregion void cgGLSetParameter2f(IntPtr param, float x, float y)

        #region void cgGLSetParameter3f(IntPtr param, float x, float y, float z)
        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter3f(IntPtr param, float x, float y, float z);
        #endregion void cgGLSetParameter3f(IntPtr param, float x, float y, float z)

        #region void cgGLSetParameter4f(IntPtr param, float x, float y, float z, float w)
        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter4f(IntPtr param, float x, float y, float z, float w);
        #endregion void cgGLSetParameter4f(IntPtr param, float x, float y, float z, float w)
        #endregion

        #region cgGLSetParameterNfv
        #region void cgGLSetParameter1fv(IntPtr param, [In] float* values)
        /// <summary>
        /// Sets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameter1fv(IntPtr param, [In] float* values);
        #endregion void cgGLSetParameter1fv(IntPtr param, [In] float* values)

        #region void cgGLSetParameter1fv(IntPtr param, [In] float[] values)
        /// <summary>
        /// Sets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter1fv(IntPtr param, [In] float[] values);
        #endregion void cgGLSetParameter1fv(IntPtr param, [In] float[] values)

        #region void cgGLSetParameter1fv(IntPtr param, [In] IntPtr values)
        /// <summary>
        /// Sets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter1fv(IntPtr param, [In] IntPtr values);
        #endregion void cgGLSetParameter1fv(IntPtr param, [In] IntPtr values)

        #region void cgGLSetParameter2fv(IntPtr param, [In] float* values)
        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameter2fv(IntPtr param, [In] float* values);
        #endregion void cgGLSetParameter2fv(IntPtr param, [In] float* values)

        #region void cgGLSetParameter2fv(IntPtr param, [In] float[] values)
        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter2fv(IntPtr param, [In] float[] values);
        #endregion void cgGLSetParameter2fv(IntPtr param, [In] float[] values)

        #region void cgGLSetParameter2fv(IntPtr param, [In] IntPtr values)
        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter2fv(IntPtr param, [In] IntPtr values);
        #endregion void cgGLSetParameter2fv(IntPtr param, [In] IntPtr values)

        #region void cgGLSetParameter3fv(IntPtr param, [In] float* values)
        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameter3fv(IntPtr param, [In] float* values);
        #endregion void cgGLSetParameter3fv(IntPtr param, [In] float* values)

        #region void cgGLSetParameter3fv(IntPtr param, [In] float[] values)
        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter3fv(IntPtr param, [In] float[] values);
        #endregion void cgGLSetParameter3fv(IntPtr param, [In] float[] values)

        #region void cgGLSetParameter3fv(IntPtr param, [In] IntPtr values)
        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter3fv(IntPtr param, [In] IntPtr values);
        #endregion void cgGLSetParameter3fv(IntPtr param, [In] IntPtr values)

        #region void cgGLSetParameter4fv(IntPtr param, [In] float* values)
        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameter4fv(IntPtr param, [In] float* values);
        #endregion void cgGLSetParameter4fv(IntPtr param, [In] float* values)

        #region void cgGLSetParameter4fv(IntPtr param, [In] float[] values)
        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter4fv(IntPtr param, [In] float[] values);
        #endregion void cgGLSetParameter4fv(IntPtr param, [In] float[] values)

        #region void cgGLSetParameter4fv(IntPtr param, [In] IntPtr values)
        /// <summary>
        /// Sets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter4fv(IntPtr param, [In] IntPtr values);
        #endregion void cgGLSetParameter4fv(IntPtr param, [In] IntPtr values)


        #endregion 

        #region cgGLSetParameterNd
        #region void cgGLSetParameter1d(IntPtr param, double x)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter1d(IntPtr param, double x);
        #endregion void cgGLSetParameter1d(IntPtr param, double x)

        #region void cgGLSetParameter2d(IntPtr param, double x, double y)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter2d(IntPtr param, double x, double y);
        #endregion void cgGLSetParameter2d(IntPtr param, double x, double y)

        #region void cgGLSetParameter3d(IntPtr param, double x, double y, double z)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter3d(IntPtr param, double x, double y, double z);
        #endregion void cgGLSetParameter3d(IntPtr param, double x, double y, double z)

        #region void cgGLSetParameter4d(IntPtr param, double x, double y, double z, double w)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter4d(IntPtr param, double x, double y, double z, double w);
        #endregion void cgGLSetParameter4d(IntPtr param, double x, double y, double z, double w)
        #endregion

        #region cgGLSetParameterNdv
        #region void cgGLSetParameter1dv(IntPtr param, [In] double* values)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameter1dv(IntPtr param, [In] double* values);
        #endregion void cgGLSetParameter1dv(IntPtr param, [In] double* values)

        #region void cgGLSetParameter1dv(IntPtr param, [In] double[] values)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter1dv(IntPtr param, [In] double[] values);
        #endregion void cgGLSetParameter1dv(IntPtr param, [In] double[] values)

        #region void cgGLSetParameter1dv(IntPtr param, [In] IntPtr values)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter1dv(IntPtr param, [In] IntPtr values);
        #endregion void cgGLSetParameter1dv(IntPtr param, [In] IntPtr values)

        #region void cgGLSetParameter2dv(IntPtr param, [In] double* values)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameter2dv(IntPtr param, [In] double* values);
        #endregion void cgGLSetParameter2dv(IntPtr param, [In] double* values)

        #region void cgGLSetParameter2dv(IntPtr param, [In] double[] values)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter2dv(IntPtr param, [In] double[] values);
        #endregion void cgGLSetParameter2dv(IntPtr param, [In] double[] values)

        #region void cgGLSetParameter2dv(IntPtr param, [In] IntPtr values)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter2dv(IntPtr param, [In] IntPtr values);
        #endregion void cgGLSetParameter2dv(IntPtr param, [In] IntPtr values)

        #region void cgGLSetParameter3dv(IntPtr param, [In] double* values)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameter3dv(IntPtr param, [In] double* values);
        #endregion void cgGLSetParameter3dv(IntPtr param, [In] double* values)

        #region void cgGLSetParameter3dv(IntPtr param, [In] double[] values)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter3dv(IntPtr param, [In] double[] values);
        #endregion void cgGLSetParameter3dv(IntPtr param, [In] double[] values)

        #region void cgGLSetParameter3dv(IntPtr param, [In] IntPtr values)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter3dv(IntPtr param, [In] IntPtr values);
        #endregion void cgGLSetParameter3dv(IntPtr param, [In] IntPtr values)

        #region void cgGLSetParameter4dv(IntPtr param, [In] double* values)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameter4dv(IntPtr param, [In] double* values);
        #endregion void cgGLSetParameter4dv(IntPtr param, [In] double* values)

        #region void cgGLSetParameter4dv(IntPtr param, [In] double[] values)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter4dv(IntPtr param, [In] double[] values);
        #endregion void cgGLSetParameter4dv(IntPtr param, [In] double[] values)

        #region void cgGLSetParameter4dv(IntPtr param, [In] IntPtr values)
        /// <summary>
        /// Sets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameter4dv(IntPtr param, [In] IntPtr values);
        #endregion void cgGLSetParameter4dv(IntPtr param, [In] IntPtr values)

        #endregion 

        #region cgGLGetParameterNf
        #region void cgGLGetParameter1f(IntPtr param, [Out] float* values)
        /// <summary>
        /// Gets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameter1f(IntPtr param, [Out] float* values);
        #endregion void cgGLGetParameter1f(IntPtr param, [Out] float* values)
        #region void cgGLGetParameter1f(IntPtr param, [Out] float[] values)
        /// <summary>
        /// Gets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter1f(IntPtr param, [Out] float[] values);
        #endregion void cgGLGetParameter1f(IntPtr param, [Out] float[] values)
        #region void cgGLGetParameter1f(IntPtr param, [Out] IntPtr values)
        /// <summary>
        /// Gets the float value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter1f(IntPtr param, [Out] IntPtr values);
        #endregion void cgGLGetParameter1f(IntPtr param, [Out] IntPtr values)

        #region void cgGLGetParameter2f(IntPtr param, [Out] float* values)
        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameter2f(IntPtr param, [Out] float* values);
        #endregion void cgGLGetParameter2f(IntPtr param, [Out] float* values)
        #region void cgGLGetParameter2f(IntPtr param, [Out] float[] values)
        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter2f(IntPtr param, [Out] float[] values);
        #endregion void cgGLGetParameter2f(IntPtr param, [Out] float[] values)
        #region void cgGLGetParameter2f(IntPtr param, [Out] IntPtr values)
        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter2f(IntPtr param, [Out] IntPtr values);
        #endregion void cgGLGetParameter2f(IntPtr param, [Out] IntPtr values)

        #region void cgGLGetParameter3f(IntPtr param, [Out] float* values)
        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameter3f(IntPtr param, [Out] float* values);
        #endregion void cgGLGetParameter3f(IntPtr param, [Out] float* values)
        #region void cgGLGetParameter3f(IntPtr param, [Out] float[] values)
        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter3f(IntPtr param, [Out] float[] values);
        #endregion void cgGLGetParameter3f(IntPtr param, [Out] float[] values)
        #region void cgGLGetParameter3f(IntPtr param, [Out] IntPtr values)
        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter3f(IntPtr param, [Out] IntPtr values);
        #endregion void cgGLGetParameter3f(IntPtr param, [Out] IntPtr values)

        #region void cgGLGetParameter4f(IntPtr param, [Out] float* values)
        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameter4f(IntPtr param, [Out] float* values);
        #endregion void cgGLGetParameter4f(IntPtr param, [Out] float* values)
        #region void cgGLGetParameter4f(IntPtr param, [Out] float[] values)
        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter4f(IntPtr param, [Out] float[] values);
        #endregion void cgGLGetParameter4f(IntPtr param, [Out] float[] values)
        #region void cgGLGetParameter4f(IntPtr param, [Out] IntPtr values)
        /// <summary>
        /// Gets the float values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter4f(IntPtr param, [Out] IntPtr values);
        #endregion void cgGLGetParameter4f(IntPtr param, [Out] IntPtr values)
        #endregion

        #region cgGLGetParameterNd
        #region void cgGLGetParameter1d(IntPtr param, [Out] double* values)
        /// <summary>
        /// Gets the double value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameter1d(IntPtr param, [Out] double* values);
        #endregion void cgGLGetParameter1d(IntPtr param, [Out] double* values)
        #region void cgGLGetParameter1d(IntPtr param, [Out] double[] values)
        /// <summary>
        /// Gets the double value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter1d(IntPtr param, [Out] double[] values);
        #endregion void cgGLGetParameter1d(IntPtr param, [Out] double[] values)
        #region void cgGLGetParameter1d(IntPtr param, [Out] IntPtr values)
        /// <summary>
        /// Gets the double value to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter1d(IntPtr param, [Out] IntPtr values);
        #endregion void cgGLGetParameter1d(IntPtr param, [Out] IntPtr values)

        #region void cgGLGetParameter2d(IntPtr param, [Out] double* values)
        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameter2d(IntPtr param, [Out] double* values);
        #endregion void cgGLGetParameter2d(IntPtr param, [Out] double* values)
        #region void cgGLGetParameter2d(IntPtr param, [Out] double[] values)
        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter2d(IntPtr param, [Out] double[] values);
        #endregion void cgGLGetParameter2d(IntPtr param, [Out] double[] values)
        #region void cgGLGetParameter2d(IntPtr param, [Out] IntPtr values)
        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter2d(IntPtr param, [Out] IntPtr values);
        #endregion void cgGLGetParameter2d(IntPtr param, [Out] IntPtr values)

        #region void cgGLGetParameter3d(IntPtr param, [Out] double* values)
        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameter3d(IntPtr param, [Out] double* values);
        #endregion void cgGLGetParameter3d(IntPtr param, [Out] double* values)
        #region void cgGLGetParameter3d(IntPtr param, [Out] double[] values)
        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter3d(IntPtr param, [Out] double[] values);
        #endregion void cgGLGetParameter3d(IntPtr param, [Out] double[] values)
        #region void cgGLGetParameter3d(IntPtr param, [Out] IntPtr values)
        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter3d(IntPtr param, [Out] IntPtr values);
        #endregion void cgGLGetParameter3d(IntPtr param, [Out] IntPtr values)

        #region void cgGLGetParameter4d(IntPtr param, [Out] double* values)
        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameter4d(IntPtr param, [Out] double* values);
        #endregion void cgGLGetParameter4d(IntPtr param, [Out] double* values)
        #region void cgGLGetParameter4d(IntPtr param, [Out] double[] values)
        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter4d(IntPtr param, [Out] double[] values);
        #endregion void cgGLGetParameter4d(IntPtr param, [Out] double[] values)
        #region void cgGLGetParameter4d(IntPtr param, [Out] IntPtr values)
        /// <summary>
        /// Gets the double values to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameter4d(IntPtr param, [Out] IntPtr values);
        #endregion void cgGLGetParameter4d(IntPtr param, [Out] IntPtr values)
        #endregion

        #region Arrays
        #region cgGLSetParameterArrayNf
        #region void cgGLSetParameterArray1f(IntPtr param, long offset, long nelements, [In] float* values)
        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameterArray1f(IntPtr param, long offset, long nelements, [In] float* values);
        #endregion void cgGLSetParameterArray1f(IntPtr param, long offset, long nelements, [In] float* values)
        #region void cgGLSetParameterArray1f(IntPtr param, long offset, long nelements, [In] float[] values)
        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray1f(IntPtr param, long offset, long nelements, [In] float[] values);
        #endregion void cgGLSetParameterArray1f(IntPtr param, long offset, long nelements, [In] float[] values)
        #region void cgGLSetParameterArray1f(IntPtr param, long offset, long nelements, [In] IntPtr values)
        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray1f(IntPtr param, long offset, long nelements, [In] IntPtr values);
        #endregion void cgGLSetParameterArray1f(IntPtr param, long offset, long nelements, [In] IntPtr values)

        #region void cgGLSetParameterArray2f(IntPtr param, long offset, long nelements, [In] float* values)
        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameterArray2f(IntPtr param, long offset, long nelements, [In] float* values);
        #endregion void cgGLSetParameterArray2f(IntPtr param, long offset, long nelements, [In] float* values)
        #region void cgGLSetParameterArray2f(IntPtr param, long offset, long nelements, [In] float[] values)
        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray2f(IntPtr param, long offset, long nelements, [In] float[] values);
        #endregion void cgGLSetParameterArray2f(IntPtr param, long offset, long nelements, [In] float[] values)
        #region void cgGLSetParameterArray2f(IntPtr param, long offset, long nelements, [In] IntPtr values)
        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray2f(IntPtr param, long offset, long nelements, [In] IntPtr values);
        #endregion void cgGLSetParameterArray2f(IntPtr param, long offset, long nelements, [In] IntPtr values)

        #region void cgGLSetParameterArray3f(IntPtr param, long offset, long nelements, [In] float* values)
        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameterArray3f(IntPtr param, long offset, long nelements, [In] float* values);
        #endregion void cgGLSetParameterArray3f(IntPtr param, long offset, long nelements, [In] float* values)
        #region void cgGLSetParameterArray3f(IntPtr param, long offset, long nelements, [In] float[] values)
        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray3f(IntPtr param, long offset, long nelements, [In] float[] values);
        #endregion void cgGLSetParameterArray3f(IntPtr param, long offset, long nelements, [In] float[] values)
        #region void cgGLSetParameterArray3f(IntPtr param, long offset, long nelements, [In] IntPtr values)
        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray3f(IntPtr param, long offset, long nelements, [In] IntPtr values);
        #endregion void cgGLSetParameterArray3f(IntPtr param, long offset, long nelements, [In] IntPtr values)

        #region void cgGLSetParameterArray4f(IntPtr param, long offset, long nelements, [In] float* values)
        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameterArray4f(IntPtr param, long offset, long nelements, [In] float* values);
        #endregion void cgGLSetParameterArray4f(IntPtr param, long offset, long nelements, [In] float* values)
        #region void cgGLSetParameterArray4f(IntPtr param, long offset, long nelements, [In] float[] values)
        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray4f(IntPtr param, long offset, long nelements, [In] float[] values);
        #endregion void cgGLSetParameterArray4f(IntPtr param, long offset, long nelements, [In] float[] values)
        #region void cgGLSetParameterArray4f(IntPtr param, long offset, long nelements, [In] IntPtr values)
        /// <summary>
        /// Sets the float values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray4f(IntPtr param, long offset, long nelements, [In] IntPtr values);
        #endregion void cgGLSetParameterArray4f(IntPtr param, long offset, long nelements, [In] IntPtr values)
        #endregion
        #region cgGLSetParameterArrayNd
        #region void cgGLSetParameterArray1d(IntPtr param, long offset, long nelements, [In] double* values)
        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameterArray1d(IntPtr param, long offset, long nelements, [In] double* values);
        #endregion void cgGLSetParameterArray1d(IntPtr param, long offset, long nelements, [In] double* values)
        #region void cgGLSetParameterArray1d(IntPtr param, long offset, long nelements, [In] double[] values)
        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray1d(IntPtr param, long offset, long nelements, [In] double[] values);
        #endregion void cgGLSetParameterArray1d(IntPtr param, long offset, long nelements, [In] double[] values)
        #region void cgGLSetParameterArray1d(IntPtr param, long offset, long nelements, [In] IntPtr values)
        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray1d(IntPtr param, long offset, long nelements, [In] IntPtr values);
        #endregion void cgGLSetParameterArray1d(IntPtr param, long offset, long nelements, [In] IntPtr values)

        #region void cgGLSetParameterArray2d(IntPtr param, long offset, long nelements, [In] double* values)
        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameterArray2d(IntPtr param, long offset, long nelements, [In] double* values);
        #endregion void cgGLSetParameterArray2d(IntPtr param, long offset, long nelements, [In] double* values)
        #region void cgGLSetParameterArray2d(IntPtr param, long offset, long nelements, [In] double[] values)
        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray2d(IntPtr param, long offset, long nelements, [In] double[] values);
        #endregion void cgGLSetParameterArray2d(IntPtr param, long offset, long nelements, [In] double[] values)
        #region void cgGLSetParameterArray2d(IntPtr param, long offset, long nelements, [In] IntPtr values)
        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray2d(IntPtr param, long offset, long nelements, [In] IntPtr values);
        #endregion void cgGLSetParameterArray2d(IntPtr param, long offset, long nelements, [In] IntPtr values)

        #region void cgGLSetParameterArray3d(IntPtr param, long offset, long nelements, [In] double* values)
        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameterArray3d(IntPtr param, long offset, long nelements, [In] double* values);
        #endregion void cgGLSetParameterArray3d(IntPtr param, long offset, long nelements, [In] double* values)
        #region void cgGLSetParameterArray3d(IntPtr param, long offset, long nelements, [In] double[] values)
        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray3d(IntPtr param, long offset, long nelements, [In] double[] values);
        #endregion void cgGLSetParameterArray3d(IntPtr param, long offset, long nelements, [In] double[] values)
        #region void cgGLSetParameterArray3d(IntPtr param, long offset, long nelements, [In] IntPtr values)
        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray3d(IntPtr param, long offset, long nelements, [In] IntPtr values);
        #endregion void cgGLSetParameterArray3d(IntPtr param, long offset, long nelements, [In] IntPtr values)

        #region void cgGLSetParameterArray4d(IntPtr param, long offset, long nelements, [In] double* values)
        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetParameterArray4d(IntPtr param, long offset, long nelements, [In] double* values);
        #endregion void cgGLSetParameterArray4d(IntPtr param, long offset, long nelements, [In] double* values)
        #region void cgGLSetParameterArray4d(IntPtr param, long offset, long nelements, [In] double[] values)
        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray4d(IntPtr param, long offset, long nelements, [In] double[] values);
        #endregion void cgGLSetParameterArray4d(IntPtr param, long offset, long nelements, [In] double[] values)
        #region void cgGLSetParameterArray4d(IntPtr param, long offset, long nelements, [In] IntPtr values)
        /// <summary>
        /// Sets the double values to the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to set values to.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to set.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetParameterArray4d(IntPtr param, long offset, long nelements, [In] IntPtr values);
        #endregion void cgGLSetParameterArray4d(IntPtr param, long offset, long nelements, [In] IntPtr values)
        #endregion

        #region cgGLGetParameterArrayNf
        #region void cgGLGetParameterArray1f(IntPtr param, long offset, long nelements, [Out] float* values)
        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameterArray1f(IntPtr param, long offset, long nelements, [Out] float* values);
        #endregion void cgGLGetParameterArray1f(IntPtr param, long offset, long nelements, [Out] float* values)
        #region void cgGLGetParameterArray1f(IntPtr param, long offset, long nelements, [Out] float[] values)
        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray1f(IntPtr param, long offset, long nelements, [Out] float[] values);
        #endregion void cgGLGetParameterArray1f(IntPtr param, long offset, long nelements, [Out] float[] values)
        #region void cgGLGetParameterArray1f(IntPtr param, long offset, long nelements, [Out] IntPtr values)
        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray1f(IntPtr param, long offset, long nelements, [Out] IntPtr values);
        #endregion void cgGLGetParameterArray1f(IntPtr param, long offset, long nelements, [Out] IntPtr values)

        #region void cgGLGetParameterArray2f(IntPtr param, long offset, long nelements, [Out] float* values)
        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameterArray2f(IntPtr param, long offset, long nelements, [Out] float* values);
        #endregion void cgGLGetParameterArray2f(IntPtr param, long offset, long nelements, [Out] float* values)
        #region void cgGLGetParameterArray2f(IntPtr param, long offset, long nelements, [Out] float[] values)
        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray2f(IntPtr param, long offset, long nelements, [Out] float[] values);
        #endregion void cgGLGetParameterArray2f(IntPtr param, long offset, long nelements, [Out] float[] values)
        #region void cgGLGetParameterArray2f(IntPtr param, long offset, long nelements, [Out] IntPtr values)
        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray2f(IntPtr param, long offset, long nelements, [Out] IntPtr values);
        #endregion void cgGLGetParameterArray2f(IntPtr param, long offset, long nelements, [Out] IntPtr values)

        #region void cgGLGetParameterArray3f(IntPtr param, long offset, long nelements, [Out] float* values)
        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameterArray3f(IntPtr param, long offset, long nelements, [Out] float* values);
        #endregion void cgGLGetParameterArray3f(IntPtr param, long offset, long nelements, [Out] float* values)
        #region void cgGLGetParameterArray3f(IntPtr param, long offset, long nelements, [Out] float[] values)
        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray3f(IntPtr param, long offset, long nelements, [Out] float[] values);
        #endregion void cgGLGetParameterArray3f(IntPtr param, long offset, long nelements, [Out] float[] values)
        #region void cgGLGetParameterArray3f(IntPtr param, long offset, long nelements, [Out] IntPtr values)
        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray3f(IntPtr param, long offset, long nelements, [Out] IntPtr values);
        #endregion void cgGLGetParameterArray3f(IntPtr param, long offset, long nelements, [Out] IntPtr values)

        #region void cgGLGetParameterArray4f(IntPtr param, long offset, long nelements, [Out] float* values)
        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameterArray4f(IntPtr param, long offset, long nelements, [Out] float* values);
        #endregion void cgGLGetParameterArray4f(IntPtr param, long offset, long nelements, [Out] float* values)
        #region void cgGLGetParameterArray4f(IntPtr param, long offset, long nelements, [Out] float[] values)
        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray4f(IntPtr param, long offset, long nelements, [Out] float[] values);
        #endregion void cgGLGetParameterArray4f(IntPtr param, long offset, long nelements, [Out] float[] values)
        #region void cgGLGetParameterArray4f(IntPtr param, long offset, long nelements, [Out] IntPtr values)
        /// <summary>
        /// Gets the float values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray4f(IntPtr param, long offset, long nelements, [Out] IntPtr values);
        #endregion void cgGLGetParameterArray4f(IntPtr param, long offset, long nelements, [Out] IntPtr values)
        #endregion
        #region cgGLGetParameterArrayNd
        #region void cgGLGetParameterArray1d(IntPtr param, long offset, long nelements, [Out] double* values)
        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameterArray1d(IntPtr param, long offset, long nelements, [Out] double* values);
        #endregion void cgGLGetParameterArray1d(IntPtr param, long offset, long nelements, [Out] double* values)
        #region void cgGLGetParameterArray1d(IntPtr param, long offset, long nelements, [Out] double[] values)
        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray1d(IntPtr param, long offset, long nelements, [Out] double[] values);
        #endregion void cgGLGetParameterArray1d(IntPtr param, long offset, long nelements, [Out] double[] values)
        #region void cgGLGetParameterArray1d(IntPtr param, long offset, long nelements, [Out] IntPtr values)
        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray1d(IntPtr param, long offset, long nelements, [Out] IntPtr values);
        #endregion void cgGLGetParameterArray1d(IntPtr param, long offset, long nelements, [Out] IntPtr values)

        #region void cgGLGetParameterArray2d(IntPtr param, long offset, long nelements, [Out] double* values)
        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameterArray2d(IntPtr param, long offset, long nelements, [Out] double* values);
        #endregion void cgGLGetParameterArray2d(IntPtr param, long offset, long nelements, [Out] double* values)
        #region void cgGLGetParameterArray2d(IntPtr param, long offset, long nelements, [Out] double[] values)
        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray2d(IntPtr param, long offset, long nelements, [Out] double[] values);
        #endregion void cgGLGetParameterArray2d(IntPtr param, long offset, long nelements, [Out] double[] values)
        #region void cgGLGetParameterArray2d(IntPtr param, long offset, long nelements, [Out] IntPtr values)
        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray2d(IntPtr param, long offset, long nelements, [Out] IntPtr values);
        #endregion void cgGLGetParameterArray2d(IntPtr param, long offset, long nelements, [Out] IntPtr values)

        #region void cgGLGetParameterArray3d(IntPtr param, long offset, long nelements, [Out] double* values)
        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameterArray3d(IntPtr param, long offset, long nelements, [Out] double* values);
        #endregion void cgGLGetParameterArray3d(IntPtr param, long offset, long nelements, [Out] double* values)
        #region void cgGLGetParameterArray3d(IntPtr param, long offset, long nelements, [Out] double[] values)
        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray3d(IntPtr param, long offset, long nelements, [Out] double[] values);
        #endregion void cgGLGetParameterArray3d(IntPtr param, long offset, long nelements, [Out] double[] values)
        #region void cgGLGetParameterArray3d(IntPtr param, long offset, long nelements, [Out] IntPtr values)
        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray3d(IntPtr param, long offset, long nelements, [Out] IntPtr values);
        #endregion void cgGLGetParameterArray3d(IntPtr param, long offset, long nelements, [Out] IntPtr values)

        #region void cgGLGetParameterArray4d(IntPtr param, long offset, long nelements, [Out] double* values)
        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetParameterArray4d(IntPtr param, long offset, long nelements, [Out] double* values);
        #endregion void cgGLGetParameterArray4d(IntPtr param, long offset, long nelements, [Out] double* values)
        #region void cgGLGetParameterArray4d(IntPtr param, long offset, long nelements, [Out] double[] values)
        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray4d(IntPtr param, long offset, long nelements, [Out] double[] values);
        #endregion void cgGLGetParameterArray4d(IntPtr param, long offset, long nelements, [Out] double[] values)
        #region void cgGLGetParameterArray4d(IntPtr param, long offset, long nelements, [Out] IntPtr values)
        /// <summary>
        /// Gets the double values from the specific parameter.
        /// </summary>
        /// <param name="param">Parameter to get values from.</param>
        /// <param name="offset">Offset into an array</param>
        /// <param name="nelements">Number of values to get.</param>
        /// <param name="values">Array of values.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetParameterArray4d(IntPtr param, long offset, long nelements, [Out] IntPtr values);
        #endregion void cgGLGetParameterArray4d(IntPtr param, long offset, long nelements, [Out] IntPtr values)
        #endregion

        #endregion
        #endregion

        #region Matrix Parameter Managment Functions
        #region void cgGLSetStateMatrixParameter(IntPtr param, int matrix, int transform)
        /// <summary>
        /// Sets the values of the parameter to a matrix in the OpenGL state.
        /// </summary>
        /// <param name="param">
        /// Parameter that will be set.
        /// </param>
        /// <param name="matrix">
        /// Which matrix should be retreived from the OpenGL state.
        /// </param>
        /// <param name="transform">
        /// Optional transformation that will be aplied to the OpenGL state matrix before it is retreived to the parameter.
        /// </param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetStateMatrixParameter(IntPtr param, int matrix, int transform);
        #endregion void cgGLSetStateMatrixParameter(IntPtr param, int matrix, int transform)

        #region cgGLSetMatrixParameter

        #region cgGLSetMatrixParameterdr

        #region void cgGLSetMatrixParameterdr(IntPtr param, [In] double* matrix)
        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetMatrixParameterdr(IntPtr param, [In] double* matrix);
        #endregion void cgGLSetMatrixParameterdr(IntPtr param, [In] double* matrix)

        #region void cgGLSetMatrixParameterdr(IntPtr param, [In] double[] matrix)
        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterdr(IntPtr param, [In] double[] matrix);
        #endregion void cgGLSetMatrixParameterdr(IntPtr param, [In] double[] matrix)

        #region void cgGLSetMatrixParameterdr(IntPtr param, [In] IntPtr matrix)
        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterdr(IntPtr param, [In] IntPtr matrix);
        #endregion void cgGLSetMatrixParameterdr(IntPtr param, [In] IntPtr matrix)

        #endregion
        #region cgGLSetMatrixParameterfr

        #region void cgGLSetMatrixParameterfr(IntPtr param, [In] float* matrix)
        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetMatrixParameterdr(IntPtr param, [In] float* matrix);
        #endregion void cgGLSetMatrixParameterfr(IntPtr param, [In] float* matrix)

        #region void cgGLSetMatrixParameterfr(IntPtr param, [In] float[] matrix)
        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterfr(IntPtr param, [In] float[] matrix);
        #endregion void cgGLSetMatrixParameterfr(IntPtr param, [In] float[] matrix)

        #region void cgGLSetMatrixParameterfr(IntPtr param, [In] IntPtr matrix)
        /// <summary>
        /// Sets the value of matrix parameters in row order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterfr(IntPtr param, [In] IntPtr matrix);
        #endregion void cgGLSetMatrixParameterfr(IntPtr param, [In] IntPtr matrix)

        #endregion

        #region cgGLSetMatrixParameterdc

        #region void cgGLSetMatrixParameterdc(IntPtr param, [In] double* matrix)
        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetMatrixParameterdc(IntPtr param, [In] double* matrix);
        #endregion void cgGLSetMatrixParameterdc(IntPtr param, [In] double* matrix)

        #region void cgGLSetMatrixParameterdc(IntPtr param, [In] double[] matrix)
        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterdc(IntPtr param, [In] double[] matrix);
        #endregion void cgGLSetMatrixParameterdc(IntPtr param, [In] double[] matrix)

        #region void cgGLSetMatrixParameterdc(IntPtr param, [In] IntPtr matrix)
        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterdc(IntPtr param, [In] IntPtr matrix);
        #endregion void cgGLSetMatrixParameterdc(IntPtr param, [In] IntPtr matrix)

        #endregion
        #region cgGLSetMatrixParameterfc

        #region void cgGLSetMatrixParameterfc(IntPtr param, [In] float* matrix)
        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetMatrixParameterfc(IntPtr param, [In] float* matrix);
        #endregion void cgGLSetMatrixParameterfc(IntPtr param, [In] float* matrix)

        #region void cgGLSetMatrixParameterfc(IntPtr param, [In] float[] matrix)
        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterfc(IntPtr param, [In] float[] matrix);
        #endregion void cgGLSetMatrixParameterfc(IntPtr param, [In] float[] matrix)

        #region void cgGLSetMatrixParameterfc(IntPtr param, [In] IntPtr matrix)
        /// <summary>
        /// Sets the value of matrix parameters in column  order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterfc(IntPtr param, [In] IntPtr matrix);
        #endregion void cgGLSetMatrixParameterfc(IntPtr param, [In] IntPtr matrix)

        #endregion

        #endregion

        #region cgGLGetMatrixParameter

        #region cgGLGetMatrixParameterdr

        #region void cgGLGetMatrixParameterdr(IntPtr param, [In] double* matrix)
        /// <summary>
        /// Gets the value of matrix parameters in row order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetMatrixParameterdr(IntPtr param, [In] double* matrix);
        #endregion void cgGLGetMatrixParameterdr(IntPtr param, [In] double* matrix)

        #region void cgGLGetMatrixParameterdr(IntPtr param, [In] double[] matrix)
        /// <summary>
        /// Gets the value of matrix parameters in row order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterdr(IntPtr param, [In] double[] matrix);
        #endregion void cgGLGetMatrixParameterdr(IntPtr param, [In] double[] matrix)

        #region void cgGLGetMatrixParameterdr(IntPtr param, [In] IntPtr matrix)
        /// <summary>
        /// Gets the value of matrix parameters in row order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterdr(IntPtr param, [In] IntPtr matrix);
        #endregion void cgGLGetMatrixParameterdr(IntPtr param, [In] IntPtr matrix)

        #endregion
        #region cgGLGetMatrixParameterfr

        #region void cgGLGetMatrixParameterfr(IntPtr param, [In] float* matrix)
        /// <summary>
        /// Gets the value of matrix parameters in row order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetMatrixParameterdr(IntPtr param, [In] float* matrix);
        #endregion void cgGLGetMatrixParameterfr(IntPtr param, [In] float* matrix)

        #region void cgGLGetMatrixParameterfr(IntPtr param, [In] float[] matrix)
        /// <summary>
        /// Gets the value of matrix parameters in row order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterfr(IntPtr param, [In] float[] matrix);
        #endregion void cgGLGetMatrixParameterfr(IntPtr param, [In] float[] matrix)

        #region void cgGLGetMatrixParameterfr(IntPtr param, [In] IntPtr matrix)
        /// <summary>
        /// Gets the value of matrix parameters in row order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterfr(IntPtr param, [In] IntPtr matrix);
        #endregion void cgGLGetMatrixParameterfr(IntPtr param, [In] IntPtr matrix)

        #endregion

        #region cgGLGetMatrixParameterdc

        #region void cgGLGetMatrixParameterdc(IntPtr param, [In] double* matrix)
        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetMatrixParameterdc(IntPtr param, [In] double* matrix);
        #endregion void cgGLGetMatrixParameterdc(IntPtr param, [In] double* matrix)

        #region void cgGLGetMatrixParameterdc(IntPtr param, [In] double[] matrix)
        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterdc(IntPtr param, [In] double[] matrix);
        #endregion void cgGLGetMatrixParameterdc(IntPtr param, [In] double[] matrix)

        #region void cgGLGetMatrixParameterdc(IntPtr param, [In] IntPtr matrix)
        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterdc(IntPtr param, [In] IntPtr matrix);
        #endregion void cgGLGetMatrixParameterdc(IntPtr param, [In] IntPtr matrix)

        #endregion
        #region cgGLGetMatrixParameterfc

        #region void cgGLGetMatrixParameterfc(IntPtr param, [In] float* matrix)
        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetMatrixParameterfc(IntPtr param, [In] float* matrix);
        #endregion void cgGLGetMatrixParameterfc(IntPtr param, [In] float* matrix)

        #region void cgGLGetMatrixParameterfc(IntPtr param, [In] float[] matrix)
        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterfc(IntPtr param, [In] float[] matrix);
        #endregion void cgGLGetMatrixParameterfc(IntPtr param, [In] float[] matrix)

        #region void cgGLGetMatrixParameterfc(IntPtr param, [In] IntPtr matrix)
        /// <summary>
        /// Gets the value of matrix parameters in column order.
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterfc(IntPtr param, [In] IntPtr matrix);
        #endregion void cgGLGetMatrixParameterfc(IntPtr param, [In] IntPtr matrix)

        #endregion

        #endregion

        #region cgGLSetMatrixParameterArray

        #region cgGLSetMatrixParameterArrayfc

        #region void cgGLSetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [In] float* matrices)
        /// <summary>
        /// Sets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [In] float* matrices);
        #endregion void cgGLSetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, const float* matrices)

        #region void cgGLSetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [In] float[] matrices)
        /// <summary>
        /// Sets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [In] float[] matrices);
        #endregion void cgGLSetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, const float[] matrices)

        #region void cgGLSetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [In] IntPtr matrices)
        /// <summary>
        /// Sets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [In] IntPtr matrices);
        #endregion void cgGLSetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, const IntPtr matrices)

        #endregion cgGLSetMatrixParameterArrayfc

        #region cgGLSetMatrixParameterArraydc

        #region void cgGLSetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [In] double* matrices)
        /// <summary>
        /// Sets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [In] double* matrices);
        #endregion void cgGLSetMatrixParameterArraydc(IntPtr param, long offset, long nelements, const double* matrices)

        #region void cgGLSetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [In] double[] matrices)
        /// <summary>
        /// Sets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [In] double[] matrices);
        #endregion void cgGLSetMatrixParameterArraydc(IntPtr param, long offset, long nelements, const double[] matrices)

        #region void cgGLSetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [In] IntPtr matrices)
        /// <summary>
        /// Sets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [In] IntPtr matrices);
        #endregion void cgGLSetMatrixParameterArraydc(IntPtr param, long offset, long nelements, const IntPtr matrices)

        #endregion cgGLSetMatrixParameterArraydc


        #region cgGLSetMatrixParameterArrayfr

        #region void cgGLSetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [In] float* matrices)
        /// <summary>
        /// Sets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [In] float* matrices);
        #endregion void cgGLSetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, const float* matrices)

        #region void cgGLSetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [In] float[] matrices)
        /// <summary>
        /// Sets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [In] float[] matrices);
        #endregion void cgGLSetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, const float[] matrices)

        #region void cgGLSetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [In] IntPtr matrices)
        /// <summary>
        /// Sets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [In] IntPtr matrices);
        #endregion void cgGLSetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, const IntPtr matrices)

        #endregion cgGLSetMatrixParameterArrayfr

        #region cgGLSetMatrixParameterArraydr

        #region void cgGLSetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [In] double* matrices)
        /// <summary>
        /// Sets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLSetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [In] double* matrices);
        #endregion void cgGLSetMatrixParameterArraydr(IntPtr param, long offset, long nelements, const double* matrices)

        #region void cgGLSetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [In] double[] matrices)
        /// <summary>
        /// Sets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [In] double[] matrices);
        #endregion void cgGLSetMatrixParameterArraydr(IntPtr param, long offset, long nelements, const double[] matrices)

        #region void cgGLSetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [In] IntPtr matrices)
        /// <summary>
        /// Sets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to be set.</param>
        /// <param name="offset">An offset into the array parameter to start setting from.</param>
        /// <param name="nelements">The number of elements to set. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values to set the parameter to. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [In] IntPtr matrices);
        #endregion void cgGLSetMatrixParameterArraydr(IntPtr param, long offset, long nelements, const IntPtr matrices)

        #endregion cgGLSetMatrixParameterArraydr

        #endregion

        #region cgGLGetMatrixParameterArray

        #region cgGLGetMatrixParameterArrayfc

        #region void cgGLGetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [Out] float* matrices)
        /// <summary>
        /// Gets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [Out] float* matrices);
        #endregion void cgGLGetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, const float* matrices)

        #region void cgGLGetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [Out] float[] matrices)
        /// <summary>
        /// Gets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [Out] float[] matrices);
        #endregion void cgGLGetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, const float[] matrices)

        #region void cgGLGetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [Out] IntPtr matrices)
        /// <summary>
        /// Gets an array matrix parameters (float) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, [Out] IntPtr matrices);
        #endregion void cgGLGetMatrixParameterArrayfc(IntPtr param, long offset, long nelements, const IntPtr matrices)

        #endregion cgGLGetMatrixParameterArrayfc

        #region cgGLGetMatrixParameterArraydc

        #region void cgGLGetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [Out] double* matrices)
        /// <summary>
        /// Gets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [Out] double* matrices);
        #endregion void cgGLGetMatrixParameterArraydc(IntPtr param, long offset, long nelements, const double* matrices)

        #region void cgGLGetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [Out] double[] matrices)
        /// <summary>
        /// Gets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [Out] double[] matrices);
        #endregion void cgGLGetMatrixParameterArraydc(IntPtr param, long offset, long nelements, const double[] matrices)

        #region void cgGLGetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [Out] IntPtr matrices)
        /// <summary>
        /// Gets an array matrix parameters (double) in column order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArraydc(IntPtr param, long offset, long nelements, [Out] IntPtr matrices);
        #endregion void cgGLGetMatrixParameterArraydc(IntPtr param, long offset, long nelements, const IntPtr matrices)

        #endregion cgGLGetMatrixParameterArraydc


        #region cgGLGetMatrixParameterArrayfr

        #region void cgGLGetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [Out] float* matrices)
        /// <summary>
        /// Gets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [Out] float* matrices);
        #endregion void cgGLGetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, const float* matrices)

        #region void cgGLGetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [Out] float[] matrices)
        /// <summary>
        /// Gets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [Out] float[] matrices);
        #endregion void cgGLGetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, const float[] matrices)

        #region void cgGLGetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [Out] IntPtr matrices)
        /// <summary>
        /// Gets an array matrix parameters (float) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, [Out] IntPtr matrices);
        #endregion void cgGLGetMatrixParameterArrayfr(IntPtr param, long offset, long nelements, const IntPtr matrices)

        #endregion cgGLGetMatrixParameterArrayfr

        #region cgGLGetMatrixParameterArraydr

        #region void cgGLGetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [Out] double* matrices)
        /// <summary>
        /// Gets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), CLSCompliant(false), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void cgGLGetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [Out] double* matrices);
        #endregion void cgGLGetMatrixParameterArraydr(IntPtr param, long offset, long nelements, const double* matrices)

        #region void cgGLGetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [Out] double[] matrices)
        /// <summary>
        /// Gets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [Out] double[] matrices);
        #endregion void cgGLGetMatrixParameterArraydr(IntPtr param, long offset, long nelements, const double[] matrices)

        #region void cgGLGetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [Out] IntPtr matrices)
        /// <summary>
        /// Gets an array matrix parameters (double) in row order.
        /// </summary>
        /// <param name="param">Parameter to get data from.</param>
        /// <param name="offset">An offset into the array parameter to start getting from.</param>
        /// <param name="nelements">The number of elements to get. A value of 0 will default to the number of elements in the array minus the offset value.</param>
        /// <param name="matrices">The array of values retreived from parameter.. This must be a contiguous set of values that total nelements times the number of elements in the matrix.</param>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLGetMatrixParameterArraydr(IntPtr param, long offset, long nelements, [Out] IntPtr matrices);
        #endregion void cgGLGetMatrixParameterArraydr(IntPtr param, long offset, long nelements, const IntPtr matrices)

        #endregion cgGLGetMatrixParameterArraydr

        #endregion
        #endregion

        #region Textures Parameter Managment Functions
        #region void cgGLSetTextureParameter(IntPtr param, int texobj)
        /// <summary>
        /// Sets texture object to the specified parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetTextureParameter(IntPtr param, int texobj);
        #endregion void cgGLSetTextureParameter(IntPtr param, int texobj)

        #region int cgGLGetTextureParameter(IntPtr param)
        /// <summary>
        /// Retreives the value of a texture parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGLGetTextureParameter(IntPtr param);
        #endregion int cgGLGetTextureParameter(IntPtr param)

        #region void cgGLEnableTextureParameter(IntPtr param)
        /// <summary>
        /// Enables (binds) the texture unit associated with the given texture parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLEnableTextureParameter(IntPtr param);
        #endregion void cgGLEnableTextureParameter(IntPtr param)

        #region void cgGLDisableTextureParameter(IntPtr param)
        /// <summary>
        /// Disables the texture unit associated with the given texture parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLDisableTextureParameter(IntPtr param);
        #endregion void cgGLDisableTextureParameter(IntPtr param)

        #region int cgGLGetTextureEnum(IntPtr param)
        /// <summary>
        /// Retreives the OpenGL enumeration for the texture unit associated with the texture parameter.
        /// <remarks>
        /// Use cgGetNamedParameter to obtain the valid pointer to param.
        /// It can be one of the GL_TEXTURE#_ARB if valid.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGLGetTextureEnum(IntPtr param);
        #endregion int cgGLGetTextureEnum(IntPtr param)

        #region void cgGLSetManageTextureParameters(IntPtr context, bool flag)
        /// <summary>
        /// Enables or disables the automatic texture management for the given rendering context.
        /// <remarks>
        /// Use CG_TRUE or CG_FALSE to enable/disable automatic texture management.
        /// </remarks>
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void cgGLSetManageTextureParameters(IntPtr context, bool flag);
        #endregion void cgGLSetManageTextureParameters(IntPtr context, bool flag)

        #region int cgGLGetManageTextureParameters(IntPtr context)
        /// <summary>
        /// Retreives the manage texture parameters flag from a context 
        /// </summary>
        [DllImport("cgGL.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern int cgGLGetManageTextureParameters(IntPtr context);
        #endregion int cgGLGetManageTextureParameters(IntPtr context)
        #endregion
    }
}
