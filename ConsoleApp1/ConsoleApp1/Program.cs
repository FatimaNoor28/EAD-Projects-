using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            FileStream fin = new FileStream("test.txt", FileMode.Open);
            fin.Flush();
            fin.Close();
            //int x = 0;
            //while (x != -1)
            //{
            //    x = fin.ReadByte();
            //    fout.WriteByte((Byte)x);
            //}
            //fin.Close();
            //fout.Close();
            int choice;
            String name, age, sal;
            Employee e1 = new Employee("Fatima", "21", "90000");
            Employee e2 = new Employee("Sana", "20", "60000");
            Employee e3 = new Employee("Humna", "23", "30000");
            Employee e4 = new Employee("Maryam", "22", "3000000");
            List<Employee> lst = new List<Employee>();
            lst.Add(e1);
            lst.Add(e2);
            lst.Add(e3);
            lst.Add(e4);

            choice = 0;
            Program p = new Program();
            while (choice != 3)
            {
                Console.WriteLine("Press 0 to Write List of Employees\nPress 1 to Read File\nPress 2 to Add an Employee\nPress 3 to exit");
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        p.WriteList(lst);
                        Console.WriteLine("List added");
                        break;
                    case 1:
                        List<Employee> list= p.Read();
                        p.Print(list);
                        break;
                    case 2:
                        Console.WriteLine("Enter Name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter Age: ");
                        age = Console.ReadLine();
                        Console.WriteLine("Enter Salary: ");
                        sal = Console.ReadLine();
                        Employee e = new Employee(name, age, sal);
                        p.Write(e);
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            //Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }

    public void WriteList(List<Employee> e)
    {
        FileStream fout = new FileStream("test.txt", FileMode.Append);
        StreamWriter sw = new StreamWriter(fout);
        for(int i=0; i < e.Count; i++)
            {
                Console.WriteLine(e[i]);
                sw.WriteLine(e[i]);
            }
        
        sw.Close();
        fout.Close();
    }
        public void Write(Employee e)
        {
            FileStream fout = new FileStream("test.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fout);
            Console.WriteLine(e);
            sw.WriteLine(e);
            sw.Close();
            fout.Close();
    }
    public List<Employee> Read()
        {
            FileStream fin = new FileStream("test.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fin);
            List<Employee> list = new List<Employee>();
            //int counter = 0;
            String ln;
            while((ln = sr.ReadLine()) != null)
            {
                String[] str = ln.Split(',');
                Employee e = new Employee(str[0], str[1], str[2]);
                list.Add(e);
            }
            // Read the file and display it line by line.  
            sr.Close();
            fin.Close();
            return list;
        }
    public void Print(List<Employee> list)
        {
            for(int i=0; i<list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
