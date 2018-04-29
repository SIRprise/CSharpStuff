using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Helper
    {
        public static string enumGetString<T>(T enumtype) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            return enumtype.ToString();
        }

        public static bool arrComparer(byte[] a, byte[] b)
        {
            return a.SequenceEqual(b);
        }

        public static byte[] arrGetRandomBytes(int count)
        {
            byte[] res = new byte[count];
            new Random().NextBytes(res);
            return res;
        }
    }
}
