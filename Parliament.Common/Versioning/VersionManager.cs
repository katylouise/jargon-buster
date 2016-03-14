using System.Diagnostics;
using System.Reflection;

namespace Parliament.Common.Versioning
{
    public class VersionManager : IVersionManager
    {
        public string GetApplicationVersion()
        {
            var assembly = Assembly.GetCallingAssembly();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersionInfo.FileVersion; 
        }
    }
}