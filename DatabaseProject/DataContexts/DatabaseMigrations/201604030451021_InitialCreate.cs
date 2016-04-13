namespace DatabaseProject.DataContexts.DatabaseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ClassID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        Title = c.String(nullable: false, maxLength: 30),
                        Type = c.String(maxLength: 30),
                        Street = c.String(maxLength: 30),
                        City = c.String(nullable: false, maxLength: 30),
                        State = c.String(nullable: false, maxLength: 2),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .Index(t => new { t.EventID, t.Date }, name: "Idx_Event_EID_Date");
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 100),
                        Start_Bid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bid_Increment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WonBidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuyItNowPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayTime = c.DateTime(nullable: false),
                        PayMethod = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ItemID)
                .Index(t => t.ItemID, name: "Idx_Item_IID_DID")
                .Index(t => new { t.ItemID, t.Start_Bid, t.Bid_Increment }, name: "Idx_Item_IID_SB_BI")
                .Index(t => new { t.ItemID, t.WonBidAmount }, name: "Idx_Item_IID_WBA_WID")
                .Index(t => new { t.PayTime, t.PayMethod }, name: "Idx_Item_WID_PT_PM");
            
            CreateTable(
                "dbo.Person_Class",
                c => new
                    {
                        PersonID = c.Int(nullable: false),
                        ClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonID, t.ClassID })
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.ClassID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        Lastname = c.String(nullable: false, maxLength: 30),
                        Street = c.String(maxLength: 30),
                        Street2 = c.String(maxLength: 30),
                        City = c.String(maxLength: 30),
                        State = c.String(maxLength: 2),
                        Zip = c.Int(nullable: false),
                        Email = c.String(maxLength: 40),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID)
                .Index(t => new { t.FirstName, t.Lastname }, name: "Idx_Person_FN_LN");
            
            CreateTable(
                "dbo.Person_Event",
                c => new
                    {
                        PersonID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                        TicketNumber = c.Int(nullable: false),
                        BidderNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonID, t.EventID })
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Person_Team",
                c => new
                    {
                        PersonID = c.Int(nullable: false),
                        TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonID, t.TeamID })
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person_Team", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.Person_Team", "PersonID", "dbo.People");
            DropForeignKey("dbo.Person_Event", "PersonID", "dbo.People");
            DropForeignKey("dbo.Person_Event", "EventID", "dbo.Events");
            DropForeignKey("dbo.Person_Class", "PersonID", "dbo.People");
            DropForeignKey("dbo.Person_Class", "ClassID", "dbo.Classes");
            DropIndex("dbo.Person_Team", new[] { "TeamID" });
            DropIndex("dbo.Person_Team", new[] { "PersonID" });
            DropIndex("dbo.Person_Event", new[] { "EventID" });
            DropIndex("dbo.Person_Event", new[] { "PersonID" });
            DropIndex("dbo.People", "Idx_Person_FN_LN");
            DropIndex("dbo.Person_Class", new[] { "ClassID" });
            DropIndex("dbo.Person_Class", new[] { "PersonID" });
            DropIndex("dbo.Items", "Idx_Item_WID_PT_PM");
            DropIndex("dbo.Items", "Idx_Item_IID_WBA_WID");
            DropIndex("dbo.Items", "Idx_Item_IID_SB_BI");
            DropIndex("dbo.Items", "Idx_Item_IID_DID");
            DropIndex("dbo.Events", "Idx_Event_EID_Date");
            DropTable("dbo.Teams");
            DropTable("dbo.Person_Team");
            DropTable("dbo.Person_Event");
            DropTable("dbo.People");
            DropTable("dbo.Person_Class");
            DropTable("dbo.Items");
            DropTable("dbo.Events");
            DropTable("dbo.Classes");
        }
    }
}
