﻿using System.Collections.Generic;
using System.Threading.Tasks;

using KiipPazardzhik.Models.Users;
using KiipPazardzhik.Services.Home;
using KiipPazardzhik.ViewModels.Home.ViewModels;
using KiipPazardzhik.ViewModels.Website.ViewModels;

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
                TopThreeNews = this.homeServices.GetTopNews(3),
                TopFiveNews = this.homeServices.GetTopNews(5),
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

        [HttpGet]
        public IActionResult GetAllRegionalColleges()
        {
            ICollection<RegionalCollegeViewModel> allRegionalColleges =
                this.homeServices.GetAllRegionalColleges();
            return new JsonResult(allRegionalColleges);
        }
    }
}