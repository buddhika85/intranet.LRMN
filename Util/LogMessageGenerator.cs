using System;

namespace Util
{
    public static class LogMessageGenerator
    {
        // Generate information based log messages
        public static string GenerateLogMessage(string username, string controller, string action, string message = "no message")
        {

            return string.Format("{0} user, executed {1} controllers 's {2} action method, log message - {3} ",
                username, controller, action, message);
        }

        // Generate exception based log messages
        public static string GenerateLogMessage(string username, string controller, string action, Exception ex)
        {
            var message = string.Format("{0} user, executed {1} controllers 's {2} action method, Exception message - {3}, Inner Exception Message - {4} ",
                username, controller, action, ex.Message, ex.InnerException == null ? "null" : ex.InnerException.Message);
            return message;
        }

    }
}
