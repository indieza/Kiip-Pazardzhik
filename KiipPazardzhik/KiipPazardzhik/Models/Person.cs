// <copyright file="Person.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        public Person()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Position { get; set; }

        [MaxLength(60)]
        public string TechnicalControl { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(70)]
        public string RegisterNumber { get; set; }

        [Required]
        [MaxLength(20)]
        public string Section { get; set; }

        [MaxLength(100)]
        public string TechnologistKind { get; set; }

        [Required]
        [MaxLength(20)]
        public string LegalCapacity { get; set; }

        [Required]
        public bool IsFrozen { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}