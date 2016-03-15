﻿using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using NLog;
using Parliament.Common.Extensions;
using Parliament.JargonBuster.WebAPI.Models;
using Parliament.JargonBuster.WebAPI.ViewModelBuilders;


namespace Parliament.JargonBuster.WebAPI.Controllers
{
    //TODO - Restrict origins based on deployment configuration
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DefinitionsController : ApiController
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private readonly IDefinitionsResultViewModelBuilder _definitionsResultViewModelBuilder;

        public DefinitionsController(IDefinitionsResultViewModelBuilder definitionsResultViewModelBuilder)
        {
            _definitionsResultViewModelBuilder = definitionsResultViewModelBuilder;
        }

        [AcceptVerbs("POST")]
        [Route("api/definitions")]
        public IEnumerable<DefinitionsResultModel> Items([FromBody]DefinitionsRequestModel model)
        {
            _logger.Debug("POST - Page Content: {0}, Page Url: {1}".FormatString(model.PageContent, model.PageUrl));
            return _definitionsResultViewModelBuilder.Build(model);
        }
    }
}
