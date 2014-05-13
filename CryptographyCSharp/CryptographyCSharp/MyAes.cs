namespace CryptographyCSharp
{
    using System;
    using System.Security.Cryptography;

    public class MyAes
    {
        public static string EncryptStringToBytes_Aes(string msg_hex, string key_hex)
        {
            if (msg_hex == null)
                throw new ArgumentNullException("msg_hex");
            if (key_hex == null)
                throw new ArgumentNullException("key_hex");

            byte[] output = new byte[16];
            msg_hex = msg_hex.PadRight(32, '0');
            key_hex = key_hex.PadRight(32, '0');
            using (var aes = Aes.Create("AES"))
            {
                
                aes.BlockSize = 128;
                aes.KeySize = 128;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.None;
                if (!aes.ValidKeySize(128))
                {
                    throw new Exception();
                }

                ICryptoTransform encryptor = aes.CreateEncryptor(key_hex.hex2bytes(), null);
                encryptor.TransformBlock(msg_hex.hex2bytes(), 0, 16, output, 0);
                encryptor.Dispose();
            }

            return output.tohex();
        }

        public static string DecryptStringFromBytes_Aes(string hex_ct, string key_hex)
        {
            if (hex_ct == null)
                throw new ArgumentNullException("cipherText");
            if (key_hex == null)
                throw new ArgumentNullException("Key");

            hex_ct = hex_ct.PadRight(32, '0');
            key_hex = key_hex.PadRight(32, '0');
            string plaintext = null;

            using (Aes aes = Aes.Create("AES"))
            {
                aes.BlockSize = 128;
                aes.KeySize = 128;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.None;
                
                if (!aes.ValidKeySize(128))
                {
                    throw new Exception();
                }

                ICryptoTransform decryptor = aes.CreateDecryptor(key_hex.hex2bytes(), null);
                var output = new byte[16];
                decryptor.TransformBlock(hex_ct.hex2bytes(), 0, 16, output, 0);
                plaintext = output.tohex();
            }

            return plaintext;
        }
    }
}