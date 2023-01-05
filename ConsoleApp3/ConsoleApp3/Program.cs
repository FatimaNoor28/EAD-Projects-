using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeView view = new EmployeeView();
            //view.InputEmployee();

            view.ShowEmployees();

            Console.ReadKey();

        }
    }
}