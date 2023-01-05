using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            String menu = "\t1- Manage Items\n\t2- Manage Customers\n\t3- Make New Sale\n\t4- Make Payment\n\t5- Exit\n\nPress 1 to 5 to select an option: ";
            while (true)
            {
                Console.Write(menu);
                choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.Write("\n\t1 - Add new Item\n\t2 - Update Item details\n\t3 - Find Items\n\t4 - Remove Existing Item\n\t5 - Back to Main Menu\nPress 1 to 5 to select an option: ");
                        choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            //case 1:


                        }
                        break;
                    case 2:
                        Console.Write("\n\r1- Add new Customer\r\n2- Update Customer details\r\n3- Find Customer\r\n4- Remove Existing Customer\r\n5- Back to Main Menu\r\nPress 1 to 5 to select an option:");
                        choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {

                            default:
                                break;
                        }
                        break;


                }

            }
        }
    }
}
