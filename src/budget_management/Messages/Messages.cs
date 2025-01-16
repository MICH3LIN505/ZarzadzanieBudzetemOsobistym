
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

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(InfoMessage.PressAnyKey());
        Console.ReadKey();
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(16, Console.CursorTop - 1);

        Console.Write("\b");
        Console.Write(" ");
        Console.Write("\b");
    }


    public static void Info(string infoMessage)
    {
        Sound.InfoSound();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("(i) ");
        Console.WriteLine(infoMessage);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(InfoMessage.PressAnyKey());
        Console.ReadKey();
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(16, Console.CursorTop - 1);

        Console.Write("\b");
        Console.Write(" ");
        Console.Write("\b");
    }

    public static void Warning(string warningMessage)
    {
        Sound.WarningSound();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("/!\\ ");
        Console.WriteLine(warningMessage);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(InfoMessage.PressAnyKey());
        Console.ReadKey();
    }
}