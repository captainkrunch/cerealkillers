using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatabaseProject.Models
{
    public class Class
    {
        [Key]
        public int ClassID { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        ///This is a comment
    }
}