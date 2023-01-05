using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVENTS
{
    public delegate void InputData(object sender, MyArg a);

    public class MyArg : EventArgs{
        public int count { get; set; }
    }
    
    public class Publisher: ArrayList
    {
        MyArg arg = new MyArg();
        
        public event InputData Added;
        public Publisher()
        {
            arg.count = 0;
        }

        public void OnAdded(object o, object sender)
        {
            arg.count++;
            Console.WriteLine($"{o} has been added");
            Added(sender, arg);
        }
        public override int Add(object o)
        {
            OnAdded(o, this);
            return base.Add(o);
        }
    }

    class Subscriber
    {
        public void Subscribe(Publisher p)
        {
            //p.Added += func;
            
        }
        public void func()
        {
            Console.WriteLine("Event occurred");
        }
    }

    public class Calling
    {
        public static void Main(string[] args)
        {
            Publisher publisher= new Publisher();
            Subscriber s = new Subscriber();
            //s.Subscribe(publisher);
            publisher.Added += (object o, MyArg arg) => Console.WriteLine($"Object added by {o.ToString()} and count of args is {arg.count}");

            publisher.Add(123);
            publisher.Add("abc");
            publisher.Add(2.5f);

            //Console.ReadKey();
        }
    }

}

//    delegate void generator(string message);
//    public class event2
//    {
//       class publisher
//        {
//            public generator gen = null;

//            public void showmsg(string text)
//            {
//                gen.Invoke(text);
//            }

//        }


//        public class subscriberupper
//        {
//            public void toupper(string msg)
//            {
//                Console.WriteLine(msg.ToUpper());

//            }

//        } 
//        public class subscriberlower
//        {
//            public void tolower(string msg)
//            {
//                Console.WriteLine(msg.ToLower());

//            }

//        }
//        public static void Main(string[] args)

//        {
//            publisher p = new publisher();
//            subscriberupper u = new subscriberupper();      
//            subscriberlower l = new subscriberlower();
//            p.gen = u.toupper;
//            p.gen += l.tolower;

//            p.showmsg("i Am LaiBA aHmeD");
//        }
//    }
//}
