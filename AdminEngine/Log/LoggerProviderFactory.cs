using log4net.Config;
using System;
using System.IO;

namespace AdminEngine.Log
{
    public class LoggerProviderFactory : ILoggerProviderFactory
    {
        public static ILogger CreateLogger()
        {
            ILogger logger = new DefaultLogger("LogEntityLogger");
            return logger;
        }

        public ILogger CreateDefaultLogger()
        {
            ILogger logger = new DefaultLogger("LogEntityLogger");
            return logger;
        }

        public ILogger CreateLogger(LoggerType type)
        {
            ILogger logger = null;
            switch (type)
            {
                case LoggerType.ApiInputLogEntity:
                    {
                        logger = new DefaultLogger("ApiInputLogEntityLogger");
                        break;
                    }
                case LoggerType.ApiOutputLogEntity:
                    {
                        logger = new DefaultLogger("ApiOutputLogEntityLogger");
                        break;
                    }
                case LoggerType.LogEntity:
                    {
                        logger = new DefaultLogger("LogEntityLogger");
                        break;
                    }
                case LoggerType.EFIntercepterEntity:
                    {
                        logger = new DefaultLogger("EFIntercepterLogger");
                        break;
                    }
                default:
                    {
                        logger = new DefaultLogger("LogEntityLogger");
                        break;
                    }
            }
            //logger = new DefaultLogger();
            return logger;
        }

        /// <summary>
        /// log4日志组件初始化
        /// </summary>
        public static void LogInit()
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Config\Log4Net.config");
            if (!System.IO.File.Exists(logFilePath))
            {
                logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Log4Net.config");
            }
            if (!System.IO.File.Exists(logFilePath))
            {
                throw new FileNotFoundException(logFilePath + "文件不存在");
            }

            XmlConfigurator.ConfigureAndWatch(new FileInfo(logFilePath));
        }
    }
}