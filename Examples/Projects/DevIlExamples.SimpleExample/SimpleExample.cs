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

#region Original Credits / License
//-----------------------------------------------------------------------------
//
// DevIL Source Example
// Copyright (C) 2000-2002 by Denton Woods
// Last modified:  4/22/2002 <--Y2K Compliant! =]
//
// Filename: examples/Simple Example/simple.c
//
// Description: Simplest implementation of an DevIL application.
//              Loads an image and saves it to a new image.
//              The images can be of any format and can be different.
//
//-----------------------------------------------------------------------------
#endregion Original Credits / License

using System;
using System.IO;
using Tao.DevIl;

namespace DevIlExamples {
    #region Class Documentation
    /// <summary>
    ///     Converts one image to another.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Denton Woods
    ///         http://openil.sourceforge.net/
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class SimpleExample {
        // --- Entry Point ---
        #region Main(string[] args)
        [STAThread]
        public static void Main(string[] args) {
            int imageId;
            string inputFile = "Data" + Path.DirectorySeparatorChar + "yinyangblue.gif";
            string outputFile = "Data" + Path.DirectorySeparatorChar + "yinyangblue.jpg";

            Console.WriteLine("DevIlExamples.SimpleExample - DevIL simple command line application.");

            if(args.Length == 2) {
                inputFile = args[0];
                outputFile = args[1];
                Console.WriteLine("Converting - {0} -> {1}", inputFile, outputFile);
            }
            else {
                Console.WriteLine("Usage - DevIlExamples.SimpleExample <inputfile> <outputfile>");
                Console.WriteLine("Converting example files - {0} -> {1}", inputFile, outputFile);
            }

            // Initialize DevIL
            Il.ilInit();

            // Generate the main image name to use
            Il.ilGenImages(1, out imageId);

            // Bind this image name
            Il.ilBindImage(imageId);

            // Loads the image into the imageId
            if(!Il.ilLoadImage(inputFile)) {
                Console.WriteLine("Could not open file, {0}, exiting.", inputFile);
                Exit();
            }

            // Display the image's dimensions
            Console.WriteLine("Width: {0} Height: {1}, Depth: {2}, Bpp: {3}",
                Il.ilGetInteger(Il.IL_IMAGE_WIDTH), Il.ilGetInteger(Il.IL_IMAGE_HEIGHT),
                Il.ilGetInteger(Il.IL_IMAGE_DEPTH),
                Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL));

            // Enable overwriting destination file
            Il.ilEnable(Il.IL_FILE_OVERWRITE);

            // Save the image
            Il.ilSaveImage(outputFile);

            // Done with the imageId, so let's delete it
            Il.ilDeleteImages(1, ref imageId);

            Exit();
        }
        #endregion Main(string[] args)

        #region Exit()
        /// <summary>
        ///     Exits application.
        /// </summary>
        private static void Exit() {
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
            Environment.Exit(0);
        }
        #endregion Exit()
    }
}
