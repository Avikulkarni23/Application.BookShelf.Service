using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.BookShelf.Aplication.Filters
{
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger<LogActionFilter> _logger;

        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // This method runs before the action method
            _logger.LogInformation($"Action '{context.ActionDescriptor.DisplayName}' is starting.");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // This method runs after the action method
            _logger.LogInformation($"Action '{context.ActionDescriptor.DisplayName}' has completed.");
        }

    }
}
