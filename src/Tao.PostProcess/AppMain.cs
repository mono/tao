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
using System.IO;

namespace Tao.PostProcess {
    #region Class Documentation
    /// <summary>
    ///     Does various post-processing on Tao Framework libraries.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This utility performs various hacks and changes to the Tao Framework libraries.  For
    ///         this to work you must supply the application the appropriate input CIL file and an
    ///         output filename:
    ///     </para>
    ///     <para>
    ///         <c>
    ///             Tao.PostProcess.exe Tao.OpenGl.il1 Tao.OpenGl.il2
    ///         </c>
    ///     </para>
    ///     <para>
    ///         The following additional switches are also available:
    ///     </para>
    ///     <para>
    ///         <c>/D  - produces a debug build.  (not currently supported)</c>
    ///         <c>/R  - produces a release build.  (default)</c>
    ///         <c>/Y  - suppresses the overwrite file prompt.</c>
    ///         <c>/MS - operates against CIL as produced by Microsoft's ILDASM.  (default)</c>
    ///         <c>/M  - operates against CIL as produced by Mono's monodis.  (may not work yet)</c>
    ///     </para>
    ///     <para>
    ///         The file you pass in should be the CIL for a Tao Framework library.  While this
    ///         application may work with other CIL disassemblers, some modification of the regular
    ///         expressions used by this application may be needed.  (This application searches for
    ///         particular strings in the CIL that may be, and most likely are, specific to the CIL
    ///         produced by ildasm.exe.)
    ///     </para>
    ///     <para>
    ///         The output file specified to this application is overwritten if it exists or created
    ///         if it does not.  You will be prompted to overwrite the file unless you specify the
    ///         /Y command line switch.
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class AppMain {
        // --- Fields ---
        #region Private Fields
        private static Options options;
        #endregion Private Fields

        // --- Entry Point ---
        #region Main(string[] args)
        /// <summary>
        ///     Application entry point.
        /// </summary>
        /// <param name="args">
        ///     The commandline arguments.
        /// </param>
        [STAThread]
        public static void Main(string[] args) {
            try {
                options = CheckArguments(args);
                string inputFileContent = ReadInputFile(options.InputFileName);
                string outputFileContent = Process(inputFileContent);
                WriteOutputFile(outputFileContent);
                DisplaySuccess();
            }
            catch(Exception e) {
                Console.WriteLine("\nUnhandled exception.  Program will terminate.\n");
                Console.WriteLine(e.Source);
                Console.WriteLine(e.TargetSite);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.StackTrace);
                Console.ReadLine();
            }
        }
        #endregion Main(string[] args)

        // --- Private Methods ---
        #region Options CheckArguments(string[] args)
        /// <summary>
        ///     Checks commandline arguments.
        /// </summary>
        /// <param name="args">
        ///     The commandline arguments.
        /// </param>
        /// <returns>
        ///     The selected options.
        /// </returns>
        private static Options CheckArguments(string[] args) {
            Options selectedOptions = new Options();

            if(args.Length < 2) {
                ExitWithError("You must supply input and output files.");
            }
            else {
                bool isDebugBuild = false;
                bool isOverwriteSilent = false;
                string inputFileName = args[0];
                string outputFileName = args[1];

                if(args.Length > 2) {
                    for(int i = 2; i < args.Length; i++) {
                        switch(args[i].ToUpper()) {
                            case "/D":
                                isDebugBuild = true;
                                break;
                            case "/R":
                                isDebugBuild = false;
                                break;
                            case "/Y":
                                isOverwriteSilent = true;
                                break;
                            default:
                                ExitWithError(args[i].ToUpper() + " is an invalid argument.");
                                break;
                        }
                    }
                }
                selectedOptions = new Options(inputFileName, outputFileName, isDebugBuild, isOverwriteSilent);
            }

            return selectedOptions;
        }
        #endregion CheckArguments(string[] args)

        #region DisplaySuccess()
        /// <summary>
        ///     Displays the appropriate success message.
        /// </summary>
        private static void DisplaySuccess() {
            if(options.IsDebugBuild) {
                Console.WriteLine("\nDebug build successfully processed and written to '" + options.OutputFileName + "'.\n");
            }
            else {
                Console.WriteLine("\nRelease build successfully processed and written to '" + options.OutputFileName + "'.\n");
            }
        }
        #endregion DisplaySuccess()

        #region ExitWithError(string errorMessage)
        /// <summary>
        ///     Exits, displays usage help, and displays supplied error message.
        /// </summary>
        /// <param name="errorMessage">
        ///     The additional error message to display.
        /// </param>
        private static void ExitWithError(string errorMessage) {
            UsageHelp.Display(errorMessage);
            Console.WriteLine();
            Environment.Exit(-1);
        }
        #endregion ExitWithError(string errorMessage)

        #region string Process(string content)
        /// <summary>
        ///     Processes the content.
        /// </summary>
        /// <param name="content">
        ///     The content to process.
        /// </param>
        /// <returns>
        ///     The modified content.
        /// </returns>
        private static string Process(string content) {
            if(options.IsDebugBuild) {
                // TODO: Implement DebugBuildProcessor.
                ExitWithError("Debug processing not yet supported.");
                return string.Empty;
            }
            else {
                using(BuildProcessor processor = (BuildProcessor) new ReleaseBuildProcessor(content)) {
                    return processor.Process();
                }
            }
        }
        #endregion string Process(string content)

        #region string ReadInputFile(string fileName)
        /// <summary>
        ///     Reads the input file's content.
        /// </summary>
        /// <param name="fileName">
        ///     The input file to read.
        /// </param>
        /// <returns>
        ///     The input file's content.
        /// </returns>
        private static string ReadInputFile(string fileName) {
            try {
                using(StreamReader stream = File.OpenText(fileName)) {
                    return stream.ReadToEnd();
                }
            }
            catch(Exception e) {
                ExitWithError(e.Message);
                return string.Empty;
            }
        }
        #endregion string ReadInputFile(string fileName)

        #region WriteOutputFile(string content)
        /// <summary>
        ///     Writes the output file.
        /// </summary>
        /// <param name="content">
        ///     The content to write.
        /// </param>
        private static void WriteOutputFile(string content) {
            try {
                if(!options.IsOverwriteSilent && File.Exists(options.OutputFileName)) {
                    Console.Write("\nOverwrite " + options.OutputFileName + "? (Yes/No): ");
                    string response = Console.ReadLine();
                    response = response.ToUpper().Trim();

                    if(response != "Y" && response != "YES") {
                        ExitWithError(options.OutputFileName + " not written by user request.");
                    }
                    else {
                        File.Delete(options.OutputFileName);
                    }
                }

                byte[] fileContent = System.Text.Encoding.UTF8.GetBytes(content);
                using(FileStream stream = File.OpenWrite(options.OutputFileName)) {
                    stream.Write(fileContent, 0, fileContent.Length);
                    stream.Flush();
                }
                fileContent = null;
            }
            catch(Exception e) {
                ExitWithError(e.Message);
            }
        }
        #endregion WriteOutputFile(string content)
    }
}
