using log4net;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using Util;

namespace MvcClient.Logger
{
    internal class MvcLogger
    {
        ILog _log;

        internal MvcLogger()
        {
            _log = log4net.LogManager.GetLogger(typeof(MvcLogger));
        }

        // log exceptions in action methods
        internal void LogException(Exception ex, ControllerContext controllerContext, string username)
        {
            _log.Error("Error message - " + LogMessageGenerator.GenerateLogMessage(
                                        username,
                                        controllerContext.RouteData.Values["controller"].ToString(),
                                        controllerContext.RouteData.Values["action"].ToString(),
                                        ex));
        }

        // log anonymouse executions of the action methods
        internal void OnActionExecutedLoggerAnonymouse(ActionExecutedContext filterContext)
        {
            _log.Info("Info message - " + LogMessageGenerator.GenerateLogMessage(
                            "Anonymouse",
                            filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                            filterContext.ActionDescriptor.ActionName,
                            "After Execution"));
        }

        // log user executions of the action methods
        internal void OnActionExecutedLogger(ActionExecutedContext filterContext)
        {
            _log.Info("Info message - " + LogMessageGenerator.GenerateLogMessage(
                            filterContext.HttpContext.User.Identity.GetUserName(),
                            filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                            filterContext.ActionDescriptor.ActionName,
                            "After Execution"));
        }

        internal void OnActionExecutingLogger(ActionExecutingContext filterContext)
        {
            _log.Info("Info message - " + LogMessageGenerator.GenerateLogMessage(
                            filterContext.HttpContext.User.Identity.GetUserName(),
                            filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                            filterContext.ActionDescriptor.ActionName,
                            "On Executing"));
        }

        internal void OnActionExecutingLoggerAnonymouse(ActionExecutingContext filterContext)
        {
            _log.Info("Info message - " + LogMessageGenerator.GenerateLogMessage(
                            "Anonymouse",
                            filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                            filterContext.ActionDescriptor.ActionName,
                            "On Executing"));

            //_log.Debug("Debug message");
            //_log.Warn("Warn message");
            //_log.Error("Error message"));
            //_log.Fatal("Fatal message"));
        }
    }
}