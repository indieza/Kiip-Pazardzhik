// <copyright file="AddDocumentService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddDocument
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using KiipPazardzhik.Areas.Administration.ViewModels.AddDocument.InputModels;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models;
    using KiipPazardzhik.Services.Cloud;

    public class AddDocumentService : IAddDocumentService
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public AddDocumentService(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
        }

        public async Task AddDocument(AddDocumentInputModel model)
        {
            foreach (var file in model.Files)
            {
                var document = new Document
                {
                    Name = file.FileName,
                    DocumentType = model.DocumentType,
                };

                var fileUrl = await ApplicationCloudinary.UploadImage(
                           this.cloudinary,
                           file,
                           $"{document.Id}-{file.FileName}");

                document.Url = fileUrl;
                this.db.Documents.Add(document);
                await this.db.SaveChangesAsync();
            }
        }
    }
}