using LoginBackend.Api.Models;
using LoginBackend.Domain.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace LoginBackend.Api.Configuration.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex is CustomException ? (int)HttpStatusCode.BadRequest : (int)HttpStatusCode.InternalServerError;

            var response = new CustomResponse(false, ex is CustomException ? ex.Message : "Internal server error, try again later!");
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
