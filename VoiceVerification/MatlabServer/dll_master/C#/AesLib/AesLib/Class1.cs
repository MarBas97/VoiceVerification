using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;


namespace AesLib
{
    public class Crypto
    {
     
        public static byte[] EncryptBytes(byte[] message,byte[]key,byte[]iv)
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



    }
}
