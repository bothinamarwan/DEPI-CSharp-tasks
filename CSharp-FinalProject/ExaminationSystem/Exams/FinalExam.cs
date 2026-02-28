using ExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Exams
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, Models.Subject subject)
            : base(time, subject, "FinalExam.txt")
        {
        }

        public override void ShowExam()
        {
            foreach (var q in Questions)
            {
                q.Show();
                Console.WriteLine();
            }

            Mode = Enums.ExamMode.finished;
        }
    }
}
