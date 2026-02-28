using ExaminationSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ExaminationSystem.Collections
{
    internal class QuestionList : List<Question>
    {
        private readonly string filePath;

        public QuestionList(string file)
        {
            filePath = file;

            // Clear file at start
            try
            {
                File.WriteAllText(filePath, string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing file: {ex.Message}");
            }
        }

        public new void Add(Question q)
        {
            base.Add(q);

            // Append question to file
            try
            {
                File.AppendAllText(filePath, q.ToString() + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing question to file: {ex.Message}");
            }
        }
    }
}
