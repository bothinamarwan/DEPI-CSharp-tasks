using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Day8.part2
{
    internal class Shape : IComparable<Shape>
    {
        public string Name { get; set; }
        public double Area { get; set; }

        public int CompareTo(Shape other)
        {
            return this.Area.CompareTo(other.Area);
        }
    }
}
