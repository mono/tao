using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenAl;
using System.Threading;
using System.Diagnostics;

namespace FFmpegExamples
{
    public class AudioStream
    {
        private const int MAX_BUFFERS = 10;
        private Decoder decoder;
        private int source;
        private int[] buffers = new int[MAX_BUFFERS];
        private float[] zeros = { 0.0f, 0.0f, 0.0f };
        private bool playing;

        public event LiveUpdateCallback LivtUpdateEvent;

        public AudioStream()
        {
            decoder = new Decoder();
            decoder.LivtUpdateEvent += new LiveUpdateCallback(decoder_LivtUpdateEvent);

            Alut.alutInit();
            Al.alGenBuffers(MAX_BUFFERS, buffers);
            Check();

            Al.alGenSources(1,out source);
            Check();

            Al.alSourcefv(source, Al.AL_POSITION, zeros);
            Al.alSourcefv(source, Al.AL_VELOCITY, zeros);
            Al.alSourcefv(source, Al.AL_DIRECTION, zeros);
            Al.alSourcef(source, Al.AL_ROLLOFF_FACTOR, 0.0f);
            Al.alSourcei(source, Al.AL_SOURCE_RELATIVE, Al.AL_TRUE);
        }

        void decoder_LivtUpdateEvent(object update)
        {
            if (LivtUpdateEvent != null)
                LivtUpdateEvent(update);
        }

        public bool Open(string path)
        {
            return decoder.Open(path);
        }

        public void Play()
        {
            //Thread t = new Thread(new ThreadStart(PlayFunc));
            //t.IsBackground = true;
            //t.Start();
            PlayFunc();
        }

        private bool Update()
        {
            int processed;
            bool active = true;

            Al.alGetSourcei(source, Al.AL_BUFFERS_PROCESSED, out processed);

            while (processed-- > 0) {
                int buffer = -1;

                Al.alSourceUnqueueBuffers(source, 1, ref buffer);
                Check();

                active = Stream(buffer);

                if (active) {
                    Al.alSourceQueueBuffers(source, 1, ref buffer);
                    Check();
                }
            }

            return active;
        }

        private void Check()
        {
            int error = Al.alGetError();
            if (error != Al.AL_NO_ERROR) {
                Debug.WriteLine("OpenAL error: " + Al.alGetString(error));
            }
        }

        private bool Stream(int buffer)
        {
            if (decoder.Stream()) {
                if (decoder.IsAudioStream) {
                    byte[] samples = decoder.Samples;
                    int sampleSize = decoder.SampleSize;
                    Al.alBufferData(buffer, decoder.Format, samples, sampleSize, decoder.Frequency);
                    Check();
                }
                return true;
            }
            return false;
        }

        public bool Playing()
        {
            int state;
            Al.alGetSourcei(source, Al.AL_SOURCE_STATE, out state);
            return (state == Al.AL_PLAYING);
        }

        public void Stop()
        {
            playing = false;
            Al.alSourceStop(source);
        }

        public bool Playback()
        {
            int queue = 0;
            Al.alGetSourcei(source, Al.AL_BUFFERS_QUEUED, out queue);

            if (queue > 0) {
                Al.alSourcePlay(source);
            }

            if(Playing())
                return true;

            for(int i = 0; i < MAX_BUFFERS; ++i)
            {
                if (!Stream(buffers[i]))
                    return false;
            }

            Al.alSourceQueueBuffers(source, MAX_BUFFERS, buffers);            

            return true;
        }

        private void PlayFunc()
        {
            playing = true;
            if (!Playback())
                throw new Exception("Refused to play");
            while (Update()) {
                if (!playing)
                    break;
                Thread.Sleep(10);
                if (!Playing()) {
                    Playback();
                }
            }
        }
    }
}
