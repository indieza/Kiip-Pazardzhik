// <copyright file="RegionalCollege.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegionalCollege
    {
        public RegionalCollege()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string DisplayName { get; set; }

        [Required]
        public string Url { get; set; }
    }
}