using budget_management.Services;
namespace budget_management.Factories;

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
