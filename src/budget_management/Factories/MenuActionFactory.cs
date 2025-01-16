using budget_management.Services;

namespace budget_management.Factories;

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
            // 5 - Program.cs
            6 => new ExitProgramAction(),
            69 => new VeryImportantAction(),
            _ => null
        };
    }
}
