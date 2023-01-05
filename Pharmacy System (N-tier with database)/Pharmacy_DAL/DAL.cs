using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cashier_DTO;
using Microsoft.Data.SqlClient;

namespace Pharmacy_DAL
{
    public class DAL
    {
        public DAL() {
            
            
        }
        public bool Authenticate(Cashier c)
        {
            String conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pharmacy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conn);
            String query = $"Select * from Cashiers where Username = {c.UserName} and Password = {c.Password}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader sqlDataReaderreader = cmd.ExecuteReader();
            if (sqlDataReaderreader.Read()!=null)
            {
                return true;
            }
            return false;
        }
    }
}
