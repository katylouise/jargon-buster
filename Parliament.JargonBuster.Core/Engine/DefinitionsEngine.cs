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
                                      .OrderByDescending(x => Regex.Matches(x.Phrase, @"\w").Count)
                                      .ToList();

            var loweredPageContent = pageContent.ToLower();
            var sbPageContent = new StringBuilder(loweredPageContent);
            
            return definitions.WhereToList(x =>
            {
                var phrase = x.Phrase.ToLower();
                if (!loweredPageContent.Contains(phrase)) return false;
                sbPageContent.Replace(phrase, string.Empty);
                return true;
            });       
        }
    }
}