namespace CryptographyCSharp
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            HashDirectory.asdf();
            Console.ReadLine();
        }

        private static void TestingUtility()
        {
            string key_hex = "AA000000000000000000000000000000";
            string plain_hex = "AA000000000000000000000000000000";
            string ct = "814827a94525ff24b90f20bec065866d".ToUpperInvariant();

            Console.WriteLine(":::::: {0}", plain_hex);
            Console.WriteLine(":::::: {0}", plain_hex.hex2bytes().tohex());

            Console.WriteLine(ct);
            Console.WriteLine(ct.Length);
            var newct = MyAes.EncryptStringToBytes_Aes(plain_hex, key_hex);
            Console.WriteLine("enc: {0}", newct);
            Console.WriteLine("length: {0}", newct.Length);
            var decrypted = MyAes.DecryptStringFromBytes_Aes(newct, key_hex);
            Console.WriteLine("dec: {0}", decrypted);
            Console.WriteLine("length: {0}", decrypted.Length);

        }
    }
}
