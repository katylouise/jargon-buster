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
            var definitionItemToAdd = BuildDefinitionItemFromViewModel(definitionViewModel);
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
            var definitionItem = new DefinitionItem
            {
                Phrase = definitionViewModel.Phrase.Trim(),
                Definition = definitionViewModel.Definition.Trim(),
                Alternates = BuildAlternateItemsList(definitionViewModel)
            };
            if(definitionViewModel.Id != 0)
            {
                definitionItem.Id = definitionViewModel.Id;
            }
            return definitionItem;
        }

        private List<AlternateDefinitionItem> BuildAlternateItemsList(DefinitionViewModel definitionViewModel)
        {
            var alternatesForNewDefinition = new List<AlternateDefinitionItem>();
            var ViewModelAlternates = definitionViewModel.Alternates.Where(x => x.AlternateDefinition != null);
            if (ViewModelAlternates.Count() > 0)
            {
                alternatesForNewDefinition = ViewModelAlternates.Select(BuildAlternateFromViewModel).ToList();
            }
            return alternatesForNewDefinition;
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