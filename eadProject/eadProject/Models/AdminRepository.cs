using Microsoft.IdentityModel.Tokens;
namespace eadProject.Models
{
    public class AdminRepository
    {
        public AdminRepository() { }
        public bool Authenticate(string username, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if ((db.Admins.Where(a => a.CNIC.Equals(username) && a.Password.Equals(password)).ToList()).IsNullOrEmpty())
                return false;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return true;
        }
        public int FindAdminId(string username, string password)
        {

            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var a = db.Admins.Where(a => (a.CNIC.Equals(username)) && a.Password.Equals(password)).Select(c => c.AdminId).FirstOrDefault();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            /* int p = System.Convert.ToInt32( db.Patients.Where(a => (a.CNIC.Equals(username)) && a.Password.Equals(password)).Select(p=>p.Id));*/
            return (int)a;


        }
        public string? find_AdminName(string username, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var p = db.Admins.Where(predicate: a => a.CNIC.Equals(username) && a.Password.Equals(password)).Select(c => c.Name).FirstOrDefault();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return (string?)p;
        }
        public bool SignUpAdmin(string CNIC, string Name, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (db.Admins.Where(x => x.CNIC.Equals(CNIC)).ToList().IsNullOrEmpty())
            {
                Admin admin = new Admin();


                admin.Name = Name;
                admin.CNIC = CNIC;
                admin.Password = password;
                db.Admins.Add(admin);
                db.SaveChanges();
            }
            else
            {
                return false;
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return (!db.Admins.Where(x => x.CNIC.Equals(CNIC) && x.Password.Equals(password)).ToList().IsNullOrEmpty());
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        }

        public Patient? find_Patient(int id)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            var p = db.Patients.Where(a => (a.Id == id)).FirstOrDefault();
            return (Patient?)p;
        }
        public void RemovePatient(int id)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            Patient? p = db.Patients.Where(a => (a.Id == id)).Select(c => c).FirstOrDefault();
            db.Patients.Remove(p);
            db.SaveChanges();
        }
        public List<Patient> GetAllPatients()
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            List<Patient> p = db.Patients.Where(a => a.Id > 0).ToList();

            return p;

        }

        public bool updatePatient(int id, string name, string cnic, string passwoord)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Patient p = db.Patients.Where(p => p.Id == id).FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (!name.IsNullOrEmpty())
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                p.Name = name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            if (!cnic.IsNullOrEmpty())
                p.CNIC = cnic;
            if (!passwoord.IsNullOrEmpty())
                p.Password = passwoord;
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

    }
}
