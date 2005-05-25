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
