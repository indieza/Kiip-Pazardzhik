using KiipPazardzhik.Models;
using KiipPazardzhik.Models.Users;
using KiipPazardzhik.Services.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KiipPazardzhik.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHomeService homeServices;

        public HomeController(UserManager<ApplicationUser> userManager, IHomeService homeServices)
        {
            this.userManager = userManager;
            this.homeServices = homeServices;
        }

        public async Task<IActionResult> Index()
        {
            await this.homeServices.SubmitAllRoles();

            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}