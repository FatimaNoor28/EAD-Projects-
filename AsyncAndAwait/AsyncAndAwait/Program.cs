using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using SomeLibrary;

namespace AsyncAndAwait
{
    delegate void EventStart(object sender, string s);
    delegate void EventStop();

    class publisher
    {
        public event EventStart start;
        public event EventStop stop;
        public void onStart()
        {
            Console.WriteLine("Event has been started");
            
            start(this, "start");
        }
        public void OnStop()
        {
            Console.WriteLine("Event has been stopped");
            stop();
        }
    }
    internal class Program
    {
        
        

        static async Task Main(string[] args)
        {
            Console.WriteLine($"Main Thread ID : {Thread.CurrentThread.ManagedThreadId}");
            //var task1=   Task.Run(library.LongRunningOpration);
            //var t2= Task.Run(SomeLibrary.LongRunningOprationWithData);
            //var t3 = Task.Run(() => SomeLibrary.LongRunningOprationWithInputData(5));


            //  Console.WriteLine(  await t2);
            // Console.WriteLine(await t3);
            //var t4 = Task.Run(CPUIntensiveTask);
            //await t4;


            publisher p = new publisher();
            p.start += CPUIntensiveTask;
            p.stop += f;
            p.onStart();
            p.OnStop();







            Console.ReadKey();
        }

        static void CPUIntensiveTask(object sender, string s)
        {
            
            Console.WriteLine($"CPUIntensiveTask starts");
            Console.WriteLine($"CPUIntensiveTask Thread ID : {Thread.CurrentThread.ManagedThreadId}");
            //Thread.Sleep(5000);
            Console.WriteLine($"CPUIntensiveTask finish");
            Console.WriteLine($"Sender is : {sender}");
            Console.WriteLine($"string is: {s}");

        }
        public static void f()
        {
            Console.WriteLine("F function");
        }

    }
}
