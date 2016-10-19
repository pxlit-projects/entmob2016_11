namespace Smart_Garden.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDiscriminatorFluentAPIToUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Discriminator", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Discriminator", c => c.String());
        }
    }
}
