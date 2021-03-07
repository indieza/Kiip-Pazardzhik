// <copyright file="ApplicationUser.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
    }
}