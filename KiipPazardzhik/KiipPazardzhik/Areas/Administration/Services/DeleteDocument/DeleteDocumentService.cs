// <copyright file="DeleteDocumentService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.DeleteDocument
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteDocument.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteDocument.ViewModels;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Services.Cloud;
    using Microsoft.EntityFrameworkCore;

    public class DeleteDocumentService : IDeleteDocumentService
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public DeleteDocumentService(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
        }

        public async Task DeleteDocument(DeleteDocumentInputModel model)
        {
            var document = await this.db.Documents.FirstOrDefaultAsync(x => x.Id == model.Id);
            ApplicationCloudinary.DeleteImage(this.cloudinary, $"{document.Id}-{document.Name}");
            this.db.Documents.Remove(document);
            await this.db.SaveChangesAsync();
        }

        public ICollection<DeleteDocumentViewModel> GetAllDocuments()
        {
            var allDocuments = this.db.Documents.ToList();
            var result = new List<DeleteDocumentViewModel>();

            foreach (var document in allDocuments)
            {
                result.Add(new DeleteDocumentViewModel
                {
                    Id = document.Id,
                    FileName = document.Name,
                });
            }

            return result;
        }
    }
}