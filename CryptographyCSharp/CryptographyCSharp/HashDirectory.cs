namespace CryptographyCSharp
{
    using System;
    using System.IO;
    using System.Security.Cryptography;

    public class HashDirectory
    {
        public static void asdf()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                FileInfo fInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "//test.mp4");
                SHA256 mySHA256 = SHA256Managed.Create();

                byte[] hashValue;
                
                StreamSHA(fInfo, mySHA256);
                Console.Write(fInfo.Name + ": ");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Error: The directory specified could not be found.");
            }
            catch (IOException)
            {
                Console.WriteLine("Error: A file in the directory could not be accessed.");
            }
        }

        private static void StreamSHA(FileInfo fInfo, SHA256 mySHA256)
        {
            FileStream fileStream = fInfo.Open(FileMode.Open);
            
            int blockLength = (int)(fileStream.Length % 1024);
            if (blockLength == 0)
            {
                blockLength = 1024;
            }

            fileStream.Position = fileStream.Length - blockLength;
            bool stop_next = false;
            byte[] h = new byte[0];
            while (true)
            {
                byte[] buffer = new byte[blockLength];
               
                fileStream.Read(buffer, 0, (int)blockLength);
                byte[] aux = new byte[blockLength + h.Length];
                buffer.CopyTo(aux, 0);
                h.CopyTo(aux, buffer.Length);
                h = mySHA256.ComputeHash(aux);
                fileStream.Position = fileStream.Position - (blockLength);
                Console.WriteLine("{0}", (double)(fileStream.Position) / (double)(fileStream.Length));
                blockLength = 1024;
                if (stop_next)
                {
                    break;
                }

                fileStream.Position = fileStream.Position - (blockLength);

                if (fileStream.Position == 0)
                {
                    stop_next = true;
                }
            }

            Console.WriteLine(h.tohex());
            PrintByteArray(h);
        }

        // Print the byte array in a readable format. 
        public static void PrintByteArray(byte[] array)
        {
            int i;
            for (i = 0; i < array.Length; i++)
            {
                Console.Write(String.Format("{0:X2}", array[i]));
                if ((i % 4) == 3) Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}