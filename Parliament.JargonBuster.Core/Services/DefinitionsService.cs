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

        public DefinitionItem GetDefinitionById(int id)
        {
            using (var context = new JargonBusterDbContext())
            {
                return context.Definitions
                              .Include("Alternates")
                              .Where(x => x.Id == id)
                              .Single();
            }
        }

        public DefinitionItem GetDefinitionByPhrase(string phrase)
        {
            using (var context = new JargonBusterDbContext())
            {
                var definition = context.Definitions
                                        .Include("Alternates")
                                        .Where(x => x.Phrase.ToLower().Contains(phrase.ToLower()));

                return definition.Count() != 0 ? definition.Single() : null;
            }
        }

        public void UpdateDefinitionItem(DefinitionItem definitionItem)
        {
            using (var context = new JargonBusterDbContext())
            {
                var definition = context.Definitions.Single(x => x.Id == definitionItem.Id);
                context.Entry(definition).CurrentValues.SetValues(definitionItem);
                //TODO Alternates

                context.SaveChanges();
            }
        }

        public void AddDefinition(DefinitionItem definitionItem)
        {
            using (var context = new JargonBusterDbContext())
            {
                context.Definitions.Add(definitionItem);
                context.SaveChanges();
            }
        }
    }
}

