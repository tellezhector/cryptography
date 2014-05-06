namespace CryptographyCSharp
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!".tohex());
            Console.WriteLine("Hello world!".tohex().hex2str());
            Console.WriteLine("Hello world!".tobin());
            Console.WriteLine("Hello world!".tobin().bin2str());

            Console.WriteLine("Starting xor manipulation");
            string bin1 = "0001001111110101";
            string bin2 = "0111010101011101";
            Console.WriteLine("bin1 {0}", bin1);
            Console.WriteLine("bin2 {0}", bin2);
            byte[] bytes = Util.XOR(bin1.bin2bytes(), bin2.bin2bytes());
            Console.WriteLine("binr {0}", bytes.tobin());
            Console.WriteLine("as string: {0}", bytes.tostr());
            Console.WriteLine("as hex: {0}", bytes.tohex());

            Console.WriteLine("Starting xor strings manipulation");
            Console.WriteLine("A: {0}", Util.XORstrings("a", " "));
            Console.ReadLine();
        }
    }
}
