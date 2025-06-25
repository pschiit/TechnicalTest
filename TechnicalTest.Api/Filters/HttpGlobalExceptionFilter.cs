﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TechnicalTest.Core.Exceptions;

namespace TechnicalTest.Api.Filters;
public sealed class HttpGlobalExceptionFilter : IExceptionFilter
{
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<HttpGlobalExceptionFilter> _logger;

    public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
    {
        _env = env;
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(new EventId(context.Exception.HResult),
            context.Exception,
            context.Exception.Message);

        if (context.Exception.GetType() == typeof(DomainException))
        {
            context.Result = new ObjectResult(context.Exception.Message);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if (context.Exception.GetType() == typeof(NotFoundException))
        {
            context.Result = new ObjectResult(context.Exception.Message);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }
        else
        {
            context.Result = new ObjectResult(context.Exception.Message);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        context.ExceptionHandled = true;
    }
}
