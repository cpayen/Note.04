using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Note.Core.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Note.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        protected readonly RequestDelegate _next;

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
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);

                // Throw the exception for other middlewares (Logging)
                throw;
            }
        }

        private async static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // 500 if unexpected
            var code = HttpStatusCode.InternalServerError;
            var title = "Server error";

            // 404 not found
            if (exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
                title = "Not found";
            }
            
            var result = JsonConvert.SerializeObject(new { title, status = (int)code, error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsync(result);
        }
    }
}
