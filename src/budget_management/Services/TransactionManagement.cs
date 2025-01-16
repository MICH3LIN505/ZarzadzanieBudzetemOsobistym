
using budget_management.Messages;
using Domain.Entities;
using System.Globalization;
namespace budget_management.Services;

public class TransactionManagement
{
    private readonly FileManagement _fileManagement = new();

    public void AddTransaction()
    {
        Display.Logo();
        Console.WriteLine();
        Console.WriteLine("=== Dodawanie transakcji ===");
        Console.WriteLine();
        Console.Write("Podaj kwotę transakcji: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        Console.Write("Opcjonalna notatka (wciśnij Enter, aby pominąć): ");
        string? note = Console.ReadLine();
        Console.Write("Podaj datę (RRRR-MM-DD): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Transaction transaction = new()
        {
            Amount = amount,
            Note = note,
            Date = date
        };

        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsFilePath) ?? new List<Transaction>();
        transactions.Add(transaction);
        _fileManagement.SaveToFile(FileManagement.TransactionsFilePath, transactions);

        Message.Info("Transakcja została dodana.");
    }

    public decimal DisplayBalance()
    {
        var config = _fileManagement.ReadFromFile<Config>(FileManagement.ConfigFilePath);

        decimal monthBudget = config.MonthBudget;
        decimal currentBudget = 0;
        int month = DateTime.Now.Month;

        var transactions = _fileManagement.ReadFromFile < List < Transaction >>(FileManagement.TransactionsFilePath) ?? new List<Transaction>();
        var currentMonthTransactions = transactions.Where(t => t.Date.Month == month).ToList();

        currentBudget = monthBudget - currentMonthTransactions.Sum(t => t.Amount);

        return currentBudget;
    }

    public void CalculateAverageExpenses()
    {
        Display.Logo();
        Console.WriteLine();
        Console.WriteLine("=== Obliczanie średniej ===");
        Console.WriteLine();
        Console.Write("Podaj rok: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Podaj miesiąc (1-12): ");
        int month = int.Parse(Console.ReadLine());

        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsFilePath);

        var filteredTransactions = transactions.Where(t => t.Date.Year == year && t.Date.Month == month).ToList();

        if (filteredTransactions.Count == 0)
        {
            Console.WriteLine("Brak transakcji w wybranym miesiącu.");
            Console.WriteLine();
            Console.WriteLine(InfoMessage.PressAnyKey());
            Console.ReadKey();
            return;
        }

        var expenses = filteredTransactions.Where(t => t.Amount < 0).ToList();
        var incomes = filteredTransactions.Where(t => t.Amount > 0).ToList();

        decimal totalExpenses = expenses.Sum(t => t.Amount);
        decimal totalIncomes = incomes.Sum(t => t.Amount);

        decimal averageExpenses = expenses.Count > 0 ? totalExpenses / expenses.Count : 0;
        decimal averageIncomes = incomes.Count > 0 ? totalIncomes / incomes.Count : 0;

        Console.Write($"Średnie wydatki za {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{Math.Abs(averageExpenses):C}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"Średnie przychody za {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{averageIncomes:C}");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine();
        Console.WriteLine(InfoMessage.PressAnyKey());
        Console.ReadKey();
    }

    public void DisplayExpensesSpecificMonthAndYear()
    {
        Display.Logo();
        Console.WriteLine();
        Console.WriteLine("=== Wyświetlanie transakcji ===");
        Console.WriteLine();
        Console.Write("Podaj rok: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Podaj miesiąc (1-12): ");
        int month = int.Parse(Console.ReadLine());

        Display.Logo();
        Console.WriteLine();
        Console.WriteLine("=== Wyświetlanie transakcji ===");
        Console.WriteLine();

        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsFilePath) ?? [];
        decimal total = 0;

        foreach (var transaction in transactions)
        {
            if (transaction.Date.Year == year && transaction.Date.Month == month)
            {
                Console.Write($"[{transaction.Date.ToString("yyyy.MM.dd")}] ");

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

                Console.Write($"[{amount}] ");
                Console.ForegroundColor = ConsoleColor.DarkGray;

                if (!string.IsNullOrEmpty(transaction.Note))
                {
                    Console.WriteLine(transaction.Note);
                }

                total += transaction.Amount;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Bilans z {month}/{year} wynosi {total:C}");
        Console.WriteLine();
        Console.WriteLine(InfoMessage.PressAnyKey());
        Console.ReadKey();
    }

    public void SetMonthBudget()
    {
        Display.Logo();
        Console.WriteLine();
        Console.WriteLine("=== Ustalanie budżetu ===");
        Console.WriteLine();
        Console.WriteLine("Twój aktualny budżet jest ustawiony na: ");

        var config = _fileManagement.ReadFromFile<Config>(FileManagement.ConfigFilePath);

        Console.WriteLine($"Twój aktualny budżet wynosi: {config.MonthBudget:C}");
        Console.WriteLine();
        Console.Write("Podaj nowy budżet miesięczny: ");
        int budget = int.Parse(Console.ReadLine());
        Console.WriteLine("Czy na pewno chcesz ustawić nowy budżet?");
        string choice = Console.ReadLine().ToLower();

        if (choice == "tak")
        {
            config.MonthBudget = budget;
            _fileManagement.SaveToFile(FileManagement.ConfigFilePath, config);
            Console.WriteLine("Budżet miesięczny został ustawiony.");
        }
        else
        {
            Console.WriteLine("Budżet nie został zmieniony.");
        }

        //Console.WriteLine("Podaj nowy budżet miesięczny:");
        //decimal budget = decimal.Parse(Console.ReadLine());

        //var config = _fileManagement.ReadFromFile<Dictionary<string, object>>(FileManagement.ConfigFilePath) ?? new Dictionary<string, object>();
        //config["MonthBudget"] = budget;
        //_fileManagement.SaveToFile(FileManagement.ConfigFilePath, config);

        //Console.WriteLine("Budżet miesięczny został ustawiony.");
    }
}
