namespace CryptographyCSharp.FourthHomeWork
{
    using System;
    using System.Net;
    using System.Text;

    public class ChosenPaddingAttack
    {
        private string thi = "73696672616765090909090909090909";
        private string sec = "6172652053717565616D697368204F73";

        private enum PaddingCase
        {
            Correct,
            Wrong,
            Unknown
        }

        public void BreakSec()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(BreakSegment(1));
            builder.Append(BreakSegment(2));
            builder.Append(BreakSegment(3));
            
            Console.WriteLine("Success: {0}", builder.ToString());
            Console.WriteLine("Success: {0}", builder.ToString().hex2str());
        }

        private string BreakSegment(int segment)
        {
            var info = string.Empty;
            var padding = GeneratePadding((info.Length / 2) + 1); ;
            string unknown_case = string.Empty;
            for (int i = 0; i < 256; i++)
            {
                string guess = string.Format("{0:X2}", i);
                var temp_guess = string.Format("{0}{1}", guess, info);
                var paddingCase = TestPad(temp_guess, padding, segment);
                if (paddingCase == PaddingCase.Correct)
                {
                    info = temp_guess;
                    padding = GeneratePadding((info.Length / 2) + 1);
                    i = -1;
                    unknown_case = string.Empty;
                }
                if (paddingCase == PaddingCase.Unknown)
                {
                    unknown_case = guess;
                }
                if (i == 255 && unknown_case.Length == 2)
                {
                    info = string.Format("{0}{1}", unknown_case, info);
                    padding = GeneratePadding((info.Length / 2) + 1);
                    i = -1;
                    unknown_case = string.Empty;
                }
                if (info.Length == 32)
                {
                    break;
                }
            }

            Console.WriteLine("Segment {0}", segment);
            Console.WriteLine("Success: {0}", info);
            Console.WriteLine("Success: {0}", info.hex2str());
            return info;
        }

        private string GeneratePadding(int i)
        {
            StringBuilder builder = new StringBuilder();
            for (int j = 0; j < i; j++)
            {
                builder.Append(string.Format("{0:X2}", i));
            }

            return builder.ToString();
        }



        private PaddingCase TestPad(string guess, string padding, int segment)
        {
            if (guess.Length != padding.Length)
            {
                throw new Exception("Padding exception");
            }

            var client = new WebClient();
            var new_guess = "".PadRight(32 * (segment - 1), '0') + (Util.XORhex(guess, padding)).PadLeft(32, '0') + "".PadRight(32, '0');
            var cyphertext = "f20bdba6ff29eed7b046d1df9fb7000058b1ffb4210a580f748b4ac714c001bd4a61044426fb515dad3f21f18aa577c0bdf302936266926ff37dbf7035d5eeb4".Substring(0, new_guess.Length);
            var xorged = Util.XORhex(new_guess, cyphertext).ToLowerInvariant();
            
            try
            {
                client.DownloadString(string.Format("http://crypto-class.appspot.com/po?er={0}", xorged.ToLowerInvariant()));
            }
            catch (WebException e)
            {
                HttpStatusCode algo = ((HttpWebResponse)e.Response).StatusCode;
                if ((int)algo == 403)
                {
                    return PaddingCase.Wrong;
                }
                else if ((int)algo == 404)
                {
                    return PaddingCase.Correct;
                }

                Console.WriteLine(e.Message);
                WebExceptionStatus a = e.Status;
                throw;
            }

            return PaddingCase.Unknown;
        }

    }
}