using Microsoft.IdentityModel.Tokens;

namespace EAD_Project.Models
{
    public class AdminRepository
    {
        public AdminRepository() { }
        public bool Authenticate(string username, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            if ((db.Admins.Where(a => a.CNIC.Equals(username) && a.Password.Equals(password)).ToList()).IsNullOrEmpty())
                return false;
            return true;
        }
        public int FindAdminId(string username, string password)
        {

            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            var a = db.Admins.Where(a => (a.CNIC.Equals(username)) && a.Password.Equals(password)).Select(c => c.AdminId).FirstOrDefault();
            /* int p = System.Convert.ToInt32( db.Patients.Where(a => (a.CNIC.Equals(username)) && a.Password.Equals(password)).Select(p=>p.Id));*/
            return (int)a;


        }
        public bool SignUpAdmin(string CNIC, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            Admin admin = new Admin();
            //int? id =db.Admins.Max(a=>(int?)a.AdminId);
            //if (id == null) {
            //    admin.AdminId = 1;
            //} else
            //{
            //    admin.AdminId = (int)id + 1;
            //}
            

            admin.CNIC = CNIC;
            admin.Password = password;
            db.Admins.Add(admin);
            db.SaveChanges();
            return (!db.Admins.Where(x => x.CNIC.Equals(CNIC) && x.Password.Equals(password)).ToList().IsNullOrEmpty());

        }
    }
}
