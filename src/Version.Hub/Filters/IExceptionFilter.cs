using Microsoft.AspNetCore.Mvc.Filters;

namespace Version.Hub.Filters
{
    internal interface IExceptionFilter : IFilterMetadata
    {
        void onException(ExceptionContext context);
    }
}
