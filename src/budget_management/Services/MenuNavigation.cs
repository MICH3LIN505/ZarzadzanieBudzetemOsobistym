using budget_management.Messages;
namespace budget_management.Services;

public interface IMenuAction
{
    void Execute();
}

public class AddTransactionAction : IMenuAction
{
    private readonly TransactionManagement _transactionManagement;

    public AddTransactionAction(TransactionManagement transactionManagement)
    {
        _transactionManagement = transactionManagement;
    }

    public void Execute()
    {
        _transactionManagement.AddTransaction();
    }
}

public class DisplayTotalExpensesAction : IMenuAction
{
    public readonly TransactionManagement _transactionManagement;

    public DisplayTotalExpensesAction(TransactionManagement transactionManagement)
    {
        _transactionManagement = transactionManagement;
    }

    public void Execute()
    {
        _transactionManagement.DisplayTotalExpenses();
    }
}

public class SettingsMenuAction : IMenuAction
{
    private readonly SettingsMenuFactory _settingsMenuFactory;

    public SettingsMenuAction(SettingsMenuFactory settingsMenuFactory)
    {
        _settingsMenuFactory = settingsMenuFactory;
    }

    public void Execute()
    {
        Console.Clear();
        Display.Logo();
        Console.WriteLine();
        Console.WriteLine("=== Ustawienia ===");
        Console.WriteLine();
        Console.WriteLine("1. Ustaw budżet miesięczny");
        Console.WriteLine("2. Ustaw dzień wypłaty");
        Console.WriteLine("3. Powrót do głównego menu");
        Console.WriteLine();
        Console.Write("Wybierz opcję: ");

        int settingsChoice;
        while (!int.TryParse(Console.ReadLine(), out settingsChoice))
        {
            ErrorMessage.InvalidChoice();
        }

        if (settingsChoice == 3) return;

        var action = _settingsMenuFactory.GetAction(settingsChoice);
        action?.Execute();
        ErrorMessage.InvalidChoice();
    }
}

public class MenuActionFactory
{
    private readonly TransactionManagement _transactionManagement;
    private readonly SettingsMenuFactory _settingsMenuFactory;

    public MenuActionFactory(TransactionManagement transactionManagement, SettingsMenuFactory settingsMenuFactory)
    {
        _transactionManagement = transactionManagement;
        _settingsMenuFactory = settingsMenuFactory;
    }

    public IMenuAction? GetAction(int choice)
    {
        return choice switch
        {
            1 => new AddTransactionAction(_transactionManagement),
            2 => new DisplayTotalExpensesAction(_transactionManagement),
            3 => new CalculateAverageExpenses(_transactionManagement),
            4 => new DisplayExpensesSpecificMonthAndYear(_transactionManagement),
            5 => new SettingsMenuAction(_settingsMenuFactory),
            6 => new ExitProgramAction(),
            _ => null
        };
    }
}

internal class CalculateAverageExpenses : DisplayTotalExpensesAction
{
    public CalculateAverageExpenses(TransactionManagement transactionManagement) : base(transactionManagement)
    {
        _transactionManagement.CalculateAverageExpenses();
    }
}

internal class DisplayExpensesSpecificMonthAndYear : CalculateAverageExpenses
{
    public DisplayExpensesSpecificMonthAndYear(TransactionManagement transactionManagement) : base(transactionManagement)
    {
        _transactionManagement.DisplayExpensesSpecificMonthAndYear();
    }
}

public class SettingsMenuFactory
{
    private readonly TransactionManagement _transactionManagement;
    private readonly UserManagement _userManagement;

    public SettingsMenuFactory(TransactionManagement transactionManagement, UserManagement userManagement)
    {
        _transactionManagement = transactionManagement;
        _userManagement = userManagement;
    }

    public IMenuAction? GetAction(int choice)
    {
        return choice switch
        {
            1 => new SetMonthBudgetAction(_transactionManagement),
            2 => new SetPaydayAction(_userManagement),
            _ => null
        };
    }
}

public class SetMonthBudgetAction : IMenuAction
{
    private readonly TransactionManagement _transactionManagement;

    public SetMonthBudgetAction(TransactionManagement transactionManagement)
    {
        _transactionManagement = transactionManagement;
    }

    public void Execute()
    {
        _transactionManagement.SetMonthBudget();
    }
}

public class SetPaydayAction : IMenuAction
{
    private readonly UserManagement _userManagement;

    public SetPaydayAction(UserManagement userManagement)
    {
        _userManagement = userManagement;
    }

    public void Execute()
    {
        _userManagement.SetPayday();
    }
}

public class ExitProgramAction : IMenuAction
{
    public void Execute()
    {
        InfoMessage.Goodbye();
        Environment.Exit(0);
    }
}
