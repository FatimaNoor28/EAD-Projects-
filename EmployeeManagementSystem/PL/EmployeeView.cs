using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using BLL;
namespace PL
{
    public class EmployeeView
    {
        public void InputEmployee()
        {
            Console.Write("Enter Name: ");
            String name = Console.ReadLine();

            Console.Write("Enter salary: ");
            int sal = int.Parse(Console.ReadLine());

            EmployeeDTO dto = new EmployeeDTO
            {
                Name = name,
                Salary = sal
            };

            EmployeeBLL bll = new EmployeeBLL();
            bll.AddEmployee(dto);
        }
    }
}
