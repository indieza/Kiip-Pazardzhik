// <copyright file="DeleteRegionalCollegeInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.DeleteRegionalCollege.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeleteRegionalCollegeInputModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Регионална колегия")]
        public string Id { get; set; }
    }
}