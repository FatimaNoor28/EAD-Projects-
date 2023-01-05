using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesToStringDataType
{
    class Person
    {
        private String name;
        private String address;
        private int age;


        public Person() { }
        Person(String nm, int age, String addr)
        {
            name = nm;
            this.age = age;
            address = addr;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public override String ToString()
        {
            return "Name: " + name + ", Age: " + age + ", Address: " + address;
        }
    }
}
