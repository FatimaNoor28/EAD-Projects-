using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Patient
    {
        //task 1
        static List<Patient> _list = new List<Patient>();
        public static int count = 0;
        public int id
        {
            get;
            set;
        }
        public String name
        {
            get;
            set;
        }
        public String cnic
        {
            get;
            set;
        }
        public String phone_number
        {
            get;
            set;
        }
        public String disease
        {
            get;
            set;
        }
        public String isAdmitted
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "\nName: " + name + "\nCNIC: " + cnic + "\nPhone: " + phone_number + "\nDisease: " + disease + "\nCurrently Admitted: " + isAdmitted;
        }

        public Patient()
        {
            _list = new List<Patient>();
        }
        //task 2
        public void AddPatient(Patient p)
        {
            count = count + 1;
            FileStream fout = new FileStream("PatientsRecord.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fout);
            p.id = count;
            Console.WriteLine(count);
            sw.WriteLine(p);
            _list.Add(p);
            sw.Close();
            fout.Close();

        }

    }
}
