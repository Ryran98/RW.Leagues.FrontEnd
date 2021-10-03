namespace RW.Leagues.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Entry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Event", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Entry", "PlayerId", "dbo.tb_Player");
            DropForeignKey("dbo.tb_Entry", "EventId", "dbo.tb_Event");
            DropIndex("dbo.tb_Entry", new[] { "EventId" });
            DropIndex("dbo.tb_Entry", new[] { "PlayerId" });
            DropTable("dbo.tb_Entry");
        }
    }
}
