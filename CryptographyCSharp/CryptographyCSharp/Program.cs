namespace CryptographyCSharp
{
    using System;

    using CryptographyCSharp.FourthHomeWork;

    class Program
    {
        static void Main(string[] args)
        {
            new ChosenPaddingAttack().BreakSec();
            Console.WriteLine("Exit");
        }

        private static void TestingUtility()
        {
            Console.WriteLine("_______________________________________________________");


            string key_hex = "AA000000000000000000000000000000";
            string plain_hex = "AA000000000000000000000000000000";
            string ct = "814827a94525ff24b90f20bec065866d".ToUpperInvariant();
            Console.WriteLine(ct);
            Console.WriteLine(ct.Length);


            var newct = MyAes.EncryptStringToBytes_Aes(plain_hex, key_hex);
            Console.WriteLine("enc: {0}", newct);
            Console.WriteLine("length: {0}", newct.Length);
            var decrypted = MyAes.DecryptStringFromBytes_Aes(newct, key_hex);
            Console.WriteLine("dec: {0}", decrypted);
            Console.WriteLine("length: {0}", decrypted.Length);
        }

        private static void TranslationsTests()
        {
            string str = "Esta es un string con signos y espacios.";
            string hex = "4573746520657320756e20746578746f20717565206f726967696e616c6d656e746520657261206865782e0000";
            string bin =
                "0000000001000101011100110111010001100101001000000110010101110011001000000111010101101110001000000111010001100101011110000111010001101111001000000110010101101110001000000110001001101001011011100110000101110010011010010110111100101110";
            Console.WriteLine("Testing str ops");
            Console.WriteLine("ORIGINAL \n:{0}:end", str);
            Console.WriteLine("ToHEX: \n:{0}:end", str.tohex());
            Console.WriteLine("ToBIN: \n:{0}:end", str.tobin());
            Console.WriteLine("ToHEXToStr: \n:{0}:end", str.tohex().hex2str());
            Console.WriteLine("ToBINToStr: \n:{0}:end", str.tobin().bin2str());
            Console.WriteLine("ToBYTESToS: \n:{0}:end", str.tobytes().tostr());

            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("Testing hex ops");
            Console.WriteLine("ORIGINAL \n:{0}:end", hex);
            Console.WriteLine("ToSTR: \n:{0}:end", hex.hex2str());
            Console.WriteLine("ToBIN: \n:{0}:end", hex.hex2bin());
            Console.WriteLine("ToSTRToHEX: \n:{0}:end", hex.hex2str().tohex());
            Console.WriteLine("ToBINToHEX: \n:{0}:end", hex.hex2bin().bin2hex());
            Console.WriteLine("ToBYTESToH: \n:{0}:end", hex.hex2bytes().tohex());

            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("Testing bin ops");
            Console.WriteLine("ORIGINAL \n:{0}:end", bin);
            Console.WriteLine("ToSTR: \n:{0}:end", bin.bin2str());
            Console.WriteLine("ToHEX: \n:{0}:end", bin.bin2hex());
            Console.WriteLine("ToSTRToBIN: \n:{0}:end", bin.bin2str().tobin());
            Console.WriteLine("ToHEXToBIN: \n:{0}:end", bin.bin2hex().hex2bin());
            Console.WriteLine("ToBYTESToB: \n:{0}:end", bin.bin2bytes().tobin());
        }
    }
}
