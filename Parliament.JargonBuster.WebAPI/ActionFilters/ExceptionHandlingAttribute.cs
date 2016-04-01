using System.Web.Http.Filters;
using NLog;

namespace Parliament.JargonBuster.WebAPI.ActionFilters
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            _logger.Error(actionExecutedContext.Exception);
            base.OnException(actionExecutedContext);
        }
    }
}