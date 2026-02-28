using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Models
{
    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int marks) 
         :base(header, body, marks)
        {
            Answers.Add(new Answer("True"));
            Answers.Add(new Answer("False"));
        }
        public override void Show()
        {
            Console.WriteLine(ToString());
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Answers[i]}");
            }
        }
    }
}
