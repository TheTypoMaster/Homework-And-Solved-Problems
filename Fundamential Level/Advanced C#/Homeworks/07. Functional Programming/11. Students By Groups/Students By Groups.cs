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
            // Using LINQ extension Methods
            var groups = Student.list
                .GroupBy(s => s.GroupNumber)
                .OrderBy(s => s.Key);

            foreach (var group in groups)
            {
                Console.WriteLine("\nGroup name {0}", group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine("{0}{1}", item.FirstName, item.LastName);
                }
            }

            // Using LINQ query syntax
            Console.WriteLine();
            var groups2 =
                from student in Student.list
                group student by student.GroupNumber into groupNumber
                select new { GroupNumber = groupNumber.Key, Students = groupNumber };

            foreach (var group in groups2)
            {
                Console.WriteLine("Group name: {0}", group.GroupNumber);
                foreach (var item in group.Students)
                {
                    Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
                }
            }
        }
    }
}
