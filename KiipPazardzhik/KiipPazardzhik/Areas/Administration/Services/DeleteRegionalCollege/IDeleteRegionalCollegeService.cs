// <copyright file="IDeleteRegionalCollegeService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.DeleteRegionalCollege
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteRegionalCollege.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteRegionalCollege.ViewModels;

    public interface IDeleteRegionalCollegeService
    {
        ICollection<DeleteRegionalCollegeViewModel> GetAllGolleges();

        Task DeleteRegionalCollege(DeleteRegionalCollegeInputModel model);
    }
}