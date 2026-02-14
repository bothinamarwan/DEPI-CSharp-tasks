namespace CSharp_Day6
{
    internal class Program
    {
        public struct Point
        {
            public int X;
            public int Y;

            // Default constructor (C# automatically provides one)
            public Point()
            {
                X = 0;
                Y = 0;
            }

            // Parameterized constructor
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            // Override ToString()
            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }
        public class TypeA
        {
            private int F = 10;
            internal int G = 20;
            public int H = 30;

            public int GetF()
            {
                return F;
            }
        }
        #region struct Employee
        public struct Employee
        {
            private int EmpId;
            private string Name;
            private double Salary;
           
            public Employee(int id, string name, double salary)
            {
                EmpId = id;
                Name = name;
                Salary = salary;
            }

            public string GetName()
            {
                return Name;
            }

            public void SetName(string name)
            {
                Name = name;
            }

            public double SalaryProperty
            {
                get { return Salary; }
                set
                {
                    if (value > 0)
                        Salary = value;
                }
            }

            public override string ToString()
            {
                return $"ID: {EmpId}, Name: {Name}, Salary: {Salary}";
            }
        }
        #endregion
        public struct Point4
        {
            public int X;
            public int Y;

            // X specific, Y = 0
            public Point4(int x)
            {
                X = x;
                Y = 0;
            }

            // X and Y specific
            public Point4(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }
        public override string ToString()
        {
            return $"Point => X: {X}, Y: {Y}";
        }
        static void Main(string[] args)
        {
            #region  struct Point
            Point p1 = new Point();
            Point p2 = new Point(5, 10);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            //Question: Why can't a struct inherit from another struct or class in C#?
            /*
               - A struct is a value type, not a reference type.
               - All structs implicitly inherit from System.ValueType.
               - C# does not support multiple inheritance for value types.
               - Allowing struct inheritance would:
                    Complicate memory layout.
                    Break value-type copying behavior.
               - Structs are designed to be:
                     Lightweight
                     Simple
                     Efficient in memory usage
               - However, structs can implement interfaces.
             */
            #endregion
            #region access modifiers
            TypeA obj = new TypeA();
            // Console.WriteLine(obj.F);  Error (private)
            Console.WriteLine(obj.G);  //Accessible inside same project
            Console.WriteLine(obj.H);    //Accessible everywhere
            Console.WriteLine(obj.GetF()); //Through method
                                           //Question: How do access modifiers impact the scope and visibility of a class member? 
            /*
             Access modifiers control who can access a class member.
                - private
                       Accessible only inside the same class.
                       Provides maximum protection.
                - internal
                      Accessible inside the same project (assembly).
                      Not accessible from another project.
                - public
                     Accessible from anywhere.
                     No restrictions.
                - protected
                       Accessible inside the class and derived classes.
                - Impact:
                   - Improve security of data.
                   - Prevent unintended modification.
                   - Help organize and control code structure.
                   - Enforce encapsulation principles.
             
             */
            #endregion
            #region struct Employee
            Employee emp = new Employee(1, "Ali", 5000);

            emp.SetName("Ahmed");
            emp.SalaryProperty = 7000;

            Console.WriteLine(emp);
            //Question: Why is encapsulation critical in software design?
            /*
              Encapsulation is critical because it:
                 - Protects data from unauthorized access.
                 - Prevents accidental modification.
                 - Allows controlled access using methods and properties.
                 - Improves code maintainability.
                 - Makes debugging easier.
                 - Enhances security.
                 - Promotes clean and modular design.
                 - Reduces system complexity.
             */
            #endregion
            #region constructor overloading
            Point4 p4 = new Point4(5);
            Point4 p5 = new Point4(5, 8);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            #endregion
            #region ToString() method 
            Point[] points =
                   {
                       new Point(1,2),
                       new Point(3,4),
                       new Point(5,6)
                   };

            foreach (var p in points)
            {
                Console.WriteLine(p);
            }
            //Question: How does overriding methods like ToString() improve code readability? 
            /*
             Overriding ToString():
                 - Provides meaningful output instead of default type name.
                 - Makes debugging easier.
                 - Improves logging readability.
                 - Helps display object data clearly.
                 - Makes console output more professional.
                 - Enhances overall code clarity.
             */
            #endregion
        }
    }
}
/////////////////////////part 2/////////////////////////
//What is copy constructor? 
/*
     - A constructor that creates a new object by copying another object of the same type.
     - it takes an object of the same class as a parameter.
     - sed to duplicate objects.
     - elps control how copying is done (shallow or deep copy).
     - n C#, it must be written manually (not automatic).
     - tructs don’t usually need it because they copy by value automatically.
*/
//what is indexer?
/*
   - An indexer allows an object to be accessed like an array.
   - It lets you use [] with an object.
   - Defined using the this keyword.
   - It does not require a method name.
 */
//when is indexer used?
/*
     - When a class contains a collection of data.
     - When you want the object to behave like an array.
     - When accessing elements by index is more natural.
     - When simplifying syntax improves readability.
 */
//business cases:
/*
 When your class internally stores multiple items and you want clean, array-like access.
 */
