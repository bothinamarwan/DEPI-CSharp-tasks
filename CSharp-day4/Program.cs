namespace CSharp_day4
{
    internal class Program
    {
        enum DayOfWeek
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        static void Main(string[] args)
        {
            #region one dimensional array
            // 1. Using new int[size]
            int[] arr1 = new int[3];
            arr1[0] = 10;
            arr1[1] = 20;
            arr1[2] = 30;

            // 2. Using initializer list
            int[] arr2 = { 1, 2, 3 };

            // 3. Using array syntax sugar
            int[] arr3 = new int[] { 5, 6, 7 };

            Console.WriteLine("Array 1:");
            foreach (int x in arr1)
                Console.WriteLine(x);

            Console.WriteLine("Array 2:");
            foreach (int x in arr2)
                Console.WriteLine(x);

            Console.WriteLine("Array 3:");
            foreach (int x in arr3)
                Console.WriteLine(x);

            // IndexOutOfRangeException
            Console.WriteLine(arr1[5]);
            //Question: What is the default value assigned to array elements in C#? 
            /*
              - int → 0
              - double → 0.0
              - bool → false
              - string / reference types → null
             */
            #endregion
            #region shallow copy & deep copy

            int[] shallow = { 1, 2, 3 };

            // Shallow copy (reference copy)
            int[] shallow2 = shallow;
            arr2[0] = 100;

            Console.WriteLine(arr1[0]); // 100

            // Deep copy using Clone
            int[] deep = (int[])shallow.Clone();
            arr3[1] = 200;

            Console.WriteLine(shallow[1]); // unchanged
                                           //Question: What is the difference between Array.Clone() and Array.Copy()?
            /*
            -> Clone()
              - Creates a new array
              - Shallow copy of elements
            -> Copy()
              - Copies elements from one array to another existing array
              - More control (start index, length)
             */
            #endregion
            #region 2D-array

            int[,] grades = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter grades for student {i + 1}:");
                for (int j = 0; j < 3; j++)
                {
                    grades[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Student {i + 1}: ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(grades[i, j] + " ");
                }
                Console.WriteLine();
            }
            //Question: What is the difference between GetLength() and Length for multi dimensional arrays?
            /*
            - Length → total number of elements
            - GetLength(dimension) → size of specific dimension
             */
            #endregion
            #region array methods
            int[] arr = { 5, 2, 9, 1, 3 };

            Array.Sort(arr);
            Array.Reverse(arr);

            int index = Array.IndexOf(arr, 3);

            int[] copyArr = new int[5];
            Array.Copy(arr, copyArr, 5);

            Array.Clear(arr, 0, 2);
            //Question: What is the difference between Array.Copy() and Array.ConstrainedCopy() ?
            /*
             - Copy() → may partially copy if error happens
             - ConstrainedCopy() → atomic (all or nothing)
             */

            #endregion
            #region loops with arrays
            int[] array = { 1, 2, 3, 4, 5 };

            // for loop
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine(array[i]);

            // foreach
            foreach (int x in array)
                Console.WriteLine(x);

            // while (reverse)
            int y = array.Length - 1;
            while (index >= 0)
            {
                Console.WriteLine(arr[index]);
                index--;
            }
            //Question: Why is foreach preferred for read-only operations on arrays?
            /*
             - Simpler
             - Safer (no index errors)
             - More readable
             */

            #endregion
            #region Odd number input
            int number;

            do
            {
                Console.Write("Enter a positive odd number: ");
            } while (!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number % 2 == 0);

            Console.WriteLine("Valid number entered.");

            //Question: Why is input validation important when working with user inputs?
            /*
             - Prevents runtime errors
             - Improves program stability
             - Protects against invalid or malicious input
             */
            #endregion
            #region 2D Array - fixed values
            int[,] matrix =
             {
              {1, 2, 3},
              {4, 5, 6},
              {7, 8, 9}
             };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            //Question: How can you format the output of a 2D array for better readability? 
            /*
              - Use tabs \t
              - Align columns
              - Print row by row
             */
            #endregion
            #region month number
            int month = int.Parse(Console.ReadLine());

            // if-else
            if (month == 1) Console.WriteLine("January");
            else if (month == 2) Console.WriteLine("February");
            else Console.WriteLine("Invalid");

            // switch
            switch (month)
            {
                case 1: Console.WriteLine("January"); break;
                case 2: Console.WriteLine("February"); break;
                default: Console.WriteLine("Invalid"); break;
            }
            //Question: When should you prefer a switch statement over if-else?
            /*
              - Many fixed values
              - Cleaner & more readable
             */

            #endregion
            #region sort and search
            int[] s = { 4, 2, 7, 2, 9 };

            Array.Sort(s);

            int first = Array.IndexOf(arr, 2);
            int last = Array.LastIndexOf(arr, 2);
            //Question: What is the time complexity of Array.Sort()?
            /*
             O(n log n)
             */
            #endregion
            #region sum of array elements
            int[] arr0 = { 1, 2, 3, 4 };

            // for loop
            int sum1 = 0;
            for (int i = 0; i < arr0.Length; i++)
                sum1 += arr0[i];

            // foreach
            int sum2 = 0;
            foreach (int x in arr0)
                sum2 += x;

            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            //Question: Which loop (for or foreach) is more efficient for calculating the sum of an array, and why?
            /*
              - for and foreach have almost the same performance with arrays.
              - foreach is preferred because it is more readable.
              - foreach is safer since it avoids index errors.
              - Use for when you need the index or want to modify elements.
             */

            #endregion
            #region part2 enum day of week
            Console.Write("Enter a number (1-7): ");
            int input = int.Parse(Console.ReadLine());

            DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), input.ToString());

            Console.WriteLine($"Day is: {day}");
            //What happens if the user enters a value outside the range of 1 to 7? 
            /*
             - The program will not throw an exception.
             - Enum.Parse will still create an enum value from the number.
             - The value will not correspond to any defined enum member.
             - The result will be logically invalid.
             - Input validation is necessary to ensure values are between 1 and 7.
             */
            #endregion
        }
    }
}
