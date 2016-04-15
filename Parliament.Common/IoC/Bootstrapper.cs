using StructureMap;
using StructureMap.Graph;
using System.Linq;
using Parliament.Common.Interfaces;

namespace Parliament.Common.IoC
{
    public class Bootstrapper
    {
        public static IContainer Build()
        {
            var container = new Container(x =>
            {
                x.Scan(
               assembly =>
               {
                   assembly.TheCallingAssembly();
                   assembly.LookForRegistries();
                   assembly.WithDefaultConventions();
                   assembly.AssembliesFromApplicationBaseDirectory(y => y.FullName.StartsWith("Parliament."));
               });
            });

            var xx = container.WhatDoIHave();

            container.AssertConfigurationIsValid();
            return container;
        }
    }
}