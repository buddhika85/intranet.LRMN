using MvcClient.Logger;
using System.Web.Mvc;

namespace MvcClient.Filters
{
    // Filter that is used to log user
    public sealed class LogAttribute : ActionFilterAttribute
    {
        MvcLogger _mvcLogger;

        public LogAttribute()
        {
            _mvcLogger = new MvcLogger();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                _mvcLogger.OnActionExecutedLogger(filterContext);
            }
            else
            {
                _mvcLogger.OnActionExecutedLoggerAnonymouse(filterContext);
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                _mvcLogger.OnActionExecutingLogger(filterContext);
            }
            else
            {
                _mvcLogger.OnActionExecutingLoggerAnonymouse(filterContext);
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }
}