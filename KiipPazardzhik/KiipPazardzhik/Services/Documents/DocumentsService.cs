// <copyright file="DocumentsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Documents
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Data;
    using KiipPazardzhik.ViewModels.Website.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    using Microsoft.EntityFrameworkCore;

    public class DocumentsService : IDocumentsService
    {
        private readonly ApplicationDbContext db;

        public DocumentsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Dictionary<string, List<DocumentViewModel>> GetAllDocuments()
        {
            var allDocuments = this.db.Documents.OrderBy(x => (int)x.DocumentType).ToList();
            var result = new Dictionary<string, List<DocumentViewModel>>();

            foreach (var document in allDocuments)
            {
                if (!result.ContainsKey(document.DocumentType.ToString()))
                {
                    result.Add(document.DocumentType.ToString(), new List<DocumentViewModel>());
                }

                result[document.DocumentType.ToString()].Add(new DocumentViewModel
                {
                    Id = document.Id,
                    Name = document.Name,
                    DocumentType = document.DocumentType,
                    Url = document.Url,
                });
            }

            return result;
        }

        public async Task<Tuple<byte[], string>> GetFile(string id)
        {
            var targetFile = await this.db.Documents.FirstOrDefaultAsync(x => x.Id == id);
            string fileName = Path.GetFileName(targetFile.Url);
            byte[] bytes = File.ReadAllBytes(targetFile.Url);
            return Tuple.Create(bytes, fileName);
        }
    }
}