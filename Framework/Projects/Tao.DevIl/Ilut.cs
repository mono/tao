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

namespace Tao.DevIl {
    #region Class Documentation
    /// <summary>
    ///     DevIL (Developer's Image Library) ILUT binding for .NET.
    /// </summary>
    #endregion Class Documentation
    public sealed class Ilut {
        // --- Fields ---
        #region Private Constants
        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.Winapi" />.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Winapi;
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants

        #region Public Constants
        #region Version
        #region ILUT_VERSION_1_6_7
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_VERSION_1_6_7 = 1;
        #endregion ILUT_VERSION_1_6_7

        #region ILUT_VERSION
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_VERSION = 167;
        #endregion ILUT_VERSION

        #region ILUT_VERSION_NUM
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_VERSION_NUM = Il.IL_VERSION_NUM;
        #endregion ILUT_VERSION_NUM

        #region ILUT_VENDOR
        /// <summary>
        /// 
        /// </summary>
        public const int ILUT_VENDOR = Il.IL_VENDOR;
        #endregion ILUT_VENDOR
        #endregion Version
        #endregion Public Constants
    }
}
