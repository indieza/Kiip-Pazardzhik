// <copyright file="AddPeopleController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.Services.AddPeople;
    using KiipPazardzhik.Areas.Administration.ViewModels.AddPeople.InputModels;
    using KiipPazardzhik.Constraints;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using OfficeOpenXml;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class AddPeopleController : Controller
    {
        private readonly IAddPeopleService addPeopleService;

        public AddPeopleController(IAddPeopleService addPeopleService)
        {
            this.addPeopleService = addPeopleService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult DownloadTemplate()
        {
            MemoryStream stream = this.addPeopleService.CreateTemplate();

            stream.Position = 0;
            string excelName = $"КИИП Пазарджик Шаблон.xlsx";
            return this.File(
                stream,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                excelName);
        }

        public async Task<IActionResult> UploadTemplate(AddPeopleInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.addPeopleService.AddPeople(model);
                this.TempData["Success"] = MessageConstants.SuccessfullyAddPeople;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "AddPeople");
        }
    }
}