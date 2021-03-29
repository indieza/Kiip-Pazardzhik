// <copyright file="DeleteRegionalCollegeController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.Services.DeleteRegionalCollege;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteRegionalCollege.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteRegionalCollege.ViewModels;
    using KiipPazardzhik.Constraints;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class DeleteRegionalCollegeController : Controller
    {
        private readonly IDeleteRegionalCollegeService deleteRegionalCollegeService;

        public DeleteRegionalCollegeController(IDeleteRegionalCollegeService deleteRegionalCollegeService)
        {
            this.deleteRegionalCollegeService = deleteRegionalCollegeService;
        }

        public IActionResult Index()
        {
            var model = new DeleteRegionalCollegeBaseModel
            {
                DeleteRegionalCollegeInputModel = new DeleteRegionalCollegeInputModel(),
                AllRegionalColleges = this.deleteRegionalCollegeService.GetAllGolleges(),
            };

            return this.View(model);
        }

        public async Task<IActionResult> DeleteRegionalCollege(DeleteRegionalCollegeBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.deleteRegionalCollegeService.DeleteRegionalCollege(model.DeleteRegionalCollegeInputModel);
                this.TempData["Success"] = MessageConstants.SuccessfullyDeleteRegionalCollege;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "DeleteRegionalCollege");
        }
    }
}