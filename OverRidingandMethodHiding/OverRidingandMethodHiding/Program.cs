using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverRidingandMethodHiding
{
    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Designation { get; set; }

       
        public Employee(string name, int salary, string designation)
        {
            Name = name;
            Salary = salary;
            Designation = designation;
        }

       
        public virtual void SalaryPrint()
        {
            Console.WriteLine("Base Employee Bonus");
        }
    }

    class Manager : Employee
    {
       
        public Manager(string name, int salary, string designation)
            : base(name, salary, designation)
        {
        }

        
        public override void SalaryPrint()
        {
            float tr = Salary * (20.0f / 100.0f); 
            if (50000 > tr)
            {
                Console.WriteLine("Bonus : 50000");
            }
            else
            {
                Console.WriteLine("Bonus : {0}", tr); 
            }
        }
    }

    class Admin : Employee
    {
       
        public Admin(string name, int salary, string designation)
            : base(name, salary, designation)
        {
        }

        
        public override void SalaryPrint()
        {
            Console.WriteLine("Bonus : 50000");
        }
    }

    class Developer : Employee
    {
       
        public Developer(string name, int salary, string designation)
            : base(name, salary, designation)
        {
        }

        
        public override void SalaryPrint()
        {
            float tr = Salary * (25.0f / 100.0f); 
            if (50000 > tr)
            {
                Console.WriteLine("Bonus : 50000");
            }
            else
            {
                Console.WriteLine("Bonus : {0}", tr); 
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Developer d1 = new Developer("Ram", 500000, "Developer");
            d1.SalaryPrint(); 

            Manager m1 = new Manager("XYZ", 1500000, "Manager");
            m1.SalaryPrint();

            Admin a1 = new Admin("ABC", 100000, "Admin");
            a1.SalaryPrint();

            Console.ReadLine(); 
        }
    }
}