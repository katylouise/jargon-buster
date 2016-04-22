namespace Parliament.JargonBuster.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtimestampstoDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DefinitionItems", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.DefinitionItems", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DefinitionItems", "UpdatedAt");
            DropColumn("dbo.DefinitionItems", "CreatedAt");
        }
    }
}
