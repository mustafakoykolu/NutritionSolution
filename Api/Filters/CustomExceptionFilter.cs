using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Api.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public CustomExceptionFilter()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(BadRequestException), HandleBadRequestException },
                { typeof(NotFoundException), HandleNotFoundException },
                // Yeni istisnalar buraya eklenebilir
            };
        }

        public void OnException(ExceptionContext context)
        {
            Type exceptionType = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(exceptionType))
            {
                _exceptionHandlers[exceptionType].Invoke(context);
            }
            else
            {
                HandleUnknownException(context);
            }
        }

        private void HandleBadRequestException(ExceptionContext context)
        {
            var badRequestException = (BadRequestException)context.Exception;
            badRequestException.Data["StackTrace"] = null;
            context.Result = new BadRequestObjectResult(new
            {
                message = badRequestException.ValidationErrors?.ToString() ??  badRequestException.Message ,
            })
            {
                StatusCode = 400
            };
            context.ExceptionHandled = true;
        }
        private void HandleNotFoundException(ExceptionContext context)
        {
            var notFoundException = (NotFoundException)context.Exception;
            notFoundException.Data["StackTrace"] = null;
            context.Result = new NotFoundObjectResult(new
            {
                message = notFoundException.Message,
            })
            {
                StatusCode = 404
            };
            context.ExceptionHandled = true;
        }
        private void HandleUnknownException(ExceptionContext context)
        {
            context.Result = new JsonResult(new
            {
                message = context.Exception.Message,
                stackTrace = context.Exception.StackTrace,
            })
            {
                StatusCode = 500
            };
        }
    }
}