using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Models
{
    internal class ChooseAllQuestion : Question
    {
        public ChooseAllQuestion(string header, string body, int marks, params Answer[] options)
            : base(header, body, marks)
        {
            foreach (var ans in options)
                Answers.Add(ans);
        }

        public override void Show()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("Select all that apply:");
            for (int i = 0; i < Answers.Count; i++)
                Console.WriteLine($"{i + 1}. {Answers[i]}");
        }
    }
}
