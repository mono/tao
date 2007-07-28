using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Tao.FFmpeg;
using Tao.OpenAl;

namespace FFmpegExamples
{
    public delegate void LiveUpdateCallback(object update);

    public class Decoder
    {
       // public static string text;

        private IntPtr pFormatContext;
        private AVFormat.AVFormatContext formatContext;

        private AVCodec.AVCodecContext audioCodecContext;
        private IntPtr pAudioCodecContext;

        private AVUtil.AVRational timebase;
        private IntPtr pAudioStream;

        private IntPtr pAudioCodec;
        //private AVCodec.AVCodecStruct audioCodec;

        //private readonly String path;
        private int audioStartIndex = -1;
        private int audioSampleRate;
        private int format;
        private const int AUDIO_FRAME_SIZE = 5000;
        private byte[] samples = new byte[AUDIO_FRAME_SIZE];
        private int sampleSize = -1;
        private bool isAudioStream = false;

        private const int TIMESTAMP_BASE = 1000000;

        public event LiveUpdateCallback LivtUpdateEvent;

        public Decoder()
        {
            AVFormat.av_register_all();
        }

        ~Decoder()
        {
            if (pFormatContext != IntPtr.Zero)
                AVFormat.av_close_input_file(pFormatContext);
            AVCodec.av_free_static();
        }

        public void Reset()
        {
            if (pFormatContext != IntPtr.Zero)
                AVFormat.av_close_input_file(pFormatContext);
            sampleSize = -1;
            audioStartIndex = -1;
        }

        public bool Open(string path)
        {
            Reset();

            int ret;
            ret = AVFormat.av_open_input_file(out pFormatContext, path, IntPtr.Zero, 0, IntPtr.Zero);

            if (ret < 0) {
                Console.WriteLine("couldn't opne input file");
                return false;
            }

            ret = AVFormat.av_find_stream_info(pFormatContext);

            if (ret < 0) {
                Console.WriteLine("couldnt find stream informaion");
                return false;
            }

            formatContext = (AVFormat.AVFormatContext)
                Marshal.PtrToStructure(pFormatContext, typeof(AVFormat.AVFormatContext));

            for (int i = 0; i < formatContext.nb_streams; ++i) {
                AVFormat.AVStream stream = (AVFormat.AVStream)
                       Marshal.PtrToStructure(formatContext.streams[i], typeof(AVFormat.AVStream));

                AVCodec.AVCodecContext codec = (AVCodec.AVCodecContext)
                       Marshal.PtrToStructure(stream.codec, typeof(AVCodec.AVCodecContext));

                if (codec.codec_type == AVCodec.CodecType.CODEC_TYPE_AUDIO &&
                                        audioStartIndex == -1) {
                    this.pAudioCodecContext = stream.codec;
                    this.pAudioStream = formatContext.streams[i];
                    this.audioCodecContext = codec;
                    this.audioStartIndex= i;
                    this.timebase = stream.time_base;

                    pAudioCodec = AVCodec.avcodec_find_decoder(this.audioCodecContext.codec_id);
                    if (pAudioCodec == IntPtr.Zero) {
                        Console.WriteLine("couldn't find codec");
                        return false;
                    }

                    AVCodec.avcodec_open(stream.codec, pAudioCodec);
                }
            }

            if (audioStartIndex == -1) {
                Console.WriteLine("Couldn't find audio streamn");
                return false;
            }

            audioSampleRate = audioCodecContext.sample_rate;

            if (audioCodecContext.channels == 1) {
                format = Al.AL_FORMAT_MONO16;
            }
            else {
                format = Al.AL_FORMAT_STEREO16;
            }

            return true;
        }

        static int count = 0;
        public bool Stream()
        {            
            int result;

          //  FFmpeg.AVPacket packet = new FFmpeg.AVPacket();
            IntPtr pPacket = Marshal.AllocHGlobal(56);

            //Marshal.StructureToPtr(packet, pPacket, false);
          //  Marshal.PtrToStructure(

            result = AVFormat.av_read_frame(pFormatContext, pPacket);
            if (result < 0)
                return false;           
            count++;

            int frameSize = 0;
            IntPtr pSamples = IntPtr.Zero;
            AVFormat.AVPacket packet = (AVFormat.AVPacket)
                                Marshal.PtrToStructure(pPacket, typeof(AVFormat.AVPacket));
             Marshal.FreeHGlobal(pPacket);
            
             if (LivtUpdateEvent != null) {
                 int cur = (int)(packet.dts * timebase.num / timebase.den);
                 int total = (int)(formatContext.duration / TIMESTAMP_BASE);
                 string time = String.Format("{0} out of {1} seconds", cur, total);
                LivtUpdateEvent(time);
            }

            if (packet.stream_index != this.audioStartIndex) {
                this.isAudioStream = false;
                return true;
            }
            this.isAudioStream = true;

            try {               
                pSamples = Marshal.AllocHGlobal(AUDIO_FRAME_SIZE);
                int size = AVCodec.avcodec_decode_audio(pAudioCodecContext, pSamples,
                        out frameSize, packet.data, packet.size);
                
                //FFmpeg.av_free_packet(pPacket);                                      

                this.sampleSize = frameSize;
                Marshal.Copy(pSamples, samples, 0, AUDIO_FRAME_SIZE);
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                return false;
            }
            finally {               
                Marshal.FreeHGlobal(pSamples);
            }

            return true;
        }

        public byte[] Samples
        {
            get { return samples; }
        }

        public int SampleSize
        {
            get { return sampleSize; }
        }

        public int Format
        {
            get { return format; }
        }

        public int Frequency
        {
            get { return audioSampleRate; }
        }

        public bool IsAudioStream
        {
            get { return isAudioStream; }
        }
    }
}
