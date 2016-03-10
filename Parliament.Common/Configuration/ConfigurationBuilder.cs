using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Web.Configuration;
using Parliament.Common.Extensions;
using Parliament.Common.Interfaces;
using Parliament.Common.Serialization;

namespace Parliament.Common.Configuration
{
    [ExcludeFromCodeCoverage]
    public class ConfigurationBuilder : IConfigurationBuilder
    {
        public virtual T GetConfiguration<T>(string prefix = null) where T : class, new()
        {
            return BuildBaseConfiguration<T>(GetValueFromConfiguration, prefix);
        }

        public virtual T GetConfigurationUsingEnvironmentVariables<T>() where T : class, new()
        {
            return BuildBaseConfiguration<T>(GetValueFromEnvironmentVariable);
        }
        public virtual void SetConfiguration<T>(T item) where T : class, new()
        {
            Type configType = typeof(T);
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
            configType.GetProperties()
                      .ForEach(x => SetValueToConfiguration(config, item, x));
            config.Save(ConfigurationSaveMode.Minimal, false);
            ConfigurationManager.RefreshSection("appSettings");
        }


        public virtual void SetConfigurationUsingEnvironmentVariables<T>(T item) where T : class, new()
        {
            Type configType = typeof(T);
            configType.GetProperties()
                      .ForEach(x => SetValueFromEnvironmentVariable(item, x));
        }

        public virtual T GetConfigurationFromFile<T>(string fileLocation) where T : class, new()
        {
            if (!File.Exists(fileLocation)) return null;
            return XmlUtility.DeserializeXml<T>(File.ReadAllText(fileLocation));
        }

        public virtual void SetConfigurationToFile<T>(T settings, string fileLocation) where T : class, new()
        {
            var directory = Path.GetDirectoryName(fileLocation);
            if (directory != null && !Directory.Exists(directory)) Directory.CreateDirectory(directory);
            File.WriteAllText(fileLocation, XmlUtility.SerializeDataObject(settings));
        }


        protected string GetValueFromProperty<T>(T item, PropertyInfo propertyInfo)
        {
            object value = propertyInfo.GetValue(item);
            return (value != null ? value.ToString() : null);
        }

        protected T BuildBaseConfiguration<T>(Action<T, PropertyInfo, string> getValueAction, string prefix = null) where T : class, new()
        {
            T config = new T();

            var configType = typeof(T);
            configType.GetProperties()
                      .ForEach(x => getValueAction(config, x, prefix));

            return config;
        }

        protected void GetValueFromConfiguration<T>(T item, PropertyInfo propertyInfo, string prefix = null)
        {
            var value = TypeDescriptor.GetConverter(propertyInfo.PropertyType)
                                      .ConvertFromString(ConfigurationManager.AppSettings[prefix + propertyInfo.Name]);
            propertyInfo.SetValue(item, value, null);
        }


        protected void GetValueFromEnvironmentVariable<T>(T item, PropertyInfo propertyInfo, string prefix = null)
        {
            var value = TypeDescriptor.GetConverter(propertyInfo.PropertyType)
                                      .ConvertFromString(Environment.GetEnvironmentVariable(prefix + propertyInfo.Name));
            propertyInfo.SetValue(item, value, null);
        }

        protected void SetValueToConfiguration<T>(System.Configuration.Configuration config, T item, PropertyInfo propertyInfo)
        {
            config.AppSettings.Settings[propertyInfo.Name].Value = GetValueFromProperty(item, propertyInfo);
        }

        protected void SetValueFromEnvironmentVariable<T>(T item, PropertyInfo propertyInfo)
        {
            Environment.SetEnvironmentVariable(propertyInfo.Name, GetValueFromProperty(item, propertyInfo));
        }
    }
}