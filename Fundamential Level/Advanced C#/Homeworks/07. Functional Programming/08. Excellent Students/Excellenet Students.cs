using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalHomework
{
    class Program
    {
        static void Main()
        {
            var excellent = Student.list
                .Where(student => student.Marks.Find(x => x == 6) == 6)
                .Select(student => new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks });

            foreach (var student in excellent)
            {
                Console.WriteLine("{0}; Marks -> {1}", student.FullName, string.Join(" ", student.Marks));
            }
        }
    }
}
