#region License
/*
MIT License
Copyright ©2003-2004 Randy Ridge
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

namespace Tao.DevIl {
    #region Class Documentation
    /// <summary>
    ///     Core DevIL library binding for .NET.
    /// </summary>
    #endregion Class Documentation
    public sealed class Ilut {
        // --- Fields ---
        #region Private Constants
        #region string ILUT_NATIVE_LIBRARY
        /// <summary>
        ///     Specifies DevIl's native library archive.
        /// </summary>
        /// <remarks>
        ///     Specifies ilut.dll for Windows and libILUT.so for Linux.
        /// </remarks>
        #if WIN32
        private const string ILUT_NATIVE_LIBRARY = "ilut.dll";
        #elif LINUX
        private const string ILUT_NATIVE_LIBRARY = "libILUT.so";
        #endif
        #endregion string ILUT_NATIVE_LIBRARY

        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.Cdecl" /> for Windows and
        ///     for Linux.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants
    }
}
