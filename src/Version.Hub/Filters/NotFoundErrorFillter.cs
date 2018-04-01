using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Version.Hub.Filters
{
    public class NotFoundErrorFillter : IExceptionFilter
    {
        private readonly ILogger<NotFoundErrorFillter> _logger;

        public NotFoundErrorFillter(ILogger<NotFoundErrorFillter> logger)
        {
            _logger = logger;
        }

        public void onException(ExceptionContext context)
        {
            var isNotFoundError = context.Exception is KeyNotFoundException;
            if (!isNotFoundError)
            {
                return;
            }

            context.ExceptionHandled = true;

            _logger.LogError(context.Exception, string.Empty);

            var response = context.HttpContext.Response;
            response.StatusCode = (int)HttpStatusCode.NotFound;
            response.WriteAsync("Resource not found");
        }
    }
}
