using System.Collections.Generic;

namespace CSharp_D05
{
    internal class Program
    {
        static void SumAndMultiply(int a, int b, out int sum, out int product)
        {
            //problem 9: out parameters
            sum = a + b;
            product = a * b;
        }
        static void PrintText(string text, int times = 5)
        {
            //problem10: Optional & named parameters
            for (int i = 0; i < times; i++)
                Console.WriteLine(text);
        }

        static void Main(string[] args)
        {
            #region divide 2 int with exception
            try
            {
                Console.Write("Enter first number: ");
                int z = int.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                int y = int.Parse(Console.ReadLine());

                int equal = z / y;
                Console.WriteLine("Result = " + equal);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero.");
            }
            finally
            {
                Console.WriteLine("Operation complete");
            }
            //What is the purpose of the finally block? 
            /*
             - Executes code whether an exception occurs or not
             - Used for cleanup operations
             - Ensures important code always runs
             */
            #endregion
            #region defensive coding
            static void TestDefensiveCode()
            {
                int x, y;

                Console.Write("Enter X (positive): ");
                while (!int.TryParse(Console.ReadLine(), out x) || x <= 0)
                {
                    Console.Write("Invalid input. Enter positive X: ");
                }

                Console.Write("Enter Y (greater than 1): ");
                while (!int.TryParse(Console.ReadLine(), out y) || y <= 1)
                {
                    Console.Write("Invalid input. Enter Y > 1: ");
                }

                Console.WriteLine($"Result = {x / y}");
            }
            //Question: How does int.TryParse() improve program robustness compared to int.Parse() ?
            /*
             - Does not throw exceptions for invalid input
             - Returns true or false instead of crashing
             - Allows safe input validation
             - Improves program stability
             */
            #endregion
            #region nullable value type
            int? number = null;

            int result = number ?? 10;
            Console.WriteLine(result);

            if (number.HasValue)
                Console.WriteLine(number.Value);
            else
                Console.WriteLine("Number is null");
            //Question: What exception occurs when trying to access Value on a null Nullable<T>? 
            /*
              - Throws InvalidOperationException
              - Occurs when the nullable variable has no value
             */
            #endregion
            #region array index out of bounds
            int[] arr = new int[5];

            try
            {
                Console.WriteLine(arr[10]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index out of bounds.");
            }
            //Question: Why is it necessary to check array bounds before accessing elements? 
            /*
               - Prevents IndexOutOfRangeException
               - Avoids runtime errors
               - Protects program stability
               - Ensures valid memory access
             */
            #endregion
            #region sum of rows & column
            int[,] matrix = new int[3, 3];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"Enter value [{i},{j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < 3; i++)
            {
                int rowSum = 0, colSum = 0;
                for (int j = 0; j < 3; j++)
                {
                    rowSum += matrix[i, j];
                    colSum += matrix[j, i];
                }
                Console.WriteLine($"Row {i} Sum = {rowSum}, Column {i} Sum = {colSum}");
            }
            //Question: How is the GetLength(dimension) method used in multi-dimensional arrays? 
            /*
              - Returns the size of a specific dimension
              - GetLength(0) → number of rows
              - GetLength(1) → number of columns
             */
            #endregion
            #region jagged array
            int[][] jagged = new int[3][];
            jagged[0] = new int[2];
            jagged[1] = new int[3];
            jagged[2] = new int[1];

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"Enter value [{i}][{j}]: ");
                    jagged[i][j] = int.Parse(Console.ReadLine());
                }
            }

            foreach (var row in jagged)
            {
                foreach (var item in row)
                    Console.Write(item + " ");
                Console.WriteLine();
            }
            //Question: How does the memory allocation differ between jagged arrays and rectangular arrays ?
            /*
                         Jagged arrays:
              - Each row is stored separately
              - Rows can have different lengths
                       Rectangular arrays:
              - Stored in one contiguous memory block
              - All rows have the same length
             */

            #endregion
            #region nullable ref. type
            string? name = null;
            Console.Write("Enter name: ");
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
                name = input;

            Console.WriteLine(name!);
            //Question: What is the purpose of nullable reference types in C#? 
            /*
             - Helps avoid NullReferenceException
             - Enforces null checks at compile time
             - Improves code safety and reliability
             */
            #endregion
            #region boxing and unboxing
            int x = 10;
            object obj = x;   // Boxing

            try
            {
                int y = (int)obj; // Unboxing
                Console.WriteLine(y);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Invalid cast");
            }
            //Question: What is the performance impact of boxing and unboxing in C#? 
            /*
               - Causes additional memory allocation
               - Requires type conversion
               - Slower than working with value types directly
               - Can reduce performance if used frequently
             */
            #endregion
            #region out parameters
         SumAndMultiply(3, 4, out int s, out int p);
          Console.WriteLine($"Sum={s}, Product={p}");
            //Question: Why must out parameters be initialized inside the method? 
            /*
              - Ensures a value is always assigned
              - Required by the compiler
              - Guarantees safe use after method execution
             */

