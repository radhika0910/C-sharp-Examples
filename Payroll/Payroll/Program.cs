using System;

namespace Payroll
{
    // Abstract class
    public abstract class Employee
    {
        public string Name { get; set; }
        public abstract decimal CalculateSalary();
    }

    // Full-time employee class
    public class FullTimeEmployee : Employee
    {
        public decimal MonthlySalary { get; set; }

        public FullTimeEmployee(string name, decimal monthlySalary)
        {
            Name = name;
            MonthlySalary = monthlySalary;
        }

        public override decimal CalculateSalary()
        {
            return MonthlySalary;
        }
    }

    // Contract employee class
    public class ContractEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public ContractEmployee(string name, decimal hourlyRate, int hoursWorked)
        {
            Name = name;
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public override decimal CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a full-time employee
            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee("Alice", 3000);
            Console.WriteLine($"Full-Time Employee: {fullTimeEmployee.Name}, Salary: {fullTimeEmployee.CalculateSalary()}");

            // Create a contract employee
            ContractEmployee contractEmployee = new ContractEmployee("Bob", 20, 160);
            Console.WriteLine($"Contract Employee: {contractEmployee.Name}, Salary: {contractEmployee.CalculateSalary()}");
        }
    }
}