using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Day8
{
    internal class product : IComparable<product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int CompareTo(product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
