
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
        Console.WriteLine(TransactionMessage.AddTransactionHeader());
        Console.WriteLine();

        Console.Write(TransactionMessage.AddAmount());
        decimal amount = Value.ReadDecimal();

        Console.Write(TransactionMessage.AddNote());
        string? note = Value.ReadString();

        Console.Write(TransactionMessage.AddDate());
        DateTime date = Value.ReadDateTime();

        Transaction transaction = new()
        {
            Amount = amount,
            Note = note,
            Date = date
        };

        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsFilePath) ?? new List<Transaction>();
        transactions.Add(transaction);
        _fileManagement.SaveToFile(FileManagement.TransactionsFilePath, transactions);

        Message.Info(TransactionMessage.TransactionAdded());
    }

    public decimal DisplayBalance()
    {
        var config = _fileManagement.ReadFromFile<Config>(FileManagement.ConfigFilePath);

        decimal monthBudget = config.MonthBudget;
        decimal currentBudget = 0;
        int month = DateTime.Now.Month;

        var transactions = _fileManagement.ReadFromFile < List < Transaction >>(FileManagement.TransactionsFilePath) ?? new List<Transaction>();
        var currentMonthTransactions = transactions.Where(t => t.Date.Month == month).ToList();

        currentBudget = monthBudget + currentMonthTransactions.Sum(t => t.Amount);

        return currentBudget;
    }

    public void CalculateAverageExpenses()
    {
        Display.Logo();
        Console.WriteLine();
        Console.WriteLine(TransactionMessage.CalculateAverageExpensesHeader());
        Console.WriteLine();

        Console.Write(TransactionMessage.AddYear());
        int year = Value.ReadInt();

        Console.Write(TransactionMessage.AddMonth());
        int month = Value.ReadInt(1, 12);

        Display.Logo();
        Console.WriteLine();
        Console.WriteLine(TransactionMessage.CalculateAverageExpensesHeader());
        Console.WriteLine();

        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsFilePath);
        var filteredTransactions = transactions.Where(t => t.Date.Year == year && t.Date.Month == month).ToList();

        if (filteredTransactions.Count == 0)
        {
            Console.WriteLine(TransactionMessage.NoTransactions());
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

        Console.Write(TransactionMessage.AverageExpenses(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), year));
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{Math.Abs(averageExpenses):f} {TransactionMessage.Currency()}");
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write(TransactionMessage.AverageIncomes(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), year));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{averageIncomes:f} {TransactionMessage.Currency()}");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine();
        Console.WriteLine(InfoMessage.PressAnyKey());
        Console.ReadKey();
    }

    public void DisplayExpensesSpecificMonthAndYear()
    {
        Display.Logo();
        Console.WriteLine();
        Console.WriteLine(TransactionMessage.DisplayExpensesHeader());
        Console.WriteLine();

        Console.Write(TransactionMessage.AddYear());
        int year = Value.ReadInt();

        Console.Write(TransactionMessage.AddMonth());
        int month = Value.ReadInt(1, 12);

        Display.Logo();
        Console.WriteLine();
        Console.WriteLine(TransactionMessage.DisplayExpensesHeader());
        Console.WriteLine();

        var transactions = _fileManagement.ReadFromFile<List<Transaction>>(FileManagement.TransactionsFilePath) ?? [];
        decimal total = 0;

        foreach (var transaction in transactions)
        {
            if (transaction.Date.Year == year && transaction.Date.Month == month)
            {
                Console.Write($"[{transaction.Date.ToString("yyyy-MM-dd")}] ");

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

                Console.Write($"[{amount} " + $"{TransactionMessage.Currency()}] ");
                Console.ForegroundColor = ConsoleColor.DarkGray;

                if (!string.IsNullOrEmpty(transaction.Note))
                {
                    Console.WriteLine(transaction.Note);
                }
                else
                {
                    Console.WriteLine();
                }

                total += transaction.Amount;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        Console.WriteLine();
        Console.Write(TransactionMessage.MonthBalance(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), year));
        if (total < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        string totalString = total.ToString("0.00");
        while (totalString.Length - totalString.IndexOf('.') < 3)
        {
            totalString += "0";
        }

        Console.WriteLine($"{totalString} {TransactionMessage.Currency()}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();

        Console.WriteLine(InfoMessage.PressAnyKey());
        Console.ReadKey();
    }

    public void SetMonthBudget()
    {
        Display.Logo();
        Console.WriteLine();
        Console.WriteLine(TransactionMessage.SetMonthBudgetHeader());
        Console.WriteLine();

        var config = _fileManagement.ReadFromFile<Config>(FileManagement.ConfigFilePath);

        Console.Write(TransactionMessage.CurrentMonthBudget(config.MonthBudget));
        Console.WriteLine();

        Console.WriteLine(TransactionMessage.WannaSetNewBudget());
        Console.WriteLine(InfoMessage.SayYesToConfirm());

        string choice = Value.ReadString();

        if (choice == Decision.Affirmative)
        {
            Console.Write(TransactionMessage.SetNewBudget());
            int budget = Value.ReadInt(0);

            config.MonthBudget = budget;
            _fileManagement.SaveToFile(FileManagement.ConfigFilePath, config);

            Console.WriteLine(TransactionMessage.BudgetSet(budget));
        }
        else
        {
            Message.Info(InfoMessage.OperationCancelled());
        }
    }
}
