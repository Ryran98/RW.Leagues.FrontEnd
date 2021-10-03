namespace RW.Leagues.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeedNumberToEntry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Entry", "SeedNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Entry", "SeedNumber");
        }
    }
}
