using EAD_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace EAD_Project.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("SignUpAdmin");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public IActionResult Login(int username, string password)
        {
            AdminRepository ar = new AdminRepository();

            if (ar.Authenticate(username, password))
                return View("Index");
            else return View("UnsuccessfullLogin");
        }
        [HttpPost]
        public IActionResult SignUpAdmin(int username, string password)
        {
            AdminRepository ar = new AdminRepository();
            if (ar.SignUpAdmin(username, password))
            {
                ViewData["Msg"] = "You are Siggned Up Successfully,LogIn to continue";
                return View("Login");
            }
            else
            {
                return View("UnsuccessfulSignUp");
            }
        }
        [HttpGet]
        public ViewResult AddPatient()
        {
            return View("AddPatient");
        }
        [HttpPost]
        public ViewResult AddPatient(int Id, string Name, string CNIC, string PhoneNum, string Doctor, int RoomNo)
        {
            return View();
        }
        [HttpGet]
        public ViewResult UpdatePatient()
        {
            return View("UpdatePatient");
        }
        [HttpPost]
        public ViewResult UpdatePatient(int Id, string Name, string CNIC, string PhoneNum, string Doctor, int RoomNo)
        {
            return View();
        }
        [HttpGet]
        public ViewResult AssignRoom()
        {
            return View("AssignRoom");
        }
        [HttpPost]
        public ViewResult AssignRoom(int Id, int RoomNo)
        {
            return View();
        }
        [HttpGet]
        public ViewResult DeletePatient()
        {
            return View("DeletePatient");
        }
        [HttpPost]
        public ViewResult DeletePatient(int Id)
        {
            return View();
        }
    }
}
