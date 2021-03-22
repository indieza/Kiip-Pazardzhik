// <copyright file="AddNewsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddNews
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using CloudinaryDotNet;

    using KiipPazardzhik.Areas.Administration.ViewModels.AddNews.InputModels;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models;
    using KiipPazardzhik.Services.Cloud;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;

    public class AddNewsService : IAddNewsService
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment environment;

        public AddNewsService(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            this.environment = environment;
        }

        public async Task AddNews(AddNewsInputModel model)
        {
            var contentWithoutTags = Regex
                .Replace(model.SanitizedDescription, "<.*?>", string.Empty);

            var news = new News
            {
                Title = model.Title,
                CreatedOn = DateTime.Now,
                Description = model.SanitizedDescription,
                ShortDescription = contentWithoutTags.Length < 250 ?
                contentWithoutTags :
                contentWithoutTags.Substring(0, 250),
            };

            string wwwPath = this.environment.WebRootPath;

            string path = Path.Combine(wwwPath, $"News\\{news.Id}");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in model.WebsiteFiles)
            {
                string fileName = Path.GetFileName(file.FileName);
                var targetDocument =
                    await this.db.WebsiteFiles
                        .FirstOrDefaultAsync(
                            x => x.Name == file.FileName && x.NewsId == news.Id);
                if (targetDocument == null)
                {
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        file.CopyTo(stream);
                        this.db.WebsiteFiles.Add(new WebsiteFile
                        {
                            Name = file.FileName,
                            Url = Path.Combine(wwwPath, $"News\\{news.Id}\\") + fileName,
                            NewsId = news.Id,
                        });
                    }
                }
            }

            this.db.News.Add(news);
            await this.db.SaveChangesAsync();
        }
    }
}