            #endregion
            #region Optional & named parameters
           PrintText("Hello", times: 3);
            //Question: Why must optional parameters always appear at the end of a method's parameter list ?
            /*
              - Prevents ambiguity in method calls
              - Allows correct parameter matching
              - Required by the compiler
             */
            #endregion
            #region Null propagation operator
            int[]? numbers = null;
            int? length = numbers?.Length;
            Console.WriteLine(length);
            //Question: How does the null propagation operator prevent NullReferenceException?
            /*
                - Checks for null before accessing members
                - Returns null instead of throwing an exception
                - Prevents NullReferenceException
             */
            #endregion
            #region Switch expression
            Console.Write("Enter day: ");
            string day = Console.ReadLine();
            int dayNumber = day switch
            {
                "Monday" => 1,
                "Tuesday" => 2,
                "Wednesday" => 3,
                "Thursday" => 4,
                "Friday" => 5,
                "Saturday" => 6,
                "Sunday" => 7,
                _ => 0
            };
            Console.WriteLine(dayNumber);
            //Question: When is a switch expression preferred over a traditional if statement? 
            /*
             - When mapping a single value to a result
            - Produces cleaner and shorter code
            - Improves readability
             */
            #endregion
            #region params keyword
            static int SumArray(params int[] numbers)
            {
                int sum = 0;
                foreach (int n in numbers)
                    sum += n;
                return sum;
            }
            Console.WriteLine(SumArray(1, 2, 3));
            Console.WriteLine(SumArray(new int[] { 4, 5, 6 }));
            //Question: What are the limitations of the params keyword in method definitions? 
            /*
              - Only one params parameter allowed
              - Must be the last parameter in the method
              - Accepts only one-dimensional arrays
             */
            #endregion
            //////////////////////////////part2//////////////////
            #region Print Numbers in a Range
            Console.Write("Enter a positive number: ");
            int n = int.Parse(Console.ReadLine());
                for (int i = 1; i <= n; i++)
                {
                    Console.Write(i);
                    if (i < n) Console.Write(", ");
                }
            #endregion
            #region Display Multiplication Table
            Console.Write("Enter a number: ");
            int k = int.Parse(Console.ReadLine());
            for (int i = 2; i <= k; i += 2)
            {
                Console.Write(i);
                if (i + 2 <= k)
                    Console.Write(", ");
            }
            #endregion
            #region List Even Numbers
            Console.Write("Enter a number: ");
            int e = int.Parse(Console.ReadLine());

            for (int i = 2; i <= e; i += 2)
            {
                Console.Write(i);
                if (i + 2 <= e) Console.Write(", ");
            }

            #endregion
            #region Compute Exponentiation
            Console.Write("Enter base number: ");
            int baseNum = int.Parse(Console.ReadLine());

            Console.Write("Enter exponent: ");
            int power = int.Parse(Console.ReadLine());

            int result0 = 1;

            for (int i = 1; i <= power; i++)
            {
                result0 *= baseNum;
            }

            Console.WriteLine("Result = " + result0);
            #endregion
            #region Reverse a Text String
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            for (int i = text.Length - 1; i >= 0; i--)
            {
                Console.Write(text[i]);
            }
            #endregion
            #region Reverse an Integer Value
            Console.Write("Enter an integer: ");
            int number_ = int.Parse(Console.ReadLine());

            int reversed = 0;

            while (number > 0)
            {
                reversed = reversed * 10 + (number_ % 10);
                number /= 10;
            }

            Console.WriteLine("Reversed number: " + reversed);
            #endregion
            #region Longest Distance Between Matching Elements
            Console.Write("Enter array size: ");
            int d = int.Parse(Console.ReadLine());

            int[] arra = new int[d];

            for (int i = 0; i < d; i++)
            {
                Console.Write($"Enter element {i}: ");
                arra[i] = int.Parse(Console.ReadLine());
            }

            int maxDistance = 0;

            for (int i = 0; i < d; i++)
            {
                for (int j = i + 1; j < d; j++)
                {
                    if (arra[i] == arra[j])
                    {
                        int distance = j - i - 1;
                        if (distance > maxDistance)
                            maxDistance = distance;
                    }
                }
            }

            Console.WriteLine("Longest distance = " + maxDistance);
            #endregion
            #region Reverse Words in a Sentence
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();

            string[] words = sentence.Split(' ');

            for (int i = words.Length - 1; i >= 0; i--)
            {
                Console.Write(words[i]);
                if (i > 0) Console.Write(" ");
            }
            #endregion


        }
    }
}
