using Serilog.Core;

namespace DevoxAPI.Loggers
{
    /// <summary>
    /// Base class for all of the other loggers, designed to implement the "Composite" design pattern.
    /// </summary>
    public abstract class LoggerBase
    {
        protected Logger _logger;                           //Serilog Logger
        protected LoggerBase _innerLogger;                  //Inner Logger that will possibly log to some other place. 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="innerLogger">Inner logger that will possibly log to some other place.</param>
        public LoggerBase(LoggerBase innerLogger = null)
        {
            _innerLogger = innerLogger;
        }
        /// <summary>
        /// Logs a message according to it`s template.
        /// </summary>
        /// <param name="template">Serilog message template</param>
        /// <param name="logLevel">Message severity</param>
        /// <param name="logObjects">Objects to be formatted according to the "template" parameter</param>
        public void Log(string template, LogLevel logLevel, params object[] logObjects)
        {
            _innerLogger?.Log(template,logLevel, logObjects);
            switch (logLevel)
            {
                case LogLevel.Info:
                    _logger.Information(template, logObjects);
                    break;
                case LogLevel.Debug:
                    _logger.Debug(template, logObjects);
                    break;
                case LogLevel.Warning:
                    _logger.Warning(template, logObjects);
                    break;
                case LogLevel.Error:
                    _logger.Error(template, logObjects);
                    break;
                case LogLevel.Fatal:
                    _logger.Fatal(template, logObjects);
                    break;
            }
        }
    }
}