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
using System.Text;
using System.Text.RegularExpressions;

namespace Tao.PostProcess {
    #region Class Documentation
    /// <summary>
    ///     Release build processor.
    /// </summary>
    #endregion Class Documentation
    public sealed class ReleaseBuildProcessor : BuildProcessor {
        // --- Constructors & Destructors ---
        #region ReleaseBuildProcessor(string fileContent)
        /// <summary>
        ///     Creates a new ReleaseBuildProcessor.
        /// </summary>
        /// <param name="fileContent">
        ///     The file content to be processed.
        /// </param>
        public ReleaseBuildProcessor(string fileContent) : base(fileContent) {
        }
        #endregion ReleaseBuildProcessor(string fileContent)

        #region Dispose(bool isDisposing)
        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        /// <param name="isDisposing">
        ///     If <c>true</c> then the method was called manually, if <c>false</c> then the method
        ///     was called by the garbage collector.
        /// </param>
        protected override void Dispose(bool isDisposing) {
            base.Dispose(isDisposing);
        }
        #endregion Dispose(bool isDisposing)

        // --- Private Methods ---
        #region string ModifyCdeclDelegateCalls(string fileContent)
        /// <summary>
        ///     Modifies any DelegateCallingConventionCdeclAttribute calls.
        /// </summary>
        /// <param name="fileContent">
        ///     The content to modify.
        /// </param>
        /// <returns>
        ///     The modified content.
        /// </returns>
        private string ModifyCdeclDelegateCalls(string fileContent) {
            Regex callStart = new Regex(@".custom instance void Tao\..*\.DelegateCallingConventionCdeclAttribute::\.ctor\(\) = \( 01 00 00 00 \) ", RegexOptions.Compiled);
            Regex injectionStart = new Regex(@".*Invoke\(.*");
            int callStartPosition = -1;
            int callEndPosition = -1;
            int injectionStartPosition = -1;
            StringBuilder builder = new StringBuilder(fileContent);

            Match callStartMatch = callStart.Match(builder.ToString());
            while(callStartMatch.Success) {
                callStartPosition = callStartMatch.Groups[0].Index;
                callEndPosition = callStartMatch.Groups[0].Index + callStartMatch.Groups[0].Length;

                Match injectionStartMatch = injectionStart.Match(builder.ToString(), callEndPosition);
                if(injectionStartMatch.Success) {
                    injectionStartPosition = injectionStartMatch.Groups[0].Index;
                    builder = builder.Insert(injectionStartPosition, "      modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl)\r\n");
                    builder = builder.Remove(callStartPosition, callEndPosition - callStartPosition);
                }

                callStartMatch = callStart.Match(builder.ToString());
            }

            return builder.ToString();
        }
        #endregion string ModifyCdeclDelegateCalls(string fileContent)

