namespace AdminEngine.Log
{
    public interface ILoggerProviderFactory
    {
        ILogger CreateDefaultLogger();

        ILogger CreateLogger(LoggerType type);
    }
}