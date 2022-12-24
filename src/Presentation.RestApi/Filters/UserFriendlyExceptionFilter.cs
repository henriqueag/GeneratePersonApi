using DocumentGeneratorApp.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace DocumentGeneratorApp.Presentation.RestApi.Filters;

public class UserFriendlyExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is UserFriendlyException ex && !context.ExceptionHandled)
        {
            var response = new
            {
                Code = ex.Code ?? "regra-de-negocio-violada",
                ex.Message
            };

            context.Result = new ObjectResult(response);
            context.HttpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
            context.ExceptionHandled = true;
        }
    }
}