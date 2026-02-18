using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Day8
{
    internal class student
    {
        public int Id;
        public string Name;
        public int Grade;

        public student(int id, string name, int grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }

        // Copy Constructor
        public student(student other)
        {
            Id = other.Id;
            Name = other.Name;
            Grade = other.Grade;
        }
    }
}
