using eadProject.Models;

namespace eadProject.Models
{
    public class ReportsRepository
    {
        public bool AddReports(string link, int PatientId)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();


            Reports reports = new Reports();
            reports.PatientId = PatientId;
            reports.link = link;
            db.Reports.Add(reports);
            if (db.SaveChanges() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
