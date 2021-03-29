// <copyright file="IAddRegionalCollege.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddRegionalCollege
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.AddRegionalCollege.InputModels;

    public interface IAddRegionalCollegeService
    {
        Task AddRegionalCollege(AddRegionalCollegeInputModel model);
    }
}