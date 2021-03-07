// <copyright file="DashboardBaseModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.Dashboard.ViewModels
{
    using KiipPazardzhik.Areas.Administration.ViewModels.Dashboard.InputModels;

    public class DashboardBaseModel
    {
        public DashboardViewModel DashboardViewModel { get; set; } = new DashboardViewModel();

        public AddRemoveAdminInputModel AddRemoveAdminInputModel { get; set; } =
            new AddRemoveAdminInputModel();
    }
}