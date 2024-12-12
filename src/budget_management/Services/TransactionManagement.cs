
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

        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsFilePath) ?? new List<Transaction>();
        transactions.Add(transaction);
        _fileManagement.SaveToFile(FileManagement.TransactionsFilePath, transactions);

        Console.WriteLine("Transakcja została dodana.");
        System.Threading.Thread.Sleep(2000);
    }

    public void DisplayTotalExpenses()
    {
        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsFilePath) ?? new List<Transaction>();
        decimal total = 0;

        foreach (var transaction in transactions)
        {
            total += transaction.Amount;
        }

        Console.WriteLine($"Całkowity bilans wynosi {total:C}");
        System.Threading.Thread.Sleep(2000);
    }

    public void CalculateAverageExpenses()
    {
        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsFilePath) ?? [];
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
        System.Threading.Thread.Sleep(2000);
    }

    public void DisplayExpensesSpecificMonthAndYear()
    {
        Console.Write("Podaj rok: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Podaj miesiąc (1-12): ");
        int month = int.Parse(Console.ReadLine());

        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsFilePath) ?? [];
        decimal total = 0;

        foreach (var transaction in transactions)
        {
            if (transaction.Date.Year == year && transaction.Date.Month == month)
            {
                Console.Write($"[{transaction.Date.ToString("yyyy.MM.dd")}]");
                Console.Write(" ");

                if (transaction.Amount > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                string amount = transaction.Amount.ToString("0.00");
                while (amount.Length - amount.IndexOf('.') < 3)
                {
                    amount += "0";
                }

                Console.WriteLine($"[{amount}]");
                Console.ForegroundColor = ConsoleColor.DarkGray;

                if (!string.IsNullOrEmpty(transaction.Note))
                {
                    Console.WriteLine(transaction.Note);
                }

                total += transaction.Amount;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        
        Console.WriteLine($"Bilans z {month}/{year} wynosi {total:C}");
        Console.ReadKey();
    }

    public void SetMonthBudget()
    {
        Console.WriteLine("Podaj budżet miesięczny:");
        decimal budget = decimal.Parse(Console.ReadLine());

        var config = _fileManagement.ReadFromFile<Dictionary<string, object>>(FileManagement.ConfigFilePath) ?? new Dictionary<string, object>();
        config["MonthBudget"] = budget;
        _fileManagement.SaveToFile(FileManagement.ConfigFilePath, config);

        Console.WriteLine("Budżet miesięczny został ustawiony.");
    }
}
