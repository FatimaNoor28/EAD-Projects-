using DAL;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReceiptBLL
    {
        public ArrayList FindReceipt(int orderId)
        {
            ReceiptDAL dal = new ReceiptDAL();
            return dal.FindReceipt(orderId);
        }

        public bool SaveReceipt(ReceiptDTO receipt1)
        {
            ReceiptDAL dal = new ReceiptDAL();
            return dal.SaveReceipt(receipt1);
        }
        public bool UpdateCustomer(CustomerDTO customer, double price)
        {
            ReceiptDAL dal = new ReceiptDAL();
            return dal.UpdateCustomer(customer, price);
        }
    }
}
