using AdminApp.ViewModels;
using Parliament.JargonBuster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminApp.ViewModelBuilders
{
    public class AlternateItemsViewModelBuilder : IAlternateItemsViewModelBuilder
    {
        public List<AlternateItemViewModel> Build(DefinitionItem defintionItem)
        {
            var alternateItems = defintionItem.Alternates;
            return alternateItems.Select(BuildAlternateItemViewModel).ToList();

        }

        private AlternateItemViewModel BuildAlternateItemViewModel(AlternateDefinitionItem alternate)
        {
            return new AlternateItemViewModel
            {
                Id = alternate.Id,
                AlternateDefinition = alternate.AlternateDefinition
            };
        }
    }
}