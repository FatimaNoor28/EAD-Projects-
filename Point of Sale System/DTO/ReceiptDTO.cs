using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReceiptDTO
    {
        public int ReceiptNo { get; set; }
        public string ReceiptDate { get; set;}
        public int orderId { get; set; }    
        public double amount { get; set; }
    }
}
