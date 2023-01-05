using Microsoft.Data.SqlClient;
using System.Data;
namespace EAD_INMEMORYDB
{
    public class Class1
    {
        public static void Main(string[] args)
        {

            //string constring = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PHARMACY; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EMS_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            ////////////////////////////////////////SELECT



            string query = "select ^ from tbUsers";

            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataAdapter ada = new SqlDataAdapter();
            DataTable tbl = new DataTable();
            ada.SelectCommand= cmd;
            ada.Fill(tbl);

/*            string query = "Select * from LOGIN";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable mytbl = new DataTable();

            adapter.SelectCommand = cmd;
            adapter.Fill(mytbl);
*/
            ////////////////////////////////////////INSERT

            DataRow newRow = tbl.NewRow();
            newRow["UserName"] = "Faiza";
            newRow["Password"] = "2131";
            tbl.Rows.Add(newRow);



           //DataRow newrow = mytbl.NewRow();
           // newrow["Username"] ="laiba";
           // newrow["Password"] = "123";
           // mytbl.Rows.Add(newrow);

            DataRow newrow2 = tbl.NewRow();
            newrow2["Username"] = "unzay";
            newrow2["Password"] = "987";
            tbl.Rows.Add(newrow2);



            String insertquery = "Insert into LOGIN(Username,Password) values(@n,@s)";

            SqlCommand insertcmd = new SqlCommand(insertquery, con);
            //SqlParameter p1 = new SqlParameter("i", SqlDbType.VarChar, 50, "Id");
            SqlParameter p1 = new SqlParameter("n", SqlDbType.VarChar, 50, "Username");
            SqlParameter p2 = new SqlParameter("s", SqlDbType.VarChar, 50, "Password");
           
            insertcmd.Parameters.Add(p1);
            insertcmd.Parameters.Add(p2);
            //insertcmd.Parameters.Add(p3);
            adapter.InsertCommand = insertcmd;
            adapter.Update(mytbl);
       
           ///////////////////////////////////////UPDATE
            DataRow mytlbrow = mytbl.Rows[1];
            mytlbrow["Username"] = "fatima";

            String upadatequery = "Update LOGIN set Username=@us where Id=23";

            SqlCommand updatecmd = new SqlCommand(upadatequery, con);
            SqlParameter u1 = new SqlParameter("us", SqlDbType.VarChar, 50, "Username");
            updatecmd.Parameters.Add(u1);
            adapter.UpdateCommand = updatecmd;  
            adapter.Update(mytbl);
          
            ///////////////////////////////////////////////////DELETE
            string name = "laiba";
            DataRow[] deleterows = mytbl.Select($"Username='{name}'");
            // mytbl.Rows.Delete(deleterows);

            foreach (DataRow row in deleterows)
            {
              
                    row.Delete();

                
            }

            String deletequery = $"Delete from LOGIN where Username='laiba' ";

            SqlCommand delcmd = new SqlCommand(deletequery, con);
            adapter.DeleteCommand = delcmd;
            adapter.Update(mytbl);



            con.Close();







        }










    }
}
// DataTable db = new DataTable();

/*string query = "Select * from CASHIER";
SqlCommand cmd = new SqlCommand(query, con);


int no = 2;
/*  Console.WriteLine("ENTER ID");
  string medid = Console.ReadLine();
  Console.WriteLine("ENTER NAME");
  string medname = Console.ReadLine();
  Console.WriteLine("ENTER Price");
  int price = int.Parse(Console.ReadLine());
  Console.WriteLine("ENTER Quantity");
  int quantity = int.Parse(Console.ReadLine());
  int total = price * quantity;
*/
/*Console.WriteLine("ENTER ID");
string uname = Console.ReadLine();
Console.WriteLine("ENTER NAME");
string pwd = Console.ReadLine();

//string query1 = $"Insert into CASHIER (MEDICINEID,MEDICINENAME,PRICE,QUANTITY,TOTAL) VALUES('{medid}','{medname}','{price}','{quantity}','{total}')";
string query1 = $"Insert into LOGIN (Username,Password) VALUES('{uname}','{pwd}')";
SqlCommand cmd1 = new SqlCommand(query1, con);
adapter.InsertCommand = cmd1;
adapter.Update(mytbl);

DataRow newrow = mytbl.NewRow();
newrow["Username"] = uname;
newrow["Password"] = pwd;





// newrow["NO#"] = no;
// newrow["MEDICINEID"] = medid;
//newrow["MEDICINENAME"] = medname;

// newrow["TOTAL"] = total;
mytbl.Rows.Add(newrow);




adapter.SelectCommand = cmd;
adapter.Fill(mytbl);

foreach (DataRow row in mytbl.Rows)
{
    Console.WriteLine(row[0]);
    Console.WriteLine(row[1]);
    Console.WriteLine(row[2]);
    Console.WriteLine(row[3]);
    //  Console.WriteLine(row[4]);

}*/