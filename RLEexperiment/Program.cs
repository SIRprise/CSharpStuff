using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLEexperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            const bool debugOn = false;
            const int arraysize = 250 * 4;
            byte[] data = new byte[arraysize];

            //create some random data + fill some parts with same value
            Random rnd = new Random();
            rnd.NextBytes(data);
            for (int i = 0; i < 5; i++)
            {
                int idx = rnd.Next(0, arraysize);
                int fillsize = rnd.Next(1, data.Length);
                fillsize = ((fillsize + idx) > arraysize) ? (arraysize - idx) : fillsize; //check upper boarder while filling
                Enumerable.Repeat(data[idx], fillsize).ToArray().CopyTo(data, idx);
            }

            //Enumerable.Repeat((byte)0xAA, arraysize).ToArray().CopyTo(data, 0);

            //encode
            byte[] dataEnc = RLE.Encode(data);

            //decode
            byte[] dataDec = RLE.Decode(dataEnc);

            //compare
            if (dataDec.SequenceEqual(data))
            {
                Console.WriteLine("It works! \r\noriginal size\t {0} B,\r\n encoded size\t {1} B", data.Length, dataEnc.Length);
                if (debugOn)
                {
                    Console.WriteLine("\r\nOrg:");
                    Console.WriteLine(BitConverter.ToString(data));
                    Console.WriteLine("\r\nEncoded:");
                    Console.WriteLine(BitConverter.ToString(dataEnc));//.Replace("-", ""));
                }
            }
            else
            {
                Console.WriteLine("There is something wrong with your algorithm");
                if (debugOn)
                {
                    Console.WriteLine("\r\nOrg:");
                    Console.WriteLine(BitConverter.ToString(data));
                    Console.WriteLine("\r\nEncoded:");
                    Console.WriteLine(BitConverter.ToString(dataEnc));
                    Console.WriteLine("\r\nDecoded:");
                    Console.WriteLine(BitConverter.ToString(dataEnc));
                }
            }

            Console.ReadLine();
        }
    }
}
