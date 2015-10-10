using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FunctionalHomework
{
    class Program
    {
        static void Main()
        {
            Regex rgx = new Regex(@"[\d]{4}14");
            string test = "123415";

            var enrolledLastYear = Student.list
                .Where(student => rgx.Match(student.FacultyNumber).Success)
                .Select(student => student);

            foreach (var student in enrolledLastYear)
            {
                Console.WriteLine("{0} {1}; Faculty Number: {2}", student.FirstName, student.LastName, student.FacultyNumber);
            }
        }
    }
}
