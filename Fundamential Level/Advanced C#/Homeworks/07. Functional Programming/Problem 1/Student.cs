using System;
using System.Collections.Generic;

namespace Functional
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
    }
}
