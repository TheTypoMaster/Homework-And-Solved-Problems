using System;
using System.Collections.Generic;
using System.Linq;

namespace University
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>() 
            {
                new Student ("215314", "Milena Kirova"),
                new Student ("203114", "Stefan Popov"),
                new Student ("203314", "Asya Manova"),
                new Student ("203914", "Diana Petrova"),
                new Student ("203814", "Ivan Ivanov"),
            };

            List<Specialty> specialties = new List<Specialty>() 
            {
                new Specialty ("Web Developer", "203314"),
                new Specialty ("Web Developer", "203114"),
                new Specialty ("PHP Developer", "203814"),
                new Specialty ("PHP Developer", "203914"),
                new Specialty ("QA Engineer", "203314"),
                new Specialty ("Web Developer", "203914"),
            };

            var joined =
                from student in students
                join specialty in specialties
                    on student.FacNum equals specialty.FacNum
                select new { Name = student.Name, FacNum = student.FacNum, Spec = specialty.SpecialtyName };

            var ordered =
                from student in joined
                orderby student.Name
                select student;

            foreach (var student in ordered)
            {
                Console.WriteLine("{0} {1} {2}", student.Name, student.FacNum, student.Spec);
            }
        }
    }

}
