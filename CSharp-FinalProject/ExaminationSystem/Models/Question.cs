using ExaminationSystem.Collections;
using System;

namespace ExaminationSystem.Models
{
    internal abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; }

        protected Question(string header, string body, int marks)
        {
            Header = header;
            Body = body;
            Marks = marks;
            Answers = new AnswerList();
        }

        public abstract void Show();

        // Deep Clone
        public virtual object Clone()
        {
            var cloned = (Question)this.MemberwiseClone();
            cloned.Answers = new AnswerList();
            foreach (var ans in this.Answers)
            {
                cloned.Answers.Add(new Answer(ans.Text, ans.IsCorrect));
            }
            return cloned;
        }

        public int CompareTo(Question? other)
        {
            return this.Marks.CompareTo(other?.Marks ?? 0);
        }

        public override string ToString()
        {
            return $"{Header} - {Body} ({Marks} marks)";
        }

        public override bool Equals(object? obj)
        {
            return obj is Question q && Body == q.Body;
        }

        public override int GetHashCode()
        {
            return Body.GetHashCode();
        }
    }
}
