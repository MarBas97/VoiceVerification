using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Security.Cryptography;
using System.Net.Sockets;

namespace SpeakerRecognitionClient
{
    class DataWaveOperation
    {
        private WaveIn waveSource = null;
        private WaveFileWriter waveFile = null;
        
        private const  string PathToFile = @"temp.wav";
        byte[] key = new byte[32] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
        byte[] iv = new byte[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";


        public DataWaveOperation()
        {

        }

        public void StartRecording()
        {
            waveSource = new WaveIn
            {
                WaveFormat = new WaveFormat(sampleRate: 48000, channels: 1)
            };

            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);

            waveFile = new WaveFileWriter(PathToFile, waveSource.WaveFormat);

            waveSource.StartRecording();
        }

        public void StopRecording()
        {
            if (waveSource != null)
            {
                waveSource.StopRecording();
            }
        }

        public byte[] OpenWaveFile()
        {
            if (File.Exists(PathToFile))
            {
                byte[] data = File.ReadAllBytes(PathToFile);

                return data;

            }

            return null;
        }

        public void PlayWaveFile(WaveOutEvent player, WaveFileReader waveFile)
        {
            if (File.Exists(PathToFile))
            {
                

                player.Init(waveFile);
                player.Play();
                
            }

        }

        public string SendDataAndReceiveAnswer()
        {
            var data = OpenWaveFile();
            data = CutWavInfo(data);
            byte[] encrypted = EncryptBytes(data, key, iv);
            byte[] bytesToSend = CreateDataPacket(encrypted);

            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);            
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            string answer = GetAnswer(bytesToRead, bytesRead);
            nwStream.Flush();
            nwStream.Close();
            client.Close();
            return answer;


        }

        void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }
        }

        public static byte[] CutWavInfo(byte[] data)
        {
            int WavInfoLength = 44;
            byte[] result = new byte[data.Length - WavInfoLength];
            for (int i = 0, j = WavInfoLength; i < result.Length; i++, j++)
            {
                result[i] = data[j];
            }
            return result;
        }


        public static byte[] EncryptBytes(byte[] message, byte[] key, byte[] iv)
        {
            if ((message == null) || (message.Length == 0))
            {
                return message;
            }


            using (var rijndael = new RijndaelManaged())
            {

                rijndael.Key = key;
                rijndael.IV = iv;

                using (var stream = new MemoryStream())
                using (var encryptor = rijndael.CreateEncryptor())
                using (var encrypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    encrypt.Write(message, 0, message.Length);
                    encrypt.FlushFinalBlock();
                    return stream.ToArray();
                }

            }



        }

        public static byte[] DecryptBytes(byte[] message, byte[] key, byte[] iv)
        {

            using (var rijndael = new RijndaelManaged())
            {

                rijndael.Key = key;
                rijndael.IV = iv;
                using (var stream = new MemoryStream())
                using (var decryptor = rijndael.CreateDecryptor())
                using (var encrypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Write))
                {
                    encrypt.Write(message, 0, message.Length);
                    encrypt.FlushFinalBlock();
                    return stream.ToArray();
                }
            }

        }

        public static byte[] CreateDataPacket(byte[] data)
        {
            
            MemoryStream ms = new MemoryStream();
            ms.Write(data, 0, data.Length);
            return ms.ToArray();


        }

        private static string GetAnswer(byte[] data, int bytesToread)
        {
            byte[] answer_byte = new byte[bytesToread];
            for (int i = 0; i < bytesToread; i++)
            {
                answer_byte[i] = data[i];
            }
            string result = System.Text.Encoding.UTF8.GetString(answer_byte);

            return result;
        }

    }
}
