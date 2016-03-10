using System.Data.Entity;

namespace Parliament.JargonBuster.Core.Domain.Context
{
    public class JargonBusterDbContext : DbContext
    {
        public DbSet<DefinitionItem> Definitions { get; set; }
        public DbSet<AlternateDefinitionItem> AlternateDefinitionItems { get; set; }
    }
}
