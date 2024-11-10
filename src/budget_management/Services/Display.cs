// konstrukcja i wyświetlanie menu głównego

namespace budget_management.Services;
public class Display
{
    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Dodaj transakcję");
        Console.WriteLine("2. Wyświetl sumę wydatków / przychodów");
        Console.WriteLine("3. Wyświetl wydatki z konkretnego miesiąca i roku");
        Console.WriteLine("4. Oblicz średnią wydatków w ciągu miesiąca");
        Console.WriteLine("5. Ustawienia");
        Console.WriteLine("6. Wyjście");
        Console.Write("\nWybór: ");
    }

    public void Settings()
    {
        Console.Clear();
        Console.WriteLine("1. Ustal budżet miesięczny");
        Console.WriteLine("2. Zmień datę wypłaty");
        Console.WriteLine("3. Zapisz do pliku");
        Console.WriteLine("4. Wczytaj z pliku");
        Console.WriteLine("5. Usuń plik zapisu");
        Console.Write("\nWybór: ");
    }
}
