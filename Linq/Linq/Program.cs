using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class ContactInfo
    {
        public string Name{get;set;      }
        public string Address { get; set; }
        public string Phone { get; set; }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            //define data set
            string[] names = { "ali", "Fatima", "Unaiza", "Laiba", "Haseeb", "Usama", "Faiza", "Fabeeha" };

            ContactInfo[] c = {
                new ContactInfo{Name = "Fatima", Address = "Sialkot", Phone = "03019788651"},
                new ContactInfo{Name = "Laiba", Address = "Sialkot", Phone = "090078601"},
                new ContactInfo{Name = "Unaiza", Address = "Lahore", Phone = "030012182121"},
                new ContactInfo{Name = "Haseeb", Address = "Lahore", Phone = "090078601"},
                new ContactInfo{Name = "Usama", Address = "Lahore", Phone = "090078601"}
            };

            //c.GroupBy(con => con.Address).Select(con => new { con.Key, NumberOfContacts = con.Count() }).ToList().ForEach(con => Console.WriteLine($"{con.Key}, {con.NumberOfContacts}"));

            c.GroupBy(con => con.Address).Select(con => new { con.Key, numberOfContacts = con.Count(p => p.Name.StartsWith("U")) }).ToList().ForEach(con => Console.WriteLine($"{con.Key}, {con.numberOfContacts}"));

            //using query syntax
            /*var query2 = from n in names
                         where n.StartsWith("F")
                         select n;
            foreach (var v in query2)
                Console.WriteLine(v);

            var query1 = from contact in c
                         where contact.Name.StartsWith("F") || contact.Name.StartsWith("U")
                         select contact.Name;
            foreach (var v in query1)
                Console.WriteLine(v);
*/

            //c.GroupBy(p => p.Address).Where(c => c.Address.Equals("Lahore"))
            //  .Where(contact => contact.Name.ToLower().StartsWith("u"))
            //  //.Select(obj => new { obj.Key, NoOfContacts = obj.Count(p => p.Address.Length > 4) })
            //  .ToList()
            //  .ForEach(ct => Console.WriteLine($"{ct.Key}, {ct.NoOfContacts}"));


            /*c.OrderByDescending(p => p.Name.Length).ThenBy(p => p.Name.StartsWith("F")).Select(p => p).ToList().ForEach(p => Console.WriteLine($"{p.Name}, {p.Address}, {p.Phone}"));

            names.OrderByDescending(p => p.ToLower().StartsWith("f")).ToList().ForEach(p => Console.WriteLine(p));
*/
            //(from n in names
            //        orderby n.ToLower().StartsWith("f")
            //         select n).ToList().ForEach(p => Console.WriteLine(p));



            //define query
            /*var query = names.Where(n => n != "ali").Where(n => n.Length > 3).Select(n => n).OrderByDescending(n => n);*/
            /*names.OrderBy(n => n.Length)
                .Where(name => name.ToLower().StartsWith("f"))
                //.Take(2)
                .Skip(2)
                .ToList()
                .ForEach(nm => Console.WriteLine(nm));
*/
            //          names.GroupBy(n => n).Select(p => new { p.Key, numberOfNames = p.Where(name => name.Length > 5).Count() }).ToList().ForEach(p => Console.WriteLine($"{ p.Key }, { p.numberOfNames}" ));
            //execute query
            /*            int i = 0;
                        foreach (var v in query)
                        {
                            Console.WriteLine("Q#"+i+" : "+v);
                            i++;
                        }
            */
            Console.ReadKey();
        }
    }
}
