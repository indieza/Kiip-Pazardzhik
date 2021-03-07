// <copyright file="IDashboardService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.Dashboard
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KiipPazardzhik.Models.Users;

    public interface IDashboardService
    {
        ICollection<ApplicationUser> GetAllUsers();

        Task<int> GetAllAdminsCount();

        Task<int> GetAllUsersCount();

        Task<ICollection<string>> GetAllAdminsNames();

        Task<ICollection<string>> GetAllNotAdminsNames();

        Task RemoveAdministrator(string username);

        Task AddAdministrator(string username);

        Task ApproveUser(string id);
    }
}