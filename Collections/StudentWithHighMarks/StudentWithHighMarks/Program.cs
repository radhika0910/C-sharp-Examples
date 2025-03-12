using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWithHighMarks
{
      public class Student
    {
        public string Name { get; set; }
        public int Marks { get; set; }

        public Student(string name, int marks)
        {
            Name = name;
            Marks = marks;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Marks: {Marks}";
        }
    }

    public class HighMarksStudents
    {
        public static void Main(stringargs)
        {
            List<Student> students = new List<Student>
        {
            new Student("Alice", 80),
            new Student("Bob", 70),
            new Student("Charlie", 90),
            new Student("David", 65),
            new Student("Eve", 85),
            new Student("Frank", 92),
            new Student("Grace", 78),
            new Student("Henry", 95),
            new Student("Ivy", 88),
            new Student("Jack", 82),
            new Student("Kelly", 91),
            new Student("Liam", 76),

        };

            // 1. Filter students who scored above 75 marks.
            var highScorers = students.Where(s => s.Marks > 75);

            // 2. Sort them in descending order of marks.
            var sortedHighScorers = highScorers.OrderByDescending(s => s.Marks);

            // 3. Display only top 5 students.
            var top5Students = sortedHighScorers.Take(5);

            Console.WriteLine("Top 5 students with marks above 75:");
            foreach (var student in top5Students)
            {
                Console.WriteLine($"Name: {student.Name}, Marks: {student.Marks}");
            }

            Console.ReadKey();
        }
    }
}
