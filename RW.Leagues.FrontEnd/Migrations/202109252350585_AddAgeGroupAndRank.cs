namespace RW.Leagues.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgeGroupAndRank : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_AgeGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Rank",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        AgeGroupId = c.Int(nullable: false),
                        EventCount = c.Int(nullable: false),
                        Points = c.Double(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_AgeGroup", t => t.AgeGroupId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.AgeGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Rank", "PlayerId", "dbo.tb_Player");
            DropForeignKey("dbo.tb_Rank", "AgeGroupId", "dbo.tb_AgeGroup");
            DropIndex("dbo.tb_Rank", new[] { "AgeGroupId" });
            DropIndex("dbo.tb_Rank", new[] { "PlayerId" });
            DropTable("dbo.tb_Rank");
            DropTable("dbo.tb_AgeGroup");
        }
    }
}
