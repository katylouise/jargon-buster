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

        public void AddDefinition(DefinitionItem definitionItem)
        {
            using (var context = new JargonBusterDbContext())
            {
                context.Definitions.Add(definitionItem);
                context.SaveChanges();
            }
        }

        public void UpdateDefinitionItem(DefinitionItem definitionItem)
        {
            using (var context = new JargonBusterDbContext())
            {
                var definition = context.Definitions
                                        .Include("Alternates")
                                        .Single(x => x.Id == definitionItem.Id);
                definition.Definition = definitionItem.Definition;
                definition.Phrase = definitionItem.Phrase;
                
                if (definitionItem.Alternates.Any())
                {
                    UpdateAlternateDefinitionItems(definitionItem, definition);
                }
                //context.Entry(definition).CurrentValues.SetValues(definitionItem);
                //TODO Alternates

                context.SaveChanges();
            }
        }

        private void UpdateAlternateDefinitionItems(DefinitionItem newDefinitionItem, DefinitionItem existingDefinitionItem)
        {
            foreach (var item in newDefinitionItem.Alternates)
            {
                if(item.Id != 0 && existingDefinitionItem.Alternates.Any(x => x.Id == item.Id))
                {
                    var exisitingAlternate = existingDefinitionItem.Alternates.First(x => x.Id == item.Id);
                    exisitingAlternate.AlternateDefinition = item.AlternateDefinition;
                }

                else
                {
                    existingDefinitionItem.Alternates.Add(item);
                }
            }
            RemoveAlternates(existingDefinitionItem, newDefinitionItem);
        }

        private void RemoveAlternates(DefinitionItem exisitingDefinitionItem, DefinitionItem newDefinitionItem)
        {
            var alternateToRemove = new List<AlternateDefinitionItem>();

            foreach (var item in exisitingDefinitionItem.Alternates)
            {
                if (newDefinitionItem.Alternates.All(x => x.Id != item.Id))
                {
                    alternateToRemove.Add(item);
                }
            }

            foreach (var item in alternateToRemove)
            {
                //delete each alternate here
            }

        }
    }
}


