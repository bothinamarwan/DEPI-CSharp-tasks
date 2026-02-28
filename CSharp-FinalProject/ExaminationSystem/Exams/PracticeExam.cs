using ExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Exams
{
    internal class PracticeExam : Exam
    {
        public PracticeExam(int time, Models.Subject subject)
            : base(time, subject, "PracticeExam.txt")
        {
        }

        public override void ShowExam()
        {
            foreach (var q in Questions)
            {
                q.Show();
                Console.WriteLine();
            }

            Console.WriteLine("=== Correct Answers ===");

            foreach (var q in Questions)
            {
                foreach (var ans in q.Answers)
                {
                    if (ans.IsCorrect)
                        Console.WriteLine($"{q.Header}: {ans.Text}");
                }
            }

            Mode = Enums.ExamMode.finished;
        }
    }
}
