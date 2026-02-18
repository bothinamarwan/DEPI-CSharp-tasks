using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Day8
{
    internal interface IWalkable
    {
        void Walk();
    }

    class Robot : IWalkable
    {
        public void Walk()
        {
            Console.WriteLine("Robot walking normally.");
        }

        void IWalkable.Walk()
        {
            Console.WriteLine("Robot walking via IWalkable.");
        }
    }
}
