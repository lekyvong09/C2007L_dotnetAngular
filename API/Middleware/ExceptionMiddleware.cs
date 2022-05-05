using System;
using System.Text.Json;
using API.Exceptions;

namespace API.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionMiddleware> _logger;
		private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                /// logging error
                _logger.LogError(ex, ex.Message);

                /// return 500 server error
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                ErrorResponse response = _env.IsDevelopment()
                    ? new ErrorResponse(500, ex.Message + ". Stacktrace: " + ex.StackTrace.ToString())
                    : new ErrorResponse(500);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                string json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}

