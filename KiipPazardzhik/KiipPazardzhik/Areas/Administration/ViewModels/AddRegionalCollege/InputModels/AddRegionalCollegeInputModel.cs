// <copyright file="AddRegionalCollegeInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.AddRegionalCollege.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddRegionalCollegeInputModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Име")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Линк")]
        public string Url { get; set; }
    }
}