using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evoting.Models
{
    public class User
    {
      

        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(15)")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(10)]
        public string UserPassword { get; set; }

        [Required]
        public string UserFullName { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public string UserDOB { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        public string UserGender { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$")]
        public double UserMobile { get; set; }

      
    }
}
