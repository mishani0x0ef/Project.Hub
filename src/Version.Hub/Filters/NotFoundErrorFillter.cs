using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Version.Hub.Filters
{
    public class NotFoundErrorFillter : IExceptionFilter
    {
        public void onException(ExceptionContext context)
        {
            var isNotFoundError = context.Exception is KeyNotFoundException;
            if (!isNotFoundError)
            {
                return;
            }

            context.ExceptionHandled = true;

            var response = context.HttpContext.Response;
            response.StatusCode = (int)HttpStatusCode.NotFound;
            response.WriteAsync("Resource not found");
        }
    }
}
