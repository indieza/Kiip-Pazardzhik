// <copyright file="IAddNewsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddNews
{
    using KiipPazardzhik.Areas.Administration.ViewModels.AddNews.InputModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAddNewsService
    {
        Task AddNews(AddNewsInputModel model);
    }
}