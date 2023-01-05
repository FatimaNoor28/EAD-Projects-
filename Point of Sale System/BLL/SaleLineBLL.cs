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
    public class SaleLineBLL
    {
        public bool AddSaleLineItem(SaleLineItem dto)
        {
            SaleLineDAL dal = new SaleLineDAL();
            return dal.AddSaleLineItem(dto);
        }

        public ArrayList FindSaleItems(int orderId)
        {
            SaleLineDAL dal = new SaleLineDAL();
            return dal.FindSaleItems(orderId);
        }

        public void RemoveItem(int Orderid, int itemid)
        {
            SaleLineDAL dal = new SaleLineDAL();
            dal.RemoveItem(Orderid,itemid);
        }
    }
}
