using System.Collections.Generic;
using System.Linq;
using Parliament.JargonBuster.Core.Domain;
using Parliament.JargonBuster.Core.Domain.Context;

namespace Parliament.JargonBuster.Core.Services
{
    public class DefinitionsService : IDefinitionsService
    {
        public IQueryable<DefinitionItem> GetDefinitions()
        {
            using (var context = new JargonBusterDbContext())
            {
                return context.Definitions;
            }
        }
    }
}
