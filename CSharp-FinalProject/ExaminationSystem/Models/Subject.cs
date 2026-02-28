using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Models
{
    internal class Subject
    {
        public string Name { get; set; }
        public event Action<string>? ExamStarted;
        public List<Student> Students { get; set; } = new();

        public Subject(string name)
        {
            Name = name;
        }

        public void OnExamStarted()
        {
            string message = $"Exam for {Name} has started!";
            ExamStarted?.Invoke(message);

            foreach (var s in Students)
                s.Notify(message);
        }
    }
}
