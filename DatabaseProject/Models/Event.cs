using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatabaseProject.Models
{
    public class Event
    {
        [Key]
        [Range(0,8)]
        [Index("Idx_Event_EID_Date", 1)]
        public int EventID { get; set; }

        [Required]
        [Index("Idx_Event_EID_Date", 2)]
        public DateTime Date { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

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
        [Range(4, 5, ErrorMessage = "Zipcode requires 5 digits.")]
        public int Zip { get; set; }
    }
}