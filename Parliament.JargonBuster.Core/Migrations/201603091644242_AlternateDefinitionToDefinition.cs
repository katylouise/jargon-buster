namespace Parliament.JargonBuster.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlternateDefinitionToDefinition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlternateDefinitionItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlternateDefinition = c.String(),
                        DefinitionItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DefinitionItems", t => t.DefinitionItem_Id)
                .Index(t => t.DefinitionItem_Id);
            
            CreateTable(
                "dbo.DefinitionItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Definition = c.String(),
                        Word = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlternateDefinitionItems", "DefinitionItem_Id", "dbo.DefinitionItems");
            DropIndex("dbo.AlternateDefinitionItems", new[] { "DefinitionItem_Id" });
            DropTable("dbo.DefinitionItems");
            DropTable("dbo.AlternateDefinitionItems");
        }
    }
}
