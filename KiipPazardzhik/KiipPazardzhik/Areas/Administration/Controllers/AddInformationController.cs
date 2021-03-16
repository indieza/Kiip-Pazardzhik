// <copyright file="AddInformationController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.Services.AddInfromation;
    using KiipPazardzhik.Areas.Administration.Services.EditInformation;
    using KiipPazardzhik.Areas.Administration.ViewModels.Information.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.Information.ViewModels;
    using KiipPazardzhik.Constraints;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class AddInformationController : Controller
    {
        private readonly IAddInformationService addInformationService;
        private readonly IEditInformationService editInformationService;

        public AddInformationController(
            IAddInformationService addInformationService,
            IEditInformationService editInformationService)
        {
            this.addInformationService = addInformationService;
            this.editInformationService = editInformationService;
        }

        public IActionResult Index()
        {
            bool haveInformationAlready = this.addInformationService.HaveInformationAlready();

            if (haveInformationAlready)
            {
                return this.RedirectToAction("Index", "EditInformation");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddInformation(AddInformationInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.addInformationService.AddInformation(model);
                this.TempData["Success"] = MessageConstants.SuccessfullyAddInformation;

                return this.RedirectToAction("Index", "EditInformation");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "AddInformation");
            }
        }
    }
}