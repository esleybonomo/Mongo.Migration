using Microsoft.Extensions.Logging;

public class ApplicationLogging
{
	private static ILoggerFactory _factory = null;

	public static void ConfigureLogger(ILoggerFactory factory)
	{
		factory.AddFile("logs/migration/log-migration.log");
	}

	/// <summary>
	/// Create logFactory instance
	/// </summary>
	/// <returns>Logger factory instance</returns>
	public static ILoggerFactory LoggerFactory
	{
		get
		{
			if (_factory == null)
			{
				_factory = new LoggerFactory();
				ConfigureLogger(_factory);
			}
			return _factory;
		}
	}

	/// <summary>
	/// creates a logger instance configured to use in migrations
	/// </summary>
	/// <returns>ILogger instance</returns>
	public static ILogger CreateLogger() => LoggerFactory.CreateLogger("logger");
}