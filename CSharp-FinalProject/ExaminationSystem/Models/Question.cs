using ExaminationSystem.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
        public int CompareTo(Question? other)
        {
            return this.Marks.CompareTo(other?.Marks ?? 0);
        }
        public override string ToString()
        {
            return $"{Header} - {Body} {Marks} marks";
        }
        public override bool Equals(object? obj)
        {
           if (obj is Question q)
                return Body == q.Body;
           return false;
        }
        public override int GetHashCode()
        {
            return  Body.GetHashCode();
        }
    }
}
