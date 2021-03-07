using Microsoft.AspNetCore.Mvc;

namespace KiipPazardzhik.Controllers
{
    public class RegulationsController : Controller
    {
        public RegulationsController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}