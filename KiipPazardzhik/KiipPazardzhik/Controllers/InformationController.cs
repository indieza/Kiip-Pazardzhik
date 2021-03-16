// <copyright file="InformationController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Controllers
{
    using KiipPazardzhik.Services.Information;
    using KiipPazardzhik.ViewModels.Website.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class InformationController : Controller
    {
        private readonly IInformationService informationService;

        public InformationController(IInformationService informationService)
        {
            this.informationService = informationService;
        }

        public IActionResult Index()
        {
            InformationViewModel model = this.informationService.GetInformation();
            return this.View(model);
        }
    }
}