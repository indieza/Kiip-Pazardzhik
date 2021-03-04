// <copyright file="Document.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using KiipPazardzhik.Models.Enums;

    public class Document
    {
        public Document()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [EnumDataType(typeof(DocumentType))]
        public DocumentType DocumentType { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }
    }
}