// <copyright file="IAddNewsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddNews
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.AddNews.InputModels;

    public interface IAddNewsService
    {
        Task AddNews(AddNewsInputModel model);
    }
}