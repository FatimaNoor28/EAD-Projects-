using Microsoft.IdentityModel.Tokens;

namespace EAD_Project.Models
{
    public class DoctorRepository
    {
        public bool Authenticate(string CNIC, string password)
        {

            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            if ((db.Doctors.Where(a => (a.CNIC.Equals(CNIC)) && a.Password.Equals(password)).ToList()).IsNullOrEmpty())
                return false;

            return true;
        }

        public bool SignUpDoctor(string CNIC, string username, int appointments, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            Doctor dr = new Doctor();
            
            if (db.Doctors.Where(x => (x.CNIC.Equals(CNIC)) && x.Password.Equals(password)).ToList().IsNullOrEmpty())
            {
                dr.Appointments = 0;
                dr.Password = password;
                dr.Name = username;
                dr.CNIC = CNIC;
                dr.ApointmentLimitPerDay = appointments;
                db.Doctors.Add(dr);
                if (db.SaveChanges() == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public Doctor findDoctor(string cnic, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            var p = db.Doctors.Where(a => (a.CNIC.Equals(cnic)) && a.Password.Equals(password)).Select(c => c).FirstOrDefault();
            
            return (Doctor)p;

        }
    }
}
