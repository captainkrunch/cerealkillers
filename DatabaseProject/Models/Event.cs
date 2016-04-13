using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseProject.Models
{
    public class Event
    {
        [Key]
        [Index("Idx_Event_EID_Date", 1)]
        public int EventID { get; set; }

        [Required]
        [Index("Idx_Event_EID_Date", 2)]
        public DateTime Date { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [StringLength(30)]
        public string Type { get; set; }

        [StringLength(30)]
        public string Street { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{5,5}$", ErrorMessage = "Zip Code must be 5 digits")]
        public string Zip { get; set; }

    }
}