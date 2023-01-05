using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAD_Lecture1To7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object myseconddata = "String";
            int lengthofmyanotherstring = ((string)myseconddata).Length;
            Console.WriteLine(lengthofmyanotherstring);

            dynamic x = "str";
            int y = x.Length;
            Console.WriteLine(y);

            //Console.Write("Press any key combination: ");
            //ConsoleKeyInfo key = Console.ReadKey();
            //Console.WriteLine();
            //Console.WriteLine(
            //    format:"key: {0}, char: {1}, modifier: {2}",
            //    arg0: key.Key,
            //    arg1:key.KeyChar,
            //    arg2:key.Modifiers
            //    );
            Console.WriteLine(typeof(int));

            //console.writeline(sizeof(int)); 4
            //Console.WriteLine($"int minimum {int.MinValue} bytes");
            //Console.WriteLine($"int minimum {int.MaxValue} bytes");

            //Console.WriteLine(sizeof(uint)); 4
            //Console.WriteLine($"uint minimum {uint.MinValue} bytes");
            //Console.WriteLine($"uint minimum {uint.MaxValue} bytes");

            //Console.WriteLine(sizeof(ulong));

            //Console.WriteLine(sizeof(float)); 8
            //Console.WriteLine($"float minimum {float.MinValue} bytes");
            //Console.WriteLine($"float minimum {float.MaxValue} bytes");

            //Console.WriteLine(sizeof(double)); 8
            //Console.WriteLine($"double minimum {double.MinValue} bytes");
            //Console.WriteLine($"double minimum {double.MaxValue} bytes");

            ////Console.WriteLine(sizeof(decimal));  16
            //Console.WriteLine($"Size of decimal: {sizeof(decimal)}");
            //Console.WriteLine($"Decimal minimum: {decimal.MinValue} bytes");
            //Console.WriteLine($"Decimal maximum: {decimal.MaxValue} bytes");

            //A decimal variable uses 16 bytes of memory and can
            //store big numbers, but not as big as a double type.
            //range of decimal is smaller than double but size is bigger because it is used for accuracy

            //Console.WriteLine("\n\n using doubles\n");
            //double a = 0.2;
            //double b = 0.3;
            //if((a+b) == 0.5)
            //{
            //    Console.WriteLine("0.2 + 0.3 is:" + (a + b));
            //}
            //else
            //{
            //    Console.WriteLine("0.2 + 0.3 is not equal to 0.5");

            //}
            //Console.WriteLine("using decimals\n");
            //decimal c = 0.2M;
            //decimal d = 0.3M;
            //Console.WriteLine($"0.2M + 0.3M is: {c + d}");

            //int? x = null;
            //Console.WriteLine(x.GetValueOrDefault());
            //x = 7;
            //Console.WriteLine(x.GetValueOrDefault());
            //x = null;
            //Console.WriteLine(x.GetValueOrDefault());

            //bool? happy = null;
            //Console.WriteLine("happy: "+happy.GetValueOrDefault());
            //char? abc = null;
            //Console.WriteLine(abc.GetValueOrDefault());
            //String xyz;
            //Console.WriteLine(xyz);


            // lecture 3
            //int population = 66_000_000; //66 Million
            //Console.WriteLine(population);

            //Console.WriteLine(default(bool));
            //Console.WriteLine(default(string));
            //Console.WriteLine(default(int));
            //Console.WriteLine(default(decimal));

            //object str = "this is a string";
            //Console.WriteLine(((string)str).Length);

            //dynamic v = 12.4f;
            //Console.WriteLine(args.Length);
            //for(int i=0;i<args.Length; i++)
            //{
            //    Console.WriteLine(args[i]);
            //}


            //lecture 4
            //numbered positional format
            //    string argument1 = "Fatima";
            //    string argument2 = "PUCIT";
            //    Console.WriteLine(
            //        format: "{0} studies in: {1}",
            //        arg0:argument1,
            //        arg1: argument2

            //        );
            //string apple = "apple";
            //int price = 200000;
            //Console.WriteLine(
            //    format: "{0,-8} {1,8:N0}",
            //    arg0: apple,
            //    arg1: price
            //);
            //Console.WriteLine(
            //        format: "{0,-8} {1,8}",
            //        arg0: argument1,
            //        arg1: argument2
            //        );

            //    String abc = String.Format(
            //        format: "{0,-8} {1,8}",
            //        arg0: argument1,
            //        arg1: argument2);


            //ConsoleKeyInfo key = Console.ReadKey();
            //Console.WriteLine();
            //Console.WriteLine(
            //    format: "{0} {1} {2}",
            //    arg0: key.Key,
            //    arg1: key.KeyChar,
            //    arg2: key.Modifiers);



            //lecture 6
            //object o = 100;
            //int k;

            //comparison method 1

            //if (o.GetType() == typeof(int))
            //{
            //    Console.WriteLine(o.GetType());
            //    k = (int)o;
            //    Console.WriteLine(k);
            //}


            //method 2
            //if (o is int)
            //{
            //    k  = (int)o;
            //    Console.WriteLine(k);
            //}
            //else if(o is long)
            //{
            //    long l = (long)o;
            //    Console.WriteLine(l);
            //}
            //else
            //{
            //    float f = (float)o;
            //    Console.WriteLine(f);
            //}

            ////method 3
            //object a = "this is a string";
            //if(a is int i)
            //{
            //    Console.WriteLine(i);
            //}
            //else if(a is string s)
            //{
            //    Console.WriteLine(s);
            //}


            //do while
            //var n = new Random().Next(1, 12);
            //do
            //{
            //    Console.WriteLine($"my random number is {n}");
            //    if (n < 5)
            //    {
            //        Console.WriteLine("Less than 5");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Greater than 5");
            //    }
            //} while ((n = (new Random()).Next(1, 10)) < 5);

            //Switch expression

            //var num = new Random().Next(1, 6);
            //var operation = 5;

            //var result = num switch
            //{
            //    1 => "Case 1",
            //    2 => "Case 2",
            //    3 => "Case 3",
            //    4 => "Case 4",
            //    _ => "No case availabe"
            //};
            //Console.WriteLine(result);

            //Console.WriteLine(Math.Round(value: 10.5, digits: 0, mode: MidpointRounding.AwayFromZero));



            int age = int.Parse("27");
            DateTime birthday = DateTime.Parse("4 July 1980");
            Console.WriteLine($"I was born {age} years ago.");
            Console.WriteLine($"My birthday is {birthday}.");
            Console.WriteLine($"My birthday is {birthday:D}.");

            int i = (int)10.5;
            Console.WriteLine(i);
            String str = "100";
            int count = 0;
            if (int.TryParse(str, out count))
            {
                Console.WriteLine(count);
            }
            else
            {
                Console.WriteLine("couldn't parse");
            }
            Console.WriteLine($"int range is from {int.MinValue} to {int.MaxValue}");

            int z = int.MaxValue - 1;
            checked
            {
                Console.WriteLine($"Initial value: {z}");
                z++;
                Console.WriteLine($"After incrementing: {z}");
                z++;
                Console.WriteLine($"After incrementing: {z}");
                z++;
                Console.WriteLine($"After incrementing: {z}");

            }



            Console.ReadKey();
        }
    }
}
