using Parliament.JargonBuster.Core.CustomModules;
using StructureMap;

namespace Parliament.JargonBuster.Core.IoC
{
    public class CustomModulesIoC : Registry
    {
        public CustomModulesIoC()
        {
            For<ICustomModule>().Add(new CustomModule("parliament-uk-old", "_RightModuleParlUKHelp", "definitions-right-module"));
            For<ICustomModule>().Add(new CustomModule("parliament-uk-old", "_ToggleDefinitions", "definitions-toggle"));
        }
    }
}