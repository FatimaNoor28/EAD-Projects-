using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates
{

    public delegate bool BooleanOperation(int x, int y);
    delegate bool Exist(int x, int[] y);
    delegate string Delegate(string name);
    delegate void d(string name);

    delegate void delegbe();

    delegate void EvenHandler(object sender, EventArgs e);
    public class myEventArgs : EventArgs
    {
        public object data { get; set; }
        public int count { get; set; }
    }
    //public delegate void Delegate(); // we pass sender and arguments using eventargs
    
    public class MyArray: ArrayList
    {

        public event EventHandler added;
        //public int cnt = 1;
        public void onAdded(object o)
        {
            //added?.Invoke(this, EventArgs.Empty);
            myEventArgs e = new myEventArgs();
            e.data = o;
            e.count = base.Count+1;
            //e.count = cnt++;
            //added(this, e); 
        }
        public override int Add(object value)
        {
            onAdded(value);
            return base.Add(value);
        }
    }


    public class Program
    {
        public static bool PerformOperations(BooleanOperation op, int x, int y) => op(x, y);


        public static bool isEqual(int x, int y)
        {
            return x == y;
        }
        public static bool isSmaller(int x, int y)
        {
            return x < y;
        }
        public static bool isLarge(int x, int y)
        {
            return x > y;
        }
        //        delegate void Delegate();
        //delegate int Delegate1(int x, int y);

        //public int f1(MathOp d, int x, int y)
        //{
        //    int r = d(x, y);
        //}

        //fire events on stack push and pop  H.W


        static void Main(string[] args)
        {

            //open file using path


            string filename = "test.txt";
            string path = Path.Combine(Environment.CurrentDirectory, filename);
            Console.WriteLine($"Path: {path}");
            Console.WriteLine($"Directory: {Path.GetDirectoryName(filename)}");
            Console.WriteLine($"file with extension: {Path.GetFileName(filename)}");
            StreamWriter sw = new StreamWriter(path, append: true);
            sw.WriteLine("this is a new line");
            sw.Close();

            
            Delegate d =  delegate (string n){
                Console.WriteLine(n);
                return n;
            };

            
            //d.Invoke();
            d += (string n) => n+" Noor" ;

            d += (string n) => n+"...";

            string name = d("Fatima");
            Console.WriteLine(name);




            delegbe d2 = () => Console.WriteLine("mahatma gandu");




            d d5 = (string n) => Console.WriteLine(n);




d e = delegate (string n)
{
    Console.WriteLine(n);
};
            e += (string n) =>
            {
                Console.WriteLine(n);
            };



            //            delegate e => (string n) => { Console.WriteLine("Name: " + n); };
            /*            d += (string n) => (Console.WriteLine(n));
            */

            /*MyArray arr = new MyArray();
            arr.Add(123);
            arr.Add("abc");
            Console.WriteLine(arr);
*/


            Action<int, string> a = Func;
            //a(5, "Done!");


            Func<int, int, int> f = someFunc;
            //Console.WriteLine( f(2,3) );



            Action<int, string, int, string> PersonalInfo = PersonalInformation;
            //PersonalInfo(28, "Fatima Noor", 21, "Lahore, Cantt");

            Func<int, string, int, string, int> person = PersonalInformation2;
            //person(1, "amna", 20, "Lahore");



            Exist op = isExist;
            int c, b;
            int[] y = { 1, 2, 0, 4 };
            Console.WriteLine("Enter op to be performed: ");
            int opr = System.Convert.ToInt32(Console.ReadLine());
            switch (opr)
            {
                case 0:
                    Console.WriteLine("Enter a number: ");
                    int r = System.Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine( op(r, y) );
                    break;
                case 1:
                    Console.WriteLine("Enter a: ");
                    c = System.Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter b: ");
                    b = System.Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"IsEqual: {PerformOperations(isEqual, c, b)}");
                    break;
                case 2:
                    Console.WriteLine("Enter a: ");
                    c = System.Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter b: ");
                    b = System.Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"IsSmaller: {Program.PerformOperations(isSmaller, c, b)}");
                    break;
            }            
            


            Console.ReadKey();
            //Delegate1 d1 = new Delegate1(sum);
            //int r = d1(1, 2);
            //Console.WriteLine($"Sum of {1} and {2} is {r}");
        }

        //public static int sum(int x, int y)
        //{
        //    return x + y;
        //}

        public static int PersonalInformation2(int id, string name, int age, string address)
        {
            Console.WriteLine($"Id: {id}, Name: {name}, Age: {age}, Address: {address}");
            return 1;
        }

        public static void PersonalInformation(int id, string name , int age, string address)
        {
            Console.WriteLine($"Id: {id}, Name: {name}, Age: {age}, Address: {address}");   
        }
        public static int someFunc(int x, int y)
        {
            return x + y;
        }
        public static void Func(int x, string y)
        {

            Console.WriteLine($"x:{x}, {y}");
        }

        

        
        public static bool isExist(int item, int[] arr)
        {
            foreach(var item2 in arr)
            {
                if(item2 == item)
                    return true;
            }
            return false;
        }



    }
}


//I got full scholarship in FSC, got yearly stipend for good grades in BCS, learned basic programming concepts in many languages and performed well in University, participated in Google Developer Student Club (GDSC) coding competition and in ICPC coding competition.

//    My goal for next 3 years is to like to learn and excel in my field and to be a good developer in a company (would be more than happy if it's Arbisoft).

    //I am really impressed by it's growth. It has grown so much in such short period of time. Only great leaders and great co-workers can make this possible. I would be so honored to be a part of Arbisoft.













/*
 * windows forms app
 * toolbox => drag button 
 * double click on button => function/Handler for that button will open
 * click on button => open properties OR right click and open properties OR from view -> open properties
 * select Mouse Click to double click
 *text -> change name //text property
 *username, password (text boxes)
 * color change property
 * MessageBox.show
 * textBox1.Text and textBox2.text
 * container controls -> tabs
 * menu control
 */








