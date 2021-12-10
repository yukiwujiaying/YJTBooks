using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace YJKBooks.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                
                await _next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType="application/json";
                context.Response.StatusCode = 500;

                var response = new ProblemDetails
                {
                    Status = 500,
                    Detail =_env.IsDevelopment()? ex.StackTrace?.ToString():null,
                    Title=ex.Message
                };
                //Inheritance Object -> JsonSerializerOptions
                var options=new JsonSerializerOptions{PropertyNamingPolicy=JsonNamingPolicy.CamelCase};
                //JsonSerializerOptions():
                //Initializes a new instance of the JsonSerializerOptions class.

                //PropertyNamingPolicy:
                //Gets or sets a value that specifies the policy used to convert a property's name on an object to another format, 
                //such as camel-casing, or null to leave property names unchanged.

                var json = JsonSerializer.Serialize(response,options);
                //Converts the value of a specified type into a JSON string

                await context.Response.WriteAsync(json);
            }
        }
    }
}