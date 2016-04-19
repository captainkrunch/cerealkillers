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

        [RegularExpression(@"^[0-9]{5,5}$", ErrorMessage = "Zip Code must be 5 digits")]
        public string Zip { get; set; }

        [StringLength(40)]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^[0-9]{10,10}$", ErrorMessage = "Phone must be 10 digits")]
        public string Phone { get; set; }

        public ICollection<Person_Team> Persons;
    }
}