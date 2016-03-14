using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Parliament.Common.IoC;
using Parliament.JargonBuster.Core.Domain;
using Parliament.JargonBuster.WebAPI.Models;
using Parliament.JargonBuster.WebAPI.ViewModelBuilders;

namespace Parliament.JargonBuster.WebAPI.Controllers
{
    //TODO - Restrict origins based on deployment configuration
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DefinitionsController : ApiController
    {
        private readonly IDefinitionsResultViewModelBuilder _definitionsResultViewModelBuilder;

        public DefinitionsController(IDefinitionsResultViewModelBuilder definitionsResultViewModelBuilder)
        {
            _definitionsResultViewModelBuilder = definitionsResultViewModelBuilder;
        }

        [AcceptVerbs("GET", "POST")]
        [Route("api/definitions")]
        public IEnumerable<DefinitionsResultModel> Items([FromBody]DefinitionsRequestModel model)
        {
            return _definitionsResultViewModelBuilder.Build(model);
        }
    }
}
