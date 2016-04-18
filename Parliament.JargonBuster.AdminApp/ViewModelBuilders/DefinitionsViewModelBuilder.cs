using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdminApp.ViewModels;
using Parliament.JargonBuster.Core.Domain;
using Parliament.JargonBuster.Core.Services;

namespace AdminApp.ViewModelBuilders
{
    public class DefinitionsViewModelBuilder : IDefinitionsViewModelBuilder
    {
        private readonly IDefinitionsService _defintionsService;

        public DefinitionsViewModelBuilder(IDefinitionsService definitionsService)
        {
            _defintionsService = definitionsService;
        }

        public DefinitionsViewModel Build()
        {
            var definitions = _defintionsService.GetDefinitions();
            var model = new DefinitionsViewModel();
            model.Definitions = definitions.Select(BuildDefinitionViewModel).ToList();
            return model;
        }

        private DefinitionViewModel BuildDefinitionViewModel(DefinitionItem definitionItem)
        {
            return new DefinitionViewModel
            {
                Id = definitionItem.Id,
                Phrase = definitionItem.Phrase,
                Definition = definitionItem.Definition,
                Alternates = definitionItem.Alternates
            };
        }
    }
}