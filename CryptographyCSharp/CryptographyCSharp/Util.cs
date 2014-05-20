namespace CryptographyCSharp
{
    public static class Util
    {
        public static byte[] XOR(byte[] bytes1, byte[] bytes2)
        {
            if (bytes1.Length < bytes2.Length)
            {
                return XOR(bytes2, bytes1);
            }

            byte[] bytes = new byte[bytes2.Length];
            for (int i = 0; i < bytes2.Length; i++)
            {
                bytes[i] = (byte)(bytes1[i] ^ bytes2[i]);
            }

            return bytes;
        }

        public static string XORstrings(string str1, string str2)
        {
            return XOR(str1.tobytes(), str2.tobytes()).tostr();
        }

        public static string XORhex(string hex1, string hex2)
        {
            return XOR(hex1.hex2bytes(), hex2.hex2bytes()).tohex();
        }
    }
}