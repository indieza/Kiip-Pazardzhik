// <copyright file="DesignOfficesController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Controllers
{
    using KiipPazardzhik.Services.DesignOffices;
    using KiipPazardzhik.ViewModels.Website.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class DesignOfficesController : Controller
    {
        private readonly IDesignOfficesService designOfficesService;

        public DesignOfficesController(IDesignOfficesService designOfficesService)
        {
            this.designOfficesService = designOfficesService;
        }

        public IActionResult Index()
        {
            DesignOfficesViewModel model = this.designOfficesService.GetInformation();
            return this.View(model);
        }
    }
}