using System.Collections.Generic;
using Parliament.JargonBuster.Core.Domain;

namespace Parliament.JargonBuster.Core.Engine
{
    public interface IDefinitionsEngine
    {
        IList<DefinitionItem> GetDefinitions(string pageContent, string pageUrl);
    }
}