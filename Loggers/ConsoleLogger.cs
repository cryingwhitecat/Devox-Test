using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;

namespace DevoxAPI.Loggers
{

    public class ConsoleLogger : LoggerBase
    {
        public ConsoleLogger(LoggerBase innerLogger=null) : base(innerLogger)
        {
            _logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();
        }
        
    }
}
