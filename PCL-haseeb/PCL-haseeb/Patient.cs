using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace PCL
{
    public class Patient
    {
        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string CNIC
        {
            get; set;

        }
        public int Phone_Number
        {
            get; set;
        }
        public string Disease
        {
            get; set;
        }
        public bool isAdmitted = false;
        public List<Patient> PatientsList = new List<Patient>();

        public void addPatient(Patient p)
        {
            PatientsList.Add(p);
            FileStream fp = new FileStream("Patients.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fp);
            sw.WriteLine(p.Id + ","
                + p.Name + ","
                + p.CNIC + ","
                + p.Phone_Number + ","
                + p.Disease + ","
                + p.isAdmitted + ",");
            sw.Close();
            fp.Close();

        }
        public void DeletePatient(int Id)
        {
            foreach (Patient k in PatientsList)
            {
                if (k.Id == Id)
                {
                    PatientsList.Remove(k);
                }
            }
        }

        public void UpdatePatient(int Id, Patient updatedObject)
        {
            foreach (Patient k in PatientsList)
            {
                if (k.Id == Id)
                {
                    k.Name = updatedObject.Name;
                    k.CNIC = updatedObject.CNIC;
                    k.Phone_Number = updatedObject.Phone_Number;
                    k.Disease = updatedObject.Disease;
                    k.isAdmitted = updatedObject.isAdmitted;

                }

            }

        }

        public void Displaylist()
        {
            foreach (Patient k in PatientsList)
            {
                Console.WriteLine(k);
            }
        }
        public override String ToString()
        {
            return Id + ","
                + Name + ","
                + CNIC + ","
                + Phone_Number + ","
                + Disease + ","
                + isAdmitted + ",";
        }
    }
}
