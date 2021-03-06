﻿namespace KiipPazardzhik.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KiipPazardzhik.Services.Documents;
    using KiipPazardzhik.ViewModels.Website.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class DocumentsController : Controller
    {
        private readonly IDocumentsService documentsService;

        public DocumentsController(IDocumentsService documentsService)
        {
            this.documentsService = documentsService;
        }

        public IActionResult Index()
        {
            Dictionary<string, List<DocumentViewModel>> allDocuments = this.documentsService.GetAllDocuments();
            return this.View(allDocuments);
        }

        public async Task<FileResult> GetDocument(string id)
        {
            var s = await this.documentsService.GetFile(id);
            return this.File(s.Item1, "application/octet-stream", s.Item2);
        }
    }
}