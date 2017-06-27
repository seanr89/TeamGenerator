

using APIGenerator.Utilities;
//using DomainObjects;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace APIGenerator.Filters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger<LogFilterAttribute> _Logger;

        public LogFilterAttribute(ILogger<LogFilterAttribute> Logger)
        {
            _Logger = Logger;
        }

        public override void OnActionExecuted(ActionExecutedContext context) 
        {
            if (!context.Canceled) 
            {
                _Logger.LogInformation(0, $"Executed action {UtilityMethods.GetCallerMemberName()}");
                base.OnActionExecuted(context);
            }
        }
    }
}