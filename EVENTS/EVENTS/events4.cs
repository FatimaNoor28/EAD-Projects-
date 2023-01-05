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
//            public void calarea(calcul c)
//            {
//                if (c == null)
//                {
//                    c.c = calculatearea;
//                }

//                else
//                {
//                    c.c += calculatearea;
//                }


//            }



//           public void calculatearea(float a)
//            {
//                Console.WriteLine(3.14*a*a);
//            }


//        }
//        class CalCircumference
//        {
//            public void calcircumference(calcul c)
//            {
//                if (c == null)
//                {
//                    c.c = calculatecircumference;
//                }

//                else
//                {
//                    c.c += calculatecircumference;
//                }
//            }

//    public void calculatecircumference(float b)
//            {
//                Console.WriteLine(2*3.14*b);
//            }


//        }

//        public static void Main(string[] args)
//        {
//            calcul x = new calcul();
//            CalArea area = new CalArea();
//            CalCircumference circum = new CalCircumference();
//            area.calarea(x);
//            circum.calcircumference(x);
//            x.docals(3);
//        }


      
//    }
//}