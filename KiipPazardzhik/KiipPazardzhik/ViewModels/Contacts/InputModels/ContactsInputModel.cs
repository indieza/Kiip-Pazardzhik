// <copyright file="ContactsInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.ViewModels.Contacts.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class ContactsInputModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Име")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Мейл")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Съдържание")]
        public string Description { get; set; }
    }
}