namespace NokSolve.Utils;

public class Logger
{
    public static void Info(string message)
    {
        Console.ResetColor();
        Console.WriteLine(message);
    }
    
    public static void Warn(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
    }
    
    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
    }
}