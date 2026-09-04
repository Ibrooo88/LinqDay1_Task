using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqDay1
{
    public class Employee
    {
        public Employee(int iD, string name, int salary)
        {
            ID = iD;
            Name = name;
            Salary = salary;
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Salary { get; private set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, -24, -25, 67, 8, 0, 7, 34, 21, 57, 46, -38 };

            List<Employee> employees = new List<Employee>
            {
                new Employee(1, "Essam", 30000),
                new Employee(2, "Ahmed", 40000),
                new Employee(3, "Osama", 30000),
                new Employee(4, "Maha", 20000),
                new Employee(5, "Ali", 12000)
            };

            Console.WriteLine("---- 1) Aggregate ----");
            var totalSalaries = employees.Aggregate(0, (acc, emp) => acc + emp.Salary);
            Console.WriteLine("Total Salaries: " + totalSalaries);

            Console.WriteLine("\n---- 2) All ----");
            bool allPositive = numbers.All(n => n > 0);
            Console.WriteLine("All numbers positive? " + allPositive);

            Console.WriteLine("\n---- 3) Any ----");
            bool hasHighSalary = employees.Any(emp => emp.Salary > 35000);
            Console.WriteLine("Any employee salary > 35000? " + hasHighSalary);

            Console.WriteLine("\n---- 4) Append ----");
            var newNumbers = numbers.Append(100);
            Console.WriteLine("After Append(100): " + string.Join(", ", newNumbers));

            Console.WriteLine("\n---- 5) Average ----");
            double avgSalary = employees.Average(emp => emp.Salary);
            Console.WriteLine("Average Salary: " + avgSalary);

            Console.WriteLine("\n---- 6) Cast ----");
            ArrayList oldList = new ArrayList { 1, 2, 3, 4 };
            IEnumerable<int> castedNumbers = oldList.Cast<int>();
            Console.WriteLine("Casted: " + string.Join(", ", castedNumbers));

            Console.WriteLine("\n---- 7) Chunk ----");
            var chunks = numbers.Chunk(4);
            int chunkIndex = 1;
            foreach (var chunk in chunks)
            {
                Console.WriteLine($"Chunk {chunkIndex++}: " + string.Join(", ", chunk));
            }

            Console.WriteLine("\n---- 8) Concat ----");
            List<int> moreNumbers = new List<int> { 100, 200, 300 };
            var combined = numbers.Concat(moreNumbers);
            Console.WriteLine("Combined Count: " + combined.Count());

            Console.WriteLine("\n---- 9) Contains ----");
            bool hasNumber = numbers.Contains(67);
            Console.WriteLine("Contains 67? " + hasNumber);

            Console.WriteLine("\n---- 10) Count ----");
            int totalCount = numbers.Count();
            int positiveCount = numbers.Count(n => n > 0);
            Console.WriteLine("Total Count: " + totalCount);
            Console.WriteLine("Positive Count: " + positiveCount);

            Console.WriteLine("\nDone. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
