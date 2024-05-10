
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Susurri.Core.Exceptions;

namespace Susurri.Infrastructure.Exceptions;

internal sealed class ExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            await HandleExceptionAsync(exception, context);
        }
    }

    private async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        var (statusCode, error) = exception switch
        {
            CustomException => (StatusCodes.Status400BadRequest,
                new Error(ConvertToSnakeCase(exception.GetType().Name.Replace("Exception", "")), exception.Message)),
            _ => (StatusCodes.Status500InternalServerError, new Error("error", "There was an error."))
        };

        context.Response.StatusCode = statusCode;
        await JsonSerializer.SerializeAsync(context.Response.Body, error);
    }

    private string ConvertToSnakeCase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var result = char.ToLower(input[0]).ToString();
        for (int i = 1; i < input.Length; i++)
        {
            if (char.IsUpper(input[i]))
            {
                result += "_";
                result += char.ToLower(input[i]);
            }
            else
            {
                result += input[i];
            }
        }
        return result;
    }

    private record Error(string Code, string Reason);
}
    