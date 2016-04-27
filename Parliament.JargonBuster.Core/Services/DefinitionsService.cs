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

        public void AddDefinitionItem(DefinitionItem definitionItem)
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
                definition.UpdatedAt = definitionItem.UpdatedAt;
                definition.HouseType = definitionItem.HouseType;
                
                if (definitionItem.Alternates.Any())
                {
                    UpdateAlternateDefinitionItems(definitionItem, definition);
                }
                context.SaveChanges();
            }
        }

        public void DeleteDefinitionItem(DefinitionItem definitionItem)
        {
            using (var context = new JargonBusterDbContext())
            {
                var definition = context.Definitions
                                        .Include("Alternates")
                                        .Single(x => x.Id == definitionItem.Id);
                if (definition.Alternates.Any())
                {
                    context.AlternateDefinitionItems.RemoveRange(definition.Alternates);
                }
                context.Definitions.Remove(definition);
                context.SaveChanges();
            }
        }

        private void UpdateAlternateDefinitionItems(DefinitionItem newDefinitionItem, DefinitionItem existingDefinitionItem)
        {
            foreach (var item in newDefinitionItem.Alternates)
            {
                if (item.AlternateDefinition != null)
                {
                    if (item.Id != 0 && existingDefinitionItem.Alternates.Any(x => x.Id == item.Id))
                    {
                        //existing one - update
                        var exisitingAlternate = existingDefinitionItem.Alternates.First(x => x.Id == item.Id);
                        exisitingAlternate.AlternateDefinition = item.AlternateDefinition;
                    }

                    else
                    {
                        // new one
                        existingDefinitionItem.Alternates.Add(item);
                    }
                }
                else
                {
                    //existing one - delete
                    if(item.AlternateDefinition != null)
                    {
                        RemoveAlternate(existingDefinitionItem, item);
                    }
                }
            }          
        }

        private void RemoveAlternate(DefinitionItem exisitingDefinitionItem, AlternateDefinitionItem item)
        {
            using (var context = new JargonBusterDbContext())
            {
                var altToRemove = context.AlternateDefinitionItems.First(x => x.Id == item.Id);
                context.Definitions.Include("Alternates")
                                   .Single(x => x.Id == exisitingDefinitionItem.Id).Alternates.Remove(altToRemove);
                context.AlternateDefinitionItems.Remove(altToRemove);
                context.SaveChanges();
            }
        }
    }
}


