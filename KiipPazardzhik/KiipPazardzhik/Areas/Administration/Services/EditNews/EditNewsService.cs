// <copyright file="EditNewsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.EditNews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditNews.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditNews.ViewModels;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models;
    using KiipPazardzhik.Services.Cloud;
    using Microsoft.EntityFrameworkCore;

    public class EditNewsService : IEditNewsService
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public EditNewsService(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
        }

        public async Task EditNews(EditNewsInputModel model)
        {
            var news = await this.db.News.FirstOrDefaultAsync(x => x.Id == model.Id);
            var files = this.db.WebsiteFiles.Where(x => x.NewsId == model.Id).ToList();

            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    ApplicationCloudinary.DeleteImage(this.cloudinary, $"{news.Id}-{file.Name}");
                }

                this.db.WebsiteFiles.RemoveRange(files);
            }

            foreach (var file in model.WebsiteFiles)
            {
                var fileUrl = await ApplicationCloudinary.UploadImage(
                       this.cloudinary,
                       file,
                       $"{news.Id}-{file.FileName}");

                this.db.WebsiteFiles.Add(new WebsiteFile
                {
                    Name = file.FileName,
                    Url = fileUrl,
                    NewsId = news.Id,
                });
            }

            var contentWithoutTags = Regex
                .Replace(model.SanitizedDescription, "<.*?>", string.Empty);

            news.Title = model.Title;
            news.Description = model.SanitizedDescription;
            news.ShortDescription = contentWithoutTags.Length < 250 ?
                contentWithoutTags :
                contentWithoutTags.Substring(0, 250);

            this.db.Update(news);
            await this.db.SaveChangesAsync();
        }

        public ICollection<EditNewsViewModel> GetAllNews()
        {
            var allNews = this.db.News.ToList();
            var result = new List<EditNewsViewModel>();

            foreach (var news in allNews)
            {
                result.Add(new EditNewsViewModel
                {
                    Id = news.Id,
                    Title = news.Title,
                });
            }

            return result;
        }

        public async Task<GetNewsDataViewModel> GetNewsById(string newsId)
        {
            var news = await this.db.News.FirstOrDefaultAsync(x => x.Id == newsId);
            return new GetNewsDataViewModel
            {
                Title = news.Title,
                Description = news.Description,
            };
        }
    }
}