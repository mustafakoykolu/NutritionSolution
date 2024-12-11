using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Api.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BadRequestException badRequestException)
            {
                badRequestException.Data["StackTrace"] = null;
                context.Result = new BadRequestObjectResult(new
                {
                    ExceptionErrorMessage = badRequestException.Message,
                    ValidationErrorMessage = badRequestException.ValidationErrors
                })
                {
                    StatusCode = 400
                };
                context.ExceptionHandled = true;
            }
            else
            {
                context.Result = new JsonResult(new
                {
                    error = "Internal Server Error",
                    details = context.Exception.Message
                })
                {
                    StatusCode = 500
                };
            }
        }
    }
}
