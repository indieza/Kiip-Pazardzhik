// <copyright file="DeleteDocumentInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.DeleteDocument.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteDocumentInputModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Документ")]
        public string Id { get; set; }
    }
}