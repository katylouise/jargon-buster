using System;
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
                Definition = definitionViewModel.Definition,
                Alternates = definitionViewModel.Alternates.Select(BuildAlternateFromViewModel).ToList()
            };
            _definitionsService.AddDefinitionItem(definitionItemToAdd);
        }

        public void UpdateDefinitionViewModel(DefinitionViewModel definitionViewModel)
        {
            var definitionItemToUpdate = BuildDefinitionItemFromViewModel(definitionViewModel);
            _definitionsService.UpdateDefinitionItem(definitionItemToUpdate);
        }

        public void DeleteDefinitionViewModel(DefinitionViewModel definitionViewModel)
        {
            var definitionItemToDelete = BuildDefinitionItemFromViewModel(definitionViewModel);
            _definitionsService.DeleteDefinitionItem(definitionItemToDelete);
        }

        private DefinitionItem BuildDefinitionItemFromViewModel(DefinitionViewModel definitionViewModel)
        {
            return new DefinitionItem
            {
                Id = definitionViewModel.Id,
                Phrase = definitionViewModel.Phrase.Trim(),
                Definition = definitionViewModel.Definition.Trim(),
                Alternates = definitionViewModel.Alternates.Where(x => x.AlternateDefinition != null).Select(BuildAlternateFromViewModel).ToList()
            };
        }

        private AlternateDefinitionItem BuildAlternateFromViewModel(AlternateItemViewModel alternateItemViewModel)
        {
            return new AlternateDefinitionItem
            {
                Id = alternateItemViewModel.Id,
                AlternateDefinition = alternateItemViewModel.AlternateDefinition.Trim()
            };
        }
    }
}