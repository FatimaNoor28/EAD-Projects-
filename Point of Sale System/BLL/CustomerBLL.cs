using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomerBLL
    {
        public int NewCustomerId()
        {
            CustomerDAL dal = new CustomerDAL();
            int? id = dal.retrieveLastId();
            if (id == null)
                return 1;
            else
                return (int)(id + 1);
        }

        public bool AddCustomer(CustomerDTO dto)
        {
            CustomerDAL dal = new CustomerDAL();
            bool check = dal.AddCustomer(dto);
            return check;
        }
        public CustomerDTO FindCustomer(int id)
        {
            CustomerDAL dal = new CustomerDAL();
            CustomerDTO dto = dal.FindCustomer(id);
            return dto;
        }

        public void ModifyCustomer(CustomerDTO dto)
        {
            CustomerDAL da = new CustomerDAL();
            da.ModifyCustomer(dto);
        }

        public void FindCustomer(CustomerDTO dto)
        {
            CustomerDAL dal = new CustomerDAL();
            dal.FindCustomer(dto);

        }
        public bool CheckCustomerInSales(int id)
        {
            CustomerDAL dal = new CustomerDAL();
            return dal.CheckCustomerInSales(id);
        }
        public void RemoveCustomer(int id)
        {
            CustomerDAL dal = new CustomerDAL();
            dal.RemoveCustomer(id);
        }
    }
}
