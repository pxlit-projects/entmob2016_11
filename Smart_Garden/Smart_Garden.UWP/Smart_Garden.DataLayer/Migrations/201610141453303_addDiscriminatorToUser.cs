namespace Smart_Garden.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDiscriminatorToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Discriminator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Discriminator");
        }
    }
}
