// <copyright file="EditPersonController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.Services.EditPerson;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditPerson.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditPerson.ViewModels;
    using KiipPazardzhik.Constraints;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class EditPersonController : Controller
    {
        private readonly IEditPersonService editPersonService;

        public EditPersonController(IEditPersonService editPersonService)
        {
            this.editPersonService = editPersonService;
        }

        public IActionResult Index()
        {
            var model = new EditPersonBaseModel
            {
                EditPersonInputModel = new EditPersonInputModel(),
                AllPeople = this.editPersonService.GetAllPeople(),
                AllSections = this.editPersonService.GetAllSections(),
                AllPositions = this.editPersonService.GetAllPositions(),
                AllTechnicalControls = this.editPersonService.GetAllTechnicalControl(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPerson(EditPersonBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.editPersonService.EditPerson(model.EditPersonInputModel);
                this.TempData["Success"] = MessageConstants.SuccessfullyEditPerson;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "EditPerson");
        }

        public async Task<IActionResult> GetPersonData(string personId)
        {
            GetPersonDataViewModel section = await this.editPersonService.GetPersonById(personId);
            return new JsonResult(section);
        }
    }
}