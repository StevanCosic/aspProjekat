using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjekatiApplication.exepction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProjekatImplementation.validation;
namespace api.core
{
    public class globalExHendling 
    {
        private readonly RequestDelegate _next;

        public globalExHendling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;

                switch (ex)
                {
                    case UnUseCaseExepction greska:
                        statusCode = StatusCodes.Status403Forbidden;
                        response = new
                        {
                            message = "You are not allowed"
                        };
                        break;

                    case EntityNotFound greska:
                        statusCode = StatusCodes.Status404NotFound;
                        response = new
                        {
                            message = "Not Found"
                        };
                        break;

                    case ValidationException greskaValidation:  
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        
                        response = new
                        {
                            message = "Fild to validation error",
                            error = greskaValidation.Errors.Select(x=>new
                            {
                                x.PropertyName,
                                x.ErrorMessage
                            })
                        };
                        break;







                }

                httpContext.Response.StatusCode = statusCode;

                if (response != null)
                {
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    return;
                }

                await Task.FromResult(httpContext.Response);
            }
        }



    }
}
