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
            // Reference:
            // string telephone = "3650+359";

            Regex rgx = new Regex(@"^(?:0|\+359)2");

            var phonesInSofia =
                from student in Student.list
                where rgx.Match(student.Phone).Success
                select student;

            foreach (var student in phonesInSofia)
            {
                Console.WriteLine("{0} {1} -> Phone: {2}", student.FirstName, student.LastName, student.Phone);
            }
        }
    }
}
