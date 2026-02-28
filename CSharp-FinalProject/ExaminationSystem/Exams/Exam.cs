using ExaminationSystem.Collections;
using ExaminationSystem.Enums;
using ExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Exams
{
    internal abstract class Exam
    {
        public int Time { get; set; }
        public QuestionList Questions { get; set; }
        public ExamMode Mode { get; set; }
        public Subject Subject { get; set; }

        protected Exam(int time, Subject subject, string fileName)
        {
            Time = time;
            Subject = subject;
            Questions = new QuestionList(fileName);
            Mode = ExamMode.Queued;
        }

        public void StartExam()
        {
            Mode = ExamMode.Started;
            Subject.OnExamStarted();
        }

        public abstract void ShowExam();
    }
}
