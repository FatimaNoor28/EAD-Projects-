using System;
using DTO;
using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class StudentView
    {
        public void InputStudent()
        {
            Console.Write("Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            String name = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Roll Number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            String rollNo = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Subject Title: ");
            Console.ForegroundColor = ConsoleColor.Green;
            String title = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Marks: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int marks = int.Parse(Console.ReadLine());
            Console.ResetColor();

            StudentDTO student = new StudentDTO()
            {
                Name = name,
                StudentID = rollNo,
                Subject = title,
            };
            StudentBLL bll = new StudentBLL();
            bll.AddStudent(student, marks);
            //Console.WriteLine("Record added");
        }

        public void ShowStudent()
        {
            StudentBLL bll = new StudentBLL();
            StudentDTO dto = bll.GetStudent();
            double gpa = bll.CalculateGPA(dto.Grade);
            if (dto == null)
            {
                Console.WriteLine("File is empty or does not exist.");
                return;
            }
            Console.Write($"Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{dto.Name}");
            Console.ResetColor();
            Console.Write($"Roll Number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{dto.StudentID}");
            Console.ResetColor();
            Console.Write($"Subject Title: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{dto.Subject}");
            Console.ResetColor();
            Console.Write($"GPA: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{gpa:0.00}");
            Console.ResetColor();
        }
    }
}
