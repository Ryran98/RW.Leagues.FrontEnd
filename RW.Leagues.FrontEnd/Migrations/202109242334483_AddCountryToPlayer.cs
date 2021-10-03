namespace RW.Leagues.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryToPlayer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tb_Player", "CountryId", c => c.Int(nullable: false, defaultValue: 1));
            CreateIndex("dbo.tb_Player", "CountryId");
            AddForeignKey("dbo.tb_Player", "CountryId", "dbo.tb_Country", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Player", "CountryId", "dbo.tb_Country");
            DropIndex("dbo.tb_Player", new[] { "CountryId" });
            DropColumn("dbo.tb_Player", "CountryId");
            DropTable("dbo.tb_Country");
        }
    }
}
