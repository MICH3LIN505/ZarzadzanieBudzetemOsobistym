
using budget_management.Sounds;
namespace budget_management.Messages;

public static class ErrorMessage
{
    public static string InvalidChoice() => "Nieprawidłowy wybór";
    public static string FileExists() => "Plik już istnieje";
}

public static class InfoMessage
{
    public static string PressAnyKey() => "Naciśnij dowolny klawisz, aby kontynuować...";
    public static string ChooseOption() => "Wybierz opcję" + ": ";
    public static string OperationCancelled() => "Operacja anulowana";
    public static string FilesDeleted() => "Pliki zapisu i ustawień zostały usunięte";
    public static string Goodbye() => "Lambert, ty... to znaczy bywaj!";
}

public static class WarningMessage
{
    public static string FileNotFound() => "Nie znaleziono pliku";
    public static string DeleteFiles() => "Uwaga!\nCzy na pewno chcesz usunąć pliki zapisu i ustawień?\nOperacja jest nieodwracalna!";
}

public static class Message
{
    public static void Error(string errorMessage)
    {
        Sound.ErrorSound();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("/!\\ ");
        Console.WriteLine(errorMessage);

        System.Threading.Thread.Sleep(2000);
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

        System.Threading.Thread.Sleep(2000);
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

        System.Threading.Thread.Sleep(2000);
        //Console.SetCursorPosition(0, Console.CursorTop - 1);
        //Console.Write(new string(' ', Console.WindowWidth));
        //Console.SetCursorPosition(16, Console.CursorTop - 1);

        //Console.Write("\b");
        //Console.Write(" ");
        //Console.Write("\b");
        Console.ForegroundColor = ConsoleColor.White;
    }
}