// <copyright file="AddNewsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddNews
{
    using System;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using CloudinaryDotNet;

    using KiipPazardzhik.Areas.Administration.ViewModels.AddNews.InputModels;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models;
    using KiipPazardzhik.Services.Cloud;

    public class AddNewsService : IAddNewsService
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public AddNewsService(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
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

            foreach (var file in model.WebsiteFiles)
            {
                var fileUrl = await ApplicationCloudinary.UploadImage(
                       this.cloudinary,
                       file,
                       $"{news.Id}-{file.FileName}");

                news.WebsiteFiles.Add(new WebsiteFile
                {
                    Name = file.FileName,
                    Url = fileUrl,
                    NewsId = news.Id,
                });
            }

            this.db.News.Add(news);
            await this.db.SaveChangesAsync();
        }
    }
}