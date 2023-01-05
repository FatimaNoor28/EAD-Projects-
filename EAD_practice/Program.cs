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
            //Console.WriteLine(sizeof(int));
            //Console.WriteLine($"int minimum {int.MinValue} bytes");
            //Console.WriteLine($"int minimum {int.MaxValue} bytes");

            //Console.WriteLine(sizeof(uint));
            //Console.WriteLine($"uint minimum {uint.MinValue} bytes");
            //Console.WriteLine($"uint minimum {uint.MaxValue} bytes");

            //Console.WriteLine(sizeof(ulong));

            //Console.WriteLine(sizeof(float));
            //Console.WriteLine($"float minimum {float.MinValue} bytes");
            //Console.WriteLine($"float minimum {float.MaxValue} bytes");

            //Console.WriteLine(sizeof(double));
            //Console.WriteLine($"double minimum {double.MinValue} bytes");
            //Console.WriteLine($"double minimum {double.MaxValue} bytes");

            ////Console.WriteLine(sizeof(decimal));
            //Console.WriteLine($"Size of decimal: {sizeof(decimal)}");
            //Console.WriteLine($"Decimal minimum: {decimal.MinValue} bytes");
            //Console.WriteLine($"Decimal maximum: {decimal.MaxValue} bytes");

            //A decimal variable uses 16 bytes of memory and can
            //store big numbers, but not as big as a double type.
            //range of decimal is smaller than double but size is bigger because it is used for accuracy

            //Console.WriteLine("\n\nusing doubles\n");
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
            Console.WriteLine(args.Length);
            for(int i=0;i<args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }


            Console.ReadKey();
        }
    }
}
