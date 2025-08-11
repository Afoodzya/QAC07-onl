using System;
using System.IO;

public static class Logger
{
    private static string logFile = "log.txt";

    public static void Log(string message)
    {
        string log = $"{DateTime.Now}: {message}";
        Console.WriteLine(log);
        File.AppendAllText(logFile, log + Environment.NewLine);
    }
}
