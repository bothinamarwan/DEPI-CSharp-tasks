using ExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ExaminationSystem.Collections
{
    internal class QuestionList : List<Question>
    {
        private string filePath;

        public QuestionList(string file)
        {
            filePath = file;
        }

        public new void Add(Question q)
        {
            base.Add(q);

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(q.ToString());
            }
        }
    }
}
