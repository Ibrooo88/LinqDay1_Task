using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int DepartmentID { get; set; }
    }

    internal class Program
    {
        static List<Department> departments = new List<Department>();
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            SeedData();
            MainMenu();
        }

        static void SeedData()
        {
            departments.Add(new Department { ID = 1, Name = "IT" });
            departments.Add(new Department { ID = 2, Name = "HR" });
            departments.Add(new Department { ID = 3, Name = "Sales" });

            employees.Add(new Employee { ID = 1, Name = "Ahmed", Salary = 15000, DepartmentID = 1 });
            employees.Add(new Employee { ID = 2, Name = "Mona", Salary = 12000, DepartmentID = 2 });
            employees.Add(new Employee { ID = 3, Name = "Sara", Salary = 18000, DepartmentID = 3 });
        }

        static void MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("==============================");
                Console.WriteLine("           Main Menu           ");
                Console.WriteLine("==============================");
                Console.WriteLine("1 - Employee Management");
                Console.WriteLine("2 - Department Management");
                Console.WriteLine("0 - Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EmployeeMenu();
                        break;
                    case "2":
                        DepartmentMenu();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }

        static void EmployeeMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine();
                Console.WriteLine("---- Employee Management ----");
                Console.WriteLine("1 - View All Employees");
                Console.WriteLine("2 - Add Employee");
                Console.WriteLine("3 - Edit Employee");
                Console.WriteLine("4 - Delete Employee");
                Console.WriteLine("0 - Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewEmployees();
                        break;
                    case "2":
                        AddEmployee();
                        break;
                    case "3":
                        EditEmployee();
                        break;
                    case "4":
                        DeleteEmployee();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }

        static void DepartmentMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine();
                Console.WriteLine("---- Department Management ----");
                Console.WriteLine("1 - View All Departments");
                Console.WriteLine("2 - Add Department");
                Console.WriteLine("3 - Edit Department");
                Console.WriteLine("4 - Delete Department");
                Console.WriteLine("0 - Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewDepartments();
                        break;
                    case "2":
                        AddDepartment();
                        break;
                    case "3":
                        EditDepartment();
                        break;
                    case "4":
                        DeleteDepartment();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }

        static void ViewEmployees()
        {
            Console.WriteLine();
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            foreach (var emp in employees)
            {
                var dept = departments.FirstOrDefault(d => d.ID == emp.DepartmentID);
                string deptName = dept != null ? dept.Name : "Unknown";
                Console.WriteLine($"ID: {emp.ID} | Name: {emp.Name} | Salary: {emp.Salary} | Department: {deptName}");
            }
        }

        static void AddEmployee()
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Employee Salary: ");
            int salary = int.Parse(Console.ReadLine());

            ViewDepartments();
            Console.Write("Enter Department ID: ");
            int deptId = int.Parse(Console.ReadLine());

            if (!departments.Any(d => d.ID == deptId))
            {
                Console.WriteLine("Department not found. Employee not added.");
                return;
            }

            int newId = employees.Count == 0 ? 1 : employees.Max(e => e.ID) + 1;

            employees.Add(new Employee { ID = newId, Name = name, Salary = salary, DepartmentID = deptId });
            Console.WriteLine("Employee added successfully.");
        }

        static void EditEmployee()
        {
            Console.Write("Enter Employee ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            var emp = employees.FirstOrDefault(e => e.ID == id);
            if (emp == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Console.Write($"Enter new Name (current: {emp.Name}): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                emp.Name = name;

            Console.Write($"Enter new Salary (current: {emp.Salary}): ");
            string salaryInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(salaryInput))
                emp.Salary = int.Parse(salaryInput);

            Console.Write($"Enter new Department ID (current: {emp.DepartmentID}): ");
            string deptInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(deptInput))
            {
                int deptId = int.Parse(deptInput);
                if (departments.Any(d => d.ID == deptId))
                    emp.DepartmentID = deptId;
                else
                    Console.WriteLine("Department not found, keeping old value.");
            }

            Console.WriteLine("Employee updated successfully.");
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var emp = employees.FirstOrDefault(e => e.ID == id);
            if (emp == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            employees.Remove(emp);
            Console.WriteLine("Employee deleted successfully.");
        }

        static void ViewDepartments()
        {
            Console.WriteLine();
            if (departments.Count == 0)
            {
                Console.WriteLine("No departments found.");
                return;
            }

            foreach (var dept in departments)
            {
                Console.WriteLine($"ID: {dept.ID} | Name: {dept.Name}");
            }
        }

        static void AddDepartment()
        {
            Console.Write("Enter Department Name: ");
            string name = Console.ReadLine();

            int newId = departments.Count == 0 ? 1 : departments.Max(d => d.ID) + 1;

            departments.Add(new Department { ID = newId, Name = name });
            Console.WriteLine("Department added successfully.");
        }

        static void EditDepartment()
        {
            Console.Write("Enter Department ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            var dept = departments.FirstOrDefault(d => d.ID == id);
            if (dept == null)
            {
                Console.WriteLine("Department not found.");
                return;
            }

            Console.Write($"Enter new Name (current: {dept.Name}): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                dept.Name = name;

            Console.WriteLine("Department updated successfully.");
        }

        static void DeleteDepartment()
        {
            Console.Write("Enter Department ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var dept = departments.FirstOrDefault(d => d.ID == id);
            if (dept == null)
            {
                Console.WriteLine("Department not found.");
                return;
            }

            bool hasEmployees = employees.Any(e => e.DepartmentID == id);
            if (hasEmployees)
            {
                Console.WriteLine("Cannot delete department, it still has employees assigned to it.");
                return;
            }

            departments.Remove(dept);
            Console.WriteLine("Department deleted successfully.");
        }
    }
}
