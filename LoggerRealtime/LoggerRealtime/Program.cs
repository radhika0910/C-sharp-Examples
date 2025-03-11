using System;
using System.IO;

namespace LoggerRealtime
{
    public interface Ilogger
    {
        void LogInfo();
        void LogWarn();
        void LogError();
    }

    class Writer
    {
        internal void WriteToFile(string message, string logType, string directoryPath)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
            string filePath = Path.Combine(directoryPath, $"{logType}Log_{timestamp}.txt");

            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                File.AppendAllText(filePath, message + Environment.NewLine);

                Console.WriteLine($"{logType} log written to: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing {logType} log: {ex.Message}");
            }
        }
    }

    class CloudLogging : Writer, Ilogger
    {
        private string directoryPath;

        public CloudLogging(string directoryPath)
        {
            this.directoryPath = directoryPath;
        }

        public void LogInfo() { WriteToFile("Cloud Log info", "Cloud", directoryPath); }
        public void LogWarn() { WriteToFile("Cloud Warn info", "Cloud", directoryPath); }
        public void LogError() { WriteToFile("Cloud Error info", "Cloud", directoryPath); }
    }

    class FileLogging : Writer, Ilogger
    {
        private string directoryPath;

        public FileLogging(string directoryPath)
        {
            this.directoryPath = directoryPath;
        }

        public void LogInfo() { WriteToFile("File Log info", "File", directoryPath); }
        public void LogWarn() { WriteToFile("File Warn info", "File", directoryPath); }
        public void LogError() { WriteToFile("File Error info", "File", directoryPath); }
    }

    class ConsoleLogging : Writer, Ilogger
    {
        private string directoryPath;

        public ConsoleLogging(string directoryPath)
        {
            this.directoryPath = directoryPath;
        }

        public void LogInfo() { WriteToFile("Console Log info", "Console", directoryPath); }
        public void LogWarn() { WriteToFile("Console Warn info", "Console", directoryPath); }
        public void LogError() { WriteToFile("Console Error info", "Console", directoryPath); }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the directory path for Cloud logs: ");
            string cloudDirectory = Console.ReadLine();

            Console.Write("Enter the directory path for File logs: ");
            string fileDirectory = Console.ReadLine();

            Console.Write("Enter the directory path for Console logs: ");
            string consoleDirectory = Console.ReadLine();

            CloudLogging cloudLogger = new CloudLogging(cloudDirectory);
            FileLogging fileLogger = new FileLogging(fileDirectory);
            ConsoleLogging consoleLogger = new ConsoleLogging(consoleDirectory);

            cloudLogger.LogInfo();
            cloudLogger.LogWarn();
            cloudLogger.LogError();

            fileLogger.LogInfo();
            fileLogger.LogWarn();
            fileLogger.LogError();

            consoleLogger.LogInfo();
            consoleLogger.LogWarn();
            consoleLogger.LogError();

            Console.WriteLine("Logging complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}