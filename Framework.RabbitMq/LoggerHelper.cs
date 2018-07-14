using System;
using System.Linq;
using log4net;

namespace Framework.RabbitMq
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public static class LoggerHelper
    {
        private static ILog _log;

        /// <summary>
        /// 文本日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void WriteToFile(Type type, string message, Exception ex)
        {
            _log = LogManager.GetLogger(type);

            _log.Error(message, ex);
        }
    }
}