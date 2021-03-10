// <copyright file="NewsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.News
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Data;
    using KiipPazardzhik.ViewModels.Website.ViewModels;

    using Microsoft.EntityFrameworkCore;

    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext db;

        public NewsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ICollection<SingleNewsViewModel> GetAllNews()
        {
            var result = new List<SingleNewsViewModel>();
            var allNews = this.db.News.OrderByDescending(x => x.CreatedOn).ToList();

            foreach (var currentNews in allNews)
            {
                var news = new SingleNewsViewModel
                {
                    Id = currentNews.Id,
                    Description = currentNews.Description,
                    Title = currentNews.Title,
                    ShortDescription = currentNews.ShortDescription,
                    CreatedOn = currentNews.CreatedOn,
                };

                var allNewsFiles = this.db.WebsiteFiles.Where(x => x.NewsId == currentNews.Id).ToList();

                foreach (var file in allNewsFiles)
                {
                    news.Files.Add(new WebsiteFileViewModel
                    {
                        Id = file.Id,
                        Name = file.Name,
                        Url = file.Url,
                    });
                }

                result.Add(news);
            }

            return result;
        }

        public async Task<SingleNewsViewModel> GetNewsById(string id)
        {
            var currentNews = await this.db.News.FirstOrDefaultAsync(x => x.Id == id);

            var news = new SingleNewsViewModel
            {
                Id = currentNews.Id,
                Description = currentNews.Description,
                Title = currentNews.Title,
                ShortDescription = currentNews.ShortDescription,
                CreatedOn = currentNews.CreatedOn,
            };

            var allNewsFiles = this.db.WebsiteFiles.Where(x => x.NewsId == currentNews.Id).ToList();

            foreach (var file in allNewsFiles)
            {
                news.Files.Add(new WebsiteFileViewModel
                {
                    Id = file.Id,
                    Name = file.Name,
                    Url = file.Url,
                });
            }

            return news;
        }
    }
}