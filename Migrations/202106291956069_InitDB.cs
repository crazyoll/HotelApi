namespace ArkadiuszGrygorukServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReservationCode = c.String(nullable: false, maxLength: 10),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationDate = c.DateTime(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        Currency = c.String(nullable: false),
                        Commission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Source = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GuestBookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookingID = c.Int(nullable: false),
                        GuestID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bookings", t => t.BookingID, cascadeDelete: true)
                .ForeignKey("dbo.Guests", t => t.GuestID, cascadeDelete: true)
                .Index(t => t.BookingID)
                .Index(t => t.GuestID);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BirthDate = c.DateTime(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GuestBookings", "GuestID", "dbo.Guests");
            DropForeignKey("dbo.GuestBookings", "BookingID", "dbo.Bookings");
            DropIndex("dbo.GuestBookings", new[] { "GuestID" });
            DropIndex("dbo.GuestBookings", new[] { "BookingID" });
            DropTable("dbo.Guests");
            DropTable("dbo.GuestBookings");
            DropTable("dbo.Bookings");
        }
    }
}
