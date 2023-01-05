using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisconnectedDB_practice_mids_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EMS_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand
            {
                Connection = con
            };
            SqlDataAdapter dr = new SqlDataAdapter();
            DataTable mytable = new DataTable();


            //////select
            string query = "select * from Employee";
            cmd.CommandText = query;
            dr.SelectCommand = cmd;

            dr.Fill(mytable);

            foreach (DataRow r2 in mytable.Rows)
            {
                Console.WriteLine($"ID: {r2[0]}, Name: {r2[1]}, Salary: {r2[2]}, Tax: {r2[3]}");
            }

            mytable.PrimaryKey = new DataColumn[] { mytable.Columns[0] };

            //////////insert
            
            
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Salary: ");
            int sal = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Tax: ");
            int tax = Convert.ToInt32(Console.ReadLine());
            DataRow row = mytable.NewRow();
            Random rand = new Random();
            int MaxId = 0;

            DataRow[] r = mytable.Select("Id > 0");
            int x = 0;
            foreach (DataRow rows in r)
            {
                x = Convert.ToInt32(rows[0]);
                if (x>MaxId)
                    MaxId = x;
            }

            Console.WriteLine($"Max Id is : {MaxId}");
            row["Id"] = MaxId+1;
            row["Name"] = name;
            row["Salary"] = sal;
            row["Tax"] = tax;
            mytable.Rows.Add(row);
            
            SqlCommand cmd2 = new SqlCommand();

            query = "insert into Employee(Name, Salary, Tax) Values(@n, @s, @t)";
            cmd2.CommandText = query;
            cmd2.Connection = con;
            //SqlParameter p = new SqlParameter("i", SqlDbType.Int, 20, "Id");
            SqlParameter p1 = new SqlParameter("n", SqlDbType.NChar, 10,"Name");
            SqlParameter p2 = new SqlParameter("s", SqlDbType.Int, sizeof(int), "Salary");
            SqlParameter p3 = new SqlParameter("t", SqlDbType.Int, 10, "Tax");
            //cmd2.Parameters.Add(p);
            cmd2.Parameters.Add(p1);
            cmd2.Parameters.Add(p2);
            cmd2.Parameters.Add(p3);
            dr.InsertCommand = cmd2;
            dr.Update(mytable);

            ///////Update
            DataRow row2 = mytable.NewRow();
            Console.Write("Enter Id to be Updated: ");
            int id = Convert.ToInt32(Console.ReadLine());
            row2 = mytable.Rows.Find(id);
            if ( row2==null)
            {
                Console.WriteLine("Row not found");
            }
            else
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine();
                Console.Write("Enter Salary: ");
                sal = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Tax: ");
                tax = Convert.ToInt32(Console.ReadLine());
                row2[1] = name;
                row2[2] = sal;
                row2[3] = tax;

                string q = "update Employee set Name = @n, Salary = @s, Tax = @t where Id = 5";
                SqlParameter p4 = new SqlParameter("n", SqlDbType.NChar, 10, "Name");
                SqlParameter p5 = new SqlParameter("s", SqlDbType.Int, sizeof(int), "Salary");
                SqlParameter p6 = new SqlParameter("t", SqlDbType.Int, sizeof(int), "Tax");
                SqlParameter p7 = new SqlParameter("i", SqlDbType.Int, sizeof(int), "Id");
                SqlCommand cd3 = new SqlCommand(q, con);
                cd3.Parameters.Add(p4);
                cd3.Parameters.Add(p5);
                cd3.Parameters.Add(p6);
                cd3.Parameters.Add(p7);

                dr.UpdateCommand = cd3;
                dr.Update(mytable);
            }

            //////delete
            Console.WriteLine("Enter id to be deleted");
            id = Convert.ToInt32(Console.ReadLine());
            DataRow row3 = mytable.Rows.Find(id);
            if(row3 == null)
            {
                Console.WriteLine("Row not found");
            }
            row3.Delete();
            query = "delete from Employee where Id = @i";
            SqlParameter p8 = new SqlParameter("i", SqlDbType.Int, 10, "Id");
            SqlCommand cmd4 = new SqlCommand(query, con);
            cmd4.Parameters.Add(p8);
            dr.DeleteCommand= cmd4;
           dr.Update(mytable);
            Console.ReadKey();
        }
    }
}
