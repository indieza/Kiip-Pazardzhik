using Microsoft.AspNetCore.Mvc;

namespace KiipPazardzhik.Controllers
{
    public class InformationController : Controller
    {
        public InformationController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}