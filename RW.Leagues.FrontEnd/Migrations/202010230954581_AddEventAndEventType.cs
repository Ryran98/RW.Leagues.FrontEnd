namespace RW.Leagues.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventAndEventType : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Players", newName: "tb_Player");
            CreateTable(
                "dbo.tb_Event",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_EventType", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.tb_EventType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        BasePointsPerRound = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Event", "TypeId", "dbo.tb_EventType");
            DropIndex("dbo.tb_Event", new[] { "TypeId" });
            DropTable("dbo.tb_EventType");
            DropTable("dbo.tb_Event");
            RenameTable(name: "dbo.tb_Player", newName: "Players");
        }
    }
}
