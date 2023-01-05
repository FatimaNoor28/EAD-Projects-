using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class CustomerPL
    {
        public void Add_Customer()
        {
            CustomerBLL bll = new CustomerBLL();
            int id = bll.NewCustomerId();
            Console.WriteLine($"Id of Customer is: {id}");
            Console.Write("Enter Name: ");
            string nm = Console.ReadLine();
            Console.Write("Enter Address: ");
            string adr = Console.ReadLine();
            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Email: ");
            string e = Console.ReadLine();
            int payable = 0;
            Console.Write("Enter Sales Limit: ");
            double sales = double.Parse(Console.ReadLine());
            CustomerDTO dto = new CustomerDTO()
            {
                ID= id,
                Name= nm,
                Address= adr,
                Phone= phone,
                Email= e,
                AmountPayable= payable,
                SalesLimit=sales,
            };
            Console.Write("Are you sure you want to save this data?(y/n: )");
            string ans = Console.ReadLine();
            if (ans.Equals("n"))
            {
                return ;
            }
            bool check = bll.AddCustomer(dto);
            if (check)
            {
                Console.WriteLine("Customer Information Saved Successfully");
            }
            else
            {
                Console.WriteLine("Customer not saved...Try Again");
            }
            return;
        }

        public void ModifyCustomer()
        {
            try
            {
                CustomerBLL bll = new CustomerBLL();
                Console.Write("Enter Id: ");
                int id = int.Parse(Console.ReadLine());
                CustomerDTO dto = bll.FindCustomer(id);
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine(string.Format("{0,-15}{1,-15}{2,-25}{3,-15}{4,-15}", "Customer ID", "Name", "Email", "Phone", "Sales Limit"));
                Console.WriteLine(string.Format("{0,-15}{1,-15}{2,-25}{3,-15}{4,-15:n}", dto.ID, dto.Name.Replace("  ", string.Empty), dto.Email, dto.Phone, dto.SalesLimit));
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Please specify atleast one of the following to modify. Leave all fields blank to return to Customers Menu:\r\n");

                Console.Write("Name: ");
                string description = Console.ReadLine().Replace("  ", String.Empty);
                if (!string.IsNullOrEmpty(description))
                {
                    dto.Name = description;
                }
                Console.Write("Email: ");
                string p = Console.ReadLine();
                if (!string.IsNullOrEmpty(p))
                {
                    dto.Email = p.Replace("  ", string.Empty);
                }
                Console.Write("Phone: ");
                string ph = Console.ReadLine();
                if (!string.IsNullOrEmpty(ph))
                {
                    dto.Phone = ph.Replace("  ", string.Empty);
                }
                Console.Write("Sales Limit: ");
                string quantity = Console.ReadLine();
                if (!string.IsNullOrEmpty(quantity))
                {
                    dto.SalesLimit = int.Parse(quantity);
                }

                bll.ModifyCustomer(dto);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public void FindCustomer()
        {
            Console.WriteLine("Please specify atleast one of the following to find the item. Leave all fields blank to return to Customers Menu:\r\n");
            Console.Write("Customer ID: ");
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
            Console.Write("Name: ");
            string des = Console.ReadLine().Replace("  ", String.Empty);
            Console.Write("Email: ");
            string e = Console.ReadLine().Replace("  ", string.Empty);
            Console.Write("Phone: ");
            string ph = Console.ReadLine().Replace("  ", String.Empty);
            Console.Write("Sales Limit: ");
            string s = Console.ReadLine().Replace("  ", String.Empty);

            double sales;
            if (!string.IsNullOrEmpty(s))
            {
                sales = double.Parse(s);
            }
            else
            {
                sales = -99999;
            }
            CustomerDTO dto = new CustomerDTO()
            {
                ID = i,
                Name = des,
                Email= e,
                Phone= ph,
                SalesLimit= sales
            };
            CustomerBLL bll = new CustomerBLL();
            bll.FindCustomer(dto);
        }

        public void RemoveCustomer()
        {
            Console.Write("Customer ID: ");
            int id = int.Parse(Console.ReadLine());
            CustomerBLL bll = new CustomerBLL();
            CustomerDTO dto = bll.FindCustomer(id);
            string check;
            if (dto != null)
            {
                if (!bll.CheckCustomerInSales(id))
                {
                    Console.Write("Are you sure you want to remove this Customer? (y/n):  ");
                    check = Console.ReadLine();
                    if (check.Equals("y"))
                    {
                        bll.RemoveCustomer(id);
                        Console.WriteLine("Record has been deleted!!");
                    }
                    return;
                }
                else
                {
                    Console.WriteLine("Customer record cannot be deleted(associated with sale)! ");
                }
            }

        }
    }
}
