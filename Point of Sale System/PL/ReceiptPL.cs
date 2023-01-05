using BLL;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class ReceiptPL
    {
        double totalSalesAmount = 0.0;
        double AmountPaid = 0.0;
        double RemainingAmount = 0.0;
        double AmountToBePaid = 0.0;

        public void MakePayment()
        {
            DateTime d = DateTime.Now;
            string date = d.ToString("dd/MM/yyyy");
            Console.Write("Enter Sales ID: ");
            Console.ForegroundColor = ConsoleColor.Red;
            int saleId = int.Parse(Console.ReadLine());
            Console.ResetColor();
            SalesBLL saleBll = new SalesBLL();
            SaleDTO sale = saleBll.FindSale(saleId);
            if(sale != null)
            {
                SaleLineBLL saleLinebll = new SaleLineBLL();
                ArrayList saleLines = saleLinebll.FindSaleItems(saleId);
                foreach(SaleLineItem saleline in saleLines)
                {
                    totalSalesAmount += saleline.Amount;
                }
                CustomerDTO customer= saleBll.FindCustomer(sale.CustomerId);
                if(customer != null)
                {
                    ReceiptBLL receiptBLL = new ReceiptBLL();
                    ArrayList receipts = receiptBLL.FindReceipt(saleId);
                    if(receipts!= null)
                    {
                        foreach (ReceiptDTO receipt in receipts)
                        {
                            AmountPaid += receipt.amount;

                        }
                    }
                    RemainingAmount = totalSalesAmount-AmountPaid;

                    Console.Write($"Customer Name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{customer.Name}");
                    Console.ResetColor();
                    Console.Write($"Total Sales Amount: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{ totalSalesAmount:n}");
                    Console.ResetColor();
                    Console.Write($"Amount Paid: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{ AmountPaid:n}");
                    Console.ResetColor();
                    if (RemainingAmount <= 0)
                    {
                        Console.WriteLine("Amount has already been paid...");
                        return;
                    }

                    Console.Write($"Remaining Amount: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{ RemainingAmount:n}");
                    Console.ResetColor();
                    Console.Write("Amount to be Paid: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    AmountToBePaid = double.Parse(Console.ReadLine());
                    Console.ResetColor();
                    if (AmountToBePaid <= RemainingAmount)
                    {
                        ReceiptDTO receipt1 = new ReceiptDTO
                        {
                            ReceiptDate = date,
                            orderId = saleId,
                            amount = AmountToBePaid
                        };
                        if(receiptBLL.SaveReceipt(receipt1) && receiptBLL.UpdateCustomer(customer, receipt1.amount) )
                        {
                            Console.WriteLine("\nThanks for shopping here. Have a Good day :)\n");

                        }
                    }
                    else
                    {
                        ReceiptDTO receipt1 = new ReceiptDTO
                        {
                            ReceiptDate = date,
                            orderId = saleId,
                            amount = AmountToBePaid
                        };
                        customer.AmountPayable = customer.AmountPayable - AmountToBePaid;
                        if (receiptBLL.SaveReceipt(receipt1) && receiptBLL.UpdateCustomer(customer, receipt1.amount) && saleBll.UpdateStatus(saleId) )
                        {
                            Console.WriteLine($"\nAmount Returned: {AmountToBePaid-RemainingAmount}");
                            Console.WriteLine("Receipt has been generated...\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Customer does not exist in DB anymore");
                }
            }
            else
            {
                Console.WriteLine("No such Sale exists");
            }
        }
    }
}
