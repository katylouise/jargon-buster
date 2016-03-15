using System.Collections.Generic;
using System.Linq;
using NLog;
using Parliament.JargonBuster.Core.Domain;
using Parliament.JargonBuster.Core.Domain.Context;

namespace Parliament.JargonBuster.Core.Services
{
    public class DefinitionsService : IDefinitionsService
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public IList<DefinitionItem> GetDefinitions()
        {
            using (var context = new JargonBusterDbContext())
            {
                _logger.Debug("Service Layer - Getting Definitions");
                return context.Definitions
                              .Include("Alternates")
                              .ToList();
            }
        }
    }
}
