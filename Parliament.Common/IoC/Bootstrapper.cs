using StructureMap;
using StructureMap.Graph;

namespace Parliament.Common.IoC
{
    public class Bootstrapper
    {
        public static IContainer Build()
        {
            var container = new Container(x =>
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.AssembliesFromApplicationBaseDirectory(
                        y =>
                            (y.FullName.StartsWith("Parliament") || y.FullName.StartsWith("Veneer")) &&
                            !y.FullName.EndsWith("Tests"));
                    scan.WithDefaultConventions();
                    scan.LookForRegistries();
                }
             ));
            
            container.AssertConfigurationIsValid();
            return container;            
        }
    }
}