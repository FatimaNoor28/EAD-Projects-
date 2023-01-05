//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Linq; //library for linq queries
//namespace LINQ
//{
//    public class LINQ1
//    {
//        public static void Main(string[] args){
//            var names = new string[] { "Laiba", "Fatima", "Unaiza", "Aiman", "Sadia","Ali","Rida" };
//            //retreive names with lenght > 4
//            int i = 0;  
//            var query = names.Where(names_length_greater_than_4); //query is only defined here, not executed
//            var query1 = names.Where(names_length_greater_than_4).ToList(); //now query is executed and return a list of strings



//            foreach (var name in query)
//            {
//                i++;
//                Console.Write($"Name{i}: ");
//                Console.WriteLine(name);
//            }
          

//         for (var x = 0; x < query1.Count; x++) {
//               Console.WriteLine(query1[x]);
//                          }

           
//        }

//        static bool names_length_greater_than_4(string name)
//        {
//            return (name.Length > 4);
//        }


//    }
//}
