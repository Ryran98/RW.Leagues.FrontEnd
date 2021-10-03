namespace RW.Leagues.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMatches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryAId = c.Int(nullable: false),
                        EntryBId = c.Int(nullable: false),
                        Round = c.Int(nullable: false),
                        PlayerAGamesWon = c.Int(nullable: false),
                        PlayerBGamesWon = c.Int(nullable: false),
                        Game1Score = c.String(nullable: false),
                        Game2Score = c.String(nullable: false),
                        Game3Score = c.String(nullable: false),
                        Game4Score = c.String(),
                        Game5Score = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Entry", t => t.EntryAId)
                .ForeignKey("dbo.tb_Entry", t => t.EntryBId)
                .Index(t => t.EntryAId)
                .Index(t => t.EntryBId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "EntryBId", "dbo.tb_Entry");
            DropForeignKey("dbo.Matches", "EntryAId", "dbo.tb_Entry");
            DropIndex("dbo.Matches", new[] { "EntryBId" });
            DropIndex("dbo.Matches", new[] { "EntryAId" });
            DropTable("dbo.Matches");
        }
    }
}
