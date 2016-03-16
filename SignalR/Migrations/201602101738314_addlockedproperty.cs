namespace SignalR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlockedproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Locked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Locked");
        }
    }
}
