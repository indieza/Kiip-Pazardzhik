using Microsoft.AspNetCore.Mvc;

namespace KiipPazardzhik.Controllers
{
    public class ContactsController : Controller
    {
        public ContactsController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}