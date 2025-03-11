using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentIntrestTask
{
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AreaOfInterest { get; set; }

        public int GetAge()
        {
            DateTime now = DateTime.Today;
            int age = now.Year - DateOfBirth.Year;
            if (DateOfBirth > now.AddYears(-age)) age--;
            return age;
        }
    }

    public class Program
    {

        public static void DisplayStudents(List<Student> studentList, string area)
        {
            if (studentList.Count > 0)
            {
                Console.WriteLine($"\nStudents interested in {area}:");
                foreach (Student student in studentList)
                {
                    Console.WriteLine($"\nName: {student.Name}");
                    Console.WriteLine($"Address: {student.Address}");
                    Console.WriteLine($"Age: {student.GetAge()}");
                }
            }
            else
            {
                Console.WriteLine($"\nNo students interested in {area}.");
            }
        }


        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Enter student details");
                Console.WriteLine("0. Exit and display student details");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    break;
                }
                else if (choice == "1")
                {
                    Student student = new Student();

                    Console.WriteLine("\nEnter student details:");

                    Console.Write("Name: ");
                    student.Name = Console.ReadLine();

                    Console.Write("Address: ");
                    student.Address = Console.ReadLine();

                    DateTime dob;
                    bool validDob = false;

                    while (!validDob)
                    {
                        Console.Write("Date of Birth (yyyy-MM-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out dob))
                        {
                            student.DateOfBirth = dob;
                            validDob = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
                        }
                    }

                    bool validArea = false;
                    while (!validArea)
                    {
                        Console.Write("Area of Interest (Science, Maths, Arts): ");
                        string area = Console.ReadLine().ToLower();

                        if (area == "science" || area == "maths" || area == "arts")
                        {
                            student.AreaOfInterest = area;
                            validArea = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid area of interest. Please enter Science, Maths, or Arts.");
                        }
                    }

                    students.Add(student);
                    Console.WriteLine("\nStudent added!");
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }

            if (students.Count > 0)
            {
                Console.WriteLine("\nStudent Details by Area of Interest:");

                List<Student> scienceStudents = students.FindAll(st => st.AreaOfInterest == "science");
                List<Student> mathsStudents = students.FindAll(st => st.AreaOfInterest == "maths");
                List<Student> artsStudents = students.FindAll(st => st.AreaOfInterest == "arts");

                DisplayStudents(scienceStudents, "Science");
                DisplayStudents(mathsStudents, "Maths");
                DisplayStudents(artsStudents, "Arts");
            }
            else
            {
                Console.WriteLine("\nNo students were entered.");
            }

            Console.WriteLine("Exiting program.");
        }

        
    }
}
