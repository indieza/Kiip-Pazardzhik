// <copyright file="DeleteNewsController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.Services.DeleteNews;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteNews.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteNews.VeiwModels;
    using KiipPazardzhik.Constraints;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class DeleteNewsController : Controller
    {
        private readonly IDeleteNewsService deleteNewsService;

        public DeleteNewsController(IDeleteNewsService deleteNewsService)
        {
            this.deleteNewsService = deleteNewsService;
        }

        public IActionResult Index()
        {
            var model = new DeleteNewsBaseModel
            {
                DeleteNewsInputModel = new DeleteNewsInputModel(),
                AllNews = this.deleteNewsService.GetAllNews(),
            };

            return this.View(model);
        }

        public async Task<IActionResult> DeleteNews(DeleteNewsBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.deleteNewsService.DeleteNews(model.DeleteNewsInputModel);
                this.TempData["Success"] = MessageConstants.SuccessfullyDeleteNews;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "DeleteNews");
        }
    }
}