using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace PL
{
    public class ItemPL
    {
        public void Add_Item()
        {
            Console.Write("Enter Description: ");
            string des = Console.ReadLine();
            Console.Write("Enter price: ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int q = int.Parse(Console.ReadLine());
            ItemDTO dto = new ItemDTO() { 
                quantity = q,
                price = p,
                description = des
            };

        }
    }
}
