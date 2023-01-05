using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class CustomerDAL
    {
        public int? retrieveLastId()
        {

            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = "SELECT MAX(CustomerId) FROM Customers";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            object result = cmd.ExecuteScalar();
            result = (result == DBNull.Value) ? null : result;
            int? id = Convert.ToInt32(result);
            con.Close();
            return id;
        }
        public bool AddCustomer(CustomerDTO dto)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"INSERT INTO Customers(CustomerId, Name , Address, Phone, Email, AmountPayable, SalesLimit) VALUES({dto.ID},'{dto.Name}', '{dto.Address}', '{dto.Phone}', '{dto.Email}', '{dto.AmountPayable}', '{dto.SalesLimit}' )";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            if (count == -1)
                return false;
            return true;
        }

        public CustomerDTO FindCustomer(int id)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"select * from Customers where CustomerId = '{id}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            CustomerDTO dto = new CustomerDTO();
            while (rd.Read())
            {
                dto.ID = Convert.ToInt32(rd[0]);
                dto.Name = rd[1].ToString();
                dto.Email = rd[4].ToString();
                dto.Phone = rd[3].ToString();
                dto.SalesLimit = Convert.ToDouble(rd[6]);
            }
            con.Close();
            return dto;
        }

        public void ModifyCustomer(CustomerDTO dto)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"Update Customers set Name = '{dto.Name}', Email = '{dto.Email}', Phone = '{dto.Phone}', SalesLimit = '{dto.SalesLimit}' where CustomerId = '{dto.ID}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }


        public void FindCustomer(CustomerDTO dto)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"select * from Customers where CustomerId = '{dto.ID}' or Name = '{dto.Name}' or Email = '{dto.Email}' or Phone = '{dto.Phone}' or SalesLimit = '{dto.SalesLimit}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine(
                    string.Format("{0,-15}{1,-25}{2,-15}{3,-15}{4,-15}", "Customer ID", "Name", "Email", "Phone", "SalesLimit")
                );
                Console.WriteLine("--------------------------------------------------------------------------------------------------");

            }
            while (rd.Read())
            {

                Console.WriteLine(string.Format("{0,-15}{1,-15}{2,-25}{3,-15}{4,-15:n}", rd[0].ToString(), rd[1].ToString().Replace("  ", String.Empty), rd[4].ToString().Replace("  ", String.Empty), rd[3].ToString().Replace("  ", String.Empty), rd[6].ToString()));
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            con.Close();
        }

        public bool CheckCustomerInSales(int id)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"SELECT * FROM Sales WHERE CustomerId = {id}";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            return rd.HasRows;
        }
        public void RemoveCustomer(int id)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"delete from Customers where CustomerId = '{id}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteReader();
        }
    }
}
