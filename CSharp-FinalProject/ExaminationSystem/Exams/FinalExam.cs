using System;
using ExaminationSystem.Models;
using ExaminationSystem.Enums;

namespace ExaminationSystem.Exams
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, Subject subject)
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

            Mode = ExamMode.Finished;
        }
    }
}