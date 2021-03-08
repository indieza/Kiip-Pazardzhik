using KiipPazardzhik.Services.News;
using KiipPazardzhik.ViewModels.News.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace KiipPazardzhik.Controllers
{
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
    }
}