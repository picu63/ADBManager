using JCore.IJLog;
using JCore.JLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAdbLibrary
{
    public class HelperService
    {
        private static ILogsService logsService = new LogsService();

        /// <summary>
        /// Zapisywanie logu do pliku oraz wyświetlenie jego w konsoli
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public static ILog SaveLogToFile(ILog log)
        {
            return logsService.SaveLogToFile(log);
        }

        /// <summary>
        /// Zapisywanie exception do pliku oraz wyświetlenie jego w konsoli
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static ILog SaveExceptionToFile(Exception ex, string description = null)
        {
            return SaveLogToFile(new Log()
            {
                Description = string.IsNullOrEmpty(description) ? ex.GetaAllMessages() : description,
                Details = string.IsNullOrEmpty(description) ? ex.GetaAllStackTrace() : $"{ex.GetaAllMessages()}{Environment.NewLine}{ex.GetaAllStackTrace()}",
                LogType = LogType.EXCEPTION
            });
        }
    }
}
