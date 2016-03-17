using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Parliament.Common.Caching;
using Parliament.Common.Extensions;
using Parliament.Common.Interfaces;
using Parliament.JargonBuster.Core.CustomModules;
using Parliament.JargonBuster.Core.Domain;
using Parliament.JargonBuster.Core.Engine;
using Parliament.JargonBuster.WebAPI.Controllers;
using Parliament.JargonBuster.WebAPI.Models;

namespace Parliament.JargonBuster.WebAPI.ViewModelBuilders
{
    public class DefinitionsResultViewModelBuilder : CachedService, IDefinitionsResultViewModelBuilder
    {
        private readonly IDefinitionsEngine _engine;
        private readonly ICustomModulesFactory _customModulesFactory;

        public DefinitionsResultViewModelBuilder(IDefinitionsEngine engine, IConfigurationBuilder configurationBuilder, ICustomModulesFactory customModulesFactory)
            : base(configurationBuilder, "DefinitionsResult")
        {
            _engine = engine;
            _customModulesFactory = customModulesFactory;
        }

        public DefinitionsResultModel Build(DefinitionsRequestModel requestModel)
        {
            return new DefinitionsResultModel
            {
                Phrases = _engine.GetDefinitions(requestModel.PageContent, requestModel.PageUrl)
                                 .SelectToList(BuildDefinitionsModel),
                CustomModules = _customModulesFactory.GetCustomModules(requestModel.ProjectName)
                                                     .SelectToList(BuildCustomModules)
            };
        }

        private CustomModuleItemModel BuildCustomModules(ICustomModule customModule)
        {
            return new CustomModuleItemModel
            {
                ModuleName = customModule.ModuleFriendlyName,
                ModuleHtml = GetCached(BuildCacheKeyForCustomModule(customModule), () => RenderPartialViewToString("CustomModules", customModule.ModuleViewName))
            };
        }

        private string BuildCacheKeyForCustomModule(ICustomModule customModule)
        {
            return "CustomModule_{0}_{1}".FormatString(customModule.ProjectName, customModule.ModuleFriendlyName);
        }

        private DefinitionsResultItemModel BuildDefinitionsModel(DefinitionItem definition)
        {
            return new DefinitionsResultItemModel
            {
                Definition = definition.Definition,
                Phrase = definition.Phrase,
                AlternatesContent = definition.Alternates?.SelectToList(d => d.AlternateDefinition).FlattenToString(", "),
                Alternates = definition.Alternates.SelectToList(x => x.AlternateDefinition),
                DisplayAlternates = definition.Alternates != null && definition.Alternates.Any()
            };
        }

        public string RenderPartialViewToString(string controllerName, string viewName)
        {
            HttpContextBase contextBase = new HttpContextWrapper(HttpContext.Current);

            var routeData = new RouteData();
            routeData.Values.Add("controller", controllerName);
            var controllerContext = new ControllerContext(contextBase, routeData, new CustomModulesController());

            using (var sw = new StringWriter())
            {
                var razorViewEngine = new RazorViewEngine();
                var razorViewResult = razorViewEngine.FindView(controllerContext, viewName, "", false);

                var viewContext = new ViewContext(controllerContext, razorViewResult.View, new ViewDataDictionary(), new TempDataDictionary(), sw);
                razorViewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString().Trim();
            }
        }
    }
}