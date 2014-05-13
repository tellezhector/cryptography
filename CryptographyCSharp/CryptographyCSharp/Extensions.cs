namespace CryptographyCSharp
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Extensions
    {
        private static Encoding _encoding = new ASCIIEncoding();

        public static string tohex(this string str)
        {
            List<string> preOutput = new List<string>();

            foreach (char letter in str)
            {
                int value = Convert.ToInt32(letter);
                preOutput.Add(String.Format("{0:X2}", value));
            }

            return String.Join(String.Empty, preOutput);
        }

        public static string hex2str(this string hex)
        {
            if (hex.Length % 2 != 0)
            {
                throw new Exception("Wrong hex format.");
            }

            List<char> preOutput = new List<char>();
            for (int i = 0; i < hex.Length / 2; i++)
            {
                string segment = String.Format("{0}{1}", hex[2 * i], hex[(2 * i) + 1]);
                int value = Convert.ToInt32(segment, 16);
                char c = (char)value;
                preOutput.Add(c);
            }

            return String.Join(String.Empty, preOutput);
        }

        public static byte[] tobytes(this string str)
        {
            return str.tobin().bin2bytes();
        }

        public static string tobin(this string str)
        {
            byte[] bytes = _encoding.GetBytes(str);
            return bytes.tobin();
        }

        public static string bin2str(this string bin)
        {
            byte[] bytes = bin2bytes(bin);
            List<char> preOutput = new List<char>();
            foreach (byte b in bytes)
            {
                preOutput.Add(Convert.ToChar(b));
            }

            return String.Join(String.Empty, preOutput);
        }

        public static string bin2hex(this string bin)
        {
            return bin2str(bin).tohex();
        }

        public static string hex2bin(this string hex)
        {
            if (hex.Length % 2 != 0)
            {
                throw new Exception("Wrong hex format.");
            }

            List<string> preOutput = new List<string>();
            for (int i = 0; i < hex.Length / 2; i++)
            {
                string segment = String.Format("{0}{1}", hex[2 * i], hex[(2 * i) + 1]);
                byte b = Convert.ToByte(segment, 16);
                preOutput.Add(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            return String.Join(String.Empty, preOutput);
        }

        public static byte[] hex2bytes(this string hex)
        {
            return hex.hex2bin().bin2bytes();
        }

        public static byte[] bin2bytes(this string bin)
        {
            if (bin.Length % 8 != 0)
            {
                throw new Exception("Wrong bin format.");
            }

            List<byte> bytes = new List<byte>();
            for (int i = 0; i < bin.Length / 8; i++)
            {
                var segment = bin.Substring(i * 8, 8);
                byte b = Convert.ToByte(segment, 2);
                bytes.Add(b);
            }

            return bytes.ToArray();
        }

        public static string tobin(this byte[] bytes)
        {
            List<string> preOutput = new List<string>();
            foreach (byte b in bytes)
            {
                preOutput.Add(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            return String.Join(String.Empty, preOutput);
        }

        public static string tostr(this byte[] bytes)
        {
            return bytes.tobin().bin2str();
        }

        public static string tohex(this byte[] bytes)
        {
            return bytes.tobin().bin2hex();
        }
    }
}