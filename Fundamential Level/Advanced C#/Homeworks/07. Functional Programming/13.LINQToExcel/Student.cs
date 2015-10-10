using System;

namespace LINQToExcel
{
    public class Student
    {
        public Student(
            string id,
            string firstName,
            string lastName,
            string email,
            string gender,
            string studentType,
            int examResult,
            int homeworkSent,
            int homeworkEvaluated,
            double teamworkScore,
            int attendencesCount,
            double bonus)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Gender = gender;
            this.StudentType = studentType;
            this.ExamResult = examResult;
            this.HomeworkSent = homeworkSent;
            this.HomeworkEvaluated = homeworkEvaluated;
            this.TeamworkScore = teamworkScore;
            this.AttendencesCount = attendencesCount;
            this.Bonus = bonus;
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string StudentType { get; set; }
        public int ExamResult { get; set; }
        public int HomeworkSent { get; set; }
        public int HomeworkEvaluated { get; set; }
        public double TeamworkScore { get; set; }
        public int AttendencesCount { get; set; }
        public double Bonus { get; set; }
        public double Result { get; set; }

        public void CalculateResult()
        {
            this.Result = (this.ExamResult + this.HomeworkSent + this.HomeworkEvaluated + this.TeamworkScore + this.AttendencesCount + this.Bonus) / 5;
        }
    }
}
