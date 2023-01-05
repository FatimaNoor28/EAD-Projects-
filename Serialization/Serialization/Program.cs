using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { 
                Name = "Ali",
                Id = 123
            };

            String JsonString = JsonSerializer.Serialize(p);
            Console.WriteLine(JsonString);

            Person p2 = JsonSerializer.Deserialize<Person>(JsonString);
            Console.WriteLine(p2.Name);
            Console.WriteLine(p2.Id);
            Console.ReadKey();
        }
    }
}
