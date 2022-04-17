using System.Net;
using APPoint.App.Exceptions;
using Microsoft.AspNetCore.Http;


namespace APPoint.App.Middlewares
{
    internal class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(BusinessException e)
            {
                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;

                if (!string.IsNullOrEmpty(e.ErrorCode))
                {
                    await context.Response.WriteAsync(e.ErrorCode);
                }
            }
        }
    }
}
