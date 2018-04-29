using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLEexperiment
{
    public static class RLE
    {
        private static byte escape = 254;
        private static byte maxLen = 250; //must be smaller than escape
        private static byte threshhold = 4; //start encoding after 4 equal elements

        public static byte[] Encode(byte[] source)
        {
            List<byte> encList = new List<byte>();
            byte runLength = 0;

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != escape)
                {
                    runLength++;
                    if (runLength >= maxLen)
                    {
                        encList.Add(escape);
                        encList.Add(source[i]);
                        encList.Add(runLength);
                        runLength = 0;
                    }
                    else
                    {
                        if ((i == source.Length - 1) || (source[i] != source[i + 1]))
                        {
                            if (runLength < threshhold)
                            {
                                for (int j = 0; j < runLength; j++)
                                    encList.Add(source[i]);
                            }
                            else
                            {
                                encList.Add(escape);
                                encList.Add(source[i]);
                                encList.Add(runLength);
                            }
                            runLength = 0;
                        }
                    }
                }
                else
                {
                    //escape symbol cannot be compressed
                    encList.Add(escape);
                    encList.Add(source[i]); // = escape
                }
            }


            return encList.ToArray();
        }

        public static byte[] Decode(byte[] source)
        {
            List<byte> dec = new List<byte>();

            for (int i = 0; i < source.Length; i++)
            {
                //case of last char == ctrl char and no byte is following (illegal encoding) is not covered -> exception
                if (source[i] == escape)
                {
                    if (source[i + 1] == escape)
                    {
                        dec.Add(escape);
                        i++;
                    }
                    else
                    {
                        for (int j = 0; j < source[i + 2]; j++)
                            dec.Add(source[i + 1]);
                        i += 2;
                    }
                }
                else
                {
                    dec.Add(source[i]);
                }
            }
            return dec.ToArray();
        }

    }
}
