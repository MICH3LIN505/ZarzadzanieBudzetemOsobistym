
namespace budget_management.Messages;

public static class Display
{
    public static void Logo()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("$$$$$$$$\\ $$$$$$$\\   $$$$$$\\  ");
        Console.WriteLine("\\____$$  |$$  __$$\\ $$  __$$\\ ");
        Console.WriteLine("    $$  / $$ |  $$ |$$ /  $$ |");
        Console.WriteLine("   $$  /  $$$$$$$\\ |$$ |  $$ |");
        Console.WriteLine("  $$  /   $$  __$$\\ $$ |  $$ |");
        Console.WriteLine(" $$  /    $$ |  $$ |$$ |  $$ |");
        Console.WriteLine("$$$$$$$$\\ $$$$$$$  | $$$$$$  |");
        Console.WriteLine("\\________|\\_______/  \\______/ - Zarządzanie Budżetem Osobistym");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void LoginPanel()
    {
        Console.WriteLine();
        Console.WriteLine("=== Panel logowania ===");
        Console.WriteLine();
        Console.WriteLine("1. Rejestracja");
        Console.WriteLine("2. Logowanie");
        Console.WriteLine("3. Zmiana hasła");
        Console.WriteLine("4. Wyjście");
        Console.WriteLine();
        Console.Write("Wybierz opcję: ");
    }
    public static void MainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== Menu główne ===");
        Console.WriteLine();
        Console.WriteLine("1. Dodaj transakcję");
        Console.WriteLine("2. Wyświetl bilans");
        Console.WriteLine("3. Oblicz średnią");
        Console.WriteLine("4. Wyświetl wydatki za wybrany miesiąc");
        Console.WriteLine("5. Ustawienia");
        Console.WriteLine("6. Wyloguj się");
        Console.WriteLine("7. Wyjście");
        Console.WriteLine();
        Console.Write("Wybierz opcję: ");
    }

    public static void Settings()
    {
        Console.WriteLine();
        Console.WriteLine("=== Ustawienia ===");
        Console.WriteLine();
        Console.WriteLine("1. Ustal budżet miesięczny");
        Console.WriteLine("2. Ustaw dzień wypłaty");
        Console.WriteLine("3. Ustawienia dźwięku");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("4. Usuń profil użytkownika");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("5. Powrót do menu głównego");
        Console.WriteLine();
        Console.Write("Wybierz opcję: ");
    }
}