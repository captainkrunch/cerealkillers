using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatabaseProject.Models
{
    public class Person_Team
    {
        [Key, ForeignKey("Person"), Column(Order = 1)]
        [Range(0, 8)]
        public int PersonID { get; set; }

        [Key, ForeignKey("Team"), Column(Order = 2)]
        [Range(0, 8)]
        public int TeamID { get; set; }

        public virtual Person Person { get; set; }

        public virtual Team Team { get; set; }
    }
}