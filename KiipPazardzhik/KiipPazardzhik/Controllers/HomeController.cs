using System.Diagnostics;
using System.Threading.Tasks;

using KiipPazardzhik.Models;
using KiipPazardzhik.Models.Users;
using KiipPazardzhik.Services.Home;
using KiipPazardzhik.ViewModels.Home.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

            var model = new HomeViewModel
            {
                HasAdmin = await this.homeServices.HasAdministrator(),
            };

            return this.View(model);
        }

        [Authorize]
        public async Task<IActionResult> MakeYourselfAdmin()
        {
            var hasAdmin = await this.homeServices.HasAdministrator();

            if (hasAdmin)
            {
                return this.BadRequest();
            }

            var currentUser = await this.userManager.GetUserAsync(this.User);
            await this.homeServices.MakeYourselfAdmin(currentUser);
            return this.RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}