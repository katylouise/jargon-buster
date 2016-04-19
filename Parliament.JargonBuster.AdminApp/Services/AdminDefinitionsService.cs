﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdminApp.ViewModels;
using Parliament.JargonBuster.Core.Domain;
using Parliament.JargonBuster.Core.Services;

namespace AdminApp.Services
{
    public class AdminDefinitionsService : IAdminDefinitionsService
    {
        private readonly IDefinitionsService _definitionsService;
        public AdminDefinitionsService(IDefinitionsService DefinitionsService)
        {
            _definitionsService = DefinitionsService;
        }
        public void AddDefinitionViewModel(DefinitionViewModel definitionViewModel)
        {
            var definitionItemToAdd = new DefinitionItem
            {
                Phrase = definitionViewModel.Phrase,
                Definition = definitionViewModel.Definition
            };
            _definitionsService.AddDefinition(definitionItemToAdd);
        }

        public void UpdateDefinitionViewModel(DefinitionViewModel definitionViewModel)
        {
            var definition = new DefinitionItem
            {
                Id = definitionViewModel.Id,
                Phrase = definitionViewModel.Phrase,
                Definition = definitionViewModel.Definition

                //TODO - alternates
            };
            _definitionsService.UpdateDefinitionItem(definition);
        }
    }
}