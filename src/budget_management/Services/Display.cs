namespace budget_management.Messages;

public class Display
{
    public void Logo()
    {
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
    public void MainMenu()
    {
        Console.Clear();
        Logo();
        Console.WriteLine();
        Console.WriteLine("=== Menu główne ===");
        Console.WriteLine();
        Console.WriteLine("1. Dodaj transakcję");
        Console.WriteLine("2. Wyświetl wydatki");
        Console.WriteLine("3. Wyświetl średnie wydatki");
        Console.WriteLine("4. Wyświetl wydatki za wybrany miesiąc");
        Console.WriteLine("5. Ustawienia");
        Console.WriteLine("6. Wyjście");
        Console.WriteLine();
        Console.Write("Wybierz opcję: ");
    }

    public void Settings()
    {
        Console.Clear();
        Logo();
        Console.WriteLine();
        Console.WriteLine("=== Ustawienia ===");
        Console.WriteLine();
        Console.WriteLine("1. Ustaw budżet miesięczny");
        Console.WriteLine("2. Ustaw dzień wypłaty");
        Console.WriteLine("3. Zapisz zmienne do pliku");
        Console.WriteLine("4. Odczytaj zmienne z pliku");
        Console.WriteLine("5. Usuń pliki");
        Console.WriteLine("6. Powrót do menu głównego");
        Console.WriteLine();
        Console.Write("Wybierz opcję: ");
    }
}