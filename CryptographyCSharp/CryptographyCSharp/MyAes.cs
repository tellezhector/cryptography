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

            byte[] encrypted = new byte[16];
            msg_hex = msg_hex.PadRight(32, '0');
            key_hex = key_hex.PadRight(32, '0');
            using (Aes aes = Aes.Create())
            {
                aes.Key = key_hex.hex2bytes();
                aes.IV = new byte[16];
                aes.BlockSize = 128;
                aes.KeySize = 128;
                if (!aes.ValidKeySize(128))
                {
                    throw new Exception();
                }


                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                aes.Clear();
                encryptor.TransformBlock(msg_hex.hex2bytes(), 0, 16, encrypted, 0);
                encryptor.Dispose();
                Console.WriteLine("how it looks in bin: {0}", encrypted.tobin());
                Console.WriteLine("how it looks in hex: {0}", encrypted.tohex());
                Console.WriteLine("how it looks in ascii: {0}", encrypted.tostr());
                Console.WriteLine("encrypted size: {0}", encrypted.Length);
            }

            return encrypted.tohex();
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

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key_hex.hex2bytes();
                aesAlg.IV = "00000000000000000000000000000000".hex2bytes();
                aesAlg.BlockSize = 128;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                var cipherText = hex_ct.hex2bytes();
                var output = new byte[16];
                decryptor.TransformBlock(cipherText, 0, 16, output, 0);
                plaintext = output.tohex();
            }

            return plaintext;
        }
    }
}