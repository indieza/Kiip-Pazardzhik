// <copyright file="IEditNewsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.EditNews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditNews.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditNews.ViewModels;

    public interface IEditNewsService
    {
        ICollection<EditNewsViewModel> GetAllNews();

        Task<GetNewsDataViewModel> GetNewsById(string newsId);

        Task EditNews(EditNewsInputModel model);
    }
}