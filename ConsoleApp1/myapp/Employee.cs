using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Employee
    {
        public String name;
        public String age;
        public String salary;
        public Employee(String name, String age, String salary)
        {
            this.name = name;
            this.age = age;
            this.salary = salary;

        }
        public String getName()
        {
            return name;
        }
        public String getAge()
        {
            return age;
        }
        public String getSalary()
        {
            return salary;
        }
        public override String ToString(){
            return name + ','+ age + ',' + salary;
        }
    }
}
