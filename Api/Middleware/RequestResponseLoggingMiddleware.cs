using Serilog;
using System.Text;

namespace Api.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalResponseBody = context.Response.Body;

            var actionName = context.GetRouteData()?.Values["action"]?.ToString();
            var controllerName = context.GetRouteData()?.Values["controller"]?.ToString();

            try
            {
                using var responseBody = new MemoryStream();
                context.Response.Body = responseBody;

                await _next(context);

                var responseBodyText = await ReadResponseBody(context.Response);

                Log.Information("HTTP Response: {Method} {Path} | Controller: {Controller} | Action: {Action} | Response Body: {ResponseBody} | Status Code: {StatusCode}",
                    context.Request.Method,
                    context.Request.Path,
                    controllerName,
                    actionName,
                    responseBodyText,
                    context.Response.StatusCode);

                await responseBody.CopyToAsync(originalResponseBody);
            }
            finally
            {
                context.Response.Body = originalResponseBody;
            }
        }

        private async Task<string> ReadResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyAsText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return bodyAsText;
        }
    }
}