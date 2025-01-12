using budget_management.Services;
namespace budget_management.Factories;

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
