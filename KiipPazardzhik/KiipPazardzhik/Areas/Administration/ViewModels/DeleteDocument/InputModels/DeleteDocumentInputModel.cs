// <copyright file="DeleteDocumentInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.DeleteDocument.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeleteDocumentInputModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Документ")]
        public string Id { get; set; }
    }
}