using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class SalesBLL:ItemBLL
    {
        public int getNewId()
        {
            SalesDAL dal = new SalesDAL();
            int? id = dal.getNewId();
            if (id == null)
                return 1;
            else
                return (int)(id + 1);
        }

        public bool AddSalesRecord(SaleDTO dto)
        {
            SalesDAL dal = new SalesDAL();
            return dal.AddSalesRecord(dto);
        }

        public new ItemDTO FindItem(int id)
        {
            ItemDTO item = new ItemDTO();
            item = base.FindItem(id);
            return item;
        }

        public CustomerDTO ModifyCustomer(int id, double payable)
        {
            CustomerDTO dto = new CustomerDTO()
            {
                ID = id,
                AmountPayable = payable
            };
            SalesDAL dal = new SalesDAL();
            dto = dal.ModifyCustomer(dto);
            return dto;
        }

        public CustomerDTO FindCustomer(int id)
        {
            SalesDAL dal = new SalesDAL();
            CustomerDTO dto = dal.FindCustomer(id);
            return dto;

        }

        public void AddQuantityInItem(int q, int id)
        {
            SalesDAL dal = new SalesDAL();
            dal.AddQuantityInItem(q, id);
        }
        public void MinusQuantityFromItem(int quantity, int id)
        {
            SalesDAL dal = new SalesDAL();
            dal.MinusQuantityFromItem(quantity, id);
        }
        public bool UpdateStatus(int id)
        {
            SalesDAL dal = new SalesDAL();
            return dal.UpdateStatus(id);
        }
        public void RemoveItemPrice(int customerId, double price) {
            SalesDAL dal = new SalesDAL();
            dal.RemoveCustomer(customerId, price);
        }

        public void RemoveSale(int orderid)
        {
            SalesDAL dal  = new SalesDAL();
            dal.RemoveSale(orderid);
        }

        public SaleDTO FindSale(int orderid)
        {
            SalesDAL dal = new SalesDAL();
            return dal.FindSale(orderid);
        }
    }
}
