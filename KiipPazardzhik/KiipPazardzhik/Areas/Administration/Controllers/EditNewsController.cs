// <copyright file="EditNewsController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KiipPazardzhik.Areas.Administration.Services.EditNews;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditNews.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditNews.ViewModels;
    using KiipPazardzhik.Constraints;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class EditNewsController : Controller
    {
        private readonly IEditNewsService editNewsService;

        public EditNewsController(IEditNewsService editNewsService)
        {
            this.editNewsService = editNewsService;
        }

        public IActionResult Index()
        {
            var model = new EditNewsBaseModel
            {
                EditNewsInputModel = new EditNewsInputModel(),
                AllNews = this.editNewsService.GetAllNews(),
            };

            return this.View(model);
        }

        public async Task<IActionResult> EditNews(EditNewsBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.editNewsService.EditNews(model.EditNewsInputModel);
                this.TempData["Success"] = MessageConstants.SuccessfullyEditNews;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "EditNews");
        }

        public async Task<IActionResult> GetNewsData(string newsId)
        {
            GetNewsDataViewModel section = await this.editNewsService.GetNewsById(newsId);
            return new JsonResult(section);
        }
    }
}