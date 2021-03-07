// <copyright file="IHomeService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Home
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Models.Users;

    public interface IHomeService
    {
        Task SubmitAllRoles();

        Task<bool> HasAdministrator();

        Task MakeYourselfAdmin(ApplicationUser currentUser);
    }
}