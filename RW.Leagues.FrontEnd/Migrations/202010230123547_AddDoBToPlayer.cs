namespace RW.Leagues.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoBToPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "DateOfBirth");
        }
    }
}
