using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class EnrolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
