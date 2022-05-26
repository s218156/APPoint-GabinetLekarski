using APPoint.App.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace APPoint.App.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> logger)
        {
            try
            {
                await _next(context);
            }
            catch(AuthorizationException)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            catch(BusinessException e)
            {
                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;

                if (!string.IsNullOrEmpty(e.ErrorCode))
                {
                    await context.Response.WriteAsJsonAsync(new { ErrorCode = e.ErrorCode });
                }
            }
            catch(Exception e)
            {
                logger.LogError(e, "An unexpected error occured");

                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
            }
        }
    }
}
