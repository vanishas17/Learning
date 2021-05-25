using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id = 1, Name="Emp 1" },
                new Employee {Id = 2, Name="Emp 2" }
            };

            IEnumerable<Employee> testers = new List<Employee>()
            {
                new Employee {Id = 3, Name="Tester 1" },
                new Employee {Id = 4, Name="Tester 2" }
            };

            Console.WriteLine(developers.Count());

            //================Lambda Expressions=========================//

            //Named Methods
            foreach (var emp in developers.Where(NameStartsWithE))
            {
                Console.WriteLine(emp.Name);
            }

            //Anonymous methods
            foreach (var emp in developers.Where(
                delegate (Employee employee)
                {
                    return employee.Name.StartsWith("E");
                }))
            {
                Console.WriteLine(emp.Name);
            }

            //Lambda Expresions
            foreach (var emp in developers.Where(e => e.Name.StartsWith("E")))                
            {
                Console.WriteLine(emp.Name);
            }

            //Func and Action
            Func<int, int> square = x => x * x;
            Console.WriteLine("Square is : " + square(3));

            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine("Sum is: "+ add(3, 5));

            Func<int, int, int> addnum = (x, y) => {
                int sum = x + y;
                return sum;
            };

            Console.WriteLine("Sum of numbers is: " + add(3, 5));



            //Action returns always void
            Action<int> write =  x => Console.WriteLine("final : " + x);
            write(square(add(3, 5)));

            Console.Read();

        }



        //Named Methods
        private static bool NameStartsWithE(Employee employee)
        {
            return employee.Name.StartsWith("E");
        }


    }
}
