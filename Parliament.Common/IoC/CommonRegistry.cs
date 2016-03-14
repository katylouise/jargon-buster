using Parliament.Common.Configuration;
using Parliament.Common.ContentReader;
using Parliament.Common.Interfaces;
using Parliament.Common.Versioning;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Parliament.Common.IoC
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            For<IUriContentReaderService>().Use<UriContentReaderService>();
            For<IConfigurationBuilder>().Use<ConfigurationBuilder>();
            For<IVersionManager>().Use<VersionManager>();
        }
    }
}