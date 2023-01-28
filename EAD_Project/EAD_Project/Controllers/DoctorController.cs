using Microsoft.AspNetCore.Mvc;

namespace EAD_Project.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
