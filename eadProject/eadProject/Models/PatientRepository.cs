using eadProject.Models;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.IdentityModel.Tokens;

namespace eadProject.Models
{
    public class PatientRepository
    {
        public PatientRepository() { }
        public bool Authenticate(string username, string password)
        {

            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            if ((db.Patients.Where(predicate: a => (a.CNIC.Equals(username)) && a.Password.Equals(password)).ToList()).IsNullOrEmpty())
                return false;

            return true;
        }
        public int find_Patient(string username, string password)
        {

            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            var p = db.Patients.Where(a => (a.CNIC.Equals(username)) && a.Password.Equals(password)).Select(c => c.Id).FirstOrDefault();
            /* int p = System.Convert.ToInt32( db.Patients.Where(a => (a.CNIC.Equals(username)) && a.Password.Equals(password)).Select(p=>p.Id));*/
            return (int)p;


        }
        public string find_PatientName(string username, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            var p = db.Patients.Where(a => (a.CNIC.Equals(username)) && a.Password.Equals(password)).Select(c => c.Name).FirstOrDefault();
            return (string)p;
        }
        public bool SignUpPatient(string CNIC, string username, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            Patient patient = new Patient();
            //patient.PatientId = username;
            if (db.Patients.Where(x => (x.CNIC.Equals(CNIC))).ToList().IsNullOrEmpty())
            {
                patient.Password = password;
                patient.Name = username;
                patient.CNIC = CNIC;
                db.Patients.Add(patient);
                if (db.SaveChanges() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        public List<Patient> GetAllAppointments(string username)
        {
            List<Patient> patients = new List<Patient>();
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            DateTime CurrentDate = DateTime.Now;/*.ToString("dd/MM/yyyy")*/
            DateOnly d = DateOnly.FromDateTime(CurrentDate);
            //DateOnly.TryParseExact(CurrentDate, "dd/MM/yyyy",d);

            Console.WriteLine(d);

            var p = db.Patients.Select(p => p.CNIC.Where(p => p.Equals(username)))/*.Where(p=> DateOnly.Parse(p.AppointmentDate) >= d )*/;



            return patients;
        }

    }
}