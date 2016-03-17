using System;
using System.Collections.Generic;
using System.Linq;
using Parliament.Common.Extensions;

namespace Parliament.JargonBuster.Core.CustomModules
{
    public class CustomModulesFactory : ICustomModulesFactory
    {
        private readonly IList<ICustomModule> _customModules;

        public CustomModulesFactory(IList<ICustomModule> customModules)
        {
            _customModules = customModules;
        }

        public IList<ICustomModule> GetCustomModules(string projectName)
        {
            return _customModules.WhereToList(x => string.Equals(x.ProjectName, projectName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}