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
        public IActionResult PatientSignUp(string CNIC,string username, string password) {
            PatientRepository pr = new PatientRepository();
            if (pr.SignUpPatient(CNIC,username, password))
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
                int p = pr.find_Patient(CNIC, password);
                   HttpContext.Response.Cookies.Append("Cookie", p.ToString());
                   HttpContext.Response.Cookies.Append("UserType", "Patient");
                   

                AppointmentRepository ar = new AppointmentRepository();
                   List<Appointment> appointments = new List<Appointment>();

                   appointments = ar.GetAppointments(CNIC);
                   MakeAppointment(appointments);

                   return View("MakeAppointment");
              }
              return View("LoginUnsuccessful");
                
            
           
        }

        /* public IActionResult PatientLogin(string CNIC, string password)
                {
                    PatientRepository pr = new PatientRepository();
                    if (HttpContext.Request.Cookies.ContainsKey("UserType")) {
                        if (HttpContext.Request.Cookies["UserType"].Equals("Patient"))
                        {
                            if ((pr.Authenticate(CNIC, password)))
                            {
                                int p = pr.find_Patient(CNIC, password);
                                HttpContext.Response.Cookies.Append("Cookie", p.ToString());
                                HttpContext.Response.Cookies.Append("UserType", "Patient");
                                AppointmentRepository ar = new AppointmentRepository();
                                List<Appointment> appointments = new List<Appointment>();

                                appointments = ar.GetAppointments(CNIC);
                                MakeAppointment(appointments);

                                return View("MakeAppointment");
                            }
                            else
                            {
                                return View("LoginUnsuccessful");
                            }

                        }
                        else {
                            ViewData["Msg"] = "You are Not a Patient,Login to Continue";
                            return View("PatientLogin");
                        }
                    }
                    else
                    {
                        ViewData["Msg"] = "No Access! Login First then Continue";
                        return View("PatientLogin");
                    }


                }*/
        [HttpGet]
        public IActionResult MakeAppointment(List<Appointment> p)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType")&&  (HttpContext.Request.Cookies["UserType"].Equals("Patient"))) {

                return View(p);
            }
            else {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("PatientLogin");
            }
                
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
                    int id = Convert.ToInt32(HttpContext.Request.Cookies["Cookie"]);
                    AppointmentRepository repository = new AppointmentRepository();
                    if (repository.MakeAppointment(id, name, phone, date, month, doctor))
                    {
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
