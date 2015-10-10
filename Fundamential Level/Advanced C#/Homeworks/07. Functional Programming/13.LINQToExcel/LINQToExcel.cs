using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace LINQToExcel
{
    class LINQToExcel
    {
        static void Main()
        {
            string studentsDataPath = "../../Students-data.txt";
            DirectoryInfo outputDir = new DirectoryInfo("../../");
            FileInfo newFile = new FileInfo(outputDir.FullName + @"Students-data-excel.xlsx");
            List<Student> studentsData = new List<Student>();

            using (var reader = new StreamReader(studentsDataPath))
            {
                string line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    string[] tokens = line.Split(new char[] { });
                    Student newStudent = new Student(
                        tokens[0], // ID
                        tokens[1], // first name
                        tokens[2], // last name
                        tokens[3], // email
                        tokens[4], // gender
                        tokens[5], // student type
                        int.Parse(tokens[6]), // exam result
                        int.Parse(tokens[7]), // homeworks sent
                        int.Parse(tokens[8]), // homeworks evaluated
                        double.Parse(tokens[9]), // teamwork score
                        int.Parse(tokens[10]), // attendence count
                        double.Parse(tokens[11]) // bouns
                        );
                    newStudent.CalculateResult();
                    studentsData.Add(newStudent);
                    line = reader.ReadLine();
                }
            }

            var onlineOrdered = studentsData
                .Where(s => s.StudentType == "Online")
                .OrderByDescending(s => s.Result);

            // make sure that we create a new file
            bool proceed = false;
            int newFileNumber = 0;
            while (!proceed)
            {
                if (newFile.Exists)
                {
                    newFile.Delete();  // ensures we create a new workbook
                    newFile = new FileInfo(outputDir.FullName + @"Students-data-excel(" + newFileNumber + ").xlsx");
                    newFileNumber++;
                }
                else
                {
                    proceed = true;
                }
            }

            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("orderedResults");

                // add the headers
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "First Name";
                worksheet.Cells[1, 3].Value = "Last Name";
                worksheet.Cells[1, 4].Value = "Email";
                worksheet.Cells[1, 5].Value = "Gender";
                worksheet.Cells[1, 6].Value = "Student Type";
                worksheet.Cells[1, 7].Value = "Exam Result";
                worksheet.Cells[1, 8].Value = "Homeworks Sent";
                worksheet.Cells[1, 9].Value = "Homeworks Evaluated";
                worksheet.Cells[1, 10].Value = "Teamwork Score";
                worksheet.Cells[1, 11].Value = "Attendence Count";
                worksheet.Cells[1, 12].Value = "Bonus";
                worksheet.Cells[1, 13].Value = "Result";

                int row = 2;
                foreach (var student in onlineOrdered)
	            {
                    worksheet.Cells[row, 1].Value = student.Id;
                    worksheet.Cells[row, 2].Value = student.FirstName;
                    worksheet.Cells[row, 3].Value = student.LastName;
                    worksheet.Cells[row, 4].Value = student.Email;
                    worksheet.Cells[row, 5].Value = student.Gender;
                    worksheet.Cells[row, 6].Value = student.StudentType;
                    worksheet.Cells[row, 7].Value = student.ExamResult;
                    worksheet.Cells[row, 8].Value = student.HomeworkSent;
                    worksheet.Cells[row, 9].Value = student.HomeworkEvaluated;
                    worksheet.Cells[row, 10].Value = student.TeamworkScore;
                    worksheet.Cells[row, 11].Value = student.AttendencesCount;
                    worksheet.Cells[row, 12].Value = student.Bonus;
                    worksheet.Cells[row, 13].Value = student.Result;
                    row++;
	            }
                package.Save();
            }

            Console.WriteLine("File created: {0}", newFile.FullName);
        }
    }
}
