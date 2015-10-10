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
            // Problem 2. Students By Group
            var studentsByGroup = Student.list
                .Where(s => s.GroupNumber == 1)
                .OrderBy(s => s.FirstName)
                .Select(s => s);

            Console.WriteLine("Students By Group - Sorted");
            foreach (var student in studentsByGroup)
            {
                Console.WriteLine("Group {0}: {1} {2}", student.GroupNumber, student.FirstName, student.LastName);
            }
        }
    }
}
