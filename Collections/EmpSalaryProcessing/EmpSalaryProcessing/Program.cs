using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpSalaryProcessing
{
 

    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, string department, decimal salary)
        {
            Name = name;
            Department = department;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Department: {Department}, Salary: {Salary:C}";
        }
    }

    public class EmployeeSalaryProcessing
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee("Alice", "HR", 60000),
            new Employee("Bob", "IT", 45000),
            new Employee("Charlie", "Finance", 75000),
            new Employee("David", "IT", 55000),
            new Employee("Eve", "HR", 48000),
            new Employee("Frank", "Finance", 80000)
        };

           
            var filteredEmployees = employees.Where(e => e.Salary > 50000);

            
            var sortedEmployees = filteredEmployees.OrderByDescending(e => e.Salary);

            
            var result = sortedEmployees.Select(e => new { e.Name, e.Salary });

            Console.WriteLine("Employees earning more than 50,000 (sorted by salary descending):");
            foreach (var employee in result)
            {
                Console.WriteLine($"Name: {employee.Name}, Salary: {employee.Salary:C}");
            }

            Console.ReadKey();
        }
    }
}
