using Microsoft.AspNetCore.Mvc;

namespace KiipPazardzhik.Controllers
{
    public class DesignOfficesController : Controller
    {
        public DesignOfficesController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}