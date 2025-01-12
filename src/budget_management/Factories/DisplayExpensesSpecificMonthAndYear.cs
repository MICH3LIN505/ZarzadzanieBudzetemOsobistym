using budget_management.Services;
namespace budget_management.Factories;

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
