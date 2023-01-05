using System;
//using PCL-haseeb;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCL;

namespace haseeb
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient p = new Patient
            {
                Name = "haseeb",
                isAdmitted = true,
                CNIC = "123898798-213218",
                Phone_Number = 0313499886,
                Id = 1,
                Disease = "tharakpan",
            };
            Patient p1 = new Patient
            {
                Name = "tehreem",
                isAdmitted = true,
                CNIC = "123898798-213218",
                Phone_Number = 0323499886,
                Id = 1,
                Disease = "pagalpan",
            };
            p.addPatient(p1);
            p.addPatient(p);
            p.UpdatePatient(1, p1);

            Console.WriteLine(p1);
            Console.ReadKey();
        }
    }
}
