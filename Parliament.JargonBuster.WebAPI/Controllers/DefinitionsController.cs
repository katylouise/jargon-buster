using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Parliament.Common.IoC;
using Parliament.JargonBuster.Core.Domain;
using Parliament.JargonBuster.Core.Engine;
using Parliament.JargonBuster.WebAPI.Models;

namespace Parliament.JargonBuster.WebAPI.Controllers
{
    //TODO - Restrict origins based on deployment configuration
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DefinitionsController : ApiController
    {
        private readonly IDefinitionsEngine _engine;

        public DefinitionsController(IDefinitionsEngine engine)
        {
            _engine = engine;
        }

        [AcceptVerbs("GET", "POST")]
        [Route("api/definitions")]
        public IEnumerable<DefinitionItem> Items([FromBody]DefinitionsModel model)
        {
            return _engine.GetDefinitions(model.PageContent, model.PageUrl);
        }
    }
}
