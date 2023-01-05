using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ItemDAL
    {
        public int? retrieveLastId()
        {

            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = "SELECT MAX(ItemId) FROM Items";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            object result = cmd.ExecuteScalar();
            result = (result == DBNull.Value) ? null : result;
            int? id = Convert.ToInt32(result);
            con.Close();
            return id;
        }
        public bool AddItem(ItemDTO dto)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            DateTime date = DateTime.Now;
            string d = date.ToString("dd/MM/yyyy");
            Console.WriteLine(d);
            string query = $"INSERT INTO Items(ItemId, Description, Price, Quantity, CreationDate) VALUES(@i,'{dto.description}', {dto.price}, {dto.quantity}, '{d}' )";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlParameter p = new SqlParameter("i", dto.id);
            cmd.Parameters.Add(p);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            if (count == -1)
                return false;
            return true;
        }
        public ItemDTO FindItem(int id)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"select * from Items where ItemId = '{id}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            ItemDTO dto = new ItemDTO();
            while (rd.Read())
            {
                dto.id = Convert.ToInt32(rd[0]);
                dto.description = rd[1].ToString();
                dto.price = Convert.ToInt32(rd[2]);
                dto.quantity = Convert.ToInt32(rd[3]);
                dto.date = rd[4].ToString();
            }
            con.Close();
            return dto;
        }

        public void ModifyItem(ItemDTO dto)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"Update Items set Description = '{dto.description}', Price = '{dto.price}', Quantity = '{dto.quantity}', CreationDate = '{dto.date}' where ItemId = '{dto.id}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }


        public void FindItem(ItemDTO dto)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"select * from Items where ItemId = '{dto.id}' or Description = '{dto.description}' or Price = '{dto.price}' or Quantity = '{dto.quantity}' or CreationDate = '{dto.date}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine(
                string.Format("{0,-15}{1,-30}{2,-15}{3,-15}{4,-15}", "ItemID", "Description", "Price", "Quantity", "Creation Date")
            );
            while (rd.Read())
            {
                //Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine(string.Format("{0,-15}{1,-30}{2,-15:n}{3,-15}{4,-15:n}", rd[0].ToString(), rd[1].ToString().Replace("  ", String.Empty), rd[2].ToString(), rd[3].ToString(), rd[4].ToString()));       
            }
            Console.WriteLine("------------------------------------------------------------------------------------------");
            con.Close();
        }
        public void RemoveItem(int id) {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSaleTerminal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            string query = $"delete from Items where ItemId = '{id}' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
        }

        //docker
        //publish
        //FROM mcr.Microsoft.com/dotnet/runtime:6.0
        //COPY bin/release/net6.0/publish .
        //ENTRYPOINT["dotnet", "file.dll"]

        //docker build -t myimg .
        //docker images
        //docker run -ti myimg
        //docker container start <container id>
        //docker exec -ti <container name> bin/bash
        //docker stop <con name>
    }
}
