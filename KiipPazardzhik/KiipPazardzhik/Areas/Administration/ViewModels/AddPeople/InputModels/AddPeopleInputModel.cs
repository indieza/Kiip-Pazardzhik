// <copyright file="AddPeopleInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.AddPeople.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public class AddPeopleInputModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Файл")]
        public IFormFile File { get; set; }
    }
}