using System;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;

namespace Naveego.Sdk.Logging
{
    internal class StdErrSink : ILogEventSink
    {
        private readonly IFormatProvider _formatProvider;

        public StdErrSink(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }
        
        public void Emit(LogEvent logEvent)
        {
            var level = GetLevelString(logEvent.Level);
            Console.Error.WriteLine($"[{level}] {logEvent.RenderMessage(_formatProvider)}");
        }

        private string GetLevelString(LogEventLevel level) => level switch
        {
            LogEventLevel.Debug => "DEBUG",
            LogEventLevel.Error => "ERROR",
            LogEventLevel.Fatal => "ERROR",
            LogEventLevel.Verbose => "TRACE",
            LogEventLevel.Warning => "WARN",
            _ => "INFO"
        };

    }
    
    public static class StdErrSinkExtensions
    {
        public static LoggerConfiguration StdErrSink(this LoggerSinkConfiguration loggerConfiguration,
            IFormatProvider formatProvider = null)
        {
            return loggerConfiguration.Sink(new StdErrSink(formatProvider));
        }
    }
}