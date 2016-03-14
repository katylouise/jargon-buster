using System.Collections.Generic;
using System.Linq;
using Parliament.JargonBuster.Core.Domain;

namespace Parliament.JargonBuster.Core.Services
{
    public interface IDefinitionsService
    {
        IList<DefinitionItem> GetDefinitions();
    }
}