using eadProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Diagnostics;

namespace eadProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment Environment;

        public AdminController(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUpAdmin()
        {
            return View("SignUpAdmin");
        }
        [HttpPost]
        public IActionResult SignUpAdmin(string CNIC, string Name, string password)
        {
            AdminRepository ar = new AdminRepository();
            if (ar.SignUpAdmin(CNIC, Name, password))
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

            return View();
        }
        [HttpPost]
        public IActionResult Login(string CNIC, string password)
        {

            AdminRepository ar = new AdminRepository();
            if (ar.Authenticate(CNIC, password))
            {
                var a = ar.FindAdminId(CNIC, password);
                var A_name = ar.find_AdminName(CNIC, password);
                HttpContext.Response.Cookies.Append("Cookie", a.ToString());
                HttpContext.Response.Cookies.Append("UserType", "Admin");
                HttpContext.Response.Cookies.Append("AdminUserName", A_name);
                ViewData["AdminUserName"] = A_name;

                return View("Index");
            }

            else return View("UnsuccessfulLogin");
        }

        [HttpGet]
        public ViewResult AddPatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View("AddPatient");
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }

        }
        [HttpPost]
        public ViewResult AddPatient(/*int Id, string Name,*/ string CNIC, string name, string password, string Doctor/*, int RoomNo*/)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                PatientRepository pr = new PatientRepository();
                if (pr.SignUpPatient(CNIC, name, password))
                    return View("Index");
            }
            ViewData["Msg"] = "Login to Access this Page ,Error 404";
            return View("Login");

        }
        [HttpGet]
        public ViewResult FindPatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }
        [HttpPost]
        public ViewResult FindPatient(int Id)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                AdminRepository ar = new AdminRepository();
                Patient p = ar.find_Patient(Id);
                return View("DisplayPatient", p);
            }
            ViewData["Msg"] = "Login to Access this Page ,Error 404";
            return View("Login");
        }

        [HttpGet]
        public ViewResult DisplayPatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

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
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }

        }

        //[Route("/Admin/UpdatePatient", Name = "update")]
        [HttpPost]
        public ViewResult UpdatePatient(int Id)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                AdminRepository ar = new AdminRepository();
                Patient p = ar.find_Patient(Id);
                return View("updateRecord", p);
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }

        public ViewResult updateRecord()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }
        //[Route("Speaker/{id:int}")]
        [HttpPost]
        public ViewResult updateRecord(int Id, string Name, string CNIC, string Password)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                AdminRepository ar = new AdminRepository();
                ar.updatePatient(Id, Name, CNIC, Password);
                ViewData["Msg"] = "Patient ID " + Id + " has been updated...";
                return View("Index", Id);
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
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
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
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                return View();
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
                AdminRepository ar = new AdminRepository();
                Patient p = ar.find_Patient(Id);
                ar.RemovePatient(Id);
                if (ar.find_Patient(Id) == null)
                    return View("Index");
            }
            ViewData["Msg"] = "Login to Access this Page ,Error 404";
            return View("Login");
        }

        [HttpGet]
        public ViewResult AllPatients()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                AdminRepository ar = new AdminRepository();
                List<Patient> p = ar.GetAllPatients();
                return View(p);
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }

        [HttpGet]
        public ViewResult uploadPatientReport()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }

        [HttpPost]
        public ViewResult uploadPatientReport(List<IFormFile> postedFiles, int PatientId)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ReportsRepository repo = new ReportsRepository();
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                string wwwPath = this.Environment.WebRootPath;
                string path = Path.Combine(wwwPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                foreach (var file in postedFiles)
                {

                    var fileName = Path.GetFileName(file.FileName);
                    var pathWithFileName = Path.Combine(path, fileName);
                    using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                    {
                        if (!repo.AddReports(pathWithFileName, PatientId))
                        {
                            ViewData["Msg"] = "File Not Uploaded";
                            return View("Index");
                        }

                        file.CopyTo(stream);
                        ViewBag.Message = "file uploaded successfully";
                    }
                }
                return View("Index");
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
            //return View();
        }
        public string CurrentAdmin()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                return HttpContext.Request.Cookies["AdminUserName"];
            }
            else return "No User found";

        }
    }
}
