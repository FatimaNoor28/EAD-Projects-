using EAD_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace EAD_Project.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View("DoctortSignUp");
        }
        [HttpPost]
        public IActionResult PatientSignUp(int username, string password)
        {
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

    }
}
