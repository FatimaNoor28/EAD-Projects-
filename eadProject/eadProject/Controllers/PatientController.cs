using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using eadProject.Models;
namespace eadProject.Controllers
{
    public class PatientController : Controller
    {

        public IActionResult Index()
        {
            return View("PatientSignUp");
        }
        [HttpPost]
        public IActionResult PatientSignUp(string CNIC, string Name, string password)
        {
            PatientRepository pr = new PatientRepository();
            if (pr.SignUpPatient(CNIC, Name, password))
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
        public IActionResult PatientLogin(string CNIC, string password)
        {
            PatientRepository pr = new PatientRepository();
            if ((pr.Authenticate(CNIC, password)))
            {
                //CookieOptions option = new CookieOptions();
                //option.Expires=ses
                //int p = pr.find_Patient(CNIC, password);
                string pname = pr.find_PatientName(CNIC, password);
                int id = pr.find_Patient(CNIC, password);
                HttpContext.Response.Cookies.Append("Cookie", id.ToString());
                HttpContext.Response.Cookies.Append("UserType", "Patient");
                HttpContext.Response.Cookies.Append("UserName", pname);


                AppointmentRepository ar = new AppointmentRepository();
                List<Appointment> appointments = ar.GetAppointmentWithId(id);
                ViewData["PatientUserName"] = pname;
                //appointments = ar.GetAppointmentWithId(id);
                //MakeAppointment(appointments);

                return View("MakeAppointment", appointments);
            }
            return View("LoginUnsuccessful");



        }
        [HttpGet]
        public IActionResult MakeAppointment(List<Appointment>? p)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType"))
            {
                if (HttpContext.Request.Cookies["UserType"].Equals("Patient"))
                {
                    Console.WriteLine("if part executed");
                    AppointmentRepository ar = new AppointmentRepository();

                    int id = System.Convert.ToInt32(HttpContext.Request.Cookies["Cookie"]);
                    if (p?.Any() != true)
                    {
                        p = ar.GetAppointmentWithId(id);
                    }
                    ViewData["PatientUserName"] = HttpContext.Request.Cookies["UserName"];

                    return View(p);
                }
                else
                {
                    Console.WriteLine("else part executed");
                    ViewData["Msg"] = "Login to Access this Page ,Error 404";
                    return View("PatientLogin");
                }
            }
            else
            {
                Console.WriteLine("else part executed");
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("PatientLogin");
            }
            return View(p);
        }
        [HttpPost]
        public IActionResult MakeAppointment(string name, string phone, int date, int month, string doctor)
        {
            Appointment p = null;
            List<Appointment> appointments = new List<Appointment>();
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType"))
            {
                if (HttpContext.Request.Cookies["UserType"].Equals("Patient"))
                {
                    ViewBag.name = "Patient";
                    int id = Convert.ToInt32(HttpContext.Request.Cookies["Cookie"]);
                    AppointmentRepository repository = new AppointmentRepository();
                    if (repository.MakeAppointment(id, name, phone, date, month, doctor))
                    {
                        ViewData["PatientUserName"] = HttpContext.Request.Cookies["UserName"];
                        appointments = repository.GetAppointmentWithId(id);
                        MakeAppointment(appointments);
                    }
                    else
                    {
                        appointments = repository.GetAppointmentWithId(id);
                        ViewData["Appointment"] = "Please enter a valid date and month";
                        return View(appointments);

                    }
                }

            }
            return View(appointments);
        }

    }
}

