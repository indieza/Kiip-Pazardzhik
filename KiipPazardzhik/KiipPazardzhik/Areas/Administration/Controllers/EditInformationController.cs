// <copyright file="EditInformationController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.Services.AddInfromation;
    using KiipPazardzhik.Areas.Administration.Services.EditInformation;
    using KiipPazardzhik.Areas.Administration.ViewModels.Information.InputModels;
    using KiipPazardzhik.Constraints;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class EditInformationController : Controller
    {
        private readonly IAddInformationService addInformationService;
        private readonly IEditInformationService editInformationService;

        public EditInformationController(
            IAddInformationService addInformationService,
            IEditInformationService editInformationService)
        {
            this.addInformationService = addInformationService;
            this.editInformationService = editInformationService;
        }

        public IActionResult Index()
        {
            bool haveInformationAlready = this.addInformationService.HaveInformationAlready();

            if (!haveInformationAlready)
            {
                return this.RedirectToAction("Index", "AddInformation");
            }

            EditInformationInputModel model = this.editInformationService.GetInformation();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditInformation(EditInformationInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.editInformationService.EditInformation(model);
                this.TempData["Success"] = MessageConstants.SuccessfullyEditInformation;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "EditInformation");
        }
    }
}