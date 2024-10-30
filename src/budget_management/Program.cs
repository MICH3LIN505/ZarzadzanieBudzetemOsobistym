using System.Collections.Specialized;
using System.Transactions;

namespace Domain.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        void MainMenu()
        {
            Console.WriteLine("X. Dodaj transakcję");
            Console.WriteLine("X. Wyświetl sumę wydatków / przychodów");
            Console.WriteLine("X. Wyświetl wszystkie transakcje z ostatnich 24 miesięcy");
            Console.WriteLine("X. Oblicz średnią wydatków w ciągu miesiąca");
            Console.WriteLine("X. Wyświetl wydatki z konkretnego miesiąca i roku");
            Console.WriteLine("X. Wyjście");
            Console.WriteLine("\nWybór: ");
        }
        void Settings()
        {
            Console.WriteLine("1. Ustal budżet miesięczny");
            Console.WriteLine("2. Zmień datę wypłaty");
            Console.WriteLine("3. Usuń plik zapisu");
        }

        void SetMonthBudget()
        {
            Console.Write("Podaj nowy budżet miesięczny: ");
            double budzet = double.Parse(Console.ReadLine());
            Console.WriteLine($"Budżet wynosi: {budzet}");
        }

        void AddExpense()
        {
            Console.WriteLine("Podaj kwotę wydatku:");
            double wydatek = double.Parse(Console.ReadLine());
            Console.WriteLine($"Dodano wydatek w kwocie: {wydatek}");
        }

        void DisplayTotalExpenses()
        {
            Console.WriteLine("Suma wydatków wynosi: ");
        }

        void DisplayAllExpenses()
        {
            Console.WriteLine("Wszystkie wydatki z ostatnich 24 miesięcy:");
        }

        void CalculateAverageExpenses()
        {
            Console.WriteLine("Średnia wydatków w ciągu miesiąca wynosi: ");
        }

        void DisplayExpensesSpecificMonthAndYear()
        {
            Console.WriteLine("Podaj miesiąc:");
            int miesiac = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj rok:");
            int rok = int.Parse(Console.ReadLine());
            Console.WriteLine($"Wydatki z miesiąca {miesiac} roku {rok}:");
        }

        void SaveToFile()
        {
            Console.WriteLine("Zapisano do pliku");
        }

        void ReadFromFile()
        {
            Console.WriteLine("Wczytano z pliku");
        }

        int choice;
        do
        {
            MainMenu();
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    SetMonthBudget();
                    break;
                case 2:
                    AddExpense();
                    Transaction transaction = new(100, DateTime.Now, "Opis", "Kategoria", "Tytuł", "Typ");
                    break;
                case 3:
                    DisplayTotalExpenses();
                    break;
                case 4:
                    DisplayAllExpenses();
                    break;
                case 5:
                    CalculateAverageExpenses();
                    break;
                case 6:
                    DisplayExpensesSpecificMonthAndYear();
                    break;
                case 7:
                    SaveToFile();
                    break;
                case 8:
                    ReadFromFile();
                    break;
                case 9:
                    Console.WriteLine("Do widzenia!");
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór");
                    break;
            }
        } while (choice != 9);
    }
}