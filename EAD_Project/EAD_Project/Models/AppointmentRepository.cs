using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;


namespace EAD_Project.Models
{
    public class AppointmentRepository
    {
        public AppointmentRepository() { }
        public List<Appointment> GetAppointments(string CNIC) { 
            //List<Appointment> list = new List<Appointment>();
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            //string CurrentDate = DateTime.Now.ToString("MM/dd/yyyy");
            //return db.Appointments.Where(p => DateTime.Parse(p.Date, System.Globalization.CultureInfo.CurrentCulture) >=DateTime.Parse(CurrentDate, System.Globalization.CultureInfo.CurrentCulture)).ToList();
            //return db.Appointments.Where(p => DbFunctions.TruncateTime(DateTime.ParseExact(p.Date, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture)) >= DbFunctions.TruncateTime(CurrentDate)).ToList();/*.Where(p=> DateOnly.Parse(p.AppointmentDate) >= d )*/;
            int d = Convert.ToInt32(DateTime.Now.ToString("dd"));
            int m = Convert.ToInt32(DateTime.Now.ToString("MM"));
            return db.Appointments.Where(a => a.Date >= d || a.Month >= m ).ToList();
        }

        public List<Appointment> GetAppointmentWithId(int id)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            return db.Appointments.Where(a => a.PatientId==id).ToList();
        }

        public bool MakeAppointment(int id, string name, string phone, int date, int month, string doctor)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            //Appointment a = (Appointment)db.Appointments.Where(p => p.PatientId == id);
            if(IsDateValid(2023, month, date))
            {
                Appointment a = new Appointment()
                {
                    PatientId = id,
                    DoctorName = doctor,
                    Date = date,
                    Month = month,
                    PhoneNo = phone,
                    time = "11:00"
                };
                db.Appointments.Add(a);
                db.SaveChanges();
                return true;
            }
            
            return false;
        }

        public bool IsDateValid(int year, int month, int day)
        {
            return day <= DateTime.DaysInMonth(year, month);
        }
    }
}
