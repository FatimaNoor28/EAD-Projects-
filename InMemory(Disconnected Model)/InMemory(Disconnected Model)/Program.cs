using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace InMemory_Disconnected_Model_
{
    internal class Program
    {
        static void Main()
        {
            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EMS_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            string Query = "SELECT * FROM tbUsers";
            SqlCommand cmd = new SqlCommand(Query, con);
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[1] };
            Console.WriteLine("ID: \t Name: \t\t\t Password: ");
            foreach(DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row[0]} \t {row[1]} \t {row[2]}");
            }

            Random rd = new Random();
            string nm, pwd;
            // insert into table
            Console.Write("Enter Name to enter to table: ");
            nm = Console.ReadLine();
            Console.Write("Enter Password: ");
            pwd = Console.ReadLine();
            DataRow row1 = dataTable.NewRow();
            row1[0] = rd.Next(100, 500);
            row1[1] = nm;
            row1[2] = pwd;
            dataTable.Rows.Add(row1);
            string query1 = "insert into tbUsers(UserName, Password) Values(@n, @p)";
            SqlParameter p1 = new SqlParameter("n", SqlDbType.NChar, 20, "UserName");
            SqlParameter p2 = new SqlParameter("p", SqlDbType.NChar, 20, "Password");
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.Add(p1);
            cmd1.Parameters.Add(p2);
            dataAdapter.InsertCommand = cmd1;
            dataAdapter.Update(dataTable);


            // update row from table

            Console.Write("Enter Name to update: ");
            nm = Console.ReadLine().Replace("  ", String.Empty);
            DataRow row2 = dataTable.Rows.Find(nm);
            Console.Write("Enter new Password: ");
            row2["Password"] = Console.ReadLine();
            /*foreach(DataRow r in dataTable.Rows)
            { 
                if (r[1].ToString().Replace("  ", String.Empty) == nm)
                {
                    Console.Write("Enter new Password: ");
                    pwd = Console.ReadLine();
                    r["Password"] = pwd;
                    break;
                }
            }*/
            string query2 = "update tbUsers Set Password = @p Where UserName = @n";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlParameter p3 = new SqlParameter("p", SqlDbType.NChar, 20, "Password");
            SqlParameter p4 = new SqlParameter("n", SqlDbType.NChar, 20, "UserName");
            cmd2.Parameters.Add(p3);
            cmd2.Parameters.Add(p4);
            dataAdapter.UpdateCommand = cmd2;
            dataAdapter.Update(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row[0]} \t {row[1]} \t {row[2]}");
            }


            //delete
            Console.WriteLine("Enter UserName of record u want to delete: ");
            nm =Console.ReadLine();
            DataRow row3 = dataTable.Rows.Find(nm);
            row3.Delete();
            string query3 = "delete from tbUsers where UserName = @n";
            SqlCommand cmd3 = new SqlCommand(query3, con);
            SqlParameter p5 = new SqlParameter("n", SqlDbType.NChar, 20, "UserName");
            cmd3.Parameters.Add(p5);
            dataAdapter.DeleteCommand = cmd3;
            dataAdapter.Update(dataTable);

            con.Close();
        }
    }
}
