namespace Parliament.Common.Interfaces
{
    public interface IConfigurationBuilder
    {
        T GetConfiguration<T>(string prefix = null) where T : class, new();
        void SetConfiguration<T>(T settings) where T : class, new();
        T GetConfigurationUsingEnvironmentVariables<T>() where T : class, new();
        void SetConfigurationUsingEnvironmentVariables<T>(T settings) where T : class, new();
        T GetConfigurationFromFile<T>(string fileLocation) where T : class, new();
        void SetConfigurationToFile<T>(T settings, string fileLocation) where T : class, new();
    }
}