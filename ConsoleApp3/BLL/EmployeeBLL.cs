using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class EmployeeBLL
    {
        public void AddEmployee(EmployeeDTO dto)
        {
            dto.TAX = CalculateTAX(dto.Salary);
            EmployeeDAL dal = new EmployeeDAL();
            dal.SaveEmployee(dto);

        }

        private double CalculateTAX(double sal)
        {
            return sal * 0.1;
        }

        public List<EmployeeDTO> GetEmployees()
        {
            EmployeeDAL empDAL = new EmployeeDAL();
            List<EmployeeDTO> employees = empDAL.GetAllEmployees();
            return employees;

        }
    }
}
