namespace RW.Leagues.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatingToPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Player", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Player", "Rating");
        }
    }
}
