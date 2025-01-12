using budget_management.Services;
namespace budget_management.Factories;

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
