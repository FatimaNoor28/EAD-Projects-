//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EVENTS
//{
//    delegate void table();
//    public class events5
//    {
//        class publisher {
            
//            public table tab = null;

//            public void print_table()
//            {
//                tab.Invoke();

//            }

//         }

//        class  printrandomtable
//        {
//            public void rand(publisher p)
//            {
//                if (p.tab == null){

//                    p.tab = randtable;        
                
//                }
//                else{
//                    p.tab += randtable;
//                }

//            }

//           public void randtable()
//            {

//                Random rnd = new Random();
         
//                int x = rnd.Next(1, 10);

//                for (int a=1; a <= 10; a++)
//                {
//                    Console.WriteLine($"{x}x{a}= {x*a} ");
//                }


//            }
//        }

//        class usertable
//        {
//            public void user(publisher p)
//            {
//                if (p.tab == null)
//                {

//                    p.tab = usertab;

//                }
//                else
//                {
//                    p.tab += usertab;
//                }
//            }
//            public void usertab()
//            {
//                Console.WriteLine("WHICH TABLE YOU WANT TO PRINT?");
//                int x = int.Parse(Console.ReadLine());  

//                for (int a = 1; a <= 10; a++)
//                {
//                    Console.WriteLine($"{x}x{a}= {x * a} ");
//                }
//            }


//}

//        class program
//        {
//           public static void Main(string[] args)
//            {
                 
//                publisher p = new publisher();  
//                printrandomtable rand = new printrandomtable();
//                usertable user = new usertable();   
               
//                rand.rand(p);
//                user.user(p);

//                p.print_table();

//            }


//        }

//    }
//}
////it has 2 disadvantages
////first is that you can five null to a delegate in subscriber class
////second invoke fucntion anywhere in subscriber class or main i.e subscriber can fire events