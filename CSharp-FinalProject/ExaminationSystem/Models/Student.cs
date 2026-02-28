using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Models
{
    internal class Student
    {
        public string Name { get; set; }

        public Student(string name)
        {
            Name = name;
        }

        public void Notify(string message)
        {
            Console.WriteLine($" {Name} received notification: {message}");
        }
    }
}