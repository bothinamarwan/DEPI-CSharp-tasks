using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Day8
{
   abstract class shape
    {
        public abstract double GetArea();

        public void Display()
        {
            Console.WriteLine("Calculating area...");
        }
    }
}
