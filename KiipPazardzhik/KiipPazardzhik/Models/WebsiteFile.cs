﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KiipPazardzhik.Models
{
    public class WebsiteFile
    {
        public WebsiteFile()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [ForeignKey(nameof(News))]
        public string NewsId { get; set; }

        public News News { get; set; }
    }
}