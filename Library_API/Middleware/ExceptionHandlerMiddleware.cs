using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Net;
using Amazon.CodePipeline.Model;
using ValidationException = FluentValidation.ValidationException;
using System.Text.Json;
using System.Reflection;

namespace Library_API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        public ExceptionHandlerMiddleware(RequestDelegate next) => this.next = next;

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExseptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExseptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            int statusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal server error";

            if (exception is DbUpdateException)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
                message = "Invalid database operation";
            }
            else if (exception is KeyNotFoundException)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
                message = exception.Message;
            }
            else if (exception is SecurityTokenSignatureKeyNotFoundException)
            {
                statusCode = (int)HttpStatusCode.Unauthorized;
                message = "Invalid authorization token";
            }
            else if (exception is ObjectDisposedException)
            {
                statusCode = (int)HttpStatusCode.NotImplemented;
                message = "OBJECT DISPOSED EXCEPTION";
            }
            else if (exception is ValidationException)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
                message = "Validation error";
            }
            else if (exception is AmbiguousMatchException)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
                message = "Ambiguous request: The request matched multiple endpoints";
            }

            httpContext.Response.StatusCode = statusCode;

            var errorDetails = new ErrorDetails { Message = message };
            var json = JsonSerializer.Serialize(errorDetails);
            await httpContext.Response.WriteAsync(json);
        }

    }
}
