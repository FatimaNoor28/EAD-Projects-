using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL;

namespace GPA_Calculator
{
    internal class Program
    {
        static void Main()
        {
            //StudentView view = new();
            int val;
            //while (true)
            //{
            //Console.WriteLine("\n\n1 ---- Enter Student Data\n2 ---- Output Student Data\n3 ---- Exit\nPlease select one of the above options: ");
            //String? s = Console.ReadLine();
            //if (s != null)
            //{
            //    val = int.Parse(s);

            //    switch (val)                                                                                                                                           
            //    {
            //        case 1:
            //            view.InputStudent();
            //            break;
            //        case 2:
            //            view.ShowStudent();
            //            Console.WriteLine("Press any key to go to main menu.....");
            //            Console.ReadKey();
            //            break;
            //        case 3:
            //            Environment.Exit(1);
            //            break;
            //    }
            //}
            //}
            val = getMaxNumbers();
            Console.WriteLine(val);
        }

        public static int getMaxNumbers(params int[] p)
        {
            return p.Length;
        }
    }
}
