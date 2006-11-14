#region License
/*
MIT License
Copyright ©2003-2006 Tao Framework Team
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
    public sealed class IlasmAttribute : Attribute
    {
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
