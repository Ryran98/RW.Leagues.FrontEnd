namespace RW.Leagues.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgeGroupToEntry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Entry", "AgeGroupId", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Match", "RoundNumber", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Entry", "AgeGroupId");
            AddForeignKey("dbo.tb_Entry", "AgeGroupId", "dbo.tb_AgeGroup", "Id", cascadeDelete: true);
            DropColumn("dbo.tb_Match", "Round");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Match", "Round", c => c.Int(nullable: false));
            DropForeignKey("dbo.tb_Entry", "AgeGroupId", "dbo.tb_AgeGroup");
            DropIndex("dbo.tb_Entry", new[] { "AgeGroupId" });
            DropColumn("dbo.tb_Match", "RoundNumber");
            DropColumn("dbo.tb_Entry", "AgeGroupId");
        }
    }
}
