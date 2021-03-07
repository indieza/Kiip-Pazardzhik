// <copyright file="AddRemoveAdminInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.Dashboard.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddRemoveAdminInputModel
    {
        [Required(ErrorMessage = "Потребителското име е задължително!")]
        [Display(Name = "Потребителско име")]
        public string Username { get; set; }
    }
}