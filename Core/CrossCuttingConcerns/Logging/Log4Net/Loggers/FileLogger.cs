using log4net;

namespace Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FileLogger : LoggerManager
    {
        public FileLogger() : base("JsonFileLogger")
        {
        }
    }
}
