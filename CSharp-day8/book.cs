using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Day8
{
    internal class book
    {
        public string Title;
        public string Author;

        public book()
        {
            Title = "Unknown";
            Author = "Unknown";
        }

        public book(string title)
        {
            Title = title;
            Author = "Unknown";
        }

        public book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
}
