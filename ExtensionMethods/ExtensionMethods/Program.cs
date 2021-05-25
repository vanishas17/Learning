using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        }
    }
}
