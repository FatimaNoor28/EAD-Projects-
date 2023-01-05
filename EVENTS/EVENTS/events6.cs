/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVENTS
{
    delegate void table();
    public class events5
    {
        class publisher
        {

            public event table tab = null;

            public void print_table()
            {
                tab.Invoke();

            }

        }

        class printrandomtable
        {
            public void rand(publisher p)
            {
               
                    p.tab += randtable;
                }

            

            public void randtable()
            {

                Random rnd = new Random();

                int x = rnd.Next(1, 10);

                for (int a = 1; a <= 10; a++)
                {
                    Console.WriteLine($"{x}x{a}= {x * a} ");
                }


            }
        }

        class usertable
        {
            public void user(publisher p)
            {
               
                {
                    p.tab += usertab;
                }
            }
            public void usertab()
            {
                Console.WriteLine("WHICH TABLE YOU WANT TO PRINT?");
                int x = int.Parse(Console.ReadLine());

                for (int a = 1; a <= 10; a++)
                {
                    Console.WriteLine($"{x}x{a}= {x * a} ");
                }
            }


        }*/

/*class program
{
    public static void Main(string[] args)
    {

        publisher p = new publisher();
        printrandomtable rand = new printrandomtable();
        usertable user = new usertable();

        rand.rand(p);
        user.user(p);

        p.print_table();

    }


}

}
}*/
//previous 2 problems are solved here using events