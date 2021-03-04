// <copyright file="DocumentType.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum DocumentType
    {
        [Display(Name = "Инструкции и формуляри")]
        InstructionsAndForms = 1,
        [Display(Name = "Членски внос")]
        MembershipFee = 2,
        [Display(Name = "Външна нормативна уредба")]
        ExternalRegulations = 3,
        [Display(Name = "Вътрешна нормативна уредба")]
        InternalRegulations = 4,
    }
}