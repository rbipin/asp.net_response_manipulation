using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Serialize_in_action_filter.Middleware
{
    public class SimpleMiddleware
    {
        private readonly RequestDelegate next;
        public SimpleMiddleware(RequestDelegate _next)
        {
            next = _next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
                var statusCode = context.Response.StatusCode;
                // Just for demo always set to 200
                statusCode = 200;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

    public static class SimpleMiddlewareExtension
    {
        public static IApplicationBuilder UseSimpleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleMiddleware>();
        }
    }
}
