
using budget_management.Messages;
using Domain.Entities;
using System.Globalization;
namespace budget_management.Services;

public class TransactionManagement
{
    private readonly FileManagement _fileManagement = new();

    public void AddTransaction()
    {
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

        Console.WriteLine("Transakcja została dodana.");
        System.Threading.Thread.Sleep(2000);
    }

    public decimal DisplayBalance()
    {
        var config = _fileManagement.ReadFromFile<Config>(FileManagement.ConfigFilePath);
        decimal budget = config.MonthBudget;

        DateTime currentDate = DateTime.Now;
        DateTime lastPayday;

        if (currentDate.Day >= config.Payday)
        {
            lastPayday = new DateTime(currentDate.Year, currentDate.Month, config.Payday);
        }
        else
        {
            int previousMonth = currentDate.Month - 1;
            int previousYear = currentDate.Year;
            if (previousMonth == 0)
            {
                previousMonth = 12;
                previousYear--;
            }

            int daysInPreviousMonth = DateTime.DaysInMonth(previousYear, previousMonth);
            lastPayday = new DateTime(previousYear, previousMonth, Math.Min(config.Payday, daysInPreviousMonth));
        }

        int monthsElapsed = ((currentDate.Year - lastPayday.Year) * 12) + currentDate.Month - lastPayday.Month;
        if (currentDate.Day < config.Payday) monthsElapsed--;

        decimal updatedBudget = budget + (monthsElapsed * budget);
        
        return updatedBudget;
    }

    public void CalculateAverageExpenses()
    {
        Console.Write("Podaj rok: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Podaj miesiąc (1-12): ");
        int month = int.Parse(Console.ReadLine());

        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsFilePath);

        var filteredTransactions = transactions.Where(t => t.Date.Year == year && t.Date.Month == month).ToList();

        if (filteredTransactions.Count == 0)
        {
            Console.WriteLine("Brak transakcji w wybranym miesiącu.");
            return;
        }

        var expenses = filteredTransactions.Where(t => t.Amount < 0).ToList();
        var incomes = filteredTransactions.Where(t => t.Amount > 0).ToList();

        decimal totalExpenses = expenses.Sum(t => t.Amount);
        decimal totalIncomes = incomes.Sum(t => t.Amount);

        decimal averageExpenses = expenses.Count > 0 ? totalExpenses / expenses.Count : 0;
        decimal averageIncomes = incomes.Count > 0 ? totalIncomes / incomes.Count : 0;

        Console.WriteLine($"Średnie wydatki za {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}: {Math.Abs(averageExpenses):C}");
        Console.WriteLine($"Średnie przychody za {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}: {averageIncomes:C}");

        Console.WriteLine();
        Console.WriteLine(InfoMessage.PressAnyKey());
        Console.ReadKey();
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
