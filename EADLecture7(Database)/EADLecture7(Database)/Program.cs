using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace EADLecture7_Database_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter user name: ");
            String u = Console.ReadLine();
            Console.Write("Enter password: ");
            String p = Console.ReadLine();

            String ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EMS_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            //SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmd= con.CreateCommand();
            cmd.Connection= con;
            
            con.Open();
            //String query = "INSERT INTO tbUsers (username, password) VALUES('abc','123')"; // hardcodded values
            String query = $"INSERT INTO tbUsers (UserName, Password) VALUES('{u}','{p}')"; // take values from user
            //String query = $"UPDATE tbUsers SET password = '{p}' WHERE username = '{u}'";
            //String query = $"DELETE FROM tbUsers WHERE username = '{u}'";
            //String query = "select COUNT(*) from tbUsers";
            //String query = "select SUM(*) from tbUsers";
            //String query = $"select * from tbUsers where username = '{u}' and password = '{p}'";     //1' OR 1=1 -- (SQL injection)
            // ' closes the query and 1=1 gives a true condition  -- means comment    
            //String query = "Select * from tbUsers where username = @un and password = @pd";
            cmd.CommandText= query;
            SqlParameter p1 = new SqlParameter("un", u);
            //SqlParameter p2 = new SqlParameter("pd", p);
            //cmd.Parameters.Add(p1);
            //cmd.Parameters.Add(p2);
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.HasRows)
            //{
            //    Console.WriteLine("User authenticated!!!");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid username or password!!!");
            //}
            //while (dr.Read())
            //{
            //    Console.WriteLine($"ID = {dr[0]}");
            //    Console.WriteLine($"Name = {dr[1]}");
            //    Console.WriteLine($"Salary = {dr[2]}");
            //    Console.WriteLine($"Tax = {dr[3]}");
            //    Console.WriteLine("--------------------");
            //}
            int count = cmd.ExecuteNonQuery();
            //var count = cmd.ExecuteScalar();
            Console.WriteLine($"Count: {count}");
            con.Close();
            Console.ReadKey();
            //Docker desktop isntallation
            //Almost all companies use it for backend infrastructure
            //Containerize applications : contains application, libraries, runtime env, etc which is portable
            
        }
    }
}
