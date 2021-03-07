// <copyright file="IDeleteNewsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.DeleteNews
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteNews.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteNews.VeiwModels;

    public interface IDeleteNewsService
    {
        ICollection<DeleteNewsViewModel> GetAllNews();

        Task DeleteNews(DeleteNewsInputModel model);
    }
}