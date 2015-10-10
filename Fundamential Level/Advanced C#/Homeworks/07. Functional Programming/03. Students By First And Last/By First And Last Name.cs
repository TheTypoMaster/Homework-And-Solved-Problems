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
            // Problem 3. Students By First Name and Last Name

            var byFirstAndLast = Student.list
                .Where(s => s.FirstName.CompareTo(s.LastName) == -1)
                .Select(s => s);

            Console.WriteLine("Students By First Name and Last Name - Sorted");
            foreach (var student in byFirstAndLast)
            {
                Console.WriteLine("The students first name [{0}] is before his/her last name [{1}] alphabetically", student.FirstName, student.LastName);
            }
        }
    }
}
