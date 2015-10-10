using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalHomework
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("LINQ Method Style"); // Sort by first and last name using LINQ extension methods
            var sortedStudents = Student.list
                .OrderBy(s => s.FirstName)
                .ThenBy(s => s.LastName)
                .Select(s => s);

            foreach (var student in sortedStudents)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine();

            Console.WriteLine("LINQ Query syntax"); // Sort by first and last name using LINQ Query syntax
            var sortedStudents2 =
                from student in Student.list
                orderby student.FirstName, student.LastName
                select student;

            foreach (var student in sortedStudents2)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
                
        }
    }
}
