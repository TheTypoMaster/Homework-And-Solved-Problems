using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Student
    {
        public Student(string facNumber, string name)
        {
            this.FacNum = facNumber;
            this.Name = name;
        }

        public string FacNum
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class Specialty
    {
        public Specialty (string specialtyName, string facNum)
        {
            this.SpecialtyName = specialtyName;
            this.FacNum = facNum;
        }

        public string SpecialtyName
        {
            get;
            set;
        }

        public string FacNum
        {
            get;
            set;
        }

    }
}
