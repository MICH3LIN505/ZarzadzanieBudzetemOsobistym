using budget_management.Services;
namespace budget_management.Factories;

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

            4 => new ChangePasswordAction(_userManagement),
            5 => new DeleteFilesAction(new FileManagement()),
            _ => null
        };
    }
}