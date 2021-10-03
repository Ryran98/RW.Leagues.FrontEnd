namespace RW.Leagues.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntrySeedNumberOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Entry", "SeedNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Entry", "SeedNumber", c => c.Int(nullable: false));
        }
    }
}
