using System.Collections.Generic;
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

        public List<DefinitionsResultModel> Build(DefinitionsRequestModel requestModel)
        {
            var definitions = _engine.GetDefinitions(requestModel.PageContent, requestModel.PageUrl);
            return definitions.SelectToList(BuildModel);
        }

        private DefinitionsResultModel BuildModel(DefinitionItem definition)
        {
            return new DefinitionsResultModel
            {
                Definition = definition.Definition,
                Phrase = definition.Phrase,
                Alternates = definition.Alternates?.SelectToList(d => d.AlternateDefinition).FlattenToString(", "),
                DisplayAlternates = definition.Alternates != null && definition.Alternates.Any()
            };
        }
    }
}