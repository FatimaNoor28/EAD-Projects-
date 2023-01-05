using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using PL;

namespace Point_of_Sale_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            int choice;
            String menu = "\t1- Manage Items\n\t2- Manage Customers\n\t3- Make New Sale\n\t4- Make Payment\n\t5- Exit\n\nPress 1 to 5 to select an option: ";
            while (true)
            {
                Console.Write(menu);
                string s = Console.ReadLine();
                if (s.IsNullOrEmpty())
                {
                    continue;
                }
                else
                    choice = int.Parse(s);
                switch (choice)
                {
                    case 1:
                        while (choice != 5)
                        {
                            ItemPL pl = new ItemPL();
                            Console.Write("\n\t1 - Add new Item\n\t2 - Update Item details\n\t3 - Find Items\n\t4 - Remove Existing Item\n\t5 - Back to Main Menu\nPress 1 to 5 to select an option: ");
                            s = Console.ReadLine();
                            if (s.IsNullOrEmpty())
                            {
                                continue;
                            }
                            else
                                choice = int.Parse(s);
                            switch (choice)
                            {
                                case 1:
                                    pl.Add_Item();
                                    break;
                                case 2:
                                    pl.ModifyItem();
                                    break;
                                case 3:
                                    pl.FindItem();
                                    break;
                                case 4:
                                    pl.RemoveItem();
                                    break;
                                case 5:
                                    break;
                            }
                        }
                        break;
                    case 2:
                        while (choice != 5)
                        {
                            CustomerPL pl = new CustomerPL();
                            Console.Write("\n\r\t1- Add new Customer\r\n\t2- Update Customer details\r\n\t3- Find Customer\r\n\t4- Remove Existing Customer\r\n\t5- Back to Main Menu\r\n\tPress 1 to 5 to select an option:");
                            s = Console.ReadLine();
                            if (s.IsNullOrEmpty())
                            {
                                continue;
                            }
                            else
                                choice = int.Parse(s);
                            switch (choice)
                            {
                                case 1:
                                    pl.Add_Customer();
                                    break;
                                case 2:
                                    pl.ModifyCustomer();
                                    break;
                                case 3:
                                    pl.FindCustomer();
                                    break;
                                case 4:
                                    pl.RemoveCustomer();
                                    break;
                                case 5:
                                    break;
                            }
                        }
                        break;
                    case 3:
                        SalesPl Salepl = new SalesPl();
                        Salepl.Start();
                        break;

                    case 4:
                        ReceiptPL receiptPL = new ReceiptPL();
                        receiptPL.MakePayment();
                        break;
                    
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
            //Console.ReadKey();
        }
    }
}
