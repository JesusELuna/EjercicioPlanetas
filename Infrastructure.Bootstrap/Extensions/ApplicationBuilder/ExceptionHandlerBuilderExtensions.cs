using Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Bootstrap.Extensions.ApplicationBuilder
{
    public static class ExceptionHandlerBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }

    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var exceptionHandlerPathFeature = httpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionHandlerPathFeature?.Error is DomainException argumentException)
            {
                string errorObject = JsonConvert.SerializeObject(new
                {
                    errors = new
                    {
                        message = this.CutArgumentMessage(argumentException.Message)
                    }
                });

                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsync(errorObject, Encoding.UTF8);
            }
            else
            {
                string errorObject = JsonConvert.SerializeObject(new
                {
                    error = "Ocurrio un error en la aplicacion, intente mas tarde."
                });

                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsync(errorObject, Encoding.UTF8);
            }
        }

        private string CutArgumentMessage(string mssg)
        {
            return mssg.Split(Environment.NewLine).FirstOrDefault();
        }
    }
}
