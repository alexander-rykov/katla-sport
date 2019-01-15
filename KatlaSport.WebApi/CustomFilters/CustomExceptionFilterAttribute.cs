using KatlaSport.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace KatlaSport.WebApi.CustomFilters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // TODO Add logging here.
            if (actionExecutedContext.Exception is RequestedResourceNotFoundException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            else if (actionExecutedContext.Exception is RequestedResourceHasConflictException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.Conflict);
            }
            else if (actionExecutedContext.Exception is Exception)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
