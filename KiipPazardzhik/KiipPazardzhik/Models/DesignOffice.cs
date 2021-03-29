// <copyright file="DesignOffice.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DesignOffice
    {
        public DesignOffice()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}