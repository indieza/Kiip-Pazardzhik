// <copyright file="DeleteNewsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.DeleteNews
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteNews.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteNews.VeiwModels;
    using KiipPazardzhik.Data;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;

    public class DeleteNewsService : IDeleteNewsService
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment environment;

        public DeleteNewsService(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            this.environment = environment;
        }

        public async Task DeleteNews(DeleteNewsInputModel model)
        {
            var allFiles = this.db.WebsiteFiles.Where(x => x.NewsId == model.Id).ToList();

            this.db.WebsiteFiles.RemoveRange(allFiles);
            var news = await this.db.News.FirstOrDefaultAsync(x => x.Id == model.Id);
            string wwwPath = this.environment.WebRootPath;
            string path = Path.Combine(wwwPath, $"News\\{news.Id}");

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }

            this.db.News.Remove(news);
            await this.db.SaveChangesAsync();
        }

        public ICollection<DeleteNewsViewModel> GetAllNews()
        {
            var news = this.db.News.ToList();
            var result = new List<DeleteNewsViewModel>();

            foreach (var current in news)
            {
                result.Add(new DeleteNewsViewModel
                {
                    Id = current.Id,
                    Title = current.Title,
                });
            }

            return result;
        }
    }
}