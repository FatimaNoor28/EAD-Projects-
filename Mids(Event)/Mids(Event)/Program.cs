using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mids_Event_
{
    public delegate void EventDelegate(string msg);

    class Temperature { 
        public int Temp { get; set; }
        public Temperature(int temp) {
            this.Temp = temp;
        }
    }
    public class Publisher
    {
        //define event
        public event EventDelegate Abc;
        
        //fire event
        public void PublisherFunc()
        {
            string remarks;
            Temperature t = new Temperature(100);
            //write code
            if (t.Temp >= 80 && t.Temp <= 150)
                remarks = "OK";
            else
                remarks = "Need Improvement";
            PublisherFunc2(remarks); 
        }

        public void PublisherFunc2(string message) { 
        //write code
            Abc(message);
        }

    }

    public class FileHandling
    {
        StreamWriter streamWriter = null;
        public void FileOpen(string filename)
        {
            //write code
            streamWriter = new StreamWriter(filename);

        }
        public void WriteToFile(string message)
        {
            streamWriter.WriteLine(message);
            CloseFile();
        }
        public void CloseFile()
        {
            streamWriter?.Close();
        }
    }
    internal class Program
    {
        static void Main()
        {
            Publisher p = new Publisher();
            FileHandling fh = new FileHandling();

            fh.FileOpen("testFile.txt");
            //register event using lambda expression
            p.Abc += (string message) => Console.WriteLine(message);
            //register function from fileHandling class
            p.Abc += fh.WriteToFile;
            //invoke event
            p.PublisherFunc();
            //fh.CloseFile();
            Console.ReadKey();
        }
    }
}
