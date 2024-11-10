//metody do zarządzania transakcjami

namespace budget_management.Services;
using Domain.Entities;
using Messages;
public class TransactionManagement
{
    public void SetMonthBudget()
    {
        Console.WriteLine("Podaj nowy budżet miesięczny: ");
        decimal budget = decimal.Parse(Console.ReadLine());
        Console.WriteLine($"Nowy budżet wynosi: {budget}");
        Console.WriteLine("Czy na pewno chcesz go ustawić? (T/N): ");
        string choice = Console.ReadLine();
        if (choice == "T")
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\micha\Desktop\budget.txt"))
            {
                writer.WriteLine(budget);
            }
            Console.WriteLine($"Budżet został ustawiony na {budget}");
        }
        else
        {
            Console.WriteLine("Modyfikacja budżetu została anulowana");
        }
    }
    public void AddTransaction()
    {
        Console.WriteLine("Podaj kwotę wydatku:");
        string title = Console.ReadLine();

        decimal wydatek = decimal.Parse(Console.ReadLine());
        string note = Console.ReadLine();

        Transaction transaction = new(title, wydatek, note);
    }

    public void DisplayTotalExpenses()
    {
        Console.WriteLine("Suma wydatków wynosi: ");
    }

    public void DisplayAllExpenses()
    {
        Console.WriteLine("Wszystkie wydatki z ostatnich 24 miesięcy:");
    }

    public void CalculateAverageExpenses()
    {
        Console.WriteLine("Średnia wydatków w ciągu miesiąca wynosi: ");
    }

    public void DisplayExpensesSpecificMonthAndYear()
    {
        Console.WriteLine("Podaj miesiąc:");
        int miesiac = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj rok:");
        int rok = int.Parse(Console.ReadLine());
        Console.WriteLine($"Wydatki z miesiąca {miesiac} roku {rok}:");
    }
}
