using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq; //library for linq queries
namespace LINQ
{
    public class LINQ1
    {
        public static void Main(string[] args)
        {
            var names = new string[] { "Laiba", "Fatima", "Unaiza","Unaizaa", "Aiman", "Sadia", "Ali", "Rida" };

            var q = names.Where(n => n.Length > 4).Select(n => n[..3]).OrderByDescending(x => x).ToList();

            //var query1 = names.Where(x => x.Length > 4).ToList(); //query is executed an d return a list of strings

            //using lemda expression instead of using function

         
            for (var x = 0; x < q.Count; x++)
            {
                Console.WriteLine(q[x]);
            }
            /*

            Console.WriteLine("\n");
*/
            //now using select method to show particular number of characters
            //now output is formatted
            //Console.WriteLine("SELECTING....");
            //var query2 = names.Where(x => x.Length > 4).Select(n => n.Substring(0, 2)).ToList(); //now query is executed and return a list of strings


            //var query2 = names.Where(x => x.Length > 4).Select(n => n[..4]).ToList();
            //now using lemda expression instead of using function


            //for (var x = 0; x < query2.Count; x++)
            //{
            //    Console.WriteLine(query2[x]);
            //}


            //now using orderby statement to sort in asc order
            //Console.WriteLine("ORDERING.....");
            //var query3 = names.Where(x => x.Length > 4).OrderBy(n=>n).ToList(); //now query is executed and return a list of strings
 
            //for (var x = 0; x < query3.Count; x++)
            //{
            //    Console.WriteLine(query3[x]);
            //}
            //Console.WriteLine("\n");



            //now using orderby statement to sort in desc order
            //Console.WriteLine("ORDERING BY DESCENDING....");
            //var query4 = names.Where(x => x.Length > 4).OrderByDescending(n => n).ToList(); //now query is executed and return a list of strings

            //for (var x = 0; x < query4.Count; x++)
            //{
            //    Console.WriteLine(query4[x]);
            //}
            //Console.WriteLine("\n");

            //now sort on 2 basis
            //Console.WriteLine("ORDERING BY DESCENDING AND LENGTH....");
            //var query5 = names.Where(x => x.Length > 4).OrderByDescending(n => n.Length).ThenBy(n=>n).ToList(); //now query is executed and return a list of strings

            //for (var x = 0; x < query5.Count; x++)
            //{
            //    Console.WriteLine(query5[x]);
            //}
            //Console.WriteLine("\n");

            //we can break queries
            //we can add some conditions on executing a particular query
            //we can use multiple select orderby etc
            //Console.WriteLine("MULITPLE LINES QUERY");
            //var query6 = names.Where(x => x.Length > 4);
            //bool choice = false;


           // if (choice == true)
           // {
           //     query6 = query6.OrderByDescending(n => n.Length).ThenBy(n => n).ToList(); //now query is executed and return a list of strings
           // }
           // else
           // {
           //     query6 = query6.Select(n => n.Substring(0, 3));
           // }
           // int i = 0;

           // foreach (var name in query6)
           // {
           //    i++;
           //   Console.Write($"Name{i}: ");
           //    Console.WriteLine(name);
           //}


        }


    }
}
