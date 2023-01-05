using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DTO;
using System.Data;

namespace DAL
{
    public class SalesDAL: CustomerDAL
    {
        public int? getNewId()
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = "SELECT MAX(OrderId) FROM Sales";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            object result = cmd.ExecuteScalar();
            result = (result == DBNull.Value) ? null : result;
            int? id = Convert.ToInt32(result);
            con.Close();
            return id;
        }

        public bool AddSalesRecord(SaleDTO dto)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"INSERT INTO Sales (OrderId, CustomerId, Date, Status) VALUES({dto.OrderId}, {dto.CustomerId}, '{dto.Date}', '{dto.Status}')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            if(count == -1)
            {
                return false;
            }
            return true;
        }

        public CustomerDTO ModifyCustomer(CustomerDTO dto)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"select * from Customers where CustomerId = '{dto.ID}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    dto.Name = rd[1].ToString();
                    dto.SalesLimit = Convert.ToDouble(rd[6]);
                    dto.AmountPayable += Convert.ToDouble(rd[5]);
                }
            }
            con.Close();
            
            if(dto.AmountPayable < dto.SalesLimit)
            {
                con.Open();
                query = $"Update Customers set AmountPayable = '{dto.AmountPayable}' where CustomerId = '{dto.ID}' ";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

            }
            con.Close();
            return dto;
        }

        public CustomerDTO FindCustomer(int id)
        {
            return base.FindCustomer(id);
        }

        public bool UpdateStatus(int id)
        {
            string status = "Sale Completed";
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"UPDATE Sales SET Status = '{status}' WHERE OrderId = {id}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            if (count == -1)
                return false;
            return true;
        }

        public void AddQuantityInItem(int id, int quantity)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"select * from Items where ItemId = '{id}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int q = 0;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    q = Convert.ToInt32(rd[3]);
                }
            }
            q += quantity;
            con.Close();
            query = $"UPDATE Items SET Quantity = '{q}' WHERE ItemId = {id}";
            cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return;
        }
        public void MinusQuantityFromItem(int quantity, int id)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"select * from Items where ItemId = '{id}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int q = 0;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    q = Convert.ToInt32(rd[3]);
                }
            }
            q -= quantity;
            con.Close();
            query = $"UPDATE Items SET Quantity = '{q}' WHERE ItemId = {id}";
            cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return;
        }

        public void RemoveCustomer(int id, double price)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            double payable = 0.0f;
            string query = $"select AmountPayable from Customers where CustomerId = '{id}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    payable = Convert.ToDouble(rd[0]) - price;
                }
            }
            con.Close();
            con.Open();
            query = $"Update Customers set AmountPayable = '{payable}' where CustomerId = '{id}' ";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteReader();
            con.Close();
        }

        public void RemoveSale(int id)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"DELETE FROM Sales WHERE OrderId = {id}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();

        }

        public SaleDTO FindSale(int id)
        { 
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"select * from Sales where OrderId = '{id}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            SaleDTO dto = new SaleDTO();
            while (rd.Read())
            {
                dto.OrderId = Convert.ToInt32(rd[0]);
                dto.CustomerId = Convert.ToInt32(rd[1]);
                dto.Date = rd[2].ToString();
                dto.Status = rd[3].ToString();
            }
            con.Close();
            return dto;
        }
    }
}
