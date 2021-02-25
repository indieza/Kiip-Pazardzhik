using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KiipPazardzhik.Models
{
    public class News
    {
        public News()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [MaxLength(250)]
        public string ShortDescription { get; set; }

        public ICollection<WebsiteFile> WebsiteFiles { get; set; } = new HashSet<WebsiteFile>();
    }
}