using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KiipPazardzhik.Controllers
{
    public class RegisterController : Controller
    {
        public RegisterController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}