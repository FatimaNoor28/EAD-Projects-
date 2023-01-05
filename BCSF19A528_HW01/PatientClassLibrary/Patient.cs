using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PatientClassLibrary
{
    public class Patient
    {
        //task 1
        static List<Patient> _list = new List<Patient>();
        public static int id
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
            return id + ", " + name + ", " + cnic + ", " + phone_number + ", " + disease + ", " + isAdmitted;
        }

        //task 2
        public void AddPatient(Patient p)
        {
            FileStream fout = new FileStream("PatientsRecord.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fout);

            sw.WriteLine(p);

            _list.Add(p);
            sw.Close();
            fout.Close();

            /*String name, cnic, PhNo, disease, isAdmitted;
            Console.Write("Enter name of patient: ");
            name = Console.ReadLine();
            Console.WriteLine("\nEnter CNIC of patient: ");
            cnic = Console.ReadLine();
            Console.WriteLine("\nEnter Phone Number of patient: ");
            PhNo = Console.ReadLine();
            Console.WriteLine("\nEnter Disease of patient: ");
            disease = Console.ReadLine();
            Console.WriteLine("\nIs the patient admitted: ");
            isAdmitted = Console.ReadLine();
            */

        }

        //task 3
        public void deletePatient(int ID)
        {
            foreach (Patient p in _list)
            {
                if (id == ID)
                {
                    _list.Remove(p);
                    break;
                }
            }
            //patients.RemoveAt(id);
        }

        //task 4
        public async Task UpdatePatient(int ID, Patient updatedPatient)
        {
            Console.WriteLine("Update start");
            await Task.Delay(1000);
            await Task.Factory.StartNew(() =>
            {
                foreach (Patient p in _list)
                {
                    if (id == ID)
                    {
                        p.name = updatedPatient.name;
                        p.cnic = updatedPatient.cnic;
                        p.phone_number = updatedPatient.phone_number;
                        p.disease = updatedPatient.disease;
                        p.isAdmitted = updatedPatient.isAdmitted;
                        Console.WriteLine("Update End");
                        return;
                    }
                }
            });
            
        }
        //task 5
        public void SearchPatient(int ID)
        {
            foreach (Patient p in _list)
            {
                if (id == ID)
                {
                    //Console.WriteLine(p);
                    Console.WriteLine(id + ", " + p.name + ", " + p.cnic + ", " + p.phone_number + ", " + p.disease + ", " + p.isAdmitted);
                }
            }

        }

        //task 6
        public void DisplayAll()
        {
            FileStream fin = new FileStream("PatientsRecord.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fin);

            //List<Patient> list = new List<Patient>();
            //int counter = 0;
            String ln;
            while ((ln = sr.ReadLine()) != null)
            {
                String[] str = ln.Split(',');
                if (str[0] == "0")
                {
                    break;
                }
                //p = new Patient
                //{
                //    id = Int32.Parse(str[0]),
                //    name = str[1],
                //    cnic = str[2],
                //    phone_number = str[3],
                //    disease = str[4],
                //    isAdmitted = str[5]
                //};
                Console.WriteLine("ID: " + str[0] + "Name: " + str[1] + "CNIC: " + str[2] + "Phone Number: " + str[3] + "Disease: " + str[4] + "IsAdmitted: " + str[5]);
                //Console.WriteLine(p);
            }
            sr.Close();
            fin.Close();
        }
    }
}
