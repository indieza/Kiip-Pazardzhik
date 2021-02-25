using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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