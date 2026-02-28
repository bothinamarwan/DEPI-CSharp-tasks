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

        // Event for exam started
        public event Action<string>? ExamStarted;

        // List of students
        public List<Student> Students { get; set; } = new();

        public Subject(string name)
        {
            Name = name;
        }

        // Call this to notify
        public void OnExamStarted()
        {
            string message = $"Exam for {Name} has started!";
            ExamStarted?.Invoke(message);

            // Notify all students
            foreach (var s in Students)
                s.Notify(message);
        }
    }
}
