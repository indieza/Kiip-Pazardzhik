// <copyright file="RegisterUserInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.ViewModels.User.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class RegisterUserInputModel
    {
        [Required(ErrorMessage = "Потребителското име е задължително!")]
        [Display(Name = "Потребителско Име")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Името е задължително поле!")]
        [MaxLength(20)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Презимето е задължително поле!")]
        [MaxLength(20)]
        [Display(Name = "Презиме")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Фамилията е задължително поле!")]
        [MaxLength(20)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Мейла е задължителен!")]
        [EmailAddress]
        [Display(Name = "Мейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Паролата е задължителен!")]
        [StringLength(100, ErrorMessage = "{0} трябва да бъди минимум {2} и максимум {1} знака.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърди Парола")]
        [Compare("Password", ErrorMessage = "Двете пароли не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }
}