using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using musicstore.Services;

namespace musicstore.Middleware
{
    public class RequestIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestIdMiddleware> _logger;

        public RequestIdMiddleware(RequestDelegate next,
            IRequestId requestID,
            ILogger<RequestIdMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public Task Invoke(HttpContext context, IRequestId requestID)
        {
            _logger.LogInformation($"Request {requestID.Id} executing.");

            return _next(context);
        }
    }
}