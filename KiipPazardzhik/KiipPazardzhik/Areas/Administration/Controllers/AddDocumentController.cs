// <copyright file="AddDocumentController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.Services.AddDocument;
    using KiipPazardzhik.Areas.Administration.ViewModels.AddDocument.InputModels;
    using KiipPazardzhik.Constraints;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class AddDocumentController : Controller
    {
        private readonly IAddDocumentService addDocumentService;

        public AddDocumentController(IAddDocumentService addDocumentService)
        {
            this.addDocumentService = addDocumentService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> AddDocument(AddDocumentInputModel model)
        {
            if (this.ModelState.IsValid && model.Files.Count > 0)
            {
                await this.addDocumentService.AddDocument(model);
                this.TempData["Success"] = MessageConstants.SuccessfullyAddDocument;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "AddDocument");
        }
    }
}