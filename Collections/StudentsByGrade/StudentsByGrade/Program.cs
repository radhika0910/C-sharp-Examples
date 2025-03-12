using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsByGrade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByGrade
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> studentGrades = new Dictionary<string, string>
        {
            { "Alice", "A" },
            { "Bob", "B" },
            { "Charlie", "A" },
            { "David", "C" },
            { "Eve", "B" },
            { "Frank", "A" },
            { "Grace", "C" },
            { "Henry", "B" }
        };

            // 1. Group students by their grades.
            var studentsByGrade = studentGrades
                .GroupBy(kvp => kvp.Value)
                .ToDictionary(group => group.Key, group => group.Select(kvp => kvp.Key).ToList());

            // 2. Display the grade along with the list of students.
            Console.WriteLine("Students grouped by grades:");
            foreach (var gradeGroup in studentsByGrade)
            {
                Console.WriteLine($"Grade: {gradeGroup.Key}");
                Console.WriteLine($"Students: {string.Join(", ", gradeGroup.Value)}");
            }

            Console.ReadKey();
        }
    }
}
