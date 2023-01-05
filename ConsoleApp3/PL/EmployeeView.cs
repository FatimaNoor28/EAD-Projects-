using System;
using DTO;
using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Employee added");
        }

        public void ShowEmployees()
        {
            EmployeeBLL bll = new EmployeeBLL();
            List<EmployeeDTO> list = bll.GetEmployees();
            foreach(EmployeeDTO dto in list)
            { 
                Console.WriteLine($"Name: { dto.Name }");
                Console.WriteLine($"Salary: {dto.Salary}");
                Console.WriteLine($"TAX: {dto.TAX}");
            }
        }
    }
}
