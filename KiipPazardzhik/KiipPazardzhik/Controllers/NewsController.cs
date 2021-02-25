using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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