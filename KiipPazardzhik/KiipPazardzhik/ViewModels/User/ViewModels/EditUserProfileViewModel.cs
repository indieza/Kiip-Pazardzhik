// <copyright file="EditUserProfileViewModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.ViewModels.User.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditUserProfileViewModel
    {
        [Phone]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Име")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Презиме")]
        [MaxLength(20)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Фамилия")]
        [MaxLength(20)]
        public string LastName { get; set; }
    }
}