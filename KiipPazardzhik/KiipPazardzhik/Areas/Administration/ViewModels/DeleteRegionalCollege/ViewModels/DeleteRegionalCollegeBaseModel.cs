// <copyright file="DeleteRegionalCollegeBaseModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.DeleteRegionalCollege.ViewModels
{
    using System.Collections.Generic;

    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteRegionalCollege.InputModels;

    public class DeleteRegionalCollegeBaseModel
    {
        public DeleteRegionalCollegeInputModel DeleteRegionalCollegeInputModel { get; set; }

        public ICollection<DeleteRegionalCollegeViewModel> AllRegionalColleges { get; set; } =
            new HashSet<DeleteRegionalCollegeViewModel>();
    }
}