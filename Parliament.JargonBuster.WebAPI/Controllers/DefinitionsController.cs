using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using Parliament.JargonBuster.Core.Domain;
using Parliament.JargonBuster.Core.Engine;
using Parliament.JargonBuster.WebAPI.Models;

namespace Parliament.JargonBuster.WebAPI.Controllers
{
    public class DefinitionsController : ApiController
    {
        private readonly IDefinitionsEngine _engine;

        public DefinitionsController(IDefinitionsEngine engine)
        {
            _engine = engine;
        }

        [HttpPost]
        public IEnumerable<DefinitionItem> GetDefinitions([FromBody]DefinitionsModel model)
        {
            return _engine.GetDefinitions(model.PageContent, model.PageUrl);
        }
    }
}
