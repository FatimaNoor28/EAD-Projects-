using EAD_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace EAD_Project.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View("PatientSignUp");
        }
        [HttpPost]
        public IActionResult PatientSignUp(int username, string password) {
            PatientRepository pr = new PatientRepository();
            if (pr.SignUpPatient(username, password))
            {
                ViewData["Msg"] = "You are Signed Up Successfully,LogIn to continue";
                return View("PatientLogin");
            }
            else
            {
                return View("UnsuccessfulSignUp");
            }
        }
        [HttpGet]
        public IActionResult PatientLogin()
        {
            return View("PatientLogin");
        }
        [HttpPost]
        public IActionResult PatientLogin(int username, string password)
        {
            PatientRepository pr = new PatientRepository();

            if (pr.Authenticate(username, password))
            {
                List<Patient> patients = new List<Patient>();
                patients = pr.GetAllAppointments(username);
                MakeAppointment(patients);
                return View("MakeAppointment");
            }    
            return View("LoginUnsuccessful");
        }

        [HttpGet]
        public IActionResult MakeAppointment(List<Patient> p)
        {
            return View(p);
        }
        [HttpPost]
        public IActionResult Receipt(string name, string CNIC, string phone, string date, string department, string doctor)
        {

            PatientRepository repository = new PatientRepository();
            Patient p = repository.MakeAppointment(name, CNIC, phone, date, department, doctor);
            return View(p);
        }
        
    }
}
