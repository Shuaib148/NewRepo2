using Microsoft.AspNetCore.Mvc;

namespace NIC_PRACTICAL.Controllers
{
    public class DashController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
