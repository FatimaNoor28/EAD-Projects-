using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cashier_DTO;
using Pharmacy_DAL;

namespace Pharmacy_BLL
{
    public class BLL
    {
        public bool Authenticate(Cashier c)
        {
            DAL dal = new DAL();
            bool check = dal.Authenticate(c);
            if (check) { return true; }
            return false;
        }
    }
}
