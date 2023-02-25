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
        [HttpPost]
        public IActionResult SignUpAdmin(string CNIC, string password)
        {
            AdminRepository ar = new AdminRepository();
            if (ar.SignUpAdmin(CNIC, password))
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
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public IActionResult Login(string CNIC, string password)
        {

            AdminRepository ar = new AdminRepository();
            if (ar.Authenticate(CNIC, password))
            {
             var   a=ar.FindAdminId(CNIC, password);
                HttpContext.Response.Cookies.Append("Cookie", a.ToString());
                HttpContext.Response.Cookies.Append("UserType", "Admin");
                return View("Index");
            }
                
            else return View("UnsuccessfulLogin");
        }
       
        [HttpGet]
        public ViewResult AddPatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {

                return View("AddPatient");
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }

        }
        [HttpPost]
        public ViewResult AddPatient(int Id, string Name, string CNIC, string PhoneNum, string Doctor, int RoomNo)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }
        [HttpGet]
        public ViewResult UpdatePatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {

                return View("UpdatePatient");
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
            
        }
        [HttpPost]
        public ViewResult UpdatePatient(int Id, string Name, string CNIC, string PhoneNum, string Doctor, int RoomNo)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }
        [HttpGet]
        public ViewResult AssignRoom()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {

                return View("AssignRoom");
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
            
        }
        [HttpPost]
        public ViewResult AssignRoom(int Id, int RoomNo)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }
        [HttpGet]
        public ViewResult DeletePatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {

                return View("DeletePatient");
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
            
        }
        [HttpPost]
        public ViewResult DeletePatient(int Id)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }

        }
    }
}
