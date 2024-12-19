
using budget_management.Sounds;
namespace budget_management.Messages;

public static class Message
{
    public static string LoggedUserName { get; set; } = string.Empty;
    public static decimal Bilance { get; set; } = 0;
    public static void Error(string errorMessage)
    {
        Sound.ErrorSound();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("/!\\ ");
        Console.WriteLine(errorMessage);

        Thread.Sleep(2000);
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(16, Console.CursorTop - 1);

        Console.Write("\b");
        Console.Write(" ");
        Console.Write("\b");
        Console.ForegroundColor = ConsoleColor.White;
    }


    public static void Info(string infoMessage)
    {
        Sound.InfoSound();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("(i) ");
        Console.WriteLine(infoMessage);

        Thread.Sleep(2000);
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(16, Console.CursorTop - 1);

        Console.Write("\b");
        Console.Write(" ");
        Console.Write("\b");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Warning(string warningMessage)
    {
        Sound.WarningSound();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("/!\\ ");
        Console.WriteLine(warningMessage);

        Thread.Sleep(2000);
        Console.ForegroundColor = ConsoleColor.White;
    }
}