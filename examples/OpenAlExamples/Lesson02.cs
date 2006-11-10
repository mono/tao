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
    ///     OpenAL Lesson 2: Looping and Fadeaway
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Jesse Maurais
    ///         http://devmaster.net/articles/openal-tutorials/lesson2.php
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Lesson02 {
        // --- Fields ---
        #region Private Fields
        /*
         * These are OpenAL "names" (or "objects"). They store and id of a buffer
         * or a source object. Generally you would expect to see the implementation
         * use values that scale up from '1', but don't count on it. The spec does
         * not make this mandatory (as it is OpenGL). The id's can easily be memory
         * pointers as well. It will depend on the implementation.
         */
        private static int buffer;                                          // Buffers to hold sound data.
        private static int source;                                          // Sources are points of emitting sound.

        /*
         * These are 3D cartesian vector coordinates. A structure or class would be
         * a more flexible of handling these, but for the sake of simplicity we will
         * just leave it as is.
         */
        private static float[] sourcePosition = {0, 0, 0};                  // Position of the source sound.
        private static float[] sourceVelocity = {0, 0, 0.1f};               // Velocity of the source sound.
        private static float[] listenerPosition = {0, 0, 0};                // Position of the Listener.
        private static float[] listenerVelocity = {0, 0, 0};                // Velocity of the Listener.
        
        // Orientation of the Listener. (first 3 elements are "at", second 3 are "up")
        // Also note that these should be units of '1'.
        private static float[] listenerOrientation = {0, 0, -1, 0, 1, 0};
        #endregion Private Fields

        // --- Entry Point ---
        #region Run()
		/// <summary>
		/// 
		/// </summary>
        public static void Run() {
            Console.WriteLine("MindCode's OpenAL Lesson 2: Looping and Fadeaway");
            Console.WriteLine();
            Console.WriteLine("Footsteps will slowly start to fade into the distance.");
            Console.WriteLine("(Press Enter key to quit.)");

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
            Al.alSourcePlay(source);

            // Loop
            int key = 0;
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            timer.Interval = 200;
            timer.Enabled = true;

            while(key == 0) {
                key = Console.Read();
            }

            timer.Stop();

            // Exit procedure to clean up and free OpenAL resources.
            KillALData();
        }
        #endregion Run()

        // --- Lesson Methods ---
        #region KillALData()
        /*
         * We have allocated memory for our buffers and sources which needs
         * to be returned to the system. This function frees that memory.
         */
        private static void KillALData() {
            Al.alDeleteBuffers(1, ref buffer);
            Al.alDeleteSources(1, ref source);
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
            Al.alGenBuffers(1, out buffer);
            if(Al.alGetError() != Al.AL_NO_ERROR) {
                return false;
            }

            // Attempt to locate the file.
            string fileName = "OpenAlExamples.Lesson02.Footsteps.wav";
            if(File.Exists(fileName)) {
                //fileName = fileName;
            }
            else if(File.Exists("Data/" + fileName)) {
                fileName = "Data/" + fileName;
            }
            else if(File.Exists("../../Data/" + fileName)) {
                fileName = "../../Data/" + fileName;
            }
            else {
                return false;
            }

            // Load wav.
            data = Alut.alutLoadMemoryFromFile(fileName, out format, out size, out frequency);
            if(data == IntPtr.Zero) {
                return false;
            }

            // Load wav data into the generated buffer.
            Al.alBufferData(buffer, format, data, size, (int)frequency);
            //Alut.alutUnloadWAV(format, out data, size, frequency);

            // Generate an OpenAL source.
            Al.alGenSources(1, out source);
            if(Al.alGetError() != Al.AL_NO_ERROR) {
                return false;
            }

            // Bind the buffer with the source.
            Al.alSourcei(source, Al.AL_BUFFER, buffer);
            Al.alSourcef(source, Al.AL_PITCH, 1.0f);
            Al.alSourcef(source, Al.AL_GAIN, 1.0f);
            Al.alSourcefv(source, Al.AL_POSITION, sourcePosition);
            Al.alSourcefv(source, Al.AL_VELOCITY, sourceVelocity);
            Al.alSourcei(source, Al.AL_LOOPING, Al.AL_TRUE);

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

        // --- Event Handlers ---
        #region Timer_Elapsed(object source, ElapsedEventArgs e)
        private static void Timer_Elapsed(object s, ElapsedEventArgs e) {
            sourcePosition[0] += sourceVelocity[0];
            sourcePosition[1] += sourceVelocity[1];
            sourcePosition[2] += sourceVelocity[2];
            Al.alSourcefv(source, Al.AL_POSITION, sourcePosition);
        }
        #endregion Timer_Elapsed(object source, ElapsedEventArgs e)
    }
}
