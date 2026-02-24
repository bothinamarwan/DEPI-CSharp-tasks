using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_day9.part_2
{
    internal class Helper_
    {
        public static T[] ReverseArray<T>(T[] arr)
        {
            T[] reversed = new T[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                reversed[i] = arr[arr.Length - 1 - i];
            }

            return reversed;
        }
    }
}
