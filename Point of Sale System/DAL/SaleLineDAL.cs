using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SaleLineDAL
    {
        public bool AddSaleLineItem(SaleLineItem dto) {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"INSERT INTO SaleLineItem (OrderId, ItemId, Quantity, Amount) VALUES({dto.OrderId}, {dto.ItemId}, {dto.Quantity}, '{dto.Amount}')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            if (count == -1)
            {
                return false;
            }
            return true;
        }

        public ArrayList FindSaleItems(int orderId)
        {
            ArrayList list = new ArrayList();
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"select * from SaleLineItem where OrderId = '{orderId}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if(rd.HasRows)
            {
                SaleLineItem saleLine;
                while(rd.Read())
                {
                    saleLine = new SaleLineItem() { 
                        LineNo = Convert.ToInt32(rd[0]),
                        OrderId= Convert.ToInt32(rd[1]),
                        ItemId= Convert.ToInt32(rd[2]),
                        Quantity= Convert.ToInt32(rd[3]),
                        Amount= Convert.ToDouble(rd[4])
                    };
                    list.Add(saleLine);
                }
            }
            con.Close();
            return list;
        }

        public void RemoveItem(int Orderid,int id)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"delete from SaleLineItem where OrderId = {Orderid} and ItemId = '{id}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteReader();

        }
    }
}
