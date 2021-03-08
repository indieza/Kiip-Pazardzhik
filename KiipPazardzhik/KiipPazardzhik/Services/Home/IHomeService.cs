// <copyright file="IHomeService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Home
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KiipPazardzhik.Models.Users;
    using KiipPazardzhik.ViewModels.Website.ViewModels;

    public interface IHomeService
    {
        Task SubmitAllRoles();

        Task<bool> HasAdministrator();

        Task MakeYourselfAdmin(ApplicationUser currentUser);

        ICollection<SingleNewsViewModel> GetTopNews(int count);
    }
}