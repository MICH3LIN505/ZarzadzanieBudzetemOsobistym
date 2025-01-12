using budget_management.Services;
namespace budget_management.Factories;

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
