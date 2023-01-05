//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EVENTS
//{

//    delegate void calculator(float radius);
//    public class events3
//    {   
//      class calcul
//        {
//           public calculator c = null;  

//            public void docals(float r)
//            {
//                c.Invoke(r);
//            }
//        }

//        class CalArea
//        {
//           public void calculatearea(float a)
//            {
//                Console.WriteLine(3.14*a*a);
//            }


//        }
//        class CalCircumference
//        {
//            public void calculatecircumference(float b)
//            {
//                Console.WriteLine(2*3.14*b);
//            }


//        }

//        public static void Main(string[] args)
//        {
//            calcul x = new calcul();
//            CalArea area = new CalArea();
//            CalCircumference circum = new CalCircumference();
//            x.c = area.calculatearea;
//            x.c += circum.calculatecircumference;
//            x.docals(3);
//        }


      
//    }
//}