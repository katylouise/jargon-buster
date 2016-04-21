using System.Collections.Generic;
using Parliament.JargonBuster.Core.Domain;

namespace Parliament.JargonBuster.Core.Services
{
    public interface IDefinitionsService
    {
        IList<DefinitionItem> GetDefinitions();

        DefinitionItem GetDefinitionById(int id);

        DefinitionItem GetDefinitionByPhrase(string phrase);

        void UpdateDefinitionItem(DefinitionItem definitionItem);
        void AddDefinitionItem(DefinitionItem definitionItem);
        void DeleteDefinitionItem(DefinitionItem definitionItem);
    }
}