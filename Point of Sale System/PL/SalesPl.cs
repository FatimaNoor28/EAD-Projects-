using BLL;
using DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class SalesPl
    {
        int Orderid;
        int CustomerId;
        string d;
        CustomerDTO customer;
        public void EnterItem()
        {
            SalesBLL bll = new SalesBLL();
            //bool available = 
            if (customer != null)
            {
                int choice = 1;
                //double sub_total = 0.0f;
                while (choice != 2)
                {
                    Console.WriteLine("Press 1 to Enter data\nPress 2 to Go Back to Menu");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            
                            Console.Write("\tItem Id: ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            int itemId = int.Parse((string)Console.ReadLine());
                            Console.ResetColor();
                            ItemDTO item = bll.FindItem(itemId);
                            //items.Add(item);
                            if (item != null)
                            {
                                Console.Write($"\tDescription: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{ item.description}");
                                Console.ResetColor();
                                Console.Write($"\tPrice: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{ item.price:0.00}");
                                Console.ResetColor();

                                Console.Write("\tQuantity: ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                int quantity = int.Parse(Console.ReadLine());
                                Console.ResetColor();
                                bll.MinusQuantityFromItem(quantity, itemId);
                                SaleLineItem dto = new SaleLineItem()
                                {
                                    OrderId= Orderid,
                                    ItemId= itemId,
                                    Quantity= quantity,
                                    Amount= item.price*quantity,
                                };
                                SaleLineBLL SaleLinebll = new SaleLineBLL();
                                Console.Write($"\tSub-Total: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{ dto.Amount:0.00}");
                                Console.ResetColor();

                                if (customer.AmountPayable + dto.Amount <= customer.SalesLimit)
                                {
                                    customer = bll.ModifyCustomer(CustomerId, dto.Amount);
                                    SaleLinebll.AddSaleLineItem(dto);
                                }
                                else
                                {
                                    DisplaySalesOfACustomer(Orderid, customer, d);
                                }
                            }
                            break;
                        case 2:
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void Start()
        {
            int choice = 0;
            while (choice != 4)
            {
                Console.WriteLine("\n\t1- Enter New Item\r\n\t2-End Sale\r\n\t3- Remove an existing Item from the current sale\r\n\t4- Cancel Sale");
                string s = Console.ReadLine();
                if (s.IsNullOrEmpty())
                {
                    continue;
                }
                else
                    choice = int.Parse(s);
                SalesBLL bll = new SalesBLL();
                ItemBLL itembll = new ItemBLL();
                SaleLineBLL saleLine = new SaleLineBLL();
                switch (choice)
                {
                    case 1:
                       
                        Orderid = bll.getNewId();
                        Console.WriteLine($"\tSales Id: {Orderid}");
                        DateTime date = DateTime.Now;
                        d = date.ToString("dd/MM/yyyy");
                        Console.WriteLine($"\tSales Date: {d}");
                        Console.Write("\tEnter Customer Id: ");
                        CustomerId = int.Parse(Console.ReadLine());
                        customer = bll.FindCustomer(CustomerId);
                        SaleDTO dto = new SaleDTO()
                        {
                            OrderId = Orderid,
                            CustomerId = CustomerId,
                            Date = d,
                            Status = "Payment Pending"
                        };
                        EnterItem();
                        bll.AddSalesRecord(dto);
                        break;
                    case 2:
                        if (Orderid != 0)               
                        {
                            DisplaySalesOfACustomer(Orderid, customer, d);
                            //    Console.WriteLine("Record added");
                            
                            Console.WriteLine("Press any key to continue...");

                            Console.ReadKey();
                            choice = 4;
                        }
                        else
                        {
                            Console.WriteLine("Enter Sales Record First");
                        }
                        break;
                    case 3:
                        Console.Write("Enter ID of Item you want to remove from Sale: ");
                        int id = int.Parse(Console.ReadLine());
                        double p = 0;
                        int q = 0;
                        ArrayList list = saleLine.FindSaleItems(Orderid);
                        foreach(SaleLineItem saleLineItem in list)
                        {
                            if(saleLineItem.ItemId == id)
                            {
                                q = saleLineItem.Quantity;
                                p = saleLineItem.Amount;
                                break;
                            }
                        }
                        //Add quantity back in items Quantity
                        bll.AddQuantityInItem(q, id);
                        // find quantity in sale line item and subtract from customer payable 
                        bll.RemoveItemPrice(CustomerId, p);
                        saleLine.RemoveItem(Orderid, id);
                        Console.WriteLine("Item has been removed from sale!");                
                        break;
                    case 4:
                        ArrayList saleLines = saleLine.FindSaleItems(Orderid);
                        foreach (SaleLineItem saleLine1 in saleLines)
                        {
                            bll.RemoveItemPrice(CustomerId, saleLine1.Amount);
                            saleLine.RemoveItem(Orderid, saleLine1.ItemId);
                        }
                        bll.RemoveSale(Orderid);
                        break;
                }
            }

        }

        public void DisplaySalesOfACustomer(int orderId, CustomerDTO customer, string date)
        {
            Console.WriteLine(format: "{0, -50} {1, 50}",
                    arg0: "Sales ID: " + orderId,
                    arg1: "Customer ID: " + customer.ID
                );
            Console.WriteLine(format: "{0, -50} {1, 50}",
                arg0: "Sales Date: " + date,
                arg1: "Name: " + customer.Name
            );
            double total = 0;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("{0,-15}{1,-30}{2,-15}{3,-15}", "Item ID", "Description", "Quantity", "Amount"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");

            SaleLineBLL bll = new SaleLineBLL();
            ArrayList saleLines = bll.FindSaleItems(orderId);
            foreach (SaleLineItem dto in saleLines)
            {
                ItemBLL itembLL = new ItemBLL();
                ItemDTO item = itembLL.FindItem(dto.ItemId);
                Console.WriteLine(string.Format("{0,-15}{1,-30}{2,-15:n}{3,-15:n}", item.id, item.description, dto.Quantity, dto.Amount));
                total += dto.Amount;

            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine(format: "{0, -15} {1, 10:n}",
                arg0: "\t\t\t\t\t\t\t\t\t\tTotal Sales ",
                arg1: "Rs. " + total);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");

        }

        //public void DisplaySalesOfACustomer(int orderId, int customerId, string date, string Name, int[] q)
        //{
        //    Console.WriteLine(format: "{0, -50} {1, 50}",
        //            arg0: "Sales ID: " + orderId,
        //            arg1: "Customer ID: " + customerId
        //        );
        //    Console.WriteLine(format: "{0, -50} {1, 50}",
        //        arg0: "Sales Date: " + date,
        //        arg1: "Name: " + Name
        //    );
        //    double total = 0;
        //    Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        //    Console.WriteLine(string.Format("{0,-15}{1,-15}{2,-15}{3,-15}", "Item ID", "Description", "Quantity", "Amount"));
        //    Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        //    //foreach (ItemDTO dto in items)
        //    //{
        //    //    Console.WriteLine(string.Format("{0,-15}{1,-15}{2,-15}{3,-15}", dto.id, dto.description, q[dto.id], dto.price));
        //    //    total += dto.price;

        //    //}
        //    Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        //    Console.WriteLine(format: "{0, -20} {1, 20}",
        //        arg0: "\t\t\t\t\t\t\tTotal Sales ",
        //        arg1: "Rs. "+total);
        //    Console.WriteLine("----------------------------------------------------------------------------------------------------------");

        //}

    }
}