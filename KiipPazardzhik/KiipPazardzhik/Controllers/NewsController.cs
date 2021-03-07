using Microsoft.AspNetCore.Mvc;

namespace KiipPazardzhik.Controllers
{
    public class NewsController : Controller
    {
        public NewsController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}