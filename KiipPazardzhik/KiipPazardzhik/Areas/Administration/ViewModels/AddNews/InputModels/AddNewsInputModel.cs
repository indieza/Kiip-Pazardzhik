// <copyright file="AddNewsInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.AddNews.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Ganss.XSS;
    using Microsoft.AspNetCore.Http;

    public class AddNewsInputModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [MaxLength(100)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Съдържание")]
        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        [Display(Name = "Файлове")]
        public ICollection<IFormFile> WebsiteFiles { get; set; } = new HashSet<IFormFile>();
    }
}