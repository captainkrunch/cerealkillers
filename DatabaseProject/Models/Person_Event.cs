using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatabaseProject.Models
{
    public class Person_Event
    {
        [Key, ForeignKey("Person"), Column(Order = 1)]
        public int PersonID { get; set; }

        [Key, ForeignKey("Event"), Column(Order = 2)]
        public int EventID { get; set; }

        public int TicketNumber { get; set; }

        public int BidderNumber { get; set; }

        public virtual Item Person { get; set; }

        public virtual Event Event { get; set; }
    }
}