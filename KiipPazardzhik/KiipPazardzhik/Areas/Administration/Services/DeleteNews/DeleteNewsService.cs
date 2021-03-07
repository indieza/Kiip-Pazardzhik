// <copyright file="DeleteNewsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.DeleteNews
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;

    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteNews.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteNews.VeiwModels;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Services.Cloud;

    using Microsoft.EntityFrameworkCore;

    public class DeleteNewsService : IDeleteNewsService
    {
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;

        public DeleteNewsService(ApplicationDbContext db, Cloudinary cloudinary)
        {
            this.db = db;
            this.cloudinary = cloudinary;
        }

        public async Task DeleteNews(DeleteNewsInputModel model)
        {
            var allFiles = this.db.WebsiteFiles.Where(x => x.NewsId == model.Id).ToList();

            foreach (var file in allFiles)
            {
                ApplicationCloudinary.DeleteImage(this.cloudinary, $"{model.Id}-{file.Name}");
            }

            this.db.WebsiteFiles.RemoveRange(allFiles);
            var news = await this.db.News.FirstOrDefaultAsync(x => x.Id == model.Id);
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