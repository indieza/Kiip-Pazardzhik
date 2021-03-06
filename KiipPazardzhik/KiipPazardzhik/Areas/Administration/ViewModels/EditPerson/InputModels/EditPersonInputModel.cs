﻿// <copyright file="EditPersonInputModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.EditPerson.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditPersonInputModel
    {
        [Required(ErrorMessage = "Полето е задължително!")]
        [Display(Name = "Човек")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(40)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(40)]
        [Display(Name = "Презиме")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(40)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(100)]
        [Display(Name = "Позиция")]
        public string Position { get; set; }

        [MaxLength(60)]
        [Display(Name = "Технически контрол")]
        public string TechnicalControl { get; set; }

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

        [MaxLength(100)]
        [Display(Name = "Вид технолог")]
        public string TechnologistKind { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(20)]
        [Display(Name = "Правоспособност")]
        public string LegalCapacity { get; set; }
    }
}