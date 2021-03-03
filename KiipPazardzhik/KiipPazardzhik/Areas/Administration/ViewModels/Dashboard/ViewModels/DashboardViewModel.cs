// <copyright file="DashboardViewModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.Dashboard.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KiipPazardzhik.Models.Users;

    public class DashboardViewModel
    {
        public ICollection<ApplicationUser> AllUsers { get; set; } = new HashSet<ApplicationUser>();

        public ICollection<string> AllAdminsNames { get; set; } = new HashSet<string>();

        public ICollection<string> AllNotAdminsNames { get; set; } = new HashSet<string>();

        public int AllUsersCount { get; set; }

        public int AllAdminsCount { get; set; }
    }
}