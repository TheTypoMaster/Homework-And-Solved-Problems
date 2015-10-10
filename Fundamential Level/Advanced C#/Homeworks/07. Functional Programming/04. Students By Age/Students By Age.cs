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
            Console.WriteLine("Students By Age - Between 18 and 24"); // Extract only the students between age 18 and 24
            var studentsByAge = Student.list
                .Where(s => s.Age >= 18 && s.Age <= 24)
                .Select(s => new { FirstName = s.FirstName, LastName = s.LastName, Age = s.Age });

            foreach (var student in studentsByAge)
            {
                Console.WriteLine("{0} {1} -> Age: {2}", student.FirstName, student.LastName, student.Age);
            }
        }
    }
}
