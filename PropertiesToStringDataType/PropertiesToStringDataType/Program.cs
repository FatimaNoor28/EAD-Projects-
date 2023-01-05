using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesToStringDataType
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Name = "Ali";
            p.Address = "Lahore";
            p.Age = 23;
            Console.WriteLine(p);
            Person p1 = new Person();
            p1.Name = "Fatima";
            p1.Age = 21;
            Person p2 = new Person();
            p2.Name = "Maham";
            p2.Address = "Cantt Lahore";

            List<Person> lst = new List<Person>();
            lst.Add(p);
            lst.Add(p1);
            lst.Add(p2);

            foreach (Person obj in lst)
            {
                Console.WriteLine(obj);
            }

            int[] x = { 1, 2, 23, 45, 56, 10 };
            foreach (int i in x)
            {
                Console.WriteLine(i);
            }

            int y = 10;
            var z = y;
            Console.Write("\n y:" + y);
            Console.WriteLine(",var z: " + z);
            dynamic a = "hello!";
            Console.WriteLine("Dynamic a: " + a);
            a = 2.5f;
            Console.WriteLine("Dynamic a: " + a);

            Program pro = new Program();
            Console.WriteLine("Max of 5 and 10 is: " + pro.getMax(5, 10));
            Console.WriteLine("Max of 10,50,30 is: " + pro.getMax(10,50,30));


            Console.ReadKey();
        }

        public int getMax(params int[] data)
        {
            return data.Length;
        }

        //public int getMax(int a, int b, int c) {
        //    if(a>b && a > c)
        //    {
        //        return a;
        //    }
        //    else if(b>a && b > c)
        //    {
        //        return b;
        //    }
        //    else
        //    {
        //        return c;
        //    }
        //}

    }
}
