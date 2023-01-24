using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BLL;
using System.Diagnostics;
using Microsoft.IdentityModel.Tokens;

namespace PL
{
    public class ItemPL
    {
        public void Add_Item()
        {
            ItemBLL bll = new ItemBLL();
            int id = bll.NewId();
            Console.WriteLine($"New Id of Item is: {id}");
            Console.Write("Enter Description: ");
            string des = Console.ReadLine();
            Console.Write("Enter price: ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int q = int.Parse(Console.ReadLine());
            ItemDTO dto = new ItemDTO()
            {
                id = id,
                quantity = q,
                price = p,
                description = des,
            };
            bool check = bll.AddItem(dto);
            if(check)
            {
                Console.WriteLine("Item Information Successfully saved");
            }
            else
            {
                Console.WriteLine("Item not saved...Try Again");
            }
            return;
        }

        public void ModifyItem()
        {
            ItemBLL bll = new ItemBLL();
            Console.Write("Enter Id: ");
            
            int id = int.Parse(Console.ReadLine());
            ItemDTO dto = bll.FindItem(id);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("{0,-15}{1,-30}{2,-15}{3,-15}{4,-15}", "ItemID", "Description", "Price", "Quantity", "Creation Date"));
            Console.WriteLine(string.Format("{0,-15}{1,-30}{2,-15:n}{3,-15}{4,-15}", dto.id, dto.description.Replace("  ",string.Empty), dto.price, dto.quantity, dto.date));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Please specify atleast one of the following to modify. Leave all fields blank to return to Items Menu:\r\n");
            
            Console.Write("Description: ");
            string description = Console.ReadLine().Replace("  ", String.Empty);
            if (!string.IsNullOrEmpty(description))
            {
                dto.description = description;
            }
            Console.Write("Price: ");
            string p = Console.ReadLine();
            if (!string.IsNullOrEmpty(p))
            {
                dto.price = int.Parse(p);
            }
            Console.Write("Quantity: ");
            string quantity = Console.ReadLine();
            if (!string.IsNullOrEmpty(quantity))
            {
                dto.quantity = int.Parse(quantity);
            }
            Console.Write("Creation Date(dd/mm/yyyy): ");
            string date = Console.ReadLine();
            if (!string.IsNullOrEmpty(date))
            {
                dto.date = date;
            }
            bll.ModifyItem(dto);

        }


        public void FindItem()
        {
            Console.WriteLine("Please specify atleast one of the following to find the item. Leave all fields blank to return to Items Menu:\r\n");
            Console.Write("Item ID: ");
            string id = Console.ReadLine();
            int i;
            if (!string.IsNullOrEmpty(id))
            {
                i = int.Parse(id);
            }
            else
            {
                i = -99999;
            }
            Console.Write("Description: ");
            string des = Console.ReadLine().Replace("  ", String.Empty);
            Console.Write("Price: ");
            string p = Console.ReadLine();
            int price;
            if (!string.IsNullOrEmpty(p))
            {
                price = int.Parse(p);
            }
            else
            {
                price = -99999;
            }
            Console.Write("Quantity: ");
            string quantity = Console.ReadLine();
            int q;
            if (!string.IsNullOrEmpty(quantity))
            {
                q = int.Parse(quantity);
            }
            else
            {
                q = -99999;
            }
            Console.Write("Creation Date: ");
            string date = Console.ReadLine();
            ItemDTO dto = new ItemDTO()
            {
                id = i,
                description = des,
                price = price,
                quantity = q,
                date = date
            };
            ItemBLL bll = new ItemBLL();
            bll.FindItem(dto);
        }

        public void RemoveItem()
        {
            Console.Write("Item ID: ");
            int id = int.Parse(Console.ReadLine());
            ItemBLL bll = new ItemBLL();
            ItemDTO dto = bll.FindItem(id);
            string check;
            if(dto != null)
            {
                Console.Write("Are you sure you want to remove this item? (y/n):  ");
                check = Console.ReadLine();
                if (check.Equals("y") || check.Equals("Y"))
                {
                    bll.RemoveItem(id);
                }
                return;
            }

        }
    }
}
