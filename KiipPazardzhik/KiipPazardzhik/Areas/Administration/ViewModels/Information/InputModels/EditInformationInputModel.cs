// <copyright file="EditInformationInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.Information.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using Ganss.XSS;

    public class EditInformationInputModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);
    }
}