using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy_BLL;
using Cashier_DTO;

namespace Pharmacy_PL
{
    public class PL
    {
        public bool AuthenticateCashier()
        {
            Console.Write("Enter user name: ");
            string name = Console.ReadLine();
            Console.Write("Enter password: ");
            string pwd = Console.ReadLine();
            Cashier c = new Cashier()
            {
                UserName= name,
                Password= pwd
            };

            BLL bll = new BLL();
            bool check = bll.Authenticate(c);
            return check;

        }
        public void InputOrder()
        {
            bool isCashier = AuthenticateCashier();
            if(isCashier)
            {
                Console.Write("Enter Medicine u want to buy: ");
                string med = Console.ReadLine();
                Console.Write($"Enter quantity of {med}: ");
                int q = int.Parse(Console.ReadLine());
            }

        }
    }
}
