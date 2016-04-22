namespace Parliament.JargonBuster.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedhousetypeenumtodefinitionitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DefinitionItems", "HouseType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DefinitionItems", "HouseType");
        }
    }
}
