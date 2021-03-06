﻿using System.Linq;
using AdminApp.ViewModels;
using Parliament.JargonBuster.Core.Domain;
using Parliament.JargonBuster.Core.Services;
using System;

namespace AdminApp.ViewModelBuilders
{
    public class DefinitionsViewModelBuilder : IDefinitionsViewModelBuilder
    {
        private readonly IDefinitionsService _defintionsService;
        private readonly IAlternateItemsViewModelBuilder _alternateItemsViewModelBuilder;

        public DefinitionsViewModelBuilder(IDefinitionsService definitionsService, IAlternateItemsViewModelBuilder alternateItemsViewModelBuilder)
        {
            _defintionsService = definitionsService;
            _alternateItemsViewModelBuilder = alternateItemsViewModelBuilder;
        }

        public DefinitionsViewModel Build()
        {
            var definitions = _defintionsService.GetDefinitions();
            var model = new DefinitionsViewModel();
            model.Definitions = definitions.Select(BuildDefinitionViewModel).OrderBy(x => x.Phrase).ToList();
            return model;
        }

        public DefinitionViewModel BuildDefinitionViewModelFromId(int id)
        {
            var definitionItem = _defintionsService.GetDefinitionById(id);
            return BuildDefinitionViewModel(definitionItem);
        }

        private DefinitionViewModel BuildDefinitionViewModel(DefinitionItem definitionItem)
        {
            return new DefinitionViewModel
            {
                Id = definitionItem.Id,
                Phrase = Capitalize(definitionItem.Phrase),
                Definition = definitionItem.Definition,
                Alternates = _alternateItemsViewModelBuilder.Build(definitionItem),
                UpdatedAt = definitionItem.UpdatedAt,
                UpdatedBy = definitionItem.UpdatedBy,
                CreatedAt = definitionItem.CreatedAt,
                CreatedBy = definitionItem.CreatedBy,
                House = definitionItem.HouseType.ToString()
            };
        }

        private String Capitalize(String word)
        {
            return word[0].ToString().ToUpper() + word.Substring(1, word.Length - 1);
        }
    }
}