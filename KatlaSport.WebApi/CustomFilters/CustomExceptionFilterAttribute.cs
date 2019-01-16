using KatlaSport.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Microsoft.Extensions.Logging;

namespace KatlaSport.WebApi.CustomFilters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private ILogger<CustomExceptionFilterAttribute> _logger;

        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is RequestedResourceNotFoundException notFound)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
                _logger.LogError(new EventId(0), notFound.Message, actionExecutedContext.Exception);

            }
            else if (actionExecutedContext.Exception is RequestedResourceHasConflictException conflict)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.Conflict);
                _logger.LogError(new EventId(0), conflict.Message, actionExecutedContext.Exception.Message);
            }
            else if (actionExecutedContext.Exception is Exception ex)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                _logger.LogError(new EventId(0), ex.Message, actionExecutedContext.Exception.Message);
            }

            base.OnException(actionExecutedContext);
        }
    }
}
