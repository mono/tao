#region License
/*
BSD License
Copyright ©2003-2004 Randy Ridge
http://www.randyridge.com/Tao/Default.aspx
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

1. Redistributions of source code must retain the above copyright notice,
   this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither Randy Ridge nor the names of any Tao contributors may be used to
   endorse or promote products derived from this software without specific
   prior written permission.

   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
   "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
   LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
   FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
   COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
   INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
   BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
   LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
   CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
   LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
   ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
   POSSIBILITY OF SUCH DAMAGE.
*/
#endregion License

using System;

namespace Tao.PostProcess {
    #region Class Documentation
    /// <summary>
    ///     Options state.
    /// </summary>
    #endregion Class Documentation
    public struct Options {
        // --- Fields ---
        #region Private Fields
        private string inputFileName;
        private string outputFileName;
        private bool isDebugBuild;
        private bool isOverwriteSilent;
        #endregion Private Fields

        #region Public Properties
        #region string InputFileName
        /// <summary>
        ///     The input file name.
        /// </summary>
        public string InputFileName {
            get {
                return inputFileName;
            }
        }
        #endregion string InputFileName

        #region string OutputFileName
        /// <summary>
        ///     The output file name.
        /// </summary>
        public string OutputFileName {
            get {
                return outputFileName;
            }
        }
        #endregion string OutputFileName

        #region bool IsDebugBuild
        /// <summary>
        ///     Is the build a debug or release build?
        /// </summary>
        public bool IsDebugBuild {
            get {
                return isDebugBuild;
            }
        }
        #endregion bool IsDebugBuild

        #region bool IsOverwriteSilent
        /// <summary>
        ///     Should overwriting the output file be silent?
        /// </summary>
        public bool IsOverwriteSilent {
            get {
                return isOverwriteSilent;
            }
        }
        #endregion bool IsOverwriteSilent
        #endregion Public Properties

        // --- Constructors & Destructors ---
        #region Options(string inputFileName, string outputFileName, bool isDebugBuild, bool isOverwriteSilent)
        /// <summary>
        ///     Creates a new Options object.
        /// </summary>
        /// <param name="inputFileName">
        ///     The input file name.
        /// </param>
        /// <param name="outputFileName">
        ///     The output file name.
        /// </param>
        /// <param name="isDebugBuild">
        ///     Is the build a debug or release build?
        /// </param>
        /// <param name="isOverwriteSilent">
        ///     Should overwriting the output file be silent?
        /// </param>
        public Options(string inputFileName, string outputFileName, bool isDebugBuild, bool isOverwriteSilent) {
            this.inputFileName = inputFileName;
            this.outputFileName = outputFileName;
            this.isDebugBuild = isDebugBuild;
            this.isOverwriteSilent = isOverwriteSilent;
        }
        #endregion Options(string inputFileName, string outputFileName, bool isDebugBuild, bool isOverwriteSilent)
    }
}
