using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatabaseProject.Models
{
    public class Person
    {
        [Key]
        [Range(0,8)]
        public int PersonID { get; set; }

        [Required]
        [StringLength(30)]
        [Index("Idx_Person_FN_LN", 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [Index("Idx_Person_FN_LN", 2)]
        public string Lastname { get; set; }

        [StringLength(30)]
        public string Street { get; set; }

        [StringLength(30)]
        public string Street2 { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }

        [Range(5,5, ErrorMessage = "Zipcode requires 5 digits.")]
        public int Zip { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [Range(7,10)]
        public int Phone { get; set; }
    }
}