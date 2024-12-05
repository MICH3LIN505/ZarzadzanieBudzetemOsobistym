
using Domain.Entities;
namespace budget_management.Services;

public class TransactionManagement
{
    private readonly FileManagement _fileManagement = new();

    public void AddTransaction()
    {
        Console.WriteLine("Podaj kwotę transakcji:");
        decimal amount = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Opcjonalna notatka (wciśnij Enter, aby pominąć):");
        string? note = Console.ReadLine();
        Console.WriteLine("Podaj datę (RRRR-MM-DD):");
        DateTime date = DateTime.Parse(Console.ReadLine());

        var transaction = new Transaction
        {
            Amount = amount,
            Note = note,
            Date = date
        };

        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsPath) ?? new List<Transaction>();
        transactions.Add(transaction);
        _fileManagement.SaveToFile(FileManagement.TransactionsPath, transactions);

        Console.WriteLine("Transakcja została dodana.");
    }

    public void DisplayTotalExpenses()
    {
        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsPath) ?? new List<Transaction>();
        decimal total = 0;

        foreach (var transaction in transactions)
        {
            total += transaction.Amount;
        }

        Console.WriteLine($"Całkowite wydatki: {total:C}");
    }

    public void CalculateAverageExpenses()
    {
        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsPath) ?? new List<Transaction>();
        if (transactions.Count == 0)
        {
            Console.WriteLine("Brak transakcji.");
            return;
        }

        decimal total = 0;
        foreach (var transaction in transactions)
        {
            total += transaction.Amount;
        }

        Console.WriteLine($"Średnie wydatki: {total / transactions.Count:C}");
    }

    public void DisplayExpensesSpecificMonthAndYear()
    {
        Console.WriteLine("Podaj rok:");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj miesiąc (1-12):");
        int month = int.Parse(Console.ReadLine());

        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsPath) ?? new List<Transaction>();
        decimal total = 0;

        foreach (var transaction in transactions)
        {
            if (transaction.Date.Year == year && transaction.Date.Month == month)
            {
                total += transaction.Amount;
            }
        }

        Console.WriteLine($"Wydatki z {month}/{year}: {total:C}");
    }

    public void SetMonthBudget()
    {
        Console.WriteLine("Podaj budżet miesięczny:");
        decimal budget = decimal.Parse(Console.ReadLine());

        var config = _fileManagement.ReadFromFile<Dictionary<string, object>>(FileManagement.ConfigPath) ?? new Dictionary<string, object>();
        config["MonthBudget"] = budget;
        _fileManagement.SaveToFile(FileManagement.ConfigPath, config);

        Console.WriteLine("Budżet miesięczny został ustawiony.");
    }
}
