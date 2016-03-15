using System.Linq;
using Parliament.Common.Extensions;
using Parliament.JargonBuster.Core.Domain;
using Parliament.JargonBuster.Core.Engine;
using Parliament.JargonBuster.WebAPI.Models;

namespace Parliament.JargonBuster.WebAPI.ViewModelBuilders
{
    public class DefinitionsResultViewModelBuilder : IDefinitionsResultViewModelBuilder
    {
        private readonly IDefinitionsEngine _engine;

        public DefinitionsResultViewModelBuilder(IDefinitionsEngine engine)
        {
            _engine = engine;
        }

        public DefinitionsResultModel Build(DefinitionsRequestModel requestModel)
        {
            return new DefinitionsResultModel
            {  
                Phrases = _engine.GetDefinitions(requestModel.PageContent, requestModel.PageUrl)
                                 .SelectToList(BuildItemModel),
                ToggleDefinitionHtml = "<div class=\"parl-toggle-html\">Test!</div>"
            };
        }

        private DefinitionsResultItemModel BuildItemModel(DefinitionItem definition)
        {
            return new DefinitionsResultItemModel
            {
                Definition = definition.Definition,
                Phrase = definition.Phrase,
                Alternates = definition.Alternates?.SelectToList(d => d.AlternateDefinition).FlattenToString(", "),
                DisplayAlternates = definition.Alternates != null && definition.Alternates.Any()
            };
        }
    }
}