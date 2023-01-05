using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

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

        private double CalculateTAX (double sal)
        {
            return sal * 0.1; 
        }
    }
}
