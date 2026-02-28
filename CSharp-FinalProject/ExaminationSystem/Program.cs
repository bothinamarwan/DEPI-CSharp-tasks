using ExaminationSystem.Models;
using ExaminationSystem.Collections;
using ExaminationSystem.Exams;


namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Students
            Student s1 = new Student("Ali");
            Student s2 = new Student("Sara");

            // Subject
            Subject math = new Subject("Mathematics");
            math.Students.Add(s1);
            math.Students.Add(s2);

            // Subscribe to event
            math.ExamStarted += message =>
            {
                Console.WriteLine(" Notification:");
                Console.WriteLine(message);
                Console.WriteLine();
            };

            // User chooses exam type
            int choice;
            do
            {
                Console.WriteLine("Choose Exam Type:");
                Console.WriteLine("1 - Practice Exam");
                Console.WriteLine("2 - Final Exam");
            } while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2));

            Exam exam = choice == 1 ? new PracticeExam(60, math) : new FinalExam(60, math);

            // Add Questions
            var q1 = new TrueFalseQuestion("Q1", "C# is OOP?", 5);
            q1.Answers[0].IsCorrect = true;

            var q2 = new ChooseOneQuestion("Q2", "Best language for AI?", 10,
                new Answer("C#"), new Answer("Python"), new Answer("Java"));
            q2.Answers[1].IsCorrect = true;

            var q3 = new ChooseAllQuestion("Q3", "Select OOP concepts:", 10,
                new Answer("Encapsulation", true),
                new Answer("Polymorphism", true),
                new Answer("Abstraction", true),
                new Answer("Recursion", false));

            exam.Questions.Add(q1);
            exam.Questions.Add(q2);
            exam.Questions.Add(q3);

            // Start Exam
            exam.StartExam();

            // Show Exam
            exam.ShowExam();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
