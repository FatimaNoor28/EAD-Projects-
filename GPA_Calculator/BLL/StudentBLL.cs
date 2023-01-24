using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class StudentBLL
    {
        public void AddStudent(StudentDTO dto, int marks)
        {
            dto.Grade = CalculateGrade(marks);
            StudentDAL dal = new StudentDAL();
            dal.SaveStudent(dto);
        }
        public double? CalculateGPA(String grade)
        {
            if (grade == null || grade.Length == 0)
                return null;
            double gpa = 9.9;
            grade = grade.Replace(" ", string.Empty);
            if (grade == "F")
                gpa = 0.0;
            else if (grade.Equals("D"))
                gpa = 1.00;
            else if (grade.Equals("C-"))
                gpa = 1.70;
            else if (grade.Equals("C"))
                gpa = 2.00;
            else if (grade.Equals("C+"))
                gpa = 2.30;
            else if (grade.Equals("B-"))
                gpa = 2.70;
            else if (grade.Equals("B"))
                gpa = 3.00;
            else if (grade.Equals("B+"))
                gpa = 3.30;
            else if (grade.Equals("A-"))
                gpa = 3.70;
            else if (grade.Equals("A"))
                gpa = 4.00;
            return gpa;
        }


        public String CalculateGrade(int marks)
        {
            String grade;
            if (marks >= 0 && marks < 50)
                grade = "F";
            else if (marks >= 50 && marks < 55)
                grade = "D";
            else if (marks >= 55 && marks < 58)
                grade = "C-";
            else if (marks >= 58 && marks < 61)
                grade = "C";
            else if (marks >= 61 && marks < 65)
                grade = "C+";
            else if (marks >= 65 && marks < 70)
                grade = "B-";
            else if (marks >= 70 && marks < 75)
                grade = "B";
            else if (marks >= 75 && marks < 80)
                grade = "B+";
            else if (marks >= 80 && marks < 85)
                grade = "A-";
            else
                grade = "A";
            return grade;
        }

        public StudentDTO GetStudent()
        {
            StudentDAL dal = new StudentDAL();
            StudentDTO student = dal.getStudent();
            if (student == null)
            {
                Console.WriteLine("DB is empty or does not exist.");
                return null;
            }
            return student;
        }
    }
}