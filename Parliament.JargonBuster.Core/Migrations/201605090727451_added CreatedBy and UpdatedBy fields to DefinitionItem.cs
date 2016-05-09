namespace Parliament.JargonBuster.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCreatedByandUpdatedByfieldstoDefinitionItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DefinitionItems", "CreatedBy", c => c.String());
            AddColumn("dbo.DefinitionItems", "UpdatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DefinitionItems", "UpdatedBy");
            DropColumn("dbo.DefinitionItems", "CreatedBy");
        }
    }
}
