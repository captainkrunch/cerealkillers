using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatabaseProject.Models
{
    public class Team
    {
        [Key]
        [Range(0, 8)]
        public int TeamID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(40)]
        public string Email { get; set; }
    }
}