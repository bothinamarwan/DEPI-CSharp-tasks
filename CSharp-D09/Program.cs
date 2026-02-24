using System.Drawing;

namespace CSharp_day9
{
    internal class Program
    {
        enum Weekdays
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }
        enum Grades : short
        {
            F = 1,
            D,
            C,
            B,
            A
        }
        #region persson class
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Department { get; set; }

            public override string ToString()
            {
                return $"Name: {Name}, Age: {Age}, Dept: {Department}";
            }
        }
        #endregion
        #region sealed Salary 
        class Parent
        {
            public virtual decimal Salary { get; set; }
        }

        class Child : Parent
        {
            public sealed override decimal Salary { get; set; }

            public void DisplaySalary()
            {
                Console.WriteLine($"Salary: {Salary}");
            }
        }
        #endregion
        #region Utility class
        static class Utility
        {
            public static double CalculatePerimeter(double length, double width)
            {
                return 2 * (length + width);
            }
        }
        #endregion
        #region ComplexNumber
        class ComplexNumber
        {
            public double Real { get; set; }
            public double Imaginary { get; set; }

            public ComplexNumber(double r, double i)
            {
                Real = r;
                Imaginary = i;
            }

            public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
            {
                return new ComplexNumber(
                    a.Real * b.Real - a.Imaginary * b.Imaginary,
                    a.Real * b.Imaginary + a.Imaginary * b.Real
                );
            }

            public override string ToString()
            {
                return $"{Real} + {Imaginary}i";
            }
        }
        #endregion
        enum Gender : byte
        {
            Male = 1,
            Female = 2
        }
        #region  convert temperatures
        static class Utility0
        {
            public static double ToFahrenheit(double c)
                => (c * 9 / 5) + 32;

            public static double ToCelsius(double f)
                => (f - 32) * 5 / 9;
        }
        #endregion
        #region Employee class
        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override bool Equals(object obj)
            {
                if (obj is Employee other)
                    return Id == other.Id;
                return false;
            }

            public override int GetHashCode()
            {
                return Id.GetHashCode();
            }
        }
        #endregion
        #region generic max
        class Helper
        {
            public static T Max<T>(T a, T b) where T : IComparable<T>
            {
                return a.CompareTo(b) > 0 ? a : b;
            }
        }
        #endregion
        #region ReplaceArray
        class Helper2<T>
        {
            public static void ReplaceArray(T[] arr, T oldValue, T newValue)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Equals(oldValue))
                        arr[i] = newValue;
                }
            }
        }
        #endregion
        #region non-generic Swap
        struct Rectangle
        {
            public double Length { get; set; }
            public double Width { get; set; }
        }
        static void Swap(ref Rectangle r1, ref Rectangle r2)
        {
            Rectangle temp = r1;
            r1 = r2;
            r2 = temp;
        }
        #endregion
        #region  Department class
        class Department
        {
            public string Name { get; set; }

            public override bool Equals(object obj)
            {
                if (obj is Department other)
                    return Name == other.Name;
                return false;
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }

            public override string ToString()
            {
                return Name;
            }
        }

        #endregion
        #region struct Circle
        struct Circle
        {
            public double Radius { get; set; }
            public string Color { get; set; }
        }

        class CircleClass
        {
            public double Radius { get; set; }
            public string Color { get; set; }
        }
        #endregion

        static void Main(string[] args)
        {
            #region weekdays enum
            foreach (Weekdays day in Enum.GetValues(typeof(Weekdays)))
            {
                Console.WriteLine($"{day} = {(int)day}");
            }
            //Question: Why is it recommended to explicitly assign values to enum members in some cases? 
            /*
               - To ensure consistent numeric values when interacting with databases or external APIs.
               - To prevent unintended value changes if new members are inserted later.
               - To control the starting value or specific numbering logic.
               - To maintain backward compatibility in large systems.
             
             */
            #endregion
            #region Grades enum 
            foreach (Grades grade0 in Enum.GetValues(typeof(Grades)))
            {
                Console.WriteLine($"{grade0} = {(short)grade0}");
            }
            //Question: What happens if you assign a value to an enum member that exceeds the underlying type's range?
            /*
               - It causes a compile-time error if the value is constant and out of range.
               - If forced through casting, it may result in overflow and unexpected values.
               - The enum will store an incorrect numeric representation.
             */
            #endregion
            #region Person with Department
            Person p1 = new Person { Name = "Ali", Age = 25, Department = "IT" };
            Person p2 = new Person { Name = "Sara", Age = 30, Department = "HR" };
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            //Question: What is the purpose of the virtual keyword when used with properties?
            /*
               - It allows derived classes to override the property.
               - It enables runtime polymorphism.
               - It supports flexible and extensible object-oriented design.
             */
            #endregion
            #region sealed salary in child
            Child child = new Child();

            child.Salary = 6000m;

            child.DisplaySalary();

            // Demonstrating polymorphism
            Parent parentReference = child;
            Console.WriteLine($"Salary via Parent reference: {parentReference.Salary}");
            //Question: Why can’t you override a sealed property or method?
            /*
               - Because sealed prevents further overriding in derived classes.
               - It is used to stop inheritance modification for security or design control.
               - It ensures the implementation remains final.
             */
            #endregion
            #region static method in the Utility class
            Console.WriteLine(Utility.CalculatePerimeter(5, 3));
            //Question: What is the key difference between static and object members?
            /*
               - Static members belong to the class itself.
               - Object (instance) members belong to specific objects.
               - Static members do not require object creation.
               - Instance members require an object to access them.
             */
            #endregion
            #region ComplexNumber
            ComplexNumber c1 = new ComplexNumber(2, 3);   // 2 + 3i
            ComplexNumber c2 = new ComplexNumber(4, 5);   // 4 + 5i

            ComplexNumber result = c1 * c2; // Using overloaded 

            Console.WriteLine("First Complex Number: " + c1);
            Console.WriteLine("Second Complex Number: " + c2);
            Console.WriteLine("Multiplication Result: " + result);
            //Question: Can you overload all operators in C#? Explain why or why not. 
            /*
               - No, not all operators can be overloaded.
               - Some operators (like . , ?: , sizeof) are not overloadable.
               - Only predefined overloadable operators are allowed to maintain language safety and clarity.
             */
            #endregion
            #region Gender enum byte
            Console.WriteLine(sizeof(byte)); // 1
            Console.WriteLine(sizeof(int));  // 4
                                             //Question: When should you consider changing the underlying type of an enum?
            /*
               - When memory optimization is required (e.g., using byte instead of int).
               - When working with network protocols or file storage formats.
               - When integrating with systems that require specific numeric sizes.
             */
            #endregion
            #region  convert temperatures
            double celsius = 25;
            double fahrenheit = Utility0.ToFahrenheit(celsius);

            Console.WriteLine($"{celsius}°C = {fahrenheit}°F");

            double newCelsius = Utility0.ToCelsius(fahrenheit);
            Console.WriteLine($"{fahrenheit}°F = {newCelsius}°C");
            //Question: Why can't a static class have instance constructors? 
            /*
               - Because static classes cannot be instantiated.
               - They are designed to contain only static members.
               - Creating an instance would contradict their purpose.
             */
            #endregion
            #region Enum.TryParse
            Console.Write("Enter Grade: ");
            string input = Console.ReadLine();

            if (Enum.TryParse(input, out Grades grade))
                Console.WriteLine($"Valid Grade: {grade}");
            else
                Console.WriteLine("Invalid grade!");
            //Question: What are the advantages of using Enum.TryParse over direct parsing with int.Parse ?
            /*
              - It does not throw exceptions on invalid input.
              - It safely handles incorrect user input.
              - It improves performance by avoiding exception handling.
              - It makes programs more robust and user-friendly.
             */
            #endregion
            #region Employee class
            Employee[] employees =
        {
            new Employee { Id = 1, Name = "Ali" },
            new Employee { Id = 2, Name = "Sara" },
            new Employee { Id = 3, Name = "Omar" }
        };

            Employee employeeToFind = new Employee { Id = 2, Name = "Test" };

            bool found = false;

            foreach (Employee emp in employees)
            {
                if (emp.Equals(employeeToFind))
                {
                    Console.WriteLine($"Employee Found: Id = {emp.Id}, Name = {emp.Name}");
                    found = true;
                    break;
                }
            }

            if (!found)
                Console.WriteLine("Employee not found.");
            //Question: What is the difference between overriding Equals and == for object comparison in C# struct and class ?
            /*
               - Equals() compares object content (if overridden).
                - == compares references for classes unless overloaded.
                - For structs, Equals() compares field-by-field by default.
                - == must be explicitly overloaded for structs.
             */
            //Question: Why is overriding ToString beneficial when working with custom classes?
            /*
               - It provides meaningful string representation of objects.
               - It improves debugging and logging.
               - It enhances readability when printing objects.
             */
            #endregion
            #region generic max
            // Integer example
            int maxInt = Helper.Max(10, 25);
            Console.WriteLine($"Max (int): {maxInt}");

            // Double example
            double maxDouble = Helper.Max(5.7, 3.2);
            Console.WriteLine($"Max (double): {maxDouble}");

            // String example (compares alphabetically)
            string maxString = Helper.Max("Ali", "Sara");
            Console.WriteLine($"Max (string): {maxString}");
            //Question: Can generics be constrained to specific types in C#? Provide an example
            /*
               - Yes, generics can use constraints.
               - Example constraints:
                       - where T : class
                       - where T : struct
                       - where T : IComparable
               - Constraints ensure type safety and allow access to specific members.
             */
            #endregion
            #region ReplaceArray
            // Integer array example
            int[] numbers = { 1, 2, 3, 2, 4, 2 };

            Helper2<int>.ReplaceArray(numbers, 2, 99);

            Console.WriteLine("Updated Integer Array:");
            foreach (int num in numbers)
                Console.Write(num + " ");

            Console.WriteLine();

            // String array example
            string[] names = { "Ali", "Sara", "Ali", "Omar" };

            Helper2<string>.ReplaceArray(names, "Ali", "Mona");

            Console.WriteLine("Updated String Array:");
            foreach (string name in names)
                Console.Write(name + " ");
            //Question: What are the key differences between generic methods and generic classes ?
            /*
              - Generic method: Only the method is generic.
              - Generic class: The entire class works with a generic type.
              - Generic classes maintain type consistency across all members.
              - Generic methods provide flexibility within non-generic classes.
            */
            #endregion
            #region non-generic Swap
            Rectangle rect1 = new Rectangle { Length = 10, Width = 5 };
            Rectangle rect2 = new Rectangle { Length = 20, Width = 8 };

            Console.WriteLine("Before Swap:");
            Console.WriteLine($"Rect1: {rect1.Length}, {rect1.Width}");
            Console.WriteLine($"Rect2: {rect2.Length}, {rect2.Width}");

            Swap(ref rect1, ref rect2);

            Console.WriteLine("\nAfter Swap:");
            Console.WriteLine($"Rect1: {rect1.Length}, {rect1.Width}");
            Console.WriteLine($"Rect2: {rect2.Length}, {rect2.Width}");
            // Question: Why might using a generic swap method be preferable to implementing custom methods for each type? 
            /*
              - Reduces code duplication.
              - Increases reusability.
              - Works with any data type.
              - Improves maintainability.
             */
            #endregion
            #region  Department class
            Department d1 = new Department { Name = "IT" };
            Department d2 = new Department { Name = "HR" };
            Department d3 = new Department { Name = "IT" };

            Console.WriteLine("Comparing Departments:");

            Console.WriteLine($"d1 equals d2? {d1.Equals(d2)}"); // False
            Console.WriteLine($"d1 equals d3? {d1.Equals(d3)}"); // True

            // Demonstrating search in array
            Department[] departments = { d1, d2 };

            Department searchDepartment = new Department { Name = "IT" };

            bool found0 = false;

            foreach (Department dept in departments)
            {
                if (dept.Equals(searchDepartment))
                {
                    Console.WriteLine("Department found in array.");
                    found0 = true;
                    break;
                }
            }

            if (!found0)
                Console.WriteLine("Department not found.");
            //Question:How can overriding Equals for the Department class improve the accuracy of searches?
            /*
              - It ensures comparison is based on content, not reference.
              - It allows correct matching when searching arrays or collections.
              - It prevents false mismatches between logically identical objects.
             */
            #endregion
            #region struct Circle
            // Struct instances
            Circle c_1 = new Circle { Radius = 5, Color = "Red" };
            Circle c_2 = new Circle { Radius = 5, Color = "Red" };

            Console.WriteLine("STRUCT COMPARISON:");
            Console.WriteLine($"c1.Equals(c2): {c_1.Equals(c_2)}"); 

            // Class instances
            CircleClass cc1 = new CircleClass { Radius = 5, Color = "Red" };
            CircleClass cc2 = new CircleClass { Radius = 5, Color = "Red" };

            Console.WriteLine("\nCLASS COMPARISON:");
            Console.WriteLine($"cc1.Equals(cc2): {cc1.Equals(cc2)}"); // False (reference comparison)
            Console.WriteLine($"cc1 == cc2: {cc1 == cc2}");           // False (reference comparison)

            // Make them reference the same object
            CircleClass cc3 = cc1;

            Console.WriteLine("\nCLASS SAME REFERENCE:");
            Console.WriteLine($"cc1.Equals(cc3): {cc1.Equals(cc3)}"); // True
            Console.WriteLine($"cc1 == cc3: {cc1 == cc3}");           // True
                                                                      //Question: Why is == not implemented by default for structs?
            /*
               - Structs are value types and compared by value using Equals().
               - The == operator must be explicitly overloaded.
               - C# avoids automatic operator implementation to prevent unintended behavior.
             */
            #endregion
            ////////////////////////////////////part 2////////////////////////////////
            //What we mean by Generalization concept using Generics ?
            /*
              - Writing reusable code that works with multiple data types.
              - Using type parameters instead of specific data types.
              - Reducing code duplication.
              - Increasing flexibility and scalability.
              - Providing compile-time type safety.
              - Eliminating the need for casting.
             */
            //What we mean by hierarchy design in real business ?
            /*
               - Structuring classes to reflect real-world business relationships.
               - Organizing entities in parent-child relationships.
               - Using inheritance to represent shared behavior.
               - Promoting code reuse across related classes.
               - Supporting polymorphism and extensibility.
               - Improving system organization and maintainability.
             */
            #region Generic Method for Reversing an Array
            int[] numbers_ = { 1, 2, 3, 4 };
            string[] names_ = { "Ali", "Sara", "Omar" };

            var reversedNumbers = part_2.Helper_.ReverseArray(numbers_);
            var reversedNames = part_2.Helper_.ReverseArray(names_);

            Console.WriteLine("Reversed Integers:");
            foreach (var n in reversedNumbers)
                Console.Write(n + " ");

            Console.WriteLine("\nReversed Strings:");
            foreach (var name in reversedNames)
                Console.Write(name + " ");
            #endregion
            #region Generic Class for a Stack
            Stack<int> stack = new Stack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Console.WriteLine("Peek: " + stack.Peek());
            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("Pop: " + stack.Pop());
            #endregion
            #region Generic Method for Swapping Elements
            int[] numbers_1 = { 1, 2, 3, 4 };

            part_2.Helper_1.Swap(numbers_1, 0, 3);

            Console.WriteLine("After Swap:");
            foreach (var n in numbers_1)
                Console.Write(n + " ");
            #endregion
            #region Generic Method for Finding Maximum Elemen
            int[] numbers_2 = { 5, 2, 9, 1 };
            string[] names_2 = { "Ali", "Sara", "Omar" };

            Console.WriteLine("Max Integer: " + part_2.Helper_2.FindMax(numbers_2));
            Console.WriteLine("Max String: " + part_2.Helper_2.FindMax(names_2));
            #endregion
            ///////////////////////////////////////////////part 3////////////////
            // what is Event deriven programming ?
            /*
              - A programming paradigm where program execution is controlled by events.
              - The program waits for events to occur before executing code.
              - Events can be user actions, system signals, or messages.
              - When an event occurs, an event handler is triggered.
              - Commonly used in graphical user interfaces and web applications.
             */
        }
    }
}
