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

#region Original Credits / License
// Dan Ricart (ricart3@tcnj.edu)
#endregion Original Credits / License

using System;
using Tao.OpenAl;

namespace OpenAlExamples {
    public class Sound {
        // --- Fields ---
        #region Private Fields
        private byte[] buffer = null;
        private int format;
        private int frequency;
        private int length;
        private int sourceId;
        private int bufferId;
        #endregion Private Fields

        // --- Public Methods ---
        #region Destroy()
        public void Destroy() {
            Al.alDeleteSources(1, ref sourceId);
            Al.alDeleteBuffers(1, ref bufferId);
        }
        #endregion Destroy()

        #region Play()
        public void Play() {
            Al.alSourcePlay(sourceId);
        }
        #endregion Play()

        #region Load(string fileName, bool shouldLoop)
        public void Load(string fileName, bool shouldLoop) {
            // Load our sound
            int looping;
            Alut.alutLoadWAVFile(fileName, out format, out buffer, out length, out frequency, out looping);
            looping = shouldLoop ? Al.AL_TRUE : Al.AL_FALSE;

            Al.alGenSources(1, out sourceId);
            Al.alGenBuffers(1, out bufferId);
            Al.alBufferData(bufferId, format, buffer, length, frequency);
            Al.alSourcei(sourceId, Al.AL_BUFFER, bufferId);

            Alut.alutUnloadWAV(format, out buffer, length, frequency);

            // Set the pitch
            Al.alSourcef(sourceId, Al.AL_PITCH, 1.0f);
            // Set the gain
            Al.alSourcef(sourceId, Al.AL_GAIN, 1.0f);
            // Set looping to loop
            Al.alSourcei(sourceId, Al.AL_LOOPING, looping);
        }
        #endregion Load(string fileName, bool shouldLoop)

        #region SetListenerOrientation(float fx, float fy, float fz, float ux, float uy, float uz)
        public void SetListenerOrientation(float fx, float fy, float fz, float ux, float uy, float uz) {
            //set the orientation using an array of floats
            float[] vec = new float[6];
            vec[0] = fx;
            vec[1] = fy;
            vec[2] = fz;
            vec[3] = ux;
            vec[4] = uy;
            vec[5] = uz;
            Al.alListenerfv(Al.AL_ORIENTATION, vec);
        }
        #endregion SetListenerOrientation(float fx, float fy, float fz, float ux, float uy, float uz)

        #region SetListenerPosition(float x, float y, float z)
        public void SetListenerPosition(float x, float y, float z) {
            // Set the position using 3 seperate floats
            Al.alListener3f(Al.AL_POSITION, x, y, z);
        }
        #endregion SetListenerPosition(float x, float y, float z)

        #region SetProperties(float x, float y, float z, float vx, float vy, float vz)
        public void SetProperties(float x, float y, float z, float vx, float vy, float vz) {
            // Set the sounds position and velocity
            Al.alSource3f(sourceId, Al.AL_POSITION, x, y, z);
            Al.alSource3f(sourceId, Al.AL_VELOCITY, vx, vy, vz);
        }
        #endregion SetProperties(float x, float y, float z, float vx, float vy, float vz)

        #region SetSourceRelative()
        // This function makes a sound source relative so all direction and velocity
        // parameters become relative to the source rather than the listener.  This is
        // useful for background music that you want to stay constant relative to the listener
        // no matter where they go.
        public void SetSourceRelative() {
            Al.alSourcei(sourceId, Al.AL_SOURCE_RELATIVE, Al.AL_TRUE);
        }
        #endregion SetSourceRelative()

        #region Stop()
        public void Stop() {
            Al.alSourceStop(sourceId);
        }
        #endregion Stop()
    }
}
