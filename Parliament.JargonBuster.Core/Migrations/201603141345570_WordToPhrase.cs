using System.Data.Entity.Migrations;

namespace Parliament.JargonBuster.Core.Migrations
{
    public partial class WordToPhrase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DefinitionItems", "Phrase", c => c.String());
            DropColumn("dbo.DefinitionItems", "Word");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DefinitionItems", "Word", c => c.String());
            DropColumn("dbo.DefinitionItems", "Phrase");
        }
    }
}
