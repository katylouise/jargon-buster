namespace Parliament.JargonBuster.Core.CustomModules
{
    public interface ICustomModule
    {
        string ProjectName { get; set; }
        string ModuleViewName { get; set; }
        string ModuleFriendlyName { get; set; }
    }
}