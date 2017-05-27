using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Authentication.Database
{
  public class DatabaseLoggerProvider : ILoggerProvider
  {
    public void Dispose() { }

    public ILogger CreateLogger(string categoryName)
    {
      if (categoryName == typeof(IRelationalCommandBuilderFactory).FullName)
        return new EntityFrameworkLogger();

      return new NullLogger();
    }

    public class EntityFrameworkLogger : ILogger
    {
      public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
      {
        var newLine = Environment.NewLine;
        File.AppendAllText(@"C:\temp\DatabaseLog.txt", $"{newLine}[Database Query - ({DateTime.UtcNow.ToLocalTime()})]{newLine}{formatter(state, exception)}{newLine}");
        Console.WriteLine($"{newLine}[Database Query - ({DateTime.UtcNow.ToLocalTime()})]{newLine}{formatter(state, exception)}{newLine}");
      }

      public bool IsEnabled(LogLevel logLevel) => true;

      public IDisposable BeginScope<TState>(TState state) => null;
    }

    private class NullLogger : ILogger
    {
      public bool IsEnabled(LogLevel logLevel)
      {
        return false;
      }

      public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
      { }

      public IDisposable BeginScope<TState>(TState state)
      {
        return null;
      }
    }
  }
}
