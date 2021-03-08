using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using KiipPazardzhik.ViewModels.Website.ViewModels;

namespace KiipPazardzhik.Services.News
{
    public interface INewsService
    {
        ICollection<SingleNewsViewModel> GetAllNews();
    }
}