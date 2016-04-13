using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatabaseProject.Models
{
    public class Item
    {
        [Key, Column(Order = 0)]
        [Index("Idx_Item_IID_DID", 1)]
        [Index("Idx_Item_IID_SB_BI", 1)]
        public int ItemID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [Index("Idx_Item_IID_SB_BI", 2)]
        public decimal Start_Bid { get; set; }

        [Required]
        [Index("Idx_Item_IID_SB_BI", 3)]
        public decimal Bid_Increment { get; set; }

        [Required]
        public decimal WonBidAmount { get; set; }

        [Required]
        public decimal Value { get; set; }

        public decimal BuyItNowPrice { get; set; }


        // DON'T KNOW HOW TO DO THIS SINCE THEY CAN'T ALL BE 
        // SET TO PERSONID?

        //[Range(0, 8)]
        //[ForeignKey("Person"), Column(Order = 1)]
        //public int SolicitorID { get; set; }

        //[Range(0, 8)]
        //[ForeignKey("Person"), Column(Order = 2)]
        //[Index("Idx_Item_IID_DID", 1)]
        //public int DonorID { get; set; }

        //[Range(0, 8)]
        //[ForeignKey("Person"), Column(Order = 3)]
        //[Index("Idx_Item_WID_PT_PM", 1)]
        //public int WinnerID { get; set; }

        [Index("Idx_Item_WID_PT_PM", 2)]
        public DateTime PayTime { get; set; }

        [StringLength(20)]
        [Index("Idx_Item_WID_PT_PM", 3)]
        public string PayMethod { get; set; }
    }
}