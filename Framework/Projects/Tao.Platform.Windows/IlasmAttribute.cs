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

namespace Tao.Platform.Windows {
    #region Class Documentation
    /// <summary>
    ///     Injects supplied MSIL into the method's body.
    /// </summary>
    /// <remarks>
    ///     This is a hack as the C# compiler does not allow inline MSIL.  This is extracted and
    ///     the appropriate MSIL injected by the PostProcessTao utility.
    /// </remarks>
    #endregion Class Documentation
    [AttributeUsage(AttributeTargets.Method, AllowMultiple=false, Inherited=false)]
    public sealed class IlasmAttribute : Attribute {
        // --- Constructors & Destructors ---
        #region IlasmAttribute()
        /// <summary>
        ///     Prevent instantiation without providing MSIL.
        /// </summary>
        private IlasmAttribute() {}
        #endregion IlasmAttribute()

        #region IlasmAttribute(string msil)
        /// <summary>
        ///     Injects the supplied MSIL into the tagged method's body.
        /// </summary>
        /// <param name="msil">
        ///     The MSIL to inject.
        /// </param>
        public IlasmAttribute(string msil) {}
        #endregion IlasmAttribute(string msil)
    }
}
