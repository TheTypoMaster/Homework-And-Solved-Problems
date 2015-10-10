using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalHomework
{
    public static class Program
    {
        public static bool FindExactlyTwoMatches (this List<int> list)
        {
            bool exactlyTwo = false;
            int counter = 0;

            foreach (var item in list)
            {
                if (item == 2)
                {
                    counter++;
                }
            }
            if (counter == 2)
            {
                exactlyTwo = true;
            }
            return exactlyTwo;
        }

        public static void Main()
        {
            var weakStudents = Student.list
                .Where(student => FindExactlyTwoMatches(student.Marks))
                .Select(student => new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks});

            foreach (var student in weakStudents)
	        {
		        Console.WriteLine("{0}; Marks -> {1}", student.FullName, string.Join(" ", student.Marks));
	        }
            
        }
    }
}
