// <copyright file="DeletePersonController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KiipPazardzhik.Areas.Administration.Services.DeletePerson;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeletePerson.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeletePerson.ViewModels;
    using KiipPazardzhik.Constraints;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class DeletePersonController : Controller
    {
        private readonly IDeletePersonService deletePersonService;

        public DeletePersonController(IDeletePersonService deletePersonService)
        {
            this.deletePersonService = deletePersonService;
        }

        public IActionResult Index()
        {
            var model = new DeletePersonBaseModel
            {
                DeletePersonInputModel = new DeletePersonInputModel(),
                AllPeople = this.deletePersonService.GetAllPeople(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePerson(DeletePersonBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.deletePersonService.DeletePerson(model.DeletePersonInputModel);
                this.TempData["Success"] = MessageConstants.SuccessfullyDeletePerson;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "DeletePerson");
        }
    }
}