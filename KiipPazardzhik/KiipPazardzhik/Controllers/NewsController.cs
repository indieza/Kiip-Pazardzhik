// <copyright file="NewsController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Controllers
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Services.News;
    using KiipPazardzhik.ViewModels.News.ViewModels;
    using KiipPazardzhik.ViewModels.Website.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class NewsController : Controller
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public IActionResult Index()
        {
            var model = new AllNewsViewModel
            {
                AllNews = this.newsService.GetAllNews(),
            };

            return this.View(model);
        }

        [HttpGet]
        [Route("/News/CurrentNews/{id}")]
        public async Task<IActionResult> CurrentNews(string id)
        {
            SingleNewsViewModel model = await this.newsService.GetNewsById(id);
            return this.View(model);
        }
    }
}