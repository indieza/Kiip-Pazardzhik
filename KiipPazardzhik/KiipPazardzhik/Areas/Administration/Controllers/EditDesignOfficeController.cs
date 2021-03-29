// <copyright file="EditDesignOfficeController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.Services.AddDesignOffice;
    using KiipPazardzhik.Areas.Administration.Services.EditDesignOffice;
    using KiipPazardzhik.Areas.Administration.ViewModels.DesignOffice.InputModels;
    using KiipPazardzhik.Constraints;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class EditDesignOfficeController : Controller
    {
        private readonly IAddDesignOfficeService addDesignOfficeService;
        private readonly IEditDesignOfficeService editDesignOfficeService;

        public EditDesignOfficeController(
            IAddDesignOfficeService addDesignOfficeService,
            IEditDesignOfficeService editDesignOfficeService)
        {
            this.addDesignOfficeService = addDesignOfficeService;
            this.editDesignOfficeService = editDesignOfficeService;
        }

        public IActionResult Index()
        {
            bool haveInformationAlready = this.addDesignOfficeService.HaveDesignOfficeAlready();

            if (!haveInformationAlready)
            {
                return this.RedirectToAction("Index", "AddDesignOffice");
            }

            EditDesignOfficeInputModel model = this.editDesignOfficeService.GetInformation();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditDesignOffice(EditDesignOfficeInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.editDesignOfficeService.EditInformation(model);
                this.TempData["Success"] = MessageConstants.SuccessfullyEditInformation;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "EditDesignOffice");
        }
    }
}