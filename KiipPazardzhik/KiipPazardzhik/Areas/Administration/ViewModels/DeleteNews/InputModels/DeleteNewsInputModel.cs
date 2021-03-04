// <copyright file="DeleteNewsInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.DeleteNews.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeleteNewsInputModel
    {
        [Required(ErrorMessage = "Полето е задължително!")]
        [Display(Name = "Новина")]
        public string Id { get; set; }
    }
}