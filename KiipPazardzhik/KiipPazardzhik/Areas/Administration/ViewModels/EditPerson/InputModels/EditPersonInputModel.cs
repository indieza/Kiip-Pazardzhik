﻿// <copyright file="EditPersonInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.EditPerson.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class EditPersonInputModel
    {
        [Required(ErrorMessage = "Полето е задължително!")]
        [Display(Name = "Човек")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(20)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(20)]
        [Display(Name = "Презиме")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(20)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [Phone]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [MaxLength(100)]
        [Display(Name = "Мейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(70)]
        [Display(Name = "Регистрационен номер")]
        public string RegisterNumber { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(20)]
        [Display(Name = "Секция")]
        public string Section { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(20)]
        [Display(Name = "Правоспособност")]
        public string LegalCapacity { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [Display(Name = "Замразен")]
        public bool IsFrozen { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [Display(Name = "Активен")]
        public bool IsActive { get; set; }
    }
}