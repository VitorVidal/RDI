using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    string message = "Internal Server Error.";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                                        
                    if (contextFeature != null)
                    {   
                        if (contextFeature.Error is Application.Exceptions.BaseException ||
                        contextFeature.Error is Domain.Exceptions.BaseException)
                        {
                            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                            message = contextFeature.Error.Message;
                        }                        

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = message
                        }.ToString());
                    }
                });
            });
        }
    }
}
