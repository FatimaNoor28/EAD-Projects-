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
            PatientRepository ar = new PatientRepository();

            if (ar.Authenticate(username, password))
                return View("MakeAppointment");
            else return View("LoginUnsuccessful");
        }

        [HttpGet]
        public IActionResult Appointment()
        {
            return View("MakeAppointment");
        }
        [HttpPost]
        public IActionResult MakeAppointment(string name, string CNIC, string phone, string date, string department, string doctor)
        {
            PatientRepository repository = new PatientRepository();
            repository.MakeAppointment(name, CNIC, phone, date, department, doctor);
            return View("Reciept");
        }
        
    }
}
