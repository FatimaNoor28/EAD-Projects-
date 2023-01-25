using Microsoft.IdentityModel.Tokens;

namespace EAD_Project.Models
{
    public class AdminRepository
    {
        public AdminRepository() { }    
        public bool Authenticate(int username, string password)
        {

            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            if ((db.Admins.Where(a => a.AdminId == username && a.Password.Equals(password)).ToList()).IsNullOrEmpty())
                return false;

            return true;
        }
    }
}
