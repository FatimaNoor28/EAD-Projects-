using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Database_sql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Student's Name: ");
            String name = Console.ReadLine();
            //Console.WriteLine("En");
            String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Class_Management_System;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            //SqlCommand cmd = con.CreateCommand();
            String query = "select * from Student";
            //cmd.Connection = con;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.CommandText= query;
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Console.WriteLine($"ID: {dr[0]}");
                Console.WriteLine($"Name: {dr[1]}");
                Console.WriteLine($"Class: {dr[2]}");
                Console.WriteLine($"Section: {dr[3]}");
                Console.WriteLine($"CGPA: {dr[4]}");
            }
            con.Close();
            Console.ReadKey();

        }
    }
}
