
using System;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace APIGenerator.Filters
{
    /// <summary>
    /// Custom Filter to handle all general exception events managed into the MVC Pipeline
    /// </summary>
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _Env;
        private readonly ILogger<HttpGlobalExceptionFilter> _Logger;

        /// <summary>
        /// Constructor with DI
        /// </summary>
        /// <param name="Env"></param>
        /// <param name="Logger"></param>
        public HttpGlobalExceptionFilter(IHostingEnvironment Env, ILogger<HttpGlobalExceptionFilter> Logger)
        {
            _Env = Env;
            _Logger = Logger;
        }

        /// <summary>
        /// Handle OnException Message
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();

            _Logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            // if (context.Exception.GetType() == typeof(OrderingDomainException)) 
            // {
            //     var json = new JsonErrorResponse
            //     {
            //         Messages = new[] { context.Exception.Message }
            //     };

            //     // Result asigned to a result object but in destiny the response is empty. This is a known bug of .net core 1.1
            //     //It will be fixed in .net core 1.1.2. See https://github.com/aspnet/Mvc/issues/5594 for more information
            //     context.Result = new BadRequestObjectResult(json);
            //     context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            // }
            // else
            // {
            //     var json = new JsonErrorResponse
            //     {
            //         Messages = new[] { "An error occur.Try it again." }
            //     };

            //     if (_Env.IsDevelopment())
            //     {
            //         json.DeveloperMessage = context.Exception;
            //     }

            //     // Result asigned to a result object but in destiny the response is empty. This is a known bug of .net core 1.1
            //     // It will be fixed in .net core 1.1.2. See https://github.com/aspnet/Mvc/issues/5594 for more information
            //     context.Result = new InternalServerErrorObjectResult(json);
            //     context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            // }
            context.ExceptionHandled = true;
        }
    }

    /// <summary>
    /// Developmental Exception Error Response Message
    /// </summary>
    public class JsonErrorResponse
    {
        public string[] Messages { get; set; }

        public object DeveloperMessage { get; set; }
    }
}