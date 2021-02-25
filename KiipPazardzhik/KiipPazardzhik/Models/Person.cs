using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KiipPazardzhik.Models
{
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
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

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

        [Required]
        [MaxLength(20)]
        public string LegalCapacity { get; set; }

        [Required]
        public bool IsFrozen { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}