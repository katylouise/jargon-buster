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
        public void AddDefinitionItem(DefinitionViewModel definitionViewModel)
        {
            var definitionItemToAdd = BuildDefinitionItemFromViewModel(definitionViewModel);
            definitionItemToAdd.CreatedAt = DateTime.Now;
            _definitionsService.AddDefinitionItem(definitionItemToAdd);
        }

        public void UpdateDefinitionItem(DefinitionViewModel definitionViewModel)
        {
            var definitionItemToUpdate = BuildDefinitionItemFromViewModel(definitionViewModel);
            _definitionsService.UpdateDefinitionItem(definitionItemToUpdate);
        }

        public void DeleteDefinitionItem(DefinitionViewModel definitionViewModel)
        {
            var definitionItemToDelete = BuildDefinitionItemFromViewModel(definitionViewModel);
            _definitionsService.DeleteDefinitionItem(definitionItemToDelete);
        }

        public bool ValidateDefinition(string phrase)
        {
            var isValid = true;
            var definitions = _definitionsService.GetDefinitions();
            var alternates = _definitionsService.GetAlternates();
            if (definitions.Any(x => x.Phrase.ToLower() == phrase.Trim().ToLower()))
            {
                isValid = false;
            }

            if (alternates.Any(x => x.AlternateDefinition != null && x.AlternateDefinition.ToLower() == phrase.Trim().ToLower()))
            {
                isValid = false;
            }
            return isValid;
        }
        private DefinitionItem BuildDefinitionItemFromViewModel(DefinitionViewModel definitionViewModel)
        {
            HouseType houseType = (HouseType)Enum.Parse(typeof(HouseType), definitionViewModel.House);
            var definitionItem = new DefinitionItem
            {
                Phrase = definitionViewModel.Phrase.Trim(),
                Definition = definitionViewModel.Definition.Trim(),
                Alternates = BuildAlternateItemsList(definitionViewModel),
                UpdatedAt = DateTime.Now,
                HouseType = houseType
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
            if (definitionViewModel.Alternates != null && definitionViewModel.Alternates.Count() > 0)
            {
                var ViewModelAlternates = definitionViewModel.Alternates;
                alternatesForNewDefinition = ViewModelAlternates.Select(BuildAlternateFromViewModel).ToList();
            }
            return alternatesForNewDefinition;
        }

        private AlternateDefinitionItem BuildAlternateFromViewModel(AlternateItemViewModel alternateItemViewModel)
        {
            return new AlternateDefinitionItem()
            {
                Id = alternateItemViewModel.Id,
                AlternateDefinition = alternateItemViewModel.AlternateDefinition
            };
        }
    }
}