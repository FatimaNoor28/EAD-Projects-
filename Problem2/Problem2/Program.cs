using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Program
    {
    static void Main(string[] args)
    {
        //program execution starts from here
        Console.WriteLine("Total Arguments: {0}", args.Length);
            if (args.Length != 5)
            {
                Console.WriteLine("Please enter 5 arguments");
                Environment.Exit(0);
            }


            Patient p = new Patient
            {
                name = args[0],
                cnic = args[1],
                phone_number = args[2],
                disease = args[3],
                isAdmitted = args[4]
            };
            Console.WriteLine(p);

        }
    }
}
