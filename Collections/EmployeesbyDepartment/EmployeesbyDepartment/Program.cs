using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesbyDepartment
{
   

    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }

        public Employee(string name, string department)
        {
            Name = name;
            Department = department;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Department: {Department}";
        }
    }

    public class EmployeesByDepartment
    {
        public static void Main(string[] args)
        {
            Hashtable employeeTable = new Hashtable
        {
            { 1, new Employee("Alice", "HR") },
            { 2, new Employee("Bob", "IT") },
            { 3, new Employee("Charlie", "HR") },
            { 4, new Employee("David", "Finance") },
            { 5, new Employee("Eve", "IT") },
            { 6, new Employee("Frank", "HR") },
            { 7, new Employee("Grace", "Finance") }
        };

            Console.Write("Enter the department to search for: ");
            string searchDepartment = Console.ReadLine();

            // 1. Find all employees in a specific department.
            List<Employee> employeesInDepartment = new List<Employee>();
            foreach (Employee employee in employeeTable.Values)
            {
                if (employee.Department.Equals(searchDepartment, StringComparison.OrdinalIgnoreCase))
                {
                    employeesInDepartment.Add(employee);
                }
            }

            // 2. Display them in alphabetical order.
            var sortedEmployees = employeesInDepartment.OrderBy(e => e.Name);

            Console.WriteLine($"Employees in the {searchDepartment} department:");
            foreach (Employee employee in sortedEmployees)
            {
                Console.WriteLine(employee);
            }

            Console.ReadKey();
        }
    }
}
