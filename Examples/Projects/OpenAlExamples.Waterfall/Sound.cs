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
