using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxAPI.Loggers
{
    /// <summary>
    /// Logger that logs all of it's messages into a file.
    /// </summary>
    public class FileLogger : LoggerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">Absolute or relative path to the log file.</param>
        /// <param name="rollingInterval">Interval, after which the logs will be rotated.</param>
        /// <param name="innerLogger">Inner logger that will possibly log to some other place.</param>
        public FileLogger(string filePath, RollingInterval rollingInterval, LoggerBase innerLogger = null) : base(innerLogger)
        {
            _logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(filePath, rollingInterval:rollingInterval)
            .CreateLogger();
        }
    }
}
