using Microsoft.VisualBasic;
using System.Text;

namespace Csharp_day3
{
    class myClass
    {
        public int value;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           #region convert string to int
          Console.WriteLine("please enter a number");
            string input = Console.ReadLine();
            try
            {
                int num = int.Parse(input);
                Console.WriteLine("using int.parse:" + num);

                int num2 = Convert.ToInt32(input);
                Console.WriteLine("using convert :" + num2);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("error" + ex.Message);
            }
            //Question: What is the difference between int.Parse and Convert.ToInt32 when handling null inputs ?
            /*
             int.parse(null) -> throwsArgumentNullExption 
            convert.toint32(null) -> returns zero
            convert.toint32 is more secure with null
             */ 
             #endregion
           #region user input validation
            Console.WriteLine("please enter a number");
            string x = Console.ReadLine();
            if (int.TryParse(x,out int result))
            {
                Console.WriteLine("valid number :"+result);
            }
            else
            {
                Console.WriteLine("error (invalid number)");
            }
            //Question: Why is TryParse recommended over Parse in user-facing applications? 
            /*
             -no exceptions
            -faster performance
            -suitable for direct user input handling
            -prevent the program from crashing
             */
           #endregion
           #region object,getHashCode
            object obj;
            obj =22;
            Console.WriteLine("int hash:"+obj.GetHashCode());

            obj = "bothina";
            Console.WriteLine("string hash:" + obj.GetHashCode());
            obj = 5.845;
            Console.WriteLine("double hash:" + obj.GetHashCode());
            //Question: Explain the real purpose of the GetHashCode() method. 
            /*
            - It is used to determine the position of an object in hash-based collections
                such as Dictionary and Hashtable.
            - It helps improve performance when searching for objects.
            - It is not a unique identifier for an object.
             */
            #endregion
            #region refrance Equality
            myClass obj1 = new myClass();
            obj1.value = 5;
            myClass obj2 = obj1;
            obj2.value = 6;
            Console.WriteLine(obj1.value); //6
            //Question: What is the significance of reference equality in .NET? 
            /*
             Reference equality means multiple references point to the same object in memory,
            so changes through one reference affect all others.
             */
            #endregion
            #region string immutability
            string str = "hello";
            Console.WriteLine(str.GetHashCode());
            str += "hi willy";
            Console.WriteLine(str.GetHashCode());
            //Question: Why string is immutable in C# ? 
            /*
              - It is thread-safe.
              - It improves performance through the String Pool mechanism.
              - It prevents unexpected changes to string values.
              - Any modification creates a new object in memory instead of changing the original one.
             */
            #endregion
            #region stringBuilder GetHachCode
            StringBuilder sb = new StringBuilder("Hello");
            Console.WriteLine(sb.GetHashCode());
            sb.Append(" Hi Willy");
            Console.WriteLine(sb.GetHashCode());
            //Question: How does StringBuilder address the inefficiencies of string concatenation?
            /*
             - Modifies the same object in memory
             - Avoids creating new string objects on each change
             - Reduces memory allocation
             - Minimizes garbage collection overhead
             - Improves performance, especially with frequent modifications
             */
            //Question: Why is StringBuilder faster for large-scale string modifications?
            /*
             - It modifies the same object instead of creating new ones
             - It uses less memory allocation
             - It reduces Garbage Collection overhead
             - It is optimized for frequent and large string changes
             - It provides better overall performance
             */
            #endregion
            #region string formatting methods
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine()); 
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Sum is " + (a + b));
            Console.WriteLine(string.Format("Sum is {0}", a + b));
            Console.WriteLine($"Sum is {a + b}");
            //Question: Which string formatting method is most used and why?
            /*
             - String Interpolation ($) is the most commonly used method.
             - It is easy to read and write.
             - It is less error-prone compared to concatenation and string.Format.
             - It makes the code cleaner and more maintainable.
             */
            #endregion
            #region StringBuilder adv. operation
            StringBuilder sb1 = new StringBuilder("Hello");
            sb1.Append(" World");
            sb1.Replace("World", "C#");
            sb1.Insert(5, ",");
            sb1.Remove(5, 1);
            Console.WriteLine(sb1.ToString());
            //Question: Explain how StringBuilder is designed to handle frequent modifications compared to strings.
            /*
             - StringBuilder is mutable, while strings are immutable.
             - It modifies the same object in memory instead of creating new objects.
             - It uses an internal buffer that can grow as needed.
             - It reduces memory allocation and garbage collection.
             - It provides better performance for frequent or large string modifications.
             */

            #endregion
        }
    }
}
