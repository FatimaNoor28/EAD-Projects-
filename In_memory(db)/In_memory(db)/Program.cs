using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace In_memory_db_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EMS_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            String query = "select * from tbUsers";
            SqlCommand cmd1 = new SqlCommand(query, con);
            //cmd1.ExecuteNonQuery();
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dataTable= new DataTable();
            sd.SelectCommand= cmd1;
            sd.Fill(dataTable);
            foreach(DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"Id: {row[0]}");
                Console.WriteLine($"Name: {row[1]}");
                Console.WriteLine($"Password: {row[2]}");
            }

            //now insert data into tbUsers by creating a row of type DataRow
            //add it to dataTable then update tbUsers
            //DataRow newRow = dataTable.NewRow();
            //newRow["Id"] = 28;
            //newRow["UserName"] = "Fatima Shahid";
            //newRow["Password"] = "Blah blah";
            //dataTable.Rows.Add(newRow);
            //query to insert into tbUsers
            //string query1 = "Insert into tbUsers(UserName, Password) Values(@u, @p)";
            //SqlCommand insertCmd = new SqlCommand(query1, con);
            //SqlParameter p1 = new SqlParameter("u", SqlDbType.NChar, 20, "UserName");
            //SqlParameter p2 = new SqlParameter("p", SqlDbType.NChar, 10, "Password");
            //insertCmd.Parameters.Add(p1);
            //insertCmd.Parameters.Add(p2);
            //sd.InsertCommand = insertCmd;
            //sd.Update(dataTable);
            

            //Delete data from data table
            //Console.Write("Enter username to be deleted: ");
            string u = "blah";
            DataRow[] row1 = dataTable.Select($"UserName = '{u}'");
            
            //row1["UserName"] = "Fatima Shahid";
            String query2 = $"Delete from tbUsers where UserName = {u}";
            SqlCommand deleteCmd = new SqlCommand();
            deleteCmd.Connection= con;
            deleteCmd.CommandText= query2;
            SqlParameter p = new SqlParameter("u", SqlDbType.NVarChar, 10, "Password");
            deleteCmd.Parameters.Add(p);
            sd.DeleteCommand = deleteCmd;

            foreach(DataRow r in row1)
            { 
                r.Delete();
            }
            sd.Update(dataTable);

            //Update a record
            //String un = "Fatima";
            //String pwd = "blah";
            //string name1 = "Fatima Shahid";
            //String query3 = $"Update tbUsers set UserName = @un, Password = @pwd where UserName = {name1}";
            //SqlCommand updatecmd = new SqlCommand(query3, con);
            //SqlParameter p3 = new SqlParameter("un", SqlDbType.NVarChar, 20, "UserName");
            //SqlParameter p4 = new SqlParameter("pwd", SqlDbType.NVarChar, 10, "Password");
            //updatecmd.Parameters.Add(p3);
            //updatecmd.Parameters.Add(p4);
            //sd.UpdateCommand = updatecmd;
            //sd.Update(dataTable);
            Console.ReadKey();
        }
    }
}
