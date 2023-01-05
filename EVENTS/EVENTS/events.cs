//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Metadata.Ecma335;
//using System.Text;
//using System.Threading.Tasks;

//namespace EVENTS
//{
//    public delegate void EventHandle(object sender, myArgs e);
//    public delegate void publishMessageDel(string msg);
//    public delegate void myEventHandler();

//    public class myArgs: EventArgs
//    {
//        public int count { get; set;}
//    }
//    public class button : ArrayList
//    {
//        //public event EventHandle click;
//        //public publishMessageDel messsage = null;

//        public event EventHandle added;
//        myArgs a = new myArgs();

//        public button()
//        {
//            a.count = 0;
//        }

//        public void OnAdded()
//        {
//            if (added != null)
//            {
//                a.count++;
//                added(this,a);
//            }
//        }

//        public override int Add(object o)
//        {
//            int i = base.Add(o);
//            OnAdded();
//            return i;
//        }
//        /*public void publishMsg(string msg)
//        { 
//            messsage.Invoke(msg);
//        }
//        public void onClick()
//        {
//            click();
//        }*/
//    }









///*
//    delegate void clicking();
//    internal class publisher    //who raises events 
//    {
//        public event clicking click;

//        public  void onclick()
//        {
//            click();
//        }

//    }
//    internal class subscriber
//    {
//        public static void handler1()
//        {
//            Console.WriteLine("EVENT IS CAUGHT");
//        }
//    }*/





//    public class subscriber
//    {
//        public void subscribe(button b)
//        {
//            b.added += (object o, myArgs arg) => { Console.WriteLine($"Sender is: {o} and count is: {arg.count}"); };

//        }
//        //public void display(object o)
//        //{
//        //    Console.WriteLine($"object {o} has been added");
//        //}
//    }
//    public  class eventss
//    {
//        //static void f()
//        //{
//        //    Console.WriteLine("Event called f");
//        //}
//        //static void g() { Console.WriteLine("event called g");  }
//       static void Main(string[] args)
//        {
//            /*publisher p = new publisher();
//            p.click += subscriber.handler1;

//            p.onclick();*/
//            button b = new button();
//            //b.click += f;
//            //b.click += g;
//            //b.onClick();
//            subscriber s = new subscriber();
//            s.subscribe(b);
//            b.Add(123);
//            b.Add("abc");
//            Console.WriteLine(b[1]);
//        }
//    }
//} 
