using System;
using System.Linq;
using System.Text;

namespace computeHash
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string s = "0100000000000000000000000000000000000000000000000000000000000000000000003ba3edfd7a7b12b27ac72c3e67768f617fc81bc3888a51323a9fb8aa4b1e5e4a29ab5f49ffff001d1dac2b7c";

            int NumberChars = s.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);

            System.Security.Cryptography.SHA256 sha = new System.Security.Cryptography.SHA256Managed();

            byte[] b2 = sha.ComputeHash(bytes);
            byte[] b3 = sha.ComputeHash(b2);

            if (BitConverter.IsLittleEndian)
            {
                b3 = b3.Reverse().ToArray();
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < b3.Length; i++)
            {
                result.Append(b3[i].ToString("x2"));
            }
            string r = result.ToString();
            Console.WriteLine("the hash is " + r);
            Console.Read();
        }
    }
}
