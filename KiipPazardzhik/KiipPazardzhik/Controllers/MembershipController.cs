using Microsoft.AspNetCore.Mvc;

namespace KiipPazardzhik.Controllers
{
    public class MembershipController : Controller
    {
        public MembershipController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}