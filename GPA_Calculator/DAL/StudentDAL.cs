using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.SqlServer;
using System.Data.SqlClient;

namespace DAL
{
    public class StudentDAL
    {
        public void SaveStudent(StudentDTO dto)
        {
            String ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GPA_CALCULATOR;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            String query1 = "DELETE FROM Student";
            String query2 = $"insert into Student (ID, Name, Subject, Grade) values ('{dto.StudentID}','{dto.Name}','{dto.Subject}','{dto.Grade}')";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = query1;
            cmd.Connection = con;
            con.Open();
            int count = cmd.ExecuteNonQuery();
            Console.WriteLine(count);
            cmd.CommandText = query2;
            count= cmd.ExecuteNonQuery();
            Console.WriteLine(count);
            con.Close();
        }

        public StudentDTO getStudent()
        {
            String ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GPA_CALCULATOR;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            String query = "select * from Student";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            string id = "", name = "", subject = "", grade = "";
            SqlDataReader rd = cmd.ExecuteReader();
            StudentDTO student = new StudentDTO();
            if (rd.Read())
            {
                id = rd[0].ToString();
                name = rd[1].ToString();
                subject = rd[2].ToString();
                grade = ((String)rd[3]);
            }
            student.StudentID = id;
            student.Name = name;
            student.Subject = subject;
            student.Grade = grade;
            Console.WriteLine($"Grade: {student.Grade}");
            con.Close();

            return student;
        }
    }
}
