#region License
/*
MIT License
Copyright ©2003-2004 Randy Ridge
http://www.randyridge.com/Tao/Default.aspx
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
    ///     Abstract base class for build processors.
    /// </summary>
    #endregion Class Documentation
    public abstract class BuildProcessor : IDisposable {
        // --- Fields ---
        #region Private Fields
        private bool isDisposed = false;
        private string content;
        #endregion Private Fields

        #region Protected Properties
        #region bool IsDisposed
        /// <summary>
        ///     Is this instance disposed?
        /// </summary>
        protected bool IsDisposed {
            get {
                lock(this) {
                    return isDisposed;
                }
            }
        }
        #endregion bool IsDisposed
        #endregion Protected Properties

        // --- Constructors & Destructors ---
        #region BuildProcessor()
        /// <summary>
        ///     Prevents instantiation.
        /// </summary>
        private BuildProcessor() {
        }
        #endregion BuildProcessor()

        #region BuildProcessor(string fileContent)
        /// <summary>
        ///     Creates a new BuildProcessor.
        /// </summary>
        /// <param name="fileContent">
        ///     The file content to be processed.
        /// </param>
        public BuildProcessor(string fileContent) {
            content = fileContent;
        }
        #endregion BuildProcessor(string fileContent)

        #region ~BuildProcessor()
        /// <summary>
        ///     Finalizer.
        /// </summary>
        ~BuildProcessor() {
            this.Dispose(false);
        }
        #endregion ~BuildProcessor()

        #region Dispose()
        /// <summary>
        ///     Dispose this instance.
        /// </summary>
        public void Dispose() {
            lock(this) {
                if(!isDisposed) {
                    this.Dispose(true);
                    GC.SuppressFinalize(this);
                }
            }
        }
        #endregion Dispose()

        #region Dispose(bool isDisposing)
        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        /// <param name="isDisposing">
        ///     If <c>true</c> then the method was called manually, if <c>false</c> then the method
        ///     was called by the garbage collector.
        /// </param>
        protected virtual void Dispose(bool isDisposing) {
            lock(this) {
                if(!isDisposed) {
                    if(isDisposing) {
                    }
                    content = null;
                }
                isDisposed = true;
            }
        }
        #endregion Dispose(bool isDisposing)

        // --- Protected Abstract Methods ---
        #region string InjectMsil()
        /// <summary>
        ///     Injects supplied MSIL into a method's body.
        /// </summary>
        /// <param name="fileContent">
        ///     The file content to modify.
        /// </param>
        /// <returns>
        ///     The modified file content.
        /// </returns>
        /// <remarks>
        ///     The method must have the IlasmAttribute applied.
        /// </remarks>
        protected abstract string InjectMsil(string fileContent);
        #endregion string InjectMsil()

        #region string ModifyCdeclDelegates()
        /// <summary>
        ///     Modifies delegates to allow cdecl calls.
        /// </summary>
        /// <param name="fileContent">
        ///     The file content to modify.
        /// </param>
        /// <returns>
        ///     The modified file content.
        /// </returns>
        /// <remarks>
        ///     The delegates must have the DelegateCallingConventionCdeclAttribute applied.
        /// </remarks>
        protected abstract string ModifyCdeclDelegates(string fileContent);
        #endregion string ModifyCdeclDelegates()

        // --- Public Methods ---
        #region string Process()
        /// <summary>
        ///     Performs all of the post-process hacks.
        /// </summary>
        /// <returns>
        ///     The modified content.
        /// </returns>
        public string Process() {
            if(IsDisposed) {
                throw new ObjectDisposedException("Object has been disposed.");
            }

            content = ModifyCdeclDelegates(content);
            content = InjectMsil(content);

            return content;
        }
        #endregion string Process()
    }
}
