
using budget_management.Messages;
namespace budget_management.Services;

public interface IMenuAction
{
    void Execute();
}

// FUNKCJE MENU GŁÓWNEGO

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
        _transactionManagement.DisplayBalance();
    }
}
internal class CalculateAverageExpenses : IMenuAction
{
    protected readonly TransactionManagement _transactionManagement;

    public CalculateAverageExpenses(TransactionManagement transactionManagement)
    {
        _transactionManagement = transactionManagement;
    }

    public void Execute()
    {
        _transactionManagement.CalculateAverageExpenses();
    }
}

internal class DisplayExpensesSpecificMonthAndYear : IMenuAction
{
    protected readonly TransactionManagement _transactionManagement;

    public DisplayExpensesSpecificMonthAndYear(TransactionManagement transactionManagement)
    {
        _transactionManagement = transactionManagement;
    }

    public void Execute()
    {
        _transactionManagement.DisplayExpensesSpecificMonthAndYear();
    }
}

public class ExitProgramAction : IMenuAction
{
    public void Execute()
    {
        FileManagement fileManagement = new();
        fileManagement.ExitProcedure();
    }
}

// FUNKCJE USTAWIEŃ

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

public sealed class SetSoundsAction : IMenuAction
{
    private readonly UserManagement _userManagement;

    public SetSoundsAction(UserManagement userManagement)
    {
        _userManagement = userManagement;
    }

    public void Execute()
    {
        _userManagement.SetSounds();
    }
}

public sealed class DeleteFilesAction : IMenuAction
{
    private readonly FileManagement _fileManagement;

    public DeleteFilesAction(FileManagement fileManagement)
    {
        _fileManagement = fileManagement;
    }

    public void Execute()
    {
        UserManagement userManagement = new();
        userManagement.DeleteUser();
    }
}

// MENU GŁÓWNE

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
            2 => new CalculateAverageExpenses(_transactionManagement),
            3 => new DisplayExpensesSpecificMonthAndYear(_transactionManagement),
            4 => new SettingsMenuAction(_settingsMenuFactory),
            // brakujący numer znajduje się w Program.cs
            6 => new ExitProgramAction(),
            _ => null
        };
    }
}

//MENU USTAWIEŃ
public class SettingsMenuAction : IMenuAction
{
    private readonly SettingsMenuFactory _settingsMenuFactory;

    public SettingsMenuAction(SettingsMenuFactory settingsMenuFactory)
    {
        _settingsMenuFactory = settingsMenuFactory;
    }

    public void Execute()
    {
        Display.Logo();
        Display.Settings();

        int settingsChoice;
        while (!int.TryParse(Console.ReadLine(), out settingsChoice))
        {
            Message.Error(ErrorMessage.InvalidChoice());
        }

        if (settingsChoice == 5) return;

        var action = _settingsMenuFactory.GetAction(settingsChoice);
        action?.Execute();
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
            3 => new SetSoundsAction(_userManagement),
            4 => new DeleteFilesAction(new FileManagement()),
            _ => null
        };
    }
}