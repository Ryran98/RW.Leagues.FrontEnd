namespace RW.Leagues.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableNameToMatch : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Matches", newName: "tb_Match");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tb_Match", newName: "Matches");
        }
    }
}
