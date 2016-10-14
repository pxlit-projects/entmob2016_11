namespace Smart_Garden.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserAndTimeToSensorAbove : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SensorAboves", "Time_Of_Record", c => c.DateTime());
            AddColumn("dbo.SensorAboves", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.SensorAboves", "UserId");
            AddForeignKey("dbo.SensorAboves", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SensorAboves", "UserId", "dbo.Users");
            DropIndex("dbo.SensorAboves", new[] { "UserId" });
            DropColumn("dbo.SensorAboves", "UserId");
            DropColumn("dbo.SensorAboves", "Time_Of_Record");
        }
    }
}
