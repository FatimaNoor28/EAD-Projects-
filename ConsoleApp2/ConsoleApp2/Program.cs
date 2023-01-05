using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream f = new FileStream("PatientsRecord.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f);
            sw.Flush();
            sw.Close();
            f.Close();

            //sw.WriteLine("ID,  Name , ")
            int choice, ID;
            //Program p = new Program();
            String nm, num, cnic, dis, admit;
            Patient p = new Patient();

            while (true)
            {
                Console.WriteLine("Press 0 to Exit\n1. Add Patient\n2. Delete Patient\n3. Update Patient\n4. Search Patient\n5. Display All Patients");
                Console.Write("Enter your choice: ");
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.WriteLine("Enter Name of patient: ");
                        nm = Console.ReadLine();
                        Console.WriteLine("Enter CNIC of patient: ");
                        cnic = Console.ReadLine();
                        Console.WriteLine("Enter Phone Number of patient: ");
                        num = Console.ReadLine();
                        Console.WriteLine("Enter Disease of patient: ");
                        dis = Console.ReadLine();
                        Console.WriteLine("Is the patient admitted? (yes/no) : ");
                        admit = Console.ReadLine();
                        Patient pt = new Patient
                        {
                            id = Patient.count,
                            name = nm,
                            cnic = cnic,
                            phone_number = num,
                            disease = dis,
                            isAdmitted = admit,

                        };
                        p.AddPatient(pt);
                        Console.WriteLine("Patient Record added\n");
                        break;
                    case 2:
                        Console.Write("Enter the ID of patient: ");
                        ID = Int32.Parse(Console.ReadLine());
                        p.deletePatient(ID);
                        Console.WriteLine("Patient record deleted\n");
                        break;
                    case 3:
                        Console.Write("Enter ID of patient u want to update: ");
                        ID = Int32.Parse(Console.ReadLine());
                        Console.Write("Enter Name of patient: ");
                        nm = Console.ReadLine();
                        Console.Write("Enter CNIC of patient: ");
                        cnic = Console.ReadLine();
                        Console.Write("Enter Phone Number of patient: ");
                        num = Console.ReadLine();
                        Console.Write("Enter Disease of patient: ");
                        dis = Console.ReadLine();
                        Console.Write("Is the patient admitted? (yes/no) : ");
                        admit = Console.ReadLine();
                        pt = new Patient
                        {
                            name = nm,
                            cnic = cnic,
                            phone_number = num,
                            disease = dis,
                            isAdmitted = admit,

                        };
                        p.UpdatePatient(ID, pt);
                        Console.WriteLine("Patient record updated");
                        break;

                    case 4:
                        Console.Write("Enter ID of patient u want to Search: ");
                        ID = Int32.Parse(Console.ReadLine());
                        p.SearchPatient(ID);
                        break;
                    case 5:
                        p.DisplayAll();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
