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
