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

        //TBD: make following in fn before as option
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
            return enumtype.ToString(); //or try ToString("G") for string or "D" for number
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

        public static string GetRightAlignedString(List<string> sl)
        {
            int maxlen=0;
            string result="";

            foreach (string str in sl)
                if (str.Length > maxlen)
                    maxlen = str.Length;

            foreach (string str in sl)
                result += str.PadLeft(maxlen) + "\r\n";

            return result;
        }

        //Histogram
        public static List<T> GetListSortedByOccurence<T>(List<T> l)
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

    #endregion

}

/*
     * possible topics for future:
     * 
     * delegates and simplifiers (+ function pointer, unmanaged-code-wrapper)
     * simplified execute methode in new thread->return result synchronized with new waiting thread (with timeout) per result->end finished threads
     *  +exit feature for termination of program
     * dynamical wrapper class to analyze and load native librarys (windows first -> DLL) via P/Invoke + GC handling (pinning)
     * thread-pool class (scheduler? - see github), and threadsafe data containers (with data-copy-output instead of reference?)
     * calendar and time-calculation-tools
     * tutorial .net-dll binding with ILmerge
     * tutorial for installer and special paths (temp, appdata, program files, registry)
     * regex tutorial and simplifier class
     * packing / crypting embedded stuff
     * winforms container + more controlls (hex-editor? color text textbox?)
     * rtf-class
     * excel-output
     * filesystem traveller + buildtree + indexer
     * sqlite connection
     * special graphic algorithms: fast scaling, fast object matching/find with tolerance, histogram, seam-carving
     * wrapper/simplifier for directX and/or openGL
     * configurable, fast plotter (as a control?)
     * sound generation class
     * game specific stuff: geometry, distance, collision detection, prediction of movement
     * printing class (make it simple to print what is displayed)
     * special serialport class
     * special tcp socket handling class
     * special container class to interconnect parsing keywords and parameters with function calls
     * special class to switch user context dynamically / ask for admin rights
     * low level stuff: drivers, ata secure erase? parsing filesystems?
     * algorithms: fft, pid, ekf
     * CLI stuff: command-parser, output in big letters
     * reflection avoidance, code injection
     * benchmarking
     * compact framework special topics: readallbytes-wrapper, delayed starter of methods (cause of lacking onLoad), get cpu-load and split into threads
     * mono
     * arduino wrapper? (see github) for firmata? or do universal µC interface with pinmap/peripherals for C# + HAL for µC
     * design pattern examples
*/
