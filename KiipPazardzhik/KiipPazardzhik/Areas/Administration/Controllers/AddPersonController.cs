// <copyright file="AddPersonController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.Services.AddPerson;
    using KiipPazardzhik.Areas.Administration.ViewModels.AddPerson.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.AddPerson.ViewModels;
    using KiipPazardzhik.Constraints;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class AddPersonController : Controller
    {
        private readonly IAddPersonService addPersonService;

        public AddPersonController(IAddPersonService addPersonService)
        {
            this.addPersonService = addPersonService;
        }

        public IActionResult Index()
        {
            var model = new AddPersonBaseModel
            {
                AddPersonInputModel = new AddPersonInputModel(),
                AllSections = this.addPersonService.GetAllSections(),
                AllPositions = this.addPersonService.GetAllPosition(),
                AllTechnicalControls = this.addPersonService.GetAllTechnicalControls(),
                AllLegalCapacities = this.addPersonService.GetAllLegalCapacities(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(AddPersonBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.addPersonService.AddPerson(model.AddPersonInputModel);
                this.TempData["Success"] = MessageConstants.SuccessfullyAddPerson;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "AddPerson");
        }
    }
}