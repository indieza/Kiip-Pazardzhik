// <copyright file="AddNewsController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.Services.AddNews;
    using KiipPazardzhik.Areas.Administration.ViewModels.AddNews.InputModels;
    using KiipPazardzhik.Constraints;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class AddNewsController : Controller
    {
        private readonly IAddNewsService addNewsService;

        public AddNewsController(IAddNewsService addNewsService)
        {
            this.addNewsService = addNewsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> AddNews(AddNewsInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.addNewsService.AddNews(model);
                this.TempData["Success"] = MessageConstants.SuccessfullyAddNews;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "AddNews");
        }
    }
}