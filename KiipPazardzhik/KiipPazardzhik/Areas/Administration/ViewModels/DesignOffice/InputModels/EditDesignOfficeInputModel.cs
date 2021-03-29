// <copyright file="EditDesignOfficeInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.DesignOffice.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using Ganss.XSS;

    public class EditDesignOfficeInputModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Съдържание")]
        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);
    }
}