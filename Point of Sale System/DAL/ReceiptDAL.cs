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
    public class ReceiptDAL
    {
        public ArrayList FindReceipt(int orderId)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"select * from Receipt where OrderId = '{orderId}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            ArrayList list = new ArrayList();
            ReceiptDTO dto;
            if(rd.HasRows)
            {
                while(rd.Read())
                {
                    dto = new ReceiptDTO{
                        ReceiptNo = Convert.ToInt32(rd[0]),
                        ReceiptDate = rd[1].ToString(),
                        orderId = Convert.ToInt32(rd[2]),
                        amount = Convert.ToDouble(rd[3])
                    };
                    list.Add(dto);
                }
            }
            return list;
        }

        public bool SaveReceipt(ReceiptDTO receipt)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"insert into Receipt(ReceiptDate, OrderId, Amount) Values('{receipt.ReceiptDate}', '{receipt.orderId}', '{receipt.amount}')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            if (count == -1)
                return false;
            return true;
        }

        public bool UpdateCustomer(CustomerDTO customer, double amount)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"select * from Customers where CustomerId = '{customer.ID}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            double payable = 0;
            while (rd.Read())
            {
                payable = Convert.ToDouble(rd[5]);
            }
            con.Close();
            payable = payable - amount;


            query = $"Update Customers set AmountPayable = '{payable}' where CustomerId = '{customer.ID}' ";
            cmd = new SqlCommand(query, con);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            if(count == -1)
                return false;
            return true;
        }
    }
}
