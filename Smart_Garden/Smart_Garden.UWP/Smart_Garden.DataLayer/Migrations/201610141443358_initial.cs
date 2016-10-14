namespace Smart_Garden.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Crops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temp = c.Double(nullable: false),
                        Humid = c.Double(nullable: false),
                        Light = c.Double(nullable: false),
                        Time_Of_Year = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SensorAboves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temp = c.Double(nullable: false),
                        Humid = c.Double(nullable: false),
                        Light = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SensorBelows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temp = c.Double(nullable: false),
                        Humid = c.Double(nullable: false),
                        Light = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        Time_Of_Record = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SensorBelows", "UserId", "dbo.Users");
            DropIndex("dbo.SensorBelows", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.SensorBelows");
            DropTable("dbo.SensorAboves");
            DropTable("dbo.Crops");
        }
    }
}
