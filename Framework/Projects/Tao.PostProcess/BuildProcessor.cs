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