        #region string ModifyIlasmCalls(string fileContent)
        /// <summary>
        ///     Modifies any IlasmAttribute calls.
        /// </summary>
        /// <param name="fileContent">
        ///     The content to modify.
        /// </param>
        /// <returns>
        ///     The modified content.
        /// </returns>
        private string ModifyIlasmCalls(string fileContent) {
            int callStartPosition = -1;
            int callEndPosition = -1;
            Regex callStart = new Regex(@"((?<Method> \.custom instance void Tao\..*?\.IlasmAttribute::\.ctor\(string\) = \((?<Body> .*?) \/\/ Code size .*? )} \/\/ end of)", RegexOptions.Compiled | RegexOptions.Singleline);

            Match callStartMatch = callStart.Match(fileContent);
            while(callStartMatch.Success) {
                // Console.WriteLine(callStartMatch.Groups["Code"].Value + "\n\n");
                callStartPosition = callStartMatch.Groups["Method"].Index;
                callEndPosition = callStartMatch.Groups["Method"].Index + callStartMatch.Groups["Method"].Length;

                // Remove the code comments.
                string tmp = callStartMatch.Groups["Body"].Value;
                Regex comment = new Regex(@"(?<Comment>\/\/ .*)", RegexOptions.Compiled);
                Match commentMatch = comment.Match(tmp);
                while(commentMatch.Success) {
                    int commentStartPosition = commentMatch.Groups["Comment"].Index;
                    int commentEndPosition = commentMatch.Groups["Comment"].Index + commentMatch.Groups["Comment"].Length;
                    tmp = tmp.Remove(commentStartPosition, commentEndPosition - commentStartPosition);
                    commentMatch = comment.Match(tmp);
                }

                // Gather the hex representation of the IL.
                string msil = "";
                Regex hex = new Regex(@"(?<Hex>[0-9A-F]{2,})", RegexOptions.Compiled);
                Match hexMatch = hex.Match(tmp);
                while(hexMatch.Success) {
                    msil = msil + " " + hexMatch.Groups["Hex"].Value;
                    hexMatch = hexMatch.NextMatch();
                }

                // Convert from hex back to a string for injection.
                string[] msilSplit = msil.Split();
                byte[] msilBytes = new byte[msilSplit.Length - 3];
                msilBytes[0] = (byte) '\r';
                msilBytes[1] = (byte) '\n';
                int x = 2;
                for(int i = 3; i < msilSplit.Length - 2; i++) {
                    msilBytes[x] = byte.Parse(msilSplit[i], System.Globalization.NumberStyles.HexNumber);
                    x++;
                }
                msil = System.Text.Encoding.ASCII.GetString(msilBytes);

                //Console.WriteLine(msil);

                // Remove odd crap at start of code.
                int actualStart = msil.IndexOf(".maxstack");
                if(actualStart != -1) {
                    msil = msil.Remove(0, actualStart);
                }

                // Remove odd crap at end of code.
                int actualEnd = msil.IndexOf("\r\nret");
                //Console.WriteLine(actualEnd + " - " + msil.Length);
                if(actualEnd != -1 && (actualEnd + 5) != msil.Length) {
                    msil = msil.Remove(actualEnd + 5, msil.Length - actualEnd - 5);
                }

                // Remove the old body and insert the new msil.
                fileContent = fileContent.Remove(callStartPosition, callEndPosition - callStartPosition);
                fileContent = fileContent.Insert(callStartPosition, msil + "\r\n");

                callStartMatch = callStart.Match(fileContent);
            }

            return fileContent;
        }
        #endregion string ModifyIlasmCalls(string fileContent)

        #region string RemoveAttribute(Regex attributeStart, Regex attributeEnd, string fileContent)
        /// <summary>
        ///     Removes a custom Attribute's implementation.
        /// </summary>
        /// <param name="attributeStart">
        ///     A Regex specifying the start of the attribute.
        /// </param>
        /// <param name="attributeEnd">
        ///     A Regex specifying the end of the attribute.
        /// </param>
        /// <param name="fileContent">
        ///     The content to modify.
        /// </param>
        /// <returns>
        ///     The modified content.
        /// </returns>
        private string RemoveAttribute(Regex attributeStart, Regex attributeEnd, string fileContent) {
            int attributeStartPosition = -1;
            int attributeEndPosition = -1;
            StringBuilder builder = new StringBuilder(fileContent);

            Match attributeStartMatch = attributeStart.Match(builder.ToString());
            while(attributeStartMatch.Success) {
                attributeStartPosition = attributeStartMatch.Groups[0].Index;
                Match attributeEndMatch = attributeEnd.Match(builder.ToString());

                if(attributeEndMatch.Success) {
                    attributeEndPosition = attributeEndMatch.Groups[0].Index + attributeEndMatch.Groups[0].Length;
                }

                if(attributeEndPosition > attributeStartPosition) {
                    builder = builder.Remove(attributeStartPosition, attributeEndPosition - attributeStartPosition);
                }

                attributeStartMatch = attributeStart.Match(builder.ToString());
            }

            return builder.ToString();
        }
        #endregion string RemoveAttribute(Regex attributeStart, Regex attributeEnd, string fileContent)

        // --- Protected Override Methods ---
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
        protected override string InjectMsil(string fileContent) {
            Regex attributeStart = new Regex(@"\.class .*? IlasmAttribute", RegexOptions.Compiled);
            Regex attributeEnd = new Regex(@"// end of class IlasmAttribute", RegexOptions.Compiled);
            fileContent = RemoveAttribute(attributeStart, attributeEnd, fileContent);
            fileContent = ModifyIlasmCalls(fileContent);

            return fileContent;
        }
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
        protected override string ModifyCdeclDelegates(string fileContent) {
            Regex attributeStart = new Regex(@"\.class .*? DelegateCallingConventionCdeclAttribute", RegexOptions.Compiled);
            Regex attributeEnd = new Regex(@"// end of class DelegateCallingConventionCdeclAttribute", RegexOptions.Compiled);
            fileContent = RemoveAttribute(attributeStart, attributeEnd, fileContent);
            fileContent = ModifyCdeclDelegateCalls(fileContent);

            return fileContent;
        }
        #endregion string ModifyCdeclDelegates()
    }
}
