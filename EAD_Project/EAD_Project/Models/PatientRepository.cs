using Microsoft.IdentityModel.Tokens;
using System.Numerics;

namespace EAD_Project.Models
{
    public class PatientRepository
    {
        public PatientRepository() { }
        public bool Authenticate(int username, string password)
        {

            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            if ((db.Patients.Where(a => a.PatientId == username && a.Password.Equals(password)).ToList()).IsNullOrEmpty())
                return false;

            return true;
        }
        public bool SignUpPatient(int username, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            Patient patient = new Patient();
            patient.PatientId = username;
            patient.Password = password;
            db.Patients.Add(patient);
            db.SaveChanges();
            return (!db.Patients.Where(x => x.PatientId == username && x.Password.Equals(password)).ToList().IsNullOrEmpty());
        }
        public void MakeAppointment(string name, string CNIC, string phone, string date,string department, string doctor)
        {

        }
    }
}
