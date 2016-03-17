namespace Parliament.JargonBuster.Core.CustomModules
{
    public class CustomModule : ICustomModule
    { 
        public CustomModule(string projectName, string moduleViewName, string moduleFriendlyName)
        {
            ProjectName = projectName;
            ModuleViewName = moduleViewName;
            ModuleFriendlyName = moduleFriendlyName;
        }

        public string ProjectName { get; set; }
        public string ModuleViewName { get; set; } 
        public string ModuleFriendlyName { get; set; }
    }
}