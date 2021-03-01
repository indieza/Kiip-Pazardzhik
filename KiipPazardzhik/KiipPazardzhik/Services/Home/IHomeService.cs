// <copyright file="IHomeService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Home
{
    using KiipPazardzhik.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IHomeService
    {
        Task SubmitAllRoles();

        Task<bool> HasAdministrator();
        Task MakeYourselfAdmin(ApplicationUser currentUser);
    }
}