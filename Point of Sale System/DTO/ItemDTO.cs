using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace DTO
{
    public class ItemDTO
    {
        public int id { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public string date { get; set; }
    }
}
