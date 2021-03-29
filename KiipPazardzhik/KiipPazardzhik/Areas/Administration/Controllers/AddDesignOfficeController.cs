// <copyright file="AddDesignOfficeController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.Services.AddDesignOffice;
    using KiipPazardzhik.Areas.Administration.ViewModels.DesignOffice.InputModels;
    using KiipPazardzhik.Constraints;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class AddDesignOfficeController : Controller
    {
        private readonly IAddDesignOfficeService addDesignOfficeService;

        public AddDesignOfficeController(IAddDesignOfficeService addDesignOfficeService)
        {
            this.addDesignOfficeService = addDesignOfficeService;
        }

        public IActionResult Index()
        {
            bool haveInformationAlready = this.addDesignOfficeService.HaveDesignOfficeAlready();

            if (haveInformationAlready)
            {
                return this.RedirectToAction("Index", "EditDesignOffice");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDesignOffice(AddDesignOfficeInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.addDesignOfficeService.AddDesignOffice(model);
                this.TempData["Success"] = MessageConstants.SuccessfullyAddInformation;

                return this.RedirectToAction("Index", "EditDesignOffice");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "AddDesignOffice");
            }
        }
    }
}