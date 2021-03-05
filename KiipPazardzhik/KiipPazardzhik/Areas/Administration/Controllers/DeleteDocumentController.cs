// <copyright file="DeleteDocumentController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KiipPazardzhik.Areas.Administration.Services.DeleteDocument;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteDocument.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteDocument.ViewModels;
    using KiipPazardzhik.Constraints;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class DeleteDocumentController : Controller
    {
        private readonly IDeleteDocumentService deleteDocumentService;

        public DeleteDocumentController(IDeleteDocumentService deleteDocumentService)
        {
            this.deleteDocumentService = deleteDocumentService;
        }

        public IActionResult Index()
        {
            var model = new DeleteDocumentBaseModel
            {
                DeleteDocumentInputModel = new DeleteDocumentInputModel(),
                AllDocuments = this.deleteDocumentService.GetAllDocuments(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDocument(DeleteDocumentBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.deleteDocumentService.DeleteDocument(model.DeleteDocumentInputModel);
                this.TempData["Success"] = MessageConstants.SuccessfullyDeleteDocument;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "DeleteDocument");
        }
    }
}