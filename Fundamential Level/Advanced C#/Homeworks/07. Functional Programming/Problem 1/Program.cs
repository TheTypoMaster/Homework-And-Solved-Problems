using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    class Program
    {
        public static List<Student> students = new List<Student>()
        {
            new Student ("Craig", "Cole", 20, "123", "0895456789", "cc@abv.bg", new List<int>() {2, 3, 4, 3}, 2),
            new Student ("Ann", "Make", 20, "345", "0895456781", "am@hotmail.com", new List<int>() {6, 6, 6, 6}, 1),
            new Student ("Susann", "Michael", 20, "211", "0895456782", "sm@abv.bg", new List<int>() {3, 4, 4, 6}, 1),
            new Student ("Peter", "Smith", 20, "345", "0895456783", "ps@hotmailc.com", new List<int>() {2, 3, 4, 3}, 2),
            new Student ("Jacob", "Loe", 20, "123", "0895456784", "jl@gmail.com", new List<int>() {2, 6, 4, 3}, 2),
            new Student ("Yi-Yam", "Koey", 20, "121", "0895456785", "yk@yahoo.com", new List<int>() {2, 6, 4, 5}, 1),
            new Student ("Frank", "Miller", 20, "234", "0895456786", "fm@abv.bg", new List<int>() {5, 3, 4, 6}, 2),
        };

        public static void Main(string[] args)
        {
            // Problem 1. Students By Group
            var studentsByGroup = students
                .Where(s => s.GroupNumber == 1)
                .OrderBy(s => s.FirstName)
                .Select(s => s);

            foreach (var student in students)
            {
                Console.WriteLine("Group {0}: {1} {2}", student.FirstName, student.LastName);
            }
        }
    }
}
