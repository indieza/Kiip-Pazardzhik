// <copyright file="RegisterController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Controllers
{
    using KiipPazardzhik.Services.Register;
    using KiipPazardzhik.ViewModels.Register.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class RegisterController : Controller
    {
        private readonly IRegisterService registerService;

        public RegisterController(IRegisterService registerService)
        {
            this.registerService = registerService;
        }

        public IActionResult Index()
        {
            var model = new RegisterBaseModel
            {
                AllSections = this.registerService.GetAllSections(),
            };

            return this.View(model);
        }

        [HttpGet]
        [Route("/Register/GetSectionByName/{sectionName}")]
        public IActionResult GetSectionByName([FromRoute] string sectionName)
        {
            var model = new GetSectionByNameBaseModel
            {
                SectionName = sectionName,
                AllPeople = this.registerService.GetAllPeopleInSection(sectionName),
            };

            return this.View(model);
        }
    }
}