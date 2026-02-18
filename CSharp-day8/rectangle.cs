using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Day8
{
    internal class rectangle : shape
    {
        public double Width;
        public double Height;

        public rectangle(double w, double h)
        {
            Width = w;
            Height = h;
        }

        public override double GetArea()
        {
            return Width * Height;
        }
    }
}
