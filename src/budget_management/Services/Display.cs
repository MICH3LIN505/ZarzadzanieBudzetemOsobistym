
namespace budget_management.Messages;

public static class Display
{
    public static void Logo(bool Color = true)
    {
        Console.Clear();
        if (Color)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
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
        Console.WriteLine("1. Logowanie");
        Console.WriteLine("2. Rejestracja");
        Console.WriteLine("3. Wyjście");
        Console.WriteLine();
        Console.Write("Wybierz opcję: ");
    }
    public static void MainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== Menu główne ===");
        Console.WriteLine();
        Console.WriteLine("1. Dodaj transakcję");
        Console.WriteLine("2. Oblicz średnią");
        Console.WriteLine("3. Wyświetl transakcje");
        Console.WriteLine("4. Ustawienia");
        Console.WriteLine("5. Wyloguj się");
        Console.WriteLine("6. Wyjście");
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
        Console.WriteLine("4. Zmień hasło");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("5. Usuń profil użytkownika");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("6. Powrót do menu głównego");
        Console.WriteLine();
        Console.Write("Wybierz opcję: ");
    }
}