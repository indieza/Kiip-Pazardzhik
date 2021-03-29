// <copyright file="AddDocumentService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddDocument
{
    using System.IO;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.AddDocument.InputModels;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;

    public class AddDocumentService : IAddDocumentService
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment environment;

        public AddDocumentService(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            this.environment = environment;
        }

        public async Task AddDocument(AddDocumentInputModel model)
        {
            string wwwPath = this.environment.WebRootPath;

            string path = Path.Combine(wwwPath, $"Documents\\{model.DocumentType}");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in model.Files)
            {
                string fileName = Path.GetFileName(file.FileName);
                var targetDocument =
                    await this.db.Documents
                        .FirstOrDefaultAsync(
                            x => x.Name == file.FileName && x.DocumentType == model.DocumentType);
                if (targetDocument == null)
                {
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        file.CopyTo(stream);
                        this.db.Documents.Add(new Document
                        {
                            DocumentType = model.DocumentType,
                            Name = file.FileName,
                            Url = Path.Combine(wwwPath, $"Documents\\{model.DocumentType}\\") + fileName,
                        });
                        await this.db.SaveChangesAsync();
                    }
                }
            }
        }
    }
}