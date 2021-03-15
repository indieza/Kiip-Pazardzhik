// <copyright file="AddRegionalCollegeController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.Services.AddRegionalCollege;
    using KiipPazardzhik.Areas.Administration.ViewModels.AddRegionalCollege.InputModels;
    using KiipPazardzhik.Constraints;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class AddRegionalCollegeController : Controller
    {
        private readonly IAddRegionalCollegeService addRegionalCollegeService;

        public AddRegionalCollegeController(IAddRegionalCollegeService addRegionalCollegeService)
        {
            this.addRegionalCollegeService = addRegionalCollegeService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionalCollege(AddRegionalCollegeInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.addRegionalCollegeService.AddRegionalCollege(model);
                this.TempData["Success"] = MessageConstants.SuccessfullyAddRegionalCollege;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "AddRegionalCollege");
        }
    }
}