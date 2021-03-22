// <copyright file="EditNewsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.EditNews
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using CloudinaryDotNet;

    using KiipPazardzhik.Areas.Administration.ViewModels.EditNews.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditNews.ViewModels;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models;
    using KiipPazardzhik.Services.Cloud;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;

    public class EditNewsService : IEditNewsService
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment environment;

        public EditNewsService(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            this.environment = environment;
        }

        public async Task EditNews(EditNewsInputModel model)
        {
            var news = await this.db.News.FirstOrDefaultAsync(x => x.Id == model.Id);
            var files = this.db.WebsiteFiles.Where(x => x.NewsId == model.Id).ToList();

            if (model.WebsiteFiles.Count > 0)
            {
                foreach (var file in files)
                {
                    var document = await this.db.WebsiteFiles.FirstOrDefaultAsync(x => x.Id == file.Id);
                    File.Delete(document.Url);
                }

                this.db.WebsiteFiles.RemoveRange(files);
                await this.db.SaveChangesAsync();
            }

            string wwwPath = this.environment.WebRootPath;
            string path = Path.Combine(wwwPath, $"News\\{news.Id}");

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