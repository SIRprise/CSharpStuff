using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public static class Helper
    {


        #region Array Operations
        public static T[] arrSubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static T[] arrSubArrayDeepClone<T>(this T[] data, int index, int length)
        {
            T[] arrCopy = new T[length];
            Array.Copy(data, index, arrCopy, 0, length);
            using (MemoryStream ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, arrCopy);
                ms.Position = 0;
                return (T[])bf.Deserialize(ms);
            }
        }

        public static bool arrComparer<T>(T[] a, T[] b)
        {
            return a.SequenceEqual(b);
        }

        public static bool arrComparer<T>(T[] a, T[] b, int count)
        {
            int mcount = (count > a.Length) ? a.Length : count;
            mcount = (mcount > b.Length) ? b.Length : mcount;
            T[] ma = arrSubArray<T>(a,0,mcount);
            T[] mb = arrSubArray<T>(b,0,mcount);
            return ma.SequenceEqual(mb);
        }
        #endregion

        #region hex
        public static byte[] String2Hex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }

        public static string String2HexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }

        public static string Hex2String(byte[] data)
        {
            string s = Encoding.ASCII.GetString(data);
            return s;
        }

        public static string Hex2String(byte data, byte numbersCount)
        {
            //TBD: make generic
            return "0x" + data.ToString("X" + numbersCount);
        }

        public static string Array2Hex(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }
        #endregion

        #region misc
        public static string enumGetString<T>(T enumtype) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            return enumtype.ToString();
        }

        public static byte[] arrGetRandomBytes(int count)
        {
            byte[] res = new byte[count];
            new Random().NextBytes(res);
            return res;
        }

        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        //Histogram
        public static List<T> getListSortedByOccurence<T>(List<T> l)
        {
            List<T> tempList = new List<T>();

            var mostPopular = l
                .GroupBy(s => s)
                .OrderByDescending(g => g.Count());
            mostPopular.ToList().ForEach(g => tempList.Add(g.Key)); //Console.WriteLine("{0}: {1}", g.Key, g.Count()));

            return tempList;
        }

        #endregion
    }

    #region HelperClasses
    //usefull class together with rtf-textboxes and AppendText
    public struct ColoredString
    {
        public string str;
        public Color color;
    }

    //delegates... TBD


    #endregion

}
