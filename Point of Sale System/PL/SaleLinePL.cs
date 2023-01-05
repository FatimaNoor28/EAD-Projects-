using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class SaleLinePL
    {
        public void AddSaleLineItem(SaleLineItem dto)
        {
            SaleLineBLL bll = new SaleLineBLL();
            bll.AddSaleLineItem(dto);
        }
    }
}
