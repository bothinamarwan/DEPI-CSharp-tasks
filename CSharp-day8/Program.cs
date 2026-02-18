using CSharp_Day8.part2;
using System.Drawing;

namespace CSharp_Day8
{
    #region struct account
    struct Account
    {
        private int accountId;
        private string accountHolder;
        private double balance;

        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        public string AccountHolder
        {
            get { return accountHolder; }
            set { accountHolder = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
       
    }
    #endregion
    internal class Program
    {
        #region part2
        static void PrintTenShapes(IShapeSeries series)
        {
            Console.WriteLine("First 10 areas:");
            for (int i = 0; i < 10; i++)
            {
                series.GetNextArea();
                Console.WriteLine(series.CurrentShapeArea);
            }
            series.ResetSeries();
        }

        static void SelectionSort(int[] numbers)
        {
            int n = numbers.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = numbers[i];
                numbers[i] = numbers[minIndex];
                numbers[minIndex] = temp;
            }
        }
            #endregion
            static void Main(string[] args)
        {
            #region interface IVehicle 
            IVehicle car = new Car();
            IVehicle bike = new Bike();

            car.StartEngine();
            car.StopEngine();

            bike.StartEngine();
            bike.StopEngine();
            //Question: Why is it better to code against an interface rather than a concrete class?  
            /*
              - Reduces tight coupling between components.
              - Makes the system easier to modify and extend.
              - Supports Dependency Injection.
              - Improves unit testing (you can mock interfaces).
              - Allows multiple implementations without changing client code.
              - Follows the Open/Closed Principle (open for extension, closed for modification).
             */
            #endregion
            #region abstract class Shape
            shape rect = new rectangle(5, 4);
            rect.Display();
            Console.WriteLine("Rectangle Area = " + rect.GetArea());

            shape circle = new circle(3);
            circle.Display();
            Console.WriteLine("Circle Area = " + circle.GetArea());
            //Question: When should you prefer an abstract class over an interface?  
            /*
              - When classes share common implementation code.
              - When you need constructors.
              - When you need fields (instance variables).
              - When there is a strong "is-a" relationship.
              - When you want to provide partial implementation and force derived classes to complete the rest.
              - When future versions may need additional non-abstract methods.
             
             */
            #endregion
            #region class Product
            product[] products =
         {
            new product { Id=1, Name="Laptop", Price=15000 },
            new product { Id=2, Name="Phone", Price=8000 },
            new product { Id=3, Name="Tablet", Price=6000 }
        };

            Array.Sort(products);

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }
            //Question: How does implementing IComparable improve flexibility in sorting? 
            /*
               - Allows objects to define their own default sorting logic.
               - Enables built-in sorting methods like Array.Sort() to work automatically.
               - Eliminates the need for external comparison logic in simple cases.
               - Makes sorting behavior encapsulated inside the class.
               - Allows easy modification of comparison logic (e.g., sort by price, name, etc.).
             */
            #endregion
            #region shallow vs. deep copies
            student s1 = new student(1, "Ali", 90);
            student s2 = s1; // Shallow Copy (reference copy)

            student s3 = new student(s1); // Deep Copy
                                          //Question: What is the primary purpose of a copy constructor in C#? 
            /*
              - To create a new independent object based on an existing object.
              - To avoid unintended modifications when copying references.
              - To support deep copying of object data.
              - To ensure object duplication while preserving original state.
              - To prevent shared references in complex objects.
             */
            #endregion
            #region Implement explicit interface
            Robot r = new Robot();
            r.Walk(); // normal

            IWalkable w = r;
            w.Walk(); // explicit
                      //Question: How does explicit interface implementation help in resolving naming conflicts?  
            /*
              - Allows multiple interfaces to define methods with the same name.
              - Prevents method name conflicts inside a class.
              - Hides the interface method from the class’s public API.
              - Forces access through the interface reference only.
              - Helps separate different behaviors for the same method name.
             */
            #endregion
            #region  struct Account 
            Account acc = new Account();

            acc.AccountId = 101;
            acc.AccountHolder = "Ali";
            acc.Balance = 5000;

            Console.WriteLine("Account ID: " + acc.AccountId);
            Console.WriteLine("Account Holder: " + acc.AccountHolder);
            Console.WriteLine("Balance: " + acc.Balance);
            //Question: What is the key difference between encapsulation in structs and classes? 
            /*
              - Structs are value types, classes are reference types.
              - Structs are copied by value; classes are copied by reference.
              - Classes support inheritance; structs do not.
              - Structs are typically used for small data structures.
              - Encapsulation works similarly, but memory behavior differs.
             */
            //Question: what is abstraction as a guideline, what’s its relation with encapsulation?  
            /*
               - Abstraction:
                    - Focuses on what an object does, not how it does it.
                    - Hides complex internal details.
                    - Reduces system complexity.
                    - Achieved using interfaces and abstract classes.
               - Relation with Encapsulation:
                    - Encapsulation hides internal data.
                    - Abstraction hides implementation complexity.
                    - Encapsulation protects data integrity.
                    - Abstraction simplifies system design.
                    - Both improve maintainability and scalability.
             */
            #endregion
            #region  class Book 
            book b1 = new book();
            book b2 = new book("C# Basics");
            book b3 = new book("C# Advanced", "Ahmed");
            //Question: How does constructor overloading improve class usability? 
            /*
              - Provides multiple ways to initialize an object.
              - Makes object creation more flexible.
              - Reduces the need for setting properties after construction.
              - Improves code readability.
              - Allows default values when some data is not provided.
             */
            #endregion
            ///////////////////////part2//////////////////////
            //What we mean by coding against interface rather than class ? and if u get it so 
            /*
              - Depend on interface or abstract type, not a specific class.
              - Reduces tight coupling between components.
              - Makes the system more flexible and extendable.
              - Improves testability and supports mocking.
              - Allows multiple implementations without changing client code.
              - Follows the Open/Closed Principle (open for extension, closed for modification).
             */
            //What we mean by code against abstraction not concreteness ?
            /*
              - Depend on general contracts (interfaces / abstract classes) instead of concrete implementations.
              - Focus on what an object can do, not how it does it.
              - Makes the system more maintainable and adaptable to change.
              - Encourages polymorphism and loose coupling.
              - Supports Dependency Inversion Principle in software design.
             */
            #region part 2
            Console.WriteLine("=== Part 1: Shape Series ===");
            IShapeSeries squareSeries = new SquareSeries();
            PrintTenShapes(squareSeries);

            IShapeSeries circleSeries = new CircleSeries();
            PrintTenShapes(circleSeries);

            Console.WriteLine("\n=== Part 2: Sorting Shapes ===");
            Shape[] shapes = {
            new Shape { Name = "Square", Area = 25 },
            new Shape { Name = "Circle", Area = 78.5 },
            new Shape { Name = "Rectangle", Area = 40 },
            new Shape { Name = "Triangle", Area = 30 }
        };

            Array.Sort(shapes);

            foreach (var s in shapes)
            {
                Console.WriteLine($"{s.Name} - {s.Area}");
            }

            Console.WriteLine("\n=== Part 3: Extended Shape Hierarchy ===");
            GeometricShape triangle = new Triangle { Dimension1 = 3, Dimension2 = 4 };
            GeometricShape rectangle = new part2.Rectangle { Dimension1 = 5, Dimension2 = 6 };

            Console.WriteLine($"Triangle Area: {triangle.CalculateArea()}, Perimeter: {triangle.Perimeter}");
            Console.WriteLine($"Rectangle Area: {rectangle.CalculateArea()}, Perimeter: {rectangle.Perimeter}");

            Console.WriteLine("\n=== Part 4: Custom SelectionSort ===");
            int[] areas = { 25, 78, 40, 30, 10 };
            Console.WriteLine("Before Sorting: " + string.Join(", ", areas));

            SelectionSort(areas);
            Console.WriteLine("After Sorting: " + string.Join(", ", areas));
        }
        #endregion
        //////////////////////////////////part3//////////
        //what is operator overloading?
        /*
         - Definition:
                - Operator overloading allows a class or struct to define or change the behavior of standard operators 
                     (like +, -, *, ==) for its own objects.
         - Purpose:
                 - Makes objects of custom classes behave like built-in types.
                 - Improves readability and expressiveness in code.
         -Key Points:
                 - Can overload most operators, but not all (e.g., ?:, sizeof cannot be overloaded).
                 - Must use the operator keyword.
                 - Typically implemented as static methods inside the class.
                 - Both operands can be objects of the class or one object + built-in type.
                 - Overloading does not create a new operator, it just changes how it works for your class.
         - Example Concept (no full code as you asked for points only):
                    - Overloading + in a Point class to add two points’ coordinates.
                    - Overloading == in a Student class to compare two students by Id.
          - Benefits:
                - akes code more intuitive: c = a + b instead of c = a.Add(b).
                - upports polymorphism for operators.
                - keeps operations consistent with object semantics.
         */


    }
}

