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
    ///     Command line usage help.
    /// </summary>
    #endregion Class Documentation
    public sealed class UsageHelp {
        // --- Public Methods ---
        #region Display()
        /// <summary>
        ///     Displays the utility's usage help.
        /// </summary>
        public static void Display() {
            Console.WriteLine("Does various post-processing on Tao Framework libraries.\n");
            Console.WriteLine("TAO.POSTPROCESS <input> <output> [/D | /R] [/Y]\n");
            Console.WriteLine("  input        Input MSIL file to process.");
            Console.WriteLine("  output       Output MSIL file to write the processed MSIL.");
            Console.WriteLine("  /D           Modifies and produces a debug build.");
            Console.WriteLine("  /R           Modifies and produces a release build.  Release is the");
            Console.WriteLine("               default if this switch is not supplied.");
            Console.WriteLine("  /Y           Suppresses prompting to confirm you want to overwrite an");
            Console.WriteLine("               existing output file.");
            Console.WriteLine("\nThis utility has only been tested against the MSIL as produced by");
            Console.WriteLine("Microsoft's 1.1 ILDASM.\n\n");
        }
        #endregion Display()

        #region Display(string additionalMessage)
        /// <summary>
        ///     Displays the utility's usage help along with an additional message.
        /// </summary>
        /// <param name="additionalMessage">
        ///     The additional message to display.
        /// </param>
        public static void Display(string additionalMessage) {
            Display();
            Console.WriteLine(additionalMessage);
        }
        #endregion Display()
    }
}
