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
            // Domain of email "abv.bg"
            var specificDomain = Student.list
                .Where(s => s.Email.Substring(s.Email.LastIndexOf('@'), s.Email.Length - s.Email.LastIndexOf('@')) == "@abv.bg")
                .Select(s => s);

            foreach (var student in specificDomain)
            {
                Console.WriteLine("{0} {1} -> Domain: {2}", student.FirstName, student.LastName, student.Email);
            }
        }
    }
}
