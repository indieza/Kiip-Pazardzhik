// <copyright file="INewsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.News
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.ViewModels.Website.ViewModels;

    public interface INewsService
    {
        ICollection<SingleNewsViewModel> GetAllNews();

        Task<SingleNewsViewModel> GetNewsById(string id);

        Task<Tuple<byte[], string>> GetFile(string id);
    }
}