using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.IO;

namespace DAL
{
    public class EmployeeDAL:BaseDAL
    {
        public void SaveEmployee(EmployeeDTO dto)
        {
            //StreamWriter sw = new StreamWriter("data.txt", append: true);
            String line = $"{dto.Name}; {dto.Salary}; {dto.TAX}";
            Save("data.txt",line);
            //sw.WriteLine(line);
            //sw.Close();
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            List<String> list = Read("data.txt");
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            foreach (String line in list)
            {
                string []temp = line.Split(';');
                EmployeeDTO employee = new EmployeeDTO
                {
                    Name = temp[0],
                    Salary = int.Parse(temp[1]),
                    TAX = double.Parse(temp[2])
                };
                employees.Add(employee);
            }
            return employees;


            //foreach(var v in list)
            //{
            //    string[] data = v.Split(';');
            //    EmployeeDTO employee = new EmployeeDTO()
            //    {
            //        Name = data[0],
            //        Salary=int.Parse(data[1]),
            //        TAX=double.Parse(data[2])
            //    };
            //}

        }
        
        
        
        
    }
}
