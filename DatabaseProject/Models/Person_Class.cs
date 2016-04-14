using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatabaseProject.Models
{
    public class Person_Class
    {
        [Key, ForeignKey("Person"), Column(Order = 1)]
        public int PersonID { get; set; }

        [Key, ForeignKey("Class"), Column(Order = 2)]
        public int ClassID { get; set; }

        public virtual Person Person { get; set; }

        public virtual Class Class { get; set; }
    }
}