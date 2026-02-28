using System;
using System.Collections.Generic;
using ExaminationSystem.Collections;
using ExaminationSystem.Enums;
using ExaminationSystem.Models;

namespace ExaminationSystem.Exams
{
    internal abstract class Exam
    {
        public int Time { get; set; }
        public QuestionList Questions { get; set; }
        public ExamMode Mode { get; set; }
        public Subject Subject { get; set; }

        public Dictionary<Question, Answer> QuestionAnswerMap { get; set; } = new();

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

        public void SubmitAnswer(Question q, Answer a)
        {
            if (Questions.Contains(q))
                QuestionAnswerMap[q] = a;
        }
    }
}