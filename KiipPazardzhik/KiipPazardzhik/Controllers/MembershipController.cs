using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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