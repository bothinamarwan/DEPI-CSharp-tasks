using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_day9.part_2
{
    internal class Helper_2
    {
        public static T FindMax<T>(T[] arr) where T : IComparable<T>
        {
            if (arr.Length == 0)
                throw new ArgumentException("Array is empty");

            T max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(max) > 0)
                    max = arr[i];
            }

            return max;
        }
    }
}
