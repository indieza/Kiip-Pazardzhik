// <copyright file="AddDocumentInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.AddDocument.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using KiipPazardzhik.Models.Enums;

    using Microsoft.AspNetCore.Http;

    public class AddDocumentInputModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Тип документ")]
        public DocumentType DocumentType { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Документи")]
        public ICollection<IFormFile> Files { get; set; } = new HashSet<IFormFile>();
    }
}