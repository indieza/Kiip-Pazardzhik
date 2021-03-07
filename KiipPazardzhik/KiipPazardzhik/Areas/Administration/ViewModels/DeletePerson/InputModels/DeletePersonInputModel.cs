// <copyright file="DeletePersonInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.DeletePerson.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class DeletePersonInputModel
    {
        [Required(ErrorMessage = "Полето е задължително!")]
        [Display(Name = "Човек")]
        public string Id { get; set; }
    }
}