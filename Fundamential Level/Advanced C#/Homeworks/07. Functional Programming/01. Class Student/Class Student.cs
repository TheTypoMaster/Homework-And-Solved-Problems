using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalHomework
{
    public class Student
    {
        public Student(
        string firstName,
        string lastName,
        int age,
        string facultyNumber,
        string phone,
        string email,
        List<int> marks,
        int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string FacultyNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public int GroupNumber { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0} {1} student)",
                this.FirstName,
                this.LastName);
        }

        public static List<Student> list = new List<Student>()
        {
            new Student ("Craig", "Cole", 20, "1234514", "0895456789", "cc@abv.bg", new List<int>() {2, 3, 4, 2}, 2),
            new Student ("Ann", "Make", 32, "1234514", "+3592112233", "am@hotmail.com", new List<int>() {6, 6, 6, 6}, 1),
            new Student ("Susann", "Michael", 20, "1234513", "0895456782", "sm@abv.bg", new List<int>() {3, 4, 4, 6}, 1),
            new Student ("Peter", "Smith", 16, "1234513", "0895456783", "ps@hotmailc.com", new List<int>() {2, 3, 2, 3}, 2),
            new Student ("Jacob", "Loe", 20, "1234514", "0895456784", "jl@gmail.com", new List<int>() {2, 6, 4, 3}, 2),
            new Student ("Yi-Yam", "Koey", 22, "1234515", "0895456785", "yk@yahoo.com", new List<int>() {2, 6, 4, 5}, 1),
            new Student ("Frank", "Miller", 23, "1234515", "02355222", "fm@abv.bg", new List<int>() {5, 3, 4, 6}, 2),
        };
    }
    public class Program
    {
        public static void Main()
        {

        }
    }
}
