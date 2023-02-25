using eadProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace eadProject.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View("DoctorSignUp");
        }
        [HttpPost]
        public IActionResult DoctorSignUp(string CNIC, string name, int appointments, string password)
        {
            DoctorRepository dr = new DoctorRepository();
            if (dr.SignUpDoctor(CNIC, name, appointments, password))
            {
                ViewData["Msg"] = "You are Signed Up Successfully,LogIn to continue";
                return View("Login");
            }
            return View("UnsuccessfulSignUp");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public IActionResult Login(string CNIC, string password)
        {
            DoctorRepository dr = new DoctorRepository();

            if (dr.Authenticate(CNIC, password))
            {
                Doctor d = dr.findDoctor(CNIC, password);
                HttpContext.Response.Cookies.Append("Cookie", d.DoctorId.ToString());
                HttpContext.Response.Cookies.Append("UserType", "Doctor");

                return View("Index", d);
            }

            else return View("LoginUnsuccessful");
        }

    }
}
