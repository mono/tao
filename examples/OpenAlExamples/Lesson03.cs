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
// Jesse Maurais (lightonthewater@hotmail.com)
#endregion Original Credits / License

using System;
using System.IO;
using System.Timers;
using Tao.OpenAl;

namespace OpenAlExamples {
    #region Class Documentation
    /// <summary>
    ///     OpenAL Lesson 3: Multiple Sources
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Jesse Maurais
    ///         http://devmaster.net/articles/openal-tutorials/lesson3.php
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Lesson03 {
        // --- Fields ---
        #region Private Fields
        private const int NUM_BUFFERS = 3;                                  // Maximum data buffers we will need.
        private const int NUM_SOURCES = 3;                                  // Maximum emissions we will need.
        private const int BATTLE = 0;                                       // These index the buffers and sources.
        private const int GUN1 = 1;
        private const int GUN2 = 2;

        /*
         * These are OpenAL "names" (or "objects"). They store and id of a buffer
         * or a source object. Generally you would expect to see the implementation
         * use values that scale up from '1', but don't count on it. The spec does
         * not make this mandatory (as it is OpenGL). The id's can easily be memory
         * pointers as well. It will depend on the implementation.
         */
        private static int[] buffer = new int[NUM_BUFFERS];                 // Buffers to hold sound data.
        private static int[] source = new int[NUM_SOURCES];                 // Sources are points of emitting sound.

        /*
         * These are 3D cartesian vector coordinates. A structure or class would be
         * a more flexible of handling these, but for the sake of simplicity we will
         * just leave it as is.
         */

        // Position of the source sound.
        private static float[][] sourcePosition = new float[NUM_SOURCES][];

        // Velocity of the source sound.
        private static float[][] sourceVelocity = new float[NUM_SOURCES][];

        private static float[] listenerPosition = {0, 0, 0};                // Position of the Listener.
        private static float[] listenerVelocity = {0, 0, 0};                // Velocity of the Listener.
        
        // Orientation of the Listener. (first 3 elements are "at", second 3 are "up")
        // Also note that these should be units of '1'.
        private static float[] listenerOrientation = {0, 0, -1, 0, 1, 0};

        private static Random rand = new Random();                          // Random number generator.
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
		/// <summary>
		/// 
		/// </summary>
        public static void Run() {
            Console.WriteLine("MindCode's OpenAL Lesson 3: Multiple Sources");
            Console.WriteLine();
            Console.WriteLine("(Press Enter key to quit.)");

            for(int i = 0; i < NUM_SOURCES; i++) {
                sourcePosition[i] = new float[3];
                sourceVelocity[i] = new float[3];
            }

            // Initialize OpenAL and clear the error bit.
            Alut.alutInit();
            Al.alGetError();

            // Load the wav data.
            if(!LoadALData()) {
                Console.WriteLine("Error loading data.");
                return;
            }

            // Initialize the listener in OpenAL.
            SetListenerValues();

            // Begin playing the source.
            Al.alSourcePlay(source[BATTLE]);

            int state;
            int key = 0;

            while(key == 0) {
                key = Console.Read();

                for(int i = 1; i < NUM_SOURCES; i++) {
                    Al.alGetSourcei(source[i], Al.AL_SOURCE_STATE, out state);

                    if(state != Al.AL_PLAYING) {
                        // Pick a random position around the listener to play the source.
                        double theta = (double) (rand.Next() % 360) * 3.14 / 180.0;

                        sourcePosition[i][0] = -(float)(Math.Cos(theta));
                        sourcePosition[i][1] = -(float)(rand.Next() % 2);
                        sourcePosition[i][2] = -(float)(Math.Sin(theta));

                        Al.alSourcefv(source[i], Al.AL_POSITION, sourcePosition[i]);

                        Al.alSourcePlay(source[i]);
                    }
                }
            }

            // Exit procedure to clean up and free OpenAL resources.
            KillALData();
        }
        #endregion Run()

        // --- Lesson Methods ---
        #region string FindFile(string fileName)
        private static string FindFile(string fileName) {
            if(File.Exists(fileName)) {
                return fileName;
            }
            else if(File.Exists("Data/" + fileName)) {
                return "Data/" + fileName;
            }
            else if(File.Exists("../../Data/" + fileName)) {
                return "../../Data/" + fileName;
            }
            else {
                return null;
            }
        }
        #endregion string FindFile(string fileName)

        #region KillALData()
        /*
         * We have allocated memory for our buffers and sources which needs
         * to be returned to the system. This function frees that memory.
         */
        private static void KillALData() {
            Al.alDeleteBuffers(NUM_BUFFERS, buffer);
            Al.alDeleteSources(NUM_SOURCES, source);
            Alut.alutExit();
        }
        #endregion KillALData()

        #region bool LoadALData()
        /*
         * This function will load our sample data from the disk using the Alut
         * utility and send the data into OpenAL as a buffer. A source is then
         * also created to play that buffer.
         */
        private static bool LoadALData() {
            // Variables to load into.
            int format;
            int size;
            IntPtr data = IntPtr.Zero;
            float frequency;
            //int loop;

            // Generate an OpenAL buffer.
            Al.alGenBuffers(NUM_BUFFERS, buffer);
            if(Al.alGetError() != Al.AL_NO_ERROR) {
                return false;
            }

            string fileName = "";

            // Attempt to locate the file.
            fileName = FindFile("OpenAlExamples.Lesson03.Battle.wav");
            if(fileName != null) {
                // Load wav.
                data = Alut.alutLoadMemoryFromFile(fileName, out format, out size, out frequency);
                if(data == IntPtr.Zero) {
                    return false;
                }

                // Load wav data into the generated buffer.
                Al.alBufferData(buffer[BATTLE], format, data, size, (int)frequency);
                //Alut.a(format, out data, size, frequency);
            }
            else {
                return false;
            }

            // Attempt to locate the file.
            fileName = FindFile("OpenAlExamples.Lesson03.Gun1.wav");
            if(fileName != null) {
                // Load wav.
				data = Alut.alutLoadMemoryFromFile(fileName, out format, out size, out frequency);
				if(data == IntPtr.Zero) 
				{
                    return false;
                }

                // Load wav data into the generated buffer.
                Al.alBufferData(buffer[GUN1], format, data, size, (int)frequency);
                //Alut.alutUnloadWAV(format, out data, size, frequency);
            }
            else {
                return false;
            }

            // Attempt to locate the file.
            fileName = FindFile("OpenAlExamples.Lesson03.Gun2.wav");
            if(fileName != null) {
                // Load wav.
				data = Alut.alutLoadMemoryFromFile(fileName, out format, out size, out frequency);
				if(data == IntPtr.Zero) 
				{
                    return false;
                }

                // Load wav data into the generated buffer.
                Al.alBufferData(buffer[GUN2], format, data, size, (int)frequency);
               // Alut.alutUnloadWAV(format, out data, size, frequency);
            }
            else {
                return false;
            }

            // Generate an OpenAL source.
            Al.alGenSources(NUM_SOURCES, source);
            if(Al.alGetError() != Al.AL_NO_ERROR) {
                return false;
            }

            // Bind the buffer with the source.
            Al.alSourcei(source[BATTLE], Al.AL_BUFFER, buffer[BATTLE]);
            Al.alSourcef(source[BATTLE], Al.AL_PITCH, 1.0f);
            Al.alSourcef(source[BATTLE], Al.AL_GAIN, 1.0f);
            Al.alSourcefv(source[BATTLE], Al.AL_POSITION, sourcePosition[BATTLE]);
            Al.alSourcefv(source[BATTLE], Al.AL_VELOCITY, sourceVelocity[BATTLE]);
            Al.alSourcei(source[BATTLE], Al.AL_LOOPING, Al.AL_TRUE);

            Al.alSourcei(source[GUN1], Al.AL_BUFFER, buffer[GUN1]);
            Al.alSourcef(source[GUN1], Al.AL_PITCH, 1.0f);
            Al.alSourcef(source[GUN1], Al.AL_GAIN, 1.0f);
            Al.alSourcefv(source[GUN1], Al.AL_POSITION, sourcePosition[GUN1]);
            Al.alSourcefv(source[GUN1], Al.AL_VELOCITY, sourceVelocity[GUN1]);
            Al.alSourcei(source[GUN1], Al.AL_LOOPING, Al.AL_FALSE);

            Al.alSourcei(source[GUN2], Al.AL_BUFFER, buffer[GUN2]);
            Al.alSourcef(source[GUN2], Al.AL_PITCH, 1.0f);
            Al.alSourcef(source[GUN2], Al.AL_GAIN, 1.0f);
            Al.alSourcefv(source[GUN2], Al.AL_POSITION, sourcePosition[GUN2]);
            Al.alSourcefv(source[GUN2], Al.AL_VELOCITY, sourceVelocity[GUN2]);
            Al.alSourcei(source[GUN2], Al.AL_LOOPING, Al.AL_FALSE);

            // Do a final error check and then return.
            if(Al.alGetError() == Al.AL_NO_ERROR) {
                return true;
            }

            return false;
        }
        #endregion bool LoadALData()

        #region SetListenerValues()
        /*
         * We already defined certain values for the Listener, but we need
         * to tell OpenAL to use that data. This function does just that.
         */
        private static void SetListenerValues() {
            Al.alListenerfv(Al.AL_POSITION, listenerPosition);
            Al.alListenerfv(Al.AL_VELOCITY, listenerVelocity);
            Al.alListenerfv(Al.AL_ORIENTATION, listenerOrientation);
        }
        #endregion SetListenerValues()
    }
}
