using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Parliament.Common.Caching;
using Parliament.Common.Extensions;
using Parliament.Common.Interfaces;
using Parliament.JargonBuster.Core.Domain;
using Parliament.JargonBuster.Core.Services;

namespace Parliament.JargonBuster.Core.Engine
{
    public class DefinitionsEngine : CachedService, IDefinitionsEngine
    {
        private const string _cacheName = "DefinitionsEngine";
        private readonly IDefinitionsService _service;

        public DefinitionsEngine(IDefinitionsService service, IConfigurationBuilder configurationBuilder)
            : base(configurationBuilder, _cacheName)
        {
            _service = service;
        }

        public string CreateCacheKey(string pageUrl)
        {
            return string.Join(_cacheName, pageUrl);
        }

        public IList<DefinitionItem> GetDefinitions(string pageContent, string pageUrl)
        {
            var cacheKey = CreateCacheKey(pageUrl);
            var results = GetCached(cacheKey, () => GetDefinitionsUncached(pageContent));
            return results;
        }

        private IList<DefinitionItem> GetDefinitionsUncached(string pageContent)
        {
            var definitions = _service.GetDefinitions()
                                      .ToList()
                                      .OrderByDescending(x => Regex.Matches(x.Word, @"/w").Count)
                                      .ToList();

            var sbPageContent = new StringBuilder(pageContent);
    
            return definitions.WhereToList(x =>
            {
                if (!pageContent.Contains(x.Word)) return false;
                sbPageContent.Replace(x.Word, string.Empty);
                return true;
            });       
        }
    }
}