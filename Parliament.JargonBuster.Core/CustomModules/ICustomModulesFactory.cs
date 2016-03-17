using System.Collections.Generic;

namespace Parliament.JargonBuster.Core.CustomModules
{
    public interface ICustomModulesFactory
    {
        IList<ICustomModule> GetCustomModules(string projectName);
    }
}